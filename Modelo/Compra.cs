namespace Sopromil.Modelo
{
    public class Compra
    {
        public int IDCompra { get; set; }
        public int IDProveedor { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal TotalCompra { get; set; }
        public decimal SaldoPendiente { get; set; }
        public decimal Flete { get; set; }
        public string Estado { get; set; }

        // Relación opcional para mostrar el nombre del proveedor en vistas
        public string NombreProveedor { get; set; }
    }
}
