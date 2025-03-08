using Sopromil.Data.Repository;
using Sopromil.Modelo;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sopromil.Controlador
{
    public class EmpresaController
    {
        private readonly EmpresaRepository _empresaRepository;

        public EmpresaController()
        {
            _empresaRepository = new EmpresaRepository();
        }

        public async Task<string> RegistrarActualizarEmpresaAsync(Empresa empresa)
        {
            string validacion = ValidarEmpresa(empresa);
            if (validacion != null)
            {
                return validacion; // Retorna el error si hay validaciones fallidas
            }

            return await _empresaRepository.RegistrarActualizarEmpresaAsync(empresa);
        }

        public async Task<Empresa> ObtenerEmpresaAsync()
        {
            return await _empresaRepository.ObtenerEmpresaAsync();
        }

        public async Task<string> EliminarEmpresaAsync()
        {
            return await _empresaRepository.EliminarEmpresaAsync();
        }

        /// <summary>
        /// Método para validar los datos de la empresa antes de guardarlos en la base de datos.
        /// </summary>
        /// <param name="empresa">Objeto Empresa</param>
        /// <returns>Mensaje de error si hay validaciones fallidas, de lo contrario NULL</returns>
        private string ValidarEmpresa(Empresa empresa)
        {
            if (string.IsNullOrWhiteSpace(empresa.Nombre))
            {
                return "El nombre de la empresa es obligatorio.";
            }

            if (string.IsNullOrWhiteSpace(empresa.NIT))
            {
                return "El identificador fiscal (NIT) es obligatorio.";
            }

            if (!string.IsNullOrWhiteSpace(empresa.Correo) && !EsCorreoValido(empresa.Correo))
            {
                return "El formato del correo electrónico no es válido.";
            }

            if (!string.IsNullOrWhiteSpace(empresa.Telefono) && !EsNumeroValido(empresa.Telefono))
            {
                return "El teléfono solo debe contener números.";
            }

            return null; // No hay errores
        }

        /// <summary>
        /// Método para validar el formato de un correo electrónico.
        /// </summary>
        private bool EsCorreoValido(string correo)
        {
            return Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        /// <summary>
        /// Método para validar que un número de teléfono solo contenga dígitos.
        /// </summary>
        private bool EsNumeroValido(string numero)
        {
            return Regex.IsMatch(numero, @"^\d+$");
        }
    }
}
