namespace Sopromil.Vista.Ventas
{
    public partial class FrmSeleccionTipoPago : Form
    {
        public string TipoPagoSeleccionado { get; private set; } = ""; // 🔥 Se almacena la selección

        public FrmSeleccionTipoPago()
        {
            InitializeComponent();
            btnCredito.Click += BtnCredito_Click;
            btnContado.Click += BtnContado_Click;
        }

        private void BtnCredito_Click(object sender, EventArgs e)
        {
            TipoPagoSeleccionado = "Crédito";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnContado_Click(object sender, EventArgs e)
        {
            TipoPagoSeleccionado = "Contado";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
