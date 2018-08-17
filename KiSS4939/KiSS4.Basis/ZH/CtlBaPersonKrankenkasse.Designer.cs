namespace KiSS4.Basis.ZH
{
    public partial class CtlBaPersonKrankenkasse
    {
        #region Fields
        private KiSS4.Gui.KissButton btnCopy;
        private KiSS4.Gui.KissCheckEdit chkTaggeldversicherung;
        private KiSS4.Gui.KissCheckEdit chkUnfallEinschluss;
        private KiSS4.Gui.KissCheckEdit chkZahnversicherung;
        private DevExpress.XtraGrid.Columns.GridColumn colAnspruch;
        private DevExpress.XtraGrid.Columns.GridColumn colAuszahlung;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumBis;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colFranchise;
        private DevExpress.XtraGrid.Columns.GridColumn colGesetzesGrundlageCode;
        private DevExpress.XtraGrid.Columns.GridColumn colGrund;
        private DevExpress.XtraGrid.Columns.GridColumn colIPVJahr;
        private DevExpress.XtraGrid.Columns.GridColumn colInstitutionName;
        private DevExpress.XtraGrid.Columns.GridColumn colLetzeMutation;
        private DevExpress.XtraGrid.Columns.GridColumn colPraemie;
        private DevExpress.XtraGrid.Columns.GridColumn colZahlungAn;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissLookUpEdit ddlBezahltDurchSD;
        private KiSS4.Gui.KissButtonEdit dlgInstitution;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissCalcEdit edtFranchise;
        private KiSS4.Gui.KissCheckEdit edtGanzeSchweiz;
        private KiSS4.Gui.KissCalcEdit edtKVGPraemienVerbillBetrag;
        private KiSS4.Gui.KissTextEdit edtMitgliedNr;
        private KiSS4.Gui.KissCalcEdit edtPraemie;
        private KiSS4.Gui.KissCalcEdit edtTaggeldversicherungBetrag;
        private KiSS4.Gui.KissGrid grdBaKrankenversicherung;
        private KiSS4.Gui.KissGrid grdPraemienuebernahme;
        private KiSS4.Gui.KissGrid grdPraemienverbilligung;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBaKrankenversicherung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBaPraemienuebernahme;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPraemienuebernahme;
        private KiSS4.Gui.KissLabel kissLabel100;
        private KiSS4.Gui.KissLabel kissLabel11;
        private KiSS4.Gui.KissLabel kissLabel15a;
        private KiSS4.Gui.KissLabel kissLabel23a;
        private KiSS4.Gui.KissLabel kissLabel24a;
        private KiSS4.Gui.KissLabel kissLabel3;
        private KiSS4.Gui.KissLabel kissLabel4;
        private KiSS4.Gui.KissLabel kissLabel49;
        private KiSS4.Gui.KissLabel kissLabel52;
        private KiSS4.Gui.KissLabel kissLabel6;
        private KiSS4.Gui.KissLabel kissLabel85;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblBezahltDurchCode;
        private KiSS4.Gui.KissLabel lblDatumVon;
        private KiSS4.Gui.KissLabel lblFranchise;
        private KiSS4.Gui.KissLabel lblInstitutionName;
        private KiSS4.Gui.KissLabel lblMitgliedNr;
        private KiSS4.Gui.KissLabel lblPraemie;
        private KiSS4.Gui.KissMemoEdit memBemerkung;
        private System.Windows.Forms.Panel panel1;
        private KiSS4.DB.SqlQuery qryBaPraemienuebernahme;
        private KiSS4.DB.SqlQuery qryBaPraemienverbilligung;
        private KiSS4.Gui.KissRadioGroup rgrGesetz;

        public KiSS4.DB.SqlQuery qryBaKrankenversicherung;

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBaPersonKrankenkasse));
            this.grdBaKrankenversicherung = new KiSS4.Gui.KissGrid();
            this.qryBaKrankenversicherung = new KiSS4.DB.SqlQuery(this.components);
            this.grvBaKrankenversicherung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colGesetzesGrundlageCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInstitutionName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPraemie = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFranchise = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rgrGesetz = new KiSS4.Gui.KissRadioGroup(this.components);
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.dlgInstitution = new KiSS4.Gui.KissButtonEdit();
            this.edtMitgliedNr = new KiSS4.Gui.KissTextEdit();
            this.edtPraemie = new KiSS4.Gui.KissCalcEdit();
            this.edtFranchise = new KiSS4.Gui.KissCalcEdit();
            this.ddlBezahltDurchSD = new KiSS4.Gui.KissLookUpEdit();
            this.chkUnfallEinschluss = new KiSS4.Gui.KissCheckEdit();
            this.chkZahnversicherung = new KiSS4.Gui.KissCheckEdit();
            this.chkTaggeldversicherung = new KiSS4.Gui.KissCheckEdit();
            this.edtTaggeldversicherungBetrag = new KiSS4.Gui.KissCalcEdit();
            this.edtKVGPraemienVerbillBetrag = new KiSS4.Gui.KissCalcEdit();
            this.memBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.btnCopy = new KiSS4.Gui.KissButton();
            this.lblInstitutionName = new KiSS4.Gui.KissLabel();
            this.lblMitgliedNr = new KiSS4.Gui.KissLabel();
            this.lblPraemie = new KiSS4.Gui.KissLabel();
            this.kissLabel23a = new KiSS4.Gui.KissLabel();
            this.lblFranchise = new KiSS4.Gui.KissLabel();
            this.kissLabel24a = new KiSS4.Gui.KissLabel();
            this.kissLabel15a = new KiSS4.Gui.KissLabel();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.lblDatumVon = new KiSS4.Gui.KissLabel();
            this.kissLabel85 = new KiSS4.Gui.KissLabel();
            this.kissLabel100 = new KiSS4.Gui.KissLabel();
            this.lblBezahltDurchCode = new KiSS4.Gui.KissLabel();
            this.kissLabel6 = new KiSS4.Gui.KissLabel();
            this.kissLabel49 = new KiSS4.Gui.KissLabel();
            this.kissLabel52 = new KiSS4.Gui.KissLabel();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kissLabel11 = new KiSS4.Gui.KissLabel();
            this.grdPraemienuebernahme = new KiSS4.Gui.KissGrid();
            this.qryBaPraemienuebernahme = new KiSS4.DB.SqlQuery(this.components);
            this.grvBaPraemienuebernahme = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.grdPraemienverbilligung = new KiSS4.Gui.KissGrid();
            this.qryBaPraemienverbilligung = new KiSS4.DB.SqlQuery(this.components);
            this.grvPraemienuebernahme = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIPVJahr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnspruch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuszahlung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZahlungAn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLetzeMutation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGrund = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtGanzeSchweiz = new KiSS4.Gui.KissCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaKrankenversicherung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaKrankenversicherung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaKrankenversicherung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgrGesetz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgrGesetz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dlgInstitution.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitgliedNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPraemie.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFranchise.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlBezahltDurchSD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlBezahltDurchSD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUnfallEinschluss.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkZahnversicherung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTaggeldversicherung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTaggeldversicherungBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGPraemienVerbillBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInstitutionName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMitgliedNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPraemie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel23a)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFranchise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel24a)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel15a)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel85)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel100)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBezahltDurchCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel49)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPraemienuebernahme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPraemienuebernahme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaPraemienuebernahme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPraemienverbilligung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPraemienverbilligung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPraemienuebernahme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGanzeSchweiz.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdBaKrankenversicherung
            // 
            this.grdBaKrankenversicherung.DataSource = this.qryBaKrankenversicherung;
            // 
            // 
            // 
            this.grdBaKrankenversicherung.EmbeddedNavigator.Name = "kissGrid3.EmbeddedNavigator";
            this.grdBaKrankenversicherung.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBaKrankenversicherung.Location = new System.Drawing.Point(6, 7);
            this.grdBaKrankenversicherung.MainView = this.grvBaKrankenversicherung;
            this.grdBaKrankenversicherung.Name = "grdBaKrankenversicherung";
            this.grdBaKrankenversicherung.Size = new System.Drawing.Size(687, 115);
            this.grdBaKrankenversicherung.TabIndex = 0;
            this.grdBaKrankenversicherung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBaKrankenversicherung});
            // 
            // qryBaKrankenversicherung
            // 
            this.qryBaKrankenversicherung.CanDelete = true;
            this.qryBaKrankenversicherung.CanInsert = true;
            this.qryBaKrankenversicherung.CanUpdate = true;
            this.qryBaKrankenversicherung.HostControl = this;
            this.qryBaKrankenversicherung.SelectStatement = resources.GetString("qryBaKrankenversicherung.SelectStatement");
            this.qryBaKrankenversicherung.TableName = "BaKrankenversicherung";
            this.qryBaKrankenversicherung.AfterFill += new System.EventHandler(this.qryBaKrankenversicherung_AfterFill);
            this.qryBaKrankenversicherung.AfterInsert += new System.EventHandler(this.qryBaKrankenversicherung_AfterInsert);
            this.qryBaKrankenversicherung.AfterPost += new System.EventHandler(this.qryBaKrankenversicherung_AfterPost);
            this.qryBaKrankenversicherung.BeforePost += new System.EventHandler(this.qryBaKrankenversicherung_BeforePost);
            this.qryBaKrankenversicherung.PositionChanged += new System.EventHandler(this.qryBaKrankenversicherung_PositionChanged);
            // 
            // grvBaKrankenversicherung
            // 
            this.grvBaKrankenversicherung.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBaKrankenversicherung.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaKrankenversicherung.Appearance.Empty.Options.UseBackColor = true;
            this.grvBaKrankenversicherung.Appearance.Empty.Options.UseFont = true;
            this.grvBaKrankenversicherung.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaKrankenversicherung.Appearance.EvenRow.Options.UseFont = true;
            this.grvBaKrankenversicherung.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBaKrankenversicherung.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaKrankenversicherung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBaKrankenversicherung.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBaKrankenversicherung.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBaKrankenversicherung.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBaKrankenversicherung.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBaKrankenversicherung.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaKrankenversicherung.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBaKrankenversicherung.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBaKrankenversicherung.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBaKrankenversicherung.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBaKrankenversicherung.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaKrankenversicherung.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBaKrankenversicherung.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaKrankenversicherung.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBaKrankenversicherung.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBaKrankenversicherung.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBaKrankenversicherung.Appearance.GroupRow.Options.UseFont = true;
            this.grvBaKrankenversicherung.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBaKrankenversicherung.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBaKrankenversicherung.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBaKrankenversicherung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBaKrankenversicherung.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBaKrankenversicherung.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBaKrankenversicherung.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBaKrankenversicherung.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBaKrankenversicherung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaKrankenversicherung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBaKrankenversicherung.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBaKrankenversicherung.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBaKrankenversicherung.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBaKrankenversicherung.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBaKrankenversicherung.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBaKrankenversicherung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaKrankenversicherung.Appearance.OddRow.Options.UseFont = true;
            this.grvBaKrankenversicherung.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBaKrankenversicherung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaKrankenversicherung.Appearance.Row.Options.UseBackColor = true;
            this.grvBaKrankenversicherung.Appearance.Row.Options.UseFont = true;
            this.grvBaKrankenversicherung.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaKrankenversicherung.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBaKrankenversicherung.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBaKrankenversicherung.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBaKrankenversicherung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBaKrankenversicherung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colGesetzesGrundlageCode,
            this.colDatumVon,
            this.colDatumBis,
            this.colInstitutionName,
            this.colPraemie,
            this.colFranchise});
            this.grvBaKrankenversicherung.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBaKrankenversicherung.GridControl = this.grdBaKrankenversicherung;
            this.grvBaKrankenversicherung.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvBaKrankenversicherung.Name = "grvBaKrankenversicherung";
            this.grvBaKrankenversicherung.OptionsBehavior.Editable = false;
            this.grvBaKrankenversicherung.OptionsCustomization.AllowFilter = false;
            this.grvBaKrankenversicherung.OptionsFilter.AllowFilterEditor = false;
            this.grvBaKrankenversicherung.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBaKrankenversicherung.OptionsMenu.EnableColumnMenu = false;
            this.grvBaKrankenversicherung.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBaKrankenversicherung.OptionsNavigation.UseTabKey = false;
            this.grvBaKrankenversicherung.OptionsView.ColumnAutoWidth = false;
            this.grvBaKrankenversicherung.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBaKrankenversicherung.OptionsView.ShowGroupPanel = false;
            this.grvBaKrankenversicherung.OptionsView.ShowIndicator = false;
            // 
            // colGesetzesGrundlageCode
            // 
            this.colGesetzesGrundlageCode.Caption = "Gesetz";
            this.colGesetzesGrundlageCode.FieldName = "GesetzesGrundlageCode";
            this.colGesetzesGrundlageCode.Name = "colGesetzesGrundlageCode";
            this.colGesetzesGrundlageCode.Visible = true;
            this.colGesetzesGrundlageCode.VisibleIndex = 0;
            this.colGesetzesGrundlageCode.Width = 71;
            // 
            // colDatumVon
            // 
            this.colDatumVon.Caption = "von";
            this.colDatumVon.FieldName = "DatumVon";
            this.colDatumVon.Name = "colDatumVon";
            this.colDatumVon.Visible = true;
            this.colDatumVon.VisibleIndex = 1;
            // 
            // colDatumBis
            // 
            this.colDatumBis.Caption = "bis";
            this.colDatumBis.FieldName = "DatumBis";
            this.colDatumBis.Name = "colDatumBis";
            this.colDatumBis.Visible = true;
            this.colDatumBis.VisibleIndex = 2;
            // 
            // colInstitutionName
            // 
            this.colInstitutionName.Caption = "Krankenkasse";
            this.colInstitutionName.FieldName = "InstitutionName";
            this.colInstitutionName.Name = "colInstitutionName";
            this.colInstitutionName.Visible = true;
            this.colInstitutionName.VisibleIndex = 3;
            this.colInstitutionName.Width = 281;
            // 
            // colPraemie
            // 
            this.colPraemie.AppearanceCell.Options.UseTextOptions = true;
            this.colPraemie.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colPraemie.AppearanceHeader.Options.UseTextOptions = true;
            this.colPraemie.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colPraemie.Caption = "Prämie";
            this.colPraemie.DisplayFormat.FormatString = "#,#.00";
            this.colPraemie.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPraemie.FieldName = "Praemie";
            this.colPraemie.Name = "colPraemie";
            this.colPraemie.Visible = true;
            this.colPraemie.VisibleIndex = 4;
            this.colPraemie.Width = 87;
            // 
            // colFranchise
            // 
            this.colFranchise.AppearanceCell.Options.UseTextOptions = true;
            this.colFranchise.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colFranchise.AppearanceHeader.Options.UseTextOptions = true;
            this.colFranchise.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colFranchise.Caption = "Franchise";
            this.colFranchise.DisplayFormat.FormatString = "#,#.00";
            this.colFranchise.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colFranchise.FieldName = "Franchise";
            this.colFranchise.Name = "colFranchise";
            this.colFranchise.Visible = true;
            this.colFranchise.VisibleIndex = 5;
            // 
            // rgrGesetz
            // 
            this.rgrGesetz.DataMember = "GesetzesGrundlageCode";
            this.rgrGesetz.DataSource = this.qryBaKrankenversicherung;
            this.rgrGesetz.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.rgrGesetz.EditValue = null;
            this.rgrGesetz.Location = new System.Drawing.Point(107, 132);
            this.rgrGesetz.LookupSQL = null;
            this.rgrGesetz.LOVFilter = null;
            this.rgrGesetz.LOVName = null;
            this.rgrGesetz.Name = "rgrGesetz";
            this.rgrGesetz.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgrGesetz.Properties.Appearance.Options.UseBackColor = true;
            this.rgrGesetz.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.rgrGesetz.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.rgrGesetz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgrGesetz.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "KVG"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "VVG")});
            this.rgrGesetz.Size = new System.Drawing.Size(100, 25);
            this.rgrGesetz.TabIndex = 1;
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.DataMember = "DatumVon";
            this.edtDatumVon.DataSource = this.qryBaKrankenversicherung;
            this.edtDatumVon.EditMode = Kiss.Interfaces.UI.EditModeType.Optional;
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(107, 162);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.Name = "kissDateEdit11.Properties";
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVon.TabIndex = 2;
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.DataMember = "DatumBis";
            this.edtDatumBis.DataSource = this.qryBaKrankenversicherung;
            this.edtDatumBis.EditMode = Kiss.Interfaces.UI.EditModeType.Optional;
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(239, 162);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.Name = "kissDateEdit12.Properties";
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBis.TabIndex = 3;
            // 
            // dlgInstitution
            // 
            this.dlgInstitution.DataMember = "InstitutionName";
            this.dlgInstitution.DataSource = this.qryBaKrankenversicherung;
            this.dlgInstitution.Location = new System.Drawing.Point(107, 192);
            this.dlgInstitution.Name = "dlgInstitution";
            this.dlgInstitution.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.dlgInstitution.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.dlgInstitution.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.dlgInstitution.Properties.Appearance.Options.UseBackColor = true;
            this.dlgInstitution.Properties.Appearance.Options.UseBorderColor = true;
            this.dlgInstitution.Properties.Appearance.Options.UseFont = true;
            this.dlgInstitution.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.dlgInstitution.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.dlgInstitution.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.dlgInstitution.Properties.Name = "editKVGKrankenKasse.Properties";
            this.dlgInstitution.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.dlgInstitution.Size = new System.Drawing.Size(309, 24);
            this.dlgInstitution.TabIndex = 4;
            this.dlgInstitution.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.dlgInstitution_UserModifiedFld);
            // 
            // edtMitgliedNr
            // 
            this.edtMitgliedNr.DataMember = "MitgliedNr";
            this.edtMitgliedNr.DataSource = this.qryBaKrankenversicherung;
            this.edtMitgliedNr.Location = new System.Drawing.Point(107, 222);
            this.edtMitgliedNr.Name = "edtMitgliedNr";
            this.edtMitgliedNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMitgliedNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMitgliedNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMitgliedNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtMitgliedNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMitgliedNr.Properties.Appearance.Options.UseFont = true;
            this.edtMitgliedNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMitgliedNr.Properties.MaxLength = 50;
            this.edtMitgliedNr.Properties.Name = "editKVGMitgliedNr.Properties";
            this.edtMitgliedNr.Size = new System.Drawing.Size(309, 24);
            this.edtMitgliedNr.TabIndex = 5;
            // 
            // edtPraemie
            // 
            this.edtPraemie.DataMember = "Praemie";
            this.edtPraemie.DataSource = this.qryBaKrankenversicherung;
            this.edtPraemie.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtPraemie.Location = new System.Drawing.Point(107, 252);
            this.edtPraemie.Name = "edtPraemie";
            this.edtPraemie.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtPraemie.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtPraemie.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPraemie.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPraemie.Properties.Appearance.Options.UseBackColor = true;
            this.edtPraemie.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPraemie.Properties.Appearance.Options.UseFont = true;
            this.edtPraemie.Properties.Appearance.Options.UseTextOptions = true;
            this.edtPraemie.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.edtPraemie.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.edtPraemie.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.edtPraemie.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPraemie.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPraemie.Properties.DisplayFormat.FormatString = "n2";
            this.edtPraemie.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtPraemie.Properties.EditFormat.FormatString = "n2";
            this.edtPraemie.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtPraemie.Properties.Mask.EditMask = "n2";
            this.edtPraemie.Size = new System.Drawing.Size(88, 24);
            this.edtPraemie.TabIndex = 6;
            // 
            // edtFranchise
            // 
            this.edtFranchise.DataMember = "Franchise";
            this.edtFranchise.DataSource = this.qryBaKrankenversicherung;
            this.edtFranchise.EditMode = Kiss.Interfaces.UI.EditModeType.Optional;
            this.edtFranchise.Location = new System.Drawing.Point(331, 252);
            this.edtFranchise.Name = "edtFranchise";
            this.edtFranchise.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtFranchise.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.edtFranchise.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFranchise.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFranchise.Properties.Appearance.Options.UseBackColor = true;
            this.edtFranchise.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFranchise.Properties.Appearance.Options.UseFont = true;
            this.edtFranchise.Properties.Appearance.Options.UseTextOptions = true;
            this.edtFranchise.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.edtFranchise.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFranchise.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFranchise.Properties.DisplayFormat.FormatString = "n2";
            this.edtFranchise.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtFranchise.Properties.EditFormat.FormatString = "n2";
            this.edtFranchise.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtFranchise.Properties.Mask.EditMask = "n2";
            this.edtFranchise.Size = new System.Drawing.Size(85, 24);
            this.edtFranchise.TabIndex = 7;
            // 
            // ddlBezahltDurchSD
            // 
            this.ddlBezahltDurchSD.DataMember = "BezahltDurchCode";
            this.ddlBezahltDurchSD.DataSource = this.qryBaKrankenversicherung;
            this.ddlBezahltDurchSD.EditMode = Kiss.Interfaces.UI.EditModeType.Optional;
            this.ddlBezahltDurchSD.Location = new System.Drawing.Point(107, 282);
            this.ddlBezahltDurchSD.LOVName = "BaKKPraemieBezahltVon";
            this.ddlBezahltDurchSD.Name = "ddlBezahltDurchSD";
            this.ddlBezahltDurchSD.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.ddlBezahltDurchSD.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.ddlBezahltDurchSD.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ddlBezahltDurchSD.Properties.Appearance.Options.UseBackColor = true;
            this.ddlBezahltDurchSD.Properties.Appearance.Options.UseBorderColor = true;
            this.ddlBezahltDurchSD.Properties.Appearance.Options.UseFont = true;
            this.ddlBezahltDurchSD.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ddlBezahltDurchSD.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ddlBezahltDurchSD.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.ddlBezahltDurchSD.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ddlBezahltDurchSD.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.ddlBezahltDurchSD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.ddlBezahltDurchSD.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ddlBezahltDurchSD.Properties.Name = "kissLookUpEdit7.Properties";
            this.ddlBezahltDurchSD.Properties.NullText = "";
            this.ddlBezahltDurchSD.Properties.ShowFooter = false;
            this.ddlBezahltDurchSD.Properties.ShowHeader = false;
            this.ddlBezahltDurchSD.Size = new System.Drawing.Size(309, 24);
            this.ddlBezahltDurchSD.TabIndex = 8;
            // 
            // chkUnfallEinschluss
            // 
            this.chkUnfallEinschluss.DataMember = "UnfallEinschluss";
            this.chkUnfallEinschluss.DataSource = this.qryBaKrankenversicherung;
            this.chkUnfallEinschluss.EditMode = Kiss.Interfaces.UI.EditModeType.Optional;
            this.chkUnfallEinschluss.Location = new System.Drawing.Point(457, 154);
            this.chkUnfallEinschluss.Name = "chkUnfallEinschluss";
            this.chkUnfallEinschluss.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.chkUnfallEinschluss.Properties.Appearance.Options.UseBackColor = true;
            this.chkUnfallEinschluss.Properties.Caption = "Unfalleinschluss";
            this.chkUnfallEinschluss.Properties.Name = "edtKVGUnfallEinschluss.Properties";
            this.chkUnfallEinschluss.Size = new System.Drawing.Size(123, 19);
            this.chkUnfallEinschluss.TabIndex = 9;
            // 
            // chkZahnversicherung
            // 
            this.chkZahnversicherung.DataMember = "Zahnversicherung";
            this.chkZahnversicherung.DataSource = this.qryBaKrankenversicherung;
            this.chkZahnversicherung.Location = new System.Drawing.Point(457, 174);
            this.chkZahnversicherung.Name = "chkZahnversicherung";
            this.chkZahnversicherung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkZahnversicherung.Properties.Appearance.Options.UseBackColor = true;
            this.chkZahnversicherung.Properties.Caption = "Zahnversicherung";
            this.chkZahnversicherung.Properties.Name = "kissCheckEdit2.Properties";
            this.chkZahnversicherung.Size = new System.Drawing.Size(123, 19);
            this.chkZahnversicherung.TabIndex = 10;
            // 
            // chkTaggeldversicherung
            // 
            this.chkTaggeldversicherung.DataMember = "Taggeldversicherung";
            this.chkTaggeldversicherung.DataSource = this.qryBaKrankenversicherung;
            this.chkTaggeldversicherung.Location = new System.Drawing.Point(457, 194);
            this.chkTaggeldversicherung.Name = "chkTaggeldversicherung";
            this.chkTaggeldversicherung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkTaggeldversicherung.Properties.Appearance.Options.UseBackColor = true;
            this.chkTaggeldversicherung.Properties.Caption = "Taggeldversicherung";
            this.chkTaggeldversicherung.Size = new System.Drawing.Size(123, 19);
            this.chkTaggeldversicherung.TabIndex = 11;
            // 
            // edtTaggeldversicherungBetrag
            // 
            this.edtTaggeldversicherungBetrag.DataMember = "TaggeldversicherungBetrag";
            this.edtTaggeldversicherungBetrag.DataSource = this.qryBaKrankenversicherung;
            this.edtTaggeldversicherungBetrag.Location = new System.Drawing.Point(586, 191);
            this.edtTaggeldversicherungBetrag.Name = "edtTaggeldversicherungBetrag";
            this.edtTaggeldversicherungBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtTaggeldversicherungBetrag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTaggeldversicherungBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTaggeldversicherungBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTaggeldversicherungBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtTaggeldversicherungBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTaggeldversicherungBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtTaggeldversicherungBetrag.Properties.Appearance.Options.UseTextOptions = true;
            this.edtTaggeldversicherungBetrag.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.edtTaggeldversicherungBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTaggeldversicherungBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTaggeldversicherungBetrag.Properties.DisplayFormat.FormatString = "n2";
            this.edtTaggeldversicherungBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtTaggeldversicherungBetrag.Properties.EditFormat.FormatString = "n2";
            this.edtTaggeldversicherungBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtTaggeldversicherungBetrag.Properties.Mask.EditMask = "n2";
            this.edtTaggeldversicherungBetrag.Size = new System.Drawing.Size(55, 24);
            this.edtTaggeldversicherungBetrag.TabIndex = 12;
            // 
            // edtKVGPraemienVerbillBetrag
            // 
            this.edtKVGPraemienVerbillBetrag.DataMember = "KVGPraemienVerbillBetrag";
            this.edtKVGPraemienVerbillBetrag.DataSource = this.qryBaKrankenversicherung;
            this.edtKVGPraemienVerbillBetrag.EditMode = Kiss.Interfaces.UI.EditModeType.Optional;
            this.edtKVGPraemienVerbillBetrag.Location = new System.Drawing.Point(540, 262);
            this.edtKVGPraemienVerbillBetrag.Name = "edtKVGPraemienVerbillBetrag";
            this.edtKVGPraemienVerbillBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtKVGPraemienVerbillBetrag.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.edtKVGPraemienVerbillBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKVGPraemienVerbillBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKVGPraemienVerbillBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtKVGPraemienVerbillBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKVGPraemienVerbillBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtKVGPraemienVerbillBetrag.Properties.Appearance.Options.UseTextOptions = true;
            this.edtKVGPraemienVerbillBetrag.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.edtKVGPraemienVerbillBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKVGPraemienVerbillBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKVGPraemienVerbillBetrag.Properties.DisplayFormat.FormatString = "n2";
            this.edtKVGPraemienVerbillBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtKVGPraemienVerbillBetrag.Properties.EditFormat.FormatString = "N2";
            this.edtKVGPraemienVerbillBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtKVGPraemienVerbillBetrag.Properties.Mask.EditMask = "n2";
            this.edtKVGPraemienVerbillBetrag.Properties.Name = "edtKVGPraemienVerbillBetrag.Properties";
            this.edtKVGPraemienVerbillBetrag.Size = new System.Drawing.Size(80, 24);
            this.edtKVGPraemienVerbillBetrag.TabIndex = 14;
            // 
            // memBemerkung
            // 
            this.memBemerkung.DataMember = "Bemerkung";
            this.memBemerkung.DataSource = this.qryBaKrankenversicherung;
            this.memBemerkung.Location = new System.Drawing.Point(107, 318);
            this.memBemerkung.Name = "memBemerkung";
            this.memBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.memBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.memBemerkung.Properties.Appearance.Options.UseFont = true;
            this.memBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memBemerkung.Properties.MaxLength = 300;
            this.memBemerkung.Properties.Name = "kissMemoEdit4.Properties";
            this.memBemerkung.Size = new System.Drawing.Size(309, 45);
            this.memBemerkung.TabIndex = 16;
            // 
            // btnCopy
            // 
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.Location = new System.Drawing.Point(540, 339);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(125, 24);
            this.btnCopy.TabIndex = 17;
            this.btnCopy.Text = "Datensatz kopieren";
            this.btnCopy.UseCompatibleTextRendering = true;
            this.btnCopy.UseVisualStyleBackColor = false;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // lblInstitutionName
            // 
            this.lblInstitutionName.Location = new System.Drawing.Point(5, 192);
            this.lblInstitutionName.Name = "lblInstitutionName";
            this.lblInstitutionName.Size = new System.Drawing.Size(96, 24);
            this.lblInstitutionName.TabIndex = 93;
            this.lblInstitutionName.Text = "Krankenkasse";
            this.lblInstitutionName.UseCompatibleTextRendering = true;
            // 
            // lblMitgliedNr
            // 
            this.lblMitgliedNr.Location = new System.Drawing.Point(5, 222);
            this.lblMitgliedNr.Name = "lblMitgliedNr";
            this.lblMitgliedNr.Size = new System.Drawing.Size(96, 24);
            this.lblMitgliedNr.TabIndex = 100;
            this.lblMitgliedNr.Text = "Mitglied-Nr";
            this.lblMitgliedNr.UseCompatibleTextRendering = true;
            // 
            // lblPraemie
            // 
            this.lblPraemie.Location = new System.Drawing.Point(5, 252);
            this.lblPraemie.Name = "lblPraemie";
            this.lblPraemie.Size = new System.Drawing.Size(96, 24);
            this.lblPraemie.TabIndex = 107;
            this.lblPraemie.Text = "Prämie";
            this.lblPraemie.UseCompatibleTextRendering = true;
            // 
            // kissLabel23a
            // 
            this.kissLabel23a.Location = new System.Drawing.Point(203, 252);
            this.kissLabel23a.Name = "kissLabel23a";
            this.kissLabel23a.Size = new System.Drawing.Size(30, 24);
            this.kissLabel23a.TabIndex = 108;
            this.kissLabel23a.Text = "CHF";
            this.kissLabel23a.UseCompatibleTextRendering = true;
            // 
            // lblFranchise
            // 
            this.lblFranchise.Location = new System.Drawing.Point(269, 252);
            this.lblFranchise.Name = "lblFranchise";
            this.lblFranchise.Size = new System.Drawing.Size(56, 24);
            this.lblFranchise.TabIndex = 109;
            this.lblFranchise.Text = "Franchise";
            this.lblFranchise.UseCompatibleTextRendering = true;
            // 
            // kissLabel24a
            // 
            this.kissLabel24a.Location = new System.Drawing.Point(417, 252);
            this.kissLabel24a.Name = "kissLabel24a";
            this.kissLabel24a.Size = new System.Drawing.Size(34, 24);
            this.kissLabel24a.TabIndex = 110;
            this.kissLabel24a.Text = "CHF";
            this.kissLabel24a.UseCompatibleTextRendering = true;
            // 
            // kissLabel15a
            // 
            this.kissLabel15a.Location = new System.Drawing.Point(457, 262);
            this.kissLabel15a.Name = "kissLabel15a";
            this.kissLabel15a.Size = new System.Drawing.Size(77, 24);
            this.kissLabel15a.TabIndex = 111;
            this.kissLabel15a.Text = "Betrag";
            this.kissLabel15a.UseCompatibleTextRendering = true;
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.Location = new System.Drawing.Point(6, 318);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(96, 24);
            this.lblBemerkung.TabIndex = 112;
            this.lblBemerkung.Text = "Bemerkung";
            this.lblBemerkung.UseCompatibleTextRendering = true;
            // 
            // lblDatumVon
            // 
            this.lblDatumVon.Location = new System.Drawing.Point(5, 162);
            this.lblDatumVon.Name = "lblDatumVon";
            this.lblDatumVon.Size = new System.Drawing.Size(96, 24);
            this.lblDatumVon.TabIndex = 114;
            this.lblDatumVon.Text = "Datum von";
            this.lblDatumVon.UseCompatibleTextRendering = true;
            // 
            // kissLabel85
            // 
            this.kissLabel85.Location = new System.Drawing.Point(630, 262);
            this.kissLabel85.Name = "kissLabel85";
            this.kissLabel85.Size = new System.Drawing.Size(35, 24);
            this.kissLabel85.TabIndex = 115;
            this.kissLabel85.Text = "CHF";
            this.kissLabel85.UseCompatibleTextRendering = true;
            // 
            // kissLabel100
            // 
            this.kissLabel100.Location = new System.Drawing.Point(213, 162);
            this.kissLabel100.Name = "kissLabel100";
            this.kissLabel100.Size = new System.Drawing.Size(20, 24);
            this.kissLabel100.TabIndex = 116;
            this.kissLabel100.Text = "bis";
            this.kissLabel100.UseCompatibleTextRendering = true;
            // 
            // lblBezahltDurchCode
            // 
            this.lblBezahltDurchCode.Location = new System.Drawing.Point(5, 282);
            this.lblBezahltDurchCode.Name = "lblBezahltDurchCode";
            this.lblBezahltDurchCode.Size = new System.Drawing.Size(96, 24);
            this.lblBezahltDurchCode.TabIndex = 117;
            this.lblBezahltDurchCode.Text = "bezahlt von";
            this.lblBezahltDurchCode.UseCompatibleTextRendering = true;
            // 
            // kissLabel6
            // 
            this.kissLabel6.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel6.Location = new System.Drawing.Point(457, 241);
            this.kissLabel6.Name = "kissLabel6";
            this.kissLabel6.Size = new System.Drawing.Size(142, 16);
            this.kissLabel6.TabIndex = 125;
            this.kissLabel6.Text = "Prämienverbilligung";
            this.kissLabel6.UseCompatibleTextRendering = true;
            // 
            // kissLabel49
            // 
            this.kissLabel49.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel49.Location = new System.Drawing.Point(457, 132);
            this.kissLabel49.Name = "kissLabel49";
            this.kissLabel49.Size = new System.Drawing.Size(181, 17);
            this.kissLabel49.TabIndex = 126;
            this.kissLabel49.Text = "zusätzliche Deckung";
            this.kissLabel49.UseCompatibleTextRendering = true;
            // 
            // kissLabel52
            // 
            this.kissLabel52.Location = new System.Drawing.Point(646, 191);
            this.kissLabel52.Name = "kissLabel52";
            this.kissLabel52.Size = new System.Drawing.Size(51, 24);
            this.kissLabel52.TabIndex = 127;
            this.kissLabel52.Text = "CHF/Tag";
            this.kissLabel52.UseCompatibleTextRendering = true;
            // 
            // kissLabel3
            // 
            this.kissLabel3.Location = new System.Drawing.Point(5, 132);
            this.kissLabel3.Name = "kissLabel3";
            this.kissLabel3.Size = new System.Drawing.Size(96, 24);
            this.kissLabel3.TabIndex = 132;
            this.kissLabel3.Text = "Gesetz";
            this.kissLabel3.UseCompatibleTextRendering = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.kissLabel11);
            this.panel1.Controls.Add(this.grdPraemienuebernahme);
            this.panel1.Controls.Add(this.kissLabel4);
            this.panel1.Controls.Add(this.grdPraemienverbilligung);
            this.panel1.Location = new System.Drawing.Point(6, 370);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(687, 236);
            this.panel1.TabIndex = 147;
            // 
            // kissLabel11
            // 
            this.kissLabel11.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel11.Location = new System.Drawing.Point(4, 115);
            this.kissLabel11.Name = "kissLabel11";
            this.kissLabel11.Size = new System.Drawing.Size(363, 20);
            this.kissLabel11.TabIndex = 149;
            this.kissLabel11.Text = "Verlustscheine / Prämienübernahme SGD (aus Omega)";
            this.kissLabel11.UseCompatibleTextRendering = true;
            // 
            // grdPraemienuebernahme
            // 
            this.grdPraemienuebernahme.DataSource = this.qryBaPraemienuebernahme;
            // 
            // 
            // 
            this.grdPraemienuebernahme.EmbeddedNavigator.Name = "";
            this.grdPraemienuebernahme.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdPraemienuebernahme.Location = new System.Drawing.Point(4, 136);
            this.grdPraemienuebernahme.MainView = this.grvBaPraemienuebernahme;
            this.grdPraemienuebernahme.Name = "grdPraemienuebernahme";
            this.grdPraemienuebernahme.Size = new System.Drawing.Size(678, 89);
            this.grdPraemienuebernahme.TabIndex = 148;
            this.grdPraemienuebernahme.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBaPraemienuebernahme});
            // 
            // qryBaPraemienuebernahme
            // 
            this.qryBaPraemienuebernahme.HostControl = this;
            this.qryBaPraemienuebernahme.SelectStatement = "SELECT *\r\nFROM BaPraemienuebernahme\r\nWHERE BaPersonID = {0} \r\nORDER BY DatumVon";
            this.qryBaPraemienuebernahme.TableName = "BaPraemienuebernahme";
            // 
            // grvBaPraemienuebernahme
            // 
            this.grvBaPraemienuebernahme.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBaPraemienuebernahme.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaPraemienuebernahme.Appearance.Empty.Options.UseBackColor = true;
            this.grvBaPraemienuebernahme.Appearance.Empty.Options.UseFont = true;
            this.grvBaPraemienuebernahme.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaPraemienuebernahme.Appearance.EvenRow.Options.UseFont = true;
            this.grvBaPraemienuebernahme.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBaPraemienuebernahme.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaPraemienuebernahme.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBaPraemienuebernahme.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBaPraemienuebernahme.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBaPraemienuebernahme.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBaPraemienuebernahme.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBaPraemienuebernahme.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaPraemienuebernahme.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBaPraemienuebernahme.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBaPraemienuebernahme.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBaPraemienuebernahme.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBaPraemienuebernahme.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaPraemienuebernahme.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBaPraemienuebernahme.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaPraemienuebernahme.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBaPraemienuebernahme.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBaPraemienuebernahme.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBaPraemienuebernahme.Appearance.GroupRow.Options.UseFont = true;
            this.grvBaPraemienuebernahme.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBaPraemienuebernahme.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBaPraemienuebernahme.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBaPraemienuebernahme.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBaPraemienuebernahme.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBaPraemienuebernahme.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBaPraemienuebernahme.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBaPraemienuebernahme.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBaPraemienuebernahme.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaPraemienuebernahme.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBaPraemienuebernahme.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBaPraemienuebernahme.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBaPraemienuebernahme.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBaPraemienuebernahme.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBaPraemienuebernahme.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBaPraemienuebernahme.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaPraemienuebernahme.Appearance.OddRow.Options.UseFont = true;
            this.grvBaPraemienuebernahme.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBaPraemienuebernahme.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaPraemienuebernahme.Appearance.Row.Options.UseBackColor = true;
            this.grvBaPraemienuebernahme.Appearance.Row.Options.UseFont = true;
            this.grvBaPraemienuebernahme.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaPraemienuebernahme.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBaPraemienuebernahme.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBaPraemienuebernahme.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBaPraemienuebernahme.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBaPraemienuebernahme.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn2,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
            this.grvBaPraemienuebernahme.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBaPraemienuebernahme.GridControl = this.grdPraemienuebernahme;
            this.grvBaPraemienuebernahme.Name = "grvBaPraemienuebernahme";
            this.grvBaPraemienuebernahme.OptionsBehavior.Editable = false;
            this.grvBaPraemienuebernahme.OptionsCustomization.AllowFilter = false;
            this.grvBaPraemienuebernahme.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBaPraemienuebernahme.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBaPraemienuebernahme.OptionsNavigation.UseTabKey = false;
            this.grvBaPraemienuebernahme.OptionsView.ColumnAutoWidth = false;
            this.grvBaPraemienuebernahme.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBaPraemienuebernahme.OptionsView.ShowGroupPanel = false;
            this.grvBaPraemienuebernahme.OptionsView.ShowIndicator = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "PU von";
            this.gridColumn3.FieldName = "DatumVon";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 80;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "PU bis";
            this.gridColumn4.FieldName = "DatumBis";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 80;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Krankenkasse";
            this.gridColumn2.FieldName = "Krankenkasse";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 164;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "betr. Pers.";
            this.gridColumn5.FieldName = "BetroffenePersonen";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 93;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Betrag l.PU";
            this.gridColumn6.DisplayFormat.FormatString = "n2";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn6.FieldName = "BetragLetztePU";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.ToolTip = "Betrag letzte Prämienübernahme";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 92;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "überpr. pfl.";
            this.gridColumn7.FieldName = "Ueberpruefungspflichtig";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.ToolTip = "Ueberpruefungspflichtig";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            this.gridColumn7.Width = 72;
            // 
            // kissLabel4
            // 
            this.kissLabel4.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel4.Location = new System.Drawing.Point(4, 3);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(262, 20);
            this.kissLabel4.TabIndex = 134;
            this.kissLabel4.Text = "Prämienverbilligung (aus Omega)";
            this.kissLabel4.UseCompatibleTextRendering = true;
            // 
            // grdPraemienverbilligung
            // 
            this.grdPraemienverbilligung.DataSource = this.qryBaPraemienverbilligung;
            // 
            // 
            // 
            this.grdPraemienverbilligung.EmbeddedNavigator.Name = "";
            this.grdPraemienverbilligung.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdPraemienverbilligung.Location = new System.Drawing.Point(4, 23);
            this.grdPraemienverbilligung.MainView = this.grvPraemienuebernahme;
            this.grdPraemienverbilligung.Name = "grdPraemienverbilligung";
            this.grdPraemienverbilligung.Size = new System.Drawing.Size(678, 89);
            this.grdPraemienverbilligung.TabIndex = 133;
            this.grdPraemienverbilligung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPraemienuebernahme});
            // 
            // qryBaPraemienverbilligung
            // 
            this.qryBaPraemienverbilligung.HostControl = this;
            this.qryBaPraemienverbilligung.SelectStatement = resources.GetString("qryBaPraemienverbilligung.SelectStatement");
            this.qryBaPraemienverbilligung.TableName = "BaPraemienverbilligung";
            // 
            // grvPraemienuebernahme
            // 
            this.grvPraemienuebernahme.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvPraemienuebernahme.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPraemienuebernahme.Appearance.Empty.Options.UseBackColor = true;
            this.grvPraemienuebernahme.Appearance.Empty.Options.UseFont = true;
            this.grvPraemienuebernahme.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPraemienuebernahme.Appearance.EvenRow.Options.UseFont = true;
            this.grvPraemienuebernahme.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvPraemienuebernahme.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPraemienuebernahme.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvPraemienuebernahme.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvPraemienuebernahme.Appearance.FocusedCell.Options.UseFont = true;
            this.grvPraemienuebernahme.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvPraemienuebernahme.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvPraemienuebernahme.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPraemienuebernahme.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvPraemienuebernahme.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvPraemienuebernahme.Appearance.FocusedRow.Options.UseFont = true;
            this.grvPraemienuebernahme.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvPraemienuebernahme.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvPraemienuebernahme.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvPraemienuebernahme.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvPraemienuebernahme.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvPraemienuebernahme.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvPraemienuebernahme.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvPraemienuebernahme.Appearance.GroupRow.Options.UseFont = true;
            this.grvPraemienuebernahme.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvPraemienuebernahme.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvPraemienuebernahme.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvPraemienuebernahme.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvPraemienuebernahme.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvPraemienuebernahme.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvPraemienuebernahme.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvPraemienuebernahme.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvPraemienuebernahme.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPraemienuebernahme.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvPraemienuebernahme.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvPraemienuebernahme.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvPraemienuebernahme.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvPraemienuebernahme.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvPraemienuebernahme.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvPraemienuebernahme.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPraemienuebernahme.Appearance.OddRow.Options.UseFont = true;
            this.grvPraemienuebernahme.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvPraemienuebernahme.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPraemienuebernahme.Appearance.Row.Options.UseBackColor = true;
            this.grvPraemienuebernahme.Appearance.Row.Options.UseFont = true;
            this.grvPraemienuebernahme.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPraemienuebernahme.Appearance.SelectedRow.Options.UseFont = true;
            this.grvPraemienuebernahme.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvPraemienuebernahme.Appearance.VertLine.Options.UseBackColor = true;
            this.grvPraemienuebernahme.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvPraemienuebernahme.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIPVJahr,
            this.colAnspruch,
            this.colAuszahlung,
            this.colZahlungAn,
            this.colLetzeMutation,
            this.colGrund});
            this.grvPraemienuebernahme.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvPraemienuebernahme.GridControl = this.grdPraemienverbilligung;
            this.grvPraemienuebernahme.Name = "grvPraemienuebernahme";
            this.grvPraemienuebernahme.OptionsBehavior.Editable = false;
            this.grvPraemienuebernahme.OptionsCustomization.AllowFilter = false;
            this.grvPraemienuebernahme.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvPraemienuebernahme.OptionsNavigation.AutoFocusNewRow = true;
            this.grvPraemienuebernahme.OptionsNavigation.UseTabKey = false;
            this.grvPraemienuebernahme.OptionsView.ColumnAutoWidth = false;
            this.grvPraemienuebernahme.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvPraemienuebernahme.OptionsView.ShowGroupPanel = false;
            this.grvPraemienuebernahme.OptionsView.ShowIndicator = false;
            // 
            // colIPVJahr
            // 
            this.colIPVJahr.Caption = "IPV-Jahr";
            this.colIPVJahr.FieldName = "Jahr";
            this.colIPVJahr.Name = "colIPVJahr";
            this.colIPVJahr.Visible = true;
            this.colIPVJahr.VisibleIndex = 0;
            // 
            // colAnspruch
            // 
            this.colAnspruch.Caption = "Anspruch CHF";
            this.colAnspruch.DisplayFormat.FormatString = "n2";
            this.colAnspruch.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAnspruch.FieldName = "BetragAnspruch";
            this.colAnspruch.Name = "colAnspruch";
            this.colAnspruch.Visible = true;
            this.colAnspruch.VisibleIndex = 1;
            this.colAnspruch.Width = 100;
            // 
            // colAuszahlung
            // 
            this.colAuszahlung.Caption = "Auszahlung CHF";
            this.colAuszahlung.DisplayFormat.FormatString = "n2";
            this.colAuszahlung.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAuszahlung.FieldName = "BetragAuszahlung";
            this.colAuszahlung.Name = "colAuszahlung";
            this.colAuszahlung.Visible = true;
            this.colAuszahlung.VisibleIndex = 2;
            this.colAuszahlung.Width = 109;
            // 
            // colZahlungAn
            // 
            this.colZahlungAn.Caption = "Zahlung an";
            this.colZahlungAn.FieldName = "ZahlungAn";
            this.colZahlungAn.Name = "colZahlungAn";
            this.colZahlungAn.Visible = true;
            this.colZahlungAn.VisibleIndex = 3;
            this.colZahlungAn.Width = 151;
            // 
            // colLetzeMutation
            // 
            this.colLetzeMutation.Caption = "letzte Mutation";
            this.colLetzeMutation.FieldName = "LetzteMutation";
            this.colLetzeMutation.Name = "colLetzeMutation";
            this.colLetzeMutation.Visible = true;
            this.colLetzeMutation.VisibleIndex = 4;
            this.colLetzeMutation.Width = 99;
            // 
            // colGrund
            // 
            this.colGrund.Caption = "Grund";
            this.colGrund.FieldName = "Grund";
            this.colGrund.Name = "colGrund";
            this.colGrund.Visible = true;
            this.colGrund.VisibleIndex = 5;
            this.colGrund.Width = 122;
            // 
            // edtGanzeSchweiz
            // 
            this.edtGanzeSchweiz.DataMember = "GanzeSchweiz";
            this.edtGanzeSchweiz.DataSource = this.qryBaKrankenversicherung;
            this.edtGanzeSchweiz.Location = new System.Drawing.Point(457, 214);
            this.edtGanzeSchweiz.Name = "edtGanzeSchweiz";
            this.edtGanzeSchweiz.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGanzeSchweiz.Properties.Appearance.Options.UseBackColor = true;
            this.edtGanzeSchweiz.Properties.Caption = "ganze Schweiz";
            this.edtGanzeSchweiz.Size = new System.Drawing.Size(123, 19);
            this.edtGanzeSchweiz.TabIndex = 148;
            // 
            // CtlBaPersonKrankenkasse
            // 
            this.ActiveSQLQuery = this.qryBaKrankenversicherung;
            this.Controls.Add(this.edtGanzeSchweiz);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kissLabel3);
            this.Controls.Add(this.kissLabel52);
            this.Controls.Add(this.kissLabel49);
            this.Controls.Add(this.kissLabel6);
            this.Controls.Add(this.lblBezahltDurchCode);
            this.Controls.Add(this.kissLabel100);
            this.Controls.Add(this.kissLabel85);
            this.Controls.Add(this.lblDatumVon);
            this.Controls.Add(this.lblBemerkung);
            this.Controls.Add(this.kissLabel15a);
            this.Controls.Add(this.kissLabel24a);
            this.Controls.Add(this.lblFranchise);
            this.Controls.Add(this.kissLabel23a);
            this.Controls.Add(this.lblPraemie);
            this.Controls.Add(this.lblMitgliedNr);
            this.Controls.Add(this.lblInstitutionName);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.memBemerkung);
            this.Controls.Add(this.edtKVGPraemienVerbillBetrag);
            this.Controls.Add(this.edtTaggeldversicherungBetrag);
            this.Controls.Add(this.chkTaggeldversicherung);
            this.Controls.Add(this.chkZahnversicherung);
            this.Controls.Add(this.chkUnfallEinschluss);
            this.Controls.Add(this.ddlBezahltDurchSD);
            this.Controls.Add(this.edtFranchise);
            this.Controls.Add(this.edtPraemie);
            this.Controls.Add(this.edtMitgliedNr);
            this.Controls.Add(this.dlgInstitution);
            this.Controls.Add(this.edtDatumBis);
            this.Controls.Add(this.edtDatumVon);
            this.Controls.Add(this.rgrGesetz);
            this.Controls.Add(this.grdBaKrankenversicherung);
            this.Name = "CtlBaPersonKrankenkasse";
            this.Size = new System.Drawing.Size(699, 609);
            this.Load += new System.EventHandler(this.CtlBaPersonKrankenkasse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdBaKrankenversicherung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaKrankenversicherung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaKrankenversicherung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgrGesetz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgrGesetz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dlgInstitution.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitgliedNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPraemie.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFranchise.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlBezahltDurchSD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlBezahltDurchSD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUnfallEinschluss.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkZahnversicherung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTaggeldversicherung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTaggeldversicherungBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGPraemienVerbillBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInstitutionName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMitgliedNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPraemie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel23a)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFranchise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel24a)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel15a)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel85)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel100)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBezahltDurchCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel49)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPraemienuebernahme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPraemienuebernahme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaPraemienuebernahme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPraemienverbilligung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPraemienverbilligung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPraemienuebernahme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGanzeSchweiz.Properties)).EndInit();
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