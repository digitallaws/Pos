namespace Sopromil.Modelo
{
    public class Producto
    {
        public int IDProducto { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public string UnidadMedida { get; set; }
        public decimal Stock { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public string CodigoBarras { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal Flete { get; set; }
        public decimal Utilidad { get; set; }
        public decimal ValorVenta { get; set; }
        public int IDProveedor { get; set; }
        public string Estado { get; set; }
        public Proveedor Proveedor { get; set; }
    }

}
