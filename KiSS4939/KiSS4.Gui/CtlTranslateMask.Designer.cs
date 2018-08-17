using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS4.Gui
{
    partial class CtlTranslateMask
    {
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
            this.qryControls = new KiSS4.DB.SqlQuery(this.components);
            this.FieldID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.grdControlTypes = new KiSS4.Gui.KissGrid();
            this.qryControlTypes = new KiSS4.DB.SqlQuery(this.components);
            this.grvControlTypes = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcControlType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdControls = new KiSS4.Gui.KissGrid();
            this.grvControls = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcDefaultText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDefaultText2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlTranslation = new System.Windows.Forms.Panel();
            this.pnlText = new System.Windows.Forms.Panel();
            this.pnlLanguage = new System.Windows.Forms.Panel();
            this.edtLanguageFrom2 = new KiSS4.Gui.KissLookUpEdit();
            this.edtLanguageTo = new KiSS4.Gui.KissLookUpEdit();
            this.edtLanguageFrom1 = new KiSS4.Gui.KissLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.qryControls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdControlTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryControlTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvControlTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdControls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvControls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.pnlTranslation.SuspendLayout();
            this.pnlText.SuspendLayout();
            this.pnlLanguage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtLanguageFrom2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLanguageFrom2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLanguageTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLanguageTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLanguageFrom1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLanguageFrom1.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // qryControls
            //
            this.qryControls.BatchUpdate = true;
            this.qryControls.HostControl = this;
            this.qryControls.TableName = "@Controls";
            //
            // FieldID
            //
            this.FieldID.Caption = "FieldID";
            this.FieldID.FieldName = "FieldID";
            this.FieldID.Name = "FieldID";
            this.FieldID.VisibleIndex = 1;
            //
            // grdControlTypes
            //
            this.grdControlTypes.DataSource = this.qryControlTypes;
            this.grdControlTypes.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdControlTypes.EmbeddedNavigator.Name = "";
            this.grdControlTypes.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdControlTypes.Location = new System.Drawing.Point(0, 0);
            this.grdControlTypes.MainView = this.grvControlTypes;
            this.grdControlTypes.Name = "grdControlTypes";
            this.grdControlTypes.Size = new System.Drawing.Size(184, 320);
            this.grdControlTypes.TabIndex = 1;
            this.grdControlTypes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvControlTypes});
            //
            // qryControlTypes
            //
            this.qryControlTypes.BatchUpdate = true;
            this.qryControlTypes.HostControl = this;
            this.qryControlTypes.PositionChanged += new System.EventHandler(this.qryControlTypes_PositionChanged);
            //
            // grvControlTypes
            //
            this.grvControlTypes.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvControlTypes.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvControlTypes.Appearance.Empty.Options.UseBackColor = true;
            this.grvControlTypes.Appearance.Empty.Options.UseFont = true;
            this.grvControlTypes.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvControlTypes.Appearance.EvenRow.Options.UseFont = true;
            this.grvControlTypes.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvControlTypes.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvControlTypes.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvControlTypes.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvControlTypes.Appearance.FocusedCell.Options.UseFont = true;
            this.grvControlTypes.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvControlTypes.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvControlTypes.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvControlTypes.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvControlTypes.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvControlTypes.Appearance.FocusedRow.Options.UseFont = true;
            this.grvControlTypes.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvControlTypes.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvControlTypes.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvControlTypes.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvControlTypes.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvControlTypes.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvControlTypes.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvControlTypes.Appearance.GroupRow.Options.UseFont = true;
            this.grvControlTypes.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvControlTypes.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvControlTypes.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvControlTypes.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvControlTypes.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvControlTypes.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvControlTypes.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvControlTypes.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvControlTypes.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvControlTypes.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvControlTypes.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvControlTypes.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvControlTypes.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvControlTypes.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvControlTypes.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvControlTypes.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvControlTypes.Appearance.OddRow.Options.UseFont = true;
            this.grvControlTypes.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvControlTypes.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvControlTypes.Appearance.Row.Options.UseBackColor = true;
            this.grvControlTypes.Appearance.Row.Options.UseFont = true;
            this.grvControlTypes.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvControlTypes.Appearance.SelectedRow.Options.UseFont = true;
            this.grvControlTypes.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvControlTypes.Appearance.VertLine.Options.UseBackColor = true;
            this.grvControlTypes.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvControlTypes.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcControlType});
            this.grvControlTypes.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvControlTypes.GridControl = this.grdControlTypes;
            this.grvControlTypes.Name = "grvControlTypes";
            this.grvControlTypes.OptionsBehavior.AutoPopulateColumns = false;
            this.grvControlTypes.OptionsBehavior.Editable = false;
            this.grvControlTypes.OptionsCustomization.AllowFilter = false;
            this.grvControlTypes.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvControlTypes.OptionsNavigation.AutoFocusNewRow = true;
            this.grvControlTypes.OptionsNavigation.UseTabKey = false;
            this.grvControlTypes.OptionsView.ColumnAutoWidth = false;
            this.grvControlTypes.OptionsView.ShowColumnHeaders = false;
            this.grvControlTypes.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvControlTypes.OptionsView.ShowGroupPanel = false;
            this.grvControlTypes.OptionsView.ShowIndicator = false;
            this.grvControlTypes.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViews_FocusedRowChanged);
            this.grvControlTypes.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gridViews_BeforeLeaveRow);
            //
            // gcControlType
            //
            this.gcControlType.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gcControlType.AppearanceCell.Options.UseBackColor = true;
            this.gcControlType.Caption = "ControlType";
            this.gcControlType.FieldName = "Text";
            this.gcControlType.Name = "gcControlType";
            this.gcControlType.OptionsColumn.AllowEdit = false;
            this.gcControlType.Visible = true;
            this.gcControlType.VisibleIndex = 0;
            this.gcControlType.Width = 180;
            //
            // grdControls
            //
            this.grdControls.DataSource = this.qryControls;
            this.grdControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdControls.EmbeddedNavigator.Name = "";
            this.grdControls.Location = new System.Drawing.Point(0, 0);
            this.grdControls.MainView = this.grvControls;
            this.grdControls.Name = "grdControls";
            this.grdControls.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1});
            this.grdControls.Size = new System.Drawing.Size(680, 296);
            this.grdControls.TabIndex = 2;
            this.grdControls.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvControls,
            this.gridView3});
            //
            // grvControls
            //
            this.grvControls.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvControls.Appearance.Empty.Options.UseBackColor = true;
            this.grvControls.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcDefaultText,
            this.gcDefaultText2,
            this.gcText});
            this.grvControls.GridControl = this.grdControls;
            this.grvControls.Name = "grvControls";
            this.grvControls.OptionsCustomization.AllowFilter = false;
            this.grvControls.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvControls.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.grvControls.OptionsView.ShowColumnHeaders = false;
            this.grvControls.OptionsView.ShowGroupPanel = false;
            this.grvControls.OptionsView.ShowIndicator = false;
            this.grvControls.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViews_FocusedRowChanged);
            this.grvControls.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gridViews_BeforeLeaveRow);
            this.grvControls.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvControls_CellValueChanging);
            //
            // gcDefaultText
            //
            this.gcDefaultText.AppearanceCell.BackColor = System.Drawing.Color.Bisque;
            this.gcDefaultText.AppearanceCell.Options.UseBackColor = true;
            this.gcDefaultText.Caption = "DefaultText";
            this.gcDefaultText.FieldName = "DefaultText";
            this.gcDefaultText.Name = "gcDefaultText";
            this.gcDefaultText.OptionsColumn.AllowEdit = false;
            this.gcDefaultText.Visible = true;
            this.gcDefaultText.VisibleIndex = 0;
            //
            // gcDefaultText2
            //
            this.gcDefaultText2.AppearanceCell.BackColor = System.Drawing.Color.Bisque;
            this.gcDefaultText2.AppearanceCell.Options.UseBackColor = true;
            this.gcDefaultText2.Caption = "DefaultText2";
            this.gcDefaultText2.FieldName = "DefaultText2";
            this.gcDefaultText2.Name = "gcDefaultText2";
            this.gcDefaultText2.OptionsColumn.AllowEdit = false;
            this.gcDefaultText2.Visible = true;
            this.gcDefaultText2.VisibleIndex = 1;
            //
            // gcText
            //
            this.gcText.Caption = "Text";
            this.gcText.FieldName = "Text";
            this.gcText.Name = "gcText";
            this.gcText.Visible = true;
            this.gcText.VisibleIndex = 2;
            //
            // repositoryItemLookUpEdit1
            //
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            //
            // gridView3
            //
            this.gridView3.GridControl = this.grdControls;
            this.gridView3.Name = "gridView3";
            //
            // pnlTranslation
            //
            this.pnlTranslation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.pnlTranslation.Controls.Add(this.pnlText);
            this.pnlTranslation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTranslation.Location = new System.Drawing.Point(184, 0);
            this.pnlTranslation.Name = "pnlTranslation";
            this.pnlTranslation.Size = new System.Drawing.Size(680, 320);
            this.pnlTranslation.TabIndex = 3;
            //
            // pnlText
            //
            this.pnlText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlText.Controls.Add(this.grdControls);
            this.pnlText.Location = new System.Drawing.Point(0, 24);
            this.pnlText.Name = "pnlText";
            this.pnlText.Size = new System.Drawing.Size(680, 296);
            this.pnlText.TabIndex = 3;
            //
            // pnlLanguage
            //
            this.pnlLanguage.Controls.Add(this.edtLanguageFrom2);
            this.pnlLanguage.Controls.Add(this.edtLanguageTo);
            this.pnlLanguage.Controls.Add(this.edtLanguageFrom1);
            this.pnlLanguage.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLanguage.Location = new System.Drawing.Point(184, 0);
            this.pnlLanguage.Name = "pnlLanguage";
            this.pnlLanguage.Size = new System.Drawing.Size(680, 24);
            this.pnlLanguage.TabIndex = 4;
            //
            // edtLanguageFrom2
            //
            this.edtLanguageFrom2.AllowNull = false;
            this.edtLanguageFrom2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.edtLanguageFrom2.Location = new System.Drawing.Point(226, 0);
            this.edtLanguageFrom2.LOVName = "Sprache";
            this.edtLanguageFrom2.Name = "edtLanguageFrom2";
            this.edtLanguageFrom2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtLanguageFrom2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLanguageFrom2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLanguageFrom2.Properties.Appearance.Options.UseBackColor = true;
            this.edtLanguageFrom2.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLanguageFrom2.Properties.Appearance.Options.UseFont = true;
            this.edtLanguageFrom2.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtLanguageFrom2.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtLanguageFrom2.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtLanguageFrom2.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtLanguageFrom2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtLanguageFrom2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtLanguageFrom2.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtLanguageFrom2.Properties.NullText = "";
            this.edtLanguageFrom2.Properties.ShowFooter = false;
            this.edtLanguageFrom2.Properties.ShowHeader = false;
            this.edtLanguageFrom2.Size = new System.Drawing.Size(219, 24);
            this.edtLanguageFrom2.TabIndex = 2;
            this.edtLanguageFrom2.EditValueChanged += new System.EventHandler(this.edtLanguageFrom_EditValueChanged);
            //
            // edtLanguageTo
            //
            this.edtLanguageTo.AllowNull = false;
            this.edtLanguageTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.edtLanguageTo.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtLanguageTo.Location = new System.Drawing.Point(451, 0);
            this.edtLanguageTo.LOVName = "Sprache";
            this.edtLanguageTo.Name = "edtLanguageTo";
            this.edtLanguageTo.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtLanguageTo.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLanguageTo.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLanguageTo.Properties.Appearance.Options.UseBackColor = true;
            this.edtLanguageTo.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLanguageTo.Properties.Appearance.Options.UseFont = true;
            this.edtLanguageTo.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtLanguageTo.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtLanguageTo.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtLanguageTo.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtLanguageTo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtLanguageTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtLanguageTo.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtLanguageTo.Properties.NullText = "";
            this.edtLanguageTo.Properties.ReadOnly = true;
            this.edtLanguageTo.Properties.ShowFooter = false;
            this.edtLanguageTo.Properties.ShowHeader = false;
            this.edtLanguageTo.Size = new System.Drawing.Size(229, 24);
            this.edtLanguageTo.TabIndex = 1;
            //
            // edtLanguageFrom1
            //
            this.edtLanguageFrom1.AllowNull = false;
            this.edtLanguageFrom1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.edtLanguageFrom1.Location = new System.Drawing.Point(0, 0);
            this.edtLanguageFrom1.LOVName = "Sprache";
            this.edtLanguageFrom1.Name = "edtLanguageFrom1";
            this.edtLanguageFrom1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtLanguageFrom1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLanguageFrom1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLanguageFrom1.Properties.Appearance.Options.UseBackColor = true;
            this.edtLanguageFrom1.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLanguageFrom1.Properties.Appearance.Options.UseFont = true;
            this.edtLanguageFrom1.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtLanguageFrom1.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtLanguageFrom1.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtLanguageFrom1.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtLanguageFrom1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtLanguageFrom1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtLanguageFrom1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtLanguageFrom1.Properties.NullText = "";
            this.edtLanguageFrom1.Properties.ShowFooter = false;
            this.edtLanguageFrom1.Properties.ShowHeader = false;
            this.edtLanguageFrom1.Size = new System.Drawing.Size(220, 24);
            this.edtLanguageFrom1.TabIndex = 0;
            this.edtLanguageFrom1.EditValueChanged += new System.EventHandler(this.edtLanguageFrom_EditValueChanged);
            //
            // CtlTranslateMask
            //
            this.Controls.Add(this.pnlLanguage);
            this.Controls.Add(this.pnlTranslation);
            this.Controls.Add(this.grdControlTypes);
            this.Name = "CtlTranslateMask";
            this.Size = new System.Drawing.Size(864, 320);
            this.Leave += new System.EventHandler(this.CtlTranslateMask_Leave);
            this.SaveData += new System.EventHandler(this.CtlTranslateMask_SaveData);
            ((System.ComponentModel.ISupportInitialize)(this.qryControls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdControlTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryControlTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvControlTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdControls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvControls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.pnlTranslation.ResumeLayout(false);
            this.pnlText.ResumeLayout(false);
            this.pnlLanguage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtLanguageFrom2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLanguageFrom2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLanguageTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLanguageTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLanguageFrom1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLanguageFrom1)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraTreeList.Columns.TreeListColumn FieldID;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissLookUpEdit edtLanguageFrom1;
        private KissLookUpEdit edtLanguageFrom2;
        private KiSS4.Gui.KissLookUpEdit edtLanguageTo;
        private DevExpress.XtraGrid.Columns.GridColumn gcControlType;
        private DevExpress.XtraGrid.Columns.GridColumn gcDefaultText;
        private DevExpress.XtraGrid.Columns.GridColumn gcDefaultText2;
        private DevExpress.XtraGrid.Columns.GridColumn gcText;
        private KiSS4.Gui.KissGrid grdControlTypes;
        private KiSS4.Gui.KissGrid grdControls;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Views.Grid.GridView grvControlTypes;
        private DevExpress.XtraGrid.Views.Grid.GridView grvControls;
        private System.Windows.Forms.Panel pnlLanguage;
        private System.Windows.Forms.Panel pnlText;
        private System.Windows.Forms.Panel pnlTranslation;
        private KiSS4.DB.SqlQuery qryControlTypes;
        private KiSS4.DB.SqlQuery qryControls;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;

    }
}
