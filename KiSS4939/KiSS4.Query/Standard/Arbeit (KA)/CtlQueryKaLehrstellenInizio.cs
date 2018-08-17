using System;
using System.ComponentModel;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query
{
    public class CtlQueryKaLehrstellenInizio : KiSS4.Common.KissQueryControl
    {
        #region Fields

        private DevExpress.XtraGrid.Columns.GridColumn colAbbruchdurch;
        private DevExpress.XtraGrid.Columns.GridColumn colAktiv;
        private DevExpress.XtraGrid.Columns.GridColumn colAlter;
        private DevExpress.XtraGrid.Columns.GridColumn colAnschlusslsung;
        private DevExpress.XtraGrid.Columns.GridColumn colAusbildungbis;
        private DevExpress.XtraGrid.Columns.GridColumn colAusbildungvon;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrieb;
        private DevExpress.XtraGrid.Columns.GridColumn colBezeichnungEinsatzplatz;
        private DevExpress.XtraGrid.Columns.GridColumn colBranche;
        private DevExpress.XtraGrid.Columns.GridColumn colCharakter;
        private DevExpress.XtraGrid.Columns.GridColumn colErfasstam;
        private DevExpress.XtraGrid.Columns.GridColumn colGeschlecht;
        private DevExpress.XtraGrid.Columns.GridColumn colLehrberuf;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colNationalitt;
        private DevExpress.XtraGrid.Columns.GridColumn colOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colPLZ;
        private DevExpress.XtraGrid.Columns.GridColumn colSchulbildung;
        private DevExpress.XtraGrid.Columns.GridColumn colStellenbeschrieb;
        private DevExpress.XtraGrid.Columns.GridColumn colTypAusbildung;
        private DevExpress.XtraGrid.Columns.GridColumn colVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colinAusbildungsverbund;
        private DevExpress.XtraGrid.Columns.GridColumn colneugeschaffen;
        private KiSS4.Gui.KissDateEdit edtZeitraumBis;
        private KiSS4.Gui.KissDateEdit edtZeitraumVon;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissLabel lblZeitraumBis;
        private SharpLibrary.WinControls.TabPageEx tpgBegAusbildung;
        private SqlQuery qryBegAusbildung;
        private IContainer components;
        private CtlGotoFall ctlGotoFallBegAusb;
        private KissGrid grdBegAusbildung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBegAusbildung;
        private KiSS4.Gui.KissLabel lblZeitraumVon;

        #endregion

        #region Constructors

        public CtlQueryKaLehrstellenInizio()
        {
            this.InitializeComponent();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryKaLehrstellenInizio));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.edtZeitraumVon = new KiSS4.Gui.KissDateEdit();
            this.edtZeitraumBis = new KiSS4.Gui.KissDateEdit();
            this.lblZeitraumVon = new KiSS4.Gui.KissLabel();
            this.lblZeitraumBis = new KiSS4.Gui.KissLabel();
            this.colAbbruchdurch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAktiv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnschlusslsung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAusbildungbis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAusbildungvon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrieb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBezeichnungEinsatzplatz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBranche = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCharakter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErfasstam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeschlecht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colinAusbildungsverbund = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLehrberuf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNationalitt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colneugeschaffen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPLZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchulbildung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStellenbeschrieb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTypAusbildung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tpgBegAusbildung = new SharpLibrary.WinControls.TabPageEx();
            this.ctlGotoFallBegAusb = new KiSS4.Common.CtlGotoFall();
            this.grdBegAusbildung = new KiSS4.Gui.KissGrid();
            this.qryBegAusbildung = new KiSS4.DB.SqlQuery(this.components);
            this.grvBegAusbildung = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtZeitraumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZeitraumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitraumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitraumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.tpgBegAusbildung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBegAusbildung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBegAusbildung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBegAusbildung)).BeginInit();
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
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.xDocument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("xDocument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Dokument öffnen")});
            this.xDocument.Visible = false;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = null;
            this.ctlGotoFall.Visible = false;
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Controls.Add(this.tpgBegAusbildung);
            this.tabControlSearch.SelectedTabIndex = 2;
            this.tabControlSearch.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgBegAusbildung});
            this.tabControlSearch.Controls.SetChildIndex(this.tpgSuchen, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgBegAusbildung, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListe, 0);
            // 
            // tpgListe
            // 
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Title = "Erfassung Einsatzplatz";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.lblZeitraumBis);
            this.tpgSuchen.Controls.Add(this.lblZeitraumVon);
            this.tpgSuchen.Controls.Add(this.edtZeitraumBis);
            this.tpgSuchen.Controls.Add(this.edtZeitraumVon);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.TabIndex = 2;
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtZeitraumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtZeitraumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZeitraumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZeitraumBis, 0);
            // 
            // edtZeitraumVon
            // 
            this.edtZeitraumVon.EditValue = "";
            this.edtZeitraumVon.Location = new System.Drawing.Point(106, 49);
            this.edtZeitraumVon.Name = "edtZeitraumVon";
            this.edtZeitraumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtZeitraumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZeitraumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZeitraumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZeitraumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtZeitraumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZeitraumVon.Properties.Appearance.Options.UseFont = true;
            this.edtZeitraumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtZeitraumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtZeitraumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtZeitraumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZeitraumVon.Properties.ShowToday = false;
            this.edtZeitraumVon.Size = new System.Drawing.Size(100, 24);
            this.edtZeitraumVon.TabIndex = 13;
            // 
            // edtZeitraumBis
            // 
            this.edtZeitraumBis.EditValue = "";
            this.edtZeitraumBis.Location = new System.Drawing.Point(256, 49);
            this.edtZeitraumBis.Name = "edtZeitraumBis";
            this.edtZeitraumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtZeitraumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZeitraumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZeitraumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZeitraumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtZeitraumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZeitraumBis.Properties.Appearance.Options.UseFont = true;
            this.edtZeitraumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtZeitraumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtZeitraumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtZeitraumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZeitraumBis.Properties.ShowToday = false;
            this.edtZeitraumBis.Size = new System.Drawing.Size(100, 24);
            this.edtZeitraumBis.TabIndex = 14;
            // 
            // lblZeitraumVon
            // 
            this.lblZeitraumVon.Location = new System.Drawing.Point(12, 49);
            this.lblZeitraumVon.Name = "lblZeitraumVon";
            this.lblZeitraumVon.Size = new System.Drawing.Size(88, 24);
            this.lblZeitraumVon.TabIndex = 15;
            this.lblZeitraumVon.Text = "Zeitraum von";
            this.lblZeitraumVon.UseCompatibleTextRendering = true;
            // 
            // lblZeitraumBis
            // 
            this.lblZeitraumBis.Location = new System.Drawing.Point(221, 49);
            this.lblZeitraumBis.Name = "lblZeitraumBis";
            this.lblZeitraumBis.Size = new System.Drawing.Size(29, 24);
            this.lblZeitraumBis.TabIndex = 16;
            this.lblZeitraumBis.Text = "bis";
            this.lblZeitraumBis.UseCompatibleTextRendering = true;
            // 
            // colAbbruchdurch
            // 
            this.colAbbruchdurch.Name = "colAbbruchdurch";
            // 
            // colAktiv
            // 
            this.colAktiv.Name = "colAktiv";
            // 
            // colAlter
            // 
            this.colAlter.Name = "colAlter";
            // 
            // colAnschlusslsung
            // 
            this.colAnschlusslsung.Name = "colAnschlusslsung";
            // 
            // colAusbildungbis
            // 
            this.colAusbildungbis.Name = "colAusbildungbis";
            // 
            // colAusbildungvon
            // 
            this.colAusbildungvon.Name = "colAusbildungvon";
            // 
            // colBetrieb
            // 
            this.colBetrieb.Name = "colBetrieb";
            // 
            // colBezeichnungEinsatzplatz
            // 
            this.colBezeichnungEinsatzplatz.Name = "colBezeichnungEinsatzplatz";
            // 
            // colBranche
            // 
            this.colBranche.Name = "colBranche";
            // 
            // colCharakter
            // 
            this.colCharakter.Name = "colCharakter";
            // 
            // colErfasstam
            // 
            this.colErfasstam.Name = "colErfasstam";
            // 
            // colGeschlecht
            // 
            this.colGeschlecht.Name = "colGeschlecht";
            // 
            // colinAusbildungsverbund
            // 
            this.colinAusbildungsverbund.Name = "colinAusbildungsverbund";
            // 
            // colLehrberuf
            // 
            this.colLehrberuf.Name = "colLehrberuf";
            // 
            // colName
            // 
            this.colName.Name = "colName";
            // 
            // colNationalitt
            // 
            this.colNationalitt.Name = "colNationalitt";
            // 
            // colneugeschaffen
            // 
            this.colneugeschaffen.Name = "colneugeschaffen";
            // 
            // colOrt
            // 
            this.colOrt.Name = "colOrt";
            // 
            // colPLZ
            // 
            this.colPLZ.Name = "colPLZ";
            // 
            // colSchulbildung
            // 
            this.colSchulbildung.Name = "colSchulbildung";
            // 
            // colStellenbeschrieb
            // 
            this.colStellenbeschrieb.Name = "colStellenbeschrieb";
            // 
            // colTypAusbildung
            // 
            this.colTypAusbildung.Name = "colTypAusbildung";
            // 
            // colVorname
            // 
            this.colVorname.Name = "colVorname";
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.Empty.Options.UseFont = true;
            this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
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
            this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.OddRow.Options.UseFont = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.grdQuery1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.UseTabKey = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // tpgBegAusbildung
            // 
            this.tpgBegAusbildung.Controls.Add(this.ctlGotoFallBegAusb);
            this.tpgBegAusbildung.Controls.Add(this.grdBegAusbildung);
            this.tpgBegAusbildung.Location = new System.Drawing.Point(6, 6);
            this.tpgBegAusbildung.Name = "tpgBegAusbildung";
            this.tpgBegAusbildung.Size = new System.Drawing.Size(772, 424);
            this.tpgBegAusbildung.TabIndex = 1;
            this.tpgBegAusbildung.Title = "Beginn Ausbildung";
            // 
            // ctlGotoFallBegAusb
            // 
            this.ctlGotoFallBegAusb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctlGotoFallBegAusb.BaPersonID = ((object)(resources.GetObject("ctlGotoFallBegAusb.BaPersonID")));
            this.ctlGotoFallBegAusb.DataMember = "BaPersonID$";
            this.ctlGotoFallBegAusb.Location = new System.Drawing.Point(3, 399);
            this.ctlGotoFallBegAusb.Name = "ctlGotoFallBegAusb";
            this.ctlGotoFallBegAusb.Size = new System.Drawing.Size(154, 24);
            this.ctlGotoFallBegAusb.TabIndex = 7;
            this.ctlGotoFallBegAusb.Visible = false;
            // 
            // grdBegAusbildung
            // 
            this.grdBegAusbildung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdBegAusbildung.ColumnFilterActivated = true;
            this.grdBegAusbildung.DataSource = this.qryBegAusbildung;
            this.grdBegAusbildung.EmbeddedNavigator.Name = "";
            this.grdBegAusbildung.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBegAusbildung.Location = new System.Drawing.Point(3, 1);
            this.grdBegAusbildung.MainView = this.grvBegAusbildung;
            this.grdBegAusbildung.Name = "grdBegAusbildung";
            this.grdBegAusbildung.Size = new System.Drawing.Size(766, 392);
            this.grdBegAusbildung.TabIndex = 6;
            this.grdBegAusbildung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBegAusbildung});
            // 
            // qryBegAusbildung
            // 
            this.qryBegAusbildung.SelectStatement = resources.GetString("qryBegAusbildung.SelectStatement");
            // 
            // grvBegAusbildung
            // 
            this.grvBegAusbildung.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBegAusbildung.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBegAusbildung.Appearance.Empty.Options.UseBackColor = true;
            this.grvBegAusbildung.Appearance.Empty.Options.UseFont = true;
            this.grvBegAusbildung.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBegAusbildung.Appearance.EvenRow.Options.UseFont = true;
            this.grvBegAusbildung.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBegAusbildung.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBegAusbildung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBegAusbildung.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBegAusbildung.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBegAusbildung.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBegAusbildung.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBegAusbildung.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBegAusbildung.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBegAusbildung.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBegAusbildung.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBegAusbildung.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBegAusbildung.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBegAusbildung.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBegAusbildung.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBegAusbildung.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBegAusbildung.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBegAusbildung.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBegAusbildung.Appearance.GroupRow.Options.UseFont = true;
            this.grvBegAusbildung.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBegAusbildung.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBegAusbildung.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBegAusbildung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBegAusbildung.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBegAusbildung.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBegAusbildung.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBegAusbildung.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBegAusbildung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBegAusbildung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBegAusbildung.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBegAusbildung.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBegAusbildung.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBegAusbildung.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBegAusbildung.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBegAusbildung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBegAusbildung.Appearance.OddRow.Options.UseFont = true;
            this.grvBegAusbildung.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBegAusbildung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBegAusbildung.Appearance.Row.Options.UseBackColor = true;
            this.grvBegAusbildung.Appearance.Row.Options.UseFont = true;
            this.grvBegAusbildung.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBegAusbildung.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBegAusbildung.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBegAusbildung.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBegAusbildung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBegAusbildung.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBegAusbildung.GridControl = this.grdBegAusbildung;
            this.grvBegAusbildung.Name = "grvBegAusbildung";
            this.grvBegAusbildung.OptionsBehavior.Editable = false;
            this.grvBegAusbildung.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBegAusbildung.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBegAusbildung.OptionsNavigation.UseTabKey = false;
            this.grvBegAusbildung.OptionsView.ColumnAutoWidth = false;
            this.grvBegAusbildung.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBegAusbildung.OptionsView.ShowGroupPanel = false;
            this.grvBegAusbildung.OptionsView.ShowIndicator = false;
            // 
            // CtlQueryKaLehrstellenInizio
            // 
            this.Name = "CtlQueryKaLehrstellenInizio";
            this.Load += new System.EventHandler(this.CtlQueryKaLehrstellenInizio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtZeitraumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZeitraumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitraumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitraumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.tpgBegAusbildung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBegAusbildung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBegAusbildung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBegAusbildung)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private void CtlQueryKaLehrstellenInizio_Load(object sender, EventArgs e)
        {
            tpgListe.Title = "Erfassung Einsatzplatz";
        }
    }
}