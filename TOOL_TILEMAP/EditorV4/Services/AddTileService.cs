using EditorV4.Models.V2;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorV4.Services
{
    public interface AddTileInterface
    {
        bool CanAddTile { get; }
        Point TilePrepareAddLocation { get; set; }
        void RefreshCanvas();
        void AddTile(int rowIndex,int columnIndex, int tileIndex);
        int SelectedTileIndex { get; }
        TilesModel TilesModel { get; }
    }
    [Serializable]
    public class AddTileService
    {
        AddTileInterface @interface;
        IConvertWorldView _convertWorldView;

        public AddTileService(AddTileInterface @interface, IConvertWorldView convertWorldView)
        {
            this.@interface = @interface;
            _convertWorldView = convertWorldView;
        }

        int oldRowIndex, oldColIndex;

        public void OnMouseDown(MouseEventArgs mouseEvent)
        {
            if (!@interface.CanAddTile)
                return;

            var p = _convertWorldView.GetWorldPoint(mouseEvent.Location);
            int rowIndex = p.Y / @interface.TilesModel.TileHeight;
            int colIndex = p.X / @interface.TilesModel.TileWidth;

            if (rowIndex == oldRowIndex && colIndex == oldColIndex)
                return;

            oldRowIndex = rowIndex;
            oldColIndex = colIndex;

            @interface.AddTile(rowIndex,colIndex, @interface.SelectedTileIndex);
            @interface.RefreshCanvas();
        }
        public void OnMouseMove(MouseEventArgs mouseEvent)
        {
            if (!@interface.CanAddTile)
                return;
            if (mouseEvent.Button == MouseButtons.Left)
            {
                OnMouseDown(mouseEvent);
            }
            if (mouseEvent.Button == MouseButtons.None)
            {
                @interface.TilePrepareAddLocation = _convertWorldView.GetWorldPoint(mouseEvent.Location);
                @interface.RefreshCanvas();
                oldColIndex = -1;
                oldRowIndex = -1;
            }
        }
    }
}
