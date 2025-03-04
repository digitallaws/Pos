using Microsoft.Data.SqlClient;
using Sopromil.Controlador;
using System;
using System.Windows.Forms;

namespace Sopromil.Vista.Caja
{
    public partial class frmMovimientoExtraCaja : Form
    {
        private readonly CajaController _cajaController;
        private readonly int _idMovimiento;

        public frmMovimientoExtraCaja(int idMovimiento)
        {
            InitializeComponent();
            _cajaController = new CajaController();
            _idMovimiento = idMovimiento;

            // Asociar eventos directamente (sin depender del diseñador)
            this.Load += frmMovimientoExtraCaja_Load;
            btnGuardar.Click += btnGuardar_Click;
            btnCancelar.Click += btnCancelar_Click;
        }

        private void frmMovimientoExtraCaja_Load(object sender, EventArgs e)
        {
            cbTipoMovimiento.Items.Add("IngresoExtra");
            cbTipoMovimiento.Items.Add("EgresoExtra");
            cbTipoMovimiento.SelectedIndex = 0;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
                return;

            string tipoMovimiento = cbTipoMovimiento.SelectedItem.ToString();
            decimal monto = decimal.Parse(txtMonto.Text);
            string descripcion = txtDescripcion.Text.Trim();

            try
            {
                await _cajaController.RegistrarMovimientoExtraAsync(_idMovimiento, tipoMovimiento, monto, descripcion);
                MessageBox.Show($"El {tipoMovimiento} fue registrado correctamente.", "Movimiento Registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (SqlException sqlEx)
            {
                LogError(sqlEx, nameof(btnGuardar_Click));
                MostrarErrorAlUsuario("Ocurrió un problema al conectar con la base de datos.\nPor favor, verifique la conexión e intente nuevamente.", sqlEx);
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(btnGuardar_Click));
                MostrarErrorAlUsuario("Ocurrió un error inesperado al registrar el movimiento extra.\nPor favor, intente nuevamente.", ex);
            }
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtMonto.Text) || !decimal.TryParse(txtMonto.Text, out decimal monto) || monto <= 0)
            {
                MessageBox.Show("Debe ingresar un monto válido mayor a cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Debe ingresar una descripción del movimiento.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LogError(Exception ex, string metodo)
        {
            try
            {
                string logPath = "logErrores.txt";
                string mensaje = $"[{DateTime.Now:dd/MM/yyyy HH:mm:ss}] Error en {metodo}: {ex.Message}{Environment.NewLine}";
                System.IO.File.AppendAllText(logPath, mensaje);
            }
            catch
            {
                // Evitar que un error al escribir el log detenga el programa
            }
        }

        private void MostrarErrorAlUsuario(string mensajeAmigable, Exception ex)
        {
            MessageBox.Show($"{mensajeAmigable}\n\nDetalle Técnico: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
