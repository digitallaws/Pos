using Sopromil.Controlador;
using Sopromil.Modelo;
using Sopromil.Vista.Usuarios;

namespace Sopromil.Vista.Creditos
{
    public partial class FrmDetalleCredito : Form
    {
        private readonly CreditoController _creditoController = new CreditoController();
        private readonly ClienteController _clienteController = new ClienteController();
        public int IDCredito { get; set; }
        private int IDCliente;

        public FrmDetalleCredito(int idCredito)
        {
            InitializeComponent();
            IDCredito = idCredito;

            // Asignar eventos por código
            Load += FrmDetalleCredito_Load;
            btnActualizarFecha.Click += BtnActualizarFecha_Click;
            btnAmpliarCredito.Click += BtnAmpliarCredito_Click;
            btnRegistrarPago.Click += BtnRegistrarPago_Click;
            btnCancelarCredito.Click += BtnCancelarCredito_Click;
            btnCerrar.Click += BtnCerrar_Click;
        }

        private async void FrmDetalleCredito_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridPagos();
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
            dgvHistorialPagos.RowHeadersVisible = false;
            dgvHistorialPagos.AllowUserToAddRows = false;
            dgvHistorialPagos.AllowUserToDeleteRows = false;
            dgvHistorialPagos.ReadOnly = true;

            dgvHistorialPagos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FechaPago",
                HeaderText = "Fecha Pago",
                Width = 120
            });

            dgvHistorialPagos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MontoPagado",
                HeaderText = "Monto Pagado",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
            });

            dgvHistorialPagos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "InteresAplicado",
                HeaderText = "Interés Aplicado",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
            });
        }


        private async Task CargarInformacionCredito()
        {
            try
            {
                var creditos = await _creditoController.ObtenerCreditosActivosAsync();
                var credito = creditos.FirstOrDefault(c => c.IDCredito == IDCredito);

                if (credito == null)
                {
                    MessageBox.Show("No se encontró el crédito seleccionado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                    return;
                }

                IDCliente = credito.IDCliente;

                // Ajustamos formato del DateTimePicker
                dtpFechaVencimiento.Format = DateTimePickerFormat.Custom;
                dtpFechaVencimiento.CustomFormat = "dd/MM/yyyy";

                // Mostrar datos del crédito con alineación a la derecha
                txtFechaRegistro.TextAlign = HorizontalAlignment.Right;
                txtFechaRegistro.Text = credito.FechaRegistro.ToString("dd/MM/yyyy");

                txtMontoTotal.TextAlign = HorizontalAlignment.Right;
                txtMontoTotal.Text = credito.Total.ToString("N2");

                txtSaldoDisponible.TextAlign = HorizontalAlignment.Right;
                txtSaldoDisponible.Text = credito.Saldo.ToString("N2");

                txtEstadoCredito.TextAlign = HorizontalAlignment.Right;
                txtEstadoCredito.Text = credito.Estado;

                txtTasaInteres.TextAlign = HorizontalAlignment.Right;
                txtTasaInteres.Text = credito.TasaInteres.ToString("N2");

                txtDiasRestantes.TextAlign = HorizontalAlignment.Right;
                TimeSpan diferencia = credito.FechaVencimiento - DateTime.Now;
                txtDiasRestantes.Text = diferencia.Days.ToString();

                await CargarHistorialPagos();
                await CargarDatosCliente(IDCliente);

                decimal totalIntereses = await CalcularTotalIntereses();
                txtGananciaIntereses.TextAlign = HorizontalAlignment.Right;
                txtGananciaIntereses.Text = totalIntereses.ToString("N2");

                decimal porcentajeConsumido = 100 - ((credito.Saldo / credito.Total) * 100);
                txtPorcentajeConsumido.TextAlign = HorizontalAlignment.Right;
                txtPorcentajeConsumido.Text = porcentajeConsumido.ToString("N2") + " %";
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(CargarInformacionCredito));
                MessageBox.Show("Ocurrió un error al cargar la información del crédito.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    txtNombreCliente.TextAlign = HorizontalAlignment.Right;
                    txtDocumentoCliente.Text = cliente.IdentificadorFiscal;
                    txtDocumentoCliente.TextAlign = HorizontalAlignment.Right;
                    txtTelefonoCliente.Text = cliente.Celular;
                    txtTelefonoCliente.TextAlign = HorizontalAlignment.Right;
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
                MessageBox.Show("Error al cargar los datos del cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    totalPagado += pago.MontoPagado;
                    totalInteres += pago.InteresAplicado;

                    dgvHistorialPagos.Rows.Add(
                        pago.FechaPago.ToString("dd/MM/yyyy"),
                        pago.MontoPagado,
                        pago.InteresAplicado
                    );
                }

                txtTotalPagado.TextAlign = HorizontalAlignment.Right;
                txtTotalPagado.Text = totalPagado.ToString("N2");
                txtGananciaIntereses.TextAlign = HorizontalAlignment.Right;
                txtGananciaIntereses.Text = totalInteres.ToString("N2");
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(CargarHistorialPagos));
                MessageBox.Show("Ocurrió un error al cargar el historial de pagos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async Task<decimal> CalcularTotalIntereses()
        {
            try
            {
                var pagos = await _creditoController.ObtenerPagosCreditoAsync(IDCredito);
                return pagos.Sum(p => p.InteresAplicado);
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(CalcularTotalIntereses));
                return 0;
            }
        }

        private async void BtnActualizarFecha_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Fecha de vencimiento actualizada correctamente (simulación).", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(BtnActualizarFecha_Click));
                MessageBox.Show("Error al actualizar la fecha.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnAmpliarCredito_Click(object sender, EventArgs e)
        {
            try
            {
                var input = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el monto adicional", "Ampliar Crédito", "0");
                if (decimal.TryParse(input, out decimal montoAdicional) && montoAdicional > 0)
                {
                    var credito = new Credito
                    {
                        IDCliente = IDCliente,
                        FechaVencimiento = dtpFechaVencimiento.Value,
                        Total = montoAdicional,
                        AplicaInteres = false,
                        TasaInteres = 0 
                    };

                    string mensaje = await _creditoController.RegistrarOActualizarCreditoAsync(credito);
                    MessageBox.Show(mensaje, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await CargarInformacionCredito();
                }
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(BtnAmpliarCredito_Click));
                MessageBox.Show("Error al ampliar el crédito.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnRegistrarPago_Click(object sender, EventArgs e)
        {
            try
            {
                var input = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el monto del pago", "Registrar Pago", "0");
                if (decimal.TryParse(input, out decimal montoPagado) && montoPagado > 0)
                {
                    await _creditoController.RegistrarPagoAsync(IDCredito, montoPagado, 0);
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

        private async void BtnCancelarCredito_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Está seguro de cancelar este crédito?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
            string logPath = "logErrores.txt";
            string mensaje = $"[{DateTime.Now:dd/MM/yyyy HH:mm:ss}] Error en {metodo}: {ex.Message}{Environment.NewLine}";
            File.AppendAllText(logPath, mensaje);
        }
    }
}
