using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Kiss4Web.Infrastructure.Modularity
{
    public class Kiss4WebAssemblies : IKiss4WebAssemblies
    {
        public Kiss4WebAssemblies()
        {
            AssemblyNames = Enum.GetValues(typeof(KissModul)).OfType<KissModul>()
                            .Select(mod => mod.GetAttribute<ModuleAttribute, KissModul>()?.ModuleName ?? $"Kiss4Web.Modules.{mod}")
                            .Append("Kiss4Web.Infrastructure.Authentication")
                            .Append("Kiss4Web.Infrastructure.Authorization")
                            .Append("Kiss4Web.Infrastructure.CircuitBreakers")
                            //.Append("Kiss4Web.Infrastructure.Configuration")
                            .Append("Kiss4Web.Infrastructure.Reporting")
                            .Append("Kiss4Web.Infrastructure.Crud")
                            .Append("Kiss4Web.Infrastructure.DataAccess")
                            .Append("Kiss4Web.Infrastructure.DocumentCreation")
                            .Append("Kiss4Web.Infrastructure.ErrorHandling")
                            .Append("Kiss4Web.Infrastructure.I18N")
                            .Append("Kiss4Web.Infrastructure.Kiss4Configuration")
                            .Append("Kiss4Web.Infrastructure.Mediator")
                            .Append("Kiss4Web.Infrastructure.Messaging")
                            .Append("Kiss4Web.Infrastructure.Modularity")
                            .Append("Kiss4Web")
                            .Select(asn => new AssemblyName(asn))
                            .ToList();
        }

        public IEnumerable<AssemblyName> AssemblyNames { get; }
    }
}