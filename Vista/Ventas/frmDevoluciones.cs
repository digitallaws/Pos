using Sopromil.Controlador;
using Sopromil.Modelo;
using System.Drawing.Printing;
using System.Globalization;

namespace Sopromil.Vista.Ventas
{
    public partial class frmDevoluciones : Form
    {
        private readonly VentaController _ventaController;
        private readonly CajaController _cajaController;
        private int _idVenta;
        private List<DetalleVenta> _detalleVenta = new();
        private readonly CultureInfo culturaColombiana = new("es-CO");
        private PrintDocument printDocument;
        private decimal _totalDevolucion = 0;

        public frmDevoluciones()
        {
            InitializeComponent();
            _ventaController = new VentaController();
            _cajaController = new CajaController();

            // Eventos asignados por código
            Load += frmDevoluciones_Load;
            btnBuscarVenta.Click += btnBuscarVenta_Click;
            btnDevolverSeleccionados.Click += btnDevolverSeleccionados_Click;
            dgvDetalleVenta.CellValueChanged += dgvDetalleVenta_CellValueChanged;
            txtNumeroVenta.KeyPress += txtNumeroVenta_KeyPress;  // Solo permite números

            ConfigurarTabla();
        }

        private void frmDevoluciones_Load(object sender, EventArgs e)
        {
            lblTotalOriginal.Text = "Total Original: $0";
            lblTotalDevuelto.Text = "Total a Devolver: $0";
        }

        private void ConfigurarTabla()
        {
            dgvDetalleVenta.Columns.Clear();
            dgvDetalleVenta.Columns.Add("IDDetalleVenta", "IDDetalleVenta");
            dgvDetalleVenta.Columns["IDDetalleVenta"].Visible = false;

            dgvDetalleVenta.Columns.Add("Producto", "Producto");
            dgvDetalleVenta.Columns.Add("Cantidad", "Cantidad");
            dgvDetalleVenta.Columns.Add("PrecioUnitario", "Precio Unitario");
            dgvDetalleVenta.Columns.Add("Total", "Total");

            var checkColumn = new DataGridViewCheckBoxColumn
            {
                Name = "Seleccionar",
                HeaderText = "Seleccionar"
            };
            dgvDetalleVenta.Columns.Add(checkColumn);
        }

