using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsharpHomework1._2
{
    public partial class Form1 : Form
    {
        double first = 0;
        double last = 0;
        double result = 0;
        bool c = false;
        string d = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (c == true)

            {

                textBox1.Text = "";

                c = false;

            }

            textBox1.Text += "7";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (c == true)

            {

                textBox1.Text = "";

                c = false;

            }

            textBox1.Text += "0";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (c == true)

            {

                textBox1.Text = "";

                c = false;

            }

            textBox1.Text += "8";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (c == true)

            {

                textBox1.Text = "";

                c = false;

            }

            textBox1.Text += "9";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (c == true)

            {

                textBox1.Text = "";

                c = false;

            }

            textBox1.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (c == true)

            {

                textBox1.Text = "";

                c = false;

            }

            textBox1.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (c == true)

            {

                textBox1.Text = "";

                c = false;

            }

            textBox1.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (c == true)

            {

                textBox1.Text = "";

                c = false;

            }

            textBox1.Text += "1";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (c == true)

            {

                textBox1.Text = "";

                c = false;

            }

            textBox1.Text += "2";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (c == true)

            {

                textBox1.Text = "";

                c = false;

            }

            textBox1.Text += "3";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (c == true)

            {

                textBox1.Text = "";

                c = false;

            }

            textBox1.Text += ".";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            switch (d)
            {
                case "+": result = first + double.Parse(textBox1.Text); break;
                case "-": result = first - double.Parse(textBox1.Text); break;
                case "*": result = first * double.Parse(textBox1.Text); break;
                case "/": result = first / double.Parse(textBox1.Text); break;
                case "x²":
                    if (first != 0) result = first * first;
                    else if (double.Parse(textBox1.Text) != 0) result = last * last;
                    break;
                case "√X":
                    if (first != 0) result = Math.Sqrt(first);
                    else if (double.Parse(textBox1.Text) != 0) result = Math.Sqrt(last);
                    break;
            }
            textBox1.Text = result + "";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            c = true;
            first = double.Parse(textBox1.Text);
            d = "/";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            c = true;
            first = double.Parse(textBox1.Text);
            d = "*";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
                textBox1.Text = "-";
            else
            {
                c = true;
                first = double.Parse(textBox1.Text);
                d = "-";
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            c = true;
            first = double.Parse(textBox1.Text);
            d = "+";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            first = 0;
            last = 0;
            result = 0;
            d = "";
            c = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
