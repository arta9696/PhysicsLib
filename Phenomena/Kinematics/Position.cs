using PhysicsLib.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsLib.Phenomena.Kinematics
{
    public class Position : Component
    {
        MathVector position;
        public Position(MathVector position) : base(true)
        {
            this.position = position;
        }

        protected override void SupportAddAction()
        {
            obj.Vector_variables.Add(Component_name, position);
        }

        protected override void SupportRemoveAction()
        {
            obj.Vector_variables.Remove(Component_name);
        }
    }
}
