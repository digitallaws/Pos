using Sopromil.Controlador;
using Sopromil.Modelo;
using System.Drawing;

namespace Sopromil.Vista.Clientes
{
    public partial class FrmComprasCliente : Form
    {
        private readonly VentaController _ventaController;
        private int _idCliente;
        private string _nombreCliente;

        public FrmComprasCliente(int id, string nombre)
        {
            InitializeComponent();
            _ventaController = new VentaController();
            _idCliente = id;
            _nombreCliente = nombre;

            txtCliente.Text = nombre;
            lbId.Text = id.ToString();

            ConfigurarDataGridView();
            ConfigurarComboBox();
            CargarVentas();

            txtBuscar.TextChanged += TxtBuscar_TextChanged;
            cbTipoPago.SelectedIndexChanged += CbTipoVenta_SelectedIndexChanged;
            btnAbonar.Click += BtnAbonar_Click; // 🔥 Evento para abrir FrmAbono
        }

        private void ConfigurarDataGridView()
        {
            dtVentas.AllowUserToAddRows = false;
            dtVentas.AllowUserToDeleteRows = false;
            dtVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtVentas.BackgroundColor = Color.White;
            dtVentas.ReadOnly = true;
            dtVentas.RowHeadersVisible = false;
            dtVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dtVentas.DefaultCellStyle.Font = new Font("Arial", 13, FontStyle.Regular);
            dtVentas.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 13, FontStyle.Bold);

            // 💠 Cambiar color de selección
            dtVentas.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            dtVentas.DefaultCellStyle.SelectionForeColor = Color.White;

            dtVentas.Columns.Clear();
            dtVentas.Columns.Add(new DataGridViewTextBoxColumn { Name = "IDVenta", HeaderText = "ID", Visible = false });
            dtVentas.Columns.Add(new DataGridViewTextBoxColumn { Name = "FechaVenta", HeaderText = "Fecha", Width = 120 });
            dtVentas.Columns.Add(new DataGridViewTextBoxColumn { Name = "TipoVenta", HeaderText = "Tipo de Pago", Width = 100 });
            dtVentas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TotalVenta",
                HeaderText = "Total",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N0" }
            });
            dtVentas.Columns.Add(new DataGridViewTextBoxColumn { Name = "Estado", HeaderText = "Estado", Width = 100 });

            DataGridViewButtonColumn btnDetalles = new DataGridViewButtonColumn
            {
                Name = "Detalles",
                HeaderText = "Ver Detalles",
                Text = "👁",
                UseColumnTextForButtonValue = true,
                Width = 80
            };
            dtVentas.Columns.Add(btnDetalles);

            dtVentas.CellClick += DtVentas_CellClick;
            dtVentas.CellFormatting += DtVentas_CellFormatting; // 🔥 Evento para cambiar color de fila
        }

        private void ConfigurarComboBox()
        {
            cbTipoPago.Items.Add("Todos");
            cbTipoPago.Items.Add("Contado");
            cbTipoPago.Items.Add("Crédito");
            cbTipoPago.SelectedIndex = 0; // Selecciona "Todos" por defecto
        }

        private async void CargarVentas()
        {
            List<Venta> ventas = await _ventaController.ObtenerVentasPorClienteAsync(_idCliente);
            MostrarVentasEnGrid(ventas);
            FiltrarVentasPorTipo(); // Aplica el filtro después de cargar los datos
        }

        private void MostrarVentasEnGrid(List<Venta> ventas)
        {
            dtVentas.Rows.Clear();

            foreach (var venta in ventas)
            {
                dtVentas.Rows.Add(
                    venta.IDVenta,
                    venta.FechaVenta.ToString("dd/MM/yyyy"),
                    venta.TipoVenta,
                    venta.TotalVenta,
                    venta.Estado
                );
            }

            CalcularTotalCredito(); // 🔥 Llamamos a esta función para actualizar lblCredito
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim().ToLower();

            if (dtVentas.Rows.Count == 0) return;

            foreach (DataGridViewRow row in dtVentas.Rows)
            {
                if (row.Cells["FechaVenta"].Value == null || row.Cells["TipoVenta"].Value == null || row.Cells["TotalVenta"].Value == null)
                    continue;

                string fecha = row.Cells["FechaVenta"].Value.ToString().ToLower();
                string tipoVenta = row.Cells["TipoVenta"].Value.ToString().ToLower();
                string totalVenta = row.Cells["TotalVenta"].Value.ToString().Replace(",", "").ToLower();

                row.Visible = fecha.Contains(filtro) || tipoVenta.Contains(filtro) || totalVenta.Contains(filtro);
            }
        }

        private void CbTipoVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarVentasPorTipo(); // Filtra sin recargar datos
        }

        private void FiltrarVentasPorTipo()
        {
            string filtroTipo = cbTipoPago.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(filtroTipo) || filtroTipo == "Todos")
            {
                foreach (DataGridViewRow row in dtVentas.Rows)
                {
                    row.Visible = true;
                }
                return;
            }

            foreach (DataGridViewRow row in dtVentas.Rows)
            {
                if (row.Cells["TipoVenta"].Value != null)
                {
                    string tipoVenta = row.Cells["TipoVenta"].Value.ToString();
                    row.Visible = tipoVenta.Equals(filtroTipo, StringComparison.OrdinalIgnoreCase);
                }
            }
        }

        private void DtVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dtVentas.Columns[e.ColumnIndex].Name == "Detalles")
            {
                int idVenta = Convert.ToInt32(dtVentas.Rows[e.RowIndex].Cells["IDVenta"].Value);
                FrmDetallesVenta detallesVenta = new FrmDetallesVenta(idVenta);
                detallesVenta.ShowDialog();
            }
        }

        /// <summary>
        /// Abre el formulario de abonos y actualiza las ventas.
        /// </summary>
        private void BtnAbonar_Click(object sender, EventArgs e)
        {
            FrmAbono frmAbono = new FrmAbono(_idCliente);
            frmAbono.ShowDialog();

            // Recargar la vista después de abonar
            CargarVentas();
            CalcularTotalCredito();
        }

        /// <summary>
        /// Calcula el total de compras a crédito y lo muestra en lblCredito.
        /// </summary>
        private void CalcularTotalCredito()
        {
            decimal totalCredito = 0;

            foreach (DataGridViewRow row in dtVentas.Rows)
            {
                if (row.Cells["TipoVenta"].Value.ToString() == "Crédito" && row.Cells["Estado"].Value.ToString() == "Pendiente")
                {
                    totalCredito += Convert.ToDecimal(row.Cells["TotalVenta"].Value);
                }
            }
        }

        /// <summary>
        /// 🔥 Cambia el color de las facturas pagadas a verde.
        /// </summary>
        private void DtVentas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && dtVentas.Columns[e.ColumnIndex].Name == "Estado")
            {
                DataGridViewRow row = dtVentas.Rows[e.RowIndex];

                if (row.Cells["Estado"].Value != null)
                {
                    string estado = row.Cells["Estado"].Value.ToString();

                    if (estado == "Pagado")
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                }
            }
        }
    }
}
