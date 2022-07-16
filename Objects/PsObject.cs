using PhysicsLib.Phenomena;
using System.Text;

namespace PhysicsLib.Objects
{
    public class PsObject
    {
        private string object_name;
        private bool isActive = false;
        private List<Component> components = new List<Component>();
        private int milisec_delay = 0;
        private Dictionary<string, object> variables = new Dictionary<string, object>();
        private Dictionary<string, double> double_variables = new Dictionary<string, double>();
        private Dictionary<string, MathVector> vector_variables = new Dictionary<string, MathVector>();
        private List<PsObject> objectPool;

        public bool IsActive { get => isActive; }
        public string Object_name { get => object_name; }
        public int Milisec_delay { get => milisec_delay; }
        public Dictionary<string, object> Variables { get => variables; set => variables = value; }
        public Dictionary<string, double> Double_variables { get => double_variables; set => double_variables = value; }
        public Dictionary<string, MathVector> Vector_variables { get => vector_variables; set => vector_variables = value; }

        public PsObject(string object_name, int milisec_delay, List<PsObject> objectPool)
        {
            this.object_name = object_name;
            this.milisec_delay = milisec_delay;
            this.objectPool = objectPool;
            objectPool.Add(this);
        }

        public void AddComponent(Component component)
        {
            component.Add(this);
            components.Add(component);
        }
        public void RemoveComponent(Component component)
        {
            if (isActive)
            {
                throw new InvalidOperationException("Can't remove component from active object");
            }
            Component rem = components.Find(x => x.Component_name.Equals(component.Component_name));
            if (rem != null)
            {
                rem.Remove();
                components.Remove(rem);
            }
        }

        public void Activate()
        {
            isActive = true;
            onActivation(this, new EventArgs());
        }
        public void Disactivate()
        {
            isActive = false;
            onDisactivation(this, new EventArgs());
        }

        public override string? ToString()
        {
            try
            {
                string one = Object_name + (isActive ? " is active " : " is not active ") + "and have " + milisec_delay.ToString() + " milliseccond delay";
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < one.Length + 4; i++)
                {
                    builder.Append("-");
                }
                builder.AppendLine("\n||" + one + "||");
                string two = "||As additional variables it have:";
                builder.Append(two);
                for (int i = two.Length; i < one.Length + 2; i++)
                {
                    builder.Append(" ");
                }
                builder.Append("||\n");
                foreach (string i in variables.Keys)
                {
                    string vars = $"||-{i} - {variables.GetValueOrDefault(i).ToString()}";
                    builder.Append(vars);
                    for (int j = vars.Length; j < one.Length + 2; j++)
                    {
                        builder.Append(" ");
                    }
                    builder.Append("||\n");
                }
                foreach (string i in double_variables.Keys)
                {
                    string vars = $"||-{i} - {this.double_variables.GetValueOrDefault(i).ToString()}";
                    builder.Append(vars);
                    for (int j = vars.Length; j < one.Length + 2; j++)
                    {
                        builder.Append(" ");
                    }
                    builder.Append("||\n");
                }
                foreach (string i in vector_variables.Keys)
                {
                    string vars = $"||-{i} - {vector_variables.GetValueOrDefault(i).ToString()}";
                    builder.Append(vars);
                    for (int j = vars.Length; j < one.Length + 2; j++)
                    {
                        builder.Append(" ");
                    }
                    builder.Append("||\n");
                }
                string three = "||Components number is " + components.Count.ToString();
                builder.Append(three);
                for (int i = three.Length; i < one.Length + 2; i++)
                {
                    builder.Append(" ");
                }
                builder.Append("||\n");
                foreach (Component c in components)
                {
                    string vars = $"||-{c.Component_name} - {(c.IsOneTimer ? "onetimer" : "repeatable")}";
                    builder.Append(vars);
                    for (int j = vars.Length; j < one.Length + 2; j++)
                    {
                        builder.Append(" ");
                    }
                    builder.Append("||\n");
                }
                for (int i = 0; i < one.Length + 4; i++)
                {
                    builder.Append("-");
                }
                return builder.ToString();
            }
            catch
            {
                return null;
            }
        }

        public event EventHandler onActivation;
        public event EventHandler onDisactivation;

    }
}