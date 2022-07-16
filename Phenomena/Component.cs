using PhysicsLib.Objects;
using System.Diagnostics;

namespace PhysicsLib.Phenomena
{
    public abstract class Component
    {
        private string component_name;
        protected PsObject? obj;
        private bool isInAction = false;
        private CancellationTokenSource ts = new CancellationTokenSource();
        private bool isOneTimer = false;
        private int delta=0;

        public string Component_name { get => component_name; }
        public bool IsOneTimer { get => isOneTimer; }

        protected Component(bool isOneTimer)
        {
            component_name = this.GetType().Name;
            this.isOneTimer = isOneTimer;
        }

        internal void Add(PsObject psObject)
        {
            obj = psObject;
            obj.onActivation += Obj_onActivation;
            obj.onDisactivation += Obj_onDisactivation;
            SupportAddAction();
        }

        private void Obj_onActivation(object? sender, EventArgs e)
        {
            if (isOneTimer)
            {
                Thread ot = new Thread(() => Action());
                ot.Start();
                return;
            }
            else
            {
                isInAction = true;

                Thread mt = new Thread(() => ThreadInsider());
                mt.Name = Component_name;
                mt.Start();
            }
        }
        internal void Remove()
        {
            obj.onActivation -= Obj_onActivation;
            obj.onDisactivation -= Obj_onDisactivation;
            obj = null;
            SupportRemoveAction();
        }

        private async void Obj_onDisactivation(object? sender, EventArgs e)
        {
            isInAction = false;

            ts.Cancel();
            ts = new CancellationTokenSource();
        }
        private void ThreadInsider()
        {
            CancellationToken ct = ts.Token;
            while (true)
            {
                if (ct.IsCancellationRequested)
                {
                    break;
                }

                Stopwatch sw = new Stopwatch();
                sw.Start();

                Action();
                if (ct.IsCancellationRequested)
                {
                    break;
                }
                sw.Stop();
                int sleep = Math.Max(0, obj.Milisec_delay - (int)sw.ElapsedMilliseconds);
                sw.Reset();

                sw.Start();
                while (sw.ElapsedTicks < 10000 * (sleep-delta)) { }
                sw.Stop();
                delta = (int)Math.Ceiling(((delta + Math.Max(0, (int)sw.ElapsedMilliseconds - sleep))/(double)2));
                Console.WriteLine(sleep + " - " + sw.ElapsedMilliseconds + "-" + component_name);
                sw.Reset();
            }
        }
        protected virtual void Action()
        {
        }
        protected virtual void SupportAddAction()
        {
        }
        protected virtual void SupportRemoveAction()
        {
        }
    }
}
