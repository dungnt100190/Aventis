using System;

namespace Kiss.Infrastructure
{
    public struct TimePeriod
    {
        #region Constructors

        public TimePeriod(DateTime from)
            : this(from, DateTime.MaxValue)
        {
            // do nothing
        }

        public TimePeriod(DateTime from, DateTime? to)
            : this(from,
                   (DateTime)(to.HasValue ? to : DateTime.MaxValue))
        {
            // do nothing
        }

        public TimePeriod(int year, int month)
            : this(new DateTime(year, month, 1),
                   new DateTime(year, month, DateTime.DaysInMonth(year, month)))
        {
            // do nothing
        }

        public TimePeriod(MonthYear monthYear)
            : this(new DateTime(monthYear.Year, monthYear.Month, 1),
                   new DateTime(monthYear.Year, monthYear.Month, DateTime.DaysInMonth(monthYear.Year, monthYear.Month)))
        {
            // do nothing
        }

        public TimePeriod(DateTime from, DateTime to)
            : this()
        {
            CheckThatTimeRunsForward(from, to);
            From = from;
            To = to;
        }

        /// <summary>
        /// For usage in XAML
        /// </summary>
        /// <param name="periodString"></param>
        public TimePeriod(string periodString)
            : this(DateTime.Parse(periodString.Split('-')[0]), DateTime.Parse(periodString.Split('-')[1]))
        {
            //nop
        }

        #endregion

        #region Properties

        public DateTime From
        {
            get;
            private set;
        }

        public DateTime? NullableTo
        {
            get { return To == DateTime.MaxValue ? null : (DateTime?)To; }
        }

        public TimeSpan TimeSpan
        {
            get { return (To - From).Add(new TimeSpan(1, 0, 0, 0)); }
        }

        public DateTime To
        {
            get;
            private set;
        }

        #endregion

        #region Methods

        #region Public Static Methods

        public static TimePeriod? operator *(TimePeriod lhs, TimePeriod rhs)
        {
            var laterFrom = lhs.From;
            if (rhs.From > laterFrom)
            {
                laterFrom = rhs.From;
            }

            var earlierTo = lhs.To;
            if (rhs.To < earlierTo)
            {
                earlierTo = rhs.To;
            }
            if (laterFrom > earlierTo)
            {
                return null; // NullTimeVector? Geht nicht, da struct
            }
            return new TimePeriod(laterFrom, earlierTo);
        }

        public static bool operator ==(TimePeriod lhs, TimePeriod rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(TimePeriod lhs, TimePeriod rhs)
        {
            return !(lhs == rhs);
        }

        #endregion

        #region Public Methods

        public int GetOverlappingDays(TimePeriod other)
        {
            var overlappingPeriod = this * other;
            if (overlappingPeriod == null)
            {
                return 0;
            }
            return overlappingPeriod.Value.TimeSpan.Days;
        }

        public TimePeriod CropBy(TimePeriod outerLimits)
        {
            return new TimePeriod(From > outerLimits.From ? From : outerLimits.From,
                                  To < outerLimits.To ? To : outerLimits.To);
        }

        public TimePeriod CropByTryPreserveTimeSpan(TimePeriod outerLimits)
        {
            var ticksToAddToTheRight = From < outerLimits.From ? (outerLimits.From - From).Ticks : 0;
            var ticksToAddToTheLeft = To > outerLimits.To ? (outerLimits.To - To).Ticks : 0;

            return new TimePeriod(From.AddTicks(ticksToAddToTheLeft), To.AddTicks(ticksToAddToTheRight)).CropBy(outerLimits);
        }


        /// <summary>
        /// Stellt fest, ob zwei Zeitintervalle
        /// eine Überschneidung haben.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IsOverlapping(TimePeriod other)
        {
            TimePeriod? res = this * other;
            if (res.HasValue)
            {
                return true;
            }
            return false;
        }


        public override string ToString()
        {
            return string.Format("{0:d} - {1:d}", From, To);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (obj.GetType() != typeof(TimePeriod)) return false;
            return Equals((TimePeriod)obj);
        }

        #endregion

        #region Private Static Methods

        private static void CheckThatTimeRunsForward(DateTime from, DateTime? to)
        {
            if (to.HasValue && to.Value < from)
            {
                throw new ArgumentException("'von' muss kleiner sein als 'bis' - Zeitmaschinen sind noch nicht erfunden");
            }
        }

        #endregion

        #endregion

        public bool Equals(TimePeriod other)
        {
            return other.From.Equals(From) && other.To.Equals(To);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (From.GetHashCode() * 397) ^ To.GetHashCode();
            }
        }

        public TimePeriod MoveByDays(double days, TimePeriod surroundingBox)
        {
            var newPeriod = new TimePeriod(From.AddDays(days), To.AddDays(days));

            if (newPeriod.From < surroundingBox.From)
            {
                return new TimePeriod(surroundingBox.From, newPeriod.To.AddTicks((surroundingBox.From - newPeriod.From).Ticks));
            }
            if (newPeriod.To > surroundingBox.To)
            {
                return new TimePeriod(newPeriod.From.AddTicks((surroundingBox.To - newPeriod.To).Ticks), surroundingBox.To);
            }
            return newPeriod;
        }

        public TimePeriod MoveByDays(double days)
        {
            return new TimePeriod(From.AddDays(days), To.AddDays(days));
        }
    }
}