using Sopromil.Data.Interfaces;
using Sopromil.Data.Repository;
using Sopromil.Modelo;

namespace Sopromil.Controlador
{
    public class InventarioController
    {
        private readonly IInventarioRepository _inventarioRepository;

        public InventarioController()
        {
            _inventarioRepository = new InventarioRepository();
        }

        public async Task RegistrarMovimientoInventarioAsync(int idProducto, decimal cantidad, string tipoMovimiento, string motivo, int idUsuario)
        {
            try
            {
                var resultado = await _inventarioRepository.RegistrarMovimientoInventarioAsync(idProducto, cantidad, tipoMovimiento, motivo, idUsuario);
                if (resultado == "MovimientoRegistrado")
                    MessageBox.Show("Movimiento registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show($"Error: {resultado}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar movimiento: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task<List<MovimientoInventario>> ObtenerHistorialMovimientosAsync(DateTime? fechaInicio, DateTime? fechaFin)
        {
            return await _inventarioRepository.ObtenerHistorialMovimientosAsync(fechaInicio, fechaFin);
        }

        public async Task AjustarStockProductoAsync(int idProducto, decimal nuevoStock)
        {
            try
            {
                var resultado = await _inventarioRepository.AjustarStockProductoAsync(idProducto, nuevoStock);
                if (resultado == "StockAjustado")
                    MessageBox.Show("Stock ajustado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show($"Error al ajustar stock: {resultado}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al ajustar stock: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task<List<ProductoInventario>> ObtenerProductosBajoStockAsync()
        {
            return await _inventarioRepository.ObtenerProductosBajoStockAsync();
        }

        public async Task<List<ProductoProximoVencer>> ObtenerProductosProximosAVencerAsync()
        {
            return await _inventarioRepository.ObtenerProductosProximosAVencerAsync();
        }
    }
}
