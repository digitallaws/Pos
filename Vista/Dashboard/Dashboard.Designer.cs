namespace Sopromil.Vista.Dashboard
{
    partial class Dashboard
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
            MenuH = new PictureBox();
            panel3 = new Panel();
            panel2 = new Panel();
            lblNombre = new Label();
            lblRol = new Label();
            pictureBox2 = new PictureBox();
            Sidebar = new Panel();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            timerMenu = new System.Windows.Forms.Timer(components);
            Content = new Panel();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MenuH).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(MenuH);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1593, 77);
            panel1.TabIndex = 0;
            // 
            // MenuH
            // 
            MenuH.BackColor = Color.White;
            MenuH.Dock = DockStyle.Left;
            MenuH.Image = Properties.Resources.menu;
            MenuH.Location = new Point(10, 0);
            MenuH.Name = "MenuH";
            MenuH.Size = new Size(37, 77);
            MenuH.SizeMode = PictureBoxSizeMode.Zoom;
            MenuH.TabIndex = 2;
            MenuH.TabStop = false;
            MenuH.Click += MenuH_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(10, 77);
            panel3.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblNombre);
            panel2.Controls.Add(lblRol);
            panel2.Controls.Add(pictureBox2);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(1382, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(211, 77);
            panel2.TabIndex = 0;
            // 
            // lblNombre
            // 
            lblNombre.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombre.Location = new Point(48, 0);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(104, 50);
            lblNombre.TabIndex = 9;
            lblNombre.Text = "Aldair";
            lblNombre.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRol
            // 
            lblRol.Location = new Point(48, 50);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(121, 27);
            lblRol.TabIndex = 8;
            lblRol.Text = "Admin";
            lblRol.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            pictureBox2.Dock = DockStyle.Left;
            pictureBox2.Image = Properties.Resources.user;
            pictureBox2.Location = new Point(0, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(48, 77);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // Sidebar
            // 
            Sidebar.Dock = DockStyle.Left;
            Sidebar.Location = new Point(0, 77);
            Sidebar.Name = "Sidebar";
            Sidebar.Size = new Size(299, 929);
            Sidebar.TabIndex = 1;
            // 
            // timerMenu
            // 
            timerMenu.Tick += timerMenu_Tick;
            // 
            // Content
            // 
            Content.Dock = DockStyle.Fill;
            Content.Location = new Point(299, 77);
            Content.Name = "Content";
            Content.Size = new Size(1294, 929);
            Content.TabIndex = 2;
            Content.Paint += Content_Paint;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1593, 1006);
            Controls.Add(Content);
            Controls.Add(Sidebar);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard";
            WindowState = FormWindowState.Maximized;
            FormClosing += Dashboard_FormClosing;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MenuH).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox MenuH;
        private Panel panel3;
        private Panel panel2;
        private PictureBox pictureBox2;
        private Label lblNombre;
        private Label lblRol;
        private Panel Sidebar;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Panel Indicadores;
        private System.Windows.Forms.Timer timerMenu;
        private Panel Content;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
    }
}