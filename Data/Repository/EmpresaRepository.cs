using Microsoft.Data.SqlClient;
using Sopromil.Modelo;
using System.Data;

namespace Sopromil.Data.Repository
{
    public class EmpresaRepository
    {
        public async Task<Empresa> ObtenerEmpresaAsync()
        {
            try
            {
                using (var connection = ConexionBD.ObtenerConexion())
                {
                    await connection.OpenAsync();

                    using (var command = new SqlCommand("ObtenerEmpresa", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new Empresa
                                {
                                    IDEmpresa = reader.GetInt32(reader.GetOrdinal("IDEmpresa")),
                                    Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                    NIT = reader.IsDBNull(reader.GetOrdinal("NIT")) ? null : reader.GetString(reader.GetOrdinal("NIT")),
                                    Direccion = reader.IsDBNull(reader.GetOrdinal("Direccion")) ? null : reader.GetString(reader.GetOrdinal("Direccion")),
                                    Telefono = reader.IsDBNull(reader.GetOrdinal("Telefono")) ? null : reader.GetString(reader.GetOrdinal("Telefono")),
                                    Correo = reader.IsDBNull(reader.GetOrdinal("Correo")) ? null : reader.GetString(reader.GetOrdinal("Correo")),
                                    Logo = reader.IsDBNull(reader.GetOrdinal("Logo")) ? null : (byte[])reader["Logo"],
                                    Moneda = reader.GetString(reader.GetOrdinal("Moneda"))
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener empresa: {ex.Message}");
            }
            return null;
        }

        public async Task<string> RegistrarEmpresaAsync(Empresa empresa)
        {
            try
            {
                using (var connection = ConexionBD.ObtenerConexion())
                {
                    await connection.OpenAsync();

                    using (var command = new SqlCommand("RegistrarEmpresa", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        MapearParametrosEmpresa(command, empresa);

                        return (string)await command.ExecuteScalarAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar empresa: {ex.Message}");
                return "Error";
            }
        }

        public async Task<string> ActualizarEmpresaAsync(Empresa empresa)
        {
            try
            {
                using (var connection = ConexionBD.ObtenerConexion())
                {
                    await connection.OpenAsync();

                    using (var command = new SqlCommand("ActualizarEmpresa", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        MapearParametrosEmpresa(command, empresa);

                        return (string)await command.ExecuteScalarAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar empresa: {ex.Message}");
                return "Error";
            }
        }

        private void MapearParametrosEmpresa(SqlCommand command, Empresa empresa)
        {
            command.Parameters.AddWithValue("@Nombre", empresa.Nombre);
            command.Parameters.AddWithValue("@NIT", (object)empresa.NIT ?? DBNull.Value);
            command.Parameters.AddWithValue("@Direccion", (object)empresa.Direccion ?? DBNull.Value);
            command.Parameters.AddWithValue("@Telefono", (object)empresa.Telefono ?? DBNull.Value);
            command.Parameters.AddWithValue("@Correo", (object)empresa.Correo ?? DBNull.Value);
            command.Parameters.AddWithValue("@Logo", (object)empresa.Logo ?? DBNull.Value);
            command.Parameters.AddWithValue("@Moneda", empresa.Moneda);
        }
    }
}
