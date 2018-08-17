using System.Windows.Controls;
using DevExpress.Xpf.Core;
using Kiss.Interfaces.UI;
using Kiss.Model.DTO.Fa;
using Kiss.UI.ViewModel.Fa;
using Container = Kiss.Infrastructure.IoC.Container;

namespace Kiss.UI.View.Fa
{
    /// <summary>
    /// Interaction logic for FaZeitachseListeView.xaml
    /// </summary>
    public partial class FaZeitachseListeView
    {
        #region Constructors

        public FaZeitachseListeView()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void RefreshData()
        {
            base.RefreshData();

            Search();
        }

        #endregion

        private void TableView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            FaZeitachseContainerVM viewModel = DataContext as FaZeitachseContainerVM; 
            if(viewModel != null)
            {
                var dto = viewModel.SelectedEntity as FaZeitachseDTO;

                if (dto != null && !string.IsNullOrWhiteSpace(dto.JumpToPath))
                {
                    var formController = Container.Resolve<IKissFormController>();
                    string className;
                    var parameters = formController.ConvertToParameterArray(dto.JumpToPath, out className);
                    formController.OpenForm(className, parameters);
                }              
            }

                 
        }

        #endregion
    }
}