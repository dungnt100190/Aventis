using System;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query.ZH
{
    partial class CtlQueryWhAbschlussgruende : Common.KissQueryControl
    {
        public CtlQueryWhAbschlussgruende()
        {
            InitializeComponent();
        }

        private void btnLeistung_Click(object sender, EventArgs e)
        {
            if (qryQuery.Count == 0)
            {
                return;
            }

            var baPersonId = qryQuery["FallBaPersonID$"];
            var faFallId = qryQuery["Fall-Nr."];
            const int modulId = 3;
            var pfad = String.Format(@"CtlWhLeistung{0}", qryQuery["LE-NR."]);

            FormController.OpenForm(
                "FrmFall",
                "Action", "JumpToPath",
                "BaPersonID", baPersonId,
                "FaFallID", faFallId,
                "ModulID", modulId,
                "PersonName", string.Empty,
                "TreeNodeID", pfad);
        }

        private void edtSucheUserID_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var searchString = edtSucheUserID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    edtSucheUserID.LookupID = DBNull.Value;
                    edtSucheUserID.EditValue = DBNull.Value;
                    return;
                }
            }

            var whereAddOn = "";
            if (!DBUtil.IsEmpty(edtSucheTeam.EditValue))
            {
                var teamText = DBUtil.IsEmpty(edtSucheTeam.EditValue) ? "NULL" : edtSucheTeam.EditValue.ToString();
                whereAddOn = string.Format(" AND OrgUnitID IN (SELECT OrgUnitID FROM dbo.fnOrgUnitsOfTeam(NULL, {0})) ", teamText);
            }

            var dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                SELECT
                  ID$              = UserID,
                  [Kürzel]         = LogonName,
                  [Mitarbeiter/in] = NameVorname,
                  [Org.Einheit]    = OrgUnit,
                  DisplayText$     = DisplayText
                FROM dbo.vwUser
                WHERE DisplayText LIKE '%' + {0} + '%' " + whereAddOn + @"
                ORDER BY NameVorname",
                searchString,
                e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                // apply new value (first EditValue, then LookupID!)
                edtSucheUserID.EditValue = dlg["DisplayText$"].ToString();
                edtSucheUserID.LookupID = dlg["ID$"];
            }
        }
    }
}