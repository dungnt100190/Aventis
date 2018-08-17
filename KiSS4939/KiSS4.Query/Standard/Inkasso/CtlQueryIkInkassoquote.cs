
namespace KiSS4.Query
{
    public class CtlQueryIkInkassoquote : KiSS4.Common.KissQueryControl
    {
        #region Fields

        private DevExpress.XtraGrid.Columns.GridColumn colBelegDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colBelegNr;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colForderung;
        private DevExpress.XtraGrid.Columns.GridColumn colGlubiger;
        private DevExpress.XtraGrid.Columns.GridColumn colHabenKtoNr;
        private DevExpress.XtraGrid.Columns.GridColumn colInkassoquote;
        private DevExpress.XtraGrid.Columns.GridColumn colSchuldner;
        private DevExpress.XtraGrid.Columns.GridColumn colSollKtoNr;
        private DevExpress.XtraGrid.Columns.GridColumn colText;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalForderungen;
        private DevExpress.XtraGrid.Columns.GridColumn colTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colZahlung;
        private DevExpress.XtraGrid.Columns.GridColumn colZahlungen;
        private DevExpress.XtraGrid.Columns.GridColumn coleinmaligeForderungen;
        private DevExpress.XtraGrid.Columns.GridColumn colperiodischeForderungen;
        private System.ComponentModel.IContainer components;
        private KiSS4.Common.CtlGotoFall ctlGotoFallStelleBI;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissCheckEdit edtDetailMode;
        private KiSS4.Gui.KissLookUpEdit edtForderungsart;
        private KiSS4.Gui.KissLookUpEdit edtInkassoTyp;
        private KiSS4.Gui.KissLookUpEdit edtInkassoTypUnterart;
        private KiSS4.Gui.KissLookUpEdit edtInkassofallStatus;
        private KiSS4.Gui.KissCheckEdit edtInklAbgeschlossene;
        private KiSS4.Gui.KissCheckEdit edtInklArchivierte;
        private KiSS4.Gui.KissCheckEdit edtInklEinmalige;
        private KiSS4.Gui.KissButtonEdit edtSAR_ID;
        private KiSS4.Gui.KissLabel edtlblForderungsart;
        private KiSS4.Gui.KissLabel edtlblInkassoTyp;
        private KiSS4.Gui.KissLabel edtlblInkassoTypUnterart;
        private KiSS4.Gui.KissLabel edtlblInkassofallStatus;
        private KiSS4.Gui.KissGrid grdDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDetails;
        private KiSS4.Gui.KissLabel lblSAR;
        private KiSS4.Gui.KissLabel lblZeitraumvon;
        private KiSS4.Gui.KissLabel lblbis;
        private KiSS4.DB.SqlQuery qryDetails;
        private SharpLibrary.WinControls.TabPageEx tpgDetails;

        #endregion

        #region Constructors

