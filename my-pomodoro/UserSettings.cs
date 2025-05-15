namespace my_pomodoro
{
    public struct UserSettings
    {
        public int workTime { get; set; }
        public int restTime { get; set; }
        public bool isSoundActivate { get; set; }
        public string soundName { get; set; }
        public string language { get; set; }

        public UserSettings(int WorkTime, int RestTime, bool IsSoundActivate, string SoundName, string Language)
        {
            workTime = WorkTime;
            restTime = RestTime;
            isSoundActivate = IsSoundActivate;
            soundName = SoundName;
            language = Language;
        }
    }
}
