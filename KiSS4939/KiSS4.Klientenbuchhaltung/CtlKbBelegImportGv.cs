using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Klientenbuchhaltung
{
    public partial class CtlKbBelegImportGv : KissSearchUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CLASSNAME = "CtlKbBelegImportGv";
        private const string KEYPATH_GRUPPE_ZAHLUNGSKONTO_EINSCHRAENKEN = @"System\KliBu\ZahlungslaufGruppeUndZahlungskontoEinschraenken";
        private const string XRIGHT_ALLE_GRUPPEN_AUSWAEHLBAR = "CtlKbBelegImportGv_AlleGruppenAuswaehlbar";
        private const string XRIGHT_KANTON_CH = "CtlKbBelegImportGv_Kanton_CH";

        #endregion

        #region Private Fields

        private bool _hasGruppenSpezialrecht;
        private bool _hasKantonChSpezialrecht;
        private bool _isGruppeUndZahlungskontoEingeschraenkt;
        private int _kbPeriodeID;

        #endregion

        #endregion

        #region Constructors

        public CtlKbBelegImportGv()
        {
            InitializeComponent();

            // setup controls
            edtErgaenzungText.Properties.MaxLength = DBODef.KbBuchung.Text.Length;

            // setup status column
            repStatusImg.SmallImages = KissImageList.SmallImageList;
            repStatusImg.NullText = "";

            SqlQuery qryStatus = DBUtil.OpenSQL(@"
                SELECT Code   = LOC.Code,
                       Text   = dbo.fnLOVMLText(LOC.LOVName, LOC.Code, {0}),
                       Value1 = LOC.Value1
                FROM dbo.XLOVCode LOC WITH (READUNCOMMITTED)
                WHERE LOC.LOVName = 'KbBuchungsStatus'
                ORDER BY SortKey", Session.User.LanguageCode);

            foreach (DataRow row in qryStatus.DataTable.Rows)
            {
                repStatusImg.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(
                    row["Text"].ToString(), Convert.ToInt32(row["Code"]), KissImageList.GetImageIndex(Convert.ToInt32(row["Value1"]))));
            }

            colStatus.ColumnEdit = repStatusImg;
        }

        #endregion

        #region EventHandlers

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (CanImportBuchungen())
            {
                ImportSelectedBuchungen();
            }
        }

        private void chkNurCHFonds_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNurCHFonds.Checked)
            {
                chkNurKantonaleFonds.Checked = false;
            }
        }

        private void chkNurKantonaleFonds_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNurKantonaleFonds.Checked)
            {
                chkNurCHFonds.Checked = false;
            }
        }

        private void CtlKbBelegImportGv_Load(object sender, EventArgs e)
        {
            tabControlSearch.SelectTab(tpgSuchen);

            _isGruppeUndZahlungskontoEingeschraenkt = DBUtil.GetConfigBool(KEYPATH_GRUPPE_ZAHLUNGSKONTO_EINSCHRAENKEN, false);
            _hasGruppenSpezialrecht = DBUtil.UserHasRight(XRIGHT_ALLE_GRUPPEN_AUSWAEHLBAR);
            _hasKantonChSpezialrecht = DBUtil.UserHasRight(XRIGHT_KANTON_CH);

            // drop-downbox für Suche KGS befüllen
            qrySucheKGS.Fill(_isGruppeUndZahlungskontoEingeschraenkt, _hasGruppenSpezialrecht, Session.User.UserID);
            edtSucheKGS.LoadQuery(qrySucheKGS);

            // Periode
            _kbPeriodeID = Convert.ToInt32(FormController.GetMessage("FrmKbKlientenbuchhaltung", false, "Action", "KbPeriodeID"));
            string periodeMandantName = Convert.ToString(DBUtil.ExecuteScalarSQL(@"
                SELECT dbo.fnKbGetPeriodeInfo({0}, 'klibu', {1});", _kbPeriodeID, Session.User.LanguageCode));

            lblPeriodeMandant.Text = periodeMandantName;

            //Wenn Gruppe eingeschränkt ist und Benutzer kein Spezialrecht hat, ist Control ReadOnly
            if (_isGruppeUndZahlungskontoEingeschraenkt && !_hasGruppenSpezialrecht)
            {
                edtSucheKGS.EditMode = EditModeType.ReadOnly;
            }

            //Spezialrecht : darf der Benutzer die Checkbox CHF/Kanton ändern? - RAT 9690-001
            if (!_hasKantonChSpezialrecht)
            {
                chkNurCHFonds.EditMode = EditModeType.ReadOnly;
                chkNurKantonaleFonds.EditMode = EditModeType.ReadOnly;
            }

            NewSearch();
        }

        private void edtSucheBelegErsteller_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(edtSucheBelegErsteller.Text, e.ButtonClicked);

            if (!e.Cancel)
            {
                edtSucheBelegErsteller.EditValue = dlg["Name"];
                edtSucheBelegErsteller.LookupID = dlg["UserID"];
            }
        }

        private void grvBeleg_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            // get all rows the user selected
            int[] rowHandles = grvBeleg.GetSelectedRows();

            if (rowHandles == null)
            {
                return;
            }

            decimal summeSelektion = 0;

            // sum betrag of all rows the user selected
            foreach (int rowHandle in rowHandles)
            {
                DataRow row = grvBeleg.GetDataRow(rowHandle);
                summeSelektion += Utils.ConvertToDecimal(row["Betrag"]);
            }

            edtSummeSelektion.EditValue = summeSelektion;
        }

        private void qryBeleg_AfterFill(object sender, EventArgs e)
        {
            grdBeleg.DataSource = qryBeleg;
            UpdateRowCount();
        }

        private void tabControlSearch_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            UpdateRowCount();
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            // KGS des Benutzers vorauswählen
            var qryMandantenNummer = DBUtil.OpenSQL(@"
                SELECT
                  Mandantennummer = ISNULL(ORG.Mandantennummer, ORGP.Mandantennummer)
                FROM dbo.XOrgUnit         ORG  WITH (READUNCOMMITTED)
                  LEFT  JOIN dbo.XOrgUnit ORGP WITH (READUNCOMMITTED) ON ORGP.OrgUnitID = ORG.ParentID
                WHERE ORG.OrgUnitID = dbo.fnOrgUnitOfUser({0}, 1);",
                Session.User.UserID);

            if (qryMandantenNummer.Count == 1)
            {
                edtSucheKGS.EditValue = qryMandantenNummer[DBO.XOrgUnit.Mandantennummer];
            }

            edtAuszahlungsart.ItemIndex = 0;

            chkNurKantonaleFonds.Checked = true;

            base.NewSearch();
        }

        /// <summary>
        /// Run a new search
        /// </summary>
        protected override void RunSearch()
        {
            // setup search parameters
            // {0}: selektierte Gruppe oder NULL
            // {1}: aktueller Mandant (KbMandantID)
            kissSearch.SelectParameters = new object[] { "{0}", "{1}", Session.User.LanguageCode, edtSucheKGS.EditValue as int?, _kbPeriodeID };

            // let base run a new search
            base.RunSearch();
        }

        #endregion

        #region Private Methods

        private bool BelegIstImportierbar(int buchungsStatusCode)
        {
            switch (buchungsStatusCode)
            {
                case (int)LOVsGenerated.KbBuchungsStatus.Freigegeben:
                    // can import
                    return true;

                default:
                    // cannot import
                    return false;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns>returns <c>False</c>
        /// if  1. there is at least 1 selected qryBelege-row
        ///     2. BelegDatum (UserInput):
        ///         a. is empty
        ///         b. is not in the given KbPeriode (between PeriodeVon and PeriodeBis)
        /// else <c>True</c></returns>
        private bool CanImportBuchungen()
        {
            // get all rows the user selected
            int[] rowHandles = grvBeleg.GetSelectedRows();

            if (rowHandles == null)
            {
                KissMsg.ShowInfo(CLASSNAME, "NoEntriesSelected", "Es wurden keine Buchungen selektiert!");
                return false;
            }

            if (DBUtil.IsEmpty(edtBelegDatum.EditValue) || edtBelegDatum.EditValue.ToString() == "")
            {
                KissMsg.ShowInfo(CLASSNAME, "NoBookingDate", "Das Belegdatum darf nicht leer bleiben.");
                edtBelegDatum.Focus();
                return false;
            }

            // validate BelegDatum and BelegNr using db-functions
            bool isBelegDatumValid = Convert.ToBoolean(DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT dbo.fnKbCheckBelegDatum({0}, {1});", _kbPeriodeID, edtBelegDatum.EditValue));

            // check if BelegDatum and BelegNr are valid
            if (!isBelegDatumValid)
            {
                // invalid BelegDatum
                KissMsg.ShowInfo(CLASSNAME,
                                 "InvalidBelegDatum",
                                 "Das eingegebene Belegdatum ist ungültig für die zugehörige Periode (KbPeriodeID='{0}').", _kbPeriodeID);
                edtBelegDatum.Focus();
                return false;
            }

            //everything ok if we get till here!
            return true;
        }

        private void ImportSelectedBuchungen()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                int[] rowIds = grvBeleg.GetSelectedRows();

                var rows = new List<DataRow>();

                foreach (int rowId in rowIds)
                {
                    rows.Add(grvBeleg.GetDataRow(rowId));
                }

                // update all rows the user selected
                foreach (DataRow row in rows)
                {
                    if (BelegIstImportierbar(Utils.ConvertToInt(row[DBO.KbBuchung.KbBuchungStatusCode])))
                    {
                        try
                        {
                            Session.BeginTransaction();

                            // Importiere Beleg
                            DBUtil.ExecSQLThrowingException(
                                @"
                                EXEC dbo.spKbBelegimportAusGesuchverwaltung {0}, {1}, {2}, {3}, {4};",
                                //{0}: @GvAuszahlungPositionID ID der Auszahlungsposition
                                row[DBO.GvAuszahlungPosition.GvAuszahlungPositionID],
                                //{1}: @Belegdatum
                                edtBelegDatum.EditValue,
                                //{2}: @Buchungstext
                                Utils.TruncateString(string.Format("{0} {1}",
                                        row["Buchungstext"],
                                        edtErgaenzungText.Text),
                                    DBODef.KbBuchung.Text.Length),
                                //{3}: @KbPeriodeID
                                _kbPeriodeID,
                                //{4}: @UserID
                                Session.User.UserID,
                                //{5}: @LanguageCode
                                Session.User.LanguageCode);

                            //Update Status in Query, so the grid is updated
                            row[DBO.KbBuchung.KbBuchungStatusCode] = LOVsGenerated.KbBuchungsStatus.Verbucht;
                            row.AcceptChanges();

                            Session.Commit();
                        }
                        catch (Exception ex)
                        {
                            if (Session.Transaction != null)
                            {
                                Session.Rollback();
                            }

                            // show info
                            KissMsg.ShowError(
                                CLASSNAME,
                                "ErrorImportRecords_v04",
                                "Es ist ein Fehler beim Importieren des Beleges aufgetreten.\r\n\r\nBuchungstext:\r\n{0}\r\n\r\nFehler:\r\n{1}",
                                string.Format("GvAuszahlungPositionID='{0}'", row[DBO.GvAuszahlungPosition.GvAuszahlungPositionID]),
                                ex,
                                row["Buchungstext"], // param0
                                ex.Message);
                        }
                        finally
                        {
                            qryBeleg.RowModified = false;
                        }
                    }
                }
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            qryBeleg.RefreshDisplay();
        }

        private void UpdateRowCount()
        {
            // validate
            if (tabControlSearch.IsTabSelected(tpgSuchen))
            {
                // hide label
                lblRowCount.Visible = false;
                return;
            }

            // set count and show label
            lblRowCount.Text = KissMsg.GetMLMessage(CLASSNAME, "", "Anzahl Einträge: {0}", qryBeleg.Count);
            lblRowCount.Visible = true;
        }

        #endregion

        #endregion
    }
}