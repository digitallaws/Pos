using Microsoft.Data.SqlClient;
using Sopromil.Modelo;
using System.Data;

namespace Sopromil.Data.Repository
{
    public class VentaRepository
    {
        private async Task<SqlConnection> GetConnectionAsync()
        {
            var connection = ConexionBD.ObtenerConexion();
            await connection.OpenAsync();
            return connection;
        }

        public async Task<List<DetalleVenta>> ObtenerDetallesPorVentaAsync(int idVenta)
        {
            var detalles = new List<DetalleVenta>();

            try
            {
                using (var connection = await GetConnectionAsync())
                using (var command = new SqlCommand("ObtenerDetalleVenta", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDVenta", idVenta);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            detalles.Add(new DetalleVenta
                            {
                                IDDetalleVenta = reader.GetInt32("IDDetalleVenta"),
                                IDVenta = reader.GetInt32("IDVenta"),
                                IDProducto = reader.GetInt32("IDProducto"),
                                NombreProducto = reader.GetString("NombreProducto"),
                                Cantidad = reader.GetDecimal("Cantidad"),
                                PrecioUnitario = reader.GetDecimal("PrecioUnitario")
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al obtener detalles de la venta: {ex.Message}");
                throw new Exception("Error al obtener detalles de la venta.");
            }

            return detalles;
        }

        public async Task<List<Venta>> ObtenerVentasAsync()
        {
            var ventas = new List<Venta>();

            try
            {
                using (var connection = await GetConnectionAsync())
                {
                    if (connection == null) return ventas;

                    using (var command = new SqlCommand("ObtenerVentas", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                ventas.Add(new Venta
                                {
                                    IDVenta = reader.GetInt32(reader.GetOrdinal("IDVenta")),
                                    IDCliente = reader.GetInt32(reader.GetOrdinal("IDCliente")),
                                    NombreCliente = reader.GetString(reader.GetOrdinal("NombreCliente")),
                                    FechaVenta = reader.GetDateTime(reader.GetOrdinal("FechaVenta")),
                                    TipoVenta = reader.GetString(reader.GetOrdinal("TipoVenta")),
                                    TotalVenta = reader.GetDecimal(reader.GetOrdinal("TotalVenta")),
                                    MontoAbonado = reader.GetDecimal(reader.GetOrdinal("MontoAbonado")),
                                    Estado = reader.GetString(reader.GetOrdinal("Estado")),
                                    FechaEstimadaPago = reader.IsDBNull(reader.GetOrdinal("FechaEstimadaPago"))
                                        ? (DateTime?)null
                                        : reader.GetDateTime(reader.GetOrdinal("FechaEstimadaPago")),
                                    TotalCompra = reader.IsDBNull(reader.GetOrdinal("TotalCompra"))
                                        ? 0
                                        : reader.GetDecimal(reader.GetOrdinal("TotalCompra")),
                                    Utilidad = reader.IsDBNull(reader.GetOrdinal("Utilidad"))
                                        ? 0
                                        : reader.GetDecimal(reader.GetOrdinal("Utilidad"))
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener las ventas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return ventas;
        }


        /// <summary>
        /// Registra una venta con sus detalles.
        /// </summary>
        public async Task<int> RegistrarVentaAsync(Venta venta, List<DetalleVenta> detalles)
        {
            try
            {
                using (var connection = await GetConnectionAsync())
                using (var command = new SqlCommand("InsertarVenta", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDCliente", venta.IDCliente);
                    command.Parameters.AddWithValue("@TipoVenta", venta.TipoVenta);
                    command.Parameters.AddWithValue("@TotalVenta", venta.TotalVenta);

                    string estadoVenta = venta.TipoVenta == "Contado" ? "Pagado" : "Pendiente";
                    command.Parameters.AddWithValue("@Estado", estadoVenta);
                    command.Parameters.AddWithValue("@FechaEstimadaPago",
                        venta.TipoVenta == "Crédito" ? (object)venta.FechaEstimadaPago : DBNull.Value);

                    var idVentaParam = new SqlParameter("@IDVenta", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    command.Parameters.Add(idVentaParam);

                    await command.ExecuteNonQueryAsync();
                    int idVenta = (int)idVentaParam.Value;

                    foreach (var detalle in detalles)
                    {
                        await RegistrarDetalleVentaAsync(idVenta, detalle);
                    }

                    return idVenta;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al registrar venta: {ex.Message}");
                throw new Exception("Error al registrar la venta.");
            }
        }

        private async Task RegistrarDetalleVentaAsync(int idVenta, DetalleVenta detalle)
        {
            try
            {
                using (var connection = await GetConnectionAsync())
                using (var command = new SqlCommand("InsertarDetalleVenta", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDVenta", idVenta);
                    command.Parameters.AddWithValue("@IDProducto", detalle.IDProducto);
                    command.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                    command.Parameters.AddWithValue("@PrecioUnitario", detalle.PrecioUnitario);

                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al registrar detalle de venta: {ex.Message}");
                throw new Exception("Error al registrar el detalle de venta.");
            }
        }

        /// <summary>
        /// Obtiene una venta por su ID.
        /// </summary>
        public async Task<Venta> ObtenerVentaPorIdAsync(int idVenta)
        {
            Venta venta = null;

            try
            {
                using (var connection = await GetConnectionAsync())
                using (var command = new SqlCommand("ObtenerVentaPorId", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDVenta", idVenta);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            venta = new Venta
                            {
                                IDVenta = reader.GetInt32(reader.GetOrdinal("IDVenta")),
                                FechaVenta = reader.GetDateTime(reader.GetOrdinal("FechaVenta")),
                                TotalVenta = reader.GetDecimal(reader.GetOrdinal("TotalVenta")),
                                MontoAbonado = reader.IsDBNull(reader.GetOrdinal("MontoAbonado")) ? 0 : reader.GetDecimal(reader.GetOrdinal("MontoAbonado")),
                                Estado = reader.GetString(reader.GetOrdinal("Estado")),
                                TipoVenta = reader.GetString(reader.GetOrdinal("TipoVenta"))
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al obtener la venta: {ex.Message}");
                throw new Exception("Error al obtener la venta.");
            }

            return venta;
        }

        /// <summary>
        /// Obtiene todas las ventas de un cliente.
        /// </summary>
        public async Task<List<Venta>> ObtenerVentasPorClienteAsync(int idCliente)
        {
            List<Venta> ventas = new List<Venta>();

            try
            {
                using (var connection = await GetConnectionAsync())
                using (var command = new SqlCommand("ObtenerVentasPorCliente", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDCliente", idCliente);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            ventas.Add(new Venta
                            {
                                IDVenta = reader.GetInt32(reader.GetOrdinal("IDVenta")),
                                IDCliente = idCliente,
                                FechaVenta = reader.GetDateTime(reader.GetOrdinal("FechaVenta")),
                                TotalVenta = reader.GetDecimal(reader.GetOrdinal("TotalVenta")),
                                MontoAbonado = reader.IsDBNull(reader.GetOrdinal("MontoAbonado")) ? 0 : reader.GetDecimal(reader.GetOrdinal("MontoAbonado")),
                                Estado = reader.GetString(reader.GetOrdinal("Estado")),
                                TipoVenta = reader.GetString(reader.GetOrdinal("TipoVenta"))
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al obtener ventas: {ex.Message}");
                throw new Exception("Error al obtener ventas.");
            }

            return ventas;
        }

        /// <summary>
        /// Aplica un pago a las facturas de un cliente.
        /// </summary>
        public async Task<bool> AplicarPagoAsync(int idCliente, decimal montoAbonado)
        {
            try
            {
                using (var connection = await GetConnectionAsync())
                using (var command = new SqlCommand("AplicarPagoFactura", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDCliente", idCliente);
                    command.Parameters.AddWithValue("@MontoAbonado", montoAbonado);

                    var idPagoParam = new SqlParameter("@IDPago", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    command.Parameters.Add(idPagoParam);

                    await command.ExecuteNonQueryAsync();
                    return (int)idPagoParam.Value > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al aplicar pago: {ex.Message}");
                throw new Exception("Error al aplicar el pago.");
            }
        }

        /// <summary>
        /// Obtiene el saldo pendiente de un cliente.
        /// </summary>
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
                Console.WriteLine($"❌ Error al obtener saldo pendiente: {ex.Message}");
                throw new Exception("Error al obtener saldo pendiente.");
            }

            return saldoPendiente;
        }

        /// <summary>
        /// Cambia el estado de una venta.
        /// </summary>
        public async Task<bool> CambiarEstadoVentaAsync(int idVenta, string nuevoEstado)
        {
            try
            {
                using (var connection = await GetConnectionAsync())
                using (var command = new SqlCommand("CambiarEstadoVenta", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDVenta", idVenta);
                    command.Parameters.AddWithValue("@NuevoEstado", nuevoEstado);

                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al cambiar estado de venta: {ex.Message}");
                throw new Exception("Error al cambiar el estado de la venta.");
            }
        }
    }
}
