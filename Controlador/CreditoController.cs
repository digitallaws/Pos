using Sopromil.Data.Interfaces;
using Sopromil.Data.Repository;
using Sopromil.Modelo;

namespace Sopromil.Controlador
{
    public class CreditoController
    {
        private readonly ICreditoRepository _creditoRepository;

        public CreditoController()
        {
            _creditoRepository = new CreditoRepository();
        }

        private void LogError(Exception ex, string metodo)
        {
            string logPath = "logErrores.txt";
            string mensaje = $"[{DateTime.Now:dd/MM/yyyy HH:mm:ss}] Error en {metodo}: {ex.Message}{Environment.NewLine}";
            File.AppendAllText(logPath, mensaje);
        }

        // Nuevo método usando el SP que valida cupo y evita créditos duplicados
        public async Task<string> RegistrarOActualizarCreditoAsync(Credito credito)
        {
            try
            {
                if (credito.IDCliente <= 0)
                    throw new ArgumentException("ID de cliente inválido.");
                if (credito.Total <= 0)
                    throw new ArgumentException("El monto debe ser mayor a cero.");

                return await _creditoRepository.RegistrarOActualizarCreditoAsync(credito);
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(RegistrarOActualizarCreditoAsync));
                return "Error al procesar el crédito.";
            }
        }

        public async Task<bool> RegistrarPagoAsync(int idCredito, decimal montoPagado, decimal interesAplicado)
        {
            try
            {
                if (idCredito <= 0) throw new ArgumentException("ID de crédito inválido.");
                if (montoPagado <= 0) throw new ArgumentException("El monto pagado debe ser mayor a cero.");

                await _creditoRepository.RegistrarPagoAsync(idCredito, montoPagado, interesAplicado);

                // Validar si el crédito queda saldo cero y cancelarlo automáticamente
                var creditos = await _creditoRepository.ObtenerCreditosActivosAsync();
                var credito = creditos.FirstOrDefault(c => c.IDCredito == idCredito);

                if (credito != null && credito.Saldo <= 0)
                {
                    await _creditoRepository.CancelarCreditoAsync(idCredito);
                }

                return true;
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(RegistrarPagoAsync));
                return false;
            }
        }

        public async Task<decimal> ObtenerSaldoPendienteAsync(int? idCliente, string documento = null)
        {
            try
            {
                if (idCliente == null && string.IsNullOrWhiteSpace(documento))
                    throw new ArgumentException("Debe proporcionar el IDCliente o el Documento.");

                return await _creditoRepository.ObtenerSaldoPendienteAsync(idCliente, documento);
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(ObtenerSaldoPendienteAsync));
                return 0;
            }
        }

        public async Task<List<Credito>> ObtenerCreditosActivosAsync()
        {
            try
            {
                return await _creditoRepository.ObtenerCreditosActivosAsync();
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(ObtenerCreditosActivosAsync));
                return new List<Credito>();
            }
        }

        public async Task<List<PagoCredito>> ObtenerPagosCreditoAsync(int idCredito)
        {
            try
            {
                if (idCredito <= 0) throw new ArgumentException("ID de crédito inválido.");

                return await _creditoRepository.ObtenerPagosCreditoAsync(idCredito);
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(ObtenerPagosCreditoAsync));
                return new List<PagoCredito>();
            }
        }

        public async Task<bool> CancelarCreditoAsync(int idCredito)
        {
            try
            {
                if (idCredito <= 0) throw new ArgumentException("ID de crédito inválido.");

                await _creditoRepository.CancelarCreditoAsync(idCredito);
                return true;
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(CancelarCreditoAsync));
                return false;
            }
        }

        public async Task<bool> ActualizarSaldoCreditoAsync(int idCliente, decimal monto)
        {
            try
            {
                if (idCliente <= 0) throw new ArgumentException("ID de cliente inválido.");
                if (monto <= 0) throw new ArgumentException("El monto debe ser mayor a cero.");

                await _creditoRepository.ActualizarSaldoCreditoAsync(idCliente, monto);
                return true;
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(ActualizarSaldoCreditoAsync));
                return false;
            }
        }
    }
}
