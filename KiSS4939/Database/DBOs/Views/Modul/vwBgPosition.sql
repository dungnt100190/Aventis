SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwBgPosition
GO
/*===============================================================================================
  $Revision: 12 $
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
=================================================================================================*/

CREATE VIEW dbo.vwBgPosition
AS

--set rowcount 1000
SELECT
  BPO.BgPositionID,
  BPO.BgPositionID_Parent,
  BPO.BgPositionID_CopyOf,
  BPO.BgBudgetID,
  BPO.BaPersonID,
  BPO.BgKategorieCode,
  BPO.BgPositionsartID,
  BPO.ShBelegID,
  BPO.Betrag,
  BPO.Reduktion,
  BPO.Abzug,
  BPO.BetragEff,
  BPO.MaxBeitragSD,
  BPO.Buchungstext,
  BPO.BgSpezkontoID,
  BPO.VerwaltungSD,
  BPO.Bemerkung,
  BPO.DatumVon,
  BPO.DatumBis,
  BPO.BaInstitutionID,
  BPO.DebitorBaPersonID,
  BPO.VerwPeriodeVon,
  BPO.VerwPeriodeBis,
  BPO.FaelligAm,
  BPO.RechnungDatum,
  BPO.BgBewilligungStatusCode,
  BPO.Value1,
  BPO.Value2,
  BPO.Value3,
  BPO.ErstelltUserID,
  BPO.ErstelltDatum,
  BPO.MutiertUserID,
  BPO.MutiertDatum,
  BPO.BgPositionTS,
  BPO.BgPositionID_AutoForderung,
  BetragFinanzplan = CASE
                       WHEN SPT.BgPositionsartCode BETWEEN 39100 AND 39199 --EFB
                            AND SPT.BgPositionsartCode != SPT.BgGruppeCode 
                            AND BPO.BgKategorieCode = 2 --nur bei der Ausgabeposition soll mit Einkommen verglichen werden
                         THEN CONVERT(MONEY, 
                                      dbo.fnMIN(BPO.MaxBeitragSD, dbo.fnMIN(BPO.Betrag - BPO.Reduktion - BPO.Abzug,   -- EFB <= Erwerbseinkommen
                                                (SELECT ISNULL(SUM(CONVERT(MONEY, dbo.fnMIN(MaxBeitragSD, Betrag - Reduktion - Abzug))), $0.00)
                                                 FROM dbo.BgPosition              SBPO WITH (READUNCOMMITTED)
                                                   INNER JOIN dbo.BgPositionsart  SBPT WITH (READUNCOMMITTED) ON SBPT.BgPositionsartID = SBPO.BgPositionsartID
                                                 WHERE SBPO.BgBudgetID = BPO.BgBudgetID 
                                                   AND SBPO.BaPersonID = BPO.BaPersonID 
                                                   AND SBPT.BgGruppeCode = 3101
                                                   AND GETDATE() BETWEEN ISNULL(SBPO.DatumVon, '19000101') AND ISNULL(SBPO.DatumBis, '99991231') )
                                               )) -- fnMIN, SELECT
                                     ) -- CONVERT
                       WHEN SPT.BgPositionsartCode = 60901
                         THEN BPO.Betrag -- Asyl-Nettolohn: Quellsteuer nicht abziehen
                       ELSE CONVERT(MONEY, dbo.fnMIN(BPO.MaxBeitragSD, BPO.Betrag - BPO.Reduktion - BPO.Abzug))
                     END,
  BetragBudget     = CASE
                       WHEN SPT.BgPositionsartCode IN (32011, 32015, 32016, 32017, 32018, 32019)
                         THEN CONVERT(MONEY, 
                                      dbo.fnMIN(BPO.MaxBeitragSD, BPO.Betrag - BPO.Reduktion - BPO.Abzug -
                                                ISNULL((SELECT SUM(SBPO.Betrag - SBPO.Reduktion)    -- Abzug VVG wenn nicht von SD übernommen
                                                        FROM dbo.BgPosition             SBPO WITH (READUNCOMMITTED)
                                                          INNER JOIN dbo.BgPositionsart SBPT WITH (READUNCOMMITTED) ON SBPT.BgPositionsartID = SBPO.BgPositionsartID
                                                        WHERE SBPO.BgBudgetID = BPO.BgBudgetID 
                                                          AND SBPT.BgPositionsartCode IN (32021, 32022, 32023) 
                                                          AND SBPO.MaxBeitragSD = $0.00
                                                          AND CASE 
                                                                WHEN BBG.MasterBudget = 1 THEN GETDATE() 
                                                                ELSE dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 15) 
                                                              END BETWEEN ISNULL(SBPO.DatumVon, '19000101') AND ISNULL(SBPO.DatumBis, '99991231')
                                                       ), $0.00) -- SELECT, ISNULL
                                               ) -- fnMIN, 
                                     ) -- CONVERT
                       WHEN SPT.BgPositionsartCode IN (32021, 32022, 32023)
                         THEN BPO.Betrag - BPO.Reduktion - BPO.Abzug   -- VVG / KVG über Limit
                       WHEN SPT.BgPositionsartCode = 60901
                         THEN BPO.Betrag -- Asyl-Nettolohn: Quellsteuer nicht abziehen
                       WHEN SPT.BgPositionsartCode BETWEEN 39100 AND 39199 --EFB
                            AND SPT.BgPositionsartCode != SPT.BgGruppeCode 
                            AND BPO.BgKategorieCode = 2 --nur bei der Ausgabeposition soll mit Einkommen verglichen werden
                         THEN CONVERT(MONEY, 
                                      dbo.fnMIN(BPO.MaxBeitragSD, dbo.fnMIN(BPO.Betrag - BPO.Reduktion - BPO.Abzug,  -- EFB <= Erwerbseinkommen
                                                (SELECT ISNULL(SUM(CONVERT(MONEY, dbo.fnMIN(MaxBeitragSD, Betrag - Reduktion - Abzug))), $0.00)
                                                 FROM dbo.BgPosition              SBPO WITH (READUNCOMMITTED)
                                                   INNER JOIN dbo.BgPositionsart  SBPT WITH (READUNCOMMITTED) ON SBPT.BgPositionsartID = SBPO.BgPositionsartID
                                                 WHERE SBPO.BgBudgetID = BPO.BgBudgetID 
                                                   AND SBPO.BaPersonID = BPO.BaPersonID 
                                                   AND SBPT.BgGruppeCode = 3101
                                                   AND CASE 
                                                         WHEN BBG.MasterBudget = 1 THEN GETDATE()
                                                         ELSE dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 15)
                                                       END BETWEEN ISNULL(SBPO.DatumVon, '19000101') AND ISNULL(SBPO.DatumBis, '99991231') )
                                               )) -- fnMIN, SELECT
                                     ) -- CONVERT
                       ELSE CONVERT(MONEY, dbo.fnMIN(BPO.MaxBeitragSD, BPO.Betrag - BPO.Reduktion - BPO.Abzug))
                     END,
  BetragRechnung   = CASE
                       WHEN SPT.BgPositionsartCode IN (32011, 32015, 32016, 32017, 32018, 32019)
                         THEN CONVERT(MONEY, 
                                      dbo.fnMIN(BPO.MaxBeitragSD, BPO.Betrag - BPO.Reduktion - 
                                                ISNULL((SELECT SUM(SBPO.Betrag - SBPO.Reduktion)    -- Abzug VVG wenn nicht von SD übernommen
                                                        FROM dbo.BgPosition             SBPO WITH (READUNCOMMITTED)
                                                          INNER JOIN dbo.BgPositionsart SBPT WITH (READUNCOMMITTED) ON SBPT.BgPositionsartID = SBPO.BgPositionsartID
                                                        WHERE SBPO.BgBudgetID = BPO.BgBudgetID 
                                                         AND SBPT.BgPositionsartCode IN (32021, 32022, 32023) 
                                                         AND SBPO.MaxBeitragSD = $0.00
                                                         AND CASE 
                                                               WHEN BBG.MasterBudget = 1 THEN GETDATE() 
                                                               ELSE dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 15) 
                                                             END BETWEEN ISNULL(SBPO.DatumVon, '19000101') AND ISNULL(SBPO.DatumBis, '99991231')
                                                       ), $0.00) -- IsNULL,, SELECT
                                               ) -- fnMIN
                                     ) -- CONVERT
                       WHEN SPT.BgPositionsartCode BETWEEN 39100 AND 39199 --EFB
                            AND SPT.BgPositionsartCode != SPT.BgGruppeCode 
                            AND BPO.BgKategorieCode = 2 --nur bei der Ausgabeposition soll mit Einkommen verglichen werden
                         THEN CONVERT(MONEY, 
                                      dbo.fnMIN(BPO.Betrag - BPO.Reduktion,   -- EFB <= Erwerbseinkommen
                                                (SELECT ISNULL(SUM(Betrag - Reduktion), $0.00)
                                                 FROM dbo.BgPosition              SBPO WITH (READUNCOMMITTED)
                                                   INNER JOIN dbo.BgPositionsart  SBPT WITH (READUNCOMMITTED) ON SBPT.BgPositionsartID = SBPO.BgPositionsartID
                                                 WHERE SBPO.BgBudgetID = BPO.BgBudgetID 
                                                   AND SBPO.BaPersonID = BPO.BaPersonID 
                                                   AND SBPT.BgGruppeCode = 3101
                                                   AND CASE 
                                                         WHEN BBG.MasterBudget = 1 THEN GETDATE() 
                                                         ELSE dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 15) 
                                                       END BETWEEN ISNULL(SBPO.DatumVon, '19000101') AND ISNULL(SBPO.DatumBis, '99991231')
                                               )) -- fnMIN, SELECT
                                     ) -- CONVERT
                       WHEN SPT.BgPositionsartCode IN (32021, 32022, 32023)
                         THEN BPO.Betrag - BPO.Reduktion - BPO.Abzug   -- VVG
                       WHEN SPT.BgPositionsartCode = 60901
                         THEN BPO.Betrag -- Asyl-Nettolohn: Quellsteuer nicht abziehen
                       ELSE BPO.Betrag - BPO.Reduktion
                     END

FROM dbo.BgPosition              BPO WITH (READUNCOMMITTED)
  INNER JOIN dbo.BgBudget        BBG WITH (READUNCOMMITTED) ON BBG.BgBudgetID = BPO.BgBudgetID
  LEFT  JOIN dbo.BgPositionsart  SPT WITH (READUNCOMMITTED) ON SPT.BgPositionsartID = BPO.BgPositionsartID

GO
