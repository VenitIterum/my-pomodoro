using System;
using System.Drawing;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;
using my_pomodoro.Properties;
using System.IO;
using Microsoft.Win32;
using System.Drawing.Printing;

namespace my_pomodoro
{
    public partial class TimerScreenForm : Form
    {
        public const int SecondsInOneMinute = 60;
        
        private const string myAppName = "My POMODORO";

        public static int userTimeForWork = 55 * SecondsInOneMinute;
        public static int userTimeForRest = 5 * SecondsInOneMinute;
        public static bool IsSoundAtivate = true;
        public static bool IsTimerActivate = false;//Переменная создана для одной только проверки в окне настроек!
        public static bool IsAutoRunOn = false;
        public static string soundName = "End Time Bell";

        private string strWorkStatus = "Фокус";
        private string strRestStatus = "Отдых";
        private string strStatusInWork = "закончится через";
        private string strStatusStop = "приостановлен";
        private string strStatusHold = "OVERTIME!!!";
        private bool IsTimeStatusWork = true;
        private bool IsTimer1MustBlink = false;
        private SoundPlayer soundTimerEnd = new SoundPlayer($"{FilesPaths.soundPath}{soundName}.wav");
        private RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        private Point lastPoint = new Point();
        private TimeSpan timerSpan;

        public TimerScreenForm()
        {
            this.TopMost = true;
            InitializeComponent();

            if(rkApp.GetValue(myAppName) == null)
                IsAutoRunOn = false;
            else
                IsAutoRunOn = true;
        }

        private void TimerScreenForm_Load(object sender, EventArgs e)
        {
            SettingsForm.SaveSettings += LocalizeLabels;
            SettingsForm.SaveSettings += ChangeAplicationAutoRun;
            SettingsForm.ReplayTimer += ReplayTimer;
            SettingsForm.NotReplayTimer += WorkStatusText;

            string[] pathsLanguageFiles = Directory.GetFiles(FilesPaths.languagePath, "*.json");
            bool IsLanguageExist = false;

            if (File.Exists(FilesPaths.userSettingsFilePath))
            {
                UserSettings userSettings = JsonReadWrite.Deserializer<UserSettings>(FilesPaths.userSettingsFilePath);

                userTimeForWork = Convert.ToInt32(userSettings.workTime) * SecondsInOneMinute;
                userTimeForRest = Convert.ToInt32(userSettings.restTime) * SecondsInOneMinute;
                IsSoundAtivate = userSettings.isSoundActivate;
                soundName = userSettings.soundName;
                Localization.language = userSettings.language;
            }

            foreach (string path in pathsLanguageFiles)
            {
                if (Localization.language == Path.GetFileNameWithoutExtension(path))
                {
                    IsLanguageExist = true;
                    break;
                }
            }

            if (!IsLanguageExist)
            {
                Localization.language = "English";
            }

            timerSpan = TimeSpan.FromSeconds(userTimeForWork);
            timer1.Interval = 1000;
            Stopwatch.Interval = 1000;
            timer1.Tick += timer1_Tick;
            timer1.Stop();

            Timer.Text = timerSpan.ToString(@"mm\:ss");

            EndTime.Text = string.Format("{0:HH\\:mm}", DateTime.Now + TimeSpan.FromSeconds(userTimeForWork));

            Localization.Init($"{FilesPaths.languagePath}{Localization.language}.json");
            LocalizeLabels();

            LabelWorkStatus.Text = strWorkStatus;
        }

        private void LocalizeLabels()
        {
            strWorkStatus   = Localization.localizationDatas[0].text;
            strRestStatus   = Localization.localizationDatas[1].text;
            strStatusInWork = Localization.localizationDatas[2].text;
            strStatusStop   = Localization.localizationDatas[3].text;
            strStatusHold   = Localization.localizationDatas[4].text;

            labelActualTime.Text    = Localization.localizationDatas[5].text;
            labelEndTimer.Text      = Localization.localizationDatas[6].text;
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
                //WorkStatusText();
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

        private void WorkStatusText()
        {
            LabelWorkStatus.Text = (IsTimeStatusWork ? $"{strWorkStatus}" : $"{strRestStatus}") + $" {strStatusInWork}";
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

        private void ChangeAplicationAutoRun()
        {
            if (IsAutoRunOn)
                rkApp.SetValue(myAppName, Application.ExecutablePath);
            else
                rkApp.DeleteValue(myAppName, false);
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
            SettingsForm.SaveSettings -= ChangeAplicationAutoRun;
        }
    }
}
