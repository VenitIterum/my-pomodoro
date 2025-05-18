namespace my_pomodoro
{
    public struct Sentence
    {
        public string id { get; set; }
        public string text { get; set; }

        public Sentence(string Id, string Text)
        {
            id = Id;
            text = Text;
        }
    }
}
