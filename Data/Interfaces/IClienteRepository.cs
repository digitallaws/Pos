using Sopromil.Modelo;

namespace Sopromil.Data.Interfaces
{
    public interface IClienteRepository
    {
        Task<int> CrearClienteAsync(Cliente cliente);
        Task<List<Cliente>> ObtenerClientesAsync();
        Task<Cliente> ObtenerClientePorIDAsync(int idCliente);
        Task ActualizarClienteAsync(Cliente cliente);
        Task CambiarEstadoClienteAsync(int idCliente, string estado);
    }
}
