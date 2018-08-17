using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml.Serialization;

namespace Kiss.Infrastructure.Utils
{
    public static class Extensions
    {
        public static T Clamp<T>(this T value, T min, T max)
            where T : IComparable<T>
        {
            if (value.CompareTo(min) < 0)
            {
                return min;
            }

            if (value.CompareTo(max) > 0)
            {
                return max;
            }

            return value;
        }

        public static IEnumerable<TSource> Except<TSource>(this IEnumerable<TSource> enumerable1, IEnumerable<TSource> enumerable2, Func<TSource, TSource, bool> comparer)
        {
            return enumerable1.Except(enumerable2, new LambdaComparer<TSource>(comparer));
        }

        public static string GetXmlEnumAttributeValueFromEnum<TEnum>(this TEnum value) where TEnum : struct, IConvertible
        {
            var enumType = typeof(TEnum);
            if (!enumType.IsEnum)
            {
                return null;
            }

            var member = enumType.GetMember(value.ToString()).FirstOrDefault();
            if (member == null)
            {
                return null;
            }

            var attribute = member.GetCustomAttributes(false).OfType<XmlEnumAttribute>().FirstOrDefault();
            if (attribute == null)
            {
                return null;
            }

            return attribute.Name;
        }

        public static bool TryGetValue<T>(this DataRow row, string fieldName, out T value)
        {
            value = default(T);

            var hasColumn = row.Table.Columns.Contains(fieldName);

            if (!hasColumn)
            {
                return false;
            }

            var valueObject = row[fieldName];

            var type = typeof(T);
            if ((valueObject == null && type.IsValueType && !(type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))) ||
                (valueObject != null && !type.IsInstanceOfType(valueObject)))
            {
                return false;
            }

            value = (T)valueObject;
            return true;
        }

        public static bool TryGetValue<T>(this Dictionary<string, Object> dictionary, string fieldName, out T value)
        {
            object valueObject;
            value = default(T);

            var result = dictionary.TryGetValue(fieldName, out valueObject);

            var type = typeof(T);
            if (!result ||
                (valueObject == null && type.IsValueType && !(type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))) ||
                (valueObject != null && !type.IsInstanceOfType(valueObject)))
            {
                return false;
            }

            value = (T)valueObject;
            return true;
        }

        public static IEnumerable<TSource> WhereIf<TSource>(
            this IEnumerable<TSource> source,
            bool condition,
            Func<TSource, bool> predicate)
        {
            if (condition)
            {
                return source.Where(predicate);
            }

            return source;
        }
    }
}