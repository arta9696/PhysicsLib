using PhysicsLib.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsLib.Phenomena.Kinematics
{
    public class Acceleration : Component
    {
        MathVector acceleration;
        public Acceleration(MathVector acceleration) : base(false)
        {
            this.acceleration = acceleration;
        }

        protected override void Action()
        {
            MathVector? value_accel;
            MathVector velocity;
            if (obj.Vector_variables.TryGetValue("Acceleration", out value_accel) && obj.Vector_variables.TryGetValue("Velocity", out velocity))
            {
                acceleration = value_accel;
                velocity += acceleration * (0.001 * obj.Milisec_delay);
                obj.Vector_variables["Velocity"] = velocity;
            }
        }

        protected override void SupportAddAction()
        {
            obj.Vector_variables.Add(Component_name, acceleration);
        }

        protected override void SupportRemoveAction()
        {
            obj.Vector_variables.Remove(Component_name);
        }
    }
}
