using Sopromil.Controlador;
using Sopromil.Utils;
using Sopromil.Vista.Configuracion;
using Sopromil.Vista.Login;
using Sopromil.Vista.Usuarios;
using System.Globalization;

namespace Sopromil
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                ConfigManager.CargarConfiguracion(); // Carga la configuración desde el archivo
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se encontró configuración. Debe configurar la conexión.",
                    "Configuración Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                Application.Run(new FrmConfiguracion()); // 🔥 Abre FrmConfiguracion si falla
                return;
            }

            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.GetCultureInfo("es-CO");
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.GetCultureInfo("es-CO");

            RunApplication();
        }


        private static void RunApplication()
        {
            if (!ConfigManager.ProbarConexion(out string mensajeConexion))
            {
                MessageBox.Show($"Error al conectar a la base de datos:\n{mensajeConexion}",
                                "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var initialSetupController = new InitialSetupController();
            var resultado = Task.Run(async () => await initialSetupController.VerificarUsuariosAsync()).GetAwaiter().GetResult();

            if (resultado == "SinUsuarios")
            {
                Application.Run(new CrearUsuario(initialSetupController));
            }
            else if (resultado == "UsuariosExistentes")
            {
                Application.Run(new SeleccionPerfil());
            }
            else
            {
                MessageBox.Show("Error al verificar usuarios. Intenta nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
