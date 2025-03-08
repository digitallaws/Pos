using Microsoft.Data.SqlClient;
using Sopromil.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Sopromil.Data.Repository
{
    public class CompraRepository
    {
        private async Task<SqlConnection> GetConnectionAsync()
        {
            try
            {
                var connection = ConexionBD.ObtenerConexion();
                await connection.OpenAsync();
                return connection;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al abrir la conexión a la base de datos: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Registra una nueva compra con sus detalles.
        /// </summary>
        public async Task<int> RegistrarCompraAsync(Compra compra, List<DetalleCompra> detalles)
        {
            try
            {
                using (var connection = await GetConnectionAsync())
                {
                    if (connection == null) return 0;

                    using (var command = new SqlCommand("InsertarCompra", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@IDProveedor", compra.IDProveedor);
                        command.Parameters.AddWithValue("@TotalCompra", compra.TotalCompra);
                        command.Parameters.AddWithValue("@FleteTotal", compra.Flete);
                        command.Parameters.AddWithValue("@Estado", compra.Estado ?? "Finalizada");

                        var idCompraParam = new SqlParameter("@IDCompra", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(idCompraParam);

                        await command.ExecuteNonQueryAsync();
                        int idCompra = (int)idCompraParam.Value;

                        foreach (var detalle in detalles)
                        {
                            await RegistrarDetalleCompraAsync(idCompra, detalle);
                        }

                        return idCompra;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al registrar la compra: {ex.Message}");
                return 0;
            }
        }

        /// <summary>
        /// Registra un detalle de compra para una compra específica.
        /// </summary>
        public async Task RegistrarDetalleCompraAsync(int idCompra, DetalleCompra detalle)
        {
            try
            {
                using (var connection = await GetConnectionAsync())
                {
                    if (connection == null) return;

                    using (var command = new SqlCommand("InsertarDetalleCompra", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@IDCompra", idCompra);
                        command.Parameters.AddWithValue("@IDProducto", detalle.IDProducto);
                        command.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                        command.Parameters.AddWithValue("@PrecioUnitario", detalle.PrecioUnitario);

                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al registrar el detalle de compra: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtiene todas las compras registradas en la base de datos.
        /// </summary>
        public async Task<List<Compra>> ObtenerComprasAsync()
        {
            var compras = new List<Compra>();

            try
            {
                using (var connection = await GetConnectionAsync())
                {
                    if (connection == null) return compras;

                    using (var command = new SqlCommand("ObtenerCompras", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                compras.Add(new Compra
                                {
                                    IDCompra = reader.GetInt32(reader.GetOrdinal("IDCompra")),
                                    IDProveedor = reader.GetInt32(reader.GetOrdinal("IDProveedor")),
                                    FechaCompra = reader.GetDateTime(reader.GetOrdinal("FechaCompra")),
                                    TotalCompra = reader.GetDecimal(reader.GetOrdinal("TotalCompra")),
                                    Flete = reader.GetDecimal(reader.GetOrdinal("FleteTotal")),
                                    Estado = reader.GetString(reader.GetOrdinal("Estado"))
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al obtener las compras: {ex.Message}");
            }

            return compras;
        }

        /// <summary>
        /// Obtiene los detalles de una compra específica.
        /// </summary>
        public async Task<List<DetalleCompra>> ObtenerDetallesPorCompraAsync(int idCompra)
        {
            var detalles = new List<DetalleCompra>();

            try
            {
                using (var connection = await GetConnectionAsync())
                {
                    if (connection == null) return detalles;

                    using (var command = new SqlCommand("ObtenerDetalleCompra", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@IDCompra", idCompra);

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                detalles.Add(new DetalleCompra
                                {
                                    IDDetalleCompra = reader.GetInt32(reader.GetOrdinal("IDDetalleCompra")),
                                    IDCompra = reader.GetInt32(reader.GetOrdinal("IDCompra")),
                                    IDProducto = reader.GetInt32(reader.GetOrdinal("IDProducto")),
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
                Console.WriteLine($"❌ Error al obtener los detalles de la compra: {ex.Message}");
            }

            return detalles;
        }

        /// <summary>
        /// Obtiene las facturas de un proveedor específico.
        /// </summary>
        public async Task<List<Compra>> ObtenerFacturasPorProveedorAsync(int idProveedor)
        {
            var compras = new List<Compra>();

            try
            {
                using (var connection = await GetConnectionAsync())
                {
                    if (connection == null) return compras;

                    using (var command = new SqlCommand("ObtenerFacturasPorProveedor", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@IDProveedor", idProveedor);

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                compras.Add(new Compra
                                {
                                    IDCompra = reader.GetInt32(reader.GetOrdinal("IDCompra")),
                                    FechaCompra = reader.GetDateTime(reader.GetOrdinal("FechaCompra")),
                                    TotalCompra = reader.GetDecimal(reader.GetOrdinal("TotalCompra")),
                                    Flete = reader.GetDecimal(reader.GetOrdinal("FleteTotal")),
                                    Estado = reader.GetString(reader.GetOrdinal("Estado")),
                                    NombreProveedor = reader.GetString(reader.GetOrdinal("NombreProveedor"))
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al obtener facturas por proveedor: {ex.Message}");
            }

            return compras;
        }
    }
}
