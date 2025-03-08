using Sopromil.Data.Repository;
using Sopromil.Modelo;

namespace Sopromil.Controlador
{
    public class CompraController
    {
        private readonly CompraRepository _compraRepository;

        public CompraController()
        {
            _compraRepository = new CompraRepository();
        }

        public async Task<List<Compra>> ObtenerComprasAsync()
        {
            try
            {
                return await _compraRepository.ObtenerComprasAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener compras: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Compra>();
            }
        }

        public async Task<int> RegistrarCompraAsync(Compra compra, List<DetalleCompra> detalles)
        {
            try
            {
                if (!ValidarCompra(compra, detalles)) return 0;

                int idCompra = await _compraRepository.RegistrarCompraAsync(compra, detalles);
                return idCompra;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar compra: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public async Task<List<DetalleCompra>> ObtenerDetallesCompraAsync(int idCompra)
        {
            try
            {
                return await _compraRepository.ObtenerDetallesPorCompraAsync(idCompra);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener detalles de la compra: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<DetalleCompra>();
            }
        }

        private bool ValidarCompra(Compra compra, List<DetalleCompra> detalles)
        {
            if (compra.IDProveedor <= 0)
            {
                MessageBox.Show("Debe seleccionar un proveedor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (compra.TotalCompra <= 0)
            {
                MessageBox.Show("El total de la compra debe ser mayor a 0.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (detalles == null || detalles.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto a la compra.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        public async Task<List<Compra>> ObtenerFacturasPorProveedorAsync(int idProveedor)
        {
            try
            {
                return await _compraRepository.ObtenerFacturasPorProveedorAsync(idProveedor);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener facturas del proveedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Compra>();
            }
        }

    }
}
