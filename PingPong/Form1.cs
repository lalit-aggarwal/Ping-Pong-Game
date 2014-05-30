using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PingPong
{
    public partial class Form1 : Form
    {
        int x, y;
        int xinc = 3, yinc = 3;
        int xloc;
        int score = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Point p = new Point();
            x += xinc;
            y += yinc;
            if (x <= 0)
                xinc *= -1;
            if (y <= 0)
                yinc *= -1;
            if (x + 10 >= 485)
                xinc *= -1;
            if (y + 10 >= 450 && x > xloc && x < xloc + 100)
            {
                yinc *= -1;
                score += 1;
                label1.Text = "Score : " + score.ToString();
            }
            if (y + 10 > 500)
            {
                timer1.Stop();
                MessageBox.Show("Your score is : " + score);
            }
            p.X = x;
            p.Y = y;
            pictureBox1.Location = p;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            x = pictureBox1.Location.X;
            y = pictureBox1.Location.Y;
            timer1.Start();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Point p = new Point();
            xloc = pictureBox2.Location.X;
            if (e.KeyChar == 'a' || e.KeyChar == 'A')
                xloc += -8;
            if (e.KeyChar == 'd' || e.KeyChar == 'D')
                xloc += 8;
            if (xloc <= 0)
                xloc = 0;
            if (xloc + 100 >= 500)
                xloc = 400;
            p.X = xloc;
            p.Y = pictureBox2.Location.Y;
            pictureBox2.Location = p;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
