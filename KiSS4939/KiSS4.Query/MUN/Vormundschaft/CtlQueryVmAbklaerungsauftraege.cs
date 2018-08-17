using System;

using KiSS4.Common;
using KiSS4.Gui;
using KiSS4.DB;

namespace KiSS4.Query.MUN
{
    public partial class CtlQueryVmAbklaerungsauftraege : KissQueryControl
    {
        #region Constructors

        public CtlQueryVmAbklaerungsauftraege()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void edtUser_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            using (var dlg = new DlgAuswahl())
            {
                e.Cancel = !dlg.MitarbeiterSuchen(edtUser.Text, e.ButtonClicked);

                if (!e.Cancel)
                {
                    edtUser.LookupID = dlg["UserID"];
                    edtUser.Text = Convert.ToString(dlg["Name"]);
                }
            }
        }

        protected override void RunSearch()
        {
            DBUtil.CheckNotNullField(edtDatum, "Zu erledigen bis");

            base.RunSearch();
        }

        #endregion
    }
}