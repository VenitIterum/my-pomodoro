using System.IO;

namespace my_pomodoro
{
    internal class SaveAndLoadDataToFile
    {
        internal void UpdateTimesOfTimer(string newUserDates)
        {
            SaveDataToFile(newUserDates, FilesPaths.userSettingsFilePath);
        }

        internal void SaveDataToFile(string data, string filePath)
        {
            File.WriteAllText(filePath, data);
        }

        internal string LoadDataFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string data = File.ReadAllText(filePath);
                return data;
            }
            else
            {
                //MessageBox.Show($"File {filePath} not found!");
                return "";
            }
        }

        internal bool FileExists(string filePath)
        {
            if (File.Exists(filePath)) return true;
            else return false;
        }

    }
}
