using Sopromil.Data.Interfaces;
using Sopromil.Data.Repository;
using Sopromil.Modelo;

namespace Sopromil.Controlador
{
    public class CajaController
    {
        private readonly ICajaRepository _cajaRepository;

        public CajaController()
        {
            _cajaRepository = new CajaRepository();
        }

        public async Task<int> AbrirCajaAsync(int idUsuarioApertura, decimal saldoInicial)
        {
            return await _cajaRepository.AbrirCajaAsync(idUsuarioApertura, saldoInicial);
        }

        public async Task CerrarCajaAsync(int idMovimiento, int idUsuarioCierre, decimal saldoFinal)
        {
            await _cajaRepository.CerrarCajaAsync(idMovimiento, idUsuarioCierre, saldoFinal);
        }

        public async Task<MovimientoCaja> ObtenerCajaAbiertaAsync()
        {
            return await _cajaRepository.ObtenerCajaAbiertaAsync();
        }

        public async Task<string> ObtenerImpresoraAsync()
        {
            return await _cajaRepository.ObtenerImpresoraAsync();
        }

        public async Task<decimal> CalcularVentasDesdeAperturaCajaAsync()
        {
            return await _cajaRepository.CalcularVentasDesdeAperturaCajaAsync();
        }
    }
}
