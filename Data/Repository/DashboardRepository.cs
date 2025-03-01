using Microsoft.Data.SqlClient;
using Sopromil.Data.Interfaces;
using Sopromil.Modelo;
using System.Data;

namespace Sopromil.Data.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        // ✅ Obtener Ventas del Mes
        public async Task<decimal> ObtenerVentasDelMesAsync()
        {
            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();
                using (var cmd = new SqlCommand("ObtenerVentasDelMes", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var result = await cmd.ExecuteScalarAsync();
                    return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                }
            }
        }

        // ✅ Obtener Ventas del Día
        public async Task<decimal> ObtenerVentasDelDiaAsync()
        {
            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();
                using (var cmd = new SqlCommand("ObtenerVentasDelDia", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var result = await cmd.ExecuteScalarAsync();
                    return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                }
            }
        }

        // ✅ Obtener Total de Créditos Pendientes
        public async Task<decimal> ObtenerTotalCreditosPendientesAsync()
        {
            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();
                using (var cmd = new SqlCommand("ObtenerTotalCreditosPendientes", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var result = await cmd.ExecuteScalarAsync();
                    return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                }
            }
        }

        // ✅ Obtener Número de Productos por Vencer
        public async Task<int> ObtenerProductosPorVencerAsync()
        {
            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();
                using (var cmd = new SqlCommand("ObtenerProductosPorVencer", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var result = await cmd.ExecuteScalarAsync();
                    return result != DBNull.Value ? Convert.ToInt32(result) : 0;
                }
            }
        }

        // ✅ Obtener Detalle de Productos por Vencer
        public async Task<List<ProductoVencimiento>> ObtenerProductosPorVencerDetalleAsync()
        {
            var productos = new List<ProductoVencimiento>();

            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();
                using (var cmd = new SqlCommand("ObtenerProductosPorVencerDetalle", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            productos.Add(new ProductoVencimiento
                            {
                                IDProducto = reader.GetInt32(reader.GetOrdinal("IDProducto")),
                                Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                                Stock = reader.GetInt32(reader.GetOrdinal("Stock")),
                                FechaVencimiento = reader.GetDateTime(reader.GetOrdinal("FechaVencimiento")),
                                PrecioVenta = reader.GetDecimal(reader.GetOrdinal("PrecioVenta"))
                            });
                        }
                    }
                }
            }

            return productos;
        }

        // ✅ Obtener Créditos Cercanos al Vencimiento
        public async Task<List<CreditoPendiente>> ObtenerCreditosCercanosVencimientoAsync()
        {
            var creditos = new List<CreditoPendiente>();

            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();
                using (var cmd = new SqlCommand("ObtenerCreditosCercanosVencimiento", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            creditos.Add(new CreditoPendiente
                            {
                                IDCredito = reader.GetInt32(reader.GetOrdinal("IDCredito")),
                                Cliente = reader.GetString(reader.GetOrdinal("Cliente")),
                                Total = reader.GetDecimal(reader.GetOrdinal("Total")),
                                Saldo = reader.GetDecimal(reader.GetOrdinal("Saldo")),
                                FechaVencimiento = reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"))
                            });
                        }
                    }
                }
            }

            return creditos;
        }
    }
}
