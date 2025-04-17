using System;
using System.Drawing;
using System.Windows.Forms;
using my_pomodoro.Properties;

namespace my_pomodoro
{
    public partial class SettingsForm : Form
    {
        private SaveAndLoadDataToFile saveAndLoadDataToFile = new SaveAndLoadDataToFile();
        private Point lastPoint = new Point();

        public SettingsForm()
        {
            InitializeComponent();
            ProductVersionLabel.Text = Application.ProductVersion;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            string[] userMinutes = saveAndLoadDataToFile.LoadDataFromFile().Split(',');

            if (userMinutes != null)
            {
                textBoxWork.Text = userMinutes[0];//load work time
                textBoxRest.Text = userMinutes[1];//load rest time
            }
        }

        #region === Settings form drag logic ===

        private void SettingsForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void SettingsForm_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        #endregion

        #region === Enter/Leave cursor on buttons ===

        private void CloseSettingsButton_MouseEnter(object sender, EventArgs e)
        {
            CloseSettingsButton.Image = Resources.close_active;
        }

        private void CloseSettingsButton_MouseLeave(object sender, EventArgs e)
        {
            CloseSettingsButton.Image = Resources.close;
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

            int workTime = Convert.ToInt32(textBoxWork.Text);
            int restTime = Convert.ToInt32(textBoxRest.Text);
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
            
            saveAndLoadDataToFile.UpdateTimesOfTimer(workTime, restTime);
            this.Close();
        }
    }
}
