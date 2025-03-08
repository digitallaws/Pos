using Sopromil.Controlador;
using Sopromil.Modelo;
using Sopromil.Vista.Inventario;
using Sopromil.Vista.Productos;
using System.Data;

namespace Sopromil.Vista
{
    public partial class Proveedores : Form
    {
        private readonly ProveedorController _proveedorController;
        private List<Proveedor> proveedoresOriginales = new();

        public Proveedores()
        {
            InitializeComponent();
            _proveedorController = new ProveedorController();

            ConfigurarDataGrid();
            CargarProveedores();

            txtBuscar.TextChanged += TxtBuscar_TextChanged;
            btnCrear.Click += BtnCrear_Click;
            btnActualizar.Click += BtnActualizar_Click;
            dtProveedores.CellClick += DtProveedores_CellClick;

            btnActualizar.Visible = false;
            lbId.Visible = false;
        }

        private void ConfigurarDataGrid()
        {
            dtProveedores.AllowUserToAddRows = false;
            dtProveedores.AllowUserToDeleteRows = false;
            dtProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dtProveedores.BackgroundColor = Color.White;
            dtProveedores.ReadOnly = true;
            dtProveedores.RowHeadersVisible = false;
            dtProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dtProveedores.DefaultCellStyle.Font = new Font("Arial", 13, FontStyle.Regular);
            dtProveedores.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 13, FontStyle.Bold);

            // 💠 Cambiar color de selección
            dtProveedores.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            dtProveedores.DefaultCellStyle.SelectionForeColor = Color.White;
        }


        private async void CargarProveedores()
        {
            // Solo activos
            proveedoresOriginales = await _proveedorController.ObtenerProveedoresAsync(true);
            MostrarProveedoresEnGrid(proveedoresOriginales);
        }

        private void MostrarProveedoresEnGrid(List<Proveedor> proveedores)
        {
            dtProveedores.DataSource = null;
            dtProveedores.Columns.Clear();
            dtProveedores.AutoGenerateColumns = false;

            dtProveedores.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dtProveedores.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Editar",
                Text = "✏️",
                UseColumnTextForButtonValue = true,
                Width = 100
            });

            dtProveedores.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Eliminar",
                Text = "🗑️",
                UseColumnTextForButtonValue = true,
                Width = 100
            });

            dtProveedores.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Productos",
                Text = "📦",
                UseColumnTextForButtonValue = true,
                Width = 100
            });

            dtProveedores.DataSource = proveedores;
        }

        private async void BtnCrear_Click(object sender, EventArgs e)
        {
            await GuardarProveedorAsync();
        }

        private async void BtnActualizar_Click(object sender, EventArgs e)
        {
            await GuardarProveedorAsync(esActualizar: true);
        }

        private async Task GuardarProveedorAsync(bool esActualizar = false)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var proveedor = new Proveedor
            {
                Nombre = txtNombre.Text.Trim(),
                IdentificadorFiscal = txtNit.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                Ciudad = txtCiudad.SelectedItem?.ToString(),
                Estado = "Activo"
            };

            if (esActualizar)
            {
                if (!int.TryParse(lbId.Text, out int idProveedor))
                {
                    MessageBox.Show("No se pudo obtener el ID del proveedor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                proveedor.IDProveedor = idProveedor;
                await _proveedorController.ActualizarProveedorAsync(proveedor);
                MostrarModoCrear();
            }
            else
            {
                await _proveedorController.CrearProveedorAsync(proveedor);
            }

            LimpiarCampos();
            CargarProveedores();
        }

        private async void DtProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= proveedoresOriginales.Count)
                return;

            var proveedor = proveedoresOriginales[e.RowIndex];

            if (dtProveedores.Columns[e.ColumnIndex].HeaderText == "Editar")
            {
                CargarProveedorEnFormulario(proveedor);
            }
            else if (dtProveedores.Columns[e.ColumnIndex].HeaderText == "Eliminar")
            {
                var confirmacion = MessageBox.Show("¿Está seguro que desea inactivar este proveedor?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmacion == DialogResult.Yes)
                {
                    await _proveedorController.CambiarEstadoProveedorAsync(proveedor.IDProveedor, "Inactivo");
                    LimpiarCampos();
                    CargarProveedores();
                }
            }
            else if (dtProveedores.Columns[e.ColumnIndex].HeaderText == "Productos")
            {
                FrmProductos frmProductos = new FrmProductos(proveedor.IDProveedor, proveedor.Nombre);
                frmProductos.ShowDialog();
            }

        }

        private void CargarProveedorEnFormulario(Proveedor proveedor)
        {
            lbId.Text = proveedor.IDProveedor.ToString();
            txtNombre.Text = proveedor.Nombre;
            txtNit.Text = proveedor.IdentificadorFiscal;
            txtTelefono.Text = proveedor.Telefono;
            txtDireccion.Text = proveedor.Direccion;
            txtCiudad.SelectedItem = proveedor.Ciudad;

            btnCrear.Visible = false;
            btnActualizar.Visible = true;
        }

        private void MostrarModoCrear()
        {
            LimpiarCampos();
            btnCrear.Visible = true;
            btnActualizar.Visible = false;
        }

        private void LimpiarCampos()
        {
            lbId.Text = string.Empty;
            txtNombre.Clear();
            txtNit.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtCiudad.SelectedIndex = -1;
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim().ToLower();

            var filtrados = proveedoresOriginales
                .Where(p =>
                    p.Nombre.ToLower().Contains(filtro) ||
                    (p.IdentificadorFiscal ?? "").ToLower().Contains(filtro) ||
                    (p.Telefono ?? "").ToLower().Contains(filtro) ||
                    (p.Direccion ?? "").ToLower().Contains(filtro) ||
                    (p.Ciudad ?? "").ToLower().Contains(filtro) ||
                    p.Estado.ToLower().Contains(filtro))
                .ToList();

            MostrarProveedoresEnGrid(filtrados.Any() ? filtrados : proveedoresOriginales);
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            FrmInventario frmInventario = new FrmInventario();
            frmInventario.Show();
            this.Hide();
        }
    }
}
