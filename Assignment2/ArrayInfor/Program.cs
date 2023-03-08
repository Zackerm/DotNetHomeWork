using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInfor
{
    class ArrayInfor
    {
        public static int GetMax(int[] nums)
        {
            return nums.Max();
        }
        public static int GetMin(int[] nums)
        {
            return nums.Min();
        }
        public static int GetSum(int[] nums)
        {
            return nums.Sum();
        }
        public static double GetAverage(int[] nums,int sum)
        {
            return sum / nums.Length;
        }

        public static void Main(string[] args)
        {
            int[] nums = { 2, 3, 77, 5, 555, 33, 102, 4, 2, 65465, 999 };
            Console.WriteLine("最大值："+GetMax(nums));
            Console.WriteLine("最小值："+GetMin(nums));
            Console.WriteLine("数组和："+GetSum(nums));
            Console.WriteLine("平均值："+GetAverage(nums,GetSum(nums)));    
        }
    }
}