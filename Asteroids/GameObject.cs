using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    abstract class GameObject
    {
        public Point Position { get; protected set; }
        public Point Direction { get; set; }
        protected Size Size { get; set; }

        public GameObject(Point position, Point direction, Size size)
        {
            Position = position;
            Direction = direction;
            Size = size;
        }

        public abstract void Draw(Graphics graphics);  
        public abstract void Update();
    }
}
