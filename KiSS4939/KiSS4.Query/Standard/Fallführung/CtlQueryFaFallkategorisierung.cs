using System;

using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query
{
    partial class CtlQueryFaFallkategorisierung : KissQueryControl
    {
        public CtlQueryFaFallkategorisierung()
        {
            InitializeComponent();

            // Sektion
            var qry = DBUtil.OpenSQL(@"
                SELECT Code   = OrgUnitID,
                       [Text] = ItemName
                FROM dbo.XOrgUnit WITH (READUNCOMMITTED)
                ORDER BY ItemName");
            var newRow = qry.DataTable.NewRow();
            newRow["Text"] = "";
            qry.DataTable.Rows.InsertAt(newRow, 0);
            newRow.AcceptChanges();
            edtOrgUnitID.Properties.Columns.Clear();
            edtOrgUnitID.Properties.Columns.AddRange(
                new[]
                {
                    new LookUpColumnInfo("Text", "", 75, FormatType.None, "", true, HorzAlignment.Default)
                });
            edtOrgUnitID.Properties.ShowFooter = false;
            edtOrgUnitID.Properties.ShowHeader = false;
            edtOrgUnitID.Properties.DisplayMember = "Text";
            edtOrgUnitID.Properties.ValueMember = "Code";
            edtOrgUnitID.Properties.DropDownRows = Math.Min(qry.Count, 7);
            edtOrgUnitID.Properties.DataSource = qry;

            kissSearch.SelectParameters = new object[] { Session.User.LanguageCode };
        }

        protected override void NewSearch()
        {
            chkNuraktuellste.Checked = true;
            chkAktiv.Checked = true;

            base.NewSearch();
        }

        private void edtBaPersonID_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var searchString = edtBaPersonID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

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
                SELECT  ID = BaPersonID,
                        Person = ISNULL(NameVorname, ''),
                        [Vers. Nr.] = Versichertennummer,
                        AHVNummer
                FROM dbo.vwPerson WITH (READUNCOMMITTED)
                WHERE ISNULL(NameVorname, '') LIKE {0} + '%'
                  AND (PersonSichtbarSDFlag = dbo.fnGetPersonSichtbarFlag('{1}') OR PersonSichtbarSDFlag = 1)
                ORDER BY Person;",
                searchString,
                e.ButtonClicked,
                Session.User.LogonName);

            if (!e.Cancel)
            {
                edtBaPersonID.EditValue = dlg[1];
                edtBaPersonID.LookupID = dlg[0];
            }
        }
    }
}