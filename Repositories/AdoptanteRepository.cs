using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using PetCareInterface.Data;

namespace PetCareInterface.Repositories
{
    /// <summary>
    /// Repositorio de la entidad <see cref="Adoptante"/>.
    /// Implementa el CRUD completo sobre la tabla "Adoptantes" usando ADO.NET.
    /// </summary>
    public class AdoptanteRepository : IRepository<Adoptante>
    {
        private readonly IConnectionFactory _connectionFactory;

        public AdoptanteRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        /// <summary>CREATE: inserta un nuevo adoptante.</summary>
        public void Agregar(Adoptante adoptante)
        {
            try
            {
                using SqliteConnection conexion = _connectionFactory.CreateConnection();
                using SqliteCommand comando = conexion.CreateCommand();
                comando.CommandText = @"
                    INSERT INTO Adoptantes (Id, Nombre, Telefono)
                    VALUES ($id, $nombre, $telefono);";
                comando.Parameters.AddWithValue("$id", adoptante.Id);
                comando.Parameters.AddWithValue("$nombre", adoptante.Nombre);
                comando.Parameters.AddWithValue("$telefono", adoptante.Telefono);
                comando.ExecuteNonQuery();
            }
            catch (SqliteException ex)
            {
                throw new DataAccessException(
                    $"No se pudo registrar el adoptante. ¿Ya existe uno con la cédula {adoptante.Id}?", ex);
            }
        }

        /// <summary>READ: obtiene un adoptante por su ID, o null si no existe.</summary>
        public Adoptante? ObtenerPorId(int id)
        {
            try
            {
                using SqliteConnection conexion = _connectionFactory.CreateConnection();
                using SqliteCommand comando = conexion.CreateCommand();
                comando.CommandText = "SELECT Id, Nombre, Telefono FROM Adoptantes WHERE Id = $id;";
                comando.Parameters.AddWithValue("$id", id);

                using SqliteDataReader lector = comando.ExecuteReader();
                if (lector.Read())
                    return Mapear(lector);

                return null;
            }
            catch (SqliteException ex)
            {
                throw new DataAccessException("No se pudo consultar el adoptante.", ex);
            }
        }

        /// <summary>READ: obtiene todos los adoptantes.</summary>
        public IReadOnlyList<Adoptante> ObtenerTodos()
        {
            try
            {
                var adoptantes = new List<Adoptante>();

                using SqliteConnection conexion = _connectionFactory.CreateConnection();
                using SqliteCommand comando = conexion.CreateCommand();
                comando.CommandText = "SELECT Id, Nombre, Telefono FROM Adoptantes ORDER BY Id;";

                using SqliteDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                    adoptantes.Add(Mapear(lector));

                return adoptantes;
            }
            catch (SqliteException ex)
            {
                throw new DataAccessException("No se pudo obtener la lista de adoptantes.", ex);
            }
        }

        /// <summary>UPDATE: actualiza los datos de un adoptante existente.</summary>
        public void Actualizar(Adoptante adoptante)
        {
            try
            {
                using SqliteConnection conexion = _connectionFactory.CreateConnection();
                using SqliteCommand comando = conexion.CreateCommand();
                comando.CommandText = @"
                    UPDATE Adoptantes
                    SET Nombre = $nombre, Telefono = $telefono
                    WHERE Id = $id;";
                comando.Parameters.AddWithValue("$id", adoptante.Id);
                comando.Parameters.AddWithValue("$nombre", adoptante.Nombre);
                comando.Parameters.AddWithValue("$telefono", adoptante.Telefono);

                int filas = comando.ExecuteNonQuery();
                if (filas == 0)
                    throw new DataAccessException(
                        $"No existe ningún adoptante con la cédula {adoptante.Id} para actualizar.",
                        new System.InvalidOperationException());
            }
            catch (SqliteException ex)
            {
                throw new DataAccessException("No se pudo actualizar el adoptante.", ex);
            }
        }

        /// <summary>DELETE: elimina un adoptante por su ID.</summary>
        public void Eliminar(int id)
        {
            try
            {
                using SqliteConnection conexion = _connectionFactory.CreateConnection();
                using SqliteCommand comando = conexion.CreateCommand();
                comando.CommandText = "DELETE FROM Adoptantes WHERE Id = $id;";
                comando.Parameters.AddWithValue("$id", id);

                int filas = comando.ExecuteNonQuery();
                if (filas == 0)
                    throw new DataAccessException(
                        $"No existe ningún adoptante con la cédula {id} para eliminar.",
                        new System.InvalidOperationException());
            }
            catch (SqliteException ex)
            {
                throw new DataAccessException("No se pudo eliminar el adoptante.", ex);
            }
        }

        /// <summary>
        /// Convierte una fila del lector en un objeto <see cref="Adoptante"/>.
        /// </summary>
        private static Adoptante Mapear(SqliteDataReader lector)
        {
            return new Adoptante(
                lector.GetInt32(0),
                lector.GetString(1),
                lector.GetString(2));
        }
    }
}
