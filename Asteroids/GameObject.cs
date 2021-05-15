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

        public Rectangle Rectangle { get => new Rectangle(Position, Size); }

        public GameObject(Point position, Point direction, Size size)
        {
            Position = position;
            Direction = direction;
            Size = size;
        }

        public virtual void Redirect(OutOfBoundsData outOfBoundsData)
        {
            if ((outOfBoundsData & OutOfBoundsData.X) == OutOfBoundsData.X)
                Direction = new Point(-Direction.X, Direction.Y);            

            if ((outOfBoundsData & OutOfBoundsData.Y) == OutOfBoundsData.Y)
                Direction = new Point(Direction.X, -Direction.Y);
        }

        public abstract void Draw(Graphics graphics);  
        public abstract void Update();
        public abstract void Destroy();

        public static OutOfBoundsData OutOfBounds(GameObject gameObject, Rectangle rectangle)
        {
            OutOfBoundsData outOfBoundsData = OutOfBoundsData.None;

            if (gameObject.Position.X < rectangle.Left || gameObject.Position.X > rectangle.Right)
                outOfBoundsData |= OutOfBoundsData.X;

            if (gameObject.Position.Y < rectangle.Top || gameObject.Position.Y > rectangle.Bottom)
                outOfBoundsData |= OutOfBoundsData.Y;

            return outOfBoundsData;
        }
    }
}
