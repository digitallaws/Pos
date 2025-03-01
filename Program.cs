using Sopromil.Controlador;
using Sopromil.Vista.Configuracion;
using Sopromil.Vista.Login;
using Sopromil.Vista.Usuarios;
using System.Globalization;

namespace Sopromil
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.GetCultureInfo("es-CO");
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.GetCultureInfo("es-CO");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Ejecutar la lógica de inicio en un método síncrono
            RunApplication();
        }

        private static void RunApplication()
        {
            var initialSetupController = new InitialSetupController();

            // Ejecutar la lógica asincrónica y esperar el resultado antes de iniciar Application.Run()
            var resultado = Task.Run(async () => await initialSetupController.VerificarUsuariosAsync()).GetAwaiter().GetResult();

            if (resultado == "SinUsuarios")
            {
                // No hay usuarios, mostrar la vista de creación de usuario
                Application.Run(new CrearUsuario(initialSetupController));
            }
            else if (resultado == "UsuariosExistentes")
            {
                // Usuarios existentes, mostrar la vista de selección de perfil
                Application.Run(new SeleccionPerfil());
            }
            else
            {
                // Manejo de resultados inesperados
                MessageBox.Show("Error al verificar usuarios. Intenta nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
