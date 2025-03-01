using Sopromil.Data.Interfaces;
using Sopromil.Data.Repository;
using Sopromil.Modelo;

namespace Sopromil.Controlador
{
    public class TicketController
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketController()
        {
            _ticketRepository = new TicketRepository();
        }

        public async Task<TicketConfig> ObtenerConfiguracionTicketAsync()
        {
            try
            {
                return await _ticketRepository.ObtenerConfiguracionTicketAsync();
            }
            catch
            {
                MessageBox.Show("Error al obtener la configuración del ticket.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task GuardarActualizarTicketAsync(TicketConfig ticketConfig)
        {
            try
            {
                var resultado = await _ticketRepository.GuardarActualizarTicketAsync(ticketConfig);

                if (resultado == "TicketActualizado")
                    MessageBox.Show("Configuración de ticket actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (resultado == "TicketCreado")
                    MessageBox.Show("Configuración de ticket creada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Error al guardar la configuración del ticket.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("Error al guardar la configuración del ticket.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
