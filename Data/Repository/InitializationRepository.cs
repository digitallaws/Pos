using Microsoft.Data.SqlClient;
using System.Data;

namespace Sopromil.Data.Repository
{
    public class InitialSetupRepository
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
            using (var command = new SqlCommand("dbo.VerificarUsuarios", connection))
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
            using (var command = new SqlCommand("dbo.CrearUsuarioInicial", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@Login", login);
                command.Parameters.AddWithValue("@Password", password);

                var result = await command.ExecuteScalarAsync();
                return result?.ToString();
            }
        }

        // Crear empresa
        public async Task<string> CrearEmpresaAsync(string nombre, string ruc, string direccion, string telefono, string correo, string moneda, byte[] logo)
        {
            using (var connection = await GetConnectionAsync())
            using (var command = new SqlCommand("dbo.CrearEmpresa", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@RUC", ruc);
                command.Parameters.AddWithValue("@Direccion", direccion);
                command.Parameters.AddWithValue("@Telefono", telefono);
                command.Parameters.AddWithValue("@Correo", correo);
                command.Parameters.AddWithValue("@Moneda", moneda);
                command.Parameters.AddWithValue("@Logo", logo);

                var result = await command.ExecuteScalarAsync();
                return result?.ToString();
            }
        }

        // Configuración inicial (ticket, impresora, lector, copia seguridad)
        public async Task<string> ConfiguracionInicialAsync(string agradecimiento, string anuncio, string datosFiscales, string copiaSeguridad, string impresora, string lectorCodigoBarras)
        {
            using (var connection = await GetConnectionAsync())
            using (var command = new SqlCommand("dbo.ConfiguracionInicial", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Agradecimiento", agradecimiento);
                command.Parameters.AddWithValue("@Anuncio", anuncio);
                command.Parameters.AddWithValue("@DatosFiscales", datosFiscales);
                command.Parameters.AddWithValue("@CopiaSeguridad", copiaSeguridad);
                command.Parameters.AddWithValue("@Impresora", impresora);

                var result = await command.ExecuteScalarAsync();
                return result?.ToString();
            }
        }
    }
}
