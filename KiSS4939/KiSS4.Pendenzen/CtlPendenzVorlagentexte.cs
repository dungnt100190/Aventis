using System;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Pendenzen
{
    /// <summary>
    /// Verwaltung der Pendenzvorlagentexte
    /// </summary>
    public partial class CtlPendenzVorlagentexte : KissUserControl
    {
        private const string COL_AKTIONEN_BETREFF_ML = "BetreffML";
        private const string COL_AKTIONEN_BEZEICHNUNG_ML = "BezeichnungML";
        private const string COL_AKTIONEN_TEXT_ML = "TextML";
        private const string TASK_TYPE = "TaskType";

        private int _xlovId;

        public CtlPendenzVorlagentexte()
        {
            InitializeComponent();

            SetupDataSource();
            SetupDataMembers();
            SetupFieldNames();
        }

        private void CtlPendenzVorlagentexte_Load(object sender, EventArgs e)
        {
            tabVorlagentexte.SelectTab(tpgVorlagentexte);

            colAktionenTyp.ColumnEdit = grdAktionen.GetLOVLookUpEdit("XTaskTypeActionType");

            qryVorlagenTexte.Fill();
            _xlovId = DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT TOP 1 XLOVID
                FROM dbo.XLOV WITH (READUNCOMMITTED)
                WHERE LOVName = {0}",
                TASK_TYPE) as int? ?? 0;

            // Einfügen/löschen darf nur BIAG-Admin, aktualisieren (wegen Übersetzung) dürfen auch andere Benutzer
            qryAktionen.CanInsert = Session.User.IsUserBIAGAdmin;
            qryAktionen.CanDelete = Session.User.IsUserBIAGAdmin;
        }

        /// <summary>
        /// Gibt die nächst mögliche Code-Nummer zurück.
        /// Wenn Query die Code-Nummer kleiner 100 berechnet, wird als Standard 101 zurückgegeben
        /// </summary>
        /// <returns>Nächst höhere Code-Nummer</returns>
        private int GetNextCodeNumber()
        {
            string sqlSelectMaxCode = @"
                SELECT MAX(Code)
                FROM dbo.XLOVCode WITH(READUNCOMMITTED)
                WHERE LovName = 'TaskType';";
            int maxCountCode = Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(sqlSelectMaxCode));

            if (maxCountCode < 100)
            {
                return 101;
            }

            return ++maxCountCode;
        }

        private void qryAktionen_AfterInsert(object sender, EventArgs e)
        {
            qryAktionen[DBO.XTaskTypeAction.TaskTypeCode] = qryVorlagenTexte[DBO.XLOVCode.Code];
        }

        private void qryAktionen_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtAktionenTypCode, lblAktionenTypCode.Text);
            DBUtil.CheckNotNullField(edtAktionenBezeichnung, lblAktionenBezeichnung.Text);
        }

        private void qryAktionen_PostCompleted(object sender, EventArgs e)
        {
            // apply changed texts to ML columns
            qryAktionen[COL_AKTIONEN_BEZEICHNUNG_ML] = edtAktionenBezeichnung.EditValue;
            qryAktionen[COL_AKTIONEN_BETREFF_ML] = edtAktionenBetreff.Text;
            qryAktionen[COL_AKTIONEN_TEXT_ML] = edtAktionenText.EditValue;

            // prevent data changed (we did save data already)
            if (qryAktionen.Row != null)
            {
                qryAktionen.Row.AcceptChanges();
                qryAktionen.RowModified = false;
                qryAktionen.RefreshDisplay();
            }
        }

        /// <summary>
        /// Transaktion committen oder rollbacken
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void qryVorlagenTexte_AfterPost(object sender, EventArgs e)
        {
            try
            {
                Session.Commit();
            }
            catch
            {
                if (Session.Transaction != null)
                {
                    Session.Rollback();
                }

                throw;
            }
        }

        /// <summary>
        /// Es wird geprüft, ob der Pendenzvorlagentext gelöscht werden darf.
        /// Ist die Vorlage eine System-Vorlage oder noch einem Task angehängt, darf diese nicht gelöscht werden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void qryVorlagenTexte_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            var isSystem = Convert.ToBoolean(qryVorlagenTexte[DBO.XLOVCode.System]);

            if (isSystem)
            {
                throw new KissInfoException(
                    KissMsg.GetMLMessage(
                        Name,
                        "SystemPendenzVorlageNichtLoeschen",
                        "System-Vorlagen können weder angepasst noch gelöscht werden.",
                        KissMsgCode.MsgInfo));
            }

            var code = Convert.ToInt32(qryVorlagenTexte[DBO.XLOVCode.Code]);
            string sqlVorhandeTasksWithCode = @"
                SELECT COUNT(*)
                FROM dbo.XTask WITH(READUNCOMMITTED)
                WHERE TaskTypeCode = {0};";
            int countRecordsFound = Convert.ToInt32(DBUtil.ExecuteScalarSQL(sqlVorhandeTasksWithCode, code));

            if (countRecordsFound > 0)
            {
                var typ = qryVorlagenTexte[DBO.XLOVCode.Text].ToString();
                throw new KissInfoException(
                    KissMsg.GetMLMessage(
                        Name,
                        "PendenzVorlageBestehendePendenzenNichtLoeschen",
                        @"Die Vorlage '{0}' kann aufgrund bestehender Pendenzen nicht gelöscht werden.",
                        KissMsgCode.MsgInfo,
                        typ));
            }
        }

        /// <summary>
        /// Transaktion starten
        /// Bei Insert, wird der TaskType sowie die nächst höhere CodeNummer zugewiesen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void qryVorlagenTexte_BeforePost(object sender, EventArgs e)
        {
            var lovName = qryVorlagenTexte[DBO.XLOVCode.LOVName] as string;

            // Wenn LovCode Null, dann wird ein Insert gemacht
            Session.BeginTransaction();

            if (string.IsNullOrWhiteSpace(lovName))
            {
                qryVorlagenTexte[DBO.XLOVCode.LOVName] = TASK_TYPE;
                qryVorlagenTexte[DBO.XLOVCode.XLOVID] = _xlovId;

                var code = GetNextCodeNumber();
                qryVorlagenTexte[DBO.XLOVCode.Code] = code;

                if (DBUtil.IsEmpty(qryVorlagenTexte[DBO.XLOVCode.SortKey]))
                {
                    qryVorlagenTexte[DBO.XLOVCode.SortKey] = code;
                }
            }
        }

        private void qryVorlagenTexte_PositionChanged(object sender, EventArgs e)
        {
            qryAktionen.Fill(qryVorlagenTexte[DBO.XLOVCode.Code], Session.User.LanguageCode);

            bool isSystem = Convert.ToBoolean(qryVorlagenTexte[DBO.XLOVCode.System]);
            SetEditMode(!isSystem);
        }

        /// <summary>
        /// Anhand Flag werden die Editfelder enabled oder disabled
        /// </summary>
        /// <param name="isEnabled">True: Felder sind enabled, false: Felder sind disabled</param>
        private void SetEditMode(bool isEnabled)
        {
            var editMode = isEnabled ? EditModeType.Normal : EditModeType.ReadOnly;
            edtSortKey.EditMode = editMode;
            edtText.EditMode = editMode;
            edtBetreff.EditMode = editMode;

            // Aktionen dürfen nur von Biag-Admin verändert werden (ausser Übersetzung).
            edtAktionenBenachrichtigung.EditMode = Session.User.IsUserBIAGAdmin ? EditModeType.Normal : EditModeType.ReadOnly;
            edtAktionenTypCode.EditMode = Session.User.IsUserBIAGAdmin ? EditModeType.Required : EditModeType.ReadOnly;
            edtAktionenErstellerDarfAusfuehren.EditMode = Session.User.IsUserBIAGAdmin ? EditModeType.Normal : EditModeType.ReadOnly;
        }

        private void SetupDataMembers()
        {
            edtSortKey.DataMember = DBO.XLOVCode.SortKey;
            edtCode.DataMember = DBO.XLOVCode.Code;
            edtBetreff.DataMemberDefaultText = DBO.XLOVCode.Value1;
            edtBetreff.DataMemberTID = DBO.XLOVCode.Value1TID;
            edtBeschreibung.DataMemberDefaultText = DBO.XLOVCode.Value2;
            edtBeschreibung.DataMemberTID = DBO.XLOVCode.Value2TID;
            edtText.DataMemberDefaultText = DBO.XLOVCode.Text;
            edtText.DataMemberTID = DBO.XLOVCode.TextTID;

            edtAktionenBenachrichtigung.DataMember = DBO.XTaskTypeAction.BenachrichtigungAktiv;
            edtAktionenBetreff.DataMemberDefaultText = DBO.XTaskTypeAction.Betreff;
            edtAktionenBetreff.DataMemberTID = DBO.XTaskTypeAction.BetreffTID;
            edtAktionenBezeichnung.DataMemberDefaultText = DBO.XTaskTypeAction.Bezeichnung;
            edtAktionenBezeichnung.DataMemberTID = DBO.XTaskTypeAction.BezeichnungTID;
            edtAktionenTypCode.DataMember = DBO.XTaskTypeAction.XTaskTypeActionTypeCode;
            edtAktionenText.DataMemberDefaultText = DBO.XTaskTypeAction.Text;
            edtAktionenText.DataMemberTID = DBO.XTaskTypeAction.TextTID;
            edtAktionenErstellerDarfAusfuehren.DataMember = DBO.XTaskTypeAction.ErstellerDarfAusfuehren;
        }

        private void SetupDataSource()
        {
            edtSortKey.DataSource = qryVorlagenTexte;
            edtText.DataSource = qryVorlagenTexte;
            edtCode.DataSource = qryVorlagenTexte;
            edtBeschreibung.DataSource = qryVorlagenTexte;
            edtBetreff.DataSource = qryVorlagenTexte;
            edtCode.DataSource = qryVorlagenTexte;
            grdVorlagenTexte.DataSource = qryVorlagenTexte;

            grdAktionen.DataSource = qryAktionen;
            edtAktionenBenachrichtigung.DataSource = qryAktionen;
            edtAktionenBetreff.DataSource = qryAktionen;
            edtAktionenBezeichnung.DataSource = qryAktionen;
            edtAktionenTypCode.DataSource = qryAktionen;
            edtAktionenText.DataSource = qryAktionen;
            edtAktionenErstellerDarfAusfuehren.DataSource = qryAktionen;
        }

        private void SetupFieldNames()
        {
            colTyp.FieldName = DBO.XLOVCode.Text;
            colBetreff.FieldName = DBO.XLOVCode.Value1;
            colBeschreibung.FieldName = DBO.XLOVCode.Value2;
            colCode.FieldName = DBO.XLOVCode.Code;
            colSortKey.FieldName = DBO.XLOVCode.SortKey;

            colAktionenID.FieldName = DBO.XTaskTypeAction.XTaskTypeActionID;
            colAktionenTyp.FieldName = DBO.XTaskTypeAction.XTaskTypeActionTypeCode;
            colAktionenBenachrichtigung.FieldName = DBO.XTaskTypeAction.BenachrichtigungAktiv;
            colAktionenBetreff.FieldName = COL_AKTIONEN_BETREFF_ML;
            colAktionenBezeichnung.FieldName = COL_AKTIONEN_BEZEICHNUNG_ML;
            colAktionenText.FieldName = COL_AKTIONEN_TEXT_ML;
        }

        private void tabVorlagentexte_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            if (page == tpgVorlagentexte)
            {
                ActiveSQLQuery = qryVorlagenTexte;
            }
            else
            {
                ActiveSQLQuery = qryAktionen;
            }
        }
    }
}