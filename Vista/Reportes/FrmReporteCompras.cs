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
    public partial class FrmReporteCompras : Form
    {
        private readonly CompraController _compraController;
        private readonly ProveedorController _proveedorController;
        private List<Compra> _comprasOriginales = new();

        public FrmReporteCompras()
        {
            InitializeComponent();
            _compraController = new CompraController();
            _proveedorController = new ProveedorController();

            ConfigurarEventos();
            ConfigurarDataGrid();
            CargarProveedores();
            CargarCompras();
        }

        #region 🔹 Configuración Inicial
        private void ConfigurarEventos()
        {
            btnFiiltrar.Click += (s, e) => FiltrarCompras();
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
            dtCompras.Columns.Add(new DataGridViewTextBoxColumn { Name = "IDCompra", HeaderText = "ID", Visible = false });
            dtCompras.Columns.Add(new DataGridViewTextBoxColumn { Name = "FechaCompra", HeaderText = "Fecha", Width = 120 });
            dtCompras.Columns.Add(new DataGridViewTextBoxColumn { Name = "Proveedor", HeaderText = "Proveedor", Width = 180 });
            dtCompras.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TotalCompra",
                HeaderText = "Total",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N0" }
            });
            dtCompras.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Flete",
                HeaderText = "Flete",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N0" }
            });
            dtCompras.Columns.Add(new DataGridViewTextBoxColumn { Name = "Estado", HeaderText = "Estado", Width = 120 });
        }

        private async void CargarProveedores()
        {
            var proveedores = await _proveedorController.ObtenerProveedoresAsync();
            cbProveedores.Items.Clear();
            cbProveedores.Items.Add("Todos");
            cbProveedores.Items.AddRange(proveedores.Select(p => p.Nombre).ToArray());
            cbProveedores.SelectedIndex = 0;
        }

        private async void CargarCompras()
        {
            _comprasOriginales = await _compraController.ObtenerComprasAsync() ?? new List<Compra>();
            txtFechaInicio.Value = DateTime.Today.AddMonths(-1);
            txtFechaFin.Value = DateTime.Today;
            FiltrarCompras();
        }
        #endregion

        #region 🔹 Filtrado y Cálculo de Totales
        private void FiltrarCompras()
        {
            if (_comprasOriginales == null || _comprasOriginales.Count == 0)
            {
                MessageBox.Show("No hay compras disponibles.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string proveedorSeleccionado = cbProveedores.SelectedItem?.ToString() ?? "Todos";
            DateTime fechaInicio = txtFechaInicio.Value.Date;
            DateTime fechaFin = txtFechaFin.Value.Date.AddDays(1).AddSeconds(-1); // Extender al final del día

            var comprasFiltradas = _comprasOriginales
                .Where(c =>
                    (proveedorSeleccionado == "Todos" || string.Equals(c.NombreProveedor.Trim(), proveedorSeleccionado.Trim(), StringComparison.OrdinalIgnoreCase)) &&
                    c.FechaCompra.Date >= fechaInicio && c.FechaCompra.Date <= fechaFin)
                .ToList();

            MostrarComprasEnGrid(comprasFiltradas);
        }


        private void MostrarComprasEnGrid(List<Compra> compras)
        {
            dtCompras.Rows.Clear();

            foreach (var compra in compras)
            {
                dtCompras.Rows.Add(
                    compra.IDCompra,
                    compra.FechaCompra.ToString("dd/MM/yyyy"),
                    compra.NombreProveedor,
                    Convert.ToDecimal(compra.TotalCompra),
                    Convert.ToDecimal(compra.Flete),
                    compra.Estado
                );
            }

            CalcularTotalCompras(compras);
        }

        private void CalcularTotalCompras(List<Compra> compras)
        {
            decimal total = compras.Sum(c => c.TotalCompra);
            lblTotal.Text = $" $ {total:N0}";
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
            string nombreArchivo = $"Reporte_Compras_{fechaHora}.xlsx";

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
                        var worksheet = excel.Workbook.Worksheets.Add("Compras");

                        string[] headers = { "Fecha", "Proveedor", "Total", "Flete", "Estado" };
                        for (int i = 0; i < headers.Length; i++)
                        {
                            worksheet.Cells[1, i + 1].Value = headers[i];
                            worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                            worksheet.Cells[1, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                        }

                        for (int i = 0; i < dtCompras.Rows.Count; i++)
                        {
                            worksheet.Cells[i + 2, 1].Value = dtCompras.Rows[i].Cells["FechaCompra"].Value;
                            worksheet.Cells[i + 2, 2].Value = dtCompras.Rows[i].Cells["Proveedor"].Value;
                            worksheet.Cells[i + 2, 3].Value = dtCompras.Rows[i].Cells["TotalCompra"].Value;
                            worksheet.Cells[i + 2, 4].Value = dtCompras.Rows[i].Cells["Flete"].Value;
                            worksheet.Cells[i + 2, 5].Value = dtCompras.Rows[i].Cells["Estado"].Value;
                        }

                        worksheet.Cells.AutoFitColumns();

                        FileInfo fileInfo = new FileInfo(sfd.FileName);
                        excel.SaveAs(fileInfo);

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
