using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    public static class OutOfBounds
    {
        public static OutOfBoundsData Calculate(Rectangle objectRectangle, Rectangle fieldRectangle)
        {
            OutOfBoundsData outOfBoundsData = OutOfBoundsData.None;

            if (objectRectangle.Left < fieldRectangle.Left || objectRectangle.Right > fieldRectangle.Right)
                outOfBoundsData |= OutOfBoundsData.X;

            if (objectRectangle.Top < fieldRectangle.Top || objectRectangle.Bottom > fieldRectangle.Bottom)
                outOfBoundsData |= OutOfBoundsData.Y;
            
            return outOfBoundsData;
        }
    }
}
