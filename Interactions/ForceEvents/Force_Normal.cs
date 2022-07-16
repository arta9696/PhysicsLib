using PhysicsLib.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsLib.Interactions.ForceEvents
{
    public class Force_Normal : Force_Arbitrary
    {
        public MathVector Action(PsObject a, PsObject b, params object[] additional_values)
        {
            var cos = (b.Vector_variables["Position"] - a.Vector_variables["Position"]).NormalizedVersion() * b.Vector_variables["Velocity"].NormalizedVersion();
            MathVector speed_into_obj = b.Vector_variables["Velocity"]*cos;
            var delta = b.Double_variables["Margin_of_force"] - (b.Vector_variables["Position"] - a.Vector_variables["Position"]).Length();
            return -speed_into_obj * a.Double_variables["Mass"] * (delta*delta);
        }
    }
}
