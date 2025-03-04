using Sopromil.Controlador;
using Sopromil.Modelo;
using System.Drawing.Printing;
using System.Globalization;

namespace Sopromil.Vista.Ventas
{
    public partial class FormVenta : Form
    {
        private readonly ClienteController _clienteController;
        private readonly ProductoController _productoController;
        private readonly VentaController _ventaController;
        private readonly CajaController _cajaController;
        private List<Producto> _productosDisponibles;
        private readonly CultureInfo culturaColombiana = new CultureInfo("es-CO");

        public FormVenta()
        {
            InitializeComponent();
            _clienteController = new ClienteController();
            _productoController = new ProductoController();
            _ventaController = new VentaController();
            _cajaController = new CajaController();
        }

        private async void Venta_Load(object sender, EventArgs e)
        {
            await CargarClientes();
            await CargarProductos();
            ConfigurarTablaVenta();
            InicializarReloj();
        }

        private void InicializarReloj()
        {
            relojTimer = new System.Windows.Forms.Timer();
            relojTimer.Interval = 1000;  // Cada segundo
            relojTimer.Tick += RelojTimer_Tick;
            relojTimer.Start();

            lblReloj.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void RelojTimer_Tick(object sender, EventArgs e)
        {
            lblReloj.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private async Task CargarClientes()
        {
            var clientes = await _clienteController.ObtenerClientesAsync();
            cmbClientes.DataSource = clientes;
            cmbClientes.DisplayMember = "Nombre";
            cmbClientes.ValueMember = "IDCliente";

            decimal ventasDesdeApertura = await _cajaController.CalcularVentasDesdeAperturaCajaAsync();
            lblVenta.Text = ventasDesdeApertura.ToString("C0", culturaColombiana);
        }

        private async Task CargarProductos()
        {
            _productosDisponibles = await _productoController.ObtenerProductosAsync();
        }

        private void ConfigurarTablaVenta()
        {
            dtVenta.AllowUserToAddRows = false;
            dtVenta.AllowUserToDeleteRows = false;
            dtVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtVenta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dtVenta.Columns.Clear();
            dtVenta.Columns.Add("IDProducto", "IDProducto");
            dtVenta.Columns["IDProducto"].Visible = false;
            dtVenta.Columns.Add("Descripcion", "Descripción");
            dtVenta.Columns.Add("Cantidad", "Cantidad");
            dtVenta.Columns.Add("PrecioUnitario", "Precio Unitario");
            dtVenta.Columns.Add("Subtotal", "Subtotal");

            var btnRestar = new DataGridViewButtonColumn
            {
                Name = "Restar",
                HeaderText = "Acción",
                Text = "-",
                UseColumnTextForButtonValue = true
            };
            dtVenta.Columns.Add(btnRestar);

            dtVenta.CellClick += dtVenta_CellClick;
        }

        private async void txtBuscarProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await BuscarYAgregarProducto(txtBuscarProducto.Text.Trim());
                txtBuscarProducto.Clear();
            }
        }

        private async Task BuscarYAgregarProducto(string criterio)
        {
            var producto = _productosDisponibles.FirstOrDefault(p => p.CodigoBarras == criterio || p.Descripcion.Contains(criterio));

            if (producto == null)
            {
                var productosDB = await _productoController.FiltrarProductosAsync(null, null, criterio, criterio);
                producto = productosDB.FirstOrDefault();
            }

            if (producto == null)
            {
                MessageBox.Show("Producto no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AgregarProductoATabla(producto);
        }

        private void AgregarProductoATabla(Producto producto)
        {
            foreach (DataGridViewRow row in dtVenta.Rows)
            {
                if (Convert.ToInt32(row.Cells["IDProducto"].Value) == producto.IDProducto)
                {
                    row.Cells["Cantidad"].Value = Convert.ToInt32(row.Cells["Cantidad"].Value) + 1;
                    ActualizarSubtotal(row);
                    CalcularTotal();
                    return;
                }
            }

            dtVenta.Rows.Add(producto.IDProducto, producto.Descripcion, 1, producto.PrecioVenta.ToString("C0", culturaColombiana), producto.PrecioVenta.ToString("C0", culturaColombiana));
            CalcularTotal();
        }

        private void dtVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dtVenta.Columns[e.ColumnIndex].Name == "Restar")
                RestarCantidadProducto(e.RowIndex);
        }

        private void RestarCantidadProducto(int rowIndex)
        {
            var row = dtVenta.Rows[rowIndex];
            int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);

            if (cantidad > 1)
            {
                row.Cells["Cantidad"].Value = --cantidad;
                ActualizarSubtotal(row);
            }
            else
            {
                dtVenta.Rows.RemoveAt(rowIndex);
            }

            CalcularTotal();
        }

        private void ActualizarSubtotal(DataGridViewRow row)
        {
            decimal precio = decimal.Parse(row.Cells["PrecioUnitario"].Value.ToString().Replace("$", "").Replace(".", ""));
            row.Cells["Subtotal"].Value = (precio * Convert.ToInt32(row.Cells["Cantidad"].Value)).ToString("C0", culturaColombiana);
        }

