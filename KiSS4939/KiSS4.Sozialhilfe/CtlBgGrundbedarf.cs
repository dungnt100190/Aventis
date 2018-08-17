using System;
using System.Drawing;

using KiSS4.DB;
using KiSS4.Gui;

using KiSS.DBScheme;

namespace KiSS4.Sozialhilfe
{
    public class CtlBgGrundbedarf : KiSS4.Gui.KissUserControl
    {
        #region Fields

        #region Private Fields

        private int BgBudgetID;
        private int BgFinanzplanID;
        private KiSS4.Gui.KissCheckEdit chkGBII_Einzel;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissCalcEdit edtAbzugVVG;
        private KiSS4.Gui.KissCalcEdit edtAbzugVVG_SKOS;
        private KiSS4.Gui.KissCalcEdit edtAnpassung;
        private KiSS4.Gui.KissMemoEdit edtBemerkung;
        private KiSS4.Gui.KissCalcEdit edtBetrag;
        private KiSS4.Gui.KissLookUpEdit edtBgPositionsartCode;
        private KissCalcEdit edtELSE_Anpassung;
        private KiSS4.Gui.KissCalcEdit edtELSE_Betrag;
        private KiSS4.Gui.KissCalcEdit edtELSE_Total;
        private KiSS4.Gui.KissCalcEdit edtGBI_Hg;
        private KiSS4.Gui.KissCalcEdit edtGBII_Hg;
        private KiSS4.Gui.KissCalcEdit edtGBIIAnpassung;
        private KiSS4.Gui.KissCalcEdit edtGBIZuschlag_Hg;
        private KiSS4.Gui.KissCalcEdit edtGrundbedarfII;
        private KiSS4.Gui.KissCalcEdit edtGrundbedarfTotal;
        private KiSS4.Gui.KissCalcEdit edtGrundbedarfZusatz;
        private KiSS4.Gui.KissLabel edtHgGrundbedarf;
        private KiSS4.Gui.KissLabel edtHgWohnkosten;
        private KiSS4.Gui.KissCalcEdit edtSKOS2005_AbzugVVG;
        private KiSS4.Gui.KissCalcEdit edtSKOS2005_Anpassung;
        private KiSS4.Gui.KissCalcEdit edtSKOS2005_Total;
        private KiSS4.Gui.KissCalcEdit edtSKOS2005_UE;
        private KiSS4.Gui.KissLabel edtUeGrundbedarf;
        private KiSS4.Gui.KissLabel edtUeWohnkosten;
        private KiSS4.Gui.KissLabel edtUeZuschlagI;
        private KiSS4.Gui.KissGroupBox fraELSE;
        private KiSS4.Gui.KissGroupBox fraKennzahlen;
        private KiSS4.Gui.KissGroupBox fraSKOS;
        private KiSS4.Gui.KissGroupBox fraSKOS2005;
        private KiSS4.Gui.KissCalcEdit kissCalcEdit2;
        private KiSS4.Gui.KissLabel kissLabel21;
        private KiSS4.Gui.KissLabel kissLabel22;
        private KiSS4.Gui.KissLabel kissLabel3;
        private KiSS4.Gui.KissLabel kissLabel4;
        private KiSS4.Gui.KissLabel kissLabel5;
        private KiSS4.Gui.KissLabel kissLabel6;
        private KiSS4.Gui.KissLabel kissLabel7;
        private KiSS4.Gui.KissLabel lblAbzugVVG;
        private KiSS4.Gui.KissLabel lblAbzugVVG_SKOS;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblBerechnungsgrundlage;
        private KissLabel lblELSE_Anpassung;
        private KiSS4.Gui.KissLabel lblELSE_Betrag;
        private KiSS4.Gui.KissLabel lblELSE_Total;
        private KiSS4.Gui.KissLabel lblGrundbedarfI;
        private KiSS4.Gui.KissLabel lblGrundbedarfIAnpassung;
        private KiSS4.Gui.KissLabel lblGrundbedarfII;
        private KiSS4.Gui.KissLabel lblGrundbedarfIIAnpassung;
        private KiSS4.Gui.KissLabel lblGrundbedarfIZuschlag;
        private KiSS4.Gui.KissLabel lblHg;
        private KiSS4.Gui.KissLabel lblHgGrundbedarf;
        private KiSS4.Gui.KissLabel lblHgWohnkosten;
        private KiSS4.Gui.KissLabel lblSKOS2005_Anpassung;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissLabel lblTotalGrundbedarf;
        private KiSS4.Gui.KissLabel lblUE;
        private KiSS4.Gui.KissLabel lblUeGrundbedarf;
        private KiSS4.Gui.KissLabel lblUeWohnkosten;
        private KiSS4.Gui.KissLabel lblUeZuschlagI;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryBgPosition;
        private SqlQuery qryBgPositionsart;
        private KiSS4.DB.SqlQuery qryKennzahlen;

        #endregion

        #endregion

        #region Constructors

        public CtlBgGrundbedarf()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            this.chkGBII_Einzel.EditValueChanged += new System.EventHandler(edtSKOS_Leave);
            this.edtGBIIAnpassung.Leave += new System.EventHandler(edtSKOS_Leave);
            this.edtAnpassung.Leave += new System.EventHandler(edtSKOS_Leave);

            this.edtSKOS2005_Anpassung.Leave += new System.EventHandler(edtSKOS2005_Leave);

            this.edtELSE_Betrag.Leave += new System.EventHandler(edtELSE_Leave);
            this.edtELSE_Anpassung.Leave += new EventHandler(edtELSE_Leave);
        }

