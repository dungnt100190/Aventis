using Kiss.DbContext;
using Kiss.DbContext.DTO.Fa;
using Kiss.Infrastructure;
using Kiss.UserInterface.ViewModel.Properties;

namespace Kiss.UserInterface.ViewModel.Fa.Timeline
{
    public struct TimelineDrawParameters
    {
        public TimePeriod TotalRange { get; set; }

        [SearchField("Ansichtszeitraum")] // ToDo: Multilanguage
        public TimePeriod VisibleRange { get; set; }
        
        public double DayWidth { get; set; }

        [SearchField("Themen")] // ToDo: Multilanguage
        public XLOVCode[] VisibleThemenCodes { get; set; }

        //[SearchField("Typen")]
        public FaZeitachseDTOType[] VisibleItemTypes { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (obj.GetType() != typeof (TimelineDrawParameters)) return false;
            return Equals((TimelineDrawParameters) obj);
        }

        public bool Equals(TimelineDrawParameters other)
        {
            return other.TotalRange.Equals(TotalRange) && 
                   other.VisibleRange.Equals(VisibleRange) && 
                   other.DayWidth.Equals(DayWidth) && 
                   Equals(other.VisibleThemenCodes, VisibleThemenCodes) && 
                   Equals(other.VisibleItemTypes, VisibleItemTypes);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = TotalRange.GetHashCode();
                result = (result*397) ^ VisibleRange.GetHashCode();
                result = (result*397) ^ DayWidth.GetHashCode();
                result = (result*397) ^ (VisibleThemenCodes != null ? VisibleThemenCodes.GetHashCode() : 0);
                result = (result*397) ^ (VisibleItemTypes != null ? VisibleItemTypes.GetHashCode() : 0);
                return result;
            }
        }
    }
}
