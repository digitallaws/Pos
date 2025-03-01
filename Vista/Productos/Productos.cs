using OfficeOpenXml;
using Sopromil.Controlador;
using Sopromil.Modelo;
using Sopromil.Utils;

namespace Sopromil.Vista.Productos
{
    public partial class Productos : Form
    {
        private readonly ProductoController _productoController;
        private List<Producto> productosImportados;
        private List<Producto> productosOriginales = new List<Producto>();

        public Productos()
        {
            InitializeComponent();
            _productoController = new ProductoController();
            

            // Eventos
            btnAgregar.Click += BtnAgregar_Click;
            btnCargarExcel.Click += BtnCargarExcel_Click;
            btnFormato.Click += BtnFormato_Click;
            btnReportes.Click += BtnReportes_Click;
            txtBuscar.TextChanged += BuscarTxt_TextChanged;
            txtBuscar.KeyPress += TxtBuscar_KeyPress;

            // ✅ Nuevo evento para doble clic
            dtInventario.CellDoubleClick += DtInventario_CellDoubleClick;
            dtInventario.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Selección completa de fila
            dtInventario.MultiSelect = false; // Solo una fila a la vez
            dtInventario.ReadOnly = true; // Evitar edición directa
            dtInventario.AllowUserToAddRows = false;

            CargarInventario();
        }

        private void DtInventario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtener el producto seleccionado
                var productoSeleccionado = (Producto)dtInventario.Rows[e.RowIndex].DataBoundItem;

