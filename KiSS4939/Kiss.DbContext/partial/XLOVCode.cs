

namespace Kiss.DbContext
{
    public partial class XLOVCode
    {
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != typeof(XLOVCode))
            {
                return false;
            }
            return Equals((XLOVCode)obj);
        }

        public bool Equals(XLOVCode other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Equals(other._lOVName, _lOVName) && other._code == _code;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_lOVName != null ? _lOVName.GetHashCode() : 0) * 397) ^ _code;
            }
        }
    }
}
