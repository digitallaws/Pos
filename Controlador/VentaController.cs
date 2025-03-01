using Sopromil.Data.Interfaces;
using Sopromil.Data.Repository;
using Sopromil.Modelo;
using Sopromil.Utils;
using System.Text;

namespace Sopromil.Controlador
{
    public class VentaController
    {
        private readonly IVentaRepository _ventaRepository;

        public VentaController()
        {
            _ventaRepository = new VentaRepository();
        }

        public async Task<int> RegistrarVentaAsync(Venta venta)
        {
            return await _ventaRepository.RegistrarVentaAsync(venta);
        }

        public async Task RegistrarDetalleVentaAsync(DetalleVenta detalle)
        {
            await _ventaRepository.RegistrarDetalleVentaAsync(detalle);
        }

        public async Task<List<Venta>> ObtenerVentasAsync()
        {
            return await _ventaRepository.ObtenerVentasAsync();
        }

        public async Task<List<DetalleVenta>> ObtenerDetalleVentaAsync(int idVenta)
        {
            return await _ventaRepository.ObtenerDetalleVentaAsync(idVenta);
        }

        public async Task DevolverVentaAsync(int idDetalleVenta)
        {
            await _ventaRepository.DevolverVentaAsync(idDetalleVenta);
        }
    }
}