        public CtlQueryIkInkassoquote()
        {
            this.InitializeComponent();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryIkInkassoquote));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.tpgDetails = new SharpLibrary.WinControls.TabPageEx();
            this.ctlGotoFallStelleBI = new KiSS4.Common.CtlGotoFall();
            this.qryDetails = new KiSS4.DB.SqlQuery(this.components);
            this.grdDetails = new KiSS4.Gui.KissGrid();
            this.grvDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblSAR = new KiSS4.Gui.KissLabel();
            this.edtSAR_ID = new KiSS4.Gui.KissButtonEdit();
            this.lblZeitraumvon = new KiSS4.Gui.KissLabel();
            this.lblbis = new KiSS4.Gui.KissLabel();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtlblInkassoTyp = new KiSS4.Gui.KissLabel();
            this.edtInkassoTyp = new KiSS4.Gui.KissLookUpEdit();
            this.edtlblInkassoTypUnterart = new KiSS4.Gui.KissLabel();
            this.edtInkassoTypUnterart = new KiSS4.Gui.KissLookUpEdit();
            this.edtlblForderungsart = new KiSS4.Gui.KissLabel();
            this.edtForderungsart = new KiSS4.Gui.KissLookUpEdit();
            this.edtlblInkassofallStatus = new KiSS4.Gui.KissLabel();
            this.edtInkassofallStatus = new KiSS4.Gui.KissLookUpEdit();
            this.edtInklEinmalige = new KiSS4.Gui.KissCheckEdit();
            this.edtInklAbgeschlossene = new KiSS4.Gui.KissCheckEdit();
            this.edtInklArchivierte = new KiSS4.Gui.KissCheckEdit();
            this.edtDetailMode = new KiSS4.Gui.KissCheckEdit();
            this.colBelegDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBelegNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coleinmaligeForderungen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colForderung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlubiger = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHabenKtoNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInkassoquote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colperiodischeForderungen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchuldner = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSollKtoNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalForderungen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZahlung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZahlungen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            this.tpgDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSAR_ID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitraumvon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtlblInkassoTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassoTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassoTyp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtlblInkassoTypUnterart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassoTypUnterart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassoTypUnterart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtlblForderungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtForderungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtForderungsart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtlblInkassofallStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassofallStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassofallStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInklEinmalige.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInklAbgeschlossene.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInklArchivierte.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDetailMode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            this.qryQuery.AfterFill += new System.EventHandler(this.qryQuery_AfterFill);
            // 
            // grvQuery1
            // 
            this.grvQuery1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvQuery1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.Empty.Options.UseBackColor = true;
            this.grvQuery1.Appearance.Empty.Options.UseFont = true;
            this.grvQuery1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvQuery1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.EvenRow.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvQuery1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvQuery1.Appearance.FocusedCell.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvQuery1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvQuery1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.FocusedRow.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseFont = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvQuery1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvQuery1.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvQuery1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvQuery1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery1.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvQuery1.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvQuery1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.OddRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.OddRow.Options.UseFont = true;
            this.grvQuery1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvQuery1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.Row.Options.UseBackColor = true;
            this.grvQuery1.Appearance.Row.Options.UseFont = true;
            this.grvQuery1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvQuery1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvQuery1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.SelectedRow.Options.UseFont = true;
            this.grvQuery1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery1.Appearance.VertLine.Options.UseBackColor = true;
            this.grvQuery1.OptionsBehavior.Editable = false;
            this.grvQuery1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvQuery1.OptionsNavigation.AutoFocusNewRow = true;
            this.grvQuery1.OptionsNavigation.UseTabKey = false;
            this.grvQuery1.OptionsPrint.AutoWidth = false;
            this.grvQuery1.OptionsPrint.ExpandAllDetails = true;
            this.grvQuery1.OptionsPrint.UsePrintStyles = true;
            this.grvQuery1.OptionsView.ColumnAutoWidth = false;
            this.grvQuery1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvQuery1.OptionsView.ShowGroupPanel = false;
            this.grvQuery1.OptionsView.ShowIndicator = false;
            // 
            // grdQuery1
            // 
            // 
            // 
            // 
            this.grdQuery1.EmbeddedNavigator.Name = "";
            this.grdQuery1.MainView = this.gridView1;
            this.grdQuery1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // xDocument
            // 
            this.xDocument.DataMember = null;
            this.xDocument.EditValue = null;
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
            this.xDocument.Visible = false;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = null;
            this.ctlGotoFall.Visible = false;
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Controls.Add(this.tpgDetails);
            this.tabControlSearch.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgDetails});
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListe, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgDetails, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgSuchen, 0);
            // 
            // tpgListe
            // 
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtDetailMode);
            this.tpgSuchen.Controls.Add(this.edtInklArchivierte);
            this.tpgSuchen.Controls.Add(this.edtInklAbgeschlossene);
            this.tpgSuchen.Controls.Add(this.edtInklEinmalige);
            this.tpgSuchen.Controls.Add(this.edtInkassofallStatus);
            this.tpgSuchen.Controls.Add(this.edtlblInkassofallStatus);
            this.tpgSuchen.Controls.Add(this.edtForderungsart);
            this.tpgSuchen.Controls.Add(this.edtlblForderungsart);
            this.tpgSuchen.Controls.Add(this.edtInkassoTypUnterart);
            this.tpgSuchen.Controls.Add(this.edtlblInkassoTypUnterart);
            this.tpgSuchen.Controls.Add(this.edtInkassoTyp);
            this.tpgSuchen.Controls.Add(this.edtlblInkassoTyp);
            this.tpgSuchen.Controls.Add(this.edtDatumBis);
            this.tpgSuchen.Controls.Add(this.edtDatumVon);
            this.tpgSuchen.Controls.Add(this.lblbis);
            this.tpgSuchen.Controls.Add(this.lblZeitraumvon);
            this.tpgSuchen.Controls.Add(this.edtSAR_ID);
            this.tpgSuchen.Controls.Add(this.lblSAR);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.TabIndex = 2;
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSAR, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSAR_ID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZeitraumvon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblbis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtlblInkassoTyp, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtInkassoTyp, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtlblInkassoTypUnterart, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtInkassoTypUnterart, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtlblForderungsart, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtForderungsart, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtlblInkassofallStatus, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtInkassofallStatus, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtInklEinmalige, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtInklAbgeschlossene, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtInklArchivierte, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDetailMode, 0);
            // 
            // tpgDetails
            // 
            this.tpgDetails.Controls.Add(this.ctlGotoFallStelleBI);
            this.tpgDetails.Controls.Add(this.grdDetails);
            this.tpgDetails.Location = new System.Drawing.Point(6, 6);
            this.tpgDetails.Name = "tpgDetails";
            this.tpgDetails.Size = new System.Drawing.Size(772, 424);
            this.tpgDetails.TabIndex = 1;
            this.tpgDetails.Title = "Details";
            // 
            // ctlGotoFallStelleBI
            // 
            this.ctlGotoFallStelleBI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctlGotoFallStelleBI.BaPersonID = ((object)(resources.GetObject("ctlGotoFallStelleBI.BaPersonID")));
            this.ctlGotoFallStelleBI.DataMember = "BaPersonID$";
            this.ctlGotoFallStelleBI.DataSource = this.qryDetails;
            this.ctlGotoFallStelleBI.Location = new System.Drawing.Point(3, 397);
            this.ctlGotoFallStelleBI.Name = "ctlGotoFallStelleBI";
            this.ctlGotoFallStelleBI.Size = new System.Drawing.Size(154, 24);
            this.ctlGotoFallStelleBI.TabIndex = 5;
            // 
            // qryDetails
            // 
            this.qryDetails.FillTimeOut = 300;
            this.qryDetails.HostControl = this;
            this.qryDetails.SelectStatement = resources.GetString("qryDetails.SelectStatement");
            // 
            // grdDetails
            // 
            this.grdDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDetails.DataSource = this.qryDetails;
            // 
            // 
            // 
            this.grdDetails.EmbeddedNavigator.Name = "";
            this.grdDetails.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdDetails.Location = new System.Drawing.Point(3, 1);
            this.grdDetails.MainView = this.grvDetails;
            this.grdDetails.Name = "grdDetails";
            this.grdDetails.Size = new System.Drawing.Size(766, 392);
            this.grdDetails.TabIndex = 4;
            this.grdDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDetails});
            // 
            // grvDetails
            // 
            this.grvDetails.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvDetails.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDetails.Appearance.Empty.Options.UseBackColor = true;
            this.grvDetails.Appearance.Empty.Options.UseFont = true;
            this.grvDetails.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDetails.Appearance.EvenRow.Options.UseFont = true;
            this.grvDetails.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvDetails.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDetails.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvDetails.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvDetails.Appearance.FocusedCell.Options.UseFont = true;
            this.grvDetails.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvDetails.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvDetails.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDetails.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvDetails.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvDetails.Appearance.FocusedRow.Options.UseFont = true;
            this.grvDetails.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvDetails.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvDetails.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvDetails.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvDetails.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvDetails.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvDetails.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvDetails.Appearance.GroupRow.Options.UseFont = true;
            this.grvDetails.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvDetails.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvDetails.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvDetails.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvDetails.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvDetails.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvDetails.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvDetails.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvDetails.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDetails.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvDetails.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvDetails.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvDetails.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvDetails.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvDetails.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvDetails.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDetails.Appearance.OddRow.Options.UseFont = true;
            this.grvDetails.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvDetails.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDetails.Appearance.Row.Options.UseBackColor = true;
            this.grvDetails.Appearance.Row.Options.UseFont = true;
            this.grvDetails.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDetails.Appearance.SelectedRow.Options.UseFont = true;
            this.grvDetails.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvDetails.Appearance.VertLine.Options.UseBackColor = true;
            this.grvDetails.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvDetails.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvDetails.GridControl = this.grdDetails;
            this.grvDetails.Name = "grvDetails";
            this.grvDetails.OptionsBehavior.Editable = false;
            this.grvDetails.OptionsCustomization.AllowFilter = false;
            this.grvDetails.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvDetails.OptionsNavigation.AutoFocusNewRow = true;
            this.grvDetails.OptionsNavigation.UseTabKey = false;
            this.grvDetails.OptionsView.ColumnAutoWidth = false;
            this.grvDetails.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvDetails.OptionsView.ShowGroupPanel = false;
            this.grvDetails.OptionsView.ShowIndicator = false;
            // 
            // lblSAR
            // 
            this.lblSAR.Location = new System.Drawing.Point(10, 40);
            this.lblSAR.Name = "lblSAR";
            this.lblSAR.Size = new System.Drawing.Size(130, 24);
            this.lblSAR.TabIndex = 1;
            this.lblSAR.Text = "SAR";
            this.lblSAR.UseCompatibleTextRendering = true;
            // 
            // edtSAR_ID
            // 
            this.edtSAR_ID.Location = new System.Drawing.Point(150, 40);
            this.edtSAR_ID.LookupSQL = "select ID = UserID, SAR = LastName + isNull(\', \' + FirstName,\'\'), [Kuerzel] = Log" +
                "onName\nfrom   XUser \nwhere LastName + isNull(\', \' + FirstName,\'\') like {0} + \'%\'" +
                " \norder by SAR";
            this.edtSAR_ID.Name = "edtSAR_ID";
            this.edtSAR_ID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSAR_ID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSAR_ID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSAR_ID.Properties.Appearance.Options.UseBackColor = true;
            this.edtSAR_ID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSAR_ID.Properties.Appearance.Options.UseFont = true;
            this.edtSAR_ID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtSAR_ID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtSAR_ID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSAR_ID.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtSAR_ID.Size = new System.Drawing.Size(265, 24);
            this.edtSAR_ID.TabIndex = 2;
            // 
            // lblZeitraumvon
            // 
            this.lblZeitraumvon.Location = new System.Drawing.Point(10, 70);
            this.lblZeitraumvon.Name = "lblZeitraumvon";
            this.lblZeitraumvon.Size = new System.Drawing.Size(130, 24);
            this.lblZeitraumvon.TabIndex = 3;
            this.lblZeitraumvon.Text = "Zeitraum von";
            this.lblZeitraumvon.UseCompatibleTextRendering = true;
            // 
            // lblbis
            // 
            this.lblbis.Location = new System.Drawing.Point(285, 70);
            this.lblbis.Name = "lblbis";
            this.lblbis.Size = new System.Drawing.Size(130, 24);
            this.lblbis.TabIndex = 4;
            this.lblbis.Text = "bis";
            this.lblbis.UseCompatibleTextRendering = true;
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.EditValue = "";
            this.edtDatumVon.Location = new System.Drawing.Point(150, 70);
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
            this.edtDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVon.TabIndex = 5;
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.EditValue = "";
            this.edtDatumBis.Location = new System.Drawing.Point(315, 70);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBis.TabIndex = 6;
            // 
            // edtlblInkassoTyp
            // 
            this.edtlblInkassoTyp.Location = new System.Drawing.Point(10, 100);
            this.edtlblInkassoTyp.Name = "edtlblInkassoTyp";
            this.edtlblInkassoTyp.Size = new System.Drawing.Size(128, 24);
            this.edtlblInkassoTyp.TabIndex = 7;
            this.edtlblInkassoTyp.Text = "Inkasso-Typ";
            this.edtlblInkassoTyp.UseCompatibleTextRendering = true;
            // 
            // edtInkassoTyp
            // 
            this.edtInkassoTyp.Location = new System.Drawing.Point(150, 100);
            this.edtInkassoTyp.LOVFilter = "Code between 401 and 499";
            this.edtInkassoTyp.LOVFilterWhereAppend = true;
            this.edtInkassoTyp.LOVName = "FaProzess";
            this.edtInkassoTyp.Name = "edtInkassoTyp";
            this.edtInkassoTyp.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtInkassoTyp.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtInkassoTyp.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtInkassoTyp.Properties.Appearance.Options.UseBackColor = true;
            this.edtInkassoTyp.Properties.Appearance.Options.UseBorderColor = true;
            this.edtInkassoTyp.Properties.Appearance.Options.UseFont = true;
            this.edtInkassoTyp.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtInkassoTyp.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtInkassoTyp.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtInkassoTyp.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtInkassoTyp.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtInkassoTyp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtInkassoTyp.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtInkassoTyp.Properties.NullText = "";
            this.edtInkassoTyp.Properties.ShowFooter = false;
            this.edtInkassoTyp.Properties.ShowHeader = false;
            this.edtInkassoTyp.Size = new System.Drawing.Size(265, 24);
            this.edtInkassoTyp.TabIndex = 8;
            // 
            // edtlblInkassoTypUnterart
            // 
            this.edtlblInkassoTypUnterart.Location = new System.Drawing.Point(10, 130);
            this.edtlblInkassoTypUnterart.Name = "edtlblInkassoTypUnterart";
            this.edtlblInkassoTypUnterart.Size = new System.Drawing.Size(128, 24);
            this.edtlblInkassoTypUnterart.TabIndex = 9;
            this.edtlblInkassoTypUnterart.Text = "Inkasso-Typ Unterart";
            this.edtlblInkassoTypUnterart.UseCompatibleTextRendering = true;
            // 
            // edtInkassoTypUnterart
            // 
            this.edtInkassoTypUnterart.Location = new System.Drawing.Point(150, 130);
            this.edtInkassoTypUnterart.LOVFilter = "code between 40000 and 49000";
            this.edtInkassoTypUnterart.LOVFilterWhereAppend = true;
            this.edtInkassoTypUnterart.LOVName = "Eroeffnungsgrund";
            this.edtInkassoTypUnterart.Name = "edtInkassoTypUnterart";
            this.edtInkassoTypUnterart.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtInkassoTypUnterart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtInkassoTypUnterart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtInkassoTypUnterart.Properties.Appearance.Options.UseBackColor = true;
            this.edtInkassoTypUnterart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtInkassoTypUnterart.Properties.Appearance.Options.UseFont = true;
            this.edtInkassoTypUnterart.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtInkassoTypUnterart.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtInkassoTypUnterart.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtInkassoTypUnterart.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtInkassoTypUnterart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtInkassoTypUnterart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtInkassoTypUnterart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtInkassoTypUnterart.Properties.NullText = "";
            this.edtInkassoTypUnterart.Properties.ShowFooter = false;
            this.edtInkassoTypUnterart.Properties.ShowHeader = false;
            this.edtInkassoTypUnterart.Size = new System.Drawing.Size(265, 24);
            this.edtInkassoTypUnterart.TabIndex = 10;
            // 
            // edtlblForderungsart
            // 
            this.edtlblForderungsart.Location = new System.Drawing.Point(10, 160);
            this.edtlblForderungsart.Name = "edtlblForderungsart";
            this.edtlblForderungsart.Size = new System.Drawing.Size(128, 24);
            this.edtlblForderungsart.TabIndex = 11;
            this.edtlblForderungsart.Text = "Forderungsart";
            this.edtlblForderungsart.UseCompatibleTextRendering = true;
            // 
            // edtForderungsart
            // 
            this.edtForderungsart.Location = new System.Drawing.Point(150, 160);
            this.edtForderungsart.LOVName = "IkForderungEinmalig";
            this.edtForderungsart.Name = "edtForderungsart";
            this.edtForderungsart.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtForderungsart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtForderungsart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtForderungsart.Properties.Appearance.Options.UseBackColor = true;
            this.edtForderungsart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtForderungsart.Properties.Appearance.Options.UseFont = true;
            this.edtForderungsart.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtForderungsart.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtForderungsart.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtForderungsart.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtForderungsart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtForderungsart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtForderungsart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtForderungsart.Properties.NullText = "";
            this.edtForderungsart.Properties.ShowFooter = false;
            this.edtForderungsart.Properties.ShowHeader = false;
            this.edtForderungsart.Size = new System.Drawing.Size(400, 24);
            this.edtForderungsart.TabIndex = 12;
            // 
            // edtlblInkassofallStatus
            // 
            this.edtlblInkassofallStatus.Location = new System.Drawing.Point(10, 190);
            this.edtlblInkassofallStatus.Name = "edtlblInkassofallStatus";
            this.edtlblInkassofallStatus.Size = new System.Drawing.Size(128, 24);
            this.edtlblInkassofallStatus.TabIndex = 13;
            this.edtlblInkassofallStatus.Text = "Status";
            this.edtlblInkassofallStatus.UseCompatibleTextRendering = true;
            // 
            // edtInkassofallStatus
            // 
            this.edtInkassofallStatus.Location = new System.Drawing.Point(150, 190);
            this.edtInkassofallStatus.LOVName = "IkLeistungStatus";
            this.edtInkassofallStatus.Name = "edtInkassofallStatus";
            this.edtInkassofallStatus.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtInkassofallStatus.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtInkassofallStatus.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtInkassofallStatus.Properties.Appearance.Options.UseBackColor = true;
            this.edtInkassofallStatus.Properties.Appearance.Options.UseBorderColor = true;
            this.edtInkassofallStatus.Properties.Appearance.Options.UseFont = true;
            this.edtInkassofallStatus.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtInkassofallStatus.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtInkassofallStatus.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtInkassofallStatus.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtInkassofallStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtInkassofallStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtInkassofallStatus.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtInkassofallStatus.Properties.NullText = "";
            this.edtInkassofallStatus.Properties.ShowFooter = false;
            this.edtInkassofallStatus.Properties.ShowHeader = false;
            this.edtInkassofallStatus.Size = new System.Drawing.Size(265, 24);
            this.edtInkassofallStatus.TabIndex = 14;
            // 
            // edtInklEinmalige
            // 
            this.edtInklEinmalige.EditValue = false;
            this.edtInklEinmalige.Location = new System.Drawing.Point(150, 220);
            this.edtInklEinmalige.Name = "edtInklEinmalige";
            this.edtInklEinmalige.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtInklEinmalige.Properties.Appearance.Options.UseBackColor = true;
            this.edtInklEinmalige.Properties.Caption = "inklusive einmalige Forderungen";
            this.edtInklEinmalige.Size = new System.Drawing.Size(250, 19);
            this.edtInklEinmalige.TabIndex = 16;
            // 
            // edtInklAbgeschlossene
            // 
            this.edtInklAbgeschlossene.EditValue = false;
            this.edtInklAbgeschlossene.Location = new System.Drawing.Point(150, 250);
            this.edtInklAbgeschlossene.Name = "edtInklAbgeschlossene";
            this.edtInklAbgeschlossene.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtInklAbgeschlossene.Properties.Appearance.Options.UseBackColor = true;
            this.edtInklAbgeschlossene.Properties.Caption = "inklusive abgeschlossene Faelle";
            this.edtInklAbgeschlossene.Size = new System.Drawing.Size(250, 19);
            this.edtInklAbgeschlossene.TabIndex = 18;
            // 
            // edtInklArchivierte
            // 
            this.edtInklArchivierte.EditValue = false;
            this.edtInklArchivierte.Location = new System.Drawing.Point(150, 280);
            this.edtInklArchivierte.Name = "edtInklArchivierte";
            this.edtInklArchivierte.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtInklArchivierte.Properties.Appearance.Options.UseBackColor = true;
            this.edtInklArchivierte.Properties.Caption = "inklusive archivierte Faelle";
            this.edtInklArchivierte.Size = new System.Drawing.Size(250, 19);
            this.edtInklArchivierte.TabIndex = 20;
            // 
            // edtDetailMode
            // 
            this.edtDetailMode.EditValue = false;
            this.edtDetailMode.Location = new System.Drawing.Point(150, 310);
            this.edtDetailMode.Name = "edtDetailMode";
            this.edtDetailMode.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtDetailMode.Properties.Appearance.Options.UseBackColor = true;
            this.edtDetailMode.Properties.Caption = "Detailmodus";
            this.edtDetailMode.Size = new System.Drawing.Size(250, 19);
            this.edtDetailMode.TabIndex = 22;
            // 
            // colBelegDatum
            // 
            this.colBelegDatum.Name = "colBelegDatum";
            // 
            // colBelegNr
            // 
            this.colBelegNr.Name = "colBelegNr";
            // 
            // colDatum
            // 
            this.colDatum.Name = "colDatum";
            // 
            // coleinmaligeForderungen
            // 
            this.coleinmaligeForderungen.Name = "coleinmaligeForderungen";
            // 
            // colForderung
            // 
            this.colForderung.Name = "colForderung";
            // 
            // colGlubiger
            // 
            this.colGlubiger.Name = "colGlubiger";
            // 
            // colHabenKtoNr
            // 
            this.colHabenKtoNr.Name = "colHabenKtoNr";
            // 
            // colInkassoquote
            // 
            this.colInkassoquote.Name = "colInkassoquote";
            // 
            // colperiodischeForderungen
            // 
            this.colperiodischeForderungen.Name = "colperiodischeForderungen";
            // 
            // colSchuldner
            // 
            this.colSchuldner.Name = "colSchuldner";
            // 
            // colSollKtoNr
            // 
            this.colSollKtoNr.Name = "colSollKtoNr";
            // 
            // colText
            // 
            this.colText.Name = "colText";
            // 
            // colTotalForderungen
            // 
            this.colTotalForderungen.Name = "colTotalForderungen";
            // 
            // colTyp
            // 
            this.colTyp.Name = "colTyp";
            // 
            // colZahlung
            // 
            this.colZahlung.Name = "colZahlung";
            // 
            // colZahlungen
            // 
            this.colZahlungen.Name = "colZahlungen";
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
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.grdQuery1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.UseTabKey = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // CtlQueryIkInkassoquote
            // 
            this.Name = "CtlQueryIkInkassoquote";
            this.Load += new System.EventHandler(this.CtlQueryIkInkassoquote_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            this.tpgDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qryDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSAR_ID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitraumvon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtlblInkassoTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassoTyp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassoTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtlblInkassoTypUnterart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassoTypUnterart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassoTypUnterart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtlblForderungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtForderungsart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtForderungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtlblInkassofallStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassofallStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassofallStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInklEinmalige.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInklAbgeschlossene.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInklArchivierte.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDetailMode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();

            tpgDetails.HideTab = true;
        }

        protected override void RunSearch()
        {
            //empty the columns in the resultset of the query, in case the user changed from 'inkl. Einmalige' to 'ohne Einmalige'
            qryQuery.DataTable.Columns.Clear();

            tpgDetails.HideTab = true;
            if (edtDetailMode.Checked)
            {
            tpgDetails.HideTab = false;
            }

            base.RunSearch();
        }

        #endregion

        #region Private Methods

        private void CtlQueryIkInkassoquote_Load(object sender, System.EventArgs e)
        {
            tpgDetails.HideTab = true;
        }

        #endregion

        private void qryQuery_AfterFill(object sender, System.EventArgs e)
        {
            //empty the columns of the current gridview, so they are re-created based on the query-result, in case the user changed from 'inkl. Einmalige' to 'ohne Einmalige'
            grdQuery1.View.Columns.Clear();
            SetupDataSourceAndGridColumns(grdQuery1, qryQuery);
        }
    }
}