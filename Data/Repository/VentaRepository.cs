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

        public async Task RegistrarDetalleVentaAsync(DetalleVenta detalle)
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

        public async Task<List<Venta>> ObtenerVentasAsync()
        {
            var ventas = new List<Venta>();

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
                                IDCliente = reader.GetInt32(reader.GetOrdinal("Cliente")),
                                IDUsuario = reader.GetInt32(reader.GetOrdinal("Usuario"))
                            });
                        }
                    }
                }
            }
            return ventas;
        }

        public async Task<List<DetalleVenta>> ObtenerDetalleVentaAsync(int idVenta)
        {
            var detalles = new List<DetalleVenta>();

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
                                IDProducto = reader.GetInt32(reader.GetOrdinal("Producto")),
                                Cantidad = reader.GetDecimal(reader.GetOrdinal("Cantidad")),
                                PrecioUnitario = reader.GetDecimal(reader.GetOrdinal("PrecioUnitario"))
                            });
                        }
                    }
                }
            }
            return detalles;
        }

        public async Task DevolverVentaAsync(int idDetalleVenta)
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
    }
}
