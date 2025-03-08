using Sopromil.Controlador;
using Sopromil.Impresion;
using Sopromil.Modelo;

namespace Sopromil.Vista.Ventas
{
    public partial class FrmVentas : Form
    {
        private readonly ClienteController _clienteController;
        private readonly ProductoController _productoController;
        private readonly VentaController _ventaController;
        private List<Cliente> _clientes = new();
        private List<Producto> _productos = new();
        private bool seleccionDesdeLista = false;

        public FrmVentas()
        {
            InitializeComponent();
            _clienteController = new ClienteController();
            _productoController = new ProductoController();
            _ventaController = new VentaController();

            ConfigurarEventos();
            CargarClientes();
            ConfigurarDataGridView();
            ConfigurarComboBoxProductos();
            ConfigurarComboBoxClientes();
            CargarProductos();
        }

        #region Carga de Datos

        private void ConfigurarDataGridView()
        {
            dtVentas.AllowUserToAddRows = false;
            dtVentas.AllowUserToDeleteRows = false;
            dtVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtVentas.BackgroundColor = Color.White;
            dtVentas.ReadOnly = true;
            dtVentas.RowHeadersVisible = false;
            dtVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dtVentas.DefaultCellStyle.Font = new Font("Arial", 13, FontStyle.Regular);
            dtVentas.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 13, FontStyle.Bold);
            dtVentas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtVentas.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            dtVentas.DefaultCellStyle.SelectionForeColor = Color.White;

