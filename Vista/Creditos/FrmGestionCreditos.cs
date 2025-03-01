using Sopromil.Controlador;
using Sopromil.Modelo;

namespace Sopromil.Vista.Creditos
{
    public partial class FrmGestionCreditos : Form
    {
        private readonly CreditoController _creditoController = new CreditoController();

        public FrmGestionCreditos()
        {
            InitializeComponent();
        }

        private async void FrmGestionCreditos_Load(object sender, EventArgs e)
        {
            await CargarCreditos();
        }

        private async Task CargarCreditos(string filtro = "")
        {
            dtCreditos.Rows.Clear();
            List<Credito> creditos = new();

            if (string.IsNullOrWhiteSpace(filtro))
            {
                creditos = await _creditoController.ObtenerCreditosActivosAsync(null, null);
            }
            else
            {
                creditos = await _creditoController.ObtenerCreditosActivosAsync(null, filtro);
            }

            foreach (var credito in creditos)
            {
                int diasRestantes = (credito.FechaVencimiento - DateTime.Now).Days;
                string estadoVencimiento = diasRestantes < 0 ? "VENCIDO" : $"{diasRestantes} días";

                var fila = new DataGridViewRow();
                fila.CreateCells(dtCreditos,
                    credito.IDCredito,
                    credito.FechaRegistro.ToShortDateString(),
                    credito.FechaVencimiento.ToShortDateString(),
                    credito.Total.ToString("C0"),
                    credito.Saldo.ToString("C0"),
                    credito.Estado,
                    estadoVencimiento
                );

                if (diasRestantes < 0)
                {
                    fila.DefaultCellStyle.ForeColor = Color.Red;
                }

                dtCreditos.Rows.Add(fila);
            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim();
            await CargarCreditos(filtro);
        }

        private void btnNuevoCredito_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmGestionarCredito())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _ = CargarCreditos();
                }
            }
        }
    }
}
