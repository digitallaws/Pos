using Sopromil.Data.Repository;
using Sopromil.Modelo;

namespace Sopromil.Controlador
{
    public class CajaController
    {
        private readonly CajaRepository _cajaRepository;

        public CajaController()
        {
            _cajaRepository = new CajaRepository();
        }

        // Apertura de caja
        public async Task<int> AbrirCajaAsync(int idUsuarioApertura, decimal saldoInicial)
        {
            try
            {
                return await _cajaRepository.AbrirCajaAsync(idUsuarioApertura, saldoInicial);
            }
            catch (Exception ex)
            {
                LogError("AbrirCajaAsync", ex);
                return 0;
            }
        }

        // Cierre de caja
        public async Task<bool> CerrarCajaAsync(int idMovimiento, int idUsuarioCierre, decimal saldoFinal, decimal descuadre, string observaciones)
        {
            try
            {
                return await _cajaRepository.CerrarCajaAsync(idMovimiento, idUsuarioCierre, saldoFinal, descuadre, observaciones);
            }
            catch (Exception ex)
            {
                LogError("CerrarCajaAsync", ex);
                return false;
            }
        }

        // Movimientos Extra
        public async Task<bool> RegistrarMovimientoExtraAsync(int idMovimiento, string tipoMovimiento, decimal monto, string descripcion)
        {
            try
            {
                return await _cajaRepository.RegistrarMovimientoExtraAsync(idMovimiento, tipoMovimiento, monto, descripcion);
            }
            catch (Exception ex)
            {
                LogError("RegistrarMovimientoExtraAsync", ex);
                return false;
            }
        }

        // Obtener Caja Abierta
        public async Task<MovimientoCaja?> ObtenerCajaAbiertaAsync()
        {
            try
            {
                return await _cajaRepository.ObtenerCajaAbiertaAsync();
            }
            catch (Exception ex)
            {
                LogError("ObtenerCajaAbiertaAsync", ex);
                return null;
            }
        }

        // Detalle de Movimientos
        public async Task<List<MovimientoCajaDetalle>> ObtenerMovimientosDetalleAsync(int idMovimiento)
        {
            try
            {
                return await _cajaRepository.ObtenerMovimientosDetalleAsync(idMovimiento);
            }
            catch (Exception ex)
            {
                LogError("ObtenerMovimientosDetalleAsync", ex);
                return new List<MovimientoCajaDetalle>();
            }
        }

        public async Task<bool> ConfigurarCajaAsync(string descripcion, string impresora, string copiaSeguridad, string estado, int idUsuario)
        {
            try
            {
                // 🔹 Validar si algún campo es NULL o vacío, y reemplazarlo con una cadena vacía ("")
                descripcion = string.IsNullOrWhiteSpace(descripcion) ? "" : descripcion;
                impresora = string.IsNullOrWhiteSpace(impresora) ? "" : impresora;
                copiaSeguridad = string.IsNullOrWhiteSpace(copiaSeguridad) ? "" : copiaSeguridad;
                estado = string.IsNullOrWhiteSpace(estado) ? "" : estado;

                return await _cajaRepository.ConfigurarCajaAsync(descripcion, impresora, copiaSeguridad, estado, idUsuario);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al configurar la caja: {ex.Message}");
                return false;
            }
        }

        public async Task<Caja?> ObtenerConfiguracionCajaAsync()
        {
            try
            {
                return await _cajaRepository.ObtenerConfiguracionCajaAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al obtener la configuración de la caja: {ex.Message}");
                return null;
            }
        }


        // Cálculo de Ventas desde Apertura
        public async Task<decimal> CalcularVentasDesdeAperturaCajaAsync()
        {
            try
            {
                return await _cajaRepository.CalcularVentasDesdeAperturaCajaAsync();
            }
            catch (Exception ex)
            {
                LogError("CalcularVentasDesdeAperturaCajaAsync", ex);
                return 0;
            }
        }

        // Cálculo de Ventas a Crédito desde Apertura
        public async Task<decimal> CalcularVentasCreditoDesdeAperturaAsync()
        {
            try
            {
                return await _cajaRepository.CalcularVentasCreditoDesdeAperturaAsync();
            }
            catch (Exception ex)
            {
                LogError("CalcularVentasCreditoDesdeAperturaAsync", ex);
                return 0;
            }
        }

        // Cálculo de Movimientos Extra desde Apertura
        public async Task<decimal> CalcularMovimientosExtraDesdeAperturaAsync()
        {
            try
            {
                return await _cajaRepository.CalcularMovimientosExtraDesdeAperturaAsync();
            }
            catch (Exception ex)
            {
                LogError("CalcularMovimientosExtraDesdeAperturaAsync", ex);
                return 0;
            }
        }

        // Registro centralizado de errores
        private void LogError(string metodo, Exception ex)
        {
            try
            {
                string rutaLog = "LogErrores.txt";
                string mensaje = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Error en {metodo}: {ex.Message}\n{ex.StackTrace}\n";
                System.IO.File.AppendAllText(rutaLog, mensaje);
            }
            catch
            {
                // No romper el flujo si falla el log.
            }
        }
    }
}
