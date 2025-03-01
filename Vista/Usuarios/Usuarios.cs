using Sopromil.Controlador;
using Sopromil.Modelo;

namespace Sopromil.Vista.Usuarios
{
    public partial class Usuarios : Form
    {
        private readonly UsuarioController _usuarioController;
        private List<Usuario> usuariosOriginales = new List<Usuario>();

        public Usuarios()
        {
            InitializeComponent();
            _usuarioController = new UsuarioController();

            // ✅ Configuración del DataGridView
            ConfigurarDataGrid();

            // ✅ Cargar usuarios al iniciar
            CargarUsuarios();

            // ✅ Eventos
            txtBuscar.TextChanged += BuscarTxt_TextChanged;
            btnRegistrar.Click += BtnRegistrar_Click;
            btnActualizar.Click += BtnActualizar_Click;
            dtUsuarios.CellClick += DtUsuarios_CellClick;
            dtUsuarios.CellFormatting += DtUsuarios_CellFormatting;

            // ✅ Inicializar label de ID oculto y botones de acción
            lbId.Visible = false;
            btnActualizar.Visible = false;

            // ✅ Configurar ComboBox de Rol
            cbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRol.Items.AddRange(new string[] { "Admin", "Cajero" });
            cbRol.SelectedIndex = 0;

            // ✅ Configurar ComboBox de Estado
            cbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEstado.Items.AddRange(new string[] { "Activo", "Inactivo" });
            cbEstado.SelectedIndex = 0;


            // ✅ Restringir entradas de texto en Login
            txtLogin.KeyPress += ValidarTextoSinEspacios;
        }

        private void ConfigurarDataGrid()
        {
            dtUsuarios.AllowUserToAddRows = false;
            dtUsuarios.AllowUserToDeleteRows = false;
            dtUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtUsuarios.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dtUsuarios.BackgroundColor = Color.White;
            dtUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtUsuarios.ReadOnly = true;
            dtUsuarios.RowHeadersVisible = false;
            dtUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // ✅ Estilos generales
            dtUsuarios.DefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dtUsuarios.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dtUsuarios.DefaultCellStyle.ForeColor = Color.Black;
            dtUsuarios.DefaultCellStyle.BackColor = Color.White;
        }

        private void BuscarTxt_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim().ToLower();

            var usuariosFiltrados = usuariosOriginales
                .Where(u => u.Nombre.ToLower().Contains(filtro) ||
                            u.Login.ToLower().Contains(filtro) ||
                            u.Rol.ToLower().Contains(filtro) ||
                            u.Estado.ToLower().Contains(filtro))
                .ToList();

            MostrarUsuariosEnGrid(usuariosFiltrados.Any() ? usuariosFiltrados : usuariosOriginales);
        }


        private void DtUsuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dtUsuarios.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var headerText = dtUsuarios.Columns[e.ColumnIndex].HeaderText;

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


        private async void CargarUsuarios()
        {
            try
            {
                usuariosOriginales = await _usuarioController.ObtenerUsuariosAsync();
                MostrarUsuariosEnGrid(usuariosOriginales);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarUsuariosEnGrid(List<Usuario> usuarios)
        {
            dtUsuarios.DataSource = null;
            dtUsuarios.Columns.Clear();
            dtUsuarios.AutoGenerateColumns = false;

            // ✅ Ocultar IDUsuario correctamente
            var colID = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IDUsuario",
                Visible = false
            };
            dtUsuarios.Columns.Add(colID);

            // ✅ Columna: Nombre
            dtUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // ✅ Columna: Login
            dtUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Login",
                HeaderText = "Login",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // ✅ Columna: Contraseña
            dtUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Password",
                HeaderText = "Contraseña",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // ✅ Columna: Rol
            dtUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Rol",
                HeaderText = "Rol",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // ✅ Columna: Estado
            dtUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Estado",
                HeaderText = "Estado",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // ✅ Botón: Editar
            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn
            {
                HeaderText = "Editar",
                Text = "Editar",
                UseColumnTextForButtonValue = true,
                Width = 70,
                FlatStyle = FlatStyle.Flat
            };
            dtUsuarios.Columns.Add(btnEditar);

            // ✅ Botón: Eliminar
            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn
            {
                HeaderText = "Eliminar",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true,
                Width = 70,
                FlatStyle = FlatStyle.Flat
            };
            dtUsuarios.Columns.Add(btnEliminar);

            dtUsuarios.DataSource = usuarios;
        }


        private async void BtnRegistrar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text.Trim();
            string rol = cbRol.SelectedItem.ToString();
            string estado = cbEstado.SelectedItem.ToString(); // 🔹 Corregido: ahora usa cbEstado

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Usuario nuevoUsuario = new Usuario
            {
                Nombre = nombre,
                Login = login,
                Password = password, // ⚠️ No encriptada
                Rol = rol,
                Estado = estado
            };

            await _usuarioController.CrearUsuarioAsync(nuevoUsuario);
            LimpiarCampos();
            CargarUsuarios();
        }


        private async void BtnActualizar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(lbId.Text, out int idUsuario))
            {
                MessageBox.Show("No se pudo determinar el usuario a actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string nombre = txtNombre.Text.Trim();
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text.Trim();
            string rol = cbRol.SelectedItem.ToString();
            string estado = cbEstado.SelectedItem.ToString();

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(login))
            {
                MessageBox.Show("Nombre y Login son obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Usuario usuarioActualizado = new Usuario
            {
                IDUsuario = idUsuario,
                Nombre = nombre,
                Login = login,
                Password = password,
                Rol = rol,
                Estado = estado
            };

            await _usuarioController.ActualizarUsuarioAsync(usuarioActualizado);
            LimpiarCampos();
            CargarUsuarios();

            btnActualizar.Visible = false;
            btnRegistrar.Visible = true;
            lbId.Visible = false;
        }



        private void DtUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var usuarioSeleccionado = ((List<Usuario>)dtUsuarios.DataSource)[e.RowIndex];

                if (dtUsuarios.Columns[e.ColumnIndex].HeaderText == "Editar")
                {
                    txtNombre.Text = usuarioSeleccionado.Nombre;
                    txtLogin.Text = usuarioSeleccionado.Login;
                    txtPassword.Text = usuarioSeleccionado.Password;
                    cbRol.SelectedItem = usuarioSeleccionado.Rol;
                    cbEstado.SelectedItem = usuarioSeleccionado.Estado;
                    lbId.Text = usuarioSeleccionado.IDUsuario.ToString();
                    lbId.Visible = true;

                    btnRegistrar.Visible = false;
                    btnActualizar.Visible = true;
                }
                else if (dtUsuarios.Columns[e.ColumnIndex].HeaderText == "Eliminar")
                {
                    var confirmar = MessageBox.Show($"¿Desea inactivar el usuario '{usuarioSeleccionado.Nombre}'?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirmar == DialogResult.Yes)
                    {
                        _usuarioController.CambiarEstadoUsuarioAsync(usuarioSeleccionado.IDUsuario, "Inactivo");
                        MessageBox.Show("Usuario inactivado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarUsuarios();
                        LimpiarCampos();
                    }
                }
            }
        }



        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtLogin.Text = "";
            txtPassword.Text = "";
            cbRol.SelectedIndex = 0;
            cbEstado.SelectedIndex = 0;
            lbId.Text = "";
        }


        private void ValidarTextoSinEspacios(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }
    }
}
