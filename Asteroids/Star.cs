using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class Star : ImagedGameObject
    {
        public Star(Point position, Point direction, Size size) : base(position, direction, size)
        {

        }


        public override void Update()
        {
            // Приходится создавать новый экземпляр структуры, т.к. не даёт присвоить значение свойству структуры (ошибка CS1612).
            // Может быть, есть способ лучше?

            Position = new Point(Position.X + Direction.X, Position.Y + Direction.Y);
        }

    }
}
