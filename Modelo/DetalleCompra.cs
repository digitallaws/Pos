namespace Sopromil.Modelo
{
    public class DetalleCompra
    {
        public int IDDetalleCompra { get; set; }
        public int IDCompra { get; set; }
        public int IDProducto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Total { get; set; }

        // Relación opcional para mostrar la descripción del producto
        public string DescripcionProducto { get; set; }
    }

}
