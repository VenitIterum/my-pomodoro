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
        public static event Action ReplayTimer;
        public static event Action NotReplayTimer;

        private string messegeBoxEmptyFields = "Пустые поля! Укажите значение в пределах от 1 до 60!";
        private string messegeBoxkAllTime = "Некорректные значения! Укажите значение в пределах от 1 до 60!";
        private string messegeBoxWorkTime = "Пожалуйста, укажите рабочее время в пределах от 1 до 60!";
        private string messegeBoxRestTime = "Пожалуйста, укажите время отдыха в пределах от 1 до 60!";
        private string messegeBoxNameMessegeBox = "Предупреждение";
        private string messegeBoxSaveMessege = "Сохранить текущие настройки?";
        private string messegeBoxResetTimer = "Сбросить текущее время?";

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

            LocalizeLabels();
        }

        private void LocalizeLabels()
        {
            labelSettingsTime.Text  = Localization.localizationDatas[7].text;
            labelWork.Text          = Localization.localizationDatas[8].text;
            labelRest.Text          = Localization.localizationDatas[9].text;
            labelMinWork.Text       = Localization.localizationDatas[10].text;
            labelMinRest.Text       = Localization.localizationDatas[10].text;

            labelSoundSettings.Text     = Localization.localizationDatas[11].text;
            labelSound.Text             = Localization.localizationDatas[12].text;
            labelOnOffSound.Text        = Localization.localizationDatas[13].text;
            labelInfoSoundUserPath.Text = Localization.localizationDatas[14].text;

            labelInfoHotKey.Text    = Localization.localizationDatas[15].text;
            labelStartStop.Text     = Localization.localizationDatas[16].text;
            labelReset.Text         = Localization.localizationDatas[17].text;
            labelChangeTimer.Text   = Localization.localizationDatas[18].text;
            labelHiddenApp.Text     = Localization.localizationDatas[19].text;
            labelSpaceKey.Text      = Localization.localizationDatas[20].text;

            labelOther.Text     = Localization.localizationDatas[24].text;
            labelAutoRun.Text   = Localization.localizationDatas[25].text;
            labelLanguage.Text  = Localization.localizationDatas[26].text;

            labelVerson.Text = Localization.localizationDatas[27].text;

            messegeBoxEmptyFields       = Localization.localizationDatas[28].text;
            messegeBoxkAllTime          = Localization.localizationDatas[29].text;
            messegeBoxWorkTime          = Localization.localizationDatas[30].text;
            messegeBoxRestTime          = Localization.localizationDatas[31].text;
            messegeBoxNameMessegeBox    = Localization.localizationDatas[32].text;
            messegeBoxSaveMessege       = Localization.localizationDatas[33].text;
            messegeBoxResetTimer        = Localization.localizationDatas[34].text;
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
                //TODO You can add two labels with red stars 
                MessageBox.Show(messegeBoxEmptyFields);
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
                MessageBox.Show(messegeBoxkAllTime);
                return;
            }

            if (workTime < 1 || workTime > 60)
            {
                MessageBox.Show(messegeBoxWorkTime);
                return;
            }

            if (restTime < 1 || restTime > 60)
            {
                MessageBox.Show(messegeBoxRestTime);
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
                DialogResult saveResult = MessageBox.Show(messegeBoxSaveMessege, messegeBoxNameMessegeBox, MessageBoxButtons.YesNo);

                if (saveResult == DialogResult.Yes)
                {
                    Localization.Init($"{FilesPaths.languagePath}{userSettingsNew.language}.json");

                    TimerScreenForm.IsSoundAtivate  = IsSoundActivate;
                    TimerScreenForm.userTimeForWork = workTime * TimerScreenForm.SecondsInOneMinute;
                    TimerScreenForm.userTimeForRest = restTime * TimerScreenForm.SecondsInOneMinute;
                    TimerScreenForm.IsAutoRunOn     = checkBoxAutoRun.Checked;

                    SaveSettings.Invoke();
                    JsonReadWrite.Serializer<UserSettings>(FilesPaths.userSettingsFilePath, userSettingsNew);
                    
                    if (TimerScreenForm.IsTimerActivate)
                    {
                        DialogResult timerOnResult = MessageBox.Show(messegeBoxResetTimer, messegeBoxNameMessegeBox, MessageBoxButtons.YesNo);

                        if (timerOnResult == DialogResult.Yes)
                        {
                            ReplayTimer.Invoke();
                        }
                        else
                        {
                            NotReplayTimer.Invoke();
                        }
                    }
                    else
                    {
                        ReplayTimer.Invoke();
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
