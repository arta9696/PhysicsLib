using PhysicsLib.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsLib.Phenomena.Dinamics
{
    public class Forcable : Component   
    {
        int card;
        public Forcable(int System_Cardinality) : base(false)
        {
            card = System_Cardinality;
        }

        protected override void Action()
        {
            double value_mass;
            if (obj.Double_variables.TryGetValue("Mass", out value_mass))
            {
                double mass = value_mass;
                MathVector SumForce = MathVector.Zero(card);
                retry:;
                try
                {
                    foreach (var i in obj.Vector_variables.Keys)
                    {
                        if (i.StartsWith("Force_"))
                        {
                            SumForce += obj.Vector_variables[i];
                            obj.Vector_variables.Remove(i);
                        }
                    }
                }
                catch
                {
                    goto retry;
                }
                

                obj.Vector_variables["Acceleration_of_Forces"] = SumForce / mass;
            }

        }
    }
}
