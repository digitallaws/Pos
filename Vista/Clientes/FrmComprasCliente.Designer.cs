namespace Sopromil.Vista.Clientes
{
    partial class FrmComprasCliente
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
            panel5 = new Panel();
            panel4 = new Panel();
            label2 = new Label();
            cbTipoPago = new ComboBox();
            lbId = new Label();
            label1 = new Label();
            label11 = new Label();
            txtCliente = new TextBox();
            txtBuscar = new TextBox();
            pictureBox2 = new PictureBox();
            panel2 = new Panel();
            btnAbonar = new Button();
            label12 = new Label();
            lbIdProveedor = new Label();
            panel1 = new Panel();
            label3 = new Label();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtVentas).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(dtVentas);
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(258, 114);
            panel3.Name = "panel3";
            panel3.Size = new Size(1241, 679);
            panel3.TabIndex = 11;
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
            dtVentas.Location = new Point(0, 117);
            dtVentas.Name = "dtVentas";
            dtVentas.ReadOnly = true;
            dtVentas.RowHeadersVisible = false;
            dtVentas.RowHeadersWidth = 51;
            dtVentas.Size = new Size(1171, 440);
            dtVentas.TabIndex = 6;
            // 
            // panel6
            // 
            panel6.Dock = DockStyle.Bottom;
            panel6.Location = new Point(0, 557);
            panel6.Name = "panel6";
            panel6.Size = new Size(1171, 122);
            panel6.TabIndex = 5;
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Right;
            panel5.Location = new Point(1171, 117);
            panel5.Name = "panel5";
            panel5.Size = new Size(70, 562);
            panel5.TabIndex = 3;
            // 
            // panel4
            // 
            panel4.Controls.Add(label2);
            panel4.Controls.Add(cbTipoPago);
            panel4.Controls.Add(lbId);
            panel4.Controls.Add(label1);
            panel4.Controls.Add(label11);
            panel4.Controls.Add(txtCliente);
            panel4.Controls.Add(txtBuscar);
            panel4.Controls.Add(pictureBox2);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(1241, 117);
            panel4.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(1040, 21);
            label2.Name = "label2";
            label2.Size = new Size(158, 31);
            label2.TabIndex = 95;
            label2.Text = "Tipo de Venta";
            // 
            // cbTipoPago
            // 
            cbTipoPago.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbTipoPago.FormattingEnabled = true;
            cbTipoPago.Location = new Point(1040, 54);
            cbTipoPago.Name = "cbTipoPago";
            cbTipoPago.Size = new Size(343, 39);
            cbTipoPago.TabIndex = 94;
            // 
            // lbId
            // 
            lbId.AutoSize = true;
            lbId.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbId.Location = new Point(971, 21);
            lbId.Name = "lbId";
            lbId.Size = new Size(37, 31);
            lbId.TabIndex = 63;
            lbId.Text = "iD";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(68, 21);
            label1.Name = "label1";
            label1.Size = new Size(83, 31);
            label1.TabIndex = 58;
            label1.Text = "Buscar";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(624, 21);
            label11.Name = "label11";
            label11.Size = new Size(85, 31);
            label11.TabIndex = 47;
            label11.Text = "Cliente";
            // 
            // txtCliente
            // 
            txtCliente.BackColor = Color.White;
            txtCliente.BorderStyle = BorderStyle.FixedSingle;
            txtCliente.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCliente.Location = new Point(615, 55);
            txtCliente.Name = "txtCliente";
            txtCliente.Size = new Size(404, 38);
            txtCliente.TabIndex = 46;
            txtCliente.TextAlign = HorizontalAlignment.Center;
            // 
            // txtBuscar
            // 
            txtBuscar.BackColor = Color.White;
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;
            txtBuscar.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.Location = new Point(68, 55);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(444, 38);
            txtBuscar.TabIndex = 34;
            txtBuscar.TextAlign = HorizontalAlignment.Center;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.White;
            pictureBox2.Image = Properties.Resources.buscar;
            pictureBox2.Location = new Point(518, 55);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(44, 38);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(btnAbonar);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(lbIdProveedor);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 114);
            panel2.Name = "panel2";
            panel2.Size = new Size(258, 679);
            panel2.TabIndex = 13;
            // 
            // btnAbonar
            // 
            btnAbonar.BackColor = Color.CornflowerBlue;
            btnAbonar.FlatStyle = FlatStyle.Flat;
            btnAbonar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAbonar.ForeColor = Color.White;
            btnAbonar.Location = new Point(40, 62);
            btnAbonar.Name = "btnAbonar";
            btnAbonar.Size = new Size(160, 55);
            btnAbonar.TabIndex = 57;
            btnAbonar.Text = "Abonar";
            btnAbonar.UseVisualStyleBackColor = false;
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
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1499, 114);
            panel1.TabIndex = 12;
            // 
            // label3
            // 
            label3.BackColor = Color.CornflowerBlue;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(1499, 114);
            label3.TabIndex = 1;
            label3.Text = "Factura Cliente";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmComprasCliente
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1499, 793);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "FrmComprasCliente";
            Text = "FrmComprasCliente";
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtVentas).EndInit();
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
        private DataGridView dtClientes;
        private Panel panel6;
        private Panel panel5;
        private Panel panel4;
        private Label label1;
        private TextBox txtBuscar;
        private PictureBox pictureBox2;
        private Panel panel2;
        private Label lbId;
        private TextBox txtCliente;
        private Label label11;
        private Label label12;
        private Label lbIdProveedor;
        private Panel panel1;
        private Label label3;
        private DataGridView dtVentas;
        private Label label2;
        private ComboBox cbTipoPago;
        private Button btnAbonar;
    }
}