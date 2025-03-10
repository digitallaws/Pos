using Microsoft.Data.SqlClient;
using Sopromil.Modelo;
using System.Data;

namespace Sopromil.Data.Repository
{
    public class PedidoCompraRepository
    {
        private async Task<SqlConnection> GetConnectionAsync()
        {
            var connection = ConexionBD.ObtenerConexion();
            await connection.OpenAsync();
            return connection;
        }

        public async Task<List<PedidoCompra>> GenerarPedidoAsync()
        {
            List<PedidoCompra> pedidos = new List<PedidoCompra>();

            try
            {
                using (var connection = await GetConnectionAsync())
                using (var command = new SqlCommand("GenerarPedidoCompra", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            pedidos.Add(new PedidoCompra
                            {
                                IDProducto = reader.GetInt32(reader.GetOrdinal("IDProducto")),
                                Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                                Marca = reader.GetString(reader.GetOrdinal("Marca")),
                                Stock = reader.GetInt32(reader.GetOrdinal("Stock")),
                                PrecioCompra = reader.GetDecimal(reader.GetOrdinal("PrecioCompra")),
                                IDProveedor = reader.GetInt32(reader.GetOrdinal("IDProveedor")),
                                NombreProveedor = reader.GetString(reader.GetOrdinal("NombreProveedor")),
                                CiudadProveedor = reader.GetString(reader.GetOrdinal("CiudadProveedor")),
                                VentasUltimosDias = reader.GetInt32(reader.GetOrdinal("VentasUltimosDias")),
                                CantidadSugerida = reader.GetInt32(reader.GetOrdinal("CantidadSugerida"))
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al generar pedido: {ex.Message}");
            }

            return pedidos;
        }
    }
}
