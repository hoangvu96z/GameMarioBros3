using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorV4.Controls
{
    public delegate void OnSelectColor(Color color);
    public partial class ColorPickerControl : UserControl
    {
        OnSelectColor _onSelectColor;
        public event OnSelectColor OnSelectColorEvent
        {
            add
            {
                _onSelectColor += value;
            }
            remove
            {
                _onSelectColor -= value;
            }
        }
        public ColorPickerControl()
        {
            InitializeComponent();
        }
        static ColorDialog colorDialog = new ColorDialog();
        public String Label
        {
            get { return label.Text; }
            set { label.Text = value; }
        }
        public String Display
        {
            get { return txtColorDisplay.Text; }
            set { txtColorDisplay.Text = value; }
        }
        public Color SelectedColor
        {
            get { return btnSelectColor.BackColor; }
            set
            {
                btnSelectColor.BackColor = value;
                txtColorDisplay.Text = String.Format("({0},{1},{2})",
                    value.R, value.G, value.B);
            }
        }

        private void btnSelectColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = SelectedColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SelectedColor = colorDialog.Color;
            }
        }

        private void txtColorDisplay_TextChanged(object sender, EventArgs e)
        {
            var t = txtColorDisplay.Text;
            if (!t.StartsWith("("))
                return;
            if (!t.EndsWith(")"))
                return;
            t = t.Substring(1, t.Length - 2);
            var numberStrs = t.Split(',');

            if (numberStrs.Length != 3)
                return;

            var r = 0;
            if (!int.TryParse(numberStrs[0], out r))
            {
                return;
            }
            var g = 0;
            if (!int.TryParse(numberStrs[1], out g))
            {
                return;
            }

            var b = 0;
            if (!int.TryParse(numberStrs[2], out b))
            {
                return;
            }

            if (r > 255 || r < 0)
                return;
            if (g > 255 || g < 0)
                return;
            if (b > 255 || b < 0)
                return;
            btnSelectColor.BackColor = Color.FromArgb(r, g, b);

        }

        private void btnSelectColor_BackColorChanged(object sender, EventArgs e)
        {
            if (_onSelectColor != null)
            {
                _onSelectColor(((Button)sender).BackColor);
            }
        }
    }
}
