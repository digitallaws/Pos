namespace Sopromil.Vista.Dashboard
{
    partial class Estadisticas
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
            ContentEstadisticas = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel9 = new Panel();
            label2 = new Label();
            dgvCreditosPendientes = new DataGridView();
            panel8 = new Panel();
            label1 = new Label();
            dgvProductosVencer = new DataGridView();
            inidcadores = new TableLayoutPanel();
            panel7 = new Panel();
            lblProductosVencer = new Label();
            label10 = new Label();
            panel6 = new Panel();
            lblCreditos = new Label();
            label8 = new Label();
            panel5 = new Panel();
            lblVentasMes = new Label();
            label6 = new Label();
            panel4 = new Panel();
            lblVentasHoy = new Label();
            label4 = new Label();
            ContentEstadisticas.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCreditosPendientes).BeginInit();
            panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductosVencer).BeginInit();
            inidcadores.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // ContentEstadisticas
            // 
            ContentEstadisticas.BorderStyle = BorderStyle.FixedSingle;
            ContentEstadisticas.Controls.Add(tableLayoutPanel1);
            ContentEstadisticas.Controls.Add(inidcadores);
            ContentEstadisticas.Dock = DockStyle.Fill;
            ContentEstadisticas.Location = new Point(0, 0);
            ContentEstadisticas.Name = "ContentEstadisticas";
            ContentEstadisticas.Size = new Size(1400, 721);
            ContentEstadisticas.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panel9, 1, 0);
            tableLayoutPanel1.Controls.Add(panel8, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 184);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 39.0654221F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 60.9345779F));
            tableLayoutPanel1.Size = new Size(1398, 535);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // panel9
            // 
            panel9.Controls.Add(label2);
            panel9.Controls.Add(dgvCreditosPendientes);
            panel9.Dock = DockStyle.Fill;
            panel9.Location = new Point(702, 3);
            panel9.Name = "panel9";
            panel9.Size = new Size(693, 203);
            panel9.TabIndex = 3;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(693, 0);
            label2.TabIndex = 2;
            label2.Text = "Creditos por vencer:";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvCreditosPendientes
            // 
            dgvCreditosPendientes.AllowUserToAddRows = false;
            dgvCreditosPendientes.AllowUserToDeleteRows = false;
            dgvCreditosPendientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCreditosPendientes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvCreditosPendientes.BorderStyle = BorderStyle.Fixed3D;
            dgvCreditosPendientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCreditosPendientes.Dock = DockStyle.Bottom;
            dgvCreditosPendientes.Location = new Point(0, -68);
            dgvCreditosPendientes.Name = "dgvCreditosPendientes";
            dgvCreditosPendientes.ReadOnly = true;
            dgvCreditosPendientes.RowHeadersWidth = 51;
            dgvCreditosPendientes.Size = new Size(693, 271);
            dgvCreditosPendientes.TabIndex = 1;
            // 
            // panel8
            // 
            panel8.Controls.Add(label1);
            panel8.Controls.Add(dgvProductosVencer);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(3, 3);
            panel8.Name = "panel8";
            panel8.Size = new Size(693, 203);
            panel8.TabIndex = 2;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(693, 0);
            label1.TabIndex = 2;
            label1.Text = "productos por vencer:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvProductosVencer
            // 
            dgvProductosVencer.AllowUserToAddRows = false;
            dgvProductosVencer.AllowUserToDeleteRows = false;
            dgvProductosVencer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductosVencer.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvProductosVencer.BorderStyle = BorderStyle.Fixed3D;
            dgvProductosVencer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductosVencer.Dock = DockStyle.Bottom;
            dgvProductosVencer.Location = new Point(0, -68);
            dgvProductosVencer.Name = "dgvProductosVencer";
            dgvProductosVencer.ReadOnly = true;
            dgvProductosVencer.RowHeadersWidth = 51;
            dgvProductosVencer.Size = new Size(693, 271);
            dgvProductosVencer.TabIndex = 1;
            // 
            // inidcadores
            // 
            inidcadores.BackColor = Color.DodgerBlue;
            inidcadores.ColumnCount = 4;
            inidcadores.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            inidcadores.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            inidcadores.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            inidcadores.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            inidcadores.Controls.Add(panel7, 3, 0);
            inidcadores.Controls.Add(panel6, 2, 0);
            inidcadores.Controls.Add(panel5, 1, 0);
            inidcadores.Controls.Add(panel4, 0, 0);
            inidcadores.Dock = DockStyle.Top;
            inidcadores.Location = new Point(0, 0);
            inidcadores.Name = "inidcadores";
            inidcadores.RowCount = 1;
            inidcadores.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            inidcadores.Size = new Size(1398, 184);
            inidcadores.TabIndex = 2;
            // 
            // panel7
            // 
            panel7.Anchor = AnchorStyles.None;
            panel7.BackColor = Color.White;
            panel7.Controls.Add(lblProductosVencer);
            panel7.Controls.Add(label10);
            panel7.Location = new Point(1074, 28);
            panel7.Name = "panel7";
            panel7.Size = new Size(296, 127);
            panel7.TabIndex = 3;
            // 
            // lblProductosVencer
            // 
            lblProductosVencer.BackColor = Color.Snow;
            lblProductosVencer.Dock = DockStyle.Fill;
            lblProductosVencer.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProductosVencer.Location = new Point(0, 63);
            lblProductosVencer.Name = "lblProductosVencer";
            lblProductosVencer.Size = new Size(296, 64);
            lblProductosVencer.TabIndex = 3;
            lblProductosVencer.Text = "20 Und";
            lblProductosVencer.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            label10.BackColor = Color.Gainsboro;
            label10.Dock = DockStyle.Top;
            label10.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(0, 0);
            label10.Name = "label10";
            label10.Size = new Size(296, 63);
            label10.TabIndex = 1;
            label10.Text = "Producto a Vencer";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            panel6.Anchor = AnchorStyles.None;
            panel6.BackColor = Color.White;
            panel6.Controls.Add(lblCreditos);
            panel6.Controls.Add(label8);
            panel6.Location = new Point(724, 28);
            panel6.Name = "panel6";
            panel6.Size = new Size(296, 127);
            panel6.TabIndex = 2;
            // 
            // lblCreditos
            // 
            lblCreditos.BackColor = Color.Snow;
            lblCreditos.Dock = DockStyle.Fill;
            lblCreditos.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCreditos.Location = new Point(0, 63);
            lblCreditos.Name = "lblCreditos";
            lblCreditos.Size = new Size(296, 64);
            lblCreditos.TabIndex = 3;
            lblCreditos.Text = "$ 10.000.000";
            lblCreditos.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.BackColor = Color.Gainsboro;
            label8.Dock = DockStyle.Top;
            label8.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(0, 0);
            label8.Name = "label8";
            label8.Size = new Size(296, 63);
            label8.TabIndex = 1;
            label8.Text = "Credito";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.None;
            panel5.BackColor = Color.White;
            panel5.Controls.Add(lblVentasMes);
            panel5.Controls.Add(label6);
            panel5.Location = new Point(375, 28);
            panel5.Name = "panel5";
            panel5.Size = new Size(296, 127);
            panel5.TabIndex = 1;
            // 
            // lblVentasMes
            // 
            lblVentasMes.BackColor = Color.Snow;
            lblVentasMes.Dock = DockStyle.Fill;
            lblVentasMes.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVentasMes.Location = new Point(0, 63);
            lblVentasMes.Name = "lblVentasMes";
            lblVentasMes.Size = new Size(296, 64);
            lblVentasMes.TabIndex = 3;
            lblVentasMes.Text = "$ 20.00.000";
            lblVentasMes.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.BackColor = Color.Gainsboro;
            label6.Dock = DockStyle.Top;
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(0, 0);
            label6.Name = "label6";
            label6.Size = new Size(296, 63);
            label6.TabIndex = 1;
            label6.Text = "Ventas Mes";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.None;
            panel4.BackColor = Color.White;
            panel4.Controls.Add(lblVentasHoy);
            panel4.Controls.Add(label4);
            panel4.Location = new Point(26, 28);
            panel4.Name = "panel4";
            panel4.Size = new Size(296, 127);
            panel4.TabIndex = 0;
            // 
            // lblVentasHoy
            // 
            lblVentasHoy.BackColor = Color.Snow;
            lblVentasHoy.Dock = DockStyle.Fill;
            lblVentasHoy.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVentasHoy.Location = new Point(0, 63);
            lblVentasHoy.Name = "lblVentasHoy";
            lblVentasHoy.Size = new Size(296, 64);
            lblVentasHoy.TabIndex = 3;
            lblVentasHoy.Text = "$ 200.000";
            lblVentasHoy.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.BackColor = Color.Gainsboro;
            label4.Dock = DockStyle.Top;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(296, 63);
            label4.TabIndex = 1;
            label4.Text = "Ventas Hoy";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Estadisticas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 721);
            Controls.Add(ContentEstadisticas);
            Name = "Estadisticas";
            Text = "Estadisticas";
            ContentEstadisticas.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCreditosPendientes).EndInit();
            panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProductosVencer).EndInit();
            inidcadores.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel ContentEstadisticas;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel9;
        private Label label2;
        private DataGridView dgvCreditosPendientes;
        private Panel panel8;
        private Label label1;
        private DataGridView dgvProductosVencer;
        private TableLayoutPanel inidcadores;
        private Panel panel7;
        private Label lblProductosVencer;
        private Label label10;
        private Panel panel6;
        private Label lblCreditos;
        private Label label8;
        private Panel panel5;
        private Label lblVentasMes;
        private Label label6;
        private Panel panel4;
        private Label lblVentasHoy;
        private Label label4;
    }
}