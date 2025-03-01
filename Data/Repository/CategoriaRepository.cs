using Microsoft.Data.SqlClient;
using Sopromil.Data.Interfaces;
using Sopromil.Modelo;
using System.Data;

namespace Sopromil.Data.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        public async Task<string> CrearCategoriaAsync(Categoria categoria)
        {
            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("CrearCategoria", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Nombre", categoria.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", categoria.Descripcion);

                    var resultado = await command.ExecuteScalarAsync();
                    return resultado.ToString();
                }
            }
        }

        public async Task<List<Categoria>> ObtenerCategoriasAsync()
        {
            var categorias = new List<Categoria>();

            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("ObtenerCategorias", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            categorias.Add(new Categoria
                            {
                                IDCategoria = reader.GetInt32(reader.GetOrdinal("IDCategoria")),
                                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                Descripcion = reader.GetString(reader.GetOrdinal("Descripcion"))
                            });
                        }
                    }
                }
            }

            return categorias;
        }

        public async Task<string> ActualizarCategoriaAsync(Categoria categoria)
        {
            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("ActualizarCategoria", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDCategoria", categoria.IDCategoria);
                    command.Parameters.AddWithValue("@Nombre", categoria.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", categoria.Descripcion);

                    var resultado = await command.ExecuteScalarAsync();
                    return resultado.ToString();
                }
            }
        }

        public async Task<string> EliminarCategoriaAsync(int idCategoria)
        {
            using (var connection = ConexionBD.ObtenerConexion())
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("EliminarCategoria", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDCategoria", idCategoria);

                    var resultado = await command.ExecuteScalarAsync();
                    return resultado.ToString();
                }
            }
        }
    }
}
