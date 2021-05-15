using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class BattleField
    {
        public List<GameObject> AllGameObjects { get; set; } = new List<GameObject>();
        public Rectangle Rectangle { get;  }

        public BattleField(Rectangle rectangle)
        {
            Rectangle = rectangle;
        }
    }
}
