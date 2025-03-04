namespace Sopromil.Vista.Creditos
{
    partial class FrmRegistrarPagoCredito
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
            btnCancelar = new Button();
            btnRegistrar = new Button();
            label3 = new Label();
            txtMontoPago = new TextBox();
            label4 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtMontoPago);
            panel1.Controls.Add(btnCancelar);
            panel1.Controls.Add(btnRegistrar);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 114);
            panel1.Name = "panel1";
            panel1.Size = new Size(515, 318);
            panel1.TabIndex = 5;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Red;
            btnCancelar.FlatStyle = FlatStyle.Popup;
            btnCancelar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(285, 218);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(131, 50);
            btnCancelar.TabIndex = 34;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = Color.DodgerBlue;
            btnRegistrar.FlatStyle = FlatStyle.Popup;
            btnRegistrar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegistrar.ForeColor = Color.White;
            btnRegistrar.Location = new Point(114, 218);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(131, 50);
            btnRegistrar.TabIndex = 33;
            btnRegistrar.Text = "Abrir";
            btnRegistrar.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.BackColor = Color.DodgerBlue;
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(515, 114);
            label3.TabIndex = 4;
            label3.Text = "Registrar Pago de Crédito";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtMontoPago
            // 
            txtMontoPago.BorderStyle = BorderStyle.FixedSingle;
            txtMontoPago.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMontoPago.Location = new Point(138, 120);
            txtMontoPago.Name = "txtMontoPago";
            txtMontoPago.Size = new Size(218, 38);
            txtMontoPago.TabIndex = 35;
            txtMontoPago.Tag = "1";
            txtMontoPago.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label4.Location = new Point(69, 69);
            label4.Name = "label4";
            label4.Size = new Size(176, 32);
            label4.TabIndex = 36;
            label4.Text = "Monto a Pagar";
            // 
            // FrmRegistrarPagoCredito
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(515, 432);
            Controls.Add(panel1);
            Controls.Add(label3);
            Name = "FrmRegistrarPagoCredito";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmRegistrarPagoCredito";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnCancelar;
        private Button btnRegistrar;
        private Label label3;
        private TextBox txtMontoPago;
        private Label label4;
    }
}