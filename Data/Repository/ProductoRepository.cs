using Microsoft.Data.SqlClient;
using Sopromil.Modelo;
using System.Data;

namespace Sopromil.Data.Repository
{
    public class ProductoRepository
    {
        public async Task<List<Producto>> ListarProductosPorProveedorAsync(int idProveedor, bool soloActivos = true)
        {
            var lista = new List<Producto>();

            try
            {
                using (var connection = ConexionBD.ObtenerConexion())
                {
                    await connection.OpenAsync();

                    using (var command = new SqlCommand("ListarProductosPorProveedor", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@IDProveedor", idProveedor);
                        command.Parameters.AddWithValue("@SoloActivos", soloActivos ? 1 : 0);

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                lista.Add(MapearProducto(reader));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al listar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return lista;
        }

        public async Task<List<Producto>> ListarTodosLosProductosAsync()
        {
            List<Producto> productos = new List<Producto>();

            try
            {
                using (var connection = ConexionBD.ObtenerConexion())
                {
                    await connection.OpenAsync();

                    using (var command = new SqlCommand("ListarTodosLosProductos", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var producto = new Producto
                                {
                                    IDProducto = reader.GetInt32(reader.GetOrdinal("IDProducto")),
                                    Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                                    Marca = reader.IsDBNull(reader.GetOrdinal("Marca")) ? null : reader.GetString(reader.GetOrdinal("Marca")),
                                    UnidadMedida = reader.GetString(reader.GetOrdinal("UnidadMedida")),
                                    Stock = reader.GetDecimal(reader.GetOrdinal("Stock")),
                                    FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento"))
                                        ? (DateTime?)null
                                        : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento")),
                                    CodigoBarras = reader.IsDBNull(reader.GetOrdinal("CodigoBarras")) ? null : reader.GetString(reader.GetOrdinal("CodigoBarras")),
                                    PrecioCompra = reader.GetDecimal(reader.GetOrdinal("PrecioCompra")),
                                    Flete = reader.GetDecimal(reader.GetOrdinal("Flete")),
                                    Utilidad = reader.GetDecimal(reader.GetOrdinal("Utilidad")),
                                    ValorVenta = reader.GetDecimal(reader.GetOrdinal("ValorVenta")),
                                    Estado = reader.GetString(reader.GetOrdinal("Estado")),

                                    // Relación con Proveedor
                                    IDProveedor = reader.GetInt32(reader.GetOrdinal("IDProveedor")),
                                    Proveedor = new Proveedor
                                    {
                                        IDProveedor = reader.GetInt32(reader.GetOrdinal("IDProveedor")),
                                        Nombre = reader.GetString(reader.GetOrdinal("NombreProveedor"))
                                    }
                                };

                                productos.Add(producto);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return productos;
        }

        public async Task CrearProductoAsync(Producto producto)
        {
            try
            {
                using (var connection = ConexionBD.ObtenerConexion())
                {
                    await connection.OpenAsync();

                    using (var command = new SqlCommand("CrearProducto", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                        command.Parameters.AddWithValue("@Marca", (object)producto.Marca ?? DBNull.Value);
                        command.Parameters.AddWithValue("@UnidadMedida", producto.UnidadMedida);
                        command.Parameters.AddWithValue("@Stock", producto.Stock);
                        command.Parameters.AddWithValue("@FechaVencimiento", (object)producto.FechaVencimiento ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CodigoBarras", (object)producto.CodigoBarras ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PrecioCompra", producto.PrecioCompra);
                        command.Parameters.AddWithValue("@Flete", producto.Flete);
                        command.Parameters.AddWithValue("@Utilidad", producto.Utilidad);
                        command.Parameters.AddWithValue("@IDProveedor", producto.IDProveedor);

                        await command.ExecuteNonQueryAsync();

                        MessageBox.Show("Producto registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task ActualizarProductoAsync(Producto producto)
        {
            try
            {
                using (var connection = ConexionBD.ObtenerConexion())
                {
                    await connection.OpenAsync();

                    using (var command = new SqlCommand("ActualizarProducto", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@IDProducto", producto.IDProducto);
                        command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                        command.Parameters.AddWithValue("@Marca", (object)producto.Marca ?? DBNull.Value);
                        command.Parameters.AddWithValue("@UnidadMedida", producto.UnidadMedida);
                        command.Parameters.AddWithValue("@Stock", producto.Stock);
                        command.Parameters.AddWithValue("@FechaVencimiento", (object)producto.FechaVencimiento ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CodigoBarras", (object)producto.CodigoBarras ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PrecioCompra", producto.PrecioCompra);
                        command.Parameters.AddWithValue("@Flete", producto.Flete);
                        command.Parameters.AddWithValue("@Utilidad", producto.Utilidad);
                        command.Parameters.AddWithValue("@Estado", producto.Estado);

                        await command.ExecuteNonQueryAsync();

                        MessageBox.Show("Producto actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task CambiarEstadoProductoAsync(int idProducto, string nuevoEstado)
        {
            try
            {
                using (var connection = ConexionBD.ObtenerConexion())
                {
                    await connection.OpenAsync();

                    using (var command = new SqlCommand("CambiarEstadoProducto", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@IDProducto", idProducto);
                        command.Parameters.AddWithValue("@Estado", nuevoEstado);

                        await command.ExecuteNonQueryAsync();

                        MessageBox.Show($"Producto cambiado a estado: {nuevoEstado}.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar estado del producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task<bool> UbicarProductoAsync(int idProducto, string estante, string seccion)
        {
            try
            {
                using (var connection = ConexionBD.ObtenerConexion())
                {
                    await connection.OpenAsync();

                    using (var command = new SqlCommand("UbicarProducto", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@IDProducto", idProducto);
                        command.Parameters.AddWithValue("@UbicacionEstante", estante);
                        command.Parameters.AddWithValue("@UbicacionSeccion", seccion);

                        int rowsAffected = await command.ExecuteNonQueryAsync();
                        return rowsAffected > 0; // Retorna `true` si se actualizó al menos una fila
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al ubicar producto: {ex.Message}");
                return false;
            }
        }

        public async Task<(string Estante, string Seccion)> ObtenerUbicacionProductoAsync(int idProducto)
        {
            try
            {
                using (var connection = ConexionBD.ObtenerConexion())
                {
                    await connection.OpenAsync();

                    using (var command = new SqlCommand("ObtenerUbicacionProducto", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@IDProducto", idProducto);

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (reader.Read())
                            {
                                string estante = reader["UbicacionEstante"]?.ToString() ?? "";
                                string seccion = reader["UbicacionSeccion"]?.ToString() ?? "";
                                return (estante, seccion);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al obtener la ubicación: {ex.Message}");
            }

            return ("", ""); // Retornar vacío si hay un error o no existe
        }


        private Producto MapearProducto(SqlDataReader reader)
        {
            var producto = new Producto
            {
                IDProducto = reader.GetInt32(reader.GetOrdinal("IDProducto")),
                Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                Marca = reader.IsDBNull(reader.GetOrdinal("Marca")) ? null : reader.GetString(reader.GetOrdinal("Marca")),
                UnidadMedida = reader.GetString(reader.GetOrdinal("UnidadMedida")),
                Stock = reader.GetDecimal(reader.GetOrdinal("Stock")),
                FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento")),
                CodigoBarras = reader.IsDBNull(reader.GetOrdinal("CodigoBarras")) ? null : reader.GetString(reader.GetOrdinal("CodigoBarras")),
                PrecioCompra = reader.GetDecimal(reader.GetOrdinal("PrecioCompra")),
                Flete = reader.GetDecimal(reader.GetOrdinal("Flete")),
                Utilidad = reader.GetDecimal(reader.GetOrdinal("Utilidad")),
                ValorVenta = reader.GetDecimal(reader.GetOrdinal("ValorVenta")),
                Estado = reader.GetString(reader.GetOrdinal("Estado")),
                IDProveedor = reader.GetInt32(reader.GetOrdinal("IDProveedor")),  // ⚠️ Aquí ocurre el error
            };

            return producto;
        }
    }
}
