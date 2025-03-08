namespace Sopromil.Modelo
{
    public class Venta
    {
        public int IDVenta { get; set; }
        public int IDCliente { get; set; }
        public DateTime FechaVenta { get; set; } = DateTime.Now;
        public decimal TotalVenta { get; set; }
        public string Estado { get; set; } // Puede ser "Pendiente", "Pagada", "Cancelada"
        public string TipoVenta { get; set; } // "Contado" o "Crédito"
        public DateTime? FechaEstimadaPago { get; set; }

        public List<DetalleVenta> Detalles { get; set; } = new List<DetalleVenta>(); // Relación con los detalles
    }
}
