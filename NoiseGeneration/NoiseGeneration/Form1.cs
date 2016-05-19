using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoiseGeneration
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerationController c;
            if(textBox1.Text != "" && textBox2.Text != "")
                c = new GenerationController(Convert.ToInt16(textBox1.Text), Convert.ToInt16(textBox2.Text));
            else
                c = new GenerationController();
            label7.Text = c.ccw.ToString();
            label8.Text = c.ccg.ToString();
            label9.Text = c.ccb.ToString();
            Bitmap b = new Bitmap(128, 128);
            for(int i = 0; i < 128; i++)
            {
                for(int j = 0; j < 128; j++)
                {
                    double t = c.cells[i, j].value;
                    //Color co = Color.FromArgb((byte)(t), (byte)(t), (byte)(t));
                    //b.SetPixel(i, j, co);
                    if (t < 100)
                        b.SetPixel(i, j, Color.DarkBlue);
                    else if (t < 120)
                        b.SetPixel(i, j, Color.Blue);
                    else if (t < 140)
                        b.SetPixel(i, j, Color.YellowGreen);
                    else if (t < 160)
                        b.SetPixel(i, j, Color.Green);
                    else
                        b.SetPixel(i, j, Color.DarkGreen);
                }
            }
            pictureBox1.Image = b;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int a, b, c;
            a = r.Next(100);
            b = r.Next(100);
            c = r.Next(100);
            label1.Text = a.ToString() + " " + b.ToString() + " " + c.ToString();
        }

    }
}
