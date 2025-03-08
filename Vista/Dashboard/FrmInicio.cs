using Sopromil.Controlador;
using Sopromil.Modelo;
using Sopromil.Vista.Caja;
using Sopromil.Vista.Clientes;
using Sopromil.Vista.Ventas;

namespace Sopromil.Vista.Dashboard
{
    public partial class FrmInicio : Form
    {
        private TableLayoutPanel tableLayoutPanel;
        private Form activeForm = null;
        private readonly CajaController _cajaController;
        private readonly Dictionary<string, Panel> panelModulos = new();

        public FrmInicio()
        {
            InitializeComponent();
            ConfigurarTableLayout();
            CargarModulos();
            btnVolver.Visible = false;

        }

        private void ConfigurarTableLayout()
        {
            tableLayoutPanel = new TableLayoutPanel
            {
                AutoSize = true,
                ColumnCount = 4,
                RowCount = 2,
                BackColor = Color.Transparent,
                Padding = new Padding(10)
            };

            for (int i = 0; i < tableLayoutPanel.ColumnCount; i++)
            {
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25f));
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

        private void CargarModulos()
        {
            var modulos = new Dictionary<string, Bitmap>
            {
                { "Proveedores", Properties.Resources.administracion_de_empresas },
                { "Clientes", Properties.Resources.cliente },
                { "Ventas", Properties.Resources.venta_al_por_mayor },
                { "Usuarios", Properties.Resources.user }
            };

            int index = 0;
            foreach (var modulo in modulos)
            {
                var panelModulo = CrearPanelModulo(modulo.Key, modulo.Value);
                int fila = index / 4;
                int columna = index % 4;

                tableLayoutPanel.Controls.Add(panelModulo, columna, fila);
                panelModulos[modulo.Key] = panelModulo;

                index++;
            }
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

            btnVolver.Visible = false;
        }

        private Panel CrearPanelModulo(string nombreModulo, Bitmap icono)
        {
            var panel = new Panel
            {
                Size = new Size(140, 140),
                BackColor = Color.White,
                Cursor = Cursors.Hand,
                Margin = new Padding(15),
                Tag = nombreModulo
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
                Text = nombreModulo,
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

            panel.Click += (s, e) => CargarFormularioModulo(nombreModulo);

            return panel;
        }

        private async void CargarFormularioModulo(string modulo)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }


            activeForm = modulo switch
            {
                "Proveedores" => new Proveedores(),
                "Clientes" => new FrmClientes(),
                "Ventas" => new FrmVentas(),
                "Usuarios" => new Usuarios.Usuarios(),
                _ => null
            };

            if (activeForm == null)
            {
                MessageBox.Show("Formulario no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            activeForm.TopLevel = false;
            activeForm.FormBorderStyle = FormBorderStyle.None;
            activeForm.Dock = DockStyle.Fill;

            btnVolver.Visible = true;

            PnlContenedor.Controls.Clear();
            PnlContenedor.Controls.Add(tableLayoutPanel);
            PnlContenedor.Controls.Add(activeForm);

            activeForm.BringToFront();
            activeForm.Show();
        }

        private async Task<bool> VerificarCajaAbierta()
        {
            // var cajaAbierta = await _cajaController.ObtenerCajaAbiertaAsync();
            // if (cajaAbierta != null) return true;

            var frmApertura = new FrmAperturaCaja();
            if (frmApertura.ShowDialog() == DialogResult.OK && frmApertura.CajaAbierta)
            {
                await _cajaController.AbrirCajaAsync(SesionActual.IDUsuario, frmApertura.SaldoInicial);
                return true;
            }

            MessageBox.Show("Debe abrir caja para ingresar a Ventas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
    }
}
