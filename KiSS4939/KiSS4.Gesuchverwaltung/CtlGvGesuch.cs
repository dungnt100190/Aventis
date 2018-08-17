using System;
using System.Data;
using System.Windows.Forms;
using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.BL;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gesuchverwaltung.ExcelImport;
using KiSS4.Gesuchverwaltung.ExcelImport.DTO;
using KiSS4.Gui;

namespace KiSS4.Gesuchverwaltung
{
    public partial class CtlGvGesuch : GvBaseControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CLASSNAME = "CtlGvGesuch";
        private const string CONTEXT_DOC = "GV_Gesuch";
        private const string QRY_BEMERKUNG_FONDS_INTERN = "Bemerkung_FondsIntern";
        private const string QRY_DOCUMENT_ID_FONDS_INTERN = "DocumentID_FondsIntern";

        #endregion

        #region Private Fields

        private int? _baPersonId;
        private GvGesuchDTO _dtoToSave;
        private SqlQuery _qryGvFonds;
        private int? _sourceGesuchId;

        #endregion

        #endregion

        #region Constructors

        public CtlGvGesuch(SqlQuery qryGvGesuch, bool hasKompetenzstufe0, bool hasKompetenzstufe1, bool hasKompetenzstufe2, int? baPersonId)
            : base(qryGvGesuch, hasKompetenzstufe0, hasKompetenzstufe1, hasKompetenzstufe2)
        {
            InitializeComponent();

            _baPersonId = baPersonId;
            _qryGvGesuch.AfterInsert += qryGvGesuch_AfterInsert;
            _qryGvGesuch.BeforePost += qryGvGesuch_BeforePost;
            _qryGvGesuch.AfterPost += qryGvGesuch_AfterPost;
            _qryGvGesuch.BeforeDelete += qryGvGesuch_BeforeDelete;
            _qryGvGesuch.BeforeDeleteQuestion += qryGvGesuch_BeforeDeleteQuestion;
            _qryGvGesuch.AfterDelete += qryGvGesuch_AfterDelete;
            _qryGvGesuch.PositionChanged += qryGvGesuch_PositionChanged;
            edtGesuchsgrund.Properties.MaxLength = DBODef.GvGesuch.Gesuchsgrund.Length;
        }

        #endregion

        #region Properties

        public bool DoImport
        {
            get { return _dtoToSave != null; }
        }

        /// <summary>
        /// Das ausgewählte Gesuch wurde kopiert
        /// </summary>
        public bool IsModeGesuchDuplizieren
        {
            get { return _sourceGesuchId.HasValue; }
        }

        private bool AllowEdit
        {
            get
            {
                return _gvStatusCode == 0 ||
                       _gvStatusCode == LOVsGenerated.GvStatus.InErfassung ||
                       (_gvStatusCode == LOVsGenerated.GvStatus.InBearbeitung && HasKompetenzstufe0);
            }
        }

        #endregion

        #region EventHandlers

