using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Shape
{
    public abstract class Shape
    {
        public abstract int getArea();
        public abstract bool isLeagle();
    }
    public class Rectangle:Shape
    {
        protected int width, height;
        public void setWidth(int width)
        {
            this.width = width;
        }
        public void setHeight(int height)
        {
            this.height = height;
        }
        public override int getArea()
        {
            return this.width * this.height;
        }
        public override bool isLeagle()
        {
            if (this.width == this.height || width < 0 || height < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
    public class Square : Rectangle
    {
        public void setHeight()
        {
            this.height = this.width;
        }
        public new bool isLeagle()
        {
            if (this.width == this.height && width > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public class Triangle:Shape
    {
        int a, b, c;
        public void setLength(int a, int b, int c)
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
        public override bool isLeagle()
        {
            if (a + b > c && a - b < c)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int shapety;
            int height, width;
            int a, b, c;
            Console.WriteLine("请输入形状：1.矩形 2.正方形 3.三角形");
            shapety = Convert.ToInt32(Console.ReadLine());
            if(shapety == 1)
            {
                Rectangle p = new Rectangle();
                Console.WriteLine("请输入长和宽");
                height = Convert.ToInt32(Console.ReadLine());
                width = Convert.ToInt32(Console.ReadLine());
                p.setWidth(width);
                p.setHeight(height);
                if(!p.isLeagle())
                {
                    Console.WriteLine("非法的图形");
                    return;
                }
                Console.WriteLine("面积为：" + p.getArea());
            }
            else if(shapety == 2)
            {
                Square s = new Square();
                Console.WriteLine("请输入边长");
                width = Convert.ToInt32(Console.ReadLine());
                s.setWidth(width);
                s.setHeight();
                if(!s.isLeagle())
                {
                    Console.WriteLine("非法的图形");
                    return;
                }
                Console.WriteLine("面积为：" +s.getArea());
            }
            else if(shapety == 3)
            {
                Triangle t = new Triangle();
                Console.WriteLine("请输入三边：");
                a = Convert.ToInt32(Console.ReadLine());
                b = Convert.ToInt32(Console.ReadLine());
                c = Convert.ToInt32(Console.ReadLine());
                t.setLength(a, b, c);
                if(!t.isLeagle() )
                {
                    Console.WriteLine("非法的图形");
                    return;
                }
                Console.WriteLine("面积为：" + t.getArea());
            }
        }
    }
}
