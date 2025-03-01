using Microsoft.Data.SqlClient;
using Sopromil.Data.Interfaces;
using Sopromil.Modelo;
using System.Data;

namespace Sopromil.Data.Repository
{
    public class EmpresaRepository : IEmpresaRepository
    {
        public async Task<Empresa> ObtenerDatosEmpresaAsync()
        {
            Empresa empresa = null;

            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("ObtenerDatosEmpresa", connection))
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
                                RUC = reader.GetString(reader.GetOrdinal("RUC")),
                                Direccion = reader.GetString(reader.GetOrdinal("Direccion")),
                                Telefono = reader.GetString(reader.GetOrdinal("Telefono")),
                                Correo = reader.GetString(reader.GetOrdinal("Correo")),
                                Moneda = reader.GetString(reader.GetOrdinal("Moneda")),
                                Logo = reader["Logo"] as byte[]
                            };
                        }
                    }
                }
            }

            return empresa;
        }

        public async Task<string> GuardarActualizarEmpresaAsync(Empresa empresa)
        {
            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("GuardarActualizarEmpresa", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Nombre", empresa.Nombre);
                    command.Parameters.AddWithValue("@RUC", empresa.RUC);
                    command.Parameters.AddWithValue("@Direccion", empresa.Direccion);
                    command.Parameters.AddWithValue("@Telefono", empresa.Telefono);
                    command.Parameters.AddWithValue("@Correo", empresa.Correo);
                    command.Parameters.AddWithValue("@Moneda", empresa.Moneda);
                    command.Parameters.AddWithValue("@Logo", (object)empresa.Logo ?? DBNull.Value);

                    var resultado = await command.ExecuteScalarAsync();
                    return resultado.ToString();
                }
            }
        }
    }
}
