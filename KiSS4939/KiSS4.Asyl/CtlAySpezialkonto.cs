using System;
using System.Data;
using System.Drawing;

using KiSS4.DB;

namespace KiSS4.Asyl
{
    public class CtlAySpezialkonto : KiSS4.Gui.KissUserControl
    {
        #region Fields

        #region Private Fields

        private BgSpezkontoTyp BgSpezkontoTypCode = 0;
        private bool DialogMode = false;
        private int FaLeistungID = 0;
        private object InitBelastung = null;
        private object InitName = null;
        private object InitStartSaldo = null;
        private Decimal Saldo = 0;
        private DevExpress.XtraGrid.Columns.GridColumn colBetragBelastung;
        private DevExpress.XtraGrid.Columns.GridColumn colBetragGutschrift;
        private DevExpress.XtraGrid.Columns.GridColumn colBetragProMonat;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumBis;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colFreigegeben;
        private DevExpress.XtraGrid.Columns.GridColumn colMonat;
        private DevExpress.XtraGrid.Columns.GridColumn colNameSpezkonto;
        private DevExpress.XtraGrid.Columns.GridColumn colSaldo;
        private DevExpress.XtraGrid.Columns.GridColumn colSaldo2;
        private DevExpress.XtraGrid.Columns.GridColumn colStartSaldo;
        private DevExpress.XtraGrid.Columns.GridColumn colText;
        private DevExpress.XtraGrid.Columns.GridColumn colVerbucht;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissMemoEdit edtBemerkung;
        private KiSS4.Gui.KissCalcEdit edtBetragProMonat;
        private KiSS4.Gui.KissLookUpEdit edtBgKostenartID;
        private KiSS4.Gui.KissCalcEdit edtDatumBisJahr;
        private KiSS4.Gui.KissLookUpEdit edtDatumBisMonat;
        private KiSS4.Gui.KissCalcEdit edtDatumVonJahr;
        private KiSS4.Gui.KissLookUpEdit edtDatumVonMonat;
        private KiSS4.Gui.KissTextEdit edtNameSpezkonto;
        private KiSS4.Gui.KissCheckEdit edtOhneEinzelzahlung;
        private KiSS4.Gui.KissCalcEdit edtStartSaldo;
        private KiSS4.Gui.KissGrid grdBgPosition;
        private KiSS4.Gui.KissGrid grdBgSpezkonto;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBgPosition;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBgSpezkonto;
        private System.Windows.Forms.ImageList imagelist1;
        private KiSS4.Gui.KissLabel kissLabel4;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblBetragProMonat;
        private KiSS4.Gui.KissLabel lblCHF1;
        private KiSS4.Gui.KissLabel lblCHF2;
        private KiSS4.Gui.KissLabel lblDatumBis;
        private KiSS4.Gui.KissLabel lblDatumVon;
        private KiSS4.Gui.KissLabel lblNameSpezkonto;
        private KiSS4.Gui.KissLabel lblStartSaldo;
        private KiSS4.Gui.KissLabel lblTitel;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryBgPosition;
        private KiSS4.DB.SqlQuery qryBgSpezkonto;

        #endregion

        #endregion

        #region Constructors

        public CtlAySpezialkonto()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent call
        }

        /// TODO titel text?
        // Used in CtlAyEinzelzahlung to display in a DlgKissUsercontrol
        public CtlAySpezialkonto(BgSpezkontoTyp BgSpezkontoTypCode, int faLeistungID, object InitName, object InitStartSaldo, object InitBelastung)
            : this(null, "Abzahlungskonto", BgSpezkontoTypCode, faLeistungID)
        {
            this.DialogMode = true;
            this.InitName = InitName;
            this.InitStartSaldo = InitStartSaldo;
            this.InitBelastung = InitBelastung;
        }

