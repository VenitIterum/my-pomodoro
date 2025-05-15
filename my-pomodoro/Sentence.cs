namespace my_pomodoro
{
    public struct Sentence
    {
        public string key { get; }
        public string text { get; }

        public Sentence(string Key, string Text)
        {
            key = Key;
            text = Text;
        }
    }
}
