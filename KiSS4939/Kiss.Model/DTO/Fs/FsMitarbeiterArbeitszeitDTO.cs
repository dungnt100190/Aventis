using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

using Kiss.Infrastructure;

namespace Kiss.Model.DTO.Fs
{
    public class FsMitarbeiterArbeitszeitDTO : DTO
    {
        #region Fields

        #region Private Fields

        private decimal _bruttoArbeitszeit;
        private IDictionary<int, FsReduktionMitarbeiter> _reduktionen;
        private decimal _verfuegbareArbeitszeit;
        private string _orgUnitName;

        #endregion

        #endregion

        #region Constructors

        public FsMitarbeiterArbeitszeitDTO()
        {
            Reduktionen = new Dictionary<int, FsReduktionMitarbeiter>();
            ReduktionenZeitraum = new Dictionary<int, FsReduktionMitarbeiterZeitraumDTO>();
        }

        #endregion

        #region Properties

        public decimal BruttoArbeitszeit
        {
            get { return _bruttoArbeitszeit; }
            set
            {
                _bruttoArbeitszeit = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => BruttoArbeitszeit);
                CalculateTotal();
            }
        }

        public int JobPercentage
        {
            get;
            set;
        }

        /// <summary>
        /// Lookup FsReduktionID -> FsReduktionMitarbeiter
        /// </summary>
        public IDictionary<int, FsReduktionMitarbeiter> Reduktionen
        {
            get { return _reduktionen; }
            set
            {
                var notifyChangedOld = _reduktionen as INotifyCollectionChanged;
                if (notifyChangedOld != null)
                {
                    notifyChangedOld.CollectionChanged -= notify_CollectionChanged;
                }

                _reduktionen = value;

                var notifyChangedNew = _reduktionen as INotifyCollectionChanged;
                if (notifyChangedNew != null)
                {
                    notifyChangedNew.CollectionChanged += notify_CollectionChanged;
                }

                RegisterPropertyChanged(_reduktionen.Values);
            }
        }

        /// <summary>
        /// Lookup FsReduktionID -> FsReduktionMitarbeiter
        /// </summary>
        public IDictionary<int, FsReduktionMitarbeiterZeitraumDTO> ReduktionenZeitraum
        {
            get;
            set;
        }

        public XUser User
        {
            get;
            set;
        }

        public decimal VerfuegbareArbeitszeit
        {
            get { return _verfuegbareArbeitszeit; }
            set
            {
                _verfuegbareArbeitszeit = Math.Max(decimal.Zero, value);
                NotifyPropertyChanged.RaisePropertyChanged(() => VerfuegbareArbeitszeit);
            }
        }

        public TimePeriod Zeitraum
        {
            get;
            set;
        }

        
        public string OrgUnitName
        {
            get { return _orgUnitName; }
            set { _orgUnitName = value; }
        }
        

        #endregion

        #region EventHandlers

        void notify_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CalculateTotal();
            RegisterPropertyChanged(Reduktionen.Values);
        }

        void reduktionMa_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            CalculateTotal(); 
        }

        #endregion

        #region Methods

        #region Private Methods

        private void CalculateTotal()
        {
            VerfuegbareArbeitszeit = BruttoArbeitszeit - Reduktionen.Sum(f => f.Value.GueltigeReduktionZeit ?? f.Value.OriginalReduktionZeit);
        }

        private void RegisterPropertyChanged(IEnumerable<FsReduktionMitarbeiter> reduktionenZeitraum)
        {
            foreach (INotifyPropertyChanged reduktionMa in reduktionenZeitraum)
            {
                reduktionMa.PropertyChanged -= reduktionMa_PropertyChanged;
                reduktionMa.PropertyChanged += reduktionMa_PropertyChanged;
            }
        }

        #endregion

        #endregion
    }
}