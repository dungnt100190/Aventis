using System;

namespace Kiss.Model.DTO.Wsh
{
    /// <summary>
    /// DTO Objekt für den Berechneten GBL.
    /// </summary>
    public class WshGrundbudgetVorschlagDTO : DTO, IObjectWithChangeTracker
    {
        #region Fields

        #region Private Fields

        private decimal _ausgaben;
        private int? _baPersonId;
        private string _betrifft;
        private decimal _einnahmen;
        private int _kontoId;
        private string _kontoNr;
        private string _kontoText;
        private bool _selected = true;
        private string _text;

        #endregion

        #endregion

        #region Properties

        public decimal Ausgaben
        {
            get { return _ausgaben; }
            set
            {
                _ausgaben = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => Ausgaben);
            }
        }

        public int? BaPersonID
        {
            get { return _baPersonId; }
            set
            {
                _baPersonId = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => BaPersonID);
            }
        }

        public string Betrifft
        {
            get { return _betrifft; }
            set
            {
                _betrifft = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => Betrifft);
            }
        }

        public ObjectChangeTracker ChangeTracker
        {
            get { throw new NotSupportedException(); }
        }

        public decimal Einnahmen
        {
            get { return _einnahmen; }
            set
            {
                _einnahmen = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => Einnahmen);
            }
        }

        public int KontoID
        {
            get { return _kontoId; }
            set
            {
                _kontoId = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => KontoID);
            }
        }

        public string KontoNr
        {
            get { return _kontoNr; }
            set
            {
                _kontoNr = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => KontoNr);
            }
        }

        public string KontoText
        {
            get { return _kontoText; }
            set
            {
                _kontoText = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => KontoText);
            }
        }

        public bool Selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => Selected);
            }
        }

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => Text);
            }
        }

        #endregion
    }
}