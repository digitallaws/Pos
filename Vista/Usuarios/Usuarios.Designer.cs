namespace Sopromil.Vista.Usuarios
{
    partial class Usuarios
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
            panel3 = new Panel();
            dtUsuarios = new DataGridView();
            panel6 = new Panel();
            panel5 = new Panel();
            panel4 = new Panel();
            label8 = new Label();
            txtBuscar = new TextBox();
            pictureBox2 = new PictureBox();
            panel2 = new Panel();
            btnActualizar = new Button();
            btnRegistrar = new Button();
            cbEstado = new ComboBox();
            label6 = new Label();
            label9 = new Label();
            cbRol = new ComboBox();
            txtPassword = new TextBox();
            label1 = new Label();
            txtLogin = new TextBox();
            label2 = new Label();
            txtNombre = new TextBox();
            label5 = new Label();
            lbId = new Label();
            label4 = new Label();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtUsuarios).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(dtUsuarios);
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(342, 114);
            panel3.Name = "panel3";
            panel3.Size = new Size(972, 638);
            panel3.TabIndex = 5;
            // 
            // dtUsuarios
            // 
            dtUsuarios.AllowUserToAddRows = false;
            dtUsuarios.AllowUserToDeleteRows = false;
            dtUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtUsuarios.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dtUsuarios.BackgroundColor = Color.White;
            dtUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtUsuarios.Dock = DockStyle.Fill;
            dtUsuarios.Location = new Point(0, 117);
            dtUsuarios.Name = "dtUsuarios";
            dtUsuarios.ReadOnly = true;
            dtUsuarios.RowHeadersVisible = false;
            dtUsuarios.RowHeadersWidth = 51;
            dtUsuarios.Size = new Size(784, 393);
            dtUsuarios.TabIndex = 6;
            // 
            // panel6
            // 
            panel6.Dock = DockStyle.Bottom;
            panel6.Location = new Point(0, 510);
            panel6.Name = "panel6";
            panel6.Size = new Size(784, 128);
            panel6.TabIndex = 5;
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Right;
            panel5.Location = new Point(784, 117);
            panel5.Name = "panel5";
            panel5.Size = new Size(188, 521);
            panel5.TabIndex = 3;
            // 
            // panel4
            // 
            panel4.Controls.Add(label8);
            panel4.Controls.Add(txtBuscar);
            panel4.Controls.Add(pictureBox2);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(972, 117);
            panel4.TabIndex = 1;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(80, 23);
            label8.Name = "label8";
            label8.Size = new Size(83, 31);
            label8.TabIndex = 34;
            label8.Text = "Buscar";
            // 
            // txtBuscar
            // 
            txtBuscar.BackColor = Color.White;
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;
            txtBuscar.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.Location = new Point(68, 57);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(286, 38);
            txtBuscar.TabIndex = 33;
            txtBuscar.TextAlign = HorizontalAlignment.Center;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.White;
            pictureBox2.Image = Properties.Resources.buscar;
            pictureBox2.Location = new Point(360, 57);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(47, 38);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(btnActualizar);
            panel2.Controls.Add(btnRegistrar);
            panel2.Controls.Add(cbEstado);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(cbRol);
            panel2.Controls.Add(txtPassword);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtLogin);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(txtNombre);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(lbId);
            panel2.Controls.Add(label4);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 114);
            panel2.Name = "panel2";
            panel2.Size = new Size(342, 638);
            panel2.TabIndex = 7;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.CornflowerBlue;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(56, 532);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(235, 55);
            btnActualizar.TabIndex = 45;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = SystemColors.MenuHighlight;
            btnRegistrar.FlatStyle = FlatStyle.Flat;
            btnRegistrar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRegistrar.ForeColor = Color.White;
            btnRegistrar.Location = new Point(56, 532);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(235, 55);
            btnRegistrar.TabIndex = 44;
            btnRegistrar.Text = "Guardar";
            btnRegistrar.UseVisualStyleBackColor = false;
            // 
            // cbEstado
            // 
            cbEstado.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbEstado.FormattingEnabled = true;
            cbEstado.Location = new Point(24, 458);
            cbEstado.Name = "cbEstado";
            cbEstado.Size = new Size(286, 39);
            cbEstado.TabIndex = 43;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(24, 424);
            label6.Name = "label6";
            label6.Size = new Size(84, 31);
            label6.TabIndex = 42;
            label6.Text = "Estado";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(24, 338);
            label9.Name = "label9";
            label9.Size = new Size(47, 31);
            label9.TabIndex = 41;
            label9.Text = "Rol";
            // 
            // cbRol
            // 
            cbRol.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbRol.FormattingEnabled = true;
            cbRol.Location = new Point(24, 372);
            cbRol.Name = "cbRol";
            cbRol.Size = new Size(286, 39);
            cbRol.TabIndex = 40;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.White;
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(24, 293);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(286, 38);
            txtPassword.TabIndex = 39;
            txtPassword.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(24, 259);
            label1.Name = "label1";
            label1.Size = new Size(131, 31);
            label1.TabIndex = 38;
            label1.Text = "Contraseña";
            // 
            // txtLogin
            // 
            txtLogin.BackColor = Color.White;
            txtLogin.BorderStyle = BorderStyle.FixedSingle;
            txtLogin.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLogin.Location = new Point(24, 210);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(286, 38);
            txtLogin.TabIndex = 37;
            txtLogin.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(24, 176);
            label2.Name = "label2";
            label2.Size = new Size(94, 31);
            label2.TabIndex = 36;
            label2.Text = "Usuario";
            // 
            // txtNombre
            // 
            txtNombre.BackColor = Color.White;
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombre.Location = new Point(24, 125);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(286, 38);
            txtNombre.TabIndex = 35;
            txtNombre.TextAlign = HorizontalAlignment.Center;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(24, 83);
            label5.Name = "label5";
            label5.Size = new Size(101, 31);
            label5.TabIndex = 35;
            label5.Text = "Nombre";
            // 
            // lbId
            // 
            lbId.AutoSize = true;
            lbId.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbId.Location = new Point(250, 125);
            lbId.Name = "lbId";
            lbId.Size = new Size(0, 23);
            lbId.TabIndex = 21;
            lbId.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label4.Location = new Point(76, 22);
            label4.Name = "label4";
            label4.Size = new Size(174, 32);
            label4.TabIndex = 9;
            label4.Text = "Nueva Usuario";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1314, 114);
            panel1.TabIndex = 6;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.CornflowerBlue;
            pictureBox1.Dock = DockStyle.Right;
            pictureBox1.Image = Properties.Resources.agregar_usuario;
            pictureBox1.Location = new Point(1059, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(255, 114);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.BackColor = Color.CornflowerBlue;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(1314, 114);
            label3.TabIndex = 1;
            label3.Text = "Usuarios del Sistema";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Usuarios
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1314, 752);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Usuarios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Usuarios";
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtUsuarios).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel3;
        private DataGridView dtUsuarios;
        private Panel panel6;
        private Panel panel5;
        private Panel panel4;
        private PictureBox pictureBox2;
        private Panel panel2;
        private Label lbId;
        private Label label4;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label3;
        private TextBox txtBuscar;
        private Label label8;
        private TextBox txtPassword;
        private Label label1;
        private TextBox txtLogin;
        private Label label2;
        private TextBox txtNombre;
        private Label label5;
        private Label label6;
        private Label label9;
        private ComboBox cbRol;
        private ComboBox cbEstado;
        private Button btnActualizar;
        private Button btnRegistrar;
    }
}