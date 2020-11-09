using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EditorV4.Controls.TreeViewControl;
using EditorV4.EditorObjects;
using EditorV4.Forms;
using EditorV4.Ultils;

namespace EditorV4.Models.V2
{
    public interface TilesheetCanvasInterface
    {
        int TileWidth { get; }
        int TileHeight { get; }
        Color CurrentTileColor { get; }
        Color SelectedTileColor { get; }
        void AddGameObjectCategory(GameObjectCategory gameObjectCategory, TreeViewObjectType treeViewObjectType = TreeViewObjectType.CategoryObjectFromTile);
        DataTable CollisionTypeTable { get; }
        void AddCollisionType(string collisionTypeName);
        List<GameObjectCategory> GameObjectCategories { get; }
        void AddTileObjectFromAvailableObjectCategory(int tileIndex, GameObjectCategory gameObjectCategory);
    }
    [Serializable]
    public class TilesheetCanvas : IDrawableObject
    {
        Image _tilesheet;
        public Image Tilesheet
        {
            get
            {
                return _tilesheet;
            }
            set
            {
                _columns = value.Width / @interface.TileWidth;
                _tilesheet = value;
            }
        }
        private int _columns;
        public TilesheetCanvasInterface @interface { get; set; }
        Point _currentLocation;
        Point _selectedTile;
        public Point SelectedTilePoint
        {
            get { return _selectedTile; }
            set { _selectedTile = value; }
        }
        public int CurrentRow
        {
            get
            {
                return _currentLocation.Y / @interface.TileHeight;
            }
        }
        public int CurrentColumn
        {
            get
            {
                return _currentLocation.X / @interface.TileWidth;
            }
        }
        public int CurrentIndex
        {
            get
            {
                return CurrentRow * _columns + CurrentColumn;
            }
        }

        public int TileColumns
        {
            get
            {
                return _columns;
            }
        }

        public TilesheetCanvas()
        {
            _selectedTile = new Point(-1, -1);
        }

        private void DrawCurrentTile(Graphics viewGraphics, CanvasViewport viewport)
        {
            if (CurrentColumn < 0 || CurrentRow < 0)
                return;
            int x = CurrentColumn * @interface.TileWidth;
            int y = CurrentRow * @interface.TileHeight;
            PointF viewLocation = viewport.GetWorldToViewLocation(new PointF(x, y));
            SizeF sizeValue = new SizeF(@interface.TileWidth * viewport.Scale, @interface.TileHeight * viewport.Scale);
            viewGraphics.DrawRectangle(new Pen(@interface.CurrentTileColor, 2), viewLocation.X, viewLocation.Y, sizeValue.Width, sizeValue.Height);
        }

        public void OnPaint(Graphics g, CanvasViewport viewport)
        {
            g.DrawImageFromOtherImage(Tilesheet, viewport.BoudingRect, new RectangleF(0, 0, viewport.Width, viewport.Height));
        }


        public void OnPaintInView(Graphics viewGraphics, CanvasViewport viewport, IConvertWorldView convertWorldView)
        {
            DrawCurrentTile(viewGraphics, viewport);
            DrawSelectedTile(viewGraphics, viewport);
        }

        private void DrawSelectedTile(Graphics viewGraphics, CanvasViewport viewport)
        {
            if (CurrentColumn < 0 || CurrentRow < 0)
                return;
            int x = _selectedTile.X * @interface.TileWidth;
            int y = _selectedTile.Y * @interface.TileHeight;
            PointF viewLocation = viewport.GetWorldToViewLocation(new PointF(x, y));
            SizeF sizeValue = new SizeF(@interface.TileWidth * viewport.Scale, @interface.TileHeight * viewport.Scale);
            viewGraphics.DrawRectangle(new Pen(@interface.SelectedTileColor, 2), viewLocation.X, viewLocation.Y, sizeValue.Width, sizeValue.Height);

        }

        public void OnMouseMove(Point mouseLocation)
        {
            _currentLocation = mouseLocation;
        }

        internal void CreateObjectCategoryFromSelectedTile()
        {
            CreateObjectCategoryForm createObjectCategoryForm = new CreateObjectCategoryForm();
            try
            {
                createObjectCategoryForm.ObjCategoryImage = Tilesheet.CropImage(new RectangleF(_selectedTile.X * @interface.TileWidth,
                _selectedTile.Y * @interface.TileHeight,
                 @interface.TileWidth,
                  @interface.TileHeight));
            }
            catch
            {
                return;
            }
            
            createObjectCategoryForm.CollisionTypeDataSource = @interface.CollisionTypeTable;
            if (createObjectCategoryForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int tileIndex = _selectedTile.Y * _columns + _selectedTile.X;
                foreach(var obj in @interface.GameObjectCategories)
                {
                    if (obj.TileIndex == tileIndex)
                    {
                        @interface.AddTileObjectFromAvailableObjectCategory(tileIndex, obj);
                        return;
                    }
                }
                GameObjectCategory gameObjectCategory = new GameObjectCategory();
                gameObjectCategory.Id = createObjectCategoryForm.ObjectCategoryId;
                gameObjectCategory.Name = createObjectCategoryForm.ObjectCategoryName;
                gameObjectCategory.ObjectCategoryImage = createObjectCategoryForm.ObjCategoryImage;
                gameObjectCategory.TileIndex = tileIndex;
                @interface.AddCollisionType(createObjectCategoryForm.CollisionTypeName);
                gameObjectCategory.CollisionType = createObjectCategoryForm.CollisionTypeName;
                @interface.AddGameObjectCategory(gameObjectCategory);
            }
        }

        internal void OnMouseDown(Point point)
        {
            _selectedTile.X = _currentLocation.X / @interface.TileWidth;
            _selectedTile.Y = _currentLocation.Y / @interface.TileHeight;
        }
    }
}
