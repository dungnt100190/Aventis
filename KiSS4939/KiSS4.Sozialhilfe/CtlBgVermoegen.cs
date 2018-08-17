using System;
using System.Data;
using System.Drawing;
using KiSS4.DB;
using KiSS.DBScheme;
using KiSS4.Common;

namespace KiSS4.Sozialhilfe
{
    public class CtlBgVermoegen : KiSS4.Gui.KissUserControl
    {
        #region Constants

        const LOV.BgGruppeCode BgGruppeCode = LOV.BgGruppeCode.Vermoegen_und_Vermoegensverbrauch;

        #endregion

        #region Fields

        private int BgBudgetID;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colBgPositionsartID;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colVerbrauch;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissCalcEdit edtAngerechnetTot;
        private KiSS4.Gui.KissLookUpEdit edtBaPersonID;
        private KiSS4.Gui.KissMemoEdit edtBemerkung;
        private KiSS4.Gui.KissCalcEdit edtBetrag;
        private KiSS4.Gui.KissLookUpEdit edtBgPositionsartID;
        private KiSS4.Gui.KissCalcEdit edtFreibetrag;
        private KiSS4.Gui.KissCalcEdit edtVerbrauch;
        private decimal free; // freibetrag
        private KiSS4.Gui.KissGrid grdBgPosition;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBgPosition;
        private KiSS4.Gui.KissLabel kissLabel3;
        private KiSS4.Gui.KissLabel kissLabel4;
        private KiSS4.Gui.KissLabel lblBaPersonID;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblBetrag;
        private KiSS4.Gui.KissLabel lblBgPositionsartID;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissLabel lblVerbrauch;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryBgPosition;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumVon;
        private SqlQuery qryBgPositionsart;
        private int BgFinanzplanID;
        private KiSS4.Gui.KissCheckEdit edtNurAktuelle;
        private DateTime finanzplanVon;

        #endregion

        #region Constructors

        public CtlBgVermoegen()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
        }

