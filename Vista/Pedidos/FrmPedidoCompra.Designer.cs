namespace Sopromil.Vista.Pedidos
{
    partial class FrmPedidoCompra
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
            PnlContenedor = new Panel();
            dtPedido = new DataGridView();
            panel2 = new Panel();
            btnEliminarFila = new Button();
            btnEditar = new Button();
            btnExcel = new Button();
            panel1 = new Panel();
            label3 = new Label();
            sqlCommandBuilder1 = new Microsoft.Data.SqlClient.SqlCommandBuilder();
            PnlContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtPedido).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // PnlContenedor
            // 
            PnlContenedor.BackColor = Color.White;
            PnlContenedor.Controls.Add(dtPedido);
            PnlContenedor.Controls.Add(panel2);
            PnlContenedor.Dock = DockStyle.Fill;
            PnlContenedor.Location = new Point(0, 114);
            PnlContenedor.Name = "PnlContenedor";
            PnlContenedor.Size = new Size(1156, 554);
            PnlContenedor.TabIndex = 16;
            // 
            // dtPedido
            // 
            dtPedido.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtPedido.Dock = DockStyle.Fill;
            dtPedido.Location = new Point(0, 125);
            dtPedido.Name = "dtPedido";
            dtPedido.RowHeadersWidth = 51;
            dtPedido.Size = new Size(1156, 429);
            dtPedido.TabIndex = 60;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnEliminarFila);
            panel2.Controls.Add(btnEditar);
            panel2.Controls.Add(btnExcel);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1156, 125);
            panel2.TabIndex = 59;
            // 
            // btnEliminarFila
            // 
            btnEliminarFila.BackColor = Color.Crimson;
            btnEliminarFila.FlatStyle = FlatStyle.Flat;
            btnEliminarFila.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEliminarFila.ForeColor = Color.White;
            btnEliminarFila.Location = new Point(679, 22);
            btnEliminarFila.Name = "btnEliminarFila";
            btnEliminarFila.Size = new Size(170, 78);
            btnEliminarFila.TabIndex = 59;
            btnEliminarFila.Text = "Eliminar Fila";
            btnEliminarFila.UseVisualStyleBackColor = false;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.CornflowerBlue;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(307, 22);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(170, 78);
            btnEditar.TabIndex = 57;
            btnEditar.Text = "Editar Cantidades";
            btnEditar.UseVisualStyleBackColor = false;
            // 
            // btnExcel
            // 
            btnExcel.BackColor = Color.LimeGreen;
            btnExcel.FlatStyle = FlatStyle.Flat;
            btnExcel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExcel.ForeColor = Color.White;
            btnExcel.Location = new Point(499, 22);
            btnExcel.Name = "btnExcel";
            btnExcel.Size = new Size(157, 78);
            btnExcel.TabIndex = 58;
            btnExcel.Text = "Exportar Excel";
            btnExcel.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1156, 114);
            panel1.TabIndex = 15;
            // 
            // label3
            // 
            label3.BackColor = Color.CornflowerBlue;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(1156, 114);
            label3.TabIndex = 1;
            label3.Text = "Sugerencia de Pedido";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmPedidoCompra
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1156, 668);
            Controls.Add(PnlContenedor);
            Controls.Add(panel1);
            Name = "FrmPedidoCompra";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pedidos";
            WindowState = FormWindowState.Maximized;
            PnlContenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtPedido).EndInit();
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel PnlContenedor;
        private Panel panel1;
        private Label label3;
        private Microsoft.Data.SqlClient.SqlCommandBuilder sqlCommandBuilder1;
        private Button btnExcel;
        private Button btnEditar;
        private Panel panel2;
        private DataGridView dtPedido;
        private Button btnEliminarFila;
    }
}