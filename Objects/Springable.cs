using PhysicsLib.Interactions.ForceEvents;
using PhysicsLib.Phenomena.Dinamics;
using PhysicsLib.Phenomena.Kinematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsLib.Objects
{
    public class Springable : PsObject
    {
        public Springable(string object_name, int milisec_delay, Spring spring, MathVector direction, List<PsObject> objectPool) : base(object_name, milisec_delay, objectPool)
        {
            AddComponent(new Position(spring.Vector_variables["Position"] + direction.NormalizedVersion() * spring.Double_variables["Length"]));
            AddComponent(new Velocity(MathVector.Zero(direction.Cardinality())));
            AddComponent(new Acceleration(MathVector.Zero(direction.Cardinality())));
            AddComponent(new ForceAdder(new Force_Elasticity(), double.MaxValue, objectPool));
        }
    }
}