        public CtlBgVermoegen(Image titelImage, string titelText, int bgBudgetID)
            : this()
        {
            this.picTitel.Image = titelImage;
            this.BgBudgetID = bgBudgetID;
            ShUtil.ApplyShStatusCodeToSqlQuery(this.ActiveSQLQuery, BgBudgetID);

            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT
                    BgFinanzplanID              = SFP.BgFinanzplanID,
                    FinanzplanVon               = IsNull(SFP.DatumVon, SFP.GeplantVon),
                    FinanzplanBis               = IsNull(SFP.DatumBis, SFP.GeplantBis),
                    AnzahlUnterstuetztErwachsen = (SELECT COUNT(*)
                                                   FROM dbo.BgFinanzplan_BaPerson SPP
                                                     INNER JOIN dbo.BaPerson      PRS ON SPP.BaPersonID = PRS.BaPersonID
                                                   WHERE SPP.BgFinanzplanID = SFP.BgFinanzplanID AND SPP.IstUnterstuetzt = 1
                                                     AND DATEADD(yy, 18, PRS.Geburtsdatum) <= IsNull(SFP.DatumVon, SFP.GeplantVon)),
                    AnzahlUnterstuetztKind      = (SELECT COUNT(*)
                                                   FROM dbo.BgFinanzplan_BaPerson SPP
                                                     INNER JOIN dbo.BaPerson      PRS ON SPP.BaPersonID = PRS.BaPersonID
                                                   WHERE SPP.BgFinanzplanID = SFP.BgFinanzplanID AND SPP.IstUnterstuetzt = 1
                                                     AND DATEADD(yy, 18, PRS.Geburtsdatum) > IsNull(SFP.DatumVon, SFP.GeplantVon)) 
                FROM dbo.BgBudget             BBG
                  INNER JOIN dbo.BgFinanzplan SFP ON SFP.BgFinanzplanID = BBG.BgFinanzplanID
                WHERE BBG.BgBudgetID = {0}", bgBudgetID);
            this.BgFinanzplanID = Utils.ConvertToInt(qry["BgFinanzplanID"]);
            finanzplanVon = ((DateTime)qry["FinanzplanVon"]).Date;
            DateTime finanzplanBis = ((DateTime)qry["FinanzplanBis"]).Date;
            int countAdult = (int)qry["AnzahlUnterstuetztErwachsen"];
            int countChild = (int)qry["AnzahlUnterstuetztKind"];
            this.lblTitel.Text = string.Format(this.lblTitel.Text, qry["FinanzplanVon"], qry["FinanzplanBis"], titelText);

            qryBgPositionsart = ShUtil.GetSqlQueryShPositionTyp(BgGruppeCode, LOV.BgKategorieCode.Vermoegen, finanzplanVon, finanzplanBis, false);

            this.edtBgPositionsartID.LoadQuery(qryBgPositionsart);
            this.colBgPositionsartID.ColumnEdit = this.grdBgPosition.GetLOVLookUpEdit(qryBgPositionsart);

            qry = ShUtil.GetPersonen_Unterstuetzt(BgBudgetID);
            this.edtBaPersonID.LoadQuery(qry, "BaPersonID", "NameVorname");

            decimal free;
            #region calculate Freibetrag
            {
                decimal freeAdult = (decimal)DBUtil.GetConfigValue(@"System\Sozialhilfe\SKOS\E2\Erwachsene", null, finanzplanVon);
                decimal freeChild = (decimal)DBUtil.GetConfigValue(@"System\Sozialhilfe\SKOS\E2\Minderjährige", null, finanzplanVon);
                decimal freeMax = (decimal)DBUtil.GetConfigValue(@"System\Sozialhilfe\SKOS\E2\Maximal", null, finanzplanVon);
                free = Math.Min(freeAdult * countAdult + freeChild * countChild, freeMax);
            }
            #endregion
            this.free = free;

            this.qryBgPosition.DataTable.RowChanged += new DataRowChangeEventHandler(DataTable_RowChanged);

            this.qryBgPosition.Fill(qryBgPosition.SelectStatement, BgBudgetID, BgGruppeCode, edtNurAktuelle.Checked);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBgVermoegen));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryBgPosition = new KiSS4.DB.SqlQuery(this.components);
            this.lblBetrag = new KiSS4.Gui.KissLabel();
            this.edtBetrag = new KiSS4.Gui.KissCalcEdit();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.edtBgPositionsartID = new KiSS4.Gui.KissLookUpEdit();
            this.lblBgPositionsartID = new KiSS4.Gui.KissLabel();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.grdBgPosition = new KiSS4.Gui.KissGrid();
            this.grvBgPosition = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBgPositionsartID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerbrauch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.lblVerbrauch = new KiSS4.Gui.KissLabel();
            this.edtVerbrauch = new KiSS4.Gui.KissCalcEdit();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            this.edtFreibetrag = new KiSS4.Gui.KissCalcEdit();
            this.lblBaPersonID = new KiSS4.Gui.KissLabel();
            this.edtBaPersonID = new KiSS4.Gui.KissLookUpEdit();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.edtAngerechnetTot = new KiSS4.Gui.KissCalcEdit();
            this.edtNurAktuelle = new KiSS4.Gui.KissCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionsartID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionsartID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgPositionsartID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerbrauch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerbrauch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFreibetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAngerechnetTot.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurAktuelle.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // qryBgPosition
            // 
            this.qryBgPosition.CanDelete = true;
            this.qryBgPosition.CanInsert = true;
            this.qryBgPosition.CanUpdate = true;
            this.qryBgPosition.HostControl = this;
            this.qryBgPosition.SelectStatement = resources.GetString("qryBgPosition.SelectStatement");
            this.qryBgPosition.TableName = "BgPosition";
            this.qryBgPosition.AfterInsert += new System.EventHandler(this.qryBgPosition_AfterInsert);
            this.qryBgPosition.BeforePost += new System.EventHandler(this.qryBgPosition_BeforePost);
            this.qryBgPosition.AfterPost += new System.EventHandler(this.qryBgPosition_AfterPost);
            this.qryBgPosition.BeforeDelete += new System.EventHandler(this.qryBgPosition_BeforeDelete);
            this.qryBgPosition.AfterDelete += new System.EventHandler(this.qryBgPosition_AfterDelete);
            // 
            // lblBetrag
            // 
            this.lblBetrag.Location = new System.Drawing.Point(8, 279);
            this.lblBetrag.Name = "lblBetrag";
            this.lblBetrag.Size = new System.Drawing.Size(168, 24);
            this.lblBetrag.TabIndex = 5;
            this.lblBetrag.Text = "Vermögen";
            // 
            // edtBetrag
            // 
            this.edtBetrag.DataMember = "Betrag";
            this.edtBetrag.DataSource = this.qryBgPosition;
            this.edtBetrag.Location = new System.Drawing.Point(192, 279);
            this.edtBetrag.Name = "edtBetrag";
            this.edtBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBetrag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBetrag.Properties.DisplayFormat.FormatString = "n2";
            this.edtBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Properties.EditFormat.FormatString = "n2";
            this.edtBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Size = new System.Drawing.Size(112, 24);
            this.edtBetrag.TabIndex = 6;
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblBemerkung.Location = new System.Drawing.Point(8, 335);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(112, 16);
            this.lblBemerkung.TabIndex = 9;
            this.lblBemerkung.Text = "Beschreibung";
            // 
            // edtBgPositionsartID
            // 
            this.edtBgPositionsartID.DataMember = "BgPositionsartID";
            this.edtBgPositionsartID.DataSource = this.qryBgPosition;
            this.edtBgPositionsartID.Location = new System.Drawing.Point(192, 247);
            this.edtBgPositionsartID.Name = "edtBgPositionsartID";
            this.edtBgPositionsartID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBgPositionsartID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgPositionsartID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgPositionsartID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgPositionsartID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgPositionsartID.Properties.Appearance.Options.UseFont = true;
            this.edtBgPositionsartID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBgPositionsartID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgPositionsartID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBgPositionsartID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBgPositionsartID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtBgPositionsartID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtBgPositionsartID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgPositionsartID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name")});
            this.edtBgPositionsartID.Properties.DisplayMember = "Name";
            this.edtBgPositionsartID.Properties.NullText = "";
            this.edtBgPositionsartID.Properties.ShowFooter = false;
            this.edtBgPositionsartID.Properties.ShowHeader = false;
            this.edtBgPositionsartID.Properties.ValueMember = "BgPositionsartID";
            this.edtBgPositionsartID.Size = new System.Drawing.Size(480, 24);
            this.edtBgPositionsartID.TabIndex = 4;
            // 
            // lblBgPositionsartID
            // 
            this.lblBgPositionsartID.Location = new System.Drawing.Point(8, 247);
            this.lblBgPositionsartID.Name = "lblBgPositionsartID";
            this.lblBgPositionsartID.Size = new System.Drawing.Size(144, 24);
            this.lblBgPositionsartID.TabIndex = 3;
            this.lblBgPositionsartID.Text = "Art des Vermögens";
            // 
            // lblTitel
            // 
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(32, 8);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(640, 16);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Vermögen und monatlicher Vermögensverbrauch vom {0:d} bis {1:d}";
            // 
            // grdBgPosition
            // 
            this.grdBgPosition.DataSource = this.qryBgPosition;
            // 
            // 
            // 
            this.grdBgPosition.EmbeddedNavigator.Name = "";
            this.grdBgPosition.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBgPosition.Location = new System.Drawing.Point(8, 30);
            this.grdBgPosition.MainView = this.grvBgPosition;
            this.grdBgPosition.Name = "grdBgPosition";
            this.grdBgPosition.Size = new System.Drawing.Size(664, 140);
            this.grdBgPosition.TabIndex = 1;
            this.grdBgPosition.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBgPosition});
            // 
            // grvBgPosition
            // 
            this.grvBgPosition.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBgPosition.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.Empty.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.Empty.Options.UseFont = true;
            this.grvBgPosition.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
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
            this.grvBgPosition.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.OddRow.Options.UseFont = true;
            this.grvBgPosition.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBgPosition.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.Row.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.Row.Options.UseFont = true;
            this.grvBgPosition.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBgPosition.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBgPosition.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBgPosition.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBgPosition.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatumVon,
            this.colName,
            this.colGeburtsdatum,
            this.colBgPositionsartID,
            this.colBetrag,
            this.colVerbrauch});
            this.grvBgPosition.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBgPosition.GridControl = this.grdBgPosition;
            this.grvBgPosition.Name = "grvBgPosition";
            this.grvBgPosition.OptionsBehavior.Editable = false;
            this.grvBgPosition.OptionsCustomization.AllowFilter = false;
            this.grvBgPosition.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBgPosition.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBgPosition.OptionsNavigation.UseTabKey = false;
            this.grvBgPosition.OptionsView.ColumnAutoWidth = false;
            this.grvBgPosition.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBgPosition.OptionsView.ShowFooter = true;
            this.grvBgPosition.OptionsView.ShowGroupPanel = false;
            this.grvBgPosition.OptionsView.ShowIndicator = false;
            // 
            // colDatumVon
            // 
            this.colDatumVon.Caption = "Gültig ab";
            this.colDatumVon.FieldName = "DatumVon";
            this.colDatumVon.Name = "colDatumVon";
            this.colDatumVon.Visible = true;
            this.colDatumVon.VisibleIndex = 0;
            this.colDatumVon.Width = 60;
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "NameVorname";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 190;
            // 
            // colGeburtsdatum
            // 
            this.colGeburtsdatum.Caption = "Geburtsdatum";
            this.colGeburtsdatum.DisplayFormat.FormatString = "d";
            this.colGeburtsdatum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colGeburtsdatum.FieldName = "Geburtsdatum";
            this.colGeburtsdatum.Name = "colGeburtsdatum";
            this.colGeburtsdatum.Visible = true;
            this.colGeburtsdatum.VisibleIndex = 2;
            this.colGeburtsdatum.Width = 90;
            // 
            // colBgPositionsartID
            // 
            this.colBgPositionsartID.Caption = "Art des Vermögens";
            this.colBgPositionsartID.FieldName = "BgPositionsartID";
            this.colBgPositionsartID.Name = "colBgPositionsartID";
            this.colBgPositionsartID.Visible = true;
            this.colBgPositionsartID.VisibleIndex = 3;
            this.colBgPositionsartID.Width = 177;
            // 
            // colBetrag
            // 
            this.colBetrag.AppearanceCell.Options.UseTextOptions = true;
            this.colBetrag.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colBetrag.Caption = "Vermögen";
            this.colBetrag.DisplayFormat.FormatString = "n2";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.FieldName = "Betrag";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.SummaryItem.DisplayFormat = "{0:n2}";
            this.colBetrag.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 4;
            // 
            // colVerbrauch
            // 
            this.colVerbrauch.AppearanceCell.Options.UseTextOptions = true;
            this.colVerbrauch.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colVerbrauch.Caption = "Verbrauch";
            this.colVerbrauch.DisplayFormat.FormatString = "n2";
            this.colVerbrauch.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colVerbrauch.FieldName = "Verbrauch";
            this.colVerbrauch.Name = "colVerbrauch";
            this.colVerbrauch.SummaryItem.DisplayFormat = "{0:n2}";
            this.colVerbrauch.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colVerbrauch.Visible = true;
            this.colVerbrauch.VisibleIndex = 5;
            this.colVerbrauch.Width = 68;
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryBgPosition;
            this.edtBemerkung.Location = new System.Drawing.Point(8, 351);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(664, 144);
            this.edtBemerkung.TabIndex = 10;
            // 
            // lblVerbrauch
            // 
            this.lblVerbrauch.Location = new System.Drawing.Point(8, 302);
            this.lblVerbrauch.Name = "lblVerbrauch";
            this.lblVerbrauch.Size = new System.Drawing.Size(168, 24);
            this.lblVerbrauch.TabIndex = 7;
            this.lblVerbrauch.Text = "Monatl. Vermögensverbrauch";
            // 
            // edtVerbrauch
            // 
            this.edtVerbrauch.DataMember = "Verbrauch";
            this.edtVerbrauch.DataSource = this.qryBgPosition;
            this.edtVerbrauch.Location = new System.Drawing.Point(192, 302);
            this.edtVerbrauch.Name = "edtVerbrauch";
            this.edtVerbrauch.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVerbrauch.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVerbrauch.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVerbrauch.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVerbrauch.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerbrauch.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVerbrauch.Properties.Appearance.Options.UseFont = true;
            this.edtVerbrauch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVerbrauch.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVerbrauch.Properties.DisplayFormat.FormatString = "n2";
            this.edtVerbrauch.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtVerbrauch.Properties.EditFormat.FormatString = "n2";
            this.edtVerbrauch.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtVerbrauch.Size = new System.Drawing.Size(112, 24);
            this.edtVerbrauch.TabIndex = 8;
            // 
            // picTitel
            // 
            this.picTitel.Location = new System.Drawing.Point(8, 8);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 64;
            this.picTitel.TabStop = false;
            // 
            // kissLabel3
            // 
            this.kissLabel3.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.kissLabel3.Location = new System.Drawing.Point(8, 188);
            this.kissLabel3.Name = "kissLabel3";
            this.kissLabel3.Size = new System.Drawing.Size(112, 23);
            this.kissLabel3.TabIndex = 66;
            this.kissLabel3.Text = "Freibetrag";
            // 
            // edtFreibetrag
            // 
            this.edtFreibetrag.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtFreibetrag.Location = new System.Drawing.Point(192, 188);
            this.edtFreibetrag.Name = "edtFreibetrag";
            this.edtFreibetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtFreibetrag.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtFreibetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFreibetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFreibetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtFreibetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFreibetrag.Properties.Appearance.Options.UseFont = true;
            this.edtFreibetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFreibetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFreibetrag.Properties.DisplayFormat.FormatString = "n2";
            this.edtFreibetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtFreibetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtFreibetrag.Properties.ReadOnly = true;
            this.edtFreibetrag.Size = new System.Drawing.Size(112, 24);
            this.edtFreibetrag.TabIndex = 70;
            // 
            // lblBaPersonID
            // 
            this.lblBaPersonID.Location = new System.Drawing.Point(8, 217);
            this.lblBaPersonID.Name = "lblBaPersonID";
            this.lblBaPersonID.Size = new System.Drawing.Size(143, 24);
            this.lblBaPersonID.TabIndex = 76;
            this.lblBaPersonID.Text = "Person";
            // 
            // edtBaPersonID
            // 
            this.edtBaPersonID.DataMember = "BaPersonID";
            this.edtBaPersonID.DataSource = this.qryBgPosition;
            this.edtBaPersonID.Location = new System.Drawing.Point(192, 217);
            this.edtBaPersonID.Name = "edtBaPersonID";
            this.edtBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBaPersonID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtBaPersonID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaPersonID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.edtBaPersonID.Properties.DisplayMember = "Text";
            this.edtBaPersonID.Properties.NullText = "";
            this.edtBaPersonID.Properties.ShowFooter = false;
            this.edtBaPersonID.Properties.ShowHeader = false;
            this.edtBaPersonID.Properties.ValueMember = "Code";
            this.edtBaPersonID.Size = new System.Drawing.Size(480, 24);
            this.edtBaPersonID.TabIndex = 75;
            // 
            // kissLabel4
            // 
            this.kissLabel4.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.kissLabel4.Location = new System.Drawing.Point(328, 188);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(112, 18);
            this.kissLabel4.TabIndex = 67;
            this.kissLabel4.Text = "Angerechnet";
            // 
            // edtAngerechnetTot
            // 
            this.edtAngerechnetTot.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAngerechnetTot.Location = new System.Drawing.Point(417, 187);
            this.edtAngerechnetTot.Name = "edtAngerechnetTot";
            this.edtAngerechnetTot.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAngerechnetTot.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAngerechnetTot.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAngerechnetTot.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAngerechnetTot.Properties.Appearance.Options.UseBackColor = true;
            this.edtAngerechnetTot.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAngerechnetTot.Properties.Appearance.Options.UseFont = true;
            this.edtAngerechnetTot.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAngerechnetTot.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAngerechnetTot.Properties.DisplayFormat.FormatString = "n2";
            this.edtAngerechnetTot.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtAngerechnetTot.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtAngerechnetTot.Properties.ReadOnly = true;
            this.edtAngerechnetTot.Size = new System.Drawing.Size(112, 24);
            this.edtAngerechnetTot.TabIndex = 71;
            // 
            // edtNurAktuelle
            // 
            this.edtNurAktuelle.EditValue = false;
            this.edtNurAktuelle.Location = new System.Drawing.Point(543, 8);
            this.edtNurAktuelle.Name = "edtNurAktuelle";
            this.edtNurAktuelle.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtNurAktuelle.Properties.Appearance.Options.UseBackColor = true;
            this.edtNurAktuelle.Properties.Caption = "Nur aktive anzeigen";
            this.edtNurAktuelle.Size = new System.Drawing.Size(129, 19);
            this.edtNurAktuelle.TabIndex = 77;
            this.edtNurAktuelle.CheckedChanged += new System.EventHandler(this.edtNurAktive_CheckedChanged);
            // 
            // CtlBgVermoegen
            // 
            this.ActiveSQLQuery = this.qryBgPosition;
            this.Controls.Add(this.edtNurAktuelle);
            this.Controls.Add(this.lblBaPersonID);
            this.Controls.Add(this.edtBaPersonID);
            this.Controls.Add(this.edtAngerechnetTot);
            this.Controls.Add(this.edtFreibetrag);
            this.Controls.Add(this.kissLabel4);
            this.Controls.Add(this.kissLabel3);
            this.Controls.Add(this.picTitel);
            this.Controls.Add(this.lblVerbrauch);
            this.Controls.Add(this.edtVerbrauch);
            this.Controls.Add(this.lblBetrag);
            this.Controls.Add(this.edtBetrag);
            this.Controls.Add(this.lblBemerkung);
            this.Controls.Add(this.edtBgPositionsartID);
            this.Controls.Add(this.lblBgPositionsartID);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.grdBgPosition);
            this.Controls.Add(this.edtBemerkung);
            this.Name = "CtlBgVermoegen";
            this.Size = new System.Drawing.Size(680, 520);
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionsartID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionsartID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgPositionsartID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerbrauch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerbrauch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFreibetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAngerechnetTot.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurAktuelle.Properties)).EndInit();
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

        #region Private Methods

        private void DataTable_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            if (e.Action == DataRowAction.Commit)
            {
                decimal betragTot = 0;
                DataColumn dcBetrag = this.qryBgPosition.DataTable.Columns["Betrag"];

                decimal verbrauchTot = 0;
                DataColumn dcVerbrauch = this.qryBgPosition.DataTable.Columns["Verbrauch"];

                foreach (DataRow row in this.qryBgPosition.DataTable.Rows)
                {
                    object obj;

                    obj = row[dcBetrag];
                    if (!(obj is DBNull))
                        betragTot += (decimal)obj;

                    obj = row[dcVerbrauch];
                    if (!(obj is DBNull))
                        verbrauchTot += (decimal)obj;
                }

                decimal free = Math.Min(this.free, betragTot);

                this.edtFreibetrag.Value = free;
                this.edtAngerechnetTot.Value = betragTot - free;
            }
        }

        private void qryBgPosition_AfterInsert(object sender, System.EventArgs e)
        {
            this.qryBgPosition["BgBudgetID"] = this.BgBudgetID;
            this.qryBgPosition["BgKategorieCode"] = 5;

            this.edtBaPersonID.Focus();
        }

        private void qryBgPosition_BeforePost(object sender, System.EventArgs e)
        {
            DBUtil.CheckNotNullField(edtBgPositionsartID, lblBgPositionsartID.Text);

            DBUtil.CheckNotNullField(edtBetrag, KissMsg.GetMLMessage("CtlBgVermoegen", "Vermoegen", "Vermögen"));
            DBUtil.CheckNotNullField(edtVerbrauch, KissMsg.GetMLMessage("CtlBgVermoegen", "Vermoegensverbrauch", "Vermögensverbrauch"));

            if ((DBUtil.IsEmpty(qryBgPosition["Buchungstext"]) || qryBgPosition.ColumnModified("BgPositionsartID"))
                && qryBgPositionsart.Find(string.Format("BgPositionsartID = {0}", qryBgPosition["BgPositionsartID"])))
            {
                qryBgPosition["Buchungstext"] = qryBgPositionsart["Name"];
            }

            Session.BeginTransaction();
            //da kein Code nach Transaktionsöffung folgt gibts hier nichts zu tun, Rest folgt im After Post
        }

        private void qryBgPosition_AfterPost(object sender, System.EventArgs e)
        {
            try
            {
                SqlQuery qry = DBUtil.OpenSQL(
                    @"SELECT
                    POS.BgPositionID,
                    POS.BgPositionID_Parent,
                    POS.BgPositionID_CopyOf,
                    POS.BgBudgetID,
                    POS.BaPersonID,
                    POS.BgKategorieCode,
                    POS.BgPositionsartID,
                    POS.ShBelegID,
                    POS.Betrag,
                    POS.Reduktion,
                    POS.Abzug,
                    POS.BetragEff,
                    POS.MaxBeitragSD,
                    POS.Buchungstext,
                    POS.BgSpezkontoID,
                    POS.VerwaltungSD,
                    POS.Bemerkung,
                    POS.DatumVon,
                    POS.DatumBis,
                    POS.OldID,
                    POS.BaInstitutionID,
                    POS.DebitorBaPersonID,
                    POS.VerwPeriodeVon,
                    POS.VerwPeriodeBis,
                    POS.FaelligAm,
                    POS.RechnungDatum,
                    POS.BgBewilligungStatusCode,
                    POS.Value1,
                    POS.Value2,
                    POS.Value3,
                    POS.ErstelltUserID,
                    POS.ErstelltDatum,
                    POS.MutiertUserID,
                    POS.MutiertDatum
                  FROM dbo.BgPosition POS
                  WHERE POS.BgPositionID_Parent = {0}"
                    , this.qryBgPosition["BgPositionID"]);

                if (qry.Count == 0)
                {
                    qry.Insert("BgPosition");

                    qry["BgBudgetID"] = this.BgBudgetID;
                    qry["BgPositionID_Parent"] = this.qryBgPosition["BgPositionID"];
                    qry["BgKategorieCode"] = 1;
                    qry["BgPositionsartID"] = ShUtil.GetBgPositionsartID(LOV.BgPositionsArt.Vermoegensverbrauch, finanzplanVon);
                }

                qry["BaPersonID"] = this.qryBgPosition["BaPersonID"];
                qry["Betrag"] = (decimal)this.edtVerbrauch.EditValue;

                if (!qry.Post("BgPosition"))
                {
                    throw new KissCancelException();
                }

                Session.Commit();
            }
            catch (Exception ex)
            {
                // catch über alle Typen von Exceptions muss immer vorhanden sein!
                // hier darf kein Code stehen!
                // Reihenfolge darf hier nicht vertauscht werden!
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
            }

            //Budget runden
            DBUtil.ExecSQLThrowingException("EXEC spWhBudget_Runden {0}", this.BgBudgetID);

            //Die StoredProcedure überprüft die editierte Masterbudget-Position und erstellt gegebenenfalls eine Nachfolge-Position,
            //falls eine Positionsart verwendet wurde, die während der Finanzplan-Laufzeit terminiert wurde.
            DBUtil.ExecSQLThrowingException("EXEC spWhPositionsart_Masterbudget_Terminieren {0}, {1}", this.BgFinanzplanID, qryBgPosition["BgPositionsartID"]);

            //Query Refresh, damit die durch die StoredProcedure veränderten Positionen auch korrekt dargestellt werden
            //Damit kein Endlos-Loop entsteht, müssen wir die aktuelle Zeile unmodified markieren
            this.qryBgPosition.RowModified = false;
            this.qryBgPosition.Refresh();
        }

        //TODO : CtlBgErwerbseinkommen ist sehr analog (weitere) --> refactoring!
        private void qryBgPosition_BeforeDelete(object sender, System.EventArgs e)
        {
			Session.BeginTransaction();
            try
            {
                //vorgängig Positionen mit Parent_ID = <zu löschender ID> löschen
                DBUtil.ExecSQLThrowingException("DELETE FROM BgPosition WHERE BgPositionID_Parent = {0}", this.qryBgPosition["BgPositionID"]);
            }
            catch (Exception ex)
            {
                // catch über alle Typen von Exceptions muss immer vorhanden sein!
                // hier darf kein Code stehen!
                // Reihenfolge darf hier nicht vertauscht werden!
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
                throw new KissCancelException();
            }
        }

        private void qryBgPosition_AfterDelete(object sender, System.EventArgs e)
        {
            try
            {
                Session.Commit();
            }
            catch (Exception ex)
            {
                // catch über alle Typen von Exceptions muss immer vorhanden sein!
                // hier darf kein Code stehen!
                // Reihenfolge darf hier nicht vertauscht werden!
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
            }
        }
        #endregion

        private void edtNurAktive_CheckedChanged(object sender, EventArgs e)
        {
            this.qryBgPosition.Fill(BgBudgetID, BgGruppeCode, edtNurAktuelle.Checked);
        }


    }
}