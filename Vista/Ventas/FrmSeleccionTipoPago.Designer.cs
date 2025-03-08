namespace Sopromil.Vista.Ventas
{
    partial class FrmSeleccionTipoPago
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
            btnCredito = new Button();
            btnContado = new Button();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnCredito);
            panel1.Controls.Add(btnContado);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 104);
            panel1.Name = "panel1";
            panel1.Size = new Size(591, 291);
            panel1.TabIndex = 5;
            // 
            // btnCredito
            // 
            btnCredito.BackColor = Color.Salmon;
            btnCredito.FlatStyle = FlatStyle.Flat;
            btnCredito.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCredito.ForeColor = Color.White;
            btnCredito.Location = new Point(304, 59);
            btnCredito.Name = "btnCredito";
            btnCredito.Size = new Size(202, 124);
            btnCredito.TabIndex = 41;
            btnCredito.Text = "Credito";
            btnCredito.UseVisualStyleBackColor = false;
            // 
            // btnContado
            // 
            btnContado.BackColor = Color.CornflowerBlue;
            btnContado.FlatStyle = FlatStyle.Flat;
            btnContado.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnContado.ForeColor = Color.White;
            btnContado.Location = new Point(76, 59);
            btnContado.Name = "btnContado";
            btnContado.Size = new Size(180, 124);
            btnContado.TabIndex = 40;
            btnContado.Text = "Contado";
            btnContado.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.BackColor = Color.CornflowerBlue;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(591, 104);
            label1.TabIndex = 4;
            label1.Text = "Forma de Pago";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmSeleccionTipoPago
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(591, 395);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "FrmSeleccionTipoPago";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmSeleccionTipoPago";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Button btnCredito;
        private Button btnContado;
    }
}