        public CtlAySpezialkonto(Image titelImage, string titelText, BgSpezkontoTyp BgSpezkontoTypCode, int faLeistungID)
            : this()
        {
            this.picTitel.Image = titelImage;
            this.BgSpezkontoTypCode = BgSpezkontoTypCode;
            this.FaLeistungID = faLeistungID;
            this.lblTitel.Text = titelText;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlAySpezialkonto));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryBgPosition = new KiSS4.DB.SqlQuery(this.components);
            this.qryBgSpezkonto = new KiSS4.DB.SqlQuery(this.components);
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.grdBgSpezkonto = new KiSS4.Gui.KissGrid();
            this.grvBgSpezkonto = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNameSpezkonto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartSaldo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetragProMonat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaldo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.imagelist1 = new System.Windows.Forms.ImageList(this.components);
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.lblNameSpezkonto = new KiSS4.Gui.KissLabel();
            this.edtBgKostenartID = new KiSS4.Gui.KissLookUpEdit();
            this.edtStartSaldo = new KiSS4.Gui.KissCalcEdit();
            this.lblStartSaldo = new KiSS4.Gui.KissLabel();
            this.edtOhneEinzelzahlung = new KiSS4.Gui.KissCheckEdit();
            this.edtBetragProMonat = new KiSS4.Gui.KissCalcEdit();
            this.lblBetragProMonat = new KiSS4.Gui.KissLabel();
            this.lblDatumVon = new KiSS4.Gui.KissLabel();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.grdBgPosition = new KiSS4.Gui.KissGrid();
            this.grvBgPosition = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMonat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetragGutschrift = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetragBelastung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaldo2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFreigegeben = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerbucht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtNameSpezkonto = new KiSS4.Gui.KissTextEdit();
            this.edtDatumVonMonat = new KiSS4.Gui.KissLookUpEdit();
            this.edtDatumVonJahr = new KiSS4.Gui.KissCalcEdit();
            this.edtDatumBisMonat = new KiSS4.Gui.KissLookUpEdit();
            this.edtDatumBisJahr = new KiSS4.Gui.KissCalcEdit();
            this.lblDatumBis = new KiSS4.Gui.KissLabel();
            this.lblCHF1 = new KiSS4.Gui.KissLabel();
            this.lblCHF2 = new KiSS4.Gui.KissLabel();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgSpezkonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBgSpezkonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgSpezkonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameSpezkonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKostenartID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKostenartID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStartSaldo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStartSaldo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOhneEinzelzahlung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetragProMonat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetragProMonat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameSpezkonto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVonMonat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVonMonat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVonJahr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBisMonat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBisMonat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBisJahr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHF1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHF2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            this.SuspendLayout();
            //
            // qryBgPosition
            //
            this.qryBgPosition.CanUpdate = true;
            this.qryBgPosition.HostControl = this;
            this.qryBgPosition.SelectStatement = resources.GetString("qryBgPosition.SelectStatement");
            this.qryBgPosition.BeforePost += new System.EventHandler(this.qryBgPosition_BeforePost);
            //
            // qryBgSpezkonto
            //
            this.qryBgSpezkonto.AutoApplyUserRights = false;
            this.qryBgSpezkonto.CanDelete = true;
            this.qryBgSpezkonto.CanInsert = true;
            this.qryBgSpezkonto.CanUpdate = true;
            this.qryBgSpezkonto.HostControl = this;
            this.qryBgSpezkonto.SelectStatement = resources.GetString("qryBgSpezkonto.SelectStatement");
            this.qryBgSpezkonto.TableName = "BgSpezkonto";
            this.qryBgSpezkonto.BeforeDelete += new System.EventHandler(this.qryBgSpezkonto_BeforeDelete);
            this.qryBgSpezkonto.BeforePost += new System.EventHandler(this.qryBgSpezkonto_BeforePost);
            this.qryBgSpezkonto.PositionChanged += new System.EventHandler(this.qryBgSpezkonto_PositionChanged);
            this.qryBgSpezkonto.AfterInsert += new System.EventHandler(this.qryBgSpezkonto_AfterInsert);
            this.qryBgSpezkonto.BeforeDeleteQuestion += new System.EventHandler(this.qryBgSpezkonto_BeforeDeleteQuestion);
            this.qryBgSpezkonto.ColumnChanged += new System.Data.DataColumnChangeEventHandler(this.qryBgSpezkonto_ColumnChanged);
            this.qryBgSpezkonto.AfterPost += new System.EventHandler(this.qryBgSpezkonto_AfterPost);
            this.qryBgSpezkonto.AfterDelete += new System.EventHandler(this.qryBgSpezkonto_AfterDelete);
            //
            // picTitel
            //
            this.picTitel.Location = new System.Drawing.Point(8, 8);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 72;
            this.picTitel.TabStop = false;
            //
            // grdBgSpezkonto
            //
            this.grdBgSpezkonto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdBgSpezkonto.DataSource = this.qryBgSpezkonto;
            this.grdBgSpezkonto.EmbeddedNavigator.Name = "";
            this.grdBgSpezkonto.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBgSpezkonto.Location = new System.Drawing.Point(5, 32);
            this.grdBgSpezkonto.MainView = this.grvBgSpezkonto;
            this.grdBgSpezkonto.Name = "grdBgSpezkonto";
            this.grdBgSpezkonto.Size = new System.Drawing.Size(667, 136);
            this.grdBgSpezkonto.TabIndex = 0;
            this.grdBgSpezkonto.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBgSpezkonto});
            //
            // grvBgSpezkonto
            //
            this.grvBgSpezkonto.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBgSpezkonto.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgSpezkonto.Appearance.Empty.Options.UseBackColor = true;
            this.grvBgSpezkonto.Appearance.Empty.Options.UseFont = true;
            this.grvBgSpezkonto.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvBgSpezkonto.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgSpezkonto.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvBgSpezkonto.Appearance.EvenRow.Options.UseFont = true;
            this.grvBgSpezkonto.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBgSpezkonto.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgSpezkonto.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBgSpezkonto.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBgSpezkonto.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBgSpezkonto.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBgSpezkonto.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBgSpezkonto.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgSpezkonto.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBgSpezkonto.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBgSpezkonto.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBgSpezkonto.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBgSpezkonto.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBgSpezkonto.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBgSpezkonto.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBgSpezkonto.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBgSpezkonto.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBgSpezkonto.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBgSpezkonto.Appearance.GroupRow.Options.UseFont = true;
            this.grvBgSpezkonto.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBgSpezkonto.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBgSpezkonto.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBgSpezkonto.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBgSpezkonto.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBgSpezkonto.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBgSpezkonto.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBgSpezkonto.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBgSpezkonto.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgSpezkonto.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBgSpezkonto.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBgSpezkonto.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBgSpezkonto.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBgSpezkonto.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBgSpezkonto.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBgSpezkonto.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvBgSpezkonto.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgSpezkonto.Appearance.OddRow.Options.UseBackColor = true;
            this.grvBgSpezkonto.Appearance.OddRow.Options.UseFont = true;
            this.grvBgSpezkonto.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBgSpezkonto.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgSpezkonto.Appearance.Row.Options.UseBackColor = true;
            this.grvBgSpezkonto.Appearance.Row.Options.UseFont = true;
            this.grvBgSpezkonto.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvBgSpezkonto.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgSpezkonto.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvBgSpezkonto.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvBgSpezkonto.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBgSpezkonto.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvBgSpezkonto.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBgSpezkonto.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBgSpezkonto.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBgSpezkonto.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNameSpezkonto,
            this.colStartSaldo,
            this.colBetragProMonat,
            this.colSaldo,
            this.colDatumVon,
            this.colDatumBis});
            this.grvBgSpezkonto.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBgSpezkonto.GridControl = this.grdBgSpezkonto;
            this.grvBgSpezkonto.Images = this.imagelist1;
            this.grvBgSpezkonto.Name = "grvBgSpezkonto";
            this.grvBgSpezkonto.OptionsBehavior.Editable = false;
            this.grvBgSpezkonto.OptionsCustomization.AllowFilter = false;
            this.grvBgSpezkonto.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBgSpezkonto.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBgSpezkonto.OptionsNavigation.UseTabKey = false;
            this.grvBgSpezkonto.OptionsView.ColumnAutoWidth = false;
            this.grvBgSpezkonto.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBgSpezkonto.OptionsView.ShowGroupPanel = false;
            this.grvBgSpezkonto.OptionsView.ShowIndicator = false;
            //
            // colNameSpezkonto
            //
            this.colNameSpezkonto.Caption = "Bezeichnung";
            this.colNameSpezkonto.FieldName = "NameSpezkonto";
            this.colNameSpezkonto.Name = "colNameSpezkonto";
            this.colNameSpezkonto.Visible = true;
            this.colNameSpezkonto.VisibleIndex = 0;
            this.colNameSpezkonto.Width = 265;
            //
            // colStartSaldo
            //
            this.colStartSaldo.Caption = "Startsaldo";
            this.colStartSaldo.DisplayFormat.FormatString = "N2";
            this.colStartSaldo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colStartSaldo.FieldName = "StartSaldo";
            this.colStartSaldo.Name = "colStartSaldo";
            this.colStartSaldo.Visible = true;
            this.colStartSaldo.VisibleIndex = 1;
            this.colStartSaldo.Width = 70;
            //
            // colBetragProMonat
            //
            this.colBetragProMonat.AppearanceCell.Options.UseTextOptions = true;
            this.colBetragProMonat.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colBetragProMonat.Caption = "Monatlich";
            this.colBetragProMonat.DisplayFormat.FormatString = "n2";
            this.colBetragProMonat.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetragProMonat.FieldName = "BetragProMonat";
            this.colBetragProMonat.Name = "colBetragProMonat";
            this.colBetragProMonat.Visible = true;
            this.colBetragProMonat.VisibleIndex = 2;
            this.colBetragProMonat.Width = 80;
            //
            // colSaldo
            //
            this.colSaldo.AppearanceCell.Options.UseTextOptions = true;
            this.colSaldo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colSaldo.Caption = "Saldo";
            this.colSaldo.DisplayFormat.FormatString = "n2";
            this.colSaldo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSaldo.FieldName = "Saldo";
            this.colSaldo.Name = "colSaldo";
            this.colSaldo.Visible = true;
            this.colSaldo.VisibleIndex = 3;
            this.colSaldo.Width = 80;
            //
            // colDatumVon
            //
            this.colDatumVon.Caption = "gültig von";
            this.colDatumVon.FieldName = "DatumVon";
            this.colDatumVon.Name = "colDatumVon";
            this.colDatumVon.Visible = true;
            this.colDatumVon.VisibleIndex = 4;
            //
            // colDatumBis
            //
            this.colDatumBis.Caption = "gültig bis";
            this.colDatumBis.FieldName = "DatumBis";
            this.colDatumBis.Name = "colDatumBis";
            this.colDatumBis.Visible = true;
            this.colDatumBis.VisibleIndex = 5;
            //
            // imagelist1
            //
            this.imagelist1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagelist1.ImageStream")));
            this.imagelist1.TransparentColor = System.Drawing.Color.Transparent;
            this.imagelist1.Images.SetKeyName(0, "");
            this.imagelist1.Images.SetKeyName(1, "");
            this.imagelist1.Images.SetKeyName(2, "");
            this.imagelist1.Images.SetKeyName(3, "");
            this.imagelist1.Images.SetKeyName(4, "");
            //
            // lblTitel
            //
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(32, 8);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(640, 16);
            this.lblTitel.TabIndex = 70;
            this.lblTitel.Text = "{0}";
            //
            // lblNameSpezkonto
            //
            this.lblNameSpezkonto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.lblNameSpezkonto.Location = new System.Drawing.Point(5, 180);
            this.lblNameSpezkonto.Name = "lblNameSpezkonto";
            this.lblNameSpezkonto.Size = new System.Drawing.Size(119, 24);
            this.lblNameSpezkonto.TabIndex = 73;
            this.lblNameSpezkonto.Text = "Bezeichnung";
            //
            // edtBgKostenartID
            //
            this.edtBgKostenartID.DataMember = "BgKostenartID";
            this.edtBgKostenartID.DataSource = this.qryBgSpezkonto;
            this.edtBgKostenartID.Location = new System.Drawing.Point(274, 240);
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
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtBgKostenartID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtBgKostenartID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgKostenartID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 544, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtBgKostenartID.Properties.DisplayMember = "Text";
            this.edtBgKostenartID.Properties.NullText = "";
            this.edtBgKostenartID.Properties.ShowFooter = false;
            this.edtBgKostenartID.Properties.ShowHeader = false;
            this.edtBgKostenartID.Properties.ValueMember = "BgKostenartID";
            this.edtBgKostenartID.Size = new System.Drawing.Size(40, 24);
            this.edtBgKostenartID.TabIndex = 4;
            this.edtBgKostenartID.Visible = false;
            //
            // edtStartSaldo
            //
            this.edtStartSaldo.DataMember = "StartSaldo";
            this.edtStartSaldo.DataSource = this.qryBgSpezkonto;
            this.edtStartSaldo.Location = new System.Drawing.Point(130, 210);
            this.edtStartSaldo.Name = "edtStartSaldo";
            this.edtStartSaldo.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtStartSaldo.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStartSaldo.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStartSaldo.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStartSaldo.Properties.Appearance.Options.UseBackColor = true;
            this.edtStartSaldo.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStartSaldo.Properties.Appearance.Options.UseFont = true;
            this.edtStartSaldo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStartSaldo.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStartSaldo.Properties.DisplayFormat.FormatString = "N2";
            this.edtStartSaldo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtStartSaldo.Properties.EditFormat.FormatString = "N2";
            this.edtStartSaldo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtStartSaldo.Size = new System.Drawing.Size(96, 24);
            this.edtStartSaldo.TabIndex = 2;
            //
            // lblStartSaldo
            //
            this.lblStartSaldo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.lblStartSaldo.Location = new System.Drawing.Point(5, 210);
            this.lblStartSaldo.Name = "lblStartSaldo";
            this.lblStartSaldo.Size = new System.Drawing.Size(119, 24);
            this.lblStartSaldo.TabIndex = 77;
            this.lblStartSaldo.Text = "Startsaldo";
            //
            // edtOhneEinzelzahlung
            //
            this.edtOhneEinzelzahlung.DataMember = "OhneEinzelzahlung";
            this.edtOhneEinzelzahlung.DataSource = this.qryBgSpezkonto;
            this.edtOhneEinzelzahlung.Location = new System.Drawing.Point(130, 312);
            this.edtOhneEinzelzahlung.Name = "edtOhneEinzelzahlung";
            this.edtOhneEinzelzahlung.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtOhneEinzelzahlung.Properties.Appearance.Options.UseBackColor = true;
            this.edtOhneEinzelzahlung.Properties.Caption = "Rückerstattung ohne Einzelzahlung";
            this.edtOhneEinzelzahlung.Size = new System.Drawing.Size(216, 19);
            this.edtOhneEinzelzahlung.TabIndex = 79;
            //
            // edtBetragProMonat
            //
            this.edtBetragProMonat.DataMember = "BetragProMonat";
            this.edtBetragProMonat.DataSource = this.qryBgSpezkonto;
            this.edtBetragProMonat.Location = new System.Drawing.Point(130, 240);
            this.edtBetragProMonat.Name = "edtBetragProMonat";
            this.edtBetragProMonat.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBetragProMonat.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBetragProMonat.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetragProMonat.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetragProMonat.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetragProMonat.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetragProMonat.Properties.Appearance.Options.UseFont = true;
            this.edtBetragProMonat.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetragProMonat.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBetragProMonat.Properties.DisplayFormat.FormatString = "N2";
            this.edtBetragProMonat.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetragProMonat.Properties.EditFormat.FormatString = "N2";
            this.edtBetragProMonat.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetragProMonat.Size = new System.Drawing.Size(96, 24);
            this.edtBetragProMonat.TabIndex = 3;
            //
            // lblBetragProMonat
            //
            this.lblBetragProMonat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.lblBetragProMonat.Location = new System.Drawing.Point(5, 240);
            this.lblBetragProMonat.Name = "lblBetragProMonat";
            this.lblBetragProMonat.Size = new System.Drawing.Size(119, 24);
            this.lblBetragProMonat.TabIndex = 80;
            this.lblBetragProMonat.Text = "Monatlicher Betrag";
            //
            // lblDatumVon
            //
            this.lblDatumVon.Location = new System.Drawing.Point(424, 210);
            this.lblDatumVon.Name = "lblDatumVon";
            this.lblDatumVon.Size = new System.Drawing.Size(56, 24);
            this.lblDatumVon.TabIndex = 84;
            this.lblDatumVon.Text = "gültig von";
            //
            // lblBemerkung
            //
            this.lblBemerkung.Location = new System.Drawing.Point(5, 270);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(119, 24);
            this.lblBemerkung.TabIndex = 88;
            this.lblBemerkung.Text = "Bemerkungen";
            //
            // edtBemerkung
            //
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryBgSpezkonto;
            this.edtBemerkung.Location = new System.Drawing.Point(130, 270);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(528, 39);
            this.edtBemerkung.TabIndex = 9;
            //
            // grdBgPosition
            //
            this.grdBgPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdBgPosition.DataSource = this.qryBgPosition;
            this.grdBgPosition.EmbeddedNavigator.Name = "";
            this.grdBgPosition.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBgPosition.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdBgPosition.Location = new System.Drawing.Point(5, 336);
            this.grdBgPosition.MainView = this.grvBgPosition;
            this.grdBgPosition.Name = "grdBgPosition";
            this.grdBgPosition.Size = new System.Drawing.Size(667, 216);
            this.grdBgPosition.TabIndex = 10;
            this.grdBgPosition.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBgPosition});
            //
            // grvBgPosition
            //
            this.grvBgPosition.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBgPosition.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.Empty.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.Empty.Options.UseFont = true;
            this.grvBgPosition.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvBgPosition.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.EvenRow.Options.UseFont = true;
            this.grvBgPosition.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBgPosition.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBgPosition.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBgPosition.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBgPosition.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBgPosition.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBgPosition.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBgPosition.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBgPosition.Appearance.FooterPanel.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBgPosition.Appearance.FooterPanel.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBgPosition.Appearance.FooterPanel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBgPosition.Appearance.FooterPanel.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.grvBgPosition.Appearance.FooterPanel.Options.UseFont = true;
            this.grvBgPosition.Appearance.GroupFooter.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBgPosition.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBgPosition.Appearance.GroupFooter.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBgPosition.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvBgPosition.Appearance.GroupFooter.Options.UseFont = true;
            this.grvBgPosition.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBgPosition.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBgPosition.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBgPosition.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBgPosition.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.GroupRow.Options.UseFont = true;
            this.grvBgPosition.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBgPosition.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBgPosition.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBgPosition.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBgPosition.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBgPosition.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBgPosition.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBgPosition.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBgPosition.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBgPosition.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBgPosition.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBgPosition.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvBgPosition.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.OddRow.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.OddRow.Options.UseFont = true;
            this.grvBgPosition.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBgPosition.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.Row.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.Row.Options.UseFont = true;
            this.grvBgPosition.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvBgPosition.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvBgPosition.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBgPosition.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvBgPosition.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBgPosition.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBgPosition.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBgPosition.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMonat,
            this.colBetragGutschrift,
            this.colBetragBelastung,
            this.colSaldo2,
            this.colFreigegeben,
            this.colVerbucht,
            this.colText});
            this.grvBgPosition.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBgPosition.GridControl = this.grdBgPosition;
            this.grvBgPosition.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.Hidden;
            this.grvBgPosition.GroupFormat = "";
            this.grvBgPosition.GroupRowHeight = 25;
            this.grvBgPosition.Images = this.imagelist1;
            this.grvBgPosition.Name = "grvBgPosition";
            this.grvBgPosition.OptionsBehavior.AutoSelectAllInEditor = false;
            this.grvBgPosition.OptionsBehavior.Editable = false;
            this.grvBgPosition.OptionsCustomization.AllowFilter = false;
            this.grvBgPosition.OptionsCustomization.AllowGroup = false;
            this.grvBgPosition.OptionsCustomization.AllowSort = false;
            this.grvBgPosition.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBgPosition.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBgPosition.OptionsNavigation.AutoMoveRowFocus = false;
            this.grvBgPosition.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvBgPosition.OptionsNavigation.UseTabKey = false;
            this.grvBgPosition.OptionsPrint.AutoWidth = false;
            this.grvBgPosition.OptionsPrint.UsePrintStyles = true;
            this.grvBgPosition.OptionsView.ColumnAutoWidth = false;
            this.grvBgPosition.OptionsView.ShowDetailButtons = false;
            this.grvBgPosition.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBgPosition.OptionsView.ShowFooter = true;
            this.grvBgPosition.OptionsView.ShowGroupPanel = false;
            this.grvBgPosition.OptionsView.ShowIndicator = false;
            this.grvBgPosition.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(this.qrvBgPosition_CustomSummaryCalculate);
            //
            // colMonat
            //
            this.colMonat.Caption = "Monat";
            this.colMonat.DisplayFormat.FormatString = "{0:MMM yyyy}";
            this.colMonat.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colMonat.FieldName = "Datum";
            this.colMonat.Name = "colMonat";
            this.colMonat.Visible = true;
            this.colMonat.VisibleIndex = 0;
            this.colMonat.Width = 90;
            //
            // colBetragGutschrift
            //
            this.colBetragGutschrift.Caption = "Gutschrift";
            this.colBetragGutschrift.DisplayFormat.FormatString = "N2";
            this.colBetragGutschrift.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetragGutschrift.FieldName = "Gutschrift";
            this.colBetragGutschrift.Name = "colBetragGutschrift";
            this.colBetragGutschrift.SummaryItem.DisplayFormat = "{0:n2}";
            this.colBetragGutschrift.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colBetragGutschrift.Visible = true;
            this.colBetragGutschrift.VisibleIndex = 1;
            this.colBetragGutschrift.Width = 80;
            //
            // colBetragBelastung
            //
            this.colBetragBelastung.Caption = "Belastung";
            this.colBetragBelastung.DisplayFormat.FormatString = "N2";
            this.colBetragBelastung.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetragBelastung.FieldName = "Belastung";
            this.colBetragBelastung.Name = "colBetragBelastung";
            this.colBetragBelastung.SummaryItem.DisplayFormat = "{0:n2}";
            this.colBetragBelastung.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colBetragBelastung.Visible = true;
            this.colBetragBelastung.VisibleIndex = 2;
            this.colBetragBelastung.Width = 80;
            //
            // colSaldo2
            //
            this.colSaldo2.Caption = "Saldo";
            this.colSaldo2.DisplayFormat.FormatString = "N2";
            this.colSaldo2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSaldo2.FieldName = "Saldo";
            this.colSaldo2.Name = "colSaldo2";
            this.colSaldo2.SummaryItem.DisplayFormat = "{0:n2}";
            this.colSaldo2.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.colSaldo2.Visible = true;
            this.colSaldo2.VisibleIndex = 3;
            this.colSaldo2.Width = 80;
            //
            // colFreigegeben
            //
            this.colFreigegeben.Caption = "MB";
            this.colFreigegeben.FieldName = "Freigegeben";
            this.colFreigegeben.ImageIndex = 3;
            this.colFreigegeben.Name = "colFreigegeben";
            this.colFreigegeben.Visible = true;
            this.colFreigegeben.VisibleIndex = 4;
            this.colFreigegeben.Width = 60;
            //
            // colVerbucht
            //
            this.colVerbucht.Caption = "verbucht";
            this.colVerbucht.FieldName = "Verbucht";
            this.colVerbucht.Name = "colVerbucht";
            this.colVerbucht.Visible = true;
            this.colVerbucht.VisibleIndex = 5;
            this.colVerbucht.Width = 60;
            //
            // colText
            //
            this.colText.Caption = "Buchungstext";
            this.colText.FieldName = "Buchungstext";
            this.colText.Name = "colText";
            this.colText.Visible = true;
            this.colText.VisibleIndex = 6;
            this.colText.Width = 190;
            //
            // edtNameSpezkonto
            //
            this.edtNameSpezkonto.DataMember = "NameSpezkonto";
            this.edtNameSpezkonto.DataSource = this.qryBgSpezkonto;
            this.edtNameSpezkonto.Location = new System.Drawing.Point(130, 180);
            this.edtNameSpezkonto.Name = "edtNameSpezkonto";
            this.edtNameSpezkonto.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNameSpezkonto.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNameSpezkonto.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNameSpezkonto.Properties.Appearance.Options.UseBackColor = true;
            this.edtNameSpezkonto.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNameSpezkonto.Properties.Appearance.Options.UseFont = true;
            this.edtNameSpezkonto.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNameSpezkonto.Size = new System.Drawing.Size(528, 24);
            this.edtNameSpezkonto.TabIndex = 1;
            //
            // edtDatumVonMonat
            //
            this.edtDatumVonMonat.DataMember = "DatumVonMonat";
            this.edtDatumVonMonat.DataSource = this.qryBgSpezkonto;
            this.edtDatumVonMonat.Location = new System.Drawing.Point(488, 210);
            this.edtDatumVonMonat.Name = "edtDatumVonMonat";
            this.edtDatumVonMonat.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVonMonat.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVonMonat.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVonMonat.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVonMonat.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVonMonat.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVonMonat.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtDatumVonMonat.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVonMonat.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtDatumVonMonat.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtDatumVonMonat.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtDatumVonMonat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtDatumVonMonat.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVonMonat.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 544, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtDatumVonMonat.Properties.DisplayMember = "Text";
            this.edtDatumVonMonat.Properties.NullText = "";
            this.edtDatumVonMonat.Properties.ShowFooter = false;
            this.edtDatumVonMonat.Properties.ShowHeader = false;
            this.edtDatumVonMonat.Properties.ValueMember = "Code";
            this.edtDatumVonMonat.Size = new System.Drawing.Size(72, 24);
            this.edtDatumVonMonat.TabIndex = 5;
            //
            // edtDatumVonJahr
            //
            this.edtDatumVonJahr.DataMember = "DatumVonJahr";
            this.edtDatumVonJahr.DataSource = this.qryBgSpezkonto;
            this.edtDatumVonJahr.Location = new System.Drawing.Point(568, 210);
            this.edtDatumVonJahr.Name = "edtDatumVonJahr";
            this.edtDatumVonJahr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVonJahr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVonJahr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVonJahr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVonJahr.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVonJahr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVonJahr.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVonJahr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtDatumVonJahr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVonJahr.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtDatumVonJahr.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtDatumVonJahr.Size = new System.Drawing.Size(48, 24);
            this.edtDatumVonJahr.TabIndex = 6;
            //
            // edtDatumBisMonat
            //
            this.edtDatumBisMonat.DataMember = "DatumBisMonat";
            this.edtDatumBisMonat.DataSource = this.qryBgSpezkonto;
            this.edtDatumBisMonat.Location = new System.Drawing.Point(488, 240);
            this.edtDatumBisMonat.Name = "edtDatumBisMonat";
            this.edtDatumBisMonat.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBisMonat.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBisMonat.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBisMonat.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBisMonat.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBisMonat.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBisMonat.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtDatumBisMonat.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBisMonat.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtDatumBisMonat.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtDatumBisMonat.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtDatumBisMonat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtDatumBisMonat.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBisMonat.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 544, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtDatumBisMonat.Properties.DisplayMember = "Text";
            this.edtDatumBisMonat.Properties.NullText = "";
            this.edtDatumBisMonat.Properties.ShowFooter = false;
            this.edtDatumBisMonat.Properties.ShowHeader = false;
            this.edtDatumBisMonat.Properties.ValueMember = "Code";
            this.edtDatumBisMonat.Size = new System.Drawing.Size(72, 24);
            this.edtDatumBisMonat.TabIndex = 7;
            //
            // edtDatumBisJahr
            //
            this.edtDatumBisJahr.DataMember = "DatumBisJahr";
            this.edtDatumBisJahr.DataSource = this.qryBgSpezkonto;
            this.edtDatumBisJahr.Location = new System.Drawing.Point(568, 240);
            this.edtDatumBisJahr.Name = "edtDatumBisJahr";
            this.edtDatumBisJahr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBisJahr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBisJahr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBisJahr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBisJahr.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBisJahr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBisJahr.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBisJahr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtDatumBisJahr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBisJahr.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtDatumBisJahr.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtDatumBisJahr.Size = new System.Drawing.Size(48, 24);
            this.edtDatumBisJahr.TabIndex = 8;
            //
            // lblDatumBis
            //
            this.lblDatumBis.Location = new System.Drawing.Point(424, 240);
            this.lblDatumBis.Name = "lblDatumBis";
            this.lblDatumBis.Size = new System.Drawing.Size(48, 24);
            this.lblDatumBis.TabIndex = 98;
            this.lblDatumBis.Text = "gültig bis";
            //
            // lblCHF1
            //
            this.lblCHF1.Location = new System.Drawing.Point(229, 210);
            this.lblCHF1.Name = "lblCHF1";
            this.lblCHF1.Size = new System.Drawing.Size(24, 24);
            this.lblCHF1.TabIndex = 99;
            this.lblCHF1.Text = "CHF";
            //
            // lblCHF2
            //
            this.lblCHF2.Location = new System.Drawing.Point(229, 240);
            this.lblCHF2.Name = "lblCHF2";
            this.lblCHF2.Size = new System.Drawing.Size(24, 24);
            this.lblCHF2.TabIndex = 100;
            this.lblCHF2.Text = "CHF";
            //
            // kissLabel4
            //
            this.kissLabel4.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel4.Location = new System.Drawing.Point(5, 315);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(119, 16);
            this.kissLabel4.TabIndex = 101;
            this.kissLabel4.Text = "Kontoblatt";
            //
            // CtlAySpezialkonto
            //
            this.ActiveSQLQuery = this.qryBgSpezkonto;
            this.Controls.Add(this.grdBgPosition);
            this.Controls.Add(this.kissLabel4);
            this.Controls.Add(this.lblCHF2);
            this.Controls.Add(this.lblCHF1);
            this.Controls.Add(this.lblDatumBis);
            this.Controls.Add(this.edtDatumBisMonat);
            this.Controls.Add(this.edtDatumBisJahr);
            this.Controls.Add(this.edtDatumVonMonat);
            this.Controls.Add(this.edtDatumVonJahr);
            this.Controls.Add(this.edtNameSpezkonto);
            this.Controls.Add(this.lblDatumVon);
            this.Controls.Add(this.lblBemerkung);
            this.Controls.Add(this.edtBemerkung);
            this.Controls.Add(this.edtBetragProMonat);
            this.Controls.Add(this.lblBetragProMonat);
            this.Controls.Add(this.edtStartSaldo);
            this.Controls.Add(this.lblStartSaldo);
            this.Controls.Add(this.edtOhneEinzelzahlung);
            this.Controls.Add(this.edtBgKostenartID);
            this.Controls.Add(this.lblNameSpezkonto);
            this.Controls.Add(this.picTitel);
            this.Controls.Add(this.grdBgSpezkonto);
            this.Controls.Add(this.lblTitel);
            this.Name = "CtlAySpezialkonto";
            this.Size = new System.Drawing.Size(680, 560);
            this.Load += new System.EventHandler(this.CtlAySpezialkonto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgSpezkonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBgSpezkonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgSpezkonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameSpezkonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKostenartID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKostenartID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStartSaldo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStartSaldo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOhneEinzelzahlung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetragProMonat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetragProMonat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameSpezkonto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVonMonat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVonMonat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVonJahr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBisMonat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBisMonat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBisJahr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHF1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHF2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
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
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        #region EventHandlers

        private void CtlAySpezialkonto_Load(object sender, System.EventArgs e)
        {
            // Kostenarten
            edtBgKostenartID.Properties.DataSource = AyUtil.GetSqlQueryKostenart_Einzelzahlung();

            // Monate
            SqlQuery qry = DBUtil.OpenSQL(@"
                select  Code = null, Text = null union all
                select  1, 'Jan' union all
                select  2, 'Feb' union all
                select  3, 'März' union all
                select  4, 'Apr' union all
                select  5, 'Mai' union all
                select  6, 'Juni' union all
                select  7, 'Juli' union all
                select  8, 'Aug' union all
                select  9, 'Sep' union all
                select 10, 'Okt' union all
                select 11, 'Nov' union all
                select 12, 'Dez' ");

            edtDatumVonMonat.LoadQuery(qry);
            edtDatumBisMonat.LoadQuery(qry);

            //rename/resize/enable Fields,GridColumns,Labels
            switch (this.BgSpezkontoTypCode)
            {
                case BgSpezkontoTyp.Ausgabekonto:
                    //lblTitel.Text = "Ausgabenkonti";
                    lblBetragProMonat.Text = "Kostenart";
                    edtBetragProMonat.Visible = false;
                    lblCHF2.Visible = false;
                    edtBgKostenartID.Left = edtBetragProMonat.Left;
                    edtBgKostenartID.Width = 250;
                    edtBgKostenartID.Visible = true;
                    edtOhneEinzelzahlung.Visible = false;
                    colNameSpezkonto.Width += 20;
                    break;

                case BgSpezkontoTyp.Vorabzugkonto:
                    //lblTitel.Text = "Vorabzugskonti";
                    edtBgKostenartID.Visible = false;
                    edtOhneEinzelzahlung.Visible = false;
                    break;

                case BgSpezkontoTyp.Abzahlungskonto:
                    //lblTitel.Text = "Abzahlungskonti";
                    edtBgKostenartID.Visible = false;
                    lblStartSaldo.Text = "Abzuzahlender Betrag";
                    colStartSaldo.Caption = "Abzahlbetrag";
                    colBetragProMonat.VisibleIndex = -1;
                    break;
            }

            qryBgSpezkonto.Fill(FaLeistungID, (int)BgSpezkontoTypCode);

            if (DialogMode)
            {
                qryBgSpezkonto.Insert();
                qryBgSpezkonto["NameSpezkonto"] = this.InitName;
                qryBgSpezkonto["StartSaldo"] = this.InitStartSaldo;
                qryBgSpezkonto["BetragProMonat"] = this.InitBelastung;
            }
        }

        private void qrvBgPosition_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            if (e.Item == colSaldo2.SummaryItem && e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                e.TotalValue = Saldo;
        }

        private void qryBgPosition_BeforePost(object sender, System.EventArgs e)
        {
            qryBgPosition.Row.AcceptChanges();
            qryBgPosition.RowModified = false;
        }

        private void qryBgSpezkonto_AfterDelete(object sender, System.EventArgs e)
        {
            try
            {
                Session.Commit();
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
                return;
            }
            if (qryBgSpezkonto.Count == 0)
                DisplayBewegungen();
        }

        private void qryBgSpezkonto_AfterInsert(object sender, System.EventArgs e)
        {
            qryBgSpezkonto["FaLeistungID"] = this.FaLeistungID;
            qryBgSpezkonto["BgSpezkontoTypCode"] = (int)BgSpezkontoTypCode;

            switch (BgSpezkontoTypCode)
            {
                case BgSpezkontoTyp.Ausgabekonto:
                    qryBgSpezkonto["BgKostenartID"] = 1;
                    break;

                case BgSpezkontoTyp.Vorabzugkonto:
                    qryBgSpezkonto["StartSaldo"] = 0;
                    qryBgSpezkonto["BetragProMonat"] = 100;
                    break;

                case BgSpezkontoTyp.Abzahlungskonto:
                    qryBgSpezkonto["StartSaldo"] = 100;
                    qryBgSpezkonto["BetragProMonat"] = 100;
                    break;
            }

            //Gültig von: nächsten Monat vorschlagen
            qryBgSpezkonto["DatumVonJahr"] = DateTime.Today.AddMonths(1).Year;
            qryBgSpezkonto["DatumVonMonat"] = DateTime.Today.AddMonths(1).Month;

            qryBgSpezkonto["Saldo"] = qryBgSpezkonto["StartSaldo"];

            edtNameSpezkonto.Focus();
        }

        private void qryBgSpezkonto_AfterPost(object sender, System.EventArgs e)
        {
            try
            {
                switch (BgSpezkontoTypCode)
                {
                    case BgSpezkontoTyp.Vorabzugkonto:
                    case BgSpezkontoTyp.Abzahlungskonto:
                        DBUtil.ExecSQL("EXECUTE dbo.spAySpezkonto_UpdateBudget {0}", qryBgSpezkonto["BgSpezkontoID"]);
                        qryBgSpezkonto_PositionChanged(this, EventArgs.Empty);
                        break;
                }

                // Gültig von/bis im Grid updaten
                this.qryBgSpezkonto.Row.AcceptChanges();
                this.qryBgSpezkonto.RowModified = false;

                Session.Commit();
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
                return;
            }

            qryBgSpezkonto.Refresh();
        }

        private void qryBgSpezkonto_BeforeDelete(object sender, System.EventArgs e)
        {
            Session.BeginTransaction();
            try
            {
                DBUtil.ExecSQL(@"
                DELETE BPO
                FROM dbo.BgPosition        BPO
                  INNER JOIN dbo.BgBudget  BBG ON BBG.BgBudgetID = BPO.BgBudgetID
                WHERE BPO.BgSpezkontoID = {0} AND BPO.BgKategorieCode IN (3, 6)
                  AND (BBG.BgBewilligungStatusCode < 5 OR (BBG.MasterBudget = 1 AND BBG.BgBewilligungStatusCode = 5))"
                        , qryBgSpezkonto["BgSpezkontoID"]);

            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
                throw new KissCancelException();
            }
        }

        private void qryBgSpezkonto_BeforeDeleteQuestion(object sender, System.EventArgs e)
        {
            if (qryBgPosition.Count == 0)
                return;
            if (qryBgPosition.Count == 1)
            {
                Text = qryBgPosition.DataTable.Rows[0]["MonatText"].ToString();
                if (Text.ToUpper() == "STARTSALDO")
                    return;
            }

            throw new KissInfoException(KissMsg.GetMLMessage("CtlAySpezialkonto", "BereitsAufKontoGebucht", "Auf dieses Konto wurde bereits gebucht und kann deshalb nicht mehr gelöscht werden", KissMsgCode.MsgInfo));
        }

        private void qryBgSpezkonto_BeforePost(object sender, System.EventArgs e)
        {
            DBUtil.CheckNotNullField(edtNameSpezkonto, lblNameSpezkonto.Text);
            DBUtil.CheckNotNullField(edtDatumVonMonat, KissMsg.GetMLMessage("CtlAySpezialkonto", "GueltigVonMonat", "gültig von (Monat)"));
            DBUtil.CheckNotNullField(edtDatumVonJahr, KissMsg.GetMLMessage("CtlAySpezialkonto", "GueltigVonJahr", "gültig von (Jahr)"));
            DBUtil.CheckNotNullField(edtStartSaldo, lblStartSaldo.Text);

            // validate only for Vorabzugkonto and Abzahlungskonto (see: #5996)
            switch (BgSpezkontoTypCode)
            {
                case BgSpezkontoTyp.Vorabzugkonto:
                case BgSpezkontoTyp.Abzahlungskonto:
                    DBUtil.CheckNotNullField(edtBetragProMonat, lblBetragProMonat.Text);
                    break;
            }

            Session.BeginTransaction();

            try
            {
                qryBgSpezkonto["DatumVon"] = new DateTime((int)qryBgSpezkonto["DatumVonJahr"], (int)qryBgSpezkonto["DatumVonMonat"], 1);

                if (!DBUtil.IsEmpty(qryBgSpezkonto["DatumBisJahr"]) && !DBUtil.IsEmpty(qryBgSpezkonto["DatumBisMonat"]))
                {
                    DateTime datumBis = new DateTime((int)qryBgSpezkonto["DatumBisJahr"], (int)qryBgSpezkonto["DatumBisMonat"], 1);
                    qryBgSpezkonto["DatumBis"] = datumBis.AddMonths(1).AddDays(-1);
                }
                else
                {
                    qryBgSpezkonto["DatumBis"] = DBNull.Value;
                }

                if (!DBUtil.IsEmpty(qryBgSpezkonto["DatumBis"]) &&
                    ((DateTime)qryBgSpezkonto["DatumVon"]) > ((DateTime)qryBgSpezkonto["DatumBis"]))
                {
                    throw new KissInfoException(KissMsg.GetMLMessage("CtlAySpezialkonto", "DatBisVorDatVon", "'gültig bis' darf nicht vor 'gültig von' sein.", KissMsgCode.MsgInfo), edtDatumVonMonat);
                }

                if (qryBgSpezkonto.Row.RowState != DataRowState.Added && qryBgSpezkonto.ColumnModified("Startsaldo"))
                {
                    decimal Saldo = (decimal)qryBgSpezkonto["Saldo", DataRowVersion.Original]
                                    - (decimal)qryBgSpezkonto["Startsaldo", DataRowVersion.Original]
                                    + (decimal)qryBgSpezkonto["Startsaldo"];

                    if (Saldo < 0)
                    {
                        Saldo = (decimal)qryBgSpezkonto["Startsaldo"] - Saldo;
                        throw new KissInfoException(KissMsg.GetMLMessage("CtlAySpezialkonto", "MinStartsaldo", "Der Startsaldo muss mindestens Fr. {0:n2} betragen", KissMsgCode.MsgInfo, Saldo), edtStartSaldo);
                    }

                    qryBgSpezkonto["Saldo"] = Saldo;
                }

                object o;

                switch (BgSpezkontoTypCode)
                {
                    case BgSpezkontoTyp.Vorabzugkonto:
                        /*
                        if (qryShSpezkonto.ColumnModified("Startsaldo"))
                        {
                            o = DBUtil.GetUserPermission(Permission.Ay_StartsaldoVorabzugskonto, null);
                            if (null == o)
                                throw new KissInfoException(KissMsg.GetMLMessage("CtlAySpezialkonto", "KompetenzErstEinrichten", "Die Kompetenz 'Asyl: Monatsbudget - max. Startsaldo eines Vorabzugskontos' muss zuerst für Sie eingerichtet werden.", KissMsgCode.MsgInfo));

                            decimal maxStartSaldo = Convert.ToDecimal(o);
                            if (this.editStartsaldo.Value > maxStartSaldo)
                            throw new KissInfoException(KissMsg.GetMLMessage("CtlAySpezialkonto", "KeineKompetenz", "Sie haben nicht die Kompetenz, einen Startsaldo von {0:n2} einzugeben.\r\nIhre Kompetenz liegt bei {1:n2}", KissMsgCode.MsgInfo, this.editStartsaldo.Value, maxStartSaldo));
                        }
                        */
                        break;

                    case BgSpezkontoTyp.Abzahlungskonto:
                        if (this.qryBgSpezkonto.ColumnModified("OhneEinzelzahlung") &&
                          DBUtil.OpenSQL("SELECT * FROM dbo.BgPosition WHERE BgSpezkontoID = {0} AND BgKategorieCode = {1}"
                          , this.qryBgSpezkonto["BgSpezkontoID"], (int)BgKategorie.Einzelzahlung).Count > 0)
                        {
                            throw new KissInfoException(KissMsg.GetMLMessage("CtlAySpezialkonto", "EinzelzahlungExistiertBereits", "Rückerstattung ohne Einzelzahlung darf nicht mehr verändert werden.\r\nEs existiert bereits eine Einzelzahlung auf diesem Konto", KissMsgCode.MsgInfo));
                        }

                        if (qryBgSpezkonto.Row.RowState == DataRowState.Added)
                        {
                            o = DBUtil.ExecuteScalarSQL(@"
                                SELECT	MAX(DATEADD(m, 1, dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1)))
                                FROM	dbo.BgFinanzplan SFP
                                        INNER JOIN dbo.BgBudget  BBG ON BBG.BgFinanzplanID = SFP.BgFinanzplanID
                                WHERE	SFP.FaLeistungID = {0} AND
                                        SFP.BgBewilligungStatusCode = 5 AND
                                        BBG.MasterBudget = 0 AND BBG.BgBewilligungStatusCode >= 5 AND
                                        dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1) >= dbo.fnFirstDayOf({1})",
                              this.FaLeistungID,
                              qryBgSpezkonto["DatumVon"]);

                            if (!DBUtil.IsEmpty(o))
                                throw new KissInfoException(KissMsg.GetMLMessage("CtlAySpezialkonto", "MonatsbudgetGesperrt", "'gültig von' ist nicht zulässig, da freigegebene oder gesperrte Monatsbudgets in diesem oder späteren Monat vorhanden sind.", KissMsgCode.MsgInfo), this.edtDatumVonMonat);

                            o = DBUtil.ExecuteScalarSQL(@"
                                SELECT	Count(*)
                                FROM	dbo.BgFinanzplan SFP
                                        INNER JOIN dbo.BgBudget    BBG ON BBG.BgFinanzplanID = SFP.BgFinanzplanID
                                        INNER JOIN dbo.BgPosition  BPO ON BPO.BgBudgetID = BBG.BgBudgetID AND BPO.BgSpezkontoID = {2}
                                WHERE	SFP.FaLeistungID = {0} AND
                                        SFP.BgBewilligungStatusCode = 5 AND
                                        BBG.MasterBudget = 0 AND BBG.BgBewilligungStatusCode >= 5 AND
                                        dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1) < dbo.fnFirstDayOf({1})",
                              this.FaLeistungID,
                              qryBgSpezkonto["DatumVon"],
                              qryBgSpezkonto["BgSpezkontoID"]);

                            if ((int)o > 0)
                                throw new KissInfoException(KissMsg.GetMLMessage("CtlAySpezialkonto", "AbzahlungenVorDiesemMonat", "'gültig von' ist nicht zulässig. Es sind {0} Abzahlungen vor diesem Monat gemacht worden", KissMsgCode.MsgInfo, o), this.edtDatumVonMonat);
                        }

                        if (Convert.ToDecimal(colBetragBelastung.SummaryItem.SummaryValue) > Convert.ToDecimal(qryBgSpezkonto["StartSaldo"]))
                            throw new KissInfoException(KissMsg.GetMLMessage("CtlAySpezialkonto", "EinzelzahlungenZuHoch", "Die Summe aller Einzelzahlungen ({0:n2}) übersteigt das Abzahlungsziel ({1:n2}))", KissMsgCode.MsgInfo, colBetragBelastung.SummaryItem.SummaryValue, qryBgSpezkonto["StartSaldo"]), this.edtStartSaldo);

                        if (Convert.ToDecimal(colBetragGutschrift.SummaryItem.SummaryValue) > Convert.ToDecimal(qryBgSpezkonto["StartSaldo"]))
                            throw new KissInfoException(KissMsg.GetMLMessage("CtlAySpezialkonto", "AbzahlungenZuHoch", "Die Summe aller Abzahlungen ({0:n2}) übersteigt das Abzahlungsziel ({1:n2}))", KissMsgCode.MsgInfo, colBetragGutschrift.SummaryItem.SummaryValue, qryBgSpezkonto["StartSaldo"]), this.edtStartSaldo);

                        if (DBUtil.IsEmpty(qryBgSpezkonto["BetragProMonat"]) || Convert.ToDecimal(qryBgSpezkonto["BetragProMonat"]) <= (decimal)0)
                            throw new KissInfoException(KissMsg.GetMLMessage("CtlAySpezialkonto", "BetragZuKlein", "Der monatliche Betrag muss > 0.00 sein.", KissMsgCode.MsgInfo), this.edtBetragProMonat);

                        if (!DBUtil.IsEmpty(qryBgSpezkonto["DatumBis"]))
                        {
                            // Falls DatumBis erfasst: die nötige Anzahl Raten muss kleiner sein als die Anzahl Monate zwischen
                            // 'gültig von' und 'gültig bis'
                            int payments = (int)Math.Floor((double)((decimal)qryBgSpezkonto["StartSaldo"] / (decimal)qryBgSpezkonto["BetragProMonat"]));
                            decimal remainder = (decimal)qryBgSpezkonto["StartSaldo"] % (decimal)qryBgSpezkonto["BetragProMonat"];
                            if (remainder > 0)
                                payments++;

                            DateTime DatumVon = (DateTime)qryBgSpezkonto["DatumVon"];
                            DateTime DatumBis = (DateTime)qryBgSpezkonto["DatumBis"];

                            int months = (DatumBis.Year * 12 + DatumBis.Month - 1) -
                                         (DatumVon.Year * 12 + DatumVon.Month - 1) + 1;

                            if (payments > months)
                                throw new KissInfoException(KissMsg.GetMLMessage("CtlAySpezialkonto", "AbzahlungenNoetig", "Es sind {0} Abzahlungen nötig, zwischen 'gültig von' und 'gültig bis' liegen aber nur {1} Monate.", KissMsgCode.MsgInfo, payments, months));
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
                throw new KissCancelException();
            }
        }

        private void qryBgSpezkonto_ColumnChanged(object sender, System.Data.DataColumnChangeEventArgs e)
        {
            if (qryBgSpezkonto.IsFilling)
                return;
            if (qryBgSpezkonto.IsInserting)
                return;

            if (e.Column.ColumnName == "StartSaldo" ||
                e.Column.ColumnName == "BetragProMonat" ||
                e.Column.ColumnName == "DatumVonJahr" ||
                e.Column.ColumnName == "DatumVonMonat")
            {
                CalcDatumBis();
            }
        }

        private void qryBgSpezkonto_PositionChanged(object sender, System.EventArgs e)
        {
            DisplayBewegungen();

            if (qryBgSpezkonto.Row == null)
                return;

            if (!DBUtil.IsEmpty(qryBgSpezkonto["DatumVon"]))
            {
                qryBgSpezkonto["DatumVonMonat"] = ((DateTime)qryBgSpezkonto["DatumVon"]).Month;
                qryBgSpezkonto["DatumVonJahr"] = ((DateTime)qryBgSpezkonto["DatumVon"]).Year;
            }

            if (!DBUtil.IsEmpty(qryBgSpezkonto["DatumBis"]))
            {
                qryBgSpezkonto["DatumBisMonat"] = ((DateTime)qryBgSpezkonto["DatumBis"]).Month;
                qryBgSpezkonto["DatumBisJahr"] = ((DateTime)qryBgSpezkonto["DatumBis"]).Year;
            }

            if (qryBgSpezkonto.Row.RowState != DataRowState.Added)
            {
                qryBgSpezkonto.RowModified = false;
                qryBgSpezkonto.Row.AcceptChanges();
            }
        }

        #endregion

        #region Methods

        #region Private Methods

        private void CalcDatumBis()
        {
            if (this.BgSpezkontoTypCode != BgSpezkontoTyp.Abzahlungskonto)
                return;
            if (DBUtil.IsEmpty(qryBgSpezkonto["DatumVonJahr"]))
                return;
            if (DBUtil.IsEmpty(qryBgSpezkonto["DatumVonMonat"]))
                return;
            if (DBUtil.IsEmpty(qryBgSpezkonto["StartSaldo"]))
                return;
            if (DBUtil.IsEmpty(qryBgSpezkonto["BetragProMonat"]))
                return;

            // #3906 Korrektur wegen Fehlermeldung wenn division mit 0!
            int payments;
            decimal remainder;

            if ((decimal)qryBgSpezkonto["BetragProMonat"] == 0)
            {
                payments = 0;
                remainder = 0;
            }
            else
            {
                payments = (int)Math.Floor((double)((decimal)qryBgSpezkonto["StartSaldo"] / (decimal)qryBgSpezkonto["BetragProMonat"]));
                remainder = (decimal)qryBgSpezkonto["StartSaldo"] % (decimal)qryBgSpezkonto["BetragProMonat"];
            }

            if (remainder > 0)
                payments++;

            DateTime DatumVon = new DateTime((int)qryBgSpezkonto["DatumVonJahr"], (int)qryBgSpezkonto["DatumVonMonat"], 1);

            qryBgSpezkonto["DatumBisMonat"] = DatumVon.AddMonths(payments - 1).Month;
            qryBgSpezkonto["DatumBisJahr"] = DatumVon.AddMonths(payments - 1).Year;

            qryBgSpezkonto.RefreshDisplay();
        }

        private void DisplayBewegungen()
        {
            Saldo = 0;

            //Sortierung:
            // 1. Jahr
            // 2. Monat
            // 3. Ausgabe   (Typ 1): Budget vor EZ
            //	  Vorabzug  (Typ 2): Budget vor EZ
            //	  Abzahlung (Typ 3): EZ vor Budget

            grdBgPosition.DataSource = null;
            qryBgPosition.Fill(qryBgSpezkonto["BgSpezkontoID"], qryBgSpezkonto["BgSpezkontoTypCode"]);
            grdBgPosition.DataSource = qryBgPosition;

            //Calculate Saldo column
            for (int i = qryBgPosition.DataTable.Rows.Count - 1; i >= 0; i--)
            {
                DataRow row = qryBgPosition.DataTable.Rows[i];

                if (!DBUtil.IsEmpty(row["Gutschrift"]))
                    Saldo += (Decimal)row["Gutschrift"];

                if (!DBUtil.IsEmpty(row["Belastung"]))
                    Saldo -= (Decimal)row["Belastung"];

                row["Saldo"] = Saldo;
            }
        }

        #endregion

        #endregion
    }
}