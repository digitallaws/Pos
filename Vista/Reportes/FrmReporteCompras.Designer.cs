namespace Sopromil.Vista.Reportes
{
    partial class FrmReporteCompras
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
            PnlContenedor = new Panel();
            dtCompras = new DataGridView();
            panel2 = new Panel();
            btnFiiltrar = new Button();
            label6 = new Label();
            cbProveedores = new ComboBox();
            label5 = new Label();
            label4 = new Label();
            txtFechaFin = new DateTimePicker();
            txtFechaInicio = new DateTimePicker();
            lblTotal = new Label();
            label1 = new Label();
            btnExcel = new Button();
            panel1 = new Panel();
            label3 = new Label();
            PnlContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtCompras).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // PnlContenedor
            // 
            PnlContenedor.BackColor = Color.White;
            PnlContenedor.Controls.Add(dtCompras);
            PnlContenedor.Controls.Add(panel2);
            PnlContenedor.Dock = DockStyle.Fill;
            PnlContenedor.Location = new Point(0, 114);
            PnlContenedor.Name = "PnlContenedor";
            PnlContenedor.Size = new Size(1257, 647);
            PnlContenedor.TabIndex = 18;
            // 
            // dtCompras
            // 
            dtCompras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtCompras.Dock = DockStyle.Fill;
            dtCompras.Location = new Point(0, 180);
            dtCompras.Name = "dtCompras";
            dtCompras.RowHeadersWidth = 51;
            dtCompras.Size = new Size(1257, 467);
            dtCompras.TabIndex = 60;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnFiiltrar);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(cbProveedores);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(txtFechaFin);
            panel2.Controls.Add(txtFechaInicio);
            panel2.Controls.Add(lblTotal);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(btnExcel);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1257, 180);
            panel2.TabIndex = 59;
            // 
            // btnFiiltrar
            // 
            btnFiiltrar.BackColor = Color.CornflowerBlue;
            btnFiiltrar.FlatStyle = FlatStyle.Flat;
            btnFiiltrar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnFiiltrar.ForeColor = Color.White;
            btnFiiltrar.Location = new Point(727, 32);
            btnFiiltrar.Name = "btnFiiltrar";
            btnFiiltrar.Size = new Size(157, 45);
            btnFiiltrar.TabIndex = 84;
            btnFiiltrar.Text = "Filtrar";
            btnFiiltrar.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(786, 88);
            label6.Name = "label6";
            label6.Size = new Size(123, 31);
            label6.TabIndex = 83;
            label6.Text = "Proveedor";
            // 
            // cbProveedores
            // 
            cbProveedores.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbProveedores.FormattingEnabled = true;
            cbProveedores.Location = new Point(786, 122);
            cbProveedores.Name = "cbProveedores";
            cbProveedores.Size = new Size(415, 39);
            cbProveedores.TabIndex = 82;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(247, 89);
            label5.Name = "label5";
            label5.Size = new Size(143, 31);
            label5.TabIndex = 70;
            label5.Text = "Fecha Limite";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(247, 5);
            label4.Name = "label4";
            label4.Size = new Size(137, 31);
            label4.TabIndex = 69;
            label4.Text = "Fecha Inicio";
            // 
            // txtFechaFin
            // 
            txtFechaFin.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFechaFin.Location = new Point(247, 123);
            txtFechaFin.Name = "txtFechaFin";
            txtFechaFin.Size = new Size(426, 38);
            txtFechaFin.TabIndex = 68;
            // 
            // txtFechaInicio
            // 
            txtFechaInicio.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFechaInicio.Location = new Point(247, 39);
            txtFechaInicio.Name = "txtFechaInicio";
            txtFechaInicio.Size = new Size(426, 38);
            txtFechaInicio.TabIndex = 67;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(51, 88);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(46, 31);
            lblTotal.TabIndex = 66;
            lblTotal.Text = "$ 0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(33, 43);
            label1.Name = "label1";
            label1.Size = new Size(164, 31);
            label1.TabIndex = 65;
            label1.Text = "Total Compras";
            // 
            // btnExcel
            // 
            btnExcel.BackColor = Color.LimeGreen;
            btnExcel.FlatStyle = FlatStyle.Flat;
            btnExcel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExcel.ForeColor = Color.White;
            btnExcel.Location = new Point(969, 29);
            btnExcel.Name = "btnExcel";
            btnExcel.Size = new Size(157, 45);
            btnExcel.TabIndex = 58;
            btnExcel.Text = "Exportar Excel";
            btnExcel.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1257, 114);
            panel1.TabIndex = 17;
            // 
            // label3
            // 
            label3.BackColor = Color.CornflowerBlue;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(1257, 114);
            label3.TabIndex = 1;
            label3.Text = "Reporte de Compras";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmReporteCompras
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1257, 761);
            Controls.Add(PnlContenedor);
            Controls.Add(panel1);
            Name = "FrmReporteCompras";
            Text = "FrmReporteCompras";
            PnlContenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtCompras).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel PnlContenedor;
        private DataGridView dtCompras;
        private Panel panel2;
        private Button btnExcel;
        private Panel panel1;
        private Label label3;
        private Label lblTotal;
        private Label label1;
        private Label label5;
        private Label label4;
        private DateTimePicker txtFechaFin;
        private DateTimePicker txtFechaInicio;
        private Label label6;
        private ComboBox cbProveedores;
        private Button btnFiiltrar;
    }
}