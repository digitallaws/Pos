namespace Sopromil.Vista.Configuracion
{
    partial class FrmConfiguracion
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
            label3 = new Label();
            panel1 = new Panel();
            btnProbar = new Button();
            btnCancelar = new Button();
            btnGuardar = new Button();
            txtClave = new TextBox();
            label6 = new Label();
            txtUsuario = new TextBox();
            label5 = new Label();
            cboTipoAuth = new ComboBox();
            label4 = new Label();
            txtBaseDatos = new TextBox();
            label2 = new Label();
            label1 = new Label();
            txtServidor = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label3
            // 
            label3.BackColor = Color.CornflowerBlue;
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(533, 90);
            label3.TabIndex = 2;
            label3.Text = "Conexión Base de Datos";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnProbar);
            panel1.Controls.Add(btnCancelar);
            panel1.Controls.Add(btnGuardar);
            panel1.Controls.Add(txtClave);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(txtUsuario);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(cboTipoAuth);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtBaseDatos);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtServidor);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 90);
            panel1.Name = "panel1";
            panel1.Size = new Size(533, 612);
            panel1.TabIndex = 3;
            // 
            // btnProbar
            // 
            btnProbar.BackColor = Color.LimeGreen;
            btnProbar.FlatStyle = FlatStyle.Flat;
            btnProbar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnProbar.ForeColor = Color.White;
            btnProbar.Location = new Point(196, 519);
            btnProbar.Name = "btnProbar";
            btnProbar.Size = new Size(138, 69);
            btnProbar.TabIndex = 38;
            btnProbar.Text = "Probar Conexión";
            btnProbar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Red;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(345, 519);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(138, 69);
            btnCancelar.TabIndex = 37;
            btnCancelar.Text = "Salir";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.CornflowerBlue;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(42, 519);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(138, 69);
            btnGuardar.TabIndex = 36;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            // 
            // txtClave
            // 
            txtClave.BackColor = Color.White;
            txtClave.BorderStyle = BorderStyle.FixedSingle;
            txtClave.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtClave.Location = new Point(99, 451);
            txtClave.Name = "txtClave";
            txtClave.Size = new Size(354, 38);
            txtClave.TabIndex = 35;
            txtClave.TextAlign = HorizontalAlignment.Center;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(47, 405);
            label6.Name = "label6";
            label6.Size = new Size(131, 31);
            label6.TabIndex = 34;
            label6.Text = "Contraseña";
            // 
            // txtUsuario
            // 
            txtUsuario.BackColor = Color.White;
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtUsuario.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsuario.Location = new Point(99, 355);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(354, 38);
            txtUsuario.TabIndex = 33;
            txtUsuario.TextAlign = HorizontalAlignment.Center;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(47, 321);
            label5.Name = "label5";
            label5.Size = new Size(94, 31);
            label5.TabIndex = 32;
            label5.Text = "Usuario";
            // 
            // cboTipoAuth
            // 
            cboTipoAuth.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboTipoAuth.FormattingEnabled = true;
            cboTipoAuth.Location = new Point(99, 267);
            cboTipoAuth.Name = "cboTipoAuth";
            cboTipoAuth.Size = new Size(354, 39);
            cboTipoAuth.TabIndex = 31;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(47, 220);
            label4.Name = "label4";
            label4.Size = new Size(209, 31);
            label4.TabIndex = 30;
            label4.Text = "Tipo Autenticación";
            // 
            // txtBaseDatos
            // 
            txtBaseDatos.BackColor = Color.White;
            txtBaseDatos.BorderStyle = BorderStyle.FixedSingle;
            txtBaseDatos.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBaseDatos.Location = new Point(99, 167);
            txtBaseDatos.Name = "txtBaseDatos";
            txtBaseDatos.Size = new Size(354, 38);
            txtBaseDatos.TabIndex = 29;
            txtBaseDatos.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(47, 123);
            label2.Name = "label2";
            label2.Size = new Size(161, 31);
            label2.TabIndex = 28;
            label2.Text = "Base de Datos";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(47, 26);
            label1.Name = "label1";
            label1.Size = new Size(104, 31);
            label1.TabIndex = 27;
            label1.Text = "Servidor";
            // 
            // txtServidor
            // 
            txtServidor.BackColor = Color.White;
            txtServidor.BorderStyle = BorderStyle.FixedSingle;
            txtServidor.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtServidor.Location = new Point(99, 70);
            txtServidor.Name = "txtServidor";
            txtServidor.Size = new Size(354, 38);
            txtServidor.TabIndex = 26;
            txtServidor.TextAlign = HorizontalAlignment.Center;
            // 
            // FrmConfiguracion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(533, 702);
            Controls.Add(panel1);
            Controls.Add(label3);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmConfiguracion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmConfiguracion";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label3;
        private Panel panel1;
        private Label label1;
        private TextBox txtServidor;
        private Button btnCancelar;
        private Button btnGuardar;
        private TextBox txtClave;
        private Label label6;
        private TextBox txtUsuario;
        private Label label5;
        private ComboBox cboTipoAuth;
        private Label label4;
        private TextBox txtBaseDatos;
        private Label label2;
        private Button btnProbar;
    }
}