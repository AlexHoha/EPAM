using System;
using System.Text;
namespace NET.W._2018.Hoha._02
{
    public class InsertNumberClass
    {
        public InsertNumberClass()
        {
        }

        public static int InsertNumber(int numberSource, int numberIn, int i, int j)
        {
            if (i > j)
            {
                throw new ArgumentException();
            }
            StringBuilder bin1 = new StringBuilder("00000000000000000000000000000000");
            StringBuilder bin2 = new StringBuilder("00000000000000000000000000000000");

            bin1.Insert(bin1.Length - Convert.ToString(numberSource, 2).Length,Convert.ToString(numberSource,2));//Переделать
            bin2.Insert(bin2.Length - Convert.ToString(numberIn, 2).Length, Convert.ToString(numberIn, 2));

            bin1.Remove(bin1.Length - Convert.ToString(numberSource, 2).Length, Convert.ToString(numberSource, 2).Length);
            bin2.Remove(bin2.Length - Convert.ToString(numberIn, 2).Length, Convert.ToString(numberIn, 2).Length);//Переделать

            int delta = j-i;
            bin1 = Reverse(bin1);
            bin2 = Reverse(bin2);

            for (int k = 0; k < delta; k++)
            {
                bin1[i] = bin2[k];
                i++;
            }

            bin1 = Reverse(bin1);
            return Convert.ToInt32(bin1.ToString(), 2);
        }

        public static StringBuilder Reverse(StringBuilder s)
        {
            char[] charArray = s.ToString().ToCharArray();
            Array.Reverse(charArray);
            return new StringBuilder(new String(charArray));
        }
    }
}
