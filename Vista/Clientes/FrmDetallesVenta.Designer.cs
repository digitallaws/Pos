namespace Sopromil.Vista.Clientes
{
    partial class FrmDetallesVenta
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
            dtDetalles = new DataGridView();
            fg = new Panel();
            lblTotalFactura = new Label();
            panel5 = new Panel();
            panel4 = new Panel();
            txtCliente = new Label();
            txtFecha = new Label();
            label1 = new Label();
            txtFactura = new Label();
            txtBuscar = new TextBox();
            pictureBox2 = new PictureBox();
            panel2 = new Panel();
            label12 = new Label();
            lbIdProveedor = new Label();
            panel1 = new Panel();
            btnVolver = new Button();
            label3 = new Label();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtDetalles).BeginInit();
            fg.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(dtDetalles);
            panel3.Controls.Add(fg);
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(93, 114);
            panel3.Name = "panel3";
            panel3.Size = new Size(1429, 669);
            panel3.TabIndex = 14;
            // 
            // dtDetalles
            // 
            dtDetalles.AllowUserToAddRows = false;
            dtDetalles.AllowUserToDeleteRows = false;
            dtDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtDetalles.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dtDetalles.BackgroundColor = Color.White;
            dtDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtDetalles.Dock = DockStyle.Fill;
            dtDetalles.Location = new Point(0, 161);
            dtDetalles.Name = "dtDetalles";
            dtDetalles.ReadOnly = true;
            dtDetalles.RowHeadersVisible = false;
            dtDetalles.RowHeadersWidth = 51;
            dtDetalles.Size = new Size(1359, 331);
            dtDetalles.TabIndex = 6;
            // 
            // fg
            // 
            fg.Controls.Add(lblTotalFactura);
            fg.Dock = DockStyle.Bottom;
            fg.Location = new Point(0, 492);
            fg.Name = "fg";
            fg.Size = new Size(1359, 177);
            fg.TabIndex = 5;
            // 
            // lblTotalFactura
            // 
            lblTotalFactura.AutoSize = true;
            lblTotalFactura.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalFactura.Location = new Point(1088, 36);
            lblTotalFactura.Name = "lblTotalFactura";
            lblTotalFactura.Size = new Size(110, 31);
            lblTotalFactura.TabIndex = 62;
            lblTotalFactura.Text = "Factura #";
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Right;
            panel5.Location = new Point(1359, 161);
            panel5.Name = "panel5";
            panel5.Size = new Size(70, 508);
            panel5.TabIndex = 3;
            // 
            // panel4
            // 
            panel4.Controls.Add(txtCliente);
            panel4.Controls.Add(txtFecha);
            panel4.Controls.Add(label1);
            panel4.Controls.Add(txtFactura);
            panel4.Controls.Add(txtBuscar);
            panel4.Controls.Add(pictureBox2);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(1429, 161);
            panel4.TabIndex = 1;
            // 
            // txtCliente
            // 
            txtCliente.AutoSize = true;
            txtCliente.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtCliente.Location = new Point(618, 21);
            txtCliente.Name = "txtCliente";
            txtCliente.Size = new Size(110, 31);
            txtCliente.TabIndex = 61;
            txtCliente.Text = "Factura #";
            // 
            // txtFecha
            // 
            txtFecha.AutoSize = true;
            txtFecha.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtFecha.Location = new Point(618, 106);
            txtFecha.Name = "txtFecha";
            txtFecha.Size = new Size(110, 31);
            txtFecha.TabIndex = 60;
            txtFecha.Text = "Factura #";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(24, 21);
            label1.Name = "label1";
            label1.Size = new Size(83, 31);
            label1.TabIndex = 58;
            label1.Text = "Buscar";
            // 
            // txtFactura
            // 
            txtFactura.AutoSize = true;
            txtFactura.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtFactura.Location = new Point(618, 62);
            txtFactura.Name = "txtFactura";
            txtFactura.Size = new Size(110, 31);
            txtFactura.TabIndex = 47;
            txtFactura.Text = "Factura #";
            // 
            // txtBuscar
            // 
            txtBuscar.BackColor = Color.White;
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;
            txtBuscar.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.Location = new Point(24, 55);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(444, 38);
            txtBuscar.TabIndex = 34;
            txtBuscar.TextAlign = HorizontalAlignment.Center;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.White;
            pictureBox2.Image = Properties.Resources.buscar;
            pictureBox2.Location = new Point(474, 55);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(44, 38);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(label12);
            panel2.Controls.Add(lbIdProveedor);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 114);
            panel2.Name = "panel2";
            panel2.Size = new Size(93, 669);
            panel2.TabIndex = 16;
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
            panel1.Controls.Add(btnVolver);
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1522, 114);
            panel1.TabIndex = 15;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(93, 30);
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
            label3.Size = new Size(1522, 114);
            label3.TabIndex = 1;
            label3.Text = "Detalle de Venta";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmDetallesVenta
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1522, 783);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "FrmDetallesVenta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmDetallesVenta";
            WindowState = FormWindowState.Maximized;
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtDetalles).EndInit();
            fg.ResumeLayout(false);
            fg.PerformLayout();
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
        private DataGridView dtDetalles;
        private Panel fg;
        private Panel panel5;
        private Panel panel4;
        private Label label2;
        private ComboBox cbTipoPago;
        private Label label1;
        private Label txtFactura;
        private TextBox txtBuscar;
        private PictureBox pictureBox2;
        private Panel panel2;
        private Label label12;
        private Label lbIdProveedor;
        private Panel panel1;
        private Label label3;
        private Label txtFecha;
        private Label txtCliente;
        private Button btnVolver;
        private Label lblTotalFactura;
    }
}