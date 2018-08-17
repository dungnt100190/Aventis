using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;

namespace Kiss.Infrastructure
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Gets the localized string representation of the enum value
        /// </summary>
        /// <param name="value">enum item to resolve</param>
        /// <remarks>the localization has to be provided
        /// - in the assembly the enum is defiend
        /// - in the default resource file (Properties.Resources.resx)
        /// - in the format [EnumTypeName]_[EnumItemNam]
        /// e.g. DocumentFormat_Word</remarks>
        /// <returns>localized string - if found in resources</returns>
        public static string ToStringLocalized(this Enum value)
        {
            try
            {
                if (value == null)
                {
                    return null;
                }
                var enumType = value.GetType();
                var resourceFileName = string.Format("{0}.{1}", enumType.Assembly.GetName().Name, "Properties.Resources");

                var resourceManager = new ResourceManager(resourceFileName, enumType.Assembly);
                var localizedString = resourceManager.GetString(string.Format("{0}_{1}", enumType.Name, value));

                return string.IsNullOrEmpty(localizedString) ? value.ToString() : localizedString;
            }
            catch (Exception)
            {
                return value.ToString();
                // ToDo: log unsuccessful lookup for admin
            }
        }

        /// <summary>
        /// Gets a lookup dictionary enum->localized string
        /// </summary>
        /// <remarks>the localization has to be provided
        /// - in the assembly the enum is defiend
        /// - in the default resource file (Properties.Resources.resx)
        /// - in the format [EnumTypeName]_[EnumItemNam]
        /// e.g. DocumentFormat_Word</remarks>
        /// <returns>localized lookup dictionary enum->localized string - if found in resources</returns>
        public static IDictionary<TEnum, string> GetLookupDirectory<TEnum>()
        {
            var enumType = typeof(TEnum);
            if (!enumType.IsEnum)
            {
                throw new ArgumentException(string.Format("Type {0} is not an enum", enumType));
            }

            return Enum.GetValues(enumType)
                       .Cast<Enum>()
                       .ToDictionary(enm => (TEnum)Enum.Parse(enumType, enm.ToString()),
                                     enm => enm.ToStringLocalized());
        }
    }
}
