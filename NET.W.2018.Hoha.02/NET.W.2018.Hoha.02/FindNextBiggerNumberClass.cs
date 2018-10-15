using System;
using System.Text;
using System.Diagnostics;
using System.Globalization;
namespace NET.W._2018.Hoha._02
{
    public class FindNextBiggerNumberClass
    {
        public static Stopwatch sw = new Stopwatch();
        public static CultureInfo ci = new CultureInfo("ru-RU");
        public FindNextBiggerNumberClass()
        {
        }

        public struct Info
        {
            int number;
            TimeSpan ts;

            public Info(int number, TimeSpan ts)
            {
                this.number = number;
                this.ts = ts;
            }

            public override string ToString()
            {
                return $"Number: {number}, time elapsed: {ts}";
            }
        }

        public static int FindNextBiggerNumber(int num)
        {
            StringBuilder temp = new StringBuilder(num.ToString());
            for (int i = temp.Length - 1; i > 1; i--)
            {
                if (temp[i] > temp[i - 1])//Меняем младший разряд со старшим, если цифра в младшем больше
                {
                    char buf = temp[i - 1];
                    temp[i - 1] = temp[i];
                    temp[i] = buf;

                    char[] tail = new char[temp.Length - i];//Создаем массив, который надо отсортировать
                    for (int j = 0; j < tail.Length; j++)
                    {
                        tail[j] = temp[i + j];
                    }
                    temp.Remove(i, temp.Length - i);//Удаляем часть массива для сортировки
                    Array.Sort(tail);
                    temp.Append(tail);//Соединяем 2 массива
                    return int.Parse(temp.ToString());
                }
            }
            return -1;
        }

        public static Info FindNextBiggerNumber(int num, bool returnTime)
        {
            sw.Start();
            int number = FindNextBiggerNumber(num);
            sw.Stop();
            return new Info(number, sw.Elapsed);
        }
    }
}
