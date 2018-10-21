using System;
namespace NET.W._2018.Hoha._05
{
    public class JaggedArrayUtils
    {
        int[][] jaggedArr;

        public JaggedArrayUtils(int[][]jaggedArr)
        {
            this.jaggedArr = jaggedArr;
        }

        public void SortBySumDesc()
        {
            for (int i = 0; i < jaggedArr.Length - 1; i++)
            {
                for (int j = 0; j < jaggedArr.Length - i -1; j++)
                {
                    if( SumOfArray(jaggedArr[j]) < SumOfArray(jaggedArr[j+1]) )
                    {
                        SwapRows(ref jaggedArr[j],ref jaggedArr[j + 1]);
                    }
                }
            }
        }

        public void SortBySumAsc()
        {
            SortBySumDesc();
            Array.Reverse(jaggedArr);
        }

        public void SortByMaxDesc()
        {
            for (int i = 0; i < jaggedArr.Length - 1; i++)
            {
                for (int j = 0; j < jaggedArr.Length - i - 1; j++)
                {
                    if (MaxElInArray(jaggedArr[j]) < MaxElInArray(jaggedArr[j + 1]))
                    {
                        SwapRows(ref jaggedArr[j], ref jaggedArr[j + 1]);
                    }
                }
            }
        }

        public void SortByMaxAsc()
        {
            SortByMaxDesc();
            Array.Reverse(jaggedArr);
        }

        public void SortByMinAsc()
        {
            for (int i = 0; i < jaggedArr.Length - 1; i++)
            {
                for (int j = 0; j < jaggedArr.Length - i - 1; j++)
                {
                    if (MinElInArray(jaggedArr[j]) > MinElInArray(jaggedArr[j + 1]))
                    {
                        SwapRows(ref jaggedArr[j], ref jaggedArr[j + 1]);
                    }
                }
            }
        }

        public void SortByMinDesc()
        {
            SortByMinAsc();
            Array.Reverse(jaggedArr);
        }

        public void Display()
        {
            for (int i = 0; i < jaggedArr.Length; i++)
            {
                for (int j = 0; j < jaggedArr[i].Length; j++)
                {
                    Console.Write(jaggedArr[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void SwapRows(ref int[] a, ref int[] b)
        {
            int[] buf = a;
            a = b;
            b = buf;
        }

        static int SumOfArray(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum;
        }

        static int MaxElInArray(int[] arr)
        {
            int max = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (max < arr[i])
                    max = arr[i];
            }
            return max;
        }

        static int MinElInArray(int[] arr)
        {
            int min = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if(min > arr[i])
                {
                    min = arr[i];
                }
            }
            return min;
        }
    }
}
