using Microsoft.Data.SqlClient;
using Sopromil.Modelo;
using System.Data;

namespace Sopromil.Data.Repository
{
    public class ClienteRepository
    {
        private async Task<SqlConnection> GetConnectionAsync()
        {
            var connection = ConexionBD.ObtenerConexion();
            await connection.OpenAsync();
            return connection;
        }

        /// <summary>
        /// Inserta un nuevo cliente en la base de datos.
        /// </summary>
        public async Task InsertarClienteAsync(Cliente cliente)
        {
            try
            {
                using (var connection = await GetConnectionAsync())
                using (var command = new SqlCommand("InsertarCliente", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Documento", cliente.Documento);
                    command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    command.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                    command.Parameters.AddWithValue("@Estado", cliente.Estado);

                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al insertar cliente: {ex.Message}");
            }
        }

        public async Task<int> CrearClienteAsync(Cliente cliente)
        {
            try
            {
                using (var connection = await GetConnectionAsync())
                using (var command = new SqlCommand("CrearCliente", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    command.Parameters.AddWithValue("@Documento", (object)cliente.Documento ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Telefono", (object)cliente.Telefono ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Estado", cliente.Estado ?? "Activo");

                    var idClienteParam = new SqlParameter("@IDCliente", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    command.Parameters.Add(idClienteParam);

                    await command.ExecuteNonQueryAsync();

                    return (int)idClienteParam.Value;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al crear cliente: {ex.Message}");
                throw new Exception("Error al registrar el cliente.");
            }
        }

        public async Task<List<Cliente>> ObtenerClientesAsync(bool soloActivos = true)
        {
            var clientes = new List<Cliente>();

            try
            {
                using (var connection = await GetConnectionAsync())
                using (var command = new SqlCommand("ObtenerClientes", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SoloActivos", soloActivos);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            clientes.Add(new Cliente
                            {
                                IDCliente = reader.GetInt32(reader.GetOrdinal("IDCliente")),
                                Documento = reader.GetString(reader.GetOrdinal("Documento")),
                                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                Telefono = reader.GetString(reader.GetOrdinal("Telefono")),
                                Estado = reader.GetString(reader.GetOrdinal("Estado"))
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al obtener clientes: {ex.Message}");
            }

            return clientes;
        }

        /// <summary>
        /// Busca clientes por nombre o documento.
        /// </summary>
        public async Task<List<Cliente>> BuscarClientesAsync(string filtro)
        {
            var clientes = new List<Cliente>();

            try
            {
                using (var connection = await GetConnectionAsync())
                using (var command = new SqlCommand("BuscarClientes", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Filtro", filtro);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            clientes.Add(new Cliente
                            {
                                IDCliente = reader.GetInt32(reader.GetOrdinal("IDCliente")),
                                Documento = reader.GetString(reader.GetOrdinal("Documento")),
                                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                Telefono = reader.GetString(reader.GetOrdinal("Telefono")),
                                Estado = reader.GetString(reader.GetOrdinal("Estado"))
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al buscar clientes: {ex.Message}");
            }

            return clientes;
        }

        /// <summary>
        /// Actualiza los datos de un cliente.
        /// </summary>
        public async Task ActualizarClienteAsync(Cliente cliente)
        {
            try
            {
                using (var connection = await GetConnectionAsync())
                using (var command = new SqlCommand("ActualizarCliente", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDCliente", cliente.IDCliente);
                    command.Parameters.AddWithValue("@Documento", cliente.Documento);
                    command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    command.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                    command.Parameters.AddWithValue("@Estado", cliente.Estado);

                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al actualizar cliente: {ex.Message}");
            }
        }

        /// <summary>
        /// Cambia el estado de un cliente (Activo/Inactivo).
        /// </summary>
        public async Task CambiarEstadoClienteAsync(int idCliente, string nuevoEstado)
        {
            try
            {
                using (var connection = await GetConnectionAsync())
                using (var command = new SqlCommand("CambiarEstadoCliente", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDCliente", idCliente);
                    command.Parameters.AddWithValue("@NuevoEstado", nuevoEstado);

                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al cambiar estado del cliente: {ex.Message}");
            }
        }
    }
}
