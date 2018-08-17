namespace KiSS4.Main.PI
{
    partial class CtlFallNavigator
    {
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.treFallNavigator = new KiSS4.Gui.KissTree();
            this.colID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colType = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAlter = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colP = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repModulIcon = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colFallverlauf = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colModulDLSpace = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSB = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colCM = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colBW = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colED = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colIN = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAB = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colWD = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colWohnort = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colBaPersonID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.chkFV = new KiSS4.Gui.KissCheckEdit();
            this.picFV = new System.Windows.Forms.PictureBox();
            this.picSB = new System.Windows.Forms.PictureBox();
            this.chkSB = new KiSS4.Gui.KissCheckEdit();
            this.picCM = new System.Windows.Forms.PictureBox();
            this.chkCM = new KiSS4.Gui.KissCheckEdit();
            this.chkBW = new KiSS4.Gui.KissCheckEdit();
            this.picBW = new System.Windows.Forms.PictureBox();
            this.chkED = new KiSS4.Gui.KissCheckEdit();
            this.picED = new System.Windows.Forms.PictureBox();
            this.picIN = new System.Windows.Forms.PictureBox();
            this.chkIN = new KiSS4.Gui.KissCheckEdit();
            this.chkAbgeschlossene = new KiSS4.Gui.KissCheckEdit();
            this.chkGastrecht = new KiSS4.Gui.KissCheckEdit();
            this.chkGruppe = new KiSS4.Gui.KissCheckEdit();
            this.btnFall = new KiSS4.Gui.KissButton();
            this.btnNeuerFall = new KiSS4.Gui.KissButton();
            this.lblAnzahlPersonen = new KiSS4.Gui.KissLabel();
            this.btnFallInfo = new DevExpress.XtraBars.BarButtonItem();
            this.colN = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.qryModul = new KiSS4.DB.SqlQuery(this.components);
            this.picAB = new System.Windows.Forms.PictureBox();
            this.chkAB = new KiSS4.Gui.KissCheckEdit();
            this.chkWD = new KiSS4.Gui.KissCheckEdit();
            this.picWD = new System.Windows.Forms.PictureBox();
            this.panBottom = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.treFallNavigator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repModulIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCM.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBW.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkED.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picED)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAbgeschlossene.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGastrecht.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGruppe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnzahlPersonen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryModul)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkWD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWD)).BeginInit();
            this.panBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // treFallNavigator
            // 
            this.treFallNavigator.AllowSortTree = true;
            this.treFallNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treFallNavigator.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.treFallNavigator.Appearance.Empty.ForeColor = System.Drawing.Color.White;
            this.treFallNavigator.Appearance.Empty.Options.UseBackColor = true;
            this.treFallNavigator.Appearance.Empty.Options.UseForeColor = true;
            this.treFallNavigator.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(236)))), ((int)(((byte)(215)))));
            this.treFallNavigator.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.treFallNavigator.Appearance.EvenRow.Options.UseBackColor = true;
            this.treFallNavigator.Appearance.EvenRow.Options.UseForeColor = true;
            this.treFallNavigator.Appearance.FocusedCell.BackColor = System.Drawing.Color.Transparent;
            this.treFallNavigator.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.treFallNavigator.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treFallNavigator.Appearance.FocusedCell.Options.UseForeColor = true;
            this.treFallNavigator.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.treFallNavigator.Appearance.FocusedRow.Options.UseForeColor = true;
            this.treFallNavigator.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treFallNavigator.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treFallNavigator.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.treFallNavigator.Appearance.FooterPanel.Options.UseBackColor = true;
            this.treFallNavigator.Appearance.FooterPanel.Options.UseFont = true;
            this.treFallNavigator.Appearance.FooterPanel.Options.UseForeColor = true;
            this.treFallNavigator.Appearance.GroupButton.BackColor = System.Drawing.Color.Transparent;
            this.treFallNavigator.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.treFallNavigator.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black;
            this.treFallNavigator.Appearance.GroupButton.Options.UseBackColor = true;
            this.treFallNavigator.Appearance.GroupButton.Options.UseFont = true;
            this.treFallNavigator.Appearance.GroupButton.Options.UseForeColor = true;
            this.treFallNavigator.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(226)))), ((int)(((byte)(184)))));
            this.treFallNavigator.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.treFallNavigator.Appearance.GroupFooter.Options.UseBackColor = true;
            this.treFallNavigator.Appearance.GroupFooter.Options.UseForeColor = true;
            this.treFallNavigator.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.treFallNavigator.Appearance.HeaderPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.treFallNavigator.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.treFallNavigator.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.treFallNavigator.Appearance.HeaderPanel.Options.UseFont = true;
            this.treFallNavigator.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.treFallNavigator.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.treFallNavigator.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treFallNavigator.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.treFallNavigator.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.treFallNavigator.Appearance.HideSelectionRow.Options.UseFont = true;
            this.treFallNavigator.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.treFallNavigator.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treFallNavigator.Appearance.HorzLine.ForeColor = System.Drawing.Color.Red;
            this.treFallNavigator.Appearance.HorzLine.Options.UseBackColor = true;
            this.treFallNavigator.Appearance.HorzLine.Options.UseForeColor = true;
            this.treFallNavigator.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.treFallNavigator.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treFallNavigator.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.treFallNavigator.Appearance.OddRow.Options.UseBackColor = true;
            this.treFallNavigator.Appearance.OddRow.Options.UseFont = true;
            this.treFallNavigator.Appearance.OddRow.Options.UseForeColor = true;
            this.treFallNavigator.Appearance.Preview.BackColor = System.Drawing.Color.White;
            this.treFallNavigator.Appearance.Preview.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treFallNavigator.Appearance.Preview.ForeColor = System.Drawing.Color.Maroon;
            this.treFallNavigator.Appearance.Preview.Options.UseBackColor = true;
            this.treFallNavigator.Appearance.Preview.Options.UseFont = true;
            this.treFallNavigator.Appearance.Preview.Options.UseForeColor = true;
            this.treFallNavigator.Appearance.Row.BackColor = System.Drawing.Color.Transparent;
            this.treFallNavigator.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treFallNavigator.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.treFallNavigator.Appearance.Row.Options.UseBackColor = true;
            this.treFallNavigator.Appearance.Row.Options.UseFont = true;
            this.treFallNavigator.Appearance.Row.Options.UseForeColor = true;
            this.treFallNavigator.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.treFallNavigator.Appearance.SelectedRow.Options.UseForeColor = true;
            this.treFallNavigator.Appearance.TreeLine.BackColor = System.Drawing.Color.Gray;
            this.treFallNavigator.Appearance.TreeLine.ForeColor = System.Drawing.Color.Gray;
            this.treFallNavigator.Appearance.TreeLine.Options.UseBackColor = true;
            this.treFallNavigator.Appearance.TreeLine.Options.UseForeColor = true;
            this.treFallNavigator.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treFallNavigator.Appearance.VertLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(166)))), ((int)(((byte)(70)))));
            this.treFallNavigator.Appearance.VertLine.Options.UseBackColor = true;
            this.treFallNavigator.Appearance.VertLine.Options.UseForeColor = true;
            this.treFallNavigator.Appearance.VertLine.Options.UseTextOptions = true;
            this.treFallNavigator.Appearance.VertLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.treFallNavigator.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colID,
            this.colType,
            this.colName,
            this.colAlter,
            this.colP,
            this.colFallverlauf,
            this.colModulDLSpace,
            this.colSB,
            this.colCM,
            this.colBW,
            this.colED,
            this.colIN,
            this.colAB,
            this.colWD,
            this.colWohnort,
            this.colBaPersonID});
            this.treFallNavigator.ImageIndexFieldName = "IconID";
            this.treFallNavigator.Location = new System.Drawing.Point(8, 8);
            this.treFallNavigator.Name = "treFallNavigator";
            this.treFallNavigator.OptionsBehavior.AutoSelectAllInEditor = false;
            this.treFallNavigator.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.treFallNavigator.OptionsBehavior.Editable = false;
            this.treFallNavigator.OptionsBehavior.KeepSelectedOnClick = false;
            this.treFallNavigator.OptionsBehavior.MoveOnEdit = false;
            this.treFallNavigator.OptionsMenu.EnableColumnMenu = false;
            this.treFallNavigator.OptionsMenu.EnableFooterMenu = false;
            this.treFallNavigator.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treFallNavigator.OptionsView.AutoWidth = false;
            this.treFallNavigator.OptionsView.EnableAppearanceEvenRow = true;
            this.treFallNavigator.OptionsView.EnableAppearanceOddRow = true;
            this.treFallNavigator.OptionsView.ShowIndicator = false;
            this.treFallNavigator.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repModulIcon});
            this.treFallNavigator.Size = new System.Drawing.Size(691, 407);
            this.treFallNavigator.TabIndex = 0;
            this.treFallNavigator.DoubleClick += new System.EventHandler(this.treFallNavigator_DoubleClick);
            this.treFallNavigator.MouseMove += new System.Windows.Forms.MouseEventHandler(this.treFallNavigator_MouseMove);
            this.treFallNavigator.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treFallNavigator_MouseUp);
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.AllowSort = false;
            this.colID.Width = 91;
            // 
            // colType
            // 
            this.colType.Caption = "Type";
            this.colType.FieldName = "Type";
            this.colType.Name = "colType";
            this.colType.OptionsColumn.AllowSort = false;
            // 
            // colName
            // 
            this.colName.Caption = "Person";
            this.colName.FieldName = "Name";
            this.colName.MinWidth = 27;
            this.colName.Name = "colName";
            this.colName.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 240;
            // 
            // colAlter
            // 
            this.colAlter.Caption = "Alter";
            this.colAlter.FieldName = "PrsAlter";
            this.colAlter.Name = "colAlter";
            this.colAlter.VisibleIndex = 1;
            this.colAlter.Width = 38;
            // 
            // colP
            // 
            this.colP.Caption = "P";
            this.colP.ColumnEdit = this.repModulIcon;
            this.colP.FieldName = "P";
            this.colP.Name = "colP";
            this.colP.OptionsColumn.AllowMove = false;
            this.colP.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.colP.OptionsColumn.AllowSize = false;
            this.colP.OptionsColumn.AllowSort = false;
            this.colP.OptionsColumn.FixedWidth = true;
            this.colP.OptionsColumn.ShowInCustomizationForm = false;
            this.colP.VisibleIndex = 2;
            this.colP.Width = 30;
            // 
            // repModulIcon
            // 
            this.repModulIcon.AutoComplete = false;
            this.repModulIcon.AutoHeight = false;
            this.repModulIcon.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 0, true, false, false, DevExpress.Utils.HorzAlignment.Default, null)});
            this.repModulIcon.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repModulIcon.Name = "repModulIcon";
            this.repModulIcon.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.NoBorder;
            this.repModulIcon.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.repModulIcon.ShowPopupShadow = false;
            // 
            // colFallverlauf
            // 
            this.colFallverlauf.Caption = "FV";
            this.colFallverlauf.ColumnEdit = this.repModulIcon;
            this.colFallverlauf.FieldName = "FV";
            this.colFallverlauf.Name = "colFallverlauf";
            this.colFallverlauf.OptionsColumn.AllowMove = false;
            this.colFallverlauf.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.colFallverlauf.OptionsColumn.AllowSize = false;
            this.colFallverlauf.OptionsColumn.FixedWidth = true;
            this.colFallverlauf.OptionsColumn.ShowInCustomizationForm = false;
            this.colFallverlauf.VisibleIndex = 3;
            this.colFallverlauf.Width = 30;
            // 
            // colModulDLSpace
            // 
            this.colModulDLSpace.Name = "colModulDLSpace";
            this.colModulDLSpace.OptionsColumn.AllowEdit = false;
            this.colModulDLSpace.OptionsColumn.AllowMove = false;
            this.colModulDLSpace.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.colModulDLSpace.OptionsColumn.AllowSize = false;
            this.colModulDLSpace.OptionsColumn.AllowSort = false;
            this.colModulDLSpace.OptionsColumn.FixedWidth = true;
            this.colModulDLSpace.OptionsColumn.ReadOnly = true;
            this.colModulDLSpace.OptionsColumn.ShowInCustomizationForm = false;
            this.colModulDLSpace.VisibleIndex = 4;
            this.colModulDLSpace.Width = 20;
            // 
            // colSB
            // 
            this.colSB.Caption = "SB";
            this.colSB.ColumnEdit = this.repModulIcon;
            this.colSB.FieldName = "SB";
            this.colSB.Name = "colSB";
            this.colSB.OptionsColumn.AllowMove = false;
            this.colSB.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.colSB.OptionsColumn.AllowSize = false;
            this.colSB.OptionsColumn.FixedWidth = true;
            this.colSB.OptionsColumn.ShowInCustomizationForm = false;
            this.colSB.VisibleIndex = 5;
            this.colSB.Width = 30;
            // 
            // colCM
            // 
            this.colCM.Caption = "CM";
            this.colCM.ColumnEdit = this.repModulIcon;
            this.colCM.FieldName = "CM";
            this.colCM.Name = "colCM";
            this.colCM.OptionsColumn.AllowMove = false;
            this.colCM.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.colCM.OptionsColumn.AllowSize = false;
            this.colCM.OptionsColumn.FixedWidth = true;
            this.colCM.OptionsColumn.ShowInCustomizationForm = false;
            this.colCM.VisibleIndex = 6;
            this.colCM.Width = 30;
            // 
            // colBW
            // 
            this.colBW.Caption = "BW";
            this.colBW.ColumnEdit = this.repModulIcon;
            this.colBW.FieldName = "BW";
            this.colBW.Name = "colBW";
            this.colBW.OptionsColumn.AllowMove = false;
            this.colBW.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.colBW.OptionsColumn.AllowSize = false;
            this.colBW.OptionsColumn.FixedWidth = true;
            this.colBW.OptionsColumn.ShowInCustomizationForm = false;
            this.colBW.VisibleIndex = 7;
            this.colBW.Width = 30;
            // 
            // colED
            // 
            this.colED.Caption = "ED";
            this.colED.ColumnEdit = this.repModulIcon;
            this.colED.FieldName = "ED";
            this.colED.Name = "colED";
            this.colED.OptionsColumn.AllowMove = false;
            this.colED.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.colED.OptionsColumn.AllowSize = false;
            this.colED.OptionsColumn.FixedWidth = true;
            this.colED.OptionsColumn.ShowInCustomizationForm = false;
            this.colED.VisibleIndex = 8;
            this.colED.Width = 30;
            // 
            // colIN
            // 
            this.colIN.Caption = "IN";
            this.colIN.ColumnEdit = this.repModulIcon;
            this.colIN.FieldName = "IN";
            this.colIN.Name = "colIN";
            this.colIN.OptionsColumn.AllowMove = false;
            this.colIN.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.colIN.OptionsColumn.AllowSize = false;
            this.colIN.OptionsColumn.FixedWidth = true;
            this.colIN.OptionsColumn.ShowInCustomizationForm = false;
            this.colIN.VisibleIndex = 9;
            this.colIN.Width = 30;
            // 
            // colAB
            // 
            this.colAB.Caption = "AB";
            this.colAB.ColumnEdit = this.repModulIcon;
            this.colAB.FieldName = "AB";
            this.colAB.Name = "colAB";
            this.colAB.OptionsColumn.AllowMove = false;
            this.colAB.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.colAB.OptionsColumn.AllowSize = false;
            this.colAB.OptionsColumn.FixedWidth = true;
            this.colAB.OptionsColumn.ShowInCustomizationForm = false;
            this.colAB.VisibleIndex = 10;
            this.colAB.Width = 30;
            // 
            // colWD
            // 
            this.colWD.Caption = "WD";
            this.colWD.ColumnEdit = this.repModulIcon;
            this.colWD.FieldName = "WD";
            this.colWD.Name = "colWD";
            this.colWD.OptionsColumn.AllowMove = false;
            this.colWD.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.colWD.OptionsColumn.AllowSize = false;
            this.colWD.OptionsColumn.FixedWidth = true;
            this.colWD.OptionsColumn.ShowInCustomizationForm = false;
            this.colWD.VisibleIndex = 11;
            this.colWD.Width = 32;
            // 
            // colWohnort
            // 
            this.colWohnort.Caption = "Wohnort";
            this.colWohnort.FieldName = "Wohnort";
            this.colWohnort.Name = "colWohnort";
            this.colWohnort.VisibleIndex = 12;
            this.colWohnort.Width = 110;
            // 
            // colBaPersonID
            // 
            this.colBaPersonID.Caption = "BaPersonID";
            this.colBaPersonID.FieldName = "BaPersonID";
            this.colBaPersonID.Name = "colBaPersonID";
            this.colBaPersonID.OptionsColumn.AllowSort = false;
            // 
            // chkFV
            // 
            this.chkFV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkFV.EditValue = "False";
            this.chkFV.Location = new System.Drawing.Point(8, 33);
            this.chkFV.Name = "chkFV";
            this.chkFV.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkFV.Properties.Appearance.Options.UseBackColor = true;
            this.chkFV.Properties.Caption = " .";
            this.chkFV.Properties.Name = "chkSB.Properties";
            this.chkFV.Size = new System.Drawing.Size(22, 19);
            this.chkFV.TabIndex = 1;
            this.chkFV.CheckedChanged += new System.EventHandler(this.Checkbox_CheckedChanged);
            // 
            // picFV
            // 
            this.picFV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picFV.Location = new System.Drawing.Point(10, 9);
            this.picFV.Name = "picFV";
            this.picFV.Size = new System.Drawing.Size(16, 16);
            this.picFV.TabIndex = 1;
            this.picFV.TabStop = false;
            // 
            // picSB
            // 
            this.picSB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picSB.Location = new System.Drawing.Point(32, 9);
            this.picSB.Name = "picSB";
            this.picSB.Size = new System.Drawing.Size(16, 16);
            this.picSB.TabIndex = 1;
            this.picSB.TabStop = false;
            // 
            // chkSB
            // 
            this.chkSB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkSB.EditValue = "False";
            this.chkSB.Location = new System.Drawing.Point(30, 33);
            this.chkSB.Name = "chkSB";
            this.chkSB.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkSB.Properties.Appearance.Options.UseBackColor = true;
            this.chkSB.Properties.Caption = " .";
            this.chkSB.Properties.Name = "chkSB.Properties";
            this.chkSB.Size = new System.Drawing.Size(22, 19);
            this.chkSB.TabIndex = 2;
            this.chkSB.CheckedChanged += new System.EventHandler(this.Checkbox_CheckedChanged);
            // 
            // picCM
            // 
            this.picCM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picCM.Location = new System.Drawing.Point(54, 9);
            this.picCM.Name = "picCM";
            this.picCM.Size = new System.Drawing.Size(16, 16);
            this.picCM.TabIndex = 2;
            this.picCM.TabStop = false;
            // 
            // chkCM
            // 
            this.chkCM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkCM.EditValue = "False";
            this.chkCM.Location = new System.Drawing.Point(52, 33);
            this.chkCM.Name = "chkCM";
            this.chkCM.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkCM.Properties.Appearance.Options.UseBackColor = true;
            this.chkCM.Properties.Caption = " .";
            this.chkCM.Properties.Name = "chkCM.Properties";
            this.chkCM.Size = new System.Drawing.Size(22, 19);
            this.chkCM.TabIndex = 3;
            this.chkCM.CheckedChanged += new System.EventHandler(this.Checkbox_CheckedChanged);
            // 
            // chkBW
            // 
            this.chkBW.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkBW.EditValue = "False";
            this.chkBW.Location = new System.Drawing.Point(74, 33);
            this.chkBW.Name = "chkBW";
            this.chkBW.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkBW.Properties.Appearance.Options.UseBackColor = true;
            this.chkBW.Properties.Caption = " .";
            this.chkBW.Properties.Name = "chkBW.Properties";
            this.chkBW.Size = new System.Drawing.Size(22, 19);
            this.chkBW.TabIndex = 4;
            this.chkBW.CheckedChanged += new System.EventHandler(this.Checkbox_CheckedChanged);
            // 
            // picBW
            // 
            this.picBW.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picBW.Location = new System.Drawing.Point(76, 9);
            this.picBW.Name = "picBW";
            this.picBW.Size = new System.Drawing.Size(16, 16);
            this.picBW.TabIndex = 4;
            this.picBW.TabStop = false;
            // 
            // chkED
            // 
            this.chkED.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkED.EditValue = "False";
            this.chkED.Location = new System.Drawing.Point(96, 33);
            this.chkED.Name = "chkED";
            this.chkED.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkED.Properties.Appearance.Options.UseBackColor = true;
            this.chkED.Properties.Caption = " .";
            this.chkED.Properties.Name = "chkED.Properties";
            this.chkED.Size = new System.Drawing.Size(22, 19);
            this.chkED.TabIndex = 5;
            this.chkED.CheckedChanged += new System.EventHandler(this.Checkbox_CheckedChanged);
            // 
            // picED
            // 
            this.picED.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picED.Location = new System.Drawing.Point(98, 9);
            this.picED.Name = "picED";
            this.picED.Size = new System.Drawing.Size(16, 16);
            this.picED.TabIndex = 5;
            this.picED.TabStop = false;
            // 
            // picIN
            // 
            this.picIN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picIN.Location = new System.Drawing.Point(120, 9);
            this.picIN.Name = "picIN";
            this.picIN.Size = new System.Drawing.Size(16, 16);
            this.picIN.TabIndex = 5;
            this.picIN.TabStop = false;
            // 
            // chkIN
            // 
            this.chkIN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkIN.EditValue = "False";
            this.chkIN.Location = new System.Drawing.Point(118, 33);
            this.chkIN.Name = "chkIN";
            this.chkIN.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkIN.Properties.Appearance.Options.UseBackColor = true;
            this.chkIN.Properties.Caption = " .";
            this.chkIN.Properties.Name = "chkED.Properties";
            this.chkIN.Size = new System.Drawing.Size(22, 19);
            this.chkIN.TabIndex = 6;
            this.chkIN.CheckedChanged += new System.EventHandler(this.Checkbox_CheckedChanged);
            // 
            // chkAbgeschlossene
            // 
            this.chkAbgeschlossene.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkAbgeschlossene.EditValue = "False";
            this.chkAbgeschlossene.Location = new System.Drawing.Point(198, 33);
            this.chkAbgeschlossene.Name = "chkAbgeschlossene";
            this.chkAbgeschlossene.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkAbgeschlossene.Properties.Appearance.Options.UseBackColor = true;
            this.chkAbgeschlossene.Properties.Caption = "Abgeschlossene";
            this.chkAbgeschlossene.Properties.Name = "editAbgeschlossene.Properties";
            this.chkAbgeschlossene.Size = new System.Drawing.Size(106, 19);
            this.chkAbgeschlossene.TabIndex = 7;
            this.chkAbgeschlossene.CheckedChanged += new System.EventHandler(this.Checkbox_CheckedChanged);
            // 
            // chkGastrecht
            // 
            this.chkGastrecht.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkGastrecht.EditValue = "False";
            this.chkGastrecht.Location = new System.Drawing.Point(310, 33);
            this.chkGastrecht.Name = "chkGastrecht";
            this.chkGastrecht.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkGastrecht.Properties.Appearance.Options.UseBackColor = true;
            this.chkGastrecht.Properties.Caption = "Gastrecht";
            this.chkGastrecht.Properties.Name = "editGastrecht.Properties";
            this.chkGastrecht.Size = new System.Drawing.Size(96, 19);
            this.chkGastrecht.TabIndex = 8;
            this.chkGastrecht.CheckedChanged += new System.EventHandler(this.Checkbox_CheckedChanged);
            // 
            // chkGruppe
            // 
            this.chkGruppe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkGruppe.EditValue = "False";
            this.chkGruppe.Location = new System.Drawing.Point(412, 33);
            this.chkGruppe.Name = "chkGruppe";
            this.chkGruppe.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkGruppe.Properties.Appearance.Options.UseBackColor = true;
            this.chkGruppe.Properties.Caption = "Gruppe";
            this.chkGruppe.Properties.Name = "editGruppe.Properties";
            this.chkGruppe.Size = new System.Drawing.Size(75, 19);
            this.chkGruppe.TabIndex = 9;
            this.chkGruppe.CheckedChanged += new System.EventHandler(this.Checkbox_CheckedChanged);
            // 
            // btnFall
            // 
            this.btnFall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFall.Location = new System.Drawing.Point(509, 1);
            this.btnFall.Name = "btnFall";
            this.btnFall.Size = new System.Drawing.Size(88, 24);
            this.btnFall.TabIndex = 10;
            this.btnFall.Text = ">Fall";
            this.btnFall.UseCompatibleTextRendering = true;
            this.btnFall.UseVisualStyleBackColor = false;
            this.btnFall.Click += new System.EventHandler(this.btnFall_Click);
            // 
            // btnNeuerFall
            // 
            this.btnNeuerFall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNeuerFall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNeuerFall.Location = new System.Drawing.Point(611, 1);
            this.btnNeuerFall.Name = "btnNeuerFall";
            this.btnNeuerFall.Size = new System.Drawing.Size(88, 24);
            this.btnNeuerFall.TabIndex = 11;
            this.btnNeuerFall.Text = "neuer Fall ...";
            this.btnNeuerFall.UseCompatibleTextRendering = true;
            this.btnNeuerFall.UseVisualStyleBackColor = false;
            this.btnNeuerFall.Click += new System.EventHandler(this.btnNeuerFall_Click);
            // 
            // lblAnzahlPersonen
            // 
            this.lblAnzahlPersonen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAnzahlPersonen.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblAnzahlPersonen.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblAnzahlPersonen.Location = new System.Drawing.Point(509, 34);
            this.lblAnzahlPersonen.Name = "lblAnzahlPersonen";
            this.lblAnzahlPersonen.Size = new System.Drawing.Size(190, 18);
            this.lblAnzahlPersonen.TabIndex = 12;
            this.lblAnzahlPersonen.Tag = "";
            this.lblAnzahlPersonen.Text = "";
            this.lblAnzahlPersonen.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblAnzahlPersonen.UseCompatibleTextRendering = true;
            // 
            // btnFallInfo
            // 
            this.btnFallInfo.Caption = "Fallinfo";
            this.btnFallInfo.Id = -1;
            this.btnFallInfo.Name = "btnFallInfo";
            this.btnFallInfo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFallInfo_ItemClick);
            // 
            // colN
            // 
            this.colN.Caption = "N";
            this.colN.FieldName = "N";
            this.colN.Name = "colN";
            this.colN.VisibleIndex = 7;
            this.colN.Width = 24;
            // 
            // qryModul
            // 
            this.qryModul.FillTimeOut = 90;
            this.qryModul.HostControl = this;
            // 
            // picAB
            // 
            this.picAB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picAB.Location = new System.Drawing.Point(142, 9);
            this.picAB.Name = "picAB";
            this.picAB.Size = new System.Drawing.Size(16, 16);
            this.picAB.TabIndex = 5;
            this.picAB.TabStop = false;
            // 
            // chkAB
            // 
            this.chkAB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkAB.EditValue = "False";
            this.chkAB.Location = new System.Drawing.Point(140, 33);
            this.chkAB.Name = "chkAB";
            this.chkAB.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkAB.Properties.Appearance.Options.UseBackColor = true;
            this.chkAB.Properties.Caption = " .";
            this.chkAB.Properties.Name = "chkED.Properties";
            this.chkAB.Size = new System.Drawing.Size(22, 19);
            this.chkAB.TabIndex = 6;
            this.chkAB.CheckedChanged += new System.EventHandler(this.Checkbox_CheckedChanged);
            // 
            // chkWD
            // 
            this.chkWD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkWD.EditValue = "False";
            this.chkWD.Location = new System.Drawing.Point(162, 33);
            this.chkWD.Name = "chkWD";
            this.chkWD.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkWD.Properties.Appearance.Options.UseBackColor = true;
            this.chkWD.Properties.Caption = " .";
            this.chkWD.Properties.Name = "chkED.Properties";
            this.chkWD.Size = new System.Drawing.Size(22, 19);
            this.chkWD.TabIndex = 14;
            this.chkWD.CheckedChanged += new System.EventHandler(this.Checkbox_CheckedChanged);
            // 
            // picWD
            // 
            this.picWD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picWD.Location = new System.Drawing.Point(164, 9);
            this.picWD.Name = "picWD";
            this.picWD.Size = new System.Drawing.Size(16, 16);
            this.picWD.TabIndex = 13;
            this.picWD.TabStop = false;
            // 
            // panBottom
            // 
            this.panBottom.Controls.Add(this.btnNeuerFall);
            this.panBottom.Controls.Add(this.chkWD);
            this.panBottom.Controls.Add(this.lblAnzahlPersonen);
            this.panBottom.Controls.Add(this.picWD);
            this.panBottom.Controls.Add(this.chkFV);
            this.panBottom.Controls.Add(this.picFV);
            this.panBottom.Controls.Add(this.btnFall);
            this.panBottom.Controls.Add(this.picSB);
            this.panBottom.Controls.Add(this.chkGruppe);
            this.panBottom.Controls.Add(this.chkSB);
            this.panBottom.Controls.Add(this.chkGastrecht);
            this.panBottom.Controls.Add(this.picCM);
            this.panBottom.Controls.Add(this.chkAbgeschlossene);
            this.panBottom.Controls.Add(this.chkCM);
            this.panBottom.Controls.Add(this.chkAB);
            this.panBottom.Controls.Add(this.chkBW);
            this.panBottom.Controls.Add(this.picAB);
            this.panBottom.Controls.Add(this.picBW);
            this.panBottom.Controls.Add(this.chkIN);
            this.panBottom.Controls.Add(this.chkED);
            this.panBottom.Controls.Add(this.picIN);
            this.panBottom.Controls.Add(this.picED);
            this.panBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panBottom.Location = new System.Drawing.Point(0, 421);
            this.panBottom.Name = "panBottom";
            this.panBottom.Size = new System.Drawing.Size(709, 61);
            this.panBottom.TabIndex = 15;
            // 
            // CtlFallNavigator
            // 
            this.Controls.Add(this.panBottom);
            this.Controls.Add(this.treFallNavigator);
            this.Name = "CtlFallNavigator";
            this.Size = new System.Drawing.Size(709, 482);
            this.RefreshData += new System.EventHandler(this.CtlFallNavigator_RefreshData);
            this.Load += new System.EventHandler(this.CtlFallNavigator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.treFallNavigator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repModulIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCM.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBW.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkED.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picED)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAbgeschlossene.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGastrecht.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGruppe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnzahlPersonen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryModul)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkWD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWD)).EndInit();
            this.panBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarManager barManager_Tree;
        private KiSS4.Gui.KissButton btnFall;
        private DevExpress.XtraBars.BarButtonItem btnFallInfo;
        private KiSS4.Gui.KissButton btnNeuerFall;
        private KiSS4.Gui.KissCheckEdit chkAbgeschlossene;
        private KiSS4.Gui.KissCheckEdit chkBW;
        private KiSS4.Gui.KissCheckEdit chkCM;
        private KiSS4.Gui.KissCheckEdit chkED;
        private KiSS4.Gui.KissCheckEdit chkFV;
        private KiSS4.Gui.KissCheckEdit chkGastrecht;
        private KiSS4.Gui.KissCheckEdit chkGruppe;
        private KiSS4.Gui.KissCheckEdit chkIN;
        private KiSS4.Gui.KissCheckEdit chkSB;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAlter;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colBW;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colBaPersonID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCM;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colED;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colFallverlauf;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIN;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colModulDLSpace;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colN;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colP;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSB;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colType;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colWohnort;
        private KiSS4.Gui.KissLabel lblAnzahlPersonen;
        private System.Windows.Forms.PictureBox picBW;
        private System.Windows.Forms.PictureBox picCM;
        private System.Windows.Forms.PictureBox picED;
        private System.Windows.Forms.PictureBox picFV;
        private System.Windows.Forms.PictureBox picIN;
        private System.Windows.Forms.PictureBox picSB;
        private DevExpress.XtraBars.PopupMenu popup_Tree;
        private KiSS4.DB.SqlQuery qryModul;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repModulIcon;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAB;
        private KiSS4.Gui.KissCheckEdit chkAB;
        private System.Windows.Forms.PictureBox picAB;
        private KiSS4.Gui.KissTree treFallNavigator;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colWD;
        private Gui.KissCheckEdit chkWD;
        private System.Windows.Forms.PictureBox picWD;
        private System.Windows.Forms.Panel panBottom;
    }
}
