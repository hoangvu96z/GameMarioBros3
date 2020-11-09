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
    public enum ModifiledObjectState
    {
        None,
        Moving,
        Sizing,
        Selecting
    }
    public interface IModifiledObjectInterface
    {
        GroupSelectable Objects { get; }
        GroupSelectable CurrentObject { get; set; }
        int TileWidth { get; }
        int TileHeight { get; }
        Unit Unit { get; }
        bool CanSelectObject { get; set; }
        Cursor SelectCursor { get; set; }
        void AddLayerObject(ISelectableObject @object);
        void RemoveLayerObject(ISelectableObject @object);
        void RefreshCanvas();
        void OnMoveEnd(ISelectableObject selectableObject, Point denta);
        void OnSizingEnd(ISelectableObject selectableObject, int sizingValue, MouseMovingBase mouseManager);
        Rectangle SelectingRect { get; set; }
        bool CanMultiSelect { get; }
    }
    [Serializable]
    public class ModifiedObjectService
    {
        IModifiledObjectInterface @interface;
        ModifiledObjectState _modifiledObjectState;
        IConvertWorldView _convertWorldView;
        ISelectableObject _prepareObject;
        int _prepareSizingValue;
        MouseMovingBase _mouseManager;

        int keyMoveDx;
        int keyMoveDy;

        int keyMoveXDistance;
        int keyMoveYDistance;

        public ModifiedObjectService(IModifiledObjectInterface @interface, IConvertWorldView convertWorldView)
        {
            this.@interface = @interface;
            _convertWorldView = convertWorldView;
            _mouseManager = new MouseMovingBase();
            keyMoveXDistance = 0;
            keyMoveYDistance = 0;
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

        private void OnKeyArrowDown()
        {
            if (@interface.CurrentObject != null)
            {
                @interface.CurrentObject.Move(new Point(keyMoveDx, keyMoveDy));
                @interface.RefreshCanvas();

                keyMoveXDistance += keyMoveDx;
                keyMoveYDistance += keyMoveDy;
            }
        }

        public void OnKeyUpDown()
        {
            keyMoveDx = 0;
            keyMoveDy = -1;
            OnKeyArrowDown();
        }


        public void OnKeyDownDown()
        {
            keyMoveDx = 0;
            keyMoveDy = 1;
            OnKeyArrowDown();
        }
        public void OnKeyLeftDown()
        {
            keyMoveDx = -1;
            keyMoveDy = 0;
            OnKeyArrowDown();
        }
        public void OnKeyRightDown()
        {
            keyMoveDx = 1;
            keyMoveDy = 0;
            OnKeyArrowDown();
        }

        public void OnKeyUp()
        {
            if (@interface.CurrentObject != null && !(keyMoveXDistance == 0 && keyMoveYDistance == 0))
                @interface.OnMoveEnd(@interface.CurrentObject, new Point(keyMoveXDistance, keyMoveYDistance));
            keyMoveXDistance = 0;
            keyMoveYDistance = 0;
        }

        public void OnMouseDown(PointF screenLocation)
        {
            _mouseManager.Active = true;
            _mouseManager.FirstCorner = _convertWorldView.GetWorldPoint(screenLocation);
            _mouseManager.SecondCorner = _mouseManager.FirstCorner;

            switch (_modifiledObjectState)
            {
                case ModifiledObjectState.None:
                    if (!@interface.CanMultiSelect && @interface.CanSelectObject && @interface.CurrentObject != null)
                    {
                        @interface.RemoveLayerObject(@interface.CurrentObject);
                        @interface.CurrentObject = null;
                        @interface.RefreshCanvas();
                    }
                    _modifiledObjectState = ModifiledObjectState.Selecting;

                    break;
                case ModifiledObjectState.Moving:
                    if (_prepareObject != null)
                    {
                        if (!@interface.CanMultiSelect)
                        {
                            if (@interface.CurrentObject != null)
                            {
                                @interface.RemoveLayerObject(@interface.CurrentObject);
                            }
                            @interface.CurrentObject = new GroupSelectable();
                        }
                        else if (@interface.CurrentObject == null)
                        {
                            @interface.CurrentObject = new GroupSelectable();
                        }

                        @interface.CurrentObject.AddObject(_prepareObject);
                        @interface.AddLayerObject(@interface.CurrentObject);
                        @interface.RefreshCanvas();
                    }
                    break;
                case ModifiledObjectState.Sizing:
                    break;
            }
        }

        public void OnMouseMove(PointF screenLocation)
        {
            if (!@interface.CanSelectObject)
            {
                return;
            }
            if (_mouseManager.Active)
            {
                PointF oldFirstCorner = _mouseManager.FirstCorner;
                _mouseManager.FirstCorner = _mouseManager.SecondCorner;
                _mouseManager.SecondCorner = _convertWorldView.GetWorldPoint(screenLocation);

                switch (_modifiledObjectState)
                {
                    case ModifiledObjectState.None:
                        break;
                    case ModifiledObjectState.Moving:
                        if (@interface.CurrentObject != null)
                        {
                            @interface.CurrentObject.Move(_mouseManager.Delta);
                            @interface.RefreshCanvas();
                        }
                        break;
                    case ModifiledObjectState.Sizing:
                        if (@interface.CurrentObject != null)
                        {
                            @interface.CurrentObject.SetSizing(_prepareSizingValue, _mouseManager.FirstCorner.ToPoint(), _mouseManager.SecondCorner.ToPoint());
                            @interface.RefreshCanvas();
                        }
                        @interface.RefreshCanvas();
                        break;
                    case ModifiledObjectState.Selecting:
                        _mouseManager.FirstCorner = oldFirstCorner;
                        var r = @interface.SelectingRect = _mouseManager.BoudingRect;
                        if (@interface.CurrentObject == null)
                        {
                            @interface.CurrentObject = new GroupSelectable();
                            @interface.AddLayerObject(@interface.CurrentObject);
                        }
                        try
                        {
                            if (!@interface.CanMultiSelect)
                            {
                                @interface.CurrentObject.Objects.RemoveAll(obj
                                    => ((GameObject)obj).Active==false || (!obj.BoudingRect.IntersectsWith(r))
                                    );
                            }
                            foreach (GameObject obj in @interface.Objects.Objects)
                            {
                                if (!obj.Active)
                                {
                                    continue;
                                }
                                if (!@interface.CurrentObject.Objects.Contains(obj) && obj.BoudingRect.IntersectsWith(r))
                                {
                                    @interface.CurrentObject.Objects.Add(obj);
                                }
                            }
                        }
                        catch
                        {

                        }

                        @interface.RefreshCanvas();
                        break;
                }
                _mouseManager.FirstCorner = oldFirstCorner;
            }
            else
            {
                _prepareObject = null;
                var ptWorld = _convertWorldView.GetWorldPoint(screenLocation);
                var objCanSelectByPoint = @interface.Objects.ObjectCanSelectByPoint(ptWorld);
                if (objCanSelectByPoint != null)
                {
                    @interface.SelectCursor = Cursors.SizeAll;
                    _modifiledObjectState = ModifiledObjectState.Moving;
                    if (@interface.CurrentObject == null)
                    {
                        _prepareObject = objCanSelectByPoint;
                    }
                    else
                    {
                        if (@interface.CurrentObject.ContainsObject(objCanSelectByPoint))
                        {
                            _prepareSizingValue = @interface.CurrentObject.SizingPointValue(ptWorld);
                            if (_prepareSizingValue != -1)
                            {
                                _modifiledObjectState = ModifiledObjectState.Sizing;
                                @interface.SelectCursor = PointSizeValueHelper.GetCursor(_prepareSizingValue);
                            }
                        }
                        else
                        {
                            _prepareObject = objCanSelectByPoint;
                        }
                    }
                }
                else
                {
                    _modifiledObjectState = ModifiledObjectState.None;
                }
            }
        }
        public void OnMouseUp()
        {
            _mouseManager.Active = false;
            switch (_modifiledObjectState)
            {
                case ModifiledObjectState.None:
                    break;
                case ModifiledObjectState.Moving:
                    @interface.OnMoveEnd(@interface.CurrentObject, _mouseManager.Delta);
                    break;
                case ModifiledObjectState.Sizing:
                    @interface.OnSizingEnd(@interface.CurrentObject, _prepareSizingValue, _mouseManager);
                    break;
                case ModifiledObjectState.Selecting:
                    _modifiledObjectState = ModifiledObjectState.None;
                    @interface.SelectingRect = Rectangle.Empty;
                    @interface.RefreshCanvas();
                    break;
            }
        }
    }
}
