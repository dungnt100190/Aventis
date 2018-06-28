using System.Globalization;

namespace Kiss4Web.Infrastructure.I18N.RequestLanguage
{
    public class LanguageResolver : ILanguageResolver
    {
        public static Language DefaultLanguage { get; } = Language.Deutsch;

        public Language GetRequestLanguage()
        {
            var languageString = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            if (string.IsNullOrEmpty(languageString))
            {
                languageString = DefaultLanguage;
            }
            return new Language(languageString);
        }

        public LanguageCode GetRequestLanguageKiss4Code()
        {
            var language = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            switch (language)
            {
                case Languages.Deutsch:
                    return LanguageCode.Deutsch;

                case Languages.Français:
                    return LanguageCode.Français;

                case Languages.Italiano:
                    return LanguageCode.Italiano;

                default:
                    return LanguageCode.Deutsch;
            }
        }

        public string GetRequestLanguageString()
        {
            return GetRequestLanguage().ToString();
        }
    }
}