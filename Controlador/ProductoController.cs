using Sopromil.Data.Interfaces;
using Sopromil.Data.Repository;
using Sopromil.Modelo;

namespace Sopromil.Controlador
{
    public class ProductoController
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoController()
        {
            _productoRepository = new ProductoRepository();
        }

        public async Task<List<Producto>> ObtenerProductosAsync()
        {
            try
            {
                return await _productoRepository.ObtenerProductosAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Producto>();
            }
        }

        public async Task CrearProductoAsync(Producto producto)
        {
            try
            {
                var resultado = await _productoRepository.CrearProductoAsync(producto);

                if (resultado == "ProductoCreado" || resultado == "ProductoActualizado")
                {
                    //MessageBox.Show("Producto creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo crear el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task ActualizarProductoAsync(Producto producto)
        {
            try
            {
                var resultado = await _productoRepository.ActualizarProductoAsync(producto);

                if (resultado == "ProductoActualizado")
                {
                    MessageBox.Show("Producto actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task EliminarProductoAsync(int idProducto)
        {
            try
            {
                var resultado = await _productoRepository.EliminarProductoAsync(idProducto);

                if (resultado == "ProductoEliminado")
                {
                    MessageBox.Show("Producto eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task<List<Producto>> FiltrarProductosAsync(DateTime? fechaInicio, DateTime? fechaFin, string codigoBarras, string descripcion)
        {
            try
            {
                return await _productoRepository.FiltrarProductosAsync(fechaInicio, fechaFin, codigoBarras, descripcion);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al filtrar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Producto>();
            }
        }
    }
}
