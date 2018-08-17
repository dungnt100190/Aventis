using System.Text.RegularExpressions;

namespace Kiss.Infrastructure.Utils
{
    public static class StringExtensions
    {
        public static string RemoveNewLines(this string value)
        {
            if (value == null)
                return null;

            return Regex.Replace(value, @"\r\n", " ");
        }

        public static string RemoveSpaces(this string value)
        {
            if (value == null)
                return null;

            return Regex.Replace(value, @" ", "");
        }

        public static string RemoveWhitespaces(this string value)
        {
            if (value == null)
                return null;

            return Regex.Replace(value, @"\s+", "");
        }

        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value) || value.Length <= maxLength)
            {
                return value;
            }

            return value.Substring(0, maxLength);
        }
    }
}