namespace PhysicsLib.Phenomena.Dinamics
{
    public class Mass : Component
    {
        double mass;
        public Mass(double mass) : base(true)
        {
            this.mass = mass;
        }
        protected override void SupportAddAction()
        {
            obj.Double_variables.Add(Component_name, mass);
        }

        protected override void SupportRemoveAction()
        {
            obj.Double_variables.Remove(Component_name);
        }
    }
}
