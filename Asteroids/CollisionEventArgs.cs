using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class CollisionEventArgs : EventArgs
    {
        private readonly GameObject @object;
        private readonly GameObject target;
        public GameObject Object => @object;
        public GameObject Target => target;

        public CollisionEventArgs(GameObject @object, GameObject target)
        {
            this.@object = @object;
            this.target = target;
        }


    }
}
