using Sopromil.Data.Repository;
using Sopromil.Modelo;
using System.Text.RegularExpressions;

namespace Sopromil.Controlador
{
    public class ClienteController
    {
        private readonly ClienteRepository _clienteRepository;

        public ClienteController()
        {
            _clienteRepository = new ClienteRepository();
        }

        public async Task<int> CrearClienteAsync(string nombre, string documento, string telefono)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del cliente es obligatorio.");

            var cliente = new Cliente
            {
                Nombre = nombre.Trim(),
                Documento = string.IsNullOrWhiteSpace(documento) ? null : documento.Trim(),
                Telefono = string.IsNullOrWhiteSpace(telefono) ? null : telefono.Trim(),
                Estado = "Activo"
            };

            return await _clienteRepository.CrearClienteAsync(cliente);
        }

        /// <summary>
        /// Obtiene la lista de clientes (opción de solo activos).
        /// </summary>
        public async Task<List<Cliente>> ObtenerClientesAsync(bool soloActivos = true)
        {
            try
            {
                return await _clienteRepository.ObtenerClientesAsync(soloActivos);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Cliente>();
            }
        }

        /// <summary>
        /// Busca clientes por nombre o documento.
        /// </summary>
        public async Task<List<Cliente>> BuscarClientesAsync(string filtro)
        {
            if (string.IsNullOrWhiteSpace(filtro))
            {
                MessageBox.Show("Debe ingresar un criterio de búsqueda.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return new List<Cliente>();
            }

            try
            {
                return await _clienteRepository.BuscarClientesAsync(filtro);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Cliente>();
            }
        }

        /// <summary>
        /// Inserta un nuevo cliente después de validar los datos.
        /// </summary>
        public async Task InsertarClienteAsync(Cliente cliente)
        {
            if (!ValidarCliente(cliente)) return;

            try
            {
                await _clienteRepository.InsertarClienteAsync(cliente);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al insertar cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Actualiza un cliente después de validar los datos.
        /// </summary>
        public async Task ActualizarClienteAsync(Cliente cliente)
        {
            if (!ValidarCliente(cliente, esActualizacion: true)) return;

            try
            {
                await _clienteRepository.ActualizarClienteAsync(cliente);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cambia el estado de un cliente (Activo/Inactivo).
        /// </summary>
        public async Task CambiarEstadoClienteAsync(int idCliente, string nuevoEstado)
        {
            if (string.IsNullOrWhiteSpace(nuevoEstado) || (nuevoEstado != "Activo" && nuevoEstado != "Inactivo"))
            {
                MessageBox.Show("El estado debe ser 'Activo' o 'Inactivo'.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                await _clienteRepository.CambiarEstadoClienteAsync(idCliente, nuevoEstado);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar el estado del cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Valida los datos del cliente antes de insertarlo o actualizarlo.
        /// </summary>
        private bool ValidarCliente(Cliente cliente, bool esActualizacion = false)
        {
            if (esActualizacion && cliente.IDCliente <= 0)
            {
                MessageBox.Show("El ID del cliente es inválido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(cliente.Documento))
            {
                MessageBox.Show("El documento del cliente es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(cliente.Nombre))
            {
                MessageBox.Show("El nombre del cliente es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!string.IsNullOrWhiteSpace(cliente.Telefono) && !Regex.IsMatch(cliente.Telefono, @"^\d+$"))
            {
                MessageBox.Show("El teléfono solo puede contener números.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
