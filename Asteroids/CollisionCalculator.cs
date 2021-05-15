using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asteroids
{
    class CollisionCalculator
    {
        private List<GameObject> ObjectList { get; set; } = new List<GameObject>();
        private List<GameObject> TargetList { get; set; } = new List<GameObject>();

        public event EventHandler<CollisionEventArgs> Collision;
        public bool DeleteAfterCollision { get; set; }

        public CollisionCalculator(bool deleteAfterCollision)
        {
            DeleteAfterCollision = deleteAfterCollision;
        }

        public void AddObject(GameObject @object) => ObjectList.Add(@object);
        public void AddTarget(GameObject target) => TargetList.Add(target);

        public List<GameObject> CalculateCollision()
        {
            List<GameObject> collisionedObjectList = new List<GameObject>();
            List<GameObject> collisionedTargetList = new List<GameObject>();

            foreach(var @object in ObjectList)
            {
                bool intersected = false;
                foreach(var target in TargetList)
                {
                    if (@object.Rectangle.IntersectsWith(target.Rectangle))
                    {
                        intersected = true;
                        collisionedTargetList.Add(target);
                    }
                }

                if (intersected)
                    collisionedObjectList.Add(@object);
            }

            if (DeleteAfterCollision)
            {
                collisionedObjectList.ForEach(p => ObjectList.Remove(p));
                collisionedTargetList.ForEach(p => TargetList.Remove(p));
            }

            return collisionedObjectList.Union(collisionedTargetList).ToList();
        }

        private void CollisionNotification(GameObject @object, GameObject target)
        {
            var eventArgs = new CollisionEventArgs(@object, target);
            OnCollision(eventArgs);
        }

        private void OnCollision(CollisionEventArgs e) => Volatile.Read(ref Collision)?.Invoke(this, e);

    }
}
