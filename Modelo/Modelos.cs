using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sopromil.Modelo
{
    internal class Modelos
    {
    }

    public class Empresa
    {
        public int IDEmpresa { get; set; } = 1;
        public string Nombre { get; set; }
        public string RUC { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public byte[] Logo { get; set; }
        public string Moneda { get; set; }
    }

    public class TicketConfig
    {
        public int IDConfig { get; set; } = 1;
        public int IDEmpresa { get; set; } = 1;
        public string Agradecimiento { get; set; }
        public string Anuncio { get; set; }
        public string DatosFiscales { get; set; }
        public Empresa Empresa { get; set; }
    }

    public class Usuario
    {
        public int IDUsuario { get; set; }
        public string Nombre { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }
        public string Estado { get; set; }
    }

    public class Caja
    {
        public int IDCaja { get; set; } = 1;
        public string Descripcion { get; set; }
        public string Impresora { get; set; }
        public string Estado { get; set; }
    }

    public class MovimientoCaja
    {
        public int IDMovimiento { get; set; }
        public int IDCaja { get; set; } = 1;
        public int IDUsuarioApertura { get; set; }
        public DateTime FechaApertura { get; set; } = DateTime.Now;
        public decimal SaldoInicial { get; set; }
        public int? IDUsuarioCierre { get; set; }
        public DateTime? FechaCierre { get; set; }
        public decimal? SaldoFinal { get; set; }
        public decimal? Descuadre { get; set; }
        public string Estado { get; set; } = "Abierta";
    }

    public class Categoria
    {
        public int IDCategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }

    public class Producto
    {
        public int IDProducto { get; set; }
        public int IDCategoria { get; set; }
        public string Categoria { get; set; }
        public string Descripcion { get; set; }
        public decimal Stock { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public string CodigoBarras { get; set; }
    }

    public class Cliente
    {
        public int IDCliente { get; set; }
        public string Nombre { get; set; }
        public string IdentificadorFiscal { get; set; }
        public string Celular { get; set; }
        public string Estado { get; set; }
    }

    public class Venta
    {
        public int IDVenta { get; set; }
        public int IDCliente { get; set; }
        public DateTime FechaVenta { get; set; } = DateTime.Now;
        public decimal MontoTotal { get; set; }
        public string TipoPago { get; set; }
        public int IDUsuario { get; set; }
    }

    public class DetalleVenta
    {
        public int IDDetalleVenta { get; set; }
        public int IDVenta { get; set; }
        public int IDProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Total => Cantidad * PrecioUnitario;
    }

    public class Credito
    {
        public int IDCredito { get; set; }
        public int IDCliente { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public DateTime FechaVencimiento { get; set; }
        public decimal Total { get; set; }
        public decimal Saldo { get; set; }
        public bool AplicaInteres { get; set; }
        public decimal TasaInteres { get; set; }
        public string Estado { get; set; }  // Pendiente, Cancelado
    }

    public class PagoCredito
    {
        public int IDPago { get; set; }
        public int IDCredito { get; set; }
        public DateTime FechaPago { get; set; } = DateTime.Now;
        public decimal MontoPagado { get; set; }
        public decimal InteresAplicado { get; set; }
    }

    public class ProductoVencimiento
    {
        public int IDProducto { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal PrecioVenta { get; set; }
    }

    public class CreditoPendiente
    {
        public int IDCredito { get; set; }
        public string Cliente { get; set; }
        public decimal Total { get; set; }
        public decimal Saldo { get; set; }
        public DateTime FechaVencimiento { get; set; }
    }

    public class ProductoInventario
    {
        public int IDProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal Stock { get; set; }
        public decimal StockMinimo { get; set; }
    }

    public class ProductoProximoVencer
    {
        public int IDProducto { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int DiasRestantes { get; set; }
    }

    public class MovimientoInventario
    {
        public int IDMovimiento { get; set; }
        public string Producto { get; set; }
        public decimal Cantidad { get; set; }
        public string TipoMovimiento { get; set; }
        public string Motivo { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public string Usuario { get; set; }
    }

    public class VentaTemporal
    {
        public int? IdCliente { get; set; }
        public List<DetalleTemporal> Detalles { get; set; } = new List<DetalleTemporal>();
        public decimal Total => Detalles.Sum(d => d.Subtotal);
    }

    public class DetalleTemporal
    {
        public int IdProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Subtotal => Precio * Cantidad;
    }

}
