using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Kiss.Infrastructure.Enumeration;

namespace Kiss.Model.DTO.Wsh
{
    public class WshKategorieKontoDTO : DTO, IObjectWithChangeTracker
    {
        #region Fields

        #region Private Fields

        private ObjectChangeTracker _changeTracker;
        private WshKategorieKbuKontoVerfuegbar _verfuegbarAlsAbzahlung = WshKategorieKbuKontoVerfuegbar.Nein;
        private WshKategorieKbuKontoVerfuegbar _verfuegbarAlsAusgabe = WshKategorieKbuKontoVerfuegbar.Nein;
        private WshKategorieKbuKontoVerfuegbar _verfuegbarAlsEinnahme = WshKategorieKbuKontoVerfuegbar.Nein;
        private WshKategorieKbuKontoVerfuegbar _verfuegbarAlsKuerzung = WshKategorieKbuKontoVerfuegbar.Nein;
        private WshKategorieKbuKontoVerfuegbar _verfuegbarAlsRueckerstattung = WshKategorieKbuKontoVerfuegbar.Nein;
        private WshKategorieKbuKontoVerfuegbar _verfuegbarAlsSanktion = WshKategorieKbuKontoVerfuegbar.Nein;
        private WshKategorieKbuKontoVerfuegbar _verfuegbarAlsVermoegen = WshKategorieKbuKontoVerfuegbar.Nein;
        private WshKategorieKbuKontoVerfuegbar _verfuegbarAlsVerrechnung = WshKategorieKbuKontoVerfuegbar.Nein;
        private WshKategorieKbuKontoVerfuegbar _verfuegbarAlsVorabzug = WshKategorieKbuKontoVerfuegbar.Nein;

        #endregion

        #endregion

        #region Properties

        public ObjectChangeTracker ChangeTracker
        {
            get
            {
                if (_changeTracker == null)
                {
                    _changeTracker = new ObjectChangeTracker();
                }
                return _changeTracker;
            }
            set
            {
                _changeTracker = value;
            }
        }

        public int KbuKontoID
        {
            get;
            set;
        }

        public string KontoName
        {
            get;
            set;
        }

        public string KontoNr
        {
            get;
            set;
        }

        public WshKategorieKbuKontoVerfuegbar VerfuegbarAlsAbzahlung
        {
            get { return _verfuegbarAlsAbzahlung; }
            set
            {
                if (_verfuegbarAlsAbzahlung == value)
                {
                    return;
                }
                _verfuegbarAlsAbzahlung = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => VerfuegbarAlsAbzahlung);
                UpdateChangeTracker();
            }
        }

        public WshKategorieKbuKontoVerfuegbar VerfuegbarAlsAusgabe
        {
            get { return _verfuegbarAlsAusgabe; }
            set
            {
                if (_verfuegbarAlsAusgabe == value)
                {
                    return;
                }
                _verfuegbarAlsAusgabe = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => VerfuegbarAlsAusgabe);
                UpdateChangeTracker();
            }
        }

        public WshKategorieKbuKontoVerfuegbar VerfuegbarAlsEinnahme
        {
            get { return _verfuegbarAlsEinnahme; }
            set
            {
                if (_verfuegbarAlsEinnahme == value)
                {
                    return;
                }
                _verfuegbarAlsEinnahme = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => VerfuegbarAlsEinnahme);
                UpdateChangeTracker();
            }
        }

        public WshKategorieKbuKontoVerfuegbar VerfuegbarAlsKuerzung
        {
            get { return _verfuegbarAlsKuerzung; }
            set
            {
                if (_verfuegbarAlsKuerzung == value)
                {
                    return;
                }
                _verfuegbarAlsKuerzung = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => VerfuegbarAlsKuerzung);
                UpdateChangeTracker();
            }
        }

        public WshKategorieKbuKontoVerfuegbar VerfuegbarAlsRueckerstattung
        {
            get { return _verfuegbarAlsRueckerstattung; }
            set
            {
                if (_verfuegbarAlsRueckerstattung == value)
                {
                    return;
                }
                _verfuegbarAlsRueckerstattung = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => VerfuegbarAlsRueckerstattung);
                UpdateChangeTracker();
            }
        }

        public WshKategorieKbuKontoVerfuegbar VerfuegbarAlsSanktion
        {
            get { return _verfuegbarAlsSanktion; }
            set
            {
                if (_verfuegbarAlsSanktion == value)
                {
                    return;
                }
                _verfuegbarAlsSanktion = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => VerfuegbarAlsSanktion);
                UpdateChangeTracker();
            }
        }

        public WshKategorieKbuKontoVerfuegbar VerfuegbarAlsVermoegen
        {
            get { return _verfuegbarAlsVermoegen; }
            set
            {
                if (_verfuegbarAlsVermoegen == value)
                {
                    return;
                }
                _verfuegbarAlsVermoegen = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => VerfuegbarAlsVermoegen);
                UpdateChangeTracker();
            }
        }

        public WshKategorieKbuKontoVerfuegbar VerfuegbarAlsVerrechnung
        {
            get { return _verfuegbarAlsVerrechnung; }
            set
            {
                if (_verfuegbarAlsVerrechnung == value)
                {
                    return;
                }
                _verfuegbarAlsVerrechnung = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => VerfuegbarAlsVerrechnung);
                UpdateChangeTracker();
            }
        }

        public WshKategorieKbuKontoVerfuegbar VerfuegbarAlsVorabzug
        {
            get { return _verfuegbarAlsVorabzug; }
            set
            {
                if (_verfuegbarAlsVorabzug == value)
                {
                    return;
                }
                _verfuegbarAlsVorabzug = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => VerfuegbarAlsVorabzug);
                UpdateChangeTracker();
            }
        }

        #endregion

        #region Methods

        #region Private Methods

        private void UpdateChangeTracker()
        {
            if (ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
            {
                ChangeTracker.State = ObjectState.Modified;
            }
        }

        #endregion

        #endregion
    }
}