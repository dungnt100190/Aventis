using System;
using System.ComponentModel;

using Kiss.Infrastructure;

namespace Kiss.Model.DTO.Fa
{
    public class FaKategorisierungDTO : ChangeTrackingDTO
    {
        #region Fields

        #region Private Fields

        private FaKategorisierung _faKategorisierung;
        private DateTime? _frist;
        private string _kategorie;
        private string _sar;
        private string _team;

        #endregion

        #endregion

        #region Properties

        public FaKategorisierung FaKategorisierung
        {
            get { return _faKategorisierung; }
            set
            {
                if (_faKategorisierung == value)
                {
                    return;
                }

                if (_faKategorisierung != null)
                {
                    _faKategorisierung.PropertyChanged -= FaKategorisierung_PropertyChanged;
                }

                _faKategorisierung = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => FaKategorisierung);

                if (_faKategorisierung != null)
                {
                    _faKategorisierung.PropertyChanged += FaKategorisierung_PropertyChanged;
                }
            }
        }

        public DateTime? Frist
        {
            get { return _frist; }
            set { SetProperty(ref _frist, value, () => Frist); }
        }

        public string Kategorie
        {
            get { return _kategorie; }
            set { SetProperty(ref _kategorie, value, () => Kategorie); }
        }

        public string SAR
        {
            get { return _sar; }
            set { SetProperty(ref _sar, value, () => SAR); }
        }

        public string Team
        {
            get { return _team; }
            set { SetProperty(ref _team, value, () => Team); }
        }

        #endregion

        #region EventHandlers

        private void FaKategorisierung_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            NotifyPropertyChanged.RaisePropertyChanged(PropertyName.GetPropertyName(() => FaKategorisierung) + "." + e.PropertyName);
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override ObjectChangeTracker GetChangeTracker()
        {
            return FaKategorisierung != null ? FaKategorisierung.ChangeTracker : null;
        }

        #endregion

        #endregion
    }
}