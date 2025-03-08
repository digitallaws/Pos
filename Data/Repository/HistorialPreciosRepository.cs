using Microsoft.Data.SqlClient;
using Sopromil.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Sopromil.Data.Repository
{
    public class HistorialPreciosRepository
    {
        /// <summary>
        /// Obtiene la conexión a la base de datos asegurando que esté abierta.
        /// </summary>
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
        /// Registra un cambio de precio en el historial.
        /// </summary>
        public async Task<bool> RegistrarCambioPrecioAsync(HistorialPrecios historial)
        {
            try
            {
                using (var connection = await GetConnectionAsync())
                {
                    if (connection == null) return false;

                    using (var command = new SqlCommand("InsertarHistorialPrecios", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@IDProducto", historial.IDProducto);
                        command.Parameters.AddWithValue("@PrecioCompraAnterior", historial.PrecioCompraAnterior);
                        command.Parameters.AddWithValue("@PrecioCompraNuevo", historial.PrecioCompraNuevo);
                        command.Parameters.AddWithValue("@PrecioVentaAnterior", historial.PrecioVentaAnterior);
                        command.Parameters.AddWithValue("@PrecioVentaNuevo", historial.PrecioVentaNuevo);
                        command.Parameters.AddWithValue("@Motivo", historial.Motivo ?? "");

                        await command.ExecuteNonQueryAsync();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al registrar el cambio de precio: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Obtiene el historial de cambios de precios de un producto.
        /// </summary>
        public async Task<List<HistorialPrecios>> ObtenerHistorialPorProductoAsync(int idProducto)
        {
            var historialPrecios = new List<HistorialPrecios>();

            try
            {
                using (var connection = await GetConnectionAsync())
                {
                    if (connection == null) return historialPrecios;

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
                                    Motivo = reader.IsDBNull(reader.GetOrdinal("Motivo")) ? "" : reader.GetString(reader.GetOrdinal("Motivo"))
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al obtener el historial de precios: {ex.Message}");
            }

            return historialPrecios;
        }
    }
}
