using Sopromil.Data.Interfaces;
using Sopromil.Data.Repository;
using Sopromil.Modelo;

namespace Sopromil.Controlador
{
    public class DashboardController
    {
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardController()
        {
            _dashboardRepository = new DashboardRepository();
        }

        // ✅ Obtener Ventas del Mes
        public async Task<decimal> ObtenerVentasDelMesAsync()
        {
            try
            {
                return await _dashboardRepository.ObtenerVentasDelMesAsync();
            }
            catch
            {
                MessageBox.Show("Error al obtener las ventas del mes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        // ✅ Obtener Ventas del Día
        public async Task<decimal> ObtenerVentasDelDiaAsync()
        {
            try
            {
                return await _dashboardRepository.ObtenerVentasDelDiaAsync();
            }
            catch
            {
                MessageBox.Show("Error al obtener las ventas del día.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        // ✅ Obtener Total Créditos Pendientes
        public async Task<decimal> ObtenerTotalCreditosPendientesAsync()
        {
            try
            {
                return await _dashboardRepository.ObtenerTotalCreditosPendientesAsync();
            }
            catch
            {
                MessageBox.Show("Error al obtener los créditos pendientes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        // ✅ Obtener Número de Productos por Vencer
        public async Task<int> ObtenerProductosPorVencerAsync()
        {
            try
            {
                return await _dashboardRepository.ObtenerProductosPorVencerAsync();
            }
            catch
            {
                MessageBox.Show("Error al obtener los productos por vencer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        // ✅ Obtener Detalle de Productos por Vencer
        public async Task<List<ProductoVencimiento>> ObtenerProductosPorVencerDetalleAsync()
        {
            try
            {
                return await _dashboardRepository.ObtenerProductosPorVencerDetalleAsync();
            }
            catch
            {
                MessageBox.Show("Error al obtener el detalle de productos por vencer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<ProductoVencimiento>();
            }
        }

        // ✅ Obtener Créditos Cercanos al Vencimiento
        public async Task<List<CreditoPendiente>> ObtenerCreditosCercanosVencimientoAsync()
        {
            try
            {
                return await _dashboardRepository.ObtenerCreditosCercanosVencimientoAsync();
            }
            catch
            {
                MessageBox.Show("Error al obtener los créditos cercanos al vencimiento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<CreditoPendiente>();
            }
        }
    }
}
