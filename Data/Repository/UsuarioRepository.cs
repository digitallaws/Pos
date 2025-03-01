using Microsoft.Data.SqlClient;
using Sopromil.Data.Interfaces;
using Sopromil.Modelo;
using System.Data;

namespace Sopromil.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public async Task<(string Resultado, int? IDUsuario, string Nombre, string Rol)> LoginUsuarioAsync(string login, string password)
        {
            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();

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
        }

        public async Task<List<Usuario>> ObtenerUsuariosActivosAsync()
        {
            var listaUsuarios = new List<Usuario>();

            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("CargarUsuariosActivos", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var usuario = new Usuario
                            {
                                IDUsuario = reader.GetInt32(reader.GetOrdinal("IDUsuario")),
                                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                Login = reader.GetString(reader.GetOrdinal("Login")),
                                Rol = reader.GetString(reader.GetOrdinal("Rol")),
                                Estado = reader.GetString(reader.GetOrdinal("Estado"))
                            };

                            listaUsuarios.Add(usuario);
                        }
                    }
                }
            }

            return listaUsuarios;
        }

        public async Task<List<Usuario>> ObtenerUsuariosAsync()
        {
            var usuarios = new List<Usuario>();

            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("ObtenerUsuarios", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            usuarios.Add(new Usuario
                            {
                                IDUsuario = reader.GetInt32("IDUsuario"),
                                Nombre = reader.GetString("Nombre"),
                                Login = reader.GetString("Login"),
                                Password = reader.GetString("Password"),
                                Rol = reader.GetString("Rol"),
                                Estado = reader.GetString("Estado")
                            });
                        }
                    }
                }
            }
            return usuarios;
        }

        public async Task CrearUsuarioAsync(Usuario usuario)
        {
            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();
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
        }

        public async Task ActualizarUsuarioAsync(Usuario usuario)
        {
            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();
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
        }

        public async Task CambiarEstadoUsuarioAsync(int idUsuario, string estado)
        {
            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("CambiarEstadoUsuario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDUsuario", idUsuario);
                    command.Parameters.AddWithValue("@Estado", estado);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
