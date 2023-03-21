using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace LambdaList
{

    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data;
        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }
    public class LinkList<T>
    {
        public int max = -1;
        public int min = 999;
        public int sum = 0;
        private Node<T> head { get; set; }
        private Node<T> tail;
        public LinkList()
        {
            head = tail = null;
        }
        public Node<T> Head
        {
            get => head;
        }
        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }
        public void forEachNode(Action<T> f, LinkList<T> a)
        {
            Node<T> temp = a.head;
            while (temp != null)
            {
                f(temp.Data);
                temp = temp.Next;
            }
        }
        public void getMax(int a)
        {
            if (max < a)
            {
                max = a;
            }
        }
        public void getMin(int a)
        {
            if(min > a)
            {
                min = a;
            }
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            LinkList<int> list = new LinkList<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }
            list.forEachNode(m => Console.WriteLine(m), list);
            Action<int> f2 = new Action<int>(list.getMax);
            list.forEachNode(f2,list);
            Console.WriteLine("最大值为：" + list.max);
            Action<int> f3 =new Action<int>(list.getMin);
            list.forEachNode(f3,list);
            Console.WriteLine("最小值为：" + list.min);
            list.forEachNode(m =>list.sum+=m,list);
            Console.WriteLine("和为：" + list.sum);
        }
    }
}  