        private decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dtVenta.Rows)
            {
                total += decimal.Parse(row.Cells["Subtotal"].Value.ToString().Replace("$", "").Replace(".", ""));
            }
            lblTotal.Text = $"Total: {total:C0}";
            return total;
        }

        private async void btnFacturar_Click(object sender, EventArgs e)
        {
            if (dtVenta.Rows.Count == 0)
            {
                MessageBox.Show("No hay productos para vender.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal totalVenta = CalcularTotal();
            var frmPago = new FrmSeleccionarPago(totalVenta);
            if (frmPago.ShowDialog() != DialogResult.OK) return;

            var venta = new Modelo.Venta
            {
                IDCliente = frmPago.TipoPago == "Crédito" ? frmPago.IDCliente : Convert.ToInt32(cmbClientes.SelectedValue),
                FechaVenta = DateTime.Now,
                MontoTotal = totalVenta,
                TipoPago = frmPago.TipoPago,
                IDUsuario = SesionActual.IDUsuario
            };

            int idVenta = await _ventaController.RegistrarVentaAsync(venta);
            if (idVenta <= 0)
            {
                MessageBox.Show("Error al registrar la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            await RegistrarDetalleVentaAsync(idVenta);

            if (frmPago.TipoPago == "Crédito")
                await ActualizarSaldoCredito(frmPago.IDCliente, totalVenta);

            ImprimirRecibo(idVenta, venta, frmPago.Devuelta);
            dtVenta.Rows.Clear();
            CalcularTotal();
        }

        private async Task RegistrarDetalleVentaAsync(int idVenta)
        {
            foreach (DataGridViewRow row in dtVenta.Rows)
            {
                var detalle = new DetalleVenta
                {
                    IDVenta = idVenta,
                    IDProducto = Convert.ToInt32(row.Cells["IDProducto"].Value),
                    Cantidad = Convert.ToDecimal(row.Cells["Cantidad"].Value),
                    PrecioUnitario = decimal.Parse(row.Cells["PrecioUnitario"].Value.ToString().Replace("$", "").Replace(".", ""))
                };
                await _ventaController.RegistrarDetalleVentaAsync(detalle);
            }
        }

        private async Task ActualizarSaldoCredito(int idCliente, decimal monto)
        {
            var creditoController = new CreditoController();
            await creditoController.ActualizarSaldoCreditoAsync(idCliente, monto);
        }

        private void ImprimirRecibo(int idVenta, Modelo.Venta venta, decimal devuelta)
        {
            var doc = new PrintDocument();
            doc.PrintPage += (s, e) => ImprimirReciboContenido(e.Graphics, idVenta, venta, devuelta);
            doc.Print();
        }

        private void ImprimirReciboContenido(Graphics g, int idVenta, Modelo.Venta venta, decimal devuelta)
        {
            try
            {
                int y = 10; // Margen superior
                Font tituloFont = new Font("Arial", 12, FontStyle.Bold);
                Font normalFont = new Font("Arial", 10);
                Font negritaFont = new Font("Arial", 10, FontStyle.Bold);

                // Encabezado
                g.DrawString("SOPROMIL - FACTURA", tituloFont, Brushes.Black, 0, y);
                y += 25;

                g.DrawString($"Venta No: {idVenta}", negritaFont, Brushes.Black, 0, y);
                y += 20;

                g.DrawString($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm:ss}", normalFont, Brushes.Black, 0, y);
                y += 25;

                g.DrawString("================================", normalFont, Brushes.Black, 0, y);
                y += 20;

                // Encabezado de productos
                g.DrawString("Producto         Cant  Subtotal", negritaFont, Brushes.Black, 0, y);
                y += 20;
                g.DrawString("--------------------------------", normalFont, Brushes.Black, 0, y);
                y += 15;

                // Recorrer productos
                foreach (DataGridViewRow row in dtVenta.Rows)
                {
                    try
                    {
                        string descripcion = row.Cells["Descripcion"].Value?.ToString() ?? string.Empty;
                        string cantidad = row.Cells["Cantidad"].Value?.ToString() ?? "0";
                        string subtotalTexto = row.Cells["Subtotal"].Value?.ToString() ?? "0";

                        // Limpiar el formato de moneda que viene con caracteres especiales
                        decimal subtotal = 0;

                        if (decimal.TryParse(
                            subtotalTexto.Replace("$", "").Replace(".", "").Replace(",", "").Trim(),
                            NumberStyles.Number,
                            CultureInfo.InvariantCulture,
                            out subtotal))
                        {
                            string subtotalFormateado = subtotal.ToString("C0", culturaColombiana);

                            // Ajustar descripción a 15 caracteres
                            if (descripcion.Length > 15)
                                descripcion = descripcion.Substring(0, 15);

                            g.DrawString($"{descripcion.PadRight(15)} {cantidad.PadLeft(4)} {subtotalFormateado.PadLeft(10)}", normalFont, Brushes.Black, 0, y);
                            y += 20;
                        }
                        else
                        {
                            g.DrawString($"ERROR FORMATO PRODUCTO", normalFont, Brushes.Red, 0, y);
                            y += 20;
                        }
                    }
                    catch (Exception exProd)
                    {
                        g.DrawString($"ERROR PRODUCTO: {exProd.Message}", normalFont, Brushes.Red, 0, y);
                        y += 20;
                    }
                }

                // Línea final
                g.DrawString("================================", normalFont, Brushes.Black, 0, y);
                y += 20;

                // Totales
                g.DrawString($"TOTAL: {venta.MontoTotal.ToString("C0", culturaColombiana)}", negritaFont, Brushes.Black, 0, y);
                y += 20;

                if (venta.TipoPago == "Efectivo")
                {
                    g.DrawString($"Devuelta: {devuelta.ToString("C0", culturaColombiana)}", negritaFont, Brushes.Black, 0, y);
                    y += 20;
                }

                g.DrawString("Gracias por su compra!", normalFont, Brushes.Black, 0, y);
            }
            catch (Exception ex)
            {
                g.DrawString($"ERROR IMPRIMIENDO RECIBO", new Font("Arial", 10, FontStyle.Bold), Brushes.Red, 0, 0);
                g.DrawString(ex.Message, new Font("Arial", 8), Brushes.Red, 0, 20);
            }
        }
    }
}
