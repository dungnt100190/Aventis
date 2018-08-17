namespace KiSS4.Vormundschaft
{
    partial class CtlVmMassnahmen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlVmMassnahmen));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            this.components = new System.ComponentModel.Container();
            this.qryVmMassnahme = new KiSS4.DB.SqlQuery();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.edtBemerkung = new KiSS4.Gui.KissRTFEdit();
            this.grdVmMassnahme = new KiSS4.Gui.KissGrid();
            this.grvVmMassnahme = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBeschluss = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAufhebung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZGB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErnennung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrivat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colIsDeleted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtZGBCodes = new KiSS4.Gui.KissCheckedLookupEdit();
            this.edtErnennungsurkundeDokID = new KiSS4.Dokument.XDokument();
            this.lblDatumVon = new KiSS4.Gui.KissLabel();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.lblDatumBis = new KiSS4.Gui.KissLabel();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.lblZGBCodes = new KiSS4.Gui.KissLabel();
            this.lblErnennungsurkundeDokID = new KiSS4.Gui.KissLabel();
            this.lblErnennung = new KiSS4.Gui.KissLabel();
            this.edtErnennung = new KiSS4.Gui.KissDateEdit();
            this.lblVmPriMa = new KiSS4.Gui.KissLabel();
            this.edtVmPriMa = new KiSS4.Gui.KissButtonEdit();
            this.lblSAR = new KiSS4.Gui.KissLabel();
            this.edtSAR = new KiSS4.Gui.KissButtonEdit();
            this.ZGBinvisible = new KiSS4.Gui.KissCheckedLookupEdit();
            this.btnNeueMT = new KiSS4.Gui.KissButton();
            this.lblWeitereZGB = new KiSS4.Gui.KissLabel();
            this.edtWeitereZGB = new KiSS4.Gui.KissTextEdit();
            this.lblElterlicheSorgeCode = new KiSS4.Gui.KissLabel();
            this.edtElterlicheSorgeCode = new KiSS4.Gui.KissLookUpEdit();
            this.panTitel = new System.Windows.Forms.Panel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.panelDetail = new System.Windows.Forms.Panel();
            this.ctlLogischLoeschen = new KiSS4.Common.CtlLogischesLoeschen();
            this.lblBeschlussVonSuche = new KiSS4.Gui.KissLabel();
            this.lblBeschlussVomBisSuche = new KiSS4.Gui.KissLabel();
            this.edtBeschlussVonSuche = new KiSS4.Gui.KissDateEdit();
            this.edtBeschlussBisSuche = new KiSS4.Gui.KissDateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.radGrpDeleted.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryVmMassnahme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVmMassnahme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVmMassnahme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZGBCodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErnennungsurkundeDokID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZGBCodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErnennungsurkundeDokID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErnennung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErnennung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVmPriMa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVmPriMa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSAR.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZGBinvisible)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWeitereZGB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWeitereZGB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblElterlicheSorgeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtElterlicheSorgeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtElterlicheSorgeCode.Properties)).BeginInit();
            this.panTitel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            this.panelDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeschlussVonSuche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeschlussVomBisSuche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeschlussVonSuche.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeschlussBisSuche.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // radGrpDeleted
            // 
            this.radGrpDeleted.Location = new System.Drawing.Point(540, 54);
            this.radGrpDeleted.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radGrpDeleted.Properties.Appearance.Options.UseBackColor = true;
            this.radGrpDeleted.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.radGrpDeleted.Properties.AppearanceDisabled.Options.UseBackColor = true;
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(696, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSearch.Location = new System.Drawing.Point(0, 24);
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.Size = new System.Drawing.Size(720, 217);
            this.tabControlSearch.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabControlSearch_SelectedTabChanged);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdVmMassnahme);
            this.tpgListe.Size = new System.Drawing.Size(708, 179);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.lblBeschlussVonSuche);
            this.tpgSuchen.Controls.Add(this.lblBeschlussVomBisSuche);
            this.tpgSuchen.Controls.Add(this.edtBeschlussVonSuche);
            this.tpgSuchen.Controls.Add(this.edtBeschlussBisSuche);
            this.tpgSuchen.Size = new System.Drawing.Size(708, 179);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.edtBeschlussBisSuche, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBeschlussVonSuche, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBeschlussVomBisSuche, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBeschlussVonSuche, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.radGrpDeleted, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            // 
            // qryVmMassnahme
            // 
            this.qryVmMassnahme.CanDelete = true;
            this.qryVmMassnahme.CanInsert = true;
            this.qryVmMassnahme.CanUpdate = true;
            this.qryVmMassnahme.HostControl = this;
            this.qryVmMassnahme.SelectStatement = resources.GetString("qryVmMassnahme.SelectStatement");
            this.qryVmMassnahme.TableName = "VmMassnahme";
            this.qryVmMassnahme.BeforeInsert += new System.EventHandler(this.qryVmMassnahme_BeforeInsert);
            this.qryVmMassnahme.AfterInsert += new System.EventHandler(this.qryVmMassnahme_AfterInsert);
            this.qryVmMassnahme.BeforePost += new System.EventHandler(this.qryVmMassnahme_BeforePost);
            this.qryVmMassnahme.AfterPost += new System.EventHandler(this.qryVmMassnahme_AfterPost);
            this.qryVmMassnahme.BeforeDelete += new System.EventHandler(this.qryVmMassnahme_BeforeDelete);
            this.qryVmMassnahme.PositionChanged += new System.EventHandler(this.qryVmMassnahme_PositionChanged);
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.Location = new System.Drawing.Point(6, 293);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(137, 24);
            this.lblBemerkung.TabIndex = 8;
            this.lblBemerkung.Text = "Bemerkung";
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBemerkung.BackColor = System.Drawing.Color.White;
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryVmMassnahme;
            this.edtBemerkung.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtBemerkung.Location = new System.Drawing.Point(149, 293);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Size = new System.Drawing.Size(542, 125);
            this.edtBemerkung.TabIndex = 11;
            // 
            // grdVmMassnahme
            // 
            this.grdVmMassnahme.DataSource = this.qryVmMassnahme;
            this.grdVmMassnahme.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdVmMassnahme.EmbeddedNavigator.Name = "";
            this.grdVmMassnahme.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdVmMassnahme.Location = new System.Drawing.Point(0, 0);
            this.grdVmMassnahme.MainView = this.grvVmMassnahme;
            this.grdVmMassnahme.Name = "grdVmMassnahme";
            this.grdVmMassnahme.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.grdVmMassnahme.Size = new System.Drawing.Size(708, 179);
            this.grdVmMassnahme.TabIndex = 0;
            this.grdVmMassnahme.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVmMassnahme});
            // 
            // grvVmMassnahme
            // 
            this.grvVmMassnahme.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvVmMassnahme.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmMassnahme.Appearance.Empty.Options.UseBackColor = true;
            this.grvVmMassnahme.Appearance.Empty.Options.UseFont = true;
            this.grvVmMassnahme.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmMassnahme.Appearance.EvenRow.Options.UseFont = true;
            this.grvVmMassnahme.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVmMassnahme.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmMassnahme.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvVmMassnahme.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvVmMassnahme.Appearance.FocusedCell.Options.UseFont = true;
            this.grvVmMassnahme.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvVmMassnahme.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVmMassnahme.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmMassnahme.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvVmMassnahme.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvVmMassnahme.Appearance.FocusedRow.Options.UseFont = true;
            this.grvVmMassnahme.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvVmMassnahme.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVmMassnahme.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvVmMassnahme.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVmMassnahme.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVmMassnahme.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVmMassnahme.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvVmMassnahme.Appearance.GroupRow.Options.UseFont = true;
            this.grvVmMassnahme.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvVmMassnahme.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvVmMassnahme.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvVmMassnahme.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVmMassnahme.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvVmMassnahme.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvVmMassnahme.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvVmMassnahme.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvVmMassnahme.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmMassnahme.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVmMassnahme.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvVmMassnahme.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvVmMassnahme.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvVmMassnahme.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvVmMassnahme.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvVmMassnahme.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmMassnahme.Appearance.OddRow.Options.UseFont = true;
            this.grvVmMassnahme.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvVmMassnahme.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmMassnahme.Appearance.Row.Options.UseBackColor = true;
            this.grvVmMassnahme.Appearance.Row.Options.UseFont = true;
            this.grvVmMassnahme.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmMassnahme.Appearance.SelectedRow.Options.UseFont = true;
            this.grvVmMassnahme.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvVmMassnahme.Appearance.VertLine.Options.UseBackColor = true;
            this.grvVmMassnahme.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvVmMassnahme.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBeschluss,
            this.colAufhebung,
            this.colZGB,
            this.colErnennung,
            this.colMT,
            this.colPrivat,
            this.colIsDeleted});
            this.grvVmMassnahme.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvVmMassnahme.GridControl = this.grdVmMassnahme;
            this.grvVmMassnahme.Name = "grvVmMassnahme";
            this.grvVmMassnahme.OptionsBehavior.Editable = false;
            this.grvVmMassnahme.OptionsCustomization.AllowFilter = false;
            this.grvVmMassnahme.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvVmMassnahme.OptionsNavigation.AutoFocusNewRow = true;
            this.grvVmMassnahme.OptionsNavigation.UseTabKey = false;
            this.grvVmMassnahme.OptionsView.ColumnAutoWidth = false;
            this.grvVmMassnahme.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvVmMassnahme.OptionsView.ShowGroupPanel = false;
            this.grvVmMassnahme.OptionsView.ShowIndicator = false;
            this.grvVmMassnahme.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            // 
            // colBeschluss
            // 
            this.colBeschluss.Caption = "Beschluss";
            this.colBeschluss.FieldName = "Beschluss";
            this.colBeschluss.Name = "colBeschluss";
            this.colBeschluss.Visible = true;
            this.colBeschluss.VisibleIndex = 0;
            // 
            // colAufhebung
            // 
            this.colAufhebung.Caption = "Aufhebung";
            this.colAufhebung.FieldName = "Aufhebung";
            this.colAufhebung.Name = "colAufhebung";
            this.colAufhebung.Visible = true;
            this.colAufhebung.VisibleIndex = 1;
            // 
            // colZGB
            // 
            this.colZGB.Caption = "ZGB";
            this.colZGB.FieldName = "ZGBListe";
            this.colZGB.Name = "colZGB";
            this.colZGB.Visible = true;
            this.colZGB.VisibleIndex = 2;
            this.colZGB.Width = 192;
            // 
            // colErnennung
            // 
            this.colErnennung.Caption = "Ernennung";
            this.colErnennung.FieldName = "Ernennung";
            this.colErnennung.Name = "colErnennung";
            this.colErnennung.Visible = true;
            this.colErnennung.VisibleIndex = 3;
            // 
            // colMT
            // 
            this.colMT.Caption = "MandatsträgerIn";
            this.colMT.FieldName = "MT";
            this.colMT.Name = "colMT";
            this.colMT.Visible = true;
            this.colMT.VisibleIndex = 4;
            this.colMT.Width = 150;
            // 
            // colPrivat
            // 
            this.colPrivat.Caption = "privat";
            this.colPrivat.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colPrivat.FieldName = "Privat";
            this.colPrivat.Name = "colPrivat";
            this.colPrivat.Visible = true;
            this.colPrivat.VisibleIndex = 5;
            this.colPrivat.Width = 43;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // colIsDeleted
            // 
            this.colIsDeleted.Caption = "gelöscht";
            this.colIsDeleted.FieldName = "IsDeleted";
            this.colIsDeleted.Name = "colIsDeleted";
            this.colIsDeleted.Visible = true;
            this.colIsDeleted.VisibleIndex = 6;
            // 
            // edtZGBCodes
            // 
            this.edtZGBCodes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtZGBCodes.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.edtZGBCodes.Appearance.Options.UseBackColor = true;
            this.edtZGBCodes.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtZGBCodes.CheckOnClick = true;
            this.edtZGBCodes.DataMember = "ZGBCodes";
            this.edtZGBCodes.DataSource = this.qryVmMassnahme;
            this.edtZGBCodes.Location = new System.Drawing.Point(358, 12);
            this.edtZGBCodes.Name = "edtZGBCodes";
            this.edtZGBCodes.Size = new System.Drawing.Size(333, 236);
            this.edtZGBCodes.TabIndex = 9;
            // 
            // edtErnennungsurkundeDokID
            // 
            this.edtErnennungsurkundeDokID.AllowDrop = true;
            this.edtErnennungsurkundeDokID.Context = "VmErnennungsurkunde";
            this.edtErnennungsurkundeDokID.DataMember = "ErnennungsurkundeDokID";
            this.edtErnennungsurkundeDokID.DataSource = this.qryVmMassnahme;
            this.edtErnennungsurkundeDokID.Location = new System.Drawing.Point(149, 72);
            this.edtErnennungsurkundeDokID.Name = "edtErnennungsurkundeDokID";
            this.edtErnennungsurkundeDokID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErnennungsurkundeDokID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErnennungsurkundeDokID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErnennungsurkundeDokID.Properties.Appearance.Options.UseBackColor = true;
            this.edtErnennungsurkundeDokID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErnennungsurkundeDokID.Properties.Appearance.Options.UseFont = true;
            this.edtErnennungsurkundeDokID.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErnennungsurkundeDokID.Properties.AppearanceDisabled.Options.UseFont = true;
            this.edtErnennungsurkundeDokID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtErnennungsurkundeDokID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtErnennungsurkundeDokID.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtErnennungsurkundeDokID.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtErnennungsurkundeDokID.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtErnennungsurkundeDokID.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "Dokument importieren")});
            this.edtErnennungsurkundeDokID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtErnennungsurkundeDokID.Properties.ReadOnly = true;
            this.edtErnennungsurkundeDokID.Size = new System.Drawing.Size(167, 24);
            this.edtErnennungsurkundeDokID.TabIndex = 3;
            // 
            // lblDatumVon
            // 
            this.lblDatumVon.Location = new System.Drawing.Point(6, 12);
            this.lblDatumVon.Name = "lblDatumVon";
            this.lblDatumVon.Size = new System.Drawing.Size(137, 24);
            this.lblDatumVon.TabIndex = 23;
            this.lblDatumVon.Text = "Beschluss vom";
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.DataMember = "DatumVon";
            this.edtDatumVon.DataSource = this.qryVmMassnahme;
            this.edtDatumVon.EditValue = new System.DateTime(2004, 6, 6, 0, 0, 0, 0);
            this.edtDatumVon.Location = new System.Drawing.Point(149, 12);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(90, 24);
            this.edtDatumVon.TabIndex = 1;
            // 
            // lblDatumBis
            // 
            this.lblDatumBis.Location = new System.Drawing.Point(6, 224);
            this.lblDatumBis.Name = "lblDatumBis";
            this.lblDatumBis.Size = new System.Drawing.Size(134, 24);
            this.lblDatumBis.TabIndex = 26;
            this.lblDatumBis.Text = "Aufhebung";
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.DataMember = "DatumBis";
            this.edtDatumBis.DataSource = this.qryVmMassnahme;
            this.edtDatumBis.EditValue = new System.DateTime(2004, 6, 6, 0, 0, 0, 0);
            this.edtDatumBis.Location = new System.Drawing.Point(149, 224);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(90, 24);
            this.edtDatumBis.TabIndex = 8;
            // 
            // lblZGBCodes
            // 
            this.lblZGBCodes.Location = new System.Drawing.Point(307, 12);
            this.lblZGBCodes.Name = "lblZGBCodes";
            this.lblZGBCodes.Size = new System.Drawing.Size(28, 24);
            this.lblZGBCodes.TabIndex = 28;
            this.lblZGBCodes.Text = "ZGB";
            // 
            // lblErnennungsurkundeDokID
            // 
            this.lblErnennungsurkundeDokID.Location = new System.Drawing.Point(6, 72);
            this.lblErnennungsurkundeDokID.Name = "lblErnennungsurkundeDokID";
            this.lblErnennungsurkundeDokID.Size = new System.Drawing.Size(137, 24);
            this.lblErnennungsurkundeDokID.TabIndex = 610;
            this.lblErnennungsurkundeDokID.Text = "Ernennungsurkunde";
            // 
            // lblErnennung
            // 
            this.lblErnennung.Location = new System.Drawing.Point(6, 42);
            this.lblErnennung.Name = "lblErnennung";
            this.lblErnennung.Size = new System.Drawing.Size(137, 24);
            this.lblErnennung.TabIndex = 611;
            this.lblErnennung.Text = "Ernennung";
            // 
            // edtErnennung
            // 
            this.edtErnennung.DataMember = "Ernennung";
            this.edtErnennung.DataSource = this.qryVmMassnahme;
            this.edtErnennung.EditValue = new System.DateTime(2004, 6, 6, 0, 0, 0, 0);
            this.edtErnennung.Location = new System.Drawing.Point(149, 42);
            this.edtErnennung.Name = "edtErnennung";
            this.edtErnennung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtErnennung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErnennung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErnennung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErnennung.Properties.Appearance.Options.UseBackColor = true;
            this.edtErnennung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErnennung.Properties.Appearance.Options.UseFont = true;
            this.edtErnennung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtErnennung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtErnennung.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtErnennung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtErnennung.Properties.ShowToday = false;
            this.edtErnennung.Size = new System.Drawing.Size(90, 24);
            this.edtErnennung.TabIndex = 2;
            // 
            // lblVmPriMa
            // 
            this.lblVmPriMa.Location = new System.Drawing.Point(3, 132);
            this.lblVmPriMa.Name = "lblVmPriMa";
            this.lblVmPriMa.Size = new System.Drawing.Size(137, 24);
            this.lblVmPriMa.TabIndex = 615;
            this.lblVmPriMa.Text = "Private MandatsträgerIn";
            // 
            // edtVmPriMa
            // 
            this.edtVmPriMa.DataMember = "VmPriMa";
            this.edtVmPriMa.DataSource = this.qryVmMassnahme;
            this.edtVmPriMa.Location = new System.Drawing.Point(149, 132);
            this.edtVmPriMa.Name = "edtVmPriMa";
            this.edtVmPriMa.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVmPriMa.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVmPriMa.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVmPriMa.Properties.Appearance.Options.UseBackColor = true;
            this.edtVmPriMa.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVmPriMa.Properties.Appearance.Options.UseFont = true;
            this.edtVmPriMa.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtVmPriMa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtVmPriMa.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVmPriMa.Size = new System.Drawing.Size(167, 24);
            this.edtVmPriMa.TabIndex = 5;
            this.edtVmPriMa.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtVmPriMa_UserModifiedFld);
            // 
            // lblSAR
            // 
            this.lblSAR.Location = new System.Drawing.Point(3, 102);
            this.lblSAR.Name = "lblSAR";
            this.lblSAR.Size = new System.Drawing.Size(137, 24);
            this.lblSAR.TabIndex = 617;
            this.lblSAR.Text = "Amtliche MandatsträgerIn";
            // 
            // edtSAR
            // 
            this.edtSAR.DataMember = "SAR";
            this.edtSAR.DataSource = this.qryVmMassnahme;
            this.edtSAR.Location = new System.Drawing.Point(149, 102);
            this.edtSAR.Name = "edtSAR";
            this.edtSAR.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSAR.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSAR.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSAR.Properties.Appearance.Options.UseBackColor = true;
            this.edtSAR.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSAR.Properties.Appearance.Options.UseFont = true;
            this.edtSAR.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtSAR.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtSAR.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSAR.Size = new System.Drawing.Size(167, 24);
            this.edtSAR.TabIndex = 4;
            this.edtSAR.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSAR_UserModifiedFld);
            // 
            // ZGBinvisible
            // 
            this.ZGBinvisible.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.ZGBinvisible.Appearance.Options.UseBackColor = true;
            this.ZGBinvisible.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.ZGBinvisible.CheckOnClick = true;
            this.ZGBinvisible.Location = new System.Drawing.Point(6, 320);
            this.ZGBinvisible.LOVFilter = "1";
            this.ZGBinvisible.LOVName = "VmZGB";
            this.ZGBinvisible.Name = "ZGBinvisible";
            this.ZGBinvisible.Size = new System.Drawing.Size(92, 58);
            this.ZGBinvisible.TabIndex = 618;
            this.ZGBinvisible.Visible = false;
            // 
            // btnNeueMT
            // 
            this.btnNeueMT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNeueMT.Location = new System.Drawing.Point(149, 162);
            this.btnNeueMT.Name = "btnNeueMT";
            this.btnNeueMT.Size = new System.Drawing.Size(167, 24);
            this.btnNeueMT.TabIndex = 6;
            this.btnNeueMT.Text = "Wechsel MandatsträgerIn";
            this.btnNeueMT.UseVisualStyleBackColor = false;
            this.btnNeueMT.Click += new System.EventHandler(this.btnNeueMT_Click);
            // 
            // lblWeitereZGB
            // 
            this.lblWeitereZGB.Location = new System.Drawing.Point(6, 254);
            this.lblWeitereZGB.Name = "lblWeitereZGB";
            this.lblWeitereZGB.Size = new System.Drawing.Size(137, 24);
            this.lblWeitereZGB.TabIndex = 619;
            this.lblWeitereZGB.Text = "Andere ZGB";
            // 
            // edtWeitereZGB
            // 
            this.edtWeitereZGB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtWeitereZGB.DataMember = "WeitereZGB";
            this.edtWeitereZGB.DataSource = this.qryVmMassnahme;
            this.edtWeitereZGB.Location = new System.Drawing.Point(149, 254);
            this.edtWeitereZGB.Name = "edtWeitereZGB";
            this.edtWeitereZGB.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWeitereZGB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWeitereZGB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWeitereZGB.Properties.Appearance.Options.UseBackColor = true;
            this.edtWeitereZGB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWeitereZGB.Properties.Appearance.Options.UseFont = true;
            this.edtWeitereZGB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtWeitereZGB.Size = new System.Drawing.Size(542, 24);
            this.edtWeitereZGB.TabIndex = 10;
            // 
            // lblElterlicheSorgeCode
            // 
            this.lblElterlicheSorgeCode.Location = new System.Drawing.Point(6, 192);
            this.lblElterlicheSorgeCode.Name = "lblElterlicheSorgeCode";
            this.lblElterlicheSorgeCode.Size = new System.Drawing.Size(137, 24);
            this.lblElterlicheSorgeCode.TabIndex = 620;
            this.lblElterlicheSorgeCode.Text = "Elterliche Sorge";
            // 
            // edtElterlicheSorgeCode
            // 
            this.edtElterlicheSorgeCode.DataMember = "ElterlicheSorgeCode";
            this.edtElterlicheSorgeCode.DataSource = this.qryVmMassnahme;
            this.edtElterlicheSorgeCode.Location = new System.Drawing.Point(149, 192);
            this.edtElterlicheSorgeCode.LOVName = "VmElterlicheSorge";
            this.edtElterlicheSorgeCode.Name = "edtElterlicheSorgeCode";
            this.edtElterlicheSorgeCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtElterlicheSorgeCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtElterlicheSorgeCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtElterlicheSorgeCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtElterlicheSorgeCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtElterlicheSorgeCode.Properties.Appearance.Options.UseFont = true;
            this.edtElterlicheSorgeCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtElterlicheSorgeCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtElterlicheSorgeCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtElterlicheSorgeCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtElterlicheSorgeCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtElterlicheSorgeCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtElterlicheSorgeCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtElterlicheSorgeCode.Properties.NullText = "";
            this.edtElterlicheSorgeCode.Properties.ShowFooter = false;
            this.edtElterlicheSorgeCode.Properties.ShowHeader = false;
            this.edtElterlicheSorgeCode.Size = new System.Drawing.Size(167, 24);
            this.edtElterlicheSorgeCode.TabIndex = 7;
            // 
            // panTitel
            // 
            this.panTitel.Controls.Add(this.picTitel);
            this.panTitel.Controls.Add(this.lblTitel);
            this.panTitel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTitel.Location = new System.Drawing.Point(0, 0);
            this.panTitel.Name = "panTitel";
            this.panTitel.Size = new System.Drawing.Size(720, 24);
            this.panTitel.TabIndex = 621;
            // 
            // picTitel
            // 
            this.picTitel.Location = new System.Drawing.Point(3, 3);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(13, 16);
            this.picTitel.TabIndex = 366;
            this.picTitel.TabStop = false;
            // 
            // lblTitel
            // 
            this.lblTitel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(23, 3);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(694, 19);
            this.lblTitel.TabIndex = 365;
            this.lblTitel.Text = "Titel";
            // 
            // panelDetail
            // 
            this.panelDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDetail.Controls.Add(this.ctlLogischLoeschen);
            this.panelDetail.Controls.Add(this.lblErnennungsurkundeDokID);
            this.panelDetail.Controls.Add(this.edtErnennungsurkundeDokID);
            this.panelDetail.Controls.Add(this.lblSAR);
            this.panelDetail.Controls.Add(this.ZGBinvisible);
            this.panelDetail.Controls.Add(this.edtElterlicheSorgeCode);
            this.panelDetail.Controls.Add(this.edtZGBCodes);
            this.panelDetail.Controls.Add(this.lblZGBCodes);
            this.panelDetail.Controls.Add(this.edtErnennung);
            this.panelDetail.Controls.Add(this.edtWeitereZGB);
            this.panelDetail.Controls.Add(this.lblErnennung);
            this.panelDetail.Controls.Add(this.lblElterlicheSorgeCode);
            this.panelDetail.Controls.Add(this.lblWeitereZGB);
            this.panelDetail.Controls.Add(this.edtDatumVon);
            this.panelDetail.Controls.Add(this.lblDatumVon);
            this.panelDetail.Controls.Add(this.edtSAR);
            this.panelDetail.Controls.Add(this.lblVmPriMa);
            this.panelDetail.Controls.Add(this.edtVmPriMa);
            this.panelDetail.Controls.Add(this.edtBemerkung);
            this.panelDetail.Controls.Add(this.lblBemerkung);
            this.panelDetail.Controls.Add(this.btnNeueMT);
            this.panelDetail.Controls.Add(this.lblDatumBis);
            this.panelDetail.Controls.Add(this.edtDatumBis);
            this.panelDetail.Location = new System.Drawing.Point(0, 247);
            this.panelDetail.Name = "panelDetail";
            this.panelDetail.Size = new System.Drawing.Size(720, 483);
            this.panelDetail.TabIndex = 622;
            // 
            // ctlLogischLoeschen
            // 
            this.ctlLogischLoeschen.ActiveSQLQuery = this.qryVmMassnahme;
            this.ctlLogischLoeschen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlLogischLoeschen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlLogischLoeschen.Location = new System.Drawing.Point(9, 424);
            this.ctlLogischLoeschen.Name = "ctlLogischLoeschen";
            this.ctlLogischLoeschen.Size = new System.Drawing.Size(682, 56);
            this.ctlLogischLoeschen.TabIndex = 623;
            this.ctlLogischLoeschen.RestoreClick += new System.EventHandler(this.btnRestoreDocument_Click);
            // 
            // lblBeschlussVonSuche
            // 
            this.lblBeschlussVonSuche.Location = new System.Drawing.Point(17, 35);
            this.lblBeschlussVonSuche.Name = "lblBeschlussVonSuche";
            this.lblBeschlussVonSuche.Size = new System.Drawing.Size(117, 24);
            this.lblBeschlussVonSuche.TabIndex = 68;
            this.lblBeschlussVonSuche.Text = "Beschluss vom (von)";
            // 
            // lblBeschlussVomBisSuche
            // 
            this.lblBeschlussVomBisSuche.Location = new System.Drawing.Point(17, 68);
            this.lblBeschlussVomBisSuche.Name = "lblBeschlussVomBisSuche";
            this.lblBeschlussVomBisSuche.Size = new System.Drawing.Size(117, 24);
            this.lblBeschlussVomBisSuche.TabIndex = 69;
            this.lblBeschlussVomBisSuche.Text = "Beschluss vom (bis)";
            // 
            // edtBeschlussVonSuche
            // 
            this.edtBeschlussVonSuche.EditValue = null;
            this.edtBeschlussVonSuche.Location = new System.Drawing.Point(140, 38);
            this.edtBeschlussVonSuche.Name = "edtBeschlussVonSuche";
            this.edtBeschlussVonSuche.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBeschlussVonSuche.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBeschlussVonSuche.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBeschlussVonSuche.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBeschlussVonSuche.Properties.Appearance.Options.UseBackColor = true;
            this.edtBeschlussVonSuche.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBeschlussVonSuche.Properties.Appearance.Options.UseFont = true;
            this.edtBeschlussVonSuche.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.edtBeschlussVonSuche.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtBeschlussVonSuche.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.edtBeschlussVonSuche.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBeschlussVonSuche.Properties.ShowToday = false;
            this.edtBeschlussVonSuche.Size = new System.Drawing.Size(122, 24);
            this.edtBeschlussVonSuche.TabIndex = 70;
            // 
            // edtBeschlussBisSuche
            // 
            this.edtBeschlussBisSuche.EditValue = null;
            this.edtBeschlussBisSuche.Location = new System.Drawing.Point(140, 68);
            this.edtBeschlussBisSuche.Name = "edtBeschlussBisSuche";
            this.edtBeschlussBisSuche.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBeschlussBisSuche.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBeschlussBisSuche.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBeschlussBisSuche.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBeschlussBisSuche.Properties.Appearance.Options.UseBackColor = true;
            this.edtBeschlussBisSuche.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBeschlussBisSuche.Properties.Appearance.Options.UseFont = true;
            this.edtBeschlussBisSuche.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.edtBeschlussBisSuche.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtBeschlussBisSuche.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12)});
            this.edtBeschlussBisSuche.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBeschlussBisSuche.Properties.ShowToday = false;
            this.edtBeschlussBisSuche.Size = new System.Drawing.Size(122, 24);
            this.edtBeschlussBisSuche.TabIndex = 71;
            // 
            // CtlVmMassnahmen
            // 
            this.ActiveSQLQuery = this.qryVmMassnahme;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(720, 688);
            
            this.Controls.Add(this.panTitel);
            this.Controls.Add(this.panelDetail);
            this.Name = "CtlVmMassnahmen";
            this.Size = new System.Drawing.Size(720, 733);
            this.Load += new System.EventHandler(this.CtlVmMassnahmen_Load);
            this.Controls.SetChildIndex(this.panelDetail, 0);
            this.Controls.SetChildIndex(this.panTitel, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            ((System.ComponentModel.ISupportInitialize)(this.radGrpDeleted.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qryVmMassnahme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVmMassnahme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVmMassnahme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZGBCodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErnennungsurkundeDokID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZGBCodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErnennungsurkundeDokID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErnennung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErnennung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVmPriMa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVmPriMa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSAR.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZGBinvisible)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWeitereZGB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWeitereZGB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblElterlicheSorgeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtElterlicheSorgeCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtElterlicheSorgeCode)).EndInit();
            this.panTitel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            this.panelDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblBeschlussVonSuche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeschlussVomBisSuche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeschlussVonSuche.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeschlussBisSuche.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissCheckedLookupEdit ZGBinvisible;
        private KiSS4.Gui.KissButton btnNeueMT;
        private DevExpress.XtraGrid.Columns.GridColumn colAufhebung;
        private DevExpress.XtraGrid.Columns.GridColumn colBeschluss;
        private DevExpress.XtraGrid.Columns.GridColumn colErnennung;
        private DevExpress.XtraGrid.Columns.GridColumn colIsDeleted;
        private DevExpress.XtraGrid.Columns.GridColumn colMT;
        private DevExpress.XtraGrid.Columns.GridColumn colPrivat;
        private DevExpress.XtraGrid.Columns.GridColumn colZGB;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Common.CtlLogischesLoeschen ctlLogischLoeschen;
        private KiSS4.Gui.KissRTFEdit edtBemerkung;
        private KiSS4.Gui.KissDateEdit edtBeschlussBisSuche;
        private KiSS4.Gui.KissDateEdit edtBeschlussVonSuche;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissLookUpEdit edtElterlicheSorgeCode;
        private KiSS4.Gui.KissDateEdit edtErnennung;
        private KiSS4.Dokument.XDokument edtErnennungsurkundeDokID;
        private KiSS4.Gui.KissButtonEdit edtSAR;
        private KiSS4.Gui.KissButtonEdit edtVmPriMa;
        private KiSS4.Gui.KissTextEdit edtWeitereZGB;
        private KiSS4.Gui.KissCheckedLookupEdit edtZGBCodes;
        private KiSS4.Gui.KissGrid grdVmMassnahme;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVmMassnahme;
        private KiSS4.Gui.KissLabel lblBeschlussVomBisSuche;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblBeschlussVonSuche;
        private KiSS4.Gui.KissLabel lblDatumBis;
        private KiSS4.Gui.KissLabel lblDatumVon;
        private KiSS4.Gui.KissLabel lblElterlicheSorgeCode;
        private KiSS4.Gui.KissLabel lblErnennung;
        private KiSS4.Gui.KissLabel lblErnennungsurkundeDokID;
        private KiSS4.Gui.KissLabel lblSAR;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissLabel lblVmPriMa;
        private KiSS4.Gui.KissLabel lblWeitereZGB;
        private KiSS4.Gui.KissLabel lblZGBCodes;
        private System.Windows.Forms.Panel panTitel;
        private System.Windows.Forms.Panel panelDetail;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryVmMassnahme;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
    }
}
