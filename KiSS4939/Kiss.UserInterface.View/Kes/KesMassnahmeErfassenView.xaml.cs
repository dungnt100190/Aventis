using Kiss.DbContext;
using Kiss.UI.Controls;
using Kiss.UserInterface.ViewModel.Kes;

namespace Kiss.UserInterface.View.Kes
{
    /// <summary>
    /// Interaction logic for KesMassnahmeErfassenView.xaml
    /// </summary>
    public partial class KesMassnahmeErfassenView
    {
        #region Constructors

        public KesMassnahmeErfassenView()
        {
            InitializeComponent();
        }

        #endregion

        private KesMassnahmeVM KesMassnahmeVM
        {
            get { return (KesMassnahmeVM)ViewModel; }
        }
    }
}