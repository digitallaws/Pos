namespace Sopromil.Vista.Usuarios
{
    partial class CrearUsuario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            panel1 = new Panel();
            cmbRol = new ComboBox();
            label6 = new Label();
            btnVerConfirmPassword = new PictureBox();
            btnVerPassword = new PictureBox();
            btnCancelar = new Button();
            btnGuardar = new Button();
            label4 = new Label();
            txtConfirmarPassword = new TextBox();
            label5 = new Label();
            txtPassword = new TextBox();
            label3 = new Label();
            txtUsuario = new TextBox();
            label2 = new Label();
            txtNombre = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnVerConfirmPassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnVerPassword).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.DodgerBlue;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(473, 104);
            label1.TabIndex = 0;
            label1.Text = "Crear Usuario";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(cmbRol);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(btnVerConfirmPassword);
            panel1.Controls.Add(btnVerPassword);
            panel1.Controls.Add(btnCancelar);
            panel1.Controls.Add(btnGuardar);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtConfirmarPassword);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtUsuario);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtNombre);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 104);
            panel1.Name = "panel1";
            panel1.Size = new Size(473, 438);
            panel1.TabIndex = 1;
            // 
            // cmbRol
            // 
            cmbRol.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbRol.FormattingEnabled = true;
            cmbRol.Location = new Point(93, 303);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(284, 33);
            cmbRol.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(93, 280);
            label6.Name = "label6";
            label6.Size = new Size(31, 20);
            label6.TabIndex = 12;
            label6.Text = "Rol";
            // 
            // btnVerConfirmPassword
            // 
            btnVerConfirmPassword.Image = Properties.Resources.eye_open;
            btnVerConfirmPassword.Location = new Point(385, 240);
            btnVerConfirmPassword.Name = "btnVerConfirmPassword";
            btnVerConfirmPassword.Size = new Size(37, 31);
            btnVerConfirmPassword.SizeMode = PictureBoxSizeMode.Zoom;
            btnVerConfirmPassword.TabIndex = 11;
            btnVerConfirmPassword.TabStop = false;
            // 
            // btnVerPassword
            // 
            btnVerPassword.Image = Properties.Resources.eye_open;
            btnVerPassword.Location = new Point(385, 180);
            btnVerPassword.Name = "btnVerPassword";
            btnVerPassword.Size = new Size(37, 31);
            btnVerPassword.SizeMode = PictureBoxSizeMode.Zoom;
            btnVerPassword.TabIndex = 10;
            btnVerPassword.TabStop = false;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(255, 128, 128);
            btnCancelar.FlatStyle = FlatStyle.Popup;
            btnCancelar.Location = new Point(247, 358);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(116, 47);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Atras";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(192, 255, 192);
            btnGuardar.FlatStyle = FlatStyle.Popup;
            btnGuardar.Location = new Point(105, 358);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(109, 47);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Registrar";
            btnGuardar.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(93, 217);
            label4.Name = "label4";
            label4.Size = new Size(153, 20);
            label4.TabIndex = 7;
            label4.Text = "Confirmar Contraseña";
            // 
            // txtConfirmarPassword
            // 
            txtConfirmarPassword.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmarPassword.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtConfirmarPassword.Location = new Point(93, 240);
            txtConfirmarPassword.Name = "txtConfirmarPassword";
            txtConfirmarPassword.Size = new Size(286, 31);
            txtConfirmarPassword.TabIndex = 6;
            txtConfirmarPassword.TextAlign = HorizontalAlignment.Center;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(93, 157);
            label5.Name = "label5";
            label5.Size = new Size(83, 20);
            label5.TabIndex = 5;
            label5.Text = "Contraseña";
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(93, 180);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(286, 31);
            txtPassword.TabIndex = 4;
            txtPassword.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(93, 94);
            label3.Name = "label3";
            label3.Size = new Size(59, 20);
            label3.TabIndex = 3;
            label3.Text = "Usuario";
            // 
            // txtUsuario
            // 
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtUsuario.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsuario.Location = new Point(93, 117);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(286, 31);
            txtUsuario.TabIndex = 2;
            txtUsuario.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(93, 25);
            label2.Name = "label2";
            label2.Size = new Size(64, 20);
            label2.TabIndex = 1;
            label2.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombre.Location = new Point(93, 48);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(286, 31);
            txtNombre.TabIndex = 0;
            txtNombre.TextAlign = HorizontalAlignment.Center;
            // 
            // CrearUsuario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(473, 542);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "CrearUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CrearUsuario";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btnVerConfirmPassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnVerPassword).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private TextBox txtNombre;
        private Button btnCancelar;
        private Button btnGuardar;
        private Label label4;
        private TextBox txtConfirmarPassword;
        private Label label5;
        private TextBox txtPassword;
        private Label label3;
        private TextBox txtUsuario;
        private Label label2;
        private PictureBox btnVerPassword;
        private PictureBox btnVerConfirmPassword;
        private ComboBox cmbRol;
        private Label label6;
    }
}