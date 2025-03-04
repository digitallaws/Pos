using Sopromil.Data.Interfaces;
using Sopromil.Data.Repository;
using Sopromil.Modelo;

namespace Sopromil.Controlador
{
    public class VentaController
    {
        private readonly IVentaRepository _ventaRepository;

        public VentaController()
        {
            _ventaRepository = new VentaRepository();
        }

        private void LogError(Exception ex, string metodo)
        {
            string logPath = "logErrores.txt";
            string mensaje = $"[{DateTime.Now:dd/MM/yyyy HH:mm:ss}] Error en {metodo}: {ex.Message}{Environment.NewLine}";
            File.AppendAllText(logPath, mensaje);
        }

        public async Task<int> RegistrarVentaAsync(Venta venta)
        {
            try
            {
                return await _ventaRepository.RegistrarVentaAsync(venta);
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(RegistrarVentaAsync));
                return 0; // Retorna 0 para indicar fallo
            }
        }

        public async Task RegistrarDetalleVentaAsync(DetalleVenta detalle)
        {
            try
            {
                await _ventaRepository.RegistrarDetalleVentaAsync(detalle);
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(RegistrarDetalleVentaAsync));
                throw; // Si necesitas que el error suba para manejo superior, lo dejas así
            }
        }

        public async Task<List<Venta>> ObtenerVentasAsync()
        {
            try
            {
                return await _ventaRepository.ObtenerVentasAsync();
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(ObtenerVentasAsync));
                return new List<Venta>(); // Retorna lista vacía para no romper el flujo
            }
        }

        public async Task<List<DetalleVenta>> ObtenerDetalleVentaAsync(int idVenta)
        {
            try
            {
                return await _ventaRepository.ObtenerDetalleVentaAsync(idVenta);
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(ObtenerDetalleVentaAsync));
                return new List<DetalleVenta>(); // Lista vacía para que la vista no reviente
            }
        }

        public async Task DevolverVentaAsync(int idDetalleVenta)
        {
            try
            {
                await _ventaRepository.DevolverVentaAsync(idDetalleVenta);
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(DevolverVentaAsync));
                throw; // Si es un proceso crítico, puedes decidir si explota o se maneja en el formulario
            }
        }

        public async Task<bool> RegistrarVentaCompletaAsync(Venta venta, List<DetalleVenta> detalles, bool esCredito)
        {
            try
            {
                var idVenta = await _ventaRepository.RegistrarVentaAsync(venta);

                if (idVenta <= 0)
                    throw new Exception("No se pudo registrar la venta.");

                foreach (var detalle in detalles)
                {
                    detalle.IDVenta = idVenta;
                    await _ventaRepository.RegistrarDetalleVentaAsync(detalle);
                }

                if (esCredito)
                {
                    var creditoController = new CreditoController();
                    await creditoController.ActualizarSaldoCreditoAsync(venta.IDCliente, -venta.MontoTotal);
                }

                return true;
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(RegistrarVentaCompletaAsync));
                return false; // Devuelve false para que el formulario detecte el error
            }
        }
    }
}
