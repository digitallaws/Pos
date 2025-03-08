namespace Sopromil.Vista.Configuracion
{
    partial class Impresora
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
            btnImprimir = new Button();
            btnImpresora = new PictureBox();
            btnSeleccionar = new Button();
            label7 = new Label();
            txtImpresora = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnImpresora).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnImprimir);
            panel1.Controls.Add(btnImpresora);
            panel1.Controls.Add(btnSeleccionar);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(txtImpresora);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 104);
            panel1.Name = "panel1";
            panel1.Size = new Size(537, 527);
            panel1.TabIndex = 3;
            // 
            // btnImprimir
            // 
            btnImprimir.BackColor = Color.CornflowerBlue;
            btnImprimir.FlatStyle = FlatStyle.Flat;
            btnImprimir.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnImprimir.ForeColor = Color.White;
            btnImprimir.Location = new Point(251, 306);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(172, 45);
            btnImprimir.TabIndex = 41;
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = false;
            // 
            // btnImpresora
            // 
            btnImpresora.Image = Properties.Resources.impresora;
            btnImpresora.Location = new Point(176, 70);
            btnImpresora.Name = "btnImpresora";
            btnImpresora.Size = new Size(138, 131);
            btnImpresora.SizeMode = PictureBoxSizeMode.Zoom;
            btnImpresora.TabIndex = 39;
            btnImpresora.TabStop = false;
            // 
            // btnSeleccionar
            // 
            btnSeleccionar.BackColor = Color.CornflowerBlue;
            btnSeleccionar.FlatStyle = FlatStyle.Flat;
            btnSeleccionar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSeleccionar.ForeColor = Color.White;
            btnSeleccionar.Location = new Point(69, 306);
            btnSeleccionar.Name = "btnSeleccionar";
            btnSeleccionar.Size = new Size(172, 45);
            btnSeleccionar.TabIndex = 37;
            btnSeleccionar.Text = "Seleccionar";
            btnSeleccionar.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(69, 228);
            label7.Name = "label7";
            label7.Size = new Size(121, 31);
            label7.TabIndex = 28;
            label7.Text = "Impresora";
            // 
            // txtImpresora
            // 
            txtImpresora.BackColor = Color.White;
            txtImpresora.BorderStyle = BorderStyle.FixedSingle;
            txtImpresora.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtImpresora.Location = new Point(69, 262);
            txtImpresora.Name = "txtImpresora";
            txtImpresora.Size = new Size(354, 38);
            txtImpresora.TabIndex = 27;
            txtImpresora.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.BackColor = Color.CornflowerBlue;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(537, 104);
            label1.TabIndex = 2;
            label1.Text = "Impresora";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Impresora
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(537, 631);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "Impresora";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Impresora";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btnImpresora).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnSeleccionar;
        private Label label7;
        private TextBox txtImpresora;
        private Label label1;
        private PictureBox btnImpresora;
        private Button btnImprimir;
    }
}