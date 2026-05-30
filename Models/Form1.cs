using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PetCareInterface.Repositories;

namespace PetCareInterface
{
    /// <summary>
    /// Ventana principal. Orquesta el CRUD de las cuatro entidades a través de
    /// los repositorios inyectados. No conoce SQL: solo llama a los contratos
    /// <see cref="IRepository{T}"/> (Inversión de Dependencias - SOLID).
    /// </summary>
    public partial class Form1 : Form
    {
        private readonly IRepository<Animal> _animales;
        private readonly IRepository<Adoptante> _adoptantes;
        private readonly IRepository<Adopcion> _adopciones;
        private readonly IRepository<RegistroMedico> _registros;

        // Evita que los eventos de selección se disparen mientras recargamos datos.
        private bool _cargando;

        public Form1(
            IRepository<Animal> animales,
            IRepository<Adoptante> adoptantes,
            IRepository<Adopcion> adopciones,
            IRepository<RegistroMedico> registros)
        {
            _animales = animales;
            _adoptantes = adoptantes;
            _adopciones = adopciones;
            _registros = registros;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefrescarTodo();
        }

        /// <summary>Recarga todas las tablas y combos desde la base de datos.</summary>
        private void RefrescarTodo()
        {
            _cargando = true;
            try
            {
                CargarAnimales();
                CargarAdoptantes();
                CargarAdopciones();
                CargarRegistros();
                CargarCombos();
            }
            catch (Exception ex)
            {
                MostrarError("Error al cargar los datos:\n" + ex.Message);
            }
            finally
            {
                _cargando = false;
            }
        }

        // ============================================================
        //  ANIMALES
        // ============================================================

        private void CargarAnimales()
        {
            dgvAnimales.DataSource = _animales.ObtenerTodos().ToList();
        }

        private void btnGuardarAnimal_Click(object sender, EventArgs e)
        {
            try
            {
                if (!TryLeerEntero(txtIdAnimal, "el ID del animal", out int id)) return;

                if (cboEstadoAnimal.SelectedItem == null)
                {
                    MostrarAdvertencia("Selecciona el estado del animal.");
                    return;
                }

                // La validación de nombre/especie ocurre dentro de la entidad Animal.
                var animal = new Animal(
                    id,
                    txtNombreAnimal.Text.Trim(),
                    txtEspecieAnimal.Text.Trim(),
                    cboEstadoAnimal.SelectedItem.ToString(),
                    DateTime.Now);

                bool existe = _animales.ObtenerPorId(id) != null;
                if (existe)
                {
                    _animales.Actualizar(animal);
                    MostrarInfo("Animal actualizado correctamente.");
                }
                else
                {
                    _animales.Agregar(animal);
                    MostrarInfo("Animal registrado correctamente.");
                }

                RefrescarTodo();
                LimpiarAnimal();
            }
            catch (ArgumentException ex)        // Validación de la capa lógica (entidad)
            {
                MostrarAdvertencia(ex.Message);
            }
            catch (DataAccessException ex)       // Error de la capa de datos
            {
                MostrarError(ex.Message);
            }
        }

        private void btnEliminarAnimal_Click(object sender, EventArgs e)
        {
            try
            {
                if (!TryLeerEntero(txtIdAnimal, "el ID del animal", out int id)) return;
                if (!ConfirmarEliminacion("este animal")) return;

                _animales.Eliminar(id);
                MostrarInfo("Animal eliminado.");
                RefrescarTodo();
                LimpiarAnimal();
            }
            catch (DataAccessException ex)
            {
                MostrarError(ex.Message);
            }
        }

        private void btnLimpiarAnimal_Click(object sender, EventArgs e) => LimpiarAnimal();

        private void LimpiarAnimal()
        {
            txtIdAnimal.Clear();
            txtNombreAnimal.Clear();
            txtEspecieAnimal.Clear();
            cboEstadoAnimal.SelectedIndex = -1;
        }

        private void dgvAnimales_SelectionChanged(object sender, EventArgs e)
        {
            if (_cargando) return;
            if (dgvAnimales.CurrentRow?.DataBoundItem is Animal animal)
            {
                txtIdAnimal.Text = animal.Id.ToString();
                txtNombreAnimal.Text = animal.Nombre;
                txtEspecieAnimal.Text = animal.Especie;
                cboEstadoAnimal.SelectedItem = animal.Estado;
            }
        }

