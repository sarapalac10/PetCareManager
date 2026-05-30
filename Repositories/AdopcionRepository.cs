using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using PetCareInterface.Data;

namespace PetCareInterface.Repositories
{
    /// <summary>
    /// Repositorio de la entidad <see cref="Adopcion"/>.
    /// Guarda solo los identificadores del animal y del adoptante, y al leer
    /// reconstruye los objetos relacionados reutilizando sus repositorios.
    /// </summary>
    public class AdopcionRepository : IRepository<Adopcion>
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly IRepository<Animal> _animalRepository;
        private readonly IRepository<Adoptante> _adoptanteRepository;

        public AdopcionRepository(
            IConnectionFactory connectionFactory,
            IRepository<Animal> animalRepository,
            IRepository<Adoptante> adoptanteRepository)
        {
            _connectionFactory = connectionFactory;
            _animalRepository = animalRepository;
            _adoptanteRepository = adoptanteRepository;
        }

        /// <summary>CREATE: registra una nueva solicitud de adopción.</summary>
        public void Agregar(Adopcion adopcion)
        {
            try
            {
                using SqliteConnection conexion = _connectionFactory.CreateConnection();
                using SqliteCommand comando = conexion.CreateCommand();
                comando.CommandText = @"
                    INSERT INTO Adopciones (Id, AnimalId, AdoptanteId, FechaSolicitud, Estado)
                    VALUES ($id, $animalId, $adoptanteId, $fecha, $estado);";
                comando.Parameters.AddWithValue("$id", adopcion.Id);
                comando.Parameters.AddWithValue("$animalId", adopcion.Animal.Id);
                comando.Parameters.AddWithValue("$adoptanteId", adopcion.Adoptante.Id);
                comando.Parameters.AddWithValue("$fecha", adopcion.FechaSolicitud.ToString("o"));
                comando.Parameters.AddWithValue("$estado", adopcion.Estado.ToString());
                comando.ExecuteNonQuery();
            }
            catch (SqliteException ex)
            {
                throw new DataAccessException(
                    $"No se pudo registrar la adopción. ¿Ya existe una con el ID {adopcion.Id}?", ex);
            }
        }

        /// <summary>READ: obtiene una adopción por su ID, o null si no existe.</summary>
        public Adopcion? ObtenerPorId(int id)
        {
            try
            {
                using SqliteConnection conexion = _connectionFactory.CreateConnection();
                using SqliteCommand comando = conexion.CreateCommand();
                comando.CommandText = "SELECT Id, AnimalId, AdoptanteId, FechaSolicitud, Estado FROM Adopciones WHERE Id = $id;";
                comando.Parameters.AddWithValue("$id", id);

                using SqliteDataReader lector = comando.ExecuteReader();
                if (lector.Read())
                    return Mapear(lector);

                return null;
            }
            catch (SqliteException ex)
            {
                throw new DataAccessException("No se pudo consultar la adopción.", ex);
            }
        }

        /// <summary>READ: obtiene todas las adopciones.</summary>
        public IReadOnlyList<Adopcion> ObtenerTodos()
        {
            try
            {
                var adopciones = new List<Adopcion>();

                using SqliteConnection conexion = _connectionFactory.CreateConnection();
                using SqliteCommand comando = conexion.CreateCommand();
                comando.CommandText = "SELECT Id, AnimalId, AdoptanteId, FechaSolicitud, Estado FROM Adopciones ORDER BY Id;";

                using SqliteDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                    adopciones.Add(Mapear(lector));

                return adopciones;
            }
            catch (SqliteException ex)
            {
                throw new DataAccessException("No se pudo obtener la lista de adopciones.", ex);
            }
        }

        /// <summary>UPDATE: actualiza el estado (y las relaciones) de una adopción.</summary>
        public void Actualizar(Adopcion adopcion)
        {
            try
            {
                using SqliteConnection conexion = _connectionFactory.CreateConnection();
                using SqliteCommand comando = conexion.CreateCommand();
                comando.CommandText = @"
                    UPDATE Adopciones
                    SET AnimalId = $animalId, AdoptanteId = $adoptanteId, Estado = $estado
                    WHERE Id = $id;";
                comando.Parameters.AddWithValue("$id", adopcion.Id);
                comando.Parameters.AddWithValue("$animalId", adopcion.Animal.Id);
                comando.Parameters.AddWithValue("$adoptanteId", adopcion.Adoptante.Id);
                comando.Parameters.AddWithValue("$estado", adopcion.Estado.ToString());

                int filas = comando.ExecuteNonQuery();
                if (filas == 0)
                    throw new DataAccessException(
                        $"No existe ninguna adopción con el ID {adopcion.Id} para actualizar.",
                        new InvalidOperationException());
            }
            catch (SqliteException ex)
            {
                throw new DataAccessException("No se pudo actualizar la adopción.", ex);
            }
        }

        /// <summary>DELETE: elimina una adopción por su ID.</summary>
        public void Eliminar(int id)
        {
            try
            {
                using SqliteConnection conexion = _connectionFactory.CreateConnection();
                using SqliteCommand comando = conexion.CreateCommand();
                comando.CommandText = "DELETE FROM Adopciones WHERE Id = $id;";
                comando.Parameters.AddWithValue("$id", id);

                int filas = comando.ExecuteNonQuery();
                if (filas == 0)
                    throw new DataAccessException(
                        $"No existe ninguna adopción con el ID {id} para eliminar.",
                        new InvalidOperationException());
            }
            catch (SqliteException ex)
            {
                throw new DataAccessException("No se pudo eliminar la adopción.", ex);
            }
        }

        /// <summary>
        /// Convierte una fila del lector en un objeto <see cref="Adopcion"/>,
        /// reconstruyendo el animal y el adoptante a partir de sus IDs.
        /// </summary>
        private Adopcion Mapear(SqliteDataReader lector)
        {
            int animalId = lector.GetInt32(1);
            int adoptanteId = lector.GetInt32(2);

            Animal? animal = _animalRepository.ObtenerPorId(animalId);
            Adoptante? adoptante = _adoptanteRepository.ObtenerPorId(adoptanteId);

            if (animal == null || adoptante == null)
                throw new DataAccessException(
                    "La adopción referencia un animal o adoptante que ya no existe.",
                    new InvalidOperationException());

            var estado = (EstadoAdopcion)Enum.Parse(typeof(EstadoAdopcion), lector.GetString(4));

            return new Adopcion(
                lector.GetInt32(0),
                animal,
                adoptante,
                DateTime.Parse(lector.GetString(3)),
                estado);
        }
    }
}
