using Microsoft.Data.Sqlite;

namespace PetCareInterface.Data
{
    /// <summary>
    /// Se encarga de crear las tablas de la base de datos si aún no existen.
    /// Se ejecuta una sola vez al iniciar la aplicación.
    /// </summary>
    public class DatabaseInitializer
    {
        private readonly IConnectionFactory _connectionFactory;

        public DatabaseInitializer(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        /// <summary>
        /// Crea el esquema completo (todas las tablas) si no existe.
        /// </summary>
        public void Inicializar()
        {
            using SqliteConnection conexion = _connectionFactory.CreateConnection();
            using SqliteCommand comando = conexion.CreateCommand();

            comando.CommandText = @"
                CREATE TABLE IF NOT EXISTS Animales (
                    Id            INTEGER PRIMARY KEY,
                    Nombre        TEXT NOT NULL,
                    Especie       TEXT NOT NULL,
                    Estado        TEXT NOT NULL,
                    FechaIngreso  TEXT NOT NULL
                );

                CREATE TABLE IF NOT EXISTS Adoptantes (
                    Id        INTEGER PRIMARY KEY,
                    Nombre    TEXT NOT NULL,
                    Telefono  TEXT NOT NULL
                );

                CREATE TABLE IF NOT EXISTS Adopciones (
                    Id              INTEGER PRIMARY KEY,
                    AnimalId        INTEGER NOT NULL,
                    AdoptanteId     INTEGER NOT NULL,
                    FechaSolicitud  TEXT NOT NULL,
                    Estado          TEXT NOT NULL,
                    FOREIGN KEY (AnimalId)    REFERENCES Animales(Id),
                    FOREIGN KEY (AdoptanteId) REFERENCES Adoptantes(Id)
                );

                CREATE TABLE IF NOT EXISTS RegistrosMedicos (
                    Id           INTEGER PRIMARY KEY,
                    AnimalId     INTEGER NOT NULL,
                    Diagnostico  TEXT NOT NULL,
                    Tratamiento  TEXT NOT NULL,
                    Fecha        TEXT NOT NULL,
                    FOREIGN KEY (AnimalId) REFERENCES Animales(Id)
                );";

            comando.ExecuteNonQuery();
        }
    }
}
