using Sopromil.Controlador;
using Sopromil.Modelo;

namespace Sopromil.Vista.Clientes
{
    public partial class FrmDetallesVenta : Form
    {
        private readonly VentaController _ventaController;
        private int _idVenta;

        public FrmDetallesVenta(int idVenta)
        {
            InitializeComponent();
            _ventaController = new VentaController();
            _idVenta = idVenta;

            ConfigurarDataGridView();
            CargarDetallesVenta();
        }

        private void ConfigurarDataGridView()
        {
            dtDetalles.AllowUserToAddRows = false;
            dtDetalles.AllowUserToDeleteRows = false;
            dtDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtDetalles.BackgroundColor = Color.White;
            dtDetalles.ReadOnly = true;
            dtDetalles.RowHeadersVisible = false;
            dtDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dtDetalles.DefaultCellStyle.Font = new Font("Arial", 13, FontStyle.Regular);
            dtDetalles.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 13, FontStyle.Bold);

            // 💠 Cambiar color de selección
            dtDetalles.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            dtDetalles.DefaultCellStyle.SelectionForeColor = Color.White;

            dtDetalles.Columns.Clear();
            dtDetalles.Columns.Add(new DataGridViewTextBoxColumn { Name = "IDProducto", HeaderText = "ID Producto", Visible = false }); // Oculto
            dtDetalles.Columns.Add(new DataGridViewTextBoxColumn { Name = "Producto", HeaderText = "Producto", Width = 200 });
            dtDetalles.Columns.Add(new DataGridViewTextBoxColumn { Name = "Cantidad", HeaderText = "Cantidad", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight } });
            dtDetalles.Columns.Add(new DataGridViewTextBoxColumn { Name = "PrecioUnitario", HeaderText = "Precio Unitario", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N2" } });
            dtDetalles.Columns.Add(new DataGridViewTextBoxColumn { Name = "Subtotal", HeaderText = "Subtotal", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N2" } });
        }

        private async void CargarDetallesVenta()
        {
            // Obtener detalles de la venta
            List<DetalleVenta> detalles = await _ventaController.ObtenerDetallesVentaAsync(_idVenta);

            // Obtener la información general de la venta
            Venta venta = await _ventaController.ObtenerVentaPorIdAsync(_idVenta);

            if (venta != null)
            {
                txtFecha.Text = $"Fecha: {venta.FechaVenta:dd/MM/yyyy}";
                txtFactura.Text = $"Factura N°: {venta.IDVenta}";
            }

            MostrarDetallesEnGrid(detalles);
        }

        private void MostrarDetallesEnGrid(List<DetalleVenta> detalles)
        {
            dtDetalles.Rows.Clear();

            foreach (var detalle in detalles)
            {
                dtDetalles.Rows.Add(
                    detalle.IDProducto,
                    detalle.NombreProducto,
                    detalle.Cantidad,
                    detalle.PrecioUnitario,
                    detalle.Cantidad * detalle.PrecioUnitario
                );
            }
        }
    }
}
