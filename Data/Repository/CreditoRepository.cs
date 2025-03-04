using Microsoft.Data.SqlClient;
using Sopromil.Data.Interfaces;
using Sopromil.Modelo;
using System.Data;

namespace Sopromil.Data.Repository
{
    public class CreditoRepository : ICreditoRepository
    {
        private async Task<T> EjecutarScalarAsync<T>(string procedimiento, SqlParameter[] parametros = null)
        {
            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand(procedimiento, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (parametros != null)
                        command.Parameters.AddRange(parametros);

                    object result = await command.ExecuteScalarAsync();
                    return (result != DBNull.Value && result != null) ? (T)Convert.ChangeType(result, typeof(T)) : default;
                }
            }
        }

        public async Task<bool> VerificarCreditoPendienteAsync(int idCliente)
        {
            try
            {
                var parametros = new[]
                {
                    new SqlParameter("@IDCliente", idCliente),
                    new SqlParameter("@TieneCreditoPendiente", SqlDbType.Bit) { Direction = ParameterDirection.Output }
                };

                await EjecutarScalarAsync<int>("sp_VerificarSiTieneCreditoPendiente", parametros);
                return Convert.ToBoolean(parametros[1].Value);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar créditos pendientes.", ex);
            }
        }

        public async Task RegistrarCreditoAsync(Credito credito)
        {
            try
            {
                using (var connection = ConexionBD.ObtenerConexion())
                {
                    await connection.OpenAsync();
                    using (var command = new SqlCommand("sp_RegistrarCredito", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@IDCliente", credito.IDCliente);
                        command.Parameters.AddWithValue("@FechaVencimiento", credito.FechaVencimiento);
                        command.Parameters.AddWithValue("@Total", credito.Total);
                        command.Parameters.AddWithValue("@AplicaInteres", credito.AplicaInteres);
                        command.Parameters.AddWithValue("@TasaInteres", credito.TasaInteres);

                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar el crédito.", ex);
            }
        }

        public async Task<List<Credito>> ObtenerCreditosActivosClienteAsync(int idCliente)
        {
            var lista = new List<Credito>();

            try
            {
                using (var connection = ConexionBD.ObtenerConexion())
                {
                    await connection.OpenAsync();
                    using (var command = new SqlCommand("sp_ObtenerCreditosActivosCliente", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@IDCliente", idCliente);

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                lista.Add(new Credito
                                {
                                    IDCredito = reader.GetInt32("IDCredito"),
                                    FechaRegistro = reader.GetDateTime("FechaRegistro"),
                                    FechaVencimiento = reader.GetDateTime("FechaVencimiento"),
                                    Total = reader.GetDecimal("Total"),
                                    Saldo = reader.GetDecimal("Saldo"),
                                    Estado = reader.GetString("Estado")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener créditos activos del cliente.", ex);
            }

            return lista;
        }

        public async Task<decimal> ObtenerSaldoPendienteClienteAsync(int idCliente)
        {
            try
            {
                var parametros = new[]
                {
                    new SqlParameter("@IDCliente", idCliente)
                };

                return await EjecutarScalarAsync<decimal>("sp_ObtenerSaldoPendienteCliente", parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el saldo pendiente del cliente.", ex);
            }
        }

        public async Task RegistrarPagoCreditoAsync(int idCredito, decimal montoPagado, decimal interesAplicado)
        {
            try
            {
                using (var connection = ConexionBD.ObtenerConexion())
                {
                    await connection.OpenAsync();
                    using (var command = new SqlCommand("sp_RegistrarPagoCredito", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@IDCredito", idCredito);
                        command.Parameters.AddWithValue("@MontoPagado", montoPagado);
                        command.Parameters.AddWithValue("@InteresAplicado", interesAplicado);

                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar el pago del crédito.", ex);
            }
        }

        public async Task<List<PagoCredito>> ObtenerPagosCreditoAsync(int idCredito)
        {
            var lista = new List<PagoCredito>();

            try
            {
                using (var connection = ConexionBD.ObtenerConexion())
                {
                    await connection.OpenAsync();
                    using (var command = new SqlCommand("sp_ObtenerPagosCredito", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@IDCredito", idCredito);

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                lista.Add(new PagoCredito
                                {
                                    IDPago = reader.GetInt32("IDPago"),
                                    FechaPago = reader.GetDateTime("FechaPago"),
                                    MontoPagado = reader.GetDecimal("MontoPagado"),
                                    InteresAplicado = reader.GetDecimal("InteresAplicado")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener pagos del crédito.", ex);
            }

            return lista;
        }

        public async Task CancelarCreditoAsync(int idCredito)
        {
            try
            {
                using (var connection = ConexionBD.ObtenerConexion())
                {
                    await connection.OpenAsync();
                    using (var command = new SqlCommand("sp_CancelarCredito", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@IDCredito", idCredito);

                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cancelar el crédito.", ex);
            }
        }

        public async Task<List<Credito>> ObtenerTodosLosCreditosActivosAsync()
        {
            var lista = new List<Credito>();

            try
            {
                using (var connection = ConexionBD.ObtenerConexion())
                {
                    await connection.OpenAsync();
                    using (var command = new SqlCommand("sp_ObtenerTodosLosCreditosActivos", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                lista.Add(new Credito
                                {
                                    IDCredito = reader.GetInt32("IDCredito"),
                                    IDCliente = reader.GetInt32("IDCliente"),
                                    FechaRegistro = reader.GetDateTime("FechaRegistro"),
                                    FechaVencimiento = reader.GetDateTime("FechaVencimiento"),
                                    Total = reader.GetDecimal("Total"),
                                    Saldo = reader.GetDecimal("Saldo"),
                                    Estado = reader.GetString("Estado")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener todos los créditos activos.", ex);
            }

            return lista;
        }

        public async Task ActualizarSaldoCreditoAsync(int idCliente, decimal monto)
        {
            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("sp_ActualizarSaldoCredito", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDCliente", idCliente);
                    command.Parameters.AddWithValue("@Monto", -monto);  // Monto negativo para restar

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

    }
}
