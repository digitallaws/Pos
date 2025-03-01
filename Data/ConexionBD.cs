using Microsoft.Data.SqlClient;
using System.Configuration;

namespace Sopromil.Data
{
    public static class ConexionBD
    {
        // Propiedad para obtener la cadena de conexión directamente
        public static string CadenaConexion
        {
            get
            {
                var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString;

                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new Exception("No se encontró una cadena de conexión válida en App.config.");
                }

                return connectionString;
            }
        }

        /// <summary>
        /// Obtiene una nueva instancia de SqlConnection utilizando la cadena de conexión predeterminada.
        /// </summary>
        /// <returns>Una instancia de SqlConnection.</returns>
        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(CadenaConexion);
        }

        /// <summary>
        /// Prueba la conexión a la base de datos.
        /// </summary>
        /// <returns>True si la conexión es exitosa, de lo contrario false.</returns>
        public static bool ProbarConexion()
        {
            try
            {
                using (var connection = ObtenerConexion())
                {
                    connection.Open();
                    return true;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error de SQL: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
