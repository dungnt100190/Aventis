using System;

using Kiss.Infrastructure;

namespace Kiss.Model.DTO
{
    public class DateRangeSearchParamDTO : DTO
    {
        #region Fields

        #region Private Fields

        private DateTime _datumBis;
        private DateTime _datumVon;

        #endregion

        #endregion

        #region Properties

        public DateTime DatumBis
        {
            get { return _datumBis; }
            set
            {
                if (_datumBis == value)
                {
                    return;
                }

                _datumBis = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => DatumBis);
            }
        }

        [SearchField("Datum", FollowedBy = "DatumBis")]
        public DateTime DatumVon
        {
            get { return _datumVon; }
            set
            {
                if (_datumVon == value)
                {
                    return;
                }

                _datumVon = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => DatumVon);
            }
        }

        #endregion
    }
}