        public CtlBgGrundbedarf(Image titelImage, string titelText, int bgBudgetID)
            : this()
        {
            picTitel.Image = titelImage;

            var qryBgFinanzplan = DBUtil.OpenSQL(@"
                SELECT FPL.BgFinanzplanID,
                       FPL.BgBewilligungStatusCode
                FROM dbo.BgBudget BDG WITH (READUNCOMMITTED)
                  INNER JOIN dbo.BgFinanzplan FPL WITH (READUNCOMMITTED) ON FPL.BgFinanzplanID = BDG.BgFinanzplanID
                WHERE BDG.BgBudgetID = {0};", bgBudgetID);

            BgBudgetID = bgBudgetID;
            BgFinanzplanID = Convert.ToInt32(qryBgFinanzplan[DBO.BgFinanzplan.BgFinanzplanID]);
            var fpBewilligungsStatusCode = Convert.ToInt32(qryBgFinanzplan[DBO.BgFinanzplan.BgBewilligungStatusCode]);

            // recalculate GBI,GBII ...
            // #7769: recalc is only done if edit is allowed
            if (fpBewilligungsStatusCode != Convert.ToInt32(BgBewilligungStatus.Erteilt) &&
                fpBewilligungsStatusCode != Convert.ToInt32(BgBewilligungStatus.Gesperrt))
            {
                DBUtil.ExecSQLThrowingException(@"
                    EXECUTE dbo.spWhFinanzplan_Update {0};", BgFinanzplanID);
            }

            var qry = DBUtil.OpenSQL(@"
                SELECT BBG.BgFinanzplanID,
                       FinanzplanVon = ISNULL(SFP.DatumVon, SFP.GeplantVon),
                       FinanzplanBis = ISNULL(SFP.DatumBis, SFP.GeplantBis)
                FROM dbo.BgBudget             BBG
                  INNER JOIN dbo.BgFinanzplan SFP ON SFP.BgFinanzplanID = BBG.BgFinanzplanID
                WHERE BBG.BgBudgetID = {0};", BgBudgetID);

            lblTitel.Text = string.Format(lblTitel.Text, qry["FinanzplanVon"], qry["FinanzplanBis"], titelText);

            qryKennzahlen.Fill(qry[DBO.BgFinanzplan.BgFinanzplanID]);

            //make sure, we only have valid Positionsarten in the dropdown
            qryBgPositionsart.Fill(qry["FinanzplanVon"], qry["FinanzplanBis"]);
            edtBgPositionsartCode.LoadQuery(qryBgPositionsart);

            ShUtil.ApplyShStatusCodeToSqlQuery(ActiveSQLQuery, BgBudgetID);
            qryBgPosition.Fill(qryBgPosition.SelectStatement, BgBudgetID, edtBgPositionsartCode.LOVName);

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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBgGrundbedarf));
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.edtBgPositionsartCode = new KiSS4.Gui.KissLookUpEdit();
            this.qryBgPosition = new KiSS4.DB.SqlQuery(this.components);
            this.lblBerechnungsgrundlage = new KiSS4.Gui.KissLabel();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fraELSE = new KiSS4.Gui.KissGroupBox();
            this.lblELSE_Anpassung = new KiSS4.Gui.KissLabel();
            this.edtELSE_Anpassung = new KiSS4.Gui.KissCalcEdit();
            this.lblELSE_Betrag = new KiSS4.Gui.KissLabel();
            this.lblELSE_Total = new KiSS4.Gui.KissLabel();
            this.edtELSE_Total = new KiSS4.Gui.KissCalcEdit();
            this.lblAbzugVVG = new KiSS4.Gui.KissLabel();
            this.edtAbzugVVG = new KiSS4.Gui.KissCalcEdit();
            this.edtELSE_Betrag = new KiSS4.Gui.KissCalcEdit();
            this.fraSKOS2005 = new KiSS4.Gui.KissGroupBox();
            this.kissCalcEdit2 = new KiSS4.Gui.KissCalcEdit();
            this.lblSKOS2005_Anpassung = new KiSS4.Gui.KissLabel();
            this.edtSKOS2005_Anpassung = new KiSS4.Gui.KissCalcEdit();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.kissLabel5 = new KiSS4.Gui.KissLabel();
            this.kissLabel6 = new KiSS4.Gui.KissLabel();
            this.edtSKOS2005_Total = new KiSS4.Gui.KissCalcEdit();
            this.kissLabel7 = new KiSS4.Gui.KissLabel();
            this.edtSKOS2005_AbzugVVG = new KiSS4.Gui.KissCalcEdit();
            this.edtSKOS2005_UE = new KiSS4.Gui.KissCalcEdit();
            this.fraSKOS = new KiSS4.Gui.KissGroupBox();
            this.lblAbzugVVG_SKOS = new KiSS4.Gui.KissLabel();
            this.edtAbzugVVG_SKOS = new KiSS4.Gui.KissCalcEdit();
            this.edtGBII_Hg = new KiSS4.Gui.KissCalcEdit();
            this.edtGBI_Hg = new KiSS4.Gui.KissCalcEdit();
            this.lblTotalGrundbedarf = new KiSS4.Gui.KissLabel();
            this.lblHg = new KiSS4.Gui.KissLabel();
            this.lblUE = new KiSS4.Gui.KissLabel();
            this.lblGrundbedarfIIAnpassung = new KiSS4.Gui.KissLabel();
            this.lblGrundbedarfIAnpassung = new KiSS4.Gui.KissLabel();
            this.lblGrundbedarfII = new KiSS4.Gui.KissLabel();
            this.lblGrundbedarfIZuschlag = new KiSS4.Gui.KissLabel();
            this.lblGrundbedarfI = new KiSS4.Gui.KissLabel();
            this.chkGBII_Einzel = new KiSS4.Gui.KissCheckEdit();
            this.edtGrundbedarfII = new KiSS4.Gui.KissCalcEdit();
            this.edtGBIIAnpassung = new KiSS4.Gui.KissCalcEdit();
            this.edtBetrag = new KiSS4.Gui.KissCalcEdit();
            this.edtGrundbedarfTotal = new KiSS4.Gui.KissCalcEdit();
            this.edtGrundbedarfZusatz = new KiSS4.Gui.KissCalcEdit();
            this.edtGBIZuschlag_Hg = new KiSS4.Gui.KissCalcEdit();
            this.edtAnpassung = new KiSS4.Gui.KissCalcEdit();
            this.fraKennzahlen = new KiSS4.Gui.KissGroupBox();
            this.kissLabel22 = new KiSS4.Gui.KissLabel();
            this.kissLabel21 = new KiSS4.Gui.KissLabel();
            this.edtUeZuschlagI = new KiSS4.Gui.KissLabel();
            this.qryKennzahlen = new KiSS4.DB.SqlQuery(this.components);
            this.lblUeZuschlagI = new KiSS4.Gui.KissLabel();
            this.edtUeWohnkosten = new KiSS4.Gui.KissLabel();
            this.lblUeWohnkosten = new KiSS4.Gui.KissLabel();
            this.lblUeGrundbedarf = new KiSS4.Gui.KissLabel();
            this.edtUeGrundbedarf = new KiSS4.Gui.KissLabel();
            this.edtHgWohnkosten = new KiSS4.Gui.KissLabel();
            this.lblHgWohnkosten = new KiSS4.Gui.KissLabel();
            this.lblHgGrundbedarf = new KiSS4.Gui.KissLabel();
            this.edtHgGrundbedarf = new KiSS4.Gui.KissLabel();
            this.qryBgPositionsart = new KiSS4.DB.SqlQuery(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionsartCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionsartCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBerechnungsgrundlage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            this.panel1.SuspendLayout();
            this.fraELSE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblELSE_Anpassung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtELSE_Anpassung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblELSE_Betrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblELSE_Total)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtELSE_Total.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbzugVVG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbzugVVG.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtELSE_Betrag.Properties)).BeginInit();
            this.fraSKOS2005.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissCalcEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSKOS2005_Anpassung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSKOS2005_Anpassung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSKOS2005_Total.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSKOS2005_AbzugVVG.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSKOS2005_UE.Properties)).BeginInit();
            this.fraSKOS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbzugVVG_SKOS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbzugVVG_SKOS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGBII_Hg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGBI_Hg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalGrundbedarf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundbedarfIIAnpassung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundbedarfIAnpassung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundbedarfII)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundbedarfIZuschlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundbedarfI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGBII_Einzel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrundbedarfII.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGBIIAnpassung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrundbedarfTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrundbedarfZusatz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGBIZuschlag_Hg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnpassung.Properties)).BeginInit();
            this.fraKennzahlen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeZuschlagI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKennzahlen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUeZuschlagI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeWohnkosten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUeWohnkosten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUeGrundbedarf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeGrundbedarf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHgWohnkosten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHgWohnkosten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHgGrundbedarf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHgGrundbedarf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPositionsart)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitel
            // 
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(32, 8);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(640, 16);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Monatlicher Grundbedarf vom {0:d} bis {1:d}";
            // 
            // edtBgPositionsartCode
            // 
            this.edtBgPositionsartCode.AllowNull = false;
            this.edtBgPositionsartCode.DataMember = "BgPositionsartCode";
            this.edtBgPositionsartCode.DataSource = this.qryBgPosition;
            this.edtBgPositionsartCode.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBgPositionsartCode.Location = new System.Drawing.Point(8, 56);
            this.edtBgPositionsartCode.LOVName = "WhGrundbedarfTyp";
            this.edtBgPositionsartCode.Name = "edtBgPositionsartCode";
            this.edtBgPositionsartCode.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBgPositionsartCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgPositionsartCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgPositionsartCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgPositionsartCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgPositionsartCode.Properties.Appearance.Options.UseFont = true;
            this.edtBgPositionsartCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBgPositionsartCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgPositionsartCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBgPositionsartCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBgPositionsartCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtBgPositionsartCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtBgPositionsartCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgPositionsartCode.Properties.NullText = "";
            this.edtBgPositionsartCode.Properties.ReadOnly = true;
            this.edtBgPositionsartCode.Properties.ShowFooter = false;
            this.edtBgPositionsartCode.Properties.ShowHeader = false;
            this.edtBgPositionsartCode.Size = new System.Drawing.Size(336, 24);
            this.edtBgPositionsartCode.TabIndex = 2;
            this.edtBgPositionsartCode.EditValueChanged += new System.EventHandler(this.edtBgPositionsartCode_EditValueChanged);
            // 
            // qryBgPosition
            // 
            this.qryBgPosition.CanUpdate = true;
            this.qryBgPosition.HostControl = this;
            this.qryBgPosition.IsIdentityInsert = false;
            this.qryBgPosition.SelectStatement = resources.GetString("qryBgPosition.SelectStatement");
            this.qryBgPosition.TableName = "BgPosition";
            this.qryBgPosition.AfterFill += new System.EventHandler(this.qryBgPosition_AfterFill);
            this.qryBgPosition.AfterPost += new System.EventHandler(this.qryBgPosition_AfterPost);
            this.qryBgPosition.BeforePost += new System.EventHandler(this.qryBgPosition_BeforePost);
            this.qryBgPosition.PositionChanged += new System.EventHandler(this.qryBgPosition_PositionChanged);
            // 
            // lblBerechnungsgrundlage
            // 
            this.lblBerechnungsgrundlage.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblBerechnungsgrundlage.Location = new System.Drawing.Point(8, 40);
            this.lblBerechnungsgrundlage.Name = "lblBerechnungsgrundlage";
            this.lblBerechnungsgrundlage.Size = new System.Drawing.Size(304, 16);
            this.lblBerechnungsgrundlage.TabIndex = 1;
            this.lblBerechnungsgrundlage.Text = "Berechnungsgrundlage";
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryBgPosition;
            this.edtBemerkung.Location = new System.Drawing.Point(352, 167);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(320, 473);
            this.edtBemerkung.TabIndex = 6;
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblBemerkung.Location = new System.Drawing.Point(352, 146);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(304, 16);
            this.lblBemerkung.TabIndex = 5;
            this.lblBemerkung.Text = "Begründungen";
            // 
            // picTitel
            // 
            this.picTitel.Location = new System.Drawing.Point(8, 8);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 55;
            this.picTitel.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.fraELSE);
            this.panel1.Controls.Add(this.fraSKOS2005);
            this.panel1.Controls.Add(this.fraSKOS);
            this.panel1.Location = new System.Drawing.Point(8, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(336, 552);
            this.panel1.TabIndex = 3;
            // 
            // fraELSE
            // 
            this.fraELSE.Controls.Add(this.lblELSE_Anpassung);
            this.fraELSE.Controls.Add(this.edtELSE_Anpassung);
            this.fraELSE.Controls.Add(this.lblELSE_Betrag);
            this.fraELSE.Controls.Add(this.lblELSE_Total);
            this.fraELSE.Controls.Add(this.edtELSE_Total);
            this.fraELSE.Controls.Add(this.lblAbzugVVG);
            this.fraELSE.Controls.Add(this.edtAbzugVVG);
            this.fraELSE.Controls.Add(this.edtELSE_Betrag);
            this.fraELSE.Dock = System.Windows.Forms.DockStyle.Top;
            this.fraELSE.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.fraELSE.Location = new System.Drawing.Point(0, 404);
            this.fraELSE.Name = "fraELSE";
            this.fraELSE.Size = new System.Drawing.Size(336, 133);
            this.fraELSE.TabIndex = 2;
            this.fraELSE.TabStop = false;
            this.fraELSE.Text = "Berechnungsgrundlage";
            // 
            // lblELSE_Anpassung
            // 
            this.lblELSE_Anpassung.Location = new System.Drawing.Point(8, 47);
            this.lblELSE_Anpassung.Name = "lblELSE_Anpassung";
            this.lblELSE_Anpassung.Size = new System.Drawing.Size(232, 24);
            this.lblELSE_Anpassung.TabIndex = 2;
            this.lblELSE_Anpassung.Text = "Anpassung des Grundbedarfes (begründen!)";
            // 
            // edtELSE_Anpassung
            // 
            this.edtELSE_Anpassung.DataMember = "ELSE_Anpassung";
            this.edtELSE_Anpassung.DataSource = this.qryBgPosition;
            this.edtELSE_Anpassung.Location = new System.Drawing.Point(248, 47);
            this.edtELSE_Anpassung.Name = "edtELSE_Anpassung";
            this.edtELSE_Anpassung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtELSE_Anpassung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtELSE_Anpassung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtELSE_Anpassung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtELSE_Anpassung.Properties.Appearance.Options.UseBackColor = true;
            this.edtELSE_Anpassung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtELSE_Anpassung.Properties.Appearance.Options.UseFont = true;
            this.edtELSE_Anpassung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtELSE_Anpassung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtELSE_Anpassung.Properties.DisplayFormat.FormatString = "n2";
            this.edtELSE_Anpassung.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtELSE_Anpassung.Properties.EditFormat.FormatString = "n2";
            this.edtELSE_Anpassung.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtELSE_Anpassung.Size = new System.Drawing.Size(80, 24);
            this.edtELSE_Anpassung.TabIndex = 3;
            // 
            // lblELSE_Betrag
            // 
            this.lblELSE_Betrag.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblELSE_Betrag.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblELSE_Betrag.Location = new System.Drawing.Point(8, 24);
            this.lblELSE_Betrag.Name = "lblELSE_Betrag";
            this.lblELSE_Betrag.Size = new System.Drawing.Size(232, 24);
            this.lblELSE_Betrag.TabIndex = 0;
            this.lblELSE_Betrag.Text = "monatlicher Grundbedarf";
            // 
            // lblELSE_Total
            // 
            this.lblELSE_Total.Location = new System.Drawing.Point(8, 100);
            this.lblELSE_Total.Name = "lblELSE_Total";
            this.lblELSE_Total.Size = new System.Drawing.Size(232, 24);
            this.lblELSE_Total.TabIndex = 6;
            this.lblELSE_Total.Text = "Total monatlicher Grundbedarf";
            // 
            // edtELSE_Total
            // 
            this.edtELSE_Total.DataMember = "ELSE_Total";
            this.edtELSE_Total.DataSource = this.qryBgPosition;
            this.edtELSE_Total.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtELSE_Total.Location = new System.Drawing.Point(248, 100);
            this.edtELSE_Total.Name = "edtELSE_Total";
            this.edtELSE_Total.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtELSE_Total.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtELSE_Total.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtELSE_Total.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtELSE_Total.Properties.Appearance.Options.UseBackColor = true;
            this.edtELSE_Total.Properties.Appearance.Options.UseBorderColor = true;
            this.edtELSE_Total.Properties.Appearance.Options.UseFont = true;
            this.edtELSE_Total.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtELSE_Total.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtELSE_Total.Properties.DisplayFormat.FormatString = "n2";
            this.edtELSE_Total.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtELSE_Total.Properties.EditFormat.FormatString = "n2";
            this.edtELSE_Total.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtELSE_Total.Properties.ReadOnly = true;
            this.edtELSE_Total.Size = new System.Drawing.Size(80, 24);
            this.edtELSE_Total.TabIndex = 7;
            // 
            // lblAbzugVVG
            // 
            this.lblAbzugVVG.Location = new System.Drawing.Point(8, 70);
            this.lblAbzugVVG.Name = "lblAbzugVVG";
            this.lblAbzugVVG.Size = new System.Drawing.Size(232, 24);
            this.lblAbzugVVG.TabIndex = 4;
            this.lblAbzugVVG.Text = "Abzug VVG";
            // 
            // edtAbzugVVG
            // 
            this.edtAbzugVVG.DataMember = "AbzugVVG";
            this.edtAbzugVVG.DataSource = this.qryBgPosition;
            this.edtAbzugVVG.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAbzugVVG.Location = new System.Drawing.Point(248, 70);
            this.edtAbzugVVG.Name = "edtAbzugVVG";
            this.edtAbzugVVG.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAbzugVVG.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAbzugVVG.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAbzugVVG.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbzugVVG.Properties.Appearance.Options.UseBackColor = true;
            this.edtAbzugVVG.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAbzugVVG.Properties.Appearance.Options.UseFont = true;
            this.edtAbzugVVG.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAbzugVVG.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAbzugVVG.Properties.DisplayFormat.FormatString = "n2";
            this.edtAbzugVVG.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtAbzugVVG.Properties.EditFormat.FormatString = "n2";
            this.edtAbzugVVG.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtAbzugVVG.Properties.ReadOnly = true;
            this.edtAbzugVVG.Size = new System.Drawing.Size(80, 24);
            this.edtAbzugVVG.TabIndex = 5;
            // 
            // edtELSE_Betrag
            // 
            this.edtELSE_Betrag.DataMember = "ELSE_Betrag";
            this.edtELSE_Betrag.DataSource = this.qryBgPosition;
            this.edtELSE_Betrag.Location = new System.Drawing.Point(248, 24);
            this.edtELSE_Betrag.Name = "edtELSE_Betrag";
            this.edtELSE_Betrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtELSE_Betrag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtELSE_Betrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtELSE_Betrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtELSE_Betrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtELSE_Betrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtELSE_Betrag.Properties.Appearance.Options.UseFont = true;
            this.edtELSE_Betrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtELSE_Betrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtELSE_Betrag.Properties.DisplayFormat.FormatString = "n2";
            this.edtELSE_Betrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtELSE_Betrag.Properties.EditFormat.FormatString = "n2";
            this.edtELSE_Betrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtELSE_Betrag.Size = new System.Drawing.Size(80, 24);
            this.edtELSE_Betrag.TabIndex = 1;
            // 
            // fraSKOS2005
            // 
            this.fraSKOS2005.Controls.Add(this.kissCalcEdit2);
            this.fraSKOS2005.Controls.Add(this.lblSKOS2005_Anpassung);
            this.fraSKOS2005.Controls.Add(this.edtSKOS2005_Anpassung);
            this.fraSKOS2005.Controls.Add(this.kissLabel3);
            this.fraSKOS2005.Controls.Add(this.kissLabel4);
            this.fraSKOS2005.Controls.Add(this.kissLabel5);
            this.fraSKOS2005.Controls.Add(this.kissLabel6);
            this.fraSKOS2005.Controls.Add(this.edtSKOS2005_Total);
            this.fraSKOS2005.Controls.Add(this.kissLabel7);
            this.fraSKOS2005.Controls.Add(this.edtSKOS2005_AbzugVVG);
            this.fraSKOS2005.Controls.Add(this.edtSKOS2005_UE);
            this.fraSKOS2005.Dock = System.Windows.Forms.DockStyle.Top;
            this.fraSKOS2005.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.fraSKOS2005.Location = new System.Drawing.Point(0, 252);
            this.fraSKOS2005.Name = "fraSKOS2005";
            this.fraSKOS2005.Size = new System.Drawing.Size(336, 152);
            this.fraSKOS2005.TabIndex = 1;
            this.fraSKOS2005.TabStop = false;
            this.fraSKOS2005.Text = "SKOS 2005";
            // 
            // kissCalcEdit2
            // 
            this.kissCalcEdit2.DataMember = "SKOS2005_HG";
            this.kissCalcEdit2.DataSource = this.qryBgPosition;
            this.kissCalcEdit2.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissCalcEdit2.Location = new System.Drawing.Point(160, 40);
            this.kissCalcEdit2.Name = "kissCalcEdit2";
            this.kissCalcEdit2.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.kissCalcEdit2.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissCalcEdit2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissCalcEdit2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissCalcEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.kissCalcEdit2.Properties.Appearance.Options.UseBorderColor = true;
            this.kissCalcEdit2.Properties.Appearance.Options.UseFont = true;
            this.kissCalcEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissCalcEdit2.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.kissCalcEdit2.Properties.DisplayFormat.FormatString = "n2";
            this.kissCalcEdit2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.kissCalcEdit2.Properties.EditFormat.FormatString = "n2";
            this.kissCalcEdit2.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.kissCalcEdit2.Properties.ReadOnly = true;
            this.kissCalcEdit2.Size = new System.Drawing.Size(80, 24);
            this.kissCalcEdit2.TabIndex = 3;
            // 
            // lblSKOS2005_Anpassung
            // 
            this.lblSKOS2005_Anpassung.Location = new System.Drawing.Point(8, 63);
            this.lblSKOS2005_Anpassung.Name = "lblSKOS2005_Anpassung";
            this.lblSKOS2005_Anpassung.Size = new System.Drawing.Size(232, 24);
            this.lblSKOS2005_Anpassung.TabIndex = 9;
            this.lblSKOS2005_Anpassung.Text = "Anpassung des Grundbedarfes (begründen!)";
            // 
            // edtSKOS2005_Anpassung
            // 
            this.edtSKOS2005_Anpassung.DataMember = "SKOS2005_Anpassung";
            this.edtSKOS2005_Anpassung.DataSource = this.qryBgPosition;
            this.edtSKOS2005_Anpassung.Location = new System.Drawing.Point(248, 63);
            this.edtSKOS2005_Anpassung.Name = "edtSKOS2005_Anpassung";
            this.edtSKOS2005_Anpassung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSKOS2005_Anpassung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSKOS2005_Anpassung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSKOS2005_Anpassung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSKOS2005_Anpassung.Properties.Appearance.Options.UseBackColor = true;
            this.edtSKOS2005_Anpassung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSKOS2005_Anpassung.Properties.Appearance.Options.UseFont = true;
            this.edtSKOS2005_Anpassung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSKOS2005_Anpassung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSKOS2005_Anpassung.Properties.DisplayFormat.FormatString = "n2";
            this.edtSKOS2005_Anpassung.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSKOS2005_Anpassung.Properties.EditFormat.FormatString = "n2";
            this.edtSKOS2005_Anpassung.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSKOS2005_Anpassung.Size = new System.Drawing.Size(80, 24);
            this.edtSKOS2005_Anpassung.TabIndex = 10;
            // 
            // kissLabel3
            // 
            this.kissLabel3.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.kissLabel3.Location = new System.Drawing.Point(160, 24);
            this.kissLabel3.Name = "kissLabel3";
            this.kissLabel3.Size = new System.Drawing.Size(80, 16);
            this.kissLabel3.TabIndex = 0;
            this.kissLabel3.Text = "für HG";
            // 
            // kissLabel4
            // 
            this.kissLabel4.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.kissLabel4.Location = new System.Drawing.Point(248, 24);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(80, 16);
            this.kissLabel4.TabIndex = 1;
            this.kissLabel4.Text = "für UE";
            // 
            // kissLabel5
            // 
            this.kissLabel5.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissLabel5.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel5.Location = new System.Drawing.Point(8, 40);
            this.kissLabel5.Name = "kissLabel5";
            this.kissLabel5.Size = new System.Drawing.Size(232, 24);
            this.kissLabel5.TabIndex = 2;
            this.kissLabel5.Text = "Grundbedarf";
            // 
            // kissLabel6
            // 
            this.kissLabel6.Location = new System.Drawing.Point(8, 116);
            this.kissLabel6.Name = "kissLabel6";
            this.kissLabel6.Size = new System.Drawing.Size(232, 24);
            this.kissLabel6.TabIndex = 7;
            this.kissLabel6.Text = "Total monatlicher Grundbedarf";
            // 
            // edtSKOS2005_Total
            // 
            this.edtSKOS2005_Total.DataMember = "SKOS2005_Total";
            this.edtSKOS2005_Total.DataSource = this.qryBgPosition;
            this.edtSKOS2005_Total.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtSKOS2005_Total.Location = new System.Drawing.Point(248, 116);
            this.edtSKOS2005_Total.Name = "edtSKOS2005_Total";
            this.edtSKOS2005_Total.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSKOS2005_Total.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSKOS2005_Total.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSKOS2005_Total.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSKOS2005_Total.Properties.Appearance.Options.UseBackColor = true;
            this.edtSKOS2005_Total.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSKOS2005_Total.Properties.Appearance.Options.UseFont = true;
            this.edtSKOS2005_Total.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSKOS2005_Total.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSKOS2005_Total.Properties.DisplayFormat.FormatString = "n2";
            this.edtSKOS2005_Total.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSKOS2005_Total.Properties.EditFormat.FormatString = "n2";
            this.edtSKOS2005_Total.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSKOS2005_Total.Properties.ReadOnly = true;
            this.edtSKOS2005_Total.Size = new System.Drawing.Size(80, 24);
            this.edtSKOS2005_Total.TabIndex = 8;
            // 
            // kissLabel7
            // 
            this.kissLabel7.Location = new System.Drawing.Point(8, 86);
            this.kissLabel7.Name = "kissLabel7";
            this.kissLabel7.Size = new System.Drawing.Size(232, 24);
            this.kissLabel7.TabIndex = 5;
            this.kissLabel7.Text = "Abzug VVG";
            // 
            // edtSKOS2005_AbzugVVG
            // 
            this.edtSKOS2005_AbzugVVG.DataMember = "AbzugVVG";
            this.edtSKOS2005_AbzugVVG.DataSource = this.qryBgPosition;
            this.edtSKOS2005_AbzugVVG.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtSKOS2005_AbzugVVG.Location = new System.Drawing.Point(248, 86);
            this.edtSKOS2005_AbzugVVG.Name = "edtSKOS2005_AbzugVVG";
            this.edtSKOS2005_AbzugVVG.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSKOS2005_AbzugVVG.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSKOS2005_AbzugVVG.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSKOS2005_AbzugVVG.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSKOS2005_AbzugVVG.Properties.Appearance.Options.UseBackColor = true;
            this.edtSKOS2005_AbzugVVG.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSKOS2005_AbzugVVG.Properties.Appearance.Options.UseFont = true;
            this.edtSKOS2005_AbzugVVG.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSKOS2005_AbzugVVG.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSKOS2005_AbzugVVG.Properties.DisplayFormat.FormatString = "n2";
            this.edtSKOS2005_AbzugVVG.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSKOS2005_AbzugVVG.Properties.EditFormat.FormatString = "n2";
            this.edtSKOS2005_AbzugVVG.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSKOS2005_AbzugVVG.Properties.ReadOnly = true;
            this.edtSKOS2005_AbzugVVG.Size = new System.Drawing.Size(80, 24);
            this.edtSKOS2005_AbzugVVG.TabIndex = 6;
            // 
            // edtSKOS2005_UE
            // 
            this.edtSKOS2005_UE.DataMember = "SKOS2005_UE";
            this.edtSKOS2005_UE.DataSource = this.qryBgPosition;
            this.edtSKOS2005_UE.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtSKOS2005_UE.Location = new System.Drawing.Point(248, 40);
            this.edtSKOS2005_UE.Name = "edtSKOS2005_UE";
            this.edtSKOS2005_UE.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSKOS2005_UE.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSKOS2005_UE.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSKOS2005_UE.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSKOS2005_UE.Properties.Appearance.Options.UseBackColor = true;
            this.edtSKOS2005_UE.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSKOS2005_UE.Properties.Appearance.Options.UseFont = true;
            this.edtSKOS2005_UE.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSKOS2005_UE.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSKOS2005_UE.Properties.DisplayFormat.FormatString = "n2";
            this.edtSKOS2005_UE.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSKOS2005_UE.Properties.EditFormat.FormatString = "n2";
            this.edtSKOS2005_UE.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSKOS2005_UE.Properties.ReadOnly = true;
            this.edtSKOS2005_UE.Size = new System.Drawing.Size(80, 24);
            this.edtSKOS2005_UE.TabIndex = 4;
            // 
            // fraSKOS
            // 
            this.fraSKOS.Controls.Add(this.lblAbzugVVG_SKOS);
            this.fraSKOS.Controls.Add(this.edtAbzugVVG_SKOS);
            this.fraSKOS.Controls.Add(this.edtGBII_Hg);
            this.fraSKOS.Controls.Add(this.edtGBI_Hg);
            this.fraSKOS.Controls.Add(this.lblTotalGrundbedarf);
            this.fraSKOS.Controls.Add(this.lblHg);
            this.fraSKOS.Controls.Add(this.lblUE);
            this.fraSKOS.Controls.Add(this.lblGrundbedarfIIAnpassung);
            this.fraSKOS.Controls.Add(this.lblGrundbedarfIAnpassung);
            this.fraSKOS.Controls.Add(this.lblGrundbedarfII);
            this.fraSKOS.Controls.Add(this.lblGrundbedarfIZuschlag);
            this.fraSKOS.Controls.Add(this.lblGrundbedarfI);
            this.fraSKOS.Controls.Add(this.chkGBII_Einzel);
            this.fraSKOS.Controls.Add(this.edtGrundbedarfII);
            this.fraSKOS.Controls.Add(this.edtGBIIAnpassung);
            this.fraSKOS.Controls.Add(this.edtBetrag);
            this.fraSKOS.Controls.Add(this.edtGrundbedarfTotal);
            this.fraSKOS.Controls.Add(this.edtGrundbedarfZusatz);
            this.fraSKOS.Controls.Add(this.edtGBIZuschlag_Hg);
            this.fraSKOS.Controls.Add(this.edtAnpassung);
            this.fraSKOS.Dock = System.Windows.Forms.DockStyle.Top;
            this.fraSKOS.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.fraSKOS.Location = new System.Drawing.Point(0, 0);
            this.fraSKOS.Name = "fraSKOS";
            this.fraSKOS.Size = new System.Drawing.Size(336, 252);
            this.fraSKOS.TabIndex = 0;
            this.fraSKOS.TabStop = false;
            this.fraSKOS.Text = "SKOS bzw. interne Richtlinien";
            // 
            // lblAbzugVVG_SKOS
            // 
            this.lblAbzugVVG_SKOS.Location = new System.Drawing.Point(8, 86);
            this.lblAbzugVVG_SKOS.Name = "lblAbzugVVG_SKOS";
            this.lblAbzugVVG_SKOS.Size = new System.Drawing.Size(232, 24);
            this.lblAbzugVVG_SKOS.TabIndex = 19;
            this.lblAbzugVVG_SKOS.Text = "Abzug VVG";
            // 
            // edtAbzugVVG_SKOS
            // 
            this.edtAbzugVVG_SKOS.DataMember = "AbzugVVG";
            this.edtAbzugVVG_SKOS.DataSource = this.qryBgPosition;
            this.edtAbzugVVG_SKOS.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAbzugVVG_SKOS.Location = new System.Drawing.Point(248, 86);
            this.edtAbzugVVG_SKOS.Name = "edtAbzugVVG_SKOS";
            this.edtAbzugVVG_SKOS.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAbzugVVG_SKOS.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAbzugVVG_SKOS.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAbzugVVG_SKOS.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbzugVVG_SKOS.Properties.Appearance.Options.UseBackColor = true;
            this.edtAbzugVVG_SKOS.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAbzugVVG_SKOS.Properties.Appearance.Options.UseFont = true;
            this.edtAbzugVVG_SKOS.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAbzugVVG_SKOS.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAbzugVVG_SKOS.Properties.DisplayFormat.FormatString = "n2";
            this.edtAbzugVVG_SKOS.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtAbzugVVG_SKOS.Properties.EditFormat.FormatString = "n2";
            this.edtAbzugVVG_SKOS.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtAbzugVVG_SKOS.Properties.ReadOnly = true;
            this.edtAbzugVVG_SKOS.Size = new System.Drawing.Size(80, 24);
            this.edtAbzugVVG_SKOS.TabIndex = 20;
            // 
            // edtGBII_Hg
            // 
            this.edtGBII_Hg.DataMember = "GBII_Hg";
            this.edtGBII_Hg.DataSource = this.qryBgPosition;
            this.edtGBII_Hg.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGBII_Hg.Location = new System.Drawing.Point(160, 146);
            this.edtGBII_Hg.Name = "edtGBII_Hg";
            this.edtGBII_Hg.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGBII_Hg.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGBII_Hg.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGBII_Hg.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGBII_Hg.Properties.Appearance.Options.UseBackColor = true;
            this.edtGBII_Hg.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGBII_Hg.Properties.Appearance.Options.UseFont = true;
            this.edtGBII_Hg.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGBII_Hg.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGBII_Hg.Properties.DisplayFormat.FormatString = "n2";
            this.edtGBII_Hg.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtGBII_Hg.Properties.EditFormat.FormatString = "n2";
            this.edtGBII_Hg.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtGBII_Hg.Properties.ReadOnly = true;
            this.edtGBII_Hg.Size = new System.Drawing.Size(80, 24);
            this.edtGBII_Hg.TabIndex = 11;
            // 
            // edtGBI_Hg
            // 
            this.edtGBI_Hg.DataMember = "GBI_Hg";
            this.edtGBI_Hg.DataSource = this.qryBgPosition;
            this.edtGBI_Hg.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGBI_Hg.Location = new System.Drawing.Point(160, 40);
            this.edtGBI_Hg.Name = "edtGBI_Hg";
            this.edtGBI_Hg.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGBI_Hg.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGBI_Hg.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGBI_Hg.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGBI_Hg.Properties.Appearance.Options.UseBackColor = true;
            this.edtGBI_Hg.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGBI_Hg.Properties.Appearance.Options.UseFont = true;
            this.edtGBI_Hg.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGBI_Hg.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGBI_Hg.Properties.DisplayFormat.FormatString = "n2";
            this.edtGBI_Hg.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtGBI_Hg.Properties.EditFormat.FormatString = "n2";
            this.edtGBI_Hg.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtGBI_Hg.Properties.ReadOnly = true;
            this.edtGBI_Hg.Size = new System.Drawing.Size(80, 24);
            this.edtGBI_Hg.TabIndex = 3;
            // 
            // lblTotalGrundbedarf
            // 
            this.lblTotalGrundbedarf.Location = new System.Drawing.Point(8, 219);
            this.lblTotalGrundbedarf.Name = "lblTotalGrundbedarf";
            this.lblTotalGrundbedarf.Size = new System.Drawing.Size(232, 24);
            this.lblTotalGrundbedarf.TabIndex = 16;
            this.lblTotalGrundbedarf.Text = "Total monatlicher Grundbedarf";
            // 
            // lblHg
            // 
            this.lblHg.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblHg.Location = new System.Drawing.Point(160, 24);
            this.lblHg.Name = "lblHg";
            this.lblHg.Size = new System.Drawing.Size(80, 16);
            this.lblHg.TabIndex = 0;
            this.lblHg.Text = "für HG";
            // 
            // lblUE
            // 
            this.lblUE.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblUE.Location = new System.Drawing.Point(248, 24);
            this.lblUE.Name = "lblUE";
            this.lblUE.Size = new System.Drawing.Size(80, 16);
            this.lblUE.TabIndex = 1;
            this.lblUE.Text = "für UE";
            // 
            // lblGrundbedarfIIAnpassung
            // 
            this.lblGrundbedarfIIAnpassung.Location = new System.Drawing.Point(8, 169);
            this.lblGrundbedarfIIAnpassung.Name = "lblGrundbedarfIIAnpassung";
            this.lblGrundbedarfIIAnpassung.Size = new System.Drawing.Size(232, 24);
            this.lblGrundbedarfIIAnpassung.TabIndex = 13;
            this.lblGrundbedarfIIAnpassung.Text = "Anpassung des Grundbedarfes (begründen!)";
            // 
            // lblGrundbedarfIAnpassung
            // 
            this.lblGrundbedarfIAnpassung.Location = new System.Drawing.Point(8, 63);
            this.lblGrundbedarfIAnpassung.Name = "lblGrundbedarfIAnpassung";
            this.lblGrundbedarfIAnpassung.Size = new System.Drawing.Size(232, 24);
            this.lblGrundbedarfIAnpassung.TabIndex = 5;
            this.lblGrundbedarfIAnpassung.Text = "Anpassung des Grundbedarfes (begründen!)";
            // 
            // lblGrundbedarfII
            // 
            this.lblGrundbedarfII.Location = new System.Drawing.Point(8, 146);
            this.lblGrundbedarfII.Name = "lblGrundbedarfII";
            this.lblGrundbedarfII.Size = new System.Drawing.Size(144, 24);
            this.lblGrundbedarfII.TabIndex = 10;
            this.lblGrundbedarfII.Text = "Grundbedarf II";
            // 
            // lblGrundbedarfIZuschlag
            // 
            this.lblGrundbedarfIZuschlag.Location = new System.Drawing.Point(8, 116);
            this.lblGrundbedarfIZuschlag.Name = "lblGrundbedarfIZuschlag";
            this.lblGrundbedarfIZuschlag.Size = new System.Drawing.Size(144, 24);
            this.lblGrundbedarfIZuschlag.TabIndex = 7;
            this.lblGrundbedarfIZuschlag.Text = "Zuschlag zum Grundbedarf I";
            // 
            // lblGrundbedarfI
            // 
            this.lblGrundbedarfI.Location = new System.Drawing.Point(8, 40);
            this.lblGrundbedarfI.Name = "lblGrundbedarfI";
            this.lblGrundbedarfI.Size = new System.Drawing.Size(128, 24);
            this.lblGrundbedarfI.TabIndex = 2;
            this.lblGrundbedarfI.Text = "Grundbedarf I";
            // 
            // chkGBII_Einzel
            // 
            this.chkGBII_Einzel.DataMember = "GBII_AsOnePerson";
            this.chkGBII_Einzel.DataSource = this.qryBgPosition;
            this.chkGBII_Einzel.Location = new System.Drawing.Point(8, 194);
            this.chkGBII_Einzel.Name = "chkGBII_Einzel";
            this.chkGBII_Einzel.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkGBII_Einzel.Properties.Appearance.Options.UseBackColor = true;
            this.chkGBII_Einzel.Properties.Caption = "Keine Kopfteilung auf GB II anwenden";
            this.chkGBII_Einzel.Size = new System.Drawing.Size(320, 19);
            this.chkGBII_Einzel.TabIndex = 15;
            // 
            // edtGrundbedarfII
            // 
            this.edtGrundbedarfII.DataMember = "GrundbedarfII";
            this.edtGrundbedarfII.DataSource = this.qryBgPosition;
            this.edtGrundbedarfII.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGrundbedarfII.Location = new System.Drawing.Point(248, 146);
            this.edtGrundbedarfII.Name = "edtGrundbedarfII";
            this.edtGrundbedarfII.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGrundbedarfII.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGrundbedarfII.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGrundbedarfII.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrundbedarfII.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrundbedarfII.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGrundbedarfII.Properties.Appearance.Options.UseFont = true;
            this.edtGrundbedarfII.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGrundbedarfII.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGrundbedarfII.Properties.DisplayFormat.FormatString = "n2";
            this.edtGrundbedarfII.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtGrundbedarfII.Properties.EditFormat.FormatString = "n2";
            this.edtGrundbedarfII.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtGrundbedarfII.Properties.ReadOnly = true;
            this.edtGrundbedarfII.Size = new System.Drawing.Size(80, 24);
            this.edtGrundbedarfII.TabIndex = 12;
            // 
            // edtGBIIAnpassung
            // 
            this.edtGBIIAnpassung.DataMember = "GrundbedarfII_Anpassung";
            this.edtGBIIAnpassung.DataSource = this.qryBgPosition;
            this.edtGBIIAnpassung.Location = new System.Drawing.Point(248, 169);
            this.edtGBIIAnpassung.Name = "edtGBIIAnpassung";
            this.edtGBIIAnpassung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGBIIAnpassung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGBIIAnpassung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGBIIAnpassung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGBIIAnpassung.Properties.Appearance.Options.UseBackColor = true;
            this.edtGBIIAnpassung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGBIIAnpassung.Properties.Appearance.Options.UseFont = true;
            this.edtGBIIAnpassung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGBIIAnpassung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGBIIAnpassung.Properties.DisplayFormat.FormatString = "n2";
            this.edtGBIIAnpassung.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtGBIIAnpassung.Properties.EditFormat.FormatString = "n2";
            this.edtGBIIAnpassung.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtGBIIAnpassung.Size = new System.Drawing.Size(80, 24);
            this.edtGBIIAnpassung.TabIndex = 14;
            // 
            // edtBetrag
            // 
            this.edtBetrag.DataMember = "Betrag_SKOS";
            this.edtBetrag.DataSource = this.qryBgPosition;
            this.edtBetrag.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBetrag.Location = new System.Drawing.Point(248, 40);
            this.edtBetrag.Name = "edtBetrag";
            this.edtBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBetrag.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
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
            this.edtBetrag.Properties.ReadOnly = true;
            this.edtBetrag.Size = new System.Drawing.Size(80, 24);
            this.edtBetrag.TabIndex = 4;
            // 
            // edtGrundbedarfTotal
            // 
            this.edtGrundbedarfTotal.DataMember = "GrundbedarfTotal";
            this.edtGrundbedarfTotal.DataSource = this.qryBgPosition;
            this.edtGrundbedarfTotal.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGrundbedarfTotal.Location = new System.Drawing.Point(248, 219);
            this.edtGrundbedarfTotal.Name = "edtGrundbedarfTotal";
            this.edtGrundbedarfTotal.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGrundbedarfTotal.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGrundbedarfTotal.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGrundbedarfTotal.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrundbedarfTotal.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrundbedarfTotal.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGrundbedarfTotal.Properties.Appearance.Options.UseFont = true;
            this.edtGrundbedarfTotal.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGrundbedarfTotal.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGrundbedarfTotal.Properties.DisplayFormat.FormatString = "n2";
            this.edtGrundbedarfTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtGrundbedarfTotal.Properties.EditFormat.FormatString = "n2";
            this.edtGrundbedarfTotal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtGrundbedarfTotal.Properties.ReadOnly = true;
            this.edtGrundbedarfTotal.Size = new System.Drawing.Size(80, 24);
            this.edtGrundbedarfTotal.TabIndex = 17;
            // 
            // edtGrundbedarfZusatz
            // 
            this.edtGrundbedarfZusatz.DataMember = "GrundbedarfZusatz";
            this.edtGrundbedarfZusatz.DataSource = this.qryBgPosition;
            this.edtGrundbedarfZusatz.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGrundbedarfZusatz.Location = new System.Drawing.Point(248, 116);
            this.edtGrundbedarfZusatz.Name = "edtGrundbedarfZusatz";
            this.edtGrundbedarfZusatz.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGrundbedarfZusatz.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGrundbedarfZusatz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGrundbedarfZusatz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrundbedarfZusatz.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrundbedarfZusatz.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGrundbedarfZusatz.Properties.Appearance.Options.UseFont = true;
            this.edtGrundbedarfZusatz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGrundbedarfZusatz.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGrundbedarfZusatz.Properties.DisplayFormat.FormatString = "n2";
            this.edtGrundbedarfZusatz.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtGrundbedarfZusatz.Properties.EditFormat.FormatString = "n2";
            this.edtGrundbedarfZusatz.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtGrundbedarfZusatz.Properties.ReadOnly = true;
            this.edtGrundbedarfZusatz.Size = new System.Drawing.Size(80, 24);
            this.edtGrundbedarfZusatz.TabIndex = 9;
            // 
            // edtGBIZuschlag_Hg
            // 
            this.edtGBIZuschlag_Hg.DataMember = "GBIZuschlag_Hg";
            this.edtGBIZuschlag_Hg.DataSource = this.qryBgPosition;
            this.edtGBIZuschlag_Hg.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGBIZuschlag_Hg.Location = new System.Drawing.Point(160, 116);
            this.edtGBIZuschlag_Hg.Name = "edtGBIZuschlag_Hg";
            this.edtGBIZuschlag_Hg.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGBIZuschlag_Hg.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGBIZuschlag_Hg.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGBIZuschlag_Hg.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGBIZuschlag_Hg.Properties.Appearance.Options.UseBackColor = true;
            this.edtGBIZuschlag_Hg.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGBIZuschlag_Hg.Properties.Appearance.Options.UseFont = true;
            this.edtGBIZuschlag_Hg.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGBIZuschlag_Hg.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGBIZuschlag_Hg.Properties.DisplayFormat.FormatString = "n2";
            this.edtGBIZuschlag_Hg.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtGBIZuschlag_Hg.Properties.EditFormat.FormatString = "n2";
            this.edtGBIZuschlag_Hg.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtGBIZuschlag_Hg.Properties.ReadOnly = true;
            this.edtGBIZuschlag_Hg.Size = new System.Drawing.Size(80, 24);
            this.edtGBIZuschlag_Hg.TabIndex = 8;
            // 
            // edtAnpassung
            // 
            this.edtAnpassung.DataMember = "GrundbedarfI_Anpassung";
            this.edtAnpassung.DataSource = this.qryBgPosition;
            this.edtAnpassung.Location = new System.Drawing.Point(248, 63);
            this.edtAnpassung.Name = "edtAnpassung";
            this.edtAnpassung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAnpassung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAnpassung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAnpassung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAnpassung.Properties.Appearance.Options.UseBackColor = true;
            this.edtAnpassung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAnpassung.Properties.Appearance.Options.UseFont = true;
            this.edtAnpassung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAnpassung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAnpassung.Properties.DisplayFormat.FormatString = "n2";
            this.edtAnpassung.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtAnpassung.Properties.EditFormat.FormatString = "n2";
            this.edtAnpassung.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtAnpassung.Size = new System.Drawing.Size(80, 24);
            this.edtAnpassung.TabIndex = 6;
            // 
            // fraKennzahlen
            // 
            this.fraKennzahlen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.fraKennzahlen.Location = new System.Drawing.Point(352, 51);
            this.fraKennzahlen.Name = "fraKennzahlen";
            this.fraKennzahlen.Size = new System.Drawing.Size(320, 88);
            this.fraKennzahlen.TabIndex = 4;
            this.fraKennzahlen.TabStop = false;
            this.fraKennzahlen.Text = "Kennzahlen";
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
            this.edtUeZuschlagI.DataSource = this.qryKennzahlen;
            this.edtUeZuschlagI.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.edtUeZuschlagI.Location = new System.Drawing.Point(219, 67);
            this.edtUeZuschlagI.Name = "edtUeZuschlagI";
            this.edtUeZuschlagI.Size = new System.Drawing.Size(24, 16);
            this.edtUeZuschlagI.TabIndex = 11;
            // 
            // qryKennzahlen
            // 
            this.qryKennzahlen.HostControl = this;
            this.qryKennzahlen.IsIdentityInsert = false;
            this.qryKennzahlen.SelectStatement = resources.GetString("qryKennzahlen.SelectStatement");
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
            this.edtUeWohnkosten.DataSource = this.qryKennzahlen;
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
            this.edtUeGrundbedarf.DataSource = this.qryKennzahlen;
            this.edtUeGrundbedarf.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.edtUeGrundbedarf.Location = new System.Drawing.Point(219, 35);
            this.edtUeGrundbedarf.Name = "edtUeGrundbedarf";
            this.edtUeGrundbedarf.Size = new System.Drawing.Size(24, 16);
            this.edtUeGrundbedarf.TabIndex = 7;
            // 
            // edtHgWohnkosten
            // 
            this.edtHgWohnkosten.DataMember = "HgWohnkosten";
            this.edtHgWohnkosten.DataSource = this.qryKennzahlen;
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
            this.edtHgGrundbedarf.DataSource = this.qryKennzahlen;
            this.edtHgGrundbedarf.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.edtHgGrundbedarf.Location = new System.Drawing.Point(83, 35);
            this.edtHgGrundbedarf.Name = "edtHgGrundbedarf";
            this.edtHgGrundbedarf.Size = new System.Drawing.Size(24, 16);
            this.edtHgGrundbedarf.TabIndex = 2;
            // 
            // qryBgPositionsart
            // 
            this.qryBgPositionsart.HostControl = this;
            this.qryBgPositionsart.IsIdentityInsert = false;
            this.qryBgPositionsart.SelectStatement = resources.GetString("qryBgPositionsart.SelectStatement");
            // 
            // CtlBgGrundbedarf
            // 
            this.ActiveSQLQuery = this.qryBgPosition;
            this.Controls.Add(this.fraKennzahlen);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.picTitel);
            this.Controls.Add(this.lblBemerkung);
            this.Controls.Add(this.edtBemerkung);
            this.Controls.Add(this.lblBerechnungsgrundlage);
            this.Controls.Add(this.edtBgPositionsartCode);
            this.Controls.Add(this.lblTitel);
            this.Name = "CtlBgGrundbedarf";
            this.Size = new System.Drawing.Size(680, 656);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionsartCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionsartCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBerechnungsgrundlage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            this.panel1.ResumeLayout(false);
            this.fraELSE.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblELSE_Anpassung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtELSE_Anpassung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblELSE_Betrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblELSE_Total)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtELSE_Total.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbzugVVG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbzugVVG.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtELSE_Betrag.Properties)).EndInit();
            this.fraSKOS2005.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kissCalcEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSKOS2005_Anpassung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSKOS2005_Anpassung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSKOS2005_Total.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSKOS2005_AbzugVVG.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSKOS2005_UE.Properties)).EndInit();
            this.fraSKOS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblAbzugVVG_SKOS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbzugVVG_SKOS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGBII_Hg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGBI_Hg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalGrundbedarf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundbedarfIIAnpassung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundbedarfIAnpassung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundbedarfII)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundbedarfIZuschlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundbedarfI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGBII_Einzel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrundbedarfII.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGBIIAnpassung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrundbedarfTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrundbedarfZusatz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGBIZuschlag_Hg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnpassung.Properties)).EndInit();
            this.fraKennzahlen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeZuschlagI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKennzahlen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUeZuschlagI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeWohnkosten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUeWohnkosten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUeGrundbedarf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeGrundbedarf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHgWohnkosten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHgWohnkosten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHgGrundbedarf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHgGrundbedarf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPositionsart)).EndInit();
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

        private void edtBgPositionsartCode_EditValueChanged(object sender, System.EventArgs e)
        {
            int bgPositionsartCode = 32011;

            try
            {
                if (sender == this.qryBgPosition || sender is System.Windows.Forms.CurrencyManager)
                    bgPositionsartCode = (int)this.qryBgPosition["BgPositionsartCode"];
                else
                    bgPositionsartCode = (int)this.edtBgPositionsartCode.EditValue;
            }
            catch { }

            switch (bgPositionsartCode)
            {
                case 32015:
                    this.fraSKOS.Visible = false;
                    this.fraSKOS2005.Visible = true;
                    this.fraELSE.Visible = false;
                    this.lblUeZuschlagI.Visible = false;
                    this.edtUeZuschlagI.Visible = false;
                    break;

                case 32016:
                case 32017:
                    this.fraSKOS.Visible = false;
                    this.fraSKOS2005.Visible = false;
                    this.fraELSE.Visible = true;
                    this.lblUeZuschlagI.Visible = false;
                    this.edtUeZuschlagI.Visible = false;

                    this.fraELSE.Text = this.edtBgPositionsartCode.Text;
                    this.lblELSE_Betrag.LabelStyle = KiSS4.Gui.LabelStyleType.EditFieldLabel;
                    this.lblELSE_Betrag.Text = "monatlicher Grundbedarf";
                    break;

                case 32018:
                    this.fraSKOS.Visible = false;
                    this.fraSKOS2005.Visible = false;
                    this.fraELSE.Visible = true;
                    this.lblUeZuschlagI.Visible = false;
                    this.edtUeZuschlagI.Visible = false;

                    this.fraELSE.Text = "Betreibungsrechtliches Existenzminimum";
                    this.lblELSE_Betrag.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
                    this.lblELSE_Betrag.Text = "monatlicher Grundbedarf gem. Angaben vom Betreibungsamt (BEX)";
                    break;

                case 32019:
                    this.fraSKOS.Visible = false;
                    this.fraSKOS2005.Visible = false;
                    this.fraELSE.Visible = true;
                    this.lblUeZuschlagI.Visible = false;
                    this.edtUeZuschlagI.Visible = false;

                    this.fraELSE.Text = "SKOS bzw. interne Richtlinien für stationäre Einrichtung";
                    this.lblELSE_Betrag.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
                    this.lblELSE_Betrag.Text = "monatlicher Grundbedarf für Klienten in stationären Einrichtungen";
                    break;

                case 32011:
                default:
                    this.fraSKOS.Visible = true;
                    this.fraSKOS2005.Visible = false;
                    this.fraELSE.Visible = false;
                    this.lblUeZuschlagI.Visible = true;
                    this.edtUeZuschlagI.Visible = true;

                    this.edtSKOS_Leave(this.chkGBII_Einzel, EventArgs.Empty);
                    break;
            }
        }

        private void edtELSE_Leave(object sender, System.EventArgs e)
        {
            try
            {
                this.edtELSE_Total.EditValue = Convert.ToDecimal(this.edtELSE_Betrag.EditValue)
                    + Convert.ToDecimal(this.edtELSE_Anpassung.EditValue)
                    - Convert.ToDecimal(this.edtAbzugVVG.EditValue);
            }
            catch { }
        }

        private void edtSKOS_Leave(object sender, System.EventArgs e)
        {
            try
            {
                if (sender == this.chkGBII_Einzel)
                {
                    if ((bool)((Gui.KissCheckEdit)sender).EditValue == true)
                    {
                        this.edtGBII_Hg.EditValue = this.qryBgPosition["GBII_Hg_Einzel"];
                        this.edtGrundbedarfII.EditValue = this.qryBgPosition["GBII_Einzel"];
                    }
                    else
                    {
                        this.edtGBII_Hg.EditValue = this.qryBgPosition["GBII_Hg_Gemeinschaft"];
                        this.edtGrundbedarfII.EditValue = this.qryBgPosition["GBII_Gemeinschaft"];
                    }
                }

                this.edtGrundbedarfTotal.EditValue = Convert.ToDecimal(this.edtBetrag.EditValue)
                    + Convert.ToDecimal(this.edtAnpassung.EditValue)
                    + Convert.ToDecimal(this.edtAbzugVVG_SKOS.EditValue)
                    + Convert.ToDecimal(this.edtGrundbedarfZusatz.EditValue)
                    + Convert.ToDecimal(this.edtGrundbedarfII.EditValue)
                    + Convert.ToDecimal(this.edtGBIIAnpassung.EditValue);
            }
            catch { }
        }

        private void edtSKOS2005_Leave(object sender, System.EventArgs e)
        {
            try
            {
                this.edtSKOS2005_Total.EditValue = Convert.ToDecimal(this.edtSKOS2005_UE.EditValue)
                    + Convert.ToDecimal(this.edtSKOS2005_Anpassung.EditValue)
                    - Convert.ToDecimal(this.edtSKOS2005_AbzugVVG.EditValue);
            }
            catch { }
        }
        private void qryBgPosition_AfterFill(object sender, System.EventArgs e)
        {
            if (this.qryBgPosition.Count > 0 && (this.qryBgPosition.CanUpdate || 32015 == (int)this.qryBgPosition["BgPositionsartID"]))
            {
                SqlQuery qry = ShUtil.GetRichtlinie(32015, BgBudgetID);
                if (qry.Count == 1)
                {
                    this.qryBgPosition["SKOS2005_HG"] = qry["HG_DEF"];
                    this.qryBgPosition["SKOS2005_UE"] = qry["UE_DEF"];

                    this.qryBgPosition["SKOS2005_Total"] = (decimal)this.qryBgPosition["SKOS2005_Total"] + (decimal)qry["UE_DEF"];
                }
            }
            this.qryBgPosition.Row.AcceptChanges();
            this.qryBgPosition.RowModified = false;
        }

        private void qryBgPosition_AfterPost(object sender, System.EventArgs e)
        {
            try
            {
                //Diese SP rundet die Beträge des Budgets bereits (kein WhBudget_Runden nötig)
                DBUtil.ExecSQLThrowingException("EXECUTE spWhFinanzplan_Update {0}", BgFinanzplanID);
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

            //Query Refresh, damit die durch die StoredProcedure veränderten Positionen auch korrekt dargestellt werden
            //Damit kein Endlos-Loop entsteht, müssen wir die aktuelle Zeile unmodified markieren
            this.qryBgPosition.RowModified = false;
            this.qryBgPosition.Refresh();
        }

        private void qryBgPosition_BeforePost(object sender, System.EventArgs e)
        {
            switch ((int)this.qryBgPosition["BgPositionsartID"])
            {
                case 32011:  // SKOS
                    DBUtil.CheckNotNullField(edtAnpassung, this.lblGrundbedarfIAnpassung.Text);
                    DBUtil.CheckNotNullField(edtGBIIAnpassung, this.lblGrundbedarfIIAnpassung.Text);

                    this.qryBgPosition["Reduktion"] = (decimal)0 - (decimal)this.qryBgPosition["GrundbedarfI_Anpassung"];
                    this.qryBgPosition["Betrag"] = this.qryBgPosition["Betrag_SKOS"];
                    break;

                case 32015:  // SKOS 2005
                    DBUtil.CheckNotNullField(edtSKOS2005_Anpassung, this.lblSKOS2005_Anpassung.Text);

                    this.qryBgPosition["Reduktion"] = (decimal)0 - (decimal)this.qryBgPosition["SKOS2005_Anpassung"];
                    this.qryBgPosition["Betrag"] = this.qryBgPosition["SKOS2005_UE"];
                    break;

                case 32019:  // Person in stationären Einrichtung
                    DBUtil.CheckNotNullField(this.edtELSE_Betrag, this.lblELSE_Betrag.Text);
                    DBUtil.CheckNotNullField(this.edtELSE_Anpassung, this.lblELSE_Anpassung.Text);

                    decimal PauschaleSTE = Convert.ToDecimal(DBUtil.GetConfigValue(@"System\Sozialhilfe\SKOS\B25_AmountMaximum", DateTime.Today));
                    if (Convert.ToDecimal(this.qryBgPosition["ELSE_Betrag"]) > PauschaleSTE)
                    {
                        this.qryBgPosition["ELSE_Betrag"] = PauschaleSTE;
                        throw new KissErrorException(KissMsg.GetMLMessage("CtlBgGrundbedarf", "MaxPauschale", "Die Pauschale für stationäre Einrichtungen beträgt maximal Fr. {0:n2}", KissMsgCode.MsgError, PauschaleSTE));
                    }
                    goto default;

                default:
                    DBUtil.CheckNotNullField(this.edtELSE_Betrag, this.lblELSE_Betrag.Text);
                    DBUtil.CheckNotNullField(this.edtELSE_Anpassung, this.lblELSE_Anpassung.Text);

                    this.qryBgPosition["Betrag"] = this.qryBgPosition["ELSE_Betrag"];
                    this.qryBgPosition["Reduktion"] = (decimal)0 - (decimal)this.qryBgPosition["ELSE_Anpassung"];
                    break;
            }

            Session.BeginTransaction();
            try
            {
                if ((int)this.qryBgPosition["BgPositionsartID"] == 32011)
                {
                    DBUtil.ExecSQLThrowingException(@"
                    UPDATE BgPosition
                      SET Reduktion       = {1},
                          BgPositionsartID = {2}
                    FROM BgPosition
                    WHERE BgBudgetID = {0} AND BgPositionsartID IN (32013, 32014) "
                        , this.BgBudgetID
                        , (decimal)0 - (decimal)this.qryBgPosition["GrundbedarfII_Anpassung"]
                        , (bool)this.qryBgPosition["GBII_AsOnePerson"] ? 32014 : 32013);
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

        private void qryBgPosition_PositionChanged(object sender, System.EventArgs e)
        {
            edtBgPositionsartCode_EditValueChanged(sender, e);
        }

        #endregion
    }
}