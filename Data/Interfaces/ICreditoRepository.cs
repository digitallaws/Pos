using Sopromil.Modelo;

namespace Sopromil.Data.Interfaces
{
    public interface ICreditoRepository
    {
        Task<string> RegistrarOActualizarCreditoAsync(Credito credito);
        Task RegistrarCreditoAsync(Credito credito);
        Task RegistrarPagoAsync(int idCredito, decimal montoPagado, decimal interesAplicado);
        Task<decimal> ObtenerSaldoPendienteAsync(int? idCliente, string documento = null);
        Task<List<Credito>> ObtenerCreditosActivosAsync();
        Task<List<PagoCredito>> ObtenerPagosCreditoAsync(int idCredito);
        Task CancelarCreditoAsync(int idCredito);
        Task ActualizarSaldoCreditoAsync(int idCliente, decimal monto);
    }
}
