namespace Kiss.Model.DTO.Wsh
{
    public class WshAuszahlvorschlagBelegPositionDTO : DTO
    {
        #region Fields

        #region Private Fields

        private decimal? _ausgabe;
        private WshAuszahlvorschlagBelegDTO _beleg;
        private decimal? _einnahme;

        #endregion

        #endregion

        #region Constructors

        public WshAuszahlvorschlagBelegPositionDTO(WshAuszahlvorschlagBelegDTO beleg)
        {
            _beleg = beleg;
        }

        #endregion

        #region Properties

        public decimal? Ausgabe
        {
            get { return _ausgabe; }
            set
            {
                if (_ausgabe == value)
                {
                    return;
                }

                _ausgabe = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => Ausgabe);
            }
        }

        public WshAuszahlvorschlagBelegDTO Beleg
        {
            get { return _beleg; }
        }

        public decimal? Einnahme
        {
            get { return _einnahme; }
            set
            {
                if (_einnahme == value)
                {
                    return;
                }

                _einnahme = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => Einnahme);
            }
        }

        public WshPosition WshPosition
        {
            get; set;
        }

        #endregion
    }
}