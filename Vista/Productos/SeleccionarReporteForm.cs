namespace Sopromil.Vista.Productos
{
    public partial class SeleccionarReporteForm : Form
    {
        public enum TipoReporte
        {
            Ninguno,
            General,
            PorVencimiento,
            StockBajo
        }

        public TipoReporte ReporteSeleccionado { get; private set; } = TipoReporte.Ninguno;

        public SeleccionarReporteForm()
        {
            InitializeComponent();

            // Asignar eventos a los PictureBox
            pbGeneral.Click += (s, e) => SeleccionarReporte(TipoReporte.General);
            pbPorVencimiento.Click += (s, e) => SeleccionarReporte(TipoReporte.PorVencimiento);
            pbStockBajo.Click += (s, e) => SeleccionarReporte(TipoReporte.StockBajo);
        }

        // ✅ Método para seleccionar el reporte y cerrar el modal
        private void SeleccionarReporte(TipoReporte tipo)
        {
            ReporteSeleccionado = tipo;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
