namespace PetCareInterface
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnAnimal = new Button();
            btnAdoptante = new Button();
            txtEspecie = new TextBox();
            txtIdAnimal = new TextBox();
            txtNombreAnimal = new TextBox();
            txtIdAdoptante = new TextBox();
            txtTelefono = new TextBox();
            txtNombreAdoptante = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // btnAnimal
            // 
            btnAnimal.Location = new Point(231, 196);
            btnAnimal.Name = "btnAnimal";
            btnAnimal.Size = new Size(111, 47);
            btnAnimal.TabIndex = 0;
            btnAnimal.Text = " Registro animal";
            btnAnimal.UseVisualStyleBackColor = true;
            btnAnimal.Click += button1_Click;
            // 
            // btnAdoptante
            // 
            btnAdoptante.Location = new Point(462, 195);
            btnAdoptante.Name = "btnAdoptante";
            btnAdoptante.Size = new Size(111, 49);
            btnAdoptante.TabIndex = 1;
            btnAdoptante.Text = "Registrar Adoptante";
            btnAdoptante.UseVisualStyleBackColor = true;
            btnAdoptante.Click += button2_Click;
            // 
            // txtEspecie
            // 
            txtEspecie.Location = new Point(231, 156);
            txtEspecie.Name = "txtEspecie";
            txtEspecie.Size = new Size(111, 23);
            txtEspecie.TabIndex = 2;
            // 
            // txtIdAnimal
            // 
            txtIdAnimal.Location = new Point(231, 50);
            txtIdAnimal.Name = "txtIdAnimal";
            txtIdAnimal.Size = new Size(111, 23);
            txtIdAnimal.TabIndex = 3;
            txtIdAnimal.TextChanged += txtNombre_TextChanged;
            // 
            // txtNombreAnimal
            // 
            txtNombreAnimal.Location = new Point(231, 112);
            txtNombreAnimal.Name = "txtNombreAnimal";
            txtNombreAnimal.Size = new Size(111, 23);
            txtNombreAnimal.TabIndex = 4;
            // 
            // txtIdAdoptante
            // 
            txtIdAdoptante.Location = new Point(462, 50);
            txtIdAdoptante.Name = "txtIdAdoptante";
            txtIdAdoptante.Size = new Size(111, 23);
            txtIdAdoptante.TabIndex = 5;
            txtIdAdoptante.TextChanged += txtIdAdoptante_TextChanged;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(462, 156);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(111, 23);
            txtTelefono.TabIndex = 6;
            txtTelefono.TextChanged += textBox3_TextChanged;
            // 
            // txtNombreAdoptante
            // 
            txtNombreAdoptante.Location = new Point(462, 106);
            txtNombreAdoptante.Name = "txtNombreAdoptante";
            txtNombreAdoptante.Size = new Size(111, 23);
            txtNombreAdoptante.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(231, 32);
            label1.Name = "label1";
            label1.Size = new Size(78, 15);
            label1.TabIndex = 8;
            label1.Text = "ID del Animal";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(231, 88);
            label2.Name = "label2";
            label2.Size = new Size(111, 15);
            label2.TabIndex = 9;
            label2.Text = "Nombre del Animal";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(231, 138);
            label3.Name = "label3";
            label3.Size = new Size(75, 15);
            label3.TabIndex = 10;
            label3.Text = "Raza/Especie";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(462, 32);
            label4.Name = "label4";
            label4.Size = new Size(103, 15);
            label4.TabIndex = 11;
            label4.Text = "Cédula Adoptante";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(462, 88);
            label5.Name = "label5";
            label5.Size = new Size(107, 15);
            label5.TabIndex = 12;
            label5.Text = "Nombre Completo";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(462, 138);
            label6.Name = "label6";
            label6.Size = new Size(52, 15);
            label6.TabIndex = 13;
            label6.Text = "Teléfono";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtNombreAdoptante);
            Controls.Add(txtTelefono);
            Controls.Add(txtIdAdoptante);
            Controls.Add(txtNombreAnimal);
            Controls.Add(txtIdAnimal);
            Controls.Add(txtEspecie);
            Controls.Add(btnAdoptante);
            Controls.Add(btnAnimal);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAnimal;
        private Button btnAdoptante;
        private TextBox txtEspecie;
        private TextBox txtIdAnimal;
        private TextBox txtNombreAnimal;
        private TextBox txtIdAdoptante;
        private TextBox txtTelefono;
        private TextBox txtNombreAdoptante;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}
