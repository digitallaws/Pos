using Microsoft.Data.SqlClient;
using Sopromil.Data.Interfaces;
using Sopromil.Modelo;
using System.Data;

namespace Sopromil.Data.Repository
{
    public class CreditoRepository : ICreditoRepository
    {
        public async Task RegistrarCreditoAsync(Credito credito)
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

        public async Task RegistrarPagoAsync(int idCredito, decimal montoPagado, decimal interesAplicado)
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

        public async Task<decimal> ObtenerSaldoPendienteAsync(int? idCliente, string documento = null)
        {
            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("sp_ObtenerSaldoPendienteCliente", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDCliente", (object)idCliente ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Documento", (object)documento ?? DBNull.Value);

                    object result = await command.ExecuteScalarAsync();
                    return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                }
            }
        }

        public async Task<List<Credito>> ObtenerCreditosActivosAsync(int? idCliente, string documento = null)
        {
            var lista = new List<Credito>();

            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("sp_ObtenerCreditosActivosCliente", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDCliente", (object)idCliente ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Documento", (object)documento ?? DBNull.Value);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            lista.Add(new Credito
                            {
                                IDCredito = reader.GetInt32(0),
                                FechaRegistro = reader.GetDateTime(1),
                                FechaVencimiento = reader.GetDateTime(2),
                                Total = reader.GetDecimal(3),
                                Saldo = reader.GetDecimal(4),
                                Estado = reader.GetString(5)
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<PagoCredito>> ObtenerPagosCreditoAsync(int idCredito)
        {
            var lista = new List<PagoCredito>();

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
                                IDPago = reader.GetInt32(0),
                                FechaPago = reader.GetDateTime(1),
                                MontoPagado = reader.GetDecimal(2),
                                InteresAplicado = reader.GetDecimal(3)
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public async Task CancelarCreditoAsync(int idCredito)
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

        public async Task ActualizarSaldoCreditoAsync(int idCliente, decimal monto)
        {
            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("sp_ActualizarSaldoCredito", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDCliente", idCliente);
                    command.Parameters.AddWithValue("@Monto", monto);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

    }
}
