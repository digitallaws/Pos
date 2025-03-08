namespace Sopromil.Vista
{
    partial class Proveedores
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
            dtProveedores = new DataGridView();
            panel6 = new Panel();
            panel5 = new Panel();
            panel4 = new Panel();
            label1 = new Label();
            txtBuscar = new TextBox();
            pictureBox2 = new PictureBox();
            panel2 = new Panel();
            lbId = new Label();
            txtCiudad = new ComboBox();
            label4 = new Label();
            label2 = new Label();
            txtDireccion = new TextBox();
            btnActualizar = new Button();
            btnCrear = new Button();
            txtTelefono = new TextBox();
            label8 = new Label();
            txtNit = new TextBox();
            label10 = new Label();
            txtNombre = new TextBox();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            lbIdProveedor = new Label();
            panel1 = new Panel();
            label3 = new Label();
            btnInventario = new Button();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtProveedores).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(dtProveedores);
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(499, 114);
            panel3.Name = "panel3";
            panel3.Size = new Size(944, 662);
            panel3.TabIndex = 5;
            // 
            // dtProveedores
            // 
            dtProveedores.AllowUserToAddRows = false;
            dtProveedores.AllowUserToDeleteRows = false;
            dtProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtProveedores.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dtProveedores.BackgroundColor = Color.White;
            dtProveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtProveedores.Dock = DockStyle.Fill;
            dtProveedores.Location = new Point(0, 117);
            dtProveedores.Name = "dtProveedores";
            dtProveedores.ReadOnly = true;
            dtProveedores.RowHeadersVisible = false;
            dtProveedores.RowHeadersWidth = 51;
            dtProveedores.Size = new Size(874, 423);
            dtProveedores.TabIndex = 6;
            // 
            // panel6
            // 
            panel6.Dock = DockStyle.Bottom;
            panel6.Location = new Point(0, 540);
            panel6.Name = "panel6";
            panel6.Size = new Size(874, 122);
            panel6.TabIndex = 5;
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Right;
            panel5.Location = new Point(874, 117);
            panel5.Name = "panel5";
            panel5.Size = new Size(70, 545);
            panel5.TabIndex = 3;
            // 
            // panel4
            // 
            panel4.Controls.Add(btnInventario);
            panel4.Controls.Add(label1);
            panel4.Controls.Add(txtBuscar);
            panel4.Controls.Add(pictureBox2);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(944, 117);
            panel4.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(68, 21);
            label1.Name = "label1";
            label1.Size = new Size(83, 31);
            label1.TabIndex = 58;
            label1.Text = "Buscar";
            // 
            // txtBuscar
            // 
            txtBuscar.BackColor = Color.White;
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;
            txtBuscar.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.Location = new Point(68, 55);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(444, 38);
            txtBuscar.TabIndex = 34;
            txtBuscar.TextAlign = HorizontalAlignment.Center;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.White;
            pictureBox2.Image = Properties.Resources.buscar;
            pictureBox2.Location = new Point(518, 55);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(44, 38);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(lbId);
            panel2.Controls.Add(txtCiudad);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(txtDireccion);
            panel2.Controls.Add(btnActualizar);
            panel2.Controls.Add(btnCrear);
            panel2.Controls.Add(txtTelefono);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(txtNit);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(txtNombre);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(lbIdProveedor);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 114);
            panel2.Name = "panel2";
            panel2.Size = new Size(499, 662);
            panel2.TabIndex = 7;
            // 
            // lbId
            // 
            lbId.AutoSize = true;
            lbId.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbId.Location = new Point(402, 94);
            lbId.Name = "lbId";
            lbId.Size = new Size(37, 31);
            lbId.TabIndex = 63;
            lbId.Text = "iD";
            // 
            // txtCiudad
            // 
            txtCiudad.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCiudad.FormattingEnabled = true;
            txtCiudad.Items.AddRange(new object[] { "AGUACHICA", "OCAÑA", "BUCARAMANGA", "SAN MARTIN", "SAN ALBERTO", "MORALES", "GAMARRA", "MEDELLIN", "BOGOTA" });
            txtCiudad.Location = new Point(27, 495);
            txtCiudad.Name = "txtCiudad";
            txtCiudad.Size = new Size(424, 39);
            txtCiudad.TabIndex = 62;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(34, 461);
            label4.Name = "label4";
            label4.Size = new Size(202, 31);
            label4.TabIndex = 61;
            label4.Text = "Ciudad (Opcional)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(34, 379);
            label2.Name = "label2";
            label2.Size = new Size(228, 31);
            label2.TabIndex = 59;
            label2.Text = "Dirección (Opcional)";
            // 
            // txtDireccion
            // 
            txtDireccion.BackColor = Color.White;
            txtDireccion.BorderStyle = BorderStyle.FixedSingle;
            txtDireccion.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDireccion.Location = new Point(27, 413);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(430, 38);
            txtDireccion.TabIndex = 58;
            txtDireccion.TextAlign = HorizontalAlignment.Center;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.CornflowerBlue;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(127, 563);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(235, 55);
            btnActualizar.TabIndex = 57;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            // 
            // btnCrear
            // 
            btnCrear.BackColor = Color.CornflowerBlue;
            btnCrear.FlatStyle = FlatStyle.Flat;
            btnCrear.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCrear.ForeColor = Color.White;
            btnCrear.Location = new Point(127, 563);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(235, 55);
            btnCrear.TabIndex = 56;
            btnCrear.Text = "Guardar";
            btnCrear.UseVisualStyleBackColor = false;
            // 
            // txtTelefono
            // 
            txtTelefono.BackColor = Color.White;
            txtTelefono.BorderStyle = BorderStyle.FixedSingle;
            txtTelefono.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTelefono.Location = new Point(27, 332);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(430, 38);
            txtTelefono.TabIndex = 51;
            txtTelefono.TextAlign = HorizontalAlignment.Center;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(27, 298);
            label8.Name = "label8";
            label8.Size = new Size(219, 31);
            label8.TabIndex = 50;
            label8.Text = "Telefono (Opcional)";
            // 
            // txtNit
            // 
            txtNit.BackColor = Color.White;
            txtNit.BorderStyle = BorderStyle.FixedSingle;
            txtNit.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNit.Location = new Point(27, 249);
            txtNit.Name = "txtNit";
            txtNit.Size = new Size(430, 38);
            txtNit.TabIndex = 49;
            txtNit.TextAlign = HorizontalAlignment.Center;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(27, 215);
            label10.Name = "label10";
            label10.Size = new Size(173, 31);
            label10.TabIndex = 48;
            label10.Text = "NIT  (Opcional)";
            // 
            // txtNombre
            // 
            txtNombre.BackColor = Color.White;
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombre.Location = new Point(27, 164);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(430, 38);
            txtNombre.TabIndex = 46;
            txtNombre.TextAlign = HorizontalAlignment.Center;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(27, 122);
            label11.Name = "label11";
            label11.Size = new Size(117, 31);
            label11.TabIndex = 47;
            label11.Text = "Nombre *";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(253, 164);
            label12.Name = "label12";
            label12.Size = new Size(0, 23);
            label12.TabIndex = 45;
            label12.Visible = false;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            label13.Location = new Point(117, 52);
            label13.Name = "label13";
            label13.Size = new Size(231, 37);
            label13.TabIndex = 44;
            label13.Text = "Nuevo Proveedor";
            // 
            // lbIdProveedor
            // 
            lbIdProveedor.AutoSize = true;
            lbIdProveedor.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbIdProveedor.Location = new Point(288, 94);
            lbIdProveedor.Name = "lbIdProveedor";
            lbIdProveedor.Size = new Size(0, 23);
            lbIdProveedor.TabIndex = 21;
            lbIdProveedor.Visible = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1443, 114);
            panel1.TabIndex = 6;
            // 
            // label3
            // 
            label3.BackColor = Color.CornflowerBlue;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(1443, 114);
            label3.TabIndex = 1;
            label3.Text = "Proveedores";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnInventario
            // 
            btnInventario.BackColor = Color.CornflowerBlue;
            btnInventario.FlatStyle = FlatStyle.Flat;
            btnInventario.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnInventario.ForeColor = Color.White;
            btnInventario.Location = new Point(799, 38);
            btnInventario.Name = "btnInventario";
            btnInventario.Size = new Size(114, 55);
            btnInventario.TabIndex = 59;
            btnInventario.Text = "Inventario";
            btnInventario.UseVisualStyleBackColor = false;
            btnInventario.Click += btnInventario_Click;
            // 
            // Proveedores
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1443, 776);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Proveedores";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Proveedores";
            WindowState = FormWindowState.Maximized;
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtProveedores).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel3;
        private DataGridView dtProveedores;
        private Panel panel6;
        private Panel panel5;
        private Panel panel4;
        private Label label1;
        private TextBox txtBuscar;
        private PictureBox pictureBox2;
        private Panel panel2;
        private Button btnActualizar;
        private Button btnCrear;
        private TextBox txtTelefono;
        private Label label8;
        private TextBox txtNit;
        private Label label10;
        private TextBox txtNombre;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label lbIdProveedor;
        private Panel panel1;
        private Label label3;
        private Label label4;
        private Label label2;
        private TextBox txtDireccion;
        private ComboBox txtCiudad;
        private Label lbId;
        private Button btnInventario;
    }
}