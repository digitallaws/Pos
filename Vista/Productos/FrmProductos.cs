using Sopromil.Controlador;
using Sopromil.Modelo;

namespace Sopromil.Vista.Productos
{
    public partial class FrmProductos : Form
    {
        private int _idProveedor;
        private string _nombreProveedor;
        private readonly ProductoController _productoController;
        private readonly CompraController _compraController;
        private List<Producto> _productosOriginales = new();
        private List<Producto> _productosSeleccionados = new();

        public FrmProductos(int id, string nombre)
        {
            InitializeComponent();
            _idProveedor = id;
            _nombreProveedor = nombre;
            _productoController = new ProductoController();
            _compraController = new CompraController();
            this.Text = $"Productos - {_nombreProveedor}";
            txtProveedor.Text = _nombreProveedor;
            lbId.Text = _idProveedor.ToString();

            ConfigurarDataGrid();
            ConfigurarEventos();
            ConfigurarFecha();
            CargarProductos();
            EstilizarListBox();

            txtVenta.ReadOnly = true;
        }

        private void AjustarPosicionListBox()
        {
            lstResultados.Location = new Point(txtNombre.Left, txtNombre.Bottom + 2);
            lstResultados.Width = txtNombre.Width;
        }


        #region Configuración Inicial

        private void ConfigurarDataGrid()
        {
            dtCompra.AllowUserToAddRows = false;
            dtCompra.AllowUserToDeleteRows = false;
            dtCompra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtCompra.BackgroundColor = Color.White;
            dtCompra.ReadOnly = true;
            dtCompra.RowHeadersVisible = false;
            dtCompra.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dtCompra.DefaultCellStyle.Font = new Font("Arial", 13, FontStyle.Regular);
            dtCompra.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 13, FontStyle.Bold);

            dtCompra.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            dtCompra.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        private void ConfigurarFecha()
        {
            txtFecha.Format = DateTimePickerFormat.Custom;
            txtFecha.CustomFormat = "txtNombre/MM/yyyy";
        }

        private void ConfigurarEventos()
        {
            txtNombre.TextChanged += BuscarProductos;
            txtCodigo.TextChanged += BuscarProductos;

            lstResultados.Click += LstResultados_Click;
            lstResultados.Leave += (s, e) => lstResultados.Visible = false;

            btnAgregar.Click += btnAgregar_Click;
            btnRegistrar.Click += btnRegistrar_Click;
            dtCompra.CellClick += DtCompra_CellClick;

            txtCompra.TextChanged += (s, e) => CalcularValorVenta();
            txtFlete.TextChanged += (s, e) => CalcularValorVenta();
            txtUtilidad.TextChanged += (s, e) => CalcularValorVenta();
            txtCantidad.TextChanged += (s, e) => CalcularValorVenta();
        }

        private void CargarProductoEnFormulario(Producto producto)
        {
            lbIdProducto.Text = producto.IDProducto.ToString();

            lbPrecioCompraAnterior.Text = producto.PrecioCompra.ToString("N2");

            txtNombre.Text = producto.Descripcion;
            txtMarca.Text = producto.Marca;

            if (txtUnMedida.Items.Contains(producto.UnidadMedida))
            {
                txtUnMedida.SelectedItem = producto.UnidadMedida;
            }
            else
            {
                txtUnMedida.Text = producto.UnidadMedida;
            }

            txtCodigo.Text = producto.CodigoBarras;
            txtFecha.Value = producto.FechaVencimiento ?? DateTime.Today;
            txtCompra.Text = producto.PrecioCompra.ToString("N0");
            txtFlete.Text = producto.Flete.ToString("N0");
            txtUtilidad.Text = producto.Utilidad.ToString("N0");

            CalcularValorVenta();
        }

        private void EstilizarListBox()
        {
            lstResultados.BackColor = Color.White;
            lstResultados.ForeColor = Color.Black;
            lstResultados.Font = new Font("Arial", 12, FontStyle.Regular);
            lstResultados.BorderStyle = BorderStyle.FixedSingle;
            lstResultados.ItemHeight = 25;
        }

        #endregion

        #region Eventos

        private void LstResultados_Click(object sender, EventArgs e)
        {
            if (lstResultados.SelectedItem is Producto producto)
            {
                CargarProductoEnFormulario(producto);
                lstResultados.Visible = false;
                txtNombre.Focus();
            }
        }

