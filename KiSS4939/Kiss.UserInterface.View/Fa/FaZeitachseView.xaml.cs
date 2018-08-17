

namespace Kiss.UserInterface.View.Fa
{
    /// <summary>
    /// Interaction logic for FaZeitachseView.xaml
    /// </summary>
    public partial class FaZeitachseView
    {
        #region Constructors

        public FaZeitachseView()
        {
            InitializeComponent();
        }

        #endregion

        private void DateRangeSlider_RequestVisibleRangeMove(object sender, Interfaces.EventArgs<Infrastructure.TimePeriod> e)
        {
            // ToDo: EventToCommandBinding
            var vm = DataContext as Kiss.UserInterface.ViewModel.Fa.FaZeitachseContainerVM;
            vm.MoveVisibleRangeTo(e.Parameter);
        }
    }
}