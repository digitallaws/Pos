namespace Sopromil.Modelo
{
    public class Empresa
    {
        public int IDEmpresa { get; set; } = 1; // Siempre será 1 (única empresa)
        public string Nombre { get; set; }
        public string NIT { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public byte[] Logo { get; set; }
        public string Moneda { get; set; } = "COP";
    }
}