        private async void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (_productosSeleccionados.Count == 0)
            {
                MessageBox.Show("No hay productos en la lista para registrar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Calcular el total de la compra
                decimal totalCompra = _productosSeleccionados.Sum(p => p.PrecioCompra * p.Stock);
                decimal fleteTotal = _productosSeleccionados.Sum(p => p.Flete * p.Stock);

                // Crear objeto de compra
                var compra = new Compra
                {
                    IDProveedor = _idProveedor,
                    TotalCompra = totalCompra,
                    Flete = fleteTotal,
                    Estado = "Finalizada"
                };

                // Convertir los productos seleccionados en detalles de compra
                var detallesCompra = _productosSeleccionados.Select(p => new DetalleCompra
                {
                    IDProducto = p.IDProducto,
                    Cantidad = p.Stock,
                    PrecioUnitario = p.PrecioCompra
                }).ToList();

                // Registrar la compra y obtener el ID generado
                int idCompra = await _compraController.RegistrarCompraAsync(compra, detallesCompra);

                foreach (var producto in _productosSeleccionados)
                {
                    producto.IDProveedor = _idProveedor;

                    if (producto.IDProducto == 0)
                    {
                        // Producto nuevo → Crear
                        await _productoController.CrearProductoAsync(producto);
                    }
                    else
                    {
                        // Producto existente → Actualizar
                        await _productoController.ActualizarProductoAsync(producto);
                    }
                }

                CargarProductos();
                _productosSeleccionados.Clear();
                MostrarProductosSeleccionados();
                CalcularTotales();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscarProductos(object sender, EventArgs e)
        {
            AjustarPosicionListBox();

            string filtroNombre = txtNombre.Text.Trim().ToLower();
            string filtroCodigo = txtCodigo.Text.Trim().ToLower();

            var productosFiltrados = _productosOriginales
                .Where(p =>
                    (string.IsNullOrEmpty(filtroNombre) || p.Descripcion.ToLower().Contains(filtroNombre)) &&
                    (string.IsNullOrEmpty(filtroCodigo) || (p.CodigoBarras ?? "").ToLower().Contains(filtroCodigo)))
                .ToList();

            if (productosFiltrados.Count > 0)
            {
                lstResultados.DataSource = null;
                lstResultados.DataSource = productosFiltrados;
                lstResultados.DisplayMember = "Descripcion";
                lstResultados.ValueMember = "IDProducto";
                lstResultados.Visible = true;
            }
            else
            {
                lstResultados.Visible = false;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar el nombre del producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtCantidad.Text, out decimal cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Debe ingresar una cantidad válida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtCompra.Text, out decimal precioCompra) || precioCompra <= 0)
            {
                MessageBox.Show("Debe ingresar un precio de compra válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtFlete.Text, out decimal flete)) flete = 0;
            if (!decimal.TryParse(txtUtilidad.Text, out decimal utilidad)) utilidad = 0;

            decimal valorVenta = precioCompra + flete + utilidad;

            // Verificamos si hay un ID de producto en lbIdProducto
            int idProducto = 0;
            if (int.TryParse(lbIdProducto.Text, out int id) && id > 0)
            {
                idProducto = id;  // Si tiene ID, lo usamos
            }

            // ✅ Verificar si el producto ya está en la lista
            var productoExistente = _productosSeleccionados.FirstOrDefault(p => p.IDProducto == idProducto);
            if (productoExistente != null)
            {
                productoExistente.Stock += cantidad; // Solo sumamos stock
            }
            else
            {
                // Si no existe, lo agregamos como nuevo
                var productoSeleccionado = new Producto
                {
                    IDProducto = idProducto,
                    Descripcion = txtNombre.Text.Trim(),
                    Marca = txtMarca.Text.Trim(),
                    UnidadMedida = txtUnMedida.SelectedItem?.ToString(),
                    CodigoBarras = txtCodigo.Text.Trim(),
                    FechaVencimiento = txtFecha.Value,
                    PrecioCompra = precioCompra,
                    Flete = flete,
                    Utilidad = utilidad,
                    ValorVenta = valorVenta,
                    Stock = cantidad,
                    Estado = "Activo"
                };

                _productosSeleccionados.Add(productoSeleccionado);
            }

            // 🔍 Verificar si hubo cambio de precio y registrar en historial
            if (idProducto > 0 && decimal.TryParse(lbPrecioCompraAnterior.Text, out decimal precioCompraAnterior))
            {
                if (precioCompraAnterior != precioCompra)
                {
                    RegistrarCambioPrecio(idProducto, precioCompraAnterior, precioCompra, "Cambio de precio al agregar al inventario");
                }
            }

            MostrarProductosSeleccionados();
            CalcularTotales();
            LimpiarCamposProducto();
        }
        private void DtCompra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dtCompra.Columns[e.ColumnIndex].HeaderText == "Eliminar")
            {
                _productosSeleccionados.RemoveAt(e.RowIndex);
                MostrarProductosSeleccionados();
                CalcularTotales();
            }
        }

        #endregion

        #region CRUD Productos

        private async void CargarProductos()
        {
            try
            {
                Console.WriteLine($"🔍 Consultando productos para proveedor: {_idProveedor}");
                _productosOriginales = await _productoController.ListarProductosPorProveedorAsync(_idProveedor);

                if (_productosOriginales == null || _productosOriginales.Count == 0)
                {
                    Console.WriteLine("⚠️ No se encontraron productos para este proveedor.");
                    _productosOriginales = new List<Producto>();
                }
                else
                {
                    Console.WriteLine($"✅ Se encontraron {_productosOriginales.Count} productos.");
                }

                // Inicializar búsqueda vacía al cargar los productos
                ActualizarListaBusqueda("");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al cargar productos: {ex.Message}");
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarListaBusqueda(string filtro)
        {
            if (string.IsNullOrWhiteSpace(filtro))
            {
                lstResultados.Visible = false;
                return;
            }

            var productosFiltrados = _productosOriginales
                .Where(p => p.Descripcion.ToLower().Contains(filtro.ToLower()))
                .ToList();

            if (productosFiltrados.Count > 0)
            {
                lstResultados.DataSource = productosFiltrados;
                lstResultados.DisplayMember = "Descripcion"; // Muestra el nombre
                lstResultados.ValueMember = "IDProducto"; // ID oculto
                lstResultados.Visible = true; // Mostrar la lista
            }
            else
            {
                lstResultados.Visible = false; // Ocultar si no hay coincidencias
            }
        }

        private void MostrarProductosSeleccionados()
        {
            dtCompra.DataSource = null;
            dtCompra.Columns.Clear();
            dtCompra.AutoGenerateColumns = false;

            dtCompra.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Descripcion", HeaderText = "Nombre" });
            dtCompra.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Marca", HeaderText = "Marca" });
            dtCompra.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "UnidadMedida", HeaderText = "Unidad" });
            dtCompra.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CodigoBarras", HeaderText = "Código" });
            dtCompra.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Stock", HeaderText = "Cantidad" });
            dtCompra.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PrecioCompra", HeaderText = "Compra" });
            dtCompra.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ValorVenta", HeaderText = "Venta" });

            dtCompra.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Eliminar",
                Text = "❌",
                UseColumnTextForButtonValue = true,
                Width = 80
            });

