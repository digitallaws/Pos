using Sopromil.Controlador;
using Sopromil.Modelo;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sopromil.Vista.Empresa
{
    public partial class CrearEmpresa : Form
    {
        private readonly EmpresaController _empresaController;
        private byte[] _logoBytes; // Para almacenar la imagen seleccionada
        private readonly Image _imagenPorDefecto = Properties.Resources.chart_marketing_report_shop_graph_business_sales_shopping_analytics_finance_icon_231909; // Imagen por defecto

        public CrearEmpresa()
        {
            InitializeComponent();
            _empresaController = new EmpresaController();

            btnRegistrar.Click += BtnRegistrar_Click;
            btnImagen.Click += BtnImagen_Click;

            this.Load += CrearEmpresa_Load;
        }

        private void CentrarPanel()
        {
            pnlContenedor.Left = (this.ClientSize.Width - pnlContenedor.Width) / 2;
            pnlContenedor.Top = (this.ClientSize.Height - pnlContenedor.Height) / 2;
        }

        private async void CrearEmpresa_Load(object sender, EventArgs e)
        {
            await CargarDatosEmpresa();
            CentrarPanel();
        }

        private async Task CargarDatosEmpresa()
        {
            var empresa = await _empresaController.ObtenerEmpresaAsync();
            if (empresa != null)
            {
                txtNombre.Text = empresa.Nombre;
                txtIdentificadorFiscal.Text = empresa.NIT;
                txtDireccion.Text = empresa.Direccion;
                txtTelefono.Text = empresa.Telefono;
                txtCorreo.Text = empresa.Correo;
                _logoBytes = empresa.Logo;

                // Cargar imagen si existe, si no, usar la imagen por defecto
                if (_logoBytes != null)
                {
                    using (MemoryStream ms = new MemoryStream(_logoBytes))
                    {
                        picImagen.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    picImagen.Image = _imagenPorDefecto;
                }
            }
        }

        private void BtnImagen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos de imagen (*.jpg, *.png, *.bmp)|*.jpg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    picImagen.Image = Image.FromFile(openFileDialog.FileName);
                    _logoBytes = File.ReadAllBytes(openFileDialog.FileName); // Convertir la imagen a bytes
                }
            }
        }

        private async void BtnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Si no se ha seleccionado una imagen nueva, se mantiene la actual en picImagen
                if (_logoBytes == null && picImagen.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        picImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        _logoBytes = ms.ToArray();
                    }
                }

                var empresa = new Modelo.Empresa
                {
                    Nombre = txtNombre.Text.Trim(),
                    NIT = txtIdentificadorFiscal.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Correo = txtCorreo.Text.Trim(),
                    Logo = _logoBytes,
                    Moneda = "COP"
                };

                string resultado = await _empresaController.RegistrarActualizarEmpresaAsync(empresa);
                MessageBox.Show(resultado, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la empresa: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
