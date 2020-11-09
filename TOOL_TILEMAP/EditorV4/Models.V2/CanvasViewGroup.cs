using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorV4.Models.V2
{
    [Serializable]
    public class CanvasViewGroup : IConvertWorldView
    {
        private CanvasViewport _canvasViewport;
        private EditorCanvas _editorCanvas;
        private EditorCanvasRender _editorCanvasRender;
        private EditorCanvasScrollHandling _editorCanvasScrollHandling;

        public CanvasViewGroup(IEditorCanvasScrollbar scrollbar, int vpWidth, int vpHeight)
        {
            EditorCanvas = new EditorCanvas();
            EditorCanvasRender = new EditorCanvasRender();
            EditorCanvasScrollHandling = new EditorCanvasScrollHandling();
            CanvasViewport = new CanvasViewport(0, 0, vpWidth, vpHeight, EditorCanvas);
            CanvasViewport.Scale = 1.0f;

            EditorCanvas.Width = 1000;
            EditorCanvas.Height = 1000;
            EditorCanvasRender.Canvas = EditorCanvas;
            EditorCanvasRender.Viewport = CanvasViewport;
            EditorCanvasScrollHandling.CanvasScrollbar = scrollbar;
            EditorCanvasScrollHandling.Canvas = EditorCanvas;
            EditorCanvasScrollHandling.Viewport = CanvasViewport;
        }

        public virtual void OnPaint(Graphics graphics, IConvertWorldView convertWorldView)
        {
            EditorCanvasRender.RenderViewport(graphics,convertWorldView);
        }

        public Matrix GetWorldToViewMatrix()
        {
            return CanvasViewport.GetWorldToViewMatrix();
        }

        public CanvasViewport CanvasViewport { get => _canvasViewport; set => _canvasViewport = value; }
        public EditorCanvas EditorCanvas { get => _editorCanvas; set => _editorCanvas = value; }
        public EditorCanvasRender EditorCanvasRender { get => _editorCanvasRender; set => _editorCanvasRender = value; }
        public EditorCanvasScrollHandling EditorCanvasScrollHandling { get => _editorCanvasScrollHandling; set => _editorCanvasScrollHandling = value; }
    }
}
