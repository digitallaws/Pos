using OfficeOpenXml;
using OfficeOpenXml.Style;
using Sopromil.Controlador;
using Sopromil.Modelo;

namespace Sopromil.Vista.Inventario
{
    public partial class FrmReporteInventario : Form
    {
        private List<Producto> _productosOriginales;
        private readonly ProductoController _productoController;

        public FrmReporteInventario()
        {
            InitializeComponent();
            _productoController = new ProductoController();
            ConfigurarEventos();
            CargarInventario();
        }

        #region Configuración Inicial

        private void ConfigurarEventos()
        {
            btnGeneral.Click += (s, e) => ExportarAExcel("Reporte_General", _productosOriginales);
            btnBajo.Click += (s, e) => ExportarAExcel("Reporte_Stock_Bajo", _productosOriginales.Where(p => p.Stock < 10).ToList());
            btnFecha.Click += (s, e) => ExportarAExcel("Reporte_Por_Vencer", _productosOriginales
                                            .Where(p => p.FechaVencimiento.HasValue && p.FechaVencimiento.Value <= DateTime.Today.AddDays(30))
                                            .ToList());
        }

        private async void CargarInventario()
        {
            try
            {
                _productosOriginales = await _productoController.ListarTodosLosProductosAsync();

                if (_productosOriginales == null || _productosOriginales.Count == 0)
                {
                    MessageBox.Show("No se encontraron productos en el inventario.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el inventario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Exportar a Excel

        private void ExportarAExcel(string nombreReporte, List<Producto> productos)
        {
            if (productos == null || productos.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 🔹 Generar nombre con fecha y hora (Formato: Reporte_General_20240309_153045.xlsx)
            string fechaHora = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string nombreArchivo = $"{nombreReporte}_{fechaHora}.xlsx";

            using (SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Excel Workbook|*.xlsx",
                Title = "Guardar Reporte",
                FileName = nombreArchivo
            })
            {
                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                    using (ExcelPackage excel = new ExcelPackage())
                    {
                        var worksheet = excel.Workbook.Worksheets.Add("Reporte");

                        // 🔹 Columnas
                        string[] headers = { "Código", "Nombre", "Marca", "Cantidad", "Unidad", "Precio Unitario", "Valor Total", "Fecha Vencimiento", "Proveedor" };
                        for (int i = 0; i < headers.Length; i++)
                        {
                            worksheet.Cells[1, i + 1].Value = headers[i];
                            worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                            worksheet.Cells[1, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                        }

                        // 🔹 Datos
                        for (int i = 0; i < productos.Count; i++)
                        {
                            Producto p = productos[i];
                            worksheet.Cells[i + 2, 1].Value = p.CodigoBarras;
                            worksheet.Cells[i + 2, 2].Value = p.Descripcion;
                            worksheet.Cells[i + 2, 3].Value = p.Marca;
                            worksheet.Cells[i + 2, 4].Value = p.Stock;
                            worksheet.Cells[i + 2, 5].Value = p.UnidadMedida;
                            worksheet.Cells[i + 2, 6].Value = p.PrecioCompra;
                            worksheet.Cells[i + 2, 7].Value = p.Stock * p.PrecioCompra;
                            worksheet.Cells[i + 2, 8].Value = p.FechaVencimiento?.ToString("yyyy-MM-dd");
                            worksheet.Cells[i + 2, 9].Value = p.Proveedor?.Nombre ?? "Sin proveedor";
                        }

                        worksheet.Cells.AutoFitColumns();

                        // 🔹 Guardar el archivo
                        FileInfo fileInfo = new FileInfo(sfd.FileName);
                        excel.SaveAs(fileInfo);

                        MessageBox.Show($"Reporte exportado exitosamente:\n{sfd.FileName}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al exportar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        #endregion
    }
}
