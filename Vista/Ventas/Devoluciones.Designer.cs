namespace Sopromil.Vista.Ventas
{
    partial class Devoluciones
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
            panel4 = new Panel();
            dtVenta = new DataGridView();
            panel5 = new Panel();
            panel7 = new Panel();
            panel8 = new Panel();
            pictureBox6 = new PictureBox();
            btnActualizar = new Button();
            lblTotal = new Label();
            label1 = new Label();
            panel6 = new Panel();
            pictureBox2 = new PictureBox();
            label5 = new Label();
            txtBuscarProducto = new TextBox();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            panel3.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtVenta).BeginInit();
            panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
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
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(315, 589);
            panel2.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.Controls.Add(dtVenta);
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
            // dtVenta
            // 
            dtVenta.BackgroundColor = Color.White;
            dtVenta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtVenta.Dock = DockStyle.Fill;
            dtVenta.Location = new Point(107, 103);
            dtVenta.Name = "dtVenta";
            dtVenta.RowHeadersVisible = false;
            dtVenta.RowHeadersWidth = 51;
            dtVenta.Size = new Size(827, 302);
            dtVenta.TabIndex = 7;
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
            panel8.Controls.Add(btnActualizar);
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
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.DodgerBlue;
            btnActualizar.FlatStyle = FlatStyle.Popup;
            btnActualizar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(461, 34);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(132, 72);
            btnActualizar.TabIndex = 32;
            btnActualizar.Text = "Registrar Devolución";
            btnActualizar.UseVisualStyleBackColor = false;
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
            panel6.Controls.Add(pictureBox2);
            panel6.Controls.Add(label5);
            panel6.Controls.Add(txtBuscarProducto);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(1045, 103);
            panel6.TabIndex = 1;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.White;
            pictureBox2.Image = Properties.Resources.buscar;
            pictureBox2.Location = new Point(461, 47);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(35, 31);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 21;
            pictureBox2.TabStop = false;
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
            // txtBuscarProducto
            // 
            txtBuscarProducto.BorderStyle = BorderStyle.FixedSingle;
            txtBuscarProducto.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscarProducto.Location = new Point(169, 47);
            txtBuscarProducto.Name = "txtBuscarProducto";
            txtBuscarProducto.Size = new Size(286, 31);
            txtBuscarProducto.TabIndex = 23;
            txtBuscarProducto.Tag = "4";
            txtBuscarProducto.TextAlign = HorizontalAlignment.Center;
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
            // Devoluciones
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1372, 709);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Name = "Devoluciones";
            Text = "Devoluciones";
            panel3.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtVenta).EndInit();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel3;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel2;
        private Panel panel4;
        private DataGridView dtVenta;
        private Panel panel5;
        private Panel panel7;
        private Panel panel8;
        private PictureBox pictureBox6;
        private Button btnActualizar;
        private Label lblTotal;
        private Label label1;
        private Panel panel6;
        private PictureBox pictureBox2;
        private Label label5;
        private TextBox txtBuscarProducto;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label3;
    }
}