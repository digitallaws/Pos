using Sopromil.Controlador;
using Sopromil.Modelo;
using System.Data;

namespace Sopromil.Vista.Inventario
{
    public partial class FrmInventario : Form
    {
        private readonly ProductoController _productoController;
        private List<Producto> _productosOriginales = new();
        private readonly ProveedorController _proveedorController;

        public FrmInventario()
        {
            InitializeComponent();
            _productoController = new ProductoController();
            _proveedorController = new ProveedorController();
            ConfigurarDataGrid();
            ConfigurarEventos();
            CargarInventario();
            CargarProveedores(); // Cargar proveedores al abrir la ventana
        }


        #region Configuración Inicial

        private void ConfigurarDataGrid()
        {
            dtInventario.AllowUserToAddRows = false;
            dtInventario.AllowUserToDeleteRows = false;
            dtInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtInventario.BackgroundColor = Color.White;
            dtInventario.ReadOnly = true;
            dtInventario.RowHeadersVisible = false;
            dtInventario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dtInventario.DefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Regular);
            dtInventario.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);

            dtInventario.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            dtInventario.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        private void ConfigurarEventos()
        {
            txtBuscar.TextChanged += (s, e) => FiltrarInventario();
            cbProveedores.SelectedIndexChanged += (s, e) => FiltrarInventario(); // Nuevo evento
        }


        #endregion

        #region Carga de Datos

        private async void CargarInventario()
        {
            try
            {
                _productosOriginales = await _productoController.ListarTodosLosProductosAsync();

                if (_productosOriginales.Count == 0)
                {
                    MessageBox.Show("No se encontraron productos en el inventario.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ActualizarTabla(_productosOriginales);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el inventario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ActualizarTabla(List<Producto> productos)
        {
            dtInventario.DataSource = null;
            dtInventario.Columns.Clear();
            dtInventario.AutoGenerateColumns = false;

            dtInventario.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CodigoBarras", HeaderText = "Código" });
            dtInventario.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Descripcion", HeaderText = "Nombre" });
            dtInventario.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Marca", HeaderText = "Marca" });
            dtInventario.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Stock", HeaderText = "Cantidad" });
            dtInventario.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "UnidadMedida", HeaderText = "Unidad" });

            // Cambié "PrecioCompra" por "Valor Unitario"
            dtInventario.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PrecioCompra", HeaderText = "Valor Unitario" });

            // Nueva columna "Valor Total" (Stock * PrecioCompra)
            var colValorTotal = new DataGridViewTextBoxColumn
            {
                HeaderText = "Valor Total",
                Name = "ValorTotal",
                ReadOnly = true
            };
            dtInventario.Columns.Add(colValorTotal);

            dtInventario.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ValorVenta", HeaderText = "Venta" });

            // Asignamos la lista de productos al DataGridView
            dtInventario.DataSource = productos;

            // Calcular el valor total por cada fila
            foreach (DataGridViewRow row in dtInventario.Rows)
            {
                if (row.DataBoundItem is Producto producto)
                {
                    row.Cells["ValorTotal"].Value = (producto.Stock * producto.PrecioCompra).ToString("N0");
                }
            }

            CalcularResumenInventario();
        }


        private async void CargarProveedores()
        {
            try
            {
                var proveedores = await _proveedorController.ObtenerProveedoresAsync(true); // Asegúrate de que este método exista

                cbProveedores.DataSource = null;
                cbProveedores.DataSource = proveedores;
                cbProveedores.DisplayMember = "Nombre";  // El nombre del proveedor
                cbProveedores.ValueMember = "IDProveedor";  // ID del proveedor
                cbProveedores.SelectedIndex = -1;  // Para que no haya ninguno seleccionado al inicio
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar proveedores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        #region Funcionalidad de Búsqueda

        private void FiltrarInventario()
        {
            string filtro = txtBuscar.Text.Trim().ToLower();
            int idProveedorSeleccionado = cbProveedores.SelectedIndex > 0 ? (int)cbProveedores.SelectedValue : 0;

            var productosFiltrados = _productosOriginales
                .Where(p =>
                    (idProveedorSeleccionado == 0 || p.IDProveedor == idProveedorSeleccionado) &&  // Filtra por proveedor si está seleccionado
                    (string.IsNullOrEmpty(filtro) ||
                     p.Descripcion.ToLower().Contains(filtro) ||
                     p.CodigoBarras.ToLower().Contains(filtro) ||
                     p.Marca.ToLower().Contains(filtro)))
                .ToList();

            ActualizarTabla(productosFiltrados);
        }


        #endregion

        #region Cálculos de Totales

        private void CalcularResumenInventario()
        {
            decimal totalInventario = _productosOriginales.Sum(p => p.PrecioCompra * p.Stock);

            lblTotalInventario.Text = $"$ {totalInventario:N0}";
        }

        #endregion

        private void btnProductos_Click(object sender, EventArgs e)
        {
            Proveedores proveedores = new Proveedores();
            proveedores.Show();
            this.Hide();
        }
    }
}
