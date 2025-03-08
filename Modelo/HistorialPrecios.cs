namespace Sopromil.Modelo
{
    public class HistorialPrecios
    {
        public int IDHistorial { get; set; }
        public int IDProducto { get; set; }
        public DateTime FechaCambio { get; set; }
        public decimal PrecioCompraAnterior { get; set; }
        public decimal PrecioCompraNuevo { get; set; }
        public decimal PrecioVentaAnterior { get; set; }
        public decimal PrecioVentaNuevo { get; set; }
        public string Motivo { get; set; }
    }
}

