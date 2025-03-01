namespace Sopromil.Vista.Creditos
{
    partial class FrmGestionCreditos
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
            panel3 = new Panel();
            dtCreditos = new DataGridView();
            panel6 = new Panel();
            panel5 = new Panel();
            tos = new Panel();
            pictureBox2 = new PictureBox();
            label5 = new Label();
            txtBuscar = new TextBox();
            panel2 = new Panel();
            btnActualizar = new Button();
            btnRegistrar = new Button();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtCreditos).BeginInit();
            tos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(dtCreditos);
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(tos);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(342, 114);
            panel3.Name = "panel3";
            panel3.Size = new Size(867, 579);
            panel3.TabIndex = 11;
            // 
            // dtCreditos
            // 
            dtCreditos.AllowUserToAddRows = false;
            dtCreditos.AllowUserToDeleteRows = false;
            dtCreditos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtCreditos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dtCreditos.BackgroundColor = Color.White;
            dtCreditos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtCreditos.Dock = DockStyle.Fill;
            dtCreditos.Location = new Point(0, 117);
            dtCreditos.Name = "dtCreditos";
            dtCreditos.ReadOnly = true;
            dtCreditos.RowHeadersVisible = false;
            dtCreditos.RowHeadersWidth = 51;
            dtCreditos.Size = new Size(800, 393);
            dtCreditos.TabIndex = 6;
            // 
            // panel6
            // 
            panel6.Dock = DockStyle.Bottom;
            panel6.Location = new Point(0, 510);
            panel6.Name = "panel6";
            panel6.Size = new Size(800, 69);
            panel6.TabIndex = 5;
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Right;
            panel5.Location = new Point(800, 117);
            panel5.Name = "panel5";
            panel5.Size = new Size(67, 462);
            panel5.TabIndex = 3;
            // 
            // tos
            // 
            tos.Controls.Add(pictureBox2);
            tos.Controls.Add(label5);
            tos.Controls.Add(txtBuscar);
            tos.Dock = DockStyle.Top;
            tos.Location = new Point(0, 0);
            tos.Name = "tos";
            tos.Size = new Size(867, 117);
            tos.TabIndex = 1;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.White;
            pictureBox2.Image = Properties.Resources.buscar;
            pictureBox2.Location = new Point(360, 60);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(35, 31);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            pictureBox2.Click += btnBuscar_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(68, 34);
            label5.Name = "label5";
            label5.Size = new Size(60, 23);
            label5.TabIndex = 20;
            label5.Text = "Buscar";
            // 
            // txtBuscar
            // 
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;
            txtBuscar.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.Location = new Point(68, 60);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(286, 31);
            txtBuscar.TabIndex = 20;
            txtBuscar.Tag = "4";
            txtBuscar.TextAlign = HorizontalAlignment.Center;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(btnActualizar);
            panel2.Controls.Add(btnRegistrar);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 114);
            panel2.Name = "panel2";
            panel2.Size = new Size(342, 579);
            panel2.TabIndex = 13;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.DodgerBlue;
            btnActualizar.FlatStyle = FlatStyle.Popup;
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(24, 158);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(286, 55);
            btnActualizar.TabIndex = 30;
            btnActualizar.Text = "Nuevo Credito";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnNuevoCredito_Click;
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = Color.DodgerBlue;
            btnRegistrar.FlatStyle = FlatStyle.Popup;
            btnRegistrar.ForeColor = Color.White;
            btnRegistrar.Location = new Point(24, 219);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(286, 55);
            btnRegistrar.TabIndex = 19;
            btnRegistrar.Text = "Reportes";
            btnRegistrar.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1209, 114);
            panel1.TabIndex = 12;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.DodgerBlue;
            pictureBox1.Dock = DockStyle.Right;
            pictureBox1.Image = Properties.Resources.agregar_usuario;
            pictureBox1.Location = new Point(954, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(255, 114);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.BackColor = Color.DodgerBlue;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(1209, 114);
            label3.TabIndex = 1;
            label3.Text = "Gestión de creditos";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            label3.Click += btnNuevoCredito_Click;
            // 
            // FrmGestionCreditos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1209, 693);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "FrmGestionCreditos";
            Text = "FrmGestionCreditos";
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtCreditos).EndInit();
            tos.ResumeLayout(false);
            tos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel3;
        private DataGridView dtCreditos;
        private Panel panel6;
        private Panel panel5;
        private Panel tos;
        private PictureBox pictureBox2;
        private Label label5;
        private TextBox txtBuscar;
        private Panel panel2;
        private Button btnActualizar;
        private Button btnRegistrar;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label3;
    }
}