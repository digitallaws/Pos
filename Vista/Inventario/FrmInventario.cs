﻿using Sopromil.Controlador;
using Sopromil.Modelo;
using System.Data;

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
            dtInventario.Dock = DockStyle.Fill;
            dtInventario.AllowUserToAddRows = false;
            dtInventario.AllowUserToDeleteRows = false;
            dtInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtInventario.BackgroundColor = Color.White;
            dtInventario.ReadOnly = true;
            dtInventario.RowHeadersVisible = false;
            dtInventario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtInventario.BorderStyle = BorderStyle.None;

            dtInventario.DefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Regular);
            dtInventario.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dtInventario.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtInventario.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            dtInventario.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        private void ConfigurarEventos()
        {
            txtBuscar.TextChanged += (s, e) => FiltrarPorTexto();
            cbProveedores.SelectedIndexChanged += (s, e) => FiltrarPorProveedor();
            dtInventario.CellClick += DtInventario_CellClick;
            btnProductos.Click += btnProductos_Click;
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
            var colID = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IDProducto",
                HeaderText = "IDProducto",
                Name = "IDProducto",
                Visible = false
            };
            dtInventario.Columns.Add(colID);
            dtInventario.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CodigoBarras", HeaderText = "Código" });
            dtInventario.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Descripcion", HeaderText = "Nombre", Name = "Descripcion", });
            dtInventario.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Marca", HeaderText = "Marca", Name = "Marca" });
            dtInventario.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Stock", HeaderText = "Cantidad", Name = "Stock" });
            dtInventario.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "UnidadMedida", HeaderText = "Unidad", Name = "Unidad" });

            var colPrecioCompra = new DataGridViewTextBoxColumn
            {
                Name = "ValorCompra",
                DataPropertyName = "PrecioCompra",
                HeaderText = "Valor Unitario",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            };
            dtInventario.Columns.Add(colPrecioCompra);

            var colValorTotal = new DataGridViewTextBoxColumn
            {
                HeaderText = "Valor Total",
                Name = "ValorTotal",
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            };
            dtInventario.Columns.Add(colValorTotal);

            var colValorVenta = new DataGridViewTextBoxColumn
            {
                Name = "ValorVenta",
                DataPropertyName = "ValorVenta",
                HeaderText = "Venta",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            };
            dtInventario.Columns.Add(colValorVenta);

            var btnHistorial = new DataGridViewButtonColumn
            {
                HeaderText = "Historial",
                Text = "📜",
                UseColumnTextForButtonValue = true,
                Name = "btnHistorial",
                Width = 80
            };
            dtInventario.Columns.Add(btnHistorial);

            var btnUbicacion = new DataGridViewButtonColumn
            {
                HeaderText = "Ubicación",
                Text = "📍",
                UseColumnTextForButtonValue = true,
                Name = "btnUbicacion",
                Width = 80
            };
            dtInventario.Columns.Add(btnUbicacion);

            var productosProcesados = productos
                .Select(p => new Producto
                {
                    IDProducto = p.IDProducto,
                    CodigoBarras = p.CodigoBarras,
                    Descripcion = p.Descripcion.ToUpper(),
                    Marca = p.Marca.ToUpper(),
                    Stock = p.Stock,
                    UnidadMedida = p.UnidadMedida.ToUpper(),
                    PrecioCompra = p.PrecioCompra,
                    ValorVenta = p.ValorVenta,
                    IDProveedor = p.IDProveedor
                })
                .ToList();

            dtInventario.DataSource = productosProcesados;

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

                if (proveedores == null || proveedores.Count == 0)
                {
                    Console.WriteLine("⚠️ No se encontraron proveedores.");
                    return;
                }

                proveedores.Insert(0, new Proveedor { IDProveedor = 0, Nombre = "Todos" });

                cbProveedores.DataSource = proveedores;
                cbProveedores.DisplayMember = "Nombre";
                cbProveedores.ValueMember = "IDProveedor";
                cbProveedores.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al cargar proveedores: {ex.Message}");
                MessageBox.Show($"Error al cargar proveedores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            var proveedoresForm = new Proveedores();
            proveedoresForm.Show();
            this.Hide();
        }

        #endregion

        #region Funcionalidad de Búsqueda

        private void FiltrarPorProveedor()
        {
            if (!(cbProveedores.SelectedValue is int idProveedorSeleccionado))
            {
                idProveedorSeleccionado = 0; // Si no hay selección, mostrar todos los productos
            }

            var productosFiltrados = _productosOriginales
                .Where(p => idProveedorSeleccionado == 0 || p.IDProveedor == idProveedorSeleccionado)
                .ToList();

            ActualizarTabla(productosFiltrados);
        }

        private void FiltrarPorTexto()
        {
            string filtro = txtBuscar.Text.Trim().ToLower();

            var productosFiltrados = _productosOriginales
                .Where(p =>
                    string.IsNullOrEmpty(filtro) ||
                    p.Descripcion.ToLower().Contains(filtro) ||
                    p.CodigoBarras.ToLower().Contains(filtro) ||
                    p.Marca.ToLower().Contains(filtro))
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
        private void DtInventario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dtInventario.Columns[e.ColumnIndex].Name == "btnHistorial")
                {
                    // ✅ Verificar si la columna "IDProducto" existe antes de acceder
                    if (!dtInventario.Columns.Contains("IDProducto"))
                    {
                        MessageBox.Show("No se encontró la columna IDProducto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // ✅ Obtener el IDProducto de manera segura
                    int idProducto = Convert.ToInt32(dtInventario.Rows[e.RowIndex].Cells["IDProducto"].Value);
                    string nombreProducto = dtInventario.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString();
                    string proveedor = dtInventario.Rows[e.RowIndex].Cells["Marca"].Value.ToString();
                    decimal stock = Convert.ToDecimal(dtInventario.Rows[e.RowIndex].Cells["Stock"].Value);
                    decimal precioVenta = Convert.ToDecimal(dtInventario.Rows[e.RowIndex].Cells["ValorVenta"].Value);
                    decimal precioCompra = Convert.ToDecimal(dtInventario.Rows[e.RowIndex].Cells["ValorCompra"].Value);

                    // ✅ Abrir la ventana del historial de precios
                    FrmInformePrecio frmHistorial = new FrmInformePrecio(idProducto, nombreProducto, proveedor, stock, precioCompra, precioVenta);
                    frmHistorial.ShowDialog();
                }
                else if (dtInventario.Columns[e.ColumnIndex].Name == "btnUbicacion")
                {
                    int idProducto = Convert.ToInt32(dtInventario.Rows[e.RowIndex].Cells["IDProducto"].Value);
                    string nombreProducto = dtInventario.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString();

                    FrmUbicar frmUbicacion = new FrmUbicar(idProducto, nombreProducto);
                    frmUbicacion.ShowDialog();
                }
            }
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            FrmReporteInventario frmReporteInventario = new FrmReporteInventario();
            frmReporteInventario.Show();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
