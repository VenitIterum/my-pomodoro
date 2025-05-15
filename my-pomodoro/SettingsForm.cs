using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;
using my_pomodoro.Properties;

namespace my_pomodoro
{
    public partial class SettingsForm : Form
    {
        public static event Action SaveSettings;

        private SoundPlayer soundPlayer = new SoundPlayer(FilesPaths.soundPath + TimerScreenForm.soundName + ".wav");
        private Point lastPoint = new Point();
        private bool IsSoundActivate = true;

        public SettingsForm()
        {
            this.TopMost = true;
            InitializeComponent();
            ProductVersionLabel.Text = Application.ProductVersion;
        }
        
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            UserSettings userSettings;
            //FOR LANGUAGE SETTINGS
            //$"{FilesPaths.languagePath}{Localization.language}.json"
            string[] pathsSoundFiles = Directory.GetFiles(FilesPaths.soundPath, "*.wav");
            string[] pathsLanguageFiles = Directory.GetFiles(FilesPaths.languagePath, "*.json");
            List<string> soundsList = new List<string>();
            List<string> languagesList = new List<string>();

            foreach (string path in pathsSoundFiles)
            {
                soundsList.Add(Path.GetFileNameWithoutExtension(path));
            }

            foreach (string path in pathsLanguageFiles)
            {
                languagesList.Add(Path.GetFileNameWithoutExtension(path));
            }

            if (File.Exists(FilesPaths.userSettingsFilePath))
            {
                userSettings = JsonReadWrite.Deserializer<UserSettings>(FilesPaths.userSettingsFilePath);

                textBoxWork.Text        = userSettings.workTime.ToString();
                textBoxRest.Text        = userSettings.restTime.ToString();
                checkBoxSound.Checked   = userSettings.isSoundActivate;
                comboBoxSound.Text      = userSettings.soundName;
                comboBoxLanguage.Text   = userSettings.language;

                TimerScreenForm.soundName = comboBoxSound.Text;
                Localization.language = comboBoxLanguage.Text;
            }
            else
            {
                comboBoxLanguage.Text = Localization.language;
            }

            if (pathsSoundFiles.Length != 0)
            {
                comboBoxSound.Items.AddRange(soundsList.ToArray());
            }

            if (pathsLanguageFiles.Length != 0)
            {
                comboBoxLanguage.Items.AddRange(languagesList.ToArray());
            }

            checkBoxAutoRun.Checked = TimerScreenForm.IsAutoRunOn;

            labelPathForUserSounds.Text = FilesPaths.soundPath;
        }

        #region === Settings form drag logic ===

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

        private void CloseSettingsButton_MouseEnter(object sender, EventArgs e)
        {
            CloseSettingsButton.Image = Resources.close;
        }

        private void CloseSettingsButton_MouseLeave(object sender, EventArgs e)
        {
            CloseSettingsButton.Image = Resources.close_active;
        }

        private void PlaySoundButton_MouseEnter(object sender, EventArgs e)
        {
            PlaySoundButton.Image = Resources.play_button_arrowhead_green;
        }

        private void PlaySoundButton_MouseLeave(object sender, EventArgs e)
        {
            PlaySoundButton.Image = Resources.play_button_arrowhead;
        }

        private void InfoButton_MouseEnter(object sender, EventArgs e)
        {
            InfoButton.Image = Resources.info_black;
        }

        private void InfoButton_MouseLeave(object sender, EventArgs e)
        {
            InfoButton.Image = Resources.info;
        }

        #endregion

        private void CloseSettingsButton_Click(object sender, EventArgs e)
        {
            if (textBoxWork.Text == "" || textBoxRest.Text == "")
            {
                //TODO u can add two labels with red stars 
                MessageBox.Show($"Пустые поля! Укажите значение в пределах от 1 до 60!");
                return;
            }

            int workTime = 55;
            int restTime = 5;

            try
            {
                workTime = Convert.ToInt32(textBoxWork.Text);
                restTime = Convert.ToInt32(textBoxRest.Text);
            }
            catch
            {
                MessageBox.Show($"Некорректные значения! Укажите значение в пределах от 1 до 60!");
                return;
            }

            if (workTime < 1 || workTime > 60)
            {
                MessageBox.Show($"Пожалуйста, укажите рабочее время в пределах от 1 до 60!");
                return;
            }

            if (restTime < 1 || restTime > 60)
            {
                MessageBox.Show($"Пожалуйста, укажите время отдыха в пределах от 1 до 60!");
                return;
            }

            soundPlayer.Stop();

            UserSettings userSettingsFromFile = JsonReadWrite.Deserializer<UserSettings>(FilesPaths.userSettingsFilePath);
            UserSettings userSettingsNew = new UserSettings(workTime, restTime, IsSoundActivate, comboBoxSound.Text, comboBoxLanguage.Text);

            if (userSettingsFromFile.Equals(userSettingsNew) && TimerScreenForm.IsAutoRunOn == checkBoxAutoRun.Checked)
            {
                this.Close();
            }
            else
            {
                DialogResult saveResult = MessageBox.Show("Сохранить текущие настройки?", "Предупреждение", MessageBoxButtons.YesNo);

                if (saveResult == DialogResult.Yes)
                {
                    TimerScreenForm.IsSoundAtivate  = IsSoundActivate;
                    TimerScreenForm.userTimeForWork = workTime * TimerScreenForm.SecondsInOneMinute;
                    TimerScreenForm.userTimeForRest = restTime * TimerScreenForm.SecondsInOneMinute;
                    TimerScreenForm.IsAutoRunOn     = checkBoxAutoRun.Checked;

                    JsonReadWrite.Serializer<UserSettings>(FilesPaths.userSettingsFilePath, userSettingsNew);
                    if (TimerScreenForm.IsTimerActivate)
                    {
                        DialogResult timerOnResult = MessageBox.Show("Сбросить текущее время?", "Предупреждение", MessageBoxButtons.YesNo);

                        if (timerOnResult == DialogResult.Yes)
                        {
                            SaveSettings.Invoke();
                        }
                    }
                    else
                    {
                        SaveSettings.Invoke();
                    }
                    this.Close();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void PlaySoundButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(FilesPaths.soundPath + TimerScreenForm.soundName + ".wav"))
            {
                soundPlayer.Play();
            }
        }

        private void comboBoxSound_SelectionChangeCommitted(object sender, EventArgs e)
        {
            TimerScreenForm.soundName = comboBoxSound.SelectedItem.ToString();
            soundPlayer = new SoundPlayer(FilesPaths.soundPath + TimerScreenForm.soundName + ".wav");
        }

        private void checkBoxSound_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            if (checkBox.Checked) IsSoundActivate = true;
            else IsSoundActivate = false;
        }

        private void InfoButton_Click(object sender, EventArgs e)
        {
            AboutAppForm aboutAppForm = new AboutAppForm();
            aboutAppForm.ShowDialog();
        }
    }
}
