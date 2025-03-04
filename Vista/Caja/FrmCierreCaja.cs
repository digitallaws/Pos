using Sopromil.Controlador;
using System.Drawing.Printing;
using System.Globalization;

namespace Sopromil.Vista.Caja
{
    public partial class FrmCierreCaja : Form
    {
        private readonly CajaController _cajaController = new CajaController();
        private readonly CultureInfo culturaColombiana = new CultureInfo("es-CO");

        private PrintDocument printDocument;
        private string impresoraConfigurada;

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

            // Eventos asignados por código
            Load += FrmCierreCaja_Load;
            txtSaldoReal.TextChanged += txtSaldoReal_TextChanged;
            txtSaldoReal.KeyPress += txtSaldoReal_KeyPress;
            btnActualizar.Click += btnCerrarCaja_Click;
            btnCancelar.Click += btnCancelar_Click;
        }

        private async void FrmCierreCaja_Load(object sender, EventArgs e)
        {
            await CargarDatosDesdeApertura();
            await CargarImpresora();
            MostrarDatosIniciales();

            lblReloj.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void InicializarReloj()
        {
            relojTimer = new System.Windows.Forms.Timer();
            relojTimer.Interval = 1000; // 1 segundo
            relojTimer.Tick += (s, e) => lblReloj.Text = DateTime.Now.ToString("HH:mm:ss");
            relojTimer.Start();
        }

        private async Task CargarDatosDesdeApertura()
        {
            VentasDesdeApertura = await _cajaController.CalcularVentasDesdeAperturaCajaAsync();
            MovimientosExtra = await _cajaController.CalcularMovimientosExtraDesdeAperturaAsync();
        }

        private async Task CargarImpresora()
        {
            impresoraConfigurada = await _cajaController.ObtenerImpresoraAsync();
        }

        private void MostrarDatosIniciales()
        {
            decimal saldoTeorico = SaldoInicial + VentasDesdeApertura + MovimientosExtra;

            lblSaldoInicial.Text = $"Saldo Inicial: {SaldoInicial.ToString("C0", culturaColombiana)}";
            lblVentasDelDia.Text = $"Ventas desde Apertura: {VentasDesdeApertura.ToString("C0", culturaColombiana)}";
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
            CajaCerrada = true;

            ImprimirCierreZ();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CajaCerrada = false;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        // ======================================
        //          IMPRESIÓN DE CIERRE Z
        // ======================================
        private void ImprimirCierreZ()
        {
            try
            {
                printDocument = new PrintDocument();
                printDocument.PrinterSettings.PrinterName = impresoraConfigurada;
                printDocument.PrintPage += PrintDocument_PrintPage;
                printDocument.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al imprimir el cierre de caja (Z).\n{ex.Message}", "Error de impresión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            DibujarTicketCierreZ(e.Graphics);
        }

        private void DibujarTicketCierreZ(Graphics g)
        {
            Font fontNormal = new Font("Arial", 10);
            Font fontBold = new Font("Arial", 12, FontStyle.Bold);
            Font fontLargeBold = new Font("Arial", 14, FontStyle.Bold);

            float y = 10;

            g.DrawString("CIERRE DE CAJA - REPORTE Z", fontLargeBold, Brushes.Black, new PointF(30, y));
            y += 25;

            g.DrawLine(Pens.Black, 10, y, 280, y);
            y += 10;

            g.DrawString($"Fecha: {DateTime.Now:yyyy-MM-dd}", fontNormal, Brushes.Black, new PointF(10, y));
            y += 20;
            g.DrawString($"Hora: {DateTime.Now:HH:mm:ss}", fontNormal, Brushes.Black, new PointF(10, y));
            y += 20;

            g.DrawLine(Pens.Black, 10, y, 280, y);
            y += 10;

            g.DrawString("RESUMEN DE CAJA", fontBold, Brushes.Black, new PointF(10, y));
            y += 20;

            g.DrawString($"Saldo Inicial: {SaldoInicial.ToString("C0", culturaColombiana)}", fontNormal, Brushes.Black, new PointF(10, y));
            y += 20;
            g.DrawString($"Ventas: {VentasDesdeApertura.ToString("C0", culturaColombiana)}", fontNormal, Brushes.Black, new PointF(10, y));
            y += 20;
            g.DrawString($"Movimientos Extra: {MovimientosExtra.ToString("C0", culturaColombiana)}", fontNormal, Brushes.Black, new PointF(10, y));
            y += 20;

            decimal saldoTeorico = SaldoInicial + VentasDesdeApertura + MovimientosExtra;
            g.DrawString($"Saldo Teórico: {saldoTeorico.ToString("C0", culturaColombiana)}", fontBold, Brushes.Black, new PointF(10, y));
            y += 25;

            g.DrawString($"Saldo Real Contado: {SaldoReal.ToString("C0", culturaColombiana)}", fontBold, Brushes.Black, new PointF(10, y));
            y += 25;

            g.DrawLine(Pens.Black, 10, y, 280, y);
            y += 10;

            g.DrawString($"Descuadre: {Descuadre.ToString("C0", culturaColombiana)}", fontLargeBold, Brushes.Black, new PointF(10, y));
            y += 30;

            g.DrawLine(Pens.Black, 10, y, 280, y);
            y += 20;

            g.DrawString("Gracias por su trabajo.", fontNormal, Brushes.Black, new PointF(10, y));
            y += 20;
            g.DrawString("*** Fin del Cierre de Caja ***", fontBold, Brushes.Black, new PointF(30, y));
        }
    }
}
