namespace KiSS4.Fallfuehrung
{
    partial class CtlFaDokumente
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject17 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject16 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject15 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject14 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject13 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFaDokumente));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.pnTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new KiSS4.Gui.KissLabel();
            this.imageTitle = new System.Windows.Forms.PictureBox();
            this.grdDokumente = new KiSS4.Gui.KissGrid();
            this.qryFaDokumente = new KiSS4.DB.SqlQuery();
            this.gvwDokumente = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThemen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStichworte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbsender = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdressat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsDeleted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDienst = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblSucheDatumVon = new KiSS4.Gui.KissLabel();
            this.lblSucheAbsender = new KiSS4.Gui.KissLabel();
            this.lblSucheAdressat = new KiSS4.Gui.KissLabel();
            this.lblSucheStichworte = new KiSS4.Gui.KissLabel();
            this.edtFaDokKorreSucheDatumVon = new KiSS4.Gui.KissDateEdit();
            this.lblSucheBis = new KiSS4.Gui.KissLabel();
            this.edtFaDokKorreSucheDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtFaDokKorreSucheAbsender = new KiSS4.Gui.KissTextEdit();
            this.edtFaDokKorreSucheAddressat = new KiSS4.Gui.KissTextEdit();
            this.edtFaDokKorreSucheStichwort = new KiSS4.Gui.KissTextEdit();
            this.lblSuchThema = new KiSS4.Gui.KissLabel();
            this.edtSuchThema = new KiSS4.Gui.KissLookUpEdit();
            this.edtDatumErstellung = new KiSS4.Gui.KissDateEdit();
            this.lblFaDokKorreDokument = new KiSS4.Gui.KissLabel();
            this.edtAbsender = new KiSS4.Common.KissMitarbeiterButtonEdit();
            this.edtAdressat = new KiSS4.Common.KissAdressatButtonEdit();
            this.lblDatumErstellung = new KiSS4.Gui.KissLabel();
            this.edtStichwort = new KiSS4.Gui.KissTextEdit();
            this.edtFaDokKorreDokument = new KiSS4.Dokument.XDokument();
            this.lblStichwort = new KiSS4.Gui.KissLabel();
            this.lblAdressat = new KiSS4.Gui.KissLabel();
            this.lblAbsender = new KiSS4.Gui.KissLabel();
            this.memBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.edtBericht = new KiSS4.Gui.KissCheckEdit();
            this.lblThema = new KiSS4.Gui.KissLabel();
            this.edtThema = new KiSS4.Gui.KissLookUpEdit();
            this.colPendenzDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPendenzMitarbeiter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPendenzStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPendenzText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtThemen = new KiSS4.Gui.KissCheckedLookupEdit();
            this.lookupThemen = new KiSS4.Gui.KissCheckedLookupEdit();
            this.lblDauer = new KiSS4.Gui.KissLabel();
            this.lblErbDienst = new KiSS4.Gui.KissLabel();
            this.edtDauer = new KiSS4.Gui.KissLookUpEdit();
            this.edtErbDienst = new KiSS4.Gui.KissLookUpEdit();
            this.lblThemen = new KiSS4.Gui.KissLabel();
            this.chkThemenFilter = new KiSS4.Gui.KissCheckEdit();
            this.ctlLogischLoeschen = new KiSS4.Common.CtlLogischesLoeschen();
            this.lblMerkblaetter = new KiSS4.Gui.KissLabel();
            this.edtDocMerkblaetter = new KiSS4.Dokument.XDokument();
            ((System.ComponentModel.ISupportInitialize)(this.radGrpDeleted)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGrpDeleted.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            this.pnTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDokumente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaDokumente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwDokumente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheAbsender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheAdressat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheStichworte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokKorreSucheDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokKorreSucheDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokKorreSucheAbsender.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokKorreSucheAddressat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokKorreSucheStichwort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchThema)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchThema)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchThema.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumErstellung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaDokKorreDokument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbsender.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdressat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumErstellung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichwort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokKorreDokument.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichwort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdressat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbsender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBericht.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblThema)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtThema)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtThema.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtThemen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupThemen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDauer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErbDienst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDauer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDauer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErbDienst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErbDienst.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblThemen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkThemenFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMerkblaetter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDocMerkblaetter.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // radGrpDeleted
            // 
            this.radGrpDeleted.Location = new System.Drawing.Point(595, 40);
            this.radGrpDeleted.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radGrpDeleted.Properties.Appearance.Options.UseBackColor = true;
            this.radGrpDeleted.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.radGrpDeleted.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.radGrpDeleted.Size = new System.Drawing.Size(130, 86);
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(760, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSearch.Location = new System.Drawing.Point(0, 35);
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.Size = new System.Drawing.Size(767, 305);
            this.tabControlSearch.TabIndex = 2;
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdDokumente);
            this.tpgListe.Size = new System.Drawing.Size(755, 267);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.lookupThemen);
            this.tpgSuchen.Controls.Add(this.edtSuchThema);
            this.tpgSuchen.Controls.Add(this.chkThemenFilter);
            this.tpgSuchen.Controls.Add(this.edtFaDokKorreSucheAddressat);
            this.tpgSuchen.Controls.Add(this.edtFaDokKorreSucheStichwort);
            this.tpgSuchen.Controls.Add(this.edtFaDokKorreSucheAbsender);
            this.tpgSuchen.Controls.Add(this.lblSuchThema);
            this.tpgSuchen.Controls.Add(this.lblSucheAdressat);
            this.tpgSuchen.Controls.Add(this.edtFaDokKorreSucheDatumBis);
            this.tpgSuchen.Controls.Add(this.edtFaDokKorreSucheDatumVon);
            this.tpgSuchen.Controls.Add(this.lblSucheBis);
            this.tpgSuchen.Controls.Add(this.lblSucheAbsender);
            this.tpgSuchen.Controls.Add(this.lblSucheDatumVon);
            this.tpgSuchen.Controls.Add(this.lblSucheStichworte);
            this.tpgSuchen.Size = new System.Drawing.Size(755, 267);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheStichworte, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.radGrpDeleted, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheAbsender, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFaDokKorreSucheDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFaDokKorreSucheDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheAdressat, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSuchThema, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFaDokKorreSucheAbsender, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFaDokKorreSucheStichwort, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFaDokKorreSucheAddressat, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkThemenFilter, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSuchThema, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lookupThemen, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            // 
            // pnTitle
            // 
            this.pnTitle.Controls.Add(this.lblTitle);
            this.pnTitle.Controls.Add(this.imageTitle);
            this.pnTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTitle.Location = new System.Drawing.Point(0, 0);
            this.pnTitle.Name = "pnTitle";
            this.pnTitle.Size = new System.Drawing.Size(767, 40);
            this.pnTitle.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitle.Location = new System.Drawing.Point(35, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(500, 20);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Korrespondenz";
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
            // grdDokumente
            // 
            this.grdDokumente.DataSource = this.qryFaDokumente;
            this.grdDokumente.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdDokumente.EmbeddedNavigator.Name = "gridCtlKiSS3UserMask_Fa_Dok_Korrespondenz.EmbeddedNavigator";
            this.grdDokumente.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdDokumente.Location = new System.Drawing.Point(0, 0);
            this.grdDokumente.MainView = this.gvwDokumente;
            this.grdDokumente.Name = "grdDokumente";
            this.grdDokumente.Size = new System.Drawing.Size(755, 267);
            this.grdDokumente.TabIndex = 3;
            this.grdDokumente.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvwDokumente});
            // 
            // qryFaDokumente
            // 
            this.qryFaDokumente.CanDelete = true;
            this.qryFaDokumente.CanInsert = true;
            this.qryFaDokumente.CanUpdate = true;
            this.qryFaDokumente.HostControl = this;
            this.qryFaDokumente.SelectStatement = resources.GetString("qryFaDokumente.SelectStatement");
            this.qryFaDokumente.TableName = "FaDokumente";
            this.qryFaDokumente.AfterInsert += new System.EventHandler(this.qryFaDokumente_AfterInsert);
            this.qryFaDokumente.BeforePost += new System.EventHandler(this.qryFaDokumente_BeforePost);
            // 
            // gvwDokumente
            // 
            this.gvwDokumente.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gvwDokumente.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwDokumente.Appearance.Empty.Options.UseBackColor = true;
            this.gvwDokumente.Appearance.Empty.Options.UseFont = true;
            this.gvwDokumente.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwDokumente.Appearance.EvenRow.Options.UseFont = true;
            this.gvwDokumente.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvwDokumente.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwDokumente.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gvwDokumente.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvwDokumente.Appearance.FocusedCell.Options.UseFont = true;
            this.gvwDokumente.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvwDokumente.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvwDokumente.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwDokumente.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gvwDokumente.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvwDokumente.Appearance.FocusedRow.Options.UseFont = true;
            this.gvwDokumente.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gvwDokumente.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gvwDokumente.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gvwDokumente.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gvwDokumente.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvwDokumente.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvwDokumente.Appearance.GroupRow.Options.UseBackColor = true;
            this.gvwDokumente.Appearance.GroupRow.Options.UseFont = true;
            this.gvwDokumente.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvwDokumente.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gvwDokumente.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gvwDokumente.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvwDokumente.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvwDokumente.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gvwDokumente.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvwDokumente.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gvwDokumente.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwDokumente.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvwDokumente.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvwDokumente.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvwDokumente.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gvwDokumente.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gvwDokumente.Appearance.HorzLine.Options.UseBackColor = true;
            this.gvwDokumente.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwDokumente.Appearance.OddRow.Options.UseFont = true;
            this.gvwDokumente.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gvwDokumente.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwDokumente.Appearance.Row.Options.UseBackColor = true;
            this.gvwDokumente.Appearance.Row.Options.UseFont = true;
            this.gvwDokumente.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwDokumente.Appearance.SelectedRow.Options.UseFont = true;
            this.gvwDokumente.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gvwDokumente.Appearance.VertLine.Options.UseBackColor = true;
            this.gvwDokumente.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gvwDokumente.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatum,
            this.colThemen,
            this.colStichworte,
            this.colAbsender,
            this.colAdressat,
            this.colIsDeleted,
            this.colDienst});
            this.gvwDokumente.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gvwDokumente.GridControl = this.grdDokumente;
            this.gvwDokumente.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.gvwDokumente.Name = "gvwDokumente";
            this.gvwDokumente.OptionsBehavior.Editable = false;
            this.gvwDokumente.OptionsCustomization.AllowFilter = false;
            this.gvwDokumente.OptionsFilter.AllowFilterEditor = false;
            this.gvwDokumente.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gvwDokumente.OptionsMenu.EnableColumnMenu = false;
            this.gvwDokumente.OptionsNavigation.AutoFocusNewRow = true;
            this.gvwDokumente.OptionsNavigation.UseTabKey = false;
            this.gvwDokumente.OptionsView.ColumnAutoWidth = false;
            this.gvwDokumente.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvwDokumente.OptionsView.ShowGroupPanel = false;
            this.gvwDokumente.OptionsView.ShowIndicator = false;
            // 
            // colDatum
            // 
            this.colDatum.Caption = "Datum";
            this.colDatum.FieldName = "DatumErstellung";
            this.colDatum.Name = "colDatum";
            this.colDatum.Visible = true;
            this.colDatum.VisibleIndex = 0;
            this.colDatum.Width = 72;
            // 
            // colThemen
            // 
            this.colThemen.Caption = "Themen";
            this.colThemen.FieldName = "FaThemaCodesText";
            this.colThemen.Name = "colThemen";
            this.colThemen.Visible = true;
            this.colThemen.VisibleIndex = 3;
            this.colThemen.Width = 150;
            // 
            // colStichworte
            // 
            this.colStichworte.Caption = "Stichwort";
            this.colStichworte.FieldName = "Stichwort";
            this.colStichworte.Name = "colStichworte";
            this.colStichworte.Visible = true;
            this.colStichworte.VisibleIndex = 2;
            this.colStichworte.Width = 289;
            // 
            // colAbsender
            // 
            this.colAbsender.Caption = "Autor";
            this.colAbsender.FieldName = "AbsenderName";
            this.colAbsender.Name = "colAbsender";
            this.colAbsender.Visible = true;
            this.colAbsender.VisibleIndex = 4;
            this.colAbsender.Width = 132;
            // 
            // colAdressat
            // 
            this.colAdressat.Caption = "Adressat";
            this.colAdressat.FieldName = "AdressatName";
            this.colAdressat.Name = "colAdressat";
            this.colAdressat.Visible = true;
            this.colAdressat.VisibleIndex = 5;
            this.colAdressat.Width = 164;
            // 
            // colIsDeleted
            // 
            this.colIsDeleted.Caption = "gelöscht";
            this.colIsDeleted.FieldName = "IsDeleted";
            this.colIsDeleted.Name = "colIsDeleted";
            this.colIsDeleted.Visible = true;
            this.colIsDeleted.VisibleIndex = 6;
            // 
            // colDienst
            // 
            this.colDienst.Caption = "Dienst";
            this.colDienst.Name = "colDienst";
            this.colDienst.Visible = true;
            this.colDienst.VisibleIndex = 1;
            this.colDienst.Width = 56;
            // 
            // lblSucheDatumVon
            // 
            this.lblSucheDatumVon.Location = new System.Drawing.Point(30, 40);
            this.lblSucheDatumVon.Name = "lblSucheDatumVon";
            this.lblSucheDatumVon.Size = new System.Drawing.Size(72, 24);
            this.lblSucheDatumVon.TabIndex = 13;
            this.lblSucheDatumVon.Text = "Datum von";
            this.lblSucheDatumVon.UseCompatibleTextRendering = true;
            // 
            // lblSucheAbsender
            // 
            this.lblSucheAbsender.Location = new System.Drawing.Point(29, 68);
            this.lblSucheAbsender.Name = "lblSucheAbsender";
            this.lblSucheAbsender.Size = new System.Drawing.Size(72, 24);
            this.lblSucheAbsender.TabIndex = 14;
            this.lblSucheAbsender.Text = "Absender/in";
            this.lblSucheAbsender.UseCompatibleTextRendering = true;
            // 
            // lblSucheAdressat
            // 
            this.lblSucheAdressat.Location = new System.Drawing.Point(29, 98);
            this.lblSucheAdressat.Name = "lblSucheAdressat";
            this.lblSucheAdressat.Size = new System.Drawing.Size(72, 24);
            this.lblSucheAdressat.TabIndex = 15;
            this.lblSucheAdressat.Text = "Adressat/in";
            this.lblSucheAdressat.UseCompatibleTextRendering = true;
            // 
            // lblSucheStichworte
            // 
            this.lblSucheStichworte.Location = new System.Drawing.Point(29, 128);
            this.lblSucheStichworte.Name = "lblSucheStichworte";
            this.lblSucheStichworte.Size = new System.Drawing.Size(72, 24);
            this.lblSucheStichworte.TabIndex = 17;
            this.lblSucheStichworte.Text = "Stichwort(e)";
            this.lblSucheStichworte.UseCompatibleTextRendering = true;
            // 
            // edtFaDokKorreSucheDatumVon
            // 
            this.edtFaDokKorreSucheDatumVon.EditValue = null;
            this.edtFaDokKorreSucheDatumVon.Location = new System.Drawing.Point(110, 38);
            this.edtFaDokKorreSucheDatumVon.Name = "edtFaDokKorreSucheDatumVon";
            this.edtFaDokKorreSucheDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtFaDokKorreSucheDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFaDokKorreSucheDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaDokKorreSucheDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaDokKorreSucheDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaDokKorreSucheDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaDokKorreSucheDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtFaDokKorreSucheDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject17.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject17.Options.UseBackColor = true;
            this.edtFaDokKorreSucheDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtFaDokKorreSucheDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject17)});
            this.edtFaDokKorreSucheDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFaDokKorreSucheDatumVon.Properties.ShowToday = false;
            this.edtFaDokKorreSucheDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtFaDokKorreSucheDatumVon.TabIndex = 18;
            // 
            // lblSucheBis
            // 
            this.lblSucheBis.Location = new System.Drawing.Point(237, 38);
            this.lblSucheBis.Name = "lblSucheBis";
            this.lblSucheBis.Size = new System.Drawing.Size(32, 24);
            this.lblSucheBis.TabIndex = 19;
            this.lblSucheBis.Text = "bis";
            this.lblSucheBis.UseCompatibleTextRendering = true;
            // 
            // edtFaDokKorreSucheDatumBis
            // 
            this.edtFaDokKorreSucheDatumBis.EditValue = null;
            this.edtFaDokKorreSucheDatumBis.Location = new System.Drawing.Point(275, 38);
            this.edtFaDokKorreSucheDatumBis.Name = "edtFaDokKorreSucheDatumBis";
            this.edtFaDokKorreSucheDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtFaDokKorreSucheDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFaDokKorreSucheDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaDokKorreSucheDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaDokKorreSucheDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaDokKorreSucheDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaDokKorreSucheDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtFaDokKorreSucheDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject16.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject16.Options.UseBackColor = true;
            this.edtFaDokKorreSucheDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtFaDokKorreSucheDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject16)});
            this.edtFaDokKorreSucheDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFaDokKorreSucheDatumBis.Properties.ShowToday = false;
            this.edtFaDokKorreSucheDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtFaDokKorreSucheDatumBis.TabIndex = 19;
            // 
            // edtFaDokKorreSucheAbsender
            // 
            this.edtFaDokKorreSucheAbsender.Location = new System.Drawing.Point(110, 68);
            this.edtFaDokKorreSucheAbsender.Name = "edtFaDokKorreSucheAbsender";
            this.edtFaDokKorreSucheAbsender.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFaDokKorreSucheAbsender.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaDokKorreSucheAbsender.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaDokKorreSucheAbsender.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaDokKorreSucheAbsender.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaDokKorreSucheAbsender.Properties.Appearance.Options.UseFont = true;
            this.edtFaDokKorreSucheAbsender.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFaDokKorreSucheAbsender.Size = new System.Drawing.Size(265, 24);
            this.edtFaDokKorreSucheAbsender.TabIndex = 20;
            // 
            // edtFaDokKorreSucheAddressat
            // 
            this.edtFaDokKorreSucheAddressat.Location = new System.Drawing.Point(110, 98);
            this.edtFaDokKorreSucheAddressat.Name = "edtFaDokKorreSucheAddressat";
            this.edtFaDokKorreSucheAddressat.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFaDokKorreSucheAddressat.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaDokKorreSucheAddressat.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaDokKorreSucheAddressat.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaDokKorreSucheAddressat.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaDokKorreSucheAddressat.Properties.Appearance.Options.UseFont = true;
            this.edtFaDokKorreSucheAddressat.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFaDokKorreSucheAddressat.Size = new System.Drawing.Size(265, 24);
            this.edtFaDokKorreSucheAddressat.TabIndex = 21;
            // 
            // edtFaDokKorreSucheStichwort
            // 
            this.edtFaDokKorreSucheStichwort.Location = new System.Drawing.Point(110, 128);
            this.edtFaDokKorreSucheStichwort.Name = "edtFaDokKorreSucheStichwort";
            this.edtFaDokKorreSucheStichwort.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFaDokKorreSucheStichwort.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaDokKorreSucheStichwort.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaDokKorreSucheStichwort.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaDokKorreSucheStichwort.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaDokKorreSucheStichwort.Properties.Appearance.Options.UseFont = true;
            this.edtFaDokKorreSucheStichwort.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFaDokKorreSucheStichwort.Size = new System.Drawing.Size(265, 24);
            this.edtFaDokKorreSucheStichwort.TabIndex = 22;
            // 
            // lblSuchThema
            // 
            this.lblSuchThema.Location = new System.Drawing.Point(29, 158);
            this.lblSuchThema.Name = "lblSuchThema";
            this.lblSuchThema.Size = new System.Drawing.Size(80, 24);
            this.lblSuchThema.TabIndex = 25;
            this.lblSuchThema.Text = "Thema";
            this.lblSuchThema.UseCompatibleTextRendering = true;
            this.lblSuchThema.Visible = false;
            // 
            // edtSuchThema
            // 
            this.edtSuchThema.Location = new System.Drawing.Point(110, 158);
            this.edtSuchThema.LOVFilter = "FaThema";
            this.edtSuchThema.Name = "edtSuchThema";
            this.edtSuchThema.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSuchThema.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSuchThema.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSuchThema.Properties.Appearance.Options.UseBackColor = true;
            this.edtSuchThema.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSuchThema.Properties.Appearance.Options.UseFont = true;
            this.edtSuchThema.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSuchThema.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSuchThema.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSuchThema.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSuchThema.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject15.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject15.Options.UseBackColor = true;
            this.edtSuchThema.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject15)});
            this.edtSuchThema.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSuchThema.Properties.NullText = "";
            this.edtSuchThema.Properties.ShowFooter = false;
            this.edtSuchThema.Properties.ShowHeader = false;
            this.edtSuchThema.Size = new System.Drawing.Size(265, 24);
            this.edtSuchThema.TabIndex = 23;
            this.edtSuchThema.Visible = false;
            // 
            // edtDatumErstellung
            // 
            this.edtDatumErstellung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDatumErstellung.DataMember = "DatumErstellung";
            this.edtDatumErstellung.DataSource = this.qryFaDokumente;
            this.edtDatumErstellung.EditValue = ((object)(resources.GetObject("edtDatumErstellung.EditValue")));
            this.edtDatumErstellung.Location = new System.Drawing.Point(94, 348);
            this.edtDatumErstellung.Name = "edtDatumErstellung";
            this.edtDatumErstellung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumErstellung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumErstellung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumErstellung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumErstellung.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumErstellung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumErstellung.Properties.Appearance.Options.UseFont = true;
            this.edtDatumErstellung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.edtDatumErstellung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumErstellung.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12)});
            this.edtDatumErstellung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumErstellung.Properties.Name = "edtFaDokKorreDatum.Properties";
            this.edtDatumErstellung.Properties.ShowToday = false;
            this.edtDatumErstellung.Size = new System.Drawing.Size(100, 24);
            this.edtDatumErstellung.TabIndex = 46;
            // 
            // lblFaDokKorreDokument
            // 
            this.lblFaDokKorreDokument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFaDokKorreDokument.Location = new System.Drawing.Point(3, 558);
            this.lblFaDokKorreDokument.Name = "lblFaDokKorreDokument";
            this.lblFaDokKorreDokument.Size = new System.Drawing.Size(85, 24);
            this.lblFaDokKorreDokument.TabIndex = 47;
            this.lblFaDokKorreDokument.Text = "Dokument";
            this.lblFaDokKorreDokument.UseCompatibleTextRendering = true;
            // 
            // edtAbsender
            // 
            this.edtAbsender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAbsender.DataMember = "AbsenderName";
            this.edtAbsender.DataMemberUserId = "UserID_Absender";
            this.edtAbsender.DataSource = this.qryFaDokumente;
            this.edtAbsender.Location = new System.Drawing.Point(94, 379);
            this.edtAbsender.LookupID = ((object)(resources.GetObject("edtAbsender.LookupID")));
            this.edtAbsender.Name = "edtAbsender";
            this.edtAbsender.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAbsender.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAbsender.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbsender.Properties.Appearance.Options.UseBackColor = true;
            this.edtAbsender.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAbsender.Properties.Appearance.Options.UseFont = true;
            this.edtAbsender.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject14.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject14.Options.UseBackColor = true;
            this.edtAbsender.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject14)});
            this.edtAbsender.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAbsender.Properties.Name = "edtFaDokKorreAbsend.Properties";
            this.edtAbsender.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtAbsender.Size = new System.Drawing.Size(250, 24);
            this.edtAbsender.TabIndex = 48;
            // 
            // edtAdressat
            // 
            this.edtAdressat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAdressat.DataMemberVmPriMa = null;
            this.edtAdressat.DataSource = this.qryFaDokumente;
            this.edtAdressat.Location = new System.Drawing.Point(94, 409);
            this.edtAdressat.LookupID = ((object)(resources.GetObject("edtAdressat.LookupID")));
            this.edtAdressat.Name = "edtAdressat";
            this.edtAdressat.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAdressat.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdressat.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdressat.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdressat.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdressat.Properties.Appearance.Options.UseFont = true;
            this.edtAdressat.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject13.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject13.Options.UseBackColor = true;
            this.edtAdressat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13)});
            this.edtAdressat.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAdressat.Properties.Name = "edtFaDokKorreAddres.Properties";
            this.edtAdressat.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtAdressat.Size = new System.Drawing.Size(250, 24);
            this.edtAdressat.TabIndex = 49;
            // 
            // lblDatumErstellung
            // 
            this.lblDatumErstellung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDatumErstellung.Location = new System.Drawing.Point(3, 348);
            this.lblDatumErstellung.Name = "lblDatumErstellung";
            this.lblDatumErstellung.Size = new System.Drawing.Size(85, 24);
            this.lblDatumErstellung.TabIndex = 50;
            this.lblDatumErstellung.Text = "Datum";
            this.lblDatumErstellung.UseCompatibleTextRendering = true;
            // 
            // edtStichwort
            // 
            this.edtStichwort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtStichwort.DataMember = "Stichwort";
            this.edtStichwort.DataSource = this.qryFaDokumente;
            this.edtStichwort.Location = new System.Drawing.Point(94, 528);
            this.edtStichwort.Name = "edtStichwort";
            this.edtStichwort.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStichwort.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStichwort.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStichwort.Properties.Appearance.Options.UseBackColor = true;
            this.edtStichwort.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStichwort.Properties.Appearance.Options.UseFont = true;
            this.edtStichwort.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStichwort.Properties.Name = "edtFaDokKorreStichwort.Properties";
            this.edtStichwort.Size = new System.Drawing.Size(421, 24);
            this.edtStichwort.TabIndex = 53;
            // 
            // edtFaDokKorreDokument
            // 
            this.edtFaDokKorreDokument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtFaDokKorreDokument.Context = "FaKorrespondenz";
            this.edtFaDokKorreDokument.DataMember = "DocumentID";
            this.edtFaDokKorreDokument.DataSource = this.qryFaDokumente;
            this.edtFaDokKorreDokument.Location = new System.Drawing.Point(94, 558);
            this.edtFaDokKorreDokument.Name = "edtFaDokKorreDokument";
            this.edtFaDokKorreDokument.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFaDokKorreDokument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaDokKorreDokument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaDokKorreDokument.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaDokKorreDokument.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaDokKorreDokument.Properties.Appearance.Options.UseFont = true;
            this.edtFaDokKorreDokument.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.edtFaDokKorreDokument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtFaDokKorreDokument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtFaDokKorreDokument.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtFaDokKorreDokument.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtFaDokKorreDokument.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11, "Dokument importieren")});
            this.edtFaDokKorreDokument.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFaDokKorreDokument.Properties.Name = "edtFaDokKorreDokument.Properties";
            this.edtFaDokKorreDokument.Properties.ReadOnly = true;
            this.edtFaDokKorreDokument.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtFaDokKorreDokument.Size = new System.Drawing.Size(121, 24);
            this.edtFaDokKorreDokument.TabIndex = 54;
            // 
            // lblStichwort
            // 
            this.lblStichwort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStichwort.Location = new System.Drawing.Point(3, 528);
            this.lblStichwort.Name = "lblStichwort";
            this.lblStichwort.Size = new System.Drawing.Size(85, 24);
            this.lblStichwort.TabIndex = 53;
            this.lblStichwort.Text = "Stichwort";
            this.lblStichwort.UseCompatibleTextRendering = true;
            // 
            // lblAdressat
            // 
            this.lblAdressat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAdressat.Location = new System.Drawing.Point(3, 408);
            this.lblAdressat.Name = "lblAdressat";
            this.lblAdressat.Size = new System.Drawing.Size(85, 24);
            this.lblAdressat.TabIndex = 54;
            this.lblAdressat.Text = "Adressat";
            this.lblAdressat.UseCompatibleTextRendering = true;
            // 
            // lblAbsender
            // 
            this.lblAbsender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAbsender.Location = new System.Drawing.Point(3, 378);
            this.lblAbsender.Name = "lblAbsender";
            this.lblAbsender.Size = new System.Drawing.Size(85, 24);
            this.lblAbsender.TabIndex = 55;
            this.lblAbsender.Text = "Autor";
            this.lblAbsender.UseCompatibleTextRendering = true;
            // 
            // memBemerkung
            // 
            this.memBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memBemerkung.DataMember = "Bemerkung";
            this.memBemerkung.DataSource = this.qryFaDokumente;
            this.memBemerkung.Location = new System.Drawing.Point(94, 618);
            this.memBemerkung.Name = "memBemerkung";
            this.memBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.memBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.memBemerkung.Properties.Appearance.Options.UseFont = true;
            this.memBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memBemerkung.Size = new System.Drawing.Size(421, 53);
            this.memBemerkung.TabIndex = 56;
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBemerkung.Location = new System.Drawing.Point(3, 618);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(85, 24);
            this.lblBemerkung.TabIndex = 57;
            this.lblBemerkung.Text = "Handlung";
            this.lblBemerkung.UseCompatibleTextRendering = true;
            // 
            // edtBericht
            // 
            this.edtBericht.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBericht.DataMember = "IstBericht";
            this.edtBericht.DataSource = this.qryFaDokumente;
            this.edtBericht.Location = new System.Drawing.Point(207, 348);
            this.edtBericht.Name = "edtBericht";
            this.edtBericht.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBericht.Properties.Appearance.Options.UseBackColor = true;
            this.edtBericht.Properties.Caption = "Bericht";
            this.edtBericht.Size = new System.Drawing.Size(137, 19);
            this.edtBericht.TabIndex = 47;
            // 
            // lblThema
            // 
            this.lblThema.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblThema.Location = new System.Drawing.Point(3, 498);
            this.lblThema.Name = "lblThema";
            this.lblThema.Size = new System.Drawing.Size(85, 24);
            this.lblThema.TabIndex = 59;
            this.lblThema.Text = "Thema";
            this.lblThema.UseCompatibleTextRendering = true;
            // 
            // edtThema
            // 
            this.edtThema.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtThema.DataMember = "ThemaCode";
            this.edtThema.DataSource = this.qryFaDokumente;
            this.edtThema.Location = new System.Drawing.Point(94, 498);
            this.edtThema.LOVName = "FaThema";
            this.edtThema.Name = "edtThema";
            this.edtThema.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtThema.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtThema.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtThema.Properties.Appearance.Options.UseBackColor = true;
            this.edtThema.Properties.Appearance.Options.UseBorderColor = true;
            this.edtThema.Properties.Appearance.Options.UseFont = true;
            this.edtThema.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtThema.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtThema.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtThema.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtThema.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtThema.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtThema.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtThema.Properties.NullText = "";
            this.edtThema.Properties.ShowFooter = false;
            this.edtThema.Properties.ShowHeader = false;
            this.edtThema.Size = new System.Drawing.Size(250, 24);
            this.edtThema.TabIndex = 52;
            // 
            // colPendenzDatum
            // 
            this.colPendenzDatum.Caption = "Datum";
            this.colPendenzDatum.Name = "colPendenzDatum";
            this.colPendenzDatum.Visible = true;
            this.colPendenzDatum.VisibleIndex = 0;
            this.colPendenzDatum.Width = 76;
            // 
            // colPendenzMitarbeiter
            // 
            this.colPendenzMitarbeiter.Caption = "Mitarbeiter";
            this.colPendenzMitarbeiter.Name = "colPendenzMitarbeiter";
            this.colPendenzMitarbeiter.Visible = true;
            this.colPendenzMitarbeiter.VisibleIndex = 2;
            this.colPendenzMitarbeiter.Width = 181;
            // 
            // colPendenzStatus
            // 
            this.colPendenzStatus.Caption = "Status";
            this.colPendenzStatus.Name = "colPendenzStatus";
            this.colPendenzStatus.Visible = true;
            this.colPendenzStatus.VisibleIndex = 1;
            this.colPendenzStatus.Width = 105;
            // 
            // colPendenzText
            // 
            this.colPendenzText.Caption = "Text";
            this.colPendenzText.FieldName = "Text";
            this.colPendenzText.Name = "colPendenzText";
            this.colPendenzText.Visible = true;
            this.colPendenzText.VisibleIndex = 3;
            // 
            // edtThemen
            // 
            this.edtThemen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtThemen.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtThemen.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtThemen.Appearance.Options.UseBackColor = true;
            this.edtThemen.Appearance.Options.UseBorderColor = true;
            this.edtThemen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtThemen.CheckOnClick = true;
            this.edtThemen.DataMember = "FaThemaCodes";
            this.edtThemen.DataSource = this.qryFaDokumente;
            this.edtThemen.Location = new System.Drawing.Point(534, 348);
            this.edtThemen.LOVName = "FaThema";
            this.edtThemen.Name = "edtThemen";
            this.edtThemen.Size = new System.Drawing.Size(217, 204);
            this.edtThemen.TabIndex = 57;
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
            this.lookupThemen.Location = new System.Drawing.Point(403, 68);
            this.lookupThemen.LOVName = "FaThema";
            this.lookupThemen.Name = "lookupThemen";
            this.lookupThemen.Size = new System.Drawing.Size(195, 199);
            this.lookupThemen.TabIndex = 25;
            // 
            // lblDauer
            // 
            this.lblDauer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDauer.Location = new System.Drawing.Point(3, 469);
            this.lblDauer.Name = "lblDauer";
            this.lblDauer.Size = new System.Drawing.Size(85, 24);
            this.lblDauer.TabIndex = 62;
            this.lblDauer.Text = "Dauer";
            this.lblDauer.UseCompatibleTextRendering = true;
            // 
            // lblErbDienst
            // 
            this.lblErbDienst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblErbDienst.Location = new System.Drawing.Point(3, 439);
            this.lblErbDienst.Name = "lblErbDienst";
            this.lblErbDienst.Size = new System.Drawing.Size(85, 24);
            this.lblErbDienst.TabIndex = 63;
            this.lblErbDienst.Text = "Dienst";
            this.lblErbDienst.UseCompatibleTextRendering = true;
            // 
            // edtDauer
            // 
            this.edtDauer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDauer.DataMember = "FaDauerCode";
            this.edtDauer.DataSource = this.qryFaDokumente;
            this.edtDauer.Location = new System.Drawing.Point(94, 469);
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
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtDauer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtDauer.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDauer.Properties.NullText = "";
            this.edtDauer.Properties.ShowFooter = false;
            this.edtDauer.Properties.ShowHeader = false;
            this.edtDauer.Size = new System.Drawing.Size(250, 24);
            this.edtDauer.TabIndex = 51;
            // 
            // edtErbDienst
            // 
            this.edtErbDienst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtErbDienst.DataMember = "VmErbDienstCode";
            this.edtErbDienst.DataSource = this.qryFaDokumente;
            this.edtErbDienst.Location = new System.Drawing.Point(94, 439);
            this.edtErbDienst.LOVName = "VmErbDienst";
            this.edtErbDienst.Name = "edtErbDienst";
            this.edtErbDienst.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErbDienst.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErbDienst.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErbDienst.Properties.Appearance.Options.UseBackColor = true;
            this.edtErbDienst.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErbDienst.Properties.Appearance.Options.UseFont = true;
            this.edtErbDienst.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtErbDienst.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtErbDienst.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtErbDienst.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtErbDienst.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtErbDienst.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtErbDienst.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtErbDienst.Properties.NullText = "";
            this.edtErbDienst.Properties.ShowFooter = false;
            this.edtErbDienst.Properties.ShowHeader = false;
            this.edtErbDienst.Size = new System.Drawing.Size(250, 24);
            this.edtErbDienst.TabIndex = 50;
            // 
            // lblThemen
            // 
            this.lblThemen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblThemen.Location = new System.Drawing.Point(445, 343);
            this.lblThemen.Name = "lblThemen";
            this.lblThemen.Size = new System.Drawing.Size(49, 24);
            this.lblThemen.TabIndex = 66;
            this.lblThemen.Text = "Themen";
            this.lblThemen.UseCompatibleTextRendering = true;
            // 
            // chkThemenFilter
            // 
            this.chkThemenFilter.EditValue = false;
            this.chkThemenFilter.Location = new System.Drawing.Point(403, 40);
            this.chkThemenFilter.Name = "chkThemenFilter";
            this.chkThemenFilter.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkThemenFilter.Properties.Appearance.Options.UseBackColor = true;
            this.chkThemenFilter.Properties.Caption = "Themen filtern (ein/aus)";
            this.chkThemenFilter.Size = new System.Drawing.Size(144, 19);
            this.chkThemenFilter.TabIndex = 24;
            this.chkThemenFilter.CheckedChanged += new System.EventHandler(this.chkThemenFilter_CheckedChanged);
            // 
            // ctlLogischLoeschen
            // 
            this.ctlLogischLoeschen.ActiveSQLQuery = this.qryFaDokumente;
            this.ctlLogischLoeschen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlLogischLoeschen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlLogischLoeschen.Location = new System.Drawing.Point(0, 687);
            this.ctlLogischLoeschen.Name = "ctlLogischLoeschen";
            this.ctlLogischLoeschen.Size = new System.Drawing.Size(767, 58);
            this.ctlLogischLoeschen.TabIndex = 58;
            this.ctlLogischLoeschen.RestoreClick += new System.EventHandler(this.btnRestoreDocument_Click);
            // 
            // lblMerkblaetter
            // 
            this.lblMerkblaetter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMerkblaetter.Location = new System.Drawing.Point(3, 588);
            this.lblMerkblaetter.Name = "lblMerkblaetter";
            this.lblMerkblaetter.Size = new System.Drawing.Size(85, 24);
            this.lblMerkblaetter.TabIndex = 70;
            this.lblMerkblaetter.Text = "Merkblätter";
            // 
            // edtDocMerkblaetter
            // 
            this.edtDocMerkblaetter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDocMerkblaetter.Context = "FaKorrespondenz";
            this.edtDocMerkblaetter.DataMember = "DocumentID";
            this.edtDocMerkblaetter.DataSource = this.qryFaDokumente;
            this.edtDocMerkblaetter.Location = new System.Drawing.Point(94, 588);
            this.edtDocMerkblaetter.Name = "edtDocMerkblaetter";
            this.edtDocMerkblaetter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDocMerkblaetter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDocMerkblaetter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDocMerkblaetter.Properties.Appearance.Options.UseBackColor = true;
            this.edtDocMerkblaetter.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDocMerkblaetter.Properties.Appearance.Options.UseFont = true;
            this.edtDocMerkblaetter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtDocMerkblaetter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocMerkblaetter.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocMerkblaetter.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocMerkblaetter.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocMerkblaetter.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "Dokument importieren")});
            this.edtDocMerkblaetter.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDocMerkblaetter.Properties.Name = "edtFaDokKorreDokument.Properties";
            this.edtDocMerkblaetter.Properties.ReadOnly = true;
            this.edtDocMerkblaetter.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtDocMerkblaetter.Size = new System.Drawing.Size(121, 24);
            this.edtDocMerkblaetter.TabIndex = 55;
            // 
            // CtlFaDokumente
            // 
            this.ActiveSQLQuery = this.qryFaDokumente;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(750, 400);
            this.Controls.Add(this.edtDocMerkblaetter);
            this.Controls.Add(this.lblDatumErstellung);
            this.Controls.Add(this.lblMerkblaetter);
            this.Controls.Add(this.edtErbDienst);
            this.Controls.Add(this.lblThemen);
            this.Controls.Add(this.edtDauer);
            this.Controls.Add(this.lblErbDienst);
            this.Controls.Add(this.edtThemen);
            this.Controls.Add(this.ctlLogischLoeschen);
            this.Controls.Add(this.lblDauer);
            this.Controls.Add(this.edtThema);
            this.Controls.Add(this.edtBericht);
            this.Controls.Add(this.memBemerkung);
            this.Controls.Add(this.lblThema);
            this.Controls.Add(this.lblBemerkung);
            this.Controls.Add(this.lblAbsender);
            this.Controls.Add(this.pnTitle);
            this.Controls.Add(this.lblAdressat);
            this.Controls.Add(this.lblStichwort);
            this.Controls.Add(this.edtFaDokKorreDokument);
            this.Controls.Add(this.edtStichwort);
            this.Controls.Add(this.edtDatumErstellung);
            this.Controls.Add(this.edtAdressat);
            this.Controls.Add(this.edtAbsender);
            this.Controls.Add(this.lblFaDokKorreDokument);
            this.Location = new System.Drawing.Point(-370, 380);
            this.Name = "CtlFaDokumente";
            this.Size = new System.Drawing.Size(767, 745);
            this.Controls.SetChildIndex(this.lblFaDokKorreDokument, 0);
            this.Controls.SetChildIndex(this.edtAbsender, 0);
            this.Controls.SetChildIndex(this.edtAdressat, 0);
            this.Controls.SetChildIndex(this.edtDatumErstellung, 0);
            this.Controls.SetChildIndex(this.edtStichwort, 0);
            this.Controls.SetChildIndex(this.edtFaDokKorreDokument, 0);
            this.Controls.SetChildIndex(this.lblStichwort, 0);
            this.Controls.SetChildIndex(this.lblAdressat, 0);
            this.Controls.SetChildIndex(this.pnTitle, 0);
            this.Controls.SetChildIndex(this.lblAbsender, 0);
            this.Controls.SetChildIndex(this.lblBemerkung, 0);
            this.Controls.SetChildIndex(this.lblThema, 0);
            this.Controls.SetChildIndex(this.memBemerkung, 0);
            this.Controls.SetChildIndex(this.edtBericht, 0);
            this.Controls.SetChildIndex(this.edtThema, 0);
            this.Controls.SetChildIndex(this.lblDauer, 0);
            this.Controls.SetChildIndex(this.ctlLogischLoeschen, 0);
            this.Controls.SetChildIndex(this.edtThemen, 0);
            this.Controls.SetChildIndex(this.lblErbDienst, 0);
            this.Controls.SetChildIndex(this.edtDauer, 0);
            this.Controls.SetChildIndex(this.lblThemen, 0);
            this.Controls.SetChildIndex(this.edtErbDienst, 0);
            this.Controls.SetChildIndex(this.lblMerkblaetter, 0);
            this.Controls.SetChildIndex(this.lblDatumErstellung, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.edtDocMerkblaetter, 0);
            ((System.ComponentModel.ISupportInitialize)(this.radGrpDeleted.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGrpDeleted)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            this.pnTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDokumente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaDokumente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwDokumente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheAbsender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheAdressat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheStichworte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokKorreSucheDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokKorreSucheDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokKorreSucheAbsender.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokKorreSucheAddressat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokKorreSucheStichwort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchThema)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchThema.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchThema)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumErstellung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaDokKorreDokument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbsender.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdressat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumErstellung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichwort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokKorreDokument.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichwort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdressat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbsender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBericht.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblThema)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtThema.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtThema)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtThemen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupThemen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDauer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErbDienst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDauer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDauer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErbDienst.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErbDienst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblThemen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkThemenFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMerkblaetter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDocMerkblaetter.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissCheckEdit chkThemenFilter;
        private DevExpress.XtraGrid.Columns.GridColumn colAbsender;
        private DevExpress.XtraGrid.Columns.GridColumn colAdressat;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colIsDeleted;
        private DevExpress.XtraGrid.Columns.GridColumn colPendenzDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colPendenzMitarbeiter;
        private DevExpress.XtraGrid.Columns.GridColumn colPendenzStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colPendenzText;
        private DevExpress.XtraGrid.Columns.GridColumn colStichworte;
        private DevExpress.XtraGrid.Columns.GridColumn colThemen;
        private System.ComponentModel.IContainer components;
        private KiSS4.Common.CtlLogischesLoeschen ctlLogischLoeschen;
        private KiSS4.Common.KissMitarbeiterButtonEdit edtAbsender;
        private KiSS4.Common.KissAdressatButtonEdit edtAdressat;
        private KiSS4.Gui.KissCheckEdit edtBericht;
        private KiSS4.Gui.KissDateEdit edtDatumErstellung;
        private KiSS4.Gui.KissLookUpEdit edtDauer;
        private Dokument.XDokument edtDocMerkblaetter;
        private KiSS4.Gui.KissLookUpEdit edtErbDienst;
        private KiSS4.Dokument.XDokument edtFaDokKorreDokument;
        private KiSS4.Gui.KissTextEdit edtFaDokKorreSucheAbsender;
        private KiSS4.Gui.KissTextEdit edtFaDokKorreSucheAddressat;
        private KiSS4.Gui.KissDateEdit edtFaDokKorreSucheDatumBis;
        private KiSS4.Gui.KissDateEdit edtFaDokKorreSucheDatumVon;
        private KiSS4.Gui.KissTextEdit edtFaDokKorreSucheStichwort;
        private KiSS4.Gui.KissTextEdit edtStichwort;
        private KiSS4.Gui.KissLookUpEdit edtSuchThema;
        private KiSS4.Gui.KissLookUpEdit edtThema;
        private KiSS4.Gui.KissCheckedLookupEdit edtThemen;
        private KiSS4.Gui.KissGrid grdDokumente;
        private DevExpress.XtraGrid.Views.Grid.GridView gvwDokumente;
        private System.Windows.Forms.PictureBox imageTitle;
        private KiSS4.Gui.KissLabel lblAbsender;
        private KiSS4.Gui.KissLabel lblAdressat;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblDatumErstellung;
        private KiSS4.Gui.KissLabel lblDauer;
        private KiSS4.Gui.KissLabel lblErbDienst;
        private KiSS4.Gui.KissLabel lblFaDokKorreDokument;
        private KiSS4.Gui.KissLabel lblMerkblaetter;
        private KiSS4.Gui.KissLabel lblStichwort;
        private KiSS4.Gui.KissLabel lblSuchThema;
        private KiSS4.Gui.KissLabel lblSucheAbsender;
        private KiSS4.Gui.KissLabel lblSucheAdressat;
        private KiSS4.Gui.KissLabel lblSucheBis;
        private KiSS4.Gui.KissLabel lblSucheDatumVon;
        private KiSS4.Gui.KissLabel lblSucheStichworte;
        private KiSS4.Gui.KissLabel lblThema;
        private KiSS4.Gui.KissLabel lblThemen;
        private KiSS4.Gui.KissLabel lblTitle;
        private KiSS4.Gui.KissCheckedLookupEdit lookupThemen;
        private KiSS4.Gui.KissMemoEdit memBemerkung;
        private System.Windows.Forms.Panel pnTitle;
        private KiSS4.DB.SqlQuery qryFaDokumente;
        private DevExpress.XtraGrid.Columns.GridColumn colDienst;
    }
}
