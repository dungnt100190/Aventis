namespace KiSS4.Arbeit
{
    partial class CtlKaAbklaerungVertieft
    {
        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKaAbklaerungVertieft));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject28 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject29 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject30 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject31 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject13 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject14 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject15 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject16 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject17 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject18 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject19 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject20 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject21 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject22 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject23 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblTitel = new System.Windows.Forms.Label();
            this.picTitle = new System.Windows.Forms.PictureBox();
            this.pnlHead = new System.Windows.Forms.Panel();
            this.grdPhasen = new KiSS4.Gui.KissGrid();
            this.qryAbklaerungVertieft = new KiSS4.DB.SqlQuery(this.components);
            this.gvAbklaerungVertieft = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModul = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPraesenz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeurteilung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.tabControlAbkl = new KiSS4.Gui.KissTabControlEx();
            this.tabPageModule = new SharpLibrary.WinControls.TabPageEx();
            this.edtDatumAustritt = new KiSS4.Gui.KissDateEdit();
            this.lblEinsatzBis = new KiSS4.Gui.KissLabel();
            this.lblEinsatzVon = new KiSS4.Gui.KissLabel();
            this.edtEinsatzBis = new KiSS4.Gui.KissDateEdit();
            this.edtEinsatzVon = new KiSS4.Gui.KissDateEdit();
            this.edtProbeeinsatzIn = new KiSS4.Gui.KissLookUpEdit();
            this.lblEinsatz = new KiSS4.Gui.KissLabel();
            this.lblKursAbbruch = new KiSS4.Gui.KissLabel();
            this.edtDatumKursAbbruch = new KiSS4.Gui.KissDateEdit();
            this.lblKursDetail = new KiSS4.Gui.KissLabel();
            this.edtKurs = new KiSS4.Gui.KissButtonEdit();
            this.lblKurs = new KiSS4.Gui.KissLabel();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.edtSchlussbericht = new KiSS4.Dokument.XDokument();
            this.lblSchlussbericht = new KiSS4.Gui.KissLabel();
            this.edtGrundDossierrueckgabe = new KiSS4.Gui.KissLookUpEdit();
            this.lblGrundDossierrückgabe = new KiSS4.Gui.KissLabel();
            this.edtIntegrationDok = new KiSS4.Dokument.XDokument();
            this.edtIntegrationCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblBeurteilung = new KiSS4.Gui.KissLabel();
            this.edtDatumIntegration = new KiSS4.Gui.KissDateEdit();
            this.edtPraesenz = new KiSS4.Gui.KissLookUpEdit();
            this.lblPraesenz = new KiSS4.Gui.KissLabel();
            this.edtStatusDossier = new KiSS4.Gui.KissLookUpEdit();
            this.lblStatusDossier = new KiSS4.Gui.KissLabel();
            this.edtModul = new KiSS4.Gui.KissLookUpEdit();
            this.lblModul = new KiSS4.Gui.KissLabel();
            this.lblDatum = new KiSS4.Gui.KissLabel();
            this.edtDatum = new KiSS4.Gui.KissDateEdit();
            this.tabPageProbe = new SharpLibrary.WinControls.TabPageEx();
            this.edtHatStattgefunden = new KiSS4.Gui.KissCheckEdit();
            this.qryProbeeinsatz = new KiSS4.DB.SqlQuery(this.components);
            this.edtDocProzessschritt = new KiSS4.Dokument.XDokument();
            this.edtProzessschritt = new KiSS4.Gui.KissLookUpEdit();
            this.grdProzessschritte = new KiSS4.Gui.KissGrid();
            this.grvProbeeinsatz = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProbeeinsatzDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProbeeinsatzProzesschritt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProbeeinsatzHatStattgefunden = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtZahlungDatum = new KiSS4.Gui.KissDateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            this.pnlHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPhasen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryAbklaerungVertieft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAbklaerungVertieft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            this.tabControlAbkl.SuspendLayout();
            this.tabPageModule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumAustritt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProbeeinsatzIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProbeeinsatzIn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKursAbbruch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumKursAbbruch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKursDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurs.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSchlussbericht.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSchlussbericht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrundDossierrueckgabe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrundDossierrueckgabe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundDossierrückgabe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIntegrationDok.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIntegrationCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIntegrationCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeurteilung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumIntegration.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPraesenz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPraesenz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPraesenz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusDossier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusDossier.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatusDossier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModul)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModul.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModul)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatum.Properties)).BeginInit();
            this.tabPageProbe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtHatStattgefunden.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryProbeeinsatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDocProzessschritt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProzessschritt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProzessschritt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProzessschritte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProbeeinsatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZahlungDatum.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblTitel.ForeColor = System.Drawing.Color.Black;
            this.lblTitel.Location = new System.Drawing.Point(35, 10);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(31, 15);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Titel";
            // 
            // picTitle
            // 
            this.picTitle.Image = ((System.Drawing.Image)(resources.GetObject("picTitle.Image")));
            this.picTitle.Location = new System.Drawing.Point(10, 9);
            this.picTitle.Name = "picTitle";
            this.picTitle.Size = new System.Drawing.Size(25, 20);
            this.picTitle.TabIndex = 105;
            this.picTitle.TabStop = false;
            // 
            // pnlHead
            // 
            this.pnlHead.Controls.Add(this.lblTitel);
            this.pnlHead.Controls.Add(this.picTitle);
            this.pnlHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHead.Location = new System.Drawing.Point(0, 0);
            this.pnlHead.Name = "pnlHead";
            this.pnlHead.Size = new System.Drawing.Size(860, 35);
            this.pnlHead.TabIndex = 0;
            // 
            // grdPhasen
            // 
            this.grdPhasen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdPhasen.DataSource = this.qryAbklaerungVertieft;
            // 
            // 
            // 
            this.grdPhasen.EmbeddedNavigator.Name = "";
            this.grdPhasen.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdPhasen.Location = new System.Drawing.Point(3, 38);
            this.grdPhasen.MainView = this.gvAbklaerungVertieft;
            this.grdPhasen.Margin = new System.Windows.Forms.Padding(0);
            this.grdPhasen.Name = "grdPhasen";
            this.grdPhasen.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1});
            this.grdPhasen.Size = new System.Drawing.Size(854, 178);
            this.grdPhasen.TabIndex = 1;
            this.grdPhasen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAbklaerungVertieft});
            // 
            // qryAbklaerungVertieft
            // 
            this.qryAbklaerungVertieft.CanDelete = true;
            this.qryAbklaerungVertieft.CanInsert = true;
            this.qryAbklaerungVertieft.CanUpdate = true;
            this.qryAbklaerungVertieft.HostControl = this;
            this.qryAbklaerungVertieft.SelectStatement = resources.GetString("qryAbklaerungVertieft.SelectStatement");
            this.qryAbklaerungVertieft.TableName = "KaAbklaerungVertieft";
            this.qryAbklaerungVertieft.AfterFill += new System.EventHandler(this.qryAbklaerungVertieft_AfterFill);
            this.qryAbklaerungVertieft.BeforeInsert += new System.EventHandler(this.qryAbklaerungVertieft_BeforeInsert);
            this.qryAbklaerungVertieft.AfterInsert += new System.EventHandler(this.qryAbklaerungVertieft_AfterInsert);
            this.qryAbklaerungVertieft.BeforePost += new System.EventHandler(this.qryAbklaerungVertieft_BeforePost);
            this.qryAbklaerungVertieft.AfterPost += new System.EventHandler(this.qryAbklaerungVertieft_AfterPost);
            this.qryAbklaerungVertieft.BeforeDeleteQuestion += new System.EventHandler(this.qryAbklaerungVertieft_BeforeDeleteQuestion);
            this.qryAbklaerungVertieft.BeforeDelete += new System.EventHandler(this.qryAbklaerungVertieft_BeforeDelete);
            this.qryAbklaerungVertieft.AfterDelete += new System.EventHandler(this.qryAbklaerungVertieft_AfterDelete);
            this.qryAbklaerungVertieft.PositionChanged += new System.EventHandler(this.qryAbklaerungVertieft_PositionChanged);
            // 
            // gvAbklaerungVertieft
            // 
            this.gvAbklaerungVertieft.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gvAbklaerungVertieft.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvAbklaerungVertieft.Appearance.Empty.Options.UseBackColor = true;
            this.gvAbklaerungVertieft.Appearance.Empty.Options.UseFont = true;
            this.gvAbklaerungVertieft.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvAbklaerungVertieft.Appearance.EvenRow.Options.UseFont = true;
            this.gvAbklaerungVertieft.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvAbklaerungVertieft.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvAbklaerungVertieft.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gvAbklaerungVertieft.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvAbklaerungVertieft.Appearance.FocusedCell.Options.UseFont = true;
            this.gvAbklaerungVertieft.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvAbklaerungVertieft.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvAbklaerungVertieft.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvAbklaerungVertieft.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gvAbklaerungVertieft.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvAbklaerungVertieft.Appearance.FocusedRow.Options.UseFont = true;
            this.gvAbklaerungVertieft.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gvAbklaerungVertieft.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gvAbklaerungVertieft.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gvAbklaerungVertieft.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gvAbklaerungVertieft.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvAbklaerungVertieft.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvAbklaerungVertieft.Appearance.GroupRow.Options.UseBackColor = true;
            this.gvAbklaerungVertieft.Appearance.GroupRow.Options.UseFont = true;
            this.gvAbklaerungVertieft.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvAbklaerungVertieft.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gvAbklaerungVertieft.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gvAbklaerungVertieft.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvAbklaerungVertieft.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvAbklaerungVertieft.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gvAbklaerungVertieft.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvAbklaerungVertieft.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gvAbklaerungVertieft.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvAbklaerungVertieft.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvAbklaerungVertieft.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvAbklaerungVertieft.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvAbklaerungVertieft.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gvAbklaerungVertieft.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gvAbklaerungVertieft.Appearance.HorzLine.Options.UseBackColor = true;
            this.gvAbklaerungVertieft.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvAbklaerungVertieft.Appearance.OddRow.Options.UseFont = true;
            this.gvAbklaerungVertieft.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gvAbklaerungVertieft.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvAbklaerungVertieft.Appearance.Row.Options.UseBackColor = true;
            this.gvAbklaerungVertieft.Appearance.Row.Options.UseFont = true;
            this.gvAbklaerungVertieft.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvAbklaerungVertieft.Appearance.SelectedRow.Options.UseFont = true;
            this.gvAbklaerungVertieft.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gvAbklaerungVertieft.Appearance.VertLine.Options.UseBackColor = true;
            this.gvAbklaerungVertieft.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gvAbklaerungVertieft.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatum,
            this.colModul,
            this.colStatus,
            this.colPraesenz,
            this.colBeurteilung});
            this.gvAbklaerungVertieft.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gvAbklaerungVertieft.GridControl = this.grdPhasen;
            this.gvAbklaerungVertieft.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.gvAbklaerungVertieft.Name = "gvAbklaerungVertieft";
            this.gvAbklaerungVertieft.OptionsBehavior.Editable = false;
            this.gvAbklaerungVertieft.OptionsCustomization.AllowFilter = false;
            this.gvAbklaerungVertieft.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gvAbklaerungVertieft.OptionsNavigation.AutoFocusNewRow = true;
            this.gvAbklaerungVertieft.OptionsNavigation.UseTabKey = false;
            this.gvAbklaerungVertieft.OptionsView.ColumnAutoWidth = false;
            this.gvAbklaerungVertieft.OptionsView.RowAutoHeight = true;
            this.gvAbklaerungVertieft.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvAbklaerungVertieft.OptionsView.ShowGroupPanel = false;
            this.gvAbklaerungVertieft.OptionsView.ShowIndicator = false;
            // 
            // colDatum
            // 
            this.colDatum.Caption = "Datum";
            this.colDatum.Name = "colDatum";
            this.colDatum.Visible = true;
            this.colDatum.VisibleIndex = 0;
            this.colDatum.Width = 80;
            // 
            // colModul
            // 
            this.colModul.Caption = "Modul";
            this.colModul.Name = "colModul";
            this.colModul.Visible = true;
            this.colModul.VisibleIndex = 1;
            this.colModul.Width = 150;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Status Dossier";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 2;
            this.colStatus.Width = 130;
            // 
            // colPraesenz
            // 
            this.colPraesenz.Caption = "Präsenz";
            this.colPraesenz.Name = "colPraesenz";
            this.colPraesenz.Visible = true;
            this.colPraesenz.VisibleIndex = 3;
            this.colPraesenz.Width = 100;
            // 
            // colBeurteilung
            // 
            this.colBeurteilung.Caption = "Int. - Beurteilung";
            this.colBeurteilung.Name = "colBeurteilung";
            this.colBeurteilung.Visible = true;
            this.colBeurteilung.VisibleIndex = 4;
            this.colBeurteilung.Width = 150;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.LinesCount = 1;
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            this.repositoryItemMemoEdit1.ReadOnly = true;
            // 
            // tabControlAbkl
            // 
            this.tabControlAbkl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlAbkl.Controls.Add(this.tabPageModule);
            this.tabControlAbkl.Controls.Add(this.tabPageProbe);
            this.tabControlAbkl.Location = new System.Drawing.Point(3, 219);
            this.tabControlAbkl.Name = "tabControlAbkl";
            this.tabControlAbkl.ShowFixedWidthTooltip = true;
            this.tabControlAbkl.Size = new System.Drawing.Size(854, 465);
            this.tabControlAbkl.TabIndex = 2;
            this.tabControlAbkl.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tabPageModule,
            this.tabPageProbe});
            this.tabControlAbkl.TabsLineColor = System.Drawing.Color.Black;
            this.tabControlAbkl.TabsLocation = SharpLibrary.WinControls.TabsLocation.Top;
            this.tabControlAbkl.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabControlAbkl.Text = "tabControlAbkl";
            this.tabControlAbkl.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabControlAbkl_SelectedTabChanged);
            // 
            // tabPageModule
            // 
            this.tabPageModule.Controls.Add(this.edtDatumAustritt);
            this.tabPageModule.Controls.Add(this.lblEinsatzBis);
            this.tabPageModule.Controls.Add(this.lblEinsatzVon);
            this.tabPageModule.Controls.Add(this.edtEinsatzBis);
            this.tabPageModule.Controls.Add(this.edtEinsatzVon);
            this.tabPageModule.Controls.Add(this.edtProbeeinsatzIn);
            this.tabPageModule.Controls.Add(this.lblEinsatz);
            this.tabPageModule.Controls.Add(this.lblKursAbbruch);
            this.tabPageModule.Controls.Add(this.edtDatumKursAbbruch);
            this.tabPageModule.Controls.Add(this.lblKursDetail);
            this.tabPageModule.Controls.Add(this.edtKurs);
            this.tabPageModule.Controls.Add(this.lblKurs);
            this.tabPageModule.Controls.Add(this.edtBemerkung);
            this.tabPageModule.Controls.Add(this.lblBemerkung);
            this.tabPageModule.Controls.Add(this.edtSchlussbericht);
            this.tabPageModule.Controls.Add(this.lblSchlussbericht);
            this.tabPageModule.Controls.Add(this.edtGrundDossierrueckgabe);
            this.tabPageModule.Controls.Add(this.lblGrundDossierrückgabe);
            this.tabPageModule.Controls.Add(this.edtIntegrationDok);
            this.tabPageModule.Controls.Add(this.edtIntegrationCode);
            this.tabPageModule.Controls.Add(this.lblBeurteilung);
            this.tabPageModule.Controls.Add(this.edtDatumIntegration);
            this.tabPageModule.Controls.Add(this.edtPraesenz);
            this.tabPageModule.Controls.Add(this.lblPraesenz);
            this.tabPageModule.Controls.Add(this.edtStatusDossier);
            this.tabPageModule.Controls.Add(this.lblStatusDossier);
            this.tabPageModule.Controls.Add(this.edtModul);
            this.tabPageModule.Controls.Add(this.lblModul);
            this.tabPageModule.Controls.Add(this.lblDatum);
            this.tabPageModule.Controls.Add(this.edtDatum);
            this.tabPageModule.Location = new System.Drawing.Point(6, 32);
            this.tabPageModule.Name = "tabPageModule";
            this.tabPageModule.Size = new System.Drawing.Size(842, 427);
            this.tabPageModule.TabIndex = 0;
            this.tabPageModule.Title = "Module";
            // 
            // edtDatumAustritt
            // 
            this.edtDatumAustritt.DataSource = this.qryAbklaerungVertieft;
            this.edtDatumAustritt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtDatumAustritt.EditValue = null;
            this.edtDatumAustritt.Location = new System.Drawing.Point(569, 371);
            this.edtDatumAustritt.Name = "edtDatumAustritt";
            this.edtDatumAustritt.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumAustritt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtDatumAustritt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumAustritt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumAustritt.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumAustritt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumAustritt.Properties.Appearance.Options.UseFont = true;
            this.edtDatumAustritt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject28.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject28.Options.UseBackColor = true;
            this.edtDatumAustritt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumAustritt.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject28)});
            this.edtDatumAustritt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumAustritt.Properties.ReadOnly = true;
            this.edtDatumAustritt.Properties.ShowToday = false;
            this.edtDatumAustritt.Size = new System.Drawing.Size(89, 24);
            this.edtDatumAustritt.TabIndex = 27;
            // 
            // lblEinsatzBis
            // 
            this.lblEinsatzBis.Location = new System.Drawing.Point(242, 189);
            this.lblEinsatzBis.Name = "lblEinsatzBis";
            this.lblEinsatzBis.Size = new System.Drawing.Size(24, 24);
            this.lblEinsatzBis.TabIndex = 17;
            this.lblEinsatzBis.Text = "bis";
            // 
            // lblEinsatzVon
            // 
            this.lblEinsatzVon.Location = new System.Drawing.Point(3, 189);
            this.lblEinsatzVon.Name = "lblEinsatzVon";
            this.lblEinsatzVon.Size = new System.Drawing.Size(138, 24);
            this.lblEinsatzVon.TabIndex = 15;
            this.lblEinsatzVon.Text = "Einsatz von";
            // 
            // edtEinsatzBis
            // 
            this.edtEinsatzBis.DataSource = this.qryAbklaerungVertieft;
            this.edtEinsatzBis.EditValue = null;
            this.edtEinsatzBis.Location = new System.Drawing.Point(272, 189);
            this.edtEinsatzBis.Name = "edtEinsatzBis";
            this.edtEinsatzBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtEinsatzBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEinsatzBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinsatzBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinsatzBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinsatzBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinsatzBis.Properties.Appearance.Options.UseFont = true;
            this.edtEinsatzBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtEinsatzBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEinsatzBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtEinsatzBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEinsatzBis.Properties.ShowToday = false;
            this.edtEinsatzBis.Size = new System.Drawing.Size(89, 24);
            this.edtEinsatzBis.TabIndex = 18;
            // 
            // edtEinsatzVon
            // 
            this.edtEinsatzVon.DataSource = this.qryAbklaerungVertieft;
            this.edtEinsatzVon.EditValue = null;
            this.edtEinsatzVon.Location = new System.Drawing.Point(147, 189);
            this.edtEinsatzVon.Name = "edtEinsatzVon";
            this.edtEinsatzVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtEinsatzVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEinsatzVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinsatzVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinsatzVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinsatzVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinsatzVon.Properties.Appearance.Options.UseFont = true;
            this.edtEinsatzVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtEinsatzVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEinsatzVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtEinsatzVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEinsatzVon.Properties.ShowToday = false;
            this.edtEinsatzVon.Size = new System.Drawing.Size(89, 24);
            this.edtEinsatzVon.TabIndex = 16;
            // 
            // edtProbeeinsatzIn
            // 
            this.edtProbeeinsatzIn.DataSource = this.qryAbklaerungVertieft;
            this.edtProbeeinsatzIn.Location = new System.Drawing.Point(147, 159);
            this.edtProbeeinsatzIn.LOVName = "KaAbklPhasenEinsatzin";
            this.edtProbeeinsatzIn.Name = "edtProbeeinsatzIn";
            this.edtProbeeinsatzIn.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtProbeeinsatzIn.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtProbeeinsatzIn.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtProbeeinsatzIn.Properties.Appearance.Options.UseBackColor = true;
            this.edtProbeeinsatzIn.Properties.Appearance.Options.UseBorderColor = true;
            this.edtProbeeinsatzIn.Properties.Appearance.Options.UseFont = true;
            this.edtProbeeinsatzIn.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtProbeeinsatzIn.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtProbeeinsatzIn.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtProbeeinsatzIn.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtProbeeinsatzIn.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtProbeeinsatzIn.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtProbeeinsatzIn.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtProbeeinsatzIn.Properties.NullText = "";
            this.edtProbeeinsatzIn.Properties.ShowFooter = false;
            this.edtProbeeinsatzIn.Properties.ShowHeader = false;
            this.edtProbeeinsatzIn.Size = new System.Drawing.Size(264, 24);
            this.edtProbeeinsatzIn.TabIndex = 14;
            // 
            // lblEinsatz
            // 
            this.lblEinsatz.Location = new System.Drawing.Point(3, 159);
            this.lblEinsatz.Name = "lblEinsatz";
            this.lblEinsatz.Size = new System.Drawing.Size(138, 24);
            this.lblEinsatz.TabIndex = 13;
            this.lblEinsatz.Text = "Einsatz in";
            // 
            // lblKursAbbruch
            // 
            this.lblKursAbbruch.Location = new System.Drawing.Point(602, 72);
            this.lblKursAbbruch.Name = "lblKursAbbruch";
            this.lblKursAbbruch.Size = new System.Drawing.Size(85, 24);
            this.lblKursAbbruch.TabIndex = 8;
            this.lblKursAbbruch.Text = "Kursabbruch";
            // 
            // edtDatumKursAbbruch
            // 
            this.edtDatumKursAbbruch.DataSource = this.qryAbklaerungVertieft;
            this.edtDatumKursAbbruch.EditValue = null;
            this.edtDatumKursAbbruch.Location = new System.Drawing.Point(693, 72);
            this.edtDatumKursAbbruch.Name = "edtDatumKursAbbruch";
            this.edtDatumKursAbbruch.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumKursAbbruch.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumKursAbbruch.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumKursAbbruch.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumKursAbbruch.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumKursAbbruch.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumKursAbbruch.Properties.Appearance.Options.UseFont = true;
            this.edtDatumKursAbbruch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtDatumKursAbbruch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumKursAbbruch.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtDatumKursAbbruch.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumKursAbbruch.Properties.ShowToday = false;
            this.edtDatumKursAbbruch.Size = new System.Drawing.Size(89, 24);
            this.edtDatumKursAbbruch.TabIndex = 9;
            // 
            // lblKursDetail
            // 
            this.lblKursDetail.DataSource = this.qryAbklaerungVertieft;
            this.lblKursDetail.Location = new System.Drawing.Point(147, 96);
            this.lblKursDetail.Name = "lblKursDetail";
            this.lblKursDetail.Size = new System.Drawing.Size(635, 24);
            this.lblKursDetail.TabIndex = 10;
            this.lblKursDetail.Text = "[KursDetail]";
            // 
            // edtKurs
            // 
            this.edtKurs.DataSource = this.qryAbklaerungVertieft;
            this.edtKurs.EditValue = "";
            this.edtKurs.Location = new System.Drawing.Point(147, 72);
            this.edtKurs.Name = "edtKurs";
            this.edtKurs.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKurs.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKurs.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKurs.Properties.Appearance.Options.UseBackColor = true;
            this.edtKurs.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKurs.Properties.Appearance.Options.UseFont = true;
            this.edtKurs.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtKurs.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtKurs.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKurs.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtKurs.Size = new System.Drawing.Size(416, 24);
            this.edtKurs.TabIndex = 7;
            this.edtKurs.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtKurs_UserModifiedFld);
            // 
            // lblKurs
            // 
            this.lblKurs.Location = new System.Drawing.Point(3, 72);
            this.lblKurs.Name = "lblKurs";
            this.lblKurs.Size = new System.Drawing.Size(138, 24);
            this.lblKurs.TabIndex = 6;
            this.lblKurs.Text = "Kurs";
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.DataSource = this.qryAbklaerungVertieft;
            this.edtBemerkung.EditValue = "";
            this.edtBemerkung.Location = new System.Drawing.Point(147, 225);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(635, 104);
            this.edtBemerkung.TabIndex = 20;
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.ForeColor = System.Drawing.Color.Black;
            this.lblBemerkung.Location = new System.Drawing.Point(3, 225);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(138, 24);
            this.lblBemerkung.TabIndex = 19;
            this.lblBemerkung.Text = "Bemerkungen";
            // 
            // edtSchlussbericht
            // 
            this.edtSchlussbericht.DataSource = this.qryAbklaerungVertieft;
            this.edtSchlussbericht.EditValue = "";
            this.edtSchlussbericht.Location = new System.Drawing.Point(147, 401);
            this.edtSchlussbericht.Name = "edtSchlussbericht";
            this.edtSchlussbericht.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSchlussbericht.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSchlussbericht.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSchlussbericht.Properties.Appearance.Options.UseBackColor = true;
            this.edtSchlussbericht.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSchlussbericht.Properties.Appearance.Options.UseFont = true;
            this.edtSchlussbericht.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSchlussbericht.Properties.AppearanceDisabled.Options.UseFont = true;
            this.edtSchlussbericht.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            serializableAppearanceObject29.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject29.Options.UseBackColor = true;
            serializableAppearanceObject30.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject30.Options.UseBackColor = true;
            serializableAppearanceObject31.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject31.Options.UseBackColor = true;
            this.edtSchlussbericht.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSchlussbericht.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSchlussbericht.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject29, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSchlussbericht.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject30, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSchlussbericht.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject31, "Dokument importieren")});
            this.edtSchlussbericht.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSchlussbericht.Properties.ReadOnly = true;
            this.edtSchlussbericht.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtSchlussbericht.Size = new System.Drawing.Size(136, 24);
            this.edtSchlussbericht.TabIndex = 29;
            // 
            // lblSchlussbericht
            // 
            this.lblSchlussbericht.Location = new System.Drawing.Point(3, 401);
            this.lblSchlussbericht.Name = "lblSchlussbericht";
            this.lblSchlussbericht.Size = new System.Drawing.Size(138, 24);
            this.lblSchlussbericht.TabIndex = 28;
            this.lblSchlussbericht.Text = "Schlussbericht";
            // 
            // edtGrundDossierrueckgabe
            // 
            this.edtGrundDossierrueckgabe.DataSource = this.qryAbklaerungVertieft;
            this.edtGrundDossierrueckgabe.Location = new System.Drawing.Point(147, 371);
            this.edtGrundDossierrueckgabe.LOVName = "KaAbklärungGrundDoss";
            this.edtGrundDossierrueckgabe.Name = "edtGrundDossierrueckgabe";
            this.edtGrundDossierrueckgabe.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGrundDossierrueckgabe.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGrundDossierrueckgabe.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrundDossierrueckgabe.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrundDossierrueckgabe.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGrundDossierrueckgabe.Properties.Appearance.Options.UseFont = true;
            this.edtGrundDossierrueckgabe.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtGrundDossierrueckgabe.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrundDossierrueckgabe.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtGrundDossierrueckgabe.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtGrundDossierrueckgabe.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtGrundDossierrueckgabe.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtGrundDossierrueckgabe.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGrundDossierrueckgabe.Properties.NullText = "";
            this.edtGrundDossierrueckgabe.Properties.ShowFooter = false;
            this.edtGrundDossierrueckgabe.Properties.ShowHeader = false;
            this.edtGrundDossierrueckgabe.Size = new System.Drawing.Size(416, 24);
            this.edtGrundDossierrueckgabe.TabIndex = 26;
            // 
            // lblGrundDossierrückgabe
            // 
            this.lblGrundDossierrückgabe.Location = new System.Drawing.Point(3, 373);
            this.lblGrundDossierrückgabe.Name = "lblGrundDossierrückgabe";
            this.lblGrundDossierrückgabe.Size = new System.Drawing.Size(138, 24);
            this.lblGrundDossierrückgabe.TabIndex = 25;
            this.lblGrundDossierrückgabe.Text = "Grund Dossierrückgabe";
            // 
            // edtIntegrationDok
            // 
            this.edtIntegrationDok.DataSource = this.qryAbklaerungVertieft;
            this.edtIntegrationDok.EditValue = "";
            this.edtIntegrationDok.Location = new System.Drawing.Point(569, 341);
            this.edtIntegrationDok.Name = "edtIntegrationDok";
            this.edtIntegrationDok.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtIntegrationDok.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIntegrationDok.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIntegrationDok.Properties.Appearance.Options.UseBackColor = true;
            this.edtIntegrationDok.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIntegrationDok.Properties.Appearance.Options.UseFont = true;
            this.edtIntegrationDok.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIntegrationDok.Properties.AppearanceDisabled.Options.UseFont = true;
            this.edtIntegrationDok.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.edtIntegrationDok.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtIntegrationDok.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtIntegrationDok.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtIntegrationDok.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtIntegrationDok.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11, "Dokument importieren")});
            this.edtIntegrationDok.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIntegrationDok.Properties.ReadOnly = true;
            this.edtIntegrationDok.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtIntegrationDok.Size = new System.Drawing.Size(136, 24);
            this.edtIntegrationDok.TabIndex = 24;
            // 
            // edtIntegrationCode
            // 
            this.edtIntegrationCode.DataSource = this.qryAbklaerungVertieft;
            this.edtIntegrationCode.Location = new System.Drawing.Point(243, 341);
            this.edtIntegrationCode.LOVName = "KaAbklaerungIntegrBeur";
            this.edtIntegrationCode.Name = "edtIntegrationCode";
            this.edtIntegrationCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtIntegrationCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIntegrationCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIntegrationCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtIntegrationCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIntegrationCode.Properties.Appearance.Options.UseFont = true;
            this.edtIntegrationCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtIntegrationCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtIntegrationCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtIntegrationCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtIntegrationCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.edtIntegrationCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12)});
            this.edtIntegrationCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIntegrationCode.Properties.NullText = "";
            this.edtIntegrationCode.Properties.ShowFooter = false;
            this.edtIntegrationCode.Properties.ShowHeader = false;
            this.edtIntegrationCode.Size = new System.Drawing.Size(320, 24);
            this.edtIntegrationCode.TabIndex = 23;
            // 
            // lblBeurteilung
            // 
            this.lblBeurteilung.Location = new System.Drawing.Point(3, 341);
            this.lblBeurteilung.Name = "lblBeurteilung";
            this.lblBeurteilung.Size = new System.Drawing.Size(138, 24);
            this.lblBeurteilung.TabIndex = 21;
            this.lblBeurteilung.Text = "Datum / Int.beurteil.";
            // 
            // edtDatumIntegration
            // 
            this.edtDatumIntegration.DataSource = this.qryAbklaerungVertieft;
            this.edtDatumIntegration.EditValue = null;
            this.edtDatumIntegration.Location = new System.Drawing.Point(147, 341);
            this.edtDatumIntegration.Name = "edtDatumIntegration";
            this.edtDatumIntegration.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumIntegration.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumIntegration.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumIntegration.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumIntegration.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumIntegration.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumIntegration.Properties.Appearance.Options.UseFont = true;
            this.edtDatumIntegration.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject13.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject13.Options.UseBackColor = true;
            this.edtDatumIntegration.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumIntegration.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13)});
            this.edtDatumIntegration.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumIntegration.Properties.ShowToday = false;
            this.edtDatumIntegration.Size = new System.Drawing.Size(89, 24);
            this.edtDatumIntegration.TabIndex = 22;
            // 
            // edtPraesenz
            // 
            this.edtPraesenz.DataSource = this.qryAbklaerungVertieft;
            this.edtPraesenz.Location = new System.Drawing.Point(147, 129);
            this.edtPraesenz.LOVName = "KaAbklaerungPraesenz";
            this.edtPraesenz.Name = "edtPraesenz";
            this.edtPraesenz.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPraesenz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPraesenz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPraesenz.Properties.Appearance.Options.UseBackColor = true;
            this.edtPraesenz.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPraesenz.Properties.Appearance.Options.UseFont = true;
            this.edtPraesenz.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtPraesenz.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtPraesenz.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtPraesenz.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtPraesenz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject14.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject14.Options.UseBackColor = true;
            this.edtPraesenz.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject14)});
            this.edtPraesenz.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPraesenz.Properties.NullText = "";
            this.edtPraesenz.Properties.ShowFooter = false;
            this.edtPraesenz.Properties.ShowHeader = false;
            this.edtPraesenz.Size = new System.Drawing.Size(264, 24);
            this.edtPraesenz.TabIndex = 12;
            // 
            // lblPraesenz
            // 
            this.lblPraesenz.Location = new System.Drawing.Point(3, 129);
            this.lblPraesenz.Name = "lblPraesenz";
            this.lblPraesenz.Size = new System.Drawing.Size(138, 24);
            this.lblPraesenz.TabIndex = 11;
            this.lblPraesenz.Text = "Präsenz Kurs";
            // 
            // edtStatusDossier
            // 
            this.edtStatusDossier.DataSource = this.qryAbklaerungVertieft;
            this.edtStatusDossier.Location = new System.Drawing.Point(567, 42);
            this.edtStatusDossier.LOVName = "KaAbklaerungStatusDossier";
            this.edtStatusDossier.Name = "edtStatusDossier";
            this.edtStatusDossier.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStatusDossier.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStatusDossier.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStatusDossier.Properties.Appearance.Options.UseBackColor = true;
            this.edtStatusDossier.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStatusDossier.Properties.Appearance.Options.UseFont = true;
            this.edtStatusDossier.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtStatusDossier.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtStatusDossier.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtStatusDossier.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtStatusDossier.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject15.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject15.Options.UseBackColor = true;
            this.edtStatusDossier.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject15)});
            this.edtStatusDossier.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStatusDossier.Properties.NullText = "";
            this.edtStatusDossier.Properties.ShowFooter = false;
            this.edtStatusDossier.Properties.ShowHeader = false;
            this.edtStatusDossier.Size = new System.Drawing.Size(215, 24);
            this.edtStatusDossier.TabIndex = 5;
            // 
            // lblStatusDossier
            // 
            this.lblStatusDossier.Location = new System.Drawing.Point(466, 42);
            this.lblStatusDossier.Name = "lblStatusDossier";
            this.lblStatusDossier.Size = new System.Drawing.Size(95, 24);
            this.lblStatusDossier.TabIndex = 4;
            this.lblStatusDossier.Text = "Status Dossier";
            // 
            // edtModul
            // 
            this.edtModul.DataSource = this.qryAbklaerungVertieft;
            this.edtModul.Location = new System.Drawing.Point(147, 42);
            this.edtModul.LOVName = "KaAbklaerungPhaseVertiefteAbklaerungen";
            this.edtModul.Name = "edtModul";
            this.edtModul.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtModul.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtModul.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtModul.Properties.Appearance.Options.UseBackColor = true;
            this.edtModul.Properties.Appearance.Options.UseBorderColor = true;
            this.edtModul.Properties.Appearance.Options.UseFont = true;
            this.edtModul.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtModul.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtModul.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtModul.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtModul.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject16.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject16.Options.UseBackColor = true;
            this.edtModul.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject16)});
            this.edtModul.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtModul.Properties.NullText = "";
            this.edtModul.Properties.ShowFooter = false;
            this.edtModul.Properties.ShowHeader = false;
            this.edtModul.Size = new System.Drawing.Size(264, 24);
            this.edtModul.TabIndex = 3;
            // 
            // lblModul
            // 
            this.lblModul.Location = new System.Drawing.Point(3, 42);
            this.lblModul.Name = "lblModul";
            this.lblModul.Size = new System.Drawing.Size(138, 24);
            this.lblModul.TabIndex = 2;
            this.lblModul.Text = "Modul";
            // 
            // lblDatum
            // 
            this.lblDatum.Location = new System.Drawing.Point(3, 12);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(138, 24);
            this.lblDatum.TabIndex = 0;
            this.lblDatum.Text = "Datum";
            // 
            // edtDatum
            // 
            this.edtDatum.DataSource = this.qryAbklaerungVertieft;
            this.edtDatum.EditValue = null;
            this.edtDatum.Location = new System.Drawing.Point(147, 12);
            this.edtDatum.Name = "edtDatum";
            this.edtDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatum.Properties.Appearance.Options.UseFont = true;
            this.edtDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject17.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject17.Options.UseBackColor = true;
            this.edtDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject17)});
            this.edtDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatum.Properties.ShowToday = false;
            this.edtDatum.Size = new System.Drawing.Size(89, 24);
            this.edtDatum.TabIndex = 1;
            // 
            // tabPageProbe
            // 
            this.tabPageProbe.Controls.Add(this.edtHatStattgefunden);
            this.tabPageProbe.Controls.Add(this.edtDocProzessschritt);
            this.tabPageProbe.Controls.Add(this.edtProzessschritt);
            this.tabPageProbe.Controls.Add(this.grdProzessschritte);
            this.tabPageProbe.Controls.Add(this.edtZahlungDatum);
            this.tabPageProbe.Location = new System.Drawing.Point(6, 32);
            this.tabPageProbe.Name = "tabPageProbe";
            this.tabPageProbe.Size = new System.Drawing.Size(842, 427);
            this.tabPageProbe.TabIndex = 0;
            this.tabPageProbe.Title = "Probeeinsatz";
            // 
            // edtHatStattgefunden
            // 
            this.edtHatStattgefunden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtHatStattgefunden.DataMember = "HatStattgefunden";
            this.edtHatStattgefunden.DataSource = this.qryProbeeinsatz;
            this.edtHatStattgefunden.Location = new System.Drawing.Point(564, 404);
            this.edtHatStattgefunden.Name = "edtHatStattgefunden";
            this.edtHatStattgefunden.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtHatStattgefunden.Properties.Appearance.Options.UseBackColor = true;
            this.edtHatStattgefunden.Properties.Caption = "hat stattgefunden";
            this.edtHatStattgefunden.Size = new System.Drawing.Size(128, 19);
            this.edtHatStattgefunden.TabIndex = 4;
            // 
            // qryProbeeinsatz
            // 
            this.qryProbeeinsatz.CanDelete = true;
            this.qryProbeeinsatz.CanInsert = true;
            this.qryProbeeinsatz.CanUpdate = true;
            this.qryProbeeinsatz.HostControl = this;
            this.qryProbeeinsatz.SelectStatement = resources.GetString("qryProbeeinsatz.SelectStatement");
            this.qryProbeeinsatz.TableName = "KaAbklaerungVertieftProbeeinsatz";
            this.qryProbeeinsatz.AfterFill += new System.EventHandler(this.qryProbeeinsatz_AfterFill);
            this.qryProbeeinsatz.BeforeInsert += new System.EventHandler(this.qryProbeeinsatz_BeforeInsert);
            this.qryProbeeinsatz.AfterInsert += new System.EventHandler(this.qryProbeeinsatz_AfterInsert);
            this.qryProbeeinsatz.BeforeDelete += new System.EventHandler(this.qryProbeeinsatz_BeforeDelete);
            this.qryProbeeinsatz.AfterDelete += new System.EventHandler(this.qryProbeeinsatz_AfterDelete);
            this.qryProbeeinsatz.PositionChanging += new System.EventHandler(this.qryProbeeinsatz_PositionChanging);
            this.qryProbeeinsatz.ColumnChanging += new System.Data.DataColumnChangeEventHandler(this.qryProbeeinsatz_ColumnChanging);
            // 
            // edtDocProzessschritt
            // 
            this.edtDocProzessschritt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDocProzessschritt.DataMember = "DocumentID_Prozessschritt";
            this.edtDocProzessschritt.DataSource = this.qryProbeeinsatz;
            this.edtDocProzessschritt.Location = new System.Drawing.Point(422, 400);
            this.edtDocProzessschritt.Name = "edtDocProzessschritt";
            this.edtDocProzessschritt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDocProzessschritt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDocProzessschritt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDocProzessschritt.Properties.Appearance.Options.UseBackColor = true;
            this.edtDocProzessschritt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDocProzessschritt.Properties.Appearance.Options.UseFont = true;
            this.edtDocProzessschritt.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDocProzessschritt.Properties.AppearanceDisabled.Options.UseFont = true;
            this.edtDocProzessschritt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject18.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject18.Options.UseBackColor = true;
            serializableAppearanceObject19.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject19.Options.UseBackColor = true;
            serializableAppearanceObject20.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject20.Options.UseBackColor = true;
            serializableAppearanceObject21.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject21.Options.UseBackColor = true;
            this.edtDocProzessschritt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocProzessschritt.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject18, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocProzessschritt.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject19, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocProzessschritt.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject20, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocProzessschritt.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject21, "Dokument importieren")});
            this.edtDocProzessschritt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDocProzessschritt.Properties.ReadOnly = true;
            this.edtDocProzessschritt.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtDocProzessschritt.Size = new System.Drawing.Size(136, 24);
            this.edtDocProzessschritt.TabIndex = 3;
            // 
            // edtProzessschritt
            // 
            this.edtProzessschritt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtProzessschritt.DataMember = "KaAbklaerungProzessschrittCode";
            this.edtProzessschritt.DataSource = this.qryProbeeinsatz;
            this.edtProzessschritt.Location = new System.Drawing.Point(109, 400);
            this.edtProzessschritt.LOVName = "KaAbklaerungProzessschritt";
            this.edtProzessschritt.Name = "edtProzessschritt";
            this.edtProzessschritt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtProzessschritt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtProzessschritt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtProzessschritt.Properties.Appearance.Options.UseBackColor = true;
            this.edtProzessschritt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtProzessschritt.Properties.Appearance.Options.UseFont = true;
            this.edtProzessschritt.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtProzessschritt.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtProzessschritt.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtProzessschritt.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtProzessschritt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject22.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject22.Options.UseBackColor = true;
            this.edtProzessschritt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject22)});
            this.edtProzessschritt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtProzessschritt.Properties.NullText = "";
            this.edtProzessschritt.Properties.ShowFooter = false;
            this.edtProzessschritt.Properties.ShowHeader = false;
            this.edtProzessschritt.Size = new System.Drawing.Size(307, 24);
            this.edtProzessschritt.TabIndex = 2;
            // 
            // grdProzessschritte
            // 
            this.grdProzessschritte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdProzessschritte.DataSource = this.qryProbeeinsatz;
            // 
            // 
            // 
            this.grdProzessschritte.EmbeddedNavigator.Name = "";
            this.grdProzessschritte.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdProzessschritte.Location = new System.Drawing.Point(3, 3);
            this.grdProzessschritte.MainView = this.grvProbeeinsatz;
            this.grdProzessschritte.Name = "grdProzessschritte";
            this.grdProzessschritte.Size = new System.Drawing.Size(836, 391);
            this.grdProzessschritte.TabIndex = 0;
            this.grdProzessschritte.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvProbeeinsatz});
            // 
            // grvProbeeinsatz
            // 
            this.grvProbeeinsatz.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvProbeeinsatz.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProbeeinsatz.Appearance.Empty.Options.UseBackColor = true;
            this.grvProbeeinsatz.Appearance.Empty.Options.UseFont = true;
            this.grvProbeeinsatz.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProbeeinsatz.Appearance.EvenRow.Options.UseFont = true;
            this.grvProbeeinsatz.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvProbeeinsatz.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProbeeinsatz.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvProbeeinsatz.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvProbeeinsatz.Appearance.FocusedCell.Options.UseFont = true;
            this.grvProbeeinsatz.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvProbeeinsatz.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvProbeeinsatz.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProbeeinsatz.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvProbeeinsatz.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvProbeeinsatz.Appearance.FocusedRow.Options.UseFont = true;
            this.grvProbeeinsatz.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvProbeeinsatz.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvProbeeinsatz.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvProbeeinsatz.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvProbeeinsatz.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvProbeeinsatz.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvProbeeinsatz.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvProbeeinsatz.Appearance.GroupRow.Options.UseFont = true;
            this.grvProbeeinsatz.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvProbeeinsatz.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvProbeeinsatz.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvProbeeinsatz.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvProbeeinsatz.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvProbeeinsatz.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvProbeeinsatz.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvProbeeinsatz.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvProbeeinsatz.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProbeeinsatz.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvProbeeinsatz.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvProbeeinsatz.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvProbeeinsatz.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvProbeeinsatz.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvProbeeinsatz.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvProbeeinsatz.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProbeeinsatz.Appearance.OddRow.Options.UseFont = true;
            this.grvProbeeinsatz.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvProbeeinsatz.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProbeeinsatz.Appearance.Row.Options.UseBackColor = true;
            this.grvProbeeinsatz.Appearance.Row.Options.UseFont = true;
            this.grvProbeeinsatz.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProbeeinsatz.Appearance.SelectedRow.Options.UseFont = true;
            this.grvProbeeinsatz.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvProbeeinsatz.Appearance.VertLine.Options.UseBackColor = true;
            this.grvProbeeinsatz.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvProbeeinsatz.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProbeeinsatzDatum,
            this.colProbeeinsatzProzesschritt,
            this.colProbeeinsatzHatStattgefunden});
            this.grvProbeeinsatz.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvProbeeinsatz.GridControl = this.grdProzessschritte;
            this.grvProbeeinsatz.Name = "grvProbeeinsatz";
            this.grvProbeeinsatz.OptionsBehavior.Editable = false;
            this.grvProbeeinsatz.OptionsCustomization.AllowFilter = false;
            this.grvProbeeinsatz.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvProbeeinsatz.OptionsNavigation.AutoFocusNewRow = true;
            this.grvProbeeinsatz.OptionsNavigation.UseTabKey = false;
            this.grvProbeeinsatz.OptionsView.ColumnAutoWidth = false;
            this.grvProbeeinsatz.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvProbeeinsatz.OptionsView.ShowGroupPanel = false;
            this.grvProbeeinsatz.OptionsView.ShowIndicator = false;
            // 
            // colProbeeinsatzDatum
            // 
            this.colProbeeinsatzDatum.Caption = "Datum";
            this.colProbeeinsatzDatum.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.colProbeeinsatzDatum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colProbeeinsatzDatum.FieldName = "Datum";
            this.colProbeeinsatzDatum.Name = "colProbeeinsatzDatum";
            this.colProbeeinsatzDatum.Visible = true;
            this.colProbeeinsatzDatum.VisibleIndex = 0;
            this.colProbeeinsatzDatum.Width = 98;
            // 
            // colProbeeinsatzProzesschritt
            // 
            this.colProbeeinsatzProzesschritt.Caption = "Prozessschritt";
            this.colProbeeinsatzProzesschritt.Name = "colProbeeinsatzProzesschritt";
            this.colProbeeinsatzProzesschritt.Visible = true;
            this.colProbeeinsatzProzesschritt.VisibleIndex = 1;
            this.colProbeeinsatzProzesschritt.Width = 320;
            // 
            // colProbeeinsatzHatStattgefunden
            // 
            this.colProbeeinsatzHatStattgefunden.Caption = "hat stattgefunden";
            this.colProbeeinsatzHatStattgefunden.DisplayFormat.FormatString = "n2";
            this.colProbeeinsatzHatStattgefunden.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colProbeeinsatzHatStattgefunden.FieldName = "HatStattgefunden";
            this.colProbeeinsatzHatStattgefunden.Name = "colProbeeinsatzHatStattgefunden";
            this.colProbeeinsatzHatStattgefunden.Visible = true;
            this.colProbeeinsatzHatStattgefunden.VisibleIndex = 2;
            this.colProbeeinsatzHatStattgefunden.Width = 120;
            // 
            // edtZahlungDatum
            // 
            this.edtZahlungDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtZahlungDatum.DataMember = "Datum";
            this.edtZahlungDatum.DataSource = this.qryProbeeinsatz;
            this.edtZahlungDatum.EditValue = null;
            this.edtZahlungDatum.Location = new System.Drawing.Point(3, 400);
            this.edtZahlungDatum.Name = "edtZahlungDatum";
            this.edtZahlungDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtZahlungDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZahlungDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZahlungDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZahlungDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtZahlungDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZahlungDatum.Properties.Appearance.Options.UseFont = true;
            this.edtZahlungDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject23.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject23.Options.UseBackColor = true;
            this.edtZahlungDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtZahlungDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject23)});
            this.edtZahlungDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZahlungDatum.Properties.ShowToday = false;
            this.edtZahlungDatum.Size = new System.Drawing.Size(100, 24);
            this.edtZahlungDatum.TabIndex = 1;
            // 
            // CtlKaAbklaerungVertieft
            // 
            this.ActiveSQLQuery = this.qryAbklaerungVertieft;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(803, 598);
            this.Controls.Add(this.grdPhasen);
            this.Controls.Add(this.tabControlAbkl);
            this.Controls.Add(this.pnlHead);
            this.Name = "CtlKaAbklaerungVertieft";
            this.Size = new System.Drawing.Size(860, 687);
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            this.pnlHead.ResumeLayout(false);
            this.pnlHead.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPhasen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryAbklaerungVertieft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAbklaerungVertieft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            this.tabControlAbkl.ResumeLayout(false);
            this.tabPageModule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumAustritt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProbeeinsatzIn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProbeeinsatzIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKursAbbruch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumKursAbbruch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKursDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKurs.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSchlussbericht.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSchlussbericht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrundDossierrueckgabe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrundDossierrueckgabe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundDossierrückgabe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIntegrationDok.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIntegrationCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIntegrationCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeurteilung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumIntegration.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPraesenz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPraesenz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPraesenz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusDossier.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusDossier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatusDossier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModul.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModul)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModul)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatum.Properties)).EndInit();
            this.tabPageProbe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtHatStattgefunden.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryProbeeinsatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDocProzessschritt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProzessschritt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProzessschritt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProzessschritte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProbeeinsatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZahlungDatum.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn colBeurteilung;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colModul;
        private DevExpress.XtraGrid.Columns.GridColumn colPraesenz;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissGrid grdPhasen;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAbklaerungVertieft;
        private System.Windows.Forms.Label lblTitel;
        private System.Windows.Forms.PictureBox picTitle;
        private System.Windows.Forms.Panel pnlHead;
        private KiSS4.DB.SqlQuery qryAbklaerungVertieft;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private Gui.KissTabControlEx tabControlAbkl;
        private SharpLibrary.WinControls.TabPageEx tabPageModule;
        private SharpLibrary.WinControls.TabPageEx tabPageProbe;
        private Gui.KissDateEdit edtDatumAustritt;
        private Gui.KissLabel lblEinsatzBis;
        private Gui.KissLabel lblEinsatzVon;
        private Gui.KissDateEdit edtEinsatzBis;
        private Gui.KissDateEdit edtEinsatzVon;
        private Gui.KissLookUpEdit edtProbeeinsatzIn;
        private Gui.KissLabel lblEinsatz;
        private Gui.KissLabel lblKursAbbruch;
        private Gui.KissDateEdit edtDatumKursAbbruch;
        private Gui.KissLabel lblKursDetail;
        private Gui.KissButtonEdit edtKurs;
        private Gui.KissLabel lblKurs;
        private Gui.KissMemoEdit edtBemerkung;
        private Gui.KissLabel lblBemerkung;
        private Dokument.XDokument edtSchlussbericht;
        private Gui.KissLabel lblSchlussbericht;
        private Gui.KissLookUpEdit edtGrundDossierrueckgabe;
        private Gui.KissLabel lblGrundDossierrückgabe;
        private Dokument.XDokument edtIntegrationDok;
        private Gui.KissLookUpEdit edtIntegrationCode;
        private Gui.KissLabel lblBeurteilung;
        private Gui.KissDateEdit edtDatumIntegration;
        private Gui.KissLookUpEdit edtPraesenz;
        private Gui.KissLabel lblPraesenz;
        private Gui.KissLookUpEdit edtStatusDossier;
        private Gui.KissLabel lblStatusDossier;
        private Gui.KissLookUpEdit edtModul;
        private Gui.KissLabel lblModul;
        private Gui.KissLabel lblDatum;
        private Gui.KissDateEdit edtDatum;
        private Gui.KissGrid grdProzessschritte;
        private DevExpress.XtraGrid.Views.Grid.GridView grvProbeeinsatz;
        private DevExpress.XtraGrid.Columns.GridColumn colProbeeinsatzDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colProbeeinsatzProzesschritt;
        private DevExpress.XtraGrid.Columns.GridColumn colProbeeinsatzHatStattgefunden;
        private Gui.KissDateEdit edtZahlungDatum;
        private DB.SqlQuery qryProbeeinsatz;
        private Gui.KissLookUpEdit edtProzessschritt;
        private Dokument.XDokument edtDocProzessschritt;
        private Gui.KissCheckEdit edtHatStattgefunden;
    }
}
