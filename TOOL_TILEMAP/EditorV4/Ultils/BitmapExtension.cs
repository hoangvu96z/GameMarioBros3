using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EditorV4.Ultils
{
    public static class BitmapExtension
    {
        public static Bitmap FromSize(float width, float height)
        {
            return new Bitmap((int)width, (int)height);
        }



        public static void DrawImageFromOtherImage(this Graphics g, Image image, RectangleF cropRect, RectangleF locationRect)
        {
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.DrawImage(image, locationRect, cropRect, GraphicsUnit.Pixel);

        }
        public static Image ResizeImage(this Image image, int width, int height)
        {
            if (width < 10)
                width = 10;
            if (height < 10)
                height = 10;
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            return destImage;
        }
        public static Image CropImage(this Image image, RectangleF cropRect)
        {
            Bitmap bmp = image as Bitmap;

            // Check if it is a bitmap:
            if (bmp == null)
                throw new ArgumentException("No valid bitmap");

            // Crop the image:
            Bitmap cropBmp = bmp.Clone(cropRect, bmp.PixelFormat);

            return cropBmp;
        }

        public static string ToBase64String(this Bitmap bmp, ImageFormat imageFormat)
        {
            string base64String = string.Empty;


            MemoryStream memoryStream = new MemoryStream();
            bmp.Save(memoryStream, imageFormat);


            memoryStream.Position = 0;
            byte[] byteBuffer = memoryStream.ToArray();


            memoryStream.Close();


            base64String = Convert.ToBase64String(byteBuffer);
            byteBuffer = null;


            return base64String;
        }

        public static Bitmap Base64StringToBitmap(this string
                                           base64String)
        {
            Bitmap bmpReturn = null;


            byte[] byteBuffer = Convert.FromBase64String(base64String);
            MemoryStream memoryStream = new MemoryStream(byteBuffer);


            memoryStream.Position = 0;


            bmpReturn = (Bitmap)Bitmap.FromStream(memoryStream);


            memoryStream.Close();
            memoryStream = null;
            byteBuffer = null;


            return bmpReturn;
        }

    }
}
