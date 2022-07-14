using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsLib.Phenomena.Kinematics
{
    public class Angle_Numeric : Component
    {
        double angle;
        public Angle_Numeric(double angle) : base(true)
        {
            this.angle = angle;
        }
        protected override void SupportAddAction()
        {
            obj.Double_variables.Add(Component_name, angle);
        }

        protected override void SupportRemoveAction()
        {
            obj.Double_variables.Remove(Component_name);
        }
    }
}
