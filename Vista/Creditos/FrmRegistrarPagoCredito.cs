using Sopromil.Controlador;

namespace Sopromil.Vista.Creditos
{
    public partial class FrmRegistrarPagoCredito : Form
    {
        public decimal MontoPagado { get; private set; }
        private readonly int _idCredito;
        private readonly CreditoController _creditoController;

        public FrmRegistrarPagoCredito(int idCredito)
        {
            InitializeComponent();
            _idCredito = idCredito;
            _creditoController = new CreditoController();

            btnRegistrar.Click += BtnRegistrar_Click;
            btnCancelar.Click += BtnCancelar_Click;
            txtMontoPago.KeyPress += TxtMontoPago_KeyPress;
        }

        private async void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtMontoPago.Text.Trim(), out decimal monto) || monto <= 0)
            {
                MessageBox.Show("Ingrese un monto válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                await _creditoController.RegistrarPagoCreditoAsync(_idCredito, monto, 0);  // Interés 0 porque es pago directo
                MontoPagado = monto;
                MessageBox.Show("Pago registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void TxtMontoPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && txtMontoPago.Text.Contains("."))
            {
                e.Handled = true;
            }
        }
    }
}
