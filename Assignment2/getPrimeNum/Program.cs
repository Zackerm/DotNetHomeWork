using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace getPrimeNum
{
    class GetPrimeNum
    {
        static int MAX;
        public static int[] GetNum(int num)
        {
            int i = 2,j = 0;
            int[] array = new int[100];
            while (i <= num)
            {
                if (num % i == 0)
                {
                    array[j] = i; j++;
                    num = num / i;
                }
                else
                {
                    i++;
                }
            }
            MAX = j;
            return array;
        }
        static void Main(string[] args)
        {
            int num = Convert.ToInt32(Console.ReadLine());
            if (num < 2) { Console.WriteLine("请输入大于1的数"); }
            for(int k = 0; k <= MAX; k++)
            {
                Console.WriteLine(GetNum(num)[k]);
            }

        }
    }
}
