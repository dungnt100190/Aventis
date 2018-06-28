using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Kiss4Web.Infrastructure.Modularity.Licensing;

namespace Kiss4Web.Infrastructure.Modularity
{
    public class LicensedTypes
    {
        public LicensedTypes(ILicenseReader licenseReader, IKiss4WebAssemblies kiss4WebAssemblies)
        {
            Modules = licenseReader.GetLicensedModules().ToList();
            var licensedModuleName = Modules
                                     .Select(mod => mod.GetAttribute<ModuleAttribute, KissModul>()?.ModuleName ?? $"Kiss4Web.Modules.{mod}")
                                     .ToList();
            var assemblyNames = kiss4WebAssemblies.AssemblyNames
                                                 .Where(asn => licensedModuleName.Contains(asn.Name)
                                                            || asn.Name.StartsWith("Kiss4Web.Infrastructure.")
                                                            || asn.Name == "Kiss4Web")
                                                 .ToList();
            var licensedAssemblies = assemblyNames.Select(LoadAssembly).Where(asm => asm != null).ToList();

            Types = licensedAssemblies.SelectMany(ass => ass.ExportedTypes).ToList();
            Assemblies = licensedAssemblies;
        }

        public IReadOnlyList<Assembly> Assemblies { get; }
        public IReadOnlyList<KissModul> Modules { get; set; }
        public IReadOnlyList<Type> Types { get; }

        public static IEnumerable<Type> DerivedOfType<TDerived>(IEnumerable<Type> source)
        {
            return source.Where(type => typeof(TDerived).IsAssignableFrom(type))
                         .Where(type => type != typeof(TDerived))
                         .Where(type => !type.GetTypeInfo().IsInterface)
                         .Where(type => !type.GetTypeInfo().IsAbstract)
                         .Where(type => !type.GetTypeInfo().IsGenericTypeDefinition)
                         .Select(type => type)
                         .ToList();
        }

        public IEnumerable<Type> GetTypesImplementing<T>()
        {
            return DerivedOfType<T>(Types);
        }

        private static Assembly LoadAssembly(AssemblyName assemblyName)
        {
            try
            {
                return Assembly.Load(assemblyName);
            }
            catch
            {
                // ignored
            }
            return null;
        }
    }
}