using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderSystem;

namespace OrderWindowsForms
{
    public partial class Form1 : Form
    {
        public OrderService orderservice { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("订单号");
            comboBox1.Items.Add("客户姓名");
            orderservice = new OrderService();
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
            orderservice.addOrder(order1);
            orderservice.addOrder(order2);
            orderservice.addOrder(order3);
            orderservice.addOrder(order4);
            bindingSource1.DataSource = orderservice.orderlist;
            //orderservice.orderlist.ForEach(o=>bindingSource2.Add(o.orders));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = comboBox1.Text;
            string infor = textBox1.Text;
            try
            {
                if (str == "订单号")
                {
                    bindingSource1.DataSource = orderservice.searchOrderByID(infor);
                    bindingSource2.DataSource = orderservice.searchOrderByID(infor).orders;
                }
                else if (str == "客户姓名")
                {
                    bindingSource1.DataSource = orderservice.searchOrderByName(infor);
                    bindingSource2.DataSource = orderservice.searchOrderByName(infor).orders;
                }
            }
            catch
            {
                label1.Text = "查找失败";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            try
            {
                orderservice.deleteOrder(Convert.ToInt32(str));
                label1.Text = "删除成功";
            }
            catch
            {
                label1.Text = "删除失败";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {        
            Form2 form2 = new Form2(this); 
            form2.ShowDialog(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this); 
            form2.ShowDialog(); 
        }
    }
}