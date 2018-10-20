using System;

namespace NET.W._2018.Hoha._03_04
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = { 16,32};
            TimeSpan ts = new TimeSpan();
            Console.WriteLine(Euclid.FindGCD(input,out ts));
            Console.WriteLine(ts);
        }
    }
}
