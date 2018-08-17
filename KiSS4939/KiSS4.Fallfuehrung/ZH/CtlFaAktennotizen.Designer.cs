namespace KiSS4.Fallfuehrung.ZH
{
    partial class CtlFaAktennotizen
    {
        private System.ComponentModel.IContainer components;

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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFaAktennotizen));
            this.grdBesprechungen = new KiSS4.Gui.KissGrid();
            this.qryFaAktennotiz = new KiSS4.DB.SqlQuery(this.components);
            this.grvBesprechungen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaGespraechsStatusCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaGespraechstypCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStichworte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKontaktpartner = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAutor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrgUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaAktennotizID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.edtSucheDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtSucheDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtSucheGespraechsStatus = new KiSS4.Gui.KissLookUpEdit();
            this.kissLabel5 = new KiSS4.Gui.KissLabel();
            this.edtSucheStichworte = new KiSS4.Gui.KissTextEdit();
            this.edtSucheInhalt = new KiSS4.Gui.KissTextEdit();
            this.edtSucheGespraechstyp = new KiSS4.Gui.KissLookUpEdit();
            this.edtSucheOrgUnitID = new KiSS4.Gui.KissButtonEdit();
            this.edtSucheUserID = new KiSS4.Gui.KissButtonEdit();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.lblSucheGespraechsStatus = new KiSS4.Gui.KissLabel();
            this.kissLabel7 = new KiSS4.Gui.KissLabel();
            this.lbledtSucheStichwort = new KiSS4.Gui.KissLabel();
            this.lblSucheInhalt = new KiSS4.Gui.KissLabel();
            this.kissLabel10 = new KiSS4.Gui.KissLabel();
            this.kissLabel12 = new KiSS4.Gui.KissLabel();
            this.lblSucheKontaktpartner = new KiSS4.Gui.KissLabel();
            this.edtSucheKontaktpartner = new KiSS4.Gui.KissTextEdit();
            this.edtFaDokBesprDatum = new KiSS4.Gui.KissDateEdit();
            this.edtZeit = new KiSS4.Gui.KissTimeEdit();
            this.lblKontaktpartner = new KiSS4.Gui.KissLabel();
            this.edtFaGespraechsStatusCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtAutor = new KiSS4.Gui.KissButtonEdit();
            this.edtFaGespraechstypCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtFaDauerCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblDatum = new KiSS4.Gui.KissLabel();
            this.edtKontaktpartner = new KiSS4.Gui.KissTextEdit();
            this.edtStichwort = new KiSS4.Gui.KissTextEdit();
            this.edtInhaltRTF = new KiSS4.Gui.KissRTFEdit();
            this.btnDokument = new KiSS4.Dokument.KissDocumentButton();
            this.lblStichwort = new KiSS4.Gui.KissLabel();
            this.lblAutor = new KiSS4.Gui.KissLabel();
            this.lblInhaltRTF = new KiSS4.Gui.KissLabel();
            this.lblFaGespraechsStatusCode = new KiSS4.Gui.KissLabel();
            this.lblZeit = new KiSS4.Gui.KissLabel();
            this.lblFaGespraechstypCode = new KiSS4.Gui.KissLabel();
            this.lblFaDauerCode = new KiSS4.Gui.KissLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.lblErfassung = new KiSS4.Gui.KissLabel();
            this.lblErfassungBenutzerDatum = new KiSS4.Gui.KissLabel();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBesprechungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaAktennotiz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBesprechungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGespraechsStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGespraechsStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheStichworte.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheInhalt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGespraechstyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGespraechstyp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheOrgUnitID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGespraechsStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbledtSucheStichwort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheInhalt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKontaktpartner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKontaktpartner.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokBesprDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZeit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktpartner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaGespraechsStatusCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaGespraechsStatusCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAutor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaGespraechstypCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaGespraechstypCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDauerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDauerCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktpartner.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichwort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichwort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAutor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInhaltRTF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaGespraechsStatusCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaGespraechstypCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaDauerCode)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungBenutzerDatum)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(685, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Location = new System.Drawing.Point(5, 30);
            this.tabControlSearch.Size = new System.Drawing.Size(709, 265);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdBesprechungen);
            this.tpgListe.Size = new System.Drawing.Size(697, 227);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtSucheKontaktpartner);
            this.tpgSuchen.Controls.Add(this.lblSucheKontaktpartner);
            this.tpgSuchen.Controls.Add(this.kissLabel12);
            this.tpgSuchen.Controls.Add(this.kissLabel10);
            this.tpgSuchen.Controls.Add(this.lblSucheInhalt);
            this.tpgSuchen.Controls.Add(this.lbledtSucheStichwort);
            this.tpgSuchen.Controls.Add(this.kissLabel7);
            this.tpgSuchen.Controls.Add(this.lblSucheGespraechsStatus);
            this.tpgSuchen.Controls.Add(this.kissLabel4);
            this.tpgSuchen.Controls.Add(this.edtSucheUserID);
            this.tpgSuchen.Controls.Add(this.edtSucheOrgUnitID);
            this.tpgSuchen.Controls.Add(this.edtSucheGespraechstyp);
            this.tpgSuchen.Controls.Add(this.edtSucheInhalt);
            this.tpgSuchen.Controls.Add(this.edtSucheStichworte);
            this.tpgSuchen.Controls.Add(this.kissLabel5);
            this.tpgSuchen.Controls.Add(this.edtSucheGespraechsStatus);
            this.tpgSuchen.Controls.Add(this.edtSucheDatumBis);
            this.tpgSuchen.Controls.Add(this.edtSucheDatumVon);
            this.tpgSuchen.Size = new System.Drawing.Size(697, 227);
            this.tpgSuchen.Title = "Suchen";
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheGespraechsStatus, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel5, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheStichworte, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheInhalt, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheGespraechstyp, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheOrgUnitID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheUserID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel4, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheGespraechsStatus, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel7, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lbledtSucheStichwort, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheInhalt, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel10, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel12, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheKontaktpartner, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheKontaktpartner, 0);
            // 
            // grdBesprechungen
            // 
            this.grdBesprechungen.DataSource = this.qryFaAktennotiz;
            this.grdBesprechungen.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdBesprechungen.EmbeddedNavigator.Name = "gridCtlKiSS3UserMask_Fa_Dok_Besprechungen.EmbeddedNavigator";
            this.grdBesprechungen.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBesprechungen.Location = new System.Drawing.Point(0, 0);
            this.grdBesprechungen.MainView = this.grvBesprechungen;
            this.grdBesprechungen.Name = "grdBesprechungen";
            this.grdBesprechungen.Size = new System.Drawing.Size(697, 227);
            this.grdBesprechungen.TabIndex = 0;
            this.grdBesprechungen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBesprechungen,
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
            this.qryFaAktennotiz.AfterFill += new System.EventHandler(this.qryFaAktennotiz_AfterFill);
            this.qryFaAktennotiz.AfterInsert += new System.EventHandler(this.qryFaAktennotiz_AfterInsert);
            this.qryFaAktennotiz.BeforePost += new System.EventHandler(this.qryFaAktennotiz_BeforePost);
            this.qryFaAktennotiz.PositionChanged += new System.EventHandler(this.qryFaAktennotiz_PositionChanged);
            // 
            // grvBesprechungen
            // 
            this.grvBesprechungen.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBesprechungen.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBesprechungen.Appearance.Empty.Options.UseBackColor = true;
            this.grvBesprechungen.Appearance.Empty.Options.UseFont = true;
            this.grvBesprechungen.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBesprechungen.Appearance.EvenRow.Options.UseFont = true;
            this.grvBesprechungen.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBesprechungen.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBesprechungen.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBesprechungen.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBesprechungen.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBesprechungen.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBesprechungen.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBesprechungen.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBesprechungen.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBesprechungen.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBesprechungen.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBesprechungen.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBesprechungen.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBesprechungen.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBesprechungen.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvBesprechungen.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvBesprechungen.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBesprechungen.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBesprechungen.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBesprechungen.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBesprechungen.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBesprechungen.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBesprechungen.Appearance.GroupRow.Options.UseFont = true;
            this.grvBesprechungen.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBesprechungen.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBesprechungen.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBesprechungen.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBesprechungen.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBesprechungen.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBesprechungen.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBesprechungen.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBesprechungen.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBesprechungen.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBesprechungen.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBesprechungen.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBesprechungen.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBesprechungen.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBesprechungen.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBesprechungen.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBesprechungen.Appearance.OddRow.Options.UseFont = true;
            this.grvBesprechungen.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBesprechungen.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBesprechungen.Appearance.Row.Options.UseBackColor = true;
            this.grvBesprechungen.Appearance.Row.Options.UseFont = true;
            this.grvBesprechungen.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBesprechungen.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBesprechungen.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBesprechungen.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBesprechungen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBesprechungen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatum,
            this.colFaGespraechsStatusCode,
            this.colFaGespraechstypCode,
            this.colStichworte,
            this.colKontaktpartner,
            this.colAutor,
            this.colOrgUnit,
            this.colFaAktennotizID});
            this.grvBesprechungen.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBesprechungen.GridControl = this.grdBesprechungen;
            this.grvBesprechungen.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvBesprechungen.Name = "grvBesprechungen";
            this.grvBesprechungen.OptionsBehavior.Editable = false;
            this.grvBesprechungen.OptionsCustomization.AllowFilter = false;
            this.grvBesprechungen.OptionsFilter.AllowFilterEditor = false;
            this.grvBesprechungen.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBesprechungen.OptionsMenu.EnableColumnMenu = false;
            this.grvBesprechungen.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBesprechungen.OptionsNavigation.UseTabKey = false;
            this.grvBesprechungen.OptionsView.ColumnAutoWidth = false;
            this.grvBesprechungen.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBesprechungen.OptionsView.ShowGroupPanel = false;
            this.grvBesprechungen.OptionsView.ShowIndicator = false;
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
            // colFaGespraechsStatusCode
            // 
            this.colFaGespraechsStatusCode.Caption = "Status";
            this.colFaGespraechsStatusCode.FieldName = "FaGespraechsStatusCode";
            this.colFaGespraechsStatusCode.Name = "colFaGespraechsStatusCode";
            this.colFaGespraechsStatusCode.Visible = true;
            this.colFaGespraechsStatusCode.VisibleIndex = 1;
            // 
            // colFaGespraechstypCode
            // 
            this.colFaGespraechstypCode.Caption = "Art";
            this.colFaGespraechstypCode.FieldName = "FaGespraechstypCode";
            this.colFaGespraechstypCode.Name = "colFaGespraechstypCode";
            this.colFaGespraechstypCode.Visible = true;
            this.colFaGespraechstypCode.VisibleIndex = 2;
            this.colFaGespraechstypCode.Width = 61;
            // 
            // colStichworte
            // 
            this.colStichworte.Caption = "Stichworte";
            this.colStichworte.FieldName = "Stichwort";
            this.colStichworte.Name = "colStichworte";
            this.colStichworte.Visible = true;
            this.colStichworte.VisibleIndex = 3;
            this.colStichworte.Width = 175;
            // 
            // colKontaktpartner
            // 
            this.colKontaktpartner.Caption = "Kontaktpartner";
            this.colKontaktpartner.FieldName = "Kontaktpartner";
            this.colKontaktpartner.Name = "colKontaktpartner";
            this.colKontaktpartner.Visible = true;
            this.colKontaktpartner.VisibleIndex = 4;
            this.colKontaktpartner.Width = 107;
            // 
            // colAutor
            // 
            this.colAutor.Caption = "MA";
            this.colAutor.FieldName = "Autor";
            this.colAutor.Name = "colAutor";
            this.colAutor.Visible = true;
            this.colAutor.VisibleIndex = 5;
            this.colAutor.Width = 62;
            // 
            // colOrgUnit
            // 
            this.colOrgUnit.Caption = "Org. Einheit";
            this.colOrgUnit.FieldName = "OrgUnit";
            this.colOrgUnit.Name = "colOrgUnit";
            this.colOrgUnit.Visible = true;
            this.colOrgUnit.VisibleIndex = 6;
            this.colOrgUnit.Width = 110;
            // 
            // colFaAktennotizID
            // 
            this.colFaAktennotizID.Caption = "gridColumn1";
            this.colFaAktennotizID.FieldName = "FaAktennotizID";
            this.colFaAktennotizID.Name = "colFaAktennotizID";
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdBesprechungen;
            this.gridView1.Name = "gridView1";
            // 
            // edtSucheDatumVon
            // 
            this.edtSucheDatumVon.EditValue = null;
            this.edtSucheDatumVon.Location = new System.Drawing.Point(75, 35);
            this.edtSucheDatumVon.Name = "edtSucheDatumVon";
            this.edtSucheDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.edtSucheDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12)});
            this.edtSucheDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheDatumVon.Properties.Name = "kissDateEdit1.Properties";
            this.edtSucheDatumVon.Properties.ShowToday = false;
            this.edtSucheDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtSucheDatumVon.TabIndex = 0;
            // 
            // edtSucheDatumBis
            // 
            this.edtSucheDatumBis.EditValue = null;
            this.edtSucheDatumBis.Location = new System.Drawing.Point(232, 35);
            this.edtSucheDatumBis.Name = "edtSucheDatumBis";
            this.edtSucheDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.edtSucheDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.edtSucheDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheDatumBis.Properties.Name = "kissDateEdit2.Properties";
            this.edtSucheDatumBis.Properties.ShowToday = false;
            this.edtSucheDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtSucheDatumBis.TabIndex = 1;
            // 
            // edtSucheGespraechsStatus
            // 
            this.edtSucheGespraechsStatus.Location = new System.Drawing.Point(75, 65);
            this.edtSucheGespraechsStatus.LOVName = "FaGespraechsStatus";
            this.edtSucheGespraechsStatus.Name = "edtSucheGespraechsStatus";
            this.edtSucheGespraechsStatus.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheGespraechsStatus.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheGespraechsStatus.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheGespraechsStatus.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheGespraechsStatus.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheGespraechsStatus.Properties.Appearance.Options.UseFont = true;
            this.edtSucheGespraechsStatus.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheGespraechsStatus.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheGespraechsStatus.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheGespraechsStatus.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheGespraechsStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.edtSucheGespraechsStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.edtSucheGespraechsStatus.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheGespraechsStatus.Properties.Name = "kissLookUpEdit2.Properties";
            this.edtSucheGespraechsStatus.Properties.NullText = "";
            this.edtSucheGespraechsStatus.Properties.ShowFooter = false;
            this.edtSucheGespraechsStatus.Properties.ShowHeader = false;
            this.edtSucheGespraechsStatus.Size = new System.Drawing.Size(257, 24);
            this.edtSucheGespraechsStatus.TabIndex = 2;
            // 
            // kissLabel5
            // 
            this.kissLabel5.Location = new System.Drawing.Point(196, 35);
            this.kissLabel5.Name = "kissLabel5";
            this.kissLabel5.Size = new System.Drawing.Size(30, 24);
            this.kissLabel5.TabIndex = 2;
            this.kissLabel5.Text = "bis";
            this.kissLabel5.UseCompatibleTextRendering = true;
            // 
            // edtSucheStichworte
            // 
            this.edtSucheStichworte.Location = new System.Drawing.Point(75, 95);
            this.edtSucheStichworte.Name = "edtSucheStichworte";
            this.edtSucheStichworte.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheStichworte.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheStichworte.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheStichworte.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheStichworte.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheStichworte.Properties.Appearance.Options.UseFont = true;
            this.edtSucheStichworte.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheStichworte.Properties.Name = "kissTextEdit1.Properties";
            this.edtSucheStichworte.Size = new System.Drawing.Size(257, 24);
            this.edtSucheStichworte.TabIndex = 3;
            // 
            // edtSucheInhalt
            // 
            this.edtSucheInhalt.Location = new System.Drawing.Point(75, 125);
            this.edtSucheInhalt.Name = "edtSucheInhalt";
            this.edtSucheInhalt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheInhalt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheInhalt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheInhalt.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheInhalt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheInhalt.Properties.Appearance.Options.UseFont = true;
            this.edtSucheInhalt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheInhalt.Properties.Name = "kissTextEdit2.Properties";
            this.edtSucheInhalt.Size = new System.Drawing.Size(257, 24);
            this.edtSucheInhalt.TabIndex = 4;
            // 
            // edtSucheGespraechstyp
            // 
            this.edtSucheGespraechstyp.Location = new System.Drawing.Point(429, 35);
            this.edtSucheGespraechstyp.LOVFilter = "F";
            this.edtSucheGespraechstyp.LOVName = "FaGespraechstyp";
            this.edtSucheGespraechstyp.Name = "edtSucheGespraechstyp";
            this.edtSucheGespraechstyp.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheGespraechstyp.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheGespraechstyp.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheGespraechstyp.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheGespraechstyp.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheGespraechstyp.Properties.Appearance.Options.UseFont = true;
            this.edtSucheGespraechstyp.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheGespraechstyp.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheGespraechstyp.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheGespraechstyp.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheGespraechstyp.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtSucheGespraechstyp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtSucheGespraechstyp.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheGespraechstyp.Properties.Name = "kissLookUpEdit2.Properties";
            this.edtSucheGespraechstyp.Properties.NullText = "";
            this.edtSucheGespraechstyp.Properties.ShowFooter = false;
            this.edtSucheGespraechstyp.Properties.ShowHeader = false;
            this.edtSucheGespraechstyp.Size = new System.Drawing.Size(257, 24);
            this.edtSucheGespraechstyp.TabIndex = 5;
            // 
            // edtSucheOrgUnitID
            // 
            this.edtSucheOrgUnitID.Location = new System.Drawing.Point(429, 65);
            this.edtSucheOrgUnitID.Name = "edtSucheOrgUnitID";
            this.edtSucheOrgUnitID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheOrgUnitID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheOrgUnitID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheOrgUnitID.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheOrgUnitID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheOrgUnitID.Properties.Appearance.Options.UseFont = true;
            this.edtSucheOrgUnitID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtSucheOrgUnitID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtSucheOrgUnitID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheOrgUnitID.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtSucheOrgUnitID.Size = new System.Drawing.Size(257, 24);
            this.edtSucheOrgUnitID.TabIndex = 6;
            this.edtSucheOrgUnitID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSucheOrgUnitID_UserModifiedFld);
            // 
            // edtSucheUserID
            // 
            this.edtSucheUserID.Location = new System.Drawing.Point(429, 95);
            this.edtSucheUserID.Name = "edtSucheUserID";
            this.edtSucheUserID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheUserID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheUserID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheUserID.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheUserID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheUserID.Properties.Appearance.Options.UseFont = true;
            this.edtSucheUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtSucheUserID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtSucheUserID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheUserID.Properties.Name = "kissButtonEdit1.Properties";
            this.edtSucheUserID.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtSucheUserID.Size = new System.Drawing.Size(257, 24);
            this.edtSucheUserID.TabIndex = 7;
            this.edtSucheUserID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSucheUserID_UserModifiedFld);
            // 
            // kissLabel4
            // 
            this.kissLabel4.Location = new System.Drawing.Point(3, 35);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(60, 24);
            this.kissLabel4.TabIndex = 10;
            this.kissLabel4.Text = "Datum von";
            this.kissLabel4.UseCompatibleTextRendering = true;
            // 
            // lblSucheGespraechsStatus
            // 
            this.lblSucheGespraechsStatus.Location = new System.Drawing.Point(3, 65);
            this.lblSucheGespraechsStatus.Name = "lblSucheGespraechsStatus";
            this.lblSucheGespraechsStatus.Size = new System.Drawing.Size(71, 24);
            this.lblSucheGespraechsStatus.TabIndex = 15;
            this.lblSucheGespraechsStatus.Text = "Status";
            this.lblSucheGespraechsStatus.UseCompatibleTextRendering = true;
            // 
            // kissLabel7
            // 
            this.kissLabel7.Location = new System.Drawing.Point(349, 95);
            this.kissLabel7.Name = "kissLabel7";
            this.kissLabel7.Size = new System.Drawing.Size(70, 24);
            this.kissLabel7.TabIndex = 17;
            this.kissLabel7.Text = "Mitarbeiter/in";
            this.kissLabel7.UseCompatibleTextRendering = true;
            // 
            // lbledtSucheStichwort
            // 
            this.lbledtSucheStichwort.Location = new System.Drawing.Point(3, 95);
            this.lbledtSucheStichwort.Name = "lbledtSucheStichwort";
            this.lbledtSucheStichwort.Size = new System.Drawing.Size(70, 24);
            this.lbledtSucheStichwort.TabIndex = 19;
            this.lbledtSucheStichwort.Text = "Stichworte";
            this.lbledtSucheStichwort.UseCompatibleTextRendering = true;
            // 
            // lblSucheInhalt
            // 
            this.lblSucheInhalt.Location = new System.Drawing.Point(3, 125);
            this.lblSucheInhalt.Name = "lblSucheInhalt";
            this.lblSucheInhalt.Size = new System.Drawing.Size(70, 24);
            this.lblSucheInhalt.TabIndex = 20;
            this.lblSucheInhalt.Text = "Inhalt";
            this.lblSucheInhalt.UseCompatibleTextRendering = true;
            // 
            // kissLabel10
            // 
            this.kissLabel10.Location = new System.Drawing.Point(349, 65);
            this.kissLabel10.Name = "kissLabel10";
            this.kissLabel10.Size = new System.Drawing.Size(63, 24);
            this.kissLabel10.TabIndex = 21;
            this.kissLabel10.Text = "Org.einheit";
            this.kissLabel10.UseCompatibleTextRendering = true;
            // 
            // kissLabel12
            // 
            this.kissLabel12.Location = new System.Drawing.Point(349, 35);
            this.kissLabel12.Name = "kissLabel12";
            this.kissLabel12.Size = new System.Drawing.Size(71, 24);
            this.kissLabel12.TabIndex = 49;
            this.kissLabel12.Text = "Gesprächstyp";
            this.kissLabel12.UseCompatibleTextRendering = true;
            // 
            // lblSucheKontaktpartner
            // 
            this.lblSucheKontaktpartner.Location = new System.Drawing.Point(349, 124);
            this.lblSucheKontaktpartner.Name = "lblSucheKontaktpartner";
            this.lblSucheKontaktpartner.Size = new System.Drawing.Size(80, 24);
            this.lblSucheKontaktpartner.TabIndex = 50;
            this.lblSucheKontaktpartner.Text = "Kontaktpartner";
            this.lblSucheKontaktpartner.UseCompatibleTextRendering = true;
            // 
            // edtSucheKontaktpartner
            // 
            this.edtSucheKontaktpartner.Location = new System.Drawing.Point(429, 124);
            this.edtSucheKontaktpartner.Name = "edtSucheKontaktpartner";
            this.edtSucheKontaktpartner.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheKontaktpartner.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheKontaktpartner.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheKontaktpartner.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheKontaktpartner.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheKontaktpartner.Properties.Appearance.Options.UseFont = true;
            this.edtSucheKontaktpartner.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheKontaktpartner.Size = new System.Drawing.Size(257, 24);
            this.edtSucheKontaktpartner.TabIndex = 51;
            // 
            // edtFaDokBesprDatum
            // 
            this.edtFaDokBesprDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtFaDokBesprDatum.DataMember = "Datum";
            this.edtFaDokBesprDatum.DataSource = this.qryFaAktennotiz;
            this.edtFaDokBesprDatum.EditValue = ((object)(resources.GetObject("edtFaDokBesprDatum.EditValue")));
            this.edtFaDokBesprDatum.Location = new System.Drawing.Point(85, 301);
            this.edtFaDokBesprDatum.Name = "edtFaDokBesprDatum";
            this.edtFaDokBesprDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtFaDokBesprDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFaDokBesprDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaDokBesprDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaDokBesprDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaDokBesprDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaDokBesprDatum.Properties.Appearance.Options.UseFont = true;
            this.edtFaDokBesprDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtFaDokBesprDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtFaDokBesprDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtFaDokBesprDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFaDokBesprDatum.Properties.Name = "edtFaDokBesprDatum.Properties";
            this.edtFaDokBesprDatum.Properties.ShowToday = false;
            this.edtFaDokBesprDatum.Size = new System.Drawing.Size(90, 24);
            this.edtFaDokBesprDatum.TabIndex = 1;
            // 
            // edtZeit
            // 
            this.edtZeit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtZeit.DataMember = "Zeit";
            this.edtZeit.DataSource = this.qryFaAktennotiz;
            this.edtZeit.EditValue = ((object)(resources.GetObject("edtZeit.EditValue")));
            this.edtZeit.Location = new System.Drawing.Point(216, 301);
            this.edtZeit.Name = "edtZeit";
            this.edtZeit.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZeit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZeit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZeit.Properties.Appearance.Options.UseBackColor = true;
            this.edtZeit.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZeit.Properties.Appearance.Options.UseFont = true;
            this.edtZeit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtZeit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtZeit.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZeit.Properties.DisplayFormat.FormatString = "t";
            this.edtZeit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtZeit.Properties.EditFormat.FormatString = "t";
            this.edtZeit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtZeit.Properties.Mask.EditMask = "t";
            this.edtZeit.Properties.Name = "kissTimeEdit1.Properties";
            this.edtZeit.Size = new System.Drawing.Size(90, 24);
            this.edtZeit.TabIndex = 2;
            // 
            // lblKontaktpartner
            // 
            this.lblKontaktpartner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblKontaktpartner.Location = new System.Drawing.Point(319, 361);
            this.lblKontaktpartner.Name = "lblKontaktpartner";
            this.lblKontaktpartner.Size = new System.Drawing.Size(87, 24);
            this.lblKontaktpartner.TabIndex = 2;
            this.lblKontaktpartner.Text = "Kontaktpartner";
            this.lblKontaktpartner.UseCompatibleTextRendering = true;
            // 
            // edtFaGespraechsStatusCode
            // 
            this.edtFaGespraechsStatusCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtFaGespraechsStatusCode.DataMember = "FaGespraechsStatusCode";
            this.edtFaGespraechsStatusCode.DataSource = this.qryFaAktennotiz;
            this.edtFaGespraechsStatusCode.Location = new System.Drawing.Point(85, 331);
            this.edtFaGespraechsStatusCode.LOVName = "FaGespraechsStatus";
            this.edtFaGespraechsStatusCode.Name = "edtFaGespraechsStatusCode";
            this.edtFaGespraechsStatusCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFaGespraechsStatusCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaGespraechsStatusCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaGespraechsStatusCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaGespraechsStatusCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaGespraechsStatusCode.Properties.Appearance.Options.UseFont = true;
            this.edtFaGespraechsStatusCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtFaGespraechsStatusCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaGespraechsStatusCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtFaGespraechsStatusCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtFaGespraechsStatusCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtFaGespraechsStatusCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtFaGespraechsStatusCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFaGespraechsStatusCode.Properties.Name = "kissLookUpEdit1.Properties";
            this.edtFaGespraechsStatusCode.Properties.NullText = "";
            this.edtFaGespraechsStatusCode.Properties.ShowFooter = false;
            this.edtFaGespraechsStatusCode.Properties.ShowHeader = false;
            this.edtFaGespraechsStatusCode.Size = new System.Drawing.Size(221, 24);
            this.edtFaGespraechsStatusCode.TabIndex = 3;
            // 
            // edtAutor
            // 
            this.edtAutor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAutor.DataMember = "Autor";
            this.edtAutor.DataSource = this.qryFaAktennotiz;
            this.edtAutor.Location = new System.Drawing.Point(85, 361);
            this.edtAutor.Name = "edtAutor";
            this.edtAutor.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAutor.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAutor.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAutor.Properties.Appearance.Options.UseBackColor = true;
            this.edtAutor.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAutor.Properties.Appearance.Options.UseFont = true;
            this.edtAutor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtAutor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtAutor.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAutor.Properties.Name = "edtFaDokBesprAutor.Properties";
            this.edtAutor.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtAutor.Size = new System.Drawing.Size(221, 24);
            this.edtAutor.TabIndex = 4;
            this.edtAutor.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtAutor_UserModifiedFld);
            // 
            // edtFaGespraechstypCode
            // 
            this.edtFaGespraechstypCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtFaGespraechstypCode.DataMember = "FaGespraechstypCode";
            this.edtFaGespraechstypCode.DataSource = this.qryFaAktennotiz;
            this.edtFaGespraechstypCode.Location = new System.Drawing.Point(412, 301);
            this.edtFaGespraechstypCode.LOVFilter = "F";
            this.edtFaGespraechstypCode.LOVName = "FaGespraechstyp";
            this.edtFaGespraechstypCode.Name = "edtFaGespraechstypCode";
            this.edtFaGespraechstypCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFaGespraechstypCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaGespraechstypCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaGespraechstypCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaGespraechstypCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaGespraechstypCode.Properties.Appearance.Options.UseFont = true;
            this.edtFaGespraechstypCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtFaGespraechstypCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaGespraechstypCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtFaGespraechstypCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtFaGespraechstypCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtFaGespraechstypCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtFaGespraechstypCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFaGespraechstypCode.Properties.Name = "kissLookUpEdit3.Properties";
            this.edtFaGespraechstypCode.Properties.NullText = "";
            this.edtFaGespraechstypCode.Properties.ShowFooter = false;
            this.edtFaGespraechstypCode.Properties.ShowHeader = false;
            this.edtFaGespraechstypCode.Size = new System.Drawing.Size(302, 24);
            this.edtFaGespraechstypCode.TabIndex = 5;
            // 
            // edtFaDauerCode
            // 
            this.edtFaDauerCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtFaDauerCode.DataMember = "FaDauerCode";
            this.edtFaDauerCode.DataSource = this.qryFaAktennotiz;
            this.edtFaDauerCode.Location = new System.Drawing.Point(412, 331);
            this.edtFaDauerCode.LOVName = "FaDauer";
            this.edtFaDauerCode.Name = "edtFaDauerCode";
            this.edtFaDauerCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFaDauerCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaDauerCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaDauerCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaDauerCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaDauerCode.Properties.Appearance.Options.UseFont = true;
            this.edtFaDauerCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtFaDauerCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaDauerCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtFaDauerCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtFaDauerCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtFaDauerCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtFaDauerCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFaDauerCode.Properties.Name = "kissLookUpEdit3.Properties";
            this.edtFaDauerCode.Properties.NullText = "";
            this.edtFaDauerCode.Properties.ShowFooter = false;
            this.edtFaDauerCode.Properties.ShowHeader = false;
            this.edtFaDauerCode.Size = new System.Drawing.Size(302, 24);
            this.edtFaDauerCode.TabIndex = 6;
            // 
            // lblDatum
            // 
            this.lblDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDatum.Location = new System.Drawing.Point(5, 301);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(74, 24);
            this.lblDatum.TabIndex = 6;
            this.lblDatum.Text = "Datum";
            this.lblDatum.UseCompatibleTextRendering = true;
            // 
            // edtKontaktpartner
            // 
            this.edtKontaktpartner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtKontaktpartner.DataMember = "Kontaktpartner";
            this.edtKontaktpartner.DataSource = this.qryFaAktennotiz;
            this.edtKontaktpartner.Location = new System.Drawing.Point(412, 361);
            this.edtKontaktpartner.Name = "edtKontaktpartner";
            this.edtKontaktpartner.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontaktpartner.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktpartner.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktpartner.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktpartner.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktpartner.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktpartner.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontaktpartner.Properties.MaxLength = 40;
            this.edtKontaktpartner.Properties.Name = "edtFaDokBesprKontakPart.Properties";
            this.edtKontaktpartner.Size = new System.Drawing.Size(302, 24);
            this.edtKontaktpartner.TabIndex = 7;
            // 
            // edtStichwort
            // 
            this.edtStichwort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtStichwort.DataMember = "Stichwort";
            this.edtStichwort.DataSource = this.qryFaAktennotiz;
            this.edtStichwort.Location = new System.Drawing.Point(85, 391);
            this.edtStichwort.Name = "edtStichwort";
            this.edtStichwort.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStichwort.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStichwort.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStichwort.Properties.Appearance.Options.UseBackColor = true;
            this.edtStichwort.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStichwort.Properties.Appearance.Options.UseFont = true;
            this.edtStichwort.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStichwort.Properties.MaxLength = 80;
            this.edtStichwort.Properties.Name = "edtFaDokBesprStichwort.Properties";
            this.edtStichwort.Size = new System.Drawing.Size(629, 24);
            this.edtStichwort.TabIndex = 8;
            // 
            // edtInhaltRTF
            // 
            this.edtInhaltRTF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtInhaltRTF.BackColor = System.Drawing.Color.White;
            this.edtInhaltRTF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edtInhaltRTF.DataMember = "InhaltRTF";
            this.edtInhaltRTF.DataSource = this.qryFaAktennotiz;
            this.edtInhaltRTF.Font = new System.Drawing.Font("Arial", 10F);
            this.edtInhaltRTF.Location = new System.Drawing.Point(85, 421);
            this.edtInhaltRTF.Name = "edtInhaltRTF";
            this.edtInhaltRTF.Size = new System.Drawing.Size(629, 156);
            this.edtInhaltRTF.TabIndex = 9;
            // 
            // btnDokument
            // 
            this.btnDokument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDokument.Context = "FaAktennotizen";
            this.btnDokument.DocumentFormat = KiSS4.Dokument.DlgNewDocument.DocumentAccessModes.All;
            this.btnDokument.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDokument.Image = ((System.Drawing.Image)(resources.GetObject("btnDokument.Image")));
            this.btnDokument.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDokument.Location = new System.Drawing.Point(622, 581);
            this.btnDokument.Name = "btnDokument";
            this.btnDokument.Size = new System.Drawing.Size(92, 24);
            this.btnDokument.TabIndex = 10;
            this.btnDokument.Text = "Dokument";
            this.btnDokument.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDokument.UseCompatibleTextRendering = true;
            this.btnDokument.UseVisualStyleBackColor = false;
            // 
            // lblStichwort
            // 
            this.lblStichwort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStichwort.Location = new System.Drawing.Point(5, 391);
            this.lblStichwort.Name = "lblStichwort";
            this.lblStichwort.Size = new System.Drawing.Size(74, 24);
            this.lblStichwort.TabIndex = 10;
            this.lblStichwort.Text = "Stichworte";
            this.lblStichwort.UseCompatibleTextRendering = true;
            // 
            // lblAutor
            // 
            this.lblAutor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAutor.Location = new System.Drawing.Point(5, 361);
            this.lblAutor.Name = "lblAutor";
            this.lblAutor.Size = new System.Drawing.Size(74, 24);
            this.lblAutor.TabIndex = 11;
            this.lblAutor.Text = "Mitarbeiter/in";
            this.lblAutor.UseCompatibleTextRendering = true;
            // 
            // lblInhaltRTF
            // 
            this.lblInhaltRTF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInhaltRTF.Location = new System.Drawing.Point(5, 421);
            this.lblInhaltRTF.Name = "lblInhaltRTF";
            this.lblInhaltRTF.Size = new System.Drawing.Size(74, 24);
            this.lblInhaltRTF.TabIndex = 12;
            this.lblInhaltRTF.Text = "Inhalt";
            this.lblInhaltRTF.UseCompatibleTextRendering = true;
            // 
            // lblFaGespraechsStatusCode
            // 
            this.lblFaGespraechsStatusCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFaGespraechsStatusCode.Location = new System.Drawing.Point(5, 331);
            this.lblFaGespraechsStatusCode.Name = "lblFaGespraechsStatusCode";
            this.lblFaGespraechsStatusCode.Size = new System.Drawing.Size(74, 24);
            this.lblFaGespraechsStatusCode.TabIndex = 41;
            this.lblFaGespraechsStatusCode.Text = "Status";
            this.lblFaGespraechsStatusCode.UseCompatibleTextRendering = true;
            // 
            // lblZeit
            // 
            this.lblZeit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblZeit.Location = new System.Drawing.Point(184, 301);
            this.lblZeit.Name = "lblZeit";
            this.lblZeit.Size = new System.Drawing.Size(26, 24);
            this.lblZeit.TabIndex = 51;
            this.lblZeit.Text = "Zeit";
            this.lblZeit.UseCompatibleTextRendering = true;
            // 
            // lblFaGespraechstypCode
            // 
            this.lblFaGespraechstypCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFaGespraechstypCode.Location = new System.Drawing.Point(319, 301);
            this.lblFaGespraechstypCode.Name = "lblFaGespraechstypCode";
            this.lblFaGespraechstypCode.Size = new System.Drawing.Size(87, 24);
            this.lblFaGespraechstypCode.TabIndex = 54;
            this.lblFaGespraechstypCode.Text = "Art";
            this.lblFaGespraechstypCode.UseCompatibleTextRendering = true;
            // 
            // lblFaDauerCode
            // 
            this.lblFaDauerCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFaDauerCode.Location = new System.Drawing.Point(319, 331);
            this.lblFaDauerCode.Name = "lblFaDauerCode";
            this.lblFaDauerCode.Size = new System.Drawing.Size(87, 24);
            this.lblFaDauerCode.TabIndex = 55;
            this.lblFaDauerCode.Text = "Dauer";
            this.lblFaDauerCode.UseCompatibleTextRendering = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picTitel);
            this.panel1.Controls.Add(this.lblTitel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(717, 24);
            this.panel1.TabIndex = 114;
            // 
            // picTitel
            // 
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
            this.lblTitel.Text = "Aktennotizen";
            this.lblTitel.UseCompatibleTextRendering = true;
            // 
            // lblErfassung
            // 
            this.lblErfassung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblErfassung.Location = new System.Drawing.Point(5, 581);
            this.lblErfassung.Name = "lblErfassung";
            this.lblErfassung.Size = new System.Drawing.Size(74, 24);
            this.lblErfassung.TabIndex = 12;
            this.lblErfassung.Text = "Erfassung";
            this.lblErfassung.UseCompatibleTextRendering = true;
            // 
            // lblErfassungBenutzerDatum
            // 
            this.lblErfassungBenutzerDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblErfassungBenutzerDatum.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblErfassungBenutzerDatum.Location = new System.Drawing.Point(85, 585);
            this.lblErfassungBenutzerDatum.Name = "lblErfassungBenutzerDatum";
            this.lblErfassungBenutzerDatum.Size = new System.Drawing.Size(531, 16);
            this.lblErfassungBenutzerDatum.TabIndex = 12;
            this.lblErfassungBenutzerDatum.Text = "...";
            this.lblErfassungBenutzerDatum.UseCompatibleTextRendering = true;
            // 
            // CtlFaAktennotizen
            // 
            this.ActiveSQLQuery = this.qryFaAktennotiz;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(699, 460);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblFaDauerCode);
            this.Controls.Add(this.lblFaGespraechstypCode);
            this.Controls.Add(this.lblZeit);
            this.Controls.Add(this.lblFaGespraechsStatusCode);
            this.Controls.Add(this.lblErfassungBenutzerDatum);
            this.Controls.Add(this.lblErfassung);
            this.Controls.Add(this.lblInhaltRTF);
            this.Controls.Add(this.lblAutor);
            this.Controls.Add(this.lblStichwort);
            this.Controls.Add(this.btnDokument);
            this.Controls.Add(this.edtInhaltRTF);
            this.Controls.Add(this.edtStichwort);
            this.Controls.Add(this.edtKontaktpartner);
            this.Controls.Add(this.lblDatum);
            this.Controls.Add(this.edtFaDauerCode);
            this.Controls.Add(this.edtFaGespraechstypCode);
            this.Controls.Add(this.edtAutor);
            this.Controls.Add(this.edtFaGespraechsStatusCode);
            this.Controls.Add(this.lblKontaktpartner);
            this.Controls.Add(this.edtZeit);
            this.Controls.Add(this.edtFaDokBesprDatum);
            this.Name = "CtlFaAktennotizen";
            this.Size = new System.Drawing.Size(717, 610);
            this.Load += new System.EventHandler(this.CtlFaAktennotizen_Load);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.edtFaDokBesprDatum, 0);
            this.Controls.SetChildIndex(this.edtZeit, 0);
            this.Controls.SetChildIndex(this.lblKontaktpartner, 0);
            this.Controls.SetChildIndex(this.edtFaGespraechsStatusCode, 0);
            this.Controls.SetChildIndex(this.edtAutor, 0);
            this.Controls.SetChildIndex(this.edtFaGespraechstypCode, 0);
            this.Controls.SetChildIndex(this.edtFaDauerCode, 0);
            this.Controls.SetChildIndex(this.lblDatum, 0);
            this.Controls.SetChildIndex(this.edtKontaktpartner, 0);
            this.Controls.SetChildIndex(this.edtStichwort, 0);
            this.Controls.SetChildIndex(this.edtInhaltRTF, 0);
            this.Controls.SetChildIndex(this.btnDokument, 0);
            this.Controls.SetChildIndex(this.lblStichwort, 0);
            this.Controls.SetChildIndex(this.lblAutor, 0);
            this.Controls.SetChildIndex(this.lblInhaltRTF, 0);
            this.Controls.SetChildIndex(this.lblErfassung, 0);
            this.Controls.SetChildIndex(this.lblErfassungBenutzerDatum, 0);
            this.Controls.SetChildIndex(this.lblFaGespraechsStatusCode, 0);
            this.Controls.SetChildIndex(this.lblZeit, 0);
            this.Controls.SetChildIndex(this.lblFaGespraechstypCode, 0);
            this.Controls.SetChildIndex(this.lblFaDauerCode, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBesprechungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaAktennotiz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBesprechungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGespraechsStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGespraechsStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheStichworte.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheInhalt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGespraechstyp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGespraechstyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheOrgUnitID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGespraechsStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbledtSucheStichwort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheInhalt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKontaktpartner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKontaktpartner.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokBesprDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZeit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktpartner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaGespraechsStatusCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaGespraechsStatusCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAutor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaGespraechstypCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaGespraechstypCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDauerCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDauerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktpartner.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichwort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichwort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAutor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInhaltRTF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaGespraechsStatusCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaGespraechstypCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaDauerCode)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungBenutzerDatum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Dokument.KissDocumentButton btnDokument;
        private DevExpress.XtraGrid.Columns.GridColumn colAutor;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colFaAktennotizID;
        private DevExpress.XtraGrid.Columns.GridColumn colFaGespraechsStatusCode;
        private DevExpress.XtraGrid.Columns.GridColumn colFaGespraechstypCode;
        private DevExpress.XtraGrid.Columns.GridColumn colKontaktpartner;
        private DevExpress.XtraGrid.Columns.GridColumn colOrgUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colStichworte;
        private KiSS4.Gui.KissButtonEdit edtAutor;
        private KiSS4.Gui.KissLookUpEdit edtFaDauerCode;
        private KiSS4.Gui.KissDateEdit edtFaDokBesprDatum;
        private KiSS4.Gui.KissLookUpEdit edtFaGespraechsStatusCode;
        private KiSS4.Gui.KissLookUpEdit edtFaGespraechstypCode;
        private KiSS4.Gui.KissRTFEdit edtInhaltRTF;
        private KiSS4.Gui.KissTextEdit edtKontaktpartner;
        private KiSS4.Gui.KissTextEdit edtStichwort;
        private KiSS4.Gui.KissDateEdit edtSucheDatumBis;
        private KiSS4.Gui.KissDateEdit edtSucheDatumVon;
        private KiSS4.Gui.KissLookUpEdit edtSucheGespraechsStatus;
        private KiSS4.Gui.KissLookUpEdit edtSucheGespraechstyp;
        private KiSS4.Gui.KissTextEdit edtSucheInhalt;
        private KiSS4.Gui.KissTextEdit edtSucheKontaktpartner;
        private KiSS4.Gui.KissButtonEdit edtSucheOrgUnitID;
        private KiSS4.Gui.KissTextEdit edtSucheStichworte;
        private KiSS4.Gui.KissButtonEdit edtSucheUserID;
        private KiSS4.Gui.KissTimeEdit edtZeit;
        private KiSS4.Gui.KissGrid grdBesprechungen;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBesprechungen;
        private KiSS4.Gui.KissLabel kissLabel10;
        private KiSS4.Gui.KissLabel kissLabel12;
        private KiSS4.Gui.KissLabel kissLabel4;
        private KiSS4.Gui.KissLabel kissLabel5;
        private KiSS4.Gui.KissLabel kissLabel7;
        private KiSS4.Gui.KissLabel lblAutor;
        private KiSS4.Gui.KissLabel lblDatum;
        private KiSS4.Gui.KissLabel lbledtSucheStichwort;
        private KiSS4.Gui.KissLabel lblFaDauerCode;
        private KiSS4.Gui.KissLabel lblFaGespraechsStatusCode;
        private KiSS4.Gui.KissLabel lblFaGespraechstypCode;
        private KiSS4.Gui.KissLabel lblInhaltRTF;
        private KiSS4.Gui.KissLabel lblKontaktpartner;
        private KiSS4.Gui.KissLabel lblStichwort;
        private KiSS4.Gui.KissLabel lblSucheGespraechsStatus;
        private KiSS4.Gui.KissLabel lblSucheInhalt;
        private KiSS4.Gui.KissLabel lblSucheKontaktpartner;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissLabel lblZeit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryFaAktennotiz;
        private Gui.KissLabel lblErfassung;
        private Gui.KissLabel lblErfassungBenutzerDatum;
    }
}
