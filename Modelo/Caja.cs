namespace Sopromil.Modelo
{
    public class Caja
    {
        public int IDCaja { get; set; } = 1; // Siempre será 1 porque es única
        public string Descripcion { get; set; } = string.Empty;
        public string Impresora { get; set; } = string.Empty;
        public string CopiaSeguridad { get; set; } = string.Empty;
        public string Estado { get; set; } = "Activa"; // Por defecto
        public int UltimaConfiguracionPor { get; set; }
    }

    public class MovimientoCaja
    {
        public int IDMovimiento { get; set; }
        public int IDCaja { get; set; } = 1; // Siempre 1
        public int IDUsuarioApertura { get; set; }
        public DateTime FechaApertura { get; set; }
        public decimal SaldoInicial { get; set; }
        public int? IDUsuarioCierre { get; set; }
        public DateTime? FechaCierre { get; set; }
        public decimal? SaldoFinal { get; set; }
        public decimal? Descuadre { get; set; }
        public string ObservacionesCierre { get; set; } = string.Empty;
        public string Estado { get; set; } = "Abierta";
    }
    public class MovimientoCajaDetalle
    {
        public int IDDetalleMovimiento { get; set; }
        public int IDMovimiento { get; set; }
        public string TipoMovimiento { get; set; } = string.Empty;  // IngresoExtra o EgresoExtra
        public decimal Monto { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaRegistro { get; set; }
    }
}
