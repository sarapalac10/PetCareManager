using Microsoft.Data.Sqlite;

namespace PetCareInterface.Data
{
    /// <summary>
    /// Implementación de <see cref="IConnectionFactory"/> para SQLite.
    /// Centraliza la cadena de conexión: si algún día se cambia de motor,
    /// solo se modifica esta clase (Responsabilidad Única - SOLID).
    /// </summary>
    public class SqliteConnectionFactory : IConnectionFactory
    {
        private readonly string _connectionString;

        /// <summary>
        /// Crea la fábrica apuntando al archivo de base de datos indicado.
        /// </summary>
        /// <param name="rutaBaseDatos">Ruta del archivo .db de SQLite.</param>
        public SqliteConnectionFactory(string rutaBaseDatos)
        {
            _connectionString = $"Data Source={rutaBaseDatos}";
        }

        /// <inheritdoc/>
        public SqliteConnection CreateConnection()
        {
            var conexion = new SqliteConnection(_connectionString);
            conexion.Open();
            return conexion;
        }
    }
}
