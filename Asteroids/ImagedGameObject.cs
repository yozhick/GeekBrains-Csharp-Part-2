using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    internal abstract class ImagedGameObject : GameObject
    {
        public Image Image { private get; set; }

        public ImagedGameObject(Point position, Point direction, Size size) : base(position, direction, size)
        {

        }

        public override void Draw(Graphics graphics)
        {
            var rectangle = new Rectangle(Position, Size);
            if (Image != null)
                graphics.DrawImage(Image, rectangle);
            else
                graphics.DrawEllipse(Pens.Red, rectangle);
        }
    }
}
