using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsLib.Phenomena
{
    public class Friction_Coeff : Component
    {
        double frict_coeff;
        public Friction_Coeff(double frict_coeff) : base(true)
        {
            this.frict_coeff = frict_coeff;
        }

        protected override void SupportAddAction()
        {
            obj.Double_variables.Add(Component_name, frict_coeff);
        }

        protected override void SupportRemoveAction()
        {
            obj.Double_variables.Remove(Component_name);
        }
    }
}
