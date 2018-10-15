using System;
namespace NET.W._2018.Hoha._02
{
    public class FindNthRootClass
    {
        public FindNthRootClass()
        {
        }

        public static double FindNthRoot(double A, int N, double epsilon = 0.0001)
        {
            double x = A / N;
            while (Math.Abs(A - Math.Pow(x, N)) > epsilon)
            {
                x = (1.0d / N) * ((N - 1) * x + (A / (Math.Pow(x, N - 1))));
            }
            return x;
        }
    }
}

