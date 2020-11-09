using EditorV4.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorV4.Services
{
    [Serializable]
    public class CanvasScrollControlService
    {
        private ICanvasScrollControl @interface;

        public CanvasScrollControlService(ICanvasScrollControl @interface)
        {
            this.@interface = @interface;
        }
    }
}
