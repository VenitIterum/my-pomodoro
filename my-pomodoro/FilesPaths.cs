using System.IO;

namespace my_pomodoro
{
    public class FilesPaths
    {
        private static string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
        
        public static string appPath                = Path.GetDirectoryName(exePath);
        public static string userSettingsFilePath   = Path.Combine(appPath, "UserSettings.json");
        public static string soundPath              = Path.Combine(appPath, @"Sounds\");
        public static string languagePath           = Path.Combine(appPath, @"Localization\");
    }
}
