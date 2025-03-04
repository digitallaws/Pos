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

        private void LogError(Exception ex, string metodo)
        {
            string logPath = "logErrores.txt";
            string mensaje = $"[{DateTime.Now:dd/MM/yyyy HH:mm:ss}] Error en {metodo}: {ex.Message}{Environment.NewLine}";
            File.AppendAllText(logPath, mensaje);
        }

        private void MostrarError(string mensaje, string metodo)
        {
            MessageBox.Show($"Ocurrió un error en {metodo}: {mensaje}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public async Task<int> AbrirCajaAsync(int idUsuarioApertura, decimal saldoInicial)
        {
            try
            {
                return await _cajaRepository.AbrirCajaAsync(idUsuarioApertura, saldoInicial);
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(AbrirCajaAsync));
                MostrarError(ex.Message, nameof(AbrirCajaAsync));
                return 0;  // Retorna 0 si falla la apertura
            }
        }

        public async Task CerrarCajaAsync(int idMovimiento, int idUsuarioCierre, decimal saldoFinal)
        {
            try
            {
                await _cajaRepository.CerrarCajaAsync(idMovimiento, idUsuarioCierre, saldoFinal);
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(CerrarCajaAsync));
                MostrarError(ex.Message, nameof(CerrarCajaAsync));
            }
        }

        public async Task<MovimientoCaja> ObtenerCajaAbiertaAsync()
        {
            try
            {
                return await _cajaRepository.ObtenerCajaAbiertaAsync();
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(ObtenerCajaAbiertaAsync));
                MostrarError(ex.Message, nameof(ObtenerCajaAbiertaAsync));
                return null;  // Retorna null si no puede obtener la caja
            }
        }

        public async Task<string> ObtenerImpresoraAsync()
        {
            try
            {
                return await _cajaRepository.ObtenerImpresoraAsync();
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(ObtenerImpresoraAsync));
                MostrarError(ex.Message, nameof(ObtenerImpresoraAsync));
                return string.Empty;  // Retorna string vacío si falla
            }
        }

        public async Task<decimal> CalcularVentasDesdeAperturaCajaAsync()
        {
            try
            {
                return await _cajaRepository.CalcularVentasDesdeAperturaCajaAsync();
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(CalcularVentasDesdeAperturaCajaAsync));
                MostrarError(ex.Message, nameof(CalcularVentasDesdeAperturaCajaAsync));
                return 0;  // Si falla, retorna 0 ventas
            }
        }
    }
}
