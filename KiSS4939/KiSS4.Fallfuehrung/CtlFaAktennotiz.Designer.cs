namespace KiSS4.Fallfuehrung
{
    partial class CtlFaAktennotiz
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFaAktennotiz));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdFaAktennotiz = new KiSS4.Gui.KissGrid();
            this.qryFaAktennotiz = new KiSS4.DB.SqlQuery();
            this.gvwFaAktennotiz = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThemen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKontaktpartner = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMitarbeiter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStichwort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsDeleted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.edtFaDokSucheDatumVon = new KiSS4.Gui.KissDateEdit();
            this.lblSearchDatumVon = new KiSS4.Gui.KissLabel();
            this.edtFaDokSucheDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtFaDokSucheKontaktart = new KiSS4.Gui.KissLookUpEdit();
            this.lblSearchDatumBis = new KiSS4.Gui.KissLabel();
            this.edtFaDokSucheSAR = new KiSS4.Common.KissMitarbeiterButtonEdit();
            this.lblSearchKontaktart = new KiSS4.Gui.KissLabel();
            this.edtFaDokSucheStichwort = new KiSS4.Gui.KissTextEdit();
            this.lblUser = new KiSS4.Gui.KissLabel();
            this.lblSearchStichwort = new KiSS4.Gui.KissLabel();
            this.pnTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new KiSS4.Gui.KissLabel();
            this.imageTitle = new System.Windows.Forms.PictureBox();
            this.chkThemenFilter = new KiSS4.Gui.KissCheckEdit();
            this.lookupThemen = new KiSS4.Gui.KissCheckedLookupEdit();
            this.panDetail = new System.Windows.Forms.Panel();
            this.edtThemen = new KiSS4.Gui.KissCheckedLookupEdit();
            this.lblThemen = new KiSS4.Gui.KissLabel();
            this.ctlLogischLoeschen = new KiSS4.Common.CtlLogischesLoeschen();
            this.memInhalt = new KiSS4.Gui.KissRTFEdit();
            this.edtDauer = new KiSS4.Gui.KissLookUpEdit();
            this.lblStichwort = new KiSS4.Gui.KissLabel();
            this.lblInhalt = new KiSS4.Gui.KissLabel();
            this.lblDauer = new KiSS4.Gui.KissLabel();
            this.lblAutor = new KiSS4.Gui.KissLabel();
            this.lblKontaktart = new KiSS4.Gui.KissLabel();
            this.btnDokument = new KiSS4.Dokument.KissDocumentButton();
            this.lblDatum = new KiSS4.Gui.KissLabel();
            this.edtStichwort = new KiSS4.Gui.KissTextEdit();
            this.edtFaDokBesprAutor = new KiSS4.Common.KissMitarbeiterButtonEdit();
            this.lblKontaktpartner = new KiSS4.Gui.KissLabel();
            this.edtFaDokBesprKontakArt = new KiSS4.Gui.KissLookUpEdit();
            this.edtFaDokBesprKontakPart = new KiSS4.Gui.KissTextEdit();
            this.edtDatum = new KiSS4.Gui.KissDateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.radGrpDeleted)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGrpDeleted.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFaAktennotiz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaAktennotiz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwFaAktennotiz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokSucheDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokSucheDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokSucheKontaktart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokSucheKontaktart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokSucheSAR.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchKontaktart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokSucheStichwort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchStichwort)).BeginInit();
            this.pnTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkThemenFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupThemen)).BeginInit();
            this.panDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtThemen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblThemen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDauer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDauer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichwort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInhalt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDauer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAutor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichwort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokBesprAutor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktpartner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokBesprKontakArt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokBesprKontakArt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokBesprKontakPart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatum.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // radGrpDeleted
            // 
            this.radGrpDeleted.Location = new System.Drawing.Point(703, 40);
            this.radGrpDeleted.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radGrpDeleted.Properties.Appearance.Options.UseBackColor = true;
            this.radGrpDeleted.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.radGrpDeleted.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.radGrpDeleted.Size = new System.Drawing.Size(130, 86);
            this.radGrpDeleted.TabIndex = 20;
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(821, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Location = new System.Drawing.Point(0, 46);
            this.tabControlSearch.MinimumSize = new System.Drawing.Size(842, 216);
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.Size = new System.Drawing.Size(845, 216);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdFaAktennotiz);
            this.tpgListe.Size = new System.Drawing.Size(833, 178);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.lookupThemen);
            this.tpgSuchen.Controls.Add(this.chkThemenFilter);
            this.tpgSuchen.Controls.Add(this.lblSearchStichwort);
            this.tpgSuchen.Controls.Add(this.lblUser);
            this.tpgSuchen.Controls.Add(this.edtFaDokSucheStichwort);
            this.tpgSuchen.Controls.Add(this.lblSearchKontaktart);
            this.tpgSuchen.Controls.Add(this.edtFaDokSucheSAR);
            this.tpgSuchen.Controls.Add(this.lblSearchDatumBis);
            this.tpgSuchen.Controls.Add(this.edtFaDokSucheKontaktart);
            this.tpgSuchen.Controls.Add(this.edtFaDokSucheDatumBis);
            this.tpgSuchen.Controls.Add(this.lblSearchDatumVon);
            this.tpgSuchen.Controls.Add(this.edtFaDokSucheDatumVon);
            this.tpgSuchen.Size = new System.Drawing.Size(833, 178);
            this.tpgSuchen.Title = "Suchen";
            this.tpgSuchen.Controls.SetChildIndex(this.radGrpDeleted, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFaDokSucheDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSearchDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFaDokSucheDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFaDokSucheKontaktart, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSearchDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFaDokSucheSAR, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSearchKontaktart, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFaDokSucheStichwort, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblUser, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSearchStichwort, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkThemenFilter, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lookupThemen, 0);
            // 
            // grdFaAktennotiz
            // 
            this.grdFaAktennotiz.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdFaAktennotiz.DataSource = this.qryFaAktennotiz;
            // 
            // 
            // 
            this.grdFaAktennotiz.EmbeddedNavigator.Name = "gridCtlKiSS3UserMask_Fa_Dok_Besprechungen.EmbeddedNavigator";
            this.grdFaAktennotiz.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdFaAktennotiz.Location = new System.Drawing.Point(0, 0);
            this.grdFaAktennotiz.MainView = this.gvwFaAktennotiz;
            this.grdFaAktennotiz.Name = "grdFaAktennotiz";
            this.grdFaAktennotiz.Size = new System.Drawing.Size(830, 175);
            this.grdFaAktennotiz.TabIndex = 3;
            this.grdFaAktennotiz.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvwFaAktennotiz,
            this.gridView1});
            // 
            // qryFaAktennotiz
            // 
            this.qryFaAktennotiz.CanDelete = true;
            this.qryFaAktennotiz.CanInsert = true;
            this.qryFaAktennotiz.CanUpdate = true;
            this.qryFaAktennotiz.HostControl = this;
            this.qryFaAktennotiz.SelectStatement = resources.GetString("qryFaAktennotiz.SelectStatement");
            this.qryFaAktennotiz.TableName = "FaAktennotizen";
            this.qryFaAktennotiz.AfterInsert += new System.EventHandler(this.qryFaAktennotiz_AfterInsert);
            this.qryFaAktennotiz.BeforePost += new System.EventHandler(this.qryFaAktennotiz_BeforePost);
            // 
            // gvwFaAktennotiz
            // 
            this.gvwFaAktennotiz.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gvwFaAktennotiz.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwFaAktennotiz.Appearance.Empty.Options.UseBackColor = true;
            this.gvwFaAktennotiz.Appearance.Empty.Options.UseFont = true;
            this.gvwFaAktennotiz.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwFaAktennotiz.Appearance.EvenRow.Options.UseFont = true;
            this.gvwFaAktennotiz.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvwFaAktennotiz.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwFaAktennotiz.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gvwFaAktennotiz.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvwFaAktennotiz.Appearance.FocusedCell.Options.UseFont = true;
            this.gvwFaAktennotiz.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvwFaAktennotiz.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvwFaAktennotiz.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwFaAktennotiz.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gvwFaAktennotiz.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvwFaAktennotiz.Appearance.FocusedRow.Options.UseFont = true;
            this.gvwFaAktennotiz.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gvwFaAktennotiz.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gvwFaAktennotiz.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gvwFaAktennotiz.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gvwFaAktennotiz.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvwFaAktennotiz.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvwFaAktennotiz.Appearance.GroupRow.Options.UseBackColor = true;
            this.gvwFaAktennotiz.Appearance.GroupRow.Options.UseFont = true;
            this.gvwFaAktennotiz.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvwFaAktennotiz.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gvwFaAktennotiz.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gvwFaAktennotiz.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvwFaAktennotiz.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvwFaAktennotiz.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gvwFaAktennotiz.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvwFaAktennotiz.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gvwFaAktennotiz.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwFaAktennotiz.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvwFaAktennotiz.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvwFaAktennotiz.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvwFaAktennotiz.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gvwFaAktennotiz.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gvwFaAktennotiz.Appearance.HorzLine.Options.UseBackColor = true;
            this.gvwFaAktennotiz.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwFaAktennotiz.Appearance.OddRow.Options.UseFont = true;
            this.gvwFaAktennotiz.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gvwFaAktennotiz.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwFaAktennotiz.Appearance.Row.Options.UseBackColor = true;
            this.gvwFaAktennotiz.Appearance.Row.Options.UseFont = true;
            this.gvwFaAktennotiz.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwFaAktennotiz.Appearance.SelectedRow.Options.UseFont = true;
            this.gvwFaAktennotiz.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gvwFaAktennotiz.Appearance.VertLine.Options.UseBackColor = true;
            this.gvwFaAktennotiz.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gvwFaAktennotiz.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatum,
            this.colThemen,
            this.colKontaktpartner,
            this.colMitarbeiter,
            this.colStichwort,
            this.colIsDeleted});
            this.gvwFaAktennotiz.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gvwFaAktennotiz.GridControl = this.grdFaAktennotiz;
            this.gvwFaAktennotiz.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.gvwFaAktennotiz.Name = "gvwFaAktennotiz";
            this.gvwFaAktennotiz.OptionsBehavior.Editable = false;
            this.gvwFaAktennotiz.OptionsCustomization.AllowFilter = false;
            this.gvwFaAktennotiz.OptionsFilter.AllowFilterEditor = false;
            this.gvwFaAktennotiz.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gvwFaAktennotiz.OptionsMenu.EnableColumnMenu = false;
            this.gvwFaAktennotiz.OptionsNavigation.AutoFocusNewRow = true;
            this.gvwFaAktennotiz.OptionsNavigation.UseTabKey = false;
            this.gvwFaAktennotiz.OptionsView.ColumnAutoWidth = false;
            this.gvwFaAktennotiz.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvwFaAktennotiz.OptionsView.ShowGroupPanel = false;
            this.gvwFaAktennotiz.OptionsView.ShowIndicator = false;
            // 
            // colDatum
            // 
            this.colDatum.Caption = "Datum";
            this.colDatum.FieldName = "Datum";
            this.colDatum.Name = "colDatum";
            this.colDatum.Visible = true;
            this.colDatum.VisibleIndex = 0;
            this.colDatum.Width = 80;
            // 
            // colThemen
            // 
            this.colThemen.Caption = "Themen";
            this.colThemen.Name = "colThemen";
            this.colThemen.Visible = true;
            this.colThemen.VisibleIndex = 2;
            this.colThemen.Width = 156;
            // 
            // colKontaktpartner
            // 
            this.colKontaktpartner.Caption = "Kontaktpartner";
            this.colKontaktpartner.FieldName = "Kontaktpartner";
            this.colKontaktpartner.Name = "colKontaktpartner";
            this.colKontaktpartner.Visible = true;
            this.colKontaktpartner.VisibleIndex = 3;
            this.colKontaktpartner.Width = 134;
            // 
            // colMitarbeiter
            // 
            this.colMitarbeiter.Caption = "Autor";
            this.colMitarbeiter.FieldName = "User";
            this.colMitarbeiter.Name = "colMitarbeiter";
            this.colMitarbeiter.Visible = true;
            this.colMitarbeiter.VisibleIndex = 4;
            this.colMitarbeiter.Width = 130;
            // 
            // colStichwort
            // 
            this.colStichwort.Caption = "Stichwort";
            this.colStichwort.FieldName = "Stichwort";
            this.colStichwort.Name = "colStichwort";
            this.colStichwort.Visible = true;
            this.colStichwort.VisibleIndex = 1;
            this.colStichwort.Width = 244;
            // 
            // colIsDeleted
            // 
            this.colIsDeleted.Caption = "gelöscht";
            this.colIsDeleted.FieldName = "IsDeleted";
            this.colIsDeleted.Name = "colIsDeleted";
            this.colIsDeleted.Visible = true;
            this.colIsDeleted.VisibleIndex = 5;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdFaAktennotiz;
            this.gridView1.Name = "gridView1";
            // 
            // edtFaDokSucheDatumVon
            // 
            this.edtFaDokSucheDatumVon.EditValue = null;
            this.edtFaDokSucheDatumVon.Location = new System.Drawing.Point(138, 40);
            this.edtFaDokSucheDatumVon.Name = "edtFaDokSucheDatumVon";
            this.edtFaDokSucheDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtFaDokSucheDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFaDokSucheDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaDokSucheDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaDokSucheDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaDokSucheDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaDokSucheDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtFaDokSucheDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtFaDokSucheDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtFaDokSucheDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtFaDokSucheDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFaDokSucheDatumVon.Properties.Name = "kissDateEdit1.Properties";
            this.edtFaDokSucheDatumVon.Properties.ShowToday = false;
            this.edtFaDokSucheDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtFaDokSucheDatumVon.TabIndex = 9;
            // 
            // lblSearchDatumVon
            // 
            this.lblSearchDatumVon.Location = new System.Drawing.Point(30, 40);
            this.lblSearchDatumVon.Name = "lblSearchDatumVon";
            this.lblSearchDatumVon.Size = new System.Drawing.Size(102, 24);
            this.lblSearchDatumVon.TabIndex = 10;
            this.lblSearchDatumVon.Text = "Datum von";
            this.lblSearchDatumVon.UseCompatibleTextRendering = true;
            // 
            // edtFaDokSucheDatumBis
            // 
            this.edtFaDokSucheDatumBis.EditValue = null;
            this.edtFaDokSucheDatumBis.Location = new System.Drawing.Point(278, 40);
            this.edtFaDokSucheDatumBis.Name = "edtFaDokSucheDatumBis";
            this.edtFaDokSucheDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtFaDokSucheDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFaDokSucheDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaDokSucheDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaDokSucheDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaDokSucheDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaDokSucheDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtFaDokSucheDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtFaDokSucheDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtFaDokSucheDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtFaDokSucheDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFaDokSucheDatumBis.Properties.Name = "kissDateEdit2.Properties";
            this.edtFaDokSucheDatumBis.Properties.ShowToday = false;
            this.edtFaDokSucheDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtFaDokSucheDatumBis.TabIndex = 10;
            // 
            // edtFaDokSucheKontaktart
            // 
            this.edtFaDokSucheKontaktart.Location = new System.Drawing.Point(138, 70);
            this.edtFaDokSucheKontaktart.LOVName = "FaKontaktart";
            this.edtFaDokSucheKontaktart.Name = "edtFaDokSucheKontaktart";
            this.edtFaDokSucheKontaktart.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFaDokSucheKontaktart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaDokSucheKontaktart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaDokSucheKontaktart.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaDokSucheKontaktart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaDokSucheKontaktart.Properties.Appearance.Options.UseFont = true;
            this.edtFaDokSucheKontaktart.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtFaDokSucheKontaktart.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaDokSucheKontaktart.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtFaDokSucheKontaktart.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtFaDokSucheKontaktart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtFaDokSucheKontaktart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtFaDokSucheKontaktart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFaDokSucheKontaktart.Properties.Name = "kissLookUpEdit2.Properties";
            this.edtFaDokSucheKontaktart.Properties.NullText = "";
            this.edtFaDokSucheKontaktart.Properties.ShowFooter = false;
            this.edtFaDokSucheKontaktart.Properties.ShowHeader = false;
            this.edtFaDokSucheKontaktart.Size = new System.Drawing.Size(283, 24);
            this.edtFaDokSucheKontaktart.TabIndex = 11;
            // 
            // lblSearchDatumBis
            // 
            this.lblSearchDatumBis.Location = new System.Drawing.Point(248, 40);
            this.lblSearchDatumBis.Name = "lblSearchDatumBis";
            this.lblSearchDatumBis.Size = new System.Drawing.Size(30, 24);
            this.lblSearchDatumBis.TabIndex = 13;
            this.lblSearchDatumBis.Text = "bis";
            this.lblSearchDatumBis.UseCompatibleTextRendering = true;
            // 
            // edtFaDokSucheSAR
            // 
            this.edtFaDokSucheSAR.IsSearchField = true;
            this.edtFaDokSucheSAR.Location = new System.Drawing.Point(138, 100);
            this.edtFaDokSucheSAR.LookupSQL = resources.GetString("edtFaDokSucheSAR.LookupSQL");
            this.edtFaDokSucheSAR.Name = "edtFaDokSucheSAR";
            this.edtFaDokSucheSAR.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFaDokSucheSAR.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaDokSucheSAR.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaDokSucheSAR.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaDokSucheSAR.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaDokSucheSAR.Properties.Appearance.Options.UseFont = true;
            this.edtFaDokSucheSAR.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtFaDokSucheSAR.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtFaDokSucheSAR.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFaDokSucheSAR.Properties.Name = "kissButtonEdit1.Properties";
            this.edtFaDokSucheSAR.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtFaDokSucheSAR.Size = new System.Drawing.Size(283, 24);
            this.edtFaDokSucheSAR.TabIndex = 12;
            // 
            // lblSearchKontaktart
            // 
            this.lblSearchKontaktart.Location = new System.Drawing.Point(31, 70);
            this.lblSearchKontaktart.Name = "lblSearchKontaktart";
            this.lblSearchKontaktart.Size = new System.Drawing.Size(101, 24);
            this.lblSearchKontaktart.TabIndex = 15;
            this.lblSearchKontaktart.Text = "Kontaktart";
            this.lblSearchKontaktart.UseCompatibleTextRendering = true;
            // 
            // edtFaDokSucheStichwort
            // 
            this.edtFaDokSucheStichwort.Location = new System.Drawing.Point(138, 130);
            this.edtFaDokSucheStichwort.Name = "edtFaDokSucheStichwort";
            this.edtFaDokSucheStichwort.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFaDokSucheStichwort.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaDokSucheStichwort.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaDokSucheStichwort.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaDokSucheStichwort.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaDokSucheStichwort.Properties.Appearance.Options.UseFont = true;
            this.edtFaDokSucheStichwort.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFaDokSucheStichwort.Properties.Name = "kissTextEdit1.Properties";
            this.edtFaDokSucheStichwort.Size = new System.Drawing.Size(283, 24);
            this.edtFaDokSucheStichwort.TabIndex = 13;
            // 
            // lblUser
            // 
            this.lblUser.Location = new System.Drawing.Point(31, 100);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(101, 24);
            this.lblUser.TabIndex = 17;
            this.lblUser.Text = "Mitarbeiter/in";
            this.lblUser.UseCompatibleTextRendering = true;
            // 
            // lblSearchStichwort
            // 
            this.lblSearchStichwort.Location = new System.Drawing.Point(31, 130);
            this.lblSearchStichwort.Name = "lblSearchStichwort";
            this.lblSearchStichwort.Size = new System.Drawing.Size(101, 24);
            this.lblSearchStichwort.TabIndex = 19;
            this.lblSearchStichwort.Text = "Stichworte";
            this.lblSearchStichwort.UseCompatibleTextRendering = true;
            // 
            // pnTitle
            // 
            this.pnTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnTitle.Controls.Add(this.lblTitle);
            this.pnTitle.Controls.Add(this.imageTitle);
            this.pnTitle.Location = new System.Drawing.Point(-3, 0);
            this.pnTitle.Name = "pnTitle";
            this.pnTitle.Size = new System.Drawing.Size(845, 40);
            this.pnTitle.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitle.Location = new System.Drawing.Point(35, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(221, 20);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Besprechungen";
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
            // chkThemenFilter
            // 
            this.chkThemenFilter.EditValue = false;
            this.chkThemenFilter.Location = new System.Drawing.Point(443, 40);
            this.chkThemenFilter.Name = "chkThemenFilter";
            this.chkThemenFilter.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkThemenFilter.Properties.Appearance.Options.UseBackColor = true;
            this.chkThemenFilter.Properties.Caption = "Themen filtern (ein/aus)";
            this.chkThemenFilter.Size = new System.Drawing.Size(176, 19);
            this.chkThemenFilter.TabIndex = 14;
            this.chkThemenFilter.CheckedChanged += new System.EventHandler(this.chkThemenFilter_CheckedChanged);
            // 
            // lookupThemen
            // 
            this.lookupThemen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lookupThemen.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.lookupThemen.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.lookupThemen.Appearance.Options.UseBackColor = true;
            this.lookupThemen.Appearance.Options.UseBorderColor = true;
            this.lookupThemen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lookupThemen.CheckOnClick = true;
            this.lookupThemen.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.lookupThemen.Location = new System.Drawing.Point(443, 69);
            this.lookupThemen.LOVName = "FaThema";
            this.lookupThemen.Name = "lookupThemen";
            this.lookupThemen.Size = new System.Drawing.Size(218, 106);
            this.lookupThemen.TabIndex = 15;
            // 
            // panDetail
            // 
            this.panDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panDetail.AutoScroll = true;
            this.panDetail.Controls.Add(this.edtThemen);
            this.panDetail.Controls.Add(this.lblThemen);
            this.panDetail.Controls.Add(this.ctlLogischLoeschen);
            this.panDetail.Controls.Add(this.memInhalt);
            this.panDetail.Controls.Add(this.edtDauer);
            this.panDetail.Controls.Add(this.lblStichwort);
            this.panDetail.Controls.Add(this.lblInhalt);
            this.panDetail.Controls.Add(this.lblDauer);
            this.panDetail.Controls.Add(this.lblAutor);
            this.panDetail.Controls.Add(this.lblKontaktart);
            this.panDetail.Controls.Add(this.btnDokument);
            this.panDetail.Controls.Add(this.lblDatum);
            this.panDetail.Controls.Add(this.edtStichwort);
            this.panDetail.Controls.Add(this.edtFaDokBesprAutor);
            this.panDetail.Controls.Add(this.lblKontaktpartner);
            this.panDetail.Controls.Add(this.edtFaDokBesprKontakArt);
            this.panDetail.Controls.Add(this.edtFaDokBesprKontakPart);
            this.panDetail.Controls.Add(this.edtDatum);
            this.panDetail.Location = new System.Drawing.Point(0, 268);
            this.panDetail.Name = "panDetail";
            this.panDetail.Size = new System.Drawing.Size(845, 312);
            this.panDetail.TabIndex = 3;
            // 
            // edtThemen
            // 
            this.edtThemen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtThemen.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtThemen.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtThemen.Appearance.Options.UseBackColor = true;
            this.edtThemen.Appearance.Options.UseBorderColor = true;
            this.edtThemen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtThemen.CheckOnClick = true;
            this.edtThemen.DataMember = "FaThemaCodes";
            this.edtThemen.DataSource = this.qryFaAktennotiz;
            this.edtThemen.Location = new System.Drawing.Point(607, 18);
            this.edtThemen.LOVName = "FaThema";
            this.edtThemen.Name = "edtThemen";
            this.edtThemen.Size = new System.Drawing.Size(223, 175);
            this.edtThemen.TabIndex = 82;
            // 
            // lblThemen
            // 
            this.lblThemen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblThemen.Location = new System.Drawing.Point(538, 18);
            this.lblThemen.Name = "lblThemen";
            this.lblThemen.Size = new System.Drawing.Size(63, 24);
            this.lblThemen.TabIndex = 96;
            this.lblThemen.Text = "Themen";
            // 
            // ctlLogischLoeschen
            // 
            this.ctlLogischLoeschen.ActiveSQLQuery = this.qryFaAktennotiz;
            this.ctlLogischLoeschen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlLogischLoeschen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlLogischLoeschen.Location = new System.Drawing.Point(6, 243);
            this.ctlLogischLoeschen.Name = "ctlLogischLoeschen";
            this.ctlLogischLoeschen.Size = new System.Drawing.Size(827, 66);
            this.ctlLogischLoeschen.TabIndex = 90;
            this.ctlLogischLoeschen.RestoreClick += new System.EventHandler(this.btnRestoreDocument_Click);
            // 
            // memInhalt
            // 
            this.memInhalt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memInhalt.BackColor = System.Drawing.Color.White;
            this.memInhalt.DataMember = "InhaltRTF";
            this.memInhalt.DataSource = this.qryFaAktennotiz;
            this.memInhalt.Font = new System.Drawing.Font("Arial", 10F);
            this.memInhalt.Location = new System.Drawing.Point(122, 199);
            this.memInhalt.Name = "memInhalt";
            this.memInhalt.Size = new System.Drawing.Size(708, 38);
            this.memInhalt.TabIndex = 81;
            // 
            // edtDauer
            // 
            this.edtDauer.DataMember = "FaDauerCode";
            this.edtDauer.DataSource = this.qryFaAktennotiz;
            this.edtDauer.Location = new System.Drawing.Point(122, 108);
            this.edtDauer.LOVName = "FaDauer";
            this.edtDauer.Name = "edtDauer";
            this.edtDauer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDauer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDauer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDauer.Properties.Appearance.Options.UseBackColor = true;
            this.edtDauer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDauer.Properties.Appearance.Options.UseFont = true;
            this.edtDauer.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtDauer.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtDauer.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtDauer.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtDauer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtDauer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtDauer.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDauer.Properties.NullText = "";
            this.edtDauer.Properties.ShowFooter = false;
            this.edtDauer.Properties.ShowHeader = false;
            this.edtDauer.Size = new System.Drawing.Size(275, 24);
            this.edtDauer.TabIndex = 78;
            // 
            // lblStichwort
            // 
            this.lblStichwort.Location = new System.Drawing.Point(10, 168);
            this.lblStichwort.Name = "lblStichwort";
            this.lblStichwort.Size = new System.Drawing.Size(106, 24);
            this.lblStichwort.TabIndex = 90;
            this.lblStichwort.Text = "Stichwort";
            this.lblStichwort.UseCompatibleTextRendering = true;
            // 
            // lblInhalt
            // 
            this.lblInhalt.Location = new System.Drawing.Point(10, 199);
            this.lblInhalt.Name = "lblInhalt";
            this.lblInhalt.Size = new System.Drawing.Size(106, 24);
            this.lblInhalt.TabIndex = 89;
            this.lblInhalt.Text = "Inhalt";
            this.lblInhalt.UseCompatibleTextRendering = true;
            // 
            // lblDauer
            // 
            this.lblDauer.Location = new System.Drawing.Point(10, 108);
            this.lblDauer.Name = "lblDauer";
            this.lblDauer.Size = new System.Drawing.Size(106, 24);
            this.lblDauer.TabIndex = 87;
            this.lblDauer.Text = "Dauer";
            this.lblDauer.UseCompatibleTextRendering = true;
            // 
            // lblAutor
            // 
            this.lblAutor.Location = new System.Drawing.Point(10, 138);
            this.lblAutor.Name = "lblAutor";
            this.lblAutor.Size = new System.Drawing.Size(106, 24);
            this.lblAutor.TabIndex = 85;
            this.lblAutor.Text = "Autor";
            this.lblAutor.UseCompatibleTextRendering = true;
            // 
            // lblKontaktart
            // 
            this.lblKontaktart.Location = new System.Drawing.Point(10, 78);
            this.lblKontaktart.Name = "lblKontaktart";
            this.lblKontaktart.Size = new System.Drawing.Size(106, 24);
            this.lblKontaktart.TabIndex = 83;
            this.lblKontaktart.Text = "Kontaktart";
            this.lblKontaktart.UseCompatibleTextRendering = true;
            // 
            // btnDokument
            // 
            this.btnDokument.Context = "FaDokBesprBericht";
            this.btnDokument.DocumentFormat = KiSS4.Dokument.DlgNewDocument.DocumentAccessModes.All;
            this.btnDokument.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDokument.Image = ((System.Drawing.Image)(resources.GetObject("btnDokument.Image")));
            this.btnDokument.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDokument.Location = new System.Drawing.Point(264, 18);
            this.btnDokument.Name = "btnDokument";
            this.btnDokument.Size = new System.Drawing.Size(133, 24);
            this.btnDokument.TabIndex = 75;
            this.btnDokument.Text = "  Dokument";
            this.btnDokument.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDokument.UseCompatibleTextRendering = true;
            this.btnDokument.UseVisualStyleBackColor = false;
            // 
            // lblDatum
            // 
            this.lblDatum.Location = new System.Drawing.Point(10, 18);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(106, 24);
            this.lblDatum.TabIndex = 80;
            this.lblDatum.Text = "Datum";
            this.lblDatum.UseCompatibleTextRendering = true;
            // 
            // edtStichwort
            // 
            this.edtStichwort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtStichwort.DataMember = "Stichwort";
            this.edtStichwort.DataSource = this.qryFaAktennotiz;
            this.edtStichwort.Location = new System.Drawing.Point(122, 168);
            this.edtStichwort.Name = "edtStichwort";
            this.edtStichwort.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStichwort.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStichwort.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStichwort.Properties.Appearance.Options.UseBackColor = true;
            this.edtStichwort.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStichwort.Properties.Appearance.Options.UseFont = true;
            this.edtStichwort.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStichwort.Size = new System.Drawing.Size(465, 24);
            this.edtStichwort.TabIndex = 80;
            // 
            // edtFaDokBesprAutor
            // 
            this.edtFaDokBesprAutor.DataMember = "User";
            this.edtFaDokBesprAutor.DataMemberUserId = "UserID";
            this.edtFaDokBesprAutor.DataSource = this.qryFaAktennotiz;
            this.edtFaDokBesprAutor.Location = new System.Drawing.Point(122, 138);
            this.edtFaDokBesprAutor.LookupID = ((object)(resources.GetObject("edtFaDokBesprAutor.LookupID")));
            this.edtFaDokBesprAutor.Name = "edtFaDokBesprAutor";
            this.edtFaDokBesprAutor.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFaDokBesprAutor.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaDokBesprAutor.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaDokBesprAutor.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaDokBesprAutor.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaDokBesprAutor.Properties.Appearance.Options.UseFont = true;
            this.edtFaDokBesprAutor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtFaDokBesprAutor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtFaDokBesprAutor.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFaDokBesprAutor.Properties.Name = "edtFaDokBesprAutor.Properties";
            this.edtFaDokBesprAutor.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtFaDokBesprAutor.Size = new System.Drawing.Size(275, 24);
            this.edtFaDokBesprAutor.TabIndex = 79;
            // 
            // lblKontaktpartner
            // 
            this.lblKontaktpartner.Location = new System.Drawing.Point(10, 48);
            this.lblKontaktpartner.Name = "lblKontaktpartner";
            this.lblKontaktpartner.Size = new System.Drawing.Size(106, 24);
            this.lblKontaktpartner.TabIndex = 76;
            this.lblKontaktpartner.Text = "Kontaktpartner";
            this.lblKontaktpartner.UseCompatibleTextRendering = true;
            // 
            // edtFaDokBesprKontakArt
            // 
            this.edtFaDokBesprKontakArt.DataMember = "FaKontaktartCode";
            this.edtFaDokBesprKontakArt.DataSource = this.qryFaAktennotiz;
            this.edtFaDokBesprKontakArt.Location = new System.Drawing.Point(122, 78);
            this.edtFaDokBesprKontakArt.LOVName = "FaKontaktart";
            this.edtFaDokBesprKontakArt.Name = "edtFaDokBesprKontakArt";
            this.edtFaDokBesprKontakArt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFaDokBesprKontakArt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaDokBesprKontakArt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaDokBesprKontakArt.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaDokBesprKontakArt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaDokBesprKontakArt.Properties.Appearance.Options.UseFont = true;
            this.edtFaDokBesprKontakArt.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtFaDokBesprKontakArt.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaDokBesprKontakArt.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtFaDokBesprKontakArt.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtFaDokBesprKontakArt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtFaDokBesprKontakArt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtFaDokBesprKontakArt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFaDokBesprKontakArt.Properties.Name = "edtFaDokBesprKontakArt.Properties";
            this.edtFaDokBesprKontakArt.Properties.NullText = "";
            this.edtFaDokBesprKontakArt.Properties.ShowFooter = false;
            this.edtFaDokBesprKontakArt.Properties.ShowHeader = false;
            this.edtFaDokBesprKontakArt.Size = new System.Drawing.Size(275, 24);
            this.edtFaDokBesprKontakArt.TabIndex = 77;
            // 
            // edtFaDokBesprKontakPart
            // 
            this.edtFaDokBesprKontakPart.DataMember = "Kontaktpartner";
            this.edtFaDokBesprKontakPart.DataSource = this.qryFaAktennotiz;
            this.edtFaDokBesprKontakPart.Location = new System.Drawing.Point(122, 48);
            this.edtFaDokBesprKontakPart.Name = "edtFaDokBesprKontakPart";
            this.edtFaDokBesprKontakPart.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFaDokBesprKontakPart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaDokBesprKontakPart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaDokBesprKontakPart.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaDokBesprKontakPart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaDokBesprKontakPart.Properties.Appearance.Options.UseFont = true;
            this.edtFaDokBesprKontakPart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFaDokBesprKontakPart.Properties.Name = "edtFaDokBesprKontakPart.Properties";
            this.edtFaDokBesprKontakPart.Size = new System.Drawing.Size(275, 24);
            this.edtFaDokBesprKontakPart.TabIndex = 76;
            // 
            // edtDatum
            // 
            this.edtDatum.DataMember = "Datum";
            this.edtDatum.DataSource = this.qryFaAktennotiz;
            this.edtDatum.EditValue = ((object)(resources.GetObject("edtDatum.EditValue")));
            this.edtDatum.Location = new System.Drawing.Point(122, 18);
            this.edtDatum.Name = "edtDatum";
            this.edtDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatum.Properties.Appearance.Options.UseFont = true;
            this.edtDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatum.Properties.Name = "edtFaDokBesprDatum.Properties";
            this.edtDatum.Properties.ShowToday = false;
            this.edtDatum.Size = new System.Drawing.Size(100, 24);
            this.edtDatum.TabIndex = 74;
            // 
            // CtlFaAktennotiz
            // 
            this.ActiveSQLQuery = this.qryFaAktennotiz;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(845, 586);
            this.Controls.Add(this.panDetail);
            this.Controls.Add(this.pnTitle);
            this.Location = new System.Drawing.Point(-102, 0);
            this.Name = "CtlFaAktennotiz";
            this.Size = new System.Drawing.Size(845, 586);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.pnTitle, 0);
            this.Controls.SetChildIndex(this.panDetail, 0);
            ((System.ComponentModel.ISupportInitialize)(this.radGrpDeleted.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGrpDeleted)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdFaAktennotiz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaAktennotiz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwFaAktennotiz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokSucheDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokSucheDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokSucheKontaktart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokSucheKontaktart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokSucheSAR.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchKontaktart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokSucheStichwort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchStichwort)).EndInit();
            this.pnTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkThemenFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupThemen)).EndInit();
            this.panDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtThemen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblThemen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDauer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDauer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichwort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInhalt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDauer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAutor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichwort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokBesprAutor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktpartner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokBesprKontakArt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokBesprKontakArt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokBesprKontakPart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatum.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Dokument.KissDocumentButton btnDokument;
        private KiSS4.Gui.KissCheckEdit chkThemenFilter;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colIsDeleted;
        private DevExpress.XtraGrid.Columns.GridColumn colKontaktpartner;
        private DevExpress.XtraGrid.Columns.GridColumn colMitarbeiter;
        private DevExpress.XtraGrid.Columns.GridColumn colStichwort;
        private DevExpress.XtraGrid.Columns.GridColumn colThemen;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Common.CtlLogischesLoeschen ctlLogischLoeschen;
        private KiSS4.Gui.KissDateEdit edtDatum;
        private KiSS4.Gui.KissLookUpEdit edtDauer;
        private KiSS4.Common.KissMitarbeiterButtonEdit edtFaDokBesprAutor;
        private KiSS4.Gui.KissLookUpEdit edtFaDokBesprKontakArt;
        private KiSS4.Gui.KissTextEdit edtFaDokBesprKontakPart;
        private KiSS4.Gui.KissDateEdit edtFaDokSucheDatumBis;
        private KiSS4.Gui.KissDateEdit edtFaDokSucheDatumVon;
        private KiSS4.Gui.KissLookUpEdit edtFaDokSucheKontaktart;
        private KiSS4.Common.KissMitarbeiterButtonEdit edtFaDokSucheSAR;
        private KiSS4.Gui.KissTextEdit edtFaDokSucheStichwort;
        private KiSS4.Gui.KissTextEdit edtStichwort;
        private KiSS4.Gui.KissCheckedLookupEdit edtThemen;
        private KiSS4.Gui.KissGrid grdFaAktennotiz;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gvwFaAktennotiz;
        private System.Windows.Forms.PictureBox imageTitle;
        private KiSS4.Gui.KissLabel lblAutor;
        private KiSS4.Gui.KissLabel lblDatum;
        private KiSS4.Gui.KissLabel lblDauer;
        private KiSS4.Gui.KissLabel lblInhalt;
        private KiSS4.Gui.KissLabel lblKontaktart;
        private KiSS4.Gui.KissLabel lblKontaktpartner;
        private KiSS4.Gui.KissLabel lblSearchDatumBis;
        private KiSS4.Gui.KissLabel lblSearchDatumVon;
        private KiSS4.Gui.KissLabel lblSearchKontaktart;
        private KiSS4.Gui.KissLabel lblSearchStichwort;
        private KiSS4.Gui.KissLabel lblStichwort;
        private KiSS4.Gui.KissLabel lblThemen;
        private KiSS4.Gui.KissLabel lblTitle;
        private KiSS4.Gui.KissLabel lblUser;
        private KiSS4.Gui.KissCheckedLookupEdit lookupThemen;
        private KiSS4.Gui.KissRTFEdit memInhalt;
        private System.Windows.Forms.Panel panDetail;
        private System.Windows.Forms.Panel pnTitle;
        private KiSS4.DB.SqlQuery qryFaAktennotiz;
    }
}
