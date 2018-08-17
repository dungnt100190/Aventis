using System;
using System.Globalization;

namespace KiSS4.Common
{
	/// <summary>
	/// This class provides methods to deal with a time period. A period is
	/// defined as the time between a starting date and an end date.
	/// </summary>
	/// TODO: implement relational operators if necessary
	/// TODO: override Equals() and GetHasCode() if necessary
	public sealed class Period
		:
		IComparable
	{
		#region Fields and Properties

		private DateTime start;
		/// <summary>
		/// Gets the start of the period.
		/// </summary>
		/// <value>The start.</value>
		public DateTime Start
		{
			get { return start; }
		}

		private DateTime end;
		/// <summary>
		/// Gets the end of the period.
		/// </summary>
		/// <value>The end.</value>
		public DateTime End
		{
			get { return end; }
		}

		#endregion

		/// <summary>
		/// Gets the duration of this period.
		/// </summary>
		/// <returns></returns>
		public TimeSpan Duration()
		{
			return end.Subtract(start);
		}

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="Period"/> class.
		/// </summary>
		/// <param name="start">The start.</param>
		/// <param name="end">The end.</param>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public Period(DateTime start, DateTime end)
		{
			/*
			 * Less than zero : t1 is less than t2. 
			 * Zero : t1 equals t2. 
			 * Greater than zero t1 is greater than t2. 
			 */
			if (DateTime.Compare(start, end) > 0)
			{
				throw new ArgumentOutOfRangeException("start", "Start date should be before end date");
			}
			else if (DateTime.Compare(start, end) == 0)
			{
				throw new ArgumentOutOfRangeException("start", "Start date and end date can not be equal");
			}
			else
			{
				this.start = start;
				this.end = end;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Period"/> class.
		/// The period will be from 01.01.yyyy - 31.12.yyyy of the specified year.
		/// </summary>
		/// <param name="year">The year.</param>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public Period(Int32 year)
		{
			if (year < DateTime.MinValue.Year)
			{
				throw new ArgumentOutOfRangeException("year", "year should not be smaller than DateTime.MinValue.Year");
			}

			if (year > DateTime.MaxValue.Year)
			{
				throw new ArgumentOutOfRangeException("year", "year should not be larger than DateTime.MaxValue.Year");
			}

			start = new DateTime(year, 1, 1);
			end = new DateTime(year, 12, 31, 23, 59, 59, 999);
		}

		#endregion

		#region Adjoins

		/// <summary>
		/// Determines if the specified period is adjacent to this
		/// period.
		/// </summary>
		/// <param name="other">The other.</param>
		/// <param name="allowedSpan"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException"></exception>
		public Boolean Adjoins(Period other, TimeSpan allowedSpan)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}

			// --- if they overlap they can not be adjacent
			if (this.Overlaps(other))
			{
				return false;
			}

			// --- if 'other' follows this period. 
			if (AdjoinsAfter(other, allowedSpan))
			{
				return true;
			}

			// --- if this period follows the other period
			if (other.AdjoinsAfter(this, allowedSpan))
			{
				return true;
			}

			return false;
		}

		/// <summary>
		/// Determines if the specified period is adjacent to this
		/// period. (allowed TimeSpan = 1 day)
		/// </summary>
		/// <param name="other">The other.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException"></exception>
		public Boolean Adjoins(Period other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}

			return Adjoins(other, TimeSpan.FromDays(1));
		}

		/// <summary>
		/// Determines whether the specifed period follows after this period.
		/// </summary>
		/// <param name="other">The other.</param>
		/// <param name="allowedRange">The allowed range.</param>
		/// <returns></returns>
		private Boolean AdjoinsAfter(
			Period other,
			TimeSpan allowedRange)
		{
			TimeSpan range = other.Start.Subtract(this.End);

			/*
			 * -1 : t1 is less than t2
			 *  0 : t1 is equal to t2
			 *  1 : t1 is greater than t2
			 */

			return (TimeSpan.Compare(range.Duration(), allowedRange.Duration()) <= 0);
		}

		/// <summary>
		/// Determines if two periods are adjacent to each other.
		/// </summary>
		/// <param name="p1">The p1.</param>
		/// <param name="p2">The p2.</param>
		/// <returns></returns>
		/// <exception cref="T:System.ArgumentNullException"></exception>
		public static Boolean Adjoins(
			Period p1,
			Period p2)
		{
			if (p1 == null)
			{
				throw new ArgumentNullException("p1");
			}
			if (p2 == null)
			{
				throw new ArgumentNullException("p2");
			}

			return (p1.Adjoins(p2, TimeSpan.FromDays(1)));
		}

