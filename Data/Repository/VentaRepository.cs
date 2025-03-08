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

        public async Task<int> RegistrarVentaAsync(Venta venta, List<DetalleVenta> detalles)
        {
            try
            {
                using (var connection = await GetConnectionAsync())
                using (var command = new SqlCommand("InsertarVenta", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDCliente", venta.IDCliente);
                    command.Parameters.AddWithValue("@TipoVenta", venta.TipoVenta); // 🔥 "Contado" o "Crédito"
                    command.Parameters.AddWithValue("@TotalVenta", venta.TotalVenta);

                    // 🔥 Establecer estado correctamente ("Pagado" si es Contado, "Pendiente" si es Crédito)
                    string estadoVenta = venta.TipoVenta == "Contado" ? "Pagado" : "Pendiente";
                    command.Parameters.AddWithValue("@Estado", estadoVenta);

                    // 🔥 Si la venta es a crédito, enviamos la fecha de pago, sino NULL
                    command.Parameters.AddWithValue("@FechaEstimadaPago",
                        venta.TipoVenta == "Crédito" ? (object)venta.FechaEstimadaPago : DBNull.Value);

                    // 🔥 Obtener el ID de la venta creada
                    var idVentaParam = new SqlParameter("@IDVenta", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    command.Parameters.Add(idVentaParam);

                    await command.ExecuteNonQueryAsync();

                    int idVenta = (int)idVentaParam.Value;

                    // 🔥 Registrar los detalles de la venta
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
                                IDDetalleVenta = reader.GetInt32(reader.GetOrdinal("IDDetalleVenta")),
                                IDVenta = reader.GetInt32(reader.GetOrdinal("IDVenta")),
                                IDProducto = reader.GetInt32(reader.GetOrdinal("IDProducto")),
                                NombreProducto = reader.GetString(reader.GetOrdinal("NombreProducto")), // 🔥 Se obtiene el nombre del producto
                                Cantidad = reader.GetDecimal(reader.GetOrdinal("Cantidad")),
                                PrecioUnitario = reader.GetDecimal(reader.GetOrdinal("PrecioUnitario"))
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
                                IDCliente = reader.GetInt32(reader.GetOrdinal("IDCliente")),
                                FechaVenta = reader.GetDateTime(reader.GetOrdinal("FechaVenta")),
                                TotalVenta = reader.GetDecimal(reader.GetOrdinal("TotalVenta")),
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
        /// Registra un detalle de venta.
        /// </summary>
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
                    command.Parameters.AddWithValue("@NombreProducto", detalle.NombreProducto); // 🔥 Se agrega NombreProducto
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
        /// Obtiene todas las ventas registradas.
        /// </summary>
        public async Task<List<Venta>> ObtenerVentasAsync()
        {
            var ventas = new List<Venta>();

            try
            {
                using (var connection = await GetConnectionAsync())
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
                                FechaVenta = reader.GetDateTime(reader.GetOrdinal("FechaVenta")),
                                TotalVenta = reader.GetDecimal(reader.GetOrdinal("TotalVenta")),
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


    }
}
