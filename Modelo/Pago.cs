namespace Sopromil.Modelo
{
    public class Pago
    {
        public int IDPago { get; set; }
        public int IDCliente { get; set; }
        public decimal MontoAbonado { get; set; }
        public DateTime FechaPago { get; set; } = DateTime.Now;
    }
}

