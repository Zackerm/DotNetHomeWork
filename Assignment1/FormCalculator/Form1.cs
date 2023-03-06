using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormCalculator
{
    public partial class Form1 : Form
    {
        string op ="";
        double a, b;
        public static string Calculator(double a, double b, string op)
        {
            if (op == "*")
            {
                return Convert.ToString(a * b);
            }
            else if (op == "/")
            {
                return Convert.ToString(a / b);
            }
            else if (op == "+")
            {
                return Convert.ToString(a + b);
            }
            else if (op == "-")
            {
                return Convert.ToString(a - b);
            }
            else
            {
                return null;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text=Calculator(a, b,op);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                op = "+";
            }
            else if (radioButton2.Checked)
            {
                op = "-";
            }
            else if (radioButton3.Checked)
            {
                op = "*";
            }
            else if (radioButton4.Checked)
            {
                op = "/";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            a= Convert.ToDouble(textBox1.Text);
        }
     
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            b= Convert.ToDouble(textBox2.Text);
        }
    }
}
