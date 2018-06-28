using System.Threading.Tasks;
using Kiss4Web.Infrastructure.Mediator;

namespace Kiss4Web.Infrastructure.I18N
{
    public class TranslationQueryHandler : TypedMessageHandler<TranslationQuery, string>
    {
        private readonly IKiss4TranslationProvider _kiss4TranslationProvider;

        public TranslationQueryHandler(IKiss4TranslationProvider kiss4TranslationProvider)
        {
            _kiss4TranslationProvider = kiss4TranslationProvider;
        }

        public override Task<string> Handle(TranslationQuery query)
        {
            return _kiss4TranslationProvider.GetText(query.MaskName, query.MessageName, query.Language);
        }
    }
}