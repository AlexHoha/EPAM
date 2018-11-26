using System;
using System.Collections.Generic;
namespace Solutions
{
    public class Generator
    {
        public void Generate(int a, int b, int count)
        {
            int current = 2;
            int value;
            List<int> list = new List<int>(){a,b};
            while(current < count)
            {
                //value = Sequence1(list, current);
                value = Sequence2(list, current);
                list.Add(value);
                current++;
            }
            Print(list);
        }

        public void Generate<T>(T a, T b, int count)
        {
            int current = 2;
            dynamic value;
            List<dynamic> list = new List<dynamic> { a, b };
            while (current < count)
            {
                value = list[current - 2] + list[current - 1] / list[current - 2];
                list.Add(value);
                current++;
            }
            Print(list);
        }

        int Sequence1(List<int> list, int current)
        {
            return list[current - 2] + list[current-1];
        }

        int Sequence2(List<int> list, int current)
        {
            return 6 * list[current - 2] - 8 * list[current - 1];
        }

        void Print<T>(List<T> list)
        {
            foreach(T item in list)
            {
                Console.WriteLine(item.ToString());
            }
        }


    }
}
