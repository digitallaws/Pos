using Sopromil.Controlador;
using Sopromil.Modelo;

namespace Sopromil.Vista.Inventario
{
    public partial class FrmInformePrecio : Form
    {
        private readonly HistorialPreciosController _historialPreciosController;
        private int _idProducto;

        public FrmInformePrecio(int idProducto, string nombreProducto, string proveedor, decimal stock, decimal precioCompra, decimal precioVenta)
        {
            InitializeComponent();
            _historialPreciosController = new HistorialPreciosController();
            _idProducto = idProducto;

            txtNombre.Text = nombreProducto;
            txtProveedor.Text = proveedor;
            txtStock.Text = stock.ToString("N0");
            txtPrecio.Text = precioCompra.ToString("N0");
            txtVenta.Text = precioVenta.ToString("N0");
            txtRegistro.Text = DateTime.Now.ToString("yyyy-MM-dd");

            ConfigurarDataGridView();
            this.Load += async (s, e) => await CargarHistorialPrecios(); // ✅ Cargar datos al abrir
        }

        /// <summary>
        /// Configura la estructura y diseño del DataGridView
        /// </summary>
        private void ConfigurarDataGridView()
        {
            dtHistorial.AllowUserToAddRows = false;
            dtHistorial.AllowUserToDeleteRows = false;
            dtHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtHistorial.BackgroundColor = Color.White;
            dtHistorial.ReadOnly = true;
            dtHistorial.RowHeadersVisible = false;
            dtHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dtHistorial.DefaultCellStyle.Font = new Font("Arial", 13, FontStyle.Regular);
            dtHistorial.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 13, FontStyle.Bold);
            dtHistorial.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            dtHistorial.DefaultCellStyle.SelectionForeColor = Color.White;

            dtHistorial.DataSource = null;
            dtHistorial.Columns.Clear();
            dtHistorial.AutoGenerateColumns = false;

            dtHistorial.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FechaCambio", HeaderText = "Fecha Cambio", SortMode = DataGridViewColumnSortMode.Automatic });

            dtHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PrecioCompraAnterior",
                HeaderText = "Precio Anterior",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dtHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PrecioCompraNuevo",
                HeaderText = "Precio Nuevo",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dtHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PrecioVentaAnterior",
                HeaderText = "Venta Anterior",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dtHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PrecioVentaNuevo",
                HeaderText = "Venta Nueva",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dtHistorial.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Motivo", HeaderText = "Motivo" });
        }

        /// <summary>
        /// Carga el historial de precios del producto
        /// </summary>
        private async Task CargarHistorialPrecios()
        {
            try
            {
                List<HistorialPrecios> historial = await _historialPreciosController.ObtenerHistorialPorProductoAsync(_idProducto);

                if (historial == null || historial.Count == 0)
                {
                    MessageBox.Show("No hay historial de precios para este producto.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                dtHistorial.DataSource = historial.OrderByDescending(h => h.FechaCambio).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el historial de precios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
