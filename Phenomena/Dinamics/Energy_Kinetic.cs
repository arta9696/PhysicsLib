using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsLib.Phenomena.Dinamics
{
    public class Energy_Kinetic : Component
    {
        public Energy_Kinetic() : base(false)
        {
        }

        protected override void Action()
        {
            if (obj.Double_variables.TryGetValue(Component_name, out _))
            {
                obj.Double_variables.Remove(Component_name);
            }
            obj.Double_variables.Add(Component_name, obj.Double_variables["Mass"] * obj.Vector_variables["Velocity"].LengthSquared()/2);
        }
    }
}
