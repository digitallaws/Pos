using Microsoft.Data.SqlClient;
using Sopromil.Data.Interfaces;
using Sopromil.Modelo;
using System.Data;

namespace Sopromil.Data.Repository
{
    public class VentaRepository : IVentaRepository
    {
        public async Task<int> RegistrarVentaAsync(Venta venta)
        {
            try
            {
                using (var connection = ConexionBD.ObtenerConexion())
                {
                    await connection.OpenAsync();
                    using (var command = new SqlCommand("sp_RegistrarVenta", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@IDCliente", venta.IDCliente);
                        command.Parameters.AddWithValue("@MontoTotal", venta.MontoTotal);
                        command.Parameters.AddWithValue("@TipoPago", venta.TipoPago);
                        command.Parameters.AddWithValue("@IDUsuario", venta.IDUsuario);

                        SqlParameter outputId = new SqlParameter("@IDVenta", SqlDbType.Int) { Direction = ParameterDirection.Output };
                        command.Parameters.Add(outputId);

                        await command.ExecuteNonQueryAsync();
                        return (int)outputId.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(RegistrarVentaAsync));
                throw new Exception("Error al registrar la venta.", ex);
            }
        }

        public async Task DevolverProductosAsync(List<int> idDetallesVenta)
        {
            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        foreach (var idDetalle in idDetallesVenta)
                        {
                            using (var command = new SqlCommand("sp_DevolverProductos", connection, transaction))
                            {
                                command.CommandType = CommandType.StoredProcedure;
                                command.Parameters.AddWithValue("@IDDetalleVenta", idDetalle);

                                await command.ExecuteNonQueryAsync();
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error al devolver productos.", ex);
                    }
                }
            }
        }

        public async Task RegistrarDetalleVentaAsync(DetalleVenta detalle)
        {
            try
            {
                using (var connection = ConexionBD.ObtenerConexion())
                {
                    await connection.OpenAsync();
                    using (var command = new SqlCommand("sp_RegistrarDetalleVenta", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@IDVenta", detalle.IDVenta);
                        command.Parameters.AddWithValue("@IDProducto", detalle.IDProducto);
                        command.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                        command.Parameters.AddWithValue("@PrecioUnitario", detalle.PrecioUnitario);

                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(RegistrarDetalleVentaAsync));
                throw new Exception("Error al registrar el detalle de la venta.", ex);
            }
        }

        public async Task<List<Venta>> ObtenerVentasAsync()
        {
            var ventas = new List<Venta>();

            try
            {
                using (var connection = ConexionBD.ObtenerConexion())
                {
                    await connection.OpenAsync();
                    using (var command = new SqlCommand("sp_ObtenerVentas", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                ventas.Add(new Venta
                                {
                                    IDVenta = reader.GetInt32(reader.GetOrdinal("IDVenta")),
                                    FechaVenta = reader.GetDateTime(reader.GetOrdinal("FechaVenta")),
                                    MontoTotal = reader.GetDecimal(reader.GetOrdinal("MontoTotal")),
                                    TipoPago = reader.GetString(reader.GetOrdinal("TipoPago")),
                                    IDCliente = 0, // Esto solo si tu sp_ObtenerVentas no devuelve IDCliente, lo puedes ajustar
                                    IDUsuario = 0 // Igual para IDUsuario
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(ObtenerVentasAsync));
                throw new Exception("Error al obtener las ventas.", ex);
            }

            return ventas;
        }

        public async Task<List<DetalleVenta>> ObtenerDetalleVentaAsync(int idVenta)
        {
            var detalles = new List<DetalleVenta>();

            try
            {
                using (var connection = ConexionBD.ObtenerConexion())
                {
                    await connection.OpenAsync();
                    using (var command = new SqlCommand("sp_ObtenerDetalleVenta", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@IDVenta", idVenta);

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                detalles.Add(new DetalleVenta
                                {
                                    IDDetalleVenta = reader.GetInt32(reader.GetOrdinal("IDDetalleVenta")),
                                    IDVenta = idVenta,
                                    IDProducto = 0, // No lo devuelve el sp_ObtenerDetalleVenta
                                    DescripcionProducto = reader.GetString(reader.GetOrdinal("Producto")),
                                    Cantidad = reader.GetDecimal(reader.GetOrdinal("Cantidad")),
                                    PrecioUnitario = reader.GetDecimal(reader.GetOrdinal("PrecioUnitario"))
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(ObtenerDetalleVentaAsync));
                throw new Exception("Error al obtener el detalle de la venta.", ex);
            }

            return detalles;
        }

        public async Task DevolverVentaAsync(int idDetalleVenta)
        {
            try
            {
                using (var connection = ConexionBD.ObtenerConexion())
                {
                    await connection.OpenAsync();
                    using (var command = new SqlCommand("sp_DevolverVenta", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@IDDetalleVenta", idDetalleVenta);

                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(DevolverVentaAsync));
                throw new Exception("Error al procesar la devolución.", ex);
            }
        }

        public async Task RegistrarVentaConCreditoAsync(Venta venta, List<DetalleVenta> detalles, int idCliente)
        {
            try
            {
                using (var connection = ConexionBD.ObtenerConexion())
                {
                    await connection.OpenAsync();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            int idVenta;

                            // Registrar la venta
                            using (var command = new SqlCommand("sp_RegistrarVenta", connection, transaction))
                            {
                                command.CommandType = CommandType.StoredProcedure;
                                command.Parameters.AddWithValue("@IDCliente", venta.IDCliente);
                                command.Parameters.AddWithValue("@MontoTotal", venta.MontoTotal);
                                command.Parameters.AddWithValue("@TipoPago", venta.TipoPago);
                                command.Parameters.AddWithValue("@IDUsuario", venta.IDUsuario);

                                SqlParameter outputId = new SqlParameter("@IDVenta", SqlDbType.Int) { Direction = ParameterDirection.Output };
                                command.Parameters.Add(outputId);

                                await command.ExecuteNonQueryAsync();
                                idVenta = (int)outputId.Value;
                            }

                            // Registrar cada producto en el detalle de la venta
                            foreach (var detalle in detalles)
                            {
                                using (var command = new SqlCommand("sp_RegistrarDetalleVenta", connection, transaction))
                                {
                                    command.CommandType = CommandType.StoredProcedure;
                                    command.Parameters.AddWithValue("@IDVenta", idVenta);
                                    command.Parameters.AddWithValue("@IDProducto", detalle.IDProducto);
                                    command.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                                    command.Parameters.AddWithValue("@PrecioUnitario", detalle.PrecioUnitario);

                                    await command.ExecuteNonQueryAsync();
                                }
                            }

                            // Actualizar saldo crédito del cliente
                            using (var command = new SqlCommand("sp_ActualizarSaldoCredito", connection, transaction))
                            {
                                command.CommandType = CommandType.StoredProcedure;
                                command.Parameters.AddWithValue("@IDCliente", idCliente);
                                command.Parameters.AddWithValue("@Monto", venta.MontoTotal);

                                await command.ExecuteNonQueryAsync();
                            }

                            transaction.Commit();
                        }
                        catch (Exception exTrans)
                        {
                            transaction.Rollback();
                            LogError(exTrans, nameof(RegistrarVentaConCreditoAsync));
                            throw new Exception("Error al registrar la venta con crédito. Se deshizo la transacción.", exTrans);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(RegistrarVentaConCreditoAsync));
                throw new Exception("Error general al registrar la venta con crédito.", ex);
            }
        }


        private void LogError(Exception ex, string metodo)
        {
            try
            {
                string logPath = "logErrores.txt";
                string mensaje = $"[{DateTime.Now:dd/MM/yyyy HH:mm:ss}] Error en {metodo}: {ex.Message}{Environment.NewLine}";
                File.AppendAllText(logPath, mensaje);
            }
            catch
            {
                // Si hay error al escribir el log, no interrumpimos
            }
        }
    }
}
