using Sopromil.Data.Repository;
using Sopromil.Modelo;

namespace Sopromil.Controlador
{
    public class EmpresaController
    {
        private readonly EmpresaRepository _empresaRepository;

        public EmpresaController()
        {
            _empresaRepository = new EmpresaRepository();
        }

        public async Task<Empresa> ObtenerEmpresaAsync()
        {
            return await _empresaRepository.ObtenerEmpresaAsync();
        }

        public async Task<string> RegistrarEmpresaAsync(Empresa empresa)
        {
            return await _empresaRepository.RegistrarEmpresaAsync(empresa);
        }

        public async Task<string> ActualizarEmpresaAsync(Empresa empresa)
        {
            return await _empresaRepository.ActualizarEmpresaAsync(empresa);
        }
    }
}