        // ============================================================
        //  ADOPTANTES
        // ============================================================

        private void CargarAdoptantes()
        {
            dgvAdoptantes.DataSource = _adoptantes.ObtenerTodos().ToList();
        }

        private void btnGuardarAdoptante_Click(object sender, EventArgs e)
        {
            try
            {
                if (!TryLeerEntero(txtIdAdoptante, "la cédula", out int id)) return;

                var adoptante = new Adoptante(
                    id,
                    txtNombreAdoptante.Text.Trim(),
                    txtTelefonoAdoptante.Text.Trim());

                bool existe = _adoptantes.ObtenerPorId(id) != null;
                if (existe)
                {
                    _adoptantes.Actualizar(adoptante);
                    MostrarInfo("Adoptante actualizado correctamente.");
                }
                else
                {
                    _adoptantes.Agregar(adoptante);
                    MostrarInfo("Adoptante registrado correctamente.");
                }

                RefrescarTodo();
                LimpiarAdoptante();
            }
            catch (ArgumentException ex)
            {
                MostrarAdvertencia(ex.Message);
            }
            catch (DataAccessException ex)
            {
                MostrarError(ex.Message);
            }
        }

        private void btnEliminarAdoptante_Click(object sender, EventArgs e)
        {
            try
            {
                if (!TryLeerEntero(txtIdAdoptante, "la cédula", out int id)) return;
                if (!ConfirmarEliminacion("este adoptante")) return;

                _adoptantes.Eliminar(id);
                MostrarInfo("Adoptante eliminado.");
                RefrescarTodo();
                LimpiarAdoptante();
            }
            catch (DataAccessException ex)
            {
                MostrarError(ex.Message);
            }
        }

        private void btnLimpiarAdoptante_Click(object sender, EventArgs e) => LimpiarAdoptante();

        private void LimpiarAdoptante()
        {
            txtIdAdoptante.Clear();
            txtNombreAdoptante.Clear();
            txtTelefonoAdoptante.Clear();
        }

        private void dgvAdoptantes_SelectionChanged(object sender, EventArgs e)
        {
            if (_cargando) return;
            if (dgvAdoptantes.CurrentRow?.DataBoundItem is Adoptante adoptante)
            {
                txtIdAdoptante.Text = adoptante.Id.ToString();
                txtNombreAdoptante.Text = adoptante.Nombre;
                txtTelefonoAdoptante.Text = adoptante.Telefono;
            }
        }

        // ============================================================
        //  ADOPCIONES
        // ============================================================

        private void CargarAdopciones()
        {
            var datos = _adopciones.ObtenerTodos()
                .Select(a => new
                {
                    a.Id,
                    Animal = a.Animal.Nombre,
                    Adoptante = a.Adoptante.Nombre,
                    Fecha = a.FechaSolicitud.ToString("yyyy-MM-dd"),
                    Estado = a.Estado.ToString()
                })
                .ToList();
            dgvAdopciones.DataSource = datos;
        }

        private void btnGuardarAdopcion_Click(object sender, EventArgs e)
        {
            try
            {
                if (!TryLeerEntero(txtIdAdopcion, "el ID de la adopción", out int id)) return;

                if (cboAnimalAdopcion.SelectedItem is not Animal animal ||
                    cboAdoptanteAdopcion.SelectedItem is not Adoptante adoptante)
                {
                    MostrarAdvertencia("Selecciona el animal y el adoptante.");
                    return;
                }

                if (_adopciones.ObtenerPorId(id) != null)
                {
                    MostrarAdvertencia($"Ya existe una adopción con el ID {id}.");
                    return;
                }

                var adopcion = new Adopcion(id, animal, adoptante); // queda EN_REVISION
                _adopciones.Agregar(adopcion);
                MostrarInfo("Solicitud de adopción registrada (En revisión).");

                RefrescarTodo();
                LimpiarAdopcion();
            }
            catch (DataAccessException ex)
            {
                MostrarError(ex.Message);
            }
        }

