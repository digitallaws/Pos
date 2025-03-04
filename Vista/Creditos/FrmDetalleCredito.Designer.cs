namespace Sopromil.Vista.Creditos
{
    partial class FrmDetalleCredito
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
            dgvHistorialPagos = new DataGridView();
            groupBox3 = new GroupBox();
            txtGananciaIntereses = new TextBox();
            txtTotalPagado = new TextBox();
            label12 = new Label();
            label13 = new Label();
            groupBox2 = new GroupBox();
            txtFechaVencimiento = new TextBox();
            txtTasaInteres = new TextBox();
            txtDiasRestantes = new TextBox();
            txtEstadoCredito = new TextBox();
            txtSaldoDisponible = new TextBox();
            txtMontoTotal = new TextBox();
            txtFechaRegistro = new TextBox();
            label10 = new Label();
            label8 = new Label();
            label6 = new Label();
            label4 = new Label();
            label5 = new Label();
            label7 = new Label();
            label9 = new Label();
            groupBox1 = new GroupBox();
            txtTelefonoCliente = new TextBox();
            txtDocumentoCliente = new TextBox();
            txtNombreCliente = new TextBox();
            label1 = new Label();
            label2 = new Label();
            lblDocumentoCliente = new Label();
            btnRegistrarPago = new Button();
            dtCreditos = new DataGridView();
            lblIDCliente = new Label();
            panel1 = new Panel();
            label3 = new Label();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistorialPagos).BeginInit();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtCreditos).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(dgvHistorialPagos);
            panel3.Controls.Add(groupBox3);
            panel3.Controls.Add(groupBox2);
            panel3.Controls.Add(groupBox1);
            panel3.Controls.Add(btnRegistrarPago);
            panel3.Controls.Add(dtCreditos);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 114);
            panel3.Name = "panel3";
            panel3.Size = new Size(1531, 786);
            panel3.TabIndex = 10;
            // 
            // dgvHistorialPagos
            // 
            dgvHistorialPagos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorialPagos.Location = new Point(171, 265);
            dgvHistorialPagos.Name = "dgvHistorialPagos";
            dgvHistorialPagos.RowHeadersWidth = 51;
            dgvHistorialPagos.Size = new Size(1207, 320);
            dgvHistorialPagos.TabIndex = 12;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtGananciaIntereses);
            groupBox3.Controls.Add(txtTotalPagado);
            groupBox3.Controls.Add(label12);
            groupBox3.Controls.Add(label13);
            groupBox3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox3.Location = new Point(361, 37);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(391, 205);
            groupBox3.TabIndex = 51;
            groupBox3.TabStop = false;
            groupBox3.Text = "Resumen Financiero";
            // 
            // txtGananciaIntereses
            // 
            txtGananciaIntereses.Location = new Point(206, 88);
            txtGananciaIntereses.Name = "txtGananciaIntereses";
            txtGananciaIntereses.Size = new Size(151, 34);
            txtGananciaIntereses.TabIndex = 55;
            // 
            // txtTotalPagado
            // 
            txtTotalPagado.Location = new Point(147, 48);
            txtTotalPagado.Name = "txtTotalPagado";
            txtTotalPagado.Size = new Size(210, 34);
            txtTotalPagado.TabIndex = 54;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 12F);
            label12.Location = new Point(6, 91);
            label12.Name = "label12";
            label12.Size = new Size(187, 25);
            label12.TabIndex = 48;
            label12.Text = "Ganancia Intereses:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Microsoft Sans Serif", 12F);
            label13.Location = new Point(6, 54);
            label13.Name = "label13";
            label13.Size = new Size(135, 25);
            label13.TabIndex = 46;
            label13.Text = "Total Pagado:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtFechaVencimiento);
            groupBox2.Controls.Add(txtTasaInteres);
            groupBox2.Controls.Add(txtDiasRestantes);
            groupBox2.Controls.Add(txtEstadoCredito);
            groupBox2.Controls.Add(txtSaldoDisponible);
            groupBox2.Controls.Add(txtMontoTotal);
            groupBox2.Controls.Add(txtFechaRegistro);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label9);
            groupBox2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(768, 37);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(751, 205);
            groupBox2.TabIndex = 52;
            groupBox2.TabStop = false;
            groupBox2.Text = "Datos del Crédito";
            // 
            // txtFechaVencimiento
            // 
            txtFechaVencimiento.Location = new Point(187, 88);
            txtFechaVencimiento.Name = "txtFechaVencimiento";
            txtFechaVencimiento.Size = new Size(268, 34);
            txtFechaVencimiento.TabIndex = 63;
            // 
            // txtTasaInteres
            // 
            txtTasaInteres.Location = new Point(616, 125);
            txtTasaInteres.Name = "txtTasaInteres";
            txtTasaInteres.Size = new Size(118, 34);
            txtTasaInteres.TabIndex = 62;
            // 
            // txtDiasRestantes
            // 
            txtDiasRestantes.Location = new Point(616, 85);
            txtDiasRestantes.Name = "txtDiasRestantes";
            txtDiasRestantes.Size = new Size(118, 34);
            txtDiasRestantes.TabIndex = 61;
            // 
            // txtEstadoCredito
            // 
            txtEstadoCredito.Location = new Point(614, 45);
            txtEstadoCredito.Name = "txtEstadoCredito";
            txtEstadoCredito.Size = new Size(118, 34);
            txtEstadoCredito.TabIndex = 60;
            // 
            // txtSaldoDisponible
            // 
            txtSaldoDisponible.Location = new Point(189, 166);
            txtSaldoDisponible.Name = "txtSaldoDisponible";
            txtSaldoDisponible.Size = new Size(266, 34);
            txtSaldoDisponible.TabIndex = 59;
            // 
            // txtMontoTotal
            // 
            txtMontoTotal.Location = new Point(189, 125);
            txtMontoTotal.Name = "txtMontoTotal";
            txtMontoTotal.Size = new Size(266, 34);
            txtMontoTotal.TabIndex = 58;
            // 
            // txtFechaRegistro
            // 
            txtFechaRegistro.Location = new Point(187, 48);
            txtFechaRegistro.Name = "txtFechaRegistro";
            txtFechaRegistro.Size = new Size(268, 34);
            txtFechaRegistro.TabIndex = 56;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 12F);
            label10.Location = new Point(461, 125);
            label10.Name = "label10";
            label10.Size = new Size(154, 25);
            label10.TabIndex = 54;
            label10.Text = "Tasa de Interés:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 12F);
            label8.Location = new Point(461, 88);
            label8.Name = "label8";
            label8.Size = new Size(149, 25);
            label8.TabIndex = 53;
            label8.Text = "Días Restantes:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12F);
            label6.Location = new Point(461, 51);
            label6.Name = "label6";
            label6.Size = new Size(79, 25);
            label6.TabIndex = 52;
            label6.Text = "Estado:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F);
            label4.Location = new Point(6, 166);
            label4.Name = "label4";
            label4.Size = new Size(165, 25);
            label4.TabIndex = 51;
            label4.Text = "Saldo Disponible:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F);
            label5.Location = new Point(6, 128);
            label5.Name = "label5";
            label5.Size = new Size(122, 25);
            label5.TabIndex = 50;
            label5.Text = "Monto Total:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 12F);
            label7.Location = new Point(6, 91);
            label7.Name = "label7";
            label7.Size = new Size(186, 25);
            label7.TabIndex = 48;
            label7.Text = "Fecha Vencimiento:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 12F);
            label9.Location = new Point(6, 54);
            label9.Name = "label9";
            label9.Size = new Size(149, 25);
            label9.TabIndex = 46;
            label9.Text = "Fecha Registro:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtTelefonoCliente);
            groupBox1.Controls.Add(txtDocumentoCliente);
            groupBox1.Controls.Add(txtNombreCliente);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(lblDocumentoCliente);
            groupBox1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(25, 37);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(330, 205);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos del Cliente";
            // 
            // txtTelefonoCliente
            // 
            txtTelefonoCliente.Location = new Point(119, 131);
            txtTelefonoCliente.Name = "txtTelefonoCliente";
            txtTelefonoCliente.Size = new Size(205, 34);
            txtTelefonoCliente.TabIndex = 53;
            // 
            // txtDocumentoCliente
            // 
            txtDocumentoCliente.Location = new Point(119, 91);
            txtDocumentoCliente.Name = "txtDocumentoCliente";
            txtDocumentoCliente.Size = new Size(205, 34);
            txtDocumentoCliente.TabIndex = 52;
            // 
            // txtNombreCliente
            // 
            txtNombreCliente.Location = new Point(119, 48);
            txtNombreCliente.Name = "txtNombreCliente";
            txtNombreCliente.Size = new Size(205, 34);
            txtNombreCliente.TabIndex = 51;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F);
            label1.Location = new Point(6, 128);
            label1.Name = "label1";
            label1.Size = new Size(96, 28);
            label1.TabIndex = 50;
            label1.Text = "Teléfono:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F);
            label2.Location = new Point(6, 91);
            label2.Name = "label2";
            label2.Size = new Size(118, 25);
            label2.TabIndex = 48;
            label2.Text = "Documento:";
            // 
            // lblDocumentoCliente
            // 
            lblDocumentoCliente.AutoSize = true;
            lblDocumentoCliente.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDocumentoCliente.Location = new Point(6, 54);
            lblDocumentoCliente.Name = "lblDocumentoCliente";
            lblDocumentoCliente.Size = new Size(87, 25);
            lblDocumentoCliente.TabIndex = 46;
            lblDocumentoCliente.Text = "Nombre:";
            // 
            // btnRegistrarPago
            // 
            btnRegistrarPago.BackColor = Color.Red;
            btnRegistrarPago.FlatStyle = FlatStyle.Popup;
            btnRegistrarPago.ForeColor = Color.White;
            btnRegistrarPago.Location = new Point(643, 644);
            btnRegistrarPago.Name = "btnRegistrarPago";
            btnRegistrarPago.Size = new Size(170, 55);
            btnRegistrarPago.TabIndex = 63;
            btnRegistrarPago.Text = "Registrar Pago";
            btnRegistrarPago.UseVisualStyleBackColor = false;
            btnRegistrarPago.Click += btnRegistrarPago_Click_1;
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
            dtCreditos.Size = new Size(1531, 786);
            dtCreditos.TabIndex = 6;
            // 
            // lblIDCliente
            // 
            lblIDCliente.AutoSize = true;
            lblIDCliente.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblIDCliente.Location = new Point(564, 45);
            lblIDCliente.Name = "lblIDCliente";
            lblIDCliente.Size = new Size(27, 32);
            lblIDCliente.TabIndex = 61;
            lblIDCliente.Text = "0";
            lblIDCliente.Visible = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(lblIDCliente);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1531, 114);
            panel1.TabIndex = 11;
            // 
            // label3
            // 
            label3.BackColor = Color.DodgerBlue;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(1531, 114);
            label3.TabIndex = 1;
            label3.Text = "Nuevo Credito";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmDetalleCredito
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1531, 900);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Name = "FrmDetalleCredito";
            Text = "FrmDetalleCredito";
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHistorialPagos).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtCreditos).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel3;
        private Button btnRegistrarPago;
        private Label lblIDCliente;
        private Label lblDocumentoCliente;
        private DataGridView dtCreditos;
        private Panel panel1;
        private Label label3;
        private GroupBox groupBox1;
        private Label label2;
        private GroupBox groupBox2;
        private Label label5;
        private Label label7;
        private Label label9;
        private Label label1;
        private GroupBox groupBox3;
        private Label label12;
        private Label label13;
        private Label label10;
        private Label label8;
        private Label label6;
        private Label label4;
        private DataGridView dgvHistorialPagos;
        private TextBox txtGananciaIntereses;
        private TextBox txtTotalPagado;
        private TextBox txtTelefonoCliente;
        private TextBox txtDocumentoCliente;
        private TextBox txtNombreCliente;
        private TextBox txtTasaInteres;
        private TextBox txtDiasRestantes;
        private TextBox txtEstadoCredito;
        private TextBox txtSaldoDisponible;
        private TextBox txtMontoTotal;
        private TextBox txtFechaRegistro;
        private TextBox txtFechaVencimiento;
    }
}