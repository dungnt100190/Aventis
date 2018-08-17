namespace KiSS4.FAMOZ.VIS
{
    public partial class CtlVISMassnahme
    {
        #region Fields

        #region Private Fields

        private DevExpress.XtraGrid.Columns.GridColumn colBHAusgangSDS;
        private DevExpress.XtraGrid.Columns.GridColumn colBHBemerkung;
        private DevExpress.XtraGrid.Columns.GridColumn colBHDatumBerichtMT;
        private DevExpress.XtraGrid.Columns.GridColumn colBHDatumBis;
        private DevExpress.XtraGrid.Columns.GridColumn colBHDatumVersandAnVB;
        private DevExpress.XtraGrid.Columns.GridColumn colBHDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colBHEingangSDS;
        private DevExpress.XtraGrid.Columns.GridColumn colBHFristerstreckung;
        private DevExpress.XtraGrid.Columns.GridColumn colBHGenehmigung1;
        private DevExpress.XtraGrid.Columns.GridColumn colBHGenehmigung2;
        private DevExpress.XtraGrid.Columns.GridColumn colBHMahnung1;
        private DevExpress.XtraGrid.Columns.GridColumn colBHMahnung2;
        private DevExpress.XtraGrid.Columns.GridColumn colBHMahnung3;
        private DevExpress.XtraGrid.Columns.GridColumn colBHMAKlibu;
        private DevExpress.XtraGrid.Columns.GridColumn colBHMandatsTraegerName;
        private DevExpress.XtraGrid.Columns.GridColumn colBHSpesen;
        private DevExpress.XtraGrid.Columns.GridColumn colBPAufhebung;
        private DevExpress.XtraGrid.Columns.GridColumn colBPBerichtsart;
        private DevExpress.XtraGrid.Columns.GridColumn colBPDatumBis;
        private DevExpress.XtraGrid.Columns.GridColumn colBPDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colBPErnennung;
        private DevExpress.XtraGrid.Columns.GridColumn colBPMT;
        private DevExpress.XtraGrid.Columns.GridColumn colBPUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colMHAufhebung;
        private DevExpress.XtraGrid.Columns.GridColumn colMHBeschluss;
        private DevExpress.XtraGrid.Columns.GridColumn colMHMassnahme;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Dokument.XDokument docBericht;
        private KiSS4.Dokument.XDokument docBerichtHist;
        private KiSS4.Dokument.XDokument docVermoegensabrechnung;
        private KiSS4.Gui.KissDateEdit edtAufhebung;
        private KiSS4.Gui.KissMemoEdit edtBemerkung;
        private KiSS4.Gui.KissTextEdit edtBerichtsart;
        private KiSS4.Gui.KissDateEdit edtBerichtsperiodeBis;
        private KiSS4.Gui.KissDateEdit edtBerichtsperiodeVon;
        private KiSS4.Gui.KissDateEdit edtDatumAusgangSDS;
        private KiSS4.Gui.KissDateEdit edtDatumBerichtMT;
        private KiSS4.Gui.KissDateEdit edtDatumEingangSDS;
        private KiSS4.Gui.KissDateEdit edtDatumFristerstreckung;
        private KiSS4.Gui.KissDateEdit edtDatumGenehmigung1;
        private KiSS4.Gui.KissDateEdit edtDatumVersandAnVB;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissButtonEdit edtMaKlibuUser;
        private KiSS4.Gui.KissGrid grdBerichtsperioden;
        private KiSS4.Gui.KissGrid grdVmBericht;
        private KiSS4.Gui.KissGrid Grid1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVmBericht;
        private KiSS4.Gui.KissDateEdit kissDateEdit2;
        private KiSS4.Gui.KissDateEdit kissDateEdit3;
        private KiSS4.Gui.KissDateEdit kissDateEdit4;
        private KiSS4.Gui.KissLabel kissLabel1;
        private KiSS4.Gui.KissLabel kissLabel10;
        private KiSS4.Gui.KissLabel kissLabel11;
        private KiSS4.Gui.KissLabel kissLabel12;
        private KiSS4.Gui.KissLabel kissLabel2;
        private KiSS4.Gui.KissLabel kissLabel4;
        private KiSS4.Gui.KissLabel kissLabel5;
        private KiSS4.Gui.KissLabel kissLabel6;
        private KiSS4.Gui.KissLabel kissLabel7;
        private KiSS4.Gui.KissLabel kissLabel8;
        private KiSS4.Gui.KissLabel kissLabel9;
        private KiSS4.Gui.KissTextEdit kissTextEdit2;
        private KiSS4.Gui.KissTextEdit kissTextEdit3;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblDatumAusgangSDS;
        private KiSS4.Gui.KissLabel lblDatumBerichtMT;
        private KiSS4.Gui.KissLabel lblDatumBis;
        private KiSS4.Gui.KissLabel lblDatumEingangSDS;
        private KiSS4.Gui.KissLabel lblDatumFristerstreckung;
        private KiSS4.Gui.KissLabel lblDatumGenehmigung1;
        private KiSS4.Gui.KissLabel lblDatumVersandAnVB;
        private KiSS4.Gui.KissLabel lblDatumVon;
        private KiSS4.Gui.KissLabel lblSucheUserID;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissLabel lblVermoegensabrechnung;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryBericht;
        private KiSS4.DB.SqlQuery qryBerichtHistory;
        private KiSS4.DB.SqlQuery qryVmBerichtsperioden;
        private KiSS4.DB.SqlQuery qryVmMassnahme;
        private KiSS4.DB.SqlQuery qryVmMassnahmeHistory;
        private KiSS4.Gui.KissTabControlEx tabBerichte;
        private KiSS4.Gui.KissTabControlEx tabMassnahmen;
        private SharpLibrary.WinControls.TabPageEx tbpBericht;
        private SharpLibrary.WinControls.TabPageEx tbpBerichtHist;
        private SharpLibrary.WinControls.TabPageEx tbpMassnahme;
        private SharpLibrary.WinControls.TabPageEx tbpMassnahmeHist;

        #endregion

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject22 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject23 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlVISMassnahme));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
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
            this.Grid1 = new KiSS4.Gui.KissGrid();
            this.qryVmMassnahmeHistory = new KiSS4.DB.SqlQuery();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMHBeschluss = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMHAufhebung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMHMassnahme = new DevExpress.XtraGrid.Columns.GridColumn();
            this.qryVmMassnahme = new KiSS4.DB.SqlQuery();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtAufhebung = new KiSS4.Gui.KissDateEdit();
            this.grdBerichtsperioden = new KiSS4.Gui.KissGrid();
            this.qryVmBerichtsperioden = new KiSS4.DB.SqlQuery();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBPErnennung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBPAufhebung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBPMT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBPUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBPDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBPDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBPBerichtsart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.kissLabel9 = new KiSS4.Gui.KissLabel();
            this.kissLabel5 = new KiSS4.Gui.KissLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.kissTextEdit2 = new KiSS4.Gui.KissTextEdit();
            this.kissLabel6 = new KiSS4.Gui.KissLabel();
            this.tabMassnahmen = new KiSS4.Gui.KissTabControlEx();
            this.tbpMassnahme = new SharpLibrary.WinControls.TabPageEx();
            this.tabBerichte = new KiSS4.Gui.KissTabControlEx();
            this.tbpBericht = new SharpLibrary.WinControls.TabPageEx();
            this.edtBerichtsnummer = new KiSS4.Gui.KissTextEdit();
            this.qryBericht = new KiSS4.DB.SqlQuery();
            this.lblBerichtsnummer = new KiSS4.Gui.KissLabel();
            this.docVermoegensabrechnung = new KiSS4.Dokument.XDokument();
            this.edtMaKlibuUser = new KiSS4.Gui.KissButtonEdit();
            this.kissLabel11 = new KiSS4.Gui.KissLabel();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.lblSucheUserID = new KiSS4.Gui.KissLabel();
            this.edtBerichtsart = new KiSS4.Gui.KissTextEdit();
            this.kissLabel10 = new KiSS4.Gui.KissLabel();
            this.docBericht = new KiSS4.Dokument.XDokument();
            this.kissDateEdit4 = new KiSS4.Gui.KissDateEdit();
            this.kissLabel8 = new KiSS4.Gui.KissLabel();
            this.kissDateEdit3 = new KiSS4.Gui.KissDateEdit();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.kissDateEdit2 = new KiSS4.Gui.KissDateEdit();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.edtDatumFristerstreckung = new KiSS4.Gui.KissDateEdit();
            this.lblDatumFristerstreckung = new KiSS4.Gui.KissLabel();
            this.edtDatumAusgangSDS = new KiSS4.Gui.KissDateEdit();
            this.lblDatumAusgangSDS = new KiSS4.Gui.KissLabel();
            this.edtDatumEingangSDS = new KiSS4.Gui.KissDateEdit();
            this.lblDatumEingangSDS = new KiSS4.Gui.KissLabel();
            this.lblVermoegensabrechnung = new KiSS4.Gui.KissLabel();
            this.lblDatumGenehmigung1 = new KiSS4.Gui.KissLabel();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.lblDatumVersandAnVB = new KiSS4.Gui.KissLabel();
            this.lblDatumBerichtMT = new KiSS4.Gui.KissLabel();
            this.edtDatumGenehmigung1 = new KiSS4.Gui.KissDateEdit();
            this.lblDatumBis = new KiSS4.Gui.KissLabel();
            this.edtDatumVersandAnVB = new KiSS4.Gui.KissDateEdit();
            this.lblDatumVon = new KiSS4.Gui.KissLabel();
            this.edtDatumBerichtMT = new KiSS4.Gui.KissDateEdit();
            this.edtBerichtsperiodeBis = new KiSS4.Gui.KissDateEdit();
            this.edtBerichtsperiodeVon = new KiSS4.Gui.KissDateEdit();
            this.tbpBerichtHist = new SharpLibrary.WinControls.TabPageEx();
            this.kissLabel12 = new KiSS4.Gui.KissLabel();
            this.docBerichtHist = new KiSS4.Dokument.XDokument();
            this.qryBerichtHistory = new KiSS4.DB.SqlQuery();
            this.grdVmBericht = new KiSS4.Gui.KissGrid();
            this.grvVmBericht = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBHDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBHDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBHDatumBerichtMT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBHDatumVersandAnVB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBHGenehmigung1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBHGenehmigung2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBHBemerkung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBHSpesen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBHEingangSDS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBHAusgangSDS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBHFristerstreckung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBHMahnung1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBHMahnung2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBHMahnung3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBHMAKlibu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBHMandatsTraegerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBHVisBerichtsnummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.kissLabel7 = new KiSS4.Gui.KissLabel();
            this.kissTextEdit3 = new KiSS4.Gui.KissTextEdit();
            this.tbpMassnahmeHist = new SharpLibrary.WinControls.TabPageEx();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVmMassnahmeHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVmMassnahme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAufhebung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBerichtsperioden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVmBerichtsperioden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).BeginInit();
            this.tabMassnahmen.SuspendLayout();
            this.tbpMassnahme.SuspendLayout();
            this.tabBerichte.SuspendLayout();
            this.tbpBericht.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtBerichtsnummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBericht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBerichtsnummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docVermoegensabrechnung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMaKlibuUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheUserID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBerichtsart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docBericht.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissDateEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissDateEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissDateEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumFristerstreckung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumFristerstreckung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumAusgangSDS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumAusgangSDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumEingangSDS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumEingangSDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVermoegensabrechnung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumGenehmigung1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVersandAnVB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBerichtMT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumGenehmigung1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVersandAnVB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBerichtMT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBerichtsperiodeBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBerichtsperiodeVon.Properties)).BeginInit();
            this.tbpBerichtHist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docBerichtHist.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBerichtHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVmBericht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVmBericht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit3.Properties)).BeginInit();
            this.tbpMassnahmeHist.SuspendLayout();
            this.SuspendLayout();
            // 
            // Grid1
            // 
            this.Grid1.DataSource = this.qryVmMassnahmeHistory;
            this.Grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.Grid1.EmbeddedNavigator.Name = "Grid1.EmbeddedNavigator";
            this.Grid1.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.Grid1.Location = new System.Drawing.Point(0, 0);
            this.Grid1.MainView = this.gridView1;
            this.Grid1.Name = "Grid1";
            this.Grid1.Size = new System.Drawing.Size(877, 497);
            this.Grid1.TabIndex = 0;
            this.Grid1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // qryVmMassnahmeHistory
            // 
            this.qryVmMassnahmeHistory.HostControl = this;
            this.qryVmMassnahmeHistory.SelectStatement = resources.GetString("qryVmMassnahmeHistory.SelectStatement");
            this.qryVmMassnahmeHistory.AfterFill += new System.EventHandler(this.qryVmMassnahmeHistory_AfterFill);
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
            this.colMHBeschluss,
            this.colMHAufhebung,
            this.colMHMassnahme});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.Grid1;
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
            // 
            // colMHBeschluss
            // 
            this.colMHBeschluss.Caption = "Beschluss Vom";
            this.colMHBeschluss.FieldName = "DatumVon";
            this.colMHBeschluss.Name = "colMHBeschluss";
            this.colMHBeschluss.Visible = true;
            this.colMHBeschluss.VisibleIndex = 0;
            this.colMHBeschluss.Width = 99;
            // 
            // colMHAufhebung
            // 
            this.colMHAufhebung.Caption = "Aufhebung";
            this.colMHAufhebung.FieldName = "DatumBis";
            this.colMHAufhebung.Name = "colMHAufhebung";
            this.colMHAufhebung.Visible = true;
            this.colMHAufhebung.VisibleIndex = 1;
            this.colMHAufhebung.Width = 84;
            // 
            // colMHMassnahme
            // 
            this.colMHMassnahme.Caption = "Behördliche Massnahme";
            this.colMHMassnahme.FieldName = "Massnahme";
            this.colMHMassnahme.Name = "colMHMassnahme";
            this.colMHMassnahme.Visible = true;
            this.colMHMassnahme.VisibleIndex = 2;
            this.colMHMassnahme.Width = 424;
            // 
            // qryVmMassnahme
            // 
            this.qryVmMassnahme.HostControl = this;
            this.qryVmMassnahme.SelectStatement = "SELECT \r\n  Massnahme = ISNULL(ZGB, \'\') + ISNULL(\' - \' + Mandatstyp, \'\'),\r\n  Datum" +
    "Von,\r\n  DatumBis,\r\n  VIS_VormschID,\r\n  VmMassnahmeID\r\nFROM VmMassnahme\r\nWHERE Fa" +
    "LeistungID = {0}\r\nORDER BY DatumVon";
            this.qryVmMassnahme.TableName = "VmMassnahme";
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.DataMember = "DatumVon";
            this.edtDatumVon.DataSource = this.qryVmMassnahme;
            this.edtDatumVon.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(96, 37);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject22.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject22.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject22)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ReadOnly = true;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVon.TabIndex = 2;
            // 
            // edtAufhebung
            // 
            this.edtAufhebung.DataMember = "DatumBis";
            this.edtAufhebung.DataSource = this.qryVmMassnahme;
            this.edtAufhebung.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAufhebung.EditValue = null;
            this.edtAufhebung.Location = new System.Drawing.Point(282, 37);
            this.edtAufhebung.Name = "edtAufhebung";
            this.edtAufhebung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAufhebung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAufhebung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAufhebung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAufhebung.Properties.Appearance.Options.UseBackColor = true;
            this.edtAufhebung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAufhebung.Properties.Appearance.Options.UseFont = true;
            this.edtAufhebung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject23.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject23.Options.UseBackColor = true;
            this.edtAufhebung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtAufhebung.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject23)});
            this.edtAufhebung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAufhebung.Properties.ReadOnly = true;
            this.edtAufhebung.Properties.ShowToday = false;
            this.edtAufhebung.Size = new System.Drawing.Size(100, 24);
            this.edtAufhebung.TabIndex = 3;
            // 
            // grdBerichtsperioden
            // 
            this.grdBerichtsperioden.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdBerichtsperioden.DataSource = this.qryVmBerichtsperioden;
            // 
            // 
            // 
            this.grdBerichtsperioden.EmbeddedNavigator.Name = "";
            this.grdBerichtsperioden.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBerichtsperioden.Location = new System.Drawing.Point(96, 67);
            this.grdBerichtsperioden.MainView = this.gridView2;
            this.grdBerichtsperioden.Name = "grdBerichtsperioden";
            this.grdBerichtsperioden.Size = new System.Drawing.Size(778, 109);
            this.grdBerichtsperioden.TabIndex = 4;
            this.grdBerichtsperioden.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // qryVmBerichtsperioden
            // 
            this.qryVmBerichtsperioden.HostControl = this;
            this.qryVmBerichtsperioden.SelectStatement = resources.GetString("qryVmBerichtsperioden.SelectStatement");
            this.qryVmBerichtsperioden.AfterFill += new System.EventHandler(this.qryVmBerichtsperioden_AfterFill);
            this.qryVmBerichtsperioden.PositionChanged += new System.EventHandler(this.qryVmBerichtsperioden_PositionChanged);
            this.qryVmBerichtsperioden.PositionChanging += new System.EventHandler(this.qryVmBerichtsperioden_PositionChanging);
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
            this.gridView2.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView2.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView2.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupFooter.Options.UseBorderColor = true;
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
            this.colBPErnennung,
            this.colBPAufhebung,
            this.colBPMT,
            this.colBPUserID,
            this.colBPDatumVon,
            this.colBPDatumBis,
            this.colBPBerichtsart});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView2.GridControl = this.grdBerichtsperioden;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsCustomization.AllowFilter = false;
            this.gridView2.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView2.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView2.OptionsNavigation.UseTabKey = false;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowIndicator = false;
            // 
            // colBPErnennung
            // 
            this.colBPErnennung.Caption = "Ernennung";
            this.colBPErnennung.FieldName = "Ernennung";
            this.colBPErnennung.Name = "colBPErnennung";
            this.colBPErnennung.Visible = true;
            this.colBPErnennung.VisibleIndex = 0;
            // 
            // colBPAufhebung
            // 
            this.colBPAufhebung.Caption = "Entlassung";
            this.colBPAufhebung.FieldName = "Aufhebung";
            this.colBPAufhebung.Name = "colBPAufhebung";
            this.colBPAufhebung.Visible = true;
            this.colBPAufhebung.VisibleIndex = 1;
            // 
            // colBPMT
            // 
            this.colBPMT.Caption = "Beist. oder Vorm.";
            this.colBPMT.FieldName = "VISMA";
            this.colBPMT.Name = "colBPMT";
            this.colBPMT.Visible = true;
            this.colBPMT.VisibleIndex = 2;
            this.colBPMT.Width = 140;
            // 
            // colBPUserID
            // 
            this.colBPUserID.Caption = "zust. MA";
            this.colBPUserID.FieldName = "KiSSMA";
            this.colBPUserID.Name = "colBPUserID";
            this.colBPUserID.Visible = true;
            this.colBPUserID.VisibleIndex = 3;
            this.colBPUserID.Width = 160;
            // 
            // colBPDatumVon
            // 
            this.colBPDatumVon.Caption = "Datum Von";
            this.colBPDatumVon.FieldName = "DatumVon";
            this.colBPDatumVon.Name = "colBPDatumVon";
            this.colBPDatumVon.Visible = true;
            this.colBPDatumVon.VisibleIndex = 5;
            // 
            // colBPDatumBis
            // 
            this.colBPDatumBis.Caption = "Datum Bis";
            this.colBPDatumBis.FieldName = "DatumBis";
            this.colBPDatumBis.Name = "colBPDatumBis";
            this.colBPDatumBis.Visible = true;
            this.colBPDatumBis.VisibleIndex = 6;
            // 
            // colBPBerichtsart
            // 
            this.colBPBerichtsart.Caption = "Berichtsart";
            this.colBPBerichtsart.FieldName = "Berichtsart";
            this.colBPBerichtsart.Name = "colBPBerichtsart";
            this.colBPBerichtsart.Visible = true;
            this.colBPBerichtsart.VisibleIndex = 4;
            this.colBPBerichtsart.Width = 160;
            // 
            // kissLabel4
            // 
            this.kissLabel4.Location = new System.Drawing.Point(5, 37);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(91, 24);
            this.kissLabel4.TabIndex = 23;
            this.kissLabel4.Text = "Beschluss vom";
            this.kissLabel4.UseCompatibleTextRendering = true;
            // 
            // kissLabel9
            // 
            this.kissLabel9.Location = new System.Drawing.Point(5, 67);
            this.kissLabel9.Name = "kissLabel9";
            this.kissLabel9.Size = new System.Drawing.Size(91, 24);
            this.kissLabel9.TabIndex = 617;
            this.kissLabel9.Text = "Ernennungen";
            this.kissLabel9.UseCompatibleTextRendering = true;
            // 
            // kissLabel5
            // 
            this.kissLabel5.Location = new System.Drawing.Point(216, 37);
            this.kissLabel5.Name = "kissLabel5";
            this.kissLabel5.Size = new System.Drawing.Size(67, 24);
            this.kissLabel5.TabIndex = 631;
            this.kissLabel5.Text = "Aufhebung";
            this.kissLabel5.UseCompatibleTextRendering = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picTitel);
            this.panel1.Controls.Add(this.lblTitel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(892, 24);
            this.panel1.TabIndex = 636;
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
            this.lblTitel.Text = "Massnahmen";
            this.lblTitel.UseCompatibleTextRendering = true;
            // 
            // kissTextEdit2
            // 
            this.kissTextEdit2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kissTextEdit2.DataMember = "VIS_VormschID";
            this.kissTextEdit2.DataSource = this.qryVmMassnahme;
            this.kissTextEdit2.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit2.Location = new System.Drawing.Point(785, 7);
            this.kissTextEdit2.Name = "kissTextEdit2";
            this.kissTextEdit2.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit2.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit2.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit2.Properties.ReadOnly = true;
            this.kissTextEdit2.Size = new System.Drawing.Size(89, 24);
            this.kissTextEdit2.TabIndex = 1;
            // 
            // kissLabel6
            // 
            this.kissLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kissLabel6.Location = new System.Drawing.Point(723, 7);
            this.kissLabel6.Name = "kissLabel6";
            this.kissLabel6.Size = new System.Drawing.Size(62, 24);
            this.kissLabel6.TabIndex = 643;
            this.kissLabel6.Text = "VormschID";
            this.kissLabel6.UseCompatibleTextRendering = true;
            // 
            // tabMassnahmen
            // 
            this.tabMassnahmen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMassnahmen.Controls.Add(this.tbpMassnahme);
            this.tabMassnahmen.Controls.Add(this.tbpMassnahmeHist);
            this.tabMassnahmen.Location = new System.Drawing.Point(0, 30);
            this.tabMassnahmen.Name = "tabMassnahmen";
            this.tabMassnahmen.ShowFixedWidthTooltip = true;
            this.tabMassnahmen.Size = new System.Drawing.Size(889, 535);
            this.tabMassnahmen.TabIndex = 0;
            this.tabMassnahmen.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tbpMassnahme,
            this.tbpMassnahmeHist});
            this.tabMassnahmen.TabsLineColor = System.Drawing.Color.Black;
            this.tabMassnahmen.TabsLocation = SharpLibrary.WinControls.TabsLocation.Top;
            this.tabMassnahmen.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            // 
            // tbpMassnahme
            // 
            this.tbpMassnahme.Controls.Add(this.tabBerichte);
            this.tbpMassnahme.Controls.Add(this.kissLabel7);
            this.tbpMassnahme.Controls.Add(this.kissTextEdit3);
            this.tbpMassnahme.Controls.Add(this.edtDatumVon);
            this.tbpMassnahme.Controls.Add(this.kissLabel6);
            this.tbpMassnahme.Controls.Add(this.edtAufhebung);
            this.tbpMassnahme.Controls.Add(this.kissTextEdit2);
            this.tbpMassnahme.Controls.Add(this.kissLabel5);
            this.tbpMassnahme.Controls.Add(this.grdBerichtsperioden);
            this.tbpMassnahme.Controls.Add(this.kissLabel9);
            this.tbpMassnahme.Controls.Add(this.kissLabel4);
            this.tbpMassnahme.Location = new System.Drawing.Point(6, 32);
            this.tbpMassnahme.Name = "tbpMassnahme";
            this.tbpMassnahme.Size = new System.Drawing.Size(877, 497);
            this.tbpMassnahme.TabIndex = 0;
            this.tbpMassnahme.Title = "Massnahme";
            // 
            // tabBerichte
            // 
            this.tabBerichte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabBerichte.Controls.Add(this.tbpBericht);
            this.tabBerichte.Controls.Add(this.tbpBerichtHist);
            this.tabBerichte.Location = new System.Drawing.Point(5, 182);
            this.tabBerichte.Name = "tabBerichte";
            this.tabBerichte.ShowFixedWidthTooltip = true;
            this.tabBerichte.Size = new System.Drawing.Size(869, 312);
            this.tabBerichte.TabIndex = 5;
            this.tabBerichte.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tbpBericht,
            this.tbpBerichtHist});
            this.tabBerichte.TabsLineColor = System.Drawing.Color.Black;
            this.tabBerichte.TabsLocation = SharpLibrary.WinControls.TabsLocation.Top;
            this.tabBerichte.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            // 
            // tbpBericht
            // 
            this.tbpBericht.Controls.Add(this.edtBerichtsnummer);
            this.tbpBericht.Controls.Add(this.lblBerichtsnummer);
            this.tbpBericht.Controls.Add(this.docVermoegensabrechnung);
            this.tbpBericht.Controls.Add(this.edtMaKlibuUser);
            this.tbpBericht.Controls.Add(this.kissLabel11);
            this.tbpBericht.Controls.Add(this.edtBemerkung);
            this.tbpBericht.Controls.Add(this.lblSucheUserID);
            this.tbpBericht.Controls.Add(this.edtBerichtsart);
            this.tbpBericht.Controls.Add(this.kissLabel10);
            this.tbpBericht.Controls.Add(this.docBericht);
            this.tbpBericht.Controls.Add(this.kissDateEdit4);
            this.tbpBericht.Controls.Add(this.kissLabel8);
            this.tbpBericht.Controls.Add(this.kissDateEdit3);
            this.tbpBericht.Controls.Add(this.kissLabel2);
            this.tbpBericht.Controls.Add(this.kissDateEdit2);
            this.tbpBericht.Controls.Add(this.kissLabel1);
            this.tbpBericht.Controls.Add(this.edtDatumFristerstreckung);
            this.tbpBericht.Controls.Add(this.lblDatumFristerstreckung);
            this.tbpBericht.Controls.Add(this.edtDatumAusgangSDS);
            this.tbpBericht.Controls.Add(this.lblDatumAusgangSDS);
            this.tbpBericht.Controls.Add(this.edtDatumEingangSDS);
            this.tbpBericht.Controls.Add(this.lblDatumEingangSDS);
            this.tbpBericht.Controls.Add(this.lblVermoegensabrechnung);
            this.tbpBericht.Controls.Add(this.lblDatumGenehmigung1);
            this.tbpBericht.Controls.Add(this.lblBemerkung);
            this.tbpBericht.Controls.Add(this.lblDatumVersandAnVB);
            this.tbpBericht.Controls.Add(this.lblDatumBerichtMT);
            this.tbpBericht.Controls.Add(this.edtDatumGenehmigung1);
            this.tbpBericht.Controls.Add(this.lblDatumBis);
            this.tbpBericht.Controls.Add(this.edtDatumVersandAnVB);
            this.tbpBericht.Controls.Add(this.lblDatumVon);
            this.tbpBericht.Controls.Add(this.edtDatumBerichtMT);
            this.tbpBericht.Controls.Add(this.edtBerichtsperiodeBis);
            this.tbpBericht.Controls.Add(this.edtBerichtsperiodeVon);
            this.tbpBericht.Location = new System.Drawing.Point(6, 32);
            this.tbpBericht.Name = "tbpBericht";
            this.tbpBericht.Size = new System.Drawing.Size(857, 274);
            this.tbpBericht.TabIndex = 0;
            this.tbpBericht.Title = "Bericht";
            // 
            // edtBerichtsnummer
            // 
            this.edtBerichtsnummer.DataMember = "VIS_Berichtsnummer";
            this.edtBerichtsnummer.DataSource = this.qryBericht;
            this.edtBerichtsnummer.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBerichtsnummer.Location = new System.Drawing.Point(119, 3);
            this.edtBerichtsnummer.Name = "edtBerichtsnummer";
            this.edtBerichtsnummer.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBerichtsnummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBerichtsnummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBerichtsnummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtBerichtsnummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBerichtsnummer.Properties.Appearance.Options.UseFont = true;
            this.edtBerichtsnummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBerichtsnummer.Properties.Name = "editSAR.Properties";
            this.edtBerichtsnummer.Properties.ReadOnly = true;
            this.edtBerichtsnummer.Size = new System.Drawing.Size(100, 24);
            this.edtBerichtsnummer.TabIndex = 662;
            // 
            // qryBericht
            // 
            this.qryBericht.CanInsert = true;
            this.qryBericht.CanUpdate = true;
            this.qryBericht.HostControl = this;
            this.qryBericht.SelectStatement = resources.GetString("qryBericht.SelectStatement");
            this.qryBericht.TableName = "VmBericht";
            this.qryBericht.AfterFill += new System.EventHandler(this.qryBericht_AfterFill);
            this.qryBericht.AfterPost += new System.EventHandler(this.qryBericht_AfterPost);
            this.qryBericht.BeforePost += new System.EventHandler(this.qryBericht_BeforePost);
            // 
            // lblBerichtsnummer
            // 
            this.lblBerichtsnummer.Location = new System.Drawing.Point(3, 3);
            this.lblBerichtsnummer.Name = "lblBerichtsnummer";
            this.lblBerichtsnummer.Size = new System.Drawing.Size(110, 24);
            this.lblBerichtsnummer.TabIndex = 663;
            this.lblBerichtsnummer.Text = "Berichtsnummer";
            this.lblBerichtsnummer.UseCompatibleTextRendering = true;
            // 
            // docVermoegensabrechnung
            // 
            this.docVermoegensabrechnung.CanImportDocument = false;
            this.docVermoegensabrechnung.Context = "Rechenschaftsbericht";
            this.docVermoegensabrechnung.DataMember = "VermoegensabrechnungDocumentID";
            this.docVermoegensabrechnung.DataSource = this.qryBericht;
            this.docVermoegensabrechnung.Location = new System.Drawing.Point(335, 165);
            this.docVermoegensabrechnung.Name = "docVermoegensabrechnung";
            this.docVermoegensabrechnung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.docVermoegensabrechnung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.docVermoegensabrechnung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docVermoegensabrechnung.Properties.Appearance.Options.UseBackColor = true;
            this.docVermoegensabrechnung.Properties.Appearance.Options.UseBorderColor = true;
            this.docVermoegensabrechnung.Properties.Appearance.Options.UseFont = true;
            this.docVermoegensabrechnung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.docVermoegensabrechnung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docVermoegensabrechnung.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docVermoegensabrechnung.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docVermoegensabrechnung.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docVermoegensabrechnung.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "Dokument importieren")});
            this.docVermoegensabrechnung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.docVermoegensabrechnung.Properties.Name = "edtFaDokKorreDokument.Properties";
            this.docVermoegensabrechnung.Properties.ReadOnly = true;
            this.docVermoegensabrechnung.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.docVermoegensabrechnung.Size = new System.Drawing.Size(117, 24);
            this.docVermoegensabrechnung.TabIndex = 661;
            this.docVermoegensabrechnung.DocumentCreating += new System.ComponentModel.CancelEventHandler(this.docVermoegensabrechnung_DocumentCreating);
            this.docVermoegensabrechnung.DocumentDeleted += new System.EventHandler(this.docVermoegensabrechnung_DocumentDeleted);
            // 
            // edtMaKlibuUser
            // 
            this.edtMaKlibuUser.DataMember = "MaKlibuUser";
            this.edtMaKlibuUser.DataSource = this.qryBericht;
            this.edtMaKlibuUser.Location = new System.Drawing.Point(335, 135);
            this.edtMaKlibuUser.Name = "edtMaKlibuUser";
            this.edtMaKlibuUser.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMaKlibuUser.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMaKlibuUser.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMaKlibuUser.Properties.Appearance.Options.UseBackColor = true;
            this.edtMaKlibuUser.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMaKlibuUser.Properties.Appearance.Options.UseFont = true;
            this.edtMaKlibuUser.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtMaKlibuUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtMaKlibuUser.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtMaKlibuUser.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtMaKlibuUser.Size = new System.Drawing.Size(117, 24);
            this.edtMaKlibuUser.TabIndex = 9;
            this.edtMaKlibuUser.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtMaKlibuUser_UserModifiedFld);
            // 
            // kissLabel11
            // 
            this.kissLabel11.Location = new System.Drawing.Point(3, 73);
            this.kissLabel11.Name = "kissLabel11";
            this.kissLabel11.Size = new System.Drawing.Size(110, 24);
            this.kissLabel11.TabIndex = 660;
            this.kissLabel11.Text = "Berichts-Dokument";
            this.kissLabel11.UseCompatibleTextRendering = true;
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryBericht;
            this.edtBemerkung.Location = new System.Drawing.Point(119, 196);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(737, 75);
            this.edtBemerkung.TabIndex = 15;
            // 
            // lblSucheUserID
            // 
            this.lblSucheUserID.Location = new System.Drawing.Point(243, 136);
            this.lblSucheUserID.Name = "lblSucheUserID";
            this.lblSucheUserID.Size = new System.Drawing.Size(80, 24);
            this.lblSucheUserID.TabIndex = 658;
            this.lblSucheUserID.Text = "MA Klibu";
            this.lblSucheUserID.UseCompatibleTextRendering = true;
            // 
            // edtBerichtsart
            // 
            this.edtBerichtsart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBerichtsart.DataMember = "Berichtsart";
            this.edtBerichtsart.DataSource = this.qryBericht;
            this.edtBerichtsart.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBerichtsart.Location = new System.Drawing.Point(432, 34);
            this.edtBerichtsart.Name = "edtBerichtsart";
            this.edtBerichtsart.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBerichtsart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBerichtsart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBerichtsart.Properties.Appearance.Options.UseBackColor = true;
            this.edtBerichtsart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBerichtsart.Properties.Appearance.Options.UseFont = true;
            this.edtBerichtsart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBerichtsart.Properties.Name = "editSAR.Properties";
            this.edtBerichtsart.Properties.ReadOnly = true;
            this.edtBerichtsart.Size = new System.Drawing.Size(424, 24);
            this.edtBerichtsart.TabIndex = 2;
            // 
            // kissLabel10
            // 
            this.kissLabel10.Location = new System.Drawing.Point(364, 34);
            this.kissLabel10.Name = "kissLabel10";
            this.kissLabel10.Size = new System.Drawing.Size(62, 24);
            this.kissLabel10.TabIndex = 655;
            this.kissLabel10.Text = "Berichtsart";
            this.kissLabel10.UseCompatibleTextRendering = true;
            // 
            // docBericht
            // 
            this.docBericht.CanDeleteDocument = false;
            this.docBericht.CanImportDocument = false;
            this.docBericht.Context = "Rechenschaftsbericht";
            this.docBericht.DataMember = "DocumentID";
            this.docBericht.DataSource = this.qryBericht;
            this.docBericht.Location = new System.Drawing.Point(119, 75);
            this.docBericht.Name = "docBericht";
            this.docBericht.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.docBericht.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.docBericht.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docBericht.Properties.Appearance.Options.UseBackColor = true;
            this.docBericht.Properties.Appearance.Options.UseBorderColor = true;
            this.docBericht.Properties.Appearance.Options.UseFont = true;
            this.docBericht.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.docBericht.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docBericht.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docBericht.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docBericht.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docBericht.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9, "Dokument importieren")});
            this.docBericht.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.docBericht.Properties.Name = "edtFaDokKorreDokument.Properties";
            this.docBericht.Properties.ReadOnly = true;
            this.docBericht.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.docBericht.Size = new System.Drawing.Size(100, 24);
            this.docBericht.TabIndex = 3;
            // 
            // kissDateEdit4
            // 
            this.kissDateEdit4.DataMember = "DatumMahnung3";
            this.kissDateEdit4.DataSource = this.qryBericht;
            this.kissDateEdit4.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissDateEdit4.EditValue = null;
            this.kissDateEdit4.Location = new System.Drawing.Point(566, 165);
            this.kissDateEdit4.Name = "kissDateEdit4";
            this.kissDateEdit4.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.kissDateEdit4.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissDateEdit4.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissDateEdit4.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissDateEdit4.Properties.Appearance.Options.UseBackColor = true;
            this.kissDateEdit4.Properties.Appearance.Options.UseBorderColor = true;
            this.kissDateEdit4.Properties.Appearance.Options.UseFont = true;
            this.kissDateEdit4.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.kissDateEdit4.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("kissDateEdit4.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.kissDateEdit4.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.kissDateEdit4.Properties.ReadOnly = true;
            this.kissDateEdit4.Properties.ShowToday = false;
            this.kissDateEdit4.Size = new System.Drawing.Size(100, 24);
            this.kissDateEdit4.TabIndex = 14;
            // 
            // kissLabel8
            // 
            this.kissLabel8.Location = new System.Drawing.Point(474, 165);
            this.kissLabel8.Name = "kissLabel8";
            this.kissLabel8.Size = new System.Drawing.Size(88, 24);
            this.kissLabel8.TabIndex = 652;
            this.kissLabel8.Text = "3. Mahnung";
            this.kissLabel8.UseCompatibleTextRendering = true;
            // 
            // kissDateEdit3
            // 
            this.kissDateEdit3.DataMember = "DatumMahnung2";
            this.kissDateEdit3.DataSource = this.qryBericht;
            this.kissDateEdit3.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissDateEdit3.EditValue = null;
            this.kissDateEdit3.Location = new System.Drawing.Point(566, 135);
            this.kissDateEdit3.Name = "kissDateEdit3";
            this.kissDateEdit3.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.kissDateEdit3.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissDateEdit3.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissDateEdit3.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissDateEdit3.Properties.Appearance.Options.UseBackColor = true;
            this.kissDateEdit3.Properties.Appearance.Options.UseBorderColor = true;
            this.kissDateEdit3.Properties.Appearance.Options.UseFont = true;
            this.kissDateEdit3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.kissDateEdit3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("kissDateEdit3.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.kissDateEdit3.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.kissDateEdit3.Properties.ReadOnly = true;
            this.kissDateEdit3.Properties.ShowToday = false;
            this.kissDateEdit3.Size = new System.Drawing.Size(100, 24);
            this.kissDateEdit3.TabIndex = 13;
            // 
            // kissLabel2
            // 
            this.kissLabel2.Location = new System.Drawing.Point(474, 135);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(88, 24);
            this.kissLabel2.TabIndex = 650;
            this.kissLabel2.Text = "2. Mahnung";
            this.kissLabel2.UseCompatibleTextRendering = true;
            // 
            // kissDateEdit2
            // 
            this.kissDateEdit2.DataMember = "DatumMahnung1";
            this.kissDateEdit2.DataSource = this.qryBericht;
            this.kissDateEdit2.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissDateEdit2.EditValue = null;
            this.kissDateEdit2.Location = new System.Drawing.Point(566, 105);
            this.kissDateEdit2.Name = "kissDateEdit2";
            this.kissDateEdit2.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.kissDateEdit2.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissDateEdit2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissDateEdit2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissDateEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.kissDateEdit2.Properties.Appearance.Options.UseBorderColor = true;
            this.kissDateEdit2.Properties.Appearance.Options.UseFont = true;
            this.kissDateEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.kissDateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("kissDateEdit2.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12)});
            this.kissDateEdit2.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.kissDateEdit2.Properties.ReadOnly = true;
            this.kissDateEdit2.Properties.ShowToday = false;
            this.kissDateEdit2.Size = new System.Drawing.Size(100, 24);
            this.kissDateEdit2.TabIndex = 12;
            // 
            // kissLabel1
            // 
            this.kissLabel1.Location = new System.Drawing.Point(474, 105);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(88, 24);
            this.kissLabel1.TabIndex = 648;
            this.kissLabel1.Text = "1. Mahnung";
            this.kissLabel1.UseCompatibleTextRendering = true;
            // 
            // edtDatumFristerstreckung
            // 
            this.edtDatumFristerstreckung.DataMember = "DatumFristerstreckung";
            this.edtDatumFristerstreckung.DataSource = this.qryBericht;
            this.edtDatumFristerstreckung.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtDatumFristerstreckung.EditValue = null;
            this.edtDatumFristerstreckung.Location = new System.Drawing.Point(566, 75);
            this.edtDatumFristerstreckung.Name = "edtDatumFristerstreckung";
            this.edtDatumFristerstreckung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumFristerstreckung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtDatumFristerstreckung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumFristerstreckung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumFristerstreckung.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumFristerstreckung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumFristerstreckung.Properties.Appearance.Options.UseFont = true;
            this.edtDatumFristerstreckung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject13.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject13.Options.UseBackColor = true;
            this.edtDatumFristerstreckung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumFristerstreckung.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13)});
            this.edtDatumFristerstreckung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumFristerstreckung.Properties.ReadOnly = true;
            this.edtDatumFristerstreckung.Properties.ShowToday = false;
            this.edtDatumFristerstreckung.Size = new System.Drawing.Size(100, 24);
            this.edtDatumFristerstreckung.TabIndex = 11;
            // 
            // lblDatumFristerstreckung
            // 
            this.lblDatumFristerstreckung.Location = new System.Drawing.Point(474, 75);
            this.lblDatumFristerstreckung.Name = "lblDatumFristerstreckung";
            this.lblDatumFristerstreckung.Size = new System.Drawing.Size(88, 24);
            this.lblDatumFristerstreckung.TabIndex = 41;
            this.lblDatumFristerstreckung.Text = "Fristerstreckung";
            this.lblDatumFristerstreckung.UseCompatibleTextRendering = true;
            // 
            // edtDatumAusgangSDS
            // 
            this.edtDatumAusgangSDS.DataMember = "DatumAusgangSDS";
            this.edtDatumAusgangSDS.DataSource = this.qryBericht;
            this.edtDatumAusgangSDS.EditValue = null;
            this.edtDatumAusgangSDS.Location = new System.Drawing.Point(335, 106);
            this.edtDatumAusgangSDS.Name = "edtDatumAusgangSDS";
            this.edtDatumAusgangSDS.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumAusgangSDS.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumAusgangSDS.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumAusgangSDS.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumAusgangSDS.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumAusgangSDS.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumAusgangSDS.Properties.Appearance.Options.UseFont = true;
            this.edtDatumAusgangSDS.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject14.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject14.Options.UseBackColor = true;
            this.edtDatumAusgangSDS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumAusgangSDS.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject14)});
            this.edtDatumAusgangSDS.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumAusgangSDS.Properties.ShowToday = false;
            this.edtDatumAusgangSDS.Size = new System.Drawing.Size(117, 24);
            this.edtDatumAusgangSDS.TabIndex = 8;
            // 
            // lblDatumAusgangSDS
            // 
            this.lblDatumAusgangSDS.Location = new System.Drawing.Point(243, 107);
            this.lblDatumAusgangSDS.Name = "lblDatumAusgangSDS";
            this.lblDatumAusgangSDS.Size = new System.Drawing.Size(86, 24);
            this.lblDatumAusgangSDS.TabIndex = 38;
            this.lblDatumAusgangSDS.Text = "Ausgang SDS";
            this.lblDatumAusgangSDS.UseCompatibleTextRendering = true;
            // 
            // edtDatumEingangSDS
            // 
            this.edtDatumEingangSDS.DataMember = "DatumEingangSDS";
            this.edtDatumEingangSDS.DataSource = this.qryBericht;
            this.edtDatumEingangSDS.EditValue = null;
            this.edtDatumEingangSDS.Location = new System.Drawing.Point(335, 75);
            this.edtDatumEingangSDS.Name = "edtDatumEingangSDS";
            this.edtDatumEingangSDS.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumEingangSDS.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumEingangSDS.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumEingangSDS.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumEingangSDS.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumEingangSDS.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumEingangSDS.Properties.Appearance.Options.UseFont = true;
            this.edtDatumEingangSDS.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject15.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject15.Options.UseBackColor = true;
            this.edtDatumEingangSDS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumEingangSDS.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject15)});
            this.edtDatumEingangSDS.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumEingangSDS.Properties.ShowToday = false;
            this.edtDatumEingangSDS.Size = new System.Drawing.Size(117, 24);
            this.edtDatumEingangSDS.TabIndex = 7;
            // 
            // lblDatumEingangSDS
            // 
            this.lblDatumEingangSDS.Location = new System.Drawing.Point(243, 77);
            this.lblDatumEingangSDS.Name = "lblDatumEingangSDS";
            this.lblDatumEingangSDS.Size = new System.Drawing.Size(86, 24);
            this.lblDatumEingangSDS.TabIndex = 36;
            this.lblDatumEingangSDS.Text = "Eingang SDS";
            this.lblDatumEingangSDS.UseCompatibleTextRendering = true;
            // 
            // lblVermoegensabrechnung
            // 
            this.lblVermoegensabrechnung.Location = new System.Drawing.Point(243, 166);
            this.lblVermoegensabrechnung.Name = "lblVermoegensabrechnung";
            this.lblVermoegensabrechnung.Size = new System.Drawing.Size(92, 24);
            this.lblVermoegensabrechnung.TabIndex = 35;
            this.lblVermoegensabrechnung.Text = "Vermoegensabr.";
            this.lblVermoegensabrechnung.UseCompatibleTextRendering = true;
            // 
            // lblDatumGenehmigung1
            // 
            this.lblDatumGenehmigung1.Location = new System.Drawing.Point(3, 166);
            this.lblDatumGenehmigung1.Name = "lblDatumGenehmigung1";
            this.lblDatumGenehmigung1.Size = new System.Drawing.Size(110, 24);
            this.lblDatumGenehmigung1.TabIndex = 33;
            this.lblDatumGenehmigung1.Text = "Genehmigung KESB";
            this.lblDatumGenehmigung1.UseCompatibleTextRendering = true;
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.Location = new System.Drawing.Point(3, 196);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(110, 24);
            this.lblBemerkung.TabIndex = 32;
            this.lblBemerkung.Text = "Bemerkung";
            this.lblBemerkung.UseCompatibleTextRendering = true;
            // 
            // lblDatumVersandAnVB
            // 
            this.lblDatumVersandAnVB.Location = new System.Drawing.Point(3, 136);
            this.lblDatumVersandAnVB.Name = "lblDatumVersandAnVB";
            this.lblDatumVersandAnVB.Size = new System.Drawing.Size(110, 24);
            this.lblDatumVersandAnVB.TabIndex = 29;
            this.lblDatumVersandAnVB.Text = "Versand an KESB";
            this.lblDatumVersandAnVB.UseCompatibleTextRendering = true;
            // 
            // lblDatumBerichtMT
            // 
            this.lblDatumBerichtMT.Location = new System.Drawing.Point(3, 106);
            this.lblDatumBerichtMT.Name = "lblDatumBerichtMT";
            this.lblDatumBerichtMT.Size = new System.Drawing.Size(110, 24);
            this.lblDatumBerichtMT.TabIndex = 27;
            this.lblDatumBerichtMT.Text = "Erstellung Bericht";
            this.lblDatumBerichtMT.UseCompatibleTextRendering = true;
            // 
            // edtDatumGenehmigung1
            // 
            this.edtDatumGenehmigung1.DataMember = "DatumGenehmigung1";
            this.edtDatumGenehmigung1.DataSource = this.qryBericht;
            this.edtDatumGenehmigung1.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtDatumGenehmigung1.EditValue = null;
            this.edtDatumGenehmigung1.Location = new System.Drawing.Point(119, 166);
            this.edtDatumGenehmigung1.Name = "edtDatumGenehmigung1";
            this.edtDatumGenehmigung1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumGenehmigung1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtDatumGenehmigung1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumGenehmigung1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumGenehmigung1.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumGenehmigung1.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumGenehmigung1.Properties.Appearance.Options.UseFont = true;
            this.edtDatumGenehmigung1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject16.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject16.Options.UseBackColor = true;
            this.edtDatumGenehmigung1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumGenehmigung1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject16)});
            this.edtDatumGenehmigung1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumGenehmigung1.Properties.ReadOnly = true;
            this.edtDatumGenehmigung1.Properties.ShowToday = false;
            this.edtDatumGenehmigung1.Size = new System.Drawing.Size(100, 24);
            this.edtDatumGenehmigung1.TabIndex = 6;
            // 
            // lblDatumBis
            // 
            this.lblDatumBis.Location = new System.Drawing.Point(222, 34);
            this.lblDatumBis.Name = "lblDatumBis";
            this.lblDatumBis.Size = new System.Drawing.Size(24, 24);
            this.lblDatumBis.TabIndex = 25;
            this.lblDatumBis.Text = "bis";
            this.lblDatumBis.UseCompatibleTextRendering = true;
            // 
            // edtDatumVersandAnVB
            // 
            this.edtDatumVersandAnVB.DataMember = "DatumVersandAnVB";
            this.edtDatumVersandAnVB.DataSource = this.qryBericht;
            this.edtDatumVersandAnVB.EditValue = null;
            this.edtDatumVersandAnVB.Location = new System.Drawing.Point(119, 136);
            this.edtDatumVersandAnVB.Name = "edtDatumVersandAnVB";
            this.edtDatumVersandAnVB.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVersandAnVB.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVersandAnVB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVersandAnVB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVersandAnVB.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVersandAnVB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVersandAnVB.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVersandAnVB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject17.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject17.Options.UseBackColor = true;
            this.edtDatumVersandAnVB.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVersandAnVB.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject17)});
            this.edtDatumVersandAnVB.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVersandAnVB.Properties.ShowToday = false;
            this.edtDatumVersandAnVB.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVersandAnVB.TabIndex = 5;
            // 
            // lblDatumVon
            // 
            this.lblDatumVon.Location = new System.Drawing.Point(3, 33);
            this.lblDatumVon.Name = "lblDatumVon";
            this.lblDatumVon.Size = new System.Drawing.Size(115, 24);
            this.lblDatumVon.TabIndex = 23;
            this.lblDatumVon.Text = "Berichtsperiode von";
            this.lblDatumVon.UseCompatibleTextRendering = true;
            // 
            // edtDatumBerichtMT
            // 
            this.edtDatumBerichtMT.DataMember = "DatumBerichtMT";
            this.edtDatumBerichtMT.DataSource = this.qryBericht;
            this.edtDatumBerichtMT.EditValue = null;
            this.edtDatumBerichtMT.Location = new System.Drawing.Point(119, 106);
            this.edtDatumBerichtMT.Name = "edtDatumBerichtMT";
            this.edtDatumBerichtMT.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBerichtMT.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBerichtMT.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBerichtMT.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBerichtMT.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBerichtMT.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBerichtMT.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBerichtMT.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject18.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject18.Options.UseBackColor = true;
            this.edtDatumBerichtMT.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBerichtMT.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject18)});
            this.edtDatumBerichtMT.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBerichtMT.Properties.ShowToday = false;
            this.edtDatumBerichtMT.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBerichtMT.TabIndex = 4;
            // 
            // edtBerichtsperiodeBis
            // 
            this.edtBerichtsperiodeBis.DataMember = "DatumBis";
            this.edtBerichtsperiodeBis.DataSource = this.qryBericht;
            this.edtBerichtsperiodeBis.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBerichtsperiodeBis.EditValue = null;
            this.edtBerichtsperiodeBis.Location = new System.Drawing.Point(248, 34);
            this.edtBerichtsperiodeBis.Name = "edtBerichtsperiodeBis";
            this.edtBerichtsperiodeBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBerichtsperiodeBis.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBerichtsperiodeBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBerichtsperiodeBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBerichtsperiodeBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtBerichtsperiodeBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBerichtsperiodeBis.Properties.Appearance.Options.UseFont = true;
            this.edtBerichtsperiodeBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject19.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject19.Options.UseBackColor = true;
            this.edtBerichtsperiodeBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtBerichtsperiodeBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject19)});
            this.edtBerichtsperiodeBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBerichtsperiodeBis.Properties.ReadOnly = true;
            this.edtBerichtsperiodeBis.Properties.ShowToday = false;
            this.edtBerichtsperiodeBis.Size = new System.Drawing.Size(100, 24);
            this.edtBerichtsperiodeBis.TabIndex = 1;
            // 
            // edtBerichtsperiodeVon
            // 
            this.edtBerichtsperiodeVon.DataMember = "DatumVon";
            this.edtBerichtsperiodeVon.DataSource = this.qryBericht;
            this.edtBerichtsperiodeVon.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBerichtsperiodeVon.EditValue = null;
            this.edtBerichtsperiodeVon.Location = new System.Drawing.Point(119, 33);
            this.edtBerichtsperiodeVon.Name = "edtBerichtsperiodeVon";
            this.edtBerichtsperiodeVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBerichtsperiodeVon.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBerichtsperiodeVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBerichtsperiodeVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBerichtsperiodeVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtBerichtsperiodeVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBerichtsperiodeVon.Properties.Appearance.Options.UseFont = true;
            this.edtBerichtsperiodeVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject20.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject20.Options.UseBackColor = true;
            this.edtBerichtsperiodeVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtBerichtsperiodeVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject20)});
            this.edtBerichtsperiodeVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBerichtsperiodeVon.Properties.ReadOnly = true;
            this.edtBerichtsperiodeVon.Properties.ShowToday = false;
            this.edtBerichtsperiodeVon.Size = new System.Drawing.Size(100, 24);
            this.edtBerichtsperiodeVon.TabIndex = 0;
            // 
            // tbpBerichtHist
            // 
            this.tbpBerichtHist.Controls.Add(this.kissLabel12);
            this.tbpBerichtHist.Controls.Add(this.docBerichtHist);
            this.tbpBerichtHist.Controls.Add(this.grdVmBericht);
            this.tbpBerichtHist.Location = new System.Drawing.Point(6, 32);
            this.tbpBerichtHist.Name = "tbpBerichtHist";
            this.tbpBerichtHist.Size = new System.Drawing.Size(857, 274);
            this.tbpBerichtHist.TabIndex = 1;
            this.tbpBerichtHist.Title = "Historie";
            // 
            // kissLabel12
            // 
            this.kissLabel12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel12.Location = new System.Drawing.Point(2, 240);
            this.kissLabel12.Name = "kissLabel12";
            this.kissLabel12.Size = new System.Drawing.Size(100, 23);
            this.kissLabel12.TabIndex = 662;
            this.kissLabel12.Text = "Berichts-Dokument";
            this.kissLabel12.UseCompatibleTextRendering = true;
            // 
            // docBerichtHist
            // 
            this.docBerichtHist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.docBerichtHist.CanDeleteDocument = false;
            this.docBerichtHist.CanImportDocument = false;
            this.docBerichtHist.Context = "FaDokumente";
            this.docBerichtHist.DataMember = "DocumentID";
            this.docBerichtHist.DataSource = this.qryBerichtHistory;
            this.docBerichtHist.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.docBerichtHist.Location = new System.Drawing.Point(123, 242);
            this.docBerichtHist.Name = "docBerichtHist";
            this.docBerichtHist.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.docBerichtHist.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.docBerichtHist.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docBerichtHist.Properties.Appearance.Options.UseBackColor = true;
            this.docBerichtHist.Properties.Appearance.Options.UseBorderColor = true;
            this.docBerichtHist.Properties.Appearance.Options.UseFont = true;
            this.docBerichtHist.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject21.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject21.Options.UseBackColor = true;
            this.docBerichtHist.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docBerichtHist.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject21, "Dokument öffnen")});
            this.docBerichtHist.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.docBerichtHist.Properties.Name = "edtFaDokKorreDokument.Properties";
            this.docBerichtHist.Properties.ReadOnly = true;
            this.docBerichtHist.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.docBerichtHist.Size = new System.Drawing.Size(90, 24);
            this.docBerichtHist.TabIndex = 1;
            // 
            // qryBerichtHistory
            // 
            this.qryBerichtHistory.HostControl = this;
            this.qryBerichtHistory.SelectStatement = resources.GetString("qryBerichtHistory.SelectStatement");
            // 
            // grdVmBericht
            // 
            this.grdVmBericht.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdVmBericht.DataSource = this.qryBerichtHistory;
            // 
            // 
            // 
            this.grdVmBericht.EmbeddedNavigator.Name = "";
            this.grdVmBericht.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdVmBericht.Location = new System.Drawing.Point(0, 0);
            this.grdVmBericht.MainView = this.grvVmBericht;
            this.grdVmBericht.Name = "grdVmBericht";
            this.grdVmBericht.Size = new System.Drawing.Size(857, 224);
            this.grdVmBericht.TabIndex = 0;
            this.grdVmBericht.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVmBericht});
            // 
            // grvVmBericht
            // 
            this.grvVmBericht.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvVmBericht.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmBericht.Appearance.Empty.Options.UseBackColor = true;
            this.grvVmBericht.Appearance.Empty.Options.UseFont = true;
            this.grvVmBericht.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmBericht.Appearance.EvenRow.Options.UseFont = true;
            this.grvVmBericht.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVmBericht.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmBericht.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvVmBericht.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvVmBericht.Appearance.FocusedCell.Options.UseFont = true;
            this.grvVmBericht.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvVmBericht.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVmBericht.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmBericht.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvVmBericht.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvVmBericht.Appearance.FocusedRow.Options.UseFont = true;
            this.grvVmBericht.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvVmBericht.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVmBericht.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvVmBericht.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvVmBericht.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvVmBericht.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVmBericht.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvVmBericht.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVmBericht.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVmBericht.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVmBericht.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvVmBericht.Appearance.GroupRow.Options.UseFont = true;
            this.grvVmBericht.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvVmBericht.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvVmBericht.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvVmBericht.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVmBericht.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvVmBericht.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvVmBericht.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvVmBericht.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvVmBericht.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmBericht.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVmBericht.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvVmBericht.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvVmBericht.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvVmBericht.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvVmBericht.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvVmBericht.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmBericht.Appearance.OddRow.Options.UseFont = true;
            this.grvVmBericht.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvVmBericht.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmBericht.Appearance.Row.Options.UseBackColor = true;
            this.grvVmBericht.Appearance.Row.Options.UseFont = true;
            this.grvVmBericht.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmBericht.Appearance.SelectedRow.Options.UseFont = true;
            this.grvVmBericht.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvVmBericht.Appearance.VertLine.Options.UseBackColor = true;
            this.grvVmBericht.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvVmBericht.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBHDatumVon,
            this.colBHDatumBis,
            this.colBHDatumBerichtMT,
            this.colBHDatumVersandAnVB,
            this.colBHGenehmigung1,
            this.colBHGenehmigung2,
            this.colBHBemerkung,
            this.colBHSpesen,
            this.colBHEingangSDS,
            this.colBHAusgangSDS,
            this.colBHFristerstreckung,
            this.colBHMahnung1,
            this.colBHMahnung2,
            this.colBHMahnung3,
            this.colBHMAKlibu,
            this.colBHMandatsTraegerName,
            this.colBHVisBerichtsnummer});
            this.grvVmBericht.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvVmBericht.GridControl = this.grdVmBericht;
            this.grvVmBericht.Name = "grvVmBericht";
            this.grvVmBericht.OptionsBehavior.Editable = false;
            this.grvVmBericht.OptionsCustomization.AllowFilter = false;
            this.grvVmBericht.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvVmBericht.OptionsNavigation.AutoFocusNewRow = true;
            this.grvVmBericht.OptionsNavigation.UseTabKey = false;
            this.grvVmBericht.OptionsView.ColumnAutoWidth = false;
            this.grvVmBericht.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvVmBericht.OptionsView.ShowGroupPanel = false;
            this.grvVmBericht.OptionsView.ShowIndicator = false;
            // 
            // colBHDatumVon
            // 
            this.colBHDatumVon.Caption = "Periode Von";
            this.colBHDatumVon.FieldName = "DatumVon";
            this.colBHDatumVon.Name = "colBHDatumVon";
            this.colBHDatumVon.Visible = true;
            this.colBHDatumVon.VisibleIndex = 0;
            this.colBHDatumVon.Width = 80;
            // 
            // colBHDatumBis
            // 
            this.colBHDatumBis.Caption = "Periode Bis";
            this.colBHDatumBis.FieldName = "DatumBis";
            this.colBHDatumBis.Name = "colBHDatumBis";
            this.colBHDatumBis.Visible = true;
            this.colBHDatumBis.VisibleIndex = 1;
            // 
            // colBHDatumBerichtMT
            // 
            this.colBHDatumBerichtMT.Caption = "Erstellung Bericht";
            this.colBHDatumBerichtMT.FieldName = "DatumBerichtMT";
            this.colBHDatumBerichtMT.Name = "colBHDatumBerichtMT";
            this.colBHDatumBerichtMT.Visible = true;
            this.colBHDatumBerichtMT.VisibleIndex = 6;
            this.colBHDatumBerichtMT.Width = 110;
            // 
            // colBHDatumVersandAnVB
            // 
            this.colBHDatumVersandAnVB.Caption = "Versand an KESB";
            this.colBHDatumVersandAnVB.FieldName = "DatumVersandAnVB";
            this.colBHDatumVersandAnVB.Name = "colBHDatumVersandAnVB";
            this.colBHDatumVersandAnVB.Visible = true;
            this.colBHDatumVersandAnVB.VisibleIndex = 12;
            this.colBHDatumVersandAnVB.Width = 93;
            // 
            // colBHGenehmigung1
            // 
            this.colBHGenehmigung1.Caption = "Genehm. KESB";
            this.colBHGenehmigung1.FieldName = "DatumGenehmigung1";
            this.colBHGenehmigung1.Name = "colBHGenehmigung1";
            this.colBHGenehmigung1.Visible = true;
            this.colBHGenehmigung1.VisibleIndex = 13;
            this.colBHGenehmigung1.Width = 80;
            // 
            // colBHGenehmigung2
            // 
            this.colBHGenehmigung2.Caption = "Genehm. BRZ (gültig bis 31.12.2012)";
            this.colBHGenehmigung2.FieldName = "DatumGenehmigung2";
            this.colBHGenehmigung2.Name = "colBHGenehmigung2";
            this.colBHGenehmigung2.Visible = true;
            this.colBHGenehmigung2.VisibleIndex = 14;
            this.colBHGenehmigung2.Width = 86;
            // 
            // colBHBemerkung
            // 
            this.colBHBemerkung.Caption = "Bemerkung";
            this.colBHBemerkung.FieldName = "Bemerkung";
            this.colBHBemerkung.Name = "colBHBemerkung";
            this.colBHBemerkung.Visible = true;
            this.colBHBemerkung.VisibleIndex = 15;
            this.colBHBemerkung.Width = 78;
            // 
            // colBHSpesen
            // 
            this.colBHSpesen.Caption = "Spesen";
            this.colBHSpesen.DisplayFormat.FormatString = "#0.00";
            this.colBHSpesen.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBHSpesen.FieldName = "BetragSpesen";
            this.colBHSpesen.Name = "colBHSpesen";
            this.colBHSpesen.Visible = true;
            this.colBHSpesen.VisibleIndex = 8;
            this.colBHSpesen.Width = 54;
            // 
            // colBHEingangSDS
            // 
            this.colBHEingangSDS.Caption = "Eingang SDS";
            this.colBHEingangSDS.FieldName = "DatumEingangSDS";
            this.colBHEingangSDS.Name = "colBHEingangSDS";
            this.colBHEingangSDS.Visible = true;
            this.colBHEingangSDS.VisibleIndex = 9;
            this.colBHEingangSDS.Width = 79;
            // 
            // colBHAusgangSDS
            // 
            this.colBHAusgangSDS.Caption = "Ausgang SDS";
            this.colBHAusgangSDS.FieldName = "DatumAusgangSDS";
            this.colBHAusgangSDS.Name = "colBHAusgangSDS";
            this.colBHAusgangSDS.Visible = true;
            this.colBHAusgangSDS.VisibleIndex = 11;
            this.colBHAusgangSDS.Width = 85;
            // 
            // colBHFristerstreckung
            // 
            this.colBHFristerstreckung.Caption = "Fristerstreckung";
            this.colBHFristerstreckung.FieldName = "DatumFristerstreckung";
            this.colBHFristerstreckung.Name = "colBHFristerstreckung";
            this.colBHFristerstreckung.Visible = true;
            this.colBHFristerstreckung.VisibleIndex = 2;
            this.colBHFristerstreckung.Width = 106;
            // 
            // colBHMahnung1
            // 
            this.colBHMahnung1.Caption = "1. Mahnung";
            this.colBHMahnung1.FieldName = "DatumMahnung1";
            this.colBHMahnung1.Name = "colBHMahnung1";
            this.colBHMahnung1.Visible = true;
            this.colBHMahnung1.VisibleIndex = 3;
            // 
            // colBHMahnung2
            // 
            this.colBHMahnung2.Caption = "2. Mahnung";
            this.colBHMahnung2.FieldName = "DatumMahnung2";
            this.colBHMahnung2.Name = "colBHMahnung2";
            this.colBHMahnung2.Visible = true;
            this.colBHMahnung2.VisibleIndex = 4;
            // 
            // colBHMahnung3
            // 
            this.colBHMahnung3.Caption = "3. Mahnung";
            this.colBHMahnung3.FieldName = "DatumMahnung3";
            this.colBHMahnung3.Name = "colBHMahnung3";
            this.colBHMahnung3.Visible = true;
            this.colBHMahnung3.VisibleIndex = 5;
            // 
            // colBHMAKlibu
            // 
            this.colBHMAKlibu.Caption = "MA Klibu";
            this.colBHMAKlibu.FieldName = "MaKlibuUser";
            this.colBHMAKlibu.Name = "colBHMAKlibu";
            this.colBHMAKlibu.Visible = true;
            this.colBHMAKlibu.VisibleIndex = 10;
            // 
            // colBHMandatsTraegerName
            // 
            this.colBHMandatsTraegerName.Caption = "Beist. oder Vorm.";
            this.colBHMandatsTraegerName.FieldName = "MandatsTraegerName";
            this.colBHMandatsTraegerName.Name = "colBHMandatsTraegerName";
            this.colBHMandatsTraegerName.Visible = true;
            this.colBHMandatsTraegerName.VisibleIndex = 7;
            this.colBHMandatsTraegerName.Width = 110;
            // 
            // colBHVisBerichtsnummer
            // 
            this.colBHVisBerichtsnummer.Caption = "Berichtsnummer";
            this.colBHVisBerichtsnummer.FieldName = "VIS_Berichtsnummer";
            this.colBHVisBerichtsnummer.Name = "colBHVisBerichtsnummer";
            this.colBHVisBerichtsnummer.Visible = true;
            this.colBHVisBerichtsnummer.VisibleIndex = 16;
            this.colBHVisBerichtsnummer.Width = 110;
            // 
            // kissLabel7
            // 
            this.kissLabel7.Location = new System.Drawing.Point(5, 7);
            this.kissLabel7.Name = "kissLabel7";
            this.kissLabel7.Size = new System.Drawing.Size(85, 24);
            this.kissLabel7.TabIndex = 645;
            this.kissLabel7.Text = "Massnahme";
            this.kissLabel7.UseCompatibleTextRendering = true;
            // 
            // kissTextEdit3
            // 
            this.kissTextEdit3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kissTextEdit3.DataMember = "Massnahme";
            this.kissTextEdit3.DataSource = this.qryVmMassnahme;
            this.kissTextEdit3.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit3.Location = new System.Drawing.Point(96, 7);
            this.kissTextEdit3.Name = "kissTextEdit3";
            this.kissTextEdit3.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit3.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit3.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit3.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit3.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit3.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit3.Properties.Name = "editSAR.Properties";
            this.kissTextEdit3.Properties.ReadOnly = true;
            this.kissTextEdit3.Size = new System.Drawing.Size(621, 24);
            this.kissTextEdit3.TabIndex = 0;
            // 
            // tbpMassnahmeHist
            // 
            this.tbpMassnahmeHist.Controls.Add(this.Grid1);
            this.tbpMassnahmeHist.Location = new System.Drawing.Point(6, 32);
            this.tbpMassnahmeHist.Name = "tbpMassnahmeHist";
            this.tbpMassnahmeHist.Size = new System.Drawing.Size(877, 497);
            this.tbpMassnahmeHist.TabIndex = 1;
            this.tbpMassnahmeHist.Title = "Historie";
            // 
            // CtlVISMassnahme
            // 
            this.ActiveSQLQuery = this.qryBericht;
            this.Controls.Add(this.tabMassnahmen);
            this.Controls.Add(this.panel1);
            this.Name = "CtlVISMassnahme";
            this.Size = new System.Drawing.Size(892, 565);
            this.Load += new System.EventHandler(this.CtlVISMassnahme_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVmMassnahmeHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVmMassnahme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAufhebung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBerichtsperioden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVmBerichtsperioden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).EndInit();
            this.tabMassnahmen.ResumeLayout(false);
            this.tbpMassnahme.ResumeLayout(false);
            this.tabBerichte.ResumeLayout(false);
            this.tbpBericht.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtBerichtsnummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBericht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBerichtsnummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docVermoegensabrechnung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMaKlibuUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheUserID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBerichtsart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docBericht.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissDateEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissDateEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissDateEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumFristerstreckung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumFristerstreckung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumAusgangSDS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumAusgangSDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumEingangSDS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumEingangSDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVermoegensabrechnung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumGenehmigung1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVersandAnVB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBerichtMT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumGenehmigung1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVersandAnVB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBerichtMT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBerichtsperiodeBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBerichtsperiodeVon.Properties)).EndInit();
            this.tbpBerichtHist.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docBerichtHist.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBerichtHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVmBericht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVmBericht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit3.Properties)).EndInit();
            this.tbpMassnahmeHist.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

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

        private Gui.KissTextEdit edtBerichtsnummer;
        private Gui.KissLabel lblBerichtsnummer;
        private DevExpress.XtraGrid.Columns.GridColumn colBHVisBerichtsnummer;
    }
}