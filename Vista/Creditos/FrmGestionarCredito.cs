using Sopromil.Controlador;
using Sopromil.Modelo;

namespace Sopromil.Vista.Creditos
{
    public partial class FrmGestionarCredito : Form
    {
        private readonly ClienteController _clienteController = new ClienteController();
        private readonly CreditoController _creditoController = new CreditoController();
        private Cliente ClienteSeleccionado;

        public FrmGestionarCredito()
        {
            InitializeComponent();
            InicializarConfiguracionInicial();
            InicializarEventos();
        }

        private void InicializarConfiguracionInicial()
        {
            txtPorcentajeInteres.Value = 3;
            txtPorcentajeInteres.Enabled = false;
            txtFechaLimite1.Value = DateTime.Now.AddDays(30);
            txtFechaLimite.Text = txtFechaLimite1.Value.ToString("dd/MM/yyyy");
            txtFechaLimite.ReadOnly = true;
        }

        private void InicializarEventos()
        {
            txtDocumento.KeyDown += txtDocumento_KeyDown;
            btnBuscarCliente.Click += btnBuscarCliente_Click;
            btnRegistrarCredito.Click += btnRegistrarCredito_Click;
            btnCancelar.Click += btnCancelar_Click;
            txtMonto.KeyPress += txtMonto_KeyPress;
            chkAplicaInteres.CheckedChanged += chkAplicaInteres_CheckedChanged;
            txtFechaLimite1.ValueChanged += dtpFechaLimite_ValueChanged;
        }

        private void LogError(Exception ex, string metodo)
        {
            string logPath = "logErrores.txt";
            string mensaje = $"[{DateTime.Now:dd/MM/yyyy HH:mm:ss}] Error en {metodo}: {ex.Message}{Environment.NewLine}";
            File.AppendAllText(logPath, mensaje);
        }

        private async void BuscarCliente()
        {
            try
            {
                string documento = txtDocumento.Text.Trim();

                if (string.IsNullOrWhiteSpace(documento))
                {
                    MessageBox.Show("Ingrese un documento válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var clientes = await _clienteController.ObtenerClientesAsync();
                ClienteSeleccionado = clientes.FirstOrDefault(c => c.IdentificadorFiscal == documento);

                if (ClienteSeleccionado != null)
                {
                    CargarDatosCliente(ClienteSeleccionado);
                }
                else
                {
                    var respuesta = MessageBox.Show("Cliente no encontrado. ¿Desea registrarlo?", "Cliente no encontrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (respuesta == DialogResult.Yes)
                    {
                        LimpiarDatosCliente();
                        txtDocumento.Enabled = false;
                        MessageBox.Show("Complete los datos del nuevo cliente.", "Nuevo Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        LimpiarDatosCliente();
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(BuscarCliente));
                MessageBox.Show("Ocurrió un error al buscar el cliente. Consulte al administrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDocumento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) BuscarCliente();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            BuscarCliente();
        }

        private void CargarDatosCliente(Cliente cliente)
        {
            txtNombre.Text = cliente.Nombre;
            txtTelefono.Text = cliente.Celular;
            lblIDCliente.Text = cliente.IDCliente.ToString();
            ClienteSeleccionado = cliente;
        }

        private void LimpiarDatosCliente()
        {
            ClienteSeleccionado = null;
            txtNombre.Clear();
            txtTelefono.Clear();
            lblIDCliente.Text = "0";
        }

        private async void btnRegistrarCredito_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtDocumento.Text))
                {
                    MessageBox.Show("Debe ingresar nombre y documento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!decimal.TryParse(txtMonto.Text, out decimal monto) || monto <= 0)
                {
                    MessageBox.Show("Ingrese un monto válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (ClienteSeleccionado == null)
                {
                    var nuevoCliente = new Cliente
                    {
                        Nombre = txtNombre.Text.Trim(),
                        IdentificadorFiscal = txtDocumento.Text.Trim(),
                        Celular = txtTelefono.Text.Trim(),
                        Estado = "Activo"
                    };

                    int nuevoID = await _clienteController.CrearClienteAsync(nuevoCliente);

                    if (nuevoID <= 0)
                    {
                        MessageBox.Show("Error al crear el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    nuevoCliente.IDCliente = nuevoID;
                    ClienteSeleccionado = nuevoCliente;
                }

                var nuevoCredito = new Credito
                {
                    IDCliente = ClienteSeleccionado.IDCliente,
                    FechaVencimiento = txtFechaLimite1.Value,
                    Total = monto, // En este caso Total es el monto solicitado (no el cupo total)
                    AplicaInteres = chkAplicaInteres.Checked,
                    TasaInteres = chkAplicaInteres.Checked ? Convert.ToDecimal(txtPorcentajeInteres.Value) : 0
                };

                string resultado = await _creditoController.RegistrarOActualizarCreditoAsync(nuevoCredito);

                if (resultado.Contains("correctamente") || resultado.Contains("Saldo disponible"))
                {
                    MessageBox.Show(resultado, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show(resultado, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(btnRegistrarCredito_Click));
                MessageBox.Show("Ocurrió un error al registrar el crédito.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void chkAplicaInteres_CheckedChanged(object sender, EventArgs e)
        {
            txtPorcentajeInteres.Enabled = chkAplicaInteres.Checked;
            if (!chkAplicaInteres.Checked)
            {
                txtPorcentajeInteres.Value = 3;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && txtMonto.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void dtpFechaLimite_ValueChanged(object sender, EventArgs e)
        {
            txtFechaLimite.Text = txtFechaLimite1.Value.ToString("dd/MM/yyyy");
        }
    }
}
