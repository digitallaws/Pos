using Sopromil.Modelo;

namespace Sopromil.Controlador
{
    public class UsuarioController
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        public async Task<bool> LoginUsuarioAsync(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Por favor, ingrese el usuario y la contraseña.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            var (resultado, idUsuario, nombre, rol) = await _usuarioRepository.LoginUsuarioAsync(login, password);

            switch (resultado)
            {
                case "LoginExitoso":
                    SesionActual.IniciarSesion(idUsuario.Value, nombre, rol);
                    return true;

                case "CredencialesIncorrectas":
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;

                case "UsuarioInactivo":
                    MessageBox.Show("El usuario está inactivo. Contacte al administrador.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;

                default:
                    MessageBox.Show("Ocurrió un error al iniciar sesión. Inténtelo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
            }
        }

        public async Task<List<Usuario>> ObtenerUsuariosActivosAsync()
        {
            try
            {
                return await _usuarioRepository.ObtenerUsuariosAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Usuario>();
            }
        }

        public async Task<List<Usuario>> ObtenerUsuariosAsync()
        {
            return await _usuarioRepository.ObtenerUsuariosAsync();
        }

        public async Task CrearUsuarioAsync(Usuario usuario)
        {
            await _usuarioRepository.CrearUsuarioAsync(usuario);
        }

        public async Task ActualizarUsuarioAsync(Usuario usuario)
        {
            await _usuarioRepository.ActualizarUsuarioAsync(usuario);
        }

        public async Task CambiarEstadoUsuarioAsync(int idUsuario, string estado)
        {
            await _usuarioRepository.CambiarEstadoUsuarioAsync(idUsuario, estado);
        }
    }
}
