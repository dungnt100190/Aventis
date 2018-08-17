using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using Kiss.Infrastructure;
using KiSS4.DB;
using SharpLibrary.WinControls;

namespace KiSS4.Gui
{
    public partial class CtlTranslateMask : KissUserControl
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlTranslateMask"/> class.
        /// </summary>
        public CtlTranslateMask()
            : this(null, new Hashtable())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlTranslateMask"/> class.
        /// </summary>
        /// <param name="maskname">The maskname.</param>
        /// <param name="htComponent">The ht component.</param>
        public CtlTranslateMask(string maskname, Hashtable htComponent)
        {
            // set flag on session to prevent executing sql-statements on KissSearchUserControl
            Session.IsInTranslationDialog = true;

            Maskname = maskname;
            Components = htComponent;

            InitializeComponent();
        }

        #endregion

        #region Destructor

        /// <summary>
        /// Use C# destructor syntax for finalization code.
        /// </summary>
        ~CtlTranslateMask()
        {
            Dispose(false);
        }

        #endregion

        #region Dispose

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            // release all resources
            ReleaseResources();

            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        #endregion

        #region Properties

        public Hashtable Components
        {
            get;
            set;
        }

        /// <summary>
        /// The maskname to be handled
        /// </summary>
        public string Maskname
        {
            get;
            set;
        }

        #endregion

        #region EventHandlers

        private void CtlTranslateMask_Leave(object sender, EventArgs e)
        {
            Save();
            SetTranslationBackground(Color.Empty);
        }

        private void CtlTranslateMask_SaveData(object sender, EventArgs e)
        {
            Save();
            SetTranslationBackground(Color.Empty);
        }

        private void edtLanguageFrom_EditValueChanged(object sender, EventArgs e)
        {
            Save();
            Fill();
            SetTranslationBackground(Color.Empty);
        }

        private void gridViews_BeforeLeaveRow(object sender, RowAllowEventArgs e)
        {
            //remove Color formatting
            SetTranslationBackground(Color.Empty);
        }

        private void gridViews_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (qryControls.IsFilling)
            {
                return;
            }

            SetActiveTabControl();

