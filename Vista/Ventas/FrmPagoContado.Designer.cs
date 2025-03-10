namespace Sopromil.Vista.Ventas
{
    partial class FrmPagoContado
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
            label2 = new Label();
            txtPagoCon = new TextBox();
            lblTotalVenta = new Label();
            btnCredito = new Button();
            btnConfirmar = new Button();
            label1 = new Label();
            lblVueltos = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(lblVueltos);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtPagoCon);
            panel1.Controls.Add(lblTotalVenta);
            panel1.Controls.Add(btnCredito);
            panel1.Controls.Add(btnConfirmar);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 104);
            panel1.Name = "panel1";
            panel1.Size = new Size(505, 350);
            panel1.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(110, 99);
            label2.Name = "label2";
            label2.Size = new Size(102, 28);
            label2.TabIndex = 87;
            label2.Text = "Paga Con:";
            // 
            // txtPagoCon
            // 
            txtPagoCon.BackColor = Color.White;
            txtPagoCon.BorderStyle = BorderStyle.FixedSingle;
            txtPagoCon.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPagoCon.Location = new Point(124, 130);
            txtPagoCon.Name = "txtPagoCon";
            txtPagoCon.Size = new Size(244, 38);
            txtPagoCon.TabIndex = 86;
            txtPagoCon.TextAlign = HorizontalAlignment.Center;
            // 
            // lblTotalVenta
            // 
            lblTotalVenta.AutoSize = true;
            lblTotalVenta.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            lblTotalVenta.Location = new Point(137, 36);
            lblTotalVenta.Name = "lblTotalVenta";
            lblTotalVenta.Size = new Size(90, 37);
            lblTotalVenta.TabIndex = 40;
            lblTotalVenta.Text = "label2";
            // 
            // btnCredito
            // 
            btnCredito.BackColor = Color.Salmon;
            btnCredito.FlatStyle = FlatStyle.Flat;
            btnCredito.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnCredito.ForeColor = Color.White;
            btnCredito.Location = new Point(269, 252);
            btnCredito.Name = "btnCredito";
            btnCredito.Size = new Size(144, 53);
            btnCredito.TabIndex = 39;
            btnCredito.Text = "Cancelar";
            btnCredito.UseVisualStyleBackColor = false;
            // 
            // btnConfirmar
            // 
            btnConfirmar.BackColor = Color.CornflowerBlue;
            btnConfirmar.FlatStyle = FlatStyle.Flat;
            btnConfirmar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnConfirmar.ForeColor = Color.White;
            btnConfirmar.Location = new Point(79, 252);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(136, 53);
            btnConfirmar.TabIndex = 38;
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
            label1.Size = new Size(505, 104);
            label1.TabIndex = 6;
            label1.Text = "Contado";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblVueltos
            // 
            lblVueltos.AutoSize = true;
            lblVueltos.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblVueltos.Location = new Point(190, 190);
            lblVueltos.Name = "lblVueltos";
            lblVueltos.Size = new Size(102, 28);
            lblVueltos.TabIndex = 88;
            lblVueltos.Text = "Paga Con:";
            // 
            // FrmPagoContado
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(505, 454);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "FrmPagoContado";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmPagoContado";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnCredito;
        private Button btnConfirmar;
        private Label label1;
        private Label lblTotalVenta;
        private Label label2;
        private TextBox txtPagoCon;
        private Label lblVueltos;
    }
}