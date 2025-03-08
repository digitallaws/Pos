using Sopromil.Data.Repository;
using Sopromil.Modelo;

namespace Sopromil.Controlador
{
    public class ProductoController
    {
        private readonly ProductoRepository _productoRepository;

        public ProductoController()
        {
            _productoRepository = new ProductoRepository();
        }

        public async Task<List<Producto>> ListarProductosPorProveedorAsync(int idProveedor, bool soloActivos = true)
        {
            try
            {
                return await _productoRepository.ListarProductosPorProveedorAsync(idProveedor, soloActivos);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Producto>();
            }
        }

        public async Task<List<Producto>> ListarTodosLosProductosAsync(bool soloActivos = true)
        {
            try
            {
                return await _productoRepository.ListarTodosLosProductosAsync(soloActivos);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener todos los productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Producto>();
            }
        }

        public async Task CrearProductoAsync(Producto producto)
        {
            if (!ValidarProducto(producto)) return;

            try
            {
                await _productoRepository.CrearProductoAsync(producto);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task ActualizarProductoAsync(Producto producto)
        {
            if (!ValidarProducto(producto)) return;

            try
            {
                await _productoRepository.ActualizarProductoAsync(producto);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task CambiarEstadoProductoAsync(int idProducto, string nuevoEstado)
        {
            try
            {
                await _productoRepository.CambiarEstadoProductoAsync(idProducto, nuevoEstado);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar estado del producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarProducto(Producto producto)
        {
            if (string.IsNullOrWhiteSpace(producto.Descripcion))
            {
                MessageBox.Show("La descripción es obligatoria.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (producto.PrecioCompra <= 0)
            {
                MessageBox.Show("El precio de compra debe ser mayor a cero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (producto.Utilidad < 0)
            {
                MessageBox.Show("La utilidad no puede ser negativa.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (producto.Stock < 0)
            {
                MessageBox.Show("El stock no puede ser negativo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (producto.IDProveedor <= 0)
            {
                MessageBox.Show("Debe seleccionar un proveedor válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
