using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsLib.Phenomena.Dinamics
{
    public class Energy_Potential : Component
    {
        double h;
        double g;
        public Energy_Potential(double sea_level, double g) : base(false)
        {
            this.h = sea_level;
            this.g = g;
        }
        protected override void Action()
        {
            if (obj.Double_variables.TryGetValue(Component_name, out _))
            {
                obj.Double_variables.Remove(Component_name);
            }
            obj.Double_variables.Add(Component_name, obj.Double_variables["Mass"] * g * h);
        }
    }
}
