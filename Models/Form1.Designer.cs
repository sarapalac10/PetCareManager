namespace PetCareInterface
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            tabControl = new TabControl();
            tabAnimales = new TabPage();
            tabAdoptantes = new TabPage();
            tabAdopciones = new TabPage();
            tabRegistros = new TabPage();

            // --- Controles Animales ---
            lblIdAnimal = new Label();
            lblNombreAnimal = new Label();
            lblEspecieAnimal = new Label();
            lblEstadoAnimal = new Label();
            txtIdAnimal = new TextBox();
            txtNombreAnimal = new TextBox();
            txtEspecieAnimal = new TextBox();
            cboEstadoAnimal = new ComboBox();
            btnGuardarAnimal = new Button();
            btnEliminarAnimal = new Button();
            btnLimpiarAnimal = new Button();
            dgvAnimales = new DataGridView();

            // --- Controles Adoptantes ---
            lblIdAdoptante = new Label();
            lblNombreAdoptante = new Label();
            lblTelefonoAdoptante = new Label();
            txtIdAdoptante = new TextBox();
            txtNombreAdoptante = new TextBox();
            txtTelefonoAdoptante = new TextBox();
            btnGuardarAdoptante = new Button();
            btnEliminarAdoptante = new Button();
            btnLimpiarAdoptante = new Button();
            dgvAdoptantes = new DataGridView();

            // --- Controles Adopciones ---
            lblIdAdopcion = new Label();
            lblAnimalAdopcion = new Label();
            lblAdoptanteAdopcion = new Label();
            lblEstadoAdopcionTexto = new Label();
            lblEstadoAdopcionValor = new Label();
            txtIdAdopcion = new TextBox();
            cboAnimalAdopcion = new ComboBox();
            cboAdoptanteAdopcion = new ComboBox();
            btnGuardarAdopcion = new Button();
            btnAprobarAdopcion = new Button();
            btnRechazarAdopcion = new Button();
            btnEliminarAdopcion = new Button();
            btnLimpiarAdopcion = new Button();
            dgvAdopciones = new DataGridView();

            // --- Controles Registros Médicos ---
            lblIdRegistro = new Label();
            lblAnimalRegistro = new Label();
            lblDiagnostico = new Label();
            lblTratamiento = new Label();
            txtIdRegistro = new TextBox();
            cboAnimalRegistro = new ComboBox();
            txtDiagnostico = new TextBox();
            txtTratamiento = new TextBox();
            btnGuardarRegistro = new Button();
            btnEliminarRegistro = new Button();
            btnLimpiarRegistro = new Button();
            dgvRegistros = new DataGridView();

            tabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAnimales).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAdoptantes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAdopciones).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvRegistros).BeginInit();
            SuspendLayout();

            //
            // tabControl
            //
            tabControl.Controls.Add(tabAnimales);
            tabControl.Controls.Add(tabAdoptantes);
            tabControl.Controls.Add(tabAdopciones);
            tabControl.Controls.Add(tabRegistros);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Name = "tabControl";

            // ============================ TAB ANIMALES ============================
            tabAnimales.Text = "Animales";
            tabAnimales.Padding = new Padding(3);
            tabAnimales.UseVisualStyleBackColor = true;
            tabAnimales.Controls.Add(lblIdAnimal);
            tabAnimales.Controls.Add(txtIdAnimal);
            tabAnimales.Controls.Add(lblNombreAnimal);
            tabAnimales.Controls.Add(txtNombreAnimal);
            tabAnimales.Controls.Add(lblEspecieAnimal);
            tabAnimales.Controls.Add(txtEspecieAnimal);
            tabAnimales.Controls.Add(lblEstadoAnimal);
            tabAnimales.Controls.Add(cboEstadoAnimal);
            tabAnimales.Controls.Add(btnGuardarAnimal);
            tabAnimales.Controls.Add(btnEliminarAnimal);
            tabAnimales.Controls.Add(btnLimpiarAnimal);
            tabAnimales.Controls.Add(dgvAnimales);

            lblIdAnimal.Location = new Point(15, 18);
            lblIdAnimal.AutoSize = true;
            lblIdAnimal.Text = "ID del animal:";
            txtIdAnimal.Location = new Point(140, 15);
            txtIdAnimal.Size = new Size(200, 23);

            lblNombreAnimal.Location = new Point(15, 53);
            lblNombreAnimal.AutoSize = true;
            lblNombreAnimal.Text = "Nombre:";
            txtNombreAnimal.Location = new Point(140, 50);
            txtNombreAnimal.Size = new Size(200, 23);

            lblEspecieAnimal.Location = new Point(15, 88);
            lblEspecieAnimal.AutoSize = true;
            lblEspecieAnimal.Text = "Especie / raza:";
            txtEspecieAnimal.Location = new Point(140, 85);
            txtEspecieAnimal.Size = new Size(200, 23);

            lblEstadoAnimal.Location = new Point(15, 123);
            lblEstadoAnimal.AutoSize = true;
            lblEstadoAnimal.Text = "Estado:";
            cboEstadoAnimal.Location = new Point(140, 120);
            cboEstadoAnimal.Size = new Size(200, 23);
            cboEstadoAnimal.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstadoAnimal.Items.AddRange(new object[] { "En observación", "Disponible", "En tratamiento", "Adoptado" });

            btnGuardarAnimal.Location = new Point(370, 15);
            btnGuardarAnimal.Size = new Size(110, 30);
            btnGuardarAnimal.Text = "Guardar";
            btnGuardarAnimal.UseVisualStyleBackColor = true;
            btnGuardarAnimal.Click += btnGuardarAnimal_Click;

            btnEliminarAnimal.Location = new Point(370, 50);
            btnEliminarAnimal.Size = new Size(110, 30);
            btnEliminarAnimal.Text = "Eliminar";
            btnEliminarAnimal.UseVisualStyleBackColor = true;
            btnEliminarAnimal.Click += btnEliminarAnimal_Click;

            btnLimpiarAnimal.Location = new Point(370, 85);
            btnLimpiarAnimal.Size = new Size(110, 30);
            btnLimpiarAnimal.Text = "Limpiar";
            btnLimpiarAnimal.UseVisualStyleBackColor = true;
            btnLimpiarAnimal.Click += btnLimpiarAnimal_Click;

            dgvAnimales.Location = new Point(15, 165);
            dgvAnimales.Size = new Size(740, 300);
            dgvAnimales.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAnimales.ReadOnly = true;
            dgvAnimales.AllowUserToAddRows = false;
            dgvAnimales.AllowUserToDeleteRows = false;
            dgvAnimales.MultiSelect = false;
            dgvAnimales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAnimales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAnimales.SelectionChanged += dgvAnimales_SelectionChanged;

            // ============================ TAB ADOPTANTES ============================
            tabAdoptantes.Text = "Adoptantes";
            tabAdoptantes.Padding = new Padding(3);
            tabAdoptantes.UseVisualStyleBackColor = true;
            tabAdoptantes.Controls.Add(lblIdAdoptante);
            tabAdoptantes.Controls.Add(txtIdAdoptante);
            tabAdoptantes.Controls.Add(lblNombreAdoptante);
            tabAdoptantes.Controls.Add(txtNombreAdoptante);
            tabAdoptantes.Controls.Add(lblTelefonoAdoptante);
            tabAdoptantes.Controls.Add(txtTelefonoAdoptante);
            tabAdoptantes.Controls.Add(btnGuardarAdoptante);
            tabAdoptantes.Controls.Add(btnEliminarAdoptante);
            tabAdoptantes.Controls.Add(btnLimpiarAdoptante);
            tabAdoptantes.Controls.Add(dgvAdoptantes);

            lblIdAdoptante.Location = new Point(15, 18);
            lblIdAdoptante.AutoSize = true;
            lblIdAdoptante.Text = "Cédula:";
            txtIdAdoptante.Location = new Point(140, 15);
            txtIdAdoptante.Size = new Size(200, 23);

            lblNombreAdoptante.Location = new Point(15, 53);
            lblNombreAdoptante.AutoSize = true;
            lblNombreAdoptante.Text = "Nombre completo:";
            txtNombreAdoptante.Location = new Point(140, 50);
            txtNombreAdoptante.Size = new Size(200, 23);

            lblTelefonoAdoptante.Location = new Point(15, 88);
            lblTelefonoAdoptante.AutoSize = true;
            lblTelefonoAdoptante.Text = "Teléfono:";
            txtTelefonoAdoptante.Location = new Point(140, 85);
            txtTelefonoAdoptante.Size = new Size(200, 23);

            btnGuardarAdoptante.Location = new Point(370, 15);
            btnGuardarAdoptante.Size = new Size(110, 30);
            btnGuardarAdoptante.Text = "Guardar";
            btnGuardarAdoptante.UseVisualStyleBackColor = true;
            btnGuardarAdoptante.Click += btnGuardarAdoptante_Click;

            btnEliminarAdoptante.Location = new Point(370, 50);
            btnEliminarAdoptante.Size = new Size(110, 30);
            btnEliminarAdoptante.Text = "Eliminar";
            btnEliminarAdoptante.UseVisualStyleBackColor = true;
            btnEliminarAdoptante.Click += btnEliminarAdoptante_Click;

            btnLimpiarAdoptante.Location = new Point(370, 85);
            btnLimpiarAdoptante.Size = new Size(110, 30);
            btnLimpiarAdoptante.Text = "Limpiar";
            btnLimpiarAdoptante.UseVisualStyleBackColor = true;
            btnLimpiarAdoptante.Click += btnLimpiarAdoptante_Click;

            dgvAdoptantes.Location = new Point(15, 130);
            dgvAdoptantes.Size = new Size(740, 335);
            dgvAdoptantes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAdoptantes.ReadOnly = true;
            dgvAdoptantes.AllowUserToAddRows = false;
            dgvAdoptantes.AllowUserToDeleteRows = false;
            dgvAdoptantes.MultiSelect = false;
            dgvAdoptantes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAdoptantes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAdoptantes.SelectionChanged += dgvAdoptantes_SelectionChanged;

            // ============================ TAB ADOPCIONES ============================
            tabAdopciones.Text = "Adopciones";
            tabAdopciones.Padding = new Padding(3);
            tabAdopciones.UseVisualStyleBackColor = true;
            tabAdopciones.Controls.Add(lblIdAdopcion);
            tabAdopciones.Controls.Add(txtIdAdopcion);
            tabAdopciones.Controls.Add(lblAnimalAdopcion);
            tabAdopciones.Controls.Add(cboAnimalAdopcion);
            tabAdopciones.Controls.Add(lblAdoptanteAdopcion);
            tabAdopciones.Controls.Add(cboAdoptanteAdopcion);
            tabAdopciones.Controls.Add(lblEstadoAdopcionTexto);
            tabAdopciones.Controls.Add(lblEstadoAdopcionValor);
            tabAdopciones.Controls.Add(btnGuardarAdopcion);
            tabAdopciones.Controls.Add(btnAprobarAdopcion);
            tabAdopciones.Controls.Add(btnRechazarAdopcion);
            tabAdopciones.Controls.Add(btnEliminarAdopcion);
            tabAdopciones.Controls.Add(btnLimpiarAdopcion);
            tabAdopciones.Controls.Add(dgvAdopciones);

            lblIdAdopcion.Location = new Point(15, 18);
            lblIdAdopcion.AutoSize = true;
            lblIdAdopcion.Text = "ID adopción:";
            txtIdAdopcion.Location = new Point(140, 15);
            txtIdAdopcion.Size = new Size(200, 23);

            lblAnimalAdopcion.Location = new Point(15, 53);
            lblAnimalAdopcion.AutoSize = true;
            lblAnimalAdopcion.Text = "Animal:";
            cboAnimalAdopcion.Location = new Point(140, 50);
            cboAnimalAdopcion.Size = new Size(200, 23);
            cboAnimalAdopcion.DropDownStyle = ComboBoxStyle.DropDownList;

            lblAdoptanteAdopcion.Location = new Point(15, 88);
            lblAdoptanteAdopcion.AutoSize = true;
            lblAdoptanteAdopcion.Text = "Adoptante:";
            cboAdoptanteAdopcion.Location = new Point(140, 85);
            cboAdoptanteAdopcion.Size = new Size(200, 23);
            cboAdoptanteAdopcion.DropDownStyle = ComboBoxStyle.DropDownList;

            lblEstadoAdopcionTexto.Location = new Point(15, 123);
            lblEstadoAdopcionTexto.AutoSize = true;
            lblEstadoAdopcionTexto.Text = "Estado:";
            lblEstadoAdopcionValor.Location = new Point(140, 123);
            lblEstadoAdopcionValor.AutoSize = true;
            lblEstadoAdopcionValor.Text = "-";

            btnGuardarAdopcion.Location = new Point(370, 15);
            btnGuardarAdopcion.Size = new Size(110, 30);
            btnGuardarAdopcion.Text = "Nueva solicitud";
            btnGuardarAdopcion.UseVisualStyleBackColor = true;
            btnGuardarAdopcion.Click += btnGuardarAdopcion_Click;

            btnAprobarAdopcion.Location = new Point(370, 50);
            btnAprobarAdopcion.Size = new Size(110, 30);
            btnAprobarAdopcion.Text = "Aprobar";
            btnAprobarAdopcion.UseVisualStyleBackColor = true;
            btnAprobarAdopcion.Click += btnAprobarAdopcion_Click;

            btnRechazarAdopcion.Location = new Point(490, 50);
            btnRechazarAdopcion.Size = new Size(110, 30);
            btnRechazarAdopcion.Text = "Rechazar";
            btnRechazarAdopcion.UseVisualStyleBackColor = true;
            btnRechazarAdopcion.Click += btnRechazarAdopcion_Click;

            btnEliminarAdopcion.Location = new Point(490, 15);
            btnEliminarAdopcion.Size = new Size(110, 30);
            btnEliminarAdopcion.Text = "Eliminar";
            btnEliminarAdopcion.UseVisualStyleBackColor = true;
            btnEliminarAdopcion.Click += btnEliminarAdopcion_Click;

            btnLimpiarAdopcion.Location = new Point(610, 15);
            btnLimpiarAdopcion.Size = new Size(110, 30);
            btnLimpiarAdopcion.Text = "Limpiar";
            btnLimpiarAdopcion.UseVisualStyleBackColor = true;
            btnLimpiarAdopcion.Click += btnLimpiarAdopcion_Click;

            dgvAdopciones.Location = new Point(15, 165);
            dgvAdopciones.Size = new Size(740, 300);
            dgvAdopciones.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAdopciones.ReadOnly = true;
            dgvAdopciones.AllowUserToAddRows = false;
            dgvAdopciones.AllowUserToDeleteRows = false;
            dgvAdopciones.MultiSelect = false;
            dgvAdopciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAdopciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAdopciones.SelectionChanged += dgvAdopciones_SelectionChanged;

            // ============================ TAB REGISTROS MÉDICOS ============================
            tabRegistros.Text = "Registros médicos";
            tabRegistros.Padding = new Padding(3);
            tabRegistros.UseVisualStyleBackColor = true;
            tabRegistros.Controls.Add(lblIdRegistro);
            tabRegistros.Controls.Add(txtIdRegistro);
            tabRegistros.Controls.Add(lblAnimalRegistro);
            tabRegistros.Controls.Add(cboAnimalRegistro);
            tabRegistros.Controls.Add(lblDiagnostico);
            tabRegistros.Controls.Add(txtDiagnostico);
            tabRegistros.Controls.Add(lblTratamiento);
            tabRegistros.Controls.Add(txtTratamiento);
            tabRegistros.Controls.Add(btnGuardarRegistro);
            tabRegistros.Controls.Add(btnEliminarRegistro);
            tabRegistros.Controls.Add(btnLimpiarRegistro);
            tabRegistros.Controls.Add(dgvRegistros);

            lblIdRegistro.Location = new Point(15, 18);
            lblIdRegistro.AutoSize = true;
            lblIdRegistro.Text = "ID registro:";
            txtIdRegistro.Location = new Point(140, 15);
            txtIdRegistro.Size = new Size(200, 23);

            lblAnimalRegistro.Location = new Point(15, 53);
            lblAnimalRegistro.AutoSize = true;
            lblAnimalRegistro.Text = "Animal:";
            cboAnimalRegistro.Location = new Point(140, 50);
            cboAnimalRegistro.Size = new Size(200, 23);
            cboAnimalRegistro.DropDownStyle = ComboBoxStyle.DropDownList;

            lblDiagnostico.Location = new Point(15, 88);
            lblDiagnostico.AutoSize = true;
            lblDiagnostico.Text = "Diagnóstico:";
            txtDiagnostico.Location = new Point(140, 85);
            txtDiagnostico.Size = new Size(200, 23);

            lblTratamiento.Location = new Point(15, 123);
            lblTratamiento.AutoSize = true;
            lblTratamiento.Text = "Tratamiento:";
            txtTratamiento.Location = new Point(140, 120);
            txtTratamiento.Size = new Size(200, 23);

            btnGuardarRegistro.Location = new Point(370, 15);
            btnGuardarRegistro.Size = new Size(110, 30);
            btnGuardarRegistro.Text = "Guardar";
            btnGuardarRegistro.UseVisualStyleBackColor = true;
            btnGuardarRegistro.Click += btnGuardarRegistro_Click;

            btnEliminarRegistro.Location = new Point(370, 50);
            btnEliminarRegistro.Size = new Size(110, 30);
            btnEliminarRegistro.Text = "Eliminar";
            btnEliminarRegistro.UseVisualStyleBackColor = true;
            btnEliminarRegistro.Click += btnEliminarRegistro_Click;

            btnLimpiarRegistro.Location = new Point(370, 85);
            btnLimpiarRegistro.Size = new Size(110, 30);
            btnLimpiarRegistro.Text = "Limpiar";
            btnLimpiarRegistro.UseVisualStyleBackColor = true;
            btnLimpiarRegistro.Click += btnLimpiarRegistro_Click;

            dgvRegistros.Location = new Point(15, 165);
            dgvRegistros.Size = new Size(740, 300);
            dgvRegistros.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvRegistros.ReadOnly = true;
            dgvRegistros.AllowUserToAddRows = false;
            dgvRegistros.AllowUserToDeleteRows = false;
            dgvRegistros.MultiSelect = false;
            dgvRegistros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRegistros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRegistros.SelectionChanged += dgvRegistros_SelectionChanged;

            //
            // Form1
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 511);
            Controls.Add(tabControl);
            Name = "Form1";
            Text = "PetCare Manager";
            Load += Form1_Load;

            tabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAnimales).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAdoptantes).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAdopciones).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvRegistros).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl;
        private TabPage tabAnimales;
        private TabPage tabAdoptantes;
        private TabPage tabAdopciones;
        private TabPage tabRegistros;

        private Label lblIdAnimal;
        private Label lblNombreAnimal;
        private Label lblEspecieAnimal;
        private Label lblEstadoAnimal;
        private TextBox txtIdAnimal;
        private TextBox txtNombreAnimal;
        private TextBox txtEspecieAnimal;
        private ComboBox cboEstadoAnimal;
        private Button btnGuardarAnimal;
        private Button btnEliminarAnimal;
        private Button btnLimpiarAnimal;
        private DataGridView dgvAnimales;

        private Label lblIdAdoptante;
        private Label lblNombreAdoptante;
        private Label lblTelefonoAdoptante;
        private TextBox txtIdAdoptante;
        private TextBox txtNombreAdoptante;
        private TextBox txtTelefonoAdoptante;
        private Button btnGuardarAdoptante;
        private Button btnEliminarAdoptante;
        private Button btnLimpiarAdoptante;
        private DataGridView dgvAdoptantes;

        private Label lblIdAdopcion;
        private Label lblAnimalAdopcion;
        private Label lblAdoptanteAdopcion;
        private Label lblEstadoAdopcionTexto;
        private Label lblEstadoAdopcionValor;
        private TextBox txtIdAdopcion;
        private ComboBox cboAnimalAdopcion;
        private ComboBox cboAdoptanteAdopcion;
        private Button btnGuardarAdopcion;
        private Button btnAprobarAdopcion;
        private Button btnRechazarAdopcion;
        private Button btnEliminarAdopcion;
        private Button btnLimpiarAdopcion;
        private DataGridView dgvAdopciones;

        private Label lblIdRegistro;
        private Label lblAnimalRegistro;
        private Label lblDiagnostico;
        private Label lblTratamiento;
        private TextBox txtIdRegistro;
        private ComboBox cboAnimalRegistro;
        private TextBox txtDiagnostico;
        private TextBox txtTratamiento;
        private Button btnGuardarRegistro;
        private Button btnEliminarRegistro;
        private Button btnLimpiarRegistro;
        private DataGridView dgvRegistros;
    }
}
