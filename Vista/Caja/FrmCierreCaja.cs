using Sopromil.Controlador;
using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sopromil.Vista.Caja
{
    public partial class FrmCierreCaja : Form
    {
        private readonly CajaController _cajaController = new CajaController();
        private readonly CultureInfo culturaColombiana = new CultureInfo("es-CO");

        public decimal SaldoInicial { get; set; }
        public decimal VentasDesdeApertura { get; set; }
        public decimal SaldoReal { get; private set; }
        public decimal Descuadre { get; private set; }
        public bool CajaCerrada { get; private set; }

        public FrmCierreCaja(decimal saldoInicial)
        {
            InitializeComponent();
            SaldoInicial = saldoInicial;
            CajaCerrada = false;

            txtSaldoReal.TextChanged += txtSaldoReal_TextChanged;
        }

        private async void FrmCierreCaja_Load(object sender, EventArgs e)
        {
            await CargarVentasDesdeApertura();
            MostrarDatosIniciales();
        }

        private async Task CargarVentasDesdeApertura()
        {
            VentasDesdeApertura = await _cajaController.CalcularVentasDesdeAperturaCajaAsync();
        }

        private void MostrarDatosIniciales()
        {
            lblSaldoInicial.Text = $"Saldo Inicial: {SaldoInicial.ToString("C0", culturaColombiana)}";
            lblVentasDelDia.Text = $"Ventas desde Apertura: {VentasDesdeApertura.ToString("C0", culturaColombiana)}";
            lblSaldoTeorico.Text = $"Saldo Teórico: {(SaldoInicial + VentasDesdeApertura).ToString("C0", culturaColombiana)}";

            lblDescuadre.Text = "Descuadre: $0";
        }

        private void txtSaldoReal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSaldoReal_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtSaldoReal.Text, out decimal saldoReal))
            {
                SaldoReal = saldoReal;
                Descuadre = SaldoReal - (SaldoInicial + VentasDesdeApertura);
                lblDescuadre.Text = $"Descuadre: {Descuadre.ToString("C0", culturaColombiana)}";
            }
            else
            {
                lblDescuadre.Text = "Descuadre: $0";
            }
        }

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtSaldoReal.Text, out decimal saldoReal))
            {
                MessageBox.Show("Ingrese un saldo real válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaldoReal = saldoReal;
            Descuadre = SaldoReal - (SaldoInicial + VentasDesdeApertura);

            lblDescuadre.Text = $"Descuadre: {Descuadre.ToString("C0", culturaColombiana)}";
            CajaCerrada = true;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
