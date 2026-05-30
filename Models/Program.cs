using System;
using System.IO;
using System.Windows.Forms;
using PetCareInterface.Data;
using PetCareInterface.Repositories;

namespace PetCareInterface
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Ruta del archivo de base de datos SQLite (junto al ejecutable).
            string rutaBaseDatos = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PetCare.db");

            // --- Composición de dependencias (Composition Root) ---
            // Aquí se crean las implementaciones concretas una sola vez y se
            // inyectan hacia las capas superiores como interfaces (DIP - SOLID).
            IConnectionFactory connectionFactory = new SqliteConnectionFactory(rutaBaseDatos);

            // Crea las tablas si la base de datos aún no existe.
            new DatabaseInitializer(connectionFactory).Inicializar();

            IRepository<Animal> animalRepo = new AnimalRepository(connectionFactory);
            IRepository<Adoptante> adoptanteRepo = new AdoptanteRepository(connectionFactory);
            IRepository<Adopcion> adopcionRepo = new AdopcionRepository(connectionFactory, animalRepo, adoptanteRepo);
            IRepository<RegistroMedico> registroRepo = new RegistroMedicoRepository(connectionFactory, animalRepo);

            try
            {
                Application.Run(new Form1(animalRepo, adoptanteRepo, adopcionRepo, registroRepo));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado:\n" + ex.Message,
                    "PetCare Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
