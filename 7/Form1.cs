using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsharpHomework7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            pencolor = "Red";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            pencolor = "Black";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            pencolor = "Blue";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            pencolor = "Yellow";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.CreateGraphics();
            drawCayleyTree(10, this.Size.Width / 2, this.Size.Height, 100, -Math.PI / 2);
        }

        private Graphics graphics;
        int n = 10;
        double leng = 200;
        double th1 = 30 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;
        string pencolor = "Black";

        void drawCayleyTree(int n,
                double x0, double y0, double leng, double th)
        {
            if (n == 0) return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            drawLine(x0, y0, x1, y1);

            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
        }

        void drawLine(double x0, double y0, double x1, double y1)
        {
            switch (pencolor)
            {
                case "Red":
                    graphics.DrawLine(
                    Pens.Red,
                    (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                case "Black":
                    graphics.DrawLine(
                    Pens.Black,
                    (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                case "Blue":
                    graphics.DrawLine(
                    Pens.Blue,
                    (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                case "Yellow":
                    graphics.DrawLine(
                    Pens.Yellow,
                    (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                default:
                    graphics.DrawLine(
                    Pens.Brown,
                    (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
            }
        }

        private void getn_TextChanged(object sender, EventArgs e)  {
            try
            {
                n = Int32.Parse(getn.Text);
            }
            catch
            {
                textBox1.Text = "格式有误1";
            }
        }

        private void getlength_TextChanged(object sender, EventArgs e) {
            try
            {
                leng = Double.Parse(getlength.Text);
            }
            catch
            {
                textBox1.Text = "格式有误2";
            }
        }

        private void getper1_TextChanged(object sender, EventArgs e) {
            try
            {
                per1 = Double.Parse(getper1.Text);
            }
            catch
            {
                textBox1.Text = "格式有误3";
            }
        }

        private void getper2_TextChanged(object sender, EventArgs e) {
            try
            {
                per2 = Double.Parse(getper2.Text);
            }
            catch
            {
                textBox1.Text = "格式有误4";
            }
        }

        private void getth1_TextChanged(object sender, EventArgs e) {
            try
            {
                th1 = Double.Parse(getth1.Text);
            }
            catch
            {
                textBox1.Text = "格式有误5";
            }
        }

        private void getth2_TextChanged(object sender, EventArgs e) {
            try
            {
                th2 = Double.Parse(getth2.Text);
            }
            catch
            {
                textBox1.Text = "格式有误6";
            }
        }

    }
}
