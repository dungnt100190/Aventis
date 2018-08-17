using System.Collections.Specialized;

using Kiss.UI.ViewModel.Vm;

using DevExpress.Xpf.Grid;

namespace Kiss.UI.View.Vm
{
    /// <summary>
    /// Interaction logic for VmKlientenBudgetView
    /// </summary>
    public partial class VmKlientenbudgetView
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string VM_KLIENTENBUDGET_MESSAGE_KEY = "VmKlientenbudgetID";

        #endregion

        #region Private Fields

        private bool _isSaveing;
        private bool _isUndoing;

        #endregion

        #endregion

        #region Constructors

        public VmKlientenbudgetView()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        private new VmKlientenbudgetVM ViewModel
        {
            get { return (VmKlientenbudgetVM)GetViewModel(); }
        }

        #endregion

        #region EventHandlers

        void ViewModel_SelectedEntityChanged(Model.DTO.Vm.VmKlientenbudgetDTO selectedEntity, Model.DTO.Vm.VmKlientenbudgetDTO deselectedEntity)
        {
            scrollViewerPosition.ScrollToVerticalOffset(0);
        }

        private void btnToggleEditMode_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (_isUndoing || _isSaveing)
            {
                return;
            }

            var result = ViewModel.SaveData(null);

            if (!result)
            {
                btnToggleEditMode.IsChecked = true;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void InitViewAndViewModel()
        {
            ViewModel.Init();
            ViewModel.SelectedEntityChanged += ViewModel_SelectedEntityChanged;
            ((TableView)grdBudgets.View).BestFitColumns();
        }

        public override void InitViewAndViewModel(int faLeistungId)
        {
            ViewModel.Init(faLeistungId);
            ViewModel.SelectedEntityChanged += ViewModel_SelectedEntityChanged;
            ((TableView)grdBudgets.View).BestFitColumns();
        }

        public override bool ReceiveMessage(HybridDictionary parameters)
        {
            if (parameters.Contains(VM_KLIENTENBUDGET_MESSAGE_KEY))
            {
                var msg = parameters[VM_KLIENTENBUDGET_MESSAGE_KEY];

                if (msg is int)
                {
                    ViewModel.SelectBudget((int)msg);
                }
            }

            return base.ReceiveMessage(parameters);
        }

        public override bool SaveData()
        {
            bool result;
            try
            {
                _isSaveing = true;
                result = base.SaveData();
            }
            finally
            {
                _isSaveing = false;
            }

            return result;
        }

        public override void UndoDataChanges()
        {
            try
            {
                _isUndoing = true;
                base.UndoDataChanges();
            }
            finally
            {
                _isUndoing = false;
            }
        }

        #endregion

        #endregion
    }
}