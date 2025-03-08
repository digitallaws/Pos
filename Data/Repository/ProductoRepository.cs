﻿using Microsoft.Data.SqlClient;
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

        public async Task<List<Producto>> ListarTodosLosProductosAsync(bool soloActivos = true)
        {
            var lista = new List<Producto>();

            try
            {
                using (var connection = ConexionBD.ObtenerConexion())
                {
                    await connection.OpenAsync();

                    using (var command = new SqlCommand("ListarTodosLosProductos", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
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
                MessageBox.Show($"Error al listar todos los productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return lista;
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
                Estado = reader.GetString(reader.GetOrdinal("Estado"))
            };

            return producto;
        }
    }
}
