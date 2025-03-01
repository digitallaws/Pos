using Sopromil.Controlador;
using Sopromil.Modelo;

namespace Sopromil.Vista.Productos
{
    public partial class SalidaStockForm : Form
    {
        private Producto productoActual;
        private readonly ProductoController _productoController;
        private readonly InventarioController _inventarioController;

        public SalidaStockForm(Producto producto)
        {
            InitializeComponent();
            _productoController = new ProductoController();
            _inventarioController = new InventarioController();
            productoActual = producto;

            lblProducto.Text = $"Producto: {producto.Descripcion}";

            // Asignar eventos a los botones
            btnConfirmar.Click += BtnConfirmar_Click;
            btnCancelar.Click += BtnCancelar_Click;
        }

        private async void BtnConfirmar_Click(object sender, EventArgs e)
        {
            int cantidadARetirar = (int)numCantidad.Value;

            if (cantidadARetirar <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cantidadARetirar > productoActual.Stock)
            {
                MessageBox.Show("No hay suficiente stock disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            productoActual.Stock -= cantidadARetirar;
            await _productoController.ActualizarProductoAsync(productoActual);
            RegistrarMovimientoInventario(productoActual.IDProducto, cantidadARetirar, "Salida", "Salida de Stock", SesionActual.IDUsuario);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private async void RegistrarMovimientoInventario(int idProducto, decimal cantidad, string tipoMovimiento, string motivo, int idUsuario)
        {
            try
            {
                await _inventarioController.RegistrarMovimientoInventarioAsync(idProducto, cantidad, tipoMovimiento, motivo, idUsuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el movimiento: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
