using EditorV4.Models.V2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorV4.EditorObjects
{
    [Serializable]
    public class GroupSelectable : ISelectableObject
    {

        public List<ISelectableObject> Objects { get; set; }
        public GroupSelectable()
        {
            Objects = new List<ISelectableObject>();
        }
        public void AddObject(ISelectableObject selectableObject)
        {
            if (!Objects.Contains(selectableObject))
            {
                Objects.Add(selectableObject);
            }
        }
        public void RemoveObject(ISelectableObject selectableObject)
        {
            Objects.Remove(selectableObject);
        }
        public bool ContainsObject(ISelectableObject selectableObject)
        {
            return Objects.Contains(selectableObject);
        }

        [Category("Properties")]
        public bool Resizeable
        {
            get
            {
                foreach (var obj in Objects)
                {
                    if (obj.Resizeable)
                        return true;
                }
                return false;
            }
        }

        [Browsable(false)]
        public bool Selected { get; set; }

        [Category("Properties")]
        public bool Movable
        {
            get
            {
                foreach (var obj in Objects)
                {
                    if (obj.Movable)
                        return true;
                }
                return false;
            }
        }

        internal void ClearAll()
        {
            Objects.Clear();
        }

        public bool CanSelectByPoint(Point p)
        {
            foreach (var obj in Objects)
            {
                if (!((GameObject)obj).Active)
                    continue;
                if (obj.CanSelectByPoint(p))
                    return true;
            }
            return false;
        }

        public ISelectableObject ObjectCanSelectByPoint(Point p)
        {
            foreach (var obj in Objects)
            {
                if (!((GameObject)obj).Active)
                    continue;
                if (obj.CanSelectByPoint(p))
                    return obj;
            }
            return null;
        }

        [Category("Properties")]
        public int Size
        {
            get
            {
                return Objects.Count;
            }
        }

        public Rectangle BoudingRect => throw new NotImplementedException();

        public int SizingPointValue(Point p)
        {
            foreach (var obj in Objects)
            {
                var value = obj.SizingPointValue(p);
                if (value != -1)
                    return value;
            }
            return -1;
        }



        public void Move(Point delta)
        {
            Objects.ForEach(x =>
            {
                if (x.Movable)
                    x.Move(delta);
            });
        }

        public void SetSizing(int sizingValue, Point ptBegin, Point ptEnd)
        {
            Objects.ForEach(x =>
            {
                if (x.Resizeable)
                    x.SetSizing(sizingValue, ptBegin, ptEnd);
            });
        }

        public void DrawSelected(Graphics g, CanvasViewport viewport, IConvertWorldView convertWorldView)
        {
            Objects.ForEach(x => x.DrawSelected(g, viewport, convertWorldView));
        }

        public void OnPaint(Graphics g, CanvasViewport viewport)
        {
            Objects.ForEach(x => x.OnPaint(g, viewport));
        }

        public void OnPaintInView(Graphics viewGraphics, CanvasViewport viewViewport, IConvertWorldView convertWorldView)
        {
            Objects.ForEach(x => x.OnPaintInView(viewGraphics, viewViewport, convertWorldView));
            if(Selected)
            {
                DrawSelected(viewGraphics, viewViewport, convertWorldView);
            }
        }

        internal void Move(object delta)
        {
            throw new NotImplementedException();
        }
    }
}
