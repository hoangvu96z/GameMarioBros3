using EditorV4.Controls.TreeViewControl;
using EditorV4.Models.V2;
using EditorV4.Ultils;
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
    [DefaultProperty("Display")]
    public class GameObject : BaseObject
    {
        public bool IsGrouped { get; set; }

        [Browsable(false)]
        public Stack<List<GameObject>> ObjectsGrouped { get; set; }
        public Stack<List<GameObject>> ObjectsUnGrouped { get; set; }


        [Category("Properties")]
        public virtual Image ObjectImage
        {
            get { return ObjectCategory.ObjectCategoryImage; }
            set
            {
                if (HasImage)
                    ObjectCategory.ObjectCategoryImage = value;
            }
        }

        public GameObject()
        {
            Active = true;
            ObjectsGrouped = new Stack<List<GameObject>>();
            ObjectsUnGrouped = new Stack<List<GameObject>>();
        }

        [Browsable(false)]
        public bool Active { get; set; }

        public virtual string Name
        {
            get
            {
                return ObjectCategory.Name;
            }
        }
        [Category("Properties")]
        public virtual string Display
        {
            get { return String.Format("{0} (Id : {1}) (Location: {2},{3})", ObjectCategory.Name, ObjectCategory.Id, Location.X, Location.Y); }
        }
        private GameObjectCategory _objectCategory;
        [Browsable(false)]
        internal int Index { get; set; }
        [Browsable(false)]
        public GameObjectCategory ObjectCategory
        {
            get => _objectCategory; set
            {
                _objectCategory = value;
                if (_objectCategory.ObjectCategoryImage != null)
                    Size = _objectCategory.ObjectCategoryImage.Size;
            }
        }

        [Browsable(false)]
        public bool HasImage { get; set; }
        public override void OnPaint(Graphics g, CanvasViewport viewport)
        {
            //if (HasImage)
            //{
            //    var location = viewport.GetWorldToViewLocation(Location).ToPoint();
            //    g.DrawImage(ObjectImage, new Rectangle(location, Size),
            //        new Rectangle(Point.Empty, ObjectImage.Size),
            //        GraphicsUnit.Pixel
            //        );
            //}
        }

        public override void OnPaintInView(Graphics viewGraphics, CanvasViewport viewport, IConvertWorldView convertWorldView)
        {
            if (!Active)
                return;
            if (HasImage)
            {
                RectangleF locationRect = new RectangleF(Location,
                    Size
                    );
                locationRect = convertWorldView.GetViewRect(locationRect);

                var sizedImage = ObjectImage.ResizeImage((int)locationRect.Width, (int)locationRect.Height);
                viewGraphics.DrawImageUnscaled(sizedImage, locationRect.Location.ToPoint());

                //viewGraphics.DrawImageFromOtherImage(ObjectImage,
                //    new RectangleF(Point.Empty, ObjectImage.Size),
                //    locationRect);
            }
            base.OnPaintInView(viewGraphics, viewport, convertWorldView);
        }

        [Browsable(false)]
        public TreeViewObject TreeViewObject { get; set; }
        [Browsable(false)]
        public int TreeViewObjectIndex { get; internal set; }
        internal virtual string GetImageKey()
        {
            return "Objects" + ObjectCategory.Index;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
