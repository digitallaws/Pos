using OfficeOpenXml;
using OfficeOpenXml.Style;
using Sopromil.Controlador;
using Sopromil.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Sopromil.Vista.Reportes
{
    public partial class FrmReporteVentas : Form
    {
        private readonly VentaController _ventaController;
        private List<Venta> _ventasOriginales = new();

        public FrmReporteVentas()
        {
            InitializeComponent();
            _ventaController = new VentaController();

            ConfigurarEventos();
            ConfigurarDataGrid();
            CargarVentas();
        }

        #region 🔹 Configuración Inicial

        private void ConfigurarEventos()
        {
            btnFiiltrar.Click += (s, e) => FiltrarVentas();
            btnExcel.Click += (s, e) => ExportarAExcel();
        }

        private void ConfigurarDataGrid()
        {
            dtCompras.AllowUserToAddRows = false;
            dtCompras.AllowUserToDeleteRows = false;
            dtCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtCompras.BackgroundColor = Color.White;
            dtCompras.ReadOnly = true;
            dtCompras.RowHeadersVisible = false;
            dtCompras.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dtCompras.DefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Regular);
            dtCompras.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);

            dtCompras.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            dtCompras.DefaultCellStyle.SelectionForeColor = Color.White;

            dtCompras.Columns.Clear();
            dtCompras.Columns.Add(new DataGridViewTextBoxColumn { Name = "IDVenta", HeaderText = "ID", Visible = false });
            dtCompras.Columns.Add(new DataGridViewTextBoxColumn { Name = "FechaVenta", HeaderText = "Fecha", Width = 120 });
            dtCompras.Columns.Add(new DataGridViewTextBoxColumn { Name = "Cliente", HeaderText = "Cliente", Width = 180 });
            dtCompras.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TotalVenta",
                HeaderText = "Total Venta",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N0" }
            });
            dtCompras.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TotalCompra",
                HeaderText = "Total Compra",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N0" }
            });
            dtCompras.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Utilidad",
                HeaderText = "Utilidad",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N0" }
            });
            dtCompras.Columns.Add(new DataGridViewTextBoxColumn { Name = "Estado", HeaderText = "Estado", Width = 120 });
        }

        private async void CargarVentas()
        {
            _ventasOriginales = await _ventaController.ObtenerVentasAsync() ?? new List<Venta>();
            txtFechaInicio.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1); // Primer día del mes
            txtFechaFin.Value = DateTime.Today;
            FiltrarVentas();
        }

        #endregion

        #region 🔹 Filtrado y Cálculo de Totales

        private void FiltrarVentas()
        {
            if (_ventasOriginales == null || _ventasOriginales.Count == 0)
            {
                MessageBox.Show("No hay ventas disponibles.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DateTime fechaInicio = txtFechaInicio.Value.Date;
            DateTime fechaFin = txtFechaFin.Value.Date.AddDays(1).AddSeconds(-1);

            var ventasFiltradas = _ventasOriginales
                .Where(v => v.FechaVenta.Date >= fechaInicio && v.FechaVenta.Date <= fechaFin)
                .ToList();

            MostrarVentasEnGrid(ventasFiltradas);
        }

        private void MostrarVentasEnGrid(List<Venta> ventas)
        {
            dtCompras.Rows.Clear();

            foreach (var venta in ventas)
            {
                dtCompras.Rows.Add(
                    venta.IDVenta,
                    venta.FechaVenta.ToString("dd/MM/yyyy"),
                    venta.NombreCliente,
                    venta.TotalVenta,
                    venta.TotalCompra, // ✅ Ya viene desde la BD
                    venta.Utilidad, // ✅ Ya viene desde la BD
                    venta.Estado
                );
            }

            CalcularTotalVentas(ventas);
        }

        private void CalcularTotalVentas(List<Venta> ventas)
        {
            decimal totalVentas = ventas.Sum(v => v.TotalVenta);
            decimal totalUtilidad = ventas.Sum(v => v.Utilidad);
            decimal totalCredito = ventas.Where(v => v.TipoVenta == "Crédito").Sum(v => v.SaldoPendiente);

            lblTotal.Text = $"$ {totalVentas:N0}";
            txtUtilidad.Text = $"$ {totalUtilidad:N0}";
            txtCredito.Text = $"$ {totalCredito:N0}";
        }


        #endregion

        #region 🔹 Exportar a Excel

        private void ExportarAExcel()
        {
            if (dtCompras.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fechaHora = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string nombreArchivo = $"Reporte_Ventas_{fechaHora}.xlsx";

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
                        var worksheet = excel.Workbook.Worksheets.Add("Ventas");

                        string[] headers = { "Fecha", "Cliente", "Total Venta", "Total Compra", "Utilidad", "Estado" };
                        for (int i = 0; i < headers.Length; i++)
                        {
                            worksheet.Cells[1, i + 1].Value = headers[i];
                            worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                            worksheet.Cells[1, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                        }

                        for (int i = 0; i < dtCompras.Rows.Count; i++)
                        {
                            worksheet.Cells[i + 2, 1].Value = dtCompras.Rows[i].Cells["FechaVenta"].Value;
                            worksheet.Cells[i + 2, 2].Value = dtCompras.Rows[i].Cells["Cliente"].Value;
                            worksheet.Cells[i + 2, 3].Value = dtCompras.Rows[i].Cells["TotalVenta"].Value;
                            worksheet.Cells[i + 2, 4].Value = dtCompras.Rows[i].Cells["TotalCompra"].Value;
                            worksheet.Cells[i + 2, 5].Value = dtCompras.Rows[i].Cells["Utilidad"].Value;
                            worksheet.Cells[i + 2, 6].Value = dtCompras.Rows[i].Cells["Estado"].Value;
                        }

                        worksheet.Cells.AutoFitColumns();
                        excel.SaveAs(new FileInfo(sfd.FileName));

                        MessageBox.Show($"Reporte exportado exitosamente:\n{sfd.FileName}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
