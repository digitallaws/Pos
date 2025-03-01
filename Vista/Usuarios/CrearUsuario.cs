using Microsoft.Data.SqlClient;
using Sopromil.Controlador;
using Sopromil.Modelo;
using Sopromil.Vista.Empresa;

namespace Sopromil.Vista.Usuarios
{
    public partial class CrearUsuario : Form
    {
        private readonly InitialSetupController _initialSetupController;
        private bool passwordVisible = false;
        private bool confirmPasswordVisible = false;

        public CrearUsuario(InitialSetupController initialSetupController)
        {
            InitializeComponent();
            _initialSetupController = initialSetupController;

            this.Load += CrearUsuario_Load;
        }

        private void CrearUsuario_Load(object sender, EventArgs e)
        {
            // Configurar eventos manualmente
            btnGuardar.Click += btnGuardar_Click;
            btnCancelar.Click += btnCancelar_Click;
            btnVerPassword.Click += (s, ev) => TogglePasswordVisibility();
            btnVerConfirmPassword.Click += (s, ev) => ToggleConfirmPasswordVisibility();

            // Permitir solo números en los campos de contraseña
            txtPassword.KeyPress += TxtPassword_KeyPress;
            txtConfirmarPassword.KeyPress += TxtPassword_KeyPress;

            // Configurar Rol como "Administrador" por defecto y bloquear cambios
            cmbRol.DataSource = Enum.GetValues(typeof(Rol));
            cmbRol.SelectedItem = Rol.Admin;
            cmbRol.Enabled = false; // Bloqueado para evitar cambios
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permitir números y teclas de control (Backspace, Delete, etc.)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Bloquea la entrada de caracteres no numéricos
            }
        }

        private void TogglePasswordVisibility()
        {
            passwordVisible = !passwordVisible;
            txtPassword.PasswordChar = passwordVisible ? '\0' : '●';
            btnVerPassword.Image = passwordVisible ? Properties.Resources.eye_open : Properties.Resources.eye_closed;
        }

        private void ToggleConfirmPasswordVisibility()
        {
            confirmPasswordVisible = !confirmPasswordVisible;
            txtConfirmarPassword.PasswordChar = confirmPasswordVisible ? '\0' : '●';
            btnVerConfirmPassword.Image = confirmPasswordVisible ? Properties.Resources.eye_open : Properties.Resources.eye_closed;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Pasar los datos al controlador sin realizar validaciones en el formulario
                await _initialSetupController.CrearUsuarioInicialAsync(
                    txtNombre.Text.Trim(),
                    txtUsuario.Text.Trim(),
                    txtPassword.Text.Trim()
                );

                // Si el controlador maneja el éxito, se muestra la siguiente vista
                CrearEmpresa seleccionPerfil = new CrearEmpresa();
                this.Hide();
                seleccionPerfil.Show();
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                MostrarMensajeError("El usuario ya existe. Por favor, elija otro nombre de usuario.");
            }
            catch (Exception ex)
            {
                MostrarMensajeError($"Error al crear usuario: {ex.Message}");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que deseas cancelar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void MostrarMensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
