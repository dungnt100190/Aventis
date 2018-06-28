namespace Kiss4Web.Infrastructure
{
    public struct Language
    {
        private readonly string _language;

        static Language()
        {
            Deutsch = new Language(Languages.Deutsch);
            English = new Language(Languages.English);
            Français = new Language(Languages.Français);
            Italiano = new Language(Languages.Italiano);
        }

        public Language(string language)
        {
            _language = language;
        }

        public static Language Deutsch { get; }

        public static Language English { get; }

        public static Language Français { get; }

        public static Language Italiano { get; }

        public static implicit operator string(Language language)
        {
            return language._language;
        }

        public override string ToString()
        {
            return this;
        }
    }

    public static class Languages
    {
        public const string Deutsch = "de";
        public const string English = "en";
        public const string Français = "fr";
        public const string Italiano = "it";
    }
}