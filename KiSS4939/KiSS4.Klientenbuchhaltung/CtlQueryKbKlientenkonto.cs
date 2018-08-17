using System.Data;

using KiSS4.Common;
using KiSS4.DB;
using Kiss.Interfaces.UI;
using KiSS4.Gui;
using System;


namespace KiSS4.Klientenbuchhaltung
{
    public class CtlQueryKbKlientenkonto : KissQueryControl
    {
        #region Fields

        private int _kbPeriodeID;
        private DateTime _PeriodeVon;
        private DateTime _PeriodeBis;
        private bool _gestartetAusKlientenBuchhaltung = true;

        private DevExpress.XtraGrid.Columns.GridColumn colAuszahlung;
        private DevExpress.XtraGrid.Columns.GridColumn colBelegDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colBelegNr;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungstext;
        private DevExpress.XtraGrid.Columns.GridColumn colEinnahme;
        private DevExpress.XtraGrid.Columns.GridColumn colKlient;
        private DevExpress.XtraGrid.Columns.GridColumn colKoA;
        private DevExpress.XtraGrid.Columns.GridColumn colSaldo;
        private KiSS4.Gui.KissDateEdit edtDatumBisX;
        private KiSS4.Gui.KissDateEdit edtDatumVonX;
        private KiSS4.Gui.KissButtonEdit edtKostenstelleX;
        private KiSS4.Gui.KissLabel lblDatumBisX;
        private KiSS4.Gui.KissLabel lblDatumVonX;
        private Gui.KissCheckEdit edtNeueSeite;
        private Gui.KissCheckEdit edtAlleKlienten;
        private KiSS4.Gui.KissLabel lblKostenstelleX;

        #endregion

        #region Constructors

        public CtlQueryKbKlientenkonto()
        {
            InitializeComponent();
        }

