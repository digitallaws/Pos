namespace Sopromil.Vista.Inventario
{
    partial class FrmInventario
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
            dtInventario = new DataGridView();
            panel6 = new Panel();
            lblUtilidad = new Label();
            lblVenta = new Label();
            label18 = new Label();
            label16 = new Label();
            lblCompra = new Label();
            label14 = new Label();
            panel2 = new Panel();
            panel5 = new Panel();
            btnProductos = new Button();
            lblTotalInventario = new Label();
            label12 = new Label();
            panel4 = new Panel();
            label1 = new Label();
            cbProveedores = new ComboBox();
            txtBuscar = new TextBox();
            dd = new Label();
            panel1 = new Panel();
            label3 = new Label();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtInventario).BeginInit();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(dtInventario);
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(panel2);
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 114);
            panel3.Name = "panel3";
            panel3.Size = new Size(1576, 774);
            panel3.TabIndex = 10;
            // 
            // dtInventario
            // 
            dtInventario.AllowUserToAddRows = false;
            dtInventario.AllowUserToDeleteRows = false;
            dtInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtInventario.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dtInventario.BackgroundColor = Color.White;
            dtInventario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtInventario.Dock = DockStyle.Fill;
            dtInventario.Location = new Point(174, 150);
            dtInventario.Name = "dtInventario";
            dtInventario.ReadOnly = true;
            dtInventario.RowHeadersVisible = false;
            dtInventario.RowHeadersWidth = 51;
            dtInventario.Size = new Size(1143, 555);
            dtInventario.TabIndex = 9;
            // 
            // panel6
            // 
            panel6.Controls.Add(lblUtilidad);
            panel6.Controls.Add(lblVenta);
            panel6.Controls.Add(label18);
            panel6.Controls.Add(label16);
            panel6.Controls.Add(lblCompra);
            panel6.Controls.Add(label14);
            panel6.Dock = DockStyle.Bottom;
            panel6.Location = new Point(174, 705);
            panel6.Name = "panel6";
            panel6.Size = new Size(1143, 69);
            panel6.TabIndex = 8;
            // 
            // lblUtilidad
            // 
            lblUtilidad.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lblUtilidad.AutoSize = true;
            lblUtilidad.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUtilidad.Location = new Point(1980, 112);
            lblUtilidad.Name = "lblUtilidad";
            lblUtilidad.Size = new Size(45, 29);
            lblUtilidad.TabIndex = 81;
            lblUtilidad.Text = "$ 0";
            // 
            // lblVenta
            // 
            lblVenta.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lblVenta.AutoSize = true;
            lblVenta.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVenta.Location = new Point(1982, 72);
            lblVenta.Name = "lblVenta";
            lblVenta.Size = new Size(45, 29);
            lblVenta.TabIndex = 80;
            lblVenta.Text = "$ 0";
            // 
            // label18
            // 
            label18.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label18.Location = new Point(1816, 110);
            label18.Name = "label18";
            label18.Size = new Size(158, 31);
            label18.TabIndex = 79;
            label18.Text = "Utilidad Neta:";
            // 
            // label16
            // 
            label16.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.Location = new Point(1816, 70);
            label16.Name = "label16";
            label16.Size = new Size(136, 31);
            label16.TabIndex = 77;
            label16.Text = "Total Venta:";
            // 
            // lblCompra
            // 
            lblCompra.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lblCompra.AutoSize = true;
            lblCompra.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCompra.Location = new Point(1982, 29);
            lblCompra.Name = "lblCompra";
            lblCompra.Size = new Size(45, 29);
            lblCompra.TabIndex = 76;
            lblCompra.Text = "$ 0";
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.Location = new Point(1816, 29);
            label14.Name = "label14";
            label14.Size = new Size(160, 31);
            label14.TabIndex = 75;
            label14.Text = "Total Compra:";
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 150);
            panel2.Name = "panel2";
            panel2.Size = new Size(174, 624);
            panel2.TabIndex = 7;
            // 
            // panel5
            // 
            panel5.Controls.Add(btnProductos);
            panel5.Controls.Add(lblTotalInventario);
            panel5.Controls.Add(label12);
            panel5.Dock = DockStyle.Right;
            panel5.Location = new Point(1317, 150);
            panel5.Name = "panel5";
            panel5.Size = new Size(259, 624);
            panel5.TabIndex = 3;
            // 
            // btnProductos
            // 
            btnProductos.BackColor = Color.CornflowerBlue;
            btnProductos.FlatStyle = FlatStyle.Flat;
            btnProductos.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnProductos.ForeColor = Color.White;
            btnProductos.Location = new Point(12, 16);
            btnProductos.Name = "btnProductos";
            btnProductos.Size = new Size(235, 55);
            btnProductos.TabIndex = 85;
            btnProductos.Text = "Agregar Producto";
            btnProductos.UseVisualStyleBackColor = false;
            btnProductos.Click += btnProductos_Click;
            // 
            // lblTotalInventario
            // 
            lblTotalInventario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lblTotalInventario.AutoSize = true;
            lblTotalInventario.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalInventario.Location = new Point(35, 153);
            lblTotalInventario.Name = "lblTotalInventario";
            lblTotalInventario.Size = new Size(45, 29);
            lblTotalInventario.TabIndex = 84;
            lblTotalInventario.Text = "$ 0";
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(17, 113);
            label12.Name = "label12";
            label12.Size = new Size(223, 31);
            label12.TabIndex = 82;
            label12.Text = "Activo en Inventario";
            // 
            // panel4
            // 
            panel4.Controls.Add(label1);
            panel4.Controls.Add(cbProveedores);
            panel4.Controls.Add(txtBuscar);
            panel4.Controls.Add(dd);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(1576, 150);
            panel4.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(819, 45);
            label1.Name = "label1";
            label1.Size = new Size(123, 31);
            label1.TabIndex = 81;
            label1.Text = "Proveedor";
            // 
            // cbProveedores
            // 
            cbProveedores.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbProveedores.FormattingEnabled = true;
            cbProveedores.Location = new Point(819, 79);
            cbProveedores.Name = "cbProveedores";
            cbProveedores.Size = new Size(415, 39);
            cbProveedores.TabIndex = 80;
            // 
            // txtBuscar
            // 
            txtBuscar.BackColor = Color.White;
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;
            txtBuscar.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.Location = new Point(174, 80);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(587, 38);
            txtBuscar.TabIndex = 79;
            txtBuscar.TextAlign = HorizontalAlignment.Center;
            // 
            // dd
            // 
            dd.AutoSize = true;
            dd.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dd.Location = new Point(174, 46);
            dd.Name = "dd";
            dd.Size = new Size(83, 31);
            dd.TabIndex = 47;
            dd.Text = "Buscar";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1576, 114);
            panel1.TabIndex = 11;
            // 
            // label3
            // 
            label3.BackColor = Color.CornflowerBlue;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(1576, 114);
            label3.TabIndex = 1;
            label3.Text = "Inventario";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmInventario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1576, 888);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Name = "FrmInventario";
            Text = "FrmInventario";
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtInventario).EndInit();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel3;
        private DataGridView dtInventario;
        private Panel panel6;
        private Label lblUtilidad;
        private Label lblVenta;
        private Label label18;
        private Label label16;
        private Label lblCompra;
        private Label label14;
        private Panel panel2;
        private Panel panel5;
        private Label lblTotalInventario;
        private Label label15;
        private Label label12;
        private Button btnRegistrar;
        private TextBox txtGeneral;
        private Button btnAgregar;
        private Panel panel4;
        private TextBox txtBuscar;
        private ComboBox txtCodigo;
        private Label lbId;
        private TextBox txtVenta;
        private Label label13;
        private TextBox txtUtilidad;
        private Label label9;
        private TextBox txtFlete;
        private Label label7;
        private TextBox txtCompra;
        private Label label6;
        private Label label5;
        private DateTimePicker txtFecha;
        private Label label1;
        private ComboBox cbProveedores;
        private TextBox txtProveedor;
        private Label label4;
        private Label dd;
        private TextBox txtCantidad;
        private Label label2;
        private TextBox txtMarca;
        private Label label10;
        private Label label8;
        private Panel panel1;
        private Label label3;
        private Button btnProductos;
    }
}