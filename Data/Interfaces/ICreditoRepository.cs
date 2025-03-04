using Sopromil.Modelo;

namespace Sopromil.Data.Interfaces
{
    public interface ICreditoRepository
    {
        Task<bool> VerificarCreditoPendienteAsync(int idCliente);
        Task RegistrarCreditoAsync(Credito credito);
        Task<List<Credito>> ObtenerCreditosActivosClienteAsync(int idCliente);
        Task<decimal> ObtenerSaldoPendienteClienteAsync(int idCliente);
        Task RegistrarPagoCreditoAsync(int idCredito, decimal montoPagado, decimal interesAplicado);
        Task<List<PagoCredito>> ObtenerPagosCreditoAsync(int idCredito);
        Task CancelarCreditoAsync(int idCredito);
        Task<List<Credito>> ObtenerTodosLosCreditosActivosAsync();
        Task ActualizarSaldoCreditoAsync(int idCliente, decimal monto);
    }
}
