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
                MessageBox.Show($"Error al obtener ventas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Venta>();
            }
        }

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

            if (detalles == null || detalles.Count == 0)
            {
                MessageBox.Show("Debe haber al menos un producto en la venta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
