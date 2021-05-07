using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class Bullet : ImagedGameObject
    {
        public Bullet(Point position, Point direction, Size size) : base(position, direction, size)
        {

        }
        public override void Update()
        {
            Position = new Point(Position.X + Direction.X, Position.Y + Direction.Y);
        }
    }
}
