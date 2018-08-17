using System;

using KiSS4.DB;

namespace KiSS4.Query
{
    public class CtlQueryAyKostenarten : KiSS4.Common.KissQueryControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string SELECT_OUTPUT_LISTE2 = @"
            --SQLCHECK_IGNORE--
            --------------------------------
            ------- Übersicht Totalzahlen / Gruppiert
            --------------------------------
            SELECT Kostengruppe,
                   KontoNr,--ExtFibuKostenartNr,
                   Leistung = Text,
                   Betrag   = convert(numeric(11, 2), Betrag)
            FROM @Result
            ORDER BY Sortkey1, Sortkey2,  BgGruppeCode, KontoNr, Kostengruppe DESC";
        private const string SELECT_OUTPUT_LISTE3 = @"
            --SQLCHECK_IGNORE--
            --------------------------------
            ------- Buchungen
            --------------------------------
            SELECT Person            = PRS.Name + isNull(', ' + PRS.Vorname,''),
                   [N.Nr]            = PRS.NNummer,
                   Monatsbudget      = dbo.fnXKurzMonatJahr(dbo.fnDateSerial(BDG.Jahr,BDG.Monat, 1)),
                   Kostenart         = KontoNr,
                   Typ,
                   Buchungstext,
                   TMP.Bemerkung,
                   Betrag,
                   BaPersonID$ = PRS.BaPersonID
            FROM @tmp                TMP
              INNER JOIN dbo.FaLeistung  FAL WITH (READUNCOMMITTED) ON FAL.FaLeistungID = TMP.FaLeistungID
              INNER JOIN dbo.BaPerson    PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = FAL.BaPersonID
              INNER JOIN dbo.BgBudget    BDG WITH (READUNCOMMITTED) ON BDG.BgBudgetID = TMP.BgBudgetID
            ORDER BY 1,3,4,5";
        private const string SELECT_SEARCH_VALUES = @"
            /*
            *  DatumVon, DatumBis schränken sowohl Eintrittsdatum (nur jene mit finanz. Unterstz.)
            *  als auch Budget-Monate ein
            */

            DECLARE @tmp Table(
              FaLeistungID       INT,
              BgGruppeCode       INT,
              BgPositionsartID   INT,
              KontoNr            VARCHAR(10),
              Betrag             MONEY,
              Reduktion          MONEY,
              BgBudgetID         INT,
              Buchungstext       VARCHAR(100),
              Typ                VARCHAR(100),
              Bemerkung          VARCHAR(6000)
            )

            DECLARE @Result Table(
              Kostengruppe       VARCHAR(100),
              KontoNr            VARCHAR(10),
              Text               VARCHAR(100),
              Betrag             MONEY,
              BgPositionsartID   INT,
              BgGruppeCode       INT,
              Sortkey1           VARCHAR(10),
              Sortkey2           VARCHAR(10)
            )

