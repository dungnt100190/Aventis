using Kiss.Model.DTO;

namespace Kiss.UI.Controls
{
    public class KissCheckedLookupItem : DTO
    {
        #region Fields

        #region Private Fields

        private bool _isChecked;

        #endregion

        #endregion

        #region Properties

        public string Description
        {
            get;
            set;
        }

        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                if(_isChecked == value)
                    return;

                _isChecked = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => IsChecked);
            }
        }

        public int TypeID
        {
            get;
            set;
        }

        #endregion
    }
}