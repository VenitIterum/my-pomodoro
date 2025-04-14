using System;
using System.Drawing;
using System.Windows.Forms;
using my_pomodoro.Properties;

namespace my_pomodoro
{
    public partial class SettingsForm : Form
    {
        SaveAndLoadDataToFile saveAndLoadDataToFile = new SaveAndLoadDataToFile();

        Point lastPoint = new Point();

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

        private void CloseSettingsButton_Click(object sender, EventArgs e)
        {
            saveAndLoadDataToFile.UpdateTimesOfTimer(textBoxWork.Text, textBoxRest.Text);
            this.Close();
        }

        private void CloseSettingsButton_MouseEnter(object sender, EventArgs e)
        {
            CloseSettingsButton.Image = Resources.close_active;
        }

        private void CloseSettingsButton_MouseLeave(object sender, EventArgs e)
        {
            CloseSettingsButton.Image = Resources.close;
        }

        private void SettingsForm_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Gray;
        }

        private void SettingsForm_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.DimGray;
        }

        private void SettingsForm_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void SettingsForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
    }
}
