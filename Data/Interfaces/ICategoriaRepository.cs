using Sopromil.Modelo;

namespace Sopromil.Data.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<string> CrearCategoriaAsync(Categoria categoria);
        Task<List<Categoria>> ObtenerCategoriasAsync();
        Task<string> ActualizarCategoriaAsync(Categoria categoria);
        Task<string> EliminarCategoriaAsync(int idCategoria);
    }
}
