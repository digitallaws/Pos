using Sopromil.Controlador;
using Sopromil.Vista.Usuarios;
using System.Globalization;

namespace Sopromil.Vista.Creditos
{
    public partial class FrmDetalleCredito : Form
    {
        private readonly CreditoController _creditoController;
        private readonly ClienteController _clienteController;
        public int IDCredito { get; set; }
        private int IDCliente;
        private readonly CultureInfo culturaColombiana = new("es-CO");

        public FrmDetalleCredito(int idCredito)
        {
            InitializeComponent();
            _creditoController = new CreditoController();
            _clienteController = new ClienteController();
            IDCredito = idCredito;

            Load += FrmDetalleCredito_Load;
            btnRegistrarPago.Click += BtnRegistrarPago_Click;

            ConfigurarDataGridPagos();
        }

        private async void FrmDetalleCredito_Load(object sender, EventArgs e)
        {
            await CargarInformacionCredito();
        }

        private void ConfigurarDataGridPagos()
        {
            dgvHistorialPagos.AllowUserToAddRows = false;
            dgvHistorialPagos.AllowUserToDeleteRows = false;
            dgvHistorialPagos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorialPagos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvHistorialPagos.BackgroundColor = Color.White;
            dgvHistorialPagos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorialPagos.ReadOnly = true;
            dgvHistorialPagos.RowHeadersVisible = false;
            dgvHistorialPagos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // ✅ Estilos generales
            dgvHistorialPagos.DefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dgvHistorialPagos.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dgvHistorialPagos.DefaultCellStyle.ForeColor = Color.Black;
            dgvHistorialPagos.DefaultCellStyle.BackColor = Color.White;

            dgvHistorialPagos.Columns.Clear();
            dgvHistorialPagos.AutoGenerateColumns = false;
            dgvHistorialPagos.Columns.Add("FechaPago", "Fecha Pago");
            dgvHistorialPagos.Columns.Add("MontoPagado", "Monto Pagado");
            dgvHistorialPagos.Columns.Add("InteresAplicado", "Interés Aplicado");

            dgvHistorialPagos.Columns["MontoPagado"].DefaultCellStyle.Format = "C0";
            dgvHistorialPagos.Columns["InteresAplicado"].DefaultCellStyle.Format = "C0";

            dgvHistorialPagos.AllowUserToAddRows = false;
            dgvHistorialPagos.ReadOnly = true;
        }

        private async Task CargarInformacionCredito()
        {
            try
            {
                var creditos = await _creditoController.ObtenerTodosLosCreditosActivosAsync();
                var credito = creditos.FirstOrDefault(c => c.IDCredito == IDCredito);

                if (credito == null)
                {
                    MessageBox.Show("No se encontró el crédito seleccionado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                    return;
                }

                IDCliente = credito.IDCliente;

                txtFechaRegistro.Text = credito.FechaRegistro.ToString("dd/MM/yyyy");
                txtFechaVencimiento.Text = credito.FechaVencimiento.ToString("dd/MM/yyyy");
                txtMontoTotal.Text = credito.Total.ToString("C0", culturaColombiana);
                txtSaldoDisponible.Text = credito.Saldo.ToString("C0", culturaColombiana);
                txtEstadoCredito.Text = credito.Estado;
                txtTasaInteres.Text = credito.TasaInteres.ToString("N2") + " %";

                TimeSpan diferencia = credito.FechaVencimiento - DateTime.Now;
                txtDiasRestantes.Text = diferencia.Days > 0 ? diferencia.Days.ToString() : "Vencido";

                await CargarDatosCliente(IDCliente);
                await CargarHistorialPagos();

                decimal porcentajeConsumido = 100 - ((credito.Saldo / credito.Total) * 100);
                

            }
            catch (Exception ex)
            {
                LogError(ex, nameof(CargarInformacionCredito));
                MessageBox.Show($"Error al cargar la información del crédito: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CargarDatosCliente(int idCliente)
        {
            try
            {
                var cliente = await _clienteController.ObtenerClientePorIDAsync(idCliente);

                if (cliente != null)
                {
                    txtNombreCliente.Text = cliente.Nombre;
                    txtDocumentoCliente.Text = cliente.IdentificadorFiscal;
                    txtTelefonoCliente.Text = cliente.Celular;
                }
                else
                {
                    txtNombreCliente.Text = "No encontrado";
                    txtDocumentoCliente.Text = "No encontrado";
                    txtTelefonoCliente.Text = "No encontrado";
                }
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(CargarDatosCliente));
                MessageBox.Show("Error al cargar datos del cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CargarHistorialPagos()
        {
            try
            {
                dgvHistorialPagos.Rows.Clear();

                var pagos = await _creditoController.ObtenerPagosCreditoAsync(IDCredito);
                decimal totalPagado = 0;
                decimal totalInteres = 0;

                foreach (var pago in pagos)
                {
                    dgvHistorialPagos.Rows.Add(
                        pago.FechaPago.ToString("dd/MM/yyyy"),
                        pago.MontoPagado.ToString("C0", culturaColombiana),
                        pago.InteresAplicado.ToString("C0", culturaColombiana)
                    );

                    totalPagado += pago.MontoPagado;
                    totalInteres += pago.InteresAplicado;
                }

                txtTotalPagado.Text = totalPagado.ToString("C0", culturaColombiana);
                txtGananciaIntereses.Text = totalInteres.ToString("C0", culturaColombiana);
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(CargarHistorialPagos));
                MessageBox.Show("Error al cargar historial de pagos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnRegistrarPago_Click(object sender, EventArgs e)
        {
            try
            {
                var input = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el monto del pago", "Registrar Pago", "0");
                if (decimal.TryParse(input, out decimal monto) && monto > 0)
                {
                    await _creditoController.RegistrarPagoCreditoAsync(IDCredito, monto, 0);
                    MessageBox.Show("Pago registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarInformacionCredito();
                }
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(BtnRegistrarPago_Click));
                MessageBox.Show("Error al registrar el pago.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnAmpliarCredito_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No puedes ampliar un crédito desde aquí. Debes gestionarlo en 'Gestionar Créditos'.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void BtnActualizarFecha_Click(object sender, EventArgs e)
        {
            MessageBox.Show("La fecha de vencimiento solo se actualiza desde el registro del crédito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void BtnCancelarCredito_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Está seguro de cancelar el crédito?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    await _creditoController.CancelarCreditoAsync(IDCredito);
                    MessageBox.Show("Crédito cancelado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarInformacionCredito();
                }
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(BtnCancelarCredito_Click));
                MessageBox.Show("Error al cancelar el crédito.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LogError(Exception ex, string metodo)
        {
            string mensaje = $"[{DateTime.Now:dd/MM/yyyy HH:mm:ss}] Error en {metodo}: {ex.Message}\n";
            File.AppendAllText("logErrores.txt", mensaje);
        }

        private void btnRegistrarPago_Click_1(object sender, EventArgs e)
        {

        }
    }
}