        #endregion
        /*
 * Zur Sicherheit wird hier der automatische erzeugte Code abgelegt,
 * weil beim neu Kompilieren die GridView automatisch rausfällt

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryKbKlientenkonto));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.edtKostenstelleX = new KiSS4.Gui.KissButtonEdit();
            this.edtDatumVonX = new KiSS4.Gui.KissDateEdit();
            this.edtDatumBisX = new KiSS4.Gui.KissDateEdit();
            this.lblKostenstelleX = new KiSS4.Gui.KissLabel();
            this.lblDatumVonX = new KiSS4.Gui.KissLabel();
            this.lblDatumBisX = new KiSS4.Gui.KissLabel();
            this.colAuszahlung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBelegDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBelegNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungstext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinnahme = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKlient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKoA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaldo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtAlleKlienten = new KiSS4.Gui.KissCheckEdit();
            this.edtNeueSeite = new KiSS4.Gui.KissCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenstelleX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVonX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBisX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenstelleX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVonX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBisX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAlleKlienten.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNeueSeite.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.AfterFill += new System.EventHandler(this.qryQuery_AfterFill);
            //
            // grdQuery1
            //
            this.grdQuery1.EmbeddedNavigator.Name = "";
            this.grdQuery1.MainView = this.grvQuery1;
            this.grdQuery1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                        this.grvQuery1});
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
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.xDocument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("xDocument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Dokument öffnen")});
            this.xDocument.Visible = false;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = "BaPersonID";
            this.ctlGotoFall.Location = new System.Drawing.Point(0, 398);
            this.ctlGotoFall.Size = new System.Drawing.Size(158, 26);
            this.ctlGotoFall.Visible = false;
            // 
            // tpgListe
            // 
            this.tpgListe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtNeueSeite);
            this.tpgSuchen.Controls.Add(this.edtAlleKlienten);
            this.tpgSuchen.Controls.Add(this.lblDatumBisX);
            this.tpgSuchen.Controls.Add(this.lblDatumVonX);
            this.tpgSuchen.Controls.Add(this.lblKostenstelleX);
            this.tpgSuchen.Controls.Add(this.edtDatumBisX);
            this.tpgSuchen.Controls.Add(this.edtDatumVonX);
            this.tpgSuchen.Controls.Add(this.edtKostenstelleX);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.TabIndex = 1;
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtKostenstelleX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumVonX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumBisX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblKostenstelleX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblDatumVonX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblDatumBisX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAlleKlienten, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNeueSeite, 0);
            // 
            // edtKostenstelleX
            // 
            this.edtKostenstelleX.Location = new System.Drawing.Point(131, 91);
            this.edtKostenstelleX.LookupSQL = "\r\n----\r\n";
            this.edtKostenstelleX.Name = "edtKostenstelleX";
            this.edtKostenstelleX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKostenstelleX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKostenstelleX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKostenstelleX.Properties.Appearance.Options.UseBackColor = true;
            this.edtKostenstelleX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKostenstelleX.Properties.Appearance.Options.UseFont = true;
            this.edtKostenstelleX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtKostenstelleX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtKostenstelleX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKostenstelleX.Size = new System.Drawing.Size(263, 24);
            this.edtKostenstelleX.TabIndex = 6;
            this.edtKostenstelleX.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtKostenstelleX_UserModifiedFld);
            // 
            // edtDatumVonX
            // 
            this.edtDatumVonX.EditValue = null;
            this.edtDatumVonX.Location = new System.Drawing.Point(131, 121);
            this.edtDatumVonX.Name = "edtDatumVonX";
            this.edtDatumVonX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVonX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVonX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVonX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVonX.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVonX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVonX.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVonX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtDatumVonX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVonX.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtDatumVonX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVonX.Properties.ShowToday = false;
            this.edtDatumVonX.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVonX.TabIndex = 7;
            // 
            // edtDatumBisX
            // 
            this.edtDatumBisX.EditValue = null;
            this.edtDatumBisX.Location = new System.Drawing.Point(294, 121);
            this.edtDatumBisX.Name = "edtDatumBisX";
            this.edtDatumBisX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBisX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBisX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBisX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBisX.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBisX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBisX.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBisX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtDatumBisX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBisX.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtDatumBisX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBisX.Properties.ShowToday = false;
            this.edtDatumBisX.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBisX.TabIndex = 8;
            // 
            // lblKostenstelleX
            // 
            this.lblKostenstelleX.Location = new System.Drawing.Point(4, 91);
            this.lblKostenstelleX.Name = "lblKostenstelleX";
            this.lblKostenstelleX.Size = new System.Drawing.Size(89, 24);
            this.lblKostenstelleX.TabIndex = 9;
            this.lblKostenstelleX.Text = "Klient";
            this.lblKostenstelleX.UseCompatibleTextRendering = true;
            // 
            // lblDatumVonX
            // 
            this.lblDatumVonX.Location = new System.Drawing.Point(4, 121);
            this.lblDatumVonX.Name = "lblDatumVonX";
            this.lblDatumVonX.Size = new System.Drawing.Size(91, 24);
            this.lblDatumVonX.TabIndex = 10;
            this.lblDatumVonX.Text = "Beleg Datum von";
            this.lblDatumVonX.UseCompatibleTextRendering = true;
            // 
            // lblDatumBisX
            // 
            this.lblDatumBisX.Location = new System.Drawing.Point(255, 121);
            this.lblDatumBisX.Name = "lblDatumBisX";
            this.lblDatumBisX.Size = new System.Drawing.Size(32, 24);
            this.lblDatumBisX.TabIndex = 11;
            this.lblDatumBisX.Text = "bis";
            this.lblDatumBisX.UseCompatibleTextRendering = true;
            // 
            // colAuszahlung
            // 
            this.colAuszahlung.Caption = "Auszahlung";
            this.colAuszahlung.DisplayFormat.FormatString = "N2";
            this.colAuszahlung.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAuszahlung.FieldName = "Ausgabe";
            this.colAuszahlung.Name = "colAuszahlung";
            this.colAuszahlung.Visible = true;
            this.colAuszahlung.VisibleIndex = 5;
            this.colAuszahlung.Width = 85;
            // 
            // colBelegDatum
            // 
            this.colBelegDatum.Caption = "Beleg-Datum";
            this.colBelegDatum.FieldName = "BelegDatum";
            this.colBelegDatum.Name = "colBelegDatum";
            this.colBelegDatum.Visible = true;
            this.colBelegDatum.VisibleIndex = 0;
            // 
            // colBelegNr
            // 
            this.colBelegNr.Caption = "Beleg-Nr.";
            this.colBelegNr.FieldName = "BelegNr";
            this.colBelegNr.Name = "colBelegNr";
            this.colBelegNr.Visible = true;
            this.colBelegNr.VisibleIndex = 1;
            // 
            // colBuchungstext
            // 
            this.colBuchungstext.Caption = "Buchungstext";
            this.colBuchungstext.FieldName = "Buchungstext";
            this.colBuchungstext.MinWidth = 20;
            this.colBuchungstext.Name = "colBuchungstext";
            this.colBuchungstext.Visible = true;
            this.colBuchungstext.VisibleIndex = 4;
            this.colBuchungstext.Width = 240;
            // 
            // colEinnahme
            // 
            this.colEinnahme.Caption = "Einnahme";
            this.colEinnahme.DisplayFormat.FormatString = "N2";
            this.colEinnahme.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colEinnahme.FieldName = "Einnahme";
            this.colEinnahme.Name = "colEinnahme";
            this.colEinnahme.Visible = true;
            this.colEinnahme.VisibleIndex = 6;
            // 
            // colKlient
            // 
            this.colKlient.Caption = "Klient";
            this.colKlient.FieldName = "Klient";
            this.colKlient.MinWidth = 20;
            this.colKlient.Name = "colKlient";
            this.colKlient.Visible = true;
            this.colKlient.VisibleIndex = 2;
            this.colKlient.Width = 160;
            // 
            // colKoA
            // 
            this.colKoA.Caption = "KoA";
            this.colKoA.FieldName = "LAText";
            this.colKoA.MinWidth = 20;
            this.colKoA.Name = "colKoA";
            this.colKoA.Visible = true;
            this.colKoA.VisibleIndex = 3;
            this.colKoA.Width = 120;
            // 
            // colSaldo
            // 
            this.colSaldo.Caption = "Saldovortrag";
            this.colSaldo.DisplayFormat.FormatString = "N2";
            this.colSaldo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSaldo.FieldName = "Saldo";
            this.colSaldo.Name = "colSaldo";
            this.colSaldo.Visible = true;
            this.colSaldo.VisibleIndex = 7;
            this.colSaldo.Width = 91;
            // 
            // edtAlleKlienten
            // 
            this.edtAlleKlienten.EditValue = true;
            this.edtAlleKlienten.Location = new System.Drawing.Point(131, 66);
            this.edtAlleKlienten.Name = "edtAlleKlienten";
            this.edtAlleKlienten.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtAlleKlienten.Properties.Appearance.Options.UseBackColor = true;
            this.edtAlleKlienten.Properties.Caption = "Alle Klienten";
            this.edtAlleKlienten.Size = new System.Drawing.Size(263, 19);
            this.edtAlleKlienten.TabIndex = 12;
            this.edtAlleKlienten.CheckedChanged += new System.EventHandler(this.edtAlleKlienten_CheckedChanged);
            // 
            // edtNeueSeite
            // 
            this.edtNeueSeite.EditValue = true;
            this.edtNeueSeite.Location = new System.Drawing.Point(131, 151);
            this.edtNeueSeite.Name = "edtNeueSeite";
            this.edtNeueSeite.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtNeueSeite.Properties.Appearance.Options.UseBackColor = true;
            this.edtNeueSeite.Properties.Caption = "Neue Seite";
            this.edtNeueSeite.Size = new System.Drawing.Size(263, 19);
            this.edtNeueSeite.TabIndex = 14;
            //
            // grvQuery1
            //
            this.grvQuery1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvQuery1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.Empty.Options.UseBackColor = true;
            this.grvQuery1.Appearance.Empty.Options.UseFont = true;
            this.grvQuery1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
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
            this.grvQuery1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvQuery1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery1.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvQuery1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.OddRow.Options.UseFont = true;
            this.grvQuery1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvQuery1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.Row.Options.UseBackColor = true;
            this.grvQuery1.Appearance.Row.Options.UseFont = true;
            this.grvQuery1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.SelectedRow.Options.UseFont = true;
            this.grvQuery1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery1.Appearance.VertLine.Options.UseBackColor = true;
            this.grvQuery1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvQuery1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                        this.colBelegDatum,
                        this.colBelegNr,
                        this.colKlient,
                        this.colKoA,
                        this.colBuchungstext,
                        this.colAuszahlung,
                        this.colEinnahme,
                        this.colSaldo});
            this.grvQuery1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvQuery1.GridControl = this.grdQuery1;
            this.grvQuery1.OptionsBehavior.Editable = false;
            this.grvQuery1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvQuery1.OptionsNavigation.AutoFocusNewRow = true;
            this.grvQuery1.OptionsNavigation.UseTabKey = false;
            this.grvQuery1.OptionsView.ColumnAutoWidth = false;
            this.grvQuery1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvQuery1.OptionsView.ShowGroupPanel = false;
            this.grvQuery1.OptionsView.ShowIndicator = false;
            // 
            // CtlQueryKbKlientenkonto
            // 
            this.Name = "CtlQueryKbKlientenkonto";
            this.StartNewSearchOnLoad = false;
            this.Load += new System.EventHandler(this.CtlQueryKbKlientenkonto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenstelleX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVonX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBisX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenstelleX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVonX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBisX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAlleKlienten.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNeueSeite.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


*/
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryKbKlientenkonto));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.edtKostenstelleX = new KiSS4.Gui.KissButtonEdit();
            this.edtDatumVonX = new KiSS4.Gui.KissDateEdit();
            this.edtDatumBisX = new KiSS4.Gui.KissDateEdit();
            this.lblKostenstelleX = new KiSS4.Gui.KissLabel();
            this.lblDatumVonX = new KiSS4.Gui.KissLabel();
            this.lblDatumBisX = new KiSS4.Gui.KissLabel();
            this.colAuszahlung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBelegDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBelegNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungstext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinnahme = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKlient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKoA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaldo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtAlleKlienten = new KiSS4.Gui.KissCheckEdit();
            this.edtNeueSeite = new KiSS4.Gui.KissCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenstelleX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVonX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBisX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenstelleX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVonX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBisX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAlleKlienten.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNeueSeite.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.AfterFill += new System.EventHandler(this.qryQuery_AfterFill);
            //
            // grdQuery1
            //
            this.grdQuery1.EmbeddedNavigator.Name = "";
            this.grdQuery1.MainView = this.grvQuery1;
            this.grdQuery1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                        this.grvQuery1});
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
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.xDocument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("xDocument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Dokument öffnen")});
            this.xDocument.Visible = false;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = "BaPersonID";
            this.ctlGotoFall.Location = new System.Drawing.Point(0, 398);
            this.ctlGotoFall.Size = new System.Drawing.Size(158, 26);
            this.ctlGotoFall.Visible = false;
            // 
            // tpgListe
            // 
            this.tpgListe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtNeueSeite);
            this.tpgSuchen.Controls.Add(this.edtAlleKlienten);
            this.tpgSuchen.Controls.Add(this.lblDatumBisX);
            this.tpgSuchen.Controls.Add(this.lblDatumVonX);
            this.tpgSuchen.Controls.Add(this.lblKostenstelleX);
            this.tpgSuchen.Controls.Add(this.edtDatumBisX);
            this.tpgSuchen.Controls.Add(this.edtDatumVonX);
            this.tpgSuchen.Controls.Add(this.edtKostenstelleX);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.TabIndex = 1;
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtKostenstelleX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumVonX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumBisX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblKostenstelleX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblDatumVonX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblDatumBisX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAlleKlienten, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNeueSeite, 0);
            // 
            // edtKostenstelleX
            // 
            this.edtKostenstelleX.Location = new System.Drawing.Point(131, 91);
            this.edtKostenstelleX.LookupSQL = "\r\n----\r\n";
            this.edtKostenstelleX.Name = "edtKostenstelleX";
            this.edtKostenstelleX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKostenstelleX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKostenstelleX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKostenstelleX.Properties.Appearance.Options.UseBackColor = true;
            this.edtKostenstelleX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKostenstelleX.Properties.Appearance.Options.UseFont = true;
            this.edtKostenstelleX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtKostenstelleX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtKostenstelleX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKostenstelleX.Size = new System.Drawing.Size(263, 24);
            this.edtKostenstelleX.TabIndex = 6;
            this.edtKostenstelleX.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtKostenstelleX_UserModifiedFld);
            // 
            // edtDatumVonX
            // 
            this.edtDatumVonX.EditValue = null;
            this.edtDatumVonX.Location = new System.Drawing.Point(131, 121);
            this.edtDatumVonX.Name = "edtDatumVonX";
            this.edtDatumVonX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVonX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVonX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVonX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVonX.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVonX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVonX.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVonX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtDatumVonX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVonX.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtDatumVonX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVonX.Properties.ShowToday = false;
            this.edtDatumVonX.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVonX.TabIndex = 7;
            // 
            // edtDatumBisX
            // 
            this.edtDatumBisX.EditValue = null;
            this.edtDatumBisX.Location = new System.Drawing.Point(294, 121);
            this.edtDatumBisX.Name = "edtDatumBisX";
            this.edtDatumBisX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBisX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBisX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBisX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBisX.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBisX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBisX.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBisX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtDatumBisX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBisX.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtDatumBisX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBisX.Properties.ShowToday = false;
            this.edtDatumBisX.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBisX.TabIndex = 8;
            // 
            // lblKostenstelleX
            // 
            this.lblKostenstelleX.Location = new System.Drawing.Point(4, 91);
            this.lblKostenstelleX.Name = "lblKostenstelleX";
            this.lblKostenstelleX.Size = new System.Drawing.Size(89, 24);
            this.lblKostenstelleX.TabIndex = 9;
            this.lblKostenstelleX.Text = "Klient";
            this.lblKostenstelleX.UseCompatibleTextRendering = true;
            // 
            // lblDatumVonX
            // 
            this.lblDatumVonX.Location = new System.Drawing.Point(4, 121);
            this.lblDatumVonX.Name = "lblDatumVonX";
            this.lblDatumVonX.Size = new System.Drawing.Size(91, 24);
            this.lblDatumVonX.TabIndex = 10;
            this.lblDatumVonX.Text = "Beleg Datum von";
            this.lblDatumVonX.UseCompatibleTextRendering = true;
            // 
            // lblDatumBisX
            // 
            this.lblDatumBisX.Location = new System.Drawing.Point(255, 121);
            this.lblDatumBisX.Name = "lblDatumBisX";
            this.lblDatumBisX.Size = new System.Drawing.Size(32, 24);
            this.lblDatumBisX.TabIndex = 11;
            this.lblDatumBisX.Text = "bis";
            this.lblDatumBisX.UseCompatibleTextRendering = true;
            // 
            // colAuszahlung
            // 
            this.colAuszahlung.Caption = "Auszahlung";
            this.colAuszahlung.DisplayFormat.FormatString = "N2";
            this.colAuszahlung.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAuszahlung.FieldName = "Ausgabe";
            this.colAuszahlung.Name = "colAuszahlung";
            this.colAuszahlung.Visible = true;
            this.colAuszahlung.VisibleIndex = 5;
            this.colAuszahlung.Width = 85;
            // 
            // colBelegDatum
            // 
            this.colBelegDatum.Caption = "Beleg-Datum";
            this.colBelegDatum.FieldName = "BelegDatum";
            this.colBelegDatum.Name = "colBelegDatum";
            this.colBelegDatum.Visible = true;
            this.colBelegDatum.VisibleIndex = 0;
            // 
            // colBelegNr
            // 
            this.colBelegNr.Caption = "Beleg-Nr.";
            this.colBelegNr.FieldName = "BelegNr";
            this.colBelegNr.Name = "colBelegNr";
            this.colBelegNr.Visible = true;
            this.colBelegNr.VisibleIndex = 1;
            // 
            // colBuchungstext
            // 
            this.colBuchungstext.Caption = "Buchungstext";
            this.colBuchungstext.FieldName = "Buchungstext";
            this.colBuchungstext.MinWidth = 20;
            this.colBuchungstext.Name = "colBuchungstext";
            this.colBuchungstext.Visible = true;
            this.colBuchungstext.VisibleIndex = 4;
            this.colBuchungstext.Width = 240;
            // 
            // colEinnahme
            // 
            this.colEinnahme.Caption = "Einnahme";
            this.colEinnahme.DisplayFormat.FormatString = "N2";
            this.colEinnahme.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colEinnahme.FieldName = "Einnahme";
            this.colEinnahme.Name = "colEinnahme";
            this.colEinnahme.Visible = true;
            this.colEinnahme.VisibleIndex = 6;
            // 
            // colKlient
            // 
            this.colKlient.Caption = "Klient";
            this.colKlient.FieldName = "Klient";
            this.colKlient.MinWidth = 20;
            this.colKlient.Name = "colKlient";
            this.colKlient.Visible = true;
            this.colKlient.VisibleIndex = 2;
            this.colKlient.Width = 160;
            // 
            // colKoA
            // 
            this.colKoA.Caption = "KoA";
            this.colKoA.FieldName = "LAText";
            this.colKoA.MinWidth = 20;
            this.colKoA.Name = "colKoA";
            this.colKoA.Visible = true;
            this.colKoA.VisibleIndex = 3;
            this.colKoA.Width = 120;
            // 
            // colSaldo
            // 
            this.colSaldo.Caption = "Saldovortrag";
            this.colSaldo.DisplayFormat.FormatString = "N2";
            this.colSaldo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSaldo.FieldName = "Saldo";
            this.colSaldo.Name = "colSaldo";
            this.colSaldo.Visible = true;
            this.colSaldo.VisibleIndex = 7;
            this.colSaldo.Width = 91;
            // 
            // edtAlleKlienten
            // 
            this.edtAlleKlienten.EditValue = true;
            this.edtAlleKlienten.Location = new System.Drawing.Point(131, 66);
            this.edtAlleKlienten.Name = "edtAlleKlienten";
            this.edtAlleKlienten.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtAlleKlienten.Properties.Appearance.Options.UseBackColor = true;
            this.edtAlleKlienten.Properties.Caption = "Alle Klienten";
            this.edtAlleKlienten.Size = new System.Drawing.Size(263, 19);
            this.edtAlleKlienten.TabIndex = 12;
            this.edtAlleKlienten.CheckedChanged += new System.EventHandler(this.edtAlleKlienten_CheckedChanged);
            // 
            // edtNeueSeite
            // 
            this.edtNeueSeite.EditValue = true;
            this.edtNeueSeite.Location = new System.Drawing.Point(131, 151);
            this.edtNeueSeite.Name = "edtNeueSeite";
            this.edtNeueSeite.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtNeueSeite.Properties.Appearance.Options.UseBackColor = true;
            this.edtNeueSeite.Properties.Caption = "Neue Seite";
            this.edtNeueSeite.Size = new System.Drawing.Size(263, 19);
            this.edtNeueSeite.TabIndex = 14;
            //
            // grvQuery1
            //
            this.grvQuery1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvQuery1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.Empty.Options.UseBackColor = true;
            this.grvQuery1.Appearance.Empty.Options.UseFont = true;
            this.grvQuery1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
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
            this.grvQuery1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvQuery1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery1.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvQuery1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.OddRow.Options.UseFont = true;
            this.grvQuery1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvQuery1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.Row.Options.UseBackColor = true;
            this.grvQuery1.Appearance.Row.Options.UseFont = true;
            this.grvQuery1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.SelectedRow.Options.UseFont = true;
            this.grvQuery1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery1.Appearance.VertLine.Options.UseBackColor = true;
            this.grvQuery1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvQuery1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                        this.colBelegDatum,
                        this.colBelegNr,
                        this.colKlient,
                        this.colKoA,
                        this.colBuchungstext,
                        this.colAuszahlung,
                        this.colEinnahme,
                        this.colSaldo});
            this.grvQuery1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvQuery1.GridControl = this.grdQuery1;
            this.grvQuery1.OptionsBehavior.Editable = false;
            this.grvQuery1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvQuery1.OptionsNavigation.AutoFocusNewRow = true;
            this.grvQuery1.OptionsNavigation.UseTabKey = false;
            this.grvQuery1.OptionsView.ColumnAutoWidth = false;
            this.grvQuery1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvQuery1.OptionsView.ShowGroupPanel = false;
            this.grvQuery1.OptionsView.ShowIndicator = false;
            // 
            // CtlQueryKbKlientenkonto
            // 
            this.Name = "CtlQueryKbKlientenkonto";
            this.StartNewSearchOnLoad = false;
            this.Load += new System.EventHandler(this.CtlQueryKbKlientenkonto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenstelleX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVonX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBisX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenstelleX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVonX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBisX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAlleKlienten.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNeueSeite.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region Protected Methods


        public override string GetContextName()
        {
            return "CtlQueryKbKlientenkonto";
        }

        public override object GetContextValue(string FieldName)
        {
            switch (FieldName.ToUpper())
            {
                case "PERSONID": return (edtAlleKlienten.Checked && _gestartetAusKlientenBuchhaltung) ? (int)0 : edtKostenstelleX.LookupID;
                case "DATUMVON": return DBUtil.IsEmpty(edtDatumVonX.EditValue) ? new DateTime(1900, 1, 1) : edtDatumVonX.EditValue;
                case "DATUMBIS": return DBUtil.IsEmpty(edtDatumBisX.EditValue) ? new DateTime(2900, 1, 1) : edtDatumBisX.EditValue;
                case "ALLEKLIENTEN": return _gestartetAusKlientenBuchhaltung ? edtAlleKlienten.EditValue : false;
                case "NEUESEITE": return edtNeueSeite.EditValue;
            }
            return base.GetContextValue(FieldName);
        }

        protected override void NewSearch()
        {
            if (_gestartetAusKlientenBuchhaltung)
            {
                edtAlleKlienten.Checked = true;
                edtNeueSeite.Checked = true;
            }
            else
            {
                edtAlleKlienten.Checked = false;
                edtNeueSeite.Checked = false;
            }
            edtAlleKlienten_CheckedChanged(null, null);
        }

        protected override void RunSearch()
        {
            // validate search
            try
            {
                if (!edtAlleKlienten.Checked)
                {
                    DBUtil.CheckNotNullField(edtKostenstelleX, lblKostenstelleX.Text);
                }
            }
            catch (KissInfoException iEx)
            {
                iEx.ShowMessage();
                edtKostenstelleX.Focus();
                throw new KissCancelException();
            }

            if (_gestartetAusKlientenBuchhaltung)
            {
                string msgText = KissMsg.GetMLMessage(
                    "CtlQueryKbKlientenkonto",
                    "CtlQueryKbKlientenkontoDatumEingabe",
                    "Wenn Sie alle Klienten anzeigen wollen, müssen Sie VON- und BIS-Datum innerhalb der Periode definieren."
                );
                if (edtAlleKlienten.Checked && (DBUtil.IsEmpty(edtDatumVonX.EditValue) || DBUtil.IsEmpty(edtDatumBisX.EditValue)))
                {
                    KissMsg.ShowInfo(msgText);
                    throw new KissCancelException();
                }

                if (edtAlleKlienten.Checked && (Utils.ConvertToDateTime(edtDatumVonX.EditValue) < _PeriodeVon ||
                                                Utils.ConvertToDateTime(edtDatumVonX.EditValue) > _PeriodeBis ||
                                                Utils.ConvertToDateTime(edtDatumBisX.EditValue) < _PeriodeVon ||
                                                Utils.ConvertToDateTime(edtDatumBisX.EditValue) > _PeriodeBis))
                {
                    KissMsg.ShowInfo(msgText);
                    throw new KissCancelException();
                }
            }

            qryQuery.Fill(
                "exec dbo.spWhKontoauszug {0}, {0}, 1, {1}, {2}, NULL, 0, 0, NULL, {3}, {4}",
                edtAlleKlienten.Checked ? 0 : edtKostenstelleX.LookupID,
                edtDatumVonX.EditValue,
                edtDatumBisX.EditValue,
                edtAlleKlienten.Checked,
                edtNeueSeite.Checked
            );
        }

        #endregion

        #region Private Methods

        private void edtKostenstelleX_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            var dlg = new Common.DlgAuswahl();

            e.Cancel = !dlg.KbKostenstelleSuchen(edtKostenstelleX.Text, e.ButtonClicked);

            if (!e.Cancel)
            {
                edtKostenstelleX.EditValue = dlg["Kostenstelle"];
                edtKostenstelleX.LookupID = dlg["BaPersonID"];
            }
        }

        private void grdQuery1_XtraPrint(object sender, KiSS4.Gui.XtraPrintEventArgs e)
        {
            string kst = edtAlleKlienten.Checked ? KissMsg.GetMLMessage("CtlQueryKbKlientenkonto", "AlleKlienten", "Alle Klienten") : edtKostenstelleX.Text;
            string footerTextLeft = kst + ", " + Utils.GetDateRangeText(edtDatumVonX.Text, edtDatumBisX.Text);
            grdQuery1.SetHeaderAndFooterText(
                e,
                KissMsg.GetMLMessage("CtlQueryKbKlientenkonto", "KbKlientenkonto", "Klientenkonto"),
                footerTextLeft
            );
        }

        private void qryQuery_AfterFill(object sender, System.EventArgs e)
        {
            var saldo = (decimal)0.0;
            int PersonID = -1;

            foreach (DataRow row in qryQuery.DataTable.Rows)
            {
                if (PersonID != Utils.ConvertToInt(row["BaPersonID"]))
                {
                    PersonID = Utils.ConvertToInt(row["BaPersonID"]);
                    saldo = (decimal)0.0;
                }
                saldo += Utils.ConvertToDecimal(row["Ausgabe"]) - Utils.ConvertToDecimal(row["Einnahme"]);
                row["Saldo"] = saldo;
            }

            qryQuery.DataTable.AcceptChanges();
            qryQuery.RowModified = false;
        }

        #endregion

        private void CtlQueryKbKlientenkonto_Load(object sender, EventArgs e)
        {

            grdQuery1.XtraPrint += new KiSS4.Gui.XtraPrintEventHandler(grdQuery1_XtraPrint);

            // Wenn das Control aus der KlientenBuchhaltung gestartet wurde,
            // dann darf die Option "Alle Klienten" aktiv sein, sonst nicht
            _gestartetAusKlientenBuchhaltung = false;
            var parent = Parent;
            CtlKbKlientenbuchhaltung parentKlibu = null;
            while (parent != null && parentKlibu == null)
            {
                parentKlibu = parent as CtlKbKlientenbuchhaltung;
                parent = parent.Parent;
            }

            if (parentKlibu != null)
            {
                _gestartetAusKlientenBuchhaltung = true;
            }

            if (_gestartetAusKlientenBuchhaltung)
            {
                _kbPeriodeID = (int)FormController.GetMessage(typeof(FrmKbKlientenbuchhaltung).Name, false, "Action", "KbPeriodeID");
                SqlQuery qryPeriode = DBUtil.OpenSQL(
                    "select PeriodeVon, PeriodeBis from KbPeriode where KbPeriodeID = {0}",
                    _kbPeriodeID
                );
                _PeriodeVon = Utils.ConvertToDateTime(qryPeriode["PeriodeVon"]);
                _PeriodeBis = Utils.ConvertToDateTime(qryPeriode["PeriodeBis"]);

                edtAlleKlienten.Checked = true;
                edtNeueSeite.Checked = true;
            }
            else
            {
                edtAlleKlienten.Checked = false;
                edtAlleKlienten.Visible = false;
                edtNeueSeite.Checked = false;
                edtNeueSeite.Visible = false;
            }

            edtAlleKlienten_CheckedChanged(null, null);

            tabControlSearch.SelectedTabIndex = tpgSuchen.TabIndex;
        }

        private void edtAlleKlienten_CheckedChanged(object sender, EventArgs e)
        {
            edtKostenstelleX.EditMode = !edtAlleKlienten.Checked ? EditModeType.Normal : EditModeType.ReadOnly;
            if (edtAlleKlienten.Checked)
            {
                edtKostenstelleX.EditValue = null;
            }
        }

        public override void OnPrint()
        {
            if ((!_gestartetAusKlientenBuchhaltung && DBUtil.IsEmpty(edtKostenstelleX.LookupID)) ||
                (_gestartetAusKlientenBuchhaltung && !edtAlleKlienten.Checked && DBUtil.IsEmpty(edtKostenstelleX.LookupID))
            )
            {
                KissMsg.ShowInfo("CtlQueryKbKlientenkonto", "ZuerstKlientWaehlen", "Wählen Sie zuerst einen Klienten aus.");
                return;
            }

            if (_gestartetAusKlientenBuchhaltung && edtAlleKlienten.Checked && (
                DBUtil.IsEmpty(edtDatumVonX.EditValue) || DBUtil.IsEmpty(edtDatumBisX.EditValue)
                )
            )
            {
                KissMsg.ShowInfo("CtlQueryKbKlientenkonto", "ZuerstDatumWaehlen", "Wählen Sie zuerst ein VON-Datum und ein BIS-Datum.");
                return;
            }

            base.OnPrint();
        }
    }
}