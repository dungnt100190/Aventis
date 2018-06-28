using System.Globalization;
using Kiss4Web.ErrorHandling;
using Kiss4Web.Infrastructure;
using Kiss4Web.Infrastructure.I18N.RequestLanguage;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Infrastructure.Modularity;
using SimpleInjector;

namespace Kiss4Web.Pipeline
{
    public class PipelineTypeRegistrator : ITypeRegistrator
    {
        public void RegisterTypes(Container container, ILicensedAssemblies licensedAssemblies)
        {
            container.Register<RootExceptionFilterAttribute>(Lifestyle.Singleton);
            container.Register(() => new RequestLanguage(new Language(CultureInfo.CurrentCulture.TwoLetterISOLanguageName)));
            container.Register(() => new RequestLanguageCode(container.GetInstance<ILanguageResolver>().GetRequestLanguageKiss4Code()));
            container.Register<IRootProcessRegistrator, RootProcessRegistrator>();
        }
    }
}