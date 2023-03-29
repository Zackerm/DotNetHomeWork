using System;
using System.ComponentModel;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderSystem;
using System.Collections.Generic;

namespace OrderSystemTest
{
    [TestClass]
    public class OrderServiceTest
    {
        public OrderService orderservice;
        Order order1; Order order2; Order order3;Order order4;
        [TestInitialize]
        public void Init()
        {
            OrderService orderservice = new OrderService();
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
        }
        
        [TestMethod]

        public void addOrderTest()
        {
            orderservice.addOrder(order1);
            orderservice.addOrder(order2);
            orderservice.addOrder(order3);
            orderservice.addOrder(order4);
            Assert.AreEqual(4,orderservice.orderlist.Count);
        }
        [TestMethod]
        public void deleteOrderTest()
        {
            orderservice.deleteOrder(1);
            Assert.AreEqual(3,orderservice.orderlist.Count);
            orderservice.deleteOrder(2);
            Assert.AreEqual(2,orderservice.orderlist.Count);
        }
        [TestMethod]
        public void changeOrderTest()
        {
            Order test = new Order(2, "jerry");
            orderservice.changeOrder(test);
            Assert.AreEqual("jerry", orderservice.orderlist[1].Customer);
        }
        [TestMethod]
        public void searchOrderTest()
        {
            List<Order> test = orderservice.searchOrder("Mike","2");
            Assert.AreEqual(2,test.Count);
            List<Order> test2 = orderservice.searchOrder("2", "1");
            Assert.AreEqual("John", test2[0].Customer);
        }

    }
}
