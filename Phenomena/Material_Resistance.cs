using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsLib.Phenomena
{
    public class Material_Resistance : Component
    {
        double mat_res;
        public Material_Resistance(double material_resistance) : base(true)
        {
            mat_res = material_resistance;
        }

        protected override void SupportAddAction()
        {
            obj.Double_variables.Add(Component_name, mat_res);
        }

        protected override void SupportRemoveAction()
        {
            obj.Double_variables.Remove(Component_name);
        }
    }
}
