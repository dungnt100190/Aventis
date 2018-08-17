using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Schnittstellen.DTA_EZAG;

using Kiss.Interfaces.UI;

namespace KiSS4.Klientenbuchhaltung
{
    /// <summary>
    /// Control, used for searching Zahlungslauf of KliBu
    /// </summary>
    partial class CtlKbZahlungslauf 
    {
        #region Fields

        #region Private Fields

        private KiSS4.Gui.KissButton btnAlle;
        private KiSS4.Gui.KissButton btnKeine;
        private KiSS4.Gui.KissButton btnMonatsbudget;
        private KiSS4.Gui.KissButton btnTransfer;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungID;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungstext;
        private DevExpress.XtraGrid.Columns.GridColumn colKreditor;
        private DevExpress.XtraGrid.Columns.GridColumn colSelektion;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colTage;
        private DevExpress.XtraGrid.Columns.GridColumn colValuta;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissCalcEdit edtAnzahl;
        private KissTextEdit edtBuchungstext;
        private KissLookUpEdit edtEinzahlungsscheinCode;
        private KissDateEdit edtErstelltDatum;
        private KiSS4.Gui.KissDateEdit edtFaelligkeitsdatum;
        private KissMemoEdit edtFehlermeldung;
        private KiSS4.Gui.KissLookUpEdit edtGruppeX;
        private KiSS4.Gui.KissLookUpEdit edtKbZahlungskonto;
        private KissTextEdit edtKreditorLinie;
        private KiSS4.Gui.KissTextEdit edtPeriodeID;
        private KiSS4.Gui.KissDateEdit edtSucheValutaBis;
        private KiSS4.Gui.KissCalcEdit edtTotal;
        private KiSS4.Gui.KissGrid grdZahllauf;
        private DevExpress.XtraGrid.Views.Grid.GridView grvZahllauf;
        private KissLabel kissLabel1;
        private KiSS4.Gui.KissLabel kissLabel2;
        private KiSS4.Gui.KissLabel kissLabel3;
        private KiSS4.Gui.KissLabel kissLabel4;
        private KiSS4.Gui.KissLabel kissLabel6;
        private KiSS4.Gui.KissLabel kissLabel7;
        private KissLabel kissLabel8;
        private KiSS4.Gui.KissLabel kissLabel9;
        private KissLabel lblBaZahlungswegID;
        private KissLabel lblBuchungstext;
        private KissLabel lblEinzahlungsscheinCode;
        private KissLabel lblErfassungDatum;
        private KiSS4.Gui.KissLabel lblFaelligkeitsdatum;
        private KiSS4.Gui.KissLabel lblTitel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryAktivKonto;
        private KiSS4.DB.SqlQuery qryBuchung;
        private KiSS4.DB.SqlQuery qryGruppe;
        private KiSS4.DB.SqlQuery qryZahlungskonto;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;

