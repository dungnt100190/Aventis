using System;

namespace Kiss4Web.Infrastructure.Configuration
{
    public class LanguageAttribute : Attribute
    {
        public LanguageAttribute(string language)
        {
            Language = new Language(language);
        }

        public Language Language { get; set; }
    }
}