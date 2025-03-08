using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;

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

        /// <summary>
        /// Guarda la configuración inicial del sistema (ticket, impresora, lector, copia seguridad).
        /// </summary>
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
                command.Parameters.AddWithValue("@LectorCodigoBarras", lectorCodigoBarras);

                var result = await command.ExecuteScalarAsync();
                return result?.ToString() ?? "Error al guardar configuración.";
            }
        }

        /// <summary>
        /// Crea una copia de seguridad de la base de datos en la ruta especificada.
        /// </summary>
        public async Task<string> CrearCopiaSeguridadAsync(string rutaBackup)
        {
            try
            {
                using (var connection = await GetConnectionAsync())
                using (var command = new SqlCommand($"BACKUP DATABASE [SopromilDB] TO DISK = @Ruta", connection))
                {
                    command.Parameters.AddWithValue("@Ruta", rutaBackup);
                    await command.ExecuteNonQueryAsync();
                    return "Copia de seguridad creada correctamente en " + rutaBackup;
                }
            }
            catch (Exception ex)
            {
                LogError("CrearCopiaSeguridadAsync", ex);
                return $"Error al crear copia de seguridad: {ex.Message}";
            }
        }

        /// <summary>
        /// Guarda errores en un archivo de log.
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
                // Evita que un fallo en el log detenga la ejecución.
            }
        }
    }
}
