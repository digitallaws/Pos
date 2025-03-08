using Microsoft.Data.SqlClient;
using Sopromil.Modelo;
using System.Data;

namespace Sopromil.Data.Repository
{
    public class ProveedorRepository
    {
        public async Task<List<Proveedor>> ObtenerProveedoresAsync(bool soloActivos = false)
        {
            var lista = new List<Proveedor>();

            try
            {
                using (var connection = ConexionBD.ObtenerConexion())
                {
                    await connection.OpenAsync();

                    using (var command = new SqlCommand("ObtenerProveedores", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@SoloActivos", soloActivos ? 1 : 0);

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                lista.Add(new Proveedor
                                {
                                    IDProveedor = reader.GetInt32(reader.GetOrdinal("IDProveedor")),
                                    Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                    IdentificadorFiscal = reader.IsDBNull(reader.GetOrdinal("IdentificadorFiscal")) ? null : reader.GetString(reader.GetOrdinal("IdentificadorFiscal")),
                                    Telefono = reader.IsDBNull(reader.GetOrdinal("Telefono")) ? null : reader.GetString(reader.GetOrdinal("Telefono")),
                                    Direccion = reader.IsDBNull(reader.GetOrdinal("Direccion")) ? null : reader.GetString(reader.GetOrdinal("Direccion")),
                                    Ciudad = reader.IsDBNull(reader.GetOrdinal("Ciudad")) ? null : reader.GetString(reader.GetOrdinal("Ciudad")),
                                    Estado = reader.GetString(reader.GetOrdinal("Estado"))
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener proveedores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return lista;
        }

        public async Task CrearProveedorAsync(Proveedor proveedor)
        {
            try
            {
                using (var connection = ConexionBD.ObtenerConexion())
                {
                    await connection.OpenAsync();

                    using (var command = new SqlCommand("CrearProveedor", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Nombre", proveedor.Nombre);
                        command.Parameters.AddWithValue("@IdentificadorFiscal", (object)proveedor.IdentificadorFiscal ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Telefono", (object)proveedor.Telefono ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Direccion", (object)proveedor.Direccion ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Ciudad", (object)proveedor.Ciudad ?? DBNull.Value);

                        int filasAfectadas = await command.ExecuteNonQueryAsync();

                        if (filasAfectadas > 0)
                            MessageBox.Show("Proveedor creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("No se pudo crear el proveedor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear proveedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task ActualizarProveedorAsync(Proveedor proveedor)
        {
            try
            {
                using (var connection = ConexionBD.ObtenerConexion())
                {
                    await connection.OpenAsync();

                    using (var command = new SqlCommand("ActualizarProveedor", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@IDProveedor", proveedor.IDProveedor);
                        command.Parameters.AddWithValue("@Nombre", proveedor.Nombre);
                        command.Parameters.AddWithValue("@IdentificadorFiscal", (object)proveedor.IdentificadorFiscal ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Telefono", (object)proveedor.Telefono ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Direccion", (object)proveedor.Direccion ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Ciudad", (object)proveedor.Ciudad ?? DBNull.Value);

                        int filasAfectadas = await command.ExecuteNonQueryAsync();

                        if (filasAfectadas > 0)
                            MessageBox.Show("Proveedor actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("No se pudo actualizar el proveedor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar proveedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task CambiarEstadoProveedorAsync(int idProveedor, string nuevoEstado)
        {
            try
            {
                using (var connection = ConexionBD.ObtenerConexion())
                {
                    await connection.OpenAsync();

                    using (var command = new SqlCommand("CambiarEstadoProveedor", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@IDProveedor", idProveedor);
                        command.Parameters.AddWithValue("@Estado", nuevoEstado);

                        int filasAfectadas = await command.ExecuteNonQueryAsync();

                        if (filasAfectadas > 0)
                            MessageBox.Show($"Proveedor cambiado a estado: {nuevoEstado}.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("No se pudo cambiar el estado del proveedor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar estado del proveedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task EliminarProveedorLogicoAsync(int idProveedor)
        {
            try
            {
                using (var connection = ConexionBD.ObtenerConexion())
                {
                    await connection.OpenAsync();

                    using (var command = new SqlCommand("EliminarProveedorLogico", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@IDProveedor", idProveedor);

                        int filasAfectadas = await command.ExecuteNonQueryAsync();

                        if (filasAfectadas > 0)
                            MessageBox.Show("Proveedor eliminado correctamente (lógica).", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("No se pudo eliminar el proveedor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar proveedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
