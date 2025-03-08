using Sopromil.Controlador;

namespace Sopromil.Vista.Configuracion
{
    public partial class Impresora : Form
    {
        private readonly CajaController _cajaController;
        private string _impresoraSeleccionada;

        public Impresora()
        {
            InitializeComponent();
            _cajaController = new CajaController();

            btnSeleccionar.Click += BtnSeleccionar_Click;
            btnImprimir.Click += BtnImprimir_Click;
            btnSeleccionar.Click += BtnGuardarConfiguracionCaja_Click;

            CargarConfiguracionCaja();
        }

        /// <summary>
        /// Carga la configuración de la caja (solo la impresora) al iniciar.
        /// </summary>
        private async void CargarConfiguracionCaja()
        {
            try
            {
                var configuracionCaja = await _cajaController.ObtenerConfiguracionCajaAsync();
                if (configuracionCaja != null && !string.IsNullOrWhiteSpace(configuracionCaja.Impresora))
                {
                    _impresoraSeleccionada = configuracionCaja.Impresora;
                    txtImpresora.Text = _impresoraSeleccionada;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error al cargar la configuración de la caja: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Abre el cuadro de diálogo para seleccionar una impresora.
        /// </summary>
        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            using (PrintDialog pd = new PrintDialog())
            {
                if (pd.ShowDialog() == DialogResult.OK)
                {
                    _impresoraSeleccionada = pd.PrinterSettings.PrinterName;
                    txtImpresora.Text = _impresoraSeleccionada;
                }
            }
        }

        /// <summary>
        /// Simulación de impresión de prueba.
        /// </summary>
        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_impresoraSeleccionada))
            {
                MessageBox.Show("Seleccione una impresora primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show($"🖨️ Impresión de prueba enviada a: {_impresoraSeleccionada}", "Impresión Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Guarda la configuración de la impresora en la base de datos.
        /// </summary>
        private async void BtnGuardarConfiguracionCaja_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_impresoraSeleccionada))
            {
                MessageBox.Show("Seleccione una impresora antes de guardar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool resultado = await _cajaController.ConfigurarCajaAsync("Configuración de Caja", _impresoraSeleccionada, "", "Activa", 1);

            if (resultado)
            {
                MessageBox.Show("✅ Configuración guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("❌ Error al guardar la configuración de la caja.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
