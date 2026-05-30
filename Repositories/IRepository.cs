using System.Collections.Generic;

namespace PetCareInterface.Repositories
{
    /// <summary>
    /// Contrato genérico para el acceso a datos (patrón Repository).
    /// Define las operaciones CRUD que toda entidad persistente debe soportar.
    /// Al programar contra esta interfaz, la GUI no depende de SQLite ni del SQL
    /// concreto (Inversión de Dependencias y Segregación de Interfaces - SOLID).
    /// </summary>
    /// <typeparam name="T">Tipo de la entidad gestionada.</typeparam>
    public interface IRepository<T>
    {
        /// <summary>Inserta una nueva entidad (CREATE).</summary>
        void Agregar(T entidad);

        /// <summary>Devuelve una entidad por su identificador, o null si no existe (READ).</summary>
        T? ObtenerPorId(int id);

        /// <summary>Devuelve todas las entidades almacenadas (READ).</summary>
        IReadOnlyList<T> ObtenerTodos();

        /// <summary>Actualiza los datos de una entidad existente (UPDATE).</summary>
        void Actualizar(T entidad);

        /// <summary>Elimina una entidad por su identificador (DELETE).</summary>
        void Eliminar(int id);
    }
}
