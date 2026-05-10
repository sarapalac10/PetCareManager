namespace PetCareInterface
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();

            // ── TAB ANIMALES ─────────────────────────────────────────────────
            this.tabAnimales = new System.Windows.Forms.TabPage();
            this.grpRegistroAnimal = new System.Windows.Forms.GroupBox();
            this.lblNombreAnimal = new System.Windows.Forms.Label();
            this.txtNombreAnimal = new System.Windows.Forms.TextBox();
            this.lblEspecieAnimal = new System.Windows.Forms.Label();
            this.txtEspecieAnimal = new System.Windows.Forms.TextBox();
            this.btnRegistrarAnimal = new System.Windows.Forms.Button();
            this.grpEstadoAnimal = new System.Windows.Forms.GroupBox();
            this.lblEstadoAnimal = new System.Windows.Forms.Label();
            this.cmbEstadoAnimal = new System.Windows.Forms.ComboBox();
            this.btnActualizarEstado = new System.Windows.Forms.Button();
            this.dgvAnimales = new System.Windows.Forms.DataGridView();
            this.colAnimalId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAnimalNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAnimalEspecie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAnimalEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAnimalFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();

            // ── TAB ADOPTANTES ───────────────────────────────────────────────
            this.tabAdoptantes = new System.Windows.Forms.TabPage();
            this.grpRegistroAdoptante = new System.Windows.Forms.GroupBox();
            this.lblNombreAdoptante = new System.Windows.Forms.Label();
            this.txtNombreAdoptante = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefonoAdoptante = new System.Windows.Forms.TextBox();
            this.btnRegistrarAdoptante = new System.Windows.Forms.Button();
            this.dgvAdoptantes = new System.Windows.Forms.DataGridView();
            this.colAdoptanteId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdoptanteNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdoptanteTel = new System.Windows.Forms.DataGridViewTextBoxColumn();

            // ── TAB ADOPCIONES ───────────────────────────────────────────────
            this.tabAdopciones = new System.Windows.Forms.TabPage();
            this.grpNuevaAdopcion = new System.Windows.Forms.GroupBox();
            this.lblAnimalAdopcion = new System.Windows.Forms.Label();
            this.cmbAnimalAdopcion = new System.Windows.Forms.ComboBox();
            this.lblAdoptanteAdopcion = new System.Windows.Forms.Label();
            this.cmbAdoptanteAdopcion = new System.Windows.Forms.ComboBox();
            this.btnCrearAdopcion = new System.Windows.Forms.Button();
            this.btnAprobarAdopcion = new System.Windows.Forms.Button();
            this.btnRechazarAdopcion = new System.Windows.Forms.Button();
            this.dgvAdopciones = new System.Windows.Forms.DataGridView();
            this.colAdopcionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdopcionAnimal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdopcionAdoptante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdopcionEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdopcionFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();

            // ── TAB REGISTROS MÉDICOS ────────────────────────────────────────
            this.tabRegistros = new System.Windows.Forms.TabPage();
            this.grpNuevoRegistro = new System.Windows.Forms.GroupBox();
            this.lblAnimalRegistro = new System.Windows.Forms.Label();
            this.cmbAnimalRegistro = new System.Windows.Forms.ComboBox();
            this.lblDiagnostico = new System.Windows.Forms.Label();
            this.txtDiagnostico = new System.Windows.Forms.TextBox();
            this.lblTratamiento = new System.Windows.Forms.Label();
            this.txtTratamiento = new System.Windows.Forms.TextBox();
            this.btnAgregarRegistro = new System.Windows.Forms.Button();
            this.dgvRegistros = new System.Windows.Forms.DataGridView();
            this.colRegId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRegAnimal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRegDiag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRegTrat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRegFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.SuspendLayout();

            // ================================================================
            //  FORM PRINCIPAL
            // ================================================================
            this.Text = "🐾  PetCare Manager";
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);

            // ── TabControl ──────────────────────────────────────────────────
            this.tabControl1.Location = new System.Drawing.Point(10, 10);
            this.tabControl1.Size = new System.Drawing.Size(875, 570);
            this.tabControl1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
                                    | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.tabControl1.Controls.Add(this.tabAnimales);
            this.tabControl1.Controls.Add(this.tabAdoptantes);
            this.tabControl1.Controls.Add(this.tabAdopciones);
            this.tabControl1.Controls.Add(this.tabRegistros);

            // ================================================================
            //  TAB 1 — ANIMALES
            // ================================================================
            this.tabAnimales.Text = "🐶  Animales";
            this.tabAnimales.Padding = new System.Windows.Forms.Padding(5);

            // GroupBox registro
            this.grpRegistroAnimal.Text = "Nuevo Animal";
            this.grpRegistroAnimal.Location = new System.Drawing.Point(10, 10);
            this.grpRegistroAnimal.Size = new System.Drawing.Size(380, 110);

            this.lblNombreAnimal.Text = "Nombre:";
            this.lblNombreAnimal.Location = new System.Drawing.Point(10, 28);
            this.lblNombreAnimal.AutoSize = true;
            this.txtNombreAnimal.Location = new System.Drawing.Point(80, 25);
            this.txtNombreAnimal.Size = new System.Drawing.Size(200, 23);

            this.lblEspecieAnimal.Text = "Especie:";
            this.lblEspecieAnimal.Location = new System.Drawing.Point(10, 62);
            this.lblEspecieAnimal.AutoSize = true;
            this.txtEspecieAnimal.Location = new System.Drawing.Point(80, 59);
            this.txtEspecieAnimal.Size = new System.Drawing.Size(200, 23);

            this.btnRegistrarAnimal.Text = "Registrar Animal";
            this.btnRegistrarAnimal.Location = new System.Drawing.Point(290, 38);
            this.btnRegistrarAnimal.Size = new System.Drawing.Size(75, 45);
            this.btnRegistrarAnimal.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnRegistrarAnimal.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarAnimal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarAnimal.Click += new System.EventHandler(this.btnRegistrarAnimal_Click);

            this.grpRegistroAnimal.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblNombreAnimal, this.txtNombreAnimal,
                this.lblEspecieAnimal, this.txtEspecieAnimal,
                this.btnRegistrarAnimal });

            // GroupBox estado
            this.grpEstadoAnimal.Text = "Actualizar Estado (selecciona fila)";
            this.grpEstadoAnimal.Location = new System.Drawing.Point(400, 10);
            this.grpEstadoAnimal.Size = new System.Drawing.Size(450, 110);

            this.lblEstadoAnimal.Text = "Nuevo estado:";
            this.lblEstadoAnimal.Location = new System.Drawing.Point(10, 35);
            this.lblEstadoAnimal.AutoSize = true;
            this.cmbEstadoAnimal.Location = new System.Drawing.Point(110, 32);
            this.cmbEstadoAnimal.Size = new System.Drawing.Size(200, 23);
            this.cmbEstadoAnimal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstadoAnimal.Items.AddRange(new object[] { "En observación", "Disponible", "En tratamiento", "Adoptado" });

            this.btnActualizarEstado.Text = "Actualizar";
            this.btnActualizarEstado.Location = new System.Drawing.Point(325, 28);
            this.btnActualizarEstado.Size = new System.Drawing.Size(100, 35);
            this.btnActualizarEstado.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.btnActualizarEstado.ForeColor = System.Drawing.Color.White;
            this.btnActualizarEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarEstado.Click += new System.EventHandler(this.btnActualizarEstado_Click);

            this.grpEstadoAnimal.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblEstadoAnimal, this.cmbEstadoAnimal, this.btnActualizarEstado });

            // DataGridView animales
            this.dgvAnimales.Location = new System.Drawing.Point(10, 130);
            this.dgvAnimales.Size = new System.Drawing.Size(840, 380);
            this.dgvAnimales.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
                                    | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvAnimales.ReadOnly = true;
            this.dgvAnimales.AllowUserToAddRows = false;
            this.dgvAnimales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAnimales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.colAnimalId.Name = "colAnimalId"; this.colAnimalId.HeaderText = "ID"; this.colAnimalId.FillWeight = 8;
            this.colAnimalNombre.Name = "colAnimalNombre"; this.colAnimalNombre.HeaderText = "Nombre"; this.colAnimalNombre.FillWeight = 25;
            this.colAnimalEspecie.Name = "colAnimalEspecie"; this.colAnimalEspecie.HeaderText = "Especie"; this.colAnimalEspecie.FillWeight = 25;
            this.colAnimalEstado.Name = "colAnimalEstado"; this.colAnimalEstado.HeaderText = "Estado"; this.colAnimalEstado.FillWeight = 25;
            this.colAnimalFecha.Name = "colAnimalFecha"; this.colAnimalFecha.HeaderText = "Fecha Ingreso"; this.colAnimalFecha.FillWeight = 17;
            this.dgvAnimales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colAnimalId, this.colAnimalNombre, this.colAnimalEspecie, this.colAnimalEstado, this.colAnimalFecha });

            this.tabAnimales.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.grpRegistroAnimal, this.grpEstadoAnimal, this.dgvAnimales });

            // ================================================================
            //  TAB 2 — ADOPTANTES
            // ================================================================
            this.tabAdoptantes.Text = "👤  Adoptantes";

            this.grpRegistroAdoptante.Text = "Nuevo Adoptante";
            this.grpRegistroAdoptante.Location = new System.Drawing.Point(10, 10);
            this.grpRegistroAdoptante.Size = new System.Drawing.Size(450, 110);

            this.lblNombreAdoptante.Text = "Nombre:";
            this.lblNombreAdoptante.Location = new System.Drawing.Point(10, 30);
            this.lblNombreAdoptante.AutoSize = true;
            this.txtNombreAdoptante.Location = new System.Drawing.Point(80, 27);
            this.txtNombreAdoptante.Size = new System.Drawing.Size(240, 23);

            this.lblTelefono.Text = "Teléfono:";
            this.lblTelefono.Location = new System.Drawing.Point(10, 65);
            this.lblTelefono.AutoSize = true;
            this.txtTelefonoAdoptante.Location = new System.Drawing.Point(80, 62);
            this.txtTelefonoAdoptante.Size = new System.Drawing.Size(240, 23);
            this.txtTelefonoAdoptante.MaxLength = 10;

            this.btnRegistrarAdoptante.Text = "Registrar";
            this.btnRegistrarAdoptante.Location = new System.Drawing.Point(335, 35);
            this.btnRegistrarAdoptante.Size = new System.Drawing.Size(95, 45);
            this.btnRegistrarAdoptante.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnRegistrarAdoptante.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarAdoptante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarAdoptante.Click += new System.EventHandler(this.btnRegistrarAdoptante_Click);

            this.grpRegistroAdoptante.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblNombreAdoptante, this.txtNombreAdoptante,
                this.lblTelefono, this.txtTelefonoAdoptante,
                this.btnRegistrarAdoptante });

            this.dgvAdoptantes.Location = new System.Drawing.Point(10, 130);
            this.dgvAdoptantes.Size = new System.Drawing.Size(840, 380);
            this.dgvAdoptantes.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
                                      | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvAdoptantes.ReadOnly = true;
            this.dgvAdoptantes.AllowUserToAddRows = false;
            this.dgvAdoptantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAdoptantes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.colAdoptanteId.Name = "colAdoptanteId"; this.colAdoptanteId.HeaderText = "ID"; this.colAdoptanteId.FillWeight = 10;
            this.colAdoptanteNombre.Name = "colAdoptanteNombre"; this.colAdoptanteNombre.HeaderText = "Nombre Completo"; this.colAdoptanteNombre.FillWeight = 55;
            this.colAdoptanteTel.Name = "colAdoptanteTel"; this.colAdoptanteTel.HeaderText = "Teléfono"; this.colAdoptanteTel.FillWeight = 35;
            this.dgvAdoptantes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colAdoptanteId, this.colAdoptanteNombre, this.colAdoptanteTel });

            this.tabAdoptantes.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.grpRegistroAdoptante, this.dgvAdoptantes });

            // ================================================================
            //  TAB 3 — ADOPCIONES
            // ================================================================
            this.tabAdopciones.Text = "🏠  Adopciones";

            this.grpNuevaAdopcion.Text = "Nueva Solicitud de Adopción";
            this.grpNuevaAdopcion.Location = new System.Drawing.Point(10, 10);
            this.grpNuevaAdopcion.Size = new System.Drawing.Size(840, 110);

            this.lblAnimalAdopcion.Text = "Animal disponible:";
            this.lblAnimalAdopcion.Location = new System.Drawing.Point(10, 32);
            this.lblAnimalAdopcion.AutoSize = true;
            this.cmbAnimalAdopcion.Location = new System.Drawing.Point(130, 29);
            this.cmbAnimalAdopcion.Size = new System.Drawing.Size(230, 23);
            this.cmbAnimalAdopcion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblAdoptanteAdopcion.Text = "Adoptante:";
            this.lblAdoptanteAdopcion.Location = new System.Drawing.Point(380, 32);
            this.lblAdoptanteAdopcion.AutoSize = true;
            this.cmbAdoptanteAdopcion.Location = new System.Drawing.Point(450, 29);
            this.cmbAdoptanteAdopcion.Size = new System.Drawing.Size(220, 23);
            this.cmbAdoptanteAdopcion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.btnCrearAdopcion.Text = "Crear Solicitud";
            this.btnCrearAdopcion.Location = new System.Drawing.Point(685, 25);
            this.btnCrearAdopcion.Size = new System.Drawing.Size(120, 35);
            this.btnCrearAdopcion.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnCrearAdopcion.ForeColor = System.Drawing.Color.White;
            this.btnCrearAdopcion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearAdopcion.Click += new System.EventHandler(this.btnCrearAdopcion_Click);

            this.btnAprobarAdopcion.Text = "✔ Aprobar";
            this.btnAprobarAdopcion.Location = new System.Drawing.Point(130, 65);
            this.btnAprobarAdopcion.Size = new System.Drawing.Size(110, 35);
            this.btnAprobarAdopcion.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.btnAprobarAdopcion.ForeColor = System.Drawing.Color.White;
            this.btnAprobarAdopcion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAprobarAdopcion.Click += new System.EventHandler(this.btnAprobarAdopcion_Click);

            this.btnRechazarAdopcion.Text = "✘ Rechazar";
            this.btnRechazarAdopcion.Location = new System.Drawing.Point(255, 65);
            this.btnRechazarAdopcion.Size = new System.Drawing.Size(110, 35);
            this.btnRechazarAdopcion.BackColor = System.Drawing.Color.FromArgb(244, 67, 54);
            this.btnRechazarAdopcion.ForeColor = System.Drawing.Color.White;
            this.btnRechazarAdopcion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRechazarAdopcion.Click += new System.EventHandler(this.btnRechazarAdopcion_Click);

            this.grpNuevaAdopcion.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblAnimalAdopcion, this.cmbAnimalAdopcion,
                this.lblAdoptanteAdopcion, this.cmbAdoptanteAdopcion,
                this.btnCrearAdopcion, this.btnAprobarAdopcion, this.btnRechazarAdopcion });

            this.dgvAdopciones.Location = new System.Drawing.Point(10, 130);
            this.dgvAdopciones.Size = new System.Drawing.Size(840, 380);
            this.dgvAdopciones.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
                                      | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvAdopciones.ReadOnly = true;
            this.dgvAdopciones.AllowUserToAddRows = false;
            this.dgvAdopciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAdopciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.colAdopcionId.Name = "colAdopcionId"; this.colAdopcionId.HeaderText = "ID"; this.colAdopcionId.FillWeight = 8;
            this.colAdopcionAnimal.Name = "colAdopcionAnimal"; this.colAdopcionAnimal.HeaderText = "Animal"; this.colAdopcionAnimal.FillWeight = 25;
            this.colAdopcionAdoptante.Name = "colAdopcionAdoptante"; this.colAdopcionAdoptante.HeaderText = "Adoptante"; this.colAdopcionAdoptante.FillWeight = 30;
            this.colAdopcionEstado.Name = "colAdopcionEstado"; this.colAdopcionEstado.HeaderText = "Estado"; this.colAdopcionEstado.FillWeight = 20;
            this.colAdopcionFecha.Name = "colAdopcionFecha"; this.colAdopcionFecha.HeaderText = "Fecha Solicitud"; this.colAdopcionFecha.FillWeight = 17;
            this.dgvAdopciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colAdopcionId, this.colAdopcionAnimal, this.colAdopcionAdoptante,
                this.colAdopcionEstado, this.colAdopcionFecha });

            this.tabAdopciones.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.grpNuevaAdopcion, this.dgvAdopciones });

            // ================================================================
            //  TAB 4 — REGISTROS MÉDICOS
            // ================================================================
            this.tabRegistros.Text = "🩺  Historial Médico";

            this.grpNuevoRegistro.Text = "Nuevo Registro Médico";
            this.grpNuevoRegistro.Location = new System.Drawing.Point(10, 10);
            this.grpNuevoRegistro.Size = new System.Drawing.Size(840, 110);

            this.lblAnimalRegistro.Text = "Animal:";
            this.lblAnimalRegistro.Location = new System.Drawing.Point(10, 32);
            this.lblAnimalRegistro.AutoSize = true;
            this.cmbAnimalRegistro.Location = new System.Drawing.Point(70, 29);
            this.cmbAnimalRegistro.Size = new System.Drawing.Size(200, 23);
            this.cmbAnimalRegistro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblDiagnostico.Text = "Diagnóstico:";
            this.lblDiagnostico.Location = new System.Drawing.Point(285, 32);
            this.lblDiagnostico.AutoSize = true;
            this.txtDiagnostico.Location = new System.Drawing.Point(375, 29);
            this.txtDiagnostico.Size = new System.Drawing.Size(190, 23);

            this.lblTratamiento.Text = "Tratamiento:";
            this.lblTratamiento.Location = new System.Drawing.Point(285, 65);
            this.lblTratamiento.AutoSize = true;
            this.txtTratamiento.Location = new System.Drawing.Point(375, 62);
            this.txtTratamiento.Size = new System.Drawing.Size(190, 23);

            this.btnAgregarRegistro.Text = "Guardar Registro";
            this.btnAgregarRegistro.Location = new System.Drawing.Point(580, 35);
            this.btnAgregarRegistro.Size = new System.Drawing.Size(130, 45);
            this.btnAgregarRegistro.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnAgregarRegistro.ForeColor = System.Drawing.Color.White;
            this.btnAgregarRegistro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarRegistro.Click += new System.EventHandler(this.btnAgregarRegistro_Click);

            this.grpNuevoRegistro.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblAnimalRegistro, this.cmbAnimalRegistro,
                this.lblDiagnostico, this.txtDiagnostico,
                this.lblTratamiento, this.txtTratamiento,
                this.btnAgregarRegistro });

            this.dgvRegistros.Location = new System.Drawing.Point(10, 130);
            this.dgvRegistros.Size = new System.Drawing.Size(840, 380);
            this.dgvRegistros.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
                                     | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvRegistros.ReadOnly = true;
            this.dgvRegistros.AllowUserToAddRows = false;
            this.dgvRegistros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRegistros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.colRegId.Name = "colRegId"; this.colRegId.HeaderText = "ID"; this.colRegId.FillWeight = 8;
            this.colRegAnimal.Name = "colRegAnimal"; this.colRegAnimal.HeaderText = "Animal"; this.colRegAnimal.FillWeight = 20;
            this.colRegDiag.Name = "colRegDiag"; this.colRegDiag.HeaderText = "Diagnóstico"; this.colRegDiag.FillWeight = 30;
            this.colRegTrat.Name = "colRegTrat"; this.colRegTrat.HeaderText = "Tratamiento"; this.colRegTrat.FillWeight = 30;
            this.colRegFecha.Name = "colRegFecha"; this.colRegFecha.HeaderText = "Fecha"; this.colRegFecha.FillWeight = 12;
            this.dgvRegistros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colRegId, this.colRegAnimal, this.colRegDiag, this.colRegTrat, this.colRegFecha });

            this.tabRegistros.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.grpNuevoRegistro, this.dgvRegistros });

            // ── Ensamblar Form ───────────────────────────────────────────────
            this.Controls.Add(this.tabControl1);
            this.ResumeLayout(false);
        }

        #endregion

        // ── TAB ANIMALES ─────────────────────────────────────────────────────
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAnimales;
        private System.Windows.Forms.GroupBox grpRegistroAnimal;
        private System.Windows.Forms.Label lblNombreAnimal;
        private System.Windows.Forms.TextBox txtNombreAnimal;
        private System.Windows.Forms.Label lblEspecieAnimal;
        private System.Windows.Forms.TextBox txtEspecieAnimal;
        private System.Windows.Forms.Button btnRegistrarAnimal;
        private System.Windows.Forms.GroupBox grpEstadoAnimal;
        private System.Windows.Forms.Label lblEstadoAnimal;
        private System.Windows.Forms.ComboBox cmbEstadoAnimal;
        private System.Windows.Forms.Button btnActualizarEstado;
        private System.Windows.Forms.DataGridView dgvAnimales;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAnimalId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAnimalNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAnimalEspecie;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAnimalEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAnimalFecha;

        // ── TAB ADOPTANTES ────────────────────────────────────────────────────
        private System.Windows.Forms.TabPage tabAdoptantes;
        private System.Windows.Forms.GroupBox grpRegistroAdoptante;
        private System.Windows.Forms.Label lblNombreAdoptante;
        private System.Windows.Forms.TextBox txtNombreAdoptante;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefonoAdoptante;
        private System.Windows.Forms.Button btnRegistrarAdoptante;
        private System.Windows.Forms.DataGridView dgvAdoptantes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdoptanteId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdoptanteNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdoptanteTel;

        // ── TAB ADOPCIONES ────────────────────────────────────────────────────
        private System.Windows.Forms.TabPage tabAdopciones;
        private System.Windows.Forms.GroupBox grpNuevaAdopcion;
        private System.Windows.Forms.Label lblAnimalAdopcion;
        private System.Windows.Forms.ComboBox cmbAnimalAdopcion;
        private System.Windows.Forms.Label lblAdoptanteAdopcion;
        private System.Windows.Forms.ComboBox cmbAdoptanteAdopcion;
        private System.Windows.Forms.Button btnCrearAdopcion;
        private System.Windows.Forms.Button btnAprobarAdopcion;
        private System.Windows.Forms.Button btnRechazarAdopcion;
        private System.Windows.Forms.DataGridView dgvAdopciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdopcionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdopcionAnimal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdopcionAdoptante;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdopcionEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdopcionFecha;

        // ── TAB REGISTROS MÉDICOS ─────────────────────────────────────────────
        private System.Windows.Forms.TabPage tabRegistros;
        private System.Windows.Forms.GroupBox grpNuevoRegistro;
        private System.Windows.Forms.Label lblAnimalRegistro;
        private System.Windows.Forms.ComboBox cmbAnimalRegistro;
        private System.Windows.Forms.Label lblDiagnostico;
        private System.Windows.Forms.TextBox txtDiagnostico;
        private System.Windows.Forms.Label lblTratamiento;
        private System.Windows.Forms.TextBox txtTratamiento;
        private System.Windows.Forms.Button btnAgregarRegistro;
        private System.Windows.Forms.DataGridView dgvRegistros;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegAnimal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegDiag;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegTrat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegFecha;
    }
}
