namespace Sopromil.Vista.Caja
{
    partial class frmMovimientoExtraCaja
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
            txtMonto = new TextBox();
            label1 = new Label();
            lblDocumentoCliente = new Label();
            btnCancelar = new Button();
            btnGuardar = new Button();
            label2 = new Label();
            cbTipoMovimiento = new ComboBox();
            label3 = new Label();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            txtDescripcion = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(txtDescripcion);
            panel1.Controls.Add(txtMonto);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblDocumentoCliente);
            panel1.Controls.Add(btnCancelar);
            panel1.Controls.Add(btnGuardar);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cbTipoMovimiento);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 91);
            panel1.Name = "panel1";
            panel1.Size = new Size(585, 432);
            panel1.TabIndex = 5;
            // 
            // txtMonto
            // 
            txtMonto.BorderStyle = BorderStyle.FixedSingle;
            txtMonto.Font = new Font("Segoe UI", 12F);
            txtMonto.Location = new Point(257, 122);
            txtMonto.Name = "txtMonto";
            txtMonto.PlaceholderText = "Ej: 20.000";
            txtMonto.Size = new Size(266, 34);
            txtMonto.TabIndex = 45;
            txtMonto.Tag = "2";
            txtMonto.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label1.Location = new Point(12, 122);
            label1.Name = "label1";
            label1.Size = new Size(93, 32);
            label1.TabIndex = 44;
            label1.Text = "Monto:";
            // 
            // lblDocumentoCliente
            // 
            lblDocumentoCliente.AutoSize = true;
            lblDocumentoCliente.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblDocumentoCliente.Location = new Point(12, 185);
            lblDocumentoCliente.Name = "lblDocumentoCliente";
            lblDocumentoCliente.Size = new Size(139, 32);
            lblDocumentoCliente.TabIndex = 42;
            lblDocumentoCliente.Text = "Descripción";
            lblDocumentoCliente.Visible = false;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Red;
            btnCancelar.FlatStyle = FlatStyle.Popup;
            btnCancelar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(307, 355);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(161, 43);
            btnCancelar.TabIndex = 38;
            btnCancelar.Tag = "5";
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.DodgerBlue;
            btnGuardar.FlatStyle = FlatStyle.Popup;
            btnGuardar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(76, 355);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(161, 43);
            btnGuardar.TabIndex = 37;
            btnGuardar.Tag = "4";
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label2.Location = new Point(12, 64);
            label2.Name = "label2";
            label2.Size = new Size(239, 32);
            label2.TabIndex = 32;
            label2.Text = "Tipo de Movimiento:";
            // 
            // cbTipoMovimiento
            // 
            cbTipoMovimiento.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cbTipoMovimiento.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbTipoMovimiento.FormattingEnabled = true;
            cbTipoMovimiento.Location = new Point(257, 64);
            cbTipoMovimiento.Name = "cbTipoMovimiento";
            cbTipoMovimiento.Size = new Size(266, 36);
            cbTipoMovimiento.TabIndex = 31;
            cbTipoMovimiento.Tag = "1";
            // 
            // label3
            // 
            label3.BackColor = Color.DodgerBlue;
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(585, 91);
            label3.TabIndex = 4;
            label3.Text = "Movimiento En Caja";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // txtDescripcion
            // 
            txtDescripcion.BorderStyle = BorderStyle.FixedSingle;
            txtDescripcion.Font = new Font("Segoe UI", 12F);
            txtDescripcion.Location = new Point(257, 185);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(266, 130);
            txtDescripcion.TabIndex = 47;
            txtDescripcion.Tag = "2";
            txtDescripcion.TextAlign = HorizontalAlignment.Center;
            // 
            // frmMovimientoExtraCaja
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(585, 523);
            Controls.Add(panel1);
            Controls.Add(label3);
            MaximizeBox = false;
            Name = "frmMovimientoExtraCaja";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmMovimientoExtraCaja";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblDocumentoCliente;
        private Button btnCancelar;
        private Button btnGuardar;
        private Label label2;
        private ComboBox cbTipoMovimiento;
        private Label label3;
        private TextBox txtMonto;
        private Label label1;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private TextBox txtDescripcion;
    }
}