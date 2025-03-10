namespace Sopromil.Vista.Ventas
{
    public partial class FrmPagoContado : Form
    {
        public decimal PagoTotal { get; private set; } = 0;
        public bool VentaConfirmada { get; private set; } = false;

        public FrmPagoContado(decimal totalVenta)
        {
            InitializeComponent();
            PagoTotal = totalVenta;
            lblTotalVenta.Text = $"Total: $ {PagoTotal:N0}";
            txtPagoCon.KeyPress += TxtPagoCon_KeyPress;
            txtPagoCon.TextChanged += TxtPagoCon_TextChanged;
            btnConfirmar.Click += BtnConfirmar_Click;
        }

        private void TxtPagoCon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b') e.Handled = true;
        }

        private void TxtPagoCon_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtPagoCon.Text, out decimal pagoCon))
            {
                decimal cambio = pagoCon - PagoTotal;
                lblVueltos.Text = cambio >= 0 ? $"Vueltos: $ {cambio:N0}" : "Vueltos: $ 0";
            }
            else
            {
                lblVueltos.Text = "Vueltos: $ 0";
            }
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtPagoCon.Text, out decimal pagoCon) || pagoCon < PagoTotal)
            {
                MessageBox.Show("El monto pagado es insuficiente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal cambio = pagoCon - PagoTotal;
            VentaConfirmada = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
