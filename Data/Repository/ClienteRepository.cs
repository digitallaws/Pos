using Microsoft.Data.SqlClient;
using Sopromil.Data.Interfaces;
using Sopromil.Modelo;
using System.Data;

namespace Sopromil.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        public async Task<int> CrearClienteAsync(Cliente cliente)
        {
            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("CrearCliente", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    command.Parameters.AddWithValue("@IdentificadorFiscal", cliente.IdentificadorFiscal);
                    command.Parameters.AddWithValue("@Celular", cliente.Celular);
                    command.Parameters.AddWithValue("@Estado", cliente.Estado);

                    return Convert.ToInt32(await command.ExecuteScalarAsync());
                }
            }
        }

        public async Task<List<Cliente>> ObtenerClientesAsync()
        {
            var clientes = new List<Cliente>();

            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("ObtenerClientes", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            clientes.Add(new Cliente
                            {
                                IDCliente = reader.GetInt32(reader.GetOrdinal("IDCliente")),
                                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                IdentificadorFiscal = reader.GetString(reader.GetOrdinal("IdentificadorFiscal")),
                                Celular = reader.GetString(reader.GetOrdinal("Celular")),
                                Estado = reader.GetString(reader.GetOrdinal("Estado"))
                            });
                        }
                    }
                }
            }

            return clientes;
        }

        public async Task<Cliente> ObtenerClientePorIDAsync(int idCliente)
        {
            Cliente cliente = null;

            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("ObtenerClientePorID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDCliente", idCliente);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            cliente = new Cliente
                            {
                                IDCliente = reader.GetInt32(reader.GetOrdinal("IDCliente")),
                                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                IdentificadorFiscal = reader.GetString(reader.GetOrdinal("IdentificadorFiscal")),
                                Celular = reader.GetString(reader.GetOrdinal("Celular")),
                                Estado = reader.GetString(reader.GetOrdinal("Estado"))
                            };
                        }
                    }
                }
            }

            return cliente;
        }

        public async Task ActualizarClienteAsync(Cliente cliente)
        {
            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("ActualizarCliente", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDCliente", cliente.IDCliente);
                    command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    command.Parameters.AddWithValue("@IdentificadorFiscal", cliente.IdentificadorFiscal);
                    command.Parameters.AddWithValue("@Celular", cliente.Celular);
                    command.Parameters.AddWithValue("@Estado", cliente.Estado);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task CambiarEstadoClienteAsync(int idCliente, string estado)
        {
            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("CambiarEstadoCliente", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDCliente", idCliente);
                    command.Parameters.AddWithValue("@Estado", estado);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