		/// <summary>
		/// Determines if two periods are adjacent to each other.
		/// </summary>
		/// <param name="p1">The p1.</param>
		/// <param name="p2">The p2.</param>
		/// <param name="allowedSpan"></param>
		/// <returns></returns>
		/// <exception cref="T:System.ArgumentNullException">period should not be null. </exception>
		public static Boolean Adjoins(
			Period p1,
			Period p2,
			TimeSpan allowedSpan)
		{
			if (p1 == null)
			{
				throw new ArgumentNullException("p1");
			}
			if (p2 == null)
			{
				throw new ArgumentNullException("p2");
			}

			return (p1.Adjoins(p2, allowedSpan));
		}

		#endregion

		#region Contains

		/// <summary>
		/// Determines whether the period contains [the specified date].
		/// </summary>
		/// <param name="date">The date.</param>
		/// <returns>
		/// 	<c>true</c> if the period contains [the specified date]; otherwise, <c>false</c>.
		/// </returns>
		public Boolean Contains(DateTime date)
		{
			/*
			 * Less than zero : t1 is less than t2. 
			 * Zero : t1 equals t2. 
			 * Greater than zero t1 is greater than t2. 
			 */
			return ((DateTime.Compare(start, date) <= 0) && (DateTime.Compare(date, end) <= 0));
		}

		/// <summary>
		/// Determines whether the period contains [the specified period].
		/// </summary>
		/// <param name="period">The period.</param>
		/// <returns>
		/// 	<c>true</c> if the period contains [the specified period]; otherwise, <c>false</c>.
		/// </returns>
		/// <exception cref="T:System.ArgumentNullException"></exception>
		public Boolean Contains(Period period)
		{
			if (period == null)
			{
				throw new ArgumentNullException("period");
			}

			return (this.Contains(period.start) && this.Contains(period.end));
		}

		#endregion

		#region Overlaps

		/// <summary>
		/// Determines if two periods do overlap.
		/// </summary>
		/// <param name="period">The other period.</param>
		/// <returns></returns>
		/// <exception cref="T:System.ArgumentNullException">period should not be null. </exception>
		public Boolean Overlaps(Period period)
		{
			if (period == null)
			{
				throw new ArgumentNullException("period");
			}

			// --- true if one contains the other
			if (this.Contains(period) || period.Contains(this))
			{
				return true;
			}

			// --- true if start and/or end of period is within out period.
			if (this.Contains(period.start) || this.Contains(period.end))
			{
				return true;
			}

			return false;
		}

		/// <summary>
		/// Determines if the specified periods do overlap.
		/// </summary>
		/// <param name="p1">The p1.</param>
		/// <param name="p2">The p2.</param>
		/// <returns></returns>
		/// <exception cref="T:System.ArgumentNullException"></exception>
		public static Boolean Overlaps(Period p1, Period p2)
		{
			if (p1 == null)
			{
				throw new ArgumentNullException("p1");
			}
			if (p2 == null)
			{
				throw new ArgumentNullException("p2");
			}

			return (p1.Overlaps(p2));
		}

		#endregion

		#region IComparable Members

		/// <summary>
		/// Compares the current instance with another object of the same type.
		/// </summary>
		/// <param name="obj">An object to compare with this instance.</param>
		/// <returns>
		/// A 32-bit signed integer that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance is less than obj. Zero This instance is equal to obj. Greater than zero This instance is greater than obj.
		/// </returns>
		/// <exception cref="T:System.ArgumentException">obj is not the same type as this instance. </exception>
		public int CompareTo(object obj)
		{
			Period period = obj as Period;

			if(period == null)
			{
				throw new ArgumentException("Argument is not a Period", "obj");
			}

			return CompareTo(period);
		}

		/// <summary>
		/// Type-safe CompareTo
		/// Compares the current instance with another object of the same type.
		/// </summary>
		/// <param name="period">An object to compare with this instance.</param>
		/// <returns>
		/// A 32-bit signed integer that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance is less than obj. Zero This instance is equal to obj. Greater than zero This instance is greater than obj.
		/// </returns>
		/// <exception cref="T:System.ArgumentNullException"></exception>
		public int CompareTo(Period period)
		{
			Int32 compareResult = 0;

			if(period == null)
			{
				throw new ArgumentNullException("period");
			}

			compareResult = this.start.CompareTo(period.start);
			if (compareResult < 0)
			{
				return compareResult;
			}
			else if (compareResult > 0)
			{
				return compareResult;
			}
			else
			{
				return TimeSpan.Compare(this.Duration(), period.Duration());
			}
		}

		#endregion

		#region overrides

		/// <summary>
		/// Returns a <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
		/// </returns>
		public override string ToString()
		{
			Double days = Math.Round(end.Subtract(start).TotalDays, 1);

			return String.Format(
				CultureInfo.CurrentUICulture, 
				"{0} - {1} ({2} days)",
				start.ToString("dd.MM.yyyy", CultureInfo.CurrentUICulture),
				end.ToString("dd.MM.yyyy", CultureInfo.CurrentUICulture),
				days.ToString(CultureInfo.CurrentUICulture));
		}

		#endregion
	}
}
