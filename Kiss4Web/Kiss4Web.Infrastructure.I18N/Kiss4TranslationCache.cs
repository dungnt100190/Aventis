using System;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure.I18N.RequestLanguage;
using Microsoft.Extensions.Caching.Memory;

namespace Kiss4Web.Infrastructure.I18N
{
    public class Kiss4TranslationCache : IKiss4TranslationProvider
    {
        private readonly IKiss4TranslationProvider _decoratee;
        private readonly IMemoryCache _cache;
        private readonly ILanguageResolver _languageResolver;
        private readonly TimeSpan _slidingExpiration = new TimeSpan(1, 0, 0, 0);

        public Kiss4TranslationCache(IKiss4TranslationProvider decoratee, IMemoryCache cache, ILanguageResolver languageResolver)
        {
            _decoratee = decoratee;
            _cache = cache;
            _languageResolver = languageResolver;
        }

        public async Task<string> GetText(int textId, LanguageCode? languageCode)
        {
            var key = new TranslationIdKey(textId, languageCode ?? _languageResolver.GetRequestLanguageKiss4Code());
            return await _cache.GetOrCreateAsync(key, entry =>
            {
                entry.SlidingExpiration = _slidingExpiration;
                return _decoratee.GetText(textId, languageCode);
            });
        }

        public async Task<string> GetText(string maskName, string messageName, LanguageCode? languageCode)
        {
            var key = new TranslationKey(maskName, messageName, languageCode ?? _languageResolver.GetRequestLanguageKiss4Code());
            return await _cache.GetOrCreateAsync(key, entry =>
            {
                entry.SlidingExpiration = _slidingExpiration;
                return _decoratee.GetText(maskName, messageName, languageCode);
            });
        }
    }
}