using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS4.Administration
{
    partial class CtlBookmarkStandard
    {
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBookmarkStandard));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdBookmark = new KiSS4.Gui.KissGrid();
            this.qryBookmark = new KiSS4.DB.SqlQuery(this.components);
            this.grvBookmark = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBookmarkName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBookmarkCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTableName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModul = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlwaysVisible = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSystem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblCategory = new KiSS4.Gui.KissLabel();
            this.lblBookmarkName = new KiSS4.Gui.KissLabel();
            this.lblDescription = new KiSS4.Gui.KissLabel();
            this.lblSQL = new KiSS4.Gui.KissLabel();
            this.edtSQL = new KiSS4.Gui.KissMemoEdit();
            this.chkReadOnly = new KiSS4.Gui.KissCheckEdit();
            this.lblBookmarkCode = new KiSS4.Gui.KissLabel();
            this.edtBookmarkCode = new KiSS4.Gui.KissLookUpEdit();
            this.btnCopy = new KiSS4.Gui.KissButton();
            this.lblTableName = new KiSS4.Gui.KissLabel();
            this.edtTableName = new KiSS4.Gui.KissComboBox();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.edtDescriptionML = new KiSS4.Gui.KissMemoEditML();
            this.edtBookmarkName = new KiSS4.Gui.KissTextEditML();
            this.edtCategory = new KiSS4.Gui.KissTextEditML();
            this.edtModulID = new KiSS4.Gui.KissLookUpEdit();
            this.lblModulID = new KiSS4.Gui.KissLabel();
            this.chkSystem = new KiSS4.Gui.KissCheckEdit();
            this.chkAlwaysVisible = new KiSS4.Gui.KissCheckEdit();
            this.splitter = new KiSS4.Gui.KissSplitterCollapsible();
            this.lblSucheCategory = new KiSS4.Gui.KissLabel();
            this.lblSucheBookmarkName = new KiSS4.Gui.KissLabel();
            this.edtSucheTableName = new KiSS4.Gui.KissComboBox();
            this.lblSucheDescription = new KiSS4.Gui.KissLabel();
            this.lblSucheTableName = new KiSS4.Gui.KissLabel();
            this.edtSucheBookmarkName = new KiSS4.Gui.KissTextEdit();
            this.lblSucheSQL = new KiSS4.Gui.KissLabel();
            this.edtSucheBookmarkCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheBookmarkCode = new KiSS4.Gui.KissLabel();
            this.edtSucheCategory = new KiSS4.Gui.KissTextEdit();
            this.edtSucheDescription = new KiSS4.Gui.KissTextEdit();
            this.edtSucheSQL = new KiSS4.Gui.KissTextEdit();
            this.lblRowCount = new KiSS4.Gui.KissLabel();
            this.edtSucheModulID = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheModulID = new KiSS4.Gui.KissLabel();
            this.chkSucheAlwaysVisible = new KiSS4.Gui.KissCheckEdit();
            this.chkSucheSystem = new KiSS4.Gui.KissCheckEdit();
            this.chkSucheNichtSystem = new KiSS4.Gui.KissCheckEdit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBookmark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBookmark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBookmark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBookmarkName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSQL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSQL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkReadOnly.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBookmarkCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBookmarkCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBookmarkCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTableName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTableName.Properties)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtBookmarkName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModulID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSystem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAlwaysVisible.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBookmarkName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTableName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheTableName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBookmarkName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheSQL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBookmarkCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBookmarkCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBookmarkCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheSQL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRowCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheModulID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheModulID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheModulID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheAlwaysVisible.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheSystem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheNichtSystem.Properties)).BeginInit();
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
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.Size = new System.Drawing.Size(800, 242);
            this.tabControlSearch.Resize += new System.EventHandler(this.tabControlSearch_Resize);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdBookmark);
            this.tpgListe.Size = new System.Drawing.Size(788, 204);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtSucheModulID);
            this.tpgSuchen.Controls.Add(this.lblSucheCategory);
            this.tpgSuchen.Controls.Add(this.lblSucheBookmarkName);
            this.tpgSuchen.Controls.Add(this.edtSucheTableName);
            this.tpgSuchen.Controls.Add(this.lblSucheDescription);
            this.tpgSuchen.Controls.Add(this.lblSucheTableName);
            this.tpgSuchen.Controls.Add(this.edtSucheSQL);
            this.tpgSuchen.Controls.Add(this.edtSucheDescription);
            this.tpgSuchen.Controls.Add(this.edtSucheBookmarkName);
            this.tpgSuchen.Controls.Add(this.lblSucheModulID);
            this.tpgSuchen.Controls.Add(this.lblSucheSQL);
            this.tpgSuchen.Controls.Add(this.edtSucheBookmarkCode);
            this.tpgSuchen.Controls.Add(this.lblSucheBookmarkCode);
            this.tpgSuchen.Controls.Add(this.chkSucheNichtSystem);
            this.tpgSuchen.Controls.Add(this.chkSucheSystem);
            this.tpgSuchen.Controls.Add(this.chkSucheAlwaysVisible);
            this.tpgSuchen.Controls.Add(this.edtSucheCategory);
            this.tpgSuchen.Size = new System.Drawing.Size(788, 204);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheCategory, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkSucheAlwaysVisible, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkSucheSystem, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkSucheNichtSystem, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBookmarkCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBookmarkCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheSQL, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheModulID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBookmarkName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheDescription, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheSQL, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheTableName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheDescription, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheTableName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBookmarkName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheCategory, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheModulID, 0);
            // 
            // grdBookmark
            // 
            this.grdBookmark.DataSource = this.qryBookmark;
            this.grdBookmark.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdBookmark.EmbeddedNavigator.Name = "";
            this.grdBookmark.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBookmark.Location = new System.Drawing.Point(0, 0);
            this.grdBookmark.MainView = this.grvBookmark;
            this.grdBookmark.Name = "grdBookmark";
            this.grdBookmark.Size = new System.Drawing.Size(788, 204);
            this.grdBookmark.TabIndex = 1;
            this.grdBookmark.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBookmark});
            // 
            // qryBookmark
            // 
            this.qryBookmark.HostControl = this;
            this.qryBookmark.SelectStatement = resources.GetString("qryBookmark.SelectStatement");
            this.qryBookmark.TableName = "XBookmark";
            this.qryBookmark.AfterFill += new System.EventHandler(this.qryBookmark_AfterFill);
            this.qryBookmark.AfterInsert += new System.EventHandler(this.qryBookmark_AfterInsert);
            this.qryBookmark.AfterPost += new System.EventHandler(this.qryBookmark_AfterPost);
            this.qryBookmark.BeforeDeleteQuestion += new System.EventHandler(this.qryBookmark_BeforeDeleteQuestion);
            this.qryBookmark.BeforePost += new System.EventHandler(this.qryBookmark_BeforePost);
            this.qryBookmark.PositionChanged += new System.EventHandler(this.qryBookmark_PositionChanged);
            // 
            // grvBookmark
            // 
            this.grvBookmark.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBookmark.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBookmark.Appearance.Empty.Options.UseBackColor = true;
            this.grvBookmark.Appearance.Empty.Options.UseFont = true;
            this.grvBookmark.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBookmark.Appearance.EvenRow.Options.UseFont = true;
            this.grvBookmark.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBookmark.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBookmark.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBookmark.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBookmark.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBookmark.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBookmark.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBookmark.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBookmark.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBookmark.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBookmark.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBookmark.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBookmark.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBookmark.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBookmark.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBookmark.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBookmark.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBookmark.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBookmark.Appearance.GroupRow.Options.UseFont = true;
            this.grvBookmark.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBookmark.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBookmark.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBookmark.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBookmark.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBookmark.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBookmark.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBookmark.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBookmark.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBookmark.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBookmark.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBookmark.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBookmark.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBookmark.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBookmark.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBookmark.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBookmark.Appearance.OddRow.Options.UseFont = true;
            this.grvBookmark.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBookmark.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBookmark.Appearance.Row.Options.UseBackColor = true;
            this.grvBookmark.Appearance.Row.Options.UseFont = true;
            this.grvBookmark.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBookmark.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBookmark.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBookmark.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBookmark.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBookmark.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCategory,
            this.colBookmarkName,
            this.colBookmarkCode,
            this.colTableName,
            this.colDescription,
            this.colModul,
            this.colAlwaysVisible,
            this.colSystem});
            this.grvBookmark.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBookmark.GridControl = this.grdBookmark;
            this.grvBookmark.Name = "grvBookmark";
            this.grvBookmark.OptionsBehavior.Editable = false;
            this.grvBookmark.OptionsCustomization.AllowFilter = false;
            this.grvBookmark.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBookmark.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBookmark.OptionsNavigation.UseTabKey = false;
            this.grvBookmark.OptionsView.ColumnAutoWidth = false;
            this.grvBookmark.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBookmark.OptionsView.ShowGroupPanel = false;
            this.grvBookmark.OptionsView.ShowIndicator = false;
            // 
            // colCategory
            // 
            this.colCategory.Caption = "Kategorie";
            this.colCategory.FieldName = "Category";
            this.colCategory.Name = "colCategory";
            this.colCategory.Visible = true;
            this.colCategory.VisibleIndex = 0;
            this.colCategory.Width = 180;
            // 
            // colBookmarkName
            // 
            this.colBookmarkName.AppearanceCell.Options.UseTextOptions = true;
            this.colBookmarkName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colBookmarkName.Caption = "Textmarke";
            this.colBookmarkName.FieldName = "DisplayName";
            this.colBookmarkName.Name = "colBookmarkName";
            this.colBookmarkName.Visible = true;
            this.colBookmarkName.VisibleIndex = 1;
            this.colBookmarkName.Width = 240;
            // 
            // colBookmarkCode
            // 
            this.colBookmarkCode.Caption = "Typ";
            this.colBookmarkCode.FieldName = "BookmarkCode";
            this.colBookmarkCode.Name = "colBookmarkCode";
            this.colBookmarkCode.Visible = true;
            this.colBookmarkCode.VisibleIndex = 2;
            this.colBookmarkCode.Width = 120;
            // 
            // colTableName
            // 
            this.colTableName.Caption = "Tabelle";
            this.colTableName.FieldName = "TableName";
            this.colTableName.Name = "colTableName";
            this.colTableName.Visible = true;
            this.colTableName.VisibleIndex = 3;
            this.colTableName.Width = 170;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Beschreibung";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 4;
            this.colDescription.Width = 170;
            // 
            // colModul
            // 
            this.colModul.Caption = "Modul";
            this.colModul.FieldName = "Modul";
            this.colModul.Name = "colModul";
            this.colModul.Visible = true;
            this.colModul.VisibleIndex = 5;
            this.colModul.Width = 170;
            // 
            // colAlwaysVisible
            // 
            this.colAlwaysVisible.Caption = "Immer sichtbar";
            this.colAlwaysVisible.FieldName = "AlwaysVisible";
            this.colAlwaysVisible.Name = "colAlwaysVisible";
            this.colAlwaysVisible.Visible = true;
            this.colAlwaysVisible.VisibleIndex = 6;
            this.colAlwaysVisible.Width = 97;
            // 
            // colSystem
            // 
            this.colSystem.Caption = "System";
            this.colSystem.FieldName = "System";
            this.colSystem.Name = "colSystem";
            this.colSystem.Visible = true;
            this.colSystem.VisibleIndex = 7;
            this.colSystem.Width = 65;
            // 
            // lblCategory
            // 
            this.lblCategory.Location = new System.Drawing.Point(9, 9);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(9, 9, 3, 9);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(87, 24);
            this.lblCategory.TabIndex = 0;
            this.lblCategory.Text = "Kategorie";
            // 
            // lblBookmarkName
            // 
            this.lblBookmarkName.Location = new System.Drawing.Point(9, 39);
            this.lblBookmarkName.Name = "lblBookmarkName";
            this.lblBookmarkName.Size = new System.Drawing.Size(87, 24);
            this.lblBookmarkName.TabIndex = 2;
            this.lblBookmarkName.Text = "Textmarke";
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(9, 131);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(87, 24);
            this.lblDescription.TabIndex = 8;
            this.lblDescription.Text = "Beschreibung";
            // 
            // lblSQL
            // 
            this.lblSQL.Location = new System.Drawing.Point(9, 187);
            this.lblSQL.Name = "lblSQL";
            this.lblSQL.Size = new System.Drawing.Size(87, 24);
            this.lblSQL.TabIndex = 10;
            this.lblSQL.Text = "SQL";
            // 
            // edtSQL
            // 
            this.edtSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtSQL.DataMember = "SQL";
            this.edtSQL.DataSource = this.qryBookmark;
            this.edtSQL.Location = new System.Drawing.Point(102, 187);
            this.edtSQL.Margin = new System.Windows.Forms.Padding(3, 3, 9, 9);
            this.edtSQL.Name = "edtSQL";
            this.edtSQL.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSQL.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSQL.Properties.Appearance.Font = new System.Drawing.Font("Courier New", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSQL.Properties.Appearance.Options.UseBackColor = true;
            this.edtSQL.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSQL.Properties.Appearance.Options.UseFont = true;
            this.edtSQL.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSQL.ProportionalFont = false;
            this.edtSQL.Size = new System.Drawing.Size(689, 104);
            this.edtSQL.TabIndex = 11;
            // 
            // chkReadOnly
            // 
            this.chkReadOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkReadOnly.EditValue = true;
            this.chkReadOnly.Location = new System.Drawing.Point(652, 106);
            this.chkReadOnly.Name = "chkReadOnly";
            this.chkReadOnly.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkReadOnly.Properties.Appearance.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chkReadOnly.Properties.Appearance.Options.UseBackColor = true;
            this.chkReadOnly.Properties.Appearance.Options.UseFont = true;
            this.chkReadOnly.Properties.Caption = "Schreibschutz";
            this.chkReadOnly.Size = new System.Drawing.Size(139, 19);
            this.chkReadOnly.TabIndex = 17;
            this.chkReadOnly.CheckedChanged += new System.EventHandler(this.chkReadOnly_CheckedChanged);
            // 
            // lblBookmarkCode
            // 
            this.lblBookmarkCode.Location = new System.Drawing.Point(9, 69);
            this.lblBookmarkCode.Name = "lblBookmarkCode";
            this.lblBookmarkCode.Size = new System.Drawing.Size(87, 24);
            this.lblBookmarkCode.TabIndex = 4;
            this.lblBookmarkCode.Text = "Typ";
            // 
            // edtBookmarkCode
            // 
            this.edtBookmarkCode.DataMember = "BookmarkCode";
            this.edtBookmarkCode.DataSource = this.qryBookmark;
            this.edtBookmarkCode.Location = new System.Drawing.Point(102, 69);
            this.edtBookmarkCode.LOVName = "Bookmark";
            this.edtBookmarkCode.Name = "edtBookmarkCode";
            this.edtBookmarkCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBookmarkCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBookmarkCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBookmarkCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtBookmarkCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBookmarkCode.Properties.Appearance.Options.UseFont = true;
            this.edtBookmarkCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBookmarkCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBookmarkCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBookmarkCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBookmarkCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtBookmarkCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtBookmarkCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBookmarkCode.Properties.NullText = "";
            this.edtBookmarkCode.Properties.ShowFooter = false;
            this.edtBookmarkCode.Properties.ShowHeader = false;
            this.edtBookmarkCode.Size = new System.Drawing.Size(295, 24);
            this.edtBookmarkCode.TabIndex = 5;
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.Location = new System.Drawing.Point(518, 101);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(104, 24);
            this.btnCopy.TabIndex = 16;
            this.btnCopy.Text = "Kopie";
            this.btnCopy.UseVisualStyleBackColor = false;
            this.btnCopy.Visible = false;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // lblTableName
            // 
            this.lblTableName.Location = new System.Drawing.Point(9, 101);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(87, 24);
            this.lblTableName.TabIndex = 6;
            this.lblTableName.Text = "Tabelle";
            // 
            // edtTableName
            // 
            this.edtTableName.DataMember = "TableName";
            this.edtTableName.DataSource = this.qryBookmark;
            this.edtTableName.Location = new System.Drawing.Point(102, 101);
            this.edtTableName.Name = "edtTableName";
            this.edtTableName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTableName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTableName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTableName.Properties.Appearance.Options.UseBackColor = true;
            this.edtTableName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTableName.Properties.Appearance.Options.UseFont = true;
            this.edtTableName.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtTableName.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtTableName.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtTableName.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtTableName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtTableName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtTableName.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTableName.Size = new System.Drawing.Size(295, 24);
            this.edtTableName.TabIndex = 7;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.edtDescriptionML);
            this.pnlBottom.Controls.Add(this.edtBookmarkName);
            this.pnlBottom.Controls.Add(this.edtCategory);
            this.pnlBottom.Controls.Add(this.edtModulID);
            this.pnlBottom.Controls.Add(this.lblModulID);
            this.pnlBottom.Controls.Add(this.lblCategory);
            this.pnlBottom.Controls.Add(this.lblBookmarkName);
            this.pnlBottom.Controls.Add(this.edtTableName);
            this.pnlBottom.Controls.Add(this.lblDescription);
            this.pnlBottom.Controls.Add(this.lblTableName);
            this.pnlBottom.Controls.Add(this.btnCopy);
            this.pnlBottom.Controls.Add(this.lblSQL);
            this.pnlBottom.Controls.Add(this.edtBookmarkCode);
            this.pnlBottom.Controls.Add(this.lblBookmarkCode);
            this.pnlBottom.Controls.Add(this.edtSQL);
            this.pnlBottom.Controls.Add(this.chkSystem);
            this.pnlBottom.Controls.Add(this.chkAlwaysVisible);
            this.pnlBottom.Controls.Add(this.chkReadOnly);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 250);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(800, 300);
            this.pnlBottom.TabIndex = 2;
            // 
            // edtDescriptionML
            // 
            this.edtDescriptionML.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDescriptionML.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtDescriptionML.DataMemberDefaultText = "Description";
            this.edtDescriptionML.DataMemberTID = "DescriptionTID";
            this.edtDescriptionML.DataSource = this.qryBookmark;
            this.edtDescriptionML.Location = new System.Drawing.Point(102, 131);
            this.edtDescriptionML.Name = "edtDescriptionML";
            this.edtDescriptionML.Size = new System.Drawing.Size(689, 50);
            this.edtDescriptionML.TabIndex = 20;
            this.edtDescriptionML.WriteLocked = false;
            // 
            // edtBookmarkName
            // 
            this.edtBookmarkName.DataMemberDefaultText = "DisplayName";
            this.edtBookmarkName.DataMemberTID = "BookmarkNameTID";
            this.edtBookmarkName.DataSource = this.qryBookmark;
            this.edtBookmarkName.Location = new System.Drawing.Point(102, 39);
            this.edtBookmarkName.Name = "edtBookmarkName";
            this.edtBookmarkName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBookmarkName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBookmarkName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBookmarkName.Properties.Appearance.Options.UseBackColor = true;
            this.edtBookmarkName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBookmarkName.Properties.Appearance.Options.UseFont = true;
            this.edtBookmarkName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtBookmarkName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtBookmarkName.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtBookmarkName.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBookmarkName.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.edtBookmarkName.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtBookmarkName.Size = new System.Drawing.Size(295, 24);
            this.edtBookmarkName.TabIndex = 19;
            // 
            // edtCategory
            // 
            this.edtCategory.DataMemberDefaultText = "Category";
            this.edtCategory.DataMemberTID = "CategoryTID";
            this.edtCategory.DataSource = this.qryBookmark;
            this.edtCategory.Location = new System.Drawing.Point(102, 9);
            this.edtCategory.Name = "edtCategory";
            this.edtCategory.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtCategory.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtCategory.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtCategory.Properties.Appearance.Options.UseBackColor = true;
            this.edtCategory.Properties.Appearance.Options.UseBorderColor = true;
            this.edtCategory.Properties.Appearance.Options.UseFont = true;
            this.edtCategory.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtCategory.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtCategory.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtCategory.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.edtCategory.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtCategory.Size = new System.Drawing.Size(295, 24);
            this.edtCategory.TabIndex = 18;
            // 
            // edtModulID
            // 
            this.edtModulID.DataMember = "ModulID";
            this.edtModulID.DataSource = this.qryBookmark;
            this.edtModulID.Location = new System.Drawing.Point(518, 9);
            this.edtModulID.LOVFilter = "(ModulID > 0 OR ModulID IN (0, -1, -7))";
            this.edtModulID.LOVFilterWhereAppend = true;
            this.edtModulID.LOVName = "Modul";
            this.edtModulID.Name = "edtModulID";
            this.edtModulID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtModulID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtModulID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtModulID.Properties.Appearance.Options.UseBackColor = true;
            this.edtModulID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtModulID.Properties.Appearance.Options.UseFont = true;
            this.edtModulID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtModulID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtModulID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtModulID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtModulID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtModulID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtModulID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtModulID.Properties.NullText = "";
            this.edtModulID.Properties.ShowFooter = false;
            this.edtModulID.Properties.ShowHeader = false;
            this.edtModulID.Size = new System.Drawing.Size(273, 24);
            this.edtModulID.TabIndex = 13;
            // 
            // lblModulID
            // 
            this.lblModulID.Location = new System.Drawing.Point(425, 9);
            this.lblModulID.Name = "lblModulID";
            this.lblModulID.Size = new System.Drawing.Size(87, 24);
            this.lblModulID.TabIndex = 12;
            this.lblModulID.Text = "Modul";
            // 
            // chkSystem
            // 
            this.chkSystem.DataMember = "System";
            this.chkSystem.DataSource = this.qryBookmark;
            this.chkSystem.Location = new System.Drawing.Point(652, 39);
            this.chkSystem.Name = "chkSystem";
            this.chkSystem.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkSystem.Properties.Appearance.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chkSystem.Properties.Appearance.Options.UseBackColor = true;
            this.chkSystem.Properties.Appearance.Options.UseFont = true;
            this.chkSystem.Properties.Caption = "System";
            this.chkSystem.Size = new System.Drawing.Size(95, 19);
            this.chkSystem.TabIndex = 15;
            // 
            // chkAlwaysVisible
            // 
            this.chkAlwaysVisible.DataMember = "AlwaysVisible";
            this.chkAlwaysVisible.DataSource = this.qryBookmark;
            this.chkAlwaysVisible.Location = new System.Drawing.Point(518, 39);
            this.chkAlwaysVisible.Name = "chkAlwaysVisible";
            this.chkAlwaysVisible.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkAlwaysVisible.Properties.Appearance.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chkAlwaysVisible.Properties.Appearance.Options.UseBackColor = true;
            this.chkAlwaysVisible.Properties.Appearance.Options.UseFont = true;
            this.chkAlwaysVisible.Properties.Caption = "Immer sichtbar";
            this.chkAlwaysVisible.Size = new System.Drawing.Size(128, 19);
            this.chkAlwaysVisible.TabIndex = 14;
            // 
            // splitter
            // 
            this.splitter.AnimationDelay = 20;
            this.splitter.AnimationStep = 20;
            this.splitter.BorderStyle3D = System.Windows.Forms.Border3DStyle.Etched;
            this.splitter.ControlToHide = this.pnlBottom;
            this.splitter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter.ExpandParentForm = false;
            this.splitter.Location = new System.Drawing.Point(0, 242);
            this.splitter.Name = "kissSplitterCollapsible1";
            this.splitter.TabIndex = 0;
            this.splitter.TabStop = false;
            this.splitter.UseAnimations = false;
            this.splitter.VisualStyle = KiSS4.Gui.VisualStyles.Mozilla;
            // 
            // lblSucheCategory
            // 
            this.lblSucheCategory.Location = new System.Drawing.Point(30, 40);
            this.lblSucheCategory.Margin = new System.Windows.Forms.Padding(9, 9, 3, 9);
            this.lblSucheCategory.Name = "lblSucheCategory";
            this.lblSucheCategory.Size = new System.Drawing.Size(87, 24);
            this.lblSucheCategory.TabIndex = 1;
            this.lblSucheCategory.Text = "Kategorie";
            // 
            // lblSucheBookmarkName
            // 
            this.lblSucheBookmarkName.Location = new System.Drawing.Point(30, 70);
            this.lblSucheBookmarkName.Name = "lblSucheBookmarkName";
            this.lblSucheBookmarkName.Size = new System.Drawing.Size(87, 24);
            this.lblSucheBookmarkName.TabIndex = 3;
            this.lblSucheBookmarkName.Text = "Textmarke";
            // 
            // edtSucheTableName
            // 
            this.edtSucheTableName.Location = new System.Drawing.Point(123, 130);
            this.edtSucheTableName.Name = "edtSucheTableName";
            this.edtSucheTableName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheTableName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheTableName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheTableName.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheTableName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheTableName.Properties.Appearance.Options.UseFont = true;
            this.edtSucheTableName.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheTableName.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheTableName.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheTableName.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheTableName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtSucheTableName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtSucheTableName.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheTableName.Size = new System.Drawing.Size(268, 24);
            this.edtSucheTableName.TabIndex = 8;
            // 
            // lblSucheDescription
            // 
            this.lblSucheDescription.Location = new System.Drawing.Point(419, 40);
            this.lblSucheDescription.Name = "lblSucheDescription";
            this.lblSucheDescription.Size = new System.Drawing.Size(87, 24);
            this.lblSucheDescription.TabIndex = 9;
            this.lblSucheDescription.Text = "Beschreibung";
            // 
            // lblSucheTableName
            // 
            this.lblSucheTableName.Location = new System.Drawing.Point(30, 130);
            this.lblSucheTableName.Name = "lblSucheTableName";
            this.lblSucheTableName.Size = new System.Drawing.Size(87, 24);
            this.lblSucheTableName.TabIndex = 7;
            this.lblSucheTableName.Text = "Tabelle";
            // 
            // edtSucheBookmarkName
            // 
            this.edtSucheBookmarkName.Location = new System.Drawing.Point(123, 70);
            this.edtSucheBookmarkName.Name = "edtSucheBookmarkName";
            this.edtSucheBookmarkName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBookmarkName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBookmarkName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBookmarkName.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBookmarkName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBookmarkName.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBookmarkName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheBookmarkName.Properties.MaxLength = 40;
            this.edtSucheBookmarkName.Size = new System.Drawing.Size(268, 24);
            this.edtSucheBookmarkName.TabIndex = 4;
            // 
            // lblSucheSQL
            // 
            this.lblSucheSQL.Location = new System.Drawing.Point(419, 70);
            this.lblSucheSQL.Name = "lblSucheSQL";
            this.lblSucheSQL.Size = new System.Drawing.Size(87, 24);
            this.lblSucheSQL.TabIndex = 11;
            this.lblSucheSQL.Text = "SQL";
            // 
            // edtSucheBookmarkCode
            // 
            this.edtSucheBookmarkCode.Location = new System.Drawing.Point(123, 100);
            this.edtSucheBookmarkCode.LOVName = "Bookmark";
            this.edtSucheBookmarkCode.Name = "edtSucheBookmarkCode";
            this.edtSucheBookmarkCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBookmarkCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBookmarkCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBookmarkCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBookmarkCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBookmarkCode.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBookmarkCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheBookmarkCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBookmarkCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheBookmarkCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheBookmarkCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtSucheBookmarkCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtSucheBookmarkCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheBookmarkCode.Properties.NullText = "";
            this.edtSucheBookmarkCode.Properties.ShowFooter = false;
            this.edtSucheBookmarkCode.Properties.ShowHeader = false;
            this.edtSucheBookmarkCode.Size = new System.Drawing.Size(268, 24);
            this.edtSucheBookmarkCode.TabIndex = 6;
            // 
            // lblSucheBookmarkCode
            // 
            this.lblSucheBookmarkCode.Location = new System.Drawing.Point(30, 100);
            this.lblSucheBookmarkCode.Name = "lblSucheBookmarkCode";
            this.lblSucheBookmarkCode.Size = new System.Drawing.Size(87, 24);
            this.lblSucheBookmarkCode.TabIndex = 5;
            this.lblSucheBookmarkCode.Text = "Typ";
            // 
            // edtSucheCategory
            // 
            this.edtSucheCategory.EditValue = "";
            this.edtSucheCategory.Location = new System.Drawing.Point(123, 40);
            this.edtSucheCategory.Name = "edtSucheCategory";
            this.edtSucheCategory.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheCategory.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheCategory.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheCategory.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheCategory.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheCategory.Properties.Appearance.Options.UseFont = true;
            this.edtSucheCategory.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheCategory.Size = new System.Drawing.Size(268, 24);
            this.edtSucheCategory.TabIndex = 2;
            // 
            // edtSucheDescription
            // 
            this.edtSucheDescription.Location = new System.Drawing.Point(512, 40);
            this.edtSucheDescription.Name = "edtSucheDescription";
            this.edtSucheDescription.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheDescription.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheDescription.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheDescription.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheDescription.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheDescription.Properties.Appearance.Options.UseFont = true;
            this.edtSucheDescription.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheDescription.Properties.MaxLength = 40;
            this.edtSucheDescription.Size = new System.Drawing.Size(268, 24);
            this.edtSucheDescription.TabIndex = 10;
            // 
            // edtSucheSQL
            // 
            this.edtSucheSQL.Location = new System.Drawing.Point(512, 70);
            this.edtSucheSQL.Name = "edtSucheSQL";
            this.edtSucheSQL.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheSQL.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheSQL.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheSQL.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheSQL.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheSQL.Properties.Appearance.Options.UseFont = true;
            this.edtSucheSQL.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheSQL.Properties.MaxLength = 40;
            this.edtSucheSQL.Size = new System.Drawing.Size(268, 24);
            this.edtSucheSQL.TabIndex = 12;
            // 
            // lblRowCount
            // 
            this.lblRowCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRowCount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRowCount.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblRowCount.Location = new System.Drawing.Point(623, 216);
            this.lblRowCount.Name = "lblRowCount";
            this.lblRowCount.Size = new System.Drawing.Size(168, 20);
            this.lblRowCount.TabIndex = 3;
            this.lblRowCount.Text = "Anzahl Datensäzte: <count>";
            this.lblRowCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edtSucheModulID
            // 
            this.edtSucheModulID.Location = new System.Drawing.Point(512, 100);
            this.edtSucheModulID.LOVFilter = "(ModulID > 0 OR ModulID IN (0, -1, -7))";
            this.edtSucheModulID.LOVFilterWhereAppend = true;
            this.edtSucheModulID.LOVName = "Modul";
            this.edtSucheModulID.Name = "edtSucheModulID";
            this.edtSucheModulID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheModulID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheModulID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheModulID.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheModulID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheModulID.Properties.Appearance.Options.UseFont = true;
            this.edtSucheModulID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheModulID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheModulID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheModulID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheModulID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtSucheModulID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtSucheModulID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheModulID.Properties.NullText = "";
            this.edtSucheModulID.Properties.ShowFooter = false;
            this.edtSucheModulID.Properties.ShowHeader = false;
            this.edtSucheModulID.Size = new System.Drawing.Size(268, 24);
            this.edtSucheModulID.TabIndex = 14;
            // 
            // lblSucheModulID
            // 
            this.lblSucheModulID.Location = new System.Drawing.Point(419, 100);
            this.lblSucheModulID.Name = "lblSucheModulID";
            this.lblSucheModulID.Size = new System.Drawing.Size(87, 24);
            this.lblSucheModulID.TabIndex = 13;
            this.lblSucheModulID.Text = "Modul";
            // 
            // chkSucheAlwaysVisible
            // 
            this.chkSucheAlwaysVisible.EditValue = false;
            this.chkSucheAlwaysVisible.Location = new System.Drawing.Point(512, 130);
            this.chkSucheAlwaysVisible.Name = "chkSucheAlwaysVisible";
            this.chkSucheAlwaysVisible.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkSucheAlwaysVisible.Properties.Appearance.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chkSucheAlwaysVisible.Properties.Appearance.Options.UseBackColor = true;
            this.chkSucheAlwaysVisible.Properties.Appearance.Options.UseFont = true;
            this.chkSucheAlwaysVisible.Properties.Caption = "Immer sichtbar";
            this.chkSucheAlwaysVisible.Size = new System.Drawing.Size(137, 19);
            this.chkSucheAlwaysVisible.TabIndex = 15;
            // 
            // chkSucheSystem
            // 
            this.chkSucheSystem.EditValue = false;
            this.chkSucheSystem.Location = new System.Drawing.Point(512, 155);
            this.chkSucheSystem.Name = "chkSucheSystem";
            this.chkSucheSystem.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkSucheSystem.Properties.Appearance.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chkSucheSystem.Properties.Appearance.Options.UseBackColor = true;
            this.chkSucheSystem.Properties.Appearance.Options.UseFont = true;
            this.chkSucheSystem.Properties.Caption = "System";
            this.chkSucheSystem.Size = new System.Drawing.Size(137, 19);
            this.chkSucheSystem.TabIndex = 16;
            // 
            // chkSucheNichtSystem
            // 
            this.chkSucheNichtSystem.EditValue = false;
            this.chkSucheNichtSystem.Location = new System.Drawing.Point(512, 180);
            this.chkSucheNichtSystem.Name = "chkSucheNichtSystem";
            this.chkSucheNichtSystem.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkSucheNichtSystem.Properties.Appearance.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chkSucheNichtSystem.Properties.Appearance.Options.UseBackColor = true;
            this.chkSucheNichtSystem.Properties.Appearance.Options.UseFont = true;
            this.chkSucheNichtSystem.Properties.Caption = "Benutzerdefiniert";
            this.chkSucheNichtSystem.Size = new System.Drawing.Size(137, 19);
            this.chkSucheNichtSystem.TabIndex = 17;
            // 
            // CtlBookmarkStandard
            // 
            this.ActiveSQLQuery = this.qryBookmark;
            this.Controls.Add(this.lblRowCount);
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.pnlBottom);
            this.Name = "CtlBookmarkStandard";
            this.Size = new System.Drawing.Size(800, 550);
            this.Load += new System.EventHandler(this.CtlBookmarkStandard_Load);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.splitter, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.lblRowCount, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBookmark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBookmark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBookmark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBookmarkName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSQL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSQL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkReadOnly.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBookmarkCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBookmarkCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBookmarkCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTableName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTableName.Properties)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtBookmarkName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModulID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSystem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAlwaysVisible.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBookmarkName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTableName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheTableName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBookmarkName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheSQL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBookmarkCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBookmarkCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBookmarkCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheSQL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRowCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheModulID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheModulID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheModulID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheAlwaysVisible.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheSystem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheNichtSystem.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissButton btnCopy;
        private KiSS4.Gui.KissCheckEdit chkAlwaysVisible;
        private KiSS4.Gui.KissCheckEdit chkReadOnly;
        private KiSS4.Gui.KissCheckEdit chkSucheAlwaysVisible;
        private KiSS4.Gui.KissCheckEdit chkSucheNichtSystem;
        private KiSS4.Gui.KissCheckEdit chkSucheSystem;
        private KiSS4.Gui.KissCheckEdit chkSystem;
        private DevExpress.XtraGrid.Columns.GridColumn colAlwaysVisible;
        private DevExpress.XtraGrid.Columns.GridColumn colBookmarkCode;
        private DevExpress.XtraGrid.Columns.GridColumn colBookmarkName;
        private DevExpress.XtraGrid.Columns.GridColumn colCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colModul;
        private DevExpress.XtraGrid.Columns.GridColumn colSystem;
        private DevExpress.XtraGrid.Columns.GridColumn colTableName;
        private KiSS4.Gui.KissLookUpEdit edtBookmarkCode;
        private KiSS4.Gui.KissLookUpEdit edtModulID;
        private KiSS4.Gui.KissMemoEdit edtSQL;
        private KiSS4.Gui.KissLookUpEdit edtSucheBookmarkCode;
        private KiSS4.Gui.KissTextEdit edtSucheBookmarkName;
        private KiSS4.Gui.KissTextEdit edtSucheCategory;
        private KiSS4.Gui.KissTextEdit edtSucheDescription;
        private KiSS4.Gui.KissLookUpEdit edtSucheModulID;
        private KiSS4.Gui.KissTextEdit edtSucheSQL;
        private KiSS4.Gui.KissComboBox edtSucheTableName;
        private KiSS4.Gui.KissComboBox edtTableName;
        private KiSS4.Gui.KissGrid grdBookmark;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBookmark;
        private KiSS4.Gui.KissLabel lblBookmarkCode;
        private KiSS4.Gui.KissLabel lblBookmarkName;
        private KiSS4.Gui.KissLabel lblCategory;
        private KiSS4.Gui.KissLabel lblDescription;
        private KiSS4.Gui.KissLabel lblModulID;
        private KiSS4.Gui.KissLabel lblRowCount;
        private KiSS4.Gui.KissLabel lblSQL;
        private KiSS4.Gui.KissLabel lblSucheBookmarkCode;
        private KiSS4.Gui.KissLabel lblSucheBookmarkName;
        private KiSS4.Gui.KissLabel lblSucheCategory;
        private KiSS4.Gui.KissLabel lblSucheDescription;
        private KiSS4.Gui.KissLabel lblSucheModulID;
        private KiSS4.Gui.KissLabel lblSucheSQL;
        private KiSS4.Gui.KissLabel lblSucheTableName;
        private KiSS4.Gui.KissLabel lblTableName;
        private System.Windows.Forms.Panel pnlBottom;
        private KiSS4.DB.SqlQuery qryBookmark;
        private KiSS4.Gui.KissSplitterCollapsible splitter;
        private Gui.KissTextEditML edtBookmarkName;
        private Gui.KissTextEditML edtCategory;
        private Gui.KissMemoEditML edtDescriptionML;
    }
}
