using Sopromil.Controlador;
using System.Globalization;

namespace Sopromil.Vista.Caja
{
    public partial class FrmCierreCaja : Form
    {
        private readonly CajaController _cajaController = new CajaController();
        private readonly CultureInfo culturaColombiana = new CultureInfo("es-CO");

        public decimal SaldoInicial { get; set; }
        public decimal VentasDesdeApertura { get; set; }
        public decimal MovimientosExtra { get; set; }
        public decimal SaldoReal { get; private set; }
        public decimal Descuadre { get; private set; }
        public bool CajaCerrada { get; private set; }

        public FrmCierreCaja(decimal saldoInicial)
        {
            InitializeComponent();
            InicializarReloj();
            SaldoInicial = saldoInicial;
            CajaCerrada = false;

            AsignarEventos();
        }

        private void AsignarEventos()
        {
            Load += FrmCierreCaja_Load;
            txtSaldoReal.TextChanged += txtSaldoReal_TextChanged;
            txtSaldoReal.KeyPress += txtSaldoReal_KeyPress;
            btnActualizar.Click += btnCerrarCaja_Click;
            btnCancelar.Click += btnCancelar_Click;
        }

        private async void FrmCierreCaja_Load(object sender, EventArgs e)
        {
            await CargarDatosDesdeApertura();
            MostrarDatosIniciales();

            lblReloj.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void InicializarReloj()
        {
            relojTimer = new System.Windows.Forms.Timer
            {
                Interval = 1000
            };
            relojTimer.Tick += (s, e) => lblReloj.Text = DateTime.Now.ToString("HH:mm:ss");
            relojTimer.Start();
        }

        private async Task CargarDatosDesdeApertura()
        {
            VentasDesdeApertura = await _cajaController.CalcularVentasDesdeAperturaCajaAsync();
            MovimientosExtra = await _cajaController.CalcularMovimientosExtraDesdeAperturaAsync();
            decimal ventasCredito = await _cajaController.CalcularVentasCreditoDesdeAperturaAsync();

            lblVentasCredito.Text = $"Ventas a Crédito: {ventasCredito.ToString("C0", culturaColombiana)}";  // Mostrar en UI
        }

        private void MostrarDatosIniciales()
        {
            decimal saldoTeorico = SaldoInicial + VentasDesdeApertura + MovimientosExtra;

            lblSaldoInicial.Text = $"Saldo Inicial: {SaldoInicial.ToString("C0", culturaColombiana)}";
            lblVentasDelDia.Text = $"Ventas Contado: {VentasDesdeApertura.ToString("C0", culturaColombiana)}";
            lblMovimientosExtra.Text = $"Movimientos Extra: {MovimientosExtra.ToString("C0", culturaColombiana)}";
            lblSaldoTeorico.Text = $"Saldo Teórico: {saldoTeorico.ToString("C0", culturaColombiana)}";
            lblDescuadre.Text = "Descuadre: $0";
        }

        private void txtSaldoReal_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtSaldoReal.Text, out decimal saldoReal))
            {
                SaldoReal = saldoReal;
                ActualizarDescuadre();
            }
            else
            {
                lblDescuadre.Text = "Descuadre: $0";
            }
        }

        private void txtSaldoReal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && txtSaldoReal.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void ActualizarDescuadre()
        {
            decimal saldoTeorico = SaldoInicial + VentasDesdeApertura + MovimientosExtra;
            Descuadre = SaldoReal - saldoTeorico;
            lblDescuadre.Text = $"Descuadre: {Descuadre.ToString("C0", culturaColombiana)}";
        }

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtSaldoReal.Text, out decimal saldoReal))
            {
                MessageBox.Show("Ingrese un saldo real válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaldoReal = saldoReal;
            ActualizarDescuadre();

            // Aquí solo marca que la caja fue cerrada
            CajaCerrada = true;

            // ✅ Eliminamos la impresión, el cierre se registra pero el ticket lo sacará otro proceso.
            MessageBox.Show("Caja cerrada correctamente. El cuadre se ha registrado.", "Cierre de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CajaCerrada = false;
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
