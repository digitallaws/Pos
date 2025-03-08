namespace Sopromil.Modelo
{
    public class CreditoCliente
    {
        public int IDCredito { get; set; }
        public int IDVenta { get; set; }
        public decimal SaldoPendiente { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Estado { get; set; } = string.Empty;

        // Info adicional de la venta
        public decimal TotalVenta { get; set; }
        public DateTime FechaVenta { get; set; }
        public string TipoPago { get; set; } = string.Empty;
    }

    public class AbonoCliente
    {
        public int IDAbono { get; set; }
        public DateTime FechaAbono { get; set; }
        public decimal MontoAbono { get; set; }
        public string? Observaciones { get; set; }
    }
}