        private void btnAprobarAdopcion_Click(object sender, EventArgs e)
        {
            CambiarEstadoAdopcion(aprobar: true);
        }

        private void btnRechazarAdopcion_Click(object sender, EventArgs e)
        {
            CambiarEstadoAdopcion(aprobar: false);
        }

        /// <summary>
        /// Aprueba o rechaza la adopción indicada en el ID. Al aprobar, el animal
        /// pasa a estado "Adoptado" y ese cambio también se persiste.
        /// </summary>
        private void CambiarEstadoAdopcion(bool aprobar)
        {
            try
            {
                if (!TryLeerEntero(txtIdAdopcion, "el ID de la adopción", out int id)) return;

                Adopcion? adopcion = _adopciones.ObtenerPorId(id);
                if (adopcion == null)
                {
                    MostrarAdvertencia($"No existe una adopción con el ID {id}.");
                    return;
                }

                if (aprobar)
                {
                    adopcion.Aprobar();                  // regla de negocio en la entidad
                    _adopciones.Actualizar(adopcion);
                    _animales.Actualizar(adopcion.Animal); // persiste el nuevo estado del animal
                    MostrarInfo("Adopción aprobada. El animal quedó como 'Adoptado'.");
                }
                else
                {
                    adopcion.Rechazar();
                    _adopciones.Actualizar(adopcion);
                    MostrarInfo("Adopción rechazada.");
                }

                RefrescarTodo();
                LimpiarAdopcion();
            }
            catch (DataAccessException ex)
            {
                MostrarError(ex.Message);
            }
        }

        private void btnEliminarAdopcion_Click(object sender, EventArgs e)
        {
            try
            {
                if (!TryLeerEntero(txtIdAdopcion, "el ID de la adopción", out int id)) return;
                if (!ConfirmarEliminacion("esta adopción")) return;

                _adopciones.Eliminar(id);
                MostrarInfo("Adopción eliminada.");
                RefrescarTodo();
                LimpiarAdopcion();
            }
            catch (DataAccessException ex)
            {
                MostrarError(ex.Message);
            }
        }

        private void btnLimpiarAdopcion_Click(object sender, EventArgs e) => LimpiarAdopcion();

        private void LimpiarAdopcion()
        {
            txtIdAdopcion.Clear();
            cboAnimalAdopcion.SelectedIndex = -1;
            cboAdoptanteAdopcion.SelectedIndex = -1;
            lblEstadoAdopcionValor.Text = "-";
        }

        private void dgvAdopciones_SelectionChanged(object sender, EventArgs e)
        {
            if (_cargando) return;
            if (dgvAdopciones.CurrentRow == null) return;

            object? valorId = dgvAdopciones.CurrentRow.Cells["Id"].Value;
            if (valorId == null) return;

            Adopcion? adopcion = _adopciones.ObtenerPorId(Convert.ToInt32(valorId));
            if (adopcion == null) return;

            txtIdAdopcion.Text = adopcion.Id.ToString();
            SeleccionarEnCombo(cboAnimalAdopcion, adopcion.Animal.Id);
            SeleccionarEnCombo(cboAdoptanteAdopcion, adopcion.Adoptante.Id);
            lblEstadoAdopcionValor.Text = adopcion.Estado.ToString();
        }

        // ============================================================
        //  REGISTROS MÉDICOS
        // ============================================================

        private void CargarRegistros()
        {
            var datos = _registros.ObtenerTodos()
                .Select(r => new
                {
                    r.Id,
                    Animal = r.Animal.Nombre,
                    r.Diagnostico,
                    r.Tratamiento,
                    Fecha = r.Fecha.ToString("yyyy-MM-dd")
                })
                .ToList();
            dgvRegistros.DataSource = datos;
        }

        private void btnGuardarRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                if (!TryLeerEntero(txtIdRegistro, "el ID del registro", out int id)) return;

