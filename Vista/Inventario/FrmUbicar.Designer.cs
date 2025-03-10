namespace Sopromil.Vista.Inventario
{
    partial class FrmUbicar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUbicar));
            panel1 = new Panel();
            btnGuardar = new Button();
            lblProducto = new Label();
            label3 = new Label();
            panel3 = new Panel();
            cbSeccion = new ComboBox();
            panel2 = new Panel();
            label2 = new Label();
            cbEstante = new ComboBox();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnGuardar);
            panel1.Controls.Add(lblProducto);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 104);
            panel1.Name = "panel1";
            panel1.Size = new Size(669, 584);
            panel1.TabIndex = 11;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.CornflowerBlue;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(202, 493);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(235, 55);
            btnGuardar.TabIndex = 86;
            btnGuardar.Text = "Asignar Ubicación";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // lblProducto
            // 
            lblProducto.BackColor = Color.CornflowerBlue;
            lblProducto.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProducto.ForeColor = Color.White;
            lblProducto.Location = new Point(102, 12);
            lblProducto.Name = "lblProducto";
            lblProducto.Size = new Size(466, 47);
            lblProducto.TabIndex = 5;
            lblProducto.Text = "Nombre";
            lblProducto.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.BackColor = Color.CornflowerBlue;
            label3.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(327, 158);
            label3.Name = "label3";
            label3.Size = new Size(148, 31);
            label3.TabIndex = 4;
            label3.Text = "Sección ";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            panel3.BackColor = Color.CornflowerBlue;
            panel3.Controls.Add(cbSeccion);
            panel3.Location = new Point(324, 158);
            panel3.Name = "panel3";
            panel3.Size = new Size(148, 78);
            panel3.TabIndex = 2;
            // 
            // cbSeccion
            // 
            cbSeccion.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbSeccion.FormattingEnabled = true;
            cbSeccion.Location = new Point(29, 34);
            cbSeccion.Name = "cbSeccion";
            cbSeccion.Size = new Size(95, 39);
            cbSeccion.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = Color.CornflowerBlue;
            panel2.Controls.Add(label2);
            panel2.Controls.Add(cbEstante);
            panel2.Location = new Point(183, 192);
            panel2.Name = "panel2";
            panel2.Size = new Size(101, 117);
            panel2.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(6, 5);
            label2.Name = "label2";
            label2.Size = new Size(89, 31);
            label2.TabIndex = 3;
            label2.Text = "Estante";
            // 
            // cbEstante
            // 
            cbEstante.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbEstante.FormattingEnabled = true;
            cbEstante.Location = new Point(0, 48);
            cbEstante.Name = "cbEstante";
            cbEstante.Size = new Size(101, 39);
            cbEstante.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Estante;
            pictureBox1.Location = new Point(102, 62);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(466, 415);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.BackColor = Color.CornflowerBlue;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(669, 104);
            label1.TabIndex = 10;
            label1.Text = "Ubicar Producto";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmUbicar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(669, 688);
            Controls.Add(panel1);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmUbicar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmUbicar";
            Load += FrmUbicacion_Load;
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private Panel panel2;
        private Panel panel3;
        private Label label3;
        private ComboBox cbSeccion;
        private Label label2;
        private ComboBox cbEstante;
        private Label lblProducto;
        private Button btnGuardar;
    }
}