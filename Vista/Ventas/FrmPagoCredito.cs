using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Sopromil.Controlador;
using Sopromil.Modelo;

namespace Sopromil.Vista.Ventas
{
    public partial class FrmPagoCredito : Form
    {
        public DateTime FechaEstimadaPago { get; private set; }
        public bool VentaConfirmada { get; private set; } = false;
        private readonly ClienteController _clienteController;
        private List<Cliente> _clientes = new();
        private int _idCliente;
        private string _nombreCliente;

        public FrmPagoCredito(int idCliente, string nombreCliente)
        {
            InitializeComponent();
            _clienteController = new ClienteController();
            _idCliente = idCliente;
            _nombreCliente = nombreCliente;

            ConfigurarComboBoxClientes();
            btnConfirmar.Click += BtnConfirmar_Click;

            CargarClientes();
            MostrarCliente();
        }

        private async void CargarClientes()
        {
            try
            {
                _clientes = await _clienteController.ObtenerClientesAsync(true);
                CargarClientesEnComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarComboBoxClientes()
        {
            cbBuscarCliente.DropDownStyle = ComboBoxStyle.DropDown;
            cbBuscarCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbBuscarCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbBuscarCliente.TextChanged += CbBuscarCliente_TextChanged;
            cbBuscarCliente.SelectedIndexChanged += CbBuscarCliente_SelectedIndexChanged;
        }

        private void CargarClientesEnComboBox()
        {
            var autoCompleteCollection = new AutoCompleteStringCollection();
            foreach (var cliente in _clientes)
            {
                autoCompleteCollection.Add(cliente.Nombre);
            }
            cbBuscarCliente.AutoCompleteCustomSource = autoCompleteCollection;
        }

        private void MostrarCliente()
        {
            if (_idCliente > 0)
            {
                lblCliente.Text = $"🧑 Cliente: {_nombreCliente}";
                lblCliente.ForeColor = System.Drawing.Color.Black;
                lblCliente.Visible = true;
                cbBuscarCliente.Visible = false;
            }
            else
            {
                lblCliente.Visible = false;
                cbBuscarCliente.Visible = true;
            }
        }

        private void CbBuscarCliente_TextChanged(object sender, EventArgs e)
        {
            string filtro = cbBuscarCliente.Text.Trim().ToLower();

            var clientesFiltrados = _clientes
                .Where(c => c.Nombre.ToLower().Contains(filtro))
                .Select(c => c.Nombre)
                .Distinct()
                .ToList();

            cbBuscarCliente.AutoCompleteCustomSource.Clear();
            cbBuscarCliente.AutoCompleteCustomSource.AddRange(clientesFiltrados.ToArray());
        }

        private void CbBuscarCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            var clienteSeleccionado = _clientes.FirstOrDefault(c => c.Nombre == cbBuscarCliente.Text);
            if (clienteSeleccionado != null)
            {
                _idCliente = clienteSeleccionado.IDCliente;
                _nombreCliente = clienteSeleccionado.Nombre;
                MostrarCliente(); // 🔥 Refresca la visibilidad de la etiqueta y el ComboBox
            }
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            if (_idCliente == 0)
            {
                MessageBox.Show("Debe seleccionar un cliente antes de asignar un crédito.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dateFechaPago.Value <= DateTime.Today)
            {
                MessageBox.Show("La fecha estimada de pago debe ser posterior a hoy.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FechaEstimadaPago = dateFechaPago.Value;
            VentaConfirmada = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
