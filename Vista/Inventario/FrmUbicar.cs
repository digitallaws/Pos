using Sopromil.Controlador;
using System.Data;

namespace Sopromil.Vista.Inventario
{
    public partial class FrmUbicar : Form
    {
        private Dictionary<string, List<string>> _seccionesPorEstante;
        private int _idProducto;
        private readonly ProductoController _productoController;

        public FrmUbicar(int idProducto, string nombreProducto)
        {
            InitializeComponent();
            CargarUbicaciones();
            ConfigurarEventos();
            _productoController = new ProductoController();
            _idProducto = idProducto;
            lblProducto.Text = $"Ubicación de: {nombreProducto}";

        }

        private async void FrmUbicacion_Load(object sender, EventArgs e)
        {
            try
            {
                var (estante, seccion) = await _productoController.ObtenerUbicacionProductoAsync(_idProducto);

                if (!string.IsNullOrEmpty(estante))
                {
                    cbEstante.SelectedItem = estante;
                }

                if (!string.IsNullOrEmpty(seccion))
                {
                    cbSeccion.SelectedItem = seccion;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la ubicación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CargarUbicaciones()
        {
            // Lista de Estantes (A-Z)
            cbEstante.DataSource = new string[]
            {
                "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O",
                "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
            };

            // Relacionar secciones según el estante seleccionado
            cbEstante.SelectedIndexChanged += (s, e) => ActualizarSecciones();
            ActualizarSecciones();
        }

        private void ActualizarSecciones()
        {
            string estanteSeleccionado = cbEstante.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(estanteSeleccionado))
            {
                cbSeccion.DataSource = new string[]
                {
                    $"{estanteSeleccionado}1", $"{estanteSeleccionado}2", $"{estanteSeleccionado}3",
                    $"{estanteSeleccionado}4", $"{estanteSeleccionado}5", $"{estanteSeleccionado}6",
                    $"{estanteSeleccionado}7", $"{estanteSeleccionado}8", $"{estanteSeleccionado}9",
                    $"{estanteSeleccionado}10", $"{estanteSeleccionado}11", $"{estanteSeleccionado}12",
                    $"{estanteSeleccionado}13", $"{estanteSeleccionado}14", $"{estanteSeleccionado}15",
                    $"{estanteSeleccionado}16", $"{estanteSeleccionado}17", $"{estanteSeleccionado}18",
                    $"{estanteSeleccionado}19", $"{estanteSeleccionado}20", $"{estanteSeleccionado}21",
                    $"{estanteSeleccionado}22", $"{estanteSeleccionado}23", $"{estanteSeleccionado}24",
                    $"{estanteSeleccionado}25", $"{estanteSeleccionado}26", $"{estanteSeleccionado}27",
                    $"{estanteSeleccionado}28", $"{estanteSeleccionado}29", $"{estanteSeleccionado}30"
                };
            }
        }

        private void ConfigurarEventos()
        {
            cbEstante.SelectedIndexChanged += (s, e) => ActualizarSecciones();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            string estante = cbEstante.SelectedItem?.ToString();
            string seccion = cbSeccion.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(estante) || string.IsNullOrEmpty(seccion))
            {
                MessageBox.Show("Debe seleccionar un estante y una sección.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool resultado = await _productoController.UbicarProductoAsync(_idProducto, estante, seccion);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error al actualizar la ubicación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
