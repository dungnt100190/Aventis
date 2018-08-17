using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using KiSS4.Common;
using Kiss.Interfaces.UI;
using KiSS4.DB;

namespace KiSS4.DesignerHost
{
    /// <summary>
    /// Summary description for CtlTableColumnEditor.
    /// </summary>
    public class CtlTableColumnEditor : KissSearchUserControl
    {
        #region Variables

        private KiSS4.Gui.KissGrid gridTableColumns;
        private DevExpress.XtraGrid.Columns.GridColumn colColumn;
        private DevExpress.XtraGrid.Columns.GridColumn colFieldCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDisplayText;
        private DevExpress.XtraGrid.Columns.GridColumn colLOVName;
        private DevExpress.XtraGrid.Columns.GridColumn colSystem;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit3;
        private KiSS4.Gui.KissLabel lblColumnName;
        private KiSS4.Gui.KissLabel lblFieldCode;
        private KiSS4.Gui.KissLabel lblDisplayText;
        private KiSS4.Gui.KissLabel lblPrimaryKey;
        private KiSS4.Gui.KissLabel lblHistory;
        private KiSS4.Gui.KissLabel lblLOVName;
        private KiSS4.Gui.KissLabel lblSystem;
        private KiSS4.Gui.KissCheckEdit chkHistory;
        private KiSS4.Gui.KissCheckEdit chkSystem;
        private KiSS4.Gui.KissTextEdit txtColumnName;
        private KiSS4.Gui.KissTextEdit txtDisplayText;
        private KiSS4.DB.SqlQuery qryXTableColumn;
        private KiSS4.Gui.KissCheckEdit chkPrimaryKey;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit4;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissLookUpEdit cboFieldCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private KiSS4.Gui.KissLookUpEdit cboLOVName;
        private KiSS4.Gui.KissLabel lblSearchSystem;
        private KiSS4.Gui.KissLabel lblSearchLOVName;
        private KiSS4.Gui.KissLabel lblSearchDisplayText;
        private KiSS4.Gui.KissLabel lblSearchField;
        private KiSS4.Gui.KissLabel lblSearchColumn;
        private KiSS4.Gui.KissLabel lblSearchTable;
        private KiSS4.Gui.KissTextEdit txtSearchTable;
        private KiSS4.Gui.KissLookUpEdit cboSearchLOVName;
        private KiSS4.Gui.KissLookUpEdit cboSearchFieldCode;
        private KiSS4.Gui.KissCheckEdit chkSearchSystem;
        private KiSS4.Gui.KissTextEdit txtSearchDisplayText;
        private KiSS4.Gui.KissTextEdit txtSearchColumn;
        private KiSS4.Gui.KissContainerControl kccContainer;
        private DevExpress.XtraGrid.Views.Grid.GridView gvViewList;
        private KiSS4.Gui.KissLabel lblSize;
        private KiSS4.Gui.KissCheckEdit chkAllowNull;
        private KiSS4.Gui.KissLabel lblAllowNull;
        private KiSS4.Gui.KissCalcEdit txtSize;
        private KiSS4.Gui.KissLabel lblDefaultValue;
        private KiSS4.Gui.KissCheckEdit chkSetDefaultValueAsNull;
        private KiSS4.Gui.KissContainerControl kccSubContainer;
        private KiSS4.Gui.KissTextEdit txtDefaultValue;
        private KiSS4.Gui.KissMemoEdit editComment;
        private KiSS4.Gui.KissLabel lblStatistics;
        private System.Windows.Forms.Panel pnDataType;
        private KiSS4.Gui.KissLabel lblDataRowCount;
        private KiSS4.Gui.KissLabel lblComment;

        private readonly ToolTip _toolTip = new ToolTip();

        #endregion

        #region Constructor / Dispose