            INSERT INTO @tmp
            SELECT SFP.FaLeistungID,
                   APT.BgGruppeCode,
                   APT.BgPositionsartID,
                   KTA.KontoNr,
                   VBP.Betrag,
                   VBP.Reduktion,
                   BBG.BgBudgetID,
                   VBP.Buchungstext,
                   APT.Name,
                   VBP.Bemerkung
            FROM dbo.FaLeistung                    FAL WITH (READUNCOMMITTED)
              INNER JOIN dbo.BgFinanzplan          SFP WITH (READUNCOMMITTED) ON SFP.FaLeistungID = FAL.FaLeistungID
              INNER JOIN dbo.BgFinanzplan_BaPerson FPP WITH (READUNCOMMITTED) ON FPP.BgFinanzplanID = SFP.BgFinanzplanID
                                                  AND FPP.IstUnterstuetzt = 1
              INNER JOIN dbo.BgBudget              BBG WITH (READUNCOMMITTED) ON BBG.BgFinanzplanID = SFP.BgFinanzplanID
              INNER JOIN dbo.vwBgPosition          VBP ON VBP.BgBudgetID = BBG.BgBudgetID AND IsNull(VBP.BaPersonID, FAL.BaPersonID) = FPP.BaPersonID
              INNER JOIN dbo.AyPositionsart        APT ON APT.BgPositionsartID = VBP.BgPositionsartID
              INNER JOIN dbo.BgKostenart           KTA WITH (READUNCOMMITTED) ON KTA.BgKostenartID = APT.BgKostenartID
              INNER JOIN dbo.fnAyPersonEinAustritt() PEA ON PEA.FaLeistungID = FAL.FaLeistungID
                                                        AND PEA.BaPersonID = FPP.BaPersonID
              LEFT JOIN dbo.FaLeistungArchiv  ARC WITH (READUNCOMMITTED) ON ARC.FaLeistungID = FAL.FaLeistungID
                                             AND ARC.CheckOut IS NULL
            WHERE FAL.ModulID = 6 AND BBG.Masterbudget = 0 AND BBG.BgBewilligungStatusCode = 5 --(Monatsbudget freigegeben)
              AND PEA.Eintritt <= {edtDatumBis} and isNull(PEA.Austritt, {edtDatumVon}) >= {edtDatumVon}
              AND (APT.ProPerson=1 AND FPP.BaPersonID = PEA.BaPersonID OR APT.ProPerson=0)
              AND (BBG.Jahr > year({edtDatumVon}) OR (BBG.Jahr = year({edtDatumVon}) AND BBG.Monat >= month({edtDatumVon})))
              AND (BBG.Jahr < year({edtDatumBis}) OR (BBG.Jahr = year({edtDatumBis}) AND BBG.Monat <= month({edtDatumBis})))
            --- AND ({edtStatus} <> 1 OR FAL.DatumBis IS NULL)
            --- AND ({edtStatus} <> 2 OR FAL.DatumBis IS NOT NULL AND ARC.FaLeistungID IS NULL)

            --------------------------------------------
            -------- Resultat aufbereiten
            --------------------------------------------
            INSERT INTO @Result
            SELECT NULL,
                   TMP.KontoNr,
                   APT.Name,
                   SUM(Betrag),
                   TMP.BgPositionsartID,
                   TMP.BgGruppeCode,
                   RIGHT(REPLICATE('0', 9) + LEFT(TMP.KontoNr, LEN(TMP.KontoNr)-1) + '0',10), --10*(TMP.ExtFibuKostenartNr/10),
                   RIGHT(REPLICATE('0', 10) + TMP.KontoNr, 10)
            FROM @tmp                    TMP
              INNER JOIN dbo.AyPositionsart  APT ON APT.BgPositionsartID = TMP.BgPositionsartID
            GROUP BY TMP.BgPositionsartID, APT.Name, TMP.BgGruppeCode, TMP.KontoNr

            INSERT INTO @Result
            SELECT NULL,
                   NULL,
                   'Total '+ MIN(LEFT(TMP.KontoNr, LEN(TMP.KontoNr)-1) + '0'), --'Total '+ CONVERT(VARCHAR, MIN(10*(TMP.ExtFibuKostenartNr/10))),
                   SUM(Betrag),
                   NULL,
                   MAX(TMP.BgGruppeCode),
                   MAX(RIGHT(REPLICATE('0', 9) + LEFT(TMP.KontoNr, LEN(TMP.KontoNr)-1) + '1',10)), --MAX(10*(TMP.ExtFibuKostenartNr/10))+1,
                   MAX(RIGHT(REPLICATE('0', 10) + TMP.KontoNr, 10))--MAX(TMP.ExtFibuKostenartNr)
            FROM @tmp                  TMP
            GROUP BY LEFT(TMP.KontoNr, LEN(TMP.KontoNr)-1) --ExtFibuKostenartNr/10-- TMP.BgGruppeCode

