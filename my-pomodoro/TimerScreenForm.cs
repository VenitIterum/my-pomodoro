using System;
using System.Drawing;
using System.Windows.Forms;
using my_pomodoro.Properties;

namespace my_pomodoro
{
    public partial class TimerScreenForm : Form
    {
        private Point lastPoint = new Point();
        private TimeSpan timerSpan;
        private int userTimeForWork = 55 * 60;
        private int userTimeForFree = 5 * 60;
        private bool IsTimeStatus = true;

        public TimerScreenForm()
        {
            InitializeComponent();
        }

        private void TimerScreenForm_Load(object sender, EventArgs e)
        {
            if (true)
            {
                userTimeForWork = 55 * 60;
                userTimeForFree = 5 * 60;
            }
            else
            {
                //Создаём файл
            }

                timerSpan = TimeSpan.FromSeconds(userTimeForWork);
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            timer1.Stop();
            Timer.ForeColor = Color.Tomato;
            Timer.Text = timerSpan.ToString(@"mm\:ss");
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

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.Image = Resources.close_active;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.Image = Resources.close;
        }

        private void PlayButton_MouseEnter(object sender, EventArgs e)
        {
            PlayButton.BackColor = Color.LightGray;
        }

        private void PlayButton_MouseLeave(object sender, EventArgs e)
        {
            PlayButton.BackColor = Color.White;
        }

        private void PauseButton_MouseEnter(object sender, EventArgs e)
        {
            PauseButton.BackColor = Color.LightGray;
        }

        private void PauseButton_MouseLeave(object sender, EventArgs e)
        {
            PauseButton.BackColor = Color.White;
        }

        private void ReplayButton_MouseEnter(object sender, EventArgs e)
        {
            ReplayButton.BackColor = Color.LightGray;
        }

        private void ReplayButton_MouseLeave(object sender, EventArgs e)
        {
            ReplayButton.BackColor = Color.White;
        }

        private void SwapButton_MouseEnter(object sender, EventArgs e)
        {
            SwapButton.BackColor = Color.LightGray;
        }

        private void SwapButton_MouseLeave(object sender, EventArgs e)
        {
            SwapButton.BackColor = Color.White;
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.Show();
        }

        private void SettingsButton_MouseEnter(object sender, EventArgs e)
        {
            SettingsButton.Image = Resources.settings_active;
        }

        private void SettingsButton_MouseLeave(object sender, EventArgs e)
        {
            SettingsButton.Image = Resources.settings;
        }

        private void PlayButton_MouseClick(object sender, MouseEventArgs e)
        {
            timer1.Start();
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void ReplayButton_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            if (IsTimeStatus) timerSpan = TimeSpan.FromSeconds(userTimeForWork);
            else timerSpan = TimeSpan.FromSeconds(userTimeForFree);

            Timer.Text = timerSpan.ToString(@"mm\:ss");
        }

        private void SwapButton_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (IsTimeStatus)
            {
                IsTimeStatus = false;
                Timer.ForeColor = Color.LightGreen;
                timerSpan = TimeSpan.FromSeconds(userTimeForFree);
            }
            else
            {
                IsTimeStatus = true;
                Timer.ForeColor = Color.Tomato;
                timerSpan = TimeSpan.FromSeconds(userTimeForWork);
            }
            Timer.Text = timerSpan.ToString(@"mm\:ss");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timerSpan.TotalSeconds > 0.5)
            {
                timerSpan = timerSpan.Subtract(TimeSpan.FromSeconds(0.5));
                Timer.Text = timerSpan.ToString(@"mm\:ss");
            }
            else
            {
                timer1.Stop();
                if (IsTimeStatus)
                {
                    IsTimeStatus = false;
                    Timer.ForeColor = Color.LightGreen;
                    timerSpan = TimeSpan.FromSeconds(userTimeForFree);
                }
                else
                {
                    IsTimeStatus = true;
                    Timer.ForeColor = Color.Tomato;
                    timerSpan = TimeSpan.FromSeconds(userTimeForWork);
                }
                Timer.Text = timerSpan.ToString(@"mm\:ss");
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            ActualTime.Text = string.Format("{0:HH\\:mm}", DateTime.Now);
        }
    }
}
