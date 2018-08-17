namespace KiSS4.Vormundschaft.ZH
{
    public partial class CtlKgDokumentenPool
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKgDokumentenPool));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblSucheDatumVon = new KiSS4.Gui.KissLabel();
            this.edtSucheDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtNichzuordbareDokumente = new KiSS4.Gui.KissCheckEdit();
            this.lblSucheDatumBis = new KiSS4.Gui.KissLabel();
            this.kissDateEdit1 = new KiSS4.Gui.KissDateEdit();
            this.edtSucheKontoNr = new KiSS4.Gui.KissLookUpEdit();
            this.edtSucheDokumentenTyp = new KiSS4.Gui.KissLabel();
            this.grdZKBDokumente = new KiSS4.Gui.KissGrid();
            this.qryZKBDokumente = new KiSS4.DB.SqlQuery(this.components);
            this.grvQuery1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colStichtag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKontoNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZKBDokumentTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZKBPartnerNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZKBFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBelegNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMandant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblZKBDokumente = new KiSS4.Gui.KissLabel();
            this.btnZuordnen = new KiSS4.Gui.KissButton();
            this.lblMandant = new KiSS4.Gui.KissLabel();
            this.edtMandant = new KiSS4.Gui.KissButtonEdit();
            this.lblStichwort = new KiSS4.Gui.KissLabel();
            this.edtStichworte = new KiSS4.Gui.KissTextEdit();
            this.edtBaPersonID = new KiSS4.Gui.KissTextEdit();
            this.btnSelektionEntfernen = new KiSS4.Gui.KissButton();
            this.btnDokOeffnen = new KiSS4.Gui.KissButton();
            this.edtDokumentHidden = new KiSS4.Dokument.XDokument();
            this.lblBaZahlungsweg = new KiSS4.Gui.KissLabel();
            this.edtKgKonto = new KiSS4.Gui.KissLookUpEdit();
            this.edtNurNichtZugeordneteDoks = new KiSS4.Gui.KissCheckEdit();
            this.ctlGotoFall = new KiSS4.Common.CtlGotoFall();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.edtFilter = new KiSS4.Gui.KissTextEdit();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.btnAutomatischeZuordnungStarten = new KiSS4.Gui.KissButton();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNichzuordbareDokumente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissDateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKontoNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKontoNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDokumentenTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZKBDokumente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZKBDokumente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZKBDokumente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMandant.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichwort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichworte.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentHidden.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaZahlungsweg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKgKonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKgKonto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurNichtZugeordneteDoks.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSucheDatumVon
            // 
            this.lblSucheDatumVon.Location = new System.Drawing.Point(4, 39);
            this.lblSucheDatumVon.Name = "lblSucheDatumVon";
            this.lblSucheDatumVon.Size = new System.Drawing.Size(68, 24);
            this.lblSucheDatumVon.TabIndex = 340;
            this.lblSucheDatumVon.Text = "Datum von";
            this.lblSucheDatumVon.UseCompatibleTextRendering = true;
            // 
            // edtSucheDatumBis
            // 
            this.edtSucheDatumBis.EditValue = null;
            this.edtSucheDatumBis.Location = new System.Drawing.Point(93, 38);
            this.edtSucheDatumBis.Name = "edtSucheDatumBis";
            this.edtSucheDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtSucheDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtSucheDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheDatumBis.Properties.ShowToday = false;
            this.edtSucheDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtSucheDatumBis.TabIndex = 339;
            // 
            // edtNichzuordbareDokumente
            // 
            this.edtNichzuordbareDokumente.EditValue = true;
            this.edtNichzuordbareDokumente.Location = new System.Drawing.Point(4, 100);
            this.edtNichzuordbareDokumente.Name = "edtNichzuordbareDokumente";
            this.edtNichzuordbareDokumente.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtNichzuordbareDokumente.Properties.Appearance.Options.UseBackColor = true;
            this.edtNichzuordbareDokumente.Properties.Caption = "Nur nicht zugeordnete Dokumente";
            this.edtNichzuordbareDokumente.Size = new System.Drawing.Size(201, 19);
            this.edtNichzuordbareDokumente.TabIndex = 341;
            // 
            // lblSucheDatumBis
            // 
            this.lblSucheDatumBis.Location = new System.Drawing.Point(209, 39);
            this.lblSucheDatumBis.Name = "lblSucheDatumBis";
            this.lblSucheDatumBis.Size = new System.Drawing.Size(23, 24);
            this.lblSucheDatumBis.TabIndex = 343;
            this.lblSucheDatumBis.Text = "bis";
            this.lblSucheDatumBis.UseCompatibleTextRendering = true;
            // 
            // kissDateEdit1
            // 
            this.kissDateEdit1.EditValue = null;
            this.kissDateEdit1.Location = new System.Drawing.Point(238, 38);
            this.kissDateEdit1.Name = "kissDateEdit1";
            this.kissDateEdit1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.kissDateEdit1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.kissDateEdit1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissDateEdit1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissDateEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.kissDateEdit1.Properties.Appearance.Options.UseBorderColor = true;
            this.kissDateEdit1.Properties.Appearance.Options.UseFont = true;
            this.kissDateEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.kissDateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("kissDateEdit1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.kissDateEdit1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.kissDateEdit1.Properties.ShowToday = false;
            this.kissDateEdit1.Size = new System.Drawing.Size(100, 24);
            this.kissDateEdit1.TabIndex = 342;
            // 
            // edtSucheKontoNr
            // 
            this.edtSucheKontoNr.Location = new System.Drawing.Point(93, 70);
            this.edtSucheKontoNr.Name = "edtSucheKontoNr";
            this.edtSucheKontoNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheKontoNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheKontoNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheKontoNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheKontoNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheKontoNr.Properties.Appearance.Options.UseFont = true;
            this.edtSucheKontoNr.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheKontoNr.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheKontoNr.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheKontoNr.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheKontoNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtSucheKontoNr.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtSucheKontoNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheKontoNr.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.edtSucheKontoNr.Properties.DisplayMember = "Text";
            this.edtSucheKontoNr.Properties.NullText = "";
            this.edtSucheKontoNr.Properties.ShowFooter = false;
            this.edtSucheKontoNr.Properties.ShowHeader = false;
            this.edtSucheKontoNr.Properties.ValueMember = "Code";
            this.edtSucheKontoNr.Size = new System.Drawing.Size(245, 24);
            this.edtSucheKontoNr.TabIndex = 345;
            // 
            // edtSucheDokumentenTyp
            // 
            this.edtSucheDokumentenTyp.Location = new System.Drawing.Point(4, 70);
            this.edtSucheDokumentenTyp.Name = "edtSucheDokumentenTyp";
            this.edtSucheDokumentenTyp.Size = new System.Drawing.Size(83, 24);
            this.edtSucheDokumentenTyp.TabIndex = 344;
            this.edtSucheDokumentenTyp.Text = "Dokumententyp";
            this.edtSucheDokumentenTyp.UseCompatibleTextRendering = true;
            // 
            // grdZKBDokumente
            // 
            this.grdZKBDokumente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdZKBDokumente.ColumnFilterActivated = true;
            this.grdZKBDokumente.DataSource = this.qryZKBDokumente;
            // 
            // 
            // 
            this.grdZKBDokumente.EmbeddedNavigator.Name = "";
            this.grdZKBDokumente.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdZKBDokumente.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdZKBDokumente.Location = new System.Drawing.Point(3, 37);
            this.grdZKBDokumente.MainView = this.grvQuery1;
            this.grdZKBDokumente.Name = "grdZKBDokumente";
            this.grdZKBDokumente.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.grdZKBDokumente.Size = new System.Drawing.Size(804, 308);
            this.grdZKBDokumente.TabIndex = 1;
            this.grdZKBDokumente.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvQuery1});
            this.grdZKBDokumente.DoubleClick += new System.EventHandler(this.grdZKBDokumente_DoubleClick);
            // 
            // qryZKBDokumente
            // 
            this.qryZKBDokumente.BatchUpdate = true;
            this.qryZKBDokumente.CanUpdate = true;
            this.qryZKBDokumente.FillTimeOut = 300;
            this.qryZKBDokumente.HostControl = this;
            this.qryZKBDokumente.SelectStatement = resources.GetString("qryZKBDokumente.SelectStatement");
            this.qryZKBDokumente.PositionChanged += new System.EventHandler(this.qryZKBDokumente_PositionChanged);
            // 
            // grvQuery1
            // 
            this.grvQuery1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvQuery1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.Empty.Options.UseBackColor = true;
            this.grvQuery1.Appearance.Empty.Options.UseFont = true;
            this.grvQuery1.Appearance.EvenRow.BackColor = System.Drawing.Color.AliceBlue;
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
            this.grvQuery1.BestFitMaxRowCount = 50;
            this.grvQuery1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvQuery1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSel,
            this.colStichtag,
            this.colKontoNr,
            this.colZKBDokumentTyp,
            this.colZKBPartnerNr,
            this.colZKBFileName,
            this.colBelegNr,
            this.colMandant});
            this.grvQuery1.GridControl = this.grdZKBDokumente;
            this.grvQuery1.GroupCount = 1;
            this.grvQuery1.Name = "grvQuery1";
            this.grvQuery1.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvQuery1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvQuery1.OptionsNavigation.AutoFocusNewRow = true;
            this.grvQuery1.OptionsPrint.AutoWidth = false;
            this.grvQuery1.OptionsPrint.ExpandAllDetails = true;
            this.grvQuery1.OptionsPrint.UsePrintStyles = true;
            this.grvQuery1.OptionsView.ColumnAutoWidth = false;
            this.grvQuery1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvQuery1.OptionsView.ShowGroupPanel = false;
            this.grvQuery1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colZKBDokumentTyp, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colSel
            // 
            this.colSel.Caption = "Sel";
            this.colSel.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colSel.FieldName = "Sel";
            this.colSel.Name = "colSel";
            this.colSel.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.colSel.Visible = true;
            this.colSel.VisibleIndex = 0;
            this.colSel.Width = 39;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // colStichtag
            // 
            this.colStichtag.Caption = "Stichtag";
            this.colStichtag.FieldName = "Stichtag";
            this.colStichtag.Name = "colStichtag";
            this.colStichtag.OptionsColumn.AllowEdit = false;
            this.colStichtag.Visible = true;
            this.colStichtag.VisibleIndex = 1;
            this.colStichtag.Width = 82;
            // 
            // colKontoNr
            // 
            this.colKontoNr.Caption = "ZKB Konto-Nr.";
            this.colKontoNr.FieldName = "ZKBGeschaeftNr";
            this.colKontoNr.Name = "colKontoNr";
            this.colKontoNr.OptionsColumn.AllowEdit = false;
            this.colKontoNr.Visible = true;
            this.colKontoNr.VisibleIndex = 2;
            this.colKontoNr.Width = 164;
            // 
            // colZKBDokumentTyp
            // 
            this.colZKBDokumentTyp.Caption = "ZKB Dokument Typ";
            this.colZKBDokumentTyp.FieldName = "ZKBDokumentTyp";
            this.colZKBDokumentTyp.Name = "colZKBDokumentTyp";
            this.colZKBDokumentTyp.OptionsColumn.AllowEdit = false;
            this.colZKBDokumentTyp.Width = 121;
            // 
            // colZKBPartnerNr
            // 
            this.colZKBPartnerNr.Caption = "ZKB Partner-Nr.";
            this.colZKBPartnerNr.FieldName = "ZKBPartnerNr";
            this.colZKBPartnerNr.Name = "colZKBPartnerNr";
            this.colZKBPartnerNr.OptionsColumn.AllowEdit = false;
            this.colZKBPartnerNr.Visible = true;
            this.colZKBPartnerNr.VisibleIndex = 3;
            this.colZKBPartnerNr.Width = 113;
            // 
            // colZKBFileName
            // 
            this.colZKBFileName.Caption = "ZKB Dateiname";
            this.colZKBFileName.FieldName = "ZKBFileName";
            this.colZKBFileName.Name = "colZKBFileName";
            this.colZKBFileName.OptionsColumn.AllowEdit = false;
            this.colZKBFileName.Width = 117;
            // 
            // colBelegNr
            // 
            this.colBelegNr.Caption = "Beleg-Nr.";
            this.colBelegNr.FieldName = "BelegNr";
            this.colBelegNr.Name = "colBelegNr";
            this.colBelegNr.OptionsColumn.AllowEdit = false;
            this.colBelegNr.OptionsColumn.ReadOnly = true;
            this.colBelegNr.Visible = true;
            this.colBelegNr.VisibleIndex = 5;
            this.colBelegNr.Width = 85;
            // 
            // colMandant
            // 
            this.colMandant.Caption = "Person mit zivilr. Massnahme";
            this.colMandant.FieldName = "Mandant";
            this.colMandant.Name = "colMandant";
            this.colMandant.OptionsColumn.AllowEdit = false;
            this.colMandant.Visible = true;
            this.colMandant.VisibleIndex = 4;
            this.colMandant.Width = 228;
            // 
            // lblZKBDokumente
            // 
            this.lblZKBDokumente.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblZKBDokumente.Location = new System.Drawing.Point(3, 12);
            this.lblZKBDokumente.Name = "lblZKBDokumente";
            this.lblZKBDokumente.Size = new System.Drawing.Size(374, 22);
            this.lblZKBDokumente.TabIndex = 345;
            this.lblZKBDokumente.Text = "Noch nicht zugeordnete ZKB-Dokumente";
            this.lblZKBDokumente.UseCompatibleTextRendering = true;
            // 
            // btnZuordnen
            // 
            this.btnZuordnen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZuordnen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZuordnen.Location = new System.Drawing.Point(672, 443);
            this.btnZuordnen.Name = "btnZuordnen";
            this.btnZuordnen.Size = new System.Drawing.Size(135, 24);
            this.btnZuordnen.TabIndex = 346;
            this.btnZuordnen.Text = "Dokumente zuordnen";
            this.btnZuordnen.UseCompatibleTextRendering = true;
            this.btnZuordnen.UseVisualStyleBackColor = false;
            this.btnZuordnen.Click += new System.EventHandler(this.btnZuordnen_Click);
            // 
            // lblMandant
            // 
            this.lblMandant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMandant.Location = new System.Drawing.Point(3, 383);
            this.lblMandant.Name = "lblMandant";
            this.lblMandant.Size = new System.Drawing.Size(156, 24);
            this.lblMandant.TabIndex = 348;
            this.lblMandant.Text = "Person mit zivilr. Massnahme";
            this.lblMandant.UseCompatibleTextRendering = true;
            // 
            // edtMandant
            // 
            this.edtMandant.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtMandant.Location = new System.Drawing.Point(165, 383);
            this.edtMandant.Name = "edtMandant";
            this.edtMandant.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMandant.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMandant.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMandant.Properties.Appearance.Options.UseBackColor = true;
            this.edtMandant.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMandant.Properties.Appearance.Options.UseFont = true;
            this.edtMandant.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtMandant.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtMandant.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtMandant.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtMandant.Size = new System.Drawing.Size(395, 24);
            this.edtMandant.TabIndex = 347;
            this.edtMandant.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtMandant_UserModifiedFld);
            // 
            // lblStichwort
            // 
            this.lblStichwort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStichwort.Location = new System.Drawing.Point(3, 443);
            this.lblStichwort.Name = "lblStichwort";
            this.lblStichwort.Size = new System.Drawing.Size(156, 24);
            this.lblStichwort.TabIndex = 350;
            this.lblStichwort.Text = "Stichworte";
            this.lblStichwort.UseCompatibleTextRendering = true;
            // 
            // edtStichworte
            // 
            this.edtStichworte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtStichworte.Location = new System.Drawing.Point(165, 443);
            this.edtStichworte.Name = "edtStichworte";
            this.edtStichworte.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStichworte.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStichworte.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStichworte.Properties.Appearance.Options.UseBackColor = true;
            this.edtStichworte.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStichworte.Properties.Appearance.Options.UseFont = true;
            this.edtStichworte.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStichworte.Size = new System.Drawing.Size(502, 24);
            this.edtStichworte.TabIndex = 349;
            // 
            // edtBaPersonID
            // 
            this.edtBaPersonID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBaPersonID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBaPersonID.Location = new System.Drawing.Point(566, 383);
            this.edtBaPersonID.Name = "edtBaPersonID";
            this.edtBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBaPersonID.Properties.Name = "editMandantNr.Properties";
            this.edtBaPersonID.Properties.ReadOnly = true;
            this.edtBaPersonID.Size = new System.Drawing.Size(101, 24);
            this.edtBaPersonID.TabIndex = 352;
            // 
            // btnSelektionEntfernen
            // 
            this.btnSelektionEntfernen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelektionEntfernen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelektionEntfernen.Location = new System.Drawing.Point(296, 351);
            this.btnSelektionEntfernen.Name = "btnSelektionEntfernen";
            this.btnSelektionEntfernen.Size = new System.Drawing.Size(121, 24);
            this.btnSelektionEntfernen.TabIndex = 353;
            this.btnSelektionEntfernen.Text = "Selektion entfernen";
            this.btnSelektionEntfernen.UseCompatibleTextRendering = true;
            this.btnSelektionEntfernen.UseVisualStyleBackColor = false;
            this.btnSelektionEntfernen.Click += new System.EventHandler(this.btnSelektionEntfernen_Click);
            // 
            // btnDokOeffnen
            // 
            this.btnDokOeffnen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDokOeffnen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDokOeffnen.Location = new System.Drawing.Point(3, 351);
            this.btnDokOeffnen.Name = "btnDokOeffnen";
            this.btnDokOeffnen.Size = new System.Drawing.Size(121, 24);
            this.btnDokOeffnen.TabIndex = 354;
            this.btnDokOeffnen.Text = "Dokument öffnen";
            this.btnDokOeffnen.UseCompatibleTextRendering = true;
            this.btnDokOeffnen.UseVisualStyleBackColor = false;
            this.btnDokOeffnen.Click += new System.EventHandler(this.btnDokOeffnen_Click);
            // 
            // edtDokumentHidden
            // 
            this.edtDokumentHidden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDokumentHidden.CanCreateDocument = false;
            this.edtDokumentHidden.CanDeleteDocument = false;
            this.edtDokumentHidden.CanImportDocument = false;
            this.edtDokumentHidden.Context = null;
            this.edtDokumentHidden.DataMember = null;
            this.edtDokumentHidden.EditValue = "";
            this.edtDokumentHidden.Location = new System.Drawing.Point(651, 351);
            this.edtDokumentHidden.Name = "edtDokumentHidden";
            this.edtDokumentHidden.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDokumentHidden.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDokumentHidden.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDokumentHidden.Properties.Appearance.Options.UseBackColor = true;
            this.edtDokumentHidden.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDokumentHidden.Properties.Appearance.Options.UseFont = true;
            this.edtDokumentHidden.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtDokumentHidden.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDokumentHidden.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDokumentHidden.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDokumentHidden.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDokumentHidden.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7, "Dokument importieren")});
            this.edtDokumentHidden.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDokumentHidden.Properties.ReadOnly = true;
            this.edtDokumentHidden.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtDokumentHidden.Size = new System.Drawing.Size(156, 24);
            this.edtDokumentHidden.TabIndex = 355;
            this.edtDokumentHidden.Visible = false;
            // 
            // lblBaZahlungsweg
            // 
            this.lblBaZahlungsweg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBaZahlungsweg.Location = new System.Drawing.Point(3, 413);
            this.lblBaZahlungsweg.Name = "lblBaZahlungsweg";
            this.lblBaZahlungsweg.Size = new System.Drawing.Size(156, 24);
            this.lblBaZahlungsweg.TabIndex = 357;
            this.lblBaZahlungsweg.Text = "Konto Zahlverkehr";
            this.lblBaZahlungsweg.UseCompatibleTextRendering = true;
            // 
            // edtKgKonto
            // 
            this.edtKgKonto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKgKonto.Location = new System.Drawing.Point(165, 413);
            this.edtKgKonto.Name = "edtKgKonto";
            this.edtKgKonto.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKgKonto.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKgKonto.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKgKonto.Properties.Appearance.Options.UseBackColor = true;
            this.edtKgKonto.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKgKonto.Properties.Appearance.Options.UseFont = true;
            this.edtKgKonto.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtKgKonto.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKgKonto.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtKgKonto.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtKgKonto.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtKgKonto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtKgKonto.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKgKonto.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.edtKgKonto.Properties.DisplayMember = "Text";
            this.edtKgKonto.Properties.NullText = "";
            this.edtKgKonto.Properties.ShowFooter = false;
            this.edtKgKonto.Properties.ShowHeader = false;
            this.edtKgKonto.Properties.ValueMember = "Code";
            this.edtKgKonto.Size = new System.Drawing.Size(502, 24);
            this.edtKgKonto.TabIndex = 356;
            // 
            // edtNurNichtZugeordneteDoks
            // 
            this.edtNurNichtZugeordneteDoks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtNurNichtZugeordneteDoks.EditValue = true;
            this.edtNurNichtZugeordneteDoks.Location = new System.Drawing.Point(424, 355);
            this.edtNurNichtZugeordneteDoks.Name = "edtNurNichtZugeordneteDoks";
            this.edtNurNichtZugeordneteDoks.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtNurNichtZugeordneteDoks.Properties.Appearance.Options.UseBackColor = true;
            this.edtNurNichtZugeordneteDoks.Properties.Caption = "Zeige nur nicht zugeordnete Dokumente";
            this.edtNurNichtZugeordneteDoks.Size = new System.Drawing.Size(228, 19);
            this.edtNurNichtZugeordneteDoks.TabIndex = 359;
            this.edtNurNichtZugeordneteDoks.Visible = false;
            this.edtNurNichtZugeordneteDoks.CheckedChanged += new System.EventHandler(this.edtNurNichtZugeordneteDoks_CheckedChanged);
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlGotoFall.DisplayModules = null;
            this.ctlGotoFall.Location = new System.Drawing.Point(672, 383);
            this.ctlGotoFall.Name = "ctlGotoFall";
            this.ctlGotoFall.Size = new System.Drawing.Size(135, 24);
            this.ctlGotoFall.TabIndex = 581;
            // 
            // kissLabel1
            // 
            this.kissLabel1.Location = new System.Drawing.Point(383, 8);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(35, 24);
            this.kissLabel1.TabIndex = 583;
            this.kissLabel1.Text = "Filter";
            this.kissLabel1.UseCompatibleTextRendering = true;
            // 
            // edtFilter
            // 
            this.edtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtFilter.Location = new System.Drawing.Point(424, 8);
            this.edtFilter.Name = "edtFilter";
            this.edtFilter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFilter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFilter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFilter.Properties.Appearance.Options.UseBackColor = true;
            this.edtFilter.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFilter.Properties.Appearance.Options.UseFont = true;
            this.edtFilter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFilter.Size = new System.Drawing.Size(243, 24);
            this.edtFilter.TabIndex = 582;
            this.edtFilter.EditValueChanged += new System.EventHandler(this.edtFilter_EditValueChanged);
            // 
            // kissLabel2
            // 
            this.kissLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kissLabel2.Location = new System.Drawing.Point(672, 8);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(135, 24);
            this.kissLabel2.TabIndex = 585;
            this.kissLabel2.Text = "(Filter entfernt Selektion)";
            this.kissLabel2.UseCompatibleTextRendering = true;
            // 
            // btnAutomatischeZuordnungStarten
            // 
            this.btnAutomatischeZuordnungStarten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAutomatischeZuordnungStarten.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutomatischeZuordnungStarten.Location = new System.Drawing.Point(130, 351);
            this.btnAutomatischeZuordnungStarten.Name = "btnAutomatischeZuordnungStarten";
            this.btnAutomatischeZuordnungStarten.Size = new System.Drawing.Size(160, 24);
            this.btnAutomatischeZuordnungStarten.TabIndex = 586;
            this.btnAutomatischeZuordnungStarten.Text = "Autom. Zuordnung starten";
            this.btnAutomatischeZuordnungStarten.UseCompatibleTextRendering = true;
            this.btnAutomatischeZuordnungStarten.UseVisualStyleBackColor = false;
            this.btnAutomatischeZuordnungStarten.Click += new System.EventHandler(this.btnAutomatischeZuordnungStarten_Click);
            // 
            // CtlKgDokumentenPool
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.edtDokumentHidden);
            this.Controls.Add(this.btnAutomatischeZuordnungStarten);
            this.Controls.Add(this.kissLabel2);
            this.Controls.Add(this.kissLabel1);
            this.Controls.Add(this.edtFilter);
            this.Controls.Add(this.ctlGotoFall);
            this.Controls.Add(this.edtNurNichtZugeordneteDoks);
            this.Controls.Add(this.edtKgKonto);
            this.Controls.Add(this.lblBaZahlungsweg);
            this.Controls.Add(this.btnDokOeffnen);
            this.Controls.Add(this.btnSelektionEntfernen);
            this.Controls.Add(this.edtBaPersonID);
            this.Controls.Add(this.lblStichwort);
            this.Controls.Add(this.edtStichworte);
            this.Controls.Add(this.lblMandant);
            this.Controls.Add(this.edtMandant);
            this.Controls.Add(this.btnZuordnen);
            this.Controls.Add(this.lblZKBDokumente);
            this.Controls.Add(this.grdZKBDokumente);
            this.Name = "CtlKgDokumentenPool";
            this.Size = new System.Drawing.Size(810, 470);
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNichzuordbareDokumente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissDateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKontoNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKontoNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDokumentenTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZKBDokumente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZKBDokumente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZKBDokumente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMandant.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichwort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichworte.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentHidden.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaZahlungsweg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKgKonto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKgKonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurNichtZugeordneteDoks.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gui.KissLabel lblSucheDatumVon;
        private Gui.KissDateEdit edtSucheDatumBis;
        private Gui.KissCheckEdit edtNichzuordbareDokumente;
        private Gui.KissLabel lblSucheDatumBis;
        private Gui.KissDateEdit kissDateEdit1;
        private Gui.KissLookUpEdit edtSucheKontoNr;
        private Gui.KissLabel edtSucheDokumentenTyp;
        protected Gui.KissGrid grdZKBDokumente;
        protected DevExpress.XtraGrid.Views.Grid.GridView grvQuery1;
        private DevExpress.XtraGrid.Columns.GridColumn colStichtag;
        private DevExpress.XtraGrid.Columns.GridColumn colKontoNr;
        private DevExpress.XtraGrid.Columns.GridColumn colZKBPartnerNr;
        protected DB.SqlQuery qryZKBDokumente;
        private DevExpress.XtraGrid.Columns.GridColumn colZKBFileName;
        private DevExpress.XtraGrid.Columns.GridColumn colZKBDokumentTyp;
        private Gui.KissLabel lblZKBDokumente;
        private Gui.KissButton btnZuordnen;
        private DevExpress.XtraGrid.Columns.GridColumn colMandant;
        private Gui.KissLabel lblMandant;
        private Gui.KissButtonEdit edtMandant;
        private Gui.KissLabel lblStichwort;
        private Gui.KissTextEdit edtStichworte;
        private DevExpress.XtraGrid.Columns.GridColumn colSel;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private Gui.KissTextEdit edtBaPersonID;
        private Gui.KissButton btnSelektionEntfernen;
        private Gui.KissButton btnDokOeffnen;
        private Dokument.XDokument edtDokumentHidden;
        private Gui.KissLabel lblBaZahlungsweg;
        private Gui.KissLookUpEdit edtKgKonto;
        private Gui.KissCheckEdit edtNurNichtZugeordneteDoks;
        private Common.CtlGotoFall ctlGotoFall;
        private Gui.KissLabel kissLabel1;
        private Gui.KissTextEdit edtFilter;
        private Gui.KissLabel kissLabel2;
        private Gui.KissButton btnAutomatischeZuordnungStarten;
        private DevExpress.XtraGrid.Columns.GridColumn colBelegNr;
    }
}