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
            btnVerConfirmPassword = new PictureBox();
            btnVerPassword = new PictureBox();
            txtNombre = new TextBox();
            label7 = new Label();
            label2 = new Label();
            txtUsuario = new TextBox();
            label3 = new Label();
            txtPassword = new TextBox();
            txtConfirmarPassword = new TextBox();
            label5 = new Label();
            btnGuardar = new Button();
            btnCancelar = new Button();
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
            label1.Size = new Size(526, 104);
            label1.TabIndex = 0;
            label1.Text = "Crear Usuario";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnCancelar);
            panel1.Controls.Add(btnGuardar);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtConfirmarPassword);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtUsuario);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(txtNombre);
            panel1.Controls.Add(btnVerConfirmPassword);
            panel1.Controls.Add(btnVerPassword);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 104);
            panel1.Name = "panel1";
            panel1.Size = new Size(526, 498);
            panel1.TabIndex = 1;
            // 
            // btnVerConfirmPassword
            // 
            btnVerConfirmPassword.Image = Properties.Resources.eye_open;
            btnVerConfirmPassword.Location = new Point(428, 310);
            btnVerConfirmPassword.Name = "btnVerConfirmPassword";
            btnVerConfirmPassword.Size = new Size(37, 38);
            btnVerConfirmPassword.SizeMode = PictureBoxSizeMode.Zoom;
            btnVerConfirmPassword.TabIndex = 11;
            btnVerConfirmPassword.TabStop = false;
            // 
            // btnVerPassword
            // 
            btnVerPassword.Image = Properties.Resources.eye_open;
            btnVerPassword.Location = new Point(428, 217);
            btnVerPassword.Name = "btnVerPassword";
            btnVerPassword.Size = new Size(37, 38);
            btnVerPassword.SizeMode = PictureBoxSizeMode.Zoom;
            btnVerPassword.TabIndex = 10;
            btnVerPassword.TabStop = false;
            // 
            // txtNombre
            // 
            txtNombre.BackColor = Color.White;
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombre.Location = new Point(68, 53);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(354, 38);
            txtNombre.TabIndex = 27;
            txtNombre.TextAlign = HorizontalAlignment.Center;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(75, 19);
            label7.Name = "label7";
            label7.Size = new Size(101, 31);
            label7.TabIndex = 28;
            label7.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(75, 99);
            label2.Name = "label2";
            label2.Size = new Size(94, 31);
            label2.TabIndex = 30;
            label2.Text = "Usuario";
            // 
            // txtUsuario
            // 
            txtUsuario.BackColor = Color.White;
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtUsuario.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsuario.Location = new Point(68, 133);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(354, 38);
            txtUsuario.TabIndex = 29;
            txtUsuario.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(75, 183);
            label3.Name = "label3";
            label3.Size = new Size(131, 31);
            label3.TabIndex = 32;
            label3.Text = "Contraseña";
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.White;
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(68, 217);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(354, 38);
            txtPassword.TabIndex = 31;
            txtPassword.TextAlign = HorizontalAlignment.Center;
            // 
            // txtConfirmarPassword
            // 
            txtConfirmarPassword.BackColor = Color.White;
            txtConfirmarPassword.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmarPassword.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtConfirmarPassword.Location = new Point(68, 310);
            txtConfirmarPassword.Name = "txtConfirmarPassword";
            txtConfirmarPassword.Size = new Size(354, 38);
            txtConfirmarPassword.TabIndex = 33;
            txtConfirmarPassword.TextAlign = HorizontalAlignment.Center;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(75, 276);
            label5.Name = "label5";
            label5.Size = new Size(233, 31);
            label5.TabIndex = 34;
            label5.Text = "Confimar Contraseña";
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = SystemColors.MenuHighlight;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(95, 392);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(138, 69);
            btnGuardar.TabIndex = 37;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Red;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(264, 392);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(138, 69);
            btnCancelar.TabIndex = 38;
            btnCancelar.Text = "Salir";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // CrearUsuario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(526, 602);
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
        private PictureBox btnVerPassword;
        private PictureBox btnVerConfirmPassword;
        private TextBox txtNombre;
        private Label label7;
        private Label label5;
        private TextBox txtConfirmarPassword;
        private Label label3;
        private TextBox txtPassword;
        private Label label2;
        private TextBox txtUsuario;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}