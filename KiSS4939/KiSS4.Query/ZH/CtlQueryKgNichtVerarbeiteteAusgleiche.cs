using System;
using System.Data;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query.ZH
{
    public class CtlQueryKgNichtVerarbeiteteAusgleiche : KissQueryControl
    {
        #region Fields

        #region Private Fields

        private KiSS4.Gui.KissButton btnAlle;
        private KiSS4.Gui.KissButton btnAusgleich;
        private KiSS4.Gui.KissButton btnBudgetposition;
        private KiSS4.Gui.KissButton btnKeine;
        private DevExpress.XtraGrid.Columns.GridColumn colBelegNr;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungstext;
        private DevExpress.XtraGrid.Columns.GridColumn colFehlermeldung;
        private DevExpress.XtraGrid.Columns.GridColumn colKonto;
        private DevExpress.XtraGrid.Columns.GridColumn colKreditor;
        private DevExpress.XtraGrid.Columns.GridColumn colMandant;
        private DevExpress.XtraGrid.Columns.GridColumn colSelektion;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colValuta;
        private KiSS4.Gui.KissLookUpEdit edtAuszahlungsart;
        private KiSS4.Gui.KissLookUpEdit edtBuchungsstatus;
        private KiSS4.Gui.KissDateEdit edtValutaBis;
        private KiSS4.Gui.KissDateEdit edtValutaVon;
        private DevExpress.XtraGrid.Views.Grid.GridView grvQuery;
        private KiSS4.Gui.KissLabel lblAuszahlungsart;
        private KiSS4.Gui.KissLabel lblBuchungsstatus;
        private KiSS4.Gui.KissLabel lblValutaBis;
        private KiSS4.Gui.KissLabel lblValutaVon;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;

        #endregion

        #endregion

        #region Constructors

        public CtlQueryKgNichtVerarbeiteteAusgleiche()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryKgNichtVerarbeiteteAusgleiche));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btnAlle = new KiSS4.Gui.KissButton();
            this.btnAusgleich = new KiSS4.Gui.KissButton();
            this.btnBudgetposition = new KiSS4.Gui.KissButton();
            this.btnKeine = new KiSS4.Gui.KissButton();
            this.edtValutaBis = new KiSS4.Gui.KissDateEdit();
            this.edtValutaVon = new KiSS4.Gui.KissDateEdit();
            this.lblAuszahlungsart = new KiSS4.Gui.KissLabel();
            this.lblBuchungsstatus = new KiSS4.Gui.KissLabel();
            this.lblValutaBis = new KiSS4.Gui.KissLabel();
            this.lblValutaVon = new KiSS4.Gui.KissLabel();
            this.edtAuszahlungsart = new KiSS4.Gui.KissLookUpEdit();
            this.edtBuchungsstatus = new KiSS4.Gui.KissLookUpEdit();
            this.colBelegNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungstext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFehlermeldung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKonto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKreditor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMandant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSelektion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValuta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grvQuery = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtValutaBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValutaVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuszahlungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungsstatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValutaBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValutaVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuszahlungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuszahlungsart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungsstatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungsstatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            this.SuspendLayout();
            //
            // qryQuery
            //
            this.qryQuery.BatchUpdate = true;
            this.qryQuery.CanUpdate = true;
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            this.qryQuery.AfterFill += new System.EventHandler(this.qryQuery_AfterFill);
            //
            // grdQuery1
            //
            this.grdQuery1.EmbeddedNavigator.Name = "";
            this.grdQuery1.GridStyle = KiSS4.Gui.GridStyleType.Default;
            this.grdQuery1.MainView = this.grvQuery;
            this.grdQuery1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
                        this.repositoryItemImageComboBox1,
                        this.repositoryItemCheckEdit1});
            this.grdQuery1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                        this.grvQuery});
            //
            // xDocument
            //
            this.xDocument.DataMember = null;
            this.xDocument.EditValue = null;
            this.xDocument.Location = new System.Drawing.Point(636, 371);
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
            this.ctlGotoFall.DataMember = "BaPersonID$";
            this.ctlGotoFall.Size = new System.Drawing.Size(110, 24);
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.btnKeine);
            this.tpgListe.Controls.Add(this.btnBudgetposition);
            this.tpgListe.Controls.Add(this.btnAusgleich);
            this.tpgListe.Controls.Add(this.btnAlle);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Controls.SetChildIndex(this.grdQuery1, 0);
            this.tpgListe.Controls.SetChildIndex(this.ctlGotoFall, 0);
            this.tpgListe.Controls.SetChildIndex(this.xDocument, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnAlle, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnAusgleich, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnBudgetposition, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnKeine, 0);
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.edtBuchungsstatus);
            this.tpgSuchen.Controls.Add(this.edtAuszahlungsart);
            this.tpgSuchen.Controls.Add(this.lblValutaVon);
            this.tpgSuchen.Controls.Add(this.lblValutaBis);
            this.tpgSuchen.Controls.Add(this.lblBuchungsstatus);
            this.tpgSuchen.Controls.Add(this.lblAuszahlungsart);
            this.tpgSuchen.Controls.Add(this.edtValutaVon);
            this.tpgSuchen.Controls.Add(this.edtValutaBis);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtValutaBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtValutaVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblAuszahlungsart, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBuchungsstatus, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblValutaBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblValutaVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAuszahlungsart, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBuchungsstatus, 0);
            //
            // btnAlle
            //
            this.btnAlle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlle.Location = new System.Drawing.Point(595, 398);
            this.btnAlle.Name = "btnAlle";
            this.btnAlle.Size = new System.Drawing.Size(84, 24);
            this.btnAlle.TabIndex = 3;
            this.btnAlle.Text = "Alle";
            this.btnAlle.UseCompatibleTextRendering = true;
            this.btnAlle.UseVisualStyleBackColor = false;
            this.btnAlle.Click += new System.EventHandler(this.btnAlle_Click);
            //
            // btnAusgleich
            //
            this.btnAusgleich.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAusgleich.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAusgleich.Location = new System.Drawing.Point(321, 398);
            this.btnAusgleich.Name = "btnAusgleich";
            this.btnAusgleich.Size = new System.Drawing.Size(143, 24);
            this.btnAusgleich.TabIndex = 3;
            this.btnAusgleich.Text = "Ausgleich verarbeiten";
            this.btnAusgleich.UseCompatibleTextRendering = true;
            this.btnAusgleich.UseVisualStyleBackColor = false;
            this.btnAusgleich.Click += new System.EventHandler(this.btnAusgleich_Click);
            //
            // btnBudgetposition
            //
            this.btnBudgetposition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBudgetposition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBudgetposition.Location = new System.Drawing.Point(130, 398);
            this.btnBudgetposition.Name = "btnBudgetposition";
            this.btnBudgetposition.Size = new System.Drawing.Size(120, 24);
            this.btnBudgetposition.TabIndex = 3;
            this.btnBudgetposition.Text = "> Budgetposition";
            this.btnBudgetposition.UseCompatibleTextRendering = true;
            this.btnBudgetposition.UseVisualStyleBackColor = false;
            this.btnBudgetposition.Click += new System.EventHandler(this.btnBudgetposition_Click);
            //
            // btnKeine
            //
            this.btnKeine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKeine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeine.Location = new System.Drawing.Point(685, 398);
            this.btnKeine.Name = "btnKeine";
            this.btnKeine.Size = new System.Drawing.Size(84, 24);
            this.btnKeine.TabIndex = 3;
            this.btnKeine.Text = "Keine";
            this.btnKeine.UseCompatibleTextRendering = true;
            this.btnKeine.UseVisualStyleBackColor = false;
            this.btnKeine.Click += new System.EventHandler(this.btnKeine_Click);
            //
            // edtValutaBis
            //
            this.edtValutaBis.EditValue = null;
            this.edtValutaBis.Location = new System.Drawing.Point(99, 77);
            this.edtValutaBis.Name = "edtValutaBis";
            this.edtValutaBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtValutaBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtValutaBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtValutaBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtValutaBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtValutaBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtValutaBis.Properties.Appearance.Options.UseFont = true;
            this.edtValutaBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtValutaBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtValutaBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtValutaBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtValutaBis.Properties.ShowToday = false;
            this.edtValutaBis.Size = new System.Drawing.Size(100, 24);
            this.edtValutaBis.TabIndex = 1;
            //
            // edtValutaVon
            //
            this.edtValutaVon.EditValue = null;
            this.edtValutaVon.Location = new System.Drawing.Point(99, 47);
            this.edtValutaVon.Name = "edtValutaVon";
            this.edtValutaVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.edtValutaVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtValutaVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtValutaVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtValutaVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtValutaVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtValutaVon.Properties.Appearance.Options.UseFont = true;
            this.edtValutaVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtValutaVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtValutaVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtValutaVon.Properties.ShowToday = false;
            this.edtValutaVon.Size = new System.Drawing.Size(100, 24);
            this.edtValutaVon.TabIndex = 1;
            //
            // lblAuszahlungsart
            //
            this.lblAuszahlungsart.Location = new System.Drawing.Point(8, 107);
            this.lblAuszahlungsart.Name = "lblAuszahlungsart";
            this.lblAuszahlungsart.Size = new System.Drawing.Size(85, 24);
            this.lblAuszahlungsart.TabIndex = 2;
            this.lblAuszahlungsart.Text = "Auszahlungsart";
            this.lblAuszahlungsart.UseCompatibleTextRendering = true;
            //
            // lblBuchungsstatus
            //
            this.lblBuchungsstatus.Location = new System.Drawing.Point(8, 137);
            this.lblBuchungsstatus.Name = "lblBuchungsstatus";
            this.lblBuchungsstatus.Size = new System.Drawing.Size(85, 24);
            this.lblBuchungsstatus.TabIndex = 2;
            this.lblBuchungsstatus.Text = "Status";
            this.lblBuchungsstatus.UseCompatibleTextRendering = true;
            //
            // lblValutaBis
            //
            this.lblValutaBis.Location = new System.Drawing.Point(8, 77);
            this.lblValutaBis.Name = "lblValutaBis";
            this.lblValutaBis.Size = new System.Drawing.Size(85, 24);
            this.lblValutaBis.TabIndex = 2;
            this.lblValutaBis.Text = "Valuta bis";
            this.lblValutaBis.UseCompatibleTextRendering = true;
            //
            // lblValutaVon
            //
            this.lblValutaVon.Location = new System.Drawing.Point(8, 47);
            this.lblValutaVon.Name = "lblValutaVon";
            this.lblValutaVon.Size = new System.Drawing.Size(85, 24);
            this.lblValutaVon.TabIndex = 2;
            this.lblValutaVon.Text = "Valuta von";
            this.lblValutaVon.UseCompatibleTextRendering = true;
            //
            // edtAuszahlungsart
            //
            this.edtAuszahlungsart.Location = new System.Drawing.Point(99, 107);
            this.edtAuszahlungsart.LOVName = "KgAuszahlungsArt";
            this.edtAuszahlungsart.Name = "edtAuszahlungsart";
            this.edtAuszahlungsart.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAuszahlungsart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAuszahlungsart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuszahlungsart.Properties.Appearance.Options.UseBackColor = true;
            this.edtAuszahlungsart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAuszahlungsart.Properties.Appearance.Options.UseFont = true;
            this.edtAuszahlungsart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAuszahlungsart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtAuszahlungsart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAuszahlungsart.Properties.NullText = "";
            this.edtAuszahlungsart.Properties.ShowFooter = false;
            this.edtAuszahlungsart.Properties.ShowHeader = false;
            this.edtAuszahlungsart.Size = new System.Drawing.Size(198, 24);
            this.edtAuszahlungsart.TabIndex = 3;
            //
            // edtBuchungsstatus
            //
            this.edtBuchungsstatus.Location = new System.Drawing.Point(99, 137);
            this.edtBuchungsstatus.LOVName = "KgBuchungsStatus";
            this.edtBuchungsstatus.Name = "edtBuchungsstatus";
            this.edtBuchungsstatus.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBuchungsstatus.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBuchungsstatus.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchungsstatus.Properties.Appearance.Options.UseBackColor = true;
            this.edtBuchungsstatus.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBuchungsstatus.Properties.Appearance.Options.UseFont = true;
            this.edtBuchungsstatus.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBuchungsstatus.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchungsstatus.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBuchungsstatus.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBuchungsstatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtBuchungsstatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtBuchungsstatus.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBuchungsstatus.Properties.NullText = "";
            this.edtBuchungsstatus.Properties.ShowFooter = false;
            this.edtBuchungsstatus.Properties.ShowHeader = false;
            this.edtBuchungsstatus.Size = new System.Drawing.Size(198, 24);
            this.edtBuchungsstatus.TabIndex = 3;
            //
            // colBelegNr
            //
            this.colBelegNr.Caption = "Beleg-Nr";
            this.colBelegNr.FieldName = "PscdBelegNr";
            this.colBelegNr.Name = "colBelegNr";
            this.colBelegNr.OptionsColumn.AllowEdit = false;
            this.colBelegNr.Visible = true;
            this.colBelegNr.VisibleIndex = 0;
            //
            // colBetrag
            //
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.FieldName = "Betrag";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.OptionsColumn.AllowEdit = false;
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 5;
            //
            // colBuchungstext
            //
            this.colBuchungstext.Caption = "Buchungstext";
            this.colBuchungstext.FieldName = "Text";
            this.colBuchungstext.Name = "colBuchungstext";
            this.colBuchungstext.OptionsColumn.AllowEdit = false;
            this.colBuchungstext.Visible = true;
            this.colBuchungstext.VisibleIndex = 4;
            //
            // colFehlermeldung
            //
            this.colFehlermeldung.Caption = "Fehlermeldung";
            this.colFehlermeldung.FieldName = "Fehlermeldung";
            this.colFehlermeldung.Name = "colFehlermeldung";
            this.colFehlermeldung.Visible = true;
            this.colFehlermeldung.VisibleIndex = 9;
            this.colFehlermeldung.Width = 142;
            //
            // colKonto
            //
            this.colKonto.Caption = "Konto";
            this.colKonto.FieldName = "SollKtoNr";
            this.colKonto.Name = "colKonto";
            this.colKonto.OptionsColumn.AllowEdit = false;
            this.colKonto.Visible = true;
            this.colKonto.VisibleIndex = 3;
            //
            // colKreditor
            //
            this.colKreditor.Caption = "Kreditor";
            this.colKreditor.FieldName = "Kreditor";
            this.colKreditor.Name = "colKreditor";
            this.colKreditor.OptionsColumn.AllowEdit = false;
            this.colKreditor.Visible = true;
            this.colKreditor.VisibleIndex = 6;
            //
            // colMandant
            //
            this.colMandant.Caption = "Person m. zivilr. Massn.";
            this.colMandant.FieldName = "Mandant";
            this.colMandant.Name = "colMandant";
            this.colMandant.OptionsColumn.AllowEdit = false;
            this.colMandant.Visible = true;
            this.colMandant.VisibleIndex = 2;
            //
            // colSelektion
            //
            this.colSelektion.Caption = "Sel";
            this.colSelektion.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colSelektion.FieldName = "Sel";
            this.colSelektion.Name = "colSelektion";
            this.colSelektion.Visible = true;
            this.colSelektion.VisibleIndex = 8;
            this.colSelektion.Width = 37;
            //
            // colStatus
            //
            this.colStatus.Caption = "Stat.";
            this.colStatus.ColumnEdit = this.repositoryItemImageComboBox1;
            this.colStatus.FieldName = "KgBuchungStatusCode";
            this.colStatus.Name = "colStatus";
            this.colStatus.OptionsColumn.AllowEdit = false;
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 7;
            this.colStatus.Width = 46;
            //
            // colValuta
            //
            this.colValuta.Caption = "Valuta";
            this.colValuta.FieldName = "ValutaDatum";
            this.colValuta.Name = "colValuta";
            this.colValuta.OptionsColumn.AllowEdit = false;
            this.colValuta.Visible = true;
            this.colValuta.VisibleIndex = 1;
            //
            // grvQuery
            //
            this.grvQuery.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvQuery.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery.Appearance.Empty.Options.UseBackColor = true;
            this.grvQuery.Appearance.Empty.Options.UseFont = true;
            this.grvQuery.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvQuery.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvQuery.Appearance.EvenRow.Options.UseFont = true;
            this.grvQuery.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvQuery.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvQuery.Appearance.FocusedCell.Options.UseFont = true;
            this.grvQuery.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvQuery.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvQuery.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvQuery.Appearance.FocusedRow.Options.UseFont = true;
            this.grvQuery.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvQuery.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvQuery.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvQuery.Appearance.GroupRow.Options.UseFont = true;
            this.grvQuery.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvQuery.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvQuery.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvQuery.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvQuery.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvQuery.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvQuery.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvQuery.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvQuery.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvQuery.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvQuery.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvQuery.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery.Appearance.OddRow.Options.UseFont = true;
            this.grvQuery.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvQuery.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery.Appearance.Row.Options.UseBackColor = true;
            this.grvQuery.Appearance.Row.Options.UseFont = true;
            this.grvQuery.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvQuery.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvQuery.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvQuery.Appearance.SelectedRow.Options.UseFont = true;
            this.grvQuery.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvQuery.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery.Appearance.VertLine.Options.UseBackColor = true;
            this.grvQuery.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvQuery.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                        this.colBelegNr,
                        this.colValuta,
                        this.colMandant,
                        this.colKonto,
                        this.colBuchungstext,
                        this.colBetrag,
                        this.colKreditor,
                        this.colStatus,
                        this.colSelektion,
                        this.colFehlermeldung});
            this.grvQuery.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvQuery.GridControl = this.grdQuery1;
            this.grvQuery.Name = "grvQuery";
            this.grvQuery.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvQuery.OptionsNavigation.AutoFocusNewRow = true;
            this.grvQuery.OptionsNavigation.UseTabKey = false;
            this.grvQuery.OptionsView.ColumnAutoWidth = false;
            this.grvQuery.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvQuery.OptionsView.ShowGroupPanel = false;
            this.grvQuery.OptionsView.ShowIndicator = false;
            //
            // repositoryItemCheckEdit1
            //
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            //
            // repositoryItemImageComboBox1
            //
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            //
            // CtlQueryKgNichtVerarbeiteteAusgleiche
            //
            this.Name = "CtlQueryKgNichtVerarbeiteteAusgleiche";
            this.Load += new System.EventHandler(this.CtlQueryKgNichtVerarbeiteteAusgleiche_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtValutaBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValutaVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuszahlungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungsstatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValutaBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValutaVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuszahlungsart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuszahlungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungsstatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungsstatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        #region EventHandlers

        private void btnAlle_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in qryQuery.DataTable.Rows)
            {
                row["Sel"] = 1;
            }

            CheckAusgleichEnabled();
        }

        private void btnAusgleich_Click(object sender, EventArgs e)
        {
            // Ausgleichsfunktionalität hat schwere Fehler, die erst behoben und getestet werden müssen.
            // Evt. kann die Maske ganz entfernt werden (alternative Maske mit ähnlicher Funktionalität besteht)
            throw new Exception("Fehler: nicht getestete Methode");

            /*
            foreach(DataRow row in qryQuery.DataTable.Rows)
            {
                if( (bool)row["Sel"] == true )
                {
                    object ezdat = System.DBNull.Value;
                    try
                    {
                        //TODO: Fehler: QryQuery statt row
                        ezdat = DateTime.ParseExact( qryQuery["EZDAT"] as string, "yyyy-MM-dd", System.Globalization.CultureInfo.CurrentCulture);
                    }
                    catch{}

                    object augdt = System.DBNull.Value;
                    try
                    {
                        // TODO: Fehler: QryQuery statt row
                        augdt = DateTime.ParseExact(qryQuery["AUGDT"] as string, "yyyy-MM-dd", System.Globalization.CultureInfo.CurrentCulture);
                    }
                    catch{}

                    try
                    {
                        Session.BeginTransaction();
                        //TODO: Fehler: qryQuery statt row
                        DBUtil.ExecSQLThrowingException(@"
                          EXEC dbo.[spPscdProcessAusgleichsinfo] {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}",
                          qryQuery["AUGBL"],
                          qryQuery["AUGBT"],
                          augdt,
                          qryQuery["AUGRD"],
                          ezdat,
                          qryQuery["VTREF"],
                          qryQuery["GPART"],
                          qryQuery["OPBEL"],
                          qryQuery["OPUPK"],
                          qryQuery["KEYZ1"],
                          qryQuery["POSZA"],
                          qryQuery["OPUPW"],
                          qryQuery["OPUPZ"],
                          qryQuery["WVSTAT"]);
                        // Fehler qryQuery statt row
                        DBUtil.ExecSQLThrowingException(@"DELETE FROM PscdAusgleichLeiche WHERE PscdAusgleichLeicheID = {0}", qryQuery["PscdAusgleichLeicheID"]);
                        Session.Commit();
                    }
                    catch(Exception ex)
                    {
                        Session.Rollback();
                        qryQuery["Fehlermeldung"] = ex.Message;
                        KissMsg.ShowError("CtlQueryKgNichtVerarbeiteteAusgleiche", "AusgleichNichtVerarbeitet", "Ausgleich konnte nicht verarbeitet werden", ex);
                    }
                }
            }
            qryQuery.Refresh();
            */
        }

        private void btnBudgetposition_Click(object sender, EventArgs e)
        {
            string jumpToPath = string.Format(
                "ClassName=FrmFall;" +
                "BaPersonID={0};" +
                "ModulID=5;" +
                @"TreeNodeID=CtlKgLeistung{1}\Masterbudget{2}\Monatsbudget{3};" +
                "ActiveSQLQuery.Find=KgPositionID = {4};",
                qryQuery["FallBaPersonID$"],
                qryQuery["KgLeistungID$"],
                qryQuery["KgBudgetID_Masterbudget$"],
                qryQuery["KgBudgetID$"],
                qryQuery["KgPositionID$"]);

            System.Collections.Specialized.HybridDictionary dic = FormController.ConvertToDictionary(jumpToPath);
            FormController.OpenForm((string)dic["ClassName"], "Action", "JumpToPath", dic);
        }

        private void btnKeine_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in qryQuery.DataTable.Rows)
            {
                row["Sel"] = 0;
            }

            CheckAusgleichEnabled();
        }

        private void CtlQueryKgNichtVerarbeiteteAusgleiche_Load(object sender, EventArgs e)
        {
            //Buchungsstati laden
            repositoryItemImageComboBox1.SmallImages = KissImageList.SmallImageList;
            SqlQuery qryStati = DBUtil.OpenSQL("select * from XLOVCode where LOVName = 'KgBuchungsStatus' order by SortKey");
            foreach (DataRow row in qryStati.DataTable.Rows)
            {
                repositoryItemImageComboBox1.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(
                    row["Text"].ToString(),
                    (int)row["Code"],
                    KissImageList.GetImageIndex(Convert.ToInt32(row["Value1"]))));
            }
            grvQuery.CellValueChanging += grvZahllauf_CellValueChanging;

            //this.repositoryItemCheckEdit1.EditValueChanged += repositoryItemCheckEdit1_EditValueChanged;
        }

        private void grvZahllauf_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            grvQuery.SetRowCellValue(e.RowHandle, colSelektion, e.Value);
            CheckAusgleichEnabled();
        }

        private void qryQuery_AfterFill(object sender, EventArgs e)
        {
            bool rowsFound = qryQuery.Count > 0;
            btnBudgetposition.Enabled = rowsFound;
            btnAusgleich.Enabled = rowsFound;
            btnAlle.Enabled = rowsFound;
            btnKeine.Enabled = rowsFound;

            CheckAusgleichEnabled();
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();

            edtBuchungsstatus.EditValue = 3;
        }

        #endregion

        #region Private Methods

        private void CheckAusgleichEnabled()
        {
            bool oneOrMoreSelected = false;
            foreach (DataRow row in qryQuery.DataTable.Rows)
            {
                if ((bool)row["Sel"])
                {
                    oneOrMoreSelected = true;
                    break;
                }
            }
            btnAusgleich.Enabled = oneOrMoreSelected;
        }

        #endregion

        #endregion
    }
}