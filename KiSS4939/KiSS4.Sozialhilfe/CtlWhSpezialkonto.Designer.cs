namespace KiSS4.Sozialhilfe
{
   public partial class CtlWhSpezialkonto
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

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlWhSpezialkonto));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panHeader = new System.Windows.Forms.Panel();
            this.btnKuerzungGrau = new KiSS4.Gui.KissButton();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblNameSpezkonto = new KiSS4.Gui.KissLabel();
            this.grdBgSpezkonto = new KiSS4.Gui.KissGrid();
            this.qryBgSpezkonto = new KiSS4.DB.SqlQuery(this.components);
            this.grvBgSpezkonto = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNameSpezkonto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartSaldo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetragProMonat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKuerzungAnteilGBL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKuerzungLaufzeit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKuerzungStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaldo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbschlussgrund = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtAktiv = new KiSS4.Gui.KissCheckEdit();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.edtNameSpezkonto = new KiSS4.Gui.KissTextEdit();
            this.btnAbschliessenUndo = new KiSS4.Gui.KissButton();
            this.btnAbschliessen = new KiSS4.Gui.KissButton();
            this.panBgKostenartID = new System.Windows.Forms.Panel();
            this.lblBgKostenartID = new KiSS4.Gui.KissLabel();
            this.edtBgKostenartID = new KiSS4.Gui.KissLookUpEdit();
            this.btnKuerzungFreigeben = new KiSS4.Gui.KissButton();
            this.panBgPositionsartID = new System.Windows.Forms.Panel();
            this.lblBgPositionsart = new KiSS4.Gui.KissLabel();
            this.edtBgPositionsartID = new KiSS4.Gui.KissLookUpEdit();
            this.btnKuerzungAufheben = new KiSS4.Gui.KissButton();
            this.panBaPersonID = new System.Windows.Forms.Panel();
            this.lblBaPersonID = new KiSS4.Gui.KissLabel();
            this.edtBaPersonID = new KiSS4.Gui.KissLookUpEdit();
            this.panBaInstitutionID = new System.Windows.Forms.Panel();
            this.edtInstitution = new KiSS4.Gui.KissButtonEdit();
            this.lblInstitutionID = new KiSS4.Gui.KissLabel();
            this.panDetail = new System.Windows.Forms.Panel();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.lblDatumBisMonat = new KiSS4.Gui.KissLabel();
            this.lblCHF2 = new KiSS4.Gui.KissLabel();
            this.edtDatumBisJahr = new KiSS4.Gui.KissCalcEdit();
            this.lblBetragProMonat = new KiSS4.Gui.KissLabel();
            this.edtDatumBisMonat = new KiSS4.Gui.KissLookUpEdit();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.lblDatumVonMonat = new KiSS4.Gui.KissLabel();
            this.edtDatumVonJahr = new KiSS4.Gui.KissCalcEdit();
            this.lblCHF1 = new KiSS4.Gui.KissLabel();
            this.edtDatumVonMonat = new KiSS4.Gui.KissLookUpEdit();
            this.edtKuerzungLaufzeit = new KiSS4.Gui.KissCalcEdit();
            this.edtBetragProMonat = new KiSS4.Gui.KissCalcEdit();
            this.edtKuerzungAnteilGBL = new KiSS4.Gui.KissCalcEdit();
            this.lblStartSaldo = new KiSS4.Gui.KissLabel();
            this.edtStartSaldo = new KiSS4.Gui.KissCalcEdit();
            this.panKontoblatt = new System.Windows.Forms.Panel();
            this.grdBgPosition = new KiSS4.Gui.KissGrid();
            this.qryBgPosition = new KiSS4.DB.SqlQuery(this.components);
            this.grvBgPosition = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetragGutschrift = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetragBelastung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaldo2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFreigegeben = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungstext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGesperrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblKontoblatt = new KiSS4.Gui.KissLabel();
            this.edtOhneEinzelzahlung = new KiSS4.Gui.KissCheckEdit();
            this.qryBaPerson = new KiSS4.DB.SqlQuery(this.components);
            this.qryBgKostenart = new KiSS4.DB.SqlQuery(this.components);
            this.panAbschliessen = new System.Windows.Forms.Panel();
            this.edtRueckerstattung = new KiSS4.Gui.KissLookUpEdit();
            this.lblBegruendungAbschluss = new KiSS4.Gui.KissLabel();
            this.edtBemerkungAbschluss = new KiSS4.Gui.KissMemoEdit();
            this.lblRueckerstattung = new KiSS4.Gui.KissLabel();
            this.panHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameSpezkonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBgSpezkonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgSpezkonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgSpezkonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAktiv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameSpezkonto.Properties)).BeginInit();
            this.panBgKostenartID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgKostenartID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKostenartID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKostenartID.Properties)).BeginInit();
            this.panBgPositionsartID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgPositionsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionsartID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionsartID.Properties)).BeginInit();
            this.panBaPersonID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            this.panBaInstitutionID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtInstitution.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInstitutionID)).BeginInit();
            this.panDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBisMonat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHF2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBisJahr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetragProMonat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBisMonat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBisMonat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVonMonat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVonJahr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHF1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVonMonat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVonMonat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKuerzungLaufzeit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetragProMonat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKuerzungAnteilGBL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStartSaldo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStartSaldo.Properties)).BeginInit();
            this.panKontoblatt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontoblatt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOhneEinzelzahlung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgKostenart)).BeginInit();
            this.panAbschliessen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtRueckerstattung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRueckerstattung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBegruendungAbschluss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkungAbschluss.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRueckerstattung)).BeginInit();
            this.SuspendLayout();
            // 
            // panHeader
            // 
            this.panHeader.Controls.Add(this.btnKuerzungGrau);
            this.panHeader.Controls.Add(this.picTitel);
            this.panHeader.Controls.Add(this.lblNameSpezkonto);
            this.panHeader.Controls.Add(this.grdBgSpezkonto);
            this.panHeader.Controls.Add(this.edtAktiv);
            this.panHeader.Controls.Add(this.lblTitel);
            this.panHeader.Controls.Add(this.edtNameSpezkonto);
            this.panHeader.Controls.Add(this.btnAbschliessenUndo);
            this.panHeader.Controls.Add(this.btnAbschliessen);
            this.panHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panHeader.Location = new System.Drawing.Point(0, 0);
            this.panHeader.Name = "panHeader";
            this.panHeader.Size = new System.Drawing.Size(705, 184);
            this.panHeader.TabIndex = 0;
            // 
            // btnKuerzungGrau
            // 
            this.btnKuerzungGrau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKuerzungGrau.Location = new System.Drawing.Point(522, 155);
            this.btnKuerzungGrau.Name = "btnKuerzungGrau";
            this.btnKuerzungGrau.Size = new System.Drawing.Size(162, 24);
            this.btnKuerzungGrau.TabIndex = 105;
            this.btnKuerzungGrau.Text = "-> \'In Vorbereitung\'";
            this.btnKuerzungGrau.UseVisualStyleBackColor = false;
            this.btnKuerzungGrau.Visible = false;
            this.btnKuerzungGrau.Click += new System.EventHandler(this.btnKuerzungGrau_Click);
            // 
            // picTitel
            // 
            this.picTitel.Location = new System.Drawing.Point(8, 5);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 104;
            this.picTitel.TabStop = false;
            // 
            // lblNameSpezkonto
            // 
            this.lblNameSpezkonto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNameSpezkonto.Location = new System.Drawing.Point(7, 155);
            this.lblNameSpezkonto.Name = "lblNameSpezkonto";
            this.lblNameSpezkonto.Size = new System.Drawing.Size(119, 24);
            this.lblNameSpezkonto.TabIndex = 3;
            this.lblNameSpezkonto.Text = "Bezeichnung";
            this.lblNameSpezkonto.UseCompatibleTextRendering = true;
            // 
            // grdBgSpezkonto
            // 
            this.grdBgSpezkonto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdBgSpezkonto.DataSource = this.qryBgSpezkonto;
            // 
            // 
            // 
            this.grdBgSpezkonto.EmbeddedNavigator.Name = "";
            this.grdBgSpezkonto.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBgSpezkonto.Location = new System.Drawing.Point(7, 29);
            this.grdBgSpezkonto.MainView = this.grvBgSpezkonto;
            this.grdBgSpezkonto.Name = "grdBgSpezkonto";
            this.grdBgSpezkonto.Size = new System.Drawing.Size(692, 120);
            this.grdBgSpezkonto.TabIndex = 1;
            this.grdBgSpezkonto.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBgSpezkonto});
            // 
            // qryBgSpezkonto
            // 
            this.qryBgSpezkonto.AutoApplyUserRights = false;
            this.qryBgSpezkonto.CanDelete = true;
            this.qryBgSpezkonto.CanInsert = true;
            this.qryBgSpezkonto.CanUpdate = true;
            this.qryBgSpezkonto.HostControl = this;
            this.qryBgSpezkonto.SelectStatement = resources.GetString("qryBgSpezkonto.SelectStatement");
            this.qryBgSpezkonto.TableName = "BgSpezkonto";
            this.qryBgSpezkonto.AfterDelete += new System.EventHandler(this.qryBgSpezkonto_AfterDelete);
            this.qryBgSpezkonto.AfterInsert += new System.EventHandler(this.qryBgSpezkonto_AfterInsert);
            this.qryBgSpezkonto.AfterPost += new System.EventHandler(this.qryBgSpezkonto_AfterPost);
            this.qryBgSpezkonto.BeforeDelete += new System.EventHandler(this.qryBgSpezkonto_BeforeDelete);
            this.qryBgSpezkonto.BeforeDeleteQuestion += new System.EventHandler(this.qryBgSpezkonto_BeforeDeleteQuestion);
            this.qryBgSpezkonto.BeforePost += new System.EventHandler(this.qryBgSpezkonto_BeforePost);
            this.qryBgSpezkonto.ColumnChanged += new System.Data.DataColumnChangeEventHandler(this.qryBgSpezkonto_ColumnChanged);
            this.qryBgSpezkonto.PositionChanged += new System.EventHandler(this.qryBgSpezkonto_PositionChanged);
            // 
            // grvBgSpezkonto
            // 
            this.grvBgSpezkonto.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBgSpezkonto.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgSpezkonto.Appearance.Empty.Options.UseBackColor = true;
            this.grvBgSpezkonto.Appearance.Empty.Options.UseFont = true;
            this.grvBgSpezkonto.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgSpezkonto.Appearance.EvenRow.Options.UseFont = true;
            this.grvBgSpezkonto.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBgSpezkonto.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgSpezkonto.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBgSpezkonto.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBgSpezkonto.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBgSpezkonto.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBgSpezkonto.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBgSpezkonto.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgSpezkonto.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBgSpezkonto.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBgSpezkonto.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBgSpezkonto.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBgSpezkonto.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBgSpezkonto.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBgSpezkonto.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBgSpezkonto.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBgSpezkonto.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBgSpezkonto.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBgSpezkonto.Appearance.GroupRow.Options.UseFont = true;
            this.grvBgSpezkonto.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBgSpezkonto.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBgSpezkonto.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBgSpezkonto.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBgSpezkonto.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBgSpezkonto.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBgSpezkonto.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBgSpezkonto.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBgSpezkonto.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgSpezkonto.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBgSpezkonto.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBgSpezkonto.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBgSpezkonto.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBgSpezkonto.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBgSpezkonto.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBgSpezkonto.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgSpezkonto.Appearance.OddRow.Options.UseFont = true;
            this.grvBgSpezkonto.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBgSpezkonto.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgSpezkonto.Appearance.Row.Options.UseBackColor = true;
            this.grvBgSpezkonto.Appearance.Row.Options.UseFont = true;
            this.grvBgSpezkonto.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgSpezkonto.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBgSpezkonto.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBgSpezkonto.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBgSpezkonto.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBgSpezkonto.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNameSpezkonto,
            this.colStartSaldo,
            this.colBetragProMonat,
            this.colKuerzungAnteilGBL,
            this.colKuerzungLaufzeit,
            this.colKuerzungStatus,
            this.colSaldo,
            this.colDatumVon,
            this.colDatumBis,
            this.colAbschlussgrund});
            this.grvBgSpezkonto.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBgSpezkonto.GridControl = this.grdBgSpezkonto;
            this.grvBgSpezkonto.Name = "grvBgSpezkonto";
            this.grvBgSpezkonto.OptionsBehavior.Editable = false;
            this.grvBgSpezkonto.OptionsCustomization.AllowFilter = false;
            this.grvBgSpezkonto.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBgSpezkonto.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBgSpezkonto.OptionsNavigation.UseTabKey = false;
            this.grvBgSpezkonto.OptionsView.ColumnAutoWidth = false;
            this.grvBgSpezkonto.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBgSpezkonto.OptionsView.ShowGroupPanel = false;
            this.grvBgSpezkonto.OptionsView.ShowIndicator = false;
            // 
            // colNameSpezkonto
            // 
            this.colNameSpezkonto.Caption = "Bezeichnung";
            this.colNameSpezkonto.FieldName = "NameSpezkonto";
            this.colNameSpezkonto.Name = "colNameSpezkonto";
            this.colNameSpezkonto.Visible = true;
            this.colNameSpezkonto.VisibleIndex = 0;
            this.colNameSpezkonto.Width = 265;
            // 
            // colStartSaldo
            // 
            this.colStartSaldo.Caption = "Startsaldo";
            this.colStartSaldo.DisplayFormat.FormatString = "N2";
            this.colStartSaldo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colStartSaldo.FieldName = "StartSaldo";
            this.colStartSaldo.Name = "colStartSaldo";
            this.colStartSaldo.Visible = true;
            this.colStartSaldo.VisibleIndex = 1;
            this.colStartSaldo.Width = 70;
            // 
            // colBetragProMonat
            // 
            this.colBetragProMonat.Caption = "Monatlich";
            this.colBetragProMonat.DisplayFormat.FormatString = "n2";
            this.colBetragProMonat.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetragProMonat.FieldName = "BetragProMonat";
            this.colBetragProMonat.Name = "colBetragProMonat";
            this.colBetragProMonat.Visible = true;
            this.colBetragProMonat.VisibleIndex = 2;
            this.colBetragProMonat.Width = 80;
            // 
            // colKuerzungAnteilGBL
            // 
            this.colKuerzungAnteilGBL.Caption = "% GB";
            this.colKuerzungAnteilGBL.DisplayFormat.FormatString = "n1";
            this.colKuerzungAnteilGBL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colKuerzungAnteilGBL.FieldName = "KuerzungAnteilGBL";
            this.colKuerzungAnteilGBL.Name = "colKuerzungAnteilGBL";
            this.colKuerzungAnteilGBL.Visible = true;
            this.colKuerzungAnteilGBL.VisibleIndex = 3;
            this.colKuerzungAnteilGBL.Width = 46;
            // 
            // colKuerzungLaufzeit
            // 
            this.colKuerzungLaufzeit.Caption = "Laufzeit";
            this.colKuerzungLaufzeit.DisplayFormat.FormatString = "n0";
            this.colKuerzungLaufzeit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colKuerzungLaufzeit.FieldName = "KuerzungLaufzeitMonate";
            this.colKuerzungLaufzeit.Name = "colKuerzungLaufzeit";
            this.colKuerzungLaufzeit.Visible = true;
            this.colKuerzungLaufzeit.VisibleIndex = 5;
            this.colKuerzungLaufzeit.Width = 60;
            // 
            // colKuerzungStatus
            // 
            this.colKuerzungStatus.Caption = "Status";
            this.colKuerzungStatus.FieldName = "BewilligungStatusCode";
            this.colKuerzungStatus.Name = "colKuerzungStatus";
            this.colKuerzungStatus.Visible = true;
            this.colKuerzungStatus.VisibleIndex = 8;
            // 
            // colSaldo
            // 
            this.colSaldo.Caption = "Saldo";
            this.colSaldo.DisplayFormat.FormatString = "n2";
            this.colSaldo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSaldo.FieldName = "Saldo";
            this.colSaldo.Name = "colSaldo";
            this.colSaldo.Visible = true;
            this.colSaldo.VisibleIndex = 4;
            this.colSaldo.Width = 80;
            // 
            // colDatumVon
            // 
            this.colDatumVon.Caption = "gültig von";
            this.colDatumVon.FieldName = "DatumVon";
            this.colDatumVon.Name = "colDatumVon";
            this.colDatumVon.Visible = true;
            this.colDatumVon.VisibleIndex = 6;
            // 
            // colDatumBis
            // 
            this.colDatumBis.Caption = "gültig bis";
            this.colDatumBis.FieldName = "DatumBis";
            this.colDatumBis.Name = "colDatumBis";
            this.colDatumBis.Visible = true;
            this.colDatumBis.VisibleIndex = 7;
            // 
            // colAbschlussgrund
            // 
            this.colAbschlussgrund.Caption = "Abschlussgrund";
            this.colAbschlussgrund.FieldName = "AbschlussgrundCode";
            this.colAbschlussgrund.Name = "colAbschlussgrund";
            this.colAbschlussgrund.Visible = true;
            this.colAbschlussgrund.VisibleIndex = 9;
            this.colAbschlussgrund.Width = 100;
            // 
            // edtAktiv
            // 
            this.edtAktiv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtAktiv.EditValue = false;
            this.edtAktiv.Location = new System.Drawing.Point(625, 5);
            this.edtAktiv.Name = "edtAktiv";
            this.edtAktiv.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAktiv.Properties.Appearance.Options.UseBackColor = true;
            this.edtAktiv.Properties.Caption = "nur aktive";
            this.edtAktiv.Size = new System.Drawing.Size(72, 19);
            this.edtAktiv.TabIndex = 0;
            this.edtAktiv.CheckedChanged += new System.EventHandler(this.editAktiv_CheckedChanged);
            this.edtAktiv.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.editAktiv_EditValueChanging);
            // 
            // lblTitel
            // 
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(30, 5);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(520, 16);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "{0}";
            this.lblTitel.UseCompatibleTextRendering = true;
            // 
            // edtNameSpezkonto
            // 
            this.edtNameSpezkonto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtNameSpezkonto.DataMember = "NameSpezkonto";
            this.edtNameSpezkonto.DataSource = this.qryBgSpezkonto;
            this.edtNameSpezkonto.Location = new System.Drawing.Point(132, 155);
            this.edtNameSpezkonto.Name = "edtNameSpezkonto";
            this.edtNameSpezkonto.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNameSpezkonto.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNameSpezkonto.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNameSpezkonto.Properties.Appearance.Options.UseBackColor = true;
            this.edtNameSpezkonto.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNameSpezkonto.Properties.Appearance.Options.UseFont = true;
            this.edtNameSpezkonto.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNameSpezkonto.Size = new System.Drawing.Size(376, 24);
            this.edtNameSpezkonto.TabIndex = 2;
            // 
            // btnAbschliessenUndo
            // 
            this.btnAbschliessenUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbschliessenUndo.Location = new System.Drawing.Point(522, 155);
            this.btnAbschliessenUndo.Name = "btnAbschliessenUndo";
            this.btnAbschliessenUndo.Size = new System.Drawing.Size(162, 24);
            this.btnAbschliessenUndo.TabIndex = 107;
            this.btnAbschliessenUndo.Text = "Abschliessen rückgängig";
            this.btnAbschliessenUndo.UseVisualStyleBackColor = false;
            this.btnAbschliessenUndo.Visible = false;
            this.btnAbschliessenUndo.Click += new System.EventHandler(this.btnAbschliessenUndo_Click);
            // 
            // btnAbschliessen
            // 
            this.btnAbschliessen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbschliessen.Location = new System.Drawing.Point(522, 155);
            this.btnAbschliessen.Name = "btnAbschliessen";
            this.btnAbschliessen.Size = new System.Drawing.Size(162, 24);
            this.btnAbschliessen.TabIndex = 106;
            this.btnAbschliessen.Text = "Abschliessen";
            this.btnAbschliessen.UseVisualStyleBackColor = false;
            this.btnAbschliessen.Visible = false;
            this.btnAbschliessen.Click += new System.EventHandler(this.btnAbschliessen_Click);
            this.btnAbschliessen.Enter += new System.EventHandler(this.btnAbschliessen_Enter);
            this.btnAbschliessen.Leave += new System.EventHandler(this.btnAbschliessen_Leave);
            this.btnAbschliessen.MouseEnter += new System.EventHandler(this.btnAbschliessen_MouseEnter);
            this.btnAbschliessen.MouseLeave += new System.EventHandler(this.btnAbschliessen_MouseLeave);
            // 
            // panBgKostenartID
            // 
            this.panBgKostenartID.Controls.Add(this.lblBgKostenartID);
            this.panBgKostenartID.Controls.Add(this.edtBgKostenartID);
            this.panBgKostenartID.Dock = System.Windows.Forms.DockStyle.Top;
            this.panBgKostenartID.Location = new System.Drawing.Point(0, 184);
            this.panBgKostenartID.Name = "panBgKostenartID";
            this.panBgKostenartID.Size = new System.Drawing.Size(705, 28);
            this.panBgKostenartID.TabIndex = 1;
            // 
            // lblBgKostenartID
            // 
            this.lblBgKostenartID.Location = new System.Drawing.Point(7, 0);
            this.lblBgKostenartID.Name = "lblBgKostenartID";
            this.lblBgKostenartID.Size = new System.Drawing.Size(119, 24);
            this.lblBgKostenartID.TabIndex = 0;
            this.lblBgKostenartID.Text = "Belastung von";
            this.lblBgKostenartID.UseCompatibleTextRendering = true;
            // 
            // edtBgKostenartID
            // 
            this.edtBgKostenartID.DataMember = "BgKostenartID";
            this.edtBgKostenartID.DataSource = this.qryBgSpezkonto;
            this.edtBgKostenartID.Location = new System.Drawing.Point(132, 0);
            this.edtBgKostenartID.Name = "edtBgKostenartID";
            this.edtBgKostenartID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBgKostenartID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgKostenartID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgKostenartID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgKostenartID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgKostenartID.Properties.Appearance.Options.UseFont = true;
            this.edtBgKostenartID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBgKostenartID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgKostenartID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBgKostenartID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBgKostenartID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtBgKostenartID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtBgKostenartID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgKostenartID.Properties.NullText = "";
            this.edtBgKostenartID.Properties.ShowFooter = false;
            this.edtBgKostenartID.Properties.ShowHeader = false;
            this.edtBgKostenartID.Size = new System.Drawing.Size(376, 24);
            this.edtBgKostenartID.TabIndex = 0;
            // 
            // btnKuerzungFreigeben
            // 
            this.btnKuerzungFreigeben.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKuerzungFreigeben.Location = new System.Drawing.Point(522, 0);
            this.btnKuerzungFreigeben.Name = "btnKuerzungFreigeben";
            this.btnKuerzungFreigeben.Size = new System.Drawing.Size(162, 24);
            this.btnKuerzungFreigeben.TabIndex = 106;
            this.btnKuerzungFreigeben.Text = "Kürzung freigeben";
            this.btnKuerzungFreigeben.UseVisualStyleBackColor = false;
            this.btnKuerzungFreigeben.Visible = false;
            this.btnKuerzungFreigeben.Click += new System.EventHandler(this.btnKuerzungFreigeben_Click);
            // 
            // panBgPositionsartID
            // 
            this.panBgPositionsartID.Controls.Add(this.lblBgPositionsart);
            this.panBgPositionsartID.Controls.Add(this.edtBgPositionsartID);
            this.panBgPositionsartID.Dock = System.Windows.Forms.DockStyle.Top;
            this.panBgPositionsartID.Location = new System.Drawing.Point(0, 212);
            this.panBgPositionsartID.Name = "panBgPositionsartID";
            this.panBgPositionsartID.Size = new System.Drawing.Size(705, 28);
            this.panBgPositionsartID.TabIndex = 2;
            // 
            // lblBgPositionsart
            // 
            this.lblBgPositionsart.Location = new System.Drawing.Point(7, 0);
            this.lblBgPositionsart.Name = "lblBgPositionsart";
            this.lblBgPositionsart.Size = new System.Drawing.Size(119, 24);
            this.lblBgPositionsart.TabIndex = 0;
            this.lblBgPositionsart.Text = "Gutschrift auf";
            this.lblBgPositionsart.UseCompatibleTextRendering = true;
            // 
            // edtBgPositionsartID
            // 
            this.edtBgPositionsartID.DataMember = "BgPositionsartID";
            this.edtBgPositionsartID.DataSource = this.qryBgSpezkonto;
            this.edtBgPositionsartID.Location = new System.Drawing.Point(132, 0);
            this.edtBgPositionsartID.Name = "edtBgPositionsartID";
            this.edtBgPositionsartID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBgPositionsartID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgPositionsartID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgPositionsartID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgPositionsartID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgPositionsartID.Properties.Appearance.Options.UseFont = true;
            this.edtBgPositionsartID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBgPositionsartID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgPositionsartID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBgPositionsartID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBgPositionsartID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtBgPositionsartID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtBgPositionsartID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgPositionsartID.Properties.NullText = "";
            this.edtBgPositionsartID.Properties.ShowFooter = false;
            this.edtBgPositionsartID.Properties.ShowHeader = false;
            this.edtBgPositionsartID.Size = new System.Drawing.Size(376, 24);
            this.edtBgPositionsartID.TabIndex = 0;
            // 
            // btnKuerzungAufheben
            // 
            this.btnKuerzungAufheben.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKuerzungAufheben.Location = new System.Drawing.Point(522, 2);
            this.btnKuerzungAufheben.Name = "btnKuerzungAufheben";
            this.btnKuerzungAufheben.Size = new System.Drawing.Size(162, 24);
            this.btnKuerzungAufheben.TabIndex = 106;
            this.btnKuerzungAufheben.Text = "Kürzung aufheben";
            this.btnKuerzungAufheben.UseVisualStyleBackColor = false;
            this.btnKuerzungAufheben.Visible = false;
            this.btnKuerzungAufheben.Click += new System.EventHandler(this.btnKuerzungAufheben_Click);
            // 
            // panBaPersonID
            // 
            this.panBaPersonID.Controls.Add(this.btnKuerzungFreigeben);
            this.panBaPersonID.Controls.Add(this.lblBaPersonID);
            this.panBaPersonID.Controls.Add(this.edtBaPersonID);
            this.panBaPersonID.Dock = System.Windows.Forms.DockStyle.Top;
            this.panBaPersonID.Location = new System.Drawing.Point(0, 240);
            this.panBaPersonID.Name = "panBaPersonID";
            this.panBaPersonID.Size = new System.Drawing.Size(705, 28);
            this.panBaPersonID.TabIndex = 3;
            // 
            // lblBaPersonID
            // 
            this.lblBaPersonID.Location = new System.Drawing.Point(7, 0);
            this.lblBaPersonID.Name = "lblBaPersonID";
            this.lblBaPersonID.Size = new System.Drawing.Size(119, 24);
            this.lblBaPersonID.TabIndex = 0;
            this.lblBaPersonID.Text = "Person";
            this.lblBaPersonID.UseCompatibleTextRendering = true;
            // 
            // edtBaPersonID
            // 
            this.edtBaPersonID.DataMember = "BaPersonID";
            this.edtBaPersonID.DataSource = this.qryBgSpezkonto;
            this.edtBaPersonID.Location = new System.Drawing.Point(132, 0);
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
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtBaPersonID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaPersonID.Properties.NullText = "";
            this.edtBaPersonID.Properties.ShowFooter = false;
            this.edtBaPersonID.Properties.ShowHeader = false;
            this.edtBaPersonID.Size = new System.Drawing.Size(376, 24);
            this.edtBaPersonID.TabIndex = 0;
            // 
            // panBaInstitutionID
            // 
            this.panBaInstitutionID.Controls.Add(this.edtInstitution);
            this.panBaInstitutionID.Controls.Add(this.lblInstitutionID);
            this.panBaInstitutionID.Dock = System.Windows.Forms.DockStyle.Top;
            this.panBaInstitutionID.Location = new System.Drawing.Point(0, 268);
            this.panBaInstitutionID.Name = "panBaInstitutionID";
            this.panBaInstitutionID.Size = new System.Drawing.Size(705, 28);
            this.panBaInstitutionID.TabIndex = 4;
            // 
            // edtInstitution
            // 
            this.edtInstitution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtInstitution.DataMember = "InstitutionName";
            this.edtInstitution.DataSource = this.qryBgSpezkonto;
            this.edtInstitution.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtInstitution.Location = new System.Drawing.Point(132, 0);
            this.edtInstitution.Name = "edtInstitution";
            this.edtInstitution.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtInstitution.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtInstitution.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtInstitution.Properties.Appearance.Options.UseBackColor = true;
            this.edtInstitution.Properties.Appearance.Options.UseBorderColor = true;
            this.edtInstitution.Properties.Appearance.Options.UseFont = true;
            this.edtInstitution.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtInstitution.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtInstitution.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtInstitution.Properties.Name = "editOrganisationName.Properties";
            this.edtInstitution.Properties.ReadOnly = true;
            this.edtInstitution.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtInstitution.Size = new System.Drawing.Size(376, 24);
            this.edtInstitution.TabIndex = 1;
            this.edtInstitution.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtInstitution_UserModifiedFld);
            // 
            // lblInstitutionID
            // 
            this.lblInstitutionID.Location = new System.Drawing.Point(7, 0);
            this.lblInstitutionID.Name = "lblInstitutionID";
            this.lblInstitutionID.Size = new System.Drawing.Size(119, 24);
            this.lblInstitutionID.TabIndex = 0;
            this.lblInstitutionID.Text = "Institution";
            this.lblInstitutionID.UseCompatibleTextRendering = true;
            // 
            // panDetail
            // 
            this.panDetail.Controls.Add(this.btnKuerzungAufheben);
            this.panDetail.Controls.Add(this.lblBemerkung);
            this.panDetail.Controls.Add(this.lblDatumBisMonat);
            this.panDetail.Controls.Add(this.lblCHF2);
            this.panDetail.Controls.Add(this.edtDatumBisJahr);
            this.panDetail.Controls.Add(this.lblBetragProMonat);
            this.panDetail.Controls.Add(this.edtDatumBisMonat);
            this.panDetail.Controls.Add(this.edtBemerkung);
            this.panDetail.Controls.Add(this.lblDatumVonMonat);
            this.panDetail.Controls.Add(this.edtDatumVonJahr);
            this.panDetail.Controls.Add(this.lblCHF1);
            this.panDetail.Controls.Add(this.edtDatumVonMonat);
            this.panDetail.Controls.Add(this.edtKuerzungLaufzeit);
            this.panDetail.Controls.Add(this.edtBetragProMonat);
            this.panDetail.Controls.Add(this.edtKuerzungAnteilGBL);
            this.panDetail.Controls.Add(this.lblStartSaldo);
            this.panDetail.Controls.Add(this.edtStartSaldo);
            this.panDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.panDetail.Location = new System.Drawing.Point(0, 296);
            this.panDetail.Name = "panDetail";
            this.panDetail.Size = new System.Drawing.Size(705, 104);
            this.panDetail.TabIndex = 5;
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.Location = new System.Drawing.Point(7, 62);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(119, 24);
            this.lblBemerkung.TabIndex = 12;
            this.lblBemerkung.Text = "Bemerkungen";
            this.lblBemerkung.UseCompatibleTextRendering = true;
            // 
            // lblDatumBisMonat
            // 
            this.lblDatumBisMonat.Location = new System.Drawing.Point(316, 32);
            this.lblDatumBisMonat.Name = "lblDatumBisMonat";
            this.lblDatumBisMonat.Size = new System.Drawing.Size(58, 24);
            this.lblDatumBisMonat.TabIndex = 9;
            this.lblDatumBisMonat.Text = "gültig bis";
            this.lblDatumBisMonat.UseCompatibleTextRendering = true;
            // 
            // lblCHF2
            // 
            this.lblCHF2.Location = new System.Drawing.Point(231, 32);
            this.lblCHF2.Name = "lblCHF2";
            this.lblCHF2.Size = new System.Drawing.Size(54, 24);
            this.lblCHF2.TabIndex = 8;
            this.lblCHF2.Text = "CHF";
            this.lblCHF2.UseCompatibleTextRendering = true;
            // 
            // edtDatumBisJahr
            // 
            this.edtDatumBisJahr.DataMember = "DatumBisJahr";
            this.edtDatumBisJahr.DataSource = this.qryBgSpezkonto;
            this.edtDatumBisJahr.Location = new System.Drawing.Point(460, 32);
            this.edtDatumBisJahr.Name = "edtDatumBisJahr";
            this.edtDatumBisJahr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBisJahr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBisJahr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBisJahr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBisJahr.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBisJahr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBisJahr.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBisJahr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtDatumBisJahr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBisJahr.Properties.DisplayFormat.FormatString = "g";
            this.edtDatumBisJahr.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtDatumBisJahr.Properties.EditFormat.FormatString = "g";
            this.edtDatumBisJahr.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtDatumBisJahr.Properties.Mask.EditMask = "g0";
            this.edtDatumBisJahr.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.edtDatumBisJahr.Size = new System.Drawing.Size(48, 24);
            this.edtDatumBisJahr.TabIndex = 5;
            // 
            // lblBetragProMonat
            // 
            this.lblBetragProMonat.Location = new System.Drawing.Point(7, 32);
            this.lblBetragProMonat.Name = "lblBetragProMonat";
            this.lblBetragProMonat.Size = new System.Drawing.Size(119, 24);
            this.lblBetragProMonat.TabIndex = 6;
            this.lblBetragProMonat.Text = "Monatlicher Betrag";
            this.lblBetragProMonat.UseCompatibleTextRendering = true;
            // 
            // edtDatumBisMonat
            // 
            this.edtDatumBisMonat.DataMember = "DatumBisMonat";
            this.edtDatumBisMonat.DataSource = this.qryBgSpezkonto;
            this.edtDatumBisMonat.Location = new System.Drawing.Point(380, 32);
            this.edtDatumBisMonat.Name = "edtDatumBisMonat";
            this.edtDatumBisMonat.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBisMonat.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBisMonat.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBisMonat.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBisMonat.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBisMonat.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBisMonat.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtDatumBisMonat.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBisMonat.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtDatumBisMonat.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtDatumBisMonat.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtDatumBisMonat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtDatumBisMonat.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBisMonat.Properties.NullText = "";
            this.edtDatumBisMonat.Properties.ShowFooter = false;
            this.edtDatumBisMonat.Properties.ShowHeader = false;
            this.edtDatumBisMonat.Size = new System.Drawing.Size(72, 24);
            this.edtDatumBisMonat.TabIndex = 4;
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryBgSpezkonto;
            this.edtBemerkung.Location = new System.Drawing.Point(132, 62);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(552, 39);
            this.edtBemerkung.TabIndex = 6;
            // 
            // lblDatumVonMonat
            // 
            this.lblDatumVonMonat.Location = new System.Drawing.Point(316, 2);
            this.lblDatumVonMonat.Name = "lblDatumVonMonat";
            this.lblDatumVonMonat.Size = new System.Drawing.Size(58, 24);
            this.lblDatumVonMonat.TabIndex = 3;
            this.lblDatumVonMonat.Text = "gültig von";
            this.lblDatumVonMonat.UseCompatibleTextRendering = true;
            // 
            // edtDatumVonJahr
            // 
            this.edtDatumVonJahr.DataMember = "DatumVonJahr";
            this.edtDatumVonJahr.DataSource = this.qryBgSpezkonto;
            this.edtDatumVonJahr.Location = new System.Drawing.Point(460, 2);
            this.edtDatumVonJahr.Name = "edtDatumVonJahr";
            this.edtDatumVonJahr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVonJahr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVonJahr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVonJahr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVonJahr.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVonJahr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVonJahr.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVonJahr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtDatumVonJahr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVonJahr.Properties.DisplayFormat.FormatString = "g";
            this.edtDatumVonJahr.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtDatumVonJahr.Properties.EditFormat.FormatString = "g";
            this.edtDatumVonJahr.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtDatumVonJahr.Properties.Mask.EditMask = "g0";
            this.edtDatumVonJahr.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.edtDatumVonJahr.Size = new System.Drawing.Size(48, 24);
            this.edtDatumVonJahr.TabIndex = 3;
            // 
            // lblCHF1
            // 
            this.lblCHF1.Location = new System.Drawing.Point(231, 2);
            this.lblCHF1.Name = "lblCHF1";
            this.lblCHF1.Size = new System.Drawing.Size(24, 24);
            this.lblCHF1.TabIndex = 2;
            this.lblCHF1.Text = "CHF";
            this.lblCHF1.UseCompatibleTextRendering = true;
            // 
            // edtDatumVonMonat
            // 
            this.edtDatumVonMonat.DataMember = "DatumVonMonat";
            this.edtDatumVonMonat.DataSource = this.qryBgSpezkonto;
            this.edtDatumVonMonat.Location = new System.Drawing.Point(380, 2);
            this.edtDatumVonMonat.Name = "edtDatumVonMonat";
            this.edtDatumVonMonat.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVonMonat.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVonMonat.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVonMonat.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVonMonat.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVonMonat.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVonMonat.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtDatumVonMonat.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVonMonat.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtDatumVonMonat.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtDatumVonMonat.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtDatumVonMonat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtDatumVonMonat.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVonMonat.Properties.NullText = "";
            this.edtDatumVonMonat.Properties.ShowFooter = false;
            this.edtDatumVonMonat.Properties.ShowHeader = false;
            this.edtDatumVonMonat.Size = new System.Drawing.Size(72, 24);
            this.edtDatumVonMonat.TabIndex = 2;
            // 
            // edtKuerzungLaufzeit
            // 
            this.edtKuerzungLaufzeit.DataMember = "KuerzungLaufzeitMonate";
            this.edtKuerzungLaufzeit.DataSource = this.qryBgSpezkonto;
            this.edtKuerzungLaufzeit.Location = new System.Drawing.Point(144, 32);
            this.edtKuerzungLaufzeit.Name = "edtKuerzungLaufzeit";
            this.edtKuerzungLaufzeit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtKuerzungLaufzeit.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKuerzungLaufzeit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKuerzungLaufzeit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKuerzungLaufzeit.Properties.Appearance.Options.UseBackColor = true;
            this.edtKuerzungLaufzeit.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKuerzungLaufzeit.Properties.Appearance.Options.UseFont = true;
            this.edtKuerzungLaufzeit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKuerzungLaufzeit.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKuerzungLaufzeit.Properties.DisplayFormat.FormatString = "n0";
            this.edtKuerzungLaufzeit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtKuerzungLaufzeit.Properties.EditFormat.FormatString = "n0";
            this.edtKuerzungLaufzeit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtKuerzungLaufzeit.Properties.Mask.EditMask = "g0";
            this.edtKuerzungLaufzeit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.edtKuerzungLaufzeit.Size = new System.Drawing.Size(96, 24);
            this.edtKuerzungLaufzeit.TabIndex = 1;
            this.edtKuerzungLaufzeit.Visible = false;
            // 
            // edtBetragProMonat
            // 
            this.edtBetragProMonat.DataMember = "BetragProMonat";
            this.edtBetragProMonat.DataSource = this.qryBgSpezkonto;
            this.edtBetragProMonat.Location = new System.Drawing.Point(132, 32);
            this.edtBetragProMonat.Name = "edtBetragProMonat";
            this.edtBetragProMonat.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBetragProMonat.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBetragProMonat.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetragProMonat.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetragProMonat.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetragProMonat.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetragProMonat.Properties.Appearance.Options.UseFont = true;
            this.edtBetragProMonat.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetragProMonat.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBetragProMonat.Properties.DisplayFormat.FormatString = "n2";
            this.edtBetragProMonat.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetragProMonat.Properties.EditFormat.FormatString = "n2";
            this.edtBetragProMonat.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetragProMonat.Size = new System.Drawing.Size(96, 24);
            this.edtBetragProMonat.TabIndex = 1;
            // 
            // edtKuerzungAnteilGBL
            // 
            this.edtKuerzungAnteilGBL.DataMember = "KuerzungAnteilGBL";
            this.edtKuerzungAnteilGBL.DataSource = this.qryBgSpezkonto;
            this.edtKuerzungAnteilGBL.Location = new System.Drawing.Point(144, 2);
            this.edtKuerzungAnteilGBL.Name = "edtKuerzungAnteilGBL";
            this.edtKuerzungAnteilGBL.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtKuerzungAnteilGBL.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKuerzungAnteilGBL.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKuerzungAnteilGBL.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKuerzungAnteilGBL.Properties.Appearance.Options.UseBackColor = true;
            this.edtKuerzungAnteilGBL.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKuerzungAnteilGBL.Properties.Appearance.Options.UseFont = true;
            this.edtKuerzungAnteilGBL.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKuerzungAnteilGBL.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKuerzungAnteilGBL.Properties.DisplayFormat.FormatString = "n1";
            this.edtKuerzungAnteilGBL.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtKuerzungAnteilGBL.Properties.EditFormat.FormatString = "n1";
            this.edtKuerzungAnteilGBL.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtKuerzungAnteilGBL.Size = new System.Drawing.Size(96, 24);
            this.edtKuerzungAnteilGBL.TabIndex = 0;
            this.edtKuerzungAnteilGBL.Visible = false;
            // 
            // lblStartSaldo
            // 
            this.lblStartSaldo.Location = new System.Drawing.Point(7, 2);
            this.lblStartSaldo.Name = "lblStartSaldo";
            this.lblStartSaldo.Size = new System.Drawing.Size(119, 24);
            this.lblStartSaldo.TabIndex = 0;
            this.lblStartSaldo.Text = "Startsaldo";
            this.lblStartSaldo.UseCompatibleTextRendering = true;
            // 
            // edtStartSaldo
            // 
            this.edtStartSaldo.DataMember = "StartSaldo";
            this.edtStartSaldo.DataSource = this.qryBgSpezkonto;
            this.edtStartSaldo.Location = new System.Drawing.Point(132, 2);
            this.edtStartSaldo.Name = "edtStartSaldo";
            this.edtStartSaldo.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtStartSaldo.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStartSaldo.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStartSaldo.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStartSaldo.Properties.Appearance.Options.UseBackColor = true;
            this.edtStartSaldo.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStartSaldo.Properties.Appearance.Options.UseFont = true;
            this.edtStartSaldo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStartSaldo.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStartSaldo.Properties.DisplayFormat.FormatString = "n2";
            this.edtStartSaldo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtStartSaldo.Properties.EditFormat.FormatString = "n2";
            this.edtStartSaldo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtStartSaldo.Size = new System.Drawing.Size(96, 24);
            this.edtStartSaldo.TabIndex = 0;
            // 
            // panKontoblatt
            // 
            this.panKontoblatt.Controls.Add(this.grdBgPosition);
            this.panKontoblatt.Controls.Add(this.lblKontoblatt);
            this.panKontoblatt.Controls.Add(this.edtOhneEinzelzahlung);
            this.panKontoblatt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panKontoblatt.Location = new System.Drawing.Point(0, 474);
            this.panKontoblatt.Name = "panKontoblatt";
            this.panKontoblatt.Size = new System.Drawing.Size(705, 242);
            this.panKontoblatt.TabIndex = 7;
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
            this.grdBgPosition.Location = new System.Drawing.Point(7, 35);
            this.grdBgPosition.MainView = this.grvBgPosition;
            this.grdBgPosition.Name = "grdBgPosition";
            this.grdBgPosition.Size = new System.Drawing.Size(692, 207);
            this.grdBgPosition.TabIndex = 16;
            this.grdBgPosition.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBgPosition});
            // 
            // qryBgPosition
            // 
            this.qryBgPosition.CanUpdate = true;
            this.qryBgPosition.HostControl = this;
            this.qryBgPosition.SelectStatement = resources.GetString("qryBgPosition.SelectStatement");
            this.qryBgPosition.BeforePost += new System.EventHandler(this.qryBgPosition_BeforePost);
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
            this.colDatum,
            this.colBetragGutschrift,
            this.colBetragBelastung,
            this.colSaldo2,
            this.colFreigegeben,
            this.colBuchungstext,
            this.colGesperrt});
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
            this.grvBgPosition.OptionsView.ShowFooter = true;
            this.grvBgPosition.OptionsView.ShowGroupPanel = false;
            this.grvBgPosition.OptionsView.ShowIndicator = false;
            this.grvBgPosition.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(this.grvBgPosition_CustomSummaryCalculate);
            // 
            // colDatum
            // 
            this.colDatum.Caption = "Monat";
            this.colDatum.DisplayFormat.FormatString = "{0:MMM yyyy}";
            this.colDatum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDatum.FieldName = "Datum";
            this.colDatum.Name = "colDatum";
            this.colDatum.Visible = true;
            this.colDatum.VisibleIndex = 0;
            this.colDatum.Width = 90;
            // 
            // colBetragGutschrift
            // 
            this.colBetragGutschrift.Caption = "Gutschrift";
            this.colBetragGutschrift.DisplayFormat.FormatString = "N2";
            this.colBetragGutschrift.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetragGutschrift.FieldName = "Gutschrift";
            this.colBetragGutschrift.Name = "colBetragGutschrift";
            this.colBetragGutschrift.SummaryItem.DisplayFormat = "{0:n2}";
            this.colBetragGutschrift.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colBetragGutschrift.Visible = true;
            this.colBetragGutschrift.VisibleIndex = 1;
            this.colBetragGutschrift.Width = 80;
            // 
            // colBetragBelastung
            // 
            this.colBetragBelastung.Caption = "Belastung";
            this.colBetragBelastung.DisplayFormat.FormatString = "N2";
            this.colBetragBelastung.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetragBelastung.FieldName = "Belastung";
            this.colBetragBelastung.Name = "colBetragBelastung";
            this.colBetragBelastung.SummaryItem.DisplayFormat = "{0:n2}";
            this.colBetragBelastung.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colBetragBelastung.Visible = true;
            this.colBetragBelastung.VisibleIndex = 2;
            this.colBetragBelastung.Width = 80;
            // 
            // colSaldo2
            // 
            this.colSaldo2.Caption = "Saldo";
            this.colSaldo2.DisplayFormat.FormatString = "N2";
            this.colSaldo2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSaldo2.FieldName = "Saldo";
            this.colSaldo2.Name = "colSaldo2";
            this.colSaldo2.SummaryItem.DisplayFormat = "{0:n2}";
            this.colSaldo2.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.colSaldo2.Visible = true;
            this.colSaldo2.VisibleIndex = 3;
            this.colSaldo2.Width = 80;
            // 
            // colFreigegeben
            // 
            this.colFreigegeben.Caption = "MB";
            this.colFreigegeben.FieldName = "Freigegeben";
            this.colFreigegeben.Name = "colFreigegeben";
            this.colFreigegeben.ToolTip = "freigegeben";
            this.colFreigegeben.Visible = true;
            this.colFreigegeben.VisibleIndex = 4;
            this.colFreigegeben.Width = 60;
            // 
            // colBuchungstext
            // 
            this.colBuchungstext.Caption = "Buchungstext";
            this.colBuchungstext.FieldName = "Buchungstext";
            this.colBuchungstext.Name = "colBuchungstext";
            this.colBuchungstext.Visible = true;
            this.colBuchungstext.VisibleIndex = 5;
            this.colBuchungstext.Width = 190;
            // 
            // colGesperrt
            // 
            this.colGesperrt.Caption = "gesperrt";
            this.colGesperrt.FieldName = "Gesperrt";
            this.colGesperrt.Name = "colGesperrt";
            this.colGesperrt.Width = 60;
            // 
            // lblKontoblatt
            // 
            this.lblKontoblatt.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblKontoblatt.Location = new System.Drawing.Point(7, 6);
            this.lblKontoblatt.Name = "lblKontoblatt";
            this.lblKontoblatt.Size = new System.Drawing.Size(119, 16);
            this.lblKontoblatt.TabIndex = 14;
            this.lblKontoblatt.Text = "Kontoblatt";
            this.lblKontoblatt.UseCompatibleTextRendering = true;
            // 
            // edtOhneEinzelzahlung
            // 
            this.edtOhneEinzelzahlung.DataMember = "OhneEinzelzahlung";
            this.edtOhneEinzelzahlung.DataSource = this.qryBgSpezkonto;
            this.edtOhneEinzelzahlung.Location = new System.Drawing.Point(132, 3);
            this.edtOhneEinzelzahlung.Name = "edtOhneEinzelzahlung";
            this.edtOhneEinzelzahlung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtOhneEinzelzahlung.Properties.Appearance.Options.UseBackColor = true;
            this.edtOhneEinzelzahlung.Properties.Caption = "Verrechnung ohne Einzelzahlung";
            this.edtOhneEinzelzahlung.Size = new System.Drawing.Size(216, 19);
            this.edtOhneEinzelzahlung.TabIndex = 7;
            // 
            // qryBaPerson
            // 
            this.qryBaPerson.HostControl = this;
            this.qryBaPerson.SelectStatement = resources.GetString("qryBaPerson.SelectStatement");
            // 
            // qryBgKostenart
            // 
            this.qryBgKostenart.HostControl = this;
            this.qryBgKostenart.SelectStatement = resources.GetString("qryBgKostenart.SelectStatement");
            // 
            // panAbschliessen
            // 
            this.panAbschliessen.Controls.Add(this.edtRueckerstattung);
            this.panAbschliessen.Controls.Add(this.lblBegruendungAbschluss);
            this.panAbschliessen.Controls.Add(this.edtBemerkungAbschluss);
            this.panAbschliessen.Controls.Add(this.lblRueckerstattung);
            this.panAbschliessen.Dock = System.Windows.Forms.DockStyle.Top;
            this.panAbschliessen.Location = new System.Drawing.Point(0, 400);
            this.panAbschliessen.Name = "panAbschliessen";
            this.panAbschliessen.Size = new System.Drawing.Size(705, 74);
            this.panAbschliessen.TabIndex = 6;
            // 
            // edtRueckerstattung
            // 
            this.edtRueckerstattung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtRueckerstattung.DataMember = "AbzahlungskontoRueckerstattungCode";
            this.edtRueckerstattung.DataSource = this.qryBgSpezkonto;
            this.edtRueckerstattung.Location = new System.Drawing.Point(132, 3);
            this.edtRueckerstattung.LOVName = "AbzahlungskontoRueckerstattung";
            this.edtRueckerstattung.Name = "edtRueckerstattung";
            this.edtRueckerstattung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtRueckerstattung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtRueckerstattung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtRueckerstattung.Properties.Appearance.Options.UseBackColor = true;
            this.edtRueckerstattung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtRueckerstattung.Properties.Appearance.Options.UseFont = true;
            this.edtRueckerstattung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtRueckerstattung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtRueckerstattung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtRueckerstattung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtRueckerstattung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtRueckerstattung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtRueckerstattung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtRueckerstattung.Properties.NullText = "";
            this.edtRueckerstattung.Properties.ShowFooter = false;
            this.edtRueckerstattung.Properties.ShowHeader = false;
            this.edtRueckerstattung.Size = new System.Drawing.Size(552, 24);
            this.edtRueckerstattung.TabIndex = 0;
            // 
            // lblBegruendungAbschluss
            // 
            this.lblBegruendungAbschluss.Location = new System.Drawing.Point(7, 33);
            this.lblBegruendungAbschluss.Name = "lblBegruendungAbschluss";
            this.lblBegruendungAbschluss.Size = new System.Drawing.Size(125, 24);
            this.lblBegruendungAbschluss.TabIndex = 12;
            this.lblBegruendungAbschluss.Text = "Begründung Abschluss";
            this.lblBegruendungAbschluss.UseCompatibleTextRendering = true;
            // 
            // edtBemerkungAbschluss
            // 
            this.edtBemerkungAbschluss.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBemerkungAbschluss.DataMember = "AbschlussBegruendung";
            this.edtBemerkungAbschluss.DataSource = this.qryBgSpezkonto;
            this.edtBemerkungAbschluss.Location = new System.Drawing.Point(132, 33);
            this.edtBemerkungAbschluss.Name = "edtBemerkungAbschluss";
            this.edtBemerkungAbschluss.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkungAbschluss.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkungAbschluss.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkungAbschluss.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkungAbschluss.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkungAbschluss.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkungAbschluss.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkungAbschluss.Size = new System.Drawing.Size(552, 39);
            this.edtBemerkungAbschluss.TabIndex = 1;
            // 
            // lblRueckerstattung
            // 
            this.lblRueckerstattung.Location = new System.Drawing.Point(7, 3);
            this.lblRueckerstattung.Name = "lblRueckerstattung";
            this.lblRueckerstattung.Size = new System.Drawing.Size(119, 24);
            this.lblRueckerstattung.TabIndex = 0;
            this.lblRueckerstattung.Text = "Rückerstattung";
            this.lblRueckerstattung.UseCompatibleTextRendering = true;
            // 
            // CtlWhSpezialkonto
            // 
            this.ActiveSQLQuery = this.qryBgSpezkonto;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(700, 580);
            this.Controls.Add(this.panKontoblatt);
            this.Controls.Add(this.panAbschliessen);
            this.Controls.Add(this.panDetail);
            this.Controls.Add(this.panBaInstitutionID);
            this.Controls.Add(this.panBaPersonID);
            this.Controls.Add(this.panBgPositionsartID);
            this.Controls.Add(this.panBgKostenartID);
            this.Controls.Add(this.panHeader);
            this.Name = "CtlWhSpezialkonto";
            this.Size = new System.Drawing.Size(705, 716);
            this.Load += new System.EventHandler(this.CtlWhSpezialkonto_Load);
            this.panHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameSpezkonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBgSpezkonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgSpezkonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgSpezkonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAktiv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameSpezkonto.Properties)).EndInit();
            this.panBgKostenartID.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblBgKostenartID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKostenartID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKostenartID)).EndInit();
            this.panBgPositionsartID.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblBgPositionsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionsartID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionsartID)).EndInit();
            this.panBaPersonID.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID)).EndInit();
            this.panBaInstitutionID.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtInstitution.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInstitutionID)).EndInit();
            this.panDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBisMonat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHF2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBisJahr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetragProMonat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBisMonat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBisMonat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVonMonat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVonJahr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHF1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVonMonat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVonMonat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKuerzungLaufzeit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetragProMonat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKuerzungAnteilGBL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStartSaldo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStartSaldo.Properties)).EndInit();
            this.panKontoblatt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontoblatt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOhneEinzelzahlung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgKostenart)).EndInit();
            this.panAbschliessen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtRueckerstattung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRueckerstattung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBegruendungAbschluss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkungAbschluss.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRueckerstattung)).EndInit();
            this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraGrid.Columns.GridColumn colBetragBelastung;
      private DevExpress.XtraGrid.Columns.GridColumn colBetragGutschrift;
      private DevExpress.XtraGrid.Columns.GridColumn colBetragProMonat;
      private DevExpress.XtraGrid.Columns.GridColumn colBuchungstext;
      private DevExpress.XtraGrid.Columns.GridColumn colDatum;
      private DevExpress.XtraGrid.Columns.GridColumn colDatumBis;
      private DevExpress.XtraGrid.Columns.GridColumn colDatumVon;
      private DevExpress.XtraGrid.Columns.GridColumn colFreigegeben;
      private DevExpress.XtraGrid.Columns.GridColumn colNameSpezkonto;
      private DevExpress.XtraGrid.Columns.GridColumn colSaldo;
      private DevExpress.XtraGrid.Columns.GridColumn colSaldo2;
      private DevExpress.XtraGrid.Columns.GridColumn colStartSaldo;
      private KiSS4.Gui.KissCheckEdit edtAktiv;
      private KiSS4.Gui.KissCalcEdit edtDatumBisJahr;
      private KiSS4.Gui.KissLookUpEdit edtDatumBisMonat;
      private KiSS4.Gui.KissCalcEdit edtDatumVonJahr;
      private KiSS4.Gui.KissLookUpEdit edtDatumVonMonat;
      private KiSS4.Gui.KissLookUpEdit edtBaPersonID;
      private KiSS4.Gui.KissMemoEdit edtBemerkung;
      private KiSS4.Gui.KissCalcEdit edtBetragProMonat;
      private KiSS4.Gui.KissLookUpEdit edtBgKostenartID;
      private KiSS4.Gui.KissLookUpEdit edtBgPositionsartID;
      private KiSS4.Gui.KissButtonEdit edtInstitution;
      private KiSS4.Gui.KissTextEdit edtNameSpezkonto;
      private KiSS4.Gui.KissCheckEdit edtOhneEinzelzahlung;
      private KiSS4.Gui.KissCalcEdit edtStartSaldo;
      private KiSS4.Gui.KissGrid grdBgPosition;
      private KiSS4.Gui.KissGrid grdBgSpezkonto;
      private DevExpress.XtraGrid.Views.Grid.GridView grvBgPosition;
      private DevExpress.XtraGrid.Views.Grid.GridView grvBgSpezkonto;
      private KiSS4.Gui.KissLabel lblDatumBisMonat;
      private KiSS4.Gui.KissLabel lblKontoblatt;
      private KiSS4.Gui.KissLabel lblBaPersonID;
      private KiSS4.Gui.KissLabel lblBemerkung;
      private KiSS4.Gui.KissLabel lblBetragProMonat;
      private KiSS4.Gui.KissLabel lblBgKostenartID;
      private KiSS4.Gui.KissLabel lblBgPositionsart;
      private KiSS4.Gui.KissLabel lblCHF1;
      private KiSS4.Gui.KissLabel lblCHF2;
      private KiSS4.Gui.KissLabel lblDatumVonMonat;
      private KiSS4.Gui.KissLabel lblInstitutionID;
      private KiSS4.Gui.KissLabel lblNameSpezkonto;
      private KiSS4.Gui.KissLabel lblStartSaldo;
      private KiSS4.Gui.KissLabel lblTitel;
      private System.Windows.Forms.Panel panBaInstitutionID;
      private System.Windows.Forms.Panel panBaPersonID;
      private System.Windows.Forms.Panel panBgKostenartID;
      private System.Windows.Forms.Panel panBgPositionsartID;
      private System.Windows.Forms.Panel panDetail;
      private System.Windows.Forms.Panel panKontoblatt;
      private System.Windows.Forms.Panel panHeader;
      private System.Windows.Forms.PictureBox picTitel;
      private KiSS4.DB.SqlQuery qryBaPerson;
      private KiSS4.DB.SqlQuery qryBgKostenart;
      private KiSS4.DB.SqlQuery qryBgPosition;
      private KiSS4.DB.SqlQuery qryBgSpezkonto;
      private DevExpress.XtraGrid.Columns.GridColumn colKuerzungAnteilGBL;
      private DevExpress.XtraGrid.Columns.GridColumn colKuerzungLaufzeit;
      private KiSS4.Gui.KissCalcEdit edtKuerzungLaufzeit;
      private KiSS4.Gui.KissCalcEdit edtKuerzungAnteilGBL;
      private KiSS4.Gui.KissButton btnKuerzungGrau;
      private KiSS4.Gui.KissButton btnKuerzungAufheben;
      private KiSS4.Gui.KissButton btnKuerzungFreigeben;
      private DevExpress.XtraGrid.Columns.GridColumn colKuerzungStatus;
      private DevExpress.XtraGrid.Columns.GridColumn colGesperrt;
      private System.Windows.Forms.Panel panAbschliessen;
      private Gui.KissLookUpEdit edtRueckerstattung;
      private Gui.KissLabel lblBegruendungAbschluss;
      private Gui.KissMemoEdit edtBemerkungAbschluss;
      private Gui.KissLabel lblRueckerstattung;
      private Gui.KissButton btnAbschliessenUndo;
      private Gui.KissButton btnAbschliessen;
      private DevExpress.XtraGrid.Columns.GridColumn colAbschlussgrund;
   }
}
