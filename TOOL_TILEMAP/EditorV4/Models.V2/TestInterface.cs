using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorV4.Models.V2
{
    public interface TestInterface
    {
        float ViewportX { get; set; }
        float ViewportY { get; set; }
        float ViewportWidth { get; set; }
        float ViewportHeight { get; set; }

        float ViewportiX { get; set; }
        float ViewportiY { get; set; }
        float ViewportiWidth { get; set; }
        float ViewportiHeight { get; set; }

        float HValue { get; set; }
        float VValue { get; set; }
        float MaxHValue { get; set; }
        float MaxVValue { get; set; }

        int MouseX { get; set; }
        int MouseY { get; set; }

        float WorldMouseX { get; set; }
        float WorldMouseY { get; set; }
    }
}
