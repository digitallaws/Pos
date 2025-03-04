using Sopromil.Controlador;
using Sopromil.Modelo;
using System.Data;

namespace Sopromil.Vista.Productos
{
    public partial class Categorias : Form
    {
        private readonly CategoriaController _categoriaController;

        public Categorias()
        {
            InitializeComponent();
            _categoriaController = new CategoriaController();
            CargarCategorias();
            dtCategorias.CellClick += DtCategorias_CellClick;
            dtCategorias.CellFormatting += DtCategorias_CellFormatting;

            // Inicializar el Label oculto para ID
            lbId.Visible = false;
            btnActualizar.Visible = false;
        }

        // ✅ Cargar categorías al iniciar
        private async void CargarCategorias()
        {
            var categorias = await _categoriaController.ObtenerCategoriasAsync();
            ConfigurarDataGrid(categorias);
        }

        // ✅ Configurar el DataGridView
        private void ConfigurarDataGrid(List<Categoria> categorias)
        {
            dtCategorias.Columns.Clear();
            dtCategorias.AutoGenerateColumns = false;

            // Columna: Nombre
            dtCategorias.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // Columna: Descripción
            dtCategorias.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Descripcion",
                HeaderText = "Descripción",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // Botón: Editar
            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn
            {
                HeaderText = "Editar",
                Text = "Editar",
                UseColumnTextForButtonValue = true,
                Width = 70,
                FlatStyle = FlatStyle.Flat
            };
            dtCategorias.Columns.Add(btnEditar);

            // Botón: Eliminar
            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn
            {
                HeaderText = "Eliminar",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true,
                Width = 70,
                FlatStyle = FlatStyle.Flat
            };
            dtCategorias.Columns.Add(btnEliminar);

            dtCategorias.AllowUserToAddRows = false;
            dtCategorias.AllowUserToDeleteRows = false;
            dtCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtCategorias.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dtCategorias.BackgroundColor = Color.White;
            dtCategorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtCategorias.ReadOnly = true;
            dtCategorias.RowHeadersVisible = false;
            dtCategorias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // ✅ Estilos generales
            dtCategorias.DefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dtCategorias.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dtCategorias.DefaultCellStyle.ForeColor = Color.Black;
            dtCategorias.DefaultCellStyle.BackColor = Color.White;

            dtCategorias.DataSource = categorias;
            dtCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ✅ Manejar clics en los botones del DataGridView
        // ✅ Manejar clics en los botones del DataGridView
        private async void DtCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var categoriaSeleccionada = ((List<Categoria>)dtCategorias.DataSource)[e.RowIndex];

                // Botón Editar
                if (dtCategorias.Columns[e.ColumnIndex].HeaderText == "Editar")
                {
                    txtNombre.Text = categoriaSeleccionada.Nombre;
                    txtDescripcion.Text = categoriaSeleccionada.Descripcion;
                    lbId.Text = categoriaSeleccionada.IDCategoria.ToString();
                    lbId.Visible = true;

                    btnRegistrar.Visible = false;
                    btnActualizar.Visible = true;
                }
                // Botón Eliminar
                else if (dtCategorias.Columns[e.ColumnIndex].HeaderText == "Eliminar")
                {
                    var confirmar = MessageBox.Show($"¿Eliminar la categoría '{categoriaSeleccionada.Nombre}'?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirmar == DialogResult.Yes)
                    {
                        try
                        {
                            await _categoriaController.EliminarCategoriaAsync(categoriaSeleccionada.IDCategoria);
                            MessageBox.Show("Categoría eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarCategorias();
                            LimpiarCampos();
                        }
                        catch (Exception ex)
                        {
                            if (ex.Message.Contains("conflicto con la restricción FOREIGN KEY") || ex.Message.Contains("REFERENCE"))
                            {
                                MessageBox.Show("No se puede eliminar la categoría porque está relacionada con uno o más productos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show($"Error al eliminar la categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }


        // ✅ Personalizar botones de Editar y Eliminar
        private void DtCategorias_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dtCategorias.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var headerText = dtCategorias.Columns[e.ColumnIndex].HeaderText;

                if (headerText == "Editar")
                {
                    e.CellStyle.BackColor = Color.RoyalBlue;
                    e.CellStyle.ForeColor = Color.White;
                }
                else if (headerText == "Eliminar")
                {
                    e.CellStyle.BackColor = Color.Red;
                    e.CellStyle.ForeColor = Color.White;
                }

                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                e.CellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            }
        }

        // ✅ Registrar Nueva Categoría
        private async void btnRegistrar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string descripcion = txtDescripcion.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("El nombre es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Categoria nuevaCategoria = new Categoria
            {
                Nombre = nombre,
                Descripcion = descripcion
            };

            await _categoriaController.CrearCategoriaAsync(nuevaCategoria);

            LimpiarCampos();
            CargarCategorias();
        }

        // ✅ Actualizar Categoría Existente
        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(lbId.Text, out int idCategoria))
            {
                MessageBox.Show("No se pudo determinar la categoría a actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string nombre = txtNombre.Text.Trim();
            string descripcion = txtDescripcion.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("El nombre es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Categoria categoriaActualizada = new Categoria
            {
                IDCategoria = idCategoria,
                Nombre = nombre,
                Descripcion = descripcion
            };

            await _categoriaController.ActualizarCategoriaAsync(categoriaActualizada);

            LimpiarCampos();
            CargarCategorias();

            // Restablecer visibilidad de botones
            btnActualizar.Visible = false;
            btnRegistrar.Visible = true;
            lbId.Visible = false;
        }

        // ✅ Buscar Categorías
        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            string terminoBusqueda = txtBuscar.Text.Trim();
            var categorias = await _categoriaController.ObtenerCategoriasAsync();

            if (!string.IsNullOrEmpty(terminoBusqueda))
            {
                var filtradas = categorias.Where(c => c.Nombre.Contains(terminoBusqueda, StringComparison.OrdinalIgnoreCase)).ToList();
                ConfigurarDataGrid(filtradas);
            }
            else
            {
                ConfigurarDataGrid(categorias);
            }
        }

        // ✅ Búsqueda dinámica mientras se escribe
        private async void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            string terminoBusqueda = txtBuscar.Text.Trim();
            var categorias = await _categoriaController.ObtenerCategoriasAsync();

            if (!string.IsNullOrEmpty(terminoBusqueda))
            {
                var filtradas = categorias
                    .Where(c => c.Nombre.Contains(terminoBusqueda, StringComparison.OrdinalIgnoreCase) ||
                                c.Descripcion.Contains(terminoBusqueda, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                ConfigurarDataGrid(filtradas);
            }
            else
            {
                ConfigurarDataGrid(categorias);
            }
        }

        // ✅ Limpiar campos
        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtBuscar.Text = "";
            lbId.Text = "";
        }
    }
}
