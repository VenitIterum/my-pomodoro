using System;
using System.Drawing;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;
using my_pomodoro.Properties;
using System.IO;

namespace my_pomodoro
{
    public partial class TimerScreenForm : Form
    {
        public const int SecondsInOneMinute = 60;

        public static int userTimeForWork = 55 * SecondsInOneMinute;
        public static int userTimeForRest = 5 * SecondsInOneMinute;

        private static string filePath = "Sounds/endTimeBell.wav";
        private bool IsTimeStatusWork = true;
        private bool IsTimer1MustBlink = false;
        private SoundPlayer soundTimerEnd = new SoundPlayer(filePath);
        private Point lastPoint = new Point();
        private TimeSpan timerSpan;

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
                userTimeForWork = Convert.ToInt32(userMinutes[0]) * SecondsInOneMinute;
                userTimeForRest = Convert.ToInt32(userMinutes[1]) * SecondsInOneMinute;
            }

            timerSpan = TimeSpan.FromSeconds(userTimeForWork);
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            timer1.Stop();

            Timer.ForeColor = Color.Tomato;
            Timer.Text = timerSpan.ToString(@"mm\:ss");

            EndTime.Text = string.Format("{0:HH\\:mm}", DateTime.Now + TimeSpan.FromSeconds(userTimeForWork));
        }

        #region === Main form drag logic ===

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

        #endregion

        #region === Enter/Leave cursor on buttons ===

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

        private void SettingsButton_MouseEnter(object sender, EventArgs e)
        {
            SettingsButton.Image = Resources.settings_active;
        }

        private void SettingsButton_MouseLeave(object sender, EventArgs e)
        {
            SettingsButton.Image = Resources.settings;
        }

        #endregion

        #region === MouseClick logic for buttons ===

        private void PlayButton_MouseClick(object sender, MouseEventArgs e)
        {
            StartTimer();
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            StopTimer();
        }

        private void ReplayButton_Click(object sender, EventArgs e)
        {
            ReplayTimer();
        }

        private void SwapButton_Click(object sender, EventArgs e)
        {
            SwapTimer();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }

        #endregion

        #region === Hotkeys ===

        private void TimerScreenForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (!timer1.Enabled)
                {
                    StartTimer();
                }
                else
                {
                    StopTimer();
                }
            }

            if (e.KeyCode == Keys.R)
            {
                ReplayTimer();
            }

            if (e.KeyCode == Keys.B)
            {
                SwapTimer();
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.Visible = false;
            }
        }

        #endregion

        #region === Realization for logic buttons ===

        private void StartTimer()
        {
            timer1.Start();
            IsTimer1MustBlink = false;
            this.Visible = false;
        }

        private void StopTimer()
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
                IsTimer1MustBlink = true;
                Blink();
            }
        }

        private void ReplayTimer()
        {
            timer1.Stop();
            IsTimer1MustBlink = false;

            if (IsTimeStatusWork)
            {
                timerSpan = TimeSpan.FromSeconds(userTimeForWork);
                EndTime.Text = string.Format("{0:HH\\:mm}", DateTime.Now + TimeSpan.FromSeconds(userTimeForWork));
            }
            else
            {
                timerSpan = TimeSpan.FromSeconds(userTimeForRest);
                EndTime.Text = string.Format("{0:HH\\:mm}", DateTime.Now + TimeSpan.FromSeconds(userTimeForRest));
            }

            Timer.Text = timerSpan.ToString(@"mm\:ss");
        }

        private void SwapTimer()
        {
            timer1.Stop();
            IsTimer1MustBlink = false;

            if (IsTimeStatusWork)
            {
                IsTimeStatusWork = false;
                Timer.ForeColor = Color.LightGreen;
                timerSpan = TimeSpan.FromSeconds(userTimeForRest);
                EndTime.Text = string.Format("{0:HH\\:mm}", DateTime.Now + TimeSpan.FromSeconds(userTimeForRest));
            }
            else
            {
                IsTimeStatusWork = true;
                Timer.ForeColor = Color.Tomato;
                timerSpan = TimeSpan.FromSeconds(userTimeForWork);
                EndTime.Text = string.Format("{0:HH\\:mm}", DateTime.Now + TimeSpan.FromSeconds(userTimeForWork));
            }
            Timer.Text = timerSpan.ToString(@"mm\:ss");
        }

        #endregion

        #region === Timers tick methods ===

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
                if (File.Exists(filePath)) soundTimerEnd.Play();

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
            if (!timer1.Enabled)
            {
                EndTime.Text = string.Format("{0:HH\\:mm}", DateTime.Now + timerSpan);
            }
        }

        #endregion

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

        private void notifyIcon1_MouseDown(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.Activate();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
