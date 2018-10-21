using System;
namespace NET.W._2018.Hoha._05
{
    public sealed class Polynomial
    {
        int degree;
        int[] coefs;
        double x;

        public double X { get { return x; } set { x = value; } }

        public int Degree { get { return degree; } set { degree = value; } }

        public int[] Coefs { get { return coefs; } set { coefs = value; } }


        public Polynomial()//коэффиценты вводить от меньшей степени к больше i.e. 5 - 8x + 3x^2
        {
            Console.Write("Input polynomial degree: ");
            Degree = int.Parse(Console.ReadLine()) + 1;// +1 для свободного члена
            Console.Write("Input X: ");
            X = double.Parse(Console.ReadLine());
            coefs = new int[Degree];
            for (int i = 0; i < coefs.Length; i++)
            {
                Console.Write($"C[{i}]: ");
                coefs[i] = Convert.ToInt32(Console.ReadLine());
            }
        }

        public Polynomial(double x, int degree, int[] coefs)
        {
            this.X = x;
            this.Degree = degree + 1;// +1 для свободного члена
            this.Coefs = coefs;
        }

        public Polynomial(int[] coefs)
        {
            this.Coefs = coefs;
            this.Degree = coefs.Length;
        }

        static Polynomial Addition(Polynomial a, Polynomial b)
        {
            int tempDegree = 0;
            double tempX = a.X + b.X;
            int[] tempCoefs = new int[a.Degree > b.Degree ? a.Degree : b.Degree];
            if (a.Degree > b.Degree)
            {
                tempDegree = a.Degree - 1;
                for (int i = 0; i < b.Degree; ++i)
                {
                    tempCoefs[i] = a.Coefs[i] + b.Coefs[i];
                }

                for (int i = b.Degree; i < a.Degree; ++i)
                {
                    tempCoefs[i] = a.Coefs[i];
                }
            }
            else if (a.Degree < b.Degree)
            {
                tempDegree = b.Degree - 1;
                for (int i = 0; i < a.Degree; ++i)
                {
                    tempCoefs[i] = a.Coefs[i] + b.Coefs[i];
                }

                for (int i = a.Degree; i < b.Degree; ++i)
                {
                    tempCoefs[i] = b.Coefs[i];
                }
            }
            else if (a.Degree == b.Degree)
            {
                tempDegree = a.Degree - 1;
                for (int i = 0; i < a.Degree; ++i)
                {
                    tempCoefs[i] = a.Coefs[i] + b.Coefs[i];
                }
            }

            return new Polynomial(tempX, tempDegree, tempCoefs);
        }

        static Polynomial Substraction(Polynomial a, Polynomial b)
        {
            int tempDegree = 0;
            double tempX = a.X - b.X;
            int[] tempCoefs = new int[a.Degree > b.Degree ? a.Degree : b.Degree];

            if (a.Degree > b.Degree)
            {
                tempDegree = a.Degree - 1;
                for (int i = 0; i < b.Degree; ++i)
                {
                    tempCoefs[i] = a.Coefs[i] - b.Coefs[i];
                }

                for (int i = b.Degree; i < a.Degree; ++i)
                {
                    tempCoefs[i] = a.Coefs[i];
                }
            }
            else if (a.Degree < b.Degree)
            {
                tempDegree = b.Degree - 1;
                for (int i = 0; i < a.Degree; ++i)
                {
                    tempCoefs[i] = a.Coefs[i] - b.Coefs[i];
                }

                for (int i = a.Degree; i < b.Degree; ++i)
                {
                    tempCoefs[i] = -b.Coefs[i];
                }
            }
            else if (a.Degree == b.Degree)
            {
                tempDegree = a.Degree - 1;
                for (int i = 0; i < a.Degree; ++i)
                {
                    tempCoefs[i] = a.Coefs[i] - b.Coefs[i];
                }
            }

            return new Polynomial(tempX, tempDegree, tempCoefs);
        }

        static Polynomial Multiply(Polynomial a, Polynomial b)
        {
            int[] tempCoefs = new int[a.Coefs.Length + b.Coefs.Length - 1];
            for (int i = 0; i < a.Coefs.Length; ++i)
            {
                for (int j = 0; j < b.Coefs.Length; ++j)
                {
                    tempCoefs[i + j] += a.Coefs[i] * b.Coefs[j];
                }
            }
            return new Polynomial(tempCoefs);
        }

        public static Polynomial operator +(Polynomial a, Polynomial b)
        {
            return Addition(a, b);
        }

        public static Polynomial operator -(Polynomial a, Polynomial b)
        {
            return Substraction(a, b);
        }

        public static Polynomial operator *(Polynomial a, Polynomial b)
        {
            return Multiply(a, b);
        }

        public static bool operator ==(Polynomial a, Polynomial b)
        {
            return a.Degree == b.Degree && a.X == b.X && AreEqual(a.Coefs, b.Coefs) ? true : false;
        }

        public static bool operator !=(Polynomial a, Polynomial b)
        {
            return a == b ? false : true;
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < Coefs.Length; i++)
            {
                s += $"{Coefs[i]}x^{i}+";
            }
            return s.Remove(s.Length - 1);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType() || obj == null)
                return false;

            Polynomial polynomial = (Polynomial)obj;
            return (this.X == polynomial.X) && (this.Degree == polynomial.Degree) && (AreEqual(this.Coefs, polynomial.Coefs)) ? true : false;
        }

        static bool AreEqual(int[]q, int[]b)
        {
            if(q.Length == b.Length)
            {
                for (int i = 0; i < q.Length; i++)
                {
                    if (q[i] != b[i])
                        return false;
                }
            }
            return true;
        }//Идентичны ли 2 массива
    }
}