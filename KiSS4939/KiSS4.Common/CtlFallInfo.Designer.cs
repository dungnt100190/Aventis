namespace KiSS4.Common
{
    partial class CtlFallInfo
    {
        #region Dispose

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFallInfo));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryFaLeistung = new KiSS4.DB.SqlQuery(this.components);
            this.qryFaLeistungArchiv = new KiSS4.DB.SqlQuery(this.components);
            this.treFaLeistung = new KiSS4.Gui.KissTree();
            this.colDatumVon = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colSAR = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colFaFallID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.panRight = new System.Windows.Forms.Panel();
            this.btnOK = new KiSS4.Gui.KissButton();
            this.tabFallinfo = new KiSS4.Gui.KissTabControlEx();
            this.tpgFaLeistung = new SharpLibrary.WinControls.TabPageEx();
            this.edtVersNr = new KiSS4.Gui.KissTextEdit();
            this.qryBaPerson = new KiSS4.DB.SqlQuery(this.components);
            this.lblVersNr = new KiSS4.Gui.KissLabel();
            this.edtVorname = new KiSS4.Gui.KissTextEdit();
            this.edtName = new KiSS4.Gui.KissTextEdit();
            this.edtMobilTel = new KiSS4.Gui.KissTextEdit();
            this.edtTelefonG = new KiSS4.Gui.KissTextEdit();
            this.lblTelefon_G = new KiSS4.Gui.KissLabel();
            this.lblMobilTel = new KiSS4.Gui.KissLabel();
            this.edtBemerkung = new KiSS4.Gui.KissRTFEdit();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.edtSterbedatum = new KiSS4.Gui.KissDateEdit();
            this.lblSterbedatum = new KiSS4.Gui.KissLabel();
            this.edtGeburtsdatum = new KiSS4.Gui.KissDateEdit();
            this.edtAHVNummer = new KiSS4.Gui.KissTextEdit();
            this.lblGeburtsdatum = new KiSS4.Gui.KissLabel();
            this.edtTelefonP = new KiSS4.Gui.KissTextEdit();
            this.lblAHVNummer = new KiSS4.Gui.KissLabel();
            this.lblTelefon_P = new KiSS4.Gui.KissLabel();
            this.edtFallCheckIn = new KiSS4.Gui.KissDateEdit();
            this.lblCheckIn = new KiSS4.Gui.KissLabel();
            this.edtWohnsitzOrt = new KiSS4.Gui.KissTextEdit();
            this.edtWohnsitzLandCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtWohnsitzKanton = new KiSS4.Gui.KissTextEdit();
            this.edtWohnsitzPLZ = new KiSS4.Gui.KissTextEdit();
            this.edtWohnsitzPostfach = new KiSS4.Gui.KissTextEdit();
            this.edtWohnsitzHausNr = new KiSS4.Gui.KissTextEdit();
            this.edtWohnsitzAdressZusatz = new KiSS4.Gui.KissTextEdit();
            this.edtWohnsitzStrasse = new KiSS4.Gui.KissTextEdit();
            this.lblWohnsitzAdressZusatz = new KiSS4.Gui.KissLabel();
            this.lblWohnsitzPostfach = new KiSS4.Gui.KissLabel();
            this.lblPlzOrtKanton = new KiSS4.Gui.KissLabel();
            this.lblWohnsitzLandCode = new KiSS4.Gui.KissLabel();
            this.lblStrasseNr = new KiSS4.Gui.KissLabel();
            this.lblTitelPerson = new KiSS4.Gui.KissLabel();
            this.edtFaProzessCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblFaProzessCode = new KiSS4.Gui.KissLabel();
            this.edtEMail = new KiSS4.Gui.KissTextEdit();
            this.edtPhone = new KiSS4.Gui.KissTextEdit();
            this.edtAbteilung = new KiSS4.Gui.KissTextEdit();
            this.lblEMail = new KiSS4.Gui.KissLabel();
            this.lblPhone = new KiSS4.Gui.KissLabel();
            this.lblAbteilung = new KiSS4.Gui.KissLabel();
            this.edtSAR = new KiSS4.Gui.KissTextEdit();
            this.lblSAR = new KiSS4.Gui.KissLabel();
            this.lblTitelSar = new KiSS4.Gui.KissLabel();
            this.lblTitelFall = new KiSS4.Gui.KissLabel();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtModulID = new KiSS4.Gui.KissLookUpEdit();
            this.lblModulID = new KiSS4.Gui.KissLabel();
            this.lblDatumBis = new KiSS4.Gui.KissLabel();
            this.lblDatumVon = new KiSS4.Gui.KissLabel();
            this.lblName = new KiSS4.Gui.KissLabel();
            this.tpgFaLeistungArchiv = new SharpLibrary.WinControls.TabPageEx();
            this.edtCheckOut = new KiSS4.Gui.KissDateEdit();
            this.lblZurueckDurch = new KiSS4.Gui.KissLabel();
            this.edtCheckOutUserName = new KiSS4.Gui.KissTextEdit();
            this.lblCheckOut = new KiSS4.Gui.KissLabel();
            this.edtCheckIn = new KiSS4.Gui.KissDateEdit();
            this.lblArchiviertDurch = new KiSS4.Gui.KissLabel();
            this.edtCheckInUserName = new KiSS4.Gui.KissTextEdit();
            this.lblArchiviert = new KiSS4.Gui.KissLabel();
            this.edtArchivNr = new KiSS4.Gui.KissTextEdit();
            this.lblArchivNr = new KiSS4.Gui.KissLabel();
            this.edtStandort = new KiSS4.Gui.KissTextEdit();
            this.lblStandort = new KiSS4.Gui.KissLabel();
            this.lblTitelArchiv = new KiSS4.Gui.KissLabel();
            this.grdFaLeistungArchiv = new KiSS4.Gui.KissGrid();
            this.grvFaLeistungArchiv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colStandort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArchivNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCheckIn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCheckOut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpgZustaendigkeit = new SharpLibrary.WinControls.TabPageEx();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.grdZustaendigkeit = new KiSS4.Gui.KissGrid();
            this.qryZustaendigkeit = new KiSS4.DB.SqlQuery(this.components);
            this.grvZustaendigkeit = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colZustModul = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repModulIcon = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colZustDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZustDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZustZustaendigkeit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpgGastrecht = new SharpLibrary.WinControls.TabPageEx();
            this.lblGastrecht = new KiSS4.Gui.KissLabel();
            this.grdGastrecht = new KiSS4.Gui.KissGrid();
            this.qryGastrecht = new KiSS4.DB.SqlQuery(this.components);
            this.grvGastrecht = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colGastModulId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repModulIconGastrecht = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colGastDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGastDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGastSAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGastDarfMutieren = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaLeistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaLeistungArchiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treFaLeistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            this.panRight.SuspendLayout();
            this.tabFallinfo.SuspendLayout();
            this.tpgFaLeistung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMobilTel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefonG.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefon_G)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMobilTel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSterbedatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSterbedatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtsdatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAHVNummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsdatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefonP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAHVNummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefon_P)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFallCheckIn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCheckIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitzOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitzLandCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitzLandCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitzKanton.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitzPLZ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitzPostfach.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitzHausNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitzAdressZusatz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitzStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWohnsitzAdressZusatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWohnsitzPostfach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPlzOrtKanton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWohnsitzLandCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStrasseNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitelPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaProzessCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaProzessCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaProzessCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEMail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbteilung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEMail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbteilung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSAR.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitelSar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitelFall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModulID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            this.tpgFaLeistungArchiv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtCheckOut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZurueckDurch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCheckOutUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCheckOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCheckIn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblArchiviertDurch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCheckInUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblArchiviert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtArchivNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblArchivNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStandort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStandort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitelArchiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFaLeistungArchiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFaLeistungArchiv)).BeginInit();
            this.tpgZustaendigkeit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZustaendigkeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZustaendigkeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZustaendigkeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repModulIcon)).BeginInit();
            this.tpgGastrecht.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblGastrecht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGastrecht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryGastrecht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvGastrecht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repModulIconGastrecht)).BeginInit();
            this.SuspendLayout();
            // 
            // qryFaLeistung
            // 
            this.qryFaLeistung.AutoApplyUserRights = false;
            this.qryFaLeistung.HostControl = this;
            this.qryFaLeistung.SelectStatement = resources.GetString("qryFaLeistung.SelectStatement");
            this.qryFaLeistung.AfterFill += new System.EventHandler(this.qryFaLeistung_AfterFill);
            this.qryFaLeistung.PositionChanged += new System.EventHandler(this.qryFaLeistung_PositionChanged);
            // 
            // qryFaLeistungArchiv
            // 
            this.qryFaLeistungArchiv.CanUpdate = true;
            this.qryFaLeistungArchiv.HostControl = this;
            this.qryFaLeistungArchiv.SelectStatement = resources.GetString("qryFaLeistungArchiv.SelectStatement");
            // 
            // treFaLeistung
            // 
            this.treFaLeistung.AllowSortTree = true;
            this.treFaLeistung.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.treFaLeistung.Appearance.Empty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.treFaLeistung.Appearance.Empty.Options.UseBackColor = true;
            this.treFaLeistung.Appearance.Empty.Options.UseForeColor = true;
            this.treFaLeistung.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(236)))), ((int)(((byte)(215)))));
            this.treFaLeistung.Appearance.EvenRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treFaLeistung.Appearance.EvenRow.Options.UseBackColor = true;
            this.treFaLeistung.Appearance.EvenRow.Options.UseForeColor = true;
            this.treFaLeistung.Appearance.FocusedCell.BackColor = System.Drawing.Color.Transparent;
            this.treFaLeistung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.treFaLeistung.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treFaLeistung.Appearance.FocusedCell.Options.UseForeColor = true;
            this.treFaLeistung.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.treFaLeistung.Appearance.FocusedRow.Options.UseForeColor = true;
            this.treFaLeistung.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treFaLeistung.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treFaLeistung.Appearance.FooterPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treFaLeistung.Appearance.FooterPanel.Options.UseBackColor = true;
            this.treFaLeistung.Appearance.FooterPanel.Options.UseFont = true;
            this.treFaLeistung.Appearance.FooterPanel.Options.UseForeColor = true;
            this.treFaLeistung.Appearance.GroupButton.BackColor = System.Drawing.Color.Transparent;
            this.treFaLeistung.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.treFaLeistung.Appearance.GroupButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treFaLeistung.Appearance.GroupButton.Options.UseBackColor = true;
            this.treFaLeistung.Appearance.GroupButton.Options.UseFont = true;
            this.treFaLeistung.Appearance.GroupButton.Options.UseForeColor = true;
            this.treFaLeistung.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(226)))), ((int)(((byte)(184)))));
            this.treFaLeistung.Appearance.GroupFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treFaLeistung.Appearance.GroupFooter.Options.UseBackColor = true;
            this.treFaLeistung.Appearance.GroupFooter.Options.UseForeColor = true;
            this.treFaLeistung.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.treFaLeistung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.treFaLeistung.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treFaLeistung.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.treFaLeistung.Appearance.HeaderPanel.Options.UseFont = true;
            this.treFaLeistung.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.treFaLeistung.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.treFaLeistung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treFaLeistung.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.treFaLeistung.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.treFaLeistung.Appearance.HideSelectionRow.Options.UseFont = true;
            this.treFaLeistung.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.treFaLeistung.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treFaLeistung.Appearance.HorzLine.ForeColor = System.Drawing.Color.Red;
            this.treFaLeistung.Appearance.HorzLine.Options.UseBackColor = true;
            this.treFaLeistung.Appearance.HorzLine.Options.UseForeColor = true;
            this.treFaLeistung.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.treFaLeistung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treFaLeistung.Appearance.OddRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treFaLeistung.Appearance.OddRow.Options.UseBackColor = true;
            this.treFaLeistung.Appearance.OddRow.Options.UseFont = true;
            this.treFaLeistung.Appearance.OddRow.Options.UseForeColor = true;
            this.treFaLeistung.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.treFaLeistung.Appearance.Preview.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treFaLeistung.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treFaLeistung.Appearance.Preview.Options.UseBackColor = true;
            this.treFaLeistung.Appearance.Preview.Options.UseFont = true;
            this.treFaLeistung.Appearance.Preview.Options.UseForeColor = true;
            this.treFaLeistung.Appearance.Row.BackColor = System.Drawing.Color.Transparent;
            this.treFaLeistung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treFaLeistung.Appearance.Row.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treFaLeistung.Appearance.Row.Options.UseBackColor = true;
            this.treFaLeistung.Appearance.Row.Options.UseFont = true;
            this.treFaLeistung.Appearance.Row.Options.UseForeColor = true;
            this.treFaLeistung.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.treFaLeistung.Appearance.SelectedRow.Options.UseForeColor = true;
            this.treFaLeistung.Appearance.TreeLine.BackColor = System.Drawing.Color.Gray;
            this.treFaLeistung.Appearance.TreeLine.Options.UseBackColor = true;
            this.treFaLeistung.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treFaLeistung.Appearance.VertLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(166)))), ((int)(((byte)(70)))));
            this.treFaLeistung.Appearance.VertLine.Options.UseBackColor = true;
            this.treFaLeistung.Appearance.VertLine.Options.UseForeColor = true;
            this.treFaLeistung.Appearance.VertLine.Options.UseTextOptions = true;
            this.treFaLeistung.Appearance.VertLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.treFaLeistung.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colDatumVon,
            this.colSAR,
            this.colFaFallID});
            this.treFaLeistung.DataSource = this.qryFaLeistung;
            this.treFaLeistung.Dock = System.Windows.Forms.DockStyle.Left;
            this.treFaLeistung.ImageIndexFieldName = "IconID";
            this.treFaLeistung.KeyFieldName = "FaLeistungID";
            this.treFaLeistung.Location = new System.Drawing.Point(0, 0);
            this.treFaLeistung.Name = "treFaLeistung";
            this.treFaLeistung.OptionsBehavior.AutoSelectAllInEditor = false;
            this.treFaLeistung.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.treFaLeistung.OptionsBehavior.Editable = false;
            this.treFaLeistung.OptionsBehavior.KeepSelectedOnClick = false;
            this.treFaLeistung.OptionsBehavior.MoveOnEdit = false;
            this.treFaLeistung.OptionsBehavior.ShowToolTips = false;
            this.treFaLeistung.OptionsBehavior.SmartMouseHover = false;
            this.treFaLeistung.OptionsMenu.EnableColumnMenu = false;
            this.treFaLeistung.OptionsMenu.EnableFooterMenu = false;
            this.treFaLeistung.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treFaLeistung.OptionsView.AutoWidth = false;
            this.treFaLeistung.OptionsView.EnableAppearanceEvenRow = true;
            this.treFaLeistung.OptionsView.EnableAppearanceOddRow = true;
            this.treFaLeistung.OptionsView.ShowIndicator = false;
            this.treFaLeistung.OptionsView.ShowVertLines = false;
            this.treFaLeistung.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1});
            this.treFaLeistung.Size = new System.Drawing.Size(270, 485);
            this.treFaLeistung.Styles.AddReplace("PressedColumn", new DevExpress.Utils.ViewStyle("PressedColumn", "TreeList", new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold), "HeaderPanel", ((DevExpress.Utils.StyleOptions)(((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor)
                    | DevExpress.Utils.StyleOptions.UseForeColor))), true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222))))), System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))));
            this.treFaLeistung.TabIndex = 0;
            // 
            // colDatumVon
            // 
            this.colDatumVon.Caption = "Datum von";
            this.colDatumVon.ColumnEdit = this.repositoryItemDateEdit1;
            this.colDatumVon.FieldName = "DatumVon";
            this.colDatumVon.MinWidth = 27;
            this.colDatumVon.Name = "colDatumVon";
            this.colDatumVon.VisibleIndex = 0;
            this.colDatumVon.Width = 110;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // colSAR
            // 
            this.colSAR.Caption = "SAR";
            this.colSAR.FieldName = "SAR";
            this.colSAR.Name = "colSAR";
            this.colSAR.VisibleIndex = 1;
            this.colSAR.Width = 150;
            // 
            // colFaFallID
            // 
            this.colFaFallID.Caption = "-";
            this.colFaFallID.FieldName = "FaFallID";
            this.colFaFallID.Name = "colFaFallID";
            this.colFaFallID.Width = 92;
            // 
            // panRight
            // 
            this.panRight.AutoScroll = true;
            this.panRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panRight.Controls.Add(this.btnOK);
            this.panRight.Controls.Add(this.tabFallinfo);
            this.panRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panRight.Location = new System.Drawing.Point(270, 0);
            this.panRight.Name = "panRight";
            this.panRight.Size = new System.Drawing.Size(713, 485);
            this.panRight.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(604, 448);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(96, 24);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            // 
            // tabFallinfo
            // 
            this.tabFallinfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabFallinfo.Controls.Add(this.tpgFaLeistung);
            this.tabFallinfo.Controls.Add(this.tpgFaLeistungArchiv);
            this.tabFallinfo.Controls.Add(this.tpgZustaendigkeit);
            this.tabFallinfo.Controls.Add(this.tpgGastrecht);
            this.tabFallinfo.Location = new System.Drawing.Point(6, 11);
            this.tabFallinfo.Name = "tabFallinfo";
            this.tabFallinfo.ShowFixedWidthTooltip = true;
            this.tabFallinfo.Size = new System.Drawing.Size(694, 461);
            this.tabFallinfo.TabIndex = 0;
            this.tabFallinfo.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgFaLeistung,
            this.tpgFaLeistungArchiv,
            this.tpgZustaendigkeit,
            this.tpgGastrecht});
            this.tabFallinfo.TabsLineColor = System.Drawing.Color.Black;
            this.tabFallinfo.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabFallinfo.Text = "kissTabControlEx1";
            // 
            // tpgFaLeistung
            // 
            this.tpgFaLeistung.AutoScroll = true;
            this.tpgFaLeistung.AutoScrollMinSize = new System.Drawing.Size(656, 420);
            this.tpgFaLeistung.Controls.Add(this.edtVersNr);
            this.tpgFaLeistung.Controls.Add(this.lblVersNr);
            this.tpgFaLeistung.Controls.Add(this.edtVorname);
            this.tpgFaLeistung.Controls.Add(this.edtName);
            this.tpgFaLeistung.Controls.Add(this.edtMobilTel);
            this.tpgFaLeistung.Controls.Add(this.edtTelefonG);
            this.tpgFaLeistung.Controls.Add(this.lblTelefon_G);
            this.tpgFaLeistung.Controls.Add(this.lblMobilTel);
            this.tpgFaLeistung.Controls.Add(this.edtBemerkung);
            this.tpgFaLeistung.Controls.Add(this.lblBemerkung);
            this.tpgFaLeistung.Controls.Add(this.edtSterbedatum);
            this.tpgFaLeistung.Controls.Add(this.lblSterbedatum);
            this.tpgFaLeistung.Controls.Add(this.edtGeburtsdatum);
            this.tpgFaLeistung.Controls.Add(this.edtAHVNummer);
            this.tpgFaLeistung.Controls.Add(this.lblGeburtsdatum);
            this.tpgFaLeistung.Controls.Add(this.edtTelefonP);
            this.tpgFaLeistung.Controls.Add(this.lblAHVNummer);
            this.tpgFaLeistung.Controls.Add(this.lblTelefon_P);
            this.tpgFaLeistung.Controls.Add(this.edtFallCheckIn);
            this.tpgFaLeistung.Controls.Add(this.lblCheckIn);
            this.tpgFaLeistung.Controls.Add(this.edtWohnsitzOrt);
            this.tpgFaLeistung.Controls.Add(this.edtWohnsitzLandCode);
            this.tpgFaLeistung.Controls.Add(this.edtWohnsitzKanton);
            this.tpgFaLeistung.Controls.Add(this.edtWohnsitzPLZ);
            this.tpgFaLeistung.Controls.Add(this.edtWohnsitzPostfach);
            this.tpgFaLeistung.Controls.Add(this.edtWohnsitzHausNr);
            this.tpgFaLeistung.Controls.Add(this.edtWohnsitzAdressZusatz);
            this.tpgFaLeistung.Controls.Add(this.edtWohnsitzStrasse);
            this.tpgFaLeistung.Controls.Add(this.lblWohnsitzAdressZusatz);
            this.tpgFaLeistung.Controls.Add(this.lblWohnsitzPostfach);
            this.tpgFaLeistung.Controls.Add(this.lblPlzOrtKanton);
            this.tpgFaLeistung.Controls.Add(this.lblWohnsitzLandCode);
            this.tpgFaLeistung.Controls.Add(this.lblStrasseNr);
            this.tpgFaLeistung.Controls.Add(this.lblTitelPerson);
            this.tpgFaLeistung.Controls.Add(this.edtFaProzessCode);
            this.tpgFaLeistung.Controls.Add(this.lblFaProzessCode);
            this.tpgFaLeistung.Controls.Add(this.edtEMail);
            this.tpgFaLeistung.Controls.Add(this.edtPhone);
            this.tpgFaLeistung.Controls.Add(this.edtAbteilung);
            this.tpgFaLeistung.Controls.Add(this.lblEMail);
            this.tpgFaLeistung.Controls.Add(this.lblPhone);
            this.tpgFaLeistung.Controls.Add(this.lblAbteilung);
            this.tpgFaLeistung.Controls.Add(this.edtSAR);
            this.tpgFaLeistung.Controls.Add(this.lblSAR);
            this.tpgFaLeistung.Controls.Add(this.lblTitelSar);
            this.tpgFaLeistung.Controls.Add(this.lblTitelFall);
            this.tpgFaLeistung.Controls.Add(this.edtDatumBis);
            this.tpgFaLeistung.Controls.Add(this.edtDatumVon);
            this.tpgFaLeistung.Controls.Add(this.edtModulID);
            this.tpgFaLeistung.Controls.Add(this.lblModulID);
            this.tpgFaLeistung.Controls.Add(this.lblDatumBis);
            this.tpgFaLeistung.Controls.Add(this.lblDatumVon);
            this.tpgFaLeistung.Controls.Add(this.lblName);
            this.tpgFaLeistung.Location = new System.Drawing.Point(6, 6);
            this.tpgFaLeistung.Name = "tpgFaLeistung";
            this.tpgFaLeistung.Size = new System.Drawing.Size(682, 423);
            this.tpgFaLeistung.TabIndex = 0;
            this.tpgFaLeistung.Title = "Übersicht";
            // 
            // edtVersNr
            // 
            this.edtVersNr.DataMember = "Versichertennummer";
            this.edtVersNr.DataSource = this.qryBaPerson;
            this.edtVersNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtVersNr.Location = new System.Drawing.Point(446, 326);
            this.edtVersNr.Name = "edtVersNr";
            this.edtVersNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVersNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVersNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVersNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtVersNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVersNr.Properties.Appearance.Options.UseFont = true;
            this.edtVersNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVersNr.Properties.ReadOnly = true;
            this.edtVersNr.Size = new System.Drawing.Size(233, 24);
            this.edtVersNr.TabIndex = 52;
            // 
            // qryBaPerson
            // 
            this.qryBaPerson.HostControl = this;
            this.qryBaPerson.SelectStatement = "SELECT PRS.*\r\nFROM dbo.FaLeistung        FAL WITH (READUNCOMMITTED)\r\n  INNER JOIN" +
    " dbo.vwPerson  PRS ON PRS.BaPersonID = FAL.BaPersonID\r\nWHERE FAL.FaLeistungID = " +
    "{0};";
            // 
            // lblVersNr
            // 
            this.lblVersNr.ForeColor = System.Drawing.Color.Black;
            this.lblVersNr.Location = new System.Drawing.Point(371, 326);
            this.lblVersNr.Name = "lblVersNr";
            this.lblVersNr.Size = new System.Drawing.Size(69, 24);
            this.lblVersNr.TabIndex = 51;
            this.lblVersNr.Text = "Vers.-Nr.";
            // 
            // edtVorname
            // 
            this.edtVorname.DataMember = "Vorname";
            this.edtVorname.DataSource = this.qryBaPerson;
            this.edtVorname.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtVorname.Location = new System.Drawing.Point(253, 190);
            this.edtVorname.Name = "edtVorname";
            this.edtVorname.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVorname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVorname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVorname.Properties.Appearance.Options.UseBackColor = true;
            this.edtVorname.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVorname.Properties.Appearance.Options.UseFont = true;
            this.edtVorname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVorname.Properties.ReadOnly = true;
            this.edtVorname.Size = new System.Drawing.Size(102, 24);
            this.edtVorname.TabIndex = 23;
            // 
            // edtName
            // 
            this.edtName.DataMember = "Name";
            this.edtName.DataSource = this.qryBaPerson;
            this.edtName.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtName.Location = new System.Drawing.Point(85, 190);
            this.edtName.Name = "edtName";
            this.edtName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtName.Properties.Appearance.Options.UseBackColor = true;
            this.edtName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtName.Properties.Appearance.Options.UseFont = true;
            this.edtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtName.Properties.ReadOnly = true;
            this.edtName.Size = new System.Drawing.Size(169, 24);
            this.edtName.TabIndex = 22;
            // 
            // edtMobilTel
            // 
            this.edtMobilTel.DataMember = "MobilTel";
            this.edtMobilTel.DataSource = this.qryBaPerson;
            this.edtMobilTel.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtMobilTel.Location = new System.Drawing.Point(446, 236);
            this.edtMobilTel.Name = "edtMobilTel";
            this.edtMobilTel.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtMobilTel.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMobilTel.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMobilTel.Properties.Appearance.Options.UseBackColor = true;
            this.edtMobilTel.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMobilTel.Properties.Appearance.Options.UseFont = true;
            this.edtMobilTel.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMobilTel.Properties.ReadOnly = true;
            this.edtMobilTel.Size = new System.Drawing.Size(233, 24);
            this.edtMobilTel.TabIndex = 42;
            // 
            // edtTelefonG
            // 
            this.edtTelefonG.DataMember = "Telefon_G";
            this.edtTelefonG.DataSource = this.qryBaPerson;
            this.edtTelefonG.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtTelefonG.Location = new System.Drawing.Point(446, 213);
            this.edtTelefonG.Name = "edtTelefonG";
            this.edtTelefonG.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtTelefonG.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTelefonG.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTelefonG.Properties.Appearance.Options.UseBackColor = true;
            this.edtTelefonG.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTelefonG.Properties.Appearance.Options.UseFont = true;
            this.edtTelefonG.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTelefonG.Properties.ReadOnly = true;
            this.edtTelefonG.Size = new System.Drawing.Size(233, 24);
            this.edtTelefonG.TabIndex = 40;
            // 
            // lblTelefon_G
            // 
            this.lblTelefon_G.ForeColor = System.Drawing.Color.Black;
            this.lblTelefon_G.Location = new System.Drawing.Point(371, 213);
            this.lblTelefon_G.Name = "lblTelefon_G";
            this.lblTelefon_G.Size = new System.Drawing.Size(69, 24);
            this.lblTelefon_G.TabIndex = 39;
            this.lblTelefon_G.Text = "Telefon G";
            // 
            // lblMobilTel
            // 
            this.lblMobilTel.ForeColor = System.Drawing.Color.Black;
            this.lblMobilTel.Location = new System.Drawing.Point(371, 236);
            this.lblMobilTel.Name = "lblMobilTel";
            this.lblMobilTel.Size = new System.Drawing.Size(69, 24);
            this.lblMobilTel.TabIndex = 41;
            this.lblMobilTel.Text = "Telefon M";
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBemerkung.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryBaPerson;
            this.edtBemerkung.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBemerkung.Font = new System.Drawing.Font("Arial", 10F);
            this.edtBemerkung.Location = new System.Drawing.Point(85, 356);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.ReadOnly = true;
            this.edtBemerkung.Size = new System.Drawing.Size(594, 64);
            this.edtBemerkung.TabIndex = 50;
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.ForeColor = System.Drawing.Color.Black;
            this.lblBemerkung.Location = new System.Drawing.Point(3, 356);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(77, 24);
            this.lblBemerkung.TabIndex = 49;
            this.lblBemerkung.Text = "Bemerkung";
            // 
            // edtSterbedatum
            // 
            this.edtSterbedatum.DataMember = "Sterbedatum";
            this.edtSterbedatum.DataSource = this.qryBaPerson;
            this.edtSterbedatum.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtSterbedatum.EditValue = new System.DateTime(2004, 4, 23, 0, 0, 0, 0);
            this.edtSterbedatum.Location = new System.Drawing.Point(584, 266);
            this.edtSterbedatum.Name = "edtSterbedatum";
            this.edtSterbedatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSterbedatum.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSterbedatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSterbedatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSterbedatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtSterbedatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSterbedatum.Properties.Appearance.Options.UseFont = true;
            this.edtSterbedatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtSterbedatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSterbedatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtSterbedatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSterbedatum.Properties.ReadOnly = true;
            this.edtSterbedatum.Properties.ShowToday = false;
            this.edtSterbedatum.Size = new System.Drawing.Size(95, 24);
            this.edtSterbedatum.TabIndex = 46;
            // 
            // lblSterbedatum
            // 
            this.lblSterbedatum.ForeColor = System.Drawing.Color.Black;
            this.lblSterbedatum.Location = new System.Drawing.Point(542, 266);
            this.lblSterbedatum.Name = "lblSterbedatum";
            this.lblSterbedatum.Size = new System.Drawing.Size(42, 24);
            this.lblSterbedatum.TabIndex = 45;
            this.lblSterbedatum.Text = "Tod";
            // 
            // edtGeburtsdatum
            // 
            this.edtGeburtsdatum.DataMember = "Geburtsdatum";
            this.edtGeburtsdatum.DataSource = this.qryBaPerson;
            this.edtGeburtsdatum.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGeburtsdatum.EditValue = null;
            this.edtGeburtsdatum.Location = new System.Drawing.Point(446, 266);
            this.edtGeburtsdatum.Name = "edtGeburtsdatum";
            this.edtGeburtsdatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGeburtsdatum.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGeburtsdatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeburtsdatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeburtsdatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeburtsdatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeburtsdatum.Properties.Appearance.Options.UseFont = true;
            this.edtGeburtsdatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtGeburtsdatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGeburtsdatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtGeburtsdatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeburtsdatum.Properties.ReadOnly = true;
            this.edtGeburtsdatum.Properties.ShowToday = false;
            this.edtGeburtsdatum.Size = new System.Drawing.Size(95, 24);
            this.edtGeburtsdatum.TabIndex = 44;
            // 
            // edtAHVNummer
            // 
            this.edtAHVNummer.DataMember = "AHVNummer";
            this.edtAHVNummer.DataSource = this.qryBaPerson;
            this.edtAHVNummer.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAHVNummer.Location = new System.Drawing.Point(446, 296);
            this.edtAHVNummer.Name = "edtAHVNummer";
            this.edtAHVNummer.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAHVNummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAHVNummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAHVNummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtAHVNummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAHVNummer.Properties.Appearance.Options.UseFont = true;
            this.edtAHVNummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAHVNummer.Properties.ReadOnly = true;
            this.edtAHVNummer.Size = new System.Drawing.Size(233, 24);
            this.edtAHVNummer.TabIndex = 48;
            // 
            // lblGeburtsdatum
            // 
            this.lblGeburtsdatum.ForeColor = System.Drawing.Color.Black;
            this.lblGeburtsdatum.Location = new System.Drawing.Point(371, 266);
            this.lblGeburtsdatum.Name = "lblGeburtsdatum";
            this.lblGeburtsdatum.Size = new System.Drawing.Size(69, 24);
            this.lblGeburtsdatum.TabIndex = 43;
            this.lblGeburtsdatum.Text = "Geburt";
            // 
            // edtTelefonP
            // 
            this.edtTelefonP.DataMember = "Telefon_P";
            this.edtTelefonP.DataSource = this.qryBaPerson;
            this.edtTelefonP.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtTelefonP.Location = new System.Drawing.Point(446, 190);
            this.edtTelefonP.Name = "edtTelefonP";
            this.edtTelefonP.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtTelefonP.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTelefonP.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTelefonP.Properties.Appearance.Options.UseBackColor = true;
            this.edtTelefonP.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTelefonP.Properties.Appearance.Options.UseFont = true;
            this.edtTelefonP.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTelefonP.Properties.ReadOnly = true;
            this.edtTelefonP.Size = new System.Drawing.Size(233, 24);
            this.edtTelefonP.TabIndex = 38;
            // 
            // lblAHVNummer
            // 
            this.lblAHVNummer.ForeColor = System.Drawing.Color.Black;
            this.lblAHVNummer.Location = new System.Drawing.Point(371, 296);
            this.lblAHVNummer.Name = "lblAHVNummer";
            this.lblAHVNummer.Size = new System.Drawing.Size(69, 24);
            this.lblAHVNummer.TabIndex = 47;
            this.lblAHVNummer.Text = "AVH-Nr";
            // 
            // lblTelefon_P
            // 
            this.lblTelefon_P.ForeColor = System.Drawing.Color.Black;
            this.lblTelefon_P.Location = new System.Drawing.Point(371, 190);
            this.lblTelefon_P.Name = "lblTelefon_P";
            this.lblTelefon_P.Size = new System.Drawing.Size(69, 24);
            this.lblTelefon_P.TabIndex = 37;
            this.lblTelefon_P.Text = "Telefon P";
            // 
            // edtFallCheckIn
            // 
            this.edtFallCheckIn.DataMember = "CheckIn";
            this.edtFallCheckIn.DataSource = this.qryFaLeistung;
            this.edtFallCheckIn.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtFallCheckIn.EditValue = null;
            this.edtFallCheckIn.Location = new System.Drawing.Point(85, 120);
            this.edtFallCheckIn.Name = "edtFallCheckIn";
            this.edtFallCheckIn.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtFallCheckIn.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtFallCheckIn.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFallCheckIn.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFallCheckIn.Properties.Appearance.Options.UseBackColor = true;
            this.edtFallCheckIn.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFallCheckIn.Properties.Appearance.Options.UseFont = true;
            this.edtFallCheckIn.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFallCheckIn.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFallCheckIn.Properties.ReadOnly = true;
            this.edtFallCheckIn.Properties.ShowToday = false;
            this.edtFallCheckIn.Size = new System.Drawing.Size(91, 24);
            this.edtFallCheckIn.TabIndex = 10;
            // 
            // lblCheckIn
            // 
            this.lblCheckIn.Location = new System.Drawing.Point(5, 120);
            this.lblCheckIn.Name = "lblCheckIn";
            this.lblCheckIn.Size = new System.Drawing.Size(74, 24);
            this.lblCheckIn.TabIndex = 9;
            this.lblCheckIn.Text = "Archiviert am";
            // 
            // edtWohnsitzOrt
            // 
            this.edtWohnsitzOrt.DataMember = "WohnsitzOrt";
            this.edtWohnsitzOrt.DataSource = this.qryBaPerson;
            this.edtWohnsitzOrt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtWohnsitzOrt.Location = new System.Drawing.Point(129, 282);
            this.edtWohnsitzOrt.Name = "edtWohnsitzOrt";
            this.edtWohnsitzOrt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtWohnsitzOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWohnsitzOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWohnsitzOrt.Properties.Appearance.Options.UseBackColor = true;
            this.edtWohnsitzOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWohnsitzOrt.Properties.Appearance.Options.UseFont = true;
            this.edtWohnsitzOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtWohnsitzOrt.Properties.ReadOnly = true;
            this.edtWohnsitzOrt.Size = new System.Drawing.Size(196, 24);
            this.edtWohnsitzOrt.TabIndex = 33;
            // 
            // edtWohnsitzLandCode
            // 
            this.edtWohnsitzLandCode.DataMember = "WohnsitzBaLandID";
            this.edtWohnsitzLandCode.DataSource = this.qryBaPerson;
            this.edtWohnsitzLandCode.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtWohnsitzLandCode.Location = new System.Drawing.Point(85, 305);
            this.edtWohnsitzLandCode.LOVName = "BaLand";
            this.edtWohnsitzLandCode.Name = "edtWohnsitzLandCode";
            this.edtWohnsitzLandCode.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtWohnsitzLandCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWohnsitzLandCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWohnsitzLandCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtWohnsitzLandCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWohnsitzLandCode.Properties.Appearance.Options.UseFont = true;
            this.edtWohnsitzLandCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtWohnsitzLandCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtWohnsitzLandCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtWohnsitzLandCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtWohnsitzLandCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtWohnsitzLandCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtWohnsitzLandCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtWohnsitzLandCode.Properties.NullText = "";
            this.edtWohnsitzLandCode.Properties.ReadOnly = true;
            this.edtWohnsitzLandCode.Properties.ShowFooter = false;
            this.edtWohnsitzLandCode.Properties.ShowHeader = false;
            this.edtWohnsitzLandCode.Size = new System.Drawing.Size(270, 24);
            this.edtWohnsitzLandCode.TabIndex = 36;
            // 
            // edtWohnsitzKanton
            // 
            this.edtWohnsitzKanton.DataMember = "WohnsitzKanton";
            this.edtWohnsitzKanton.DataSource = this.qryBaPerson;
            this.edtWohnsitzKanton.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtWohnsitzKanton.Location = new System.Drawing.Point(324, 282);
            this.edtWohnsitzKanton.Name = "edtWohnsitzKanton";
            this.edtWohnsitzKanton.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtWohnsitzKanton.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWohnsitzKanton.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWohnsitzKanton.Properties.Appearance.Options.UseBackColor = true;
            this.edtWohnsitzKanton.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWohnsitzKanton.Properties.Appearance.Options.UseFont = true;
            this.edtWohnsitzKanton.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtWohnsitzKanton.Properties.ReadOnly = true;
            this.edtWohnsitzKanton.Size = new System.Drawing.Size(31, 24);
            this.edtWohnsitzKanton.TabIndex = 34;
            // 
            // edtWohnsitzPLZ
            // 
            this.edtWohnsitzPLZ.DataMember = "WohnsitzPLZ";
            this.edtWohnsitzPLZ.DataSource = this.qryBaPerson;
            this.edtWohnsitzPLZ.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtWohnsitzPLZ.Location = new System.Drawing.Point(85, 282);
            this.edtWohnsitzPLZ.Name = "edtWohnsitzPLZ";
            this.edtWohnsitzPLZ.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtWohnsitzPLZ.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWohnsitzPLZ.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWohnsitzPLZ.Properties.Appearance.Options.UseBackColor = true;
            this.edtWohnsitzPLZ.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWohnsitzPLZ.Properties.Appearance.Options.UseFont = true;
            this.edtWohnsitzPLZ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtWohnsitzPLZ.Properties.ReadOnly = true;
            this.edtWohnsitzPLZ.Size = new System.Drawing.Size(45, 24);
            this.edtWohnsitzPLZ.TabIndex = 32;
            // 
            // edtWohnsitzPostfach
            // 
            this.edtWohnsitzPostfach.DataMember = "WohnsitzPostfach";
            this.edtWohnsitzPostfach.DataSource = this.qryBaPerson;
            this.edtWohnsitzPostfach.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtWohnsitzPostfach.Location = new System.Drawing.Point(85, 259);
            this.edtWohnsitzPostfach.Name = "edtWohnsitzPostfach";
            this.edtWohnsitzPostfach.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtWohnsitzPostfach.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWohnsitzPostfach.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWohnsitzPostfach.Properties.Appearance.Options.UseBackColor = true;
            this.edtWohnsitzPostfach.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWohnsitzPostfach.Properties.Appearance.Options.UseFont = true;
            this.edtWohnsitzPostfach.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtWohnsitzPostfach.Properties.ReadOnly = true;
            this.edtWohnsitzPostfach.Size = new System.Drawing.Size(270, 24);
            this.edtWohnsitzPostfach.TabIndex = 30;
            // 
            // edtWohnsitzHausNr
            // 
            this.edtWohnsitzHausNr.DataMember = "WohnsitzHausNr";
            this.edtWohnsitzHausNr.DataSource = this.qryBaPerson;
            this.edtWohnsitzHausNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtWohnsitzHausNr.Location = new System.Drawing.Point(306, 236);
            this.edtWohnsitzHausNr.Name = "edtWohnsitzHausNr";
            this.edtWohnsitzHausNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtWohnsitzHausNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWohnsitzHausNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWohnsitzHausNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtWohnsitzHausNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWohnsitzHausNr.Properties.Appearance.Options.UseFont = true;
            this.edtWohnsitzHausNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtWohnsitzHausNr.Properties.ReadOnly = true;
            this.edtWohnsitzHausNr.Size = new System.Drawing.Size(49, 24);
            this.edtWohnsitzHausNr.TabIndex = 28;
            // 
            // edtWohnsitzAdressZusatz
            // 
            this.edtWohnsitzAdressZusatz.DataMember = "WohnsitzAdressZusatz";
            this.edtWohnsitzAdressZusatz.DataSource = this.qryBaPerson;
            this.edtWohnsitzAdressZusatz.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtWohnsitzAdressZusatz.Location = new System.Drawing.Point(85, 213);
            this.edtWohnsitzAdressZusatz.Name = "edtWohnsitzAdressZusatz";
            this.edtWohnsitzAdressZusatz.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtWohnsitzAdressZusatz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWohnsitzAdressZusatz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWohnsitzAdressZusatz.Properties.Appearance.Options.UseBackColor = true;
            this.edtWohnsitzAdressZusatz.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWohnsitzAdressZusatz.Properties.Appearance.Options.UseFont = true;
            this.edtWohnsitzAdressZusatz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtWohnsitzAdressZusatz.Properties.ReadOnly = true;
            this.edtWohnsitzAdressZusatz.Size = new System.Drawing.Size(270, 24);
            this.edtWohnsitzAdressZusatz.TabIndex = 25;
            // 
            // edtWohnsitzStrasse
            // 
            this.edtWohnsitzStrasse.DataMember = "WohnsitzStrasse";
            this.edtWohnsitzStrasse.DataSource = this.qryBaPerson;
            this.edtWohnsitzStrasse.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtWohnsitzStrasse.Location = new System.Drawing.Point(85, 236);
            this.edtWohnsitzStrasse.Name = "edtWohnsitzStrasse";
            this.edtWohnsitzStrasse.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtWohnsitzStrasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWohnsitzStrasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWohnsitzStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.edtWohnsitzStrasse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWohnsitzStrasse.Properties.Appearance.Options.UseFont = true;
            this.edtWohnsitzStrasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtWohnsitzStrasse.Properties.ReadOnly = true;
            this.edtWohnsitzStrasse.Size = new System.Drawing.Size(222, 24);
            this.edtWohnsitzStrasse.TabIndex = 27;
            // 
            // lblWohnsitzAdressZusatz
            // 
            this.lblWohnsitzAdressZusatz.ForeColor = System.Drawing.Color.Black;
            this.lblWohnsitzAdressZusatz.Location = new System.Drawing.Point(5, 213);
            this.lblWohnsitzAdressZusatz.Name = "lblWohnsitzAdressZusatz";
            this.lblWohnsitzAdressZusatz.Size = new System.Drawing.Size(77, 24);
            this.lblWohnsitzAdressZusatz.TabIndex = 24;
            this.lblWohnsitzAdressZusatz.Text = "Zusatz";
            // 
            // lblWohnsitzPostfach
            // 
            this.lblWohnsitzPostfach.ForeColor = System.Drawing.Color.Black;
            this.lblWohnsitzPostfach.Location = new System.Drawing.Point(5, 259);
            this.lblWohnsitzPostfach.Name = "lblWohnsitzPostfach";
            this.lblWohnsitzPostfach.Size = new System.Drawing.Size(77, 24);
            this.lblWohnsitzPostfach.TabIndex = 29;
            this.lblWohnsitzPostfach.Text = "Postfach";
            // 
            // lblPlzOrtKanton
            // 
            this.lblPlzOrtKanton.ForeColor = System.Drawing.Color.Black;
            this.lblPlzOrtKanton.Location = new System.Drawing.Point(5, 282);
            this.lblPlzOrtKanton.Name = "lblPlzOrtKanton";
            this.lblPlzOrtKanton.Size = new System.Drawing.Size(77, 24);
            this.lblPlzOrtKanton.TabIndex = 31;
            this.lblPlzOrtKanton.Text = "PLZ / Ort / Kt";
            // 
            // lblWohnsitzLandCode
            // 
            this.lblWohnsitzLandCode.ForeColor = System.Drawing.Color.Black;
            this.lblWohnsitzLandCode.Location = new System.Drawing.Point(5, 305);
            this.lblWohnsitzLandCode.Name = "lblWohnsitzLandCode";
            this.lblWohnsitzLandCode.Size = new System.Drawing.Size(77, 24);
            this.lblWohnsitzLandCode.TabIndex = 35;
            this.lblWohnsitzLandCode.Text = "Land";
            // 
            // lblStrasseNr
            // 
            this.lblStrasseNr.ForeColor = System.Drawing.Color.Black;
            this.lblStrasseNr.Location = new System.Drawing.Point(5, 236);
            this.lblStrasseNr.Name = "lblStrasseNr";
            this.lblStrasseNr.Size = new System.Drawing.Size(77, 24);
            this.lblStrasseNr.TabIndex = 26;
            this.lblStrasseNr.Text = "Strasse / Nr";
            // 
            // lblTitelPerson
            // 
            this.lblTitelPerson.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblTitelPerson.Location = new System.Drawing.Point(5, 160);
            this.lblTitelPerson.Name = "lblTitelPerson";
            this.lblTitelPerson.Size = new System.Drawing.Size(100, 16);
            this.lblTitelPerson.TabIndex = 20;
            this.lblTitelPerson.Text = "Person";
            // 
            // edtFaProzessCode
            // 
            this.edtFaProzessCode.DataMember = "FaProzessCode";
            this.edtFaProzessCode.DataSource = this.qryFaLeistung;
            this.edtFaProzessCode.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtFaProzessCode.Location = new System.Drawing.Point(85, 60);
            this.edtFaProzessCode.LOVFilterWhereAppend = true;
            this.edtFaProzessCode.LOVName = "FaProzess";
            this.edtFaProzessCode.Name = "edtFaProzessCode";
            this.edtFaProzessCode.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtFaProzessCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaProzessCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaProzessCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaProzessCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaProzessCode.Properties.Appearance.Options.UseFont = true;
            this.edtFaProzessCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtFaProzessCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaProzessCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtFaProzessCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtFaProzessCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFaProzessCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFaProzessCode.Properties.NullText = "";
            this.edtFaProzessCode.Properties.ReadOnly = true;
            this.edtFaProzessCode.Properties.ShowFooter = false;
            this.edtFaProzessCode.Properties.ShowHeader = false;
            this.edtFaProzessCode.Size = new System.Drawing.Size(223, 24);
            this.edtFaProzessCode.TabIndex = 4;
            // 
            // lblFaProzessCode
            // 
            this.lblFaProzessCode.ForeColor = System.Drawing.Color.Black;
            this.lblFaProzessCode.Location = new System.Drawing.Point(5, 60);
            this.lblFaProzessCode.Name = "lblFaProzessCode";
            this.lblFaProzessCode.Size = new System.Drawing.Size(74, 24);
            this.lblFaProzessCode.TabIndex = 3;
            this.lblFaProzessCode.Text = "Prozess";
            // 
            // edtEMail
            // 
            this.edtEMail.DataMember = "EMail";
            this.edtEMail.DataSource = this.qryFaLeistung;
            this.edtEMail.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtEMail.Location = new System.Drawing.Point(446, 120);
            this.edtEMail.Name = "edtEMail";
            this.edtEMail.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtEMail.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEMail.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEMail.Properties.Appearance.Options.UseBackColor = true;
            this.edtEMail.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEMail.Properties.Appearance.Options.UseFont = true;
            this.edtEMail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEMail.Properties.ReadOnly = true;
            this.edtEMail.Size = new System.Drawing.Size(233, 24);
            this.edtEMail.TabIndex = 19;
            // 
            // edtPhone
            // 
            this.edtPhone.DataMember = "Phone";
            this.edtPhone.DataSource = this.qryFaLeistung;
            this.edtPhone.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtPhone.Location = new System.Drawing.Point(446, 90);
            this.edtPhone.Name = "edtPhone";
            this.edtPhone.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPhone.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPhone.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPhone.Properties.Appearance.Options.UseBackColor = true;
            this.edtPhone.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPhone.Properties.Appearance.Options.UseFont = true;
            this.edtPhone.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPhone.Properties.ReadOnly = true;
            this.edtPhone.Size = new System.Drawing.Size(233, 24);
            this.edtPhone.TabIndex = 17;
            // 
            // edtAbteilung
            // 
            this.edtAbteilung.DataMember = "Abteilung";
            this.edtAbteilung.DataSource = this.qryFaLeistung;
            this.edtAbteilung.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAbteilung.Location = new System.Drawing.Point(446, 60);
            this.edtAbteilung.Name = "edtAbteilung";
            this.edtAbteilung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAbteilung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAbteilung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbteilung.Properties.Appearance.Options.UseBackColor = true;
            this.edtAbteilung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAbteilung.Properties.Appearance.Options.UseFont = true;
            this.edtAbteilung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAbteilung.Properties.ReadOnly = true;
            this.edtAbteilung.Size = new System.Drawing.Size(233, 24);
            this.edtAbteilung.TabIndex = 15;
            // 
            // lblEMail
            // 
            this.lblEMail.ForeColor = System.Drawing.Color.Black;
            this.lblEMail.Location = new System.Drawing.Point(371, 120);
            this.lblEMail.Name = "lblEMail";
            this.lblEMail.Size = new System.Drawing.Size(69, 24);
            this.lblEMail.TabIndex = 18;
            this.lblEMail.Text = "E-Mail";
            // 
            // lblPhone
            // 
            this.lblPhone.ForeColor = System.Drawing.Color.Black;
            this.lblPhone.Location = new System.Drawing.Point(371, 90);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(69, 24);
            this.lblPhone.TabIndex = 16;
            this.lblPhone.Text = "Telefon";
            // 
            // lblAbteilung
            // 
            this.lblAbteilung.ForeColor = System.Drawing.Color.Black;
            this.lblAbteilung.Location = new System.Drawing.Point(371, 60);
            this.lblAbteilung.Name = "lblAbteilung";
            this.lblAbteilung.Size = new System.Drawing.Size(69, 24);
            this.lblAbteilung.TabIndex = 14;
            this.lblAbteilung.Text = "Abteilung";
            // 
            // edtSAR
            // 
            this.edtSAR.DataMember = "SAR";
            this.edtSAR.DataSource = this.qryFaLeistung;
            this.edtSAR.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtSAR.Location = new System.Drawing.Point(446, 30);
            this.edtSAR.Name = "edtSAR";
            this.edtSAR.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSAR.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSAR.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSAR.Properties.Appearance.Options.UseBackColor = true;
            this.edtSAR.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSAR.Properties.Appearance.Options.UseFont = true;
            this.edtSAR.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSAR.Properties.ReadOnly = true;
            this.edtSAR.Size = new System.Drawing.Size(233, 24);
            this.edtSAR.TabIndex = 13;
            // 
            // lblSAR
            // 
            this.lblSAR.Location = new System.Drawing.Point(371, 30);
            this.lblSAR.Name = "lblSAR";
            this.lblSAR.Size = new System.Drawing.Size(69, 24);
            this.lblSAR.TabIndex = 12;
            this.lblSAR.Text = "Name";
            // 
            // lblTitelSar
            // 
            this.lblTitelSar.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblTitelSar.Location = new System.Drawing.Point(371, 5);
            this.lblTitelSar.Name = "lblTitelSar";
            this.lblTitelSar.Size = new System.Drawing.Size(285, 16);
            this.lblTitelSar.TabIndex = 11;
            this.lblTitelSar.Text = "SAR";
            // 
            // lblTitelFall
            // 
            this.lblTitelFall.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblTitelFall.Location = new System.Drawing.Point(5, 5);
            this.lblTitelFall.Name = "lblTitelFall";
            this.lblTitelFall.Size = new System.Drawing.Size(303, 16);
            this.lblTitelFall.TabIndex = 0;
            this.lblTitelFall.Text = "Fall";
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.DataMember = "DatumBis";
            this.edtDatumBis.DataSource = this.qryFaLeistung;
            this.edtDatumBis.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(217, 90);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.ReadOnly = true;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(91, 24);
            this.edtDatumBis.TabIndex = 8;
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.DataMember = "DatumVon";
            this.edtDatumVon.DataSource = this.qryFaLeistung;
            this.edtDatumVon.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(85, 90);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ReadOnly = true;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(91, 24);
            this.edtDatumVon.TabIndex = 6;
            // 
            // edtModulID
            // 
            this.edtModulID.DataMember = "ModulID";
            this.edtModulID.DataSource = this.qryFaLeistung;
            this.edtModulID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtModulID.Location = new System.Drawing.Point(85, 30);
            this.edtModulID.LOVName = "Modul";
            this.edtModulID.Name = "edtModulID";
            this.edtModulID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtModulID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtModulID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtModulID.Properties.Appearance.Options.UseBackColor = true;
            this.edtModulID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtModulID.Properties.Appearance.Options.UseFont = true;
            this.edtModulID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtModulID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtModulID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtModulID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtModulID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtModulID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtModulID.Properties.NullText = "";
            this.edtModulID.Properties.ReadOnly = true;
            this.edtModulID.Properties.ShowFooter = false;
            this.edtModulID.Properties.ShowHeader = false;
            this.edtModulID.Size = new System.Drawing.Size(223, 24);
            this.edtModulID.TabIndex = 2;
            // 
            // lblModulID
            // 
            this.lblModulID.ForeColor = System.Drawing.Color.Black;
            this.lblModulID.Location = new System.Drawing.Point(5, 30);
            this.lblModulID.Name = "lblModulID";
            this.lblModulID.Size = new System.Drawing.Size(74, 24);
            this.lblModulID.TabIndex = 1;
            this.lblModulID.Text = "Modul";
            // 
            // lblDatumBis
            // 
            this.lblDatumBis.Location = new System.Drawing.Point(187, 90);
            this.lblDatumBis.Name = "lblDatumBis";
            this.lblDatumBis.Size = new System.Drawing.Size(25, 24);
            this.lblDatumBis.TabIndex = 7;
            this.lblDatumBis.Text = "bis";
            // 
            // lblDatumVon
            // 
            this.lblDatumVon.Location = new System.Drawing.Point(5, 90);
            this.lblDatumVon.Name = "lblDatumVon";
            this.lblDatumVon.Size = new System.Drawing.Size(74, 24);
            this.lblDatumVon.TabIndex = 5;
            this.lblDatumVon.Text = "Datum von";
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(5, 190);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(77, 24);
            this.lblName.TabIndex = 21;
            this.lblName.Text = "Name";
            // 
            // tpgFaLeistungArchiv
            // 
            this.tpgFaLeistungArchiv.Controls.Add(this.edtCheckOut);
            this.tpgFaLeistungArchiv.Controls.Add(this.lblZurueckDurch);
            this.tpgFaLeistungArchiv.Controls.Add(this.edtCheckOutUserName);
            this.tpgFaLeistungArchiv.Controls.Add(this.lblCheckOut);
            this.tpgFaLeistungArchiv.Controls.Add(this.edtCheckIn);
            this.tpgFaLeistungArchiv.Controls.Add(this.lblArchiviertDurch);
            this.tpgFaLeistungArchiv.Controls.Add(this.edtCheckInUserName);
            this.tpgFaLeistungArchiv.Controls.Add(this.lblArchiviert);
            this.tpgFaLeistungArchiv.Controls.Add(this.edtArchivNr);
            this.tpgFaLeistungArchiv.Controls.Add(this.lblArchivNr);
            this.tpgFaLeistungArchiv.Controls.Add(this.edtStandort);
            this.tpgFaLeistungArchiv.Controls.Add(this.lblStandort);
            this.tpgFaLeistungArchiv.Controls.Add(this.lblTitelArchiv);
            this.tpgFaLeistungArchiv.Controls.Add(this.grdFaLeistungArchiv);
            this.tpgFaLeistungArchiv.Location = new System.Drawing.Point(6, 6);
            this.tpgFaLeistungArchiv.Name = "tpgFaLeistungArchiv";
            this.tpgFaLeistungArchiv.Size = new System.Drawing.Size(682, 423);
            this.tpgFaLeistungArchiv.TabIndex = 2;
            this.tpgFaLeistungArchiv.Title = "Archivierung";
            // 
            // edtCheckOut
            // 
            this.edtCheckOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtCheckOut.DataMember = "CheckOut";
            this.edtCheckOut.DataSource = this.qryFaLeistungArchiv;
            this.edtCheckOut.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtCheckOut.EditValue = null;
            this.edtCheckOut.Location = new System.Drawing.Point(75, 396);
            this.edtCheckOut.Name = "edtCheckOut";
            this.edtCheckOut.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtCheckOut.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtCheckOut.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtCheckOut.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtCheckOut.Properties.Appearance.Options.UseBackColor = true;
            this.edtCheckOut.Properties.Appearance.Options.UseBorderColor = true;
            this.edtCheckOut.Properties.Appearance.Options.UseFont = true;
            this.edtCheckOut.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtCheckOut.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtCheckOut.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtCheckOut.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtCheckOut.Properties.ReadOnly = true;
            this.edtCheckOut.Properties.ShowToday = false;
            this.edtCheckOut.Size = new System.Drawing.Size(95, 24);
            this.edtCheckOut.TabIndex = 11;
            // 
            // lblZurueckDurch
            // 
            this.lblZurueckDurch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblZurueckDurch.ForeColor = System.Drawing.Color.Black;
            this.lblZurueckDurch.Location = new System.Drawing.Point(176, 396);
            this.lblZurueckDurch.Name = "lblZurueckDurch";
            this.lblZurueckDurch.Size = new System.Drawing.Size(40, 24);
            this.lblZurueckDurch.TabIndex = 12;
            this.lblZurueckDurch.Text = "durch";
            // 
            // edtCheckOutUserName
            // 
            this.edtCheckOutUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtCheckOutUserName.DataMember = "CheckOutUserName";
            this.edtCheckOutUserName.DataSource = this.qryFaLeistungArchiv;
            this.edtCheckOutUserName.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtCheckOutUserName.Location = new System.Drawing.Point(222, 396);
            this.edtCheckOutUserName.Name = "edtCheckOutUserName";
            this.edtCheckOutUserName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtCheckOutUserName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtCheckOutUserName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtCheckOutUserName.Properties.Appearance.Options.UseBackColor = true;
            this.edtCheckOutUserName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtCheckOutUserName.Properties.Appearance.Options.UseFont = true;
            this.edtCheckOutUserName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtCheckOutUserName.Properties.ReadOnly = true;
            this.edtCheckOutUserName.Size = new System.Drawing.Size(232, 24);
            this.edtCheckOutUserName.TabIndex = 13;
            // 
            // lblCheckOut
            // 
            this.lblCheckOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCheckOut.ForeColor = System.Drawing.Color.Black;
            this.lblCheckOut.Location = new System.Drawing.Point(3, 396);
            this.lblCheckOut.Name = "lblCheckOut";
            this.lblCheckOut.Size = new System.Drawing.Size(66, 24);
            this.lblCheckOut.TabIndex = 10;
            this.lblCheckOut.Text = "zurück";
            // 
            // edtCheckIn
            // 
            this.edtCheckIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtCheckIn.DataMember = "CheckIn";
            this.edtCheckIn.DataSource = this.qryFaLeistungArchiv;
            this.edtCheckIn.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtCheckIn.EditValue = null;
            this.edtCheckIn.Location = new System.Drawing.Point(75, 366);
            this.edtCheckIn.Name = "edtCheckIn";
            this.edtCheckIn.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtCheckIn.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtCheckIn.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtCheckIn.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtCheckIn.Properties.Appearance.Options.UseBackColor = true;
            this.edtCheckIn.Properties.Appearance.Options.UseBorderColor = true;
            this.edtCheckIn.Properties.Appearance.Options.UseFont = true;
            this.edtCheckIn.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtCheckIn.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtCheckIn.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtCheckIn.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtCheckIn.Properties.ReadOnly = true;
            this.edtCheckIn.Properties.ShowToday = false;
            this.edtCheckIn.Size = new System.Drawing.Size(95, 24);
            this.edtCheckIn.TabIndex = 7;
            // 
            // lblArchiviertDurch
            // 
            this.lblArchiviertDurch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblArchiviertDurch.ForeColor = System.Drawing.Color.Black;
            this.lblArchiviertDurch.Location = new System.Drawing.Point(176, 366);
            this.lblArchiviertDurch.Name = "lblArchiviertDurch";
            this.lblArchiviertDurch.Size = new System.Drawing.Size(40, 24);
            this.lblArchiviertDurch.TabIndex = 8;
            this.lblArchiviertDurch.Text = "durch";
            // 
            // edtCheckInUserName
            // 
            this.edtCheckInUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtCheckInUserName.DataMember = "CheckInUserName";
            this.edtCheckInUserName.DataSource = this.qryFaLeistungArchiv;
            this.edtCheckInUserName.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtCheckInUserName.Location = new System.Drawing.Point(222, 366);
            this.edtCheckInUserName.Name = "edtCheckInUserName";
            this.edtCheckInUserName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtCheckInUserName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtCheckInUserName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtCheckInUserName.Properties.Appearance.Options.UseBackColor = true;
            this.edtCheckInUserName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtCheckInUserName.Properties.Appearance.Options.UseFont = true;
            this.edtCheckInUserName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtCheckInUserName.Properties.ReadOnly = true;
            this.edtCheckInUserName.Size = new System.Drawing.Size(232, 24);
            this.edtCheckInUserName.TabIndex = 9;
            // 
            // lblArchiviert
            // 
            this.lblArchiviert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblArchiviert.ForeColor = System.Drawing.Color.Black;
            this.lblArchiviert.Location = new System.Drawing.Point(3, 366);
            this.lblArchiviert.Name = "lblArchiviert";
            this.lblArchiviert.Size = new System.Drawing.Size(66, 24);
            this.lblArchiviert.TabIndex = 6;
            this.lblArchiviert.Text = "archiviert";
            // 
            // edtArchivNr
            // 
            this.edtArchivNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtArchivNr.DataMember = "ArchivNr";
            this.edtArchivNr.DataSource = this.qryFaLeistungArchiv;
            this.edtArchivNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtArchivNr.Location = new System.Drawing.Point(75, 336);
            this.edtArchivNr.Name = "edtArchivNr";
            this.edtArchivNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtArchivNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtArchivNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtArchivNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtArchivNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtArchivNr.Properties.Appearance.Options.UseFont = true;
            this.edtArchivNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtArchivNr.Properties.ReadOnly = true;
            this.edtArchivNr.Size = new System.Drawing.Size(192, 24);
            this.edtArchivNr.TabIndex = 5;
            // 
            // lblArchivNr
            // 
            this.lblArchivNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblArchivNr.ForeColor = System.Drawing.Color.Black;
            this.lblArchivNr.Location = new System.Drawing.Point(3, 336);
            this.lblArchivNr.Name = "lblArchivNr";
            this.lblArchivNr.Size = new System.Drawing.Size(66, 24);
            this.lblArchivNr.TabIndex = 4;
            this.lblArchivNr.Text = "Archiv-Nr.";
            // 
            // edtStandort
            // 
            this.edtStandort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtStandort.DataMember = "Standort";
            this.edtStandort.DataSource = this.qryFaLeistungArchiv;
            this.edtStandort.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtStandort.Location = new System.Drawing.Point(75, 306);
            this.edtStandort.Name = "edtStandort";
            this.edtStandort.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtStandort.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStandort.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStandort.Properties.Appearance.Options.UseBackColor = true;
            this.edtStandort.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStandort.Properties.Appearance.Options.UseFont = true;
            this.edtStandort.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStandort.Properties.ReadOnly = true;
            this.edtStandort.Size = new System.Drawing.Size(379, 24);
            this.edtStandort.TabIndex = 3;
            // 
            // lblStandort
            // 
            this.lblStandort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStandort.ForeColor = System.Drawing.Color.Black;
            this.lblStandort.Location = new System.Drawing.Point(3, 306);
            this.lblStandort.Name = "lblStandort";
            this.lblStandort.Size = new System.Drawing.Size(66, 24);
            this.lblStandort.TabIndex = 2;
            this.lblStandort.Text = "Standort";
            // 
            // lblTitelArchiv
            // 
            this.lblTitelArchiv.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblTitelArchiv.Location = new System.Drawing.Point(5, 5);
            this.lblTitelArchiv.Name = "lblTitelArchiv";
            this.lblTitelArchiv.Size = new System.Drawing.Size(100, 16);
            this.lblTitelArchiv.TabIndex = 0;
            this.lblTitelArchiv.Text = "Archiv-History";
            // 
            // grdFaLeistungArchiv
            // 
            this.grdFaLeistungArchiv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdFaLeistungArchiv.DataSource = this.qryFaLeistungArchiv;
            // 
            // 
            // 
            this.grdFaLeistungArchiv.EmbeddedNavigator.Name = "";
            this.grdFaLeistungArchiv.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdFaLeistungArchiv.Location = new System.Drawing.Point(3, 24);
            this.grdFaLeistungArchiv.MainView = this.grvFaLeistungArchiv;
            this.grdFaLeistungArchiv.Name = "grdFaLeistungArchiv";
            this.grdFaLeistungArchiv.Size = new System.Drawing.Size(676, 276);
            this.grdFaLeistungArchiv.TabIndex = 1;
            this.grdFaLeistungArchiv.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvFaLeistungArchiv});
            // 
            // grvFaLeistungArchiv
            // 
            this.grvFaLeistungArchiv.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvFaLeistungArchiv.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistungArchiv.Appearance.Empty.Options.UseBackColor = true;
            this.grvFaLeistungArchiv.Appearance.Empty.Options.UseFont = true;
            this.grvFaLeistungArchiv.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvFaLeistungArchiv.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistungArchiv.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvFaLeistungArchiv.Appearance.EvenRow.Options.UseFont = true;
            this.grvFaLeistungArchiv.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFaLeistungArchiv.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistungArchiv.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvFaLeistungArchiv.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvFaLeistungArchiv.Appearance.FocusedCell.Options.UseFont = true;
            this.grvFaLeistungArchiv.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvFaLeistungArchiv.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFaLeistungArchiv.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistungArchiv.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvFaLeistungArchiv.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvFaLeistungArchiv.Appearance.FocusedRow.Options.UseFont = true;
            this.grvFaLeistungArchiv.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvFaLeistungArchiv.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFaLeistungArchiv.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvFaLeistungArchiv.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFaLeistungArchiv.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFaLeistungArchiv.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFaLeistungArchiv.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvFaLeistungArchiv.Appearance.GroupRow.Options.UseFont = true;
            this.grvFaLeistungArchiv.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvFaLeistungArchiv.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvFaLeistungArchiv.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvFaLeistungArchiv.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFaLeistungArchiv.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvFaLeistungArchiv.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvFaLeistungArchiv.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvFaLeistungArchiv.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvFaLeistungArchiv.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistungArchiv.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFaLeistungArchiv.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvFaLeistungArchiv.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvFaLeistungArchiv.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvFaLeistungArchiv.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvFaLeistungArchiv.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvFaLeistungArchiv.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvFaLeistungArchiv.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistungArchiv.Appearance.OddRow.Options.UseBackColor = true;
            this.grvFaLeistungArchiv.Appearance.OddRow.Options.UseFont = true;
            this.grvFaLeistungArchiv.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvFaLeistungArchiv.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistungArchiv.Appearance.Row.Options.UseBackColor = true;
            this.grvFaLeistungArchiv.Appearance.Row.Options.UseFont = true;
            this.grvFaLeistungArchiv.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvFaLeistungArchiv.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistungArchiv.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvFaLeistungArchiv.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvFaLeistungArchiv.Appearance.SelectedRow.Options.UseFont = true;
            this.grvFaLeistungArchiv.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvFaLeistungArchiv.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvFaLeistungArchiv.Appearance.VertLine.Options.UseBackColor = true;
            this.grvFaLeistungArchiv.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvFaLeistungArchiv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStandort,
            this.colArchivNr,
            this.colCheckIn,
            this.colCheckOut});
            this.grvFaLeistungArchiv.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvFaLeistungArchiv.GridControl = this.grdFaLeistungArchiv;
            this.grvFaLeistungArchiv.Name = "grvFaLeistungArchiv";
            this.grvFaLeistungArchiv.OptionsBehavior.Editable = false;
            this.grvFaLeistungArchiv.OptionsCustomization.AllowFilter = false;
            this.grvFaLeistungArchiv.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvFaLeistungArchiv.OptionsNavigation.AutoFocusNewRow = true;
            this.grvFaLeistungArchiv.OptionsNavigation.UseTabKey = false;
            this.grvFaLeistungArchiv.OptionsView.ColumnAutoWidth = false;
            this.grvFaLeistungArchiv.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvFaLeistungArchiv.OptionsView.ShowGroupPanel = false;
            this.grvFaLeistungArchiv.OptionsView.ShowIndicator = false;
            // 
            // colStandort
            // 
            this.colStandort.Caption = "Standort";
            this.colStandort.FieldName = "Standort";
            this.colStandort.Name = "colStandort";
            this.colStandort.Visible = true;
            this.colStandort.VisibleIndex = 0;
            this.colStandort.Width = 267;
            // 
            // colArchivNr
            // 
            this.colArchivNr.Caption = "ArchivNr";
            this.colArchivNr.FieldName = "ArchivNr";
            this.colArchivNr.Name = "colArchivNr";
            this.colArchivNr.Visible = true;
            this.colArchivNr.VisibleIndex = 1;
            this.colArchivNr.Width = 117;
            // 
            // colCheckIn
            // 
            this.colCheckIn.Caption = "archiviert";
            this.colCheckIn.FieldName = "CheckIn";
            this.colCheckIn.Name = "colCheckIn";
            this.colCheckIn.Visible = true;
            this.colCheckIn.VisibleIndex = 2;
            this.colCheckIn.Width = 71;
            // 
            // colCheckOut
            // 
            this.colCheckOut.Caption = "zurück";
            this.colCheckOut.FieldName = "CheckOut";
            this.colCheckOut.Name = "colCheckOut";
            this.colCheckOut.Visible = true;
            this.colCheckOut.VisibleIndex = 3;
            // 
            // tpgZustaendigkeit
            // 
            this.tpgZustaendigkeit.Controls.Add(this.kissLabel1);
            this.tpgZustaendigkeit.Controls.Add(this.grdZustaendigkeit);
            this.tpgZustaendigkeit.Location = new System.Drawing.Point(6, 6);
            this.tpgZustaendigkeit.Name = "tpgZustaendigkeit";
            this.tpgZustaendigkeit.Size = new System.Drawing.Size(682, 423);
            this.tpgZustaendigkeit.TabIndex = 3;
            this.tpgZustaendigkeit.Title = "Liste Zuständigkeit";
            // 
            // kissLabel1
            // 
            this.kissLabel1.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel1.Location = new System.Drawing.Point(5, 5);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(200, 16);
            this.kissLabel1.TabIndex = 1;
            this.kissLabel1.Text = "Liste Zuständigkeit";
            // 
            // grdZustaendigkeit
            // 
            this.grdZustaendigkeit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdZustaendigkeit.DataSource = this.qryZustaendigkeit;
            // 
            // 
            // 
            this.grdZustaendigkeit.EmbeddedNavigator.Name = "";
            this.grdZustaendigkeit.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdZustaendigkeit.Location = new System.Drawing.Point(3, 24);
            this.grdZustaendigkeit.MainView = this.grvZustaendigkeit;
            this.grdZustaendigkeit.Name = "grdZustaendigkeit";
            this.grdZustaendigkeit.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repModulIcon});
            this.grdZustaendigkeit.Size = new System.Drawing.Size(676, 396);
            this.grdZustaendigkeit.TabIndex = 0;
            this.grdZustaendigkeit.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvZustaendigkeit});
            // 
            // qryZustaendigkeit
            // 
            this.qryZustaendigkeit.HostControl = this;
            this.qryZustaendigkeit.SelectStatement = resources.GetString("qryZustaendigkeit.SelectStatement");
            // 
            // grvZustaendigkeit
            // 
            this.grvZustaendigkeit.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvZustaendigkeit.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZustaendigkeit.Appearance.Empty.Options.UseBackColor = true;
            this.grvZustaendigkeit.Appearance.Empty.Options.UseFont = true;
            this.grvZustaendigkeit.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZustaendigkeit.Appearance.EvenRow.Options.UseFont = true;
            this.grvZustaendigkeit.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvZustaendigkeit.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZustaendigkeit.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvZustaendigkeit.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvZustaendigkeit.Appearance.FocusedCell.Options.UseFont = true;
            this.grvZustaendigkeit.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvZustaendigkeit.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvZustaendigkeit.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZustaendigkeit.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvZustaendigkeit.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvZustaendigkeit.Appearance.FocusedRow.Options.UseFont = true;
            this.grvZustaendigkeit.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvZustaendigkeit.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZustaendigkeit.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvZustaendigkeit.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZustaendigkeit.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvZustaendigkeit.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZustaendigkeit.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvZustaendigkeit.Appearance.GroupRow.Options.UseFont = true;
            this.grvZustaendigkeit.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvZustaendigkeit.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvZustaendigkeit.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvZustaendigkeit.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvZustaendigkeit.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvZustaendigkeit.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvZustaendigkeit.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvZustaendigkeit.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvZustaendigkeit.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZustaendigkeit.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZustaendigkeit.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvZustaendigkeit.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvZustaendigkeit.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvZustaendigkeit.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvZustaendigkeit.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvZustaendigkeit.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZustaendigkeit.Appearance.OddRow.Options.UseFont = true;
            this.grvZustaendigkeit.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvZustaendigkeit.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZustaendigkeit.Appearance.Row.Options.UseBackColor = true;
            this.grvZustaendigkeit.Appearance.Row.Options.UseFont = true;
            this.grvZustaendigkeit.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZustaendigkeit.Appearance.SelectedRow.Options.UseFont = true;
            this.grvZustaendigkeit.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvZustaendigkeit.Appearance.VertLine.Options.UseBackColor = true;
            this.grvZustaendigkeit.BestFitMaxRowCount = 1000;
            this.grvZustaendigkeit.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvZustaendigkeit.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colZustModul,
            this.colZustDatumVon,
            this.colZustDatumBis,
            this.colZustZustaendigkeit});
            this.grvZustaendigkeit.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvZustaendigkeit.GridControl = this.grdZustaendigkeit;
            this.grvZustaendigkeit.Name = "grvZustaendigkeit";
            this.grvZustaendigkeit.OptionsBehavior.Editable = false;
            this.grvZustaendigkeit.OptionsCustomization.AllowFilter = false;
            this.grvZustaendigkeit.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvZustaendigkeit.OptionsNavigation.AutoFocusNewRow = true;
            this.grvZustaendigkeit.OptionsNavigation.UseTabKey = false;
            this.grvZustaendigkeit.OptionsView.ColumnAutoWidth = false;
            this.grvZustaendigkeit.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvZustaendigkeit.OptionsView.ShowGroupPanel = false;
            this.grvZustaendigkeit.OptionsView.ShowIndicator = false;
            // 
            // colZustModul
            // 
            this.colZustModul.Caption = "Modul";
            this.colZustModul.ColumnEdit = this.repModulIcon;
            this.colZustModul.FieldName = "IconID";
            this.colZustModul.Name = "colZustModul";
            this.colZustModul.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            this.colZustModul.Visible = true;
            this.colZustModul.VisibleIndex = 0;
            this.colZustModul.Width = 60;
            // 
            // repModulIcon
            // 
            this.repModulIcon.AutoHeight = false;
            this.repModulIcon.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repModulIcon.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repModulIcon.Name = "repModulIcon";
            // 
            // colZustDatumVon
            // 
            this.colZustDatumVon.Caption = "Datum von";
            this.colZustDatumVon.FieldName = "DatumVon";
            this.colZustDatumVon.Name = "colZustDatumVon";
            this.colZustDatumVon.Visible = true;
            this.colZustDatumVon.VisibleIndex = 1;
            this.colZustDatumVon.Width = 85;
            // 
            // colZustDatumBis
            // 
            this.colZustDatumBis.Caption = "Datum bis";
            this.colZustDatumBis.FieldName = "DatumBis";
            this.colZustDatumBis.Name = "colZustDatumBis";
            this.colZustDatumBis.Visible = true;
            this.colZustDatumBis.VisibleIndex = 2;
            this.colZustDatumBis.Width = 85;
            // 
            // colZustZustaendigkeit
            // 
            this.colZustZustaendigkeit.Caption = "Zuständigkeit";
            this.colZustZustaendigkeit.FieldName = "SAR";
            this.colZustZustaendigkeit.Name = "colZustZustaendigkeit";
            this.colZustZustaendigkeit.Visible = true;
            this.colZustZustaendigkeit.VisibleIndex = 3;
            this.colZustZustaendigkeit.Width = 250;
            // 
            // tpgGastrecht
            // 
            this.tpgGastrecht.Controls.Add(this.lblGastrecht);
            this.tpgGastrecht.Controls.Add(this.grdGastrecht);
            this.tpgGastrecht.Location = new System.Drawing.Point(6, 6);
            this.tpgGastrecht.Name = "tpgGastrecht";
            this.tpgGastrecht.Size = new System.Drawing.Size(682, 423);
            this.tpgGastrecht.TabIndex = 4;
            this.tpgGastrecht.Title = "Liste Gastrecht";
            // 
            // lblGastrecht
            // 
            this.lblGastrecht.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblGastrecht.Location = new System.Drawing.Point(5, 5);
            this.lblGastrecht.Name = "lblGastrecht";
            this.lblGastrecht.Size = new System.Drawing.Size(200, 16);
            this.lblGastrecht.TabIndex = 2;
            this.lblGastrecht.Text = "Liste Gastrecht";
            // 
            // grdGastrecht
            // 
            this.grdGastrecht.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdGastrecht.DataSource = this.qryGastrecht;
            // 
            // 
            // 
            this.grdGastrecht.EmbeddedNavigator.Name = "";
            this.grdGastrecht.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdGastrecht.Location = new System.Drawing.Point(3, 24);
            this.grdGastrecht.MainView = this.grvGastrecht;
            this.grdGastrecht.Name = "grdGastrecht";
            this.grdGastrecht.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repModulIconGastrecht});
            this.grdGastrecht.Size = new System.Drawing.Size(676, 396);
            this.grdGastrecht.TabIndex = 1;
            this.grdGastrecht.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvGastrecht});
            // 
            // qryGastrecht
            // 
            this.qryGastrecht.HostControl = this;
            this.qryGastrecht.SelectStatement = resources.GetString("qryGastrecht.SelectStatement");
            // 
            // grvGastrecht
            // 
            this.grvGastrecht.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvGastrecht.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGastrecht.Appearance.Empty.Options.UseBackColor = true;
            this.grvGastrecht.Appearance.Empty.Options.UseFont = true;
            this.grvGastrecht.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGastrecht.Appearance.EvenRow.Options.UseFont = true;
            this.grvGastrecht.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvGastrecht.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGastrecht.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvGastrecht.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvGastrecht.Appearance.FocusedCell.Options.UseFont = true;
            this.grvGastrecht.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvGastrecht.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvGastrecht.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGastrecht.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvGastrecht.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvGastrecht.Appearance.FocusedRow.Options.UseFont = true;
            this.grvGastrecht.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvGastrecht.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvGastrecht.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvGastrecht.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvGastrecht.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvGastrecht.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvGastrecht.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvGastrecht.Appearance.GroupRow.Options.UseFont = true;
            this.grvGastrecht.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvGastrecht.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvGastrecht.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvGastrecht.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvGastrecht.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvGastrecht.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvGastrecht.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvGastrecht.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvGastrecht.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGastrecht.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvGastrecht.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvGastrecht.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvGastrecht.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvGastrecht.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvGastrecht.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvGastrecht.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGastrecht.Appearance.OddRow.Options.UseFont = true;
            this.grvGastrecht.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvGastrecht.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGastrecht.Appearance.Row.Options.UseBackColor = true;
            this.grvGastrecht.Appearance.Row.Options.UseFont = true;
            this.grvGastrecht.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGastrecht.Appearance.SelectedRow.Options.UseFont = true;
            this.grvGastrecht.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvGastrecht.Appearance.VertLine.Options.UseBackColor = true;
            this.grvGastrecht.BestFitMaxRowCount = 1000;
            this.grvGastrecht.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvGastrecht.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colGastModulId,
            this.colGastDatumVon,
            this.colGastDatumBis,
            this.colGastSAR,
            this.colGastDarfMutieren});
            this.grvGastrecht.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvGastrecht.GridControl = this.grdGastrecht;
            this.grvGastrecht.Name = "grvGastrecht";
            this.grvGastrecht.OptionsBehavior.Editable = false;
            this.grvGastrecht.OptionsCustomization.AllowFilter = false;
            this.grvGastrecht.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvGastrecht.OptionsNavigation.AutoFocusNewRow = true;
            this.grvGastrecht.OptionsNavigation.UseTabKey = false;
            this.grvGastrecht.OptionsView.ColumnAutoWidth = false;
            this.grvGastrecht.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvGastrecht.OptionsView.ShowGroupPanel = false;
            this.grvGastrecht.OptionsView.ShowIndicator = false;
            // 
            // colGastModulId
            // 
            this.colGastModulId.Caption = "Modul";
            this.colGastModulId.ColumnEdit = this.repModulIconGastrecht;
            this.colGastModulId.FieldName = "IconID";
            this.colGastModulId.Name = "colGastModulId";
            this.colGastModulId.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            this.colGastModulId.Visible = true;
            this.colGastModulId.VisibleIndex = 0;
            this.colGastModulId.Width = 60;
            // 
            // repModulIconGastrecht
            // 
            this.repModulIconGastrecht.AutoHeight = false;
            this.repModulIconGastrecht.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repModulIconGastrecht.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repModulIconGastrecht.Name = "repModulIconGastrecht";
            // 
            // colGastDatumVon
            // 
            this.colGastDatumVon.Caption = "Datum von";
            this.colGastDatumVon.FieldName = "DatumVon";
            this.colGastDatumVon.Name = "colGastDatumVon";
            this.colGastDatumVon.Visible = true;
            this.colGastDatumVon.VisibleIndex = 1;
            this.colGastDatumVon.Width = 85;
            // 
            // colGastDatumBis
            // 
            this.colGastDatumBis.Caption = "Datum bis";
            this.colGastDatumBis.FieldName = "DatumBis";
            this.colGastDatumBis.Name = "colGastDatumBis";
            this.colGastDatumBis.Visible = true;
            this.colGastDatumBis.VisibleIndex = 2;
            this.colGastDatumBis.Width = 85;
            // 
            // colGastSAR
            // 
            this.colGastSAR.Caption = "Mitarbeiter/-in";
            this.colGastSAR.FieldName = "SAR";
            this.colGastSAR.Name = "colGastSAR";
            this.colGastSAR.Visible = true;
            this.colGastSAR.VisibleIndex = 3;
            this.colGastSAR.Width = 250;
            // 
            // colGastDarfMutieren
            // 
            this.colGastDarfMutieren.Caption = "Mutieren";
            this.colGastDarfMutieren.FieldName = "DarfMutieren";
            this.colGastDarfMutieren.Name = "colGastDarfMutieren";
            this.colGastDarfMutieren.Visible = true;
            this.colGastDarfMutieren.VisibleIndex = 4;
            // 
            // CtlFallInfo
            // 
            this.ActiveSQLQuery = this.qryFaLeistung;
            this.ClientSize = new System.Drawing.Size(983, 485);
            this.Controls.Add(this.panRight);
            this.Controls.Add(this.treFaLeistung);
            this.Name = "CtlFallInfo";
            this.Text = "Fallinfo";
            this.Load += new System.EventHandler(this.CtlFallInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryFaLeistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaLeistungArchiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treFaLeistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            this.panRight.ResumeLayout(false);
            this.tabFallinfo.ResumeLayout(false);
            this.tpgFaLeistung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtVersNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMobilTel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefonG.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefon_G)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMobilTel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSterbedatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSterbedatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtsdatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAHVNummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsdatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefonP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAHVNummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefon_P)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFallCheckIn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCheckIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitzOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitzLandCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitzLandCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitzKanton.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitzPLZ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitzPostfach.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitzHausNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitzAdressZusatz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitzStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWohnsitzAdressZusatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWohnsitzPostfach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPlzOrtKanton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWohnsitzLandCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStrasseNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitelPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaProzessCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaProzessCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaProzessCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEMail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbteilung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEMail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbteilung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSAR.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitelSar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitelFall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModulID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            this.tpgFaLeistungArchiv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtCheckOut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZurueckDurch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCheckOutUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCheckOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCheckIn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblArchiviertDurch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCheckInUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblArchiviert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtArchivNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblArchivNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStandort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStandort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitelArchiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFaLeistungArchiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFaLeistungArchiv)).EndInit();
            this.tpgZustaendigkeit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZustaendigkeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZustaendigkeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZustaendigkeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repModulIcon)).EndInit();
            this.tpgGastrecht.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblGastrecht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGastrecht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryGastrecht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvGastrecht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repModulIconGastrecht)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissButton btnOK;
        private DevExpress.XtraGrid.Columns.GridColumn colArchivNr;
        private DevExpress.XtraGrid.Columns.GridColumn colCheckIn;
        private DevExpress.XtraGrid.Columns.GridColumn colCheckOut;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDatumVon;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colFaFallID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSAR;
        private DevExpress.XtraGrid.Columns.GridColumn colStandort;
        private KiSS4.Gui.KissTextEdit edtAHVNummer;
        private KiSS4.Gui.KissTextEdit edtAbteilung;
        private KiSS4.Gui.KissTextEdit edtArchivNr;
        private KiSS4.Gui.KissRTFEdit edtBemerkung;
        private KiSS4.Gui.KissDateEdit edtFallCheckIn;
        private KiSS4.Gui.KissTextEdit edtCheckInUserName;
        private KiSS4.Gui.KissDateEdit edtCheckOut;
        private KiSS4.Gui.KissTextEdit edtCheckOutUserName;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissTextEdit edtEMail;
        private KiSS4.Gui.KissLookUpEdit edtFaProzessCode;
        private KiSS4.Gui.KissDateEdit edtGeburtsdatum;
        private KiSS4.Gui.KissTextEdit edtMobilTel;
        private KiSS4.Gui.KissLookUpEdit edtModulID;
        private KiSS4.Gui.KissTextEdit edtName;
        private KiSS4.Gui.KissTextEdit edtPhone;
        private KiSS4.Gui.KissTextEdit edtSAR;
        private KiSS4.Gui.KissTextEdit edtStandort;
        private KiSS4.Gui.KissDateEdit edtSterbedatum;
        private KiSS4.Gui.KissTextEdit edtTelefonG;
        private KiSS4.Gui.KissTextEdit edtTelefonP;
        private KiSS4.Gui.KissTextEdit edtVersNr;
        private KiSS4.Gui.KissTextEdit edtVorname;
        private KiSS4.Gui.KissTextEdit edtWohnsitzAdressZusatz;
        private KiSS4.Gui.KissTextEdit edtWohnsitzHausNr;
        private KiSS4.Gui.KissTextEdit edtWohnsitzKanton;
        private KiSS4.Gui.KissLookUpEdit edtWohnsitzLandCode;
        private KiSS4.Gui.KissTextEdit edtWohnsitzOrt;
        private KiSS4.Gui.KissTextEdit edtWohnsitzPLZ;
        private KiSS4.Gui.KissTextEdit edtWohnsitzPostfach;
        private KiSS4.Gui.KissTextEdit edtWohnsitzStrasse;
        private KiSS4.Gui.KissGrid grdFaLeistungArchiv;
        private DevExpress.XtraGrid.Views.Grid.GridView grvFaLeistungArchiv;
        private KiSS4.Gui.KissDateEdit edtCheckIn;
        private KiSS4.Gui.KissLabel lblTitelArchiv;
        private KiSS4.Gui.KissLabel lblTitelPerson;
        private KiSS4.Gui.KissLabel lblName;
        private KiSS4.Gui.KissLabel lblPlzOrtKanton;
        private KiSS4.Gui.KissLabel lblArchiviert;
        private KiSS4.Gui.KissLabel lblStrasseNr;
        private KiSS4.Gui.KissLabel lblTitelFall;
        private KiSS4.Gui.KissLabel lblArchiviertDurch;
        private KiSS4.Gui.KissLabel lblZurueckDurch;
        private KiSS4.Gui.KissLabel lblTitelSar;
        private KiSS4.Gui.KissLabel lblAHVNummer;
        private KiSS4.Gui.KissLabel lblAbteilung;
        private KiSS4.Gui.KissLabel lblArchivNr;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblCheckIn;
        private KiSS4.Gui.KissLabel lblDatumBis;
        private KiSS4.Gui.KissLabel lblDatumVon;
        private KiSS4.Gui.KissLabel lblEMail;
        private KiSS4.Gui.KissLabel lblFaProzessCode;
        private KiSS4.Gui.KissLabel lblGeburtsdatum;
        private KiSS4.Gui.KissLabel lblMobilTel;
        private KiSS4.Gui.KissLabel lblModulID;
        private KiSS4.Gui.KissLabel lblPhone;
        private KiSS4.Gui.KissLabel lblSAR;
        private KiSS4.Gui.KissLabel lblStandort;
        private KiSS4.Gui.KissLabel lblSterbedatum;
        private KiSS4.Gui.KissLabel lblTelefon_G;
        private KiSS4.Gui.KissLabel lblTelefon_P;
        private KiSS4.Gui.KissLabel lblVersNr;
        private KiSS4.Gui.KissLabel lblWohnsitzAdressZusatz;
        private KiSS4.Gui.KissLabel lblWohnsitzLandCode;
        private KiSS4.Gui.KissLabel lblWohnsitzPostfach;
        private KiSS4.Gui.KissLabel lblCheckOut;
        private System.Windows.Forms.Panel panRight;
        private KiSS4.DB.SqlQuery qryBaPerson;
        private KiSS4.DB.SqlQuery qryFaLeistung;
        private KiSS4.DB.SqlQuery qryFaLeistungArchiv;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private KiSS4.Gui.KissTabControlEx tabFallinfo;
        private SharpLibrary.WinControls.TabPageEx tpgFaLeistung;
        private SharpLibrary.WinControls.TabPageEx tpgFaLeistungArchiv;
        private KiSS4.Gui.KissTree treFaLeistung;
        private SharpLibrary.WinControls.TabPageEx tpgZustaendigkeit;
        private Gui.KissGrid grdZustaendigkeit;
        private Gui.KissLabel kissLabel1;
        private DevExpress.XtraGrid.Views.Grid.GridView grvZustaendigkeit;
        private DevExpress.XtraGrid.Columns.GridColumn colZustModul;
        private DevExpress.XtraGrid.Columns.GridColumn colZustDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colZustDatumBis;
        private DevExpress.XtraGrid.Columns.GridColumn colZustZustaendigkeit;
        private DB.SqlQuery qryZustaendigkeit;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repModulIcon;
        private SharpLibrary.WinControls.TabPageEx tpgGastrecht;
        private Gui.KissLabel lblGastrecht;
        private Gui.KissGrid grdGastrecht;
        private DevExpress.XtraGrid.Views.Grid.GridView grvGastrecht;
        private DevExpress.XtraGrid.Columns.GridColumn colGastModulId;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repModulIconGastrecht;
        private DevExpress.XtraGrid.Columns.GridColumn colGastDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colGastDatumBis;
        private DevExpress.XtraGrid.Columns.GridColumn colGastSAR;
        private DB.SqlQuery qryGastrecht;
        private DevExpress.XtraGrid.Columns.GridColumn colGastDarfMutieren;
    }
}
