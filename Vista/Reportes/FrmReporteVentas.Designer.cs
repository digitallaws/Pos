namespace Sopromil.Vista.Reportes
{
    partial class FrmReporteVentas
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
            dtCompras = new DataGridView();
            panel6 = new Panel();
            lblUtilidad = new Label();
            lblVenta = new Label();
            label18 = new Label();
            label16 = new Label();
            lblCompra = new Label();
            label14 = new Label();
            panel2 = new Panel();
            panel5 = new Panel();
            btnExcel = new Button();
            panel4 = new Panel();
            txtUtilidad = new Label();
            label7 = new Label();
            txtCredito = new Label();
            label5 = new Label();
            lblTotal = new Label();
            label2 = new Label();
            label1 = new Label();
            dd = new Label();
            txtFechaFin = new DateTimePicker();
            txtFechaInicio = new DateTimePicker();
            panel1 = new Panel();
            label3 = new Label();
            btnFiiltrar = new Button();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtCompras).BeginInit();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(dtCompras);
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(panel2);
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 114);
            panel3.Name = "panel3";
            panel3.Size = new Size(1456, 673);
            panel3.TabIndex = 12;
            // 
            // dtCompras
            // 
            dtCompras.AllowUserToAddRows = false;
            dtCompras.AllowUserToDeleteRows = false;
            dtCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtCompras.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dtCompras.BackgroundColor = Color.White;
            dtCompras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtCompras.Dock = DockStyle.Fill;
            dtCompras.Location = new Point(174, 185);
            dtCompras.Name = "dtCompras";
            dtCompras.ReadOnly = true;
            dtCompras.RowHeadersVisible = false;
            dtCompras.RowHeadersWidth = 51;
            dtCompras.Size = new Size(1023, 419);
            dtCompras.TabIndex = 9;
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
            panel6.Location = new Point(174, 604);
            panel6.Name = "panel6";
            panel6.Size = new Size(1023, 69);
            panel6.TabIndex = 8;
            // 
            // lblUtilidad
            // 
            lblUtilidad.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lblUtilidad.AutoSize = true;
            lblUtilidad.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUtilidad.Location = new Point(2803, 112);
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
            lblVenta.Location = new Point(2805, 72);
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
            label18.Location = new Point(2639, 110);
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
            label16.Location = new Point(2639, 70);
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
            lblCompra.Location = new Point(2805, 29);
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
            label14.Location = new Point(2639, 29);
            label14.Name = "label14";
            label14.Size = new Size(160, 31);
            label14.TabIndex = 75;
            label14.Text = "Total Compra:";
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 185);
            panel2.Name = "panel2";
            panel2.Size = new Size(174, 488);
            panel2.TabIndex = 7;
            // 
            // panel5
            // 
            panel5.Controls.Add(btnExcel);
            panel5.Dock = DockStyle.Right;
            panel5.Location = new Point(1197, 185);
            panel5.Name = "panel5";
            panel5.Size = new Size(259, 488);
            panel5.TabIndex = 3;
            // 
            // btnExcel
            // 
            btnExcel.BackColor = Color.LimeGreen;
            btnExcel.FlatStyle = FlatStyle.Flat;
            btnExcel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExcel.ForeColor = Color.White;
            btnExcel.Location = new Point(12, 24);
            btnExcel.Name = "btnExcel";
            btnExcel.Size = new Size(235, 55);
            btnExcel.TabIndex = 85;
            btnExcel.Text = "Descargar Excel";
            btnExcel.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            panel4.Controls.Add(btnFiiltrar);
            panel4.Controls.Add(txtUtilidad);
            panel4.Controls.Add(label7);
            panel4.Controls.Add(txtCredito);
            panel4.Controls.Add(label5);
            panel4.Controls.Add(lblTotal);
            panel4.Controls.Add(label2);
            panel4.Controls.Add(label1);
            panel4.Controls.Add(dd);
            panel4.Controls.Add(txtFechaFin);
            panel4.Controls.Add(txtFechaInicio);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(1456, 185);
            panel4.TabIndex = 1;
            // 
            // txtUtilidad
            // 
            txtUtilidad.AutoSize = true;
            txtUtilidad.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtUtilidad.Location = new Point(529, 92);
            txtUtilidad.Name = "txtUtilidad";
            txtUtilidad.Size = new Size(46, 31);
            txtUtilidad.TabIndex = 75;
            txtUtilidad.Text = "$ 0";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(511, 47);
            label7.Name = "label7";
            label7.Size = new Size(96, 31);
            label7.TabIndex = 74;
            label7.Text = "Utilidad";
            // 
            // txtCredito
            // 
            txtCredito.AutoSize = true;
            txtCredito.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtCredito.Location = new Point(314, 92);
            txtCredito.Name = "txtCredito";
            txtCredito.Size = new Size(46, 31);
            txtCredito.TabIndex = 73;
            txtCredito.Text = "$ 0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(296, 47);
            label5.Name = "label5";
            label5.Size = new Size(91, 31);
            label5.TabIndex = 72;
            label5.Text = "Credito";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(73, 92);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(46, 31);
            lblTotal.TabIndex = 71;
            lblTotal.Text = "$ 0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(55, 47);
            label2.Name = "label2";
            label2.Size = new Size(140, 31);
            label2.TabIndex = 70;
            label2.Text = "Total Ventas";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(837, 88);
            label1.Name = "label1";
            label1.Size = new Size(143, 31);
            label1.TabIndex = 69;
            label1.Text = "Fecha Limite";
            // 
            // dd
            // 
            dd.AutoSize = true;
            dd.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dd.Location = new Point(841, 13);
            dd.Name = "dd";
            dd.Size = new Size(137, 31);
            dd.TabIndex = 68;
            dd.Text = "Fecha Inicio";
            // 
            // txtFechaFin
            // 
            txtFechaFin.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFechaFin.Location = new Point(826, 122);
            txtFechaFin.Name = "txtFechaFin";
            txtFechaFin.Size = new Size(403, 38);
            txtFechaFin.TabIndex = 67;
            // 
            // txtFechaInicio
            // 
            txtFechaInicio.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFechaInicio.Location = new Point(826, 47);
            txtFechaInicio.Name = "txtFechaInicio";
            txtFechaInicio.Size = new Size(403, 38);
            txtFechaInicio.TabIndex = 66;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1456, 114);
            panel1.TabIndex = 13;
            // 
            // label3
            // 
            label3.BackColor = Color.CornflowerBlue;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(1456, 114);
            label3.TabIndex = 1;
            label3.Text = "Reportes de ventas";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnFiiltrar
            // 
            btnFiiltrar.BackColor = Color.LimeGreen;
            btnFiiltrar.FlatStyle = FlatStyle.Flat;
            btnFiiltrar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnFiiltrar.ForeColor = Color.White;
            btnFiiltrar.Location = new Point(679, 47);
            btnFiiltrar.Name = "btnFiiltrar";
            btnFiiltrar.Size = new Size(114, 55);
            btnFiiltrar.TabIndex = 86;
            btnFiiltrar.Text = "Filtrar";
            btnFiiltrar.UseVisualStyleBackColor = false;
            // 
            // FrmReporteVentas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1456, 787);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Name = "FrmReporteVentas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmReporteVentas";
            WindowState = FormWindowState.Maximized;
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtCompras).EndInit();
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
        private DataGridView dtCompras;
        private Panel panel6;
        private Label lblUtilidad;
        private Label lblVenta;
        private Label label18;
        private Label label16;
        private Label lblCompra;
        private Label label14;
        private Panel panel2;
        private Panel panel5;
        private Button btnExcel;
        private Panel panel4;
        private Panel panel1;
        private Label label3;
        private DateTimePicker txtFechaFin;
        private DateTimePicker txtFechaInicio;
        private Label label1;
        private Label dd;
        private Label txtUtilidad;
        private Label label7;
        private Label txtCredito;
        private Label label5;
        private Label lblTotal;
        private Label label2;
        private Button btnFiiltrar;
    }
}