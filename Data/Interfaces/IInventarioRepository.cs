using Sopromil.Modelo;

namespace Sopromil.Data.Interfaces
{
    public interface IInventarioRepository
    {
        Task<string> RegistrarMovimientoInventarioAsync(int idProducto, decimal cantidad, string tipoMovimiento, string motivo, int idUsuario);
        Task<List<MovimientoInventario>> ObtenerHistorialMovimientosAsync(DateTime? fechaInicio, DateTime? fechaFin);
        Task<string> AjustarStockProductoAsync(int idProducto, decimal nuevoStock);
        Task<List<ProductoInventario>> ObtenerProductosBajoStockAsync();
        Task<List<ProductoProximoVencer>> ObtenerProductosProximosAVencerAsync();
    }
}
