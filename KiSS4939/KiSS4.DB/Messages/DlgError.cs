using System;
using System.Linq;
using System.Windows.Forms;

using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.DB.Properties;

namespace KiSS4.Messages
{
    public partial class DlgError : Form
    {
        private DlgError(string userText, string technicalText, Exception ex)
        {
            InitializeComponent();

            BackColor = DBUtil.DefaultMessageDialogBackColor;
            txtUserText.BackColor = DBUtil.DefaultMessageDialogBackColor;
            txtTechnicalText.BackColor = DBUtil.DefaultMessageDialogBackColor;

            tabError.SelectedTabIndex = 0;

            txtUserText.Text = userText;
            txtTechnicalText.Text = "";

            if (string.IsNullOrEmpty(technicalText) && (ex == null))
            {
                tpgTechnical.Visible = false;
            }
            else
            {
                if (!string.IsNullOrEmpty(technicalText))
                {
                    txtTechnicalText.Text = technicalText;
                }

                if (ex != null)
                {
                    if (!String.IsNullOrEmpty(txtTechnicalText.Text))
                    {
                        txtTechnicalText.Text += "\r\n\r\n";
                    }

                    txtTechnicalText.Text += ex.ToString();
                }
            }

            // Multilanguage handling
            Text = KissMsg.GetMLMessage("DlgError", "FormText", Resources.DlgError_FormText);
            tpgUser.Title = KissMsg.GetMLMessage("DlgError", "TpgUserTitle", Resources.DlgError_TpgUserTitle);
            tpgTechnical.Title = KissMsg.GetMLMessage("DlgError", "TpgTechnicalTitle", Resources.DlgError_TpgTechnicalTitle);
            tpgSupport.Title = KissMsg.GetMLMessage("DlgError", "TpgSupportTitle", Resources.DlgError_TpgSupportTitle);
            btnOK.Text = KissMsg.GetMLMessage("DlgError", "BtnOKText", Resources.DlgError_BtnOKText);
        }

        public static IMessagePresenter MessagePresenter
        {
            get;
            set;
        }

        /// <summary>
        /// Displays an error Message (user + technical) with an ok button and a support Tab
        /// ErrorMessage and StackTrace of the Exception will be appended to the technical Tab
        /// </summary>
        /// <param name="userText">the text for the user</param>
        /// <param name="technicalText">the text with technical details of the error</param>
        /// <param name="ex">The exception that was thrown.</param>
        /// <param name="width">The width of the dialog.</param>
        /// <param name="height">The height of the dialog.</param>
        public static void Show(string userText, string technicalText, Exception ex, int width, int height)
        {
            // In KiSS 5 kein Dialog öffnen.
            // Falls die Meldung von einem Dialog kommt kann im KiSS5 kein ValidationSummary angezeigt werden und
            // muss wie im KiSS4 mit dem DlgInfo angezeigt werden.
            // KissForm implementiert IKissDataNavigator (gelegentlich gibt es eine OpenForm für DevExpress-Tooltips..)
            if (MessagePresenter != null && !Application.OpenForms.OfType<Form>().OfType<IKissDataNavigator>().Any())
            {
                MessagePresenter.ShowError(userText, technicalText, ex, width, height);
            }
            else
            {
                DlgError dlg = new DlgError(userText, technicalText, ex);

                if (width != 0)
                {
                    dlg.Width = width;
                }

                if (height != 0)
                {
                    dlg.Height = height;
                }

                // show dialog
                dlg.ShowDialog(KissMsg.GetMainWindow());
            }
        }

        private void DlgError_Load(object sender, EventArgs e)
        {
            // show dialog and main form
            KissMsg.BringKiSSAndDialogToFront(this);
        }
    }
}