            --Leerzeilen
            INSERT INTO @Result
            SELECT NULL,
                   NULL,
                   NULL,
                   NULL,
                   NULL,
                   MAX(TMP.BgGruppeCode),
                   MAX(RIGHT(REPLICATE('0', 9) + LEFT(TMP.KontoNr, LEN(TMP.KontoNr)-1) + '1',10)), --MAX(10*(TMP.ExtFibuKostenartNr/10))+1,
                   MAX(RIGHT(REPLICATE('0', 10) + TMP.KontoNr, 10))--MAX(TMP.ExtFibuKostenartNr)
            FROM @tmp TMP
            GROUP BY LEFT(TMP.KontoNr, LEN(TMP.KontoNr)-1)--ExtFibuKostenartNr/10

            --Headerzeilen
            INSERT INTO @Result
            SELECT dbo.fnLovText('BgGruppe', MAX(TMP.BgGruppeCode)) + ' ('+ MIN(LEFT(TMP.KontoNr, LEN(TMP.KontoNr)-1) + '0') + ')',--dbo.fnLovText('BgGruppe', MAX(TMP.BgGruppeCode)) + ' ('+ CONVERT(VARCHAR, MIN(10*(TMP.ExtFibuKostenartNr/10))) + ')',
                   NULL,
                   NULL,
                   NULL,
                   NULL,
                   MIN(TMP.BgGruppeCode),
                   MIN(RIGHT(REPLICATE('0', 9) + LEFT(TMP.KontoNr, LEN(TMP.KontoNr)-1) + '0',10)),--MIN(10*(TMP.ExtFibuKostenartNr/10)),
                   MIN(RIGHT(REPLICATE('0', 10) + TMP.KontoNr, 10))--MIN(TMP.ExtFibuKostenartNr)
            FROM @tmp TMP
            GROUP BY LEFT(TMP.KontoNr, LEN(TMP.KontoNr)-1)--ExtFibuKostenartNr/10--TMP.BgGruppeCode

            --Total Kostenart
            INSERT INTO @Result
            SELECT NULL,
                   KontoNr,--ExtFibuKostenartNr,
                   'Total ' + KontoNr,--'Total ' + CONVERT(VARCHAR, ExtFibuKostenartNr),
                   SUM(Betrag),
                   NULL,
                   999999999,
                   RIGHT(REPLICATE('0', 9) + LEFT(TMP.KontoNr, LEN(TMP.KontoNr)-1) + '0',10),--10 * (TMP.ExtFibuKostenartNr/10),
                   RIGHT(REPLICATE('0', 10) + TMP.KontoNr, 10)--TMP.ExtFibuKostenartNr
            FROM @tmp TMP
            GROUP BY TMP.KontoNr--ExtFibuKostenartNr

            --Leerzeile nach Total Kostenart
            INSERT INTO @Result
            SELECT NULL,
                   NULL,
                   NULL,
                   NULL,
                   NULL,
                   -999999999,
                   RIGHT(REPLICATE('0', 9) + LEFT(TMP.KontoNr, LEN(TMP.KontoNr)-1) + '0',10),--10*(TMP.ExtFibuKostenartNr/10),
                   RIGHT(REPLICATE('0', 10) + TMP.KontoNr, 10)--TMP.ExtFibuKostenartNr
            FROM @tmp TMP
            GROUP BY KontoNr--ExtFibuKostenartNr";

        #endregion

        #region Private Fields

