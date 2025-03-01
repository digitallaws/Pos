namespace Sopromil.Vista.Productos
{
    partial class cargaMasiva
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
            panel1 = new Panel();
            btnCancelar = new Button();
            btnConfirmar = new Button();
            dtMasivo = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtMasivo).BeginInit();
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
            label3.Size = new Size(1018, 72);
            label3.TabIndex = 2;
            label3.Text = "Carga Masiva";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnCancelar);
            panel1.Controls.Add(btnConfirmar);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 588);
            panel1.Name = "panel1";
            panel1.Size = new Size(1018, 75);
            panel1.TabIndex = 3;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Red;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancelar.Location = new Point(162, 8);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(243, 55);
            btnCancelar.TabIndex = 29;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnConfirmar
            // 
            btnConfirmar.BackColor = Color.DodgerBlue;
            btnConfirmar.FlatStyle = FlatStyle.Flat;
            btnConfirmar.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfirmar.ForeColor = Color.White;
            btnConfirmar.ImageAlign = ContentAlignment.MiddleLeft;
            btnConfirmar.Location = new Point(434, 8);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(243, 55);
            btnConfirmar.TabIndex = 28;
            btnConfirmar.Text = "Cargar productos";
            btnConfirmar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnConfirmar.UseVisualStyleBackColor = false;
            // 
            // dtMasivo
            // 
            dtMasivo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtMasivo.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dtMasivo.BackgroundColor = Color.White;
            dtMasivo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtMasivo.Dock = DockStyle.Fill;
            dtMasivo.Location = new Point(0, 72);
            dtMasivo.Name = "dtMasivo";
            dtMasivo.RowHeadersVisible = false;
            dtMasivo.RowHeadersWidth = 51;
            dtMasivo.Size = new Size(1018, 516);
            dtMasivo.TabIndex = 4;
            // 
            // cargaMasiva
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1018, 663);
            Controls.Add(dtMasivo);
            Controls.Add(panel1);
            Controls.Add(label3);
            Name = "cargaMasiva";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "cargaMasiva";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtMasivo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label3;
        private Panel panel1;
        private DataGridView dtMasivo;
        private Button btnConfirmar;
        private Button btnCancelar;
    }
}