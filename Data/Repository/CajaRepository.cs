using Microsoft.Data.SqlClient;
using Sopromil.Data.Interfaces;
using Sopromil.Modelo;
using System.Data;

namespace Sopromil.Data.Repository
{
    public class CajaRepository : ICajaRepository
    {
        public async Task<int> AbrirCajaAsync(int idUsuarioApertura, decimal saldoInicial)
        {
            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("sp_AbrirCaja", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDUsuarioApertura", idUsuarioApertura);
                    command.Parameters.AddWithValue("@SaldoInicial", saldoInicial);

                    SqlParameter outputId = new SqlParameter("@IDMovimiento", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    command.Parameters.Add(outputId);

                    await command.ExecuteNonQueryAsync();
                    return (int)outputId.Value;
                }
            }
        }

        public async Task CerrarCajaAsync(int idMovimiento, int idUsuarioCierre, decimal saldoFinal)
        {
            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("sp_CerrarCaja", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDMovimiento", idMovimiento);
                    command.Parameters.AddWithValue("@IDUsuarioCierre", idUsuarioCierre);
                    command.Parameters.AddWithValue("@SaldoFinal", saldoFinal);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<decimal> CalcularVentasDesdeAperturaCajaAsync()
        {
            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("sp_CalcularVentasDesdeAperturaCaja", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    object result = await command.ExecuteScalarAsync();

                    return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                }
            }
        }


        public async Task<MovimientoCaja> ObtenerCajaAbiertaAsync()
        {
            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("sp_ObtenerCajaAbierta", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new MovimientoCaja
                            {
                                IDMovimiento = reader.GetInt32(reader.GetOrdinal("IDMovimiento")),
                                IDUsuarioApertura = reader.GetInt32(reader.GetOrdinal("IDUsuarioApertura")),
                                FechaApertura = reader.GetDateTime(reader.GetOrdinal("FechaApertura")),
                                SaldoInicial = reader.GetDecimal(reader.GetOrdinal("SaldoInicial")),
                                IDUsuarioCierre = reader.IsDBNull(reader.GetOrdinal("IDUsuarioCierre")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IDUsuarioCierre")),
                                FechaCierre = reader.IsDBNull(reader.GetOrdinal("FechaCierre")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaCierre")),
                                SaldoFinal = reader.IsDBNull(reader.GetOrdinal("SaldoFinal")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("SaldoFinal")),
                                Descuadre = reader.IsDBNull(reader.GetOrdinal("Descuadre")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("Descuadre")),
                                Estado = reader.GetString(reader.GetOrdinal("Estado"))
                            };
                        }
                    }
                }
            }
            return null;
        }

        public async Task<string> ObtenerImpresoraAsync()
        {
            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("sp_ObtenerImpresora", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    object result = await command.ExecuteScalarAsync();
                    return result != null ? result.ToString() : "IMPRESORA NO CONFIGURADA";
                }
            }
        }
    }
}
