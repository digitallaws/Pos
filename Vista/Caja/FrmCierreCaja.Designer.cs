namespace Sopromil.Vista.Caja
{
    partial class FrmCierreCaja
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
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            btnCancelar = new Button();
            lblMovimientosExtra = new Label();
            lblDescuadre = new Label();
            lblSaldoTeorico = new Label();
            lblVentasDelDia = new Label();
            lblSaldoInicial = new Label();
            label2 = new Label();
            btnActualizar = new Button();
            lblReloj = new Label();
            label1 = new Label();
            label4 = new Label();
            txtSaldoReal = new TextBox();
            label3 = new Label();
            relojTimer = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnCancelar);
            panel1.Controls.Add(lblMovimientosExtra);
            panel1.Controls.Add(lblDescuadre);
            panel1.Controls.Add(lblSaldoTeorico);
            panel1.Controls.Add(lblVentasDelDia);
            panel1.Controls.Add(lblSaldoInicial);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnActualizar);
            panel1.Controls.Add(lblReloj);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtSaldoReal);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 114);
            panel1.Name = "panel1";
            panel1.Size = new Size(734, 375);
            panel1.TabIndex = 5;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Red;
            btnCancelar.FlatStyle = FlatStyle.Popup;
            btnCancelar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(176, 145);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(119, 50);
            btnCancelar.TabIndex = 41;
            btnCancelar.Tag = "5";
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // lblMovimientosExtra
            // 
            lblMovimientosExtra.AutoSize = true;
            lblMovimientosExtra.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMovimientosExtra.Location = new Point(373, 195);
            lblMovimientosExtra.Name = "lblMovimientosExtra";
            lblMovimientosExtra.Size = new Size(96, 31);
            lblMovimientosExtra.TabIndex = 40;
            lblMovimientosExtra.Text = "10:00:00";
            // 
            // lblDescuadre
            // 
            lblDescuadre.AutoSize = true;
            lblDescuadre.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescuadre.Location = new Point(373, 236);
            lblDescuadre.Name = "lblDescuadre";
            lblDescuadre.Size = new Size(96, 31);
            lblDescuadre.TabIndex = 39;
            lblDescuadre.Text = "10:00:00";
            // 
            // lblSaldoTeorico
            // 
            lblSaldoTeorico.AutoSize = true;
            lblSaldoTeorico.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSaldoTeorico.Location = new Point(373, 153);
            lblSaldoTeorico.Name = "lblSaldoTeorico";
            lblSaldoTeorico.Size = new Size(96, 31);
            lblSaldoTeorico.TabIndex = 38;
            lblSaldoTeorico.Text = "10:00:00";
            // 
            // lblVentasDelDia
            // 
            lblVentasDelDia.AutoSize = true;
            lblVentasDelDia.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVentasDelDia.Location = new Point(373, 111);
            lblVentasDelDia.Name = "lblVentasDelDia";
            lblVentasDelDia.Size = new Size(96, 31);
            lblVentasDelDia.TabIndex = 37;
            lblVentasDelDia.Text = "10:00:00";
            // 
            // lblSaldoInicial
            // 
            lblSaldoInicial.AutoSize = true;
            lblSaldoInicial.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSaldoInicial.Location = new Point(373, 71);
            lblSaldoInicial.Name = "lblSaldoInicial";
            lblSaldoInicial.Size = new Size(96, 31);
            lblSaldoInicial.TabIndex = 36;
            lblSaldoInicial.Text = "10:00:00";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label2.Location = new Point(330, 21);
            label2.Name = "label2";
            label2.Size = new Size(194, 32);
            label2.TabIndex = 35;
            label2.Text = "Resumen de la Z";
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.DodgerBlue;
            btnActualizar.FlatStyle = FlatStyle.Popup;
            btnActualizar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(26, 145);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(131, 50);
            btnActualizar.TabIndex = 33;
            btnActualizar.Text = "Cerrar";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnCerrarCaja_Click;
            // 
            // lblReloj
            // 
            lblReloj.AutoSize = true;
            lblReloj.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblReloj.Location = new Point(82, 293);
            lblReloj.Name = "lblReloj";
            lblReloj.Size = new Size(101, 32);
            lblReloj.TabIndex = 12;
            lblReloj.Text = "10:00:00";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label1.Location = new Point(54, 236);
            label1.Name = "label1";
            label1.Size = new Size(174, 32);
            label1.TabIndex = 11;
            label1.Text = "Hora de Cierre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label4.Location = new Point(54, 22);
            label4.Name = "label4";
            label4.Size = new Size(162, 32);
            label4.TabIndex = 10;
            label4.Text = "Saldo en Caja";
            // 
            // txtSaldoReal
            // 
            txtSaldoReal.BorderStyle = BorderStyle.FixedSingle;
            txtSaldoReal.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSaldoReal.Location = new Point(26, 73);
            txtSaldoReal.Name = "txtSaldoReal";
            txtSaldoReal.Size = new Size(269, 38);
            txtSaldoReal.TabIndex = 6;
            txtSaldoReal.Tag = "1";
            txtSaldoReal.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.BackColor = Color.DodgerBlue;
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(734, 114);
            label3.TabIndex = 4;
            label3.Text = "Cierre de Caja";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmCierreCaja
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(734, 489);
            Controls.Add(panel1);
            Controls.Add(label3);
            Name = "FrmCierreCaja";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmCierreCaja";
            Load += FrmCierreCaja_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnActualizar;
        private Label lblReloj;
        private Label label1;
        private Label label4;
        private TextBox txtSaldoReal;
        private Label label3;
        private Label label2;
        private Label lblSaldoTeorico;
        private Label lblVentasDelDia;
        private Label lblSaldoInicial;
        private Label lblDescuadre;
        private Label lblMovimientosExtra;
        private Button btnCancelar;
        private System.Windows.Forms.Timer relojTimer;
    }
}