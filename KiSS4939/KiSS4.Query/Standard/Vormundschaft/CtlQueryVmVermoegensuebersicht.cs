using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query
{
    public partial class CtlQueryVmVermoegensuebersicht : KissQueryControl
    {
        #region Constructors

        public CtlQueryVmVermoegensuebersicht()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void edtBaPersonID_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtBaPersonID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    edtBaPersonID.EditValue = null;
                    edtBaPersonID.LookupID = null;
                    return;
                }
            }

            var dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                select distinct
                    ID = PRS.BaPersonID,
                    Mandant = PRS.NameVorname,
                    Strasse = PRS.WohnsitzStrasseHausNr,
                    Ort     = PRS.WohnsitzPLZOrt,
                    Mandatstraeger = isNull(BEN.FirstName + ' ','') + isNull(BEN.LastName,'')
                from FbPeriode PER
                    inner join vwPerson        PRS on PRS.BaPersonID = PER.BaPersonID
                    left  join FaLeistung      FAL on FAL.BaPersonID = PER.BaPersonID and
                                                 FAL.ModulID IN (5, 29) and
                                                 FAL.FaLeistungID  = dbo.fnVmGetLeistungID(PER.BaPersonID)
                    left  join XUser            BEN on BEN.UserID = FAL.UserID
                where PRS.NameVorname like {0} + '%'
                order by Mandant",
              searchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                edtBaPersonID.EditValue = dlg[1];
                edtBaPersonID.LookupID = dlg[0];
            }
        }

        private void edtUserID_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtUserID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    edtUserID.EditValue = null;
                    edtUserID.LookupID = null;
                    return;
                }
            }

            var dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(searchString, e.ButtonClicked);

            if (!e.Cancel)
            {
                edtUserID.EditValue = dlg["Name"];
                edtUserID.LookupID = dlg["UserID"];
            }
        }

        #endregion
    }
}