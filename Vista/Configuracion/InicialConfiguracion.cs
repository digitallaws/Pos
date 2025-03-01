using Microsoft.VisualBasic.ApplicationServices;
using Sopromil.Controlador;
using Sopromil.Modelo;
using System.Drawing.Printing;

namespace Sopromil.Vista.Configuracion
{
    public partial class InicialConfiguracion : Form
    {
        private readonly InitialSetupController _setupController;
        private readonly EmpresaController _empresaController;
        private string selectedPrinter = string.Empty;
        private string copiaSeguridadPath = string.Empty;

        public InicialConfiguracion()
        {
            InitializeComponent();
            _setupController = new InitialSetupController();
            _empresaController = new EmpresaController();

            // Eventos
            btnSeleccionarImpresora.Click += BtnSeleccionarImpresora_Click;
            btnSeleccionarRuta.Click += BtnSeleccionarRuta_Click;
            btnProbarLector.Click += BtnProbarLector_Click;
            btnImprimirPrueba.Click += BtnImprimirPrueba_Click;
            btnGuardarConfiguracion.Click += BtnGuardarConfiguracion_Click;

            txtCodigo.KeyDown += TxtCodigo_KeyDown;

            // Cargar datos de la empresa al iniciar
            CargarDatosEmpresa();
        }

        // ✅ Cargar Datos de la Empresa y Mostrarlos
        private async void CargarDatosEmpresa()
        {
            var datosEmpresa = await _empresaController.ObtenerDatosEmpresaAsync();

            txtNombre.Text = datosEmpresa.Nombre ?? "N/A";
            txtNit.Text = $"NIT: {datosEmpresa.RUC ?? "N/A"}";
            txtDireccion.Text = $"Dirección: {datosEmpresa.Direccion ?? "N/A"}";
            txtTelefono.Text = $"Tel: {datosEmpresa.Telefono ?? "N/A"}";

            // Redibujar el ticket con los datos cargados
            panelTicket.Invalidate();
        }

        // ✅ Seleccionar Impresora
        private void BtnSeleccionarImpresora_Click(object sender, EventArgs e)
        {
            using (PrintDialog printDialog = new PrintDialog())
            {
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedPrinter = printDialog.PrinterSettings.PrinterName;
                    txtImpresora.Text = selectedPrinter;
                }

                btnImprimirPrueba.Visible = true;
            }
        }

