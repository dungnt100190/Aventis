using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

using Kiss.Infrastructure.Enumeration;

namespace Kiss.Model.DTO.Wsh
{
    public class WshAuszahlvorschlagBelegDTO : DTO
    {
        #region Fields

        #region Private Fields

        private List<WshAuszahlvorschlagBelegPositionDTO> _belegPositionen;
        private WshAuszahlvorschlagStatus _status;

        #endregion

        #endregion

        #region Properties

        public decimal AuszahlbetragNetto
        {
            get
            {
                if (BelegPositionen == null)
                {
                    return 0;
                }

                // TODO unitTest
                return BelegPositionen.Sum(b => b.Ausgabe ?? 0) - BelegPositionen.Sum(b => b.Einnahme ?? 0);
            }
        }

        public List<WshAuszahlvorschlagBelegPositionDTO> BelegPositionen
        {
            get { return _belegPositionen; }
            set
            {
                if (_belegPositionen == value)
                {
                    return;
                }
               
                _belegPositionen = value;               

                NotifyPropertyChanged.RaisePropertyChanged(() => AuszahlbetragNetto);
            }
        }




        /// <summary>
        /// Ein Property einer Position eines Belegs hat sich geändert.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void PositionPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            NotifyPropertyChanged.RaisePropertyChanged(() => AuszahlbetragNetto);
        }


     
        public void RegisterPositionPropertyChangedEventHandler()
        {
            foreach (var belegPosition in BelegPositionen)
            {
                belegPosition.PropertyChanged += PositionPropertyChanged;
            }     
        }


        public bool HatEinnahmePositionen
        {
            get
            {
                if (Status.EnumValue == WshAuszahlvorschlagStatus.Vorschlag)
                {
                    return true;
                }

                bool hatEinnahmePositionen = false;
                BelegPositionen.ToList().ForEach(bp => hatEinnahmePositionen |= bp.Einnahme.HasValue);
                return hatEinnahmePositionen;
            }
        }

        public WshAuszahlvorschlagKreditorDTO Kreditor
        {
            get; set;
        }

        public WshAuszahlvorschlagStatusWrapper Status
        {
            get { return _status; }
            set
            {
                if (_status == value)
                {
                    return;
                }

                _status = value;

                NotifyPropertyChanged.RaisePropertyChanged(() => Status);
                NotifyPropertyChanged.RaisePropertyChanged(() => IsVorschlag);
                NotifyPropertyChanged.RaisePropertyChanged(() => IsFreigegeben);
                NotifyPropertyChanged.RaisePropertyChanged(() => IsNotFreigegeben);
            }
        }

        public bool IsVorschlag
        {
            get { return Status == WshAuszahlvorschlagStatus.Vorschlag; }           
        }

        public bool IsFreigegeben
        {
            get { return Status == WshAuszahlvorschlagStatus.Freigegeben; }
        }

        public bool IsNotFreigegeben
        {
            get { return !IsFreigegeben; }
        }


        public DateTime Valuta
        {
            get; set;
        }

        #endregion
    }
}