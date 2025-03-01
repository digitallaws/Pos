using Sopromil.Modelo;

namespace Sopromil.Data.Interfaces
{
    public interface ITicketRepository
    {
        Task<TicketConfig> ObtenerConfiguracionTicketAsync();
        Task<string> GuardarActualizarTicketAsync(TicketConfig ticketConfig);
    }
}
