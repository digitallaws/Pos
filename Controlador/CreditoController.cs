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
            try
            {
                string logPath = "logErrores.txt";
                string mensaje = $"[{DateTime.Now:dd/MM/yyyy HH:mm:ss}] Error en {metodo}: {ex.Message}{Environment.NewLine}";
                System.IO.File.AppendAllText(logPath, mensaje);
            }
            catch
            {
                // No interrumpir al usuario si el log falla
            }
        }

        private void MostrarError(string mensaje, string metodo)
        {
            MessageBox.Show($"Ocurrió un error en {metodo}:\n{mensaje}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // ======================
        // Verificar crédito pendiente
        // ======================
        public async Task<bool> VerificarCreditoPendienteAsync(int idCliente)
        {
            if (idCliente <= 0)
            {
                MessageBox.Show("El ID del cliente es inválido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                return await _creditoRepository.VerificarCreditoPendienteAsync(idCliente);
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(VerificarCreditoPendienteAsync));
                MostrarError(ex.Message, nameof(VerificarCreditoPendienteAsync));
                return false;
            }
        }

        // ======================
        // Registrar un nuevo crédito
        // ======================
        public async Task<bool> RegistrarCreditoAsync(Credito credito)
        {
            if (!ValidarCredito(credito)) return false;

            try
            {
                await _creditoRepository.RegistrarCreditoAsync(credito);
                return true; // Indica éxito
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(RegistrarCreditoAsync));
                MostrarError(ex.Message, nameof(RegistrarCreditoAsync));
                return false; // Indica error
            }
        }

        // ======================
        // Obtener créditos activos del cliente
        // ======================
        public async Task<List<Credito>> ObtenerCreditosActivosClienteAsync(int idCliente)
        {
            if (idCliente <= 0)
            {
                MessageBox.Show("El ID del cliente es inválido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return new List<Credito>();
            }

            try
            {
                return await _creditoRepository.ObtenerCreditosActivosClienteAsync(idCliente);
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(ObtenerCreditosActivosClienteAsync));
                MostrarError(ex.Message, nameof(ObtenerCreditosActivosClienteAsync));
                return new List<Credito>();
            }
        }

        // ======================
        // Obtener saldo pendiente
        // ======================
        public async Task<decimal> ObtenerSaldoPendienteClienteAsync(int idCliente)
        {
            if (idCliente <= 0)
            {
                MessageBox.Show("El ID del cliente es inválido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }

            try
            {
                return await _creditoRepository.ObtenerSaldoPendienteClienteAsync(idCliente);
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(ObtenerSaldoPendienteClienteAsync));
                MostrarError(ex.Message, nameof(ObtenerSaldoPendienteClienteAsync));
                return 0;
            }
        }

        // ======================
        // Registrar pago a crédito
        // ======================
        public async Task RegistrarPagoCreditoAsync(int idCredito, decimal montoPagado, decimal interesAplicado)
        {
            if (idCredito <= 0 || montoPagado <= 0)
            {
                MessageBox.Show("Datos inválidos para registrar el pago.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                await _creditoRepository.RegistrarPagoCreditoAsync(idCredito, montoPagado, interesAplicado);
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(RegistrarPagoCreditoAsync));
                MostrarError(ex.Message, nameof(RegistrarPagoCreditoAsync));
            }
        }

        // ======================
        // Obtener historial de pagos
        // ======================
        public async Task<List<PagoCredito>> ObtenerPagosCreditoAsync(int idCredito)
        {
            if (idCredito <= 0)
            {
                MessageBox.Show("El ID del crédito es inválido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return new List<PagoCredito>();
            }

            try
            {
                return await _creditoRepository.ObtenerPagosCreditoAsync(idCredito);
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(ObtenerPagosCreditoAsync));
                MostrarError(ex.Message, nameof(ObtenerPagosCreditoAsync));
                return new List<PagoCredito>();
            }
        }

        // ======================
        // Cancelar crédito
        // ======================
        public async Task CancelarCreditoAsync(int idCredito)
        {
            if (idCredito <= 0)
            {
                MessageBox.Show("El ID del crédito es inválido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                await _creditoRepository.CancelarCreditoAsync(idCredito);
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(CancelarCreditoAsync));
                MostrarError(ex.Message, nameof(CancelarCreditoAsync));
            }
        }

        // ======================
        // Obtener todos los créditos activos (para admin)
        // ======================
        public async Task<List<Credito>> ObtenerTodosLosCreditosActivosAsync()
        {
            try
            {
                return await _creditoRepository.ObtenerTodosLosCreditosActivosAsync();
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(ObtenerTodosLosCreditosActivosAsync));
                MostrarError(ex.Message, nameof(ObtenerTodosLosCreditosActivosAsync));
                return new List<Credito>();
            }
        }

        // ======================
        // Validación básica de crédito
        // ======================
        private bool ValidarCredito(Credito credito)
        {
            if (credito == null)
            {
                MessageBox.Show("La información del crédito es inválida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (credito.IDCliente <= 0)
            {
                MessageBox.Show("El cliente es inválido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (credito.Total <= 0)
            {
                MessageBox.Show("El monto total debe ser mayor a cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (credito.FechaVencimiento <= DateTime.Now.Date)
            {
                MessageBox.Show("La fecha de vencimiento debe ser posterior a hoy.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (credito.AplicaInteres && (credito.TasaInteres < 0 || credito.TasaInteres > 100))
            {
                MessageBox.Show("La tasa de interés debe estar entre 0% y 100%.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        public async Task<bool> ActualizarSaldoCreditoAsync(int idCliente, decimal monto)
        {
            try
            {
                if (idCliente <= 0 || monto <= 0)
                {
                    throw new ArgumentException("ID de cliente o monto inválido.");
                }

                await _creditoRepository.ActualizarSaldoCreditoAsync(idCliente, monto);
                return true;
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(ActualizarSaldoCreditoAsync));
                MostrarError("Error al actualizar el saldo del crédito.", nameof(ActualizarSaldoCreditoAsync));
                return false;
            }
        }

    }
}
