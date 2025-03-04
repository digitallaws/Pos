using Microsoft.Data.SqlClient;
using Sopromil.Data.Interfaces;
using Sopromil.Modelo;
using System.Data;

namespace Sopromil.Data.Repository
{
    public class CajaRepository : ICajaRepository
    {
        public async Task<decimal> CalcularVentasDesdeAperturaCajaAsync()
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception("Error al calcular ventas desde apertura.", ex);
            }
        }

        public async Task<int> AbrirCajaAsync(int idUsuarioApertura, decimal saldoInicial)
        {
            try
            {
                using (var connection = ConexionBD.ObtenerConexion())
                {
                    await connection.OpenAsync();
                    using (var command = new SqlCommand("sp_AbrirCaja", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@IDUsuarioApertura", idUsuarioApertura);
                        command.Parameters.AddWithValue("@SaldoInicial", saldoInicial);

                        var outputId = new SqlParameter("@IDMovimiento", SqlDbType.Int) { Direction = ParameterDirection.Output };
                        command.Parameters.Add(outputId);

                        await command.ExecuteNonQueryAsync();
                        return (int)outputId.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al abrir la caja.", ex);
            }
        }

        public async Task CerrarCajaAsync(int idMovimiento, int idUsuarioCierre, decimal saldoFinal)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception("Error al cerrar la caja.", ex);
            }
        }

        public async Task<MovimientoCaja> ObtenerCajaAbiertaAsync()
        {
            try
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
                                    Estado = reader.GetString(reader.GetOrdinal("Estado"))
                                };
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la caja abierta.", ex);
            }
        }

        public async Task RegistrarMovimientoExtraAsync(int idMovimiento, string tipo, decimal monto, string descripcion)
        {
            try
            {
                using (var connection = ConexionBD.ObtenerConexion())
                {
                    await connection.OpenAsync();
                    using (var command = new SqlCommand("sp_RegistrarMovimientoExtra", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@IDMovimiento", idMovimiento);
                        command.Parameters.AddWithValue("@TipoMovimiento", tipo);
                        command.Parameters.AddWithValue("@Monto", monto);
                        command.Parameters.AddWithValue("@Descripcion", descripcion);

                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar movimiento extra.", ex);
            }
        }

        public async Task<decimal> CalcularMovimientosExtraDesdeAperturaAsync()
        {
            try
            {
                using (var connection = ConexionBD.ObtenerConexion())
                {
                    await connection.OpenAsync();
                    using (var command = new SqlCommand("sp_CalcularMovimientosExtraDesdeApertura", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        object result = await command.ExecuteScalarAsync();
                        return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al calcular movimientos extra.", ex);
            }
        }

        public async Task<List<MovimientoCajaDetalle>> ObtenerMovimientosExtraDeCajaAsync(int idMovimiento)
        {
            var movimientos = new List<MovimientoCajaDetalle>();

            try
            {
                using (var connection = ConexionBD.ObtenerConexion())
                {
                    await connection.OpenAsync();
                    using (var command = new SqlCommand("SELECT * FROM MovimientosCajaDetalle WHERE IDMovimiento = @IDMovimiento", connection))
                    {
                        command.Parameters.AddWithValue("@IDMovimiento", idMovimiento);

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                movimientos.Add(new MovimientoCajaDetalle
                                {
                                    IDDetalleMovimiento = reader.GetInt32(reader.GetOrdinal("IDDetalleMovimiento")),
                                    IDMovimiento = reader.GetInt32(reader.GetOrdinal("IDMovimiento")),
                                    TipoMovimiento = reader.GetString(reader.GetOrdinal("TipoMovimiento")),
                                    Monto = reader.GetDecimal(reader.GetOrdinal("Monto")),
                                    Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                                    FechaRegistro = reader.GetDateTime(reader.GetOrdinal("FechaRegistro"))
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener movimientos extra.", ex);
            }

            return movimientos;
        }

        public async Task<string> ObtenerImpresoraAsync()
        {
            try
            {
                using (var connection = ConexionBD.ObtenerConexion())
                {
                    await connection.OpenAsync();
                    using (var command = new SqlCommand("sp_ObtenerImpresora", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        object result = await command.ExecuteScalarAsync();
                        return result?.ToString() ?? "IMPRESORA NO CONFIGURADA";
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la impresora.", ex);
            }
        }
    }
}
