using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorV4.Models.V2
{
    public enum CanvasState
    {
        NONE,
        DRAWABLE
    }
    [Serializable]
    public class EditorCanvas : IDrawableObject, IViewportLimit
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public CanvasState CanvasState { get; set; }
        private List<IDrawableObject> DrawableObjects { get; set; }
        public int Left { get { return 0; } }
        public int Right { get { return Width; } }
        public int Top { get { return 0; } }
        public int Bottom { get { return Height; } }
        public EditorCanvas()
        {
            DrawableObjects = new List<IDrawableObject>();
            CanvasState = CanvasState.NONE;
        }
        public void AppendObject(IDrawableObject drawableObject)
        {
            if (!DrawableObjects.Contains(drawableObject))
                DrawableObjects.Add(drawableObject);
        }
        public void ClearObjects()
        {
            DrawableObjects.Clear();
        }
        public void InsertObject(IDrawableObject drawableObject, int index)
        {
            DrawableObjects.Insert(index, drawableObject);
        }
        public void RemoveObject(IDrawableObject drawableObject)
        {
            DrawableObjects.Remove(drawableObject);
        }
        public virtual void OnPaint(Graphics g, CanvasViewport viewport)
        {
            foreach (var obj in DrawableObjects)
            {
                obj.OnPaint(g, viewport);
            }
        }

        public void OnPaintInView(Graphics viewGraphics, CanvasViewport viewViewport, IConvertWorldView convertWorldView)
        {
            foreach (var obj in DrawableObjects)
            {
                obj.OnPaintInView(viewGraphics, viewViewport, convertWorldView);
            }
        }
    }
}
