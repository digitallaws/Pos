using Sopromil.Controlador;
using Sopromil.Impresion;
using Sopromil.Utils;
using System.Drawing.Printing;

namespace Sopromil.Vista.Configuracion
{
    public partial class InicialConfiguracion : Form
    {
        private readonly CajaController _cajaController;
        private readonly EmpresaController _empresaController;

        public InicialConfiguracion()
        {
            InitializeComponent();
            _cajaController = new CajaController();
            _empresaController = new EmpresaController();

            btnSeleccionarImpresora.Click += BtnSeleccionarImpresora_Click;
            btnSeleccionarRuta.Click += BtnSeleccionarRuta_Click;
            btnGuardarConfiguracion.Click += BtnGuardarConfiguracion_Click;
            btnImprimirPrueba.Visible = false;

            // Cargar datos al iniciar
            CargarDatosEmpresa();
            CargarConfiguracionActual();
        }

        private async void CargarDatosEmpresa()
        {
            var empresa = await _empresaController.ObtenerEmpresaAsync();
            txtNombre.Text = empresa?.Nombre ?? "N/A";
            txtNit.Text = empresa?.NIT ?? "N/A";
            txtDireccion.Text = empresa?.Direccion ?? "N/A";
            txtTelefono.Text = empresa?.Telefono ?? "N/A";
        }

        private async void CargarConfiguracionActual()
        {
            var caja = await _cajaController.ObtenerConfiguracionCajaAsync();
            if (caja != null)
            {
                txtImpresora.Text = caja.Impresora;
                txtRutaCopiaSeguridad.Text = caja.CopiaSeguridad;
            }
        }

        private void BtnSeleccionarImpresora_Click(object sender, EventArgs e)
        {
            using (PrintDialog printDialog = new PrintDialog())
            {
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    txtImpresora.Text = printDialog.PrinterSettings.PrinterName;
                    btnImprimirPrueba.Visible = true;
                    btnImprimirPrueba.Enabled = true;
                }
            }
        }

        private void BtnSeleccionarRuta_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txtRutaCopiaSeguridad.Text = folderDialog.SelectedPath;
                }
            }
        }

        private async void BtnGuardarConfiguracion_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtImpresora.Text) || string.IsNullOrWhiteSpace(txtRutaCopiaSeguridad.Text))
            {
                MessageBox.Show("Debe seleccionar una impresora y una ruta de copia de seguridad.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var actualizado = await _cajaController.ActualizarConfiguracionImpresoraYCopiaAsync(txtImpresora.Text, txtRutaCopiaSeguridad.Text);

            if (actualizado)
            {
                MessageBox.Show("Configuración guardada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al guardar configuración.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
