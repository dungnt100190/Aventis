namespace KiSS4.Basis
{
    partial class CtlBaZahlungsweg
    {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBaZahlungsweg));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdBaZahlungsweg = new KiSS4.Gui.KissGrid();
            this.qryBaZahlungsweg = new KiSS4.DB.SqlQuery(this.components);
            this.grvZahlungsweg = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBankPost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKontoNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPCKonto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGueltigAb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGueltigBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtEinzahlungsschein = new KiSS4.Gui.KissLookUpEdit();
            this.edtBankPost = new KiSS4.Gui.KissButtonEdit();
            this.edtBankkontoNr = new KiSS4.Gui.KissTextEdit();
            this.edtIBAN = new KiSS4.Gui.KissTextEdit();
            this.edtPostkontoNr = new KiSS4.Gui.KissTextEdit();
            this.edtReferenz = new KiSS4.Common.KissReferenzNrEdit(this.components);
            this.edtName = new KiSS4.Gui.KissTextEdit();
            this.edtWohnsitzZusatz = new KiSS4.Gui.KissTextEdit();
            this.edtWohnsitzStrasse = new KiSS4.Gui.KissTextEdit();
            this.edtNummerWohnsitz = new KiSS4.Gui.KissTextEdit();
            this.edtIBANErrorMsg = new KiSS4.Gui.KissMemoEdit();
            this.edtBaZahlwegModulStdCodes = new KiSS4.Gui.KissCheckedLookupEdit();
            this.btnGenerateIBAN = new KiSS4.Gui.KissButton();
            this.edtClearingNummer = new KiSS4.Gui.KissTextEdit();
            this.edtBankPC = new KiSS4.Gui.KissTextEdit();
            this.lblEinzahlungsschein = new KiSS4.Gui.KissLabel();
            this.lblBankPost = new KiSS4.Gui.KissLabel();
            this.lblBankkontoNr = new KiSS4.Gui.KissLabel();
            this.lblPostKonto = new KiSS4.Gui.KissLabel();
            this.lblIBAN = new KiSS4.Gui.KissLabel();
            this.lblBCN = new KiSS4.Gui.KissLabel();
            this.lblRefNr = new KiSS4.Gui.KissLabel();
            this.lblDatumVon = new KiSS4.Gui.KissLabel();
            this.lblGueltigBis = new KiSS4.Gui.KissLabel();
            this.lblName = new KiSS4.Gui.KissLabel();
            this.lblZusatz = new KiSS4.Gui.KissLabel();
            this.lblStrasseNr = new KiSS4.Gui.KissLabel();
            this.lblPLZOrt = new KiSS4.Gui.KissLabel();
            this.lblEinzahlungFuer = new KiSS4.Gui.KissLabel();
            this.lblStandardZahlwegFuer = new KiSS4.Gui.KissLabel();
            this.edtWohnsitzPLZOrt = new KiSS4.Common.KissPLZOrt();
            this.panZahlwegData = new System.Windows.Forms.Panel();
            this.panTblDetails = new System.Windows.Forms.TableLayoutPanel();
            this.panAddressAndMore = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaZahlungsweg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaZahlungsweg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZahlungsweg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinzahlungsschein)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinzahlungsschein.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBankPost.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBankkontoNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIBAN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPostkontoNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtReferenz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitzZusatz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitzStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNummerWohnsitz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIBANErrorMsg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaZahlwegModulStdCodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtClearingNummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBankPC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinzahlungsschein)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBankPost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBankkontoNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPostKonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIBAN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBCN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRefNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGueltigBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStrasseNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPLZOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinzahlungFuer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStandardZahlwegFuer)).BeginInit();
            this.panZahlwegData.SuspendLayout();
            this.panTblDetails.SuspendLayout();
            this.panAddressAndMore.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdBaZahlungsweg
            // 
            this.grdBaZahlungsweg.DataSource = this.qryBaZahlungsweg;
            this.grdBaZahlungsweg.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdBaZahlungsweg.EmbeddedNavigator.Name = "kissGrid6.EmbeddedNavigator";
            this.grdBaZahlungsweg.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBaZahlungsweg.Location = new System.Drawing.Point(0, 0);
            this.grdBaZahlungsweg.MainView = this.grvZahlungsweg;
            this.grdBaZahlungsweg.Name = "grdBaZahlungsweg";
            this.grdBaZahlungsweg.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1});
            this.grdBaZahlungsweg.Size = new System.Drawing.Size(846, 175);
            this.grdBaZahlungsweg.TabIndex = 0;
            this.grdBaZahlungsweg.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvZahlungsweg});
            // 
            // qryBaZahlungsweg
            // 
            this.qryBaZahlungsweg.CanDelete = true;
            this.qryBaZahlungsweg.CanInsert = true;
            this.qryBaZahlungsweg.CanUpdate = true;
            this.qryBaZahlungsweg.HostControl = this;
            this.qryBaZahlungsweg.TableName = "BaZahlungsweg";
            this.qryBaZahlungsweg.AfterFill += new System.EventHandler(this.qryBaZahlungsweg_AfterFill);
            this.qryBaZahlungsweg.AfterInsert += new System.EventHandler(this.qryBaZahlungsweg_AfterInsert);
            this.qryBaZahlungsweg.BeforePost += new System.EventHandler(this.qryBaZahlungsweg_BeforePost);
            this.qryBaZahlungsweg.PositionChanged += new System.EventHandler(this.qryBaZahlungsweg_PositionChanged);
            // 
            // grvZahlungsweg
            // 
            this.grvZahlungsweg.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvZahlungsweg.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungsweg.Appearance.Empty.Options.UseBackColor = true;
            this.grvZahlungsweg.Appearance.Empty.Options.UseFont = true;
            this.grvZahlungsweg.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungsweg.Appearance.EvenRow.Options.UseFont = true;
            this.grvZahlungsweg.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvZahlungsweg.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungsweg.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvZahlungsweg.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvZahlungsweg.Appearance.FocusedCell.Options.UseFont = true;
            this.grvZahlungsweg.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvZahlungsweg.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvZahlungsweg.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungsweg.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvZahlungsweg.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvZahlungsweg.Appearance.FocusedRow.Options.UseFont = true;
            this.grvZahlungsweg.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvZahlungsweg.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZahlungsweg.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvZahlungsweg.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZahlungsweg.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvZahlungsweg.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZahlungsweg.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvZahlungsweg.Appearance.GroupRow.Options.UseFont = true;
            this.grvZahlungsweg.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvZahlungsweg.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvZahlungsweg.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvZahlungsweg.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvZahlungsweg.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvZahlungsweg.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvZahlungsweg.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvZahlungsweg.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvZahlungsweg.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungsweg.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZahlungsweg.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvZahlungsweg.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvZahlungsweg.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvZahlungsweg.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvZahlungsweg.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvZahlungsweg.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungsweg.Appearance.OddRow.Options.UseFont = true;
            this.grvZahlungsweg.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvZahlungsweg.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungsweg.Appearance.Row.Options.UseBackColor = true;
            this.grvZahlungsweg.Appearance.Row.Options.UseFont = true;
            this.grvZahlungsweg.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungsweg.Appearance.SelectedRow.Options.UseFont = true;
            this.grvZahlungsweg.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvZahlungsweg.Appearance.VertLine.Options.UseBackColor = true;
            this.grvZahlungsweg.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvZahlungsweg.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEZ,
            this.colBankPost,
            this.colKontoNr,
            this.colPCKonto,
            this.colGueltigAb,
            this.colGueltigBis});
            this.grvZahlungsweg.CustomizationFormBounds = new System.Drawing.Rectangle(816, 459, 208, 175);
            this.grvZahlungsweg.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvZahlungsweg.GridControl = this.grdBaZahlungsweg;
            this.grvZahlungsweg.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvZahlungsweg.Name = "grvZahlungsweg";
            this.grvZahlungsweg.OptionsBehavior.Editable = false;
            this.grvZahlungsweg.OptionsCustomization.AllowFilter = false;
            this.grvZahlungsweg.OptionsFilter.AllowFilterEditor = false;
            this.grvZahlungsweg.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvZahlungsweg.OptionsMenu.EnableColumnMenu = false;
            this.grvZahlungsweg.OptionsNavigation.AutoFocusNewRow = true;
            this.grvZahlungsweg.OptionsNavigation.UseTabKey = false;
            this.grvZahlungsweg.OptionsView.ColumnAutoWidth = false;
            this.grvZahlungsweg.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvZahlungsweg.OptionsView.ShowGroupPanel = false;
            this.grvZahlungsweg.OptionsView.ShowIndicator = false;
            // 
            // colEZ
            // 
            this.colEZ.Caption = "EZ";
            this.colEZ.FieldName = "EinzahlungsscheinCode";
            this.colEZ.Name = "colEZ";
            this.colEZ.Visible = true;
            this.colEZ.VisibleIndex = 2;
            this.colEZ.Width = 136;
            // 
            // colBankPost
            // 
            this.colBankPost.Caption = "Bank / Post";
            this.colBankPost.FieldName = "Bankname";
            this.colBankPost.Name = "colBankPost";
            this.colBankPost.Visible = true;
            this.colBankPost.VisibleIndex = 3;
            this.colBankPost.Width = 187;
            // 
            // colKontoNr
            // 
            this.colKontoNr.Caption = "Bank Konto-Nr.";
            this.colKontoNr.FieldName = "BankKontoNummer";
            this.colKontoNr.Name = "colKontoNr";
            this.colKontoNr.Visible = true;
            this.colKontoNr.VisibleIndex = 4;
            this.colKontoNr.Width = 111;
            // 
            // colPCKonto
            // 
            this.colPCKonto.Caption = "Postkonto-Nr.";
            this.colPCKonto.FieldName = "PcNr";
            this.colPCKonto.Name = "colPCKonto";
            this.colPCKonto.Visible = true;
            this.colPCKonto.VisibleIndex = 5;
            this.colPCKonto.Width = 95;
            // 
            // colGueltigAb
            // 
            this.colGueltigAb.Caption = "Von";
            this.colGueltigAb.FieldName = "DatumVon";
            this.colGueltigAb.Name = "colGueltigAb";
            this.colGueltigAb.Visible = true;
            this.colGueltigAb.VisibleIndex = 0;
            // 
            // colGueltigBis
            // 
            this.colGueltigBis.Caption = "bis";
            this.colGueltigBis.FieldName = "DatumBis";
            this.colGueltigBis.Name = "colGueltigBis";
            this.colGueltigBis.Visible = true;
            this.colGueltigBis.VisibleIndex = 1;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.repositoryItemLookUpEdit1.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.repositoryItemLookUpEdit1.AppearanceDropDown.Options.UseBackColor = true;
            this.repositoryItemLookUpEdit1.AppearanceDropDown.Options.UseFont = true;
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.NullText = "";
            this.repositoryItemLookUpEdit1.ShowFooter = false;
            this.repositoryItemLookUpEdit1.ShowHeader = false;
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.DataMember = "DatumVon";
            this.edtDatumVon.DataSource = this.qryBaZahlungsweg;
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(118, 9);
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
            this.edtDatumVon.Size = new System.Drawing.Size(90, 24);
            this.edtDatumVon.TabIndex = 1;
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.DataMember = "DatumBis";
            this.edtDatumBis.DataSource = this.qryBaZahlungsweg;
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(244, 9);
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
            this.edtDatumBis.Size = new System.Drawing.Size(90, 24);
            this.edtDatumBis.TabIndex = 3;
            // 
            // edtEinzahlungsschein
            // 
            this.edtEinzahlungsschein.AllowNull = false;
            this.edtEinzahlungsschein.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtEinzahlungsschein.DataMember = "EinzahlungsscheinCode";
            this.edtEinzahlungsschein.DataSource = this.qryBaZahlungsweg;
            this.edtEinzahlungsschein.Location = new System.Drawing.Point(118, 39);
            this.edtEinzahlungsschein.LOVName = "BgEinzahlungsschein";
            this.edtEinzahlungsschein.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.edtEinzahlungsschein.Name = "edtEinzahlungsschein";
            this.edtEinzahlungsschein.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEinzahlungsschein.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinzahlungsschein.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinzahlungsschein.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinzahlungsschein.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinzahlungsschein.Properties.Appearance.Options.UseFont = true;
            this.edtEinzahlungsschein.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtEinzahlungsschein.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinzahlungsschein.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtEinzahlungsschein.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtEinzahlungsschein.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtEinzahlungsschein.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtEinzahlungsschein.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEinzahlungsschein.Properties.Name = "kissLookUpEdit6.Properties";
            this.edtEinzahlungsschein.Properties.NullText = "";
            this.edtEinzahlungsschein.Properties.ShowFooter = false;
            this.edtEinzahlungsschein.Properties.ShowHeader = false;
            this.edtEinzahlungsschein.Size = new System.Drawing.Size(290, 24);
            this.edtEinzahlungsschein.TabIndex = 5;
            this.edtEinzahlungsschein.EnterKey += new System.Windows.Forms.KeyEventHandler(this.edtEinzahlungsschein_EnterKey);
            this.edtEinzahlungsschein.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.edtEinzahlungsschein_CloseUp);
            this.edtEinzahlungsschein.EditValueChanged += new System.EventHandler(this.edtEinzahlungsschein_EditValueChanged);
            // 
            // edtBankPost
            // 
            this.edtBankPost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBankPost.DataMember = "Bankname";
            this.edtBankPost.DataSource = this.qryBaZahlungsweg;
            this.edtBankPost.Location = new System.Drawing.Point(118, 69);
            this.edtBankPost.Name = "edtBankPost";
            this.edtBankPost.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBankPost.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBankPost.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBankPost.Properties.Appearance.Options.UseBackColor = true;
            this.edtBankPost.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBankPost.Properties.Appearance.Options.UseFont = true;
            this.edtBankPost.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtBankPost.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtBankPost.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBankPost.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtBankPost.Size = new System.Drawing.Size(290, 24);
            this.edtBankPost.TabIndex = 7;
            this.edtBankPost.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtBankPost_UserModifiedFld);
            // 
            // edtBankkontoNr
            // 
            this.edtBankkontoNr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBankkontoNr.DataMember = "BankKontoNummer";
            this.edtBankkontoNr.DataSource = this.qryBaZahlungsweg;
            this.edtBankkontoNr.Location = new System.Drawing.Point(118, 99);
            this.edtBankkontoNr.Name = "edtBankkontoNr";
            this.edtBankkontoNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBankkontoNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBankkontoNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBankkontoNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtBankkontoNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBankkontoNr.Properties.Appearance.Options.UseFont = true;
            this.edtBankkontoNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBankkontoNr.Properties.MaxLength = 50;
            this.edtBankkontoNr.Properties.Name = "kissTextEdit13.Properties";
            this.edtBankkontoNr.Size = new System.Drawing.Size(203, 24);
            this.edtBankkontoNr.TabIndex = 9;
            this.edtBankkontoNr.EditValueChanged += new System.EventHandler(this.edtBankkontoNr_EditValueChanged);
            // 
            // edtIBAN
            // 
            this.edtIBAN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtIBAN.DataMember = "IBANNummer";
            this.edtIBAN.DataSource = this.qryBaZahlungsweg;
            this.edtIBAN.Location = new System.Drawing.Point(118, 129);
            this.edtIBAN.Name = "edtIBAN";
            this.edtIBAN.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtIBAN.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIBAN.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIBAN.Properties.Appearance.Options.UseBackColor = true;
            this.edtIBAN.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIBAN.Properties.Appearance.Options.UseFont = true;
            this.edtIBAN.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtIBAN.Properties.MaxLength = 50;
            this.edtIBAN.Properties.Name = "kissTextEdit16.Properties";
            this.edtIBAN.Size = new System.Drawing.Size(290, 24);
            this.edtIBAN.TabIndex = 13;
            // 
            // edtPostkontoNr
            // 
            this.edtPostkontoNr.DataMember = "PcNr";
            this.edtPostkontoNr.DataSource = this.qryBaZahlungsweg;
            this.edtPostkontoNr.Location = new System.Drawing.Point(118, 159);
            this.edtPostkontoNr.Name = "edtPostkontoNr";
            this.edtPostkontoNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPostkontoNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPostkontoNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPostkontoNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtPostkontoNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPostkontoNr.Properties.Appearance.Options.UseFont = true;
            this.edtPostkontoNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPostkontoNr.Properties.MaxLength = 20;
            this.edtPostkontoNr.Properties.Name = "kissTextEdit14.Properties";
            this.edtPostkontoNr.Size = new System.Drawing.Size(194, 24);
            this.edtPostkontoNr.TabIndex = 16;
            this.edtPostkontoNr.EditValueChanged += new System.EventHandler(this.edtPostkontoNr_EditValueChanged);
            // 
            // edtReferenz
            // 
            this.edtReferenz.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtReferenz.DataMember = "ReferenzNummer";
            this.edtReferenz.DataSource = this.qryBaZahlungsweg;
            this.edtReferenz.Location = new System.Drawing.Point(118, 189);
            this.edtReferenz.Name = "edtReferenz";
            this.edtReferenz.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtReferenz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtReferenz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtReferenz.Properties.Appearance.Options.UseBackColor = true;
            this.edtReferenz.Properties.Appearance.Options.UseBorderColor = true;
            this.edtReferenz.Properties.Appearance.Options.UseFont = true;
            this.edtReferenz.Properties.Appearance.Options.UseTextOptions = true;
            this.edtReferenz.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.edtReferenz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtReferenz.Size = new System.Drawing.Size(290, 24);
            this.edtReferenz.TabIndex = 0;
            // 
            // edtName
            // 
            this.edtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtName.DataMember = "AdresseName";
            this.edtName.DataSource = this.qryBaZahlungsweg;
            this.edtName.Location = new System.Drawing.Point(83, 39);
            this.edtName.Name = "edtName";
            this.edtName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtName.Properties.Appearance.Options.UseBackColor = true;
            this.edtName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtName.Properties.Appearance.Options.UseFont = true;
            this.edtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtName.Properties.Name = "kissTextEdit11.Properties";
            this.edtName.Size = new System.Drawing.Size(325, 24);
            this.edtName.TabIndex = 3;
            this.edtName.EditValueChanged += new System.EventHandler(this.edtName_EditValueChanged);
            // 
            // edtWohnsitzZusatz
            // 
            this.edtWohnsitzZusatz.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtWohnsitzZusatz.DataMember = "AdresseName2";
            this.edtWohnsitzZusatz.DataSource = this.qryBaZahlungsweg;
            this.edtWohnsitzZusatz.Location = new System.Drawing.Point(83, 62);
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
            this.edtWohnsitzZusatz.Size = new System.Drawing.Size(325, 24);
            this.edtWohnsitzZusatz.TabIndex = 5;
            this.edtWohnsitzZusatz.EditValueChanged += new System.EventHandler(this.edtWohnsitzZusatz_EditValueChanged);
            // 
            // edtWohnsitzStrasse
            // 
            this.edtWohnsitzStrasse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtWohnsitzStrasse.DataMember = "AdresseStrasse";
            this.edtWohnsitzStrasse.DataSource = this.qryBaZahlungsweg;
            this.edtWohnsitzStrasse.Location = new System.Drawing.Point(83, 85);
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
            this.edtWohnsitzStrasse.Size = new System.Drawing.Size(277, 24);
            this.edtWohnsitzStrasse.TabIndex = 7;
            this.edtWohnsitzStrasse.EditValueChanged += new System.EventHandler(this.edtWohnsitzStrasse_EditValueChanged);
            // 
            // edtNummerWohnsitz
            // 
            this.edtNummerWohnsitz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtNummerWohnsitz.DataMember = "AdresseHausNr";
            this.edtNummerWohnsitz.DataSource = this.qryBaZahlungsweg;
            this.edtNummerWohnsitz.Location = new System.Drawing.Point(359, 85);
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
            this.edtNummerWohnsitz.TabIndex = 8;
            // 
            // edtIBANErrorMsg
            // 
            this.edtIBANErrorMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.edtIBANErrorMsg.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtIBANErrorMsg.EditValue = "";
            this.edtIBANErrorMsg.Location = new System.Drawing.Point(0, 175);
            this.edtIBANErrorMsg.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.edtIBANErrorMsg.Name = "edtIBANErrorMsg";
            this.edtIBANErrorMsg.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtIBANErrorMsg.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIBANErrorMsg.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIBANErrorMsg.Properties.Appearance.Options.UseBackColor = true;
            this.edtIBANErrorMsg.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIBANErrorMsg.Properties.Appearance.Options.UseFont = true;
            this.edtIBANErrorMsg.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtIBANErrorMsg.Properties.ReadOnly = true;
            this.edtIBANErrorMsg.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.edtIBANErrorMsg.Size = new System.Drawing.Size(846, 24);
            this.edtIBANErrorMsg.TabIndex = 1;
            this.edtIBANErrorMsg.TabStop = false;
            this.edtIBANErrorMsg.Visible = false;
            // 
            // edtBaZahlwegModulStdCodes
            // 
            this.edtBaZahlwegModulStdCodes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBaZahlwegModulStdCodes.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.edtBaZahlwegModulStdCodes.Appearance.Options.UseBackColor = true;
            this.edtBaZahlwegModulStdCodes.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtBaZahlwegModulStdCodes.CheckOnClick = true;
            this.edtBaZahlwegModulStdCodes.DataMember = "BaZahlwegModulStdCodes";
            this.edtBaZahlwegModulStdCodes.DataSource = this.qryBaZahlungsweg;
            this.edtBaZahlwegModulStdCodes.Location = new System.Drawing.Point(83, 160);
            this.edtBaZahlwegModulStdCodes.LOVName = "BaZahlwegModulStd";
            this.edtBaZahlwegModulStdCodes.Name = "edtBaZahlwegModulStdCodes";
            this.edtBaZahlwegModulStdCodes.Size = new System.Drawing.Size(325, 53);
            this.edtBaZahlwegModulStdCodes.TabIndex = 12;
            // 
            // btnGenerateIBAN
            // 
            this.btnGenerateIBAN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateIBAN.Enabled = false;
            this.btnGenerateIBAN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateIBAN.Location = new System.Drawing.Point(285, 9);
            this.btnGenerateIBAN.Name = "btnGenerateIBAN";
            this.btnGenerateIBAN.Size = new System.Drawing.Size(123, 24);
            this.btnGenerateIBAN.TabIndex = 0;
            this.btnGenerateIBAN.Text = "IBAN generieren";
            this.btnGenerateIBAN.UseCompatibleTextRendering = true;
            this.btnGenerateIBAN.UseVisualStyleBackColor = false;
            this.btnGenerateIBAN.Visible = false;
            this.btnGenerateIBAN.Click += new System.EventHandler(this.btnGenerateIBAN_Click);
            // 
            // edtClearingNummer
            // 
            this.edtClearingNummer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtClearingNummer.DataMember = "ClearingNr";
            this.edtClearingNummer.DataSource = this.qryBaZahlungsweg;
            this.edtClearingNummer.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtClearingNummer.Location = new System.Drawing.Point(356, 99);
            this.edtClearingNummer.Name = "edtClearingNummer";
            this.edtClearingNummer.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtClearingNummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtClearingNummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtClearingNummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtClearingNummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtClearingNummer.Properties.Appearance.Options.UseFont = true;
            this.edtClearingNummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtClearingNummer.Properties.ReadOnly = true;
            this.edtClearingNummer.Size = new System.Drawing.Size(52, 24);
            this.edtClearingNummer.TabIndex = 11;
            this.edtClearingNummer.TabStop = false;
            // 
            // edtBankPC
            // 
            this.edtBankPC.DataMember = "BankPC";
            this.edtBankPC.DataSource = this.qryBaZahlungsweg;
            this.edtBankPC.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBankPC.Location = new System.Drawing.Point(118, 159);
            this.edtBankPC.Name = "edtBankPC";
            this.edtBankPC.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBankPC.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBankPC.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBankPC.Properties.Appearance.Options.UseBackColor = true;
            this.edtBankPC.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBankPC.Properties.Appearance.Options.UseFont = true;
            this.edtBankPC.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBankPC.Properties.ReadOnly = true;
            this.edtBankPC.Size = new System.Drawing.Size(194, 24);
            this.edtBankPC.TabIndex = 17;
            this.edtBankPC.TabStop = false;
            this.edtBankPC.Visible = false;
            // 
            // lblEinzahlungsschein
            // 
            this.lblEinzahlungsschein.Location = new System.Drawing.Point(9, 39);
            this.lblEinzahlungsschein.Name = "lblEinzahlungsschein";
            this.lblEinzahlungsschein.Size = new System.Drawing.Size(103, 24);
            this.lblEinzahlungsschein.TabIndex = 4;
            this.lblEinzahlungsschein.Text = "Zahlwegtyp";
            this.lblEinzahlungsschein.UseCompatibleTextRendering = true;
            // 
            // lblBankPost
            // 
            this.lblBankPost.Location = new System.Drawing.Point(9, 69);
            this.lblBankPost.Name = "lblBankPost";
            this.lblBankPost.Size = new System.Drawing.Size(103, 24);
            this.lblBankPost.TabIndex = 6;
            this.lblBankPost.Text = "Bank";
            this.lblBankPost.UseCompatibleTextRendering = true;
            // 
            // lblBankkontoNr
            // 
            this.lblBankkontoNr.Location = new System.Drawing.Point(9, 99);
            this.lblBankkontoNr.Name = "lblBankkontoNr";
            this.lblBankkontoNr.Size = new System.Drawing.Size(103, 24);
            this.lblBankkontoNr.TabIndex = 8;
            this.lblBankkontoNr.Text = "Bankkonto-Nr.";
            this.lblBankkontoNr.UseCompatibleTextRendering = true;
            // 
            // lblPostKonto
            // 
            this.lblPostKonto.Location = new System.Drawing.Point(9, 159);
            this.lblPostKonto.Name = "lblPostKonto";
            this.lblPostKonto.Size = new System.Drawing.Size(103, 24);
            this.lblPostKonto.TabIndex = 14;
            this.lblPostKonto.Text = "Postkonto-Nr.";
            this.lblPostKonto.UseCompatibleTextRendering = true;
            // 
            // lblIBAN
            // 
            this.lblIBAN.Location = new System.Drawing.Point(9, 129);
            this.lblIBAN.Name = "lblIBAN";
            this.lblIBAN.Size = new System.Drawing.Size(103, 24);
            this.lblIBAN.TabIndex = 12;
            this.lblIBAN.Text = "IBAN";
            this.lblIBAN.UseCompatibleTextRendering = true;
            // 
            // lblBCN
            // 
            this.lblBCN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBCN.Location = new System.Drawing.Point(327, 99);
            this.lblBCN.Name = "lblBCN";
            this.lblBCN.Size = new System.Drawing.Size(23, 24);
            this.lblBCN.TabIndex = 10;
            this.lblBCN.Text = "BC";
            this.lblBCN.UseCompatibleTextRendering = true;
            // 
            // lblRefNr
            // 
            this.lblRefNr.Location = new System.Drawing.Point(9, 189);
            this.lblRefNr.Name = "lblRefNr";
            this.lblRefNr.Size = new System.Drawing.Size(103, 24);
            this.lblRefNr.TabIndex = 18;
            this.lblRefNr.Text = "Referenz-Nr. ";
            this.lblRefNr.UseCompatibleTextRendering = true;
            // 
            // lblDatumVon
            // 
            this.lblDatumVon.Location = new System.Drawing.Point(9, 9);
            this.lblDatumVon.Name = "lblDatumVon";
            this.lblDatumVon.Size = new System.Drawing.Size(103, 24);
            this.lblDatumVon.TabIndex = 0;
            this.lblDatumVon.Text = "Gültig von";
            this.lblDatumVon.UseCompatibleTextRendering = true;
            // 
            // lblGueltigBis
            // 
            this.lblGueltigBis.Location = new System.Drawing.Point(214, 9);
            this.lblGueltigBis.Name = "lblGueltigBis";
            this.lblGueltigBis.Size = new System.Drawing.Size(27, 24);
            this.lblGueltigBis.TabIndex = 2;
            this.lblGueltigBis.Text = "bis";
            this.lblGueltigBis.UseCompatibleTextRendering = true;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(9, 39);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(68, 24);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name";
            this.lblName.UseCompatibleTextRendering = true;
            this.lblName.Click += new System.EventHandler(this.lblName_Click);
            // 
            // lblZusatz
            // 
            this.lblZusatz.Location = new System.Drawing.Point(9, 61);
            this.lblZusatz.Name = "lblZusatz";
            this.lblZusatz.Size = new System.Drawing.Size(68, 24);
            this.lblZusatz.TabIndex = 4;
            this.lblZusatz.Text = "Zusatz";
            this.lblZusatz.UseCompatibleTextRendering = true;
            this.lblZusatz.Click += new System.EventHandler(this.lblZusatz_Click);
            // 
            // lblStrasseNr
            // 
            this.lblStrasseNr.Location = new System.Drawing.Point(9, 85);
            this.lblStrasseNr.Name = "lblStrasseNr";
            this.lblStrasseNr.Size = new System.Drawing.Size(68, 24);
            this.lblStrasseNr.TabIndex = 6;
            this.lblStrasseNr.Text = "Strasse / Nr";
            this.lblStrasseNr.UseCompatibleTextRendering = true;
            this.lblStrasseNr.Click += new System.EventHandler(this.lblStrasseNr_Click);
            // 
            // lblPLZOrt
            // 
            this.lblPLZOrt.Location = new System.Drawing.Point(9, 108);
            this.lblPLZOrt.Name = "lblPLZOrt";
            this.lblPLZOrt.Size = new System.Drawing.Size(68, 24);
            this.lblPLZOrt.TabIndex = 9;
            this.lblPLZOrt.Text = "PLZ / Ort";
            this.lblPLZOrt.UseCompatibleTextRendering = true;
            this.lblPLZOrt.Click += new System.EventHandler(this.lblPLZOrt_Click);
            // 
            // lblEinzahlungFuer
            // 
            this.lblEinzahlungFuer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEinzahlungFuer.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblEinzahlungFuer.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblEinzahlungFuer.Location = new System.Drawing.Point(83, 20);
            this.lblEinzahlungFuer.Name = "lblEinzahlungFuer";
            this.lblEinzahlungFuer.Size = new System.Drawing.Size(196, 16);
            this.lblEinzahlungFuer.TabIndex = 1;
            this.lblEinzahlungFuer.Text = "Einzahlung für";
            this.lblEinzahlungFuer.UseCompatibleTextRendering = true;
            this.lblEinzahlungFuer.Click += new System.EventHandler(this.lblEinzahlungFuer_Click);
            // 
            // lblStandardZahlwegFuer
            // 
            this.lblStandardZahlwegFuer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStandardZahlwegFuer.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblStandardZahlwegFuer.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblStandardZahlwegFuer.Location = new System.Drawing.Point(83, 141);
            this.lblStandardZahlwegFuer.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lblStandardZahlwegFuer.Name = "lblStandardZahlwegFuer";
            this.lblStandardZahlwegFuer.Size = new System.Drawing.Size(325, 16);
            this.lblStandardZahlwegFuer.TabIndex = 11;
            this.lblStandardZahlwegFuer.Text = "Standard-Zahlweg für";
            this.lblStandardZahlwegFuer.UseCompatibleTextRendering = true;
            this.lblStandardZahlwegFuer.Click += new System.EventHandler(this.lblStandardZahlwegFuer_Click);
            // 
            // edtWohnsitzPLZOrt
            // 
            this.edtWohnsitzPLZOrt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtWohnsitzPLZOrt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtWohnsitzPLZOrt.DataMember = "AdresseOrtCode";
            this.edtWohnsitzPLZOrt.DataMemberBaGemeindeID = null;
            this.edtWohnsitzPLZOrt.DataMemberOrt = "AdresseOrt";
            this.edtWohnsitzPLZOrt.DataMemberPLZ = "AdressePLZ";
            this.edtWohnsitzPLZOrt.DataSource = this.qryBaZahlungsweg;
            this.edtWohnsitzPLZOrt.Location = new System.Drawing.Point(83, 108);
            this.edtWohnsitzPLZOrt.Name = "edtWohnsitzPLZOrt";
            this.edtWohnsitzPLZOrt.ShowKanton = false;
            this.edtWohnsitzPLZOrt.ShowLand = false;
            this.edtWohnsitzPLZOrt.Size = new System.Drawing.Size(325, 24);
            this.edtWohnsitzPLZOrt.TabIndex = 10;
            this.edtWohnsitzPLZOrt.Load += new System.EventHandler(this.edtWohnsitzPLZOrt_Load);
            // 
            // panZahlwegData
            // 
            this.panZahlwegData.Controls.Add(this.lblDatumVon);
            this.panZahlwegData.Controls.Add(this.edtDatumVon);
            this.panZahlwegData.Controls.Add(this.edtDatumBis);
            this.panZahlwegData.Controls.Add(this.edtEinzahlungsschein);
            this.panZahlwegData.Controls.Add(this.edtBankPost);
            this.panZahlwegData.Controls.Add(this.edtBankkontoNr);
            this.panZahlwegData.Controls.Add(this.edtIBAN);
            this.panZahlwegData.Controls.Add(this.edtPostkontoNr);
            this.panZahlwegData.Controls.Add(this.lblGueltigBis);
            this.panZahlwegData.Controls.Add(this.edtReferenz);
            this.panZahlwegData.Controls.Add(this.edtClearingNummer);
            this.panZahlwegData.Controls.Add(this.lblRefNr);
            this.panZahlwegData.Controls.Add(this.edtBankPC);
            this.panZahlwegData.Controls.Add(this.lblBCN);
            this.panZahlwegData.Controls.Add(this.lblEinzahlungsschein);
            this.panZahlwegData.Controls.Add(this.lblIBAN);
            this.panZahlwegData.Controls.Add(this.lblBankPost);
            this.panZahlwegData.Controls.Add(this.lblPostKonto);
            this.panZahlwegData.Controls.Add(this.lblBankkontoNr);
            this.panZahlwegData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panZahlwegData.Location = new System.Drawing.Point(3, 3);
            this.panZahlwegData.Name = "panZahlwegData";
            this.panZahlwegData.Size = new System.Drawing.Size(417, 221);
            this.panZahlwegData.TabIndex = 0;
            // 
            // panTblDetails
            // 
            this.panTblDetails.ColumnCount = 2;
            this.panTblDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panTblDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panTblDetails.Controls.Add(this.panZahlwegData, 0, 0);
            this.panTblDetails.Controls.Add(this.panAddressAndMore, 1, 0);
            this.panTblDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panTblDetails.Location = new System.Drawing.Point(0, 199);
            this.panTblDetails.Name = "panTblDetails";
            this.panTblDetails.RowCount = 1;
            this.panTblDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panTblDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panTblDetails.Size = new System.Drawing.Size(846, 227);
            this.panTblDetails.TabIndex = 2;
            // 
            // panAddressAndMore
            // 
            this.panAddressAndMore.Controls.Add(this.btnGenerateIBAN);
            this.panAddressAndMore.Controls.Add(this.edtBaZahlwegModulStdCodes);
            this.panAddressAndMore.Controls.Add(this.edtWohnsitzPLZOrt);
            this.panAddressAndMore.Controls.Add(this.edtName);
            this.panAddressAndMore.Controls.Add(this.lblStandardZahlwegFuer);
            this.panAddressAndMore.Controls.Add(this.edtWohnsitzZusatz);
            this.panAddressAndMore.Controls.Add(this.lblEinzahlungFuer);
            this.panAddressAndMore.Controls.Add(this.edtWohnsitzStrasse);
            this.panAddressAndMore.Controls.Add(this.lblPLZOrt);
            this.panAddressAndMore.Controls.Add(this.edtNummerWohnsitz);
            this.panAddressAndMore.Controls.Add(this.lblStrasseNr);
            this.panAddressAndMore.Controls.Add(this.lblName);
            this.panAddressAndMore.Controls.Add(this.lblZusatz);
            this.panAddressAndMore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panAddressAndMore.Location = new System.Drawing.Point(426, 3);
            this.panAddressAndMore.Name = "panAddressAndMore";
            this.panAddressAndMore.Size = new System.Drawing.Size(417, 221);
            this.panAddressAndMore.TabIndex = 1;
            // 
            // CtlBaZahlungsweg
            // 
            this.ActiveSQLQuery = this.qryBaZahlungsweg;
            this.Controls.Add(this.grdBaZahlungsweg);
            this.Controls.Add(this.edtIBANErrorMsg);
            this.Controls.Add(this.panTblDetails);
            this.Name = "CtlBaZahlungsweg";
            this.Size = new System.Drawing.Size(846, 426);
            ((System.ComponentModel.ISupportInitialize)(this.grdBaZahlungsweg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaZahlungsweg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZahlungsweg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinzahlungsschein.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinzahlungsschein)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBankPost.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBankkontoNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIBAN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPostkontoNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtReferenz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitzZusatz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitzStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNummerWohnsitz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIBANErrorMsg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaZahlwegModulStdCodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtClearingNummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBankPC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinzahlungsschein)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBankPost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBankkontoNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPostKonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIBAN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBCN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRefNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGueltigBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStrasseNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPLZOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinzahlungFuer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStandardZahlwegFuer)).EndInit();
            this.panZahlwegData.ResumeLayout(false);
            this.panTblDetails.ResumeLayout(false);
            this.panAddressAndMore.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public KiSS4.Gui.KissButtonEdit edtBankPost;
        public KiSS4.Gui.KissTextEdit edtBankkontoNr;
        public KiSS4.Gui.KissDateEdit edtDatumBis;
        public KiSS4.Gui.KissDateEdit edtDatumVon;
        public KiSS4.Gui.KissLookUpEdit edtEinzahlungsschein;
        public KiSS4.Gui.KissTextEdit edtIBAN;
        public KiSS4.Gui.KissTextEdit edtPostkontoNr;
        public KiSS4.Common.KissReferenzNrEdit edtReferenz;
        public KiSS4.DB.SqlQuery qryBaZahlungsweg;
        private KiSS4.Gui.KissButton btnGenerateIBAN;
        private DevExpress.XtraGrid.Columns.GridColumn colBankPost;
        private DevExpress.XtraGrid.Columns.GridColumn colEZ;
        private DevExpress.XtraGrid.Columns.GridColumn colGueltigAb;
        private DevExpress.XtraGrid.Columns.GridColumn colGueltigBis;
        private DevExpress.XtraGrid.Columns.GridColumn colKontoNr;
        private DevExpress.XtraGrid.Columns.GridColumn colPCKonto;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissCheckedLookupEdit edtBaZahlwegModulStdCodes;
        private KiSS4.Gui.KissTextEdit edtBankPC;
        private KiSS4.Gui.KissTextEdit edtClearingNummer;
        private KiSS4.Gui.KissMemoEdit edtIBANErrorMsg;
        private KiSS4.Gui.KissTextEdit edtName;
        private KiSS4.Gui.KissTextEdit edtNummerWohnsitz;
        private KiSS4.Common.KissPLZOrt edtWohnsitzPLZOrt;
        private KiSS4.Gui.KissTextEdit edtWohnsitzStrasse;
        private KiSS4.Gui.KissTextEdit edtWohnsitzZusatz;
        private KiSS4.Gui.KissGrid grdBaZahlungsweg;
        private DevExpress.XtraGrid.Views.Grid.GridView grvZahlungsweg;
        private KiSS4.Gui.KissLabel lblBCN;
        private KiSS4.Gui.KissLabel lblBankPost;
        private KiSS4.Gui.KissLabel lblBankkontoNr;
        private KiSS4.Gui.KissLabel lblDatumVon;
        private KiSS4.Gui.KissLabel lblEinzahlungFuer;
        private KiSS4.Gui.KissLabel lblEinzahlungsschein;
        private KiSS4.Gui.KissLabel lblGueltigBis;
        private KiSS4.Gui.KissLabel lblIBAN;
        private KiSS4.Gui.KissLabel lblName;
        private KiSS4.Gui.KissLabel lblPLZOrt;
        private KiSS4.Gui.KissLabel lblPostKonto;
        private KiSS4.Gui.KissLabel lblRefNr;
        private KiSS4.Gui.KissLabel lblStandardZahlwegFuer;
        private KiSS4.Gui.KissLabel lblStrasseNr;
        private KiSS4.Gui.KissLabel lblZusatz;
        private System.Windows.Forms.Panel panAddressAndMore;
        private System.Windows.Forms.TableLayoutPanel panTblDetails;
        private System.Windows.Forms.Panel panZahlwegData;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
    }
}
