namespace KiSS4.Sozialhilfe.ZH
{
    partial class CtlBgFPAusgaben
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBgFPAusgaben));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdBgPosition = new KiSS4.Gui.KissGrid();
            this.qryBgPosition = new KiSS4.DB.SqlQuery(this.components);
            this.grvBgPosition = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKOA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungsText2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReduktion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAchtung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.kissTabControlEx1 = new KiSS4.Gui.KissTabControlEx();
            this.tpgMonatsbudget = new SharpLibrary.WinControls.TabPageEx();
            this.kissGrid1 = new KiSS4.Gui.KissGrid();
            this.qryMonatsbudget = new KiSS4.DB.SqlQuery(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colStatus2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colJahr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKOA2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungstext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpgPosition = new SharpLibrary.WinControls.TabPageEx();
            this.edtTotal = new KiSS4.Gui.KissCalcEdit();
            this.fraKennzahlen = new KiSS4.Gui.KissGroupBox();
            this.edtUeWohnkosten = new KiSS4.Gui.KissLabel();
            this.qryWhKennzahlen = new KiSS4.DB.SqlQuery(this.components);
            this.lblUeWohnkosten = new KiSS4.Gui.KissLabel();
            this.edtUeGrundbedarf = new KiSS4.Gui.KissLabel();
            this.lblUeGrundbedarf = new KiSS4.Gui.KissLabel();
            this.kissLabel22 = new KiSS4.Gui.KissLabel();
            this.edtHgWohnkosten = new KiSS4.Gui.KissLabel();
            this.lblHgWohnkosten = new KiSS4.Gui.KissLabel();
            this.edtHgGrundbedarf = new KiSS4.Gui.KissLabel();
            this.lblHgGrundbedarf = new KiSS4.Gui.KissLabel();
            this.kissLabel21 = new KiSS4.Gui.KissLabel();
            this.lblKommentar = new KiSS4.Gui.KissLabel();
            this.lblTotal = new KiSS4.Gui.KissLabel();
            this.lblMinus = new KiSS4.Gui.KissLabel();
            this.lblReduktion = new KiSS4.Gui.KissLabel();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.lblInstitution = new KiSS4.Gui.KissLabel();
            this.lblBuchungstext = new KiSS4.Gui.KissLabel();
            this.lblKostenart = new KiSS4.Gui.KissLabel();
            this.lblBis = new KiSS4.Gui.KissLabel();
            this.lblDatumVon = new KiSS4.Gui.KissLabel();
            this.lblBaPersonID = new KiSS4.Gui.KissLabel();
            this.edtAdresse = new KiSS4.Gui.KissMemoEdit();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.edtInstitution = new KiSS4.Gui.KissButtonEdit();
            this.edtBewilligung = new KiSS4.Gui.KissTextEdit();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.btnPositionVerlauf = new KiSS4.Gui.KissButton();
            this.btnPositionBewilligung = new KiSS4.Gui.KissButton();
            this.edtReduktion = new KiSS4.Gui.KissCalcEdit();
            this.edtBetrag = new KiSS4.Gui.KissCalcEdit();
            this.lblBetrag = new KiSS4.Gui.KissLabel();
            this.edtBaPersonID = new KiSS4.Gui.KissLookUpEdit();
            this.edtBuchungstext = new KiSS4.Gui.KissTextEdit();
            this.edtKostenart = new KiSS4.Gui.KissButtonEdit();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.picTitle = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            this.kissTabControlEx1.SuspendLayout();
            this.tpgMonatsbudget.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryMonatsbudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).BeginInit();
            this.tpgPosition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtTotal.Properties)).BeginInit();
            this.fraKennzahlen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeWohnkosten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryWhKennzahlen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUeWohnkosten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeGrundbedarf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUeGrundbedarf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHgWohnkosten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHgWohnkosten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHgGrundbedarf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHgGrundbedarf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKommentar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMinus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReduktion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInstitution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungstext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInstitution.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBewilligung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtReduktion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungstext.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // grdBgPosition
            // 
            this.grdBgPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdBgPosition.DataSource = this.qryBgPosition;
            // 
            // 
            // 
            this.grdBgPosition.EmbeddedNavigator.Name = "";
            this.grdBgPosition.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBgPosition.Location = new System.Drawing.Point(5, 37);
            this.grdBgPosition.MainView = this.grvBgPosition;
            this.grdBgPosition.Name = "grdBgPosition";
            this.grdBgPosition.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1});
            this.grdBgPosition.Size = new System.Drawing.Size(721, 330);
            this.grdBgPosition.TabIndex = 0;
            this.grdBgPosition.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBgPosition});
            // 
            // qryBgPosition
            // 
            this.qryBgPosition.CanDelete = true;
            this.qryBgPosition.CanInsert = true;
            this.qryBgPosition.CanUpdate = true;
            this.qryBgPosition.HostControl = this;
            this.qryBgPosition.SelectStatement = resources.GetString("qryBgPosition.SelectStatement");
            this.qryBgPosition.TableName = "BgPosition";
            this.qryBgPosition.AfterDelete += new System.EventHandler(this.qryBgPosition_AfterDelete);
            this.qryBgPosition.AfterInsert += new System.EventHandler(this.qryBgPosition_AfterInsert);
            this.qryBgPosition.AfterPost += new System.EventHandler(this.qryBgPosition_AfterPost);
            this.qryBgPosition.BeforeDelete += new System.EventHandler(this.qryBgPosition_BeforeDelete);
            this.qryBgPosition.BeforeDeleteQuestion += new System.EventHandler(this.qryBgPosition_BeforeDeleteQuestion);
            this.qryBgPosition.BeforePost += new System.EventHandler(this.qryBgPosition_BeforePost);
            this.qryBgPosition.PositionChanged += new System.EventHandler(this.qryBgPosition_PositionChanged);
            // 
            // grvBgPosition
            // 
            this.grvBgPosition.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBgPosition.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.Empty.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.Empty.Options.UseFont = true;
            this.grvBgPosition.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.EvenRow.Options.UseFont = true;
            this.grvBgPosition.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBgPosition.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBgPosition.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBgPosition.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBgPosition.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBgPosition.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBgPosition.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBgPosition.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBgPosition.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBgPosition.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBgPosition.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvBgPosition.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBgPosition.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBgPosition.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBgPosition.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBgPosition.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.GroupRow.Options.UseFont = true;
            this.grvBgPosition.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBgPosition.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBgPosition.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBgPosition.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBgPosition.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBgPosition.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBgPosition.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBgPosition.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBgPosition.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBgPosition.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBgPosition.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBgPosition.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.OddRow.Options.UseFont = true;
            this.grvBgPosition.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBgPosition.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.Row.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.Row.Options.UseFont = true;
            this.grvBgPosition.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBgPosition.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBgPosition.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBgPosition.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBgPosition.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatumVon,
            this.colDatumBis,
            this.colKOA,
            this.colBuchungsText2,
            this.colBaPersonID,
            this.colPersNr,
            this.colBetrag,
            this.colReduktion,
            this.colTotal,
            this.colStatus,
            this.colF,
            this.colAchtung});
            this.grvBgPosition.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBgPosition.GridControl = this.grdBgPosition;
            this.grvBgPosition.Name = "grvBgPosition";
            this.grvBgPosition.OptionsBehavior.Editable = false;
            this.grvBgPosition.OptionsCustomization.AllowFilter = false;
            this.grvBgPosition.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBgPosition.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBgPosition.OptionsNavigation.UseTabKey = false;
            this.grvBgPosition.OptionsView.ColumnAutoWidth = false;
            this.grvBgPosition.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBgPosition.OptionsView.ShowGroupPanel = false;
            this.grvBgPosition.OptionsView.ShowIndicator = false;
            // 
            // colDatumVon
            // 
            this.colDatumVon.Caption = "gültig von";
            this.colDatumVon.FieldName = "DatumVonKonsolidiert";
            this.colDatumVon.Name = "colDatumVon";
            this.colDatumVon.Visible = true;
            this.colDatumVon.VisibleIndex = 0;
            // 
            // colDatumBis
            // 
            this.colDatumBis.Caption = "bis";
            this.colDatumBis.FieldName = "DatumBisKonsolidiert";
            this.colDatumBis.Name = "colDatumBis";
            this.colDatumBis.Visible = true;
            this.colDatumBis.VisibleIndex = 1;
            // 
            // colKOA
            // 
            this.colKOA.Caption = "LA";
            this.colKOA.FieldName = "KOA";
            this.colKOA.Name = "colKOA";
            this.colKOA.Visible = true;
            this.colKOA.VisibleIndex = 2;
            this.colKOA.Width = 34;
            // 
            // colBuchungsText2
            // 
            this.colBuchungsText2.Caption = "Buchungstext";
            this.colBuchungsText2.FieldName = "Buchungstext";
            this.colBuchungsText2.Name = "colBuchungsText2";
            this.colBuchungsText2.Visible = true;
            this.colBuchungsText2.VisibleIndex = 3;
            this.colBuchungsText2.Width = 145;
            // 
            // colBaPersonID
            // 
            this.colBaPersonID.Caption = "Person";
            this.colBaPersonID.FieldName = "BaPersonID";
            this.colBaPersonID.Name = "colBaPersonID";
            this.colBaPersonID.Visible = true;
            this.colBaPersonID.VisibleIndex = 4;
            this.colBaPersonID.Width = 149;
            // 
            // colPersNr
            // 
            this.colPersNr.Caption = "Pers.-Nr.";
            this.colPersNr.FieldName = "BaPersonID";
            this.colPersNr.Name = "colPersNr";
            this.colPersNr.Visible = true;
            this.colPersNr.VisibleIndex = 5;
            this.colPersNr.Width = 60;
            // 
            // colBetrag
            // 
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.DisplayFormat.FormatString = "n2";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.FieldName = "Betrag";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 6;
            // 
            // colReduktion
            // 
            this.colReduktion.Caption = "Reduktion";
            this.colReduktion.DisplayFormat.FormatString = "n2";
            this.colReduktion.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colReduktion.FieldName = "Reduktion";
            this.colReduktion.Name = "colReduktion";
            this.colReduktion.Visible = true;
            this.colReduktion.VisibleIndex = 7;
            // 
            // colTotal
            // 
            this.colTotal.Caption = "Total";
            this.colTotal.DisplayFormat.FormatString = "n2";
            this.colTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotal.FieldName = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 8;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Stat";
            this.colStatus.ColumnEdit = this.repositoryItemImageComboBox1;
            this.colStatus.FieldName = "BgBewilligungStatusCode";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 9;
            this.colStatus.Width = 31;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // colF
            // 
            this.colF.Caption = "LE";
            this.colF.FieldName = "F";
            this.colF.Name = "colF";
            this.colF.Visible = true;
            this.colF.VisibleIndex = 10;
            this.colF.Width = 25;
            // 
            // colAchtung
            // 
            this.colAchtung.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colAchtung.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.colAchtung.AppearanceCell.Options.HighPriority = true;
            this.colAchtung.AppearanceCell.Options.UseFont = true;
            this.colAchtung.AppearanceCell.Options.UseForeColor = true;
            this.colAchtung.AppearanceCell.Options.UseTextOptions = true;
            this.colAchtung.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAchtung.AppearanceHeader.Options.UseTextOptions = true;
            this.colAchtung.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAchtung.Caption = "!";
            this.colAchtung.FieldName = "Achtung";
            this.colAchtung.Name = "colAchtung";
            this.colAchtung.Visible = true;
            this.colAchtung.VisibleIndex = 11;
            this.colAchtung.Width = 20;
            // 
            // lblTitel
            // 
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(32, 8);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(648, 16);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "{2} vom {0:d} bis {1:d}";
            this.lblTitel.UseCompatibleTextRendering = true;
            // 
            // kissTabControlEx1
            // 
            this.kissTabControlEx1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kissTabControlEx1.Controls.Add(this.tpgMonatsbudget);
            this.kissTabControlEx1.Controls.Add(this.tpgPosition);
            this.kissTabControlEx1.Location = new System.Drawing.Point(5, 376);
            this.kissTabControlEx1.Name = "kissTabControlEx1";
            this.kissTabControlEx1.ShowFixedWidthTooltip = true;
            this.kissTabControlEx1.Size = new System.Drawing.Size(723, 270);
            this.kissTabControlEx1.TabIndex = 1;
            this.kissTabControlEx1.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgPosition,
            this.tpgMonatsbudget});
            this.kissTabControlEx1.TabsLineColor = System.Drawing.Color.Black;
            this.kissTabControlEx1.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.kissTabControlEx1.Text = "kissTabControlEx1";
            // 
            // tpgMonatsbudget
            // 
            this.tpgMonatsbudget.Controls.Add(this.kissGrid1);
            this.tpgMonatsbudget.Location = new System.Drawing.Point(6, 6);
            this.tpgMonatsbudget.Name = "tpgMonatsbudget";
            this.tpgMonatsbudget.Size = new System.Drawing.Size(711, 232);
            this.tpgMonatsbudget.TabIndex = 1;
            this.tpgMonatsbudget.Title = "Verwendung Monatsbudgets";
            // 
            // kissGrid1
            // 
            this.kissGrid1.DataSource = this.qryMonatsbudget;
            this.kissGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.kissGrid1.EmbeddedNavigator.Name = "";
            this.kissGrid1.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.kissGrid1.Location = new System.Drawing.Point(0, 0);
            this.kissGrid1.MainView = this.gridView1;
            this.kissGrid1.Name = "kissGrid1";
            this.kissGrid1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox2});
            this.kissGrid1.Size = new System.Drawing.Size(711, 232);
            this.kissGrid1.TabIndex = 0;
            this.kissGrid1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // qryMonatsbudget
            // 
            this.qryMonatsbudget.CanDelete = true;
            this.qryMonatsbudget.CanInsert = true;
            this.qryMonatsbudget.CanUpdate = true;
            this.qryMonatsbudget.HostControl = this;
            this.qryMonatsbudget.SelectStatement = resources.GetString("qryMonatsbudget.SelectStatement");
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
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStatus2,
            this.colJahr,
            this.colMonat,
            this.colKOA2,
            this.colBuchungstext,
            this.colPerson,
            this.colBetrag2});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.kissGrid1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.UseTabKey = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // colStatus2
            // 
            this.colStatus2.Caption = "Stat";
            this.colStatus2.ColumnEdit = this.repositoryItemImageComboBox2;
            this.colStatus2.FieldName = "Status";
            this.colStatus2.Name = "colStatus2";
            this.colStatus2.Visible = true;
            this.colStatus2.VisibleIndex = 0;
            this.colStatus2.Width = 35;
            // 
            // repositoryItemImageComboBox2
            // 
            this.repositoryItemImageComboBox2.AutoHeight = false;
            this.repositoryItemImageComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox2.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
            // 
            // colJahr
            // 
            this.colJahr.Caption = "Jahr";
            this.colJahr.FieldName = "Jahr";
            this.colJahr.Name = "colJahr";
            this.colJahr.Visible = true;
            this.colJahr.VisibleIndex = 1;
            this.colJahr.Width = 45;
            // 
            // colMonat
            // 
            this.colMonat.Caption = "Monat";
            this.colMonat.FieldName = "Monat";
            this.colMonat.Name = "colMonat";
            this.colMonat.Visible = true;
            this.colMonat.VisibleIndex = 2;
            // 
            // colKOA2
            // 
            this.colKOA2.Caption = "LA";
            this.colKOA2.FieldName = "KOA";
            this.colKOA2.Name = "colKOA2";
            this.colKOA2.Visible = true;
            this.colKOA2.VisibleIndex = 3;
            this.colKOA2.Width = 37;
            // 
            // colBuchungstext
            // 
            this.colBuchungstext.Caption = "Buchungstext";
            this.colBuchungstext.FieldName = "Buchungstext";
            this.colBuchungstext.Name = "colBuchungstext";
            this.colBuchungstext.Visible = true;
            this.colBuchungstext.VisibleIndex = 4;
            this.colBuchungstext.Width = 167;
            // 
            // colPerson
            // 
            this.colPerson.Caption = "Person";
            this.colPerson.FieldName = "Person";
            this.colPerson.Name = "colPerson";
            this.colPerson.Visible = true;
            this.colPerson.VisibleIndex = 5;
            this.colPerson.Width = 163;
            // 
            // colBetrag2
            // 
            this.colBetrag2.Caption = "Betrag";
            this.colBetrag2.DisplayFormat.FormatString = "N2";
            this.colBetrag2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag2.FieldName = "Betrag";
            this.colBetrag2.Name = "colBetrag2";
            this.colBetrag2.Visible = true;
            this.colBetrag2.VisibleIndex = 6;
            // 
            // tpgPosition
            // 
            this.tpgPosition.Controls.Add(this.edtTotal);
            this.tpgPosition.Controls.Add(this.fraKennzahlen);
            this.tpgPosition.Controls.Add(this.lblKommentar);
            this.tpgPosition.Controls.Add(this.lblTotal);
            this.tpgPosition.Controls.Add(this.lblMinus);
            this.tpgPosition.Controls.Add(this.lblReduktion);
            this.tpgPosition.Controls.Add(this.kissLabel2);
            this.tpgPosition.Controls.Add(this.lblInstitution);
            this.tpgPosition.Controls.Add(this.lblBuchungstext);
            this.tpgPosition.Controls.Add(this.lblKostenart);
            this.tpgPosition.Controls.Add(this.lblBis);
            this.tpgPosition.Controls.Add(this.lblDatumVon);
            this.tpgPosition.Controls.Add(this.lblBaPersonID);
            this.tpgPosition.Controls.Add(this.edtAdresse);
            this.tpgPosition.Controls.Add(this.lblBemerkung);
            this.tpgPosition.Controls.Add(this.edtInstitution);
            this.tpgPosition.Controls.Add(this.edtBewilligung);
            this.tpgPosition.Controls.Add(this.edtBemerkung);
            this.tpgPosition.Controls.Add(this.btnPositionVerlauf);
            this.tpgPosition.Controls.Add(this.btnPositionBewilligung);
            this.tpgPosition.Controls.Add(this.edtReduktion);
            this.tpgPosition.Controls.Add(this.edtBetrag);
            this.tpgPosition.Controls.Add(this.lblBetrag);
            this.tpgPosition.Controls.Add(this.edtBaPersonID);
            this.tpgPosition.Controls.Add(this.edtBuchungstext);
            this.tpgPosition.Controls.Add(this.edtKostenart);
            this.tpgPosition.Controls.Add(this.edtDatumBis);
            this.tpgPosition.Controls.Add(this.edtDatumVon);
            this.tpgPosition.Location = new System.Drawing.Point(6, 6);
            this.tpgPosition.Name = "tpgPosition";
            this.tpgPosition.Size = new System.Drawing.Size(711, 232);
            this.tpgPosition.TabIndex = 0;
            this.tpgPosition.Title = "Position";
            // 
            // edtTotal
            // 
            this.edtTotal.DataMember = "Total";
            this.edtTotal.DataSource = this.qryBgPosition;
            this.edtTotal.Location = new System.Drawing.Point(458, 118);
            this.edtTotal.Name = "edtTotal";
            this.edtTotal.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtTotal.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTotal.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTotal.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTotal.Properties.Appearance.Options.UseBackColor = true;
            this.edtTotal.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTotal.Properties.Appearance.Options.UseFont = true;
            this.edtTotal.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTotal.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTotal.Properties.DisplayFormat.FormatString = "n2";
            this.edtTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtTotal.Properties.EditFormat.FormatString = "n2";
            this.edtTotal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtTotal.Size = new System.Drawing.Size(94, 24);
            this.edtTotal.TabIndex = 7;
            // 
            // fraKennzahlen
            // 
            this.fraKennzahlen.Controls.Add(this.edtUeWohnkosten);
            this.fraKennzahlen.Controls.Add(this.lblUeWohnkosten);
            this.fraKennzahlen.Controls.Add(this.edtUeGrundbedarf);
            this.fraKennzahlen.Controls.Add(this.lblUeGrundbedarf);
            this.fraKennzahlen.Controls.Add(this.kissLabel22);
            this.fraKennzahlen.Controls.Add(this.edtHgWohnkosten);
            this.fraKennzahlen.Controls.Add(this.lblHgWohnkosten);
            this.fraKennzahlen.Controls.Add(this.edtHgGrundbedarf);
            this.fraKennzahlen.Controls.Add(this.lblHgGrundbedarf);
            this.fraKennzahlen.Controls.Add(this.kissLabel21);
            this.fraKennzahlen.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.fraKennzahlen.Location = new System.Drawing.Point(409, 141);
            this.fraKennzahlen.Name = "fraKennzahlen";
            this.fraKennzahlen.Size = new System.Drawing.Size(299, 88);
            this.fraKennzahlen.TabIndex = 80;
            this.fraKennzahlen.TabStop = false;
            this.fraKennzahlen.Text = "Kennzahlen";
            this.fraKennzahlen.UseCompatibleTextRendering = true;
            // 
            // edtUeWohnkosten
            // 
            this.edtUeWohnkosten.DataMember = "UeWohnkosten";
            this.edtUeWohnkosten.DataSource = this.qryWhKennzahlen;
            this.edtUeWohnkosten.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.edtUeWohnkosten.Location = new System.Drawing.Point(219, 51);
            this.edtUeWohnkosten.Name = "edtUeWohnkosten";
            this.edtUeWohnkosten.Size = new System.Drawing.Size(24, 16);
            this.edtUeWohnkosten.TabIndex = 9;
            this.edtUeWohnkosten.UseCompatibleTextRendering = true;
            // 
            // qryWhKennzahlen
            // 
            this.qryWhKennzahlen.HostControl = this;
            this.qryWhKennzahlen.SelectStatement = "SELECT * FROM dbo.fnWhKennzahlen({0})";
            // 
            // lblUeWohnkosten
            // 
            this.lblUeWohnkosten.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblUeWohnkosten.Location = new System.Drawing.Point(147, 51);
            this.lblUeWohnkosten.Name = "lblUeWohnkosten";
            this.lblUeWohnkosten.Size = new System.Drawing.Size(72, 16);
            this.lblUeWohnkosten.TabIndex = 8;
            this.lblUeWohnkosten.Text = "Miete (Anteil)";
            this.lblUeWohnkosten.UseCompatibleTextRendering = true;
            // 
            // edtUeGrundbedarf
            // 
            this.edtUeGrundbedarf.DataMember = "UeGrundbedarf";
            this.edtUeGrundbedarf.DataSource = this.qryWhKennzahlen;
            this.edtUeGrundbedarf.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.edtUeGrundbedarf.Location = new System.Drawing.Point(219, 35);
            this.edtUeGrundbedarf.Name = "edtUeGrundbedarf";
            this.edtUeGrundbedarf.Size = new System.Drawing.Size(24, 16);
            this.edtUeGrundbedarf.TabIndex = 7;
            this.edtUeGrundbedarf.UseCompatibleTextRendering = true;
            // 
            // lblUeGrundbedarf
            // 
            this.lblUeGrundbedarf.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblUeGrundbedarf.Location = new System.Drawing.Point(147, 35);
            this.lblUeGrundbedarf.Name = "lblUeGrundbedarf";
            this.lblUeGrundbedarf.Size = new System.Drawing.Size(72, 16);
            this.lblUeGrundbedarf.TabIndex = 6;
            this.lblUeGrundbedarf.Text = "Grundbedarf";
            this.lblUeGrundbedarf.UseCompatibleTextRendering = true;
            // 
            // kissLabel22
            // 
            this.kissLabel22.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel22.Location = new System.Drawing.Point(145, 19);
            this.kissLabel22.Name = "kissLabel22";
            this.kissLabel22.Size = new System.Drawing.Size(148, 16);
            this.kissLabel22.TabIndex = 5;
            this.kissLabel22.Text = "Unterstützungseinheit";
            this.kissLabel22.UseCompatibleTextRendering = true;
            // 
            // edtHgWohnkosten
            // 
            this.edtHgWohnkosten.DataMember = "HgWohnkosten";
            this.edtHgWohnkosten.DataSource = this.qryWhKennzahlen;
            this.edtHgWohnkosten.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.edtHgWohnkosten.Location = new System.Drawing.Point(83, 51);
            this.edtHgWohnkosten.Name = "edtHgWohnkosten";
            this.edtHgWohnkosten.Size = new System.Drawing.Size(24, 16);
            this.edtHgWohnkosten.TabIndex = 4;
            this.edtHgWohnkosten.UseCompatibleTextRendering = true;
            // 
            // lblHgWohnkosten
            // 
            this.lblHgWohnkosten.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblHgWohnkosten.Location = new System.Drawing.Point(11, 51);
            this.lblHgWohnkosten.Name = "lblHgWohnkosten";
            this.lblHgWohnkosten.Size = new System.Drawing.Size(72, 16);
            this.lblHgWohnkosten.TabIndex = 3;
            this.lblHgWohnkosten.Text = "Miete";
            this.lblHgWohnkosten.UseCompatibleTextRendering = true;
            // 
            // edtHgGrundbedarf
            // 
            this.edtHgGrundbedarf.DataMember = "HgGrundbedarf";
            this.edtHgGrundbedarf.DataSource = this.qryWhKennzahlen;
            this.edtHgGrundbedarf.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.edtHgGrundbedarf.Location = new System.Drawing.Point(83, 35);
            this.edtHgGrundbedarf.Name = "edtHgGrundbedarf";
            this.edtHgGrundbedarf.Size = new System.Drawing.Size(24, 16);
            this.edtHgGrundbedarf.TabIndex = 2;
            this.edtHgGrundbedarf.UseCompatibleTextRendering = true;
            // 
            // lblHgGrundbedarf
            // 
            this.lblHgGrundbedarf.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblHgGrundbedarf.Location = new System.Drawing.Point(11, 35);
            this.lblHgGrundbedarf.Name = "lblHgGrundbedarf";
            this.lblHgGrundbedarf.Size = new System.Drawing.Size(72, 16);
            this.lblHgGrundbedarf.TabIndex = 1;
            this.lblHgGrundbedarf.Text = "Grundbedarf";
            this.lblHgGrundbedarf.UseCompatibleTextRendering = true;
            // 
            // kissLabel21
            // 
            this.kissLabel21.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel21.Location = new System.Drawing.Point(11, 19);
            this.kissLabel21.Name = "kissLabel21";
            this.kissLabel21.Size = new System.Drawing.Size(140, 16);
            this.kissLabel21.TabIndex = 0;
            this.kissLabel21.Text = "Berechnungseinheit";
            this.kissLabel21.UseCompatibleTextRendering = true;
            // 
            // lblKommentar
            // 
            this.lblKommentar.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblKommentar.Location = new System.Drawing.Point(401, 38);
            this.lblKommentar.Name = "lblKommentar";
            this.lblKommentar.Size = new System.Drawing.Size(239, 17);
            this.lblKommentar.TabIndex = 79;
            this.lblKommentar.Text = "VVG wird nur bei bewilligtem EK aufgenommen!";
            this.lblKommentar.UseCompatibleTextRendering = true;
            // 
            // lblTotal
            // 
            this.lblTotal.Location = new System.Drawing.Point(372, 118);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(82, 24);
            this.lblTotal.TabIndex = 77;
            this.lblTotal.Text = "= Unterstützung";
            this.lblTotal.UseCompatibleTextRendering = true;
            // 
            // lblMinus
            // 
            this.lblMinus.Location = new System.Drawing.Point(201, 118);
            this.lblMinus.Name = "lblMinus";
            this.lblMinus.Size = new System.Drawing.Size(8, 24);
            this.lblMinus.TabIndex = 76;
            this.lblMinus.Text = "-";
            this.lblMinus.UseCompatibleTextRendering = true;
            // 
            // lblReduktion
            // 
            this.lblReduktion.Location = new System.Drawing.Point(210, 118);
            this.lblReduktion.Name = "lblReduktion";
            this.lblReduktion.Size = new System.Drawing.Size(56, 24);
            this.lblReduktion.TabIndex = 75;
            this.lblReduktion.Text = "Reduktion";
            this.lblReduktion.UseCompatibleTextRendering = true;
            // 
            // kissLabel2
            // 
            this.kissLabel2.Location = new System.Drawing.Point(5, 205);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(64, 24);
            this.kissLabel2.TabIndex = 73;
            this.kissLabel2.Text = "Bewilligung";
            this.kissLabel2.UseCompatibleTextRendering = true;
            // 
            // lblInstitution
            // 
            this.lblInstitution.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblInstitution.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblInstitution.Location = new System.Drawing.Point(409, 15);
            this.lblInstitution.Name = "lblInstitution";
            this.lblInstitution.Size = new System.Drawing.Size(54, 16);
            this.lblInstitution.TabIndex = 67;
            this.lblInstitution.Text = "Institution";
            this.lblInstitution.UseCompatibleTextRendering = true;
            // 
            // lblBuchungstext
            // 
            this.lblBuchungstext.Location = new System.Drawing.Point(5, 57);
            this.lblBuchungstext.Name = "lblBuchungstext";
            this.lblBuchungstext.Size = new System.Drawing.Size(85, 24);
            this.lblBuchungstext.TabIndex = 64;
            this.lblBuchungstext.Text = "Buchungstext";
            this.lblBuchungstext.UseCompatibleTextRendering = true;
            // 
            // lblKostenart
            // 
            this.lblKostenart.Location = new System.Drawing.Point(5, 35);
            this.lblKostenart.Name = "lblKostenart";
            this.lblKostenart.Size = new System.Drawing.Size(85, 24);
            this.lblKostenart.TabIndex = 63;
            this.lblKostenart.Text = "LA/Positionsart";
            this.lblKostenart.UseCompatibleTextRendering = true;
            // 
            // lblBis
            // 
            this.lblBis.Location = new System.Drawing.Point(202, 5);
            this.lblBis.Name = "lblBis";
            this.lblBis.Size = new System.Drawing.Size(18, 24);
            this.lblBis.TabIndex = 60;
            this.lblBis.Text = "bis";
            this.lblBis.UseCompatibleTextRendering = true;
            // 
            // lblDatumVon
            // 
            this.lblDatumVon.Location = new System.Drawing.Point(5, 5);
            this.lblDatumVon.Name = "lblDatumVon";
            this.lblDatumVon.Size = new System.Drawing.Size(85, 24);
            this.lblDatumVon.TabIndex = 58;
            this.lblDatumVon.Text = "gültig von";
            this.lblDatumVon.UseCompatibleTextRendering = true;
            // 
            // lblBaPersonID
            // 
            this.lblBaPersonID.Location = new System.Drawing.Point(5, 87);
            this.lblBaPersonID.Name = "lblBaPersonID";
            this.lblBaPersonID.Size = new System.Drawing.Size(85, 24);
            this.lblBaPersonID.TabIndex = 57;
            this.lblBaPersonID.Text = "Person";
            this.lblBaPersonID.UseCompatibleTextRendering = true;
            // 
            // edtAdresse
            // 
            this.edtAdresse.DataMember = "Adresse";
            this.edtAdresse.DataSource = this.qryBgPosition;
            this.edtAdresse.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAdresse.Location = new System.Drawing.Point(410, 57);
            this.edtAdresse.Name = "edtAdresse";
            this.edtAdresse.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAdresse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdresse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdresse.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdresse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdresse.Properties.Appearance.Options.UseFont = true;
            this.edtAdresse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAdresse.Properties.ReadOnly = true;
            this.edtAdresse.Size = new System.Drawing.Size(298, 54);
            this.edtAdresse.TabIndex = 13;
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblBemerkung.Location = new System.Drawing.Point(5, 148);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(95, 17);
            this.lblBemerkung.TabIndex = 12;
            this.lblBemerkung.Text = "Bemerkung";
            this.lblBemerkung.UseCompatibleTextRendering = true;
            // 
            // edtInstitution
            // 
            this.edtInstitution.DataMember = "Institution";
            this.edtInstitution.DataSource = this.qryBgPosition;
            this.edtInstitution.Location = new System.Drawing.Point(410, 34);
            this.edtInstitution.Name = "edtInstitution";
            this.edtInstitution.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtInstitution.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtInstitution.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtInstitution.Properties.Appearance.Options.UseBackColor = true;
            this.edtInstitution.Properties.Appearance.Options.UseBorderColor = true;
            this.edtInstitution.Properties.Appearance.Options.UseFont = true;
            this.edtInstitution.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtInstitution.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtInstitution.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtInstitution.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtInstitution.Size = new System.Drawing.Size(298, 24);
            this.edtInstitution.TabIndex = 12;
            this.edtInstitution.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtInstitution_UserModifiedFld);
            // 
            // edtBewilligung
            // 
            this.edtBewilligung.DataMember = "Bewilligung";
            this.edtBewilligung.DataSource = this.qryBgPosition;
            this.edtBewilligung.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBewilligung.Location = new System.Drawing.Point(106, 205);
            this.edtBewilligung.Name = "edtBewilligung";
            this.edtBewilligung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBewilligung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBewilligung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBewilligung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBewilligung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBewilligung.Properties.Appearance.Options.UseFont = true;
            this.edtBewilligung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBewilligung.Properties.ReadOnly = true;
            this.edtBewilligung.Size = new System.Drawing.Size(289, 24);
            this.edtBewilligung.TabIndex = 11;
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryBgPosition;
            this.edtBemerkung.Location = new System.Drawing.Point(106, 148);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Properties.MaxLength = 200;
            this.edtBemerkung.Size = new System.Drawing.Size(289, 50);
            this.edtBemerkung.TabIndex = 10;
            // 
            // btnPositionVerlauf
            // 
            this.btnPositionVerlauf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPositionVerlauf.IconID = 1370;
            this.btnPositionVerlauf.Location = new System.Drawing.Point(588, 118);
            this.btnPositionVerlauf.Name = "btnPositionVerlauf";
            this.btnPositionVerlauf.Size = new System.Drawing.Size(25, 24);
            this.btnPositionVerlauf.TabIndex = 9;
            this.btnPositionVerlauf.UseCompatibleTextRendering = true;
            this.btnPositionVerlauf.UseVisualStyleBackColor = false;
            this.btnPositionVerlauf.Visible = false;
            // 
            // btnPositionBewilligung
            // 
            this.btnPositionBewilligung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPositionBewilligung.Image = ((System.Drawing.Image)(resources.GetObject("btnPositionBewilligung.Image")));
            this.btnPositionBewilligung.Location = new System.Drawing.Point(558, 118);
            this.btnPositionBewilligung.Name = "btnPositionBewilligung";
            this.btnPositionBewilligung.Size = new System.Drawing.Size(24, 24);
            this.btnPositionBewilligung.TabIndex = 8;
            this.btnPositionBewilligung.UseCompatibleTextRendering = true;
            this.btnPositionBewilligung.UseVisualStyleBackColor = false;
            this.btnPositionBewilligung.Visible = false;
            this.btnPositionBewilligung.Click += new System.EventHandler(this.btnPositionBewilligung_Click);
            // 
            // edtReduktion
            // 
            this.edtReduktion.DataMember = "Reduktion";
            this.edtReduktion.DataSource = this.qryBgPosition;
            this.edtReduktion.Location = new System.Drawing.Point(276, 118);
            this.edtReduktion.Name = "edtReduktion";
            this.edtReduktion.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtReduktion.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtReduktion.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtReduktion.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtReduktion.Properties.Appearance.Options.UseBackColor = true;
            this.edtReduktion.Properties.Appearance.Options.UseBorderColor = true;
            this.edtReduktion.Properties.Appearance.Options.UseFont = true;
            this.edtReduktion.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtReduktion.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtReduktion.Properties.DisplayFormat.FormatString = "n2";
            this.edtReduktion.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtReduktion.Properties.EditFormat.FormatString = "n2";
            this.edtReduktion.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtReduktion.Size = new System.Drawing.Size(90, 24);
            this.edtReduktion.TabIndex = 6;
            // 
            // edtBetrag
            // 
            this.edtBetrag.DataMember = "Betrag";
            this.edtBetrag.DataSource = this.qryBgPosition;
            this.edtBetrag.Location = new System.Drawing.Point(106, 118);
            this.edtBetrag.Name = "edtBetrag";
            this.edtBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBetrag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBetrag.Properties.DisplayFormat.FormatString = "n2";
            this.edtBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Properties.EditFormat.FormatString = "n2";
            this.edtBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Size = new System.Drawing.Size(90, 24);
            this.edtBetrag.TabIndex = 5;
            // 
            // lblBetrag
            // 
            this.lblBetrag.Location = new System.Drawing.Point(5, 118);
            this.lblBetrag.Name = "lblBetrag";
            this.lblBetrag.Size = new System.Drawing.Size(85, 24);
            this.lblBetrag.TabIndex = 4;
            this.lblBetrag.Text = "mtl. Betrag";
            this.lblBetrag.UseCompatibleTextRendering = true;
            // 
            // edtBaPersonID
            // 
            this.edtBaPersonID.DataMember = "BaPersonID";
            this.edtBaPersonID.DataSource = this.qryBgPosition;
            this.edtBaPersonID.Location = new System.Drawing.Point(106, 87);
            this.edtBaPersonID.Name = "edtBaPersonID";
            this.edtBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBaPersonID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtBaPersonID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaPersonID.Properties.NullText = "";
            this.edtBaPersonID.Properties.ShowFooter = false;
            this.edtBaPersonID.Properties.ShowHeader = false;
            this.edtBaPersonID.Size = new System.Drawing.Size(289, 24);
            this.edtBaPersonID.TabIndex = 4;
            // 
            // edtBuchungstext
            // 
            this.edtBuchungstext.DataMember = "Buchungstext";
            this.edtBuchungstext.DataSource = this.qryBgPosition;
            this.edtBuchungstext.Location = new System.Drawing.Point(106, 57);
            this.edtBuchungstext.Name = "edtBuchungstext";
            this.edtBuchungstext.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBuchungstext.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBuchungstext.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchungstext.Properties.Appearance.Options.UseBackColor = true;
            this.edtBuchungstext.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBuchungstext.Properties.Appearance.Options.UseFont = true;
            this.edtBuchungstext.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBuchungstext.Size = new System.Drawing.Size(289, 24);
            this.edtBuchungstext.TabIndex = 3;
            // 
            // edtKostenart
            // 
            this.edtKostenart.DataMember = "Kostenart";
            this.edtKostenart.DataSource = this.qryBgPosition;
            this.edtKostenart.Location = new System.Drawing.Point(106, 35);
            this.edtKostenart.Name = "edtKostenart";
            this.edtKostenart.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKostenart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKostenart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKostenart.Properties.Appearance.Options.UseBackColor = true;
            this.edtKostenart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKostenart.Properties.Appearance.Options.UseFont = true;
            this.edtKostenart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtKostenart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtKostenart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKostenart.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtKostenart.Size = new System.Drawing.Size(289, 24);
            this.edtKostenart.TabIndex = 2;
            this.edtKostenart.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtKostenart_UserModifiedFld);
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.DataMember = "DatumBis";
            this.edtDatumBis.DataSource = this.qryBgPosition;
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(226, 5);
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
            this.edtDatumBis.Size = new System.Drawing.Size(90, 24);
            this.edtDatumBis.TabIndex = 1;
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.DataMember = "DatumVon";
            this.edtDatumVon.DataSource = this.qryBgPosition;
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(106, 5);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(90, 24);
            this.edtDatumVon.TabIndex = 0;
            // 
            // picTitle
            // 
            this.picTitle.Location = new System.Drawing.Point(8, 8);
            this.picTitle.Name = "picTitle";
            this.picTitle.Size = new System.Drawing.Size(16, 16);
            this.picTitle.TabIndex = 55;
            this.picTitle.TabStop = false;
            // 
            // CtlBgFPAusgaben
            // 
            this.ActiveSQLQuery = this.qryBgPosition;
            this.Controls.Add(this.picTitle);
            this.Controls.Add(this.kissTabControlEx1);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.grdBgPosition);
            this.Name = "CtlBgFPAusgaben";
            this.Size = new System.Drawing.Size(736, 649);
            ((System.ComponentModel.ISupportInitialize)(this.grdBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            this.kissTabControlEx1.ResumeLayout(false);
            this.tpgMonatsbudget.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kissGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryMonatsbudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).EndInit();
            this.tpgPosition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtTotal.Properties)).EndInit();
            this.fraKennzahlen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtUeWohnkosten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryWhKennzahlen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUeWohnkosten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeGrundbedarf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUeGrundbedarf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHgWohnkosten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHgWohnkosten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHgGrundbedarf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHgGrundbedarf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKommentar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMinus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReduktion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInstitution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungstext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInstitution.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBewilligung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtReduktion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungstext.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissButton btnPositionBewilligung;
        private KiSS4.Gui.KissButton btnPositionVerlauf;
        private DevExpress.XtraGrid.Columns.GridColumn colAchtung;
        private DevExpress.XtraGrid.Columns.GridColumn colBaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag2;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungstext;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungsText2;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumBis;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colF;
        private DevExpress.XtraGrid.Columns.GridColumn colJahr;
        private DevExpress.XtraGrid.Columns.GridColumn colKOA;
        private DevExpress.XtraGrid.Columns.GridColumn colKOA2;
        private DevExpress.XtraGrid.Columns.GridColumn colMonat;
        private DevExpress.XtraGrid.Columns.GridColumn colPersNr;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colReduktion;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus2;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private KiSS4.Gui.KissMemoEdit edtAdresse;
        private KiSS4.Gui.KissLookUpEdit edtBaPersonID;
        private KiSS4.Gui.KissMemoEdit edtBemerkung;
        private KiSS4.Gui.KissCalcEdit edtBetrag;
        private KiSS4.Gui.KissTextEdit edtBewilligung;
        private KiSS4.Gui.KissTextEdit edtBuchungstext;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissLabel edtHgGrundbedarf;
        private KiSS4.Gui.KissLabel edtHgWohnkosten;
        private KiSS4.Gui.KissButtonEdit edtInstitution;
        private KiSS4.Gui.KissButtonEdit edtKostenart;
        private KiSS4.Gui.KissCalcEdit edtReduktion;
        private KiSS4.Gui.KissCalcEdit edtTotal;
        private KiSS4.Gui.KissLabel edtUeGrundbedarf;
        private KiSS4.Gui.KissLabel edtUeWohnkosten;
        private KiSS4.Gui.KissGroupBox fraKennzahlen;
        private KiSS4.Gui.KissGrid grdBgPosition;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBgPosition;
        private KiSS4.Gui.KissGrid kissGrid1;
        private KiSS4.Gui.KissLabel kissLabel2;
        private KiSS4.Gui.KissLabel kissLabel21;
        private KiSS4.Gui.KissLabel kissLabel22;
        private KiSS4.Gui.KissTabControlEx kissTabControlEx1;
        private KiSS4.Gui.KissLabel lblBaPersonID;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblBetrag;
        private KiSS4.Gui.KissLabel lblBis;
        private KiSS4.Gui.KissLabel lblBuchungstext;
        private KiSS4.Gui.KissLabel lblDatumVon;
        private KiSS4.Gui.KissLabel lblHgGrundbedarf;
        private KiSS4.Gui.KissLabel lblHgWohnkosten;
        private KiSS4.Gui.KissLabel lblInstitution;
        private KiSS4.Gui.KissLabel lblKommentar;
        private KiSS4.Gui.KissLabel lblKostenart;
        private KiSS4.Gui.KissLabel lblMinus;
        private KiSS4.Gui.KissLabel lblReduktion;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissLabel lblTotal;
        private KiSS4.Gui.KissLabel lblUeGrundbedarf;
        private KiSS4.Gui.KissLabel lblUeWohnkosten;
        private System.Windows.Forms.PictureBox picTitle;
        private KiSS4.DB.SqlQuery qryBgFinanzplan;
        private KiSS4.DB.SqlQuery qryBgPosition;
        private KiSS4.DB.SqlQuery qryMonatsbudget;
        private KiSS4.DB.SqlQuery qryWhKennzahlen;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2;
        private SharpLibrary.WinControls.TabPageEx tpgMonatsbudget;
        private SharpLibrary.WinControls.TabPageEx tpgPosition;
    }
}
