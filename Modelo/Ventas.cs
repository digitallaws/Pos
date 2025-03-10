namespace Sopromil.Modelo
{
    public class Venta
    {
        public int IDVenta { get; set; }
        public int IDCliente { get; set; }
        public string NombreCliente { get; set; }
        public DateTime FechaVenta { get; set; } = DateTime.Now;
        public decimal TotalVenta { get; set; }
        public decimal MontoAbonado { get; set; }
        public decimal SaldoPendiente => TotalVenta - MontoAbonado;
        public string Estado { get; set; }
        public string TipoVenta { get; set; }
        public DateTime? FechaEstimadaPago { get; set; }

        // ✅ Estos valores vienen directamente de SQL Server, no se recalculan en C#
        public decimal TotalCompra { get; set; }
        public decimal Utilidad { get; set; }

        public List<DetalleVenta> Detalles { get; set; } = new List<DetalleVenta>();
    }
}