        // ✅ Seleccionar Carpeta para Copia de Seguridad
        private void BtnSeleccionarRuta_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Selecciona la carpeta para la copia de seguridad";
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    copiaSeguridadPath = folderDialog.SelectedPath;
                    txtRutaCopiaSeguridad.Text = copiaSeguridadPath;
                }
            }
        }

        // ✅ Probar Lector de Códigos
        private void BtnProbarLector_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = string.Empty;
            txtCodigo.Focus();
            MessageBox.Show("Escanea un código de barras ahora.", "Prueba de Lector", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ✅ Evento para Capturar el Código desde el Lector
        private void TxtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string codigoEscaneado = txtCodigo.Text.Trim();

                if (!string.IsNullOrEmpty(codigoEscaneado))
                {
                    MessageBox.Show($"Código Escaneado Correctamente: {codigoEscaneado}", "Lector Funcionando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se detectó ningún código. Intenta nuevamente.", "Error de Lector", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                txtCodigo.Text = string.Empty;
                e.SuppressKeyPress = true;
            }
        }

        // ✅ Imprimir Ticket de Prueba
        private void BtnImprimirPrueba_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedPrinter))
            {
                MessageBox.Show("Por favor, selecciona una impresora antes de imprimir.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PrintDocument printDocument = new PrintDocument();
            printDocument.PrinterSettings.PrinterName = selectedPrinter;

            // Evento que se encarga de dibujar el ticket
            printDocument.PrintPage += PrintDocument_PrintPage;

            try
            {
                printDocument.Print();
                MessageBox.Show("Ticket de prueba enviado a la impresora.", "Impresión Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al imprimir: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ✅ Evento que Dibuja el Ticket para Imprimir
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            DibujarTicket(g);
        }

        // ✅ Método para Dibujar el Ticket
        private void DibujarTicket(Graphics g)
        {
            Font fontNormal = new Font("Arial", 10);
            Font fontBold = new Font("Arial", 12, FontStyle.Bold);
            Font fontLargeBold = new Font("Arial", 14, FontStyle.Bold);

            float y = 10;

            // Encabezado con datos de la empresa
            g.DrawString(txtNombre.Text, fontLargeBold, Brushes.Black, new PointF(60, y));
            y += 25;
            g.DrawString($"NIT: {txtNit.Text}", fontNormal, Brushes.Black, new PointF(40, y));
            y += 20;
            g.DrawString(txtDireccion.Text, fontNormal, Brushes.Black, new PointF(60, y));
            y += 20;
            g.DrawString($"Tel: {txtTelefono.Text}", fontNormal, Brushes.Black, new PointF(40, y));
            y += 30;

            g.DrawLine(Pens.Black, 10, y, 280, y);
            y += 10;

            // Número de Factura
            g.DrawString("Sistema POS No. FV-00001", fontBold, Brushes.Black, new PointF(30, y));
            y += 30;

            // Código de barras (simulado)
            g.DrawRectangle(Pens.Black, new Rectangle(70, (int)y, 140, 40));
            g.DrawString("|| ||| | || || |||", fontLargeBold, Brushes.Black, new PointF(80, y + 5));
            y += 50;
            g.DrawString("ABC-abc-1234", fontNormal, Brushes.Black, new PointF(90, y));
            y += 30;

            // Información de la venta
            g.DrawString($"Fecha: {DateTime.Now.ToString("yyyy-MM-dd")} Hora: {DateTime.Now.ToString("hh:mm:ss tt")}", fontNormal, Brushes.Black, new PointF(10, y));
            y += 20;
            g.DrawString("Cliente: Consumidor Final", fontNormal, Brushes.Black, new PointF(10, y));
            y += 20;
            g.DrawString("Forma de pago: Efectivo", fontNormal, Brushes.Black, new PointF(10, y));
            y += 20;
            g.DrawString("Vendedor: Aldair", fontNormal, Brushes.Black, new PointF(10, y));
            y += 20;

            g.DrawLine(Pens.Black, 10, y, 280, y);
            y += 10;

            // Productos
            g.DrawString("Cant   Detalle       Precio    Total", fontBold, Brushes.Black, new PointF(10, y));
            y += 20;
            g.DrawString("2      Martillos    20.000$   40.000$", fontNormal, Brushes.Black, new PointF(10, y));
            y += 20;
            g.DrawString("10     Puntillas      200$     2.000$", fontNormal, Brushes.Black, new PointF(10, y));
            y += 30;

            g.DrawLine(Pens.Black, 10, y, 280, y);
            y += 10;

            // Totales
            g.DrawString("Subtotal:                  42.000$", fontNormal, Brushes.Black, new PointF(10, y));
            y += 20;
            g.DrawString("IVA:                           0$", fontNormal, Brushes.Black, new PointF(10, y));
            y += 20;
            g.DrawString("Total:                     42.000$", fontLargeBold, Brushes.Black, new PointF(10, y));
            y += 30;
            g.DrawString("Cantidad Productos: 12", fontNormal, Brushes.Black, new PointF(10, y));
            y += 30;

            g.DrawLine(Pens.Black, 10, y, 280, y);
            y += 20;

            // Mensajes finales
            g.DrawString("Conserve este ticket para", fontNormal, Brushes.Black, new PointF(40, y));
            y += 20;
            g.DrawString("cambios y devoluciones", fontNormal, Brushes.Black, new PointF(40, y));
            y += 30;
            g.DrawString("¡Gracias por Comprar!", fontBold, Brushes.Black, new PointF(40, y));
        }


        // ✅ Guardar Configuración
        private async void BtnGuardarConfiguracion_Click(object sender, EventArgs e)
        {
            string impresora = txtImpresora.Text.Trim();
            string lectorCodigos = txtCodigo.Text.Trim();
            string rutaCopiaSeguridad = txtRutaCopiaSeguridad.Text.Trim();

            if (string.IsNullOrWhiteSpace(impresora))
            {
                MessageBox.Show("Debe seleccionar una impresora.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(lectorCodigos))
            {
                MessageBox.Show("Debe probar el lector de códigos antes de guardar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(rutaCopiaSeguridad) || !Directory.Exists(rutaCopiaSeguridad))
            {
                MessageBox.Show("Debe seleccionar una ruta válida para la copia de seguridad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Información adicional para el ticket
            string agradecimiento = "¡Gracias por su compra!";
            string anuncio = "Sopromil - Lo mejor para ti";
            string datosFiscales = $"NIT: {txtNit.Text}";

             await _setupController.ConfiguracionInicialAsync(
                agradecimiento,
                anuncio,
                datosFiscales,
                rutaCopiaSeguridad,
                impresora,
                lectorCodigos
            );

            // ✅ Cargar el Dashboard después de guardar
            this.Hide();
           
            var vistaPrincipal = new Login.SeleccionPerfil();
            vistaPrincipal.ShowDialog();
            this.Close();

            // Cerrar la ventana actual
            this.Close();
            MessageBox.Show("Configuración guardada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
