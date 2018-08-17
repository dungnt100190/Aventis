using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;

namespace KiSS4.Gui.Format
{
	/// <summary>
	/// Converter for DateTime format strings.
	/// </summary>
	public class DateTimeFormatConverter
	{
		/// <summary>
		/// true if format is a standard DateTime format.
		/// </summary>
		/// <remarks>a null string or an empty string are considered the standard format "G".</remarks>
		public static bool IsStandardFormat(string format)
		{
			return format == null || format.Length <= 1;
		}

		/// <summary>
		/// Gets the <see cref="DateTimeFormatInfo"/> in use.
		/// </summary>
		public readonly DateTimeFormatInfo Provider;

		/// <summary>
		/// Initialize with the <see cref="DateTimeFormatInfo"/> used by the current thread.
		/// </summary>
		public DateTimeFormatConverter() : this(DateTimeFormatInfo.CurrentInfo)
		{}

		/// <summary>
		/// Initialize with a <see cref="DateTimeFormatInfo"/>.
		/// </summary>
		public DateTimeFormatConverter(DateTimeFormatInfo provider)
		{
			if (provider == null) throw new ArgumentNullException("provider");

			this.Provider = provider;
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
			if (format == null || format.Length == 0) // use the general format
				format = "G";

			string ret;
			if (format.Length == 1) // standard date time format string
			{
				char ch = format[0];
				switch (ch)
				{
					case 'd':
						ret = this.Provider.ShortDatePattern;
						break;

					case 'D':
						ret = this.Provider.LongDatePattern;
						break;

					case 't':
						ret = this.Provider.ShortTimePattern;
						break;

					case 'T':
						ret = this.Provider.LongTimePattern;
						break;

					case 'f':
						ret = this.Provider.LongDatePattern + " " + this.Provider.ShortTimePattern;
						break;

					case 'F':
						ret = this.Provider.FullDateTimePattern;
						break;

					case 'g':
						ret = this.Provider.ShortDatePattern + " " + this.Provider.ShortTimePattern;
						break;

					case 'G':
						ret = this.Provider.ShortDatePattern + " " + this.Provider.LongTimePattern;
						break;
				
					case 'M':
					case 'm':
						ret = this.Provider.MonthDayPattern;
						break;

					case 'R':
					case 'r':
						if (this.Provider != DateTimeFormatInfo.InvariantInfo)
							throw new ArgumentException("r format only valid for invariant DateTimeFormatInfo");
						ret = this.Provider.RFC1123Pattern;
						break;

					case 's':
						if (this.Provider != DateTimeFormatInfo.InvariantInfo)
							throw new ArgumentException("s format only valid for invariant DateTimeFormatInfo");
						ret = DateTimeFormatInfo.InvariantInfo.SortableDateTimePattern;
						break;

					case 'u':
						if (this.Provider != DateTimeFormatInfo.InvariantInfo)
							throw new ArgumentException("u format only valid for invariant DateTimeFormatInfo");
						ret = DateTimeFormatInfo.InvariantInfo.UniversalSortableDateTimePattern;
						break;

					case 'U':
						throw new ArgumentException("'U' cannot be converted to a custom DateTime format string.", "format");

					case 'Y':
					case 'y':
						ret = this.Provider.YearMonthPattern;
						break;

					default:
						throw new FormatException(string.Format("'{0}' is an invalid standard DateTime format character.", ch));
				}

				if (ret.Length == 1) // still a standard format
					ret = "%" + ret;
			}
			else // already a custom format string
				ret = format;

			return ret;
		}

		private static string ParsePlaceholder(string format, ref int index)
		{
			if (index >= format.Length) return null;
				
			int ix = index;
			char ch = format[ix++];
			if (ch == '%')
			{
				if (ix < format.Length)
					ch = format[ix++];
				else
					return null;
			}
				
			int max;
			switch (ch)
			{
				case 'd':
				case 'M':
					max = 4; break;
				case 'f':
					max = 7; break;
				case 'g':
				case 'h':
				case 'H':
				case 'm':
				case 's':
				case 't':
					max = 2; break;
				case 'y':
					max = int.MaxValue; break;
				case 'z':
					max = 3; break;
				default:
					return null;
			}

			int count = 1;
			index = ix;

			while (true)
			{
				if (ix >= format.Length) break;
				char ch1 = format[ix++];
				if (ch1 == '%') continue;
				if (ch1 != ch) break;
				count++;
				index = ix;
			}

			if (count > max)
			{
				if (ch == 'f')
					throw new FormatException("Too many 'f's.");
				else
					count = max;
			}

			return new string(ch, count);
		}

		private static string ParseSeparator(string format, ref int index, DateTimeFormatInfo provider)
		{
			if (index >= format.Length) return null;

			const char stDSep = '/';
			const char stTSep = ':';
			string prDSep = provider.DateSeparator;
			string prTSep = provider.TimeSeparator;
			string ret = null;

			string sub = format.Substring(index);
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
			else if (format[index] == stDSep)
			{
				ret = stDSep.ToString();
				index++;
			}
			else if (format[index] == stTSep)
			{
				ret = stTSep.ToString();
				index++;
			}

			return ret;
		}

		private static string ParseLiteral(string format, ref int index)
		{
			if (index >= format.Length) return null;

			int ix = index;
			char ch = format[ix++];

			string ret;
			if (ch == '"' || ch == '\'')
			{
				while (true)
				{
					if (ix >= format.Length)
						throw new FormatException("No matching " + ch + " found.");
					char ch1 = format[ix++];
					if (ch1 == ch)
					{
						ret = format.Substring(index+1, ix - index - 2);
						index = ix;
						break;
					}
				}
			}
			else if (ch == '\\')
			{
				if (ix >= format.Length) return null;
					
				ch = format[ix++];
				ret = ch.ToString();
				index = ix;
			}
			else
			{
				if (ch == '%')
				{
					if (ix >= format.Length) return null;
					ch = format[ix++];
				}

				if ("%\\\"'".IndexOf(ch) >= 0) return null;

				ret = ch.ToString();
				index = ix;
			}

			return ret;
		}

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
			format = this.ToCustomFormat(format);
			Debug.Assert(format.Length > 0);

			ArrayList retAL = new ArrayList();
			int index = 0;

			while (index < format.Length)
			{
				string ele;
					
				if ((ele = ParsePlaceholder(format, ref index)) != null)
					retAL.Add(ele);
				else if ((ele = ParseSeparator(format, ref index, this.Provider)) != null)
					retAL.Add(ele);
				else if ((ele = ParseLiteral(format, ref index)) != null)
				{
					if (retAL.Count > 0)
					{
						string lit = (string) retAL[retAL.Count - 1] + ele;
						if (lit[0] == '\'')
							retAL[retAL.Count - 1] = lit + ele;
						else
							retAL.Add("'" + ele);
					}
					else
						retAL.Add("'" + ele);
				}
				else
					throw new FormatException("Input string contains invalid format.");
			}

			return (string[]) retAL.ToArray(typeof(string));
		}
	}
}
