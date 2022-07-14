using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsLib.Phenomena.Kinematics
{
    public class Angular_Speed_Numeric : Component
    {
        double rotation_speed;
        double rotation_period;
        double rotation_frequency;
        public Angular_Speed_Numeric(double rotation_speed) : base(false)
        {
            this.rotation_speed = rotation_speed;
            rotation_period = 2 * Math.PI / rotation_speed;
            rotation_frequency = 1 / rotation_period;
        }
        protected override void SupportAddAction()
        {
            obj.Double_variables.Add(Component_name, rotation_speed);
            obj.Double_variables.Add("Rotation_Period", rotation_period);
            obj.Double_variables.Add("Rotation_Frequency", rotation_frequency);
        }

        protected override void SupportRemoveAction()
        {
            obj.Double_variables.Remove(Component_name);
            obj.Double_variables.Remove("Rotation_Period");
            obj.Double_variables.Remove("Rotation_Frequency");
        }

        protected override void Action()
        {
            double value_rot;
            double angle;
            if (obj.Double_variables.TryGetValue("Angle_Numeric", out angle) && obj.Double_variables.TryGetValue("Angular_Speed_Numeric", out value_rot))
            {
                rotation_speed = value_rot;
                angle += rotation_speed * (0.001 * obj.Milisec_delay);
                obj.Double_variables["Angle_Numeric"] = angle;

                rotation_period = 2 * Math.PI / rotation_speed;
                rotation_frequency = 1 / rotation_period;
                obj.Double_variables["Rotation_Period"] = rotation_period;
                obj.Double_variables["Rotation_Frequency"] = rotation_frequency;
            }
        }
    }
}
