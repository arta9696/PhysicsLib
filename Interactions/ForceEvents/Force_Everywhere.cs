using PhysicsLib.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsLib.Interactions.ForceEvents
{
    public interface Force_Everywhere
    {
        public abstract MathVector Action(PsObject a);
    }
}