        private DevExpress.XtraGrid.Columns.GridColumn colBemerkung;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungstext;
        private DevExpress.XtraGrid.Columns.GridColumn colGesKosten40;
        private DevExpress.XtraGrid.Columns.GridColumn colGrundbedarf10;
        private DevExpress.XtraGrid.Columns.GridColumn colKostenart;
        private DevExpress.XtraGrid.Columns.GridColumn colKostengruppe;
        private DevExpress.XtraGrid.Columns.GridColumn colLeistung;
        private DevExpress.XtraGrid.Columns.GridColumn colLeistzGAK70;
        private DevExpress.XtraGrid.Columns.GridColumn colLeistzGBFM60;
        private DevExpress.XtraGrid.Columns.GridColumn colMonatsbudget;
        private DevExpress.XtraGrid.Columns.GridColumn colNNr;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colQuellensteuer;
        private DevExpress.XtraGrid.Columns.GridColumn colSILFKS50;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalzahlungen;
        private DevExpress.XtraGrid.Columns.GridColumn colTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colWohnen20;
        private DevExpress.XtraGrid.Columns.GridColumn colZahnarzt30;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Common.CtlGotoFall ctlGotoFallListe2;
        private KiSS4.Common.CtlGotoFall ctlGotoFallListe3;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissLookUpEdit edtStatus;
        private KiSS4.Gui.KissGrid grdListe2;
        private KiSS4.Gui.KissGrid grdListe3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView grvListe2;
        private DevExpress.XtraGrid.Views.Grid.GridView grvListe3;
        private KiSS4.Gui.KissLabel lblStatus;
        private KiSS4.Gui.KissLabel lblZeitraumvon;
        private KiSS4.Gui.KissLabel lblbis;
        private KiSS4.DB.SqlQuery qryListe2;
        private KiSS4.DB.SqlQuery qryListe3;
        private SharpLibrary.WinControls.TabPageEx tpgListe2;
        private SharpLibrary.WinControls.TabPageEx tpgListe3;

        #endregion

        #endregion

        #region Constructors

