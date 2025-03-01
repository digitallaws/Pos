using Sopromil.Controlador;

namespace Sopromil.Vista.Dashboard
{
    public partial class Estadisticas : Form
    {
        private readonly DashboardController _dashboardController;

        public Estadisticas()
        {
            InitializeComponent();
            _dashboardController = new DashboardController();

            // Aplicar estilos a las tablas
            AplicarEstiloDataGrid(dgvProductosVencer);
            AplicarEstiloDataGrid(dgvCreditosPendientes);

            CargarEstadisticas();
        }

        private async void CargarEstadisticas()
        {
            try
            {
                // Cargar estadísticas generales
                lblVentasHoy.Text = (await _dashboardController.ObtenerVentasDelDiaAsync()).ToString("C");
                lblVentasMes.Text = (await _dashboardController.ObtenerVentasDelMesAsync()).ToString("C");
                lblCreditos.Text = (await _dashboardController.ObtenerTotalCreditosPendientesAsync()).ToString("C");
                lblProductosVencer.Text = (await _dashboardController.ObtenerProductosPorVencerAsync()) + " Und";

                // Cargar lista de productos por vencer
                var productosVencer = await _dashboardController.ObtenerProductosPorVencerDetalleAsync();
                dgvProductosVencer.DataSource = productosVencer;

                // Ocultar IDProducto
                if (dgvProductosVencer.Columns.Contains("IDProducto"))
                {
                    dgvProductosVencer.Columns["IDProducto"].Visible = false;
                }

                AjustarColumnasProductos(dgvProductosVencer);

                // Cargar lista de créditos pendientes
                var creditosPendientes = await _dashboardController.ObtenerCreditosCercanosVencimientoAsync();
                dgvCreditosPendientes.DataSource = creditosPendientes;

                // Ocultar IDCredito
                if (dgvCreditosPendientes.Columns.Contains("IDCredito"))
                {
                    dgvCreditosPendientes.Columns["IDCredito"].Visible = false;
                }

                AjustarColumnasCreditos(dgvCreditosPendientes);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar estadísticas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void AplicarEstiloDataGrid(DataGridView dgv)
        {
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.BackgroundColor = Color.White;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.RowHeadersVisible = false;
            dgv.ReadOnly = true;
            dgv.RowHeadersWidth = 51;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // ✅ Estilos generales
            dgv.DefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.BackColor = Color.White;
        }

        private void AjustarColumnasProductos(DataGridView dgv)
        {
            if (dgv.Columns.Count > 0)
            {
                dgv.Columns["Descripcion"].HeaderText = "Descripción";
                dgv.Columns["Stock"].HeaderText = "Stock Disponible";
                dgv.Columns["FechaVencimiento"].HeaderText = "Fecha de Vencimiento";
                dgv.Columns["PrecioVenta"].HeaderText = "Precio Venta";

                dgv.Columns["Descripcion"].Width = 250;
                dgv.Columns["Stock"].Width = 120;
                dgv.Columns["FechaVencimiento"].Width = 180;
                dgv.Columns["PrecioVenta"].Width = 150;

                dgv.Columns["FechaVencimiento"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgv.Columns["FechaVencimiento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["PrecioVenta"].DefaultCellStyle.Format = "C2"; // Formato moneda
            }
        }

        private void AjustarColumnasCreditos(DataGridView dgv)
        {
            if (dgv.Columns.Count > 0)
            {
                dgv.Columns["Cliente"].HeaderText = "Cliente";
                dgv.Columns["Total"].HeaderText = "Total Crédito";
                dgv.Columns["Saldo"].HeaderText = "Saldo Pendiente";
                dgv.Columns["FechaVencimiento"].HeaderText = "Fecha de Vencimiento";

                dgv.Columns["Cliente"].Width = 250;
                dgv.Columns["Total"].Width = 150;
                dgv.Columns["Saldo"].Width = 150;
                dgv.Columns["FechaVencimiento"].Width = 180;

                dgv.Columns["FechaVencimiento"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgv.Columns["FechaVencimiento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["Total"].DefaultCellStyle.Format = "C2"; // Formato moneda
                dgv.Columns["Saldo"].DefaultCellStyle.Format = "C2"; // Formato moneda
            }
        }
    }
}
