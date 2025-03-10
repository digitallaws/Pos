namespace Sopromil.Vista.Clientes
{
    partial class FrmClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClientes));
            panel3 = new Panel();
            dtClientes = new DataGridView();
            panel6 = new Panel();
            panel5 = new Panel();
            panel4 = new Panel();
            label1 = new Label();
            txtBuscar = new TextBox();
            pictureBox2 = new PictureBox();
            panel2 = new Panel();
            lbId = new Label();
            btnActualizar = new Button();
            btnGuardar = new Button();
            txtTelefono = new TextBox();
            label8 = new Label();
            txtDocumento = new TextBox();
            label10 = new Label();
            txtNombre = new TextBox();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            lbIdProveedor = new Label();
            panel1 = new Panel();
            label3 = new Label();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtClientes).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(dtClientes);
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(499, 114);
            panel3.Name = "panel3";
            panel3.Size = new Size(984, 709);
            panel3.TabIndex = 8;
            // 
            // dtClientes
            // 
            dtClientes.AllowUserToAddRows = false;
            dtClientes.AllowUserToDeleteRows = false;
            dtClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtClientes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dtClientes.BackgroundColor = Color.White;
            dtClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtClientes.Dock = DockStyle.Fill;
            dtClientes.Location = new Point(0, 117);
            dtClientes.Name = "dtClientes";
            dtClientes.ReadOnly = true;
            dtClientes.RowHeadersVisible = false;
            dtClientes.RowHeadersWidth = 51;
            dtClientes.Size = new Size(914, 470);
            dtClientes.TabIndex = 6;
            // 
            // panel6
            // 
            panel6.Dock = DockStyle.Bottom;
            panel6.Location = new Point(0, 587);
            panel6.Name = "panel6";
            panel6.Size = new Size(914, 122);
            panel6.TabIndex = 5;
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Right;
            panel5.Location = new Point(914, 117);
            panel5.Name = "panel5";
            panel5.Size = new Size(70, 592);
            panel5.TabIndex = 3;
            // 
            // panel4
            // 
            panel4.Controls.Add(label1);
            panel4.Controls.Add(txtBuscar);
            panel4.Controls.Add(pictureBox2);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(984, 117);
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
            panel2.Controls.Add(btnActualizar);
            panel2.Controls.Add(btnGuardar);
            panel2.Controls.Add(txtTelefono);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(txtDocumento);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(txtNombre);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(lbIdProveedor);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 114);
            panel2.Name = "panel2";
            panel2.Size = new Size(499, 709);
            panel2.TabIndex = 10;
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
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.CornflowerBlue;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(139, 428);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(235, 55);
            btnActualizar.TabIndex = 57;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.CornflowerBlue;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(139, 500);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(235, 55);
            btnGuardar.TabIndex = 56;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
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
            // txtDocumento
            // 
            txtDocumento.BackColor = Color.White;
            txtDocumento.BorderStyle = BorderStyle.FixedSingle;
            txtDocumento.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDocumento.Location = new Point(27, 249);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(430, 38);
            txtDocumento.TabIndex = 49;
            txtDocumento.TextAlign = HorizontalAlignment.Center;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(27, 215);
            label10.Name = "label10";
            label10.Size = new Size(251, 31);
            label10.TabIndex = 48;
            label10.Text = "Documento (Opcional)";
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
            label13.Size = new Size(190, 37);
            label13.TabIndex = 44;
            label13.Text = "Nuevo Cliente";
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
            panel1.Size = new Size(1483, 114);
            panel1.TabIndex = 9;
            // 
            // label3
            // 
            label3.BackColor = Color.CornflowerBlue;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(1483, 114);
            label3.TabIndex = 1;
            label3.Text = "Clientes";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmClientes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1483, 823);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmClientes";
            Text = "FrmClientes";
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtClientes).EndInit();
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
        private DataGridView dtClientes;
        private Panel panel6;
        private Panel panel5;
        private Panel panel4;
        private Label label1;
        private TextBox txtBuscar;
        private PictureBox pictureBox2;
        private Panel panel2;
        private Label lbId;
        private Button btnActualizar;
        private Button btnGuardar;
        private TextBox txtTelefono;
        private Label label8;
        private TextBox txtDocumento;
        private Label label10;
        private TextBox txtNombre;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label lbIdProveedor;
        private Panel panel1;
        private Label label3;
    }
}