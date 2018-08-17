using System;
using System.Data;
using DevExpress.XtraGrid.Views.Base;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Klientenbuchhaltung
{
    public partial class CtlQueryKontiOhneBgKostenart : KissQueryControl
    {
        private int _kbPeriodeId;

        public CtlQueryKontiOhneBgKostenart()
        {
            InitializeComponent();
            grvQuery1.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            grvQuery1.OptionsCustomization.AllowSort = false;

            grdQuery1.XtraPrint += grdQuery1_XtraPrint;
        }

        void grdQuery1_XtraPrint(object sender, XtraPrintEventArgs e)
        {
            string footerTextLeft = Utils.GetDateRangeText(edtSearchDatumVon.Text, edtSearchDatumBis.Text);
            footerTextLeft = footerTextLeft + ", " + edtSucheKonto.Text;
            grdQuery1.SetHeaderAndFooterText(
                e,
                KissMsg.GetMLMessage(Name, "KbKonto", "Konto"),
                footerTextLeft
            );
        }

        private void CtlQueryKontiOhneBgKostenart_Load(object sender, EventArgs e)
        {
            qryQuery.SelectStatement = GetSelectStatement();

            _kbPeriodeId = (int)FormController.GetMessage("FrmKbKlientenbuchhaltung", false, "Action", "KbPeriodeID");
            kissSearch.SelectParameters = new object[] { _kbPeriodeId };
        }

        protected override void RunSearch()
        {
            DBUtil.CheckNotNullField(edtSucheKonto, "Konto");
            base.RunSearch();
        }

        private void qryQuery_AfterFill(object sender, System.EventArgs e)
        {
            // Saldo berechnen
            var saldo = (decimal)0.0;
            foreach (DataRow row in qryQuery.DataTable.Rows)
            {
                if (saldo == (decimal)0.0)
                {
                    saldo = Utils.ConvertToDecimal(row["Vorsaldo$"]);
                }
                saldo += Utils.ConvertToDecimal(row["Soll"]) - Utils.ConvertToDecimal(row["Haben"]);
                row["Saldo"] = saldo;
            }

            qryQuery.DataTable.AcceptChanges();
            qryQuery.RowModified = false;
            grdQuery1.DataSource = qryQuery;
        }


        private void edtSucheKonto_UserModifiedFld(object sender, Gui.UserModifiedFldEventArgs e)
        {
            string searchString = edtSucheKonto.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    edtSucheKonto.LookupID = DBNull.Value;
                    edtSucheKonto.EditValue = DBNull.Value;
                }
            }

            var dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(string.Format(@"
                SELECT KbKontoID$ = KTO.KbKontoID,
                       KTO.KontoNr,
                       KTO.KontoName
                FROM KbKonto KTO
                    LEFT JOIN BgKostenart BGK ON BGK.KontoNr = KTO.KontoNr
                WHERE (KTO.KontoNr LIKE '%' + isNull({0},'') + '%' OR KTO.KontoName LIKE '%' + isNull({0},'') + '%')
                  AND KTO.KbPeriodeID = {1}
                  AND BGK.BgKostenartID IS NULL
                  AND (KbKontoklasseCode NOT IN (5,6) OR KbKontoklasseCode IS NULL)
                  AND Kontogruppe = 0
                ORDER BY KTO.KontoNr", "{0}", _kbPeriodeId),
              searchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                edtSucheKonto.EditValue = dlg["KontoNr"] + " " + dlg["KontoName"];
                edtSucheKonto.LookupID = dlg["KontoNr"].ToString();
            }
        }


        private string GetSelectStatement()
        {
            string statement = @"
IF (OBJECT_ID('TempDB.dbo.#buchung') IS NOT NULL)
BEGIN 
  DROP TABLE #buchung;
END;


DECLARE @PeriodeID INT, @DatumVon DATETIME, @DatumBis DATETIME, @KontoNr VARCHAR(10), @Vorsaldo MONEY;
SET @PeriodeID = {0};
SET @DatumVon = '17530101';
--- SET @DatumVon = {edtSearchDatumVon};
SET @DatumBis = '99991231';
--- SET @DatumBis = {edtSearchDatumBis};
SET @KontoNr = '';
--- SET @KontoNr = {edtSucheKonto.LookupID};

SELECT @Vorsaldo = dbo.fnKbGetKontoVorsaldo(@PeriodeID, @KontoNr, @DatumVon, 0);


SELECT [Beleg Nr]		= BUC.Belegnr,
       [Datum]			= REB.BelegDatum,
       [Buchungstext]	= BUC.Text,
       [Mitarbeiter]	= USR.LogonName,
       [Gegenkonto]		= REB.SollKtoNr,
       [Soll]			= REB.Betrag,
       [Haben]			= 0.0,
       [Saldo]			= 0.0,
       KontoNr$			= REB.SollKtoNr,
       Vorsaldo$        = @Vorsaldo,
       Betrag$			= CASE WHEN BUC.SollKtoNr IS NULL THEN BUC.Betrag ELSE -BUC.Betrag END
INTO #buchung
FROM dbo.fnKbGetRelevanteBuchungen(@PeriodeID, @DatumVon, @DatumBis, 0, 0) REB -- KbPeriodeID aus FormKlibu (FormController)

  INNER JOIN dbo.KbBuchung	BUC ON BUC.KbBuchungID = REB.KbBuchungID
  LEFT  JOIN dbo.XUser              USR WITH(READUNCOMMITTED) -- es hat leider (noch)nicht jede Buchungen einen Ersteller
                                 ON USR.UserID = BUC.ErstelltUserID


WHERE BUC.BelegNr IS NOT NULL
  AND REB.SollKtoNr = @KontoNr
  AND REB.BelegDatum IS NOT NULL
  AND REB.Betrag <> 0       -- Ticket 2703


UNION ALL

SELECT [Beleg Nr]		= BUC.Belegnr,
       [Datum]			= REB.BelegDatum,
       [Buchungstext]	= BUC.Text,
       [Mitarbeiter]	= USR.LogonName,
       [Gegenkonto]		= REB.SollKtoNr,
       [Soll]			= 0.0,
       [Haben]			= REB.Betrag,
       [Saldo]			= 0.0,
       KontoNr$			= REB.HabenKtoNr,
       Vorsaldo$        = @Vorsaldo,
       Betrag$			= CASE WHEN BUC.SollKtoNr IS NULL THEN BUC.Betrag ELSE -BUC.Betrag END

FROM dbo.fnKbGetRelevanteBuchungen(@PeriodeID, @DatumVon, @DatumBis, 0, 0) REB -- KbPeriodeID aus FormKlibu (FormController)

  INNER JOIN dbo.KbBuchung	BUC ON BUC.KbBuchungID = REB.KbBuchungID
  LEFT  JOIN dbo.XUser              USR WITH(READUNCOMMITTED) -- es hat leider (noch)nicht jede Buchungen einen Ersteller
                                 ON USR.UserID = BUC.ErstelltUserID

WHERE BUC.BelegNr IS NOT NULL
  AND REB.HabenKtoNr = @KontoNr
  AND REB.BelegDatum IS NOT NULL
  AND REB.Betrag <> 0       -- Ticket 2703


ORDER BY REB.BelegDatum ASC

SELECT [Beleg Nr]		= NULL,
       [Datum]			= NULL,
       [Buchungstext]	= 'Vorsaldo',
       [Mitarbeiter]	= '',
       [Gegenkonto]		= '',
       [Soll]			= NULL,
       [Haben]			= NULL,
       [Saldo]			= @Vorsaldo,
       KontoNr$			= '',
       Vorsaldo$        = @Vorsaldo,
       Betrag$			= NULL

UNION ALL

SELECT *
FROM #buchung";

            return statement;
        }

    }
}
