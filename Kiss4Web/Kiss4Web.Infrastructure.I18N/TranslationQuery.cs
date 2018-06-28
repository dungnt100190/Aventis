using Kiss4Web.Infrastructure.Mediator;

namespace Kiss4Web.Infrastructure.I18N
{
    public class TranslationQuery : Message<string>
    {
        public string MaskName { get; set; }
        public string MessageName { get; set; }
        public LanguageCode? Language { get; set; }
    }
}