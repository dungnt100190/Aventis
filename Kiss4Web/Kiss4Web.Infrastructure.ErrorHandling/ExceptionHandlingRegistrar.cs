using Kiss4Web.Infrastructure.Modularity;
using SimpleInjector;

namespace Kiss4Web.Infrastructure.ErrorHandling
{
    public class ExceptionHandlingRegistrar : ITypeRegistrator
    {
        public void RegisterTypes(Container container, ILicensedAssemblies licensedAssemblies)
        {
            container.Register<IExceptionTranslator, ExceptionTranslator>(Lifestyle.Singleton);
            container.RegisterCollection<IExceptionTranslation>(licensedAssemblies.GetTypes<IExceptionTranslation>());

            container.RegisterSingleton<ExceptionSerializer>();

            container.Register<IWarningsCollector, WarningsCollector>();
        }
    }
}