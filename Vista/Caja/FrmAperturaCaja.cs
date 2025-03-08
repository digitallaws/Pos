using Sopromil.Controlador;
using Sopromil.Data.Repository;
using Sopromil.Modelo;

namespace Sopromil.Vista.Caja
{
    public partial class FrmAperturaCaja : Form
    {
        public decimal SaldoInicial { get; private set; }
        public bool CajaAbierta { get; private set; }
        private readonly CajaController _cajaController;

        public FrmAperturaCaja()
        {
            InitializeComponent();
            _cajaController = new CajaController();

            InicializarReloj();
            AsignarEventos();

            CajaAbierta = false;
        }

        private void AsignarEventos()
        {
            Load += FrmAperturaCaja_Load;
            btnActualizar.Click += btnAbrir_Click;
            button1.Click += btnCancelar_Click;
            txtSaldoInicial.KeyPress += txtSaldoInicial_KeyPress;
        }

        private async void FrmAperturaCaja_Load(object sender, EventArgs e)
        {
            lblReloj.Text = DateTime.Now.ToString("HH:mm:ss");

            var cajaAbierta = await _cajaController.ObtenerCajaAbiertaAsync();
            if (cajaAbierta != null)
            {
                MessageBox.Show("Ya existe una caja abierta. No puede abrir otra hasta que cierre la actual.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CajaAbierta = false;
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void InicializarReloj()
        {
            relojTimer = new System.Windows.Forms.Timer();
            relojTimer.Interval = 1000; // 1 segundo
            relojTimer.Tick += (s, e) => lblReloj.Text = DateTime.Now.ToString("HH:mm:ss");
            relojTimer.Start();
        }

        private async void btnAbrir_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtSaldoInicial.Text, out decimal saldo) || saldo < 0)
            {
                MessageBox.Show("Ingrese un saldo inicial válido y mayor o igual a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Capturar usuario actual
            int idUsuario = SesionActual.IDUsuario;

            // Abrir caja en BD
            int idMovimiento = await _cajaController.AbrirCajaAsync(idUsuario, saldo);

            if (idMovimiento > 0)
            {
                SaldoInicial = saldo;
                CajaAbierta = true;
                MessageBox.Show("Caja abierta correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("No se pudo abrir la caja. Revise la conexión o consulte con soporte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}
