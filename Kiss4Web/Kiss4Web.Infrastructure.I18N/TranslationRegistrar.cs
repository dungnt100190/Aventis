using Kiss4Web.Infrastructure.I18N.RequestLanguage;
using Kiss4Web.Infrastructure.Modularity;
using SimpleInjector;

namespace Kiss4Web.Infrastructure.I18N
{
    public class TranslationRegistrar : ITypeRegistrator
    {
        public void RegisterTypes(Container container, ILicensedAssemblies licensedAssemblies)
        {
            container.Register<IKiss4TranslationProvider, Kiss4TranslationProvider>();
            container.RegisterDecorator<IKiss4TranslationProvider, Kiss4TranslationCache>();

            container.Register<ILanguageResolver, LanguageResolver>();
        }
    }
}