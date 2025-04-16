using System;
using System.Drawing;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;
using my_pomodoro.Properties;

namespace my_pomodoro
{
    public partial class TimerScreenForm : Form
    {
        public static int userTimeForWork = 55 * 60;
        public static int userTimeForRest = 5 * 60;

        private Point lastPoint = new Point();
        private TimeSpan timerSpan;
        private bool IsTimeStatusWork = true;
        private bool IsTimer1MustBlink = false;
        private SoundPlayer soundTimerEnd = new SoundPlayer("endTimeBell.wav");

        public TimerScreenForm()
        {
            InitializeComponent();
        }

        private void TimerScreenForm_Load(object sender, EventArgs e)
        {
            SaveAndLoadDataToFile saveAndLoadDataToFile = new SaveAndLoadDataToFile();
            string[] userMinutes = saveAndLoadDataToFile.LoadDataFromFile().Split(',');

            if (saveAndLoadDataToFile.FileExists())
            {
                userTimeForWork = Convert.ToInt32(userMinutes[0]) * 60;
                userTimeForRest = Convert.ToInt32(userMinutes[1]) * 60;
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
            settingsForm.ShowDialog();
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
            IsTimer1MustBlink = false;
            this.Visible = false;
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            IsTimer1MustBlink = true;
            Blink();
        }

        private void ReplayButton_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            IsTimer1MustBlink = false;

            if (IsTimeStatusWork) timerSpan = TimeSpan.FromSeconds(userTimeForWork);
            else timerSpan = TimeSpan.FromSeconds(userTimeForRest);

            Timer.Text = timerSpan.ToString(@"mm\:ss");
        }

        private void SwapButton_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            IsTimer1MustBlink = false;

            if (IsTimeStatusWork)
            {
                IsTimeStatusWork = false;
                Timer.ForeColor = Color.LightGreen;
                timerSpan = TimeSpan.FromSeconds(userTimeForRest);
            }
            else
            {
                IsTimeStatusWork = true;
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
                this.Visible = true;
                //this.Activate();
                //this.WindowState = FormWindowState.Normal;
                soundTimerEnd.Play();

                if (IsTimeStatusWork)
                {
                    IsTimeStatusWork = false;
                    Timer.ForeColor = Color.LightGreen;
                    timerSpan = TimeSpan.FromSeconds(userTimeForRest);
                }
                else
                {
                    IsTimeStatusWork = true;
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

        private void notifyIcon1_MouseDown(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.Activate();
        }

        private async void Blink()
        {
            while (IsTimer1MustBlink)
            {
                await Task.Delay(500);

                if (IsTimeStatusWork)
                {
                    Timer.ForeColor = Timer.ForeColor == Color.Tomato ? Color.Red : Color.Tomato;
                }
                else
                {
                    Timer.ForeColor = Timer.ForeColor == Color.LightGreen ? Color.Green : Color.LightGreen;
                }
            }

            if (IsTimeStatusWork) Timer.ForeColor = Color.Tomato;
            else Timer.ForeColor = Color.LightGreen;
        }

        //Hotkeys
        private void TimerScreenForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Visible = false;
            }

            if (e.KeyCode == Keys.Space)
            {
                if (timer1.Enabled)
                {
                    timer1.Stop();
                    IsTimer1MustBlink = true;
                    Blink();
                }
                else
                {
                    timer1.Start();
                    IsTimer1MustBlink = false;
                    this.Visible = false;
                }
            }

            if (e.KeyCode == Keys.R)
            {
                timer1.Stop();
                IsTimer1MustBlink = false;

                if (IsTimeStatusWork) timerSpan = TimeSpan.FromSeconds(userTimeForWork);
                else timerSpan = TimeSpan.FromSeconds(userTimeForRest);

                Timer.Text = timerSpan.ToString(@"mm\:ss");
            }

            if (e.KeyCode == Keys.B)
            {
                timer1.Stop();
                IsTimer1MustBlink = false;

                if (IsTimeStatusWork)
                {
                    IsTimeStatusWork = false;
                    Timer.ForeColor = Color.LightGreen;
                    timerSpan = TimeSpan.FromSeconds(userTimeForRest);
                }
                else
                {
                    IsTimeStatusWork = true;
                    Timer.ForeColor = Color.Tomato;
                    timerSpan = TimeSpan.FromSeconds(userTimeForWork);
                }
                Timer.Text = timerSpan.ToString(@"mm\:ss");
            }
        }
    }
}
