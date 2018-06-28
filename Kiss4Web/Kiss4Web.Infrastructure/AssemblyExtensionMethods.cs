using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Kiss4Web.Infrastructure
{
    public static class AssemblyExtensionMethods
    {
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

        public static IEnumerable<TDerived> GetInstances<TDerived>(this Assembly assembly)
        {
            return assembly.GetTypesImplementing<TDerived>().Select(Activator.CreateInstance).OfType<TDerived>();
        }

        public static IEnumerable<TDerived> GetInstances<TDerived>(this IEnumerable<Assembly> assemblies)
        {
            return assemblies.SelectMany(GetInstances<TDerived>);
        }

        public static string GetModuleName(this Assembly assembly)
        {
            return assembly.GetName().Name?.Split('.').Skip(1).FirstOrDefault()?.ToLowerInvariant();
        }

        public static IEnumerable<Type> GetTypesImplementing<TDerived>(this Assembly assembly)
        {
            return DerivedOfType<TDerived>(assembly.GetTypes());
        }

        public static IEnumerable<Type> GetTypesImplementing<TDerived>(this IEnumerable<Assembly> assemblies)
        {
            return assemblies.SelectMany(GetTypesImplementing<TDerived>);
        }
    }
}