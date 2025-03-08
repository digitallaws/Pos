using Sopromil.Utils;

namespace Sopromil.Vista.Configuracion
{
    public partial class FrmConfiguracion : Form
    {
        public FrmConfiguracion()
        {
            InitializeComponent();
            ConfigurarEventos();
        }

        private void FrmConfiguracion_Load(object sender, EventArgs e)
        {
            cboTipoAuth.Items.Add("Windows");
            cboTipoAuth.Items.Add("SQLServer");
            cboTipoAuth.SelectedIndex = 0;  // Por defecto Windows

            MostrarCamposSQL();

            // 🔔 El btnGuardar arranca desactivado
            btnGuardar.Enabled = false;
        }

        // 🔔 Asignación manual de eventos a cada control
        private void ConfigurarEventos()
        {
            this.Load += FrmConfiguracion_Load;

            cboTipoAuth.SelectedIndexChanged += cboTipoAuth_SelectedIndexChanged;
            btnProbar.Click += btnProbar_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnCancelar.Click += btnCancelar_Click;
        }

        private void cboTipoAuth_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarCamposSQL();
        }

        private void MostrarCamposSQL()
        {
            bool esSQL = cboTipoAuth.SelectedItem.ToString() == "SQLServer";
            txtUsuario.Enabled = esSQL;
            txtClave.Enabled = esSQL;

            if (!esSQL)
            {
                txtUsuario.Clear();
                txtClave.Clear();
            }
        }

        private void btnProbar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtServidor.Text) ||
                string.IsNullOrWhiteSpace(txtBaseDatos.Text))
            {
                MessageBox.Show("Por favor complete todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var tipoAuth = cboTipoAuth.SelectedItem.ToString();
            var usuario = tipoAuth == "SQLServer" ? txtUsuario.Text : "";
            var clave = tipoAuth == "SQLServer" ? txtClave.Text : "";

            ConfigManager.GuardarConfiguracionEnMemoria(
                txtServidor.Text,
                txtBaseDatos.Text,
                tipoAuth,
                usuario,
                clave
            );

            if (ConfigManager.ProbarConexion(out string mensaje))
            {
                MessageBox.Show("Conexión exitosa.", "Prueba de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnGuardar.Enabled = true;  // 🔥 Habilita el Guardar
            }
            else
            {
                MessageBox.Show($"Error al conectar con la base de datos.\n\nDetalle: {mensaje}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnGuardar.Enabled = false;  // 🔒 Mantiene el Guardar deshabilitado
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var tipoAuth = cboTipoAuth.SelectedItem.ToString();
            var usuario = tipoAuth == "SQLServer" ? txtUsuario.Text : "";
            var clave = tipoAuth == "SQLServer" ? txtClave.Text : "";

            ConfigManager.GuardarConfiguracion(
                txtServidor.Text,
                txtBaseDatos.Text,
                tipoAuth,
                usuario,
                clave
            );

            MessageBox.Show("Configuración guardada correctamente. Reinicie la aplicación.", "Configuración Guardada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
