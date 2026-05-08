using System;
using System.Windows.Forms;

namespace PetCareInterface
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // --- SECCIÓN ANIMAL ---
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtIdAnimal.Text) ||
                    string.IsNullOrWhiteSpace(txtNombreAnimal.Text) ||
                    string.IsNullOrWhiteSpace(txtEspecie.Text))
                {
                    MessageBox.Show("Por favor, llena todos los datos del Animal.");
                    return;
                }

                int id = int.Parse(txtIdAnimal.Text);
                string nombre = txtNombreAnimal.Text;
                string raza = txtEspecie.Text;

                Animal prueba = new Animal(id, nombre, raza);


                MessageBox.Show($"Mascota registrada con éxito:\n\n" +
                 $"ID: {id}\n" +
                 $"Nombre: {nombre}\n" +
                 $"Raza: {raza}",
                 "Sistema PetCare", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtIdAnimal.Clear(); txtNombreAnimal.Clear(); txtEspecie.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Error en Animal: El ID debe ser un número.");
            }
        }

        // --- SECCIÓN ADOPTANTE ---
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtIdAdoptante.Text) ||
                    string.IsNullOrWhiteSpace(txtNombreAdoptante.Text) ||
                    string.IsNullOrWhiteSpace(txtTelefono.Text))
                {
                    MessageBox.Show("Por favor, llena todos los datos del Adoptante.");
                    return;
                }

                int id = int.Parse(txtIdAdoptante.Text);
                string nombre = txtNombreAdoptante.Text;
                string telefono = txtTelefono.Text;

                Adoptante nuevoAdoptante = new Adoptante(id, nombre, telefono);

                
                MessageBox.Show($"Adoptante registrado con éxito:\n\n" +
                $"Cédula: {id}\n" +
                $"Nombre: {nombre}\n" +
                $"Teléfono: {telefono}",
                "Registro de Adoptantes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Error en Adoptante: Revisa que el ID sea un número.");
            }
        }

        // --- FUNCIONES QUE EL DISEÑADOR NECESITA (NO BORRAR) ---
        private void txtNombre_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { } // Corregido
        private void textBox3_TextChanged(object sender, EventArgs e) { } // Corregido
        private void txtIdAdoptante_TextChanged(object sender, EventArgs e) { }
    }
}