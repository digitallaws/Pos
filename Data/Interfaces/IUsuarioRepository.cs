using Sopromil.Modelo;

namespace Sopromil.Data.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<(string Resultado, int? IDUsuario, string Nombre, string Rol)> LoginUsuarioAsync(string login, string password);
        Task<List<Usuario>> ObtenerUsuariosActivosAsync();
        Task<List<Usuario>> ObtenerUsuariosAsync();
        Task CrearUsuarioAsync(Usuario usuario);
        Task ActualizarUsuarioAsync(Usuario usuario);
        Task CambiarEstadoUsuarioAsync(int idUsuario, string estado);
    }
}
