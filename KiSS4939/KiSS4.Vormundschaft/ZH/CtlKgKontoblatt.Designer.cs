namespace KiSS4.Vormundschaft.ZH
{
    partial class CtlKgKontoblatt
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject17 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject16 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject15 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject14 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject13 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKgKontoblatt));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grid = new KiSS4.Gui.KissGrid();
            this.qryKontoblaetter = new KiSS4.DB.SqlQuery(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKtoName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValuta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMandant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGKtoNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetragSoll = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetragHaben = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaldo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBelegNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDokument = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtOpenDocumentEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.lblMandant = new KiSS4.Gui.KissLabel();
            this.btnExpand = new KiSS4.Gui.KissButton();
            this.btnCollapse = new KiSS4.Gui.KissButton();
            this.edtDokumentHidden = new KiSS4.Dokument.XDokument();
            this.edtMandant = new KiSS4.Gui.KissButtonEdit();
            this.edtKontoVon = new KiSS4.Gui.KissButtonEdit();
            this.edtKontoBis = new KiSS4.Gui.KissButtonEdit();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.label31 = new KiSS4.Gui.KissLabel();
            this.edtValutaVon = new KiSS4.Gui.KissDateEdit();
            this.edtValutaBis = new KiSS4.Gui.KissDateEdit();
            this.label26 = new KiSS4.Gui.KissLabel();
            this.label4 = new KiSS4.Gui.KissLabel();
            this.label5 = new KiSS4.Gui.KissLabel();
            this.edtKontonameVon = new KiSS4.Gui.KissTextEdit();
            this.edtKontonameBis = new KiSS4.Gui.KissTextEdit();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.grdPeriode = new KiSS4.Gui.KissGrid();
            this.qryPeriode = new KiSS4.DB.SqlQuery(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label40 = new KiSS4.Gui.KissLabel();
            this.edtAdresse = new KiSS4.Gui.KissTextEdit();
            this.edtBaPersonID = new KiSS4.Gui.KissTextEdit();
            this.edtMT = new KiSS4.Gui.KissTextEdit();
            this.label10 = new KiSS4.Gui.KissLabel();
            this.label1 = new KiSS4.Gui.KissLabel();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.lblAusgeglicheneAusblenden = new KiSS4.Gui.KissLabel();
            this.btnDrucken = new KiSS4.Gui.KissButton();
            this.edtAusgeglicheneKDAusblenden = new KiSS4.Gui.KissCheckEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.grdDokumente = new KiSS4.Gui.KissGrid();
            this.qryDocument = new KiSS4.DB.SqlQuery(this.components);
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDokumentTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDokStichworte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDokErstellungsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDokModified = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeckblatt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSelektion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemPictureEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.repositoryItemImageEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.lblDokumente = new KiSS4.Gui.KissLabel();
            this.edtDokument = new KiSS4.Dokument.XDokument();
            this.btnBudgetPosition = new KiSS4.Gui.KissButton();
            this.btnDokumenteDrucken = new KiSS4.Gui.KissButton();
            this.btnKeineDokumenteAuswaehlen = new KiSS4.Gui.KissButton();
            this.btnAlleDokumenteAuswaehlen = new KiSS4.Gui.KissButton();
            this.edtDrucker = new KiSS4.Gui.KissComboBox();
            this.edtDocumentHidden = new KiSS4.Dokument.XDokument();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKontoblaetter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOpenDocumentEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentHidden.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMandant.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontoVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontoBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValutaVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValutaBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontonameVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontonameBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPeriode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPeriode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusgeglicheneAusblenden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusgeglicheneKDAusblenden.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDokumente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryDocument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokumente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokument.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDrucker.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDocumentHidden.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(946, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSearch.Location = new System.Drawing.Point(3, 30);
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.Size = new System.Drawing.Size(964, 487);
            this.tabControlSearch.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabControlSearch_SelectedTabChanged);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.edtDocumentHidden);
            this.tpgListe.Controls.Add(this.edtDrucker);
            this.tpgListe.Controls.Add(this.btnAlleDokumenteAuswaehlen);
            this.tpgListe.Controls.Add(this.btnKeineDokumenteAuswaehlen);
            this.tpgListe.Controls.Add(this.btnDokumenteDrucken);
            this.tpgListe.Controls.Add(this.btnBudgetPosition);
            this.tpgListe.Controls.Add(this.edtDokument);
            this.tpgListe.Controls.Add(this.lblDokumente);
            this.tpgListe.Controls.Add(this.grdDokumente);
            this.tpgListe.Controls.Add(this.edtDokumentHidden);
            this.tpgListe.Controls.Add(this.btnCollapse);
            this.tpgListe.Controls.Add(this.btnExpand);
            this.tpgListe.Controls.Add(this.lblMandant);
            this.tpgListe.Controls.Add(this.grid);
            this.tpgListe.Size = new System.Drawing.Size(952, 449);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtAusgeglicheneKDAusblenden);
            this.tpgSuchen.Controls.Add(this.btnDrucken);
            this.tpgSuchen.Controls.Add(this.lblAusgeglicheneAusblenden);
            this.tpgSuchen.Controls.Add(this.kissLabel2);
            this.tpgSuchen.Controls.Add(this.kissLabel3);
            this.tpgSuchen.Controls.Add(this.label1);
            this.tpgSuchen.Controls.Add(this.label10);
            this.tpgSuchen.Controls.Add(this.edtMT);
            this.tpgSuchen.Controls.Add(this.edtBaPersonID);
            this.tpgSuchen.Controls.Add(this.edtAdresse);
            this.tpgSuchen.Controls.Add(this.label40);
            this.tpgSuchen.Controls.Add(this.grdPeriode);
            this.tpgSuchen.Controls.Add(this.kissLabel1);
            this.tpgSuchen.Controls.Add(this.edtKontonameBis);
            this.tpgSuchen.Controls.Add(this.edtKontonameVon);
            this.tpgSuchen.Controls.Add(this.label5);
            this.tpgSuchen.Controls.Add(this.label4);
            this.tpgSuchen.Controls.Add(this.label26);
            this.tpgSuchen.Controls.Add(this.edtValutaBis);
            this.tpgSuchen.Controls.Add(this.edtValutaVon);
            this.tpgSuchen.Controls.Add(this.label31);
            this.tpgSuchen.Controls.Add(this.edtDatumBis);
            this.tpgSuchen.Controls.Add(this.edtDatumVon);
            this.tpgSuchen.Controls.Add(this.edtKontoBis);
            this.tpgSuchen.Controls.Add(this.edtKontoVon);
            this.tpgSuchen.Controls.Add(this.edtMandant);
            this.tpgSuchen.Size = new System.Drawing.Size(952, 449);
            this.tpgSuchen.TabIndex = 0;
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.edtMandant, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtKontoVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtKontoBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.label31, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtValutaVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtValutaBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.label26, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.label4, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.label5, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtKontonameVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtKontonameBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel1, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.grdPeriode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.label40, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAdresse, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBaPersonID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtMT, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.label10, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.label1, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel3, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel2, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblAusgeglicheneAusblenden, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.btnDrucken, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAusgeglicheneKDAusblenden, 0);
            // 
            // grid
            // 
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.DataSource = this.qryKontoblaetter;
            // 
            // 
            // 
            this.grid.EmbeddedNavigator.Name = "grid.EmbeddedNavigator";
            this.grid.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grid.Location = new System.Drawing.Point(3, 33);
            this.grid.MainView = this.gridView1;
            this.grid.Name = "grid";
            this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.edtOpenDocumentEdit,
            this.repositoryItemPictureEdit1,
            this.repositoryItemImageEdit1});
            this.grid.Size = new System.Drawing.Size(946, 227);
            this.grid.TabIndex = 2;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.grid.DoubleClick += new System.EventHandler(this.grid_DoubleClick);
            // 
            // qryKontoblaetter
            // 
            this.qryKontoblaetter.FillTimeOut = 60;
            this.qryKontoblaetter.HostControl = this;
            this.qryKontoblaetter.SelectStatement = "select 1 where 1 = 2";
            this.qryKontoblaetter.ColumnChanged += new System.Data.DataColumnChangeEventHandler(this.qryKontoblaetter_ColumnChanged);
            this.qryKontoblaetter.PositionChanged += new System.EventHandler(this.qryKontoblaetter_PositionChanged);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.Empty.Options.UseFont = true;
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
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
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKtoName,
            this.colDatum,
            this.colValuta,
            this.colMandant,
            this.colGKtoNr,
            this.colText,
            this.colBetragSoll,
            this.colBetragHaben,
            this.colSaldo,
            this.colBelegNr,
            this.colDokument});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.grid;
            this.gridView1.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsFilter.AllowFilterEditor = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.UseTabKey = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.CustomDrawGroupRow += new DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(this.gridView1_CustomDrawGroupRow);
            // 
            // colKtoName
            // 
            this.colKtoName.Caption = "Konto";
            this.colKtoName.FieldName = "KtoName";
            this.colKtoName.Name = "colKtoName";
            this.colKtoName.Width = 59;
            // 
            // colDatum
            // 
            this.colDatum.Caption = "Buch.-Datum";
            this.colDatum.FieldName = "BuchungsDatum";
            this.colDatum.Name = "colDatum";
            this.colDatum.OptionsColumn.ReadOnly = true;
            this.colDatum.Visible = true;
            this.colDatum.VisibleIndex = 0;
            this.colDatum.Width = 97;
            // 
            // colValuta
            // 
            this.colValuta.Caption = "Valuta";
            this.colValuta.FieldName = "ValutaDatum";
            this.colValuta.Name = "colValuta";
            this.colValuta.OptionsColumn.ReadOnly = true;
            this.colValuta.Visible = true;
            this.colValuta.VisibleIndex = 1;
            // 
            // colMandant
            // 
            this.colMandant.Caption = "Person m. zivilr. Massn.";
            this.colMandant.FieldName = "Mandant";
            this.colMandant.Name = "colMandant";
            this.colMandant.Width = 115;
            // 
            // colGKtoNr
            // 
            this.colGKtoNr.Caption = "Gegenkto";
            this.colGKtoNr.FieldName = "GKtoNr";
            this.colGKtoNr.Name = "colGKtoNr";
            this.colGKtoNr.OptionsColumn.ReadOnly = true;
            this.colGKtoNr.Visible = true;
            this.colGKtoNr.VisibleIndex = 2;
            this.colGKtoNr.Width = 64;
            // 
            // colText
            // 
            this.colText.Caption = "Text";
            this.colText.FieldName = "Text";
            this.colText.Name = "colText";
            this.colText.OptionsColumn.ReadOnly = true;
            this.colText.Visible = true;
            this.colText.VisibleIndex = 3;
            this.colText.Width = 210;
            // 
            // colBetragSoll
            // 
            this.colBetragSoll.Caption = "Soll";
            this.colBetragSoll.DisplayFormat.FormatString = "#,##0.00";
            this.colBetragSoll.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetragSoll.FieldName = "BetragSoll";
            this.colBetragSoll.Name = "colBetragSoll";
            this.colBetragSoll.OptionsColumn.ReadOnly = true;
            this.colBetragSoll.Visible = true;
            this.colBetragSoll.VisibleIndex = 4;
            // 
            // colBetragHaben
            // 
            this.colBetragHaben.Caption = "Haben";
            this.colBetragHaben.DisplayFormat.FormatString = "#,##0.00";
            this.colBetragHaben.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetragHaben.FieldName = "BetragHaben";
            this.colBetragHaben.Name = "colBetragHaben";
            this.colBetragHaben.OptionsColumn.ReadOnly = true;
            this.colBetragHaben.Visible = true;
            this.colBetragHaben.VisibleIndex = 5;
            // 
            // colSaldo
            // 
            this.colSaldo.Caption = "Saldo";
            this.colSaldo.DisplayFormat.FormatString = "#,##0.00";
            this.colSaldo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSaldo.FieldName = "Saldo";
            this.colSaldo.Name = "colSaldo";
            this.colSaldo.OptionsColumn.ReadOnly = true;
            this.colSaldo.Visible = true;
            this.colSaldo.VisibleIndex = 6;
            this.colSaldo.Width = 80;
            // 
            // colBelegNr
            // 
            this.colBelegNr.Caption = "Beleg";
            this.colBelegNr.FieldName = "KgBuchungID";
            this.colBelegNr.Name = "colBelegNr";
            this.colBelegNr.OptionsColumn.ReadOnly = true;
            this.colBelegNr.Visible = true;
            this.colBelegNr.VisibleIndex = 7;
            this.colBelegNr.Width = 69;
            // 
            // colDokument
            // 
            this.colDokument.AppearanceCell.Options.UseTextOptions = true;
            this.colDokument.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDokument.Caption = "Dok";
            this.colDokument.FieldName = "AnzahlDoc";
            this.colDokument.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.colDokument.Name = "colDokument";
            this.colDokument.Visible = true;
            this.colDokument.VisibleIndex = 8;
            this.colDokument.Width = 36;
            // 
            // edtOpenDocumentEdit
            // 
            this.edtOpenDocumentEdit.AutoHeight = false;
            this.edtOpenDocumentEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.OK)});
            this.edtOpenDocumentEdit.Name = "edtOpenDocumentEdit";
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            // 
            // repositoryItemImageEdit1
            // 
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            this.repositoryItemImageEdit1.ReadOnly = true;
            // 
            // lblMandant
            // 
            this.lblMandant.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblMandant.Location = new System.Drawing.Point(0, 5);
            this.lblMandant.Name = "lblMandant";
            this.lblMandant.Size = new System.Drawing.Size(604, 25);
            this.lblMandant.TabIndex = 2;
            this.lblMandant.Text = "Person mit zivilrechtlicher Massnahme";
            this.lblMandant.UseCompatibleTextRendering = true;
            // 
            // btnExpand
            // 
            this.btnExpand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpand.Image = ((System.Drawing.Image)(resources.GetObject("btnExpand.Image")));
            this.btnExpand.Location = new System.Drawing.Point(631, 3);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(24, 24);
            this.btnExpand.TabIndex = 315;
            this.btnExpand.UseCompatibleTextRendering = true;
            this.btnExpand.UseVisualStyleBackColor = false;
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // btnCollapse
            // 
            this.btnCollapse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCollapse.Image = ((System.Drawing.Image)(resources.GetObject("btnCollapse.Image")));
            this.btnCollapse.Location = new System.Drawing.Point(661, 3);
            this.btnCollapse.Name = "btnCollapse";
            this.btnCollapse.Size = new System.Drawing.Size(24, 24);
            this.btnCollapse.TabIndex = 316;
            this.btnCollapse.UseCompatibleTextRendering = true;
            this.btnCollapse.UseVisualStyleBackColor = false;
            this.btnCollapse.Click += new System.EventHandler(this.btnCollapse_Click);
            // 
            // edtDokumentHidden
            // 
            this.edtDokumentHidden.Context = null;
            this.edtDokumentHidden.DataMember = null;
            this.edtDokumentHidden.DataSource = this.qryKontoblaetter;
            this.edtDokumentHidden.Location = new System.Drawing.Point(318, 4);
            this.edtDokumentHidden.Name = "edtDokumentHidden";
            this.edtDokumentHidden.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDokumentHidden.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDokumentHidden.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDokumentHidden.Properties.Appearance.Options.UseBackColor = true;
            this.edtDokumentHidden.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDokumentHidden.Properties.Appearance.Options.UseFont = true;
            this.edtDokumentHidden.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.edtDokumentHidden.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDokumentHidden.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDokumentHidden.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDokumentHidden.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDokumentHidden.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10, "Dokument importieren")});
            this.edtDokumentHidden.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDokumentHidden.Properties.ReadOnly = true;
            this.edtDokumentHidden.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtDokumentHidden.Size = new System.Drawing.Size(156, 24);
            this.edtDokumentHidden.TabIndex = 318;
            this.edtDokumentHidden.Visible = false;
            // 
            // edtMandant
            // 
            this.edtMandant.Location = new System.Drawing.Point(136, 47);
            this.edtMandant.Name = "edtMandant";
            this.edtMandant.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMandant.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMandant.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMandant.Properties.Appearance.Options.UseBackColor = true;
            this.edtMandant.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMandant.Properties.Appearance.Options.UseFont = true;
            this.edtMandant.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject17.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject17.Options.UseBackColor = true;
            this.edtMandant.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject17)});
            this.edtMandant.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtMandant.Properties.Name = "editMandant.Properties";
            this.edtMandant.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtMandant.Size = new System.Drawing.Size(216, 24);
            this.edtMandant.TabIndex = 0;
            this.edtMandant.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtMandant_UserModifiedFld);
            // 
            // edtKontoVon
            // 
            this.edtKontoVon.Location = new System.Drawing.Point(136, 151);
            this.edtKontoVon.Name = "edtKontoVon";
            this.edtKontoVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontoVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontoVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontoVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontoVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontoVon.Properties.Appearance.Options.UseFont = true;
            this.edtKontoVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject16.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject16.Options.UseBackColor = true;
            this.edtKontoVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject16)});
            this.edtKontoVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKontoVon.Properties.Name = "editKontoVonX.Properties";
            this.edtKontoVon.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtKontoVon.Size = new System.Drawing.Size(106, 24);
            this.edtKontoVon.TabIndex = 1;
            this.edtKontoVon.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtKontoVon_UserModifiedFld);
            // 
            // edtKontoBis
            // 
            this.edtKontoBis.Location = new System.Drawing.Point(136, 186);
            this.edtKontoBis.Name = "edtKontoBis";
            this.edtKontoBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontoBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontoBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontoBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontoBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontoBis.Properties.Appearance.Options.UseFont = true;
            this.edtKontoBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject15.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject15.Options.UseBackColor = true;
            this.edtKontoBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject15)});
            this.edtKontoBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKontoBis.Properties.Name = "editKontoBisX.Properties";
            this.edtKontoBis.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtKontoBis.Size = new System.Drawing.Size(106, 24);
            this.edtKontoBis.TabIndex = 2;
            this.edtKontoBis.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtKontoBis_UserModifiedFld);
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(136, 236);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject14.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject14.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject14)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.Name = "editDatumVonX.Properties";
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(106, 24);
            this.edtDatumVon.TabIndex = 3;
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(280, 236);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject13.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject13.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.Name = "editDatumBisX.Properties";
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(106, 24);
            this.edtDatumBis.TabIndex = 4;
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(253, 236);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(18, 24);
            this.label31.TabIndex = 4;
            this.label31.Text = "bis";
            this.label31.UseCompatibleTextRendering = true;
            // 
            // edtValutaVon
            // 
            this.edtValutaVon.EditValue = null;
            this.edtValutaVon.Location = new System.Drawing.Point(136, 269);
            this.edtValutaVon.Name = "edtValutaVon";
            this.edtValutaVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtValutaVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtValutaVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtValutaVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtValutaVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtValutaVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtValutaVon.Properties.Appearance.Options.UseFont = true;
            this.edtValutaVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.edtValutaVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtValutaVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12)});
            this.edtValutaVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtValutaVon.Properties.Name = "editDatumVonX.Properties";
            this.edtValutaVon.Properties.ShowToday = false;
            this.edtValutaVon.Size = new System.Drawing.Size(106, 24);
            this.edtValutaVon.TabIndex = 6;
            // 
            // edtValutaBis
            // 
            this.edtValutaBis.EditValue = null;
            this.edtValutaBis.Location = new System.Drawing.Point(280, 269);
            this.edtValutaBis.Name = "edtValutaBis";
            this.edtValutaBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtValutaBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtValutaBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtValutaBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtValutaBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtValutaBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtValutaBis.Properties.Appearance.Options.UseFont = true;
            this.edtValutaBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.edtValutaBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtValutaBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.edtValutaBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtValutaBis.Properties.Name = "editDatumBisX.Properties";
            this.edtValutaBis.Properties.ShowToday = false;
            this.edtValutaBis.Size = new System.Drawing.Size(106, 24);
            this.edtValutaBis.TabIndex = 7;
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(10, 236);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(80, 24);
            this.label26.TabIndex = 332;
            this.label26.Text = "Datum von";
            this.label26.UseCompatibleTextRendering = true;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(10, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 24);
            this.label4.TabIndex = 351;
            this.label4.Text = "Konto von";
            this.label4.UseCompatibleTextRendering = true;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(10, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 24);
            this.label5.TabIndex = 352;
            this.label5.Text = "Konto bis";
            this.label5.UseCompatibleTextRendering = true;
            // 
            // edtKontonameVon
            // 
            this.edtKontonameVon.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKontonameVon.Location = new System.Drawing.Point(250, 151);
            this.edtKontonameVon.Name = "edtKontonameVon";
            this.edtKontonameVon.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKontonameVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontonameVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontonameVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontonameVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontonameVon.Properties.Appearance.Options.UseFont = true;
            this.edtKontonameVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontonameVon.Properties.Name = "editKontonameVonX.Properties";
            this.edtKontonameVon.Properties.ReadOnly = true;
            this.edtKontonameVon.Size = new System.Drawing.Size(346, 24);
            this.edtKontonameVon.TabIndex = 353;
            // 
            // edtKontonameBis
            // 
            this.edtKontonameBis.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKontonameBis.Location = new System.Drawing.Point(250, 186);
            this.edtKontonameBis.Name = "edtKontonameBis";
            this.edtKontonameBis.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKontonameBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontonameBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontonameBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontonameBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontonameBis.Properties.Appearance.Options.UseFont = true;
            this.edtKontonameBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontonameBis.Properties.Name = "editKontonameBisX.Properties";
            this.edtKontonameBis.Properties.ReadOnly = true;
            this.edtKontonameBis.Size = new System.Drawing.Size(346, 24);
            this.edtKontonameBis.TabIndex = 354;
            // 
            // kissLabel1
            // 
            this.kissLabel1.Location = new System.Drawing.Point(392, 236);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(241, 24);
            this.kissLabel1.TabIndex = 364;
            this.kissLabel1.Text = "(Datumbereich darf periodenübergreifend sein)";
            this.kissLabel1.UseCompatibleTextRendering = true;
            this.kissLabel1.Visible = false;
            // 
            // grdPeriode
            // 
            this.grdPeriode.DataSource = this.qryPeriode;
            // 
            // 
            // 
            this.grdPeriode.EmbeddedNavigator.Name = "gridPeriode.EmbeddedNavigator";
            this.grdPeriode.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdPeriode.Location = new System.Drawing.Point(428, 47);
            this.grdPeriode.MainView = this.gridView2;
            this.grdPeriode.Name = "grdPeriode";
            this.grdPeriode.Size = new System.Drawing.Size(283, 85);
            this.grdPeriode.TabIndex = 384;
            this.grdPeriode.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // qryPeriode
            // 
            this.qryPeriode.HostControl = this;
            this.qryPeriode.SelectStatement = resources.GetString("qryPeriode.SelectStatement");
            this.qryPeriode.PositionChanged += new System.EventHandler(this.qryPeriode_PositionChanged);
            // 
            // gridView2
            // 
            this.gridView2.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView2.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.Empty.Options.UseBackColor = true;
            this.gridView2.Appearance.Empty.Options.UseFont = true;
            this.gridView2.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.gridView2.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView2.Appearance.EvenRow.Options.UseFont = true;
            this.gridView2.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView2.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView2.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView2.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView2.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView2.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView2.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView2.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView2.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView2.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView2.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView2.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView2.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView2.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView2.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupRow.Options.UseFont = true;
            this.gridView2.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView2.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView2.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView2.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView2.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView2.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView2.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView2.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView2.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView2.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView2.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView2.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.OddRow.Options.UseFont = true;
            this.gridView2.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView2.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.Row.Options.UseBackColor = true;
            this.gridView2.Appearance.Row.Options.UseFont = true;
            this.gridView2.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gridView2.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView2.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView2.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView2.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView2.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colVon,
            this.colBis,
            this.colStatus});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView2.GridControl = this.grdPeriode;
            this.gridView2.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsCustomization.AllowFilter = false;
            this.gridView2.OptionsFilter.AllowFilterEditor = false;
            this.gridView2.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView2.OptionsMenu.EnableColumnMenu = false;
            this.gridView2.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView2.OptionsNavigation.UseTabKey = false;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowIndicator = false;
            // 
            // colVon
            // 
            this.colVon.Caption = "Periode Von";
            this.colVon.FieldName = "PeriodeVon";
            this.colVon.Name = "colVon";
            this.colVon.Visible = true;
            this.colVon.VisibleIndex = 0;
            this.colVon.Width = 80;
            // 
            // colBis
            // 
            this.colBis.Caption = "Periode Bis";
            this.colBis.FieldName = "PeriodeBis";
            this.colBis.Name = "colBis";
            this.colBis.Visible = true;
            this.colBis.VisibleIndex = 1;
            this.colBis.Width = 80;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Status";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 2;
            this.colStatus.Width = 98;
            // 
            // label40
            // 
            this.label40.Location = new System.Drawing.Point(10, 47);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(120, 24);
            this.label40.TabIndex = 388;
            this.label40.Text = "Pers. mit zivilr. Massn.";
            this.label40.UseCompatibleTextRendering = true;
            // 
            // edtAdresse
            // 
            this.edtAdresse.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAdresse.Location = new System.Drawing.Point(136, 85);
            this.edtAdresse.Name = "edtAdresse";
            this.edtAdresse.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAdresse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdresse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdresse.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdresse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdresse.Properties.Appearance.Options.UseFont = true;
            this.edtAdresse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAdresse.Properties.Name = "editPlzOrt.Properties";
            this.edtAdresse.Properties.ReadOnly = true;
            this.edtAdresse.Size = new System.Drawing.Size(281, 24);
            this.edtAdresse.TabIndex = 389;
            // 
            // edtBaPersonID
            // 
            this.edtBaPersonID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBaPersonID.Location = new System.Drawing.Point(358, 47);
            this.edtBaPersonID.Name = "edtBaPersonID";
            this.edtBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBaPersonID.Properties.Name = "editMandantNr.Properties";
            this.edtBaPersonID.Properties.ReadOnly = true;
            this.edtBaPersonID.Size = new System.Drawing.Size(59, 24);
            this.edtBaPersonID.TabIndex = 390;
            // 
            // edtMT
            // 
            this.edtMT.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtMT.Location = new System.Drawing.Point(136, 108);
            this.edtMT.Name = "edtMT";
            this.edtMT.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtMT.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMT.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMT.Properties.Appearance.Options.UseBackColor = true;
            this.edtMT.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMT.Properties.Appearance.Options.UseFont = true;
            this.edtMT.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMT.Properties.Name = "editMT.Properties";
            this.edtMT.Properties.ReadOnly = true;
            this.edtMT.Size = new System.Drawing.Size(281, 24);
            this.edtMT.TabIndex = 391;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(10, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 24);
            this.label10.TabIndex = 392;
            this.label10.Text = "Beist. oder Vorm.";
            this.label10.UseCompatibleTextRendering = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 24);
            this.label1.TabIndex = 393;
            this.label1.Text = "Adresse";
            this.label1.UseCompatibleTextRendering = true;
            // 
            // kissLabel3
            // 
            this.kissLabel3.Location = new System.Drawing.Point(253, 269);
            this.kissLabel3.Name = "kissLabel3";
            this.kissLabel3.Size = new System.Drawing.Size(18, 24);
            this.kissLabel3.TabIndex = 396;
            this.kissLabel3.Text = "bis";
            this.kissLabel3.UseCompatibleTextRendering = true;
            // 
            // kissLabel2
            // 
            this.kissLabel2.Location = new System.Drawing.Point(10, 269);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(67, 24);
            this.kissLabel2.TabIndex = 397;
            this.kissLabel2.Text = "Valuta von";
            this.kissLabel2.UseCompatibleTextRendering = true;
            // 
            // lblAusgeglicheneAusblenden
            // 
            this.lblAusgeglicheneAusblenden.Location = new System.Drawing.Point(10, 300);
            this.lblAusgeglicheneAusblenden.Name = "lblAusgeglicheneAusblenden";
            this.lblAusgeglicheneAusblenden.Size = new System.Drawing.Size(295, 24);
            this.lblAusgeglicheneAusblenden.TabIndex = 397;
            this.lblAusgeglicheneAusblenden.Text = "Ausgeglichene Kreditoren/Debitoren ausblenden:";
            this.lblAusgeglicheneAusblenden.UseCompatibleTextRendering = true;
            // 
            // btnDrucken
            // 
            this.btnDrucken.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDrucken.Location = new System.Drawing.Point(136, 327);
            this.btnDrucken.Name = "btnDrucken";
            this.btnDrucken.Size = new System.Drawing.Size(90, 24);
            this.btnDrucken.TabIndex = 398;
            this.btnDrucken.Text = "Drucken";
            this.btnDrucken.UseCompatibleTextRendering = true;
            this.btnDrucken.UseVisualStyleBackColor = true;
            this.btnDrucken.Click += new System.EventHandler(this.btnDrucken_Click);
            // 
            // edtAusgeglicheneKDAusblenden
            // 
            this.edtAusgeglicheneKDAusblenden.EditValue = true;
            this.edtAusgeglicheneKDAusblenden.Location = new System.Drawing.Point(267, 305);
            this.edtAusgeglicheneKDAusblenden.Name = "edtAusgeglicheneKDAusblenden";
            this.edtAusgeglicheneKDAusblenden.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAusgeglicheneKDAusblenden.Properties.Appearance.Options.UseBackColor = true;
            this.edtAusgeglicheneKDAusblenden.Size = new System.Drawing.Size(62, 19);
            this.edtAusgeglicheneKDAusblenden.TabIndex = 399;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picTitel);
            this.panel1.Controls.Add(this.lblTitel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(970, 24);
            this.panel1.TabIndex = 1;
            // 
            // picTitel
            // 
            this.picTitel.Image = ((System.Drawing.Image)(resources.GetObject("picTitel.Image")));
            this.picTitel.Location = new System.Drawing.Point(5, 5);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 293;
            this.picTitel.TabStop = false;
            // 
            // lblTitel
            // 
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(25, 5);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(542, 15);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Kontoblatt";
            this.lblTitel.UseCompatibleTextRendering = true;
            // 
            // grdDokumente
            // 
            this.grdDokumente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDokumente.DataSource = this.qryDocument;
            // 
            // 
            // 
            this.grdDokumente.EmbeddedNavigator.Name = "grid.EmbeddedNavigator";
            this.grdDokumente.Location = new System.Drawing.Point(3, 303);
            this.grdDokumente.MainView = this.gridView3;
            this.grdDokumente.Name = "grdDokumente";
            this.grdDokumente.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1,
            this.repositoryItemPictureEdit2,
            this.repositoryItemImageEdit2});
            this.grdDokumente.Size = new System.Drawing.Size(946, 112);
            this.grdDokumente.TabIndex = 319;
            this.grdDokumente.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // qryDocument
            // 
            this.qryDocument.BatchUpdate = true;
            this.qryDocument.FillTimeOut = 60;
            this.qryDocument.HostControl = this;
            this.qryDocument.SelectStatement = resources.GetString("qryDocument.SelectStatement");
            // 
            // gridView3
            // 
            this.gridView3.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView3.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.Empty.Options.UseBackColor = true;
            this.gridView3.Appearance.Empty.Options.UseFont = true;
            this.gridView3.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.gridView3.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView3.Appearance.EvenRow.Options.UseFont = true;
            this.gridView3.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView3.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView3.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView3.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView3.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView3.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView3.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView3.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView3.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView3.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView3.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView3.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView3.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView3.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView3.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView3.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView3.Appearance.GroupRow.Options.UseFont = true;
            this.gridView3.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView3.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView3.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView3.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView3.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView3.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView3.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView3.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView3.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView3.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView3.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView3.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView3.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView3.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView3.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.OddRow.Options.UseFont = true;
            this.gridView3.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView3.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.Row.Options.UseBackColor = true;
            this.gridView3.Appearance.Row.Options.UseFont = true;
            this.gridView3.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gridView3.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView3.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView3.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView3.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView3.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView3.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDokumentTyp,
            this.colDokStichworte,
            this.colDokErstellungsdatum,
            this.colDokModified,
            this.colDeckblatt,
            this.colSelektion});
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView3.GridControl = this.grdDokumente;
            this.gridView3.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsCustomization.AllowFilter = false;
            this.gridView3.OptionsFilter.AllowFilterEditor = false;
            this.gridView3.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView3.OptionsMenu.EnableColumnMenu = false;
            this.gridView3.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView3.OptionsNavigation.UseTabKey = false;
            this.gridView3.OptionsView.ColumnAutoWidth = false;
            this.gridView3.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            this.gridView3.OptionsView.ShowIndicator = false;
            // 
            // colDokumentTyp
            // 
            this.colDokumentTyp.Caption = "Typ";
            this.colDokumentTyp.FieldName = "KgDokumentTypCode";
            this.colDokumentTyp.Name = "colDokumentTyp";
            this.colDokumentTyp.OptionsColumn.AllowEdit = false;
            this.colDokumentTyp.Visible = true;
            this.colDokumentTyp.VisibleIndex = 0;
            this.colDokumentTyp.Width = 115;
            // 
            // colDokStichworte
            // 
            this.colDokStichworte.Caption = "Stichwort";
            this.colDokStichworte.FieldName = "Stichwort";
            this.colDokStichworte.Name = "colDokStichworte";
            this.colDokStichworte.OptionsColumn.AllowEdit = false;
            this.colDokStichworte.Visible = true;
            this.colDokStichworte.VisibleIndex = 1;
            this.colDokStichworte.Width = 357;
            // 
            // colDokErstellungsdatum
            // 
            this.colDokErstellungsdatum.Caption = "Erstellungsdatum";
            this.colDokErstellungsdatum.FieldName = "DateCreation";
            this.colDokErstellungsdatum.Name = "colDokErstellungsdatum";
            this.colDokErstellungsdatum.OptionsColumn.AllowEdit = false;
            this.colDokErstellungsdatum.OptionsColumn.ReadOnly = true;
            this.colDokErstellungsdatum.Visible = true;
            this.colDokErstellungsdatum.VisibleIndex = 2;
            this.colDokErstellungsdatum.Width = 119;
            // 
            // colDokModified
            // 
            this.colDokModified.Caption = "Letzte Speicherung";
            this.colDokModified.FieldName = "DateLastSave";
            this.colDokModified.Name = "colDokModified";
            this.colDokModified.OptionsColumn.AllowEdit = false;
            this.colDokModified.OptionsColumn.ReadOnly = true;
            this.colDokModified.Visible = true;
            this.colDokModified.VisibleIndex = 3;
            this.colDokModified.Width = 119;
            // 
            // colDeckblatt
            // 
            this.colDeckblatt.Caption = "inkl. Deckblatt";
            this.colDeckblatt.FieldName = "Deckblatt";
            this.colDeckblatt.Name = "colDeckblatt";
            this.colDeckblatt.Visible = true;
            this.colDeckblatt.VisibleIndex = 4;
            this.colDeckblatt.Width = 100;
            // 
            // colSelektion
            // 
            this.colSelektion.Caption = "Selektion";
            this.colSelektion.FieldName = "Selektion";
            this.colSelektion.Name = "colSelektion";
            this.colSelektion.Visible = true;
            this.colSelektion.VisibleIndex = 5;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.OK)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // repositoryItemPictureEdit2
            // 
            this.repositoryItemPictureEdit2.Name = "repositoryItemPictureEdit2";
            // 
            // repositoryItemImageEdit2
            // 
            this.repositoryItemImageEdit2.AutoHeight = false;
            this.repositoryItemImageEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit2.Name = "repositoryItemImageEdit2";
            this.repositoryItemImageEdit2.ReadOnly = true;
            // 
            // lblDokumente
            // 
            this.lblDokumente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDokumente.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblDokumente.Location = new System.Drawing.Point(3, 275);
            this.lblDokumente.Name = "lblDokumente";
            this.lblDokumente.Size = new System.Drawing.Size(88, 25);
            this.lblDokumente.TabIndex = 337;
            this.lblDokumente.Text = "Dokumente";
            this.lblDokumente.UseCompatibleTextRendering = true;
            // 
            // edtDokument
            // 
            this.edtDokument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDokument.CanCreateDocument = false;
            this.edtDokument.CanDeleteDocument = false;
            this.edtDokument.CanImportDocument = false;
            this.edtDokument.Context = null;
            this.edtDokument.DataMember = "DocumentID";
            this.edtDokument.DataSource = this.qryDocument;
            this.edtDokument.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtDokument.Location = new System.Drawing.Point(793, 421);
            this.edtDokument.Name = "edtDokument";
            this.edtDokument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtDokument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDokument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDokument.Properties.Appearance.Options.UseBackColor = true;
            this.edtDokument.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDokument.Properties.Appearance.Options.UseFont = true;
            this.edtDokument.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtDokument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDokument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6, "Dokument öffnen")});
            this.edtDokument.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDokument.Properties.ReadOnly = true;
            this.edtDokument.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtDokument.Size = new System.Drawing.Size(156, 24);
            this.edtDokument.TabIndex = 338;
            // 
            // btnBudgetPosition
            // 
            this.btnBudgetPosition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBudgetPosition.Location = new System.Drawing.Point(836, 6);
            this.btnBudgetPosition.Name = "btnBudgetPosition";
            this.btnBudgetPosition.Size = new System.Drawing.Size(113, 24);
            this.btnBudgetPosition.TabIndex = 339;
            this.btnBudgetPosition.Text = "> Budgetposition";
            this.btnBudgetPosition.UseCompatibleTextRendering = true;
            this.btnBudgetPosition.UseVisualStyleBackColor = false;
            this.btnBudgetPosition.Click += new System.EventHandler(this.btnMonatsbudget_Click);
            // 
            // btnDokumenteDrucken
            // 
            this.btnDokumenteDrucken.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDokumenteDrucken.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDokumenteDrucken.Location = new System.Drawing.Point(836, 273);
            this.btnDokumenteDrucken.Name = "btnDokumenteDrucken";
            this.btnDokumenteDrucken.Size = new System.Drawing.Size(113, 24);
            this.btnDokumenteDrucken.TabIndex = 340;
            this.btnDokumenteDrucken.Text = "Auswahl drucken";
            this.btnDokumenteDrucken.UseVisualStyleBackColor = false;
            this.btnDokumenteDrucken.Click += new System.EventHandler(this.btnDokumenteDrucken_Click);
            // 
            // btnKeineDokumenteAuswaehlen
            // 
            this.btnKeineDokumenteAuswaehlen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKeineDokumenteAuswaehlen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeineDokumenteAuswaehlen.Location = new System.Drawing.Point(565, 273);
            this.btnKeineDokumenteAuswaehlen.Name = "btnKeineDokumenteAuswaehlen";
            this.btnKeineDokumenteAuswaehlen.Size = new System.Drawing.Size(115, 24);
            this.btnKeineDokumenteAuswaehlen.TabIndex = 341;
            this.btnKeineDokumenteAuswaehlen.Text = "Keine selektieren";
            this.btnKeineDokumenteAuswaehlen.UseVisualStyleBackColor = false;
            this.btnKeineDokumenteAuswaehlen.Click += new System.EventHandler(this.btnKeineDokumenteAuswaehlen_Click);
            // 
            // btnAlleDokumenteAuswaehlen
            // 
            this.btnAlleDokumenteAuswaehlen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlleDokumenteAuswaehlen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlleDokumenteAuswaehlen.Location = new System.Drawing.Point(444, 273);
            this.btnAlleDokumenteAuswaehlen.Name = "btnAlleDokumenteAuswaehlen";
            this.btnAlleDokumenteAuswaehlen.Size = new System.Drawing.Size(115, 24);
            this.btnAlleDokumenteAuswaehlen.TabIndex = 342;
            this.btnAlleDokumenteAuswaehlen.Text = "Alle selektieren";
            this.btnAlleDokumenteAuswaehlen.UseVisualStyleBackColor = false;
            this.btnAlleDokumenteAuswaehlen.Click += new System.EventHandler(this.btnAlleDokumenteAuswaehlen_Click);
            // 
            // edtDrucker
            // 
            this.edtDrucker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDrucker.Location = new System.Drawing.Point(686, 273);
            this.edtDrucker.Name = "edtDrucker";
            this.edtDrucker.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDrucker.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDrucker.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDrucker.Properties.Appearance.Options.UseBackColor = true;
            this.edtDrucker.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDrucker.Properties.Appearance.Options.UseFont = true;
            this.edtDrucker.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtDrucker.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtDrucker.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtDrucker.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtDrucker.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtDrucker.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtDrucker.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDrucker.Size = new System.Drawing.Size(144, 24);
            this.edtDrucker.TabIndex = 343;
            // 
            // edtDocumentHidden
            // 
            this.edtDocumentHidden.CanCreateDocument = false;
            this.edtDocumentHidden.CanDeleteDocument = false;
            this.edtDocumentHidden.CanImportDocument = false;
            this.edtDocumentHidden.Context = null;
            this.edtDocumentHidden.EditValue = "";
            this.edtDocumentHidden.Location = new System.Drawing.Point(338, 273);
            this.edtDocumentHidden.Name = "edtDocumentHidden";
            this.edtDocumentHidden.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDocumentHidden.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDocumentHidden.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDocumentHidden.Properties.Appearance.Options.UseBackColor = true;
            this.edtDocumentHidden.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDocumentHidden.Properties.Appearance.Options.UseFont = true;
            this.edtDocumentHidden.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtDocumentHidden.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocumentHidden.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocumentHidden.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocumentHidden.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocumentHidden.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "Dokument importieren")});
            this.edtDocumentHidden.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDocumentHidden.Properties.ReadOnly = true;
            this.edtDocumentHidden.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtDocumentHidden.Size = new System.Drawing.Size(100, 24);
            this.edtDocumentHidden.TabIndex = 344;
            this.edtDocumentHidden.Visible = false;
            // 
            // CtlKgKontoblatt
            // 
            this.ActiveSQLQuery = this.qryKontoblaetter;
            this.AutoRefresh = false;
            this.Controls.Add(this.panel1);
            this.Name = "CtlKgKontoblatt";
            this.Size = new System.Drawing.Size(970, 520);
            this.Load += new System.EventHandler(this.CtlKgKontoblatt_Load);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKontoblaetter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOpenDocumentEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentHidden.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMandant.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontoVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontoBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValutaVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValutaBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontonameVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontonameBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPeriode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPeriode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusgeglicheneAusblenden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusgeglicheneKDAusblenden.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDokumente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryDocument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokumente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokument.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDrucker.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDocumentHidden.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissButton btnAlleDokumenteAuswaehlen;
        private KiSS4.Gui.KissButton btnBudgetPosition;
        private KiSS4.Gui.KissButton btnCollapse;
        private KiSS4.Gui.KissButton btnDokumenteDrucken;
        private KiSS4.Gui.KissButton btnDrucken;
        private KiSS4.Gui.KissButton btnExpand;
        private KiSS4.Gui.KissButton btnKeineDokumenteAuswaehlen;
        private DevExpress.XtraGrid.Columns.GridColumn colBelegNr;
        private DevExpress.XtraGrid.Columns.GridColumn colBetragHaben;
        private DevExpress.XtraGrid.Columns.GridColumn colBetragSoll;
        private DevExpress.XtraGrid.Columns.GridColumn colBis;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colDokErstellungsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colDokModified;
        private DevExpress.XtraGrid.Columns.GridColumn colDokStichworte;
        private DevExpress.XtraGrid.Columns.GridColumn colDokument;
        private DevExpress.XtraGrid.Columns.GridColumn colDokumentTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colGKtoNr;
        private DevExpress.XtraGrid.Columns.GridColumn colKtoName;
        private DevExpress.XtraGrid.Columns.GridColumn colMandant;
        private DevExpress.XtraGrid.Columns.GridColumn colSaldo;
        private DevExpress.XtraGrid.Columns.GridColumn colSelektion;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colText;
        private DevExpress.XtraGrid.Columns.GridColumn colValuta;
        private DevExpress.XtraGrid.Columns.GridColumn colVon;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissTextEdit edtAdresse;
        private KiSS4.Gui.KissCheckEdit edtAusgeglicheneKDAusblenden;
        private KiSS4.Gui.KissTextEdit edtBaPersonID;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private Dokument.XDokument edtDocumentHidden;
        private KiSS4.Dokument.XDokument edtDokument;
        private KiSS4.Dokument.XDokument edtDokumentHidden;
        private KiSS4.Gui.KissComboBox edtDrucker;
        private KiSS4.Gui.KissButtonEdit edtKontoBis;
        private KiSS4.Gui.KissButtonEdit edtKontoVon;
        private KiSS4.Gui.KissTextEdit edtKontonameBis;
        private KiSS4.Gui.KissTextEdit edtKontonameVon;
        private KiSS4.Gui.KissTextEdit edtMT;
        private KiSS4.Gui.KissButtonEdit edtMandant;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit edtOpenDocumentEdit;
        private KiSS4.Gui.KissDateEdit edtValutaBis;
        private KiSS4.Gui.KissDateEdit edtValutaVon;
        private KiSS4.Gui.KissGrid grdDokumente;
        private KiSS4.Gui.KissGrid grdPeriode;
        private KiSS4.Gui.KissGrid grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private KiSS4.Gui.KissLabel kissLabel1;
        private KiSS4.Gui.KissLabel kissLabel2;
        private KiSS4.Gui.KissLabel kissLabel3;
        private KiSS4.Gui.KissLabel label1;
        private KiSS4.Gui.KissLabel label10;
        private KiSS4.Gui.KissLabel label26;
        private KiSS4.Gui.KissLabel label31;
        private KiSS4.Gui.KissLabel label4;
        private KiSS4.Gui.KissLabel label40;
        private KiSS4.Gui.KissLabel label5;
        private KiSS4.Gui.KissLabel lblAusgeglicheneAusblenden;
        private KiSS4.Gui.KissLabel lblDokumente;
        private KiSS4.Gui.KissLabel lblMandant;
        private KiSS4.Gui.KissLabel lblTitel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryDocument;
        private KiSS4.DB.SqlQuery qryKontoblaetter;
        private KiSS4.DB.SqlQuery qryPeriode;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colDeckblatt;
    }
}