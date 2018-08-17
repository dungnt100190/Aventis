using System;
using System.ComponentModel;

namespace Kiss.Model.DTO.Kbu
{
    public class KbuBelegLaufDTO : DTO
    {
        #region Fields

        #region Private Fields

        private long? _belegnummer;
        private decimal _betrag;
        private string _kient;
        private string _errorMessage;
        private int? _faFallID;
        private int _kbuBelegID;
        private int? _kbuTransferLaufKbuBelegID;
        private string _text;
        private DateTime? _valutaDatum;        
        private int? _verbuchungsLauf;
        private bool _selected = true; 
              

        #endregion

        #endregion

        #region Properties

        public long? Belegnummer
        {
            get { return _belegnummer; }
            set {
                _belegnummer = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => Belegnummer);
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


        public int KbuBelegID
        {
            get { return _kbuBelegID; }

            set 
            { 
                _kbuBelegID = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => KbuBelegID);
            }
        }

        public decimal Betrag
        {
            get { return _betrag; }
            set {
                _betrag = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => Betrag);
            }
        }

        public string Klient
        {
            get { return _kient; }
            set {
                _kient = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => Klient);
            }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => ErrorMessage);
            }
        }

        public int? FaFallID
        {
            get { return _faFallID; }
            set {
                _faFallID = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => FaFallID);
            }
        }

        public int? KbuTransferLaufKbuBelegID
        {
            get { return _kbuTransferLaufKbuBelegID; }
            set {
                _kbuTransferLaufKbuBelegID = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => KbuTransferLaufKbuBelegID);
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

        public DateTime? ValutaDatum
        {
            get { return _valutaDatum; }
            set
            {
                _valutaDatum = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => ValutaDatum);
            }
        }

        public int? TageValuta
        {
            get { 
                DateTime today = DateTime.Today;
                if(ValutaDatum.HasValue)
                {
                    TimeSpan ts = ValutaDatum.Value - today;
                    return ts.Days;
                }                
                return null;                
            }
            
        }

        public int? VerbuchungsLauf
        {
            get { return _verbuchungsLauf; }
            set
            {
                _verbuchungsLauf = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => VerbuchungsLauf);
            }
        }

        #endregion
    }
}