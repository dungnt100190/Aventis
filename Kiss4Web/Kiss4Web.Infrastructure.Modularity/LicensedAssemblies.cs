using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Kiss4Web.Infrastructure.Modularity
{
    public class LicensedAssemblies : ILicensedAssemblies
    {
        private readonly LicensedTypes _licensedTypes;

        public LicensedAssemblies(LicensedTypes licensedTypes)
        {
            _licensedTypes = licensedTypes;
        }

        public IReadOnlyList<Assembly> Assemblies => _licensedTypes.Assemblies;

        public IEnumerable<T> Get<T>()
        {
            return GetTypes<T>().Select(Activator.CreateInstance).OfType<T>().ToList();
        }

        public IEnumerable<Type> GetTypes<T>()
        {
            return _licensedTypes.GetTypesImplementing<T>().ToList();
        }
    }
}