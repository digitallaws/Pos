namespace Sopromil.Modelo
{
    public class Usuario
    {
        public int IDUsuario { get; set; }
        public string Nombre { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }
        public string Estado { get; set; } = "Activo";
    }

}
