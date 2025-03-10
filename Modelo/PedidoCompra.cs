namespace Sopromil.Modelo
{
    public class PedidoCompra
    {
        public int IDProducto { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public int Stock { get; set; }
        public decimal PrecioCompra { get; set; }
        public int IDProveedor { get; set; }
        public string NombreProveedor { get; set; }
        public string CiudadProveedor { get; set; }
        public int VentasUltimosDias { get; set; }
        public int CantidadSugerida { get; set; }
        public decimal Total => PrecioCompra * CantidadSugerida; // 🔥 Total automático
    }
}
