using Sopromil.Controlador;
using Sopromil.Modelo;

namespace Sopromil.Vista.Creditos
{
    public partial class FrmGestionCreditos : Form
    {
        private readonly CreditoController _creditoController;
        private List<Credito> creditosOriginales = new List<Credito>();

        public FrmGestionCreditos()
        {
            InitializeComponent();
            _creditoController = new CreditoController();

            // ✅ Configurar DataGridView
            ConfigurarDataGrid();

            // ✅ Asignar eventos por código
            txtBuscar.TextChanged += TxtBuscar_TextChanged;
            btnRegistrarA.Click += BtnRegistrar_Click;
            btnRegistrar.Click += BtnActualizar_Click;
            dtCreditos.CellClick += DtCreditos_CellClick;  // Aquí está el evento que faltaba

            // ✅ Cargar créditos al iniciar
            CargarCreditos();
        }

        private void ConfigurarDataGrid()
        {
            dtCreditos.AllowUserToAddRows = false;
            dtCreditos.AllowUserToDeleteRows = false;
            dtCreditos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtCreditos.BackgroundColor = Color.White;
            dtCreditos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtCreditos.ReadOnly = true;
            dtCreditos.RowHeadersVisible = false;
            dtCreditos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // ✅ Estilo general
            dtCreditos.DefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dtCreditos.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dtCreditos.DefaultCellStyle.ForeColor = Color.Black;
            dtCreditos.DefaultCellStyle.BackColor = Color.White;
        }

        private async void CargarCreditos()
        {
            try
            {
                creditosOriginales = await _creditoController.ObtenerCreditosActivosAsync();
                MostrarCreditosEnGrid(creditosOriginales);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar créditos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarCreditosEnGrid(List<Credito> creditos)
        {
            dtCreditos.DataSource = null;
            dtCreditos.Columns.Clear();
            dtCreditos.AutoGenerateColumns = false;

            dtCreditos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IDCredito",
                HeaderText = "ID",
                Visible = false
            });

            dtCreditos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IDCliente",
                HeaderText = "IDCliente",
                Visible = false
            });

            dtCreditos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FechaRegistro",
                HeaderText = "Fecha Registro",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            dtCreditos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FechaVencimiento",
                HeaderText = "Fecha Vencimiento",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            dtCreditos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Total",
                HeaderText = "Total",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dtCreditos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Saldo",
                HeaderText = "Saldo",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dtCreditos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Estado",
                HeaderText = "Estado",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            dtCreditos.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Ver Detalle",
                Text = "Detalle",
                UseColumnTextForButtonValue = true,
                Width = 100
            });

            dtCreditos.DataSource = creditos;
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim().ToLower();

            var creditosFiltrados = creditosOriginales
                .Where(c => c.IDCredito.ToString().Contains(filtro) ||
                            c.IDCliente.ToString().Contains(filtro) ||
                            c.Estado.ToLower().Contains(filtro))
                .ToList();

            MostrarCreditosEnGrid(creditosFiltrados.Any() ? creditosFiltrados : creditosOriginales);
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            var frm = new FrmGestionarCredito();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CargarCreditos();
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            CargarCreditos();
        }

        private void DtCreditos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var creditoSeleccionado = ((List<Credito>)dtCreditos.DataSource)[e.RowIndex];

            if (dtCreditos.Columns[e.ColumnIndex].HeaderText == "Ver Detalle")
            {
                var frmDetalle = new FrmDetalleCredito(creditoSeleccionado.IDCredito);
                frmDetalle.ShowDialog();

                // Actualiza lista de créditos al cerrar el detalle
                CargarCreditos();
            }
        }
    }
}
