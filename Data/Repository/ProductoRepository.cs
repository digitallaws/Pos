using Microsoft.Data.SqlClient;
using Sopromil.Data.Interfaces;
using Sopromil.Modelo;
using System.Data;

namespace Sopromil.Data.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        public async Task<string> CrearProductoAsync(Producto producto)
        {
            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("CrearProducto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@IDCategoria", producto.IDCategoria);
                    command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    command.Parameters.AddWithValue("@Stock", producto.Stock);
                    command.Parameters.AddWithValue("@PrecioCompra", producto.PrecioCompra);
                    command.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);

                    // ✅ Manejo de FechaVencimiento nula
                    if (producto.FechaVencimiento == null || producto.FechaVencimiento == DateTime.MinValue)
                    {
                        command.Parameters.AddWithValue("@FechaVencimiento", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@FechaVencimiento", producto.FechaVencimiento);
                    }

                    command.Parameters.AddWithValue("@CodigoBarras", producto.CodigoBarras);

                    var resultado = await command.ExecuteScalarAsync();
                    return resultado?.ToString();
                }
            }
        }

        public async Task<List<Producto>> ObtenerProductosAsync()
        {
            var productos = new List<Producto>();

            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("ObtenerProductos", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var producto = new Producto
                            {
                                IDProducto = reader.GetInt32(reader.GetOrdinal("IDProducto")),
                                IDCategoria = reader.GetInt32(reader.GetOrdinal("IDCategoria")), // ✅ Ahora obtiene el ID de la categoría
                                Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                                Categoria = reader.GetString(reader.GetOrdinal("Categoria")),
                                Stock = reader.GetInt32(reader.GetOrdinal("Stock")),
                                PrecioCompra = reader.GetDecimal(reader.GetOrdinal("PrecioCompra")),
                                PrecioVenta = reader.GetDecimal(reader.GetOrdinal("PrecioVenta")),
                                // ✅ Manejo de posibles valores nulos en FechaVencimiento
                                FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento"))
                                    ? (DateTime?)null
                                    : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento")),
                                CodigoBarras = reader.GetString(reader.GetOrdinal("CodigoBarras"))
                            };

                            productos.Add(producto);
                        }
                    }
                }
            }

            return productos;
        }


        public async Task<string> ActualizarProductoAsync(Producto producto)
        {
            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("ActualizarProducto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@IDProducto", producto.IDProducto);
                    command.Parameters.AddWithValue("@IDCategoria", producto.IDCategoria);
                    command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    command.Parameters.AddWithValue("@Stock", producto.Stock);
                    command.Parameters.AddWithValue("@PrecioCompra", producto.PrecioCompra);
                    command.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);

                    if (producto.FechaVencimiento == null || producto.FechaVencimiento == DateTime.MinValue)
                    {
                        command.Parameters.AddWithValue("@FechaVencimiento", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@FechaVencimiento", producto.FechaVencimiento);
                    }

                    command.Parameters.AddWithValue("@CodigoBarras", producto.CodigoBarras);

                    var resultado = await command.ExecuteScalarAsync();
                    return resultado?.ToString();
                }
            }
        }

        public async Task<string> EliminarProductoAsync(int idProducto)
        {
            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("EliminarProducto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDProducto", idProducto);

                    var resultado = await command.ExecuteScalarAsync();
                    return resultado?.ToString();
                }
            }
        }

        public async Task<List<Producto>> FiltrarProductosAsync(DateTime? fechaInicio, DateTime? fechaFin, string codigoBarras, string descripcion)
        {
            var productos = new List<Producto>();

            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("FiltrarProductos", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@FechaInicio", (object)fechaInicio ?? DBNull.Value);
                    command.Parameters.AddWithValue("@FechaFin", (object)fechaFin ?? DBNull.Value);
                    command.Parameters.AddWithValue("@CodigoBarras", (object)codigoBarras ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Descripcion", (object)descripcion ?? DBNull.Value);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            productos.Add(new Producto
                            {
                                IDProducto = reader.GetInt32(reader.GetOrdinal("IDProducto")),
                                Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                                Categoria = reader.GetString(reader.GetOrdinal("Categoria")),
                                Stock = reader.GetInt32(reader.GetOrdinal("Stock")),
                                PrecioCompra = reader.GetDecimal(reader.GetOrdinal("PrecioCompra")),
                                PrecioVenta = reader.GetDecimal(reader.GetOrdinal("PrecioVenta")),
                                FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento"))
                                    ? (DateTime?)null
                                    : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento")),
                                CodigoBarras = reader.GetString(reader.GetOrdinal("CodigoBarras"))
                            });
                        }
                    }
                }
            }

            return productos;
        }
    }
}
