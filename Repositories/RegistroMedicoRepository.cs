using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using PetCareInterface.Data;

namespace PetCareInterface.Repositories
{
    /// <summary>
    /// Repositorio de la entidad <see cref="RegistroMedico"/>.
    /// Guarda el identificador del animal y al leer reconstruye el objeto
    /// relacionado reutilizando el repositorio de animales.
    /// </summary>
    public class RegistroMedicoRepository : IRepository<RegistroMedico>
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly IRepository<Animal> _animalRepository;

        public RegistroMedicoRepository(
            IConnectionFactory connectionFactory,
            IRepository<Animal> animalRepository)
        {
            _connectionFactory = connectionFactory;
            _animalRepository = animalRepository;
        }

        /// <summary>CREATE: inserta un nuevo registro médico.</summary>
        public void Agregar(RegistroMedico registro)
        {
            try
            {
                using SqliteConnection conexion = _connectionFactory.CreateConnection();
                using SqliteCommand comando = conexion.CreateCommand();
                comando.CommandText = @"
                    INSERT INTO RegistrosMedicos (Id, AnimalId, Diagnostico, Tratamiento, Fecha)
                    VALUES ($id, $animalId, $diagnostico, $tratamiento, $fecha);";
                comando.Parameters.AddWithValue("$id", registro.Id);
                comando.Parameters.AddWithValue("$animalId", registro.Animal.Id);
                comando.Parameters.AddWithValue("$diagnostico", registro.Diagnostico);
                comando.Parameters.AddWithValue("$tratamiento", registro.Tratamiento);
                comando.Parameters.AddWithValue("$fecha", registro.Fecha.ToString("o"));
                comando.ExecuteNonQuery();
            }
            catch (SqliteException ex)
            {
                throw new DataAccessException(
                    $"No se pudo registrar el historial médico. ¿Ya existe uno con el ID {registro.Id}?", ex);
            }
        }

        /// <summary>READ: obtiene un registro médico por su ID, o null si no existe.</summary>
        public RegistroMedico? ObtenerPorId(int id)
        {
            try
            {
                using SqliteConnection conexion = _connectionFactory.CreateConnection();
                using SqliteCommand comando = conexion.CreateCommand();
                comando.CommandText = "SELECT Id, AnimalId, Diagnostico, Tratamiento, Fecha FROM RegistrosMedicos WHERE Id = $id;";
                comando.Parameters.AddWithValue("$id", id);

                using SqliteDataReader lector = comando.ExecuteReader();
                if (lector.Read())
                    return Mapear(lector);

                return null;
            }
            catch (SqliteException ex)
            {
                throw new DataAccessException("No se pudo consultar el registro médico.", ex);
            }
        }

        /// <summary>READ: obtiene todos los registros médicos.</summary>
        public IReadOnlyList<RegistroMedico> ObtenerTodos()
        {
            try
            {
                var registros = new List<RegistroMedico>();

                using SqliteConnection conexion = _connectionFactory.CreateConnection();
                using SqliteCommand comando = conexion.CreateCommand();
                comando.CommandText = "SELECT Id, AnimalId, Diagnostico, Tratamiento, Fecha FROM RegistrosMedicos ORDER BY Id;";

                using SqliteDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                    registros.Add(Mapear(lector));

                return registros;
            }
            catch (SqliteException ex)
            {
                throw new DataAccessException("No se pudo obtener la lista de registros médicos.", ex);
            }
        }

        /// <summary>UPDATE: actualiza los datos de un registro médico existente.</summary>
        public void Actualizar(RegistroMedico registro)
        {
            try
            {
                using SqliteConnection conexion = _connectionFactory.CreateConnection();
                using SqliteCommand comando = conexion.CreateCommand();
                comando.CommandText = @"
                    UPDATE RegistrosMedicos
                    SET AnimalId = $animalId, Diagnostico = $diagnostico, Tratamiento = $tratamiento
                    WHERE Id = $id;";
                comando.Parameters.AddWithValue("$id", registro.Id);
                comando.Parameters.AddWithValue("$animalId", registro.Animal.Id);
                comando.Parameters.AddWithValue("$diagnostico", registro.Diagnostico);
                comando.Parameters.AddWithValue("$tratamiento", registro.Tratamiento);

                int filas = comando.ExecuteNonQuery();
                if (filas == 0)
                    throw new DataAccessException(
                        $"No existe ningún registro médico con el ID {registro.Id} para actualizar.",
                        new InvalidOperationException());
            }
            catch (SqliteException ex)
            {
                throw new DataAccessException("No se pudo actualizar el registro médico.", ex);
            }
        }

        /// <summary>DELETE: elimina un registro médico por su ID.</summary>
        public void Eliminar(int id)
        {
            try
            {
                using SqliteConnection conexion = _connectionFactory.CreateConnection();
                using SqliteCommand comando = conexion.CreateCommand();
                comando.CommandText = "DELETE FROM RegistrosMedicos WHERE Id = $id;";
                comando.Parameters.AddWithValue("$id", id);

                int filas = comando.ExecuteNonQuery();
                if (filas == 0)
                    throw new DataAccessException(
                        $"No existe ningún registro médico con el ID {id} para eliminar.",
                        new InvalidOperationException());
            }
            catch (SqliteException ex)
            {
                throw new DataAccessException("No se pudo eliminar el registro médico.", ex);
            }
        }

        /// <summary>
        /// Convierte una fila del lector en un objeto <see cref="RegistroMedico"/>,
        /// reconstruyendo el animal a partir de su ID.
        /// </summary>
        private RegistroMedico Mapear(SqliteDataReader lector)
        {
            int animalId = lector.GetInt32(1);
            Animal? animal = _animalRepository.ObtenerPorId(animalId);

            if (animal == null)
                throw new DataAccessException(
                    "El registro médico referencia un animal que ya no existe.",
                    new InvalidOperationException());

            return new RegistroMedico(
                lector.GetInt32(0),
                animal,
                lector.GetString(2),
                lector.GetString(3),
                DateTime.Parse(lector.GetString(4)));
        }
    }
}
