
namespace Kiss.Infrastructure
{
    public static class RangeExtensionMethods
    {
        public static long GetRange(this Range<long> range)
        {
            return range.To - range.From;
        }
    }
}
