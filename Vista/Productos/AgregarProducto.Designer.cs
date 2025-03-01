namespace Sopromil.Vista.Productos
{
    partial class AgregarProducto
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
            txtTitulo = new Label();
            panel1 = new Panel();
            btnActualizar = new Button();
            txtSTockInicial = new TextBox();
            txtFechaVencimiento = new TextBox();
            btnRegistrar = new Button();
            dtpFechaVencimiento = new DateTimePicker();
            label9 = new Label();
            txtPrecioCompra = new TextBox();
            label8 = new Label();
            txtCodigo = new TextBox();
            label7 = new Label();
            txtPrecioVenta = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            cmbCategoria = new ComboBox();
            txtNombre = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtTitulo
            // 
            txtTitulo.BackColor = Color.DodgerBlue;
            txtTitulo.Dock = DockStyle.Top;
            txtTitulo.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTitulo.ForeColor = Color.White;
            txtTitulo.Location = new Point(0, 0);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(748, 104);
            txtTitulo.TabIndex = 3;
            txtTitulo.Text = "Agregar Producto";
            txtTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnActualizar);
            panel1.Controls.Add(txtSTockInicial);
            panel1.Controls.Add(txtFechaVencimiento);
            panel1.Controls.Add(btnRegistrar);
            panel1.Controls.Add(dtpFechaVencimiento);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(txtPrecioCompra);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(txtCodigo);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(txtPrecioVenta);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(cmbCategoria);
            panel1.Controls.Add(txtNombre);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel1.Location = new Point(0, 104);
            panel1.Name = "panel1";
            panel1.Size = new Size(748, 559);
            panel1.TabIndex = 4;
            // 
            // btnActualizar
            // 
            btnActualizar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnActualizar.BackColor = Color.DodgerBlue;
            btnActualizar.FlatStyle = FlatStyle.Popup;
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(392, 400);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(286, 47);
            btnActualizar.TabIndex = 43;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Visible = false;
            // 
            // txtSTockInicial
            // 
            txtSTockInicial.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtSTockInicial.BorderStyle = BorderStyle.FixedSingle;
            txtSTockInicial.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSTockInicial.Location = new Point(49, 413);
            txtSTockInicial.Name = "txtSTockInicial";
            txtSTockInicial.Size = new Size(307, 34);
            txtSTockInicial.TabIndex = 42;
            txtSTockInicial.Tag = "1";
            txtSTockInicial.TextAlign = HorizontalAlignment.Center;
            // 
            // txtFechaVencimiento
            // 
            txtFechaVencimiento.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtFechaVencimiento.BorderStyle = BorderStyle.FixedSingle;
            txtFechaVencimiento.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFechaVencimiento.Location = new Point(392, 321);
            txtFechaVencimiento.Name = "txtFechaVencimiento";
            txtFechaVencimiento.ReadOnly = true;
            txtFechaVencimiento.Size = new Size(290, 34);
            txtFechaVencimiento.TabIndex = 41;
            txtFechaVencimiento.Tag = "1";
            txtFechaVencimiento.TextAlign = HorizontalAlignment.Center;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnRegistrar.BackColor = Color.DodgerBlue;
            btnRegistrar.FlatStyle = FlatStyle.Popup;
            btnRegistrar.ForeColor = Color.White;
            btnRegistrar.Location = new Point(392, 400);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(286, 47);
            btnRegistrar.TabIndex = 40;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = false;
            btnRegistrar.Visible = false;
            // 
            // dtpFechaVencimiento
            // 
            dtpFechaVencimiento.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtpFechaVencimiento.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpFechaVencimiento.Location = new Point(680, 321);
            dtpFechaVencimiento.Name = "dtpFechaVencimiento";
            dtpFechaVencimiento.Size = new Size(19, 34);
            dtpFechaVencimiento.TabIndex = 39;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            label9.Location = new Point(392, 288);
            label9.Name = "label9";
            label9.Size = new Size(232, 30);
            label9.TabIndex = 38;
            label9.Text = "Fecha de Vencimiento";
            // 
            // txtPrecioCompra
            // 
            txtPrecioCompra.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtPrecioCompra.BorderStyle = BorderStyle.FixedSingle;
            txtPrecioCompra.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPrecioCompra.Location = new Point(392, 221);
            txtPrecioCompra.Name = "txtPrecioCompra";
            txtPrecioCompra.Size = new Size(307, 34);
            txtPrecioCompra.TabIndex = 36;
            txtPrecioCompra.Tag = "1";
            txtPrecioCompra.TextAlign = HorizontalAlignment.Center;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            label8.Location = new Point(392, 188);
            label8.Name = "label8";
            label8.Size = new Size(159, 30);
            label8.TabIndex = 37;
            label8.Text = "Precio Compra";
            // 
            // txtCodigo
            // 
            txtCodigo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtCodigo.BorderStyle = BorderStyle.FixedSingle;
            txtCodigo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCodigo.Location = new Point(49, 321);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(307, 34);
            txtCodigo.TabIndex = 34;
            txtCodigo.Tag = "1";
            txtCodigo.TextAlign = HorizontalAlignment.Center;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            label7.Location = new Point(49, 288);
            label7.Name = "label7";
            label7.Size = new Size(85, 30);
            label7.TabIndex = 35;
            label7.Text = "Codigo";
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtPrecioVenta.BorderStyle = BorderStyle.FixedSingle;
            txtPrecioVenta.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPrecioVenta.Location = new Point(392, 132);
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(307, 34);
            txtPrecioVenta.TabIndex = 32;
            txtPrecioVenta.Tag = "1";
            txtPrecioVenta.TextAlign = HorizontalAlignment.Center;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            label6.Location = new Point(392, 99);
            label6.Name = "label6";
            label6.Size = new Size(138, 30);
            label6.TabIndex = 33;
            label6.Text = "Precio Venta";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            label5.Location = new Point(49, 380);
            label5.Name = "label5";
            label5.Size = new Size(102, 30);
            label5.TabIndex = 31;
            label5.Text = "Cantidad";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            label4.Location = new Point(49, 186);
            label4.Name = "label4";
            label4.Size = new Size(109, 30);
            label4.TabIndex = 29;
            label4.Text = "Categoria";
            // 
            // cmbCategoria
            // 
            cmbCategoria.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cmbCategoria.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(49, 221);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(307, 36);
            cmbCategoria.TabIndex = 28;
            // 
            // txtNombre
            // 
            txtNombre.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombre.Location = new Point(49, 132);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(307, 34);
            txtNombre.TabIndex = 26;
            txtNombre.Tag = "1";
            txtNombre.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            label1.Location = new Point(49, 99);
            label1.Name = "label1";
            label1.Size = new Size(129, 30);
            label1.TabIndex = 27;
            label1.Text = "Descripción";
            // 
            // AgregarProducto
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(748, 663);
            Controls.Add(panel1);
            Controls.Add(txtTitulo);
            Name = "AgregarProducto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AgregarProducto";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label3;
        private Panel panel1;
        private TextBox txtFechaVencimiento;
        private Button btnRegistrar;
        private DateTimePicker dtpFechaVencimiento;
        private Label label9;
        private TextBox txtPrecioCompra;
        private Label label8;
        private TextBox txtCodigo;
        private Label label7;
        private TextBox txtPrecioVenta;
        private Label label6;
        private Label label5;
        private Label label4;
        private ComboBox cmbCategoria;
        private TextBox txtNombre;
        private Label label1;
        private TextBox txtSTockInicial;
        private Button button1;
        private Label txtTitulo;
        private Button btnActualizar;
    }
}