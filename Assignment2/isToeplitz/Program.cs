using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isToeplitz
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] text = { { 1, 2, 3, 4 }, { 5, 1, 2, 3 }, { 9, 5, 1, 2 } };
            Console.WriteLine($"the result is:{IsToeplitz(text)}");
        }
        public static bool IsToeplitz(int[,] text)
        {
            for (int i = 1; i < text.GetLength(0); i++)
            {
                for (int j = 1; j < text.GetLength(1); j++)
                {
                    if (text[i, j] != text[i - 1, j - 1]) return false;
                }
            }
            return true;
        }
    }
}
