using System.Threading.Tasks;
using Kiss4Web.Infrastructure.Mediator;

namespace Kiss4Web.Infrastructure.I18N
{
    public class TranslationByIdQueryHandler : TypedMessageHandler<TranslationByIdQuery, string>
    {
        private readonly IKiss4TranslationProvider _kiss4TranslationProvider;

        public TranslationByIdQueryHandler(IKiss4TranslationProvider kiss4TranslationProvider)
        {
            _kiss4TranslationProvider = kiss4TranslationProvider;
        }

        public override Task<string> Handle(TranslationByIdQuery query)
        {
            return _kiss4TranslationProvider.GetText(query.TextId, query.Language);
        }
    }
}