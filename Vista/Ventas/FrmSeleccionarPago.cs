using Sopromil.Controlador;
using System.Globalization;

namespace Sopromil.Vista.Ventas
{
    public partial class FrmSeleccionarPago : Form
    {
        private readonly ClienteController _clienteController = new ClienteController();
        private readonly CreditoController _creditoController = new CreditoController();
        private readonly CultureInfo culturaColombiana = new CultureInfo("es-CO");

        public string TipoPago { get; private set; }
        public decimal MontoRecibido { get; private set; }
        public decimal Devuelta { get; private set; }
        public decimal TotalVenta { get; set; }
        public int IDCliente { get; private set; }
        private decimal CupoDisponible { get; set; }

        public FrmSeleccionarPago(decimal totalVenta)
        {
            InitializeComponent();
            TotalVenta = totalVenta;
        }

        private void FrmSeleccionarPago_Load(object sender, EventArgs e)
        {
            cmbTipoPago.Items.Add("Efectivo");
            cmbTipoPago.Items.Add("Crédito");
            cmbTipoPago.SelectedIndex = 0;

            MostrarOcultarCamposPago();
        }

        private void cmbTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarOcultarCamposPago();
        }

        private void MostrarOcultarCamposPago()
        {
            bool esEfectivo = cmbTipoPago.SelectedItem.ToString() == "Efectivo";
            bool esCredito = cmbTipoPago.SelectedItem.ToString() == "Crédito";

            lblMontoRecibido.Visible = esEfectivo;
            txtMontoRecibido.Visible = esEfectivo;
            lblDevuelta.Visible = esEfectivo;

            lblDocumentoCliente.Visible = esCredito;
            txtDocumentoCliente.Visible = esCredito;
            btnBuscarCliente.Visible = esCredito;
            lblCupoDisponible.Visible = esCredito;

            lblDevuelta.Text = "Devuelta: $0";
        }

        private void txtMontoRecibido_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtMontoRecibido.Text, out decimal montoRecibido))
            {
                MontoRecibido = montoRecibido;
                Devuelta = MontoRecibido - TotalVenta;
                lblDevuelta.Text = $"Devuelta: {Devuelta.ToString("C0", culturaColombiana)}";
            }
            else
            {
                lblDevuelta.Text = "Devuelta: $0";
            }
        }

        private async void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            string documento = txtDocumentoCliente.Text.Trim();

            if (string.IsNullOrWhiteSpace(documento))
            {
                MessageBox.Show("Ingrese un documento para buscar al cliente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var clientes = await _clienteController.ObtenerClientesAsync();
            var cliente = clientes.FirstOrDefault(c => c.IdentificadorFiscal == documento);

            if (cliente != null)
            {
                IDCliente = cliente.IDCliente;

                // Validar si tiene crédito activo
                var creditos = await _creditoController.ObtenerCreditosActivosAsync(IDCliente, null);

                if (creditos.Count == 0)
                {
                    MessageBox.Show("El cliente no tiene un crédito aprobado o activo. No puede realizar compras a crédito.",
                        "Crédito no disponible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    IDCliente = 0; // Resetear ID para prevenir errores
                    CupoDisponible = 0;
                    lblCupoDisponible.Text = $"Cupo Disponible: $0";
                    return;
                }

                // Obtener el saldo pendiente y calcular el cupo disponible
                decimal saldoPendiente = await _creditoController.ObtenerSaldoPendienteAsync(IDCliente, null);
                decimal cupoTotal = 2000000m;  // Si el cupo máximo está en la BD, lo puedes consultar desde Clientes
                CupoDisponible = cupoTotal - saldoPendiente;

                lblCupoDisponible.Text = $"Cupo Disponible: {CupoDisponible.ToString("C0", culturaColombiana)}";
            }
            else
            {
                MessageBox.Show("Cliente no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            TipoPago = cmbTipoPago.SelectedItem.ToString();

            if (TipoPago == "Efectivo")
            {
                if (MontoRecibido < TotalVenta)
                {
                    MessageBox.Show("El monto recibido es insuficiente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (TipoPago == "Crédito")
            {
                if (IDCliente <= 0)
                {
                    MessageBox.Show("Debe seleccionar un cliente válido para crédito.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (TotalVenta > CupoDisponible)
                {
                    MessageBox.Show("El total de la venta supera el cupo de crédito disponible.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
