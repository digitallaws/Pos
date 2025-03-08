using Sopromil.Controlador;
using Sopromil.Modelo;
using Sopromil.Vista.Dashboard;

namespace Sopromil.Vista.Login
{
    public partial class Login : Form
    {
        private readonly UsuarioController _usuarioController;
        private readonly Usuario _usuarioSeleccionado;
        private TableLayoutPanel Layout;
        private FlowLayoutPanel panelTeclado;
        private TextBox txtPassword;
        private PictureBox btnVerPassword;
        private Button btnLogin;
        private bool passwordVisible = false;

        public Login(Usuario usuarioSeleccionado)
        {
            InitializeComponent();

            _usuarioSeleccionado = usuarioSeleccionado;
            _usuarioController = new UsuarioController(); // Se instancia directamente el controlador

            ConfigurarInterfaz();
            CrearTeclado();
        }

        private void ConfigurarInterfaz()
        {
            this.Text = "Login";
            this.Size = new Size(600, 455);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;

            Layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 2,
                BackColor = Color.White,
                Padding = new Padding(20)
            };

            Layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            Layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            Layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            Layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            this.Controls.Add(Layout);

            Button btnVolver = new Button
            {
                Text = "Atrás",
                Font = new Font("Arial", 10, FontStyle.Bold),
                BackColor = Color.LightGray,
                FlatStyle = FlatStyle.Flat,
                Width = 80,
                Height = 30,
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };
            btnVolver.FlatAppearance.BorderSize = 0;
            btnVolver.Click += btnVolver_Click;
            Layout.Controls.Add(btnVolver, 0, 0);

            FlowLayoutPanel panelDatos = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown,
                Dock = DockStyle.Fill,
                Padding = new Padding(10),
                AutoSize = true
            };

            Label lblPassword = new Label
            {
                Text = "Ingrese su contraseña",
                Font = new Font("Arial", 10, FontStyle.Regular),
                ForeColor = Color.Black,
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleLeft
            };

            Panel passwordContainer = new Panel
            {
                Width = 235,
                Height = 40,
                BackColor = Color.Transparent
            };

            txtPassword = new TextBox
            {
                Font = new Font("Arial", 14),
                PasswordChar = '●',
                Width = 200,
                Location = new Point(0, 5),
                TextAlign = HorizontalAlignment.Left,
                TabIndex = 1

            };

            

            btnVerPassword = new PictureBox
            {
                Image = Properties.Resources.eye_closed,
                SizeMode = PictureBoxSizeMode.Zoom,
                Width = 30,
                Height = 30,
                Location = new Point(205, 5),
                Cursor = Cursors.Hand
            };
            btnVerPassword.Click += TogglePasswordVisibility;

            passwordContainer.Controls.Add(txtPassword);
            passwordContainer.Controls.Add(btnVerPassword);

            btnLogin = new Button
            {
                Text = "Login",
                Font = new Font("Arial", 12, FontStyle.Bold),
                BackColor = Color.DodgerBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Width = 230,
                Height = 40,
                Anchor = AnchorStyles.Left
            };
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Click += btnLogin_Click;

            panelDatos.Controls.Add(lblPassword);
            panelDatos.Controls.Add(passwordContainer);
            panelDatos.Controls.Add(btnLogin);

            txtPassword.KeyDown += TxtPassword_KeyDown;
            txtPassword.Focus();

            Layout.Controls.Add(panelDatos, 0, 1);

            panelTeclado = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                Dock = DockStyle.Fill,
                Padding = new Padding(10)
            };

            Layout.Controls.Add(panelTeclado, 1, 1);
        }

        // ✅ Detectar tecla Enter en el campo de contraseña
        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Simular clic en el botón de Login
                btnLogin.PerformClick();
                e.SuppressKeyPress = true; // Prevenir el sonido de la tecla Enter
            }
        }

        private void CrearTeclado()
        {
            int btnSize = 60;
            int columnas = 3;

            TableLayoutPanel tecladoLayout = new TableLayoutPanel
            {
                ColumnCount = columnas,
                RowCount = 4,
                Dock = DockStyle.Fill,
                AutoSize = true
            };

            for (int i = 0; i < columnas; i++)
            {
                tecladoLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3F));
            }

            for (int i = 1; i <= 9; i++)
            {
                var btn = new Button
                {
                    Text = i.ToString(),
                    Width = btnSize,
                    Height = btnSize,
                    Font = new Font("Arial", 14, FontStyle.Bold),
                    BackColor = Color.WhiteSmoke,
                    FlatStyle = FlatStyle.Flat
                };
                btn.Click += (s, e) => txtPassword.Text += btn.Text;
                tecladoLayout.Controls.Add(btn);
            }

            var btnBorrar = new Button
            {
                Text = "←",
                Width = btnSize,
                Height = btnSize,
                Font = new Font("Arial", 14, FontStyle.Bold),
                BackColor = Color.LightCoral,
                FlatStyle = FlatStyle.Flat
            };
            btnBorrar.Click += (s, e) => RemoveLastCharacter();
            tecladoLayout.Controls.Add(btnBorrar);

            var btn0 = new Button
            {
                Text = "0",
                Width = btnSize,
                Height = btnSize,
                Font = new Font("Arial", 14, FontStyle.Bold),
                BackColor = Color.WhiteSmoke,
                FlatStyle = FlatStyle.Flat
            };
            btn0.Click += (s, e) => txtPassword.Text += "0";
            tecladoLayout.Controls.Add(btn0);

            var btnClear = new Button
            {
                Text = "C",
                Width = btnSize,
                Height = btnSize,
                Font = new Font("Arial", 14, FontStyle.Bold),
                BackColor = Color.Orange,
                FlatStyle = FlatStyle.Flat
            };
            btnClear.Click += (s, e) => ClearPassword();
            tecladoLayout.Controls.Add(btnClear);

            panelTeclado.Controls.Add(tecladoLayout);
        }

        private void TogglePasswordVisibility(object sender, EventArgs e)
        {
            passwordVisible = !passwordVisible;
            txtPassword.PasswordChar = passwordVisible ? '\0' : '●';
            btnVerPassword.Image = passwordVisible ? Properties.Resources.eye_open : Properties.Resources.eye_closed;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string password = txtPassword.Text.Trim();

            try
            {
                bool loginExitoso = await _usuarioController.LoginUsuarioAsync(_usuarioSeleccionado.Login, password);

                if (loginExitoso)
                {
                    var vistaPrincipal = new FrmInicio();
                    this.Hide();
                    vistaPrincipal.ShowDialog();
                    this.Close();
                }
                else
                {
                    // El controlador ya maneja el mensaje de error
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al iniciar sesión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            var seleccionPerfilForm = new SeleccionPerfil();
            this.Hide();
            seleccionPerfilForm.ShowDialog();
            this.Close();
        }

        private void RemoveLastCharacter()
        {
            if (txtPassword.Text.Length > 0)
            {
                txtPassword.Text = txtPassword.Text.Substring(0, txtPassword.Text.Length - 1);
            }
        }

        private void ClearPassword()
        {
            txtPassword.Text = string.Empty;
        }
    }
}
