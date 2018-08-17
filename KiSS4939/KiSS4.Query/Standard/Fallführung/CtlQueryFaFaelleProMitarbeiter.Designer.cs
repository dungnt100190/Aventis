using System;

namespace KiSS4.Query
{
    partial class CtlQueryFaFaelleProMitarbeiter
    {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryFaFaelleProMitarbeiter));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblSAR = new KiSS4.Gui.KissLabel();
            this.lblKlientIn = new KiSS4.Gui.KissLabel();
            this.lblModul = new KiSS4.Gui.KissLabel();
            this.edtUserID = new KiSS4.Common.KissMitarbeiterButtonEdit();
            this.edtKlient = new KiSS4.Gui.KissTextEdit();
            this.lblaktivzwischen = new KiSS4.Gui.KissLabel();
            this.edtModulID = new KiSS4.Gui.KissLookUpEdit();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtNurAktive = new KiSS4.Gui.KissCheckEdit();
            this.colAbgeschlossen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAHVNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErffnet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFallNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeschlecht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHeimatort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHeimatortKanton = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKanton = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModul = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNationalitt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPLZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrasse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrasseNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZivilstand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZusatz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZustndigeGemeinde = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblBfsLeistungsart = new KiSS4.Gui.KissLabel();
            this.edtBfsLeistungsart = new KiSS4.Gui.KissLookUpEdit();
            this.tpgListe2 = new SharpLibrary.WinControls.TabPageEx();
            this.grdQuery2 = new KiSS4.Gui.KissGrid();
            this.qryListe2 = new KiSS4.DB.SqlQuery();
            this.grvQuery2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModul)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlient.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblaktivzwischen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurAktive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBfsLeistungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBfsLeistungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBfsLeistungsart.Properties)).BeginInit();
            this.tpgListe2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryListe2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery2)).BeginInit();
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
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = "BaPersonID$";
            this.ctlGotoFall.Location = new System.Drawing.Point(0, 397);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Controls.Add(this.tpgListe2);
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgListe2});
            this.tabControlSearch.Controls.SetChildIndex(this.tpgSuchen, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListe2, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListe, 0);
            // 
            // tpgListe
            // 
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtBfsLeistungsart);
            this.tpgSuchen.Controls.Add(this.lblBfsLeistungsart);
            this.tpgSuchen.Controls.Add(this.edtNurAktive);
            this.tpgSuchen.Controls.Add(this.edtDatumBis);
            this.tpgSuchen.Controls.Add(this.edtDatumVon);
            this.tpgSuchen.Controls.Add(this.edtModulID);
            this.tpgSuchen.Controls.Add(this.lblaktivzwischen);
            this.tpgSuchen.Controls.Add(this.edtKlient);
            this.tpgSuchen.Controls.Add(this.edtUserID);
            this.tpgSuchen.Controls.Add(this.lblModul);
            this.tpgSuchen.Controls.Add(this.lblKlientIn);
            this.tpgSuchen.Controls.Add(this.lblSAR);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSAR, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblKlientIn, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblModul, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUserID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtKlient, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblaktivzwischen, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtModulID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNurAktive, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBfsLeistungsart, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBfsLeistungsart, 0);
            // 
            // lblSAR
            // 
            this.lblSAR.Location = new System.Drawing.Point(10, 40);
            this.lblSAR.Name = "lblSAR";
            this.lblSAR.Size = new System.Drawing.Size(130, 24);
            this.lblSAR.TabIndex = 1;
            this.lblSAR.Text = "SAR";
            this.lblSAR.UseCompatibleTextRendering = true;
            // 
            // lblKlientIn
            // 
            this.lblKlientIn.Location = new System.Drawing.Point(10, 70);
            this.lblKlientIn.Name = "lblKlientIn";
            this.lblKlientIn.Size = new System.Drawing.Size(130, 24);
            this.lblKlientIn.TabIndex = 3;
            this.lblKlientIn.Text = "KlientIn";
            this.lblKlientIn.UseCompatibleTextRendering = true;
            // 
            // lblModul
            // 
            this.lblModul.Location = new System.Drawing.Point(10, 100);
            this.lblModul.Name = "lblModul";
            this.lblModul.Size = new System.Drawing.Size(130, 24);
            this.lblModul.TabIndex = 5;
            this.lblModul.Text = "Modul";
            this.lblModul.UseCompatibleTextRendering = true;
            // 
            // edtUserID
            // 
            this.edtUserID.IsSearchField = true;
            this.edtUserID.Location = new System.Drawing.Point(150, 40);
            this.edtUserID.LookupSQL = "select ID = UserID, SAR = LastName + isNull(\', \' + FirstName,\'\'), \r\n[Kuerzel] = L" +
    "ogonName\r\nfrom   XUser \r\nwhere LastName + isNull(\', \' + FirstName,\'\') \r\nlike {0}" +
    " + \'%\' order by SAR\r\n----";
            this.edtUserID.Name = "edtUserID";
            this.edtUserID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUserID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserID.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserID.Properties.Appearance.Options.UseFont = true;
            this.edtUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtUserID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtUserID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUserID.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtUserID.Size = new System.Drawing.Size(225, 24);
            this.edtUserID.TabIndex = 2;
            // 
            // edtKlient
            // 
            this.edtKlient.Location = new System.Drawing.Point(150, 70);
            this.edtKlient.Name = "edtKlient";
            this.edtKlient.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKlient.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKlient.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKlient.Properties.Appearance.Options.UseBackColor = true;
            this.edtKlient.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKlient.Properties.Appearance.Options.UseFont = true;
            this.edtKlient.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKlient.Size = new System.Drawing.Size(225, 24);
            this.edtKlient.TabIndex = 4;
            // 
            // lblaktivzwischen
            // 
            this.lblaktivzwischen.Location = new System.Drawing.Point(10, 130);
            this.lblaktivzwischen.Name = "lblaktivzwischen";
            this.lblaktivzwischen.Size = new System.Drawing.Size(130, 24);
            this.lblaktivzwischen.TabIndex = 7;
            this.lblaktivzwischen.Text = "aktiv zwischen";
            this.lblaktivzwischen.UseCompatibleTextRendering = true;
            // 
            // edtModulID
            // 
            this.edtModulID.Location = new System.Drawing.Point(150, 100);
            this.edtModulID.LOVFilter = "ModulTree = 1 AND Licensed = 1 AND ModulID > 1 ";
            this.edtModulID.LOVFilterWhereAppend = true;
            this.edtModulID.LOVName = "Modul";
            this.edtModulID.Name = "edtModulID";
            this.edtModulID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtModulID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtModulID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtModulID.Properties.Appearance.Options.UseBackColor = true;
            this.edtModulID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtModulID.Properties.Appearance.Options.UseFont = true;
            this.edtModulID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtModulID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtModulID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtModulID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtModulID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtModulID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtModulID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtModulID.Properties.NullText = "";
            this.edtModulID.Properties.ShowFooter = false;
            this.edtModulID.Properties.ShowHeader = false;
            this.edtModulID.Size = new System.Drawing.Size(225, 24);
            this.edtModulID.TabIndex = 6;
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(150, 130);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(94, 24);
            this.edtDatumVon.TabIndex = 8;
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(281, 130);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(94, 24);
            this.edtDatumBis.TabIndex = 9;
            // 
            // edtNurAktive
            // 
            this.edtNurAktive.EditValue = false;
            this.edtNurAktive.Location = new System.Drawing.Point(150, 160);
            this.edtNurAktive.Name = "edtNurAktive";
            this.edtNurAktive.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtNurAktive.Properties.Appearance.Options.UseBackColor = true;
            this.edtNurAktive.Properties.Caption = "nur aktive";
            this.edtNurAktive.Size = new System.Drawing.Size(200, 19);
            this.edtNurAktive.TabIndex = 10;
            // 
            // colAbgeschlossen
            // 
            this.colAbgeschlossen.Name = "colAbgeschlossen";
            // 
            // colAHVNummer
            // 
            this.colAHVNummer.Name = "colAHVNummer";
            // 
            // colErffnet
            // 
            this.colErffnet.Name = "colErffnet";
            // 
            // colFallNr
            // 
            this.colFallNr.Name = "colFallNr";
            // 
            // colGeburtsdatum
            // 
            this.colGeburtsdatum.Name = "colGeburtsdatum";
            // 
            // colGeschlecht
            // 
            this.colGeschlecht.Name = "colGeschlecht";
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
            // colNNummer
            // 
            this.colNNummer.Name = "colNNummer";
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
            // colSAR
            // 
            this.colSAR.Name = "colSAR";
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
            // colZusatz
            // 
            this.colZusatz.Name = "colZusatz";
            // 
            // colZustndigeGemeinde
            // 
            this.colZustndigeGemeinde.Name = "colZustndigeGemeinde";
            // 
            // lblBfsLeistungsart
            // 
            this.lblBfsLeistungsart.Location = new System.Drawing.Point(10, 185);
            this.lblBfsLeistungsart.Name = "lblBfsLeistungsart";
            this.lblBfsLeistungsart.Size = new System.Drawing.Size(130, 24);
            this.lblBfsLeistungsart.TabIndex = 11;
            this.lblBfsLeistungsart.Text = "BFS-Leistungsart";
            // 
            // edtBfsLeistungsart
            // 
            this.edtBfsLeistungsart.Location = new System.Drawing.Point(150, 185);
            this.edtBfsLeistungsart.LOVFilter = "S";
            this.edtBfsLeistungsart.LOVName = "Leistungsart";
            this.edtBfsLeistungsart.Name = "edtBfsLeistungsart";
            this.edtBfsLeistungsart.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBfsLeistungsart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBfsLeistungsart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBfsLeistungsart.Properties.Appearance.Options.UseBackColor = true;
            this.edtBfsLeistungsart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBfsLeistungsart.Properties.Appearance.Options.UseFont = true;
            this.edtBfsLeistungsart.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBfsLeistungsart.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBfsLeistungsart.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBfsLeistungsart.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBfsLeistungsart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtBfsLeistungsart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtBfsLeistungsart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBfsLeistungsart.Properties.NullText = "";
            this.edtBfsLeistungsart.Properties.PopupWidth = 250;
            this.edtBfsLeistungsart.Properties.ShowFooter = false;
            this.edtBfsLeistungsart.Properties.ShowHeader = false;
            this.edtBfsLeistungsart.Size = new System.Drawing.Size(225, 24);
            this.edtBfsLeistungsart.TabIndex = 12;
            // 
            // tpgListe2
            // 
            this.tpgListe2.Controls.Add(this.grdQuery2);
            this.tpgListe2.Location = new System.Drawing.Point(6, 6);
            this.tpgListe2.Name = "tpgListe2";
            this.tpgListe2.Size = new System.Drawing.Size(772, 424);
            this.tpgListe2.TabIndex = 0;
            this.tpgListe2.Title = "Liste 2";
            // 
            // grdQuery2
            // 
            this.grdQuery2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdQuery2.DataSource = this.qryListe2;
            // 
            // 
            // 
            this.grdQuery2.EmbeddedNavigator.Name = "";
            this.grdQuery2.Location = new System.Drawing.Point(3, 0);
            this.grdQuery2.MainView = this.grvQuery2;
            this.grdQuery2.Name = "grdQuery2";
            this.grdQuery2.Size = new System.Drawing.Size(766, 424);
            this.grdQuery2.TabIndex = 0;
            this.grdQuery2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvQuery2});
            // 
            // qryListe2
            // 
            this.qryListe2.HostControl = this;
            this.qryListe2.SelectStatement = resources.GetString("qryListe2.SelectStatement");
            // 
            // grvQuery2
            // 
            this.grvQuery2.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvQuery2.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery2.Appearance.Empty.Options.UseBackColor = true;
            this.grvQuery2.Appearance.Empty.Options.UseFont = true;
            this.grvQuery2.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvQuery2.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery2.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvQuery2.Appearance.EvenRow.Options.UseFont = true;
            this.grvQuery2.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery2.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery2.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvQuery2.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvQuery2.Appearance.FocusedCell.Options.UseFont = true;
            this.grvQuery2.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvQuery2.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery2.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery2.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvQuery2.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvQuery2.Appearance.FocusedRow.Options.UseFont = true;
            this.grvQuery2.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvQuery2.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery2.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvQuery2.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery2.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvQuery2.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery2.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvQuery2.Appearance.GroupRow.Options.UseFont = true;
            this.grvQuery2.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvQuery2.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvQuery2.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvQuery2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvQuery2.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvQuery2.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvQuery2.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvQuery2.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvQuery2.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery2.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery2.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvQuery2.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvQuery2.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvQuery2.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery2.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvQuery2.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvQuery2.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery2.Appearance.OddRow.Options.UseBackColor = true;
            this.grvQuery2.Appearance.OddRow.Options.UseFont = true;
            this.grvQuery2.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvQuery2.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery2.Appearance.Row.Options.UseBackColor = true;
            this.grvQuery2.Appearance.Row.Options.UseFont = true;
            this.grvQuery2.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvQuery2.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery2.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvQuery2.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvQuery2.Appearance.SelectedRow.Options.UseFont = true;
            this.grvQuery2.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvQuery2.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery2.Appearance.VertLine.Options.UseBackColor = true;
            this.grvQuery2.BestFitMaxRowCount = 50;
            this.grvQuery2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvQuery2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvQuery2.GridControl = this.grdQuery2;
            this.grvQuery2.Name = "grvQuery2";
            this.grvQuery2.OptionsBehavior.Editable = false;
            this.grvQuery2.OptionsCustomization.AllowFilter = false;
            this.grvQuery2.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvQuery2.OptionsNavigation.AutoFocusNewRow = true;
            this.grvQuery2.OptionsNavigation.UseTabKey = false;
            this.grvQuery2.OptionsPrint.AutoWidth = false;
            this.grvQuery2.OptionsPrint.ExpandAllDetails = true;
            this.grvQuery2.OptionsPrint.UsePrintStyles = true;
            this.grvQuery2.OptionsView.ColumnAutoWidth = false;
            this.grvQuery2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvQuery2.OptionsView.ShowGroupPanel = false;
            this.grvQuery2.OptionsView.ShowIndicator = false;
            // 
            // CtlQueryFaFaelleProMitarbeiter
            // 
            this.Name = "CtlQueryFaFaelleProMitarbeiter";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgListe.PerformLayout();
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModul)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlient.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblaktivzwischen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurAktive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBfsLeistungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBfsLeistungsart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBfsLeistungsart)).EndInit();
            this.tpgListe2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryListe2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn colAHVNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colAbgeschlossen;
        private DevExpress.XtraGrid.Columns.GridColumn colErffnet;
        private DevExpress.XtraGrid.Columns.GridColumn colFallNr;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGeschlecht;
        private DevExpress.XtraGrid.Columns.GridColumn colHeimatort;
        private DevExpress.XtraGrid.Columns.GridColumn colHeimatortKanton;
        private DevExpress.XtraGrid.Columns.GridColumn colKanton;
        private DevExpress.XtraGrid.Columns.GridColumn colModul;
        private DevExpress.XtraGrid.Columns.GridColumn colNNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colNationalitt;
        private DevExpress.XtraGrid.Columns.GridColumn colOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colPLZ;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colSAR;
        private DevExpress.XtraGrid.Columns.GridColumn colStrasse;
        private DevExpress.XtraGrid.Columns.GridColumn colStrasseNr;
        private DevExpress.XtraGrid.Columns.GridColumn colZivilstand;
        private DevExpress.XtraGrid.Columns.GridColumn colZusatz;
        private DevExpress.XtraGrid.Columns.GridColumn colZustndigeGemeinde;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissTextEdit edtKlient;
        private KiSS4.Gui.KissLookUpEdit edtModulID;
        private KiSS4.Gui.KissCheckEdit edtNurAktive;
        private KiSS4.Common.KissMitarbeiterButtonEdit edtUserID;
        private KiSS4.Gui.KissLabel lblKlientIn;
        private KiSS4.Gui.KissLabel lblModul;
        private KiSS4.Gui.KissLabel lblSAR;
        private KiSS4.Gui.KissLabel lblBfsLeistungsart;
        private KiSS4.Gui.KissLookUpEdit edtBfsLeistungsart;
        private SharpLibrary.WinControls.TabPageEx tpgListe2;
        private KiSS4.Gui.KissGrid grdQuery2;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.DB.SqlQuery qryListe2;
        private DevExpress.XtraGrid.Views.Grid.GridView grvQuery2;
        private KiSS4.Gui.KissLabel lblaktivzwischen;
    }
}
