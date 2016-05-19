using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FNoise
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RandomMap a1 = new RandomMap(8, 128);
            RandomMap a2 = new RandomMap(16, 64);
            RandomMap a3 = new RandomMap(1, 8);
            RandomMap a4 = new RandomMap(4, 32);
            RandomMap a5 = new RandomMap(2, 16);
            RandomMap a = new RandomMap();
            for(int i = 0; i < 128; i++)
            {
                for(int j = 0; j < 128; j++)
                {
                    a.cells[i, j].value = a1.cells[i, j].value + a2.cells[i, j].value 
                                        + a3.cells[i, j].value + a4.cells[i, j].value 
                                        + a5.cells[i, j].value;
                }
            }
            Bitmap b = new Bitmap(128, 128);
            int cc = 0;
            for (int i = 0; i < 128; i++)
            {
                for (int j = 0; j < 128; j++)
                {
                    byte t = (byte)(a.cells[i, j].value);
                    Color c = Color.FromArgb(255, t, t, t);
                    b.SetPixel(i, j, c);
                    if (a.cells[i, j].value < 0)
                        cc++;
                }
            }
            label6.Text = cc.ToString();
            pictureBox1.Image = b;
        }


    }
}
