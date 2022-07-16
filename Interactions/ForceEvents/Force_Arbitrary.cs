using PhysicsLib.Objects;
using PhysicsLib.Phenomena.Dinamics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsLib.Interactions.ForceEvents
{
    public interface Force_Arbitrary
    {
        public abstract MathVector Action(PsObject a, PsObject b, params object[] additional_values);
    }
}
