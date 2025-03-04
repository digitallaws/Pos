using Sopromil.Controlador;
using Sopromil.Modelo;
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

            // ✅ Forzar el evento Load desde el constructor
            Load += FrmSeleccionarPago_Load;

            // ✅ Asignar eventos a controles manualmente
            InicializarEventos();
        }

        private void InicializarEventos()
        {
            cmbTipoPago.SelectedIndexChanged += cmbTipoPago_SelectedIndexChanged;
            txtMontoRecibido.TextChanged += txtMontoRecibido_TextChanged;
            btnBuscarCliente.Click += async (s, e) => await BuscarClienteAsync();
            btnActualizar.Click += btnAceptar_Click;
            button1.Click += btnCancelar_Click;
        }

        private void FrmSeleccionarPago_Load(object sender, EventArgs e)
        {
            // ✅ Aquí cargamos el combo manualmente (esto es lo que te estaba fallando)
            cmbTipoPago.Items.Clear();
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

            // ✅ Mostrar y ocultar los campos según el tipo de pago
            lblMontoRecibido.Visible = esEfectivo;
            txtMontoRecibido.Visible = esEfectivo;
            lblDevuelta.Visible = esEfectivo;

            lblDocumentoCliente.Visible = esCredito;
            txtDocumentoCliente.Visible = esCredito;
            btnBuscarCliente.Visible = esCredito;
            lblCupoDisponible.Visible = esCredito;

            txtMontoRecibido.Clear();
            lblDevuelta.Text = "Devuelta: $0";

            LimpiarCupo();
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

        private async Task BuscarClienteAsync()
        {
            string documento = txtDocumentoCliente.Text.Trim();

            if (string.IsNullOrWhiteSpace(documento))
            {
                MessageBox.Show("Ingrese un documento para buscar al cliente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var clientes = await _clienteController.ObtenerClientesAsync();
            var cliente = clientes.FirstOrDefault(c => c.IdentificadorFiscal == documento);

            if (cliente == null)
            {
                MessageBox.Show("Cliente no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarCupo();
                return;
            }

            IDCliente = cliente.IDCliente;

            await CargarCupoDisponibleAsync();
        }

        private async Task CargarCupoDisponibleAsync()
        {
            var creditos = await _creditoController.ObtenerTodosLosCreditosActivosAsync();
            var credito = creditos.FirstOrDefault(c => c.IDCliente == IDCliente && c.Estado == "Pendiente");

            if (credito == null)
            {
                MessageBox.Show("El cliente no tiene crédito activo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LimpiarCupo();
                return;
            }

            CupoDisponible = credito.Saldo;
            lblCupoDisponible.Text = $"Cupo Disponible: {CupoDisponible.ToString("C0", culturaColombiana)}";
        }

        private void LimpiarCupo()
        {
            IDCliente = 0;
            CupoDisponible = 0;
            lblCupoDisponible.Text = "Cupo Disponible: $0";
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
                    MessageBox.Show("El total de la venta supera el cupo disponible.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
    }
}
