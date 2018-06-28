using Kiss4Web.Infrastructure.Mediator;

namespace Kiss4Web.Infrastructure.I18N
{
    public class TranslationByIdQuery : Message<string>
    {
        public int TextId { get; set; }
        public LanguageCode? Language { get; set; }
    }
}