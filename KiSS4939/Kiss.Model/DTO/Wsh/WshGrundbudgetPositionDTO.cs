using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using Kiss.Infrastructure;
using Kiss.Infrastructure.Constant;
using Kiss.Model.DTO.BA;

namespace Kiss.Model.DTO.Wsh
{
    public class WshGrundbudgetPositionDTO : DTO, IObjectWithChangeTracker
    {
        #region Fields

        #region Private Fields

        private int? _anzahlDokumente;
        private DateTime? _auszahlungTermin;
        private decimal _betragBerechnet;
        private bool _isAuszahlungDritte;
        private BaDebitorDTO _selectedDebitor;
        private BaZahlungswegDTO _selectedZahlungsweg;
        private WshGrundbudgetPosition _wshGrundbudgetPosition;

  

        #endregion

        #endregion

        #region Constructors

        public WshGrundbudgetPositionDTO()
        {
            // TODO AddPropertyMapping from EntityBase to PropertyMapping
            ////var wshGrundbudgetPositionString = PropertyName.GetPropertyName(() => WshGrundbudgetPosition) + ".";

            //////IstEinnahme
            ////AddPropertyMapping(
            ////    wshGrundbudgetPositionString + PropertyName.GetPropertyName(() => WshGrundbudgetPosition.WshKategorieID),
            ////    PropertyName.GetPropertyName(() => IstEinnahme));

            //////Gruppierung
            ////AddPropertyMapping(
            ////    PropertyName.GetPropertyName(() => IstEinnahme),
            ////    PropertyName.GetPropertyName(() => Gruppierung));

            //////IstEinnahmeOrHatValutaTermin
            ////AddPropertyMapping(
            ////    PropertyName.GetPropertyName(() => IstEinnahme),
            ////    PropertyName.GetPropertyName(() => IstEinnahmeOrHatFaelligAmPeriodizität));
            ////AddPropertyMapping(
            ////    wshGrundbudgetPositionString + PropertyName.GetPropertyName(() => WshGrundbudgetPosition.HatFaelligAmPeriodizität),
            ////    PropertyName.GetPropertyName(() => IstEinnahmeOrHatFaelligAmPeriodizität));

            //////SdString
            ////AddPropertyMapping(
            ////    PropertyName.GetPropertyName(() => IsAuszahlungDritte),
            ////    PropertyName.GetPropertyName(() => SdString));
            ////AddPropertyMapping(
            ////    PropertyName.GetPropertyName(() => VerwaltungSD),
            ////    PropertyName.GetPropertyName(() => SdString));

            //////FaelligAm
            ////AddPropertyMapping(
            ////    wshGrundbudgetPositionString + PropertyName.GetPropertyName(() => WshGrundbudgetPosition.FaelligAm),
            ////    PropertyName.GetPropertyName(() => AuszahlungTermin));
        }

        #endregion

        #region Properties

        public int? AnzahlDokumente
        {
            get { return _anzahlDokumente; }
            set
            {
                if(_anzahlDokumente == value)
                {
                    return;
                }

                _anzahlDokumente = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => AnzahlDokumente);
            }
        }

        public DateTime? AuszahlungTermin
        {
            get
            {
                if (IstEinnahmeOrHatFaelligAmPeriodizität)
                {
                    return WshGrundbudgetPosition.FaelligAm;
                }

                return _auszahlungTermin;
            }
            set
            {
                if (IstEinnahmeOrHatFaelligAmPeriodizität)
                {
                    WshGrundbudgetPosition.FaelligAm = value;
                }
                else
                {
                    _auszahlungTermin = value;
                }

                NotifyPropertyChanged.RaisePropertyChanged(() => AuszahlungTermin);
            }
        }

        /// <summary>
        /// Gibt den Betrag zurück, wenn die Position eine Ausgabe ist.
        /// </summary>
        public decimal? BetragAusgabe
        {
            get { return !WshGrundbudgetPosition.IstEinnahme ? (decimal?)BetragBerechnet : null; }
        }

