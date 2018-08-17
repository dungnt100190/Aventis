namespace KiSS4.Klientenbuchhaltung
{
    partial class CtlKbAuszahlungVerbuchen
    {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKbAuszahlungVerbuchen));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryBuchung = new KiSS4.DB.SqlQuery(this.components);
            this.edtPeriodeX = new KiSS4.Gui.KissTextEdit();
            this.lblPeriode = new KiSS4.Gui.KissLabel();
            this.lblKbZahlungskonto = new KiSS4.Gui.KissLabel();
            this.edtKbZahlungskonto = new KiSS4.Gui.KissLookUpEdit();
            this.btnVerbuchen = new KiSS4.Gui.KissButton();
            this.edtBeguenstigtName = new KiSS4.Gui.KissTextEdit();
            this.edtBeguenstigtPLZ = new KiSS4.Gui.KissTextEdit();
            this.edtBeguenstigtOrt = new KiSS4.Gui.KissTextEdit();
            this.edtBetrag = new KiSS4.Gui.KissCalcEdit();
            this.edtBeguenstigtName2 = new KiSS4.Gui.KissTextEdit();
            this.edtBankName = new KiSS4.Gui.KissTextEdit();
            this.edtBankKontoNr = new KiSS4.Gui.KissTextEdit();
            this.edtIBAN = new KiSS4.Gui.KissTextEdit();
            this.edtPCKontoNr = new KiSS4.Gui.KissTextEdit();
            this.edtBuchungsDatum = new KiSS4.Gui.KissDateEdit();
            this.lblBuchungsDatum = new KiSS4.Gui.KissLabel();
            this.qryAktivKonto = new KiSS4.DB.SqlQuery(this.components);
            this.qryAusgleichExists = new KiSS4.DB.SqlQuery(this.components);
            this.qryZahlungskonto = new KiSS4.DB.SqlQuery(this.components);
            this.lblSucheDatumVon = new KiSS4.Gui.KissLabel();
            this.lblSucheBudgetNr = new KiSS4.Gui.KissLabel();
            this.lblSucheBuchungId = new KiSS4.Gui.KissLabel();
            this.lblSucheDatumBis = new KiSS4.Gui.KissLabel();
            this.edtSucheDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtSucheDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtSucheBudgetNr = new KiSS4.Gui.KissTextEdit();
            this.edtSucheBuchungId = new KiSS4.Gui.KissTextEdit();
            this.grdKbAuszahlungen = new KiSS4.Gui.KissGrid();
            this.grvKbAuszahlungen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBuchungId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBelegDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBelegNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFalltraeger = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungstext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungsstatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repBuchungStatus = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.lblBetrag = new KiSS4.Gui.KissLabel();
            this.lblBeguenstigtName = new KiSS4.Gui.KissLabel();
            this.lblBeguenstigtZusatz = new KiSS4.Gui.KissLabel();
            this.lblBeguenstigtPlzOrt = new KiSS4.Gui.KissLabel();
            this.lblBankName = new KiSS4.Gui.KissLabel();
            this.lblBankKonto = new KiSS4.Gui.KissLabel();
            this.lblBankPCKonto = new KiSS4.Gui.KissLabel();
            this.lblBankIBAN = new KiSS4.Gui.KissLabel();
            this.lblZahlinfo = new KiSS4.Gui.KissLabel();
            this.grdZugehoerigeBuchungen = new KiSS4.Gui.KissGrid();
            this.qryZugehoerigeBuchung = new KiSS4.DB.SqlQuery(this.components);
            this.grvZugehoerigeBuchungen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colZugehBuchungId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZugehBelegDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZugehBelegNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZugehBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZugehFT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZugehText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZugehStat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblSucheFT = new KiSS4.Gui.KissLabel();
            this.edtSucheFT = new KiSS4.Gui.KissButtonEdit();
            this.edtBelegNr = new KiSS4.Gui.KissTextEdit();
            this.lblBelegNummer = new KiSS4.Gui.KissLabel();
            this.edtBelegDatum = new KiSS4.Gui.KissDateEdit();
            this.lblBelegDatum = new KiSS4.Gui.KissLabel();
            this.lblZugehoerigeBuchungTitel = new KiSS4.Gui.KissLabel();
            this.btnStatusReset = new KiSS4.Gui.KissButton();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryBuchung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPeriodeX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPeriode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKbZahlungskonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKbZahlungskonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKbZahlungskonto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeguenstigtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeguenstigtPLZ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeguenstigtOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeguenstigtName2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBankName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBankKontoNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIBAN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPCKontoNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungsDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungsDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryAktivKonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryAusgleichExists)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZahlungskonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBudgetNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBuchungId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBudgetNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBuchungId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKbAuszahlungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKbAuszahlungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repBuchungStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeguenstigtName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeguenstigtZusatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeguenstigtPlzOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBankName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBankKonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBankPCKonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBankIBAN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlinfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZugehoerigeBuchungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugehoerigeBuchung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZugehoerigeBuchungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheFT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBelegNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegNummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBelegDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZugehoerigeBuchungTitel)).BeginInit();
            this.SuspendLayout();
            //
            // searchTitle
            //
            this.searchTitle.Size = new System.Drawing.Size(788, 24);
            //
            // tabControlSearch
            //
            this.tabControlSearch.Size = new System.Drawing.Size(812, 261);
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.grdKbAuszahlungen);
            this.tpgListe.Size = new System.Drawing.Size(800, 223);
            this.tpgListe.Title = "Liste";
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.edtSucheFT);
            this.tpgSuchen.Controls.Add(this.lblSucheFT);
            this.tpgSuchen.Controls.Add(this.edtSucheBuchungId);
            this.tpgSuchen.Controls.Add(this.edtSucheBudgetNr);
            this.tpgSuchen.Controls.Add(this.edtSucheDatumVon);
            this.tpgSuchen.Controls.Add(this.edtSucheDatumBis);
            this.tpgSuchen.Controls.Add(this.lblSucheDatumBis);
            this.tpgSuchen.Controls.Add(this.lblSucheBuchungId);
            this.tpgSuchen.Controls.Add(this.lblSucheBudgetNr);
            this.tpgSuchen.Controls.Add(this.lblSucheDatumVon);
            this.tpgSuchen.Controls.Add(this.lblPeriode);
            this.tpgSuchen.Controls.Add(this.edtPeriodeX);
            this.tpgSuchen.Size = new System.Drawing.Size(800, 223);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtPeriodeX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblPeriode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBudgetNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBuchungId, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBudgetNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBuchungId, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheFT, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheFT, 0);
            //
            // qryBuchung
            //
            this.qryBuchung.CanUpdate = true;
            this.qryBuchung.HostControl = this;
            this.qryBuchung.TableName = "KbBuchung";
            this.qryBuchung.PositionChanged += new System.EventHandler(this.qryBuchung_PositionChanged);
            //
            // edtPeriodeX
            //
            this.edtPeriodeX.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtPeriodeX.Location = new System.Drawing.Point(136, 160);
            this.edtPeriodeX.Name = "edtPeriodeX";
            this.edtPeriodeX.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPeriodeX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPeriodeX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPeriodeX.Properties.Appearance.Options.UseBackColor = true;
            this.edtPeriodeX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPeriodeX.Properties.Appearance.Options.UseFont = true;
            this.edtPeriodeX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPeriodeX.Properties.ReadOnly = true;
            this.edtPeriodeX.Size = new System.Drawing.Size(193, 24);
            this.edtPeriodeX.TabIndex = 10;
            this.edtPeriodeX.TabStop = false;
            this.edtPeriodeX.Visible = false;
            //
            // lblPeriode
            //
            this.lblPeriode.Location = new System.Drawing.Point(33, 160);
            this.lblPeriode.Name = "lblPeriode";
            this.lblPeriode.Size = new System.Drawing.Size(73, 24);
            this.lblPeriode.TabIndex = 2;
            this.lblPeriode.Text = "Periode";
            this.lblPeriode.UseCompatibleTextRendering = true;
            this.lblPeriode.Visible = false;
            //
            // lblKbZahlungskonto
            //
            this.lblKbZahlungskonto.Location = new System.Drawing.Point(9, 359);
            this.lblKbZahlungskonto.Name = "lblKbZahlungskonto";
            this.lblKbZahlungskonto.Size = new System.Drawing.Size(84, 24);
            this.lblKbZahlungskonto.TabIndex = 1;
            this.lblKbZahlungskonto.Text = "Zahlungskonto";
            this.lblKbZahlungskonto.UseCompatibleTextRendering = true;
            //
            // edtKbZahlungskonto
            //
            this.edtKbZahlungskonto.AllowNull = false;
            this.edtKbZahlungskonto.Location = new System.Drawing.Point(99, 359);
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
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtKbZahlungskonto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtKbZahlungskonto.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKbZahlungskonto.Properties.NullText = "";
            this.edtKbZahlungskonto.Properties.ShowFooter = false;
            this.edtKbZahlungskonto.Properties.ShowHeader = false;
            this.edtKbZahlungskonto.Size = new System.Drawing.Size(271, 24);
            this.edtKbZahlungskonto.TabIndex = 13;
            //
            // btnVerbuchen
            //
            this.btnVerbuchen.Enabled = false;
            this.btnVerbuchen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerbuchen.Location = new System.Drawing.Point(253, 396);
            this.btnVerbuchen.Name = "btnVerbuchen";
            this.btnVerbuchen.Size = new System.Drawing.Size(117, 24);
            this.btnVerbuchen.TabIndex = 14;
            this.btnVerbuchen.Text = "Verbuchen";
            this.btnVerbuchen.UseCompatibleTextRendering = true;
            this.btnVerbuchen.UseVisualStyleBackColor = false;
            this.btnVerbuchen.Click += new System.EventHandler(this.btnVerbuchen_Click);
            //
            // edtBeguenstigtName
            //
            this.edtBeguenstigtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBeguenstigtName.DataMember = "BeguenstigtName";
            this.edtBeguenstigtName.DataSource = this.qryBuchung;
            this.edtBeguenstigtName.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBeguenstigtName.Location = new System.Drawing.Point(555, 299);
            this.edtBeguenstigtName.Name = "edtBeguenstigtName";
            this.edtBeguenstigtName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBeguenstigtName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBeguenstigtName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBeguenstigtName.Properties.Appearance.Options.UseBackColor = true;
            this.edtBeguenstigtName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBeguenstigtName.Properties.Appearance.Options.UseFont = true;
            this.edtBeguenstigtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBeguenstigtName.Properties.ReadOnly = true;
            this.edtBeguenstigtName.Size = new System.Drawing.Size(254, 24);
            this.edtBeguenstigtName.TabIndex = 16;
            this.edtBeguenstigtName.TabStop = false;
            //
            // edtBeguenstigtPLZ
            //
            this.edtBeguenstigtPLZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBeguenstigtPLZ.DataMember = "BeguenstigtPLZ";
            this.edtBeguenstigtPLZ.DataSource = this.qryBuchung;
            this.edtBeguenstigtPLZ.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBeguenstigtPLZ.Location = new System.Drawing.Point(555, 359);
            this.edtBeguenstigtPLZ.Name = "edtBeguenstigtPLZ";
            this.edtBeguenstigtPLZ.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBeguenstigtPLZ.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBeguenstigtPLZ.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBeguenstigtPLZ.Properties.Appearance.Options.UseBackColor = true;
            this.edtBeguenstigtPLZ.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBeguenstigtPLZ.Properties.Appearance.Options.UseFont = true;
            this.edtBeguenstigtPLZ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBeguenstigtPLZ.Properties.ReadOnly = true;
            this.edtBeguenstigtPLZ.Size = new System.Drawing.Size(67, 24);
            this.edtBeguenstigtPLZ.TabIndex = 18;
            this.edtBeguenstigtPLZ.TabStop = false;
            //
            // edtBeguenstigtOrt
            //
            this.edtBeguenstigtOrt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBeguenstigtOrt.DataMember = "BeguenstigtOrt";
            this.edtBeguenstigtOrt.DataSource = this.qryBuchung;
            this.edtBeguenstigtOrt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBeguenstigtOrt.Location = new System.Drawing.Point(621, 359);
            this.edtBeguenstigtOrt.Name = "edtBeguenstigtOrt";
            this.edtBeguenstigtOrt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBeguenstigtOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBeguenstigtOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBeguenstigtOrt.Properties.Appearance.Options.UseBackColor = true;
            this.edtBeguenstigtOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBeguenstigtOrt.Properties.Appearance.Options.UseFont = true;
            this.edtBeguenstigtOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBeguenstigtOrt.Properties.ReadOnly = true;
            this.edtBeguenstigtOrt.Size = new System.Drawing.Size(188, 24);
            this.edtBeguenstigtOrt.TabIndex = 19;
            this.edtBeguenstigtOrt.TabStop = false;
            //
            // edtBetrag
            //
            this.edtBetrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBetrag.DataMember = "Betrag";
            this.edtBetrag.DataSource = this.qryBuchung;
            this.edtBetrag.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBetrag.Location = new System.Drawing.Point(555, 269);
            this.edtBetrag.Name = "edtBetrag";
            this.edtBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBetrag.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBetrag.Properties.DisplayFormat.FormatString = "N2";
            this.edtBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Properties.EditFormat.FormatString = "N2";
            this.edtBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Properties.Mask.EditMask = "##,###,##0.##";
            this.edtBetrag.Properties.ReadOnly = true;
            this.edtBetrag.Size = new System.Drawing.Size(100, 24);
            this.edtBetrag.TabIndex = 15;
            this.edtBetrag.TabStop = false;
            //
            // edtBeguenstigtName2
            //
            this.edtBeguenstigtName2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBeguenstigtName2.DataMember = "BeguenstigtName2";
            this.edtBeguenstigtName2.DataSource = this.qryBuchung;
            this.edtBeguenstigtName2.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBeguenstigtName2.Location = new System.Drawing.Point(555, 329);
            this.edtBeguenstigtName2.Name = "edtBeguenstigtName2";
            this.edtBeguenstigtName2.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBeguenstigtName2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBeguenstigtName2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBeguenstigtName2.Properties.Appearance.Options.UseBackColor = true;
            this.edtBeguenstigtName2.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBeguenstigtName2.Properties.Appearance.Options.UseFont = true;
            this.edtBeguenstigtName2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBeguenstigtName2.Properties.ReadOnly = true;
            this.edtBeguenstigtName2.Size = new System.Drawing.Size(254, 24);
            this.edtBeguenstigtName2.TabIndex = 17;
            this.edtBeguenstigtName2.TabStop = false;
            //
            // edtBankName
            //
            this.edtBankName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBankName.DataMember = "BankName";
            this.edtBankName.DataSource = this.qryBuchung;
            this.edtBankName.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBankName.Location = new System.Drawing.Point(555, 432);
            this.edtBankName.Name = "edtBankName";
            this.edtBankName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBankName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBankName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBankName.Properties.Appearance.Options.UseBackColor = true;
            this.edtBankName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBankName.Properties.Appearance.Options.UseFont = true;
            this.edtBankName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBankName.Properties.ReadOnly = true;
            this.edtBankName.Size = new System.Drawing.Size(254, 24);
            this.edtBankName.TabIndex = 21;
            this.edtBankName.TabStop = false;
            //
            // edtBankKontoNr
            //
            this.edtBankKontoNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBankKontoNr.DataMember = "BankKontoNr";
            this.edtBankKontoNr.DataSource = this.qryBuchung;
            this.edtBankKontoNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBankKontoNr.Location = new System.Drawing.Point(555, 462);
            this.edtBankKontoNr.Name = "edtBankKontoNr";
            this.edtBankKontoNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBankKontoNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBankKontoNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBankKontoNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtBankKontoNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBankKontoNr.Properties.Appearance.Options.UseFont = true;
            this.edtBankKontoNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBankKontoNr.Properties.ReadOnly = true;
            this.edtBankKontoNr.Size = new System.Drawing.Size(254, 24);
            this.edtBankKontoNr.TabIndex = 22;
            this.edtBankKontoNr.TabStop = false;
            //
            // edtIBAN
            //
            this.edtIBAN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtIBAN.DataMember = "IBAN";
            this.edtIBAN.DataSource = this.qryBuchung;
            this.edtIBAN.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtIBAN.Location = new System.Drawing.Point(555, 522);
            this.edtIBAN.Name = "edtIBAN";
            this.edtIBAN.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtIBAN.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIBAN.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIBAN.Properties.Appearance.Options.UseBackColor = true;
            this.edtIBAN.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIBAN.Properties.Appearance.Options.UseFont = true;
            this.edtIBAN.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtIBAN.Properties.ReadOnly = true;
            this.edtIBAN.Size = new System.Drawing.Size(254, 24);
            this.edtIBAN.TabIndex = 24;
            this.edtIBAN.TabStop = false;
            //
            // edtPCKontoNr
            //
            this.edtPCKontoNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtPCKontoNr.DataMember = "PCKontoNr";
            this.edtPCKontoNr.DataSource = this.qryBuchung;
            this.edtPCKontoNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtPCKontoNr.Location = new System.Drawing.Point(555, 492);
            this.edtPCKontoNr.Name = "edtPCKontoNr";
            this.edtPCKontoNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPCKontoNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPCKontoNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPCKontoNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtPCKontoNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPCKontoNr.Properties.Appearance.Options.UseFont = true;
            this.edtPCKontoNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPCKontoNr.Properties.ReadOnly = true;
            this.edtPCKontoNr.Size = new System.Drawing.Size(254, 24);
            this.edtPCKontoNr.TabIndex = 23;
            this.edtPCKontoNr.TabStop = false;
            //
            // edtBuchungsDatum
            //
            this.edtBuchungsDatum.DataMember = "AusgleichBelegDatum";
            this.edtBuchungsDatum.DataSource = this.qryBuchung;
            this.edtBuchungsDatum.EditValue = null;
            this.edtBuchungsDatum.Location = new System.Drawing.Point(99, 329);
            this.edtBuchungsDatum.Name = "edtBuchungsDatum";
            this.edtBuchungsDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBuchungsDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBuchungsDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBuchungsDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchungsDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtBuchungsDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBuchungsDatum.Properties.Appearance.Options.UseFont = true;
            this.edtBuchungsDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtBuchungsDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtBuchungsDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtBuchungsDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBuchungsDatum.Properties.ShowToday = false;
            this.edtBuchungsDatum.Size = new System.Drawing.Size(146, 24);
            this.edtBuchungsDatum.TabIndex = 12;
            //
            // lblBuchungsDatum
            //
            this.lblBuchungsDatum.Location = new System.Drawing.Point(9, 329);
            this.lblBuchungsDatum.Name = "lblBuchungsDatum";
            this.lblBuchungsDatum.Size = new System.Drawing.Size(84, 24);
            this.lblBuchungsDatum.TabIndex = 16;
            this.lblBuchungsDatum.Text = "Buchungsdatum";
            this.lblBuchungsDatum.UseCompatibleTextRendering = true;
            //
            // qryAktivKonto
            //
            this.qryAktivKonto.HostControl = this;
            this.qryAktivKonto.SelectStatement = "SELECT\r\n   KbKontoId,\r\n   KbKontoartCodes,\r\n   KontoNr\r\nFROM KBKonto\r\n\r\nWHERE KbP" +
                "eriodeID = {0}\r\n AND KbZahlungskontoID = {1}";
            //
            // qryAusgleichExists
            //
            this.qryAusgleichExists.HostControl = this;
            this.qryAusgleichExists.SelectStatement = "SELECT \r\n   KbOpAusgleichID,\r\n   OpBuchungID,\r\n   AusgleichBuchungID\r\nFROM KbOpAu" +
                "sgleich\r\nWHERE OPBuchungId = {0} --1518095";
            //
            // qryZahlungskonto
            //
            this.qryZahlungskonto.HostControl = this;
            this.qryZahlungskonto.SelectStatement = resources.GetString("qryZahlungskonto.SelectStatement");
            //
            // lblSucheDatumVon
            //
            this.lblSucheDatumVon.Location = new System.Drawing.Point(30, 130);
            this.lblSucheDatumVon.Name = "lblSucheDatumVon";
            this.lblSucheDatumVon.Size = new System.Drawing.Size(100, 23);
            this.lblSucheDatumVon.TabIndex = 3;
            this.lblSucheDatumVon.Text = "Beleg Datum von";
            //
            // lblSucheBudgetNr
            //
            this.lblSucheBudgetNr.Location = new System.Drawing.Point(30, 40);
            this.lblSucheBudgetNr.Name = "lblSucheBudgetNr";
            this.lblSucheBudgetNr.Size = new System.Drawing.Size(100, 24);
            this.lblSucheBudgetNr.TabIndex = 4;
            this.lblSucheBudgetNr.Text = "Budget-Nr.";
            //
            // lblSucheBuchungId
            //
            this.lblSucheBuchungId.Location = new System.Drawing.Point(30, 70);
            this.lblSucheBuchungId.Name = "lblSucheBuchungId";
            this.lblSucheBuchungId.Size = new System.Drawing.Size(100, 24);
            this.lblSucheBuchungId.TabIndex = 5;
            this.lblSucheBuchungId.Text = "Beleg-ID";
            //
            // lblSucheDatumBis
            //
            this.lblSucheDatumBis.Location = new System.Drawing.Point(255, 130);
            this.lblSucheDatumBis.Name = "lblSucheDatumBis";
            this.lblSucheDatumBis.Size = new System.Drawing.Size(31, 24);
            this.lblSucheDatumBis.TabIndex = 6;
            this.lblSucheDatumBis.Text = "bis";
            //
            // edtSucheDatumBis
            //
            this.edtSucheDatumBis.EditValue = null;
            this.edtSucheDatumBis.Location = new System.Drawing.Point(292, 130);
            this.edtSucheDatumBis.Name = "edtSucheDatumBis";
            this.edtSucheDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtSucheDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtSucheDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheDatumBis.Properties.ShowToday = false;
            this.edtSucheDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtSucheDatumBis.TabIndex = 4;
            //
            // edtSucheDatumVon
            //
            this.edtSucheDatumVon.EditValue = null;
            this.edtSucheDatumVon.Location = new System.Drawing.Point(136, 130);
            this.edtSucheDatumVon.Name = "edtSucheDatumVon";
            this.edtSucheDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtSucheDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtSucheDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheDatumVon.Properties.ShowToday = false;
            this.edtSucheDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtSucheDatumVon.TabIndex = 3;
            //
            // edtSucheBudgetNr
            //
            this.edtSucheBudgetNr.Location = new System.Drawing.Point(136, 40);
            this.edtSucheBudgetNr.Name = "edtSucheBudgetNr";
            this.edtSucheBudgetNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBudgetNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBudgetNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBudgetNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBudgetNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBudgetNr.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBudgetNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheBudgetNr.Size = new System.Drawing.Size(256, 24);
            this.edtSucheBudgetNr.TabIndex = 0;
            //
            // edtSucheBuchungId
            //
            this.edtSucheBuchungId.Location = new System.Drawing.Point(136, 70);
            this.edtSucheBuchungId.Name = "edtSucheBuchungId";
            this.edtSucheBuchungId.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBuchungId.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBuchungId.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBuchungId.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBuchungId.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBuchungId.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBuchungId.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheBuchungId.Size = new System.Drawing.Size(256, 24);
            this.edtSucheBuchungId.TabIndex = 1;
            //
            // grdKbAuszahlungen
            //
            this.grdKbAuszahlungen.DataSource = this.qryBuchung;
            this.grdKbAuszahlungen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdKbAuszahlungen.EmbeddedNavigator.Name = "";
            this.grdKbAuszahlungen.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdKbAuszahlungen.Location = new System.Drawing.Point(0, 0);
            this.grdKbAuszahlungen.MainView = this.grvKbAuszahlungen;
            this.grdKbAuszahlungen.Name = "grdKbAuszahlungen";
            this.grdKbAuszahlungen.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repBuchungStatus});
            this.grdKbAuszahlungen.Size = new System.Drawing.Size(800, 223);
            this.grdKbAuszahlungen.TabIndex = 0;
            this.grdKbAuszahlungen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKbAuszahlungen});
            //
            // grvKbAuszahlungen
            //
            this.grvKbAuszahlungen.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvKbAuszahlungen.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbAuszahlungen.Appearance.Empty.Options.UseBackColor = true;
            this.grvKbAuszahlungen.Appearance.Empty.Options.UseFont = true;
            this.grvKbAuszahlungen.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbAuszahlungen.Appearance.EvenRow.Options.UseFont = true;
            this.grvKbAuszahlungen.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKbAuszahlungen.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbAuszahlungen.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvKbAuszahlungen.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvKbAuszahlungen.Appearance.FocusedCell.Options.UseFont = true;
            this.grvKbAuszahlungen.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvKbAuszahlungen.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKbAuszahlungen.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbAuszahlungen.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvKbAuszahlungen.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvKbAuszahlungen.Appearance.FocusedRow.Options.UseFont = true;
            this.grvKbAuszahlungen.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvKbAuszahlungen.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKbAuszahlungen.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvKbAuszahlungen.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKbAuszahlungen.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKbAuszahlungen.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKbAuszahlungen.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvKbAuszahlungen.Appearance.GroupRow.Options.UseFont = true;
            this.grvKbAuszahlungen.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvKbAuszahlungen.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvKbAuszahlungen.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvKbAuszahlungen.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKbAuszahlungen.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvKbAuszahlungen.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvKbAuszahlungen.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKbAuszahlungen.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvKbAuszahlungen.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbAuszahlungen.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKbAuszahlungen.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKbAuszahlungen.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvKbAuszahlungen.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvKbAuszahlungen.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvKbAuszahlungen.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvKbAuszahlungen.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbAuszahlungen.Appearance.OddRow.Options.UseFont = true;
            this.grvKbAuszahlungen.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKbAuszahlungen.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbAuszahlungen.Appearance.Row.Options.UseBackColor = true;
            this.grvKbAuszahlungen.Appearance.Row.Options.UseFont = true;
            this.grvKbAuszahlungen.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbAuszahlungen.Appearance.SelectedRow.Options.UseFont = true;
            this.grvKbAuszahlungen.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvKbAuszahlungen.Appearance.VertLine.Options.UseBackColor = true;
            this.grvKbAuszahlungen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvKbAuszahlungen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBuchungId,
            this.colBelegDatum,
            this.colBelegNr,
            this.colBetrag,
            this.colFalltraeger,
            this.colBuchungstext,
            this.colBuchungsstatus});
            this.grvKbAuszahlungen.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvKbAuszahlungen.GridControl = this.grdKbAuszahlungen;
            this.grvKbAuszahlungen.Name = "grvKbAuszahlungen";
            this.grvKbAuszahlungen.OptionsBehavior.Editable = false;
            this.grvKbAuszahlungen.OptionsCustomization.AllowFilter = false;
            this.grvKbAuszahlungen.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvKbAuszahlungen.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKbAuszahlungen.OptionsNavigation.UseTabKey = false;
            this.grvKbAuszahlungen.OptionsView.ColumnAutoWidth = false;
            this.grvKbAuszahlungen.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvKbAuszahlungen.OptionsView.ShowGroupPanel = false;
            this.grvKbAuszahlungen.OptionsView.ShowIndicator = false;
            //
            // colBuchungId
            //
            this.colBuchungId.Caption = "Beleg-ID";
            this.colBuchungId.Name = "colBuchungId";
            this.colBuchungId.OptionsColumn.FixedWidth = true;
            this.colBuchungId.Visible = true;
            this.colBuchungId.VisibleIndex = 0;
            this.colBuchungId.Width = 80;
            //
            // colBelegDatum
            //
            this.colBelegDatum.Caption = "Beleg Datum";
            this.colBelegDatum.Name = "colBelegDatum";
            this.colBelegDatum.OptionsColumn.FixedWidth = true;
            this.colBelegDatum.Visible = true;
            this.colBelegDatum.VisibleIndex = 1;
            this.colBelegDatum.Width = 80;
            //
            // colBelegNr
            //
            this.colBelegNr.Caption = "Beleg-Nr.";
            this.colBelegNr.Name = "colBelegNr";
            this.colBelegNr.OptionsColumn.FixedWidth = true;
            this.colBelegNr.Visible = true;
            this.colBelegNr.VisibleIndex = 2;
            this.colBelegNr.Width = 80;
            //
            // colBetrag
            //
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.DisplayFormat.FormatString = "n2";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 3;
            this.colBetrag.Width = 77;
            //
            // colFalltraeger
            //
            this.colFalltraeger.Caption = "Fallträger";
            this.colFalltraeger.Name = "colFalltraeger";
            this.colFalltraeger.Visible = true;
            this.colFalltraeger.VisibleIndex = 4;
            this.colFalltraeger.Width = 106;
            //
            // colBuchungstext
            //
            this.colBuchungstext.Caption = "Buchungstext";
            this.colBuchungstext.Name = "colBuchungstext";
            this.colBuchungstext.Visible = true;
            this.colBuchungstext.VisibleIndex = 5;
            this.colBuchungstext.Width = 169;
            //
            // colBuchungsstatus
            //
            this.colBuchungsstatus.Caption = "STAT";
            this.colBuchungsstatus.ColumnEdit = this.repBuchungStatus;
            this.colBuchungsstatus.Name = "colBuchungsstatus";
            this.colBuchungsstatus.OptionsColumn.FixedWidth = true;
            this.colBuchungsstatus.Visible = true;
            this.colBuchungsstatus.VisibleIndex = 6;
            this.colBuchungsstatus.Width = 40;
            //
            // repBuchungStatus
            //
            this.repBuchungStatus.AutoHeight = false;
            this.repBuchungStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repBuchungStatus.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repBuchungStatus.Name = "repBuchungStatus";
            //
            // lblBetrag
            //
            this.lblBetrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBetrag.Location = new System.Drawing.Point(485, 269);
            this.lblBetrag.Name = "lblBetrag";
            this.lblBetrag.Size = new System.Drawing.Size(64, 24);
            this.lblBetrag.TabIndex = 17;
            this.lblBetrag.Text = "Betrag CHF";
            this.lblBetrag.UseCompatibleTextRendering = true;
            //
            // lblBeguenstigtName
            //
            this.lblBeguenstigtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBeguenstigtName.Location = new System.Drawing.Point(485, 299);
            this.lblBeguenstigtName.Name = "lblBeguenstigtName";
            this.lblBeguenstigtName.Size = new System.Drawing.Size(64, 24);
            this.lblBeguenstigtName.TabIndex = 18;
            this.lblBeguenstigtName.Text = "Name";
            this.lblBeguenstigtName.UseCompatibleTextRendering = true;
            //
            // lblBeguenstigtZusatz
            //
            this.lblBeguenstigtZusatz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBeguenstigtZusatz.Location = new System.Drawing.Point(485, 329);
            this.lblBeguenstigtZusatz.Name = "lblBeguenstigtZusatz";
            this.lblBeguenstigtZusatz.Size = new System.Drawing.Size(64, 24);
            this.lblBeguenstigtZusatz.TabIndex = 19;
            this.lblBeguenstigtZusatz.Text = "Zusatz";
            this.lblBeguenstigtZusatz.UseCompatibleTextRendering = true;
            //
            // lblBeguenstigtPlzOrt
            //
            this.lblBeguenstigtPlzOrt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBeguenstigtPlzOrt.Location = new System.Drawing.Point(485, 359);
            this.lblBeguenstigtPlzOrt.Name = "lblBeguenstigtPlzOrt";
            this.lblBeguenstigtPlzOrt.Size = new System.Drawing.Size(64, 24);
            this.lblBeguenstigtPlzOrt.TabIndex = 20;
            this.lblBeguenstigtPlzOrt.Text = "PLZ / Ort";
            this.lblBeguenstigtPlzOrt.UseCompatibleTextRendering = true;
            //
            // lblBankName
            //
            this.lblBankName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBankName.Location = new System.Drawing.Point(485, 432);
            this.lblBankName.Name = "lblBankName";
            this.lblBankName.Size = new System.Drawing.Size(64, 24);
            this.lblBankName.TabIndex = 21;
            this.lblBankName.Text = "Name";
            this.lblBankName.UseCompatibleTextRendering = true;
            //
            // lblBankKonto
            //
            this.lblBankKonto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBankKonto.Location = new System.Drawing.Point(485, 462);
            this.lblBankKonto.Name = "lblBankKonto";
            this.lblBankKonto.Size = new System.Drawing.Size(64, 24);
            this.lblBankKonto.TabIndex = 22;
            this.lblBankKonto.Text = "Bank-Konto";
            this.lblBankKonto.UseCompatibleTextRendering = true;
            //
            // lblBankPCKonto
            //
            this.lblBankPCKonto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBankPCKonto.Location = new System.Drawing.Point(485, 492);
            this.lblBankPCKonto.Name = "lblBankPCKonto";
            this.lblBankPCKonto.Size = new System.Drawing.Size(64, 24);
            this.lblBankPCKonto.TabIndex = 23;
            this.lblBankPCKonto.Text = "PC-Konto";
            this.lblBankPCKonto.UseCompatibleTextRendering = true;
            //
            // lblBankIBAN
            //
            this.lblBankIBAN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBankIBAN.Location = new System.Drawing.Point(485, 522);
            this.lblBankIBAN.Name = "lblBankIBAN";
            this.lblBankIBAN.Size = new System.Drawing.Size(64, 24);
            this.lblBankIBAN.TabIndex = 24;
            this.lblBankIBAN.Text = "IBAN";
            this.lblBankIBAN.UseCompatibleTextRendering = true;
            //
            // lblZahlinfo
            //
            this.lblZahlinfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblZahlinfo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblZahlinfo.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblZahlinfo.Location = new System.Drawing.Point(485, 410);
            this.lblZahlinfo.Name = "lblZahlinfo";
            this.lblZahlinfo.Size = new System.Drawing.Size(64, 16);
            this.lblZahlinfo.TabIndex = 25;
            this.lblZahlinfo.Text = "Zahlinfo";
            this.lblZahlinfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblZahlinfo.UseCompatibleTextRendering = true;
            //
            // grdZugehoerigeBuchungen
            //
            this.grdZugehoerigeBuchungen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdZugehoerigeBuchungen.DataSource = this.qryZugehoerigeBuchung;
            this.grdZugehoerigeBuchungen.EmbeddedNavigator.Name = "";
            this.grdZugehoerigeBuchungen.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdZugehoerigeBuchungen.Location = new System.Drawing.Point(9, 462);
            this.grdZugehoerigeBuchungen.MainView = this.grvZugehoerigeBuchungen;
            this.grdZugehoerigeBuchungen.Name = "grdZugehoerigeBuchungen";
            this.grdZugehoerigeBuchungen.Size = new System.Drawing.Size(452, 170);
            this.grdZugehoerigeBuchungen.TabIndex = 27;
            this.grdZugehoerigeBuchungen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvZugehoerigeBuchungen});
            //
            // qryZugehoerigeBuchung
            //
            this.qryZugehoerigeBuchung.HostControl = this;
            //
            // grvZugehoerigeBuchungen
            //
            this.grvZugehoerigeBuchungen.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvZugehoerigeBuchungen.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugehoerigeBuchungen.Appearance.Empty.Options.UseBackColor = true;
            this.grvZugehoerigeBuchungen.Appearance.Empty.Options.UseFont = true;
            this.grvZugehoerigeBuchungen.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugehoerigeBuchungen.Appearance.EvenRow.Options.UseFont = true;
            this.grvZugehoerigeBuchungen.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvZugehoerigeBuchungen.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugehoerigeBuchungen.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvZugehoerigeBuchungen.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvZugehoerigeBuchungen.Appearance.FocusedCell.Options.UseFont = true;
            this.grvZugehoerigeBuchungen.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvZugehoerigeBuchungen.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvZugehoerigeBuchungen.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugehoerigeBuchungen.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvZugehoerigeBuchungen.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvZugehoerigeBuchungen.Appearance.FocusedRow.Options.UseFont = true;
            this.grvZugehoerigeBuchungen.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvZugehoerigeBuchungen.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZugehoerigeBuchungen.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvZugehoerigeBuchungen.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZugehoerigeBuchungen.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvZugehoerigeBuchungen.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZugehoerigeBuchungen.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvZugehoerigeBuchungen.Appearance.GroupRow.Options.UseFont = true;
            this.grvZugehoerigeBuchungen.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvZugehoerigeBuchungen.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvZugehoerigeBuchungen.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvZugehoerigeBuchungen.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvZugehoerigeBuchungen.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvZugehoerigeBuchungen.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvZugehoerigeBuchungen.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvZugehoerigeBuchungen.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvZugehoerigeBuchungen.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugehoerigeBuchungen.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZugehoerigeBuchungen.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvZugehoerigeBuchungen.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvZugehoerigeBuchungen.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvZugehoerigeBuchungen.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvZugehoerigeBuchungen.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvZugehoerigeBuchungen.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugehoerigeBuchungen.Appearance.OddRow.Options.UseFont = true;
            this.grvZugehoerigeBuchungen.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvZugehoerigeBuchungen.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugehoerigeBuchungen.Appearance.Row.Options.UseBackColor = true;
            this.grvZugehoerigeBuchungen.Appearance.Row.Options.UseFont = true;
            this.grvZugehoerigeBuchungen.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugehoerigeBuchungen.Appearance.SelectedRow.Options.UseFont = true;
            this.grvZugehoerigeBuchungen.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvZugehoerigeBuchungen.Appearance.VertLine.Options.UseBackColor = true;
            this.grvZugehoerigeBuchungen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvZugehoerigeBuchungen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colZugehBuchungId,
            this.colZugehBelegDatum,
            this.colZugehBelegNr,
            this.colZugehBetrag,
            this.colZugehFT,
            this.colZugehText,
            this.colZugehStat});
            this.grvZugehoerigeBuchungen.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvZugehoerigeBuchungen.GridControl = this.grdZugehoerigeBuchungen;
            this.grvZugehoerigeBuchungen.Name = "grvZugehoerigeBuchungen";
            this.grvZugehoerigeBuchungen.OptionsBehavior.Editable = false;
            this.grvZugehoerigeBuchungen.OptionsCustomization.AllowFilter = false;
            this.grvZugehoerigeBuchungen.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvZugehoerigeBuchungen.OptionsNavigation.AutoFocusNewRow = true;
            this.grvZugehoerigeBuchungen.OptionsNavigation.UseTabKey = false;
            this.grvZugehoerigeBuchungen.OptionsView.ColumnAutoWidth = false;
            this.grvZugehoerigeBuchungen.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvZugehoerigeBuchungen.OptionsView.ShowGroupPanel = false;
            this.grvZugehoerigeBuchungen.OptionsView.ShowIndicator = false;
            //
            // colZugehBuchungId
            //
            this.colZugehBuchungId.Caption = "Beleg-ID";
            this.colZugehBuchungId.Name = "colZugehBuchungId";
            this.colZugehBuchungId.OptionsColumn.FixedWidth = true;
            this.colZugehBuchungId.Visible = true;
            this.colZugehBuchungId.VisibleIndex = 0;
            //
            // colZugehBelegDatum
            //
            this.colZugehBelegDatum.Caption = "Beleg Datum";
            this.colZugehBelegDatum.Name = "colZugehBelegDatum";
            this.colZugehBelegDatum.OptionsColumn.FixedWidth = true;
            this.colZugehBelegDatum.Visible = true;
            this.colZugehBelegDatum.VisibleIndex = 1;
            this.colZugehBelegDatum.Width = 80;
            //
            // colZugehBelegNr
            //
            this.colZugehBelegNr.Caption = "Beleg-Nr.";
            this.colZugehBelegNr.Name = "colZugehBelegNr";
            this.colZugehBelegNr.OptionsColumn.FixedWidth = true;
            this.colZugehBelegNr.Visible = true;
            this.colZugehBelegNr.VisibleIndex = 2;
            //
            // colZugehBetrag
            //
            this.colZugehBetrag.Caption = "Betrag";
            this.colZugehBetrag.DisplayFormat.FormatString = "n2";
            this.colZugehBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colZugehBetrag.Name = "colZugehBetrag";
            this.colZugehBetrag.Visible = true;
            this.colZugehBetrag.VisibleIndex = 3;
            //
            // colZugehFT
            //
            this.colZugehFT.Caption = "Fallträger";
            this.colZugehFT.Name = "colZugehFT";
            this.colZugehFT.Visible = true;
            this.colZugehFT.VisibleIndex = 4;
            //
            // colZugehText
            //
            this.colZugehText.Caption = "Buchungstext";
            this.colZugehText.Name = "colZugehText";
            this.colZugehText.Visible = true;
            this.colZugehText.VisibleIndex = 5;
            this.colZugehText.Width = 117;
            //
            // colZugehStat
            //
            this.colZugehStat.Caption = "STAT";
            this.colZugehStat.ColumnEdit = this.repBuchungStatus;
            this.colZugehStat.Name = "colZugehStat";
            this.colZugehStat.OptionsColumn.FixedWidth = true;
            this.colZugehStat.Visible = true;
            this.colZugehStat.VisibleIndex = 6;
            this.colZugehStat.Width = 40;
            //
            // lblSucheFT
            //
            this.lblSucheFT.Location = new System.Drawing.Point(30, 100);
            this.lblSucheFT.Name = "lblSucheFT";
            this.lblSucheFT.Size = new System.Drawing.Size(100, 23);
            this.lblSucheFT.TabIndex = 11;
            this.lblSucheFT.Text = "Fallträger";
            //
            // edtSucheFT
            //
            this.edtSucheFT.Location = new System.Drawing.Point(136, 100);
            this.edtSucheFT.Name = "edtSucheFT";
            this.edtSucheFT.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheFT.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheFT.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheFT.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheFT.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheFT.Properties.Appearance.Options.UseFont = true;
            this.edtSucheFT.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtSucheFT.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtSucheFT.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheFT.Size = new System.Drawing.Size(256, 24);
            this.edtSucheFT.TabIndex = 2;
            this.edtSucheFT.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSucheFT_UserModifiedFld);
            //
            // edtBelegNr
            //
            this.edtBelegNr.DataSource = this.qryBuchung;
            this.edtBelegNr.Location = new System.Drawing.Point(99, 269);
            this.edtBelegNr.Name = "edtBelegNr";
            this.edtBelegNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBelegNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBelegNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBelegNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtBelegNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBelegNr.Properties.Appearance.Options.UseFont = true;
            this.edtBelegNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBelegNr.Size = new System.Drawing.Size(146, 24);
            this.edtBelegNr.TabIndex = 10;
            //
            // lblBelegNummer
            //
            this.lblBelegNummer.Location = new System.Drawing.Point(9, 269);
            this.lblBelegNummer.Name = "lblBelegNummer";
            this.lblBelegNummer.Size = new System.Drawing.Size(84, 24);
            this.lblBelegNummer.TabIndex = 29;
            this.lblBelegNummer.Text = "Beleg Nummer";
            this.lblBelegNummer.UseCompatibleTextRendering = true;
            //
            // edtBelegDatum
            //
            this.edtBelegDatum.DataSource = this.qryBuchung;
            this.edtBelegDatum.EditValue = null;
            this.edtBelegDatum.Location = new System.Drawing.Point(99, 299);
            this.edtBelegDatum.Name = "edtBelegDatum";
            this.edtBelegDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBelegDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBelegDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBelegDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBelegDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtBelegDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBelegDatum.Properties.Appearance.Options.UseFont = true;
            this.edtBelegDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtBelegDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtBelegDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtBelegDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBelegDatum.Properties.ShowToday = false;
            this.edtBelegDatum.Size = new System.Drawing.Size(146, 24);
            this.edtBelegDatum.TabIndex = 11;
            //
            // lblBelegDatum
            //
            this.lblBelegDatum.Location = new System.Drawing.Point(9, 299);
            this.lblBelegDatum.Name = "lblBelegDatum";
            this.lblBelegDatum.Size = new System.Drawing.Size(84, 24);
            this.lblBelegDatum.TabIndex = 31;
            this.lblBelegDatum.Text = "Beleg Datum";
            this.lblBelegDatum.UseCompatibleTextRendering = true;
            //
            // lblZugehoerigeBuchungTitel
            //
            this.lblZugehoerigeBuchungTitel.Location = new System.Drawing.Point(9, 436);
            this.lblZugehoerigeBuchungTitel.Name = "lblZugehoerigeBuchungTitel";
            this.lblZugehoerigeBuchungTitel.Size = new System.Drawing.Size(361, 24);
            this.lblZugehoerigeBuchungTitel.TabIndex = 32;
            this.lblZugehoerigeBuchungTitel.Text = "Alle Belege aus Budget: ";
            //
            // btnStatusReset
            //
            this.btnStatusReset.Enabled = false;
            this.btnStatusReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatusReset.Location = new System.Drawing.Point(99, 396);
            this.btnStatusReset.Name = "btnStatusReset";
            this.btnStatusReset.Size = new System.Drawing.Size(117, 24);
            this.btnStatusReset.TabIndex = 33;
            this.btnStatusReset.Text = "Zurücksetzen";
            this.btnStatusReset.UseCompatibleTextRendering = true;
            this.btnStatusReset.UseVisualStyleBackColor = false;
            this.btnStatusReset.Click += new System.EventHandler(this.btnStatusReset_Click);
            //
            // CtlKbAuszahlungVerbuchen
            //
            this.ActiveSQLQuery = this.qryBuchung;
            this.Controls.Add(this.btnStatusReset);
            this.Controls.Add(this.lblZugehoerigeBuchungTitel);
            this.Controls.Add(this.lblBelegDatum);
            this.Controls.Add(this.edtBelegDatum);
            this.Controls.Add(this.lblBelegNummer);
            this.Controls.Add(this.edtBelegNr);
            this.Controls.Add(this.grdZugehoerigeBuchungen);
            this.Controls.Add(this.lblZahlinfo);
            this.Controls.Add(this.lblBankIBAN);
            this.Controls.Add(this.lblBankPCKonto);
            this.Controls.Add(this.lblBankKonto);
            this.Controls.Add(this.lblBankName);
            this.Controls.Add(this.lblBeguenstigtPlzOrt);
            this.Controls.Add(this.lblBeguenstigtZusatz);
            this.Controls.Add(this.lblBeguenstigtName);
            this.Controls.Add(this.lblBetrag);
            this.Controls.Add(this.lblBuchungsDatum);
            this.Controls.Add(this.edtBuchungsDatum);
            this.Controls.Add(this.edtPCKontoNr);
            this.Controls.Add(this.edtIBAN);
            this.Controls.Add(this.edtBankKontoNr);
            this.Controls.Add(this.edtBankName);
            this.Controls.Add(this.edtBeguenstigtName2);
            this.Controls.Add(this.edtBetrag);
            this.Controls.Add(this.edtBeguenstigtOrt);
            this.Controls.Add(this.edtBeguenstigtPLZ);
            this.Controls.Add(this.edtBeguenstigtName);
            this.Controls.Add(this.btnVerbuchen);
            this.Controls.Add(this.edtKbZahlungskonto);
            this.Controls.Add(this.lblKbZahlungskonto);
            this.Name = "CtlKbAuszahlungVerbuchen";
            this.Size = new System.Drawing.Size(818, 645);
            this.Load += new System.EventHandler(this.CtlKbAuszahlungVerbuchen_Load);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.lblKbZahlungskonto, 0);
            this.Controls.SetChildIndex(this.edtKbZahlungskonto, 0);
            this.Controls.SetChildIndex(this.btnVerbuchen, 0);
            this.Controls.SetChildIndex(this.edtBeguenstigtName, 0);
            this.Controls.SetChildIndex(this.edtBeguenstigtPLZ, 0);
            this.Controls.SetChildIndex(this.edtBeguenstigtOrt, 0);
            this.Controls.SetChildIndex(this.edtBetrag, 0);
            this.Controls.SetChildIndex(this.edtBeguenstigtName2, 0);
            this.Controls.SetChildIndex(this.edtBankName, 0);
            this.Controls.SetChildIndex(this.edtBankKontoNr, 0);
            this.Controls.SetChildIndex(this.edtIBAN, 0);
            this.Controls.SetChildIndex(this.edtPCKontoNr, 0);
            this.Controls.SetChildIndex(this.edtBuchungsDatum, 0);
            this.Controls.SetChildIndex(this.lblBuchungsDatum, 0);
            this.Controls.SetChildIndex(this.lblBetrag, 0);
            this.Controls.SetChildIndex(this.lblBeguenstigtName, 0);
            this.Controls.SetChildIndex(this.lblBeguenstigtZusatz, 0);
            this.Controls.SetChildIndex(this.lblBeguenstigtPlzOrt, 0);
            this.Controls.SetChildIndex(this.lblBankName, 0);
            this.Controls.SetChildIndex(this.lblBankKonto, 0);
            this.Controls.SetChildIndex(this.lblBankPCKonto, 0);
            this.Controls.SetChildIndex(this.lblBankIBAN, 0);
            this.Controls.SetChildIndex(this.lblZahlinfo, 0);
            this.Controls.SetChildIndex(this.grdZugehoerigeBuchungen, 0);
            this.Controls.SetChildIndex(this.edtBelegNr, 0);
            this.Controls.SetChildIndex(this.lblBelegNummer, 0);
            this.Controls.SetChildIndex(this.edtBelegDatum, 0);
            this.Controls.SetChildIndex(this.lblBelegDatum, 0);
            this.Controls.SetChildIndex(this.lblZugehoerigeBuchungTitel, 0);
            this.Controls.SetChildIndex(this.btnStatusReset, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qryBuchung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPeriodeX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPeriode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKbZahlungskonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKbZahlungskonto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKbZahlungskonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeguenstigtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeguenstigtPLZ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeguenstigtOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeguenstigtName2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBankName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBankKontoNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIBAN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPCKontoNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungsDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungsDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryAktivKonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryAusgleichExists)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZahlungskonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBudgetNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBuchungId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBudgetNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBuchungId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKbAuszahlungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKbAuszahlungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repBuchungStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeguenstigtName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeguenstigtZusatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeguenstigtPlzOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBankName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBankKonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBankPCKonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBankIBAN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlinfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZugehoerigeBuchungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugehoerigeBuchung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZugehoerigeBuchungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheFT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBelegNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegNummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBelegDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZugehoerigeBuchungTitel)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private KiSS4.Gui.KissButton btnStatusReset;
        private KiSS4.Gui.KissButton btnVerbuchen;
        private DevExpress.XtraGrid.Columns.GridColumn colBelegDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colBelegNr;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungId;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungsstatus;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungstext;
        private DevExpress.XtraGrid.Columns.GridColumn colFalltraeger;
        private DevExpress.XtraGrid.Columns.GridColumn colZugehBelegDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colZugehBelegNr;
        private DevExpress.XtraGrid.Columns.GridColumn colZugehBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colZugehBuchungId;
        private DevExpress.XtraGrid.Columns.GridColumn colZugehFT;
        private DevExpress.XtraGrid.Columns.GridColumn colZugehStat;
        private DevExpress.XtraGrid.Columns.GridColumn colZugehText;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissTextEdit edtBankKontoNr;
        private KiSS4.Gui.KissTextEdit edtBankName;
        private KiSS4.Gui.KissTextEdit edtBeguenstigtName;
        private KiSS4.Gui.KissTextEdit edtBeguenstigtName2;
        private KiSS4.Gui.KissTextEdit edtBeguenstigtOrt;
        private KiSS4.Gui.KissTextEdit edtBeguenstigtPLZ;
        private KiSS4.Gui.KissDateEdit edtBelegDatum;
        private KiSS4.Gui.KissTextEdit edtBelegNr;
        private KiSS4.Gui.KissCalcEdit edtBetrag;
        private KiSS4.Gui.KissDateEdit edtBuchungsDatum;
        private KiSS4.Gui.KissTextEdit edtIBAN;
        private KiSS4.Gui.KissLookUpEdit edtKbZahlungskonto;
        private KiSS4.Gui.KissTextEdit edtPCKontoNr;
        private KiSS4.Gui.KissTextEdit edtPeriodeX;
        private KiSS4.Gui.KissTextEdit edtSucheBuchungId;
        private KiSS4.Gui.KissTextEdit edtSucheBudgetNr;
        private KiSS4.Gui.KissDateEdit edtSucheDatumBis;
        private KiSS4.Gui.KissDateEdit edtSucheDatumVon;
        private KiSS4.Gui.KissButtonEdit edtSucheFT;
        private KiSS4.Gui.KissGrid grdKbAuszahlungen;
        private KiSS4.Gui.KissGrid grdZugehoerigeBuchungen;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKbAuszahlungen;
        private DevExpress.XtraGrid.Views.Grid.GridView grvZugehoerigeBuchungen;
        private KiSS4.Gui.KissLabel lblBankIBAN;
        private KiSS4.Gui.KissLabel lblBankKonto;
        private KiSS4.Gui.KissLabel lblBankName;
        private KiSS4.Gui.KissLabel lblBankPCKonto;
        private KiSS4.Gui.KissLabel lblBeguenstigtName;
        private KiSS4.Gui.KissLabel lblBeguenstigtPlzOrt;
        private KiSS4.Gui.KissLabel lblBeguenstigtZusatz;
        private KiSS4.Gui.KissLabel lblBelegDatum;
        private KiSS4.Gui.KissLabel lblBelegNummer;
        private KiSS4.Gui.KissLabel lblBetrag;
        private KiSS4.Gui.KissLabel lblBuchungsDatum;
        private KiSS4.Gui.KissLabel lblKbZahlungskonto;
        private KiSS4.Gui.KissLabel lblPeriode;
        private KiSS4.Gui.KissLabel lblSucheBuchungId;
        private KiSS4.Gui.KissLabel lblSucheBudgetNr;
        private KiSS4.Gui.KissLabel lblSucheDatumBis;
        private KiSS4.Gui.KissLabel lblSucheDatumVon;
        private KiSS4.Gui.KissLabel lblSucheFT;
        private KiSS4.Gui.KissLabel lblZahlinfo;
        private KiSS4.Gui.KissLabel lblZugehoerigeBuchungTitel;
        private KiSS4.DB.SqlQuery qryAktivKonto;
        private KiSS4.DB.SqlQuery qryAusgleichExists;
        private KiSS4.DB.SqlQuery qryBuchung;
        private KiSS4.DB.SqlQuery qryZahlungskonto;
        private KiSS4.DB.SqlQuery qryZugehoerigeBuchung;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repBuchungStatus;
    }
}
