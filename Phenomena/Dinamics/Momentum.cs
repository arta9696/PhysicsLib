using PhysicsLib.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsLib.Phenomena.Dinamics
{
    public class Momentum : Component
    {
        public Momentum() : base(false)
        {
        }

        protected override void Action()
        {
            var new_momentum = obj.Vector_variables["Velocity"] * obj.Double_variables["Mass"];
            var delta_momentum = MathVector.Zero(new_momentum.Cardinality());
            if (obj.Vector_variables.TryGetValue(Component_name, out var value))
            {
                delta_momentum = new_momentum - value;
                obj.Vector_variables.Remove(Component_name);
            }
            obj.Vector_variables.Add(Component_name, new_momentum);

            if (obj.Vector_variables.TryGetValue(Component_name+"Delta", out _))
            {
                obj.Vector_variables.Remove(Component_name + "Delta");
            }
            obj.Vector_variables.Add(Component_name + "Delta", delta_momentum);
        }
    }
}
