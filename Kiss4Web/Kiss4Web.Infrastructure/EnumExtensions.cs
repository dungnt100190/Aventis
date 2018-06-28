using System;
using System.Collections.Generic;
using System.Linq;

namespace Kiss4Web.Infrastructure
{
    public static class EnumExtensions
    {
        public static T GetAttribute<T, TEnum>(this TEnum enumValue) where T : Attribute
        {
            var memberInfo = enumValue.GetType()
                .GetMember(enumValue.ToString())
                .FirstOrDefault();

            var attribute = (T)memberInfo?.GetCustomAttributes(typeof(T), false).FirstOrDefault();
            return attribute;
        }

        public static IDictionary<int, string> GetIntLookupDirectoryTypeless(Type enumType)
        {
            return Enum.GetValues(enumType)
                .Cast<Enum>()
                //.ToDictionary(enm => (int)Enum.Parse(enumType, enm.ToString()), enm => enm.ToStringLocalized())
                .ToDictionary(enm => (int)Enum.Parse(enumType, enm.ToString()), enm => enm.ToString()) // ToDo: I18N ToStringLocalized
                .OrderBy(x => x.Key)
                .ToDictionary(enm => enm.Key, enm => enm.Value);
        }

        public static IDictionary<Enum, string> GetLookupDirectoryTypeless(Type enumType)
        {
            return Enum.GetValues(enumType).Cast<Enum>().ToDictionary(enm => (Enum)Enum.Parse(enumType, enm.ToString()), enm => enm.ToString()).OrderBy(x => x.Key).ToDictionary(enm => enm.Key, enm => enm.Value);
            // ToDo: I18N
            //return Enum.GetValues(enumType).Cast<Enum>().ToDictionary(enm => (Enum)Enum.Parse(enumType, enm.ToString()), enm => enm.ToStringLocalized()).OrderBy(x => x.Key).ToDictionary(enm => enm.Key, enm => enm.Value);
        }
    }
}