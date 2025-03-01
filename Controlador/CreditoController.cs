using Sopromil.Data.Interfaces;
using Sopromil.Data.Repository;
using Sopromil.Modelo;
using Sopromil.Vista.Creditos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sopromil.Controlador
{
    public class CreditoController
    {
        private readonly ICreditoRepository _creditoRepository;

        public CreditoController()
        {
            _creditoRepository = new CreditoRepository();
        }

        public async Task RegistrarCreditoAsync(Credito credito)
        {
            if (credito.IDCliente <= 0)
                throw new ArgumentException("ID de cliente inválido.");

            if (credito.Total <= 0)
                throw new ArgumentException("El total debe ser mayor a cero.");

            await _creditoRepository.RegistrarCreditoAsync(credito);
        }

        public async Task RegistrarPagoAsync(int idCredito, decimal montoPagado, decimal interesAplicado)
        {
            if (idCredito <= 0)
                throw new ArgumentException("ID de crédito inválido.");

            if (montoPagado <= 0)
                throw new ArgumentException("El monto pagado debe ser mayor a cero.");

            await _creditoRepository.RegistrarPagoAsync(idCredito, montoPagado, interesAplicado);
        }

        public async Task<decimal> ObtenerSaldoPendienteAsync(int? idCliente, string documento = null)
        {
            if (idCliente == null && string.IsNullOrWhiteSpace(documento))
                throw new ArgumentException("Debe proporcionar el IDCliente o el Documento.");
            return await _creditoRepository.ObtenerSaldoPendienteAsync(idCliente, documento);
        }

        public async Task<List<Credito>> ObtenerCreditosActivosAsync(int? idCliente, string documento = null)
        {
            if (idCliente == null && string.IsNullOrWhiteSpace(documento))
                throw new ArgumentException("Debe proporcionar el IDCliente o el Documento.");

            return await _creditoRepository.ObtenerCreditosActivosAsync(idCliente, documento);
        }

        public async Task<List<PagoCredito>> ObtenerPagosCreditoAsync(int idCredito)
        {
            if (idCredito <= 0)
                throw new ArgumentException("ID de crédito inválido.");

            return await _creditoRepository.ObtenerPagosCreditoAsync(idCredito);
        }

        public async Task CancelarCreditoAsync(int idCredito)
        {
            if (idCredito <= 0)
                throw new ArgumentException("ID de crédito inválido.");

            await _creditoRepository.CancelarCreditoAsync(idCredito);
        }

        public async Task ActualizarSaldoCreditoAsync(int idCliente, decimal monto)
        {
            if (idCliente <= 0)
                throw new ArgumentException("ID de cliente inválido.");

            if (monto <= 0)
                throw new ArgumentException("El monto debe ser mayor a cero.");

            await _creditoRepository.ActualizarSaldoCreditoAsync(idCliente, monto);
        }

    }
}
