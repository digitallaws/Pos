using Sopromil.Data.Repository;
using Sopromil.Modelo;

namespace Sopromil.Controlador
{
    public class HistorialPreciosController
    {
        private readonly HistorialPreciosRepository _historialRepository;

        public HistorialPreciosController()
        {
            _historialRepository = new HistorialPreciosRepository();
        }

        /// <summary>
        /// Registra un nuevo cambio de precio en el historial.
        /// </summary>
        public async Task RegistrarCambioPrecioAsync(HistorialPrecios historial)
        {
            if (!ValidarHistorial(historial)) return;

            try
            {
                await _historialRepository.RegistrarCambioPrecioAsync(historial);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar cambio de precio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Obtiene el historial de cambios de precios para un producto específico.
        /// </summary>
        public async Task<List<HistorialPrecios>> ObtenerHistorialPorProductoAsync(int idProducto)
        {
            try
            {
                return await _historialRepository.ObtenerHistorialPorProductoAsync(idProducto);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener historial de precios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<HistorialPrecios>();
            }
        }

        /// <summary>
        /// Valida los datos del historial de precios antes de registrarlo.
        /// </summary>
        private bool ValidarHistorial(HistorialPrecios historial)
        {
            if (historial.IDProducto <= 0)
            {
                MessageBox.Show("El ID del producto no es válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (historial.PrecioCompraNuevo < 0 || historial.PrecioVentaNuevo < 0)
            {
                MessageBox.Show("Los precios no pueden ser negativos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(historial.Motivo))
            {
                MessageBox.Show("Debe especificar un motivo para el cambio de precio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