        /// <summary>
        /// Der berechnete Betrag wird im Service berechnet.
        /// </summary>
        public decimal BetragBerechnet
        {
            get { return _betragBerechnet; }
            set
            {
                if (_betragBerechnet == value)
                {
                    return;
                }

                _betragBerechnet = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => BetragBerechnet);
            }
        }

               

        /// <summary>
        /// Gibt den Betrag zurück, wenn die Position eine Einnahme ist.
        /// </summary>
        public decimal? BetragEinnahme
        {
            get { return WshGrundbudgetPosition.IstEinnahme ? (decimal?)BetragBerechnet : null; }
        }

        public ObjectChangeTracker ChangeTracker
        {
            get { return WshGrundbudgetPosition.ChangeTracker; }
        }

        /// <summary>
        /// Zusätzliche Spalte für das Gruppieren.
        /// </summary>
        public string Gruppierung
        {
            get { return WshGrundbudgetPosition.IstEinnahme ? "Einnahmen" : "Ausgaben"; }
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

        /// <summary>
        /// Prüft, ob es eine Einnahme ist oder ob die gewählte Periodizität das 'Fällig am'-Datum erfordert.
        /// </summary>
        public bool IstEinnahmeOrHatFaelligAmPeriodizität
        {
            get
            {
                if (WshGrundbudgetPosition != null)
                {
                    return WshGrundbudgetPosition.IstEinnahme || WshGrundbudgetPosition.HatFaelligAmPeriodizität;
                }

                return false;
            }
        }

        public string KreditorDebitorInfo
        {
            get
            {
                if (WshGrundbudgetPosition.IstAusgabe && SelectedZahlungsweg == null || WshGrundbudgetPosition.IstEinnahme && SelectedDebitor == null)
                {
                    return string.Empty;
                }

                if (WshGrundbudgetPosition.IstAusgabe)
                {
                    if (WshGrundbudgetPosition.KbuAuszahlungArtCode == (int)LOVsGenerated.KbuAuszahlungArt.ElektronischeAuszahlung)
                    {
                        return SelectedZahlungsweg.Name;
                    }

                    return string.Empty;
                }

                if (WshGrundbudgetPosition.IstEinnahme)
                {
                    return SelectedDebitor.Name;
                }

                return string.Empty;
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

                if (WshGrundbudgetPosition.VerwaltungSD)
                {
                    return "S";
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

        public WshGrundbudgetPosition WshGrundbudgetPosition
        {
            get { return _wshGrundbudgetPosition; }
            set
            {
                if (_wshGrundbudgetPosition == value)
                {
                    return;
                }

                _wshGrundbudgetPosition = value;
                _wshGrundbudgetPosition.PropertyChanged += WshGrundbudgetPosition_PropertyChanged;
                NotifyPropertyChanged.RaisePropertyChanged(() => WshGrundbudgetPosition);
            }
        }

        #endregion

        #region EventHandlers

        private void WshGrundbudgetPosition_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // TODO AddPropertyMapping from EntityBase to PropertyMapping
            if (e.PropertyName == PropertyName.GetPropertyName(() => WshGrundbudgetPosition.VerwaltungSD))
            {
                NotifyPropertyChanged.RaisePropertyChanged(() => SdString);
            }
            ////if (e.PropertyName == PropertyName.GetPropertyName(() => WshGrundbudgetPosition.BetragTotal))
            ////{
            ////    NotifyPropertyChanged.RaisePropertyChanged(() => BetragMonatlich);
            ////    NotifyPropertyChanged.RaisePropertyChanged(() => AusgabeMonatlich);
            ////    NotifyPropertyChanged.RaisePropertyChanged(() => EinnahmeMonatlich);
            ////}

            NotifyPropertyChanged.RaisePropertyChanged(PropertyName.GetPropertyName(() => WshGrundbudgetPosition) + "." + e.PropertyName);
        }

        #endregion
    }
}