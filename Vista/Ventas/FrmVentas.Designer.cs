namespace Sopromil.Vista.Ventas
{
    partial class FrmVentas
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
            dtVentas = new DataGridView();
            panel6 = new Panel();
            lblTotal = new Label();
            label11 = new Label();
            lblUtilidad = new Label();
            lblVenta = new Label();
            label18 = new Label();
            label16 = new Label();
            lblCompra = new Label();
            label14 = new Label();
            panel2 = new Panel();
            panel5 = new Panel();
            btnFacturar = new Button();
            btnAgregar = new Button();
            panel4 = new Panel();
            cbBuscarCliente = new ComboBox();
            btnCrearCliente = new Button();
            cbBuscarProducto = new ComboBox();
            lblStock = new Label();
            label4 = new Label();
            txtTelefono = new TextBox();
            label2 = new Label();
            txtDocumento = new TextBox();
            lbCliente = new Label();
            label1 = new Label();
            lbIdProducto = new Label();
            dd = new Label();
            panel1 = new Panel();
            label3 = new Label();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtVentas).BeginInit();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(dtVentas);
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(panel2);
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 114);
            panel3.Name = "panel3";
            panel3.Size = new Size(1674, 936);
            panel3.TabIndex = 10;
            // 
            // dtVentas
            // 
            dtVentas.AllowUserToAddRows = false;
            dtVentas.AllowUserToDeleteRows = false;
            dtVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtVentas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dtVentas.BackgroundColor = Color.White;
            dtVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtVentas.Dock = DockStyle.Fill;
            dtVentas.Location = new Point(174, 365);
            dtVentas.Name = "dtVentas";
            dtVentas.ReadOnly = true;
            dtVentas.RowHeadersVisible = false;
            dtVentas.RowHeadersWidth = 51;
            dtVentas.Size = new Size(1289, 329);
            dtVentas.TabIndex = 9;
            // 
            // panel6
            // 
            panel6.Controls.Add(lblTotal);
            panel6.Controls.Add(label11);
            panel6.Controls.Add(lblUtilidad);
            panel6.Controls.Add(lblVenta);
            panel6.Controls.Add(label18);
            panel6.Controls.Add(label16);
            panel6.Controls.Add(lblCompra);
            panel6.Controls.Add(label14);
            panel6.Dock = DockStyle.Bottom;
            panel6.Location = new Point(174, 694);
            panel6.Name = "panel6";
            panel6.Size = new Size(1289, 242);
            panel6.TabIndex = 8;
            // 
            // lblTotal
            // 
            lblTotal.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(1083, 47);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(45, 29);
            lblTotal.TabIndex = 83;
            lblTotal.Text = "$ 0";
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(917, 47);
            label11.Name = "label11";
            label11.Size = new Size(160, 31);
            label11.TabIndex = 82;
            label11.Text = "Total Compra:";
            // 
            // lblUtilidad
            // 
            lblUtilidad.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lblUtilidad.AutoSize = true;
            lblUtilidad.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUtilidad.Location = new Point(2126, 112);
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
            lblVenta.Location = new Point(2128, 72);
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
            label18.Location = new Point(1962, 110);
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
            label16.Location = new Point(1962, 70);
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
            lblCompra.Location = new Point(2128, 29);
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
            label14.Location = new Point(1962, 29);
            label14.Name = "label14";
            label14.Size = new Size(160, 31);
            label14.TabIndex = 75;
            label14.Text = "Total Compra:";
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 365);
            panel2.Name = "panel2";
            panel2.Size = new Size(174, 571);
            panel2.TabIndex = 7;
            // 
            // panel5
            // 
            panel5.Controls.Add(btnFacturar);
            panel5.Controls.Add(btnAgregar);
            panel5.Dock = DockStyle.Right;
            panel5.Location = new Point(1463, 365);
            panel5.Name = "panel5";
            panel5.Size = new Size(211, 571);
            panel5.TabIndex = 3;
            // 
            // btnFacturar
            // 
            btnFacturar.BackColor = Color.LightSeaGreen;
            btnFacturar.FlatStyle = FlatStyle.Flat;
            btnFacturar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnFacturar.ForeColor = Color.White;
            btnFacturar.Location = new Point(20, 340);
            btnFacturar.Name = "btnFacturar";
            btnFacturar.Size = new Size(166, 122);
            btnFacturar.TabIndex = 82;
            btnFacturar.Text = "Facturar";
            btnFacturar.UseVisualStyleBackColor = false;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.CornflowerBlue;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(32, 30);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(154, 55);
            btnAgregar.TabIndex = 56;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            panel4.Controls.Add(cbBuscarCliente);
            panel4.Controls.Add(btnCrearCliente);
            panel4.Controls.Add(cbBuscarProducto);
            panel4.Controls.Add(lblStock);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(txtTelefono);
            panel4.Controls.Add(label2);
            panel4.Controls.Add(txtDocumento);
            panel4.Controls.Add(lbCliente);
            panel4.Controls.Add(label1);
            panel4.Controls.Add(lbIdProducto);
            panel4.Controls.Add(dd);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(1674, 365);
            panel4.TabIndex = 1;
            // 
            // cbBuscarCliente
            // 
            cbBuscarCliente.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbBuscarCliente.FormattingEnabled = true;
            cbBuscarCliente.Location = new Point(26, 53);
            cbBuscarCliente.Name = "cbBuscarCliente";
            cbBuscarCliente.Size = new Size(425, 39);
            cbBuscarCliente.TabIndex = 92;
            // 
            // btnCrearCliente
            // 
            btnCrearCliente.BackColor = Color.CornflowerBlue;
            btnCrearCliente.FlatStyle = FlatStyle.Flat;
            btnCrearCliente.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCrearCliente.ForeColor = Color.White;
            btnCrearCliente.Location = new Point(457, 52);
            btnCrearCliente.Name = "btnCrearCliente";
            btnCrearCliente.Size = new Size(44, 40);
            btnCrearCliente.TabIndex = 93;
            btnCrearCliente.Text = "+";
            btnCrearCliente.UseVisualStyleBackColor = false;
            // 
            // cbBuscarProducto
            // 
            cbBuscarProducto.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbBuscarProducto.FormattingEnabled = true;
            cbBuscarProducto.Location = new Point(527, 53);
            cbBuscarProducto.Name = "cbBuscarProducto";
            cbBuscarProducto.Size = new Size(425, 39);
            cbBuscarProducto.TabIndex = 91;
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStock.Location = new Point(527, 107);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(27, 31);
            lblStock.TabIndex = 90;
            lblStock.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(26, 197);
            label4.Name = "label4";
            label4.Size = new Size(101, 31);
            label4.TabIndex = 88;
            label4.Text = "telefono";
            // 
            // txtTelefono
            // 
            txtTelefono.BackColor = Color.White;
            txtTelefono.BorderStyle = BorderStyle.FixedSingle;
            txtTelefono.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTelefono.Location = new Point(26, 236);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(425, 38);
            txtTelefono.TabIndex = 87;
            txtTelefono.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(26, 107);
            label2.Name = "label2";
            label2.Size = new Size(136, 31);
            label2.TabIndex = 86;
            label2.Text = "Documento";
            // 
            // txtDocumento
            // 
            txtDocumento.BackColor = Color.White;
            txtDocumento.BorderStyle = BorderStyle.FixedSingle;
            txtDocumento.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDocumento.Location = new Point(26, 141);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(425, 38);
            txtDocumento.TabIndex = 85;
            txtDocumento.TextAlign = HorizontalAlignment.Center;
            // 
            // lbCliente
            // 
            lbCliente.AutoSize = true;
            lbCliente.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbCliente.Location = new Point(405, 19);
            lbCliente.Name = "lbCliente";
            lbCliente.Size = new Size(37, 31);
            lbCliente.TabIndex = 83;
            lbCliente.Text = "iD";
            lbCliente.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(542, 18);
            label1.Name = "label1";
            label1.Size = new Size(201, 31);
            label1.TabIndex = 82;
            label1.Text = "Buscar Producto *";
            // 
            // lbIdProducto
            // 
            lbIdProducto.AutoSize = true;
            lbIdProducto.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbIdProducto.Location = new Point(902, 19);
            lbIdProducto.Name = "lbIdProducto";
            lbIdProducto.Size = new Size(37, 31);
            lbIdProducto.TabIndex = 80;
            lbIdProducto.Text = "iD";
            lbIdProducto.Visible = false;
            // 
            // dd
            // 
            dd.AutoSize = true;
            dd.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dd.Location = new Point(36, 19);
            dd.Name = "dd";
            dd.Size = new Size(101, 31);
            dd.TabIndex = 47;
            dd.Text = "Cliente *";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1674, 114);
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
            label3.Size = new Size(1674, 114);
            label3.TabIndex = 1;
            label3.Text = "Registrar Venta";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmVentas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1674, 1050);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Name = "FrmVentas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmVentas";
            WindowState = FormWindowState.Maximized;
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtVentas).EndInit();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel3;
        private DataGridView dtVentas;
        private Panel panel6;
        private Label lblUtilidad;
        private Label lblVenta;
        private Label label18;
        private Label label16;
        private Label lblCompra;
        private Label label14;
        private Panel panel2;
        private Panel panel5;
        private Button btnFacturar;
        private Button btnAgregar;
        private Panel panel4;
        private Label lbIdProducto;
        private Label dd;
        private Panel panel1;
        private Label label3;
        private Label label1;
        private Label lbCliente;
        private Label label4;
        private TextBox txtTelefono;
        private Label label2;
        private TextBox txtDocumento;
        private Label lblStock;
        private ComboBox cbBuscarProducto;
        private ComboBox cbBuscarCliente;
        private Button btnCrearCliente;
        private Label lblTotal;
        private Label label11;
    }
}