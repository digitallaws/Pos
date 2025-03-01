using Microsoft.Data.SqlClient;
using Sopromil.Data.Interfaces;
using Sopromil.Modelo;
using System.Data;

namespace Sopromil.Data.Repository
{
    public class InventarioRepository : IInventarioRepository
    {
        public async Task<string> RegistrarMovimientoInventarioAsync(int idProducto, decimal cantidad, string tipoMovimiento, string motivo, int idUsuario)
        {
            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();
                using (var cmd = new SqlCommand("RegistrarMovimientoInventario", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDProducto", idProducto);
                    cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@TipoMovimiento", tipoMovimiento);
                    cmd.Parameters.AddWithValue("@Motivo", motivo);
                    cmd.Parameters.AddWithValue("@IDUsuario", idUsuario);

                    var resultado = await cmd.ExecuteScalarAsync();
                    return resultado.ToString();
                }
            }
        }

        public async Task<List<MovimientoInventario>> ObtenerHistorialMovimientosAsync(DateTime? fechaInicio, DateTime? fechaFin)
        {
            var movimientos = new List<MovimientoInventario>();

            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();
                using (var cmd = new SqlCommand("ObtenerHistorialMovimientos", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio.HasValue ? (object)fechaInicio : DBNull.Value);
                    cmd.Parameters.AddWithValue("@FechaFin", fechaFin.HasValue ? (object)fechaFin : DBNull.Value);

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            movimientos.Add(new MovimientoInventario
                            {
                                IDMovimiento = reader.GetInt32(0),
                                Producto = reader.GetString(1),
                                Cantidad = reader.GetDecimal(2),
                                TipoMovimiento = reader.GetString(3),
                                Motivo = reader.GetString(4),
                                FechaMovimiento = reader.GetDateTime(5),
                                Usuario = reader.GetString(6)
                            });
                        }
                    }
                }
            }

            return movimientos;
        }

        public async Task<string> AjustarStockProductoAsync(int idProducto, decimal nuevoStock)
        {
            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();
                using (var cmd = new SqlCommand("AjustarStockProducto", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDProducto", idProducto);
                    cmd.Parameters.AddWithValue("@NuevoStock", nuevoStock);

                    var resultado = await cmd.ExecuteScalarAsync();
                    return resultado.ToString();
                }
            }
        }

        public async Task<List<ProductoInventario>> ObtenerProductosBajoStockAsync()
        {
            var productos = new List<ProductoInventario>();

            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();
                using (var cmd = new SqlCommand("ObtenerProductosBajoStock", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            productos.Add(new ProductoInventario
                            {
                                IDProducto = reader.GetInt32(0),
                                Descripcion = reader.GetString(1),
                                Stock = reader.GetDecimal(2),
                                StockMinimo = reader.GetDecimal(3)
                            });
                        }
                    }
                }
            }

            return productos;
        }

        public async Task<List<ProductoProximoVencer>> ObtenerProductosProximosAVencerAsync()
        {
            var productos = new List<ProductoProximoVencer>();

            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();
                using (var cmd = new SqlCommand("ObtenerProductosProximosAVencer", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            productos.Add(new ProductoProximoVencer
                            {
                                IDProducto = reader.GetInt32(0),
                                Descripcion = reader.GetString(1),
                                FechaVencimiento = reader.GetDateTime(2),
                                DiasRestantes = reader.GetInt32(3)
                            });
                        }
                    }
                }
            }

            return productos;
        }
    }
}
