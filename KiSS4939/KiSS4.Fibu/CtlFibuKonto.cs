using System;
using System.Data;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Fibu
{
    /// <summary>
    /// Summary description for CtlFibuKonto.
    /// </summary>
    public class CtlFibuKonto : KiSS4.Gui.KissUserControl
    {
        private int BaPersonID = 0;
        private DevExpress.XtraGrid.Columns.GridColumn colBeleg;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colBis;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colDepotNr;
        private DevExpress.XtraGrid.Columns.GridColumn colEroeffnungssaldo;
        private DevExpress.XtraGrid.Columns.GridColumn colFbDTAZugangID;
        private DevExpress.XtraGrid.Columns.GridColumn colHaben;
        private DevExpress.XtraGrid.Columns.GridColumn colItemMandant;
        private DevExpress.XtraGrid.Columns.GridColumn colKontoTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colKtoNr;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colSaldoGruppeName;
        private DevExpress.XtraGrid.Columns.GridColumn colSaldoTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colSoll;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colTeam;
        private DevExpress.XtraGrid.Columns.GridColumn colText;
        private DevExpress.XtraGrid.Columns.GridColumn colVon;
        private System.ComponentModel.IContainer components;

        private KiSS4.Gui.KissButtonEdit editMandant;
        private KiSS4.Gui.KissTextEdit editMandantNr;
        private KiSS4.Gui.KissTextEdit editMT;
        private KiSS4.Gui.KissTextEdit editPlzOrt;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit grideditEZugang;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit grideditKontoTyp;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit grideditVorsaldo;
        private KiSS4.Gui.KissGrid gridKonten;
        private KiSS4.Gui.KissGrid gridPeriode;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewFields;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewMasks;
        private KissLabel kissLabel1;
        private KissLabel kissLabel10;
        private KissLabel kissLabel11;
        private KissLabel kissLabel12;
        private KissLabel kissLabel13;
        private KissLabel kissLabel14;
        private KissLabel kissLabel15;
        private KissLabel kissLabel16;
        private KissLabel kissLabel17;
        private KissLabel kissLabel18;
        private KissLabel kissLabel2;
        private KissLabel kissLabel3;
        private KissLabel kissLabel4;
        private KissLabel kissLabel5;
        private KissLabel kissLabel6;
        private KissLabel kissLabel7;
        private KissLabel kissLabel8;
        private KissLabel kissLabel9;
        private KiSS4.Gui.KissLabel label1;
        private KiSS4.Gui.KissLabel label10;
        private KiSS4.Gui.KissLabel label40;
        private KiSS4.Gui.KissLabel lblStandardKontenplan;
        private System.Windows.Forms.Panel panelGrid;

        // wenn 0: anzeigen des StandardKontoplans
        private SqlQuery qryEZugang;

        private KiSS4.DB.SqlQuery qryKonto;
        private KiSS4.DB.SqlQuery qryPeriode;
        private SharpLibrary.WinControls.TabPageEx tabAktiven;
        private SharpLibrary.WinControls.TabPageEx tabAufwand;
        private SharpLibrary.WinControls.TabPageEx tabErtrag;
        private KiSS4.Gui.KissTabControlEx tabKonten;
        private SharpLibrary.WinControls.TabPageEx tabPassiven;
        private int tabSelectedIndex = 0;
        private SharpLibrary.WinControls.TabPageEx tabSpezial;
        private System.Windows.Forms.Timer timer1;

        public CtlFibuKonto()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            panelGrid.Visible = BaPersonID != 0;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>

        private bool IsStandardKontenplan
        {
            get
            {
                return BaPersonID == 0;
            }
        }

        public override string GetContextName()
        {
            return "VmFibu";
        }

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryKonto = new KiSS4.DB.SqlQuery(this.components);
            this.gridViewMasks = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colItemMandant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeleg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoll = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHaben = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.editMandant = new KiSS4.Gui.KissButtonEdit();
            this.editMandantNr = new KiSS4.Gui.KissTextEdit();
            this.editPlzOrt = new KiSS4.Gui.KissTextEdit();
            this.label40 = new KiSS4.Gui.KissLabel();
            this.gridPeriode = new KiSS4.Gui.KissGrid();
            this.qryPeriode = new KiSS4.DB.SqlQuery(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTeam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaldoTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label10 = new KiSS4.Gui.KissLabel();
            this.editMT = new KiSS4.Gui.KissTextEdit();
            this.label1 = new KiSS4.Gui.KissLabel();
            this.tabKonten = new KiSS4.Gui.KissTabControlEx();
            this.tabAktiven = new SharpLibrary.WinControls.TabPageEx();
            this.gridKonten = new KiSS4.Gui.KissGrid();
            this.gridViewFields = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKtoNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEroeffnungssaldo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grideditVorsaldo = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.colKontoTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grideditKontoTyp = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colSaldoGruppeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFbDTAZugangID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grideditEZugang = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colDepotNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.kissLabel17 = new KiSS4.Gui.KissLabel();
            this.kissLabel18 = new KiSS4.Gui.KissLabel();
            this.kissLabel15 = new KiSS4.Gui.KissLabel();
            this.kissLabel16 = new KiSS4.Gui.KissLabel();
            this.kissLabel13 = new KiSS4.Gui.KissLabel();
            this.kissLabel14 = new KiSS4.Gui.KissLabel();
            this.kissLabel11 = new KiSS4.Gui.KissLabel();
            this.kissLabel12 = new KiSS4.Gui.KissLabel();
            this.kissLabel9 = new KiSS4.Gui.KissLabel();
            this.kissLabel10 = new KiSS4.Gui.KissLabel();
            this.kissLabel8 = new KiSS4.Gui.KissLabel();
            this.kissLabel7 = new KiSS4.Gui.KissLabel();
            this.kissLabel6 = new KiSS4.Gui.KissLabel();
            this.kissLabel5 = new KiSS4.Gui.KissLabel();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.tabSpezial = new SharpLibrary.WinControls.TabPageEx();
            this.tabPassiven = new SharpLibrary.WinControls.TabPageEx();
            this.tabAufwand = new SharpLibrary.WinControls.TabPageEx();
            this.tabErtrag = new SharpLibrary.WinControls.TabPageEx();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblStandardKontenplan = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qryKonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMasks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editMandant.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editMandantNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPlzOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPeriode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPeriode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editMT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            this.tabKonten.SuspendLayout();
            this.tabAktiven.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridKonten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grideditVorsaldo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grideditKontoTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grideditEZugang)).BeginInit();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStandardKontenplan)).BeginInit();
            this.SuspendLayout();
            // 
            // qryKonto
            // 
            this.qryKonto.CanDelete = true;
            this.qryKonto.CanInsert = true;
            this.qryKonto.CanUpdate = true;
            this.qryKonto.HostControl = this;
            this.qryKonto.IsIdentityInsert = false;
            this.qryKonto.TableName = "FbKonto";
            this.qryKonto.AfterInsert += new System.EventHandler(this.qryKonto_AfterInsert);
            this.qryKonto.AfterPost += new System.EventHandler(this.qryKonto_AfterPost);
            this.qryKonto.BeforeDelete += new System.EventHandler(this.qryKonto_BeforeDelete);
            this.qryKonto.BeforePost += new System.EventHandler(this.qryKonto_BeforePost);
            this.qryKonto.ColumnChanged += new System.Data.DataColumnChangeEventHandler(this.qryKonto_ColumnChanged);
            // 
            // gridViewMasks
            // 
            this.gridViewMasks.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colItemMandant,
            this.colBeleg,
            this.colDatum,
            this.colSoll,
            this.colHaben,
            this.colText,
            this.colBetrag});
            this.gridViewMasks.Name = "gridViewMasks";
            this.gridViewMasks.ViewStyles.AddReplace("FocusedCell", "FocusedRow");
            this.gridViewMasks.ViewStyles.AddReplace("SelectedRow", "Row");
            this.gridViewMasks.ViewStyles.AddReplace("HideSelectionRow", "SelectedRow");
            // 
            // colItemMandant
            // 
            this.colItemMandant.Caption = "Mandant";
            this.colItemMandant.FieldName = "Mandant";
            this.colItemMandant.Name = "colItemMandant";
            this.colItemMandant.Visible = true;
            this.colItemMandant.VisibleIndex = 0;
            this.colItemMandant.Width = 147;
            // 
            // colBeleg
            // 
            this.colBeleg.Caption = "Beleg";
            this.colBeleg.FieldName = "BelegNr";
            this.colBeleg.Name = "colBeleg";
            this.colBeleg.Visible = true;
            this.colBeleg.VisibleIndex = 1;
            this.colBeleg.Width = 70;
            // 
            // colDatum
            // 
            this.colDatum.Caption = "Datum";
            this.colDatum.FieldName = "DatumBuchung";
            this.colDatum.Name = "colDatum";
            this.colDatum.Visible = true;
            this.colDatum.VisibleIndex = 2;
            this.colDatum.Width = 92;
            // 
            // colSoll
            // 
            this.colSoll.Caption = "Soll";
            this.colSoll.FieldName = "KontoNrS";
            this.colSoll.Name = "colSoll";
            this.colSoll.Visible = true;
            this.colSoll.VisibleIndex = 3;
            this.colSoll.Width = 56;
            // 
            // colHaben
            // 
            this.colHaben.Caption = "Haben";
            this.colHaben.FieldName = "KontoNrH";
            this.colHaben.Name = "colHaben";
            this.colHaben.Visible = true;
            this.colHaben.VisibleIndex = 4;
            this.colHaben.Width = 57;
            // 
            // colText
            // 
            this.colText.Caption = "Text";
            this.colText.FieldName = "Text";
            this.colText.Name = "colText";
            this.colText.Visible = true;
            this.colText.VisibleIndex = 5;
            this.colText.Width = 230;
            // 
            // colBetrag
            // 
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.DisplayFormat.FormatString = "N";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.FieldName = "Betrag";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 6;
            this.colBetrag.Width = 109;
            // 
            // editMandant
            // 
            this.editMandant.Location = new System.Drawing.Point(80, 20);
            this.editMandant.Name = "editMandant";
            this.editMandant.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editMandant.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editMandant.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editMandant.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.editMandant.Properties.Appearance.Options.UseBackColor = true;
            this.editMandant.Properties.Appearance.Options.UseBorderColor = true;
            this.editMandant.Properties.Appearance.Options.UseFont = true;
            this.editMandant.Properties.Appearance.Options.UseForeColor = true;
            this.editMandant.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.editMandant.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.editMandant.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editMandant.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.editMandant.Size = new System.Drawing.Size(205, 24);
            this.editMandant.TabIndex = 0;
            this.editMandant.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.editMandant_UserModifiedFld);
            // 
            // editMandantNr
            // 
            this.editMandantNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editMandantNr.Location = new System.Drawing.Point(295, 20);
            this.editMandantNr.Name = "editMandantNr";
            this.editMandantNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editMandantNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editMandantNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editMandantNr.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.editMandantNr.Properties.Appearance.Options.UseBackColor = true;
            this.editMandantNr.Properties.Appearance.Options.UseBorderColor = true;
            this.editMandantNr.Properties.Appearance.Options.UseFont = true;
            this.editMandantNr.Properties.Appearance.Options.UseForeColor = true;
            this.editMandantNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editMandantNr.Properties.ReadOnly = true;
            this.editMandantNr.Size = new System.Drawing.Size(70, 24);
            this.editMandantNr.TabIndex = 283;
            this.editMandantNr.TabStop = false;
            // 
            // editPlzOrt
            // 
            this.editPlzOrt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editPlzOrt.Location = new System.Drawing.Point(80, 55);
            this.editPlzOrt.Name = "editPlzOrt";
            this.editPlzOrt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editPlzOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editPlzOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editPlzOrt.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.editPlzOrt.Properties.Appearance.Options.UseBackColor = true;
            this.editPlzOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.editPlzOrt.Properties.Appearance.Options.UseFont = true;
            this.editPlzOrt.Properties.Appearance.Options.UseForeColor = true;
            this.editPlzOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editPlzOrt.Properties.ReadOnly = true;
            this.editPlzOrt.Size = new System.Drawing.Size(285, 24);
            this.editPlzOrt.TabIndex = 274;
            this.editPlzOrt.TabStop = false;
            // 
            // label40
            // 
            this.label40.ForeColor = System.Drawing.Color.Black;
            this.label40.Location = new System.Drawing.Point(15, 20);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(63, 24);
            this.label40.TabIndex = 262;
            this.label40.Text = "Mandant";
            // 
            // gridPeriode
            // 
            this.gridPeriode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridPeriode.DataSource = this.qryPeriode;
            // 
            // 
            // 
            this.gridPeriode.EmbeddedNavigator.Name = "";
            this.gridPeriode.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.gridPeriode.ImeMode = System.Windows.Forms.ImeMode.On;
            this.gridPeriode.Location = new System.Drawing.Point(385, 20);
            this.gridPeriode.MainView = this.gridView2;
            this.gridPeriode.Name = "gridPeriode";
            this.gridPeriode.Size = new System.Drawing.Size(425, 110);
            this.gridPeriode.TabIndex = 1;
            this.gridPeriode.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // qryPeriode
            // 
            this.qryPeriode.CanUpdate = true;
            this.qryPeriode.HostControl = this;
            this.qryPeriode.IsIdentityInsert = false;
            this.qryPeriode.TableName = "FbPeriode";
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
            this.gridView2.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.gridView2.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.OddRow.Options.UseBackColor = true;
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
            this.colStatus,
            this.colTeam,
            this.colSaldoTotal});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView2.GridControl = this.gridPeriode;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsCustomization.AllowFilter = false;
            this.gridView2.OptionsCustomization.AllowGroup = false;
            this.gridView2.OptionsFilter.AllowFilterEditor = false;
            this.gridView2.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView2.OptionsMenu.EnableColumnMenu = false;
            this.gridView2.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView2.OptionsNavigation.AutoMoveRowFocus = false;
            this.gridView2.OptionsNavigation.EnterMoveNextColumn = true;
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
            this.colStatus.FieldName = "StatusText";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 2;
            this.colStatus.Width = 98;
            // 
            // colTeam
            // 
            this.colTeam.Caption = "Team";
            this.colTeam.FieldName = "Team";
            this.colTeam.Name = "colTeam";
            this.colTeam.Visible = true;
            this.colTeam.VisibleIndex = 3;
            this.colTeam.Width = 78;
            // 
            // colSaldoTotal
            // 
            this.colSaldoTotal.Caption = "Saldototal";
            this.colSaldoTotal.DisplayFormat.FormatString = "N2";
            this.colSaldoTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSaldoTotal.FieldName = "SaldoTotal";
            this.colSaldoTotal.Name = "colSaldoTotal";
            this.colSaldoTotal.Visible = true;
            this.colSaldoTotal.VisibleIndex = 4;
            this.colSaldoTotal.Width = 70;
            // 
            // label10
            // 
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(15, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 24);
            this.label10.TabIndex = 286;
            this.label10.Text = "M.Träger";
            // 
            // editMT
            // 
            this.editMT.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editMT.Location = new System.Drawing.Point(80, 78);
            this.editMT.Name = "editMT";
            this.editMT.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editMT.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editMT.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editMT.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.editMT.Properties.Appearance.Options.UseBackColor = true;
            this.editMT.Properties.Appearance.Options.UseBorderColor = true;
            this.editMT.Properties.Appearance.Options.UseFont = true;
            this.editMT.Properties.Appearance.Options.UseForeColor = true;
            this.editMT.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editMT.Properties.ReadOnly = true;
            this.editMT.Size = new System.Drawing.Size(285, 24);
            this.editMT.TabIndex = 285;
            this.editMT.TabStop = false;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(15, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 24);
            this.label1.TabIndex = 287;
            this.label1.Text = "Ort";
            // 
            // tabKonten
            // 
            this.tabKonten.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabKonten.Controls.Add(this.tabAktiven);
            this.tabKonten.Controls.Add(this.tabSpezial);
            this.tabKonten.Controls.Add(this.tabPassiven);
            this.tabKonten.Controls.Add(this.tabAufwand);
            this.tabKonten.Controls.Add(this.tabErtrag);
            this.tabKonten.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabKonten.Location = new System.Drawing.Point(15, 135);
            this.tabKonten.Name = "tabKonten";
            this.tabKonten.ShowFixedWidthTooltip = true;
            this.tabKonten.Size = new System.Drawing.Size(795, 325);
            this.tabKonten.TabIndex = 2;
            this.tabKonten.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tabAktiven,
            this.tabPassiven,
            this.tabAufwand,
            this.tabErtrag,
            this.tabSpezial});
            this.tabKonten.TabsLineColor = System.Drawing.Color.Black;
            this.tabKonten.TabsLocation = SharpLibrary.WinControls.TabsLocation.Top;
            this.tabKonten.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabKonten.TabStop = false;
            this.tabKonten.Text = "xTabControl2";
            this.tabKonten.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabKonten_SelectedTabChanged);
            // 
            // tabAktiven
            // 
            this.tabAktiven.Controls.Add(this.gridKonten);
            this.tabAktiven.Controls.Add(this.panelGrid);
            this.tabAktiven.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.tabAktiven.Location = new System.Drawing.Point(6, 32);
            this.tabAktiven.Name = "tabAktiven";
            this.tabAktiven.Size = new System.Drawing.Size(783, 287);
            this.tabAktiven.TabIndex = 0;
            this.tabAktiven.Title = "Aktiven";
            // 
            // gridKonten
            // 
            this.gridKonten.DataSource = this.qryKonto;
            this.gridKonten.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.gridKonten.EmbeddedNavigator.Name = "";
            this.gridKonten.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.gridKonten.ImeMode = System.Windows.Forms.ImeMode.On;
            this.gridKonten.Location = new System.Drawing.Point(0, 0);
            this.gridKonten.MainView = this.gridViewFields;
            this.gridKonten.Name = "gridKonten";
            this.gridKonten.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.grideditKontoTyp,
            this.grideditEZugang,
            this.grideditVorsaldo});
            this.gridKonten.Size = new System.Drawing.Size(783, 200);
            this.gridKonten.TabIndex = 6;
            this.gridKonten.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewFields});
            // 
            // gridViewFields
            // 
            this.gridViewFields.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridViewFields.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridViewFields.Appearance.Empty.Options.UseBackColor = true;
            this.gridViewFields.Appearance.Empty.Options.UseFont = true;
            this.gridViewFields.Appearance.EvenRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gridViewFields.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridViewFields.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridViewFields.Appearance.EvenRow.Options.UseFont = true;
            this.gridViewFields.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.gridViewFields.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridViewFields.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridViewFields.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridViewFields.Appearance.FocusedCell.Options.UseFont = true;
            this.gridViewFields.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridViewFields.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gridViewFields.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridViewFields.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gridViewFields.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridViewFields.Appearance.FocusedRow.Options.UseFont = true;
            this.gridViewFields.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridViewFields.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.gridViewFields.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.gridViewFields.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridViewFields.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridViewFields.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridViewFields.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridViewFields.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridViewFields.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridViewFields.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridViewFields.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridViewFields.Appearance.GroupRow.Options.UseFont = true;
            this.gridViewFields.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridViewFields.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridViewFields.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridViewFields.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridViewFields.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridViewFields.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridViewFields.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewFields.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gridViewFields.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridViewFields.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridViewFields.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridViewFields.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridViewFields.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridViewFields.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.gridViewFields.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridViewFields.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.gridViewFields.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridViewFields.Appearance.OddRow.Options.UseBackColor = true;
            this.gridViewFields.Appearance.OddRow.Options.UseFont = true;
            this.gridViewFields.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.gridViewFields.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridViewFields.Appearance.Row.Options.UseBackColor = true;
            this.gridViewFields.Appearance.Row.Options.UseFont = true;
            this.gridViewFields.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gridViewFields.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridViewFields.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridViewFields.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridViewFields.Appearance.SelectedRow.Options.UseFont = true;
            this.gridViewFields.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridViewFields.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.gridViewFields.Appearance.VertLine.Options.UseBackColor = true;
            this.gridViewFields.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridViewFields.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKtoNr,
            this.colName,
            this.colEroeffnungssaldo,
            this.colKontoTyp,
            this.colSaldoGruppeName,
            this.colFbDTAZugangID,
            this.colDepotNr});
            this.gridViewFields.GridControl = this.gridKonten;
            this.gridViewFields.Name = "gridViewFields";
            this.gridViewFields.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp;
            this.gridViewFields.OptionsCustomization.AllowFilter = false;
            this.gridViewFields.OptionsCustomization.AllowGroup = false;
            this.gridViewFields.OptionsFilter.AllowFilterEditor = false;
            this.gridViewFields.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridViewFields.OptionsMenu.EnableColumnMenu = false;
            this.gridViewFields.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewFields.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewFields.OptionsView.ColumnAutoWidth = false;
            this.gridViewFields.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridViewFields.OptionsView.ShowGroupPanel = false;
            this.gridViewFields.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridViewFields_RowCellStyle);
            this.gridViewFields.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gridViewFields_ShowingEditor);
            // 
            // colKtoNr
            // 
            this.colKtoNr.Caption = "Nr";
            this.colKtoNr.FieldName = "KontoNr";
            this.colKtoNr.Name = "colKtoNr";
            this.colKtoNr.Visible = true;
            this.colKtoNr.VisibleIndex = 0;
            this.colKtoNr.Width = 58;
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "KontoName";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 250;
            // 
            // colEroeffnungssaldo
            // 
            this.colEroeffnungssaldo.Caption = "Vorsaldo";
            this.colEroeffnungssaldo.ColumnEdit = this.grideditVorsaldo;
            this.colEroeffnungssaldo.DisplayFormat.FormatString = "N2";
            this.colEroeffnungssaldo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colEroeffnungssaldo.FieldName = "EroeffnungsSaldo";
            this.colEroeffnungssaldo.Name = "colEroeffnungssaldo";
            this.colEroeffnungssaldo.Visible = true;
            this.colEroeffnungssaldo.VisibleIndex = 2;
            // 
            // grideditVorsaldo
            // 
            this.grideditVorsaldo.AutoHeight = false;
            this.grideditVorsaldo.DisplayFormat.FormatString = "N2";
            this.grideditVorsaldo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.grideditVorsaldo.EditFormat.FormatString = "N2";
            this.grideditVorsaldo.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.grideditVorsaldo.Name = "grideditVorsaldo";
            // 
            // colKontoTyp
            // 
            this.colKontoTyp.Caption = "Kontotyp";
            this.colKontoTyp.ColumnEdit = this.grideditKontoTyp;
            this.colKontoTyp.FieldName = "KontoTypCode";
            this.colKontoTyp.Name = "colKontoTyp";
            this.colKontoTyp.Visible = true;
            this.colKontoTyp.VisibleIndex = 3;
            this.colKontoTyp.Width = 102;
            // 
            // grideditKontoTyp
            // 
            this.grideditKontoTyp.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grideditKontoTyp.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grideditKontoTyp.AppearanceDropDown.Options.UseBackColor = true;
            this.grideditKontoTyp.AppearanceDropDown.Options.UseFont = true;
            this.grideditKontoTyp.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.grideditKontoTyp.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.grideditKontoTyp.DisplayMember = "Text";
            this.grideditKontoTyp.Name = "grideditKontoTyp";
            this.grideditKontoTyp.NullText = "";
            this.grideditKontoTyp.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Flat;
            this.grideditKontoTyp.PopupSizeable = false;
            this.grideditKontoTyp.PopupWidth = 112;
            this.grideditKontoTyp.ShowFooter = false;
            this.grideditKontoTyp.ShowHeader = false;
            this.grideditKontoTyp.ValueMember = "Code";
            // 
            // colSaldoGruppeName
            // 
            this.colSaldoGruppeName.Caption = "Saldogruppe";
            this.colSaldoGruppeName.DisplayFormat.FormatString = "N0";
            this.colSaldoGruppeName.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSaldoGruppeName.FieldName = "SaldoGruppeName";
            this.colSaldoGruppeName.Name = "colSaldoGruppeName";
            this.colSaldoGruppeName.Visible = true;
            this.colSaldoGruppeName.VisibleIndex = 4;
            this.colSaldoGruppeName.Width = 100;
            // 
            // colFbDTAZugangID
            // 
            this.colFbDTAZugangID.Caption = "e-Zugang";
            this.colFbDTAZugangID.ColumnEdit = this.grideditEZugang;
            this.colFbDTAZugangID.FieldName = "FbDTAZugangID";
            this.colFbDTAZugangID.Name = "colFbDTAZugangID";
            this.colFbDTAZugangID.Visible = true;
            this.colFbDTAZugangID.VisibleIndex = 5;
            this.colFbDTAZugangID.Width = 126;
            // 
            // grideditEZugang
            // 
            this.grideditEZugang.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grideditEZugang.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grideditEZugang.AppearanceDropDown.Options.UseBackColor = true;
            this.grideditEZugang.AppearanceDropDown.Options.UseFont = true;
            this.grideditEZugang.AutoHeight = false;
            this.grideditEZugang.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.grideditEZugang.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F5);
            this.grideditEZugang.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name")});
            this.grideditEZugang.DisplayMember = "Name";
            this.grideditEZugang.DropDownRows = 8;
            this.grideditEZugang.Name = "grideditEZugang";
            this.grideditEZugang.NullText = "";
            this.grideditEZugang.PopupWidth = 126;
            this.grideditEZugang.ShowFooter = false;
            this.grideditEZugang.ShowHeader = false;
            this.grideditEZugang.ValueMember = "FbDTAZugangID";
            // 
            // colDepotNr
            // 
            this.colDepotNr.Caption = "Depotnummer";
            this.colDepotNr.FieldName = "FbDepotNr";
            this.colDepotNr.Name = "colDepotNr";
            this.colDepotNr.Visible = true;
            this.colDepotNr.VisibleIndex = 6;
            this.colDepotNr.Width = 100;
            // 
            // panelGrid
            // 
            this.panelGrid.Controls.Add(this.kissLabel17);
            this.panelGrid.Controls.Add(this.kissLabel18);
            this.panelGrid.Controls.Add(this.kissLabel15);
            this.panelGrid.Controls.Add(this.kissLabel16);
            this.panelGrid.Controls.Add(this.kissLabel13);
            this.panelGrid.Controls.Add(this.kissLabel14);
            this.panelGrid.Controls.Add(this.kissLabel11);
            this.panelGrid.Controls.Add(this.kissLabel12);
            this.panelGrid.Controls.Add(this.kissLabel9);
            this.panelGrid.Controls.Add(this.kissLabel10);
            this.panelGrid.Controls.Add(this.kissLabel8);
            this.panelGrid.Controls.Add(this.kissLabel7);
            this.panelGrid.Controls.Add(this.kissLabel6);
            this.panelGrid.Controls.Add(this.kissLabel5);
            this.panelGrid.Controls.Add(this.kissLabel3);
            this.panelGrid.Controls.Add(this.kissLabel2);
            this.panelGrid.Controls.Add(this.kissLabel1);
            this.panelGrid.Controls.Add(this.kissLabel4);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelGrid.Location = new System.Drawing.Point(0, 200);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(783, 87);
            this.panelGrid.TabIndex = 7;
            // 
            // kissLabel17
            // 
            this.kissLabel17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel17.ForeColor = System.Drawing.Color.Black;
            this.kissLabel17.Location = new System.Drawing.Point(649, 27);
            this.kissLabel17.Name = "kissLabel17";
            this.kissLabel17.Size = new System.Drawing.Size(122, 24);
            this.kissLabel17.TabIndex = 294;
            this.kissLabel17.Text = "Vorsaldo-Mutation";
            // 
            // kissLabel18
            // 
            this.kissLabel18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel18.ForeColor = System.Drawing.Color.Black;
            this.kissLabel18.Location = new System.Drawing.Point(649, 3);
            this.kissLabel18.Name = "kissLabel18";
            this.kissLabel18.Size = new System.Drawing.Size(122, 24);
            this.kissLabel18.TabIndex = 293;
            this.kissLabel18.Text = "Betrag der letzten";
            // 
            // kissLabel15
            // 
            this.kissLabel15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel15.ForeColor = System.Drawing.Color.Black;
            this.kissLabel15.Location = new System.Drawing.Point(521, 27);
            this.kissLabel15.Name = "kissLabel15";
            this.kissLabel15.Size = new System.Drawing.Size(122, 24);
            this.kissLabel15.TabIndex = 292;
            this.kissLabel15.Text = "Vorsaldo-Mutation";
            // 
            // kissLabel16
            // 
            this.kissLabel16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel16.ForeColor = System.Drawing.Color.Black;
            this.kissLabel16.Location = new System.Drawing.Point(521, 3);
            this.kissLabel16.Name = "kissLabel16";
            this.kissLabel16.Size = new System.Drawing.Size(122, 24);
            this.kissLabel16.TabIndex = 291;
            this.kissLabel16.Text = "Benutzer der letzten";
            // 
            // kissLabel13
            // 
            this.kissLabel13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel13.ForeColor = System.Drawing.Color.Black;
            this.kissLabel13.Location = new System.Drawing.Point(394, 27);
            this.kissLabel13.Name = "kissLabel13";
            this.kissLabel13.Size = new System.Drawing.Size(122, 24);
            this.kissLabel13.TabIndex = 290;
            this.kissLabel13.Text = "Vorsaldo-Mutation";
            // 
            // kissLabel14
            // 
            this.kissLabel14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel14.ForeColor = System.Drawing.Color.Black;
            this.kissLabel14.Location = new System.Drawing.Point(394, 3);
            this.kissLabel14.Name = "kissLabel14";
            this.kissLabel14.Size = new System.Drawing.Size(122, 24);
            this.kissLabel14.TabIndex = 289;
            this.kissLabel14.Text = "Datum der letzten";
            // 
            // kissLabel11
            // 
            this.kissLabel11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel11.ForeColor = System.Drawing.Color.Black;
            this.kissLabel11.Location = new System.Drawing.Point(270, 27);
            this.kissLabel11.Name = "kissLabel11";
            this.kissLabel11.Size = new System.Drawing.Size(122, 24);
            this.kissLabel11.TabIndex = 288;
            this.kissLabel11.Text = "Ersterfassung";
            // 
            // kissLabel12
            // 
            this.kissLabel12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel12.ForeColor = System.Drawing.Color.Black;
            this.kissLabel12.Location = new System.Drawing.Point(270, 3);
            this.kissLabel12.Name = "kissLabel12";
            this.kissLabel12.Size = new System.Drawing.Size(122, 24);
            this.kissLabel12.TabIndex = 287;
            this.kissLabel12.Text = "Betrag der Vorsaldo-";
            // 
            // kissLabel9
            // 
            this.kissLabel9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel9.ForeColor = System.Drawing.Color.Black;
            this.kissLabel9.Location = new System.Drawing.Point(142, 27);
            this.kissLabel9.Name = "kissLabel9";
            this.kissLabel9.Size = new System.Drawing.Size(122, 24);
            this.kissLabel9.TabIndex = 286;
            this.kissLabel9.Text = "Ersterfassung";
            // 
            // kissLabel10
            // 
            this.kissLabel10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel10.ForeColor = System.Drawing.Color.Black;
            this.kissLabel10.Location = new System.Drawing.Point(142, 3);
            this.kissLabel10.Name = "kissLabel10";
            this.kissLabel10.Size = new System.Drawing.Size(122, 24);
            this.kissLabel10.TabIndex = 285;
            this.kissLabel10.Text = "Benutzer der Vorsaldo-";
            // 
            // kissLabel8
            // 
            this.kissLabel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel8.ForeColor = System.Drawing.Color.Black;
            this.kissLabel8.Location = new System.Drawing.Point(14, 27);
            this.kissLabel8.Name = "kissLabel8";
            this.kissLabel8.Size = new System.Drawing.Size(122, 24);
            this.kissLabel8.TabIndex = 284;
            this.kissLabel8.Text = "Ersterfassung";
            // 
            // kissLabel7
            // 
            this.kissLabel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel7.ForeColor = System.Drawing.Color.Black;
            this.kissLabel7.Location = new System.Drawing.Point(14, 3);
            this.kissLabel7.Name = "kissLabel7";
            this.kissLabel7.Size = new System.Drawing.Size(122, 24);
            this.kissLabel7.TabIndex = 283;
            this.kissLabel7.Text = "Datum der Vorsaldo-";
            // 
            // kissLabel6
            // 
            this.kissLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel6.DataMember = "EroeffnungsSaldoNowTxt";
            this.kissLabel6.DataSource = this.qryKonto;
            this.kissLabel6.ForeColor = System.Drawing.Color.Black;
            this.kissLabel6.Location = new System.Drawing.Point(649, 51);
            this.kissLabel6.Name = "kissLabel6";
            this.kissLabel6.Size = new System.Drawing.Size(122, 24);
            this.kissLabel6.TabIndex = 282;
            // 
            // kissLabel5
            // 
            this.kissLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel5.DataMember = "EroeffnungsSaldoModifier";
            this.kissLabel5.DataSource = this.qryKonto;
            this.kissLabel5.ForeColor = System.Drawing.Color.Black;
            this.kissLabel5.Location = new System.Drawing.Point(521, 51);
            this.kissLabel5.Name = "kissLabel5";
            this.kissLabel5.Size = new System.Drawing.Size(122, 24);
            this.kissLabel5.TabIndex = 281;
            // 
            // kissLabel3
            // 
            this.kissLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel3.DataMember = "EroeffnungsSaldoModified";
            this.kissLabel3.DataSource = this.qryKonto;
            this.kissLabel3.ForeColor = System.Drawing.Color.Black;
            this.kissLabel3.Location = new System.Drawing.Point(394, 51);
            this.kissLabel3.Name = "kissLabel3";
            this.kissLabel3.Size = new System.Drawing.Size(122, 24);
            this.kissLabel3.TabIndex = 280;
            // 
            // kissLabel2
            // 
            this.kissLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel2.DataMember = "EroeffnungsSaldo_AtCreationTxt";
            this.kissLabel2.DataSource = this.qryKonto;
            this.kissLabel2.ForeColor = System.Drawing.Color.Black;
            this.kissLabel2.Location = new System.Drawing.Point(267, 51);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(122, 24);
            this.kissLabel2.TabIndex = 279;
            // 
            // kissLabel1
            // 
            this.kissLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel1.DataMember = "EroeffnungsSaldoCreator";
            this.kissLabel1.DataSource = this.qryKonto;
            this.kissLabel1.ForeColor = System.Drawing.Color.Black;
            this.kissLabel1.Location = new System.Drawing.Point(142, 51);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(122, 24);
            this.kissLabel1.TabIndex = 278;
            // 
            // kissLabel4
            // 
            this.kissLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel4.DataMember = "EroeffnungsSaldoCreated";
            this.kissLabel4.DataSource = this.qryKonto;
            this.kissLabel4.ForeColor = System.Drawing.Color.Black;
            this.kissLabel4.Location = new System.Drawing.Point(14, 51);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(122, 24);
            this.kissLabel4.TabIndex = 266;
            // 
            // tabSpezial
            // 
            this.tabSpezial.Location = new System.Drawing.Point(6, 32);
            this.tabSpezial.Name = "tabSpezial";
            this.tabSpezial.Size = new System.Drawing.Size(783, 287);
            this.tabSpezial.TabIndex = 4;
            this.tabSpezial.Title = "Spezial";
            // 
            // tabPassiven
            // 
            this.tabPassiven.Location = new System.Drawing.Point(6, 32);
            this.tabPassiven.Name = "tabPassiven";
            this.tabPassiven.Size = new System.Drawing.Size(783, 287);
            this.tabPassiven.TabIndex = 1;
            this.tabPassiven.Title = "Passiven";
            this.tabPassiven.Visible = false;
            // 
            // tabAufwand
            // 
            this.tabAufwand.Location = new System.Drawing.Point(6, 32);
            this.tabAufwand.Name = "tabAufwand";
            this.tabAufwand.Size = new System.Drawing.Size(783, 287);
            this.tabAufwand.TabIndex = 2;
            this.tabAufwand.Title = "Aufwand";
            this.tabAufwand.Visible = false;
            // 
            // tabErtrag
            // 
            this.tabErtrag.Location = new System.Drawing.Point(6, 32);
            this.tabErtrag.Name = "tabErtrag";
            this.tabErtrag.Size = new System.Drawing.Size(783, 287);
            this.tabErtrag.TabIndex = 3;
            this.tabErtrag.Title = "Ertrag";
            this.tabErtrag.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblStandardKontenplan
            // 
            this.lblStandardKontenplan.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblStandardKontenplan.ForeColor = System.Drawing.Color.Black;
            this.lblStandardKontenplan.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblStandardKontenplan.Location = new System.Drawing.Point(445, 95);
            this.lblStandardKontenplan.Name = "lblStandardKontenplan";
            this.lblStandardKontenplan.Size = new System.Drawing.Size(219, 24);
            this.lblStandardKontenplan.TabIndex = 288;
            this.lblStandardKontenplan.Text = "Standard-Kontenplan";
            this.lblStandardKontenplan.Visible = false;
            // 
            // CtlFibuKonto
            // 
            this.ActiveSQLQuery = this.qryKonto;
            this.Controls.Add(this.lblStandardKontenplan);
            this.Controls.Add(this.tabKonten);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.editMT);
            this.Controls.Add(this.gridPeriode);
            this.Controls.Add(this.editMandant);
            this.Controls.Add(this.editMandantNr);
            this.Controls.Add(this.editPlzOrt);
            this.Controls.Add(this.label40);
            this.Name = "CtlFibuKonto";
            this.Size = new System.Drawing.Size(825, 475);
            this.Load += new System.EventHandler(this.ctlFibuKonto_Load);
            this.Enter += new System.EventHandler(this.CtlFibuKonto_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.qryKonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMasks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editMandant.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editMandantNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPlzOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPeriode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPeriode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editMT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            this.tabKonten.ResumeLayout(false);
            this.tabAktiven.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridKonten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFields)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grideditVorsaldo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grideditKontoTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grideditEZugang)).EndInit();
            this.panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStandardKontenplan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private bool AllowRowEdit(int RowHandle)
        {
            // Depot/Wertschriften-Konti nur editierbar, wenn User Depotberechtigung hat
            DataRow row = gridKonten.View.GetDataRow(RowHandle);
            if ((int)row["KontoTypCode"] == 4 || (int)row["KontoTypCode"] == 5) //Wertschriften/Depot-Konti
            {
                return CtlFibu.DepotBereich((int)qryPeriode["FbTeamID"]);
            }
            return true;
        }

        private void CheckPeriodeActiv()
        {
            if (DBUtil.IsEmpty(qryPeriode["FbPeriodeID"])) return;

            //Periodenstatus könnte geändert haben: Deshalb nochmals prüfen ob Periode aktiv
            int status = 1;
            try
            {
                status = (int)DBUtil.ExecuteScalarSQL(@"SELECT PeriodeStatusCode
                                                        FROM FbPeriode
                                                        WHERE FbPeriodeID = {0}", qryPeriode["FbPeriodeID"]);
            }
            catch { }

            if (status != 1)
            {
                KissMsg.ShowInfo("CtlFibuKonto", "PeriodeNichtAktiv", "Die Periode ist nicht (mehr) aktiv. Deshalb ist keine Veränderung am Kontenplan möglich!");
                throw new Exception();
            }
        }

        private void CtlFibuKonto_Enter(object sender, System.EventArgs e)
        {
            qryEZugang.Refresh();
        }

        private void ctlFibuKonto_Load(object sender, System.EventArgs e)
        {
            lblStandardKontenplan.Location = gridPeriode.Location;

            SqlQuery qry = DBUtil.OpenSQL(@"SELECT Code, Text
                                            FROM   XLOVCode
				                            WHERE  LOVName = 'FbKontoTyp'
				                            ORDER  BY SortKey");

            grideditKontoTyp.DataSource = qry;
            grideditKontoTyp.DropDownRows = Math.Min(qry.Count, 7);

            qryEZugang = DBUtil.OpenSQL(@"SELECT FbDTAZugangID, Name
				                          FROM   FbDTAZugang
				                          UNION SELECT NULL, ''
				                          ORDER BY 2");

            grideditEZugang.DataSource = qryEZugang;
            grideditEZugang.DropDownRows = Math.Min(qry.Count, 7);

            ShowPerioden();
        }

        private void editMandant_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.MandantSuchenB(editMandant.Text, e.ButtonClicked);
            if (!e.Cancel)
            {
                panelGrid.Visible = !DBUtil.IsEmpty(dlg["BaPersonID"]);
                if (DBUtil.IsEmpty(dlg["BaPersonID"]))
                    BaPersonID = 0;
                else
                    BaPersonID = (int)dlg["BaPersonID"];

                editMandantNr.Text = dlg["BaPersonID"].ToString();
                editMandant.Text = dlg["Mandant"].ToString();
                editPlzOrt.Text = dlg["PLZOrt"].ToString();
                editMT.Text = dlg["MTName"].ToString();
                ShowPerioden();
            }
        }

        private int GetKontoKlasse()
        {
            switch (tabKonten.SelectedTabIndex)
            {
                case 0: return 1;
                case 1: return 2;
                case 2: return 3;
                case 3: return 4;
                case 4: return 9;
            }
            return 0;
        }

        private void gridViewFields_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (gridKonten.GridStyle != GridStyleType.Editable) return;
            if (BaPersonID == 0) return; //Standardkontenplan

            if (!AllowRowEdit(e.RowHandle) && gridKonten.Styles["RowDepotKonto"] != null)
            {
                e.Appearance.Assign(gridKonten.Styles["RowDepotKonto"].ToAppearance());
            }
        }

        private void gridViewFields_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (BaPersonID == 0) return; //Standardkontenplan
            e.Cancel = !AllowRowEdit(gridKonten.View.FocusedRowHandle);
        }

        private void qryKonto_AfterInsert(object sender, System.EventArgs e)
        {
            qryKonto["FbPeriodeID"] = (BaPersonID == 0) ? DBNull.Value : qryPeriode["FbPeriodeID"];
            qryKonto["KontoKlasseCode"] = GetKontoKlasse();
            qryKonto["KontoTypCode"] = 1; // Normal
            qryKonto["EroeffnungsSaldo"] = 0F;

            gridKonten.View.FocusedColumn = gridKonten.View.Columns["KontoNr"];
            timer1.Enabled = true;
        }

        private void qryKonto_AfterPost(object sender, System.EventArgs e)
        {
            if (BaPersonID == 0) return;

            SqlQuery qry = DBUtil.OpenSQL(@"SELECT SaldoTotal = ISNULL(SUM(ISNULL(EroeffnungsSaldo, 0)), 0)
                                            FROM   FbKonto
                                            WHERE  FbPeriodeID = {0}", qryPeriode["FbPeriodeID"]);

            qryPeriode["SaldoTotal"] = qry["SaldoTotal"];
            if (!DBUtil.IsEmpty(qryKonto["EroeffnungsSaldoModified"]))
            {
                qryKonto["EroeffnungsSaldoNow"] = qryKonto["EroeffnungsSaldo"];
            }
            if (qryKonto["EroeffnungsSaldo_AtCreation"] is decimal)
            {
                qryKonto["EroeffnungsSaldo_AtCreationTxt"] = ((decimal)qryKonto["EroeffnungsSaldo_AtCreation"]).ToString("F2");
            }
            if (qryKonto["EroeffnungsSaldoNow"] is decimal)
            {
                qryKonto["EroeffnungsSaldoNowTxt"] = ((decimal)qryKonto["EroeffnungsSaldoNow"]).ToString("F2");
            }
        }

        private void qryKonto_BeforeDelete(object sender, System.EventArgs e)
        {
            CheckPeriodeActiv();
        }

        private void qryKonto_BeforePost(object sender, System.EventArgs e)
        {
            CheckPeriodeActiv();

            DBUtil.CheckNotNullFieldInGrid(qryKonto, "KontoTypCode", KissMsg.GetMLMessage("CtlFibuKonto", "Typ", "Typ"));
            DBUtil.CheckNotNullFieldInGrid(qryKonto, "KontoNr", KissMsg.GetMLMessage("CtlFibuKonto", "Nr", "Nr"));
            DBUtil.CheckNotNullFieldInGrid(qryKonto, "KontoName", KissMsg.GetMLMessage("CtlFibuKonto", "Name", "Name"));
            if (!IsStandardKontenplan)
            {
                // Der erste Eroeffnungssaldo wird gesetzt, sobald der Saldo das erste mal <> 0 ist (Bei Altdaten mit Saldo <> 0 wird er nie gesetzt).
                // Der letzte Vorsaldo wird gesetzt, falls sich der Eroeffnungssaldo ändert.
                if (qryKonto.Row.RowState == DataRowState.Added ||
                    qryKonto.Row.RowState != DataRowState.Added && qryKonto.ColumnModified("EroeffnungsSaldo") && ((decimal)qryKonto["EroeffnungsSaldo", DataRowVersion.Original]) == 0 &&
                    DBUtil.IsEmpty(qryKonto["EroeffnungsSaldo_AtCreation"]) && DBUtil.IsEmpty(qryKonto["EroeffnungsSaldoModified"]) && DBUtil.IsEmpty(qryKonto["EroeffnungsSaldoCreator"]))
                {
                    qryKonto["EroeffnungsSaldoCreator"] = DBUtil.GetDBRowCreatorModifier();
                    qryKonto["EroeffnungsSaldoCreated"] = DateTime.Now;
                    qryKonto["EroeffnungsSaldo_AtCreation"] = qryKonto["EroeffnungsSaldo"];
                }
                else if (qryKonto.Row.RowState != DataRowState.Added && qryKonto.ColumnModified("EroeffnungsSaldo"))
                {
                    qryKonto["EroeffnungsSaldoModifier"] = DBUtil.GetDBRowCreatorModifier();
                    qryKonto["EroeffnungsSaldoModified"] = DateTime.Now;
                }
            }
        }

        private void qryKonto_ColumnChanged(object sender, System.Data.DataColumnChangeEventArgs e)
        {
            qryPeriode.RowModified = true;
        }

        private void qryPeriode_PositionChanged(object sender, System.EventArgs e)
        {
            ShowKonten();
        }

        private void ShowKonten()
        {
            //Eröffnungssaldo nur sichtbar, wenn Mandant ausgewählt und Aktiv/Passiv-Konten
            if (BaPersonID == 0 || tabKonten.SelectedTabIndex > 1)
                colEroeffnungssaldo.VisibleIndex = -1;
            else
                colEroeffnungssaldo.VisibleIndex = 2;

            if (BaPersonID == 0)
            {
                //StandardKontoPlan
                qryKonto.Fill(@"SELECT FbPeriodeID,
                                       FbKontoID,
                                       FbKontoTS,
                                       KontoNr,
                                       KontoName,
                                       KontoKlasseCode,
                                       SaldoGruppeName,
                                       EroeffnungsSaldo,
                                       KontoTypCode,
                                       FbDTAZugangID,
                                       FbDepotNr,
                                       EroeffnungsSaldoCreator,
                                       EroeffnungsSaldoModified,
                                       EroeffnungsSaldoModifier,
                                       EroeffnungsSaldoCreated,
                                       EroeffnungsSaldo_AtCreation,
                                       EroeffnungsSaldoNow = CASE WHEN EroeffnungsSaldoModified IS NULL THEN NULL ELSE EroeffnungsSaldo END,
                                       EroeffnungsSaldo_AtCreationTxt = CONVERT(varchar(20), EroeffnungsSaldo_AtCreation, 0),
                                       EroeffnungsSaldoNowTxt = CONVERT(varchar(20), CASE WHEN EroeffnungsSaldoModified IS NULL THEN NULL ELSE EroeffnungsSaldo END, 0)
                                FROM   FbKonto
					            WHERE  FbPeriodeID IS NULL
					              AND  KontoKlasseCode = {0}
					            ORDER  BY KontoNr", GetKontoKlasse());

                // Standarkontenplan nur durch Administrator editierbar
                if (Session.User.IsUserAdmin)
                {
                    gridKonten.GridStyle = KiSS4.Gui.GridStyleType.Editable;
                    qryKonto.CanInsert = true;
                    qryKonto.CanDelete = true;
                    qryKonto.CanUpdate = true;
                }
                else
                {
                    gridKonten.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
                    qryKonto.CanInsert = false;
                    qryKonto.CanDelete = false;
                    qryKonto.CanUpdate = false;
                }
            }
            else
            {
                qryKonto.Fill(@"SELECT FbPeriodeID,
                                       FbKontoID,
                                       FbKontoTS,
                                       KontoNr,
                                       KontoName,
                                       KontoKlasseCode,
                                       SaldoGruppeName,
                                       EroeffnungsSaldo,
                                       KontoTypCode,
                                       FbDTAZugangID,
                                       FbDepotNr,
                                       EroeffnungsSaldoCreator,
                                       EroeffnungsSaldoModified,
                                       EroeffnungsSaldoModifier,
                                       EroeffnungsSaldoCreated,
                                       EroeffnungsSaldo_AtCreation,
                                       EroeffnungsSaldoNow = CASE WHEN EroeffnungsSaldoModified IS NULL THEN NULL ELSE EroeffnungsSaldo END,
                                       EroeffnungsSaldo_AtCreationTxt = CONVERT(varchar(20), EroeffnungsSaldo_AtCreation, 0),
                                       EroeffnungsSaldoNowTxt = CONVERT(varchar(20), CASE WHEN EroeffnungsSaldoModified IS NULL THEN NULL ELSE EroeffnungsSaldo END, 0)
                                FROM   FbKonto
					            WHERE  FbPeriodeID = {0}
					              AND  KontoKlasseCode = {1}
					            ORDER  BY KontoNr", (int)qryPeriode["FbPeriodeID"], GetKontoKlasse());

                // Konten nur editierbar, wenn Periode aktiv und User Teammitglied ist
                int? periodeStatusCode = qryPeriode["PeriodeStatusCode"] as int?;
                int? fbTeamId = qryPeriode["FbTeamID"] as int?;

                if (periodeStatusCode.HasValue && periodeStatusCode.Value == 1
                    && fbTeamId.HasValue && CtlFibu.UserIsMemberOfTeam(fbTeamId.Value))
                {
                    qryKonto.CanInsert = true;
                    qryKonto.CanDelete = true;
                    qryKonto.CanUpdate = true;
                    qryKonto.ApplyUserRights();
                    if (qryKonto.CanUpdate)
                        gridKonten.GridStyle = KiSS4.Gui.GridStyleType.Editable;
                    else
                        gridKonten.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
                }
                else
                {
                    gridKonten.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
                    qryKonto.CanInsert = false;
                    qryKonto.CanDelete = false;
                    qryKonto.CanUpdate = false;
                }
            }

            if (tabKonten.SelectedTabIndex != 0)
            {
                colFbDTAZugangID.VisibleIndex = -1;
                colDepotNr.VisibleIndex = -1;
            }
            else
            {
                colFbDTAZugangID.VisibleIndex = 5;
                colDepotNr.VisibleIndex = 6;
            }
        }

        private void ShowPerioden()
        {
            gridPeriode.Visible = (BaPersonID != 0);
            lblStandardKontenplan.Visible = (BaPersonID == 0);

            qryPeriode.Fill(@"
                SELECT PER.FbPeriodeID,
                       PER.FbTeamID,
                       PER.PeriodeStatusCode,
                       PER.PeriodeVon,
                       PER.PeriodeBis,
                       STA.Text StatusText,
                       TEA.Name Team,
				       SaldoTotal = (SELECT ISNULL(SUM(ISNULL(EroeffnungsSaldo,0)),0)
                                     FROM FbKonto
				                     WHERE FbPeriodeID = PER.FbPeriodeID)
				FROM   FbPeriode      PER
				  INNER JOIN XLOVCode STA ON STA.Code = PER.PeriodeStatusCode AND
				                             STA.LOVName = 'FbPeriodeStatus'
				  LEFT  JOIN FbTeam   TEA ON TEA.FbTeamID = PER.FbTeamID
				WHERE PER.BaPersonID = {0}
				ORDER BY PER.PeriodeVon DESC", BaPersonID);

            ShowKonten();
        }

        private void tabKonten_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            if (!qryKonto.Post())
            {
                tabKonten.SelectedTabChanged -= new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(tabKonten_SelectedTabChanged);
                tabKonten.SelectedTabIndex = tabSelectedIndex;
                tabKonten.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(tabKonten_SelectedTabChanged);
            }
            else
            {
                tabSelectedIndex = tabKonten.SelectedTabIndex;
                gridKonten.Parent = tabKonten.SelectedTab;
                panelGrid.Parent = tabKonten.SelectedTab;
                // Anzeige Vorsaldo
                panelGrid.Visible = (page == tabAktiven || page == tabPassiven) && BaPersonID != 0;
                ShowKonten();
            }
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            gridKonten.View.ShowEditor();
            timer1.Enabled = false;
        }
    }
}