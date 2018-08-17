using Kiss.Model.DTO;

namespace Kiss.UI.ViewModel.Fa
{
    public class FaTimelineItemType : DTO
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

        public bool IsEnabled
        {
            get;
            set;
        }

        public int TypeID
        {
            get;
            set;
        }

        #endregion
    }
}