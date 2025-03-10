using Sopromil.Controlador;
using Sopromil.Modelo;

namespace Sopromil.Vista.Login
{
    public partial class SeleccionPerfil : Form
    {
        private TableLayoutPanel Layout;
        private readonly UsuarioController _usuarioController;

        public SeleccionPerfil()
        {
            InitializeComponent();
            _usuarioController = new UsuarioController();
            ConfigurarInterfaz();
            _ = CargarUsuariosAsync(); // Llamada asíncrona para cargar usuarios
        }

        private void ConfigurarInterfaz()
        {
            this.Text = "Seleccionar Perfil";
            this.BackColor = Color.White;
            this.Size = new Size(900, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            Layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                BackColor = Color.White
            };

            Layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            Layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            var lblTitulo = new Label
            {
                Text = "Selecciona tu perfil",
                Font = new Font("Arial", 20, FontStyle.Bold),
                ForeColor = Color.Black,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 60,
                Padding = new Padding(10)
            };

            Layout.Controls.Add(lblTitulo, 0, 0);

            FlowLayoutPanel panelUsuarios = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(20),
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                BackColor = Color.White
            };

            Layout.Controls.Add(panelUsuarios, 0, 1);
            this.Controls.Add(Layout);
        }

        private async Task CargarUsuariosAsync()
        {
            List<Usuario> usuarios = await _usuarioController.ObtenerUsuariosActivosAsync();

            if (usuarios == null || usuarios.Count == 0)
            {
                MessageBox.Show("No hay usuarios activos disponibles.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            FlowLayoutPanel panelUsuarios = Layout.Controls[1] as FlowLayoutPanel;
            panelUsuarios.Controls.Clear();

            foreach (var usuario in usuarios)
            {
                Panel panelUsuario = new Panel
                {
                    Size = new Size(180, 220),
                    Margin = new Padding(20),
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.None
                };

                PictureBox avatar = new PictureBox
                {
                    Size = new Size(140, 140),
                    Image = Properties.Resources.user, // Imagen predeterminada
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Cursor = Cursors.Hand,
                    Dock = DockStyle.Top
                };

                Label lblNombre = new Label
                {
                    Text = usuario.Nombre, // Usar la propiedad correcta del modelo
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    ForeColor = Color.Black,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Bottom,
                    Height = 40
                };

                panelUsuario.MouseEnter += (s, e) => panelUsuario.BackColor = Color.LightGray;
                panelUsuario.MouseLeave += (s, e) => panelUsuario.BackColor = Color.White;

                // Evento al hacer clic en el panel o la imagen
                panelUsuario.Click += (s, e) => SeleccionarUsuario(usuario);
                avatar.Click += (s, e) => SeleccionarUsuario(usuario);

                panelUsuario.Controls.Add(lblNombre);
                panelUsuario.Controls.Add(avatar);
                panelUsuarios.Controls.Add(panelUsuario);
            }
        }

        private void SeleccionarUsuario(Usuario usuario)
        {
            var loginForm = new Login(usuario);
            this.Hide();
            loginForm.ShowDialog();
            this.Close();
        }
    }
}
