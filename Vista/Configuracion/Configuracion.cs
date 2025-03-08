using Sopromil.Modelo;
using Sopromil.Vista.Empresa;

namespace Sopromil.Vista.Configuracion
{
    public partial class Configuracion : Form
    {
        public Configuracion()
        {
            InitializeComponent();
        }

        private void btnNegocio_Click(object sender, EventArgs e)
        {
            CrearEmpresa empresa = new CrearEmpresa();
            empresa.ShowDialog();
        }

        private void btnImpresora_Click(object sender, EventArgs e)
        {
            Impresora impresion = new Impresora();
            impresion.ShowDialog();

        }

        private void btnTicket_Click(object sender, EventArgs e)
        {

        }

        private void btnCopia_Click(object sender, EventArgs e)
        {

        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios.Usuarios usuarios = new Usuarios.Usuarios();
            usuarios.ShowDialog();
        }
    }
}
