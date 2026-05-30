using Microsoft.Data.Sqlite;

namespace PetCareInterface.Data
{
    /// <summary>
    /// Abstracción para la creación de conexiones a la base de datos.
    /// Permite que los repositorios dependan de una interfaz y no de una
    /// implementación concreta (Principio de Inversión de Dependencias - SOLID).
    /// </summary>
    public interface IConnectionFactory
    {
        /// <summary>
        /// Crea y abre una nueva conexión lista para usarse.
        /// </summary>
        SqliteConnection CreateConnection();
    }
}