        #endregion

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKbZahlungslauf));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryBuchung = new KiSS4.DB.SqlQuery(this.components);
            this.grdZahllauf = new KiSS4.Gui.KissGrid();
            this.grvZahllauf = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBuchungID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValuta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungstext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKreditor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colSelektion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.edtSucheValutaBis = new KiSS4.Gui.KissDateEdit();
            this.kissLabel6 = new KiSS4.Gui.KissLabel();
            this.kissLabel7 = new KiSS4.Gui.KissLabel();
            this.kissLabel9 = new KiSS4.Gui.KissLabel();
            this.edtPeriodeID = new KiSS4.Gui.KissTextEdit();
            this.edtGruppeX = new KiSS4.Gui.KissLookUpEdit();
            this.btnTransfer = new KiSS4.Gui.KissButton();
            this.btnAlle = new KiSS4.Gui.KissButton();
            this.btnKeine = new KiSS4.Gui.KissButton();
            this.btnMonatsbudget = new KiSS4.Gui.KissButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.edtTotal = new KiSS4.Gui.KissCalcEdit();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.edtAnzahl = new KiSS4.Gui.KissCalcEdit();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.edtKbZahlungskonto = new KiSS4.Gui.KissLookUpEdit();
            this.edtFaelligkeitsdatum = new KiSS4.Gui.KissDateEdit();
            this.lblFaelligkeitsdatum = new KiSS4.Gui.KissLabel();
            this.qryAktivKonto = new KiSS4.DB.SqlQuery(this.components);
            this.qryGruppe = new KiSS4.DB.SqlQuery(this.components);
            this.qryZahlungskonto = new KiSS4.DB.SqlQuery(this.components);
            this.edtFehlermeldung = new KiSS4.Gui.KissMemoEdit();
            this.lblEinzahlungsscheinCode = new KiSS4.Gui.KissLabel();
            this.lblBaZahlungswegID = new KiSS4.Gui.KissLabel();
            this.lblErfassungDatum = new KiSS4.Gui.KissLabel();
            this.kissLabel8 = new KiSS4.Gui.KissLabel();
            this.lblBuchungstext = new KiSS4.Gui.KissLabel();
            this.edtKreditorLinie = new KiSS4.Gui.KissTextEdit();
            this.edtEinzahlungsscheinCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtErstelltDatum = new KiSS4.Gui.KissDateEdit();
            this.edtBuchungstext = new KiSS4.Gui.KissTextEdit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryBuchung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZahllauf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZahllauf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheValutaBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPeriodeID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGruppeX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGruppeX.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnzahl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKbZahlungskonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKbZahlungskonto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaelligkeitsdatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaelligkeitsdatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryAktivKonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryGruppe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZahlungskonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFehlermeldung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinzahlungsscheinCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaZahlungswegID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungstext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditorLinie.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinzahlungsscheinCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinzahlungsscheinCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErstelltDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungstext.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(887, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSearch.Location = new System.Drawing.Point(5, 37);
            this.tabControlSearch.Size = new System.Drawing.Size(911, 348);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdZahllauf);
            this.tpgListe.Size = new System.Drawing.Size(899, 310);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtGruppeX);
            this.tpgSuchen.Controls.Add(this.edtPeriodeID);
            this.tpgSuchen.Controls.Add(this.kissLabel9);
            this.tpgSuchen.Controls.Add(this.kissLabel7);
            this.tpgSuchen.Controls.Add(this.kissLabel6);
            this.tpgSuchen.Controls.Add(this.edtSucheValutaBis);
            this.tpgSuchen.Size = new System.Drawing.Size(899, 310);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheValutaBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel6, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel7, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel9, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtPeriodeID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtGruppeX, 0);
            // 
            // qryBuchung
            // 
            this.qryBuchung.BatchUpdate = true;
            this.qryBuchung.CanUpdate = true;
            this.qryBuchung.HostControl = this;
            this.qryBuchung.IsIdentityInsert = false;
            this.qryBuchung.SelectStatement = resources.GetString("qryBuchung.SelectStatement");
            this.qryBuchung.AfterFill += new System.EventHandler(this.qryBuchung_AfterFill);
            this.qryBuchung.PositionChanged += new System.EventHandler(this.qryBuchung_PositionChanged);
            // 
            // grdZahllauf
            // 
            this.grdZahllauf.DataSource = this.qryBuchung;
            this.grdZahllauf.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdZahllauf.EmbeddedNavigator.Name = "";
            this.grdZahllauf.Location = new System.Drawing.Point(0, 0);
            this.grdZahllauf.MainView = this.grvZahllauf;
            this.grdZahllauf.Name = "grdZahllauf";
            this.grdZahllauf.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1,
            this.repositoryItemTextEdit1,
            this.repositoryItemCheckEdit1});
            this.grdZahllauf.Size = new System.Drawing.Size(899, 310);
            this.grdZahllauf.TabIndex = 0;
            this.grdZahllauf.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvZahllauf});
            this.grdZahllauf.Click += new System.EventHandler(this.grdZahllauf_Click);
            // 
            // grvZahllauf
            // 
            this.grvZahllauf.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvZahllauf.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahllauf.Appearance.Empty.Options.UseBackColor = true;
            this.grvZahllauf.Appearance.Empty.Options.UseFont = true;
            this.grvZahllauf.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahllauf.Appearance.EvenRow.Options.UseFont = true;
            this.grvZahllauf.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvZahllauf.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahllauf.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvZahllauf.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvZahllauf.Appearance.FocusedCell.Options.UseFont = true;
            this.grvZahllauf.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvZahllauf.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvZahllauf.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahllauf.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvZahllauf.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvZahllauf.Appearance.FocusedRow.Options.UseFont = true;
            this.grvZahllauf.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvZahllauf.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZahllauf.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvZahllauf.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZahllauf.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahllauf.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZahllauf.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvZahllauf.Appearance.GroupRow.Options.UseFont = true;
            this.grvZahllauf.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvZahllauf.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvZahllauf.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvZahllauf.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahllauf.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvZahllauf.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvZahllauf.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvZahllauf.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvZahllauf.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahllauf.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZahllauf.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvZahllauf.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvZahllauf.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvZahllauf.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvZahllauf.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvZahllauf.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahllauf.Appearance.OddRow.Options.UseFont = true;
            this.grvZahllauf.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvZahllauf.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahllauf.Appearance.Row.Options.UseBackColor = true;
            this.grvZahllauf.Appearance.Row.Options.UseFont = true;
            this.grvZahllauf.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahllauf.Appearance.SelectedRow.Options.UseFont = true;
            this.grvZahllauf.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvZahllauf.Appearance.VertLine.Options.UseBackColor = true;
            this.grvZahllauf.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvZahllauf.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBuchungID,
            this.colValuta,
            this.colTage,
            this.colBuchungstext,
            this.colBetrag,
            this.colKreditor,
            this.colStatus,
            this.colSelektion});
            this.grvZahllauf.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvZahllauf.GridControl = this.grdZahllauf;
            this.grvZahllauf.Name = "grvZahllauf";
            this.grvZahllauf.OptionsCustomization.AllowFilter = false;
            this.grvZahllauf.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvZahllauf.OptionsNavigation.AutoFocusNewRow = true;
            this.grvZahllauf.OptionsNavigation.UseTabKey = false;
            this.grvZahllauf.OptionsView.ColumnAutoWidth = false;
            this.grvZahllauf.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvZahllauf.OptionsView.ShowGroupPanel = false;
            this.grvZahllauf.OptionsView.ShowIndicator = false;
            // 
            // colBuchungID
            // 
            this.colBuchungID.AppearanceCell.Options.UseTextOptions = true;
            this.colBuchungID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colBuchungID.Caption = "Beleg-Nr.";
            this.colBuchungID.FieldName = "BelegNr";
            this.colBuchungID.Name = "colBuchungID";
            this.colBuchungID.Visible = true;
            this.colBuchungID.VisibleIndex = 0;
            this.colBuchungID.Width = 94;
            // 
            // colValuta
            // 
            this.colValuta.Caption = "Valuta";
            this.colValuta.FieldName = "ValutaDatum";
            this.colValuta.Name = "colValuta";
            this.colValuta.OptionsColumn.AllowEdit = false;
            this.colValuta.Visible = true;
            this.colValuta.VisibleIndex = 1;
            this.colValuta.Width = 82;
            // 
            // colTage
            // 
            this.colTage.Caption = "Tage";
            this.colTage.FieldName = "Tage";
            this.colTage.Name = "colTage";
            this.colTage.OptionsColumn.AllowEdit = false;
            this.colTage.Visible = true;
            this.colTage.VisibleIndex = 2;
            // 
            // colBuchungstext
            // 
            this.colBuchungstext.Caption = "Buchungstext";
            this.colBuchungstext.FieldName = "Text";
            this.colBuchungstext.Name = "colBuchungstext";
            this.colBuchungstext.OptionsColumn.AllowEdit = false;
            this.colBuchungstext.Visible = true;
            this.colBuchungstext.VisibleIndex = 3;
            this.colBuchungstext.Width = 162;
            // 
            // colBetrag
            // 
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.DisplayFormat.FormatString = "n2";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.FieldName = "Betrag";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.OptionsColumn.AllowEdit = false;
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 4;
            this.colBetrag.Width = 53;
            // 
            // colKreditor
            // 
            this.colKreditor.Caption = "Kreditor";
            this.colKreditor.FieldName = "KreditorLinie";
            this.colKreditor.Name = "colKreditor";
            this.colKreditor.OptionsColumn.AllowEdit = false;
            this.colKreditor.Visible = true;
            this.colKreditor.VisibleIndex = 5;
            this.colKreditor.Width = 181;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Status";
            this.colStatus.ColumnEdit = this.repositoryItemImageComboBox1;
            this.colStatus.FieldName = "KbBuchungStatusCode";
            this.colStatus.Name = "colStatus";
            this.colStatus.OptionsColumn.AllowEdit = false;
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 6;
            this.colStatus.Width = 70;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // colSelektion
            // 
            this.colSelektion.Caption = "Übermitteln";
            this.colSelektion.FieldName = "Uebermitteln";
            this.colSelektion.Name = "colSelektion";
            this.colSelektion.Visible = true;
            this.colSelektion.VisibleIndex = 7;
            this.colSelektion.Width = 84;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            this.repositoryItemTextEdit1.ReadOnly = true;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // edtSucheValutaBis
            // 
            this.edtSucheValutaBis.EditValue = null;
            this.edtSucheValutaBis.Location = new System.Drawing.Point(106, 38);
            this.edtSucheValutaBis.Name = "edtSucheValutaBis";
            this.edtSucheValutaBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheValutaBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheValutaBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheValutaBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheValutaBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheValutaBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheValutaBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheValutaBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtSucheValutaBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheValutaBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtSucheValutaBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheValutaBis.Properties.ShowToday = false;
            this.edtSucheValutaBis.Size = new System.Drawing.Size(189, 24);
            this.edtSucheValutaBis.TabIndex = 0;
            // 
            // kissLabel6
            // 
            this.kissLabel6.Location = new System.Drawing.Point(7, 38);
            this.kissLabel6.Name = "kissLabel6";
            this.kissLabel6.Size = new System.Drawing.Size(72, 24);
            this.kissLabel6.TabIndex = 3;
            this.kissLabel6.Text = "Valuta bis";
            this.kissLabel6.UseCompatibleTextRendering = true;
            // 
            // kissLabel7
            // 
            this.kissLabel7.Location = new System.Drawing.Point(8, 99);
            this.kissLabel7.Name = "kissLabel7";
            this.kissLabel7.Size = new System.Drawing.Size(72, 24);
            this.kissLabel7.TabIndex = 3;
            this.kissLabel7.Text = "Periode";
            this.kissLabel7.UseCompatibleTextRendering = true;
            // 
            // kissLabel9
            // 
            this.kissLabel9.Location = new System.Drawing.Point(8, 69);
            this.kissLabel9.Name = "kissLabel9";
            this.kissLabel9.Size = new System.Drawing.Size(72, 24);
            this.kissLabel9.TabIndex = 3;
            this.kissLabel9.Text = "Gruppe";
            this.kissLabel9.UseCompatibleTextRendering = true;
            // 
            // edtPeriodeID
            // 
            this.edtPeriodeID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtPeriodeID.Location = new System.Drawing.Point(106, 99);
            this.edtPeriodeID.Name = "edtPeriodeID";
            this.edtPeriodeID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPeriodeID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPeriodeID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPeriodeID.Properties.Appearance.Options.UseBackColor = true;
            this.edtPeriodeID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPeriodeID.Properties.Appearance.Options.UseFont = true;
            this.edtPeriodeID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPeriodeID.Properties.ReadOnly = true;
            this.edtPeriodeID.Size = new System.Drawing.Size(189, 24);
            this.edtPeriodeID.TabIndex = 4;
            // 
            // edtGruppeX
            // 
            this.edtGruppeX.Location = new System.Drawing.Point(106, 69);
            this.edtGruppeX.Name = "edtGruppeX";
            this.edtGruppeX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGruppeX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGruppeX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGruppeX.Properties.Appearance.Options.UseBackColor = true;
            this.edtGruppeX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGruppeX.Properties.Appearance.Options.UseFont = true;
            this.edtGruppeX.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtGruppeX.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtGruppeX.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtGruppeX.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtGruppeX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtGruppeX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtGruppeX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGruppeX.Properties.NullText = "";
            this.edtGruppeX.Properties.ShowFooter = false;
            this.edtGruppeX.Properties.ShowHeader = false;
            this.edtGruppeX.Size = new System.Drawing.Size(189, 24);
            this.edtGruppeX.TabIndex = 5;
            this.edtGruppeX.EditValueChanged += new System.EventHandler(this.edtGruppeX_EditValueChanged);
            // 
            // btnTransfer
            // 
            this.btnTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransfer.Location = new System.Drawing.Point(708, 362);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(90, 24);
            this.btnTransfer.TabIndex = 1;
            this.btnTransfer.Text = "Erstellen";
            this.btnTransfer.UseCompatibleTextRendering = true;
            this.btnTransfer.UseVisualStyleBackColor = false;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // btnAlle
            // 
            this.btnAlle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlle.Location = new System.Drawing.Point(808, 362);
            this.btnAlle.Name = "btnAlle";
            this.btnAlle.Size = new System.Drawing.Size(49, 24);
            this.btnAlle.TabIndex = 2;
            this.btnAlle.Text = "Alle";
            this.btnAlle.UseCompatibleTextRendering = true;
            this.btnAlle.UseVisualStyleBackColor = false;
            this.btnAlle.Click += new System.EventHandler(this.btnAlle_Click);
            // 
            // btnKeine
            // 
            this.btnKeine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKeine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeine.Location = new System.Drawing.Point(864, 362);
            this.btnKeine.Name = "btnKeine";
            this.btnKeine.Size = new System.Drawing.Size(50, 24);
            this.btnKeine.TabIndex = 3;
            this.btnKeine.Text = "Keine";
            this.btnKeine.UseCompatibleTextRendering = true;
            this.btnKeine.UseVisualStyleBackColor = false;
            this.btnKeine.Click += new System.EventHandler(this.btnKeine_Click);
            // 
            // btnMonatsbudget
            // 
            this.btnMonatsbudget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMonatsbudget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMonatsbudget.Location = new System.Drawing.Point(308, 362);
            this.btnMonatsbudget.Name = "btnMonatsbudget";
            this.btnMonatsbudget.Size = new System.Drawing.Size(107, 24);
            this.btnMonatsbudget.TabIndex = 4;
            this.btnMonatsbudget.Text = "> Monatsbudget";
            this.btnMonatsbudget.UseCompatibleTextRendering = true;
            this.btnMonatsbudget.UseVisualStyleBackColor = false;
            this.btnMonatsbudget.Visible = false;
            this.btnMonatsbudget.Click += new System.EventHandler(this.btnMonatsbudget_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.edtTotal);
            this.panel1.Controls.Add(this.kissLabel4);
            this.panel1.Controls.Add(this.picTitel);
            this.panel1.Controls.Add(this.kissLabel3);
            this.panel1.Controls.Add(this.kissLabel1);
            this.panel1.Controls.Add(this.kissLabel2);
            this.panel1.Controls.Add(this.edtAnzahl);
            this.panel1.Controls.Add(this.lblTitel);
            this.panel1.Controls.Add(this.edtKbZahlungskonto);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(922, 31);
            this.panel1.TabIndex = 314;
            // 
            // edtTotal
            // 
            this.edtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtTotal.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtTotal.Location = new System.Drawing.Point(784, 4);
            this.edtTotal.Name = "edtTotal";
            this.edtTotal.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtTotal.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtTotal.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTotal.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTotal.Properties.Appearance.Options.UseBackColor = true;
            this.edtTotal.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTotal.Properties.Appearance.Options.UseFont = true;
            this.edtTotal.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTotal.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTotal.Properties.DisplayFormat.FormatString = "n2";
            this.edtTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtTotal.Properties.ReadOnly = true;
            this.edtTotal.Size = new System.Drawing.Size(100, 24);
            this.edtTotal.TabIndex = 295;
            // 
            // kissLabel4
            // 
            this.kissLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kissLabel4.Location = new System.Drawing.Point(889, 4);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(28, 24);
            this.kissLabel4.TabIndex = 294;
            this.kissLabel4.Text = "CHF";
            this.kissLabel4.UseCompatibleTextRendering = true;
            // 
            // picTitel
            // 
            this.picTitel.Image = ((System.Drawing.Image)(resources.GetObject("picTitel.Image")));
            this.picTitel.Location = new System.Drawing.Point(5, 5);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 293;
            this.picTitel.TabStop = false;
            // 
            // kissLabel3
            // 
            this.kissLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kissLabel3.Location = new System.Drawing.Point(711, 4);
            this.kissLabel3.Name = "kissLabel3";
            this.kissLabel3.Size = new System.Drawing.Size(68, 24);
            this.kissLabel3.TabIndex = 6;
            this.kissLabel3.Text = "Betragstotal";
            this.kissLabel3.UseCompatibleTextRendering = true;
            // 
            // kissLabel1
            // 
            this.kissLabel1.Location = new System.Drawing.Point(154, 3);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(86, 24);
            this.kissLabel1.TabIndex = 5;
            this.kissLabel1.Text = "Zahlungskonto";
            this.kissLabel1.UseCompatibleTextRendering = true;
            // 
            // kissLabel2
            // 
            this.kissLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kissLabel2.Location = new System.Drawing.Point(551, 4);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(75, 24);
            this.kissLabel2.TabIndex = 5;
            this.kissLabel2.Text = "Anzahl Belege";
            this.kissLabel2.UseCompatibleTextRendering = true;
            // 
            // edtAnzahl
            // 
            this.edtAnzahl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtAnzahl.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAnzahl.Location = new System.Drawing.Point(632, 4);
            this.edtAnzahl.Name = "edtAnzahl";
            this.edtAnzahl.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAnzahl.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAnzahl.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAnzahl.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAnzahl.Properties.Appearance.Options.UseBackColor = true;
            this.edtAnzahl.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAnzahl.Properties.Appearance.Options.UseFont = true;
            this.edtAnzahl.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAnzahl.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAnzahl.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtAnzahl.Properties.ReadOnly = true;
            this.edtAnzahl.Size = new System.Drawing.Size(73, 24);
            this.edtAnzahl.TabIndex = 1;
            // 
            // lblTitel
            // 
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(25, 5);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(122, 23);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Zahllauf";
            this.lblTitel.UseCompatibleTextRendering = true;
            // 
            // edtKbZahlungskonto
            // 
            this.edtKbZahlungskonto.Location = new System.Drawing.Point(246, 4);
            this.edtKbZahlungskonto.Name = "edtKbZahlungskonto";
            this.edtKbZahlungskonto.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKbZahlungskonto.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKbZahlungskonto.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKbZahlungskonto.Properties.Appearance.Options.UseBackColor = true;
            this.edtKbZahlungskonto.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKbZahlungskonto.Properties.Appearance.Options.UseFont = true;
            this.edtKbZahlungskonto.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtKbZahlungskonto.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKbZahlungskonto.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtKbZahlungskonto.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtKbZahlungskonto.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtKbZahlungskonto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtKbZahlungskonto.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKbZahlungskonto.Properties.NullText = "";
            this.edtKbZahlungskonto.Properties.ShowFooter = false;
            this.edtKbZahlungskonto.Properties.ShowHeader = false;
            this.edtKbZahlungskonto.Size = new System.Drawing.Size(294, 24);
            this.edtKbZahlungskonto.TabIndex = 0;
            // 
            // edtFaelligkeitsdatum
            // 
            this.edtFaelligkeitsdatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtFaelligkeitsdatum.DataMember = null;
            this.edtFaelligkeitsdatum.DataSource = this.qryBuchung;
            this.edtFaelligkeitsdatum.EditValue = null;
            this.edtFaelligkeitsdatum.Location = new System.Drawing.Point(586, 362);
            this.edtFaelligkeitsdatum.Name = "edtFaelligkeitsdatum";
            this.edtFaelligkeitsdatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtFaelligkeitsdatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFaelligkeitsdatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaelligkeitsdatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaelligkeitsdatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaelligkeitsdatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaelligkeitsdatum.Properties.Appearance.Options.UseFont = true;
            this.edtFaelligkeitsdatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtFaelligkeitsdatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtFaelligkeitsdatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtFaelligkeitsdatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFaelligkeitsdatum.Properties.ShowToday = false;
            this.edtFaelligkeitsdatum.Size = new System.Drawing.Size(101, 24);
            this.edtFaelligkeitsdatum.TabIndex = 315;
            // 
            // lblFaelligkeitsdatum
            // 
            this.lblFaelligkeitsdatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFaelligkeitsdatum.Location = new System.Drawing.Point(446, 362);
            this.lblFaelligkeitsdatum.Name = "lblFaelligkeitsdatum";
            this.lblFaelligkeitsdatum.Size = new System.Drawing.Size(134, 24);
            this.lblFaelligkeitsdatum.TabIndex = 316;
            this.lblFaelligkeitsdatum.Text = "Bezahlen am (Fälligkeit):";
            this.lblFaelligkeitsdatum.UseCompatibleTextRendering = true;
            // 
            // qryAktivKonto
            // 
            this.qryAktivKonto.HostControl = this;
            this.qryAktivKonto.IsIdentityInsert = false;
            this.qryAktivKonto.SelectStatement = "SELECT\r\n   KbKontoId,\r\n   KbKontoartCodes,\r\n   KontoNr\r\nFROM dbo.KBKonto WITH (RE" +
    "ADUNCOMMITTED)\r\n\r\nWHERE KbPeriodeID = {0}\r\n AND KbZahlungskontoID = {1}";
            // 
            // qryGruppe
            // 
            this.qryGruppe.HostControl = this;
            this.qryGruppe.IsIdentityInsert = false;
            this.qryGruppe.SelectStatement = resources.GetString("qryGruppe.SelectStatement");
            // 
            // qryZahlungskonto
            // 
            this.qryZahlungskonto.IsIdentityInsert = false;
            this.qryZahlungskonto.SelectStatement = resources.GetString("qryZahlungskonto.SelectStatement");
            // 
            // edtFehlermeldung
            // 
            this.edtFehlermeldung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtFehlermeldung.DataMember = "FibuFehlermeldung";
            this.edtFehlermeldung.DataSource = this.qryBuchung;
            this.edtFehlermeldung.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtFehlermeldung.Location = new System.Drawing.Point(154, 469);
            this.edtFehlermeldung.Name = "edtFehlermeldung";
            this.edtFehlermeldung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtFehlermeldung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFehlermeldung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFehlermeldung.Properties.Appearance.Options.UseBackColor = true;
            this.edtFehlermeldung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFehlermeldung.Properties.Appearance.Options.UseFont = true;
            this.edtFehlermeldung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFehlermeldung.Properties.ReadOnly = true;
            this.edtFehlermeldung.Size = new System.Drawing.Size(289, 68);
            this.edtFehlermeldung.TabIndex = 407;
            // 
            // lblEinzahlungsscheinCode
            // 
            this.lblEinzahlungsscheinCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEinzahlungsscheinCode.Location = new System.Drawing.Point(479, 408);
            this.lblEinzahlungsscheinCode.Name = "lblEinzahlungsscheinCode";
            this.lblEinzahlungsscheinCode.Size = new System.Drawing.Size(66, 24);
            this.lblEinzahlungsscheinCode.TabIndex = 406;
            this.lblEinzahlungsscheinCode.Text = "Zahlwegtyp";
            this.lblEinzahlungsscheinCode.UseCompatibleTextRendering = true;
            // 
            // lblBaZahlungswegID
            // 
            this.lblBaZahlungswegID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBaZahlungswegID.Location = new System.Drawing.Point(479, 438);
            this.lblBaZahlungswegID.Name = "lblBaZahlungswegID";
            this.lblBaZahlungswegID.Size = new System.Drawing.Size(72, 24);
            this.lblBaZahlungswegID.TabIndex = 405;
            this.lblBaZahlungswegID.Text = "Kreditor";
            this.lblBaZahlungswegID.UseCompatibleTextRendering = true;
            // 
            // lblErfassungDatum
            // 
            this.lblErfassungDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblErfassungDatum.Location = new System.Drawing.Point(14, 438);
            this.lblErfassungDatum.Name = "lblErfassungDatum";
            this.lblErfassungDatum.Size = new System.Drawing.Size(55, 24);
            this.lblErfassungDatum.TabIndex = 403;
            this.lblErfassungDatum.Text = "Buchung";
            this.lblErfassungDatum.UseCompatibleTextRendering = true;
            // 
            // kissLabel8
            // 
            this.kissLabel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel8.Location = new System.Drawing.Point(14, 468);
            this.kissLabel8.Name = "kissLabel8";
            this.kissLabel8.Size = new System.Drawing.Size(105, 24);
            this.kissLabel8.TabIndex = 404;
            this.kissLabel8.Text = "Fehlermeldung";
            this.kissLabel8.UseCompatibleTextRendering = true;
            // 
            // lblBuchungstext
            // 
            this.lblBuchungstext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBuchungstext.Location = new System.Drawing.Point(14, 408);
            this.lblBuchungstext.Name = "lblBuchungstext";
            this.lblBuchungstext.Size = new System.Drawing.Size(75, 24);
            this.lblBuchungstext.TabIndex = 402;
            this.lblBuchungstext.Text = "Buchungstext";
            this.lblBuchungstext.UseCompatibleTextRendering = true;
            // 
            // edtKreditorLinie
            // 
            this.edtKreditorLinie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtKreditorLinie.DataMember = "KreditorLinie";
            this.edtKreditorLinie.DataSource = this.qryBuchung;
            this.edtKreditorLinie.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKreditorLinie.Location = new System.Drawing.Point(586, 438);
            this.edtKreditorLinie.Name = "edtKreditorLinie";
            this.edtKreditorLinie.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKreditorLinie.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKreditorLinie.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKreditorLinie.Properties.Appearance.Options.UseBackColor = true;
            this.edtKreditorLinie.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKreditorLinie.Properties.Appearance.Options.UseFont = true;
            this.edtKreditorLinie.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKreditorLinie.Properties.ReadOnly = true;
            this.edtKreditorLinie.Size = new System.Drawing.Size(323, 24);
            this.edtKreditorLinie.TabIndex = 401;
            // 
            // edtEinzahlungsscheinCode
            // 
            this.edtEinzahlungsscheinCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtEinzahlungsscheinCode.DataMember = "EinzahlungsscheinCode";
            this.edtEinzahlungsscheinCode.DataSource = this.qryBuchung;
            this.edtEinzahlungsscheinCode.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtEinzahlungsscheinCode.Location = new System.Drawing.Point(586, 408);
            this.edtEinzahlungsscheinCode.LOVName = "BgEinzahlungsschein";
            this.edtEinzahlungsscheinCode.Name = "edtEinzahlungsscheinCode";
            this.edtEinzahlungsscheinCode.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtEinzahlungsscheinCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinzahlungsscheinCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinzahlungsscheinCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinzahlungsscheinCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinzahlungsscheinCode.Properties.Appearance.Options.UseFont = true;
            this.edtEinzahlungsscheinCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtEinzahlungsscheinCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinzahlungsscheinCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtEinzahlungsscheinCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtEinzahlungsscheinCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtEinzahlungsscheinCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtEinzahlungsscheinCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEinzahlungsscheinCode.Properties.NullText = "";
            this.edtEinzahlungsscheinCode.Properties.ReadOnly = true;
            this.edtEinzahlungsscheinCode.Properties.ShowFooter = false;
            this.edtEinzahlungsscheinCode.Properties.ShowHeader = false;
            this.edtEinzahlungsscheinCode.Size = new System.Drawing.Size(323, 24);
            this.edtEinzahlungsscheinCode.TabIndex = 400;
            // 
            // edtErstelltDatum
            // 
            this.edtErstelltDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtErstelltDatum.DataMember = "ErstelltDatum";
            this.edtErstelltDatum.DataSource = this.qryBuchung;
            this.edtErstelltDatum.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtErstelltDatum.EditValue = null;
            this.edtErstelltDatum.Location = new System.Drawing.Point(154, 438);
            this.edtErstelltDatum.Name = "edtErstelltDatum";
            this.edtErstelltDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtErstelltDatum.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtErstelltDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErstelltDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErstelltDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtErstelltDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErstelltDatum.Properties.Appearance.Options.UseFont = true;
            this.edtErstelltDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtErstelltDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtErstelltDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtErstelltDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtErstelltDatum.Properties.ReadOnly = true;
            this.edtErstelltDatum.Properties.ShowToday = false;
            this.edtErstelltDatum.Size = new System.Drawing.Size(100, 24);
            this.edtErstelltDatum.TabIndex = 399;
            // 
            // edtBuchungstext
            // 
            this.edtBuchungstext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBuchungstext.DataMember = "Text";
            this.edtBuchungstext.DataSource = this.qryBuchung;
            this.edtBuchungstext.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBuchungstext.Location = new System.Drawing.Point(154, 408);
            this.edtBuchungstext.Name = "edtBuchungstext";
            this.edtBuchungstext.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBuchungstext.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBuchungstext.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchungstext.Properties.Appearance.Options.UseBackColor = true;
            this.edtBuchungstext.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBuchungstext.Properties.Appearance.Options.UseFont = true;
            this.edtBuchungstext.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBuchungstext.Properties.ReadOnly = true;
            this.edtBuchungstext.Size = new System.Drawing.Size(289, 24);
            this.edtBuchungstext.TabIndex = 398;
            // 
            // CtlKbZahlungslauf
            // 
            this.ActiveSQLQuery = this.qryBuchung;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(917, 569);
            this.Controls.Add(this.edtFehlermeldung);
            this.Controls.Add(this.lblEinzahlungsscheinCode);
            this.Controls.Add(this.lblBaZahlungswegID);
            this.Controls.Add(this.lblErfassungDatum);
            this.Controls.Add(this.kissLabel8);
            this.Controls.Add(this.lblBuchungstext);
            this.Controls.Add(this.edtKreditorLinie);
            this.Controls.Add(this.edtEinzahlungsscheinCode);
            this.Controls.Add(this.edtErstelltDatum);
            this.Controls.Add(this.edtBuchungstext);
            this.Controls.Add(this.lblFaelligkeitsdatum);
            this.Controls.Add(this.edtFaelligkeitsdatum);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnMonatsbudget);
            this.Controls.Add(this.btnKeine);
            this.Controls.Add(this.btnAlle);
            this.Controls.Add(this.btnTransfer);
            this.Name = "CtlKbZahlungslauf";
            this.Size = new System.Drawing.Size(922, 569);
            this.Load += new System.EventHandler(this.CtlKbZahlungslauf_Load);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.btnTransfer, 0);
            this.Controls.SetChildIndex(this.btnAlle, 0);
            this.Controls.SetChildIndex(this.btnKeine, 0);
            this.Controls.SetChildIndex(this.btnMonatsbudget, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.edtFaelligkeitsdatum, 0);
            this.Controls.SetChildIndex(this.lblFaelligkeitsdatum, 0);
            this.Controls.SetChildIndex(this.edtBuchungstext, 0);
            this.Controls.SetChildIndex(this.edtErstelltDatum, 0);
            this.Controls.SetChildIndex(this.edtEinzahlungsscheinCode, 0);
            this.Controls.SetChildIndex(this.edtKreditorLinie, 0);
            this.Controls.SetChildIndex(this.lblBuchungstext, 0);
            this.Controls.SetChildIndex(this.kissLabel8, 0);
            this.Controls.SetChildIndex(this.lblErfassungDatum, 0);
            this.Controls.SetChildIndex(this.lblBaZahlungswegID, 0);
            this.Controls.SetChildIndex(this.lblEinzahlungsscheinCode, 0);
            this.Controls.SetChildIndex(this.edtFehlermeldung, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qryBuchung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZahllauf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZahllauf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheValutaBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPeriodeID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGruppeX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGruppeX)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnzahl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKbZahlungskonto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKbZahlungskonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaelligkeitsdatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaelligkeitsdatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryAktivKonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryGruppe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZahlungskonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFehlermeldung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinzahlungsscheinCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaZahlungswegID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungstext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditorLinie.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinzahlungsscheinCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinzahlungsscheinCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErstelltDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungstext.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #region Dispose

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

        #endregion

    }
}