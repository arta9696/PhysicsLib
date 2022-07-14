using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsLib.Phenomena.Kinematics
{
    public class Angular_Acceleration_Numeric : Component
    {
        double angular_accel;
        public Angular_Acceleration_Numeric(double angular_accel) : base(false)
        {
            this.angular_accel = angular_accel;
        }

        protected override void Action()
        {
            double value_accel;
            double velocity;
            if (obj.Double_variables.TryGetValue("Angular_Acceleration_Numeric", out value_accel) && obj.Double_variables.TryGetValue("Angular_Speed_Numeric", out velocity))
            {
                angular_accel = value_accel;
                velocity += angular_accel * (0.001 * obj.Milisec_delay);
                obj.Double_variables["Angular_Speed_Numeric"] = velocity;
            }
        }

        protected override void SupportAddAction()
        {
            obj.Double_variables.Add(Component_name, angular_accel);
        }

        protected override void SupportRemoveAction()
        {
            obj.Double_variables.Remove(Component_name);
        }
    }
}
