using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsLib.Phenomena
{
    internal class Size_Round : Component
    {
        double size;
        public Size_Round(double size) : base(true)
        {
            this.size = size;
        }

        protected override void SupportAddAction()
        {
            obj.Double_variables.Add("Size", size);
        }

        protected override void SupportRemoveAction()
        {
            obj.Double_variables.Remove("Size");
        }
    }
}
