using Sopromil.Modelo;

namespace Sopromil.Data.Interfaces
{
    public interface IDashboardRepository
    {
        Task<decimal> ObtenerVentasDelMesAsync();
        Task<decimal> ObtenerVentasDelDiaAsync();
        Task<decimal> ObtenerTotalCreditosPendientesAsync();
        Task<int> ObtenerProductosPorVencerAsync();
        Task<List<ProductoVencimiento>> ObtenerProductosPorVencerDetalleAsync();
        Task<List<CreditoPendiente>> ObtenerCreditosCercanosVencimientoAsync();
    }

}
