using Sopromil.Controlador;
using Sopromil.Modelo;
using System.Data;

namespace Sopromil.Vista.Clientes
{
    public partial class FrmClientes : Form
    {
        private readonly ClienteController _clienteController;
        private List<Cliente> _clientesOriginales = new();

        public FrmClientes()
        {
            InitializeComponent();
            _clienteController = new ClienteController();

            ConfigurarDataGrid();
            CargarClientes();

            txtBuscar.TextChanged += TxtBuscar_TextChanged;
            btnGuardar.Click += btnGuardar_Click;
            btnActualizar.Click += BtnActualizar_Click;
            dtClientes.CellClick += DtClientes_CellClick;

            btnActualizar.Visible = false;
            lbId.Visible = false;
        }

        private void ConfigurarDataGrid()
        {
            dtClientes.AllowUserToAddRows = false;
            dtClientes.AllowUserToDeleteRows = false;
            dtClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dtClientes.BackgroundColor = Color.White;
            dtClientes.ReadOnly = true;
            dtClientes.RowHeadersVisible = false;
            dtClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dtClientes.DefaultCellStyle.Font = new Font("Arial", 13, FontStyle.Regular);
            dtClientes.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 13, FontStyle.Bold);

            dtClientes.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            dtClientes.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        private async void CargarClientes()
        {
            _clientesOriginales = await _clienteController.ObtenerClientesAsync(true); // Solo activos
            MostrarClientesEnGrid(_clientesOriginales);
        }

        private void MostrarClientesEnGrid(List<Cliente> clientes)
        {
            dtClientes.DataSource = null;
            dtClientes.Columns.Clear();
            dtClientes.AutoGenerateColumns = false;

            dtClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dtClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Documento",
                HeaderText = "Documento",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dtClientes.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "✏Editar",
                Text = "✏️",
                UseColumnTextForButtonValue = true,
                Width = 100
            });

            dtClientes.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Eliminar",
                Text = "🗑️",
                UseColumnTextForButtonValue = true,
                Width = 100
            });

            dtClientes.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Facturas",
                Text = "🛒",
                UseColumnTextForButtonValue = true,
                Width = 100
            });

            dtClientes.DataSource = clientes;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            await GuardarClienteAsync();
        }

        private async void BtnActualizar_Click(object sender, EventArgs e)
        {
            await GuardarClienteAsync(esActualizar: true);
        }

        private async Task GuardarClienteAsync(bool esActualizar = false)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtDocumento.Text))
            {
                MessageBox.Show("El nombre y el documento son obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cliente = new Cliente
            {
                Nombre = txtNombre.Text.Trim().ToUpper(),
                Documento = txtDocumento.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Estado = "Activo"
            };

            if (esActualizar)
            {
                if (!int.TryParse(lbId.Text, out int idCliente))
                {
                    MessageBox.Show("No se pudo obtener el ID del cliente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                cliente.IDCliente = idCliente;
                await _clienteController.ActualizarClienteAsync(cliente);
                MostrarModoCrear();
            }
            else
            {
                await _clienteController.InsertarClienteAsync(cliente);
            }

            LimpiarCampos();
            CargarClientes();
        }

        private async void DtClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _clientesOriginales.Count)
                return;

            var cliente = _clientesOriginales[e.RowIndex];

            if (dtClientes.Columns[e.ColumnIndex].HeaderText == "Editar")
            {
                CargarClienteEnFormulario(cliente);
            }
            else if (dtClientes.Columns[e.ColumnIndex].HeaderText == "Eliminar")
            {
                var confirmacion = MessageBox.Show("¿Está seguro que desea inactivar este cliente?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmacion == DialogResult.Yes)
                {
                    await _clienteController.CambiarEstadoClienteAsync(cliente.IDCliente, "Inactivo");
                    LimpiarCampos();
                    CargarClientes();
                }
            }
            else if (dtClientes.Columns[e.ColumnIndex].HeaderText == "Facturas")
            {
                FrmComprasCliente frmCompras = new FrmComprasCliente(cliente.IDCliente, cliente.Nombre);
                frmCompras.ShowDialog();
            }
        }

        private void CargarClienteEnFormulario(Cliente cliente)
        {
            lbId.Text = cliente.IDCliente.ToString();
            txtNombre.Text = cliente.Nombre;
            txtDocumento.Text = cliente.Documento;
            txtTelefono.Text = cliente.Telefono;

            btnGuardar.Visible = false;
            btnActualizar.Visible = true;
        }

        private void MostrarModoCrear()
        {
            LimpiarCampos();
            btnGuardar.Visible = true;
            btnActualizar.Visible = false;
        }

        private void LimpiarCampos()
        {
            lbId.Text = string.Empty;
            txtNombre.Clear();
            txtDocumento.Clear();
            txtTelefono.Clear();
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim().ToLower();

            var filtrados = _clientesOriginales
                .Where(c =>
                    c.Nombre.ToLower().Contains(filtro) ||
                    c.Documento.ToLower().Contains(filtro) ||
                    (c.Telefono ?? "").ToLower().Contains(filtro) ||
                    c.Estado.ToLower().Contains(filtro))
                .ToList();

            MostrarClientesEnGrid(filtrados.Any() ? filtrados : _clientesOriginales);
        }
    }
}
