namespace Sopromil.Vista.Reportes
{
    public partial class Reportes : Form
    {
        private TableLayoutPanel tableLayoutPanel;
        private Form activeForm = null;
        private readonly Dictionary<string, Panel> panelReportes = new();

        public Reportes()
        {
            InitializeComponent();
            ConfigurarTableLayout();
            CargarModulosReportes();
        }

        private void ConfigurarTableLayout()
        {
            tableLayoutPanel = new TableLayoutPanel
            {
                AutoSize = true,
                ColumnCount = 3,
                RowCount = 2,
                BackColor = Color.Transparent,
                Padding = new Padding(10)
            };

            for (int i = 0; i < tableLayoutPanel.ColumnCount; i++)
            {
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33f));
            }

            for (int i = 0; i < tableLayoutPanel.RowCount; i++)
            {
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
            }

            PnlContenedor.Controls.Add(tableLayoutPanel);
            PnlContenedor.Resize += (s, e) => CentrarTabla(tableLayoutPanel);
        }

        private void CentrarTabla(Control control)
        {
            if (control.Parent != null)
            {
                control.Left = (PnlContenedor.ClientSize.Width - control.Width) / 2;
                control.Top = (PnlContenedor.ClientSize.Height - control.Height) / 2;
            }
        }

        private void CargarModulosReportes()
        {
            var reportes = new Dictionary<string, Bitmap>
            {
                { "Ventas", Properties.Resources.venta_al_por_mayor },
                { "Compras", Properties.Resources.folder },
            };

            int index = 0;
            foreach (var reporte in reportes)
            {
                var panelReporte = CrearPanelReporte(reporte.Key, reporte.Value);
                int fila = index / 3;
                int columna = index % 3;

                tableLayoutPanel.Controls.Add(panelReporte, columna, fila);
                panelReportes[reporte.Key] = panelReporte;

                index++;
            }
        }

        private Panel CrearPanelReporte(string nombreReporte, Bitmap icono)
        {
            var panel = new Panel
            {
                Size = new Size(140, 140),
                BackColor = Color.White,
                Cursor = Cursors.Hand,
                Margin = new Padding(15),
                Tag = nombreReporte
            };

            var pictureBox = new PictureBox
            {
                Image = icono,
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(70, 70),
                Location = new Point((panel.Width - 70) / 2, 15)
            };

            var label = new Label
            {
                Text = nombreReporte,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Bottom,
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.Black,
                Height = 30
            };

            panel.Controls.Add(pictureBox);
            panel.Controls.Add(label);

            panel.MouseEnter += (s, e) => panel.BackColor = Color.LightSkyBlue;
            panel.MouseLeave += (s, e) => panel.BackColor = Color.White;

            panel.Click += (s, e) => CargarFormularioReporte(nombreReporte);

            return panel;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm = null;
            }

            PnlContenedor.Controls.Clear();
            PnlContenedor.Controls.Add(tableLayoutPanel);

        }

        private void CargarFormularioReporte(string reporte)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = reporte switch
            {
                "Ventas" => new FrmReporteVentas(),
                "Compras" => new FrmReporteCompras(),
                _ => null
            };

            if (activeForm == null)
            {
                MessageBox.Show("Reporte no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            activeForm.TopLevel = false;
            activeForm.FormBorderStyle = FormBorderStyle.None;
            activeForm.Dock = DockStyle.Fill;


            PnlContenedor.Controls.Clear();
            PnlContenedor.Controls.Add(tableLayoutPanel);
            PnlContenedor.Controls.Add(activeForm);

            activeForm.BringToFront();
            activeForm.Show();
        }
    }
}
