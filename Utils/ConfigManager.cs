using Microsoft.Data.SqlClient;
using System.Collections.Specialized;

namespace Sopromil.Utils
{
    public static class ConfigManager
    {
        private static readonly string rutaConfig = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "Sopromil",
            "config.ini"
        );

        private static string Servidor;
        private static string BaseDatos;
        private static string Usuario;
        private static string Clave;
        private static string TipoAutenticacion;

        public static bool ConfiguracionExiste()
        {
            return File.Exists(rutaConfig);
        }

        public static void CargarConfiguracion()
        {
            if (!ConfiguracionExiste())
                throw new Exception("No se encontró el archivo de configuración.");

            var configuracion = new NameValueCollection();

            foreach (var linea in File.ReadAllLines(rutaConfig))
            {
                if (linea.Contains('='))
                {
                    var partes = linea.Split('=');
                    configuracion[partes[0].Trim()] = partes[1].Trim();
                }
            }

            Servidor = configuracion["Servidor"];
            BaseDatos = configuracion["BaseDatos"];
            TipoAutenticacion = configuracion["TipoAutenticacion"];
            Usuario = configuracion["Usuario"];
            Clave = configuracion["Clave"];
        }

        public static void GuardarConfiguracion(string servidor, string baseDatos, string tipoAutenticacion, string usuario, string clave)
        {
            AsegurarDirectorio();

            File.WriteAllLines(rutaConfig, new[]
            {
                "[Conexion]",
                $"Servidor={servidor}",
                $"BaseDatos={baseDatos}",
                $"TipoAutenticacion={tipoAutenticacion}",
                $"Usuario={usuario}",
                $"Clave={clave}"
            });

            // Actualizar en memoria
            Servidor = servidor;
            BaseDatos = baseDatos;
            TipoAutenticacion = tipoAutenticacion;
            Usuario = usuario;
            Clave = clave;
        }

        public static void GuardarConfiguracionEnMemoria(string servidor, string baseDatos, string tipoAutenticacion, string usuario, string clave)
        {
            Servidor = servidor;
            BaseDatos = baseDatos;
            TipoAutenticacion = tipoAutenticacion;
            Usuario = usuario;
            Clave = clave;
        }

        public static string ObtenerCadenaConexion()
        {
            if (TipoAutenticacion == "Windows")
            {
                return $"Server={Servidor};Database={BaseDatos};Trusted_Connection=True;TrustServerCertificate=True;";
            }
            else
            {
                return $"Server={Servidor};Database={BaseDatos};User Id={Usuario};Password={Clave};TrustServerCertificate=True;";
            }
        }


        public static bool ProbarConexion(out string mensaje)
        {
            try
            {
                using (var conexion = new SqlConnection(ObtenerCadenaConexion()))
                {
                    conexion.Open();
                    mensaje = "Conexión exitosa.";
                    return true;
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                return false;
            }
        }

        private static void AsegurarDirectorio()
        {
            string directorio = Path.GetDirectoryName(rutaConfig);
            if (!Directory.Exists(directorio))
            {
                Directory.CreateDirectory(directorio);
            }
        }
    }

}
