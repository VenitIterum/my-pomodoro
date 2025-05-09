using System;
using System.Drawing;
using System.Windows.Forms;
using my_pomodoro.Properties;

namespace my_pomodoro
{
    public partial class AboutAppForm : Form
    {
        private const int StartYear = 2025;

        private Point lastPoint;
        private DateTime todayDateTime = new DateTime();

        public AboutAppForm()
        {
            this.TopMost = true;
            InitializeComponent();
            ProductVersionLabel.Text = Application.ProductVersion;
        }

        private void AboutAppForm_Load(object sender, EventArgs e)
        {
            todayDateTime = DateTime.Now;

            if (StartYear == todayDateTime.Year)
            {
                yearsLabel.Text = $"{StartYear}";
            }
            else
            {
                yearsLabel.Text = $"{StartYear} - {todayDateTime.Year}";
            }
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

        #endregion

        private void CloseSettingsButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
