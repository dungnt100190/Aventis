namespace KiSS4.Query
{
    partial class CtlQueryShPapierverfuegung
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryShPapierverfuegung));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.edtJahr = new KiSS4.Gui.KissCalcEdit();
            this.lblJahr = new KiSS4.Gui.KissLabel();
            this.edtUserID = new KiSS4.Gui.KissButtonEdit();
            this.lblSAR = new KiSS4.Gui.KissLabel();
            this.edtMonat = new KiSS4.Gui.KissLookUpEdit();
            this.lblMonat = new KiSS4.Gui.KissLabel();
            this.lblAktion = new KiSS4.Gui.KissLabel();
            this.btnPrint = new KiSS4.Gui.KissButton();
            this.btnAbbruch = new KiSS4.Gui.KissButton();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colSAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKlient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBudgetID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKbBuchungID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBudgetMonat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIntern = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSelPrint = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkPreview = new KiSS4.Gui.KissCheckEdit();
            this.btnSelectNone = new KiSS4.Gui.KissButton();
            this.btnSelectAll = new KiSS4.Gui.KissButton();
            this.btnGotoBudget = new KiSS4.Gui.KissButton();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtJahr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJahr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMonat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMonat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMonat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAktion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPreview.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.CanUpdate = true;
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            this.qryQuery.TableName = "vwShMassendruckPapierverfuegung";
            this.qryQuery.BeforePost += new System.EventHandler(this.qryQuery_BeforePost);
            this.qryQuery.AfterFill += new System.EventHandler(this.qryQuery_AfterFill);
            // 
            // grvQuery1
            // 
            this.grvQuery1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvQuery1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.Empty.Options.UseBackColor = true;
            this.grvQuery1.Appearance.Empty.Options.UseFont = true;
            this.grvQuery1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvQuery1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.EvenRow.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.grvQuery1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvQuery1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvQuery1.Appearance.FocusedCell.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvQuery1.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvQuery1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.grvQuery1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.FocusedRow.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvQuery1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseFont = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvQuery1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvQuery1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvQuery1.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvQuery1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvQuery1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.grvQuery1.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvQuery1.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvQuery1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.OddRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.OddRow.Options.UseFont = true;
            this.grvQuery1.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.grvQuery1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.Row.Options.UseBackColor = true;
            this.grvQuery1.Appearance.Row.Options.UseFont = true;
            this.grvQuery1.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvQuery1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvQuery1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.SelectedRow.Options.UseFont = true;
            this.grvQuery1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.grvQuery1.Appearance.VertLine.Options.UseBackColor = true;
            this.grvQuery1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBudgetID,
            this.colKbBuchungID,
            this.colSAR,
            this.colKlient,
            this.colBudgetMonat,
            this.colIntern,
            this.colBetrag,
            this.colSelPrint});
            this.grvQuery1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.CellFocus;
            this.grvQuery1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvQuery1.OptionsNavigation.AutoFocusNewRow = true;
            this.grvQuery1.OptionsPrint.AutoWidth = false;
            this.grvQuery1.OptionsPrint.ExpandAllDetails = true;
            this.grvQuery1.OptionsPrint.UsePrintStyles = true;
            this.grvQuery1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.grvQuery1.OptionsView.ColumnAutoWidth = false;
            this.grvQuery1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvQuery1.OptionsView.ShowGroupPanel = false;
            this.grvQuery1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grvQuery1_CustomDrawCell);
            // 
            // grdQuery1
            // 
            this.grdQuery1.EmbeddedNavigator.Name = "";
            this.grdQuery1.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdQuery1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.grdQuery1.Size = new System.Drawing.Size(766, 361);
            // 
            // xDocument
            // 
            this.xDocument.Location = new System.Drawing.Point(3, 372);
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.xDocument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("xDocument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Dokument öffnen")});
            this.xDocument.Visible = false;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = "BaPersonID";
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.btnGotoBudget);
            this.tpgListe.Controls.Add(this.btnSelectNone);
            this.tpgListe.Controls.Add(this.btnSelectAll);
            this.tpgListe.Controls.Add(this.chkPreview);
            this.tpgListe.Controls.Add(this.btnAbbruch);
            this.tpgListe.Controls.Add(this.btnPrint);
            this.tpgListe.Controls.Add(this.lblAktion);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Controls.SetChildIndex(this.grdQuery1, 0);
            this.tpgListe.Controls.SetChildIndex(this.ctlGotoFall, 0);
            this.tpgListe.Controls.SetChildIndex(this.xDocument, 0);
            this.tpgListe.Controls.SetChildIndex(this.lblAktion, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnPrint, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnAbbruch, 0);
            this.tpgListe.Controls.SetChildIndex(this.chkPreview, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnSelectAll, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnSelectNone, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnGotoBudget, 0);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtMonat);
            this.tpgSuchen.Controls.Add(this.lblMonat);
            this.tpgSuchen.Controls.Add(this.edtJahr);
            this.tpgSuchen.Controls.Add(this.lblJahr);
            this.tpgSuchen.Controls.Add(this.edtUserID);
            this.tpgSuchen.Controls.Add(this.lblSAR);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSAR, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUserID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblJahr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtJahr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblMonat, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtMonat, 0);
            // 
            // edtJahr
            // 
            this.edtJahr.Location = new System.Drawing.Point(77, 108);
            this.edtJahr.Name = "edtJahr";
            this.edtJahr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtJahr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtJahr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtJahr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtJahr.Properties.Appearance.Options.UseBackColor = true;
            this.edtJahr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtJahr.Properties.Appearance.Options.UseFont = true;
            this.edtJahr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtJahr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtJahr.Size = new System.Drawing.Size(60, 24);
            this.edtJahr.TabIndex = 6;
            // 
            // lblJahr
            // 
            this.lblJahr.Location = new System.Drawing.Point(13, 108);
            this.lblJahr.Name = "lblJahr";
            this.lblJahr.Size = new System.Drawing.Size(58, 24);
            this.lblJahr.TabIndex = 5;
            this.lblJahr.Text = "Jahr";
            this.lblJahr.UseCompatibleTextRendering = true;
            // 
            // edtUserID
            // 
            this.edtUserID.Location = new System.Drawing.Point(77, 48);
            this.edtUserID.LookupSQL = "select ID = UserID, \r\nSAR = LastName + isNull(\', \' + FirstName,\'\'), \r\n[Kuerzel] =" +
                " LogonName\r\nfrom   XUser where LastName + isNull(\', \' + FirstName,\'\') like isNul" +
                "l({0},\'\') + \'%\' \r\norder by SAR";
            this.edtUserID.Name = "edtUserID";
            this.edtUserID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUserID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserID.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserID.Properties.Appearance.Options.UseFont = true;
            this.edtUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtUserID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtUserID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUserID.Size = new System.Drawing.Size(250, 24);
            this.edtUserID.TabIndex = 2;
            // 
            // lblSAR
            // 
            this.lblSAR.Location = new System.Drawing.Point(13, 48);
            this.lblSAR.Name = "lblSAR";
            this.lblSAR.Size = new System.Drawing.Size(58, 24);
            this.lblSAR.TabIndex = 1;
            this.lblSAR.Text = "SAR";
            this.lblSAR.UseCompatibleTextRendering = true;
            // 
            // edtMonat
            // 
            this.edtMonat.Location = new System.Drawing.Point(77, 78);
            this.edtMonat.Name = "edtMonat";
            this.edtMonat.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMonat.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMonat.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMonat.Properties.Appearance.Options.UseBackColor = true;
            this.edtMonat.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMonat.Properties.Appearance.Options.UseFont = true;
            this.edtMonat.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtMonat.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtMonat.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtMonat.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtMonat.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtMonat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtMonat.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtMonat.Properties.NullText = "";
            this.edtMonat.Properties.ShowFooter = false;
            this.edtMonat.Properties.ShowHeader = false;
            this.edtMonat.Size = new System.Drawing.Size(149, 24);
            this.edtMonat.TabIndex = 4;
            // 
            // lblMonat
            // 
            this.lblMonat.Location = new System.Drawing.Point(13, 78);
            this.lblMonat.Name = "lblMonat";
            this.lblMonat.Size = new System.Drawing.Size(58, 24);
            this.lblMonat.TabIndex = 3;
            this.lblMonat.Text = "Monat";
            this.lblMonat.UseCompatibleTextRendering = true;
            // 
            // lblAktion
            // 
            this.lblAktion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAktion.Location = new System.Drawing.Point(185, 397);
            this.lblAktion.Name = "lblAktion";
            this.lblAktion.Size = new System.Drawing.Size(218, 24);
            this.lblAktion.TabIndex = 6;
            this.lblAktion.Text = "Aktion";
            this.lblAktion.UseCompatibleTextRendering = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Location = new System.Drawing.Point(665, 397);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(104, 24);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Text = "Massendruck";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnAbbruch
            // 
            this.btnAbbruch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbbruch.Enabled = false;
            this.btnAbbruch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbbruch.Location = new System.Drawing.Point(569, 397);
            this.btnAbbruch.Name = "btnAbbruch";
            this.btnAbbruch.Size = new System.Drawing.Size(90, 24);
            this.btnAbbruch.TabIndex = 8;
            this.btnAbbruch.Text = "Abbruch";
            this.btnAbbruch.UseVisualStyleBackColor = true;
            this.btnAbbruch.Click += new System.EventHandler(this.btnAbbruch_Click);
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // colSAR
            // 
            this.colSAR.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colSAR.AppearanceCell.Options.UseBackColor = true;
            this.colSAR.Caption = "SAR";
            this.colSAR.FieldName = "SAR";
            this.colSAR.Name = "colSAR";
            this.colSAR.OptionsColumn.AllowEdit = false;
            this.colSAR.Visible = true;
            this.colSAR.VisibleIndex = 6;
            // 
            // colKlient
            // 
            this.colKlient.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colKlient.AppearanceCell.Options.UseBackColor = true;
            this.colKlient.Caption = "Klient";
            this.colKlient.FieldName = "Klient";
            this.colKlient.Name = "colKlient";
            this.colKlient.OptionsColumn.AllowEdit = false;
            this.colKlient.Visible = true;
            this.colKlient.VisibleIndex = 2;
            // 
            // colBudgetID
            // 
            this.colBudgetID.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colBudgetID.AppearanceCell.Options.UseBackColor = true;
            this.colBudgetID.Caption = "Budget";
            this.colBudgetID.FieldName = "BgBudgetID";
            this.colBudgetID.Name = "colBudgetID";
            this.colBudgetID.OptionsColumn.AllowEdit = false;
            //this.colBudgetID.Visible = true;
            //this.colBudgetID.VisibleIndex = 0;
            // 
            // colKbBuchungID
            // 
            this.colKbBuchungID.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colKbBuchungID.AppearanceCell.Options.UseBackColor = true;
            this.colKbBuchungID.Caption = "Buchung ID";
            this.colKbBuchungID.FieldName = "KbBuchungID";
            this.colKbBuchungID.Name = "colKbBuchungID";
            this.colKbBuchungID.OptionsColumn.AllowEdit = false;
            // 
            // colBudgetMonat
            // 
            this.colBudgetMonat.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colBudgetMonat.AppearanceCell.Options.UseBackColor = true;
            this.colBudgetMonat.Caption = "Budget Monat";
            this.colBudgetMonat.FieldName = "BudgetMonat";
            this.colBudgetMonat.Name = "colBudgetMonat";
            this.colBudgetMonat.OptionsColumn.AllowEdit = false;
            this.colBudgetMonat.Visible = true;
            this.colBudgetMonat.VisibleIndex = 4;
            // 
            // colIntern
            // 
            this.colIntern.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colIntern.AppearanceCell.Options.UseBackColor = true;
            this.colIntern.Caption = "Buchungstext";
            this.colIntern.FieldName = "Intern";
            this.colIntern.Name = "colIntern";
            this.colIntern.OptionsColumn.AllowEdit = false;
            this.colIntern.Visible = true;
            this.colIntern.VisibleIndex = 5;
            // 
            // colBetrag
            // 
            this.colBetrag.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colBetrag.AppearanceCell.Options.UseBackColor = true;
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.FieldName = "Betrag";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.OptionsColumn.AllowEdit = false;
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 3;
            // 
            // colSelPrint
            // 
            this.colSelPrint.Caption = "Drucken";
            this.colSelPrint.FieldName = "SelPrint";
            this.colSelPrint.Name = "colSelPrint";
            this.colSelPrint.Visible = true;
            this.colSelPrint.VisibleIndex = 1;
            // 
            // chkPreview
            // 
            this.chkPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPreview.EditValue = false;
            this.chkPreview.Location = new System.Drawing.Point(569, 372);
            this.chkPreview.Name = "chkPreview";
            this.chkPreview.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkPreview.Properties.Appearance.Options.UseBackColor = true;
            this.chkPreview.Properties.Caption = "Druckvorschau";
            this.chkPreview.Size = new System.Drawing.Size(105, 19);
            this.chkPreview.TabIndex = 47;
            // 
            // btnSelectNone
            // 
            this.btnSelectNone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectNone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectNone.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectNone.Image")));
            this.btnSelectNone.Location = new System.Drawing.Point(745, 367);
            this.btnSelectNone.Name = "btnSelectNone";
            this.btnSelectNone.Size = new System.Drawing.Size(24, 24);
            this.btnSelectNone.TabIndex = 49;
            this.btnSelectNone.UseCompatibleTextRendering = true;
            this.btnSelectNone.UseVisualStyleBackColor = false;
            this.btnSelectNone.Click += new System.EventHandler(this.btnSelectNone_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectAll.Image")));
            this.btnSelectAll.Location = new System.Drawing.Point(715, 367);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(24, 24);
            this.btnSelectAll.TabIndex = 48;
            this.btnSelectAll.UseCompatibleTextRendering = true;
            this.btnSelectAll.UseVisualStyleBackColor = false;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnGotoBudget
            // 
            this.btnGotoBudget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGotoBudget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGotoBudget.Location = new System.Drawing.Point(409, 397);
            this.btnGotoBudget.Name = "btnGotoBudget";
            this.btnGotoBudget.Size = new System.Drawing.Size(119, 24);
            this.btnGotoBudget.TabIndex = 50;
            this.btnGotoBudget.Text = "> &Monatsbudget";
            this.btnGotoBudget.UseCompatibleTextRendering = true;
            this.btnGotoBudget.UseVisualStyleBackColor = false;
            this.btnGotoBudget.Click += new System.EventHandler(this.btnGotoBudget_Click);
            // 
            // CtlQueryShPapierverfuegung
            // 

            this.Name = "CtlQueryShPapierverfuegung";
            this.Print += new System.EventHandler(this.CtlQueryShPapierverfuegung_Print);
            this.Load += new System.EventHandler(this.CtlQueryShPapierverfuegung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtJahr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJahr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMonat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMonat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMonat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAktion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPreview.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KiSS4.Gui.KissCalcEdit edtJahr;
        private KiSS4.Gui.KissLabel lblJahr;
        private KiSS4.Gui.KissButtonEdit edtUserID;
        private KiSS4.Gui.KissLabel lblSAR;
        private KiSS4.Gui.KissLookUpEdit edtMonat;
        private KiSS4.Gui.KissLabel lblMonat;
        private KiSS4.Gui.KissLabel lblAktion;
        private KiSS4.Gui.KissButton btnPrint;
        private KiSS4.Gui.KissButton btnAbbruch;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colBudgetID;
        private DevExpress.XtraGrid.Columns.GridColumn colKbBuchungID;
        private DevExpress.XtraGrid.Columns.GridColumn colSAR;
        private DevExpress.XtraGrid.Columns.GridColumn colKlient;
        private DevExpress.XtraGrid.Columns.GridColumn colBudgetMonat;
        private DevExpress.XtraGrid.Columns.GridColumn colIntern;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colSelPrint;
        private KiSS4.Gui.KissCheckEdit chkPreview;
        private KiSS4.Gui.KissButton btnSelectNone;
        private KiSS4.Gui.KissButton btnSelectAll;
        private KiSS4.Gui.KissButton btnGotoBudget;
    }
}
