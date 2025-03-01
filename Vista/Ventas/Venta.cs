using Sopromil.Controlador;
using Sopromil.Modelo;
using System.Globalization;

namespace Sopromil.Vista.Ventas
{
    public partial class Venta : Form
    {
        private readonly ClienteController _clienteController;
        private readonly ProductoController _productoController;
        private readonly VentaController _ventaController;
        private readonly CajaController _cajaController;
        private List<Producto> _productosDisponibles;
        private readonly CultureInfo culturaColombiana = new CultureInfo("es-CO");

        public Venta()
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

        private async Task CargarClientes()
        {
            var clientes = await _clienteController.ObtenerClientesAsync();
            cmbClientes.DataSource = clientes;
            cmbClientes.DisplayMember = "Nombre";
            cmbClientes.ValueMember = "IDCliente";

            decimal ventasDesdeApertura = await _cajaController.CalcularVentasDesdeAperturaCajaAsync();
            lblVenta.Text = $"{ventasDesdeApertura.ToString("C0", culturaColombiana)}";
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
            dtVenta.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dtVenta.BackgroundColor = Color.White;
            dtVenta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtVenta.Dock = DockStyle.Fill;
            dtVenta.ReadOnly = false;
            dtVenta.RowHeadersVisible = false;
            dtVenta.RowHeadersWidth = 51;
            dtVenta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dtVenta.DefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dtVenta.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dtVenta.DefaultCellStyle.ForeColor = Color.Black;
            dtVenta.DefaultCellStyle.BackColor = Color.White;

            dtVenta.Columns.Clear();

            dtVenta.Columns.Add("IDProducto", "IDProducto");
            dtVenta.Columns["IDProducto"].Visible = false;

            dtVenta.Columns.Add("Descripcion", "Descripción");
            dtVenta.Columns.Add("Cantidad", "Cantidad");
            dtVenta.Columns.Add("PrecioUnitario", "Precio Unitario");
            dtVenta.Columns.Add("Subtotal", "Subtotal");

            DataGridViewButtonColumn btnRestar = new DataGridViewButtonColumn
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
                string textoBusqueda = txtBuscarProducto.Text.Trim();
                if (!string.IsNullOrEmpty(textoBusqueda))
                {
                    await BuscarYAgregarProducto(textoBusqueda);
                }
                txtBuscarProducto.Clear();
            }
        }

        private void InicializarReloj()
        {
            relojTimer = new System.Windows.Forms.Timer();
            relojTimer.Interval = 1000;
            relojTimer.Tick += RelojTimer_Tick;
            relojTimer.Start();
            lblReloj.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void RelojTimer_Tick(object sender, EventArgs e)
        {
            lblReloj.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private async Task BuscarYAgregarProducto(string criterio)
        {
            var producto = _productosDisponibles.FirstOrDefault(p => p.CodigoBarras == criterio || p.Descripcion.Contains(criterio));

            if (producto == null)
            {
                var productosDB = await _productoController.FiltrarProductosAsync(null, null, criterio, criterio);
                producto = productosDB.FirstOrDefault();
            }

            if (producto == null || producto.IDProducto <= 0)
            {
                MessageBox.Show("Producto no encontrado o tiene un ID inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            dtVenta.Rows.Add(
                producto.IDProducto,
                producto.Descripcion,
                1,
                producto.PrecioVenta.ToString("C0", culturaColombiana),
                producto.PrecioVenta.ToString("C0", culturaColombiana)
            );
            CalcularTotal();
        }

        private void dtVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dtVenta.Columns[e.ColumnIndex].Name == "Restar")
            {
                RestarCantidadProducto(e.RowIndex);
            }
        }

        private void RestarCantidadProducto(int rowIndex)
        {
            var fila = dtVenta.Rows[rowIndex];
            int cantidad = Convert.ToInt32(fila.Cells["Cantidad"].Value);

            if (cantidad > 1)
            {
                fila.Cells["Cantidad"].Value = --cantidad;
                ActualizarSubtotal(fila);
            }
            else
            {
                if (MessageBox.Show("¿Eliminar producto de la venta?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dtVenta.Rows.RemoveAt(rowIndex);
                }
            }

            CalcularTotal();
        }

        private void ActualizarSubtotal(DataGridViewRow fila)
        {
            decimal precioUnitario = Convert.ToDecimal(fila.Cells["PrecioUnitario"].Value.ToString().Replace("$", "").Replace(".", ""));
            decimal subtotal = precioUnitario * Convert.ToInt32(fila.Cells["Cantidad"].Value);
            fila.Cells["Subtotal"].Value = subtotal.ToString("C0", culturaColombiana);
        }

        private decimal CalcularTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dtVenta.Rows)
            {
                if (!row.IsNewRow)
                {
                    string valorTexto = row.Cells["Subtotal"].Value.ToString().Replace("$", "").Replace(".", "");
                    total += Convert.ToDecimal(valorTexto);
                }
            }

            lblTotal.Text = $"Total: {total.ToString("C0", culturaColombiana)}";
            return total;
        }

