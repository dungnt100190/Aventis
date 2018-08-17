using System.ComponentModel;

using Kiss.Infrastructure;

namespace Kiss.UI.Controls.ViewModel
{
    /// <summary>
    /// Base class of control's view model. 
    /// This implements the interface <see cref="INotifyPropertyChanged"/>.
    /// </summary>
    public class ControlViewModelBase : INotifyPropertyChanged
    {
        #region Fields

        #region Private Fields

        private NotifyPropertyChanged _notifyPropertyChanged;

        #endregion

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        protected NotifyPropertyChanged NotifyPropertyChanged
        {
            get
            {
                return _notifyPropertyChanged ?? (_notifyPropertyChanged = new NotifyPropertyChanged(this, () => PropertyChanged));
            }
        }

        #endregion
    }
}