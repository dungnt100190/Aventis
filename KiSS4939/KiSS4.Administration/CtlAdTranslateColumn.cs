using System;
using System.Windows.Forms;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Administration
{
    /// <summary>
    /// Control, used to translate database-content in various table-columns as defined in table XTranslateColumn
    /// </summary>
    public partial class CtlAdTranslateColumn : KiSS4.Gui.KissUserControl
    {
        #region Fields

        #region Private Fields

        private bool _isRefreshingTranslation = true;
        private bool _translationHasChanged = false;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlAdTranslateColumn"/> class.
        /// </summary>
        public CtlAdTranslateColumn()
        {
            // init control
            InitializeComponent();

            // check and handle rights
            SetupRights();
        }

        #endregion

        #region EventHandlers

        private void CtlAdTranslateColumn_Load(object sender, EventArgs e)
        {
            // init custom
            InitControl();
        }

        private void edtTableName_EditValueChanged(object sender, EventArgs e)
        {
            // reapply data for column-lookup-edits
            string tableName = DBUtil.IsEmpty(edtTableName.EditValue) ? null : Convert.ToString(edtTableName.EditValue);

            // fill lookupedits
            InitColumnLookupEdits(tableName);
        }

        private void edtTranslation_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            // if user clicks the button, data may be changed
            TranslationHasChanged();
        }

        private void qryTranslation_PositionChanging(object sender, EventArgs e)
        {
            // check if need to refresh data
            if (_translationHasChanged && !_isRefreshingTranslation)
            {
                try
                {
                    _isRefreshingTranslation = true;
                    qryTranslation.Refresh();

                    SetupTranslationColumns();
                }
                finally
                {
                    // reset flags
                    _isRefreshingTranslation = false;
                    this._translationHasChanged = false;
                }
            }
        }

        private void qryXTranslateColumn_AfterInsert(object sender, EventArgs e)
        {
            // set creator
            qryXTranslateColumn.SetCreator();
        }

        private void qryXTranslateColumn_AfterPost(object sender, EventArgs e)
        {
            // load corresponding data
            LoadTranslation();
        }

        private void qryXTranslateColumn_BeforePost(object sender, EventArgs e)
        {
            // check mustfields
            DBUtil.CheckNotNullField(edtTableName, lblTableName.Text);
            DBUtil.CheckNotNullField(edtColumnName, lblColumnName.Text);
            DBUtil.CheckNotNullField(edtTIDColumnName, lblTIDColumnName.Text);

            // set modification
            qryXTranslateColumn.SetModifierModified();
        }

        private void qryXTranslateColumn_PositionChanged(object sender, EventArgs e)
        {
            // load data of translation
            LoadTranslation();

            // override defaults
            grvXTranslateColumn.OptionsView.ColumnAutoWidth = true;
        }

        private void qryXTranslateColumn_PositionChanging(object sender, EventArgs e)
        {
            // save changes before switching position
            if (!qryTranslation.Post())
            {
                // cancel
                throw new KissCancelException();
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Handle adding a new tablecolumn to translate
        /// </summary>
        /// <returns><c>True</c> if entry could be created, otherwise <c>False</c></returns>
        public override bool OnAddData()
        {
            // save pending changes first
            if (!OnSaveData())
            {
                return false;
            }

            // let base do stuff
            return base.OnAddData();
        }

        /// <summary>
        /// Refresh the shown data
        /// </summary>
        public override void OnRefreshData()
        {
            // refresh only if save was successfully
            if (!OnSaveData())
            {
                return;
            }

            // refresh all queries
            qryXTranslateColumn.Refresh();
            qryTranslation.Refresh();
        }

        /// <summary>
        /// Save all pending changes
        /// </summary>
        /// <returns><c>True</c> if saving was successfully done, otherwise <c>False</c></returns>
        public override bool OnSaveData()
        {
            // save changes first on detail and then on main query
            return qryTranslation.Post() && qryXTranslateColumn.Post();
        }

        #endregion

        #region Private Methods

        private string GetTranslationColumnValue(string colName)
        {
            // validate first
            if (qryXTranslateColumn.IsEmpty || DBUtil.IsEmpty(qryXTranslateColumn[colName]))
            {
                // no or invalid row
                return null;
            }

            // get current value
            return Convert.ToString(qryXTranslateColumn[colName]);
        }

        private void InitColumnLookupEdits(string tableName)
        {
            // fill queries for lookupedits
            SqlQuery qryColumnNames = DBUtil.OpenSQL(@"
                DECLARE @TableName VARCHAR(255);
                SET @TableName = ISNULL({0}, '');

                SELECT [Code] = COL.name,
                       [Text] = COL.name --+ ISNULL('  -  ' + OBJ.name + '', '')
                FROM sys.columns COL
                  INNER JOIN sysobjects OBJ ON OBJ.id = COL.object_id
                                           AND OBJ.xtype IN ('U')
                                           AND OBJ.name = @TableName
                ORDER BY OBJ.name, COL.column_id, COL.name;", tableName);

            // apply
            edtColumnName.LoadQuery(qryColumnNames);
            edtColumnName.Properties.DropDownRows = Math.Min(qryColumnNames.Count, 14);
            edtColumnName.Properties.PopupWidth = edtColumnName.Width + 80;

            edtTIDColumnName.LoadQuery(qryColumnNames);
            edtTIDColumnName.Properties.DropDownRows = Math.Min(qryColumnNames.Count, 14);
            edtTIDColumnName.Properties.PopupWidth = edtTIDColumnName.Width + 80;
        }

        private void InitControl()
        {
            // setup default values to flags
            _translationHasChanged = false;
            _isRefreshingTranslation = true;

            // fill main-query
            qryXTranslateColumn.Fill(@"
                --SQLCHECK_IGNORE--
                SELECT XTC.XTranslateColumnID,
                       XTC.TableName,
                       XTC.ColumnName,
                       XTC.TIDColumnName,
                       XTC.Description,
                       XTC.Creator,
                       XTC.Created,
                       XTC.Modifier,
                       XTC.Modified,
                       XTC.XTranslateColumnTS
                FROM dbo.XTranslateColumn XTC
                ORDER BY XTC.TableName, XTC.ColumnName");

            // init tablename lookupedit
            InitTableLookupEdit();

            // check if need to load defaults
            if (qryXTranslateColumn.IsEmpty)
            {
                // load as positionchanged and editvaluechanged were not called
                LoadTranslation();

                // init columname lookupedits
                InitColumnLookupEdits(null);
            }
        }

        private void InitTableLookupEdit()
        {
            // fill queries for lookupedits
            SqlQuery qryTableNames = DBUtil.OpenSQL(@"
                SELECT [Code] = TBL.name,
                       [Text] = TBL.name
                FROM sys.tables TBL WITH (READUNCOMMITTED)
                WHERE TBL.name NOT IN ('dtproperties', 'sysdiagrams')
                ORDER BY TBL.name;");

            // apply
            edtTableName.LoadQuery(qryTableNames);
            edtTableName.Properties.DropDownRows = Math.Min(qryTableNames.Count, 14);
            edtTableName.Properties.PopupWidth = edtTableName.Width + 80;
        }

        private void LoadTranslation()
        {
            // setup vars
            string tableName = GetTranslationColumnValue("TableName");
            string columnName = GetTranslationColumnValue("ColumnName");
            string tidColumnName = GetTranslationColumnValue("TIDColumnName");

            // remove datamember first
            edtTranslation.DataMemberDefaultText = null;
            edtTranslation.DataMemberTID = null;

            // load correspoding data
            LoadTranslationData(tableName, columnName, tidColumnName);

            // set datamember again
            edtTranslation.DataMemberDefaultText = columnName;
            edtTranslation.DataMemberTID = tidColumnName;
        }

        private void LoadTranslationData(string tableName, string columnName, string tidColumnName)
        {
            try
            {
                // setup cursor
                Cursor.Current = Cursors.WaitCursor;

                // set flag
                _isRefreshingTranslation = true;

                // setup vars
                string idColumnName = string.Format("{0}ID", tableName);

                // remove all visible columns first
                grvTranslation.Columns.Clear();
                qryTranslation.DataTable.Columns.Clear();

                // fill query
                qryTranslation.Fill(@"
                    -- setup var and default value
                    DECLARE @TableName VARCHAR(255);
                    DECLARE @ColumName VARCHAR(255);
                    DECLARE @TIDColumName VARCHAR(255);

                    DECLARE @LanguageColumns NVARCHAR(1000);
                    DECLARE @SqlString VARCHAR(MAX);

                    SET @TableName = {0};
                    SET @ColumName = {1};
                    SET @TIDColumName = {2};

                    SET @LanguageColumns = '';
                    SET @SqlString = '';

                    -- get all languages as [Deutsch],[Englisch], ... including subquery for text
                    SELECT @LanguageColumns = @LanguageColumns +
                                              '[' + @ColumName + ' ' + SUBSTRING(LOV.Text, 1, 1) + ']' +
                                              '=(SELECT LNG.Text
                                                 FROM dbo.XLangText LNG WITH (READUNCOMMITTED)
                                                 WHERE LNG.TID = TBL.' + @TIDColumName + '
                                                   AND LNG.LanguageCode = ' + CONVERT(VARCHAR(10),LOV.Code) + '), '
                    FROM dbo.XLOVCode LOV WITH (READUNCOMMITTED)
                    WHERE LOV.LOVName = 'Sprache'
                      AND LOV.Text NOT LIKE '%]%'
                    GROUP BY LOV.Text, LOV.Code, LOV.SortKey
                    ORDER BY LOV.SortKey ASC;

                    -- validate for empty
                    IF (@LanguageColumns IS NULL OR @LanguageColumns = '')
                    BEGIN
                      SET @LanguageColumns = 'NoLang = 1,';
                    END;

                    -- remove last comma and prepare string
                    SELECT @LanguageColumns = LEFT(@LanguageColumns, LEN(@LanguageColumns) - 1);

                    -- debug only
                    -- PRINT(@LanguageColumns);

                    -- create query to execute with all language columns
                    SET @SqlString = '
                      SELECT TBL.' + @TableName + 'ID,
                             [ID]   = TBL.' + @TableName + 'ID,
                             TBL.' + @ColumName + ',
                             TBL.' + @TIDColumName + ',
                             ' + @LanguageColumns + ',
                             TBL.' + @TableName + 'TS
                      FROM dbo.' + @TableName + ' TBL WITH (READUNCOMMITTED)
                      ORDER BY TBL.' + @TableName + 'ID'

                    -- execute query and show data
                    --PRINT(@sqlString);
                    EXEC(@SqlString);", tableName, columnName, tidColumnName);

                // setup query
                qryTranslation.TableName = tableName;

                // init validation counter
                int colsAdded = 0;

                // loop through language items and add columns to grid
                foreach (System.Data.DataColumn col in qryTranslation.DataTable.Columns)
                {
                    // check if need to add column
                    if (col.ColumnName.Equals(idColumnName) ||
                        col.ColumnName.EndsWith("$") ||
                        col.ColumnName.EndsWith("TID", false, null) ||
                        col.ColumnName.EndsWith("TS", false, null))
                    {
                        continue;
                    }

                    // create new column
                    DevExpress.XtraGrid.Columns.GridColumn newCol = new DevExpress.XtraGrid.Columns.GridColumn();
                    newCol.FieldName = col.ColumnName;
                    newCol.Caption = col.Caption;
                    newCol.Width = 120;
                    newCol.VisibleIndex = grvTranslation.Columns.Count;

                    // add column to view
                    grvTranslation.Columns.Add(newCol);
                    colsAdded++;
                }

                // autosize columns
                SetupTranslationColumns();

                // validate (we need at least three columns: ID, ColumnName and one language)
                if (colsAdded < 3 && qryTranslation.DataTable.Columns.Count > 0)
                {
                    throw new Exception(string.Format(@"Could not add all columns to current view ('{0}' of '{1}' columns)", colsAdded, qryTranslation.DataTable.Columns.Count));
                }
            }
            catch (Exception ex)
            {
                // show error
                KissMsg.ShowError(this.Name, "ErrorLoadingData", "Es ist ein Fehler in der Verarbeitung aufgetreten. Die Daten werden womöglich nicht korrekt dargestellt.", ex);

                // logging
                XLog.Create(this.GetType().FullName, LogLevel.WARN, "Error loading translation data.", ex.Message);
            }
            finally
            {
                // reset cursor
                Cursor.Current = Cursors.Default;

                // reset flags
                _isRefreshingTranslation = false;
            }
        }

        private void SetupRights()
        {
            // vars
            bool isAdmin = Session.User.IsUserAdmin;
            bool isBIAGAdmin = Session.User.IsUserBIAGAdmin;
            bool canReadData = false;
            bool canInsert = false;
            bool canUpdate = false;
            bool canDelete = false;

            // set values
            Session.GetUserRight(this.Name, out canReadData, out canInsert, out canUpdate, out canDelete);

            if (!canReadData)
            {
                // no rights to view this control
                throw new AccessViolationException("No rights to view details of this control.");
            }

            // query - XTranslateColumn
            qryXTranslateColumn.CanInsert = isBIAGAdmin;    // only biag-admin can manage the translation entries
            qryXTranslateColumn.CanUpdate = isBIAGAdmin;
            qryXTranslateColumn.CanDelete = isBIAGAdmin;

            // query - Translation
            qryTranslation.CanInsert = isAdmin || canInsert;
            qryTranslation.CanUpdate = isAdmin || canUpdate;
            qryTranslation.CanDelete = isAdmin || canDelete;

            // controls
            qryXTranslateColumn.EnableBoundFields();
            qryTranslation.EnableBoundFields();
        }

        private void SetupTranslationColumns()
        {
            // autosize columns
            grdTranslation.View.BestFitColumns();
        }

        private void TranslationHasChanged()
        {
            // set flag
            this._translationHasChanged = true;
        }

        #endregion

        #endregion
    }
}