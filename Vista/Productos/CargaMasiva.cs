using Sopromil.Modelo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Sopromil.Vista.Productos
{
    public partial class cargaMasiva : Form
    {
        private List<Producto> productos;

        public cargaMasiva(List<Producto> productosImportados)
        {
            InitializeComponent();
            productos = productosImportados;
            CargarDatosEnGrid();
            btnConfirmar.Click += BtnConfirmar_Click;
            btnCancelar.Click += BtnCancelar_Click;
        }

        // ✅ Cargar los datos en el DataGridView
        // ✅ Cargar los datos en el DataGridView
        private void CargarDatosEnGrid()
        {
            dtMasivo.DataSource = null;
            dtMasivo.DataSource = productos;

            // Ocultar columnas no relevantes
            dtMasivo.Columns["IDProducto"].Visible = false;
            dtMasivo.Columns["IDCategoria"].Visible = false;

            // Ocultar la columna Categoría si existe
            if (dtMasivo.Columns.Contains("Categoria"))
            {
                dtMasivo.Columns["Categoria"].Visible = false;
            }

            // Configurar encabezados y formatos
            dtMasivo.Columns["Descripcion"].HeaderText = "Descripción";
            dtMasivo.Columns["Stock"].HeaderText = "Stock";
            dtMasivo.Columns["PrecioCompra"].HeaderText = "Precio Compra";
            dtMasivo.Columns["PrecioCompra"].DefaultCellStyle.Format = "C2";
            dtMasivo.Columns["PrecioVenta"].HeaderText = "Precio Venta";
            dtMasivo.Columns["PrecioVenta"].DefaultCellStyle.Format = "C2";
            dtMasivo.Columns["FechaVencimiento"].HeaderText = "Fecha de Vencimiento";
            dtMasivo.Columns["CodigoBarras"].HeaderText = "Código de Barras";

            // Ajustes visuales
            dtMasivo.AutoResizeColumns();
            dtMasivo.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dtMasivo.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // ✅ Suscribirse al evento CellFormatting para aplicar colores
            dtMasivo.CellFormatting -= DtMasivo_CellFormatting; // Evitar múltiples suscripciones
            dtMasivo.CellFormatting += DtMasivo_CellFormatting;
        }

        // ✅ Aplicar colores según la fecha de vencimiento
        private void DtMasivo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dtMasivo.Columns[e.ColumnIndex].Name == "FechaVencimiento")
            {
                var row = dtMasivo.Rows[e.RowIndex];
                var fechaVencimientoObj = row.Cells["FechaVencimiento"].Value;

                if (fechaVencimientoObj != null && DateTime.TryParse(fechaVencimientoObj.ToString(), out DateTime fechaVencimiento))
                {
                    TimeSpan diferencia = fechaVencimiento - DateTime.Now;

                    if (diferencia.TotalDays <= 15 && diferencia.TotalDays >= 0)
                    {
                        // 🔴 Rojo - Vence en 15 días o menos
                        row.DefaultCellStyle.BackColor = Color.Red;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                    else if (diferencia.TotalDays <= 30 && diferencia.TotalDays > 15)
                    {
                        // 🟡 Amarillo - Vence en 16 a 30 días
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else if (diferencia.TotalDays > 30)
                    {
                        // 🟢 Verde - Vence en más de 30 días
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else if (diferencia.TotalDays < 0)
                    {
                        // 🔴 Oscuro - Producto ya vencido
                        row.DefaultCellStyle.BackColor = Color.DarkRed;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                }
                else
                {
                    // Sin fecha de vencimiento
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }


        // ✅ Confirmar la carga
        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // ✅ Cancelar la carga
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
