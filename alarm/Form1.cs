using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace alarm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

              this.WindowState = FormWindowState.Minimized;
          
            timer1.Start();

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime tarih = DateTime.Now;
            this.Text = tarih.ToString();
            if (maskedTextBox1.Text==DateTime.Now.ToShortTimeString()) 
            {
                timer2.Start();
                timer1.Stop();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            timer2.Stop();
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            SoundPlayer sp = new SoundPlayer();
            sp.SoundLocation = string.Format(@"C:\Windows\media\Alarm05.wav", Application.StartupPath);
            sp.Play();
            this.Opacity = 1;
            this.BringToFront();
            this.TopMost = true;

            if (textBox1.BackColor == Color.White)
            {
                textBox1.BackColor = Color.Red;
                textBox1.ForeColor = Color.White;
            }
            else
            {
                textBox1.BackColor = Color.White;
                textBox1.ForeColor = Color.Red;
            }
        }
    }
}
