using Kiss.Interfaces.BL;
using Kiss.Interfaces.ViewModel;
using Kiss.UI.ViewModel.Commanding;

namespace Kiss.UI.ViewModel
{
    public abstract class ViewModelSearchListBase : ViewModelBase, IViewModelSearch
    {
        #region Fields

        #region Private Fields

        private IAsyncCommand _searchCommand;
        private bool _searchPanelMaximized;
        private KissServiceResult _searchValidationResult;
        private object _selectedEntity;

        #endregion

        #endregion

        #region Constructors

        protected ViewModelSearchListBase()
        {
            SearchCommand = new AsyncDelegateCommand<object>(ExecuteSearchCommand);
            SearchCommand.Executed += (s, e) => SearchCommand.IsExecuteEnabled = SearchCommand.CanExecute(null);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets if a new search is being prepared
        /// </summary>
        public bool ReadyForNewSearch
        {
            get { return _searchPanelMaximized; }
            set
            {
                _searchPanelMaximized = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => ReadyForNewSearch);
            }
        }

        /// <summary>
        /// Command to start a search or prepare a new one (function toggles)
        /// </summary>
        public IAsyncCommand SearchCommand
        {
            get { return _searchCommand; }
            protected set
            {
                _searchCommand = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => SearchCommand);
            }
        }

        public KissServiceResult SearchValidationResult
        {
            get { return _searchValidationResult; }
            protected set
            {
                _searchValidationResult = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => SearchValidationResult);
            }
        }

        /// <summary>
        /// Gets or sets the selected entity
        /// </summary>
        public object SelectedEntity
        {
            get { return _selectedEntity; }
            set
            {
                _selectedEntity = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => SelectedEntity);
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public abstract KissServiceResult Search(IUnitOfWork unitOfWork);

        #endregion

        #region Private Methods

        private void ExecuteSearchCommand(object o)
        {
            if (ReadyForNewSearch)
            {
                // Suche durchführen
                if (Search(null))
                {
                    ReadyForNewSearch = false;
                }

            }
            else
            {
                // Neue Suche vorbereiten
                ReadyForNewSearch = true;
            }
        }

        #endregion

        #endregion
    }
}