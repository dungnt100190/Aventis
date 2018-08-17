using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Messages;

namespace KiSS4.Schnittstellen.Newod
{
    public partial class CtlQueryNewodVerbindungenLoesen : KiSS4.Common.KissBatchQueryControl
    {
        private const string CLASSNAME = "CtlQueryNewodVerbindungenLoesen";
        private const string COLUMN_BAPERSONID = "BaPersonID";
        private const string COLUMN_NEWOD_PERSONID = "NewodPersonID";

        #region Constructors

        public CtlQueryNewodVerbindungenLoesen()
        {
            InitializeComponent();

            SqlQuery qry = DBUtil.OpenSQL(@"select Code = OrgUnitID, Text = ItemName from XOrgUnit
            order by ItemName");
            System.Data.DataRow newRow = qry.DataTable.NewRow();
            newRow["Text"] = "";
            qry.DataTable.Rows.InsertAt(newRow, 0);
            newRow.AcceptChanges();
            edtOrgUnitID.Properties.Columns.Clear();
            edtOrgUnitID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[]
            {
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 75, DevExpress.Utils.FormatType.None,
                    "", true, DevExpress.Utils.HorzAlignment.Default)
            });
            edtOrgUnitID.Properties.ShowFooter = false;
            edtOrgUnitID.Properties.ShowHeader = false;
            edtOrgUnitID.Properties.DisplayMember = "Text";
            edtOrgUnitID.Properties.ValueMember = "Code";
            edtOrgUnitID.Properties.DropDownRows = Math.Min(qry.Count, 7);
            edtOrgUnitID.Properties.DataSource = qry;
        }

        #endregion

        protected override void AenderungenUebernehmen(DataRow row)
        {
            int baPersonID = Utils.ConvertToInt(row[COLUMN_BAPERSONID]);
            int newodPersonID = Utils.ConvertToInt(row[COLUMN_NEWOD_PERSONID]);

            try
            {
                //Verbindung lösen
                NewodUtils.ClearNewodMapping(baPersonID, newodPersonID);

                // Eintrag ins Log (Ansicht unter Anwendung/Newod Schnittstelle/Protokolle)
                XLog.Create(GetType().FullName, 3, LogLevel.INFO, "Auflösen", string.Format("Verbindung mit NEWODID: {0} aufgelöst", newodPersonID), "BaPerson", Convert.ToInt32(baPersonID.ToString()));

                DlgProgressLog.AddLine(KissMsg.GetMLMessage(CLASSNAME, "InfoDisconnectNewod",
                    "BaPersonID: {0} - Die Verbindung zu NEWOD Person ID: {1} wurde aufgelöst.", baPersonID, newodPersonID));
            }
            catch (Exception ex)
            {
                DlgProgressLog.AddLine(KissMsg.GetMLMessage(CLASSNAME, "ErrorClearNewodBinding",
                    "BaPersonID: {0} - Die Verbindung zu NEWOD Person ID: {1} konnte nicht gelöst werden. Fehler: {2}", baPersonID, newodPersonID, ex));

                throw;
            }
        }

        private void edtUserID_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            if (e.Cancel)
            {
                edtUserID.EditValue = null;
                edtUserID.LookupID = null;
                return;
            }

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
    }
}