using Sopromil.Controlador;
using Sopromil.Modelo;

namespace Sopromil.Vista.Clientes
{
    public partial class FrmAbono : Form
    {
        private readonly PagoController _pagoController;
        private int _idCliente;
        private decimal saldoPendiente; // ✅ Variable para manejar el saldo pendiente actual

        public FrmAbono(int idCliente)
        {
            InitializeComponent();
            _pagoController = new PagoController();
            _idCliente = idCliente;

            ConfigurarDataGridView();
            CargarAbonos();
            CargarSaldoPendiente();

            txtAbono.TextChanged += TxtAbono_TextChanged; // ✅ Evento para actualizar saldo en tiempo real
            btnConfirmar.Enabled = false; // 🔥 Botón deshabilitado hasta ingresar un monto válido
        }

        private void ConfigurarDataGridView()
        {
            dtAbonos.AllowUserToAddRows = false;
            dtAbonos.AllowUserToDeleteRows = false;
            dtAbonos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtAbonos.BackgroundColor = Color.White;
            dtAbonos.ReadOnly = true;
            dtAbonos.RowHeadersVisible = false;
            dtAbonos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dtAbonos.DefaultCellStyle.Font = new Font("Arial", 13, FontStyle.Regular);
            dtAbonos.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 13, FontStyle.Bold);

            dtAbonos.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            dtAbonos.DefaultCellStyle.SelectionForeColor = Color.White;

            dtAbonos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtAbonos.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtAbonos.Columns.Clear();
            dtAbonos.Columns.Add(new DataGridViewTextBoxColumn { Name = "IDPago", HeaderText = "ID Pago", Visible = false });
            dtAbonos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Fecha", HeaderText = "Fecha", Width = 150 });

            dtAbonos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Monto",
                HeaderText = "Monto Abonado",
                Width = 200,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N0" }
            });
        }

        private async void CargarSaldoPendiente()
        {
            try
            {
                saldoPendiente = await _pagoController.ObtenerSaldoPendienteAsync(_idCliente);
                ActualizarSaldoEnPantalla(); // ✅ Llamamos la función que actualiza el saldo
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
                    abono.MontoAbonado.ToString("N0") // ✅ Mostrar sin decimales y en unidades de mil
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

            if (montoAbonado > saldoPendiente)
            {
                MessageBox.Show("No puede abonar más de lo que debe.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool pagoExitoso = await _pagoController.AplicarPagoAsync(_idCliente, montoAbonado);

            if (pagoExitoso)
            {
                MessageBox.Show("✅ Pago registrado con éxito.", "Pago Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAbono.Clear();
                CargarAbonos(); // 🔥 Recargar la lista de abonos después de confirmar
                saldoPendiente -= montoAbonado; // ✅ Restamos el abono al saldo actual
                ActualizarSaldoEnPantalla(); // ✅ Actualizar en pantalla
                btnConfirmar.Enabled = false; // 🔥 Deshabilitar botón después del pago
            }
        }

        private void TxtAbono_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtAbono.Text.Trim(), out decimal montoAbonado))
            {
                decimal nuevoSaldo = saldoPendiente - montoAbonado;

                if (montoAbonado > saldoPendiente)
                {
                    lblCredito.Text = $"⚠️ Monto Mayor al del credito";
                    lblCredito.ForeColor = Color.Red;
                    btnConfirmar.Enabled = false;
                }
                else
                {
                    lblCredito.Text = $"Saldo Pendiente: {nuevoSaldo:N0}";
                    lblCredito.ForeColor = Color.Black;
                    btnConfirmar.Enabled = montoAbonado > 0;
                }
            }
            else
            {
                lblCredito.Text = $"Saldo Pendiente: {saldoPendiente:N0}";
                lblCredito.ForeColor = Color.Black;
                btnConfirmar.Enabled = false;
            }
        }

        private void ActualizarSaldoEnPantalla()
        {
            lblCredito.Text = $"Saldo Pendiente: {saldoPendiente:N0}";
            lblCredito.ForeColor = Color.Black;
        }
    }
}
