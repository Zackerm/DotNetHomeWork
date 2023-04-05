using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderSystem;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OrderWindowsForms
{
    public partial class Form3 : Form
    {
        string ID;
        Form2 form2;
        OrderService orderservice { get; set; }
        public Form3()
        {
            InitializeComponent();
        }
        public Form3(Form2 form2)
        {
            InitializeComponent();
            this.form2 = form2;
            ID = form2.textBox1.Text;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            OrderDetails details = new OrderDetails(textBox.Text, Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text));
            form2.form1.orderservice.searchOrderByID(ID).addDetails(details);
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OrderDetails details = new OrderDetails(textBox.Text, Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text));
            form2.form1.orderservice.searchOrderByID(ID).orders.Clear();
            form2.form1.orderservice.searchOrderByID(ID).addDetails(details);
            Close();
        }
    }
}
