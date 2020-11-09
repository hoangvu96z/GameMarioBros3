using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorV4.Services
{
    public interface IControlScrollInterface
    {
        void OnControlScroll(MouseEventArgs e);
    }
    [Serializable]
    public class ControlScrollService
    {
        IControlScrollInterface @interface;

        public ControlScrollService(IControlScrollInterface @interface)
        {
            this.@interface = @interface;
        }

        bool _isControlDown;
        public void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                _isControlDown = true;
            }
        }
        public void OnKeyUp(KeyEventArgs e)
        {
            _isControlDown = false;
            IsControlMouseWheel = false;
        }

        public bool IsControlDown
        {
            get { return _isControlDown; }
        }

        public bool IsControlMouseWheel { get; set; }

        public void OnMouseWheel(MouseEventArgs e)
        {
            if(e.Delta!=0 && _isControlDown)
            {
                IsControlMouseWheel = true;
                if(@interface!=null)
                {
                    @interface.OnControlScroll(e);
                }
            }
        }

    }
}
