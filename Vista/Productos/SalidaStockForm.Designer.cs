namespace Sopromil.Vista.Productos
{
    partial class SalidaStockForm
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
            label3 = new Label();
            panel4 = new Panel();
            lblProducto = new Label();
            btnConfirmar = new Button();
            btnCancelar = new Button();
            numCantidad = new NumericUpDown();
            label5 = new Label();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.BackColor = Color.DodgerBlue;
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(483, 70);
            label3.TabIndex = 34;
            label3.Text = "Salida Producto";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(lblProducto);
            panel4.Controls.Add(btnConfirmar);
            panel4.Controls.Add(btnCancelar);
            panel4.Controls.Add(numCantidad);
            panel4.Controls.Add(label5);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 70);
            panel4.Name = "panel4";
            panel4.Size = new Size(483, 272);
            panel4.TabIndex = 35;
            // 
            // lblProducto
            // 
            lblProducto.AutoSize = true;
            lblProducto.Font = new Font("Segoe UI Semibold", 14.2F, FontStyle.Bold);
            lblProducto.Location = new Point(193, 21);
            lblProducto.Name = "lblProducto";
            lblProducto.Size = new Size(113, 32);
            lblProducto.TabIndex = 43;
            lblProducto.Text = "Producto";
            // 
            // btnConfirmar
            // 
            btnConfirmar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnConfirmar.BackColor = Color.DodgerBlue;
            btnConfirmar.FlatStyle = FlatStyle.Popup;
            btnConfirmar.ForeColor = Color.White;
            btnConfirmar.Location = new Point(260, 162);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(143, 47);
            btnConfirmar.TabIndex = 42;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnCancelar.BackColor = Color.Red;
            btnCancelar.FlatStyle = FlatStyle.Popup;
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(88, 162);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(144, 47);
            btnCancelar.TabIndex = 41;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // numCantidad
            // 
            numCantidad.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            numCantidad.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numCantidad.Location = new Point(193, 87);
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(112, 34);
            numCantidad.TabIndex = 31;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12.2F, FontStyle.Bold);
            label5.Location = new Point(88, 91);
            label5.Name = "label5";
            label5.Size = new Size(99, 30);
            label5.TabIndex = 21;
            label5.Text = "Cantidad";
            // 
            // SalidaStockForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(483, 342);
            Controls.Add(panel4);
            Controls.Add(label3);
            Name = "SalidaStockForm";
            Text = "SalidaStockForm";
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label3;
        private Panel panel4;
        private Label label5;
        private NumericUpDown numCantidad;
        private Button btnConfirmar;
        private Button btnCancelar;
        private Label lblProducto;
    }
}