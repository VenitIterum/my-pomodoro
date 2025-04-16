using System;
using System.IO;
using System.Windows.Forms;

namespace my_pomodoro
{
    internal class SaveAndLoadDataToFile
    {
        private string filePath = "UserSettings.txt";

        internal void UpdateTimesOfTimer(int workTime, int restTime)
        {
            TimerScreenForm.userTimeForWork = workTime * 60;
            TimerScreenForm.userTimeForRest = restTime * 60;

            SaveDataToFile(workTime + "," + restTime);
        }

        internal void SaveDataToFile(string data)
        {
            File.WriteAllText(filePath, data);
        }

        internal string LoadDataFromFile()
        {
            if (File.Exists(filePath))
            {
                string data = File.ReadAllText(filePath);
                return data;
            }
            else
            {
                MessageBox.Show($"File {filePath} not found!");
                return "";
            }
        }

        internal bool FileExists()
        {
            if (File.Exists(filePath)) return true;
            else return false;
        }

    }
}
