namespace Sopromil.Vista.Caja
{
    public partial class FrmAperturaCaja : Form
    {
        public decimal SaldoInicial { get; private set; }
        public bool CajaAbierta { get; private set; }

        public FrmAperturaCaja()
        {
            InitializeComponent();
            InicializarReloj();

            // Asignar eventos manualmente
            Load += FrmAperturaCaja_Load;
            btnActualizar.Click += btnAbrir_Click;
            button1.Click += btnCancelar_Click;
            txtSaldoInicial.KeyPress += txtSaldoInicial_KeyPress;

            CajaAbierta = false;
        }

        private void FrmAperturaCaja_Load(object sender, EventArgs e)
        {
            lblReloj.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void InicializarReloj()
        {
            relojTimer = new System.Windows.Forms.Timer();
            relojTimer.Interval = 1000; // 1 segundo
            relojTimer.Tick += (s, e) => lblReloj.Text = DateTime.Now.ToString("HH:mm:ss");
            relojTimer.Start();
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtSaldoInicial.Text, out decimal saldo) || saldo < 0)
            {
                MessageBox.Show("Ingrese un saldo inicial válido y mayor o igual a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaldoInicial = saldo;
            CajaAbierta = true;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CajaAbierta = false;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtSaldoInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Solo permite un punto decimal
            if (e.KeyChar == '.' && txtSaldoInicial.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void FrmAperturaCaja_Load_1(object sender, EventArgs e)
        {

        }
    }
}
