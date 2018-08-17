using System;
using DevExpress.XtraBars;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query
{
    public partial class CtlQueryVmFallgewichtungAktuell : KiSS4.Common.KissQueryControl
    {
        #region Constructors

        public CtlQueryVmFallgewichtungAktuell()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void CtlQueryVmFallgewichtungAktuell_Load(object sender, System.EventArgs e)
        {
            grdQuery1.AddContextMenuItem("Zur Fallgewichtung", Fallgewichtung_ItemClick, 209);
        }

        private void edtBaPersonID_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string SearchString = edtBaPersonID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
                if (e.ButtonClicked)
                {
                    SearchString = "%";
                }
                else
                {
                    edtBaPersonID.EditValue = null;
                    edtBaPersonID.LookupID = null;
                    return;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                select distinct
                    ID = PRS.BaPersonID,
                    Mandant = PRS.NameVorname,
                    Strasse = PRS.WohnsitzStrasseHausNr,
                    Ort     = PRS.WohnsitzPLZOrt
                from FaLeistung FAL
                    inner join vwPerson PRS on PRS.BaPersonID = FAL.BaPersonID
                    left  join XUser BEN on BEN.UserID = FAL.UserID
                where FAL.ModulID = 5
                and FAL.FaProzessCode = 501
                and PRS.NameVorname like {0} + '%'
                order by PRS.NameVorname",
              SearchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                edtBaPersonID.EditValue = dlg[1];
                edtBaPersonID.LookupID = dlg[0];
            }
        }

        private void edtUserID_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
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

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                SELECT
                    ID = USR.UserID,
                    SAR = USR.LastName + isNull(', ' + USR.FirstName,''),
                    [Kuerzel] = USR.LogonName
                FROM   XUser USR
                    INNER JOIN XOrgUnit_User OUU  on OUU.UserID = USR.UserID
                            AND OUU.OrgUnitMemberCode = 2 -- member
                    INNER JOIN dbo.XOrgUnit ORG WITH (READUNCOMMITTED) on ORG.OrgUnitID = OUU.OrgUnitID
                            AND ORG.ItemName = 'EKS Beistandschaften'
                WHERE  LastName + isNull(', ' + FirstName,'') like {0} + '%'
                AND isMandatsTraeger = 1
                ORDER BY SAR",
              SearchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                edtUserID.EditValue = dlg[1];
                edtUserID.LookupID = dlg[0];
            }
        }

        private void Fallgewichtung_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!DBUtil.IsEmpty(qryQuery["VmBewertungID$"]))
            {
                int vmBewertungID = Convert.ToInt32(qryQuery["VmBewertungID$"]);
                FormController.OpenForm("FrmVmBewertung", "Action", "SetBewertungID", "VmBewertungID", vmBewertungID);
            }
        }

        #endregion
    }
}