using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;

namespace OrderSystem
{
    public class Order
    {
        public int Id { get; set; }//订单号
        public string Customer { get; set; }
        public List<OrderDetails> orders { get; set; } //储存订单的信息
        int Amount=> orders.Sum(order=>order.Amount);
        public Order(int id, string Customer)
        {
            this.Id = id; 
            this.Customer = Customer;
            orders = new List<OrderDetails> ();
        }
        public void addDetails(OrderDetails details)
        {
            orders.Add(details);
        }
        public override bool Equals(object obj)
        {
            Order m = obj as Order;
            return m.orders == orders && m.Id == Id && m.Customer == Customer;
        }
        public override int GetHashCode()
        {
            return Id;
        }
        public override string ToString()
        {
            return " 订单id为 " + Id + " 客户姓名为 " + Customer + " 订单总金额为 " + Amount;
        }
    }
    public class OrderDetails
    {
        public string Name { get; set; }//商品名称
        public int Price { get; set; }//订单金额
        public int Number { get; set; }//商品数量
        public int Amount =>Price*Number;
        public OrderDetails(string name, int price, int number)
        {
            this.Name = name;
            this.Price = price;
            this.Number = number;
        }

        public override bool Equals(object obj)
        {
            OrderDetails m= obj as OrderDetails;
            return m.Name == Name  && m.Number == Number && m.Price == Price;
        }
        public override int GetHashCode()
        {
            return 0;
        }
        public override string ToString()
        {
            return "商品名称为" + Name + "商品单价为" + Price+"购买件数为"+Number+"总价为"+Amount;
        }
    }
    public class OrderServise
    {
        public List<Order> orderlist = new List<Order>();
        public void addOrder(Order order)
        {
            if(orderlist.Contains(order))
            {
                throw new InvalidOperationException("已存在该订单");
            }
            orderlist.Add(order);
        }
        public void deleteOrder(int id)
        {
            Order temporder = orderlist.SingleOrDefault(temp => temp.Id == id);//找到id相同的订单
            if (!orderlist.Contains(temporder))
            {
                throw new InvalidOperationException("不存在此订单或已被删除");
            }
            orderlist.Remove(temporder);
        }
        public void changeOrder(Order neworder)
        {
            Order temporder= orderlist.SingleOrDefault(temp => temp.Id == neworder.Id);
            if(temporder == null)
            {
                throw new InvalidOperationException("不存在此订单");  
            }
            orderlist[orderlist.IndexOf(temporder)] = neworder;
        }
        public List<Order> searchOrder(string infor,string method)
        {
            if (method == "1")//按id查询
            {
                return orderlist.FindAll(order => order.Id == Convert.ToInt64(infor));
            }
            else if(method == "2")//按客户姓名查询
            {
                return orderlist.FindAll(order => order.Customer == infor);
            }
            else
            {
                throw new InvalidOperationException("错误的查询");
            }
        }
        public void sortOrder()
        {
            orderlist.Sort();
        }

    }
        
    class Program
    {
        static void Main(string[] args)
        {
            OrderServise orderservice = new OrderServise();
            //初始化订单
            Order order1 = new Order(00001, "Mike");
            Order order2 = new Order(00002, "John");
            Order order3 = new Order(00003, "Danny");
            Order order4 = new Order(00004, "Chris");
            order1.addDetails(new OrderDetails("Pen", 3, 9));
            order1.addDetails(new OrderDetails("Paper", 10, 1));
            order2.addDetails(new OrderDetails("Clothes", 200, 1));
            order3.addDetails(new OrderDetails("shoes", 300, 1));
            order4.addDetails(new OrderDetails("books", 80, 5));
            Console.WriteLine(order1.ToString());//输出订单1的数据
            orderservice.addOrder(order1);
            //orderservice.addOrder(order1);//返回错误信息
            orderservice.addOrder(order2);
            orderservice.addOrder(order3);
            orderservice.addOrder(order4);
            orderservice.deleteOrder(00003);
            //orderservice.deleteOrder(00006);//返回错误信息
            Console.WriteLine("选择查询方式：1.订单id  2.客户姓名");
            string method = Console.ReadLine();
            Console.WriteLine("输入查询信息");
            string infor = Console.ReadLine();
            List<Order> result = orderservice.searchOrder(infor, method);
            result.ForEach(t => Console.WriteLine(t.ToString()));//输出查询结果的信息
            order1.orders.ForEach(t => Console.WriteLine(t.ToString()));


        }
    }
}
