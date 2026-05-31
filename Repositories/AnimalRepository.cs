using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using PetCareInterface.Data;

namespace PetCareInterface.Repositories
{
    /// <summary>
    /// Repositorio de la entidad <see cref="Animal"/>.
    /// Implementa el CRUD completo sobre la tabla "Animales" usando ADO.NET.
    /// </summary>
    public class AnimalRepository : IRepository<Animal>
    {
        private readonly IConnectionFactory _connectionFactory;

        public AnimalRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        /// <summary>CREATE: inserta un nuevo animal.</summary>
        public void Agregar(Animal animal)
        {
            try
            {
                using SqliteConnection conexion = _connectionFactory.CreateConnection();
                using SqliteCommand comando = conexion.CreateCommand();
                comando.CommandText = @"
                    INSERT INTO Animales (Id, Nombre, Especie, Estado, FechaIngreso)
                    VALUES ($id, $nombre, $especie, $estado, $fecha);";
                comando.Parameters.AddWithValue("$id", animal.Id);
                comando.Parameters.AddWithValue("$nombre", animal.Nombre);
                comando.Parameters.AddWithValue("$especie", animal.Especie);
                comando.Parameters.AddWithValue("$estado", animal.Estado);
                comando.Parameters.AddWithValue("$fecha", animal.FechaIngreso.ToString("o"));
                comando.ExecuteNonQuery();
            }
            catch (SqliteException ex)
            {
                throw new DataAccessException(
                    $"No se pudo registrar el animal. ¿Ya existe un animal con el ID {animal.Id}?", ex);
            }
        }

        /// <summary>READ: obtiene un animal por su ID, o null si no existe.</summary>
        public Animal? ObtenerPorId(int id)
        {
            try
            {
                using SqliteConnection conexion = _connectionFactory.CreateConnection();
                using SqliteCommand comando = conexion.CreateCommand();
                comando.CommandText = "SELECT Id, Nombre, Especie, Estado, FechaIngreso FROM Animales WHERE Id = $id;";
                comando.Parameters.AddWithValue("$id", id);

                using SqliteDataReader lector = comando.ExecuteReader();
                if (lector.Read())
                    return Mapear(lector);

                return null;
            }
            catch (SqliteException ex)
            {
                throw new DataAccessException("No se pudo consultar el animal.", ex);
            }
        }

        /// <summary>READ: obtiene todos los animales.</summary>
        public IReadOnlyList<Animal> ObtenerTodos()
        {
            try
            {
                var animales = new List<Animal>();

                using SqliteConnection conexion = _connectionFactory.CreateConnection();
                using SqliteCommand comando = conexion.CreateCommand();
                comando.CommandText = "SELECT Id, Nombre, Especie, Estado, FechaIngreso FROM Animales ORDER BY Id;";

                using SqliteDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                    animales.Add(Mapear(lector));

                return animales;
            }
            catch (SqliteException ex)
            {
                throw new DataAccessException("No se pudo obtener la lista de animales.", ex);
            }
        }

        /// <summary>UPDATE: actualiza los datos de un animal existente.</summary>
        public void Actualizar(Animal animal)
        {
            try
            {
                using SqliteConnection conexion = _connectionFactory.CreateConnection();
                using SqliteCommand comando = conexion.CreateCommand();
                comando.CommandText = @"
                    UPDATE Animales
                    SET Nombre = $nombre, Especie = $especie, Estado = $estado
                    WHERE Id = $id;";
                comando.Parameters.AddWithValue("$id", animal.Id);
                comando.Parameters.AddWithValue("$nombre", animal.Nombre);
                comando.Parameters.AddWithValue("$especie", animal.Especie);
                comando.Parameters.AddWithValue("$estado", animal.Estado);

                int filas = comando.ExecuteNonQuery();
                if (filas == 0)
                    throw new DataAccessException(
                        $"No existe ningún animal con el ID {animal.Id} para actualizar.",
                        new InvalidOperationException());
            }
            catch (SqliteException ex)
            {
                throw new DataAccessException("No se pudo actualizar el animal.", ex);
            }
        }

        /// <summary>DELETE: elimina un animal por su ID.</summary>
        public void Eliminar(int id)
        {
            try
            {
                using SqliteConnection conexion = _connectionFactory.CreateConnection();

                // Integridad referencial: no se puede borrar un animal que tenga
                // adopciones o registros médicos asociados (quedarían huérfanos).
                int adopciones = ContarReferencias(conexion, "Adopciones", "AnimalId", id);
                int registros = ContarReferencias(conexion, "RegistrosMedicos", "AnimalId", id);
                if (adopciones > 0 || registros > 0)
                    throw new DataAccessException(
                        $"No se puede eliminar el animal: tiene {adopciones} adopción(es) y " +
                        $"{registros} registro(s) médico(s) asociados. Elimina primero esos registros.",
                        new InvalidOperationException());

                using SqliteCommand comando = conexion.CreateCommand();
                comando.CommandText = "DELETE FROM Animales WHERE Id = $id;";
                comando.Parameters.AddWithValue("$id", id);

                int filas = comando.ExecuteNonQuery();
                if (filas == 0)
                    throw new DataAccessException(
                        $"No existe ningún animal con el ID {id} para eliminar.",
                        new InvalidOperationException());
            }
            catch (SqliteException ex)
            {
                throw new DataAccessException("No se pudo eliminar el animal.", ex);
            }
        }

        /// <summary>
        /// Cuenta cuántas filas de otra tabla referencian al animal indicado.
        /// Se usa para validar la integridad referencial antes de eliminar.
        /// Los nombres de tabla y columna son constantes internas (no entran datos
        /// del usuario), por lo que no hay riesgo de inyección SQL.
        /// </summary>
        private static int ContarReferencias(SqliteConnection conexion, string tabla, string columna, int id)
        {
            using SqliteCommand comando = conexion.CreateCommand();
            comando.CommandText = $"SELECT COUNT(*) FROM {tabla} WHERE {columna} = $id;";
            comando.Parameters.AddWithValue("$id", id);
            return Convert.ToInt32(comando.ExecuteScalar());
        }

        /// <summary>
        /// Convierte una fila del lector en un objeto <see cref="Animal"/>.
        /// </summary>
        private static Animal Mapear(SqliteDataReader lector)
        {
            return new Animal(
                lector.GetInt32(0),
                lector.GetString(1),
                lector.GetString(2),
                lector.GetString(3),
                DateTime.Parse(lector.GetString(4)));
        }
    }
}
