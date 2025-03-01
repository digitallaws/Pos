using Sopromil.Modelo;

namespace Sopromil.Data.Interfaces
{
    public interface IEmpresaRepository
    {
        Task<Empresa> ObtenerDatosEmpresaAsync();
        Task<string> GuardarActualizarEmpresaAsync(Empresa empresa);
    }
}