                using (AgregarProducto editarProductoForm = new AgregarProducto(productoSeleccionado))
                {
                    var resultado = editarProductoForm.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        CargarInventario(); // Refrescar el inventario tras la actualización
                    }
                }
            }
        }

        private void BtnSalidaStock_Click(object sender, EventArgs e)
        {
            if (dtInventario.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un producto para realizar la salida de stock.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener la fila seleccionada
            var filaSeleccionada = dtInventario.SelectedRows[0];

            // ⚠️ Verificar que el IDCategoria se obtiene correctamente antes de usarlo
            int idCategoria = filaSeleccionada.Cells["IDCategoria"].Value != DBNull.Value
                ? Convert.ToInt32(filaSeleccionada.Cells["IDCategoria"].Value)
                : 0; // Si es null, asignar un valor por defecto

            var productoSeleccionado = new Producto
            {
                IDProducto = Convert.ToInt32(filaSeleccionada.Cells["IDProducto"].Value),
                Descripcion = filaSeleccionada.Cells["Descripcion"].Value.ToString(),
                Stock = Convert.ToInt32(filaSeleccionada.Cells["Stock"].Value),
                PrecioCompra = Convert.ToDecimal(filaSeleccionada.Cells["PrecioCompra"].Value),
                PrecioVenta = Convert.ToDecimal(filaSeleccionada.Cells["PrecioVenta"].Value),
                FechaVencimiento = filaSeleccionada.Cells["FechaVencimiento"].Value == DBNull.Value
                    ? (DateTime?)null
                    : Convert.ToDateTime(filaSeleccionada.Cells["FechaVencimiento"].Value),
                CodigoBarras = filaSeleccionada.Cells["CodigoBarras"].Value.ToString(),
                IDCategoria = idCategoria // ✅ Asegurar que se obtiene correctamente
            };

            Console.WriteLine($"Producto seleccionado: {productoSeleccionado.Descripcion}, IDCategoria: {productoSeleccionado.IDCategoria}");

            using (SalidaStockForm salidaStockForm = new SalidaStockForm(productoSeleccionado))
            {
                var resultado = salidaStockForm.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    CargarInventario(); // Refrescar inventario tras la salida de stock
                }
            }
        }


        private async void CargarInventario()
        {
            try
            {
                productosOriginales = await _productoController.ObtenerProductosAsync();

                // ⚠️ Verificar que IDCategoria se obtiene correctamente
                foreach (var p in productosOriginales)
                {
                    Console.WriteLine($"Producto: {p.Descripcion}, IDCategoria: {p.IDCategoria}");
                }

                MostrarProductosEnGrid(productosOriginales);
                dtInventario.DefaultCellStyle.Font = new Font("Segoe UI", 12);
                dtInventario.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                dtInventario.CellFormatting -= DtInventario_CellFormatting;
                dtInventario.CellFormatting += DtInventario_CellFormatting;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el inventario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void MostrarProductosEnGrid(List<Producto> productos)
        {
            dtInventario.DataSource = null;
            dtInventario.DataSource = productos;

            dtInventario.Columns["IDProducto"].Visible = false;

            if (!dtInventario.Columns.Contains("IDCategoria"))
            {
                dtInventario.Columns.Add("IDCategoria", "IDCategoria");
            }

            dtInventario.Columns["IDCategoria"].Visible = false;
            dtInventario.Columns["Descripcion"].HeaderText = "Descripción";
            dtInventario.Columns["Categoria"].HeaderText = "Categoría";
            dtInventario.Columns["Stock"].HeaderText = "Stock";
            dtInventario.Columns["PrecioCompra"].HeaderText = "Precio Compra";
            dtInventario.Columns["PrecioCompra"].DefaultCellStyle.Format = "C2";
            dtInventario.Columns["PrecioVenta"].HeaderText = "Precio Venta";
            dtInventario.Columns["PrecioVenta"].DefaultCellStyle.Format = "C2";
            dtInventario.Columns["FechaVencimiento"].HeaderText = "Fecha de Vencimiento";
            dtInventario.Columns["CodigoBarras"].HeaderText = "Código de Barras";

            dtInventario.AutoResizeColumns();
        }


        private void DtInventario_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dtInventario.Columns[e.ColumnIndex].Name == "FechaVencimiento")
            {
                var row = dtInventario.Rows[e.RowIndex];
                var fechaVencimientoObj = row.Cells["FechaVencimiento"].Value;

                if (fechaVencimientoObj != null && fechaVencimientoObj != DBNull.Value)
                {
                    DateTime fechaVencimiento = Convert.ToDateTime(fechaVencimientoObj);
                    TimeSpan diferencia = fechaVencimiento - DateTime.Now;

                    if (diferencia.TotalDays <= 15 && diferencia.TotalDays >= 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                    else if (diferencia.TotalDays <= 30 && diferencia.TotalDays > 15)
                    {
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else if (diferencia.TotalDays > 30)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else if (diferencia.TotalDays < 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.DarkRed;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void BuscarTxt_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim().ToLower();

            var productosFiltrados = productosOriginales.Where(p =>
                (p.Descripcion != null && p.Descripcion.ToLower().Contains(filtro)) ||
                (p.Categoria != null && p.Categoria.ToLower().Contains(filtro)) ||
                (p.CodigoBarras != null && p.CodigoBarras.ToLower().Contains(filtro)) ||
                p.Stock.ToString().Contains(filtro) ||
                p.PrecioCompra.ToString().Contains(filtro) ||
                p.PrecioVenta.ToString().Contains(filtro)).ToList();

            MostrarProductosEnGrid(productosFiltrados.Any() ? productosFiltrados : productosOriginales);
        }

        private void TxtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string codigoBarras = txtBuscar.Text.Trim();
                var producto = productosOriginales.FirstOrDefault(p => p.CodigoBarras == codigoBarras);

                if (producto != null)
                {
                    MostrarProductosEnGrid(new List<Producto> { producto });
                }
                else
                {
                    MessageBox.Show("Producto no encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarProductosEnGrid(productosOriginales);
                }
                txtBuscar.Clear();
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            using (AgregarProducto agregarProductoForm = new AgregarProducto())
            {
                var resultado = agregarProductoForm.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    CargarInventario();
                }
            }
        }

        private void BtnCargarExcel_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos de Excel (*.xlsx)|*.xlsx";
                openFileDialog.Title = "Seleccionar archivo de Excel";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    productosImportados = LeerProductosDesdeExcel(filePath);

                    if (productosImportados.Any())
                    {
                        cargaMasiva modal = new cargaMasiva(productosImportados);
                        var resultado = modal.ShowDialog();

                        if (resultado == DialogResult.OK)
                        {
                            GuardarProductosImportados();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron productos válidos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private List<Producto> LeerProductosDesdeExcel(string filePath)
        {
            List<Producto> productos = new List<Producto>();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];
                int rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++)
                {
                    try
                    {
                        string descripcion = worksheet.Cells[row, 1].Text.Trim();
                        string precioCompraTexto = worksheet.Cells[row, 2].Text.Trim();
                        string precioVentaTexto = worksheet.Cells[row, 3].Text.Trim();
                        string fechaTexto = worksheet.Cells[row, 4].Text.Trim();
                        string codigoBarras = worksheet.Cells[row, 5].Text.Trim();
                        string stockTexto = worksheet.Cells[row, 6].Text.Trim();

                        decimal precioCompra = decimal.TryParse(precioCompraTexto, out decimal pc) ? pc : 0;
                        decimal precioVenta = decimal.TryParse(precioVentaTexto, out decimal pv) ? pv : 0;
                        decimal stock = decimal.TryParse(stockTexto, out decimal s) ? s : 0;

                        DateTime? fechaVencimiento = null;
                        if (!string.IsNullOrEmpty(fechaTexto))
                        {
                            if (DateTime.TryParseExact(fechaTexto, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime fechaV))
                            {
                                fechaVencimiento = fechaV;
                            }
                            else
                            {
                                Console.WriteLine($"Formato de fecha inválido en la fila {row}: '{fechaTexto}'");
                            }
                        }

                        Producto producto = new Producto
                        {
                            Descripcion = descripcion,
                            IDCategoria = 1,
                            Stock = stock,
                            PrecioCompra = precioCompra,
                            PrecioVenta = precioVenta,
                            FechaVencimiento = fechaVencimiento,
                            CodigoBarras = codigoBarras,
                        };

                        productos.Add(producto);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error en la fila {row}: {ex.Message}");
                    }
                }
            }

            return productos;
        }

        private async void GuardarProductosImportados()
        {
            int count = 0;
            foreach (var producto in productosImportados)
            {
                await _productoController.CrearProductoAsync(producto);
                count++;
            }

            MessageBox.Show($"Se importaron {count} productos correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarInventario();
        }

        private void BtnFormato_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Archivo Excel (*.xlsx)|*.xlsx",
                Title = "Guardar Formato de Inventario",
                FileName = "Formato_Inventario.xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                GenerarFormatoExcel(saveFileDialog.FileName);
                MessageBox.Show($"Formato de inventario guardado exitosamente en {saveFileDialog.FileName}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GenerarFormatoExcel(string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Formato Inventario");

                worksheet.Cells[1, 1].Value = "Descripción";
                worksheet.Cells[1, 2].Value = "Precio Compra";
                worksheet.Cells[1, 3].Value = "Precio Venta";
                worksheet.Cells[1, 4].Value = "Fecha de Vencimiento (yyyy-MM-dd)";
                worksheet.Cells[1, 5].Value = "Código de Barras";
                worksheet.Cells[1, 6].Value = "Stock";

                using (var range = worksheet.Cells[1, 1, 1, 6])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                }

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                File.WriteAllBytes(filePath, package.GetAsByteArray());
            }
        }

        private void BtnReportes_Click(object sender, EventArgs e)
        {
            using (SeleccionarReporteForm seleccionarReporteForm = new SeleccionarReporteForm())
            {
                if (seleccionarReporteForm.ShowDialog() == DialogResult.OK)
                {
                    List<Producto> productosParaReporte = new List<Producto>();

                    switch (seleccionarReporteForm.ReporteSeleccionado)
                    {
                        case SeleccionarReporteForm.TipoReporte.General:
                            productosParaReporte = productosOriginales;
                            break;

                        case SeleccionarReporteForm.TipoReporte.PorVencimiento:
                            productosParaReporte = productosOriginales
                                .Where(p => p.FechaVencimiento.HasValue && (p.FechaVencimiento.Value - DateTime.Now).TotalDays <= 30 && (p.FechaVencimiento.Value - DateTime.Now).TotalDays >= 0)
                                .ToList();
                            break;

                        case SeleccionarReporteForm.TipoReporte.StockBajo:
                            productosParaReporte = productosOriginales
                                .Where(p => p.Stock < 5)
                                .ToList();
                            break;

                        default:
                            return;
                    }

                    if (!productosParaReporte.Any())
                    {
                        MessageBox.Show("No se encontraron productos para el reporte seleccionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Archivo Excel (*.xlsx)|*.xlsx";
                        saveFileDialog.Title = "Guardar Reporte";
                        saveFileDialog.FileName = $"Reporte_{seleccionarReporteForm.ReporteSeleccionado}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            GenerarReporteExcel(saveFileDialog.FileName, productosParaReporte, seleccionarReporteForm.ReporteSeleccionado.ToString());
                            MessageBox.Show($"Reporte generado exitosamente:\n{saveFileDialog.FileName}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void GenerarReporteExcel(string filePath, List<Producto> productos, string nombreHoja)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(nombreHoja);

                worksheet.Cells[1, 1].Value = "Descripción";
                worksheet.Cells[1, 2].Value = "Categoría";
                worksheet.Cells[1, 3].Value = "Stock";
                worksheet.Cells[1, 4].Value = "Precio Compra";
                worksheet.Cells[1, 5].Value = "Precio Venta";
                worksheet.Cells[1, 6].Value = "Fecha de Vencimiento";
                worksheet.Cells[1, 7].Value = "Código de Barras";

                using (var range = worksheet.Cells[1, 1, 1, 7])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                }

                int row = 2;
                foreach (var producto in productos)
                {
                    worksheet.Cells[row, 1].Value = producto.Descripcion;
                    worksheet.Cells[row, 2].Value = producto.Categoria;
                    worksheet.Cells[row, 3].Value = producto.Stock;
                    worksheet.Cells[row, 4].Value = producto.PrecioCompra;
                    worksheet.Cells[row, 5].Value = producto.PrecioVenta;
                    worksheet.Cells[row, 6].Value = producto.FechaVencimiento?.ToString("dd/MM/yyyy");
                    worksheet.Cells[row, 7].Value = producto.CodigoBarras;
                    row++;
                }

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                File.WriteAllBytes(filePath, package.GetAsByteArray());
            }
        }

        
    }
}