using Kiss.Infrastructure;
using Kiss.Infrastructure.Constant;
using Kiss.Model.DTO.BA;

namespace Kiss.Model.DTO.Wsh
{
    /// <summary>
    /// DTO um Positionen in der Monatsbudget-Maske zu handeln
    /// </summary>
    public class WshPositionMonatBudgetDTO : DTO, IObjectWithChangeTracker
    {
        #region Fields

        #region Private Fields

        private decimal _betragMonatlich;

        /// <summary>
        /// Bei Periodizität Quartal und Semester muss der Totalbetrag ausgefüllt.
        /// Betrag Monatlich ist readonly und berechntet. (HasTotalBetrag = true).
        /// 
        /// Bei allen anderen Periodizitäten wird der Betrag ausgefüllt. Betrag Total
        /// wird gar nicht angezeigt.
        /// </summary>
        private bool _hasTotalBetrag;
        private bool _isAuszahlungDritte;
        private string _auszahlTermine;
        private BaDebitorDTO _selectedDebitor;
        private BaZahlungswegDTO _selectedZahlungsweg;
        private WshPosition _wshPosition;

        #endregion

        #endregion

        #region Properties

        public decimal? AusgabeMonatlich
        {
            get
            {
                if(!WshPosition.IstEinnahme)
                {
                    return BetragMonatlich;
                }
                return null;
            }
        }

        public decimal BetragMonatlich
        {
            get
            {
                return _betragMonatlich;
            }
            set
            {
                if(_betragMonatlich == value)
                {
                    return;
                }
                _betragMonatlich = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => BetragMonatlich);
            }
        }

        public ObjectChangeTracker ChangeTracker
        {
            get
            {
                return WshPosition.ChangeTracker;
            }
        }

        public decimal? EinnahmeMonatlich
        {
            get
            {
                if(WshPosition.IstEinnahme)
                {
                    return BetragMonatlich;
                }
                return null;
            }
        }

        public bool HasTotalBetrag
        {
            get { return _hasTotalBetrag; }
            set
            {
                if(value == _hasTotalBetrag)
                {
                    return;
                }
                _hasTotalBetrag = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => HasTotalBetrag);
            }
        }

        public bool IsAuszahlungDritte
        {
            get { return _isAuszahlungDritte; }
            set
            {
                if (_isAuszahlungDritte == value)
                {
                    return;
                }

                _isAuszahlungDritte = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => IsAuszahlungDritte);
                NotifyPropertyChanged.RaisePropertyChanged(() => SdString);
            }
        }

        public string AuszahlTermine
        {
            get
            {
                return _auszahlTermine;
            }
            set
            {
                if (_auszahlTermine == value)
                {
                    return;
                }

                _auszahlTermine = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => AuszahlTermine);
                NotifyPropertyChanged.RaisePropertyChanged(() => HasTotalBetrag);
            }
        }

        public string SdString
        {
            get
            {
                if (IsAuszahlungDritte)
                {
                    return "D";
                }

                if (WshPosition.VerwaltungSD)
                {
                    return "S";
                }

                return string.Empty;
            }
        }

        public string GdaString
        {
            get
            {
                if (WshPosition != null && WshPosition.DauerauftragAktiv)
                {
                    return "DA";
                }
                return string.Empty;
            }
        }

        public BaDebitorDTO SelectedDebitor
        {
            get { return _selectedDebitor; }
            set
            {
                if (_selectedDebitor == value)
                {
                    return;
                }

                _selectedDebitor = value;

                NotifyPropertyChanged.RaisePropertyChanged(() => SelectedDebitor);
            }
        }

        public BaZahlungswegDTO SelectedZahlungsweg
        {
            get { return _selectedZahlungsweg; }
            set
            {
                if (_selectedZahlungsweg == value)
                {
                    return;
                }

                _selectedZahlungsweg = value;

                NotifyPropertyChanged.RaisePropertyChanged(() => SelectedZahlungsweg);
            }
        }

        public WshPosition WshPosition
        {
            get { return _wshPosition; }
            set
            {
                if (_wshPosition == value)
                {
                    return;
                }

                _wshPosition = value;
                _wshPosition.PropertyChanged += WshPosition_PropertyChanged;
                NotifyPropertyChanged.RaisePropertyChanged(() => WshPosition);
                NotifyPropertyChanged.RaisePropertyChanged(() => GdaString);
            }
        }

        #endregion

        #region EventHandlers

        private void WshPosition_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == PropertyName.GetPropertyName(() => WshPosition.VerwaltungSD))
            {
                NotifyPropertyChanged.RaisePropertyChanged(() => SdString);
            }
            if(e.PropertyName == PropertyName.GetPropertyName(() => WshPosition.BetragTotal))
            {
                NotifyPropertyChanged.RaisePropertyChanged(() => BetragMonatlich);
                NotifyPropertyChanged.RaisePropertyChanged(() => AusgabeMonatlich);
                NotifyPropertyChanged.RaisePropertyChanged(() => EinnahmeMonatlich);
            }

            NotifyPropertyChanged.RaisePropertyChanged(PropertyName.GetPropertyName(() => WshPosition) + "." + e.PropertyName);
        }

        #endregion
    }
}