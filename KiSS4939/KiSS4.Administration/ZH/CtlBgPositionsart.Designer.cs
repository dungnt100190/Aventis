using System.Windows.Forms;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Administration.ZH
{
    public partial class CtlBgPositionsart
    {
        private KiSS4.Gui.KissCheckedLookupEdit chkEditMaskMasterHigh;
        private KiSS4.Gui.KissCheckedLookupEdit chkEditMaskMasterLow;
        private KiSS4.Gui.KissCheckedLookupEdit chkEditMaskMonatHigh;
        private KiSS4.Gui.KissCheckedLookupEdit chkEditMaskMonatLow;
        private DevExpress.XtraGrid.Columns.GridColumn colAbfolge;
        private DevExpress.XtraGrid.Columns.GridColumn colBgGruppeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colBgKategorieCode;
        private DevExpress.XtraGrid.Columns.GridColumn colBgKostenartID;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungstext;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colSD;
        private DevExpress.XtraGrid.Columns.GridColumn colSpezkonto;
        private DevExpress.XtraGrid.Columns.GridColumn colStandardwert;
        private DevExpress.XtraGrid.Columns.GridColumn colUE;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissCheckEdit editReadOnly;
        private KiSS4.Gui.KissMemoEdit edtBemerkung;
        private KissLookUpEdit edtBgGruppeCode;
        private KiSS4.Gui.KissLookUpEdit edtBgGruppeCodeX;
        private KissLookUpEdit edtBgKategorieCode;
        private KiSS4.Gui.KissLookUpEdit edtBgKategorieCodeX;
        private KissLookUpEdit edtBgKostenartID;
        private KiSS4.Gui.KissLookUpEdit edtBgKostenartIDX;
        private KissTextEdit edtBuchungstext;
        private KissCalcEdit edtHauptvorgang;
        private KissTextEdit edtName;
        private KiSS4.Gui.KissTextEdit edtNameX;
        private KissButtonEdit edtPositionsartUseText;
        private KissCheckEdit edtProPerson;
        private KissCheckEdit edtProUE;
        private KissCalcEdit edtSortKey;
        private KissCheckEdit edtSpezkonto;
        private KissCheckEdit edtStandardwert;
        private KissCalcEdit edtTeilvorgang;
        private KissCheckEdit edtVerwaltungSD_Default;
        private KiSS4.Gui.KissGrid grdBgPositionsart;
        private KissGrid grdBuchungstext;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBgPositionsart;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBuchungstext;
        private KiSS4.Gui.KissLabel kissLabel1;
        private KissLabel kissLabel10;
        private KissLabel kissLabel11;
        private KiSS4.Gui.KissLabel kissLabel2;
        private KiSS4.Gui.KissLabel kissLabel3;
        private KiSS4.Gui.KissLabel kissLabel4;
        private KissLabel lblBgGruppeCode;
        private KissLabel lblBgKategorieCode;
        private KissLabel lblBgKostenartID;
        private KissLabel lblBuchungstext;
        private KissLabel lblGleicherText;
        private KissLabel lblHauptvorgang;
        private KissLabel lblHilfeText;
        private KissLabel lblName;
        private KissLabel lblSortKey;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private KiSS4.DB.SqlQuery qryBgKostenart;
        private KiSS4.DB.SqlQuery qryBgPositionsart;
        private SqlQuery qryBgPositionsartBuchungstext;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit4;
        private KissTabControlEx tabDetail;
        private SharpLibrary.WinControls.TabPageEx tabPageEx1;
        private SharpLibrary.WinControls.TabPageEx tabPageEx2;
        private SharpLibrary.WinControls.TabPageEx tabPageEx3;
        private SharpLibrary.WinControls.TabPageEx tpgBuchungstext;
        private SharpLibrary.WinControls.TabPageEx tpgPositionsart;


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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBgPositionsart));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdBgPositionsart = new KiSS4.Gui.KissGrid();
            this.qryBgPositionsart = new KiSS4.DB.SqlQuery(this.components);
            this.grvBgPositionsart = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBgKategorieCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBgGruppeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBgKostenartID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSpezkonto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKeinKreditor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbfolge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.edtBgKategorieCodeX = new KiSS4.Gui.KissLookUpEdit();
            this.edtBgGruppeCodeX = new KiSS4.Gui.KissLookUpEdit();
            this.edtNameX = new KiSS4.Gui.KissTextEdit();
            this.edtBgKostenartIDX = new KiSS4.Gui.KissLookUpEdit();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.qryBgKostenart = new KiSS4.DB.SqlQuery(this.components);
            this.tabDetail = new KiSS4.Gui.KissTabControlEx();
            this.tpgPositionsart = new SharpLibrary.WinControls.TabPageEx();
            this.edtKeinKreditor = new KiSS4.Gui.KissCheckEdit();
            this.edtErzeugtBfsDossier = new KiSS4.Gui.KissCheckEdit();
            this.edtTeilvorgang = new KiSS4.Gui.KissCalcEdit();
            this.lblHauptvorgang = new KiSS4.Gui.KissLabel();
            this.edtHauptvorgang = new KiSS4.Gui.KissCalcEdit();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.kissLabel10 = new KiSS4.Gui.KissLabel();
            this.kissLabel11 = new KiSS4.Gui.KissLabel();
            this.lblHilfeText = new KiSS4.Gui.KissLabel();
            this.editReadOnly = new KiSS4.Gui.KissCheckEdit();
            this.chkEditMaskMonatHigh = new KiSS4.Gui.KissCheckedLookupEdit();
            this.chkEditMaskMonatLow = new KiSS4.Gui.KissCheckedLookupEdit();
            this.chkEditMaskMasterHigh = new KiSS4.Gui.KissCheckedLookupEdit();
            this.chkEditMaskMasterLow = new KiSS4.Gui.KissCheckedLookupEdit();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.lblBgKostenartID = new KiSS4.Gui.KissLabel();
            this.edtSortKey = new KiSS4.Gui.KissCalcEdit();
            this.edtSpezkonto = new KiSS4.Gui.KissCheckEdit();
            this.lblSortKey = new KiSS4.Gui.KissLabel();
            this.edtVerwaltungSD_Default = new KiSS4.Gui.KissCheckEdit();
            this.edtProUE = new KiSS4.Gui.KissCheckEdit();
            this.lblName = new KiSS4.Gui.KissLabel();
            this.edtProPerson = new KiSS4.Gui.KissCheckEdit();
            this.edtBgKostenartID = new KiSS4.Gui.KissLookUpEdit();
            this.lblBgGruppeCode = new KiSS4.Gui.KissLabel();
            this.edtName = new KiSS4.Gui.KissTextEdit();
            this.edtBgGruppeCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblBgKategorieCode = new KiSS4.Gui.KissLabel();
            this.edtBgKategorieCode = new KiSS4.Gui.KissLookUpEdit();
            this.tpgBuchungstext = new SharpLibrary.WinControls.TabPageEx();
            this.edtStandardwert = new KiSS4.Gui.KissCheckEdit();
            this.qryBgPositionsartBuchungstext = new KiSS4.DB.SqlQuery(this.components);
            this.lblBuchungstext = new KiSS4.Gui.KissLabel();
            this.edtBuchungstext = new KiSS4.Gui.KissTextEdit();
            this.edtPositionsartUseText = new KiSS4.Gui.KissButtonEdit();
            this.lblGleicherText = new KiSS4.Gui.KissLabel();
            this.grdBuchungstext = new KiSS4.Gui.KissGrid();
            this.grvBuchungstext = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBuchungstext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStandardwert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.tabPageEx1 = new SharpLibrary.WinControls.TabPageEx();
            this.tabPageEx2 = new SharpLibrary.WinControls.TabPageEx();
            this.tabPageEx3 = new SharpLibrary.WinControls.TabPageEx();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBgPositionsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPositionsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgPositionsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKategorieCodeX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKategorieCodeX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgGruppeCodeX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgGruppeCodeX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKostenartIDX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKostenartIDX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgKostenart)).BeginInit();
            this.tabDetail.SuspendLayout();
            this.tpgPositionsart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtKeinKreditor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErzeugtBfsDossier.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTeilvorgang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHauptvorgang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHauptvorgang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHilfeText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editReadOnly.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEditMaskMonatHigh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEditMaskMonatLow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEditMaskMasterHigh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEditMaskMasterLow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgKostenartID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSortKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSpezkonto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSortKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwaltungSD_Default.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProUE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKostenartID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKostenartID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgGruppeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgGruppeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgGruppeCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgKategorieCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKategorieCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKategorieCode.Properties)).BeginInit();
            this.tpgBuchungstext.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtStandardwert.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPositionsartBuchungstext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungstext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungstext.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPositionsartUseText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGleicherText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBuchungstext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBuchungstext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(785, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSearch.Size = new System.Drawing.Size(809, 299);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdBgPositionsart);
            this.tpgListe.Size = new System.Drawing.Size(797, 261);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.kissLabel1);
            this.tpgSuchen.Controls.Add(this.kissLabel2);
            this.tpgSuchen.Controls.Add(this.kissLabel3);
            this.tpgSuchen.Controls.Add(this.kissLabel4);
            this.tpgSuchen.Controls.Add(this.edtBgKostenartIDX);
            this.tpgSuchen.Controls.Add(this.edtNameX);
            this.tpgSuchen.Controls.Add(this.edtBgGruppeCodeX);
            this.tpgSuchen.Controls.Add(this.edtBgKategorieCodeX);
            this.tpgSuchen.Size = new System.Drawing.Size(797, 261);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.edtBgKategorieCodeX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBgGruppeCodeX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNameX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBgKostenartIDX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel4, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel3, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel2, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel1, 0);
            // 
            // grdBgPositionsart
            // 
            this.grdBgPositionsart.DataSource = this.qryBgPositionsart;
            this.grdBgPositionsart.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdBgPositionsart.EmbeddedNavigator.Name = "";
            this.grdBgPositionsart.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBgPositionsart.Location = new System.Drawing.Point(0, 0);
            this.grdBgPositionsart.MainView = this.grvBgPositionsart;
            this.grdBgPositionsart.Name = "grdBgPositionsart";
            this.grdBgPositionsart.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2});
            this.grdBgPositionsart.Size = new System.Drawing.Size(797, 261);
            this.grdBgPositionsart.TabIndex = 0;
            this.grdBgPositionsart.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBgPositionsart});
            // 
            // qryBgPositionsart
            // 
            this.qryBgPositionsart.HostControl = this;
            this.qryBgPositionsart.SelectStatement = resources.GetString("qryBgPositionsart.SelectStatement");
            this.qryBgPositionsart.TableName = "BgPositionsart";
            this.qryBgPositionsart.AfterInsert += new System.EventHandler(this.qryBgPositionsart_AfterInsert);
            this.qryBgPositionsart.BeforePost += new System.EventHandler(this.qryBgPositionsart_BeforePost);
            this.qryBgPositionsart.PositionChanged += new System.EventHandler(this.qryBgPositionsart_PositionChanged);
            // 
            // grvBgPositionsart
            // 
            this.grvBgPositionsart.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBgPositionsart.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPositionsart.Appearance.Empty.Options.UseBackColor = true;
            this.grvBgPositionsart.Appearance.Empty.Options.UseFont = true;
            this.grvBgPositionsart.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPositionsart.Appearance.EvenRow.Options.UseFont = true;
            this.grvBgPositionsart.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBgPositionsart.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPositionsart.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBgPositionsart.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBgPositionsart.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBgPositionsart.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBgPositionsart.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBgPositionsart.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPositionsart.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBgPositionsart.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBgPositionsart.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBgPositionsart.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBgPositionsart.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBgPositionsart.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBgPositionsart.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBgPositionsart.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBgPositionsart.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBgPositionsart.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBgPositionsart.Appearance.GroupRow.Options.UseFont = true;
            this.grvBgPositionsart.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBgPositionsart.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBgPositionsart.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBgPositionsart.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBgPositionsart.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBgPositionsart.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBgPositionsart.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBgPositionsart.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBgPositionsart.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPositionsart.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBgPositionsart.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBgPositionsart.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBgPositionsart.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBgPositionsart.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBgPositionsart.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBgPositionsart.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPositionsart.Appearance.OddRow.Options.UseFont = true;
            this.grvBgPositionsart.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBgPositionsart.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPositionsart.Appearance.Row.Options.UseBackColor = true;
            this.grvBgPositionsart.Appearance.Row.Options.UseFont = true;
            this.grvBgPositionsart.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPositionsart.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBgPositionsart.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBgPositionsart.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBgPositionsart.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBgPositionsart.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBgKategorieCode,
            this.colBgGruppeCode,
            this.colName,
            this.colBgKostenartID,
            this.colPerson,
            this.colUE,
            this.colSD,
            this.colSpezkonto,
            this.colKeinKreditor,
            this.colAbfolge});
            this.grvBgPositionsart.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBgPositionsart.GridControl = this.grdBgPositionsart;
            this.grvBgPositionsart.Name = "grvBgPositionsart";
            this.grvBgPositionsart.OptionsBehavior.Editable = false;
            this.grvBgPositionsart.OptionsCustomization.AllowFilter = false;
            this.grvBgPositionsart.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBgPositionsart.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBgPositionsart.OptionsNavigation.UseTabKey = false;
            this.grvBgPositionsart.OptionsView.ColumnAutoWidth = false;
            this.grvBgPositionsart.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBgPositionsart.OptionsView.ShowGroupPanel = false;
            this.grvBgPositionsart.OptionsView.ShowIndicator = false;
            // 
            // colBgKategorieCode
            // 
            this.colBgKategorieCode.Caption = "Kategorie";
            this.colBgKategorieCode.FieldName = "BgKategorieCode";
            this.colBgKategorieCode.Name = "colBgKategorieCode";
            this.colBgKategorieCode.Visible = true;
            this.colBgKategorieCode.VisibleIndex = 0;
            this.colBgKategorieCode.Width = 111;
            // 
            // colBgGruppeCode
            // 
            this.colBgGruppeCode.Caption = "Gruppe";
            this.colBgGruppeCode.FieldName = "BgGruppeCode";
            this.colBgGruppeCode.Name = "colBgGruppeCode";
            this.colBgGruppeCode.Visible = true;
            this.colBgGruppeCode.VisibleIndex = 1;
            this.colBgGruppeCode.Width = 160;
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            this.colName.Width = 233;
            // 
            // colBgKostenartID
            // 
            this.colBgKostenartID.Caption = "LA";
            this.colBgKostenartID.FieldName = "BgKostenartID";
            this.colBgKostenartID.Name = "colBgKostenartID";
            this.colBgKostenartID.Visible = true;
            this.colBgKostenartID.VisibleIndex = 3;
            // 
            // colPerson
            // 
            this.colPerson.Caption = "Pers.";
            this.colPerson.FieldName = "ProPerson";
            this.colPerson.Name = "colPerson";
            this.colPerson.Visible = true;
            this.colPerson.VisibleIndex = 4;
            this.colPerson.Width = 40;
            // 
            // colUE
            // 
            this.colUE.Caption = "UE";
            this.colUE.FieldName = "ProUE";
            this.colUE.Name = "colUE";
            this.colUE.Visible = true;
            this.colUE.VisibleIndex = 5;
            this.colUE.Width = 40;
            // 
            // colSD
            // 
            this.colSD.Caption = "SD";
            this.colSD.FieldName = "VerwaltungSD_Default";
            this.colSD.Name = "colSD";
            this.colSD.Visible = true;
            this.colSD.VisibleIndex = 6;
            this.colSD.Width = 40;
            // 
            // colSpezkonto
            // 
            this.colSpezkonto.Caption = "Sp.K.";
            this.colSpezkonto.FieldName = "Spezkonto";
            this.colSpezkonto.Name = "colSpezkonto";
            this.colSpezkonto.Visible = true;
            this.colSpezkonto.VisibleIndex = 7;
            this.colSpezkonto.Width = 40;
            // 
            // colKeinKreditor
            // 
            this.colKeinKreditor.Caption = "K.Kred.";
            this.colKeinKreditor.FieldName = "KeinKreditor";
            this.colKeinKreditor.Name = "colKeinKreditor";
            this.colKeinKreditor.Visible = true;
            this.colKeinKreditor.VisibleIndex = 8;
            this.colKeinKreditor.Width = 50;
            // 
            // colAbfolge
            // 
            this.colAbfolge.Caption = "Abf.";
            this.colAbfolge.FieldName = "SortKey";
            this.colAbfolge.Name = "colAbfolge";
            this.colAbfolge.Visible = true;
            this.colAbfolge.VisibleIndex = 9;
            this.colAbfolge.Width = 33;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // edtBgKategorieCodeX
            // 
            this.edtBgKategorieCodeX.Location = new System.Drawing.Point(91, 39);
            this.edtBgKategorieCodeX.LOVName = "BgKategorie";
            this.edtBgKategorieCodeX.Name = "edtBgKategorieCodeX";
            this.edtBgKategorieCodeX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBgKategorieCodeX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgKategorieCodeX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgKategorieCodeX.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgKategorieCodeX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgKategorieCodeX.Properties.Appearance.Options.UseFont = true;
            this.edtBgKategorieCodeX.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBgKategorieCodeX.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgKategorieCodeX.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBgKategorieCodeX.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBgKategorieCodeX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtBgKategorieCodeX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtBgKategorieCodeX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgKategorieCodeX.Properties.NullText = "";
            this.edtBgKategorieCodeX.Properties.ShowFooter = false;
            this.edtBgKategorieCodeX.Properties.ShowHeader = false;
            this.edtBgKategorieCodeX.Size = new System.Drawing.Size(447, 24);
            this.edtBgKategorieCodeX.TabIndex = 0;
            // 
            // edtBgGruppeCodeX
            // 
            this.edtBgGruppeCodeX.Location = new System.Drawing.Point(91, 69);
            this.edtBgGruppeCodeX.LOVName = "BgGruppe";
            this.edtBgGruppeCodeX.Name = "edtBgGruppeCodeX";
            this.edtBgGruppeCodeX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBgGruppeCodeX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgGruppeCodeX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgGruppeCodeX.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgGruppeCodeX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgGruppeCodeX.Properties.Appearance.Options.UseFont = true;
            this.edtBgGruppeCodeX.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBgGruppeCodeX.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgGruppeCodeX.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBgGruppeCodeX.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBgGruppeCodeX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtBgGruppeCodeX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtBgGruppeCodeX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgGruppeCodeX.Properties.NullText = "";
            this.edtBgGruppeCodeX.Properties.ShowFooter = false;
            this.edtBgGruppeCodeX.Properties.ShowHeader = false;
            this.edtBgGruppeCodeX.Size = new System.Drawing.Size(447, 24);
            this.edtBgGruppeCodeX.TabIndex = 1;
            // 
            // edtNameX
            // 
            this.edtNameX.Location = new System.Drawing.Point(91, 99);
            this.edtNameX.Name = "edtNameX";
            this.edtNameX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNameX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNameX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNameX.Properties.Appearance.Options.UseBackColor = true;
            this.edtNameX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNameX.Properties.Appearance.Options.UseFont = true;
            this.edtNameX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNameX.Size = new System.Drawing.Size(447, 24);
            this.edtNameX.TabIndex = 2;
            // 
            // edtBgKostenartIDX
            // 
            this.edtBgKostenartIDX.Location = new System.Drawing.Point(91, 130);
            this.edtBgKostenartIDX.Name = "edtBgKostenartIDX";
            this.edtBgKostenartIDX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBgKostenartIDX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgKostenartIDX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgKostenartIDX.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgKostenartIDX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgKostenartIDX.Properties.Appearance.Options.UseFont = true;
            this.edtBgKostenartIDX.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBgKostenartIDX.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgKostenartIDX.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBgKostenartIDX.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBgKostenartIDX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtBgKostenartIDX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtBgKostenartIDX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgKostenartIDX.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtBgKostenartIDX.Properties.DisplayMember = "Name";
            this.edtBgKostenartIDX.Properties.NullText = "";
            this.edtBgKostenartIDX.Properties.ShowFooter = false;
            this.edtBgKostenartIDX.Properties.ShowHeader = false;
            this.edtBgKostenartIDX.Properties.ValueMember = "BgKostenartID";
            this.edtBgKostenartIDX.Size = new System.Drawing.Size(447, 24);
            this.edtBgKostenartIDX.TabIndex = 3;
            // 
            // kissLabel4
            // 
            this.kissLabel4.Location = new System.Drawing.Point(7, 39);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(62, 24);
            this.kissLabel4.TabIndex = 11;
            this.kissLabel4.Text = "Kategorie";
            this.kissLabel4.UseCompatibleTextRendering = true;
            // 
            // kissLabel3
            // 
            this.kissLabel3.Location = new System.Drawing.Point(7, 69);
            this.kissLabel3.Name = "kissLabel3";
            this.kissLabel3.Size = new System.Drawing.Size(62, 24);
            this.kissLabel3.TabIndex = 13;
            this.kissLabel3.Text = "Gruppe";
            this.kissLabel3.UseCompatibleTextRendering = true;
            // 
            // kissLabel2
            // 
            this.kissLabel2.Location = new System.Drawing.Point(7, 99);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(62, 24);
            this.kissLabel2.TabIndex = 15;
            this.kissLabel2.Text = "Name";
            this.kissLabel2.UseCompatibleTextRendering = true;
            // 
            // kissLabel1
            // 
            this.kissLabel1.Location = new System.Drawing.Point(7, 130);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(62, 24);
            this.kissLabel1.TabIndex = 17;
            this.kissLabel1.Text = "Leistungsart";
            this.kissLabel1.UseCompatibleTextRendering = true;
            // 
            // qryBgKostenart
            // 
            this.qryBgKostenart.HostControl = this;
            this.qryBgKostenart.SelectStatement = "SELECT *, NrName = KontoNr + \' \' + Name\r\nFROM BgKostenart\r\nWHERE ModulID = {0}";
            // 
            // tabDetail
            // 
            this.tabDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabDetail.Controls.Add(this.tpgPositionsart);
            this.tabDetail.Controls.Add(this.tpgBuchungstext);
            this.tabDetail.InvalidateOnPropertyChanged = false;
            this.tabDetail.Location = new System.Drawing.Point(3, 308);
            this.tabDetail.Name = "tabDetail";
            this.tabDetail.ShowFixedWidthTooltip = true;
            this.tabDetail.Size = new System.Drawing.Size(809, 323);
            this.tabDetail.TabIndex = 1;
            this.tabDetail.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgPositionsart,
            this.tpgBuchungstext});
            this.tabDetail.TabsLineColor = System.Drawing.Color.Black;
            this.tabDetail.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabDetail.Text = "kissTabControlEx1";
            this.tabDetail.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabDetail_SelectedTabChanged);
            // 
            // tpgPositionsart
            // 
            this.tpgPositionsart.Controls.Add(this.edtKeinKreditor);
            this.tpgPositionsart.Controls.Add(this.edtErzeugtBfsDossier);
            this.tpgPositionsart.Controls.Add(this.edtTeilvorgang);
            this.tpgPositionsart.Controls.Add(this.lblHauptvorgang);
            this.tpgPositionsart.Controls.Add(this.edtHauptvorgang);
            this.tpgPositionsart.Controls.Add(this.pictureBox3);
            this.tpgPositionsart.Controls.Add(this.pictureBox4);
            this.tpgPositionsart.Controls.Add(this.pictureBox2);
            this.tpgPositionsart.Controls.Add(this.pictureBox1);
            this.tpgPositionsart.Controls.Add(this.kissLabel10);
            this.tpgPositionsart.Controls.Add(this.kissLabel11);
            this.tpgPositionsart.Controls.Add(this.lblHilfeText);
            this.tpgPositionsart.Controls.Add(this.editReadOnly);
            this.tpgPositionsart.Controls.Add(this.chkEditMaskMonatHigh);
            this.tpgPositionsart.Controls.Add(this.chkEditMaskMonatLow);
            this.tpgPositionsart.Controls.Add(this.chkEditMaskMasterHigh);
            this.tpgPositionsart.Controls.Add(this.chkEditMaskMasterLow);
            this.tpgPositionsart.Controls.Add(this.edtBemerkung);
            this.tpgPositionsart.Controls.Add(this.lblBgKostenartID);
            this.tpgPositionsart.Controls.Add(this.edtSortKey);
            this.tpgPositionsart.Controls.Add(this.edtSpezkonto);
            this.tpgPositionsart.Controls.Add(this.lblSortKey);
            this.tpgPositionsart.Controls.Add(this.edtVerwaltungSD_Default);
            this.tpgPositionsart.Controls.Add(this.edtProUE);
            this.tpgPositionsart.Controls.Add(this.lblName);
            this.tpgPositionsart.Controls.Add(this.edtProPerson);
            this.tpgPositionsart.Controls.Add(this.edtBgKostenartID);
            this.tpgPositionsart.Controls.Add(this.lblBgGruppeCode);
            this.tpgPositionsart.Controls.Add(this.edtName);
            this.tpgPositionsart.Controls.Add(this.edtBgGruppeCode);
            this.tpgPositionsart.Controls.Add(this.lblBgKategorieCode);
            this.tpgPositionsart.Controls.Add(this.edtBgKategorieCode);
            this.tpgPositionsart.Location = new System.Drawing.Point(6, 6);
            this.tpgPositionsart.Name = "tpgPositionsart";
            this.tpgPositionsart.Size = new System.Drawing.Size(797, 285);
            this.tpgPositionsart.TabIndex = 0;
            this.tpgPositionsart.Title = "Positionsart";
            // 
            // edtKeinKreditor
            // 
            this.edtKeinKreditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtKeinKreditor.DataMember = "KeinKreditor";
            this.edtKeinKreditor.DataSource = this.qryBgPositionsart;
            this.edtKeinKreditor.Location = new System.Drawing.Point(449, 125);
            this.edtKeinKreditor.Name = "edtKeinKreditor";
            this.edtKeinKreditor.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKeinKreditor.Properties.Appearance.Options.UseBackColor = true;
            this.edtKeinKreditor.Properties.Caption = "Kein Kreditor";
            this.edtKeinKreditor.Size = new System.Drawing.Size(90, 19);
            this.edtKeinKreditor.TabIndex = 67;
            this.edtKeinKreditor.CheckedChanged += new System.EventHandler(this.edtKeinKreditor_CheckedChanged);
            // 
            // edtErzeugtBfsDossier
            // 
            this.edtErzeugtBfsDossier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtErzeugtBfsDossier.DataMember = "ErzeugtBfsDossier";
            this.edtErzeugtBfsDossier.DataSource = this.qryBgPositionsart;
            this.edtErzeugtBfsDossier.Location = new System.Drawing.Point(404, 97);
            this.edtErzeugtBfsDossier.Name = "edtErzeugtBfsDossier";
            this.edtErzeugtBfsDossier.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtErzeugtBfsDossier.Properties.Appearance.Options.UseBackColor = true;
            this.edtErzeugtBfsDossier.Properties.Caption = "Erzeugt BFS-Dossier";
            this.edtErzeugtBfsDossier.Size = new System.Drawing.Size(122, 19);
            this.edtErzeugtBfsDossier.TabIndex = 66;
            // 
            // edtTeilvorgang
            // 
            this.edtTeilvorgang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtTeilvorgang.DataMember = "SpezTeilvorgang";
            this.edtTeilvorgang.DataSource = this.qryBgPositionsart;
            this.edtTeilvorgang.Location = new System.Drawing.Point(450, 155);
            this.edtTeilvorgang.Name = "edtTeilvorgang";
            this.edtTeilvorgang.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtTeilvorgang.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTeilvorgang.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTeilvorgang.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTeilvorgang.Properties.Appearance.Options.UseBackColor = true;
            this.edtTeilvorgang.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTeilvorgang.Properties.Appearance.Options.UseFont = true;
            this.edtTeilvorgang.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTeilvorgang.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTeilvorgang.Properties.DisplayFormat.FormatString = "d";
            this.edtTeilvorgang.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtTeilvorgang.Properties.EditFormat.FormatString = "d";
            this.edtTeilvorgang.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtTeilvorgang.Size = new System.Drawing.Size(75, 24);
            this.edtTeilvorgang.TabIndex = 65;
            // 
            // lblHauptvorgang
            // 
            this.lblHauptvorgang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblHauptvorgang.Location = new System.Drawing.Point(216, 155);
            this.lblHauptvorgang.Name = "lblHauptvorgang";
            this.lblHauptvorgang.Size = new System.Drawing.Size(151, 24);
            this.lblHauptvorgang.TabIndex = 64;
            this.lblHauptvorgang.Text = "HV/TV (Aufw.-/Ertragsmind)";
            this.lblHauptvorgang.UseCompatibleTextRendering = true;
            // 
            // edtHauptvorgang
            // 
            this.edtHauptvorgang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtHauptvorgang.DataMember = "SpezHauptvorgang";
            this.edtHauptvorgang.DataSource = this.qryBgPositionsart;
            this.edtHauptvorgang.Location = new System.Drawing.Point(369, 155);
            this.edtHauptvorgang.Name = "edtHauptvorgang";
            this.edtHauptvorgang.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtHauptvorgang.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtHauptvorgang.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHauptvorgang.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHauptvorgang.Properties.Appearance.Options.UseBackColor = true;
            this.edtHauptvorgang.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHauptvorgang.Properties.Appearance.Options.UseFont = true;
            this.edtHauptvorgang.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtHauptvorgang.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtHauptvorgang.Properties.DisplayFormat.FormatString = "d";
            this.edtHauptvorgang.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtHauptvorgang.Properties.EditFormat.FormatString = "d";
            this.edtHauptvorgang.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtHauptvorgang.Size = new System.Drawing.Size(75, 24);
            this.edtHauptvorgang.TabIndex = 63;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(571, 22);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(16, 16);
            this.pictureBox3.TabIndex = 62;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(551, 22);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(16, 16);
            this.pictureBox4.TabIndex = 61;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(657, 22);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.TabIndex = 60;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(637, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 59;
            this.pictureBox1.TabStop = false;
            // 
            // kissLabel10
            // 
            this.kissLabel10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel10.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissLabel10.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel10.Location = new System.Drawing.Point(635, 2);
            this.kissLabel10.Name = "kissLabel10";
            this.kissLabel10.Size = new System.Drawing.Size(104, 15);
            this.kissLabel10.TabIndex = 58;
            this.kissLabel10.Text = "Monatsbudget";
            this.kissLabel10.UseCompatibleTextRendering = true;
            // 
            // kissLabel11
            // 
            this.kissLabel11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel11.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissLabel11.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel11.Location = new System.Drawing.Point(549, 2);
            this.kissLabel11.Name = "kissLabel11";
            this.kissLabel11.Size = new System.Drawing.Size(84, 15);
            this.kissLabel11.TabIndex = 57;
            this.kissLabel11.Text = "Masterbudget";
            this.kissLabel11.UseCompatibleTextRendering = true;
            // 
            // lblHilfeText
            // 
            this.lblHilfeText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblHilfeText.Location = new System.Drawing.Point(14, 180);
            this.lblHilfeText.Name = "lblHilfeText";
            this.lblHilfeText.Size = new System.Drawing.Size(63, 24);
            this.lblHilfeText.TabIndex = 55;
            this.lblHilfeText.Text = "Bemerkung";
            this.lblHilfeText.UseCompatibleTextRendering = true;
            // 
            // editReadOnly
            // 
            this.editReadOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editReadOnly.EditValue = true;
            this.editReadOnly.Location = new System.Drawing.Point(655, 259);
            this.editReadOnly.Name = "editReadOnly";
            this.editReadOnly.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editReadOnly.Properties.Appearance.Options.UseBackColor = true;
            this.editReadOnly.Properties.Caption = "Schreibschutz";
            this.editReadOnly.Size = new System.Drawing.Size(104, 19);
            this.editReadOnly.TabIndex = 56;
            this.editReadOnly.CheckedChanged += new System.EventHandler(this.editReadOnly_CheckedChanged);
            // 
            // chkEditMaskMonatHigh
            // 
            this.chkEditMaskMonatHigh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkEditMaskMonatHigh.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkEditMaskMonatHigh.Appearance.Options.UseBackColor = true;
            this.chkEditMaskMonatHigh.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.chkEditMaskMonatHigh.CheckOnClick = true;
            this.chkEditMaskMonatHigh.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.chkEditMaskMonatHigh.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Löschen"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Betrag -"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Betrag +"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Neu"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Gruppe"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Art"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Text"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Betrifft Person"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Bemerkung"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Betrag Rechnung"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Gruppe (Filter)")});
            this.chkEditMaskMonatHigh.Location = new System.Drawing.Point(655, 41);
            this.chkEditMaskMonatHigh.Name = "chkEditMaskMonatHigh";
            this.chkEditMaskMonatHigh.Size = new System.Drawing.Size(122, 194);
            this.chkEditMaskMonatHigh.TabIndex = 54;
            this.chkEditMaskMonatHigh.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.chkEditMask_ItemCheck);
            // 
            // chkEditMaskMonatLow
            // 
            this.chkEditMaskMonatLow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkEditMaskMonatLow.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkEditMaskMonatLow.Appearance.Options.UseBackColor = true;
            this.chkEditMaskMonatLow.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.chkEditMaskMonatLow.CheckOnClick = true;
            this.chkEditMaskMonatLow.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.chkEditMaskMonatLow.Location = new System.Drawing.Point(636, 41);
            this.chkEditMaskMonatLow.Name = "chkEditMaskMonatLow";
            this.chkEditMaskMonatLow.Size = new System.Drawing.Size(24, 194);
            this.chkEditMaskMonatLow.TabIndex = 53;
            this.chkEditMaskMonatLow.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.chkEditMask_ItemCheck);
            // 
            // chkEditMaskMasterHigh
            // 
            this.chkEditMaskMasterHigh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkEditMaskMasterHigh.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkEditMaskMasterHigh.Appearance.Options.UseBackColor = true;
            this.chkEditMaskMasterHigh.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.chkEditMaskMasterHigh.CheckOnClick = true;
            this.chkEditMaskMasterHigh.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.chkEditMaskMasterHigh.Location = new System.Drawing.Point(569, 41);
            this.chkEditMaskMasterHigh.Name = "chkEditMaskMasterHigh";
            this.chkEditMaskMasterHigh.Size = new System.Drawing.Size(22, 194);
            this.chkEditMaskMasterHigh.TabIndex = 52;
            this.chkEditMaskMasterHigh.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.chkEditMask_ItemCheck);
            // 
            // chkEditMaskMasterLow
            // 
            this.chkEditMaskMasterLow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkEditMaskMasterLow.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkEditMaskMasterLow.Appearance.Options.UseBackColor = true;
            this.chkEditMaskMasterLow.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.chkEditMaskMasterLow.CheckOnClick = true;
            this.chkEditMaskMasterLow.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.chkEditMaskMasterLow.Location = new System.Drawing.Point(550, 41);
            this.chkEditMaskMasterLow.Name = "chkEditMaskMasterLow";
            this.chkEditMaskMasterLow.Size = new System.Drawing.Size(24, 194);
            this.chkEditMaskMasterLow.TabIndex = 51;
            this.chkEditMaskMasterLow.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.chkEditMask_ItemCheck);
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryBgPositionsart;
            this.edtBemerkung.Location = new System.Drawing.Point(80, 188);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(447, 90);
            this.edtBemerkung.TabIndex = 50;
            // 
            // lblBgKostenartID
            // 
            this.lblBgKostenartID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBgKostenartID.Location = new System.Drawing.Point(14, 93);
            this.lblBgKostenartID.Name = "lblBgKostenartID";
            this.lblBgKostenartID.Size = new System.Drawing.Size(62, 24);
            this.lblBgKostenartID.TabIndex = 48;
            this.lblBgKostenartID.Text = "Leistungsart";
            this.lblBgKostenartID.UseCompatibleTextRendering = true;
            // 
            // edtSortKey
            // 
            this.edtSortKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSortKey.DataMember = "SortKey";
            this.edtSortKey.DataSource = this.qryBgPositionsart;
            this.edtSortKey.Location = new System.Drawing.Point(79, 155);
            this.edtSortKey.Name = "edtSortKey";
            this.edtSortKey.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSortKey.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSortKey.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSortKey.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSortKey.Properties.Appearance.Options.UseBackColor = true;
            this.edtSortKey.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSortKey.Properties.Appearance.Options.UseFont = true;
            this.edtSortKey.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSortKey.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSortKey.Size = new System.Drawing.Size(40, 24);
            this.edtSortKey.TabIndex = 49;
            // 
            // edtSpezkonto
            // 
            this.edtSpezkonto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSpezkonto.DataMember = "Spezkonto";
            this.edtSpezkonto.DataSource = this.qryBgPositionsart;
            this.edtSpezkonto.Location = new System.Drawing.Point(353, 125);
            this.edtSpezkonto.Name = "edtSpezkonto";
            this.edtSpezkonto.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSpezkonto.Properties.Appearance.Options.UseBackColor = true;
            this.edtSpezkonto.Properties.Caption = "Spezialkonto";
            this.edtSpezkonto.Size = new System.Drawing.Size(90, 19);
            this.edtSpezkonto.TabIndex = 47;
            this.edtSpezkonto.CheckedChanged += new System.EventHandler(this.edtSpezkonto_CheckedChanged);
            // 
            // lblSortKey
            // 
            this.lblSortKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSortKey.Location = new System.Drawing.Point(14, 155);
            this.lblSortKey.Name = "lblSortKey";
            this.lblSortKey.Size = new System.Drawing.Size(62, 24);
            this.lblSortKey.TabIndex = 45;
            this.lblSortKey.Text = "Abfolge";
            this.lblSortKey.UseCompatibleTextRendering = true;
            // 
            // edtVerwaltungSD_Default
            // 
            this.edtVerwaltungSD_Default.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtVerwaltungSD_Default.DataMember = "VerwaltungSD_Default";
            this.edtVerwaltungSD_Default.DataSource = this.qryBgPositionsart;
            this.edtVerwaltungSD_Default.Location = new System.Drawing.Point(237, 125);
            this.edtVerwaltungSD_Default.Name = "edtVerwaltungSD_Default";
            this.edtVerwaltungSD_Default.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVerwaltungSD_Default.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerwaltungSD_Default.Properties.Caption = "Verwaltung SD";
            this.edtVerwaltungSD_Default.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Inactive;
            this.edtVerwaltungSD_Default.Size = new System.Drawing.Size(110, 19);
            this.edtVerwaltungSD_Default.TabIndex = 46;
            // 
            // edtProUE
            // 
            this.edtProUE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtProUE.DataMember = "ProUE";
            this.edtProUE.DataSource = this.qryBgPositionsart;
            this.edtProUE.Location = new System.Drawing.Point(167, 125);
            this.edtProUE.Name = "edtProUE";
            this.edtProUE.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtProUE.Properties.Appearance.Options.UseBackColor = true;
            this.edtProUE.Properties.Caption = "pro UE";
            this.edtProUE.Size = new System.Drawing.Size(64, 19);
            this.edtProUE.TabIndex = 44;
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblName.Location = new System.Drawing.Point(14, 63);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(62, 24);
            this.lblName.TabIndex = 42;
            this.lblName.Text = "Name";
            this.lblName.UseCompatibleTextRendering = true;
            // 
            // edtProPerson
            // 
            this.edtProPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtProPerson.DataMember = "ProPerson";
            this.edtProPerson.DataSource = this.qryBgPositionsart;
            this.edtProPerson.Location = new System.Drawing.Point(79, 125);
            this.edtProPerson.Name = "edtProPerson";
            this.edtProPerson.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtProPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtProPerson.Properties.Caption = "pro Person";
            this.edtProPerson.Size = new System.Drawing.Size(82, 19);
            this.edtProPerson.TabIndex = 43;
            // 
            // edtBgKostenartID
            // 
            this.edtBgKostenartID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBgKostenartID.DataMember = "BgKostenartID";
            this.edtBgKostenartID.DataSource = this.qryBgPositionsart;
            this.edtBgKostenartID.Location = new System.Drawing.Point(79, 93);
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
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtBgKostenartID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtBgKostenartID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgKostenartID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtBgKostenartID.Properties.DisplayMember = "Name";
            this.edtBgKostenartID.Properties.NullText = "";
            this.edtBgKostenartID.Properties.ShowFooter = false;
            this.edtBgKostenartID.Properties.ShowHeader = false;
            this.edtBgKostenartID.Properties.ValueMember = "BgKostenartID";
            this.edtBgKostenartID.Size = new System.Drawing.Size(319, 24);
            this.edtBgKostenartID.TabIndex = 41;
            // 
            // lblBgGruppeCode
            // 
            this.lblBgGruppeCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBgGruppeCode.Location = new System.Drawing.Point(14, 33);
            this.lblBgGruppeCode.Name = "lblBgGruppeCode";
            this.lblBgGruppeCode.Size = new System.Drawing.Size(62, 24);
            this.lblBgGruppeCode.TabIndex = 39;
            this.lblBgGruppeCode.Text = "Gruppe";
            this.lblBgGruppeCode.UseCompatibleTextRendering = true;
            // 
            // edtName
            // 
            this.edtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtName.DataMember = "Name";
            this.edtName.DataSource = this.qryBgPositionsart;
            this.edtName.Location = new System.Drawing.Point(79, 63);
            this.edtName.Name = "edtName";
            this.edtName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtName.Properties.Appearance.Options.UseBackColor = true;
            this.edtName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtName.Properties.Appearance.Options.UseFont = true;
            this.edtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtName.Size = new System.Drawing.Size(447, 24);
            this.edtName.TabIndex = 40;
            // 
            // edtBgGruppeCode
            // 
            this.edtBgGruppeCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBgGruppeCode.DataMember = "BgGruppeCode";
            this.edtBgGruppeCode.DataSource = this.qryBgPositionsart;
            this.edtBgGruppeCode.Location = new System.Drawing.Point(79, 33);
            this.edtBgGruppeCode.LOVName = "BgGruppe";
            this.edtBgGruppeCode.Name = "edtBgGruppeCode";
            this.edtBgGruppeCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBgGruppeCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgGruppeCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgGruppeCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgGruppeCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgGruppeCode.Properties.Appearance.Options.UseFont = true;
            this.edtBgGruppeCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBgGruppeCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgGruppeCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBgGruppeCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBgGruppeCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtBgGruppeCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtBgGruppeCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgGruppeCode.Properties.NullText = "";
            this.edtBgGruppeCode.Properties.ShowFooter = false;
            this.edtBgGruppeCode.Properties.ShowHeader = false;
            this.edtBgGruppeCode.Size = new System.Drawing.Size(447, 24);
            this.edtBgGruppeCode.TabIndex = 38;
            // 
            // lblBgKategorieCode
            // 
            this.lblBgKategorieCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBgKategorieCode.Location = new System.Drawing.Point(14, 3);
            this.lblBgKategorieCode.Name = "lblBgKategorieCode";
            this.lblBgKategorieCode.Size = new System.Drawing.Size(62, 24);
            this.lblBgKategorieCode.TabIndex = 36;
            this.lblBgKategorieCode.Text = "Kategorie";
            this.lblBgKategorieCode.UseCompatibleTextRendering = true;
            // 
            // edtBgKategorieCode
            // 
            this.edtBgKategorieCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBgKategorieCode.DataMember = "BgKategorieCode";
            this.edtBgKategorieCode.DataSource = this.qryBgPositionsart;
            this.edtBgKategorieCode.Location = new System.Drawing.Point(79, 3);
            this.edtBgKategorieCode.LOVName = "BgKategorie";
            this.edtBgKategorieCode.Name = "edtBgKategorieCode";
            this.edtBgKategorieCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBgKategorieCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgKategorieCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgKategorieCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgKategorieCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgKategorieCode.Properties.Appearance.Options.UseFont = true;
            this.edtBgKategorieCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBgKategorieCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgKategorieCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBgKategorieCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBgKategorieCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtBgKategorieCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtBgKategorieCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgKategorieCode.Properties.NullText = "";
            this.edtBgKategorieCode.Properties.ShowFooter = false;
            this.edtBgKategorieCode.Properties.ShowHeader = false;
            this.edtBgKategorieCode.Size = new System.Drawing.Size(447, 24);
            this.edtBgKategorieCode.TabIndex = 37;
            // 
            // tpgBuchungstext
            // 
            this.tpgBuchungstext.Controls.Add(this.edtStandardwert);
            this.tpgBuchungstext.Controls.Add(this.lblBuchungstext);
            this.tpgBuchungstext.Controls.Add(this.edtBuchungstext);
            this.tpgBuchungstext.Controls.Add(this.edtPositionsartUseText);
            this.tpgBuchungstext.Controls.Add(this.lblGleicherText);
            this.tpgBuchungstext.Controls.Add(this.grdBuchungstext);
            this.tpgBuchungstext.Location = new System.Drawing.Point(6, 6);
            this.tpgBuchungstext.Name = "tpgBuchungstext";
            this.tpgBuchungstext.Size = new System.Drawing.Size(797, 285);
            this.tpgBuchungstext.TabIndex = 1;
            this.tpgBuchungstext.Title = "Buchungstext";
            // 
            // edtStandardwert
            // 
            this.edtStandardwert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtStandardwert.DataMember = "Standardwert";
            this.edtStandardwert.DataSource = this.qryBgPositionsartBuchungstext;
            this.edtStandardwert.Location = new System.Drawing.Point(514, 262);
            this.edtStandardwert.Name = "edtStandardwert";
            this.edtStandardwert.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtStandardwert.Properties.Appearance.Options.UseBackColor = true;
            this.edtStandardwert.Properties.Caption = "Standardwert";
            this.edtStandardwert.Size = new System.Drawing.Size(137, 19);
            this.edtStandardwert.TabIndex = 45;
            // 
            // qryBgPositionsartBuchungstext
            // 
            this.qryBgPositionsartBuchungstext.HostControl = this;
            this.qryBgPositionsartBuchungstext.SelectStatement = resources.GetString("qryBgPositionsartBuchungstext.SelectStatement");
            this.qryBgPositionsartBuchungstext.TableName = "BgPositionsartBuchungstext";
            this.qryBgPositionsartBuchungstext.AfterInsert += new System.EventHandler(this.qryBgPositionsartBuchungstext_AfterInsert);
            this.qryBgPositionsartBuchungstext.BeforePost += new System.EventHandler(this.qryBgPositionsartBuchungstext_BeforePost);
            // 
            // lblBuchungstext
            // 
            this.lblBuchungstext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBuchungstext.Location = new System.Drawing.Point(7, 258);
            this.lblBuchungstext.Name = "lblBuchungstext";
            this.lblBuchungstext.Size = new System.Drawing.Size(97, 24);
            this.lblBuchungstext.TabIndex = 44;
            this.lblBuchungstext.Text = "Buchungstext";
            this.lblBuchungstext.UseCompatibleTextRendering = true;
            // 
            // edtBuchungstext
            // 
            this.edtBuchungstext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBuchungstext.DataMember = "Buchungstext";
            this.edtBuchungstext.DataSource = this.qryBgPositionsartBuchungstext;
            this.edtBuchungstext.Location = new System.Drawing.Point(110, 258);
            this.edtBuchungstext.Name = "edtBuchungstext";
            this.edtBuchungstext.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBuchungstext.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBuchungstext.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchungstext.Properties.Appearance.Options.UseBackColor = true;
            this.edtBuchungstext.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBuchungstext.Properties.Appearance.Options.UseFont = true;
            this.edtBuchungstext.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBuchungstext.Size = new System.Drawing.Size(382, 24);
            this.edtBuchungstext.TabIndex = 43;
            // 
            // edtPositionsartUseText
            // 
            this.edtPositionsartUseText.DataMember = "Positionsart";
            this.edtPositionsartUseText.DataSource = this.qryBgPositionsartBuchungstext;
            this.edtPositionsartUseText.Location = new System.Drawing.Point(110, 3);
            this.edtPositionsartUseText.Name = "edtPositionsartUseText";
            this.edtPositionsartUseText.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPositionsartUseText.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPositionsartUseText.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPositionsartUseText.Properties.Appearance.Options.UseBackColor = true;
            this.edtPositionsartUseText.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPositionsartUseText.Properties.Appearance.Options.UseFont = true;
            this.edtPositionsartUseText.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtPositionsartUseText.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtPositionsartUseText.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPositionsartUseText.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtPositionsartUseText.Size = new System.Drawing.Size(317, 24);
            this.edtPositionsartUseText.TabIndex = 9;
            this.edtPositionsartUseText.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtPositionsartUseText_UserModifiedFld);
            // 
            // lblGleicherText
            // 
            this.lblGleicherText.Location = new System.Drawing.Point(4, 4);
            this.lblGleicherText.Name = "lblGleicherText";
            this.lblGleicherText.Size = new System.Drawing.Size(100, 23);
            this.lblGleicherText.TabIndex = 2;
            this.lblGleicherText.Text = "gleicher Text wie";
            // 
            // grdBuchungstext
            // 
            this.grdBuchungstext.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdBuchungstext.DataSource = this.qryBgPositionsartBuchungstext;
            // 
            // 
            // 
            this.grdBuchungstext.EmbeddedNavigator.Name = "";
            this.grdBuchungstext.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBuchungstext.Location = new System.Drawing.Point(0, 33);
            this.grdBuchungstext.MainView = this.grvBuchungstext;
            this.grdBuchungstext.Name = "grdBuchungstext";
            this.grdBuchungstext.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit3,
            this.repositoryItemCheckEdit4});
            this.grdBuchungstext.Size = new System.Drawing.Size(797, 219);
            this.grdBuchungstext.TabIndex = 1;
            this.grdBuchungstext.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBuchungstext});
            // 
            // grvBuchungstext
            // 
            this.grvBuchungstext.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBuchungstext.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBuchungstext.Appearance.Empty.Options.UseBackColor = true;
            this.grvBuchungstext.Appearance.Empty.Options.UseFont = true;
            this.grvBuchungstext.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBuchungstext.Appearance.EvenRow.Options.UseFont = true;
            this.grvBuchungstext.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBuchungstext.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBuchungstext.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBuchungstext.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBuchungstext.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBuchungstext.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBuchungstext.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBuchungstext.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBuchungstext.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBuchungstext.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBuchungstext.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBuchungstext.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBuchungstext.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBuchungstext.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBuchungstext.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBuchungstext.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBuchungstext.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBuchungstext.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBuchungstext.Appearance.GroupRow.Options.UseFont = true;
            this.grvBuchungstext.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBuchungstext.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBuchungstext.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBuchungstext.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBuchungstext.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBuchungstext.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBuchungstext.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBuchungstext.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBuchungstext.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBuchungstext.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBuchungstext.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBuchungstext.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBuchungstext.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBuchungstext.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBuchungstext.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBuchungstext.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBuchungstext.Appearance.OddRow.Options.UseFont = true;
            this.grvBuchungstext.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBuchungstext.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBuchungstext.Appearance.Row.Options.UseBackColor = true;
            this.grvBuchungstext.Appearance.Row.Options.UseFont = true;
            this.grvBuchungstext.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBuchungstext.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBuchungstext.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBuchungstext.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBuchungstext.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBuchungstext.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBuchungstext,
            this.colStandardwert});
            this.grvBuchungstext.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBuchungstext.GridControl = this.grdBuchungstext;
            this.grvBuchungstext.Name = "grvBuchungstext";
            this.grvBuchungstext.OptionsBehavior.Editable = false;
            this.grvBuchungstext.OptionsCustomization.AllowFilter = false;
            this.grvBuchungstext.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBuchungstext.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBuchungstext.OptionsNavigation.UseTabKey = false;
            this.grvBuchungstext.OptionsView.ColumnAutoWidth = false;
            this.grvBuchungstext.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBuchungstext.OptionsView.ShowGroupPanel = false;
            this.grvBuchungstext.OptionsView.ShowIndicator = false;
            // 
            // colBuchungstext
            // 
            this.colBuchungstext.Caption = "Buchungstext";
            this.colBuchungstext.FieldName = "Buchungstext";
            this.colBuchungstext.Name = "colBuchungstext";
            this.colBuchungstext.Visible = true;
            this.colBuchungstext.VisibleIndex = 0;
            this.colBuchungstext.Width = 300;
            // 
            // colStandardwert
            // 
            this.colStandardwert.Caption = "Standardwert";
            this.colStandardwert.FieldName = "Standardwert";
            this.colStandardwert.Name = "colStandardwert";
            this.colStandardwert.Visible = true;
            this.colStandardwert.VisibleIndex = 1;
            this.colStandardwert.Width = 100;
            // 
            // repositoryItemCheckEdit3
            // 
            this.repositoryItemCheckEdit3.AutoHeight = false;
            this.repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
            // 
            // repositoryItemCheckEdit4
            // 
            this.repositoryItemCheckEdit4.AutoHeight = false;
            this.repositoryItemCheckEdit4.Name = "repositoryItemCheckEdit4";
            // 
            // tabPageEx1
            // 
            this.tabPageEx1.Location = new System.Drawing.Point(0, 0);
            this.tabPageEx1.Name = "tabPageEx1";
            this.tabPageEx1.Size = new System.Drawing.Size(150, 150);
            this.tabPageEx1.TabIndex = 0;
            this.tabPageEx1.Title = "tabPageEx1";
            // 
            // tabPageEx2
            // 
            this.tabPageEx2.Location = new System.Drawing.Point(0, 0);
            this.tabPageEx2.Name = "tabPageEx2";
            this.tabPageEx2.Size = new System.Drawing.Size(150, 150);
            this.tabPageEx2.TabIndex = 0;
            this.tabPageEx2.Title = "tabPageEx2";
            // 
            // tabPageEx3
            // 
            this.tabPageEx3.Location = new System.Drawing.Point(0, 0);
            this.tabPageEx3.Name = "tabPageEx3";
            this.tabPageEx3.Size = new System.Drawing.Size(150, 150);
            this.tabPageEx3.TabIndex = 0;
            this.tabPageEx3.Title = "tabPageEx3";
            // 
            // CtlBgPositionsart
            // 
            this.ActiveSQLQuery = this.qryBgPositionsart;
            this.Controls.Add(this.tabDetail);
            this.Name = "CtlBgPositionsart";
            this.Size = new System.Drawing.Size(815, 635);
            this.Load += new System.EventHandler(this.CtlBgPositionsart_Load);
            this.Controls.SetChildIndex(this.tabDetail, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBgPositionsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPositionsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgPositionsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKategorieCodeX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKategorieCodeX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgGruppeCodeX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgGruppeCodeX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKostenartIDX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKostenartIDX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgKostenart)).EndInit();
            this.tabDetail.ResumeLayout(false);
            this.tpgPositionsart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtKeinKreditor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErzeugtBfsDossier.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTeilvorgang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHauptvorgang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHauptvorgang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHilfeText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editReadOnly.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEditMaskMonatHigh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEditMaskMonatLow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEditMaskMasterHigh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEditMaskMasterLow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgKostenartID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSortKey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSpezkonto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSortKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwaltungSD_Default.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProUE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKostenartID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKostenartID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgGruppeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgGruppeCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgGruppeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgKategorieCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKategorieCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKategorieCode)).EndInit();
            this.tpgBuchungstext.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtStandardwert.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPositionsartBuchungstext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungstext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungstext.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPositionsartUseText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGleicherText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBuchungstext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBuchungstext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).EndInit();
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

        private KissCheckEdit edtErzeugtBfsDossier;
        private KissCheckEdit edtKeinKreditor;
        private DevExpress.XtraGrid.Columns.GridColumn colKeinKreditor;



    }
}
