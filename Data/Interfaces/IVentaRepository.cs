using Sopromil.Modelo;

namespace Sopromil.Data.Interfaces
{
    public interface IVentaRepository
    {
        Task<int> RegistrarVentaAsync(Venta venta);
        Task RegistrarDetalleVentaAsync(DetalleVenta detalle);
        Task<List<Venta>> ObtenerVentasAsync();
        Task<List<DetalleVenta>> ObtenerDetalleVentaAsync(int idVenta);
        Task DevolverVentaAsync(int idDetalleVenta);
        Task DevolverProductosAsync(List<int> idDetallesVenta);
        Task RegistrarVentaConCreditoAsync(Venta venta, List<DetalleVenta> detalles, int idCliente);
    }
}
