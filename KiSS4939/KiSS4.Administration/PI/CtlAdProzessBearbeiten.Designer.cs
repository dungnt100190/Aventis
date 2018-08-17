namespace KiSS4.Administration.PI
{
    partial class CtlAdProzessBearbeiten
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlAdProzessBearbeiten));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryBaPerson = new KiSS4.DB.SqlQuery();
            this.ctlFallInfo = new KiSS4.Common.PI.CtlFallInfo();
            this.splitter = new KiSS4.Gui.KissSplitterCollapsible();
            this.lblSuchePersonenNr = new KiSS4.Gui.KissLabel();
            this.edtSucheName = new KiSS4.Gui.KissTextEdit();
            this.edtSuchePersonenNr = new KiSS4.Gui.KissCalcEdit();
            this.lblSucheName = new KiSS4.Gui.KissLabel();
            this.edtSucheVorname = new KiSS4.Gui.KissTextEdit();
            this.lblSucheVorname = new KiSS4.Gui.KissLabel();
            this.lblSucheModulID = new KiSS4.Gui.KissLabel();
            this.lblSucheProzessNr = new KiSS4.Gui.KissLabel();
            this.edtSucheProzessNr = new KiSS4.Gui.KissCalcEdit();
            this.edtSucheModulID = new KiSS4.Gui.KissLookUpEdit();
            this.grdBaPerson = new KiSS4.Gui.KissGrid();
            this.grvBaPerson = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeschlecht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVersNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrasse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerantwortlicherFV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panGotoFall = new System.Windows.Forms.Panel();
            this.lblCount = new KiSS4.Gui.KissLabel();
            this.ctlGotoFall = new KiSS4.Common.CtlGotoFall();
            this.lblAbwesenheitswochenLoeschen = new KiSS4.Gui.KissLabel();
            this.panAbwesenheitswochenLoeschen = new System.Windows.Forms.Panel();
            this.btnAbwesenheitswochenLoeschen = new KiSS4.Gui.KissButton();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchePersonenNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchePersonenNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVorname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheModulID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheProzessNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheProzessNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheModulID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheModulID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaPerson)).BeginInit();
            this.panGotoFall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbwesenheitswochenLoeschen)).BeginInit();
            this.panAbwesenheitswochenLoeschen.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(789, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 0);
            this.tabControlSearch.Size = new System.Drawing.Size(820, 200);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdBaPerson);
            this.tpgListe.Controls.Add(this.panGotoFall);
            this.tpgListe.Size = new System.Drawing.Size(808, 162);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtSuchePersonenNr);
            this.tpgSuchen.Controls.Add(this.lblSuchePersonenNr);
            this.tpgSuchen.Controls.Add(this.edtSucheModulID);
            this.tpgSuchen.Controls.Add(this.edtSucheProzessNr);
            this.tpgSuchen.Controls.Add(this.edtSucheName);
            this.tpgSuchen.Controls.Add(this.lblSucheProzessNr);
            this.tpgSuchen.Controls.Add(this.lblSucheName);
            this.tpgSuchen.Controls.Add(this.lblSucheModulID);
            this.tpgSuchen.Controls.Add(this.lblSucheVorname);
            this.tpgSuchen.Controls.Add(this.edtSucheVorname);
            this.tpgSuchen.Size = new System.Drawing.Size(808, 162);
            this.tpgSuchen.TabIndex = 0;
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheVorname, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheVorname, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheModulID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheProzessNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheProzessNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheModulID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSuchePersonenNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSuchePersonenNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            // 
            // qryBaPerson
            // 
            this.qryBaPerson.FillTimeOut = 60;
            this.qryBaPerson.HostControl = this;
            this.qryBaPerson.SelectStatement = resources.GetString("qryBaPerson.SelectStatement");
            this.qryBaPerson.AfterFill += new System.EventHandler(this.qryBaPerson_AfterFill);
            this.qryBaPerson.PositionChanged += new System.EventHandler(this.qryBaPerson_PositionChanged);
            // 
            // ctlFallInfo
            // 
            this.ctlFallInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlFallInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlFallInfo.CurrentAccessMode = KiSS4.Common.PI.CtlFallInfo.AccessMode.AllowEdit;
            this.ctlFallInfo.Location = new System.Drawing.Point(0, 208);
            this.ctlFallInfo.Name = "ctlFallInfo";
            this.ctlFallInfo.Size = new System.Drawing.Size(820, 366);
            this.ctlFallInfo.TabIndex = 2;
            // 
            // splitter
            // 
            this.splitter.AnimationDelay = 20;
            this.splitter.AnimationStep = 20;
            this.splitter.BorderStyle3D = System.Windows.Forms.Border3DStyle.Etched;
            this.splitter.ControlToHide = this.tabControlSearch;
            this.splitter.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter.ExpandParentForm = false;
            this.splitter.Location = new System.Drawing.Point(0, 200);
            this.splitter.Name = "splitter";
            this.splitter.TabIndex = 1;
            this.splitter.TabStop = false;
            this.splitter.UseAnimations = false;
            this.splitter.VisualStyle = KiSS4.Gui.VisualStyles.Mozilla;
            // 
            // lblSuchePersonenNr
            // 
            this.lblSuchePersonenNr.Location = new System.Drawing.Point(31, 40);
            this.lblSuchePersonenNr.Name = "lblSuchePersonenNr";
            this.lblSuchePersonenNr.Size = new System.Drawing.Size(86, 24);
            this.lblSuchePersonenNr.TabIndex = 1;
            this.lblSuchePersonenNr.Text = "Personen-Nr.";
            // 
            // edtSucheName
            // 
            this.edtSucheName.Location = new System.Drawing.Point(123, 70);
            this.edtSucheName.Name = "edtSucheName";
            this.edtSucheName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheName.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheName.Properties.Appearance.Options.UseFont = true;
            this.edtSucheName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheName.Size = new System.Drawing.Size(230, 24);
            this.edtSucheName.TabIndex = 4;
            // 
            // edtSuchePersonenNr
            // 
            this.edtSuchePersonenNr.Location = new System.Drawing.Point(123, 40);
            this.edtSuchePersonenNr.Name = "edtSuchePersonenNr";
            this.edtSuchePersonenNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSuchePersonenNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSuchePersonenNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSuchePersonenNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSuchePersonenNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtSuchePersonenNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSuchePersonenNr.Properties.Appearance.Options.UseFont = true;
            this.edtSuchePersonenNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSuchePersonenNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSuchePersonenNr.Size = new System.Drawing.Size(100, 24);
            this.edtSuchePersonenNr.TabIndex = 2;
            // 
            // lblSucheName
            // 
            this.lblSucheName.Location = new System.Drawing.Point(31, 70);
            this.lblSucheName.Name = "lblSucheName";
            this.lblSucheName.Size = new System.Drawing.Size(86, 24);
            this.lblSucheName.TabIndex = 3;
            this.lblSucheName.Text = "Name";
            // 
            // edtSucheVorname
            // 
            this.edtSucheVorname.Location = new System.Drawing.Point(123, 100);
            this.edtSucheVorname.Name = "edtSucheVorname";
            this.edtSucheVorname.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheVorname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheVorname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheVorname.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheVorname.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheVorname.Properties.Appearance.Options.UseFont = true;
            this.edtSucheVorname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheVorname.Size = new System.Drawing.Size(230, 24);
            this.edtSucheVorname.TabIndex = 6;
            // 
            // lblSucheVorname
            // 
            this.lblSucheVorname.Location = new System.Drawing.Point(31, 100);
            this.lblSucheVorname.Name = "lblSucheVorname";
            this.lblSucheVorname.Size = new System.Drawing.Size(86, 24);
            this.lblSucheVorname.TabIndex = 5;
            this.lblSucheVorname.Text = "Vorname";
            // 
            // lblSucheModulID
            // 
            this.lblSucheModulID.Location = new System.Drawing.Point(385, 70);
            this.lblSucheModulID.Name = "lblSucheModulID";
            this.lblSucheModulID.Size = new System.Drawing.Size(86, 24);
            this.lblSucheModulID.TabIndex = 9;
            this.lblSucheModulID.Text = "Prozess";
            // 
            // lblSucheProzessNr
            // 
            this.lblSucheProzessNr.Location = new System.Drawing.Point(385, 40);
            this.lblSucheProzessNr.Name = "lblSucheProzessNr";
            this.lblSucheProzessNr.Size = new System.Drawing.Size(86, 24);
            this.lblSucheProzessNr.TabIndex = 7;
            this.lblSucheProzessNr.Text = "Prozess-Nr.";
            // 
            // edtSucheProzessNr
            // 
            this.edtSucheProzessNr.Location = new System.Drawing.Point(477, 40);
            this.edtSucheProzessNr.Name = "edtSucheProzessNr";
            this.edtSucheProzessNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheProzessNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheProzessNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheProzessNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheProzessNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheProzessNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheProzessNr.Properties.Appearance.Options.UseFont = true;
            this.edtSucheProzessNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheProzessNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheProzessNr.Size = new System.Drawing.Size(100, 24);
            this.edtSucheProzessNr.TabIndex = 8;
            // 
            // edtSucheModulID
            // 
            this.edtSucheModulID.Location = new System.Drawing.Point(477, 70);
            this.edtSucheModulID.LOVFilter = "ModulID IN (2, 3, 4, 5, 6, 7, 8) -- only AKV modules";
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
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtSucheModulID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtSucheModulID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheModulID.Properties.NullText = "";
            this.edtSucheModulID.Properties.ShowFooter = false;
            this.edtSucheModulID.Properties.ShowHeader = false;
            this.edtSucheModulID.Size = new System.Drawing.Size(230, 24);
            this.edtSucheModulID.TabIndex = 10;
            // 
            // grdBaPerson
            // 
            this.grdBaPerson.DataSource = this.qryBaPerson;
            this.grdBaPerson.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdBaPerson.EmbeddedNavigator.Name = "";
            this.grdBaPerson.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBaPerson.Location = new System.Drawing.Point(0, 0);
            this.grdBaPerson.MainView = this.grvBaPerson;
            this.grdBaPerson.Name = "grdBaPerson";
            this.grdBaPerson.Size = new System.Drawing.Size(808, 132);
            this.grdBaPerson.TabIndex = 0;
            this.grdBaPerson.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBaPerson});
            // 
            // grvBaPerson
            // 
            this.grvBaPerson.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBaPerson.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaPerson.Appearance.Empty.Options.UseBackColor = true;
            this.grvBaPerson.Appearance.Empty.Options.UseFont = true;
            this.grvBaPerson.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaPerson.Appearance.EvenRow.Options.UseFont = true;
            this.grvBaPerson.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBaPerson.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaPerson.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBaPerson.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBaPerson.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBaPerson.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBaPerson.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBaPerson.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaPerson.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBaPerson.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBaPerson.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBaPerson.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBaPerson.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaPerson.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBaPerson.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaPerson.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBaPerson.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBaPerson.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBaPerson.Appearance.GroupRow.Options.UseFont = true;
            this.grvBaPerson.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBaPerson.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBaPerson.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBaPerson.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBaPerson.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBaPerson.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBaPerson.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBaPerson.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBaPerson.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaPerson.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBaPerson.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBaPerson.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBaPerson.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBaPerson.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBaPerson.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBaPerson.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaPerson.Appearance.OddRow.Options.UseFont = true;
            this.grvBaPerson.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBaPerson.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaPerson.Appearance.Row.Options.UseBackColor = true;
            this.grvBaPerson.Appearance.Row.Options.UseFont = true;
            this.grvBaPerson.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaPerson.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBaPerson.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBaPerson.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBaPerson.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBaPerson.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBaPersonID,
            this.colName,
            this.colVorname,
            this.colGeburtsdatum,
            this.colAlter,
            this.colGeschlecht,
            this.colVersNr,
            this.colStrasse,
            this.colOrt,
            this.colVerantwortlicherFV});
            this.grvBaPerson.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBaPerson.GridControl = this.grdBaPerson;
            this.grvBaPerson.Name = "grvBaPerson";
            this.grvBaPerson.OptionsBehavior.Editable = false;
            this.grvBaPerson.OptionsCustomization.AllowFilter = false;
            this.grvBaPerson.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBaPerson.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBaPerson.OptionsNavigation.UseTabKey = false;
            this.grvBaPerson.OptionsView.ColumnAutoWidth = false;
            this.grvBaPerson.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBaPerson.OptionsView.ShowGroupPanel = false;
            this.grvBaPerson.OptionsView.ShowIndicator = false;
            // 
            // colBaPersonID
            // 
            this.colBaPersonID.Caption = "Nr.";
            this.colBaPersonID.FieldName = "BaPersonID";
            this.colBaPersonID.Name = "colBaPersonID";
            this.colBaPersonID.Visible = true;
            this.colBaPersonID.VisibleIndex = 0;
            this.colBaPersonID.Width = 63;
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 100;
            // 
            // colVorname
            // 
            this.colVorname.Caption = "Vorname";
            this.colVorname.FieldName = "Vorname";
            this.colVorname.Name = "colVorname";
            this.colVorname.Visible = true;
            this.colVorname.VisibleIndex = 2;
            this.colVorname.Width = 100;
            // 
            // colGeburtsdatum
            // 
            this.colGeburtsdatum.Caption = "Geb.Dat.";
            this.colGeburtsdatum.FieldName = "Geburtsdatum";
            this.colGeburtsdatum.Name = "colGeburtsdatum";
            this.colGeburtsdatum.Visible = true;
            this.colGeburtsdatum.VisibleIndex = 7;
            this.colGeburtsdatum.Width = 80;
            // 
            // colAlter
            // 
            this.colAlter.Caption = "Alter";
            this.colAlter.FieldName = "Alter";
            this.colAlter.Name = "colAlter";
            this.colAlter.Visible = true;
            this.colAlter.VisibleIndex = 6;
            this.colAlter.Width = 38;
            // 
            // colGeschlecht
            // 
            this.colGeschlecht.Caption = "Geschlecht";
            this.colGeschlecht.FieldName = "Geschlecht";
            this.colGeschlecht.Name = "colGeschlecht";
            this.colGeschlecht.Visible = true;
            this.colGeschlecht.VisibleIndex = 5;
            // 
            // colVersNr
            // 
            this.colVersNr.Caption = "Vers.-Nr.";
            this.colVersNr.FieldName = "VersichertenNummer";
            this.colVersNr.Name = "colVersNr";
            this.colVersNr.Visible = true;
            this.colVersNr.VisibleIndex = 8;
            this.colVersNr.Width = 90;
            // 
            // colStrasse
            // 
            this.colStrasse.Caption = "Strasse";
            this.colStrasse.FieldName = "Strasse";
            this.colStrasse.Name = "colStrasse";
            this.colStrasse.Visible = true;
            this.colStrasse.VisibleIndex = 3;
            this.colStrasse.Width = 100;
            // 
            // colOrt
            // 
            this.colOrt.Caption = "Ort";
            this.colOrt.FieldName = "PLZOrt";
            this.colOrt.Name = "colOrt";
            this.colOrt.Visible = true;
            this.colOrt.VisibleIndex = 4;
            this.colOrt.Width = 100;
            // 
            // colVerantwortlicherFV
            // 
            this.colVerantwortlicherFV.Caption = "Verantwortliche/r FV";
            this.colVerantwortlicherFV.FieldName = "VerantwortlicherFV";
            this.colVerantwortlicherFV.Name = "colVerantwortlicherFV";
            this.colVerantwortlicherFV.Visible = true;
            this.colVerantwortlicherFV.VisibleIndex = 9;
            this.colVerantwortlicherFV.Width = 150;
            // 
            // panGotoFall
            // 
            this.panGotoFall.Controls.Add(this.lblCount);
            this.panGotoFall.Controls.Add(this.ctlGotoFall);
            this.panGotoFall.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panGotoFall.Location = new System.Drawing.Point(0, 132);
            this.panGotoFall.Name = "panGotoFall";
            this.panGotoFall.Size = new System.Drawing.Size(808, 30);
            this.panGotoFall.TabIndex = 1;
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblCount.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblCount.Location = new System.Drawing.Point(570, 3);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(228, 24);
            this.lblCount.TabIndex = 1;
            this.lblCount.Text = "Anzahl Datensätze: {0}";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = "BaPersonID";
            this.ctlGotoFall.DataSource = this.qryBaPerson;
            this.ctlGotoFall.Location = new System.Drawing.Point(3, 3);
            this.ctlGotoFall.Name = "ctlGotoFall";
            this.ctlGotoFall.Size = new System.Drawing.Size(208, 24);
            this.ctlGotoFall.TabIndex = 0;
            // 
            // lblAbwesenheitswochenLoeschen
            // 
            this.lblAbwesenheitswochenLoeschen.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblAbwesenheitswochenLoeschen.Location = new System.Drawing.Point(11, 10);
            this.lblAbwesenheitswochenLoeschen.Name = "lblAbwesenheitswochenLoeschen";
            this.lblAbwesenheitswochenLoeschen.Size = new System.Drawing.Size(797, 23);
            this.lblAbwesenheitswochenLoeschen.TabIndex = 3;
            this.lblAbwesenheitswochenLoeschen.Text = "Abwesenheitswochen löschen";
            this.lblAbwesenheitswochenLoeschen.UseCompatibleTextRendering = true;
            // 
            // panAbwesenheitswochenLoeschen
            // 
            this.panAbwesenheitswochenLoeschen.Controls.Add(this.btnAbwesenheitswochenLoeschen);
            this.panAbwesenheitswochenLoeschen.Controls.Add(this.lblAbwesenheitswochenLoeschen);
            this.panAbwesenheitswochenLoeschen.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panAbwesenheitswochenLoeschen.Location = new System.Drawing.Point(0, 580);
            this.panAbwesenheitswochenLoeschen.Name = "panAbwesenheitswochenLoeschen";
            this.panAbwesenheitswochenLoeschen.Size = new System.Drawing.Size(820, 80);
            this.panAbwesenheitswochenLoeschen.TabIndex = 4;
            this.panAbwesenheitswochenLoeschen.Visible = false;
            // 
            // btnAbwesenheitswochenLoeschen
            // 
            this.btnAbwesenheitswochenLoeschen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbwesenheitswochenLoeschen.IconID = 4;
            this.btnAbwesenheitswochenLoeschen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAbwesenheitswochenLoeschen.Location = new System.Drawing.Point(11, 36);
            this.btnAbwesenheitswochenLoeschen.Name = "btnAbwesenheitswochenLoeschen";
            this.btnAbwesenheitswochenLoeschen.Size = new System.Drawing.Size(223, 24);
            this.btnAbwesenheitswochenLoeschen.TabIndex = 11;
            this.btnAbwesenheitswochenLoeschen.Text = "Abwesenheitswochen löschen";
            this.btnAbwesenheitswochenLoeschen.UseVisualStyleBackColor = false;
            this.btnAbwesenheitswochenLoeschen.Click += new System.EventHandler(this.btnAbwesenheitswochenLoeschen_Click);
            // 
            // CtlAdProzessBearbeiten
            // 
            this.ActiveSQLQuery = this.qryBaPerson;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panAbwesenheitswochenLoeschen);
            this.Controls.Add(this.ctlFallInfo);
            this.Controls.Add(this.splitter);
            this.Name = "CtlAdProzessBearbeiten";
            this.Size = new System.Drawing.Size(820, 660);
            this.Load += new System.EventHandler(this.CtlAdProzessBearbeiten_Load);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.splitter, 0);
            this.Controls.SetChildIndex(this.ctlFallInfo, 0);
            this.Controls.SetChildIndex(this.panAbwesenheitswochenLoeschen, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchePersonenNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchePersonenNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVorname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheModulID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheProzessNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheProzessNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheModulID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheModulID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaPerson)).EndInit();
            this.panGotoFall.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbwesenheitswochenLoeschen)).EndInit();
            this.panAbwesenheitswochenLoeschen.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.DB.SqlQuery qryBaPerson;
        private KiSS4.Gui.KissSplitterCollapsible splitter;
        private KiSS4.Common.PI.CtlFallInfo ctlFallInfo;
        private KiSS4.Gui.KissLabel lblSuchePersonenNr;
        private KiSS4.Gui.KissTextEdit edtSucheName;
        private KiSS4.Gui.KissCalcEdit edtSuchePersonenNr;
        private KiSS4.Gui.KissLabel lblSucheName;
        private KiSS4.Gui.KissLabel lblSucheVorname;
        private KiSS4.Gui.KissTextEdit edtSucheVorname;
        private KiSS4.Gui.KissCalcEdit edtSucheProzessNr;
        private KiSS4.Gui.KissLabel lblSucheProzessNr;
        private KiSS4.Gui.KissLabel lblSucheModulID;
        private KiSS4.Gui.KissLookUpEdit edtSucheModulID;
        private KiSS4.Gui.KissGrid grdBaPerson;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBaPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colBaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colAlter;
        private DevExpress.XtraGrid.Columns.GridColumn colGeschlecht;
        private DevExpress.XtraGrid.Columns.GridColumn colVersNr;
        private DevExpress.XtraGrid.Columns.GridColumn colStrasse;
        private DevExpress.XtraGrid.Columns.GridColumn colOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colVerantwortlicherFV;
        private System.Windows.Forms.Panel panGotoFall;
        private KiSS4.Common.CtlGotoFall ctlGotoFall;
        private KiSS4.Gui.KissLabel lblCount;
        private System.Windows.Forms.Panel panAbwesenheitswochenLoeschen;
        private Gui.KissLabel lblAbwesenheitswochenLoeschen;
        private Gui.KissButton btnAbwesenheitswochenLoeschen;
    }
}
