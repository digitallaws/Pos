using OfficeOpenXml;
using OfficeOpenXml.Style;
using Sopromil.Controlador;
using Sopromil.Modelo;

namespace Sopromil.Vista.Pedidos
{
    public partial class FrmPedidoCompra : Form
    {
        private readonly PedidoCompraController _pedidoController;
        private List<PedidoCompra> _pedidos;

        public FrmPedidoCompra()
        {
            InitializeComponent();
            _pedidoController = new PedidoCompraController();

            ConfigurarDataGrid();
            CargarPedidos();

            btnExcel.Click += BtnExcel_Click;
            btnEliminarFila.Click += BtnEliminarFila_Click;
        }

        private void ConfigurarDataGrid()
        {
            dtPedido.AllowUserToAddRows = false;
            dtPedido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtPedido.BackgroundColor = Color.White;
            dtPedido.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dtPedido.DefaultCellStyle.Font = new Font("Arial", 13, FontStyle.Regular);
            dtPedido.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 13, FontStyle.Bold);

            dtPedido.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            dtPedido.DefaultCellStyle.SelectionForeColor = Color.White;

            dtPedido.Columns.Clear();
            dtPedido.Columns.Add(new DataGridViewTextBoxColumn { Name = "IDProducto", HeaderText = "ID", Visible = false });
            dtPedido.Columns.Add(new DataGridViewTextBoxColumn { Name = "Descripcion", HeaderText = "Producto", Width = 200, ReadOnly = false });
            dtPedido.Columns.Add(new DataGridViewTextBoxColumn { Name = "Marca", HeaderText = "Marca", Width = 120, ReadOnly = false });
            dtPedido.Columns.Add(new DataGridViewTextBoxColumn { Name = "Stock", HeaderText = "Stock", Width = 100, ReadOnly = false });
            dtPedido.Columns.Add(new DataGridViewTextBoxColumn { Name = "PrecioCompra", HeaderText = "Precio Compra", Width = 120, ReadOnly = false });
            dtPedido.Columns.Add(new DataGridViewTextBoxColumn { Name = "NombreProveedor", HeaderText = "Proveedor", Width = 200, ReadOnly = true });
            dtPedido.Columns.Add(new DataGridViewTextBoxColumn { Name = "CiudadProveedor", HeaderText = "Ciudad", Width = 150, ReadOnly = true });
            dtPedido.Columns.Add(new DataGridViewTextBoxColumn { Name = "VentasUltimosDias", HeaderText = "Ventas Recientes", Width = 100, ReadOnly = false });
            dtPedido.Columns.Add(new DataGridViewTextBoxColumn { Name = "CantidadSugerida", HeaderText = "Sugerido", Width = 120, ReadOnly = false });
            dtPedido.Columns.Add(new DataGridViewTextBoxColumn { Name = "Total", HeaderText = "Total", Width = 120, ReadOnly = true });

            dtPedido.CellEndEdit += DtPedido_CellEndEdit;
        }

        private async void CargarPedidos()
        {
            _pedidos = await _pedidoController.GenerarPedidoAsync();
            MostrarPedidosEnGrid(_pedidos);
        }

        private void MostrarPedidosEnGrid(List<PedidoCompra> pedidos)
        {
            dtPedido.Rows.Clear();

            foreach (var pedido in pedidos)
            {
                dtPedido.Rows.Add(
                    pedido.IDProducto,
                    pedido.Descripcion,
                    pedido.Marca,
                    pedido.Stock,
                    pedido.PrecioCompra.ToString("N0"),
                    pedido.NombreProveedor,
                    pedido.CiudadProveedor,
                    pedido.VentasUltimosDias,
                    pedido.CantidadSugerida,
                    pedido.Total.ToString("N0")
                );
            }
        }

        private void DtPedido_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dtPedido.Rows[e.RowIndex];

            if (!decimal.TryParse(row.Cells["PrecioCompra"].Value?.ToString(), out decimal precioCompra))
            {
                MessageBox.Show("El valor de Precio Compra debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(row.Cells["CantidadSugerida"].Value?.ToString(), out int cantidadSugerida))
            {
                MessageBox.Show("La Cantidad Sugerida debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            row.Cells["Total"].Value = (precioCompra * cantidadSugerida).ToString("N0");
        }

        private void BtnEliminarFila_Click(object sender, EventArgs e)
        {
            if (dtPedido.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una fila para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataGridViewRow row in dtPedido.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    dtPedido.Rows.Remove(row);
                }
            }
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            if (dtPedido.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel Workbook|*.xlsx",
                Title = "Guardar Reporte",
                FileName = $"PedidoCompra_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
            };

            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage excel = new ExcelPackage())
                {
                    var worksheet = excel.Workbook.Worksheets.Add("PedidoCompra");

                    string[] headers = { "ID", "Producto", "Marca", "Stock", "Precio Compra", "Proveedor", "Ciudad", "Ventas Recientes", "Sugerido", "Total" };
                    for (int i = 0; i < headers.Length; i++)
                    {
                        worksheet.Cells[1, i + 1].Value = headers[i];
                        worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                        worksheet.Cells[1, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                    }

                    for (int i = 0; i < dtPedido.Rows.Count; i++)
                    {
                        DataGridViewRow row = dtPedido.Rows[i];
                        worksheet.Cells[i + 2, 1].Value = row.Cells["IDProducto"].Value;
                        worksheet.Cells[i + 2, 2].Value = row.Cells["Descripcion"].Value;
                        worksheet.Cells[i + 2, 3].Value = row.Cells["Marca"].Value;
                        worksheet.Cells[i + 2, 4].Value = row.Cells["Stock"].Value;
                        worksheet.Cells[i + 2, 5].Value = row.Cells["PrecioCompra"].Value;
                        worksheet.Cells[i + 2, 6].Value = row.Cells["NombreProveedor"].Value;
                        worksheet.Cells[i + 2, 7].Value = row.Cells["CiudadProveedor"].Value;
                        worksheet.Cells[i + 2, 8].Value = row.Cells["VentasUltimosDias"].Value;
                        worksheet.Cells[i + 2, 9].Value = row.Cells["CantidadSugerida"].Value;
                        worksheet.Cells[i + 2, 10].Value = row.Cells["Total"].Value;
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

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
