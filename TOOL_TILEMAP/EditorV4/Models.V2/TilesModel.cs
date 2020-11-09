using EditorV4.Ultils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorV4.Models.V2
{
    public interface ITilesModelParent
    {
        int TileWidth { get; }
        int TileHeight { get; }
    }
    [Serializable]
    public class TilesModel : ITilesModel
    {
        public ITilesModelParent ITilesModelParent { get; set; }
        public int TileWidth
        {
            get { return ITilesModelParent.TileWidth; }
        }

        public int TileHeight
        {
            get { return ITilesModelParent.TileHeight; }
        }

        public int TileRows { get; set; }
        public int TileColumns { get; set; }
        public int TilesheetColumns { get; set; }
        public int[,] Matrix { get; set; }
        public Image Tilesheet
        {
            get
            {
                return _tilesheet;
            }
            set
            {
                _tilesheet = value;
                _bmpData = BitmapExtension.ToBase64String((Bitmap)_tilesheet, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        private string _bmpData;
        private Image _tilesheet;

        public string BmpData 
        {
            get
            {
                return _bmpData;
            }
            set
            {
                _tilesheet = BitmapExtension.Base64StringToBitmap(value);
                _bmpData = value;
            }
        }
    }
}
