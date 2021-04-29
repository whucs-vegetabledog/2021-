using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace CsharpHomework9
{
    public partial class Form1 : Form
    {

        private string startUrl = "";
        private Crawler myCrawler = new Crawler();
        private Uri u = null;
        public static StringBuilder message = new StringBuilder();

        public Form1()
        {
            InitializeComponent();
        }

        private void textInput_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            startUrl = textInput.Text;
            try
            {
                textIsCompleted.Text = "Success!";
                u = new Uri(startUrl);
                myCrawler.urls.Add(startUrl, false);
                new Thread(myCrawler.Crawl).Start();
            }
            catch
            {
                textIsCompleted.Text = "Defeat!";
            }
        }

        private void textIsCompleted_TextChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void textOutput_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
