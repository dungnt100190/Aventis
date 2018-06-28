using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Infrastructure.Modularity;
using SimpleInjector;

namespace Kiss4Web.Infrastructure.Crud
{
    public class CrudTypeRegistrar : ITypeRegistrator
    {
        public void RegisterTypes(Container container, ILicensedAssemblies licensedAssemblies)
        {
            container.RegisterConditional(typeof(TypedMessageHandler<>), typeof(SaveCommandHandler<>), c => !c.Handled);
        }
    }
}