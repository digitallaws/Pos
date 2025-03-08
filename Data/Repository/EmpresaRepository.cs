using Microsoft.Data.SqlClient;
using Sopromil.Modelo;
using System.Data;

namespace Sopromil.Data.Repository
{
    public class EmpresaRepository
    {
        private async Task<SqlConnection> GetConnectionAsync()
        {
            var connection = ConexionBD.ObtenerConexion();
            await connection.OpenAsync();
            return connection;
        }

        public async Task<string> RegistrarActualizarEmpresaAsync(Empresa empresa)
        {
            string resultado = "Error";

            try
            {
                using (var connection = await GetConnectionAsync())
                using (var command = new SqlCommand("RegistrarActualizarEmpresa", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Nombre", empresa.Nombre);
                    command.Parameters.AddWithValue("@NIT", empresa.NIT);
                    command.Parameters.AddWithValue("@Direccion", empresa.Direccion);
                    command.Parameters.AddWithValue("@Telefono", empresa.Telefono);
                    command.Parameters.AddWithValue("@Correo", empresa.Correo);
                    command.Parameters.AddWithValue("@Logo", (object)empresa.Logo ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Moneda", empresa.Moneda);

                    // 🔥 Agregar parámetro de salida
                    var mensajeSalida = new SqlParameter("@MensajeSalida", SqlDbType.VarChar, 100)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(mensajeSalida);

                    await command.ExecuteNonQueryAsync();
                    resultado = mensajeSalida.Value.ToString(); // 🔥 Obtener el mensaje
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al registrar/actualizar empresa: {ex.Message}");
            }

            return resultado;
        }

        public async Task<Empresa> ObtenerEmpresaAsync()
        {
            Empresa empresa = null;

            try
            {
                using (var connection = await GetConnectionAsync())
                using (var command = new SqlCommand("ObtenerEmpresa", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            empresa = new Empresa
                            {
                                IDEmpresa = reader.GetInt32(reader.GetOrdinal("IDEmpresa")),
                                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                NIT = reader.GetString(reader.GetOrdinal("NIT")),
                                Direccion = reader.GetString(reader.GetOrdinal("Direccion")),
                                Telefono = reader.GetString(reader.GetOrdinal("Telefono")),
                                Correo = reader.GetString(reader.GetOrdinal("Correo")),
                                Logo = reader.IsDBNull(reader.GetOrdinal("Logo")) ? null : (byte[])reader["Logo"],
                                Moneda = reader.GetString(reader.GetOrdinal("Moneda"))
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al obtener empresa: {ex.Message}");
            }

            return empresa;
        }

        public async Task<string> EliminarEmpresaAsync()
        {
            string resultado = "Error";

            try
            {
                using (var connection = await GetConnectionAsync())
                using (var command = new SqlCommand("EliminarEmpresa", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    resultado = (string)await command.ExecuteScalarAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al eliminar empresa: {ex.Message}");
            }

            return resultado;
        }
    }
}
