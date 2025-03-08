using Sopromil.Modelo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;

namespace Sopromil.Impresion
{
    public class TirillaPrinter
    {
        private List<DetalleVenta> _detallesVenta;
        private Venta _venta;

        public TirillaPrinter(Venta venta, List<DetalleVenta> detalles)
        {
            _venta = venta;
            _detallesVenta = detalles;
        }

        public void Imprimir()
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += PrintDoc_PrintPage;

            try
            {
                printDoc.Print();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al imprimir: {ex.Message}");
            }
        }

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font font = new Font("Courier New", 10, FontStyle.Bold);
            int y = 10;

            g.DrawString("SOPROMIL VENTAS", font, Brushes.Black, 10, y);
            y += 20;
            g.DrawString($"Fecha: {_venta.FechaVenta:dd/MM/yyyy HH:mm}", font, Brushes.Black, 10, y);
            y += 20;
            g.DrawString("----------------------------------", font, Brushes.Black, 10, y);
            y += 20;

            g.DrawString("Cant  Producto      Precio", font, Brushes.Black, 10, y);
            y += 20;
            g.DrawString("----------------------------------", font, Brushes.Black, 10, y);
            y += 20;

            foreach (var detalle in _detallesVenta)
            {
                string linea = $"{detalle.Cantidad,-4} {detalle.IDProducto,-10} {detalle.PrecioUnitario,6:N0}";
                g.DrawString(linea, font, Brushes.Black, 10, y);
                y += 20;
            }

            g.DrawString("----------------------------------", font, Brushes.Black, 10, y);
            y += 20;
            g.DrawString($"TOTAL: {_venta.TotalVenta:N0}", font, Brushes.Black, 10, y);
            y += 20;
            g.DrawString("----------------------------------", font, Brushes.Black, 10, y);
            y += 20;
            g.DrawString("¡GRACIAS POR SU COMPRA!", font, Brushes.Black, 10, y);
        }
    }
}
