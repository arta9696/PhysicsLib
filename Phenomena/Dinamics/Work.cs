using PhysicsLib.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsLib.Phenomena.Dinamics
{
    public class Work : Component
    {
        MathVector startPosition;
        public Work() : base(false)
        {
            startPosition = obj.Vector_variables["Position"];
        }

        protected override void Action()
        {
            double work = obj.Vector_variables["MomentumDelta"].Length() / obj.Milisec_delay * (obj.Vector_variables["Position"] - startPosition).Length();
            startPosition = obj.Vector_variables["Position"];
            if (obj.Double_variables.TryGetValue(Component_name, out var value))
            {
                obj.Double_variables[Component_name] += work;
            }
            else
            {
                obj.Double_variables.Add(Component_name, work);
            }
        }
    }
}
