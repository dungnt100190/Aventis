using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Kiss.Infrastructure;

namespace Kiss.Model.DTO.Kbu
{
    public class KbuErwarteteEinnahmeDTO : DTO
    {
        #region Fields

        #region Private Fields

        private decimal _betragAuszugleichen;
        private decimal _betragOffen;

        #endregion

        #endregion

        #region Properties

        public int? BaInstitutionIDDebitor
        {
            get; set;
        }

        public int? BaPersonIDDebitor
        {
            get; set;
        }

        /// <summary>
        /// Hilfswert für Maske: Der ausgeglichene Betrag zwischen dem selektierten Beleg und der erwarteten Einnahme
        /// </summary>
        public decimal BetragAuszugleichen
        {
            get { return _betragAuszugleichen; }
            set
            {
                if (_betragAuszugleichen == value)
                {
                    return;
                }
                _betragAuszugleichen = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => BetragAuszugleichen);
            }
        }

        public decimal BetragOffen
        {
            get { return _betragOffen; }
            set
            {
                if (_betragOffen == value)
                {
                    return;
                }
                _betragOffen = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => BetragOffen);
            }
        }

        public decimal BetragTotal
        {
            get; set;
        }

        public string DebitorText
        {
            get; set;
        }

        public DateTime FaelligAm
        {
            get; set;
        }

        public int KbuKontoID
        {
            get; set;
        }

        public string KontoNr
        {
            get; set;
        }

        public string Kostenstelle
        {
            get; set;
        }

        public string Text
        {
            get; set;
        }

        public TimePeriod Verwendungsperiode
        {
            get; set;
        }

        public int? WshPositionID
        {
            get; set;
        }

        #endregion
    }
}