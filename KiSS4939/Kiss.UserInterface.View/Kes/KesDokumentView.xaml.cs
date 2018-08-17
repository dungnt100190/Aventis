using System;
using System.Windows;

using DevExpress.Xpf.Editors;

using Kiss.UserInterface.View.LocalResources.Kes;
using Kiss.UserInterface.ViewModel.Kes;

using Microsoft.Win32;

namespace Kiss.UserInterface.View.Kes
{
    /// <summary>
    /// Interaction logic for KesPraeventionView.xaml
    /// </summary>
    public partial class KesDokumentView
    {
        public KesDokumentView()
        {
            InitializeComponent();
        }

        private KesDokumentVM KesDokumentVM
        {
            get { return (KesDokumentVM)ViewModel; }
        }

        private void BtnDokumenteExportieren_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog
            {
                AddExtension = true,
                DefaultExt = ".pdf",
                Filter = KesDokumentViewRes.PdfDateien + " (*.pdf)|*.pdf"
            };

            var result = dialog.ShowDialog();

            if (result == true)
            {
                var pdfFileName = dialog.FileName;
                KesDokumentVM.DokumenteExportieren(pdfFileName);
            }
        }

        private void KesDokumentResultat_PopupOpening(object sender, OpenPopupEventArgs e)
        {
            KesDokumentVM.FilterKesDokumentResultatCodes();
        }

        private void SelectionChanged(object sender, EventArgs e)
        {
            KesDokumentVM.HasSelection = true;
        }
    }
}