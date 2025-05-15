using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace my_pomodoro
{
    public class Localization
    {
        private static CultureInfo cl = CultureInfo.InstalledUICulture;
        public static string language = Regex.Match(cl.EnglishName, "^[^ ]+").Value;

        public void StartLocalization()
        {
            //Надо придумать адекватную локализацию.
            //Как сделать сразу несколько сериализаций в одном?
            //Через цикл?
            Sentence sentences = new Sentence();
        }
    }
}
