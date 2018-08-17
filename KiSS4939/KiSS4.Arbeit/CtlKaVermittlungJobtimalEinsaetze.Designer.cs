namespace KiSS4.Arbeit
{
    partial class CtlKaVermittlungJobtimalEinsaetze
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKaVermittlungJobtimalEinsaetze));
            this.tabEinsaetze = new KiSS4.Gui.KissTabControlEx();
            this.tpgEinsatz = new SharpLibrary.WinControls.TabPageEx();
            this.lblEinsatzende = new KiSS4.Gui.KissLabel();
            this.lblBemerkungen = new KiSS4.Gui.KissLabel();
            this.lblAbschlussDurch = new KiSS4.Gui.KissLabel();
            this.lblLeistungsfaehigkeit = new KiSS4.Gui.KissLabel();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.lblProzent = new KiSS4.Gui.KissLabel();
            this.lblArbeitspensum = new KiSS4.Gui.KissLabel();
            this.lblEinsatzab = new KiSS4.Gui.KissLabel();
            this.edtEinsatzBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.qryJobtimalEinsatz = new KiSS4.DB.SqlQuery(this.components);
            this.edtAbschlussGrund = new KiSS4.Gui.KissLookUpEdit();
            this.edtAbschlussDurch = new KiSS4.Gui.KissLookUpEdit();
            this.edtEinsatzende = new KiSS4.Gui.KissDateEdit();
            this.lblGrund = new KiSS4.Gui.KissLabel();
            this.edtPensumErgänzungen = new KiSS4.Gui.KissCalcEdit();
            this.edtPensum = new KiSS4.Gui.KissCalcEdit();
            this.lblEinsatzendeDatum = new KiSS4.Gui.KissLabel();
            this.edtEinsatzAb = new KiSS4.Gui.KissDateEdit();
            this.tpgVertrag = new SharpLibrary.WinControls.TabPageEx();
            this.edtDocument = new KiSS4.Dokument.XDokument();
            this.qryJobtimalVertrag = new KiSS4.DB.SqlQuery(this.components);
            this.grdVertrag = new KiSS4.Gui.KissGrid();
            this.grvVertrag = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDokumentTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblVertragTyp = new KiSS4.Gui.KissLabel();
            this.lblDatum = new KiSS4.Gui.KissLabel();
            this.edtVertragTyp = new KiSS4.Gui.KissLookUpEdit();
            this.edtDatum = new KiSS4.Gui.KissDateEdit();
            this.qryJobtimalVorschlag = new KiSS4.DB.SqlQuery(this.components);
            this.pnTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new KiSS4.Gui.KissLabel();
            this.imageTitle = new System.Windows.Forms.PictureBox();
            this.lblEinsatzplatz = new KiSS4.Gui.KissLabel();
            this.lblBetrieb = new KiSS4.Gui.KissLabel();
            this.lbKontaktperson = new KiSS4.Gui.KissLabel();
            this.grdVermittlungJobtimalEinsaetze = new KiSS4.Gui.KissGrid();
            this.grvVermittlungJobtimalEinsaetze = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEinsatzVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBezeichnung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrieb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPensum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinsatzende = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtEinsatzplatz = new KiSS4.Gui.KissTextEdit();
            this.edtBetrieb = new KiSS4.Gui.KissTextEdit();
            this.edtKontaktperson = new KiSS4.Gui.KissTextEdit();
            this.btnDetailsEinsatzplatz = new KiSS4.Gui.KissButton();
            this.lblEinsatzplatzNr = new KiSS4.Gui.KissLabel();
            this.edtEinsatzplatzNr = new KiSS4.Gui.KissTextEdit();
            this.tabEinsaetze.SuspendLayout();
            this.tpgEinsatz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzende)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschlussDurch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeistungsfaehigkeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProzent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblArbeitspensum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryJobtimalEinsatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrund.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussDurch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussDurch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzende.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPensumErgänzungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPensum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzendeDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzAb.Properties)).BeginInit();
            this.tpgVertrag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtDocument.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryJobtimalVertrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVertrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVertrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVertragTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVertragTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVertragTyp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryJobtimalVorschlag)).BeginInit();
            this.pnTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzplatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrieb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbKontaktperson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVermittlungJobtimalEinsaetze)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVermittlungJobtimalEinsaetze)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzplatz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrieb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktperson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzplatzNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzplatzNr.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tabEinsaetze
            // 
            this.tabEinsaetze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tabEinsaetze.Controls.Add(this.tpgEinsatz);
            this.tabEinsaetze.Controls.Add(this.tpgVertrag);
            this.tabEinsaetze.Location = new System.Drawing.Point(0, 285);
            this.tabEinsaetze.Name = "tabEinsaetze";
            this.tabEinsaetze.ShowFixedWidthTooltip = true;
            this.tabEinsaetze.Size = new System.Drawing.Size(719, 272);
            this.tabEinsaetze.TabIndex = 11;
            this.tabEinsaetze.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgEinsatz,
            this.tpgVertrag});
            this.tabEinsaetze.TabsLineColor = System.Drawing.Color.Black;
            this.tabEinsaetze.TabsLocation = SharpLibrary.WinControls.TabsLocation.Top;
            this.tabEinsaetze.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabEinsaetze.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabEinsaetze_SelectedTabChanged);
            this.tabEinsaetze.SelectedTabChanging += new System.ComponentModel.CancelEventHandler(this.tabEinsaetze_SelectedTabChanging);
            // 
            // tpgEinsatz
            // 
            this.tpgEinsatz.Controls.Add(this.lblEinsatzende);
            this.tpgEinsatz.Controls.Add(this.lblBemerkungen);
            this.tpgEinsatz.Controls.Add(this.lblAbschlussDurch);
            this.tpgEinsatz.Controls.Add(this.lblLeistungsfaehigkeit);
            this.tpgEinsatz.Controls.Add(this.kissLabel1);
            this.tpgEinsatz.Controls.Add(this.lblProzent);
            this.tpgEinsatz.Controls.Add(this.lblArbeitspensum);
            this.tpgEinsatz.Controls.Add(this.lblEinsatzab);
            this.tpgEinsatz.Controls.Add(this.edtEinsatzBemerkung);
            this.tpgEinsatz.Controls.Add(this.edtAbschlussGrund);
            this.tpgEinsatz.Controls.Add(this.edtAbschlussDurch);
            this.tpgEinsatz.Controls.Add(this.edtEinsatzende);
            this.tpgEinsatz.Controls.Add(this.lblGrund);
            this.tpgEinsatz.Controls.Add(this.edtPensumErgänzungen);
            this.tpgEinsatz.Controls.Add(this.edtPensum);
            this.tpgEinsatz.Controls.Add(this.lblEinsatzendeDatum);
            this.tpgEinsatz.Controls.Add(this.edtEinsatzAb);
            this.tpgEinsatz.Location = new System.Drawing.Point(6, 32);
            this.tpgEinsatz.Name = "tpgEinsatz";
            this.tpgEinsatz.Size = new System.Drawing.Size(707, 234);
            this.tpgEinsatz.TabIndex = 0;
            this.tpgEinsatz.Title = "Einsatz";
            // 
            // lblEinsatzende
            // 
            this.lblEinsatzende.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblEinsatzende.Location = new System.Drawing.Point(5, 82);
            this.lblEinsatzende.Name = "lblEinsatzende";
            this.lblEinsatzende.Size = new System.Drawing.Size(89, 16);
            this.lblEinsatzende.TabIndex = 10;
            this.lblEinsatzende.Text = "Einsatzende";
            this.lblEinsatzende.UseCompatibleTextRendering = true;
            // 
            // lblBemerkungen
            // 
            this.lblBemerkungen.Location = new System.Drawing.Point(5, 171);
            this.lblBemerkungen.Name = "lblBemerkungen";
            this.lblBemerkungen.Size = new System.Drawing.Size(76, 24);
            this.lblBemerkungen.TabIndex = 19;
            this.lblBemerkungen.Text = "Bemerkungen";
            this.lblBemerkungen.UseCompatibleTextRendering = true;
            // 
            // lblAbschlussDurch
            // 
            this.lblAbschlussDurch.Location = new System.Drawing.Point(203, 101);
            this.lblAbschlussDurch.Name = "lblAbschlussDurch";
            this.lblAbschlussDurch.Size = new System.Drawing.Size(35, 24);
            this.lblAbschlussDurch.TabIndex = 13;
            this.lblAbschlussDurch.Text = "durch";
            this.lblAbschlussDurch.UseCompatibleTextRendering = true;
            // 
            // lblLeistungsfaehigkeit
            // 
            this.lblLeistungsfaehigkeit.Location = new System.Drawing.Point(216, 40);
            this.lblLeistungsfaehigkeit.Name = "lblLeistungsfaehigkeit";
            this.lblLeistungsfaehigkeit.Size = new System.Drawing.Size(107, 24);
            this.lblLeistungsfaehigkeit.TabIndex = 8;
            this.lblLeistungsfaehigkeit.Text = "Leistungsfähigkeit";
            this.lblLeistungsfaehigkeit.UseCompatibleTextRendering = true;
            // 
            // kissLabel1
            // 
            this.kissLabel1.Location = new System.Drawing.Point(375, 40);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(19, 24);
            this.kissLabel1.TabIndex = 7;
            this.kissLabel1.Text = "%";
            this.kissLabel1.UseCompatibleTextRendering = true;
            // 
            // lblProzent
            // 
            this.lblProzent.Location = new System.Drawing.Point(137, 40);
            this.lblProzent.Name = "lblProzent";
            this.lblProzent.Size = new System.Drawing.Size(19, 24);
            this.lblProzent.TabIndex = 7;
            this.lblProzent.Text = "%";
            this.lblProzent.UseCompatibleTextRendering = true;
            // 
            // lblArbeitspensum
            // 
            this.lblArbeitspensum.Location = new System.Drawing.Point(5, 40);
            this.lblArbeitspensum.Name = "lblArbeitspensum";
            this.lblArbeitspensum.Size = new System.Drawing.Size(80, 24);
            this.lblArbeitspensum.TabIndex = 5;
            this.lblArbeitspensum.Text = "Arbeitspensum";
            this.lblArbeitspensum.UseCompatibleTextRendering = true;
            // 
            // lblEinsatzab
            // 
            this.lblEinsatzab.Location = new System.Drawing.Point(5, 10);
            this.lblEinsatzab.Name = "lblEinsatzab";
            this.lblEinsatzab.Size = new System.Drawing.Size(80, 24);
            this.lblEinsatzab.TabIndex = 0;
            this.lblEinsatzab.Text = "Einsatz ab";
            this.lblEinsatzab.UseCompatibleTextRendering = true;
            // 
            // edtEinsatzBemerkung
            // 
            this.edtEinsatzBemerkung.DataMember = "EinsatzBemerkungen";
            this.edtEinsatzBemerkung.DataSource = this.qryJobtimalEinsatz;
            this.edtEinsatzBemerkung.Location = new System.Drawing.Point(91, 171);
            this.edtEinsatzBemerkung.Name = "edtEinsatzBemerkung";
            this.edtEinsatzBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEinsatzBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinsatzBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinsatzBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinsatzBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinsatzBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtEinsatzBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEinsatzBemerkung.Size = new System.Drawing.Size(613, 60);
            this.edtEinsatzBemerkung.TabIndex = 20;
            // 
            // qryJobtimalEinsatz
            // 
            this.qryJobtimalEinsatz.CanDelete = true;
            this.qryJobtimalEinsatz.CanUpdate = true;
            this.qryJobtimalEinsatz.HostControl = this;
            this.qryJobtimalEinsatz.IsIdentityInsert = false;
            this.qryJobtimalEinsatz.SelectStatement = "SELECT\tVEI.*\r\nFROM KaVermittlungEinsatz VEI\r\nWHERE VEI.KaVermittlungVorschlagID =" +
    " {0}";
            this.qryJobtimalEinsatz.TableName = "KaVermittlungEinsatz";
            this.qryJobtimalEinsatz.BeforePost += new System.EventHandler(this.qryJobtimalEinsatz_BeforePost);
            this.qryJobtimalEinsatz.ColumnChanging += new System.Data.DataColumnChangeEventHandler(this.qryJobtimalEinsatz_ColumnChanging);
            // 
            // edtAbschlussGrund
            // 
            this.edtAbschlussGrund.DataMember = "SIAbschlussGrundCode";
            this.edtAbschlussGrund.DataSource = this.qryJobtimalEinsatz;
            this.edtAbschlussGrund.Location = new System.Drawing.Point(91, 131);
            this.edtAbschlussGrund.LOVName = "KaJobtimalEinsatzendeGrund";
            this.edtAbschlussGrund.Name = "edtAbschlussGrund";
            this.edtAbschlussGrund.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAbschlussGrund.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAbschlussGrund.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbschlussGrund.Properties.Appearance.Options.UseBackColor = true;
            this.edtAbschlussGrund.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAbschlussGrund.Properties.Appearance.Options.UseFont = true;
            this.edtAbschlussGrund.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAbschlussGrund.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbschlussGrund.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAbschlussGrund.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAbschlussGrund.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtAbschlussGrund.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtAbschlussGrund.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAbschlussGrund.Properties.NullText = "";
            this.edtAbschlussGrund.Properties.ShowFooter = false;
            this.edtAbschlussGrund.Properties.ShowHeader = false;
            this.edtAbschlussGrund.Size = new System.Drawing.Size(303, 24);
            this.edtAbschlussGrund.TabIndex = 16;
            // 
            // edtAbschlussDurch
            // 
            this.edtAbschlussDurch.DataMember = "BIBIPSIAbschlussDurchCode";
            this.edtAbschlussDurch.DataSource = this.qryJobtimalEinsatz;
            this.edtAbschlussDurch.Location = new System.Drawing.Point(244, 101);
            this.edtAbschlussDurch.LOVName = "KaVermittlungEinsatzAbschlussDurch";
            this.edtAbschlussDurch.Name = "edtAbschlussDurch";
            this.edtAbschlussDurch.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAbschlussDurch.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAbschlussDurch.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbschlussDurch.Properties.Appearance.Options.UseBackColor = true;
            this.edtAbschlussDurch.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAbschlussDurch.Properties.Appearance.Options.UseFont = true;
            this.edtAbschlussDurch.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAbschlussDurch.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbschlussDurch.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAbschlussDurch.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAbschlussDurch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtAbschlussDurch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtAbschlussDurch.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAbschlussDurch.Properties.NullText = "";
            this.edtAbschlussDurch.Properties.ShowFooter = false;
            this.edtAbschlussDurch.Properties.ShowHeader = false;
            this.edtAbschlussDurch.Size = new System.Drawing.Size(150, 24);
            this.edtAbschlussDurch.TabIndex = 14;
            // 
            // edtEinsatzende
            // 
            this.edtEinsatzende.DataMember = "Abschluss";
            this.edtEinsatzende.DataSource = this.qryJobtimalEinsatz;
            this.edtEinsatzende.EditValue = null;
            this.edtEinsatzende.Location = new System.Drawing.Point(91, 101);
            this.edtEinsatzende.Name = "edtEinsatzende";
            this.edtEinsatzende.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtEinsatzende.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEinsatzende.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinsatzende.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinsatzende.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinsatzende.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinsatzende.Properties.Appearance.Options.UseFont = true;
            this.edtEinsatzende.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtEinsatzende.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEinsatzende.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtEinsatzende.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEinsatzende.Properties.ShowToday = false;
            this.edtEinsatzende.Size = new System.Drawing.Size(96, 24);
            this.edtEinsatzende.TabIndex = 12;
            // 
            // lblGrund
            // 
            this.lblGrund.Location = new System.Drawing.Point(5, 132);
            this.lblGrund.Name = "lblGrund";
            this.lblGrund.Size = new System.Drawing.Size(74, 24);
            this.lblGrund.TabIndex = 15;
            this.lblGrund.Text = "Grund";
            this.lblGrund.UseCompatibleTextRendering = true;
            // 
            // edtPensumErgänzungen
            // 
            this.edtPensumErgänzungen.DataMember = "Leistungsfaehigkeit";
            this.edtPensumErgänzungen.DataSource = this.qryJobtimalEinsatz;
            this.edtPensumErgänzungen.Location = new System.Drawing.Point(329, 40);
            this.edtPensumErgänzungen.Name = "edtPensumErgänzungen";
            this.edtPensumErgänzungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPensumErgänzungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPensumErgänzungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPensumErgänzungen.Properties.Appearance.Options.UseBackColor = true;
            this.edtPensumErgänzungen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPensumErgänzungen.Properties.Appearance.Options.UseFont = true;
            this.edtPensumErgänzungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPensumErgänzungen.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPensumErgänzungen.Properties.Mask.EditMask = "##,###,##0.##";
            this.edtPensumErgänzungen.Size = new System.Drawing.Size(40, 24);
            this.edtPensumErgänzungen.TabIndex = 9;
            // 
            // edtPensum
            // 
            this.edtPensum.DataMember = "Arbeitspensum";
            this.edtPensum.DataSource = this.qryJobtimalEinsatz;
            this.edtPensum.Location = new System.Drawing.Point(91, 40);
            this.edtPensum.Name = "edtPensum";
            this.edtPensum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtPensum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPensum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPensum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPensum.Properties.Appearance.Options.UseBackColor = true;
            this.edtPensum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPensum.Properties.Appearance.Options.UseFont = true;
            this.edtPensum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPensum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPensum.Properties.Mask.EditMask = "##,###,##0.##";
            this.edtPensum.Size = new System.Drawing.Size(40, 24);
            this.edtPensum.TabIndex = 6;
            this.edtPensum.Leave += new System.EventHandler(this.edtPensum_Leave);
            // 
            // lblEinsatzendeDatum
            // 
            this.lblEinsatzendeDatum.Location = new System.Drawing.Point(5, 101);
            this.lblEinsatzendeDatum.Name = "lblEinsatzendeDatum";
            this.lblEinsatzendeDatum.Size = new System.Drawing.Size(66, 24);
            this.lblEinsatzendeDatum.TabIndex = 11;
            this.lblEinsatzendeDatum.Text = "Datum";
            this.lblEinsatzendeDatum.UseCompatibleTextRendering = true;
            // 
            // edtEinsatzAb
            // 
            this.edtEinsatzAb.DataMember = "EinsatzVon";
            this.edtEinsatzAb.DataSource = this.qryJobtimalEinsatz;
            this.edtEinsatzAb.EditValue = null;
            this.edtEinsatzAb.Location = new System.Drawing.Point(91, 10);
            this.edtEinsatzAb.Name = "edtEinsatzAb";
            this.edtEinsatzAb.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtEinsatzAb.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEinsatzAb.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinsatzAb.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinsatzAb.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinsatzAb.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinsatzAb.Properties.Appearance.Options.UseFont = true;
            this.edtEinsatzAb.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtEinsatzAb.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEinsatzAb.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtEinsatzAb.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEinsatzAb.Properties.ShowToday = false;
            this.edtEinsatzAb.Size = new System.Drawing.Size(96, 24);
            this.edtEinsatzAb.TabIndex = 1;
            // 
            // tpgVertrag
            // 
            this.tpgVertrag.Controls.Add(this.edtDocument);
            this.tpgVertrag.Controls.Add(this.grdVertrag);
            this.tpgVertrag.Controls.Add(this.lblVertragTyp);
            this.tpgVertrag.Controls.Add(this.lblDatum);
            this.tpgVertrag.Controls.Add(this.edtVertragTyp);
            this.tpgVertrag.Controls.Add(this.edtDatum);
            this.tpgVertrag.Location = new System.Drawing.Point(6, 32);
            this.tpgVertrag.Name = "tpgVertrag";
            this.tpgVertrag.Size = new System.Drawing.Size(707, 234);
            this.tpgVertrag.TabIndex = 1;
            this.tpgVertrag.Title = "Verträge";
            // 
            // edtDocument
            // 
            this.edtDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDocument.Context = "KaJobtimalVertrag";
            this.edtDocument.DataMember = "DocumentID";
            this.edtDocument.DataSource = this.qryJobtimalVertrag;
            this.edtDocument.Location = new System.Drawing.Point(446, 207);
            this.edtDocument.Name = "edtDocument";
            this.edtDocument.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDocument.Properties.Appearance.Options.UseBackColor = true;
            this.edtDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDocument.Properties.Appearance.Options.UseFont = true;
            this.edtDocument.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtDocument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocument.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocument.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocument.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8, "Dokument importieren")});
            this.edtDocument.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDocument.Properties.ReadOnly = true;
            this.edtDocument.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtDocument.Size = new System.Drawing.Size(120, 24);
            this.edtDocument.TabIndex = 19;
            // 
            // qryJobtimalVertrag
            // 
            this.qryJobtimalVertrag.CanDelete = true;
            this.qryJobtimalVertrag.CanInsert = true;
            this.qryJobtimalVertrag.CanUpdate = true;
            this.qryJobtimalVertrag.HostControl = this;
            this.qryJobtimalVertrag.IsIdentityInsert = false;
            this.qryJobtimalVertrag.SelectStatement = "SELECT\tVER.*       \r\nFROM KaJobtimalVertrag VER\t\r\nWHERE VER.KaVermittlungVorschla" +
    "gID = {0}";
            this.qryJobtimalVertrag.TableName = "KaJobtimalVertrag";
            this.qryJobtimalVertrag.AfterInsert += new System.EventHandler(this.qryJobtimalZwischenbericht_AfterInsert);
            // 
            // grdVertrag
            // 
            this.grdVertrag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdVertrag.DataSource = this.qryJobtimalVertrag;
            // 
            // 
            // 
            this.grdVertrag.EmbeddedNavigator.Name = "";
            this.grdVertrag.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdVertrag.Location = new System.Drawing.Point(-2, 0);
            this.grdVertrag.MainView = this.grvVertrag;
            this.grdVertrag.Name = "grdVertrag";
            this.grdVertrag.Size = new System.Drawing.Size(709, 201);
            this.grdVertrag.TabIndex = 0;
            this.grdVertrag.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVertrag});
            // 
            // grvVertrag
            // 
            this.grvVertrag.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvVertrag.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVertrag.Appearance.Empty.Options.UseBackColor = true;
            this.grvVertrag.Appearance.Empty.Options.UseFont = true;
            this.grvVertrag.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVertrag.Appearance.EvenRow.Options.UseFont = true;
            this.grvVertrag.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVertrag.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVertrag.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvVertrag.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvVertrag.Appearance.FocusedCell.Options.UseFont = true;
            this.grvVertrag.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvVertrag.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVertrag.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVertrag.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvVertrag.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvVertrag.Appearance.FocusedRow.Options.UseFont = true;
            this.grvVertrag.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvVertrag.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVertrag.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvVertrag.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvVertrag.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvVertrag.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVertrag.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvVertrag.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVertrag.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVertrag.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVertrag.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvVertrag.Appearance.GroupRow.Options.UseFont = true;
            this.grvVertrag.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvVertrag.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvVertrag.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvVertrag.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVertrag.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvVertrag.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvVertrag.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvVertrag.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvVertrag.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVertrag.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVertrag.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvVertrag.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvVertrag.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvVertrag.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvVertrag.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvVertrag.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVertrag.Appearance.OddRow.Options.UseFont = true;
            this.grvVertrag.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvVertrag.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVertrag.Appearance.Row.Options.UseBackColor = true;
            this.grvVertrag.Appearance.Row.Options.UseFont = true;
            this.grvVertrag.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVertrag.Appearance.SelectedRow.Options.UseFont = true;
            this.grvVertrag.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvVertrag.Appearance.VertLine.Options.UseBackColor = true;
            this.grvVertrag.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvVertrag.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatum,
            this.colDokumentTyp});
            this.grvVertrag.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvVertrag.GridControl = this.grdVertrag;
            this.grvVertrag.Name = "grvVertrag";
            this.grvVertrag.OptionsBehavior.Editable = false;
            this.grvVertrag.OptionsCustomization.AllowFilter = false;
            this.grvVertrag.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvVertrag.OptionsNavigation.AutoFocusNewRow = true;
            this.grvVertrag.OptionsNavigation.UseTabKey = false;
            this.grvVertrag.OptionsView.ColumnAutoWidth = false;
            this.grvVertrag.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvVertrag.OptionsView.ShowGroupPanel = false;
            this.grvVertrag.OptionsView.ShowIndicator = false;
            // 
            // colDatum
            // 
            this.colDatum.Caption = "Datum";
            this.colDatum.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.colDatum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDatum.FieldName = "Datum";
            this.colDatum.Name = "colDatum";
            this.colDatum.Visible = true;
            this.colDatum.VisibleIndex = 0;
            this.colDatum.Width = 99;
            // 
            // colDokumentTyp
            // 
            this.colDokumentTyp.Caption = "Dokument";
            this.colDokumentTyp.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.colDokumentTyp.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDokumentTyp.FieldName = "KaJobtimalVertragTypCode";
            this.colDokumentTyp.Name = "colDokumentTyp";
            this.colDokumentTyp.Visible = true;
            this.colDokumentTyp.VisibleIndex = 1;
            this.colDokumentTyp.Width = 151;
            // 
            // lblVertragTyp
            // 
            this.lblVertragTyp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVertragTyp.Location = new System.Drawing.Point(158, 207);
            this.lblVertragTyp.Name = "lblVertragTyp";
            this.lblVertragTyp.Size = new System.Drawing.Size(70, 24);
            this.lblVertragTyp.TabIndex = 9;
            this.lblVertragTyp.Text = "Vertrag-Typ";
            this.lblVertragTyp.UseCompatibleTextRendering = true;
            // 
            // lblDatum
            // 
            this.lblDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDatum.Location = new System.Drawing.Point(0, 207);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(43, 24);
            this.lblDatum.TabIndex = 1;
            this.lblDatum.Text = "Datum";
            this.lblDatum.UseCompatibleTextRendering = true;
            // 
            // edtVertragTyp
            // 
            this.edtVertragTyp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtVertragTyp.DataMember = "KaJobtimalVertragTypCode";
            this.edtVertragTyp.DataSource = this.qryJobtimalVertrag;
            this.edtVertragTyp.Location = new System.Drawing.Point(234, 207);
            this.edtVertragTyp.LOVName = "KaJobtimalVertragTyp";
            this.edtVertragTyp.Name = "edtVertragTyp";
            this.edtVertragTyp.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVertragTyp.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVertragTyp.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVertragTyp.Properties.Appearance.Options.UseBackColor = true;
            this.edtVertragTyp.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVertragTyp.Properties.Appearance.Options.UseFont = true;
            this.edtVertragTyp.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtVertragTyp.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtVertragTyp.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtVertragTyp.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtVertragTyp.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtVertragTyp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtVertragTyp.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVertragTyp.Properties.NullText = "";
            this.edtVertragTyp.Properties.ShowFooter = false;
            this.edtVertragTyp.Properties.ShowHeader = false;
            this.edtVertragTyp.Size = new System.Drawing.Size(206, 24);
            this.edtVertragTyp.TabIndex = 10;
            // 
            // edtDatum
            // 
            this.edtDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDatum.DataMember = "Datum";
            this.edtDatum.DataSource = this.qryJobtimalVertrag;
            this.edtDatum.EditValue = null;
            this.edtDatum.Location = new System.Drawing.Point(49, 207);
            this.edtDatum.Name = "edtDatum";
            this.edtDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatum.Properties.Appearance.Options.UseFont = true;
            this.edtDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.edtDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.edtDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatum.Properties.ShowToday = false;
            this.edtDatum.Size = new System.Drawing.Size(96, 24);
            this.edtDatum.TabIndex = 2;
            // 
            // qryJobtimalVorschlag
            // 
            this.qryJobtimalVorschlag.CanDelete = true;
            this.qryJobtimalVorschlag.CanUpdate = true;
            this.qryJobtimalVorschlag.HostControl = this;
            this.qryJobtimalVorschlag.IsIdentityInsert = false;
            this.qryJobtimalVorschlag.SelectStatement = resources.GetString("qryJobtimalVorschlag.SelectStatement");
            this.qryJobtimalVorschlag.TableName = "KaVermittlungVorschlag";
            this.qryJobtimalVorschlag.AfterFill += new System.EventHandler(this.qryJobtimalVorschlag_AfterFill);
            this.qryJobtimalVorschlag.AfterPost += new System.EventHandler(this.qryJobtimalVorschlag_AfterPost);
            this.qryJobtimalVorschlag.BeforeDelete += new System.EventHandler(this.qryJobtimalVorschlag_BeforeDelete);
            this.qryJobtimalVorschlag.PositionChanged += new System.EventHandler(this.qryJobtimalVorschlag_PositionChanged);
            // 
            // pnTitle
            // 
            this.pnTitle.Controls.Add(this.lblTitle);
            this.pnTitle.Controls.Add(this.imageTitle);
            this.pnTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTitle.Location = new System.Drawing.Point(0, 0);
            this.pnTitle.Name = "pnTitle";
            this.pnTitle.Size = new System.Drawing.Size(722, 40);
            this.pnTitle.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitle.Location = new System.Drawing.Point(35, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(500, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Ka_VermittlungJobtimal_Einsätze";
            this.lblTitle.UseCompatibleTextRendering = true;
            // 
            // imageTitle
            // 
            this.imageTitle.Location = new System.Drawing.Point(10, 9);
            this.imageTitle.Name = "imageTitle";
            this.imageTitle.Size = new System.Drawing.Size(25, 20);
            this.imageTitle.TabIndex = 1;
            this.imageTitle.TabStop = false;
            // 
            // lblEinsatzplatz
            // 
            this.lblEinsatzplatz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEinsatzplatz.Location = new System.Drawing.Point(10, 210);
            this.lblEinsatzplatz.Name = "lblEinsatzplatz";
            this.lblEinsatzplatz.Size = new System.Drawing.Size(80, 24);
            this.lblEinsatzplatz.TabIndex = 2;
            this.lblEinsatzplatz.Text = "Bezeichnung";
            this.lblEinsatzplatz.UseCompatibleTextRendering = true;
            // 
            // lblBetrieb
            // 
            this.lblBetrieb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBetrieb.Location = new System.Drawing.Point(10, 234);
            this.lblBetrieb.Name = "lblBetrieb";
            this.lblBetrieb.Size = new System.Drawing.Size(80, 24);
            this.lblBetrieb.TabIndex = 6;
            this.lblBetrieb.Text = "Betrieb";
            this.lblBetrieb.UseCompatibleTextRendering = true;
            // 
            // lbKontaktperson
            // 
            this.lbKontaktperson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbKontaktperson.Location = new System.Drawing.Point(10, 258);
            this.lbKontaktperson.Name = "lbKontaktperson";
            this.lbKontaktperson.Size = new System.Drawing.Size(80, 24);
            this.lbKontaktperson.TabIndex = 8;
            this.lbKontaktperson.Text = "Kontaktperson";
            this.lbKontaktperson.UseCompatibleTextRendering = true;
            // 
            // grdVermittlungJobtimalEinsaetze
            // 
            this.grdVermittlungJobtimalEinsaetze.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdVermittlungJobtimalEinsaetze.DataSource = this.qryJobtimalVorschlag;
            // 
            // 
            // 
            this.grdVermittlungJobtimalEinsaetze.EmbeddedNavigator.Name = "";
            this.grdVermittlungJobtimalEinsaetze.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdVermittlungJobtimalEinsaetze.Location = new System.Drawing.Point(0, 35);
            this.grdVermittlungJobtimalEinsaetze.MainView = this.grvVermittlungJobtimalEinsaetze;
            this.grdVermittlungJobtimalEinsaetze.Name = "grdVermittlungJobtimalEinsaetze";
            this.grdVermittlungJobtimalEinsaetze.Size = new System.Drawing.Size(722, 168);
            this.grdVermittlungJobtimalEinsaetze.TabIndex = 1;
            this.grdVermittlungJobtimalEinsaetze.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVermittlungJobtimalEinsaetze});
            // 
            // grvVermittlungJobtimalEinsaetze
            // 
            this.grvVermittlungJobtimalEinsaetze.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvVermittlungJobtimalEinsaetze.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVermittlungJobtimalEinsaetze.Appearance.Empty.Options.UseBackColor = true;
            this.grvVermittlungJobtimalEinsaetze.Appearance.Empty.Options.UseFont = true;
            this.grvVermittlungJobtimalEinsaetze.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVermittlungJobtimalEinsaetze.Appearance.EvenRow.Options.UseFont = true;
            this.grvVermittlungJobtimalEinsaetze.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVermittlungJobtimalEinsaetze.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVermittlungJobtimalEinsaetze.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvVermittlungJobtimalEinsaetze.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvVermittlungJobtimalEinsaetze.Appearance.FocusedCell.Options.UseFont = true;
            this.grvVermittlungJobtimalEinsaetze.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvVermittlungJobtimalEinsaetze.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVermittlungJobtimalEinsaetze.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVermittlungJobtimalEinsaetze.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvVermittlungJobtimalEinsaetze.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvVermittlungJobtimalEinsaetze.Appearance.FocusedRow.Options.UseFont = true;
            this.grvVermittlungJobtimalEinsaetze.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvVermittlungJobtimalEinsaetze.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVermittlungJobtimalEinsaetze.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvVermittlungJobtimalEinsaetze.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvVermittlungJobtimalEinsaetze.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvVermittlungJobtimalEinsaetze.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVermittlungJobtimalEinsaetze.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvVermittlungJobtimalEinsaetze.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVermittlungJobtimalEinsaetze.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVermittlungJobtimalEinsaetze.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVermittlungJobtimalEinsaetze.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvVermittlungJobtimalEinsaetze.Appearance.GroupRow.Options.UseFont = true;
            this.grvVermittlungJobtimalEinsaetze.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvVermittlungJobtimalEinsaetze.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvVermittlungJobtimalEinsaetze.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvVermittlungJobtimalEinsaetze.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVermittlungJobtimalEinsaetze.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvVermittlungJobtimalEinsaetze.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvVermittlungJobtimalEinsaetze.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvVermittlungJobtimalEinsaetze.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvVermittlungJobtimalEinsaetze.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVermittlungJobtimalEinsaetze.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVermittlungJobtimalEinsaetze.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvVermittlungJobtimalEinsaetze.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvVermittlungJobtimalEinsaetze.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvVermittlungJobtimalEinsaetze.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvVermittlungJobtimalEinsaetze.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvVermittlungJobtimalEinsaetze.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVermittlungJobtimalEinsaetze.Appearance.OddRow.Options.UseFont = true;
            this.grvVermittlungJobtimalEinsaetze.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvVermittlungJobtimalEinsaetze.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVermittlungJobtimalEinsaetze.Appearance.Row.Options.UseBackColor = true;
            this.grvVermittlungJobtimalEinsaetze.Appearance.Row.Options.UseFont = true;
            this.grvVermittlungJobtimalEinsaetze.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVermittlungJobtimalEinsaetze.Appearance.SelectedRow.Options.UseFont = true;
            this.grvVermittlungJobtimalEinsaetze.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvVermittlungJobtimalEinsaetze.Appearance.VertLine.Options.UseBackColor = true;
            this.grvVermittlungJobtimalEinsaetze.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvVermittlungJobtimalEinsaetze.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEinsatzVon,
            this.colBezeichnung,
            this.colBetrieb,
            this.colPensum,
            this.colEinsatzende});
            this.grvVermittlungJobtimalEinsaetze.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvVermittlungJobtimalEinsaetze.GridControl = this.grdVermittlungJobtimalEinsaetze;
            this.grvVermittlungJobtimalEinsaetze.Name = "grvVermittlungJobtimalEinsaetze";
            this.grvVermittlungJobtimalEinsaetze.OptionsBehavior.Editable = false;
            this.grvVermittlungJobtimalEinsaetze.OptionsCustomization.AllowFilter = false;
            this.grvVermittlungJobtimalEinsaetze.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvVermittlungJobtimalEinsaetze.OptionsNavigation.AutoFocusNewRow = true;
            this.grvVermittlungJobtimalEinsaetze.OptionsNavigation.UseTabKey = false;
            this.grvVermittlungJobtimalEinsaetze.OptionsView.ColumnAutoWidth = false;
            this.grvVermittlungJobtimalEinsaetze.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvVermittlungJobtimalEinsaetze.OptionsView.ShowGroupPanel = false;
            this.grvVermittlungJobtimalEinsaetze.OptionsView.ShowIndicator = false;
            // 
            // colEinsatzVon
            // 
            this.colEinsatzVon.Caption = "Einsatz von";
            this.colEinsatzVon.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.colEinsatzVon.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colEinsatzVon.FieldName = "EinsatzVon";
            this.colEinsatzVon.Name = "colEinsatzVon";
            this.colEinsatzVon.Visible = true;
            this.colEinsatzVon.VisibleIndex = 0;
            // 
            // colBezeichnung
            // 
            this.colBezeichnung.Caption = "Bezeichnung";
            this.colBezeichnung.FieldName = "Einsatzplatz";
            this.colBezeichnung.Name = "colBezeichnung";
            this.colBezeichnung.Visible = true;
            this.colBezeichnung.VisibleIndex = 1;
            this.colBezeichnung.Width = 120;
            // 
            // colBetrieb
            // 
            this.colBetrieb.Caption = "Betrieb";
            this.colBetrieb.FieldName = "Betrieb";
            this.colBetrieb.Name = "colBetrieb";
            this.colBetrieb.Visible = true;
            this.colBetrieb.VisibleIndex = 2;
            this.colBetrieb.Width = 340;
            // 
            // colPensum
            // 
            this.colPensum.Caption = "Pensum %";
            this.colPensum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPensum.FieldName = "Arbeitspensum";
            this.colPensum.Name = "colPensum";
            this.colPensum.Visible = true;
            this.colPensum.VisibleIndex = 3;
            // 
            // colEinsatzende
            // 
            this.colEinsatzende.Caption = "Einsatzende";
            this.colEinsatzende.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.colEinsatzende.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colEinsatzende.FieldName = "Abschluss";
            this.colEinsatzende.Name = "colEinsatzende";
            this.colEinsatzende.Visible = true;
            this.colEinsatzende.VisibleIndex = 4;
            this.colEinsatzende.Width = 100;
            // 
            // edtEinsatzplatz
            // 
            this.edtEinsatzplatz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtEinsatzplatz.DataMember = "Einsatzplatz";
            this.edtEinsatzplatz.DataSource = this.qryJobtimalVorschlag;
            this.edtEinsatzplatz.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtEinsatzplatz.Location = new System.Drawing.Point(97, 209);
            this.edtEinsatzplatz.Name = "edtEinsatzplatz";
            this.edtEinsatzplatz.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtEinsatzplatz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinsatzplatz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinsatzplatz.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinsatzplatz.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinsatzplatz.Properties.Appearance.Options.UseFont = true;
            this.edtEinsatzplatz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEinsatzplatz.Properties.ReadOnly = true;
            this.edtEinsatzplatz.Size = new System.Drawing.Size(383, 24);
            this.edtEinsatzplatz.TabIndex = 3;
            // 
            // edtBetrieb
            // 
            this.edtBetrieb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBetrieb.DataMember = "Betrieb";
            this.edtBetrieb.DataSource = this.qryJobtimalVorschlag;
            this.edtBetrieb.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBetrieb.Location = new System.Drawing.Point(97, 234);
            this.edtBetrieb.Name = "edtBetrieb";
            this.edtBetrieb.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBetrieb.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetrieb.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetrieb.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetrieb.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetrieb.Properties.Appearance.Options.UseFont = true;
            this.edtBetrieb.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetrieb.Properties.ReadOnly = true;
            this.edtBetrieb.Size = new System.Drawing.Size(491, 24);
            this.edtBetrieb.TabIndex = 7;
            // 
            // edtKontaktperson
            // 
            this.edtKontaktperson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtKontaktperson.DataMember = "Kontaktperson";
            this.edtKontaktperson.DataSource = this.qryJobtimalVorschlag;
            this.edtKontaktperson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKontaktperson.Location = new System.Drawing.Point(97, 259);
            this.edtKontaktperson.Name = "edtKontaktperson";
            this.edtKontaktperson.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKontaktperson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktperson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktperson.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktperson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktperson.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktperson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontaktperson.Properties.ReadOnly = true;
            this.edtKontaktperson.Size = new System.Drawing.Size(491, 24);
            this.edtKontaktperson.TabIndex = 9;
            // 
            // btnDetailsEinsatzplatz
            // 
            this.btnDetailsEinsatzplatz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDetailsEinsatzplatz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetailsEinsatzplatz.Location = new System.Drawing.Point(594, 209);
            this.btnDetailsEinsatzplatz.Name = "btnDetailsEinsatzplatz";
            this.btnDetailsEinsatzplatz.Size = new System.Drawing.Size(125, 24);
            this.btnDetailsEinsatzplatz.TabIndex = 10;
            this.btnDetailsEinsatzplatz.Text = "Info Einsatzplatz";
            this.btnDetailsEinsatzplatz.UseCompatibleTextRendering = true;
            this.btnDetailsEinsatzplatz.UseVisualStyleBackColor = false;
            this.btnDetailsEinsatzplatz.Click += new System.EventHandler(this.btnDetailsEinsatzplatz_Click);
            // 
            // lblEinsatzplatzNr
            // 
            this.lblEinsatzplatzNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEinsatzplatzNr.Location = new System.Drawing.Point(486, 209);
            this.lblEinsatzplatzNr.Name = "lblEinsatzplatzNr";
            this.lblEinsatzplatzNr.Size = new System.Drawing.Size(22, 24);
            this.lblEinsatzplatzNr.TabIndex = 4;
            this.lblEinsatzplatzNr.Text = "Nr.";
            this.lblEinsatzplatzNr.UseCompatibleTextRendering = true;
            // 
            // edtEinsatzplatzNr
            // 
            this.edtEinsatzplatzNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtEinsatzplatzNr.DataMember = "KaEinsatzplatzID";
            this.edtEinsatzplatzNr.DataSource = this.qryJobtimalVorschlag;
            this.edtEinsatzplatzNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtEinsatzplatzNr.Location = new System.Drawing.Point(514, 209);
            this.edtEinsatzplatzNr.Name = "edtEinsatzplatzNr";
            this.edtEinsatzplatzNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtEinsatzplatzNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinsatzplatzNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinsatzplatzNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinsatzplatzNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinsatzplatzNr.Properties.Appearance.Options.UseFont = true;
            this.edtEinsatzplatzNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEinsatzplatzNr.Properties.ReadOnly = true;
            this.edtEinsatzplatzNr.Size = new System.Drawing.Size(74, 24);
            this.edtEinsatzplatzNr.TabIndex = 5;
            // 
            // CtlKaVermittlungJobtimalEinsaetze
            // 
            this.ActiveSQLQuery = this.qryJobtimalVorschlag;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(730, 550);
            this.Controls.Add(this.lblEinsatzplatzNr);
            this.Controls.Add(this.edtEinsatzplatzNr);
            this.Controls.Add(this.btnDetailsEinsatzplatz);
            this.Controls.Add(this.edtKontaktperson);
            this.Controls.Add(this.edtBetrieb);
            this.Controls.Add(this.edtEinsatzplatz);
            this.Controls.Add(this.grdVermittlungJobtimalEinsaetze);
            this.Controls.Add(this.lbKontaktperson);
            this.Controls.Add(this.lblBetrieb);
            this.Controls.Add(this.lblEinsatzplatz);
            this.Controls.Add(this.pnTitle);
            this.Controls.Add(this.tabEinsaetze);
            this.Name = "CtlKaVermittlungJobtimalEinsaetze";
            this.Size = new System.Drawing.Size(722, 557);
            this.tabEinsaetze.ResumeLayout(false);
            this.tpgEinsatz.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzende)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschlussDurch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeistungsfaehigkeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProzent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblArbeitspensum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryJobtimalEinsatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrund.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussDurch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussDurch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzende.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPensumErgänzungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPensum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzendeDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzAb.Properties)).EndInit();
            this.tpgVertrag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtDocument.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryJobtimalVertrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVertrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVertrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVertragTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVertragTyp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVertragTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryJobtimalVorschlag)).EndInit();
            this.pnTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzplatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrieb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbKontaktperson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVermittlungJobtimalEinsaetze)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVermittlungJobtimalEinsaetze)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzplatz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrieb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktperson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzplatzNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzplatzNr.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissButton btnDetailsEinsatzplatz;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrieb;
        private DevExpress.XtraGrid.Columns.GridColumn colBezeichnung;
        private DevExpress.XtraGrid.Columns.GridColumn colDokumentTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colEinsatzVon;
        private DevExpress.XtraGrid.Columns.GridColumn colEinsatzende;
        private DevExpress.XtraGrid.Columns.GridColumn colPensum;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissLookUpEdit edtAbschlussDurch;
        private KiSS4.Gui.KissLookUpEdit edtAbschlussGrund;
        private KiSS4.Gui.KissDateEdit edtDatum;
        private KiSS4.Gui.KissTextEdit edtBetrieb;
        private KiSS4.Gui.KissDateEdit edtEinsatzAb;
        private KiSS4.Gui.KissMemoEdit edtEinsatzBemerkung;
        private KiSS4.Gui.KissDateEdit edtEinsatzende;
        private KiSS4.Gui.KissTextEdit edtEinsatzplatz;
        private KiSS4.Gui.KissTextEdit edtEinsatzplatzNr;
        private KiSS4.Gui.KissLookUpEdit edtVertragTyp;
        private KiSS4.Gui.KissTextEdit edtKontaktperson;
        private KiSS4.Gui.KissCalcEdit edtPensum;
        private KiSS4.Gui.KissCalcEdit edtPensumErgänzungen;
        private KiSS4.Gui.KissGrid grdVermittlungJobtimalEinsaetze;
        private KiSS4.Gui.KissGrid grdVertrag;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVermittlungJobtimalEinsaetze;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVertrag;
        private System.Windows.Forms.PictureBox imageTitle;
        private KiSS4.Gui.KissLabel lbKontaktperson;
        private KiSS4.Gui.KissLabel lblAbschlussDurch;
        private KiSS4.Gui.KissLabel lblDatum;
        private KiSS4.Gui.KissLabel lblArbeitspensum;
        private KiSS4.Gui.KissLabel lblBemerkungen;
        private KiSS4.Gui.KissLabel lblBetrieb;
        private KiSS4.Gui.KissLabel lblEinsatzab;
        private KiSS4.Gui.KissLabel lblEinsatzende;
        private KiSS4.Gui.KissLabel lblEinsatzendeDatum;
        private KiSS4.Gui.KissLabel lblEinsatzplatz;
        private KiSS4.Gui.KissLabel lblEinsatzplatzNr;
        private KiSS4.Gui.KissLabel lblLeistungsfaehigkeit;
        private KiSS4.Gui.KissLabel lblGrund;
        private KiSS4.Gui.KissLabel lblVertragTyp;
        private KiSS4.Gui.KissLabel lblProzent;
        private KiSS4.Gui.KissLabel lblTitle;
        private System.Windows.Forms.Panel pnTitle;
        private KiSS4.DB.SqlQuery qryJobtimalEinsatz;
        private KiSS4.DB.SqlQuery qryJobtimalVorschlag;
        private KiSS4.DB.SqlQuery qryJobtimalVertrag;
        private KiSS4.Gui.KissTabControlEx tabEinsaetze;
        private SharpLibrary.WinControls.TabPageEx tpgEinsatz;
        private SharpLibrary.WinControls.TabPageEx tpgVertrag;
        private Dokument.XDokument edtDocument;
        private Gui.KissLabel kissLabel1;
    }
}
