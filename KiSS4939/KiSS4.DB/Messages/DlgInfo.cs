using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.DB.Properties;

namespace KiSS4.Messages
{
    public partial class DlgInfo : Form
    {
        private DlgInfo(string info)
        {
            InitializeComponent();
            txtInfo.Text = info;
            BackColor = DBUtil.DefaultMessageDialogBackColor;
            txtInfo.BackColor = DBUtil.DefaultMessageDialogBackColor;

            // Multilanguage handling
            Text = KissMsg.GetMLMessage("DlgInfo", "FormText", Resources.DlgInfo_FormText);
            btnOK.Text = KissMsg.GetMLMessage("DlgInfo", "BtnOKText", Resources.DlgInfo_BtnOKText);
        }

        public static IMessagePresenter MessagePresenter
        {
            get;
            set;
        }

        /// <summary>
        /// Displays information to the user with an ok button, The size of the window will be Width/Height
        /// </summary>
        /// <param name="info">the text to be displayed</param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void Show(string info, int width, int height)
        {
            // In KiSS 5 kein Dialog öffnen.
            // Falls die Meldung von einem Dialog kommt kann im KiSS5 kein ValidationSummary angezeigt werden und
            // muss wie im KiSS4 mit dem DlgInfo angezeigt werden.
            // KissForm implementiert IKissDataNavigator (gelegentlich gibt es eine OpenForm für DevExpress-Tooltips..)
            if (MessagePresenter != null && !Application.OpenForms.OfType<Form>().OfType<IKissDataNavigator>().Any())
            {
                MessagePresenter.ShowInfo(info, width, height);
            }
            else
            {
                DlgInfo dlg = new DlgInfo(info);

                Size aTextSize = TextRenderer.MeasureText(info, dlg.txtInfo.Font);

                dlg.Width = aTextSize.Width + dlg.txtInfo.Left + 30;
                dlg.Height = aTextSize.Height + dlg.txtInfo.Top + 90;

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

                    if ((dlg.txtInfo.Width < aTextSize.Width) || (dlg.txtInfo.Height < aTextSize.Height))
                    {
                        dlg.txtInfo.ScrollBars = ScrollBars.Vertical;
                    }
                }
                else
                {
                    if (dlg.Width > Screen.PrimaryScreen.WorkingArea.Width / 2)
                    {
                        // Wenn Weite grösser als der halben Bildschrimweite:
                        dlg.Width = Screen.PrimaryScreen.WorkingArea.Width / 2;
                        dlg.txtInfo.ScrollBars = ScrollBars.Vertical;
                    }

                    if (dlg.Height > Screen.PrimaryScreen.WorkingArea.Height / 2)
                    {
                        // Wenn Breite grösser als der halben Bildschrimbreite:
                        dlg.Height = Screen.PrimaryScreen.WorkingArea.Height / 2;
                        dlg.txtInfo.ScrollBars = ScrollBars.Vertical;
                    }
                }

                // show dialog
                dlg.ShowDialog(KissMsg.GetMainWindow());
            }
        }

        private void DlgInfo_Load(object sender, EventArgs e)
        {
            // show dialog and main form
            KissMsg.BringKiSSAndDialogToFront(this);
        }
    }
}