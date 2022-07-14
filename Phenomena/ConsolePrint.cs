using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsLib.Phenomena
{
    public class ConsolePrint : Component
    {
        public ConsolePrint() : base(false)
        {
        }

        protected override void Action()
        {
            Console.WriteLine(obj.ToString());
        }
    }
}
