using System;
using System.Collections;
using System.Drawing;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Sozialhilfe
{
    public class CtlBgWohnkosten : KiSS4.Gui.KissUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const LOV.BgGruppeCode BgGruppeCode = LOV.BgGruppeCode.Wohnkosten;

        #endregion

        #region Private Fields

        private bool abgeschlossen = false;
        private DateTime AnpassenVon;
        private bool bAnpassen = false;
        private int BgBudgetID;
        private KiSS4.Gui.KissButton btnAnpassen;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colNKBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissCalcEdit edtAngerechnet;
        private KiSS4.Gui.KissCalcEdit edtBeitrag;
        private KiSS4.Gui.KissMemoEdit edtBemerkung;
        private KiSS4.Gui.KissLookUpEdit edtBerechnungsgrundlage;
        private KiSS4.Gui.KissCalcEdit edtBetrag;
        private KiSS4.Gui.KissLabel edtHgGrundbedarf;
        private KiSS4.Gui.KissLabel edtHgWohnkosten;
        private KiSS4.Gui.KissLabel edtHgZuschlagI;
        private KiSS4.Gui.KissCalcEdit edtMaxBeitragSD;
        private KiSS4.Gui.KissCalcEdit edtNKBetrag;
        private KiSS4.Gui.KissCalcEdit edtNKMaxBeitragSD;
        private KiSS4.Gui.KissCalcEdit edtTotal;
        private KiSS4.Gui.KissLabel edtUeGrundbedarf;
        private KiSS4.Gui.KissLabel edtUeWohnkosten;
        private KiSS4.Gui.KissLabel edtUeZuschlagI;
        private KiSS4.Gui.KissCalcEdit edtUnterdeckung;
        private KiSS4.Gui.KissCalcEdit edtWohnkosten_Hg;
        private KiSS4.Gui.KissLookUpEdit edtWohnsituation;
        private DateTime finanzplanVon;
        private KiSS4.Gui.KissGroupBox fraKennzahlen;
        private KiSS4.Gui.KissGrid grdBgPosition;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBgPosition;
        private Hashtable ht = new Hashtable();
        private KiSS4.Gui.KissLabel kissLabel21;
        private KiSS4.Gui.KissLabel kissLabel22;
        private KiSS4.Gui.KissLabel lblAnpassen;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblBerechnungsgrundlage;
        private KiSS4.Gui.KissLabel lblGrundbedarfI;
        private KiSS4.Gui.KissLabel lblGrundbedarfII;
        private KiSS4.Gui.KissLabel lblGrundbedarfIIAnpassung;
        private KiSS4.Gui.KissLabel lblGrundbedarfIZuschlag;
        private KiSS4.Gui.KissLabel lblHg;
        private KiSS4.Gui.KissLabel lblHgGrundbedarf;
        private KiSS4.Gui.KissLabel lblHgWohnkosten;
        private KiSS4.Gui.KissLabel lblHgZuschlagI;
        private KiSS4.Gui.KissLabel lblRichtlinien;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissLabel lblTotalGrundbedarf;
        private KiSS4.Gui.KissLabel lblUE;
        private KiSS4.Gui.KissLabel lblUeGrundbedarf;
        private KiSS4.Gui.KissLabel lblUeWohnkosten;
        private KiSS4.Gui.KissLabel lblUeZuschlagI;
        private KiSS4.Gui.KissLabel lblWohnsituation;
        private System.Windows.Forms.PictureBox picTitel;
        private SqlQuery qryBgFinanzplan;
        private KiSS4.DB.SqlQuery qryBgPosition;
        private SqlQuery qryBgPositionsart;
        private KiSS4.DB.SqlQuery qryWhKennzahlen;
        private object RntHgUeFactor;

        #endregion

        #endregion

        #region Constructors

        public CtlBgWohnkosten()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
        }

        public CtlBgWohnkosten(Image titelImage, string titelText, int bgBudgetID)
            : this()
        {
            this.picTitel.Image = titelImage;
            this.BgBudgetID = bgBudgetID;

            lblAnpassen.Text = "";

            qryBgFinanzplan = DBUtil.OpenSQL(@"
                SELECT FLE.FaFallID, FLE.FaLeistungID, SFP.BgFinanzplanID,
                  SFP.WhGrundbedarfTypCode,
                  BgBewilligungStatusCode = CASE WHEN FLE.DatumBis IS NOT NULL THEN 9 ELSE SFP.BgBewilligungStatusCode END,
                  FinanzplanVon    = IsNull(SFP.DatumVon, SFP.GeplantVon),
                  FinanzplanBis    = IsNull(SFP.DatumBis, SFP.GeplantBis),
                  AnpassenVon      = IsNull((SELECT MAX(DATEADD(m, 1, dbo.fnDateSerial(Jahr, Monat, 1))) FROM BgBudget
                                             WHERE BgFinanzplanID = SFP.BgFinanzplanID AND MasterBudget = 0
                                               AND BgBewilligungStatusCode >= 5), SFP.GeplantVon),
                  AnpassenBis      = SFP.DatumBis,
                  LeistungDatumBis = FLE.DatumBis
                FROM BgBudget             BBG
                  INNER JOIN BgFinanzplan SFP ON SFP.BgFinanzplanID = BBG.BgFinanzplanID
                  INNER JOIN FaLeistung   FLE ON FLE.FaLeistungID = SFP.FaLeistungID
                WHERE BBG.BgBudgetID = {0}"
                , bgBudgetID);

            this.abgeschlossen = !DBUtil.IsEmpty(qryBgFinanzplan["LeistungDatumBis"]);
            this.finanzplanVon = Utils.ConvertToDateTime(qryBgFinanzplan["FinanzplanVon"]);
            DateTime finanzplanBis = Utils.ConvertToDateTime(qryBgFinanzplan["FinanzplanBis"]);
            this.btnAnpassen.Enabled = this.ActiveSQLQuery.CanUpdate && !this.abgeschlossen;
            ShUtil.ApplyShStatusCodeToSqlQuery(this.ActiveSQLQuery, BgBudgetID);
            this.btnAnpassen.Enabled = this.ActiveSQLQuery.CanUpdate ? false : this.btnAnpassen.Enabled;

            this.lblTitel.Text = string.Format(this.lblTitel.Text, qryBgFinanzplan["FinanzplanVon"], qryBgFinanzplan["FinanzplanBis"], titelText);

            switch (Utils.ConvertToInt(qryBgFinanzplan["WhGrundbedarfTypCode"]))
            {
                case 32015:
                case 32016:
                case 32017:
                case 32018:
                    this.lblHgZuschlagI.Visible = false;
                    this.edtHgZuschlagI.Visible = false;
                    this.lblUeZuschlagI.Visible = false;
                    this.edtUeZuschlagI.Visible = false;
                    break;

                case 32019:
                case 32011:
                default:
                    this.lblHgZuschlagI.Visible = true;
                    this.edtHgZuschlagI.Visible = true;
                    this.lblUeZuschlagI.Visible = true;
                    this.edtUeZuschlagI.Visible = true;
                    break;
            }

            qryBgPositionsart = DBUtil.OpenSQL(@"
                SELECT DISTINCT
                  Code = SPT.BgPositionsartCode - (SPT.BgPositionsartCode % 2),
                  Text = LTRIM(SUBSTRING(SPT.Name, 1, LEN(SPT.Name) - CHARINDEX('-', REVERSE(SPT.Name)) - 1)),
                  SPT.SortKey
                FROM WhPositionsart     SPT
                WHERE SPT.BgKategorieCode = 2
                AND SPT.BgPositionsartCode <> 32060 AND SPT.BgGruppeCode = {0}
                AND ISNULL(SPT.DatumVon, '1900-01-01') <= {2} AND ISNULL(SPT.DatumBis, '2999-12-31') >= {1}
                ORDER BY SPT.SortKey", BgGruppeCode, finanzplanVon, finanzplanBis);
            this.edtWohnsituation.LoadQuery(qryBgPositionsart);

            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT Code = 0, Text = 'Wohnkosten gem. Richtlinien bestimmen'
                UNION ALL
                SELECT 1, 'Wohnkosten individuell bestimmen'");
            this.edtBerechnungsgrundlage.LoadQuery(qry);

            this.qryBgPosition.Fill(qryBgPosition.SelectStatement, BgBudgetID, BgGruppeCode);

            qryWhKennzahlen.Fill(qryBgFinanzplan["BgFinanzplanID"]);

            RntHgUeFactor = qryWhKennzahlen["RntHgUeFactor"];
            if (DBUtil.IsEmpty(RntHgUeFactor))
                RntHgUeFactor = 1;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBgWohnkosten));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.qryBgPosition = new KiSS4.DB.SqlQuery(this.components);
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.lblWohnsituation = new KiSS4.Gui.KissLabel();
            this.edtWohnsituation = new KiSS4.Gui.KissLookUpEdit();
            this.lblTotalGrundbedarf = new KiSS4.Gui.KissLabel();
            this.lblHg = new KiSS4.Gui.KissLabel();
            this.lblUE = new KiSS4.Gui.KissLabel();
            this.lblGrundbedarfIIAnpassung = new KiSS4.Gui.KissLabel();
            this.lblRichtlinien = new KiSS4.Gui.KissLabel();
            this.lblGrundbedarfII = new KiSS4.Gui.KissLabel();
            this.lblGrundbedarfIZuschlag = new KiSS4.Gui.KissLabel();
            this.lblGrundbedarfI = new KiSS4.Gui.KissLabel();
            this.edtUnterdeckung = new KiSS4.Gui.KissCalcEdit();
            this.edtNKMaxBeitragSD = new KiSS4.Gui.KissCalcEdit();
            this.edtBetrag = new KiSS4.Gui.KissCalcEdit();
            this.edtBeitrag = new KiSS4.Gui.KissCalcEdit();
            this.edtTotal = new KiSS4.Gui.KissCalcEdit();
            this.edtAngerechnet = new KiSS4.Gui.KissCalcEdit();
            this.edtMaxBeitragSD = new KiSS4.Gui.KissCalcEdit();
            this.lblBerechnungsgrundlage = new KiSS4.Gui.KissLabel();
            this.edtBerechnungsgrundlage = new KiSS4.Gui.KissLookUpEdit();
            this.edtWohnkosten_Hg = new KiSS4.Gui.KissCalcEdit();
            this.edtNKBetrag = new KiSS4.Gui.KissCalcEdit();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.grdBgPosition = new KiSS4.Gui.KissGrid();
            this.grvBgPosition = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNKBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAnpassen = new KiSS4.Gui.KissButton();
            this.lblAnpassen = new KiSS4.Gui.KissLabel();
            this.fraKennzahlen = new KiSS4.Gui.KissGroupBox();
            this.edtHgZuschlagI = new KiSS4.Gui.KissLabel();
            this.qryWhKennzahlen = new KiSS4.DB.SqlQuery(this.components);
            this.lblHgZuschlagI = new KiSS4.Gui.KissLabel();
            this.kissLabel22 = new KiSS4.Gui.KissLabel();
            this.kissLabel21 = new KiSS4.Gui.KissLabel();
            this.edtUeZuschlagI = new KiSS4.Gui.KissLabel();
            this.lblUeZuschlagI = new KiSS4.Gui.KissLabel();
            this.edtUeWohnkosten = new KiSS4.Gui.KissLabel();
            this.lblUeWohnkosten = new KiSS4.Gui.KissLabel();
            this.lblUeGrundbedarf = new KiSS4.Gui.KissLabel();
            this.edtUeGrundbedarf = new KiSS4.Gui.KissLabel();
            this.edtHgWohnkosten = new KiSS4.Gui.KissLabel();
            this.lblHgWohnkosten = new KiSS4.Gui.KissLabel();
            this.lblHgGrundbedarf = new KiSS4.Gui.KissLabel();
            this.edtHgGrundbedarf = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWohnsituation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsituation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsituation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalGrundbedarf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundbedarfIIAnpassung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRichtlinien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundbedarfII)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundbedarfIZuschlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundbedarfI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUnterdeckung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNKMaxBeitragSD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeitrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAngerechnet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMaxBeitragSD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBerechnungsgrundlage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBerechnungsgrundlage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBerechnungsgrundlage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnkosten_Hg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNKBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnpassen)).BeginInit();
            this.fraKennzahlen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtHgZuschlagI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryWhKennzahlen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHgZuschlagI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeZuschlagI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUeZuschlagI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeWohnkosten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUeWohnkosten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUeGrundbedarf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeGrundbedarf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHgWohnkosten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHgWohnkosten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHgGrundbedarf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHgGrundbedarf)).BeginInit();
            this.SuspendLayout();
            //
            // lblTitel
            //
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(32, 8);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(640, 16);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Monatliche Wohnkosten vom {0:d} bis {1:d}";
            //
            // qryBgPosition
            //
            this.qryBgPosition.CanUpdate = true;
            this.qryBgPosition.FillTimeOut = 600;
            this.qryBgPosition.HostControl = this;
            this.qryBgPosition.InsertTimeOut = 600;
            this.qryBgPosition.SelectStatement = resources.GetString("qryBgPosition.SelectStatement");
            this.qryBgPosition.TableName = "BgPosition";
            this.qryBgPosition.UpdateTimeOut = 600;
            this.qryBgPosition.BeforePost += new System.EventHandler(this.qryBgPosition_BeforePost);
            this.qryBgPosition.AfterPost += new System.EventHandler(this.qryBgPosition_AfterPost);
            this.qryBgPosition.PositionChanged += new System.EventHandler(this.qryBgPosition_PositionChanged);
            this.qryBgPosition.ColumnChanged += new System.Data.DataColumnChangeEventHandler(this.qryBgPosition_ColumnChanged);
            //
            // lblBemerkung
            //
            this.lblBemerkung.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblBemerkung.Location = new System.Drawing.Point(352, 240);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(304, 16);
            this.lblBemerkung.TabIndex = 23;
            this.lblBemerkung.Text = "Begründungen";
            //
            // edtBemerkung
            //
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryBgPosition;
            this.edtBemerkung.Location = new System.Drawing.Point(352, 256);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(320, 192);
            this.edtBemerkung.TabIndex = 24;
            //
            // lblWohnsituation
            //
            this.lblWohnsituation.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblWohnsituation.Location = new System.Drawing.Point(8, 136);
            this.lblWohnsituation.Name = "lblWohnsituation";
            this.lblWohnsituation.Size = new System.Drawing.Size(304, 16);
            this.lblWohnsituation.TabIndex = 1;
            this.lblWohnsituation.Text = "Wohnsituation";
            //
            // edtWohnsituation
            //
            this.edtWohnsituation.DataMember = "Wohnsituation";
            this.edtWohnsituation.DataSource = this.qryBgPosition;
            this.edtWohnsituation.Location = new System.Drawing.Point(8, 152);
            this.edtWohnsituation.Name = "edtWohnsituation";
            this.edtWohnsituation.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
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
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtWohnsituation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtWohnsituation.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtWohnsituation.Properties.NullText = "";
            this.edtWohnsituation.Properties.ShowFooter = false;
            this.edtWohnsituation.Properties.ShowHeader = false;
            this.edtWohnsituation.Size = new System.Drawing.Size(336, 24);
            this.edtWohnsituation.TabIndex = 2;
            //
            // lblTotalGrundbedarf
            //
            this.lblTotalGrundbedarf.Location = new System.Drawing.Point(8, 424);
            this.lblTotalGrundbedarf.Name = "lblTotalGrundbedarf";
            this.lblTotalGrundbedarf.Size = new System.Drawing.Size(248, 24);
            this.lblTotalGrundbedarf.TabIndex = 20;
            this.lblTotalGrundbedarf.Text = "Angerechneter Wohnkostenanteil inkl. NK";
            //
            // lblHg
            //
            this.lblHg.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblHg.Location = new System.Drawing.Point(176, 240);
            this.lblHg.Name = "lblHg";
            this.lblHg.Size = new System.Drawing.Size(80, 16);
            this.lblHg.TabIndex = 6;
            this.lblHg.Text = "für HG";
            //
            // lblUE
            //
            this.lblUE.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblUE.Location = new System.Drawing.Point(264, 240);
            this.lblUE.Name = "lblUE";
            this.lblUE.Size = new System.Drawing.Size(80, 16);
            this.lblUE.TabIndex = 8;
            this.lblUE.Text = "für UE";
            //
            // lblGrundbedarfIIAnpassung
            //
            this.lblGrundbedarfIIAnpassung.Location = new System.Drawing.Point(8, 384);
            this.lblGrundbedarfIIAnpassung.Name = "lblGrundbedarfIIAnpassung";
            this.lblGrundbedarfIIAnpassung.Size = new System.Drawing.Size(160, 24);
            this.lblGrundbedarfIIAnpassung.TabIndex = 17;
            this.lblGrundbedarfIIAnpassung.Text = "Effektive Nebenkosten";
            //
            // lblRichtlinien
            //
            this.lblRichtlinien.Location = new System.Drawing.Point(8, 279);
            this.lblRichtlinien.Name = "lblRichtlinien";
            this.lblRichtlinien.Size = new System.Drawing.Size(248, 24);
            this.lblRichtlinien.TabIndex = 10;
            this.lblRichtlinien.Text = "Ansatz gemäss Richtlinien";
            //
            // lblGrundbedarfII
            //
            this.lblGrundbedarfII.Location = new System.Drawing.Point(8, 343);
            this.lblGrundbedarfII.Name = "lblGrundbedarfII";
            this.lblGrundbedarfII.Size = new System.Drawing.Size(248, 24);
            this.lblGrundbedarfII.TabIndex = 15;
            this.lblGrundbedarfII.Text = "Unterdeckter Anteil zulasten Klient";
            //
            // lblGrundbedarfIZuschlag
            //
            this.lblGrundbedarfIZuschlag.Location = new System.Drawing.Point(8, 320);
            this.lblGrundbedarfIZuschlag.Name = "lblGrundbedarfIZuschlag";
            this.lblGrundbedarfIZuschlag.Size = new System.Drawing.Size(248, 24);
            this.lblGrundbedarfIZuschlag.TabIndex = 13;
            this.lblGrundbedarfIZuschlag.Text = "Angerechneter Wohnkostenanteil exkl. NK";
            //
            // lblGrundbedarfI
            //
            this.lblGrundbedarfI.Location = new System.Drawing.Point(8, 256);
            this.lblGrundbedarfI.Name = "lblGrundbedarfI";
            this.lblGrundbedarfI.Size = new System.Drawing.Size(160, 24);
            this.lblGrundbedarfI.TabIndex = 5;
            this.lblGrundbedarfI.Text = "Effektive Miet- rsp. Zinskosten";
            //
            // edtUnterdeckung
            //
            this.edtUnterdeckung.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtUnterdeckung.Location = new System.Drawing.Point(264, 343);
            this.edtUnterdeckung.Name = "edtUnterdeckung";
            this.edtUnterdeckung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtUnterdeckung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtUnterdeckung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUnterdeckung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUnterdeckung.Properties.Appearance.Options.UseBackColor = true;
            this.edtUnterdeckung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUnterdeckung.Properties.Appearance.Options.UseFont = true;
            this.edtUnterdeckung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtUnterdeckung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUnterdeckung.Properties.DisplayFormat.FormatString = "n2";
            this.edtUnterdeckung.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtUnterdeckung.Properties.EditFormat.FormatString = "n2";
            this.edtUnterdeckung.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtUnterdeckung.Properties.ReadOnly = true;
            this.edtUnterdeckung.Size = new System.Drawing.Size(80, 24);
            this.edtUnterdeckung.TabIndex = 16;
            //
            // edtNKMaxBeitragSD
            //
            this.edtNKMaxBeitragSD.DataMember = "NKMaxBeitragSD";
            this.edtNKMaxBeitragSD.DataSource = this.qryBgPosition;
            this.edtNKMaxBeitragSD.Location = new System.Drawing.Point(264, 384);
            this.edtNKMaxBeitragSD.Name = "edtNKMaxBeitragSD";
            this.edtNKMaxBeitragSD.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtNKMaxBeitragSD.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNKMaxBeitragSD.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNKMaxBeitragSD.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNKMaxBeitragSD.Properties.Appearance.Options.UseBackColor = true;
            this.edtNKMaxBeitragSD.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNKMaxBeitragSD.Properties.Appearance.Options.UseFont = true;
            this.edtNKMaxBeitragSD.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNKMaxBeitragSD.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNKMaxBeitragSD.Properties.DisplayFormat.FormatString = "n2";
            this.edtNKMaxBeitragSD.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtNKMaxBeitragSD.Properties.EditFormat.FormatString = "n2";
            this.edtNKMaxBeitragSD.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtNKMaxBeitragSD.Size = new System.Drawing.Size(80, 24);
            this.edtNKMaxBeitragSD.TabIndex = 19;
            //
            // edtBetrag
            //
            this.edtBetrag.DataMember = "Betrag";
            this.edtBetrag.DataSource = this.qryBgPosition;
            this.edtBetrag.Location = new System.Drawing.Point(176, 256);
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
            this.edtBetrag.Size = new System.Drawing.Size(80, 24);
            this.edtBetrag.TabIndex = 7;
            //
            // edtBeitrag
            //
            this.edtBeitrag.DataMember = "Beitrag";
            this.edtBeitrag.DataSource = this.qryBgPosition;
            this.edtBeitrag.Location = new System.Drawing.Point(264, 256);
            this.edtBeitrag.Name = "edtBeitrag";
            this.edtBeitrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBeitrag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBeitrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBeitrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBeitrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtBeitrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBeitrag.Properties.Appearance.Options.UseFont = true;
            this.edtBeitrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBeitrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBeitrag.Properties.DisplayFormat.FormatString = "n2";
            this.edtBeitrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBeitrag.Properties.EditFormat.FormatString = "n2";
            this.edtBeitrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBeitrag.Size = new System.Drawing.Size(80, 24);
            this.edtBeitrag.TabIndex = 9;
            //
            // edtTotal
            //
            this.edtTotal.DataMember = "Total";
            this.edtTotal.DataSource = this.qryBgPosition;
            this.edtTotal.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtTotal.Location = new System.Drawing.Point(264, 424);
            this.edtTotal.Name = "edtTotal";
            this.edtTotal.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtTotal.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtTotal.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTotal.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTotal.Properties.Appearance.Options.UseBackColor = true;
            this.edtTotal.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTotal.Properties.Appearance.Options.UseFont = true;
            this.edtTotal.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTotal.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTotal.Properties.DisplayFormat.FormatString = "n2";
            this.edtTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtTotal.Properties.EditFormat.FormatString = "n2";
            this.edtTotal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtTotal.Properties.ReadOnly = true;
            this.edtTotal.Size = new System.Drawing.Size(80, 24);
            this.edtTotal.TabIndex = 21;
            //
            // edtAngerechnet
            //
            this.edtAngerechnet.DataSource = this.qryBgPosition;
            this.edtAngerechnet.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAngerechnet.Location = new System.Drawing.Point(264, 320);
            this.edtAngerechnet.Name = "edtAngerechnet";
            this.edtAngerechnet.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAngerechnet.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAngerechnet.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAngerechnet.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAngerechnet.Properties.Appearance.Options.UseBackColor = true;
            this.edtAngerechnet.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAngerechnet.Properties.Appearance.Options.UseFont = true;
            this.edtAngerechnet.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAngerechnet.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAngerechnet.Properties.DisplayFormat.FormatString = "n2";
            this.edtAngerechnet.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtAngerechnet.Properties.EditFormat.FormatString = "n2";
            this.edtAngerechnet.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtAngerechnet.Properties.ReadOnly = true;
            this.edtAngerechnet.Size = new System.Drawing.Size(80, 24);
            this.edtAngerechnet.TabIndex = 14;
            //
            // edtMaxBeitragSD
            //
            this.edtMaxBeitragSD.DataMember = "MaxBeitragSD";
            this.edtMaxBeitragSD.DataSource = this.qryBgPosition;
            this.edtMaxBeitragSD.Location = new System.Drawing.Point(264, 279);
            this.edtMaxBeitragSD.Name = "edtMaxBeitragSD";
            this.edtMaxBeitragSD.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtMaxBeitragSD.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMaxBeitragSD.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMaxBeitragSD.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMaxBeitragSD.Properties.Appearance.Options.UseBackColor = true;
            this.edtMaxBeitragSD.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMaxBeitragSD.Properties.Appearance.Options.UseFont = true;
            this.edtMaxBeitragSD.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMaxBeitragSD.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtMaxBeitragSD.Properties.DisplayFormat.FormatString = "n2";
            this.edtMaxBeitragSD.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtMaxBeitragSD.Properties.EditFormat.FormatString = "n2";
            this.edtMaxBeitragSD.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtMaxBeitragSD.Size = new System.Drawing.Size(80, 24);
            this.edtMaxBeitragSD.TabIndex = 12;
            //
            // lblBerechnungsgrundlage
            //
            this.lblBerechnungsgrundlage.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblBerechnungsgrundlage.Location = new System.Drawing.Point(8, 184);
            this.lblBerechnungsgrundlage.Name = "lblBerechnungsgrundlage";
            this.lblBerechnungsgrundlage.Size = new System.Drawing.Size(304, 16);
            this.lblBerechnungsgrundlage.TabIndex = 3;
            this.lblBerechnungsgrundlage.Text = "Berechnungsgrundlage";
            //
            // edtBerechnungsgrundlage
            //
            this.edtBerechnungsgrundlage.DataMember = "Berechnungsgrundlage";
            this.edtBerechnungsgrundlage.DataSource = this.qryBgPosition;
            this.edtBerechnungsgrundlage.Location = new System.Drawing.Point(8, 200);
            this.edtBerechnungsgrundlage.Name = "edtBerechnungsgrundlage";
            this.edtBerechnungsgrundlage.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBerechnungsgrundlage.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBerechnungsgrundlage.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBerechnungsgrundlage.Properties.Appearance.Options.UseBackColor = true;
            this.edtBerechnungsgrundlage.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBerechnungsgrundlage.Properties.Appearance.Options.UseFont = true;
            this.edtBerechnungsgrundlage.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBerechnungsgrundlage.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBerechnungsgrundlage.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBerechnungsgrundlage.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBerechnungsgrundlage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtBerechnungsgrundlage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtBerechnungsgrundlage.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBerechnungsgrundlage.Properties.NullText = "";
            this.edtBerechnungsgrundlage.Properties.ShowFooter = false;
            this.edtBerechnungsgrundlage.Properties.ShowHeader = false;
            this.edtBerechnungsgrundlage.Size = new System.Drawing.Size(336, 24);
            this.edtBerechnungsgrundlage.TabIndex = 4;
            this.edtBerechnungsgrundlage.EditValueChanged += new System.EventHandler(this.edtBerechnungsgrundlage_EditValueChanged);
            //
            // edtWohnkosten_Hg
            //
            this.edtWohnkosten_Hg.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtWohnkosten_Hg.Location = new System.Drawing.Point(176, 279);
            this.edtWohnkosten_Hg.Name = "edtWohnkosten_Hg";
            this.edtWohnkosten_Hg.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtWohnkosten_Hg.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtWohnkosten_Hg.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWohnkosten_Hg.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWohnkosten_Hg.Properties.Appearance.Options.UseBackColor = true;
            this.edtWohnkosten_Hg.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWohnkosten_Hg.Properties.Appearance.Options.UseFont = true;
            this.edtWohnkosten_Hg.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtWohnkosten_Hg.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtWohnkosten_Hg.Properties.DisplayFormat.FormatString = "n2";
            this.edtWohnkosten_Hg.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtWohnkosten_Hg.Properties.EditFormat.FormatString = "n2";
            this.edtWohnkosten_Hg.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtWohnkosten_Hg.Properties.ReadOnly = true;
            this.edtWohnkosten_Hg.Size = new System.Drawing.Size(80, 24);
            this.edtWohnkosten_Hg.TabIndex = 11;
            //
            // edtNKBetrag
            //
            this.edtNKBetrag.DataMember = "NKBetrag";
            this.edtNKBetrag.DataSource = this.qryBgPosition;
            this.edtNKBetrag.Location = new System.Drawing.Point(176, 384);
            this.edtNKBetrag.Name = "edtNKBetrag";
            this.edtNKBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtNKBetrag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNKBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNKBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNKBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtNKBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNKBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtNKBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNKBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNKBetrag.Properties.DisplayFormat.FormatString = "n2";
            this.edtNKBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtNKBetrag.Properties.EditFormat.FormatString = "n2";
            this.edtNKBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtNKBetrag.Size = new System.Drawing.Size(80, 24);
            this.edtNKBetrag.TabIndex = 18;
            //
            // picTitel
            //
            this.picTitel.Location = new System.Drawing.Point(8, 8);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 76;
            this.picTitel.TabStop = false;
            //
            // grdBgPosition
            //
            this.grdBgPosition.DataSource = this.qryBgPosition;
            //
            //
            //
            this.grdBgPosition.EmbeddedNavigator.Name = "";
            this.grdBgPosition.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBgPosition.Location = new System.Drawing.Point(8, 32);
            this.grdBgPosition.MainView = this.grvBgPosition;
            this.grdBgPosition.Name = "grdBgPosition";
            this.grdBgPosition.Size = new System.Drawing.Size(664, 96);
            this.grdBgPosition.TabIndex = 78;
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
            this.colBetrag,
            this.colNKBetrag,
            this.colTotal});
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
            this.grvBgPosition.OptionsView.ShowGroupPanel = false;
            this.grvBgPosition.OptionsView.ShowIndicator = false;
            //
            // colDatumVon
            //
            this.colDatumVon.Caption = "Gültig ab";
            this.colDatumVon.DisplayFormat.FormatString = "Y";
            this.colDatumVon.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDatumVon.FieldName = "DatumVon";
            this.colDatumVon.Name = "colDatumVon";
            this.colDatumVon.Visible = true;
            this.colDatumVon.VisibleIndex = 0;
            this.colDatumVon.Width = 110;
            //
            // colBetrag
            //
            this.colBetrag.Caption = "Miete";
            this.colBetrag.DisplayFormat.FormatString = "n2";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.FieldName = "Betrag";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 1;
            this.colBetrag.Width = 85;
            //
            // colNKBetrag
            //
            this.colNKBetrag.Caption = "Nebenkosten";
            this.colNKBetrag.DisplayFormat.FormatString = "n2";
            this.colNKBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colNKBetrag.FieldName = "NKBetrag";
            this.colNKBetrag.Name = "colNKBetrag";
            this.colNKBetrag.Visible = true;
            this.colNKBetrag.VisibleIndex = 2;
            this.colNKBetrag.Width = 85;
            //
            // colTotal
            //
            this.colTotal.Caption = "Angerechnet";
            this.colTotal.DisplayFormat.FormatString = "n2";
            this.colTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotal.FieldName = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 3;
            this.colTotal.Width = 85;
            //
            // btnAnpassen
            //
            this.btnAnpassen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnpassen.Location = new System.Drawing.Point(424, 480);
            this.btnAnpassen.Name = "btnAnpassen";
            this.btnAnpassen.Size = new System.Drawing.Size(248, 24);
            this.btnAnpassen.TabIndex = 79;
            this.btnAnpassen.Text = "bewilligte Wohnkosten anpassen ...";
            this.btnAnpassen.UseVisualStyleBackColor = false;
            this.btnAnpassen.Click += new System.EventHandler(this.cmdAnpassen_Click);
            //
            // lblAnpassen
            //
            this.lblAnpassen.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblAnpassen.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblAnpassen.Location = new System.Drawing.Point(104, 486);
            this.lblAnpassen.Name = "lblAnpassen";
            this.lblAnpassen.Size = new System.Drawing.Size(304, 16);
            this.lblAnpassen.TabIndex = 80;
            this.lblAnpassen.Text = "Anpassen";
            this.lblAnpassen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // fraKennzahlen
            //
            this.fraKennzahlen.Controls.Add(this.edtHgZuschlagI);
            this.fraKennzahlen.Controls.Add(this.lblHgZuschlagI);
            this.fraKennzahlen.Controls.Add(this.kissLabel22);
            this.fraKennzahlen.Controls.Add(this.kissLabel21);
            this.fraKennzahlen.Controls.Add(this.edtUeZuschlagI);
            this.fraKennzahlen.Controls.Add(this.lblUeZuschlagI);
            this.fraKennzahlen.Controls.Add(this.edtUeWohnkosten);
            this.fraKennzahlen.Controls.Add(this.lblUeWohnkosten);
            this.fraKennzahlen.Controls.Add(this.lblUeGrundbedarf);
            this.fraKennzahlen.Controls.Add(this.edtUeGrundbedarf);
            this.fraKennzahlen.Controls.Add(this.edtHgWohnkosten);
            this.fraKennzahlen.Controls.Add(this.lblHgWohnkosten);
            this.fraKennzahlen.Controls.Add(this.lblHgGrundbedarf);
            this.fraKennzahlen.Controls.Add(this.edtHgGrundbedarf);
            this.fraKennzahlen.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.fraKennzahlen.Location = new System.Drawing.Point(352, 144);
            this.fraKennzahlen.Name = "fraKennzahlen";
            this.fraKennzahlen.Size = new System.Drawing.Size(320, 88);
            this.fraKennzahlen.TabIndex = 81;
            this.fraKennzahlen.TabStop = false;
            this.fraKennzahlen.Text = "Kennzahlen";
            //
            // edtHgZuschlagI
            //
            this.edtHgZuschlagI.DataMember = "HgZuschlagI";
            this.edtHgZuschlagI.DataSource = this.qryWhKennzahlen;
            this.edtHgZuschlagI.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.edtHgZuschlagI.Location = new System.Drawing.Point(83, 67);
            this.edtHgZuschlagI.Name = "edtHgZuschlagI";
            this.edtHgZuschlagI.Size = new System.Drawing.Size(24, 16);
            this.edtHgZuschlagI.TabIndex = 13;
            //
            // qryWhKennzahlen
            //
            this.qryWhKennzahlen.HostControl = this;
            this.qryWhKennzahlen.SelectStatement = "SELECT * FROM dbo.fnWhKennzahlen({0})";
            //
            // lblHgZuschlagI
            //
            this.lblHgZuschlagI.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblHgZuschlagI.Location = new System.Drawing.Point(11, 67);
            this.lblHgZuschlagI.Name = "lblHgZuschlagI";
            this.lblHgZuschlagI.Size = new System.Drawing.Size(72, 16);
            this.lblHgZuschlagI.TabIndex = 12;
            this.lblHgZuschlagI.Text = "Zuschlag I";
            //
            // kissLabel22
            //
            this.kissLabel22.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel22.Location = new System.Drawing.Point(147, 19);
            this.kissLabel22.Name = "kissLabel22";
            this.kissLabel22.Size = new System.Drawing.Size(152, 16);
            this.kissLabel22.TabIndex = 5;
            this.kissLabel22.Text = "Unterstützungseinheit";
            //
            // kissLabel21
            //
            this.kissLabel21.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel21.Location = new System.Drawing.Point(11, 19);
            this.kissLabel21.Name = "kissLabel21";
            this.kissLabel21.Size = new System.Drawing.Size(120, 16);
            this.kissLabel21.TabIndex = 0;
            this.kissLabel21.Text = "Haushaltsgrösse";
            //
            // edtUeZuschlagI
            //
            this.edtUeZuschlagI.DataMember = "UeZuschlagI";
            this.edtUeZuschlagI.DataSource = this.qryWhKennzahlen;
            this.edtUeZuschlagI.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.edtUeZuschlagI.Location = new System.Drawing.Point(219, 67);
            this.edtUeZuschlagI.Name = "edtUeZuschlagI";
            this.edtUeZuschlagI.Size = new System.Drawing.Size(24, 16);
            this.edtUeZuschlagI.TabIndex = 11;
            //
            // lblUeZuschlagI
            //
            this.lblUeZuschlagI.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblUeZuschlagI.Location = new System.Drawing.Point(147, 67);
            this.lblUeZuschlagI.Name = "lblUeZuschlagI";
            this.lblUeZuschlagI.Size = new System.Drawing.Size(72, 16);
            this.lblUeZuschlagI.TabIndex = 10;
            this.lblUeZuschlagI.Text = "Zuschlag I";
            //
            // edtUeWohnkosten
            //
            this.edtUeWohnkosten.DataMember = "UeWohnkosten";
            this.edtUeWohnkosten.DataSource = this.qryWhKennzahlen;
            this.edtUeWohnkosten.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.edtUeWohnkosten.Location = new System.Drawing.Point(219, 51);
            this.edtUeWohnkosten.Name = "edtUeWohnkosten";
            this.edtUeWohnkosten.Size = new System.Drawing.Size(24, 16);
            this.edtUeWohnkosten.TabIndex = 9;
            //
            // lblUeWohnkosten
            //
            this.lblUeWohnkosten.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblUeWohnkosten.Location = new System.Drawing.Point(147, 51);
            this.lblUeWohnkosten.Name = "lblUeWohnkosten";
            this.lblUeWohnkosten.Size = new System.Drawing.Size(72, 16);
            this.lblUeWohnkosten.TabIndex = 8;
            this.lblUeWohnkosten.Text = "Wohnkosten";
            //
            // lblUeGrundbedarf
            //
            this.lblUeGrundbedarf.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblUeGrundbedarf.Location = new System.Drawing.Point(147, 35);
            this.lblUeGrundbedarf.Name = "lblUeGrundbedarf";
            this.lblUeGrundbedarf.Size = new System.Drawing.Size(72, 16);
            this.lblUeGrundbedarf.TabIndex = 6;
            this.lblUeGrundbedarf.Text = "Grundbedarf";
            //
            // edtUeGrundbedarf
            //
            this.edtUeGrundbedarf.DataMember = "UeGrundbedarf";
            this.edtUeGrundbedarf.DataSource = this.qryWhKennzahlen;
            this.edtUeGrundbedarf.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.edtUeGrundbedarf.Location = new System.Drawing.Point(219, 35);
            this.edtUeGrundbedarf.Name = "edtUeGrundbedarf";
            this.edtUeGrundbedarf.Size = new System.Drawing.Size(24, 16);
            this.edtUeGrundbedarf.TabIndex = 7;
            //
            // edtHgWohnkosten
            //
            this.edtHgWohnkosten.DataMember = "HgWohnkosten";
            this.edtHgWohnkosten.DataSource = this.qryWhKennzahlen;
            this.edtHgWohnkosten.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.edtHgWohnkosten.Location = new System.Drawing.Point(83, 51);
            this.edtHgWohnkosten.Name = "edtHgWohnkosten";
            this.edtHgWohnkosten.Size = new System.Drawing.Size(24, 16);
            this.edtHgWohnkosten.TabIndex = 4;
            //
            // lblHgWohnkosten
            //
            this.lblHgWohnkosten.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblHgWohnkosten.Location = new System.Drawing.Point(11, 51);
            this.lblHgWohnkosten.Name = "lblHgWohnkosten";
            this.lblHgWohnkosten.Size = new System.Drawing.Size(72, 16);
            this.lblHgWohnkosten.TabIndex = 3;
            this.lblHgWohnkosten.Text = "Wohnkosten";
            //
            // lblHgGrundbedarf
            //
            this.lblHgGrundbedarf.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblHgGrundbedarf.Location = new System.Drawing.Point(11, 35);
            this.lblHgGrundbedarf.Name = "lblHgGrundbedarf";
            this.lblHgGrundbedarf.Size = new System.Drawing.Size(72, 16);
            this.lblHgGrundbedarf.TabIndex = 1;
            this.lblHgGrundbedarf.Text = "Grundbedarf";
            //
            // edtHgGrundbedarf
            //
            this.edtHgGrundbedarf.DataMember = "HgGrundbedarf";
            this.edtHgGrundbedarf.DataSource = this.qryWhKennzahlen;
            this.edtHgGrundbedarf.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.edtHgGrundbedarf.Location = new System.Drawing.Point(83, 35);
            this.edtHgGrundbedarf.Name = "edtHgGrundbedarf";
            this.edtHgGrundbedarf.Size = new System.Drawing.Size(24, 16);
            this.edtHgGrundbedarf.TabIndex = 2;
            //
            // CtlBgWohnkosten
            //
            this.ActiveSQLQuery = this.qryBgPosition;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(680, 520);
            this.Controls.Add(this.fraKennzahlen);
            this.Controls.Add(this.lblAnpassen);
            this.Controls.Add(this.btnAnpassen);
            this.Controls.Add(this.grdBgPosition);
            this.Controls.Add(this.lblGrundbedarfI);
            this.Controls.Add(this.edtBetrag);
            this.Controls.Add(this.edtBeitrag);
            this.Controls.Add(this.picTitel);
            this.Controls.Add(this.edtNKBetrag);
            this.Controls.Add(this.edtWohnkosten_Hg);
            this.Controls.Add(this.lblBerechnungsgrundlage);
            this.Controls.Add(this.edtBerechnungsgrundlage);
            this.Controls.Add(this.lblTotalGrundbedarf);
            this.Controls.Add(this.lblHg);
            this.Controls.Add(this.lblUE);
            this.Controls.Add(this.lblGrundbedarfIIAnpassung);
            this.Controls.Add(this.lblRichtlinien);
            this.Controls.Add(this.lblGrundbedarfII);
            this.Controls.Add(this.lblGrundbedarfIZuschlag);
            this.Controls.Add(this.edtUnterdeckung);
            this.Controls.Add(this.edtNKMaxBeitragSD);
            this.Controls.Add(this.edtTotal);
            this.Controls.Add(this.edtAngerechnet);
            this.Controls.Add(this.edtMaxBeitragSD);
            this.Controls.Add(this.lblBemerkung);
            this.Controls.Add(this.edtBemerkung);
            this.Controls.Add(this.lblWohnsituation);
            this.Controls.Add(this.edtWohnsituation);
            this.Controls.Add(this.lblTitel);
            this.Name = "CtlBgWohnkosten";
            this.Size = new System.Drawing.Size(680, 520);
            this.Load += new System.EventHandler(this.CtlBgWohnkosten_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWohnsituation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsituation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsituation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalGrundbedarf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundbedarfIIAnpassung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRichtlinien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundbedarfII)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundbedarfIZuschlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundbedarfI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUnterdeckung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNKMaxBeitragSD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeitrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAngerechnet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMaxBeitragSD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBerechnungsgrundlage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBerechnungsgrundlage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBerechnungsgrundlage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnkosten_Hg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNKBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnpassen)).EndInit();
            this.fraKennzahlen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtHgZuschlagI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryWhKennzahlen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHgZuschlagI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeZuschlagI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUeZuschlagI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeWohnkosten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUeWohnkosten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUeGrundbedarf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeGrundbedarf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHgWohnkosten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHgWohnkosten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHgGrundbedarf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHgGrundbedarf)).EndInit();
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

        private void cmdAnpassen_Click(object sender, EventArgs e)
        {
            if (!((IKissDataNavigator)this).SaveData())
            {
                return;
            }

            if (bAnpassen)
            {
                bAnpassen = false;
                lblAnpassen.Text = "";
                btnAnpassen.Text = "Wohnkosten anpassen...";
                qryBgPosition.CanUpdate = false;
                qryBgPosition.EnableBoundFields(false);

                qryBgPosition.Refresh();
                qryBgPosition.DataTable.DefaultView.RowFilter = "";
                return;
            }

            DlgWhPositionAnpassen dlg = new DlgWhPositionAnpassen(DlgWhPositionAnpassen.AnpassungTyp.Wohnkosten
                , (DateTime)qryBgFinanzplan["AnpassenVon"], (DateTime)this.qryBgFinanzplan["AnpassenBis"]);

            dlg.ShowDialog(this);

            if (dlg.UserCancel)
            {
                return;
            }

            bAnpassen = true;
            AnpassenVon = dlg.DatumVon;

            qryBgPosition.DataTable.DefaultView.RowFilter = string.Format("Anpassung = 1 OR (IsNull(DatumVon, {0}) <= {0} AND (DatumBis > {0} OR DatumBis IS NULL))"
                , AnpassenVon.ToString(@"\#MM\/dd\/yyyy\#"));

            lblAnpassen.Text = string.Format("Die Wohnkosten gelten ab {0:Y}", AnpassenVon);
            btnAnpassen.Text = "Bearbeitung abschliessen";
            qryBgPosition.CanUpdate = true;
            edtBerechnungsgrundlage.EditMode = EditModeType.ReadOnly;
            edtMaxBeitragSD.EditMode = EditModeType.ReadOnly;
            qryBgPosition.EnableBoundFields(true);

            // Calculate Richtlinien per 'AnpassenVon'
            CalcRichtlinien(AnpassenVon);
            ReCalc(false);
        }

        private void CtlBgWohnkosten_Load(object sender, System.EventArgs e)
        {
            while (this.qryBgPosition["DatumBis"] != DBNull.Value &&
                   ((DateTime)this.qryBgPosition["DatumBis"]).Date < DateTime.Today &&
                   this.qryBgPosition.Next()) { }
        }

        private void edtBerechnungsgrundlage_EditValueChanged(object sender, EventArgs e)
        {
            qryBgPosition["Berechnungsgrundlage"] = edtBerechnungsgrundlage.EditValue;  //force column changed event
            SetLayout();
        }

        private void qryBgPosition_AfterPost(object sender, EventArgs e)
        {
            DBUtil.ExecSQLThrowingException(@"
                UPDATE BgPosition
                   SET Betrag       = IsNull({1}, $0.00),
                       Reduktion    = CONVERT(money, dbo.fnMax(IsNull({1}, $0.00) - IsNull({2}, $0.00), $0.00)),
                       Abzug        = $0.00,
                       MaxBeitragSD = IsNull({2}, $0.00),
                       DatumVon     = {3},
                       DatumBis     = {4}
                WHERE BgPositionID_Parent = {0}"
                , this.qryBgPosition["BgPositionID"]
                , this.qryBgPosition["NKBetrag"]
                , this.qryBgPosition["NKMaxBeitragSD"]
                , this.qryBgPosition["DatumVon"]
                , this.qryBgPosition["DatumBis"]);

            // Monatsbudget auf 0.05 Beträge runden
            DBUtil.ExecSQL("EXECUTE spWhBudget_Runden {0}", this.BgBudgetID);

            // Monatsbudget Beträge anpassen
            if (this.bAnpassen)
            {
                DBUtil.ExecSQL(600, "EXECUTE spWhFinanzplan_Bewilligen {0}, {1}, {2}",
                    qryBgFinanzplan["BgFinanzplanID"], qryBgPosition["DatumVon"], qryBgPosition["BgPositionID"]);
            }

            Session.Commit();

            //Query Refresh, damit die durch die StoredProcedure veränderten Positionen auch korrekt dargestellt werden
            //Damit kein Endlos-Loop entsteht, müssen wir die aktuelle Zeile unmodified markieren
            this.qryBgPosition.RowModified = false;
            this.qryBgPosition.Refresh();
        }

        private void qryBgPosition_BeforePost(object sender, System.EventArgs e)
        {
            DBUtil.CheckNotNullField(this.edtBetrag, KissMsg.GetMLMessage("CtlBgWohnkosten", "Miete", "Miete"));
            DBUtil.CheckNotNullField(this.edtBeitrag, KissMsg.GetMLMessage("CtlBgWohnkosten", "MieteUE", "Miete UE"));
            DBUtil.CheckNotNullField(this.edtMaxBeitragSD, KissMsg.GetMLMessage("CtlBgWohnkosten", "Angerechnet", "Angerechnet"));
            DBUtil.CheckNotNullField(this.edtNKBetrag, KissMsg.GetMLMessage("CtlBgWohnkosten", "Nebenkosten", "Nebenkosten"));
            DBUtil.CheckNotNullField(this.edtNKMaxBeitragSD, KissMsg.GetMLMessage("CtlBgWohnkosten", "NebenkostenUE", "Nebenkosten UE"));

            if ((decimal)this.qryBgPosition["Betrag"] < (decimal)this.qryBgPosition["Beitrag"])
                throw new DB.KissInfoException(KissMsg.GetMLMessage("CtlBgWohnkosten", "AnteilGroesserGesamtmiete", "Der Mietanteil der UE ist grösser als die gesammte Miete", KissMsgCode.MsgInfo), this.edtBeitrag);

            if ((decimal)this.qryBgPosition["NKBetrag"] < (decimal)this.qryBgPosition["NKMaxBeitragSD"])
                throw new DB.KissInfoException(KissMsg.GetMLMessage("CtlBgWohnkosten", "AnteilGroesserGesamtnebenkosten", "Der Nebenkostenanteil der UE ist grösser als die gesammten Nebenkosten", KissMsgCode.MsgInfo), this.edtNKMaxBeitragSD);

            int positionsartCode = (int)this.edtWohnsituation.EditValue + (int)this.qryBgPosition["Berechnungsgrundlage"];
            DateTime stichTag = bAnpassen ? AnpassenVon : finanzplanVon;
            this.qryBgPosition["BgPositionsartID"] = ShUtil.GetBgPositionsartID(positionsartCode, stichTag);

            if ((int)this.qryBgPosition["Berechnungsgrundlage"] == 1)
                this.qryBgPosition["Reduktion"] = (decimal)this.qryBgPosition["Betrag"] - (decimal)this.qryBgPosition["Beitrag"];
            else if (!DBUtil.IsEmpty(RntHgUeFactor))
                this.qryBgPosition["Reduktion"] = (decimal)this.qryBgPosition["Betrag"] * (Convert.ToDecimal(1) - Convert.ToDecimal(RntHgUeFactor));

            this.qryBgPosition["Abzug"] = (decimal)this.qryBgPosition["Betrag"] - (decimal)this.qryBgPosition["Reduktion"] - (decimal)this.qryBgPosition["MaxBeitragSD"];
            if ((decimal)this.qryBgPosition["Abzug"] < (decimal)0)
                this.qryBgPosition["Abzug"] = (decimal)0;

            if (this.bAnpassen && !KissMsg.ShowQuestion("CtlBgWohnkosten", "AenderungWohnkosten", "Sie ändern die Wohnkosten eines aktiven Finanzplanes!\r\n\r\nSollen diese Änderungen gespeichert und alle betroffenen Monatsbudgets angepasst werden?"))
            {
                this.qryBgPosition.Row.RejectChanges();
                this.qryBgPosition.RowModified = false;
                this.cmdAnpassen_Click(this, EventArgs.Empty);
                throw new KissCancelException();
            }

            Session.BeginTransaction();
            try
            {
                if (bAnpassen)
                {
                    this.qryBgPosition["DatumVon"] = this.AnpassenVon;
                    this.qryBgPosition["Anpassung"] = 1;

                    if (!DBUtil.IsEmpty(qryBgPosition["BgPositionID"]))
                    {
                        SqlQuery qry = DBUtil.OpenSQL(@"
                        SELECT DISTINCT BgPositionID AS Pk, BgPositionID_Parent AS Parent, CONVERT(int, NULL) AS KeyNew
                        INTO #BgPosition
                        FROM BgPosition WHERE BgBudgetID = {0} AND (BgPositionID = {1} OR BgPositionID_Parent = {1})

                        EXECUTE spXParentChildCopy '#BgPosition',
                                                   'BgPosition', 'BgPositionID', 'BgPositionID_Parent',
                                                   'BgPositionID_CopyOf', 'BgPositionID', 'OldID, BgBewilligungStatusCode'

                        SELECT BPO.*, TMP.Pk
                        FROM #BgPosition           TMP
                          INNER JOIN vwBgPosition  BPO ON BPO.BgPositionID = TMP.KeyNew
                        ORDER BY CASE WHEN Pk = {0} THEN 0 ELSE 1 END

                        DROP TABLE #BgPosition"
                            , this.BgBudgetID, this.qryBgPosition["BgPositionID"]);

                        string[] columnNames = new string[] { "BgPositionID", "BgPositionID_CopyOf", "BgBewilligungStatusCode", "BgPositionTS" };

                        object[] currentValue = this.qryBgPosition.Row.ItemArray;

                        this.qryBgPosition.Row.RejectChanges();

                        foreach (string columnName in columnNames)
                        {
                            if (this.qryBgPosition.DataTable.Columns.Contains(columnName))
                                this.qryBgPosition[columnName] = qry[columnName];
                        }

                        this.qryBgPosition.Row.AcceptChanges();

                        this.qryBgPosition.Row.ItemArray = currentValue;

                        foreach (string columnName in columnNames)
                        {
                            if (this.qryBgPosition.DataTable.Columns.Contains(columnName))
                                this.qryBgPosition[columnName] = qry[columnName];
                        }
                    }
                }
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

        private void qryBgPosition_ColumnChanged(object sender, System.Data.DataColumnChangeEventArgs e)
        {
            int Berechnungsgrundlage = (int)this.qryBgPosition["Berechnungsgrundlage"];

            if (Berechnungsgrundlage != 1)
            {
                if (e.Column.ColumnName == "MaxBeitragSD")
                    return;
                if (e.Column.ColumnName == "Beitrag")
                    return;
                if (e.Column.ColumnName == "NKMaxBeitragSD")
                    return;
            }
            if (e.Column.ColumnName == "Total")
                return;

            ReCalc();
        }

        private void qryBgPosition_PositionChanged(object sender, System.EventArgs e)
        {
            if (bAnpassen)
            {
                grvBgPosition.RefreshData();
            }
            CalcRichtlinien(qryBgPosition["DatumVon"] as DateTime?);
            SetLayout();
            ReCalc();
        }

        #endregion

        #region Methods

        #region Private Methods

        private void CalcRichtlinien(DateTime? stichTag)
        {
            var qryRichtlinien = DBUtil.OpenSQL(@"
                SELECT Wohnkosten_Hg = dbo.fnShWohnkosten_Hg({0}, {1});", qryBgFinanzplan["BgFinanzplanID"], stichTag);

            var wohnkostenHgAlt = edtWohnkosten_Hg.EditValue;
            edtWohnkosten_Hg.EditValue = qryRichtlinien["Wohnkosten_Hg"];

            if (qryBgPosition.CanUpdate && wohnkostenHgAlt != edtWohnkosten_Hg.EditValue)
            {
                qryBgPosition.RowModified = true;
            }
        }

        private void ReCalc(bool applyData = true)
        {
            try
            {
                var berechnungsgrundlage = Convert.ToInt32(qryBgPosition["Berechnungsgrundlage"]);

                if (berechnungsgrundlage != 1)
                {
                    // nach Richtlinie
                    var calculatedBeitragSd = ShUtil.RoundMoney(edtWohnkosten_Hg.Value * Convert.ToDecimal(RntHgUeFactor));

                    // #7769: Mark query as changed if calculated MaxBeitragSD does not match with BgPosition.MaxBeitragSD value on database.
                    //        With this change, we ensure that the user will get the message to recalc budget positions, too.
                    if (qryBgPosition.CanUpdate && !DBUtil.IsEmpty(qryBgPosition[DBO.BgPosition.BgPositionID]))
                    {
                        // get current value saved on database
                        var qryBgPosOnDB = DBUtil.OpenSQL(@"
                            SELECT MaxBeitragSD
                            FROM dbo.BgPosition
                            WHERE BgPositionID = {0};", qryBgPosition[DBO.BgPosition.BgPositionID]);

                        var maxBeitragSdOnDB = !DBUtil.IsEmpty(qryBgPosOnDB[DBO.BgPosition.MaxBeitragSD]) ? Convert.ToDecimal(qryBgPosOnDB[DBO.BgPosition.MaxBeitragSD]) : null as decimal?;

                        if (maxBeitragSdOnDB.HasValue &&
                            !Convert.ToDecimal(calculatedBeitragSd).Equals(maxBeitragSdOnDB.Value))
                        {
                            // data has changed (possible due to changed config value), so we need to recalc budgets
                            qryBgPosition.RowModified = true;
                        }
                    }

                    if (applyData)
                    {
                        qryBgPosition[DBO.BgPosition.MaxBeitragSD] = calculatedBeitragSd;

                        if (!DBUtil.IsEmpty(qryBgPosition[DBO.BgPosition.Betrag]))
                        {
                            qryBgPosition["Beitrag"] =
                                ShUtil.RoundMoney(Convert.ToDecimal(qryBgPosition[DBO.BgPosition.Betrag]) * Convert.ToDecimal(RntHgUeFactor));
                        }

                        if (!DBUtil.IsEmpty(qryBgPosition["NKBetrag"]))
                        {
                            qryBgPosition["NKMaxBeitragSD"] =
                                ShUtil.RoundMoney(Convert.ToDecimal(qryBgPosition["NKBetrag"]) * Convert.ToDecimal(RntHgUeFactor));
                        }
                    }
                } // [if (berechnungsgrundlage != 1)]
                if (applyData)
                {
                    edtAngerechnet.EditValue = Math.Min((decimal)qryBgPosition[DBO.BgPosition.MaxBeitragSD], (decimal)qryBgPosition["Beitrag"]);
                    edtUnterdeckung.EditValue = (decimal)qryBgPosition["Beitrag"] - (decimal)edtAngerechnet.EditValue;

                    if ((decimal)edtUnterdeckung.EditValue < 0)
                    {
                        edtUnterdeckung.EditValue = 0;
                    }

                    qryBgPosition["Total"] = Convert.ToDecimal(edtAngerechnet.EditValue) +
                                             Convert.ToDecimal(qryBgPosition["NKMaxBeitragSD"]);
                }
            }
            catch (Exception ex)
            {
                XLog.Create(GetType().FullName, LogLevel.ERROR, "Error in Recalc()", ex.Message);
            }

            if (!qryBgPosition.CanUpdate)
            {
                qryBgPosition.RowModified = false;
                qryBgPosition.Row.AcceptChanges();
            }

            qryBgPosition.RefreshDisplay();
        }

        private void SetLayout()
        {
            try
            {
                var berechnungsgrundlage = (int)qryBgPosition["Berechnungsgrundlage"];

                if (berechnungsgrundlage == 1)
                {
                    this.lblRichtlinien.Text = "Angerechnete Miet- rsp. Zinskosten";
                    this.edtBeitrag.EditMode = Kiss.Interfaces.UI.EditModeType.Normal;
                    this.edtWohnkosten_Hg.Visible = false;
                    this.edtMaxBeitragSD.EditMode = this.bAnpassen ? Kiss.Interfaces.UI.EditModeType.ReadOnly : Kiss.Interfaces.UI.EditModeType.Normal;
                    this.edtNKMaxBeitragSD.EditMode = Kiss.Interfaces.UI.EditModeType.Normal;
                }
                else
                {
                    this.lblRichtlinien.Text = "Ansatz gemäss Richtlinien";
                    this.edtBeitrag.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
                    this.edtWohnkosten_Hg.Visible = true;
                    this.edtMaxBeitragSD.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
                    this.edtNKMaxBeitragSD.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
                }

                this.qryBgPosition.EnableBoundFields();
            }
            catch { }
        }

        #endregion

        #endregion
    }
}