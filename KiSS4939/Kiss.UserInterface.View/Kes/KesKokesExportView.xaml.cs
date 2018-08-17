using System.Windows;

using Kiss.UserInterface.View.LocalResources.Kes;
using Kiss.UserInterface.ViewModel.Kes;

using Microsoft.Win32;

namespace Kiss.UserInterface.View.Kes
{
    /// <summary>
    /// Interaction logic for KesKokesExportView
    /// </summary>
    public partial class KesKokesExportView
    {
        public KesKokesExportView()
        {
            InitializeComponent();
        }

        private void BtnExport_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog
            {
                Title = KesKokesExportViewRes.SpeichernUnter,
                DefaultExt = ".xml",
                AddExtension = true,
                CheckPathExists = true,
                Filter = KesKokesExportViewRes.SpeichernUnterFilter
            };

            if (dialog.ShowDialog() == true)
            {
                var vm = (KesKokesExportVM)ViewModel;
                vm.PerformExport(dialog.FileName);
            }
        }

        private void BtnGotoMassnahme_Click(object sender, RoutedEventArgs e)
        {
            var vm = (KesKokesExportVM)ViewModel;
            vm.GotoMassnahme();
        }
    }
}