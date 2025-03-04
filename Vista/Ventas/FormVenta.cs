using Sopromil.Controlador;
using Sopromil.Modelo;
using Sopromil.Vista.Caja;
using Sopromil.Vista.Productos;
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
        private string impresoraConfigurada;


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
            impresoraConfigurada = await _cajaController.ObtenerImpresoraAsync();
        }

        private void ImprimirRecibo(int idVenta, Venta venta, decimal devuelta)
        {
            try
            {
                var printDocument = new PrintDocument();
                printDocument.PrinterSettings.PrinterName = impresoraConfigurada;
                printDocument.PrintPage += (s, e) => ImprimirReciboContenido(e.Graphics, idVenta, venta, devuelta);
                printDocument.Print();
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(ImprimirRecibo));
                MessageBox.Show($"Error al imprimir el recibo de la venta.\n{ex.Message}", "Error de impresión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImprimirReciboContenido(Graphics g, int idVenta, Venta venta, decimal devuelta)
        {
            try
            {
                int y = 10;
                Font fontNormal = new Font("Arial", 9);
                Font fontBold = new Font("Arial", 11, FontStyle.Bold);
                Font fontLarge = new Font("Arial", 12, FontStyle.Bold);

                // Encabezado
                g.DrawString("SOPROMIL - TIENDA", fontLarge, Brushes.Black, 30, y);
                y += 25;
                g.DrawString($"Venta No: {idVenta}", fontBold, Brushes.Black, 0, y);
                y += 20;
                g.DrawString($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm:ss}", fontNormal, Brushes.Black, 0, y);
                y += 20;

                g.DrawString("================================", fontNormal, Brushes.Black, 0, y);
                y += 20;

                // Encabezado de productos
                g.DrawString("Producto        Cant   Subtotal", fontBold, Brushes.Black, 0, y);
                y += 20;
                g.DrawString("--------------------------------", fontNormal, Brushes.Black, 0, y);
                y += 15;

                // Recorrer productos
                foreach (DataGridViewRow row in dtVenta.Rows)
                {
                    if (row.IsNewRow) continue;

                    string descripcion = row.Cells["Descripcion"].Value?.ToString()?.Trim() ?? "SIN DESC.";
                    string cantidad = row.Cells["Cantidad"].Value?.ToString()?.Trim() ?? "0";
                    string subtotal = row.Cells["Subtotal"].Value?.ToString()?.Trim() ?? "$0";

                    // Limpiar formato de moneda y evitar errores
                    decimal subtotalDecimal = 0;
                    decimal.TryParse(subtotal.Replace("$", "").Replace(".", "").Replace(",", ""), out subtotalDecimal);
                    string subtotalFormateado = subtotalDecimal.ToString("C0", culturaColombiana);

                    // Ajustar descripción a 15 caracteres (evitar desbordes en térmica)
                    if (descripcion.Length > 15)
                        descripcion = descripcion.Substring(0, 15);

                    string lineaProducto = $"{descripcion.PadRight(15)} {cantidad.PadLeft(4)} {subtotalFormateado.PadLeft(10)}";

                    g.DrawString(lineaProducto, fontNormal, Brushes.Black, 0, y);
                    y += 20;
                }

                // Línea final
                g.DrawString("================================", fontNormal, Brushes.Black, 0, y);
                y += 20;

                // Totales
                g.DrawString($"TOTAL: {venta.MontoTotal.ToString("C0", culturaColombiana)}", fontBold, Brushes.Black, 0, y);
                y += 20;

                if (venta.TipoPago == "Efectivo")
                {
                    g.DrawString($"Devuelta: {devuelta.ToString("C0", culturaColombiana)}", fontBold, Brushes.Black, 0, y);
                    y += 20;
                }

                g.DrawString("¡Gracias por su compra!", fontNormal, Brushes.Black, 0, y);
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(ImprimirReciboContenido));
                // Nota: NO imprimo errores en el ticket físico. Mejor solo al log.
            }
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

        private async void btnMovimiento_Click(object sender, EventArgs e)
        {
            try
            {
                CajaController cajaController = new CajaController();
                var cajaAbierta = await cajaController.ObtenerCajaAbiertaAsync();

                if (cajaAbierta == null)
                {
                    MessageBox.Show("No hay una caja abierta actualmente. No es posible registrar movimientos extra.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var formMovimiento = new frmMovimientoExtraCaja(cajaAbierta.IDMovimiento))
                {
                    formMovimiento.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(btnMovimiento_Click));
                MessageBox.Show($"Ocurrió un error al intentar abrir el formulario de movimiento extra.\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LogError(Exception ex, string metodo)
        {
            try
            {
                string logPath = "logErrores.txt";
                string mensaje = $"[{DateTime.Now:dd/MM/yyyy HH:mm:ss}] Error en {metodo}: {ex.Message}{Environment.NewLine}";
                System.IO.File.AppendAllText(logPath, mensaje);
            }
            catch
            {
            }
        }

        private void btnDevolucion_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmDevoluciones();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(btnDevolucion_Click));
                MessageBox.Show($"Ocurrió un error al abrir el formulario de devoluciones.\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            try
            {
                using (var frm = new FormProductos())
                {
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(btnProducto_Click));
                MessageBox.Show("Ocurrió un error al abrir el formulario de productos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreditos_Click(object sender, EventArgs e)
        {

        }
    }
}
