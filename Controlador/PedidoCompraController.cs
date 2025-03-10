using Sopromil.Data.Repository;
using Sopromil.Modelo;

namespace Sopromil.Controlador
{
    public class PedidoCompraController
    {
        private readonly PedidoCompraRepository _pedidoCompraRepository;

        public PedidoCompraController()
        {
            _pedidoCompraRepository = new PedidoCompraRepository();
        }

        public async Task<List<PedidoCompra>> GenerarPedidoAsync()
        {
            return await _pedidoCompraRepository.GenerarPedidoAsync();
        }
    }
}
