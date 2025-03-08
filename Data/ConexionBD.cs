using Microsoft.Data.SqlClient;
using Sopromil.Utils; // Asegúrate de agregar el using para que vea ConfigManager

namespace Sopromil.Data
{
    public static class ConexionBD
    {
        // Propiedad para obtener la cadena de conexión, ahora desde ConfigManager
        public static string CadenaConexion
        {
            get
            {
                try
                {
                    // Cargar configuración desde el archivo ini (si no se ha cargado antes)
                    ConfigManager.CargarConfiguracion();

                    // Retorna la cadena desde ConfigManager
                    return ConfigManager.ObtenerCadenaConexion();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al obtener la cadena de conexión desde ConfigManager: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Obtiene una nueva instancia de SqlConnection utilizando la cadena de conexión dinámica.
        /// </summary>
        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(CadenaConexion);
        }

        /// <summary>
        /// Prueba la conexión a la base de datos.
        /// </summary>
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
