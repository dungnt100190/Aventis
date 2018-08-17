using System;
using System.Diagnostics;
using System.Globalization;

namespace Kiss.UI.Controls.Helper.Format
{
    /// <summary>
    /// Converts an .NET format string to an Excel NumberFormat.
    /// </summary>
    public abstract class ExcelFormatConverter
    {
        #region Fields

        #region Public Constant/Read-Only Fields

        /// <summary>
        /// Get the used CultureInfo.
        /// </summary>
        public readonly CultureInfo Culture;

        /// <summary>
        /// Get the used Converter for the DateTime Format. 
        /// </summary>
        public readonly DateTimeFormatConverter DateTimeFormatConverter;

        /// <summary>
        /// Get the used Converter for the NumberFormat.
        /// </summary>
        public readonly NumberFormatConverter NumberFormatConverter;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelFormatConverter"/> class.
        /// </summary>
        /// <param name="culture">The culture.</param>
        protected ExcelFormatConverter(CultureInfo culture)
        {
            if (culture == null)
            {
                throw new ArgumentNullException("culture");
            }

            Culture = culture;
            DateTimeFormatConverter = new DateTimeFormatConverter(culture.DateTimeFormat);
            NumberFormatConverter = new NumberFormatConverter(culture.NumberFormat);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the day char.
        /// </summary>
        /// <value>The day char.</value>
        public abstract char DayChar
        {
            get;
        }

        /// <summary>
        /// Gets the hour char.
        /// </summary>
        /// <value>The hour char.</value>
        public abstract char HourChar
        {
            get;
        }

        /// <summary>
        /// Gets the minute char.
        /// </summary>
        /// <value>The minute char.</value>
        public abstract char MinuteChar
        {
            get;
        }

        /// <summary>
        /// Gets the month char.
        /// </summary>
        /// <value>The month char.</value>
        public abstract char MonthChar
        {
            get;
        }

        /// <summary>
        /// Gets the second char.
        /// </summary>
        /// <value>The second char.</value>
        public abstract char SecondChar
        {
            get;
        }

        /// <summary>
        /// Gets the year char.
        /// </summary>
        /// <value>The year char.</value>
        public abstract char YearChar
        {
            get;
        }

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Gets the converter.
        /// </summary>
        /// <returns></returns>
        public static ExcelFormatConverter GetConverter()
        {
            return GetConverter(CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Gets the converter.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns></returns>
        public static ExcelFormatConverter GetConverter(CultureInfo culture)
        {
            if (culture == null)
            {
                throw new ArgumentNullException("culture");
            }

            var baseCulture = culture;

            while (true)
            {
                switch (baseCulture.LCID)
                {
                    case Invariant.LCID:
                        return new Invariant(culture);

                    case German.LCID:
                        return new German(culture);
                }

                baseCulture = baseCulture.Parent;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Convert a DateTime format to an excel format.
        /// </summary>
        public string ToExcelDateTimeFormat(string format)
        {
            var elements = DateTimeFormatConverter.Parse(format);
            string ret = null;

            for (var i = 0; i < elements.Length; i++)
            {
                var ele = elements[i];
                string excelFormat;

                switch (ele[0])
                {
                    case 'd':
                        Debug.Assert(ele.Length <= 4);
                        excelFormat = new string(DayChar, ele.Length);
                        break;

                    case 'M':
                        Debug.Assert(ele.Length <= 4);
                        excelFormat = new string(MonthChar, ele.Length);
                        break;

                    case 'y':
                        excelFormat = new string(YearChar, ele.Length);
                        break;

                    case 'h':
                    case 'H':
                        {
                            // determine if followed by t
                            bool ampm;
                            var j = i + 1;

                            while (true)
                            {
                                if (j >= elements.Length)
                                {
                                    ampm = false;
                                    break;
                                }

                                var ele1 = elements[j++];

                                if (ele1[0] == '\'')
                                {
                                    continue; // ignore literals
                                }

                                ampm = ele1[0] == 't';
                                break;
                            }

                            if (ele[0] == 'H' && ampm)
                            {
                                throw new ArgumentException("H format character must not be followed by t.");
                            }

                            if (ele[0] == 'h' && !ampm)
                            {
                                throw new ArgumentException("h format character must be followed by t.");
                            }

                            Debug.Assert(ele.Length <= 2);
                            excelFormat = new string(HourChar, ele.Length);
                        }

                        break;

                    case 'm':
                        Debug.Assert(ele.Length <= 2);
                        excelFormat = new string(MinuteChar, ele.Length);
                        break;

                    case 's':
                        Debug.Assert(ele.Length <= 2);
                        excelFormat = new string(SecondChar, ele.Length);
                        break;

                    case 'f':
                        Debug.Assert(ele.Length <= 7);
                        excelFormat = new string('0', ele.Length);
                        break;

                    case 't':
                        Debug.Assert(ele.Length <= 2);
                        excelFormat = ele.Length == 1 ? "A/P" : "AM/PM";
                        break;

                    case 'g':
                        throw new ArgumentException("g format character cannot be converted to Excel format.");

                    case 'z':
                        throw new ArgumentException("z format character cannot be converted to Excel format.");

                    case '/':
                        excelFormat = DateTimeFormatConverter.Provider.DateSeparator;
                        break;

                    case ':':
                        excelFormat = DateTimeFormatConverter.Provider.TimeSeparator;
                        break;

                    case '\'': // literal
                        excelFormat = ToLiteral(ele);
                        break;

                    default:
                        throw new ApplicationException("Unknown format element.");
                }

                ret += excelFormat;
            }

            return ret;
        }

        /// <summary>
        /// Convert a number format to an excel format.
        /// </summary>
        public string ToExcelNumberFormat(string format)
        {
            var elements = NumberFormatConverter.Parse(format);
            var nfi = NumberFormatConverter.Provider;
            string ret = null;

            foreach (var ele in elements)
            {
                string excelFormat;

                switch (ele[0])
                {
                    case '0':
                    case '#':
                    case 'e':
                    case 'E':
                    case ';':
                        excelFormat = ele;
                        break;

                    case '.':
                        excelFormat = nfi.NumberDecimalSeparator;
                        break;

                    case ',':
                        excelFormat = nfi.NumberGroupSeparator;
                        break;

                    case '%':
                        excelFormat = nfi.PercentSymbol;
                        break;

                    case '+':
                        excelFormat = nfi.PositiveSign;
                        break;

                    case '-':
                        excelFormat = nfi.NegativeSign;
                        break;

                    case '\'': // literal
                        excelFormat = ToLiteral(ele);
                        break;

                    default:
                        throw new ApplicationException("Unknown format element.");
                }

                ret += excelFormat;
            }

            return ret;
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// Converts the given string to a literal.
        /// </summary>
        /// <param name="literalString">The literal string.</param>
        /// <returns></returns>
        private static string ToLiteral(string literalString)
        {
            Debug.Assert(literalString[0] == '\'');
            literalString = literalString.Substring(1); // remove leading '

            var lits = literalString.Split('"');

            for (var j = 0; j < lits.Length; j++)
            {
                var lit = lits[j];

                switch (lit.Length)
                {
                    case 0:
                        break;

                    case 1:
                        lit = "\\" + lit;
                        break;

                    default:
                        lit = "\"" + lit + "\"";
                        break;
                }

                lits[j] = lit;
            }

            return string.Join("\\\"", lits);
        }

        #endregion

        #endregion

        #region Nested Types

        /// <summary>
        /// Implements the German Converter.
        /// </summary>
        private class German : ExcelFormatConverter
        {
            #region Fields

            #region Public Constant/Read-Only Fields

            public const int LCID = 0x007;

            #endregion

            #endregion

            #region Constructors

            /// <summary>
            /// Initializes a new instance of the <see cref="ExcelFormatConverter.German"/> class.
            /// </summary>
            /// <param name="culture">The culture.</param>
            public German(CultureInfo culture)
                : base(culture)
            {
                Debug.Assert(culture.IsNeutralCulture && culture.LCID == LCID || culture.Parent.LCID == LCID);
            }

            #endregion

            #region Properties

            /// <summary>
            /// Gets the day char.
            /// </summary>
            /// <value>The day char.</value>
            public override char DayChar
            {
                get { return 'T'; }
            }

            /// <summary>
            /// Gets the hour char.
            /// </summary>
            /// <value>The hour char.</value>
            public override char HourChar
            {
                get { return 'h'; }
            }

            /// <summary>
            /// Gets the minute char.
            /// </summary>
            /// <value>The minute char.</value>
            public override char MinuteChar
            {
                get { return 'm'; }
            }

            /// <summary>
            /// Gets the month char.
            /// </summary>
            /// <value>The month char.</value>
            public override char MonthChar
            {
                get { return 'M'; }
            }

            /// <summary>
            /// Gets the second char.
            /// </summary>
            /// <value>The second char.</value>
            public override char SecondChar
            {
                get { return 's'; }
            }

            /// <summary>
            /// Gets the year char.
            /// </summary>
            /// <value>The year char.</value>
            public override char YearChar
            {
                get { return 'J'; }
            }

            #endregion
        }

        /// <summary>
        /// Implements invariant language.
        /// </summary>
        private class Invariant : ExcelFormatConverter
        {
            #region Fields

            #region Public Constant/Read-Only Fields

            /// <summary>
            /// Get the language ID.
            /// </summary>
            public const int LCID = 0x07F;

            #endregion

            #endregion

            #region Constructors

            /// <summary>
            /// Initializes a new instance of the <see cref="ExcelFormatConverter.Invariant"/> class.
            /// </summary>
            /// <param name="culture">The culture.</param>
            public Invariant(CultureInfo culture)
                : base(culture)
            {
            }

            #endregion

            #region Properties

            /// <summary>
            /// Gets the day char.
            /// </summary>
            /// <value>The day char.</value>
            public override char DayChar
            {
                get { return 'd'; }
            }

            /// <summary>
            /// Gets the hour char.
            /// </summary>
            /// <value>The hour char.</value>
            public override char HourChar
            {
                get { return 'h'; }
            }

            /// <summary>
            /// Gets the minute char.
            /// </summary>
            /// <value>The minute char.</value>
            public override char MinuteChar
            {
                get { return 'm'; }
            }

            /// <summary>
            /// Gets the month char.
            /// </summary>
            /// <value>The month char.</value>
            public override char MonthChar
            {
                get { return 'M'; }
            }

            /// <summary>
            /// Gets the second char.
            /// </summary>
            /// <value>The second char.</value>
            public override char SecondChar
            {
                get { return 's'; }
            }

            /// <summary>
            /// Gets the year char.
            /// </summary>
            /// <value>The year char.</value>
            public override char YearChar
            {
                get { return 'y'; }
            }

            #endregion
        }

        #endregion
    }
}