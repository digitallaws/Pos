using Microsoft.Data.SqlClient;
using Sopromil.Modelo;
using System.Data;

namespace Sopromil.Data.Repository
{
    public class HistorialPreciosRepository
    {
        private async Task<SqlConnection> GetConnectionAsync()
        {
            var connection = ConexionBD.ObtenerConexion();
            await connection.OpenAsync();
            return connection;
        }

        /// <summary>
        /// Registra un cambio de precio en el historial.
        /// </summary>
        public async Task RegistrarCambioPrecioAsync(HistorialPrecios historial)
        {
            using (var connection = await GetConnectionAsync())
            using (var command = new SqlCommand("InsertarHistorialPrecios", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@IDProducto", historial.IDProducto);
                command.Parameters.AddWithValue("@PrecioCompraAnterior", historial.PrecioCompraAnterior);
                command.Parameters.AddWithValue("@PrecioCompraNuevo", historial.PrecioCompraNuevo);
                command.Parameters.AddWithValue("@PrecioVentaAnterior", historial.PrecioVentaAnterior);
                command.Parameters.AddWithValue("@PrecioVentaNuevo", historial.PrecioVentaNuevo);
                command.Parameters.AddWithValue("@Motivo", historial.Motivo);

                await command.ExecuteNonQueryAsync();
            }
        }

        /// <summary>
        /// Obtiene el historial de cambios de precios de un producto.
        /// </summary>
        public async Task<List<HistorialPrecios>> ObtenerHistorialPorProductoAsync(int idProducto)
        {
            var historialPrecios = new List<HistorialPrecios>();

            using (var connection = await GetConnectionAsync())
            using (var command = new SqlCommand("ObtenerHistorialPrecios", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDProducto", idProducto);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        historialPrecios.Add(new HistorialPrecios
                        {
                            IDHistorial = reader.GetInt32(reader.GetOrdinal("IDHistorial")),
                            IDProducto = reader.GetInt32(reader.GetOrdinal("IDProducto")),
                            FechaCambio = reader.GetDateTime(reader.GetOrdinal("FechaCambio")),
                            PrecioCompraAnterior = reader.GetDecimal(reader.GetOrdinal("PrecioCompraAnterior")),
                            PrecioCompraNuevo = reader.GetDecimal(reader.GetOrdinal("PrecioCompraNuevo")),
                            PrecioVentaAnterior = reader.GetDecimal(reader.GetOrdinal("PrecioVentaAnterior")),
                            PrecioVentaNuevo = reader.GetDecimal(reader.GetOrdinal("PrecioVentaNuevo")),
                            Motivo = reader.GetString(reader.GetOrdinal("Motivo"))
                        });
                    }
                }
            }

            return historialPrecios;
        }
    }
}
