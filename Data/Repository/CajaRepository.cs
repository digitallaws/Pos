using Microsoft.Data.SqlClient;
using Sopromil.Modelo;
using System.Data;

namespace Sopromil.Data.Repository
{
    public class CajaRepository
    {
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

        public async Task<bool> ConfigurarCajaAsync(string descripcion, string impresora, string copiaSeguridad, string estado, int idUsuario)
        {
            try
            {
                using (var connection = ConexionBD.ObtenerConexion())
                {
                    await connection.OpenAsync();

                    using (var command = new SqlCommand("ConfigurarCaja", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Descripcion", descripcion);
                        command.Parameters.AddWithValue("@Impresora", impresora);
                        command.Parameters.AddWithValue("@CopiaSeguridad", copiaSeguridad);
                        command.Parameters.AddWithValue("@Estado", estado);
                        command.Parameters.AddWithValue("@IDUsuario", idUsuario);

                        await command.ExecuteNonQueryAsync();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al configurar caja: {ex.Message}");
                return false;
            }
        }

        public async Task<Caja?> ObtenerConfiguracionCajaAsync()
        {
            try
            {
                using (var connection = ConexionBD.ObtenerConexion())
                {
                    await connection.OpenAsync();

                    using (var command = new SqlCommand("ObtenerConfiguracionCaja", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new Caja
                                {
                                    Descripcion = reader.GetString("Descripcion"),
                                    Impresora = reader.GetString("Impresora"),
                                    CopiaSeguridad = reader.GetString("CopiaSeguridad"),
                                    Estado = reader.GetString("Estado")
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener configuración caja: {ex.Message}");
            }
            return null;
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
        public async Task<bool> ActualizarConfiguracionImpresoraYCopiaAsync(string impresora, string copiaSeguridad)
        {
            try
            {
                using (var connection = ConexionBD.ObtenerConexion())
                {
                    await connection.OpenAsync();

                    using (var command = new SqlCommand("ConfigurarCaja", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Mete la info por defecto o actualiza si ya hay algo, pero siempre lo mete
                        command.Parameters.AddWithValue("@Descripcion", "Caja Principal");
                        command.Parameters.AddWithValue("@Impresora", impresora);
                        command.Parameters.AddWithValue("@CopiaSeguridad", copiaSeguridad);
                        command.Parameters.AddWithValue("@Estado", "Activa");
                        command.Parameters.AddWithValue("@IDUsuario", 1);  // O el usuario que tengas logueado, si aplica

                        var rowsAffected = await command.ExecuteNonQueryAsync();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al forzar la configuración de la caja (impresora y copia): {ex.Message}");
                return false;
            }
        }
    }
}
