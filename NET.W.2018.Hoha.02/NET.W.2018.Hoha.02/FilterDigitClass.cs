using System;
using System.Collections.Generic;
namespace NET.W._2018.Hoha._02
{
    public class FilterDigitClass
    {
        public FilterDigitClass()
        {
        }

        public static List<int> FilterDigit(List<int> input, int key)
        {
            List<int> output = new List<int>();
            foreach(int i in input)
            {
                if (i.ToString().Contains(key.ToString()))
                {
                    output.Add(i);
                }
            }

            return output;
        }
    }
}