            dtCompra.DataSource = _productosSeleccionados;
        }

        #endregion

        #region Utilidades

        private async Task RegistrarCambioPrecio(int idProducto, decimal precioAnterior, decimal precioNuevo, string motivo)
        {
            var historialController = new HistorialPreciosController();

            var historial = new HistorialPrecios
            {
                IDProducto = idProducto,
                PrecioCompraAnterior = precioAnterior,
                PrecioCompraNuevo = precioNuevo,
                PrecioVentaAnterior = 0, // No lo usamos aquí
                PrecioVentaNuevo = 0, // No lo usamos aquí
                Motivo = motivo
            };

            await historialController.RegistrarCambioPrecioAsync(historial);
        }

        private void CalcularTotales()
        {
            decimal totalCompra = _productosSeleccionados.Sum(p => p.PrecioCompra * p.Stock);
            decimal totalVenta = _productosSeleccionados.Sum(p => p.ValorVenta * p.Stock);
            decimal totalFlete = _productosSeleccionados.Sum(p => p.Flete * p.Stock);

            // Asegurarnos de que txtGeneral siempre sea un número válido
            if (!decimal.TryParse(txtGeneral.Text, out decimal generalFlete))
            {
                generalFlete = 0;
                txtGeneral.Text = "0";  // Si está vacío o no es un número, lo establecemos en 0
            }

            // Cálculo de la utilidad neta: totalVenta - totalCompra - generalFlete
            decimal totalUtilidad = totalVenta - totalCompra - generalFlete;

            lblCompra.Text = totalCompra.ToString("N0");
            lblVenta.Text = totalVenta.ToString("N0");
            lblUtilidad.Text = totalUtilidad.ToString("N0");
            lblFlete.Text = totalFlete.ToString("N0");
        }

        private void CalcularValorVenta()
        {
            if (decimal.TryParse(txtCompra.Text, out decimal compra) &&
                decimal.TryParse(txtFlete.Text, out decimal flete) &&
                decimal.TryParse(txtUtilidad.Text, out decimal utilidad))
            {
                decimal valorVenta = compra + flete + utilidad;
                txtVenta.Text = valorVenta.ToString("N0");
            }
            else
            {
                txtVenta.Text = "0";
            }
        }

        private void LimpiarCamposProducto()
        {
            txtNombre.Clear();
            txtMarca.Clear();
            txtCodigo.SelectedIndex = -1;
            txtCantidad.Clear();
            txtCompra.Clear();
            txtFlete.Clear();
            txtUtilidad.Clear();
            txtVenta.Clear();
            txtFecha.Value = DateTime.Today;
        }

        #endregion
    }
}
