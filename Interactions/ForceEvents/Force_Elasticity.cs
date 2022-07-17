using PhysicsLib.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsLib.Interactions.ForceEvents
{
    internal class Force_Elasticity : Force_Arbitrary
    {
        public MathVector Action(PsObject a, PsObject b, params object[] additional_values)
        {
            if (b.GetType() == typeof(Spring))
            {
                Spring spring = (Spring)b;
                MathVector vector = (a.Vector_variables["Position"] - b.Vector_variables["Position"]);
                return -(b.Double_variables["Stiffness_Coeff"] * (b.Double_variables["Length"] - vector.Length()) * vector.NormalizedVersion());
            }
            else
            {
                return null;
            }
        }
    }
}
