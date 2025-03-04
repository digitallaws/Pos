namespace Sopromil.Vista.Ventas
{
    partial class FormVenta
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
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            label3 = new Label();
            panel3 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel2 = new Panel();
            btnProducto = new Button();
            btnCreditos = new Button();
            btnMovimiento = new Button();
            panel9 = new Panel();
            lblVenta = new Label();
            label6 = new Label();
            label4 = new Label();
            lblReloj = new Label();
            label2 = new Label();
            cmbClientes = new ComboBox();
            panel4 = new Panel();
            dtVenta = new DataGridView();
            panel5 = new Panel();
            panel7 = new Panel();
            panel8 = new Panel();
            pictureBox6 = new PictureBox();
            btnActualizar = new Button();
            button3 = new Button();
            lblTotal = new Label();
            label1 = new Label();
            panel6 = new Panel();
            pictureBox2 = new PictureBox();
            label5 = new Label();
            txtBuscarProducto = new TextBox();
            relojTimer = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            panel9.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtVenta).BeginInit();
            panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1419, 114);
            panel1.TabIndex = 9;
            // 
            // label3
            // 
            label3.BackColor = Color.DodgerBlue;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(1419, 114);
            label3.TabIndex = 1;
            label3.Text = "Ventas";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(tableLayoutPanel1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 114);
            panel3.Name = "panel3";
            panel3.Size = new Size(1419, 633);
            panel3.TabIndex = 10;
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
            tableLayoutPanel1.Size = new Size(1419, 633);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnProducto);
            panel2.Controls.Add(btnCreditos);
            panel2.Controls.Add(btnMovimiento);
            panel2.Controls.Add(panel9);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(cmbClientes);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(327, 627);
            panel2.TabIndex = 2;
            // 
            // btnProducto
            // 
            btnProducto.BackColor = Color.DodgerBlue;
            btnProducto.FlatStyle = FlatStyle.Popup;
            btnProducto.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnProducto.ForeColor = Color.White;
            btnProducto.Location = new Point(162, 228);
            btnProducto.Name = "btnProducto";
            btnProducto.Size = new Size(147, 72);
            btnProducto.TabIndex = 43;
            btnProducto.Text = "Consultar Producto";
            btnProducto.UseVisualStyleBackColor = false;
            btnProducto.Click += btnProducto_Click;
            // 
            // btnCreditos
            // 
            btnCreditos.BackColor = Color.DodgerBlue;
            btnCreditos.FlatStyle = FlatStyle.Popup;
            btnCreditos.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreditos.ForeColor = Color.White;
            btnCreditos.Location = new Point(162, 135);
            btnCreditos.Name = "btnCreditos";
            btnCreditos.Size = new Size(147, 72);
            btnCreditos.TabIndex = 42;
            btnCreditos.Text = "Consultar Credito";
            btnCreditos.UseVisualStyleBackColor = false;
            btnCreditos.Click += btnCreditos_Click;
            // 
            // btnMovimiento
            // 
            btnMovimiento.BackColor = Color.DodgerBlue;
            btnMovimiento.FlatStyle = FlatStyle.Popup;
            btnMovimiento.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMovimiento.ForeColor = Color.White;
            btnMovimiento.Location = new Point(9, 135);
            btnMovimiento.Name = "btnMovimiento";
            btnMovimiento.Size = new Size(147, 72);
            btnMovimiento.TabIndex = 40;
            btnMovimiento.Text = "Registrar Movimiento";
            btnMovimiento.UseVisualStyleBackColor = false;
            btnMovimiento.Click += btnMovimiento_Click;
            // 
            // panel9
            // 
            panel9.Controls.Add(lblVenta);
            panel9.Controls.Add(label6);
            panel9.Controls.Add(label4);
            panel9.Controls.Add(lblReloj);
            panel9.Dock = DockStyle.Bottom;
            panel9.Location = new Point(0, 319);
            panel9.Name = "panel9";
            panel9.Size = new Size(327, 308);
            panel9.TabIndex = 32;
            // 
            // lblVenta
            // 
            lblVenta.Anchor = AnchorStyles.Top;
            lblVenta.AutoSize = true;
            lblVenta.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVenta.Location = new Point(105, 144);
            lblVenta.Name = "lblVenta";
            lblVenta.Size = new Size(145, 46);
            lblVenta.TabIndex = 34;
            lblVenta.Text = "10:00:23";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label6.Location = new Point(31, 100);
            label6.Name = "label6";
            label6.Size = new Size(226, 32);
            label6.TabIndex = 33;
            label6.Text = "Total Ventas del día";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label4.Location = new Point(31, 14);
            label4.Name = "label4";
            label4.Size = new Size(68, 32);
            label4.TabIndex = 32;
            label4.Text = "Hora";
            // 
            // lblReloj
            // 
            lblReloj.Anchor = AnchorStyles.Top;
            lblReloj.AutoSize = true;
            lblReloj.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblReloj.Location = new Point(105, 46);
            lblReloj.Name = "lblReloj";
            lblReloj.Size = new Size(145, 46);
            lblReloj.TabIndex = 0;
            lblReloj.Text = "10:00:23";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label2.Location = new Point(9, 12);
            label2.Name = "label2";
            label2.Size = new Size(90, 32);
            label2.TabIndex = 31;
            label2.Text = "Cliente";
            // 
            // cmbClientes
            // 
            cmbClientes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cmbClientes.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbClientes.FormattingEnabled = true;
            cmbClientes.Location = new Point(9, 47);
            cmbClientes.Name = "cmbClientes";
            cmbClientes.Size = new Size(300, 36);
            cmbClientes.TabIndex = 30;
            // 
            // panel4
            // 
            panel4.Controls.Add(dtVenta);
            panel4.Controls.Add(panel5);
            panel4.Controls.Add(panel7);
            panel4.Controls.Add(panel8);
            panel4.Controls.Add(panel6);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(336, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(1080, 627);
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
            dtVenta.Size = new Size(862, 340);
            dtVenta.TabIndex = 7;
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Left;
            panel5.Location = new Point(0, 103);
            panel5.Name = "panel5";
            panel5.Size = new Size(107, 340);
            panel5.TabIndex = 6;
            // 
            // panel7
            // 
            panel7.Dock = DockStyle.Right;
            panel7.Location = new Point(969, 103);
            panel7.Name = "panel7";
            panel7.Size = new Size(111, 340);
            panel7.TabIndex = 5;
            // 
            // panel8
            // 
            panel8.Controls.Add(pictureBox6);
            panel8.Controls.Add(btnActualizar);
            panel8.Controls.Add(button3);
            panel8.Controls.Add(lblTotal);
            panel8.Controls.Add(label1);
            panel8.Dock = DockStyle.Bottom;
            panel8.Location = new Point(0, 443);
            panel8.Name = "panel8";
            panel8.Size = new Size(1080, 184);
            panel8.TabIndex = 4;
            // 
            // pictureBox6
            // 
            pictureBox6.Image = Properties.Resources.venta_al_por_mayor;
            pictureBox6.Location = new Point(114, 24);
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
            btnActualizar.Location = new Point(185, 24);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(132, 72);
            btnActualizar.TabIndex = 32;
            btnActualizar.Text = "Facturar";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnFacturar_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.DodgerBlue;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.White;
            button3.Location = new Point(349, 24);
            button3.Name = "button3";
            button3.Size = new Size(147, 72);
            button3.TabIndex = 41;
            button3.Text = "Devoluciones";
            button3.UseVisualStyleBackColor = false;
            button3.Click += btnDevolucion_Click;
            // 
            // lblTotal
            // 
            lblTotal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(848, 46);
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
            label1.Location = new Point(759, 39);
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
            panel6.Size = new Size(1080, 103);
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
            txtBuscarProducto.KeyDown += txtBuscarProducto_KeyDown;
            // 
            // FormVenta
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1419, 747);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Name = "FormVenta";
            Text = "Venta";
            Load += Venta_Load;
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtVenta).EndInit();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Label label3;
        private Panel panel3;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel4;
        private Panel panel6;
        private DataGridView dtVenta;
        private Panel panel5;
        private Panel panel7;
        private Panel panel8;
        private PictureBox pictureBox2;
        private Label label5;
        private TextBox txtBuscarProducto;
        private Label lblTotal;
        private Label label1;
        private Panel panel2;
        private Label label2;
        private ComboBox cmbClientes;
        private Button btnActualizar;
        private Panel panel9;
        private Label lblReloj;
        private System.Windows.Forms.Timer relojTimer;
        private Label label4;
        private PictureBox pictureBox6;
        private Button button1;
        private Label lblVenta;
        private Label label6;
        private Button btnProducto;
        private Button btnCreditos;
        private Button btnMovimiento;
        private Button button3;
    }
}