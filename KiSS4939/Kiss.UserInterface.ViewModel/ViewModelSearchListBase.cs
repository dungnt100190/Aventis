using System.Threading;
using System.Windows.Input;
using Kiss.Interfaces.BL;
using Kiss.UserInterface.ViewModel.Commanding;
using Kiss.UserInterface.ViewModel.Interfaces;

namespace Kiss.UserInterface.ViewModel
{
    public abstract class ViewModelSearchListBase : ViewModel, IViewModelSearch
    {
        #region Fields

        #region Private Fields

        private bool _searchPanelMaximized;
        private KissServiceResult _searchValidationResult;
        private object _selectedEntity;

        #endregion

        #endregion

        #region Constructors

        protected ViewModelSearchListBase()
        {
            // ToDo: Handling von ReadyForNewSearch
            SearchTask = new AsyncTask((parameter, cancellationToken) => Search(cancellationToken));

            CommandBindings.Add(new CommandBindingToCommand(NavigationCommands.Search, SearchTask.StartCommand));
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

        public IAsyncTask SearchTask { get; private set; }

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

        public abstract KissServiceResult Search(CancellationToken cancellationToken);

        #endregion

        #region Private Methods

        //private void ExecuteSearchCommand(object o)
        //{
        //    if (ReadyForNewSearch)
        //    {
        //        // Suche durchführen
        //        if (Search())
        //        {
        //            ReadyForNewSearch = false;
        //        }

        //    }
        //    else
        //    {
        //        // Neue Suche vorbereiten
        //        ReadyForNewSearch = true;
        //    }
        //}

        #endregion

        #endregion
    }
}