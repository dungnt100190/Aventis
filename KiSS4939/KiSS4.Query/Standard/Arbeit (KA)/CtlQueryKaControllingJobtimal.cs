using System;
using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query
{
    partial class CtlQueryKaControllingJobtimal : KiSS4.Common.KissQueryControl
    {
        #region Constructors

        public CtlQueryKaControllingJobtimal()
        {
            this.InitializeComponent();

            edtSucheNach.EditValue = 1;
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();

            edtSucheNach.EditValue = 1;

            edtZustaendigKA.EditValue = null;
            edtZustaendigKA.LookupID = null;
            edtStatusHeute.EditValue = null;
            edtZeitraumVon.EditValue = null;
            edtZeitraumBis.EditValue = null;
        }

        protected override void RunSearch()
        {
            if (DBUtil.IsEmpty(edtSucheNach.EditValue))
            {
                edtSucheNach.EditValue = 1;
                edtZeitraumVon.EditValue = null;
                edtZeitraumBis.EditValue = null;
            }

            base.RunSearch();
        }

        #endregion

        #region Private Methods

        private void CtlQueryKaControllingJobtimal_Load(object sender, System.EventArgs e)
        {
            tpgListe.Title = "Daten STES";
        }

        private void edtSucheNach_EditValueChanged(object sender, System.EventArgs e)
        {
            edtStatusHeute.EditMode = EditModeType.ReadOnly;
            edtZeitraumVon.EditMode = EditModeType.ReadOnly;
            edtZeitraumBis.EditMode = EditModeType.ReadOnly;

            edtStatusHeute.EditValue = null;
            edtZeitraumVon.EditValue = null;
            edtZeitraumBis.EditValue = null;

            if (!DBUtil.IsEmpty(edtSucheNach.EditValue))
            {
                if (Convert.ToInt32(edtSucheNach.EditValue) == 1)
                {
                    edtStatusHeute.EditMode = EditModeType.Normal;
                }
                else
                {
                    edtZeitraumVon.EditMode = EditModeType.Normal;
                    edtZeitraumBis.EditMode = EditModeType.Normal;
                }
            }
        }

        private void edtZustaendigKA_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string SearchString = edtZustaendigKA.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
                if (e.ButtonClicked)
                {
                    SearchString = "%";
                }
                else
                {
                    edtZustaendigKA.EditValue = null;
                    edtZustaendigKA.LookupID = null;
                    return;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
              SELECT ID$ = UserID,
                     [Kürzel] = LogonName,
                     [Mitarbeiter/in] = NameVorname,
                     [Org.Einheit] = OrgUnit
              FROM   vwUser
              WHERE  NameVorname like {0} + '%'
              AND    LogonName like 'KA%'
              ORDER BY NameVorname",
              SearchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                edtZustaendigKA.EditValue = dlg[2];
                edtZustaendigKA.LookupID = dlg[0];
            }
        }

        #endregion
    }
}