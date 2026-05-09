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

        // --- 1. SECCIÓN ANIMAL (Validación + Try-Catch) ---
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Validación de campos vacíos (Primera línea de defensa)
                if (string.IsNullOrWhiteSpace(txtIdAnimal.Text) ||
                    string.IsNullOrWhiteSpace(txtNombreAnimal.Text) ||
                    string.IsNullOrWhiteSpace(txtEspecie.Text))
                {
                    MessageBox.Show("Por favor, llena todos los datos del Animal.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtIdAnimal.Text);
                string nombre = txtNombreAnimal.Text;
                string raza = txtEspecie.Text;

                // Instancia del objeto (Backend)
                Animal prueba = new Animal(id, nombre, raza);

                MessageBox.Show($"Mascota registrada con éxito:\n\nID: {id}\nNombre: {nombre}\nRaza: {raza}",
                 "Sistema PetCare", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtIdAnimal.Clear(); txtNombreAnimal.Clear(); txtEspecie.Clear();
            }
            catch (Exception)
            {
                // Captura de error si el ID no es número (Segunda línea de defensa)
                MessageBox.Show("Error en Animal: El ID debe ser un número entero.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- 2. SECCIÓN ADOPTANTE (Validación + Try-Catch) ---
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtIdAdoptante.Text) ||
                    string.IsNullOrWhiteSpace(txtNombreAdoptante.Text) ||
                    string.IsNullOrWhiteSpace(txtTelefono.Text))
                {
                    MessageBox.Show("Por favor, llena todos los datos del Adoptante.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtIdAdoptante.Text);
                string nombre = txtNombreAdoptante.Text;
                string telefono = txtTelefono.Text;

                Adoptante nuevoAdoptante = new Adoptante(id, nombre, telefono);

                MessageBox.Show($"Adoptante registrado con éxito:\n\nCédula: {id}\nNombre: {nombre}\nTeléfono: {telefono}",
                "Registro de Adoptantes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtIdAdoptante.Clear(); txtNombreAdoptante.Clear(); txtTelefono.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Error en Adoptante: Revisa que la cédula sea un número.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- 3. SECCIÓN ACCIONES SEGURAS (Requisito de Tarea: Confirmación) ---
        
        private void btnRechazar_Click(object sender, EventArgs e)
        {
            // Cuadro de diálogo para confirmar acción irreversible
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de que desea rechazar esta solicitud? Esta acción no se puede deshacer.",
                "Confirmación de Seguridad",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                // Solo ocurre si el usuario presiona "Sí"
                MessageBox.Show("La solicitud ha sido rechazada exitosamente.", "Acción Realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Opcional: aviso de que no se hizo nada
                MessageBox.Show("Operación cancelada.", "Sistema PetCare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // --- FUNCIONES DEL DISEÑADOR (NO BORRAR) ---
        private void txtNombre_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void txtIdAdoptante_TextChanged(object sender, EventArgs e) { }
    }
}
