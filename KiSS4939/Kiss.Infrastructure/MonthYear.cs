using System;
using System.Collections.Generic;

namespace Kiss.Infrastructure
{
    public struct MonthYear : IComparable<MonthYear>, IEquatable<MonthYear>
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const int MONTHS_IN_YEAR = 12;

        #endregion

        #region Private Fields

        private int _month;

        #endregion

        #endregion

        #region Constructors

        public MonthYear(DateTime date)
            : this(date.Year, date.Month)
        {
            // do nothing
        }

        public MonthYear(int year, int month)
            : this()
        {
            Year = year;
            Month = month;
        }

        #endregion

        #region Properties

        public static MonthYear CurrentMonth
        {
            get
            {
                return new MonthYear(DateTime.Today);
            }
        }

        public int Month
        {
            get { return _month; }
            set
            {
                if (value < 1 || value > MONTHS_IN_YEAR)
                {
                    throw new ArgumentOutOfRangeException("value", string.Format("Month must be between 1 and {0}", MONTHS_IN_YEAR));
                }
                _month = value;
            }
        }

        public int Year
        {
            get;
            set;
        }

        #endregion

        #region Methods

        #region Public Static Methods

        public static bool operator !=(MonthYear lhs, MonthYear rhs)
        {
            return !(lhs == rhs);
        }

        public static MonthYear operator +(MonthYear lhs, int rhs)
        {
            var monthDiff = lhs.Month + rhs;
            if (monthDiff < 1 || monthDiff > 12)
            {
                var yearsTotalToAdd = (double)(monthDiff - 1) / MONTHS_IN_YEAR;
                var yearsToAdd = (int)Math.Floor(yearsTotalToAdd);
                var months = monthDiff - yearsToAdd * MONTHS_IN_YEAR;
                return new MonthYear(lhs.Year + yearsToAdd, months);
            }

            return new MonthYear(lhs.Year, monthDiff);
        }

        public static MonthYear operator ++(MonthYear monthYear)
        {
            if (monthYear.Month >= MONTHS_IN_YEAR)
            {
                return new MonthYear { Year = monthYear.Year + 1, Month = 1 };
            }

            return new MonthYear { Year = monthYear.Year, Month = monthYear.Month + 1 };
        }

        public static MonthYear operator -(MonthYear lhs, int rhs)
        {
            return lhs + (-rhs);
        }


        /// <summary>
        /// Returns the number of Months that the two MonthYears span
        /// Apr 2012 -> Jun 2012 = 3  months
        /// Apr 2012 -> Jan 2013 = 10 months
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static int GetSpanningMonthCount(MonthYear from, MonthYear to)
        {
            return to.Month - from.Month + 1 + (to.Year - from.Year) * MONTHS_IN_YEAR;
        }

        /// <summary>
        /// Returns the number of Months between the two MonthYears
        /// Apr 2012 -> Jun 2012 = 2 months
        /// Apr 2012 -> Jan 2013 = 9 months
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static int GetMonthDiff(MonthYear from, MonthYear to)
        {
            return GetSpanningMonthCount(from, to) - 1;
        }

        public static MonthYear operator --(MonthYear monthYear)
        {
            if (monthYear.Month <= 1)
            {
                return new MonthYear { Year = monthYear.Year - 1, Month = MONTHS_IN_YEAR };
            }

            return new MonthYear { Year = monthYear.Year, Month = monthYear.Month - 1 };
        }

        public static bool operator <(MonthYear lhs, MonthYear rhs)
        {
            return lhs.CompareTo(rhs) < 0;
        }

        public static bool operator <=(MonthYear lhs, MonthYear rhs)
        {
            return lhs.CompareTo(rhs) <= 0;
        }

        public static bool operator ==(MonthYear lhs, MonthYear rhs)
        {
            if ((object)lhs == null && (object)rhs == null)
            {
                return true;
            }

            if ((object)lhs == null || (object)rhs == null)
            {
                return false;
            }

            return lhs.CompareTo(rhs) == 0;
        }

        public static bool operator >(MonthYear lhs, MonthYear rhs)
        {
            return lhs.CompareTo(rhs) > 0;
        }

        public static bool operator >=(MonthYear lhs, MonthYear rhs)
        {
            return lhs.CompareTo(rhs) >= 0;
        }

        public static IList<MonthYear> GetMonthList(MonthYear from, MonthYear to)
        {
            var list = new List<MonthYear>();

            for (var i = from; i <= to; i++)
            {
                list.Add(i);
            }

            return list;
        }

        #endregion

        #region Public Methods

        #region IComparable<MonthYear> Members

        public int CompareTo(MonthYear other)
        {
            var yearCompare = Year.CompareTo(other.Year);
            return yearCompare != 0 ? yearCompare : Month.CompareTo(other.Month);
        }

        #endregion

        #region IEquatable<MonthYear> Members

        public bool Equals(MonthYear other)
        {
            return other.Year == Year && other.Month == Month;
        }

        #endregion

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (obj.GetType() != typeof(MonthYear))
            {
                return false;
            }

            return Equals((MonthYear)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Year * 397) ^ Month;
            }
        }

        public override string ToString()
        {
            return (new DateTime(Year, Month, 1)).ToString("MMM yyyy");
        }

        public DateTime GetFirstDayOfMonth()
        {
            return new DateTime(Year, Month, 1);
        }

        public DateTime GetLastDayOfMonth()
        {
            return new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month));
        }

        #endregion

        #endregion
    }
}
