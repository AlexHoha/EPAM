using System;

namespace NET.W._2018.Hoha._01
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = new int[] { 0, 6, 4, 2, 7, 5, 3, 1, 9, 8 };
            MergeSort ms = new MergeSort();
            ms.sort(input, 0, input.Length - 1);
            //QuickSort(input, 0, input.Length - 1);
            PrintArray(input);
        }

        public static void QuickSort(int[] arr, int b, int e)
        {
            int l = b, r = e;
            int piv = arr[(l + r) / 2];
            while (l <= r)
            {
                while (arr[l] < piv)
                    l++;
                while (arr[r] > piv)
                    r--;
                if (l <= r)
                    Swap(ref arr[l++], ref arr[r--]);
            }
            if (b < r)
                QuickSort(arr, b, r);
            if (e > l)
                QuickSort(arr, l, e);
        }
        public static void Swap(ref int a, ref int b)
        {
            int c = a;
            a = b;
            b = c;

        }
        public static int[] GenerateArray(int size)
        {
            Random r = new Random();
            int[] ret = new int[size];
            for (int i = 0; i < ret.Length - 1; i++)
            {
                ret[i] = r.Next(20);
            }

            return ret;
        }
        public static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}
