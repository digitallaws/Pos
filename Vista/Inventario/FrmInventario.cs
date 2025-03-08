using Sopromil.Controlador;
using Sopromil.Modelo;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            CargarProveedores();
        }

        #region Configuración Inicial

        private void ConfigurarDataGrid()
        {
            dtInventario.Dock = DockStyle.Fill; // Hace que el DataGridView ocupe todo el panel
            dtInventario.AllowUserToAddRows = false;
            dtInventario.AllowUserToDeleteRows = false;
            dtInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtInventario.BackgroundColor = Color.White;
            dtInventario.ReadOnly = true;
            dtInventario.RowHeadersVisible = false;
            dtInventario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtInventario.BorderStyle = BorderStyle.None; // Se elimina el borde para mejorar el diseño

            dtInventario.DefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Regular);
            dtInventario.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dtInventario.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // 🔹 Cambiar color de selección
            dtInventario.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            dtInventario.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        private void ConfigurarEventos()
        {
            txtBuscar.TextChanged += (s, e) => FiltrarInventario();
            cbProveedores.SelectedIndexChanged += (s, e) => FiltrarInventario();
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

            // 🔹 Precio de compra formateado con separador de miles
            var colPrecioCompra = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PrecioCompra",
                HeaderText = "Valor Unitario",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            };
            dtInventario.Columns.Add(colPrecioCompra);

            // 🔹 Nueva columna "Valor Total" (Stock * PrecioCompra) formateada con separadores de miles
            var colValorTotal = new DataGridViewTextBoxColumn
            {
                HeaderText = "Valor Total",
                Name = "ValorTotal",
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            };
            dtInventario.Columns.Add(colValorTotal);

            // 🔹 Precio de venta formateado con separador de miles
            var colValorVenta = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ValorVenta",
                HeaderText = "Venta",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            };
            dtInventario.Columns.Add(colValorVenta);

            // Asignar la lista de productos al DataGridView
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
                var proveedores = await _proveedorController.ObtenerProveedoresAsync(true);

                cbProveedores.DataSource = null;
                cbProveedores.DataSource = proveedores;
                cbProveedores.DisplayMember = "Nombre";
                cbProveedores.ValueMember = "IDProveedor";
                cbProveedores.SelectedIndex = -1;
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
                    (idProveedorSeleccionado == 0 || p.IDProveedor == idProveedorSeleccionado) &&
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
