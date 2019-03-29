using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_InzOpr
{
    class Slider2 : Slider
    {
        protected override void DrawBar(Graphics graphics)
        {
            SolidBrush b = new SolidBrush(Color.Aqua);
            
                graphics.FillRectangle(b, 0, Height / 3, Width, Height / 3);

        }
    }
}
