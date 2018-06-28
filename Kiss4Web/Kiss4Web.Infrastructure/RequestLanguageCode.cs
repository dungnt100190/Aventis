namespace Kiss4Web.Infrastructure
{
    public class RequestLanguageCode
    {
        public RequestLanguageCode(LanguageCode languageCode)
        {
            LanguageCode = languageCode;
        }

        public LanguageCode LanguageCode { get; }
    }
}