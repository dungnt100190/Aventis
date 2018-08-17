namespace KiSS4.Basis
{
    partial class CtlBaPersonAdresse
    {
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBaPersonAdresse));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdBaWohnsitzAdresse = new KiSS4.Gui.KissGrid();
            this.qryBaWohnsitzAdresse = new KiSS4.DB.SqlQuery(this.components);
            this.grvBaWohnsitzAdresse = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colWohnsitzDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWohnsitzDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWohnsitzStrasse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWohnsitzHausNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtWohnsitzVon = new KiSS4.Gui.KissDateEdit();
            this.edtWohnsitzBis = new KiSS4.Gui.KissDateEdit();
            this.edtName = new KiSS4.Gui.KissTextEdit();
            this.qryBaPerson = new KiSS4.DB.SqlQuery(this.components);
            this.edtVorname = new KiSS4.Gui.KissTextEdit();
            this.edtWohnsitzZusatz = new KiSS4.Gui.KissTextEdit();
            this.edtWohnsitzStrasse = new KiSS4.Gui.KissTextEdit();
            this.edtNummerWohnsitz = new KiSS4.Gui.KissTextEdit();
            this.edtWohnsitzPostfach = new KiSS4.Gui.KissTextEdit();
            this.edtPLZWohnsitz = new KiSS4.Common.KissPLZOrt();
            this.grdBaAufenthaltAdresse = new KiSS4.Gui.KissGrid();
            this.qryBaWeitereAdressen = new KiSS4.DB.SqlQuery(this.components);
            this.grvBaAufenthaltAdresse = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAufenthaltDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAufenthaltAdresstyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAufenthaltInstitution = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAufenthaltDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboAdresstyp = new KiSS4.Gui.KissLookUpEdit();
            this.edtAufenthaltVon = new KiSS4.Gui.KissDateEdit();
            this.edtAufenthaltBis = new KiSS4.Gui.KissDateEdit();
            this.edtAufenthaltInstitutionName = new KiSS4.Gui.KissTextEdit();
            this.edtInstitutionLookup = new KiSS4.Gui.KissButtonEdit();
            this.edtAufenthaltZusatz = new KiSS4.Gui.KissTextEdit();
            this.edtAufenthaltStrasse = new KiSS4.Gui.KissTextEdit();
            this.edtAufenthaltHausNr = new KiSS4.Gui.KissTextEdit();
            this.edtAufenthaltPostfach = new KiSS4.Gui.KissTextEdit();
            this.edtPLZAufenthalt = new KiSS4.Common.KissPLZOrt();
            this.lblTitelWohnsitz = new KiSS4.Gui.KissLabel();
            this.lblWohnsitzNameVorname = new KiSS4.Gui.KissLabel();
            this.lblWohnsitzZusatz = new KiSS4.Gui.KissLabel();
            this.lblWohnsitzStrasseNr = new KiSS4.Gui.KissLabel();
            this.lblWohnsitzPostfach = new KiSS4.Gui.KissLabel();
            this.lblWohnsitzPLZOrtKt = new KiSS4.Gui.KissLabel();
            this.lblWohnsitzLand = new KiSS4.Gui.KissLabel();
            this.lblTitelOtherAddress = new KiSS4.Gui.KissLabel();
            this.lblAufenthaltDatumVon = new KiSS4.Gui.KissLabel();
            this.lblAufenthaltDatumBis = new KiSS4.Gui.KissLabel();
            this.lblAufenthaltInstitution = new KiSS4.Gui.KissLabel();
            this.lblAufenthaltZusatz = new KiSS4.Gui.KissLabel();
            this.lblAufenthaltStrasseHausNr = new KiSS4.Gui.KissLabel();
            this.lblAufenthaltPostfach = new KiSS4.Gui.KissLabel();
            this.lblAufenthaltPLZOrtKt = new KiSS4.Gui.KissLabel();
            this.lblAufenthaltLand = new KiSS4.Gui.KissLabel();
            this.lblWohnsitzDatumVon = new KiSS4.Gui.KissLabel();
            this.lblWohnsitzDatumBis = new KiSS4.Gui.KissLabel();
            this.lblAufenthaltAdresstyp = new KiSS4.Gui.KissLabel();
            this.cboAdresstypWohnsitz = new KiSS4.Gui.KissLookUpEdit();
            this.lblWohnsitzAdressTyp = new KiSS4.Gui.KissLabel();
            this.edtWohnsituationsCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtWohnungsgroesseCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblWohnsitzWohnungsgroesse = new KiSS4.Gui.KissLabel();
            this.lblWohnsitzWohnstatus = new KiSS4.Gui.KissLabel();
            this.chkWohnsitzPostfachOhneNr = new KiSS4.Gui.KissCheckEdit();
            this.chkAufenthaltPostfachOhneNr = new KiSS4.Gui.KissCheckEdit();
            this.pnlTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.panDetailsWohnsitz = new System.Windows.Forms.Panel();
            this.panTblWohnsitzNameVorname = new System.Windows.Forms.TableLayoutPanel();
            this.lblWohnsitzBezirk = new KiSS4.Gui.KissLabel();
            this.panDetailsOtherAddress = new System.Windows.Forms.Panel();
            this.edtAufenthaltZuhandenVon = new KiSS4.Gui.KissTextEdit();
            this.lblAufenthaltZuhandenVon = new KiSS4.Gui.KissLabel();
            this.lblAufenthaltBezirk = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaWohnsitzAdresse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaWohnsitzAdresse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaWohnsitzAdresse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitzVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitzBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitzZusatz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitzStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNummerWohnsitz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitzPostfach.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaAufenthaltAdresse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaWeitereAdressen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaAufenthaltAdresse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAdresstyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAdresstyp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAufenthaltVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAufenthaltBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAufenthaltInstitutionName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInstitutionLookup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAufenthaltZusatz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAufenthaltStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAufenthaltHausNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAufenthaltPostfach.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitelWohnsitz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWohnsitzNameVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWohnsitzZusatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWohnsitzStrasseNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWohnsitzPostfach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWohnsitzPLZOrtKt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWohnsitzLand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitelOtherAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAufenthaltDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAufenthaltDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAufenthaltInstitution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAufenthaltZusatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAufenthaltStrasseHausNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAufenthaltPostfach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAufenthaltPLZOrtKt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAufenthaltLand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWohnsitzDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWohnsitzDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAufenthaltAdresstyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAdresstypWohnsitz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAdresstypWohnsitz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWohnsitzAdressTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsituationsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsituationsCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnungsgroesseCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnungsgroesseCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWohnsitzWohnungsgroesse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWohnsitzWohnstatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkWohnsitzPostfachOhneNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAufenthaltPostfachOhneNr.Properties)).BeginInit();
            this.pnlTableLayout.SuspendLayout();
            this.panDetailsWohnsitz.SuspendLayout();
            this.panTblWohnsitzNameVorname.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblWohnsitzBezirk)).BeginInit();
            this.panDetailsOtherAddress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtAufenthaltZuhandenVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAufenthaltZuhandenVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAufenthaltBezirk)).BeginInit();
            this.SuspendLayout();
            // 
            // grdBaWohnsitzAdresse
            // 
            this.grdBaWohnsitzAdresse.DataSource = this.qryBaWohnsitzAdresse;
            this.grdBaWohnsitzAdresse.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdBaWohnsitzAdresse.EmbeddedNavigator.Name = "";
            this.grdBaWohnsitzAdresse.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBaWohnsitzAdresse.Location = new System.Drawing.Point(3, 27);
            this.grdBaWohnsitzAdresse.MainView = this.grvBaWohnsitzAdresse;
            this.grdBaWohnsitzAdresse.Name = "grdBaWohnsitzAdresse";
            this.grdBaWohnsitzAdresse.Size = new System.Drawing.Size(343, 209);
            this.grdBaWohnsitzAdresse.TabIndex = 1;
            this.grdBaWohnsitzAdresse.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBaWohnsitzAdresse});
            // 
            // qryBaWohnsitzAdresse
            // 
            this.qryBaWohnsitzAdresse.CanDelete = true;
            this.qryBaWohnsitzAdresse.CanInsert = true;
            this.qryBaWohnsitzAdresse.CanUpdate = true;
            this.qryBaWohnsitzAdresse.HostControl = this;
            this.qryBaWohnsitzAdresse.SelectStatement = resources.GetString("qryBaWohnsitzAdresse.SelectStatement");
            this.qryBaWohnsitzAdresse.TableName = "BaAdresse";
            this.qryBaWohnsitzAdresse.AfterDelete += new System.EventHandler(this.qryBaWohnsitzAdresse_AfterDelete);
            this.qryBaWohnsitzAdresse.AfterFill += new System.EventHandler(this.qryBaWohnsitzAdresse_AfterFill);
            this.qryBaWohnsitzAdresse.AfterInsert += new System.EventHandler(this.qryBaWohnsitzAdresse_AfterInsert);
            this.qryBaWohnsitzAdresse.BeforeDelete += new System.EventHandler(this.qryBaWohnsitzAdresse_BeforeDelete);
            this.qryBaWohnsitzAdresse.BeforeDeleteQuestion += new System.EventHandler(this.qryBaWohnsitzAdresse_BeforeDeleteQuestion);
            this.qryBaWohnsitzAdresse.BeforePost += new System.EventHandler(this.qryBaWohnsitzAdresse_BeforePost);
            this.qryBaWohnsitzAdresse.PositionChanged += new System.EventHandler(this.qryBaWohnsitzAdresse_PositionChanged);
            // 
            // grvBaWohnsitzAdresse
            // 
            this.grvBaWohnsitzAdresse.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBaWohnsitzAdresse.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWohnsitzAdresse.Appearance.Empty.Options.UseBackColor = true;
            this.grvBaWohnsitzAdresse.Appearance.Empty.Options.UseFont = true;
            this.grvBaWohnsitzAdresse.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWohnsitzAdresse.Appearance.EvenRow.Options.UseFont = true;
            this.grvBaWohnsitzAdresse.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBaWohnsitzAdresse.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWohnsitzAdresse.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBaWohnsitzAdresse.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBaWohnsitzAdresse.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBaWohnsitzAdresse.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBaWohnsitzAdresse.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBaWohnsitzAdresse.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWohnsitzAdresse.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBaWohnsitzAdresse.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBaWohnsitzAdresse.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBaWohnsitzAdresse.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBaWohnsitzAdresse.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaWohnsitzAdresse.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBaWohnsitzAdresse.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaWohnsitzAdresse.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBaWohnsitzAdresse.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBaWohnsitzAdresse.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBaWohnsitzAdresse.Appearance.GroupRow.Options.UseFont = true;
            this.grvBaWohnsitzAdresse.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBaWohnsitzAdresse.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBaWohnsitzAdresse.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBaWohnsitzAdresse.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBaWohnsitzAdresse.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBaWohnsitzAdresse.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBaWohnsitzAdresse.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBaWohnsitzAdresse.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBaWohnsitzAdresse.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWohnsitzAdresse.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBaWohnsitzAdresse.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBaWohnsitzAdresse.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBaWohnsitzAdresse.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBaWohnsitzAdresse.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBaWohnsitzAdresse.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBaWohnsitzAdresse.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWohnsitzAdresse.Appearance.OddRow.Options.UseFont = true;
            this.grvBaWohnsitzAdresse.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBaWohnsitzAdresse.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWohnsitzAdresse.Appearance.Row.Options.UseBackColor = true;
            this.grvBaWohnsitzAdresse.Appearance.Row.Options.UseFont = true;
            this.grvBaWohnsitzAdresse.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWohnsitzAdresse.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBaWohnsitzAdresse.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBaWohnsitzAdresse.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBaWohnsitzAdresse.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBaWohnsitzAdresse.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colWohnsitzDatumVon,
            this.colWohnsitzDatumBis,
            this.colWohnsitzStrasse,
            this.colWohnsitzHausNr});
            this.grvBaWohnsitzAdresse.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBaWohnsitzAdresse.GridControl = this.grdBaWohnsitzAdresse;
            this.grvBaWohnsitzAdresse.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvBaWohnsitzAdresse.Name = "grvBaWohnsitzAdresse";
            this.grvBaWohnsitzAdresse.OptionsBehavior.Editable = false;
            this.grvBaWohnsitzAdresse.OptionsCustomization.AllowFilter = false;
            this.grvBaWohnsitzAdresse.OptionsFilter.AllowFilterEditor = false;
            this.grvBaWohnsitzAdresse.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBaWohnsitzAdresse.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBaWohnsitzAdresse.OptionsNavigation.UseTabKey = false;
            this.grvBaWohnsitzAdresse.OptionsView.ColumnAutoWidth = false;
            this.grvBaWohnsitzAdresse.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBaWohnsitzAdresse.OptionsView.ShowGroupPanel = false;
            this.grvBaWohnsitzAdresse.OptionsView.ShowIndicator = false;
            // 
            // colWohnsitzDatumVon
            // 
            this.colWohnsitzDatumVon.Caption = "Von";
            this.colWohnsitzDatumVon.FieldName = "DatumVon";
            this.colWohnsitzDatumVon.Name = "colWohnsitzDatumVon";
            this.colWohnsitzDatumVon.Visible = true;
            this.colWohnsitzDatumVon.VisibleIndex = 0;
            // 
            // colWohnsitzDatumBis
            // 
            this.colWohnsitzDatumBis.Caption = "Bis";
            this.colWohnsitzDatumBis.FieldName = "DatumBis";
            this.colWohnsitzDatumBis.Name = "colWohnsitzDatumBis";
            this.colWohnsitzDatumBis.Visible = true;
            this.colWohnsitzDatumBis.VisibleIndex = 1;
            // 
            // colWohnsitzStrasse
            // 
            this.colWohnsitzStrasse.Caption = "Strasse";
            this.colWohnsitzStrasse.FieldName = "Strasse";
            this.colWohnsitzStrasse.Name = "colWohnsitzStrasse";
            this.colWohnsitzStrasse.Visible = true;
            this.colWohnsitzStrasse.VisibleIndex = 2;
            this.colWohnsitzStrasse.Width = 130;
            // 
            // colWohnsitzHausNr
            // 
            this.colWohnsitzHausNr.Caption = "HausNr";
            this.colWohnsitzHausNr.FieldName = "HausNr";
            this.colWohnsitzHausNr.Name = "colWohnsitzHausNr";
            this.colWohnsitzHausNr.Visible = true;
            this.colWohnsitzHausNr.VisibleIndex = 3;
            this.colWohnsitzHausNr.Width = 50;
            // 
            // edtWohnsitzVon
            // 
            this.edtWohnsitzVon.DataMember = "DatumVon";
            this.edtWohnsitzVon.DataSource = this.qryBaWohnsitzAdresse;
            this.edtWohnsitzVon.EditValue = null;
            this.edtWohnsitzVon.Location = new System.Drawing.Point(98, 9);
            this.edtWohnsitzVon.Name = "edtWohnsitzVon";
            this.edtWohnsitzVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtWohnsitzVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWohnsitzVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWohnsitzVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWohnsitzVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtWohnsitzVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWohnsitzVon.Properties.Appearance.Options.UseFont = true;
            this.edtWohnsitzVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtWohnsitzVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtWohnsitzVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtWohnsitzVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtWohnsitzVon.Properties.ShowToday = false;
            this.edtWohnsitzVon.Size = new System.Drawing.Size(90, 24);
            this.edtWohnsitzVon.TabIndex = 1;
            // 
            // edtWohnsitzBis
            // 
            this.edtWohnsitzBis.DataMember = "DatumBis";
            this.edtWohnsitzBis.DataSource = this.qryBaWohnsitzAdresse;
            this.edtWohnsitzBis.EditValue = null;
            this.edtWohnsitzBis.Location = new System.Drawing.Point(229, 9);
            this.edtWohnsitzBis.Name = "edtWohnsitzBis";
            this.edtWohnsitzBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtWohnsitzBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWohnsitzBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWohnsitzBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWohnsitzBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtWohnsitzBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWohnsitzBis.Properties.Appearance.Options.UseFont = true;
            this.edtWohnsitzBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtWohnsitzBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtWohnsitzBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtWohnsitzBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtWohnsitzBis.Properties.ShowToday = false;
            this.edtWohnsitzBis.Size = new System.Drawing.Size(90, 24);
            this.edtWohnsitzBis.TabIndex = 3;
            // 
            // edtName
            // 
            this.edtName.DataMember = "Name";
            this.edtName.DataSource = this.qryBaPerson;
            this.edtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtName.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtName.Location = new System.Drawing.Point(0, 0);
            this.edtName.Margin = new System.Windows.Forms.Padding(0);
            this.edtName.Name = "edtName";
            this.edtName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtName.Properties.Appearance.Options.UseBackColor = true;
            this.edtName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtName.Properties.Appearance.Options.UseFont = true;
            this.edtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtName.Properties.Name = "kissTextEdit11.Properties";
            this.edtName.Properties.ReadOnly = true;
            this.edtName.Size = new System.Drawing.Size(144, 24);
            this.edtName.TabIndex = 0;
            this.edtName.TabStop = false;
            // 
            // qryBaPerson
            // 
            this.qryBaPerson.HostControl = this;
            this.qryBaPerson.SelectStatement = "SELECT \r\n    Name,\r\n    Vorname\r\nFROM BaPerson PRS\r\nWHERE \r\n    BaPersonID = {0}";
            // 
            // edtVorname
            // 
            this.edtVorname.DataMember = "Vorname";
            this.edtVorname.DataSource = this.qryBaPerson;
            this.edtVorname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtVorname.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtVorname.Location = new System.Drawing.Point(144, 0);
            this.edtVorname.Margin = new System.Windows.Forms.Padding(0);
            this.edtVorname.Name = "edtVorname";
            this.edtVorname.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVorname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVorname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVorname.Properties.Appearance.Options.UseBackColor = true;
            this.edtVorname.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVorname.Properties.Appearance.Options.UseFont = true;
            this.edtVorname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVorname.Properties.Name = "kissTextEdit10.Properties";
            this.edtVorname.Properties.ReadOnly = true;
            this.edtVorname.Size = new System.Drawing.Size(97, 24);
            this.edtVorname.TabIndex = 1;
            this.edtVorname.TabStop = false;
            // 
            // edtWohnsitzZusatz
            // 
            this.edtWohnsitzZusatz.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtWohnsitzZusatz.DataMember = "Zusatz";
            this.edtWohnsitzZusatz.DataSource = this.qryBaWohnsitzAdresse;
            this.edtWohnsitzZusatz.Location = new System.Drawing.Point(98, 131);
            this.edtWohnsitzZusatz.Name = "edtWohnsitzZusatz";
            this.edtWohnsitzZusatz.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWohnsitzZusatz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWohnsitzZusatz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWohnsitzZusatz.Properties.Appearance.Options.UseBackColor = true;
            this.edtWohnsitzZusatz.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWohnsitzZusatz.Properties.Appearance.Options.UseFont = true;
            this.edtWohnsitzZusatz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtWohnsitzZusatz.Properties.MaxLength = 200;
            this.edtWohnsitzZusatz.Properties.Name = "editZusatzWohnsitz.Properties";
            this.edtWohnsitzZusatz.Size = new System.Drawing.Size(241, 24);
            this.edtWohnsitzZusatz.TabIndex = 13;
            // 
            // edtWohnsitzStrasse
            // 
            this.edtWohnsitzStrasse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtWohnsitzStrasse.DataMember = "Strasse";
            this.edtWohnsitzStrasse.DataSource = this.qryBaWohnsitzAdresse;
            this.edtWohnsitzStrasse.Location = new System.Drawing.Point(98, 154);
            this.edtWohnsitzStrasse.Name = "edtWohnsitzStrasse";
            this.edtWohnsitzStrasse.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWohnsitzStrasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWohnsitzStrasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWohnsitzStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.edtWohnsitzStrasse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWohnsitzStrasse.Properties.Appearance.Options.UseFont = true;
            this.edtWohnsitzStrasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtWohnsitzStrasse.Properties.MaxLength = 100;
            this.edtWohnsitzStrasse.Properties.Name = "editStrasseWohnsitz.Properties";
            this.edtWohnsitzStrasse.Size = new System.Drawing.Size(193, 24);
            this.edtWohnsitzStrasse.TabIndex = 15;
            // 
            // edtNummerWohnsitz
            // 
            this.edtNummerWohnsitz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtNummerWohnsitz.DataMember = "HausNr";
            this.edtNummerWohnsitz.DataSource = this.qryBaWohnsitzAdresse;
            this.edtNummerWohnsitz.Location = new System.Drawing.Point(290, 154);
            this.edtNummerWohnsitz.Name = "edtNummerWohnsitz";
            this.edtNummerWohnsitz.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNummerWohnsitz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNummerWohnsitz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNummerWohnsitz.Properties.Appearance.Options.UseBackColor = true;
            this.edtNummerWohnsitz.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNummerWohnsitz.Properties.Appearance.Options.UseFont = true;
            this.edtNummerWohnsitz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNummerWohnsitz.Properties.MaxLength = 10;
            this.edtNummerWohnsitz.Properties.Name = "editNummerWohnsitz.Properties";
            this.edtNummerWohnsitz.Size = new System.Drawing.Size(49, 24);
            this.edtNummerWohnsitz.TabIndex = 16;
            // 
            // edtWohnsitzPostfach
            // 
            this.edtWohnsitzPostfach.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtWohnsitzPostfach.DataMember = "Postfach";
            this.edtWohnsitzPostfach.DataSource = this.qryBaWohnsitzAdresse;
            this.edtWohnsitzPostfach.Location = new System.Drawing.Point(98, 177);
            this.edtWohnsitzPostfach.Name = "edtWohnsitzPostfach";
            this.edtWohnsitzPostfach.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWohnsitzPostfach.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWohnsitzPostfach.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWohnsitzPostfach.Properties.Appearance.Options.UseBackColor = true;
            this.edtWohnsitzPostfach.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWohnsitzPostfach.Properties.Appearance.Options.UseFont = true;
            this.edtWohnsitzPostfach.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtWohnsitzPostfach.Properties.MaxLength = 100;
            this.edtWohnsitzPostfach.Properties.Name = "editPostfachWohnsitz.Properties";
            this.edtWohnsitzPostfach.Size = new System.Drawing.Size(159, 24);
            this.edtWohnsitzPostfach.TabIndex = 18;
            // 
            // edtPLZWohnsitz
            // 
            this.edtPLZWohnsitz.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtPLZWohnsitz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPLZWohnsitz.DataMember = "OrtschaftCode";
            this.edtPLZWohnsitz.DataMemberBaGemeindeID = null;
            this.edtPLZWohnsitz.DataSource = this.qryBaWohnsitzAdresse;
            this.edtPLZWohnsitz.Location = new System.Drawing.Point(98, 200);
            this.edtPLZWohnsitz.Name = "edtPLZWohnsitz";
            this.edtPLZWohnsitz.ShowBezirk = true;
            this.edtPLZWohnsitz.Size = new System.Drawing.Size(241, 70);
            this.edtPLZWohnsitz.TabIndex = 21;
            // 
            // grdBaAufenthaltAdresse
            // 
            this.grdBaAufenthaltAdresse.DataSource = this.qryBaWeitereAdressen;
            this.grdBaAufenthaltAdresse.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdBaAufenthaltAdresse.EmbeddedNavigator.Name = "kissGrid7.EmbeddedNavigator";
            this.grdBaAufenthaltAdresse.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBaAufenthaltAdresse.Location = new System.Drawing.Point(352, 27);
            this.grdBaAufenthaltAdresse.MainView = this.grvBaAufenthaltAdresse;
            this.grdBaAufenthaltAdresse.Name = "grdBaAufenthaltAdresse";
            this.grdBaAufenthaltAdresse.Size = new System.Drawing.Size(343, 209);
            this.grdBaAufenthaltAdresse.TabIndex = 4;
            this.grdBaAufenthaltAdresse.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBaAufenthaltAdresse});
            // 
            // qryBaWeitereAdressen
            // 
            this.qryBaWeitereAdressen.CanDelete = true;
            this.qryBaWeitereAdressen.CanInsert = true;
            this.qryBaWeitereAdressen.CanUpdate = true;
            this.qryBaWeitereAdressen.HostControl = this;
            this.qryBaWeitereAdressen.SelectStatement = resources.GetString("qryBaWeitereAdressen.SelectStatement");
            this.qryBaWeitereAdressen.TableName = "BaAdresse";
            this.qryBaWeitereAdressen.AfterDelete += new System.EventHandler(this.qryBaWeitereAdressen_AfterDelete);
            this.qryBaWeitereAdressen.AfterFill += new System.EventHandler(this.qryBaWeitereAdressen_AfterFill);
            this.qryBaWeitereAdressen.AfterInsert += new System.EventHandler(this.qryBaWeitereAdressen_AfterInsert);
            this.qryBaWeitereAdressen.BeforeDelete += new System.EventHandler(this.qryBaWeitereAdressen_BeforeDelete);
            this.qryBaWeitereAdressen.BeforeDeleteQuestion += new System.EventHandler(this.qryBaWeitereAdressen_BeforeDeleteQuestion);
            this.qryBaWeitereAdressen.BeforePost += new System.EventHandler(this.qryBaWeitereAdressen_BeforePost);
            this.qryBaWeitereAdressen.PositionChanged += new System.EventHandler(this.qryBaWeitereAdressen_PositionChanged);
            this.qryBaWeitereAdressen.PostCompleted += new System.EventHandler(this.qryBaWeitereAdressen_PostCompleted);
            // 
            // grvBaAufenthaltAdresse
            // 
            this.grvBaAufenthaltAdresse.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBaAufenthaltAdresse.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaAufenthaltAdresse.Appearance.Empty.Options.UseBackColor = true;
            this.grvBaAufenthaltAdresse.Appearance.Empty.Options.UseFont = true;
            this.grvBaAufenthaltAdresse.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaAufenthaltAdresse.Appearance.EvenRow.Options.UseFont = true;
            this.grvBaAufenthaltAdresse.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBaAufenthaltAdresse.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaAufenthaltAdresse.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBaAufenthaltAdresse.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBaAufenthaltAdresse.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBaAufenthaltAdresse.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBaAufenthaltAdresse.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBaAufenthaltAdresse.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaAufenthaltAdresse.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBaAufenthaltAdresse.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBaAufenthaltAdresse.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBaAufenthaltAdresse.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBaAufenthaltAdresse.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaAufenthaltAdresse.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBaAufenthaltAdresse.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaAufenthaltAdresse.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBaAufenthaltAdresse.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBaAufenthaltAdresse.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBaAufenthaltAdresse.Appearance.GroupRow.Options.UseFont = true;
            this.grvBaAufenthaltAdresse.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBaAufenthaltAdresse.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBaAufenthaltAdresse.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBaAufenthaltAdresse.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBaAufenthaltAdresse.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBaAufenthaltAdresse.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBaAufenthaltAdresse.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBaAufenthaltAdresse.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBaAufenthaltAdresse.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaAufenthaltAdresse.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBaAufenthaltAdresse.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBaAufenthaltAdresse.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBaAufenthaltAdresse.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBaAufenthaltAdresse.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBaAufenthaltAdresse.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBaAufenthaltAdresse.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaAufenthaltAdresse.Appearance.OddRow.Options.UseFont = true;
            this.grvBaAufenthaltAdresse.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBaAufenthaltAdresse.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaAufenthaltAdresse.Appearance.Row.Options.UseBackColor = true;
            this.grvBaAufenthaltAdresse.Appearance.Row.Options.UseFont = true;
            this.grvBaAufenthaltAdresse.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaAufenthaltAdresse.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBaAufenthaltAdresse.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBaAufenthaltAdresse.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBaAufenthaltAdresse.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBaAufenthaltAdresse.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAufenthaltDatumVon,
            this.colAufenthaltAdresstyp,
            this.colAufenthaltInstitution,
            this.colAufenthaltDatumBis});
            this.grvBaAufenthaltAdresse.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBaAufenthaltAdresse.GridControl = this.grdBaAufenthaltAdresse;
            this.grvBaAufenthaltAdresse.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvBaAufenthaltAdresse.Name = "grvBaAufenthaltAdresse";
            this.grvBaAufenthaltAdresse.OptionsBehavior.Editable = false;
            this.grvBaAufenthaltAdresse.OptionsCustomization.AllowFilter = false;
            this.grvBaAufenthaltAdresse.OptionsFilter.AllowFilterEditor = false;
            this.grvBaAufenthaltAdresse.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBaAufenthaltAdresse.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBaAufenthaltAdresse.OptionsNavigation.UseTabKey = false;
            this.grvBaAufenthaltAdresse.OptionsView.ColumnAutoWidth = false;
            this.grvBaAufenthaltAdresse.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBaAufenthaltAdresse.OptionsView.ShowGroupPanel = false;
            this.grvBaAufenthaltAdresse.OptionsView.ShowIndicator = false;
            // 
            // colAufenthaltDatumVon
            // 
            this.colAufenthaltDatumVon.Caption = "Von";
            this.colAufenthaltDatumVon.FieldName = "DatumVon";
            this.colAufenthaltDatumVon.Name = "colAufenthaltDatumVon";
            this.colAufenthaltDatumVon.Visible = true;
            this.colAufenthaltDatumVon.VisibleIndex = 0;
            // 
            // colAufenthaltAdresstyp
            // 
            this.colAufenthaltAdresstyp.Caption = "Adresstyp";
            this.colAufenthaltAdresstyp.FieldName = "AdresseCode";
            this.colAufenthaltAdresstyp.Name = "colAufenthaltAdresstyp";
            this.colAufenthaltAdresstyp.Visible = true;
            this.colAufenthaltAdresstyp.VisibleIndex = 2;
            this.colAufenthaltAdresstyp.Width = 90;
            // 
            // colAufenthaltInstitution
            // 
            this.colAufenthaltInstitution.Caption = "Ort/Inst.";
            this.colAufenthaltInstitution.FieldName = "CareOfOrt";
            this.colAufenthaltInstitution.Name = "colAufenthaltInstitution";
            this.colAufenthaltInstitution.Visible = true;
            this.colAufenthaltInstitution.VisibleIndex = 3;
            this.colAufenthaltInstitution.Width = 69;
            // 
            // colAufenthaltDatumBis
            // 
            this.colAufenthaltDatumBis.Caption = "Bis";
            this.colAufenthaltDatumBis.FieldName = "DatumBis";
            this.colAufenthaltDatumBis.Name = "colAufenthaltDatumBis";
            this.colAufenthaltDatumBis.Visible = true;
            this.colAufenthaltDatumBis.VisibleIndex = 1;
            // 
            // cboAdresstyp
            // 
            this.cboAdresstyp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAdresstyp.DataMember = "AdresseCode";
            this.cboAdresstyp.DataSource = this.qryBaWeitereAdressen;
            this.cboAdresstyp.Location = new System.Drawing.Point(93, 32);
            this.cboAdresstyp.LOVFilter = "not Code=1";
            this.cboAdresstyp.LOVFilterWhereAppend = true;
            this.cboAdresstyp.LOVName = "BaAdresstyp";
            this.cboAdresstyp.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.cboAdresstyp.Name = "cboAdresstyp";
            this.cboAdresstyp.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboAdresstyp.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboAdresstyp.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboAdresstyp.Properties.Appearance.Options.UseBackColor = true;
            this.cboAdresstyp.Properties.Appearance.Options.UseBorderColor = true;
            this.cboAdresstyp.Properties.Appearance.Options.UseFont = true;
            this.cboAdresstyp.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboAdresstyp.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboAdresstyp.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboAdresstyp.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboAdresstyp.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.cboAdresstyp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.cboAdresstyp.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboAdresstyp.Properties.NullText = "";
            this.cboAdresstyp.Properties.ShowFooter = false;
            this.cboAdresstyp.Properties.ShowHeader = false;
            this.cboAdresstyp.Size = new System.Drawing.Size(241, 24);
            this.cboAdresstyp.TabIndex = 5;
            // 
            // edtAufenthaltVon
            // 
            this.edtAufenthaltVon.DataMember = "DatumVon";
            this.edtAufenthaltVon.DataSource = this.qryBaWeitereAdressen;
            this.edtAufenthaltVon.EditValue = null;
            this.edtAufenthaltVon.Location = new System.Drawing.Point(93, 9);
            this.edtAufenthaltVon.Name = "edtAufenthaltVon";
            this.edtAufenthaltVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAufenthaltVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAufenthaltVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAufenthaltVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAufenthaltVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtAufenthaltVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAufenthaltVon.Properties.Appearance.Options.UseFont = true;
            this.edtAufenthaltVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtAufenthaltVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtAufenthaltVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtAufenthaltVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAufenthaltVon.Properties.Name = "kissDateEdit5.Properties";
            this.edtAufenthaltVon.Properties.ShowToday = false;
            this.edtAufenthaltVon.Size = new System.Drawing.Size(90, 24);
            this.edtAufenthaltVon.TabIndex = 1;
            // 
            // edtAufenthaltBis
            // 
            this.edtAufenthaltBis.DataMember = "DatumBis";
            this.edtAufenthaltBis.DataSource = this.qryBaWeitereAdressen;
            this.edtAufenthaltBis.EditValue = null;
            this.edtAufenthaltBis.Location = new System.Drawing.Point(224, 9);
            this.edtAufenthaltBis.Name = "edtAufenthaltBis";
            this.edtAufenthaltBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAufenthaltBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAufenthaltBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAufenthaltBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAufenthaltBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtAufenthaltBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAufenthaltBis.Properties.Appearance.Options.UseFont = true;
            this.edtAufenthaltBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtAufenthaltBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtAufenthaltBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtAufenthaltBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAufenthaltBis.Properties.Name = "kissDateEdit6.Properties";
            this.edtAufenthaltBis.Properties.ShowToday = false;
            this.edtAufenthaltBis.Size = new System.Drawing.Size(90, 24);
            this.edtAufenthaltBis.TabIndex = 3;
            // 
            // edtAufenthaltInstitutionName
            // 
            this.edtAufenthaltInstitutionName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtAufenthaltInstitutionName.DataMember = "CareOf";
            this.edtAufenthaltInstitutionName.DataSource = this.qryBaWeitereAdressen;
            this.edtAufenthaltInstitutionName.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAufenthaltInstitutionName.Location = new System.Drawing.Point(93, 78);
            this.edtAufenthaltInstitutionName.Name = "edtAufenthaltInstitutionName";
            this.edtAufenthaltInstitutionName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAufenthaltInstitutionName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAufenthaltInstitutionName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAufenthaltInstitutionName.Properties.Appearance.Options.UseBackColor = true;
            this.edtAufenthaltInstitutionName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAufenthaltInstitutionName.Properties.Appearance.Options.UseFont = true;
            this.edtAufenthaltInstitutionName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAufenthaltInstitutionName.Properties.MaxLength = 100;
            this.edtAufenthaltInstitutionName.Properties.ReadOnly = true;
            this.edtAufenthaltInstitutionName.Size = new System.Drawing.Size(222, 24);
            this.edtAufenthaltInstitutionName.TabIndex = 7;
            // 
            // edtInstitutionLookup
            // 
            this.edtInstitutionLookup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtInstitutionLookup.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtInstitutionLookup.Location = new System.Drawing.Point(314, 78);
            this.edtInstitutionLookup.Name = "edtInstitutionLookup";
            this.edtInstitutionLookup.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtInstitutionLookup.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtInstitutionLookup.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtInstitutionLookup.Properties.Appearance.Options.UseBackColor = true;
            this.edtInstitutionLookup.Properties.Appearance.Options.UseBorderColor = true;
            this.edtInstitutionLookup.Properties.Appearance.Options.UseFont = true;
            this.edtInstitutionLookup.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtInstitutionLookup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Up, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtInstitutionLookup.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtInstitutionLookup.Properties.Name = "btnInstitution.Properties";
            this.edtInstitutionLookup.Properties.ReadOnly = true;
            this.edtInstitutionLookup.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtInstitutionLookup.Size = new System.Drawing.Size(20, 24);
            this.edtInstitutionLookup.TabIndex = 8;
            this.edtInstitutionLookup.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtInstitutionLookup_UserModifiedFld);
            // 
            // edtAufenthaltZusatz
            // 
            this.edtAufenthaltZusatz.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtAufenthaltZusatz.DataMember = "Zusatz";
            this.edtAufenthaltZusatz.DataSource = this.qryBaWeitereAdressen;
            this.edtAufenthaltZusatz.Location = new System.Drawing.Point(93, 108);
            this.edtAufenthaltZusatz.Name = "edtAufenthaltZusatz";
            this.edtAufenthaltZusatz.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAufenthaltZusatz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAufenthaltZusatz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAufenthaltZusatz.Properties.Appearance.Options.UseBackColor = true;
            this.edtAufenthaltZusatz.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAufenthaltZusatz.Properties.Appearance.Options.UseFont = true;
            this.edtAufenthaltZusatz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAufenthaltZusatz.Properties.MaxLength = 200;
            this.edtAufenthaltZusatz.Properties.Name = "kissTextEdit22.Properties";
            this.edtAufenthaltZusatz.Size = new System.Drawing.Size(241, 24);
            this.edtAufenthaltZusatz.TabIndex = 10;
            // 
            // edtAufenthaltStrasse
            // 
            this.edtAufenthaltStrasse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtAufenthaltStrasse.DataMember = "Strasse";
            this.edtAufenthaltStrasse.DataSource = this.qryBaWeitereAdressen;
            this.edtAufenthaltStrasse.Location = new System.Drawing.Point(93, 154);
            this.edtAufenthaltStrasse.Name = "edtAufenthaltStrasse";
            this.edtAufenthaltStrasse.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAufenthaltStrasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAufenthaltStrasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAufenthaltStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.edtAufenthaltStrasse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAufenthaltStrasse.Properties.Appearance.Options.UseFont = true;
            this.edtAufenthaltStrasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAufenthaltStrasse.Properties.MaxLength = 100;
            this.edtAufenthaltStrasse.Properties.Name = "editStrasseAufenthaltsOrt.Properties";
            this.edtAufenthaltStrasse.Size = new System.Drawing.Size(193, 24);
            this.edtAufenthaltStrasse.TabIndex = 14;
            // 
            // edtAufenthaltHausNr
            // 
            this.edtAufenthaltHausNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtAufenthaltHausNr.DataMember = "HausNr";
            this.edtAufenthaltHausNr.DataSource = this.qryBaWeitereAdressen;
            this.edtAufenthaltHausNr.Location = new System.Drawing.Point(285, 154);
            this.edtAufenthaltHausNr.Name = "edtAufenthaltHausNr";
            this.edtAufenthaltHausNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAufenthaltHausNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAufenthaltHausNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAufenthaltHausNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtAufenthaltHausNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAufenthaltHausNr.Properties.Appearance.Options.UseFont = true;
            this.edtAufenthaltHausNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAufenthaltHausNr.Properties.MaxLength = 10;
            this.edtAufenthaltHausNr.Properties.Name = "editAufenthaltsOrtNummer.Properties";
            this.edtAufenthaltHausNr.Size = new System.Drawing.Size(49, 24);
            this.edtAufenthaltHausNr.TabIndex = 15;
            // 
            // edtAufenthaltPostfach
            // 
            this.edtAufenthaltPostfach.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtAufenthaltPostfach.DataMember = "Postfach";
            this.edtAufenthaltPostfach.DataSource = this.qryBaWeitereAdressen;
            this.edtAufenthaltPostfach.Location = new System.Drawing.Point(93, 177);
            this.edtAufenthaltPostfach.Name = "edtAufenthaltPostfach";
            this.edtAufenthaltPostfach.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAufenthaltPostfach.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAufenthaltPostfach.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAufenthaltPostfach.Properties.Appearance.Options.UseBackColor = true;
            this.edtAufenthaltPostfach.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAufenthaltPostfach.Properties.Appearance.Options.UseFont = true;
            this.edtAufenthaltPostfach.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAufenthaltPostfach.Properties.MaxLength = 100;
            this.edtAufenthaltPostfach.Properties.Name = "editAufenthaltsOrtPosfach.Properties";
            this.edtAufenthaltPostfach.Size = new System.Drawing.Size(159, 24);
            this.edtAufenthaltPostfach.TabIndex = 17;
            // 
            // edtPLZAufenthalt
            // 
            this.edtPLZAufenthalt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtPLZAufenthalt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPLZAufenthalt.DataMember = "OrtschaftCode";
            this.edtPLZAufenthalt.DataMemberBaGemeindeID = null;
            this.edtPLZAufenthalt.DataSource = this.qryBaWeitereAdressen;
            this.edtPLZAufenthalt.Location = new System.Drawing.Point(93, 200);
            this.edtPLZAufenthalt.Name = "edtPLZAufenthalt";
            this.edtPLZAufenthalt.ShowBezirk = true;
            this.edtPLZAufenthalt.Size = new System.Drawing.Size(241, 70);
            this.edtPLZAufenthalt.TabIndex = 20;
            // 
            // lblTitelWohnsitz
            // 
            this.lblTitelWohnsitz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitelWohnsitz.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblTitelWohnsitz.Location = new System.Drawing.Point(3, 0);
            this.lblTitelWohnsitz.Name = "lblTitelWohnsitz";
            this.lblTitelWohnsitz.Size = new System.Drawing.Size(343, 24);
            this.lblTitelWohnsitz.TabIndex = 0;
            this.lblTitelWohnsitz.Text = "Wohn- und Meldeadresse";
            this.lblTitelWohnsitz.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitelWohnsitz.UseCompatibleTextRendering = true;
            // 
            // lblWohnsitzNameVorname
            // 
            this.lblWohnsitzNameVorname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblWohnsitzNameVorname.Location = new System.Drawing.Point(4, 108);
            this.lblWohnsitzNameVorname.Name = "lblWohnsitzNameVorname";
            this.lblWohnsitzNameVorname.Size = new System.Drawing.Size(83, 24);
            this.lblWohnsitzNameVorname.TabIndex = 10;
            this.lblWohnsitzNameVorname.Text = "Name / Vorn.";
            this.lblWohnsitzNameVorname.UseCompatibleTextRendering = true;
            // 
            // lblWohnsitzZusatz
            // 
            this.lblWohnsitzZusatz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblWohnsitzZusatz.Location = new System.Drawing.Point(4, 131);
            this.lblWohnsitzZusatz.Name = "lblWohnsitzZusatz";
            this.lblWohnsitzZusatz.Size = new System.Drawing.Size(83, 24);
            this.lblWohnsitzZusatz.TabIndex = 12;
            this.lblWohnsitzZusatz.Text = "Zusatz";
            this.lblWohnsitzZusatz.UseCompatibleTextRendering = true;
            // 
            // lblWohnsitzStrasseNr
            // 
            this.lblWohnsitzStrasseNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblWohnsitzStrasseNr.Location = new System.Drawing.Point(4, 154);
            this.lblWohnsitzStrasseNr.Name = "lblWohnsitzStrasseNr";
            this.lblWohnsitzStrasseNr.Size = new System.Drawing.Size(83, 24);
            this.lblWohnsitzStrasseNr.TabIndex = 14;
            this.lblWohnsitzStrasseNr.Text = "Strasse / Nr";
            this.lblWohnsitzStrasseNr.UseCompatibleTextRendering = true;
            // 
            // lblWohnsitzPostfach
            // 
            this.lblWohnsitzPostfach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblWohnsitzPostfach.Location = new System.Drawing.Point(4, 177);
            this.lblWohnsitzPostfach.Name = "lblWohnsitzPostfach";
            this.lblWohnsitzPostfach.Size = new System.Drawing.Size(83, 24);
            this.lblWohnsitzPostfach.TabIndex = 17;
            this.lblWohnsitzPostfach.Text = "Postfach";
            this.lblWohnsitzPostfach.UseCompatibleTextRendering = true;
            // 
            // lblWohnsitzPLZOrtKt
            // 
            this.lblWohnsitzPLZOrtKt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblWohnsitzPLZOrtKt.Location = new System.Drawing.Point(4, 200);
            this.lblWohnsitzPLZOrtKt.Name = "lblWohnsitzPLZOrtKt";
            this.lblWohnsitzPLZOrtKt.Size = new System.Drawing.Size(83, 24);
            this.lblWohnsitzPLZOrtKt.TabIndex = 20;
            this.lblWohnsitzPLZOrtKt.Text = "PLZ / Ort / Kt";
            this.lblWohnsitzPLZOrtKt.UseCompatibleTextRendering = true;
            // 
            // lblWohnsitzLand
            // 
            this.lblWohnsitzLand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblWohnsitzLand.Location = new System.Drawing.Point(4, 246);
            this.lblWohnsitzLand.Name = "lblWohnsitzLand";
            this.lblWohnsitzLand.Size = new System.Drawing.Size(83, 24);
            this.lblWohnsitzLand.TabIndex = 23;
            this.lblWohnsitzLand.Text = "Land";
            this.lblWohnsitzLand.UseCompatibleTextRendering = true;
            // 
            // lblTitelOtherAddress
            // 
            this.lblTitelOtherAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitelOtherAddress.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblTitelOtherAddress.Location = new System.Drawing.Point(352, 0);
            this.lblTitelOtherAddress.Name = "lblTitelOtherAddress";
            this.lblTitelOtherAddress.Size = new System.Drawing.Size(343, 24);
            this.lblTitelOtherAddress.TabIndex = 3;
            this.lblTitelOtherAddress.Text = "Weitere Adressen";
            this.lblTitelOtherAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitelOtherAddress.UseCompatibleTextRendering = true;
            // 
            // lblAufenthaltDatumVon
            // 
            this.lblAufenthaltDatumVon.Location = new System.Drawing.Point(4, 9);
            this.lblAufenthaltDatumVon.Name = "lblAufenthaltDatumVon";
            this.lblAufenthaltDatumVon.Size = new System.Drawing.Size(83, 24);
            this.lblAufenthaltDatumVon.TabIndex = 0;
            this.lblAufenthaltDatumVon.Text = "Datum von";
            this.lblAufenthaltDatumVon.UseCompatibleTextRendering = true;
            // 
            // lblAufenthaltDatumBis
            // 
            this.lblAufenthaltDatumBis.Location = new System.Drawing.Point(189, 9);
            this.lblAufenthaltDatumBis.Name = "lblAufenthaltDatumBis";
            this.lblAufenthaltDatumBis.Size = new System.Drawing.Size(29, 24);
            this.lblAufenthaltDatumBis.TabIndex = 2;
            this.lblAufenthaltDatumBis.Text = "bis";
            this.lblAufenthaltDatumBis.UseCompatibleTextRendering = true;
            // 
            // lblAufenthaltInstitution
            // 
            this.lblAufenthaltInstitution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAufenthaltInstitution.Location = new System.Drawing.Point(4, 78);
            this.lblAufenthaltInstitution.Name = "lblAufenthaltInstitution";
            this.lblAufenthaltInstitution.Size = new System.Drawing.Size(83, 24);
            this.lblAufenthaltInstitution.TabIndex = 6;
            this.lblAufenthaltInstitution.Text = "Institution";
            this.lblAufenthaltInstitution.UseCompatibleTextRendering = true;
            // 
            // lblAufenthaltZusatz
            // 
            this.lblAufenthaltZusatz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAufenthaltZusatz.Location = new System.Drawing.Point(4, 108);
            this.lblAufenthaltZusatz.Name = "lblAufenthaltZusatz";
            this.lblAufenthaltZusatz.Size = new System.Drawing.Size(83, 24);
            this.lblAufenthaltZusatz.TabIndex = 9;
            this.lblAufenthaltZusatz.Text = "Zusatz";
            this.lblAufenthaltZusatz.UseCompatibleTextRendering = true;
            // 
            // lblAufenthaltStrasseHausNr
            // 
            this.lblAufenthaltStrasseHausNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAufenthaltStrasseHausNr.Location = new System.Drawing.Point(4, 154);
            this.lblAufenthaltStrasseHausNr.Name = "lblAufenthaltStrasseHausNr";
            this.lblAufenthaltStrasseHausNr.Size = new System.Drawing.Size(83, 24);
            this.lblAufenthaltStrasseHausNr.TabIndex = 13;
            this.lblAufenthaltStrasseHausNr.Text = "Strasse / Nr";
            this.lblAufenthaltStrasseHausNr.UseCompatibleTextRendering = true;
            // 
            // lblAufenthaltPostfach
            // 
            this.lblAufenthaltPostfach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAufenthaltPostfach.Location = new System.Drawing.Point(4, 177);
            this.lblAufenthaltPostfach.Name = "lblAufenthaltPostfach";
            this.lblAufenthaltPostfach.Size = new System.Drawing.Size(83, 24);
            this.lblAufenthaltPostfach.TabIndex = 16;
            this.lblAufenthaltPostfach.Text = "Postfach";
            this.lblAufenthaltPostfach.UseCompatibleTextRendering = true;
            // 
            // lblAufenthaltPLZOrtKt
            // 
            this.lblAufenthaltPLZOrtKt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAufenthaltPLZOrtKt.Location = new System.Drawing.Point(4, 200);
            this.lblAufenthaltPLZOrtKt.Name = "lblAufenthaltPLZOrtKt";
            this.lblAufenthaltPLZOrtKt.Size = new System.Drawing.Size(83, 24);
            this.lblAufenthaltPLZOrtKt.TabIndex = 19;
            this.lblAufenthaltPLZOrtKt.Text = "PLZ / Ort / Kt";
            this.lblAufenthaltPLZOrtKt.UseCompatibleTextRendering = true;
            // 
            // lblAufenthaltLand
            // 
            this.lblAufenthaltLand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAufenthaltLand.Location = new System.Drawing.Point(4, 246);
            this.lblAufenthaltLand.Name = "lblAufenthaltLand";
            this.lblAufenthaltLand.Size = new System.Drawing.Size(83, 24);
            this.lblAufenthaltLand.TabIndex = 22;
            this.lblAufenthaltLand.Text = "Land";
            this.lblAufenthaltLand.UseCompatibleTextRendering = true;
            // 
            // lblWohnsitzDatumVon
            // 
            this.lblWohnsitzDatumVon.Location = new System.Drawing.Point(4, 9);
            this.lblWohnsitzDatumVon.Name = "lblWohnsitzDatumVon";
            this.lblWohnsitzDatumVon.Size = new System.Drawing.Size(83, 24);
            this.lblWohnsitzDatumVon.TabIndex = 0;
            this.lblWohnsitzDatumVon.Text = "Datum von";
            this.lblWohnsitzDatumVon.UseCompatibleTextRendering = true;
            // 
            // lblWohnsitzDatumBis
            // 
            this.lblWohnsitzDatumBis.Location = new System.Drawing.Point(194, 9);
            this.lblWohnsitzDatumBis.Name = "lblWohnsitzDatumBis";
            this.lblWohnsitzDatumBis.Size = new System.Drawing.Size(29, 24);
            this.lblWohnsitzDatumBis.TabIndex = 2;
            this.lblWohnsitzDatumBis.Text = "bis";
            this.lblWohnsitzDatumBis.UseCompatibleTextRendering = true;
            // 
            // lblAufenthaltAdresstyp
            // 
            this.lblAufenthaltAdresstyp.Location = new System.Drawing.Point(4, 32);
            this.lblAufenthaltAdresstyp.Name = "lblAufenthaltAdresstyp";
            this.lblAufenthaltAdresstyp.Size = new System.Drawing.Size(83, 24);
            this.lblAufenthaltAdresstyp.TabIndex = 4;
            this.lblAufenthaltAdresstyp.Text = "Adresstyp";
            this.lblAufenthaltAdresstyp.UseCompatibleTextRendering = true;
            // 
            // cboAdresstypWohnsitz
            // 
            this.cboAdresstypWohnsitz.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAdresstypWohnsitz.DataMember = "AdresseCode";
            this.cboAdresstypWohnsitz.DataSource = this.qryBaWohnsitzAdresse;
            this.cboAdresstypWohnsitz.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.cboAdresstypWohnsitz.Location = new System.Drawing.Point(98, 32);
            this.cboAdresstypWohnsitz.LOVFilter = "Code = 1";
            this.cboAdresstypWohnsitz.LOVFilterWhereAppend = true;
            this.cboAdresstypWohnsitz.LOVName = "BaAdresstyp";
            this.cboAdresstypWohnsitz.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.cboAdresstypWohnsitz.Name = "cboAdresstypWohnsitz";
            this.cboAdresstypWohnsitz.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.cboAdresstypWohnsitz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboAdresstypWohnsitz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboAdresstypWohnsitz.Properties.Appearance.Options.UseBackColor = true;
            this.cboAdresstypWohnsitz.Properties.Appearance.Options.UseBorderColor = true;
            this.cboAdresstypWohnsitz.Properties.Appearance.Options.UseFont = true;
            this.cboAdresstypWohnsitz.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboAdresstypWohnsitz.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboAdresstypWohnsitz.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboAdresstypWohnsitz.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboAdresstypWohnsitz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.cboAdresstypWohnsitz.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.cboAdresstypWohnsitz.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboAdresstypWohnsitz.Properties.NullText = "";
            this.cboAdresstypWohnsitz.Properties.ReadOnly = true;
            this.cboAdresstypWohnsitz.Properties.ShowFooter = false;
            this.cboAdresstypWohnsitz.Properties.ShowHeader = false;
            this.cboAdresstypWohnsitz.Size = new System.Drawing.Size(241, 24);
            this.cboAdresstypWohnsitz.TabIndex = 5;
            this.cboAdresstypWohnsitz.TabStop = false;
            // 
            // lblWohnsitzAdressTyp
            // 
            this.lblWohnsitzAdressTyp.Location = new System.Drawing.Point(4, 31);
            this.lblWohnsitzAdressTyp.Name = "lblWohnsitzAdressTyp";
            this.lblWohnsitzAdressTyp.Size = new System.Drawing.Size(83, 24);
            this.lblWohnsitzAdressTyp.TabIndex = 4;
            this.lblWohnsitzAdressTyp.Text = "Adresstyp";
            this.lblWohnsitzAdressTyp.UseCompatibleTextRendering = true;
            // 
            // edtWohnsituationsCode
            // 
            this.edtWohnsituationsCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtWohnsituationsCode.DataMember = "WohnStatusCode";
            this.edtWohnsituationsCode.DataSource = this.qryBaWohnsitzAdresse;
            this.edtWohnsituationsCode.Location = new System.Drawing.Point(98, 55);
            this.edtWohnsituationsCode.LOVName = "Wohnstatus";
            this.edtWohnsituationsCode.Name = "edtWohnsituationsCode";
            this.edtWohnsituationsCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWohnsituationsCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWohnsituationsCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWohnsituationsCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtWohnsituationsCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWohnsituationsCode.Properties.Appearance.Options.UseFont = true;
            this.edtWohnsituationsCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtWohnsituationsCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtWohnsituationsCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtWohnsituationsCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtWohnsituationsCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtWohnsituationsCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtWohnsituationsCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtWohnsituationsCode.Properties.NullText = "";
            this.edtWohnsituationsCode.Properties.ShowFooter = false;
            this.edtWohnsituationsCode.Properties.ShowHeader = false;
            this.edtWohnsituationsCode.Size = new System.Drawing.Size(241, 24);
            this.edtWohnsituationsCode.TabIndex = 7;
            this.edtWohnsituationsCode.EditValueChanged += new System.EventHandler(this.edtWohnSituationCode_EditValueChanged);
            // 
            // edtWohnungsgroesseCode
            // 
            this.edtWohnungsgroesseCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtWohnungsgroesseCode.DataMember = "WohnungsgroesseCode";
            this.edtWohnungsgroesseCode.DataSource = this.qryBaWohnsitzAdresse;
            this.edtWohnungsgroesseCode.Location = new System.Drawing.Point(98, 78);
            this.edtWohnungsgroesseCode.LOVName = "Wohnungsgroesse";
            this.edtWohnungsgroesseCode.Name = "edtWohnungsgroesseCode";
            this.edtWohnungsgroesseCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWohnungsgroesseCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWohnungsgroesseCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWohnungsgroesseCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtWohnungsgroesseCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWohnungsgroesseCode.Properties.Appearance.Options.UseFont = true;
            this.edtWohnungsgroesseCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtWohnungsgroesseCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtWohnungsgroesseCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtWohnungsgroesseCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtWohnungsgroesseCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtWohnungsgroesseCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtWohnungsgroesseCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtWohnungsgroesseCode.Properties.NullText = "";
            this.edtWohnungsgroesseCode.Properties.ShowFooter = false;
            this.edtWohnungsgroesseCode.Properties.ShowHeader = false;
            this.edtWohnungsgroesseCode.Size = new System.Drawing.Size(241, 24);
            this.edtWohnungsgroesseCode.TabIndex = 9;
            // 
            // lblWohnsitzWohnungsgroesse
            // 
            this.lblWohnsitzWohnungsgroesse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblWohnsitzWohnungsgroesse.Location = new System.Drawing.Point(4, 78);
            this.lblWohnsitzWohnungsgroesse.Name = "lblWohnsitzWohnungsgroesse";
            this.lblWohnsitzWohnungsgroesse.Size = new System.Drawing.Size(83, 24);
            this.lblWohnsitzWohnungsgroesse.TabIndex = 8;
            this.lblWohnsitzWohnungsgroesse.Text = "Wohnungsgr.";
            this.lblWohnsitzWohnungsgroesse.UseCompatibleTextRendering = true;
            // 
            // lblWohnsitzWohnstatus
            // 
            this.lblWohnsitzWohnstatus.Location = new System.Drawing.Point(4, 55);
            this.lblWohnsitzWohnstatus.Name = "lblWohnsitzWohnstatus";
            this.lblWohnsitzWohnstatus.Size = new System.Drawing.Size(83, 24);
            this.lblWohnsitzWohnstatus.TabIndex = 6;
            this.lblWohnsitzWohnstatus.Text = "Wohnstatus";
            this.lblWohnsitzWohnstatus.UseCompatibleTextRendering = true;
            // 
            // chkWohnsitzPostfachOhneNr
            // 
            this.chkWohnsitzPostfachOhneNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkWohnsitzPostfachOhneNr.DataMember = "PostfachOhneNr";
            this.chkWohnsitzPostfachOhneNr.DataSource = this.qryBaWohnsitzAdresse;
            this.chkWohnsitzPostfachOhneNr.Location = new System.Drawing.Point(263, 179);
            this.chkWohnsitzPostfachOhneNr.Name = "chkWohnsitzPostfachOhneNr";
            this.chkWohnsitzPostfachOhneNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkWohnsitzPostfachOhneNr.Properties.Appearance.Options.UseBackColor = true;
            this.chkWohnsitzPostfachOhneNr.Properties.Caption = "ohne Nr.";
            this.chkWohnsitzPostfachOhneNr.Size = new System.Drawing.Size(76, 19);
            this.chkWohnsitzPostfachOhneNr.TabIndex = 19;
            this.chkWohnsitzPostfachOhneNr.CheckedChanged += new System.EventHandler(this.chkWohnsitzPostfachOhneNr_CheckedChanged);
            // 
            // chkAufenthaltPostfachOhneNr
            // 
            this.chkAufenthaltPostfachOhneNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAufenthaltPostfachOhneNr.DataMember = "PostfachOhneNr";
            this.chkAufenthaltPostfachOhneNr.DataSource = this.qryBaWeitereAdressen;
            this.chkAufenthaltPostfachOhneNr.Location = new System.Drawing.Point(258, 179);
            this.chkAufenthaltPostfachOhneNr.Name = "chkAufenthaltPostfachOhneNr";
            this.chkAufenthaltPostfachOhneNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkAufenthaltPostfachOhneNr.Properties.Appearance.Options.UseBackColor = true;
            this.chkAufenthaltPostfachOhneNr.Properties.Caption = "ohne Nr.";
            this.chkAufenthaltPostfachOhneNr.Size = new System.Drawing.Size(76, 19);
            this.chkAufenthaltPostfachOhneNr.TabIndex = 18;
            this.chkAufenthaltPostfachOhneNr.CheckedChanged += new System.EventHandler(this.chkAufenthaltPostfachOhneNr_CheckedChanged);
            // 
            // pnlTableLayout
            // 
            this.pnlTableLayout.ColumnCount = 2;
            this.pnlTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlTableLayout.Controls.Add(this.panDetailsWohnsitz, 0, 2);
            this.pnlTableLayout.Controls.Add(this.panDetailsOtherAddress, 1, 2);
            this.pnlTableLayout.Controls.Add(this.grdBaWohnsitzAdresse, 0, 1);
            this.pnlTableLayout.Controls.Add(this.grdBaAufenthaltAdresse, 1, 1);
            this.pnlTableLayout.Controls.Add(this.lblTitelWohnsitz, 0, 0);
            this.pnlTableLayout.Controls.Add(this.lblTitelOtherAddress, 1, 0);
            this.pnlTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTableLayout.Location = new System.Drawing.Point(0, 0);
            this.pnlTableLayout.Name = "pnlTableLayout";
            this.pnlTableLayout.RowCount = 3;
            this.pnlTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.pnlTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 285F));
            this.pnlTableLayout.Size = new System.Drawing.Size(698, 524);
            this.pnlTableLayout.TabIndex = 0;
            // 
            // panDetailsWohnsitz
            // 
            this.panDetailsWohnsitz.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panDetailsWohnsitz.Controls.Add(this.panTblWohnsitzNameVorname);
            this.panDetailsWohnsitz.Controls.Add(this.lblWohnsitzAdressTyp);
            this.panDetailsWohnsitz.Controls.Add(this.edtWohnsitzVon);
            this.panDetailsWohnsitz.Controls.Add(this.chkWohnsitzPostfachOhneNr);
            this.panDetailsWohnsitz.Controls.Add(this.edtWohnsituationsCode);
            this.panDetailsWohnsitz.Controls.Add(this.edtWohnungsgroesseCode);
            this.panDetailsWohnsitz.Controls.Add(this.edtWohnsitzBis);
            this.panDetailsWohnsitz.Controls.Add(this.lblWohnsitzWohnungsgroesse);
            this.panDetailsWohnsitz.Controls.Add(this.edtWohnsitzZusatz);
            this.panDetailsWohnsitz.Controls.Add(this.lblWohnsitzWohnstatus);
            this.panDetailsWohnsitz.Controls.Add(this.edtWohnsitzStrasse);
            this.panDetailsWohnsitz.Controls.Add(this.edtNummerWohnsitz);
            this.panDetailsWohnsitz.Controls.Add(this.cboAdresstypWohnsitz);
            this.panDetailsWohnsitz.Controls.Add(this.edtWohnsitzPostfach);
            this.panDetailsWohnsitz.Controls.Add(this.edtPLZWohnsitz);
            this.panDetailsWohnsitz.Controls.Add(this.lblWohnsitzNameVorname);
            this.panDetailsWohnsitz.Controls.Add(this.lblWohnsitzZusatz);
            this.panDetailsWohnsitz.Controls.Add(this.lblWohnsitzStrasseNr);
            this.panDetailsWohnsitz.Controls.Add(this.lblWohnsitzPostfach);
            this.panDetailsWohnsitz.Controls.Add(this.lblWohnsitzDatumBis);
            this.panDetailsWohnsitz.Controls.Add(this.lblWohnsitzPLZOrtKt);
            this.panDetailsWohnsitz.Controls.Add(this.lblWohnsitzBezirk);
            this.panDetailsWohnsitz.Controls.Add(this.lblWohnsitzLand);
            this.panDetailsWohnsitz.Controls.Add(this.lblWohnsitzDatumVon);
            this.panDetailsWohnsitz.Location = new System.Drawing.Point(3, 242);
            this.panDetailsWohnsitz.Name = "panDetailsWohnsitz";
            this.panDetailsWohnsitz.Size = new System.Drawing.Size(343, 279);
            this.panDetailsWohnsitz.TabIndex = 2;
            // 
            // panTblWohnsitzNameVorname
            // 
            this.panTblWohnsitzNameVorname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panTblWohnsitzNameVorname.ColumnCount = 2;
            this.panTblWohnsitzNameVorname.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.panTblWohnsitzNameVorname.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.panTblWohnsitzNameVorname.Controls.Add(this.edtVorname, 1, 0);
            this.panTblWohnsitzNameVorname.Controls.Add(this.edtName, 0, 0);
            this.panTblWohnsitzNameVorname.Location = new System.Drawing.Point(98, 109);
            this.panTblWohnsitzNameVorname.Name = "panTblWohnsitzNameVorname";
            this.panTblWohnsitzNameVorname.RowCount = 1;
            this.panTblWohnsitzNameVorname.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panTblWohnsitzNameVorname.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panTblWohnsitzNameVorname.Size = new System.Drawing.Size(241, 24);
            this.panTblWohnsitzNameVorname.TabIndex = 11;
            // 
            // lblWohnsitzBezirk
            // 
            this.lblWohnsitzBezirk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblWohnsitzBezirk.Location = new System.Drawing.Point(4, 223);
            this.lblWohnsitzBezirk.Name = "lblWohnsitzBezirk";
            this.lblWohnsitzBezirk.Size = new System.Drawing.Size(83, 24);
            this.lblWohnsitzBezirk.TabIndex = 22;
            this.lblWohnsitzBezirk.Text = "Bezirk";
            this.lblWohnsitzBezirk.UseCompatibleTextRendering = true;
            // 
            // panDetailsOtherAddress
            // 
            this.panDetailsOtherAddress.Controls.Add(this.lblAufenthaltAdresstyp);
            this.panDetailsOtherAddress.Controls.Add(this.chkAufenthaltPostfachOhneNr);
            this.panDetailsOtherAddress.Controls.Add(this.cboAdresstyp);
            this.panDetailsOtherAddress.Controls.Add(this.edtAufenthaltVon);
            this.panDetailsOtherAddress.Controls.Add(this.lblAufenthaltLand);
            this.panDetailsOtherAddress.Controls.Add(this.edtAufenthaltBis);
            this.panDetailsOtherAddress.Controls.Add(this.lblAufenthaltPLZOrtKt);
            this.panDetailsOtherAddress.Controls.Add(this.edtAufenthaltInstitutionName);
            this.panDetailsOtherAddress.Controls.Add(this.lblAufenthaltPostfach);
            this.panDetailsOtherAddress.Controls.Add(this.edtInstitutionLookup);
            this.panDetailsOtherAddress.Controls.Add(this.lblAufenthaltStrasseHausNr);
            this.panDetailsOtherAddress.Controls.Add(this.edtAufenthaltZuhandenVon);
            this.panDetailsOtherAddress.Controls.Add(this.edtAufenthaltZusatz);
            this.panDetailsOtherAddress.Controls.Add(this.lblAufenthaltZuhandenVon);
            this.panDetailsOtherAddress.Controls.Add(this.lblAufenthaltZusatz);
            this.panDetailsOtherAddress.Controls.Add(this.edtAufenthaltStrasse);
            this.panDetailsOtherAddress.Controls.Add(this.lblAufenthaltInstitution);
            this.panDetailsOtherAddress.Controls.Add(this.edtAufenthaltHausNr);
            this.panDetailsOtherAddress.Controls.Add(this.lblAufenthaltDatumBis);
            this.panDetailsOtherAddress.Controls.Add(this.edtAufenthaltPostfach);
            this.panDetailsOtherAddress.Controls.Add(this.lblAufenthaltDatumVon);
            this.panDetailsOtherAddress.Controls.Add(this.lblAufenthaltBezirk);
            this.panDetailsOtherAddress.Controls.Add(this.edtPLZAufenthalt);
            this.panDetailsOtherAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panDetailsOtherAddress.Location = new System.Drawing.Point(352, 242);
            this.panDetailsOtherAddress.Name = "panDetailsOtherAddress";
            this.panDetailsOtherAddress.Size = new System.Drawing.Size(343, 279);
            this.panDetailsOtherAddress.TabIndex = 5;
            // 
            // edtAufenthaltZuhandenVon
            // 
            this.edtAufenthaltZuhandenVon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtAufenthaltZuhandenVon.DataMember = "ZuhandenVon";
            this.edtAufenthaltZuhandenVon.DataSource = this.qryBaWeitereAdressen;
            this.edtAufenthaltZuhandenVon.Location = new System.Drawing.Point(93, 131);
            this.edtAufenthaltZuhandenVon.Name = "edtAufenthaltZuhandenVon";
            this.edtAufenthaltZuhandenVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAufenthaltZuhandenVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAufenthaltZuhandenVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAufenthaltZuhandenVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtAufenthaltZuhandenVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAufenthaltZuhandenVon.Properties.Appearance.Options.UseFont = true;
            this.edtAufenthaltZuhandenVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAufenthaltZuhandenVon.Properties.MaxLength = 200;
            this.edtAufenthaltZuhandenVon.Properties.Name = "kissTextEdit22.Properties";
            this.edtAufenthaltZuhandenVon.Size = new System.Drawing.Size(241, 24);
            this.edtAufenthaltZuhandenVon.TabIndex = 12;
            // 
            // lblAufenthaltZuhandenVon
            // 
            this.lblAufenthaltZuhandenVon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAufenthaltZuhandenVon.Location = new System.Drawing.Point(4, 131);
            this.lblAufenthaltZuhandenVon.Name = "lblAufenthaltZuhandenVon";
            this.lblAufenthaltZuhandenVon.Size = new System.Drawing.Size(83, 24);
            this.lblAufenthaltZuhandenVon.TabIndex = 11;
            this.lblAufenthaltZuhandenVon.Text = "Zuhanden von";
            this.lblAufenthaltZuhandenVon.UseCompatibleTextRendering = true;
            // 
            // lblAufenthaltBezirk
            // 
            this.lblAufenthaltBezirk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAufenthaltBezirk.Location = new System.Drawing.Point(4, 222);
            this.lblAufenthaltBezirk.Name = "lblAufenthaltBezirk";
            this.lblAufenthaltBezirk.Size = new System.Drawing.Size(83, 24);
            this.lblAufenthaltBezirk.TabIndex = 21;
            this.lblAufenthaltBezirk.Text = "Bezirk";
            this.lblAufenthaltBezirk.UseCompatibleTextRendering = true;
            // 
            // CtlBaPersonAdresse
            // 
            this.Controls.Add(this.pnlTableLayout);
            this.Name = "CtlBaPersonAdresse";
            this.Size = new System.Drawing.Size(698, 524);
            this.AddData += new System.EventHandler(this.CtlBaPersonAdresse_AddData);
            this.DeleteData += new System.EventHandler(this.CtlBaPersonAdresse_DeleteData);
            this.MoveFirst += new System.EventHandler(this.CtlBaPersonAdresse_MoveFirst);
            this.MoveLast += new System.EventHandler(this.CtlBaPersonAdresse_MoveLast);
            this.MoveNext += new System.EventHandler(this.CtlBaPersonAdresse_MoveNext);
            this.MovePrevious += new System.EventHandler(this.CtlBaPersonAdresse_MovePrevious);
            this.RefreshData += new System.EventHandler(this.CtlBaPersonAdresse_RefreshData);
            this.SaveData += new System.EventHandler(this.CtlBaPersonAdresse_SaveData);
            this.UndoDataChanges += new System.EventHandler(this.CtlBaPersonAdresse_UndoDataChanges);
            this.Load += new System.EventHandler(this.CtlBaPersonAdresse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdBaWohnsitzAdresse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaWohnsitzAdresse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaWohnsitzAdresse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitzVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitzBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitzZusatz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitzStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNummerWohnsitz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitzPostfach.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaAufenthaltAdresse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaWeitereAdressen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaAufenthaltAdresse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAdresstyp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAdresstyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAufenthaltVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAufenthaltBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAufenthaltInstitutionName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInstitutionLookup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAufenthaltZusatz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAufenthaltStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAufenthaltHausNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAufenthaltPostfach.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitelWohnsitz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWohnsitzNameVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWohnsitzZusatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWohnsitzStrasseNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWohnsitzPostfach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWohnsitzPLZOrtKt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWohnsitzLand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitelOtherAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAufenthaltDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAufenthaltDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAufenthaltInstitution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAufenthaltZusatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAufenthaltStrasseHausNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAufenthaltPostfach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAufenthaltPLZOrtKt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAufenthaltLand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWohnsitzDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWohnsitzDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAufenthaltAdresstyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAdresstypWohnsitz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAdresstypWohnsitz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWohnsitzAdressTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsituationsCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsituationsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnungsgroesseCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnungsgroesseCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWohnsitzWohnungsgroesse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWohnsitzWohnstatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkWohnsitzPostfachOhneNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAufenthaltPostfachOhneNr.Properties)).EndInit();
            this.pnlTableLayout.ResumeLayout(false);
            this.panDetailsWohnsitz.ResumeLayout(false);
            this.panTblWohnsitzNameVorname.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblWohnsitzBezirk)).EndInit();
            this.panDetailsOtherAddress.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtAufenthaltZuhandenVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAufenthaltZuhandenVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAufenthaltBezirk)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissLookUpEdit cboAdresstyp;
        private KiSS4.Gui.KissLookUpEdit cboAdresstypWohnsitz;
        private KiSS4.Gui.KissCheckEdit chkAufenthaltPostfachOhneNr;
        private KiSS4.Gui.KissCheckEdit chkWohnsitzPostfachOhneNr;
        private DevExpress.XtraGrid.Columns.GridColumn colAufenthaltAdresstyp;
        private DevExpress.XtraGrid.Columns.GridColumn colAufenthaltDatumBis;
        private DevExpress.XtraGrid.Columns.GridColumn colAufenthaltDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colAufenthaltInstitution;
        private DevExpress.XtraGrid.Columns.GridColumn colWohnsitzDatumBis;
        private DevExpress.XtraGrid.Columns.GridColumn colWohnsitzDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colWohnsitzHausNr;
        private DevExpress.XtraGrid.Columns.GridColumn colWohnsitzStrasse;
        private KiSS4.Gui.KissDateEdit edtAufenthaltBis;
        private KiSS4.Gui.KissTextEdit edtAufenthaltHausNr;
        private KiSS4.Gui.KissTextEdit edtAufenthaltInstitutionName;
        private KiSS4.Gui.KissTextEdit edtAufenthaltPostfach;
        private KiSS4.Gui.KissTextEdit edtAufenthaltStrasse;
        private KiSS4.Gui.KissDateEdit edtAufenthaltVon;
        private KiSS4.Gui.KissTextEdit edtAufenthaltZuhandenVon;
        private KiSS4.Gui.KissTextEdit edtAufenthaltZusatz;
        private KiSS4.Gui.KissButtonEdit edtInstitutionLookup;
        private KiSS4.Gui.KissTextEdit edtName;
        private KiSS4.Gui.KissTextEdit edtNummerWohnsitz;
        private KiSS4.Common.KissPLZOrt edtPLZAufenthalt;
        private KiSS4.Common.KissPLZOrt edtPLZWohnsitz;
        private KiSS4.Gui.KissTextEdit edtVorname;
        private KiSS4.Gui.KissLookUpEdit edtWohnsituationsCode;
        private KiSS4.Gui.KissDateEdit edtWohnsitzBis;
        private KiSS4.Gui.KissTextEdit edtWohnsitzPostfach;
        private KiSS4.Gui.KissTextEdit edtWohnsitzStrasse;
        private KiSS4.Gui.KissDateEdit edtWohnsitzVon;
        private KiSS4.Gui.KissTextEdit edtWohnsitzZusatz;
        private KiSS4.Gui.KissLookUpEdit edtWohnungsgroesseCode;
        private KiSS4.Gui.KissGrid grdBaAufenthaltAdresse;
        private KiSS4.Gui.KissGrid grdBaWohnsitzAdresse;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBaAufenthaltAdresse;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBaWohnsitzAdresse;
        private KiSS4.Gui.KissLabel lblAufenthaltAdresstyp;
        private KiSS4.Gui.KissLabel lblAufenthaltBezirk;
        private KiSS4.Gui.KissLabel lblAufenthaltDatumBis;
        private KiSS4.Gui.KissLabel lblAufenthaltDatumVon;
        private KiSS4.Gui.KissLabel lblAufenthaltInstitution;
        private KiSS4.Gui.KissLabel lblAufenthaltLand;
        private KiSS4.Gui.KissLabel lblAufenthaltPLZOrtKt;
        private KiSS4.Gui.KissLabel lblAufenthaltPostfach;
        private KiSS4.Gui.KissLabel lblAufenthaltStrasseHausNr;
        private KiSS4.Gui.KissLabel lblAufenthaltZuhandenVon;
        private KiSS4.Gui.KissLabel lblAufenthaltZusatz;
        private KiSS4.Gui.KissLabel lblTitelOtherAddress;
        private KiSS4.Gui.KissLabel lblTitelWohnsitz;
        private KiSS4.Gui.KissLabel lblWohnsitzAdressTyp;
        private KiSS4.Gui.KissLabel lblWohnsitzBezirk;
        private KiSS4.Gui.KissLabel lblWohnsitzDatumBis;
        private KiSS4.Gui.KissLabel lblWohnsitzDatumVon;
        private KiSS4.Gui.KissLabel lblWohnsitzLand;
        private KiSS4.Gui.KissLabel lblWohnsitzNameVorname;
        private KiSS4.Gui.KissLabel lblWohnsitzPLZOrtKt;
        private KiSS4.Gui.KissLabel lblWohnsitzPostfach;
        private KiSS4.Gui.KissLabel lblWohnsitzStrasseNr;
        private KiSS4.Gui.KissLabel lblWohnsitzWohnstatus;
        private KiSS4.Gui.KissLabel lblWohnsitzWohnungsgroesse;
        private KiSS4.Gui.KissLabel lblWohnsitzZusatz;
        private System.Windows.Forms.Panel panDetailsOtherAddress;
        private System.Windows.Forms.Panel panDetailsWohnsitz;
        private System.Windows.Forms.TableLayoutPanel panTblWohnsitzNameVorname;
        private System.Windows.Forms.TableLayoutPanel pnlTableLayout;
        private KiSS4.DB.SqlQuery qryBaPerson;
        private KiSS4.DB.SqlQuery qryBaWeitereAdressen;
        private KiSS4.DB.SqlQuery qryBaWohnsitzAdresse;
    }
}
