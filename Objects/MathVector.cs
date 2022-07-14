using System.Text;

namespace PhysicsLib.Objects
{
    public class MathVector
    {
        protected double[] vectorValues;

        public MathVector(params double[] values)
        {
            vectorValues = new double[values.Length];
            values.CopyTo(vectorValues, 0);
        }

        public double this[int index]
        {
            get
            {
                return vectorValues[index];
            }
            set
            {
                vectorValues[index] = value;
            }
        }
        public int Cardinality()
        {
            return vectorValues.Length;
        }
        public double Length()
        {
            double len = 0;
            foreach (var v in vectorValues)
            {
                len += v * v;
            }
            return Math.Sqrt(len);
        }
        public double LengthSquared()
        {
            double len = 0;
            foreach (var v in vectorValues)
            {
                len += v * v;
            }
            return len;
        }
        public static MathVector operator +(MathVector a, MathVector b)
        {
            if (a.Cardinality() != b.Cardinality())
            {
                throw new ArgumentException("Vectors must be of equal cardinality");
            }
            int n = a.Cardinality();
            double[] values = new double[n];
            for (int i = 0; i < n; i++)
            {
                values[i] = a[i] + b[i];
            }
            return new MathVector(values);
        }
        public static MathVector operator -(MathVector a, MathVector b)
        {
            if (a.Cardinality != b.Cardinality)
            {
                throw new ArgumentException("Vectors must be of equal cardinality");
            }
            int n = a.Cardinality();
            double[] values = new double[n];
            for (int i = 0; i < n; i++)
            {
                values[i] = a[i] - b[i];
            }
            return new MathVector(values);
        }
        public static MathVector operator -(MathVector a)
        {
            int n = a.Cardinality();
            double[] values = new double[n];
            for (int i = 0; i < n; i++)
            {
                values[i] = -a[i];
            }
            return new MathVector(values);
        }
        public static MathVector operator *(MathVector a, double b)
        {
            int n = a.Cardinality();
            double[] values = new double[n];
            for (int i = 0; i < n; i++)
            {
                values[i] = a[i] * b;
            }
            return new MathVector(values);
        }
        public static MathVector operator *(double a, MathVector b)
        {
            int n = b.Cardinality();
            double[] values = new double[n];
            for (int i = 0; i < n; i++)
            {
                values[i] = b[i] * a;
            }
            return new MathVector(values);
        }
        public static MathVector operator /(MathVector a, double b)
        {
            int n = a.Cardinality();
            double[] values = new double[n];
            for (int i = 0; i < n; i++)
            {
                values[i] = a[i] / b;
            }
            return new MathVector(values);
        }
        public static MathVector operator /(double a, MathVector b)
        {
            int n = b.Cardinality();
            double[] values = new double[n];
            for (int i = 0; i < n; i++)
            {
                values[i] = b[i] / a;
            }
            return new MathVector(values);
        }
        public static double ScalarMulti(MathVector a, MathVector b)
        {
            return a * b;
        }
        public double ScalarMulti(MathVector b)
        {
            return this * b;
        }
        public static double operator *(MathVector a, MathVector b)
        {
            if (a.Cardinality != b.Cardinality)
            {
                throw new ArgumentException("Vectors must be of equal cardinality");
            }
            int n = a.Cardinality();
            double value = 0;
            for (int i = 0; i < n; i++)
            {
                value += a[i] * b[i];
            }
            return value;
        }
        public static MathVector VectorMulti(params MathVector[] a)
        {
            if (a.Length - 1 != a[0].Length())
            {
                throw new ArgumentException("Vectors amount must be one less than length of a vector");
            }
            foreach (var v in a)
            {
                if (v.Cardinality != a[0].Cardinality)
                {
                    throw new ArgumentException("Vectors must be of equal cardinality");
                }
            }

            int n = a[0].Cardinality();
            MathVector[] b = (MathVector[])a.Reverse();
            double[] values = new double[n];
            for (int i = 0; i < n; i++)
            {
                double to_add = 1;
                double to_subtract = 1;
                for (int k = 0; k < n - 1; k++)
                {
                    int position = i + k + 1;
                    if (position == n)
                    {
                        position -= n;
                    }
                    to_add *= a[k][position];
                    to_subtract *= b[k][position];
                }

                values[i] = to_add - to_subtract;
            }
            return new MathVector(values);
        }
        public static double Angle(MathVector a, MathVector b)
        {
            return a ^ b;
        }
        public double Angle(MathVector b)
        {
            return this ^ b;
        }
        public static double operator ^(MathVector a, MathVector b)
        {
            if (a.Cardinality != b.Cardinality)
            {
                throw new ArgumentException("Vectors must be of equal cardinality");
            }

            return Math.Acos(a * b / (a.Length() * b.Length()));
        }
        public static MathVector NormalizedVersion(MathVector a)
        {
            return a / a.Length();
        }
        public MathVector NormalizedVersion()
        {
            return this / Length();
        }
        public static MathVector Zero(int cardinality)
        {
            double[] values = new double[cardinality];
            for (int i = 0; i < cardinality; i++)
            {
                values[i] = 0;
            }
            return new MathVector(values);
        }

        public override string? ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var v in vectorValues)
            {
                sb.Append(v.ToString() + ", ");
            }
            sb.Remove(sb.Length - 2, 2);
            return "{" + sb.ToString() + "}";
        }
    }
}
