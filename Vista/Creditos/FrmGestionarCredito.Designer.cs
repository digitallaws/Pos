namespace Sopromil.Vista.Creditos
{
    partial class FrmGestionarCredito
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
            button1 = new Button();
            pictureBox2 = new PictureBox();
            lblIDCliente = new Label();
            txtFechaLimite = new TextBox();
            txtFechaLimite1 = new DateTimePicker();
            btnActualizar = new Button();
            label6 = new Label();
            txtPorcentajeInteres = new NumericUpDown();
            chkAplicaInteres = new CheckBox();
            label5 = new Label();
            txtMonto = new TextBox();
            label4 = new Label();
            label2 = new Label();
            txtTelefono = new TextBox();
            label1 = new Label();
            txtDocumento = new TextBox();
            lblDocumentoCliente = new Label();
            txtNombre = new TextBox();
            dtCreditos = new DataGridView();
            panel1 = new Panel();
            label3 = new Label();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPorcentajeInteres).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtCreditos).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(button1);
            panel3.Controls.Add(pictureBox2);
            panel3.Controls.Add(lblIDCliente);
            panel3.Controls.Add(txtFechaLimite);
            panel3.Controls.Add(txtFechaLimite1);
            panel3.Controls.Add(btnActualizar);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(txtPorcentajeInteres);
            panel3.Controls.Add(chkAplicaInteres);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(txtMonto);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(txtTelefono);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(txtDocumento);
            panel3.Controls.Add(lblDocumentoCliente);
            panel3.Controls.Add(txtNombre);
            panel3.Controls.Add(dtCreditos);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 114);
            panel3.Name = "panel3";
            panel3.Size = new Size(883, 476);
            panel3.TabIndex = 8;
            // 
            // button1
            // 
            button1.BackColor = Color.Red;
            button1.FlatStyle = FlatStyle.Popup;
            button1.ForeColor = Color.White;
            button1.Location = new Point(455, 375);
            button1.Name = "button1";
            button1.Size = new Size(170, 55);
            button1.TabIndex = 63;
            button1.Text = "Cancelar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += btnCancelar_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.White;
            pictureBox2.Image = Properties.Resources.buscar;
            pictureBox2.Location = new Point(273, 96);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(35, 31);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 62;
            pictureBox2.TabStop = false;
            pictureBox2.Click += btnBuscarCliente_Click;
            // 
            // lblIDCliente
            // 
            lblIDCliente.AutoSize = true;
            lblIDCliente.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblIDCliente.Location = new Point(389, 15);
            lblIDCliente.Name = "lblIDCliente";
            lblIDCliente.Size = new Size(27, 32);
            lblIDCliente.TabIndex = 61;
            lblIDCliente.Text = "0";
            // 
            // txtFechaLimite
            // 
            txtFechaLimite.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtFechaLimite.BorderStyle = BorderStyle.FixedSingle;
            txtFechaLimite.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFechaLimite.Location = new Point(332, 227);
            txtFechaLimite.Name = "txtFechaLimite";
            txtFechaLimite.ReadOnly = true;
            txtFechaLimite.Size = new Size(218, 34);
            txtFechaLimite.TabIndex = 60;
            txtFechaLimite.Tag = "1";
            txtFechaLimite.TextAlign = HorizontalAlignment.Center;
            // 
            // txtFechaLimite1
            // 
            txtFechaLimite1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtFechaLimite1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFechaLimite1.Location = new Point(547, 227);
            txtFechaLimite1.Name = "txtFechaLimite1";
            txtFechaLimite1.Size = new Size(26, 34);
            txtFechaLimite1.TabIndex = 59;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.DodgerBlue;
            btnActualizar.FlatStyle = FlatStyle.Popup;
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(229, 375);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(170, 55);
            btnActualizar.TabIndex = 58;
            btnActualizar.Text = "Registrar Credito";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnRegistrarCredito_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label6.Location = new Point(627, 229);
            label6.Name = "label6";
            label6.Size = new Size(29, 28);
            label6.TabIndex = 57;
            label6.Text = "%";
            label6.Visible = false;
            // 
            // txtPorcentajeInteres
            // 
            txtPorcentajeInteres.Location = new Point(662, 230);
            txtPorcentajeInteres.Name = "txtPorcentajeInteres";
            txtPorcentajeInteres.Size = new Size(58, 27);
            txtPorcentajeInteres.TabIndex = 56;
            txtPorcentajeInteres.Visible = false;
            // 
            // chkAplicaInteres
            // 
            chkAplicaInteres.AutoSize = true;
            chkAplicaInteres.Location = new Point(617, 200);
            chkAplicaInteres.Name = "chkAplicaInteres";
            chkAplicaInteres.Size = new Size(135, 24);
            chkAplicaInteres.TabIndex = 55;
            chkAplicaInteres.Text = "Aplica Interéses";
            chkAplicaInteres.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label5.Location = new Point(41, 195);
            label5.Name = "label5";
            label5.Size = new Size(93, 32);
            label5.TabIndex = 54;
            label5.Text = "Monto:";
            // 
            // txtMonto
            // 
            txtMonto.BorderStyle = BorderStyle.FixedSingle;
            txtMonto.Font = new Font("Segoe UI", 12F);
            txtMonto.Location = new Point(40, 230);
            txtMonto.Name = "txtMonto";
            txtMonto.PlaceholderText = "Ej: 10.000";
            txtMonto.Size = new Size(244, 34);
            txtMonto.TabIndex = 53;
            txtMonto.Tag = "4";
            txtMonto.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label4.Location = new Point(332, 192);
            label4.Name = "label4";
            label4.Size = new Size(151, 32);
            label4.TabIndex = 51;
            label4.Text = "Fecha Limite";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label2.Location = new Point(598, 58);
            label2.Name = "label2";
            label2.Size = new Size(113, 32);
            label2.TabIndex = 50;
            label2.Text = "Telefono:";
            // 
            // txtTelefono
            // 
            txtTelefono.BorderStyle = BorderStyle.FixedSingle;
            txtTelefono.Font = new Font("Segoe UI", 12F);
            txtTelefono.Location = new Point(583, 96);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.PlaceholderText = "Ej: 3128566435";
            txtTelefono.Size = new Size(244, 34);
            txtTelefono.TabIndex = 49;
            txtTelefono.Tag = "4";
            txtTelefono.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label1.Location = new Point(41, 58);
            label1.Name = "label1";
            label1.Size = new Size(141, 32);
            label1.TabIndex = 48;
            label1.Text = "Documento";
            // 
            // txtDocumento
            // 
            txtDocumento.BorderStyle = BorderStyle.FixedSingle;
            txtDocumento.Font = new Font("Segoe UI", 12F);
            txtDocumento.Location = new Point(24, 96);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.PlaceholderText = "Ej: 1003247480";
            txtDocumento.Size = new Size(243, 34);
            txtDocumento.TabIndex = 47;
            txtDocumento.Tag = "4";
            txtDocumento.TextAlign = HorizontalAlignment.Center;
            // 
            // lblDocumentoCliente
            // 
            lblDocumentoCliente.AutoSize = true;
            lblDocumentoCliente.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblDocumentoCliente.Location = new Point(336, 58);
            lblDocumentoCliente.Name = "lblDocumentoCliente";
            lblDocumentoCliente.Size = new Size(103, 32);
            lblDocumentoCliente.TabIndex = 46;
            lblDocumentoCliente.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Font = new Font("Segoe UI", 12F);
            txtNombre.Location = new Point(332, 96);
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Ej: Juan Manzano";
            txtNombre.Size = new Size(230, 34);
            txtNombre.TabIndex = 45;
            txtNombre.Tag = "4";
            txtNombre.TextAlign = HorizontalAlignment.Center;
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
            dtCreditos.Location = new Point(0, 0);
            dtCreditos.Name = "dtCreditos";
            dtCreditos.ReadOnly = true;
            dtCreditos.RowHeadersVisible = false;
            dtCreditos.RowHeadersWidth = 51;
            dtCreditos.Size = new Size(883, 476);
            dtCreditos.TabIndex = 6;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(883, 114);
            panel1.TabIndex = 9;
            // 
            // label3
            // 
            label3.BackColor = Color.DodgerBlue;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(883, 114);
            label3.TabIndex = 1;
            label3.Text = "Nuevo Credito";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmGestionarCredito
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(883, 590);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Name = "FrmGestionarCredito";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GestionarCreditos";
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPorcentajeInteres).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtCreditos).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel3;
        private DataGridView dtCreditos;
        private Panel panel1;
        private Label label3;
        private Label lblDocumentoCliente;
        private TextBox txtNombre;
        private Label label1;
        private TextBox txtDocumento;
        private TextBox txtTelefono;
        private Label label2;
        private Label label5;
        private TextBox txtMonto;
        private Label label4;
        private CheckBox chkAplicaInteres;
        private Label label6;
        private NumericUpDown txtPorcentajeInteres;
        private Button btnActualizar;
        private TextBox txtFechaLimite;
        private DateTimePicker txtFechaLimite1;
        private Label lblIDCliente;
        private Button button1;
        private PictureBox pictureBox2;
    }
}