using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids
{
    interface IGameView
    {
        int Width { get; }
        int Height { get; }
        BufferedGraphics BufferedGraphics { get; }

        event KeyEventHandler KeyDown;
        
    }
}
