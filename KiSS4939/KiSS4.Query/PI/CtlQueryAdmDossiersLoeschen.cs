using System;
using System.Data;
using System.Windows.Forms;

using KiSS4.Common;
using KiSS4.Common.PI;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Messages;

using Kiss.Interfaces.UI;

namespace KiSS4.Query.PI
{
    public partial class CtlQueryAdmDossiersLoeschen : KiSS4.Common.KissQueryControl
    {
        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Fields

        private bool _isChiefOrRepresentative;
        private bool _specialRightKostenstelleHS;
        private bool _specialRightKostenstelleKGS;
        private Int32 _userOrgUnitID = -1; // store the user's orgunitid

        #endregion

        #endregion

        #region Constructors

        public CtlQueryAdmDossiersLoeschen()
        {
            this.InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void CtlQueryBaDossiersLoeschen_Load(object sender, System.EventArgs e)
        {
            // logging
            logger.Debug("enter");

            // DEFAULT VALUES:
            // get users member orgunit
            this._userOrgUnitID = QryUtils.GetOrgUnitOfUser(Session.User.UserID);

            edtSucheJahr.Value = DateTime.Today.Year;

            // RIGHTS:
            _specialRightKostenstelleHS = DBUtil.UserHasRight("QRYDossiersLoeschenKostenstelleHS");
            _specialRightKostenstelleKGS = DBUtil.UserHasRight("QRYDossiersLoeschenKostenstelleKGS");
            _isChiefOrRepresentative = QryUtils.IsChiefOrRepresentative(Session.User.UserID, -1);

            // SEARCH:
            // fill dropdowns data, depending on rights
            BDEUtils.InitKostenstelleDropDown(Session.User.UserID, _specialRightKostenstelleHS, _specialRightKostenstelleKGS, edtSucheKostenstelle);
            BDEUtils.InitMitarbeiterDropDown(Session.User.UserID, _specialRightKostenstelleHS, _specialRightKostenstelleKGS, _isChiefOrRepresentative, edtSucheMitarbeiter);

            // FILLTIMEOUT:
            // setup FillTimeOut for qryQuery
            if (_specialRightKostenstelleHS)
            {
                // hauptsitz, huge amount of data expected
                qryQuery.FillTimeOut = 1200; // 20min
                
                //Suche nach 'verwaister' Personen nur für Hauptsitz sichtbar
                cbVerwaistePersonen.Visible = true;
            }
            else if (_specialRightKostenstelleKGS)
            {
                // KGS, lower amount of data, still big amount
                qryQuery.FillTimeOut = 600; // 10min
            }
            else if (_isChiefOrRepresentative)
            {
                // Chief only, lower amount
                qryQuery.FillTimeOut = 360;
            }

            // INIT
            // start with new search
            this.NewSearch();

            //make sure, the gridview is editable (is set to false in super-class)
            grvQuery1.OptionsBehavior.Editable = true;
            qryQuery.CanUpdate = true;

            // logging
            logger.Debug("done");
        }

        private void DeleteSelectedPersons_End()
        {
            qryQuery.Refresh();
        }

        private void DeleteSelectedPersons_Start()
        {
            try
            {
                //prepare task
                Cursor = Cursors.WaitCursor;

                //sql-statement zum Löschen einer Person ermitteln
                var deleteStatements = GetDeleteStatement();

                DlgProgressLog.AddLine(KissMsg.GetMLMessage(this.Name, "LoeschvorgangGestartet", "Löschvorgang gestartet"));
                DlgProgressLog.ShowTopMost();

                //perform task
                foreach (DataRow row in qryQuery.DataTable.Rows)
                {
                    if (DlgProgressLog.CancellledByUser)
                    {
                        return;
                    }

                    bool isSelected = Utils.ConvertToBool(row["Selektiert"]);
                    int baPersonID = Utils.ConvertToInt(row["BaPersonID$"]);

                    if (isSelected)
                    {
                        //delete Person
                        PersonLoeschen(deleteStatements, baPersonID);
                    }
                }
            }
            finally
            {
                Cursor = Cursors.Default;

                DlgProgressLog.AddLine(KissMsg.GetMLMessage(this.Name, "LoeschvorgangAbgeschlossen", "Löschvorgang abgeschlossen"));
                DlgProgressLog.EndProgress();
                DlgProgressLog.ShowTopMost();
            }
        }

        private void btnDossiersLoeschen_Click(object sender, EventArgs e)
        {
            //Ask for confirmation
            if (!KissMsg.ShowQuestion(
                this.Name,
                "FrageDatenLöschen",
                "Wollen Sie die Personen mit ihren Daten wirklich unwiderruflich löschen?")
                )
            {
                DlgProgressLog.AddLine(KissMsg.GetMLMessage(this.Name, "LoeschvorgangAbgebrochen", "Löschvorgang abgebrochen"));
                DlgProgressLog.EndProgress();
                DlgProgressLog.ShowTopMost();
                return;
            }

            // Alle selektierten Personen löschen
            DlgProgressLog.Show
            (
                KissMsg.GetMLMessage(this.Name, "FortschrittDossiersLoeschen", "Fortschritt: Dossiers löschen"),
                700, 300,
                DeleteSelectedPersons_Start,
                DeleteSelectedPersons_End,
                Session.MainForm
            );
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            SetFlagOnAllRows(true);
        }

        private void btnSelectNone_Click(object sender, EventArgs e)
        {
            SetFlagOnAllRows(false);
        }

        private void cbVerwaistePersonen_CheckedChanged(object sender, EventArgs e)
        {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryAdmDossiersLoeschen));

