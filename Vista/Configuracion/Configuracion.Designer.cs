namespace Sopromil.Vista.Configuracion
{
    partial class Configuracion
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
            panel2 = new Panel();
            label5 = new Label();
            btnUsuarios = new PictureBox();
            panel4 = new Panel();
            btnImpresora = new PictureBox();
            label1 = new Label();
            panel3 = new Panel();
            btnNegocio = new PictureBox();
            label4 = new Label();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnUsuarios).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnImpresora).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnNegocio).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(label5);
            panel2.Controls.Add(btnUsuarios);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(btnImpresora);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(btnNegocio);
            panel2.Controls.Add(label4);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 114);
            panel2.Name = "panel2";
            panel2.Size = new Size(1127, 585);
            panel2.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label5.Location = new Point(40, 253);
            label5.Name = "label5";
            label5.Size = new Size(90, 28);
            label5.TabIndex = 22;
            label5.Text = "Usuarios";
            // 
            // btnUsuarios
            // 
            btnUsuarios.Image = Properties.Resources.agregar_usuario;
            btnUsuarios.Location = new Point(40, 300);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Size = new Size(138, 131);
            btnUsuarios.SizeMode = PictureBoxSizeMode.Zoom;
            btnUsuarios.TabIndex = 21;
            btnUsuarios.TabStop = false;
            btnUsuarios.Click += btnUsuarios_Click;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Black;
            panel4.Location = new Point(48, 437);
            panel4.Name = "panel4";
            panel4.Size = new Size(1031, 2);
            panel4.TabIndex = 14;
            // 
            // btnImpresora
            // 
            btnImpresora.Image = Properties.Resources.impresora;
            btnImpresora.Location = new Point(249, 74);
            btnImpresora.Name = "btnImpresora";
            btnImpresora.Size = new Size(138, 131);
            btnImpresora.SizeMode = PictureBoxSizeMode.Zoom;
            btnImpresora.TabIndex = 13;
            btnImpresora.TabStop = false;
            btnImpresora.Click += btnImpresora_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.Location = new Point(266, 20);
            label1.Name = "label1";
            label1.Size = new Size(104, 28);
            label1.TabIndex = 12;
            label1.Text = "Impresora";
            // 
            // panel3
            // 
            panel3.BackColor = Color.Black;
            panel3.Location = new Point(40, 223);
            panel3.Name = "panel3";
            panel3.Size = new Size(1031, 2);
            panel3.TabIndex = 11;
            // 
            // btnNegocio
            // 
            btnNegocio.Image = Properties.Resources.online_shop;
            btnNegocio.Location = new Point(40, 74);
            btnNegocio.Name = "btnNegocio";
            btnNegocio.Size = new Size(138, 131);
            btnNegocio.SizeMode = PictureBoxSizeMode.Zoom;
            btnNegocio.TabIndex = 10;
            btnNegocio.TabStop = false;
            btnNegocio.Click += btnNegocio_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.Location = new Point(40, 20);
            label4.Name = "label4";
            label4.Size = new Size(146, 28);
            label4.TabIndex = 9;
            label4.Text = "Datos Negocio";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1127, 114);
            panel1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.CornflowerBlue;
            pictureBox1.Dock = DockStyle.Right;
            pictureBox1.Image = Properties.Resources.settings;
            pictureBox1.Location = new Point(990, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(137, 114);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.BackColor = Color.CornflowerBlue;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(1127, 114);
            label3.TabIndex = 1;
            label3.Text = "Configuraciones";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Configuracion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1127, 699);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Configuracion";
            Text = "Configuracion";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btnUsuarios).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnImpresora).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnNegocio).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private Label label4;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label3;
        private Panel panel3;
        private PictureBox btnNegocio;
        private Panel panel4;
        private PictureBox btnImpresora;
        private Label label1;
        private Label label5;
        private PictureBox btnUsuarios;
    }
}