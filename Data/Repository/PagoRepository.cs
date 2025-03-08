using Microsoft.Data.SqlClient;
using Sopromil.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Sopromil.Data.Repository
{
    public class PagoRepository
    {
        private async Task<SqlConnection> GetConnectionAsync()
        {
            var connection = ConexionBD.ObtenerConexion();
            await connection.OpenAsync();
            return connection;
        }

        public async Task<int> AplicarPagoFacturaAsync(int idCliente, decimal montoAbonado)
        {
            int idPago = 0;

            try
            {
                using (var connection = await GetConnectionAsync())
                using (var command = new SqlCommand("AplicarPagoFactura", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDCliente", idCliente);
                    command.Parameters.AddWithValue("@MontoAbonado", montoAbonado);

                    var outputParam = new SqlParameter("@IDPago", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    command.Parameters.Add(outputParam);

                    await command.ExecuteNonQueryAsync();
                    idPago = (int)outputParam.Value;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al aplicar el pago: {ex.Message}");
                throw new Exception("Error al aplicar el pago.");
            }

            return idPago;
        }

        public async Task<decimal> ObtenerSaldoPendienteAsync(int idCliente)
        {
            decimal saldoPendiente = 0;

            try
            {
                using (var connection = await GetConnectionAsync())
                using (var command = new SqlCommand("ObtenerSaldoPendientePorCliente", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDCliente", idCliente);

                    var result = await command.ExecuteScalarAsync();
                    saldoPendiente = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al obtener el saldo pendiente: {ex.Message}");
            }

            return saldoPendiente;
        }


        public async Task<List<Pago>> ObtenerAbonosPorClienteAsync(int idCliente)
        {
            var abonos = new List<Pago>();

            try
            {
                using (var connection = await GetConnectionAsync())
                using (var command = new SqlCommand("ObtenerAbonosPorCliente", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDCliente", idCliente);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            abonos.Add(new Pago
                            {
                                IDPago = reader.GetInt32(reader.GetOrdinal("IDPago")),
                                FechaPago = reader.GetDateTime(reader.GetOrdinal("FechaPago")),
                                MontoAbonado = reader.GetDecimal(reader.GetOrdinal("MontoAbonado"))
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al obtener los abonos: {ex.Message}");
                throw new Exception("Error al obtener los abonos.");
            }

            return abonos;
        }
    }
}
