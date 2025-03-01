using System.ComponentModel;

namespace Sopromil.Controles
{
    public class CustomTextBox : TextBox
    {
        private Color borderColor = Color.Gray;  // Color normal del borde
        private Color focusBorderColor = Color.DodgerBlue; // Color cuando está en foco
        private int borderSize = 2; // Grosor del borde
        private bool isFocused = false;

        private string placeholderText = "Escriba aquí...";
        private bool isPlaceholder = true;

        public CustomTextBox()
        {
            this.Font = new Font("Arial", 10);
            this.ForeColor = Color.DarkGray;
            this.Text = placeholderText;
            this.isPlaceholder = true;
            this.BorderStyle = BorderStyle.None;
            this.Padding = new Padding(5);
            this.BackColor = Color.White;

            this.Enter += RemovePlaceholder;
            this.Leave += SetPlaceholder;
        }

        // Propiedad para cambiar el color del borde
        [Category("Custom")]
        public Color BorderColor
        {
            get => borderColor;
            set { borderColor = value; this.Invalidate(); }
        }

        [Category("Custom")]
        public Color FocusBorderColor
        {
            get => focusBorderColor;
            set { focusBorderColor = value; this.Invalidate(); }
        }

        [Category("Custom")]
        public string PlaceholderText
        {
            get => placeholderText;
            set { placeholderText = value; SetPlaceholder(this, EventArgs.Empty); }
        }

        private void RemovePlaceholder(object sender, EventArgs e)
        {
            if (isPlaceholder)
            {
                this.Text = "";
                this.ForeColor = Color.Black;
                isPlaceholder = false;
            }
            isFocused = true;
            this.Invalidate();
        }

        private void SetPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.Text))
            {
                isPlaceholder = true;
                this.Text = placeholderText;
                this.ForeColor = Color.DarkGray;
            }
            isFocused = false;
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Pen pen = new Pen(isFocused ? focusBorderColor : borderColor, borderSize))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate();
        }
    }
}
