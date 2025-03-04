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
            btnRegistrar.Click += BtnRegistrar_Click;
            dtCreditos.CellClick += DtCreditos_CellClick;

            // ✅ Cargar créditos al iniciar
            Load += FrmGestionCreditos_Load;
        }

        private async void FrmGestionCreditos_Load(object sender, EventArgs e)
        {
            await CargarCreditos();
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

            dtCreditos.DefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Regular);
            dtCreditos.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Bold);
            dtCreditos.DefaultCellStyle.ForeColor = Color.Black;
            dtCreditos.DefaultCellStyle.BackColor = Color.White;
        }

        private async Task CargarCreditos()
        {
            try
            {
                creditosOriginales = await _creditoController.ObtenerTodosLosCreditosActivosAsync();
                MostrarCreditosEnGrid(creditosOriginales);
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(CargarCreditos));
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
                HeaderText = "ID Crédito",
                Visible = false
            });

            dtCreditos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IDCliente",
                HeaderText = "ID Cliente",
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
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dtCreditos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Saldo",
                HeaderText = "Saldo",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dtCreditos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Estado",
                HeaderText = "Estado",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            dtCreditos.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Acción",
                Text = "Ver Detalle",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            dtCreditos.DataSource = creditos;
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim().ToLower();

            var filtrados = creditosOriginales
                .Where(c => c.IDCredito.ToString().Contains(filtro) ||
                            c.IDCliente.ToString().Contains(filtro) ||
                            c.Estado.ToLower().Contains(filtro))
                .ToList();

            MostrarCreditosEnGrid(filtrados.Any() ? filtrados : creditosOriginales);
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            using var frm = new FrmGestionarCredito();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _ = CargarCreditos();  // Ejecuta async sin bloquear
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            _ = CargarCreditos();
        }

        private void DtCreditos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dtCreditos.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                dtCreditos.Columns[e.ColumnIndex].HeaderText == "Acción")
            {
                var creditoSeleccionado = ((List<Credito>)dtCreditos.DataSource)[e.RowIndex];
                using var frmDetalle = new FrmDetalleCredito(creditoSeleccionado.IDCredito);
                frmDetalle.ShowDialog();

                _ = CargarCreditos();
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
                // No interrumpir al usuario si falla el log
            }
        }
    }
}
