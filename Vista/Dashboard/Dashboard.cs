using Sopromil.Controlador;
using Sopromil.Modelo;
using Sopromil.Vista.Caja;
using Sopromil.Vista.Productos;

namespace Sopromil.Vista.Dashboard
{
    public partial class Dashboard : Form
    {
        private bool menuExpand = false;
        private const int ExpandedWidth = 250;
        private const int CollapsedWidth = 55;
        private const int AnimationSpeed = 40;
        private Form activeForm = null;
        private Usuario usuario;
        private readonly CajaController _cajaController = new();
        private Button btnOpciones;
        private ContextMenuStrip menuOpciones;
        private readonly Dictionary<string, Panel> panelModulos = new();

        public Dashboard()
        {
            InitializeComponent();
            Sidebar.Width = CollapsedWidth;
            CreateSidebarPanels();
            CrearBotonOpciones();

            if (SesionActual.EstaAutenticado)
            {
                lblNombre.Text = SesionActual.Nombre;
                lblRol.Text = SesionActual.Rol;

                if (SesionActual.Rol == "Admin")
                {
                    if (panelModulos.ContainsKey("Dashboard"))
                    {
                        var panelDashboard = panelModulos["Dashboard"];
                        LoadFormAsync("Dashboard", panelDashboard);
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay una sesión activa. Por favor inicie sesión.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void CrearBotonOpciones()
        {
            btnOpciones = new Button
            {
                Text = "▼",
                Width = 30,
                Height = 30,
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleCenter,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            btnOpciones.Location = new Point(panel2.Width - btnOpciones.Width - 5, 5);
            btnOpciones.Click += btnOpciones_Click;
            panel2.Controls.Add(btnOpciones);

            panel2.SizeChanged += (s, e) =>
            {
                btnOpciones.Location = new Point(panel2.Width - btnOpciones.Width - 5, 5);
            };

            ConfigurarMenuOpciones();
        }

        private void ConfigurarMenuOpciones()
        {
            menuOpciones = new ContextMenuStrip();
            menuOpciones.Items.Add("Cerrar Sesión", null, CerrarSesion_Click);
            menuOpciones.Items.Add("Cerrar Caja", null, CerrarCaja_Click);
        }

        private void btnOpciones_Click(object sender, EventArgs e)
        {
            menuOpciones.Show(btnOpciones, new Point(0, btnOpciones.Height));
        }

        private async void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            var cajaAbierta = await _cajaController.ObtenerCajaAbiertaAsync();
            if (cajaAbierta != null && cajaAbierta.Estado == "Abierta")
            {
                var frmCierre = new FrmCierreCaja(cajaAbierta.SaldoInicial);
                if (frmCierre.ShowDialog() == DialogResult.OK && frmCierre.CajaCerrada)
                {
                    await _cajaController.CerrarCajaAsync(cajaAbierta.IDMovimiento, SesionActual.IDUsuario, frmCierre.SaldoReal);
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void MenuH_Click(object sender, EventArgs e)
        {
            timerMenu.Interval = 1;
            timerMenu.Start();
        }

        private void CerrarSesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de cerrar sesión?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SesionActual.CerrarSesion();
                Application.Restart();
            }
        }

        private async void CerrarCaja_Click(object sender, EventArgs e)
        {
            var cajaAbierta = await _cajaController.ObtenerCajaAbiertaAsync();
            if (cajaAbierta != null && cajaAbierta.Estado == "Abierta")
            {
                var frmCierre = new FrmCierreCaja(cajaAbierta.SaldoInicial);
                if (frmCierre.ShowDialog() == DialogResult.OK && frmCierre.CajaCerrada)
                {
                    await _cajaController.CerrarCajaAsync(cajaAbierta.IDMovimiento, SesionActual.IDUsuario, frmCierre.SaldoReal);
                    MessageBox.Show("Caja cerrada correctamente.", "Cierre de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void timerMenu_Tick(object sender, EventArgs e)
        {
            Sidebar.Width += menuExpand ? -AnimationSpeed : AnimationSpeed;

            if (Sidebar.Width <= CollapsedWidth || Sidebar.Width >= ExpandedWidth)
            {
                menuExpand = !menuExpand;
                timerMenu.Stop();
            }

            UpdatePanelLayout();
            Sidebar.Refresh();
        }

        private void UpdatePanelLayout()
        {
            foreach (var panelButton in panelModulos.Values)
            {
                PictureBox pictureBox = panelButton.Controls.OfType<PictureBox>().FirstOrDefault();
                Label label = panelButton.Controls.OfType<Label>().FirstOrDefault();

                if (menuExpand)
                {
                    // Mostrar texto y ajustar el icono al expandir
                    if (label != null) label.Visible = true;
                    if (pictureBox != null)
                    {
                        pictureBox.Size = new Size(30, 30);
                        pictureBox.Location = new Point(10, 10);
                    }
                }
                else
                {
                    // Ocultar el texto al colapsar
                    if (label != null) label.Visible = false;
                    if (pictureBox != null)
                    {
                        pictureBox.Size = new Size(30, 30);
                        pictureBox.Location = new Point(10, 10);
                    }
                }
            }
        }

        private async Task<bool> VerificarCajaAbierta()
        {
            var cajaAbierta = await _cajaController.ObtenerCajaAbiertaAsync();

            if (cajaAbierta != null)
            {
                return true; // ✅ Caja ya está abierta
            }

            // ✅ Mostrar formulario de apertura de caja
            var frmApertura = new FrmAperturaCaja();
            if (frmApertura.ShowDialog() == DialogResult.OK && frmApertura.CajaAbierta)
            {
                int idUsuario = SesionActual.IDUsuario;
                await _cajaController.AbrirCajaAsync(idUsuario, frmApertura.SaldoInicial);
                return true;
            }
            else
            {
                // ✅ Si cancela, mostramos el Dashboard automáticamente
                MessageBox.Show("Debe abrir caja para ingresar a Ventas. Regresando al Dashboard.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadFormAsync("Dashboard", panelModulos["Dashboard"]);
                return false;
            }
        }



        private void CreateSidebarPanels()
        {
            var moduleNames = new List<string> { "Dashboard", "Usuarios", "Clientes", "Ventas", "Creditos", "Inventario", "Categorias" };
            var moduleIcons = new List<Bitmap>
            {
                Properties.Resources.analisis_de_negocios,
                Properties.Resources.administracion_de_empresas,
                Properties.Resources.cliente,
                Properties.Resources.colateral,
                Properties.Resources.analisis_de_negocios,
                Properties.Resources.inventario,
                Properties.Resources.aplicacion
            };

            var permisosPorRol = new Dictionary<string, List<string>>
            {
                { "Admin", moduleNames },
                { "Vendedor", new List<string> { "Dashboard", "Clientes", "Ventas", "Creditos" } },
                { "Cajero", new List<string> { "Ventas" } }
            };

            var rolUsuario = SesionActual.Rol;
            if (!permisosPorRol.ContainsKey(rolUsuario))
            {
                MessageBox.Show("Rol no válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            var modulosPermitidos = permisosPorRol[rolUsuario];
            int panelTop = 10;

            for (int i = 0; i < modulosPermitidos.Count; i++)
            {
                var modulo = modulosPermitidos[i];

                var panelButton = new Panel
                {
                    Width = ExpandedWidth - 10,
                    Height = 50,
                    BackColor = Color.LightGray,
                    Top = panelTop,
                    Left = 5,
                    Tag = modulo
                };

                var icono = new PictureBox
                {
                    Image = moduleIcons[i],
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Size = new Size(30, 30),
                    Location = new Point(10, 10)
                };

                var label = new Label
                {
                    Text = modulo,
                    Location = new Point(50, 15),
                    Font = new Font("Arial", 10, FontStyle.Bold)
                };

                panelButton.Click += (s, e) => LoadFormAsync(modulo, panelButton);
                icono.Click += (s, e) => LoadFormAsync(modulo, panelButton);
                label.Click += (s, e) => LoadFormAsync(modulo, panelButton);

                panelButton.Controls.Add(icono);
                panelButton.Controls.Add(label);

                Sidebar.Controls.Add(panelButton);
                panelModulos[modulo] = panelButton;
                panelTop += panelButton.Height + 5;
            }
        }

        private async Task LoadFormAsync(string formName, Panel panelSeleccionado)
        {
            if (activeForm != null)
            {
                if (activeForm.Tag?.ToString() == formName)
                    return;

                activeForm.Close();
                if (activeForm.Tag != null && panelModulos.ContainsKey(activeForm.Tag.ToString()))
                {
                    panelModulos[activeForm.Tag.ToString()].Enabled = true;
                }
            }

            if (formName == "Ventas")
            {
                if (!await VerificarCajaAbierta())
                {
                    // ✅ No abrimos el formulario de Ventas y regresamos
                    return;
                }
            }

            activeForm = formName switch
            {
                "Dashboard" => new Estadisticas(),
                "Usuarios" => new Usuarios.Usuarios(),
                "Clientes" => new Clientes.Clientes(),
                "Ventas" => new Ventas.FormVenta(),
                "Creditos" => new Creditos.FrmGestionCreditos(),
                "Categorias" => new Categorias(),
                "Inventario" => new Productos.FormProductos(),
                _ => null
            };

            if (activeForm == null)
            {
                MessageBox.Show("Formulario no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            activeForm.Tag = formName;
            activeForm.TopLevel = false;
            activeForm.FormBorderStyle = FormBorderStyle.None;
            activeForm.Dock = DockStyle.Fill;

            Content.Controls.Clear();
            Content.Controls.Add(activeForm);
            activeForm.Show();

            panelSeleccionado.Enabled = false;
        }
    }
}
