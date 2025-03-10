namespace Sopromil.Modelo
{
    public class DetalleCompra
    {
        public int IDDetalleCompra { get; set; }
        public int IDCompra { get; set; }
        public int IDProducto { get; set; }
        public string NombreProducto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Total => Cantidad * PrecioUnitario;
    }
}
