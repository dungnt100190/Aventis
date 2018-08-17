using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Kiss.Infrastructure.Utils
{
    public class Utils
    {
        /// <summary>
        /// Money Rounding: smallesUnit e.q. 0.10 for roundings to 1 decimal
        /// </summary>
        /// <param name="value">Value to round</param>
        /// <param name="smallestUnit">smallest unit used for rounding</param>
        /// <returns>Rounded Value</returns>
        public static Decimal RoundMoney(Decimal value, Decimal smallestUnit)
        {
            if (smallestUnit == 0)
            {
                return Math.Round(value, MidpointRounding.AwayFromZero);
            }
            else
            {
                return Math.Round(value / smallestUnit, MidpointRounding.AwayFromZero) * smallestUnit;
            }
        }

        /// <summary>
        /// Defaul Money Rounding for Switzerland
        /// </summary>
        /// <param name="value">Value to round</param>
        /// <returns>Rounded Value</returns>
        public static Decimal RoundMoney_CH(Decimal value)
        {
            return RoundMoney(value, (Decimal)0.05);
        }

        /// <summary>
        /// Money Rounding allways rounding up to the next unit
        /// </summary>
        /// <param name="value">Value to round</param>
        /// <param name="smallestUnit">smallest unit used for rounding</param>
        /// <returns>Rounded Value</returns>
        public static Decimal RoundMoney_Up(Decimal value, Decimal smallestUnit)
        {
            Decimal Rounded = RoundMoney(value, smallestUnit);

            if (value > Rounded)
            {
                Rounded += smallestUnit;
            }

            return Rounded;
        }

        /// <summary>
        /// Serializes an object as an XML string.
        /// </summary>
        /// <param name="myObject">Object to be treated.</param>
        /// <returns>XML string.</returns>
        public static string SerializeObjectAsXml<T>(T myObject)
        {
            var serializer = new XmlSerializer(typeof(T));
            var stringBuilder = new StringBuilder();
            var stream = new StringWriter(stringBuilder);
            serializer.Serialize(stream, myObject);
            return stringBuilder.ToString();
        }

        public static bool TryConvertCodeToEnumMember<T>(int? code, out T enumValue)
        {
            // code is null
            // code is not defined in the enum
            if (!code.HasValue || !Enum.IsDefined(typeof(T), code.Value))
            {
                enumValue = default(T);
                return false;
            }

            // cast code to enum
            enumValue = (T)Enum.ToObject(typeof(T), code.Value);
            return true;
        }
    }
}