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

        // ========================================
        // APERTURA DE CAJA
        // ========================================
        public async Task<int> AbrirCajaAsync(int idUsuarioApertura, decimal saldoInicial)
        {
            try
            {
                if (saldoInicial < 0)
                    throw new ArgumentException("El saldo inicial no puede ser negativo.");

                return await _cajaRepository.AbrirCajaAsync(idUsuarioApertura, saldoInicial);
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(AbrirCajaAsync));
                MostrarError("Error al abrir la caja.", ex);
                return 0;
            }
        }

        // ========================================
        // CIERRE DE CAJA
        // ========================================
        public async Task CerrarCajaAsync(int idMovimiento, int idUsuarioCierre, decimal saldoFinal)
        {
            try
            {
                await _cajaRepository.CerrarCajaAsync(idMovimiento, idUsuarioCierre, saldoFinal);
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(CerrarCajaAsync));
                MostrarError("Error al cerrar la caja.", ex);
            }
        }

        // ========================================
        // OBTENER CAJA ABIERTA
        // ========================================
        public async Task<MovimientoCaja> ObtenerCajaAbiertaAsync()
        {
            try
            {
                return await _cajaRepository.ObtenerCajaAbiertaAsync();
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(ObtenerCajaAbiertaAsync));
                MostrarError("Error al obtener la caja abierta.", ex);
                return null;
            }
        }

        // ========================================
        // CALCULAR VENTAS DESDE APERTURA
        // ========================================
        public async Task<decimal> CalcularVentasDesdeAperturaCajaAsync()
        {
            try
            {
                return await _cajaRepository.CalcularVentasDesdeAperturaCajaAsync();
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(CalcularVentasDesdeAperturaCajaAsync));
                MostrarError("Error al calcular las ventas desde la apertura.", ex);
                return 0;
            }
        }

        // ========================================
        // REGISTRAR MOVIMIENTO EXTRA (INGRESO/EGRESO)
        // ========================================
        public async Task RegistrarMovimientoExtraAsync(int idMovimiento, string tipo, decimal monto, string descripcion)
        {
            try
            {
                ValidarMovimientoExtra(idMovimiento, tipo, monto, descripcion);
                await _cajaRepository.RegistrarMovimientoExtraAsync(idMovimiento, tipo, monto, descripcion);
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(RegistrarMovimientoExtraAsync));
                MostrarError("Error al registrar el movimiento extra.", ex);
            }
        }

        // ========================================
        // CALCULAR MOVIMIENTOS EXTRA DESDE APERTURA
        // ========================================
        public async Task<decimal> CalcularMovimientosExtraDesdeAperturaAsync()
        {
            try
            {
                return await _cajaRepository.CalcularMovimientosExtraDesdeAperturaAsync();
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(CalcularMovimientosExtraDesdeAperturaAsync));
                MostrarError("Error al calcular los movimientos extra desde la apertura.", ex);
                return 0;
            }
        }

        // ========================================
        // OBTENER MOVIMIENTOS EXTRA DE UNA CAJA
        // ========================================
        public async Task<List<MovimientoCajaDetalle>> ObtenerMovimientosExtraDeCajaAsync(int idMovimiento)
        {
            try
            {
                return await _cajaRepository.ObtenerMovimientosExtraDeCajaAsync(idMovimiento);
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(ObtenerMovimientosExtraDeCajaAsync));
                MostrarError("Error al obtener los movimientos extra de la caja.", ex);
                return new List<MovimientoCajaDetalle>();
            }
        }

        // ========================================
        // OBTENER IMPRESORA CONFIGURADA
        // ========================================
        public async Task<string> ObtenerImpresoraAsync()
        {
            try
            {
                return await _cajaRepository.ObtenerImpresoraAsync();
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(ObtenerImpresoraAsync));
                MostrarError("Error al obtener la impresora configurada.", ex);
                return "IMPRESORA NO CONFIGURADA";
            }
        }

        // ========================================
        // VALIDACIONES DE MOVIMIENTO EXTRA
        // ========================================
        private void ValidarMovimientoExtra(int idMovimiento, string tipo, decimal monto, string descripcion)
        {
            if (idMovimiento <= 0)
                throw new ArgumentException("ID de caja inválido.");

            if (string.IsNullOrWhiteSpace(tipo) || (tipo != "IngresoExtra" && tipo != "EgresoExtra"))
                throw new ArgumentException("Tipo de movimiento inválido. Debe ser 'IngresoExtra' o 'EgresoExtra'.");

            if (monto <= 0)
                throw new ArgumentException("El monto debe ser mayor a cero.");

            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripción es obligatoria.");
        }

        // ========================================
        // LOG DE ERRORES
        // ========================================
        private void LogError(Exception ex, string metodo)
        {
            try
            {
                string logPath = "logErrores.txt";
                string mensaje = $"[{DateTime.Now:dd/MM/yyyy HH:mm:ss}] Error en {metodo}: {ex.Message}{Environment.NewLine}";
                File.AppendAllText(logPath, mensaje);
            }
            catch
            {
                // Si falla el log, no interrumpimos el flujo
            }
        }

        // ========================================
        // MOSTRAR ERROR AL USUARIO
        // ========================================
        private void MostrarError(string mensaje, Exception ex)
        {
            MessageBox.Show($"{mensaje}\n\nDetalle Técnico: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
