using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsLib.Objects
{
    public class Wall_easy : PsObject
    {
        MathVector first, second, parallel;
        private int delta = 0;
        private CancellationTokenSource ts = new CancellationTokenSource();
        List<PsObject> objectPool;
        public Wall_easy(string object_name, int milisec_delay, double size, List<PsObject> objectPool, MathVector firstPoint, MathVector secondPoint) : base(object_name, milisec_delay, objectPool)
        {
            first = firstPoint; second = secondPoint; this.objectPool = objectPool; Double_variables.Add("Size", size);
            Vector_variables.Add("firstPoint", firstPoint);
            Vector_variables.Add("secondPoint", secondPoint);
            parallel = second - first;
        }
        public new void Activate()
        {
            objectPool.Remove(this);
            Thread mt = new Thread(() => ThreadInsider());
            mt.Name = Object_name;
            mt.IsBackground = true;
            mt.Start();
        }
        public new void Disactivate()
        {
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

                check();

                if (ct.IsCancellationRequested)
                {
                    break;
                }
                sw.Stop();
                int sleep = Math.Max(0, Milisec_delay - (int)sw.ElapsedMilliseconds);
                sw.Reset();

                sw.Start();
                while (sw.ElapsedTicks < 10000 * (sleep - delta)) { }
                sw.Stop();
                delta = (int)Math.Ceiling(((delta + Math.Max(0, (int)sw.ElapsedMilliseconds - sleep)) / (double)2));
                sw.Reset();
            }
        }

        private void check()
        {
            foreach (var ob in objectPool)
            {
                var third = ob.Vector_variables["Position"];
                var forth = third + ob.Vector_variables["Velocity"];

                if ((first[0] - second[0]) * (third[1] - forth[1])- (first[1] - second[1]) * (third[0] - forth[0]) == 0)
                {
                    return;
                }

                double[][] matr = new double[2][];
                matr[0] = new double[]
                {
                    first[0], first[1]
                };
                matr[1] = new double[]
                {
                    second[0], second[1]
                };
                var fn = DET(matr, 2);

                matr[0] = new double[]
                {
                    first[0], 1
                };
                matr[1] = new double[]
                {
                    second[0], 1
                };
                var sn = DET(matr, 2);

                matr[0] = new double[]
                {
                    third[0], third[1]
                };
                matr[1] = new double[]
                {
                    forth[0], forth[1]
                };
                var tn = DET(matr, 2);

                matr[0] = new double[]
                {
                    third[0], 1
                };
                matr[1] = new double[]
                {
                    forth[0], 1
                };
                var f4n = DET(matr, 2);

                matr[0] = new double[]
                {
                    first[1], 1
                };
                matr[1] = new double[]
                {
                    second[1], 1
                };
                var f5n = DET(matr, 2);

                matr[0] = new double[]
                {
                    third[1], 1
                };
                matr[1] = new double[]
                {
                    forth[1], 1
                };
                var s6n = DET(matr, 2);

                matr[0] = new double[]
                {
                    fn, sn
                };
                matr[1] = new double[]
                {
                    tn, f4n
                };
                var det11 = DET(matr, 2);

                matr[0] = new double[]
                {
                    sn, f5n
                };
                matr[1] = new double[]
                {
                    f4n, s6n
                };
                var det12 = DET(matr, 2);

                matr[0] = new double[]
                {
                    fn, f5n
                };
                matr[1] = new double[]
                {
                    tn, s6n
                };
                var det21 = DET(matr, 2);
                MathVector inters_point = new MathVector(det11/det12, det21/det12);
                if ((inters_point - third).NormalizedVersion()*forth.NormalizedVersion()>0 && forth.Length()>(inters_point-third).Length())
                {
                    ob.Vector_variables["Velocity"] = ob.Vector_variables["Velocity"]+2*(-ob.Vector_variables["Velocity"]*Math.Sin(ob.Vector_variables["Velocity"].NormalizedVersion()^parallel.NormalizedVersion()));
                }
            }
        }
        private static double DET(double[][] input, int n)
        {
            double det = 0;
            if (n == 1)
            {
                return input[0][0];
            }
            
            for (int i = 0; i < n; i++)
            {
                double[][] next_input = new double[n-1][];
                for(int k = 0; k < n-1; k++)
                {
                    next_input[k] = new double[n-1];
                    int j = 0;
                    for (int l = 0; l < n; l++)
                    {
                        if (l!=i)
                        {
                            next_input[k][j] = input[k + 1][l];
                            j++;
                        }
                    }
                }
                det += input[0][i] * (i%2==0?1:-1) * DET(next_input, n - 1);
            }
            return det;
        }
    }
}
