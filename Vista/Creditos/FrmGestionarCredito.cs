using Sopromil.Controlador;
using Sopromil.Modelo;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            txtPorcentajeInteres.Value = 3; // ✅ Por defecto 3%
            txtPorcentajeInteres.Enabled = false; // ✅ Inicia deshabilitado
            txtFechaLimite1.Value = DateTime.Now.AddDays(30); // ✅ Fecha por defecto: 30 días adelante
            txtFechaLimite.Text = txtFechaLimite1.Value.ToString("dd/MM/yyyy"); // ✅ Reflejar en el TextBox
            txtFechaLimite.ReadOnly = true; // ✅ Solo lectura para evitar errores
        }

        private async void BuscarCliente()
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
                    txtDocumento.Enabled = false; // ✅ Se fija el documento para evitar cambios
                    MessageBox.Show("Complete los datos del nuevo cliente.", "Nuevo Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    LimpiarDatosCliente();
                }
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
                // ✅ Registrar cliente si no existe
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
                FechaVencimiento = txtFechaLimite1.Value, // ✅ Fecha seleccionada
                Total = monto,
                Saldo = monto,
                AplicaInteres = chkAplicaInteres.Checked,
                TasaInteres = chkAplicaInteres.Checked ? Convert.ToDecimal(txtPorcentajeInteres.Value) : 0,
                Estado = "Pendiente"
            };

            try
            {
                await _creditoController.RegistrarCreditoAsync(nuevoCredito);
                MessageBox.Show("Crédito registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el crédito: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkAplicaInteres_CheckedChanged(object sender, EventArgs e)
        {
            txtPorcentajeInteres.Enabled = chkAplicaInteres.Checked;
            if (!chkAplicaInteres.Checked)
            {
                txtPorcentajeInteres.Value = 3; // ✅ Restaurar 3% cuando se desactiva
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ✅ Solo permitir números y un punto decimal
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // ✅ Solo un punto decimal permitido
            if (e.KeyChar == '.' && txtMonto.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void dtpFechaLimite_ValueChanged(object sender, EventArgs e)
        {
            txtFechaLimite.Text = txtFechaLimite1.Value.ToString("dd/MM/yyyy"); // ✅ Actualiza el TextBox al cambiar fecha
        }
    }
}