                if (cboAnimalRegistro.SelectedItem is not Animal animal)
                {
                    MostrarAdvertencia("Selecciona el animal del registro médico.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtDiagnostico.Text) ||
                    string.IsNullOrWhiteSpace(txtTratamiento.Text))
                {
                    MostrarAdvertencia("Completa el diagnóstico y el tratamiento.");
                    return;
                }

                var registro = new RegistroMedico(
                    id,
                    animal,
                    txtDiagnostico.Text.Trim(),
                    txtTratamiento.Text.Trim());

                bool existe = _registros.ObtenerPorId(id) != null;
                if (existe)
                {
                    _registros.Actualizar(registro);
                    MostrarInfo("Registro médico actualizado.");
                }
                else
                {
                    _registros.Agregar(registro);
                    MostrarInfo("Registro médico guardado.");
                }

                RefrescarTodo();
                LimpiarRegistro();
            }
            catch (DataAccessException ex)
            {
                MostrarError(ex.Message);
            }
        }

        private void btnEliminarRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                if (!TryLeerEntero(txtIdRegistro, "el ID del registro", out int id)) return;
                if (!ConfirmarEliminacion("este registro médico")) return;

                _registros.Eliminar(id);
                MostrarInfo("Registro médico eliminado.");
                RefrescarTodo();
                LimpiarRegistro();
            }
            catch (DataAccessException ex)
            {
                MostrarError(ex.Message);
            }
        }

        private void btnLimpiarRegistro_Click(object sender, EventArgs e) => LimpiarRegistro();

        private void LimpiarRegistro()
        {
            txtIdRegistro.Clear();
            cboAnimalRegistro.SelectedIndex = -1;
            txtDiagnostico.Clear();
            txtTratamiento.Clear();
        }

        private void dgvRegistros_SelectionChanged(object sender, EventArgs e)
        {
            if (_cargando) return;
            if (dgvRegistros.CurrentRow == null) return;

            object? valorId = dgvRegistros.CurrentRow.Cells["Id"].Value;
            if (valorId == null) return;

            RegistroMedico? registro = _registros.ObtenerPorId(Convert.ToInt32(valorId));
            if (registro == null) return;

            txtIdRegistro.Text = registro.Id.ToString();
            SeleccionarEnCombo(cboAnimalRegistro, registro.Animal.Id);
            txtDiagnostico.Text = registro.Diagnostico;
            txtTratamiento.Text = registro.Tratamiento;
        }

        // ============================================================
        //  COMBOS Y UTILIDADES
        // ============================================================

        /// <summary>Llena los combos de animales y adoptantes desde la BD.</summary>
        private void CargarCombos()
        {
            List<Animal> animales = _animales.ObtenerTodos().ToList();
            List<Adoptante> adoptantes = _adoptantes.ObtenerTodos().ToList();

            // Cada combo necesita su propia instancia de lista para no compartir selección.
            ConfigurarCombo(cboAnimalAdopcion, new List<Animal>(animales), "Nombre", "Id");
            ConfigurarCombo(cboAnimalRegistro, new List<Animal>(animales), "Nombre", "Id");
            ConfigurarCombo(cboAdoptanteAdopcion, new List<Adoptante>(adoptantes), "Nombre", "Id");
        }

        private static void ConfigurarCombo(ComboBox combo, object fuente, string display, string value)
        {
            combo.DataSource = fuente;
            combo.DisplayMember = display;
            combo.ValueMember = value;
            combo.SelectedIndex = -1;
        }

        private static void SeleccionarEnCombo(ComboBox combo, int id)
        {
            combo.SelectedValue = id;
        }

        /// <summary>
        /// Validación desde la GUI: intenta leer un entero del cuadro de texto.
        /// </summary>
        private bool TryLeerEntero(TextBox caja, string campo, out int valor)
        {
            if (!int.TryParse(caja.Text.Trim(), out valor))
            {
                MostrarAdvertencia($"Escribe un número válido en {campo}.");
                caja.Focus();
                return false;
            }
            return true;
        }

        private bool ConfirmarEliminacion(string descripcion)
        {
            return MessageBox.Show(
                $"¿Seguro que deseas eliminar {descripcion}? Esta acción no se puede deshacer.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes;
        }

        private void MostrarInfo(string mensaje) =>
            MessageBox.Show(mensaje, "PetCare Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private void MostrarAdvertencia(string mensaje) =>
            MessageBox.Show(mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private void MostrarError(string mensaje) =>
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
