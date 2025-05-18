using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace my_pomodoro
{
    public class Localization
    {
        private static CultureInfo cl = CultureInfo.InstalledUICulture;
        public static string language = Regex.Match(cl.EnglishName, "^[^ ]+").Value;
        public static List<Sentence> localizationDatas;

        public static void Init(string path)
        {
            localizationDatas = JsonReadWrite.Deserializer<List<Sentence>>(path);
        }
    }
}