            //set Color formatting
            SetTranslationBackground(Color.Tomato);
        }

        private void grvControls_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            //hack to know which rows were changed...

            qryControls.Row.BeginEdit();

            if (Maskname != null && qryControls["FieldID"] != DBNull.Value && qryControls["FieldID"] != null)
            {
                if ((Components[qryControls["FieldID"]] as KissCompPropDescriptor) != null)
                {
                    ((KissCompPropDescriptor)Components[qryControls["FieldID"]]).Value = e.Value.ToString();
                }
            }
        }

        private void qryControlTypes_PositionChanged(object sender, EventArgs e)
        {
            SetTranslationBackground(Color.Empty);
            Save();
            Fill();
            SetActiveTabControl();

            // resize due to scrollbar
            ApplicationFacade.DoEvents();
            ResizeDropDowns();
        }

        #endregion

        #region Methods

        #region Public Static Methods

        public static void ReleaseResources()
        {
            // reset flag on session to prevent executing sql-statements on KissSearchUserControl
            Session.IsInTranslationDialog = false;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Translates texts (exact matches only) of all rows
        /// </summary>
        public void AutoTranslate()
        {
            Int32 languageCode = edtLanguageTo.EditValue != null && Convert.ToInt32(edtLanguageTo.EditValue) > 0
                                     ? Convert.ToInt32(edtLanguageTo.EditValue)
                                     : 1;

            AutoTranslate(languageCode);
        }

        /// <summary>
        /// Translates texts (exact matches only) of all rows
        /// </summary>
        /// <param name="languageCode">The langauge code to translate</param>
        public void AutoTranslate(Int32 languageCode)
        {
            foreach (DataRow row in qryControls.DataTable.Rows)
            {
                if (row["DefaultText"] is String && Convert.ToString(row["DefaultText"]) != "[leer]")
                {
                    string translation = Convert.ToString(
                        DBUtil.ExecuteScalarSQL(@"
                            --exact match
                            IF EXISTS(SELECT TOP 1 1
                                      FROM dbo.XLangText WITH (READUNCOMMITTED)
                                      WHERE Text LIKE {0} AND
                                            LanguageCode = 1)
                            BEGIN
                               SELECT TOP 1
                                      TXT2.Text
                               FROM dbo.XLangText TXT1 WITH (READUNCOMMITTED)
                                 LEFT JOIN dbo.XLangText TXT2 WITH (READUNCOMMITTED) ON TXT2.TID = TXT1.TID
                               WHERE TXT1.Text LIKE {0} AND
                                     TXT1.LanguageCode = 1 AND
                                     TXT2.LanguageCode = {1}
                               ORDER BY DIFFERENCE(TXT1.Text, {0}) DESC
                            END",
                            row["DefaultText"],
                            languageCode));

                    if (DBUtil.IsEmpty(row["Text"]))
                    {
                        row["Text"] = translation;
                        grvControls_CellValueChanging(null, new CellValueChangedEventArgs(0, null, translation));
                    }
                }
            }
        }

        /// <summary>
        /// Fill query with controls
        /// </summary>
        public void Fill()
        {
            // TODO fill maybe texts from XMessage (don't forget to change spSetXLangText)

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!DesignMode && qryControls != null &&
                    Session.User != null &&
                    edtLanguageFrom1.EditValue != null &&
                    edtLanguageTo.EditValue != null &&
                    Convert.ToInt32(edtLanguageFrom1.EditValue) > 0 &&
                    Convert.ToInt32(edtLanguageTo.EditValue) > 0)
                {
                    qryControls.Fill(@"
                        DECLARE @Controls Table
                        (
                            ID            INT PRIMARY KEY IDENTITY(1, 1),
                            ParentID      INT,
                            ClassName     VARCHAR(255),
                            FieldID       VARCHAR(255),
                            TypeName      VARCHAR(255),
                            FieldName	    VARCHAR(255),
                            TID           INT,
                            TypeCode      INT,
                            ParentControl VARCHAR(255)
                        )

                        -- Components
                        INSERT INTO @Controls
                            SELECT NULL,
                                    ClassName,
                                    ComponentName,
                                    TypeName,
                                    CASE WHEN {0} IS NULL THEN ClassName + '.' + ComponentName
                                        ELSE ComponentName
                                    END,
                                    ComponentTID,
                                    1,
                                    NULL
                            FROM dbo.XClassComponent WITH (READUNCOMMITTED)
                            WHERE (ClassName = {0} OR {0} IS NULL) AND
                                TypeName NOT IN ('DevExpress.XtraGrid.Views.Grid.GridView')

                        -- Controls
                        INSERT INTO @Controls
                            SELECT NULL,
                                    ClassName,
                                    ControlName,
                                    TypeName,
                                    CASE WHEN {0} IS NULL THEN ClassName + '.' + ControlName
                                        ELSE ControlName
                                    END,
                                    ControlTID,
                                    0,
                                    ParentControl
                            FROM dbo.XClassControl WITH (READUNCOMMITTED)
                            WHERE (ClassName = {0} OR {0} IS NULL) AND
                                ((DataMember IS NULL AND DataSource IS NULL) OR TypeName IN ('KiSS4.Gui.KissRadioGroup', 'KiSS4.Gui.KissCheckEdit')) AND
                                TypeName NOT IN ('System.Windows.Forms.PictureBox', 'System.Windows.Forms.Panel', 'KiSS4.Gui.KissGrid', 'KiSS4.Gui.KissTree', 'System.Windows.Forms.Splitter', 'KiSS4.Gui.KissSplitterCollapsible', 'KiSS4.Gui.KissTabControlEx')

                        -- Class
                        INSERT INTO @Controls
                            SELECT NULL,
                                    ClassName,
                                    ClassName,
                                    BaseType,
                                    ClassName,
                                    ClassTID,
                                    2,
                                    NULL
                            FROM dbo.XClass WITH (READUNCOMMITTED)
                            WHERE (ClassName = {0} OR {0} IS NULL)

                        -- Select and filter
                        SELECT CTR.*,
                                DefaultText = TXT_1.Text,
                                DefaultText2 = TXT_2.Text,
                                Text = TXT_3.Text
                        FROM @Controls CTR
                            LEFT JOIN dbo.XLangText TXT_1 WITH (READUNCOMMITTED) ON TXT_1.TID = CTR.TID AND
                                                                                    TXT_1.LanguageCode = {1}
                            LEFT JOIN dbo.XLangText TXT_2 WITH (READUNCOMMITTED) ON TXT_2.TID = CTR.TID AND
                                                                                    TXT_2.LanguageCode = {2}
                            LEFT JOIN dbo.XLangText TXT_3 WITH (READUNCOMMITTED) ON TXT_3.TID = CTR.TID AND
                                                                                    TXT_3.LanguageCode = {3}
                        WHERE ','+{4}+',' LIKE '%,'+TypeName+',%'
                        ORDER BY ParentControl",
                        Maskname,
                        Convert.ToInt32(edtLanguageFrom1.EditValue),
                        Convert.ToInt32(edtLanguageFrom2.EditValue),
                        Convert.ToInt32(edtLanguageTo.EditValue),
                        qryControlTypes["Value3"]);
                }

                SetNonTranslatedTexts();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("CtlTranslateMask", "FillException", "Fehler beim Befüllen der Datenquelle.", ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public override bool OnSaveData()
        {
            Save();
            return true;
        }

        /// <summary>
        /// Save changes made
        /// </summary>
        public void Save()
        {
            if (qryControls != null && qryControls.DataTable != null)
            {
                foreach (DataRow row in qryControls.DataTable.Rows)
                {
                    if (row.RowState == DataRowState.Modified && row["Text"] != DBNull.Value)
                    {
                        Int32 result = -1;

                        row["TID"] = Convert.ToInt32(
                            DBUtil.ExecuteScalarSQL(@"
                                --SQLCHECK_IGNORE--
                                EXEC dbo.spXSetXLangText {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7} OUT

                                SELECT {7}",
                                row["TID"],
                                edtLanguageTo.EditValue,
                                row["Text"],
                                row["ClassName"],
                                row["FieldID"],
                                row["TypeCode"],
                                DBNull.Value,
                                result));

                        // if default lang text not in db, set is as well
                        if (Convert.ToInt32(edtLanguageTo.EditValue) != 1)
                        {
                            DBUtil.ExecSQL(@"
                                IF NOT EXISTS(SELECT TOP 1 1
                                              FROM dbo.XLangText WITH (READUNCOMMITTED)
                                              WHERE TID = {0} AND LanguageCode = 1)
                                BEGIN
                                  EXEC dbo.spXSetXLangText {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}
                                END",
                                row["TID"],
                                1,
                                row["DefaultText"],
                                row["ClassName"],
                                row["FieldID"],
                                row["TypeCode"],
                                DBNull.Value,
                                result);
                        }

                        row.AcceptChanges();
                    }
                }
            }
        }

        #endregion

        #region Protected Methods

        protected override void OnLoad(EventArgs e)
        {
            // let base do stuff
            base.OnLoad(e);

            // check if designer is active
            if (DesignerMode)
            {
                // do not continue
                return;
            }

            edtLanguageFrom1.EditValue = 1; //German

            if (Session.User.LanguageCode > 0)
            {
                edtLanguageTo.EditValue = Session.User.LanguageCode;
            }
            else
            {
                edtLanguageTo.EditValue = 1;
            }

            edtLanguageFrom2.EditValue = edtLanguageTo.EditValue;
            qryControlTypes.Fill(@"
                SELECT Code,
                       Text = ISNULL(TXT.Text, LOV.Text), Value3
                FROM dbo.XLOVCode LOV WITH (READUNCOMMITTED)
                  LEFT JOIN dbo.XLangText TXT WITH (READUNCOMMITTED) ON TXT.TID = LOV.TextTID
                                                                    AND LanguageCode = {0}
                WHERE LOVName = 'ControlTypeCode';",
                Session.User.LanguageCode);

            Fill();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ResizeDropDowns();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ResizeDropDowns();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Resize and arrange dropdowns
        /// </summary>
        private void ResizeDropDowns()
        {
            edtLanguageFrom1.Width = grvControls.Columns[0].VisibleWidth + 1;
            edtLanguageFrom2.Width = grvControls.Columns[1].VisibleWidth + 1;
            edtLanguageFrom2.Left = edtLanguageFrom1.Width;
            edtLanguageTo.Left = edtLanguageFrom1.Width + edtLanguageFrom2.Width;
            edtLanguageTo.Width = grvControls.Columns[2].VisibleWidth + 2;
        }

        /// <summary>
        /// Set active tab control depending on selected control
        /// </summary>
        private void SetActiveTabControl()
        {
            if (!DBUtil.IsEmpty(qryControls["FieldID"]) &&
                !DBUtil.IsEmpty(Components[qryControls["FieldID"]]) &&
                Components[qryControls["FieldID"]] is KissCompPropDescriptor)
            {
                KissCompPropDescriptor cmp = ((KissCompPropDescriptor)Components[qryControls["FieldID"]]);

                Control c;

                if (cmp.Component is GridColumn)
                {
                    c = ((GridColumn)cmp.Component).View.GridControl;
                }
                else if (cmp.Component is DevExpress.XtraTreeList.Columns.TreeListColumn)
                {
                    c = ((DevExpress.XtraTreeList.Columns.TreeListColumn)cmp.Component).TreeList;
                }
                else
                {
                    c = cmp.Component as Control;
                }

                while (c != null)
                {
                    c.Visible = true;

                    if (c.GetType().Name == Maskname)
                    {
                        return;
                    }

                    if (c is TabPageEx)
                    {
                        ((TabControlEx)c.Parent).SelectedTabIndex = ((TabControlEx)c.Parent).TabPages.IndexOf(((TabPageEx)c));
                    }

                    c = c.Parent;
                }
            }
        }

        /// <summary>
        /// Set non translated texts
        /// </summary>
        private void SetNonTranslatedTexts()
        {
            foreach (DataRow row in qryControls.DataTable.Rows)
            {
                if (Components != null &&
                    Components.Count > 0 &&
                    row["FieldID"] != DBNull.Value &&
                    row["DefaultText"] == DBNull.Value &&
                    Components[row["FieldID"]] != null &&
                    Components[row["FieldID"]] is KissCompPropDescriptor)
                {
                    row["DefaultText"] = ((KissCompPropDescriptor)Components[row["FieldID"]]).Value;
                }
                else if (row["DefaultText"] == DBNull.Value && row["FieldID"] != DBNull.Value)
                {
                    row["DefaultText"] = "[leer]";
                }
                if (row["DefaultText2"] == DBNull.Value)
                {
                    row["DefaultText2"] = row["DefaultText"];
                }

                row.AcceptChanges();
            }

            qryControls.RowModified = false;
        }

        /// <summary>
        /// Set background color depending on selected control
        /// </summary>
        /// <param name="c"></param>
        private void SetTranslationBackground(Color c)
        {
            if (!DBUtil.IsEmpty(qryControls["FieldID"]) &&
                !DBUtil.IsEmpty(Components[qryControls["FieldID"]]) &&
                Components[qryControls["FieldID"]] is KissCompPropDescriptor)
            {
                ((KissCompPropDescriptor)Components[qryControls["FieldID"]]).BackColor = c;
            }
        }

        #endregion

        #endregion
    }
}