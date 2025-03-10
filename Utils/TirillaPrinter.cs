using Sopromil.Controlador;
using Sopromil.Modelo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Sopromil.Impresion
{
    public class TirillaPrinter
    {
        private readonly Venta _venta;
        private readonly List<DetalleVenta> _detallesVenta;
        private Empresa _empresa;
        private PrintDocument printDoc;
        private string impresoraSeleccionada = "POS-58"; // 🔹 Impresora predeterminada

        public TirillaPrinter(Venta venta, List<DetalleVenta> detalles)
        {
            _venta = venta;
            _detallesVenta = detalles;
            printDoc = new PrintDocument();
            printDoc.PrintPage += PrintDoc_PrintPage;
        }

        public async Task Imprimir()
        {
            try
            {
                // 🔹 Obtener datos de la empresa antes de imprimir
                var empresaController = new EmpresaController();
                _empresa = await empresaController.ObtenerEmpresaAsync();

                if (_empresa == null)
                {
                    _empresa = new Empresa
                    {
                        Nombre = "SOPROMIL",
                        NIT = "123456789",
                        Direccion = "Calle 123 # 45-67",
                        Telefono = "123 456 7890"
                    };
                }

                // 🔹 Mostrar Vista Previa antes de Imprimir
                PrintPreviewDialog previewDialog = new PrintPreviewDialog
                {
                    Document = printDoc,
                    Width = 600,
                    Height = 800
                };

                DialogResult result = previewDialog.ShowDialog();
                if (result != DialogResult.OK) return;

                // 🔹 Verificar si la impresora POS-58 está instalada
                if (!PrinterSettings.InstalledPrinters.Cast<string>().Contains(impresoraSeleccionada))
                {
                    MessageBox.Show("⚠️ La impresora POS-58 no está instalada.", "Impresora no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // 🔹 Preguntar si desea seleccionar otra impresora o guardar la factura
                    DialogResult opcion = MessageBox.Show("¿Desea seleccionar otra impresora o guardar la factura?", "Opciones", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (opcion == DialogResult.Yes)
                    {
                        impresoraSeleccionada = SeleccionarImpresora();
                        if (string.IsNullOrEmpty(impresoraSeleccionada))
                        {
                            MessageBox.Show("No se seleccionó ninguna impresora. Se guardará la factura.", "Guardando Factura", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            GuardarFactura();
                            return;
                        }
                    }
                    else if (opcion == DialogResult.No)
                    {
                        GuardarFactura();
                        return;
                    }
                    else
                    {
                        return; // Cancelar la operación
                    }
                }

                // 🔹 Configurar la impresora seleccionada
                printDoc.PrinterSettings.PrinterName = impresoraSeleccionada;
                printDoc.Print();
                MessageBox.Show($"✅ Factura enviada a la impresora '{impresoraSeleccionada}' correctamente.", "Impresión Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error al imprimir: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font font = new Font("Courier New", 10, FontStyle.Bold);
            int y = 10;

            // 🔹 Encabezado de la empresa
            g.DrawString($"{_empresa.Nombre}", font, Brushes.Black, 10, y);
            y += 20;
            g.DrawString($"NIT: {_empresa.NIT}", font, Brushes.Black, 10, y);
            y += 20;
            g.DrawString($"{_empresa.Direccion}", font, Brushes.Black, 10, y);
            y += 20;
            g.DrawString($"Tel: {_empresa.Telefono}", font, Brushes.Black, 10, y);
            y += 20;
            g.DrawString("----------------------------------", font, Brushes.Black, 10, y);
            y += 20;

            // 🔹 Información de la venta
            g.DrawString($"Fecha: {_venta.FechaVenta:dd/MM/yyyy HH:mm}", font, Brushes.Black, 10, y);
            y += 20;
            g.DrawString($"Cliente: {_venta.NombreCliente}", font, Brushes.Black, 10, y);
            y += 20;
            g.DrawString("----------------------------------", font, Brushes.Black, 10, y);
            y += 20;

            // 🔹 Encabezados de productos
            g.DrawString("Cant  Producto      Precio", font, Brushes.Black, 10, y);
            y += 20;
            g.DrawString("----------------------------------", font, Brushes.Black, 10, y);
            y += 20;

            // 🔹 Listado de productos
            foreach (var detalle in _detallesVenta)
            {
                string linea = $"{detalle.Cantidad,-4} {detalle.NombreProducto,-12} {detalle.PrecioUnitario,6:N0}";
                g.DrawString(linea, font, Brushes.Black, 10, y);
                y += 20;
            }

            // 🔹 Totales
            g.DrawString("----------------------------------", font, Brushes.Black, 10, y);
            y += 20;
            g.DrawString($"TOTAL: {_venta.TotalVenta:N0}", font, Brushes.Black, 10, y);
            y += 20;
            g.DrawString("----------------------------------", font, Brushes.Black, 10, y);
            y += 20;

            // 🔹 Mensaje final
            g.DrawString("¡GRACIAS POR SU COMPRA!", font, Brushes.Black, 10, y);
        }

        private string SeleccionarImpresora()
        {
            var impresoras = PrinterSettings.InstalledPrinters.Cast<string>().ToList();

            if (impresoras.Count == 0)
            {
                MessageBox.Show("⚠️ No hay impresoras disponibles en el sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }

            using (Form form = new Form())
            {
                form.Text = "Seleccionar Impresora";
                form.Size = new Size(400, 200);
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterScreen;

                Label lblMensaje = new Label
                {
                    Text = "Seleccione una impresora:",
                    Left = 50,
                    Top = 20,
                    Width = 300
                };

                ComboBox cbImpresoras = new ComboBox
                {
                    Left = 50,
                    Top = 50,
                    Width = 300,
                    DropDownStyle = ComboBoxStyle.DropDownList
                };
                cbImpresoras.Items.AddRange(impresoras.ToArray());
                cbImpresoras.SelectedIndex = 0;

                Button btnAceptar = new Button
                {
                    Text = "Aceptar",
                    Left = 150,
                    Top = 100,
                    Width = 100
                };
                btnAceptar.Click += (s, e) => { form.Tag = cbImpresoras.SelectedItem?.ToString(); form.Close(); };

                form.Controls.Add(lblMensaje);
                form.Controls.Add(cbImpresoras);
                form.Controls.Add(btnAceptar);
                form.ShowDialog();

                return form.Tag as string;
            }
        }

        private void GuardarFactura()
        {
            string ruta = "Factura.txt";
            File.WriteAllText(ruta, $"Factura de {_empresa.Nombre}\nFecha: {_venta.FechaVenta:dd/MM/yyyy HH:mm}\nCliente: {_venta.NombreCliente}\nTotal: {_venta.TotalVenta:N0}");
            MessageBox.Show($"📄 Factura guardada en {ruta}", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
