namespace KiSS4.Query.IBE
{
    public partial class CtlQueryBaPersonenSuchen
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryBaPersonenSuchen));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btnFallInfo = new KiSS4.Gui.KissButton();
            this.lblName = new KiSS4.Gui.KissLabel();
            this.edtName = new KiSS4.Gui.KissTextEdit();
            this.lblVorname = new KiSS4.Gui.KissLabel();
            this.edtVorname = new KiSS4.Gui.KissTextEdit();
            this.lblGeburtsdatumvon = new KiSS4.Gui.KissLabel();
            this.edtGeburtVon = new KiSS4.Gui.KissDateEdit();
            this.lblbis = new KiSS4.Gui.KissLabel();
            this.edtGeburtBis = new KiSS4.Gui.KissDateEdit();
            this.lblAHV = new KiSS4.Gui.KissLabel();
            this.edtAHV = new KiSS4.Gui.KissTextEdit();
            this.lblNNr = new KiSS4.Gui.KissLabel();
            this.edtNNr = new KiSS4.Gui.KissTextEdit();
            this.lblStrasse = new KiSS4.Gui.KissLabel();
            this.edtStrasse = new KiSS4.Gui.KissTextEdit();
            this.lblPLZOrt = new KiSS4.Gui.KissLabel();
            this.edtPLZ = new KiSS4.Gui.KissTextEdit();
            this.edtOrt = new KiSS4.Gui.KissTextEdit();
            this.edtNurAktivePerson = new KiSS4.Gui.KissCheckEdit();
            this.colAHV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAHVNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAHVVersNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuslaenderStatusCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuslaenderStatusDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuslaenderStatusGueltigBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaPersonTS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBemerkung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBFFNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEMail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErteilungVA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFiktiv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFruehererName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtsdatum1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeschlechtCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHeimatgemeindeBaGemeindeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHeimatort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImKantonSeit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImKantonSeitGeburt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInCHSeitGeburt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInGemeindeSeit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKonfessionCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMigrationKA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMobilTel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmw = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNationalitaetCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNavigatorZusatz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersonSichtbarSDFlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPLZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSARAsyl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSARFallfhrung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSARInkasso = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSARSozialhilfe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSARVormundschaft = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSichtbarSDFlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSprachCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSterbedatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrasse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTelefonG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTelefonP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTestperson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTitel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnterstuetzt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUntWohnsitzKanton = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUntWohnsitzLandCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUntWohnsitzOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUntWohnsitzOrtCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUntWohnsitzPLZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVersichertennummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorname1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorname2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWegzugDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWegzugKanton = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWegzugLandCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWegzugOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWegzugOrtCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWegzugPLZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWohnsituationCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWohnungsgroesseCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZEMISNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZivilstandCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZivilstandDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZuzugGdeDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZuzugGdeKanton = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZuzugGdeLandCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZuzugGdeOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZuzugGdeOrtCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZuzugGdePLZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZuzugGdeSeitGeburt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZuzugKtDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZuzugKtKanton = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZuzugKtLandCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZuzugKtOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZuzugKtOrtCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZuzugKtPLZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZuzugKtSeitGeburt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.soundex = new KiSS4.Gui.KissCheckEdit();
            this.edtVersNr = new KiSS4.Gui.KissTextEdit();
            this.lblVersNr = new KiSS4.Gui.KissLabel();
            this.edtHaushaltVersNr = new KiSS4.Gui.KissTextEdit();
            this.lblHaushaltVersNr = new KiSS4.Gui.KissLabel();
            this.edtFT = new KiSS4.Gui.KissCheckEdit();
            this.lblAktivVon = new KiSS4.Gui.KissLabel();
            this.edtAktivVon = new KiSS4.Gui.KissDateEdit();
            this.lblAktivBis = new KiSS4.Gui.KissLabel();
            this.edtAktivBis = new KiSS4.Gui.KissDateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsdatumvon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAHV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAHV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStrasse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPLZOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPLZ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurAktivePerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.soundex.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHaushaltVersNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHaushaltVersNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAktivVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAktivVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAktivBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAktivBis.Properties)).BeginInit();
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
            this.xDocument.Location = new System.Drawing.Point(277, 937);
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
            this.ctlGotoFall.Location = new System.Drawing.Point(3, 485);
            // 
            // lblSuchkriterienInfo
            // 
            this.lblSuchkriterienInfo.Location = new System.Drawing.Point(306, 489);
            this.lblSuchkriterienInfo.Size = new System.Drawing.Size(496, 13);
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(793, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.Size = new System.Drawing.Size(817, 552);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.btnFallInfo);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Size = new System.Drawing.Size(805, 514);
            this.tpgListe.Controls.SetChildIndex(this.lblSuchkriterienInfo, 0);
            this.tpgListe.Controls.SetChildIndex(this.ctlGotoFall, 0);
            this.tpgListe.Controls.SetChildIndex(this.xDocument, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnFallInfo, 0);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtFT);
            this.tpgSuchen.Controls.Add(this.edtHaushaltVersNr);
            this.tpgSuchen.Controls.Add(this.lblHaushaltVersNr);
            this.tpgSuchen.Controls.Add(this.edtVersNr);
            this.tpgSuchen.Controls.Add(this.lblVersNr);
            this.tpgSuchen.Controls.Add(this.soundex);
            this.tpgSuchen.Controls.Add(this.edtNurAktivePerson);
            this.tpgSuchen.Controls.Add(this.edtOrt);
            this.tpgSuchen.Controls.Add(this.edtPLZ);
            this.tpgSuchen.Controls.Add(this.lblPLZOrt);
            this.tpgSuchen.Controls.Add(this.edtStrasse);
            this.tpgSuchen.Controls.Add(this.lblStrasse);
            this.tpgSuchen.Controls.Add(this.edtNNr);
            this.tpgSuchen.Controls.Add(this.lblNNr);
            this.tpgSuchen.Controls.Add(this.edtAHV);
            this.tpgSuchen.Controls.Add(this.lblAHV);
            this.tpgSuchen.Controls.Add(this.edtAktivBis);
            this.tpgSuchen.Controls.Add(this.edtGeburtBis);
            this.tpgSuchen.Controls.Add(this.lblAktivBis);
            this.tpgSuchen.Controls.Add(this.lblbis);
            this.tpgSuchen.Controls.Add(this.edtAktivVon);
            this.tpgSuchen.Controls.Add(this.lblAktivVon);
            this.tpgSuchen.Controls.Add(this.edtGeburtVon);
            this.tpgSuchen.Controls.Add(this.lblGeburtsdatumvon);
            this.tpgSuchen.Controls.Add(this.edtVorname);
            this.tpgSuchen.Controls.Add(this.lblVorname);
            this.tpgSuchen.Controls.Add(this.edtName);
            this.tpgSuchen.Controls.Add(this.lblName);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Size = new System.Drawing.Size(805, 514);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblVorname, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtVorname, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblGeburtsdatumvon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtGeburtVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblAktivVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAktivVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblbis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblAktivBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtGeburtBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAktivBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblAHV, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAHV, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblNNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblStrasse, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtStrasse, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblPLZOrt, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtPLZ, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtOrt, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNurAktivePerson, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.soundex, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblVersNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtVersNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblHaushaltVersNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtHaushaltVersNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFT, 0);
            // 
            // btnFallInfo
            // 
            this.btnFallInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFallInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFallInfo.Location = new System.Drawing.Point(167, 487);
            this.btnFallInfo.Name = "btnFallInfo";
            this.btnFallInfo.Size = new System.Drawing.Size(90, 24);
            this.btnFallInfo.TabIndex = 3;
            this.btnFallInfo.Text = "Fall-Info";
            this.btnFallInfo.UseCompatibleTextRendering = true;
            this.btnFallInfo.UseVisualStyleBackColor = true;
            this.btnFallInfo.Click += new System.EventHandler(this.btnFallInfo_Click);
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(14, 39);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(130, 24);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            this.lblName.UseCompatibleTextRendering = true;
            // 
            // edtName
            // 
            this.edtName.Location = new System.Drawing.Point(158, 39);
            this.edtName.Name = "edtName";
            this.edtName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtName.Properties.Appearance.Options.UseBackColor = true;
            this.edtName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtName.Properties.Appearance.Options.UseFont = true;
            this.edtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtName.Size = new System.Drawing.Size(250, 24);
            this.edtName.TabIndex = 2;
            // 
            // lblVorname
            // 
            this.lblVorname.Location = new System.Drawing.Point(14, 69);
            this.lblVorname.Name = "lblVorname";
            this.lblVorname.Size = new System.Drawing.Size(130, 24);
            this.lblVorname.TabIndex = 3;
            this.lblVorname.Text = "Vorname";
            this.lblVorname.UseCompatibleTextRendering = true;
            // 
            // edtVorname
            // 
            this.edtVorname.Location = new System.Drawing.Point(158, 69);
            this.edtVorname.Name = "edtVorname";
            this.edtVorname.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVorname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVorname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVorname.Properties.Appearance.Options.UseBackColor = true;
            this.edtVorname.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVorname.Properties.Appearance.Options.UseFont = true;
            this.edtVorname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVorname.Size = new System.Drawing.Size(250, 24);
            this.edtVorname.TabIndex = 4;
            // 
            // lblGeburtsdatumvon
            // 
            this.lblGeburtsdatumvon.Location = new System.Drawing.Point(14, 99);
            this.lblGeburtsdatumvon.Name = "lblGeburtsdatumvon";
            this.lblGeburtsdatumvon.Size = new System.Drawing.Size(130, 24);
            this.lblGeburtsdatumvon.TabIndex = 5;
            this.lblGeburtsdatumvon.Text = "Geburtsdatum von";
            this.lblGeburtsdatumvon.UseCompatibleTextRendering = true;
            // 
            // edtGeburtVon
            // 
            this.edtGeburtVon.EditValue = "";
            this.edtGeburtVon.Location = new System.Drawing.Point(158, 99);
            this.edtGeburtVon.Name = "edtGeburtVon";
            this.edtGeburtVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGeburtVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGeburtVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeburtVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeburtVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeburtVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeburtVon.Properties.Appearance.Options.UseFont = true;
            this.edtGeburtVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtGeburtVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGeburtVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtGeburtVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeburtVon.Properties.ShowToday = false;
            this.edtGeburtVon.Size = new System.Drawing.Size(100, 24);
            this.edtGeburtVon.TabIndex = 6;
            // 
            // lblbis
            // 
            this.lblbis.Location = new System.Drawing.Point(268, 99);
            this.lblbis.Name = "lblbis";
            this.lblbis.Size = new System.Drawing.Size(34, 24);
            this.lblbis.TabIndex = 7;
            this.lblbis.Text = "bis";
            this.lblbis.UseCompatibleTextRendering = true;
            // 
            // edtGeburtBis
            // 
            this.edtGeburtBis.EditValue = "";
            this.edtGeburtBis.Location = new System.Drawing.Point(308, 99);
            this.edtGeburtBis.Name = "edtGeburtBis";
            this.edtGeburtBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGeburtBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGeburtBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeburtBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeburtBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeburtBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeburtBis.Properties.Appearance.Options.UseFont = true;
            this.edtGeburtBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtGeburtBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGeburtBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtGeburtBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeburtBis.Properties.ShowToday = false;
            this.edtGeburtBis.Size = new System.Drawing.Size(100, 24);
            this.edtGeburtBis.TabIndex = 8;
            // 
            // lblAHV
            // 
            this.lblAHV.Location = new System.Drawing.Point(14, 129);
            this.lblAHV.Name = "lblAHV";
            this.lblAHV.Size = new System.Drawing.Size(130, 24);
            this.lblAHV.TabIndex = 9;
            this.lblAHV.Text = "AHV-Nr.";
            this.lblAHV.UseCompatibleTextRendering = true;
            // 
            // edtAHV
            // 
            this.edtAHV.Location = new System.Drawing.Point(158, 129);
            this.edtAHV.Name = "edtAHV";
            this.edtAHV.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAHV.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAHV.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAHV.Properties.Appearance.Options.UseBackColor = true;
            this.edtAHV.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAHV.Properties.Appearance.Options.UseFont = true;
            this.edtAHV.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAHV.Size = new System.Drawing.Size(250, 24);
            this.edtAHV.TabIndex = 10;
            // 
            // lblNNr
            // 
            this.lblNNr.Location = new System.Drawing.Point(14, 219);
            this.lblNNr.Name = "lblNNr";
            this.lblNNr.Size = new System.Drawing.Size(130, 24);
            this.lblNNr.TabIndex = 15;
            this.lblNNr.Text = "N-Nr";
            this.lblNNr.UseCompatibleTextRendering = true;
            // 
            // edtNNr
            // 
            this.edtNNr.Location = new System.Drawing.Point(158, 219);
            this.edtNNr.Name = "edtNNr";
            this.edtNNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtNNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNNr.Properties.Appearance.Options.UseFont = true;
            this.edtNNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNNr.Size = new System.Drawing.Size(250, 24);
            this.edtNNr.TabIndex = 16;
            // 
            // lblStrasse
            // 
            this.lblStrasse.Location = new System.Drawing.Point(14, 249);
            this.lblStrasse.Name = "lblStrasse";
            this.lblStrasse.Size = new System.Drawing.Size(130, 24);
            this.lblStrasse.TabIndex = 17;
            this.lblStrasse.Text = "Strasse";
            this.lblStrasse.UseCompatibleTextRendering = true;
            // 
            // edtStrasse
            // 
            this.edtStrasse.Location = new System.Drawing.Point(158, 249);
            this.edtStrasse.Name = "edtStrasse";
            this.edtStrasse.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStrasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStrasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.edtStrasse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStrasse.Properties.Appearance.Options.UseFont = true;
            this.edtStrasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStrasse.Size = new System.Drawing.Size(250, 24);
            this.edtStrasse.TabIndex = 18;
            // 
            // lblPLZOrt
            // 
            this.lblPLZOrt.Location = new System.Drawing.Point(14, 279);
            this.lblPLZOrt.Name = "lblPLZOrt";
            this.lblPLZOrt.Size = new System.Drawing.Size(130, 24);
            this.lblPLZOrt.TabIndex = 19;
            this.lblPLZOrt.Text = "PLZ / Ort";
            this.lblPLZOrt.UseCompatibleTextRendering = true;
            // 
            // edtPLZ
            // 
            this.edtPLZ.Location = new System.Drawing.Point(158, 279);
            this.edtPLZ.Name = "edtPLZ";
            this.edtPLZ.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPLZ.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPLZ.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPLZ.Properties.Appearance.Options.UseBackColor = true;
            this.edtPLZ.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPLZ.Properties.Appearance.Options.UseFont = true;
            this.edtPLZ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPLZ.Size = new System.Drawing.Size(60, 24);
            this.edtPLZ.TabIndex = 20;
            // 
            // edtOrt
            // 
            this.edtOrt.Location = new System.Drawing.Point(228, 279);
            this.edtOrt.Name = "edtOrt";
            this.edtOrt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtOrt.Properties.Appearance.Options.UseBackColor = true;
            this.edtOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtOrt.Properties.Appearance.Options.UseFont = true;
            this.edtOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtOrt.Size = new System.Drawing.Size(180, 24);
            this.edtOrt.TabIndex = 21;
            // 
            // edtNurAktivePerson
            // 
            this.edtNurAktivePerson.EditValue = false;
            this.edtNurAktivePerson.Location = new System.Drawing.Point(158, 364);
            this.edtNurAktivePerson.Name = "edtNurAktivePerson";
            this.edtNurAktivePerson.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtNurAktivePerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtNurAktivePerson.Properties.Caption = "nur aktive Personen";
            this.edtNurAktivePerson.Size = new System.Drawing.Size(250, 19);
            this.edtNurAktivePerson.TabIndex = 27;
            // 
            // colAHV
            // 
            this.colAHV.Name = "colAHV";
            // 
            // colAHVNummer
            // 
            this.colAHVNummer.Name = "colAHVNummer";
            // 
            // colAHVVersNr
            // 
            this.colAHVVersNr.Name = "colAHVVersNr";
            // 
            // colAlter
            // 
            this.colAlter.Name = "colAlter";
            // 
            // colAuslaenderStatusCode
            // 
            this.colAuslaenderStatusCode.Name = "colAuslaenderStatusCode";
            // 
            // colAuslaenderStatusDatum
            // 
            this.colAuslaenderStatusDatum.Name = "colAuslaenderStatusDatum";
            // 
            // colAuslaenderStatusGueltigBis
            // 
            this.colAuslaenderStatusGueltigBis.Name = "colAuslaenderStatusGueltigBis";
            // 
            // colBaPersonID
            // 
            this.colBaPersonID.Name = "colBaPersonID";
            // 
            // colBaPersonTS
            // 
            this.colBaPersonTS.Name = "colBaPersonTS";
            // 
            // colBemerkung
            // 
            this.colBemerkung.Name = "colBemerkung";
            // 
            // colBFFNummer
            // 
            this.colBFFNummer.Name = "colBFFNummer";
            // 
            // colEMail
            // 
            this.colEMail.Name = "colEMail";
            // 
            // colErteilungVA
            // 
            this.colErteilungVA.Name = "colErteilungVA";
            // 
            // colFax
            // 
            this.colFax.Name = "colFax";
            // 
            // colFiktiv
            // 
            this.colFiktiv.Name = "colFiktiv";
            // 
            // colFruehererName
            // 
            this.colFruehererName.Name = "colFruehererName";
            // 
            // colFT
            // 
            this.colFT.Name = "colFT";
            // 
            // colGeburtsdatum
            // 
            this.colGeburtsdatum.Name = "colGeburtsdatum";
            // 
            // colGeburtsdatum1
            // 
            this.colGeburtsdatum1.Name = "colGeburtsdatum1";
            // 
            // colGeschlechtCode
            // 
            this.colGeschlechtCode.Name = "colGeschlechtCode";
            // 
            // colHeimatgemeindeBaGemeindeID
            // 
            this.colHeimatgemeindeBaGemeindeID.Name = "colHeimatgemeindeBaGemeindeID";
            // 
            // colHeimatort
            // 
            this.colHeimatort.Name = "colHeimatort";
            // 
            // colImKantonSeit
            // 
            this.colImKantonSeit.Name = "colImKantonSeit";
            // 
            // colImKantonSeitGeburt
            // 
            this.colImKantonSeitGeburt.Name = "colImKantonSeitGeburt";
            // 
            // colInCHSeitGeburt
            // 
            this.colInCHSeitGeburt.Name = "colInCHSeitGeburt";
            // 
            // colInGemeindeSeit
            // 
            this.colInGemeindeSeit.Name = "colInGemeindeSeit";
            // 
            // colKonfessionCode
            // 
            this.colKonfessionCode.Name = "colKonfessionCode";
            // 
            // colMigrationKA
            // 
            this.colMigrationKA.Name = "colMigrationKA";
            // 
            // colMobilTel
            // 
            this.colMobilTel.Name = "colMobilTel";
            // 
            // colmw
            // 
            this.colmw.Name = "colmw";
            // 
            // colName
            // 
            this.colName.Name = "colName";
            // 
            // colName1
            // 
            this.colName1.Name = "colName1";
            // 
            // colNationalitaetCode
            // 
            this.colNationalitaetCode.Name = "colNationalitaetCode";
            // 
            // colNavigatorZusatz
            // 
            this.colNavigatorZusatz.Name = "colNavigatorZusatz";
            // 
            // colNNr
            // 
            this.colNNr.Name = "colNNr";
            // 
            // colNNummer
            // 
            this.colNNummer.Name = "colNNummer";
            // 
            // colOrt
            // 
            this.colOrt.Name = "colOrt";
            // 
            // colPersonSichtbarSDFlag
            // 
            this.colPersonSichtbarSDFlag.Name = "colPersonSichtbarSDFlag";
            // 
            // colPLZ
            // 
            this.colPLZ.Name = "colPLZ";
            // 
            // colSARAsyl
            // 
            this.colSARAsyl.Name = "colSARAsyl";
            // 
            // colSARFallfhrung
            // 
            this.colSARFallfhrung.Name = "colSARFallfhrung";
            // 
            // colSARInkasso
            // 
            this.colSARInkasso.Name = "colSARInkasso";
            // 
            // colSARSozialhilfe
            // 
            this.colSARSozialhilfe.Name = "colSARSozialhilfe";
            // 
            // colSARVormundschaft
            // 
            this.colSARVormundschaft.Name = "colSARVormundschaft";
            // 
            // colSichtbarSDFlag
            // 
            this.colSichtbarSDFlag.Name = "colSichtbarSDFlag";
            // 
            // colSprachCode
            // 
            this.colSprachCode.Name = "colSprachCode";
            // 
            // colSterbedatum
            // 
            this.colSterbedatum.Name = "colSterbedatum";
            // 
            // colStrasse
            // 
            this.colStrasse.Name = "colStrasse";
            // 
            // colTelefonG
            // 
            this.colTelefonG.Name = "colTelefonG";
            // 
            // colTelefonP
            // 
            this.colTelefonP.Name = "colTelefonP";
            // 
            // colTestperson
            // 
            this.colTestperson.Name = "colTestperson";
            // 
            // colTitel
            // 
            this.colTitel.Name = "colTitel";
            // 
            // colUnterstuetzt
            // 
            this.colUnterstuetzt.Name = "colUnterstuetzt";
            // 
            // colUntWohnsitzKanton
            // 
            this.colUntWohnsitzKanton.Name = "colUntWohnsitzKanton";
            // 
            // colUntWohnsitzLandCode
            // 
            this.colUntWohnsitzLandCode.Name = "colUntWohnsitzLandCode";
            // 
            // colUntWohnsitzOrt
            // 
            this.colUntWohnsitzOrt.Name = "colUntWohnsitzOrt";
            // 
            // colUntWohnsitzOrtCode
            // 
            this.colUntWohnsitzOrtCode.Name = "colUntWohnsitzOrtCode";
            // 
            // colUntWohnsitzPLZ
            // 
            this.colUntWohnsitzPLZ.Name = "colUntWohnsitzPLZ";
            // 
            // colVerID
            // 
            this.colVerID.Name = "colVerID";
            // 
            // colVersichertennummer
            // 
            this.colVersichertennummer.Name = "colVersichertennummer";
            // 
            // colVorname
            // 
            this.colVorname.Name = "colVorname";
            // 
            // colVorname1
            // 
            this.colVorname1.Name = "colVorname1";
            // 
            // colVorname2
            // 
            this.colVorname2.Name = "colVorname2";
            // 
            // colWegzugDatum
            // 
            this.colWegzugDatum.Name = "colWegzugDatum";
            // 
            // colWegzugKanton
            // 
            this.colWegzugKanton.Name = "colWegzugKanton";
            // 
            // colWegzugLandCode
            // 
            this.colWegzugLandCode.Name = "colWegzugLandCode";
            // 
            // colWegzugOrt
            // 
            this.colWegzugOrt.Name = "colWegzugOrt";
            // 
            // colWegzugOrtCode
            // 
            this.colWegzugOrtCode.Name = "colWegzugOrtCode";
            // 
            // colWegzugPLZ
            // 
            this.colWegzugPLZ.Name = "colWegzugPLZ";
            // 
            // colWohnsituationCode
            // 
            this.colWohnsituationCode.Name = "colWohnsituationCode";
            // 
            // colWohnungsgroesseCode
            // 
            this.colWohnungsgroesseCode.Name = "colWohnungsgroesseCode";
            // 
            // colZEMISNummer
            // 
            this.colZEMISNummer.Name = "colZEMISNummer";
            // 
            // colZivilstandCode
            // 
            this.colZivilstandCode.Name = "colZivilstandCode";
            // 
            // colZivilstandDatum
            // 
            this.colZivilstandDatum.Name = "colZivilstandDatum";
            // 
            // colZuzugGdeDatum
            // 
            this.colZuzugGdeDatum.Name = "colZuzugGdeDatum";
            // 
            // colZuzugGdeKanton
            // 
            this.colZuzugGdeKanton.Name = "colZuzugGdeKanton";
            // 
            // colZuzugGdeLandCode
            // 
            this.colZuzugGdeLandCode.Name = "colZuzugGdeLandCode";
            // 
            // colZuzugGdeOrt
            // 
            this.colZuzugGdeOrt.Name = "colZuzugGdeOrt";
            // 
            // colZuzugGdeOrtCode
            // 
            this.colZuzugGdeOrtCode.Name = "colZuzugGdeOrtCode";
            // 
            // colZuzugGdePLZ
            // 
            this.colZuzugGdePLZ.Name = "colZuzugGdePLZ";
            // 
            // colZuzugGdeSeitGeburt
            // 
            this.colZuzugGdeSeitGeburt.Name = "colZuzugGdeSeitGeburt";
            // 
            // colZuzugKtDatum
            // 
            this.colZuzugKtDatum.Name = "colZuzugKtDatum";
            // 
            // colZuzugKtKanton
            // 
            this.colZuzugKtKanton.Name = "colZuzugKtKanton";
            // 
            // colZuzugKtLandCode
            // 
            this.colZuzugKtLandCode.Name = "colZuzugKtLandCode";
            // 
            // colZuzugKtOrt
            // 
            this.colZuzugKtOrt.Name = "colZuzugKtOrt";
            // 
            // colZuzugKtOrtCode
            // 
            this.colZuzugKtOrtCode.Name = "colZuzugKtOrtCode";
            // 
            // colZuzugKtPLZ
            // 
            this.colZuzugKtPLZ.Name = "colZuzugKtPLZ";
            // 
            // colZuzugKtSeitGeburt
            // 
            this.colZuzugKtSeitGeburt.Name = "colZuzugKtSeitGeburt";
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
            this.gridView1.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupFooter.Options.UseBorderColor = true;
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
            // gridView2
            // 
            this.gridView2.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView2.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.Empty.Options.UseBackColor = true;
            this.gridView2.Appearance.Empty.Options.UseFont = true;
            this.gridView2.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.EvenRow.Options.UseFont = true;
            this.gridView2.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView2.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView2.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView2.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView2.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView2.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView2.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView2.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView2.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView2.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView2.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView2.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView2.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView2.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView2.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView2.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView2.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView2.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupRow.Options.UseFont = true;
            this.gridView2.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView2.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView2.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView2.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView2.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView2.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView2.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView2.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView2.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView2.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView2.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView2.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.OddRow.Options.UseFont = true;
            this.gridView2.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView2.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.Row.Options.UseBackColor = true;
            this.gridView2.Appearance.Row.Options.UseFont = true;
            this.gridView2.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView2.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView2.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView2.GridControl = this.grdQuery1;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView2.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView2.OptionsNavigation.UseTabKey = false;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowIndicator = false;
            // 
            // gridView3
            // 
            this.gridView3.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView3.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.Empty.Options.UseBackColor = true;
            this.gridView3.Appearance.Empty.Options.UseFont = true;
            this.gridView3.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.EvenRow.Options.UseFont = true;
            this.gridView3.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView3.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView3.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView3.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView3.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView3.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView3.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView3.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView3.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView3.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView3.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView3.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView3.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView3.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView3.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView3.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView3.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView3.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView3.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView3.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView3.Appearance.GroupRow.Options.UseFont = true;
            this.gridView3.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView3.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView3.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView3.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView3.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView3.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView3.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView3.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView3.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView3.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView3.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView3.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView3.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView3.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView3.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.OddRow.Options.UseFont = true;
            this.gridView3.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView3.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.Row.Options.UseBackColor = true;
            this.gridView3.Appearance.Row.Options.UseFont = true;
            this.gridView3.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView3.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView3.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView3.GridControl = this.grdQuery1;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsBehavior.Editable = false;
            this.gridView3.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView3.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView3.OptionsNavigation.UseTabKey = false;
            this.gridView3.OptionsView.ColumnAutoWidth = false;
            this.gridView3.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            this.gridView3.OptionsView.ShowIndicator = false;
            // 
            // soundex
            // 
            this.soundex.EditValue = false;
            this.soundex.Location = new System.Drawing.Point(158, 389);
            this.soundex.Name = "soundex";
            this.soundex.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.soundex.Properties.Appearance.Options.UseBackColor = true;
            this.soundex.Properties.Caption = "auch ähnliche Namen/Vornamen";
            this.soundex.Size = new System.Drawing.Size(250, 19);
            this.soundex.TabIndex = 28;
            // 
            // edtVersNr
            // 
            this.edtVersNr.Location = new System.Drawing.Point(158, 159);
            this.edtVersNr.Name = "edtVersNr";
            this.edtVersNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVersNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVersNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVersNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtVersNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVersNr.Properties.Appearance.Options.UseFont = true;
            this.edtVersNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVersNr.Size = new System.Drawing.Size(250, 24);
            this.edtVersNr.TabIndex = 12;
            // 
            // lblVersNr
            // 
            this.lblVersNr.Location = new System.Drawing.Point(14, 159);
            this.lblVersNr.Name = "lblVersNr";
            this.lblVersNr.Size = new System.Drawing.Size(130, 24);
            this.lblVersNr.TabIndex = 11;
            this.lblVersNr.Text = "Versicherten Nr.";
            this.lblVersNr.UseCompatibleTextRendering = true;
            // 
            // edtHaushaltVersNr
            // 
            this.edtHaushaltVersNr.Location = new System.Drawing.Point(158, 189);
            this.edtHaushaltVersNr.Name = "edtHaushaltVersNr";
            this.edtHaushaltVersNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtHaushaltVersNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHaushaltVersNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHaushaltVersNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtHaushaltVersNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHaushaltVersNr.Properties.Appearance.Options.UseFont = true;
            this.edtHaushaltVersNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtHaushaltVersNr.Size = new System.Drawing.Size(250, 24);
            this.edtHaushaltVersNr.TabIndex = 14;
            // 
            // lblHaushaltVersNr
            // 
            this.lblHaushaltVersNr.Location = new System.Drawing.Point(14, 189);
            this.lblHaushaltVersNr.Name = "lblHaushaltVersNr";
            this.lblHaushaltVersNr.Size = new System.Drawing.Size(141, 24);
            this.lblHaushaltVersNr.TabIndex = 13;
            this.lblHaushaltVersNr.Text = "Haushaltversicherung Nr.";
            this.lblHaushaltVersNr.UseCompatibleTextRendering = true;
            // 
            // edtFT
            // 
            this.edtFT.EditValue = false;
            this.edtFT.Location = new System.Drawing.Point(158, 339);
            this.edtFT.Name = "edtFT";
            this.edtFT.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtFT.Properties.Appearance.Options.UseBackColor = true;
            this.edtFT.Properties.Caption = "nur Fallträger";
            this.edtFT.Size = new System.Drawing.Size(250, 19);
            this.edtFT.TabIndex = 26;
            // 
            // lblAktivVon
            // 
            this.lblAktivVon.Location = new System.Drawing.Point(14, 309);
            this.lblAktivVon.Name = "lblAktivVon";
            this.lblAktivVon.Size = new System.Drawing.Size(130, 24);
            this.lblAktivVon.TabIndex = 22;
            this.lblAktivVon.Text = "Aktiv von";
            this.lblAktivVon.UseCompatibleTextRendering = true;
            // 
            // edtAktivVon
            // 
            this.edtAktivVon.EditValue = "";
            this.edtAktivVon.Location = new System.Drawing.Point(158, 309);
            this.edtAktivVon.Name = "edtAktivVon";
            this.edtAktivVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAktivVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAktivVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAktivVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAktivVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtAktivVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAktivVon.Properties.Appearance.Options.UseFont = true;
            this.edtAktivVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtAktivVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtAktivVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtAktivVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAktivVon.Properties.ShowToday = false;
            this.edtAktivVon.Size = new System.Drawing.Size(100, 24);
            this.edtAktivVon.TabIndex = 23;
            // 
            // lblAktivBis
            // 
            this.lblAktivBis.Location = new System.Drawing.Point(268, 309);
            this.lblAktivBis.Name = "lblAktivBis";
            this.lblAktivBis.Size = new System.Drawing.Size(34, 24);
            this.lblAktivBis.TabIndex = 24;
            this.lblAktivBis.Text = "bis";
            this.lblAktivBis.UseCompatibleTextRendering = true;
            // 
            // edtAktivBis
            // 
            this.edtAktivBis.EditValue = "";
            this.edtAktivBis.Location = new System.Drawing.Point(308, 309);
            this.edtAktivBis.Name = "edtAktivBis";
            this.edtAktivBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAktivBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAktivBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAktivBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAktivBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtAktivBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAktivBis.Properties.Appearance.Options.UseFont = true;
            this.edtAktivBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtAktivBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtAktivBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtAktivBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAktivBis.Properties.ShowToday = false;
            this.edtAktivBis.Size = new System.Drawing.Size(100, 24);
            this.edtAktivBis.TabIndex = 25;
            // 
            // CtlQueryBaPersonenSuchen
            // 
            this.Name = "CtlQueryBaPersonenSuchen";
            this.Size = new System.Drawing.Size(833, 590);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgListe.PerformLayout();
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsdatumvon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAHV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAHV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStrasse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPLZOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPLZ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurAktivePerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.soundex.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHaushaltVersNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHaushaltVersNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAktivVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAktivVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAktivBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAktivBis.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KiSS4.Gui.KissButton btnFallInfo;
        private DevExpress.XtraGrid.Columns.GridColumn colAHV;
        private DevExpress.XtraGrid.Columns.GridColumn colAHVNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colAHVVersNr;
        private DevExpress.XtraGrid.Columns.GridColumn colAlter;
        private DevExpress.XtraGrid.Columns.GridColumn colAuslaenderStatusCode;
        private DevExpress.XtraGrid.Columns.GridColumn colAuslaenderStatusDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colAuslaenderStatusGueltigBis;
        private DevExpress.XtraGrid.Columns.GridColumn colBaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colBaPersonTS;
        private DevExpress.XtraGrid.Columns.GridColumn colBemerkung;
        private DevExpress.XtraGrid.Columns.GridColumn colBFFNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colEMail;
        private DevExpress.XtraGrid.Columns.GridColumn colErteilungVA;
        private DevExpress.XtraGrid.Columns.GridColumn colFax;
        private DevExpress.XtraGrid.Columns.GridColumn colFiktiv;
        private DevExpress.XtraGrid.Columns.GridColumn colFruehererName;
        private DevExpress.XtraGrid.Columns.GridColumn colFT;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtsdatum1;
        private DevExpress.XtraGrid.Columns.GridColumn colGeschlechtCode;
        private DevExpress.XtraGrid.Columns.GridColumn colHeimatgemeindeBaGemeindeID;
        private DevExpress.XtraGrid.Columns.GridColumn colHeimatort;
        private DevExpress.XtraGrid.Columns.GridColumn colImKantonSeit;
        private DevExpress.XtraGrid.Columns.GridColumn colImKantonSeitGeburt;
        private DevExpress.XtraGrid.Columns.GridColumn colInCHSeitGeburt;
        private DevExpress.XtraGrid.Columns.GridColumn colInGemeindeSeit;
        private DevExpress.XtraGrid.Columns.GridColumn colKonfessionCode;
        private DevExpress.XtraGrid.Columns.GridColumn colMigrationKA;
        private DevExpress.XtraGrid.Columns.GridColumn colMobilTel;
        private DevExpress.XtraGrid.Columns.GridColumn colmw;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colName1;
        private DevExpress.XtraGrid.Columns.GridColumn colNationalitaetCode;
        private DevExpress.XtraGrid.Columns.GridColumn colNavigatorZusatz;
        private DevExpress.XtraGrid.Columns.GridColumn colNNr;
        private DevExpress.XtraGrid.Columns.GridColumn colNNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonSichtbarSDFlag;
        private DevExpress.XtraGrid.Columns.GridColumn colPLZ;
        private DevExpress.XtraGrid.Columns.GridColumn colSARAsyl;
        private DevExpress.XtraGrid.Columns.GridColumn colSARFallfhrung;
        private DevExpress.XtraGrid.Columns.GridColumn colSARInkasso;
        private DevExpress.XtraGrid.Columns.GridColumn colSARSozialhilfe;
        private DevExpress.XtraGrid.Columns.GridColumn colSARVormundschaft;
        private DevExpress.XtraGrid.Columns.GridColumn colSichtbarSDFlag;
        private DevExpress.XtraGrid.Columns.GridColumn colSprachCode;
        private DevExpress.XtraGrid.Columns.GridColumn colSterbedatum;
        private DevExpress.XtraGrid.Columns.GridColumn colStrasse;
        private DevExpress.XtraGrid.Columns.GridColumn colTelefonG;
        private DevExpress.XtraGrid.Columns.GridColumn colTelefonP;
        private DevExpress.XtraGrid.Columns.GridColumn colTestperson;
        private DevExpress.XtraGrid.Columns.GridColumn colTitel;
        private DevExpress.XtraGrid.Columns.GridColumn colUnterstuetzt;
        private DevExpress.XtraGrid.Columns.GridColumn colUntWohnsitzKanton;
        private DevExpress.XtraGrid.Columns.GridColumn colUntWohnsitzLandCode;
        private DevExpress.XtraGrid.Columns.GridColumn colUntWohnsitzOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colUntWohnsitzOrtCode;
        private DevExpress.XtraGrid.Columns.GridColumn colUntWohnsitzPLZ;
        private DevExpress.XtraGrid.Columns.GridColumn colVerID;
        private DevExpress.XtraGrid.Columns.GridColumn colVersichertennummer;
        private DevExpress.XtraGrid.Columns.GridColumn colVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colVorname1;
        private DevExpress.XtraGrid.Columns.GridColumn colVorname2;
        private DevExpress.XtraGrid.Columns.GridColumn colWegzugDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colWegzugKanton;
        private DevExpress.XtraGrid.Columns.GridColumn colWegzugLandCode;
        private DevExpress.XtraGrid.Columns.GridColumn colWegzugOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colWegzugOrtCode;
        private DevExpress.XtraGrid.Columns.GridColumn colWegzugPLZ;
        private DevExpress.XtraGrid.Columns.GridColumn colWohnsituationCode;
        private DevExpress.XtraGrid.Columns.GridColumn colWohnungsgroesseCode;
        private DevExpress.XtraGrid.Columns.GridColumn colZEMISNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colZivilstandCode;
        private DevExpress.XtraGrid.Columns.GridColumn colZivilstandDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colZuzugGdeDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colZuzugGdeKanton;
        private DevExpress.XtraGrid.Columns.GridColumn colZuzugGdeLandCode;
        private DevExpress.XtraGrid.Columns.GridColumn colZuzugGdeOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colZuzugGdeOrtCode;
        private DevExpress.XtraGrid.Columns.GridColumn colZuzugGdePLZ;
        private DevExpress.XtraGrid.Columns.GridColumn colZuzugGdeSeitGeburt;
        private DevExpress.XtraGrid.Columns.GridColumn colZuzugKtDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colZuzugKtKanton;
        private DevExpress.XtraGrid.Columns.GridColumn colZuzugKtLandCode;
        private DevExpress.XtraGrid.Columns.GridColumn colZuzugKtOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colZuzugKtOrtCode;
        private DevExpress.XtraGrid.Columns.GridColumn colZuzugKtPLZ;
        private DevExpress.XtraGrid.Columns.GridColumn colZuzugKtSeitGeburt;
        private KiSS4.Gui.KissTextEdit edtAHV;
        private KiSS4.Gui.KissCheckEdit edtFT;
        private KiSS4.Gui.KissDateEdit edtGeburtBis;
        private KiSS4.Gui.KissDateEdit edtGeburtVon;
        private KiSS4.Gui.KissTextEdit edtHaushaltVersNr;
        private KiSS4.Gui.KissTextEdit edtName;
        private KiSS4.Gui.KissTextEdit edtNNr;
        private KiSS4.Gui.KissCheckEdit edtNurAktivePerson;
        private KiSS4.Gui.KissTextEdit edtOrt;
        private KiSS4.Gui.KissTextEdit edtPLZ;
        private KiSS4.Gui.KissTextEdit edtStrasse;
        private KiSS4.Gui.KissTextEdit edtVersNr;
        private KiSS4.Gui.KissTextEdit edtVorname;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private KiSS4.Gui.KissLabel lblAHV;
        private KiSS4.Gui.KissLabel lblbis;
        private KiSS4.Gui.KissLabel lblGeburtsdatumvon;
        private KiSS4.Gui.KissLabel lblHaushaltVersNr;
        private KiSS4.Gui.KissLabel lblName;
        private KiSS4.Gui.KissLabel lblNNr;
        private KiSS4.Gui.KissLabel lblPLZOrt;
        private KiSS4.Gui.KissLabel lblStrasse;
        private KiSS4.Gui.KissLabel lblVersNr;
        private KiSS4.Gui.KissLabel lblVorname;
        private KiSS4.Gui.KissCheckEdit soundex;
        private Gui.KissDateEdit edtAktivBis;
        private Gui.KissLabel lblAktivBis;
        private Gui.KissDateEdit edtAktivVon;
        private Gui.KissLabel lblAktivVon;
    }
}