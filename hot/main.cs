using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace hot
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new checkin().Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new checkout().Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new cleanin().Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new reserv().Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void main_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.WindowState = FormWindowState.Maximized;
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
