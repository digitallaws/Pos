using Sopromil.Modelo;

namespace Sopromil.Data.Interfaces
{
    public interface IProductoRepository
    {
        Task<string> CrearProductoAsync(Producto producto);
        Task<List<Producto>> ObtenerProductosAsync();
        Task<string> ActualizarProductoAsync(Producto producto);
        Task<string> EliminarProductoAsync(int idProducto);
        Task<List<Producto>> FiltrarProductosAsync(DateTime? fechaInicio, DateTime? fechaFin, string codigoBarras, string descripcion);
    }
}
