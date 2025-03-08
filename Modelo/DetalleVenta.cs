namespace Sopromil.Modelo
{
    public class DetalleVenta
    {
        public int IDDetalleVenta { get; set; }
        public int IDVenta { get; set; }
        public int IDProducto { get; set; }
        public string NombreProducto { get; set; } // 🔥 Se agrega el nombre del producto
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Total => Cantidad * PrecioUnitario;
    }

}
