using Sopromil.Controlador;
using Sopromil.Modelo;

namespace Sopromil.Vista.Clientes
{
    public partial class FrmAbono : Form
    {
        private readonly PagoController _pagoController;
        private int _idCliente;

        public FrmAbono(int idCliente)
        {
            InitializeComponent();
            _pagoController = new PagoController();
            _idCliente = idCliente;

            ConfigurarDataGridView();
            CargarAbonos();
            CargarSaldoPendiente();
        }

        private void ConfigurarDataGridView()
        {
            dtAbonos.AllowUserToAddRows = false;
            dtAbonos.AllowUserToDeleteRows = false;
            dtAbonos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dtAbonos.BackgroundColor = Color.White;
            dtAbonos.ReadOnly = true;
            dtAbonos.RowHeadersVisible = false;
            dtAbonos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dtAbonos.DefaultCellStyle.Font = new Font("Arial", 13, FontStyle.Regular);
            dtAbonos.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 13, FontStyle.Bold);

            // 💠 Cambiar color de selección
            dtAbonos.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            dtAbonos.DefaultCellStyle.SelectionForeColor = Color.White;

            dtAbonos.Columns.Clear();
            dtAbonos.Columns.Add(new DataGridViewTextBoxColumn { Name = "IDPago", HeaderText = "ID Pago", Visible = false });
            dtAbonos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Fecha", HeaderText = "Fecha", Width = 150 });
            dtAbonos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Monto", HeaderText = "Monto Abonado", Width = 200, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "C2" } });
        }

        private async void CargarSaldoPendiente()
        {
            try
            {
                decimal saldoPendiente = await _pagoController.ObtenerSaldoPendienteAsync(_idCliente);
                lblCredito.Text = $"Saldo Pendiente: {saldoPendiente:C2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el saldo pendiente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void CargarAbonos()
        {
            List<Pago> abonos = await _pagoController.ObtenerAbonosPorClienteAsync(_idCliente);
            MostrarAbonosEnGrid(abonos);
        }

        private void MostrarAbonosEnGrid(List<Pago> abonos)
        {
            dtAbonos.Rows.Clear();

            foreach (var abono in abonos)
            {
                dtAbonos.Rows.Add(
                    abono.IDPago,
                    abono.FechaPago.ToString("dd/MM/yyyy"),
                    abono.MontoAbonado
                );
            }
        }

        private async void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtAbono.Text.Trim(), out decimal montoAbonado) || montoAbonado <= 0)
            {
                MessageBox.Show("Ingrese un monto válido mayor a 0.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool pagoExitoso = await _pagoController.AplicarPagoAsync(_idCliente, montoAbonado);

            if (pagoExitoso)
            {
                MessageBox.Show("✅ Pago registrado con éxito.", "Pago Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAbono.Clear();
                CargarAbonos(); // 🔥 Recargar la lista de abonos después de confirmar
            }
        }
    }
}
