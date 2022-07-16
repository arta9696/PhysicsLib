using PhysicsLib.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsLib.Interactions.ForceEvents
{
    public class Force_Gravity_Newton : Force_Everywhere
    {
        MathVector g;
        public Force_Gravity_Newton(MathVector acceleration)
        {
            this.g = acceleration;
        }

        public Force_Gravity_Newton(): this(/*9.8066*/10*new MathVector(0,1))
        {
        }

        public MathVector Action(PsObject a)
        {
            return a.Double_variables["Mass"] * g;
        }
    }
}
