using PhysicsLib.Interactions.ForceEvents;
using PhysicsLib.Phenomena;
using PhysicsLib.Phenomena.Dinamics;
using PhysicsLib.Phenomena.Kinematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsLib.Objects
{
    public sealed class Wall : PsObject
    {
        MathVector first, second, parallel;
        PsObject[] wallObjects;
        List<PsObject> objectPool;
        double size;
        double friction_of_wall;
        public Wall(string object_name, int milisec_delay, double size, double friction_of_wall, List<PsObject> objectPool, MathVector firstPoint, MathVector secondPoint) : base(object_name, milisec_delay, objectPool)
        {
            first = firstPoint;
            second = secondPoint;
            Vector_variables.Add("firstPoint", firstPoint);
            Vector_variables.Add("secondPoint", secondPoint);
            parallel = second - first;
            this.objectPool = objectPool;
            this.size = size;
            this.friction_of_wall = friction_of_wall;
        }

        public new void Activate()
        {
            wallObjects = new PsObject[(int)parallel.Length()];
            for (int i = 0; i < parallel.Length(); i++)
            {
                wallObjects[i] = new PsObject(Object_name + i, Milisec_delay, objectPool);
                wallObjects[i].AddComponent(new Mass(double.PositiveInfinity));
                wallObjects[i].AddComponent(new Position(parallel.NormalizedVersion() * i));
                wallObjects[i].AddComponent(new ForceAdder(new Force_Normal(), size, objectPool));
                wallObjects[i].AddComponent(new Size_Round(size));
                wallObjects[i].AddComponent(new Friction_Coeff(friction_of_wall));
            }
            objectPool.AddRange(wallObjects);
        }
        public new void Disactivate()
        {
            objectPool.RemoveAll((x) => x.Object_name.StartsWith(Object_name));
        }
    }
}
