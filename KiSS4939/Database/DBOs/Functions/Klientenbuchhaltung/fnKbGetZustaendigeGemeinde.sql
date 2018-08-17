SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnKbGetZustaendigeGemeinde;
GO
/*===============================================================================================
  $Revision: 4$
=================================================================================================
  SUMMARY: Gibt die zuständige Gemeinde einer Buchung. Neu haben auch Manuell erfasste Buchungen 
           eine zuständige Gemeinde. Heuristik:
           Buchung mit Kostenart auf Konto 680/682 oder 780/782 --> GemeindeCode der Inkasso-Leistung
           sonst:
           GemeindeCode der am Beleg-Datum aktiven SH-Leistung
  PARAMS:
    @KbBuchungKostenartID: ID der Kostenart-Buchung
  -
  RETURNS: GemeindeCode der zuständige Gemeinde
  -
  TEST:    SELECT dbo.fnKbGetZustaendigeGemeinde(1);
=================================================================================================*/

CREATE FUNCTION dbo.fnKbGetZustaendigeGemeinde
(
  @KbBuchungKostenartID INT
)
RETURNS INT
AS BEGIN

  DECLARE @InkassoKonti    VARCHAR(200);
  DECLARE @GemeindeCode INT;
  DECLARE @NbrGemeindeSozialdienst INT;
  
  --perform expensive calculations only if we have to (if multiple GemeindeCodes are possible)
  SELECT @NbrGemeindeSozialdienst = COUNT(Code)
  FROM XLOVCode
  WHERE LOVName='GemeindeSozialdienst';
  
  IF @NbrGemeindeSozialdienst = 1
  BEGIN
    SELECT @GemeindeCode = Code
    FROM XLOVCode
    WHERE LOVName='GemeindeSozialdienst'
  
    RETURN @GemeindeCode;
  END;  

  -- KontoNr holen, um Inkasso-betreffende ManuelleBuchungen zu erkennen
  SELECT @InkassoKonti = ';' + CONVERT(VARCHAR(200), dbo.fnXConfig('System\KliBu\Sozialhilferechnung\InkassoKonti', GETDATE())) + ';'

  -----------------------------------------------------------------------------
  -- Zuständige Gemeinde suchen
  -----------------------------------------------------------------------------
 SELECT @GemeindeCode = CASE 
                          -- Budget
                          WHEN BUC.KbBuchungTypCode = 1 THEN (SELECT TOP 1 LEI.GemeindeCode
                                                               FROM FaLeistung           LEI
                                                                 INNER JOIN BgFinanzplan FPL ON FPL.FaLeistungID = LEI.FaLeistungID
                                                                 INNER JOIN BgBudget     BDG ON BDG.BgFinanzplanID = FPL.BgFinanzplanID
                                                               WHERE BDG.BgBudgetID = BUC.BgBudgetID)
                          -- Manuelle Buchungen + Umbuchungen
                          WHEN BUC.KbBuchungTypCode IN (2, 5) THEN (
                            /* Suche GemeindeCode in der Inkasso-Leistung wenn die gebuchte Kostenart auf eines der folgenden Konti bucht:
                             * 680/780: Alimentenbevorschussung
                             * 682/782: Inkassokosten Alimentenbevorschussung
                             * sonst:
                             * Suche GemeindeCode am Belegdatum gültigen SH-Leistung
                             */
                            SELECT TOP 1 GemeindeCode
                            FROM
                            (
                              -- Inkasso
                              SELECT LEI.GemeindeCode
                              FROM dbo.KbBuchungKostenart   BKOI WITH (READUNCOMMITTED) 
                                LEFT JOIN dbo.IkGlaeubiger  GLA WITH (READUNCOMMITTED) ON GLA.BaPersonID = BKOI.BaPersonID            -- person is glaeubiger
                                LEFT JOIN dbo.IkRechtstitel RTI WITH (READUNCOMMITTED) ON RTI.IkRechtstitelID = GLA.IkRechtstitelID
                                LEFT JOIN dbo.FaLeistung    LEI WITH (READUNCOMMITTED) ON LEI.SchuldnerBaPersonID = BKOI.BaPersonID   -- person is schuldner
                                              OR LEI.FaLeistungID = RTI.FaLeistungID --take the Leistung if the Person Is Glaeubiger
                                              OR (LEI.BaPersonID = BKOI.BaPersonID AND LEI.ModulID = 2) --take the Fallfuehrung of the Schuldner
                                              OR (LEI.BaPersonID = GLA.BaPersonID AND LEI.ModulID = 2) --take the Fallfuehrung of the Glaeubiger
                              WHERE BKOI.KbBuchungKostenartID = BKO.KbBuchungKostenartID
                                AND @InkassoKonti LIKE ';%' + BKOI.KontoNr + '%;'
                                AND LEI.GemeindeCode IS NOT NULL
                                AND LEI.DatumVon <= BUC.BelegDatum
                                AND ISNULL(LEI.DatumBis, '99991231') >= BUC.BelegDatum
                              UNION
                              -- fallback: Letzte Leistung ohne Datum-Berücksichtigung
                              SELECT GemeindeCode
                              FROM (SELECT TOP 1 LEI.GemeindeCode 
                                    FROM dbo.KbBuchungKostenart   BKOI WITH (READUNCOMMITTED) 
                                      LEFT JOIN dbo.IkGlaeubiger  GLA WITH (READUNCOMMITTED) ON GLA.BaPersonID = BKOI.BaPersonID            -- person is glaeubiger
                                      LEFT JOIN dbo.IkRechtstitel RTI WITH (READUNCOMMITTED) ON RTI.IkRechtstitelID = GLA.IkRechtstitelID
                                      LEFT JOIN dbo.FaLeistung    LEI WITH (READUNCOMMITTED) ON LEI.SchuldnerBaPersonID = BKOI.BaPersonID   -- person is schuldner
                                                    OR LEI.FaLeistungID = RTI.FaLeistungID --take the Leistung if the Person Is Glaeubiger
                                                    OR (LEI.BaPersonID = BKOI.BaPersonID AND LEI.ModulID = 2) --take the Fallfuehrung of the Schuldner
                                                    OR (LEI.BaPersonID = GLA.BaPersonID AND LEI.ModulID = 2) --take the Fallfuehrung of the Glaeubiger
                                    WHERE BKOI.KbBuchungKostenartID = BKO.KbBuchungKostenartID
                                      AND @InkassoKonti LIKE ';%' + BKOI.KontoNr + '%;'
                                      AND LEI.GemeindeCode IS NOT NULL
                                    ORDER BY LEI.DatumVon DESC
                              ) TMP1
                              UNION                            
                              -- SH (Budget)
                              SELECT LEI.GemeindeCode
                              FROM FaLeistung           LEI
                                INNER JOIN BgFinanzplan FPL ON FPL.FaLeistungID = LEI.FaLeistungID
                                INNER JOIN BgBudget     BDG ON BDG.BgFinanzplanID = FPL.BgFinanzplanID
                              WHERE BDG.BgBudgetID = BUC.BgBudgetID
                              UNION
                              -- SH (Person)
                              SELECT LEI.GemeindeCode
                              FROM dbo.FaLeistung                     LEI WITH (READUNCOMMITTED) 
                                INNER JOIN dbo.BgFinanzplan           FPL WITH (READUNCOMMITTED) ON FPL.FaLeistungID = LEI.FaLeistungID
                                INNER JOIN dbo.BgFinanzplan_BaPerson  FPP WITH (READUNCOMMITTED) ON FPP.BgFinanzplanID = FPL.BgFinanzplanID
                              WHERE 
                                (BUC.ValutaDatum BETWEEN ISNULL(FPL.DatumVon, FPL.GeplantVon) AND ISNULL(FPL.DatumBis, FPL.GeplantBis)
                                  OR BUC.BelegDatum BETWEEN ISNULL(FPL.DatumVon, FPL.GeplantVon) AND ISNULL(FPL.DatumBis, FPL.GeplantBis)
                                  OR (BKO.VerwPeriodeBis >= FPL.DatumVon AND BKO.VerwPeriodeVon <= FPL.DatumBis)
                                )
                                AND BKO.BaPersonID = FPP.BaPersonID
                              UNION
                              -- Fallback: Letzte SH-Leistung ohne Datumsberücksichtigung
                              SELECT GemeindeCode
                              FROM (
                                SELECT TOP 1 LEI.GemeindeCode
                                FROM dbo.FaLeistung                     LEI WITH (READUNCOMMITTED) 
                                  INNER JOIN dbo.BgFinanzplan           FPL WITH (READUNCOMMITTED) ON FPL.FaLeistungID = LEI.FaLeistungID
                                  INNER JOIN dbo.BgFinanzplan_BaPerson  FPP WITH (READUNCOMMITTED) ON FPP.BgFinanzplanID = FPL.BgFinanzplanID
                                WHERE 
                                  BKO.BaPersonID = FPP.BaPersonID
                                ORDER BY LEI.DatumVon DESC
                              )TMP2
                            )TMP
                          )                          
                          -- Inkasso
                          WHEN BUC.KbBuchungTypCode = 3 THEN (
                            SELECT TOP 1 GemeindeCode
                            FROM (
                              SELECT LEI.GemeindeCode
                              FROM FaLeistung LEI
                              WHERE LEI.FaLeistungID = BUC.FaLeistungID
                                AND LEI.GemeindeCode IS NOT NULL
                              UNION
                              SELECT GemeindeCode
                              FROM (SELECT TOP 1 LEI1.GemeindeCode
                                    FROM FaLeistung LEI
                                      LEFT JOIN FaLeistung LEI1 ON LEI1.BaPersonID = LEI.BaPersonID AND LEI1.ModulID = 2
                                    WHERE LEI.FaLeistungID = BUC.FaLeistungID
                                      AND LEI1.GemeindeCode IS NOT NULL
                                    ORDER BY LEI1.DatumVon DESC
                                   ) TMP1
                            )TMP
                          )
                          -- Ausgleich
                          WHEN BUC.KbBuchungTypCode = 4 THEN dbo.fnKbGetZustaendigeGemeinde((SELECT TOP 1 BKO.KbBuchungKostenartID
                                                                                             FROM KbOpAusgleich OPA
                                                                                               INNER JOIN KbBuchungKostenart BKO ON BKO.KbBuchungID = OPA.OpBuchungID
                                                                                             WHERE OPA.AusgleichBuchungID = BUC.KbBuchungID))
                          ELSE NULL
                        END
  FROM KbBuchungKostenart BKO
    INNER JOIN KbBuchung  BUC ON BUC.KbBuchungID = BKO.KbBuchungID
  WHERE KbBuchungKostenartID = @KbBuchungKostenartID

  --Fallback: Wenn das vorherige Statement keinen GemeindeCode liefert (<Ironie>das kann ja gar nicht sein!</Ironie>),
  --          ZuständigeGemeinde aus Fallführung nehmen
  IF(@GemeindeCode IS NULL)
  BEGIN
    SELECT TOP 1 @GemeindeCode = COALESCE(LEI1.GemeindeCode, LEI2.GemeindeCode, LEI3.GemeindeCode)
    FROM KbBuchungKostenart BKO 
      INNER JOIN KbBuchung        BUC ON BUC.KbBuchungID = BKO.KbBuchungID
      INNER JOIN KbKostenstelle_BaPerson  KST WITH(READUNCOMMITTED) ON KST.KbKostenstelleID = BKO.KbKostenstelleID
                                                                   AND (KST.DatumBis IS NULL OR GETDATE() BETWEEN KST.DatumVon AND KST.DatumBis)  --Datumsvergleich analog zu spKbSozialhilferechnungDifferenziert, wo diese Funktion verwendet wird!
      INNER JOIN FaFallPerson     FAL ON FAL.BaPersonID = KST.BaPersonID

      OUTER APPLY (SELECT TOP 1 TMP.BaPersonID, TMP.GemeindeCode, TMP.FaLeistungID
                   FROM FaLeistung TMP
                   WHERE TMP.FaFallID = FAL.FaFallID
                     AND TMP.ModulID = 2 --2: Fallführung
                     AND TMP.GemeindeCode IS NOT NULL
                     AND BUC.BelegDatum BETWEEN TMP.DatumVon AND ISNULL(TMP.DatumBis, '99991231')
                   ) LEI1

      OUTER APPLY (SELECT TOP 1 TMP.BaPersonID, TMP.GemeindeCode, TMP.FaLeistungID
                   FROM FaLeistung TMP
                   WHERE TMP.FaFallID = FAL.FaFallID
                     AND TMP.ModulID = 2 --2: Fallführung
                     AND TMP.GemeindeCode IS NOT NULL
                     AND BUC.BelegDatum < TMP.DatumVon 
                   ORDER BY DatumVon ASC
                   ) LEI2

      OUTER APPLY (SELECT TOP 1 TMP.BaPersonID, TMP.GemeindeCode, TMP.FaLeistungID
                   FROM FaLeistung TMP
                   WHERE TMP.FaFallID = FAL.FaFallID
                     AND TMP.ModulID = 2 --2: Fallführung
                     AND TMP.GemeindeCode IS NOT NULL
                     AND BUC.BelegDatum > ISNULL(TMP.DatumBis, '99991231')
                   ORDER BY DatumVon DESC
                   ) LEI3
    WHERE BKO.KbBuchungKostenartID = @KbBuchungKostenartID
      AND (KST.DatumBis IS NULL OR GETDATE() BETWEEN KST.DatumVon AND KST.DatumBis)  --Datumsvergleich analog zu spKbSozialhilferechnungDifferenziert, wo diese Funktion verwendet wird!
    ORDER BY CASE WHEN COALESCE(LEI1.BaPersonID, LEI2.BaPersonID, LEI3.BaPersonID) = KST.BaPersonID THEN 1 --person ist fallträger
                  ELSE 2
             END;
  END;

  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN @GemeindeCode;
END;
GO
