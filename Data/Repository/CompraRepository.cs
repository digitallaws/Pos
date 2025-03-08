using Microsoft.Data.SqlClient;
using Sopromil.Modelo;
using System.Data;

namespace Sopromil.Data.Repository
{
    public class CompraRepository
    {
        private async Task<SqlConnection> GetConnectionAsync()
        {
            var connection = ConexionBD.ObtenerConexion();
            await connection.OpenAsync();
            return connection;
        }

        // Registrar una compra
        public async Task<int> RegistrarCompraAsync(Compra compra, List<DetalleCompra> detalles)
        {
            using (var connection = await GetConnectionAsync())
            using (var command = new SqlCommand("InsertarCompra", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@IDProveedor", compra.IDProveedor);
                command.Parameters.AddWithValue("@TotalCompra", compra.TotalCompra);
                command.Parameters.AddWithValue("@FleteTotal", compra.Flete);
                command.Parameters.AddWithValue("@Estado", compra.Estado ?? "Finalizada");

                var idCompraParam = new SqlParameter("@IDCompra", SqlDbType.Int) { Direction = ParameterDirection.Output };
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

        // Registrar detalle de compra
        public async Task RegistrarDetalleCompraAsync(int idCompra, DetalleCompra detalle)
        {
            using (var connection = await GetConnectionAsync())
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

        // Obtener todas las compras
        public async Task<List<Compra>> ObtenerComprasAsync()
        {
            var compras = new List<Compra>();

            using (var connection = await GetConnectionAsync())
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

            return compras;
        }

        // Obtener detalles de una compra específica
        public async Task<List<DetalleCompra>> ObtenerDetallesPorCompraAsync(int idCompra)
        {
            var detalles = new List<DetalleCompra>();

            using (var connection = await GetConnectionAsync())
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

            return detalles;
        }

        // Obtener facturas por proveedor
        public async Task<List<Compra>> ObtenerFacturasPorProveedorAsync(int idProveedor)
        {
            var compras = new List<Compra>();

            using (var connection = await GetConnectionAsync())
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

            return compras;
        }

    }
}
