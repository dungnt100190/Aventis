using System;

using KiSS4.DB;
using KiSS4.Main;

namespace KiSS4.WordDocumentRepair
{
    public partial class CtlWordDocumentRepairLogin : Gui.KissUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string STATUS_LOGIN_CONNECTED = "Eingeloggter Benutzer: {0}";
        private const string STATUS_LOGIN_CONNECTED_NO_ADMIN = "Der eingeloggte Benutzer hat keine Administrator-Rechte. Bitte mit einem Administrator-Konto einloggen.";
        private const string STATUS_LOGIN_NOT_CONNECTED = "Bitte einloggen.";

        #endregion

        #endregion

        #region Constructors

        public CtlWordDocumentRepairLogin()
        {
            InitializeComponent();
            SetLoginStatus(false);
        }

        #endregion

        #region EventHandlers

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {

                FrmLogin frmLogin = new FrmLogin();
                frmLogin.ShowDialog();

                SetLoginStatus(Session.Active);
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(Name, "AnmeldenFehlgeschlagen", "Anmelden fehlgeschlagen.", ex);
            }
        }

        #endregion

        #region Methods

        #region Private Methods

        private void SetLoginStatus(bool loggedIn)
        {
            if (!loggedIn)
            {
                lblLoginStatus.Text = STATUS_LOGIN_NOT_CONNECTED;
                ctlWordDocumentRepair.Enabled = false;
            }
            else
            {
                if (!Session.User.IsUserAdmin)
                {
                    lblLoginStatus.Text = STATUS_LOGIN_CONNECTED_NO_ADMIN;
                    ctlWordDocumentRepair.Enabled = false;
                }
                else
                {
                    lblLoginStatus.Text = string.Format(STATUS_LOGIN_CONNECTED, Session.User.LastFirstName);
                    ctlWordDocumentRepair.Enabled = true;
                }
            }
        }

        #endregion

        #endregion
    }
}