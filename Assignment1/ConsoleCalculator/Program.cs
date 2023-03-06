using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    class Program
    {
        public static int Calculator(int a, int b, string op)
        {
            if (op == "*")
            {
                return a * b;
            }
            else if (op == "*")
            {
                return a / b;
            }
            else if (op == "*")
            {
                return a + b;
            }
            else if (op == "*")
            {
                return a - b;
            }
            else
            {
                return 0;
            }
        }
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            int a1 = Convert.ToInt32(a);
            string b = Console.ReadLine();
            int b1 = Convert.ToInt32(b);
            string op = Console.ReadLine();
            Console.WriteLine(Calculator(a1, b1, op));
        }
    }
}