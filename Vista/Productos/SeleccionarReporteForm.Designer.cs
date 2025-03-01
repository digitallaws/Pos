namespace Sopromil.Vista.Productos
{
    partial class SeleccionarReporteForm
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
            label2 = new Label();
            label1 = new Label();
            label5 = new Label();
            pbPorVencimiento = new PictureBox();
            pbGeneral = new PictureBox();
            pbStockBajo = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPorVencimiento).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbGeneral).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbStockBajo).BeginInit();
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
            label3.Size = new Size(867, 114);
            label3.TabIndex = 3;
            label3.Text = "Reportes De Invetario";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(pbPorVencimiento);
            panel1.Controls.Add(pbGeneral);
            panel1.Controls.Add(pbStockBajo);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 114);
            panel1.Name = "panel1";
            panel1.Size = new Size(867, 468);
            panel1.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(596, 284);
            label2.Name = "label2";
            label2.Size = new Size(171, 23);
            label2.TabIndex = 23;
            label2.Text = "Reporte Vencimiento";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(364, 284);
            label1.Name = "label1";
            label1.Size = new Size(135, 23);
            label1.TabIndex = 22;
            label1.Text = "Reporte General";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(120, 284);
            label5.Name = "label5";
            label5.Size = new Size(156, 23);
            label5.TabIndex = 21;
            label5.Text = "Reporte Stock Bajo";
            // 
            // pbPorVencimiento
            // 
            pbPorVencimiento.Image = Properties.Resources.schedule;
            pbPorVencimiento.Location = new Point(596, 81);
            pbPorVencimiento.Name = "pbPorVencimiento";
            pbPorVencimiento.Size = new Size(153, 182);
            pbPorVencimiento.SizeMode = PictureBoxSizeMode.Zoom;
            pbPorVencimiento.TabIndex = 2;
            pbPorVencimiento.TabStop = false;
            // 
            // pbGeneral
            // 
            pbGeneral.Image = Properties.Resources.inventory__1_;
            pbGeneral.Location = new Point(355, 81);
            pbGeneral.Name = "pbGeneral";
            pbGeneral.Size = new Size(153, 182);
            pbGeneral.SizeMode = PictureBoxSizeMode.Zoom;
            pbGeneral.TabIndex = 1;
            pbGeneral.TabStop = false;
            // 
            // pbStockBajo
            // 
            pbStockBajo.Image = Properties.Resources.decrease;
            pbStockBajo.Location = new Point(120, 81);
            pbStockBajo.Name = "pbStockBajo";
            pbStockBajo.Size = new Size(153, 182);
            pbStockBajo.SizeMode = PictureBoxSizeMode.Zoom;
            pbStockBajo.TabIndex = 0;
            pbStockBajo.TabStop = false;
            // 
            // SeleccionarReporteForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(867, 582);
            Controls.Add(panel1);
            Controls.Add(label3);
            Name = "SeleccionarReporteForm";
            Text = "SeleccionarReporteForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbPorVencimiento).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbGeneral).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbStockBajo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label3;
        private Panel panel1;
        private PictureBox pbPorVencimiento;
        private PictureBox pbGeneral;
        private PictureBox pbStockBajo;
        private Label label5;
        private Label label2;
        private Label label1;
    }
}