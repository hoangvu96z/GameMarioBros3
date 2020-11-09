using EditorV4.EditorObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorV4.Models.V2
{
    [Serializable]
    public class QuadNode
    {
        public static int MinimunSize = 100;
        public string Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public List<ISelectableObject> Objects { get; set; }
        public QuadNode TL { get; set; }
        public QuadNode TR { get; set; }
        public QuadNode BL { get; set; }
        public QuadNode BR { get; set; }
        public Rectangle BoudingRect
        {
            get
            {
                return new Rectangle(X, Y, Width, Height);
            }
        }

        public QuadNode(Rectangle rect, List<ISelectableObject> objects, string id)
        {
            X = rect.X;
            Y = rect.Y;
            Width = rect.Width;
            Height = rect.Height;
            Id = id;

            var boudingRect = BoudingRect;
            Objects = new List<ISelectableObject>();

            foreach (GameObject obj in objects)
            {
                if (!obj.Active)
                    continue;
                var objRect = obj.BoudingRect;
                if (objRect.IntersectsWith(boudingRect))
                {
                    Objects.Add(obj);
                }
            }

            if (Width / 2 > MinimunSize && Objects.Count > 0)
            {
                var rtl = new Rectangle(X, Y, Width / 2, Height / 2);
                var rtr = new Rectangle(X + Width / 2, Y, Width / 2, Height / 2);
                var rbl = new Rectangle(X, Y + Height / 2, Width / 2, Height / 2);
                var rbr = new Rectangle(X + Width / 2, Y + Height / 2, Width / 2, Height / 2);

                TL = new QuadNode(rtl, Objects, id + "1");
                TR = new QuadNode(rtr, Objects, id + "2");
                BL = new QuadNode(rbl, Objects, id + "3");
                BR = new QuadNode(rbr, Objects, id + "4");

                Objects.Clear();
            }



        }
    }
}
