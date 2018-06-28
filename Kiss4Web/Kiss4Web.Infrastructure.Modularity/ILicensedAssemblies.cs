using System;
using System.Collections.Generic;
using System.Reflection;

namespace Kiss4Web.Infrastructure.Modularity
{
    public interface ILicensedAssemblies
    {
        IReadOnlyList<Assembly> Assemblies { get; }

        IEnumerable<T> Get<T>();

        IEnumerable<Type> GetTypes<T>();
    }
}