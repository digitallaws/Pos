using Microsoft.Data.SqlClient;
using Sopromil.Data;
using Sopromil.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

public class UsuarioRepository
{
    /// <summary>
    /// Obtiene la conexión a la base de datos asegurando que esté abierta.
    /// </summary>
    private async Task<SqlConnection> GetConnectionAsync()
    {
        try
        {
            var connection = ConexionBD.ObtenerConexion();
            await connection.OpenAsync();
            return connection;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error al abrir la conexión a la base de datos: {ex.Message}");
            return null;
        }
    }

    /// <summary>
    /// Verifica si existen usuarios en la base de datos.
    /// </summary>
    public async Task<string> VerificarUsuariosAsync()
    {
        try
        {
            using (var connection = await GetConnectionAsync())
            {
                if (connection == null) return "Error";

                using (var command = new SqlCommand("VerificarUsuarios", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    var result = await command.ExecuteScalarAsync();
                    return result?.ToString() ?? "Error";
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error al verificar usuarios: {ex.Message}");
            return "Error";
        }
    }

    /// <summary>
    /// Crea el usuario inicial en la base de datos.
    /// </summary>
    public async Task<string> CrearUsuarioInicialAsync(string nombre, string login, string password)
    {
        try
        {
            using (var connection = await GetConnectionAsync())
            {
                if (connection == null) return "Error";

                using (var command = new SqlCommand("CrearUsuarioInicial", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Login", login);
                    command.Parameters.AddWithValue("@Password", password);

                    var result = await command.ExecuteScalarAsync();
                    return result?.ToString() ?? "Error";
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error al crear usuario inicial: {ex.Message}");
            return "Error";
        }
    }

    /// <summary>
    /// Realiza el login de un usuario y devuelve su información.
    /// </summary>
    public async Task<(string Resultado, int? IDUsuario, string Nombre, string Rol)> LoginUsuarioAsync(string login, string password)
    {
        try
        {
            using (var connection = await GetConnectionAsync())
            {
                if (connection == null) return ("Error", null, null, null);

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
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error en login de usuario: {ex.Message}");
        }

        return ("Error", null, null, null);
    }

    /// <summary>
    /// Obtiene la lista de usuarios registrados en la base de datos.
    /// </summary>
    public async Task<List<Usuario>> ObtenerUsuariosAsync(bool soloActivos = false)
    {
        var usuarios = new List<Usuario>();

        try
        {
            using (var connection = await GetConnectionAsync())
            {
                if (connection == null) return usuarios;

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
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error al obtener usuarios: {ex.Message}");
        }

        return usuarios;
    }

    /// <summary>
    /// Crea un nuevo usuario en la base de datos.
    /// </summary>
    public async Task<bool> CrearUsuarioAsync(Usuario usuario)
    {
        try
        {
            using (var connection = await GetConnectionAsync())
            {
                if (connection == null) return false;

                using (var command = new SqlCommand("InsertarUsuario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    command.Parameters.AddWithValue("@Login", usuario.Login);
                    command.Parameters.AddWithValue("@Password", usuario.Password);
                    command.Parameters.AddWithValue("@Rol", usuario.Rol);
                    command.Parameters.AddWithValue("@Estado", usuario.Estado);

                    await command.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error al crear usuario: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// Actualiza los datos de un usuario existente.
    /// </summary>
    public async Task<bool> ActualizarUsuarioAsync(Usuario usuario)
    {
        try
        {
            using (var connection = await GetConnectionAsync())
            {
                if (connection == null) return false;

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
                    return true;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error al actualizar usuario: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// Cambia el estado de un usuario a Activo/Inactivo.
    /// </summary>
    public async Task<bool> CambiarEstadoUsuarioAsync(int idUsuario, string estado)
    {
        try
        {
            using (var connection = await GetConnectionAsync())
            {
                if (connection == null) return false;

                using (var command = new SqlCommand("CambiarEstadoUsuario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDUsuario", idUsuario);
                    command.Parameters.AddWithValue("@Estado", estado);

                    await command.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error al cambiar estado del usuario: {ex.Message}");
            return false;
        }
    }
}
