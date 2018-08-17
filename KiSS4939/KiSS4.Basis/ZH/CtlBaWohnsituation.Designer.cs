namespace KiSS4.Basis.ZH
{
    public partial class CtlBaWohnsituation
    {
        #region Fields

        private DevExpress.XtraGrid.Columns.GridColumn colBis;
        private DevExpress.XtraGrid.Columns.GridColumn colGleicherHaushalt;
        private DevExpress.XtraGrid.Columns.GridColumn colMieteNetto;
        private DevExpress.XtraGrid.Columns.GridColumn colNebenkosten;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colVermieter;
        private DevExpress.XtraGrid.Columns.GridColumn colVon;
        private DevExpress.XtraGrid.Columns.GridColumn colWohnsituation;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit colchkIstInHaushalt;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissMemoEdit edtBemerkung;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissCalcEdit edtMiete;
        private KiSS4.Gui.KissCalcEdit edtMieteAnteil;
        private KiSS4.Gui.KissCalcEdit edtNebenkosten;
        private KiSS4.Gui.KissCalcEdit edtNebenkostenAnteil;
        private KiSS4.Gui.KissLookUpEdit edtSicherheitsleistungArt;
        private KiSS4.Gui.KissCalcEdit edtSicherheitsleistungBetrag;
        private KiSS4.Gui.KissLookUpEdit edtSicherheitsleistungUebernahmen;
        private KiSS4.Gui.KissButtonEdit edtVermieter;
        private KiSS4.Gui.KissLookUpEdit edtWohnsituation;
        private KiSS4.Gui.KissLookUpEdit edtWohnungsgroesse;
        private KiSS4.Gui.KissGrid grdBaWohnsituation;
        private KiSS4.Gui.KissGrid grdBaWohnsituationPerson;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBaWohnsituation;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBaWohnsituationPerson;
        private KiSS4.Gui.KissLabel kissLabel1;
        private KiSS4.Gui.KissLabel kissLabel2;
        private KiSS4.Gui.KissLabel kissLabel5;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblCHF1;
        private KiSS4.Gui.KissLabel lblCHF2;
        private KiSS4.Gui.KissLabel lblCHF3;
        private KiSS4.Gui.KissLabel lblDatumBis;
        private KiSS4.Gui.KissLabel lblDatumVon;
        private KiSS4.Gui.KissLabel lblGesamtmiete;
        private KiSS4.Gui.KissLabel lblHaushalt;
        private KiSS4.Gui.KissLabel lblMiete;
        private KiSS4.Gui.KissLabel lblMietvertrag;
        private KiSS4.Gui.KissLabel lblNebenkosten;
        private KiSS4.Gui.KissLabel lblSIcherheitsleistungArt;
        private KiSS4.Gui.KissLabel lblSicherheitsleistung;
        private KiSS4.Gui.KissLabel lblSicherheitsleistungBetrag;
        private KiSS4.Gui.KissLabel lblSicherheitsleistungUebernahmen;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissLabel lblVermieter;
        private KiSS4.Gui.KissLabel lblWohnsituation;
        private KiSS4.Gui.KissLabel lblWohnungsgroesse;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryBaWohnsituation;
        private KiSS4.DB.SqlQuery qryBaWohnsituationPerson;

        #endregion

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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBaWohnsituation));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.qryBaWohnsituation = new KiSS4.DB.SqlQuery(this.components);
            this.grdBaWohnsituation = new KiSS4.Gui.KissGrid();
            this.grvBaWohnsituation = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWohnsituation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVermieter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMieteNetto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNebenkosten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtWohnsituation = new KiSS4.Gui.KissLookUpEdit();
            this.edtWohnungsgroesse = new KiSS4.Gui.KissLookUpEdit();
            this.grdBaWohnsituationPerson = new KiSS4.Gui.KissGrid();
            this.qryBaWohnsituationPerson = new KiSS4.DB.SqlQuery(this.components);
            this.grvBaWohnsituationPerson = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGleicherHaushalt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colchkIstInHaushalt = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.edtVermieter = new KiSS4.Gui.KissButtonEdit();
            this.edtMiete = new KiSS4.Gui.KissCalcEdit();
            this.edtMieteAnteil = new KiSS4.Gui.KissCalcEdit();
            this.edtNebenkosten = new KiSS4.Gui.KissCalcEdit();
            this.edtNebenkostenAnteil = new KiSS4.Gui.KissCalcEdit();
            this.edtSicherheitsleistungArt = new KiSS4.Gui.KissLookUpEdit();
            this.edtSicherheitsleistungBetrag = new KiSS4.Gui.KissCalcEdit();
            this.edtSicherheitsleistungUebernahmen = new KiSS4.Gui.KissLookUpEdit();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.lblVermieter = new KiSS4.Gui.KissLabel();
            this.lblDatumVon = new KiSS4.Gui.KissLabel();
            this.lblDatumBis = new KiSS4.Gui.KissLabel();
            this.lblCHF2 = new KiSS4.Gui.KissLabel();
            this.lblCHF1 = new KiSS4.Gui.KissLabel();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.lblSicherheitsleistung = new KiSS4.Gui.KissLabel();
            this.lblSIcherheitsleistungArt = new KiSS4.Gui.KissLabel();
            this.lblSicherheitsleistungBetrag = new KiSS4.Gui.KissLabel();
            this.lblGesamtmiete = new KiSS4.Gui.KissLabel();
            this.lblCHF3 = new KiSS4.Gui.KissLabel();
            this.lblMiete = new KiSS4.Gui.KissLabel();
            this.lblNebenkosten = new KiSS4.Gui.KissLabel();
            this.lblSicherheitsleistungUebernahmen = new KiSS4.Gui.KissLabel();
            this.lblWohnsituation = new KiSS4.Gui.KissLabel();
            this.lblWohnungsgroesse = new KiSS4.Gui.KissLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.lblHaushalt = new KiSS4.Gui.KissLabel();
            this.lblMietvertrag = new KiSS4.Gui.KissLabel();
            this.kissLabel5 = new KiSS4.Gui.KissLabel();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaWohnsituation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaWohnsituation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaWohnsituation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsituation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsituation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnungsgroesse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnungsgroesse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaWohnsituationPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaWohnsituationPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaWohnsituationPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colchkIstInHaushalt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVermieter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMiete.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMieteAnteil.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNebenkosten.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNebenkostenAnteil.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSicherheitsleistungArt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSicherheitsleistungArt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSicherheitsleistungBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSicherheitsleistungUebernahmen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSicherheitsleistungUebernahmen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVermieter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHF2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHF1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSicherheitsleistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSIcherheitsleistungArt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSicherheitsleistungBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGesamtmiete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHF3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMiete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNebenkosten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSicherheitsleistungUebernahmen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWohnsituation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWohnungsgroesse)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHaushalt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMietvertrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            this.SuspendLayout();
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDatumVon.DataMember = "DatumVon";
            this.edtDatumVon.DataSource = this.qryBaWohnsituation;
            this.edtDatumVon.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(103, 236);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
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
            this.edtDatumVon.Properties.Name = "kissDateEdit1.Properties";
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVon.TabIndex = 0;
            // 
            // qryBaWohnsituation
            // 
            this.qryBaWohnsituation.CanDelete = true;
            this.qryBaWohnsituation.CanInsert = true;
            this.qryBaWohnsituation.CanUpdate = true;
            this.qryBaWohnsituation.HostControl = this;
            this.qryBaWohnsituation.SelectStatement = resources.GetString("qryBaWohnsituation.SelectStatement");
            this.qryBaWohnsituation.TableName = "BaWohnsituation";
            this.qryBaWohnsituation.AfterFill += new System.EventHandler(this.qryBaWohnsituation_AfterFill);
            this.qryBaWohnsituation.BeforePost += new System.EventHandler(this.qryBaWohnsituation_BeforePost);
            this.qryBaWohnsituation.AfterPost += new System.EventHandler(this.qryBaWohnsituation_AfterPost);
            this.qryBaWohnsituation.BeforeDeleteQuestion += new System.EventHandler(this.qryBaWohnsituation_BeforeDeleteQuestion);
            this.qryBaWohnsituation.BeforeDelete += new System.EventHandler(this.qryBaWohnsituation_BeforeDelete);
            this.qryBaWohnsituation.AfterDelete += new System.EventHandler(this.qryBaWohnsituation_AfterDelete);
            this.qryBaWohnsituation.PostError += new System.UnhandledExceptionEventHandler(this.qryBaWohnsituation_PostError);
            this.qryBaWohnsituation.DeleteError += new System.UnhandledExceptionEventHandler(this.qryBaWohnsituation_DeleteError);
            this.qryBaWohnsituation.PositionChanged += new System.EventHandler(this.qryBaWohnsituation_PositionChanged);
            // 
            // grdBaWohnsituation
            // 
            this.grdBaWohnsituation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdBaWohnsituation.DataSource = this.qryBaWohnsituation;
            // 
            // 
            // 
            this.grdBaWohnsituation.EmbeddedNavigator.Name = "kissGrid1.EmbeddedNavigator";
            this.grdBaWohnsituation.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBaWohnsituation.Location = new System.Drawing.Point(5, 30);
            this.grdBaWohnsituation.MainView = this.grvBaWohnsituation;
            this.grdBaWohnsituation.Name = "grdBaWohnsituation";
            this.grdBaWohnsituation.Size = new System.Drawing.Size(708, 200);
            this.grdBaWohnsituation.TabIndex = 0;
            this.grdBaWohnsituation.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBaWohnsituation});
            // 
            // grvBaWohnsituation
            // 
            this.grvBaWohnsituation.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBaWohnsituation.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWohnsituation.Appearance.Empty.Options.UseBackColor = true;
            this.grvBaWohnsituation.Appearance.Empty.Options.UseFont = true;
            this.grvBaWohnsituation.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWohnsituation.Appearance.EvenRow.Options.UseFont = true;
            this.grvBaWohnsituation.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBaWohnsituation.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWohnsituation.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBaWohnsituation.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBaWohnsituation.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBaWohnsituation.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBaWohnsituation.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBaWohnsituation.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWohnsituation.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBaWohnsituation.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBaWohnsituation.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBaWohnsituation.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBaWohnsituation.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaWohnsituation.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBaWohnsituation.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaWohnsituation.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBaWohnsituation.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBaWohnsituation.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBaWohnsituation.Appearance.GroupRow.Options.UseFont = true;
            this.grvBaWohnsituation.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBaWohnsituation.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBaWohnsituation.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBaWohnsituation.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBaWohnsituation.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBaWohnsituation.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBaWohnsituation.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBaWohnsituation.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBaWohnsituation.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWohnsituation.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBaWohnsituation.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBaWohnsituation.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBaWohnsituation.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBaWohnsituation.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBaWohnsituation.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBaWohnsituation.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWohnsituation.Appearance.OddRow.Options.UseFont = true;
            this.grvBaWohnsituation.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBaWohnsituation.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWohnsituation.Appearance.Row.Options.UseBackColor = true;
            this.grvBaWohnsituation.Appearance.Row.Options.UseFont = true;
            this.grvBaWohnsituation.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWohnsituation.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBaWohnsituation.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBaWohnsituation.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBaWohnsituation.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBaWohnsituation.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colVon,
            this.colBis,
            this.colWohnsituation,
            this.colVermieter,
            this.colMieteNetto,
            this.colNebenkosten});
            this.grvBaWohnsituation.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBaWohnsituation.GridControl = this.grdBaWohnsituation;
            this.grvBaWohnsituation.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvBaWohnsituation.Name = "grvBaWohnsituation";
            this.grvBaWohnsituation.OptionsBehavior.Editable = false;
            this.grvBaWohnsituation.OptionsCustomization.AllowFilter = false;
            this.grvBaWohnsituation.OptionsFilter.AllowFilterEditor = false;
            this.grvBaWohnsituation.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBaWohnsituation.OptionsMenu.EnableColumnMenu = false;
            this.grvBaWohnsituation.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBaWohnsituation.OptionsNavigation.UseTabKey = false;
            this.grvBaWohnsituation.OptionsView.ColumnAutoWidth = false;
            this.grvBaWohnsituation.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBaWohnsituation.OptionsView.ShowGroupPanel = false;
            this.grvBaWohnsituation.OptionsView.ShowIndicator = false;
            // 
            // colVon
            // 
            this.colVon.Caption = "von";
            this.colVon.FieldName = "DatumVon";
            this.colVon.Name = "colVon";
            this.colVon.Visible = true;
            this.colVon.VisibleIndex = 0;
            // 
            // colBis
            // 
            this.colBis.Caption = "bis";
            this.colBis.FieldName = "DatumBis";
            this.colBis.Name = "colBis";
            this.colBis.Visible = true;
            this.colBis.VisibleIndex = 1;
            // 
            // colWohnsituation
            // 
            this.colWohnsituation.Caption = "Wohnsituation";
            this.colWohnsituation.FieldName = "WohnsituationCode";
            this.colWohnsituation.Name = "colWohnsituation";
            this.colWohnsituation.Visible = true;
            this.colWohnsituation.VisibleIndex = 2;
            this.colWohnsituation.Width = 135;
            // 
            // colVermieter
            // 
            this.colVermieter.Caption = "Vermieter";
            this.colVermieter.FieldName = "Name";
            this.colVermieter.Name = "colVermieter";
            this.colVermieter.Visible = true;
            this.colVermieter.VisibleIndex = 3;
            this.colVermieter.Width = 211;
            // 
            // colMieteNetto
            // 
            this.colMieteNetto.AppearanceHeader.Options.UseTextOptions = true;
            this.colMieteNetto.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colMieteNetto.Caption = "Miete gesamt";
            this.colMieteNetto.DisplayFormat.FormatString = "n2";
            this.colMieteNetto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMieteNetto.FieldName = "Miete";
            this.colMieteNetto.Name = "colMieteNetto";
            this.colMieteNetto.Visible = true;
            this.colMieteNetto.VisibleIndex = 4;
            this.colMieteNetto.Width = 90;
            // 
            // colNebenkosten
            // 
            this.colNebenkosten.AppearanceHeader.Options.UseTextOptions = true;
            this.colNebenkosten.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colNebenkosten.Caption = "Miete Anteil";
            this.colNebenkosten.DisplayFormat.FormatString = "n2";
            this.colNebenkosten.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colNebenkosten.FieldName = "MieteAnteil";
            this.colNebenkosten.Name = "colNebenkosten";
            this.colNebenkosten.Visible = true;
            this.colNebenkosten.VisibleIndex = 5;
            this.colNebenkosten.Width = 90;
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDatumBis.DataMember = "DatumBis";
            this.edtDatumBis.DataSource = this.qryBaWohnsituation;
            this.edtDatumBis.EditMode = Kiss.Interfaces.UI.EditModeType.Optional;
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(245, 236);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.LightCyan;
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
            this.edtDatumBis.Properties.Name = "kissDateEdit2.Properties";
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBis.TabIndex = 1;
            // 
            // edtWohnsituation
            // 
            this.edtWohnsituation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtWohnsituation.DataMember = "WohnsituationCode";
            this.edtWohnsituation.DataSource = this.qryBaWohnsituation;
            this.edtWohnsituation.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtWohnsituation.Location = new System.Drawing.Point(103, 266);
            this.edtWohnsituation.LOVName = "BaWohnstatus";
            this.edtWohnsituation.Name = "edtWohnsituation";
            this.edtWohnsituation.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtWohnsituation.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWohnsituation.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWohnsituation.Properties.Appearance.Options.UseBackColor = true;
            this.edtWohnsituation.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWohnsituation.Properties.Appearance.Options.UseFont = true;
            this.edtWohnsituation.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtWohnsituation.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtWohnsituation.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtWohnsituation.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtWohnsituation.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtWohnsituation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtWohnsituation.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtWohnsituation.Properties.NullText = "";
            this.edtWohnsituation.Properties.ShowFooter = false;
            this.edtWohnsituation.Properties.ShowHeader = false;
            this.edtWohnsituation.Size = new System.Drawing.Size(242, 24);
            this.edtWohnsituation.TabIndex = 2;
            // 
            // edtWohnungsgroesse
            // 
            this.edtWohnungsgroesse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtWohnungsgroesse.DataMember = "WohnungsgroesseCode";
            this.edtWohnungsgroesse.DataSource = this.qryBaWohnsituation;
            this.edtWohnungsgroesse.EditMode = Kiss.Interfaces.UI.EditModeType.Optional;
            this.edtWohnungsgroesse.Location = new System.Drawing.Point(103, 296);
            this.edtWohnungsgroesse.LOVName = "BaWohnungsgroesse";
            this.edtWohnungsgroesse.Name = "edtWohnungsgroesse";
            this.edtWohnungsgroesse.Properties.Appearance.BackColor = System.Drawing.Color.LightCyan;
            this.edtWohnungsgroesse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWohnungsgroesse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWohnungsgroesse.Properties.Appearance.Options.UseBackColor = true;
            this.edtWohnungsgroesse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWohnungsgroesse.Properties.Appearance.Options.UseFont = true;
            this.edtWohnungsgroesse.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtWohnungsgroesse.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtWohnungsgroesse.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtWohnungsgroesse.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtWohnungsgroesse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtWohnungsgroesse.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtWohnungsgroesse.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtWohnungsgroesse.Properties.NullText = "";
            this.edtWohnungsgroesse.Properties.ShowFooter = false;
            this.edtWohnungsgroesse.Properties.ShowHeader = false;
            this.edtWohnungsgroesse.Size = new System.Drawing.Size(242, 24);
            this.edtWohnungsgroesse.TabIndex = 3;
            // 
            // grdBaWohnsituationPerson
            // 
            this.grdBaWohnsituationPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grdBaWohnsituationPerson.DataSource = this.qryBaWohnsituationPerson;
            // 
            // 
            // 
            this.grdBaWohnsituationPerson.EmbeddedNavigator.Name = "";
            this.grdBaWohnsituationPerson.Location = new System.Drawing.Point(103, 326);
            this.grdBaWohnsituationPerson.MainView = this.grvBaWohnsituationPerson;
            this.grdBaWohnsituationPerson.Name = "grdBaWohnsituationPerson";
            this.grdBaWohnsituationPerson.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.colchkIstInHaushalt});
            this.grdBaWohnsituationPerson.Size = new System.Drawing.Size(242, 187);
            this.grdBaWohnsituationPerson.TabIndex = 4;
            this.grdBaWohnsituationPerson.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBaWohnsituationPerson});
            // 
            // qryBaWohnsituationPerson
            // 
            this.qryBaWohnsituationPerson.BatchUpdate = true;
            this.qryBaWohnsituationPerson.CanUpdate = true;
            this.qryBaWohnsituationPerson.HostControl = this;
            this.qryBaWohnsituationPerson.SelectStatement = resources.GetString("qryBaWohnsituationPerson.SelectStatement");
            this.qryBaWohnsituationPerson.ColumnChanged += new System.Data.DataColumnChangeEventHandler(this.qryBaWohnsituationPerson_ColumnChanged);
            // 
            // grvBaWohnsituationPerson
            // 
            this.grvBaWohnsituationPerson.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBaWohnsituationPerson.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWohnsituationPerson.Appearance.Empty.Options.UseBackColor = true;
            this.grvBaWohnsituationPerson.Appearance.Empty.Options.UseFont = true;
            this.grvBaWohnsituationPerson.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvBaWohnsituationPerson.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWohnsituationPerson.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvBaWohnsituationPerson.Appearance.EvenRow.Options.UseFont = true;
            this.grvBaWohnsituationPerson.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.grvBaWohnsituationPerson.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWohnsituationPerson.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvBaWohnsituationPerson.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBaWohnsituationPerson.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBaWohnsituationPerson.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBaWohnsituationPerson.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvBaWohnsituationPerson.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWohnsituationPerson.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.grvBaWohnsituationPerson.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBaWohnsituationPerson.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBaWohnsituationPerson.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBaWohnsituationPerson.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaWohnsituationPerson.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBaWohnsituationPerson.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaWohnsituationPerson.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWohnsituationPerson.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBaWohnsituationPerson.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBaWohnsituationPerson.Appearance.GroupRow.Options.UseFont = true;
            this.grvBaWohnsituationPerson.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBaWohnsituationPerson.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBaWohnsituationPerson.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBaWohnsituationPerson.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWohnsituationPerson.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBaWohnsituationPerson.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBaWohnsituationPerson.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBaWohnsituationPerson.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvBaWohnsituationPerson.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWohnsituationPerson.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBaWohnsituationPerson.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBaWohnsituationPerson.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBaWohnsituationPerson.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBaWohnsituationPerson.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.grvBaWohnsituationPerson.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBaWohnsituationPerson.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWohnsituationPerson.Appearance.OddRow.Options.UseFont = true;
            this.grvBaWohnsituationPerson.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.grvBaWohnsituationPerson.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWohnsituationPerson.Appearance.Row.Options.UseBackColor = true;
            this.grvBaWohnsituationPerson.Appearance.Row.Options.UseFont = true;
            this.grvBaWohnsituationPerson.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvBaWohnsituationPerson.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWohnsituationPerson.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvBaWohnsituationPerson.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvBaWohnsituationPerson.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBaWohnsituationPerson.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvBaWohnsituationPerson.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.grvBaWohnsituationPerson.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBaWohnsituationPerson.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBaWohnsituationPerson.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPerson,
            this.colGleicherHaushalt});
            this.grvBaWohnsituationPerson.GridControl = this.grdBaWohnsituationPerson;
            this.grvBaWohnsituationPerson.Name = "grvBaWohnsituationPerson";
            this.grvBaWohnsituationPerson.OptionsCustomization.AllowFilter = false;
            this.grvBaWohnsituationPerson.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBaWohnsituationPerson.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBaWohnsituationPerson.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvBaWohnsituationPerson.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.grvBaWohnsituationPerson.OptionsSelection.UseIndicatorForSelection = false;
            this.grvBaWohnsituationPerson.OptionsView.ColumnAutoWidth = false;
            this.grvBaWohnsituationPerson.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBaWohnsituationPerson.OptionsView.ShowGroupPanel = false;
            this.grvBaWohnsituationPerson.OptionsView.ShowIndicator = false;
            // 
            // colPerson
            // 
            this.colPerson.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colPerson.AppearanceCell.Options.UseBackColor = true;
            this.colPerson.Caption = "Person";
            this.colPerson.FieldName = "PersonName";
            this.colPerson.Name = "colPerson";
            this.colPerson.OptionsColumn.AllowEdit = false;
            this.colPerson.OptionsColumn.AllowFocus = false;
            this.colPerson.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.colPerson.OptionsColumn.ReadOnly = true;
            this.colPerson.Visible = true;
            this.colPerson.VisibleIndex = 0;
            this.colPerson.Width = 153;
            // 
            // colGleicherHaushalt
            // 
            this.colGleicherHaushalt.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colGleicherHaushalt.AppearanceCell.Options.UseBackColor = true;
            this.colGleicherHaushalt.Caption = "gl. Haush.";
            this.colGleicherHaushalt.ColumnEdit = this.colchkIstInHaushalt;
            this.colGleicherHaushalt.FieldName = "IstInWohnung";
            this.colGleicherHaushalt.Name = "colGleicherHaushalt";
            this.colGleicherHaushalt.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.colGleicherHaushalt.Visible = true;
            this.colGleicherHaushalt.VisibleIndex = 1;
            this.colGleicherHaushalt.Width = 64;
            // 
            // colchkIstInHaushalt
            // 
            this.colchkIstInHaushalt.AutoHeight = false;
            this.colchkIstInHaushalt.Name = "colchkIstInHaushalt";
            // 
            // edtVermieter
            // 
            this.edtVermieter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtVermieter.DataMember = "Name";
            this.edtVermieter.DataSource = this.qryBaWohnsituation;
            this.edtVermieter.EditMode = Kiss.Interfaces.UI.EditModeType.Optional;
            this.edtVermieter.Location = new System.Drawing.Point(475, 266);
            this.edtVermieter.Name = "edtVermieter";
            this.edtVermieter.Properties.Appearance.BackColor = System.Drawing.Color.LightCyan;
            this.edtVermieter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVermieter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVermieter.Properties.Appearance.Options.UseBackColor = true;
            this.edtVermieter.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVermieter.Properties.Appearance.Options.UseFont = true;
            this.edtVermieter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtVermieter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtVermieter.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVermieter.Properties.Name = "kissButtonEdit1.Properties";
            this.edtVermieter.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtVermieter.Size = new System.Drawing.Size(232, 24);
            this.edtVermieter.TabIndex = 5;
            this.edtVermieter.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtVermieter_UserModifiedFld);
            // 
            // edtMiete
            // 
            this.edtMiete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtMiete.DataMember = "Miete";
            this.edtMiete.DataSource = this.qryBaWohnsituation;
            this.edtMiete.EditMode = Kiss.Interfaces.UI.EditModeType.Optional;
            this.edtMiete.Location = new System.Drawing.Point(475, 320);
            this.edtMiete.Name = "edtMiete";
            this.edtMiete.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtMiete.Properties.Appearance.BackColor = System.Drawing.Color.LightCyan;
            this.edtMiete.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMiete.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMiete.Properties.Appearance.Options.UseBackColor = true;
            this.edtMiete.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMiete.Properties.Appearance.Options.UseFont = true;
            this.edtMiete.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMiete.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtMiete.Properties.DisplayFormat.FormatString = "N2";
            this.edtMiete.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtMiete.Properties.EditFormat.FormatString = "N2";
            this.edtMiete.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtMiete.Properties.Name = "kissCalcEdit1.Properties";
            this.edtMiete.Size = new System.Drawing.Size(85, 24);
            this.edtMiete.TabIndex = 6;
            // 
            // edtMieteAnteil
            // 
            this.edtMieteAnteil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtMieteAnteil.DataMember = "MieteAnteil";
            this.edtMieteAnteil.DataSource = this.qryBaWohnsituation;
            this.edtMieteAnteil.EditMode = Kiss.Interfaces.UI.EditModeType.Optional;
            this.edtMieteAnteil.Location = new System.Drawing.Point(596, 320);
            this.edtMieteAnteil.Name = "edtMieteAnteil";
            this.edtMieteAnteil.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtMieteAnteil.Properties.Appearance.BackColor = System.Drawing.Color.LightCyan;
            this.edtMieteAnteil.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMieteAnteil.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMieteAnteil.Properties.Appearance.Options.UseBackColor = true;
            this.edtMieteAnteil.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMieteAnteil.Properties.Appearance.Options.UseFont = true;
            this.edtMieteAnteil.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMieteAnteil.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtMieteAnteil.Properties.DisplayFormat.FormatString = "N2";
            this.edtMieteAnteil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtMieteAnteil.Properties.EditFormat.FormatString = "N2";
            this.edtMieteAnteil.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtMieteAnteil.Size = new System.Drawing.Size(85, 24);
            this.edtMieteAnteil.TabIndex = 7;
            // 
            // edtNebenkosten
            // 
            this.edtNebenkosten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtNebenkosten.DataMember = "Nebenkosten";
            this.edtNebenkosten.DataSource = this.qryBaWohnsituation;
            this.edtNebenkosten.Location = new System.Drawing.Point(475, 350);
            this.edtNebenkosten.Name = "edtNebenkosten";
            this.edtNebenkosten.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtNebenkosten.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNebenkosten.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNebenkosten.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNebenkosten.Properties.Appearance.Options.UseBackColor = true;
            this.edtNebenkosten.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNebenkosten.Properties.Appearance.Options.UseFont = true;
            this.edtNebenkosten.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNebenkosten.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNebenkosten.Properties.DisplayFormat.FormatString = "N2";
            this.edtNebenkosten.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtNebenkosten.Properties.EditFormat.FormatString = "N2";
            this.edtNebenkosten.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtNebenkosten.Properties.Name = "kissCalcEdit2.Properties";
            this.edtNebenkosten.Size = new System.Drawing.Size(85, 24);
            this.edtNebenkosten.TabIndex = 8;
            // 
            // edtNebenkostenAnteil
            // 
            this.edtNebenkostenAnteil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtNebenkostenAnteil.DataMember = "NebenkostenAnteil";
            this.edtNebenkostenAnteil.DataSource = this.qryBaWohnsituation;
            this.edtNebenkostenAnteil.Location = new System.Drawing.Point(596, 350);
            this.edtNebenkostenAnteil.Name = "edtNebenkostenAnteil";
            this.edtNebenkostenAnteil.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtNebenkostenAnteil.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNebenkostenAnteil.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNebenkostenAnteil.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNebenkostenAnteil.Properties.Appearance.Options.UseBackColor = true;
            this.edtNebenkostenAnteil.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNebenkostenAnteil.Properties.Appearance.Options.UseFont = true;
            this.edtNebenkostenAnteil.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNebenkostenAnteil.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNebenkostenAnteil.Properties.DisplayFormat.FormatString = "N2";
            this.edtNebenkostenAnteil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtNebenkostenAnteil.Properties.EditFormat.FormatString = "N2";
            this.edtNebenkostenAnteil.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtNebenkostenAnteil.Properties.Name = "kissCalcEdit2.Properties";
            this.edtNebenkostenAnteil.Size = new System.Drawing.Size(85, 24);
            this.edtNebenkostenAnteil.TabIndex = 9;
            // 
            // edtSicherheitsleistungArt
            // 
            this.edtSicherheitsleistungArt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSicherheitsleistungArt.DataMember = "SicherheitsleistungArtCode";
            this.edtSicherheitsleistungArt.DataSource = this.qryBaWohnsituation;
            this.edtSicherheitsleistungArt.EditMode = Kiss.Interfaces.UI.EditModeType.Optional;
            this.edtSicherheitsleistungArt.Location = new System.Drawing.Point(475, 429);
            this.edtSicherheitsleistungArt.LOVName = "BaMieteSicherheitsleistungArt";
            this.edtSicherheitsleistungArt.Name = "edtSicherheitsleistungArt";
            this.edtSicherheitsleistungArt.Properties.Appearance.BackColor = System.Drawing.Color.LightCyan;
            this.edtSicherheitsleistungArt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSicherheitsleistungArt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSicherheitsleistungArt.Properties.Appearance.Options.UseBackColor = true;
            this.edtSicherheitsleistungArt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSicherheitsleistungArt.Properties.Appearance.Options.UseFont = true;
            this.edtSicherheitsleistungArt.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSicherheitsleistungArt.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSicherheitsleistungArt.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSicherheitsleistungArt.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSicherheitsleistungArt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtSicherheitsleistungArt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtSicherheitsleistungArt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSicherheitsleistungArt.Properties.Name = "kissLookUpEdit1.Properties";
            this.edtSicherheitsleistungArt.Properties.NullText = "";
            this.edtSicherheitsleistungArt.Properties.ShowFooter = false;
            this.edtSicherheitsleistungArt.Properties.ShowHeader = false;
            this.edtSicherheitsleistungArt.Size = new System.Drawing.Size(232, 24);
            this.edtSicherheitsleistungArt.TabIndex = 10;
            // 
            // edtSicherheitsleistungBetrag
            // 
            this.edtSicherheitsleistungBetrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSicherheitsleistungBetrag.DataMember = "SicherheitsleistungBetrag";
            this.edtSicherheitsleistungBetrag.DataSource = this.qryBaWohnsituation;
            this.edtSicherheitsleistungBetrag.EditMode = Kiss.Interfaces.UI.EditModeType.Optional;
            this.edtSicherheitsleistungBetrag.Location = new System.Drawing.Point(475, 459);
            this.edtSicherheitsleistungBetrag.Name = "edtSicherheitsleistungBetrag";
            this.edtSicherheitsleistungBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSicherheitsleistungBetrag.Properties.Appearance.BackColor = System.Drawing.Color.LightCyan;
            this.edtSicherheitsleistungBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSicherheitsleistungBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSicherheitsleistungBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtSicherheitsleistungBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSicherheitsleistungBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtSicherheitsleistungBetrag.Properties.Appearance.Options.UseTextOptions = true;
            this.edtSicherheitsleistungBetrag.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.edtSicherheitsleistungBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSicherheitsleistungBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSicherheitsleistungBetrag.Properties.DisplayFormat.FormatString = "N2";
            this.edtSicherheitsleistungBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSicherheitsleistungBetrag.Properties.EditFormat.FormatString = "N2";
            this.edtSicherheitsleistungBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSicherheitsleistungBetrag.Properties.Name = "kissCalcEdit3.Properties";
            this.edtSicherheitsleistungBetrag.Size = new System.Drawing.Size(100, 24);
            this.edtSicherheitsleistungBetrag.TabIndex = 11;
            // 
            // edtSicherheitsleistungUebernahmen
            // 
            this.edtSicherheitsleistungUebernahmen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSicherheitsleistungUebernahmen.DataMember = "SicherheitsleistungUebernahmevonCode";
            this.edtSicherheitsleistungUebernahmen.DataSource = this.qryBaWohnsituation;
            this.edtSicherheitsleistungUebernahmen.EditMode = Kiss.Interfaces.UI.EditModeType.Optional;
            this.edtSicherheitsleistungUebernahmen.Location = new System.Drawing.Point(475, 489);
            this.edtSicherheitsleistungUebernahmen.LOVName = "BaMieteSicherheitsleistungUebernahmeDurch";
            this.edtSicherheitsleistungUebernahmen.Name = "edtSicherheitsleistungUebernahmen";
            this.edtSicherheitsleistungUebernahmen.Properties.Appearance.BackColor = System.Drawing.Color.LightCyan;
            this.edtSicherheitsleistungUebernahmen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSicherheitsleistungUebernahmen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSicherheitsleistungUebernahmen.Properties.Appearance.Options.UseBackColor = true;
            this.edtSicherheitsleistungUebernahmen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSicherheitsleistungUebernahmen.Properties.Appearance.Options.UseFont = true;
            this.edtSicherheitsleistungUebernahmen.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSicherheitsleistungUebernahmen.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSicherheitsleistungUebernahmen.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSicherheitsleistungUebernahmen.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSicherheitsleistungUebernahmen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtSicherheitsleistungUebernahmen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtSicherheitsleistungUebernahmen.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSicherheitsleistungUebernahmen.Properties.Name = "kissLookUpEdit3.Properties";
            this.edtSicherheitsleistungUebernahmen.Properties.NullText = "";
            this.edtSicherheitsleistungUebernahmen.Properties.ShowFooter = false;
            this.edtSicherheitsleistungUebernahmen.Properties.ShowHeader = false;
            this.edtSicherheitsleistungUebernahmen.Size = new System.Drawing.Size(232, 24);
            this.edtSicherheitsleistungUebernahmen.TabIndex = 12;
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryBaWohnsituation;
            this.edtBemerkung.Location = new System.Drawing.Point(103, 525);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Properties.MaxLength = 300;
            this.edtBemerkung.Properties.Name = "kissMemoEdit1.Properties";
            this.edtBemerkung.Size = new System.Drawing.Size(620, 42);
            this.edtBemerkung.TabIndex = 13;
            // 
            // lblVermieter
            // 
            this.lblVermieter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVermieter.Location = new System.Drawing.Point(367, 266);
            this.lblVermieter.Name = "lblVermieter";
            this.lblVermieter.Size = new System.Drawing.Size(105, 24);
            this.lblVermieter.TabIndex = 46;
            this.lblVermieter.Text = "Vermieter";
            this.lblVermieter.UseCompatibleTextRendering = true;
            // 
            // lblDatumVon
            // 
            this.lblDatumVon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDatumVon.Location = new System.Drawing.Point(5, 236);
            this.lblDatumVon.Name = "lblDatumVon";
            this.lblDatumVon.Size = new System.Drawing.Size(95, 24);
            this.lblDatumVon.TabIndex = 47;
            this.lblDatumVon.Text = "Dauer von";
            this.lblDatumVon.UseCompatibleTextRendering = true;
            // 
            // lblDatumBis
            // 
            this.lblDatumBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDatumBis.Location = new System.Drawing.Point(216, 236);
            this.lblDatumBis.Name = "lblDatumBis";
            this.lblDatumBis.Size = new System.Drawing.Size(22, 24);
            this.lblDatumBis.TabIndex = 48;
            this.lblDatumBis.Text = "bis";
            this.lblDatumBis.UseCompatibleTextRendering = true;
            // 
            // lblCHF2
            // 
            this.lblCHF2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCHF2.Location = new System.Drawing.Point(562, 320);
            this.lblCHF2.Name = "lblCHF2";
            this.lblCHF2.Size = new System.Drawing.Size(24, 24);
            this.lblCHF2.TabIndex = 55;
            this.lblCHF2.Text = "CHF";
            this.lblCHF2.UseCompatibleTextRendering = true;
            // 
            // lblCHF1
            // 
            this.lblCHF1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCHF1.Location = new System.Drawing.Point(683, 320);
            this.lblCHF1.Name = "lblCHF1";
            this.lblCHF1.Size = new System.Drawing.Size(24, 24);
            this.lblCHF1.TabIndex = 56;
            this.lblCHF1.Text = "CHF";
            this.lblCHF1.UseCompatibleTextRendering = true;
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBemerkung.Location = new System.Drawing.Point(5, 525);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(95, 24);
            this.lblBemerkung.TabIndex = 58;
            this.lblBemerkung.Text = "Bemerkung";
            this.lblBemerkung.UseCompatibleTextRendering = true;
            // 
            // lblSicherheitsleistung
            // 
            this.lblSicherheitsleistung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSicherheitsleistung.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblSicherheitsleistung.Location = new System.Drawing.Point(367, 404);
            this.lblSicherheitsleistung.Name = "lblSicherheitsleistung";
            this.lblSicherheitsleistung.Size = new System.Drawing.Size(136, 16);
            this.lblSicherheitsleistung.TabIndex = 62;
            this.lblSicherheitsleistung.Text = "Sicherheitsleistung";
            this.lblSicherheitsleistung.UseCompatibleTextRendering = true;
            // 
            // lblSIcherheitsleistungArt
            // 
            this.lblSIcherheitsleistungArt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSIcherheitsleistungArt.Location = new System.Drawing.Point(367, 429);
            this.lblSIcherheitsleistungArt.Name = "lblSIcherheitsleistungArt";
            this.lblSIcherheitsleistungArt.Size = new System.Drawing.Size(105, 24);
            this.lblSIcherheitsleistungArt.TabIndex = 63;
            this.lblSIcherheitsleistungArt.Text = "Art";
            this.lblSIcherheitsleistungArt.UseCompatibleTextRendering = true;
            // 
            // lblSicherheitsleistungBetrag
            // 
            this.lblSicherheitsleistungBetrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSicherheitsleistungBetrag.Location = new System.Drawing.Point(367, 459);
            this.lblSicherheitsleistungBetrag.Name = "lblSicherheitsleistungBetrag";
            this.lblSicherheitsleistungBetrag.Size = new System.Drawing.Size(105, 24);
            this.lblSicherheitsleistungBetrag.TabIndex = 64;
            this.lblSicherheitsleistungBetrag.Text = "Betrag";
            this.lblSicherheitsleistungBetrag.UseCompatibleTextRendering = true;
            // 
            // lblGesamtmiete
            // 
            this.lblGesamtmiete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGesamtmiete.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblGesamtmiete.Location = new System.Drawing.Point(475, 301);
            this.lblGesamtmiete.Name = "lblGesamtmiete";
            this.lblGesamtmiete.Size = new System.Drawing.Size(88, 16);
            this.lblGesamtmiete.TabIndex = 67;
            this.lblGesamtmiete.Text = "Gesamt";
            this.lblGesamtmiete.UseCompatibleTextRendering = true;
            // 
            // lblCHF3
            // 
            this.lblCHF3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCHF3.Location = new System.Drawing.Point(562, 350);
            this.lblCHF3.Name = "lblCHF3";
            this.lblCHF3.Size = new System.Drawing.Size(24, 24);
            this.lblCHF3.TabIndex = 69;
            this.lblCHF3.Text = "CHF";
            this.lblCHF3.UseCompatibleTextRendering = true;
            // 
            // lblMiete
            // 
            this.lblMiete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMiete.Location = new System.Drawing.Point(367, 320);
            this.lblMiete.Name = "lblMiete";
            this.lblMiete.Size = new System.Drawing.Size(105, 24);
            this.lblMiete.TabIndex = 70;
            this.lblMiete.Text = "Miete inkl. NK";
            this.lblMiete.UseCompatibleTextRendering = true;
            // 
            // lblNebenkosten
            // 
            this.lblNebenkosten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNebenkosten.Location = new System.Drawing.Point(367, 350);
            this.lblNebenkosten.Name = "lblNebenkosten";
            this.lblNebenkosten.Size = new System.Drawing.Size(105, 24);
            this.lblNebenkosten.TabIndex = 71;
            this.lblNebenkosten.Text = "davon Nebenkosten";
            this.lblNebenkosten.UseCompatibleTextRendering = true;
            // 
            // lblSicherheitsleistungUebernahmen
            // 
            this.lblSicherheitsleistungUebernahmen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSicherheitsleistungUebernahmen.Location = new System.Drawing.Point(367, 489);
            this.lblSicherheitsleistungUebernahmen.Name = "lblSicherheitsleistungUebernahmen";
            this.lblSicherheitsleistungUebernahmen.Size = new System.Drawing.Size(105, 24);
            this.lblSicherheitsleistungUebernahmen.TabIndex = 72;
            this.lblSicherheitsleistungUebernahmen.Text = "übernommen von";
            this.lblSicherheitsleistungUebernahmen.UseCompatibleTextRendering = true;
            // 
            // lblWohnsituation
            // 
            this.lblWohnsituation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblWohnsituation.Location = new System.Drawing.Point(5, 266);
            this.lblWohnsituation.Name = "lblWohnsituation";
            this.lblWohnsituation.Size = new System.Drawing.Size(95, 24);
            this.lblWohnsituation.TabIndex = 74;
            this.lblWohnsituation.Text = "Wohnsituation";
            this.lblWohnsituation.UseCompatibleTextRendering = true;
            // 
            // lblWohnungsgroesse
            // 
            this.lblWohnungsgroesse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblWohnungsgroesse.Location = new System.Drawing.Point(5, 296);
            this.lblWohnungsgroesse.Name = "lblWohnungsgroesse";
            this.lblWohnungsgroesse.Size = new System.Drawing.Size(95, 24);
            this.lblWohnungsgroesse.TabIndex = 75;
            this.lblWohnungsgroesse.Text = "Wohnungsgrösse";
            this.lblWohnungsgroesse.UseCompatibleTextRendering = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picTitel);
            this.panel1.Controls.Add(this.lblTitel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(729, 24);
            this.panel1.TabIndex = 79;
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
            this.lblTitel.Text = "Wohnsituation";
            this.lblTitel.UseCompatibleTextRendering = true;
            // 
            // lblHaushalt
            // 
            this.lblHaushalt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblHaushalt.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblHaushalt.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblHaushalt.Location = new System.Drawing.Point(5, 326);
            this.lblHaushalt.Name = "lblHaushalt";
            this.lblHaushalt.Size = new System.Drawing.Size(95, 35);
            this.lblHaushalt.TabIndex = 80;
            this.lblHaushalt.Text = "Personen im Haushalt";
            this.lblHaushalt.UseCompatibleTextRendering = true;
            // 
            // lblMietvertrag
            // 
            this.lblMietvertrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMietvertrag.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblMietvertrag.Location = new System.Drawing.Point(367, 244);
            this.lblMietvertrag.Name = "lblMietvertrag";
            this.lblMietvertrag.Size = new System.Drawing.Size(90, 16);
            this.lblMietvertrag.TabIndex = 82;
            this.lblMietvertrag.Text = "Mietvertrag";
            this.lblMietvertrag.UseCompatibleTextRendering = true;
            // 
            // kissLabel5
            // 
            this.kissLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel5.Location = new System.Drawing.Point(579, 459);
            this.kissLabel5.Name = "kissLabel5";
            this.kissLabel5.Size = new System.Drawing.Size(24, 24);
            this.kissLabel5.TabIndex = 83;
            this.kissLabel5.Text = "CHF";
            this.kissLabel5.UseCompatibleTextRendering = true;
            // 
            // kissLabel1
            // 
            this.kissLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel1.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel1.Location = new System.Drawing.Point(596, 301);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(88, 16);
            this.kissLabel1.TabIndex = 85;
            this.kissLabel1.Text = "Anteil";
            this.kissLabel1.UseCompatibleTextRendering = true;
            // 
            // kissLabel2
            // 
            this.kissLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel2.Location = new System.Drawing.Point(683, 350);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(24, 24);
            this.kissLabel2.TabIndex = 86;
            this.kissLabel2.Text = "CHF";
            this.kissLabel2.UseCompatibleTextRendering = true;
            // 
            // CtlBaWohnsituation
            // 
            this.ActiveSQLQuery = this.qryBaWohnsituation;
            this.Controls.Add(this.kissLabel2);
            this.Controls.Add(this.kissLabel1);
            this.Controls.Add(this.kissLabel5);
            this.Controls.Add(this.lblMietvertrag);
            this.Controls.Add(this.lblHaushalt);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblWohnungsgroesse);
            this.Controls.Add(this.lblWohnsituation);
            this.Controls.Add(this.lblSicherheitsleistungUebernahmen);
            this.Controls.Add(this.lblNebenkosten);
            this.Controls.Add(this.lblMiete);
            this.Controls.Add(this.lblCHF3);
            this.Controls.Add(this.lblGesamtmiete);
            this.Controls.Add(this.lblSicherheitsleistungBetrag);
            this.Controls.Add(this.lblSIcherheitsleistungArt);
            this.Controls.Add(this.lblSicherheitsleistung);
            this.Controls.Add(this.lblBemerkung);
            this.Controls.Add(this.lblCHF1);
            this.Controls.Add(this.lblCHF2);
            this.Controls.Add(this.lblDatumBis);
            this.Controls.Add(this.lblDatumVon);
            this.Controls.Add(this.lblVermieter);
            this.Controls.Add(this.edtBemerkung);
            this.Controls.Add(this.edtSicherheitsleistungUebernahmen);
            this.Controls.Add(this.edtSicherheitsleistungBetrag);
            this.Controls.Add(this.edtSicherheitsleistungArt);
            this.Controls.Add(this.edtNebenkostenAnteil);
            this.Controls.Add(this.edtNebenkosten);
            this.Controls.Add(this.edtMieteAnteil);
            this.Controls.Add(this.edtMiete);
            this.Controls.Add(this.edtVermieter);
            this.Controls.Add(this.grdBaWohnsituationPerson);
            this.Controls.Add(this.edtWohnungsgroesse);
            this.Controls.Add(this.edtWohnsituation);
            this.Controls.Add(this.edtDatumBis);
            this.Controls.Add(this.grdBaWohnsituation);
            this.Controls.Add(this.edtDatumVon);
            this.Location = new System.Drawing.Point(5, 0);
            this.Name = "CtlBaWohnsituation";
            this.Size = new System.Drawing.Size(729, 580);
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaWohnsituation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaWohnsituation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaWohnsituation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsituation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsituation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnungsgroesse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnungsgroesse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaWohnsituationPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaWohnsituationPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaWohnsituationPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colchkIstInHaushalt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVermieter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMiete.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMieteAnteil.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNebenkosten.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNebenkostenAnteil.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSicherheitsleistungArt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSicherheitsleistungArt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSicherheitsleistungBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSicherheitsleistungUebernahmen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSicherheitsleistungUebernahmen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVermieter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHF2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHF1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSicherheitsleistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSIcherheitsleistungArt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSicherheitsleistungBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGesamtmiete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHF3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMiete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNebenkosten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSicherheitsleistungUebernahmen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWohnsituation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWohnungsgroesse)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHaushalt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMietvertrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
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
    }
}