using System.Linq;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure.I18N.RequestLanguage;
using Kiss4Web.Model;
using Microsoft.EntityFrameworkCore;

namespace Kiss4Web.Infrastructure.I18N
{
    public class Kiss4TranslationProvider : IKiss4TranslationProvider
    {
        private readonly IQueryable<XLangText> _texts;
        private readonly IQueryable<XMessage> _messages;
        private readonly ILanguageResolver _languageResolver;

        public Kiss4TranslationProvider(IQueryable<XLangText> texts,
                                        IQueryable<XMessage> messages,
                                        ILanguageResolver languageResolver)
        {
            _texts = texts;
            _messages = messages;
            _languageResolver = languageResolver;
        }

        public async Task<string> GetText(int textId, LanguageCode? languageCode)
        {
            var languageCodeNotNullable = languageCode ?? _languageResolver.GetRequestLanguageKiss4Code();
            var texts = await _texts.Where(txt => txt.Tid == textId
                                              && (txt.LanguageCode == languageCodeNotNullable
                                               || txt.LanguageCode == LanguageCode.Deutsch))
                                    .ToListAsync();
            return texts.FirstOrDefault(txt => txt.LanguageCode == languageCodeNotNullable)?.Text ??
                   texts.First().Text; // fallback to default language
        }

        public async Task<string> GetText(string maskName, string messageName, LanguageCode? languageCode)
        {
            var message = await _messages.FirstOrDefaultAsync(msg => msg.MaskName == maskName
                                                                  && msg.MessageName == messageName);
            if (message?.MessageTid == null)
            {
                return null;
            }

            return await GetText(message.MessageTid.Value, languageCode);
        }
    }
}