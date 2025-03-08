using Sopromil.Data.Repository;
using Sopromil.Modelo;

namespace Sopromil.Controlador
{
    public class PagoController
    {
        private readonly PagoRepository _pagoRepository;

        public PagoController()
        {
            _pagoRepository = new PagoRepository();
        }

        public async Task<bool> AplicarPagoAsync(int idCliente, decimal montoAbonado)
        {
            if (montoAbonado <= 0)
            {
                MessageBox.Show("El monto debe ser mayor a 0.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                int idPago = await _pagoRepository.AplicarPagoFacturaAsync(idCliente, montoAbonado);

                if (idPago > 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el pago.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al aplicar el pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public async Task<List<Pago>> ObtenerAbonosPorClienteAsync(int idCliente)
        {
            return await _pagoRepository.ObtenerAbonosPorClienteAsync(idCliente);
        }

        public async Task<decimal> ObtenerSaldoPendienteAsync(int idCliente)
        {
            return await _pagoRepository.ObtenerSaldoPendienteAsync(idCliente);
        }

    }
}
