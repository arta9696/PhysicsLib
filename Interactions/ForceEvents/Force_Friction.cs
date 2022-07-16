using PhysicsLib.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsLib.Interactions.ForceEvents
{
    public class Force_Friction : Force_Arbitrary
    {
        public MathVector Action(PsObject a, PsObject b, params object[] additional_values)
        {
            var N = new Force_Normal().Action(a, b);
            return -a.Vector_variables["Velocity"].NormalizedVersion() * b.Double_variables["Friction_Coeff"] * N.Length();
        }
    }
}
