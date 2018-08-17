using Kiss.UI.ViewModel;

namespace Kiss.UI.View
{
    public class KissAbfrageBaseView : KissView
    {
        #region Fields

        #region Private Fields

        private ViewModelSearchListBase _searchListBaseVM;

        #endregion

        #endregion

        #region Constructors

        public KissAbfrageBaseView()
        {
            Loaded += KissAbfrageBaseView_Loaded;
        }

        #endregion

        #region Properties

        public ViewModelSearchListBase SearchListBaseVM
        {
            get { return _searchListBaseVM ?? (_searchListBaseVM = GetViewModelSearchList()); }
        }

        #endregion

        #region EventHandlers

        private void KissAbfrageBaseView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (SearchListBaseVM != null)
            {
                //CommandBindings.Add(new CommandBindingToCommand(NavigationCommands.Search, SearchListBaseVM.SearchCommand));
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override bool AddData()
        {
            return true;
        }

        public override bool DeleteData()
        {
            return true;
        }

        public override void RefreshData()
        {
        }

        public override bool SaveData()
        {
            return true;
        }

        public override void Search()
        {
            if (SearchListBaseVM.SearchCommand.CanExecute(null))
            {
                SearchListBaseVM.SearchCommand.Execute(null);
            }
        }

        public override void UndoDataChanges()
        {
        }

        #endregion

        #region Protected Methods

        protected virtual ViewModelSearchListBase GetViewModelSearchList()
        {
            return null;
        }

        #endregion

        #endregion
    }
}