using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Kiss.UI.Controls.Helper.Format
{
    /// <summary>
    /// Converter for number format strings.
    /// </summary>
    public class NumberFormatConverter
    {
        #region Enumerations

        private enum NumberFormatType
        {
            Number,
            Currency,
            Percent
        }

        #endregion

        #region Fields

        #region Public Constant/Read-Only Fields

        /// <summary>
        /// Gets the <see cref="NumberFormatInfo"/> in use.
        /// </summary>
        public readonly NumberFormatInfo Provider;

        #endregion

        #region Private Static Fields

        private static readonly Regex _rgxStandardNumericFormat = new Regex(@"[A-Za-z][0-9]{0,2}");

        #endregion

        #region Private Constant/Read-Only Fields

        private readonly string[] _symbolsProvider;

        private const string SYMBOLS = ".,%;+-";

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initialize with the <see cref="NumberFormatInfo"/> used by the current thread.
        /// </summary>
        public NumberFormatConverter()
            : this(NumberFormatInfo.CurrentInfo)
        {
        }

        /// <summary>
        /// Initialize with a <see cref="NumberFormatInfo"/>.
        /// </summary>
        public NumberFormatConverter(NumberFormatInfo provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException("provider");
            }

            Provider = provider;

            _symbolsProvider = new string[SYMBOLS.Length];

            for (var i = 0; i < SYMBOLS.Length; i++)
            {
                string symbolProvider;

                switch (SYMBOLS[i])
                {
                    case '.':
                        symbolProvider = provider.NumberDecimalSeparator;
                        break;

                    case ',':
                        symbolProvider = provider.NumberGroupSeparator;
                        break;

                    case '%':
                        symbolProvider = provider.PercentSymbol;
                        break;

                    case ';':
                        symbolProvider = null;
                        break;

                    case '+':
                        symbolProvider = provider.PositiveSign;
                        break;

                    case '-':
                        symbolProvider = provider.NegativeSign;
                        break;

                    default:
                        throw new ApplicationException("Internal error.");
                }

                if (symbolProvider != null && symbolProvider.Length == 1 && symbolProvider[0] == SYMBOLS[i])
                {
                    symbolProvider = null;
                }

                _symbolsProvider[i] = symbolProvider;
            }
        }

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// true if format is a standard number format.
        /// </summary>
        /// <remarks>a null string or an empty string are considered the standard format "G".</remarks>
        public static bool IsStandardFormat(string format)
        {
            bool ret;

            if (string.IsNullOrEmpty(format))
            {
                ret = true;
            }
            else
            {
                var m = _rgxStandardNumericFormat.Match(format);
                ret = m.Success && m.Length == format.Length;
            }

            return ret;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Parse format and return it's elements.
        /// </summary>
        /// <remarks>
        /// Strings returned will match the following patterns:
        ///     0+
        ///     #+
        ///     .
        ///     ,
        ///     %
        ///     ;
        ///     +
        ///     -
        ///     (E|e)(+|-)?0+
        ///     '.+
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
                else if ((ele = ParseSymbol(format, ref index)) != null)
                {
                    retAl.Add(ele);
                }
                else if ((ele = ParseExponent(format, ref index)) != null)
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
        /// Convert a numeric format string to an equivalent custom numeric format string.
        /// </summary>
        /// <returns>A custom numeric format string cfs so that x.ToString(format, provider)==x.ToString(cfs, provider).</returns>
        /// <exception cref="ArgumentException">Formats "G", "g", "R", "r", "X", "x" cannot be converted to custom format strings.</exception>
        /// <exception cref="FormatException">format is a standard numeric format string, but contains an invalid format character.</exception>
        /// <exception cref="FormatException">Currency and Percent decimal separator must match NumberDecimalSeparator if used.</exception>
        /// <exception cref="FormatException">Currency and Percent group separator must match NumberGroupSeparator if used.</exception>
        /// <exception cref="FormatException">Group sizes must be exactly 0 or exactly 3.</exception>
        /// <exception cref="FormatException">One of the xxxPatterns is not recognized.</exception>
        public string ToCustomFormat(string format)
        {
            bool isStandard;
            char ch;
            int prec;

            if (string.IsNullOrEmpty(format))
            {
                isStandard = true;
                ch = 'G';
                prec = -1;
            }
            else
            {
                var m = _rgxStandardNumericFormat.Match(format);

                if (m.Success && m.Length == format.Length) // standard format string
                {
                    isStandard = true;
                    ch = format[0];

                    if (format.Length > 1)
                    {
                        prec = int.Parse(format.Substring(1));
                    }
                    else
                    {
                        prec = -1;
                    }
                }
                else
                {
                    isStandard = false;
                    ch = (char)0;
                    prec = -1;
                }
            }

            string ret;

            if (isStandard)
            {
                string pos; // positive format string
                string neg; // negative format string - or null

                switch (ch)
                {
                    case 'C':
                    case 'c':

                        #region currency

                        {
                            var n = ToCustomFormatN(prec, NumberFormatType.Currency);

                            switch (Provider.CurrencyPositivePattern)
                            {
                                case 0:
                                    pos = "'{0}'{1}";
                                    break;

                                case 1:
                                    pos = "{1}'{0}'";
                                    break;

                                case 2:
                                    pos = "'{0} '{1}";
                                    break;

                                case 3:
                                    pos = "{1}' {0}'";
                                    break;

                                default:
                                    throw new FormatException("Unknown CurrencyPositivePattern.");
                            }

                            pos = string.Format(pos, Provider.CurrencySymbol, n);

                            switch (Provider.CurrencyNegativePattern)
                            {
                                case 0:
                                    neg = "'({0}'{1}')'";
                                    break;

                                case 1:
                                    neg = "{2}'{0}'{1}";
                                    break;

                                case 2:
                                    neg = "'{0}'{2}{1}";
                                    break;

                                case 3:
                                    neg = "'{0}'{1}{2}";
                                    break;

                                case 4:
                                    neg = "'('{1}'{0})'";
                                    break;

                                case 5:
                                    neg = "{2}{1}'{0}'";
                                    break;

                                case 6:
                                    neg = "{1}{2}'{0}'";
                                    break;

                                case 7:
                                    neg = "{1}'{0}'{2}";
                                    break;

                                case 8:
                                    neg = "{2}{1}' {0}'";
                                    break;

                                case 9:
                                    neg = "{2}'{0} '{1}";
                                    break;

                                case 10:
                                    neg = "{1}' {0}'{2}";
                                    break;

                                case 11:
                                    neg = "'{0} '{1}{2}";
                                    break;

                                case 12:
                                    neg = "'{0} '{2}{1}";
                                    break;

                                case 13:
                                    neg = "{1}{2}' {0}'";
                                    break;

                                case 14:
                                    neg = "'({0} '{1}')'";
                                    break;

                                case 15:
                                    neg = "'('{1}' {0})'";
                                    break;

                                default:
                                    throw new FormatException("Unknown CurrencyNegativePattern.");
                            }

                            neg = string.Format(neg, Provider.CurrencySymbol, n, Provider.NegativeSign);
                        }

                        #endregion

                        break;

                    case 'D':
                    case 'd':

                        #region decimal

                        {
                            pos = new string('0', Math.Max(1, prec));
                            neg = null;
                        }

                        #endregion

                        break;

                    case 'E':
                    case 'e':

                        #region scientific

                        {
                            if (prec == -1)
                            {
                                prec = 6;
                            }

                            if (prec == 0)
                            {
                                pos = "0" + ch + "+000";
                            }
                            else
                            {
                                pos = "0." + new string('0', prec) + ch + "+000";
                            }

                            neg = null;
                        }

                        #endregion

                        break;

                    case 'F':
                    case 'f':

                        #region fixed-point

                        {
                            if (prec == -1)
                            {
                                prec = Provider.PercentDecimalDigits;
                            }

                            if (prec == 0)
                            {
                                pos = "0";
                            }
                            else
                            {
                                pos = "0." + new string('0', prec);
                            }

                            neg = null;
                        }

                        #endregion

                        break;

                    case 'G':
                    case 'g':
                        throw new ArgumentException("'G' and 'g' formats are not supported.");

                    case 'N':
                    case 'n':

                        #region number

                        {
                            pos = ToCustomFormatN(prec, NumberFormatType.Number);

                            switch (Provider.NumberNegativePattern)
                            {
                                case 0:
                                    neg = "'('{0}')'";
                                    break;

                                case 1:
                                    neg = null;
                                    break;

                                case 2:
                                    neg = "{1} {0}";
                                    break;

                                case 3:
                                    neg = "{0}{1}";
                                    break;

                                case 4:
                                    neg = "{0} {1}";
                                    break;

                                default:
                                    throw new FormatException("Unknown NumberNegativePattern.");
                            }

                            if (neg != null)
                            {
                                neg = string.Format(neg, pos, Provider.NegativeSign);
                            }
                        }

                        #endregion

                        break;

                    case 'P':
                    case 'p':

                        #region percent

                        {
                            var n = ToCustomFormatN(prec, NumberFormatType.Percent);

                            switch (Provider.PercentPositivePattern)
                            {
                                case 0:
                                    pos = "{0} %";
                                    break;

                                case 1:
                                    pos = "{0}%";
                                    break;

                                case 2:
                                    pos = "%{0}";
                                    break;

                                default:
                                    throw new FormatException("Unknown PercentPositivePattern.");
                            }

                            pos = string.Format(pos, n);

                            switch (Provider.PercentNegativePattern)
                            {
                                case 0:
                                    neg = "{1}{0} %";
                                    break;

                                case 1:
                                    neg = "{1}{0}%";
                                    break;

                                case 2:
                                    neg = "{1}%{0}";
                                    break;

                                default:
                                    throw new FormatException("Unknown PercentNegativePattern.");
                            }

                            neg = string.Format(neg, n, Provider.NegativeSign);
                        }

                        #endregion

                        break;

                    case 'R':
                    case 'r':
                        throw new ArgumentException("'R' and 'r' formats are not supported.");

                    case 'X':
                    case 'x':
                        throw new ArgumentException("'X' and 'x' formats are not supported.");

                    default:
                        throw new FormatException(string.Format("'{0}' is an invalid standard numeric format character.", ch));
                }

                ret = pos;

                if (neg != null)
                {
                    ret += ";" + neg;
                }
            }
            else // custom format string
            {
                ret = format;
            }

            return ret;
        }

        #endregion

        #region Private Static Methods

        private static string ParseExponent(string format, ref int index)
        {
            if (index >= format.Length)
            {
                return null;
            }

            var ix = index;
            var ch = format[ix++];

            if (ch != 'E' && ch != 'e')
            {
                return null;
            }

            if (ix >= format.Length)
            {
                return null;
            }

            ch = format[ix++];

            if (ch == '+' || ch == '-')
            {
                if (ix >= format.Length)
                {
                    return null;
                }
                ch = format[ix++];
            }

            if (ch != '0')
            {
                return null;
            }

            while (ix < format.Length && format[ix] == '0')
            {
                ix++;
            }

            var ret = format.Substring(index, ix - index);
            index = ix;
            return ret;
        }

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
                    if ("\\\"'".IndexOf(ch) >= 0)
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

            switch (ch)
            {
                case '0':
                case '#':
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

                if (ch1 != ch)
                {
                    break;
                }

                count++;
                index = ix;
            }

            return new string(ch, count);
        }

        #endregion

        #region Private Methods

        private string ParseSymbol(string format, ref int index)
        {
            if (index >= format.Length)
            {
                return null;
            }

            Debug.Assert(_symbolsProvider.Length == SYMBOLS.Length);

            string ret = null;

            var sub = format.Substring(index);

            for (var i = 0; i < SYMBOLS.Length; i++)
            {
                var symbolProvider = _symbolsProvider[i];

                if (symbolProvider != null && sub.StartsWith(symbolProvider))
                {
                    ret = SYMBOLS[i].ToString();
                    index += symbolProvider.Length;
                    break;
                }
            }

            if (ret != null)
            {
                return ret;
            }

            foreach (var symbol in SYMBOLS)
            {
                if (format[index] == symbol)
                {
                    ret = symbol.ToString();
                    index++;
                    break;
                }
            }

            return ret;
        }

        /// <summary>
        /// Called by ToCustomFormat(string, NumberFormatInfo).
        /// </summary>
        /// <param name="prec">The precision as specified or -1 for default.</param>
        /// <param name="type">One of the <see cref="NumberFormatType"/> enums.</param>
        /// <returns>Format of the number.</returns>
        private string ToCustomFormatN(int prec, NumberFormatType type)
        {
            string decimalSeparator;
            string groupSeparator;
            int[] groupSizes;

            switch (type)
            {
                case NumberFormatType.Number:
                    if (prec == -1)
                    {
                        prec = Provider.PercentDecimalDigits;
                    }

                    decimalSeparator = Provider.NumberDecimalSeparator;
                    groupSeparator = Provider.NumberGroupSeparator;
                    groupSizes = Provider.NumberGroupSizes;
                    break;

                case NumberFormatType.Currency:
                    if (prec == -1)
                    {
                        prec = Provider.CurrencyDecimalDigits;
                    }

                    decimalSeparator = Provider.CurrencyDecimalSeparator;
                    groupSeparator = Provider.CurrencyGroupSeparator;
                    groupSizes = Provider.CurrencyGroupSizes;
                    break;

                case NumberFormatType.Percent:
                    if (prec == -1)
                    {
                        prec = Provider.PercentDecimalDigits;
                    }

                    decimalSeparator = Provider.PercentDecimalSeparator;
                    groupSeparator = Provider.PercentGroupSeparator;
                    groupSizes = Provider.PercentGroupSizes;
                    break;

                default:
                    throw new ArgumentOutOfRangeException("type");
            }

            string ret;

            if (groupSizes.Length == 1 && groupSizes[0] == 3)
            {
                if (groupSeparator != Provider.NumberGroupSeparator)
                {
                    throw new FormatException(string.Format("{0} group separator must match number group separator.", type));
                }

                ret = "#,##0";
            }
            else if (groupSizes.Length == 1 && groupSizes[0] == 0)
            {
                ret = "0";
            }
            else
            {
                throw new FormatException(string.Format("{0} group sizes cannot be converted to custom format.", type));
            }

            if (prec > 0)
            {
                if (decimalSeparator != Provider.NumberDecimalSeparator)
                {
                    throw new FormatException(string.Format("{0} decimal separator must match number decimal separator.", type));
                }

                ret += "." + new string('0', prec);
            }

            return ret;
        }

        #endregion

        #endregion
    }
}