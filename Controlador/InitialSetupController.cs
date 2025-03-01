using Sopromil.Data.Repository;

namespace Sopromil.Controlador
{
    public class InitialSetupController
    {
        private readonly InitialSetupRepository _repository;

        public InitialSetupController()
        {
            _repository = new InitialSetupRepository();
        }

        public async Task<string> VerificarUsuariosAsync()
        {
            var resultado = await _repository.VerificarUsuariosAsync();
            return resultado; // Retorna el resultado al Program.cs para que decida qué vista abrir
        }

        public async Task CrearUsuarioInicialAsync(string nombre, string login, string password)
        {
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var resultado = await _repository.CrearUsuarioInicialAsync(nombre, login, password);

            if (resultado == "UsuarioInicialCreado")
            {
                MessageBox.Show("Usuario creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (resultado == "UsuarioYaExiste")
            {
                MessageBox.Show("El usuario ya existe. Por favor, elija otro nombre de usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show($"Resultado inesperado: {resultado}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task CrearEmpresaAsync(string nombre, string ruc, string direccion, string telefono, string correo, string moneda, byte[] logo)
        {
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(ruc))
            {
                MessageBox.Show("El nombre y RUC son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var resultado = await _repository.CrearEmpresaAsync(nombre, ruc, direccion, telefono, correo, moneda, logo);

            if (resultado == "EmpresaCreada")
            {
                MessageBox.Show("Empresa creada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (resultado == "EmpresaActualizada")
            {
                MessageBox.Show("Empresa actualizada exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Resultado inesperado: {resultado}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task ConfiguracionInicialAsync(string agradecimiento, string anuncio, string datosFiscales, string copiaSeguridad, string impresora, string lectorCodigoBarras)
        {
            if (string.IsNullOrWhiteSpace(impresora))
            {
                MessageBox.Show("El nombre de la impresora es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var resultado = await _repository.ConfiguracionInicialAsync(agradecimiento, anuncio, datosFiscales, copiaSeguridad, impresora, lectorCodigoBarras);

            if (resultado == "ConfiguracionInicialCompletada")
            {
                MessageBox.Show("Configuración inicial completada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Resultado inesperado: {resultado}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
