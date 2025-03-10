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
            txtFecha.CustomFormat = " "; // Inicialmente vacío
            txtFecha.ValueChanged += TxtFecha_ValueChanged; // Manejar cambios de valor
        }

        private void TxtFecha_ValueChanged(object sender, EventArgs e)
        {
            // Establecer el formato correcto cuando el usuario selecciona una fecha
            txtFecha.CustomFormat = "dddd, dd MMMM yyyy";
        }

        private void ConfigurarEventos()
        {
            txtNombre.Click += (s, e) => lstResultados.Visible = false;

            txtNombre.TextChanged += BuscarProductos;
            txtCodigo.TextChanged += BuscarProductos;

            lstResultados.Click += LstResultados_Click;
            lstResultados.Leave += (s, e) => lstResultados.Visible = false;

            btnAgregar.Click += btnAgregar_Click;
            btnRegistrar.Click += btnRegistrar_Click;
            dtCompra.CellClick += DtCompra_CellClick;
            btnLimpiar.Click += BtnLimpiar_Click;

            txtCompra.TextChanged += (s, e) => CalcularValorVenta();
            txtFlete.TextChanged += (s, e) => CalcularValorVenta();
            txtUtilidad.TextChanged += (s, e) => CalcularValorVenta();
            txtCantidad.TextChanged += (s, e) => CalcularValorVenta();

        }

        private void CargarProductoEnFormulario(Producto producto)
        {
            lbIdProducto.Text = producto.IDProducto.ToString();

            lbPrecioCompraAnterior.Text = producto.PrecioCompra.ToString("N2");
            lblPrecioVenta.Text = producto.ValorVenta.ToString("N2");

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
        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCamposProducto();
        }

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
                    IDProveedor = int.Parse(lbId.Text),
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
                    producto.IDProveedor = int.Parse(lbId.Text);

                    // 🔥 Ajustar Código de Barras a NULL si está vacío o tiene solo espacios
                    if (string.IsNullOrWhiteSpace(producto.CodigoBarras))
                    {
                        producto.CodigoBarras = null;
                    }

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
                LimpiarCamposProducto();
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

            if (filtroNombre.Length < 3 && filtroCodigo.Length < 3)
            {
                lstResultados.Visible = false;
                return;
            }

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

        private async void btnAgregar_Click(object sender, EventArgs e)
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

            // Claves de identificación: Nombre, Marca, Código
            string nombre = txtNombre.Text.Trim().ToUpper();
            string marca = txtMarca.Text.Trim().ToUpper();
            string codigo = txtCodigo.Text.Trim().ToUpper();

            // Verificamos si hay un ID de producto en lbIdProducto
            int idProducto = 0;
            if (int.TryParse(lbIdProducto.Text, out int id) && id > 0)
            {
                idProducto = id;  // Si tiene ID, lo usamos
            }

            // ✅ Verificar si el producto ya está en la lista
            var productoExistente = _productosSeleccionados.FirstOrDefault(p =>
                p.Descripcion.ToUpper() == nombre &&
                p.Marca.ToUpper() == marca &&
                p.CodigoBarras.ToUpper() == codigo);

            // ✅ Validar la fecha antes de asignarla
            DateTime? fechaVencimiento = null;
            if (txtFecha.CustomFormat != " " && txtFecha.Value != DateTime.Today)
            {
                fechaVencimiento = txtFecha.Value; // Solo se asigna si fue modificada
            }

            if (productoExistente != null)
            {
                // Si ya existe, actualizar los valores
                productoExistente.Stock = cantidad;
                productoExistente.PrecioCompra = precioCompra;
                productoExistente.Flete = flete;
                productoExistente.Utilidad = utilidad;
                productoExistente.ValorVenta = valorVenta;
                productoExistente.FechaVencimiento = fechaVencimiento;
            }
            else
            {
                var nuevoProducto = new Producto
                {
                    IDProducto = idProducto,
                    Descripcion = nombre,
                    Marca = marca,
                    UnidadMedida = txtUnMedida.SelectedItem?.ToString(),
                    CodigoBarras = codigo,
                    FechaVencimiento = fechaVencimiento,
                    PrecioCompra = precioCompra,
                    Flete = flete,
                    Utilidad = utilidad,
                    ValorVenta = valorVenta,
                    Stock = cantidad,
                    Estado = "Activo"
                };

                if (decimal.TryParse(lbPrecioCompraAnterior.Text, out decimal precioCompraAnterior) &&
                    decimal.TryParse(lblPrecioVenta.Text, out decimal precioVentaAnterior))
                {
                    if (lbIdProducto.Text != "0" && (precioCompraAnterior != precioCompra || precioVentaAnterior != valorVenta))
                    {
                        await RegistrarCambioPrecio(idProducto, precioCompraAnterior, precioCompra, precioVentaAnterior, valorVenta, "Nuevo producto agregado al inventario");
                    }
                }


                _productosSeleccionados.Add(nuevoProducto);
            }

            MostrarProductosSeleccionados();
            CalcularTotales();
            LimpiarCamposProducto();
        }

        private void DtCompra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Evitar errores si se hace clic en el encabezado

            // Si el usuario hace clic en el botón "Editar"
            if (dtCompra.Columns[e.ColumnIndex].Name == "Editar")
            {
                var productoSeleccionado = _productosSeleccionados[e.RowIndex];

                lbIdProducto.Text = productoSeleccionado.IDProducto.ToString();
                txtNombre.Text = productoSeleccionado.Descripcion;
                txtMarca.Text = productoSeleccionado.Marca;
                txtUnMedida.Text = productoSeleccionado.UnidadMedida;
                txtCodigo.Text = productoSeleccionado.CodigoBarras;
                txtCompra.Text = productoSeleccionado.PrecioCompra.ToString("N0");
                txtFlete.Text = productoSeleccionado.Flete.ToString("N0");
                txtUtilidad.Text = productoSeleccionado.Utilidad.ToString("N0");

                CalcularValorVenta();
            }

            // Si el usuario hace clic en el botón "Eliminar"
            else if (dtCompra.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                var confirmacion = MessageBox.Show("¿Está seguro de eliminar este producto?", "Confirmar eliminación",
                                                   MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmacion == DialogResult.Yes)
                {
                    _productosSeleccionados.RemoveAt(e.RowIndex);
                    MostrarProductosSeleccionados();
                    CalcularTotales();
                }
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

            var colCantidad = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Stock",
                HeaderText = "Cantidad",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            };
            dtCompra.Columns.Add(colCantidad);

            var colCompra = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PrecioCompra",
                HeaderText = "Compra",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            };
            dtCompra.Columns.Add(colCompra);

            var colVenta = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ValorVenta",
                HeaderText = "Venta",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            };
            dtCompra.Columns.Add(colVenta);

            // 🔹 Botón Editar
            var btnEditar = new DataGridViewButtonColumn
            {
                HeaderText = "Editar",
                Name = "Editar",
                Text = "✏️",
                UseColumnTextForButtonValue = true,
                Width = 80
            };
            dtCompra.Columns.Add(btnEditar);

            // 🔹 Botón Eliminar
            var btnEliminar = new DataGridViewButtonColumn
            {
                HeaderText = "Eliminar",
                Name = "Eliminar",
                Text = "❌",
                UseColumnTextForButtonValue = true,
                Width = 80
            };
            dtCompra.Columns.Add(btnEliminar);

            dtCompra.DataSource = _productosSeleccionados;
        }

        #endregion

        #region Utilidades

        private void LimpiarCamposProducto()
        {
            lbIdProducto.Text = "0";
            txtNombre.Clear();
            txtMarca.Clear();
            txtCodigo.SelectedIndex = -1;
            txtCodigo.Text = "";
            txtCantidad.Clear();
            txtCompra.Clear();
            txtFlete.Clear();
            txtUtilidad.Clear();
            txtVenta.Clear();

            // Limpiar DateTimePicker (dejándolo visualmente vacío)
            txtFecha.CustomFormat = " ";
            txtFecha.Format = DateTimePickerFormat.Custom;

            txtUnMedida.SelectedIndex = -1;
            lbPrecioCompraAnterior.Text = "0";
        }


        private async Task RegistrarCambioPrecio(int idProducto, decimal precioAnterior, decimal precioNuevo, decimal PrecioVentaAnterior, decimal PrecioVentaNuevo, string motivo)
        {
            var historialController = new HistorialPreciosController();

            var historial = new HistorialPrecios
            {
                IDProducto = idProducto,
                PrecioCompraAnterior = precioAnterior,
                PrecioCompraNuevo = precioNuevo,
                PrecioVentaAnterior = PrecioVentaAnterior,
                PrecioVentaNuevo = PrecioVentaNuevo,
                Motivo = motivo
            };

            await historialController.RegistrarCambioPrecioAsync(historial);
        }

        private void CalcularTotales()
        {
            decimal totalCompra = _productosSeleccionados.Sum(p => p.PrecioCompra * p.Stock);
            decimal totalVenta = _productosSeleccionados.Sum(p => p.ValorVenta * p.Stock);
            decimal totalFlete = _productosSeleccionados.Sum(p => p.Flete * p.Stock);

            decimal totalUtilidad = totalVenta - totalCompra - totalFlete;

            lblCompra.Text = $"$ {totalCompra.ToString("N0")}";
            lblVenta.Text = $"$ {totalVenta.ToString("N0")}";
            lblUtilidad.Text = $"$ {totalUtilidad.ToString("N0")}";
            lblFlete.Text = $"$ {totalFlete.ToString("N0")}";
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

        #endregion

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
