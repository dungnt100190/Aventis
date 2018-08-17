using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Klientenbuchhaltung
{
    /// <summary>
    /// Control, used to import bookkeeping records of WH
    /// </summary>
    public partial class CtlKbBelegImportSH : KissSearchUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const int AUSZAHLUNGSART_IV = 105;
        private const int BELEGKREIS_AKTIVKONTO = 1; // KbBelegkreisCode.Aktivkonto
        private const int BELEGKREIS_BELEGIMPORT_ASYL = 5; // KbBelegkreisCode.BelegImportAsyl
        private const int BELEGKREIS_BELEGIMPORT_IV = 9; // KbBelegkreisCode.BelegImportInterneVerrechnung
        private const int BELEGKREIS_BELEGIMPORT_SH = 2; // KbBelegkreisCode.BelegImportSozialhilfe
        private const int BUCHUNGSSTATUS_BARBELEG_AUSGEDRUCKT = 4;
        private const int BUCHUNGSSTATUS_FREIGEGEBEN = 2;
        private const string CLASSNAME = "CtlKbBelegImportSH";
        private const int MANDANT_ASYL = 6;

        #endregion

        #region Private Fields

        private int? _kbFolgeperiodeId; // ID der Folgeperiode
        private int _kbMandantId;
        private int _kbPeriodeId;
        private string _kontoNrKasse; // #3913 für ausbezahlte Kassenbelege darf nicht derselbe Belegkreis verwendet werden!

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlKbBelegImportSH"/> class.
        /// </summary>
        public CtlKbBelegImportSH()
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

        private void chkSucheOhneBelegNr_CheckedChanged(object sender, EventArgs e)
        {
            HandleSucheBelegNr(chkSucheOhneBelegNr);
        }

        private void CtlKbBelegImportSH_Load(object sender, EventArgs e)
        {
            // init groups
            qryGruppe.Fill();
            edtSucheGruppe.LoadQuery(qryGruppe);

            // start with new search
            NewSearch();
            tabControlSearch_SelectedTabChanged(tpgSuchen);

            // continue with init
            grdBeleg.DataSource = null;

            // --- Periode
            _kbPeriodeId = Convert.ToInt32(FormController.GetMessage("FrmKbKlientenbuchhaltung", false, "Action", "KbPeriodeID"));

            if (_kbPeriodeId == 0)
            {
                KissMsg.ShowInfo(CLASSNAME, "FirstSelectDefaultKbPeriodeID", "Bitte wählen Sie eine Standardperiode aus!");
            }
            else
            {
                SetBelegkreise(_kbPeriodeId);
                SetKontoNrKasse(_kbPeriodeId);
            }

            _kbFolgeperiodeId = KliBuUtil.GetFolgeperiodeId(_kbPeriodeId);

            string periodeMandantName = Convert.ToString(DBUtil.ExecuteScalarSQL(@"
                SELECT dbo.fnKbGetPeriodeInfo({0}, 'klibu', {1});", _kbPeriodeId, Session.User.LanguageCode));

            lblPeriodeMandant.Text = periodeMandantName;
            SetBelegkreise(_kbPeriodeId);

            colBeleg_BelegStatus.ColumnEdit = repStatusImg;
            colBeleg_Auszahlungsart.ColumnEdit = grdKbBuchung.GetLOVLookUpEdit("KbAuszahlungsArt");
            colAuszahlungsart.ColumnEdit = grdKbBuchung.GetLOVLookUpEdit("KbAuszahlungsArt");
        }

        private void edtSucheBelegNr_EditValueChanged(object sender, EventArgs e)
        {
            HandleSucheBelegNr(edtSucheBelegNrVon);
        }

        private void edtSucheErfasser_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(edtSucheErfasser.Text, e.ButtonClicked);

            if (!e.Cancel)
            {
                edtSucheErfasser.EditValue = dlg["Name"];
                edtSucheErfasser.LookupID = dlg["UserID"];
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

        private void qryBeleg_PositionChanged(object sender, EventArgs e)
        {
            qryKbBuchung.Fill(qryBeleg["KbBuchungID"]);

            grvKbBuchung.CollapseAllDetails();
        }

        private void qryKbBuchung_AfterFill(object sender, EventArgs e)
        {
            DataSet ds = qryKbBuchung.DataSet;

            ds.Relations.Add("BelegDetail",
            ds.Tables[0].Columns["KbBuchungID"],
            ds.Tables[1].Columns["KbBuchungID"]);
        }

        private void tabControlSearch_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            grdKbBuchung.Visible = tabControlSearch.SelectedTabIndex == tpgListe.TabIndex;
            UpdateRowCount();
        }

        #endregion

        #region Methods

        #region Protected Methods

        /// <summary>
        /// Initialize a new search
        /// </summary>
        protected override void NewSearch()
        {
            // let base do stuff
            base.NewSearch();

            // set default values
            chkSucheInterneVerrechnungEinbeziehen.EditValue = false;
            chkSucheOhneBelegNr.EditValue = false;
            edtSucheKbBuchungsStatus.EditValue = Convert.ToString(BUCHUNGSSTATUS_FREIGEGEBEN);
            edtSucheGruppe.ItemIndex = 0;

            // set focus
            edtSucheValutaVon.Focus();
        }

        /// <summary>
        /// Run a new search
        /// </summary>
        protected override void RunSearch()
        {
            // setup search parameters
            kissSearch.SelectParameters = new object[] { _kbMandantId };

            // let base run a new search
            base.RunSearch();
        }

        #endregion

        #region Private Methods

        private bool BelegIstImportierbar(int buchungsStatusCode)
        {
            switch (buchungsStatusCode)
            {
                case BUCHUNGSSTATUS_FREIGEGEBEN:
                case BUCHUNGSSTATUS_BARBELEG_AUSGEDRUCKT:
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

            if (DBUtil.IsEmpty(edtBuchungsdatum.EditValue) || edtBuchungsdatum.EditValue.ToString() == "")
            {
                KissMsg.ShowInfo(CLASSNAME, "NoBookingDate", "Das Buchungsdatum darf nicht leer bleiben.");
                edtBuchungsdatum.Focus();
                return false;
            }

            // validate BelegDatum and BelegNr using db-functions
            bool isBelegDatumValid = Convert.ToBoolean(DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT dbo.fnKbCheckBelegDatum({0}, {1});", _kbPeriodeId, edtBuchungsdatum.EditValue));

            // check if BelegDatum and BelegNr are valid
            if (!isBelegDatumValid)
            {
                // invalid BelegDatum
                KissMsg.ShowInfo(CLASSNAME,
                                 "InvalidBelegDatum",
                                 "Das eingegebene Beleg-Datum ist ungültig für das aktuelle Budget und die zugehörige Periode (KbPeriodeID='{0}').", _kbPeriodeId);
                edtBuchungsdatum.Focus();
                return false;
            }

            //everything ok if we get till here!
            return true;
        }

        private void HandleSucheBelegNr(object sender)
        {
            // handle checkbox
            if (chkSucheOhneBelegNr.Checked && sender == chkSucheOhneBelegNr)
            {
                // reset from/to and disable
                edtSucheBelegNrVon.EditValue = null;
                edtSucheBelegNrBis.EditValue = null;

                // check checkbox again (could be droped due to recursive call)
                chkSucheOhneBelegNr.Checked = true;
            }
            else
            {
                // check if any value is entered in from/to
                if (!DBUtil.IsEmpty(edtSucheBelegNrVon.EditValue) || !DBUtil.IsEmpty(edtSucheBelegNrBis.EditValue))
                {
                    // uncheck checkbox and make readonly
                    chkSucheOhneBelegNr.Checked = false;
                }
            }
        }

        //@@TODO refactor!
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

                var buchungenAusFolgePeriodeAuchImportieren = KliBuUtil.CheckImportBelegeOfFollowingPeriod(rows, _kbPeriodeId, _kbFolgeperiodeId);
                var buchungenMitBelegNrAusAnderenPeriodeAuchImportieren = KliBuUtil.CheckImportBelegeWithBelegNrOfOtherPeriod(rows, _kbPeriodeId);

                var notifiedBelegkreisCodes = new HashSet<int>();

                // Wenn der Beleg von der Folgeperiode ist und diese Importe abgelehnt wurden dann diesen Beleg überspringen
                // Wenn der Beleg von einer anderen Periode ist, eine BelegNr hat und diese Importe abgelehnt wurden dann diesen Beleg überspringen
                if (buchungenAusFolgePeriodeAuchImportieren && buchungenMitBelegNrAusAnderenPeriodeAuchImportieren)
                {
                    // update all rows the user selected
                    foreach (DataRow row in rows)
                    {
                        if (BelegIstImportierbar(Utils.ConvertToInt(row["KbBuchungStatusCode"])))
                        {
                            //#3913 für Barauszahlungen: Gegenbuchung erstellen und anderen BelegKreis verwenden
                            bool isAusgedruckt = Utils.ConvertToInt(row["KbBuchungStatusCode"]) == BUCHUNGSSTATUS_BARBELEG_AUSGEDRUCKT;
                            bool isInterneVerrechnung = Utils.ConvertToInt(row["KbAuszahlungsArtCode"]) == AUSZAHLUNGSART_IV;
                            int belegKreisCode = -1;
                            string kontoNr = null;

                            if (isAusgedruckt)
                            {
                                belegKreisCode = BELEGKREIS_AKTIVKONTO;
                                kontoNr = _kontoNrKasse;
                            }
                            else if (isInterneVerrechnung)
                            {
                                belegKreisCode = BELEGKREIS_BELEGIMPORT_IV;
                            }
                            else if (_kbMandantId == MANDANT_ASYL)
                            {
                                belegKreisCode = BELEGKREIS_BELEGIMPORT_ASYL;
                            }
                            else
                            {
                                belegKreisCode = BELEGKREIS_BELEGIMPORT_SH;
                            }

                            //ensure there exists a Belegkreis for this BelegKreisCode
                            int? kbBelegkreisID = KliBuUtil.GetKbBelegKreisId(_kbPeriodeId, belegKreisCode, kontoNr);
                            if (kbBelegkreisID == null)
                            {
                                if (!notifiedBelegkreisCodes.Contains(belegKreisCode))
                                {
                                    //make sure, we notify a missing belegkreisCode only once
                                    notifiedBelegkreisCodes.Add(belegKreisCode);

                                    string belegkreisTyp = (string)DBUtil.ExecuteScalarSQL("SELECT dbo.fnLOVMLText('KbBelegkreis', {0}, {1})", belegKreisCode, Session.User.LanguageCode);
                                    // show info
                                    KissMsg.ShowError(CLASSNAME,
                                            "ErrorImportRecordsNoBelegkreis_v01",
                                                      string.Format("Buchung mit Buchungstext:\r\n{0}\r\nkonnte nicht importiert werden.\r\n\r\nDer datzu benötigte Belegkreis wurde nicht gefunden. Bitte erstellen Sie einen Belegkreis vom Typ: '{1}'.",
                                                qryBeleg[DBO.KbBuchung.Text],
                                                belegkreisTyp));
                                }
                                continue;
                            }

                            qryBeleg.Find(string.Format("KbBuchungID = {0}", row["KbBuchungID"]));

                            // --- starte die transaktion
                            Session.BeginTransaction();

                            try
                            {
                                // init vars
                                int naechsteBelegNr = -1;

                                // check if we already have a belegNr
                                bool hasBelegNr = !DBUtil.IsEmpty(qryBeleg["BelegNr"]);

                                if (!hasBelegNr)
                                {
                                    // create new BelegNr
                                    naechsteBelegNr = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                                    EXEC dbo.spKbGetBelegNr {0}, {1}, {2};", _kbPeriodeId, belegKreisCode, kontoNr));
                                }

                                qryBeleg["KbBuchungStatusCode"] = 13;
                                qryBeleg["Text"] = Utils.TruncateString(string.Format("{0} {1} {2}",
                                            qryBeleg["Text"],
                                            qryBeleg["BudgetMonatJahr"],
                                            edtErgaenzungText.Text),
                                        DBODef.KbBuchung.Text.Length);
                                qryBeleg["BelegDatum"] = edtBuchungsdatum.EditValue;

                                if (!hasBelegNr)
                                {
                                    // validate
                                    if (naechsteBelegNr < 0)
                                    {
                                        throw new KissErrorException(string.Format("Invalid next record number, cannot apply value (BelegNr='{0}')", naechsteBelegNr));
                                    }

                                    // apply new BelegNr
                                    qryBeleg["BelegNr"] = naechsteBelegNr;
                                    qryBeleg["KbBelegKreisID"] = kbBelegkreisID;
                                }

                                qryBeleg["KbPeriodeID"] = _kbPeriodeId;
                                qryBeleg.Post();

                                // #3913 für Barauszahlungen: Gegenbuchung erstellen
                                if (isAusgedruckt)
                                {
                                    int buchungId = Utils.ConvertToInt(qryBeleg["KbBuchungId"]);
                                    decimal betrag = Utils.ConvertToDecimal(qryBeleg["Betrag"]);
                                    string habenKtoNr = Utils.ConvertToString(qryBeleg["HabenKtoNr"]);

                                    int ausgleichBuchungId = Balance.ErstelleAusgleichsBuchung(betrag,
                                            habenKtoNr,
                                            _kontoNrKasse,
                                            _kbPeriodeId,
                                            edtBuchungsdatum.DateTime);

                                    int ausgleichId = Balance.ErstelleAusgleichEintrag(buchungId, ausgleichBuchungId, betrag);

                                    // --- markiere Buchung als 'Ausgeglichen'.
                                    Balance.AktualisiereBuchungsStatus(buchungId, 6);
                                }

                                Session.Commit();
                            }
                            catch (Exception ex)
                            {
                                // undo changes
                                Session.Rollback();

                                // undo changes on current row
                                qryBeleg.Row.RejectChanges();
                                qryBeleg.RefreshDisplay();

                                // show info
                                KissMsg.ShowError(CLASSNAME,
                                    "ErrorImportRecords_v04",
                                    "Es ist ein Fehler beim Importieren des Beleges aufgetreten.\r\n\r\nBuchungstext:\r\n{0}\r\n\r\nFehler:\r\n{1}",
                                    string.Format("KbBuchungID='{0}'", qryBeleg[DBO.KbBuchung.KbBuchungID]),
                                    ex,
                                              qryBeleg[DBO.KbBuchung.Text], ex.Message);
                            }
                        }
                        else
                        {
                            //System.Diagnostics.Debug.WriteLine("Beleg wurde ignoriert");
                        }
                    } // [foreach]
                }
            }

            finally
            {
                Cursor = Cursors.Default;
            }
        }

        //@@TODO refactor!
        private void SetBelegkreise(int kbPeriodeID)
        {
            //KbBelegkreis  2:  Belegimport Sozialhilfe
            //              5:  Belegimport Asyl
            _kbMandantId = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                SELECT KbMandantID
                FROM dbo.KbPeriode
                WHERE KbPeriodeID = {0};", kbPeriodeID));
        }

        private void SetKontoNrKasse(int kbPeriodeID)
        {
            _kontoNrKasse = Convert.ToString(DBUtil.ExecuteScalarSQLThrowingException(
                @"SELECT KontoNr
                  FROM dbo.KbBelegKreis KBK
                  WHERE KBK.KbPeriodeID = {0}
                    AND KBK.KbBelegKreisCode = 1      -- aktivKonto
                    AND KBK.KontoNr = (SELECT KontoNr
                                       FROM dbo.KbKonto
                                       WHERE KbPeriodeID = {0}
                                         AND ',' + KbKontoartCodes + ',' LIKE '%,60,%');", kbPeriodeID));
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