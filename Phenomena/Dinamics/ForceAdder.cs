using PhysicsLib.Interactions.ForceEvents;
using PhysicsLib.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsLib.Phenomena.Dinamics
{
    public class ForceAdder: Component
    {
        PsObject[] all_objects;
        double e = double.PositiveInfinity;
        Force_Arbitrary force;
        Force_Everywhere force_everywhere;
        public ForceAdder(Force_Arbitrary force, double margin_from_effect, params PsObject[] all_objects) : base(false)
        {
            this.all_objects = all_objects;
            e = margin_from_effect;
            this.force = force;
        }

        public ForceAdder(Force_Everywhere force) : base(false)
        {
            force_everywhere = force;
        }

        protected override void Action()
        {
            if (double.IsInfinity(e))
            {
                MathVector forced = force_everywhere.Action(obj);
                try
                {
                    obj.Vector_variables.Add(force_everywhere.GetType().Name, forced);
                }
                catch
                {
                    obj.Vector_variables.Remove(force_everywhere.GetType().Name);
                    obj.Vector_variables.Add(force_everywhere.GetType().Name, forced);
                }
            }
            else
            {
                MathVector pos = obj.Vector_variables["Position"];
                foreach (var anobj in all_objects)
                {
                    MathVector anpos = anobj.Vector_variables["Position"];
                    if (!obj.Equals(anobj) && obj.Variables[force.GetType().Name] == anobj.Variables[force.GetType().Name] && (pos - anpos).Length() <= e)
                    {
                        MathVector forced = force.Action(obj, anobj, e);
                        obj.Vector_variables.Add(force.GetType().Name, forced);
                        anobj.Vector_variables.Add(force.GetType().Name, forced);
                    }
                }
            }
        }

        protected override void SupportAddAction()
        {
            if (!double.IsInfinity(e))
            {
                obj.Variables.Add(force.GetType().Name, force);
            }
        }

        protected override void SupportRemoveAction()
        {
            if (!double.IsInfinity(e))
            {
                obj.Variables.Remove(force.GetType().Name);
            }
        }
    }
}
