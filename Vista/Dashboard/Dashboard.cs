using Sopromil.Controlador;
using Sopromil.Modelo;
using Sopromil.Vista.Caja;
using Sopromil.Vista.Creditos;
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
        private Dictionary<string, Panel> panelModulos = new();

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
                    LoadFormAsync("Dashboard");
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

        private void CreateSidebarPanels()
        {
            var moduleNames = new List<string> { "Dashboard", "Usuarios", "Clientes", "Ventas", "Creditos", "Inventario", "Categorias" };
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

            foreach (var modulo in modulosPermitidos)
            {
                var panelButton = new Panel
                {
                    Width = ExpandedWidth - 10,
                    Height = 50,
                    BackColor = Color.LightGray,
                    Top = panelTop,
                    Left = 5,
                    Tag = modulo
                };

                panelButton.Click += (s, e) => LoadFormAsync(modulo, panelButton);

                panelButton.Controls.Add(new Label
                {
                    Text = modulo,
                    Location = new Point(50, 15),
                    Font = new Font("Arial", 10, FontStyle.Bold)
                });

                Sidebar.Controls.Add(panelButton);
                panelModulos[modulo] = panelButton;
                panelTop += panelButton.Height + 5;
            }
        }

        private async Task LoadFormAsync(string formName, Panel panelSeleccionado = null)
        {
            if (activeForm != null)
            {
                if (activeForm.Tag?.ToString() == formName)
                    return;

                activeForm.Close();
                panelModulos[activeForm.Tag.ToString()].Enabled = true;
            }

            if (panelSeleccionado == null && panelModulos.ContainsKey(formName))
                panelSeleccionado = panelModulos[formName];

            if (formName == "Ventas" && !await VerificarCajaAbierta())
            {
                MessageBox.Show("Debe abrir caja antes de iniciar ventas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            activeForm = formName switch
            {
                "Dashboard" => new Estadisticas(),
                "Usuarios" => new Usuarios.Usuarios(),
                "Clientes" => new Clientes.Clientes(),
                "Ventas" => new Ventas.Venta(),
                "Creditos" => new FrmGestionCreditos(),
                "Categorias" => new Categorias(),
                "Inventario" => new Productos.Productos(),
                _ => throw new InvalidOperationException("Formulario no encontrado.")
            };

            activeForm.Tag = formName;
            activeForm.TopLevel = false;
            activeForm.FormBorderStyle = FormBorderStyle.None;
            activeForm.Dock = DockStyle.Fill;

            Content.Controls.Clear();
            Content.Controls.Add(activeForm);
            activeForm.Show();

            panelSeleccionado.Enabled = false;
        }

        private async Task<bool> VerificarCajaAbierta()
        {
            var caja = await _cajaController.ObtenerCajaAbiertaAsync();
            if (caja != null) return true;

            var frmApertura = new FrmAperturaCaja();
            if (frmApertura.ShowDialog() == DialogResult.OK && frmApertura.CajaAbierta)
            {
                await _cajaController.AbrirCajaAsync(SesionActual.IDUsuario, frmApertura.SaldoInicial);
                return true;
            }

            return false;
        }
        private void UpdatePanelLayout()
        {
            foreach (Control control in Sidebar.Controls)
            {
                if (control is Panel panelButton)
                {
                    PictureBox pictureBox = panelButton.Controls.OfType<PictureBox>().FirstOrDefault();
                    Label label = panelButton.Controls.OfType<Label>().FirstOrDefault();

                    if (menuExpand)
                    {
                        // Mostrar el texto y reposicionar el ícono
                        if (label != null) label.Visible = true;
                        if (pictureBox != null)
                        {
                            pictureBox.Size = new Size(30, 30); // Tamaño original
                            pictureBox.Location = new Point(10, 10); // Pegado a la izquierda
                        }
                    }
                    else
                    {
                        // Ocultar el texto y mantener el ícono en su posición original
                        if (label != null) label.Visible = false;
                        if (pictureBox != null)
                        {
                            pictureBox.Size = new Size(30, 30); // Evita que se expanda
                            pictureBox.Location = new Point(10, 10); // Pegado a la izquierda
                        }
                    }
                }
            }
        }

        private void Content_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
