using EditorV4.EditorObjects;
using EditorV4.Ultils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorV4.Models.V2
{
    public interface FocusedObjectLayerInterface
    {
        GameObjectCategory FocusedObjectCategory { get; }
        PointF FocusedObjectCategoryLocation { get; }
    }
    [Serializable]
    public class FocusedObjectLayer : IDrawableObject
    {
        FocusedObjectLayerInterface @interface;
        public FocusedObjectLayer(FocusedObjectLayerInterface @interface)
        {
            this.@interface = @interface;
        }

        public void OnPaint(Graphics g, CanvasViewport viewport)
        {
        }

        public void OnPaintInView(Graphics viewGraphics, CanvasViewport viewViewport, IConvertWorldView convertWorldView)
        {
            if (@interface.FocusedObjectCategory != null)
            {
                if(@interface.FocusedObjectCategory.TreeViewObject.TreeViewObjectType == Controls.TreeViewControl.TreeViewObjectType.CategoryRectangle)
                {
                    return;
                }
                RectangleF locationRect = new RectangleF(@interface.FocusedObjectCategoryLocation,
                    @interface.FocusedObjectCategory.ObjectCategoryImage.Size
                    );
                locationRect = convertWorldView.GetViewRect(locationRect);
                viewGraphics.DrawImageFromOtherImage(@interface.FocusedObjectCategory.ObjectCategoryImage,
                    new RectangleF(Point.Empty, @interface.FocusedObjectCategory.ObjectCategoryImage.Size),
                    locationRect);
            }
        }
    }
}
