using Sopromil.Data.Interfaces;
using Sopromil.Data.Repository;
using Sopromil.Modelo;

namespace Sopromil.Controlador
{
    public class CategoriaController
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController()
        {
            _categoriaRepository = new CategoriaRepository();
        }

        public async Task CrearCategoriaAsync(Categoria categoria)
        {
            try
            {
                var resultado = await _categoriaRepository.CrearCategoriaAsync(categoria);
                if (resultado == "CategoriaCreada")
                {
                    MessageBox.Show("Categoría creada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al crear la categoría.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear la categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task<List<Categoria>> ObtenerCategoriasAsync()
        {
            try
            {
                return await _categoriaRepository.ObtenerCategoriasAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener las categorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Categoria>();
            }
        }

        public async Task ActualizarCategoriaAsync(Categoria categoria)
        {
            try
            {
                var resultado = await _categoriaRepository.ActualizarCategoriaAsync(categoria);
                if (resultado == "CategoriaActualizada")
                {
                    MessageBox.Show("Categoría actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al actualizar la categoría.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task EliminarCategoriaAsync(int idCategoria)
        {
            try
            {
                var resultado = await _categoriaRepository.EliminarCategoriaAsync(idCategoria);
                if (resultado == "CategoriaEliminada")
                {
                    MessageBox.Show("Categoría eliminada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al eliminar la categoría.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
