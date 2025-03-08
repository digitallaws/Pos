namespace Sopromil.Vista.Ventas
{
    partial class FrmPagoCredito
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
            lblCliente = new Label();
            etiqueta = new Label();
            cbBuscarCliente = new ComboBox();
            dateFechaPago = new DateTimePicker();
            btnCredito = new Button();
            btnConfirmar = new Button();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(lblCliente);
            panel1.Controls.Add(etiqueta);
            panel1.Controls.Add(cbBuscarCliente);
            panel1.Controls.Add(dateFechaPago);
            panel1.Controls.Add(btnCredito);
            panel1.Controls.Add(btnConfirmar);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 104);
            panel1.Name = "panel1";
            panel1.Size = new Size(557, 296);
            panel1.TabIndex = 3;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCliente.Location = new Point(108, 109);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(160, 31);
            lblCliente.TabIndex = 95;
            lblCliente.Text = "Buscar Cliente";
            // 
            // etiqueta
            // 
            etiqueta.AutoSize = true;
            etiqueta.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            etiqueta.Location = new Point(108, 6);
            etiqueta.Name = "etiqueta";
            etiqueta.Size = new Size(160, 31);
            etiqueta.TabIndex = 94;
            etiqueta.Text = "Buscar Cliente";
            // 
            // cbBuscarCliente
            // 
            cbBuscarCliente.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbBuscarCliente.FormattingEnabled = true;
            cbBuscarCliente.Location = new Point(108, 40);
            cbBuscarCliente.Name = "cbBuscarCliente";
            cbBuscarCliente.Size = new Size(343, 39);
            cbBuscarCliente.TabIndex = 93;
            // 
            // dateFechaPago
            // 
            dateFechaPago.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateFechaPago.Location = new Point(104, 168);
            dateFechaPago.Name = "dateFechaPago";
            dateFechaPago.Size = new Size(365, 34);
            dateFechaPago.TabIndex = 42;
            // 
            // btnCredito
            // 
            btnCredito.BackColor = Color.Salmon;
            btnCredito.FlatStyle = FlatStyle.Flat;
            btnCredito.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnCredito.ForeColor = Color.White;
            btnCredito.Location = new Point(307, 231);
            btnCredito.Name = "btnCredito";
            btnCredito.Size = new Size(144, 53);
            btnCredito.TabIndex = 41;
            btnCredito.Text = "Cancelar";
            btnCredito.UseVisualStyleBackColor = false;
            // 
            // btnConfirmar
            // 
            btnConfirmar.BackColor = Color.CornflowerBlue;
            btnConfirmar.FlatStyle = FlatStyle.Flat;
            btnConfirmar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnConfirmar.ForeColor = Color.White;
            btnConfirmar.Location = new Point(104, 231);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(136, 53);
            btnConfirmar.TabIndex = 40;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.BackColor = Color.CornflowerBlue;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(557, 104);
            label1.TabIndex = 2;
            label1.Text = "Credito";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmPagoCredito
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(557, 400);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "FrmPagoCredito";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmPagoCredito";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Button btnCredito;
        private Button btnConfirmar;
        private DateTimePicker dateFechaPago;
        private ComboBox cbBuscarCliente;
        private Label etiqueta;
        private Label lblCliente;
    }
}