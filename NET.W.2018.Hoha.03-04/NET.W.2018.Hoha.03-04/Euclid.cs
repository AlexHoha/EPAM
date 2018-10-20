using System;
using System.Diagnostics;
namespace NET.W._2018.Hoha._03_04
{
    public class Euclid
    {
        static Stopwatch sw = new Stopwatch();
        public Euclid()
        {
        }

        static int FindGCD(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            if (a == 0 || b == 0)
                throw new ArgumentException();
            while(a != b)
            {
                if(a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }
            return a;
        }

        public static int FindGCD(int[] input, out TimeSpan ts)
        {
            sw.Start();
            int tempGCD = 0;
            for (int i = 0; i < input.Length - 1; i++)
            {
                tempGCD = FindGCD(input[i], input[i+1]);
            }
            sw.Stop();
            ts = sw.Elapsed;
            return tempGCD;
        } 
    }
}
