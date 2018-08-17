using System.Windows;
using System.Windows.Controls;

using Kiss.UserInterface.ViewModel.Interfaces;

namespace Kiss.UI.Controls
{
    public class KissTabControl : TabControl
    {
        static KissTabControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(KissTabControl), new FrameworkPropertyMetadata(typeof(KissTabControl)));
        }

        public KissTabControl()
        {
            SelectionChanged += KissTabControl_SelectionChanged;
        }

        private void KissTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tabControl = sender as KissTabControl;
            if (tabControl == null)
            {
                return;
            }

            var vmCrud = tabControl.DataContext as IViewModelCRUD;
            var vm = tabControl.DataContext as IViewModel;

            if (vmCrud == null || vm == null)
            {
                return;
            }

            vmCrud.SaveDataCommand.Execute(null);

            if (!vm.ValidationResult.IsOk)
            {
                tabControl.SelectionChanged -= KissTabControl_SelectionChanged;
                tabControl.SelectedItem = e.RemovedItems[0];
                tabControl.SelectionChanged += KissTabControl_SelectionChanged;
                e.Handled = true;
            }
        }
    }
}