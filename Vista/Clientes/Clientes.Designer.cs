namespace Sopromil.Vista.Clientes
{
    partial class Clientes
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
            dtClientes = new DataGridView();
            panel6 = new Panel();
            panel5 = new Panel();
            panel4 = new Panel();
            pictureBox2 = new PictureBox();
            label5 = new Label();
            txtBuscar = new TextBox();
            panel2 = new Panel();
            btnActualizar = new Button();
            cbEstado = new ComboBox();
            label7 = new Label();
            Celular = new Label();
            txtCelular = new TextBox();
            txtIdentificadorFiscal = new TextBox();
            lbId = new Label();
            btnRegistrar = new Button();
            label4 = new Label();
            label1 = new Label();
            label2 = new Label();
            txtNombre = new TextBox();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtClientes).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(dtClientes);
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(342, 114);
            panel3.Name = "panel3";
            panel3.Size = new Size(882, 604);
            panel3.TabIndex = 2;
            // 
            // dtClientes
            // 
            dtClientes.AllowUserToAddRows = false;
            dtClientes.AllowUserToDeleteRows = false;
            dtClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtClientes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dtClientes.BackgroundColor = Color.White;
            dtClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtClientes.Dock = DockStyle.Fill;
            dtClientes.Location = new Point(0, 117);
            dtClientes.Name = "dtClientes";
            dtClientes.ReadOnly = true;
            dtClientes.RowHeadersVisible = false;
            dtClientes.RowHeadersWidth = 51;
            dtClientes.Size = new Size(694, 359);
            dtClientes.TabIndex = 6;
            // 
            // panel6
            // 
            panel6.Dock = DockStyle.Bottom;
            panel6.Location = new Point(0, 476);
            panel6.Name = "panel6";
            panel6.Size = new Size(694, 128);
            panel6.TabIndex = 5;
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Right;
            panel5.Location = new Point(694, 117);
            panel5.Name = "panel5";
            panel5.Size = new Size(188, 487);
            panel5.TabIndex = 3;
            // 
            // panel4
            // 
            panel4.Controls.Add(pictureBox2);
            panel4.Controls.Add(label5);
            panel4.Controls.Add(txtBuscar);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(882, 117);
            panel4.TabIndex = 1;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.White;
            pictureBox2.Image = Properties.Resources.buscar;
            pictureBox2.Location = new Point(360, 45);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(35, 31);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(68, 19);
            label5.Name = "label5";
            label5.Size = new Size(60, 23);
            label5.TabIndex = 20;
            label5.Text = "Buscar";
            // 
            // txtBuscar
            // 
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;
            txtBuscar.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.Location = new Point(68, 45);
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
            panel2.Controls.Add(cbEstado);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(Celular);
            panel2.Controls.Add(txtCelular);
            panel2.Controls.Add(txtIdentificadorFiscal);
            panel2.Controls.Add(lbId);
            panel2.Controls.Add(btnRegistrar);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(txtNombre);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 114);
            panel2.Name = "panel2";
            panel2.Size = new Size(342, 604);
            panel2.TabIndex = 4;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.DodgerBlue;
            btnActualizar.FlatStyle = FlatStyle.Popup;
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(24, 476);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(286, 55);
            btnActualizar.TabIndex = 30;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            // 
            // cbEstado
            // 
            cbEstado.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cbEstado.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbEstado.FormattingEnabled = true;
            cbEstado.Location = new Point(24, 396);
            cbEstado.Name = "cbEstado";
            cbEstado.Size = new Size(286, 36);
            cbEstado.TabIndex = 29;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(24, 370);
            label7.Name = "label7";
            label7.Size = new Size(61, 23);
            label7.TabIndex = 25;
            label7.Text = "Estado";
            // 
            // Celular
            // 
            Celular.AutoSize = true;
            Celular.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Celular.Location = new Point(24, 301);
            Celular.Name = "Celular";
            Celular.Size = new Size(63, 23);
            Celular.TabIndex = 24;
            Celular.Text = "Celular";
            // 
            // txtCelular
            // 
            txtCelular.BorderStyle = BorderStyle.FixedSingle;
            txtCelular.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCelular.Location = new Point(24, 327);
            txtCelular.Name = "txtCelular";
            txtCelular.Size = new Size(286, 31);
            txtCelular.TabIndex = 23;
            txtCelular.Tag = "1";
            txtCelular.TextAlign = HorizontalAlignment.Center;
            // 
            // txtIdentificadorFiscal
            // 
            txtIdentificadorFiscal.BorderStyle = BorderStyle.FixedSingle;
            txtIdentificadorFiscal.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtIdentificadorFiscal.Location = new Point(24, 260);
            txtIdentificadorFiscal.Name = "txtIdentificadorFiscal";
            txtIdentificadorFiscal.Size = new Size(286, 31);
            txtIdentificadorFiscal.TabIndex = 22;
            txtIdentificadorFiscal.Tag = "1";
            txtIdentificadorFiscal.TextAlign = HorizontalAlignment.Center;
            // 
            // lbId
            // 
            lbId.AutoSize = true;
            lbId.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbId.Location = new Point(250, 159);
            lbId.Name = "lbId";
            lbId.Size = new Size(0, 23);
            lbId.TabIndex = 21;
            lbId.Visible = false;
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = Color.DodgerBlue;
            btnRegistrar.FlatStyle = FlatStyle.Popup;
            btnRegistrar.ForeColor = Color.White;
            btnRegistrar.Location = new Point(24, 476);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(286, 55);
            btnRegistrar.TabIndex = 19;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label4.Location = new Point(63, 98);
            label4.Name = "label4";
            label4.Size = new Size(197, 32);
            label4.TabIndex = 9;
            label4.Text = "Nueva Categoria";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(24, 234);
            label1.Name = "label1";
            label1.Size = new Size(127, 23);
            label1.TabIndex = 8;
            label1.Text = "Nr. Documento";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(24, 159);
            label2.Name = "label2";
            label2.Size = new Size(73, 23);
            label2.TabIndex = 7;
            label2.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombre.Location = new Point(24, 192);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(286, 31);
            txtNombre.TabIndex = 5;
            txtNombre.Tag = "1";
            txtNombre.TextAlign = HorizontalAlignment.Center;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1224, 114);
            panel1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.DodgerBlue;
            pictureBox1.Dock = DockStyle.Right;
            pictureBox1.Image = Properties.Resources.cliente;
            pictureBox1.Location = new Point(969, 0);
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
            label3.Size = new Size(1224, 114);
            label3.TabIndex = 1;
            label3.Text = "Clientes";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Clientes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1224, 718);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Clientes";
            Text = "Clientes";
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtClientes).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel3;
        private DataGridView dtClientes;
        private Panel panel6;
        private Panel panel5;
        private Panel panel4;
        private PictureBox pictureBox2;
        private Label label5;
        private TextBox txtBuscar;
        private Panel panel2;
        private Label label7;
        private Label Celular;
        private TextBox txtCelular;
        private TextBox txtIdentificadorFiscal;
        private Label lbId;
        private Button btnRegistrar;
        private Label label4;
        private Label label1;
        private Label label2;
        private TextBox txtNombre;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label3;
        private ComboBox cbEstado;
        private Button btnActualizar;
    }
}