            dtVentas.Columns.Add(new DataGridViewTextBoxColumn { Name = "IDProducto", HeaderText = "ID", Visible = false });
            dtVentas.Columns.Add(new DataGridViewTextBoxColumn { Name = "Nombre", HeaderText = "Producto", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dtVentas.Columns.Add(new DataGridViewTextBoxColumn { Name = "Cantidad", HeaderText = "Cantidad", Width = 80, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dtVentas.Columns.Add(new DataGridViewTextBoxColumn { Name = "PrecioUnitario", HeaderText = "Precio Unitario", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dtVentas.Columns.Add(new DataGridViewTextBoxColumn { Name = "Total", HeaderText = "Total", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } });

            DataGridViewButtonColumn btnMas = new DataGridViewButtonColumn
            {
                Name = "Mas",
                HeaderText = "➕",
                Text = "+",
                UseColumnTextForButtonValue = true,
                Width = 40
            };
            dtVentas.Columns.Add(btnMas);

            DataGridViewButtonColumn btnMenos = new DataGridViewButtonColumn
            {
                Name = "Menos",
                HeaderText = "➖",
                Text = "-",
                UseColumnTextForButtonValue = true,
                Width = 40
            };
            dtVentas.Columns.Add(btnMenos);

            dtVentas.CellClick += DtVentas_CellClick;
        }

        private decimal ObtenerStockProducto(int idProducto)
        {
            var producto = _productos.FirstOrDefault(p => p.IDProducto == idProducto);
            return producto != null ? Math.Floor(producto.Stock) : 0;
        }

        private async void CargarClientes()
        {
            try
            {
                _clientes = await _clienteController.ObtenerClientesAsync(true);
                CargarClientesEnComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void CargarProductos()
        {
            try
            {
                _productos = await _productoController.ListarTodosLosProductosAsync();
                _productos = _productos.Where(p => p.Stock > 0).ToList();
                CargarProductosEnComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Configuración de ComboBox

        private void ConfigurarComboBoxProductos()
        {
            cbBuscarProducto.DropDownStyle = ComboBoxStyle.DropDown;
            cbBuscarProducto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbBuscarProducto.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbBuscarProducto.TextChanged += CbBuscarProducto_TextChanged;
            cbBuscarProducto.KeyDown += CbBuscarProducto_KeyDown;
            cbBuscarProducto.SelectedIndexChanged += CbBuscarProducto_SelectedIndexChanged;
            cbBuscarProducto.Leave += CbBuscarProducto_Leave;
        }

        private void ConfigurarComboBoxClientes()
        {
            cbBuscarCliente.DropDownStyle = ComboBoxStyle.DropDown;
            cbBuscarCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbBuscarCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbBuscarCliente.TextChanged += CbBuscarCliente_TextChanged;
            cbBuscarCliente.KeyDown += CbBuscarCliente_KeyDown;
            cbBuscarCliente.SelectedIndexChanged += CbBuscarCliente_SelectedIndexChanged;
            cbBuscarCliente.Leave += CbBuscarCliente_Leave;

            btnCrearCliente.Visible = false;
            btnCrearCliente.Click += BtnCrearCliente_Click;
        }

        private void CargarProductosEnComboBox()
        {
            var autoCompleteCollection = new AutoCompleteStringCollection();
            foreach (var producto in _productos.Where(p => p.Stock > 0))
            {
                autoCompleteCollection.Add(producto.Descripcion);
            }
            cbBuscarProducto.AutoCompleteCustomSource = autoCompleteCollection;
        }

        private void CargarClientesEnComboBox()
        {
            var autoCompleteCollection = new AutoCompleteStringCollection();
            foreach (var cliente in _clientes)
            {
                autoCompleteCollection.Add(cliente.Nombre);
            }
            cbBuscarCliente.AutoCompleteCustomSource = autoCompleteCollection;
        }

        private async void BtnFacturar_Click(object sender, EventArgs e)
        {
            if (dtVentas.Rows.Count == 0)
            {
                MessageBox.Show("No hay productos en la venta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(lbCliente.Text) || lbCliente.Text == "0")
            {
                MessageBox.Show("Debe seleccionar un cliente antes de facturar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FrmSeleccionTipoPago frmSeleccionTipoPago = new FrmSeleccionTipoPago();
            if (frmSeleccionTipoPago.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string tipoPago = frmSeleccionTipoPago.TipoPagoSeleccionado;
            DateTime? fechaPagoCredito = null;
            decimal pagoTotal = 0;
            bool ventaConfirmada = false;

            if (tipoPago == "Crédito")
            {
                FrmPagoCredito frmCredito = new FrmPagoCredito(int.Parse(lbCliente.Text), cbBuscarCliente.Text);
                if (frmCredito.ShowDialog() == DialogResult.OK && frmCredito.VentaConfirmada)
                {
                    fechaPagoCredito = frmCredito.FechaEstimadaPago;
                    ventaConfirmada = true;
                }
            }
            else if (tipoPago == "Contado")
            {
                FrmPagoContado frmContado = new FrmPagoContado(decimal.Parse(lblTotal.Text.Replace("Total: $ ", "").Replace(",", "")));
                if (frmContado.ShowDialog() == DialogResult.OK && frmContado.VentaConfirmada)
                {
                    ventaConfirmada = true;
                }
            }

            if (!ventaConfirmada)
            {
                MessageBox.Show("La venta no fue confirmada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<DetalleVenta> detalles = ObtenerDetallesVenta();

            Venta nuevaVenta = new Venta
            {
                IDCliente = int.Parse(lbCliente.Text),
                TotalVenta = detalles.Sum(d => d.Total),
                Estado = tipoPago == "Contado" ? "Pagado" : "Pendiente",
                TipoVenta = tipoPago,
                FechaEstimadaPago = tipoPago == "Crédito" ? fechaPagoCredito : null
            };

            try
            {
                int idVenta = await _ventaController.RegistrarVentaAsync(nuevaVenta, detalles);

                if (idVenta > 0)
                {
                    MessageBox.Show($"Venta registrada exitosamente con ID {idVenta}.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();

                    TirillaPrinter impresora = new TirillaPrinter(nuevaVenta, detalles);
                    impresora.Imprimir();

                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show("Error al registrar la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al facturar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<DetalleVenta> ObtenerDetallesVenta()
        {
            List<DetalleVenta> detalles = new();

            foreach (DataGridViewRow row in dtVentas.Rows)
            {
                if (row.Cells["IDProducto"].Value != null)
                {
                    DetalleVenta detalle = new()
                    {
                        IDProducto = Convert.ToInt32(row.Cells["IDProducto"].Value),
                        Cantidad = Convert.ToDecimal(row.Cells["Cantidad"].Value),
                        PrecioUnitario = Convert.ToDecimal(row.Cells["PrecioUnitario"].Value),
                    };

                    detalles.Add(detalle);
                }
            }

            return detalles;
        }

        private void LimpiarFormulario()
        {
            // 🔥 Limpiar cliente
            lbCliente.Text = "0";
            cbBuscarCliente.Text = "";
            txtDocumento.Clear();
            txtTelefono.Clear();

            // 🔥 Limpiar productos
            cbBuscarProducto.Text = "";
            lbIdProducto.Text = "0";
            lblStock.Text = "Stock: 0";

            // 🔥 Limpiar DataGridView
            dtVentas.Rows.Clear();

            // 🔥 Limpiar total de la compra
            lblTotal.Text = "$ 0";

            // 🔥 Habilitar botón de facturar solo si hay productos
            btnFacturar.Enabled = false;
        }

        #endregion

        #region Eventos

        private void CbBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            if (!seleccionDesdeLista)
            {
                cbBuscarProducto.DroppedDown = false; // 🔥 Evita que se despliegue sin necesidad
            }
        }

        private void CbBuscarProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string codigoIngresado = cbBuscarProducto.Text.Trim();

                if (string.IsNullOrWhiteSpace(codigoIngresado))
                {
                    return; // Evita procesar un campo vacío
                }

                // 🔥 Buscar por código de barras o descripción
                var productoSeleccionado = _productos.FirstOrDefault(p =>
                    p.CodigoBarras == codigoIngresado || p.Descripcion.ToLower() == codigoIngresado.ToLower());

                if (productoSeleccionado != null)
                {
                    // 🔥 Asignar datos
                    lbIdProducto.Text = productoSeleccionado.IDProducto.ToString();
                    lblStock.Text = $"Stock: {Math.Floor(productoSeleccionado.Stock)}";
                    cbBuscarProducto.Text = productoSeleccionado.Descripcion;

                    // 🔥 Agregar automáticamente
                    AgregarProductoSeleccionado();
                    cbBuscarProducto.Text = ""; // 🔥 Limpiar el ComboBox
                }
                else
                {
                    MessageBox.Show("Producto no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                e.SuppressKeyPress = true; // Evita sonidos o caracteres no deseados
            }
        }

        private void CbBuscarProducto_Leave(object sender, EventArgs e)
        {
            seleccionDesdeLista = false; // 🔥 Restablece el estado para evitar bugs
        }

        private void CbBuscarProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBuscarProducto.SelectedIndex != -1)
            {
                seleccionDesdeLista = true; // 🔥 Indica que se está seleccionando desde la lista
                var productoSeleccionado = _productos.FirstOrDefault(p => p.Descripcion == cbBuscarProducto.Text);

                if (productoSeleccionado != null)
                {
                    lbIdProducto.Text = productoSeleccionado.IDProducto.ToString();
                    lblStock.Text = $"Stock: {Math.Floor(productoSeleccionado.Stock)}";
                }
            }
        }

        private void DtVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int idProducto = Convert.ToInt32(dtVentas.Rows[e.RowIndex].Cells["IDProducto"].Value);
            decimal cantidadActual = Convert.ToDecimal(dtVentas.Rows[e.RowIndex].Cells["Cantidad"].Value);
            decimal precioUnitario = Convert.ToDecimal(dtVentas.Rows[e.RowIndex].Cells["PrecioUnitario"].Value);
            decimal stockDisponible = ObtenerStockProducto(idProducto);

            // 🔥 Botón ➕ (Aumentar cantidad)
            if (dtVentas.Columns[e.ColumnIndex].Name == "Mas")
            {
                if (cantidadActual + 1 > stockDisponible)
                {
                    MessageBox.Show("No hay suficiente stock disponible.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                cantidadActual += 1;
            }
            // 🔥 Botón ➖ (Disminuir cantidad)
            else if (dtVentas.Columns[e.ColumnIndex].Name == "Menos")
            {
                if (cantidadActual - 1 <= 0)
                {
                    dtVentas.Rows.RemoveAt(e.RowIndex); // 🔥 Elimina la fila si la cantidad llega a 0
                    ActualizarTotalVenta();
                    return;
                }

                cantidadActual -= 1;
            }

            // 🔥 Actualizar cantidad y total con formato
            dtVentas.Rows[e.RowIndex].Cells["Cantidad"].Value = cantidadActual;
            dtVentas.Rows[e.RowIndex].Cells["Total"].Value = $"{Math.Round(cantidadActual * precioUnitario):N0}";

            ActualizarTotalVenta();
        }

        private void CbBuscarCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBuscarCliente.SelectedIndex != -1)
            {
                seleccionDesdeLista = true; // 🔥 Evita alerta innecesaria

                var clienteSeleccionado = _clientes.FirstOrDefault(c => c.Nombre == cbBuscarCliente.Text);
                if (clienteSeleccionado != null)
                {
                    lbCliente.Text = clienteSeleccionado.IDCliente.ToString();
                    txtDocumento.Text = clienteSeleccionado.Documento;
                    txtTelefono.Text = clienteSeleccionado.Telefono;
                    btnCrearCliente.Visible = false; // 🔥 Ocultar botón de creación
                }

                seleccionDesdeLista = false;
            }
        }

        private void CbBuscarCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                seleccionDesdeLista = true;
                CbBuscarCliente_SelectedIndexChanged(null, null);
                cbBuscarCliente.SelectionStart = cbBuscarCliente.Text.Length; // 🔥 Mantiene la selección
                cbBuscarCliente.DroppedDown = false; // 🔥 Cierra el desplegable si está abierto
                e.SuppressKeyPress = true;
            }
        }

        private void CbBuscarCliente_Leave(object sender, EventArgs e)
        {
            seleccionDesdeLista = false;
        }

        private void CbBuscarCliente_TextChanged(object sender, EventArgs e)
        {
            if (!seleccionDesdeLista)
            {
                string filtro = cbBuscarCliente.Text.Trim().ToLower();

                var clienteExistente = _clientes.FirstOrDefault(c => c.Nombre.ToLower() == filtro);

                if (clienteExistente != null)
                {
                    // 🔥 Cliente encontrado, actualizar datos y bloquear edición
                    lbCliente.Text = clienteExistente.IDCliente.ToString();
                    txtDocumento.Text = clienteExistente.Documento;
                    txtTelefono.Text = clienteExistente.Telefono;
                    btnCrearCliente.Visible = false;
                }
                else
                {
                    // 🔥 Cliente NO encontrado, permitir crearlo
                    lbCliente.Text = "0";
                    txtDocumento.Clear();
                    txtTelefono.Clear();
                    btnCrearCliente.Visible = true;
                }
            }
        }

        private async void BtnCrearCliente_Click(object sender, EventArgs e)
        {
            string nombreCliente = cbBuscarCliente.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombreCliente))
            {
                MessageBox.Show("Debe ingresar un nombre válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var clienteExistente = _clientes.FirstOrDefault(c => c.Nombre.Equals(nombreCliente, StringComparison.OrdinalIgnoreCase));
            if (clienteExistente != null)
            {
                MessageBox.Show("El cliente ya existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                int nuevoID = await _clienteController.CrearClienteAsync(nombreCliente, txtDocumento.Text.Trim(), txtTelefono.Text.Trim());

                if (nuevoID > 0)
                {
                    MessageBox.Show("Cliente creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    lbCliente.Text = nuevoID.ToString();
                    btnCrearCliente.Visible = false;

                    _clientes.Add(new Cliente
                    {
                        IDCliente = nuevoID,
                        Nombre = nombreCliente,
                        Documento = txtDocumento.Text.Trim(),
                        Telefono = txtTelefono.Text.Trim(),
                        Estado = "Activo"
                    });

                    cbBuscarCliente.AutoCompleteCustomSource.Add(nombreCliente);
                }
                else
                {
                    MessageBox.Show("Error al crear el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Configuración de Eventos

        private void ConfigurarEventos()
        {
            cbBuscarProducto.KeyDown += CbBuscarProducto_KeyDown;
            cbBuscarCliente.KeyDown += CbBuscarCliente_KeyDown;
            btnAgregar.Click += BtnAgregar_Click;
            btnFacturar.Click += BtnFacturar_Click;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            AgregarProductoSeleccionado();
        }

        private void AgregarProductoSeleccionado()
        {
            if (string.IsNullOrWhiteSpace(cbBuscarProducto.Text))
            {
                MessageBox.Show("Seleccione un producto antes de agregar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var productoSeleccionado = _productos.FirstOrDefault(p => p.Descripcion == cbBuscarProducto.Text);
            if (productoSeleccionado == null)
            {
                MessageBox.Show("El producto seleccionado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idProducto = productoSeleccionado.IDProducto;
            string nombreProducto = productoSeleccionado.Descripcion;
            decimal stockDisponible = Math.Floor(productoSeleccionado.Stock);
            decimal precioUnitario = Math.Round(productoSeleccionado.ValorVenta);
            decimal total = precioUnitario;

            foreach (DataGridViewRow row in dtVentas.Rows)
            {
                if (Convert.ToInt32(row.Cells["IDProducto"].Value) == idProducto)
                {
                    decimal cantidadActual = Convert.ToDecimal(row.Cells["Cantidad"].Value);

                    if (cantidadActual + 1 > stockDisponible)
                    {
                        MessageBox.Show("No hay suficiente stock disponible.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    row.Cells["Cantidad"].Value = cantidadActual + 1;
                    row.Cells["Total"].Value = (cantidadActual + 1) * precioUnitario;
                    row.Cells["Total"].Value = $"{Math.Round((cantidadActual + 1) * precioUnitario):N0}";

                    ActualizarTotalVenta();
                    cbBuscarProducto.Text = "";
                    return;
                }
            }

            if (stockDisponible >= 1)
            {
                dtVentas.Rows.Add(idProducto, nombreProducto, 1, $"{precioUnitario:N0}", $"{total:N0}");
                ActualizarTotalVenta();
                cbBuscarProducto.Text = "";
            }
            else
            {
                MessageBox.Show("No hay suficiente stock disponible.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ActualizarTotalVenta()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dtVentas.Rows)
            {
                if (row.Cells["Total"].Value != null)
                {
                    total += Convert.ToDecimal(row.Cells["Total"].Value);
                }
            }

            lblTotal.Text = $"Total: $ {total:N0}"; // 🔥 Formato moneda
        }
        #endregion
    }
}
