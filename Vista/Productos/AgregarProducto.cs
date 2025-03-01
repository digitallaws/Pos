using Sopromil.Controlador;
using Sopromil.Modelo;

namespace Sopromil.Vista.Productos
{
    public partial class AgregarProducto : Form
    {
        private readonly ProductoController _productoController;
        private readonly CategoriaController _categoriaController;
        private Producto productoActual;

        public AgregarProducto(Producto producto = null)
        {
            InitializeComponent();
            _productoController = new ProductoController();
            _categoriaController = new CategoriaController();

            // Eventos para botones
            btnRegistrar.Click += BtnRegistrar_Click;
            btnActualizar.Click += BtnActualizar_Click;

            productoActual = producto;

            // Cargar categorías
            CargarCategorias();

            // Configurar el formulario según el modo (nuevo o edición)
            ConfigurarFormulario();

            // Configurar el DateTimePicker
            dtpFechaVencimiento.Format = DateTimePickerFormat.Custom;
            dtpFechaVencimiento.CustomFormat = " ";
            dtpFechaVencimiento.ValueChanged += DtpFechaVencimiento_ValueChanged;

            // Validaciones de entrada
            txtPrecioVenta.KeyPress += SoloNumerosConDecimal;
            txtPrecioCompra.KeyPress += SoloNumerosConDecimal;
            txtSTockInicial.KeyPress += SoloNumeros;

            // Agregar placeholders a los campos
            AgregarPlaceholders();
        }

        // ✅ Agregar placeholders a los campos
        private void AgregarPlaceholders()
        {
            txtNombre.PlaceholderText = "Ejemplo: Fertilizante Orgánico";
            txtPrecioVenta.PlaceholderText = "Ejemplo: 25.50";
            txtPrecioCompra.PlaceholderText = "Ejemplo: 15.00";
            txtCodigo.PlaceholderText = "Ejemplo: 1000000001";
            txtSTockInicial.PlaceholderText = "Ejemplo: 300";
            txtFechaVencimiento.PlaceholderText = "Selecciona una fecha";
        }

        // ✅ Configurar el formulario según el modo (Agregar o Actualizar)
        private void ConfigurarFormulario()
        {
            if (productoActual != null) // Modo edición
            {
                btnRegistrar.Visible = false;
                btnActualizar.Visible = true;
                txtTitulo.Text = "Actualizar Producto";  // Cambiar el título

                // Cargar datos existentes
                txtNombre.Text = productoActual.Descripcion;
                txtPrecioVenta.Text = productoActual.PrecioVenta.ToString("F2");
                txtPrecioCompra.Text = productoActual.PrecioCompra.ToString("F2");
                txtCodigo.Text = productoActual.CodigoBarras;
                txtSTockInicial.Text = productoActual.Stock.ToString();
                cmbCategoria.SelectedValue = productoActual.IDCategoria;
                
                if (productoActual.FechaVencimiento.HasValue)
                {
                    txtFechaVencimiento.Text = dtpFechaVencimiento.Value.ToString("yyyy-MM-dd");
                    dtpFechaVencimiento.Value = productoActual.FechaVencimiento.Value;
                }
            }
            else // Modo agregar nuevo producto
            {
                btnRegistrar.Visible = true;
                btnActualizar.Visible = false;
                txtTitulo.Text = "Registrar Producto";  // Cambiar el título
                txtSTockInicial.Text = "";
            }
        }

        // ✅ Permitir solo números y un punto decimal
        private void SoloNumerosConDecimal(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            // Solo permitir un punto decimal
            TextBox textBox = sender as TextBox;
            if (e.KeyChar == '.' && textBox.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        // ✅ Permitir solo números enteros
        private void SoloNumeros(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // ✅ Actualizar el TextBox de fecha al seleccionar una fecha
        private void DtpFechaVencimiento_ValueChanged(object sender, EventArgs e)
        {
            txtFechaVencimiento.Text = dtpFechaVencimiento.Value.ToString("yyyy-MM-dd");
        }

        // ✅ Cargar categorías en el ComboBox
        private async void CargarCategorias()
        {
            var categorias = await _categoriaController.ObtenerCategoriasAsync();

            cmbCategoria.DataSource = categorias;
            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.ValueMember = "IDCategoria";
        }

        // ✅ Registrar nuevo producto
        private async void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            productoActual = new Producto
            {
                Descripcion = txtNombre.Text.Trim(),
                IDCategoria = Convert.ToInt32(cmbCategoria.SelectedValue),
                PrecioVenta = decimal.Parse(txtPrecioVenta.Text),
                PrecioCompra = decimal.Parse(txtPrecioCompra.Text),
                CodigoBarras = txtCodigo.Text.Trim(),
                Stock = int.Parse(txtSTockInicial.Text),
                FechaVencimiento = string.IsNullOrWhiteSpace(txtFechaVencimiento.Text)
                    ? (DateTime?)null
                    : DateTime.Parse(txtFechaVencimiento.Text)
            };

            await _productoController.CrearProductoAsync(productoActual);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // ✅ Actualizar producto existente
        private async void BtnActualizar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            productoActual.Descripcion = txtNombre.Text.Trim();
            productoActual.IDCategoria = Convert.ToInt32(cmbCategoria.SelectedValue);
            productoActual.PrecioVenta = decimal.Parse(txtPrecioVenta.Text);
            productoActual.PrecioCompra = decimal.Parse(txtPrecioCompra.Text);
            productoActual.CodigoBarras = txtCodigo.Text.Trim();
            productoActual.Stock = decimal.Parse(txtSTockInicial.Text);
            productoActual.FechaVencimiento = string.IsNullOrWhiteSpace(txtFechaVencimiento.Text)
                ? (DateTime?)null
                : DateTime.Parse(txtFechaVencimiento.Text);

            await _productoController.ActualizarProductoAsync(productoActual);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // ✅ Validaciones generales
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("La descripción del producto es obligatoria.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbCategoria.SelectedItem == null)
            {
                MessageBox.Show("Selecciona una categoría.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!decimal.TryParse(txtPrecioVenta.Text, out decimal precioVenta) || precioVenta <= 0)
            {
                MessageBox.Show("Ingresa un precio de venta válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!decimal.TryParse(txtPrecioCompra.Text, out decimal precioCompra) || precioCompra <= 0)
            {
                MessageBox.Show("Ingresa un precio de compra válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("Ingresa un código de barras válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!ValidarStockInicial()) return false;

            return true;
        }

        private bool ValidarStockInicial()
        {
            string stockTexto = txtSTockInicial.Text.Trim();

            // Reemplazar comas y puntos si existen (evitar problemas de formato)
            stockTexto = stockTexto.Replace(",", "").Replace(".", "");

            if (string.IsNullOrWhiteSpace(stockTexto) || !int.TryParse(stockTexto, out int stockInicial) || stockInicial <= 0)
            {
                MessageBox.Show("El stock inicial debe ser un número entero mayor a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

    }
}
