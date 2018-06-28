using System.Threading.Tasks;

namespace Kiss4Web.Infrastructure.I18N
{
    public interface IKiss4TranslationProvider
    {
        Task<string> GetText(int textId, LanguageCode? languageCode = null);

        Task<string> GetText(string maskName, string messageName, LanguageCode? languageCode = null);
    }
}