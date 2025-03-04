using Sopromil.Controlador;
using Sopromil.Modelo;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sopromil.Vista.Usuarios;

namespace Sopromil.Vista.Clientes
{
    public partial class Clientes : Form
    {
        private readonly ClienteController _clienteController;
        private List<Cliente> clientesOriginales = new List<Cliente>();

        public Clientes()
        {
            InitializeComponent();
            _clienteController = new ClienteController();

            // ✅ Configuración del DataGridView
            ConfigurarDataGrid();

            // ✅ Cargar clientes al iniciar
            CargarClientes();

            // ✅ Eventos
            txtBuscar.TextChanged += BuscarTxt_TextChanged;
            btnRegistrar.Click += BtnRegistrar_Click;
            btnActualizar.Click += BtnActualizar_Click;
            dtClientes.CellClick += DtClientes_CellClick;
            dtClientes.CellFormatting += DtClientes_CellFormatting;

            // ✅ Inicializar label de ID oculto y botones de acción
            lbId.Visible = false;
            btnActualizar.Visible = false;

            // ✅ Configurar ComboBox de Estado
            cbEstado.DropDownStyle = ComboBoxStyle.DropDownList; // No permite escribir
            cbEstado.Items.AddRange(new string[] { "Activo", "Inactivo" });
            cbEstado.SelectedIndex = 0; // Siempre inicia en "Activo"

            // ✅ Restringir entradas de texto en Identificador Fiscal y Celular
            txtIdentificadorFiscal.KeyPress += ValidarNumeros;
            txtCelular.KeyPress += ValidarNumeros;
        }

        private void ConfigurarDataGrid()
        {
            dtClientes.AllowUserToAddRows = false;
            dtClientes.AllowUserToDeleteRows = false;
            dtClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtClientes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dtClientes.BackgroundColor = Color.White;
            dtClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtClientes.ReadOnly = true;
            dtClientes.RowHeadersVisible = false;
            dtClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // ✅ Estilos generales
            dtClientes.DefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dtClientes.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dtClientes.DefaultCellStyle.ForeColor = Color.Black;
            dtClientes.DefaultCellStyle.BackColor = Color.White;
        }

        private async void CargarClientes()
        {
            try
            {
                clientesOriginales = await _clienteController.ObtenerClientesAsync();
                MostrarClientesEnGrid(clientesOriginales);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarClientesEnGrid(List<Cliente> clientes)
        {
            dtClientes.DataSource = null;
            dtClientes.Columns.Clear();
            dtClientes.AutoGenerateColumns = false;

            // ✅ Ocultar IDCliente
            var colID = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IDCliente",
                Visible = false
            };
            dtClientes.Columns.Add(colID);

            // ✅ Columna: Nombre
            dtClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // ✅ Columna: Identificador Fiscal
            dtClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IdentificadorFiscal",
                HeaderText = "Identificación",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // ✅ Columna: Celular
            dtClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Celular",
                HeaderText = "Celular",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // ✅ Columna: Estado
            dtClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Estado",
                HeaderText = "Estado",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // ✅ Botón: Editar
            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn
            {
                HeaderText = "Editar",
                Text = "Editar",
                UseColumnTextForButtonValue = true,
                Width = 70,
                FlatStyle = FlatStyle.Flat
            };
            dtClientes.Columns.Add(btnEditar);

            // ✅ Botón: Eliminar (Cambia estado a inactivo)
            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn
            {
                HeaderText = "Eliminar",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true,
                Width = 70,
                FlatStyle = FlatStyle.Flat
            };
            dtClientes.Columns.Add(btnEliminar);

            dtClientes.DataSource = clientes;
        }

        private async void BtnRegistrar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string identificador = txtIdentificadorFiscal.Text.Trim();
            string celular = txtCelular.Text.Trim();
            string estado = cbEstado.SelectedItem.ToString();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("El nombre es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cliente nuevoCliente = new Cliente
            {
                Nombre = nombre,
                IdentificadorFiscal = identificador,
                Celular = celular,
                Estado = estado
            };

            await _clienteController.CrearClienteAsync(nuevoCliente);
            LimpiarCampos();
            CargarClientes();
        }

        private async void BtnActualizar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(lbId.Text, out int idCliente))
            {
                MessageBox.Show("No se pudo determinar el cliente a actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string nombre = txtNombre.Text.Trim();
            string identificador = txtIdentificadorFiscal.Text.Trim();
            string celular = txtCelular.Text.Trim();
            string estado = cbEstado.SelectedItem.ToString();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("El nombre es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cliente clienteActualizado = new Cliente
            {
                IDCliente = idCliente,
                Nombre = nombre,
                IdentificadorFiscal = identificador,
                Celular = celular,
                Estado = estado
            };

            await _clienteController.ActualizarClienteAsync(clienteActualizado);
            LimpiarCampos();
            CargarClientes();

            btnActualizar.Visible = false;
            btnRegistrar.Visible = true;
            lbId.Visible = false;
        }

        private async void DtClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var clienteSeleccionado = ((List<Cliente>)dtClientes.DataSource)[e.RowIndex];

                if (dtClientes.Columns[e.ColumnIndex].HeaderText == "Editar")
                {
                    txtNombre.Text = clienteSeleccionado.Nombre;
                    txtIdentificadorFiscal.Text = clienteSeleccionado.IdentificadorFiscal;
                    txtCelular.Text = clienteSeleccionado.Celular;
                    cbEstado.SelectedItem = clienteSeleccionado.Estado;
                    lbId.Text = clienteSeleccionado.IDCliente.ToString();
                    lbId.Visible = true;

                    btnRegistrar.Visible = false;
                    btnActualizar.Visible = true;
                }
                else if (dtClientes.Columns[e.ColumnIndex].HeaderText == "Eliminar")
                {
                    await _clienteController.CambiarEstadoClienteAsync(clienteSeleccionado.IDCliente, "Inactivo");
                    MessageBox.Show("Cliente inactivado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarClientes();
                    LimpiarCampos();
                }
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtIdentificadorFiscal.Text = "";
            txtCelular.Text = "";
            cbEstado.SelectedIndex = 0;
            lbId.Text = "";
        }

        // ✅ Buscador en tiempo real
        private void BuscarTxt_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim().ToLower();

            var clientesFiltrados = clientesOriginales
                .Where(c => c.Nombre.ToLower().Contains(filtro) ||
                            c.IdentificadorFiscal.ToLower().Contains(filtro) ||
                            c.Celular.ToLower().Contains(filtro) ||
                            c.Estado.ToLower().Contains(filtro))
                .ToList();

            MostrarClientesEnGrid(clientesFiltrados.Any() ? clientesFiltrados : clientesOriginales);
        }

        // ✅ Formatear botones del DataGridView
        private void DtClientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dtClientes.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var headerText = dtClientes.Columns[e.ColumnIndex].HeaderText;

                if (headerText == "Editar")
                {
                    e.CellStyle.BackColor = Color.RoyalBlue;
                    e.CellStyle.ForeColor = Color.White;
                }
                else if (headerText == "Eliminar")
                {
                    e.CellStyle.BackColor = Color.Red;
                    e.CellStyle.ForeColor = Color.White;
                }

                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                e.CellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            }
        }

        // ✅ Validar solo números en Identificador Fiscal y Celular
        private void ValidarNumeros(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y teclas de control como Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}
