using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using my_pomodoro.Properties;

namespace my_pomodoro
{
    public partial class SettingsForm : Form
    {
        public static event Action SaveSettings;

        private SaveAndLoadDataToFile saveAndLoadDataToFile = new SaveAndLoadDataToFile();
        private SoundPlayer soundPlayer = new SoundPlayer(FilesPaths.soundPath + TimerScreenForm.soundName + ".wav");
        private Point lastPoint = new Point();
        private bool IsSoundActivate = true;

        public SettingsForm()
        {
            this.TopMost = true;
            InitializeComponent();
            //ProductVersionLabel.Text = Application.ProductVersion;
        }
        
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            string[] userDatas = saveAndLoadDataToFile.LoadDataFromFile(FilesPaths.userSettingsFilePath).Split(',');
            string[] soundsList = saveAndLoadDataToFile.LoadDataFromFile(FilesPaths.soundsListFilePath).Split(',');

            if (saveAndLoadDataToFile.FileExists(FilesPaths.userSettingsFilePath))
            {
                textBoxWork.Text = userDatas[0];//load work time
                textBoxRest.Text = userDatas[1];//load rest time
                checkBoxSound.Checked = Convert.ToBoolean(userDatas[2]);
                comboBoxSound.Text = userDatas[3];
            }

            TimerScreenForm.soundName = comboBoxSound.Text;

            if (saveAndLoadDataToFile.FileExists(FilesPaths.soundsListFilePath))
            {
                comboBoxSound.Items.AddRange(soundsList);
            }

            checkBoxAutoRun.Checked = TimerScreenForm.IsAutoRunOn;
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

        #endregion

        //TODO Method must work for different timers
        private void CloseSettingsButton_Click(object sender, EventArgs e)
        {
            if (textBoxWork.Text == "" || textBoxRest.Text == "")
            {
                MessageBox.Show($"Пустые поля! Укажите значение в пределах от 1 до 60!");
                return;
            }

            //Это можно удалить
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

            //Кажется бестолковая переменная, а неее. Это заделка на будущее
            string messageText = "время";

            if ((workTime < 1 || workTime > 60) || (restTime < 1 || restTime > 60))
            {
                MessageBox.Show($"Пожалуйста, укажите {messageText} в пределах от 1 до 60!");
                return;
            }

            //TODO Доделать проверку, чтобы для кадого поля выводилась своя ошибка
            //if(workTime < 1 || workTime > 60)
            //{
            //    messageText += "рабочее время";
            //    MessageBox.Show($"Пожалуйста, укажите {messageText} в пределах от 1 до 60!");
            //}

            //if (restTime < 1 || restTime > 60)
            //{
            //    messageText += "время отдыха";
            //}
            soundPlayer.Stop();

            string userDatas = saveAndLoadDataToFile.LoadDataFromFile(FilesPaths.userSettingsFilePath);
            string newUserDates = $"{workTime},{restTime},{IsSoundActivate},{TimerScreenForm.soundName}";

            if (userDatas == newUserDates && TimerScreenForm.IsAutoRunOn == checkBoxAutoRun.Checked)
                this.Close();
            else
            {
                DialogResult saveResult = MessageBox.Show("Сохранить текущие настройки?", "Предупреждение", MessageBoxButtons.YesNo);
                
                if (saveResult == DialogResult.Yes)
                {
                    TimerScreenForm.IsSoundAtivate = IsSoundActivate;
                    TimerScreenForm.userTimeForWork = workTime * TimerScreenForm.SecondsInOneMinute;
                    TimerScreenForm.userTimeForRest = restTime * TimerScreenForm.SecondsInOneMinute;
                    TimerScreenForm.IsAutoRunOn = checkBoxAutoRun.Checked; 

                    saveAndLoadDataToFile.UpdateTimesOfTimer(newUserDates);
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
            soundPlayer.Play();
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
    }
}
