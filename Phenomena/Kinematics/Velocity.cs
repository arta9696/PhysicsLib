using PhysicsLib.Objects;

namespace PhysicsLib.Phenomena.Kinematics
{
    public class Velocity : Component
    {
        MathVector velocity;
        public Velocity(MathVector velocity) : base(false)
        {
            this.velocity = velocity;
        }

        protected override void SupportAddAction()
        {
            obj.Vector_variables.Add(Component_name, velocity);
        }

        protected override void SupportRemoveAction()
        {
            obj.Vector_variables.Remove(Component_name);
        }

        protected override void Action()
        {
            MathVector value_vel;
            MathVector posit;
            if (obj.Vector_variables.TryGetValue("Position", out posit) && obj.Vector_variables.TryGetValue("Velocity", out value_vel))
            {
                velocity = value_vel;
                posit += velocity * (0.001 * obj.Milisec_delay);
                obj.Vector_variables["Position"] = posit;
            }
        }
    }
}