            if (cbVerwaistePersonen.Checked)
            {
                edtSucheKostenstelle.ItemIndex = 0;
                edtSucheKostenstelle.EditMode = EditModeType.ReadOnly;

                edtSucheJahr.Text = String.Empty;
                edtSucheJahr.EditMode = EditModeType.ReadOnly;

                edtSucheMitarbeiter.ItemIndex = 0;
                edtSucheMitarbeiter.EditMode = EditModeType.ReadOnly;

                kissSearch.SelectStatement = resources.GetString("qryQueryOrphans.SelectStatement");
            }
            else
            {
                edtSucheKostenstelle.EditMode = EditModeType.Normal;
                edtSucheJahr.EditMode = EditModeType.Normal;
                edtSucheMitarbeiter.EditMode = EditModeType.Normal;

                QryUtils.NewSearchMitarbeiter(_specialRightKostenstelleHS, _specialRightKostenstelleKGS, _isChiefOrRepresentative, edtSucheMitarbeiter);

                edtSucheJahr.Value = DateTime.Today.Year;
                edtSucheKostenstelle.EditValue = _userOrgUnitID;

                kissSearch.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            }
        }

        private void qryQuery_BeforePost(object sender, EventArgs e)
        {
            //Der Benutzer kann keine Änderungen an den Daten vornehmen (ausser Dossiers/Fallträger löschen)
            //Selektion einer Zeile im Grid wird im Query aber bereits als Daten-Mutation angesehen und wird beim
            //Fokus-Wechsel "abgespeichert".
            //-> Query als nicht-modifiziert markieren
            qryQuery.Row.RejectChanges();
            qryQuery.RowModified = false;
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            // let base do stuff
            base.NewSearch();

            // apply rights and default search parameters
            QryUtils.NewSearchMitarbeiter(_specialRightKostenstelleHS, _specialRightKostenstelleKGS, _isChiefOrRepresentative, edtSucheMitarbeiter);

            // default Kostenstelle (for all users the same way)
            edtSucheKostenstelle.EditValue = _userOrgUnitID;

            // set focus
            edtSucheKostenstelle.Focus();
        }

        protected override void RunSearch()
        {
            // replace search parameters:
            // @CurrentUserID = {0},
            // @SpecialRightKostenstelleHS = {1},
            // @SpecialRightKostenstelleKGS = {2},
            // @IsChiefOrRepresentative = {3},
            // @LanguageCode = {4};

            var parameters = new object[]
            {
                Session.User.UserID,
                _specialRightKostenstelleHS,
                _specialRightKostenstelleKGS,
                _isChiefOrRepresentative,
                Session.User.LanguageCode
            };
            kissSearch.SelectParameters = parameters;

            // let base do stuff
            base.RunSearch();
        }

        #endregion

        #region Private Methods