        private async void btnBuscarVenta_Click(object sender, EventArgs e)
        {
            string valorIngresado = txtNumeroVenta.Text.Trim();

            if (string.IsNullOrEmpty(valorIngresado))
            {
                MessageBox.Show("Debe ingresar un número de venta.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(valorIngresado, out _idVenta))
            {
                MessageBox.Show($"El número de venta '{valorIngresado}' no es válido. Ingrese solo números.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            await CargarDetalleVenta();
        }

        private async Task CargarDetalleVenta()
        {
            try
            {
                dgvDetalleVenta.Rows.Clear();
                _detalleVenta = await _ventaController.ObtenerDetalleVentaAsync(_idVenta);

                if (_detalleVenta.Count == 0)
                {
                    MessageBox.Show("No se encontró detalle para esta venta.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                decimal totalOriginal = 0;
                foreach (var item in _detalleVenta)
                {
                    dgvDetalleVenta.Rows.Add(item.IDDetalleVenta, item.DescripcionProducto, item.Cantidad,
                        item.PrecioUnitario.ToString("C0", culturaColombiana),
                        item.Total.ToString("C0", culturaColombiana), false);
                    totalOriginal += item.Total;
                }

                lblTotalOriginal.Text = $"Total Original: {totalOriginal.ToString("C0", culturaColombiana)}";
                CalcularTotalDevolucion();
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(CargarDetalleVenta));
                MessageBox.Show($"Error al cargar el detalle de la venta.\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CalcularTotalDevolucion()
        {
            decimal totalDevolucion = 0;
            foreach (DataGridViewRow row in dgvDetalleVenta.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Seleccionar"].Value))
                {
                    string totalTexto = row.Cells["Total"].Value.ToString();
                    decimal total = decimal.Parse(totalTexto.Replace("$", "").Replace(".", ""));
                    totalDevolucion += total;
                }
            }
            lblTotalDevuelto.Text = $"Total a Devolver: {totalDevolucion.ToString("C0", culturaColombiana)}";
        }

        private async void btnDevolverSeleccionados_Click(object sender, EventArgs e)
        {
            var seleccionados = new List<int>();

            foreach (DataGridViewRow row in dgvDetalleVenta.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Seleccionar"].Value))
                {
                    int idDetalleVenta = Convert.ToInt32(row.Cells["IDDetalleVenta"].Value);
                    seleccionados.Add(idDetalleVenta);
                }
            }

            if (seleccionados.Count == 0)
            {
                MessageBox.Show("Seleccione al menos un producto para devolver.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                await _ventaController.DevolverProductosAsync(seleccionados);

                var cajaAbierta = await _cajaController.ObtenerCajaAbiertaAsync();
                if (cajaAbierta != null && _totalDevolucion > 0)
                {
                    await _cajaController.RegistrarMovimientoExtraAsync(
                        cajaAbierta.IDMovimiento,
                        "EgresoExtra",
                        _totalDevolucion,
                        $"Devolución venta No. {_idVenta}"
                    );
                }

                if (MessageBox.Show("Devolución registrada correctamente.\n¿Desea imprimir comprobante de devolución?", "Éxito", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ImprimirComprobanteDevolucion();
                }

                Close();
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(btnDevolverSeleccionados_Click));
                MessageBox.Show($"Error al registrar la devolución.\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDetalleVenta_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvDetalleVenta.Columns[e.ColumnIndex].Name == "Seleccionar")
            {
                CalcularTotalDevolucion();
            }
        }

        private void ImprimirComprobanteDevolucion()
        {
            try
            {
                printDocument = new PrintDocument();
                printDocument.PrintPage += PrintDocument_PrintPage;
                printDocument.Print();
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(ImprimirComprobanteDevolucion));
                MessageBox.Show($"Error al imprimir el comprobante de devolución.\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            DibujarComprobanteDevolucion(e.Graphics);
        }

        private void DibujarComprobanteDevolucion(Graphics g)
        {
            Font fontNormal = new Font("Arial", 10);
            Font fontBold = new Font("Arial", 12, FontStyle.Bold);
            float y = 10;

            g.DrawString("COMPROBANTE DE DEVOLUCIÓN", fontBold, Brushes.Black, 10, y);
            y += 25;
            g.DrawString($"Venta No: {_idVenta}", fontNormal, Brushes.Black, 10, y);
            y += 20;

            g.DrawString("===================================", fontNormal, Brushes.Black, 10, y);
            y += 15;

            foreach (DataGridViewRow row in dgvDetalleVenta.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Seleccionar"].Value))
                {
                    string producto = row.Cells["Producto"].Value.ToString();
                    string cantidad = row.Cells["Cantidad"].Value.ToString();
                    string total = row.Cells["Total"].Value.ToString();

                    g.DrawString($"{producto}  x{cantidad}  {total}", fontNormal, Brushes.Black, 10, y);
                    y += 20;
                }
            }

            g.DrawString("===================================", fontNormal, Brushes.Black, 10, y);
            y += 15;
            g.DrawString($"TOTAL DEVUELTO: {_totalDevolucion.ToString("C0", culturaColombiana)}", fontBold, Brushes.Black, 10, y);
            y += 25;
            g.DrawString("Gracias por su preferencia.", fontNormal, Brushes.Black, 10, y);
        }

        private void txtNumeroVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquea cualquier tecla que no sea número
            }
        }

        private void LogError(Exception ex, string metodo)
        {
            try
            {
                string logPath = "logErrores.txt";
                string mensaje = $"[{DateTime.Now:dd/MM/yyyy HH:mm:ss}] Error en {metodo}: {ex.Message}{Environment.NewLine}";
                System.IO.File.AppendAllText(logPath, mensaje);
            }
            catch
            {
                // No interrumpe al usuario si el log falla.
            }
        }
    }
}
