using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Sostat
{
    public class CtlBfsFragenkatalog : Common.KissSearchUserControl
    {
        #region Fields

        #region Private Fields

        private DevExpress.XtraGrid.Columns.GridColumn colFrage;
        private DevExpress.XtraGrid.Columns.GridColumn colIdx;
        private DevExpress.XtraGrid.Columns.GridColumn colKategorie;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonenTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colReihenfolge;
        private DevExpress.XtraGrid.Columns.GridColumn colVariable;
        private System.ComponentModel.IContainer components;
        private KissLookUpEdit edtBFSFrageKatalogVersionX;
        private KissTextEdit edtExportAttributeX;
        private KiSS4.Gui.KissTextEdit edtFrageX;
        private KiSS4.Gui.KissLookUpEdit edtSucheBFSKategorieCode;
        private KiSS4.Gui.KissTextEdit edtVariableX;
        private KiSS4.Gui.KissGrid grdBFSFrage;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KissLabel lblBFSFrageKatalogVersionX;
        private KissLabel lblExportAttributeX;
        private KiSS4.Gui.KissLabel lblFrageX;
        private KiSS4.Gui.KissLabel lblSucheBFSKategorieCode;
        private KiSS4.Gui.KissLabel lblVariableX;
        private System.Windows.Forms.Panel panDetail;
        private KissTextEdit edtBFSKatalogVersionID;
        private KissLabel lblBFSFrageKatalogVersion;
        private KissCheckEdit edtUpdateOK;
        private KissLabel lblReihenfolge;
        private KissCalcEdit edtReihenfolge;
        private KissLabel lblLeistungsfilter;
        private System.Windows.Forms.Panel pnlLeistungsfilter;
        private KissCheckedLookupEdit edtLeistungsfilter;
        private KissTextEdit edtBFSLOVName;
        private KissMemoEdit edtFrage;
        private KissCalcEdit edtPersonIndex;
        private KissLookUpEdit edtBFSValidierungCode;
        private KissLookUpEdit edtBFSPersonCode;
        private KissLookUpEdit edtBFSFeldCode;
        private KissLookUpEdit edtBFSKategorieCode;
        private KissCheckEdit edtEditierbar;
        private KissTextEdit edtVariable;
        private KissTextEdit edtBFSFormat;
        private KissTextEdit edtVorgabewert;
        private KissMemoEdit edtHilfeText;
        private KissLabel lblHilfetext;
        private KissGroupBox groupBox3;
        private KissTextEdit edtExportPredicate;
        private KissTextEdit edtExportAttribute;
        private KissTextEdit edtExportNode;
        private KissLabel lblAttribute;
        private KissLabel lblNode;
        private KissLabel lblPredicate;
        private KissGroupBox groupBox2;
        private KissLabel lblRegel;
        private KissMemoEdit edtFilterRegel;
        private KissMemoEdit edtHerkunftBeschreibung;
        private KissMemoEdit edtHerkunftSQL;
        private KissTextEdit edtFFPKFeld;
        private KissTextEdit edtFFLOVName;
        private KissLookUpEdit edtHerkunftCode;
        private KissTextEdit edtFFFeld;
        private KissTextEdit edtFFTabelle;
        private KissLabel lblTabelle;
        private KissLabel lblFFFeld;
        private KissLabel lblWertelisteFF;
        private KissLabel lblbPKFeld;
        private KissLabel lblTyp;
        private KissLabel lblBeschreibung;
        private KissLabel lblSQL;
        private KissLabel lblFrage;
        private KissLabel lblPerson;
        private KissLabel lblIndex;
        private KissLabel lblFeldtyp;
        private KissLabel lblFormat;
        private KissLabel lblWerteliste;
        private KissLabel lblValidierung;
        private KissLabel lblVorgabewert;
        private KissLabel lblKategorie;
        private KissLabel lblVariable;
        private KissSplitterCollapsible splitter;
        private KiSS4.DB.SqlQuery qryBFSFrage;

        #endregion

        #endregion

        #region Constructors

        public CtlBfsFragenkatalog()
        {
            InitializeComponent();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBfsFragenkatalog));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdBFSFrage = new KiSS4.Gui.KissGrid();
            this.qryBFSFrage = new KiSS4.DB.SqlQuery(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKategorie = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVariable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFrage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReihenfolge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersonenTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdx = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtVariableX = new KiSS4.Gui.KissTextEdit();
            this.lblVariableX = new KiSS4.Gui.KissLabel();
            this.lblFrageX = new KiSS4.Gui.KissLabel();
            this.edtFrageX = new KiSS4.Gui.KissTextEdit();
            this.edtSucheBFSKategorieCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheBFSKategorieCode = new KiSS4.Gui.KissLabel();
            this.lblExportAttributeX = new KiSS4.Gui.KissLabel();
            this.edtExportAttributeX = new KiSS4.Gui.KissTextEdit();
            this.edtBFSFrageKatalogVersionX = new KiSS4.Gui.KissLookUpEdit();
            this.lblBFSFrageKatalogVersionX = new KiSS4.Gui.KissLabel();
            this.panDetail = new System.Windows.Forms.Panel();
            this.edtBFSKatalogVersionID = new KiSS4.Gui.KissTextEdit();
            this.lblBFSFrageKatalogVersion = new KiSS4.Gui.KissLabel();
            this.edtUpdateOK = new KiSS4.Gui.KissCheckEdit();
            this.lblReihenfolge = new KiSS4.Gui.KissLabel();
            this.edtReihenfolge = new KiSS4.Gui.KissCalcEdit();
            this.lblLeistungsfilter = new KiSS4.Gui.KissLabel();
            this.pnlLeistungsfilter = new System.Windows.Forms.Panel();
            this.edtLeistungsfilter = new KiSS4.Gui.KissCheckedLookupEdit();
            this.edtBFSLOVName = new KiSS4.Gui.KissTextEdit();
            this.edtFrage = new KiSS4.Gui.KissMemoEdit();
            this.edtPersonIndex = new KiSS4.Gui.KissCalcEdit();
            this.edtBFSValidierungCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtBFSPersonCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtBFSFeldCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtBFSKategorieCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtEditierbar = new KiSS4.Gui.KissCheckEdit();
            this.edtVariable = new KiSS4.Gui.KissTextEdit();
            this.edtBFSFormat = new KiSS4.Gui.KissTextEdit();
            this.edtVorgabewert = new KiSS4.Gui.KissTextEdit();
            this.edtHilfeText = new KiSS4.Gui.KissMemoEdit();
            this.lblHilfetext = new KiSS4.Gui.KissLabel();
            this.groupBox3 = new KiSS4.Gui.KissGroupBox();
            this.edtExportPredicate = new KiSS4.Gui.KissTextEdit();
            this.edtExportAttribute = new KiSS4.Gui.KissTextEdit();
            this.edtExportNode = new KiSS4.Gui.KissTextEdit();
            this.lblAttribute = new KiSS4.Gui.KissLabel();
            this.lblNode = new KiSS4.Gui.KissLabel();
            this.lblPredicate = new KiSS4.Gui.KissLabel();
            this.groupBox2 = new KiSS4.Gui.KissGroupBox();
            this.lblRegel = new KiSS4.Gui.KissLabel();
            this.edtFilterRegel = new KiSS4.Gui.KissMemoEdit();
            this.edtHerkunftBeschreibung = new KiSS4.Gui.KissMemoEdit();
            this.edtHerkunftSQL = new KiSS4.Gui.KissMemoEdit();
            this.edtFFPKFeld = new KiSS4.Gui.KissTextEdit();
            this.edtFFLOVName = new KiSS4.Gui.KissTextEdit();
            this.edtHerkunftCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtFFFeld = new KiSS4.Gui.KissTextEdit();
            this.edtFFTabelle = new KiSS4.Gui.KissTextEdit();
            this.lblTabelle = new KiSS4.Gui.KissLabel();
            this.lblFFFeld = new KiSS4.Gui.KissLabel();
            this.lblWertelisteFF = new KiSS4.Gui.KissLabel();
            this.lblbPKFeld = new KiSS4.Gui.KissLabel();
            this.lblTyp = new KiSS4.Gui.KissLabel();
            this.lblBeschreibung = new KiSS4.Gui.KissLabel();
            this.lblSQL = new KiSS4.Gui.KissLabel();
            this.lblFrage = new KiSS4.Gui.KissLabel();
            this.lblPerson = new KiSS4.Gui.KissLabel();
            this.lblIndex = new KiSS4.Gui.KissLabel();
            this.lblFeldtyp = new KiSS4.Gui.KissLabel();
            this.lblFormat = new KiSS4.Gui.KissLabel();
            this.lblWerteliste = new KiSS4.Gui.KissLabel();
            this.lblValidierung = new KiSS4.Gui.KissLabel();
            this.lblVorgabewert = new KiSS4.Gui.KissLabel();
            this.lblKategorie = new KiSS4.Gui.KissLabel();
            this.lblVariable = new KiSS4.Gui.KissLabel();
            this.splitter = new KiSS4.Gui.KissSplitterCollapsible();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBFSFrage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBFSFrage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVariableX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVariableX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFrageX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFrageX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBFSKategorieCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBFSKategorieCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBFSKategorieCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblExportAttributeX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtExportAttributeX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSFrageKatalogVersionX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSFrageKatalogVersionX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBFSFrageKatalogVersionX)).BeginInit();
            this.panDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSKatalogVersionID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBFSFrageKatalogVersion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUpdateOK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReihenfolge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtReihenfolge.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeistungsfilter)).BeginInit();
            this.pnlLeistungsfilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtLeistungsfilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSLOVName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFrage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonIndex.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSValidierungCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSValidierungCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSPersonCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSPersonCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSFeldCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSFeldCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSKategorieCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSKategorieCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEditierbar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVariable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSFormat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorgabewert.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHilfeText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHilfetext)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtExportPredicate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtExportAttribute.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtExportNode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAttribute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPredicate)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblRegel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilterRegel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHerkunftBeschreibung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHerkunftSQL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFFPKFeld.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFFLOVName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHerkunftCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHerkunftCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFFFeld.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFFTabelle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTabelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFFFeld)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWertelisteFF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbPKFeld)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeschreibung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSQL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFrage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFeldtyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFormat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWerteliste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValidierung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVorgabewert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKategorie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVariable)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(893, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 0);
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.Size = new System.Drawing.Size(917, 227);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdBFSFrage);
            this.tpgListe.Size = new System.Drawing.Size(905, 189);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtBFSFrageKatalogVersionX);
            this.tpgSuchen.Controls.Add(this.lblBFSFrageKatalogVersionX);
            this.tpgSuchen.Controls.Add(this.lblExportAttributeX);
            this.tpgSuchen.Controls.Add(this.edtExportAttributeX);
            this.tpgSuchen.Controls.Add(this.edtSucheBFSKategorieCode);
            this.tpgSuchen.Controls.Add(this.edtFrageX);
            this.tpgSuchen.Controls.Add(this.lblFrageX);
            this.tpgSuchen.Controls.Add(this.lblSucheBFSKategorieCode);
            this.tpgSuchen.Controls.Add(this.lblVariableX);
            this.tpgSuchen.Controls.Add(this.edtVariableX);
            this.tpgSuchen.Size = new System.Drawing.Size(905, 189);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtVariableX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblVariableX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBFSKategorieCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblFrageX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFrageX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBFSKategorieCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtExportAttributeX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblExportAttributeX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBFSFrageKatalogVersionX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBFSFrageKatalogVersionX, 0);
            // 
            // grdBFSFrage
            // 
            this.grdBFSFrage.DataSource = this.qryBFSFrage;
            this.grdBFSFrage.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdBFSFrage.EmbeddedNavigator.Name = "";
            this.grdBFSFrage.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBFSFrage.Location = new System.Drawing.Point(0, 0);
            this.grdBFSFrage.MainView = this.gridView1;
            this.grdBFSFrage.Name = "grdBFSFrage";
            this.grdBFSFrage.Size = new System.Drawing.Size(905, 189);
            this.grdBFSFrage.TabIndex = 0;
            this.grdBFSFrage.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // qryBFSFrage
            // 
            this.qryBFSFrage.CanDelete = true;
            this.qryBFSFrage.CanInsert = true;
            this.qryBFSFrage.CanUpdate = true;
            this.qryBFSFrage.HostControl = this;
            this.qryBFSFrage.SelectStatement = resources.GetString("qryBFSFrage.SelectStatement");
            this.qryBFSFrage.TableName = "BFSFrage";
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
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKategorie,
            this.colVariable,
            this.colFrage,
            this.colReihenfolge,
            this.colPersonenTyp,
            this.colIdx});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.grdBFSFrage;
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
            // colKategorie
            // 
            this.colKategorie.Caption = "Kategorie";
            this.colKategorie.FieldName = "BFSKategorieCode";
            this.colKategorie.Name = "colKategorie";
            this.colKategorie.Visible = true;
            this.colKategorie.VisibleIndex = 0;
            this.colKategorie.Width = 130;
            // 
            // colVariable
            // 
            this.colVariable.Caption = "Variable";
            this.colVariable.FieldName = "Variable";
            this.colVariable.Name = "colVariable";
            this.colVariable.Visible = true;
            this.colVariable.VisibleIndex = 1;
            // 
            // colFrage
            // 
            this.colFrage.Caption = "Frage";
            this.colFrage.FieldName = "Frage";
            this.colFrage.Name = "colFrage";
            this.colFrage.Visible = true;
            this.colFrage.VisibleIndex = 2;
            this.colFrage.Width = 493;
            // 
            // colReihenfolge
            // 
            this.colReihenfolge.Caption = "Folge";
            this.colReihenfolge.FieldName = "Reihenfolge";
            this.colReihenfolge.Name = "colReihenfolge";
            this.colReihenfolge.Width = 50;
            // 
            // colPersonenTyp
            // 
            this.colPersonenTyp.Caption = "Personentyp";
            this.colPersonenTyp.FieldName = "BFSPersonCode";
            this.colPersonenTyp.Name = "colPersonenTyp";
            this.colPersonenTyp.Visible = true;
            this.colPersonenTyp.VisibleIndex = 3;
            this.colPersonenTyp.Width = 99;
            // 
            // colIdx
            // 
            this.colIdx.Caption = "Idx";
            this.colIdx.FieldName = "PersonIndex";
            this.colIdx.Name = "colIdx";
            this.colIdx.Visible = true;
            this.colIdx.VisibleIndex = 4;
            this.colIdx.Width = 32;
            // 
            // edtVariableX
            // 
            this.edtVariableX.Location = new System.Drawing.Point(127, 70);
            this.edtVariableX.Name = "edtVariableX";
            this.edtVariableX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVariableX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVariableX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVariableX.Properties.Appearance.Options.UseBackColor = true;
            this.edtVariableX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVariableX.Properties.Appearance.Options.UseFont = true;
            this.edtVariableX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVariableX.Size = new System.Drawing.Size(181, 24);
            this.edtVariableX.TabIndex = 4;
            // 
            // lblVariableX
            // 
            this.lblVariableX.Location = new System.Drawing.Point(31, 70);
            this.lblVariableX.Name = "lblVariableX";
            this.lblVariableX.Size = new System.Drawing.Size(90, 24);
            this.lblVariableX.TabIndex = 3;
            this.lblVariableX.Text = "Variable";
            this.lblVariableX.UseCompatibleTextRendering = true;
            // 
            // lblFrageX
            // 
            this.lblFrageX.Location = new System.Drawing.Point(31, 100);
            this.lblFrageX.Name = "lblFrageX";
            this.lblFrageX.Size = new System.Drawing.Size(90, 24);
            this.lblFrageX.TabIndex = 5;
            this.lblFrageX.Text = "Frage";
            this.lblFrageX.UseCompatibleTextRendering = true;
            // 
            // edtFrageX
            // 
            this.edtFrageX.Location = new System.Drawing.Point(127, 100);
            this.edtFrageX.Name = "edtFrageX";
            this.edtFrageX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFrageX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFrageX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFrageX.Properties.Appearance.Options.UseBackColor = true;
            this.edtFrageX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFrageX.Properties.Appearance.Options.UseFont = true;
            this.edtFrageX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFrageX.Size = new System.Drawing.Size(181, 24);
            this.edtFrageX.TabIndex = 6;
            // 
            // edtSucheBFSKategorieCode
            // 
            this.edtSucheBFSKategorieCode.Location = new System.Drawing.Point(127, 40);
            this.edtSucheBFSKategorieCode.Name = "edtSucheBFSKategorieCode";
            this.edtSucheBFSKategorieCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBFSKategorieCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBFSKategorieCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBFSKategorieCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBFSKategorieCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBFSKategorieCode.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBFSKategorieCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheBFSKategorieCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBFSKategorieCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheBFSKategorieCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheBFSKategorieCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtSucheBFSKategorieCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtSucheBFSKategorieCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheBFSKategorieCode.Properties.NullText = "";
            this.edtSucheBFSKategorieCode.Properties.ShowFooter = false;
            this.edtSucheBFSKategorieCode.Properties.ShowHeader = false;
            this.edtSucheBFSKategorieCode.Size = new System.Drawing.Size(181, 24);
            this.edtSucheBFSKategorieCode.TabIndex = 2;
            // 
            // lblSucheBFSKategorieCode
            // 
            this.lblSucheBFSKategorieCode.Location = new System.Drawing.Point(31, 40);
            this.lblSucheBFSKategorieCode.Name = "lblSucheBFSKategorieCode";
            this.lblSucheBFSKategorieCode.Size = new System.Drawing.Size(90, 24);
            this.lblSucheBFSKategorieCode.TabIndex = 1;
            this.lblSucheBFSKategorieCode.Text = "Kategorie";
            this.lblSucheBFSKategorieCode.UseCompatibleTextRendering = true;
            // 
            // lblExportAttributeX
            // 
            this.lblExportAttributeX.Location = new System.Drawing.Point(338, 40);
            this.lblExportAttributeX.Name = "lblExportAttributeX";
            this.lblExportAttributeX.Size = new System.Drawing.Size(90, 24);
            this.lblExportAttributeX.TabIndex = 7;
            this.lblExportAttributeX.Text = "Export-Attribute";
            this.lblExportAttributeX.UseCompatibleTextRendering = true;
            // 
            // edtExportAttributeX
            // 
            this.edtExportAttributeX.Location = new System.Drawing.Point(434, 40);
            this.edtExportAttributeX.Name = "edtExportAttributeX";
            this.edtExportAttributeX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtExportAttributeX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtExportAttributeX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtExportAttributeX.Properties.Appearance.Options.UseBackColor = true;
            this.edtExportAttributeX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtExportAttributeX.Properties.Appearance.Options.UseFont = true;
            this.edtExportAttributeX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtExportAttributeX.Size = new System.Drawing.Size(181, 24);
            this.edtExportAttributeX.TabIndex = 8;
            // 
            // edtBFSFrageKatalogVersionX
            // 
            this.edtBFSFrageKatalogVersionX.AllowNull = false;
            this.edtBFSFrageKatalogVersionX.DataSource = this.qryBFSFrage;
            this.edtBFSFrageKatalogVersionX.Location = new System.Drawing.Point(127, 130);
            this.edtBFSFrageKatalogVersionX.Name = "edtBFSFrageKatalogVersionX";
            this.edtBFSFrageKatalogVersionX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBFSFrageKatalogVersionX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBFSFrageKatalogVersionX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBFSFrageKatalogVersionX.Properties.Appearance.Options.UseBackColor = true;
            this.edtBFSFrageKatalogVersionX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBFSFrageKatalogVersionX.Properties.Appearance.Options.UseFont = true;
            this.edtBFSFrageKatalogVersionX.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBFSFrageKatalogVersionX.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBFSFrageKatalogVersionX.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBFSFrageKatalogVersionX.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBFSFrageKatalogVersionX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtBFSFrageKatalogVersionX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtBFSFrageKatalogVersionX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBFSFrageKatalogVersionX.Properties.NullText = "";
            this.edtBFSFrageKatalogVersionX.Properties.ShowFooter = false;
            this.edtBFSFrageKatalogVersionX.Properties.ShowHeader = false;
            this.edtBFSFrageKatalogVersionX.Size = new System.Drawing.Size(181, 24);
            this.edtBFSFrageKatalogVersionX.TabIndex = 10;
            // 
            // lblBFSFrageKatalogVersionX
            // 
            this.lblBFSFrageKatalogVersionX.Location = new System.Drawing.Point(31, 130);
            this.lblBFSFrageKatalogVersionX.Name = "lblBFSFrageKatalogVersionX";
            this.lblBFSFrageKatalogVersionX.Size = new System.Drawing.Size(90, 24);
            this.lblBFSFrageKatalogVersionX.TabIndex = 9;
            this.lblBFSFrageKatalogVersionX.Text = "Katalog-Version";
            this.lblBFSFrageKatalogVersionX.UseCompatibleTextRendering = true;
            // 
            // panDetail
            // 
            this.panDetail.AutoScroll = true;
            this.panDetail.AutoScrollMinSize = new System.Drawing.Size(915, 535);
            this.panDetail.Controls.Add(this.edtBFSKatalogVersionID);
            this.panDetail.Controls.Add(this.lblBFSFrageKatalogVersion);
            this.panDetail.Controls.Add(this.edtUpdateOK);
            this.panDetail.Controls.Add(this.lblReihenfolge);
            this.panDetail.Controls.Add(this.edtReihenfolge);
            this.panDetail.Controls.Add(this.lblLeistungsfilter);
            this.panDetail.Controls.Add(this.pnlLeistungsfilter);
            this.panDetail.Controls.Add(this.edtBFSLOVName);
            this.panDetail.Controls.Add(this.edtFrage);
            this.panDetail.Controls.Add(this.edtPersonIndex);
            this.panDetail.Controls.Add(this.edtBFSValidierungCode);
            this.panDetail.Controls.Add(this.edtBFSPersonCode);
            this.panDetail.Controls.Add(this.edtBFSFeldCode);
            this.panDetail.Controls.Add(this.edtBFSKategorieCode);
            this.panDetail.Controls.Add(this.edtEditierbar);
            this.panDetail.Controls.Add(this.edtVariable);
            this.panDetail.Controls.Add(this.edtBFSFormat);
            this.panDetail.Controls.Add(this.edtVorgabewert);
            this.panDetail.Controls.Add(this.edtHilfeText);
            this.panDetail.Controls.Add(this.lblHilfetext);
            this.panDetail.Controls.Add(this.groupBox3);
            this.panDetail.Controls.Add(this.groupBox2);
            this.panDetail.Controls.Add(this.lblFrage);
            this.panDetail.Controls.Add(this.lblPerson);
            this.panDetail.Controls.Add(this.lblIndex);
            this.panDetail.Controls.Add(this.lblFeldtyp);
            this.panDetail.Controls.Add(this.lblFormat);
            this.panDetail.Controls.Add(this.lblWerteliste);
            this.panDetail.Controls.Add(this.lblValidierung);
            this.panDetail.Controls.Add(this.lblVorgabewert);
            this.panDetail.Controls.Add(this.lblKategorie);
            this.panDetail.Controls.Add(this.lblVariable);
            this.panDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panDetail.Location = new System.Drawing.Point(0, 235);
            this.panDetail.Name = "panDetail";
            this.panDetail.Size = new System.Drawing.Size(917, 537);
            this.panDetail.TabIndex = 1;
            // 
            // edtBFSKatalogVersionID
            // 
            this.edtBFSKatalogVersionID.DataMember = "BFSKatalogVersionID";
            this.edtBFSKatalogVersionID.DataSource = this.qryBFSFrage;
            this.edtBFSKatalogVersionID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBFSKatalogVersionID.Location = new System.Drawing.Point(306, 125);
            this.edtBFSKatalogVersionID.Name = "edtBFSKatalogVersionID";
            this.edtBFSKatalogVersionID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBFSKatalogVersionID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBFSKatalogVersionID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBFSKatalogVersionID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBFSKatalogVersionID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBFSKatalogVersionID.Properties.Appearance.Options.UseFont = true;
            this.edtBFSKatalogVersionID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBFSKatalogVersionID.Properties.ReadOnly = true;
            this.edtBFSKatalogVersionID.Size = new System.Drawing.Size(123, 24);
            this.edtBFSKatalogVersionID.TabIndex = 81;
            // 
            // lblBFSFrageKatalogVersion
            // 
            this.lblBFSFrageKatalogVersion.Location = new System.Drawing.Point(214, 127);
            this.lblBFSFrageKatalogVersion.Name = "lblBFSFrageKatalogVersion";
            this.lblBFSFrageKatalogVersion.Size = new System.Drawing.Size(86, 24);
            this.lblBFSFrageKatalogVersion.TabIndex = 80;
            this.lblBFSFrageKatalogVersion.Text = "Katalog-Version";
            this.lblBFSFrageKatalogVersion.UseCompatibleTextRendering = true;
            // 
            // edtUpdateOK
            // 
            this.edtUpdateOK.DataMember = "UpdateOK";
            this.edtUpdateOK.DataSource = this.qryBFSFrage;
            this.edtUpdateOK.Location = new System.Drawing.Point(354, 373);
            this.edtUpdateOK.Name = "edtUpdateOK";
            this.edtUpdateOK.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtUpdateOK.Properties.Appearance.Options.UseBackColor = true;
            this.edtUpdateOK.Properties.Caption = "UpdateOK";
            this.edtUpdateOK.Size = new System.Drawing.Size(75, 19);
            this.edtUpdateOK.TabIndex = 74;
            // 
            // lblReihenfolge
            // 
            this.lblReihenfolge.Location = new System.Drawing.Point(306, 317);
            this.lblReihenfolge.Name = "lblReihenfolge";
            this.lblReihenfolge.Size = new System.Drawing.Size(42, 24);
            this.lblReihenfolge.TabIndex = 71;
            this.lblReihenfolge.Text = "Sort.";
            this.lblReihenfolge.UseCompatibleTextRendering = true;
            // 
            // edtReihenfolge
            // 
            this.edtReihenfolge.DataMember = "Reihenfolge";
            this.edtReihenfolge.DataSource = this.qryBFSFrage;
            this.edtReihenfolge.Location = new System.Drawing.Point(354, 317);
            this.edtReihenfolge.Name = "edtReihenfolge";
            this.edtReihenfolge.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtReihenfolge.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtReihenfolge.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtReihenfolge.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtReihenfolge.Properties.Appearance.Options.UseBackColor = true;
            this.edtReihenfolge.Properties.Appearance.Options.UseBorderColor = true;
            this.edtReihenfolge.Properties.Appearance.Options.UseFont = true;
            this.edtReihenfolge.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtReihenfolge.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtReihenfolge.Size = new System.Drawing.Size(75, 24);
            this.edtReihenfolge.TabIndex = 72;
            // 
            // lblLeistungsfilter
            // 
            this.lblLeistungsfilter.Location = new System.Drawing.Point(5, 14);
            this.lblLeistungsfilter.Name = "lblLeistungsfilter";
            this.lblLeistungsfilter.Size = new System.Drawing.Size(88, 24);
            this.lblLeistungsfilter.TabIndex = 50;
            this.lblLeistungsfilter.Text = "Leistungsfilter";
            this.lblLeistungsfilter.UseCompatibleTextRendering = true;
            // 
            // pnlLeistungsfilter
            // 
            this.pnlLeistungsfilter.Controls.Add(this.edtLeistungsfilter);
            this.pnlLeistungsfilter.Location = new System.Drawing.Point(99, 14);
            this.pnlLeistungsfilter.Name = "pnlLeistungsfilter";
            this.pnlLeistungsfilter.Size = new System.Drawing.Size(330, 107);
            this.pnlLeistungsfilter.TabIndex = 79;
            // 
            // edtLeistungsfilter
            // 
            this.edtLeistungsfilter.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.edtLeistungsfilter.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLeistungsfilter.Appearance.Options.UseBackColor = true;
            this.edtLeistungsfilter.Appearance.Options.UseBorderColor = true;
            this.edtLeistungsfilter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtLeistungsfilter.CheckOnClick = true;
            this.edtLeistungsfilter.DataMember = "BFSLeistungsfilterCodes";
            this.edtLeistungsfilter.DataSource = this.qryBFSFrage;
            this.edtLeistungsfilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtLeistungsfilter.Location = new System.Drawing.Point(0, 0);
            this.edtLeistungsfilter.LookupSQL = "SELECT Code, Text\r\nFROM BFSLOVCode\r\nWHERE LOVName = \'BFSLeistungsfilter\'";
            this.edtLeistungsfilter.MultiColumn = true;
            this.edtLeistungsfilter.Name = "edtLeistungsfilter";
            this.edtLeistungsfilter.Size = new System.Drawing.Size(330, 107);
            this.edtLeistungsfilter.TabIndex = 0;
            // 
            // edtBFSLOVName
            // 
            this.edtBFSLOVName.DataMember = "BFSLOVName";
            this.edtBFSLOVName.DataSource = this.qryBFSFrage;
            this.edtBFSLOVName.Location = new System.Drawing.Point(99, 315);
            this.edtBFSLOVName.Name = "edtBFSLOVName";
            this.edtBFSLOVName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBFSLOVName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBFSLOVName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBFSLOVName.Properties.Appearance.Options.UseBackColor = true;
            this.edtBFSLOVName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBFSLOVName.Properties.Appearance.Options.UseFont = true;
            this.edtBFSLOVName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBFSLOVName.Size = new System.Drawing.Size(192, 24);
            this.edtBFSLOVName.TabIndex = 62;
            // 
            // edtFrage
            // 
            this.edtFrage.DataMember = "Frage";
            this.edtFrage.DataSource = this.qryBFSFrage;
            this.edtFrage.Location = new System.Drawing.Point(99, 157);
            this.edtFrage.Name = "edtFrage";
            this.edtFrage.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFrage.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFrage.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFrage.Properties.Appearance.Options.UseBackColor = true;
            this.edtFrage.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFrage.Properties.Appearance.Options.UseFont = true;
            this.edtFrage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFrage.Size = new System.Drawing.Size(331, 58);
            this.edtFrage.TabIndex = 54;
            // 
            // edtPersonIndex
            // 
            this.edtPersonIndex.DataMember = "PersonIndex";
            this.edtPersonIndex.DataSource = this.qryBFSFrage;
            this.edtPersonIndex.Location = new System.Drawing.Point(354, 254);
            this.edtPersonIndex.Name = "edtPersonIndex";
            this.edtPersonIndex.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtPersonIndex.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPersonIndex.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPersonIndex.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPersonIndex.Properties.Appearance.Options.UseBackColor = true;
            this.edtPersonIndex.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPersonIndex.Properties.Appearance.Options.UseFont = true;
            this.edtPersonIndex.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPersonIndex.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPersonIndex.Size = new System.Drawing.Size(38, 24);
            this.edtPersonIndex.TabIndex = 68;
            // 
            // edtBFSValidierungCode
            // 
            this.edtBFSValidierungCode.DataMember = "BFSValidierungCode";
            this.edtBFSValidierungCode.DataSource = this.qryBFSFrage;
            this.edtBFSValidierungCode.Location = new System.Drawing.Point(99, 377);
            this.edtBFSValidierungCode.LOVName = "BFSValidierung";
            this.edtBFSValidierungCode.Name = "edtBFSValidierungCode";
            this.edtBFSValidierungCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBFSValidierungCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBFSValidierungCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBFSValidierungCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtBFSValidierungCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBFSValidierungCode.Properties.Appearance.Options.UseFont = true;
            this.edtBFSValidierungCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBFSValidierungCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBFSValidierungCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBFSValidierungCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBFSValidierungCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtBFSValidierungCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "_", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtBFSValidierungCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBFSValidierungCode.Properties.NullText = "";
            this.edtBFSValidierungCode.Properties.ShowFooter = false;
            this.edtBFSValidierungCode.Properties.ShowHeader = false;
            this.edtBFSValidierungCode.Size = new System.Drawing.Size(192, 24);
            this.edtBFSValidierungCode.TabIndex = 66;
            // 
            // edtBFSPersonCode
            // 
            this.edtBFSPersonCode.DataMember = "BFSPersonCode";
            this.edtBFSPersonCode.DataSource = this.qryBFSFrage;
            this.edtBFSPersonCode.Location = new System.Drawing.Point(99, 254);
            this.edtBFSPersonCode.Name = "edtBFSPersonCode";
            this.edtBFSPersonCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBFSPersonCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBFSPersonCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBFSPersonCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtBFSPersonCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBFSPersonCode.Properties.Appearance.Options.UseFont = true;
            this.edtBFSPersonCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBFSPersonCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBFSPersonCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBFSPersonCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBFSPersonCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtBFSPersonCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "_", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtBFSPersonCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBFSPersonCode.Properties.NullText = "";
            this.edtBFSPersonCode.Properties.ShowFooter = false;
            this.edtBFSPersonCode.Properties.ShowHeader = false;
            this.edtBFSPersonCode.Size = new System.Drawing.Size(192, 24);
            this.edtBFSPersonCode.TabIndex = 58;
            // 
            // edtBFSFeldCode
            // 
            this.edtBFSFeldCode.AllowNull = false;
            this.edtBFSFeldCode.DataMember = "BFSFeldCode";
            this.edtBFSFeldCode.DataSource = this.qryBFSFrage;
            this.edtBFSFeldCode.Location = new System.Drawing.Point(99, 285);
            this.edtBFSFeldCode.LOVName = "BFSFeld";
            this.edtBFSFeldCode.Name = "edtBFSFeldCode";
            this.edtBFSFeldCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBFSFeldCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBFSFeldCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBFSFeldCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtBFSFeldCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBFSFeldCode.Properties.Appearance.Options.UseFont = true;
            this.edtBFSFeldCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBFSFeldCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBFSFeldCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBFSFeldCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBFSFeldCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtBFSFeldCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "_", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtBFSFeldCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBFSFeldCode.Properties.NullText = "";
            this.edtBFSFeldCode.Properties.ShowFooter = false;
            this.edtBFSFeldCode.Properties.ShowHeader = false;
            this.edtBFSFeldCode.Size = new System.Drawing.Size(192, 24);
            this.edtBFSFeldCode.TabIndex = 60;
            // 
            // edtBFSKategorieCode
            // 
            this.edtBFSKategorieCode.DataMember = "BFSKategorieCode";
            this.edtBFSKategorieCode.DataSource = this.qryBFSFrage;
            this.edtBFSKategorieCode.Location = new System.Drawing.Point(99, 223);
            this.edtBFSKategorieCode.Name = "edtBFSKategorieCode";
            this.edtBFSKategorieCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBFSKategorieCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBFSKategorieCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBFSKategorieCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtBFSKategorieCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBFSKategorieCode.Properties.Appearance.Options.UseFont = true;
            this.edtBFSKategorieCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBFSKategorieCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBFSKategorieCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBFSKategorieCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBFSKategorieCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtBFSKategorieCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtBFSKategorieCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBFSKategorieCode.Properties.NullText = "";
            this.edtBFSKategorieCode.Properties.ShowFooter = false;
            this.edtBFSKategorieCode.Properties.ShowHeader = false;
            this.edtBFSKategorieCode.Size = new System.Drawing.Size(331, 24);
            this.edtBFSKategorieCode.TabIndex = 56;
            // 
            // edtEditierbar
            // 
            this.edtEditierbar.DataMember = "Editierbar";
            this.edtEditierbar.DataSource = this.qryBFSFrage;
            this.edtEditierbar.Location = new System.Drawing.Point(354, 347);
            this.edtEditierbar.Name = "edtEditierbar";
            this.edtEditierbar.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtEditierbar.Properties.Appearance.Options.UseBackColor = true;
            this.edtEditierbar.Properties.Caption = "editierbar";
            this.edtEditierbar.Size = new System.Drawing.Size(86, 19);
            this.edtEditierbar.TabIndex = 73;
            // 
            // edtVariable
            // 
            this.edtVariable.DataMember = "Variable";
            this.edtVariable.DataSource = this.qryBFSFrage;
            this.edtVariable.Location = new System.Drawing.Point(99, 127);
            this.edtVariable.Name = "edtVariable";
            this.edtVariable.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVariable.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVariable.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVariable.Properties.Appearance.Options.UseBackColor = true;
            this.edtVariable.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVariable.Properties.Appearance.Options.UseFont = true;
            this.edtVariable.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVariable.Size = new System.Drawing.Size(100, 24);
            this.edtVariable.TabIndex = 52;
            // 
            // edtBFSFormat
            // 
            this.edtBFSFormat.DataMember = "BFSFormat";
            this.edtBFSFormat.DataSource = this.qryBFSFrage;
            this.edtBFSFormat.Location = new System.Drawing.Point(354, 285);
            this.edtBFSFormat.Name = "edtBFSFormat";
            this.edtBFSFormat.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBFSFormat.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBFSFormat.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBFSFormat.Properties.Appearance.Options.UseBackColor = true;
            this.edtBFSFormat.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBFSFormat.Properties.Appearance.Options.UseFont = true;
            this.edtBFSFormat.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBFSFormat.Size = new System.Drawing.Size(75, 24);
            this.edtBFSFormat.TabIndex = 70;
            // 
            // edtVorgabewert
            // 
            this.edtVorgabewert.DataMember = "Vorgabewert";
            this.edtVorgabewert.DataSource = this.qryBFSFrage;
            this.edtVorgabewert.Location = new System.Drawing.Point(99, 347);
            this.edtVorgabewert.Name = "edtVorgabewert";
            this.edtVorgabewert.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVorgabewert.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVorgabewert.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVorgabewert.Properties.Appearance.Options.UseBackColor = true;
            this.edtVorgabewert.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVorgabewert.Properties.Appearance.Options.UseFont = true;
            this.edtVorgabewert.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVorgabewert.Size = new System.Drawing.Size(192, 24);
            this.edtVorgabewert.TabIndex = 64;
            // 
            // edtHilfeText
            // 
            this.edtHilfeText.DataMember = "HilfeText";
            this.edtHilfeText.DataSource = this.qryBFSFrage;
            this.edtHilfeText.Location = new System.Drawing.Point(99, 407);
            this.edtHilfeText.Name = "edtHilfeText";
            this.edtHilfeText.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtHilfeText.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHilfeText.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHilfeText.Properties.Appearance.Options.UseBackColor = true;
            this.edtHilfeText.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHilfeText.Properties.Appearance.Options.UseFont = true;
            this.edtHilfeText.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtHilfeText.Size = new System.Drawing.Size(334, 121);
            this.edtHilfeText.TabIndex = 76;
            // 
            // lblHilfetext
            // 
            this.lblHilfetext.Location = new System.Drawing.Point(5, 407);
            this.lblHilfetext.Name = "lblHilfetext";
            this.lblHilfetext.Size = new System.Drawing.Size(88, 24);
            this.lblHilfetext.TabIndex = 75;
            this.lblHilfetext.Text = "Hilfetext";
            this.lblHilfetext.UseCompatibleTextRendering = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.edtExportPredicate);
            this.groupBox3.Controls.Add(this.edtExportAttribute);
            this.groupBox3.Controls.Add(this.edtExportNode);
            this.groupBox3.Controls.Add(this.lblAttribute);
            this.groupBox3.Controls.Add(this.lblNode);
            this.groupBox3.Controls.Add(this.lblPredicate);
            this.groupBox3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.groupBox3.Location = new System.Drawing.Point(451, 407);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(460, 122);
            this.groupBox3.TabIndex = 78;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "XML Export";
            this.groupBox3.UseCompatibleTextRendering = true;
            // 
            // edtExportPredicate
            // 
            this.edtExportPredicate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtExportPredicate.DataMember = "ExportPredicate";
            this.edtExportPredicate.DataSource = this.qryBFSFrage;
            this.edtExportPredicate.Location = new System.Drawing.Point(71, 80);
            this.edtExportPredicate.Name = "edtExportPredicate";
            this.edtExportPredicate.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtExportPredicate.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtExportPredicate.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtExportPredicate.Properties.Appearance.Options.UseBackColor = true;
            this.edtExportPredicate.Properties.Appearance.Options.UseBorderColor = true;
            this.edtExportPredicate.Properties.Appearance.Options.UseFont = true;
            this.edtExportPredicate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtExportPredicate.Size = new System.Drawing.Size(382, 24);
            this.edtExportPredicate.TabIndex = 5;
            // 
            // edtExportAttribute
            // 
            this.edtExportAttribute.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtExportAttribute.DataMember = "ExportAttribute";
            this.edtExportAttribute.DataSource = this.qryBFSFrage;
            this.edtExportAttribute.Location = new System.Drawing.Point(71, 50);
            this.edtExportAttribute.Name = "edtExportAttribute";
            this.edtExportAttribute.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtExportAttribute.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtExportAttribute.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtExportAttribute.Properties.Appearance.Options.UseBackColor = true;
            this.edtExportAttribute.Properties.Appearance.Options.UseBorderColor = true;
            this.edtExportAttribute.Properties.Appearance.Options.UseFont = true;
            this.edtExportAttribute.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtExportAttribute.Size = new System.Drawing.Size(382, 24);
            this.edtExportAttribute.TabIndex = 3;
            // 
            // edtExportNode
            // 
            this.edtExportNode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtExportNode.DataMember = "ExportNode";
            this.edtExportNode.DataSource = this.qryBFSFrage;
            this.edtExportNode.Location = new System.Drawing.Point(71, 20);
            this.edtExportNode.Name = "edtExportNode";
            this.edtExportNode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtExportNode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtExportNode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtExportNode.Properties.Appearance.Options.UseBackColor = true;
            this.edtExportNode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtExportNode.Properties.Appearance.Options.UseFont = true;
            this.edtExportNode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtExportNode.Size = new System.Drawing.Size(382, 24);
            this.edtExportNode.TabIndex = 1;
            // 
            // lblAttribute
            // 
            this.lblAttribute.Location = new System.Drawing.Point(6, 50);
            this.lblAttribute.Name = "lblAttribute";
            this.lblAttribute.Size = new System.Drawing.Size(59, 24);
            this.lblAttribute.TabIndex = 2;
            this.lblAttribute.Text = "Attribute";
            this.lblAttribute.UseCompatibleTextRendering = true;
            // 
            // lblNode
            // 
            this.lblNode.Location = new System.Drawing.Point(6, 20);
            this.lblNode.Name = "lblNode";
            this.lblNode.Size = new System.Drawing.Size(59, 24);
            this.lblNode.TabIndex = 0;
            this.lblNode.Text = "Node";
            this.lblNode.UseCompatibleTextRendering = true;
            // 
            // lblPredicate
            // 
            this.lblPredicate.Location = new System.Drawing.Point(6, 80);
            this.lblPredicate.Name = "lblPredicate";
            this.lblPredicate.Size = new System.Drawing.Size(59, 24);
            this.lblPredicate.TabIndex = 4;
            this.lblPredicate.Text = "Predicate";
            this.lblPredicate.UseCompatibleTextRendering = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblRegel);
            this.groupBox2.Controls.Add(this.edtFilterRegel);
            this.groupBox2.Controls.Add(this.edtHerkunftBeschreibung);
            this.groupBox2.Controls.Add(this.edtHerkunftSQL);
            this.groupBox2.Controls.Add(this.edtFFPKFeld);
            this.groupBox2.Controls.Add(this.edtFFLOVName);
            this.groupBox2.Controls.Add(this.edtHerkunftCode);
            this.groupBox2.Controls.Add(this.edtFFFeld);
            this.groupBox2.Controls.Add(this.edtFFTabelle);
            this.groupBox2.Controls.Add(this.lblTabelle);
            this.groupBox2.Controls.Add(this.lblFFFeld);
            this.groupBox2.Controls.Add(this.lblWertelisteFF);
            this.groupBox2.Controls.Add(this.lblbPKFeld);
            this.groupBox2.Controls.Add(this.lblTyp);
            this.groupBox2.Controls.Add(this.lblBeschreibung);
            this.groupBox2.Controls.Add(this.lblSQL);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.groupBox2.Location = new System.Drawing.Point(451, 14);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(460, 387);
            this.groupBox2.TabIndex = 77;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Herleitung aus Fallführung";
            this.groupBox2.UseCompatibleTextRendering = true;
            // 
            // lblRegel
            // 
            this.lblRegel.Location = new System.Drawing.Point(6, 293);
            this.lblRegel.Name = "lblRegel";
            this.lblRegel.Size = new System.Drawing.Size(59, 24);
            this.lblRegel.TabIndex = 14;
            this.lblRegel.Text = "Filterregel";
            this.lblRegel.UseCompatibleTextRendering = true;
            // 
            // edtFilterRegel
            // 
            this.edtFilterRegel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtFilterRegel.DataMember = "FilterRegel";
            this.edtFilterRegel.DataSource = this.qryBFSFrage;
            this.edtFilterRegel.Location = new System.Drawing.Point(71, 293);
            this.edtFilterRegel.Name = "edtFilterRegel";
            this.edtFilterRegel.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFilterRegel.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFilterRegel.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFilterRegel.Properties.Appearance.Options.UseBackColor = true;
            this.edtFilterRegel.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFilterRegel.Properties.Appearance.Options.UseFont = true;
            this.edtFilterRegel.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFilterRegel.Size = new System.Drawing.Size(382, 78);
            this.edtFilterRegel.TabIndex = 15;
            // 
            // edtHerkunftBeschreibung
            // 
            this.edtHerkunftBeschreibung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtHerkunftBeschreibung.DataMember = "HerkunftBeschreibung";
            this.edtHerkunftBeschreibung.DataSource = this.qryBFSFrage;
            this.edtHerkunftBeschreibung.Location = new System.Drawing.Point(71, 115);
            this.edtHerkunftBeschreibung.Name = "edtHerkunftBeschreibung";
            this.edtHerkunftBeschreibung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtHerkunftBeschreibung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHerkunftBeschreibung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHerkunftBeschreibung.Properties.Appearance.Options.UseBackColor = true;
            this.edtHerkunftBeschreibung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHerkunftBeschreibung.Properties.Appearance.Options.UseFont = true;
            this.edtHerkunftBeschreibung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtHerkunftBeschreibung.Size = new System.Drawing.Size(382, 80);
            this.edtHerkunftBeschreibung.TabIndex = 11;
            // 
            // edtHerkunftSQL
            // 
            this.edtHerkunftSQL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtHerkunftSQL.DataMember = "HerkunftSQL";
            this.edtHerkunftSQL.DataSource = this.qryBFSFrage;
            this.edtHerkunftSQL.Location = new System.Drawing.Point(71, 202);
            this.edtHerkunftSQL.Name = "edtHerkunftSQL";
            this.edtHerkunftSQL.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtHerkunftSQL.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHerkunftSQL.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHerkunftSQL.Properties.Appearance.Options.UseBackColor = true;
            this.edtHerkunftSQL.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHerkunftSQL.Properties.Appearance.Options.UseFont = true;
            this.edtHerkunftSQL.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtHerkunftSQL.Size = new System.Drawing.Size(382, 78);
            this.edtHerkunftSQL.TabIndex = 13;
            // 
            // edtFFPKFeld
            // 
            this.edtFFPKFeld.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtFFPKFeld.DataMember = "FFPKFeld";
            this.edtFFPKFeld.DataSource = this.qryBFSFrage;
            this.edtFFPKFeld.Location = new System.Drawing.Point(271, 84);
            this.edtFFPKFeld.Name = "edtFFPKFeld";
            this.edtFFPKFeld.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFFPKFeld.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFFPKFeld.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFFPKFeld.Properties.Appearance.Options.UseBackColor = true;
            this.edtFFPKFeld.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFFPKFeld.Properties.Appearance.Options.UseFont = true;
            this.edtFFPKFeld.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFFPKFeld.Size = new System.Drawing.Size(182, 24);
            this.edtFFPKFeld.TabIndex = 9;
            // 
            // edtFFLOVName
            // 
            this.edtFFLOVName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtFFLOVName.DataMember = "FFLOVName";
            this.edtFFLOVName.DataSource = this.qryBFSFrage;
            this.edtFFLOVName.Location = new System.Drawing.Point(71, 84);
            this.edtFFLOVName.Name = "edtFFLOVName";
            this.edtFFLOVName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFFLOVName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFFLOVName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFFLOVName.Properties.Appearance.Options.UseBackColor = true;
            this.edtFFLOVName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFFLOVName.Properties.Appearance.Options.UseFont = true;
            this.edtFFLOVName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFFLOVName.Size = new System.Drawing.Size(113, 24);
            this.edtFFLOVName.TabIndex = 5;
            // 
            // edtHerkunftCode
            // 
            this.edtHerkunftCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtHerkunftCode.DataMember = "HerkunftCode";
            this.edtHerkunftCode.DataSource = this.qryBFSFrage;
            this.edtHerkunftCode.Location = new System.Drawing.Point(71, 24);
            this.edtHerkunftCode.LOVName = "BFSHerleitung";
            this.edtHerkunftCode.Name = "edtHerkunftCode";
            this.edtHerkunftCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtHerkunftCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHerkunftCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHerkunftCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtHerkunftCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHerkunftCode.Properties.Appearance.Options.UseFont = true;
            this.edtHerkunftCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtHerkunftCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtHerkunftCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtHerkunftCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtHerkunftCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtHerkunftCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "_", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtHerkunftCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtHerkunftCode.Properties.NullText = "";
            this.edtHerkunftCode.Properties.ShowFooter = false;
            this.edtHerkunftCode.Properties.ShowHeader = false;
            this.edtHerkunftCode.Size = new System.Drawing.Size(113, 24);
            this.edtHerkunftCode.TabIndex = 1;
            // 
            // edtFFFeld
            // 
            this.edtFFFeld.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtFFFeld.DataMember = "FFFeld";
            this.edtFFFeld.DataSource = this.qryBFSFrage;
            this.edtFFFeld.Location = new System.Drawing.Point(271, 54);
            this.edtFFFeld.Name = "edtFFFeld";
            this.edtFFFeld.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFFFeld.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFFFeld.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFFFeld.Properties.Appearance.Options.UseBackColor = true;
            this.edtFFFeld.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFFFeld.Properties.Appearance.Options.UseFont = true;
            this.edtFFFeld.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFFFeld.Size = new System.Drawing.Size(182, 24);
            this.edtFFFeld.TabIndex = 7;
            // 
            // edtFFTabelle
            // 
            this.edtFFTabelle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtFFTabelle.DataMember = "FFTabelle";
            this.edtFFTabelle.DataSource = this.qryBFSFrage;
            this.edtFFTabelle.Location = new System.Drawing.Point(71, 54);
            this.edtFFTabelle.Name = "edtFFTabelle";
            this.edtFFTabelle.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFFTabelle.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFFTabelle.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFFTabelle.Properties.Appearance.Options.UseBackColor = true;
            this.edtFFTabelle.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFFTabelle.Properties.Appearance.Options.UseFont = true;
            this.edtFFTabelle.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFFTabelle.Size = new System.Drawing.Size(113, 24);
            this.edtFFTabelle.TabIndex = 3;
            // 
            // lblTabelle
            // 
            this.lblTabelle.Location = new System.Drawing.Point(6, 54);
            this.lblTabelle.Name = "lblTabelle";
            this.lblTabelle.Size = new System.Drawing.Size(59, 24);
            this.lblTabelle.TabIndex = 2;
            this.lblTabelle.Text = "Tabelle";
            this.lblTabelle.UseCompatibleTextRendering = true;
            // 
            // lblFFFeld
            // 
            this.lblFFFeld.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFFFeld.Location = new System.Drawing.Point(203, 54);
            this.lblFFFeld.Name = "lblFFFeld";
            this.lblFFFeld.Size = new System.Drawing.Size(62, 24);
            this.lblFFFeld.TabIndex = 6;
            this.lblFFFeld.Text = "Feld";
            this.lblFFFeld.UseCompatibleTextRendering = true;
            // 
            // lblWertelisteFF
            // 
            this.lblWertelisteFF.Location = new System.Drawing.Point(6, 84);
            this.lblWertelisteFF.Name = "lblWertelisteFF";
            this.lblWertelisteFF.Size = new System.Drawing.Size(59, 24);
            this.lblWertelisteFF.TabIndex = 4;
            this.lblWertelisteFF.Text = "Werteliste";
            this.lblWertelisteFF.UseCompatibleTextRendering = true;
            // 
            // lblbPKFeld
            // 
            this.lblbPKFeld.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblbPKFeld.Location = new System.Drawing.Point(203, 84);
            this.lblbPKFeld.Name = "lblbPKFeld";
            this.lblbPKFeld.Size = new System.Drawing.Size(62, 24);
            this.lblbPKFeld.TabIndex = 8;
            this.lblbPKFeld.Text = "PK-Feld";
            this.lblbPKFeld.UseCompatibleTextRendering = true;
            // 
            // lblTyp
            // 
            this.lblTyp.Location = new System.Drawing.Point(6, 24);
            this.lblTyp.Name = "lblTyp";
            this.lblTyp.Size = new System.Drawing.Size(59, 24);
            this.lblTyp.TabIndex = 0;
            this.lblTyp.Text = "Typ";
            this.lblTyp.UseCompatibleTextRendering = true;
            // 
            // lblBeschreibung
            // 
            this.lblBeschreibung.Location = new System.Drawing.Point(6, 115);
            this.lblBeschreibung.Name = "lblBeschreibung";
            this.lblBeschreibung.Size = new System.Drawing.Size(59, 24);
            this.lblBeschreibung.TabIndex = 10;
            this.lblBeschreibung.Text = "Beschr.";
            this.lblBeschreibung.UseCompatibleTextRendering = true;
            // 
            // lblSQL
            // 
            this.lblSQL.Location = new System.Drawing.Point(6, 202);
            this.lblSQL.Name = "lblSQL";
            this.lblSQL.Size = new System.Drawing.Size(59, 24);
            this.lblSQL.TabIndex = 12;
            this.lblSQL.Text = "SQL";
            this.lblSQL.UseCompatibleTextRendering = true;
            // 
            // lblFrage
            // 
            this.lblFrage.Location = new System.Drawing.Point(5, 157);
            this.lblFrage.Name = "lblFrage";
            this.lblFrage.Size = new System.Drawing.Size(88, 24);
            this.lblFrage.TabIndex = 53;
            this.lblFrage.Text = "Frage";
            this.lblFrage.UseCompatibleTextRendering = true;
            // 
            // lblPerson
            // 
            this.lblPerson.Location = new System.Drawing.Point(5, 254);
            this.lblPerson.Name = "lblPerson";
            this.lblPerson.Size = new System.Drawing.Size(88, 24);
            this.lblPerson.TabIndex = 57;
            this.lblPerson.Text = "Person";
            this.lblPerson.UseCompatibleTextRendering = true;
            // 
            // lblIndex
            // 
            this.lblIndex.Location = new System.Drawing.Point(306, 254);
            this.lblIndex.Name = "lblIndex";
            this.lblIndex.Size = new System.Drawing.Size(51, 24);
            this.lblIndex.TabIndex = 67;
            this.lblIndex.Text = "Index";
            this.lblIndex.UseCompatibleTextRendering = true;
            // 
            // lblFeldtyp
            // 
            this.lblFeldtyp.Location = new System.Drawing.Point(5, 285);
            this.lblFeldtyp.Name = "lblFeldtyp";
            this.lblFeldtyp.Size = new System.Drawing.Size(88, 24);
            this.lblFeldtyp.TabIndex = 59;
            this.lblFeldtyp.Text = "Feldtyp";
            this.lblFeldtyp.UseCompatibleTextRendering = true;
            // 
            // lblFormat
            // 
            this.lblFormat.Location = new System.Drawing.Point(306, 285);
            this.lblFormat.Name = "lblFormat";
            this.lblFormat.Size = new System.Drawing.Size(42, 24);
            this.lblFormat.TabIndex = 69;
            this.lblFormat.Text = "Format";
            this.lblFormat.UseCompatibleTextRendering = true;
            // 
            // lblWerteliste
            // 
            this.lblWerteliste.Location = new System.Drawing.Point(5, 315);
            this.lblWerteliste.Name = "lblWerteliste";
            this.lblWerteliste.Size = new System.Drawing.Size(88, 24);
            this.lblWerteliste.TabIndex = 61;
            this.lblWerteliste.Text = "Werteliste";
            this.lblWerteliste.UseCompatibleTextRendering = true;
            // 
            // lblValidierung
            // 
            this.lblValidierung.Location = new System.Drawing.Point(5, 377);
            this.lblValidierung.Name = "lblValidierung";
            this.lblValidierung.Size = new System.Drawing.Size(88, 24);
            this.lblValidierung.TabIndex = 65;
            this.lblValidierung.Text = "Validierung";
            this.lblValidierung.UseCompatibleTextRendering = true;
            // 
            // lblVorgabewert
            // 
            this.lblVorgabewert.Location = new System.Drawing.Point(5, 347);
            this.lblVorgabewert.Name = "lblVorgabewert";
            this.lblVorgabewert.Size = new System.Drawing.Size(88, 24);
            this.lblVorgabewert.TabIndex = 63;
            this.lblVorgabewert.Text = "Vorgabewert";
            this.lblVorgabewert.UseCompatibleTextRendering = true;
            // 
            // lblKategorie
            // 
            this.lblKategorie.Location = new System.Drawing.Point(5, 223);
            this.lblKategorie.Name = "lblKategorie";
            this.lblKategorie.Size = new System.Drawing.Size(88, 24);
            this.lblKategorie.TabIndex = 55;
            this.lblKategorie.Text = "Kategorie";
            this.lblKategorie.UseCompatibleTextRendering = true;
            // 
            // lblVariable
            // 
            this.lblVariable.Location = new System.Drawing.Point(5, 127);
            this.lblVariable.Name = "lblVariable";
            this.lblVariable.Size = new System.Drawing.Size(88, 24);
            this.lblVariable.TabIndex = 51;
            this.lblVariable.Text = "Variable";
            this.lblVariable.UseCompatibleTextRendering = true;
            // 
            // splitter
            // 
            this.splitter.AnimationDelay = 20;
            this.splitter.AnimationStep = 20;
            this.splitter.BorderStyle3D = System.Windows.Forms.Border3DStyle.Etched;
            this.splitter.ControlToHide = this.panDetail;
            this.splitter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter.ExpandParentForm = false;
            this.splitter.Location = new System.Drawing.Point(0, 227);
            this.splitter.Name = "splitter";
            this.splitter.TabIndex = 2;
            this.splitter.TabStop = false;
            this.splitter.UseAnimations = false;
            this.splitter.VisualStyle = KiSS4.Gui.VisualStyles.Mozilla;
            // 
            // CtlBfsFragenkatalog
            // 
            this.ActiveSQLQuery = this.qryBFSFrage;
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.panDetail);
            this.Location = new System.Drawing.Point(12, 0);
            this.Name = "CtlBfsFragenkatalog";
            this.Size = new System.Drawing.Size(917, 772);
            this.Load += new System.EventHandler(this.CtlBfsFragenkatalog_Load);
            this.Controls.SetChildIndex(this.panDetail, 0);
            this.Controls.SetChildIndex(this.splitter, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBFSFrage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBFSFrage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVariableX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVariableX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFrageX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFrageX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBFSKategorieCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBFSKategorieCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBFSKategorieCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblExportAttributeX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtExportAttributeX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSFrageKatalogVersionX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSFrageKatalogVersionX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBFSFrageKatalogVersionX)).EndInit();
            this.panDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSKatalogVersionID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBFSFrageKatalogVersion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUpdateOK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReihenfolge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtReihenfolge.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeistungsfilter)).EndInit();
            this.pnlLeistungsfilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtLeistungsfilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSLOVName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFrage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonIndex.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSValidierungCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSValidierungCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSPersonCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSPersonCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSFeldCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSFeldCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSKategorieCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSKategorieCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEditierbar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVariable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSFormat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorgabewert.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHilfeText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHilfetext)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtExportPredicate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtExportAttribute.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtExportNode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAttribute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPredicate)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblRegel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilterRegel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHerkunftBeschreibung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHerkunftSQL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFFPKFeld.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFFLOVName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHerkunftCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHerkunftCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFFFeld.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFFTabelle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTabelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFFFeld)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWertelisteFF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbPKFeld)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeschreibung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSQL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFrage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFeldtyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFormat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWerteliste)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValidierung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVorgabewert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKategorie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVariable)).EndInit();
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

        #region EventHandlers

        private void CtlBfsFragenkatalog_Load(object sender, System.EventArgs e)
        {
            // fill column edits
            colKategorie.ColumnEdit = grdBFSFrage.GetLOVLookUpEdit(DBUtil.OpenSQL(@"
                    SELECT Code,
                           Text
                    FROM dbo.BFSLOVCode WITH (READUNCOMMITTED)
                    WHERE LOVName = 'BFSKategorie'
                    ORDER BY SortKey"));

            colPersonenTyp.ColumnEdit = grdBFSFrage.GetLOVLookUpEdit(DBUtil.OpenSQL(@"
                    SELECT Code,
                           Text
                    FROM dbo.BFSLOVCode WITH (READUNCOMMITTED)
                    WHERE LOVName = 'BFSPerson'
                    ORDER BY SortKey"));

            // fill Kategorie
            edtBFSKategorieCode.LoadQuery(DBUtil.OpenSQL(@"
                    SELECT Code,
                           Text
                    FROM dbo.BFSLOVCode WITH (READUNCOMMITTED)
                    WHERE LOVName = 'BFSKategorie'
                    ORDER BY SortKey"));

            // fill Kategorie-Suche
            edtSucheBFSKategorieCode.LoadQuery(DBUtil.OpenSQL(@"
                    SELECT Code = NULL,
                           Text = '',
                           SortKey = -1

                    UNION

                    SELECT Code,
                           Text,
                           SortKey
                    FROM dbo.BFSLOVCode WITH (READUNCOMMITTED)
                    WHERE LOVName = 'BFSKategorie'
                    ORDER BY SortKey"));

            // fill PersonCode
            edtBFSPersonCode.LoadQuery(DBUtil.OpenSQL(@"
                    SELECT Code,
                           Text
                    FROM dbo.BFSLOVCode WITH (READUNCOMMITTED)
                    WHERE LOVName = 'BFSPerson'
                    ORDER BY SortKey"));

            // fill PersonCode
            edtBFSFrageKatalogVersionX.LoadQuery(DBUtil.OpenSQL(@"
                    SELECT
                      Code = BFSKatalogVersionID,
                      Text = BFSKatalogVersionID
                    FROM BFSKatalogVersion
                    ORDER BY BFSKatalogVersionID DESC"));

            edtBFSFrageKatalogVersionX.ItemIndex = 0;
        }

        #endregion
    }
}