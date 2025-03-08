using Sopromil.Controlador;

namespace Sopromil.Vista.Caja
{
    public partial class frmMovimientoExtraCaja : Form
    {
        private readonly CajaController _cajaController;
        private readonly int _idMovimiento;

        public frmMovimientoExtraCaja(int idMovimiento, CajaController cajaController)
        {
            InitializeComponent();
            _cajaController = cajaController ?? throw new ArgumentNullException(nameof(cajaController));
            _idMovimiento = idMovimiento;

            // Asociar eventos directamente
            this.Load += frmMovimientoExtraCaja_Load;
            btnGuardar.Click += btnGuardar_Click;
            btnCancelar.Click += btnCancelar_Click;
        }

        private void frmMovimientoExtraCaja_Load(object sender, EventArgs e)
        {
            cbTipoMovimiento.Items.Add("IngresoExtra");
            cbTipoMovimiento.Items.Add("EgresoExtra");
            cbTipoMovimiento.SelectedIndex = 0;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos(out decimal monto, out string descripcion))
                return;

            string tipoMovimiento = cbTipoMovimiento.SelectedItem.ToString();

            try
            {
                bool registrado = await _cajaController.RegistrarMovimientoExtraAsync(_idMovimiento, tipoMovimiento, monto, descripcion);
                if (registrado)
                {
                    MessageBox.Show($"El {tipoMovimiento} fue registrado correctamente.", "Movimiento Registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el movimiento extra. Revise la conexión o intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(btnGuardar_Click));
                MostrarErrorAlUsuario("Ocurrió un error inesperado al registrar el movimiento extra.\nPor favor, intente nuevamente.", ex);
            }
        }

        private bool ValidarDatos(out decimal monto, out string descripcion)
        {
            monto = 0;
            descripcion = txtDescripcion.Text.Trim();

            if (string.IsNullOrWhiteSpace(txtMonto.Text) || !decimal.TryParse(txtMonto.Text, out monto) || monto <= 0)
            {
                MessageBox.Show("Debe ingresar un monto válido mayor a cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(descripcion))
            {
                MessageBox.Show("Debe ingresar una descripción del movimiento.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LogError(Exception ex, string metodo)
        {
            try
            {
                string logPath = "logErrores.txt";
                string mensaje = $"[{DateTime.Now:dd/MM/yyyy HH:mm:ss}] Error en {metodo}: {ex.Message}{Environment.NewLine}";
                System.IO.File.AppendAllText(logPath, mensaje);
            }
            catch
            {
                // Si hay un error al escribir el log, no detiene el programa.
            }
        }

        private void MostrarErrorAlUsuario(string mensajeAmigable, Exception ex)
        {
            MessageBox.Show($"{mensajeAmigable}\n\nDetalle Técnico: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
