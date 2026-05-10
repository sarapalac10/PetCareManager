using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PetCareInterface
{
    public partial class Form1 : Form
    {
        // ── Listas en memoria (backend) ──────────────────────────────────────
        private List<Animal> listaAnimales = new List<Animal>();
        private List<Adoptante> listaAdoptantes = new List<Adoptante>();
        private List<Adopcion> listaAdopciones = new List<Adopcion>();
        private List<RegistroMedico> listaRegistrosMedicos = new List<RegistroMedico>();

        private int contadorAnimales = 1;
        private int contadorAdoptantes = 1;
        private int contadorAdopciones = 1;
        private int contadorRegistros = 1;

        public Form1()
        {
            InitializeComponent();
            txtTelefonoAdoptante.KeyPress += txtTelefonoAdoptante_KeyPress;
            CargarDatosIniciales();
        }

        private void txtTelefonoAdoptante_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        // ── Datos de prueba para demostración ────────────────────────────────
        private void CargarDatosIniciales()
        {
            try
            {
                var a1 = new Animal(contadorAnimales++, "Luna", "Perro");
                a1.ActualizarEstado("Disponible");
                listaAnimales.Add(a1);

                var a2 = new Animal(contadorAnimales++, "Michi", "Gato");
                listaAnimales.Add(a2);

                var ad1 = new Adoptante(contadorAdoptantes++, "Carlos Pérez", "3001234567");
                listaAdoptantes.Add(ad1);

                RefrescarGridAnimales();
                RefrescarGridAdoptantes();
                RefrescarGridAdopciones();
                RefrescarGridRegistros();
                RefrescarCombosAdopcion();
                RefrescarCombosRegistro();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos iniciales: " + ex.Message,
                    "PetCare Manager", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ════════════════════════════════════════════════════════════════════
        //  TAB 1 — ANIMALES
        // ════════════════════════════════════════════════════════════════════

        private void btnRegistrarAnimal_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombreAnimal.Text) ||
                    string.IsNullOrWhiteSpace(txtEspecieAnimal.Text))
                {
                    MessageBox.Show("Por favor completa Nombre y Especie del animal.",
                        "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var animal = new Animal(contadorAnimales++, txtNombreAnimal.Text.Trim(), txtEspecieAnimal.Text.Trim());
                listaAnimales.Add(animal);

                RefrescarGridAnimales();
                RefrescarCombosAdopcion();
                RefrescarCombosRegistro();

                txtNombreAnimal.Clear();
                txtEspecieAnimal.Clear();

                MessageBox.Show($"Animal \"{animal.Nombre}\" registrado exitosamente. ID asignado: {animal.Id}",
                    "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Dato inválido: " + ex.Message,
                    "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizarEstado_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAnimales.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Selecciona un animal de la lista para actualizar su estado.",
                        "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbEstadoAnimal.SelectedItem == null)
                {
                    MessageBox.Show("Selecciona un estado válido.",
                        "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = (int)dgvAnimales.SelectedRows[0].Cells["colAnimalId"].Value;
                var animal = listaAnimales.Find(a => a.Id == id);

                if (animal == null)
                {
                    MessageBox.Show("Animal no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string nuevoEstado = cmbEstadoAnimal.SelectedItem.ToString();
                animal.ActualizarEstado(nuevoEstado);
                RefrescarGridAnimales();

                MessageBox.Show($"Estado de \"{animal.Nombre}\" actualizado a: {nuevoEstado}",
                    "Actualización exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Error de validación: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefrescarGridAnimales()
        {
            dgvAnimales.Rows.Clear();
            foreach (var a in listaAnimales)
                dgvAnimales.Rows.Add(a.Id, a.Nombre, a.Especie, a.Estado, a.FechaIngreso.ToShortDateString());
        }

        // ════════════════════════════════════════════════════════════════════
        //  TAB 2 — ADOPTANTES
        // ════════════════════════════════════════════════════════════════════

        private void btnRegistrarAdoptante_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombreAdoptante.Text) ||
                    string.IsNullOrWhiteSpace(txtTelefonoAdoptante.Text))
                {
                    MessageBox.Show("Por favor completa Nombre y Teléfono del adoptante.",
                        "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string telefono = txtTelefonoAdoptante.Text.Trim();
                foreach (char c in telefono)
                {
                    if (!char.IsDigit(c))
                    {
                        MessageBox.Show("El teléfono solo puede contener números.",
                            "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtTelefonoAdoptante.Focus();
                        return;
                    }
                }

                if (telefono.Length != 10)
                {
                    MessageBox.Show("El teléfono debe tener exactamente 10 dígitos.",
                        "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTelefonoAdoptante.Focus();
                    return;
                }

                var adoptante = new Adoptante(contadorAdoptantes++, txtNombreAdoptante.Text.Trim(), telefono);
                listaAdoptantes.Add(adoptante);

                RefrescarGridAdoptantes();
                RefrescarCombosAdopcion();

                txtNombreAdoptante.Clear();
                txtTelefonoAdoptante.Clear();

                MessageBox.Show($"Adoptante \"{adoptante.Nombre}\" registrado exitosamente. ID asignado: {adoptante.Id}",
                    "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Dato inválido: " + ex.Message,
                    "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefrescarGridAdoptantes()
        {
            dgvAdoptantes.Rows.Clear();
            foreach (var ad in listaAdoptantes)
                dgvAdoptantes.Rows.Add(ad.Id, ad.Nombre, ad.Telefono);
        }

        // ════════════════════════════════════════════════════════════════════
        //  TAB 3 — ADOPCIONES
        // ════════════════════════════════════════════════════════════════════

        private void RefrescarCombosAdopcion()
        {
            cmbAnimalAdopcion.Items.Clear();
            foreach (var a in listaAnimales)
                if (a.EsAdoptable())
                    cmbAnimalAdopcion.Items.Add($"{a.Id} - {a.Nombre} ({a.Especie})");

            cmbAdoptanteAdopcion.Items.Clear();
            foreach (var ad in listaAdoptantes)
                cmbAdoptanteAdopcion.Items.Add($"{ad.Id} - {ad.Nombre}");
        }

        private void btnCrearAdopcion_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbAnimalAdopcion.SelectedIndex < 0 || cmbAdoptanteAdopcion.SelectedIndex < 0)
                {
                    MessageBox.Show("Selecciona un animal disponible y un adoptante.",
                        "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string itemAnimal = cmbAnimalAdopcion.SelectedItem.ToString();
                int idAnimal = int.Parse(itemAnimal.Split('-')[0].Trim());
                var animal = listaAnimales.Find(a => a.Id == idAnimal);

                string itemAdoptante = cmbAdoptanteAdopcion.SelectedItem.ToString();
                int idAdoptante = int.Parse(itemAdoptante.Split('-')[0].Trim());
                var adoptante = listaAdoptantes.Find(a => a.Id == idAdoptante);

                if (animal == null || adoptante == null)
                {
                    MessageBox.Show("No se encontró el animal o adoptante seleccionado.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var adopcion = new Adopcion(contadorAdopciones++, animal, adoptante);
                listaAdopciones.Add(adopcion);

                RefrescarGridAdopciones();
                RefrescarCombosAdopcion();
                cmbAnimalAdopcion.SelectedIndex = -1;
                cmbAdoptanteAdopcion.SelectedIndex = -1;

                MessageBox.Show($"Solicitud de adopción creada.\nAnimal: {animal.Nombre}\nAdoptante: {adoptante.Nombre}\nEstado: EN REVISIÓN",
                    "Adopción registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la adopción: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAprobarAdopcion_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAdopciones.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Selecciona una adopción de la lista.",
                        "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = (int)dgvAdopciones.SelectedRows[0].Cells["colAdopcionId"].Value;
                var adopcion = listaAdopciones.Find(a => a.Id == id);
                if (adopcion == null) return;

                if (adopcion.Estado != EstadoAdopcion.EN_REVISION)
                {
                    MessageBox.Show("Solo se pueden aprobar adopciones EN REVISIÓN.",
                        "Operación no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                adopcion.Aprobar();
                RefrescarGridAdopciones();
                RefrescarGridAnimales();

                MessageBox.Show($"Adopción aprobada. \"{adopcion.Animal.Nombre}\" tiene un nuevo hogar con {adopcion.Adoptante.Nombre}.",
                    "Adopción aprobada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al aprobar adopción: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRechazarAdopcion_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAdopciones.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Selecciona una adopción de la lista.",
                        "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = (int)dgvAdopciones.SelectedRows[0].Cells["colAdopcionId"].Value;
                var adopcion = listaAdopciones.Find(a => a.Id == id);
                if (adopcion == null) return;

                if (adopcion.Estado != EstadoAdopcion.EN_REVISION)
                {
                    MessageBox.Show("Solo se pueden rechazar adopciones EN REVISIÓN.",
                        "Operación no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirm = MessageBox.Show($"¿Confirmas rechazar la adopción de \"{adopcion.Animal.Nombre}\"?",
                    "Confirmar rechazo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    adopcion.Rechazar();
                    RefrescarGridAdopciones();
                    MessageBox.Show("Solicitud de adopción rechazada.",
                        "Operación completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al rechazar adopción: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefrescarGridAdopciones()
        {
            dgvAdopciones.Rows.Clear();
            foreach (var ad in listaAdopciones)
                dgvAdopciones.Rows.Add(ad.Id, ad.Animal.Nombre, ad.Adoptante.Nombre,
                    ad.Estado.ToString(), ad.FechaSolicitud.ToShortDateString());
        }

        // ════════════════════════════════════════════════════════════════════
        //  TAB 4 — REGISTROS MÉDICOS
        // ════════════════════════════════════════════════════════════════════

        private void RefrescarCombosRegistro()
        {
            cmbAnimalRegistro.Items.Clear();
            foreach (var a in listaAnimales)
                cmbAnimalRegistro.Items.Add($"{a.Id} - {a.Nombre}");
        }

        private void btnAgregarRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbAnimalRegistro.SelectedIndex < 0 ||
                    string.IsNullOrWhiteSpace(txtDiagnostico.Text) ||
                    string.IsNullOrWhiteSpace(txtTratamiento.Text))
                {
                    MessageBox.Show("Completa todos los campos: Animal, Diagnóstico y Tratamiento.",
                        "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string itemAnimal = cmbAnimalRegistro.SelectedItem.ToString();
                int idAnimal = int.Parse(itemAnimal.Split('-')[0].Trim());
                var animal = listaAnimales.Find(a => a.Id == idAnimal);

                if (animal == null)
                {
                    MessageBox.Show("Animal no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var registro = new RegistroMedico(contadorRegistros++, animal,
                    txtDiagnostico.Text.Trim(), txtTratamiento.Text.Trim());
                listaRegistrosMedicos.Add(registro);

                RefrescarGridRegistros();
                cmbAnimalRegistro.SelectedIndex = -1;
                txtDiagnostico.Clear();
                txtTratamiento.Clear();

                MessageBox.Show($"Registro médico agregado para \"{animal.Nombre}\".",
                    "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar registro médico: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefrescarGridRegistros()
        {
            dgvRegistros.Rows.Clear();
            foreach (var r in listaRegistrosMedicos)
                dgvRegistros.Rows.Add(r.Id, r.Animal.Nombre, r.Diagnostico,
                    r.Tratamiento, r.Fecha.ToShortDateString());
        }

        // ── Eventos requeridos por el diseñador original ─────────────────────
        private void txtNombre_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void txtIdAdoptante_TextChanged(object sender, EventArgs e) { }
    }
}
