using PhysicsLib.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsLib.Interactions.ForceEvents
{
    internal class Force_Normal : Force_Arbitrary
    {
        public MathVector Action(PsObject a, PsObject b, params object[] additional_values)
        {
            double t = ((a.Vector_variables["Position"] + a.Vector_variables["Velocity"]) - (b.Vector_variables["Position"] + b.Vector_variables["Velocity"])).Length() - (double)additional_values[0];
            return new MathVector(a.Vector_variables["Position"][0] - b.Vector_variables["Position"][0], a.Vector_variables["Position"][1] - b.Vector_variables["Position"][1]) * t * a.Double_variables["Material_Resistance"];
        }
    }
}
