namespace Sopromil.Vista.Reportes
{
    partial class Reportes
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
            label3 = new Label();
            PnlContenedor = new Panel();
            btnVolver = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnVolver);
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1159, 114);
            panel1.TabIndex = 13;
            // 
            // label3
            // 
            label3.BackColor = Color.CornflowerBlue;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(1159, 114);
            label3.TabIndex = 1;
            label3.Text = "Reportes";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PnlContenedor
            // 
            PnlContenedor.BackColor = Color.White;
            PnlContenedor.Dock = DockStyle.Fill;
            PnlContenedor.Location = new Point(0, 114);
            PnlContenedor.Name = "PnlContenedor";
            PnlContenedor.Size = new Size(1159, 525);
            PnlContenedor.TabIndex = 14;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(33, 40);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(97, 49);
            btnVolver.TabIndex = 6;
            btnVolver.Text = "Atras";
            btnVolver.UseVisualStyleBackColor = true;
            // 
            // Reportes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1159, 639);
            Controls.Add(PnlContenedor);
            Controls.Add(panel1);
            Name = "Reportes";
            Text = "Reportes";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Label label3;
        private Panel PnlContenedor;
        private Button btnVolver;
    }
}