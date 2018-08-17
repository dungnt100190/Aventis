using System;

namespace Kiss.DbContext
{
    partial class KesMassnahmeBericht
    {
        private DateTime? _datumBericht;
        private DateTime? _datumRechnung;

        public DateTime? DatumBericht
        {
            get { return _datumBericht; }
            set
            {
                if (_datumBericht != value)
                {
                    _datumBericht = value;
                    RaisePropertyChanged("DatumBericht");
                }
            }
        }

        public DateTime? DatumRechnung
        {
            get { return _datumRechnung; }
            set
            {
                if (_datumRechnung != value)
                {
                    _datumRechnung = value;
                    RaisePropertyChanged("DatumRechnung");
                }
            }
        }
    }
}