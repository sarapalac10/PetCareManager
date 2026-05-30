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
