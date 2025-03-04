using Sopromil.Modelo;

namespace Sopromil.Data.Interfaces
{
    public interface ICajaRepository
    {
        Task<int> AbrirCajaAsync(int idUsuarioApertura, decimal saldoInicial);
        Task CerrarCajaAsync(int idMovimiento, int idUsuarioCierre, decimal saldoFinal);
        Task<MovimientoCaja> ObtenerCajaAbiertaAsync();
        Task<string> ObtenerImpresoraAsync();
        Task<decimal> CalcularVentasDesdeAperturaCajaAsync();

        // Nuevos métodos para movimientos extra
        Task RegistrarMovimientoExtraAsync(int idMovimiento, string tipo, decimal monto, string descripcion);
        Task<decimal> CalcularMovimientosExtraDesdeAperturaAsync();
        Task<List<MovimientoCajaDetalle>> ObtenerMovimientosExtraDeCajaAsync(int idMovimiento);
    }
}
