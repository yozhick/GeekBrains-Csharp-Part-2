using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class BattleShip : ImagedGameObject
    {
        public BattleShip(Point position, Point direction, Size size) : base(position, direction, size)
        {

        }

        public override void Update()
        {
            
        }

        public void SetPosition(Point newPosition)
        {
            Position = newPosition;
        }
    }
}
