namespace KiSS4.Administration
{
    partial class CtlConfig
    {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlConfig));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panTree = new System.Windows.Forms.Panel();
            this.treConfigTree = new KiSS4.Gui.KissTree();
            this.colKey = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colValue = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTreeAmount = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colKeyPath = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDisplayPath = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colFilterNSEID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.panBottomTree = new System.Windows.Forms.Panel();
            this.panBottomFilter = new System.Windows.Forms.Panel();
            this.edtFilterNamespaceExtension = new KiSS4.Gui.KissLookUpEdit();
            this.btnResetNamespaceFilter = new KiSS4.Gui.KissButton();
            this.btnResetKeyFilter = new KiSS4.Gui.KissButton();
            this.lblFilterNamespaceExtension = new KiSS4.Gui.KissLabel();
            this.lblFilterKey = new KiSS4.Gui.KissLabel();
            this.edtFilterKey = new KiSS4.Gui.KissTextEdit();
            this.qryValue = new KiSS4.DB.SqlQuery(this.components);
            this.panBottomButtons = new System.Windows.Forms.Panel();
            this.chkShowFilter = new KiSS4.Gui.KissCheckEdit();
            this.btnCollapseAll = new KiSS4.Gui.KissButton();
            this.btnExpandAll = new KiSS4.Gui.KissButton();
            this.splitter = new KiSS4.Gui.KissSplitter();
            this.panDetails = new System.Windows.Forms.Panel();
            this.edtKeyPathId = new KiSS4.Gui.KissTextEdit();
            this.edtValueCode = new KiSS4.Gui.KissTextEdit();
            this.lblKeyPathId = new KiSS4.Gui.KissLabel();
            this.edtDescription = new KiSS4.Gui.KissMemoEditML();
            this.edtKeyPath = new KiSS4.Gui.KissTextEditML();
            this.edtValueCheckedLookupEdit = new KiSS4.Gui.KissCheckedLookupEdit();
            this.edtNamespaceExtension = new KiSS4.Gui.KissLookUpEdit();
            this.lblDatumVon = new KiSS4.Gui.KissLabel();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtValueDateEdit = new KiSS4.Gui.KissDateEdit();
            this.edtValueCalcEdit = new KiSS4.Gui.KissCalcEdit();
            this.chkSystem = new KiSS4.Gui.KissCheckEdit();
            this.edtValueCheckEdit = new KiSS4.Gui.KissCheckEdit();
            this.edtValueMemoEdit = new KiSS4.Gui.KissMemoEdit();
            this.edtOriginalValue = new KiSS4.Gui.KissTextEdit();
            this.lblValue = new KiSS4.Gui.KissLabel();
            this.lblNamespaceExtension = new KiSS4.Gui.KissLabel();
            this.lblDescription = new KiSS4.Gui.KissLabel();
            this.lblOriginalValue = new KiSS4.Gui.KissLabel();
            this.lblValueCode = new KiSS4.Gui.KissLabel();
            this.lblKeyPath = new KiSS4.Gui.KissLabel();
            this.edtValueTextEdit = new KiSS4.Gui.KissTextEdit();
            this.qryConfigTree = new KiSS4.DB.SqlQuery(this.components);
            this.panConfiguration = new System.Windows.Forms.Panel();
            this.splitterConfiguration = new KiSS4.Gui.KissSplitterCollapsible();
            this.panHistory = new System.Windows.Forms.Panel();
            this.grdXConfigHist = new KiSS4.Gui.KissGrid();
            this.grvXConfigHist = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colXConfigHistValueCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colXConfigHistValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colXConfigHistDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colXConfigHistActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treConfigTree)).BeginInit();
            this.panBottomTree.SuspendLayout();
            this.panBottomFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilterNamespaceExtension)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilterNamespaceExtension.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilterNamespaceExtension)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilterKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilterKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryValue)).BeginInit();
            this.panBottomButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowFilter.Properties)).BeginInit();
            this.panDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtKeyPathId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValueCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKeyPathId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKeyPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValueCheckedLookupEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNamespaceExtension)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNamespaceExtension.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValueDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValueCalcEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSystem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValueCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValueMemoEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOriginalValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNamespaceExtension)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblOriginalValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValueCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKeyPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValueTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryConfigTree)).BeginInit();
            this.panConfiguration.SuspendLayout();
            this.panHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdXConfigHist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvXConfigHist)).BeginInit();
            this.SuspendLayout();
            // 
            // panTree
            // 
            this.panTree.Controls.Add(this.treConfigTree);
            this.panTree.Controls.Add(this.panBottomTree);
            this.panTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.panTree.Location = new System.Drawing.Point(0, 0);
            this.panTree.Name = "panTree";
            this.panTree.Size = new System.Drawing.Size(490, 730);
            this.panTree.TabIndex = 0;
            // 
            // treConfigTree
            // 
            this.treConfigTree.AllowSortTree = true;
            this.treConfigTree.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.treConfigTree.Appearance.Empty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.treConfigTree.Appearance.Empty.Options.UseBackColor = true;
            this.treConfigTree.Appearance.Empty.Options.UseForeColor = true;
            this.treConfigTree.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.treConfigTree.Appearance.EvenRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treConfigTree.Appearance.EvenRow.Options.UseBackColor = true;
            this.treConfigTree.Appearance.EvenRow.Options.UseForeColor = true;
            this.treConfigTree.Appearance.FocusedCell.BackColor = System.Drawing.Color.Transparent;
            this.treConfigTree.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.treConfigTree.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treConfigTree.Appearance.FocusedCell.Options.UseForeColor = true;
            this.treConfigTree.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.treConfigTree.Appearance.FocusedRow.Options.UseForeColor = true;
            this.treConfigTree.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treConfigTree.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treConfigTree.Appearance.FooterPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treConfigTree.Appearance.FooterPanel.Options.UseBackColor = true;
            this.treConfigTree.Appearance.FooterPanel.Options.UseFont = true;
            this.treConfigTree.Appearance.FooterPanel.Options.UseForeColor = true;
            this.treConfigTree.Appearance.GroupButton.BackColor = System.Drawing.Color.Transparent;
            this.treConfigTree.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.treConfigTree.Appearance.GroupButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treConfigTree.Appearance.GroupButton.Options.UseBackColor = true;
            this.treConfigTree.Appearance.GroupButton.Options.UseFont = true;
            this.treConfigTree.Appearance.GroupButton.Options.UseForeColor = true;
            this.treConfigTree.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(226)))), ((int)(((byte)(184)))));
            this.treConfigTree.Appearance.GroupFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treConfigTree.Appearance.GroupFooter.Options.UseBackColor = true;
            this.treConfigTree.Appearance.GroupFooter.Options.UseForeColor = true;
            this.treConfigTree.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.treConfigTree.Appearance.HeaderPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.treConfigTree.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treConfigTree.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.treConfigTree.Appearance.HeaderPanel.Options.UseFont = true;
            this.treConfigTree.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.treConfigTree.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.treConfigTree.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treConfigTree.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.treConfigTree.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.treConfigTree.Appearance.HideSelectionRow.Options.UseFont = true;
            this.treConfigTree.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.treConfigTree.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treConfigTree.Appearance.HorzLine.ForeColor = System.Drawing.Color.Red;
            this.treConfigTree.Appearance.HorzLine.Options.UseBackColor = true;
            this.treConfigTree.Appearance.HorzLine.Options.UseForeColor = true;
            this.treConfigTree.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(236)))), ((int)(((byte)(215)))));
            this.treConfigTree.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treConfigTree.Appearance.OddRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treConfigTree.Appearance.OddRow.Options.UseBackColor = true;
            this.treConfigTree.Appearance.OddRow.Options.UseFont = true;
            this.treConfigTree.Appearance.OddRow.Options.UseForeColor = true;
            this.treConfigTree.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.treConfigTree.Appearance.Preview.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treConfigTree.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treConfigTree.Appearance.Preview.Options.UseBackColor = true;
            this.treConfigTree.Appearance.Preview.Options.UseFont = true;
            this.treConfigTree.Appearance.Preview.Options.UseForeColor = true;
            this.treConfigTree.Appearance.Row.BackColor = System.Drawing.Color.Transparent;
            this.treConfigTree.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treConfigTree.Appearance.Row.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treConfigTree.Appearance.Row.Options.UseBackColor = true;
            this.treConfigTree.Appearance.Row.Options.UseFont = true;
            this.treConfigTree.Appearance.Row.Options.UseForeColor = true;
            this.treConfigTree.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.treConfigTree.Appearance.SelectedRow.Options.UseForeColor = true;
            this.treConfigTree.Appearance.TreeLine.BackColor = System.Drawing.Color.Gray;
            this.treConfigTree.Appearance.TreeLine.Options.UseBackColor = true;
            this.treConfigTree.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treConfigTree.Appearance.VertLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(166)))), ((int)(((byte)(70)))));
            this.treConfigTree.Appearance.VertLine.Options.UseBackColor = true;
            this.treConfigTree.Appearance.VertLine.Options.UseForeColor = true;
            this.treConfigTree.Appearance.VertLine.Options.UseTextOptions = true;
            this.treConfigTree.Appearance.VertLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.treConfigTree.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colKey,
            this.colValue,
            this.colTreeAmount,
            this.colKeyPath,
            this.colDisplayPath,
            this.colFilterNSEID});
            this.treConfigTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treConfigTree.ImageIndexFieldName = "IconID";
            this.treConfigTree.Location = new System.Drawing.Point(0, 0);
            this.treConfigTree.Name = "treConfigTree";
            this.treConfigTree.OptionsBehavior.AutoSelectAllInEditor = false;
            this.treConfigTree.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.treConfigTree.OptionsBehavior.Editable = false;
            this.treConfigTree.OptionsBehavior.EnableFiltering = true;
            this.treConfigTree.OptionsBehavior.KeepSelectedOnClick = false;
            this.treConfigTree.OptionsBehavior.MoveOnEdit = false;
            this.treConfigTree.OptionsBehavior.ShowToolTips = false;
            this.treConfigTree.OptionsBehavior.SmartMouseHover = false;
            this.treConfigTree.OptionsMenu.EnableColumnMenu = false;
            this.treConfigTree.OptionsMenu.EnableFooterMenu = false;
            this.treConfigTree.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treConfigTree.OptionsView.AutoWidth = false;
            this.treConfigTree.OptionsView.EnableAppearanceEvenRow = true;
            this.treConfigTree.OptionsView.EnableAppearanceOddRow = true;
            this.treConfigTree.OptionsView.ShowIndicator = false;
            this.treConfigTree.OptionsView.ShowVertLines = false;
            this.treConfigTree.Size = new System.Drawing.Size(490, 620);
            this.treConfigTree.Styles.AddReplace("PressedColumn", new DevExpress.Utils.ViewStyle("PressedColumn", "TreeList", new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel), "HeaderPanel", ((DevExpress.Utils.StyleOptions)(((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor)
                    | DevExpress.Utils.StyleOptions.UseForeColor))), true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222))))), System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))));
            this.treConfigTree.TabIndex = 0;
            this.treConfigTree.BeforeFocusNode += new DevExpress.XtraTreeList.BeforeFocusNodeEventHandler(this.treConfigTree_BeforeFocusNode);
            this.treConfigTree.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treConfigTree_FocusedNodeChanged);
            this.treConfigTree.FilterNode += new DevExpress.XtraTreeList.FilterNodeEventHandler(this.treConfigTree_FilterNode);
            // 
            // colKey
            // 
            this.colKey.Caption = "Schlüssel";
            this.colKey.FieldName = "colKey";
            this.colKey.Name = "colKey";
            this.colKey.OptionsColumn.AllowSort = false;
            this.colKey.VisibleIndex = 0;
            this.colKey.Width = 200;
            // 
            // colValue
            // 
            this.colValue.Caption = "Wert";
            this.colValue.FieldName = "colValue";
            this.colValue.Name = "colValue";
            this.colValue.OptionsColumn.AllowSort = false;
            this.colValue.VisibleIndex = 1;
            this.colValue.Width = 200;
            // 
            // colTreeAmount
            // 
            this.colTreeAmount.Caption = "Anzahl";
            this.colTreeAmount.FieldName = "Amount";
            this.colTreeAmount.Name = "colTreeAmount";
            this.colTreeAmount.OptionsColumn.AllowSort = false;
            this.colTreeAmount.VisibleIndex = 2;
            this.colTreeAmount.Width = 60;
            // 
            // colKeyPath
            // 
            this.colKeyPath.Caption = "colKeyPath";
            this.colKeyPath.FieldName = "colKeyPath";
            this.colKeyPath.Name = "colKeyPath";
            this.colKeyPath.OptionsColumn.AllowSort = false;
            // 
            // colDisplayPath
            // 
            this.colDisplayPath.Caption = "colDisplayPath";
            this.colDisplayPath.FieldName = "colDisplayPath";
            this.colDisplayPath.Name = "colDisplayPath";
            this.colDisplayPath.OptionsColumn.AllowSort = false;
            // 
            // colFilterNSEID
            // 
            this.colFilterNSEID.Caption = "colFilterNSEID";
            this.colFilterNSEID.FieldName = "FilterNSEID";
            this.colFilterNSEID.Name = "colFilterNSEID";
            this.colFilterNSEID.OptionsColumn.AllowSort = false;
            // 
            // panBottomTree
            // 
            this.panBottomTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panBottomTree.Controls.Add(this.panBottomFilter);
            this.panBottomTree.Controls.Add(this.panBottomButtons);
            this.panBottomTree.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panBottomTree.Location = new System.Drawing.Point(0, 620);
            this.panBottomTree.Name = "panBottomTree";
            this.panBottomTree.Size = new System.Drawing.Size(490, 110);
            this.panBottomTree.TabIndex = 1;
            // 
            // panBottomFilter
            // 
            this.panBottomFilter.Controls.Add(this.edtFilterNamespaceExtension);
            this.panBottomFilter.Controls.Add(this.btnResetNamespaceFilter);
            this.panBottomFilter.Controls.Add(this.btnResetKeyFilter);
            this.panBottomFilter.Controls.Add(this.lblFilterNamespaceExtension);
            this.panBottomFilter.Controls.Add(this.lblFilterKey);
            this.panBottomFilter.Controls.Add(this.edtFilterKey);
            this.panBottomFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panBottomFilter.Location = new System.Drawing.Point(0, 36);
            this.panBottomFilter.Name = "panBottomFilter";
            this.panBottomFilter.Size = new System.Drawing.Size(488, 72);
            this.panBottomFilter.TabIndex = 1;
            // 
            // edtFilterNamespaceExtension
            // 
            this.edtFilterNamespaceExtension.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtFilterNamespaceExtension.Location = new System.Drawing.Point(94, 39);
            this.edtFilterNamespaceExtension.Name = "edtFilterNamespaceExtension";
            this.edtFilterNamespaceExtension.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFilterNamespaceExtension.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFilterNamespaceExtension.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFilterNamespaceExtension.Properties.Appearance.Options.UseBackColor = true;
            this.edtFilterNamespaceExtension.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFilterNamespaceExtension.Properties.Appearance.Options.UseFont = true;
            this.edtFilterNamespaceExtension.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtFilterNamespaceExtension.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtFilterNamespaceExtension.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtFilterNamespaceExtension.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtFilterNamespaceExtension.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtFilterNamespaceExtension.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtFilterNamespaceExtension.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFilterNamespaceExtension.Properties.NullText = "";
            this.edtFilterNamespaceExtension.Properties.ShowFooter = false;
            this.edtFilterNamespaceExtension.Properties.ShowHeader = false;
            this.edtFilterNamespaceExtension.Size = new System.Drawing.Size(356, 24);
            this.edtFilterNamespaceExtension.TabIndex = 4;
            this.edtFilterNamespaceExtension.EditValueChanged += new System.EventHandler(this.edtFilterNamespaceExtension_EditValueChanged);
            // 
            // btnResetNamespaceFilter
            // 
            this.btnResetNamespaceFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetNamespaceFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetNamespaceFilter.IconID = 4;
            this.btnResetNamespaceFilter.Location = new System.Drawing.Point(456, 39);
            this.btnResetNamespaceFilter.Margin = new System.Windows.Forms.Padding(3, 6, 6, 0);
            this.btnResetNamespaceFilter.Name = "btnResetNamespaceFilter";
            this.btnResetNamespaceFilter.Size = new System.Drawing.Size(24, 24);
            this.btnResetNamespaceFilter.TabIndex = 5;
            this.btnResetNamespaceFilter.UseVisualStyleBackColor = false;
            this.btnResetNamespaceFilter.Click += new System.EventHandler(this.btnResetNamespaceFilter_Click);
            // 
            // btnResetKeyFilter
            // 
            this.btnResetKeyFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetKeyFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetKeyFilter.IconID = 4;
            this.btnResetKeyFilter.Location = new System.Drawing.Point(456, 9);
            this.btnResetKeyFilter.Margin = new System.Windows.Forms.Padding(3, 6, 6, 0);
            this.btnResetKeyFilter.Name = "btnResetKeyFilter";
            this.btnResetKeyFilter.Size = new System.Drawing.Size(24, 24);
            this.btnResetKeyFilter.TabIndex = 2;
            this.btnResetKeyFilter.UseVisualStyleBackColor = false;
            this.btnResetKeyFilter.Click += new System.EventHandler(this.btnResetKeyFilter_Click);
            // 
            // lblFilterNamespaceExtension
            // 
            this.lblFilterNamespaceExtension.Location = new System.Drawing.Point(9, 39);
            this.lblFilterNamespaceExtension.Name = "lblFilterNamespaceExtension";
            this.lblFilterNamespaceExtension.Size = new System.Drawing.Size(79, 24);
            this.lblFilterNamespaceExtension.TabIndex = 3;
            this.lblFilterNamespaceExtension.Text = "Namespace";
            // 
            // lblFilterKey
            // 
            this.lblFilterKey.Location = new System.Drawing.Point(9, 9);
            this.lblFilterKey.Name = "lblFilterKey";
            this.lblFilterKey.Size = new System.Drawing.Size(79, 24);
            this.lblFilterKey.TabIndex = 0;
            this.lblFilterKey.Text = "Schlüssel";
            // 
            // edtFilterKey
            // 
            this.edtFilterKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtFilterKey.EditValue = "";
            this.edtFilterKey.Location = new System.Drawing.Point(94, 9);
            this.edtFilterKey.Name = "edtFilterKey";
            this.edtFilterKey.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFilterKey.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFilterKey.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFilterKey.Properties.Appearance.Options.UseBackColor = true;
            this.edtFilterKey.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFilterKey.Properties.Appearance.Options.UseFont = true;
            this.edtFilterKey.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFilterKey.Size = new System.Drawing.Size(356, 24);
            this.edtFilterKey.TabIndex = 1;
            this.edtFilterKey.EditValueChanged += new System.EventHandler(this.edtFilterKey_EditValueChanged);
            // 
            // qryValue
            // 
            this.qryValue.CanDelete = true;
            this.qryValue.CanUpdate = true;
            this.qryValue.HostControl = this;
            this.qryValue.RowModified = true;
            this.qryValue.SelectStatement = resources.GetString("qryValue.SelectStatement");
            this.qryValue.TableName = "XConfig";
            this.qryValue.AfterDelete += new System.EventHandler(this.qryValue_AfterDelete);
            this.qryValue.AfterFill += new System.EventHandler(this.qryValue_AfterFill);
            this.qryValue.AfterPost += new System.EventHandler(this.qryValue_AfterPost);
            this.qryValue.BeforeDeleteQuestion += new System.EventHandler(this.qryValue_BeforeDeleteQuestion);
            this.qryValue.BeforePost += new System.EventHandler(this.qryValue_BeforePost);
            this.qryValue.PostCompleted += new System.EventHandler(this.qryValue_PostCompleted);
            // 
            // panBottomButtons
            // 
            this.panBottomButtons.Controls.Add(this.chkShowFilter);
            this.panBottomButtons.Controls.Add(this.btnCollapseAll);
            this.panBottomButtons.Controls.Add(this.btnExpandAll);
            this.panBottomButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panBottomButtons.Location = new System.Drawing.Point(0, 0);
            this.panBottomButtons.Name = "panBottomButtons";
            this.panBottomButtons.Size = new System.Drawing.Size(488, 36);
            this.panBottomButtons.TabIndex = 0;
            // 
            // chkShowFilter
            // 
            this.chkShowFilter.EditValue = false;
            this.chkShowFilter.Location = new System.Drawing.Point(12, 8);
            this.chkShowFilter.Name = "chkShowFilter";
            this.chkShowFilter.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkShowFilter.Properties.Appearance.Options.UseBackColor = true;
            this.chkShowFilter.Properties.Caption = "Zeige &Filter";
            this.chkShowFilter.Size = new System.Drawing.Size(119, 19);
            this.chkShowFilter.TabIndex = 0;
            this.chkShowFilter.CheckedChanged += new System.EventHandler(this.chkShowFilter_CheckedChanged);
            // 
            // btnCollapseAll
            // 
            this.btnCollapseAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCollapseAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCollapseAll.Image = ((System.Drawing.Image)(resources.GetObject("btnCollapseAll.Image")));
            this.btnCollapseAll.Location = new System.Drawing.Point(456, 6);
            this.btnCollapseAll.Margin = new System.Windows.Forms.Padding(3, 6, 6, 0);
            this.btnCollapseAll.Name = "btnCollapseAll";
            this.btnCollapseAll.Size = new System.Drawing.Size(24, 24);
            this.btnCollapseAll.TabIndex = 2;
            this.btnCollapseAll.UseVisualStyleBackColor = false;
            this.btnCollapseAll.Click += new System.EventHandler(this.btnCollapseAll_Click);
            // 
            // btnExpandAll
            // 
            this.btnExpandAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExpandAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpandAll.Image = ((System.Drawing.Image)(resources.GetObject("btnExpandAll.Image")));
            this.btnExpandAll.Location = new System.Drawing.Point(426, 6);
            this.btnExpandAll.Name = "btnExpandAll";
            this.btnExpandAll.Size = new System.Drawing.Size(24, 24);
            this.btnExpandAll.TabIndex = 1;
            this.btnExpandAll.UseVisualStyleBackColor = false;
            this.btnExpandAll.Click += new System.EventHandler(this.btnExpandAll_Click);
            // 
            // splitter
            // 
            this.splitter.Location = new System.Drawing.Point(490, 0);
            this.splitter.Name = "splitter";
            this.splitter.Size = new System.Drawing.Size(3, 730);
            this.splitter.TabIndex = 1;
            this.splitter.TabStop = false;
            // 
            // panDetails
            // 
            this.panDetails.Controls.Add(this.edtKeyPathId);
            this.panDetails.Controls.Add(this.edtValueCode);
            this.panDetails.Controls.Add(this.lblKeyPathId);
            this.panDetails.Controls.Add(this.edtDescription);
            this.panDetails.Controls.Add(this.edtKeyPath);
            this.panDetails.Controls.Add(this.edtValueCheckedLookupEdit);
            this.panDetails.Controls.Add(this.edtNamespaceExtension);
            this.panDetails.Controls.Add(this.lblDatumVon);
            this.panDetails.Controls.Add(this.edtDatumVon);
            this.panDetails.Controls.Add(this.edtValueDateEdit);
            this.panDetails.Controls.Add(this.edtValueCalcEdit);
            this.panDetails.Controls.Add(this.chkSystem);
            this.panDetails.Controls.Add(this.edtValueCheckEdit);
            this.panDetails.Controls.Add(this.edtValueMemoEdit);
            this.panDetails.Controls.Add(this.edtOriginalValue);
            this.panDetails.Controls.Add(this.lblValue);
            this.panDetails.Controls.Add(this.lblNamespaceExtension);
            this.panDetails.Controls.Add(this.lblDescription);
            this.panDetails.Controls.Add(this.lblOriginalValue);
            this.panDetails.Controls.Add(this.lblValueCode);
            this.panDetails.Controls.Add(this.lblKeyPath);
            this.panDetails.Controls.Add(this.edtValueTextEdit);
            this.panDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panDetails.Location = new System.Drawing.Point(0, 126);
            this.panDetails.Name = "panDetails";
            this.panDetails.Size = new System.Drawing.Size(499, 604);
            this.panDetails.TabIndex = 1;
            // 
            // edtKeyPathId
            // 
            this.edtKeyPathId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKeyPathId.DataMember = "KeyPath";
            this.edtKeyPathId.DataSource = this.qryValue;
            this.edtKeyPathId.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKeyPathId.Location = new System.Drawing.Point(352, 9);
            this.edtKeyPathId.Name = "edtKeyPathId";
            this.edtKeyPathId.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKeyPathId.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKeyPathId.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKeyPathId.Properties.Appearance.Options.UseBackColor = true;
            this.edtKeyPathId.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKeyPathId.Properties.Appearance.Options.UseFont = true;
            this.edtKeyPathId.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKeyPathId.Properties.ReadOnly = true;
            this.edtKeyPathId.Size = new System.Drawing.Size(135, 24);
            this.edtKeyPathId.TabIndex = 23;
            // 
            // edtValueCode
            // 
            this.edtValueCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtValueCode.DataMember = "ValueType";
            this.edtValueCode.DataSource = this.qryValue;
            this.edtValueCode.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtValueCode.Location = new System.Drawing.Point(94, 32);
            this.edtValueCode.Name = "edtValueCode";
            this.edtValueCode.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtValueCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtValueCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtValueCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtValueCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtValueCode.Properties.Appearance.Options.UseFont = true;
            this.edtValueCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtValueCode.Properties.ReadOnly = true;
            this.edtValueCode.Size = new System.Drawing.Size(393, 24);
            this.edtValueCode.TabIndex = 3;
            // 
            // lblKeyPathId
            // 
            this.lblKeyPathId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKeyPathId.Location = new System.Drawing.Point(328, 9);
            this.lblKeyPathId.Name = "lblKeyPathId";
            this.lblKeyPathId.Size = new System.Drawing.Size(18, 24);
            this.lblKeyPathId.TabIndex = 22;
            this.lblKeyPathId.Text = "ID";
            // 
            // edtDescription
            // 
            this.edtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDescription.ApplyChangesToDefaultText = false;
            this.edtDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtDescription.DataMemberDefaultText = "Description";
            this.edtDescription.DataMemberTID = "DescriptionTID";
            this.edtDescription.DataSource = this.qryValue;
            this.edtDescription.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtDescription.Location = new System.Drawing.Point(94, 78);
            this.edtDescription.Name = "edtDescription";
            this.edtDescription.Size = new System.Drawing.Size(393, 76);
            this.edtDescription.TabIndex = 21;
            this.edtDescription.WriteLocked = true;
            // 
            // edtKeyPath
            // 
            this.edtKeyPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKeyPath.ApplyChangesToDefaultText = false;
            this.edtKeyPath.DataMemberDefaultText = "KeyPath";
            this.edtKeyPath.DataMemberTID = "KeyPathTID";
            this.edtKeyPath.DataSource = this.qryValue;
            this.edtKeyPath.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKeyPath.Location = new System.Drawing.Point(94, 9);
            this.edtKeyPath.Name = "edtKeyPath";
            this.edtKeyPath.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKeyPath.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKeyPath.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKeyPath.Properties.Appearance.Options.UseBackColor = true;
            this.edtKeyPath.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKeyPath.Properties.Appearance.Options.UseFont = true;
            this.edtKeyPath.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtKeyPath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtKeyPath.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtKeyPath.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKeyPath.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.edtKeyPath.Properties.ReadOnly = true;
            this.edtKeyPath.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtKeyPath.Size = new System.Drawing.Size(228, 24);
            this.edtKeyPath.TabIndex = 20;
            // 
            // edtValueCheckedLookupEdit
            // 
            this.edtValueCheckedLookupEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtValueCheckedLookupEdit.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtValueCheckedLookupEdit.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtValueCheckedLookupEdit.Appearance.Options.UseBackColor = true;
            this.edtValueCheckedLookupEdit.Appearance.Options.UseBorderColor = true;
            this.edtValueCheckedLookupEdit.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtValueCheckedLookupEdit.CheckOnClick = true;
            this.edtValueCheckedLookupEdit.Location = new System.Drawing.Point(94, 414);
            this.edtValueCheckedLookupEdit.Name = "edtValueCheckedLookupEdit";
            this.edtValueCheckedLookupEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.edtValueCheckedLookupEdit.Size = new System.Drawing.Size(393, 178);
            this.edtValueCheckedLookupEdit.TabIndex = 19;
            this.edtValueCheckedLookupEdit.Visible = false;
            // 
            // edtNamespaceExtension
            // 
            this.edtNamespaceExtension.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtNamespaceExtension.DataMember = "XNamespaceExtensionID";
            this.edtNamespaceExtension.DataSource = this.qryValue;
            this.edtNamespaceExtension.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtNamespaceExtension.Location = new System.Drawing.Point(94, 153);
            this.edtNamespaceExtension.Name = "edtNamespaceExtension";
            this.edtNamespaceExtension.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtNamespaceExtension.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNamespaceExtension.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNamespaceExtension.Properties.Appearance.Options.UseBackColor = true;
            this.edtNamespaceExtension.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNamespaceExtension.Properties.Appearance.Options.UseFont = true;
            this.edtNamespaceExtension.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtNamespaceExtension.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtNamespaceExtension.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtNamespaceExtension.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtNamespaceExtension.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtNamespaceExtension.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtNamespaceExtension.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNamespaceExtension.Properties.NullText = "";
            this.edtNamespaceExtension.Properties.ReadOnly = true;
            this.edtNamespaceExtension.Properties.ShowFooter = false;
            this.edtNamespaceExtension.Properties.ShowHeader = false;
            this.edtNamespaceExtension.Size = new System.Drawing.Size(393, 24);
            this.edtNamespaceExtension.TabIndex = 9;
            // 
            // lblDatumVon
            // 
            this.lblDatumVon.Location = new System.Drawing.Point(9, 209);
            this.lblDatumVon.Name = "lblDatumVon";
            this.lblDatumVon.Size = new System.Drawing.Size(79, 24);
            this.lblDatumVon.TabIndex = 11;
            this.lblDatumVon.Text = "Gültig ab";
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.DataMember = "DatumVon";
            this.edtDatumVon.DataSource = this.qryValue;
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(94, 209);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(90, 24);
            this.edtDatumVon.TabIndex = 12;
            // 
            // edtValueDateEdit
            // 
            this.edtValueDateEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtValueDateEdit.EditValue = "";
            this.edtValueDateEdit.Location = new System.Drawing.Point(94, 354);
            this.edtValueDateEdit.Name = "edtValueDateEdit";
            this.edtValueDateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtValueDateEdit.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtValueDateEdit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtValueDateEdit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtValueDateEdit.Properties.Appearance.Options.UseBackColor = true;
            this.edtValueDateEdit.Properties.Appearance.Options.UseBorderColor = true;
            this.edtValueDateEdit.Properties.Appearance.Options.UseFont = true;
            this.edtValueDateEdit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtValueDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtValueDateEdit.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtValueDateEdit.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtValueDateEdit.Properties.ShowToday = false;
            this.edtValueDateEdit.Size = new System.Drawing.Size(393, 24);
            this.edtValueDateEdit.TabIndex = 17;
            this.edtValueDateEdit.Visible = false;
            // 
            // edtValueCalcEdit
            // 
            this.edtValueCalcEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtValueCalcEdit.EditValue = "";
            this.edtValueCalcEdit.Location = new System.Drawing.Point(94, 384);
            this.edtValueCalcEdit.Name = "edtValueCalcEdit";
            this.edtValueCalcEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtValueCalcEdit.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtValueCalcEdit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtValueCalcEdit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtValueCalcEdit.Properties.Appearance.Options.UseBackColor = true;
            this.edtValueCalcEdit.Properties.Appearance.Options.UseBorderColor = true;
            this.edtValueCalcEdit.Properties.Appearance.Options.UseFont = true;
            this.edtValueCalcEdit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtValueCalcEdit.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtValueCalcEdit.Size = new System.Drawing.Size(393, 24);
            this.edtValueCalcEdit.TabIndex = 18;
            this.edtValueCalcEdit.Visible = false;
            // 
            // chkSystem
            // 
            this.chkSystem.DataMember = "System";
            this.chkSystem.DataSource = this.qryValue;
            this.chkSystem.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.chkSystem.Location = new System.Drawing.Point(94, 184);
            this.chkSystem.Name = "chkSystem";
            this.chkSystem.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkSystem.Properties.Appearance.Options.UseBackColor = true;
            this.chkSystem.Properties.Caption = "System";
            this.chkSystem.Properties.ReadOnly = true;
            this.chkSystem.Size = new System.Drawing.Size(85, 19);
            this.chkSystem.TabIndex = 10;
            this.chkSystem.Tag = "";
            // 
            // edtValueCheckEdit
            // 
            this.edtValueCheckEdit.EditValue = false;
            this.edtValueCheckEdit.Location = new System.Drawing.Point(94, 269);
            this.edtValueCheckEdit.Name = "edtValueCheckEdit";
            this.edtValueCheckEdit.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtValueCheckEdit.Properties.Appearance.Options.UseBackColor = true;
            this.edtValueCheckEdit.Properties.Caption = "";
            this.edtValueCheckEdit.Size = new System.Drawing.Size(28, 19);
            this.edtValueCheckEdit.TabIndex = 15;
            this.edtValueCheckEdit.Tag = "";
            this.edtValueCheckEdit.Visible = false;
            // 
            // edtValueMemoEdit
            // 
            this.edtValueMemoEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtValueMemoEdit.Location = new System.Drawing.Point(94, 294);
            this.edtValueMemoEdit.Name = "edtValueMemoEdit";
            this.edtValueMemoEdit.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtValueMemoEdit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtValueMemoEdit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtValueMemoEdit.Properties.Appearance.Options.UseBackColor = true;
            this.edtValueMemoEdit.Properties.Appearance.Options.UseBorderColor = true;
            this.edtValueMemoEdit.Properties.Appearance.Options.UseFont = true;
            this.edtValueMemoEdit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtValueMemoEdit.Size = new System.Drawing.Size(393, 54);
            this.edtValueMemoEdit.TabIndex = 16;
            this.edtValueMemoEdit.Visible = false;
            // 
            // edtOriginalValue
            // 
            this.edtOriginalValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtOriginalValue.DataMember = "OriginalValue";
            this.edtOriginalValue.DataSource = this.qryValue;
            this.edtOriginalValue.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtOriginalValue.Location = new System.Drawing.Point(94, 55);
            this.edtOriginalValue.Name = "edtOriginalValue";
            this.edtOriginalValue.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtOriginalValue.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtOriginalValue.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtOriginalValue.Properties.Appearance.Options.UseBackColor = true;
            this.edtOriginalValue.Properties.Appearance.Options.UseBorderColor = true;
            this.edtOriginalValue.Properties.Appearance.Options.UseFont = true;
            this.edtOriginalValue.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtOriginalValue.Properties.ReadOnly = true;
            this.edtOriginalValue.Size = new System.Drawing.Size(393, 24);
            this.edtOriginalValue.TabIndex = 5;
            // 
            // lblValue
            // 
            this.lblValue.Location = new System.Drawing.Point(9, 239);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(79, 24);
            this.lblValue.TabIndex = 13;
            this.lblValue.Text = "Wert";
            // 
            // lblNamespaceExtension
            // 
            this.lblNamespaceExtension.Location = new System.Drawing.Point(9, 153);
            this.lblNamespaceExtension.Name = "lblNamespaceExtension";
            this.lblNamespaceExtension.Size = new System.Drawing.Size(79, 24);
            this.lblNamespaceExtension.TabIndex = 8;
            this.lblNamespaceExtension.Text = "Namespace";
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(9, 78);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(79, 24);
            this.lblDescription.TabIndex = 6;
            this.lblDescription.Text = "Beschreibung";
            // 
            // lblOriginalValue
            // 
            this.lblOriginalValue.Location = new System.Drawing.Point(9, 56);
            this.lblOriginalValue.Name = "lblOriginalValue";
            this.lblOriginalValue.Size = new System.Drawing.Size(79, 24);
            this.lblOriginalValue.TabIndex = 4;
            this.lblOriginalValue.Text = "Standardwert";
            // 
            // lblValueCode
            // 
            this.lblValueCode.Location = new System.Drawing.Point(9, 32);
            this.lblValueCode.Name = "lblValueCode";
            this.lblValueCode.Size = new System.Drawing.Size(79, 24);
            this.lblValueCode.TabIndex = 2;
            this.lblValueCode.Text = "Typ";
            // 
            // lblKeyPath
            // 
            this.lblKeyPath.Location = new System.Drawing.Point(9, 9);
            this.lblKeyPath.Name = "lblKeyPath";
            this.lblKeyPath.Size = new System.Drawing.Size(79, 24);
            this.lblKeyPath.TabIndex = 0;
            this.lblKeyPath.Text = "Schlüssel";
            // 
            // edtValueTextEdit
            // 
            this.edtValueTextEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtValueTextEdit.DataSource = this.qryValue;
            this.edtValueTextEdit.EditValue = "";
            this.edtValueTextEdit.Location = new System.Drawing.Point(94, 239);
            this.edtValueTextEdit.Name = "edtValueTextEdit";
            this.edtValueTextEdit.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtValueTextEdit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtValueTextEdit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtValueTextEdit.Properties.Appearance.Options.UseBackColor = true;
            this.edtValueTextEdit.Properties.Appearance.Options.UseBorderColor = true;
            this.edtValueTextEdit.Properties.Appearance.Options.UseFont = true;
            this.edtValueTextEdit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtValueTextEdit.Size = new System.Drawing.Size(393, 24);
            this.edtValueTextEdit.TabIndex = 14;
            // 
            // qryConfigTree
            // 
            this.qryConfigTree.SelectStatement = resources.GetString("qryConfigTree.SelectStatement");
            this.qryConfigTree.AfterFill += new System.EventHandler(this.qryConfigTree_AfterFill);
            // 
            // panConfiguration
            // 
            this.panConfiguration.Controls.Add(this.panDetails);
            this.panConfiguration.Controls.Add(this.splitterConfiguration);
            this.panConfiguration.Controls.Add(this.panHistory);
            this.panConfiguration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panConfiguration.Location = new System.Drawing.Point(493, 0);
            this.panConfiguration.Name = "panConfiguration";
            this.panConfiguration.Size = new System.Drawing.Size(499, 730);
            this.panConfiguration.TabIndex = 1;
            // 
            // splitterConfiguration
            // 
            this.splitterConfiguration.AnimationDelay = 20;
            this.splitterConfiguration.AnimationStep = 20;
            this.splitterConfiguration.BorderStyle3D = System.Windows.Forms.Border3DStyle.Etched;
            this.splitterConfiguration.ControlToHide = this.panHistory;
            this.splitterConfiguration.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterConfiguration.ExpandParentForm = false;
            this.splitterConfiguration.Location = new System.Drawing.Point(0, 118);
            this.splitterConfiguration.Name = "splitterConfiguration";
            this.splitterConfiguration.TabIndex = 0;
            this.splitterConfiguration.TabStop = false;
            this.splitterConfiguration.UseAnimations = false;
            this.splitterConfiguration.VisualStyle = KiSS4.Gui.VisualStyles.Mozilla;
            // 
            // panHistory
            // 
            this.panHistory.Controls.Add(this.grdXConfigHist);
            this.panHistory.Dock = System.Windows.Forms.DockStyle.Top;
            this.panHistory.Location = new System.Drawing.Point(0, 0);
            this.panHistory.Name = "panHistory";
            this.panHistory.Size = new System.Drawing.Size(499, 118);
            this.panHistory.TabIndex = 0;
            // 
            // grdXConfigHist
            // 
            this.grdXConfigHist.DataSource = this.qryValue;
            this.grdXConfigHist.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdXConfigHist.EmbeddedNavigator.Name = "";
            this.grdXConfigHist.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdXConfigHist.Location = new System.Drawing.Point(0, 0);
            this.grdXConfigHist.MainView = this.grvXConfigHist;
            this.grdXConfigHist.Name = "grdXConfigHist";
            this.grdXConfigHist.Size = new System.Drawing.Size(499, 118);
            this.grdXConfigHist.TabIndex = 0;
            this.grdXConfigHist.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvXConfigHist});
            // 
            // grvXConfigHist
            // 
            this.grvXConfigHist.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvXConfigHist.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXConfigHist.Appearance.Empty.Options.UseBackColor = true;
            this.grvXConfigHist.Appearance.Empty.Options.UseFont = true;
            this.grvXConfigHist.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXConfigHist.Appearance.EvenRow.Options.UseFont = true;
            this.grvXConfigHist.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvXConfigHist.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXConfigHist.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvXConfigHist.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvXConfigHist.Appearance.FocusedCell.Options.UseFont = true;
            this.grvXConfigHist.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvXConfigHist.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvXConfigHist.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXConfigHist.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvXConfigHist.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvXConfigHist.Appearance.FocusedRow.Options.UseFont = true;
            this.grvXConfigHist.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvXConfigHist.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvXConfigHist.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvXConfigHist.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvXConfigHist.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvXConfigHist.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvXConfigHist.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvXConfigHist.Appearance.GroupRow.Options.UseFont = true;
            this.grvXConfigHist.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvXConfigHist.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvXConfigHist.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvXConfigHist.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvXConfigHist.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvXConfigHist.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvXConfigHist.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvXConfigHist.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvXConfigHist.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXConfigHist.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvXConfigHist.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvXConfigHist.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvXConfigHist.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvXConfigHist.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvXConfigHist.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvXConfigHist.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXConfigHist.Appearance.OddRow.Options.UseFont = true;
            this.grvXConfigHist.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvXConfigHist.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXConfigHist.Appearance.Row.Options.UseBackColor = true;
            this.grvXConfigHist.Appearance.Row.Options.UseFont = true;
            this.grvXConfigHist.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXConfigHist.Appearance.SelectedRow.Options.UseFont = true;
            this.grvXConfigHist.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvXConfigHist.Appearance.VertLine.Options.UseBackColor = true;
            this.grvXConfigHist.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvXConfigHist.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colXConfigHistValueCode,
            this.colXConfigHistValue,
            this.colXConfigHistDate,
            this.colXConfigHistActive});
            this.grvXConfigHist.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvXConfigHist.GridControl = this.grdXConfigHist;
            this.grvXConfigHist.Name = "grvXConfigHist";
            this.grvXConfigHist.OptionsBehavior.Editable = false;
            this.grvXConfigHist.OptionsCustomization.AllowFilter = false;
            this.grvXConfigHist.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvXConfigHist.OptionsNavigation.AutoFocusNewRow = true;
            this.grvXConfigHist.OptionsNavigation.UseTabKey = false;
            this.grvXConfigHist.OptionsView.ColumnAutoWidth = false;
            this.grvXConfigHist.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvXConfigHist.OptionsView.ShowGroupPanel = false;
            this.grvXConfigHist.OptionsView.ShowIndicator = false;
            // 
            // colXConfigHistValueCode
            // 
            this.colXConfigHistValueCode.Caption = "Typ";
            this.colXConfigHistValueCode.FieldName = "ValueType";
            this.colXConfigHistValueCode.Name = "colXConfigHistValueCode";
            this.colXConfigHistValueCode.Visible = true;
            this.colXConfigHistValueCode.VisibleIndex = 0;
            this.colXConfigHistValueCode.Width = 120;
            // 
            // colXConfigHistValue
            // 
            this.colXConfigHistValue.Caption = "Wert";
            this.colXConfigHistValue.FieldName = "Value";
            this.colXConfigHistValue.Name = "colXConfigHistValue";
            this.colXConfigHistValue.Visible = true;
            this.colXConfigHistValue.VisibleIndex = 1;
            this.colXConfigHistValue.Width = 250;
            // 
            // colXConfigHistDate
            // 
            this.colXConfigHistDate.Caption = "Gültig ab";
            this.colXConfigHistDate.FieldName = "DatumVon";
            this.colXConfigHistDate.Name = "colXConfigHistDate";
            this.colXConfigHistDate.Visible = true;
            this.colXConfigHistDate.VisibleIndex = 2;
            this.colXConfigHistDate.Width = 80;
            // 
            // colXConfigHistActive
            // 
            this.colXConfigHistActive.Caption = "Aktiv";
            this.colXConfigHistActive.FieldName = "Active";
            this.colXConfigHistActive.Name = "colXConfigHistActive";
            this.colXConfigHistActive.Visible = true;
            this.colXConfigHistActive.VisibleIndex = 3;
            this.colXConfigHistActive.Width = 45;
            // 
            // CtlConfig
            // 
            this.ActiveSQLQuery = this.qryValue;
            this.ClientSize = new System.Drawing.Size(992, 730);
            this.Controls.Add(this.panConfiguration);
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.panTree);
            this.Name = "CtlConfig";
            this.Text = "Konfiguration";
            this.Load += new System.EventHandler(this.CtlConfig_Load);
            this.panTree.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treConfigTree)).EndInit();
            this.panBottomTree.ResumeLayout(false);
            this.panBottomFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtFilterNamespaceExtension.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilterNamespaceExtension)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilterNamespaceExtension)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilterKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilterKey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryValue)).EndInit();
            this.panBottomButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkShowFilter.Properties)).EndInit();
            this.panDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtKeyPathId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValueCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKeyPathId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKeyPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValueCheckedLookupEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNamespaceExtension.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNamespaceExtension)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValueDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValueCalcEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSystem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValueCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValueMemoEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOriginalValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNamespaceExtension)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblOriginalValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValueCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKeyPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValueTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryConfigTree)).EndInit();
            this.panConfiguration.ResumeLayout(false);
            this.panHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdXConfigHist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvXConfigHist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissButton btnCollapseAll;
        private KiSS4.Gui.KissButton btnExpandAll;
        private KiSS4.Gui.KissButton btnResetKeyFilter;
        private KiSS4.Gui.KissButton btnResetNamespaceFilter;
        private KiSS4.Gui.KissCheckEdit chkShowFilter;
        private KiSS4.Gui.KissCheckEdit chkSystem;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colFilterNSEID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colKey;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colKeyPath;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTreeAmount;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colValue;
        private DevExpress.XtraGrid.Columns.GridColumn colXConfigHistActive;
        private DevExpress.XtraGrid.Columns.GridColumn colXConfigHistDate;
        private DevExpress.XtraGrid.Columns.GridColumn colXConfigHistValue;
        private DevExpress.XtraGrid.Columns.GridColumn colXConfigHistValueCode;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissTextEdit edtFilterKey;
        private KiSS4.Gui.KissLookUpEdit edtFilterNamespaceExtension;
        private KiSS4.Gui.KissLookUpEdit edtNamespaceExtension;
        private KiSS4.Gui.KissTextEdit edtOriginalValue;
        private KiSS4.Gui.KissCalcEdit edtValueCalcEdit;
        private KiSS4.Gui.KissCheckEdit edtValueCheckEdit;
        private KiSS4.Gui.KissCheckedLookupEdit edtValueCheckedLookupEdit;
        private KiSS4.Gui.KissTextEdit edtValueCode;
        private KiSS4.Gui.KissDateEdit edtValueDateEdit;
        private KiSS4.Gui.KissMemoEdit edtValueMemoEdit;
        private KiSS4.Gui.KissTextEdit edtValueTextEdit;
        private KiSS4.Gui.KissGrid grdXConfigHist;
        private DevExpress.XtraGrid.Views.Grid.GridView grvXConfigHist;
        private KiSS4.Gui.KissLabel lblDatumVon;
        private KiSS4.Gui.KissLabel lblDescription;
        private KiSS4.Gui.KissLabel lblFilterKey;
        private KiSS4.Gui.KissLabel lblFilterNamespaceExtension;
        private KiSS4.Gui.KissLabel lblKeyPath;
        private KiSS4.Gui.KissLabel lblNamespaceExtension;
        private KiSS4.Gui.KissLabel lblOriginalValue;
        private KiSS4.Gui.KissLabel lblValue;
        private KiSS4.Gui.KissLabel lblValueCode;
        private System.Windows.Forms.Panel panBottomButtons;
        private System.Windows.Forms.Panel panBottomFilter;
        private System.Windows.Forms.Panel panBottomTree;
        private System.Windows.Forms.Panel panConfiguration;
        private System.Windows.Forms.Panel panDetails;
        private System.Windows.Forms.Panel panHistory;
        private System.Windows.Forms.Panel panTree;
        private KiSS4.DB.SqlQuery qryConfigTree;
        private KiSS4.DB.SqlQuery qryValue;
        private KiSS4.Gui.KissSplitter splitter;
        private KiSS4.Gui.KissSplitterCollapsible splitterConfiguration;
        private KiSS4.Gui.KissTree treConfigTree;
        private Gui.KissTextEditML edtKeyPath;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDisplayPath;
        private Gui.KissMemoEditML edtDescription;
        private Gui.KissTextEdit edtKeyPathId;
        private Gui.KissLabel lblKeyPathId;
    }
}