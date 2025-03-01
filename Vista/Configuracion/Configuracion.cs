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
        }
    }
}
