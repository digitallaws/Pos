namespace Sopromil.Vista.Clientes
{
    partial class FrmAbono
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
            label1 = new Label();
            panel1 = new Panel();
            dtAbonos = new DataGridView();
            panel6 = new Panel();
            ed = new Panel();
            lblCliente = new Label();
            label3 = new Label();
            txtBuscar = new TextBox();
            pictureBox2 = new PictureBox();
            panel2 = new Panel();
            lblCredito = new Label();
            txtAbono = new TextBox();
            btnConfirmar = new Button();
            label2 = new Label();
            panel5 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtAbonos).BeginInit();
            ed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.CornflowerBlue;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(1435, 137);
            label1.TabIndex = 8;
            label1.Text = "Abonos";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(dtAbonos);
            panel1.Controls.Add(panel6);
            panel1.Controls.Add(ed);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(panel5);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 137);
            panel1.Name = "panel1";
            panel1.Size = new Size(1435, 544);
            panel1.TabIndex = 9;
            // 
            // dtAbonos
            // 
            dtAbonos.AllowUserToAddRows = false;
            dtAbonos.AllowUserToDeleteRows = false;
            dtAbonos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtAbonos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dtAbonos.BackgroundColor = Color.White;
            dtAbonos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtAbonos.Dock = DockStyle.Fill;
            dtAbonos.Location = new Point(499, 117);
            dtAbonos.Name = "dtAbonos";
            dtAbonos.ReadOnly = true;
            dtAbonos.RowHeadersVisible = false;
            dtAbonos.RowHeadersWidth = 51;
            dtAbonos.Size = new Size(866, 305);
            dtAbonos.TabIndex = 14;
            // 
            // panel6
            // 
            panel6.Dock = DockStyle.Bottom;
            panel6.Location = new Point(499, 422);
            panel6.Name = "panel6";
            panel6.Size = new Size(866, 122);
            panel6.TabIndex = 13;
            // 
            // ed
            // 
            ed.Controls.Add(lblCliente);
            ed.Controls.Add(label3);
            ed.Controls.Add(txtBuscar);
            ed.Controls.Add(pictureBox2);
            ed.Dock = DockStyle.Top;
            ed.Location = new Point(499, 0);
            ed.Name = "ed";
            ed.Size = new Size(866, 117);
            ed.TabIndex = 11;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCliente.Location = new Point(429, 12);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(37, 31);
            lblCliente.TabIndex = 59;
            lblCliente.Text = "iD";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(68, 21);
            label3.Name = "label3";
            label3.Size = new Size(83, 31);
            label3.TabIndex = 58;
            label3.Text = "Buscar";
            // 
            // txtBuscar
            // 
            txtBuscar.BackColor = Color.White;
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;
            txtBuscar.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.Location = new Point(68, 55);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(444, 38);
            txtBuscar.TabIndex = 34;
            txtBuscar.TextAlign = HorizontalAlignment.Center;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.White;
            pictureBox2.Image = Properties.Resources.buscar;
            pictureBox2.Location = new Point(518, 55);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(44, 38);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(lblCredito);
            panel2.Controls.Add(txtAbono);
            panel2.Controls.Add(btnConfirmar);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(499, 544);
            panel2.TabIndex = 15;
            // 
            // lblCredito
            // 
            lblCredito.AutoSize = true;
            lblCredito.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblCredito.Location = new Point(198, 89);
            lblCredito.Name = "lblCredito";
            lblCredito.Size = new Size(23, 28);
            lblCredito.TabIndex = 92;
            lblCredito.Text = "0";
            // 
            // txtAbono
            // 
            txtAbono.BackColor = Color.White;
            txtAbono.BorderStyle = BorderStyle.FixedSingle;
            txtAbono.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAbono.Location = new Point(78, 230);
            txtAbono.Name = "txtAbono";
            txtAbono.Size = new Size(318, 38);
            txtAbono.TabIndex = 90;
            txtAbono.TextAlign = HorizontalAlignment.Center;
            // 
            // btnConfirmar
            // 
            btnConfirmar.BackColor = Color.CornflowerBlue;
            btnConfirmar.FlatStyle = FlatStyle.Flat;
            btnConfirmar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnConfirmar.ForeColor = Color.White;
            btnConfirmar.Location = new Point(161, 302);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(136, 53);
            btnConfirmar.TabIndex = 88;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = false;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(100, 175);
            label2.Name = "label2";
            label2.Size = new Size(186, 28);
            label2.TabIndex = 91;
            label2.Text = "Cantidad a Abonar:";
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Right;
            panel5.Location = new Point(1365, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(70, 544);
            panel5.TabIndex = 12;
            // 
            // FrmAbono
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1435, 681);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "FrmAbono";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmAbono";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtAbonos).EndInit();
            ed.ResumeLayout(false);
            ed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private Panel panel1;
        private Label label2;
        private TextBox txtAbono;
        private Button btnConfirmar;
        private DataGridView dtAbonos;
        private Panel panel6;
        private Panel ed;
        private Label label3;
        private TextBox txtBuscar;
        private PictureBox pictureBox2;
        private Panel panel2;
        private Panel panel5;
        private Label lblCliente;
        private Label lblCredito;
    }
}