using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace my_pomodoro
{
    public partial class TimerScreenForm : Form
    {
        private Point lastPoint = new Point();
        private Stopwatch timer;
        private Stopwatch userValue;

        private Timer timerReally = new Timer();

        public TimerScreenForm()
        {
            InitializeComponent();
        }

        private void TimerScreenForm_Load(object sender, EventArgs e)
        {
            timer = new Stopwatch();
            userValue = new Stopwatch();

            timerReally.Enabled = false;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TimerScreenForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void TimerScreenForm_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void TimerScreenForm_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Gray;
        }

        private void TimerScreenForm_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.DimGray;
        }

        private void PlayButton_MouseClick(object sender, MouseEventArgs e)
        {
            //timer.Start();
            timerReally.Enabled = true;
            timerReally.Interval = 10000;
            timerReally.Start();
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            //timer.Stop();
            timerReally.Stop();
        }

        private void ReplayButton_Click(object sender, EventArgs e)
        {
            timer.Reset();
            this.Timer.Text = string.Format("{0:mm\\:ss}", timerReally);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //this.Timer.Text = string.Format("{0:mm\\:ss}", timerReally.Interval);
            this.Timer.Text = timerReally.ToString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.ActualTime.Text = string.Format("{0:HH\\:mm}", DateTime.Now);
        }
    }
}