        public CtlQueryAyKostenarten()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryAyKostenarten));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.components = new System.ComponentModel.Container();
            this.tpgListe2 = new SharpLibrary.WinControls.TabPageEx();
            this.ctlGotoFallListe2 = new KiSS4.Common.CtlGotoFall();
            this.grdListe2 = new KiSS4.Gui.KissGrid();
            this.qryListe2 = new KiSS4.DB.SqlQuery();
            this.grvListe2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tpgListe3 = new SharpLibrary.WinControls.TabPageEx();
            this.ctlGotoFallListe3 = new KiSS4.Common.CtlGotoFall();
            this.qryListe3 = new KiSS4.DB.SqlQuery();
            this.grdListe3 = new KiSS4.Gui.KissGrid();
            this.grvListe3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblZeitraumvon = new KiSS4.Gui.KissLabel();
            this.lblbis = new KiSS4.Gui.KissLabel();
            this.lblStatus = new KiSS4.Gui.KissLabel();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtStatus = new KiSS4.Gui.KissLookUpEdit();
            this.colBemerkung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungstext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGesKosten40 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGrundbedarf10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKostenart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKostengruppe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLeistung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLeistzGAK70 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLeistzGBFM60 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonatsbudget = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuellensteuer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSILFKS50 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalzahlungen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWohnen20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZahnarzt30 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            this.tpgListe2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdListe2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryListe2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvListe2)).BeginInit();
            this.tpgListe3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryListe3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdListe3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvListe3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitraumvon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            // 
            // grvQuery1
            // 
            this.grvQuery1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvQuery1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.Empty.Options.UseBackColor = true;
            this.grvQuery1.Appearance.Empty.Options.UseFont = true;
            this.grvQuery1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvQuery1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.EvenRow.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvQuery1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvQuery1.Appearance.FocusedCell.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvQuery1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvQuery1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.FocusedRow.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseFont = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvQuery1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvQuery1.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvQuery1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvQuery1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery1.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvQuery1.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvQuery1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.OddRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.OddRow.Options.UseFont = true;
            this.grvQuery1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvQuery1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.Row.Options.UseBackColor = true;
            this.grvQuery1.Appearance.Row.Options.UseFont = true;
            this.grvQuery1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvQuery1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvQuery1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.SelectedRow.Options.UseFont = true;
            this.grvQuery1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery1.Appearance.VertLine.Options.UseBackColor = true;
            this.grvQuery1.OptionsBehavior.Editable = false;
            this.grvQuery1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvQuery1.OptionsNavigation.AutoFocusNewRow = true;
            this.grvQuery1.OptionsNavigation.UseTabKey = false;
            this.grvQuery1.OptionsPrint.AutoWidth = false;
            this.grvQuery1.OptionsPrint.ExpandAllDetails = true;
            this.grvQuery1.OptionsPrint.UsePrintStyles = true;
            this.grvQuery1.OptionsView.ColumnAutoWidth = false;
            this.grvQuery1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvQuery1.OptionsView.ShowGroupPanel = false;
            this.grvQuery1.OptionsView.ShowIndicator = false;
            // 
            // grdQuery1
            // 
            // 
            // 
            // 
            this.grdQuery1.EmbeddedNavigator.Name = "";
            this.grdQuery1.MainView = this.gridView1;
            this.grdQuery1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // xDocument
            // 
            this.xDocument.DataMember = null;
            this.xDocument.EditValue = null;
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.xDocument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("xDocument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Dokument öffnen")});
            this.xDocument.Visible = false;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = "BaPersonID$";
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Controls.Add(this.tpgListe3);
            this.tabControlSearch.Controls.Add(this.tpgListe2);
            this.tabControlSearch.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgListe2,
            this.tpgListe3});
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListe, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListe2, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListe3, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgSuchen, 0);
            // 
            // tpgListe
            // 
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtStatus);
            this.tpgSuchen.Controls.Add(this.edtDatumBis);
            this.tpgSuchen.Controls.Add(this.edtDatumVon);
            this.tpgSuchen.Controls.Add(this.lblStatus);
            this.tpgSuchen.Controls.Add(this.lblbis);
            this.tpgSuchen.Controls.Add(this.lblZeitraumvon);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.TabIndex = 3;
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZeitraumvon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblbis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblStatus, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtStatus, 0);
            // 
            // tpgListe2
            // 
            this.tpgListe2.Controls.Add(this.ctlGotoFallListe2);
            this.tpgListe2.Controls.Add(this.grdListe2);
            this.tpgListe2.Location = new System.Drawing.Point(6, 6);
            this.tpgListe2.Name = "tpgListe2";
            this.tpgListe2.Size = new System.Drawing.Size(772, 424);
            this.tpgListe2.TabIndex = 1;
            this.tpgListe2.Title = "Liste 2";
            // 
            // ctlGotoFallListe2
            // 
            this.ctlGotoFallListe2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctlGotoFallListe2.BaPersonID = ((object)(resources.GetObject("ctlGotoFallListe2.BaPersonID")));
            this.ctlGotoFallListe2.Location = new System.Drawing.Point(3, 398);
            this.ctlGotoFallListe2.Name = "ctlGotoFallListe2";
            this.ctlGotoFallListe2.Size = new System.Drawing.Size(154, 24);
            this.ctlGotoFallListe2.TabIndex = 7;
            this.ctlGotoFallListe2.Visible = false;
            // 
            // grdListe2
            // 
            this.grdListe2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdListe2.DataSource = this.qryListe2;
            // 
            // 
            // 
            this.grdListe2.EmbeddedNavigator.Name = "";
            this.grdListe2.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdListe2.Location = new System.Drawing.Point(3, 2);
            this.grdListe2.MainView = this.grvListe2;
            this.grdListe2.Name = "grdListe2";
            this.grdListe2.Size = new System.Drawing.Size(766, 392);
            this.grdListe2.TabIndex = 6;
            this.grdListe2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvListe2});
            // 
            // qryListe2
            // 
            this.qryListe2.FillTimeOut = 300;
            this.qryListe2.HostControl = this;
            // 
            // grvListe2
            // 
            this.grvListe2.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvListe2.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2.Appearance.Empty.Options.UseBackColor = true;
            this.grvListe2.Appearance.Empty.Options.UseFont = true;
            this.grvListe2.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2.Appearance.EvenRow.Options.UseFont = true;
            this.grvListe2.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvListe2.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvListe2.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvListe2.Appearance.FocusedCell.Options.UseFont = true;
            this.grvListe2.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvListe2.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvListe2.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvListe2.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvListe2.Appearance.FocusedRow.Options.UseFont = true;
            this.grvListe2.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvListe2.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvListe2.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvListe2.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvListe2.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvListe2.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvListe2.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvListe2.Appearance.GroupRow.Options.UseFont = true;
            this.grvListe2.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvListe2.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvListe2.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvListe2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvListe2.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvListe2.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvListe2.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvListe2.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvListe2.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvListe2.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvListe2.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvListe2.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvListe2.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvListe2.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvListe2.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2.Appearance.OddRow.Options.UseFont = true;
            this.grvListe2.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvListe2.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2.Appearance.Row.Options.UseBackColor = true;
            this.grvListe2.Appearance.Row.Options.UseFont = true;
            this.grvListe2.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2.Appearance.SelectedRow.Options.UseFont = true;
            this.grvListe2.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvListe2.Appearance.VertLine.Options.UseBackColor = true;
            this.grvListe2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvListe2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvListe2.GridControl = this.grdListe2;
            this.grvListe2.Name = "grvListe2";
            this.grvListe2.OptionsBehavior.Editable = false;
            this.grvListe2.OptionsCustomization.AllowFilter = false;
            this.grvListe2.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvListe2.OptionsNavigation.AutoFocusNewRow = true;
            this.grvListe2.OptionsNavigation.UseTabKey = false;
            this.grvListe2.OptionsView.ColumnAutoWidth = false;
            this.grvListe2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvListe2.OptionsView.ShowGroupPanel = false;
            this.grvListe2.OptionsView.ShowIndicator = false;
            // 
            // tpgListe3
            // 
            this.tpgListe3.Controls.Add(this.ctlGotoFallListe3);
            this.tpgListe3.Controls.Add(this.grdListe3);
            this.tpgListe3.Location = new System.Drawing.Point(6, 6);
            this.tpgListe3.Name = "tpgListe3";
            this.tpgListe3.Size = new System.Drawing.Size(772, 424);
            this.tpgListe3.TabIndex = 2;
            this.tpgListe3.Title = "Liste 3";
            // 
            // ctlGotoFallListe3
            // 
            this.ctlGotoFallListe3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctlGotoFallListe3.BaPersonID = ((object)(resources.GetObject("ctlGotoFallListe3.BaPersonID")));
            this.ctlGotoFallListe3.DataMember = "BaPersonID$";
            this.ctlGotoFallListe3.DataSource = this.qryListe3;
            this.ctlGotoFallListe3.Location = new System.Drawing.Point(3, 398);
            this.ctlGotoFallListe3.Name = "ctlGotoFallListe3";
            this.ctlGotoFallListe3.Size = new System.Drawing.Size(154, 24);
            this.ctlGotoFallListe3.TabIndex = 7;
            // 
            // qryListe3
            // 
            this.qryListe3.FillTimeOut = 300;
            this.qryListe3.HostControl = this;
            // 
            // grdListe3
            // 
            this.grdListe3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdListe3.DataSource = this.qryListe3;
            // 
            // 
            // 
            this.grdListe3.EmbeddedNavigator.Name = "";
            this.grdListe3.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdListe3.Location = new System.Drawing.Point(3, 2);
            this.grdListe3.MainView = this.grvListe3;
            this.grdListe3.Name = "grdListe3";
            this.grdListe3.Size = new System.Drawing.Size(766, 392);
            this.grdListe3.TabIndex = 6;
            this.grdListe3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvListe3});
            // 
            // grvListe3
            // 
            this.grvListe3.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvListe3.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe3.Appearance.Empty.Options.UseBackColor = true;
            this.grvListe3.Appearance.Empty.Options.UseFont = true;
            this.grvListe3.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe3.Appearance.EvenRow.Options.UseFont = true;
            this.grvListe3.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvListe3.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe3.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvListe3.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvListe3.Appearance.FocusedCell.Options.UseFont = true;
            this.grvListe3.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvListe3.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvListe3.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe3.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvListe3.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvListe3.Appearance.FocusedRow.Options.UseFont = true;
            this.grvListe3.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvListe3.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvListe3.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvListe3.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvListe3.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvListe3.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvListe3.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvListe3.Appearance.GroupRow.Options.UseFont = true;
            this.grvListe3.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvListe3.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvListe3.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvListe3.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvListe3.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvListe3.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvListe3.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvListe3.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvListe3.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe3.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvListe3.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvListe3.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvListe3.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvListe3.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvListe3.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvListe3.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe3.Appearance.OddRow.Options.UseFont = true;
            this.grvListe3.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvListe3.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe3.Appearance.Row.Options.UseBackColor = true;
            this.grvListe3.Appearance.Row.Options.UseFont = true;
            this.grvListe3.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe3.Appearance.SelectedRow.Options.UseFont = true;
            this.grvListe3.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvListe3.Appearance.VertLine.Options.UseBackColor = true;
            this.grvListe3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvListe3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvListe3.GridControl = this.grdListe3;
            this.grvListe3.Name = "grvListe3";
            this.grvListe3.OptionsBehavior.Editable = false;
            this.grvListe3.OptionsCustomization.AllowFilter = false;
            this.grvListe3.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvListe3.OptionsNavigation.AutoFocusNewRow = true;
            this.grvListe3.OptionsNavigation.UseTabKey = false;
            this.grvListe3.OptionsView.ColumnAutoWidth = false;
            this.grvListe3.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvListe3.OptionsView.ShowGroupPanel = false;
            this.grvListe3.OptionsView.ShowIndicator = false;
            // 
            // lblZeitraumvon
            // 
            this.lblZeitraumvon.Location = new System.Drawing.Point(10, 40);
            this.lblZeitraumvon.Name = "lblZeitraumvon";
            this.lblZeitraumvon.Size = new System.Drawing.Size(130, 24);
            this.lblZeitraumvon.TabIndex = 2;
            this.lblZeitraumvon.Text = "Zeitraum von";
            this.lblZeitraumvon.UseCompatibleTextRendering = true;
            // 
            // lblbis
            // 
            this.lblbis.Location = new System.Drawing.Point(270, 40);
            this.lblbis.Name = "lblbis";
            this.lblbis.Size = new System.Drawing.Size(130, 24);
            this.lblbis.TabIndex = 3;
            this.lblbis.Text = "bis";
            this.lblbis.UseCompatibleTextRendering = true;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(10, 70);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(130, 24);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Status";
            this.lblStatus.UseCompatibleTextRendering = true;
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.EditValue = "";
            this.edtDatumVon.Location = new System.Drawing.Point(150, 40);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVon.TabIndex = 22;
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.EditValue = "";
            this.edtDatumBis.Location = new System.Drawing.Point(300, 40);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBis.TabIndex = 23;
            // 
            // edtStatus
            // 
            this.edtStatus.Location = new System.Drawing.Point(150, 70);
            this.edtStatus.Name = "edtStatus";
            this.edtStatus.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStatus.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStatus.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStatus.Properties.Appearance.Options.UseBackColor = true;
            this.edtStatus.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStatus.Properties.Appearance.Options.UseFont = true;
            this.edtStatus.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtStatus.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtStatus.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtStatus.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtStatus.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStatus.Properties.NullText = "";
            this.edtStatus.Properties.ShowFooter = false;
            this.edtStatus.Properties.ShowHeader = false;
            this.edtStatus.Size = new System.Drawing.Size(250, 24);
            this.edtStatus.TabIndex = 24;
            // 
            // colBemerkung
            // 
            this.colBemerkung.Name = "colBemerkung";
            // 
            // colBetrag
            // 
            this.colBetrag.Name = "colBetrag";
            // 
            // colBuchungstext
            // 
            this.colBuchungstext.Name = "colBuchungstext";
            // 
            // colGesKosten40
            // 
            this.colGesKosten40.Name = "colGesKosten40";
            // 
            // colGrundbedarf10
            // 
            this.colGrundbedarf10.Name = "colGrundbedarf10";
            // 
            // colKostenart
            // 
            this.colKostenart.Name = "colKostenart";
            // 
            // colKostengruppe
            // 
            this.colKostengruppe.Name = "colKostengruppe";
            // 
            // colLeistung
            // 
            this.colLeistung.Name = "colLeistung";
            // 
            // colLeistzGAK70
            // 
            this.colLeistzGAK70.Name = "colLeistzGAK70";
            // 
            // colLeistzGBFM60
            // 
            this.colLeistzGBFM60.Name = "colLeistzGBFM60";
            // 
            // colMonatsbudget
            // 
            this.colMonatsbudget.Name = "colMonatsbudget";
            // 
            // colNNr
            // 
            this.colNNr.Name = "colNNr";
            // 
            // colPerson
            // 
            this.colPerson.Name = "colPerson";
            // 
            // colQuellensteuer
            // 
            this.colQuellensteuer.Name = "colQuellensteuer";
            // 
            // colSILFKS50
            // 
            this.colSILFKS50.Name = "colSILFKS50";
            // 
            // colStatus
            // 
            this.colStatus.Name = "colStatus";
            // 
            // colTotalzahlungen
            // 
            this.colTotalzahlungen.Name = "colTotalzahlungen";
            // 
            // colTyp
            // 
            this.colTyp.Name = "colTyp";
            // 
            // colWohnen20
            // 
            this.colWohnen20.Name = "colWohnen20";
            // 
            // colZahnarzt30
            // 
            this.colZahnarzt30.Name = "colZahnarzt30";
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
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.grdQuery1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.UseTabKey = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // CtlQueryAyKostenarten
            // 
            this.Name = "CtlQueryAyKostenarten";
            this.Load += new System.EventHandler(this.CtlQueryAyKostenarten_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            this.tpgListe2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdListe2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryListe2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvListe2)).EndInit();
            this.tpgListe3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qryListe3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdListe3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvListe3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitraumvon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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

        private void CtlQueryAyKostenarten_Load(object sender, System.EventArgs e)
        {
            qryListe2.SelectStatement = SELECT_SEARCH_VALUES + SELECT_OUTPUT_LISTE2;
            qryListe3.SelectStatement = SELECT_SEARCH_VALUES + SELECT_OUTPUT_LISTE3;

            const string text = "Text";
            var qry = DBUtil.OpenSQL(@"
                SELECT Code = 1, Text = 'aktiv'
                UNION ALL
                SELECT Code = 2, Text = 'geschlossen'");
            System.Data.DataRow newRow = qry.DataTable.NewRow();
            newRow[text] = "";
            qry.DataTable.Rows.InsertAt(newRow, 0);
            newRow.AcceptChanges();
            edtStatus.Properties.Columns.Clear();
            edtStatus.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[]
            {
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo(text, "", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default)
            });
            edtStatus.Properties.ShowFooter = false;
            edtStatus.Properties.ShowHeader = false;
            edtStatus.Properties.DisplayMember = text;
            edtStatus.Properties.ValueMember = "Code";
            edtStatus.Properties.DropDownRows = Math.Min(qry.Count, 7);
            edtStatus.Properties.DataSource = qry;
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void RunSearch()
        {
            DBUtil.CheckNotNullField(edtDatumVon, "Zeitraum von");
            DBUtil.CheckNotNullField(edtDatumBis, "Zeitraum bis");

            base.RunSearch();
        }

        #endregion

        #endregion
    }
}