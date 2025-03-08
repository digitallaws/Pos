using Sopromil.Data.Repository;
using Sopromil.Modelo;
using System.Text.RegularExpressions;

namespace Sopromil.Controlador
{
    public class ProveedorController
    {
        private readonly ProveedorRepository _proveedorRepository;

        public ProveedorController()
        {
            _proveedorRepository = new ProveedorRepository();
        }

        // Obtener proveedores
        public async Task<List<Proveedor>> ObtenerProveedoresAsync(bool soloActivos = false)
        {
            try
            {
                return await _proveedorRepository.ObtenerProveedoresAsync(soloActivos);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener proveedores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Proveedor>();
            }
        }

        // Crear proveedor
        public async Task CrearProveedorAsync(Proveedor proveedor)
        {
            if (!ValidarProveedor(proveedor)) return;

            try
            {
                await _proveedorRepository.CrearProveedorAsync(proveedor);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear proveedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Actualizar proveedor
        public async Task ActualizarProveedorAsync(Proveedor proveedor)
        {
            if (!ValidarProveedor(proveedor, esActualizacion: true)) return;

            try
            {
                await _proveedorRepository.ActualizarProveedorAsync(proveedor);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar proveedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cambiar estado (Activo/Inactivo)
        public async Task CambiarEstadoProveedorAsync(int idProveedor, string nuevoEstado)
        {
            if (string.IsNullOrWhiteSpace(nuevoEstado) || (nuevoEstado != "Activo" && nuevoEstado != "Inactivo"))
            {
                MessageBox.Show("El estado debe ser 'Activo' o 'Inactivo'.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                await _proveedorRepository.CambiarEstadoProveedorAsync(idProveedor, nuevoEstado);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar el estado del proveedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Eliminar proveedor lógicamente
        public async Task EliminarProveedorAsync(int idProveedor)
        {
            try
            {
                await _proveedorRepository.EliminarProveedorLogicoAsync(idProveedor);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar proveedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Validar datos del proveedor antes de insertar/actualizar
        private bool ValidarProveedor(Proveedor proveedor, bool esActualizacion = false)
        {
            if (esActualizacion && proveedor.IDProveedor <= 0)
            {
                MessageBox.Show("El ID del proveedor es inválido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(proveedor.Nombre))
            {
                MessageBox.Show("El nombre del proveedor es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!string.IsNullOrWhiteSpace(proveedor.Telefono) && !Regex.IsMatch(proveedor.Telefono, @"^\d+$"))
            {
                MessageBox.Show("El teléfono solo puede contener números.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
