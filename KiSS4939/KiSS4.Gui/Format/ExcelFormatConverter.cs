using System;
using System.Diagnostics;
using System.Globalization;

namespace KiSS4.Gui.Format
{
	/// <summary>
	/// Converts an .NET format string to an Excel NumberFormat.
	/// </summary>
	public abstract class ExcelFormatConverter
	{
		#region static GetConverter

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
			if (culture == null) throw new ArgumentNullException("culture");

			CultureInfo baseCulture = culture;
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

		/// <summary>
		/// Initializes a new instance of the <see cref="ExcelFormatConverter"/> class.
		/// </summary>
		/// <param name="culture">The culture.</param>
		protected ExcelFormatConverter(CultureInfo culture)
		{
			if (culture == null) throw new ArgumentNullException("culture");

			this.Culture = culture;
			this.DateTimeFormatConverter = new DateTimeFormatConverter(culture.DateTimeFormat);
			this.NumberFormatConverter = new NumberFormatConverter(culture.NumberFormat);
		}

		#region abstract

		/// <summary>
		/// Gets the day char.
		/// </summary>
		/// <value>The day char.</value>
		public abstract char DayChar { get; }

		/// <summary>
		/// Gets the month char.
		/// </summary>
		/// <value>The month char.</value>
		public abstract char MonthChar { get; }

		/// <summary>
		/// Gets the year char.
		/// </summary>
		/// <value>The year char.</value>
		public abstract char YearChar { get; }

		/// <summary>
		/// Gets the hour char.
		/// </summary>
		/// <value>The hour char.</value>
		public abstract char HourChar { get; }

		/// <summary>
		/// Gets the minute char.
		/// </summary>
		/// <value>The minute char.</value>
		public abstract char MinuteChar { get; }

		/// <summary>
		/// Gets the second char.
		/// </summary>
		/// <value>The second char.</value>
		public abstract char SecondChar { get; }

		#endregion

		/// <summary>
		/// Converts the given string to a literal.
		/// </summary>
		/// <param name="literalString">The literal string.</param>
		/// <returns></returns>
		private static string ToLiteral(string literalString)
		{
			Debug.Assert(literalString[0] == '\'');
			literalString = literalString.Substring(1); // remove leading '

			string[] lits = literalString.Split('"');
			for (int j = 0; j < lits.Length; j++)
			{
				string lit = lits[j];
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
			string ret = string.Join("\\\"", lits);
			return ret;
		}

		/// <summary>
		/// Convert a DateTime format to an excel format.
		/// </summary>
		public string ToExcelDateTimeFormat(string format)
		{
			string[] elements = this.DateTimeFormatConverter.Parse(format);
			string ret = null;

			for (int i = 0; i < elements.Length; i++)
			{
				string ele = elements[i];
				string excelFormat;
				switch (ele[0])
				{
					case 'd':
						Debug.Assert(ele.Length <= 4);
						excelFormat = new string(this.DayChar, ele.Length);
						break;

					case 'M':
						Debug.Assert(ele.Length <= 4);
						excelFormat = new string(this.MonthChar, ele.Length);
						break;

					case 'y':
						excelFormat = new string(this.YearChar, ele.Length);
						break;

					case 'h':
					case 'H':
					{
						// determine if followed by t
						bool ampm;
						int j = i+1;
						while (true)
						{
							if (j >= elements.Length) { ampm = false;  break; }
							string ele1 = elements[j++];
							if (ele1[0] == '\'') continue; // ignore literals
							ampm = ele1[0] == 't';
							break;
						}

						if (ele[0] == 'H' && ampm)
							throw new ArgumentException("H format character must not be followed by t.");
						if (ele[0] == 'h' && !ampm)
							throw new ArgumentException("h format character must be followed by t.");

						Debug.Assert(ele.Length <= 2);
						excelFormat = new string(this.HourChar, ele.Length);
					}
						break;

					case 'm':
						Debug.Assert(ele.Length <= 2);
						excelFormat = new string(this.MinuteChar, ele.Length);
						break;

					case 's':
						Debug.Assert(ele.Length <= 2);
						excelFormat = new string(this.SecondChar, ele.Length);
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
						excelFormat = this.DateTimeFormatConverter.Provider.DateSeparator;
						break;

					case ':':
						excelFormat = this.DateTimeFormatConverter.Provider.TimeSeparator;
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
			string[] elements = this.NumberFormatConverter.Parse(format);
			NumberFormatInfo nfi = this.NumberFormatConverter.Provider;
			string ret = null;

			for (int i = 0; i < elements.Length; i++)
			{
				string ele = elements[i];
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

		#region inheritors

		/// <summary>
		/// Implements invariant language.
		/// </summary>
		private class Invariant : ExcelFormatConverter
		{
			/// <summary>
			/// Get the language ID.
			/// </summary>
			public const int LCID = 0x07F;

			/// <summary>
			/// Initializes a new instance of the <see cref="Invariant"/> class.
			/// </summary>
			/// <param name="culture">The culture.</param>
			public Invariant(CultureInfo culture) : base(culture)
			{
			}

			/// <summary>
			/// Gets the day char.
			/// </summary>
			/// <value>The day char.</value>
			public override char DayChar
			{
				get { return 'd'; }
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
			/// Gets the year char.
			/// </summary>
			/// <value>The year char.</value>
			public override char YearChar
			{
				get { return 'y'; }
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
			/// Gets the second char.
			/// </summary>
			/// <value>The second char.</value>
			public override char SecondChar
			{
				get { return 's'; }
			}
		}

		/// <summary>
		/// Implements the German Converter.
		/// </summary>
		private class German : ExcelFormatConverter
		{
			public const int LCID = 0x007;

			/// <summary>
			/// Initializes a new instance of the <see cref="German"/> class.
			/// </summary>
			/// <param name="culture">The culture.</param>
			public German(CultureInfo culture) : base(culture)
			{
				Debug.Assert(culture.IsNeutralCulture && culture.LCID == LCID || culture.Parent.LCID == LCID);
			}

			/// <summary>
			/// Gets the day char.
			/// </summary>
			/// <value>The day char.</value>
			public override char DayChar
			{
				get { return 'T'; }
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
			/// Gets the year char.
			/// </summary>
			/// <value>The year char.</value>
			public override char YearChar
			{
				get { return 'J'; }
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
			/// Gets the second char.
			/// </summary>
			/// <value>The second char.</value>
			public override char SecondChar
			{
				get { return 's'; }
			}
		}

		#endregion
	}
}
