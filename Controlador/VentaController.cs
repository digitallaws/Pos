using Sopromil.Data.Repository;
using Sopromil.Modelo;

namespace Sopromil.Controlador
{
    public class VentaController
    {
        private readonly VentaRepository _ventaRepository;

        public VentaController()
        {
            _ventaRepository = new VentaRepository();
        }

        /// <summary>
        /// Registra una nueva venta con detalles.
        /// </summary>
        public async Task<int> RegistrarVentaAsync(Venta venta, List<DetalleVenta> detalles)
        {
            if (!ValidarVenta(venta, detalles)) return 0;

            try
            {
                return await _ventaRepository.RegistrarVentaAsync(venta, detalles);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar la venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
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
                MessageBox.Show($"Error al obtener las ventas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Venta>();
            }
        }

        /// <summary>
        /// Obtiene una venta por su ID.
        /// </summary>
        public async Task<Venta> ObtenerVentaPorIdAsync(int idVenta)
        {
            try
            {
                return await _ventaRepository.ObtenerVentaPorIdAsync(idVenta);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener la información de la venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Obtiene todas las ventas de un cliente específico.
        /// </summary>
        public async Task<List<Venta>> ObtenerVentasPorClienteAsync(int idCliente)
        {
            try
            {
                return await _ventaRepository.ObtenerVentasPorClienteAsync(idCliente);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener ventas del cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Venta>();
            }
        }

        /// <summary>
        /// Obtiene el saldo pendiente de un cliente.
        /// </summary>
        public async Task<decimal> ObtenerSaldoPendienteAsync(int idCliente)
        {
            try
            {
                return await _ventaRepository.ObtenerSaldoPendienteAsync(idCliente);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener saldo pendiente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        /// <summary>
        /// Aplica un pago a las facturas de un cliente.
        /// </summary>
        public async Task<bool> AplicarPagoAsync(int idCliente, decimal montoAbonado)
        {
            if (montoAbonado <= 0)
            {
                MessageBox.Show("El monto a abonar debe ser mayor a 0.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                return await _ventaRepository.AplicarPagoAsync(idCliente, montoAbonado);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al aplicar el pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Cambia el estado de una venta.
        /// </summary>
        public async Task<bool> CambiarEstadoVentaAsync(int idVenta, string nuevoEstado)
        {
            if (string.IsNullOrWhiteSpace(nuevoEstado) ||
                (nuevoEstado != "Pendiente" && nuevoEstado != "Pagado" && nuevoEstado != "Cancelado"))
            {
                MessageBox.Show("Estado inválido. Debe ser 'Pendiente', 'Pagado' o 'Cancelado'.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                return await _ventaRepository.CambiarEstadoVentaAsync(idVenta, nuevoEstado);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar estado de venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Obtiene los detalles de una venta específica.
        /// </summary>
        public async Task<List<DetalleVenta>> ObtenerDetallesVentaAsync(int idVenta)
        {
            try
            {
                return await _ventaRepository.ObtenerDetallesPorVentaAsync(idVenta);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener detalles de la venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<DetalleVenta>();
            }
        }

        /// <summary>
        /// Valida los datos de una venta antes de registrarla.
        /// </summary>
        private bool ValidarVenta(Venta venta, List<DetalleVenta> detalles)
        {
            if (venta.IDCliente <= 0)
            {
                MessageBox.Show("El cliente es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (venta.TotalVenta <= 0)
            {
                MessageBox.Show("El total de la venta debe ser mayor a 0.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(venta.TipoVenta) || (venta.TipoVenta != "Contado" && venta.TipoVenta != "Crédito"))
            {
                MessageBox.Show("El tipo de pago debe ser 'Contado' o 'Crédito'.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (venta.TipoVenta == "Crédito" && venta.FechaEstimadaPago == null)
            {
                MessageBox.Show("Para ventas a crédito, debe ingresar una fecha estimada de pago.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (detalles == null || detalles.Count == 0)
            {
                MessageBox.Show("Debe haber al menos un producto en la venta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
