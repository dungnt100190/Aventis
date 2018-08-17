using System;

using Kiss.Infrastructure;

namespace Kiss.DbContext.DTO
{
    public class DateRangeSearchParamDTO : Bindable, ICloneable
    {
        private DateTime _datumBis;
        private DateTime _datumVon;

        public DateTime DatumBis
        {
            get { return _datumBis; }
            set { SetProperty(ref _datumBis, value, () => DatumBis); }
        }

        [SearchField("Datum von", FollowedBy = "DatumBis", ResourceName = "DatumVon")]
        public DateTime DatumVon
        {
            get { return _datumVon; }
            set { SetProperty(ref _datumVon, value, () => DatumVon); }
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}