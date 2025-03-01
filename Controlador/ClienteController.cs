using Sopromil.Data.Interfaces;
using Sopromil.Data.Repository;
using Sopromil.Modelo;

namespace Sopromil.Controlador
{
    public class ClienteController
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController()
        {
            _clienteRepository = new ClienteRepository();
        }

        public async Task<int> CrearClienteAsync(Cliente cliente)
        {
            return await _clienteRepository.CrearClienteAsync(cliente);
        }

        public async Task<List<Cliente>> ObtenerClientesAsync()
        {
            return await _clienteRepository.ObtenerClientesAsync();
        }

        public async Task<Cliente> ObtenerClientePorIDAsync(int idCliente)
        {
            return await _clienteRepository.ObtenerClientePorIDAsync(idCliente);
        }

        public async Task ActualizarClienteAsync(Cliente cliente)
        {
            await _clienteRepository.ActualizarClienteAsync(cliente);
        }

        public async Task CambiarEstadoClienteAsync(int idCliente, string estado)
        {
            await _clienteRepository.CambiarEstadoClienteAsync(idCliente, estado);
        }
    }
}
