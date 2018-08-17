using System;

using KiSS4.Common;
using KiSS4.Gui;

namespace KiSS4.Query.MUN
{
    public partial class CtlQueryFaPendenzenAuswertungen : KissQueryControl
    {
        #region Constructors

        public CtlQueryFaPendenzenAuswertungen()
        {
            InitializeComponent();
        }

        #endregion

        protected override void NewSearch()
        {
            edtFrist.Text = "30";

            base.NewSearch();
        }

        #region EventHandlers

        private void edtUserID_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            using (var dlg = new DlgAuswahl())
            {
                e.Cancel = !dlg.MitarbeiterSuchen(edtUserID.Text, e.ButtonClicked);

                if (!e.Cancel)
                {
                    edtUserID.LookupID = dlg["UserID"];
                    edtUserID.Text = Convert.ToString(dlg["Name"]);
                }
            }
        }

        #endregion
    }
}