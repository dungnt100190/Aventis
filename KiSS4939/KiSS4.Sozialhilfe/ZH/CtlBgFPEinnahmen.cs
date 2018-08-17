using System;
using System.Data;
using System.Drawing;
using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Sozialhilfe.ZH
{
    public class CtlBgFPEinnahmen : KiSS4.Gui.KissUserControl
    {
        #region Fields

        private int BgBudgetID;
        private int BgGruppeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colBaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag2;
        private DevExpress.XtraGrid.Columns.GridColumn colBgPositionsartID;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungstext;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumBis;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colF;
        private DevExpress.XtraGrid.Columns.GridColumn colJahr;
        private DevExpress.XtraGrid.Columns.GridColumn colKOA;
        private DevExpress.XtraGrid.Columns.GridColumn colKOA2;
        private DevExpress.XtraGrid.Columns.GridColumn colMonat;
        private DevExpress.XtraGrid.Columns.GridColumn colPersNr;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus2;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissMemoEdit edtAdresse;
        private KiSS4.Gui.KissLookUpEdit edtBaPersonID;
        private KiSS4.Gui.KissMemoEdit edtBemerkung;
        private KiSS4.Gui.KissCalcEdit edtBetrag;
        private KiSS4.Gui.KissTextEdit edtBuchungstext;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissButtonEdit edtInstitution;
        private KiSS4.Gui.KissButtonEdit edtKostenart;
        private KiSS4.Gui.KissCheckEdit edtVerwaltungSD;
        private KiSS4.Gui.KissGrid grdBgPosition;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBgPosition;
        private KiSS4.Gui.KissGrid kissGrid1;
        private KiSS4.Gui.KissTabControlEx kissTabControlEx1;
        private KiSS4.Gui.KissLabel lblBaPersonID;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblBetrag;
        private KiSS4.Gui.KissLabel lblBis;
        private KiSS4.Gui.KissLabel lblBuchungstext;
        private KiSS4.Gui.KissLabel lblDatumVon;
        private KiSS4.Gui.KissLabel lblInstitution;
        private KiSS4.Gui.KissLabel lblKostenart;
        private KiSS4.Gui.KissLabel lblTitel;
        private System.Windows.Forms.PictureBox picTitle;
        private SqlQuery qryBgFinanzplan;
        private KiSS4.DB.SqlQuery qryBgPosition;
        private KiSS4.DB.SqlQuery qryMonatsbudget;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2;
        private SharpLibrary.WinControls.TabPageEx tpgMonatsbudget;
        private SharpLibrary.WinControls.TabPageEx tpgPosition;

        #endregion Fields

        #region Constructors

        public CtlBgFPEinnahmen(Image titelImage, string titelText, int bgBudgetID, int bgGruppeCode)
            : this()
        {
            this.picTitle.Image = titelImage;
            this.BgBudgetID = bgBudgetID;
            this.BgGruppeCode = bgGruppeCode;

            qryBgFinanzplan = DBUtil.OpenSQL(@"
                SELECT FLE.FaFallID, FLE.FaLeistungID, SFP.BgFinanzplanID,
                  LeiDatumBis   = FLE.DatumBis,
                  FPStatus      = SFP.BgBewilligungStatusCode,
                  FinanzplanVon = IsNull(SFP.DatumVon, SFP.GeplantVon),
                  FinanzplanBis = IsNull(SFP.DatumBis, SFP.GeplantBis),
                  AnpassenVon   = IsNull((SELECT MAX(DATEADD(m, 1, dbo.fnDateSerial(Jahr, Monat, 1))) FROM BgBudget
                                          WHERE BgFinanzplanID = SFP.BgFinanzplanID AND MasterBudget = 0
                                            AND BgBewilligungStatusCode >= 5), SFP.GeplantVon),
                  AnpassenBis   = SFP.DatumBis
                FROM BgBudget             BBG
                  INNER JOIN BgFinanzplan SFP ON SFP.BgFinanzplanID = BBG.BgFinanzplanID
                  INNER JOIN FaLeistung   FLE ON FLE.FaLeistungID = SFP.FaLeistungID
                WHERE BBG.BgBudgetID = {0}"
                , bgBudgetID);

            this.lblTitel.Text = string.Format(this.lblTitel.Text, qryBgFinanzplan["FinanzplanVon"], qryBgFinanzplan["FinanzplanBis"], titelText);

            ShUtil.GetPersonen_Unterstuetzt(BgBudgetID);

            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT PRS.BaPersonID, PRS.NameVorname, PRS.Name, PRS.Vorname, LT = CASE WHEN LST.BaPersonID = PRS.BaPersonID THEN 0 ELSE 1 END,
                       Person = PRS.NameVorname + ' (' + isNull(convert(varchar,PRS.AlterMortal),'-') + isNull(',' + GES.ShortText,'') + ')'
                FROM BgBudget                       BBG
                  INNER JOIN BgFinanzplan           SFP ON SFP.BgFinanzplanID = BBG.BgFinanzplanID
                  INNER JOIN FaLeistung             LST ON LST.FaLeistungID   = SFP.FaLeistungID
                  INNER JOIN BgFinanzplan_BaPerson  SPP ON SPP.BgFinanzplanID = BBG.BgFinanzplanID
                  INNER JOIN vwPerson               PRS ON PRS.BaPersonID     = SPP.BaPersonID
                  LEFT  JOIN XLOVCode               GES ON GES.LOVName = 'BaGeschlecht' AND GES.Code = PRS.GeschlechtCode
                WHERE BBG.BgBudgetID = {0} AND SPP.IstUnterstuetzt = 1
                UNION ALL SELECT NULL, '', '', '', 0, ''
                ORDER BY LT, PRS.Name, PRS.Vorname"
                , BgBudgetID);

            this.colBaPersonID.ColumnEdit = this.grdBgPosition.GetLOVLookUpEdit(qry, "BaPersonID", "Person");
            this.edtBaPersonID.LoadQuery(qry, "BaPersonID", "Person");

            //Bewilligungsstati laden
            repositoryItemImageComboBox1.SmallImages = KissImageList.SmallImageList;
            SqlQuery qryStati = DBUtil.OpenSQL("select * from XLOVCode where LOVName = 'BgBewilligungStatus' order by SortKey");
            foreach (DataRow R in qryStati.DataTable.Rows)
            {
                repositoryItemImageComboBox1.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(
                    R["Text"].ToString(),
                    (int)R["Code"],
                    KissImageList.GetImageIndex(Convert.ToInt32(R["Value1"]))));
            }

            //Buchungsstati laden
            repositoryItemImageComboBox2.SmallImages = KissImageList.SmallImageList;
            qryStati = DBUtil.OpenSQL("select * from XLOVCode where LOVName = 'KbBuchungsStatus' order by SortKey");
            foreach (DataRow R in qryStati.DataTable.Rows)
            {
                repositoryItemImageComboBox2.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(
                    R["Text"].ToString(),
                    (int)R["Code"],
                    KissImageList.GetImageIndex(Convert.ToInt32(R["Value1"]))));
            }

            this.qryBgPosition.PostCompleted += new System.EventHandler(this.qryBgPosition_PostCompleted);

            this.qryBgPosition.Fill(BgBudgetID, BgGruppeCode);
        }

        public CtlBgFPEinnahmen()
        {
            this.InitializeComponent();
        }

        #endregion Constructors

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBgFPEinnahmen));
            this.grdBgPosition = new KiSS4.Gui.KissGrid();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.picTitle = new System.Windows.Forms.PictureBox();
            this.kissTabControlEx1 = new KiSS4.Gui.KissTabControlEx();
            this.tpgPosition = new SharpLibrary.WinControls.TabPageEx();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtKostenart = new KiSS4.Gui.KissButtonEdit();
            this.edtBuchungstext = new KiSS4.Gui.KissTextEdit();
            this.lblBetrag = new KiSS4.Gui.KissLabel();
            this.edtBaPersonID = new KiSS4.Gui.KissLookUpEdit();
            this.edtBetrag = new KiSS4.Gui.KissCalcEdit();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.edtInstitution = new KiSS4.Gui.KissButtonEdit();
            this.edtVerwaltungSD = new KiSS4.Gui.KissCheckEdit();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.lblBaPersonID = new KiSS4.Gui.KissLabel();
            this.lblDatumVon = new KiSS4.Gui.KissLabel();
            this.lblBis = new KiSS4.Gui.KissLabel();
            this.lblKostenart = new KiSS4.Gui.KissLabel();
            this.lblBuchungstext = new KiSS4.Gui.KissLabel();
            this.lblInstitution = new KiSS4.Gui.KissLabel();
            this.edtAdresse = new KiSS4.Gui.KissMemoEdit();
            this.tpgMonatsbudget = new SharpLibrary.WinControls.TabPageEx();
            this.kissGrid1 = new KiSS4.Gui.KissGrid();
            this.colBaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBgPositionsartID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungstext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJahr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKOA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKOA2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grvBgPosition = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.qryBgPosition = new KiSS4.DB.SqlQuery(this.components);
            this.qryMonatsbudget = new KiSS4.DB.SqlQuery(this.components);
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            this.kissTabControlEx1.SuspendLayout();
            this.tpgPosition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungstext.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInstitution.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwaltungSD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungstext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInstitution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresse.Properties)).BeginInit();
            this.tpgMonatsbudget.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryMonatsbudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).BeginInit();
            this.SuspendLayout();
            //
            // grdBgPosition
            //
            this.grdBgPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdBgPosition.DataSource = this.qryBgPosition;
            this.grdBgPosition.EmbeddedNavigator.Name = "";
            this.grdBgPosition.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBgPosition.Location = new System.Drawing.Point(5, 37);
            this.grdBgPosition.MainView = this.grvBgPosition;
            this.grdBgPosition.Name = "grdBgPosition";
            this.grdBgPosition.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
                        this.repositoryItemImageComboBox1});
            this.grdBgPosition.Size = new System.Drawing.Size(721, 361);
            this.grdBgPosition.TabIndex = 0;
            this.grdBgPosition.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                        this.grvBgPosition});
            //
            // lblTitel
            //
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(32, 8);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(648, 16);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "{2} vom {0:d} bis {1:d}";
            this.lblTitel.UseCompatibleTextRendering = true;
            //
            // picTitle
            //
            this.picTitle.Location = new System.Drawing.Point(8, 8);
            this.picTitle.Name = "picTitle";
            this.picTitle.Size = new System.Drawing.Size(16, 16);
            this.picTitle.TabIndex = 55;
            this.picTitle.TabStop = false;
            //
            // kissTabControlEx1
            //
            this.kissTabControlEx1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.kissTabControlEx1.Controls.Add(this.tpgMonatsbudget);
            this.kissTabControlEx1.Controls.Add(this.tpgPosition);
            this.kissTabControlEx1.Location = new System.Drawing.Point(5, 404);
            this.kissTabControlEx1.Name = "kissTabControlEx1";
            this.kissTabControlEx1.ShowFixedWidthTooltip = true;
            this.kissTabControlEx1.Size = new System.Drawing.Size(723, 243);
            this.kissTabControlEx1.TabIndex = 71;
            this.kissTabControlEx1.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
                        this.tpgPosition,
                        this.tpgMonatsbudget});
            this.kissTabControlEx1.TabsLineColor = System.Drawing.Color.Black;
            this.kissTabControlEx1.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.kissTabControlEx1.Text = "kissTabControlEx1";
            //
            // tpgPosition
            //
            this.tpgPosition.Controls.Add(this.edtAdresse);
            this.tpgPosition.Controls.Add(this.lblInstitution);
            this.tpgPosition.Controls.Add(this.lblBuchungstext);
            this.tpgPosition.Controls.Add(this.lblKostenart);
            this.tpgPosition.Controls.Add(this.lblBis);
            this.tpgPosition.Controls.Add(this.lblDatumVon);
            this.tpgPosition.Controls.Add(this.lblBaPersonID);
            this.tpgPosition.Controls.Add(this.lblBemerkung);
            this.tpgPosition.Controls.Add(this.edtVerwaltungSD);
            this.tpgPosition.Controls.Add(this.edtInstitution);
            this.tpgPosition.Controls.Add(this.edtBemerkung);
            this.tpgPosition.Controls.Add(this.edtBetrag);
            this.tpgPosition.Controls.Add(this.edtBaPersonID);
            this.tpgPosition.Controls.Add(this.lblBetrag);
            this.tpgPosition.Controls.Add(this.edtBuchungstext);
            this.tpgPosition.Controls.Add(this.edtKostenart);
            this.tpgPosition.Controls.Add(this.edtDatumBis);
            this.tpgPosition.Controls.Add(this.edtDatumVon);
            this.tpgPosition.Location = new System.Drawing.Point(6, 6);
            this.tpgPosition.Name = "tpgPosition";
            this.tpgPosition.Size = new System.Drawing.Size(711, 205);
            this.tpgPosition.TabIndex = 0;
            this.tpgPosition.Title = "Position";
            //
            // edtDatumVon
            //
            this.edtDatumVon.DataMember = "DatumVon";
            this.edtDatumVon.DataSource = this.qryBgPosition;
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(91, 5);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(90, 24);
            this.edtDatumVon.TabIndex = 1;
            //
            // edtDatumBis
            //
            this.edtDatumBis.DataMember = "DatumBis";
            this.edtDatumBis.DataSource = this.qryBgPosition;
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(212, 5);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(90, 24);
            this.edtDatumBis.TabIndex = 2;
            //
            // edtKostenart
            //
            this.edtKostenart.DataMember = "Kostenart";
            this.edtKostenart.DataSource = this.qryBgPosition;
            this.edtKostenart.Location = new System.Drawing.Point(91, 35);
            this.edtKostenart.Name = "edtKostenart";
            this.edtKostenart.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKostenart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKostenart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKostenart.Properties.Appearance.Options.UseBackColor = true;
            this.edtKostenart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKostenart.Properties.Appearance.Options.UseFont = true;
            this.edtKostenart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtKostenart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtKostenart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKostenart.Size = new System.Drawing.Size(304, 24);
            this.edtKostenart.TabIndex = 3;
            this.edtKostenart.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtKostenart_UserModifiedFld);
            //
            // edtBuchungstext
            //
            this.edtBuchungstext.DataMember = "Buchungstext";
            this.edtBuchungstext.DataSource = this.qryBgPosition;
            this.edtBuchungstext.Location = new System.Drawing.Point(91, 57);
            this.edtBuchungstext.Name = "edtBuchungstext";
            this.edtBuchungstext.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBuchungstext.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBuchungstext.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchungstext.Properties.Appearance.Options.UseBackColor = true;
            this.edtBuchungstext.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBuchungstext.Properties.Appearance.Options.UseFont = true;
            this.edtBuchungstext.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBuchungstext.Size = new System.Drawing.Size(304, 24);
            this.edtBuchungstext.TabIndex = 4;
            //
            // lblBetrag
            //
            this.lblBetrag.Location = new System.Drawing.Point(5, 118);
            this.lblBetrag.Name = "lblBetrag";
            this.lblBetrag.Size = new System.Drawing.Size(85, 24);
            this.lblBetrag.TabIndex = 4;
            this.lblBetrag.Text = "mtl. Betrag";
            this.lblBetrag.UseCompatibleTextRendering = true;
            //
            // edtBaPersonID
            //
            this.edtBaPersonID.DataMember = "BaPersonID";
            this.edtBaPersonID.DataSource = this.qryBgPosition;
            this.edtBaPersonID.Location = new System.Drawing.Point(91, 87);
            this.edtBaPersonID.Name = "edtBaPersonID";
            this.edtBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBaPersonID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtBaPersonID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaPersonID.Properties.NullText = "";
            this.edtBaPersonID.Properties.ShowFooter = false;
            this.edtBaPersonID.Properties.ShowHeader = false;
            this.edtBaPersonID.Size = new System.Drawing.Size(304, 24);
            this.edtBaPersonID.TabIndex = 5;
            //
            // edtBetrag
            //
            this.edtBetrag.DataMember = "Betrag";
            this.edtBetrag.DataSource = this.qryBgPosition;
            this.edtBetrag.Location = new System.Drawing.Point(91, 118);
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
            // edtBemerkung
            //
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryBgPosition;
            this.edtBemerkung.Location = new System.Drawing.Point(91, 148);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Properties.MaxLength = 200;
            this.edtBemerkung.Size = new System.Drawing.Size(304, 50);
            this.edtBemerkung.TabIndex = 7;
            //
            // edtInstitution
            //
            this.edtInstitution.DataMember = "Institution";
            this.edtInstitution.DataSource = this.qryBgPosition;
            this.edtInstitution.Location = new System.Drawing.Point(418, 35);
            this.edtInstitution.Name = "edtInstitution";
            this.edtInstitution.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtInstitution.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtInstitution.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtInstitution.Properties.Appearance.Options.UseBackColor = true;
            this.edtInstitution.Properties.Appearance.Options.UseBorderColor = true;
            this.edtInstitution.Properties.Appearance.Options.UseFont = true;
            this.edtInstitution.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtInstitution.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtInstitution.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtInstitution.Size = new System.Drawing.Size(272, 24);
            this.edtInstitution.TabIndex = 8;
            this.edtInstitution.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtInstitution_UserModifiedFld);
            //
            // edtVerwaltungSD
            //
            this.edtVerwaltungSD.DataMember = "VerwaltungSD";
            this.edtVerwaltungSD.DataSource = this.qryBgPosition;
            this.edtVerwaltungSD.Location = new System.Drawing.Point(415, 138);
            this.edtVerwaltungSD.Name = "edtVerwaltungSD";
            this.edtVerwaltungSD.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtVerwaltungSD.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerwaltungSD.Properties.Caption = "Ermächtigung - Einnahmen an SoD ";
            this.edtVerwaltungSD.Size = new System.Drawing.Size(272, 19);
            this.edtVerwaltungSD.TabIndex = 9;
            //
            // lblBemerkung
            //
            this.lblBemerkung.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblBemerkung.Location = new System.Drawing.Point(5, 148);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(85, 17);
            this.lblBemerkung.TabIndex = 12;
            this.lblBemerkung.Text = "Beschreibung";
            this.lblBemerkung.UseCompatibleTextRendering = true;
            //
            // lblBaPersonID
            //
            this.lblBaPersonID.Location = new System.Drawing.Point(5, 87);
            this.lblBaPersonID.Name = "lblBaPersonID";
            this.lblBaPersonID.Size = new System.Drawing.Size(85, 24);
            this.lblBaPersonID.TabIndex = 57;
            this.lblBaPersonID.Text = "Person";
            this.lblBaPersonID.UseCompatibleTextRendering = true;
            //
            // lblDatumVon
            //
            this.lblDatumVon.Location = new System.Drawing.Point(5, 5);
            this.lblDatumVon.Name = "lblDatumVon";
            this.lblDatumVon.Size = new System.Drawing.Size(85, 24);
            this.lblDatumVon.TabIndex = 58;
            this.lblDatumVon.Text = "gültig von";
            this.lblDatumVon.UseCompatibleTextRendering = true;
            //
            // lblBis
            //
            this.lblBis.Location = new System.Drawing.Point(188, 5);
            this.lblBis.Name = "lblBis";
            this.lblBis.Size = new System.Drawing.Size(18, 24);
            this.lblBis.TabIndex = 60;
            this.lblBis.Text = "bis";
            this.lblBis.UseCompatibleTextRendering = true;
            //
            // lblKostenart
            //
            this.lblKostenart.Location = new System.Drawing.Point(5, 35);
            this.lblKostenart.Name = "lblKostenart";
            this.lblKostenart.Size = new System.Drawing.Size(85, 24);
            this.lblKostenart.TabIndex = 63;
            this.lblKostenart.Text = "LA/Positionsart";
            this.lblKostenart.UseCompatibleTextRendering = true;
            //
            // lblBuchungstext
            //
            this.lblBuchungstext.Location = new System.Drawing.Point(5, 57);
            this.lblBuchungstext.Name = "lblBuchungstext";
            this.lblBuchungstext.Size = new System.Drawing.Size(85, 24);
            this.lblBuchungstext.TabIndex = 64;
            this.lblBuchungstext.Text = "Buchungstext";
            this.lblBuchungstext.UseCompatibleTextRendering = true;
            //
            // lblInstitution
            //
            this.lblInstitution.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblInstitution.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblInstitution.Location = new System.Drawing.Point(418, 17);
            this.lblInstitution.Name = "lblInstitution";
            this.lblInstitution.Size = new System.Drawing.Size(64, 16);
            this.lblInstitution.TabIndex = 67;
            this.lblInstitution.Text = "Institution";
            this.lblInstitution.UseCompatibleTextRendering = true;
            //
            // edtAdresse
            //
            this.edtAdresse.DataMember = "Adresse";
            this.edtAdresse.DataSource = this.qryBgPosition;
            this.edtAdresse.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAdresse.Location = new System.Drawing.Point(418, 58);
            this.edtAdresse.Name = "edtAdresse";
            this.edtAdresse.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAdresse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdresse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdresse.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdresse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdresse.Properties.Appearance.Options.UseFont = true;
            this.edtAdresse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAdresse.Properties.ReadOnly = true;
            this.edtAdresse.Size = new System.Drawing.Size(272, 72);
            this.edtAdresse.TabIndex = 68;
            //
            // tpgMonatsbudget
            //
            this.tpgMonatsbudget.Controls.Add(this.kissGrid1);
            this.tpgMonatsbudget.Location = new System.Drawing.Point(6, 6);
            this.tpgMonatsbudget.Name = "tpgMonatsbudget";
            this.tpgMonatsbudget.Size = new System.Drawing.Size(711, 205);
            this.tpgMonatsbudget.TabIndex = 1;
            this.tpgMonatsbudget.Title = "Verwendung Monatsbudgets";
            //
            // kissGrid1
            //
            this.kissGrid1.DataSource = this.qryMonatsbudget;
            this.kissGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kissGrid1.EmbeddedNavigator.Name = "";
            this.kissGrid1.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.kissGrid1.Location = new System.Drawing.Point(0, 0);
            this.kissGrid1.MainView = this.gridView1;
            this.kissGrid1.Name = "kissGrid1";
            this.kissGrid1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
                        this.repositoryItemImageComboBox2});
            this.kissGrid1.Size = new System.Drawing.Size(711, 205);
            this.kissGrid1.TabIndex = 0;
            this.kissGrid1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                        this.gridView1});
            //
            // colBaPersonID
            //
            this.colBaPersonID.Caption = "Person";
            this.colBaPersonID.FieldName = "BaPersonID";
            this.colBaPersonID.Name = "colBaPersonID";
            this.colBaPersonID.Visible = true;
            this.colBaPersonID.VisibleIndex = 4;
            this.colBaPersonID.Width = 149;
            //
            // colBetrag
            //
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.DisplayFormat.FormatString = "n2";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.FieldName = "Betrag";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 6;
            //
            // colBetrag2
            //
            this.colBetrag2.Caption = "Betrag";
            this.colBetrag2.DisplayFormat.FormatString = "N2";
            this.colBetrag2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag2.FieldName = "Betrag";
            this.colBetrag2.Name = "colBetrag2";
            this.colBetrag2.Visible = true;
            this.colBetrag2.VisibleIndex = 6;
            //
            // colBgPositionsartID
            //
            this.colBgPositionsartID.Caption = "Buchungstext";
            this.colBgPositionsartID.FieldName = "Buchungstext";
            this.colBgPositionsartID.Name = "colBgPositionsartID";
            this.colBgPositionsartID.Visible = true;
            this.colBgPositionsartID.VisibleIndex = 3;
            this.colBgPositionsartID.Width = 145;
            //
            // colBuchungstext
            //
            this.colBuchungstext.Caption = "Buchungstext";
            this.colBuchungstext.FieldName = "Buchungstext";
            this.colBuchungstext.Name = "colBuchungstext";
            this.colBuchungstext.Visible = true;
            this.colBuchungstext.VisibleIndex = 4;
            this.colBuchungstext.Width = 167;
            //
            // colDatumBis
            //
            this.colDatumBis.Caption = "bis";
            this.colDatumBis.FieldName = "DatumBis";
            this.colDatumBis.Name = "colDatumBis";
            this.colDatumBis.Visible = true;
            this.colDatumBis.VisibleIndex = 1;
            //
            // colDatumVon
            //
            this.colDatumVon.Caption = "gültig von";
            this.colDatumVon.FieldName = "DatumVon";
            this.colDatumVon.Name = "colDatumVon";
            this.colDatumVon.Visible = true;
            this.colDatumVon.VisibleIndex = 0;
            //
            // colF
            //
            this.colF.Caption = "LE";
            this.colF.FieldName = "F";
            this.colF.Name = "colF";
            this.colF.Visible = true;
            this.colF.VisibleIndex = 7;
            this.colF.Width = 25;
            //
            // colJahr
            //
            this.colJahr.Caption = "Jahr";
            this.colJahr.FieldName = "Jahr";
            this.colJahr.Name = "colJahr";
            this.colJahr.Visible = true;
            this.colJahr.VisibleIndex = 1;
            this.colJahr.Width = 45;
            //
            // colKOA
            //
            this.colKOA.Caption = "LA";
            this.colKOA.FieldName = "KOA";
            this.colKOA.Name = "colKOA";
            this.colKOA.Visible = true;
            this.colKOA.VisibleIndex = 2;
            this.colKOA.Width = 34;
            //
            // colKOA2
            //
            this.colKOA2.Caption = "LA";
            this.colKOA2.FieldName = "KOA";
            this.colKOA2.Name = "colKOA2";
            this.colKOA2.Visible = true;
            this.colKOA2.VisibleIndex = 3;
            this.colKOA2.Width = 37;
            //
            // colMonat
            //
            this.colMonat.Caption = "Monat";
            this.colMonat.FieldName = "Monat";
            this.colMonat.Name = "colMonat";
            this.colMonat.Visible = true;
            this.colMonat.VisibleIndex = 2;
            //
            // colPersNr
            //
            this.colPersNr.Caption = "Pers.-Nr.";
            this.colPersNr.FieldName = "BaPersonID";
            this.colPersNr.Name = "colPersNr";
            this.colPersNr.Visible = true;
            this.colPersNr.VisibleIndex = 5;
            this.colPersNr.Width = 60;
            //
            // colPerson
            //
            this.colPerson.Caption = "Person";
            this.colPerson.FieldName = "Person";
            this.colPerson.Name = "colPerson";
            this.colPerson.Visible = true;
            this.colPerson.VisibleIndex = 5;
            this.colPerson.Width = 163;
            //
            // colStatus2
            //
            this.colStatus2.Caption = "Stat";
            this.colStatus2.ColumnEdit = this.repositoryItemImageComboBox2;
            this.colStatus2.FieldName = "Status";
            this.colStatus2.Name = "colStatus2";
            this.colStatus2.Visible = true;
            this.colStatus2.VisibleIndex = 0;
            this.colStatus2.Width = 35;
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
            this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
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
                        this.colStatus2,
                        this.colJahr,
                        this.colMonat,
                        this.colKOA2,
                        this.colBuchungstext,
                        this.colPerson,
                        this.colBetrag2});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.kissGrid1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.UseTabKey = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
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
                        this.colDatumBis,
                        this.colKOA,
                        this.colBgPositionsartID,
                        this.colBaPersonID,
                        this.colPersNr,
                        this.colBetrag,
                        this.colF});
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
            // qryBgPosition
            //
            this.qryBgPosition.CanDelete = true;
            this.qryBgPosition.CanInsert = true;
            this.qryBgPosition.CanUpdate = true;
            this.qryBgPosition.HostControl = this;
            this.qryBgPosition.SelectStatement = resources.GetString("qryBgPosition.SelectStatement");
            this.qryBgPosition.TableName = "BgPosition";
            this.qryBgPosition.PositionChanged += new System.EventHandler(this.qryBgPosition_PositionChanged);
            this.qryBgPosition.BeforeDeleteQuestion += new System.EventHandler(this.qryBgPosition_BeforeDeleteQuestion);
            this.qryBgPosition.BeforePost += new System.EventHandler(this.qryBgPosition_BeforePost);
            this.qryBgPosition.AfterInsert += new System.EventHandler(this.qryBgPosition_AfterInsert);
            //
            // qryMonatsbudget
            //
            this.qryMonatsbudget.CanDelete = true;
            this.qryMonatsbudget.CanInsert = true;
            this.qryMonatsbudget.CanUpdate = true;
            this.qryMonatsbudget.HostControl = this;
            this.qryMonatsbudget.SelectStatement = resources.GetString("qryMonatsbudget.SelectStatement");
            //
            // repositoryItemImageComboBox1
            //
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            //
            // repositoryItemImageComboBox2
            //
            this.repositoryItemImageComboBox2.AutoHeight = false;
            this.repositoryItemImageComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox2.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
            //
            // CtlBgFPEinnahmen
            //
            this.ActiveSQLQuery = this.qryBgPosition;
            this.Controls.Add(this.kissTabControlEx1);
            this.Controls.Add(this.picTitle);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.grdBgPosition);
            this.Name = "CtlBgFPEinnahmen";
            this.Size = new System.Drawing.Size(736, 649);
            ((System.ComponentModel.ISupportInitialize)(this.grdBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            this.kissTabControlEx1.ResumeLayout(false);
            this.tpgPosition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungstext.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInstitution.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwaltungSD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungstext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInstitution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresse.Properties)).EndInit();
            this.tpgMonatsbudget.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kissGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryMonatsbudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion Windows Form Designer generated code

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

        #endregion Dispose

        #region Private Methods

        private bool AuswahlInstitutionFAMOZ(string SearchString, bool ButtonClicked)
        {
            bool Cancel = false;
            SearchString = SearchString.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
                if (ButtonClicked)
                {
                    SearchString = "%";
                }
                else
                {
                    qryBgPosition["BaInstitutionID"] = DBNull.Value;
                    qryBgPosition["Institution"] = DBNull.Value;
                    qryBgPosition["Adresse"] = DBNull.Value;
                    return Cancel;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();

            switch (SearchString)
            {
                case "":
                    break;

                case ".":
                    // Institution aus
                    // Involvierte Stellen  - FaInvolvierteInstitution
                    // Krankenkasse         - BaKrankenversicherung
                    // Vermieter            - BaWohnsituation
                    // Arbeitgeber          - BaArbeit

                    Cancel = !dlg.SearchData(@"
                        -- InvolvierteStelle
                        SELECT  Art              = 'involvierte Stelle',
                                Name             = INS.Name,
                                Adresse          = INS.Adresse,
                                Typ              = INS.Typ,
                                BaInstitutionID$ = INS.BaInstitutionID,
                                BaPersonID$      = null,
                                Adresse$         = INS.AdresseMehrzeilig,
                                SortKey$         = 2
                        FROM    FaInvolvierteInstitution INV
                                INNER JOIN vwInstitution INS ON INS.BaInstitutionID = INV.BaInstitutionID
                        WHERE   INV.FaFallID = {0}

                        UNION

                        -- Krankenkasse
                        SELECT  Art              = 'Krankenkasse',
                                Name             = INS.Name,
                                Adresse          = INS.Adresse,
                                Typ              = INS.Typ,
                                BaInstitutionID$ = INS.BaInstitutionID,
                                BaPersonID$      = null,
                                Adresse$         = INS.AdresseMehrzeilig,
                                SortKey$         = 3
                        FROM    FaFallPerson FAP
                                INNER JOIN BaKrankenversicherung KKV ON KKV.BaPersonID = FAP.BaPersonID
                                INNER JOIN vwInstitution         INS ON INS.BaInstitutionID = KKV.BaInstitutionID
                        WHERE   FAP.FaFallID = {0}

                        UNION

                        -- Vermieter
                        SELECT  Art              = 'Vermieter',
                                Name             = INS.Name,
                                Adresse          = INS.Adresse,
                                Typ              = INS.Typ,
                                BaInstitutionID$ = INS.BaInstitutionID,
                                BaPersonID$      = null,
                                Adresse$         = INS.AdresseMehrzeilig,
                                SortKey$         = 4
                        FROM    FaFallPerson FAP
                                INNER JOIN BaWohnsituationPerson WOP ON WOP.BaPersonID = FAP.BaPersonID
                                INNER JOIN BaWohnsituation       WOH ON WOH.BaWohnsituationID = WOP.BaWohnsituationID
                                INNER JOIN vwInstitution         INS ON INS.BaInstitutionID = WOH.BaInstitutionID
                        WHERE   FAP.FaFallID = {0}

                        UNION

                        -- Arbeitgeber
                        SELECT  Art              = 'Arbeitgeber',
                                Name             = INS.Name,
                                Adresse          = INS.Adresse,
                                Typ              = INS.Typ,
                                BaInstitutionID$ = INS.BaInstitutionID,
                                BaPersonID$      = null,
                                Adresse$         = INS.AdresseMehrzeilig,
                                SortKey$         = 5
                        FROM    FaFallPerson FAP
                                INNER JOIN BaArbeit      ARB ON ARB.BaPersonID = FAP.BaPersonID
                                INNER JOIN vwInstitution INS ON INS.BaInstitutionID = ARB.BaInstitutionID
                        WHERE   FAP.FaFallID = {0}

                        ORDER BY SortKey$, Name, Adresse
                        ",
                        qryBgPosition["FaFallID"].ToString(), ButtonClicked);
                    break;

                default:
                    Cancel = !dlg.SearchData(@"
              			SELECT Institution      = INS.Name,
                               Adresse          = INS.Adresse,
                               Typ              = INS.Typ,
                               BaInstitutionID$ = INS.BaInstitutionID,
                               BaPersonID$      = null,
                               Adresse$         = INS.AdresseMehrzeilig
                        FROM   vwInstitution INS
                        WHERE  INS.BaFreigabeStatusCode = 2 AND
                               (INS.Name LIKE '%' + {0} + '%' OR
                                INS.AdressZusatz LIKE '%' + {0} + '%')
              			ORDER BY Institution",
                        SearchString,
                        ButtonClicked, null, null, null);
                    break;
            }

            if (!Cancel)
            {
                qryBgPosition["BaInstitutionID"] = dlg["BaInstitutionID$"];
                qryBgPosition["Institution"] = DBUtil.IsEmpty(dlg["Name"]) ? dlg["Institution"] : dlg["Name"];
                qryBgPosition["Adresse"] = dlg["Adresse$"];
            }
            return Cancel;
        }

        private void edtInstitution_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            e.Cancel = AuswahlInstitutionFAMOZ(edtInstitution.EditValue.ToString(), e.ButtonClicked);
        }

        private void edtKostenart_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string SearchString = edtKostenart.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
                if (e.ButtonClicked)
                {
                    SearchString = "%";
                }
                else
                {
                    qryBgPosition["BgPositionsArtID"] = DBNull.Value;
                    qryBgPosition["Kostenart"] = DBNull.Value;
                    return;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();
            string sql = @"
                select LA                  = BKA.KontoNr,
                       Positionsart        = BPA.Name,
                       Gruppe              = GRP.Text,
                       BgPositionsartID$   = BPA.BgPositionsartID,
                       ProPerson$          = BPA.ProPerson,
                       ProUE$              = BPA.ProUE,
                       KOAPositionsart$    = BKA.KontoNr + ' '+ BPA.Name,
                       Name$               = BPA.Name,
                       VerwaltungSD$       = BPA.VerwaltungSD_Default
                from   WhPositionsart BPA
                       inner join BgKostenart BKA on BKA.BgKostenartID = BPA.BgKostenartID
                       left  join XLOVCode    GRP on GRP.LOVName = 'BgGruppe' AND GRP.Code = BPA.BgGruppeCode
                where  BPA.BgGruppeCode = " + BgGruppeCode.ToString() + @" and
                       BPA.BgKategorieCode = 1 and
                       (BKA.Name like '%' + {0} + '%' or
                        BKA.KontoNr like {0} + '%')
                order by 1,2";

            e.Cancel = !dlg.SearchData(sql, SearchString, e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                qryBgPosition["BgPositionsArtID"] = dlg["BgPositionsartID$"];
                qryBgPosition["Kostenart"] = dlg["KOAPositionsart$"];
                qryBgPosition["Buchungstext"] = dlg["Name$"];
                qryBgPosition["ProPerson"] = dlg["ProPerson$"];
                qryBgPosition["ProUE"] = dlg["ProUE$"];
                qryBgPosition["VerwaltungSD"] = dlg["VerwaltungSD$"];

                bool ProPerson = (bool)qryBgPosition["ProPerson"];
                bool ProUE = (bool)qryBgPosition["ProUE"];

                if (ProUE && !ProPerson) qryBgPosition["BaPersonID"] = null;

                SetEditMode();
            }
        }

        private bool FPAnpassungAblehnen(string TaskDescription, int ReceiverID)
        {
            try
            {
                // Pfad für Pendenz erzeugen
                string JumpToPath = string.Format(
                    "ActiveSQLQuery.Find=BgPositionID = {0};" +
                    "BaPersonID={1};" +
                    "ModulID=3;" +
                    "TreeNodeID=CtlWhFinanzplan{2}" +
                    "/CtlBgUebersicht/CtlBgSilC1_8;FaLeistungID={3};" +
                    "FaFallID={4};" +
                    "ClassName=FrmFall;",
                    qryBgPosition["BgPositionID"],
                    qryBgPosition["FallBaPersonID"],
                    qryBgPosition["BgFinanzplanID"],
                    qryBgPosition["FaLeistungID"],
                    qryBgPosition["FaFallID"]);

                // Pendenz erzeugen: Rückmeldung, pendent
                // + BgBewilligungsStatus der Position auf "abgelehnt"
                DBUtil.ExecSQLThrowingException(@"
                    INSERT INTO XTask (TaskTypeCode, TaskStatusCode, CreateDate, StartDate,
                                       [Subject], TaskDescription, SenderID, TaskSenderCode, ReceiverID, TaskReceiverCode,
                                       FaLeistungID, BaPersonID, JumpToPath)
                    VALUES (5, 1, GetDate(), GetDate(), {0}, {1}, {2}, 1, {3}, 1, {4}, {5}, {6})

                    UPDATE BgPosition SET BgBewilligungStatusCode = 2 WHERE BgPositionID = {7}",
                    string.Format("Bewilligung {0} abgelehnt.", qryBgPosition["Gruppe"]),
                    TaskDescription,
                    Session.User.UserID,
                    ReceiverID,
                    qryBgPosition["FaLeistungID"],
                    qryBgPosition["BaPersonID"],
                    JumpToPath,
                    qryBgPosition["BgPositionID"]);
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowInfo("Fehler beim Ablehnen der FP-Anpassung:\r\n\r\n" + ex.Message);
                return false;
            }

            Session.Commit();
            return true;
        }

        private bool GetUserPermission()
        {
            SqlQuery qry = DBUtil.OpenSQL(@"
                select ok = dbo.fnWhPosition_Permission({0},{1})",
                qryBgPosition["BgPositionID"],
                Session.User.UserID);

            if (qry.Count > 0)
                return (bool)qry["ok"];
            else
                return false;
        }

        private void qryBgPosition_AfterInsert(object sender, System.EventArgs e)
        {
            qryBgPosition["BgBudgetID"] = this.BgBudgetID;
            qryBgPosition["BgKategorieCode"] = 1;
            qryBgPosition["BgBewilligungStatusCode"] = BgBewilligungStatus.InVorbereitung;

            qryBgPosition["DatumVon"] = qryBgFinanzplan["FinanzplanVon"];
            qryBgPosition["DatumBis"] = qryBgFinanzplan["FinanzplanBis"];

            qryBgPosition["ProPerson"] = false;
            qryBgPosition["ProUE"] = true;

            edtKostenart.Focus();
        }

        private void qryBgPosition_BeforeDeleteQuestion(object sender, System.EventArgs e)
        {
            if (!DBUtil.IsEmpty(qryBgPosition["F"]))
            {
                throw new KissInfoException("Positionen des LE können nicht mehr gelöscht werden");
            }

            if (qryMonatsbudget.Count > 0)
            {
                throw new KissInfoException("Diese Position wird bereits in einem oder mehreren Monatsbudgets verwendet");
            }

            DBUtil.ExecSQL(@"
                delete BgDokument where BgPositionID = {0}
                delete BgBewilligung where BgPositionID = {0}",
                qryBgPosition["BgPositionID"]);
        }

        private void qryBgPosition_BeforePost(object sender, System.EventArgs e)
        {
            BgBewilligungStatus fpStatus = (BgBewilligungStatus)qryBgFinanzplan["FPStatus"];

            if (fpStatus == BgBewilligungStatus.Erteilt && edtDatumVon.EditMode != EditModeType.ReadOnly)
            {
                //bei existierenden Positionen (wenn sie aus dem vorherigen Finanzplan kopiert wurden) kann DatumVon NULL sein
                DBUtil.CheckNotNullField(edtDatumVon, lblDatumVon.Text);
            }

            DBUtil.CheckNotNullField(edtKostenart, lblKostenart.Text);
            DBUtil.CheckNotNullField(edtBuchungstext, lblBuchungstext.Text);
            DBUtil.CheckNotNullField(edtBetrag, lblBetrag.Text);

            DateTime gueltigVon;
            DateTime gueltigBis;

            if (DBUtil.IsEmpty(edtDatumVon.EditValue))
            {
                // Es wurde kein DatumVon eingegeben, d.h. für die Checks verwenden wir das frühest mögliche Datum
                gueltigVon = new DateTime(1900, 1, 1);
            }
            else
            {
                gueltigVon = (DateTime)edtDatumVon.EditValue;
            }

            if (DBUtil.IsEmpty(edtDatumBis.EditValue))
            {
                // Es wurde kein DatumBis eingegeben, d.h. für die Checks verwenden wir das spätest mögliche Datum
                gueltigBis = new DateTime(2079, 12, 31);
            }
            else
            {
                gueltigBis = (DateTime)edtDatumBis.EditValue;

                // Nur wenn das Datum explitit eingegeben wird, wird überprüft, ob es sicher grösser ist als Gültig von
                // => Dies erlaubt, dass der User zukünftige Leistungen ohne fixiertes Ende eingeben kann, die über den FP hinausgehen, z.B. eine Mieterhöhung, die erst in mehreren Monaten gültig ist
                if (gueltigBis < gueltigVon)
                {
                    throw new KissInfoException("'Gültig von' muss kleiner sein als 'Gültig bis'.");
                }

                WhUtil.CheckIfGueltigBisIsValidWithMonatsbudget(qryBgPosition["BgPositionID"] as int?, gueltigBis);
            }

            //Betrifft Person
            if (!DBUtil.IsEmpty(qryBgPosition["ProPerson"]) && !DBUtil.IsEmpty(qryBgPosition["ProUE"]))
            {
                bool ProPerson = (bool)qryBgPosition["ProPerson"];
                bool ProUE = (bool)qryBgPosition["ProUE"];

                if (ProPerson && !ProUE && DBUtil.IsEmpty(qryBgPosition["BaPersonID"]))
                {
                    edtBaPersonID.Focus();
                    throw new KissInfoException("Das Feld 'Betrifft Person' darf nicht leer bleiben für diese Leistungsart!");
                }
            }

            int PosStatus = ShUtil.GetCode(qryBgPosition["BgBewilligungStatusCode"]);

            //Betrag
            if (PosStatus == 1 && (Decimal)qryBgPosition["Betrag"] <= Decimal.Zero)
            {
                edtBetrag.Focus();
                throw new KissInfoException("Das Feld 'Betrag' darf nicht kleiner oder gleich 0.00 sein!");
            }
        }

        private void qryBgPosition_PositionChanged(object sender, System.EventArgs e)
        {
            SetEditMode();
            qryMonatsbudget.Fill(qryBgPosition["BgPositionID"]);
        }

        private void qryBgPosition_PostCompleted(object sender, System.EventArgs e)
        {
            qryBgPosition.Refresh();
        }

        private void SetEditMode()
        {
            BgBewilligungStatus FPStatus = (BgBewilligungStatus)qryBgFinanzplan["FPStatus"];
            BgBewilligungStatus PosStatus = (BgBewilligungStatus)qryBgPosition["BgBewilligungStatusCode"];

            bool abgeschlossen = !DBUtil.IsEmpty(qryBgFinanzplan["LeiDatumBis"]);
            bool editierbar = !abgeschlossen &&
                                 (FPStatus != BgBewilligungStatus.Gesperrt) &&
                                 (PosStatus != BgBewilligungStatus.Erteilt);

            bool anpassbar = !abgeschlossen &&
                                 (FPStatus != BgBewilligungStatus.Gesperrt);

            qryBgPosition.EnableBoundFields(editierbar);

            if (!DBUtil.IsEmpty(qryBgPosition["ProPerson"]) && !DBUtil.IsEmpty(qryBgPosition["ProUE"]))
            {
                bool ProPerson = (bool)qryBgPosition["ProPerson"];
                bool ProUE = (bool)qryBgPosition["ProUE"];

                edtBaPersonID.EditMode = editierbar && (ProPerson || !ProUE) ? EditModeType.Normal : EditModeType.ReadOnly;
            }
            else
            {
                edtBaPersonID.EditMode = EditModeType.ReadOnly;
            }

            var editModeEditierbar = editierbar ? EditModeType.Normal : EditModeType.ReadOnly;
            edtDatumVon.EditMode = editModeEditierbar;
            edtBetrag.EditMode = editModeEditierbar;

            if (anpassbar)
            {
                edtDatumBis.EditMode = EditModeType.Normal;
            }
        }

        #endregion Private Methods
    }
}