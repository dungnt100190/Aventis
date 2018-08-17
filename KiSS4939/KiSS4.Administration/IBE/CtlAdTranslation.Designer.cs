namespace KiSS4.Administration.IBE
{
    public partial class CtlAdTranslation
    {
        private System.Windows.Forms.Panel panel1;
        private KiSS4.Gui.KissButton btnAutoTranslateAll;
        private KiSS4.Gui.KissButton btnAutoTranslate;
        private KiSS4.Gui.KissButton btnCopy;
        private KiSS4.Gui.KissButton btnClose;
        private System.Windows.Forms.Panel panel2;
        private KiSS4.Gui.KissLabel kissLabel3;
        private KiSS4.Gui.KissLookUpEdit cboLanguages;
        private KiSS4.DB.SqlQuery qryLanguages;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissSplitter kissSplitter1;
        private System.Windows.Forms.Panel panel3;
        private KiSS4.Gui.KissGrid grdFields;
        private KiSS4.DB.SqlQuery qryFields;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn grdcolOtherLanguage;
        private System.Windows.Forms.Panel panel5;
        private KiSS4.Gui.KissLabel lblTitel;
        private System.Windows.Forms.Panel panel6;
        private KiSS4.Gui.KissLabel lblText;
        private KiSS4.Gui.KissTextEdit edtText;
        private KiSS4.Gui.KissTree treFelder;
        private DevExpress.XtraTreeList.Columns.TreeListColumn trecolName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn trecolTable;
        private DevExpress.XtraTreeList.Columns.TreeListColumn trecolField;
        private DevExpress.XtraTreeList.Columns.TreeListColumn trecolFieldPK;
        private KiSS4.DB.SqlQuery qryTable;
        
        #region Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlAdTranslation));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAutoTranslateAll = new KiSS4.Gui.KissButton();
            this.btnAutoTranslate = new KiSS4.Gui.KissButton();
            this.btnCopy = new KiSS4.Gui.KissButton();
            this.btnClose = new KiSS4.Gui.KissButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            this.cboLanguages = new KiSS4.Gui.KissLookUpEdit();
            this.qryLanguages = new KiSS4.DB.SqlQuery();
            this.treFelder = new KiSS4.Gui.KissTree();
            this.trecolName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trecolTable = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trecolField = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trecolFieldPK = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.qryTable = new KiSS4.DB.SqlQuery();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grdFields = new KiSS4.Gui.KissGrid();
            this.qryFields = new KiSS4.DB.SqlQuery();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdcolOtherLanguage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblText = new KiSS4.Gui.KissLabel();
            this.edtText = new KiSS4.Gui.KissTextEdit();
            this.kissSplitter1 = new KiSS4.Gui.KissSplitter();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLanguages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLanguages.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryLanguages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treFelder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryTable)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtText.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAutoTranslateAll);
            this.panel1.Controls.Add(this.btnAutoTranslate);
            this.panel1.Controls.Add(this.btnCopy);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 442);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(810, 30);
            this.panel1.TabIndex = 1;
            // 
            // btnAutoTranslateAll
            // 
            this.btnAutoTranslateAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAutoTranslateAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutoTranslateAll.Location = new System.Drawing.Point(568, 3);
            this.btnAutoTranslateAll.Name = "btnAutoTranslateAll";
            this.btnAutoTranslateAll.Size = new System.Drawing.Size(142, 24);
            this.btnAutoTranslateAll.TabIndex = 3;
            this.btnAutoTranslateAll.Text = "alle autom. übersetzen";
            this.btnAutoTranslateAll.UseCompatibleTextRendering = true;
            this.btnAutoTranslateAll.UseVisualStyleBackColor = false;
            this.btnAutoTranslateAll.Click += new System.EventHandler(this.btnAutoTranslateAll_Click);
            // 
            // btnAutoTranslate
            // 
            this.btnAutoTranslate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAutoTranslate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutoTranslate.Location = new System.Drawing.Point(443, 3);
            this.btnAutoTranslate.Name = "btnAutoTranslate";
            this.btnAutoTranslate.Size = new System.Drawing.Size(119, 24);
            this.btnAutoTranslate.TabIndex = 2;
            this.btnAutoTranslate.Text = "autom. übersetzen";
            this.btnAutoTranslate.UseCompatibleTextRendering = true;
            this.btnAutoTranslate.UseVisualStyleBackColor = false;
            this.btnAutoTranslate.Click += new System.EventHandler(this.btnAutoTranslate_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.Location = new System.Drawing.Point(347, 3);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(90, 24);
            this.btnCopy.TabIndex = 1;
            this.btnCopy.Text = "übertragen";
            this.btnCopy.UseCompatibleTextRendering = true;
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(716, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 24);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Schliessen";
            this.btnClose.UseCompatibleTextRendering = true;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.kissLabel3);
            this.panel2.Controls.Add(this.cboLanguages);
            this.panel2.Controls.Add(this.treFelder);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(279, 442);
            this.panel2.TabIndex = 2;
            // 
            // kissLabel3
            // 
            this.kissLabel3.Location = new System.Drawing.Point(3, 9);
            this.kissLabel3.Name = "kissLabel3";
            this.kissLabel3.Size = new System.Drawing.Size(109, 24);
            this.kissLabel3.TabIndex = 2;
            this.kissLabel3.Text = "Sprache filtern";
            this.kissLabel3.UseCompatibleTextRendering = true;
            // 
            // cboLanguages
            // 
            this.cboLanguages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLanguages.Location = new System.Drawing.Point(3, 35);
            this.cboLanguages.Name = "cboLanguages";
            this.cboLanguages.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboLanguages.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboLanguages.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboLanguages.Properties.Appearance.Options.UseBackColor = true;
            this.cboLanguages.Properties.Appearance.Options.UseBorderColor = true;
            this.cboLanguages.Properties.Appearance.Options.UseFont = true;
            this.cboLanguages.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboLanguages.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboLanguages.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboLanguages.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboLanguages.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.cboLanguages.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.cboLanguages.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboLanguages.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.cboLanguages.Properties.DataSource = this.qryLanguages;
            this.cboLanguages.Properties.DisplayMember = "Text";
            this.cboLanguages.Properties.NullText = "";
            this.cboLanguages.Properties.ShowFooter = false;
            this.cboLanguages.Properties.ShowHeader = false;
            this.cboLanguages.Properties.ValueMember = "Code";
            this.cboLanguages.Size = new System.Drawing.Size(270, 24);
            this.cboLanguages.TabIndex = 1;
            this.cboLanguages.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.cboLanguages_CloseUp);
            // 
            // qryLanguages
            // 
            this.qryLanguages.HostControl = this;
            this.qryLanguages.SelectStatement = "--select Code = 0, Text = \'[Alle Sprachen]\', SortKey = 0\r\n--union all\r\nselect Cod" +
    "e, Text, SortKey from XLOVCode\r\nwhere LOVName = \'Sprache\'\r\n  and not Code = 1\r\no" +
    "rder by SortKey";
            // 
            // treFelder
            // 
            this.treFelder.AllowSortTree = true;
            this.treFelder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treFelder.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.treFelder.Appearance.Empty.Options.UseBackColor = true;
            this.treFelder.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(236)))), ((int)(((byte)(215)))));
            this.treFelder.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.treFelder.Appearance.EvenRow.Options.UseBackColor = true;
            this.treFelder.Appearance.EvenRow.Options.UseForeColor = true;
            this.treFelder.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treFelder.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treFelder.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.treFelder.Appearance.FooterPanel.Options.UseBackColor = true;
            this.treFelder.Appearance.FooterPanel.Options.UseFont = true;
            this.treFelder.Appearance.FooterPanel.Options.UseForeColor = true;
            this.treFelder.Appearance.GroupButton.BackColor = System.Drawing.Color.Transparent;
            this.treFelder.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.treFelder.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black;
            this.treFelder.Appearance.GroupButton.Options.UseBackColor = true;
            this.treFelder.Appearance.GroupButton.Options.UseFont = true;
            this.treFelder.Appearance.GroupButton.Options.UseForeColor = true;
            this.treFelder.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(226)))), ((int)(((byte)(184)))));
            this.treFelder.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.treFelder.Appearance.GroupFooter.Options.UseBackColor = true;
            this.treFelder.Appearance.GroupFooter.Options.UseForeColor = true;
            this.treFelder.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.treFelder.Appearance.HeaderPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.treFelder.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.treFelder.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.treFelder.Appearance.HeaderPanel.Options.UseFont = true;
            this.treFelder.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.treFelder.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.treFelder.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treFelder.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.treFelder.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.treFelder.Appearance.HideSelectionRow.Options.UseFont = true;
            this.treFelder.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.treFelder.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treFelder.Appearance.HorzLine.ForeColor = System.Drawing.Color.Red;
            this.treFelder.Appearance.HorzLine.Options.UseBackColor = true;
            this.treFelder.Appearance.HorzLine.Options.UseForeColor = true;
            this.treFelder.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.treFelder.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treFelder.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.treFelder.Appearance.OddRow.Options.UseBackColor = true;
            this.treFelder.Appearance.OddRow.Options.UseFont = true;
            this.treFelder.Appearance.OddRow.Options.UseForeColor = true;
            this.treFelder.Appearance.Preview.BackColor = System.Drawing.Color.White;
            this.treFelder.Appearance.Preview.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treFelder.Appearance.Preview.ForeColor = System.Drawing.Color.Maroon;
            this.treFelder.Appearance.Preview.Options.UseBackColor = true;
            this.treFelder.Appearance.Preview.Options.UseFont = true;
            this.treFelder.Appearance.Preview.Options.UseForeColor = true;
            this.treFelder.Appearance.Row.BackColor = System.Drawing.Color.Transparent;
            this.treFelder.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treFelder.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.treFelder.Appearance.Row.Options.UseBackColor = true;
            this.treFelder.Appearance.Row.Options.UseFont = true;
            this.treFelder.Appearance.Row.Options.UseForeColor = true;
            this.treFelder.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.treFelder.Appearance.SelectedRow.Options.UseForeColor = true;
            this.treFelder.Appearance.TreeLine.BackColor = System.Drawing.Color.Gray;
            this.treFelder.Appearance.TreeLine.Options.UseBackColor = true;
            this.treFelder.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treFelder.Appearance.VertLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(166)))), ((int)(((byte)(70)))));
            this.treFelder.Appearance.VertLine.Options.UseBackColor = true;
            this.treFelder.Appearance.VertLine.Options.UseForeColor = true;
            this.treFelder.Appearance.VertLine.Options.UseTextOptions = true;
            this.treFelder.Appearance.VertLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.treFelder.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.treFelder.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.trecolName,
            this.trecolTable,
            this.trecolField,
            this.trecolFieldPK});
            this.treFelder.DataSource = this.qryTable;
            this.treFelder.ImageIndexFieldName = "IconID";
            this.treFelder.Location = new System.Drawing.Point(3, 65);
            this.treFelder.Name = "treFelder";
            this.treFelder.OptionsBehavior.AutoSelectAllInEditor = false;
            this.treFelder.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.treFelder.OptionsBehavior.Editable = false;
            this.treFelder.OptionsBehavior.KeepSelectedOnClick = false;
            this.treFelder.OptionsBehavior.MoveOnEdit = false;
            this.treFelder.OptionsMenu.EnableColumnMenu = false;
            this.treFelder.OptionsMenu.EnableFooterMenu = false;
            this.treFelder.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treFelder.OptionsView.AutoWidth = false;
            this.treFelder.OptionsView.EnableAppearanceEvenRow = true;
            this.treFelder.OptionsView.EnableAppearanceOddRow = true;
            this.treFelder.OptionsView.ShowIndicator = false;
            this.treFelder.Size = new System.Drawing.Size(270, 371);
            this.treFelder.TabIndex = 0;
            this.treFelder.BeforeFocusNode += new DevExpress.XtraTreeList.BeforeFocusNodeEventHandler(this.treFelder_BeforeFocusNode);
            this.treFelder.AfterFocusNode += new DevExpress.XtraTreeList.NodeEventHandler(this.treFelder_AfterFocusNode);
            // 
            // trecolName
            // 
            this.trecolName.FieldName = "Name";
            this.trecolName.Name = "trecolName";
            this.trecolName.OptionsColumn.AllowSort = false;
            this.trecolName.VisibleIndex = 0;
            this.trecolName.Width = 248;
            // 
            // trecolTable
            // 
            this.trecolTable.Caption = "trecolTable";
            this.trecolTable.FieldName = "Tablename";
            this.trecolTable.Name = "trecolTable";
            this.trecolTable.OptionsColumn.AllowSort = false;
            // 
            // trecolField
            // 
            this.trecolField.Caption = "trecolField";
            this.trecolField.FieldName = "Fieldname";
            this.trecolField.Name = "trecolField";
            this.trecolField.OptionsColumn.AllowSort = false;
            // 
            // trecolFieldPK
            // 
            this.trecolFieldPK.Caption = "trecolFieldPK";
            this.trecolFieldPK.FieldName = "FieldnamePK";
            this.trecolFieldPK.Name = "trecolFieldPK";
            this.trecolFieldPK.OptionsColumn.AllowSort = false;
            // 
            // qryTable
            // 
            this.qryTable.BatchUpdate = true;
            this.qryTable.CanUpdate = true;
            this.qryTable.HostControl = this;
            this.qryTable.SelectStatement = "EXEC dbo.spAdTranslationFields NULL";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.grdFields);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(279, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(531, 442);
            this.panel3.TabIndex = 3;
            // 
            // grdFields
            // 
            this.grdFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdFields.DataSource = this.qryFields;
            // 
            // 
            // 
            this.grdFields.EmbeddedNavigator.Name = "";
            this.grdFields.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            gridLevelNode1.RelationName = "Level1";
            this.grdFields.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grdFields.Location = new System.Drawing.Point(9, 35);
            this.grdFields.MainView = this.gridView1;
            this.grdFields.Name = "grdFields";
            this.grdFields.Size = new System.Drawing.Size(519, 334);
            this.grdFields.TabIndex = 3;
            this.grdFields.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // qryFields
            // 
            this.qryFields.BatchUpdate = true;
            this.qryFields.CanUpdate = true;
            this.qryFields.HostControl = this;
            this.qryFields.SelectStatement = resources.GetString("qryFields.SelectStatement");
            this.qryFields.AfterFill += new System.EventHandler(this.qryFields_AfterFill);
            this.qryFields.BeforePost += new System.EventHandler(this.qryFields_BeforePost);
            this.qryFields.PositionChanged += new System.EventHandler(this.qryFields_PositionChanged);
            this.qryFields.PositionChanging += new System.EventHandler(this.qryFields_PositionChanging);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.Empty.Options.UseFont = true;
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView1.Appearance.EvenRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.gridView1.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.OddRow.Options.UseFont = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.grdcolOtherLanguage});
            this.gridView1.GridControl = this.grdFields;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridColumn1.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn1.Caption = "Deutsch";
            this.gridColumn1.FieldName = "Deutsch";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.AllowMove = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // grdcolOtherLanguage
            // 
            this.grdcolOtherLanguage.AppearanceCell.BackColor = System.Drawing.Color.AliceBlue;
            this.grdcolOtherLanguage.AppearanceCell.Options.UseBackColor = true;
            this.grdcolOtherLanguage.Caption = "Französisch";
            this.grdcolOtherLanguage.FieldName = "LangToTranslate";
            this.grdcolOtherLanguage.Name = "grdcolOtherLanguage";
            this.grdcolOtherLanguage.OptionsColumn.AllowMove = false;
            this.grdcolOtherLanguage.Visible = true;
            this.grdcolOtherLanguage.VisibleIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblTitel);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(531, 32);
            this.panel5.TabIndex = 1;
            // 
            // lblTitel
            // 
            this.lblTitel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(9, 9);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(519, 16);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "kissLabel1";
            this.lblTitel.UseCompatibleTextRendering = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.lblText);
            this.panel6.Controls.Add(this.edtText);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 375);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(531, 67);
            this.panel6.TabIndex = 2;
            // 
            // lblText
            // 
            this.lblText.Location = new System.Drawing.Point(9, 10);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(100, 23);
            this.lblText.TabIndex = 2;
            this.lblText.Text = "Deutsch";
            this.lblText.UseCompatibleTextRendering = true;
            // 
            // edtText
            // 
            this.edtText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtText.DataMember = "LangToTranslate";
            this.edtText.DataSource = this.qryFields;
            this.edtText.Location = new System.Drawing.Point(9, 36);
            this.edtText.Name = "edtText";
            this.edtText.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtText.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtText.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtText.Properties.Appearance.Options.UseBackColor = true;
            this.edtText.Properties.Appearance.Options.UseBorderColor = true;
            this.edtText.Properties.Appearance.Options.UseFont = true;
            this.edtText.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtText.Size = new System.Drawing.Size(519, 24);
            this.edtText.TabIndex = 1;
            // 
            // kissSplitter1
            // 
            this.kissSplitter1.Location = new System.Drawing.Point(279, 0);
            this.kissSplitter1.Name = "kissSplitter1";
            this.kissSplitter1.Size = new System.Drawing.Size(3, 442);
            this.kissSplitter1.TabIndex = 4;
            this.kissSplitter1.TabStop = false;
            // 
            // CtlAdTranslation
            // 
            this.Controls.Add(this.kissSplitter1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "CtlAdTranslation";
            this.Size = new System.Drawing.Size(810, 472);
            this.Load += new System.EventHandler(this.CtlAdTranslation_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLanguages.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLanguages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryLanguages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treFelder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryTable)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdFields)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFields)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtText.Properties)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if ((components != null))
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}