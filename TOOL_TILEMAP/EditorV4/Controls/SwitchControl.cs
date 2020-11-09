using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorV4.Controls
{

    public class SwitchControl : CheckBox
    {
        public SwitchControl()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            Padding = new Padding(6);
            AutoSize = false;
            timer = new Timer();
            CheckedDuration = 0.3;
            timer.Interval = 10;
            timer.Tick += Timer_Tick;
            CheckedChanged += SwitchControl_CheckedChanged;
            Cursor = Cursors.Hand;
        }

        private void SwitchControl_CheckedChanged(object sender, EventArgs e)
        {
            var value = Checked;
            var duration = CheckedDuration * 100;
            if (value == true)
            {
                currentX = 0;
                verlocity = Width / duration;
            }
            else
            {
                currentX = Width - Height + 1;
                verlocity = -Width / duration;
            }
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (verlocity < 0 && currentX + verlocity < 0)
            {
                currentX = 0;
                timer.Stop();
                return;
            }
            if (verlocity > 0 && currentX + Height - 1 + verlocity > Width)
            {
                currentX = Width - Height - 1;
                timer.Stop();
                return;
            }
            currentX += verlocity;
            Refresh();
        }

        Timer timer;

        public double CheckedDuration
        {
            get { return _checkedDuration; }
            set
            {
                _checkedDuration = value;
            }
        }
        private double currentX;


        double verlocity;
        private double _checkedDuration;

        protected override void OnPaint(PaintEventArgs e)
        {
            this.OnPaintBackground(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = new GraphicsPath())
            {
                var d = Padding.All;
                var r = this.Height - 2 * d;
                path.AddArc(d, d, r, r, 90, 180);
                path.AddArc(this.Width - r - d, d, r, r, -90, 180);
                path.CloseFigure();
                e.Graphics.FillPath(Checked ? Brushes.Orange : Brushes.LightGray, path);
                r = Height - 1;
                var rect = Checked ? new Rectangle((int)currentX, 0, r, r)
                                   : new Rectangle((int)currentX, 0, r, r);
                e.Graphics.FillEllipse(Checked ? Brushes.OrangeRed : Brushes.WhiteSmoke, rect);
            }
        }
    }
}
