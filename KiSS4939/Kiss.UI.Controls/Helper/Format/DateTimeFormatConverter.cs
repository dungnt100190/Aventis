using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;

namespace Kiss.UI.Controls.Helper.Format
{
    /// <summary>
    /// Converter for DateTime format strings.
    /// </summary>
    public class DateTimeFormatConverter
    {
        #region Fields

        #region Public Constant/Read-Only Fields

        /// <summary>
        /// Gets the <see cref="DateTimeFormatInfo"/> in use.
        /// </summary>
        public readonly DateTimeFormatInfo Provider;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initialize with the <see cref="DateTimeFormatInfo"/> used by the current thread.
        /// </summary>
        public DateTimeFormatConverter()
            : this(DateTimeFormatInfo.CurrentInfo)
        {
        }

        /// <summary>
        /// Initialize with a <see cref="DateTimeFormatInfo"/>.
        /// </summary>
        public DateTimeFormatConverter(DateTimeFormatInfo provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException("provider");
            }

            Provider = provider;
        }

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// true if format is a standard DateTime format.
        /// </summary>
        /// <remarks>a null string or an empty string are considered the standard format "G".</remarks>
        public static bool IsStandardFormat(string format)
        {
            return format == null || format.Length <= 1;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Parse format and return it's elements.
        /// </summary>
        /// <remarks>
        /// Strings returned will match the following patterns:
        ///		d{1,4}
        ///		f{1,7}
        ///		g{1,2}
        ///		h{1,2}
        ///		H{1,2}
        ///		m{1,2}
        ///		M{1,4}
        ///		s{1,2}
        ///		t{1,2}
        ///		y+
        ///		z{1,3}
        ///		/
        ///		:
        ///		'.+
        ///	Literal strings start with (but are not enclose in) an apostrophe. No two such consecutive strings are returned.
        /// </remarks>
        public string[] Parse(string format)
        {
            format = ToCustomFormat(format);
            Debug.Assert(format.Length > 0);

            var retAl = new ArrayList();
            var index = 0;

            while (index < format.Length)
            {
                string ele;

                if ((ele = ParsePlaceholder(format, ref index)) != null)
                {
                    retAl.Add(ele);
                }
                else if ((ele = ParseSeparator(format, ref index, Provider)) != null)
                {
                    retAl.Add(ele);
                }
                else if ((ele = ParseLiteral(format, ref index)) != null)
                {
                    if (retAl.Count > 0)
                    {
                        var lit = (string)retAl[retAl.Count - 1] + ele;

                        if (lit[0] == '\'')
                        {
                            retAl[retAl.Count - 1] = lit + ele;
                        }
                        else
                        {
                            retAl.Add("'" + ele);
                        }
                    }
                    else
                    {
                        retAl.Add("'" + ele);
                    }
                }
                else
                {
                    throw new FormatException("Input string contains invalid format.");
                }
            }

            return (string[])retAl.ToArray(typeof(string));
        }

        /// <summary>
        /// Convert a DateTime format string to an equivalent custom DateTime format string.
        /// </summary>
        /// <returns>A custom DateTime format string cfs so that x.ToString(format, provider)==x.ToString(cfs, provider).</returns>
        /// <exception cref="FormatException">format is a standard DateTime format string, but contains an invalid format character.</exception>
        /// <exception cref="ArgumentException">format is "R", "r", "s" or "u", and provider is not the invariant <see cref="DateTimeFormatInfo"/>.</exception>
        /// <exception cref="ArgumentException">format is "U", which has no equivalent custom format string.</exception>
        public string ToCustomFormat(string format)
        {
            if (string.IsNullOrEmpty(format)) // use the general format
            {
                format = "G";
            }

            string ret;

            if (format.Length == 1) // standard date time format string
            {
                var ch = format[0];

                switch (ch)
                {
                    case 'd':
                        ret = Provider.ShortDatePattern;
                        break;

                    case 'D':
                        ret = Provider.LongDatePattern;
                        break;

                    case 't':
                        ret = Provider.ShortTimePattern;
                        break;

                    case 'T':
                        ret = Provider.LongTimePattern;
                        break;

                    case 'f':
                        ret = Provider.LongDatePattern + " " + Provider.ShortTimePattern;
                        break;

                    case 'F':
                        ret = Provider.FullDateTimePattern;
                        break;

                    case 'g':
                        ret = Provider.ShortDatePattern + " " + Provider.ShortTimePattern;
                        break;

                    case 'G':
                        ret = Provider.ShortDatePattern + " " + Provider.LongTimePattern;
                        break;

                    case 'M':
                    case 'm':
                        ret = Provider.MonthDayPattern;
                        break;

                    case 'R':
                    case 'r':
                        if (Provider != DateTimeFormatInfo.InvariantInfo)
                        {
                            throw new ArgumentException("r format only valid for invariant DateTimeFormatInfo");
                        }

                        ret = Provider.RFC1123Pattern;
                        break;

                    case 's':
                        if (Provider != DateTimeFormatInfo.InvariantInfo)
                        {
                            throw new ArgumentException("s format only valid for invariant DateTimeFormatInfo");
                        }

                        ret = DateTimeFormatInfo.InvariantInfo.SortableDateTimePattern;
                        break;

                    case 'u':
                        if (Provider != DateTimeFormatInfo.InvariantInfo)
                        {
                            throw new ArgumentException("u format only valid for invariant DateTimeFormatInfo");
                        }

                        ret = DateTimeFormatInfo.InvariantInfo.UniversalSortableDateTimePattern;
                        break;

                    case 'U':
                        throw new ArgumentException("'U' cannot be converted to a custom DateTime format string.", "format");

                    case 'Y':
                    case 'y':
                        ret = Provider.YearMonthPattern;
                        break;

                    default:
                        throw new FormatException(string.Format("'{0}' is an invalid standard DateTime format character.", ch));
                }

                if (ret.Length == 1) // still a standard format
                {
                    ret = "%" + ret;
                }
            }
            else // already a custom format string
            {
                ret = format;
            }

            return ret;
        }

        #endregion

        #region Private Static Methods

        private static string ParseLiteral(string format, ref int index)
        {
            if (index >= format.Length)
            {
                return null;
            }

            var ix = index;
            var ch = format[ix++];

            string ret;

            switch (ch)
            {
                case '\'':
                case '"':
                    while (true)
                    {
                        if (ix >= format.Length)
                        {
                            throw new FormatException("No matching " + ch + " found.");
                        }

                        var ch1 = format[ix++];

                        if (ch1 == ch)
                        {
                            ret = format.Substring(index + 1, ix - index - 2);
                            index = ix;
                            break;
                        }
                    }

                    break;

                case '\\':
                    if (ix >= format.Length)
                    {
                        return null;
                    }

                    ch = format[ix++];
                    ret = ch.ToString();
                    index = ix;
                    break;

                default:
                    if (ch == '%')
                    {
                        if (ix >= format.Length)
                        {
                            return null;
                        }

                        ch = format[ix++];
                    }

                    if ("%\\\"'".IndexOf(ch) >= 0)
                    {
                        return null;
                    }

                    ret = ch.ToString();
                    index = ix;
                    break;
            }

            return ret;
        }

        private static string ParsePlaceholder(string format, ref int index)
        {
            if (index >= format.Length)
            {
                return null;
            }

            var ix = index;
            var ch = format[ix++];

            if (ch == '%')
            {
                if (ix < format.Length)
                {
                    ch = format[ix++];
                }
                else
                {
                    return null;
                }
            }

            int max;

            switch (ch)
            {
                case 'd':
                case 'M':
                    max = 4;
                    break;

                case 'f':
                    max = 7;
                    break;

                case 'g':
                case 'h':
                case 'H':
                case 'm':
                case 's':
                case 't':
                    max = 2;
                    break;

                case 'y':
                    max = int.MaxValue;
                    break;

                case 'z':
                    max = 3;
                    break;

                default:
                    return null;
            }

            var count = 1;
            index = ix;

            while (true)
            {
                if (ix >= format.Length)
                {
                    break;
                }

                var ch1 = format[ix++];

                if (ch1 == '%')
                {
                    continue;
                }

                if (ch1 != ch)
                {
                    break;
                }

                count++;
                index = ix;
            }

            if (count > max)
            {
                if (ch == 'f')
                {
                    throw new FormatException("Too many 'f's.");
                }

                count = max;
            }

            return new string(ch, count);
        }

        private static string ParseSeparator(string format, ref int index, DateTimeFormatInfo provider)
        {
            if (index >= format.Length)
            {
                return null;
            }

            const char stDSep = '/';
            const char stTSep = ':';
            var prDSep = provider.DateSeparator;
            var prTSep = provider.TimeSeparator;
            string ret = null;

            var sub = format.Substring(index);

            if (sub.StartsWith(prDSep))
            {
                ret = stDSep.ToString();
                index += prDSep.Length;
            }
            else if (sub.StartsWith(prTSep))
            {
                ret = stTSep.ToString();
                index += prTSep.Length;
            }
            else
            {
                switch (format[index])
                {
                    case stDSep:
                        ret = stDSep.ToString();
                        index++;
                        break;

                    case stTSep:
                        ret = stTSep.ToString();
                        index++;
                        break;
                }
            }

            return ret;
        }

        #endregion

        #endregion
    }
}