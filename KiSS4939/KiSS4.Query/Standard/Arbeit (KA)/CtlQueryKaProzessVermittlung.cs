using System;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query
{
    public partial class CtlQueryKaProzessVermittlung : KissQueryControl
    {
        public CtlQueryKaProzessVermittlung()
        {
            InitializeComponent();

            // HACK: Tabulator springt nicht aus einem KissLookUpEdit, wenn es nicht das letzte seiner Art ist..
            tpgSuchen.Controls.Add(new KissLookUpEdit { TabIndex = 999, TabStop = false, Visible = false });
        }

        protected override void RunSearch()
        {
            // since the number of displayed columns (in Liste-Tab) may change with every search-run, we have to remove all visible columns first
            grvQuery1.Columns.Clear();
            qryQuery.DataTable.Columns.Clear();

            base.RunSearch();
        }

        private void CtlQueryKaProzessVermittlung_Load(object sender, EventArgs e)
        {
            edtLeistung.LoadQuery(DBUtil.OpenSQL(@"
                SELECT Code = NULL,
                       Text = '',
                       SortKey = 0

                UNION ALL

                SELECT Code,
                       Text,
                       SortKey
                FROM dbo.XLOVCode WITH (READUNCOMMITTED)
                WHERE LOVName = 'FaProzess'
                  AND Code IN (705, 706, 711)
                  ORDER BY 3;"));
        }

        private void edtNameSTES_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtNameSTES.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    edtNameSTES.EditValue = null;
                    edtNameSTES.LookupID = null;
                    return;
                }
            }

            var dlg = new DlgAuswahl();
            e.Cancel = !dlg.PersonSuchen(searchString, e.ButtonClicked);

            if (!e.Cancel)
            {
                edtNameSTES.EditValue = dlg["Name"];
                edtNameSTES.LookupID = dlg["BaPersonID"];
            }
        }

        private void edtZustKA_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var searchString = edtZustKA.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    edtZustKA.EditValue = null;
                    edtZustKA.LookupID = null;
                    return;
                }
            }

            var dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
              SELECT ID$ = UserID,
                     [Kürzel] = LogonName,
                     [Mitarbeiter/in] = NameVorname,
                     [Org.Einheit] = OrgUnit
              FROM dbo.vwUser
              WHERE NameVorname LIKE {0} + '%'
                AND LogonName LIKE 'KA%'
              ORDER BY NameVorname;", searchString, e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                edtZustKA.EditValue = dlg[2];
                edtZustKA.LookupID = dlg[0];
            }
        }

        private void qryQuery_AfterFill(object sender, EventArgs e)
        {
            grdRohdaten.DataSource = qryQuery.DataSet.Tables[1];
            grvRohdaten.BestFitColumns();
        }
    }
}