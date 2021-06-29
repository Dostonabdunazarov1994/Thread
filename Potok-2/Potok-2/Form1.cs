using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Potok_2
{
    public partial class Form1 : Form
    {
        Mythread th1;
        Mythread th2;
        Mythread th3;
        Mythread th4;
        public Form1()
        {
            InitializeComponent();
            th1 = new Mythread(Red);
            th2 = new Mythread(Green);
            th3 = new Mythread(Blue);
            th4 = new Mythread(this);
        }
        double red, green, blue;
        public void Red()
        {
            red = (181 + red) % 180;
            panel1.BackColor = Color.FromArgb((int)(255 * Math.Sin((Math.PI * red) / 180)), 0, 0);
            panel4.BackColor = Color.FromArgb((int)(255 * Math.Sin((Math.PI * red) / 180)), (int)(255 * Math.Sin((Math.PI * green) / 180)), (int)(255 * Math.Sin((Math.PI * blue) / 180)));

        }
        public void Green()
        {
            green = (181 + green) % 180;
            panel2.BackColor = Color.FromArgb(0, (int)(255 * Math.Sin((Math.PI * green) / 180)), 0);
            panel4.BackColor = Color.FromArgb((int)(255 * Math.Sin((Math.PI * red) / 180)), (int)(255 * Math.Sin((Math.PI * green) / 180)), (int)(255 * Math.Sin((Math.PI * blue) / 180)));
        }
        public void Blue()
        {
            blue = (181 + blue) % 180;
            panel3.BackColor = Color.FromArgb(0, 0, (int)(255 * Math.Sin((Math.PI * blue) / 180)));
            panel4.BackColor = Color.FromArgb((int)(255 * Math.Sin((Math.PI * red) / 180)), (int)(255 * Math.Sin((Math.PI * green) / 180)), (int)(255 * Math.Sin((Math.PI * blue) / 180)));
        }
        public void time()
        {
            label1.Text = DateTime.Now.ToString("HH:mm:ss,fff");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked) th1.Res();
            else th1.Sus();

            if (!checkBox2.Checked) th2.Res();
            else th2.Sus();

            if (!checkBox3.Checked) th3.Res();
            else th3.Sus();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            th1.Priority = (ThreadPriority)(trackBar1.Value);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            th2.Priority = (ThreadPriority)(trackBar2.Value);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            th3.Priority = (ThreadPriority)(trackBar3.Value);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            th4.Stop();
        }

       
     
    }
}
