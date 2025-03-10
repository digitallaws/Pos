namespace Sopromil.Vista.Productos
{
    partial class FrmProductos
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
            dtCompra = new DataGridView();
            panel6 = new Panel();
            lblFlete = new Label();
            lblUtilidad = new Label();
            lblVenta = new Label();
            label12 = new Label();
            label18 = new Label();
            label16 = new Label();
            lblCompra = new Label();
            label14 = new Label();
            panel2 = new Panel();
            panel5 = new Panel();
            btnRegistrar = new Button();
            btnAgregar = new Button();
            panel4 = new Panel();
            lblPrecioVenta = new Label();
            btnLimpiar = new Button();
            lbPrecioCompraAnterior = new Label();
            lbIdProducto = new Label();
            txtNombre = new TextBox();
            lstResultados = new ListBox();
            txtCodigo = new ComboBox();
            lbId = new Label();
            txtVenta = new TextBox();
            label13 = new Label();
            txtUtilidad = new TextBox();
            label9 = new Label();
            txtFlete = new TextBox();
            label7 = new Label();
            txtCompra = new TextBox();
            label6 = new Label();
            label5 = new Label();
            txtFecha = new DateTimePicker();
            label1 = new Label();
            txtUnMedida = new ComboBox();
            txtProveedor = new TextBox();
            label4 = new Label();
            dd = new Label();
            txtCantidad = new TextBox();
            label2 = new Label();
            txtMarca = new TextBox();
            label10 = new Label();
            label8 = new Label();
            panel1 = new Panel();
            btnVolver = new Button();
            label3 = new Label();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtCompra).BeginInit();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(dtCompra);
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(panel2);
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 114);
            panel3.Name = "panel3";
            panel3.Size = new Size(1655, 773);
            panel3.TabIndex = 8;
            // 
            // dtCompra
            // 
            dtCompra.AllowUserToAddRows = false;
            dtCompra.AllowUserToDeleteRows = false;
            dtCompra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtCompra.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dtCompra.BackgroundColor = Color.White;
            dtCompra.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtCompra.Dock = DockStyle.Fill;
            dtCompra.Location = new Point(174, 238);
            dtCompra.Name = "dtCompra";
            dtCompra.ReadOnly = true;
            dtCompra.RowHeadersVisible = false;
            dtCompra.RowHeadersWidth = 51;
            dtCompra.Size = new Size(1270, 378);
            dtCompra.TabIndex = 9;
            // 
            // panel6
            // 
            panel6.Controls.Add(lblFlete);
            panel6.Controls.Add(lblUtilidad);
            panel6.Controls.Add(lblVenta);
            panel6.Controls.Add(label12);
            panel6.Controls.Add(label18);
            panel6.Controls.Add(label16);
            panel6.Controls.Add(lblCompra);
            panel6.Controls.Add(label14);
            panel6.Dock = DockStyle.Bottom;
            panel6.Location = new Point(174, 616);
            panel6.Name = "panel6";
            panel6.Size = new Size(1270, 157);
            panel6.TabIndex = 8;
            // 
            // lblFlete
            // 
            lblFlete.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lblFlete.AutoSize = true;
            lblFlete.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFlete.Location = new Point(792, 60);
            lblFlete.Name = "lblFlete";
            lblFlete.Size = new Size(45, 29);
            lblFlete.TabIndex = 83;
            lblFlete.Text = "$ 0";
            // 
            // lblUtilidad
            // 
            lblUtilidad.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lblUtilidad.AutoSize = true;
            lblUtilidad.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUtilidad.Location = new Point(1102, 112);
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
            lblVenta.Location = new Point(1104, 72);
            lblVenta.Name = "lblVenta";
            lblVenta.Size = new Size(45, 29);
            lblVenta.TabIndex = 80;
            lblVenta.Text = "$ 0";
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(752, 29);
            label12.Name = "label12";
            label12.Size = new Size(127, 31);
            label12.TabIndex = 82;
            label12.Text = "Flete Total:";
            // 
            // label18
            // 
            label18.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label18.Location = new Point(938, 110);
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
            label16.Location = new Point(938, 70);
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
            lblCompra.Location = new Point(1104, 29);
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
            label14.Location = new Point(938, 29);
            label14.Name = "label14";
            label14.Size = new Size(160, 31);
            label14.TabIndex = 75;
            label14.Text = "Total Compra:";
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 238);
            panel2.Name = "panel2";
            panel2.Size = new Size(174, 535);
            panel2.TabIndex = 7;
            // 
            // panel5
            // 
            panel5.Controls.Add(btnRegistrar);
            panel5.Controls.Add(btnAgregar);
            panel5.Dock = DockStyle.Right;
            panel5.Location = new Point(1444, 238);
            panel5.Name = "panel5";
            panel5.Size = new Size(211, 535);
            panel5.TabIndex = 3;
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = Color.LightSeaGreen;
            btnRegistrar.FlatStyle = FlatStyle.Flat;
            btnRegistrar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRegistrar.ForeColor = Color.White;
            btnRegistrar.Location = new Point(20, 382);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(166, 122);
            btnRegistrar.TabIndex = 82;
            btnRegistrar.Text = "Finalizar Registro";
            btnRegistrar.UseVisualStyleBackColor = false;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.CornflowerBlue;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(30, 21);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(154, 55);
            btnAgregar.TabIndex = 56;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            panel4.Controls.Add(lblPrecioVenta);
            panel4.Controls.Add(btnLimpiar);
            panel4.Controls.Add(lbPrecioCompraAnterior);
            panel4.Controls.Add(lbIdProducto);
            panel4.Controls.Add(txtNombre);
            panel4.Controls.Add(lstResultados);
            panel4.Controls.Add(txtCodigo);
            panel4.Controls.Add(lbId);
            panel4.Controls.Add(txtVenta);
            panel4.Controls.Add(label13);
            panel4.Controls.Add(txtUtilidad);
            panel4.Controls.Add(label9);
            panel4.Controls.Add(txtFlete);
            panel4.Controls.Add(label7);
            panel4.Controls.Add(txtCompra);
            panel4.Controls.Add(label6);
            panel4.Controls.Add(label5);
            panel4.Controls.Add(txtFecha);
            panel4.Controls.Add(label1);
            panel4.Controls.Add(txtUnMedida);
            panel4.Controls.Add(txtProveedor);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(dd);
            panel4.Controls.Add(txtCantidad);
            panel4.Controls.Add(label2);
            panel4.Controls.Add(txtMarca);
            panel4.Controls.Add(label10);
            panel4.Controls.Add(label8);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(1655, 238);
            panel4.TabIndex = 1;
            // 
            // lblPrecioVenta
            // 
            lblPrecioVenta.AutoSize = true;
            lblPrecioVenta.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrecioVenta.Location = new Point(1274, 95);
            lblPrecioVenta.Name = "lblPrecioVenta";
            lblPrecioVenta.Size = new Size(37, 31);
            lblPrecioVenta.TabIndex = 83;
            lblPrecioVenta.Text = "iD";
            lblPrecioVenta.Visible = false;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.CornflowerBlue;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(1541, 41);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(89, 51);
            btnLimpiar.TabIndex = 82;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // lbPrecioCompraAnterior
            // 
            lbPrecioCompraAnterior.AutoSize = true;
            lbPrecioCompraAnterior.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbPrecioCompraAnterior.Location = new Point(515, 20);
            lbPrecioCompraAnterior.Name = "lbPrecioCompraAnterior";
            lbPrecioCompraAnterior.Size = new Size(37, 31);
            lbPrecioCompraAnterior.TabIndex = 81;
            lbPrecioCompraAnterior.Text = "iD";
            lbPrecioCompraAnterior.Visible = false;
            // 
            // lbIdProducto
            // 
            lbIdProducto.AutoSize = true;
            lbIdProducto.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbIdProducto.Location = new Point(718, 20);
            lbIdProducto.Name = "lbIdProducto";
            lbIdProducto.Size = new Size(37, 31);
            lbIdProducto.TabIndex = 80;
            lbIdProducto.Text = "iD";
            lbIdProducto.Visible = false;
            // 
            // txtNombre
            // 
            txtNombre.BackColor = Color.White;
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombre.Location = new Point(343, 54);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(425, 38);
            txtNombre.TabIndex = 79;
            txtNombre.TextAlign = HorizontalAlignment.Center;
            // 
            // lstResultados
            // 
            lstResultados.FormattingEnabled = true;
            lstResultados.Location = new Point(343, 89);
            lstResultados.Name = "lstResultados";
            lstResultados.Size = new Size(425, 144);
            lstResultados.TabIndex = 78;
            // 
            // txtCodigo
            // 
            txtCodigo.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCodigo.FormattingEnabled = true;
            txtCodigo.Location = new Point(1260, 52);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(250, 39);
            txtCodigo.TabIndex = 77;
            // 
            // lbId
            // 
            lbId.AutoSize = true;
            lbId.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbId.Location = new Point(288, 20);
            lbId.Name = "lbId";
            lbId.Size = new Size(37, 31);
            lbId.TabIndex = 75;
            lbId.Text = "iD";
            lbId.Visible = false;
            // 
            // txtVenta
            // 
            txtVenta.BackColor = Color.White;
            txtVenta.BorderStyle = BorderStyle.FixedSingle;
            txtVenta.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtVenta.Location = new Point(1274, 160);
            txtVenta.Name = "txtVenta";
            txtVenta.ReadOnly = true;
            txtVenta.Size = new Size(169, 38);
            txtVenta.TabIndex = 73;
            txtVenta.TextAlign = HorizontalAlignment.Center;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(1274, 126);
            label13.Name = "label13";
            label13.Size = new Size(144, 31);
            label13.TabIndex = 74;
            label13.Text = "Precio Venta";
            // 
            // txtUtilidad
            // 
            txtUtilidad.BackColor = Color.White;
            txtUtilidad.BorderStyle = BorderStyle.FixedSingle;
            txtUtilidad.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUtilidad.Location = new Point(1064, 160);
            txtUtilidad.Name = "txtUtilidad";
            txtUtilidad.Size = new Size(169, 38);
            txtUtilidad.TabIndex = 71;
            txtUtilidad.TextAlign = HorizontalAlignment.Center;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(1064, 126);
            label9.Name = "label9";
            label9.Size = new Size(96, 31);
            label9.TabIndex = 72;
            label9.Text = "Utilidad";
            // 
            // txtFlete
            // 
            txtFlete.BackColor = Color.White;
            txtFlete.BorderStyle = BorderStyle.FixedSingle;
            txtFlete.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFlete.Location = new Point(862, 160);
            txtFlete.Name = "txtFlete";
            txtFlete.Size = new Size(169, 38);
            txtFlete.TabIndex = 69;
            txtFlete.TextAlign = HorizontalAlignment.Center;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(862, 126);
            label7.Name = "label7";
            label7.Size = new Size(64, 31);
            label7.TabIndex = 70;
            label7.Text = "Flete";
            // 
            // txtCompra
            // 
            txtCompra.BackColor = Color.White;
            txtCompra.BorderStyle = BorderStyle.FixedSingle;
            txtCompra.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCompra.Location = new Point(658, 160);
            txtCompra.Name = "txtCompra";
            txtCompra.Size = new Size(169, 38);
            txtCompra.TabIndex = 67;
            txtCompra.TextAlign = HorizontalAlignment.Center;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(658, 126);
            label6.Name = "label6";
            label6.Size = new Size(157, 31);
            label6.TabIndex = 68;
            label6.Text = "Valor Compra";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(58, 126);
            label5.Name = "label5";
            label5.Size = new Size(241, 31);
            label5.TabIndex = 66;
            label5.Text = "Fecha de Vencimiento";
            // 
            // txtFecha
            // 
            txtFecha.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFecha.Location = new Point(57, 160);
            txtFecha.Name = "txtFecha";
            txtFecha.Size = new Size(403, 38);
            txtFecha.TabIndex = 65;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(57, 20);
            label1.Name = "label1";
            label1.Size = new Size(123, 31);
            label1.TabIndex = 64;
            label1.Text = "Proveedor";
            // 
            // txtUnMedida
            // 
            txtUnMedida.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUnMedida.FormattingEnabled = true;
            txtUnMedida.Items.AddRange(new object[] { "UNIDAD", "LITRO", "MILILITRO", "GALÓN", "KILO", "GRAMO", "QUINTAL", "BULTO", "SACO", "METRO", "METRO CUADRADO", "METRO CÚBICO", "CENTÍMETRO", "PULGADA", "PIE", "ROLLO", "PAQUETE", "CAJA", "DOCENA", "PAR", "SOBRE", "TIRA", "BOTELLA", "CUBETA", "TANQUE", "ENVASE", "BIDÓN", "TARRO", "BARRIL", "LATA", "MAZO", "KILÓMETRO", "TONELADA" });
            txtUnMedida.Location = new Point(1028, 52);
            txtUnMedida.Name = "txtUnMedida";
            txtUnMedida.Size = new Size(205, 39);
            txtUnMedida.TabIndex = 62;
            // 
            // txtProveedor
            // 
            txtProveedor.BackColor = Color.White;
            txtProveedor.BorderStyle = BorderStyle.FixedSingle;
            txtProveedor.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtProveedor.Location = new Point(57, 54);
            txtProveedor.Name = "txtProveedor";
            txtProveedor.Size = new Size(268, 38);
            txtProveedor.TabIndex = 46;
            txtProveedor.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(1028, 18);
            label4.Name = "label4";
            label4.Size = new Size(205, 31);
            label4.TabIndex = 61;
            label4.Text = "Unidad de medida";
            // 
            // dd
            // 
            dd.AutoSize = true;
            dd.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dd.Location = new Point(343, 20);
            dd.Name = "dd";
            dd.Size = new Size(117, 31);
            dd.TabIndex = 47;
            dd.Text = "Nombre *";
            // 
            // txtCantidad
            // 
            txtCantidad.BackColor = Color.White;
            txtCantidad.BorderStyle = BorderStyle.FixedSingle;
            txtCantidad.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCantidad.Location = new Point(500, 160);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(127, 38);
            txtCantidad.TabIndex = 58;
            txtCantidad.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(500, 126);
            label2.Name = "label2";
            label2.Size = new Size(107, 31);
            label2.TabIndex = 59;
            label2.Text = "Cantidad";
            // 
            // txtMarca
            // 
            txtMarca.BackColor = Color.White;
            txtMarca.BorderStyle = BorderStyle.FixedSingle;
            txtMarca.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMarca.Location = new Point(787, 53);
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(224, 38);
            txtMarca.TabIndex = 49;
            txtMarca.TextAlign = HorizontalAlignment.Center;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(787, 19);
            label10.Name = "label10";
            label10.Size = new Size(79, 31);
            label10.TabIndex = 48;
            label10.Text = "Marca";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(1260, 18);
            label8.Name = "label8";
            label8.Size = new Size(205, 31);
            label8.TabIndex = 50;
            label8.Text = "Codigo (Opcional)";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnVolver);
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1655, 114);
            panel1.TabIndex = 9;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(58, 40);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(97, 49);
            btnVolver.TabIndex = 7;
            btnVolver.Text = "Atras";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // label3
            // 
            label3.BackColor = Color.CornflowerBlue;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(1655, 114);
            label3.TabIndex = 1;
            label3.Text = "Registrar Productos";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmProductos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1655, 887);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Name = "FrmProductos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmProductos";
            WindowState = FormWindowState.Maximized;
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtCompra).EndInit();
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
        private Panel panel5;
        private Panel panel4;
        private ComboBox txtUnMedida;
        private Label label4;
        private Label label2;
        private TextBox txtCantidad;
        private Button btnAgregar;
        private Label label8;
        private TextBox txtMarca;
        private Label label10;
        private TextBox txtProveedor;
        private Label dd;
        private Panel panel1;
        private Label label3;
        private Label label1;
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
        private Button btnRegistrar;
        private DataGridView dtCompra;
        private Panel panel6;
        private Label lblUtilidad;
        private Label lblVenta;
        private Label label18;
        private Label label16;
        private Label lblCompra;
        private Label label14;
        private Panel panel2;
        private Label lbId;
        private ComboBox txtCodigo;
        private Label label12;
        private Label lblFlete;
        private ListBox lstResultados;
        private TextBox txtNombre;
        private Label lbIdProducto;
        private Label lbPrecioCompraAnterior;
        private Button btnLimpiar;
        private Label lblPrecioVenta;
        private Button btnVolver;
    }
}