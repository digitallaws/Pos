using Sopromil.Controlador;
using Sopromil.Modelo;

namespace Sopromil.Vista.Clientes
{
    public partial class FrmDetallesVenta : Form
    {
        private readonly VentaController _ventaController;
        private int _idVenta;
        private string _cliente;

        public FrmDetallesVenta(int idVenta, string cliente)
        {
            InitializeComponent();
            _ventaController = new VentaController();
            _idVenta = idVenta;
            _cliente = cliente;

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

            dtDetalles.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            dtDetalles.DefaultCellStyle.SelectionForeColor = Color.White;

            dtDetalles.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDetalles.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtDetalles.Columns.Clear();
            dtDetalles.Columns.Add(new DataGridViewTextBoxColumn { Name = "IDProducto", HeaderText = "ID Producto", Visible = false });
            dtDetalles.Columns.Add(new DataGridViewTextBoxColumn { Name = "Producto", HeaderText = "Producto", Width = 200 });
            dtDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Cantidad",
                HeaderText = "Cantidad",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter, Format = "N0" }
            });
            dtDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PrecioUnitario",
                HeaderText = "Precio Unitario",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter, Format = "N0" }
            });
            dtDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Subtotal",
                HeaderText = "Subtotal",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter, Format = "N0" }
            });
        }

        private async void CargarDetallesVenta()
        {
            List<DetalleVenta> detalles = await _ventaController.ObtenerDetallesVentaAsync(_idVenta);
            Venta venta = await _ventaController.ObtenerVentaPorIdAsync(_idVenta);

            if (venta != null)
            {
                txtFecha.Text = $"Fecha: {venta.FechaVenta:dd/MM/yyyy}";
                txtFactura.Text = $"Factura N°: {venta.IDVenta}";
                txtCliente.Text = $"Cliente: {_cliente}";
            }

            MostrarDetallesEnGrid(detalles);
        }

        private void MostrarDetallesEnGrid(List<DetalleVenta> detalles)
        {
            dtDetalles.Rows.Clear();
            decimal totalFactura = 0;

            foreach (var detalle in detalles)
            {
                decimal cantidad = Math.Round(detalle.Cantidad, 0);  // 🔥 Redondeo de cantidad
                decimal precioUnitario = Math.Round(detalle.PrecioUnitario, 0);  // 🔥 Redondeo de precio unitario
                decimal subtotal = Math.Round(detalle.Cantidad * detalle.PrecioUnitario, 0);  // 🔥 Redondeo del subtotal

                dtDetalles.Rows.Add(
                    detalle.IDProducto,
                    detalle.NombreProducto,
                    cantidad.ToString("N0"),
                    precioUnitario.ToString("N0"),
                    subtotal.ToString("N0")
                );

                totalFactura += subtotal; // 🔥 Sumar subtotal al total de la factura
            }

            CalcularTotalFactura(totalFactura);
        }

        private void CalcularTotalFactura(decimal total)
        {
            lblTotalFactura.Text = $"Total Factura: $ {total:N0}"; // 🔥 Mostrar total sin decimales
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
