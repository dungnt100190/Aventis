using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Messages;

namespace KiSS4.Query
{
    public class CtlQueryStatShFallzahlenTotal : KiSS4.Common.KissQueryControl
    {
        #region Fields

        private DevExpress.XtraGrid.Columns.GridColumn colAlter;
        private DevExpress.XtraGrid.Columns.GridColumn colAlterTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colAnzPersHaushalt;
        private DevExpress.XtraGrid.Columns.GridColumn colAnzPersUnterst;
        private DevExpress.XtraGrid.Columns.GridColumn colAnzahlFP;
        private DevExpress.XtraGrid.Columns.GridColumn colAnzahlUE;
        private DevExpress.XtraGrid.Columns.GridColumn colArchiviertAm;
        private DevExpress.XtraGrid.Columns.GridColumn colFall;
        private DevExpress.XtraGrid.Columns.GridColumn colFallNr;
        private DevExpress.XtraGrid.Columns.GridColumn colFalltrger;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGeffnet;
        private DevExpress.XtraGrid.Columns.GridColumn colGeschlecht;
        private DevExpress.XtraGrid.Columns.GridColumn colGeschlossen;
        private DevExpress.XtraGrid.Columns.GridColumn colHeimatort;
        private DevExpress.XtraGrid.Columns.GridColumn colHeimatortKanton;
        private DevExpress.XtraGrid.Columns.GridColumn colKanton;
        private DevExpress.XtraGrid.Columns.GridColumn colModul;
        private DevExpress.XtraGrid.Columns.GridColumn colNationalitt;
        private DevExpress.XtraGrid.Columns.GridColumn colOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colPLZ;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colSARKrzel;
        private DevExpress.XtraGrid.Columns.GridColumn colSARName;
        private DevExpress.XtraGrid.Columns.GridColumn colSARSektion;
        private DevExpress.XtraGrid.Columns.GridColumn colStrasse;
        private DevExpress.XtraGrid.Columns.GridColumn colStrasseNr;
        private DevExpress.XtraGrid.Columns.GridColumn colZivilstand;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissTextEdit edtJahr;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KissDateEdit edtDatumVon;
        private KissLabel lblbis;
        private KissLabel lblZeitraumvon;
        private KissDateEdit edtDatumBis;
        private KissLabel lblGemeinde;
        private KissLookUpEdit edtGemeindeCode;
        private SharpLibrary.WinControls.TabPageEx tpgListe2;
        private KissGrid grdListe2;
        private DevExpress.XtraGrid.Views.Grid.GridView grvListe2;
        private SqlQuery qryListe2;
        private KiSS4.Gui.KissLabel lblAuswertungsjahr;

        #endregion

        #region Constructors

