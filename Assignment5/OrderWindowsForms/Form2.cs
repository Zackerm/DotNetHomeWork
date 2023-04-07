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
    public partial class Form2 : Form
    {
        public Form1 form1;
        public Form2()
        {
            InitializeComponent();

        }
        public Form2(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
            bindingSource2.DataSource = form1.orderservice.orderlist;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {          
            Form3 form3= new Form3(this);
            form3.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bindingSource1.DataSource= form1.orderservice.searchOrderByID(textBox1.Text).orders;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(this);
            form3.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            form1.orderservice.searchOrderByID(textBox1.Text).orders.Clear();
        }
    }
}
