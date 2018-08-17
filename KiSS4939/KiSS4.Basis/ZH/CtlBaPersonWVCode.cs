using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using Kiss.Infrastructure;
using Kiss.Interfaces.UI;
using KiSS4.Common.ZH;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Basis.ZH
{
    public partial class CtlBaPersonWVCode : KissUserControl
    {
        #region Fields

        #region Public Constant/Read-Only Fields

        public const string CLASSNAME = "CtlBaPersonWVCode";

        #endregion

        #region Private Constant/Read-Only Fields

        private readonly List<int> _allCodes = new List<int>();
        private readonly string _allCodesString;

        // Falls im BeforePost ein Folge-WV-Code angelegt wird, darf nicht nochmals eine Row eingefügt werden
        private readonly Dictionary<int, string> _bedFromCode = new Dictionary<int, string>();

        private readonly Dictionary<int, string> _codeTextFromCode = new Dictionary<int, string>();
        private readonly Dictionary<int, int> _dauerFromCode = new Dictionary<int, int>();
        private readonly Dictionary<int, string> _folgeCodeStringsFromCode = new Dictionary<int, string>();
        private readonly Dictionary<int, List<int>> _folgeCodesFromCode = new Dictionary<int, List<int>>();
        private readonly Dictionary<int, int> _pflichtFolgeCodeFromCode = new Dictionary<int, int>();

        #endregion

        #region Private Fields

        private bool _autoInsertedRowInBeforePostEvent;
        private int _baPersonID;
        private DataTable _codesVorher;
        private bool _insertingFolgeCode;
        private bool _unchanged = true;

        #endregion

        #endregion

        #region Constructors

        public CtlBaPersonWVCode()
        {
            InitializeComponent();

            // In Design-Mode this throws an exception, and I couldn't fix it with checking for DesignMode (not sure why)
            try
            {
                var qryLovBaWVCode = DBUtil.OpenSQL(@"
                    SELECT  Code,
                            Text = Shorttext + '  ' + Text,
                            ShortText
                    FROM dbo.XLOVCode
                    WHERE LOVName = 'BaWVCode'");

                ddlWVCode.LoadQuery(qryLovBaWVCode);
                colWVCode.ColumnEdit = grdBaWVCode.GetLOVLookUpEdit(qryLovBaWVCode, "Code", "ShortText");

                colBED.ColumnEdit = grdBaWVCode.GetLOVLookUpEdit("BaBED");
                colStatus.ColumnEdit = grdBaWVCode.GetLOVLookUpEdit("BaWVStatus");

                qryWVCodeLOV.Fill();
                // statische Daten laden
                foreach (DataRow row in qryWVCodeLOV.DataTable.Rows)
                {
                    int code = (int)row["Code"];
                    _codeTextFromCode[code] = row["ShortText"] as string;
                    _folgeCodeStringsFromCode[code] = row["Value1"] as string;
                    _bedFromCode[code] = row["Value2"] as string;
                    _allCodes.Add(code);
                    if (!DBUtil.IsEmpty(row["BFSCode"]))
                    {
                        _pflichtFolgeCodeFromCode[code] = (int)row["BFSCode"];
                    }

                    if (!DBUtil.IsEmpty(row["Dauer"]))
                    {
                        _dauerFromCode[code] = (int)row["Dauer"];
                    }

                    string folgeCodesString = row["Value1"] as string;
                    if (!string.IsNullOrEmpty(folgeCodesString))
                    {
                        _folgeCodesFromCode[code] = new List<string>(folgeCodesString.Split(',')).ConvertAll(Convert.ToInt32);
                    }
                    else
                    {
                        _folgeCodesFromCode[code] = new List<int>();
                    }
                }

                _allCodesString = string.Join(",", _allCodes.ConvertAll(Convert.ToString).ToArray());

                SetTimelineColors();
            }
            catch (Exception ex)
            {
                Trace.WriteLine("CtlBaPersonWVCode.CtlBaPersonWVCode(): " + ex.Message);
            }
        }

        #endregion

        #region Properties

        public int BaPersonID
        {
            set
            {
                _baPersonID = value;
                FillWVCodes(value);
                pnlFeedback.Visible = false;
                edtFeedback.Text = string.Empty;
            }

            get
            {
                return _baPersonID;
            }
        }

        private bool CanInsertWVCode
        {
            get
            {
                DataRow[] rows = qryBaWVCode.DataTable.Select("DatumBis IS NULL AND BaWVStatusCode <> 2"); //Status <> Falsch;
                return rows == null || rows.Length == 0;
            }
        }

        private bool CanUpdateWVCode
        {
            get
            {
                if (DBUtil.IsEmpty(qryBaWVCode["BaWVCodeID"]))
                {
                    return false;
                }

                DataRow[] rows = qryBaWVCode.DataTable.Select("BaWVStatusCode <> 2", "DatumVon DESC"); //Status <> Falsch;
                return rows != null && rows.Length > 0 && (int)rows[0]["BaWVCodeID"] == (int)qryBaWVCode["BaWVCodeID"];
            }
        }

        private object LastDateTo
        {
            get
            {
                DataRow[] rows = qryBaWVCode.DataTable.Select("BaWVStatusCode <> 2", "DatumBis DESC, DatumVon DESC"); //Status <> Falsch;
                if (rows != null && rows.Length > 0)
                {
                    return rows[0]["DatumBis"];
                }

                return DBNull.Value;
            }
        }

        #endregion

        #region EventHandlers

        private void ddlStatus_EditValueChanging(object sender, ChangingEventArgs e)
        {
            int? newValue = e.NewValue as int?;
            if (newValue.HasValue && newValue.Value == 2 /*falsch*/&& (int)qryBaWVCode["BaWVStatusCode"] != 2)
            {
                var anzahlEinheiten = qryBaWVCode["AnzahlEinheiten"] as int?;
                if (anzahlEinheiten.HasValue && anzahlEinheiten.Value > 0)
                {
                    int anzahlEinzelposten = (int)DBUtil.ExecuteScalarSQLThrowingException(@"
                        SELECT Count(*)
                        FROM WhWVEinheitMitglied      WVM
                          INNER JOIN KbWVEinzelposten EIP ON WVM.WhWVEinheitMitgliedID = EIP.WhWVEinheitMitgliedID
                        WHERE WVM.BaWVCodeID = {0}",
                        qryBaWVCode["BaWVCodeID"]);
                    if (!KissMsg.ShowQuestion(
                            "<MaskName>",
                            "WirklichFalschSetzen",
                            "Dieser WV-Code wird bereits in WV-Einheiten verwendet. Mit dem Setzten des Status 'Falsch' dieses Codes werden die entsprechenden WV-Einheiten {0}.{1}{1}Wollen Sie wirklich den Status auf 'Falsch' setzen?",
                            0,
                            0,
                            true,
                            anzahlEinzelposten == 0 ? "gelöscht" : "ungültig gesetzt",
                            Environment.NewLine))
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        private void ddlWVCode_CloseUp(object sender, CloseUpEventArgs e)
        {
            /*
                       Specifies that the dropdown window was closed because an end user:
              ButtonClick  clicked the editor's dropdown button.
              Cancel       pressed the ESC key or clicked the close button
                       (available for LookUpEdit, CalcEdit and PopupContainerEdit controls).
              CloseUpKey   pressed a shortcut used to close the dropdown (the ALT+DOWN ARROW or RepositoryItemPopupBase.CloseUpKey).
              Immediate    clicked outside the editor.
              Normal       selected an option from the editor's dropdown.
              */

            e.AcceptValue = true;

            if (e.Value != ddlWVCode.EditValue)
            {
                ddlBED.EditValue = null;
            }
        }

        private void ddlWVCode_EditValueChanging(object sender, ChangingEventArgs e)
        {
            int? newValue = e.NewValue as int?;
            if (newValue.HasValue && _bedFromCode.ContainsKey(newValue.Value))
            {
                string bedCriteria = _bedFromCode[newValue.Value];
                if (bedCriteria != null)
                {
                    SetBEDList(bedCriteria);
                }
            }
        }

        private void qryBaWVCode_AfterInsert(object sender, EventArgs e)
        {
            qryBaWVCode["BaPersonID"] = _baPersonID;
            object lastDateObj = LastDateTo;
            if (lastDateObj is DateTime)
            {
                qryBaWVCode["DatumVon"] = ((DateTime)lastDateObj).AddDays(1);
            }

            qryBaWVCode.RowModified = true;

            ddlWVCode.Focus();
        }

        private void qryBaWVCode_BeforeDelete(object sender, EventArgs e)
        {
            if ((int)qryBaWVCode["AnzahlEinheiten"] > 0)
            {
                int anzahlEinzelposten = (int)DBUtil.ExecuteScalarSQLThrowingException(@"
                    SELECT Count(*)
                    FROM WhWVEinheitMitglied      WVM
                      INNER JOIN KbWVEinzelposten EIP ON WVM.WhWVEinheitMitgliedID = EIP.WhWVEinheitMitgliedID
                    WHERE WVM.BaWVCodeID = {0}",
                    qryBaWVCode["BaWVCodeID"]);

                if (anzahlEinzelposten > 0)
                {
                    throw new KissErrorException("Dieser WV-Code wird bereits in WV-Einheiten verwendet auf welche WV-Einzelposten generiert wurden. Der WV-Code kann nicht mehr gelöscht werden, setzten sie ihn auf ungültig");
                }

                if (!KissMsg.ShowQuestion(
                        "<MaskName>",
                        "EinheitVorhanden",
                        "Dieser WV-Code wird bereits in WV-Einheiten verwendet. Mit dem Löschen dieses Codes werden die entsprechenden WV-Einheiten gelöscht.{0}{0}Wollen Sie wirklich den WV-Code löschen?",
                        0,
                        0,
                        true,
                        Environment.NewLine))
                {
                    throw new KissCancelException();
                }
            }
        }

        private void qryBaWVCode_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            if ((bool)qryBaWVCode["Migriert"])
            {
                throw new KissErrorException(
                    KissMsg.GetMLMessage(
                        CLASSNAME,
                        "NichtLoeschbarDaMigriert",
                        "Dieser WV-Code ist migriert und kann deshalb nicht gelöscht werden. Setzen Sie den Status auf 'Falsch' und erzeugen Sie einen neuen.",
                        KissMsgCode.MsgInfo));
            }
        }

        private void qryBaWVCode_BeforePost(object sender, EventArgs e)
        {
            _unchanged = false;
            //Muss ausgefüllt sein: DatumVon, WVCode, BED
            DBUtil.CheckNotNullField(edtDatumVon, KissMsg.GetMLMessage(CLASSNAME, "Eroeffnungsdatum", "Eröffnungsdatum"));
            DBUtil.CheckNotNullField(ddlWVCode, KissMsg.GetMLMessage(CLASSNAME, "WVCode", "WV-Code"));
            DBUtil.CheckNotNullField(ddlBED, KissMsg.GetMLMessage(CLASSNAME, "BaBedID", "BED"));
            DBUtil.CheckNotNullField(ddlStatus, KissMsg.GetMLMessage(CLASSNAME, "BaWVStatusCode", "Status"));

            //DatumVon > DatumBis
            if (!DBUtil.IsEmpty(qryBaWVCode["DatumBis"]))
            {
                if ((DateTime)qryBaWVCode["DatumVon"] > (DateTime)qryBaWVCode["DatumBis"])
                {
                    throw new KissErrorException(
                        KissMsg.GetMLMessage(CLASSNAME, "DatumBisGroesserDatumVon", "Das Von-Datum muss kleiner als das Bis-Datum sein!", KissMsgCode.MsgInfo));
                }
            }

            HandleFolgeCode();
            FillTimeline(true);
        }

        private void qryBaWVCode_PositionChanged(object sender, EventArgs e)
        {
            SetWVCodeList();

            // Falls bereits WV-EPs erzeugt wurden kann nichts mehr verändert werden
            bool einzelpostenVorhanden = !DBUtil.IsEmpty(qryBaWVCode["AnzahlEinzelposten"]) && (int)qryBaWVCode["AnzahlEinzelposten"] > 0;

            if (einzelpostenVorhanden)
            {
                edtDatumVon.EditMode = EditModeType.ReadOnly;
                edtDatumBis.EditMode = EditModeType.ReadOnly;
                ddlWVCode.EditMode = EditModeType.ReadOnly;
                ddlBED.EditMode = EditModeType.ReadOnly;
            }
            else
            {
                edtDatumVon.EditMode = EditModeType.Required;
                edtDatumBis.EditMode = EditModeType.Normal;
                ddlWVCode.EditMode = EditModeType.Required;
                ddlBED.EditMode = EditModeType.Required;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public void Activate()
        {
            edtDatumVon.Focus();
        }

        public override bool OnAddData()
        {
            _autoInsertedRowInBeforePostEvent = false;
            return qryBaWVCode.Post() && (_autoInsertedRowInBeforePostEvent || qryBaWVCode.Insert() != null);
        }

        public override bool OnSaveData()
        {
            try
            {
                edtBemerkung.DoValidate();
                //KissMsg.ShowInfo(string.Format("OnSaveData, RowState: {0}, Modified: {1}", qryBaWVCode.Row.RowState, qryBaWVCode.RowModified));
                //KissMsg.ShowInfo(string.Format("Post: {0}, Validate: {1}, BatchUpdate: {2}", qryBaWVCode.Post(),ValidateCodes(),BatchUpdate()));
                return (qryBaWVCode.Post() && ValidateCodes() && BatchUpdate()) || _unchanged;
            }
            catch (KissCancelException ex)
            {
                ex.ShowMessage();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("IKissDataNavigator", "FehlerDatensatzSpeichern", "Datensatz kann nicht gespeichert werden.", ex);
            }

            return false;
        }

        public override void OnUndoDataChanges()
        {
            UndoBatchChanges();
        }

        public bool UndoBatchChanges()
        {
            if (KissMsg.ShowQuestion(CLASSNAME, "WirklichRueckgaengig", "Wollen Sie wirklich alle Änderungen seit dem letzten Speichern verwerfen?"))
            {
                FillWVCodes(BaPersonID);
                pnlFeedback.Visible = false;
                edtFeedback.Text = string.Empty;
                return true;
            }

            return false;
        }

        #endregion

        #region Private Static Methods

        private static string GetDateString(DateTime date)
        {
            const string unendlich = "[unendlich]";
            return date == DateTime.MaxValue.Date ? unendlich : date.ToString("dd.MM.yyyy");
        }

        private static DateTime Max(DateTime date1, DateTime date2)
        {
            return date1 > date2 ? date1 : date2;
        }

        private static DateTime Min(DateTime date1, DateTime date2)
        {
            return date1 < date2 ? date1 : date2;
        }

        #endregion

        #region Private Methods

        private bool BatchUpdate()
        {
            const string updateStmt = @"UPDATE BaWVCode
                                        SET DatumVon = {2}, DatumBis = {3}, BaWVStatusCode = {4}, WVCode = {5}, BaBedID = {6}, DatumRekurs = {7}, Bemerkung = {8}, SKZNummer = {9}
                                        WHERE BaWVCodeID = {0} AND BaWVCodeTS = {1}";
            const string insertStmt = @"INSERT INTO BaWVCode (BaPersonID, DatumVon, DatumBis, BaWVStatusCode, WVCode, BaBedID, DatumRekurs, Bemerkung, SKZNummer)
                                        VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8})";
            const string deleteStmt = @"DELETE FROM BaWVCode WHERE BaWVCodeID = {0} AND Migriert = 0 AND BaWVCodeTS = {1}";
            int changes = 0;
            bool success = true;
            try
            {
                Session.BeginTransaction();
                foreach (DataRow row in qryBaWVCode.DataTable.Rows)
                {
                    if (row.RowState == DataRowState.Deleted)
                    {
                        RemoveCodeFromWvEinheit(
                            (int)row["BaWVCodeID", DataRowVersion.Original], (int)row["BaPersonID", DataRowVersion.Original], row["BaWVCodeTS", DataRowVersion.Original], false);
                        success &= (DBUtil.ExecSQLThrowingException(deleteStmt, row["BaWVCodeID", DataRowVersion.Original], row["BaWVCodeTS", DataRowVersion.Original]) == 1);

                        // Eintrag ins Fallverlaufsprotokoll
                        CreateFaJournal(
                            string.Format(
                                "WV-Code gelöscht: {0}, von {1:d} bis {2:d}, BED {3}",
                                _codeTextFromCode[(int)row["WVCode", DataRowVersion.Original]],
                                row["DatumVon", DataRowVersion.Original],
                                ExplainNull(row["DatumBis", DataRowVersion.Original]),
                                row["BaBedID", DataRowVersion.Original]));
                        changes++;
                    }
                    else if (row.RowState == DataRowState.Added)
                    {
                        success &=
                            (DBUtil.ExecSQLThrowingException(
                                insertStmt,
                                row["BaPersonID"],
                                row["DatumVon"],
                                row["DatumBis"],
                                row["BaWVStatusCode"],
                                row["WVCode"],
                                row["BaBedID"],
                                row["DatumRekurs"],
                                row["Bemerkung"],
                                row["SKZNummer"]) == 1);
                        // Eintrag ins Fallverlaufsprotokoll
                        CreateFaJournal(
                            string.Format(
                                "WV-Code erfasst: {0}, von {1:d} bis {2:d}, BED {3}",
                                _codeTextFromCode[(int)row["WVCode"]],
                                row["DatumVon"],
                                ExplainNull(row["DatumBis"]),
                                row["BaBedID"]));
                        changes++;
                    }
                    else if (row.RowState == DataRowState.Modified)
                    {
                        bool onlyBemerkungChanged = true;
                        bool statusChanged = false;
                        bool contentChanged = false;
                        foreach (DataColumn column in row.Table.Columns)
                        {
                            if (column.Caption == "Bemerkung")
                            {
                                continue;
                            }

                            if ((DBUtil.IsEmpty(row[column.Caption]) != DBUtil.IsEmpty(row[column.Caption, DataRowVersion.Original])
                                 || !DBUtil.IsEmpty(row[column.Caption]) && !row[column.Caption].Equals(row[column.Caption, DataRowVersion.Original])))
                            {
                                if (column.Caption == "BaWVStatusCode")
                                {
                                    statusChanged = true;
                                }
                                else
                                {
                                    contentChanged = true;
                                }

                                onlyBemerkungChanged = false;
                            }
                        }

                        success &= (DBUtil.ExecSQLThrowingException(
                            updateStmt,
                            row["BaWVCodeID"],
                            row["BaWVCodeTS"],
                            row["DatumVon"],
                            row["DatumBis"],
                            row["BaWVStatusCode"],
                            row["WVCode"],
                            row["BaBedID"],
                            row["DatumRekurs"],
                            row["Bemerkung"],
                            row["SKZNummer"]) == 1);
                        if (!onlyBemerkungChanged)
                        {
                            changes++;
                            DataRow[] rowsOriginal = _codesVorher.Select(string.Format("BaWVCodeID = {0}", row["BaWVCodeID"]));
                            if (rowsOriginal.Length != 1)
                            {
                                throw new KissErrorException("Der Original-WV-Code wurde nicht gefunden");
                            }

                            DataRow rowOriginal = rowsOriginal[0];
                            DateTime? bisVorher = rowOriginal["DatumBis"] as DateTime?;
                            DateTime? bisNachher = row["DatumBis"] as DateTime?;
                            // Muss die Person aus der WV-Einheit entfernt werden?
                            if ((int)row["WVCode"] != (int)rowOriginal["WVCode"] ||
                                (int)row["BaBedID"] != (int)rowOriginal["BaBedID"] ||
                                (DateTime)row["DatumVon"] != (DateTime)rowOriginal["DatumVon"] ||
                                bisVorher != bisNachher)
                            {
                                RemoveCodeFromWvEinheit((int)row["BaWVCodeID"], (int)row["BaPersonID"], row["BaWVCodeTS"], false);
                            }
                            else if ((int)rowOriginal["BaWVStatusCode"] == 1 && (int)row["BaWVStatusCode"] == 2)
                            {
                                // Umsetzen von Richtig -> Falsch
                                RemoveCodeFromWvEinheit((int)row["BaWVCodeID"], (int)row["BaPersonID"], row["BaWVCodeTS"], true);
                            }

                            // Eintrag ins Fallverlaufsprotokoll
                            object ohne = row["BaBedID"];
                            object vorher = row["BaBedID", DataRowVersion.Original];
                            object nachher = row["BaBedID", DataRowVersion.Current];
                            CreateFaJournal(
                                string.Format(
                                    "WV-Code {0}:{1}bisher: {2}, von {3:d} bis {4:d}, BED {5}, Status {6}{1}neu: {7}, von {8:d} bis {9:d}, BED {10}, Status {11}",
                                    statusChanged && !contentChanged ? "Statusänderung" : "mutiert",
                                    Environment.NewLine,
                                    _codeTextFromCode[(int)rowOriginal["WVCode"]],
                                    rowOriginal["DatumVon"],
                                    ExplainNull(rowOriginal["DatumBis"]),
                                    rowOriginal["BaBedID"],
                                    ResolveStatus((int)rowOriginal["BaWVStatusCode"]),
                                    _codeTextFromCode[(int)row["WVCode"]],
                                    row["DatumVon"],
                                    ExplainNull(row["DatumBis"]),
                                    row["BaBedID"],
                                    ResolveStatus((int)row["BaWVStatusCode"])));
                        }
                    }
                }

                if (success)
                {
                    if (changes > 0)
                    {
                        // WV-Einheiten anpassen
                        // Dies muss im Code erfolgen, da der BgBewilligungStatusCode im Code gesetzt wird
                        SqlQuery qryBetroffeneFaelle = DBUtil.OpenSQL(@"
                            SELECT DISTINCT LEI.FaFallID
                            FROM dbo.BgFinanzplan_BaPerson FPP
                              INNER JOIN dbo.BgFinanzplan  BFP ON BFP.BgFinanzplanID = FPP.BgFinanzplanID
                              INNER JOIN dbo.FaLeistung    LEI ON LEI.FaLeistungID   = BFP.FaLeistungID
                            WHERE FPP.BaPersonID = {0}
                              AND FPP.IstUnterstuetzt = 1",
                            BaPersonID);

                        foreach (DataRow row in qryBetroffeneFaelle.DataTable.Rows)
                        {
                            int faFallID = (int)row["FaFallID"];
                            DBUtil.ExecSQLThrowingException(@"EXECUTE spWhWVModifyUnits {0}, 0", faFallID);
                        }
                    }

                    Session.Commit();
                    int position = qryBaWVCode.Position;
                    FillWVCodes(BaPersonID);
                    qryBaWVCode.Position = position;
                }
                else
                {
                    Session.Rollback();
                }
            }
            catch (KissCancelException ex)
            {
                Session.Rollback();
                ex.ShowMessage();
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowError(CLASSNAME, "DB-Update fehlgeschlagen", "Die Änderungen konnten nicht auf die Datenbank geschrieben werden", ex);
            }

            return success;
        }

        private void CreateFaJournal(object text)
        {
            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT FaFallID
                FROM dbo.FaFallPerson
                WHERE  BaPersonID = {0}",
                BaPersonID);
            foreach (DataRow row in qry.DataTable.Rows)
            {
                DBUtil.ExecSQLThrowingException(@"INSERT FaJournal (FaFallID, BaPersonID, UserID, Text, OrgUnitID)
                                                  VALUES ({0},{1},{2},{3},{4})",
                    row["FaFallID"],
                    qryBaWVCode["BaPersonID"],
                    Session.User.UserID,
                    text,
                    Session.User["OrgUnitID"]);
            }
        }

        private object ExplainNull(object value)
        {
            if (DBUtil.IsEmpty(value))
            {
                return "(leer)";
            }

            return value;
        }

        private void FillTimeline(bool showCurrentCodesLine)
        {
            SuspendLayout();
            try
            {
                ctlTimeline.Clear();
                if (qryBaWVCode.DataTable.Rows.Count == 0)
                {
                    ctlTimeline.Visible = false;
                    splitterTimeline.Visible = false;
                    return;
                }

                ctlTimeline.Visible = true;
                splitterTimeline.Visible = true;

                TimelineItem codeLine = new TimelineItem(1, "Gespeichert");
                foreach (DataRow wvCode in _codesVorher.Select("BaWVStatusCode = 1"))
                {
                    int baWvCode = (int)wvCode["WVCode"];
                    DateTime from = (DateTime)wvCode["DatumVon"];
                    object toObj = wvCode["DatumBis"];
                    DateTime to = toObj is DateTime ? (DateTime)(toObj) : new DateTime(9999, 12, 31);
                    codeLine.Sections.Add(new TimelineSection(from, to, baWvCode));
                }

                ctlTimeline.AddItem(codeLine);

                if (showCurrentCodesLine)
                {
                    TimelineItem codeLineCurrent = new TimelineItem(2, "Aktuell");
                    foreach (DataRow wvCode in qryBaWVCode.DataTable.Select("BaWVStatusCode = 1 AND WVCode IS NOT NULL"))
                    {
                        int baWvCode = (int)wvCode["WVCode"];
                        DateTime from = (DateTime)wvCode["DatumVon"];
                        object toObj = wvCode["DatumBis"];
                        DateTime to = toObj is DateTime ? (DateTime)(toObj) : new DateTime(9999, 12, 31);
                        codeLineCurrent.Sections.Add(new TimelineSection(from, to, baWvCode));
                    }

                    ctlTimeline.AddItem(codeLineCurrent);
                }

                TimelineItem codeLineWrong = new TimelineItem(3, "Status Falsch");
                foreach (DataRow wvCode in qryBaWVCode.DataTable.Select("BaWVStatusCode = 2 AND WVCode IS NOT NULL"))
                {
                    int baWvCode = (int)wvCode["WVCode"];
                    DateTime from = (DateTime)wvCode["DatumVon"];
                    object toObj = wvCode["DatumBis"];
                    DateTime to = toObj is DateTime ? (DateTime)(toObj) : new DateTime(9999, 12, 31);
                    codeLineWrong.Sections.Add(new TimelineSection(from, to, baWvCode));
                }

                if (codeLineWrong.Sections.Count > 0)
                {
                    ctlTimeline.AddItem(codeLineWrong);
                }

                TimelineItem fpLine = new TimelineItem(4, "Finanzplan");
                foreach (DataRow finanzplan in qryBgFinanzplan.DataTable.Rows)
                {
                    int id = (int)finanzplan["BgFinanzplanID"];
                    DateTime from = (DateTime)finanzplan["Von"];
                    object toObj = finanzplan["Bis"];
                    DateTime to = toObj is DateTime ? (DateTime)(toObj) : new DateTime(9999, 12, 31);
                    fpLine.Sections.Add(new TimelineSection(from, to, 110));
                }

                if (fpLine.Sections.Count > 0)
                {
                    ctlTimeline.AddItem(fpLine);
                }

                DateTime min;
                DateTime max;
                ctlTimeline.GetBorderDates(out min, out max);
                ctlTimeline.FromDate = min;
                ctlTimeline.ToDate = max;
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("d", null, null, ex);
            }
            finally
            {
                ResumeLayout();
            }
        }

        private void FillWVCodes(int baPersonID)
        {
            qryBaWVCode.Fill(baPersonID);
            GetFinanzplanPerioden(BaPersonID);
            _codesVorher = qryBaWVCode.DataTable.Copy();
            FillTimeline(false);
            _unchanged = true;
        }

        private List<KeyValuePair<DateTime, DateTime>> GetAbgedecktePerioden(DataRow[] wvCodes)
        {
            List<KeyValuePair<DateTime, DateTime>> perioden = new List<KeyValuePair<DateTime, DateTime>>();
            //try{
            foreach (DataRow row in wvCodes)
            {
                bool eingetragen = false;
                DateTime von1 = (DateTime)row["DatumVon"];
                DateTime bis1 = DBUtil.IsEmpty(row["DatumBis"]) ? DateTime.MaxValue.Date : (DateTime)row["DatumBis"];
                for (int i = 0; i < perioden.Count; i++) // KeyValuePair<DateTime,DateTime> span in perioden )
                {
                    DateTime von2 = perioden[i].Key;
                    DateTime bis2 = perioden[i].Value;
                    if (UeberschneidenSichPerioden(von1, bis1, von2, bis2) ||
                        bis1 == von2.AddDays(-1) || bis2 == von1.AddDays(-1))
                    {
                        perioden[i] = new KeyValuePair<DateTime, DateTime>(Min(von1, von2), Max(bis1, bis2));
                        eingetragen = true;
                        break;
                    }
                }
                if (!eingetragen)
                {
                    perioden.Add(new KeyValuePair<DateTime, DateTime>(von1, bis1));
                }
            }

            // debug
            /*
            string msg = "Perioden:" + Environment.NewLine;
            foreach(KeyValuePair<DateTime,DateTime> span in perioden)
            {
                msg += string.Format("{0} - {1}{2}", span.Key.ToShortDateString(), span.Value.ToShortDateString(), Environment.NewLine);
            }
            KissMsg.ShowInfo(msg);
            */
            //}catch(Exception ex){KissMsg.ShowError(ex.Message, null,null, ex);}
            return perioden;
        }

        private List<KeyValuePair<DateTime, DateTime>> GetFinanzplanPerioden(int baPersonID)
        {
            qryBgFinanzplan.Fill(baPersonID);
            List<KeyValuePair<DateTime, DateTime>> perioden = new List<KeyValuePair<DateTime, DateTime>>();
            foreach (DataRow row in qryBgFinanzplan.DataTable.Rows)
            {
                perioden.Add(new KeyValuePair<DateTime, DateTime>((DateTime)row["Von"], DBUtil.IsEmpty(row["Bis"]) ? DateTime.MaxValue : (DateTime)row["Bis"]));
            }

            return perioden;
        }

        private List<KeyValuePair<DateTime, DateTime>> GetNichtAbgedecktePerioden(List<KeyValuePair<DateTime, DateTime>> vorher, List<KeyValuePair<DateTime, DateTime>> nachher)
        {
            List<KeyValuePair<DateTime, DateTime>> nichtAbgedeckt = new List<KeyValuePair<DateTime, DateTime>>();
            List<KeyValuePair<DateTime, DateTime>> neuErzeugt = new List<KeyValuePair<DateTime, DateTime>>();
            foreach (KeyValuePair<DateTime, DateTime> periodeSoll in vorher)
            {
                bool abgedeckt = false;
                DateTime vonSoll = periodeSoll.Key;
                DateTime bisSoll = periodeSoll.Value;

                foreach (KeyValuePair<DateTime, DateTime> periodeIst in nachher)
                {
                    DateTime vonIst = periodeIst.Key;
                    DateTime bisIst = periodeIst.Value;
                    if (vonIst <= vonSoll && bisIst >= bisSoll)
                    {
                        //Ist-Periode deckt Soll-Periode komplett ab
                        abgedeckt = true;
                        break;
                    }

                    if (vonIst > vonSoll && vonIst < bisSoll)
                    {
                        // Ist-Periode startet in Soll-Periode
                        if (bisIst > vonSoll && bisIst < bisSoll && bisIst < DateTime.MaxValue.Date)
                        {
                            // ...und endet in Soll-Periode -> neue Soll-Periode erzeugen
                            neuErzeugt.Add(new KeyValuePair<DateTime, DateTime>(bisIst.AddDays(1), bisSoll));
                        }
                        bisSoll = vonIst.AddDays(-1);
                    }
                    else if (bisIst > vonSoll && bisIst < bisSoll)
                    {
                        // Ist-Periode endet in Soll-Periode
                        vonSoll = bisIst.AddDays(1);
                    }
                }

                if (!abgedeckt)
                {
                    nichtAbgedeckt.Add(new KeyValuePair<DateTime, DateTime>(vonSoll, bisSoll));
                }
            }

            // die neu erzeugten Perioden prüfen (rekursiv)
            if (neuErzeugt.Count > 0)
            {
                nichtAbgedeckt.AddRange(GetNichtAbgedecktePerioden(neuErzeugt, nachher));
            }

            return nichtAbgedeckt;
        }

        private void HandleFolgeCode()
        {
            // es soll kein Folgecode des Folgecodes angelegt werden, sonst enden wir in einer Endlosschlaufe
            if (_insertingFolgeCode)
            {
                return;
            }

            // aktuellen Code bestimmen
            int wvCode = (int)qryBaWVCode["WVCode"];

            // Folgecode zwingend?
            if (!_pflichtFolgeCodeFromCode.ContainsKey(wvCode) || !_dauerFromCode.ContainsKey(wvCode)) // TODO bei Einführung W-Modul: || !FPgenehmigt ) )
            {
                return;
            }

            // Sind schon EPs erzeugt, darf an den Datums nicht mehr geschraubt werden
            int? anzahlEPsTmp = qryBaWVCode["AnzahlEinzelposten"] as int?;
            int anzahlEPs = anzahlEPsTmp.HasValue ? anzahlEPsTmp.Value : 0;

            DateTime datumVon = (DateTime)qryBaWVCode["DatumVon"];
            int dauerMonate = _dauerFromCode[wvCode];
            DateTime maxStartDatumFolgeCode = datumVon.AddMonths(dauerMonate);
            // Bestehenden Folgecode suchen (kann irgendwann in Max-Zeitspanne des aktuellen Codes starten)
            DataRow[] folgeCodes = qryBaWVCode.DataTable.Select(string.Format(
                "BaWVStatusCode = 1 AND WVCode IN ({0}) AND DatumVon > '{1}' AND DatumVon <= '{2}'",
                _folgeCodeStringsFromCode[wvCode], datumVon, maxStartDatumFolgeCode));
            if (folgeCodes.Length > 0)
            {
                DateTime vonDatumFolgeCode = (DateTime)(folgeCodes[0]["DatumVon"]);
                // Es gibt bereits einen Folgecode
                if (anzahlEPs == 0 &&
                    (DBUtil.IsEmpty(qryBaWVCode["DatumBis"]) ||
                     vonDatumFolgeCode.AddDays(-1) != (DateTime)qryBaWVCode["DatumBis"] &&
                     KissMsg.ShowQuestion(
                         CLASSNAME,
                         "BisDatumAnFolgeCodeAnpassen",
                         "Sie haben {0} als Enddatum eingegeben, der Folgecode beginnt aber {1} am {2}. Soll das Enddatum angepasst werden?",
                         0,
                         0,
                         true,
                         ((DateTime)qryBaWVCode["DatumBis"]).ToString("dd.MM.yyyy"),
                         (vonDatumFolgeCode.AddDays(-1) > (DateTime)qryBaWVCode["DatumBis"]) ? "erst" : "bereits",
                         vonDatumFolgeCode.ToString("dd.MM.yyyy"))))
                {
                    // Bis-Datum an Folgecode anpassen, falls
                    // - bisher leer
                    // oder
                    // -Folgecode beginnt früher als eingegebenes bzw. vorgeschlagenes Datum. Frage an User: Datum anpassen?
                    qryBaWVCode["DatumBis"] = vonDatumFolgeCode.AddDays(-1);
                }
            }
            else
            {
                // Bisher kein Folgecode
                if (anzahlEPs == 0 && DBUtil.IsEmpty(qryBaWVCode["DatumBis"]))
                {
                    // falls bisher leer, Bis-Datum durch maximale Dauer des WV-Codes ausfüllen
                    qryBaWVCode["DatumBis"] = maxStartDatumFolgeCode.AddDays(-1);
                }

                // Vorschlag an User: Folgecode anlegen?
                if (KissMsg.ShowQuestion(CLASSNAME, "FolgeCodeEinfuegen", "Für diesen WV-Code ist ein FolgeCode zwingend. Soll ein Datensatz angelegt werden?"))
                {
                    try
                    {
                        DateTime bis = (DateTime)qryBaWVCode["DatumBis"];
                        _insertingFolgeCode = true;
                        if (qryBaWVCode.Insert() != null)
                        {
                            int folgeCode = _pflichtFolgeCodeFromCode[wvCode];
                            qryBaWVCode["BaWVStatusCode"] = 1; // Richtig
                            qryBaWVCode["WVCode"] = folgeCode;
                            qryBaWVCode["BaBedID"] = int.Parse((_bedFromCode[folgeCode]).Substring(0, 5));
                            qryBaWVCode["DatumVon"] = bis.AddDays(1);
                            _autoInsertedRowInBeforePostEvent = true;
                        }
                    }
                    finally
                    {
                        _insertingFolgeCode = false;
                    }
                }
            }
        }

        private void RemoveCodeFromWvEinheit(int baWVCodeID, int baPersonID, object baWVCodeTs, bool ungueltigSetzen)
        {
            //const string deleteMitgliedStmt = @"DELETE FROM WhWvEinheitMitglied WHERE BaWVCodeID = {0}";

            // WV-Code oder BED verändert -> weg damit
            // ToDo: Check, ob Einzelposten auf Einheit verweisen, dann diese falsch setzen
            DBUtil.ExecSQLThrowingException(@"
                DECLARE @WhWvEinheitID int,
                        @BaPersonID int,
                        @WVTraeger int,
                        @WhWvEinheitMitgliedID int

                DECLARE cWVCode CURSOR FAST_FORWARD FOR
                  SELECT WhWvEinheitID, WhWvEinheitMitgliedID, BaPersonID
                  FROM WhWVEinheitMitglied
                  WHERE BaWVCodeID = {0}

                OPEN cWVCode
                WHILE 1=1 BEGIN
                  FETCH NEXT FROM cWVCode INTO @WhWvEinheitID, @WhWvEinheitMitgliedID, @BaPersonID
                  IF @@FETCH_STATUS <> 0 BREAK

                  --Check: Ist auf dieses Mitglied eine Buchung erzeugt worden?
                  IF {0} = 1 OR EXISTS(SELECT *
                                       FROM WhWvEinheitMitglied         PRS
                                         INNER JOIN WhWvEinheitMitglied WVM ON WVM.WhWvEinheitID = PRS.WhWvEinheitID
                                         INNER JOIN KbWVEinzelposten    WVP ON WVP.WhWvEinheitMitgliedID = WVM.WhWvEinheitMitgliedID
                                       WHERE PRS.WhWvEinheitMitgliedID = @WhWvEinheitMitgliedID ) BEGIN
                    -- Buchung existiert -> WV-Einheit auf ungültig setzen
                    UPDATE WhWVEinheit
                    SET Ungueltig = 1
                    WHERE WhWVEinheitID = @WhWvEinheitID
                  END
                  ELSE BEGIN
              /*
                    -- Noch keine Buchung -> WV-Mitglied kann gelöscht werden
                    SELECT @WVTraeger = BaPersonID
                    FROM WhWVEinheit
                    WHERE WhWVEinheitID = @WhWvEinheitID

                    DELETE FROM WhWVEinheitMitglied
                    WHERE WhWVEinheitID = @WhWvEinheitID AND BaWVCodeID = {0}

                    IF @BaPersonID = @WVTraeger BEGIN
              */
                      -- ganze Einheit löschen
                      DELETE FROM WhWVEinheitMitglied
                      WHERE WhWVEinheitID = @WhWVEinheitID

                      DELETE FROM WhWVEinheit
                      WHERE WhWVEinheitID = @WhWVEinheitID
              --    END
                  END
                END

                CLOSE cWVCode
                DEALLOCATE cWVCode",
                baWVCodeID,
                baPersonID,
                baWVCodeTs,
                ungueltigSetzen);

            //DBUtil.ExecSQLThrowingException(deleteMitgliedStmt, baWVCodeID, baWVCodeTS);
        }

        private object ResolveStatus(int baWVStatusCode)
        {
            if (baWVStatusCode == 1)
            {
                return "Richtig";
            }

            if (baWVStatusCode == 2)
            {
                return "Falsch";
            }

            return "(unbekannt)";
        }

        private void SetBEDList(string bedCriteria)
        {
            SetDDLList(ddlBED, bedCriteria, "BaBED");
        }

        private void SetDDLList(KissLookUpEdit ddl, string codes, string lovName)
        {
            if (DBUtil.IsEmpty(codes))
            {
                codes = "Code"; //finds all
            }

            string[] criteria = codes.Split(',');
            string whereInString = "";

            if (codes.Contains("-"))
            {
                foreach (string s in criteria)
                {
                    if (whereInString.Length > 0)
                    {
                        whereInString += ",";
                    }

                    if (s.Contains("-"))
                    {
                        string[] minMax = s.Split('-');
                        int min;
                        int max;
                        int.TryParse(minMax[0], out min);
                        int.TryParse(minMax[1], out max);
                        for (int i = min; i <= max; i++)
                        {
                            whereInString += i.ToString();
                            if (i < max)
                            {
                                whereInString += ",";
                            }
                        }
                    }
                    else
                    {
                        whereInString += s;
                    }
                }
            }
            else
            {
                whereInString = codes;
            }

            string textString;
            if (ddl == ddlBED)
            {
                textString = "Text = CAST( Code AS varchar ) + ',  ' + Text";
            }
            else
            {
                textString = "Text = Shorttext + '  ' + Text";
            }

            string sql = @"
                SELECT Code, " + textString + @"
                FROM dbo.XLOVCode
                WHERE LOVName = {0} AND Code IN (" +
                         whereInString + @")
                ORDER BY SortKey";

            SqlQuery qry = DBUtil.OpenSQL(sql, lovName);
            ddl.Properties.DataSource = qry;
            ddl.Properties.DropDownRows = 7;

            if (qry.Count == 1)
            {
                ddl.EditValue = qry["Code"];
            }
        }

        private void SetTimelineColors()
        {
            Dictionary<int, Color> colors = new Dictionary<int, Color>();
            colors[1] = Color.LawnGreen;
            colors[2] = Color.LightBlue;
            colors[3] = Color.LightSeaGreen;
            colors[4] = Color.IndianRed;
            colors[5] = Color.SandyBrown;
            colors[6] = Color.DarkOrange;
            colors[7] = Color.Goldenrod;
            colors[8] = Color.Olive;
            colors[9] = Color.GreenYellow;
            colors[10] = Color.SpringGreen;
            colors[11] = Color.Violet;
            colors[12] = Color.Pink;
            colors[13] = Color.Thistle;
            colors[14] = Color.CornflowerBlue;
            colors[15] = Color.Yellow;
            colors[16] = Color.LightYellow;
            colors[17] = Color.Beige;
            colors[18] = Color.Khaki;
            colors[19] = Color.Gold;
            colors[20] = Color.Wheat;
            colors[21] = Color.NavajoWhite;
            colors[22] = Color.Tan;
            colors[23] = Color.LightSalmon;
            colors[24] = Color.Tomato;
            colors[25] = Color.RosyBrown;
            colors[26] = Color.LightCoral;
            colors[27] = Color.BlanchedAlmond;

            //SqlQuery qryWVCodes = DBUtil.OpenSQL("SELECT Code, ShortText FROM XLOVCode WHERE LOVName = 'BaWVCode'");
            foreach (DataRow codeRow in qryWVCodeLOV.DataTable.Rows)
            {
                int code = (int)codeRow["Code"];
                if (colors.ContainsKey(code))
                {
                    ctlTimeline.Colors[code] = new KeyValuePair<string, SolidBrush>((string)codeRow["ShortText"], new SolidBrush(colors[code]));
                }
                else
                {
                    ctlTimeline.Colors[code] = new KeyValuePair<string, SolidBrush>((string)codeRow["ShortText"], new SolidBrush(Color.White));
                }
            }

            // highlight
            ctlTimeline.Colors[100] = new KeyValuePair<string, SolidBrush>("", new SolidBrush(Color.Crimson));
            ctlTimeline.Colors[101] = new KeyValuePair<string, SolidBrush>("", new SolidBrush(Color.Crimson));
            ctlTimeline.Colors[110] = new KeyValuePair<string, SolidBrush>("", new SolidBrush(Color.Red));
        }

        private void SetWVCodeList()
        {
            if (!DBUtil.IsEmpty(qryBaWVCode["DatumVon"]))
            {
                DateTime datumBisVorCode = ((DateTime)qryBaWVCode["DatumVon"]).AddDays(-1);
                DataRow[] vorCodes = qryBaWVCode.DataTable.Select(string.Format("BaWVStatusCode = 1 AND DatumBis = '{0}'", datumBisVorCode));
                if (vorCodes.Length > 0)
                {
                    SetWVCodeList(_folgeCodeStringsFromCode[(int)vorCodes[0]["WVCode"]]);
                }
                else
                {
                    SetWVCodeList(_allCodesString);
                }
            }
            else
            {
                SetWVCodeList(_allCodesString);
            }
        }

        private void SetWVCodeList(string folgeCodes)
        {
            SetDDLList(ddlWVCode, folgeCodes, "BaWVCode");
        }

        private bool UeberschneidenSichPerioden(DateTime von1, DateTime bis1, DateTime von2, DateTime bis2)
        {
            return bis1 < von1 || bis2 < von2 ||
                   ((von1 >= von2 && von1 <= bis2) ||
                    (bis1 >= von2 && bis1 <= bis2) ||
                    (von1 <= von2 && bis1 >= bis2));
        }

        private bool ValidateCodes()
        {
            FillTimeline(true);

            string errors = "";
            // Ist noch kein WV-Code erfasst, kann auch nix falsch sein
            if (qryBaWVCode.DataTable.Rows.Count == 0)
            {
                return true;
            }

            DataRow[] codesNull = qryBaWVCode.DataTable.Select("DatumVon IS NULL OR WVCode IS NULL OR BaBedId IS NULL");
            if (codesNull.Length > 0)
            {
                errors += "Es sind nicht alle WV-Codes, BED und Datum Von ausgefüllt";
            }

            if (string.IsNullOrEmpty(errors))
            {
                // Hier wird angegeben, welche Balken gehighlighted werden. 2 bedeutet 'aktuell'
                List<int> ids = new List<int>();
                ids.Add(2);

                DateTime startDate = DateTime.MaxValue;
                DateTime endDate = DateTime.MinValue;
                // Check Überschneidung von WV-Codes
                DataRow[] codes = qryBaWVCode.DataTable.Select("BaWVStatusCode = 1", "DatumVon");
                List<DataRow> checkedCodes = new List<DataRow>();
                foreach (DataRow row1 in codes)
                {
                    checkedCodes.Add(row1);
                    DateTime von1 = (DateTime)row1["DatumVon"];
                    DateTime bis1 = DBUtil.IsEmpty(row1["DatumBis"]) ? DateTime.MaxValue.Date : (DateTime)row1["DatumBis"];
                    // Min/Max-Datum für Prüfung 'lückenlos' bestimmen
                    if (von1 < startDate)
                    {
                        startDate = von1;
                    }

                    if (bis1 > endDate)
                    {
                        endDate = bis1;
                    }

                    string bis1String = GetDateString(bis1);
                    DateTime von2Soll = (bis1 == DateTime.MaxValue.Date) ? bis1 : bis1.AddDays(1);
                    int wvCode1 = (int)row1["WVCode"];
                    bool folgeCodeOk = !_pflichtFolgeCodeFromCode.ContainsKey(wvCode1);
                    //object folgeCode =  ? pflichtFolgeCodeFromCode[wvCode1] : null;
                    foreach (DataRow row2 in codes)
                    {
                        // Damit Codekombinationen nicht 2x gecheckt werden (z.B. A/B und B/A)
                        if (checkedCodes.Contains(row2))
                        {
                            continue;
                        }

                        int wvCode2 = (int)row2["WVCode"];
                        // Überschneidung von WV-Codes
                        DateTime von2 = (DateTime)row2["DatumVon"];
                        DateTime bis2 = DBUtil.IsEmpty(row2["DatumBis"]) ? DateTime.MaxValue.Date : (DateTime)row2["DatumBis"];
                        string bis2String = GetDateString(bis2);
                        if (UeberschneidenSichPerioden(von1, bis1, von2, bis2))
                        {
                            errors += string.Format(
                                "Folgende WV-Codes überschneiden sich: {0} ({1} bis {2}) und {3} ({4} bis {5}){6}",
                                _codeTextFromCode[wvCode1],
                                GetDateString(von1),
                                bis1String,
                                _codeTextFromCode[wvCode2],
                                GetDateString(von2),
                                bis2String,
                                Environment.NewLine);
                            ctlTimeline.HighlightSection(Max(von1, von2), Min(bis1, bis2), ids, 100, null, 101);
                        }

                        // Zwei aufeinanderfolgende identische WV-Codes?
                        bool folgeCodeIdentisch = von2Soll == von2 && // unmittelbar folgend
                                                  wvCode1 == wvCode2 && // gleicher WV-Code
                                                  (int)row1["BaBedID"] == (int)row2["BaBedID"]; // gleicher BED
                        if (folgeCodeIdentisch)
                        {
                            errors += string.Format(
                                "Folgende WV-Codes sind identisch: {0} ({1} bis {2}) und {3} ({4} bis {5}){6}Bitte löschen Sie einen und dehnen den anderen aus{6}",
                                _codeTextFromCode[wvCode1],
                                GetDateString(von1),
                                bis1String,
                                _codeTextFromCode[wvCode2],
                                GetDateString(von2),
                                bis2String,
                                Environment.NewLine);
                            ctlTimeline.HighlightSection(Max(von1, von2), Min(bis1, bis2), ids, 100, null, 101);
                        }

                        // Folgecode
                        folgeCodeOk |= _folgeCodesFromCode[wvCode1].Contains(wvCode2) && von2Soll == von2;
                    }

                    if (!folgeCodeOk)
                    {
                        List<string> codeStrings = new List<string>();
                        foreach (int folgeCodeCode in _folgeCodesFromCode[wvCode1])
                        {
                            codeStrings.Add(_codeTextFromCode[folgeCodeCode]);
                        }

                        errors += string.Format(
                            "Für den Code {0} ({1} bis {2}) ist ein Folgecode zwingend, es ist aber kein gültiger ({3}) mit Startdatum {4} erfasst.{5}",
                            _codeTextFromCode[wvCode1],
                            GetDateString(von1),
                            bis1String,
                            string.Join(", ", codeStrings.ToArray()),
                            GetDateString(von2Soll),
                            Environment.NewLine);
                    }

                    // Dauer prüfen
                    if (_dauerFromCode.ContainsKey(wvCode1) && von1.AddMonths(_dauerFromCode[wvCode1]) < bis1)
                    {
                        errors += string.Format(
                            "Der Code {0} ({1} bis {2}) überschreitet die maximale Zeitdauer {3} Monate{4}",
                            _codeTextFromCode[wvCode1],
                            GetDateString(von1),
                            bis1String,
                            _dauerFromCode[wvCode1],
                            Environment.NewLine);
                    }
                }

                // nur checken, falls Daten konsistent sind
                if (string.IsNullOrEmpty(errors))
                {
                    // Vorherige Zeitspanne abgedeckt?
                    List<KeyValuePair<DateTime, DateTime>> neuAbgedecktePerioden = GetAbgedecktePerioden(qryBaWVCode.DataTable.Select("BaWVStatusCode = 1"));
                    List<KeyValuePair<DateTime, DateTime>> lueckenlosPerioden = new List<KeyValuePair<DateTime, DateTime>>();
                    lueckenlosPerioden.Add(new KeyValuePair<DateTime, DateTime>(startDate, endDate));
                    List<KeyValuePair<DateTime, DateTime>> nichtAbgedecktePerioden = GetNichtAbgedecktePerioden(lueckenlosPerioden, neuAbgedecktePerioden);
                    if (nichtAbgedecktePerioden.Count > 0 && startDate != DateTime.MaxValue && endDate != DateTime.MinValue)
                    {
                        string msg = "";
                        foreach (KeyValuePair<DateTime, DateTime> span in nichtAbgedecktePerioden)
                        {
                            msg += string.Format("{0} - {1}{2}", GetDateString(span.Key), GetDateString(span.Value), Environment.NewLine);
                            ctlTimeline.HighlightSection(span.Key, span.Value, ids, 100, null, 101);
                        }

                        errors += string.Format("Folgende Zeitspannen müssen noch abgedeckt werden:{0}{1}{0}", Environment.NewLine, msg);
                    }

                    // Falsche Codes abgedeckt?
                    //List<KeyValuePair<DateTime,DateTime>> neuAbgedecktePerioden   = GetAbgedecktePerioden(qryBaWVCode.DataTable.Select("BaWVStatusCode = 1"));
                    List<KeyValuePair<DateTime, DateTime>> falscheCodesPerioden = GetAbgedecktePerioden(qryBaWVCode.DataTable.Select("BaWVStatusCode = 2"));
                    nichtAbgedecktePerioden = GetNichtAbgedecktePerioden(falscheCodesPerioden, neuAbgedecktePerioden);
                    if (nichtAbgedecktePerioden.Count > 0)
                    {
                        string msg = "";
                        foreach (KeyValuePair<DateTime, DateTime> span in nichtAbgedecktePerioden)
                        {
                            msg += string.Format("{0} - {1}{2}", GetDateString(span.Key), GetDateString(span.Value), Environment.NewLine);
                            ctlTimeline.HighlightSection(span.Key, span.Value, ids, 100, null, 101);
                        }

                        errors += string.Format("Folgende auf falsch gesetzte WV-Codes müssen noch abgedeckt werden:{0}{1}{0}", Environment.NewLine, msg);
                    }

                    // Zeitspannen der Finanzpläne abgedeckt?
                    List<KeyValuePair<DateTime, DateTime>> finanzplanPerioden = GetFinanzplanPerioden(BaPersonID);
                    List<KeyValuePair<DateTime, DateTime>> nichtAbgedeckteFpPerioden = GetNichtAbgedecktePerioden(finanzplanPerioden, neuAbgedecktePerioden);
                    if (nichtAbgedeckteFpPerioden.Count > 0)
                    {
                        string msg = "";
                        foreach (KeyValuePair<DateTime, DateTime> span in nichtAbgedeckteFpPerioden)
                        {
                            msg += string.Format("{0} - {1}{2}", GetDateString(span.Key), GetDateString(span.Value), Environment.NewLine);
                            ctlTimeline.HighlightSection(span.Key, span.Value, ids, 100, null, 101);
                        }

                        errors += string.Format("Folgende Finanzplan-Zeitspannen müssen noch abgedeckt werden:{0}{1}{0}", Environment.NewLine, msg);
                    }
                }
            }

            if (!string.IsNullOrEmpty(errors))
            {
                pnlFeedback.Visible = true;
                // Kurzes Aufleuchten der Fehlermeldung
                edtFeedback.Text = errors;
                edtFeedback.BackColor = Color.Red;
                ApplicationFacade.DoEvents();
                Thread.Sleep(300);
                edtFeedback.BackColor = Color.Salmon;
                return false;
            }

            pnlFeedback.Visible = false;
            edtFeedback.Text = "Daten sind korrekt erfasst";
            edtFeedback.BackColor = Color.YellowGreen;
            return true;
        }

        #endregion

        #endregion
    }
}