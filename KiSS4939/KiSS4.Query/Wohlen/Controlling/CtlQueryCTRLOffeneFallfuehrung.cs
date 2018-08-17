using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Messages;

namespace KiSS4.Query.WOH
{
    public partial class CtlQueryCTRLOffeneFallfuehrung : KiSS4.Common.KissQueryControl
    {
        #region Constructors

        public CtlQueryCTRLOffeneFallfuehrung()
        {
            InitializeComponent();
        }

        #endregion

        #region Private Methods

        private void edtUserID_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string SearchString = edtUserID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
                if (e.ButtonClicked)
                {
                    SearchString = "%";
                }
                else
                {
                    edtUserID.EditValue = null;
                    edtUserID.LookupID = null;
                    return;
                }
            }

            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(SearchString, e.ButtonClicked);

            if (!e.Cancel)
            {
                edtUserID.EditValue = dlg["Name"];
                edtUserID.LookupID = dlg["UserID"];
            }
        }

        #endregion
    }
}