        /// <summary>
        /// Constructor
        /// </summary>
        public CtlTableColumnEditor()
        {
            LastDataRowState = DataRowState.Unchanged;
            SystemPermitted = false;
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            //init controls and fill lists
            colFieldCode.ColumnEdit = gridTableColumns.GetLOVLookUpEdit(cboFieldCode.LOVName);
            SqlQuery qryLOVName = DBUtil.OpenSQL("SELECT Code = NULL, Text = '' UNION ALL SELECT Code = LOVName, Text = LOVName FROM XLOV ORDER BY 1;");
            cboSearchLOVName.Properties.DataSource = qryLOVName;
            cboLOVName.Properties.DataSource = qryLOVName;

            colLOVName.ColumnEdit = gridTableColumns.GetLOVLookUpEdit(qryLOVName);

            SqlQuery qryFieldCode = DBUtil.OpenSQL("SELECT Code = NULL, Text = '' UNION ALL SELECT Code, Text FROM XLOVCode WHERE LOVName = 'FieldCode' ORDER BY 1;");
            cboSearchFieldCode.Properties.DataSource = qryFieldCode;

            ActiveSQLQuery = qryXTableColumn;
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
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

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gridTableColumns = new KiSS4.Gui.KissGrid();
            this.qryXTableColumn = new KiSS4.DB.SqlQuery(this.components);
            this.gvViewList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFieldCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDisplayText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLOVName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSystem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.cboSearchLOVName = new KiSS4.Gui.KissLookUpEdit();
            this.cboSearchFieldCode = new KiSS4.Gui.KissLookUpEdit();
            this.chkSearchSystem = new KiSS4.Gui.KissCheckEdit();
            this.lblSearchSystem = new KiSS4.Gui.KissLabel();
            this.lblSearchLOVName = new KiSS4.Gui.KissLabel();
            this.txtSearchDisplayText = new KiSS4.Gui.KissTextEdit();
            this.lblSearchDisplayText = new KiSS4.Gui.KissLabel();
            this.lblSearchField = new KiSS4.Gui.KissLabel();
            this.txtSearchColumn = new KiSS4.Gui.KissTextEdit();
            this.lblSearchColumn = new KiSS4.Gui.KissLabel();
            this.txtSearchTable = new KiSS4.Gui.KissTextEdit();
            this.lblSearchTable = new KiSS4.Gui.KissLabel();
            this.txtColumnName = new KiSS4.Gui.KissTextEdit();
            this.lblColumnName = new KiSS4.Gui.KissLabel();
            this.lblFieldCode = new KiSS4.Gui.KissLabel();
            this.txtDisplayText = new KiSS4.Gui.KissTextEdit();
            this.lblDisplayText = new KiSS4.Gui.KissLabel();
            this.lblPrimaryKey = new KiSS4.Gui.KissLabel();
            this.lblHistory = new KiSS4.Gui.KissLabel();
            this.lblLOVName = new KiSS4.Gui.KissLabel();
            this.lblSystem = new KiSS4.Gui.KissLabel();
            this.chkHistory = new KiSS4.Gui.KissCheckEdit();
            this.chkSystem = new KiSS4.Gui.KissCheckEdit();
            this.chkPrimaryKey = new KiSS4.Gui.KissCheckEdit();
            this.cboFieldCode = new KiSS4.Gui.KissLookUpEdit();
            this.cboLOVName = new KiSS4.Gui.KissLookUpEdit();
            this.kccContainer = new KiSS4.Gui.KissContainerControl();
            this.kccSubContainer = new KiSS4.Gui.KissContainerControl();
            this.pnDataType = new System.Windows.Forms.Panel();
            this.txtSize = new KiSS4.Gui.KissCalcEdit();
            this.lblSize = new KiSS4.Gui.KissLabel();
            this.lblStatistics = new KiSS4.Gui.KissLabel();
            this.editComment = new KiSS4.Gui.KissMemoEdit();
            this.lblComment = new KiSS4.Gui.KissLabel();
            this.lblAllowNull = new KiSS4.Gui.KissLabel();
            this.chkAllowNull = new KiSS4.Gui.KissCheckEdit();
            this.lblDefaultValue = new KiSS4.Gui.KissLabel();
            this.chkSetDefaultValueAsNull = new KiSS4.Gui.KissCheckEdit();
            this.txtDefaultValue = new KiSS4.Gui.KissTextEdit();
            this.lblDataRowCount = new KiSS4.Gui.KissLabel();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTableColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXTableColumn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSearchLOVName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSearchLOVName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSearchFieldCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSearchFieldCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSearchSystem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchSystem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchLOVName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchDisplayText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchDisplayText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchColumn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchColumn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchTable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtColumnName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblColumnName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFieldCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDisplayText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDisplayText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPrimaryKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLOVName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSystem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHistory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSystem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPrimaryKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFieldCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFieldCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLOVName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLOVName.Properties)).BeginInit();
            this.kccContainer.SuspendLayout();
            this.kccSubContainer.SuspendLayout();
            this.pnDataType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatistics)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editComment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblComment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAllowNull)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllowNull.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDefaultValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSetDefaultValueAsNull.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDefaultValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDataRowCount)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(776, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 0);
            this.tabControlSearch.Size = new System.Drawing.Size(816, 312);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.gridTableColumns);
            this.tpgListe.Size = new System.Drawing.Size(804, 274);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.cboSearchLOVName);
            this.tpgSuchen.Controls.Add(this.cboSearchFieldCode);
            this.tpgSuchen.Controls.Add(this.chkSearchSystem);
            this.tpgSuchen.Controls.Add(this.lblSearchSystem);
            this.tpgSuchen.Controls.Add(this.lblSearchLOVName);
            this.tpgSuchen.Controls.Add(this.txtSearchDisplayText);
            this.tpgSuchen.Controls.Add(this.lblSearchDisplayText);
            this.tpgSuchen.Controls.Add(this.lblSearchField);
            this.tpgSuchen.Controls.Add(this.txtSearchColumn);
            this.tpgSuchen.Controls.Add(this.lblSearchColumn);
            this.tpgSuchen.Controls.Add(this.txtSearchTable);
            this.tpgSuchen.Controls.Add(this.lblSearchTable);
            this.tpgSuchen.Size = new System.Drawing.Size(804, 274);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.lblSearchTable, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.txtSearchTable, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSearchColumn, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.txtSearchColumn, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSearchField, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSearchDisplayText, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.txtSearchDisplayText, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSearchLOVName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSearchSystem, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkSearchSystem, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.cboSearchFieldCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.cboSearchLOVName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            // 
            // gridTableColumns
            // 
            this.gridTableColumns.DataSource = this.qryXTableColumn;
            this.gridTableColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTableColumns.EmbeddedNavigator.Name = "";
            this.gridTableColumns.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.gridTableColumns.Location = new System.Drawing.Point(0, 0);
            this.gridTableColumns.MainView = this.gvViewList;
            this.gridTableColumns.Name = "gridTableColumns";
            this.gridTableColumns.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2,
            this.repositoryItemCheckEdit3,
            this.repositoryItemCheckEdit4,
            this.repositoryItemLookUpEdit1});
            this.gridTableColumns.Size = new System.Drawing.Size(804, 274);
            this.gridTableColumns.TabIndex = 0;
            this.gridTableColumns.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvViewList});
            // 
            // qryXTableColumn
            // 
            this.qryXTableColumn.CanDelete = true;
            this.qryXTableColumn.CanInsert = true;
            this.qryXTableColumn.CanUpdate = true;
            this.qryXTableColumn.HostControl = this;
            this.qryXTableColumn.TableName = "XTableColumn";
            this.qryXTableColumn.AfterDelete += new System.EventHandler(this.qryXTableColumn_AfterDelete);
            this.qryXTableColumn.AfterInsert += new System.EventHandler(this.qryXTableColumn_AfterInsert);
            this.qryXTableColumn.PositionChanged += new System.EventHandler(this.qryXTableColumn_PositionChanged);
            this.qryXTableColumn.BeforePost += new System.EventHandler(this.qryXTableColumn_BeforePost);
            this.qryXTableColumn.AfterPost += new System.EventHandler(this.qryXTableColumn_AfterPost);
            this.qryXTableColumn.BeforeDeleteQuestion += new System.EventHandler(this.qryXTableColumn_BeforeDeleteQuestion);
            // 
            // gvViewList
            // 
            this.gvViewList.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gvViewList.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvViewList.Appearance.Empty.Options.UseBackColor = true;
            this.gvViewList.Appearance.Empty.Options.UseFont = true;
            this.gvViewList.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvViewList.Appearance.EvenRow.Options.UseFont = true;
            this.gvViewList.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvViewList.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvViewList.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gvViewList.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvViewList.Appearance.FocusedCell.Options.UseFont = true;
            this.gvViewList.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvViewList.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvViewList.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvViewList.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gvViewList.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvViewList.Appearance.FocusedRow.Options.UseFont = true;
            this.gvViewList.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gvViewList.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gvViewList.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gvViewList.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gvViewList.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvViewList.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvViewList.Appearance.GroupRow.Options.UseBackColor = true;
            this.gvViewList.Appearance.GroupRow.Options.UseFont = true;
            this.gvViewList.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvViewList.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gvViewList.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gvViewList.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvViewList.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvViewList.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gvViewList.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvViewList.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gvViewList.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvViewList.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvViewList.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvViewList.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvViewList.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gvViewList.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gvViewList.Appearance.HorzLine.Options.UseBackColor = true;
            this.gvViewList.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvViewList.Appearance.OddRow.Options.UseFont = true;
            this.gvViewList.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gvViewList.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvViewList.Appearance.Row.Options.UseBackColor = true;
            this.gvViewList.Appearance.Row.Options.UseFont = true;
            this.gvViewList.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvViewList.Appearance.SelectedRow.Options.UseFont = true;
            this.gvViewList.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gvViewList.Appearance.VertLine.Options.UseBackColor = true;
            this.gvViewList.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gvViewList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colColumn,
            this.colFieldCode,
            this.colDisplayText,
            this.colLOVName,
            this.colSystem});
            this.gvViewList.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gvViewList.GridControl = this.gridTableColumns;
            this.gvViewList.Name = "gvViewList";
            this.gvViewList.OptionsBehavior.Editable = false;
            this.gvViewList.OptionsCustomization.AllowFilter = false;
            this.gvViewList.OptionsFilter.AllowFilterEditor = false;
            this.gvViewList.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gvViewList.OptionsMenu.EnableColumnMenu = false;
            this.gvViewList.OptionsNavigation.AutoFocusNewRow = true;
            this.gvViewList.OptionsNavigation.UseTabKey = false;
            this.gvViewList.OptionsView.ColumnAutoWidth = false;
            this.gvViewList.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvViewList.OptionsView.ShowGroupPanel = false;
            this.gvViewList.OptionsView.ShowIndicator = false;
            // 
            // colColumn
            // 
            this.colColumn.Caption = "Spalte";
            this.colColumn.FieldName = "ColumnName";
            this.colColumn.Name = "colColumn";
            this.colColumn.Visible = true;
            this.colColumn.VisibleIndex = 0;
            this.colColumn.Width = 180;
            // 
            // colFieldCode
            // 
            this.colFieldCode.Caption = "Feld";
            this.colFieldCode.FieldName = "FieldCode";
            this.colFieldCode.Name = "colFieldCode";
            this.colFieldCode.Visible = true;
            this.colFieldCode.VisibleIndex = 1;
            this.colFieldCode.Width = 120;
            // 
            // colDisplayText
            // 
            this.colDisplayText.Caption = "Angezeigter Text";
            this.colDisplayText.FieldName = "DisplayText";
            this.colDisplayText.Name = "colDisplayText";
            this.colDisplayText.Visible = true;
            this.colDisplayText.VisibleIndex = 2;
            this.colDisplayText.Width = 133;
            // 
            // colLOVName
            // 
            this.colLOVName.Caption = "Werteliste";
            this.colLOVName.FieldName = "LOVName";
            this.colLOVName.Name = "colLOVName";
            this.colLOVName.Visible = true;
            this.colLOVName.VisibleIndex = 3;
            this.colLOVName.Width = 120;
            // 
            // colSystem
            // 
            this.colSystem.Caption = "System";
            this.colSystem.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colSystem.FieldName = "System";
            this.colSystem.Name = "colSystem";
            this.colSystem.Visible = true;
            this.colSystem.VisibleIndex = 4;
            this.colSystem.Width = 53;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // repositoryItemCheckEdit3
            // 
            this.repositoryItemCheckEdit3.AutoHeight = false;
            this.repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
            // 
            // repositoryItemCheckEdit4
            // 
            this.repositoryItemCheckEdit4.AutoHeight = false;
            this.repositoryItemCheckEdit4.Name = "repositoryItemCheckEdit4";
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.repositoryItemLookUpEdit1.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.repositoryItemLookUpEdit1.AppearanceDropDown.Options.UseBackColor = true;
            this.repositoryItemLookUpEdit1.AppearanceDropDown.Options.UseFont = true;
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.NullText = "";
            this.repositoryItemLookUpEdit1.ShowFooter = false;
            this.repositoryItemLookUpEdit1.ShowHeader = false;
            // 
            // cboSearchLOVName
            // 
            this.cboSearchLOVName.DataMember = "LOVName";
            this.cboSearchLOVName.Location = new System.Drawing.Point(120, 176);
            this.cboSearchLOVName.Name = "cboSearchLOVName";
            this.cboSearchLOVName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboSearchLOVName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboSearchLOVName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboSearchLOVName.Properties.Appearance.Options.UseBackColor = true;
            this.cboSearchLOVName.Properties.Appearance.Options.UseBorderColor = true;
            this.cboSearchLOVName.Properties.Appearance.Options.UseFont = true;
            this.cboSearchLOVName.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboSearchLOVName.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboSearchLOVName.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboSearchLOVName.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboSearchLOVName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.cboSearchLOVName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.cboSearchLOVName.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboSearchLOVName.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LOVName")});
            this.cboSearchLOVName.Properties.DisplayMember = "LOVName";
            this.cboSearchLOVName.Properties.NullText = "";
            this.cboSearchLOVName.Properties.ShowFooter = false;
            this.cboSearchLOVName.Properties.ShowHeader = false;
            this.cboSearchLOVName.Properties.ValueMember = "LOVName";
            this.cboSearchLOVName.Size = new System.Drawing.Size(200, 24);
            this.cboSearchLOVName.TabIndex = 4;
            // 
            // cboSearchFieldCode
            // 
            this.cboSearchFieldCode.DataMember = "FieldCode";
            this.cboSearchFieldCode.Location = new System.Drawing.Point(120, 112);
            this.cboSearchFieldCode.LOVName = "FieldCode";
            this.cboSearchFieldCode.Name = "cboSearchFieldCode";
            this.cboSearchFieldCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboSearchFieldCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboSearchFieldCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboSearchFieldCode.Properties.Appearance.Options.UseBackColor = true;
            this.cboSearchFieldCode.Properties.Appearance.Options.UseBorderColor = true;
            this.cboSearchFieldCode.Properties.Appearance.Options.UseFont = true;
            this.cboSearchFieldCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboSearchFieldCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboSearchFieldCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboSearchFieldCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboSearchFieldCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.cboSearchFieldCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.cboSearchFieldCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboSearchFieldCode.Properties.NullText = "";
            this.cboSearchFieldCode.Properties.ShowFooter = false;
            this.cboSearchFieldCode.Properties.ShowHeader = false;
            this.cboSearchFieldCode.Size = new System.Drawing.Size(200, 24);
            this.cboSearchFieldCode.TabIndex = 2;
            // 
            // chkSearchSystem
            // 
            this.chkSearchSystem.DataMember = "System";
            this.chkSearchSystem.EditValue = false;
            this.chkSearchSystem.Location = new System.Drawing.Point(120, 208);
            this.chkSearchSystem.Name = "chkSearchSystem";
            this.chkSearchSystem.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkSearchSystem.Properties.Appearance.Options.UseBackColor = true;
            this.chkSearchSystem.Properties.Caption = "";
            this.chkSearchSystem.Size = new System.Drawing.Size(24, 19);
            this.chkSearchSystem.TabIndex = 5;
            // 
            // lblSearchSystem
            // 
            this.lblSearchSystem.Location = new System.Drawing.Point(16, 208);
            this.lblSearchSystem.Name = "lblSearchSystem";
            this.lblSearchSystem.Size = new System.Drawing.Size(100, 24);
            this.lblSearchSystem.TabIndex = 35;
            this.lblSearchSystem.Text = "System";
            // 
            // lblSearchLOVName
            // 
            this.lblSearchLOVName.Location = new System.Drawing.Point(16, 176);
            this.lblSearchLOVName.Name = "lblSearchLOVName";
            this.lblSearchLOVName.Size = new System.Drawing.Size(100, 24);
            this.lblSearchLOVName.TabIndex = 34;
            this.lblSearchLOVName.Text = "Werteliste";
            // 
            // txtSearchDisplayText
            // 
            this.txtSearchDisplayText.DataMember = "DisplayText";
            this.txtSearchDisplayText.Location = new System.Drawing.Point(120, 144);
            this.txtSearchDisplayText.Name = "txtSearchDisplayText";
            this.txtSearchDisplayText.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.txtSearchDisplayText.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.txtSearchDisplayText.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txtSearchDisplayText.Properties.Appearance.Options.UseBackColor = true;
            this.txtSearchDisplayText.Properties.Appearance.Options.UseBorderColor = true;
            this.txtSearchDisplayText.Properties.Appearance.Options.UseFont = true;
            this.txtSearchDisplayText.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtSearchDisplayText.Size = new System.Drawing.Size(200, 24);
            this.txtSearchDisplayText.TabIndex = 3;
            // 
            // lblSearchDisplayText
            // 
            this.lblSearchDisplayText.Location = new System.Drawing.Point(16, 144);
            this.lblSearchDisplayText.Name = "lblSearchDisplayText";
            this.lblSearchDisplayText.Size = new System.Drawing.Size(100, 24);
            this.lblSearchDisplayText.TabIndex = 30;
            this.lblSearchDisplayText.Text = "Angezeigter Text";
            // 
            // lblSearchField
            // 
            this.lblSearchField.Location = new System.Drawing.Point(16, 112);
            this.lblSearchField.Name = "lblSearchField";
            this.lblSearchField.Size = new System.Drawing.Size(100, 24);
            this.lblSearchField.TabIndex = 29;
            this.lblSearchField.Text = "Feld";
            // 
            // txtSearchColumn
            // 
            this.txtSearchColumn.DataMember = "ColumnName";
            this.txtSearchColumn.Location = new System.Drawing.Point(120, 80);
            this.txtSearchColumn.Name = "txtSearchColumn";
            this.txtSearchColumn.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.txtSearchColumn.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.txtSearchColumn.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txtSearchColumn.Properties.Appearance.Options.UseBackColor = true;
            this.txtSearchColumn.Properties.Appearance.Options.UseBorderColor = true;
            this.txtSearchColumn.Properties.Appearance.Options.UseFont = true;
            this.txtSearchColumn.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtSearchColumn.Size = new System.Drawing.Size(200, 24);
            this.txtSearchColumn.TabIndex = 1;
            // 
            // lblSearchColumn
            // 
            this.lblSearchColumn.Location = new System.Drawing.Point(16, 80);
            this.lblSearchColumn.Name = "lblSearchColumn";
            this.lblSearchColumn.Size = new System.Drawing.Size(100, 24);
            this.lblSearchColumn.TabIndex = 27;
            this.lblSearchColumn.Text = "Spalte";
            // 
            // txtSearchTable
            // 
            this.txtSearchTable.DataMember = "TableName";
            this.txtSearchTable.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.txtSearchTable.Location = new System.Drawing.Point(120, 48);
            this.txtSearchTable.Name = "txtSearchTable";
            this.txtSearchTable.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.txtSearchTable.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.txtSearchTable.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txtSearchTable.Properties.Appearance.Options.UseBackColor = true;
            this.txtSearchTable.Properties.Appearance.Options.UseBorderColor = true;
            this.txtSearchTable.Properties.Appearance.Options.UseFont = true;
            this.txtSearchTable.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtSearchTable.Properties.ReadOnly = true;
            this.txtSearchTable.Size = new System.Drawing.Size(200, 24);
            this.txtSearchTable.TabIndex = 0;
            // 
            // lblSearchTable
            // 
            this.lblSearchTable.Location = new System.Drawing.Point(16, 48);
            this.lblSearchTable.Name = "lblSearchTable";
            this.lblSearchTable.Size = new System.Drawing.Size(100, 24);
            this.lblSearchTable.TabIndex = 25;
            this.lblSearchTable.Text = "Tabelle";
            // 
            // txtColumnName
            // 
            this.txtColumnName.DataMember = "ColumnName";
            this.txtColumnName.DataSource = this.qryXTableColumn;
            this.txtColumnName.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.txtColumnName.Location = new System.Drawing.Point(112, 16);
            this.txtColumnName.Name = "txtColumnName";
            this.txtColumnName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.txtColumnName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.txtColumnName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txtColumnName.Properties.Appearance.Options.UseBackColor = true;
            this.txtColumnName.Properties.Appearance.Options.UseBorderColor = true;
            this.txtColumnName.Properties.Appearance.Options.UseFont = true;
            this.txtColumnName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtColumnName.Properties.ReadOnly = true;
            this.txtColumnName.Size = new System.Drawing.Size(168, 24);
            this.txtColumnName.TabIndex = 1;
            // 
            // lblColumnName
            // 
            this.lblColumnName.Location = new System.Drawing.Point(8, 16);
            this.lblColumnName.Name = "lblColumnName";
            this.lblColumnName.Size = new System.Drawing.Size(100, 24);
            this.lblColumnName.TabIndex = 0;
            this.lblColumnName.Text = "Spalte";
            // 
            // lblFieldCode
            // 
            this.lblFieldCode.Location = new System.Drawing.Point(8, 8);
            this.lblFieldCode.Name = "lblFieldCode";
            this.lblFieldCode.Size = new System.Drawing.Size(100, 24);
            this.lblFieldCode.TabIndex = 0;
            this.lblFieldCode.Text = "Feld";
            // 
            // txtDisplayText
            // 
            this.txtDisplayText.DataMember = "DisplayText";
            this.txtDisplayText.DataSource = this.qryXTableColumn;
            this.txtDisplayText.Location = new System.Drawing.Point(112, 48);
            this.txtDisplayText.Name = "txtDisplayText";
            this.txtDisplayText.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.txtDisplayText.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.txtDisplayText.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txtDisplayText.Properties.Appearance.Options.UseBackColor = true;
            this.txtDisplayText.Properties.Appearance.Options.UseBorderColor = true;
            this.txtDisplayText.Properties.Appearance.Options.UseFont = true;
            this.txtDisplayText.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtDisplayText.Size = new System.Drawing.Size(168, 24);
            this.txtDisplayText.TabIndex = 3;
            // 
            // lblDisplayText
            // 
            this.lblDisplayText.Location = new System.Drawing.Point(8, 48);
            this.lblDisplayText.Name = "lblDisplayText";
            this.lblDisplayText.Size = new System.Drawing.Size(100, 24);
            this.lblDisplayText.TabIndex = 2;
            this.lblDisplayText.Text = "Angezeigter Text";
            // 
            // lblPrimaryKey
            // 
            this.lblPrimaryKey.Location = new System.Drawing.Point(8, 80);
            this.lblPrimaryKey.Name = "lblPrimaryKey";
            this.lblPrimaryKey.Size = new System.Drawing.Size(100, 24);
            this.lblPrimaryKey.TabIndex = 4;
            this.lblPrimaryKey.Text = "Primärschlüssel";
            // 
            // lblHistory
            // 
            this.lblHistory.Location = new System.Drawing.Point(8, 144);
            this.lblHistory.Name = "lblHistory";
            this.lblHistory.Size = new System.Drawing.Size(100, 24);
            this.lblHistory.TabIndex = 8;
            this.lblHistory.Text = "Verlauf";
            // 
            // lblLOVName
            // 
            this.lblLOVName.Location = new System.Drawing.Point(8, 176);
            this.lblLOVName.Name = "lblLOVName";
            this.lblLOVName.Size = new System.Drawing.Size(100, 24);
            this.lblLOVName.TabIndex = 10;
            this.lblLOVName.Text = "Werteliste";
            // 
            // lblSystem
            // 
            this.lblSystem.Location = new System.Drawing.Point(8, 112);
            this.lblSystem.Name = "lblSystem";
            this.lblSystem.Size = new System.Drawing.Size(100, 24);
            this.lblSystem.TabIndex = 6;
            this.lblSystem.Text = "System";
            // 
            // chkHistory
            // 
            this.chkHistory.EditValue = false;
            this.chkHistory.Location = new System.Drawing.Point(112, 147);
            this.chkHistory.Name = "chkHistory";
            this.chkHistory.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkHistory.Properties.Appearance.Options.UseBackColor = true;
            this.chkHistory.Properties.Caption = "";
            this.chkHistory.Size = new System.Drawing.Size(24, 19);
            this.chkHistory.TabIndex = 9;
            this.chkHistory.CheckedChanged += new System.EventHandler(this.chkHistory_CheckedChanged);
            // 
            // chkSystem
            // 
            this.chkSystem.DataMember = "System";
            this.chkSystem.DataSource = this.qryXTableColumn;
            this.chkSystem.Location = new System.Drawing.Point(112, 115);
            this.chkSystem.Name = "chkSystem";
            this.chkSystem.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkSystem.Properties.Appearance.Options.UseBackColor = true;
            this.chkSystem.Properties.Caption = "";
            this.chkSystem.Size = new System.Drawing.Size(24, 19);
            this.chkSystem.TabIndex = 7;
            // 
            // chkPrimaryKey
            // 
            this.chkPrimaryKey.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.chkPrimaryKey.EditValue = false;
            this.chkPrimaryKey.Location = new System.Drawing.Point(112, 83);
            this.chkPrimaryKey.Name = "chkPrimaryKey";
            this.chkPrimaryKey.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkPrimaryKey.Properties.Appearance.Options.UseBackColor = true;
            this.chkPrimaryKey.Properties.Caption = "";
            this.chkPrimaryKey.Properties.ReadOnly = true;
            this.chkPrimaryKey.Size = new System.Drawing.Size(24, 19);
            this.chkPrimaryKey.TabIndex = 5;
            // 
            // cboFieldCode
            // 
            this.cboFieldCode.AllowNull = false;
            this.cboFieldCode.DataMember = "FieldCode";
            this.cboFieldCode.DataSource = this.qryXTableColumn;
            this.cboFieldCode.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.cboFieldCode.Location = new System.Drawing.Point(112, 8);
            this.cboFieldCode.LOVName = "FieldCode";
            this.cboFieldCode.Name = "cboFieldCode";
            this.cboFieldCode.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.cboFieldCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboFieldCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboFieldCode.Properties.Appearance.Options.UseBackColor = true;
            this.cboFieldCode.Properties.Appearance.Options.UseBorderColor = true;
            this.cboFieldCode.Properties.Appearance.Options.UseFont = true;
            this.cboFieldCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboFieldCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboFieldCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboFieldCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboFieldCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.cboFieldCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.cboFieldCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboFieldCode.Properties.NullText = "";
            this.cboFieldCode.Properties.ReadOnly = true;
            this.cboFieldCode.Properties.ShowFooter = false;
            this.cboFieldCode.Properties.ShowHeader = false;
            this.cboFieldCode.Size = new System.Drawing.Size(216, 24);
            this.cboFieldCode.TabIndex = 1;
            this.cboFieldCode.EditValueChanged += new System.EventHandler(this.cboFieldCode_EditValueChanged);
            // 
            // cboLOVName
            // 
            this.cboLOVName.DataMember = "LOVName";
            this.cboLOVName.DataSource = this.qryXTableColumn;
            this.cboLOVName.Location = new System.Drawing.Point(112, 175);
            this.cboLOVName.Name = "cboLOVName";
            this.cboLOVName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboLOVName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboLOVName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboLOVName.Properties.Appearance.Options.UseBackColor = true;
            this.cboLOVName.Properties.Appearance.Options.UseBorderColor = true;
            this.cboLOVName.Properties.Appearance.Options.UseFont = true;
            this.cboLOVName.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboLOVName.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboLOVName.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboLOVName.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboLOVName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.cboLOVName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.cboLOVName.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboLOVName.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.cboLOVName.Properties.DisplayMember = "Text";
            this.cboLOVName.Properties.NullText = "";
            this.cboLOVName.Properties.ShowFooter = false;
            this.cboLOVName.Properties.ShowHeader = false;
            this.cboLOVName.Properties.ValueMember = "Code";
            this.cboLOVName.Size = new System.Drawing.Size(168, 24);
            this.cboLOVName.TabIndex = 11;
            // 
            // kccContainer
            // 
            this.kccContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kccContainer.Controls.Add(this.kccSubContainer);
            this.kccContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kccContainer.Location = new System.Drawing.Point(0, 312);
            this.kccContainer.Name = "kccContainer";
            this.kccContainer.Size = new System.Drawing.Size(816, 264);
            this.kccContainer.TabIndex = 21;
            // 
            // kccSubContainer
            // 
            this.kccSubContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kccSubContainer.Controls.Add(this.pnDataType);
            this.kccSubContainer.Controls.Add(this.lblStatistics);
            this.kccSubContainer.Controls.Add(this.editComment);
            this.kccSubContainer.Controls.Add(this.lblComment);
            this.kccSubContainer.Controls.Add(this.chkHistory);
            this.kccSubContainer.Controls.Add(this.chkSystem);
            this.kccSubContainer.Controls.Add(this.chkPrimaryKey);
            this.kccSubContainer.Controls.Add(this.txtColumnName);
            this.kccSubContainer.Controls.Add(this.lblColumnName);
            this.kccSubContainer.Controls.Add(this.txtDisplayText);
            this.kccSubContainer.Controls.Add(this.lblDisplayText);
            this.kccSubContainer.Controls.Add(this.lblPrimaryKey);
            this.kccSubContainer.Controls.Add(this.lblHistory);
            this.kccSubContainer.Controls.Add(this.lblLOVName);
            this.kccSubContainer.Controls.Add(this.lblSystem);
            this.kccSubContainer.Controls.Add(this.cboLOVName);
            this.kccSubContainer.Controls.Add(this.lblAllowNull);
            this.kccSubContainer.Controls.Add(this.chkAllowNull);
            this.kccSubContainer.Controls.Add(this.lblDefaultValue);
            this.kccSubContainer.Controls.Add(this.chkSetDefaultValueAsNull);
            this.kccSubContainer.Controls.Add(this.txtDefaultValue);
            this.kccSubContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kccSubContainer.Location = new System.Drawing.Point(0, 0);
            this.kccSubContainer.Name = "kccSubContainer";
            this.kccSubContainer.Size = new System.Drawing.Size(816, 264);
            this.kccSubContainer.TabIndex = 0;
            // 
            // pnDataType
            // 
            this.pnDataType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.pnDataType.Controls.Add(this.cboFieldCode);
            this.pnDataType.Controls.Add(this.lblFieldCode);
            this.pnDataType.Controls.Add(this.txtSize);
            this.pnDataType.Controls.Add(this.lblSize);
            this.pnDataType.Location = new System.Drawing.Point(296, 8);
            this.pnDataType.Name = "pnDataType";
            this.pnDataType.Size = new System.Drawing.Size(336, 72);
            this.pnDataType.TabIndex = 12;
            // 
            // txtSize
            // 
            this.txtSize.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSize.Location = new System.Drawing.Point(112, 40);
            this.txtSize.Name = "txtSize";
            this.txtSize.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.txtSize.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.txtSize.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.txtSize.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txtSize.Properties.Appearance.Options.UseBackColor = true;
            this.txtSize.Properties.Appearance.Options.UseBorderColor = true;
            this.txtSize.Properties.Appearance.Options.UseFont = true;
            this.txtSize.Properties.Appearance.Options.UseTextOptions = true;
            this.txtSize.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtSize.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtSize.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.txtSize.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSize.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSize.Properties.Precision = 0;
            this.txtSize.Size = new System.Drawing.Size(216, 24);
            this.txtSize.TabIndex = 3;
            this.txtSize.TextChanged += new System.EventHandler(this.txtSize_TextChanged);
            // 
            // lblSize
            // 
            this.lblSize.Location = new System.Drawing.Point(8, 40);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(100, 24);
            this.lblSize.TabIndex = 2;
            this.lblSize.Text = "Länge";
            // 
            // lblStatistics
            // 
            this.lblStatistics.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatistics.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatistics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatistics.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblStatistics.Location = new System.Drawing.Point(0, 240);
            this.lblStatistics.Name = "lblStatistics";
            this.lblStatistics.Size = new System.Drawing.Size(816, 24);
            this.lblStatistics.TabIndex = 24;
            this.lblStatistics.Text = "Statistik:";
            this.lblStatistics.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // editComment
            // 
            this.editComment.DataMember = "Comment";
            this.editComment.DataSource = this.qryXTableColumn;
            this.editComment.Location = new System.Drawing.Point(408, 144);
            this.editComment.Name = "editComment";
            this.editComment.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editComment.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editComment.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editComment.Properties.Appearance.Options.UseBackColor = true;
            this.editComment.Properties.Appearance.Options.UseBorderColor = true;
            this.editComment.Properties.Appearance.Options.UseFont = true;
            this.editComment.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editComment.Size = new System.Drawing.Size(216, 56);
            this.editComment.TabIndex = 19;
            // 
            // lblComment
            // 
            this.lblComment.Location = new System.Drawing.Point(304, 144);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(96, 24);
            this.lblComment.TabIndex = 18;
            this.lblComment.Text = "Beschreibung";
            // 
            // lblAllowNull
            // 
            this.lblAllowNull.Location = new System.Drawing.Point(304, 80);
            this.lblAllowNull.Name = "lblAllowNull";
            this.lblAllowNull.Size = new System.Drawing.Size(100, 24);
            this.lblAllowNull.TabIndex = 13;
            this.lblAllowNull.Text = "NULL zulassen";
            // 
            // chkAllowNull
            // 
            this.chkAllowNull.EditValue = false;
            this.chkAllowNull.Location = new System.Drawing.Point(408, 83);
            this.chkAllowNull.Name = "chkAllowNull";
            this.chkAllowNull.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkAllowNull.Properties.Appearance.Options.UseBackColor = true;
            this.chkAllowNull.Properties.Caption = "";
            this.chkAllowNull.Size = new System.Drawing.Size(24, 19);
            this.chkAllowNull.TabIndex = 14;
            this.chkAllowNull.CheckedChanged += new System.EventHandler(this.chkAllowNull_CheckedChanged);
            // 
            // lblDefaultValue
            // 
            this.lblDefaultValue.Location = new System.Drawing.Point(304, 112);
            this.lblDefaultValue.Name = "lblDefaultValue";
            this.lblDefaultValue.Size = new System.Drawing.Size(100, 24);
            this.lblDefaultValue.TabIndex = 15;
            this.lblDefaultValue.Text = "Standardwert";
            // 
            // chkSetDefaultValueAsNull
            // 
            this.chkSetDefaultValueAsNull.EditValue = false;
            this.chkSetDefaultValueAsNull.Location = new System.Drawing.Point(576, 115);
            this.chkSetDefaultValueAsNull.Name = "chkSetDefaultValueAsNull";
            this.chkSetDefaultValueAsNull.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkSetDefaultValueAsNull.Properties.Appearance.Options.UseBackColor = true;
            this.chkSetDefaultValueAsNull.Properties.Caption = "NULL";
            this.chkSetDefaultValueAsNull.Size = new System.Drawing.Size(48, 19);
            this.chkSetDefaultValueAsNull.TabIndex = 17;
            this.chkSetDefaultValueAsNull.CheckedChanged += new System.EventHandler(this.chkSetDefaultValueAsNull_CheckedChanged);
            // 
            // txtDefaultValue
            // 
            this.txtDefaultValue.EditValue = "";
            this.txtDefaultValue.Location = new System.Drawing.Point(408, 112);
            this.txtDefaultValue.Name = "txtDefaultValue";
            this.txtDefaultValue.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.txtDefaultValue.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.txtDefaultValue.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txtDefaultValue.Properties.Appearance.Options.UseBackColor = true;
            this.txtDefaultValue.Properties.Appearance.Options.UseBorderColor = true;
            this.txtDefaultValue.Properties.Appearance.Options.UseFont = true;
            this.txtDefaultValue.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtDefaultValue.Size = new System.Drawing.Size(160, 24);
            this.txtDefaultValue.TabIndex = 16;
            this.txtDefaultValue.TextChanged += new System.EventHandler(this.txtDefaultValue_TextChanged);
            // 
            // lblDataRowCount
            // 
            this.lblDataRowCount.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblDataRowCount.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblDataRowCount.Location = new System.Drawing.Point(152, 24);
            this.lblDataRowCount.Name = "lblDataRowCount";
            this.lblDataRowCount.Size = new System.Drawing.Size(56, 24);
            this.lblDataRowCount.TabIndex = 2;
            this.lblDataRowCount.Text = "-";
            this.lblDataRowCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CtlTableColumnEditor
            // 
            this.Controls.Add(this.kccContainer);
            this.Name = "CtlTableColumnEditor";
            this.Size = new System.Drawing.Size(816, 576);
            this.Controls.SetChildIndex(this.kccContainer, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTableColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXTableColumn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSearchLOVName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSearchLOVName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSearchFieldCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSearchFieldCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSearchSystem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchSystem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchLOVName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchDisplayText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchDisplayText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchColumn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchColumn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchTable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtColumnName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblColumnName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFieldCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDisplayText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDisplayText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPrimaryKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLOVName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSystem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHistory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSystem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPrimaryKey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFieldCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFieldCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLOVName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLOVName)).EndInit();
            this.kccContainer.ResumeLayout(false);
            this.kccSubContainer.ResumeLayout(false);
            this.pnDataType.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatistics)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editComment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblComment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAllowNull)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllowNull.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDefaultValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSetDefaultValueAsNull.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDefaultValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDataRowCount)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Properties

        /// <summary>
        /// Property for name of current table to show
        /// </summary>
        private string _currentTableName = "";
        internal string CurrentTableName
        {
            get
            {
                return _currentTableName;
            }
            set
            {
                //apply
                _currentTableName = value;

                //init for new table
                InitTableColumnEditor();
            }
        }

        /// <summary>
        /// Name of the selected column
        /// </summary>
        public string CurrentColumnName { get; set; }

        /// <summary>
        /// Selected FieldCode
        /// </summary>
        public int CurrentFieldCode { get; set; }

        /// <summary>
        /// Current table history flag
        /// </summary>
        private bool HistoryPermitted { get; set; }

        /// <summary>
        /// Current table system flag
        /// </summary>
        private bool SystemPermitted { get; set; }

        /// <summary>
        /// Last RowState of the current row
        /// </summary>
        private DataRowState LastDataRowState { get; set; }

        #endregion

        #region public events

        /// <summary>
        /// The user wants to open the table editor
        /// </summary>
        public event EventHandler OpenTableEditor;

        #endregion

        #region Events

        private void qryXTableColumn_AfterInsert(object sender, EventArgs e)
        {
            // show container if hidden (no columns existing yet) and valid table selected
            if (IsValidTableSelected())
            {
                kccSubContainer.Visible = true;
            }
            else
            {
                kccSubContainer.Visible = false;
                throw new KissErrorException("Bitte wählen Sie zuerst eine gültige Tabelle aus, um eine neue Spalte hinzuzufügen.");
            }

            // reset current column name because of consistency
            CurrentColumnName = null;

            // setup default values and editmodes
            qryXTableColumn["TableName"] = CurrentTableName;
            qryXTableColumn["DisplayText"] = "";

            txtSize.Text = "0";
            txtDefaultValue.Text = "";

            chkPrimaryKey.Checked = false;
            chkHistory.Checked = HistoryPermitted;
            chkAllowNull.Checked = true;
            chkSetDefaultValueAsNull.Checked = true;

            txtColumnName.EditMode = EditModeType.Normal;
            cboFieldCode.EditMode = EditModeType.Normal;

            qryXTableColumn.EnableBoundFields();

            RefreshEnabledStates();
            ShowStatisticsForColumn(CurrentTableName, null);

            //set focus to first control
            txtColumnName.Focus();

            //change row modified state to unchanged per init
            qryXTableColumn.RowModified = false;
        }

        private void qryXTableColumn_PositionChanged(object sender, EventArgs e)
        {
            // apply columnname to property
            CurrentColumnName = qryXTableColumn["ColumnName"] as string;
            try
            {
                CurrentFieldCode = (int)qryXTableColumn["FieldCode"];
            }
            catch
            {
                CurrentFieldCode = -1;
            }

            // check if TableColumn is a primary key
            if (!string.IsNullOrEmpty(CurrentColumnName))
            {
                // read out settings from database and apply to controls
                chkPrimaryKey.Checked = XTableColumnDBHandler.IsPrimaryKeyColumn(CurrentTableName, CurrentColumnName);
                chkHistory.Checked = XTableColumnDBHandler.ExistsColumn(string.Format("Hist_{0}", CurrentTableName), CurrentColumnName);
                chkAllowNull.Checked = XTableColumnDBHandler.IsNullableColumn(CurrentTableName, CurrentColumnName);
                txtSize.Value = XTableColumnDBHandler.GetSizeOfColumnField(CurrentTableName, CurrentColumnName);

                //check if consistent
                if (CurrentFieldCode >= 0)
                {
                    if (XTableColumnDBHandler.IsPhysicalDataTypeConsistent(CurrentTableName, CurrentColumnName, CurrentFieldCode, false))
                    {
                        pnDataType.BackColor = Color.FromArgb(247, 239, 231);
                        _toolTip.RemoveAll();
                    }
                    else
                    {
                        pnDataType.BackColor = Color.FromArgb(255, 64, 64);
                        string message = KissMsg.GetMLMessage("CtlTableColumnEditor",
                                                              "InconsitentDataTypeInDatabaseColumnShort",
                                                              "Physikalischer Datentyp ({0}) entspricht nicht dem definierten Feldtyp",
                                                              KissMsgCode.Text,
                                                              XTableColumnDBHandler.GetPhysicalDataTypeOfColumnField(
                                                                  CurrentTableName, CurrentColumnName));
                        _toolTip.RemoveAll();
                        _toolTip.SetToolTip(pnDataType, message);
                        _toolTip.SetToolTip(lblFieldCode, message);
                        _toolTip.SetToolTip(lblSize, message);
                    }
                }

                // apply default value for current field
                ShowDefaultValue(true);
            }

            if (qryXTableColumn.Row != null && qryXTableColumn.Row.RowState != DataRowState.Added)
            {
                RefreshEnabledStates();
                ShowStatisticsForColumn(CurrentTableName, CurrentColumnName);

                txtColumnName.EditMode = EditModeType.ReadOnly;
                qryXTableColumn.EnableBoundFields();

                //change row modified state to unchanged per init
                qryXTableColumn.RowModified = false;
            }
        }

        private void cboFieldCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                // try to set fieldcode to property
                CurrentFieldCode = (int)cboFieldCode.EditValue;
            }
            catch
            {
                CurrentFieldCode = -1;
            }

            RefreshEnabledStates();
        }

        private void qryXTableColumn_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            ValidateInputControls();

            // set last datarowstate of current row
            LastDataRowState = qryXTableColumn.Row.RowState;

            if (LastDataRowState != DataRowState.Added)
            {
                // cannot delete primary-key columns
                if (XTableColumnDBHandler.IsPrimaryKeyColumn(CurrentTableName, qryXTableColumn["ColumnName"] as string))
                {
                    throw new KissErrorException("Spalten, die als Primärschlüssel definiert sind, dürfen nicht gelöscht werden.");
                }

                // cannot delete system columns
                if ((bool)qryXTableColumn["System"])
                {
                    throw new KissErrorException("Systemspalten dürfen nicht gelöscht werden.");
                }
            }
        }

        private void qryXTableColumn_AfterDelete(object sender, EventArgs e)
        {
            // check if not a new column
            if (LastDataRowState != DataRowState.Added)
            {
                // delete both columns if existing
                XTableColumnDBHandler.DeleteColumnWithHistory(CurrentTableName, qryXTableColumn["ColumnName"] as string);
            }
        }

        private void qryXTableColumn_BeforePost(object sender, EventArgs e)
        {
            ValidateInputControls();

            // validate inputs
            DBUtil.CheckNotNullField(txtColumnName, lblColumnName.Text);
            DBUtil.CheckNotNullField(cboFieldCode, lblFieldCode.Text);
            if (!chkAllowNull.Checked && !chkSetDefaultValueAsNull.Checked)
            {
                if (GetDefaultValue() == string.Empty)
                {
                    // Replace empty default string with N''
                    txtDefaultValue.Text = DBUtil.SqlLiteral(txtDefaultValue.EditValue);
                }
            }

            // check if NULL is not allowed anymore and if there are entries with value NULL
            int rowWithNullCount = 0;
            // if the column does not exist yet, the GetRowWithNULLCount method throws an exception
            try
            {
                rowWithNullCount = XTableColumnDBHandler.GetRowWithNULLCount(CurrentTableName, txtColumnName.Text);
            }
            catch { }

            if (!chkAllowNull.Checked && rowWithNullCount > 0)
            {
                throw new KissErrorException(KissMsg.GetMLMessage("XTableColumnDBHandler",
                                                                  "CannotApplyNotNullDueToNullEntires",
                                                                  "Die Spalte '{0}' enthält NULL-Einträge. Deshalb kann NOT NULL nicht angewendet werden.",
                                                                  KissMsgCode.MsgError, txtColumnName.Text));
            }

            // check if a valid datatype is selected
            XTableColumnDBHandler.GetDataType(CurrentFieldCode, 0);

            // set last datarowstate of current row
            LastDataRowState = qryXTableColumn.Row.RowState;

            // apply new columnname to property
            CurrentColumnName = txtColumnName.Text;



            // AfterPost Code, moved to BeforePost because AfterPost() doesn't perform a rollback if an exception occurs
            // check if row was added or modified by user
            if (LastDataRowState.Equals(DataRowState.Added))
            {
                // create columns
                var iSize = (int)txtSize.Value;

                if (HistoryPermitted && chkHistory.Checked)
                {
                    XTableColumnDBHandler.CreateColumnWithHistory(CurrentTableName, CurrentColumnName, CurrentFieldCode,
                                                                  iSize, chkAllowNull.Checked, GetDefaultValue(),
                                                                  chkSetDefaultValueAsNull.Checked);
                }
                else
                {
                    XTableColumnDBHandler.CreateColumn(CurrentTableName, CurrentColumnName, CurrentFieldCode, iSize,
                                                       chkAllowNull.Checked, GetDefaultValue(),
                                                       chkSetDefaultValueAsNull.Checked);
                }
            }
            else if (LastDataRowState.Equals(DataRowState.Modified))
            {
                // modify column
                // update history column depending on current settings
                if (HistoryPermitted)
                {
                    // add, modify or remove history column
                    if (chkHistory.Checked)
                    {
                        XTableColumnDBHandler.CreateColumn(string.Format("Hist_{0}", CurrentTableName),
                                                           CurrentColumnName, CurrentFieldCode, (int)txtSize.Value,
                                                           chkAllowNull.Checked, GetDefaultValue(),
                                                           chkSetDefaultValueAsNull.Checked);
                        XTableColumnDBHandler.ModifyColumnWithHistory(CurrentTableName, CurrentColumnName,
                                                                      CurrentFieldCode, (int)txtSize.Value,
                                                                      chkAllowNull.Checked, GetDefaultValue(),
                                                                      chkSetDefaultValueAsNull.Checked);
                    }
                    else
                    {
                        string historyTableName = string.Format("Hist_{0}", CurrentTableName);
                        if (XTableColumnDBHandler.ExistsColumn(historyTableName, CurrentColumnName))
                        {
                            // ask user if he really wants to delete the history column
                            bool deleteHistoryColumn = true;
                            try
                            {
                                if (XTableColumnDBHandler.GetRowCount(historyTableName) != XTableColumnDBHandler.GetRowWithNULLCount(historyTableName, CurrentColumnName))
                                {
                                    deleteHistoryColumn = KissMsg.ShowQuestion("CtlTableColumnEditor",
                                                                               "ConfirmDeleteHistoryColumn",
                                                                               string.Format(
                                                                                   "Wollen Sie wirklich die Verlauf-Spalte von '{0}' und die darin enthaltenen Daten löschen?",
                                                                                   CurrentColumnName), false);
                                }
                                if (deleteHistoryColumn)
                                {
                                    XTableColumnDBHandler.DeleteColumn(string.Format("Hist_{0}", CurrentTableName), CurrentColumnName);
                                }
                                else
                                {
                                    chkHistory.Checked = true;
                                }
                            }
                            catch (KissErrorException ex)
                            {
                                KissMsg.ShowError("CtlTableColumnEditor", "AfterPostRowCountFailed", "Beim Zählen der Anzahl Datensätze der Spalte '{0}' ist ein Fehler aufgetreten", null, ex, 0, 0, CurrentColumnName);
                            }
                        }
                        XTableColumnDBHandler.ModifyColumn(CurrentTableName, CurrentColumnName, CurrentFieldCode, (int)txtSize.Value, chkAllowNull.Checked, GetDefaultValue(), chkSetDefaultValueAsNull.Checked);
                    }
                }
                else
                {
                    // modify just the current column
                    XTableColumnDBHandler.ModifyColumn(CurrentTableName, CurrentColumnName, CurrentFieldCode, (int)txtSize.Value, chkAllowNull.Checked, GetDefaultValue(), chkSetDefaultValueAsNull.Checked);
                }
            }

            // update trigger if column is a history column
            if (HistoryPermitted && chkHistory.Checked)
            {
                DBUtil.ExecSQL(@"EXECUTE dbo.spXHistoryVersion {0}, 1", qryXTableColumn.Row["TableName"]);
            }
        }

        private void qryXTableColumn_AfterPost(object sender, EventArgs e)
        {
            // reset controls
            txtColumnName.EditMode = EditModeType.ReadOnly;
            cboFieldCode.EditMode = EditModeType.ReadOnly;
            qryXTableColumn.EnableBoundFields();
        }

        private void chkHistory_CheckedChanged(object sender, EventArgs e)
        {
            qryXTableColumn.RowModified = true;
        }

        private void chkAllowNull_CheckedChanged(object sender, EventArgs e)
        {
            qryXTableColumn.RowModified = true;

            // uncheck set as NULL if NULL is not allowed
            if (!chkAllowNull.Checked)
            {
                chkSetDefaultValueAsNull.Checked = false;
            }

            RefreshEnabledStates();
        }

        private void txtSize_TextChanged(object sender, EventArgs e)
        {
            qryXTableColumn.RowModified = true;
        }

        private void txtDefaultValue_TextChanged(object sender, EventArgs e)
        {
            qryXTableColumn.RowModified = true;
        }

        private void chkSetDefaultValueAsNull_CheckedChanged(object sender, EventArgs e)
        {
            qryXTableColumn.RowModified = true;
            RefreshEnabledStates();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Init control each time the table changes
        /// </summary>
        private void InitTableColumnEditor()
        {
            //init query
            qryXTableColumn.Fill("SELECT * FROM XTableColumn WHERE TableName = {0}", _currentTableName);

            //change row modified state to unchanged per init
            qryXTableColumn.RowModified = false;

            //init search textbox
            txtSearchTable.Text = _currentTableName;

            //check and set if current table has the history flag
            HistoryPermitted = CtlTableEditor.HasTableHistoryTable(_currentTableName);

            //check and set if current table has the system flag
            SystemPermitted = XTableColumnDBHandler.IsSystemTable(_currentTableName);

            //init new search in order to clear EditValue of controls
            NewSearch();

            //select first tab
            tabControlSearch.SelectedTabIndex = 0;

            RefreshEnabledStates();
        }

        /// <summary>
        /// Fill grid table depending on search criterias
        /// </summary>
        protected override void RunSearch()
        {
            string sqlStatement = string.Format(@"
                SELECT *
                FROM dbo.XTableColumn
                WHERE TableName = {0}", DBUtil.SqlLiteral(CurrentTableName));

            // TableColumn
            if (txtSearchColumn.Text != "")
            {
                sqlStatement += " AND ColumnName LIKE " + DBUtil.SqlLiteralLike("%" + txtSearchColumn.Text + "%");
            }

            // Field
            if (!DBUtil.IsEmpty(cboSearchFieldCode.EditValue))
            {
                sqlStatement += " and FieldCode = " + DBUtil.SqlLiteralLike(cboSearchFieldCode.EditValue);
            }

            // DisplayText
            if (txtSearchDisplayText.Text != "")
            {
                sqlStatement += " AND DisplayText LIKE " + DBUtil.SqlLiteralLike("%" + txtSearchDisplayText.Text + "%");
            }

            // LOVName
            if (!DBUtil.IsEmpty(cboSearchLOVName.EditValue))
            {
                sqlStatement += " AND LOVName = " + DBUtil.SqlLiteralLike(cboSearchLOVName.EditValue);
            }

            // System
            if (!DBUtil.IsEmpty(chkSearchSystem.EditValue))
            {
                sqlStatement += " AND System = " + DBUtil.SqlLiteralLike(chkSearchSystem.EditValue);
            }

            qryXTableColumn.Fill(sqlStatement);

            tabControlSearch.SelectedTabIndex = 0;
            gridTableColumns.Focus();
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Initialize a new search
        /// </summary>
        protected override void NewSearch()
        {
            base.NewSearch();

            // reapply search textbox
            txtSearchTable.Text = CurrentTableName;

            txtSearchColumn.Focus();
        }

        /// <summary>
        /// Get value from control for default value
        /// </summary>
        /// <returns>Entered default value string</returns>
        private string GetDefaultValue()
        {
            return txtDefaultValue.Text;
        }

        /// <summary>
        /// Set defined value to control for default value selected in cboFieldCode
        /// </summary>
        /// <param name="showExceptionMsgBox"></param>
        private void ShowDefaultValue(bool showExceptionMsgBox)
        {
            try
            {
                string defaultValue = XTableColumnDBHandler.GetDefaultValueOfColumnField(CurrentTableName, CurrentColumnName, true);
                chkSetDefaultValueAsNull.Checked = (defaultValue == null);

                // replace null with empty string
                if (defaultValue == null)
                {
                    defaultValue = "";
                }
                txtDefaultValue.Text = defaultValue;
            }

            catch (Exception ex)
            {
                if (showExceptionMsgBox)
                {
                    KissMsg.ShowError("CtlTableColumnEditor", "CouldNotSetDefaultValue", "Standardwert konnte nicht gesetzt werden", ex);
                }
            }
        }

        /// <summary>
        /// Handle editmode property for used controls
        /// </summary>
        private void RefreshEnabledStates()
        {
            // the 'varchar' data type is the only one (of the offered) which can change its size
            bool bIsPrimaryKey = false;
            bool bDataTypeHasSize = false;
            if (CurrentFieldCode >= 0)
            {
                try
                {
                    bDataTypeHasSize = XTableColumnDBHandler.HasDataTypeVariableLength(CurrentFieldCode);
                }
                catch (Exception)
                {
                    // could not determine data type
                    bDataTypeHasSize = false;
                }
            }
            try
            {
                var columnName = qryXTableColumn["ColumnName"] as string;
                if (columnName != null)
                {
                    // cannot be primary key if new row
                    if (qryXTableColumn.Row.RowState != DataRowState.Added)
                    {
                        bIsPrimaryKey = XTableColumnDBHandler.IsPrimaryKeyColumn(CurrentTableName, columnName);
                    }
                }
            }
            catch { }

            EditModeType mode = bIsPrimaryKey ? EditModeType.ReadOnly : EditModeType.Normal;
            EditModeType modeDefaultValues = bIsPrimaryKey || (chkSetDefaultValueAsNull.Checked && chkAllowNull.Checked) ? EditModeType.ReadOnly : EditModeType.Normal;
            EditModeType modeSystem = bIsPrimaryKey || !SystemPermitted ? EditModeType.ReadOnly : EditModeType.Normal;
            EditModeType modeSize = bIsPrimaryKey || !bDataTypeHasSize ? EditModeType.ReadOnly : EditModeType.Normal;

            // default setup
            txtSize.EditMode = modeSize;
            txtDisplayText.EditMode = mode;
            chkSystem.EditMode = modeSystem;
            txtSize.EditMode = modeSize;
            chkAllowNull.EditMode = mode;
            txtDefaultValue.EditMode = modeDefaultValues;
            cboLOVName.EditMode = mode;
            editComment.EditMode = mode;

            // special cases
            if (!bIsPrimaryKey)
            {
                bool bIsDataTypeChangeable = true;
                if (qryXTableColumn.Row != null && qryXTableColumn.Row.RowState != DataRowState.Added)
                {
                    bIsDataTypeChangeable = false;
                    if (CurrentFieldCode >= 0)
                    {
                        try
                        {
                            bIsDataTypeChangeable = XTableColumnDBHandler.IsDataTypeChangeable(CurrentFieldCode);
                        }
                        catch { }
                    }
                }

                chkHistory.EditMode = HistoryPermitted ? EditModeType.Normal : EditModeType.ReadOnly;
                chkSetDefaultValueAsNull.EditMode = chkAllowNull.Checked ? EditModeType.Normal : EditModeType.ReadOnly;
                chkAllowNull.EditMode = bIsDataTypeChangeable ? EditModeType.Normal : EditModeType.ReadOnly;
            }
            else
            {
                cboFieldCode.EditMode = EditModeType.ReadOnly;
                chkHistory.EditMode = EditModeType.ReadOnly;
                chkHistory.Checked = false;
                chkSetDefaultValueAsNull.EditMode = EditModeType.ReadOnly;
                chkSetDefaultValueAsNull.Checked = false;
            }
        }

        /// <summary>
        /// Validate input controls and apply current (changed) value
        /// </summary>
        private void ValidateInputControls()
        {
            txtColumnName.DoValidate();
            chkSystem.DoValidate();
            chkHistory.DoValidate();
            cboFieldCode.DoValidate();
            txtSize.DoValidate();
            chkAllowNull.DoValidate();
            cboLOVName.DoValidate();
            chkSetDefaultValueAsNull.DoValidate();
            editComment.DoValidate();

            // defaults
            txtDefaultValue.DoValidate();

            // do not allow decimal values --> round to 0 precision
            txtSize.Value = Math.Round(txtSize.Value, 0);
        }

        /// <summary>
        /// Update statistics for current table and column
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="columnName"></param>
        private void ShowStatisticsForColumn(string tableName, string columnName)
        {
            if (tableName != null && columnName != null)
            {
                string statistics = "";
                int dataRowCount = -1;
                int dataNullCount = -1;

                try
                {
                    dataRowCount = XTableColumnDBHandler.GetRowCount(tableName);
                }
                catch { }

                try
                {
                    dataNullCount = XTableColumnDBHandler.GetRowWithNULLCount(tableName, columnName);
                }
                catch { }

                statistics = string.Format("{0}: {1} = {2}",
                    KissMsg.GetMLMessage("CtlTableColumnEditor", "StatisticsTitle", "Statistik"),
                    KissMsg.GetMLMessage("CtlTableColumnEditor", "StatisticsRowCount", "Anzahl Datensätze in der Tabelle"),
                    dataRowCount > -1 ? dataRowCount.ToString() : "-"
                    );

                if (dataRowCount > 0)
                {
                    if (dataRowCount == dataNullCount)
                    {
                        statistics += string.Format(", {0}",
                                                    KissMsg.GetMLMessage("CtlTableColumnEditor",
                                                                         "StatisticsAllValuesNull",
                                                                         "alle Werte in der gewählten Spalte sind NULL"));
                    }
                    else if (dataNullCount == 0)
                    {
                        statistics += string.Format(", {0}",
                                                    KissMsg.GetMLMessage("CtlTableColumnEditor",
                                                                         "StatisticsNoValuesNull",
                                                                         "keine NULL-Einträge in der gewählten Spalte"));
                    }
                    else if (dataRowCount > 0)
                    {
                        statistics += string.Format(", {0} = {1}",
                            KissMsg.GetMLMessage("CtlTableColumnEditor", "StatisticsNULLEntries", "Anzahl NULL-Einträge in der gewählten Spalte"),
                            dataNullCount > -1 ? dataNullCount.ToString() : "-"
                            );
                    }
                }
                lblStatistics.Text = statistics;
            }
            else
            {
                lblStatistics.Text = "-";
            }
        }

        /// <summary>
        /// Check if current selected table is valid
        /// </summary>
        /// <returns>True if table is valid</returns>
        private bool IsValidTableSelected()
        {
            //validate table name
            return (CurrentTableName != null && !CurrentTableName.Equals(""));
        }

        #endregion

    }
}
