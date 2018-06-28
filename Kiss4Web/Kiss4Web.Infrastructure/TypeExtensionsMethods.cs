using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Kiss4Web.Infrastructure
{
    public static class TypeExtensionsMethods
    {
        /// <summary>
        /// Gets all fields of a type and recursively of the base type
        /// </summary>
        /// <param name="type"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        public static IEnumerable<FieldInfo> GetAllFields(this Type type, BindingFlags flags)
        {
            if (type == null)
            {
                return Enumerable.Empty<FieldInfo>();
            }

            var fieldInfos = type.GetFields(flags);

            if (type.GetTypeInfo().BaseType == null)
            {
                return fieldInfos;
            }

            return fieldInfos.Concat(type.GetTypeInfo().BaseType.GetAllFields(flags));
        }

        public static PropertyInfo GetReportProperty(this Type type, string part)
        {
            var property = type.GetProperty(part, BindingFlags.DeclaredOnly |
                                                  BindingFlags.Public |
                                                  BindingFlags.Instance);
            // überschriebene Properties zuerst, z.B. FalBeteiligtReportEntity.SysUser
            if (property == null)
            {
                property = type.GetProperty(part);
            }
            return property;
        }

        public static TypeName GetTypeName(this Type type)
        {
            return new TypeName(type.ToString());
        }

        public static bool HasAttribute<TAttribute>(this Type type)
            where TAttribute : Attribute
        {
            return type.GetTypeInfo().GetCustomAttributes<TAttribute>().Any();
        }

        public static bool ImplementsInterface<TInterface>(this Type type)
        {
            return typeof(TInterface).IsAssignableFrom(type);
        }

        public static bool ImplementsInterface(this Type type, Type genericType)
        {
            return type.GetInterfaces().Any(i => i == genericType ||
                                                 i.IsConstructedGenericType &&
                                                 i.GetGenericTypeDefinition() == genericType);
        }

        public static bool IsDerivedOfType<TBase>(this Type type)
        {
            return typeof(TBase).IsAssignableFrom(type) &&
                   type != typeof(TBase) &&
                   !type.GetTypeInfo().IsInterface &&
                   !type.GetTypeInfo().IsAbstract &&
                   !type.GetTypeInfo().IsGenericTypeDefinition;
        }

        public static bool IsNullable(this Type type)
        {
            return type != null &&
                   (type.GetTypeInfo().IsClass ||
                    type == typeof(string) ||
                    type.IsConstructedGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        public static bool IsPrimitiveType(this Type type)
        {
            return type.GetTypeInfo().IsPrimitive ||
                   type.GetTypeInfo().IsEnum ||
                   type == typeof(decimal) ||
                   type == typeof(string) ||
                   type == typeof(DateTime) ||
                   type == typeof(byte[]) ||
                   type.IsConstructedGenericType &&
                   type.GetGenericTypeDefinition() == typeof(Nullable<>) &&
                   type.GenericTypeArguments[0].IsPrimitiveType();
        }
    }
}