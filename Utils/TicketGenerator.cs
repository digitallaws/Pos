using Sopromil.Controlador;
using Sopromil.Modelo;
using System.Drawing.Printing;
using System.Text;

namespace Sopromil.Utils
{
    public class TicketGenerator
    {
        private EmpresaController _empresaController;
        private string _impresora;

        public TicketGenerator()
        {
            _empresaController = new EmpresaController();
        }

        public async Task ImprimirTicket(string ticketID, string fecha, string cliente, string vendedor, string tipoPago, List<(string producto, decimal cantidad, decimal precioUnitario)> detalleVenta)
        {
            Empresa empresa = await _empresaController.ObtenerDatosEmpresaAsync();
            if (empresa == null)
            {
                throw new Exception("No se pudieron obtener los datos de la empresa.");
            }

            _impresora = "Nombre de tu impresora térmica"; // Configurar el nombre de la impresora correctamente

            StringBuilder ticketTexto = new StringBuilder();
            ticketTexto.AppendLine(empresa.Nombre);
            ticketTexto.AppendLine("NIT: " + empresa.RUC);
            ticketTexto.AppendLine(empresa.Direccion);
            ticketTexto.AppendLine("Tel: " + empresa.Telefono);
            ticketTexto.AppendLine("--------------------------------");
            ticketTexto.AppendLine($"Fecha: {fecha}");
            ticketTexto.AppendLine($"Cliente: {cliente}");
            ticketTexto.AppendLine($"Forma de pago: {tipoPago}");
            ticketTexto.AppendLine($"Vendedor: {vendedor}");
            ticketTexto.AppendLine("--------------------------------");
            ticketTexto.AppendLine("Cant  Detalle        Precio  Total");

            decimal subtotal = 0;
            int cantidadTotal = 0;

            foreach (var item in detalleVenta)
            {
                decimal totalProducto = item.cantidad * item.precioUnitario;
                subtotal += totalProducto;
                cantidadTotal += (int)item.cantidad;
                ticketTexto.AppendLine($"{item.cantidad,-4} {item.producto,-12} {item.precioUnitario,8} {totalProducto,8}");
            }

            decimal total = subtotal;
            ticketTexto.AppendLine("--------------------------------");
            ticketTexto.AppendLine($"Subtotal: {subtotal:N0}$");
            ticketTexto.AppendLine("IVA: 0$");
            ticketTexto.AppendLine($"Total: {total:N0}$");
            ticketTexto.AppendLine($"Cantidad Productos: {cantidadTotal}");
            ticketTexto.AppendLine("--------------------------------");
            ticketTexto.AppendLine("¡Gracias por comprar!");
            ticketTexto.AppendLine("Conserve este ticket para cambios y devoluciones.");

            PrintDocument printDoc = new PrintDocument();
            printDoc.PrinterSettings.PrinterName = _impresora;

            printDoc.PrintPage += (sender, e) =>
            {
                Font printFont = new Font("Courier New", 10);
                e.Graphics.DrawString(ticketTexto.ToString(), printFont, Brushes.Black, new PointF(0, 0));
            };

            try
            {
                printDoc.Print();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al imprimir en la impresora térmica: {ex.Message}");
            }
        }
    }
}