        private string GetDeleteStatement()
        {
            var deleteQuery = DBUtil.OpenSQL(@"
                DECLARE @PkTableName VARCHAR(128);
                DECLARE @PkTableId VARCHAR(MAX);
                DECLARE @DefaultDeleteRuleCode INT;
                SET @PkTableName = 'BaPerson';
                SET @PkTableId = '<0>';

                -- XDeleteRuleCode
                -- 0: No Action
                -- 1: Cascade
                -- 2: Set to NULL
                -- 3: Set default --> NOT IMPLEMENTED
                SET @DefaultDeleteRuleCode = 0;

                DECLARE @EntriesToDelete TABLE (
                  ID INT IDENTITY (1, 1) NOT NULL,
                  PkTableName     VARCHAR(128),
                  PkColumnName    VARCHAR(128),
                  PkTableObjectId INT,
                  PkColumnId      INT,
                  FkTableName     VARCHAR(128),
                  FkColumnName    VARCHAR(128),
                  FkTableObjectId INT,
                  FkColumnId      INT,
                  FkName          VARCHAR(128),
                  FkObjectId      INT,
                  tableLevel      INT,
                  fkPath          VARCHAR(MAX),
                  XDeleteRuleCode INT,
                  SqlSelectPkIds  VARCHAR(MAX),
                  SqlDeleteAction VARCHAR(MAX)
                );

                ;WITH FKTmp
                AS
                (
                  -- select all FK from other tables that uses BaPerson
                  SELECT
                    PkTableName     = OBJECT_NAME(FKC.referenced_object_id),
                    PkColumnName    = COLPK.name,
                    PkTableObjectId = FKC.referenced_object_id,
                    PkColumnId      = FKC.referenced_column_id,
                    FkTableName     = OBJECT_NAME(FKC.parent_object_id),
                    FkColumnName    = COLFK.name,
                    FkTableObjectId = FKC.parent_object_id,
                    FkColumnId      = FKC.parent_column_id,
                    FkName          = OBJECT_NAME(FKC.constraint_object_id),
                    FkObjectId      = FKC.constraint_object_id,
                    tableLevel      = 1,
                    fkPath          = CONVERT(VARCHAR(MAX), OBJECT_NAME(FKC.referenced_object_id)) + '.' + COLPK.name + '/' + OBJECT_NAME(FKC.parent_object_id) + '.' + COLFK.name,
                    XDeleteRuleCode = ISNULL(DAC.XDeleteRuleCode, @DefaultDeleteRuleCode),
                    SqlSelectPkIds  = CONVERT(NVARCHAR(MAX), @PkTableId)
                  FROM sys.foreign_key_columns FKC
                    INNER JOIN sys.columns     COLPK ON COLPK.object_id = FKC.referenced_object_id
                                                    AND COLPK.column_id = FKC.referenced_column_id
                    INNER JOIN sys.columns     COLFK ON COLFK.object_id = FKC.parent_object_id
                                                    AND COLFK.column_id = FKC.parent_column_id
                    LEFT  JOIN dbo.XDeleteRule DAC ON DAC.TableName = OBJECT_NAME(FKC.parent_object_id)
                                                  AND DAC.ColumnName = COLFK.name
                  WHERE OBJECT_NAME(referenced_object_id) = @PkTableName

                  UNION ALL

                  -- recursion on ohter tables
                  SELECT
                    PkTableName     = OBJECT_NAME(FKC.referenced_object_id),
                    PkColumnName    = COLPK.name,
                    PkTableObjectId = FKC.referenced_object_id,
                    PkColumnId      = FKC.referenced_column_id,
                    FkTableName     = OBJECT_NAME(FKC.parent_object_id),
                    FkColumnName    = COLFK.name,
                    FkTableObjectId = FKC.parent_object_id,
                    FkColumnId      = FKC.parent_column_id,
                    FkName          = OBJECT_NAME(FKC.constraint_object_id),
                    FkObjectId      = FKC.constraint_object_id,
                    tableLevel      = CTE.tableLevel + 1,
                    fkPath          = CTE.fkPath + '/' + OBJECT_NAME(FKC.parent_object_id) + '.' + COLFK.name,
                    XDeleteRuleCode = ISNULL((SELECT DAC.XDeleteRuleCode
                                              FROM dbo.XDeleteRule DAC
                                              WHERE DAC.TableName = OBJECT_NAME(FKC.parent_object_id)
                                                AND DAC.ColumnName = COLFK.name), @DefaultDeleteRuleCode),
                    SqlSelectPkIds  = N'SELECT ' + COLPK.name + N' FROM ' + CTE.FkTableName + N' WHERE ' + CTE.FkColumnName + N' IN (' + CTE.SqlSelectPkIds + N')'
                  FROM sys.foreign_key_columns FKC
                    INNER JOIN sys.columns     COLPK ON COLPK.object_id = FKC.referenced_object_id
                                                    AND COLPK.column_id = FKC.referenced_column_id
                    INNER JOIN sys.columns     COLFK ON COLFK.object_id = FKC.parent_object_id
                                                    AND COLFK.column_id = FKC.parent_column_id
                    INNER JOIN FKTmp           CTE   ON CTE.FkTableName = OBJECT_NAME(FKC.referenced_object_id)
                                                    AND CTE.PkTableObjectId <> FKC.referenced_object_id
                                                    AND CTE.XDeleteRuleCode = 1 -- delete
                )

                -- insert entries to delete that have FKs on the PK table
                INSERT INTO @EntriesToDelete(PkTableName, PkColumnName, PkTableObjectId, PkColumnId,
                                             FkTableName, FkColumnName, FkTableObjectId, FkColumnId, FkName, FkObjectId,
                                             tableLevel, fkPath, XDeleteRuleCode, SqlSelectPkIds)
                  SELECT
                    PkTableName,
                    PkColumnName,
                    PkTableObjectId,
                    PkColumnId,
                    FkTableName,
                    FkColumnName,
                    FkTableObjectId,
                    FkColumnId,
                    FkName,
                    FkObjectId,
                    tableLevel,
                    fkPath,
                    XDeleteRuleCode,
                    SqlSelectPkIds
                  FROM FKTmp CTE;

                -- insert PK table to delete
                INSERT INTO @EntriesToDelete(PkTableName, PkColumnName, PkTableObjectId, PkColumnId,
                                             FkTableName, FkColumnName, FkTableObjectId, FkColumnId,
                                             tableLevel, fkPath, XDeleteRuleCode, SqlSelectPkIds)
                  SELECT
                    PkTableName     = OBJECT_NAME(SKEY.parent_object_id),
                    PkColumnName    = COL.name,
                    PkTableObjectId = SKEY.parent_object_id,
                    PkColumnId      = COL.column_id,
                    FkTableName     = OBJECT_NAME(SKEY.parent_object_id),
                    FkColumnName    = COL.name,
                    FkTableObjectId = SKEY.parent_object_id,
                    FkColumnId      = COL.column_id,
                    tableLevel      = 0,
                    fkPath          = CONVERT(VARCHAR(MAX), OBJECT_NAME(SKEY.parent_object_id)) + '.' + COL.name,
                    XDeleteRuleCode = 1, -- delete
                    SqlSelectPkIds  = CONVERT(NVARCHAR(MAX), @PkTableId)
                  FROM sys.columns                 COL
                    INNER JOIN sys.key_constraints SKEY ON SKEY.type = 'PK'
                                                       AND SKEY.parent_object_id = COL.OBJECT_ID
                                                       AND OBJECT_NAME(SKEY.parent_object_id) = @PkTableName
                    INNER JOIN sys.index_columns   SIXC ON SIXC.object_id = SKEY.parent_object_id
                                                       AND SIXC.index_id = SKEY.unique_index_id
                                                       AND SIXC.column_id = COL.column_id;

                -- insert XDocument entries to delete as they don't have a FK
                INSERT INTO @EntriesToDelete(PkTableName, PkColumnName, PkTableObjectId, PkColumnId,
                                             FkTableName, FkColumnName, FkTableObjectId, FkColumnId,
                                             tableLevel, fkPath, XDeleteRuleCode, SqlSelectPkIds, SqlDeleteAction)
                  SELECT
                    PkTableName     = OBJECT_NAME(OBJ.object_id),
                    PkColumnName    = DOCPK.name,
                    PkTableObjectId = OBJ.object_id,
                    PkColumnId      = DOCPK.column_id,
                    FkTableName     = DEL.FkTableName,
                    FkColumnName    = COLFK.name,
                    FkTableObjectId = DEL.FkTableObjectId,
                    FkColumnId      = COLFK.column_id,
                    tableLevel      = (SELECT MAX(tableLevel) + 1
                                       FROM @EntriesToDelete),
                    fkPath          = DEL.fkPath + '/' + DEL.FkTableName + '.' + COLFK.name,
                    XDeleteRuleCode = ISNULL(DAC.XDeleteRuleCode, @DefaultDeleteRuleCode),
                    SqlSelectPkIds  = N'SELECT ' + COLFK.name + N' FROM ' + DEL.FkTableName + N' WHERE ' + DEL.FkColumnName + N' IN (' + DEL.SqlSelectPkIds + N')',
                    SqlDeleteAction = CASE ISNULL(DAC.XDeleteRuleCode, @DefaultDeleteRuleCode)
                                        WHEN 1
                                          THEN N'DELETE T FROM ' + OBJECT_NAME(OBJ.object_id) + ' T WHERE ' + DOCPK.name + ' IN (' +
                                               N'SELECT ' + COLFK.name + N' FROM ' + DEL.FkTableName + N' WHERE ' + DEL.FkColumnName + N' IN (' + DEL.SqlSelectPkIds + N')'
                                               + ')'

                                        WHEN 2
                                          THEN 'UPDATE T SET ' + COLFK.name + ' = NULL FROM ' + DEL.FkTableName + ' T WHERE ' + DEL.FkColumnName + ' IN (' + DEL.SqlSelectPkIds + ')'
                                        ELSE '--'
                                      END

                  FROM @EntriesToDelete            DEL
                    INNER JOIN sys.columns         COLPK ON OBJECT_NAME(COLPK.object_id) = DEL.FkTableName
                    INNER JOIN sys.key_constraints KEYPK ON KEYPK.type = 'PK'
                                                        AND KEYPK.parent_object_id = COLPK.object_id
                    INNER JOIN sys.index_columns   IXCPK ON IXCPK.object_id = KEYPK.parent_object_id
                                                        AND IXCPK.index_id = KEYPK.unique_index_id
                                                        AND IXCPK.column_id = COLPK.column_id

                    INNER JOIN sys.columns         COLFK ON OBJECT_NAME(COLFK.object_id) = DEL.FkTableName
                                                        AND (COLFK.name LIKE '%Do_umentID%' OR COLFK.name LIKE '%DocID%')

                    INNER JOIN sys.objects         OBJ   ON OBJECT_NAME(OBJ.object_id) = 'XDocument'
                    INNER JOIN sys.columns         DOCPK ON DOCPK.object_id = OBJ.object_id
                    INNER JOIN sys.key_constraints SKEY  ON SKEY.type = 'PK'
                                                        AND SKEY.parent_object_id = OBJ.object_id
                    INNER JOIN sys.index_columns   SIXC  ON SIXC.object_id = SKEY.parent_object_id
                                                        AND SIXC.index_id = SKEY.unique_index_id
                                                        AND SIXC.column_id = DOCPK.column_id
                    LEFT  JOIN dbo.XDeleteRule     DAC   ON DAC.TableName = DEL.FkTableName
                                                        AND DAC.ColumnName = COLFK.name;

                SELECT
                  SqlDeleteAction = ISNULL(
                                      SqlDeleteAction,
                                      CASE ISNULL(DEL.XDeleteRuleCode, 1)
                                        WHEN 1
                                          THEN 'DELETE T'
                                        WHEN 2
                                          THEN 'UPDATE T SET ' + DEL.FkColumnName + ' = NULL'
                                        ELSE '--'
                                      END + ' FROM ' + DEL.FkTableName + ' T WHERE ' + DEL.FkColumnName + ' IN (' + DEL.SqlSelectPkIds + ')')
                FROM @EntriesToDelete DEL
                ORDER BY tableLevel DESC, PkTableName, PkColumnName, FkTableName, FkColumnName;
                ");

            string deleteStatments = "INSERT INTO dbo.HistoryVersion(AppUser) VALUES ('kiss_sys');" + Environment.NewLine;

            do
            {
                deleteStatments += deleteQuery["SqlDeleteAction"] + Environment.NewLine;
            }
            while (deleteQuery.Next());

            return deleteStatments.Replace("<0>", "{0}");
        }

        private void PersonLoeschen(string deleteStatements, int baPersonID)
        {
            //Transaktion öffnen
            Session.BeginTransaction();
            // hier darf kein Code stehen!
            try
            {
                DBUtil.ExecSQLThrowingException(deleteStatements, baPersonID);

                DlgProgressLog.AddLine(KissMsg.GetMLMessage(this.Name, "PersonWurdeGeloescht", "Person Nr: {0} wurde gelöscht", baPersonID));

                Session.Commit();
                // hier darf kein Code stehen!
            }
            catch (Exception ex)
            {
                // catch über alle Typen von Exceptions muss immer vorhanden sein!
                // hier darf kein Code stehen!
                // Reihenfolge darf hier nicht vertauscht werden!
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
                DlgProgressLog.AddLine(KissMsg.GetMLMessage(this.Name, "PersonLoeschenFehlgeschlagen", "Löschen von Person Nr: {0} ist fehlgeschlagen. Fehler: {1}", baPersonID, ex.Message));
            }
        }

        private void SetFlagOnAllRows(bool flagStatus)
        {
            foreach (DataRow row in qryQuery.DataTable.Rows)
            {
                row["Selektiert"] = flagStatus;
            }
        }

        #endregion

        #endregion
    }
}