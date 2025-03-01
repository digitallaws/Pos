using Sopromil.Data.Interfaces;
using Sopromil.Data.Repository;
using Sopromil.Modelo;

namespace Sopromil.Controlador
{
    public class EmpresaController
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaController()
        {
            _empresaRepository = new EmpresaRepository();
        }

        public async Task<Empresa> ObtenerDatosEmpresaAsync()
        {
            try
            {
                return await _empresaRepository.ObtenerDatosEmpresaAsync();
            }
            catch
            {
                MessageBox.Show("Error al obtener los datos de la empresa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task GuardarActualizarEmpresaAsync(Empresa empresa)
        {
            try
            {
                var resultado = await _empresaRepository.GuardarActualizarEmpresaAsync(empresa);

                if (resultado == "EmpresaActualizada")
                    MessageBox.Show("Empresa actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (resultado == "EmpresaCreada")
                    MessageBox.Show("Empresa creada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Error al guardar la empresa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("Error al guardar los datos de la empresa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
