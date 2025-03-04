namespace Sopromil.Vista.Ventas
{
    partial class FrmSeleccionarPago
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
            label3 = new Label();
            panel1 = new Panel();
            btnBuscarCliente = new PictureBox();
            lblDocumentoCliente = new Label();
            lblCupoDisponible = new Label();
            txtDocumentoCliente = new TextBox();
            button1 = new Button();
            btnActualizar = new Button();
            lblDevuelta = new Label();
            txtMontoRecibido = new TextBox();
            lblMontoRecibido = new Label();
            label2 = new Label();
            cmbTipoPago = new ComboBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnBuscarCliente).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.BackColor = Color.DodgerBlue;
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(553, 91);
            label3.TabIndex = 2;
            label3.Text = "Proceso de Facturación";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnBuscarCliente);
            panel1.Controls.Add(lblDocumentoCliente);
            panel1.Controls.Add(lblCupoDisponible);
            panel1.Controls.Add(txtDocumentoCliente);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(btnActualizar);
            panel1.Controls.Add(lblDevuelta);
            panel1.Controls.Add(txtMontoRecibido);
            panel1.Controls.Add(lblMontoRecibido);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cmbTipoPago);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 91);
            panel1.Name = "panel1";
            panel1.Size = new Size(553, 406);
            panel1.TabIndex = 3;
            // 
            // btnBuscarCliente
            // 
            btnBuscarCliente.BackColor = Color.White;
            btnBuscarCliente.Image = Properties.Resources.buscar;
            btnBuscarCliente.Location = new Point(429, 151);
            btnBuscarCliente.Name = "btnBuscarCliente";
            btnBuscarCliente.Size = new Size(35, 31);
            btnBuscarCliente.SizeMode = PictureBoxSizeMode.Zoom;
            btnBuscarCliente.TabIndex = 43;
            btnBuscarCliente.TabStop = false;
            // 
            // lblDocumentoCliente
            // 
            lblDocumentoCliente.AutoSize = true;
            lblDocumentoCliente.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblDocumentoCliente.Location = new Point(123, 116);
            lblDocumentoCliente.Name = "lblDocumentoCliente";
            lblDocumentoCliente.Size = new Size(175, 32);
            lblDocumentoCliente.TabIndex = 42;
            lblDocumentoCliente.Text = "Buscar credito:";
            lblDocumentoCliente.Visible = false;
            // 
            // lblCupoDisponible
            // 
            lblCupoDisponible.AutoSize = true;
            lblCupoDisponible.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblCupoDisponible.Location = new Point(195, 208);
            lblCupoDisponible.Name = "lblCupoDisponible";
            lblCupoDisponible.Size = new Size(123, 32);
            lblCupoDisponible.TabIndex = 41;
            lblCupoDisponible.Text = "Paga Con:";
            lblCupoDisponible.Visible = false;
            // 
            // txtDocumentoCliente
            // 
            txtDocumentoCliente.BorderStyle = BorderStyle.FixedSingle;
            txtDocumentoCliente.Font = new Font("Segoe UI", 12F);
            txtDocumentoCliente.Location = new Point(123, 151);
            txtDocumentoCliente.Name = "txtDocumentoCliente";
            txtDocumentoCliente.PlaceholderText = "Ejemplo: 1003247480";
            txtDocumentoCliente.Size = new Size(300, 34);
            txtDocumentoCliente.TabIndex = 40;
            txtDocumentoCliente.Tag = "4";
            txtDocumentoCliente.TextAlign = HorizontalAlignment.Center;
            txtDocumentoCliente.Visible = false;
            // 
            // button1
            // 
            button1.BackColor = Color.Red;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(273, 307);
            button1.Name = "button1";
            button1.Size = new Size(161, 43);
            button1.TabIndex = 38;
            button1.Text = "Cancelar";
            button1.UseVisualStyleBackColor = false;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.DodgerBlue;
            btnActualizar.FlatStyle = FlatStyle.Popup;
            btnActualizar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(85, 307);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(161, 43);
            btnActualizar.TabIndex = 37;
            btnActualizar.Text = "Facturar";
            btnActualizar.UseVisualStyleBackColor = false;
            // 
            // lblDevuelta
            // 
            lblDevuelta.AutoSize = true;
            lblDevuelta.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblDevuelta.Location = new Point(195, 208);
            lblDevuelta.Name = "lblDevuelta";
            lblDevuelta.Size = new Size(123, 32);
            lblDevuelta.TabIndex = 36;
            lblDevuelta.Text = "Paga Con:";
            lblDevuelta.Visible = false;
            // 
            // txtMontoRecibido
            // 
            txtMontoRecibido.BorderStyle = BorderStyle.FixedSingle;
            txtMontoRecibido.Font = new Font("Segoe UI", 12F);
            txtMontoRecibido.Location = new Point(123, 151);
            txtMontoRecibido.Name = "txtMontoRecibido";
            txtMontoRecibido.Size = new Size(300, 34);
            txtMontoRecibido.TabIndex = 35;
            txtMontoRecibido.Tag = "4";
            txtMontoRecibido.TextAlign = HorizontalAlignment.Center;
            txtMontoRecibido.Visible = false;
            // 
            // lblMontoRecibido
            // 
            lblMontoRecibido.AutoSize = true;
            lblMontoRecibido.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblMontoRecibido.Location = new Point(123, 116);
            lblMontoRecibido.Name = "lblMontoRecibido";
            lblMontoRecibido.Size = new Size(123, 32);
            lblMontoRecibido.TabIndex = 34;
            lblMontoRecibido.Text = "Paga Con:";
            lblMontoRecibido.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label2.Location = new Point(123, 26);
            label2.Name = "label2";
            label2.Size = new Size(195, 32);
            label2.TabIndex = 32;
            label2.Text = "Metodo de Pago";
            // 
            // cmbTipoPago
            // 
            cmbTipoPago.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cmbTipoPago.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbTipoPago.FormattingEnabled = true;
            cmbTipoPago.Location = new Point(123, 61);
            cmbTipoPago.Name = "cmbTipoPago";
            cmbTipoPago.Size = new Size(300, 36);
            cmbTipoPago.TabIndex = 31;
            // 
            // FrmSeleccionarPago
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(553, 497);
            Controls.Add(panel1);
            Controls.Add(label3);
            Name = "FrmSeleccionarPago";
            Text = "FrmSeleccionarPago";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btnBuscarCliente).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label3;
        private Panel panel1;
        private ComboBox cmbTipoPago;
        private Label lblMontoRecibido;
        private Label label2;
        private TextBox txtMontoRecibido;
        private Label lblDevuelta;
        private Button button1;
        private Button btnActualizar;
        private Label lblDocumentoCliente;
        private Label lblCupoDisponible;
        private TextBox txtDocumentoCliente;
        private PictureBox btnBuscarCliente;
    }
}