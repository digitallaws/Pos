using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            txtSaldoInicial.KeyPress += txtSaldoInicial_KeyPress;

            CajaAbierta = false;
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtSaldoInicial.Text, out decimal saldo))
            {
                MessageBox.Show("Ingrese un saldo inicial válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaldoInicial = saldo;
            CajaAbierta = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CajaAbierta = false;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void InicializarReloj()
        {
            relojTimer = new System.Windows.Forms.Timer();
            relojTimer.Interval = 1000; // 1 segundo
            relojTimer.Tick += RelojTimer_Tick;
            relojTimer.Start();

            // Mostrar la hora actual al abrir
            lblReloj.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void RelojTimer_Tick(object sender, EventArgs e)
        {
            lblReloj.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void txtSaldoInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite dígitos, punto decimal y la tecla de retroceso (backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Bloquea la tecla
            }

            // Solo permite un punto decimal
            if (e.KeyChar == '.' && txtSaldoInicial.Text.Contains("."))
            {
                e.Handled = true;
            }
        }
    }
}
