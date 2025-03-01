namespace Sopromil.Modelo
{
    public static class SesionActual
    {
        public static int IDUsuario { get; private set; }
        public static string Nombre { get; private set; }
        public static string Rol { get; private set; }
        public static bool EstaAutenticado => IDUsuario > 0;

        /// <summary>
        /// Inicia la sesión estableciendo la información del usuario autenticado.
        /// </summary>
        public static void IniciarSesion(int idUsuario, string nombre, string rol)
        {
            IDUsuario = idUsuario;
            Nombre = nombre;
            Rol = rol;
        }

        /// <summary>
        /// Cierra la sesión limpiando los datos del usuario.
        /// </summary>
        public static void CerrarSesion()
        {
            IDUsuario = 0;
            Nombre = string.Empty;
            Rol = string.Empty;
        }
    }
}
