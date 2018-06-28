namespace Kiss4Web.Infrastructure
{
    public class RequestLanguage
    {
        public RequestLanguage(Language language)
        {
            Language = language;
        }

        public Language Language { get; }
    }
}