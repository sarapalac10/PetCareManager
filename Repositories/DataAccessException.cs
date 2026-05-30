using System;

namespace PetCareInterface.Repositories
{
    /// <summary>
    /// Excepción propia de la capa de acceso a datos.
    /// Envuelve los errores técnicos de SQLite en un mensaje claro,
    /// de modo que la GUI no tenga que conocer detalles del motor de base de datos.
    /// </summary>
    public class DataAccessException : Exception
    {
        public DataAccessException(string mensaje, Exception innerException)
            : base(mensaje, innerException)
        {
        }
    }
}
