namespace Sopromil.Modelo
{
    public class Compra
    {
        public int IDCompra { get; set; }
        public int IDProveedor { get; set; }
        public string NombreProveedor { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal TotalCompra { get; set; }
        public decimal Flete { get; set; }
        public string Estado { get; set; }
    }
}
