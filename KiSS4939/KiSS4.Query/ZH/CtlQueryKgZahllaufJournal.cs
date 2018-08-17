namespace KiSS4.Query.ZH
{
    public class CtlQueryKgZahllaufJournal : Common.KissQueryControl
    {
        #region Fields

        #region Private Fields

        private DevExpress.XtraGrid.Columns.GridColumn colAusgleichsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colAuszahlungsart;
        private DevExpress.XtraGrid.Columns.GridColumn colBelegNr;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colKreditor;
        private DevExpress.XtraGrid.Columns.GridColumn colMandant;
        private DevExpress.XtraGrid.Columns.GridColumn colTransferdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colValuta;
        private DevExpress.XtraGrid.Columns.GridColumn colZahlinfo;
        private DevExpress.XtraGrid.Columns.GridColumn colZeit;
        private Gui.KissDateEdit edtSucheBarbezugDatumBis;
        private Gui.KissDateEdit edtSucheBarbezugDatumVon;
        private KiSS4.Gui.KissDateEdit edtSucheTransferDatumBis;
        private KiSS4.Gui.KissDateEdit edtSucheTransferDatumVon;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.GroupBox grpBarauszahlung;
        private System.Windows.Forms.GroupBox grpElektronisch;
        private Gui.KissLabel lblBarbezugsdatumBis;
        private Gui.KissLabel lblBarbezugsdatumVon;
        private KiSS4.Gui.KissLabel lblTransferDatumBis;
        private KiSS4.Gui.KissLabel lblTransferDatumVon;

        #endregion

        #endregion

        #region Constructors

        public CtlQueryKgZahllaufJournal()
        {
            InitializeComponent();
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryKgZahllaufJournal));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.edtSucheTransferDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtSucheTransferDatumBis = new KiSS4.Gui.KissDateEdit();
            this.lblTransferDatumVon = new KiSS4.Gui.KissLabel();
            this.lblTransferDatumBis = new KiSS4.Gui.KissLabel();
            this.colAuszahlungsart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBelegNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKreditor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMandant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTransferdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValuta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZahlinfo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZeit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAusgleichsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grpElektronisch = new System.Windows.Forms.GroupBox();
            this.grpBarauszahlung = new System.Windows.Forms.GroupBox();
            this.lblBarbezugsdatumVon = new KiSS4.Gui.KissLabel();
            this.edtSucheBarbezugDatumVon = new KiSS4.Gui.KissDateEdit();
            this.lblBarbezugsdatumBis = new KiSS4.Gui.KissLabel();
            this.edtSucheBarbezugDatumBis = new KiSS4.Gui.KissDateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTransferDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTransferDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTransferDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTransferDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.grpElektronisch.SuspendLayout();
            this.grpBarauszahlung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblBarbezugsdatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBarbezugDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBarbezugsdatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBarbezugDatumBis.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // qryQuery
            //
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
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
            this.grvQuery1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvQuery1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvQuery1.Appearance.FocusedCell.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvQuery1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvQuery1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.FocusedRow.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseFont = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvQuery1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvQuery1.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvQuery1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvQuery1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery1.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvQuery1.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvQuery1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.OddRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.OddRow.Options.UseFont = true;
            this.grvQuery1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvQuery1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.Row.Options.UseBackColor = true;
            this.grvQuery1.Appearance.Row.Options.UseFont = true;
            this.grvQuery1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvQuery1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvQuery1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.SelectedRow.Options.UseFont = true;
            this.grvQuery1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery1.Appearance.VertLine.Options.UseBackColor = true;
            this.grvQuery1.OptionsBehavior.Editable = false;
            this.grvQuery1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvQuery1.OptionsNavigation.AutoFocusNewRow = true;
            this.grvQuery1.OptionsNavigation.UseTabKey = false;
            this.grvQuery1.OptionsPrint.AutoWidth = false;
            this.grvQuery1.OptionsPrint.ExpandAllDetails = true;
            this.grvQuery1.OptionsPrint.UsePrintStyles = true;
            this.grvQuery1.OptionsView.ColumnAutoWidth = false;
            this.grvQuery1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvQuery1.OptionsView.ShowGroupPanel = false;
            this.grvQuery1.OptionsView.ShowIndicator = false;
            //
            // grdQuery1
            //
            //
            //
            //
            this.grdQuery1.EmbeddedNavigator.Name = "";
            this.grdQuery1.MainView = this.gridView1;
            this.grdQuery1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            //
            // xDocument
            //
            this.xDocument.DataMember = null;
            this.xDocument.EditValue = null;
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
            this.xDocument.Visible = false;
            //
            // ctlGotoFall
            //
            this.ctlGotoFall.DataMember = "BaPersonID$";
            //
            // tpgListe
            //
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.grpBarauszahlung);
            this.tpgSuchen.Controls.Add(this.grpElektronisch);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.grpElektronisch, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.grpBarauszahlung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            //
            // edtSucheTransferDatumVon
            //
            this.edtSucheTransferDatumVon.EditValue = null;
            this.edtSucheTransferDatumVon.Location = new System.Drawing.Point(135, 22);
            this.edtSucheTransferDatumVon.Name = "edtSucheTransferDatumVon";
            this.edtSucheTransferDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheTransferDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheTransferDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheTransferDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheTransferDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheTransferDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheTransferDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheTransferDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtSucheTransferDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheTransferDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtSucheTransferDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheTransferDatumVon.Properties.ShowToday = false;
            this.edtSucheTransferDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtSucheTransferDatumVon.TabIndex = 0;
            //
            // edtSucheTransferDatumBis
            //
            this.edtSucheTransferDatumBis.EditValue = null;
            this.edtSucheTransferDatumBis.Location = new System.Drawing.Point(135, 52);
            this.edtSucheTransferDatumBis.Name = "edtSucheTransferDatumBis";
            this.edtSucheTransferDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheTransferDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheTransferDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheTransferDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheTransferDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheTransferDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheTransferDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheTransferDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtSucheTransferDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheTransferDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtSucheTransferDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheTransferDatumBis.Properties.ShowToday = false;
            this.edtSucheTransferDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtSucheTransferDatumBis.TabIndex = 1;
            //
            // lblTransferDatumVon
            //
            this.lblTransferDatumVon.Location = new System.Drawing.Point(6, 22);
            this.lblTransferDatumVon.Name = "lblTransferDatumVon";
            this.lblTransferDatumVon.Size = new System.Drawing.Size(123, 24);
            this.lblTransferDatumVon.TabIndex = 1;
            this.lblTransferDatumVon.Text = "Transferdatum von";
            this.lblTransferDatumVon.UseCompatibleTextRendering = true;
            //
            // lblTransferDatumBis
            //
            this.lblTransferDatumBis.Location = new System.Drawing.Point(6, 52);
            this.lblTransferDatumBis.Name = "lblTransferDatumBis";
            this.lblTransferDatumBis.Size = new System.Drawing.Size(123, 24);
            this.lblTransferDatumBis.TabIndex = 2;
            this.lblTransferDatumBis.Text = "Transferdatum bis";
            this.lblTransferDatumBis.UseCompatibleTextRendering = true;
            //
            // colAuszahlungsart
            //
            this.colAuszahlungsart.Caption = "Ausz.-Art";
            this.colAuszahlungsart.FieldName = "Auszahlungsart";
            this.colAuszahlungsart.GroupFormat.FormatString = "{0:n2}";
            this.colAuszahlungsart.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAuszahlungsart.Name = "colAuszahlungsart";
            //
            // colBelegNr
            //
            this.colBelegNr.Caption = "Beleg-Nr.";
            this.colBelegNr.FieldName = "BelegNr";
            this.colBelegNr.Name = "colBelegNr";
            this.colBelegNr.Visible = true;
            this.colBelegNr.VisibleIndex = 4;
            //
            // colBetrag
            //
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.FieldName = "Betrag";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.SummaryItem.DisplayFormat = "{0:#,0.00}";
            this.colBetrag.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 6;
            //
            // colKreditor
            //
            this.colKreditor.Caption = "Kreditor";
            this.colKreditor.FieldName = "Kreditor";
            this.colKreditor.Name = "colKreditor";
            this.colKreditor.Visible = true;
            this.colKreditor.VisibleIndex = 7;
            //
            // colMandant
            //
            this.colMandant.Caption = "Person m. zivilr. Massn.";
            this.colMandant.FieldName = "Mandant";
            this.colMandant.Name = "colMandant";
            this.colMandant.Visible = true;
            this.colMandant.VisibleIndex = 5;
            this.colMandant.Width = 162;
            //
            // colTransferdatum
            //
            this.colTransferdatum.Caption = "Transfer";
            this.colTransferdatum.FieldName = "Transferdatum";
            this.colTransferdatum.Name = "colTransferdatum";
            this.colTransferdatum.Visible = true;
            this.colTransferdatum.VisibleIndex = 0;
            //
            // colValuta
            //
            this.colValuta.Caption = "Valuta";
            this.colValuta.FieldName = "Valuta";
            this.colValuta.Name = "colValuta";
            this.colValuta.Visible = true;
            this.colValuta.VisibleIndex = 2;
            //
            // colZahlinfo
            //
            this.colZahlinfo.Caption = "Zahlinfo";
            this.colZahlinfo.FieldName = "Zahlinfo";
            this.colZahlinfo.Name = "colZahlinfo";
            this.colZahlinfo.Visible = true;
            this.colZahlinfo.VisibleIndex = 8;
            //
            // colZeit
            //
            this.colZeit.Caption = "Zeit";
            this.colZeit.FieldName = "Zeit";
            this.colZeit.Name = "colZeit";
            this.colZeit.Visible = true;
            this.colZeit.VisibleIndex = 1;
            //
            // gridView1
            //
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.Empty.Options.UseFont = true;
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView1.Appearance.EvenRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView1.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView1.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupFooter.Options.UseFont = true;
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
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.Options.UseFont = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTransferdatum,
            this.colZeit,
            this.colValuta,
            this.colAusgleichsdatum,
            this.colBelegNr,
            this.colMandant,
            this.colBetrag,
            this.colAuszahlungsart,
            this.colKreditor,
            this.colZahlinfo});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.grdQuery1;
            this.gridView1.GroupCount = 1;
            this.gridView1.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Betrag", this.colBetrag, "{0:n2}")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.UseTabKey = false;
            this.gridView1.OptionsPrint.AutoWidth = false;
            this.gridView1.OptionsPrint.ExpandAllDetails = true;
            this.gridView1.OptionsPrint.UsePrintStyles = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colAuszahlungsart, DevExpress.Data.ColumnSortOrder.Ascending)});
            //
            // colAusgleichsdatum
            //
            this.colAusgleichsdatum.Caption = "Ausgleich";
            this.colAusgleichsdatum.FieldName = "Ausgleichsdatum";
            this.colAusgleichsdatum.Name = "colAusgleichsdatum";
            this.colAusgleichsdatum.Visible = true;
            this.colAusgleichsdatum.VisibleIndex = 3;
            //
            // grpElektronisch
            //
            this.grpElektronisch.Controls.Add(this.lblTransferDatumVon);
            this.grpElektronisch.Controls.Add(this.edtSucheTransferDatumVon);
            this.grpElektronisch.Controls.Add(this.lblTransferDatumBis);
            this.grpElektronisch.Controls.Add(this.edtSucheTransferDatumBis);
            this.grpElektronisch.Location = new System.Drawing.Point(30, 40);
            this.grpElektronisch.Name = "grpElektronisch";
            this.grpElektronisch.Size = new System.Drawing.Size(245, 87);
            this.grpElektronisch.TabIndex = 3;
            this.grpElektronisch.TabStop = false;
            this.grpElektronisch.Text = "elektronische Auszahlung";
            //
            // grpBarauszahlung
            //
            this.grpBarauszahlung.Controls.Add(this.lblBarbezugsdatumVon);
            this.grpBarauszahlung.Controls.Add(this.edtSucheBarbezugDatumVon);
            this.grpBarauszahlung.Controls.Add(this.lblBarbezugsdatumBis);
            this.grpBarauszahlung.Controls.Add(this.edtSucheBarbezugDatumBis);
            this.grpBarauszahlung.Location = new System.Drawing.Point(30, 133);
            this.grpBarauszahlung.Name = "grpBarauszahlung";
            this.grpBarauszahlung.Size = new System.Drawing.Size(245, 87);
            this.grpBarauszahlung.TabIndex = 4;
            this.grpBarauszahlung.TabStop = false;
            this.grpBarauszahlung.Text = "Barauszahlung";
            //
            // lblBarbezugsdatumVon
            //
            this.lblBarbezugsdatumVon.Location = new System.Drawing.Point(6, 22);
            this.lblBarbezugsdatumVon.Name = "lblBarbezugsdatumVon";
            this.lblBarbezugsdatumVon.Size = new System.Drawing.Size(123, 24);
            this.lblBarbezugsdatumVon.TabIndex = 1;
            this.lblBarbezugsdatumVon.Text = "Barbezugsdatum von";
            this.lblBarbezugsdatumVon.UseCompatibleTextRendering = true;
            //
            // edtSucheBarbezugDatumVon
            //
            this.edtSucheBarbezugDatumVon.EditValue = null;
            this.edtSucheBarbezugDatumVon.Location = new System.Drawing.Point(135, 22);
            this.edtSucheBarbezugDatumVon.Name = "edtSucheBarbezugDatumVon";
            this.edtSucheBarbezugDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheBarbezugDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBarbezugDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBarbezugDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBarbezugDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBarbezugDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBarbezugDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBarbezugDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtSucheBarbezugDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheBarbezugDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtSucheBarbezugDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheBarbezugDatumVon.Properties.ShowToday = false;
            this.edtSucheBarbezugDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtSucheBarbezugDatumVon.TabIndex = 0;
            //
            // lblBarbezugsdatumBis
            //
            this.lblBarbezugsdatumBis.Location = new System.Drawing.Point(6, 52);
            this.lblBarbezugsdatumBis.Name = "lblBarbezugsdatumBis";
            this.lblBarbezugsdatumBis.Size = new System.Drawing.Size(123, 24);
            this.lblBarbezugsdatumBis.TabIndex = 2;
            this.lblBarbezugsdatumBis.Text = "Barbezugsdatum bis";
            this.lblBarbezugsdatumBis.UseCompatibleTextRendering = true;
            //
            // edtSucheBarbezugDatumBis
            //
            this.edtSucheBarbezugDatumBis.EditValue = null;
            this.edtSucheBarbezugDatumBis.Location = new System.Drawing.Point(135, 52);
            this.edtSucheBarbezugDatumBis.Name = "edtSucheBarbezugDatumBis";
            this.edtSucheBarbezugDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheBarbezugDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBarbezugDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBarbezugDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBarbezugDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBarbezugDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBarbezugDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBarbezugDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtSucheBarbezugDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheBarbezugDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtSucheBarbezugDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheBarbezugDatumBis.Properties.ShowToday = false;
            this.edtSucheBarbezugDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtSucheBarbezugDatumBis.TabIndex = 1;
            //
            // CtlQueryKgZahllaufJournal
            //
            this.Name = "CtlQueryKgZahllaufJournal";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgListe.PerformLayout();
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTransferDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTransferDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTransferDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTransferDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.grpElektronisch.ResumeLayout(false);
            this.grpBarauszahlung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblBarbezugsdatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBarbezugDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBarbezugsdatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBarbezugDatumBis.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void OnSearch()
        {
            base.OnSearch();

            //wenn eine spezifische Auszahlungsart ausgewählt wurde, macht es keinen Sinn, die Gruppierung collapsed zu lassen
            if (edtSucheTransferDatumVon.EditValue == null && edtSucheTransferDatumBis.EditValue == null
                || edtSucheBarbezugDatumVon.EditValue == null && edtSucheBarbezugDatumBis.EditValue == null)
            {
                gridView1.ExpandAllGroups();
            }
        }

        #endregion

        #endregion
    }
}