        private async void btnFacturar_Click(object sender, EventArgs e)
        {
            if (dtVenta.Rows.Count == 0)
            {
                MessageBox.Show("No hay productos para vender.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!SesionActual.EstaAutenticado)
            {
                MessageBox.Show("Debe iniciar sesión para realizar una venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal totalVenta = CalcularTotal();

            var frmPago = new FrmSeleccionarPago(totalVenta);
            if (frmPago.ShowDialog() != DialogResult.OK)
            {
                return; // Canceló el proceso
            }

            var nuevaVenta = new Modelo.Venta
            {
                IDCliente = frmPago.TipoPago == "Crédito" ? frmPago.IDCliente : Convert.ToInt32(cmbClientes.SelectedValue),
                FechaVenta = DateTime.Now,
                MontoTotal = totalVenta,
                TipoPago = frmPago.TipoPago,
                IDUsuario = SesionActual.IDUsuario
            };

            int idVenta = await _ventaController.RegistrarVentaAsync(nuevaVenta);

            if (idVenta > 0)
            {
                await RegistrarDetalleVentaAsync(idVenta);

                if (frmPago.TipoPago == "Efectivo")
                {
                    MessageBox.Show($"Venta registrada.\nDevuelta: {frmPago.Devuelta.ToString("C0", new System.Globalization.CultureInfo("es-CO"))}",
                                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (frmPago.TipoPago == "Crédito")
                {
                    await ActualizarSaldoCredito(frmPago.IDCliente, totalVenta);
                    MessageBox.Show("Venta registrada y saldo actualizado en el crédito del cliente.",
                                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                dtVenta.Rows.Clear();
                CalcularTotal();
            }
            else
            {
                MessageBox.Show("Error al registrar la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task ActualizarSaldoCredito(int idCliente, decimal monto)
        {
            try
            {
                var creditoController = new CreditoController();
                await creditoController.ActualizarSaldoCreditoAsync(idCliente, monto);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el saldo del crédito: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async Task RegistrarDetalleVentaAsync(int idVenta)
        {
            foreach (DataGridViewRow row in dtVenta.Rows)
            {
                if (row.IsNewRow) continue;

                string precioTexto = row.Cells["PrecioUnitario"].Value.ToString();
                precioTexto = precioTexto.Replace("$", "").Replace(".", "").Replace(" ", ""); // Limpiar formato

                var detalle = new DetalleVenta
                {
                    IDVenta = idVenta,
                    IDProducto = Convert.ToInt32(row.Cells["IDProducto"].Value),
                    Cantidad = Convert.ToDecimal(row.Cells["Cantidad"].Value),
                    PrecioUnitario = Convert.ToDecimal(precioTexto)  // Ahora sí es seguro convertir
                };
            }
        }
    }
}
