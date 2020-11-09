using EditorV4.EditorObjects;
using EditorV4.Models.V2;
using EditorV4.Ultils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorV4.Services
{
    public interface ICreateObject
    {
        bool IsCreateRect { get; }
        GroupSelectable Objects { get; }
        GroupSelectable CurrentObject { get; set; }
        void RefreshCanvas();
        void OnSizing(ISelectableObject @object);
        void AddLayerObject(ISelectableObject @object);
        void AddGameObject(GameObject @object, bool isUndo = true);
        void RemoveLayerObject(ISelectableObject @object);
        int TileWidth { get; }
        int TileHeight { get; }
        Unit Unit { get; }

        Cursor SelectCursor { get; set; }
        GameObjectCategory FocusedObjectCategory { get; }
        PointF FocusedObjectCategoryLocation { get; set; }

    }

    public enum CreateObjectState
    {
        None,
        CreateRectangle,
        CreateObjectFocused
    }

    public enum Unit
    {
        Pixel,
        Tile
    }
    [Serializable]
    public class CreateObjectService
    {
        ICreateObject @interface;
        PointF _oldSecondCorner;

        public CreateObjectService(ICreateObject @interface, IConvertWorldView convertWorldView)
        {
            this.@interface = @interface;
            _convertWorldView = convertWorldView;
            _mouseMoving = new MouseMovingBase();
        }

        GroupSelectable CurrentObject
        {
            get
            {
                return @interface.CurrentObject;
            }
            set
            {
                @interface.CurrentObject = value;
            }
        }

        IConvertWorldView _convertWorldView;

        MouseMovingBase _mouseMoving;
        public CreateObjectState CreateObjectState { get; set; }


        private void CreateRectangleObject()
        {
            @interface.RemoveLayerObject(CurrentObject);
            CurrentObject = new GroupSelectable();
            RectangleObject obj = new RectangleObject();
            obj.X = (int)_mouseMoving.FirstCorner.X;
            obj.Y = (int)_mouseMoving.FirstCorner.Y;
            obj.ObjectCategory = @interface.FocusedObjectCategory;
            obj.Size = Size.Empty;
            CurrentObject.AddObject(obj);
            @interface.AddLayerObject(CurrentObject);
            @interface.AddGameObject(obj);
        }

        private void ResizeCurrentObject(GroupSelectable currentObject)
        {
            currentObject.SetSizing(_mouseMoving.SizingValue, _oldSecondCorner.ToPoint(), _mouseMoving.SecondCorner.ToPoint());
        }

        PointF GetPointByUnit(PointF p)
        {
            switch (@interface.Unit)
            {
                case Unit.Pixel:
                    break;
                case Unit.Tile:
                    p.X = @interface.TileWidth * ((int)(p.X) / @interface.TileWidth);
                    p.Y = @interface.TileWidth * ((int)(p.Y) / @interface.TileHeight);
                    break;
            }
            return p;
        }

        PointF GetSecondPointByUnit(PointF p)
        {
            switch (@interface.Unit)
            {
                case Unit.Pixel:
                    break;
                case Unit.Tile:
                    p.X = @interface.TileWidth * ((int)(p.X + @interface.TileWidth) / @interface.TileWidth);
                    p.Y = @interface.TileWidth * ((int)(p.Y + @interface.TileHeight) / @interface.TileHeight);
                    break;
            }
            return p;
        }
        public void OnMouseDown(PointF screenLocation)
        {
            switch (CreateObjectState)
            {
                case CreateObjectState.None:
                    break;
                case CreateObjectState.CreateRectangle:
                    _mouseMoving.Active = true;
                    _mouseMoving.FirstCorner = GetPointByUnit(_convertWorldView.GetWorldPointF(screenLocation));
                    _mouseMoving.SecondCorner = _mouseMoving.FirstCorner;
                    _mouseMoving.SizingValue = PointSizeValueHelper.FromHV(1, 1);
                    CreateRectangleObject();
                    break;
                case CreateObjectState.CreateObjectFocused:
                    GameObject gameObject = new GameObject();
                    gameObject.ObjectCategory = @interface.FocusedObjectCategory;
                    gameObject.Location = @interface.FocusedObjectCategoryLocation.ToPoint();
                    gameObject.Size = @interface.FocusedObjectCategory.ObjectCategoryImage.Size;
                    gameObject.HasImage = true;
                    gameObject.Resizeable = true;
                    gameObject.Movable = true;
                    gameObject.ObjectImage = @interface.FocusedObjectCategory.ObjectCategoryImage;
                    @interface.AddGameObject(gameObject);
                    break;
            }
        }
        public void OnMouseMove(PointF screenLocation)
        {

            switch (CreateObjectState)
            {
                case CreateObjectState.None:
                    break;
                case CreateObjectState.CreateRectangle:
                    if (_mouseMoving.Active)
                    {
                        _oldSecondCorner = _mouseMoving.SecondCorner;
                        _mouseMoving.SecondCorner = GetSecondPointByUnit(_convertWorldView.GetWorldPointF(screenLocation));
                        ResizeCurrentObject(@interface.CurrentObject);
                        @interface.RefreshCanvas();
                    }
                    @interface.SelectCursor = Cursors.Cross;
                    break;
                case CreateObjectState.CreateObjectFocused:
                    @interface.FocusedObjectCategoryLocation = GetPointByUnit(_convertWorldView.GetWorldPointF(screenLocation));
                    @interface.RefreshCanvas();
                    break;
            }
        }
        public void OnMouseUp()
        {
            switch (CreateObjectState)
            {
                case CreateObjectState.None:
                    break;
                case CreateObjectState.CreateRectangle:
                    _mouseMoving.Active = false;
                    break;
            }
        }

    }
}
