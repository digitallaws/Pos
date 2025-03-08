using Sopromil.Data.Repository;
using Sopromil.Modelo;

namespace Sopromil.Controlador
{
    public class InitialSetupController
    {
        private readonly UsuarioRepository _usuarioRepository;
        private readonly EmpresaRepository _empresaRepository;

        public InitialSetupController()
        {
            _usuarioRepository = new UsuarioRepository();
            _empresaRepository = new EmpresaRepository();
        }

        /// <summary>
        /// Verifica si hay usuarios registrados.
        /// </summary>
        public async Task<string> VerificarUsuariosAsync()
        {
            try
            {
                return await _usuarioRepository.VerificarUsuariosAsync();
            }
            catch (Exception ex)
            {
                LogError("VerificarUsuariosAsync", ex);
                return "Error";
            }
        }

        /// <summary>
        /// Crea el primer usuario inicial (admin).
        /// </summary>
        public async Task<string> CrearUsuarioInicialAsync(string nombre, string login, string password)
        {
            try
            {
                return await _usuarioRepository.CrearUsuarioInicialAsync(nombre, login, password);
            }
            catch (Exception ex)
            {
                LogError("CrearUsuarioInicialAsync", ex);
                return "Error";
            }
        }

        /// <summary>
        /// Registra o actualiza la empresa.
        /// </summary>
        public async Task<string> GuardarEmpresaAsync(Empresa empresa)
        {
            try
            {
                // Verificamos si ya hay empresa registrada.
                var empresaActual = await _empresaRepository.ObtenerEmpresaAsync();
                if (empresaActual == null)
                {
                    return await _empresaRepository.RegistrarEmpresaAsync(empresa);
                }
                else
                {
                    empresa.IDEmpresa = empresaActual.IDEmpresa;  // aseguramos el mismo ID.
                    return await _empresaRepository.ActualizarEmpresaAsync(empresa);
                }
            }
            catch (Exception ex)
            {
                LogError("GuardarEmpresaAsync", ex);
                return "Error";
            }
        }

        /// <summary>
        /// Loguea errores en archivo de texto.
        /// </summary>
        private void LogError(string metodo, Exception ex)
        {
            try
            {
                string rutaLog = "LogErrores.txt";
                string mensaje = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Error en {metodo}: {ex.Message}\n";
                File.AppendAllText(rutaLog, mensaje);
            }
            catch
            {
                // Evitar que un fallo en el log detenga la ejecución.
            }
        }
    }
}
