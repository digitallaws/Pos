using Sopromil.Controlador;
using Sopromil.Vista.Configuracion;
using System.Text.RegularExpressions;

namespace Sopromil.Vista.Empresa
{
    public partial class CrearEmpresa : Form
    {
        private readonly EmpresaController _empresaController;
        private byte[] logoBytes = null;

        public string Modo { get; set; } = "Crear";  // Puede ser "Crear" o "Editar"

        public CrearEmpresa()
        {
            InitializeComponent();
            _empresaController = new EmpresaController();

            btnRegistrar.Click += BtnRegistrar_Click;

            // Validaciones
            txtNombre.KeyPress += ValidarLetras;
            txtIdentificadorFiscal.KeyPress += ValidarLetrasYNumeros;
            txtDireccion.KeyPress += ValidarDireccion;
            txtTelefono.KeyPress += ValidarNumeros;
            txtCorreo.Leave += ValidarCorreo;

            this.Load += CrearEmpresa_Load;
        }

        private async void CrearEmpresa_Load(object sender, EventArgs e)
        {
            if (Modo == "Editar")
            {
                btnRegistrar.Text = "Actualizar";
                await CargarDatosEmpresa();
            }
        }

        private async Task CargarDatosEmpresa()
        {
            var empresa = await _empresaController.ObtenerEmpresaAsync();
            if (empresa != null)
            {
                txtNombre.Text = empresa.Nombre;
                txtIdentificadorFiscal.Text = empresa.NIT;
                txtDireccion.Text = empresa.Direccion;
                txtTelefono.Text = empresa.Telefono;
                txtCorreo.Text = empresa.Correo;
                logoBytes = empresa.Logo;
            }
        }

        private void BtnSeleccionarLogo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Imágenes (*.jpg;*.png;*.jpeg)|*.jpg;*.png;*.jpeg";
                openFileDialog.Title = "Seleccionar Logo";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    logoBytes = File.ReadAllBytes(openFileDialog.FileName);
                }
            }
        }

        private async void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                var empresa = new Modelo.Empresa
                {
                    Nombre = txtNombre.Text.Trim(),
                    NIT = txtIdentificadorFiscal.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Correo = txtCorreo.Text.Trim(),
                    Moneda = "COP",
                    Logo = logoBytes
                };

                if (Modo == "Crear")
                {
                    await _empresaController.RegistrarEmpresaAsync(empresa);
                    MessageBox.Show("Empresa registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 🔹 Registro inicial -> abrir configuración
                    this.Hide();
                    InicialConfiguracion configForm = new InicialConfiguracion();
                    configForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    await _empresaController.ActualizarEmpresaAsync(empresa);
                    MessageBox.Show("Datos de la empresa actualizados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MostrarMensajeError($"Error al guardar la empresa: {ex.Message}");
            }
        }

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

        private bool EsCorreoValido(string correo) => Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        private bool EsNumeroValido(string numero) => Regex.IsMatch(numero, @"^\d+$");

        private void MostrarMensajeError(string mensaje) => MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        // ✅ Validaciones específicas de entrada
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
