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

        private const string strWorkStatus = "Фокус";
        private const string strRestStatus = "Отдых";
        private const string strStatusInWork = "закончится через";
        private const string strStatusStop = "приостановлен";
        private const string strStatusHold = "OVERTIME!!!";

        public static int userTimeForWork = 55 * SecondsInOneMinute;
        public static int userTimeForRest = 5 * SecondsInOneMinute;
        public static bool IsSoundAtivate = true;
        public static bool IsTimerActivate = false;//Переменная создана для одной только проверки в окне настроек!
        public static string soundName = "EndTimeBell";

        private bool IsTimeStatusWork = true;
        private bool IsTimer1MustBlink = false;
        private SoundPlayer soundTimerEnd = new SoundPlayer("Sounds/EndTimeBell.wav");
        private Point lastPoint = new Point();
        private TimeSpan timerSpan;

        public TimerScreenForm()
        {
            this.TopMost = true;
            InitializeComponent();
        }

        private void TimerScreenForm_Load(object sender, EventArgs e)
        {
            SettingsForm.SaveSettings += ReplayTimer;

            SaveAndLoadDataToFile saveAndLoadDataToFile = new SaveAndLoadDataToFile();
            string[] userDatas = saveAndLoadDataToFile.LoadDataFromFile(FilesPaths.userSettingsFilePath).Split(',');

            if (saveAndLoadDataToFile.FileExists(FilesPaths.userSettingsFilePath))
            {
                userTimeForWork = Convert.ToInt32(userDatas[0]) * SecondsInOneMinute;
                userTimeForRest = Convert.ToInt32(userDatas[1]) * SecondsInOneMinute;
                IsSoundAtivate = Convert.ToBoolean(userDatas[2]);
                soundName = userDatas[3];
            }

            LabelWorkStatus.Text = strWorkStatus;

            timerSpan = TimeSpan.FromSeconds(userTimeForWork);
            timer1.Interval = 1000;
            Stopwatch.Interval = 1000;
            timer1.Tick += timer1_Tick;
            timer1.Stop();

            Timer.Text = timerSpan.ToString(@"mm\:ss");

            EndTime.Text = string.Format("{0:HH\\:mm}", DateTime.Now + TimeSpan.FromSeconds(userTimeForWork));
        }

        #region === Main form drag logic ===

        private void objectForMoveForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void objectForMoveForm_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        #endregion

        #region === Enter/Leave cursor on buttons ===

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.Image = Resources.close;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.Image = Resources.close_active;
        }

        private void PlayButton_MouseEnter(object sender, EventArgs e)
        {
            if (IsTimeStatusWork)
                PlayButton.BackColor = Color.Tomato;
            else
                PlayButton.BackColor = Color.YellowGreen;
        }

        private void PlayButton_MouseLeave(object sender, EventArgs e)
        {
            if (IsTimeStatusWork)
                PlayButton.BackColor = Color.Salmon;
            else
                PlayButton.BackColor = Color.LightGreen;
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
            SettingsButton.Image = Resources.settings;
        }

        private void SettingsButton_MouseLeave(object sender, EventArgs e)
        {
            SettingsButton.Image = Resources.settings_active;
        }

        #endregion

        #region === MouseClick logic for buttons ===

        private void PlayButton_MouseClick(object sender, MouseEventArgs e)
        {
            PlayOrStopTimer();
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
                PlayOrStopTimer();
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

        private void PlayOrStopTimer()
        {
            if (!Stopwatch.Enabled)
            {
                if (!timer1.Enabled)
                {
                    LabelWorkStatus.Text = (IsTimeStatusWork ? $"{strWorkStatus}" : $"{strRestStatus}") + $" {strStatusInWork}";
                    PlayButton.Image = Resources.pause;
                    StartTimer();
                }
                else
                {
                    LabelWorkStatus.Text = (IsTimeStatusWork ? $"{strWorkStatus}" : $"{strRestStatus}") + $" {strStatusStop}";
                    PlayButton.Image = Resources.play_button_arrowhead;
                    StopTimer();
                }
            }
            else
            {
                Timer.ForeColor = Color.White;
                SwapTimer();
            }
        }

        private void StartTimer()
        {
            timer1.Start();
            Stopwatch.Stop();
            IsTimerActivate = true;
            IsTimer1MustBlink = false;
            this.Visible = false;
        }

        private void StopTimer()
        {
            if (timer1.Enabled)//Not must have IF
            {
                timer1.Stop();
                IsTimerActivate = false;
                IsTimer1MustBlink = true;
                Blink();
            }
        }

        private void ReplayTimer()
        {
            timer1.Stop();
            Stopwatch.Stop();

            IsTimerActivate = false;
            IsTimer1MustBlink = false;

            Timer.ForeColor = Color.White;
            PlayButton.Image = Resources.play_button_arrowhead;
            LabelWorkStatus.Text = (IsTimeStatusWork ? $"{strWorkStatus}" : $"{strRestStatus}");


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
            IsTimer1MustBlink = false;
            ChangeTimerType();
        }

        private void ChangeTimerType()
        {
            timer1.Stop();
            Stopwatch.Stop();

            IsTimerActivate = false;

            Timer.ForeColor = Color.White;
            PlayButton.Image = Resources.play_button_arrowhead;

            if (IsTimeStatusWork)
            {
                IsTimeStatusWork = false;
                PlayButton.BackColor = Color.LightGreen;
                timerSpan = TimeSpan.FromSeconds(userTimeForRest);
            }
            else
            {
                IsTimeStatusWork = true;
                PlayButton.BackColor = Color.Salmon;
                timerSpan = TimeSpan.FromSeconds(userTimeForWork);
            }

            LabelWorkStatus.Text = (IsTimeStatusWork ? $"{strWorkStatus}" : $"{strRestStatus}");
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
                Stopwatch.Start();

                Timer.ForeColor = Color.Tomato;
                LabelWorkStatus.Text = (IsTimeStatusWork ? $"{strWorkStatus}" : $"{strRestStatus}") + $" {strStatusHold}";

                this.Visible = true;
                this.Activate();

                //Следующая строчка максимально костыльная. Каждый раз присваивать один и тот же путь до звука такое себе
                soundTimerEnd = new SoundPlayer(FilesPaths.soundPath + soundName + ".wav");
                if (File.Exists(FilesPaths.soundPath + soundName + ".wav") && IsSoundAtivate) soundTimerEnd.Play();
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

        private void Stopwatch_Tick(object sender, EventArgs e)
        {
            timerSpan = timerSpan.Add(TimeSpan.FromSeconds(1));
            Timer.Text = timerSpan.ToString(@"mm\:ss");
        }

        #endregion

        private async void Blink()
        {
            while (IsTimer1MustBlink)
            {
                await Task.Delay(500);

                Timer.ForeColor = Timer.ForeColor == Color.White ? Color.Gray : Color.White;
            }

            Timer.ForeColor = Color.White;
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

        private void TimerScreenForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SettingsForm.SaveSettings -= ReplayTimer;
        }
    }
}
