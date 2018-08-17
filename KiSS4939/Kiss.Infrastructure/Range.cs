using System;

namespace Kiss.Infrastructure
{
    public struct Range<T>
        where T : IComparable<T>
    {
        #region Constructors

        public Range(T from, T to)
            : this()
        {
            if (from.CompareTo(to) > 0)
            {
                throw new ArgumentException("'from' must be smaller than 'to'");
            }
            From = from;
            To = to;
        }

        #endregion

        #region Properties

        public T From { get; private set; }

        public T To { get; private set; }

        #endregion

        #region Methods

        #region Public Static Methods

        public static bool operator ==(Range<T> lhs, Range<T> rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Range<T> lhs, Range<T> rhs)
        {
            return !(lhs == rhs);
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return string.Format("{0} - {1}", From, To);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (obj.GetType() != typeof(TimePeriod)) return false;
            return Equals((TimePeriod)obj);
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
    }
}
