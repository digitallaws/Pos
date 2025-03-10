namespace Sopromil.Vista.Inventario
{
    partial class FrmInformePrecio
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
            panel1 = new Panel();
            dtHistorial = new DataGridView();
            panel2 = new Panel();
            groupBox1 = new GroupBox();
            label6 = new Label();
            txtPrecio = new TextBox();
            label5 = new Label();
            txtStock = new TextBox();
            label4 = new Label();
            txtRegistro = new TextBox();
            label2 = new Label();
            txtProveedor = new TextBox();
            label3 = new Label();
            txtNombre = new TextBox();
            label1 = new Label();
            label7 = new Label();
            txtVenta = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtHistorial).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(dtHistorial);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(groupBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 104);
            panel1.Name = "panel1";
            panel1.Size = new Size(1292, 687);
            panel1.TabIndex = 13;
            // 
            // dtHistorial
            // 
            dtHistorial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtHistorial.Dock = DockStyle.Fill;
            dtHistorial.Location = new Point(0, 226);
            dtHistorial.Name = "dtHistorial";
            dtHistorial.RowHeadersWidth = 51;
            dtHistorial.Size = new Size(1292, 402);
            dtHistorial.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 628);
            panel2.Name = "panel2";
            panel2.Size = new Size(1292, 59);
            panel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(txtVenta);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtPrecio);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtStock);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtRegistro);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtProveedor);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1292, 226);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos Producto";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label6.Location = new Point(526, 130);
            label6.Name = "label6";
            label6.Size = new Size(236, 28);
            label6.TabIndex = 89;
            label6.Text = "Precio de Compra Actual";
            // 
            // txtPrecio
            // 
            txtPrecio.BackColor = Color.White;
            txtPrecio.BorderStyle = BorderStyle.FixedSingle;
            txtPrecio.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPrecio.Location = new Point(526, 161);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(236, 38);
            txtPrecio.TabIndex = 88;
            txtPrecio.TextAlign = HorizontalAlignment.Center;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label5.Location = new Point(911, 48);
            label5.Name = "label5";
            label5.Size = new Size(61, 28);
            label5.TabIndex = 87;
            label5.Text = "Stock";
            // 
            // txtStock
            // 
            txtStock.BackColor = Color.White;
            txtStock.BorderStyle = BorderStyle.FixedSingle;
            txtStock.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtStock.Location = new Point(911, 79);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(106, 38);
            txtStock.TabIndex = 86;
            txtStock.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.Location = new Point(162, 130);
            label4.Name = "label4";
            label4.Size = new Size(173, 28);
            label4.TabIndex = 85;
            label4.Text = "Fecha de Registro";
            // 
            // txtRegistro
            // 
            txtRegistro.BackColor = Color.White;
            txtRegistro.BorderStyle = BorderStyle.FixedSingle;
            txtRegistro.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRegistro.Location = new Point(162, 161);
            txtRegistro.Name = "txtRegistro";
            txtRegistro.Size = new Size(340, 38);
            txtRegistro.TabIndex = 84;
            txtRegistro.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(525, 48);
            label2.Name = "label2";
            label2.Size = new Size(66, 28);
            label2.TabIndex = 83;
            label2.Text = "Marca";
            // 
            // txtProveedor
            // 
            txtProveedor.BackColor = Color.White;
            txtProveedor.BorderStyle = BorderStyle.FixedSingle;
            txtProveedor.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtProveedor.Location = new Point(525, 79);
            txtProveedor.Name = "txtProveedor";
            txtProveedor.Size = new Size(356, 38);
            txtProveedor.TabIndex = 82;
            txtProveedor.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.Location = new Point(162, 48);
            label3.Name = "label3";
            label3.Size = new Size(176, 28);
            label3.TabIndex = 81;
            label3.Text = "Nombre Producto";
            // 
            // txtNombre
            // 
            txtNombre.BackColor = Color.White;
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombre.Location = new Point(162, 79);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(340, 38);
            txtNombre.TabIndex = 80;
            txtNombre.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.BackColor = Color.CornflowerBlue;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(1292, 104);
            label1.TabIndex = 12;
            label1.Text = "Historial Precios";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label7.Location = new Point(781, 130);
            label7.Name = "label7";
            label7.Size = new Size(223, 28);
            label7.TabIndex = 91;
            label7.Text = "Precio de  Venta Actual";
            // 
            // txtVenta
            // 
            txtVenta.BackColor = Color.White;
            txtVenta.BorderStyle = BorderStyle.FixedSingle;
            txtVenta.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtVenta.Location = new Point(781, 161);
            txtVenta.Name = "txtVenta";
            txtVenta.Size = new Size(236, 38);
            txtVenta.TabIndex = 90;
            txtVenta.TextAlign = HorizontalAlignment.Center;
            // 
            // FrmInformePrecio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1292, 791);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "FrmInformePrecio";
            Text = "FrmInformePrecio";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtHistorial).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private GroupBox groupBox1;
        private TextBox txtNombre;
        private DataGridView dtHistorial;
        private Panel panel2;
        private Label label6;
        private TextBox txtPrecio;
        private Label label5;
        private TextBox txtStock;
        private Label label4;
        private TextBox txtRegistro;
        private Label label2;
        private TextBox txtProveedor;
        private Label label3;
        private Label label7;
        private TextBox txtVenta;
    }
}