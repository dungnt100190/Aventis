SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwBgPosition
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwBgPosition.sql $
  $Author: Mmarghitola $
  $Modtime: 19.08.10 16:44 $
  $Revision: 9 (Version 10 wurde rollbacked)
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwBgPosition.sql $
 * 
 * 7     19.08.10 16:45 Mmarghitola
 * Anpassen line-endings
 * 
 * 6     19.08.10 9:42 Mmarghitola
 * fehlendes Komma ergänzt
 * 
 * 5     19.08.10 9:40 Mmarghitola
 * falsche Spalten entfernt.
 * 
 * 4     18.08.10 14:55 Mmarghitola
 * Sternchen in View aufgrund von Risiken (Schemaänderungen in zu Grunde
 * liegender Tabelle führen zu inkonsistenter Ansicht) entfernt
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:02 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE VIEW [dbo].[vwBgPosition]
AS
  SELECT
    BPO.[BgPositionID],
    BPO.[BgBudgetID],
    BPO.[BgKategorieCode],
    BPO.[DatumVon],
    BPO.[DatumBis],
    BPO.[BgPositionID_CopyOf],
    BPO.[BgPositionID_Parent],
    BPO.[BaPersonID],
    BPO.[BaInstitutionID],
    BPO.[DebitorBaPersonID],
    BPO.[BgPositionsartID],
    BPO.[Buchungstext],
    BPO.[Betrag],
    BPO.[Reduktion],
    BPO.[Abzug],
    BPO.[MaxBeitragSD],
    BPO.[BgSpezkontoID],
    BPO.[Bemerkung],
    BPO.[VerwPeriodeVon],
    BPO.[VerwPeriodeBis],
    BPO.[FaelligAm],
    BPO.[RechnungDatum],
    BPO.[BetragAnfrage],
    BPO.[VerwaltungSD],
    BPO.[BgBewilligungStatusCode],
    BPO.[BewilligtVon],
    BPO.[BewilligtBis],
    BPO.[BewilligtBetrag],
    BPO.[FPPosition],
    BPO.[Value1],
    BPO.[Value2],
    BPO.[Value3],
    BPO.[BetragGBLAufAusgabekonto],
    BPO.[ErstelltUserID],
    BPO.[ErstelltDatum],
    BPO.[MutiertUserID],
    BPO.[MutiertDatum],
    BPO.[BgPositionTS],
    BPO.[Hidden],
    BPO.[BgPositionID_AutoForderung],
    BPO.[Rechnungsnummer],
    BetragFinanzplan = CASE
      WHEN BPO.BgPositionsartID BETWEEN 39100 AND 39199
        AND BPO.BgPositionsartID != SPT.BgGruppeCode THEN CONVERT(money, dbo.fnMIN(BPO.MaxBeitragSD, dbo.fnMIN(BPO.Betrag - BPO.Reduktion - BPO.Abzug,   -- EFB <= Erwerbseinkommen
                                                              (SELECT IsNull(SUM(CONVERT(money, dbo.fnMIN(MaxBeitragSD, Betrag - Reduktion - Abzug))), $0.00)
                                                               FROM dbo.BgPosition SBPO WITH (READUNCOMMITTED)
                                                                 INNER JOIN dbo.BgPositionsart  SBPT WITH (READUNCOMMITTED) ON SBPT.BgPositionsartID = SBPO.BgPositionsartID
                                                               WHERE SBPO.BgBudgetID = BPO.BgBudgetID AND SBPO.BaPersonID = BPO.BaPersonID AND SBPT.BgGruppeCode = 3101
                                                                 AND GetDate() BETWEEN IsNull(DatumVon, '19000101') AND IsNull(DatumBis, '99991231') ))))
      WHEN BPO.BgPositionsartID = 60901                   THEN BPO.Betrag -- Asyl-Nettolohn: Quellsteuer nicht abziehen
      ELSE CONVERT(money, dbo.fnMIN(BPO.MaxBeitragSD, BPO.Betrag - BPO.Reduktion - BPO.Abzug))
    END,
    BetragBudget = CASE
      WHEN BPO.BgPositionsartID IN (32011, 32015, 32016, 32017, 32018, 32019,3102)
                                                          THEN CONVERT(money, dbo.fnMIN(BPO.MaxBeitragSD, BPO.Betrag - BPO.Reduktion - BPO.Abzug - IsNull(
                                                              (SELECT SUM(Betrag - Reduktion)    -- Abzug VVG wenn nicht von SD übernommen
                                                               FROM dbo.BgPosition WITH (READUNCOMMITTED)
                                                               WHERE BgBudgetID = BPO.BgBudgetID AND BgPositionsartID IN (32021, 32022) AND MaxBeitragSD = $0.00
                                                                 AND CASE WHEN BBG.MasterBudget = 1 THEN GetDate() ELSE dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 15) END BETWEEN IsNull(DatumVon, '19000101') AND IsNull(DatumBis, '99991231') )
                                                             , $0.00)))
      WHEN BPO.BgPositionsartID IN (32021, 32022)         THEN BPO.Betrag - BPO.Reduktion - BPO.Abzug   -- VVG
      WHEN BPO.BgPositionsartID = 60901                   THEN BPO.Betrag -- Asyl-Nettolohn: Quellsteuer nicht abziehen
      WHEN BPO.BgPositionsartID BETWEEN 39100 AND 39199
        AND BPO.BgPositionsartID != SPT.BgGruppeCode THEN CONVERT(money, dbo.fnMIN(BPO.MaxBeitragSD, dbo.fnMIN(BPO.Betrag - BPO.Reduktion - BPO.Abzug,  -- EFB <= Erwerbseinkommen
                                                              (SELECT IsNull(SUM(CONVERT(money, dbo.fnMIN(MaxBeitragSD, Betrag - Reduktion - Abzug))), $0.00)
                                                               FROM dbo.BgPosition SBPO WITH (READUNCOMMITTED)
                                                                 INNER JOIN dbo.BgPositionsart  SBPT WITH (READUNCOMMITTED) ON SBPT.BgPositionsartID = SBPO.BgPositionsartID
                                                               WHERE SBPO.BgBudgetID = BPO.BgBudgetID AND SBPO.BaPersonID = BPO.BaPersonID AND SBPT.BgGruppeCode = 3101
                                                                 AND CASE WHEN BBG.MasterBudget = 1 THEN GetDate() ELSE dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 15) END BETWEEN IsNull(DatumVon, '19000101') AND IsNull(DatumBis, '99991231') ))))
      ELSE CONVERT(money, dbo.fnMIN(BPO.MaxBeitragSD, BPO.Betrag - BPO.Reduktion - BPO.Abzug))
    END,
    BetragRechnung = CASE
      WHEN BPO.BgPositionsartID IN (32011, 32015, 32016, 32017, 32018, 32019,3102)
                                                          THEN CONVERT(money, dbo.fnMIN(BPO.MaxBeitragSD, BPO.Betrag - BPO.Reduktion - IsNull(
                                                              (SELECT SUM(Betrag - Reduktion)    -- Abzug VVG wenn nicht von SD übernommen
                                                               FROM dbo.BgPosition WITH (READUNCOMMITTED)
                                                               WHERE BgBudgetID = BPO.BgBudgetID AND BgPositionsartID IN (32021, 32022) AND MaxBeitragSD = $0.00
                                                                 AND CASE WHEN BBG.MasterBudget = 1 THEN GetDate() ELSE dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 15) END BETWEEN IsNull(DatumVon, '19000101') AND IsNull(DatumBis, '99991231') )
                                                             , $0.00)))
      WHEN BPO.BgPositionsartID BETWEEN 39100 AND 39199
        AND BPO.BgPositionsartID != SPT.BgGruppeCode THEN CONVERT(money, dbo.fnMIN(BPO.Betrag - BPO.Reduktion,   -- EFB <= Erwerbseinkommen
                                                              (SELECT IsNull(SUM(Betrag - Reduktion), $0.00)
                                                               FROM dbo.BgPosition             SBPO WITH (READUNCOMMITTED)
                                                                 INNER JOIN dbo.BgPositionsart  SBPT WITH (READUNCOMMITTED) ON SBPT.BgPositionsartID = SBPO.BgPositionsartID
                                                               WHERE SBPO.BgBudgetID = BPO.BgBudgetID AND SBPO.BaPersonID = BPO.BaPersonID AND SBPT.BgGruppeCode = 3101
                                                                 AND CASE WHEN BBG.MasterBudget = 1 THEN GetDate() ELSE dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 15) END BETWEEN IsNull(DatumVon, '19000101') AND IsNull(DatumBis, '99991231') )))
      WHEN BPO.BgPositionsartID IN (32021, 32022)         THEN BPO.Betrag - BPO.Reduktion - BPO.Abzug   -- VVG
      WHEN BPO.BgPositionsartID = 60901                   THEN BPO.Betrag -- Asyl-Nettolohn: Quellsteuer nicht abziehen
      ELSE BPO.Betrag - BPO.Reduktion
    END
  FROM dbo.BgPosition BPO WITH (READUNCOMMITTED)
    INNER JOIN dbo.BgBudget       BBG WITH (READUNCOMMITTED) ON BBG.BgBudgetID = BPO.BgBudgetID
    LEFT OUTER JOIN dbo.BgPositionsart  SPT WITH (READUNCOMMITTED) ON SPT.BgPositionsartID = BPO.BgPositionsartID

GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
GRANT  SELECT  ON [dbo].[vwBgPosition]  TO [tools_access]
GO
