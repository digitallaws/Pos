using Microsoft.Data.SqlClient;
using Sopromil.Modelo;
using System.Data;

namespace Sopromil.Data.Repository
{
    public class CajaRepository
    {

        private async Task<SqlConnection> GetConnectionAsync()
        {
            var connection = ConexionBD.ObtenerConexion();
            await connection.OpenAsync();
            return connection;
        }
        public async Task<int> AbrirCajaAsync(int idUsuarioApertura, decimal saldoInicial)
        {
            try
            {
                using (var connection = ConexionBD.ObtenerConexion())
                {
                    await connection.OpenAsync();

                    using (var command = new SqlCommand("AbrirCaja", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@IDUsuarioApertura", idUsuarioApertura);
                        command.Parameters.AddWithValue("@SaldoInicial", saldoInicial);

                        return Convert.ToInt32(await command.ExecuteScalarAsync());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al abrir caja: {ex.Message}");
                return 0;
            }
        }

        public async Task<bool> CerrarCajaAsync(int idMovimiento, int idUsuarioCierre, decimal saldoFinal, decimal descuadre, string observaciones)
        {
            try
            {
                using (var connection = ConexionBD.ObtenerConexion())
                {
                    await connection.OpenAsync();

                    using (var command = new SqlCommand("CerrarCaja", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@IDMovimiento", idMovimiento);
                        command.Parameters.AddWithValue("@IDUsuarioCierre", idUsuarioCierre);
                        command.Parameters.AddWithValue("@SaldoFinal", saldoFinal);
                        command.Parameters.AddWithValue("@Descuadre", descuadre);
                        command.Parameters.AddWithValue("@Observaciones", observaciones ?? (object)DBNull.Value);

                        await command.ExecuteNonQueryAsync();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cerrar caja: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> RegistrarMovimientoExtraAsync(int idMovimiento, string tipoMovimiento, decimal monto, string descripcion)
        {
            try
            {
                using (var connection = ConexionBD.ObtenerConexion())
                {
                    await connection.OpenAsync();

                    using (var command = new SqlCommand("RegistrarMovimientoCajaDetalle", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@IDMovimiento", idMovimiento);
                        command.Parameters.AddWithValue("@TipoMovimiento", tipoMovimiento);
                        command.Parameters.AddWithValue("@Monto", monto);
                        command.Parameters.AddWithValue("@Descripcion", descripcion);

                        await command.ExecuteNonQueryAsync();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar movimiento extra: {ex.Message}");
                return false;
            }
        }

        public async Task<MovimientoCaja?> ObtenerCajaAbiertaAsync()
        {
            try
            {
                using (var connection = ConexionBD.ObtenerConexion())
                {
                    await connection.OpenAsync();

                    using (var command = new SqlCommand("ObtenerCajaAbierta", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new MovimientoCaja
                                {
                                    IDMovimiento = reader.GetInt32("IDMovimiento"),
                                    SaldoInicial = reader.GetDecimal("SaldoInicial"),
                                    FechaApertura = reader.GetDateTime("FechaApertura")
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener caja abierta: {ex.Message}");
            }
            return null;
        }

        public async Task<List<MovimientoCajaDetalle>> ObtenerMovimientosDetalleAsync(int idMovimiento)
        {
            var detalles = new List<MovimientoCajaDetalle>();

            try
            {
                using (var connection = ConexionBD.ObtenerConexion())
                {
                    await connection.OpenAsync();

                    using (var command = new SqlCommand("ObtenerMovimientosCajaDetalle", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@IDMovimiento", idMovimiento);

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                detalles.Add(new MovimientoCajaDetalle
                                {
                                    IDDetalleMovimiento = reader.GetInt32("IDDetalleMovimiento"),
                                    TipoMovimiento = reader.GetString("TipoMovimiento"),
                                    Monto = reader.GetDecimal("Monto"),
                                    Descripcion = reader.GetString("Descripcion"),
                                    FechaRegistro = reader.GetDateTime("FechaRegistro")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener movimientos detalle: {ex.Message}");
            }

            return detalles;
        }

        public async Task<decimal> CalcularVentasDesdeAperturaCajaAsync()
        {
            try
            {
                using (var connection = ConexionBD.ObtenerConexion())
                {
                    await connection.OpenAsync();

                    using (var command = new SqlCommand("CalcularVentasDesdeApertura", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        var resultado = await command.ExecuteScalarAsync();
                        return resultado != DBNull.Value ? Convert.ToDecimal(resultado) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al calcular ventas desde apertura: {ex.Message}");
                return 0;
            }
        }

        public async Task<decimal> CalcularVentasCreditoDesdeAperturaAsync()
        {
            try
            {
                using (var connection = ConexionBD.ObtenerConexion())
                {
                    await connection.OpenAsync();

                    using (var command = new SqlCommand("CalcularVentasCreditoDesdeApertura", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        var resultado = await command.ExecuteScalarAsync();
                        return resultado != DBNull.Value ? Convert.ToDecimal(resultado) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al calcular ventas a crédito desde apertura: {ex.Message}");
                return 0;
            }
        }

        public async Task<decimal> CalcularMovimientosExtraDesdeAperturaAsync()
        {
            try
            {
                using (var connection = ConexionBD.ObtenerConexion())
                {
                    await connection.OpenAsync();

                    using (var command = new SqlCommand("CalcularMovimientosExtraDesdeApertura", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        var resultado = await command.ExecuteScalarAsync();
                        return resultado != DBNull.Value ? Convert.ToDecimal(resultado) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al calcular movimientos extra: {ex.Message}");
                return 0;
            }
        }

        public async Task<bool> ConfigurarCajaAsync(string descripcion, string impresora, string copiaSeguridad, string estado, int idUsuario)
        {
            try
            {
                using (var connection = await GetConnectionAsync())
                using (var command = new SqlCommand("ConfigurarCaja", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // 🔹 Aseguramos que los valores nulos sean cadenas vacías
                    command.Parameters.AddWithValue("@Descripcion", string.IsNullOrWhiteSpace(descripcion) ? "" : descripcion);
                    command.Parameters.AddWithValue("@Impresora", string.IsNullOrWhiteSpace(impresora) ? "" : impresora);
                    command.Parameters.AddWithValue("@CopiaSeguridad", string.IsNullOrWhiteSpace(copiaSeguridad) ? "" : copiaSeguridad);
                    command.Parameters.AddWithValue("@Estado", string.IsNullOrWhiteSpace(estado) ? "" : estado);
                    command.Parameters.AddWithValue("@IDUsuario", idUsuario); // ✅ CAMBIO AQUÍ: Usar el nombre correcto

                    await command.ExecuteNonQueryAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al configurar la caja: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        /// <summary>
        /// Obtiene la configuración actual de la caja desde la base de datos.
        /// </summary>
        public async Task<Caja?> ObtenerConfiguracionCajaAsync()
        {
            try
            {
                using (var connection = await GetConnectionAsync())
                using (var command = new SqlCommand("ObtenerConfiguracionCaja", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Caja
                            {
                                IDCaja = reader.GetInt32(reader.GetOrdinal("IDCaja")),
                                Descripcion = reader.IsDBNull(reader.GetOrdinal("Descripcion")) ? "" : reader.GetString(reader.GetOrdinal("Descripcion")),
                                Impresora = reader.IsDBNull(reader.GetOrdinal("Impresora")) ? "" : reader.GetString(reader.GetOrdinal("Impresora")),
                                CopiaSeguridad = reader.IsDBNull(reader.GetOrdinal("CopiaSeguridad")) ? "" : reader.GetString(reader.GetOrdinal("CopiaSeguridad")),
                                Estado = reader.IsDBNull(reader.GetOrdinal("Estado")) ? "" : reader.GetString(reader.GetOrdinal("Estado")),
                                UltimaConfiguracionPor = 1
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al obtener la configuración de la caja: {ex.Message}");
            }
            return null;
        }
    }
}
