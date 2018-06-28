namespace Kiss4Web.Infrastructure.I18N.RequestLanguage
{
    public interface ILanguageResolver
    {
        Language GetRequestLanguage();

        LanguageCode GetRequestLanguageKiss4Code();

        string GetRequestLanguageString();
    }
}