namespace Kiss.Model.DTO
{
    /// <summary>
    /// DTO für die Fortschrittsanzeige
    /// einer Stapelverarbeitung.
    /// </summary>
    public class VerarbeitungsProgressDTO : DTO
    {
        #region Fields

        #region Private Fields

        private int _numErrors;
        private int _numHandled;
        private int _numTotal;

        #endregion

        #endregion

        #region Properties

        public int NumErrors
        {
            get { return _numErrors; }
            set {
                _numErrors = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => NumErrors);
            }
        }

        public int NumHandled
        {
            get { return _numHandled; }
            set {
                _numHandled = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => NumHandled);
                NotifyPropertyChanged.RaisePropertyChanged(() => Percentage);
            }
        }

        public int NumTotal
        {
            get { return _numTotal; }
            set {
                _numTotal = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => NumTotal);
                NotifyPropertyChanged.RaisePropertyChanged(() => Percentage);
            }
        }

        public int Percentage
        {
            get
            {
                if(NumTotal == 0)
                {
                    return 0;
                }
                double percentage = (double) NumHandled * 100.0 / (double) NumTotal;
                return (int) percentage;
            }
        }

        public bool IsCompleted
        {
            get
            {
                if(NumHandled >= NumTotal)
                {
                    return true;
                }
                return false;
            }
        }

        #endregion
    }
}