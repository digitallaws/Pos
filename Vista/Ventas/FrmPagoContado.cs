namespace Sopromil.Vista.Ventas
{
    public partial class FrmPagoContado : Form
    {
        public decimal PagoTotal { get; private set; } = 0;
        public bool VentaConfirmada { get; private set; } = false;

        public FrmPagoContado(decimal totalVenta)
        {
            InitializeComponent();
            lblTotalVenta.Text = $"Total: $ {totalVenta:N0}";
            txtPagoCon.KeyPress += TxtPagoCon_KeyPress;
            btnConfirmar.Click += BtnConfirmar_Click;
        }

        private void TxtPagoCon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b') e.Handled = true;
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
