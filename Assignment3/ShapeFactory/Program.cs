using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeFactory
{
    public abstract class Shape
    {
        public abstract int getArea();
    }
    public class Rectangle : Shape
    {
        protected int width, height;
        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
        public override int getArea()
        {
            return this.width * this.height;
        }
    }
    public class Square : Shape
    {
        private int width, height;
        public Square(int width)
        {
            this.width = width;
            this.height = this.width;
        }
       
        public override int getArea()
        {
            return this.width * this.height;
        }
    }
    public class Triangle : Shape
    {
        int a, b, c;
        public Triangle(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public override int getArea()
        {
            int p = (a + b + c) / 2;
            return Convert.ToInt32(Math.Sqrt(p * (p - a) * (p - b) * (p - c)));
        }
    }
    public static class ShapeFactory
    {
        public static Shape CreateShape(int type)
        {
            Random r = new Random();
            switch (type)
            {
                case 1:
                    return new Square(r.Next(1, 10));
                case 2:
                    return new Rectangle(r.Next(1, 10), r.Next(1, 10));
                case 3:
                    return new Triangle(r.Next(3, 5), r.Next(3, 5), r.Next(3, 5));
                default:
                    throw new ArgumentException("错误的类型");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            double totalArea = 0;
            for (int i = 0; i < 10; i++)
            {
                totalArea += ShapeFactory.CreateShape(new int[] { 1, 2, 3 }[new Random().Next(3)]).getArea();
            }
            Console.WriteLine("总面积为: " + totalArea);
        }
    }
}
