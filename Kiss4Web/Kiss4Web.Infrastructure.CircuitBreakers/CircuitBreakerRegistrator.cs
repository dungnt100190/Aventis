using System.Linq;
using Kiss4Web.Infrastructure.Modularity;
using SimpleInjector;

namespace Kiss4Web.Infrastructure.CircuitBreakers
{
    public class CircuitBreakerRegistrator : ITypeRegistrator
    {
        public void RegisterTypes(Container container, ILicensedAssemblies licensedAssemblies)
        {
            var circuitBreakers = licensedAssemblies.GetTypes<CircuitBreaker>().ToList();
            circuitBreakers.DoForEach(cbt => container.RegisterSingleton(cbt, cbt));
            container.RegisterCollection<CircuitBreaker>(circuitBreakers);

            container.RegisterSingleton<CircuitBreakerRegistry>();
            container.RegisterSingleton<CircuitBreakerAttributeLookup>();
        }
    }
}