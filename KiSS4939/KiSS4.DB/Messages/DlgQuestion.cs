using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Kiss.Interfaces.UI;

using KiSS4.DB;

namespace KiSS4.Messages
{
    public partial class DlgQuestion : Form
    {
        private DlgQuestion(string question)
        {
            InitializeComponent();

            if (Session.IsKiss5Mode)
            {
                this.Text = "Kiss";
            }

            BackColor = DBUtil.DefaultMessageDialogBackColor;
            txtQuestion.BackColor = DBUtil.DefaultMessageDialogBackColor;

            txtQuestion.Text = question;

            // Multilanguage handling
            btnYes.Text = KissMsg.GetMLMessage("DlgQuestion", "BtnYesText", DB.Properties.Resources.DlgQuestion_BtnYesText);
            btnNo.Text = KissMsg.GetMLMessage("DlgQuestion", "BtnNoText", DB.Properties.Resources.DlgQuestion_BtnNoText);
        }

        public static IMessagePresenter MessagePresenter
        {
            get;
            set;
        }

        /// <summary>
        /// Displays a question to the user and returns true (Yes) or false (No)
        /// </summary>
        /// <param name="question">the question text, preferably with an ? at the end</param>
        /// <param name="width">The width of the dialog.</param>
        /// <param name="height">The height of the dialog.</param>
        /// <param name="defaultYes">If true the 'yes'-Button is default.</param>
        public static bool Show(string question, int width, int height, bool defaultYes)
        {
            // In KiSS 5 kein Dialog öffnen.
            // Falls die Meldung von einem Dialog kommt kann im KiSS5 kein ValidationSummary angezeigt werden und
            // muss wie im KiSS4 mit dem DlgInfo angezeigt werden.
            // KissForm implementiert IKissDataNavigator (gelegentlich gibt es eine OpenForm für DevExpress-Tooltips..)
            if (MessagePresenter != null && !Application.OpenForms.OfType<Form>().OfType<IKissDataNavigator>().Any())
            {
                return MessagePresenter.ShowQuestion(question, width, height, defaultYes);
            }

            DlgQuestion dlg = new DlgQuestion(question);

            Size aTextSize = TextRenderer.MeasureText(question, dlg.txtQuestion.Font);

            dlg.Width = aTextSize.Width + dlg.txtQuestion.Left + 30;
            dlg.Height = aTextSize.Height + dlg.txtQuestion.Top + 90;

            if ((width != 0) || (height != 0))
            {
                // Grössen sind angegeben, also Grösse nicht ändern
                if (width != 0)
                {
                    dlg.Width = width;
                }

                if (height != 0)
                {
                    dlg.Height = height;
                }

                if ((dlg.txtQuestion.Width < aTextSize.Width) || (dlg.txtQuestion.Height < aTextSize.Height))
                {
                    dlg.txtQuestion.ScrollBars = ScrollBars.Vertical;
                }
            }
            else
            {
                if (dlg.Width > Screen.PrimaryScreen.WorkingArea.Width / 2)
                {
                    // Wenn Weite grösser als der halben Bildschrimweite:
                    dlg.Width = Screen.PrimaryScreen.WorkingArea.Width / 2;
                    dlg.txtQuestion.ScrollBars = ScrollBars.Vertical;
                }

                if (dlg.Height > Screen.PrimaryScreen.WorkingArea.Height / 2)
                {
                    // Wenn Breite grösser als der halben Bildschrimbreite:
                    dlg.Height = Screen.PrimaryScreen.WorkingArea.Height / 2;
                    dlg.txtQuestion.ScrollBars = ScrollBars.Vertical;
                }
            }

            if (defaultYes)
            {
                dlg.AcceptButton = dlg.btnYes;
                dlg.btnYes.TabIndex = 0;
                dlg.btnNo.TabIndex = 1;
            }
            else
            {
                dlg.AcceptButton = dlg.btnNo;
                dlg.btnNo.TabIndex = 0;
                dlg.btnYes.TabIndex = 1;
            }

            // return value
            return dlg.ShowDialog(KissMsg.GetMainWindow()) == DialogResult.Yes;
        }

        private void DlgQuestion_Load(object sender, EventArgs e)
        {
            // show dialog and main form
            KissMsg.BringKiSSAndDialogToFront(this);
        }
    }
}