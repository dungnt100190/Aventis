using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace KiSS4.Sozialhilfe
{
    public class CtlBgKrankenkasse : KiSS4.Gui.KissUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        /// <summary>
        /// The BaInstitutionTypID for 'Krankenkasse' type (ZH: 10)
        /// </summary>
        private const int BAINSTITUTIONTYPID_KK = 4;

        #endregion

        #region Private Fields

        private bool abgeschlossen = false;
        private DateTime AnpassenVon;
        private bool bAnpassen = false;
        private int BgBudgetID;
        private KiSS4.Gui.KissButton btnAnpassen;
        private KiSS4.Gui.KissCheckEdit chkDiffMaxBeitragKVG;
        private KiSS4.Gui.KissCheckEdit chkUebernahmeVVG;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colReduktion;
        private DevExpress.XtraGrid.Columns.GridColumn colVVGBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colVVGReduktion;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissLabel dblNamePerson;
        private KiSS4.Gui.KissButtonEdit edtBaInstitution;
        private KiSS4.Gui.KissMemoEdit edtBemerkung;
        private KiSS4.Gui.KissLookUpEdit edtBgPositionsart;
        private KiSS4.Gui.KissCalcEdit edtKVGBeitragDiff;
        private KiSS4.Gui.KissCalcEdit edtKVGBetrag;
        private KissCalcEdit edtKVGLimit;
        private KiSS4.Gui.KissCalcEdit edtKVGMaxBeitrag;
        private KiSS4.Gui.KissCalcEdit edtKVGReduktion;
        private KiSS4.Gui.KissCalcEdit edtKVGTotal;
        private KissCalcEdit edtKVGUnterstuetzt;
        private KissCalcEdit edtKVGUnterstuetztDiff;
        private KissCheckEdit edtNurAktive;
        private KiSS4.Gui.KissCalcEdit edtTotal;
        private KissCalcEdit edtTotalUnterstuetzt;
        private KiSS4.Gui.KissButtonEdit edtVVGBaInstitution;
        private KiSS4.Gui.KissCalcEdit edtVVGBetrag;
        private KiSS4.Gui.KissCalcEdit edtVVGReduktion;
        private KiSS4.Gui.KissCalcEdit edtVVGTotal;
        private KissCalcEdit edtVVGUnterstuetzt;
        private DateTime finanzplanVon;
        private KiSS4.Gui.KissGrid grdBgPosition;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBgPosition;
        private KissLabel kissLabel1;
        private KissLabel kissLabel2;
        private KiSS4.Gui.KissLabel kissLabel5;
        private KiSS4.Gui.KissLabel lblAngerechnet;
        private KiSS4.Gui.KissLabel lblAnpassen;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblBetrag;
        private KiSS4.Gui.KissLabel lblDifferenz;
        private KiSS4.Gui.KissLabel lblEffWwUk;
        private KissLabel lblEquals1;
        private KiSS4.Gui.KissLabel lblKV;
        private KiSS4.Gui.KissLabel lblKVGInstitution;
        private KiSS4.Gui.KissLabel lblMaxBetrag;
        private KiSS4.Gui.KissLabel lblRechnung;
        private KiSS4.Gui.KissLabel lblReduktion;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissLabel lblVVGInstitution;
        private Panel panel1;
        private System.Windows.Forms.PictureBox picTitel;
        private SqlQuery qryBgFinanzplan;
        private KiSS4.DB.SqlQuery qryBgPosition;
        private SqlQuery qryBgPositionsart;
        private string TitelText;

        #endregion

        #endregion

        #region Constructors

        public CtlBgKrankenkasse()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
        }

        public CtlBgKrankenkasse(Image titelImage, string titelText, int bgBudgetID)
            : this()
        {
            this.picTitel.Image = titelImage;
            this.BgBudgetID = bgBudgetID;
            this.TitelText = titelText;

            qryBgFinanzplan = DBUtil.OpenSQL(@"
                SELECT FLE.FaFallID, FLE.FaLeistungID, SFP.BgFinanzplanID,
                  BgBewilligungStatusCode = CASE WHEN FLE.DatumBis IS NOT NULL THEN 9 ELSE SFP.BgBewilligungStatusCode END,
                  FinanzplanVon = IsNull(SFP.DatumVon, SFP.GeplantVon),
                  FinanzplanBis = IsNull(SFP.DatumBis, SFP.GeplantBis),
                  AnpassenVon   = IsNull((SELECT MAX(DATEADD(m, 1, dbo.fnDateSerial(Jahr, Monat, 1))) FROM BgBudget
                                          WHERE BgFinanzplanID = SFP.BgFinanzplanID AND MasterBudget = 0
                                            AND BgBewilligungStatusCode >= 5), SFP.GeplantVon),
                  AnpassenBis      = SFP.DatumBis,
                  LeistungDatumBis = FLE.DatumBis
                FROM dbo.BgBudget             BBG
                  INNER JOIN dbo.BgFinanzplan SFP ON SFP.BgFinanzplanID = BBG.BgFinanzplanID
                  INNER JOIN dbo.FaLeistung   FLE ON FLE.FaLeistungID = SFP.FaLeistungID
                WHERE BBG.BgBudgetID = {0}"
                , bgBudgetID);

            this.lblTitel.Text = string.Format(this.lblTitel.Text, qryBgFinanzplan["FinanzplanVon"], qryBgFinanzplan["FinanzplanBis"], titelText);

            this.abgeschlossen = !DBUtil.IsEmpty(qryBgFinanzplan["LeistungDatumBis"]);

            //zur Bestimmung der gültigen BgPositionsartIDs wird der Gültigkeitsbereich des Finanzplans verwendet.
            finanzplanVon = Utils.ConvertToDateTime(qryBgFinanzplan["FinanzplanVon"]);
            DateTime finanzplanBis = Utils.ConvertToDateTime(qryBgFinanzplan["FinanzplanBis"]);

            this.btnAnpassen.Enabled = this.qryBgPosition.CanUpdate & !this.abgeschlossen;
            ShUtil.ApplyShStatusCodeToSqlQuery(this.qryBgPosition, BgBudgetID);
            this.btnAnpassen.Enabled = this.qryBgPosition.CanUpdate ? false : this.btnAnpassen.Enabled;

            qryBgPositionsart = ShUtil.GetSqlQueryShPositionTyp(LOV.BgGruppeCode.Med_Grundversorgung, LOV.BgPositionsArt.KVG_Erwachsene_Region_1, LOV.BgPositionsArt.KVG_EL, finanzplanVon, finanzplanBis, false);

            this.edtBgPositionsart.LoadQuery(qryBgPositionsart);
            this.edtBgPositionsart.Properties.DropDownRows = Math.Max(9, qryBgPositionsart.Count);

            this.qryBgPosition.Fill(BgBudgetID, qryBgFinanzplan["FinanzplanVon"], edtNurAktive.Checked);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBgKrankenkasse));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblRechnung = new KiSS4.Gui.KissLabel();
            this.dblNamePerson = new KiSS4.Gui.KissLabel();
            this.qryBgPosition = new KiSS4.DB.SqlQuery(this.components);
            this.lblEffWwUk = new KiSS4.Gui.KissLabel();
            this.lblKV = new KiSS4.Gui.KissLabel();
            this.lblAngerechnet = new KiSS4.Gui.KissLabel();
            this.lblReduktion = new KiSS4.Gui.KissLabel();
            this.lblBetrag = new KiSS4.Gui.KissLabel();
            this.kissLabel5 = new KiSS4.Gui.KissLabel();
            this.edtTotal = new KiSS4.Gui.KissCalcEdit();
            this.edtVVGTotal = new KiSS4.Gui.KissCalcEdit();
            this.edtVVGReduktion = new KiSS4.Gui.KissCalcEdit();
            this.edtVVGBetrag = new KiSS4.Gui.KissCalcEdit();
            this.edtKVGBetrag = new KiSS4.Gui.KissCalcEdit();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.grdBgPosition = new KiSS4.Gui.KissGrid();
            this.grvBgPosition = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReduktion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVVGBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVVGReduktion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.edtKVGReduktion = new KiSS4.Gui.KissCalcEdit();
            this.edtKVGTotal = new KiSS4.Gui.KissCalcEdit();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.chkUebernahmeVVG = new KiSS4.Gui.KissCheckEdit();
            this.btnAnpassen = new KiSS4.Gui.KissButton();
            this.lblAnpassen = new KiSS4.Gui.KissLabel();
            this.edtBaInstitution = new KiSS4.Gui.KissButtonEdit();
            this.edtVVGBaInstitution = new KiSS4.Gui.KissButtonEdit();
            this.lblKVGInstitution = new KiSS4.Gui.KissLabel();
            this.lblVVGInstitution = new KiSS4.Gui.KissLabel();
            this.lblMaxBetrag = new KiSS4.Gui.KissLabel();
            this.lblDifferenz = new KiSS4.Gui.KissLabel();
            this.edtKVGBeitragDiff = new KiSS4.Gui.KissCalcEdit();
            this.edtKVGMaxBeitrag = new KiSS4.Gui.KissCalcEdit();
            this.chkDiffMaxBeitragKVG = new KiSS4.Gui.KissCheckEdit();
            this.edtBgPositionsart = new KiSS4.Gui.KissLookUpEdit();
            this.edtKVGLimit = new KiSS4.Gui.KissCalcEdit();
            this.edtKVGUnterstuetzt = new KiSS4.Gui.KissCalcEdit();
            this.edtKVGUnterstuetztDiff = new KiSS4.Gui.KissCalcEdit();
            this.edtTotalUnterstuetzt = new KiSS4.Gui.KissCalcEdit();
            this.edtVVGUnterstuetzt = new KiSS4.Gui.KissCalcEdit();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.lblEquals1 = new KiSS4.Gui.KissLabel();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.edtNurAktive = new KiSS4.Gui.KissCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechnung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dblNamePerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEffWwUk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAngerechnet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReduktion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVVGTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVVGReduktion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVVGBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGReduktion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUebernahmeVVG.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnpassen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaInstitution.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVVGBaInstitution.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKVGInstitution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVVGInstitution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMaxBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDifferenz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGBeitragDiff.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGMaxBeitrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDiffMaxBeitragKVG.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionsart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGLimit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGUnterstuetzt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGUnterstuetztDiff.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTotalUnterstuetzt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVVGUnterstuetzt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEquals1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurAktive.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // lblRechnung
            //
            this.lblRechnung.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblRechnung.Location = new System.Drawing.Point(537, 257);
            this.lblRechnung.Name = "lblRechnung";
            this.lblRechnung.Size = new System.Drawing.Size(112, 16);
            this.lblRechnung.TabIndex = 9;
            this.lblRechnung.Text = "Rechnung";
            //
            // dblNamePerson
            //
            this.dblNamePerson.DataMember = "NameVorname";
            this.dblNamePerson.DataSource = this.qryBgPosition;
            this.dblNamePerson.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.dblNamePerson.Location = new System.Drawing.Point(8, 206);
            this.dblNamePerson.Name = "dblNamePerson";
            this.dblNamePerson.Size = new System.Drawing.Size(528, 16);
            this.dblNamePerson.TabIndex = 2;
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
            this.qryBgPosition.AfterFill += new System.EventHandler(this.qryBgPosition_AfterFill);
            this.qryBgPosition.BeforePost += new System.EventHandler(this.qryBgPosition_BeforePost);
            this.qryBgPosition.AfterPost += new System.EventHandler(this.qryBgPosition_AfterPost);
            this.qryBgPosition.ColumnChanged += new System.Data.DataColumnChangeEventHandler(this.qryBgPosition_ColumnChanged);
            //
            // lblEffWwUk
            //
            this.lblEffWwUk.Location = new System.Drawing.Point(8, 350);
            this.lblEffWwUk.Name = "lblEffWwUk";
            this.lblEffWwUk.Size = new System.Drawing.Size(72, 24);
            this.lblEffWwUk.TabIndex = 23;
            this.lblEffWwUk.Text = "VVG-Beitrag";
            //
            // lblKV
            //
            this.lblKV.Location = new System.Drawing.Point(8, 274);
            this.lblKV.Name = "lblKV";
            this.lblKV.Size = new System.Drawing.Size(80, 24);
            this.lblKV.TabIndex = 10;
            this.lblKV.Text = "KVG-Beitrag";
            //
            // lblAngerechnet
            //
            this.lblAngerechnet.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblAngerechnet.Location = new System.Drawing.Point(410, 257);
            this.lblAngerechnet.Name = "lblAngerechnet";
            this.lblAngerechnet.Size = new System.Drawing.Size(112, 16);
            this.lblAngerechnet.TabIndex = 8;
            this.lblAngerechnet.Text = "Unterstützung";
            //
            // lblReduktion
            //
            this.lblReduktion.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblReduktion.Location = new System.Drawing.Point(265, 257);
            this.lblReduktion.Name = "lblReduktion";
            this.lblReduktion.Size = new System.Drawing.Size(112, 16);
            this.lblReduktion.TabIndex = 7;
            this.lblReduktion.Text = "Reduktion";
            //
            // lblBetrag
            //
            this.lblBetrag.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblBetrag.Location = new System.Drawing.Point(129, 257);
            this.lblBetrag.Name = "lblBetrag";
            this.lblBetrag.Size = new System.Drawing.Size(112, 16);
            this.lblBetrag.TabIndex = 6;
            this.lblBetrag.Text = "Effektiv";
            //
            // kissLabel5
            //
            this.kissLabel5.Location = new System.Drawing.Point(249, 349);
            this.kissLabel5.Name = "kissLabel5";
            this.kissLabel5.Size = new System.Drawing.Size(8, 24);
            this.kissLabel5.TabIndex = 25;
            this.kissLabel5.Text = "-";
            //
            // edtTotal
            //
            this.edtTotal.DataMember = "Total";
            this.edtTotal.DataSource = this.qryBgPosition;
            this.edtTotal.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtTotal.Location = new System.Drawing.Point(540, 380);
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
            this.edtTotal.Size = new System.Drawing.Size(112, 24);
            this.edtTotal.TabIndex = 32;
            this.edtTotal.TabStop = false;
            //
            // edtVVGTotal
            //
            this.edtVVGTotal.DataMember = "VVGTotal";
            this.edtVVGTotal.DataSource = this.qryBgPosition;
            this.edtVVGTotal.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtVVGTotal.Location = new System.Drawing.Point(540, 350);
            this.edtVVGTotal.Name = "edtVVGTotal";
            this.edtVVGTotal.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVVGTotal.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVVGTotal.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVVGTotal.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVVGTotal.Properties.Appearance.Options.UseBackColor = true;
            this.edtVVGTotal.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVVGTotal.Properties.Appearance.Options.UseFont = true;
            this.edtVVGTotal.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVVGTotal.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVVGTotal.Properties.DisplayFormat.FormatString = "n2";
            this.edtVVGTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtVVGTotal.Properties.EditFormat.FormatString = "n2";
            this.edtVVGTotal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtVVGTotal.Properties.ReadOnly = true;
            this.edtVVGTotal.Size = new System.Drawing.Size(112, 24);
            this.edtVVGTotal.TabIndex = 28;
            this.edtVVGTotal.TabStop = false;
            //
            // edtVVGReduktion
            //
            this.edtVVGReduktion.DataMember = "VVGReduktion";
            this.edtVVGReduktion.DataSource = this.qryBgPosition;
            this.edtVVGReduktion.Location = new System.Drawing.Point(263, 350);
            this.edtVVGReduktion.Name = "edtVVGReduktion";
            this.edtVVGReduktion.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVVGReduktion.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVVGReduktion.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVVGReduktion.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVVGReduktion.Properties.Appearance.Options.UseBackColor = true;
            this.edtVVGReduktion.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVVGReduktion.Properties.Appearance.Options.UseFont = true;
            this.edtVVGReduktion.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVVGReduktion.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVVGReduktion.Properties.DisplayFormat.FormatString = "n2";
            this.edtVVGReduktion.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtVVGReduktion.Properties.EditFormat.FormatString = "n2";
            this.edtVVGReduktion.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtVVGReduktion.Size = new System.Drawing.Size(112, 24);
            this.edtVVGReduktion.TabIndex = 26;
            //
            // edtVVGBetrag
            //
            this.edtVVGBetrag.DataMember = "VVGBetrag";
            this.edtVVGBetrag.DataSource = this.qryBgPosition;
            this.edtVVGBetrag.Location = new System.Drawing.Point(129, 350);
            this.edtVVGBetrag.Name = "edtVVGBetrag";
            this.edtVVGBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVVGBetrag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVVGBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVVGBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVVGBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtVVGBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVVGBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtVVGBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVVGBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVVGBetrag.Properties.DisplayFormat.FormatString = "n2";
            this.edtVVGBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtVVGBetrag.Properties.EditFormat.FormatString = "n2";
            this.edtVVGBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtVVGBetrag.Size = new System.Drawing.Size(112, 24);
            this.edtVVGBetrag.TabIndex = 24;
            //
            // edtKVGBetrag
            //
            this.edtKVGBetrag.DataMember = "KVGBetrag";
            this.edtKVGBetrag.DataSource = this.qryBgPosition;
            this.edtKVGBetrag.Location = new System.Drawing.Point(129, 274);
            this.edtKVGBetrag.Name = "edtKVGBetrag";
            this.edtKVGBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtKVGBetrag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKVGBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKVGBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKVGBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtKVGBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKVGBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtKVGBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKVGBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKVGBetrag.Properties.DisplayFormat.FormatString = "n2";
            this.edtKVGBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtKVGBetrag.Properties.EditFormat.FormatString = "n2";
            this.edtKVGBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtKVGBetrag.Size = new System.Drawing.Size(112, 24);
            this.edtKVGBetrag.TabIndex = 11;
            //
            // lblBemerkung
            //
            this.lblBemerkung.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblBemerkung.Location = new System.Drawing.Point(8, 470);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(112, 16);
            this.lblBemerkung.TabIndex = 37;
            this.lblBemerkung.Text = "Beschreibung";
            //
            // lblTitel
            //
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(32, 8);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(640, 16);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Monatliche KVG- und VVG-Beiträge vom {0:d} bis {1:d}";
            //
            // grdBgPosition
            //
            this.grdBgPosition.DataSource = this.qryBgPosition;
            //
            //
            //
            this.grdBgPosition.EmbeddedNavigator.Name = "";
            this.grdBgPosition.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBgPosition.Location = new System.Drawing.Point(8, 38);
            this.grdBgPosition.MainView = this.grvBgPosition;
            this.grdBgPosition.Name = "grdBgPosition";
            this.grdBgPosition.Size = new System.Drawing.Size(664, 163);
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
            this.colBetrag,
            this.colReduktion,
            this.colVVGBetrag,
            this.colVVGReduktion});
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
            this.colDatumVon.DisplayFormat.FormatString = "Y";
            this.colDatumVon.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDatumVon.FieldName = "DatumVon";
            this.colDatumVon.Name = "colDatumVon";
            this.colDatumVon.Visible = true;
            this.colDatumVon.VisibleIndex = 0;
            this.colDatumVon.Width = 110;
            //
            // colName
            //
            this.colName.Caption = "Name";
            this.colName.FieldName = "NameVorname";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 177;
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
            // colBetrag
            //
            this.colBetrag.AppearanceCell.Options.UseTextOptions = true;
            this.colBetrag.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colBetrag.Caption = "KVG";
            this.colBetrag.DisplayFormat.FormatString = "n2";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.FieldName = "KVGBetrag";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.SummaryItem.DisplayFormat = "{0:n2}";
            this.colBetrag.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 3;
            this.colBetrag.Width = 65;
            //
            // colReduktion
            //
            this.colReduktion.AppearanceCell.Options.UseTextOptions = true;
            this.colReduktion.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colReduktion.Caption = "KVG Red.";
            this.colReduktion.DisplayFormat.FormatString = "n2";
            this.colReduktion.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colReduktion.FieldName = "KVGReduktion";
            this.colReduktion.Name = "colReduktion";
            this.colReduktion.SummaryItem.DisplayFormat = "{0:n2}";
            this.colReduktion.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colReduktion.Visible = true;
            this.colReduktion.VisibleIndex = 4;
            this.colReduktion.Width = 65;
            //
            // colVVGBetrag
            //
            this.colVVGBetrag.AppearanceCell.Options.UseTextOptions = true;
            this.colVVGBetrag.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colVVGBetrag.Caption = "VVG";
            this.colVVGBetrag.DisplayFormat.FormatString = "n2";
            this.colVVGBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colVVGBetrag.FieldName = "VVGBetrag";
            this.colVVGBetrag.Name = "colVVGBetrag";
            this.colVVGBetrag.SummaryItem.DisplayFormat = "{0:n2}";
            this.colVVGBetrag.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colVVGBetrag.Visible = true;
            this.colVVGBetrag.VisibleIndex = 5;
            this.colVVGBetrag.Width = 65;
            //
            // colVVGReduktion
            //
            this.colVVGReduktion.AppearanceCell.Options.UseTextOptions = true;
            this.colVVGReduktion.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colVVGReduktion.Caption = "VVG Red.";
            this.colVVGReduktion.DisplayFormat.FormatString = "n2";
            this.colVVGReduktion.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colVVGReduktion.FieldName = "VVGReduktion";
            this.colVVGReduktion.Name = "colVVGReduktion";
            this.colVVGReduktion.SummaryItem.DisplayFormat = "{0:n2}";
            this.colVVGReduktion.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colVVGReduktion.Visible = true;
            this.colVVGReduktion.VisibleIndex = 6;
            this.colVVGReduktion.Width = 65;
            //
            // edtBemerkung
            //
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryBgPosition;
            this.edtBemerkung.Location = new System.Drawing.Point(8, 487);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(664, 64);
            this.edtBemerkung.TabIndex = 38;
            //
            // edtKVGReduktion
            //
            this.edtKVGReduktion.DataMember = "KVGReduktion";
            this.edtKVGReduktion.DataSource = this.qryBgPosition;
            this.edtKVGReduktion.Location = new System.Drawing.Point(265, 297);
            this.edtKVGReduktion.Name = "edtKVGReduktion";
            this.edtKVGReduktion.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtKVGReduktion.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKVGReduktion.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKVGReduktion.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKVGReduktion.Properties.Appearance.Options.UseBackColor = true;
            this.edtKVGReduktion.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKVGReduktion.Properties.Appearance.Options.UseFont = true;
            this.edtKVGReduktion.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKVGReduktion.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKVGReduktion.Properties.DisplayFormat.FormatString = "n2";
            this.edtKVGReduktion.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtKVGReduktion.Properties.EditFormat.FormatString = "n2";
            this.edtKVGReduktion.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtKVGReduktion.Size = new System.Drawing.Size(112, 24);
            this.edtKVGReduktion.TabIndex = 15;
            //
            // edtKVGTotal
            //
            this.edtKVGTotal.DataMember = "KVGTotal";
            this.edtKVGTotal.DataSource = this.qryBgPosition;
            this.edtKVGTotal.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKVGTotal.Location = new System.Drawing.Point(540, 320);
            this.edtKVGTotal.Name = "edtKVGTotal";
            this.edtKVGTotal.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtKVGTotal.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKVGTotal.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKVGTotal.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKVGTotal.Properties.Appearance.Options.UseBackColor = true;
            this.edtKVGTotal.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKVGTotal.Properties.Appearance.Options.UseFont = true;
            this.edtKVGTotal.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKVGTotal.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKVGTotal.Properties.DisplayFormat.FormatString = "n2";
            this.edtKVGTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtKVGTotal.Properties.EditFormat.FormatString = "n2";
            this.edtKVGTotal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtKVGTotal.Properties.ReadOnly = true;
            this.edtKVGTotal.Size = new System.Drawing.Size(112, 24);
            this.edtKVGTotal.TabIndex = 22;
            this.edtKVGTotal.TabStop = false;
            //
            // picTitel
            //
            this.picTitel.Location = new System.Drawing.Point(8, 8);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 69;
            this.picTitel.TabStop = false;
            //
            // chkUebernahmeVVG
            //
            this.chkUebernahmeVVG.DataMember = "VVGBeitragSD";
            this.chkUebernahmeVVG.DataSource = this.qryBgPosition;
            this.chkUebernahmeVVG.Location = new System.Drawing.Point(129, 380);
            this.chkUebernahmeVVG.Name = "chkUebernahmeVVG";
            this.chkUebernahmeVVG.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkUebernahmeVVG.Properties.Appearance.Options.UseBackColor = true;
            this.chkUebernahmeVVG.Properties.Caption = "VVG Beitrag wird durch den SD übernommen";
            this.chkUebernahmeVVG.Size = new System.Drawing.Size(384, 19);
            this.chkUebernahmeVVG.TabIndex = 30;
            //
            // btnAnpassen
            //
            this.btnAnpassen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnpassen.Location = new System.Drawing.Point(424, 559);
            this.btnAnpassen.Name = "btnAnpassen";
            this.btnAnpassen.Size = new System.Drawing.Size(248, 24);
            this.btnAnpassen.TabIndex = 40;
            this.btnAnpassen.Text = "bewilligte Beiträge anpassen ...";
            this.btnAnpassen.UseVisualStyleBackColor = false;
            this.btnAnpassen.Click += new System.EventHandler(this.btnAnpassen_Click);
            //
            // lblAnpassen
            //
            this.lblAnpassen.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblAnpassen.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblAnpassen.Location = new System.Drawing.Point(16, 564);
            this.lblAnpassen.Name = "lblAnpassen";
            this.lblAnpassen.Size = new System.Drawing.Size(392, 16);
            this.lblAnpassen.TabIndex = 39;
            this.lblAnpassen.Text = "";
            this.lblAnpassen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // edtBaInstitution
            //
            this.edtBaInstitution.DataMember = "InstitutionName";
            this.edtBaInstitution.DataSource = this.qryBgPosition;
            this.edtBaInstitution.Location = new System.Drawing.Point(132, 416);
            this.edtBaInstitution.Name = "edtBaInstitution";
            this.edtBaInstitution.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBaInstitution.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaInstitution.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaInstitution.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaInstitution.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaInstitution.Properties.Appearance.Options.UseFont = true;
            this.edtBaInstitution.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtBaInstitution.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtBaInstitution.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaInstitution.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtBaInstitution.Size = new System.Drawing.Size(248, 24);
            this.edtBaInstitution.TabIndex = 34;
            this.edtBaInstitution.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtBaInstitution_UserModifiedFld);
            //
            // edtVVGBaInstitution
            //
            this.edtVVGBaInstitution.DataMember = "VVGInstitutionName";
            this.edtVVGBaInstitution.DataSource = this.qryBgPosition;
            this.edtVVGBaInstitution.Location = new System.Drawing.Point(132, 446);
            this.edtVVGBaInstitution.Name = "edtVVGBaInstitution";
            this.edtVVGBaInstitution.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVVGBaInstitution.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVVGBaInstitution.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVVGBaInstitution.Properties.Appearance.Options.UseBackColor = true;
            this.edtVVGBaInstitution.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVVGBaInstitution.Properties.Appearance.Options.UseFont = true;
            this.edtVVGBaInstitution.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtVVGBaInstitution.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtVVGBaInstitution.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVVGBaInstitution.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtVVGBaInstitution.Size = new System.Drawing.Size(248, 24);
            this.edtVVGBaInstitution.TabIndex = 36;
            this.edtVVGBaInstitution.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtVVGBaInstitution_UserModifiedFld);
            //
            // lblKVGInstitution
            //
            this.lblKVGInstitution.Location = new System.Drawing.Point(8, 416);
            this.lblKVGInstitution.Name = "lblKVGInstitution";
            this.lblKVGInstitution.Size = new System.Drawing.Size(72, 24);
            this.lblKVGInstitution.TabIndex = 33;
            this.lblKVGInstitution.Text = "KVG Kasse";
            //
            // lblVVGInstitution
            //
            this.lblVVGInstitution.Location = new System.Drawing.Point(8, 446);
            this.lblVVGInstitution.Name = "lblVVGInstitution";
            this.lblVVGInstitution.Size = new System.Drawing.Size(72, 24);
            this.lblVVGInstitution.TabIndex = 35;
            this.lblVVGInstitution.Text = "VVG Kasse";
            //
            // lblMaxBetrag
            //
            this.lblMaxBetrag.Location = new System.Drawing.Point(8, 230);
            this.lblMaxBetrag.Name = "lblMaxBetrag";
            this.lblMaxBetrag.Size = new System.Drawing.Size(101, 24);
            this.lblMaxBetrag.TabIndex = 3;
            this.lblMaxBetrag.Text = "KVG-max. Beitrag";
            //
            // lblDifferenz
            //
            this.lblDifferenz.Location = new System.Drawing.Point(8, 320);
            this.lblDifferenz.Name = "lblDifferenz";
            this.lblDifferenz.Size = new System.Drawing.Size(121, 24);
            this.lblDifferenz.TabIndex = 18;
            this.lblDifferenz.Text = "KVG-Beitrag Differenz";
            //
            // edtKVGBeitragDiff
            //
            this.edtKVGBeitragDiff.DataMember = "KVGBeitragDiff";
            this.edtKVGBeitragDiff.DataSource = this.qryBgPosition;
            this.edtKVGBeitragDiff.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKVGBeitragDiff.Location = new System.Drawing.Point(129, 320);
            this.edtKVGBeitragDiff.Name = "edtKVGBeitragDiff";
            this.edtKVGBeitragDiff.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtKVGBeitragDiff.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKVGBeitragDiff.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKVGBeitragDiff.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKVGBeitragDiff.Properties.Appearance.Options.UseBackColor = true;
            this.edtKVGBeitragDiff.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKVGBeitragDiff.Properties.Appearance.Options.UseFont = true;
            this.edtKVGBeitragDiff.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKVGBeitragDiff.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKVGBeitragDiff.Properties.DisplayFormat.FormatString = "n2";
            this.edtKVGBeitragDiff.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtKVGBeitragDiff.Properties.EditFormat.FormatString = "n2";
            this.edtKVGBeitragDiff.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtKVGBeitragDiff.Properties.ReadOnly = true;
            this.edtKVGBeitragDiff.Size = new System.Drawing.Size(112, 24);
            this.edtKVGBeitragDiff.TabIndex = 19;
            this.edtKVGBeitragDiff.TabStop = false;
            //
            // edtKVGMaxBeitrag
            //
            this.edtKVGMaxBeitrag.DataMember = "KVGMaxBeitrag";
            this.edtKVGMaxBeitrag.DataSource = this.qryBgPosition;
            this.edtKVGMaxBeitrag.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKVGMaxBeitrag.Location = new System.Drawing.Point(129, 297);
            this.edtKVGMaxBeitrag.Name = "edtKVGMaxBeitrag";
            this.edtKVGMaxBeitrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtKVGMaxBeitrag.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKVGMaxBeitrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKVGMaxBeitrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKVGMaxBeitrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtKVGMaxBeitrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKVGMaxBeitrag.Properties.Appearance.Options.UseFont = true;
            this.edtKVGMaxBeitrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKVGMaxBeitrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKVGMaxBeitrag.Properties.DisplayFormat.FormatString = "n2";
            this.edtKVGMaxBeitrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtKVGMaxBeitrag.Properties.EditFormat.FormatString = "n2";
            this.edtKVGMaxBeitrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtKVGMaxBeitrag.Properties.ReadOnly = true;
            this.edtKVGMaxBeitrag.Size = new System.Drawing.Size(112, 24);
            this.edtKVGMaxBeitrag.TabIndex = 13;
            this.edtKVGMaxBeitrag.TabStop = false;
            //
            // chkDiffMaxBeitragKVG
            //
            this.chkDiffMaxBeitragKVG.DataMember = "KVGBeitragSD";
            this.chkDiffMaxBeitragKVG.DataSource = this.qryBgPosition;
            this.chkDiffMaxBeitragKVG.Location = new System.Drawing.Point(247, 324);
            this.chkDiffMaxBeitragKVG.Name = "chkDiffMaxBeitragKVG";
            this.chkDiffMaxBeitragKVG.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkDiffMaxBeitragKVG.Properties.Appearance.Options.UseBackColor = true;
            this.chkDiffMaxBeitragKVG.Properties.Caption = "durch den SD übernommen";
            this.chkDiffMaxBeitragKVG.Size = new System.Drawing.Size(150, 19);
            this.chkDiffMaxBeitragKVG.TabIndex = 20;
            //
            // edtBgPositionsart
            //
            this.edtBgPositionsart.DataMember = "BgPositionsartID";
            this.edtBgPositionsart.DataSource = this.qryBgPosition;
            this.edtBgPositionsart.Location = new System.Drawing.Point(129, 230);
            this.edtBgPositionsart.Name = "edtBgPositionsart";
            this.edtBgPositionsart.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBgPositionsart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgPositionsart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgPositionsart.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgPositionsart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgPositionsart.Properties.Appearance.Options.UseFont = true;
            this.edtBgPositionsart.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBgPositionsart.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgPositionsart.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBgPositionsart.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBgPositionsart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtBgPositionsart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtBgPositionsart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgPositionsart.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.edtBgPositionsart.Properties.DisplayMember = "Text";
            this.edtBgPositionsart.Properties.NullText = "";
            this.edtBgPositionsart.Properties.ShowFooter = false;
            this.edtBgPositionsart.Properties.ShowHeader = false;
            this.edtBgPositionsart.Properties.ValueMember = "Code";
            this.edtBgPositionsart.Size = new System.Drawing.Size(248, 24);
            this.edtBgPositionsart.TabIndex = 4;
            //
            // edtKVGLimit
            //
            this.edtKVGLimit.DataMember = "KVGLimit";
            this.edtKVGLimit.DataSource = this.qryBgPosition;
            this.edtKVGLimit.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKVGLimit.Location = new System.Drawing.Point(413, 230);
            this.edtKVGLimit.Name = "edtKVGLimit";
            this.edtKVGLimit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtKVGLimit.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKVGLimit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKVGLimit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKVGLimit.Properties.Appearance.Options.UseBackColor = true;
            this.edtKVGLimit.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKVGLimit.Properties.Appearance.Options.UseFont = true;
            this.edtKVGLimit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKVGLimit.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKVGLimit.Properties.DisplayFormat.FormatString = "n2";
            this.edtKVGLimit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtKVGLimit.Properties.EditFormat.FormatString = "n2";
            this.edtKVGLimit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtKVGLimit.Properties.ReadOnly = true;
            this.edtKVGLimit.Size = new System.Drawing.Size(112, 24);
            this.edtKVGLimit.TabIndex = 5;
            this.edtKVGLimit.TabStop = false;
            //
            // edtKVGUnterstuetzt
            //
            this.edtKVGUnterstuetzt.DataMember = "KVGUnterstuetzt";
            this.edtKVGUnterstuetzt.DataSource = this.qryBgPosition;
            this.edtKVGUnterstuetzt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKVGUnterstuetzt.Location = new System.Drawing.Point(413, 297);
            this.edtKVGUnterstuetzt.Name = "edtKVGUnterstuetzt";
            this.edtKVGUnterstuetzt.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtKVGUnterstuetzt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKVGUnterstuetzt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKVGUnterstuetzt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKVGUnterstuetzt.Properties.Appearance.Options.UseBackColor = true;
            this.edtKVGUnterstuetzt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKVGUnterstuetzt.Properties.Appearance.Options.UseFont = true;
            this.edtKVGUnterstuetzt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKVGUnterstuetzt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKVGUnterstuetzt.Properties.DisplayFormat.FormatString = "n2";
            this.edtKVGUnterstuetzt.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtKVGUnterstuetzt.Properties.EditFormat.FormatString = "n2";
            this.edtKVGUnterstuetzt.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtKVGUnterstuetzt.Properties.ReadOnly = true;
            this.edtKVGUnterstuetzt.Size = new System.Drawing.Size(112, 24);
            this.edtKVGUnterstuetzt.TabIndex = 17;
            this.edtKVGUnterstuetzt.TabStop = false;
            //
            // edtKVGUnterstuetztDiff
            //
            this.edtKVGUnterstuetztDiff.DataMember = "KVGUnterstuetztDiff";
            this.edtKVGUnterstuetztDiff.DataSource = this.qryBgPosition;
            this.edtKVGUnterstuetztDiff.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKVGUnterstuetztDiff.Location = new System.Drawing.Point(413, 320);
            this.edtKVGUnterstuetztDiff.Name = "edtKVGUnterstuetztDiff";
            this.edtKVGUnterstuetztDiff.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtKVGUnterstuetztDiff.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKVGUnterstuetztDiff.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKVGUnterstuetztDiff.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKVGUnterstuetztDiff.Properties.Appearance.Options.UseBackColor = true;
            this.edtKVGUnterstuetztDiff.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKVGUnterstuetztDiff.Properties.Appearance.Options.UseFont = true;
            this.edtKVGUnterstuetztDiff.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKVGUnterstuetztDiff.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKVGUnterstuetztDiff.Properties.DisplayFormat.FormatString = "n2";
            this.edtKVGUnterstuetztDiff.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtKVGUnterstuetztDiff.Properties.EditFormat.FormatString = "n2";
            this.edtKVGUnterstuetztDiff.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtKVGUnterstuetztDiff.Properties.ReadOnly = true;
            this.edtKVGUnterstuetztDiff.Size = new System.Drawing.Size(112, 24);
            this.edtKVGUnterstuetztDiff.TabIndex = 21;
            this.edtKVGUnterstuetztDiff.TabStop = false;
            //
            // edtTotalUnterstuetzt
            //
            this.edtTotalUnterstuetzt.DataMember = "TotalUnterstuetzt";
            this.edtTotalUnterstuetzt.DataSource = this.qryBgPosition;
            this.edtTotalUnterstuetzt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtTotalUnterstuetzt.Location = new System.Drawing.Point(413, 380);
            this.edtTotalUnterstuetzt.Name = "edtTotalUnterstuetzt";
            this.edtTotalUnterstuetzt.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtTotalUnterstuetzt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtTotalUnterstuetzt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTotalUnterstuetzt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTotalUnterstuetzt.Properties.Appearance.Options.UseBackColor = true;
            this.edtTotalUnterstuetzt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTotalUnterstuetzt.Properties.Appearance.Options.UseFont = true;
            this.edtTotalUnterstuetzt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTotalUnterstuetzt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTotalUnterstuetzt.Properties.DisplayFormat.FormatString = "n2";
            this.edtTotalUnterstuetzt.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtTotalUnterstuetzt.Properties.EditFormat.FormatString = "n2";
            this.edtTotalUnterstuetzt.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtTotalUnterstuetzt.Properties.ReadOnly = true;
            this.edtTotalUnterstuetzt.Size = new System.Drawing.Size(112, 24);
            this.edtTotalUnterstuetzt.TabIndex = 31;
            this.edtTotalUnterstuetzt.TabStop = false;
            //
            // edtVVGUnterstuetzt
            //
            this.edtVVGUnterstuetzt.DataMember = "VVGUnterstuetzt";
            this.edtVVGUnterstuetzt.DataSource = this.qryBgPosition;
            this.edtVVGUnterstuetzt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtVVGUnterstuetzt.Location = new System.Drawing.Point(413, 350);
            this.edtVVGUnterstuetzt.Name = "edtVVGUnterstuetzt";
            this.edtVVGUnterstuetzt.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVVGUnterstuetzt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVVGUnterstuetzt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVVGUnterstuetzt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVVGUnterstuetzt.Properties.Appearance.Options.UseBackColor = true;
            this.edtVVGUnterstuetzt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVVGUnterstuetzt.Properties.Appearance.Options.UseFont = true;
            this.edtVVGUnterstuetzt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVVGUnterstuetzt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVVGUnterstuetzt.Properties.DisplayFormat.FormatString = "n2";
            this.edtVVGUnterstuetzt.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtVVGUnterstuetzt.Properties.EditFormat.FormatString = "n2";
            this.edtVVGUnterstuetzt.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtVVGUnterstuetzt.Properties.ReadOnly = true;
            this.edtVVGUnterstuetzt.Size = new System.Drawing.Size(112, 24);
            this.edtVVGUnterstuetzt.TabIndex = 27;
            this.edtVVGUnterstuetzt.TabStop = false;
            //
            // kissLabel2
            //
            this.kissLabel2.Location = new System.Drawing.Point(251, 297);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(8, 24);
            this.kissLabel2.TabIndex = 14;
            this.kissLabel2.Text = "-";
            //
            // lblEquals1
            //
            this.lblEquals1.Location = new System.Drawing.Point(389, 297);
            this.lblEquals1.Name = "lblEquals1";
            this.lblEquals1.Size = new System.Drawing.Size(8, 24);
            this.lblEquals1.TabIndex = 16;
            this.lblEquals1.Text = "=";
            //
            // kissLabel1
            //
            this.kissLabel1.Location = new System.Drawing.Point(8, 297);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(101, 24);
            this.kissLabel1.TabIndex = 12;
            this.kissLabel1.Text = "KVG-max. Beitrag";
            //
            // panel1
            //
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(413, 376);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(239, 1);
            this.panel1.TabIndex = 29;
            //
            // edtNurAktive
            //
            this.edtNurAktive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtNurAktive.DataMember = "KVGBeitragSD";
            this.edtNurAktive.EditValue = false;
            this.edtNurAktive.Location = new System.Drawing.Point(522, 13);
            this.edtNurAktive.Name = "edtNurAktive";
            this.edtNurAktive.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtNurAktive.Properties.Appearance.Options.UseBackColor = true;
            this.edtNurAktive.Properties.Caption = "Nur aktuelle anzeigen";
            this.edtNurAktive.Size = new System.Drawing.Size(150, 19);
            this.edtNurAktive.TabIndex = 20;
            this.edtNurAktive.CheckedChanged += new System.EventHandler(this.edtNurAktive_CheckedChanged);
            //
            // CtlBgKrankenkasse
            //
            this.ActiveSQLQuery = this.qryBgPosition;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(679, 589);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kissLabel1);
            this.Controls.Add(this.edtVVGUnterstuetzt);
            this.Controls.Add(this.edtTotalUnterstuetzt);
            this.Controls.Add(this.edtKVGUnterstuetztDiff);
            this.Controls.Add(this.edtKVGUnterstuetzt);
            this.Controls.Add(this.edtKVGLimit);
            this.Controls.Add(this.edtBgPositionsart);
            this.Controls.Add(this.edtNurAktive);
            this.Controls.Add(this.chkDiffMaxBeitragKVG);
            this.Controls.Add(this.edtKVGMaxBeitrag);
            this.Controls.Add(this.edtKVGBeitragDiff);
            this.Controls.Add(this.lblDifferenz);
            this.Controls.Add(this.lblMaxBetrag);
            this.Controls.Add(this.lblVVGInstitution);
            this.Controls.Add(this.lblKVGInstitution);
            this.Controls.Add(this.edtVVGBaInstitution);
            this.Controls.Add(this.edtBaInstitution);
            this.Controls.Add(this.lblAnpassen);
            this.Controls.Add(this.btnAnpassen);
            this.Controls.Add(this.grdBgPosition);
            this.Controls.Add(this.chkUebernahmeVVG);
            this.Controls.Add(this.picTitel);
            this.Controls.Add(this.lblEquals1);
            this.Controls.Add(this.edtKVGTotal);
            this.Controls.Add(this.kissLabel2);
            this.Controls.Add(this.edtKVGReduktion);
            this.Controls.Add(this.dblNamePerson);
            this.Controls.Add(this.lblEffWwUk);
            this.Controls.Add(this.lblKV);
            this.Controls.Add(this.lblAngerechnet);
            this.Controls.Add(this.lblReduktion);
            this.Controls.Add(this.lblBetrag);
            this.Controls.Add(this.kissLabel5);
            this.Controls.Add(this.edtTotal);
            this.Controls.Add(this.edtVVGTotal);
            this.Controls.Add(this.edtVVGReduktion);
            this.Controls.Add(this.edtVVGBetrag);
            this.Controls.Add(this.edtKVGBetrag);
            this.Controls.Add(this.lblBemerkung);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.edtBemerkung);
            this.Controls.Add(this.lblRechnung);
            this.Name = "CtlBgKrankenkasse";
            this.Size = new System.Drawing.Size(690, 600);
            ((System.ComponentModel.ISupportInitialize)(this.lblRechnung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dblNamePerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEffWwUk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAngerechnet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReduktion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVVGTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVVGReduktion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVVGBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGReduktion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUebernahmeVVG.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnpassen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaInstitution.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVVGBaInstitution.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKVGInstitution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVVGInstitution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMaxBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDifferenz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGBeitragDiff.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGMaxBeitrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDiffMaxBeitragKVG.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionsart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGLimit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGUnterstuetzt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGUnterstuetztDiff.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTotalUnterstuetzt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVVGUnterstuetzt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEquals1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurAktive.Properties)).EndInit();
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

        private void btnAnpassen_Click(object sender, System.EventArgs e)
        {
            if (!((IKissDataNavigator)this).SaveData())
                return;

            if (this.bAnpassen)
            {
                this.bAnpassen = false;
                this.lblAnpassen.Text = "";
                this.btnAnpassen.Text = "Beiträge anpassen...";
                this.qryBgPosition.CanUpdate = false;
                this.qryBgPosition.EnableBoundFields(false);

                this.qryBgPosition.Refresh();
                this.qryBgPosition.DataTable.DefaultView.RowFilter = "";
                return;
            }

            DlgWhPositionAnpassen dlg = new DlgWhPositionAnpassen(DlgWhPositionAnpassen.AnpassungTyp.Krankenkasse
                , (DateTime)this.qryBgFinanzplan["AnpassenVon"], (DateTime)this.qryBgFinanzplan["AnpassenBis"]);

            dlg.ShowDialog(this);

            if (dlg.UserCancel)
                return;

            bAnpassen = true;
            AnpassenVon = dlg.DatumVon;

            this.lblAnpassen.Text = string.Format("Die Beiträge gelten ab {0:Y}", AnpassenVon);
            this.btnAnpassen.Text = "Bearbeitung abschliessen";

            object bgBudgetId = qryBgPosition["BgBudgetId"]; //geht einfacher zum debuggen

            DBUtil.ExecSQLThrowingException(600, "EXEC spWhAlleKVGVVGAnpassen {0}, {1}", bgBudgetId, AnpassenVon);

            qryBgPosition.Refresh();

            this.qryBgPosition.DataTable.DefaultView.RowFilter = string.Format("DatumVon = {0}",
                this.AnpassenVon.ToString(@"\#MM\/dd\/yyyy\#"));

            this.qryBgPosition.CanUpdate = true;
            this.qryBgPosition.EnableBoundFields(true);
        }

        private void edtBaInstitution_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string searchString = edtBaInstitution.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryBgPosition["BaInstitutionID"] = DBNull.Value;
                    qryBgPosition["InstitutionName"] = DBNull.Value;
                    return;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();

            e.Cancel = !dlg.SearchData(GetKKInstitutionSearchSQL(searchString), searchString, e.ButtonClicked);

            if (!e.Cancel)
            {
                qryBgPosition["BaInstitutionID"] = dlg[0];
                qryBgPosition["InstitutionName"] = dlg[1];
            }
        }

        private void edtNurAktive_CheckedChanged(object sender, EventArgs e)
        {
            this.qryBgPosition.Fill(BgBudgetID, qryBgFinanzplan["FinanzplanVon"], edtNurAktive.Checked);
        }

        private void edtVVGBaInstitution_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string searchString = edtVVGBaInstitution.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryBgPosition["VVGBaInstitutionID"] = DBNull.Value;
                    qryBgPosition["VVGInstitutionName"] = DBNull.Value;
                    return;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();

            e.Cancel = !dlg.SearchData(GetKKInstitutionSearchSQL(searchString), searchString, e.ButtonClicked);

            if (!e.Cancel)
            {
                qryBgPosition["VVGBaInstitutionID"] = dlg[0];
                qryBgPosition["VVGInstitutionName"] = dlg[1];
            }
        }

        private void qryBgPosition_AfterFill(object sender, EventArgs e)
        {
            foreach (DataRow row in qryBgPosition.DataTable.Rows)
            {
                if (!DBUtil.IsEmpty(row["KVGLimit"]))
                {
                    row[edtKVGMaxBeitrag.DataMember] = Math.Min((decimal)row[edtKVGBetrag.DataMember], (decimal)row[edtKVGLimit.DataMember]);
                    row[edtKVGBeitragDiff.DataMember] = (decimal)row[edtKVGBetrag.DataMember] - (decimal)row[edtKVGMaxBeitrag.DataMember];

                    row[edtKVGUnterstuetzt.DataMember] = (decimal)row[edtKVGMaxBeitrag.DataMember] - (decimal)row[edtKVGReduktion.DataMember];
                    row[edtKVGUnterstuetztDiff.DataMember] = (bool)row[chkDiffMaxBeitragKVG.DataMember] ? (decimal)row[edtKVGBeitragDiff.DataMember] : decimal.Zero;

                    row[edtVVGUnterstuetzt.DataMember] = (bool)row[chkUebernahmeVVG.DataMember] ? (decimal)row[edtVVGTotal.DataMember] : decimal.Zero;

                    row[edtTotalUnterstuetzt.DataMember] = (decimal)row[edtKVGUnterstuetzt.DataMember] + (decimal)row[edtKVGUnterstuetztDiff.DataMember]
                        + (decimal)row[edtVVGUnterstuetzt.DataMember];
                }

                row.AcceptChanges();
                qryBgPosition.RowModified = false;
            }
        }

        private void qryBgPosition_AfterPost(object sender, System.EventArgs e)
        {
            object bem = qryBgPosition["Bemerkung"];

            try
            {
                if (qryBgPosition.Row.RowState != DataRowState.Deleted)
                {
                    // KVG
                    SqlQuery qry = DBUtil.OpenSQL(@"
                    SELECT POS.*, POA.BgPositionsartCode
                    FROM BgPosition           POS
                    INNER JOIN BgPositionsart POA ON POA.BgPositionsartID = POS.BgPositionsartID
                    WHERE POS.BgBudgetID = {0}
                      AND POS.BgPositionID_Parent = {1}
                      AND POA.BgPositionsartCode IN (32023, 32024)"
                        //32023: KVB - GBL, 32024: KVG - Übernahme durch SD
                        , this.qryBgPosition["BgBudgetID"], this.qryBgPosition["BgPositionID"]);

                    InsertRow(qry);

                    //Migration BgPositionsart: Keine Änderung nötig
                    //qryBgPosition["BgPositionsartID_KVG"] wird in Abhängigkeit des Monats ermittelt
                    qry["BgPositionsartID"] = this.qryBgPosition["BgPositionsartID_KVG"];
                    qry["Betrag"] = (decimal)this.qryBgPosition["KVGBetrag"] - (decimal)this.qryBgPosition["Betrag"];
                    qry["Reduktion"] = (decimal)this.qryBgPosition["KVGReduktion"] - (decimal)this.qryBgPosition["Reduktion"];
                    qry["MaxBeitragSD"] = (int)qryBgPosition["BgPositionsartCode_KVG"] == (int)LOV.BgPositionsArt.KVG_Uebernahme_durch_SD ? (decimal)999999999 : (decimal)0;  //32024: KVG - Übernahme durch SD
                    qry["DatumVon"] = this.qryBgPosition["DatumVon"];
                    qry["DatumBis"] = this.qryBgPosition["DatumBis"];
                    qry["BaInstitutionID"] = this.qryBgPosition["BaInstitutionID"];

                    UpdateBuchungstext(qry);

                    if (!qry.Post("BgPosition"))
                    {
                        throw new KissErrorException(
                            KissMsg.GetMLMessage(
                                "CtlBgKrankenkasse", "KVGNichtGespeichert",
                                "KVG kann nicht gespeichert werden",
                                KissMsgCode.MsgError)
                            );
                    }

                    // VVG
                    qry.Fill(@"
                    SELECT POS.*, POA.BgPositionsartCode
                    FROM BgPosition           POS
                    INNER JOIN BgPositionsart POA on POA.BgPositionsartID = POS.BgPositionsartID
                    WHERE POS.BgBudgetID = {0}
                      AND POS.BgPositionID_Parent = {1}
                      AND POA.BgPositionsartCode IN (32021, 32022)"
                        //32021: VVG, 32022: VVG Prämie - SIL
                        , this.qryBgPosition["BgBudgetID"], this.qryBgPosition["BgPositionID"]);

                    InsertRow(qry);

                    //Migration BgPositionsart: Keine Änderung nötig
                    //qryBgPosition["BgPositionsartID_VVG"] wird in Abhängigkeit des Monats ermittelt
                    qry["BgPositionsartID"] = this.qryBgPosition["BgPositionsartID_VVG"];
                    qry["Betrag"] = this.qryBgPosition["VVGBetrag"];
                    qry["Reduktion"] = this.qryBgPosition["VVGReduktion"];
                    qry["MaxBeitragSD"] = this.qryBgPosition["VVGMaxBeitragSD"];
                    qry["DatumVon"] = this.qryBgPosition["DatumVon"];
                    qry["DatumBis"] = this.qryBgPosition["DatumBis"];
                    qry["BaInstitutionID"] = this.qryBgPosition["VVGBaInstitutionID"];

                    UpdateBuchungstext(qry);

                    if (!qry.Post("BgPosition"))
                    {
                        throw new KissErrorException(
                            KissMsg.GetMLMessage(
                                "CtlBgKrankenkasse", "VVGNichtGespeichert",
                                "VVG kann nicht gespeichert werden",
                                KissMsgCode.MsgError)
                            );
                    }

                    // Monatsbudget Beträge anpassen
                    if (this.bAnpassen)
                    {
                        DBUtil.ExecSQL(600, "EXECUTE spWhFinanzplan_Bewilligen {0}, {1}, {2}",
                            qryBgFinanzplan["BgFinanzplanID"], qryBgPosition["DatumVon"], qryBgPosition["BgPositionID"]);
                    }
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

            //Query Refresh, damit die durch die StoredProcedure veränderten Positionen auch korrekt dargestellt werden
            //Damit kein Endlos-Loop entsteht, müssen wir die aktuelle Zeile unmodified markieren
            qryBgPosition.RowModified = false;
            qryBgPosition.Refresh();
        }

        private void qryBgPosition_BeforePost(object sender, System.EventArgs e)
        {
            CheckNotNullFields();

            decimal kvgReduktion = Utils.ConvertToDecimal(qryBgPosition["KVGReduktion"]);
            decimal kvgBetrag = Utils.ConvertToDecimal(qryBgPosition["KVGMaxBeitrag"]);
            if (kvgReduktion > kvgBetrag)
            {
                throw new KissInfoException(KissMsg.GetMLMessage("CtlBgKrankenkasse", "KvgReduktionGroesserKvgMaxBetrag", "Der Betrag in KVG Reduktion darf nicht grösser sein als der KVG-max. Beitrag.", KissMsgCode.MsgInfo));
            }

            decimal vvgReduktion = Utils.ConvertToDecimal(qryBgPosition["VVGReduktion"]);
            decimal vvgBetrag = Utils.ConvertToDecimal(qryBgPosition["VVGBetrag"]);
            if (vvgReduktion > vvgBetrag)
            {
                throw new KissInfoException(KissMsg.GetMLMessage("CtlBgKrankenkasse", "VvgReduktionGroesserVvgBetrag", "Der Betrag in VVG Reduktion darf nicht grösser sein als VVG-Beitrag.", KissMsgCode.MsgInfo));
            }

            if ((int)this.qryBgPosition["BgPositionsartCode"] == (int)LOV.BgPositionsArt.KVG_Krankenkassenpraemien)
            {
                this.qryBgPosition["Betrag"] = this.qryBgPosition["KVGBetrag"];
                this.qryBgPosition["Reduktion"] = this.qryBgPosition["KVGReduktion"];
                this.qryBgPosition["MaxBeitragSD"] = this.qryBgPosition["KVGTotal"];
            }
            else
            {
                this.qryBgPosition["Betrag"] = Math.Min((decimal)this.qryBgPosition["KVGBetrag"], (decimal)this.qryBgPosition["KVGLimit"]);
                this.qryBgPosition["Reduktion"] = this.qryBgPosition["KVGReduktion"];
                this.qryBgPosition["MaxBeitragSD"] = Math.Min((decimal)this.qryBgPosition["KVGTotal"], (decimal)this.qryBgPosition["KVGLimit"]);
            }

            #region MaxBetrag

            DateTime refDate;
            if (this.bAnpassen)
                refDate = this.AnpassenVon;
            else if (!DBUtil.IsEmpty(this.qryBgPosition["DatumVon"]) && (DateTime)this.qryBgPosition["DatumVon"] > (DateTime)this.qryBgFinanzplan["FinanzplanVon"])
                refDate = (DateTime)this.qryBgPosition["DatumVon"];
            else
                refDate = (DateTime)this.qryBgFinanzplan["FinanzplanVon"];

            decimal MaxBetrag = (decimal)DBUtil.GetConfigValue(@"System\Sozialhilfe\SKOS\KVG_MaxPerPerson", (decimal)0, refDate, false);
            if ((decimal)this.qryBgPosition["KVGBetrag"] > MaxBetrag)
                throw new KissInfoException(KissMsg.GetMLMessage("CtlBgKrankenkasse", "KVGErhoehungNichtMoeglich", "Die KVG-Prämien können nicht über {0:n2} erhöht werden", KissMsgCode.MsgInfo, MaxBetrag));

            MaxBetrag = (decimal)DBUtil.GetConfigValue(@"System\Sozialhilfe\SKOS\VVG_MaxPerPerson", (decimal)0, refDate, false);
            if ((decimal)this.qryBgPosition["VVGBetrag"] > MaxBetrag)
                throw new KissInfoException(KissMsg.GetMLMessage("CtlBgKrankenkasse", "VVGErhoehungNichtMoeglich", "Die VVG-Prämien können nicht über {0:n2} erhöht werden", KissMsgCode.MsgInfo, MaxBetrag));

            #endregion

            //um die für diesen Finanzplan gültigen PositionsartIDs zu ermitteln, wird der Gültigkeits-Datumsbereich
            //benötigt.
            DateTime datumVon = bAnpassen ? AnpassenVon : finanzplanVon;

            if ((bool)this.qryBgPosition["KVGBeitragSD"])
            {
                this.qryBgPosition["BgPositionsartID_KVG"] = ShUtil.GetBgPositionsartID(LOV.BgPositionsArt.KVG_Uebernahme_durch_SD, datumVon); //32024
                this.qryBgPosition["BgPositionsartCode_KVG"] = LOV.BgPositionsArt.KVG_Uebernahme_durch_SD;
            }
            else
            {
                this.qryBgPosition["BgPositionsartID_KVG"] = ShUtil.GetBgPositionsartID(LOV.BgPositionsArt.KVG_GBL, datumVon); //32023
                this.qryBgPosition["BgPositionsartCode_KVG"] = LOV.BgPositionsArt.KVG_GBL;
            }

            if ((bool)this.qryBgPosition["VVGBeitragSD"])
            {
                this.qryBgPosition["BgPositionsartID_VVG"] = ShUtil.GetBgPositionsartID(LOV.BgPositionsArt.VVG_Praemie_SIL, datumVon); //32022
                this.qryBgPosition["BgPositionsartCode_VVG"] = LOV.BgPositionsArt.VVG_Praemie_SIL;
                this.qryBgPosition["VVGMaxbeitragSD"] = (decimal)999999999;
            }
            else
            {
                this.qryBgPosition["BgPositionsartID_VVG"] = ShUtil.GetBgPositionsartID(LOV.BgPositionsArt.VVG, datumVon); //32021
                this.qryBgPosition["BgPositionsartCode_VVG"] = LOV.BgPositionsArt.VVG;
                this.qryBgPosition["VVGMaxbeitragSD"] = (decimal)0;
            }

            if (Session.Transaction == null)
                Session.BeginTransaction();
        }

        private void qryBgPosition_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            CheckNotNullFields();

            switch (e.Column.ColumnName)
            {
                case "BgPositionsartID":
                    DataRowView dataRowView = (DataRowView)edtBgPositionsart.Properties.GetDataSourceRowByKeyValue(e.Row["BgPositionsartID"]);
                    if (dataRowView != null)
                    {
                        e.Row["BgPositionsartCode"] = dataRowView.Row["BgPositionsartCode"];
                        e.Row["KVGLimit"] = DBUtil.GetConfigValue(
                            string.Format(@"System\Sozialhilfe\Krankenkasse\{0}", dataRowView.Row["BgPositionsartCode"]),
                            decimal.Zero,
                            (DateTime)(bAnpassen ? AnpassenVon : qryBgFinanzplan["FinanzplanVon"]),
                            false);

                        e.Row["KVGReduktion"] = DBUtil.GetConfigValue(
                            string.Format(@"System\Sozialhilfe\Praemienverbilligung\{0}", dataRowView.Row["BgPositionsartCode"]),
                            decimal.Zero,
                            (DateTime)(bAnpassen ? AnpassenVon : qryBgFinanzplan["FinanzplanVon"]),
                            false);
                    }
                    break;

                case "KVGBetrag":
                case "KVGReduktion":
                case "KVGBeitragSD":
                case "KVGLimit":
                    if ((int)e.Row["BgPositionsartCode"] == 32020)
                    {
                        e.Row["KVGMaxBeitrag"] = (decimal)e.Row["KVGBetrag"];
                        e.Row["KVGBeitragDiff"] = decimal.Zero;
                    }
                    else
                    {
                        e.Row["KVGMaxBeitrag"] = Math.Min((decimal)e.Row["KVGBetrag"], (decimal)e.Row["KVGLimit"]);
                        e.Row["KVGBeitragDiff"] = (decimal)e.Row["KVGBetrag"] - (decimal)e.Row["KVGMaxBeitrag"];
                    }
                    e.Row["KVGUnterstuetzt"] = (decimal)e.Row["KVGMaxBeitrag"] - (decimal)e.Row["KVGReduktion"];
                    e.Row["KVGUnterstuetztDiff"] = (bool)e.Row["KVGBeitragSD"] ? e.Row["KVGBeitragDiff"] : decimal.Zero;
                    e.Row["KVGTotal"] = (decimal)e.Row["KVGBetrag"] - (decimal)e.Row["KVGReduktion"];

                    if (e.Column.ColumnName.Equals("KVGBetrag")) // wird der KVGBetrag angepasst, soll zusätzlich auch noch die Prämienverbilligung automatisch angepasst werden
                    {
                        DataRowView dataRow = (DataRowView)edtBgPositionsart.Properties.GetDataSourceRowByKeyValue(e.Row["BgPositionsartID"]);
                        e.Row["KVGReduktion"] = DBUtil.GetConfigValue(
                            string.Format(@"System\Sozialhilfe\Praemienverbilligung\{0}", dataRow.Row["BgPositionsartCode"]),
                            decimal.Zero,
                            (DateTime)(bAnpassen ? AnpassenVon : qryBgFinanzplan["FinanzplanVon"]),
                            false);
                    }
                    break;

                case "VVGBetrag":
                case "VVGReduktion":
                case "VVGBeitragSD":
                    e.Row["VVGTotal"] = (decimal)e.Row["VVGBetrag"] - (decimal)e.Row["VVGReduktion"];
                    e.Row["VVGUnterstuetzt"] = (bool)e.Row["VVGBeitragSD"] ? e.Row["VVGTotal"] : decimal.Zero;
                    break;

                case "KVGUnterstuetzt":
                case "KVGUnterstuetztDiff":
                case "VVGUnterstuetzt":
                    e.Row["TotalUnterstuetzt"] = (decimal)e.Row["KVGUnterstuetzt"] + (decimal)e.Row["KVGUnterstuetztDiff"]
                        + (decimal)e.Row["VVGUnterstuetzt"];
                    break;

                case "KVGTotal":
                case "VVGTotal":
                    e.Row["Total"] = (decimal)e.Row["KVGTotal"] + (decimal)e.Row["VVGTotal"];
                    break;

                default:
                    return;
            }

            qryBgPosition.RefreshDisplay();
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// 8096
        /// </summary>
        /// <returns></returns>
        public override bool OnSaveData()
        {
            //UpdateKVGLimit();
            return kissDataNavigator.SaveData();
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// Get SQL statement for searching institution data of specific type Krankenkasse
        /// </summary>
        /// <param name="searchString">Search value for Name/Vorname of institution</param>
        /// <returns>The SQL statement to execute for searching institutions</returns>
        private static string GetKKInstitutionSearchSQL(string searchString)
        {
            return string.Format(@"
                SELECT ID$         = INS.BaInstitutionID,
                       Institution = INS.NameVorname,
                       Adresse     = INS.Adresse,
                       Typen       = dbo.fnBaGetBaInstitutionTypen(INS.BaInstitutionID, 0, '; ', {1}, {3})
                FROM dbo.vwInstitution INS WITH (READUNCOMMITTED)
                WHERE INS.NameVorname LIKE '%' + {0} + '%'
                  AND (',' + dbo.fnBaGetBaInstitutionTypen(INS.BaInstitutionID, 1, ',', {1}, 1) + ',' LIKE '%,{2},%')
                ORDER BY INS.NameVorname", DBUtil.SqlLiteral(searchString), Session.User.UserID, BAINSTITUTIONTYPID_KK, Session.User.LanguageCode);
        }

        private static void UpdateBuchungstext(SqlQuery qry)
        {
            if (DBUtil.IsEmpty(qry["Buchungstext"]) || qry.ColumnModified("BgPositionsartID") || qry.ColumnModified("BgPositionsartCode"))
            {
                //Migration BgPositionsart: Keine Änderung nötig
                qry["Buchungstext"] = DBUtil.ExecuteScalarSQL(
                    "SELECT Name FROM BgPositionsart WHERE BgPositionsartID = {0}",
                    qry["BgPositionsartID"]);
            }
        }

        #endregion

        #region Private Methods

        private void CheckNotNullFields()
        {
            DBUtil.CheckNotNullField(this.edtBgPositionsart, lblMaxBetrag.Text);

            DBUtil.CheckNotNullField(this.edtKVGBetrag, KissMsg.GetMLMessage("CtlBgKrankenkasse", "KVGBeitragEffektiv", "KVG-Beitrag effektiv"));
            DBUtil.CheckNotNullField(this.edtKVGReduktion, KissMsg.GetMLMessage("CtlBgKrankenkasse", "KVGBeitragReduktion", "KVG-Beitrag Reduktion"));
            DBUtil.CheckNotNullField(this.edtVVGBetrag, KissMsg.GetMLMessage("CtlBgKrankenkasse", "VVGBeitragEffektiv", "VVG-Beitrag effektiv"));
            DBUtil.CheckNotNullField(this.edtVVGReduktion, KissMsg.GetMLMessage("CtlBgKrankenkasse", "VVGBeitragReduktion", "VVG-Beitrag Reduktion"));
        }

        private void InsertRow(SqlQuery qry)
        {
            if (qry.IsEmpty)
            {
                qry.Insert("BgPosition");

                qry["BgBudgetID"] = this.qryBgPosition["BgBudgetID"];
                qry["BgPositionID_Parent"] = this.qryBgPosition["BgPositionID"];
                qry["BgKategorieCode"] = 2;

                qry["BaPersonID"] = this.qryBgPosition["BaPersonID"];
            }
        }

        #endregion

        #endregion
    }
}