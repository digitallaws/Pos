namespace Sopromil.Vista.Caja
{
    partial class FrmAperturaCaja
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
            label3 = new Label();
            panel1 = new Panel();
            button1 = new Button();
            btnActualizar = new Button();
            lblReloj = new Label();
            label1 = new Label();
            label4 = new Label();
            txtSaldoInicial = new TextBox();
            relojTimer = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label3
            // 
            label3.BackColor = Color.CornflowerBlue;
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(527, 114);
            label3.TabIndex = 2;
            label3.Text = "Apertura de Caja";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(btnActualizar);
            panel1.Controls.Add(lblReloj);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtSaldoInicial);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 114);
            panel1.Name = "panel1";
            panel1.Size = new Size(527, 336);
            panel1.TabIndex = 3;
            // 
            // button1
            // 
            button1.BackColor = Color.Red;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(275, 133);
            button1.Name = "button1";
            button1.Size = new Size(131, 50);
            button1.TabIndex = 34;
            button1.Text = "Cancelar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += btnCancelar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.CornflowerBlue;
            btnActualizar.FlatStyle = FlatStyle.Popup;
            btnActualizar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(125, 133);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(131, 50);
            btnActualizar.TabIndex = 33;
            btnActualizar.Text = "Abrir";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnAbrir_Click;
            // 
            // lblReloj
            // 
            lblReloj.AutoSize = true;
            lblReloj.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblReloj.Location = new Point(215, 268);
            lblReloj.Name = "lblReloj";
            lblReloj.Size = new Size(101, 32);
            lblReloj.TabIndex = 12;
            lblReloj.Text = "10:00:00";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label1.Location = new Point(164, 220);
            label1.Name = "label1";
            label1.Size = new Size(207, 32);
            label1.TabIndex = 11;
            label1.Text = "Hora de Apertura";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label4.Location = new Point(179, 21);
            label4.Name = "label4";
            label4.Size = new Size(162, 32);
            label4.TabIndex = 10;
            label4.Text = "Saldo en Caja";
            // 
            // txtSaldoInicial
            // 
            txtSaldoInicial.BorderStyle = BorderStyle.FixedSingle;
            txtSaldoInicial.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSaldoInicial.Location = new Point(153, 69);
            txtSaldoInicial.Name = "txtSaldoInicial";
            txtSaldoInicial.Size = new Size(218, 38);
            txtSaldoInicial.TabIndex = 6;
            txtSaldoInicial.Tag = "1";
            txtSaldoInicial.TextAlign = HorizontalAlignment.Center;
            // 
            // FrmAperturaCaja
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(527, 450);
            Controls.Add(panel1);
            Controls.Add(label3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmAperturaCaja";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmAperturaCaja";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label3;
        private Panel panel1;
        private System.Windows.Forms.Timer relojTimer;
        private TextBox txtSaldoInicial;
        private Label lblReloj;
        private Label label1;
        private Label label4;
        private Button button1;
        private Button btnActualizar;
    }
}