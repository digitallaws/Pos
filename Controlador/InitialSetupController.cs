using Sopromil.Data.Repository;
using Sopromil.Utils;

namespace Sopromil.Controlador
{
    public class InitialSetupController
    {
        private readonly UsuarioRepository _usuarioRepository;
        private readonly EmpresaRepository _empresaRepository;
        private readonly InitialSetupRepository _setupRepository;

        public InitialSetupController()
        {
            _usuarioRepository = new UsuarioRepository();
            _empresaRepository = new EmpresaRepository();
            _setupRepository = new InitialSetupRepository();
        }

        public async Task<string> VerificarUsuariosAsync()
        {
            try
            {
                return await _usuarioRepository.VerificarUsuariosAsync();
            }
            catch (Exception ex)
            {
                return $"❌ Error al verificar usuarios: {ex.Message}";
            }
        }

        public async Task<string> CrearUsuarioInicialAsync(string nombre, string login, string password)
        {
            try
            {
                return await _usuarioRepository.CrearUsuarioInicialAsync(nombre, login, password);
            }
            catch (Exception ex)
            {
                return $"❌ Error al crear usuario inicial: {ex.Message}";
            }
        }

        public async Task<string> GuardarConfiguracionAsync(string agradecimiento, string anuncio, string datosFiscales, string copiaSeguridad, string impresora, string lectorCodigoBarras)
        {
            try
            {
                return await _setupRepository.ConfiguracionInicialAsync(agradecimiento, anuncio, datosFiscales, copiaSeguridad, impresora, lectorCodigoBarras);
            }
            catch (Exception ex)
            {
                return $"❌ Error al guardar configuración: {ex.Message}";
            }
        }

        public async Task<string> CrearCopiaSeguridadAsync(string rutaBackup)
        {
            try
            {
                return await _setupRepository.CrearCopiaSeguridadAsync(rutaBackup);
            }
            catch (Exception ex)
            {
                return $"❌ Error al crear la copia de seguridad: {ex.Message}";
            }
        }

        public string GuardarConfiguracionBD(string servidor, string baseDatos, string tipoAutenticacion, string usuario, string clave)
        {
            try
            {
                ConfigManager.GuardarConfiguracion(servidor, baseDatos, tipoAutenticacion, usuario, clave);
                return "✅ Configuración de la base de datos guardada correctamente.";
            }
            catch (Exception ex)
            {
                return $"❌ Error al guardar configuración de la base de datos: {ex.Message}";
            }
        }

        public bool ProbarConexionBD(out string mensaje)
        {
            try
            {
                return ConfigManager.ProbarConexion(out mensaje);
            }
            catch (Exception ex)
            {
                mensaje = $"❌ Error al probar la conexión: {ex.Message}";
                return false;
            }
        }
    }
}
