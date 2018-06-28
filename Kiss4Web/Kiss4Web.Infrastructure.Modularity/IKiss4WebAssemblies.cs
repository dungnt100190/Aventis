using System.Collections.Generic;
using System.Reflection;

namespace Kiss4Web.Infrastructure.Modularity
{
    public interface IKiss4WebAssemblies
    {
        IEnumerable<AssemblyName> AssemblyNames { get; }
    }
}