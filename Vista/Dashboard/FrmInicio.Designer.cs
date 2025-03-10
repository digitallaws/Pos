namespace Sopromil.Vista.Dashboard
{
    partial class FrmInicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInicio));
            label3 = new Label();
            PnlContenedor = new Panel();
            btnVolver = new Button();
            button1 = new Button();
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
            label3.Size = new Size(917, 109);
            label3.TabIndex = 2;
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // PnlContenedor
            // 
            PnlContenedor.Dock = DockStyle.Fill;
            PnlContenedor.Location = new Point(0, 109);
            PnlContenedor.Name = "PnlContenedor";
            PnlContenedor.Size = new Size(917, 462);
            PnlContenedor.TabIndex = 3;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(12, 25);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(97, 49);
            btnVolver.TabIndex = 5;
            btnVolver.Text = "Atras";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(778, 25);
            button1.Name = "button1";
            button1.Size = new Size(117, 49);
            button1.TabIndex = 6;
            button1.Text = "Cerrar Sesión";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FrmInicio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(917, 571);
            Controls.Add(button1);
            Controls.Add(btnVolver);
            Controls.Add(PnlContenedor);
            Controls.Add(label3);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmInicio";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmInicio";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
        }

        #endregion

        private Label label3;
        private Panel PnlContenedor;
        private Button btnVolver;
        private Button button1;
    }
}