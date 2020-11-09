using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorV4.Models.V2
{
    [Serializable]
    public class TilesheetConvertWorldView : IConvertWorldView
    {
        public Matrix GetWorldToViewMatrix()
        {
            return new Matrix();
        }
    }
}
