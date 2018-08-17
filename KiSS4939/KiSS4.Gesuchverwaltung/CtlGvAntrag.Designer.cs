namespace KiSS4.Gesuchverwaltung
{
    partial class CtlGvAntrag
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlGvAntrag));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject13 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblFinanzierung = new KiSS4.Gui.KissLabel();
            this.lblKosten = new KiSS4.Gui.KissLabel();
            this.panelKosten = new System.Windows.Forms.Panel();
            this.edtKostenBetrag = new KiSS4.Gui.KissCalcEdit();
            this.qryGvKosten = new KiSS4.DB.SqlQuery(this.components);
            this.edtKostenBezeichnung = new KiSS4.Gui.KissTextEdit();
            this.lblKostenbezeichnung = new KiSS4.Gui.KissLabel();
            this.lblKostenBetrag = new KiSS4.Gui.KissLabel();
            this.panelFinanzierung = new System.Windows.Forms.Panel();
            this.edtFinanzierungBetrag = new KiSS4.Gui.KissCalcEdit();
            this.qryGvFinanzierung = new KiSS4.DB.SqlQuery(this.components);
            this.edtFinanzierungQuelle = new KiSS4.Gui.KissTextEdit();
            this.lblFinanzierungQuelle = new KiSS4.Gui.KissLabel();
            this.lblFinanzierungBetrag = new KiSS4.Gui.KissLabel();
            this.grdKosten = new KiSS4.Gui.KissGrid();
            this.grvKosten = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKostenKostenbezeichnung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKostenBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKostenSortBezeichnung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdFinanzierung = new KiSS4.Gui.KissGrid();
            this.grvFinanzierung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFinanzierungQuelle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinanzierungBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinanzierungSortKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlKompetenz = new System.Windows.Forms.Panel();
            this.chkEigenkompetenz = new KiSS4.Gui.KissCheckEdit();
            this.chkKompetenzBSL = new KiSS4.Gui.KissCheckEdit();
            this.grpGesuchAnExternenFonds = new KiSS4.Gui.KissGroupBox();
            this.panTableLayoutGesuchanexternenFonds = new System.Windows.Forms.TableLayoutPanel();
            this.panelGesuchanexterneFondsLinks = new System.Windows.Forms.Panel();
            this.btnExternerFondsAbschlussAufheben = new KiSS4.Gui.KissButton();
            this.edtExternerFondsGesuchsformular = new KiSS4.Dokument.XDokument();
            this.lblExternerFondsGesuchsformular = new KiSS4.Gui.KissLabel();
            this.btnExternerFondsGesuchAbschliessen = new KiSS4.Gui.KissButton();
            this.edtExternerFondsAbschlussgrund = new KiSS4.Gui.KissLookUpEdit();
            this.lblExternerFondsAbschlussgrund = new KiSS4.Gui.KissLabel();
            this.lblExternerFondsDatumAbschluss = new KiSS4.Gui.KissLabel();
            this.edtExternerFondsDatumAbschluss = new KiSS4.Gui.KissDateEdit();
            this.edtExternerFondsBemerkung = new KiSS4.Gui.KissRTFEdit();
            this.lblExternerFondsBemerkung = new KiSS4.Gui.KissLabel();
            this.edtExternerFondsBewilligterBetrag = new KiSS4.Gui.KissCalcEdit();
            this.edtExternerFondsDatumEntscheid = new KiSS4.Gui.KissDateEdit();
            this.lblExternerFondsDatumEntscheid = new KiSS4.Gui.KissLabel();
            this.lblExternerFondsBewilligterBetrag = new KiSS4.Gui.KissLabel();
            this.panelGesuchanexterneFondsRechtsIKS = new System.Windows.Forms.Panel();
            this.kissRTFEditAbgeschlossenesBemerkung = new KiSS4.Gui.KissRTFEdit();
            this.lblAbgeschlossenesGesuchBemerkung = new KiSS4.Gui.KissLabel();
            this.edtAbgeschlossenesGesuchDurchIKS = new KiSS4.Gui.KissTextEdit();
            this.lblAbgeschlossensGesuchDurchIKS = new KiSS4.Gui.KissLabel();
            this.chkAbgeschlossenesGesuchBesprechen = new KiSS4.Gui.KissCheckEdit();
            this.edtAbgeschlossenesGesuchgeprueftam = new KiSS4.Gui.KissDateEdit();
            this.lblAbgeschlossenesGesuchgeprueftam = new KiSS4.Gui.KissLabel();
            this.kissRTFErfasstesGesuchBemerkung = new KiSS4.Gui.KissRTFEdit();
            this.lblErfasstesGesuchBemerkung = new KiSS4.Gui.KissLabel();
            this.edtErfasstesGesuchgepreuftdurchIKS = new KiSS4.Gui.KissTextEdit();
            this.lblErfasstesGesuchgepreuftdurchIKS = new KiSS4.Gui.KissLabel();
            this.chkErfasstesGesuchBesprechen = new KiSS4.Gui.KissCheckEdit();
            this.edtErfasstesGesuchgeprueftam = new KiSS4.Gui.KissDateEdit();
            this.lblErfasstesGesuchgeprueftam = new KiSS4.Gui.KissLabel();
            this.panTableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblFinanzierung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKosten)).BeginInit();
            this.panelKosten.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryGvKosten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenBezeichnung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenbezeichnung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenBetrag)).BeginInit();
            this.panelFinanzierung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtFinanzierungBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryGvFinanzierung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFinanzierungQuelle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFinanzierungQuelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFinanzierungBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKosten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKosten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFinanzierung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFinanzierung)).BeginInit();
            this.pnlKompetenz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkEigenkompetenz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKompetenzBSL.Properties)).BeginInit();
            this.grpGesuchAnExternenFonds.SuspendLayout();
            this.panTableLayoutGesuchanexternenFonds.SuspendLayout();
            this.panelGesuchanexterneFondsLinks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtExternerFondsGesuchsformular.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblExternerFondsGesuchsformular)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtExternerFondsAbschlussgrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtExternerFondsAbschlussgrund.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblExternerFondsAbschlussgrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblExternerFondsDatumAbschluss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtExternerFondsDatumAbschluss.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblExternerFondsBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtExternerFondsBewilligterBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtExternerFondsDatumEntscheid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblExternerFondsDatumEntscheid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblExternerFondsBewilligterBetrag)).BeginInit();
            this.panelGesuchanexterneFondsRechtsIKS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbgeschlossenesGesuchBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbgeschlossenesGesuchDurchIKS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbgeschlossensGesuchDurchIKS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAbgeschlossenesGesuchBesprechen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbgeschlossenesGesuchgeprueftam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbgeschlossenesGesuchgeprueftam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfasstesGesuchBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfasstesGesuchgepreuftdurchIKS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfasstesGesuchgepreuftdurchIKS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkErfasstesGesuchBesprechen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfasstesGesuchgeprueftam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfasstesGesuchgeprueftam)).BeginInit();
            this.SuspendLayout();
            // 
            // panTableLayout
            // 
            this.panTableLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panTableLayout.ColumnCount = 2;
            this.panTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panTableLayout.Controls.Add(this.lblFinanzierung, 1, 0);
            this.panTableLayout.Controls.Add(this.lblKosten, 0, 0);
            this.panTableLayout.Controls.Add(this.panelKosten, 0, 2);
            this.panTableLayout.Controls.Add(this.panelFinanzierung, 1, 2);
            this.panTableLayout.Controls.Add(this.grdKosten, 0, 1);
            this.panTableLayout.Controls.Add(this.grdFinanzierung, 1, 1);
            this.panTableLayout.Controls.Add(this.pnlKompetenz, 0, 3);
            this.panTableLayout.Controls.Add(this.grpGesuchAnExternenFonds, 0, 4);
            this.panTableLayout.Location = new System.Drawing.Point(3, 3);
            this.panTableLayout.Name = "panTableLayout";
            this.panTableLayout.RowCount = 5;
            this.panTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.panTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.panTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 324F));
            this.panTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panTableLayout.Size = new System.Drawing.Size(1224, 642);
            this.panTableLayout.TabIndex = 0;
            // 
            // lblFinanzierung
            // 
            this.lblFinanzierung.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblFinanzierung.Location = new System.Drawing.Point(615, 0);
            this.lblFinanzierung.Name = "lblFinanzierung";
            this.lblFinanzierung.Size = new System.Drawing.Size(100, 16);
            this.lblFinanzierung.TabIndex = 4;
            this.lblFinanzierung.Text = "Finanzierung";
            // 
            // lblKosten
            // 
            this.lblKosten.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblKosten.Location = new System.Drawing.Point(3, 0);
            this.lblKosten.Name = "lblKosten";
            this.lblKosten.Size = new System.Drawing.Size(100, 16);
            this.lblKosten.TabIndex = 0;
            this.lblKosten.Text = "Kosten";
            // 
            // panelKosten
            // 
            this.panelKosten.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelKosten.Controls.Add(this.edtKostenBetrag);
            this.panelKosten.Controls.Add(this.edtKostenBezeichnung);
            this.panelKosten.Controls.Add(this.lblKostenbezeichnung);
            this.panelKosten.Controls.Add(this.lblKostenBetrag);
            this.panelKosten.Location = new System.Drawing.Point(3, 215);
            this.panelKosten.Name = "panelKosten";
            this.panelKosten.Size = new System.Drawing.Size(606, 68);
            this.panelKosten.TabIndex = 2;
            // 
            // edtKostenBetrag
            // 
            this.edtKostenBetrag.DataSource = this.qryGvKosten;
            this.edtKostenBetrag.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtKostenBetrag.Location = new System.Drawing.Point(127, 38);
            this.edtKostenBetrag.Name = "edtKostenBetrag";
            this.edtKostenBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtKostenBetrag.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtKostenBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKostenBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKostenBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtKostenBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKostenBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtKostenBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKostenBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKostenBetrag.Properties.DisplayFormat.FormatString = "n2";
            this.edtKostenBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtKostenBetrag.Properties.EditFormat.FormatString = "n2";
            this.edtKostenBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtKostenBetrag.Properties.Mask.EditMask = "n2";
            this.edtKostenBetrag.Size = new System.Drawing.Size(100, 24);
            this.edtKostenBetrag.TabIndex = 3;
            // 
            // qryGvKosten
            // 
            this.qryGvKosten.CanDelete = true;
            this.qryGvKosten.CanInsert = true;
            this.qryGvKosten.CanUpdate = true;
            this.qryGvKosten.HostControl = this;
            this.qryGvKosten.SelectStatement = resources.GetString("qryGvKosten.SelectStatement");
            this.qryGvKosten.TableName = "GvAntragPosition";
            this.qryGvKosten.AfterInsert += new System.EventHandler(this.qryGvKosten_AfterInsert);
            this.qryGvKosten.BeforeDeleteQuestion += new System.EventHandler(this.qryGvKosten_BeforeDeleteQuestion);
            this.qryGvKosten.BeforePost += new System.EventHandler(this.qryGvKosten_BeforePost);
            this.qryGvKosten.PostCompleted += new System.EventHandler(this.qryGvKosten_PostCompleted);
            // 
            // edtKostenBezeichnung
            // 
            this.edtKostenBezeichnung.DataSource = this.qryGvKosten;
            this.edtKostenBezeichnung.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtKostenBezeichnung.Location = new System.Drawing.Point(127, 8);
            this.edtKostenBezeichnung.Name = "edtKostenBezeichnung";
            this.edtKostenBezeichnung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtKostenBezeichnung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKostenBezeichnung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKostenBezeichnung.Properties.Appearance.Options.UseBackColor = true;
            this.edtKostenBezeichnung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKostenBezeichnung.Properties.Appearance.Options.UseFont = true;
            this.edtKostenBezeichnung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKostenBezeichnung.Properties.MaxLength = 200;
            this.edtKostenBezeichnung.Properties.Name = "kissTextEdit22.Properties";
            this.edtKostenBezeichnung.Size = new System.Drawing.Size(211, 24);
            this.edtKostenBezeichnung.TabIndex = 1;
            // 
            // lblKostenbezeichnung
            // 
            this.lblKostenbezeichnung.Location = new System.Drawing.Point(3, 8);
            this.lblKostenbezeichnung.Name = "lblKostenbezeichnung";
            this.lblKostenbezeichnung.Size = new System.Drawing.Size(118, 24);
            this.lblKostenbezeichnung.TabIndex = 0;
            this.lblKostenbezeichnung.Text = "Kostenbezeichnung";
            // 
            // lblKostenBetrag
            // 
            this.lblKostenBetrag.Location = new System.Drawing.Point(3, 36);
            this.lblKostenBetrag.Name = "lblKostenBetrag";
            this.lblKostenBetrag.Size = new System.Drawing.Size(118, 24);
            this.lblKostenBetrag.TabIndex = 2;
            this.lblKostenBetrag.Text = "Betrag";
            // 
            // panelFinanzierung
            // 
            this.panelFinanzierung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFinanzierung.Controls.Add(this.edtFinanzierungBetrag);
            this.panelFinanzierung.Controls.Add(this.edtFinanzierungQuelle);
            this.panelFinanzierung.Controls.Add(this.lblFinanzierungQuelle);
            this.panelFinanzierung.Controls.Add(this.lblFinanzierungBetrag);
            this.panelFinanzierung.Location = new System.Drawing.Point(615, 215);
            this.panelFinanzierung.Name = "panelFinanzierung";
            this.panelFinanzierung.Size = new System.Drawing.Size(606, 68);
            this.panelFinanzierung.TabIndex = 6;
            // 
            // edtFinanzierungBetrag
            // 
            this.edtFinanzierungBetrag.DataSource = this.qryGvFinanzierung;
            this.edtFinanzierungBetrag.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtFinanzierungBetrag.Location = new System.Drawing.Point(114, 39);
            this.edtFinanzierungBetrag.Name = "edtFinanzierungBetrag";
            this.edtFinanzierungBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtFinanzierungBetrag.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtFinanzierungBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFinanzierungBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFinanzierungBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtFinanzierungBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFinanzierungBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtFinanzierungBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFinanzierungBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFinanzierungBetrag.Properties.DisplayFormat.FormatString = "n2";
            this.edtFinanzierungBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtFinanzierungBetrag.Properties.EditFormat.FormatString = "n2";
            this.edtFinanzierungBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtFinanzierungBetrag.Properties.Mask.EditMask = "n2";
            this.edtFinanzierungBetrag.Size = new System.Drawing.Size(100, 24);
            this.edtFinanzierungBetrag.TabIndex = 3;
            // 
            // qryGvFinanzierung
            // 
            this.qryGvFinanzierung.CanDelete = true;
            this.qryGvFinanzierung.CanInsert = true;
            this.qryGvFinanzierung.CanUpdate = true;
            this.qryGvFinanzierung.HostControl = this;
            this.qryGvFinanzierung.SelectStatement = resources.GetString("qryGvFinanzierung.SelectStatement");
            this.qryGvFinanzierung.TableName = "GvAntragPosition";
            this.qryGvFinanzierung.AfterInsert += new System.EventHandler(this.qryGvFinanzierung_AfterInsert);
            this.qryGvFinanzierung.BeforeDeleteQuestion += new System.EventHandler(this.qryGvFinanzierung_BeforeDeleteQuestion);
            this.qryGvFinanzierung.BeforePost += new System.EventHandler(this.qryGvFinanzierung_BeforePost);
            this.qryGvFinanzierung.PositionChanged += new System.EventHandler(this.qryGvFinanzierung_PositionChanged);
            this.qryGvFinanzierung.PostCompleted += new System.EventHandler(this.qryGvFinanzierung_PostCompleted);
            // 
            // edtFinanzierungQuelle
            // 
            this.edtFinanzierungQuelle.DataSource = this.qryGvFinanzierung;
            this.edtFinanzierungQuelle.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtFinanzierungQuelle.Location = new System.Drawing.Point(114, 8);
            this.edtFinanzierungQuelle.Name = "edtFinanzierungQuelle";
            this.edtFinanzierungQuelle.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtFinanzierungQuelle.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFinanzierungQuelle.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFinanzierungQuelle.Properties.Appearance.Options.UseBackColor = true;
            this.edtFinanzierungQuelle.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFinanzierungQuelle.Properties.Appearance.Options.UseFont = true;
            this.edtFinanzierungQuelle.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFinanzierungQuelle.Properties.MaxLength = 200;
            this.edtFinanzierungQuelle.Properties.Name = "kissTextEdit22.Properties";
            this.edtFinanzierungQuelle.Size = new System.Drawing.Size(211, 24);
            this.edtFinanzierungQuelle.TabIndex = 1;
            // 
            // lblFinanzierungQuelle
            // 
            this.lblFinanzierungQuelle.Location = new System.Drawing.Point(3, 8);
            this.lblFinanzierungQuelle.Name = "lblFinanzierungQuelle";
            this.lblFinanzierungQuelle.Size = new System.Drawing.Size(105, 24);
            this.lblFinanzierungQuelle.TabIndex = 0;
            this.lblFinanzierungQuelle.Text = "Quelle";
            // 
            // lblFinanzierungBetrag
            // 
            this.lblFinanzierungBetrag.Location = new System.Drawing.Point(3, 38);
            this.lblFinanzierungBetrag.Name = "lblFinanzierungBetrag";
            this.lblFinanzierungBetrag.Size = new System.Drawing.Size(105, 24);
            this.lblFinanzierungBetrag.TabIndex = 2;
            this.lblFinanzierungBetrag.Text = "Betrag";
            // 
            // grdKosten
            // 
            this.grdKosten.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdKosten.DataSource = this.qryGvKosten;
            // 
            // 
            // 
            this.grdKosten.EmbeddedNavigator.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.grdKosten.EmbeddedNavigator.Name = "";
            this.grdKosten.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdKosten.Location = new System.Drawing.Point(3, 23);
            this.grdKosten.MainView = this.grvKosten;
            this.grdKosten.Name = "grdKosten";
            this.grdKosten.Size = new System.Drawing.Size(606, 186);
            this.grdKosten.TabIndex = 1;
            this.grdKosten.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKosten});
            // 
            // grvKosten
            // 
            this.grvKosten.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvKosten.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKosten.Appearance.Empty.Options.UseBackColor = true;
            this.grvKosten.Appearance.Empty.Options.UseFont = true;
            this.grvKosten.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKosten.Appearance.EvenRow.Options.UseFont = true;
            this.grvKosten.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKosten.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKosten.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvKosten.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvKosten.Appearance.FocusedCell.Options.UseFont = true;
            this.grvKosten.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvKosten.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKosten.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKosten.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvKosten.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvKosten.Appearance.FocusedRow.Options.UseFont = true;
            this.grvKosten.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvKosten.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKosten.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKosten.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvKosten.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvKosten.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKosten.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvKosten.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKosten.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKosten.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKosten.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvKosten.Appearance.GroupRow.Options.UseFont = true;
            this.grvKosten.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvKosten.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvKosten.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvKosten.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKosten.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvKosten.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvKosten.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKosten.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvKosten.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKosten.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKosten.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKosten.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvKosten.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvKosten.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvKosten.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvKosten.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKosten.Appearance.OddRow.Options.UseFont = true;
            this.grvKosten.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKosten.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKosten.Appearance.Row.Options.UseBackColor = true;
            this.grvKosten.Appearance.Row.Options.UseFont = true;
            this.grvKosten.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKosten.Appearance.SelectedRow.Options.UseFont = true;
            this.grvKosten.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvKosten.Appearance.VertLine.Options.UseBackColor = true;
            this.grvKosten.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvKosten.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKostenKostenbezeichnung,
            this.colKostenBetrag,
            this.colKostenSortBezeichnung});
            this.grvKosten.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvKosten.GridControl = this.grdKosten;
            this.grvKosten.Name = "grvKosten";
            this.grvKosten.OptionsBehavior.Editable = false;
            this.grvKosten.OptionsCustomization.AllowFilter = false;
            this.grvKosten.OptionsCustomization.AllowSort = false;
            this.grvKosten.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvKosten.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKosten.OptionsNavigation.UseTabKey = false;
            this.grvKosten.OptionsView.ColumnAutoWidth = false;
            this.grvKosten.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvKosten.OptionsView.ShowFooter = true;
            this.grvKosten.OptionsView.ShowGroupPanel = false;
            this.grvKosten.OptionsView.ShowIndicator = false;
            this.grvKosten.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colKostenSortBezeichnung, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colKostenKostenbezeichnung
            // 
            this.colKostenKostenbezeichnung.Caption = "Kostenbezeichnung";
            this.colKostenKostenbezeichnung.Name = "colKostenKostenbezeichnung";
            this.colKostenKostenbezeichnung.SummaryItem.DisplayFormat = "Total";
            this.colKostenKostenbezeichnung.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.colKostenKostenbezeichnung.Visible = true;
            this.colKostenKostenbezeichnung.VisibleIndex = 0;
            this.colKostenKostenbezeichnung.Width = 250;
            // 
            // colKostenBetrag
            // 
            this.colKostenBetrag.Caption = "Betrag";
            this.colKostenBetrag.DisplayFormat.FormatString = "n2";
            this.colKostenBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colKostenBetrag.Name = "colKostenBetrag";
            this.colKostenBetrag.SummaryItem.DisplayFormat = "{0:n2}";
            this.colKostenBetrag.SummaryItem.FieldName = "Betrag";
            this.colKostenBetrag.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colKostenBetrag.Visible = true;
            this.colKostenBetrag.VisibleIndex = 1;
            // 
            // colKostenSortBezeichnung
            // 
            this.colKostenSortBezeichnung.Caption = "Bezeichnung";
            this.colKostenSortBezeichnung.Name = "colKostenSortBezeichnung";
            this.colKostenSortBezeichnung.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            // 
            // grdFinanzierung
            // 
            this.grdFinanzierung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdFinanzierung.DataSource = this.qryGvFinanzierung;
            // 
            // 
            // 
            this.grdFinanzierung.EmbeddedNavigator.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.grdFinanzierung.EmbeddedNavigator.Name = "";
            this.grdFinanzierung.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdFinanzierung.Location = new System.Drawing.Point(615, 23);
            this.grdFinanzierung.MainView = this.grvFinanzierung;
            this.grdFinanzierung.Name = "grdFinanzierung";
            this.grdFinanzierung.Size = new System.Drawing.Size(606, 186);
            this.grdFinanzierung.TabIndex = 5;
            this.grdFinanzierung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvFinanzierung});
            // 
            // grvFinanzierung
            // 
            this.grvFinanzierung.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvFinanzierung.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFinanzierung.Appearance.Empty.Options.UseBackColor = true;
            this.grvFinanzierung.Appearance.Empty.Options.UseFont = true;
            this.grvFinanzierung.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFinanzierung.Appearance.EvenRow.Options.UseFont = true;
            this.grvFinanzierung.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFinanzierung.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFinanzierung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvFinanzierung.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvFinanzierung.Appearance.FocusedCell.Options.UseFont = true;
            this.grvFinanzierung.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvFinanzierung.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFinanzierung.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFinanzierung.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvFinanzierung.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvFinanzierung.Appearance.FocusedRow.Options.UseFont = true;
            this.grvFinanzierung.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvFinanzierung.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFinanzierung.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvFinanzierung.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvFinanzierung.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvFinanzierung.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFinanzierung.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvFinanzierung.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFinanzierung.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFinanzierung.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFinanzierung.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvFinanzierung.Appearance.GroupRow.Options.UseFont = true;
            this.grvFinanzierung.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvFinanzierung.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvFinanzierung.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvFinanzierung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFinanzierung.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvFinanzierung.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvFinanzierung.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvFinanzierung.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvFinanzierung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFinanzierung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFinanzierung.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvFinanzierung.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvFinanzierung.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvFinanzierung.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvFinanzierung.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvFinanzierung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFinanzierung.Appearance.OddRow.Options.UseFont = true;
            this.grvFinanzierung.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvFinanzierung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFinanzierung.Appearance.Row.Options.UseBackColor = true;
            this.grvFinanzierung.Appearance.Row.Options.UseFont = true;
            this.grvFinanzierung.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFinanzierung.Appearance.SelectedRow.Options.UseFont = true;
            this.grvFinanzierung.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvFinanzierung.Appearance.VertLine.Options.UseBackColor = true;
            this.grvFinanzierung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvFinanzierung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFinanzierungQuelle,
            this.colFinanzierungBetrag,
            this.colFinanzierungSortKey});
            this.grvFinanzierung.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvFinanzierung.GridControl = this.grdFinanzierung;
            this.grvFinanzierung.Name = "grvFinanzierung";
            this.grvFinanzierung.OptionsBehavior.Editable = false;
            this.grvFinanzierung.OptionsCustomization.AllowFilter = false;
            this.grvFinanzierung.OptionsCustomization.AllowSort = false;
            this.grvFinanzierung.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvFinanzierung.OptionsNavigation.AutoFocusNewRow = true;
            this.grvFinanzierung.OptionsNavigation.UseTabKey = false;
            this.grvFinanzierung.OptionsView.ColumnAutoWidth = false;
            this.grvFinanzierung.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvFinanzierung.OptionsView.ShowFooter = true;
            this.grvFinanzierung.OptionsView.ShowGroupPanel = false;
            this.grvFinanzierung.OptionsView.ShowIndicator = false;
            this.grvFinanzierung.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colFinanzierungSortKey, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colFinanzierungQuelle
            // 
            this.colFinanzierungQuelle.Caption = "Quelle";
            this.colFinanzierungQuelle.Name = "colFinanzierungQuelle";
            this.colFinanzierungQuelle.SummaryItem.DisplayFormat = "Total";
            this.colFinanzierungQuelle.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.colFinanzierungQuelle.Visible = true;
            this.colFinanzierungQuelle.VisibleIndex = 0;
            this.colFinanzierungQuelle.Width = 250;
            // 
            // colFinanzierungBetrag
            // 
            this.colFinanzierungBetrag.Caption = "Betrag";
            this.colFinanzierungBetrag.DisplayFormat.FormatString = "n2";
            this.colFinanzierungBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colFinanzierungBetrag.Name = "colFinanzierungBetrag";
            this.colFinanzierungBetrag.SummaryItem.DisplayFormat = "{0:n2}";
            this.colFinanzierungBetrag.SummaryItem.FieldName = "Betrag";
            this.colFinanzierungBetrag.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colFinanzierungBetrag.Visible = true;
            this.colFinanzierungBetrag.VisibleIndex = 1;
            // 
            // colFinanzierungSortKey
            // 
            this.colFinanzierungSortKey.Caption = "Sortierung";
            this.colFinanzierungSortKey.Name = "colFinanzierungSortKey";
            this.colFinanzierungSortKey.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            // 
            // pnlKompetenz
            // 
            this.panTableLayout.SetColumnSpan(this.pnlKompetenz, 2);
            this.pnlKompetenz.Controls.Add(this.chkEigenkompetenz);
            this.pnlKompetenz.Controls.Add(this.chkKompetenzBSL);
            this.pnlKompetenz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKompetenz.Location = new System.Drawing.Point(3, 289);
            this.pnlKompetenz.Name = "pnlKompetenz";
            this.pnlKompetenz.Size = new System.Drawing.Size(1218, 26);
            this.pnlKompetenz.TabIndex = 7;
            // 
            // chkEigenkompetenz
            // 
            this.chkEigenkompetenz.EditValue = false;
            this.chkEigenkompetenz.Location = new System.Drawing.Point(6, 3);
            this.chkEigenkompetenz.Name = "chkEigenkompetenz";
            this.chkEigenkompetenz.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkEigenkompetenz.Properties.Appearance.Options.UseBackColor = true;
            this.chkEigenkompetenz.Properties.Caption = "Eigenkompetenz";
            this.chkEigenkompetenz.Size = new System.Drawing.Size(115, 19);
            this.chkEigenkompetenz.TabIndex = 0;
            // 
            // chkKompetenzBSL
            // 
            this.chkKompetenzBSL.EditValue = false;
            this.chkKompetenzBSL.Location = new System.Drawing.Point(127, 3);
            this.chkKompetenzBSL.Name = "chkKompetenzBSL";
            this.chkKompetenzBSL.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkKompetenzBSL.Properties.Appearance.Options.UseBackColor = true;
            this.chkKompetenzBSL.Properties.Caption = "Kompetenz BSL";
            this.chkKompetenzBSL.Size = new System.Drawing.Size(173, 19);
            this.chkKompetenzBSL.TabIndex = 1;
            // 
            // grpGesuchAnExternenFonds
            // 
            this.grpGesuchAnExternenFonds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panTableLayout.SetColumnSpan(this.grpGesuchAnExternenFonds, 2);
            this.grpGesuchAnExternenFonds.Controls.Add(this.panTableLayoutGesuchanexternenFonds);
            this.grpGesuchAnExternenFonds.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpGesuchAnExternenFonds.Location = new System.Drawing.Point(3, 321);
            this.grpGesuchAnExternenFonds.Name = "grpGesuchAnExternenFonds";
            this.grpGesuchAnExternenFonds.Size = new System.Drawing.Size(1218, 318);
            this.grpGesuchAnExternenFonds.TabIndex = 7;
            this.grpGesuchAnExternenFonds.TabStop = false;
            this.grpGesuchAnExternenFonds.Text = "Gesuch an externen Fonds";
            this.grpGesuchAnExternenFonds.UseCompatibleTextRendering = true;
            // 
            // panTableLayoutGesuchanexternenFonds
            // 
            this.panTableLayoutGesuchanexternenFonds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panTableLayoutGesuchanexternenFonds.BackColor = System.Drawing.Color.Transparent;
            this.panTableLayoutGesuchanexternenFonds.ColumnCount = 2;
            this.panTableLayoutGesuchanexternenFonds.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.24793F));
            this.panTableLayoutGesuchanexternenFonds.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.75207F));
            this.panTableLayoutGesuchanexternenFonds.Controls.Add(this.panelGesuchanexterneFondsLinks, 0, 0);
            this.panTableLayoutGesuchanexternenFonds.Controls.Add(this.panelGesuchanexterneFondsRechtsIKS, 1, 0);
            this.panTableLayoutGesuchanexternenFonds.Location = new System.Drawing.Point(0, 18);
            this.panTableLayoutGesuchanexternenFonds.Name = "panTableLayoutGesuchanexternenFonds";
            this.panTableLayoutGesuchanexternenFonds.RowCount = 1;
            this.panTableLayoutGesuchanexternenFonds.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panTableLayoutGesuchanexternenFonds.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panTableLayoutGesuchanexternenFonds.Size = new System.Drawing.Size(1212, 308);
            this.panTableLayoutGesuchanexternenFonds.TabIndex = 16;
            // 
            // panelGesuchanexterneFondsLinks
            // 
            this.panelGesuchanexterneFondsLinks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGesuchanexterneFondsLinks.Controls.Add(this.btnExternerFondsAbschlussAufheben);
            this.panelGesuchanexterneFondsLinks.Controls.Add(this.edtExternerFondsGesuchsformular);
            this.panelGesuchanexterneFondsLinks.Controls.Add(this.lblExternerFondsGesuchsformular);
            this.panelGesuchanexterneFondsLinks.Controls.Add(this.btnExternerFondsGesuchAbschliessen);
            this.panelGesuchanexterneFondsLinks.Controls.Add(this.edtExternerFondsAbschlussgrund);
            this.panelGesuchanexterneFondsLinks.Controls.Add(this.lblExternerFondsAbschlussgrund);
            this.panelGesuchanexterneFondsLinks.Controls.Add(this.lblExternerFondsDatumAbschluss);
            this.panelGesuchanexterneFondsLinks.Controls.Add(this.edtExternerFondsDatumAbschluss);
            this.panelGesuchanexterneFondsLinks.Controls.Add(this.edtExternerFondsBemerkung);
            this.panelGesuchanexterneFondsLinks.Controls.Add(this.lblExternerFondsBemerkung);
            this.panelGesuchanexterneFondsLinks.Controls.Add(this.edtExternerFondsBewilligterBetrag);
            this.panelGesuchanexterneFondsLinks.Controls.Add(this.edtExternerFondsDatumEntscheid);
            this.panelGesuchanexterneFondsLinks.Controls.Add(this.lblExternerFondsDatumEntscheid);
            this.panelGesuchanexterneFondsLinks.Controls.Add(this.lblExternerFondsBewilligterBetrag);
            this.panelGesuchanexterneFondsLinks.Location = new System.Drawing.Point(3, 3);
            this.panelGesuchanexterneFondsLinks.Name = "panelGesuchanexterneFondsLinks";
            this.panelGesuchanexterneFondsLinks.Size = new System.Drawing.Size(603, 302);
            this.panelGesuchanexterneFondsLinks.TabIndex = 0;
            
            // 
            // btnExternerFondsAbschlussAufheben
            // 
            this.btnExternerFondsAbschlussAufheben.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExternerFondsAbschlussAufheben.Location = new System.Drawing.Point(392, 40);
            this.btnExternerFondsAbschlussAufheben.Name = "btnExternerFondsAbschlussAufheben";
            this.btnExternerFondsAbschlussAufheben.Size = new System.Drawing.Size(133, 24);
            this.btnExternerFondsAbschlussAufheben.TabIndex = 28;
            this.btnExternerFondsAbschlussAufheben.Text = "Abschluss aufheben";
            this.btnExternerFondsAbschlussAufheben.UseCompatibleTextRendering = true;
            this.btnExternerFondsAbschlussAufheben.UseVisualStyleBackColor = false;
            // 
            // edtExternerFondsGesuchsformular
            // 
            this.edtExternerFondsGesuchsformular.Context = "GV_Antrag";
            this.edtExternerFondsGesuchsformular.EditValue = "";
            this.edtExternerFondsGesuchsformular.Location = new System.Drawing.Point(112, 10);
            this.edtExternerFondsGesuchsformular.Name = "edtExternerFondsGesuchsformular";
            this.edtExternerFondsGesuchsformular.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtExternerFondsGesuchsformular.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtExternerFondsGesuchsformular.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtExternerFondsGesuchsformular.Properties.Appearance.Options.UseBackColor = true;
            this.edtExternerFondsGesuchsformular.Properties.Appearance.Options.UseBorderColor = true;
            this.edtExternerFondsGesuchsformular.Properties.Appearance.Options.UseFont = true;
            this.edtExternerFondsGesuchsformular.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            serializableAppearanceObject13.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject13.Options.UseBackColor = true;
            this.edtExternerFondsGesuchsformular.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtExternerFondsGesuchsformular.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtExternerFondsGesuchsformular.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtExternerFondsGesuchsformular.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtExternerFondsGesuchsformular.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13, "Dokument importieren")});
            this.edtExternerFondsGesuchsformular.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtExternerFondsGesuchsformular.Properties.ReadOnly = true;
            this.edtExternerFondsGesuchsformular.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtExternerFondsGesuchsformular.Size = new System.Drawing.Size(125, 24);
            this.edtExternerFondsGesuchsformular.TabIndex = 27;
            // 
            // lblExternerFondsGesuchsformular
            // 
            this.lblExternerFondsGesuchsformular.Location = new System.Drawing.Point(5, 10);
            this.lblExternerFondsGesuchsformular.Name = "lblExternerFondsGesuchsformular";
            this.lblExternerFondsGesuchsformular.Size = new System.Drawing.Size(105, 24);
            this.lblExternerFondsGesuchsformular.TabIndex = 26;
            this.lblExternerFondsGesuchsformular.Text = "Gesuchsformular";
            // 
            // btnExternerFondsGesuchAbschliessen
            // 
            this.btnExternerFondsGesuchAbschliessen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExternerFondsGesuchAbschliessen.Location = new System.Drawing.Point(392, 40);
            this.btnExternerFondsGesuchAbschliessen.Name = "btnExternerFondsGesuchAbschliessen";
            this.btnExternerFondsGesuchAbschliessen.Size = new System.Drawing.Size(133, 24);
            this.btnExternerFondsGesuchAbschliessen.TabIndex = 25;
            this.btnExternerFondsGesuchAbschliessen.Text = "Gesuch abschliessen";
            this.btnExternerFondsGesuchAbschliessen.UseCompatibleTextRendering = true;
            this.btnExternerFondsGesuchAbschliessen.UseVisualStyleBackColor = false;
            // 
            // edtExternerFondsAbschlussgrund
            // 
            this.edtExternerFondsAbschlussgrund.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtExternerFondsAbschlussgrund.Location = new System.Drawing.Point(296, 70);
            this.edtExternerFondsAbschlussgrund.LOVName = "GvAbschlussgrund";
            this.edtExternerFondsAbschlussgrund.Name = "edtExternerFondsAbschlussgrund";
            this.edtExternerFondsAbschlussgrund.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtExternerFondsAbschlussgrund.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtExternerFondsAbschlussgrund.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtExternerFondsAbschlussgrund.Properties.Appearance.Options.UseBackColor = true;
            this.edtExternerFondsAbschlussgrund.Properties.Appearance.Options.UseBorderColor = true;
            this.edtExternerFondsAbschlussgrund.Properties.Appearance.Options.UseFont = true;
            this.edtExternerFondsAbschlussgrund.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtExternerFondsAbschlussgrund.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtExternerFondsAbschlussgrund.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtExternerFondsAbschlussgrund.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtExternerFondsAbschlussgrund.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtExternerFondsAbschlussgrund.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtExternerFondsAbschlussgrund.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtExternerFondsAbschlussgrund.Properties.NullText = "";
            this.edtExternerFondsAbschlussgrund.Properties.ShowFooter = false;
            this.edtExternerFondsAbschlussgrund.Properties.ShowHeader = false;
            this.edtExternerFondsAbschlussgrund.Size = new System.Drawing.Size(301, 24);
            this.edtExternerFondsAbschlussgrund.TabIndex = 24;
            // 
            // lblExternerFondsAbschlussgrund
            // 
            this.lblExternerFondsAbschlussgrund.Location = new System.Drawing.Point(203, 70);
            this.lblExternerFondsAbschlussgrund.Name = "lblExternerFondsAbschlussgrund";
            this.lblExternerFondsAbschlussgrund.Size = new System.Drawing.Size(87, 24);
            this.lblExternerFondsAbschlussgrund.TabIndex = 23;
            this.lblExternerFondsAbschlussgrund.Text = "Abschlussgrund";
            // 
            // lblExternerFondsDatumAbschluss
            // 
            this.lblExternerFondsDatumAbschluss.Location = new System.Drawing.Point(203, 40);
            this.lblExternerFondsDatumAbschluss.Name = "lblExternerFondsDatumAbschluss";
            this.lblExternerFondsDatumAbschluss.Size = new System.Drawing.Size(87, 24);
            this.lblExternerFondsDatumAbschluss.TabIndex = 22;
            this.lblExternerFondsDatumAbschluss.Text = "Abschlussdatum";
            // 
            // edtExternerFondsDatumAbschluss
            // 
            this.edtExternerFondsDatumAbschluss.EditValue = null;
            this.edtExternerFondsDatumAbschluss.Location = new System.Drawing.Point(296, 40);
            this.edtExternerFondsDatumAbschluss.Name = "edtExternerFondsDatumAbschluss";
            this.edtExternerFondsDatumAbschluss.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtExternerFondsDatumAbschluss.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtExternerFondsDatumAbschluss.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtExternerFondsDatumAbschluss.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtExternerFondsDatumAbschluss.Properties.Appearance.Options.UseBackColor = true;
            this.edtExternerFondsDatumAbschluss.Properties.Appearance.Options.UseBorderColor = true;
            this.edtExternerFondsDatumAbschluss.Properties.Appearance.Options.UseFont = true;
            this.edtExternerFondsDatumAbschluss.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtExternerFondsDatumAbschluss.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtExternerFondsDatumAbschluss.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtExternerFondsDatumAbschluss.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtExternerFondsDatumAbschluss.Properties.ShowToday = false;
            this.edtExternerFondsDatumAbschluss.Size = new System.Drawing.Size(89, 24);
            this.edtExternerFondsDatumAbschluss.TabIndex = 21;
            // 
            // edtExternerFondsBemerkung
            // 
            this.edtExternerFondsBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtExternerFondsBemerkung.BackColor = System.Drawing.Color.White;
            this.edtExternerFondsBemerkung.EditValue = ((object)(resources.GetObject("edtExternerFondsBemerkung.EditValue")));
            this.edtExternerFondsBemerkung.Font = new System.Drawing.Font("Arial", 10F);
            this.edtExternerFondsBemerkung.Location = new System.Drawing.Point(112, 100);
            this.edtExternerFondsBemerkung.Name = "edtExternerFondsBemerkung";
            this.edtExternerFondsBemerkung.Size = new System.Drawing.Size(485, 191);
            this.edtExternerFondsBemerkung.TabIndex = 20;
            // 
            // lblExternerFondsBemerkung
            // 
            this.lblExternerFondsBemerkung.Location = new System.Drawing.Point(5, 100);
            this.lblExternerFondsBemerkung.Name = "lblExternerFondsBemerkung";
            this.lblExternerFondsBemerkung.Size = new System.Drawing.Size(105, 24);
            this.lblExternerFondsBemerkung.TabIndex = 19;
            this.lblExternerFondsBemerkung.Text = "Bemerkung";
            // 
            // edtExternerFondsBewilligterBetrag
            // 
            this.edtExternerFondsBewilligterBetrag.Location = new System.Drawing.Point(112, 70);
            this.edtExternerFondsBewilligterBetrag.Name = "edtExternerFondsBewilligterBetrag";
            this.edtExternerFondsBewilligterBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtExternerFondsBewilligterBetrag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtExternerFondsBewilligterBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtExternerFondsBewilligterBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtExternerFondsBewilligterBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtExternerFondsBewilligterBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtExternerFondsBewilligterBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtExternerFondsBewilligterBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtExternerFondsBewilligterBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtExternerFondsBewilligterBetrag.Properties.DisplayFormat.FormatString = "n2";
            this.edtExternerFondsBewilligterBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtExternerFondsBewilligterBetrag.Properties.EditFormat.FormatString = "n2";
            this.edtExternerFondsBewilligterBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtExternerFondsBewilligterBetrag.Properties.Mask.EditMask = "n2";
            this.edtExternerFondsBewilligterBetrag.Size = new System.Drawing.Size(88, 24);
            this.edtExternerFondsBewilligterBetrag.TabIndex = 18;
            // 
            // edtExternerFondsDatumEntscheid
            // 
            this.edtExternerFondsDatumEntscheid.EditValue = null;
            this.edtExternerFondsDatumEntscheid.Location = new System.Drawing.Point(112, 40);
            this.edtExternerFondsDatumEntscheid.Name = "edtExternerFondsDatumEntscheid";
            this.edtExternerFondsDatumEntscheid.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtExternerFondsDatumEntscheid.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtExternerFondsDatumEntscheid.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtExternerFondsDatumEntscheid.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtExternerFondsDatumEntscheid.Properties.Appearance.Options.UseBackColor = true;
            this.edtExternerFondsDatumEntscheid.Properties.Appearance.Options.UseBorderColor = true;
            this.edtExternerFondsDatumEntscheid.Properties.Appearance.Options.UseFont = true;
            this.edtExternerFondsDatumEntscheid.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtExternerFondsDatumEntscheid.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtExternerFondsDatumEntscheid.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtExternerFondsDatumEntscheid.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtExternerFondsDatumEntscheid.Properties.ShowToday = false;
            this.edtExternerFondsDatumEntscheid.Size = new System.Drawing.Size(88, 24);
            this.edtExternerFondsDatumEntscheid.TabIndex = 16;
            // 
            // lblExternerFondsDatumEntscheid
            // 
            this.lblExternerFondsDatumEntscheid.Location = new System.Drawing.Point(5, 40);
            this.lblExternerFondsDatumEntscheid.Name = "lblExternerFondsDatumEntscheid";
            this.lblExternerFondsDatumEntscheid.Size = new System.Drawing.Size(105, 24);
            this.lblExternerFondsDatumEntscheid.TabIndex = 15;
            this.lblExternerFondsDatumEntscheid.Text = "Entscheiddatum";
            // 
            // lblExternerFondsBewilligterBetrag
            // 
            this.lblExternerFondsBewilligterBetrag.Location = new System.Drawing.Point(5, 70);
            this.lblExternerFondsBewilligterBetrag.Name = "lblExternerFondsBewilligterBetrag";
            this.lblExternerFondsBewilligterBetrag.Size = new System.Drawing.Size(105, 24);
            this.lblExternerFondsBewilligterBetrag.TabIndex = 17;
            this.lblExternerFondsBewilligterBetrag.Text = "bewilligter Betrag";
            // 
            // panelGesuchanexterneFondsRechtsIKS
            // 
            this.panelGesuchanexterneFondsRechtsIKS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGesuchanexterneFondsRechtsIKS.Controls.Add(this.kissRTFEditAbgeschlossenesBemerkung);
            this.panelGesuchanexterneFondsRechtsIKS.Controls.Add(this.lblAbgeschlossenesGesuchBemerkung);
            this.panelGesuchanexterneFondsRechtsIKS.Controls.Add(this.edtAbgeschlossenesGesuchDurchIKS);
            this.panelGesuchanexterneFondsRechtsIKS.Controls.Add(this.lblAbgeschlossensGesuchDurchIKS);
            this.panelGesuchanexterneFondsRechtsIKS.Controls.Add(this.chkAbgeschlossenesGesuchBesprechen);
            this.panelGesuchanexterneFondsRechtsIKS.Controls.Add(this.edtAbgeschlossenesGesuchgeprueftam);
            this.panelGesuchanexterneFondsRechtsIKS.Controls.Add(this.lblAbgeschlossenesGesuchgeprueftam);
            this.panelGesuchanexterneFondsRechtsIKS.Controls.Add(this.kissRTFErfasstesGesuchBemerkung);
            this.panelGesuchanexterneFondsRechtsIKS.Controls.Add(this.lblErfasstesGesuchBemerkung);
            this.panelGesuchanexterneFondsRechtsIKS.Controls.Add(this.edtErfasstesGesuchgepreuftdurchIKS);
            this.panelGesuchanexterneFondsRechtsIKS.Controls.Add(this.lblErfasstesGesuchgepreuftdurchIKS);
            this.panelGesuchanexterneFondsRechtsIKS.Controls.Add(this.chkErfasstesGesuchBesprechen);
            this.panelGesuchanexterneFondsRechtsIKS.Controls.Add(this.edtErfasstesGesuchgeprueftam);
            this.panelGesuchanexterneFondsRechtsIKS.Controls.Add(this.lblErfasstesGesuchgeprueftam);
            this.panelGesuchanexterneFondsRechtsIKS.Location = new System.Drawing.Point(612, 3);
            this.panelGesuchanexterneFondsRechtsIKS.Name = "panelGesuchanexterneFondsRechtsIKS";
            this.panelGesuchanexterneFondsRechtsIKS.Size = new System.Drawing.Size(597, 302);
            this.panelGesuchanexterneFondsRechtsIKS.TabIndex = 1;
            // 
            // kissRTFEditAbgeschlossenesBemerkung
            // 
            this.kissRTFEditAbgeschlossenesBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kissRTFEditAbgeschlossenesBemerkung.BackColor = System.Drawing.Color.White;
            this.kissRTFEditAbgeschlossenesBemerkung.EditValue = ((object)(resources.GetObject("kissRTFEditAbgeschlossenesBemerkung.EditValue")));
            this.kissRTFEditAbgeschlossenesBemerkung.Font = new System.Drawing.Font("Arial", 10F);
            this.kissRTFEditAbgeschlossenesBemerkung.Location = new System.Drawing.Point(205, 205);
            this.kissRTFEditAbgeschlossenesBemerkung.Name = "kissRTFEditAbgeschlossenesBemerkung";
            this.kissRTFEditAbgeschlossenesBemerkung.Size = new System.Drawing.Size(388, 86);
            this.kissRTFEditAbgeschlossenesBemerkung.TabIndex = 33;
            // 
            // lblAbgeschlossenesGesuchBemerkung
            // 
            this.lblAbgeschlossenesGesuchBemerkung.Location = new System.Drawing.Point(3, 205);
            this.lblAbgeschlossenesGesuchBemerkung.Name = "lblAbgeschlossenesGesuchBemerkung";
            this.lblAbgeschlossenesGesuchBemerkung.Size = new System.Drawing.Size(105, 24);
            this.lblAbgeschlossenesGesuchBemerkung.TabIndex = 32;
            this.lblAbgeschlossenesGesuchBemerkung.Text = "Bemerkung";
            // 
            // edtAbgeschlossenesGesuchDurchIKS
            // 
            this.edtAbgeschlossenesGesuchDurchIKS.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAbgeschlossenesGesuchDurchIKS.Location = new System.Drawing.Point(205, 175);
            this.edtAbgeschlossenesGesuchDurchIKS.Name = "edtAbgeschlossenesGesuchDurchIKS";
            this.edtAbgeschlossenesGesuchDurchIKS.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAbgeschlossenesGesuchDurchIKS.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAbgeschlossenesGesuchDurchIKS.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbgeschlossenesGesuchDurchIKS.Properties.Appearance.Options.UseBackColor = true;
            this.edtAbgeschlossenesGesuchDurchIKS.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAbgeschlossenesGesuchDurchIKS.Properties.Appearance.Options.UseFont = true;
            this.edtAbgeschlossenesGesuchDurchIKS.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAbgeschlossenesGesuchDurchIKS.Properties.ReadOnly = true;
            this.edtAbgeschlossenesGesuchDurchIKS.Size = new System.Drawing.Size(211, 24);
            this.edtAbgeschlossenesGesuchDurchIKS.TabIndex = 31;
            // 
            // lblAbgeschlossensGesuchDurchIKS
            // 
            this.lblAbgeschlossensGesuchDurchIKS.Location = new System.Drawing.Point(2, 175);
            this.lblAbgeschlossensGesuchDurchIKS.Name = "lblAbgeschlossensGesuchDurchIKS";
            this.lblAbgeschlossensGesuchDurchIKS.Size = new System.Drawing.Size(102, 24);
            this.lblAbgeschlossensGesuchDurchIKS.TabIndex = 30;
            this.lblAbgeschlossensGesuchDurchIKS.Text = "durch IKS";
            // 
            // chkAbgeschlossenesGesuchBesprechen
            // 
            this.chkAbgeschlossenesGesuchBesprechen.EditValue = false;
            this.chkAbgeschlossenesGesuchBesprechen.Location = new System.Drawing.Point(377, 148);
            this.chkAbgeschlossenesGesuchBesprechen.Name = "chkAbgeschlossenesGesuchBesprechen";
            this.chkAbgeschlossenesGesuchBesprechen.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkAbgeschlossenesGesuchBesprechen.Properties.Appearance.Options.UseBackColor = true;
            this.chkAbgeschlossenesGesuchBesprechen.Properties.Caption = "besprechen";
            this.chkAbgeschlossenesGesuchBesprechen.Size = new System.Drawing.Size(87, 19);
            this.chkAbgeschlossenesGesuchBesprechen.TabIndex = 29;
            // 
            // edtAbgeschlossenesGesuchgeprueftam
            // 
            this.edtAbgeschlossenesGesuchgeprueftam.EditValue = null;
            this.edtAbgeschlossenesGesuchgeprueftam.Location = new System.Drawing.Point(205, 146);
            this.edtAbgeschlossenesGesuchgeprueftam.Name = "edtAbgeschlossenesGesuchgeprueftam";
            this.edtAbgeschlossenesGesuchgeprueftam.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAbgeschlossenesGesuchgeprueftam.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAbgeschlossenesGesuchgeprueftam.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAbgeschlossenesGesuchgeprueftam.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbgeschlossenesGesuchgeprueftam.Properties.Appearance.Options.UseBackColor = true;
            this.edtAbgeschlossenesGesuchgeprueftam.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAbgeschlossenesGesuchgeprueftam.Properties.Appearance.Options.UseFont = true;
            this.edtAbgeschlossenesGesuchgeprueftam.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtAbgeschlossenesGesuchgeprueftam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtAbgeschlossenesGesuchgeprueftam.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtAbgeschlossenesGesuchgeprueftam.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAbgeschlossenesGesuchgeprueftam.Properties.ShowToday = false;
            this.edtAbgeschlossenesGesuchgeprueftam.Size = new System.Drawing.Size(100, 24);
            this.edtAbgeschlossenesGesuchgeprueftam.TabIndex = 28;
            this.edtAbgeschlossenesGesuchgeprueftam.EditValueChanged += new System.EventHandler(this.edtAbgeschlossenesGesuchgeprueftam_EditValueChanged);
            // 
            // lblAbgeschlossenesGesuchgeprueftam
            // 
            this.lblAbgeschlossenesGesuchgeprueftam.Location = new System.Drawing.Point(3, 146);
            this.lblAbgeschlossenesGesuchgeprueftam.Name = "lblAbgeschlossenesGesuchgeprueftam";
            this.lblAbgeschlossenesGesuchgeprueftam.Size = new System.Drawing.Size(194, 24);
            this.lblAbgeschlossenesGesuchgeprueftam.TabIndex = 27;
            this.lblAbgeschlossenesGesuchgeprueftam.Text = "Abgeschlossenes Gesuch geprüft am";
            // 
            // kissRTFErfasstesGesuchBemerkung
            // 
            this.kissRTFErfasstesGesuchBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kissRTFErfasstesGesuchBemerkung.BackColor = System.Drawing.Color.White;
            this.kissRTFErfasstesGesuchBemerkung.EditValue = ((object)(resources.GetObject("kissRTFErfasstesGesuchBemerkung.EditValue")));
            this.kissRTFErfasstesGesuchBemerkung.Font = new System.Drawing.Font("Arial", 10F);
            this.kissRTFErfasstesGesuchBemerkung.Location = new System.Drawing.Point(205, 64);
            this.kissRTFErfasstesGesuchBemerkung.Name = "kissRTFErfasstesGesuchBemerkung";
            this.kissRTFErfasstesGesuchBemerkung.Size = new System.Drawing.Size(388, 78);
            this.kissRTFErfasstesGesuchBemerkung.TabIndex = 26;
            // 
            // lblErfasstesGesuchBemerkung
            // 
            this.lblErfasstesGesuchBemerkung.Location = new System.Drawing.Point(3, 64);
            this.lblErfasstesGesuchBemerkung.Name = "lblErfasstesGesuchBemerkung";
            this.lblErfasstesGesuchBemerkung.Size = new System.Drawing.Size(105, 24);
            this.lblErfasstesGesuchBemerkung.TabIndex = 25;
            this.lblErfasstesGesuchBemerkung.Text = "Bemerkung";
            // 
            // edtErfasstesGesuchgepreuftdurchIKS
            // 
            this.edtErfasstesGesuchgepreuftdurchIKS.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtErfasstesGesuchgepreuftdurchIKS.Location = new System.Drawing.Point(205, 34);
            this.edtErfasstesGesuchgepreuftdurchIKS.Name = "edtErfasstesGesuchgepreuftdurchIKS";
            this.edtErfasstesGesuchgepreuftdurchIKS.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtErfasstesGesuchgepreuftdurchIKS.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErfasstesGesuchgepreuftdurchIKS.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErfasstesGesuchgepreuftdurchIKS.Properties.Appearance.Options.UseBackColor = true;
            this.edtErfasstesGesuchgepreuftdurchIKS.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErfasstesGesuchgepreuftdurchIKS.Properties.Appearance.Options.UseFont = true;
            this.edtErfasstesGesuchgepreuftdurchIKS.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtErfasstesGesuchgepreuftdurchIKS.Properties.ReadOnly = true;
            this.edtErfasstesGesuchgepreuftdurchIKS.Size = new System.Drawing.Size(211, 24);
            this.edtErfasstesGesuchgepreuftdurchIKS.TabIndex = 24;
            // 
            // lblErfasstesGesuchgepreuftdurchIKS
            // 
            this.lblErfasstesGesuchgepreuftdurchIKS.Location = new System.Drawing.Point(3, 34);
            this.lblErfasstesGesuchgepreuftdurchIKS.Name = "lblErfasstesGesuchgepreuftdurchIKS";
            this.lblErfasstesGesuchgepreuftdurchIKS.Size = new System.Drawing.Size(102, 24);
            this.lblErfasstesGesuchgepreuftdurchIKS.TabIndex = 23;
            this.lblErfasstesGesuchgepreuftdurchIKS.Text = "durch IKS";
            // 
            // chkErfasstesGesuchBesprechen
            // 
            this.chkErfasstesGesuchBesprechen.EditValue = false;
            this.chkErfasstesGesuchBesprechen.Location = new System.Drawing.Point(377, 8);
            this.chkErfasstesGesuchBesprechen.Name = "chkErfasstesGesuchBesprechen";
            this.chkErfasstesGesuchBesprechen.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkErfasstesGesuchBesprechen.Properties.Appearance.Options.UseBackColor = true;
            this.chkErfasstesGesuchBesprechen.Properties.Caption = "besprechen";
            this.chkErfasstesGesuchBesprechen.Size = new System.Drawing.Size(87, 19);
            this.chkErfasstesGesuchBesprechen.TabIndex = 18;
            // 
            // edtErfasstesGesuchgeprueftam
            // 
            this.edtErfasstesGesuchgeprueftam.EditValue = null;
            this.edtErfasstesGesuchgeprueftam.Location = new System.Drawing.Point(205, 4);
            this.edtErfasstesGesuchgeprueftam.Name = "edtErfasstesGesuchgeprueftam";
            this.edtErfasstesGesuchgeprueftam.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtErfasstesGesuchgeprueftam.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErfasstesGesuchgeprueftam.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErfasstesGesuchgeprueftam.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErfasstesGesuchgeprueftam.Properties.Appearance.Options.UseBackColor = true;
            this.edtErfasstesGesuchgeprueftam.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErfasstesGesuchgeprueftam.Properties.Appearance.Options.UseFont = true;
            this.edtErfasstesGesuchgeprueftam.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtErfasstesGesuchgeprueftam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtErfasstesGesuchgeprueftam.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtErfasstesGesuchgeprueftam.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtErfasstesGesuchgeprueftam.Properties.ShowToday = false;
            this.edtErfasstesGesuchgeprueftam.Size = new System.Drawing.Size(100, 24);
            this.edtErfasstesGesuchgeprueftam.TabIndex = 17;
            this.edtErfasstesGesuchgeprueftam.EditValueChanged += new System.EventHandler(this.edtErfasstesGesuchgeprueftam_EditValueChanged);
            // 
            // lblErfasstesGesuchgeprueftam
            // 
            this.lblErfasstesGesuchgeprueftam.Location = new System.Drawing.Point(3, 7);
            this.lblErfasstesGesuchgeprueftam.Name = "lblErfasstesGesuchgeprueftam";
            this.lblErfasstesGesuchgeprueftam.Size = new System.Drawing.Size(151, 24);
            this.lblErfasstesGesuchgeprueftam.TabIndex = 16;
            this.lblErfasstesGesuchgeprueftam.Text = "Erfasstes Gesuch geprüft am";
            // 
            // CtlGvAntrag
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.panTableLayout);
            this.Name = "CtlGvAntrag";
            this.Size = new System.Drawing.Size(1230, 645);
            this.AddData += new System.EventHandler(this.CtlGvAntrag_AddData);
            this.DeleteData += new System.EventHandler(this.CtlGvAntrag_DeleteData);
            this.MoveFirst += new System.EventHandler(this.CtlGvAntrag_MoveFirst);
            this.MoveLast += new System.EventHandler(this.CtlGvAntrag_MoveLast);
            this.MoveNext += new System.EventHandler(this.CtlGvAntrag_MoveNext);
            this.MovePrevious += new System.EventHandler(this.CtlGvAntrag_MovePrevious);
            this.RefreshData += new System.EventHandler(this.CtlGvAntrag_RefreshData);
            this.SaveData += new System.EventHandler(this.CtlGvAntrag_SaveData);
            this.UndoDataChanges += new System.EventHandler(this.CtlGvAntrag_UndoDataChanges);
            this.Load += new System.EventHandler(this.CtlGvAntrag_Load);
            this.panTableLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblFinanzierung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKosten)).EndInit();
            this.panelKosten.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryGvKosten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenBezeichnung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenbezeichnung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenBetrag)).EndInit();
            this.panelFinanzierung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtFinanzierungBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryGvFinanzierung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFinanzierungQuelle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFinanzierungQuelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFinanzierungBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKosten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKosten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFinanzierung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFinanzierung)).EndInit();
            this.pnlKompetenz.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkEigenkompetenz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKompetenzBSL.Properties)).EndInit();
            this.grpGesuchAnExternenFonds.ResumeLayout(false);
            this.panTableLayoutGesuchanexternenFonds.ResumeLayout(false);
            this.panelGesuchanexterneFondsLinks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtExternerFondsGesuchsformular.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblExternerFondsGesuchsformular)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtExternerFondsAbschlussgrund.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtExternerFondsAbschlussgrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblExternerFondsAbschlussgrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblExternerFondsDatumAbschluss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtExternerFondsDatumAbschluss.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblExternerFondsBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtExternerFondsBewilligterBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtExternerFondsDatumEntscheid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblExternerFondsDatumEntscheid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblExternerFondsBewilligterBetrag)).EndInit();
            this.panelGesuchanexterneFondsRechtsIKS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblAbgeschlossenesGesuchBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbgeschlossenesGesuchDurchIKS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbgeschlossensGesuchDurchIKS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAbgeschlossenesGesuchBesprechen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbgeschlossenesGesuchgeprueftam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbgeschlossenesGesuchgeprueftam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfasstesGesuchBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfasstesGesuchgepreuftdurchIKS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfasstesGesuchgepreuftdurchIKS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkErfasstesGesuchBesprechen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfasstesGesuchgeprueftam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfasstesGesuchgeprueftam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panTableLayout;
        private Gui.KissLabel lblFinanzierung;
        private Gui.KissLabel lblKosten;
        private Gui.KissGrid grdKosten;
        private Gui.KissGrid grdFinanzierung;
        private System.Windows.Forms.Panel panelKosten;
        private Gui.KissLabel lblKostenbezeichnung;
        private Gui.KissLabel lblKostenBetrag;
        private System.Windows.Forms.Panel panelFinanzierung;
        private Gui.KissTextEdit edtKostenBezeichnung;
        private Gui.KissTextEdit edtFinanzierungQuelle;
        private Gui.KissLabel lblFinanzierungQuelle;
        private Gui.KissLabel lblFinanzierungBetrag;
        private Gui.KissGroupBox grpGesuchAnExternenFonds;
        private Gui.KissCheckEdit chkEigenkompetenz;
        private Gui.KissCheckEdit chkKompetenzBSL;
        private DevExpress.XtraGrid.Views.Grid.GridView grvFinanzierung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKosten;
        private DevExpress.XtraGrid.Columns.GridColumn colKostenKostenbezeichnung;
        private DevExpress.XtraGrid.Columns.GridColumn colKostenBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colFinanzierungQuelle;
        private DevExpress.XtraGrid.Columns.GridColumn colFinanzierungBetrag;
        private DB.SqlQuery qryGvKosten;
        private DB.SqlQuery qryGvFinanzierung;
        private Gui.KissCalcEdit edtKostenBetrag;
        private Gui.KissCalcEdit edtFinanzierungBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colFinanzierungSortKey;
        private DevExpress.XtraGrid.Columns.GridColumn colKostenSortBezeichnung;
        private System.Windows.Forms.Panel pnlKompetenz;
        private System.Windows.Forms.TableLayoutPanel panTableLayoutGesuchanexternenFonds;
        private System.Windows.Forms.Panel panelGesuchanexterneFondsLinks;
        private Gui.KissButton btnExternerFondsAbschlussAufheben;
        private Dokument.XDokument edtExternerFondsGesuchsformular;
        private Gui.KissLabel lblExternerFondsGesuchsformular;
        private Gui.KissButton btnExternerFondsGesuchAbschliessen;
        private Gui.KissLookUpEdit edtExternerFondsAbschlussgrund;
        private Gui.KissLabel lblExternerFondsAbschlussgrund;
        private Gui.KissLabel lblExternerFondsDatumAbschluss;
        private Gui.KissDateEdit edtExternerFondsDatumAbschluss;
        private Gui.KissRTFEdit edtExternerFondsBemerkung;
        private Gui.KissLabel lblExternerFondsBemerkung;
        private Gui.KissCalcEdit edtExternerFondsBewilligterBetrag;
        private Gui.KissDateEdit edtExternerFondsDatumEntscheid;
        private Gui.KissLabel lblExternerFondsDatumEntscheid;
        private Gui.KissLabel lblExternerFondsBewilligterBetrag;
        private System.Windows.Forms.Panel panelGesuchanexterneFondsRechtsIKS;
        private Gui.KissLabel lblErfasstesGesuchgeprueftam;
        private Gui.KissDateEdit edtErfasstesGesuchgeprueftam;
        private Gui.KissCheckEdit chkErfasstesGesuchBesprechen;
        private Gui.KissLabel lblErfasstesGesuchgepreuftdurchIKS;
        private Gui.KissRTFEdit kissRTFErfasstesGesuchBemerkung;
        private Gui.KissLabel lblErfasstesGesuchBemerkung;
        private Gui.KissTextEdit edtErfasstesGesuchgepreuftdurchIKS;
        private Gui.KissLabel lblAbgeschlossenesGesuchgeprueftam;
        private Gui.KissDateEdit edtAbgeschlossenesGesuchgeprueftam;
        private Gui.KissCheckEdit chkAbgeschlossenesGesuchBesprechen;
        private Gui.KissTextEdit edtAbgeschlossenesGesuchDurchIKS;
        private Gui.KissLabel lblAbgeschlossensGesuchDurchIKS;
        private Gui.KissLabel lblAbgeschlossenesGesuchBemerkung;
        private Gui.KissRTFEdit kissRTFEditAbgeschlossenesBemerkung;
    }
}
