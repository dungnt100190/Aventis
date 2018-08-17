using System.Windows.Input;

using Kiss.Interfaces.ViewModel;
using Kiss.UI.ViewModel.Kbu;

namespace Kiss.UI.View.Kbu
{
    /// <summary>
    /// Interaction logic for KbuZahlungseingangView
    /// </summary>
    public partial class KbuZahlungseingangView
    {
        #region Constructors

        public KbuZahlungseingangView()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        private new KbuZahlungseingangVM ViewModel
        {
            get { return (KbuZahlungseingangVM)base.ViewModel; }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void InitViewAndViewModel()
        {
            ViewModel.Init();
        }

        #endregion

        #region Protected Methods

        protected override IViewModelCRUD GetViewModel()
        {
            return DataContext as IViewModelCRUD;
        }

        private void BetragAusgleichen_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ((KbuZahlungseingangVM)DataContext).BetragAusgleichen(e.Parameter);
        }

        private void BetragAusgleichen_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((KbuZahlungseingangVM)DataContext).CanExecuteBetragAusgleichen(e.Parameter);
        }

        private void ZahlungseingangVerbuchen_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ((KbuZahlungseingangVM)DataContext).ZahlungseingangVerbuchen(e.Parameter);
        }

        private void ZahlungseingangVerbuchen_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((KbuZahlungseingangVM)DataContext).CanExecuteZahlungseingangVerbuchen(e.Parameter);
        }

        #endregion

        #endregion
    }
}