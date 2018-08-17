using Kiss.Interfaces.ViewModel;
using Kiss.UI.ViewModel.Wsh;

using DevExpress.Xpf.Grid;

namespace Kiss.UI.View.Wsh
{
    /// <summary>
    /// Interaction logic for WshAbzugBudgetPositionView
    /// </summary>
    public partial class WshAbzugBudgetPositionView
    {
        #region Constructors

        public WshAbzugBudgetPositionView()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public new WshAbzugBudgetPositionVM ViewModel
        {
            get { return (WshAbzugBudgetPositionVM)base.ViewModel; }
        }

        #endregion

        #region EventHandlers

        private void grdWshBudgetPosition_CustomUnboundColumnData(object sender, GridColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "StatusIconUnbound")
            {
                if (e.IsGetData)
                {
                    e.Value = ViewModel.GetPositionsStatusImage(e.ListSourceRowIndex);
                }
            }
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override IViewModelCRUD GetViewModel()
        {
            return FindResource("viewModel") as IViewModelCRUD;
        }

        #endregion

        #endregion
    }
}