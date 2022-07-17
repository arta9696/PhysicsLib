using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsLib.Phenomena
{
    internal class Stiffness_Coeff : Component
    {
        double stiffness;
        public Stiffness_Coeff(double stiffness) : base(true)
        {
            this.stiffness = stiffness;
        }

        protected override void SupportAddAction()
        {
            obj.Double_variables.Add(Component_name, stiffness);
        }

        protected override void SupportRemoveAction()
        {
            obj.Double_variables.Remove(Component_name);
        }
    }
}
