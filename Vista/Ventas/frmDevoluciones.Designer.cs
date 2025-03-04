namespace Sopromil.Vista.Ventas
{
    partial class frmDevoluciones
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
            tableLayoutPanel1 = new TableLayoutPanel();
            panel2 = new Panel();
            lblTotalDevuelto = new Label();
            lblTotalOriginal = new Label();
            panel4 = new Panel();
            dgvDetalleVenta = new DataGridView();
            panel5 = new Panel();
            panel7 = new Panel();
            panel8 = new Panel();
            pictureBox6 = new PictureBox();
            btnDevolverSeleccionados = new Button();
            lblTotal = new Label();
            label1 = new Label();
            panel6 = new Panel();
            btnBuscarVenta = new PictureBox();
            label5 = new Label();
            txtNumeroVenta = new TextBox();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            panel3.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalleVenta).BeginInit();
            panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnBuscarVenta).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(tableLayoutPanel1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 114);
            panel3.Name = "panel3";
            panel3.Size = new Size(1372, 595);
            panel3.TabIndex = 12;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.46723F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 76.53277F));
            tableLayoutPanel1.Controls.Add(panel2, 0, 0);
            tableLayoutPanel1.Controls.Add(panel4, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 57.7696533F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 42.2303467F));
            tableLayoutPanel1.Size = new Size(1372, 595);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblTotalDevuelto);
            panel2.Controls.Add(lblTotalOriginal);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(315, 589);
            panel2.TabIndex = 2;
            // 
            // lblTotalDevuelto
            // 
            lblTotalDevuelto.AutoSize = true;
            lblTotalDevuelto.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold);
            lblTotalDevuelto.Location = new Point(41, 238);
            lblTotalDevuelto.Name = "lblTotalDevuelto";
            lblTotalDevuelto.Size = new Size(76, 31);
            lblTotalDevuelto.TabIndex = 28;
            lblTotalDevuelto.Text = "label7";
            // 
            // lblTotalOriginal
            // 
            lblTotalOriginal.AutoSize = true;
            lblTotalOriginal.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold);
            lblTotalOriginal.Location = new Point(41, 172);
            lblTotalOriginal.Name = "lblTotalOriginal";
            lblTotalOriginal.Size = new Size(76, 31);
            lblTotalOriginal.TabIndex = 26;
            lblTotalOriginal.Text = "label7";
            // 
            // panel4
            // 
            panel4.Controls.Add(dgvDetalleVenta);
            panel4.Controls.Add(panel5);
            panel4.Controls.Add(panel7);
            panel4.Controls.Add(panel8);
            panel4.Controls.Add(panel6);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(324, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(1045, 589);
            panel4.TabIndex = 1;
            // 
            // dgvDetalleVenta
            // 
            dgvDetalleVenta.BackgroundColor = Color.White;
            dgvDetalleVenta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalleVenta.Dock = DockStyle.Fill;
            dgvDetalleVenta.Location = new Point(107, 103);
            dgvDetalleVenta.Name = "dgvDetalleVenta";
            dgvDetalleVenta.RowHeadersVisible = false;
            dgvDetalleVenta.RowHeadersWidth = 51;
            dgvDetalleVenta.Size = new Size(827, 302);
            dgvDetalleVenta.TabIndex = 7;
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Left;
            panel5.Location = new Point(0, 103);
            panel5.Name = "panel5";
            panel5.Size = new Size(107, 302);
            panel5.TabIndex = 6;
            // 
            // panel7
            // 
            panel7.Dock = DockStyle.Right;
            panel7.Location = new Point(934, 103);
            panel7.Name = "panel7";
            panel7.Size = new Size(111, 302);
            panel7.TabIndex = 5;
            // 
            // panel8
            // 
            panel8.Controls.Add(pictureBox6);
            panel8.Controls.Add(btnDevolverSeleccionados);
            panel8.Controls.Add(lblTotal);
            panel8.Controls.Add(label1);
            panel8.Dock = DockStyle.Bottom;
            panel8.Location = new Point(0, 405);
            panel8.Name = "panel8";
            panel8.Size = new Size(1045, 184);
            panel8.TabIndex = 4;
            // 
            // pictureBox6
            // 
            pictureBox6.Image = Properties.Resources.venta_al_por_mayor;
            pictureBox6.Location = new Point(389, 34);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(75, 72);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 39;
            pictureBox6.TabStop = false;
            // 
            // btnDevolverSeleccionados
            // 
            btnDevolverSeleccionados.BackColor = Color.DodgerBlue;
            btnDevolverSeleccionados.FlatStyle = FlatStyle.Popup;
            btnDevolverSeleccionados.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDevolverSeleccionados.ForeColor = Color.White;
            btnDevolverSeleccionados.Location = new Point(461, 34);
            btnDevolverSeleccionados.Name = "btnDevolverSeleccionados";
            btnDevolverSeleccionados.Size = new Size(132, 72);
            btnDevolverSeleccionados.TabIndex = 32;
            btnDevolverSeleccionados.Text = "Registrar Devolución";
            btnDevolverSeleccionados.UseVisualStyleBackColor = false;
            // 
            // lblTotal
            // 
            lblTotal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(1693, 46);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(49, 28);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "0.00";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            label1.Location = new Point(1604, 39);
            label1.Name = "label1";
            label1.Size = new Size(83, 37);
            label1.TabIndex = 0;
            label1.Text = "Total:";
            // 
            // panel6
            // 
            panel6.Controls.Add(btnBuscarVenta);
            panel6.Controls.Add(label5);
            panel6.Controls.Add(txtNumeroVenta);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(1045, 103);
            panel6.TabIndex = 1;
            // 
            // btnBuscarVenta
            // 
            btnBuscarVenta.BackColor = Color.White;
            btnBuscarVenta.Image = Properties.Resources.buscar;
            btnBuscarVenta.Location = new Point(461, 47);
            btnBuscarVenta.Name = "btnBuscarVenta";
            btnBuscarVenta.Size = new Size(35, 31);
            btnBuscarVenta.SizeMode = PictureBoxSizeMode.Zoom;
            btnBuscarVenta.TabIndex = 21;
            btnBuscarVenta.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label5.Location = new Point(169, 12);
            label5.Name = "label5";
            label5.Size = new Size(86, 32);
            label5.TabIndex = 22;
            label5.Text = "Buscar";
            // 
            // txtNumeroVenta
            // 
            txtNumeroVenta.BorderStyle = BorderStyle.FixedSingle;
            txtNumeroVenta.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNumeroVenta.Location = new Point(169, 47);
            txtNumeroVenta.Name = "txtNumeroVenta";
            txtNumeroVenta.Size = new Size(286, 31);
            txtNumeroVenta.TabIndex = 23;
            txtNumeroVenta.Tag = "4";
            txtNumeroVenta.TextAlign = HorizontalAlignment.Center;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1372, 114);
            panel1.TabIndex = 11;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.DodgerBlue;
            pictureBox1.Dock = DockStyle.Right;
            pictureBox1.Image = Properties.Resources.agregar_usuario;
            pictureBox1.Location = new Point(1208, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(164, 114);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.BackColor = Color.DodgerBlue;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(1372, 114);
            label3.TabIndex = 1;
            label3.Text = "Regitrar devolución";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmDevoluciones
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1372, 709);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Name = "frmDevoluciones";
            Text = "Devoluciones";
            panel3.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDetalleVenta).EndInit();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btnBuscarVenta).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel3;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel2;
        private Panel panel4;
        private DataGridView dgvDetalleVenta;
        private Panel panel5;
        private Panel panel7;
        private Panel panel8;
        private PictureBox pictureBox6;
        private Button btnDevolverSeleccionados;
        private Label lblTotal;
        private Label label1;
        private Panel panel6;
        private PictureBox btnBuscarVenta;
        private Label label5;
        private TextBox txtNumeroVenta;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label3;
        private Label lblTotalDevuelto;
        private Label lblTotalOriginal;
    }
}