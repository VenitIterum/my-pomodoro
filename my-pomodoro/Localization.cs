using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Text.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace my_pomodoro
{
    public class Localization
    {
        private static CultureInfo cl = CultureInfo.InstalledUICulture;
        public static string language = Regex.Match(cl.EnglishName, "^[^ ]+").Value;
        public static List<Sentence> localizationDatas;

        public static void Init(string path)
        {
            //Надо придумать адекватную локализацию.
            //Как сделать сразу несколько сериализаций в одном?
            //Через цикл?
            localizationDatas = JsonReadWrite.Deserializer<List<Sentence>>(path);
        }
    }
}
