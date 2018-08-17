using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

using Kiss.Interfaces.UI;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.DesignerHost
{
    /// <summary>
    /// Summary description for CtlDesignerRule.
    /// </summary>
    public class CtlDesignerRule : KissSearchUserControl
    {
        #region Fields

        #region Internal Fields

        internal KiSS4.DB.SqlQuery qryXClassRule;

        #endregion

        #region Private Constant/Read-Only Fields

        private readonly SqlQuery _qryXClass;

        #endregion

        #region Private Fields

        private KiSS4.Gui.KissButton btnBuild;
        private KissButton btnCopyRule;
        private KissButton btnExportCS;
        private KissButton btnImportCS;
        private KissButton btnPasteRule;
        private DevExpress.XtraGrid.Columns.GridColumn colActive;
        private DevExpress.XtraGrid.Columns.GridColumn colComponentName;
        private DevExpress.XtraGrid.Columns.GridColumn colControlName;
        private DevExpress.XtraGrid.Columns.GridColumn colRuleCode;
        private DevExpress.XtraGrid.Columns.GridColumn colRuleName;
        private DevExpress.XtraGrid.Columns.GridColumn colSortKey;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissCheckEdit edtActive;
        private KiSS4.Gui.KissLookUpEdit edtComponent;
        private KiSS4.Gui.KissLookUpEdit edtControl;
        private TextEditorControl edtCsCode;
        private KiSS4.Gui.KissLookUpEdit edtRuleCode;
        private KiSS4.Gui.KissMemoEdit edtRuleDescription;
        private KiSS4.Gui.KissButtonEdit edtRuleName;
        private KiSS4.Gui.KissCalcEdit edtSortKey;
        private KissTextEdit edtSucheComponentName;
        private KissTextEdit edtSucheCsCode;
        private KissLookUpEdit edtSucheRuleCode;
        private KissTextEdit edtSucheRuleName;
        private KiSS4.Gui.KissGrid grdXClassRule;
        private DevExpress.XtraGrid.Views.Grid.GridView grvXClassRule;
        private KiSS4.Gui.KissLabel lblComponent;
        private KiSS4.Gui.KissLabel lblControl;
        private KiSS4.Gui.KissLabel lblCsCode;
        private KiSS4.Gui.KissLabel lblRuleCode;
        private KiSS4.Gui.KissLabel lblRuleDescription;
        private KiSS4.Gui.KissLabel lblRuleName;
        private KiSS4.Gui.KissLabel lblSortKey;
        private KissLabel lblSucheComponentName;
        private KissLabel lblSucheCsCode;
        private KissLabel lblSucheRuleCode;
        private KissLabel lblSucheRuleName;
        private System.Windows.Forms.Panel panControls;
        private Panel panCopyPaste;
        private SqlQuery qryXRule;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repItemCheckAktiv;
        private KissSplitterCollapsible splitter;

        #endregion

        #endregion

        #region Constructors

        public CtlDesignerRule()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            colRuleCode.ColumnEdit = grdXClassRule.GetLOVLookUpEdit((SqlQuery)edtRuleCode.Properties.DataSource);
        }

        public CtlDesignerRule(SqlQuery qryXClass, SqlQuery qryXClassControl, SqlQuery qryXClassComponent)
            : this()
        {
            _qryXClass = qryXClass;
            _qryXClass.AfterFill += qryXClass_AfterFill;

            kissSearch.SelectStatement = MyCodeDomDesignerLoader.SQLqryXClassRule.Replace("WHERE CLR.ClassName = {0}", @"WHERE CLR.ClassName = {0}
                ---  AND (CLR.ControlName LIKE {edtSucheComponentName} + '%' OR CLR.ComponentName LIKE {edtSucheComponentName} + '%')
                ---  AND RUL.RuleName LIKE {edtSucheRuleName} + '%'
                ---  AND RUL.RuleCode = {edtSucheRuleCode}
                ---  AND RUL.CsCode LIKE '%' + {edtSucheCsCode} + '%'");

            qryXClass_AfterFill(this, EventArgs.Empty);

            edtControl.Properties.DataSource = qryXClassControl;
            edtComponent.Properties.DataSource = qryXClassComponent;
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlDesignerRule));
            ICSharpCode.TextEditor.Document.DefaultTextEditorProperties defaultTextEditorProperties1 = new ICSharpCode.TextEditor.Document.DefaultTextEditorProperties();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdXClassRule = new KiSS4.Gui.KissGrid();
            this.qryXClassRule = new KiSS4.DB.SqlQuery(this.components);
            this.grvXClassRule = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colControlName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComponentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRuleCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRuleName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSortKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repItemCheckAktiv = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.lblControl = new KiSS4.Gui.KissLabel();
            this.lblComponent = new KiSS4.Gui.KissLabel();
            this.lblCsCode = new KiSS4.Gui.KissLabel();
            this.edtControl = new KiSS4.Gui.KissLookUpEdit();
            this.edtComponent = new KiSS4.Gui.KissLookUpEdit();
            this.edtRuleCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtCsCode = new KiSS4.DesignerHost.TextEditorControl();
            this.lblRuleName = new KiSS4.Gui.KissLabel();
            this.lblRuleCode = new KiSS4.Gui.KissLabel();
            this.edtRuleName = new KiSS4.Gui.KissButtonEdit();
            this.lblRuleDescription = new KiSS4.Gui.KissLabel();
            this.edtRuleDescription = new KiSS4.Gui.KissMemoEdit();
            this.lblSortKey = new KiSS4.Gui.KissLabel();
            this.edtSortKey = new KiSS4.Gui.KissCalcEdit();
            this.edtActive = new KiSS4.Gui.KissCheckEdit();
            this.btnBuild = new KiSS4.Gui.KissButton();
            this.splitter = new KiSS4.Gui.KissSplitterCollapsible();
            this.panControls = new System.Windows.Forms.Panel();
            this.btnExportCS = new KiSS4.Gui.KissButton();
            this.btnImportCS = new KiSS4.Gui.KissButton();
            this.qryXRule = new KiSS4.DB.SqlQuery(this.components);
            this.edtSucheRuleCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheRuleCode = new KiSS4.Gui.KissLabel();
            this.lblSucheRuleName = new KiSS4.Gui.KissLabel();
            this.edtSucheRuleName = new KiSS4.Gui.KissTextEdit();
            this.edtSucheCsCode = new KiSS4.Gui.KissTextEdit();
            this.lblSucheCsCode = new KiSS4.Gui.KissLabel();
            this.edtSucheComponentName = new KiSS4.Gui.KissTextEdit();
            this.lblSucheComponentName = new KiSS4.Gui.KissLabel();
            this.panCopyPaste = new System.Windows.Forms.Panel();
            this.btnPasteRule = new KiSS4.Gui.KissButton();
            this.btnCopyRule = new KiSS4.Gui.KissButton();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdXClassRule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXClassRule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvXClassRule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemCheckAktiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblComponent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtComponent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtComponent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRuleCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRuleCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRuleName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRuleCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRuleName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRuleDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRuleDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSortKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSortKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtActive.Properties)).BeginInit();
            this.panControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryXRule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheRuleCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheRuleCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheRuleCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheRuleName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheRuleName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheCsCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheCsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheComponentName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheComponentName)).BeginInit();
            this.panCopyPaste.SuspendLayout();
            this.SuspendLayout();
            //
            // searchTitle
            //
            this.searchTitle.Size = new System.Drawing.Size(1013, 24);
            //
            // tabControlSearch
            //
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 0);
            this.tabControlSearch.Size = new System.Drawing.Size(1037, 216);
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.grdXClassRule);
            this.tpgListe.Controls.Add(this.panCopyPaste);
            this.tpgListe.Size = new System.Drawing.Size(1025, 178);
            this.tpgListe.Title = "Liste";
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.edtSucheComponentName);
            this.tpgSuchen.Controls.Add(this.lblSucheComponentName);
            this.tpgSuchen.Controls.Add(this.edtSucheCsCode);
            this.tpgSuchen.Controls.Add(this.lblSucheCsCode);
            this.tpgSuchen.Controls.Add(this.edtSucheRuleName);
            this.tpgSuchen.Controls.Add(this.lblSucheRuleName);
            this.tpgSuchen.Controls.Add(this.lblSucheRuleCode);
            this.tpgSuchen.Controls.Add(this.edtSucheRuleCode);
            this.tpgSuchen.Size = new System.Drawing.Size(1025, 178);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheRuleCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheRuleCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheRuleName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheRuleName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheCsCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheCsCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheComponentName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheComponentName, 0);
            //
            // grdXClassRule
            //
            this.grdXClassRule.DataSource = this.qryXClassRule;
            this.grdXClassRule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdXClassRule.EmbeddedNavigator.Name = "";
            this.grdXClassRule.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdXClassRule.Location = new System.Drawing.Point(0, 0);
            this.grdXClassRule.MainView = this.grvXClassRule;
            this.grdXClassRule.Name = "grdXClassRule";
            this.grdXClassRule.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repItemCheckAktiv});
            this.grdXClassRule.Size = new System.Drawing.Size(995, 178);
            this.grdXClassRule.TabIndex = 0;
            this.grdXClassRule.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvXClassRule});
            //
            // qryXClassRule
            //
            this.qryXClassRule.CanDelete = true;
            this.qryXClassRule.CanInsert = true;
            this.qryXClassRule.CanUpdate = true;
            this.qryXClassRule.HostControl = this;
            this.qryXClassRule.TableName = "XClassRule";
            this.qryXClassRule.BeforePost += new System.EventHandler(this.qryXClassRule_BeforePost);
            this.qryXClassRule.PositionChanged += new System.EventHandler(this.qryXClassRule_PositionChanged);
            this.qryXClassRule.AfterInsert += new System.EventHandler(this.qryXClassRule_AfterInsert);
            //
            // grvXClassRule
            //
            this.grvXClassRule.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvXClassRule.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXClassRule.Appearance.Empty.Options.UseBackColor = true;
            this.grvXClassRule.Appearance.Empty.Options.UseFont = true;
            this.grvXClassRule.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXClassRule.Appearance.EvenRow.Options.UseFont = true;
            this.grvXClassRule.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvXClassRule.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXClassRule.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvXClassRule.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvXClassRule.Appearance.FocusedCell.Options.UseFont = true;
            this.grvXClassRule.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvXClassRule.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvXClassRule.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXClassRule.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvXClassRule.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvXClassRule.Appearance.FocusedRow.Options.UseFont = true;
            this.grvXClassRule.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvXClassRule.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvXClassRule.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvXClassRule.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvXClassRule.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvXClassRule.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvXClassRule.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvXClassRule.Appearance.GroupRow.Options.UseFont = true;
            this.grvXClassRule.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvXClassRule.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvXClassRule.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvXClassRule.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvXClassRule.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvXClassRule.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvXClassRule.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvXClassRule.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvXClassRule.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXClassRule.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvXClassRule.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvXClassRule.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvXClassRule.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvXClassRule.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvXClassRule.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvXClassRule.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXClassRule.Appearance.OddRow.Options.UseFont = true;
            this.grvXClassRule.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvXClassRule.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXClassRule.Appearance.Row.Options.UseBackColor = true;
            this.grvXClassRule.Appearance.Row.Options.UseFont = true;
            this.grvXClassRule.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXClassRule.Appearance.SelectedRow.Options.UseFont = true;
            this.grvXClassRule.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvXClassRule.Appearance.VertLine.Options.UseBackColor = true;
            this.grvXClassRule.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvXClassRule.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colControlName,
            this.colComponentName,
            this.colRuleCode,
            this.colRuleName,
            this.colSortKey,
            this.colActive});
            this.grvXClassRule.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvXClassRule.GridControl = this.grdXClassRule;
            this.grvXClassRule.Name = "grvXClassRule";
            this.grvXClassRule.OptionsBehavior.Editable = false;
            this.grvXClassRule.OptionsCustomization.AllowFilter = false;
            this.grvXClassRule.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvXClassRule.OptionsNavigation.AutoFocusNewRow = true;
            this.grvXClassRule.OptionsNavigation.UseTabKey = false;
            this.grvXClassRule.OptionsView.ColumnAutoWidth = false;
            this.grvXClassRule.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvXClassRule.OptionsView.ShowGroupPanel = false;
            this.grvXClassRule.OptionsView.ShowIndicator = false;
            //
            // colControlName
            //
            this.colControlName.Caption = "Control";
            this.colControlName.FieldName = "ControlName";
            this.colControlName.Name = "colControlName";
            this.colControlName.Visible = true;
            this.colControlName.VisibleIndex = 0;
            this.colControlName.Width = 172;
            //
            // colComponentName
            //
            this.colComponentName.Caption = "Component";
            this.colComponentName.FieldName = "ComponentName";
            this.colComponentName.Name = "colComponentName";
            this.colComponentName.Visible = true;
            this.colComponentName.VisibleIndex = 1;
            this.colComponentName.Width = 172;
            //
            // colRuleCode
            //
            this.colRuleCode.Caption = "Rule";
            this.colRuleCode.FieldName = "RuleCode";
            this.colRuleCode.Name = "colRuleCode";
            this.colRuleCode.Visible = true;
            this.colRuleCode.VisibleIndex = 2;
            this.colRuleCode.Width = 172;
            //
            // colRuleName
            //
            this.colRuleName.Caption = "Name";
            this.colRuleName.FieldName = "RuleName";
            this.colRuleName.Name = "colRuleName";
            this.colRuleName.Visible = true;
            this.colRuleName.VisibleIndex = 3;
            this.colRuleName.Width = 280;
            //
            // colSortKey
            //
            this.colSortKey.Caption = "Sortierung";
            this.colSortKey.FieldName = "SortKey";
            this.colSortKey.Name = "colSortKey";
            this.colSortKey.Visible = true;
            this.colSortKey.VisibleIndex = 4;
            this.colSortKey.Width = 70;
            //
            // colActive
            //
            this.colActive.Caption = "Aktiv";
            this.colActive.ColumnEdit = this.repItemCheckAktiv;
            this.colActive.FieldName = "Active";
            this.colActive.Name = "colActive";
            this.colActive.Visible = true;
            this.colActive.VisibleIndex = 5;
            this.colActive.Width = 41;
            //
            // repItemCheckAktiv
            //
            this.repItemCheckAktiv.AutoHeight = false;
            this.repItemCheckAktiv.Name = "repItemCheckAktiv";
            //
            // lblControl
            //
            this.lblControl.Location = new System.Drawing.Point(5, 11);
            this.lblControl.Name = "lblControl";
            this.lblControl.Size = new System.Drawing.Size(100, 23);
            this.lblControl.TabIndex = 0;
            this.lblControl.Text = "Control";
            //
            // lblComponent
            //
            this.lblComponent.Location = new System.Drawing.Point(5, 36);
            this.lblComponent.Name = "lblComponent";
            this.lblComponent.Size = new System.Drawing.Size(100, 23);
            this.lblComponent.TabIndex = 2;
            this.lblComponent.Text = "Component";
            //
            // lblCsCode
            //
            this.lblCsCode.Location = new System.Drawing.Point(5, 194);
            this.lblCsCode.Name = "lblCsCode";
            this.lblCsCode.Size = new System.Drawing.Size(100, 23);
            this.lblCsCode.TabIndex = 10;
            this.lblCsCode.Text = "Rule";
            //
            // edtControl
            //
            this.edtControl.DataMember = "ControlName";
            this.edtControl.DataSource = this.qryXClassRule;
            this.edtControl.Location = new System.Drawing.Point(109, 11);
            this.edtControl.Name = "edtControl";
            this.edtControl.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtControl.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtControl.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtControl.Properties.Appearance.Options.UseBackColor = true;
            this.edtControl.Properties.Appearance.Options.UseBorderColor = true;
            this.edtControl.Properties.Appearance.Options.UseFont = true;
            this.edtControl.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtControl.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtControl.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtControl.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtControl.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtControl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtControl.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtControl.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ControlName"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TypeName")});
            this.edtControl.Properties.DisplayMember = "ControlName";
            this.edtControl.Properties.NullText = "";
            this.edtControl.Properties.ShowFooter = false;
            this.edtControl.Properties.ShowHeader = false;
            this.edtControl.Properties.ValueMember = "ControlName";
            this.edtControl.Size = new System.Drawing.Size(350, 24);
            this.edtControl.TabIndex = 1;
            this.edtControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtControl_KeyDown);
            //
            // edtComponent
            //
            this.edtComponent.DataMember = "ComponentName";
            this.edtComponent.DataSource = this.qryXClassRule;
            this.edtComponent.Location = new System.Drawing.Point(109, 36);
            this.edtComponent.Name = "edtComponent";
            this.edtComponent.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtComponent.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtComponent.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtComponent.Properties.Appearance.Options.UseBackColor = true;
            this.edtComponent.Properties.Appearance.Options.UseBorderColor = true;
            this.edtComponent.Properties.Appearance.Options.UseFont = true;
            this.edtComponent.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtComponent.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtComponent.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtComponent.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtComponent.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtComponent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtComponent.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtComponent.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ComponentName"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TypeName")});
            this.edtComponent.Properties.DisplayMember = "ComponentName";
            this.edtComponent.Properties.NullText = "";
            this.edtComponent.Properties.ShowFooter = false;
            this.edtComponent.Properties.ShowHeader = false;
            this.edtComponent.Properties.ValueMember = "ComponentName";
            this.edtComponent.Size = new System.Drawing.Size(350, 24);
            this.edtComponent.TabIndex = 3;
            this.edtComponent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtComponent_KeyDown);
            //
            // edtRuleCode
            //
            this.edtRuleCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtRuleCode.DataMember = "RuleCode";
            this.edtRuleCode.DataSource = this.qryXClassRule;
            this.edtRuleCode.Location = new System.Drawing.Point(109, 171);
            this.edtRuleCode.LOVName = "Rule";
            this.edtRuleCode.Name = "edtRuleCode";
            this.edtRuleCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtRuleCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtRuleCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtRuleCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtRuleCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtRuleCode.Properties.Appearance.Options.UseFont = true;
            this.edtRuleCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtRuleCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtRuleCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtRuleCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtRuleCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtRuleCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtRuleCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtRuleCode.Properties.NullText = "";
            this.edtRuleCode.Properties.ShowFooter = false;
            this.edtRuleCode.Properties.ShowHeader = false;
            this.edtRuleCode.Size = new System.Drawing.Size(919, 24);
            this.edtRuleCode.TabIndex = 9;
            //
            // edtCsCode
            //
            this.edtCsCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtCsCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edtCsCode.DataMember = "csCode";
            this.edtCsCode.DataSource = this.qryXClassRule;
            this.edtCsCode.Encoding = ((System.Text.Encoding)(resources.GetObject("edtCsCode.Encoding")));
            this.edtCsCode.IsIconBarVisible = false;
            this.edtCsCode.Location = new System.Drawing.Point(109, 199);
            this.edtCsCode.Name = "edtCsCode";
            this.edtCsCode.ShowEOLMarkers = true;
            this.edtCsCode.ShowSpaces = true;
            this.edtCsCode.ShowTabs = true;
            this.edtCsCode.Size = new System.Drawing.Size(919, 166);
            this.edtCsCode.TabIndex = 11;
            this.edtCsCode.TabStop = false;
            defaultTextEditorProperties1.AllowCaretBeyondEOL = false;
            defaultTextEditorProperties1.AutoInsertCurlyBracket = true;
            defaultTextEditorProperties1.BracketMatchingStyle = ICSharpCode.TextEditor.Document.BracketMatchingStyle.After;
            defaultTextEditorProperties1.ConvertTabsToSpaces = false;
            defaultTextEditorProperties1.CreateBackupCopy = false;
            defaultTextEditorProperties1.DocumentSelectionMode = ICSharpCode.TextEditor.Document.DocumentSelectionMode.Normal;
            defaultTextEditorProperties1.EnableFolding = true;
            defaultTextEditorProperties1.Encoding = ((System.Text.Encoding)(resources.GetObject("defaultTextEditorProperties1.Encoding")));
            defaultTextEditorProperties1.Font = new System.Drawing.Font("Courier New", 10F);
            defaultTextEditorProperties1.HideMouseCursor = false;
            defaultTextEditorProperties1.IndentStyle = ICSharpCode.TextEditor.Document.IndentStyle.Smart;
            defaultTextEditorProperties1.IsIconBarVisible = false;
            defaultTextEditorProperties1.LineTerminator = "\r\n";
            defaultTextEditorProperties1.LineViewerStyle = ICSharpCode.TextEditor.Document.LineViewerStyle.None;
            defaultTextEditorProperties1.MouseWheelScrollDown = true;
            defaultTextEditorProperties1.MouseWheelTextZoom = true;
            defaultTextEditorProperties1.ShowEOLMarker = true;
            defaultTextEditorProperties1.ShowHorizontalRuler = false;
            defaultTextEditorProperties1.ShowInvalidLines = true;
            defaultTextEditorProperties1.ShowLineNumbers = true;
            defaultTextEditorProperties1.ShowMatchingBracket = true;
            defaultTextEditorProperties1.ShowSpaces = true;
            defaultTextEditorProperties1.ShowTabs = true;
            defaultTextEditorProperties1.ShowVerticalRuler = false;
            defaultTextEditorProperties1.TabIndent = 4;
            defaultTextEditorProperties1.UseAntiAliasedFont = false;
            defaultTextEditorProperties1.UseCustomLine = false;
            defaultTextEditorProperties1.VerticalRulerRow = 80;
            this.edtCsCode.TextEditorProperties = defaultTextEditorProperties1;
            //
            // lblRuleName
            //
            this.lblRuleName.Location = new System.Drawing.Point(5, 61);
            this.lblRuleName.Name = "lblRuleName";
            this.lblRuleName.Size = new System.Drawing.Size(100, 23);
            this.lblRuleName.TabIndex = 4;
            this.lblRuleName.Text = "Name";
            //
            // lblRuleCode
            //
            this.lblRuleCode.Location = new System.Drawing.Point(5, 171);
            this.lblRuleCode.Name = "lblRuleCode";
            this.lblRuleCode.Size = new System.Drawing.Size(100, 23);
            this.lblRuleCode.TabIndex = 8;
            this.lblRuleCode.Text = "Rule Typ";
            //
            // edtRuleName
            //
            this.edtRuleName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtRuleName.DataMember = "RuleName";
            this.edtRuleName.DataSource = this.qryXClassRule;
            this.edtRuleName.Location = new System.Drawing.Point(109, 61);
            this.edtRuleName.Name = "edtRuleName";
            this.edtRuleName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtRuleName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtRuleName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtRuleName.Properties.Appearance.Options.UseBackColor = true;
            this.edtRuleName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtRuleName.Properties.Appearance.Options.UseFont = true;
            this.edtRuleName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtRuleName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtRuleName.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtRuleName.Size = new System.Drawing.Size(919, 24);
            this.edtRuleName.TabIndex = 5;
            this.edtRuleName.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtRuleName_UserModifiedFld);
            //
            // lblRuleDescription
            //
            this.lblRuleDescription.Location = new System.Drawing.Point(5, 86);
            this.lblRuleDescription.Name = "lblRuleDescription";
            this.lblRuleDescription.Size = new System.Drawing.Size(100, 23);
            this.lblRuleDescription.TabIndex = 6;
            this.lblRuleDescription.Text = "Beschreibung";
            //
            // edtRuleDescription
            //
            this.edtRuleDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtRuleDescription.DataMember = "RuleDescription";
            this.edtRuleDescription.DataSource = this.qryXClassRule;
            this.edtRuleDescription.Location = new System.Drawing.Point(109, 86);
            this.edtRuleDescription.Name = "edtRuleDescription";
            this.edtRuleDescription.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtRuleDescription.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtRuleDescription.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtRuleDescription.Properties.Appearance.Options.UseBackColor = true;
            this.edtRuleDescription.Properties.Appearance.Options.UseBorderColor = true;
            this.edtRuleDescription.Properties.Appearance.Options.UseFont = true;
            this.edtRuleDescription.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtRuleDescription.Size = new System.Drawing.Size(919, 78);
            this.edtRuleDescription.TabIndex = 7;
            //
            // lblSortKey
            //
            this.lblSortKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSortKey.Location = new System.Drawing.Point(850, 10);
            this.lblSortKey.Name = "lblSortKey";
            this.lblSortKey.Size = new System.Drawing.Size(62, 24);
            this.lblSortKey.TabIndex = 12;
            this.lblSortKey.Text = "Sortierung";
            //
            // edtSortKey
            //
            this.edtSortKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtSortKey.DataMember = "SortKey";
            this.edtSortKey.DataSource = this.qryXClassRule;
            this.edtSortKey.Location = new System.Drawing.Point(918, 10);
            this.edtSortKey.Name = "edtSortKey";
            this.edtSortKey.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSortKey.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSortKey.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSortKey.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSortKey.Properties.Appearance.Options.UseBackColor = true;
            this.edtSortKey.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSortKey.Properties.Appearance.Options.UseFont = true;
            this.edtSortKey.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSortKey.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSortKey.Size = new System.Drawing.Size(110, 24);
            this.edtSortKey.TabIndex = 13;
            //
            // edtActive
            //
            this.edtActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtActive.DataMember = "Active";
            this.edtActive.DataSource = this.qryXClassRule;
            this.edtActive.Location = new System.Drawing.Point(847, 36);
            this.edtActive.Name = "edtActive";
            this.edtActive.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtActive.Properties.Appearance.Options.UseBackColor = true;
            this.edtActive.Properties.Caption = "Aktiv";
            this.edtActive.Size = new System.Drawing.Size(65, 19);
            this.edtActive.TabIndex = 14;
            //
            // btnBuild
            //
            this.btnBuild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuild.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuild.Image = global::KiSS4.DesignerHost.Properties.Resources.Build;
            this.btnBuild.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuild.Location = new System.Drawing.Point(918, 35);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(110, 24);
            this.btnBuild.TabIndex = 15;
            this.btnBuild.Text = "Build";
            this.btnBuild.UseVisualStyleBackColor = false;
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            //
            // splitter
            //
            this.splitter.AnimationDelay = 20;
            this.splitter.AnimationStep = 20;
            this.splitter.BorderStyle3D = System.Windows.Forms.Border3DStyle.Etched;
            this.splitter.ControlToHide = this.tabControlSearch;
            this.splitter.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter.ExpandParentForm = false;
            this.splitter.Location = new System.Drawing.Point(0, 216);
            this.splitter.Name = "splitter";
            this.splitter.TabIndex = 17;
            this.splitter.TabStop = false;
            this.splitter.UseAnimations = false;
            this.splitter.VisualStyle = KiSS4.Gui.VisualStyles.Mozilla;
            //
            // panControls
            //
            this.panControls.Controls.Add(this.edtControl);
            this.panControls.Controls.Add(this.edtComponent);
            this.panControls.Controls.Add(this.btnBuild);
            this.panControls.Controls.Add(this.edtActive);
            this.panControls.Controls.Add(this.edtSortKey);
            this.panControls.Controls.Add(this.lblSortKey);
            this.panControls.Controls.Add(this.lblControl);
            this.panControls.Controls.Add(this.lblComponent);
            this.panControls.Controls.Add(this.lblCsCode);
            this.panControls.Controls.Add(this.edtRuleCode);
            this.panControls.Controls.Add(this.edtRuleDescription);
            this.panControls.Controls.Add(this.edtCsCode);
            this.panControls.Controls.Add(this.lblRuleDescription);
            this.panControls.Controls.Add(this.lblRuleName);
            this.panControls.Controls.Add(this.edtRuleName);
            this.panControls.Controls.Add(this.lblRuleCode);
            this.panControls.Controls.Add(this.btnExportCS);
            this.panControls.Controls.Add(this.btnImportCS);
            this.panControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panControls.Location = new System.Drawing.Point(0, 224);
            this.panControls.Name = "panControls";
            this.panControls.Size = new System.Drawing.Size(1037, 368);
            this.panControls.TabIndex = 18;
            //
            // btnExportCS
            //
            this.btnExportCS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportCS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportCS.Location = new System.Drawing.Point(676, 35);
            this.btnExportCS.Name = "btnExportCS";
            this.btnExportCS.Size = new System.Drawing.Size(110, 24);
            this.btnExportCS.TabIndex = 17;
            this.btnExportCS.Text = "Export CS-Datei";
            this.btnExportCS.UseVisualStyleBackColor = false;
            this.btnExportCS.Click += new System.EventHandler(this.btnExportCS_Click);
            //
            // btnImportCS
            //
            this.btnImportCS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportCS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportCS.Location = new System.Drawing.Point(676, 10);
            this.btnImportCS.Name = "btnImportCS";
            this.btnImportCS.Size = new System.Drawing.Size(110, 24);
            this.btnImportCS.TabIndex = 16;
            this.btnImportCS.Text = "Import CS-Datei";
            this.btnImportCS.UseVisualStyleBackColor = false;
            this.btnImportCS.Click += new System.EventHandler(this.btnImportCS_Click);
            //
            // qryXRule
            //
            this.qryXRule.AutoApplyUserRights = false;
            this.qryXRule.CanInsert = true;
            this.qryXRule.CanUpdate = true;
            this.qryXRule.SelectStatement = "SELECT * FROM XRule WHERE XRuleID = {0}";
            this.qryXRule.TableName = "XRule";
            //
            // edtSucheRuleCode
            //
            this.edtSucheRuleCode.Location = new System.Drawing.Point(127, 96);
            this.edtSucheRuleCode.LOVName = "Rule";
            this.edtSucheRuleCode.Name = "edtSucheRuleCode";
            this.edtSucheRuleCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheRuleCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheRuleCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheRuleCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheRuleCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheRuleCode.Properties.Appearance.Options.UseFont = true;
            this.edtSucheRuleCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheRuleCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheRuleCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheRuleCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheRuleCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtSucheRuleCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtSucheRuleCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheRuleCode.Properties.NullText = "";
            this.edtSucheRuleCode.Properties.ShowFooter = false;
            this.edtSucheRuleCode.Properties.ShowHeader = false;
            this.edtSucheRuleCode.Size = new System.Drawing.Size(350, 24);
            this.edtSucheRuleCode.TabIndex = 6;
            //
            // lblSucheRuleCode
            //
            this.lblSucheRuleCode.Location = new System.Drawing.Point(5, 96);
            this.lblSucheRuleCode.Name = "lblSucheRuleCode";
            this.lblSucheRuleCode.Size = new System.Drawing.Size(116, 24);
            this.lblSucheRuleCode.TabIndex = 5;
            this.lblSucheRuleCode.Text = "Rule Typ";
            //
            // lblSucheRuleName
            //
            this.lblSucheRuleName.Location = new System.Drawing.Point(5, 65);
            this.lblSucheRuleName.Name = "lblSucheRuleName";
            this.lblSucheRuleName.Size = new System.Drawing.Size(116, 24);
            this.lblSucheRuleName.TabIndex = 3;
            this.lblSucheRuleName.Text = "Name";
            //
            // edtSucheRuleName
            //
            this.edtSucheRuleName.Location = new System.Drawing.Point(127, 66);
            this.edtSucheRuleName.Name = "edtSucheRuleName";
            this.edtSucheRuleName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheRuleName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheRuleName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheRuleName.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheRuleName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheRuleName.Properties.Appearance.Options.UseFont = true;
            this.edtSucheRuleName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheRuleName.Size = new System.Drawing.Size(350, 24);
            this.edtSucheRuleName.TabIndex = 4;
            //
            // edtSucheCsCode
            //
            this.edtSucheCsCode.Location = new System.Drawing.Point(127, 126);
            this.edtSucheCsCode.Name = "edtSucheCsCode";
            this.edtSucheCsCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheCsCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheCsCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheCsCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheCsCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheCsCode.Properties.Appearance.Options.UseFont = true;
            this.edtSucheCsCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheCsCode.Size = new System.Drawing.Size(350, 24);
            this.edtSucheCsCode.TabIndex = 8;
            //
            // lblSucheCsCode
            //
            this.lblSucheCsCode.Location = new System.Drawing.Point(5, 125);
            this.lblSucheCsCode.Name = "lblSucheCsCode";
            this.lblSucheCsCode.Size = new System.Drawing.Size(116, 24);
            this.lblSucheCsCode.TabIndex = 7;
            this.lblSucheCsCode.Text = "Rule";
            //
            // edtSucheComponentName
            //
            this.edtSucheComponentName.Location = new System.Drawing.Point(127, 36);
            this.edtSucheComponentName.Name = "edtSucheComponentName";
            this.edtSucheComponentName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheComponentName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheComponentName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheComponentName.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheComponentName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheComponentName.Properties.Appearance.Options.UseFont = true;
            this.edtSucheComponentName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheComponentName.Size = new System.Drawing.Size(350, 24);
            this.edtSucheComponentName.TabIndex = 2;
            //
            // lblSucheComponentName
            //
            this.lblSucheComponentName.Location = new System.Drawing.Point(5, 35);
            this.lblSucheComponentName.Name = "lblSucheComponentName";
            this.lblSucheComponentName.Size = new System.Drawing.Size(116, 24);
            this.lblSucheComponentName.TabIndex = 1;
            this.lblSucheComponentName.Text = "Control / Component";
            //
            // panCopyPaste
            //
            this.panCopyPaste.Controls.Add(this.btnPasteRule);
            this.panCopyPaste.Controls.Add(this.btnCopyRule);
            this.panCopyPaste.Dock = System.Windows.Forms.DockStyle.Right;
            this.panCopyPaste.Location = new System.Drawing.Point(995, 0);
            this.panCopyPaste.Name = "panCopyPaste";
            this.panCopyPaste.Size = new System.Drawing.Size(30, 178);
            this.panCopyPaste.TabIndex = 0;
            //
            // btnPasteRule
            //
            this.btnPasteRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPasteRule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPasteRule.Image = global::KiSS4.DesignerHost.Properties.Resources._0057_Paste2;
            this.btnPasteRule.Location = new System.Drawing.Point(3, 33);
            this.btnPasteRule.Name = "btnPasteRule";
            this.btnPasteRule.Size = new System.Drawing.Size(24, 24);
            this.btnPasteRule.TabIndex = 1;
            this.btnPasteRule.UseVisualStyleBackColor = false;
            this.btnPasteRule.Click += new System.EventHandler(this.btnPasteRule_Click);
            //
            // btnCopyRule
            //
            this.btnCopyRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyRule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyRule.Image = global::KiSS4.DesignerHost.Properties.Resources._0055_Copy2;
            this.btnCopyRule.Location = new System.Drawing.Point(3, 3);
            this.btnCopyRule.Name = "btnCopyRule";
            this.btnCopyRule.Size = new System.Drawing.Size(24, 24);
            this.btnCopyRule.TabIndex = 0;
            this.btnCopyRule.UseVisualStyleBackColor = false;
            this.btnCopyRule.Click += new System.EventHandler(this.btnCopyRule_Click);
            //
            // CtlDesignerRule
            //
            this.ActiveSQLQuery = this.qryXClassRule;
            this.Controls.Add(this.panControls);
            this.Controls.Add(this.splitter);
            this.Name = "CtlDesignerRule";
            this.Size = new System.Drawing.Size(1037, 592);
            this.Load += new System.EventHandler(this.CtlDesignerRule_Load);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.splitter, 0);
            this.Controls.SetChildIndex(this.panControls, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdXClassRule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXClassRule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvXClassRule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemCheckAktiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblComponent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtComponent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtComponent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRuleCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRuleCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRuleName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRuleCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRuleName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRuleDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRuleDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSortKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSortKey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtActive.Properties)).EndInit();
            this.panControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qryXRule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheRuleCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheRuleCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheRuleCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheRuleName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheRuleName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheCsCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheCsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheComponentName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheComponentName)).EndInit();
            this.panCopyPaste.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        #region Dispose

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

        #region EventHandlers

        private void CtlDesignerRule_Load(object sender, EventArgs e)
        {
            // run a new search
            RunSearch();
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            var ctlDesigner = GetParentControl(typeof(CtlDesigner)) as CtlDesigner;
            if (ctlDesigner != null)
            {
                ctlDesigner.ShowPreview();
            }
        }

        /// <summary>
        /// Event clicking the button btnCopyRule, copy selected business-rule to clipboard
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void btnCopyRule_Click(object sender, EventArgs e)
        {
            // get current cursor
            Cursor cursor = Cursor.Current;

            try
            {
                // set busy-cursor
                Cursor.Current = Cursors.WaitCursor;

                // check if a rule is available
                if (qryXClassRule.Count < 1)
                {
                    // no rule available, show info
                    KissMsg.ShowInfo("CtlDesignerRule", "CopyRuleNoRule", "Es ist keine Regel zum Kopieren vorhanden.");
                    return;
                }

                // create new dataobject to use within clipboard
                var rule = new ClipboardBusinessRule
                               {
                                   Active = Convert.ToBoolean(qryXClassRule["Active"]),
                                   SortKey = Convert.ToInt32(qryXClassRule["SortKey"]),
                                   ControlName = Convert.ToString(qryXClassRule["ControlName"]),
                                   ComponentName = Convert.ToString(qryXClassRule["ComponentName"]),
                                   RuleName = Convert.ToString(qryXClassRule["RuleName"]),
                                   RuleDescription = Convert.ToString(qryXClassRule["RuleDescription"]),
                                   RuleCode = Convert.ToInt32(qryXClassRule["RuleCode"]),
                                   CsCode = Convert.ToString(qryXClassRule["csCode"]),
                                   PublicRule = Convert.ToBoolean(qryXClassRule["PublicRule"]),
                                   TemplateRule = Convert.ToBoolean(qryXClassRule["TemplateRule"])
                               };

                // fill date to rule

                // copy data to empty clipboard
                Clipboard.Clear();
                Clipboard.SetData(typeof(ClipboardBusinessRule).FullName, rule);

                // check if success
                if (!Clipboard.ContainsData(typeof(ClipboardBusinessRule).FullName))
                {
                    // something went wrong
                    KissMsg.ShowInfo("CtlDesignerRule", "CopyRuleFailure", "Die ausgewählte Regel konnte nicht in den Zwischenspeicher kopiert werden.");
                    return;
                }
            }
            catch (System.Runtime.Serialization.SerializationException ex)
            {
                // show error
                KissMsg.ShowError("CtlDesignerRule", "CopySerializationException", "Es ist ein Fehler bei der Serialisation aufgetreten, die Regel konnte nicht korrekt kopiert werden.", ex);
            }
            finally
            {
                // reset cursor
                Cursor.Current = cursor;
            }
        }

        private void btnExportCS_Click(object sender, EventArgs e)
        {
            var dlg = new SaveFileDialog
                          {
                              FileName = string.Format("{0}.cs", _qryXClass["ClassName"]),
                              DefaultExt = "cs"
                          };
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            CtlClass.ExportCS(new[] { _qryXClass.Row }, new FileInfo(dlg.FileName).DirectoryName);
        }

        private void btnImportCS_Click(object sender, EventArgs e)
        {
            if (CtlClass.ImportCS(_qryXClass, 1))
            {
                _qryXClass.Refresh();
            }
        }

        /// <summary>
        /// Event clicking the button btnPasteRule, paste business-rule from clipboard as new rule
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void btnPasteRule_Click(object sender, EventArgs e)
        {
            // get current cursor
            Cursor cursor = Cursor.Current;

            try
            {
                // set busy-cursor
                Cursor.Current = Cursors.WaitCursor;

                // check if we can paste rule to query
                if (!qryXClassRule.CanInsert)
                {
                    // query is locked, no paste is possible
                    KissMsg.ShowInfo("CtlDesignerRule", "PasteRuleCannotInsert", "Es können keine neuen Regeln hinzugefügt werden.");
                    return;
                }

                // check if clipboard contains data
                if (!Clipboard.ContainsData(typeof(ClipboardBusinessRule).FullName))
                {
                    // clipboard does not contain any rule-data
                    KissMsg.ShowInfo("CtlDesignerRule", "PasteRuleNoRuleInClipboard", "Der Zwischenspeicher enthält keine gültigen Daten.");
                    return;
                }

                // get data from clipboard
                var rule = (ClipboardBusinessRule)Clipboard.GetData(typeof(ClipboardBusinessRule).FullName);

                // check if we have a rule
                if (rule == null)
                {
                    // no valid rule received from clipboard
                    KissMsg.ShowInfo("CtlDesignerRule", "PasteRuleNoValidRuleFromClipboard", "Der Zwischenspeicher konnte nicht in eine Regel umgeformt werden.");
                    return;
                }

                // create new rule within query and check if success
                if (OnAddData())
                {
                    // apply data
                    qryXClassRule["Active"] = rule.Active;
                    qryXClassRule["SortKey"] = rule.SortKey;
                    qryXClassRule["RuleName"] = rule.RuleName;
                    qryXClassRule["RuleDescription"] = rule.RuleDescription;
                    qryXClassRule["RuleCode"] = rule.RuleCode;
                    qryXClassRule["csCode"] = rule.CsCode;
                    qryXClassRule["PublicRule"] = rule.PublicRule;
                    qryXClassRule["TemplateRule"] = rule.TemplateRule;

                    // apply controlname if possible
                    if (!DBUtil.IsEmpty(rule.ControlName) &&
                        edtControl.Properties.DataSource != null &&
                        edtControl.Properties.DataSource is SqlQuery &&
                        ((SqlQuery)edtControl.Properties.DataSource).Find(String.Format("ControlName = '{0}'", rule.ControlName)))
                    {
                        // found it, apply
                        qryXClassRule["ControlName"] = rule.ControlName;
                    }

                    // apply componentname if possible
                    if (!DBUtil.IsEmpty(rule.ComponentName) &&
                        edtComponent.Properties.DataSource != null &&
                        edtComponent.Properties.DataSource is SqlQuery &&
                        ((SqlQuery)edtComponent.Properties.DataSource).Find(String.Format("ComponentName = '{0}'", rule.ComponentName)))
                    {
                        // found it, apply
                        qryXClassRule["ComponentName"] = rule.ComponentName;
                    }
                }
            }
            catch (System.Runtime.Serialization.SerializationException ex)
            {
                // show error
                KissMsg.ShowError("CtlDesignerRule", "PasteSerializationException", "Es ist ein Fehler bei der Serialisation aufgetreten, die Regel wurde nicht korrekt erstellt.", ex);
            }
            finally
            {
                // reset cursor
                Cursor.Current = cursor;
            }
        }

        private void edtComponent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                // delete component name if user pressed delete button
                edtComponent.EditValue = null;
            }
        }

        private void edtControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                // delete control name if user pressed delete button
                edtControl.EditValue = null;
            }
        }

        private void edtRuleName_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var dlg = new KissLookupDialog();

            string searchString = edtRuleName.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (dlg.SearchData(@"
                    SELECT ID = RUL.XRuleID, Name = RuleName, Typ = XLC.Text, Template = RUL.TemplateRule
                    FROM XRule             RUL
                      INNER JOIN XLOVCode  XLC ON XLC.LOVName = 'Rule' AND XLC.Code = RUL.RuleCode
                    WHERE (RUL.RuleName LIKE '%' + {0} + '%' OR CONVERT(varchar, RUL.XRuleID) = {0})
                      AND IsNull(RUL.ModulID, {1}) = {1}
                      AND (RUL.PublicRule = 1 OR RUL.TemplateRule = 1
                       OR EXISTS (SELECT *
                                  FROM XClassRule      CLR
                                    INNER JOIN XClass  CLS ON CLS.ClassName = CLR.ClassName AND CLS.ModulID = {1}
                                  WHERE CLR.XRuleID = RUL.XRuleID AND (RUL.RuleCode IN (1, 4) OR CLR.ClassName = {2})))
                    ORDER BY RuleName;", searchString, true, _qryXClass["ModulID"], _qryXClass["ClassName"]))
            {
                SqlQuery qry = DBUtil.OpenSQL(@"
                    SELECT
                      New_XRuleID = CASE WHEN TemplateRule = 1 THEN NULL ELSE XRuleID END,
                      New_SortKey = IsNull(DefaultSortKey, {1}),
                      RUL.*
                    FROM XRule  RUL
                    WHERE XRuleID = {0};", dlg["ID"], qryXClassRule["SortKey"]);

                foreach (DataColumn col in qry.DataTable.Columns)
                {
                    if (qryXClassRule.DataTable.Columns.Contains(col.ColumnName))
                    {
                        qryXClassRule[col.ColumnName] = qry[col.ColumnName];
                    }
                }

                qryXClassRule["XRuleID"] = qry["New_XRuleID"];
                qryXClassRule["SortKey"] = qry["New_SortKey"];
                qryXClassRule["TemplateRule"] = false;
            }
            else
            {
                if ((bool)qryXClassRule["PublicRule"] && searchString == "")
                {
                    qryXClassRule["XRuleID"] = DBNull.Value;
                    qryXClassRule["RuleName"] = DBNull.Value;
                    qryXClassRule["PublicRule"] = false;
                    qryXClassRule["ModulID"] = DBNull.Value;
                    qryXClassRule["DefaultSortKey"] = DBNull.Value;
                }
                else if ((bool)qryXClassRule["PublicRule"])
                {
                    e.Cancel = true;
                }
                else
                {
                    qryXClassRule["RuleName"] = edtRuleName.EditValue;
                }
            }

            qryXClassRule.RefreshDisplay();
            qryXClassRule_PositionChanged(sender, EventArgs.Empty);
        }

        private void qryXClassRule_AfterInsert(object sender, EventArgs e)
        {
            qryXClassRule["ClassName"] = _qryXClass["ClassName"];
            qryXClassRule["RuleCode"] = 3;
            qryXClassRule["PublicRule"] = false;
            qryXClassRule["TemplateRule"] = false;

            qryXClassRule_PositionChanged(sender, e);

            edtControl.Focus();
        }

        private void qryXClassRule_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtRuleCode, lblRuleCode.Text);

            qryXRule.Fill(qryXClassRule["XRuleID"]);
            if (qryXRule.Count == 0)
            {
                qryXRule.Insert();
                qryXClassRule["XRuleID"] = DBUtil.ExecuteScalarSQL(@"
                    SELECT IsNull(MAX(XRuleID), 1000) + 1
                    FROM XRule
                    WHERE XRuleID > 1000");
            }

            foreach (DataColumn col in qryXRule.DataTable.Columns)
                qryXRule[col.ColumnName] = qryXClassRule[col.ColumnName];

            qryXRule.Post();
        }

        private void qryXClassRule_PositionChanged(object sender, EventArgs e)
        {
            if (!DBUtil.IsEmpty(qryXClassRule["PublicRule"]) && (bool)qryXClassRule["PublicRule"])
            {
                edtRuleCode.EditMode = EditModeType.ReadOnly;
                edtRuleDescription.EditMode = EditModeType.ReadOnly;
                edtCsCode.EditMode = EditModeType.ReadOnly;
            }
            else
            {
                edtRuleCode.EditMode = EditModeType.Normal;
                edtRuleDescription.EditMode = EditModeType.Normal;
                edtCsCode.EditMode = EditModeType.Normal;

                qryXClassRule.EnableBoundFields();
            }
        }

        private void qryXClass_AfterFill(object sender, EventArgs e)
        {
            btnImportCS.Enabled = _qryXClass.CanUpdate;
            btnBuild.Enabled = _qryXClass.CanUpdate;

            qryXClassRule.CanInsert &= _qryXClass.CanUpdate;
            qryXClassRule.CanUpdate &= _qryXClass.CanUpdate;
            qryXClassRule.CanDelete &= _qryXClass.CanUpdate;

            kissSearch.SelectParameters = new[] { _qryXClass["ClassName"] };
            qryXClassRule.Fill(MyCodeDomDesignerLoader.SQLqryXClassRule, _qryXClass["ClassName"]);

            var qry = edtControl.Properties.DataSource as SqlQuery;
            edtControl.Properties.DataSource = null;
            edtControl.Properties.DataSource = qry;

            qry = edtComponent.Properties.DataSource as SqlQuery;
            edtComponent.Properties.DataSource = null;
            edtComponent.Properties.DataSource = qry;
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();

            edtSucheComponentName.Focus();
        }

        #endregion

        #endregion
    }
}