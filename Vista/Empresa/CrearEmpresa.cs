using Sopromil.Controlador;
using Sopromil.Vista.Configuracion;
using System.Text.RegularExpressions;

namespace Sopromil.Vista.Empresa
{
    public partial class CrearEmpresa : Form
    {
        private readonly InitialSetupController _initialSetupController;
        private byte[] logoBytes = null;

        public CrearEmpresa()
        {
            InitializeComponent();
            _initialSetupController = new InitialSetupController();

            // Asignar eventos
            btnSeleccionarLogo.Click += BtnSeleccionarLogo_Click;
            btnRegistrar.Click += BtnRegistrar_Click;

            // Validaciones de entrada en tiempo real
            txtNombre.KeyPress += ValidarLetras;
            txtIdentificadorFiscal.KeyPress += ValidarLetrasYNumeros;
            txtDireccion.KeyPress += ValidarDireccion;
            txtTelefono.KeyPress += ValidarNumeros;
            txtCorreo.Leave += ValidarCorreo;
        }

        // 📌 Seleccionar Logo
        private void BtnSeleccionarLogo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Imágenes (*.jpg;*.png;*.jpeg)|*.jpg;*.png;*.jpeg";
                openFileDialog.Title = "Seleccionar Logo";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string rutaImagen = openFileDialog.FileName;
                    logoBytes = File.ReadAllBytes(rutaImagen);

                    // Mostrar la imagen en el PictureBox
                    picLogo.Image = Image.FromFile(rutaImagen);
                    picLogo.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        // 📌 Función para registrar la empresa en la base de datos
        private async void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                await _initialSetupController.CrearEmpresaAsync(
                    txtNombre.Text.Trim(),
                    txtIdentificadorFiscal.Text.Trim(),
                    txtDireccion.Text.Trim(),
                    txtTelefono.Text.Trim(),
                    txtCorreo.Text.Trim(),
                    "COP", // Moneda por defecto
                    logoBytes
                );

                // 🔹 Redirección a InicialConfiguracion
                this.Hide();
                InicialConfiguracion configForm = new InicialConfiguracion();
                configForm.ShowDialog();

                this.Close();
            }
            catch (Exception ex)
            {
                MostrarMensajeError($"Error al registrar la empresa: {ex.Message}");
            }
        }

        // 📌 Validaciones de los campos antes de enviar la información
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MostrarMensajeError("El nombre de la empresa es obligatorio.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtIdentificadorFiscal.Text))
            {
                MostrarMensajeError("El identificador fiscal es obligatorio.");
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtCorreo.Text) && !EsCorreoValido(txtCorreo.Text))
            {
                MostrarMensajeError("El formato del correo electrónico no es válido.");
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtTelefono.Text) && !EsNumeroValido(txtTelefono.Text))
            {
                MostrarMensajeError("El teléfono debe contener solo números.");
                return false;
            }

            return true;
        }

        private bool EsCorreoValido(string correo)
        {
            string patronCorreo = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(correo, patronCorreo);
        }

        private bool EsNumeroValido(string numero)
        {
            return Regex.IsMatch(numero, @"^\d+$"); // Solo números
        }

        private void MostrarMensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // ✅ Métodos para restringir caracteres en los campos de entrada
        private void ValidarLetras(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void ValidarLetrasYNumeros(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ValidarDireccion(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void ValidarNumeros(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ValidarCorreo(object sender, EventArgs e)
        {
            if (!EsCorreoValido(txtCorreo.Text))
            {
                MostrarMensajeError("Formato de correo inválido. Ejemplo: correo@ejemplo.com");
                txtCorreo.Focus();
            }
        }
    }
}
