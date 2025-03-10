namespace Sopromil.Vista.Inventario
{
    partial class FrmReporteInventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReporteInventario));
            panel1 = new Panel();
            label1 = new Label();
            btnBajo = new PictureBox();
            btnFecha = new PictureBox();
            btnGeneral = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnBajo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnFecha).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnGeneral).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnGeneral);
            panel1.Controls.Add(btnFecha);
            panel1.Controls.Add(btnBajo);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 104);
            panel1.Name = "panel1";
            panel1.Size = new Size(563, 352);
            panel1.TabIndex = 9;
            // 
            // label1
            // 
            label1.BackColor = Color.CornflowerBlue;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(563, 104);
            label1.TabIndex = 8;
            label1.Text = "Reportes Inventario";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnBajo
            // 
            btnBajo.Image = Properties.Resources.decrease;
            btnBajo.Location = new Point(25, 98);
            btnBajo.Name = "btnBajo";
            btnBajo.Size = new Size(134, 129);
            btnBajo.SizeMode = PictureBoxSizeMode.Zoom;
            btnBajo.TabIndex = 0;
            btnBajo.TabStop = false;
            // 
            // btnFecha
            // 
            btnFecha.Image = Properties.Resources.schedule;
            btnFecha.Location = new Point(207, 98);
            btnFecha.Name = "btnFecha";
            btnFecha.Size = new Size(134, 129);
            btnFecha.SizeMode = PictureBoxSizeMode.Zoom;
            btnFecha.TabIndex = 1;
            btnFecha.TabStop = false;
            // 
            // btnGeneral
            // 
            btnGeneral.Image = Properties.Resources.inventory;
            btnGeneral.Location = new Point(387, 98);
            btnGeneral.Name = "btnGeneral";
            btnGeneral.Size = new Size(136, 129);
            btnGeneral.SizeMode = PictureBoxSizeMode.Zoom;
            btnGeneral.TabIndex = 2;
            btnGeneral.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(40, 243);
            label2.Name = "label2";
            label2.Size = new Size(106, 28);
            label2.TabIndex = 3;
            label2.Text = "Stock Bajo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.Location = new Point(181, 243);
            label3.Name = "label3";
            label3.Size = new Size(184, 28);
            label3.TabIndex = 4;
            label3.Text = "Fecha Vencimiento";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.Location = new Point(416, 243);
            label4.Name = "label4";
            label4.Size = new Size(82, 28);
            label4.TabIndex = 5;
            label4.Text = "General";
            // 
            // FrmReporteInventario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(563, 456);
            Controls.Add(panel1);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmReporteInventario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmReporteInventario";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btnBajo).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnFecha).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnGeneral).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label4;
        private Label label3;
        private Label label2;
        private PictureBox btnGeneral;
        private PictureBox btnFecha;
        private PictureBox btnBajo;
    }
}