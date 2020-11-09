using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace EditorV4.Controls
{

    public class ToolStripButtonCustom : ToolStripButton
    {
        public ToolStripButtonCustom() : base()
        {
            MouseLeave += ToolStripButtonCustom_MouseLeave;
        }

        public Image CheckedImage { get; set; }

        private void ToolStripButtonCustom_MouseLeave(object sender, EventArgs e)
        {
            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs mea)
        {
            Invalidate();
            base.OnMouseMove(mea);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if(!IsCheckBox || !Enabled)
            {
                return;
            }
            Checked = !Checked;
            base.OnMouseDown(e);
        }

        public bool IsCheckBox { get; set; }

        public static Bitmap MakeGrayscale3(Image original)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);
            //get a graphics object from the new image
            Graphics g = Graphics.FromImage(newBitmap);
            //create the grayscale ColorMatrix
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][]
              {
                 new float[] {.3f, .3f, .3f, 0, 0},
                 new float[] {.59f, .59f, .59f, 0, 0},
                 new float[] {.11f, .11f, .11f, 0, 0},
                 new float[] {0, 0, 0, 1, 0},
                 new float[] {0, 0, 0, 0, 1}
              });
            //create some image attributes
            ImageAttributes attributes = new ImageAttributes();
            //set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);
            //draw the original image on the new image
            //using the grayscale color matrix
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
               0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);
            //dispose the Graphics object
            g.Dispose();
            return newBitmap;
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = new Rectangle(0, 0, Width - 2, Height - 2);
            var cp = Cursor.Position;
            var thisPos = this.Parent.PointToScreen(this.Bounds.Location);
            var wRect = new Rectangle(thisPos, rect.Size);
            if(IsCheckBox && Checked)
            {
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(127, 128, 229), 1), rect);
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(128, 234, 234, 234)), rect);
            }
            if (Enabled)
            {
                if (wRect.Contains(cp))
                {
                    if (Control.MouseButtons == MouseButtons.Left)
                    {

                        using (var ellipsePath = new GraphicsPath())
                        {
                            ellipsePath.AddRectangle(rect);
                            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(127, 128, 229), 1), rect);

                        }
                    }
                    else
                    {
                        using (var ellipsePath = new GraphicsPath())
                        {
                            ellipsePath.AddRectangle(rect);
                            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(127, 128, 229), 1), rect);
                        }
                    }
                }
                else
                {
                    var borderRect = rect;
                    borderRect.Width -= 4;
                    borderRect.Height -= 4;
                    borderRect.X += 2;
                    borderRect.Y += 2;

                    // rotate

                    using (var ellipsePath = new GraphicsPath())
                    {
                        ellipsePath.AddRectangle(borderRect);
                    }


                    //e.Graphics.FillEllipse(br, borderRect);
                }
            }
            else
            {
            }
            var r = Width / 2;
            var dx = 3;
            var w = rect.Width - 2 * dx;

            var image = Image;
            if(IsCheckBox && Checked && CheckedImage!=null)
            {
                image = CheckedImage;
            }

            if (image == null)
                return;
            if (Enabled)
            {
                e.Graphics.DrawImage(image, new RectangleF(dx, dx, w, w), new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
            }
            else
            {
                e.Graphics.DrawImage(MakeGrayscale3(Image), new RectangleF(dx, dx, w, w), new Rectangle(0, 0, Image.Width, Image.Height), GraphicsUnit.Pixel);
            }

        }
    }
}
