using System.Windows;

using Kiss.UserInterface.ViewModel.Kes;

namespace Kiss.UserInterface.View.Kes
{
    /// <summary>
    /// Interaction logic for KesLeistungView.xaml
    /// </summary>
    public partial class KesLeistungView
    {
        #region Constructors

        public KesLeistungView()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        #region Private Methods

        private void LeistungWiedereroeffnen(object sender, RoutedEventArgs e)
        {
            ((KesLeistungVM)ViewModel).LeistungWiedereroeffnen();
        }

        #endregion

        #endregion
    }
}