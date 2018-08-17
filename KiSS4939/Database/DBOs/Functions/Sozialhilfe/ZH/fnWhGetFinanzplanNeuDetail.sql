SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnWhGetFinanzplanNeuDetail
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE FUNCTION dbo.fnWhGetFinanzplanNeuDetail
(
  @BgBudgetID int, 
  @Monat varchar(50)
)
RETURNS @OUTPUT TABLE (Rec_ID int, Parent_ID int, SortKey int IDENTITY(1, 1) PRIMARY KEY, Style int, BgKategorieCode int, BgGruppeCode int, Bezeichnung varchar(500), an varchar(3), Betrag money, Total money, LA varchar(10), LAName varchar(100), UeEinheit varchar(100))
AS
BEGIN
  -- Positionsarten, welche in der Übersicht kommen sollen festlegen
  DECLARE @WhPositionsart TABLE (BgPositionsartID int PRIMARY KEY, BgKategorieCode int, BgGruppeCode int, BgGruppeCode2 int)
  INSERT INTO @WhPositionsart
  SELECT BgPositionsartID, BgKategorieCode, BgGruppeCode, CASE WHEN BgGruppeCode BETWEEN 39000 AND 39999 THEN 39000 ELSE BgGruppeCode END
  FROM dbo.WhPositionsart
  WHERE BgKategorieCode IN (1, 2, 4)
  --select * from @WhPositionsart  
  

  -- Neuen Kategoriecode für "EVB und Zulagen" bestimmen als Maximum von BgKategorie plus eins
  DECLARE @KategorieCodeEFBZ int 
  SELECT @KategorieCodeEFBZ = (MAX(Code) + 1) FROM XLOVCode WHERE LOVName like 'BgKategorie'
  
  -- BgGruppeCode2 = 39000 in eine eigene Kategorie (nur wenn nicht Sanktionen)
  UPDATE @WhPositionsart
  SET BgKategorieCode = @KategorieCodeEFBZ 
  WHERE BgGruppeCode2 = 39000 AND BgKategorieCode <> 4
  --select * from @WhPositionsart  


  -- BgPositionen abfüllen
  DECLARE @Budget TABLE (PKey int IDENTITY(1, 1) PRIMARY KEY, Rec_ID int, Parent_ID int, SortKey int, Style int, BgKategorieCode int, BgGruppeCode int, Bezeichnung varchar(500), an varchar(3), Betrag money, Total money, LA varchar(10), LAName varchar(100), UeEinheit varchar(100))
  INSERT INTO @Budget (Style, Parent_ID, BgKategorieCode, BgGruppeCode, Bezeichnung, an, Betrag, SortKey, LA, LAName, UeEinheit)
	SELECT 10, BPA.BgKategorieCode, BPA.BgKategorieCode, BPA.BgGruppeCode2, BGG.Text, 
          CASE -- Spalte "an" (SOD = Verwaltung Sozialdienst, D = Dritte, KL = Klient, UE = Unterstützungseinheit
             WHEN BPO.VerwaltungSD = 1 THEN 'SOD' -- Verwaltung Sozialdienst
             WHEN KRE.BaZahlungswegID IS NOT NULL AND KRE.BaPersonID IS NULL THEN 'D' -- Dritte
             WHEN 1 = (SELECT BGKOA.Quoting
                       FROM dbo.BgBudget                        BBG2 WITH (READUNCOMMITTED) 
                            INNER JOIN dbo.BgPosition BPOS2 WITH (READUNCOMMITTED) on BPOS2.BgBudgetID = BBG2.BgBudgetID AND BPOS2.BgPositionID = BPO.BgPositionID
                            INNER JOIN dbo.BgPositionsart BPOA2 WITH (READUNCOMMITTED) on BPOA2.BgPositionsartID = BPO.BgPositionsartID
                            INNER JOIN dbo.BgKostenart BGKOA WITH (READUNCOMMITTED) on BGKOA.BgKostenartID = BPOA.BgKostenartID
                        WHERE BBG2.BgBudgetID = @BgBudgetID) THEN 'UE'  -- Falls gequotet dann an UE
             ELSE 'KL'  -- Sonst an Klient
          END, 
          BPO.BetragFinanzplan, BGG.SortKey, BKOA.KontoNr, BKOA.Name,
          CASE -- Spalte an welche Person der Betrag geht (Unterstützungeeinheit oder PRS an welche der Betrag geht)
             WHEN 1 = (SELECT BGKOA.Quoting
                       FROM dbo.BgBudget                        BBG2 WITH (READUNCOMMITTED) 
                            INNER JOIN dbo.BgPosition BPOS2 WITH (READUNCOMMITTED) on BPOS2.BgBudgetID = BBG2.BgBudgetID AND BPOS2.BgPositionID = BPO.BgPositionID
                            INNER JOIN dbo.BgPositionsart BPOA2 WITH (READUNCOMMITTED) on BPOA2.BgPositionsartID = BPO.BgPositionsartID
                            INNER JOIN dbo.BgKostenart BGKOA WITH (READUNCOMMITTED) on BGKOA.BgKostenartID = BPOA.BgKostenartID
                        WHERE BBG2.BgBudgetID = @BgBudgetID) THEN 'Unterstützungseinheit' -- Falls gequotet dann an UE
             ELSE (SELECT CONVERT(varchar,PER.BaPersonID) + ', ' + PER.Name + ' ' + PER.Vorname
                   FROM dbo.BgBudget                        BBG2 WITH (READUNCOMMITTED) 
		                INNER JOIN dbo.BgPosition BPOS2 WITH (READUNCOMMITTED) on BPOS2.BgBudgetID = BBG2.BgBudgetID AND BPOS2.BgPositionID = BPO.BgPositionID
		                INNER JOIN dbo.BgPositionsart BPOA2 WITH (READUNCOMMITTED) on BPOA2.BgPositionsartID = BPO.BgPositionsartID
		                INNER JOIN dbo.BgKostenart BGKOA WITH (READUNCOMMITTED) on BGKOA.BgKostenartID = BPOA.BgKostenartID
		                INNER JOIN dbo.BaPerson PER WITH (READUNCOMMITTED) on PER.BaPersonID = BPOS2.BaPersonID
		           WHERE BBG2.BgBudgetID = @BgBudgetID) -- Sonst PersNr, Vorname, Name an wen es geht
          END
	FROM @WhPositionsart       BPA
	  INNER JOIN dbo.BgBudget      BBG WITH (READUNCOMMITTED) ON BBG.BgBudgetID = @BgBudgetID
      INNER JOIN dbo.BgFinanzplan  FPL WITH (READUNCOMMITTED) ON FPL.BgFinanzplanID = BBG.BgFinanzplanID
      INNER JOIN dbo.FaLeistung    LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = FPL.FaLeistungID
	  LEFT  JOIN dbo.XLOVCode      BGG WITH (READUNCOMMITTED) ON BGG.LOVName = 'BgGruppe' AND BGG.Code = BPA.BgGruppeCode2
	  LEFT  JOIN dbo.vwBgPosition  BPO ON BPO.BgPositionsartID = BPA.BgPositionsartID 
                                      AND BPO.BgBudgetID = @BgBudgetID
									  AND (BBG.BgBewilligungStatusCode = 1 OR ISNULL(BPO.FPPosition,0) = 1)
      LEFT  JOIN dbo.BgPositionsart BPOA WITH (READUNCOMMITTED) ON BPOA.BgPositionsartID = BPO.BgPositionsartID
      LEFT  JOIN dbo.BgKostenart    BKOA WITH (READUNCOMMITTED) ON BKOA.BgKostenartID = BPOA.BgKostenartID
      LEFT  JOIN dbo.BgAuszahlungPerson   BAP  WITH (READUNCOMMITTED) ON BAP.BgPositionID = BPO.BgPositionID AND
                                                   BAP.BgAuszahlungPersonID = (SELECT TOP 1 BgAuszahlungPersonID
                                                                               FROM   dbo.BgAuszahlungPerson WITH (READUNCOMMITTED) 
                                                                               WHERE  BgPositionID = BPO.BgPositionID
                                                                               ORDER BY 
                                                                                 CASE WHEN BaPersonID IS NULL THEN 1
                                                                                      WHEN BaPersonID = BPO.BaPersonID THEN 2
                                                                                      WHEN BaPersonID = LEI.BaPersonID THEN 3
                                                                                       ELSE 4
                                                                                 END)
       LEFT  JOIN dbo.vwKreditor          KRE  ON KRE.BaZahlungswegID = BAP.BaZahlungswegID

	WHERE BPA.BgKategorieCode IN (1, 2, @KategorieCodeEFBZ) 
    OR (BPA.BgKategorieCode = 4 AND BPO.BetragFinanzplan > 0)
  --select * from @Budget
  
  -- Für alle Kategorien die Summe bilden
  INSERT INTO @Budget (Rec_ID, Style, BgKategorieCode, Total)
  SELECT BgKategorieCode, 1, BgKategorieCode, SUM(Betrag) 
  FROM @Budget 
  GROUP BY BgKategorieCode

  -- Titel einfügen und sicherstellen, dass mindestens eine Überschrift pro Kategorie besteht
  IF NOT EXISTS(SELECT * FROM @Budget WHERE BgGruppeCode IS NULL AND BgKategorieCode = 2) INSERT INTO @Budget(Rec_ID, Style, BgKategorieCode, Total) VALUES (2, 1, 2, 0) 
  IF NOT EXISTS(SELECT * FROM @Budget WHERE BgGruppeCode IS NULL AND BgKategorieCode = 1) INSERT INTO @Budget(Rec_ID, Style, BgKategorieCode, Total) VALUES (1, 1, 1, 0) 
  IF NOT EXISTS(SELECT * FROM @Budget WHERE BgGruppeCode IS NULL AND BgKategorieCode = @KategorieCodeEFBZ) INSERT INTO @Budget(Rec_ID, Style, BgKategorieCode, Total) VALUES (@KategorieCodeEFBZ, 1, @KategorieCodeEFBZ, 0) 
  IF NOT EXISTS(SELECT * FROM @Budget WHERE BgGruppeCode IS NULL AND BgKategorieCode = 4) INSERT INTO @Budget(Rec_ID, Style, BgKategorieCode, Total) VALUES (4, 1, 4, 0) 
  UPDATE @Budget SET SortKey = 10, Bezeichnung = 'Bedarf' WHERE BgGruppeCode IS NULL AND BgKategorieCode = 2
  UPDATE @Budget SET SortKey = 20, Bezeichnung = 'Einnahmen' WHERE BgGruppeCode IS NULL AND BgKategorieCode = 1
  UPDATE @Budget SET SortKey = 30, Bezeichnung = 'EFB und Zulagen' WHERE BgGruppeCode IS NULL AND BgKategorieCode = @KategorieCodeEFBZ
  UPDATE @Budget SET SortKey = 40, Bezeichnung = 'Verrechnung und Sanktionen' WHERE BgGruppeCode IS NULL AND BgKategorieCode = 4


  -- Output
  INSERT INTO @OUTPUT (Rec_ID, Parent_ID, Style, BgKategorieCode, BgGruppeCode, Bezeichnung, an, Betrag, Total, LA, LAName, UeEinheit)
  SELECT TMP.Rec_ID, 
         TMP.Parent_ID, 
         TMP.Style,
         TMP.BgKategorieCode, 
         TMP.BgGruppeCode,
         Bezeichnung = CASE TMP.Style
                         WHEN 1 THEN ''
                         WHEN 2 THEN '  '
                         ELSE        '    '
                       END + TMP.Bezeichnung,
         TMP.an,
         TMP.Betrag, 
         TMP.Total,
         TMP.LA,
         TMP.LAName,
         TMP.UeEinheit
  FROM @Budget                 TMP
    LEFT JOIN @Budget          SUB ON (SUB.Style IS NULL OR SUB.Style NOT IN (1, 2)) AND (SUB.PKey = TMP.PKey)
    LEFT JOIN @Budget          GRP ON GRP.Style = 2 AND (GRP.PKey = TMP.PKey OR GRP.Rec_ID = TMP.Parent_ID)
    LEFT JOIN @Budget          TIT ON TIT.Style = 1 AND (TIT.PKey = TMP.PKey OR TIT.Rec_ID = GRP.Parent_ID OR TIT.Rec_ID = TMP.Parent_ID)
  WHERE TMP.BgGruppeCode IS NULL OR TMP.BgGruppeCode NOT IN (3901, 3902)
  ORDER BY TIT.SortKey, TIT.PKey,
           GRP.SortKey, GRP.PKey,
           SUB.SortKey, SUB.PKey

  -- Fehlbeträge
  INSERT INTO @OUTPUT (Style, Bezeichnung) 
    VALUES (1, '')
  INSERT INTO @OUTPUT (Style, Bezeichnung) 
    VALUES (1, 'Zusammenfassung')
  INSERT INTO @OUTPUT (Style, Bezeichnung, Betrag)
    SELECT 10, ' Bedarf',
           Betrag = (SELECT Total FROM @Budget WHERE Parent_ID IS NULL AND BgKategorieCode = 2)
  INSERT INTO @OUTPUT (Style, Bezeichnung, Betrag)
    SELECT 10, ' Einnahmen',
           Betrag = (SELECT Total FROM @Budget WHERE Parent_ID IS NULL AND BgKategorieCode = 1)
  INSERT INTO @OUTPUT (Style, Bezeichnung, Betrag)
    SELECT 1, 'Unterstützungsbedarf vor Zulagen und Verrechnungen',
           Betrag = (SELECT SUM(CASE
                                  WHEN BgKategorieCode = 2 THEN Total
                                  WHEN BgKategorieCode = 1 THEN -Total
                                  ELSE $0.00
                                END)
                     FROM @Budget)
  INSERT INTO @OUTPUT (Style, Bezeichnung, Betrag)
    SELECT 10, ' zuzüglich Einkommensfreibetrag und Zulagen',
           Betrag = (SELECT Total FROM @Budget WHERE Parent_ID IS NULL AND BgKategorieCode = @KategorieCodeEFBZ)
  INSERT INTO @OUTPUT (Style, Bezeichnung, Betrag)
    SELECT 10, ' abzüglich Verrechung und Sanktionen',
           Betrag = (SELECT Total FROM @Budget WHERE Parent_ID IS NULL AND BgKategorieCode = 4)
  INSERT INTO @OUTPUT (Style, Bezeichnung, Betrag)
    SELECT 1, 'Total Monat ' + @Monat,
           Betrag = (SELECT SUM(CASE
                                  WHEN BgKategorieCode = 2 THEN Total
                                  WHEN BgKategorieCode = 1 THEN -Total
                                  WHEN BgKategorieCode = @KategorieCodeEFBZ THEN Total
                                  WHEN BgKategorieCode = 4 THEN -Total
                                  ELSE $0.00
                                END)
                     FROM @Budget)


  RETURN
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
