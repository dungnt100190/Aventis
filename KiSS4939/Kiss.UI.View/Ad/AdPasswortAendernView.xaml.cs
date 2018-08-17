using System.Windows;
using System.Windows.Input;

using Kiss.Interfaces.ViewModel;
using Kiss.UI.View.LocalResources.Ad;
using Kiss.UI.ViewModel.Ad;

namespace Kiss.UI.View.Ad
{
    /// <summary>
    /// Interaction logic for AdPasswortAendernView
    /// </summary>
    public partial class AdPasswortAendernView
    {
        #region Constructors

        public AdPasswortAendernView()
        {
            InitializeComponent();
            edtAltesPasswort.Focus();
        }

        #endregion

        #region Properties

        private new AdPasswortAendernVM ViewModel
        {
            get { return (AdPasswortAendernVM)GetViewModel(); }
        }

        #endregion

        #region EventHandlers

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            ValidationResult = ViewModel.SaveNewPassword(edtAltesPasswort.Text, edtNeuesPasswort.Text, edtNeuesPasswortWh.Text);

            if (ValidationResult.IsOk)
            {
                ViewModel.RaiseMessage(AdPasswortAendernViewRes.PasswortErfolgreichGeaendert, ValidationResult);
                ViewHelper.CloseDialog(this, true);
            }
            else
            {
                ViewModel.RaiseMessage(AdPasswortAendernViewRes.FehlerBeimPasswortAendern, ValidationResult);
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void InitViewAndViewModel()
        {
            ViewModel.Init();
        }

        #endregion

        #endregion
    }
}