        private void btnDatenimport_Click(object sender, EventArgs e)
        {
            // Save before opening the dialog
            if (!OnSaveData())
            {
                return;
            }

            if (ofdExcelImport.ShowDialog() == DialogResult.OK)
            {
                using (var dlg = new DlgGvExcelImport(ofdExcelImport.FileName))
                {
                    // if the result is OK, add a new row and set the import flag
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        if (OnAddData())
                        {
                            _dtoToSave = dlg.GvGesuchDTO;
                            _qryGvGesuch[DBO.GvGesuch.Gesuchsgrund] = _dtoToSave.Gesuchsgrund;
                            _qryGvGesuch[DBO.GvGesuch.Begruendung] = _dtoToSave.Begruendung;
                            _qryGvGesuch[DBO.GvGesuch.BaPersonID] = _dtoToSave.BaPersonIdKlient;
                            _qryGvGesuch[CtlGvGesuchverwaltung.QRY_GVGESUCH_KLIENT] = string.Format("{0}, {1}", _dtoToSave.BaPersonDtoKlient.Name, _dtoToSave.BaPersonDtoKlient.Vorname);
                            //Importierte Gesuche sind immer extern!
                            _qryGvGesuch[DBO.GvGesuch.Extern] = 1;

                            // Try to get FLB fonds of the current user's KGS
                            var qryFonds = DBUtil.OpenSQL(@"
                                SELECT
                                  FND.GvFondsID
                                FROM dbo.GvFonds                  FND WITH(READUNCOMMITTED)
                                  INNER JOIN dbo.GvFonds_XOrgUnit FOU ON FOU.GvFondsID = FND.GvFondsID
                                  INNER JOIN dbo.XOrgUnit         ORG ON ORG.OrgUnitID = FOU.OrgUnitID
                                WHERE FND.GvFondsTypCode = 1 -- Intern
                                  AND FND.KbZahlungskontoID IS NOT NULL -- FLB
                                  AND ORG.Mandantennummer = dbo.fnOrgUnitOfUserMandantenNr({0})
                                ORDER BY FND.NameKurz;",
                                Session.User.UserID);

                            if (!qryFonds.IsEmpty)
                            {
                                edtFonds.EditValue = qryFonds[DBO.GvFonds.GvFondsID];
                            }
                        }
                    }
                    else
                    {
                        _dtoToSave = null;
                    }
                }
            }
        }

        private void btnGesuchAbschliessen_Click(object sender, EventArgs e)
        {
            StatusWechsel(LOVsGenerated.GvStatus.Abgeschlossen, LOVsGenerated.GvBewilligung.BearbeitungAbschliessen);
            _qryGvGesuch[DBO.GvGesuch.AbschlussDatum] = DateTime.Today;
            _qryGvGesuch.Post();
            btnGesuchAbschliessen.Enabled = false;
        }

        private void btnGesuchDuplizieren_Click(object sender, EventArgs e)
        {
            if (!_qryGvGesuch.Post())
            {
                return;
            }

            // Source Gesuch Id setzen, um die Daten kopieren zu können
            _sourceGesuchId = _qryGvGesuch[DBO.GvGesuch.GvGesuchID] as int?;
            var baPersonId = _qryGvGesuch[DBO.GvGesuch.BaPersonID];
            var begruendung = _qryGvGesuch[DBO.GvGesuch.Begruendung];
            var bemerkung = _qryGvGesuch[DBO.GvGesuch.Bemerkung];
            var gesuchgrund = _qryGvGesuch[DBO.GvGesuch.Gesuchsgrund];

            if (OnAddData())
            {
                _qryGvGesuch[DBO.GvGesuch.BaPersonID] = baPersonId;
                _qryGvGesuch[DBO.GvGesuch.Begruendung] = begruendung;
                _qryGvGesuch[DBO.GvGesuch.Bemerkung] = bemerkung;
                _qryGvGesuch[DBO.GvGesuch.Gesuchsgrund] = gesuchgrund;
            }
        }

        private void CtlGvGesuch_Load(object sender, EventArgs e)
        {
            SetUpFonds();
            ActiveSQLQuery = _qryGvGesuch;
            SetupDataSource();
            SetupDataMembers();
            SetupContext();
            SetEditMode();
        }

        private void edtDatum_EditValueChanged(object sender, EventArgs e)
        {
            ApplyFilterOnFonds(edtDatum.UserModified);

            if (edtDatum.UserModified && !DBUtil.IsEmpty(edtFonds.EditValue) && !_qryGvFonds.Find(string.Format("GvFondsID={0}", edtFonds.EditValue)))
            {
                _qryGvGesuch[DBO.GvGesuch.GesuchsDatum] = edtDatum.EditValue;
                edtFonds.EditValue = DBNull.Value;
            }
        }

        private void edtFonds_EditValueChanged(object sender, EventArgs e)
        {
            SetupDataDependingOnFonds();
        }

        private void edtKlient_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            e.Cancel = !DialogKlient(e, edtKlient);
        }

        private void qryGvGesuch_AfterDelete(object sender, EventArgs e)
        {
            if (Session.Transaction != null)
            {
                Session.Commit();
            }
        }

        private void qryGvGesuch_AfterInsert(object sender, EventArgs e)
        {
            _qryGvGesuch[DBO.GvGesuch.XUserID_Autor] = Session.User.UserID;
            _qryGvGesuch[CtlGvGesuchverwaltung.QRY_GVGESUCH_AUTOR] = Session.User.LastFirstName;
            _qryGvGesuch[DBO.GvGesuch.GesuchsDatum] = DateTime.Today;
            _qryGvGesuch[DBO.GvGesuch.GvStatusCode] = LOVsGenerated.GvStatus.InErfassung;

            if (_baPersonId != null)
            {
                _qryGvGesuch[DBO.GvGesuch.BaPersonID] = _baPersonId;
                _qryGvGesuch[CtlGvGesuchverwaltung.QRY_GVGESUCH_KLIENT] = BaPersonService.GetBaPersonNameVornameByBaPersonId(_baPersonId);
            }
        }

        private void qryGvGesuch_AfterPost(object sender, EventArgs e)
        {
            if (DoImport)
            {
                try
                {
                    ImportData();
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
                finally
                {
                    _dtoToSave = null;
                    _qryGvGesuch.Refresh();
                }
            }
            else if (IsModeGesuchDuplizieren)
            {
                try
                {
                    CopyGesuch();
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
                finally
                {
                    _sourceGesuchId = null;
                }
            }
        }

        private void qryGvGesuch_BeforeDelete(object sender, EventArgs e)
        {
            try
            {
                Session.BeginTransaction();
                LoescheAbhaengigeDatenDesErfassungsmodus();
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

        private void qryGvGesuch_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            if (_gvStatusCode != LOVsGenerated.GvStatus.InErfassung)
            {
                KissMsg.ShowInfo(
                    CLASSNAME,
                    "GesuchNichtLoeschbarStatus",
                    "Das Gesuch kann nicht gelöscht werden.\r\nEs können nur Gesuche im Status 'Erfassung' gelöscht werden.");
                throw new KissCancelException();
            }

            var hatAbhaengigeDaten = !DBUtil.IsEmpty(
                DBUtil.ExecuteScalarSQL(@"
                    SELECT TOP 1 1
                    FROM dbo.GvDocument
                    WHERE GvGesuchID = {0};",
                _qryGvGesuch[DBO.GvGesuch.GvGesuchID]));

            if (hatAbhaengigeDaten)
            {
                KissMsg.ShowInfo(
                    CLASSNAME,
                    "GesuchNichtLoeschbarDaten",
                    "Das Gesuch kann nicht gelöscht werden.\r\nLöschen Sie alle abhängigen Daten des Gesuchs und versuchen Sie es erneut.");
                throw new KissCancelException();
            }
        }

        private void qryGvGesuch_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtKlient, lblKlient.Text);
            DBUtil.CheckNotNullField(edtFonds, lblFonds.Text);
            DBUtil.CheckNotNullField(edtDatum, lblDatum.Text);
            DBUtil.CheckNotNullField(edtGesuchsgrund, lblGesuchsgrund.Text);

            if (DoImport)
            {
                Session.BeginTransaction();

                // Wenn die BaPersonID des Klienten 0 ist, muss ein neuer Fall eingefügt werden.
                if (_dtoToSave.BaPersonIdKlient == 0)
                {
                    var writer = new GvImportWriter(_dtoToSave);
                    writer.CreateFall(_dtoToSave.BaPersonDtoKlient);
                }

                _qryGvGesuch[DBO.GvGesuch.BaPersonID] = _dtoToSave.BaPersonIdKlient;
            }
            else if (IsModeGesuchDuplizieren)
            {
                Session.BeginTransaction();
            }
            else
            {
                //Kopiere Werte aus virtuellen Spalten für interne Fonds in physisch existierende Spalten
                if (_qryGvGesuch.ColumnModified(QRY_DOCUMENT_ID_FONDS_INTERN))
                {
                    _qryGvGesuch[DBO.GvGesuch.DocumentID] = _qryGvGesuch[QRY_DOCUMENT_ID_FONDS_INTERN];
                }

                if (_qryGvGesuch.ColumnModified(QRY_BEMERKUNG_FONDS_INTERN))
                {
                    _qryGvGesuch[DBO.GvGesuch.Bemerkung] = _qryGvGesuch[QRY_BEMERKUNG_FONDS_INTERN];
                }
            }
        }

        private void qryGvGesuch_PositionChanged(object sender, EventArgs e)
        {
            _dtoToSave = null;
        }

        #endregion

        #region Methods

        #region Internal Methods

        internal void SetEditMode()
        {
            // Felder je nach Status aktivieren
            // Hat es nach der Suche keinen Treffer, dann sind auch alle Felder Readonly.
            if (_qryGvGesuch.Count > 0)
            {
                //_baPersonId -> Dieses Modul kann vom Tree geöffnent sein, im Rahmen der Editierung eines Kundes, oder in einem spearaten Fenester vom Menu mit Kunde wählbar
                edtKlient.EditMode = (!_baPersonId.HasValue && (AllowEdit || AllowSpecialEdit)) ? EditModeType.Required : EditModeType.ReadOnly;
                edtDatum.EditMode = AllowEdit ? EditModeType.Required : EditModeType.ReadOnly;
                edtFonds.EditMode = AllowEdit || AllowSpecialEdit ? EditModeType.Required : EditModeType.ReadOnly;
                edtDokument.EditMode = ((AllowEdit || AllowSpecialEdit) && !IsExternerFonds) ? EditModeType.Normal : EditModeType.ReadOnly;
                edtGesuchsgrund.EditMode = AllowEdit || AllowSpecialEdit ? EditModeType.Required : EditModeType.ReadOnly;
                chkExtern.EditMode = AllowEdit ? EditModeType.Normal : EditModeType.ReadOnly;
                edtBemerkung.EditMode = (_gvStatusCode == LOVsGenerated.GvStatus.InErfassung ||
                                         _gvStatusCode == LOVsGenerated.GvStatus.InBearbeitung ||
                                         _gvStatusCode == LOVsGenerated.GvStatus.InPruefung ||
                                         _gvStatusCode == LOVsGenerated.GvStatus.InPruefungCh ||
                                         _gvStatusCode == LOVsGenerated.GvStatus.Beurteilt ||
                                         _gvStatusCode == LOVsGenerated.GvStatus.Abgeschlossen)
                    ? EditModeType.Normal : EditModeType.ReadOnly;
            }
            else
            {
                edtKlient.EditMode = EditModeType.ReadOnly;
                edtDatum.EditMode = EditModeType.ReadOnly;
                edtFonds.EditMode = EditModeType.ReadOnly;
                edtDokument.EditMode = EditModeType.ReadOnly;
                edtGesuchsgrund.EditMode = EditModeType.ReadOnly;
                chkExtern.EditMode = EditModeType.ReadOnly;
                edtBemerkung.EditMode = EditModeType.ReadOnly;
            }

            btnDatenimport.Enabled = DBUtil.UserHasRight("CtlGvGesuchverwaltung_Datenimport");
            btnGesuchDuplizieren.Enabled = !_qryGvGesuch.IsEmpty; // TODO Maskenrecht zum Erstellen prüfen?
        }

        #endregion

        #region Protected Methods

        protected override void LoadData(bool refresh)
        {
            if (refresh)
            {
                SetEditMode();
            }

            DisableOrEnableGesuchAbschliessenButton();

            SetUpFonds();
        }

        #endregion

        #region Private Static Methods

        private static void CopyRelatedData(string tableName, string pkName, int gesuchIdSource, int gesuchIdTarget)
        {
            string sql =
                string.Format(
                    @"
                    --SQLCHECK_IGNORE--
                    SELECT DISTINCT Pk = {0}, Parent = CONVERT(INT, NULL), KeyNew = CONVERT(INT, NULL)
                    INTO #{1}
                    FROM {1}
                    WHERE GvGesuchID = {2};

                    EXECUTE spXParentChildCopy '#{1}','{1}', '{0}', NULL, 'GvGesuchId, Creator, Created, Modifier, Modified', '{3}, ''{4}'', GETDATE(), ''{4}'', GETDATE()', NULL;

                    DROP TABLE #{1};",
                    pkName,
                    tableName,
                    gesuchIdSource,
                    gesuchIdTarget,
                    DBUtil.GetDBRowCreatorModifier());

            DBUtil.ExecSQL(sql);
        }

        private static void CopyXDocumentFromGvDocument(int sourceGesuchId, int targetGesuchId)
        {
            DBUtil.ExecSQL(@"
                -------------------------------------------------------------------------------
                -- init vars and table
                -------------------------------------------------------------------------------
                DECLARE @EntriesCount INT;
                DECLARE @EntriesIterator INT;
                DECLARE @DocumentID_Old INT;
                DECLARE @DocumentID_New INT;
                DECLARE @CreatorModifier VARCHAR(255);
                DECLARE @UserID INT;
                DECLARE @GesuchSourceID INT;
                DECLARE @GesuchTargetID INT;

                SET @UserID = {0};
                SET @GesuchSourceID = {1};
                SET @GesuchTargetID = {2};

                SET @CreatorModifier = dbo.fnGetDBRowCreatorModifier(@UserID);

                DECLARE @TempTable TABLE
                (
                  ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY CLUSTERED,
                  DocumentID_Old INT
                );

                -------------------------------------------------------------------------------
                -- insert entries into temp table
                -------------------------------------------------------------------------------
                INSERT INTO @TempTable (DocumentID_Old)
                  SELECT DocumentID
                  FROM dbo.GvDocument GDO WITH (READUNCOMMITTED)
                  WHERE GvGesuchID = @GesuchSourceID;

                -- prepare vars for loop
                SET @EntriesCount = @@ROWCOUNT;  -- needs to be done just after filling!
                SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table

                -------------------------------------------------------------------------------
                -- loop all entries
                -------------------------------------------------------------------------------
                WHILE (@EntriesIterator <= @EntriesCount)
                BEGIN
                  -- get current entry
                  SELECT @DocumentID_Old = TMP.DocumentID_Old
                  FROM @TempTable TMP
                  WHERE TMP.ID = @EntriesIterator;

                  -----------------------------------------------------------------------------
                  -- do something
                  -----------------------------------------------------------------------------
                  INSERT INTO dbo.XDocument (
                          UserID_Creator,
                          UserID_LastSave,
                          FileBinary,
                          DocFormatCode,
                          FileExtension,
                          DocReadOnly,
                          DocTemplateID,
                          DocTypeCode,
                          DocTemplateName
                          )
                    SELECT
                      UserID_Creator = @UserID,
                      UserID_LastSave = @UserID,
                      FileBinary,
                      DocFormatCode,
                      FileExtension,
                      DocReadOnly,
                      DocTemplateID,
                      DocTypeCode,
                      DocTemplateName
                    FROM XDocument
                    WHERE DocumentID = @DocumentID_Old;

                  SET @DocumentID_New = SCOPE_IDENTITY();

                  UPDATE dbo.GvDocument
                    SET DocumentID = @DocumentID_New
                  WHERE GvGesuchID = @GesuchTargetID
                    AND DocumentID = @DocumentID_Old;
                  -----------------------------------------------------------------------------

                  -- prepare for next entry
                  SET @EntriesIterator = @EntriesIterator + 1;
                END;",
                Session.User.UserID,
                sourceGesuchId,
                targetGesuchId);
        }

        #endregion

        #region Private Methods

        private void ApplyFilterOnFonds(bool userModified)
        {
            bool setDataViewAsDataSource = false;

            var dataView = edtFonds.Properties.DataSource as DataView;

            if (dataView == null)
            {
                var itemsSource = edtFonds.Properties.DataSource as SqlQuery;

                if (itemsSource != null)
                {
                    if (itemsSource.DataTable.DefaultView != null)
                    {
                        dataView = itemsSource.DataTable.DefaultView;
                    }
                    else
                    {
                        dataView = new DataView(itemsSource.DataTable);
                        setDataViewAsDataSource = true;
                    }
                }
            }

            if (setDataViewAsDataSource)
            {
                edtFonds.Properties.DataSource = dataView;
            }

            if (dataView != null && edtFonds.DataSource != null && edtFonds.DataMember != null && !string.IsNullOrEmpty(edtFonds.DataMember))
            {
                //DateTime myDate = edtDatum.EditValue != null ? (DateTime)edtDatum.EditValue : DateTime.Today;
                //DateTime myDate = DateTime.Today;
                //only display active elements or the Null-element or the one representing the current EditValue
                //string rowFilter = string.Format(
                //     "(DatumVon =< {0} OR DatumVon IS NULL) AND (DatumBis => {0} OR DatumBis IS NULL)",
                //     (myDate).ToString(@"\#MM\/dd\/yyyy\#")); ;
                // dataView.RowFilter = rowFilter;
                //dataView.RowFilter = string.Format("DatumVon =< {0} AND DatumBis > {0}", myDate.ToString(@"\#MM\/dd\/yyyy\#"));
                var datum = DBUtil.IsEmpty(edtDatum.EditValue) ? DateTime.Today : edtDatum.EditValue;
                dataView.RowFilter = string.Format(
                    "(DatumVon IS NULL OR DatumVon <= #{0:MM/dd/yyyy}#) AND (DatumBis IS NULL OR DatumBis >= #{0:MM/dd/yyyy}#) OR (GvFondsID = {1} AND {2} = 0)",
                    datum,
                    DBUtil.SqlLiteral(edtFonds.DataSource[edtFonds.DataMember]),
                    userModified);
                edtFonds.Properties.DropDownRows = Math.Min(dataView.Count, edtFonds.Properties.DropDownRows);
            }
        }

        /// <summary>
        /// Kopiert die verknüpften Daten (Antrag, Dokumente) eines Gesuchs mit Hilfe von spXParentChildCopy
        /// Ausserdem wird der kopierte Antrage mit Typ 2 (BeantragterBetrag) auf Typ 3 (Finanzierung) aktualisiert
        /// Wenn beim OriginalGesuch ein GesuchDokument hinterlegt ist, wird dieses auch kopiert
        /// </summary>
        private void CopyGesuch()
        {
            if (!_sourceGesuchId.HasValue)
            {
                return;
            }

            int targetGesuchId = (int)_qryGvGesuch[DBO.GvGesuch.GvGesuchID];
            // GvAntragPosition kopieren
            CopyRelatedData(DBO.GvAntragPosition.DBOName, DBO.GvAntragPosition.GvAntragPositionID, _sourceGesuchId.Value, targetGesuchId);
            // GvDokument und XDocument kopieren
            CopyRelatedData(DBO.GvDocument.DBOName, DBO.GvDocument.GvDocumentID, _sourceGesuchId.Value, targetGesuchId);
            CopyXDocumentFromGvDocument(_sourceGesuchId.Value, targetGesuchId);
            // GvAbklaerendeStelle kopieren
            CopyRelatedData(DBO.GvAbklaerendeStelle.DBOName, DBO.GvAbklaerendeStelle.GvAbklaerendeStelleID, _sourceGesuchId.Value, targetGesuchId);

            // AntragPositionTyp von BeantragterBetrag auf Finanzierung ändern
            var qryAntragPositionBeantragterBetrag = DBUtil.OpenSQL(@"
                SELECT
                  GvAntragPositionID,
                  GvAntragPositionTypCode,
                  Creator,
                  Created,
                  Modifier,
                  Modified,
                  GvAntragPositionTS
                FROM dbo.GvAntragPosition WITH (READUNCOMMITTED)
                WHERE GvGesuchID = {0}
                  AND GvAntragPositionTypCode = {1};",
                targetGesuchId,
                LOVsGenerated.GvAntragPositionTyp.BeantragterBetrag);
            qryAntragPositionBeantragterBetrag.TableName = DBO.GvAntragPosition.DBOName;
            qryAntragPositionBeantragterBetrag.CanUpdate = true;
            qryAntragPositionBeantragterBetrag[DBO.GvAntragPosition.GvAntragPositionTypCode] = LOVsGenerated.GvAntragPositionTyp.Finanzierung;
            qryAntragPositionBeantragterBetrag.Post();

            CopyGesuchDokument(targetGesuchId);
        }

        /// <summary>
        /// Kopiert das Gesuchsdokument vom Originalgesuch in Belege/Dokumente des duplizierten Gesuchs.
        /// </summary>
        /// <param name="targetGesuchId">GesuchID vom duplizierten Gesuch</param>
        private void CopyGesuchDokument(int targetGesuchId)
        {
            if (_sourceGesuchId == null)
            {
                return;
            }

            string copyGesuchDokument =
                @"
                DECLARE @DocumentID INT;
                DECLARE @Gesuchsgrund VARCHAR(40);
                DECLARE @CreatorModifier VARCHAR(255);
                DECLARE @UserID INT;
                DECLARE @GesuchSourceID INT;
                DECLARE @GesuchTargetID INT;

                SET @UserID = {0};
                SET @GesuchSourceID = {1};
                SET @GesuchTargetID = {2};

                SET @CreatorModifier = dbo.fnGetDBRowCreatorModifier(@UserID);

                SELECT TOP 1
                  @Gesuchsgrund = GES.Gesuchsgrund,
                  @DocumentID = DOC.DocumentID
                FROM dbo.XDocument        DOC WITH (READUNCOMMITTED)
                  INNER JOIN dbo.GvGesuch GES WITH (READUNCOMMITTED) ON GES.DocumentID = DOC.DocumentID
                WHERE GES.GvGesuchID = @GesuchSourceID;

                IF (@DocumentID IS NULL)
                BEGIN
                  RETURN;
                END;

                INSERT INTO dbo.XDocument (
                        UserID_Creator,
                        UserID_LastSave,
                        FileBinary,
                        DocFormatCode,
                        FileExtension,
                        DocReadOnly,
                        DocTemplateID,
                        DocTypeCode,
                        DocTemplateName
                        )
                  SELECT
                    UserID_Creator = @UserID,
                    UserID_LastSave = @UserID,
                    FileBinary,
                    DocFormatCode,
                    FileExtension,
                    DocReadOnly,
                    DocTemplateID,
                    DocTypeCode,
                    DocTemplateName
                  FROM XDocument
                  WHERE DocumentID = @DocumentID;

                SET @DocumentID = SCOPE_IDENTITY();

                INSERT INTO GvDocument (
                        GvGesuchID,
                        UserID,
                        DocumentID,
                        Stichworte,
                        Datum,
                        Creator,
                        Created,
                        Modifier,
                        Modified)
                VALUES (
                        @GesuchTargetID, -- [GvGesuchID]
                        @UserID, -- [UserID]
                        @DocumentID, -- [DocumentID]
                        @Gesuchsgrund, --[Stichworte]
                        GETDATE(), -- [Datum]
                        @CreatorModifier, --[Creator]
                        GETDATE(), -- [Created]
                        @CreatorModifier, --[Modifier]
                        GETDATE() -- [Modified]
                       );";
            DBUtil.ExecSQLThrowingException(
                copyGesuchDokument,
                Session.User.UserID,
                _sourceGesuchId.Value,
                targetGesuchId
               );
        }

        private bool DialogKlient(UserModifiedFldEventArgs e, KissButtonEdit edt)
        {
            try
            {
                // check if data can be altered
                if (edt.EditMode == EditModeType.ReadOnly)
                {
                    // do nothing
                    return true;
                }

                // validate edt
                if (edt != edtKlient)
                {
                    // do nothing
                    return false;
                }

                // prepare search string
                string searchString = "";

                // check if we have a value to parse
                if (!DBUtil.IsEmpty(edt.EditValue))
                {
                    // prepare for database search
                    searchString = edt.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%").Replace("'", "''");
                }

                // validate search string
                if (DBUtil.IsEmpty(searchString))
                {
                    if (e.ButtonClicked)
                    {
                        // if no data entered and the button is clicked, show dialog with all data
                        searchString = "%";
                    }
                    else
                    {
                        // user
                        edt.EditValue = null;
                        edt.LookupID = null;

                        // done
                        return true;
                    }
                }

                // search user (only within KGS and those who are not yet in use within this Einsatzvereinbarung)
                var dlg = new KissLookupDialog();
                dlg.FillTimeout = 90;

                e.Cancel =
                    !dlg.SearchData(
                        String.Format(
                            @"
                            SELECT PRS.*
                            FROM dbo.fnDlgPersonSuchenKGS({0}, 1, N'{1}') PRS
                            WHERE PRS.Name LIKE N'{1}%';",
                            Session.User.UserID,
                            searchString),
                        searchString,
                        e.ButtonClicked,
                        null,
                        null,
                        null);

                if (!e.Cancel)
                {
                    // user
                    _qryGvGesuch[DBO.GvGesuch.BaPersonID] = dlg["BaPersonID$"];
                    _qryGvGesuch[CtlGvGesuchverwaltung.QRY_GVGESUCH_KLIENT] = dlg["Name"];
                    edt.LookupID = dlg["BaPersonID$"];
                    edt.EditValue = dlg["Name"];

                    // success
                    return true;
                }

                // canceled or error
                return false;
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(CLASSNAME, "ErrorIKissUserModified", "Fehler bei der Verarbeitung.", ex);
                return false;
            }
        }

        private void DisableOrEnableGesuchAbschliessenButton()
        {
            if (!DBUtil.IsEmpty(_qryGvGesuch[DBO.GvGesuch.GvGesuchID]))
            {
                var canBeClosed =
                    DBUtil.ExecuteScalarSQLThrowingException(
                        @"SELECT dbo.fnGvGesuchAbschliessbar({0}, {1})",
                        _qryGvGesuch[DBO.GvGesuch.GvGesuchID], _qryGvGesuch[DBO.GvGesuch.GvStatusCode]) as bool? ?? false;

                btnGesuchAbschliessen.Enabled = canBeClosed;
            }
        }

        private void ImportData()
        {
            if (_dtoToSave == null)
            {
                return;
            }

            _dtoToSave.GvGesuchId = Utils.ConvertToInt(_qryGvGesuch[DBO.GvGesuch.GvGesuchID]);

            var writer = new GvImportWriter(_dtoToSave);
            writer.WriteToDatabase();
        }

        private void LoescheAbhaengigeDatenDesErfassungsmodus()
        {
            DBUtil.ExecSQL(@"
                DELETE
                FROM GvBewilligung
                WHERE GvGesuchID = {0}

                DELETE
                FROM dbo.GvAntragPosition
                WHERE GvGesuchID = {0} AND GvAntragPositionTypCode = {1}

                DELETE
                FROM dbo.GvAbklaerendeStelle
                WHERE GvGesuchID = {0}

                DELETE
                FROM dbo.XDocument
                WHERE DocumentID IN (SELECT DocumentID
                                     FROM dbo.GvGesuch
                                     WHERE GvGesuchID = {0})",
                _qryGvGesuch[DBO.GvGesuch.GvGesuchID],
                LOVsGenerated.GvAntragPositionTyp.BeantragterBetrag);
        }

        private void SetupContext()
        {
            edtDokument.Context = CONTEXT_DOC;
        }

        private void SetupDataDependingOnFonds()
        {
            if (_qryGvGesuch[DBO.GvGesuch.GvFondsID] as int? != edtFonds.EditValue as int? && !_qryGvGesuch.IsDeleting)
            {
                // Wert nur setzen wenn es geändert hat.
                _qryGvGesuch[DBO.GvGesuch.GvFondsID] = edtFonds.EditValue;

                string searchExpression = string.Format("{0} = {1}", DBO.GvFonds.GvFondsID, DBUtil.SqlLiteral(_qryGvGesuch[DBO.GvGesuch.GvFondsID]));
                DataRow[] rows = _qryGvFonds.DataTable.Select(searchExpression, _qryGvFonds.DataTable.DefaultView.Sort);

                if (rows.Length == 0) // nichts gefunden
                {
                    _qryGvGesuch[DBO.GvFonds.GvFondsTypCode] = DBNull.Value;
                    _qryGvGesuch[DBO.GvFonds.KbZahlungskontoID] = DBNull.Value;
                    _qryGvGesuch[CtlGvGesuchverwaltung.QRY_GVGESUCH_FONDS_HINWEIS] = "";
                    _qryGvGesuch[CtlGvGesuchverwaltung.QRY_GVGESUCH_IST_FONDS_EXTERN] = DBNull.Value; ;
                    _qryGvGesuch[CtlGvGesuchverwaltung.QRY_GVGESUCH_IST_FONDS_FLB] = DBNull.Value;
                }
                else
                {
                    _qryGvGesuch[DBO.GvFonds.GvFondsTypCode] = rows[0][DBO.GvFonds.GvFondsTypCode];
                    _qryGvGesuch[DBO.GvFonds.KbZahlungskontoID] = rows[0][DBO.GvFonds.KbZahlungskontoID];
                    _qryGvGesuch[CtlGvGesuchverwaltung.QRY_GVGESUCH_FONDS_HINWEIS] = DBUtil.IsEmpty(rows[0][DBO.GvFonds.Bemerkung]) ? "" : rows[0][DBO.GvFonds.Bemerkung].ToString();
                    _qryGvGesuch[CtlGvGesuchverwaltung.QRY_GVGESUCH_IST_FONDS_EXTERN] = Utils.ConvertToBool(rows[0][CtlGvGesuchverwaltung.QRY_GVGESUCH_IST_FONDS_EXTERN]);
                    _qryGvGesuch[CtlGvGesuchverwaltung.QRY_GVGESUCH_IST_FONDS_FLB] = Utils.ConvertToBool(rows[0][CtlGvGesuchverwaltung.QRY_GVGESUCH_IST_FONDS_FLB]);
                }

                if (!_qryGvGesuch.CanUpdate)
                {
                    // Wenn CanUpdate false ist und die Position gewechselt wird, darf nicht gespeichert werden
                    _qryGvGesuch.DataSet.AcceptChanges();
                    _qryGvGesuch.RowModified = false;
                }
            }

            SetEditMode();
        }

        private void SetupDataMembers()
        {
            edtKlient.DataMember = CtlGvGesuchverwaltung.QRY_GVGESUCH_KLIENT;
            edtDatum.DataMember = DBO.GvGesuch.GesuchsDatum;
            edtFonds.DataMember = DBO.GvGesuch.GvFondsID;
            edtDokument.DataMember = QRY_DOCUMENT_ID_FONDS_INTERN;
            edtBemerkung.DataMember = QRY_BEMERKUNG_FONDS_INTERN;
            edtGesuchTotal.DataMember = CtlGvGesuchverwaltung.QRY_GVGESUCH_TOTAL_FONDS_BEWILLIGT;
            edtAusbezahltFLBTotal.DataMember = CtlGvGesuchverwaltung.QRY_GVGESUCH_TOTAL_FONDS_AUSBEZAHLT;
            lblFondsHinweis.DataMember = CtlGvGesuchverwaltung.QRY_GVGESUCH_FONDS_HINWEIS;
            edtGesuchsgrund.DataMember = DBO.GvGesuch.Gesuchsgrund;
            chkExtern.DataMember = DBO.GvGesuch.Extern;
        }

        private void SetupDataSource()
        {
            edtKlient.DataSource = _qryGvGesuch;
            edtDatum.DataSource = _qryGvGesuch;
            edtFonds.DataSource = _qryGvGesuch;
            edtDokument.DataSource = _qryGvGesuch;
            edtBemerkung.DataSource = _qryGvGesuch;
            edtGesuchTotal.DataSource = _qryGvGesuch;
            edtAusbezahltFLBTotal.DataSource = _qryGvGesuch;
            lblFondsHinweis.DataSource = _qryGvGesuch;
            edtGesuchsgrund.DataSource = _qryGvGesuch;
            chkExtern.DataSource = _qryGvGesuch;
        }

        private void SetUpFonds()
        {
            int? gvGesuchId = null;
            if (_qryGvGesuch != null)
            {
                gvGesuchId = _qryGvGesuch[DBO.GvGesuch.GvGesuchID] as int?;
            }

            _qryGvFonds =
                DBUtil.OpenSQL(
                    @"
                    -- UserId
                    DECLARE @UserId INT;
                    SET @UserId = {0};

                    ;WITH GvFondsCte
                    AS
                    (
                        SELECT FND.GvFondsID
                        FROM dbo.GvFonds                   FND    WITH (READUNCOMMITTED)
                          INNER JOIN dbo.GvFonds_XOrgUnit  FOU    WITH (READUNCOMMITTED) ON FOU.GvFondsID = FND.GvFondsID
                          -- Kantonale Geschäftsstellen
                          LEFT JOIN dbo.XOrgUnit           ORG_KG WITH (READUNCOMMITTED) ON ORG_KG.OrgUnitID = FOU.OrgUnitID
                          -- Fonds Schweiz (Hauptsitz)
                          LEFT JOIN dbo.XOrgUnit           ORG_CH WITH (READUNCOMMITTED) ON ORG_CH.OrgUnitID = FOU.OrgUnitId
                                                                                        AND ORG_CH.OEItemTypCode = 1
                        WHERE ORG_KG.Mandantennummer = dbo.fnOrgUnitOfUserMandantenNr(@UserId)
                           OR ORG_CH.OrgUnitID IS NOT NULL

                        UNION ALL

                        -- aktueller Fond vom Gesuch (z.B. wenn Fall einer neuen KGS zugeteilt worden ist)
                        SELECT GvFondsID
                        FROM GvGesuch
                        WHERE GvGesuchID = {2}
                    )

                    SELECT DISTINCT
                      FND.GvFondsID,
                      FND.NameKurz,
                      Bemerkung = dbo.fnGetMLTextByDefault(BemerkungTID, {1}, FND.Bemerkung),
                      FND.GvFondsTypCode,
                      FND.KbZahlungskontoID,
                      FND.DatumVon,
                      FND.DatumBis,
                      IstFondsExtern = CASE FND.GvFondsTypCode WHEN 2 THEN CONVERT(BIT, 1) ELSE CONVERT(BIT, 0) END,
                      IstFondsFLB = CASE WHEN FND.GvFondsTypCode = 1 AND FND.KbZahlungskontoID IS NOT NULL THEN CONVERT(BIT, 1) ELSE CONVERT(BIT, 0) END
                    FROM GvFondsCte CTE
                      INNER JOIN dbo.GvFonds FND    WITH (READUNCOMMITTED) ON FND.GvFondsID = CTE.GvFondsID
                    ORDER BY FND.GvFondsTypCode, FND.NameKurz;",
                    Session.User.UserID,
                    Session.User.LanguageCode,
                    gvGesuchId);
            edtFonds.LoadQuery(_qryGvFonds, DBO.GvFonds.GvFondsID, DBO.GvFonds.NameKurz);
            ApplyFilterOnFonds(false);
            SetupDataDependingOnFonds();
        }

        #endregion

        #endregion
    }
}