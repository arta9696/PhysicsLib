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
    public class Spring : PsObject
    {
        public Spring(string object_name, int milisec_delay, double stiffnes, double length, MathVector position, List<PsObject> objectPool) : base(object_name, milisec_delay, objectPool)
        {
            AddComponent(new Position(position));
            AddComponent(new Stiffness_Coeff(stiffnes));
            Double_variables.Add("Length", length);
            AddComponent(new ForceAdder(new Force_Elasticity(), double.Epsilon, objectPool));
        }
    }
}