        public CtlQueryStatShFallzahlenTotal()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryStatShFallzahlenTotal));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblAuswertungsjahr = new KiSS4.Gui.KissLabel();
            this.edtJahr = new KiSS4.Gui.KissTextEdit();
            this.colAlter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlterTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnzahlFP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnzahlUE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnzPersHaushalt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnzPersUnterst = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArchiviertAm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFall = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFallNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFalltrger = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeffnet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeschlecht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeschlossen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHeimatort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHeimatortKanton = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKanton = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModul = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNationalitt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPLZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSARKrzel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSARName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSARSektion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrasse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrasseNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZivilstand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.lblbis = new KiSS4.Gui.KissLabel();
            this.lblZeitraumvon = new KiSS4.Gui.KissLabel();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtGemeindeCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblGemeinde = new KiSS4.Gui.KissLabel();
            this.tpgListe2 = new SharpLibrary.WinControls.TabPageEx();
            this.grdListe2 = new KiSS4.Gui.KissGrid();
            this.qryListe2 = new KiSS4.DB.SqlQuery(this.components);
            this.grvListe2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuswertungsjahr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtJahr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitraumvon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGemeindeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGemeindeCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGemeinde)).BeginInit();
            this.tpgListe2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdListe2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryListe2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvListe2)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
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
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.xDocument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("xDocument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "Dokument öffnen")});
            this.xDocument.Visible = false;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.Visible = false;
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Controls.Add(this.tpgListe2);
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgListe2});
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListe2, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgSuchen, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListe, 0);
            // 
            // tpgListe
            // 
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.lblGemeinde);
            this.tpgSuchen.Controls.Add(this.edtGemeindeCode);
            this.tpgSuchen.Controls.Add(this.edtDatumBis);
            this.tpgSuchen.Controls.Add(this.edtDatumVon);
            this.tpgSuchen.Controls.Add(this.lblbis);
            this.tpgSuchen.Controls.Add(this.lblZeitraumvon);
            this.tpgSuchen.Controls.Add(this.edtJahr);
            this.tpgSuchen.Controls.Add(this.lblAuswertungsjahr);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.TabIndex = 2;
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblAuswertungsjahr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtJahr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZeitraumvon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblbis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtGemeindeCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblGemeinde, 0);
            // 
            // lblAuswertungsjahr
            // 
            this.lblAuswertungsjahr.Location = new System.Drawing.Point(10, 66);
            this.lblAuswertungsjahr.Name = "lblAuswertungsjahr";
            this.lblAuswertungsjahr.Size = new System.Drawing.Size(130, 24);
            this.lblAuswertungsjahr.TabIndex = 5;
            this.lblAuswertungsjahr.Text = "Auswertungsjahr";
            this.lblAuswertungsjahr.UseCompatibleTextRendering = true;
            // 
            // edtJahr
            // 
            this.edtJahr.EditValue = "";
            this.edtJahr.Location = new System.Drawing.Point(150, 66);
            this.edtJahr.Name = "edtJahr";
            this.edtJahr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtJahr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtJahr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtJahr.Properties.Appearance.Options.UseBackColor = true;
            this.edtJahr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtJahr.Properties.Appearance.Options.UseFont = true;
            this.edtJahr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtJahr.Size = new System.Drawing.Size(60, 24);
            this.edtJahr.TabIndex = 6;
            // 
            // colAlter
            // 
            this.colAlter.Name = "colAlter";
            // 
            // colAlterTyp
            // 
            this.colAlterTyp.Name = "colAlterTyp";
            // 
            // colAnzahlFP
            // 
            this.colAnzahlFP.Name = "colAnzahlFP";
            // 
            // colAnzahlUE
            // 
            this.colAnzahlUE.Name = "colAnzahlUE";
            // 
            // colAnzPersHaushalt
            // 
            this.colAnzPersHaushalt.Name = "colAnzPersHaushalt";
            // 
            // colAnzPersUnterst
            // 
            this.colAnzPersUnterst.Name = "colAnzPersUnterst";
            // 
            // colArchiviertAm
            // 
            this.colArchiviertAm.Name = "colArchiviertAm";
            // 
            // colFall
            // 
            this.colFall.Name = "colFall";
            // 
            // colFallNr
            // 
            this.colFallNr.Name = "colFallNr";
            // 
            // colFalltrger
            // 
            this.colFalltrger.Name = "colFalltrger";
            // 
            // colGeburtsdatum
            // 
            this.colGeburtsdatum.Name = "colGeburtsdatum";
            // 
            // colGeffnet
            // 
            this.colGeffnet.Name = "colGeffnet";
            // 
            // colGeschlecht
            // 
            this.colGeschlecht.Name = "colGeschlecht";
            // 
            // colGeschlossen
            // 
            this.colGeschlossen.Name = "colGeschlossen";
            // 
            // colHeimatort
            // 
            this.colHeimatort.Name = "colHeimatort";
            // 
            // colHeimatortKanton
            // 
            this.colHeimatortKanton.Name = "colHeimatortKanton";
            // 
            // colKanton
            // 
            this.colKanton.Name = "colKanton";
            // 
            // colModul
            // 
            this.colModul.Name = "colModul";
            // 
            // colNationalitt
            // 
            this.colNationalitt.Name = "colNationalitt";
            // 
            // colOrt
            // 
            this.colOrt.Name = "colOrt";
            // 
            // colPerson
            // 
            this.colPerson.Name = "colPerson";
            // 
            // colPLZ
            // 
            this.colPLZ.Name = "colPLZ";
            // 
            // colSARKrzel
            // 
            this.colSARKrzel.Name = "colSARKrzel";
            // 
            // colSARName
            // 
            this.colSARName.Name = "colSARName";
            // 
            // colSARSektion
            // 
            this.colSARSektion.Name = "colSARSektion";
            // 
            // colStrasse
            // 
            this.colStrasse.Name = "colStrasse";
            // 
            // colStrasseNr
            // 
            this.colStrasseNr.Name = "colStrasseNr";
            // 
            // colZivilstand
            // 
            this.colZivilstand.Name = "colZivilstand";
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
            // edtDatumVon
            // 
            this.edtDatumVon.EditValue = "";
            this.edtDatumVon.Location = new System.Drawing.Point(150, 36);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(101, 24);
            this.edtDatumVon.TabIndex = 2;
            // 
            // lblbis
            // 
            this.lblbis.Location = new System.Drawing.Point(270, 36);
            this.lblbis.Name = "lblbis";
            this.lblbis.Size = new System.Drawing.Size(25, 24);
            this.lblbis.TabIndex = 3;
            this.lblbis.Text = "bis";
            this.lblbis.UseCompatibleTextRendering = true;
            // 
            // lblZeitraumvon
            // 
            this.lblZeitraumvon.Location = new System.Drawing.Point(10, 36);
            this.lblZeitraumvon.Name = "lblZeitraumvon";
            this.lblZeitraumvon.Size = new System.Drawing.Size(131, 24);
            this.lblZeitraumvon.TabIndex = 1;
            this.lblZeitraumvon.Text = "Zeitraum von";
            this.lblZeitraumvon.UseCompatibleTextRendering = true;
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.EditValue = "";
            this.edtDatumBis.Location = new System.Drawing.Point(301, 36);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBis.TabIndex = 4;
            // 
            // edtGemeindeCode
            // 
            this.edtGemeindeCode.Location = new System.Drawing.Point(150, 97);
            this.edtGemeindeCode.LOVName = "GemeindeSozialdienst";
            this.edtGemeindeCode.Name = "edtGemeindeCode";
            this.edtGemeindeCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGemeindeCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGemeindeCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGemeindeCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtGemeindeCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGemeindeCode.Properties.Appearance.Options.UseFont = true;
            this.edtGemeindeCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtGemeindeCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtGemeindeCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtGemeindeCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtGemeindeCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtGemeindeCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtGemeindeCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGemeindeCode.Properties.NullText = "";
            this.edtGemeindeCode.Properties.ShowFooter = false;
            this.edtGemeindeCode.Properties.ShowHeader = false;
            this.edtGemeindeCode.Size = new System.Drawing.Size(251, 24);
            this.edtGemeindeCode.TabIndex = 7;
            // 
            // lblGemeinde
            // 
            this.lblGemeinde.Location = new System.Drawing.Point(10, 97);
            this.lblGemeinde.Name = "lblGemeinde";
            this.lblGemeinde.Size = new System.Drawing.Size(130, 24);
            this.lblGemeinde.TabIndex = 8;
            this.lblGemeinde.Text = "Gemeinde";
            this.lblGemeinde.UseCompatibleTextRendering = true;
            // 
            // tpgListe2
            // 
            this.tpgListe2.Controls.Add(this.grdListe2);
            this.tpgListe2.Location = new System.Drawing.Point(6, 6);
            this.tpgListe2.Name = "tpgListe2";
            this.tpgListe2.Size = new System.Drawing.Size(772, 424);
            this.tpgListe2.TabIndex = 1;
            this.tpgListe2.Title = "Liste 2";
            // 
            // grdListe2
            // 
            this.grdListe2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdListe2.DataSource = this.qryListe2;
            this.grdListe2.EmbeddedNavigator.Name = "";
            this.grdListe2.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdListe2.Location = new System.Drawing.Point(3, 1);
            this.grdListe2.MainView = this.grvListe2;
            this.grdListe2.Name = "grdListe2";
            this.grdListe2.Size = new System.Drawing.Size(766, 391);
            this.grdListe2.TabIndex = 0;
            this.grdListe2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvListe2});
            // 
            // qryListe2
            // 
            this.qryListe2.FillTimeOut = 300;
            this.qryListe2.SelectStatement = resources.GetString("qryListe2.SelectStatement");
            // 
            // grvListe2
            // 
            this.grvListe2.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvListe2.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2.Appearance.Empty.Options.UseBackColor = true;
            this.grvListe2.Appearance.Empty.Options.UseFont = true;
            this.grvListe2.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2.Appearance.EvenRow.Options.UseFont = true;
            this.grvListe2.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvListe2.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvListe2.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvListe2.Appearance.FocusedCell.Options.UseFont = true;
            this.grvListe2.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvListe2.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvListe2.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvListe2.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvListe2.Appearance.FocusedRow.Options.UseFont = true;
            this.grvListe2.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvListe2.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvListe2.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvListe2.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvListe2.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvListe2.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvListe2.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvListe2.Appearance.GroupRow.Options.UseFont = true;
            this.grvListe2.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvListe2.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvListe2.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvListe2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvListe2.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvListe2.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvListe2.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvListe2.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvListe2.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvListe2.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvListe2.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvListe2.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvListe2.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvListe2.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvListe2.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2.Appearance.OddRow.Options.UseFont = true;
            this.grvListe2.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvListe2.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2.Appearance.Row.Options.UseBackColor = true;
            this.grvListe2.Appearance.Row.Options.UseFont = true;
            this.grvListe2.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2.Appearance.SelectedRow.Options.UseFont = true;
            this.grvListe2.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvListe2.Appearance.VertLine.Options.UseBackColor = true;
            this.grvListe2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvListe2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvListe2.GridControl = this.grdListe2;
            this.grvListe2.Name = "grvListe2";
            this.grvListe2.OptionsBehavior.Editable = false;
            this.grvListe2.OptionsCustomization.AllowFilter = false;
            this.grvListe2.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvListe2.OptionsNavigation.AutoFocusNewRow = true;
            this.grvListe2.OptionsNavigation.UseTabKey = false;
            this.grvListe2.OptionsView.ColumnAutoWidth = false;
            this.grvListe2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvListe2.OptionsView.ShowGroupPanel = false;
            this.grvListe2.OptionsView.ShowIndicator = false;
            // 
            // CtlQueryStatShFallzahlenTotal
            // 
            this.Name = "CtlQueryStatShFallzahlenTotal";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblAuswertungsjahr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtJahr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitraumvon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGemeindeCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGemeindeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGemeinde)).EndInit();
            this.tpgListe2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdListe2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryListe2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvListe2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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