using Microsoft.Data.SqlClient;
using Sopromil.Data.Interfaces;
using Sopromil.Modelo;
using System.Data;

namespace Sopromil.Data.Repository
{
    public class TicketRepository : ITicketRepository
    {
        public async Task<TicketConfig> ObtenerConfiguracionTicketAsync()
        {
            TicketConfig ticketConfig = null;

            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("ObtenerConfiguracionTicket", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            ticketConfig = new TicketConfig
                            {
                                IDConfig = reader.GetInt32(reader.GetOrdinal("IDConfig")),
                                Agradecimiento = reader.GetString(reader.GetOrdinal("Agradecimiento")),
                                Anuncio = reader.GetString(reader.GetOrdinal("Anuncio")),
                                DatosFiscales = reader.GetString(reader.GetOrdinal("DatosFiscales"))
                            };
                        }
                    }
                }
            }

            return ticketConfig;
        }

        public async Task<string> GuardarActualizarTicketAsync(TicketConfig ticketConfig)
        {
            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("GuardarActualizarTicket", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Agradecimiento", ticketConfig.Agradecimiento);
                    command.Parameters.AddWithValue("@Anuncio", ticketConfig.Anuncio);
                    command.Parameters.AddWithValue("@DatosFiscales", ticketConfig.DatosFiscales);

                    var resultado = await command.ExecuteScalarAsync();
                    return resultado.ToString();
                }
            }
        }
    }
}
