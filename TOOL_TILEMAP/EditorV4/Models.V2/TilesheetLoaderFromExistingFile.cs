using EditorV4.Ultils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorV4.Models.V2
{
    class TileModel
    {
        public Image Image { get; set; }
        public int Index { get; set; }
    }
    public interface ILoaderInterface
    {
        void EnableWaiting();
        void DisableWaiting();
        void SetVolumeWaiting(int volume);
    }
    public static class TilesheetLoaderFromExistingFile
    {
        static bool CompareImage(this Image src, Image dest)
        {
            var bmp1 = (Bitmap)src;
            var bmp2 = (Bitmap)dest;
            if (bmp1.Size != bmp2.Size)
            {
                return false;
            }
            if (bmp1 == bmp2)
                return true;

            var rect = new Rectangle(0, 0, bmp1.Width, bmp1.Height);

            BitmapData bmpData1 = null;


            bmpData1 = bmp1.LockBits(rect, ImageLockMode.ReadOnly, bmp1.PixelFormat);

            try
            {
                BitmapData bmpData2 = null;

                bmpData2 = bmp2.LockBits(rect, ImageLockMode.ReadOnly, bmp2.PixelFormat);

                try
                {
                    unsafe
                    {
                        var ptr1 = (byte*)bmpData1.Scan0.ToPointer();
                        var ptr2 = (byte*)bmpData2.Scan0.ToPointer();
                        var width = 3 * rect.Width; // for 24bpp pixel data

                        for (var y = 0; y < rect.Height; y++)
                        {
                            for (var x = 0; x < width; x++)
                            {
                                if (*ptr1 != *ptr2)
                                {
                                    return false;
                                }

                                ptr1++;
                                ptr2++;
                            }

                            ptr1 += bmpData1.Stride - width;
                            ptr2 += bmpData2.Stride - width;
                        }
                    }
                }
                finally
                {
                    bmp2.UnlockBits(bmpData2);
                }
            }
            finally
            {
                bmp1.UnlockBits(bmpData1);
            }

            return true;
        }
        static TileModel TileHasImage(this List<TileModel> tileModels, Image item)
        {
            foreach (var tile in tileModels)
            {
                if (tile.Image.CompareImage(item))
                {
                    return tile;
                }
            }
            return null;
        }
        public static void LoadFromExistingFile(this ITilesModel tilesModel, String imagePath, ILoaderInterface loaderInterface = null)
        {
            if (tilesModel == null)
                throw new Exception();
            Image background = Image.FromFile(imagePath);
            tilesModel.TileRows = background.Height / tilesModel.TileHeight;
            if(background.Height% tilesModel.TileHeight!=0)
            {
                tilesModel.TileRows++;
            }
            tilesModel.TileColumns = background.Width / tilesModel.TileWidth;
            if (background.Width % tilesModel.TileWidth != 0)
            {
                tilesModel.TileColumns++;
            }

            Image newImage = new Bitmap(tilesModel.TileColumns * tilesModel.TileWidth, tilesModel.TileRows * tilesModel.TileHeight);
            RectangleF r = new RectangleF(0, 0, background.Width, background.Height);
            Graphics.FromImage(newImage).DrawImageFromOtherImage(background, r, r);
            background.Dispose();
            background = newImage;
            tilesModel.Matrix = new int[tilesModel.TileRows, tilesModel.TileColumns];
            List<TileModel> tileModels = new List<TileModel>();

            if (loaderInterface != null)
            {
                loaderInterface.EnableWaiting();
            }

            int currentVolume = 0;

            for (int rIndex = 0; rIndex < tilesModel.TileRows; rIndex++)
            {
                for (int cIndex = 0; cIndex < tilesModel.TileColumns; cIndex++)
                {
                    Rectangle cropedRect = new Rectangle(cIndex * tilesModel.TileWidth, rIndex * tilesModel.TileHeight, tilesModel.TileWidth, tilesModel.TileHeight);
                    Image cropedImage = background.CropImage(cropedRect);
                    TileModel tileHasImage = tileModels.TileHasImage(cropedImage);
                    if (tileHasImage != null)
                    {
                        tilesModel.Matrix[rIndex, cIndex] = tileHasImage.Index;
                    }
                    else
                    {
                        TileModel tileModel = new TileModel()
                        {
                            Image = cropedImage,
                            Index = tileModels.Count
                        };
                        tileModels.Add(tileModel);
                        tilesModel.Matrix[rIndex, cIndex] = tileModel.Index;
                    }

                    if (loaderInterface != null)
                    {
                        currentVolume++;
                        loaderInterface.SetVolumeWaiting((int)100.0f * currentVolume / (tilesModel.TileRows * tilesModel.TileColumns));
                    }
                }
            }

            tilesModel.TilesheetColumns = (int)(Math.Sqrt(tileModels.Count));
            int tileSheetColumns = tilesModel.TilesheetColumns;

            int tileSheetRows = tileModels.Count / tilesModel.TilesheetColumns;

            if (tileModels.Count % tilesModel.TilesheetColumns != 0)
            {
                tileSheetRows++;
            }
            tilesModel.Tilesheet = new Bitmap(tilesModel.TilesheetColumns * tilesModel.TileWidth,
                tileSheetRows * tilesModel.TileHeight);

            foreach (var tilesheet in tileModels)
            {
                int index = tilesheet.Index;
                int x = (index % tileSheetColumns) * tilesModel.TileWidth;
                int y = (index / tileSheetColumns) * tilesModel.TileHeight;

                Graphics.FromImage(tilesModel.Tilesheet).DrawImageFromOtherImage(tilesheet.Image,
                    new RectangleF(0, 0, tilesheet.Image.Width, tilesheet.Image.Height),
                    new RectangleF(x, y, tilesheet.Image.Width, tilesheet.Image.Height)
                    );
                tilesheet.Image.Dispose();
            }

            background.Dispose();
            if (loaderInterface != null)
                loaderInterface.DisableWaiting();
        }
    }
}
