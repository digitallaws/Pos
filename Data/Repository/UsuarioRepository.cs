using Microsoft.Data.SqlClient;
using Sopromil.Data;
using Sopromil.Modelo;
using System.Data;

public class UsuarioRepository
{
    private async Task<SqlConnection> GetConnectionAsync()
    {
        var connection = ConexionBD.ObtenerConexion();
        await connection.OpenAsync();
        return connection;
    }

    // Verificar si existen usuarios
    public async Task<string> VerificarUsuariosAsync()
    {
        using (var connection = await GetConnectionAsync())
        using (var command = new SqlCommand("VerificarUsuarios", connection))
        {
            command.CommandType = CommandType.StoredProcedure;
            var result = await command.ExecuteScalarAsync();
            return result?.ToString();
        }
    }

    // Crear usuario inicial
    public async Task<string> CrearUsuarioInicialAsync(string nombre, string login, string password)
    {
        using (var connection = await GetConnectionAsync())
        using (var command = new SqlCommand("CrearUsuarioInicial", connection))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Nombre", nombre);
            command.Parameters.AddWithValue("@Login", login);
            command.Parameters.AddWithValue("@Password", password);

            var result = await command.ExecuteScalarAsync();
            return result?.ToString();
        }
    }

    // Login de usuario
    public async Task<(string Resultado, int? IDUsuario, string Nombre, string Rol)> LoginUsuarioAsync(string login, string password)
    {
        using (var connection = await GetConnectionAsync())
        using (var command = new SqlCommand("LoginUsuario", connection))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Login", login);
            command.Parameters.AddWithValue("@Password", password);

            using (var reader = await command.ExecuteReaderAsync())
            {
                if (await reader.ReadAsync())
                {
                    string resultado = reader["Resultado"].ToString();

                    if (resultado == "LoginExitoso")
                    {
                        int idUsuario = Convert.ToInt32(reader["IDUsuario"]);
                        string nombre = reader["Nombre"].ToString();
                        string rol = reader["Rol"].ToString();

                        return (resultado, idUsuario, nombre, rol);
                    }
                    else
                    {
                        return (resultado, null, null, null);
                    }
                }
                else
                {
                    return ("Error", null, null, null);
                }
            }
        }
    }

    // Obtener usuarios (todos o solo activos)
    public async Task<List<Usuario>> ObtenerUsuariosAsync(bool soloActivos = false)
    {
        var usuarios = new List<Usuario>();

        using (var connection = await GetConnectionAsync())
        using (var command = new SqlCommand("ObtenerUsuarios", connection))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@SoloActivos", soloActivos);

            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    usuarios.Add(new Usuario
                    {
                        IDUsuario = reader.GetInt32(reader.GetOrdinal("IDUsuario")),
                        Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                        Login = reader.GetString(reader.GetOrdinal("Login")),
                        Password = reader.GetString(reader.GetOrdinal("Password")),
                        Rol = reader.GetString(reader.GetOrdinal("Rol")),
                        Estado = reader.GetString(reader.GetOrdinal("Estado"))
                    });
                }
            }
        }

        return usuarios;
    }

    // Crear nuevo usuario
    public async Task CrearUsuarioAsync(Usuario usuario)
    {
        using (var connection = await GetConnectionAsync())
        using (var command = new SqlCommand("InsertarUsuario", connection))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
            command.Parameters.AddWithValue("@Login", usuario.Login);
            command.Parameters.AddWithValue("@Password", usuario.Password);
            command.Parameters.AddWithValue("@Rol", usuario.Rol);
            command.Parameters.AddWithValue("@Estado", usuario.Estado);

            await command.ExecuteNonQueryAsync();
        }
    }

    // Actualizar usuario existente
    public async Task ActualizarUsuarioAsync(Usuario usuario)
    {
        using (var connection = await GetConnectionAsync())
        using (var command = new SqlCommand("ActualizarUsuario", connection))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDUsuario", usuario.IDUsuario);
            command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
            command.Parameters.AddWithValue("@Login", usuario.Login);
            command.Parameters.AddWithValue("@Password", usuario.Password);
            command.Parameters.AddWithValue("@Rol", usuario.Rol);
            command.Parameters.AddWithValue("@Estado", usuario.Estado);

            await command.ExecuteNonQueryAsync();
        }
    }

    // Cambiar estado de un usuario (Activo/Inactivo)
    public async Task CambiarEstadoUsuarioAsync(int idUsuario, string estado)
    {
        using (var connection = await GetConnectionAsync())
        using (var command = new SqlCommand("CambiarEstadoUsuario", connection))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDUsuario", idUsuario);
            command.Parameters.AddWithValue("@Estado", estado);

            await command.ExecuteNonQueryAsync();
        }
    }
}