SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnWhGetFinanzplanIndent
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/Sozialhilfe/fnWhGetFinanzplanIndent.sql $
  $Author: Tabegglen $
  $Modtime: 08.10.2014 $
  $Revision: 2 $
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
 */

CREATE FUNCTION dbo.fnWhGetFinanzplanIndent
 (@BgBudgetID      int,
  @GetDate         datetime,
  @Indent          bit)
RETURNS
  @OUTPUT TABLE (
    Rec_ID            int,
    Parent_ID         int,
    SortKey           int IDENTITY(1, 1) PRIMARY KEY,

    Style             int,

    BgKategorieCode   int,
    BgGruppeCode      int,

    Bezeichnung       varchar(500),
    Betrag            money,
    Total             money,

    Info              varchar(4000)
  )
AS

BEGIN
  DECLARE @Budget TABLE (
    PKey                 int IDENTITY(1, 1) PRIMARY KEY,

    Rec_ID               int,
    Parent_ID            int,
    SortKey              int,

    Style                int,

    WhGrundbedarfTypCode int,
    BgKategorieCode      int,
    BgGruppeCode         int,

    Bezeichnung          varchar(500),
    Betrag               money,
    Total                money,

    Info                 varchar(4000)
  )

  SELECT @GetDate = CASE WHEN BBG.MasterBudget = 1
                      THEN dbo.fnDateOf(CONVERT(datetime, dbo.fnMIN(dbo.fnMAX(@GetDate, IsNull(BFP.DatumVon, BFP.GeplantVon)), IsNull(BFP.DatumBis, BFP.GeplantBis))))
                      ELSE dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 15)
                    END
  FROM dbo.BgBudget              BBG WITH (READUNCOMMITTED) 
    INNER JOIN dbo.BgFinanzplan  BFP WITH (READUNCOMMITTED) ON BFP.BgFinanzplanID = BBG.BgFinanzplanID
  WHERE BBG.BgBudgetID = @BgBudgetID

  DECLARE @WhPositionsart TABLE (
    BgPositionsartID  int PRIMARY KEY,
    BgKategorieCode   int,
    BgGruppeCode      int,
    BgGruppeCode2     int
  )

  INSERT INTO @WhPositionsart
  SELECT BgPositionsartID, BgKategorieCode, BgGruppeCode, CASE WHEN BgGruppeCode BETWEEN 39000 AND 39999 THEN 39000 ELSE BgGruppeCode END
  FROM dbo.WhPositionsart
  WHERE BgKategorieCode IN (1, 2, 4)

  -- BgPositionen
  INSERT INTO @Budget (Style, Parent_ID, WhGrundbedarfTypCode, BgKategorieCode, BgGruppeCode,
                       Bezeichnung, Betrag, SortKey, Info)
    SELECT 10, BPA.BgKategorieCode, BFP.WhGrundbedarfTypCode, BPA.BgKategorieCode, BPA.BgGruppeCode2,
      BGG.Text, IsNull(SUM(BPO.BetragFinanzplan), $0.00), BGG.SortKey,
      Info = CASE
               WHEN BPA.BgGruppeCode2 = 3201 THEN
                 (SELECT ', VVG aus GBL: ' + LTrim(STR(SUM(POS.BetragFinanzplan) - SUM(POS.BetragBudget), 19, 2))
                  FROM dbo.vwBgPosition POS
                  INNER JOIN BgPositionsart POA ON POA.BgPositionsartID = POS.BgPositionsartID
                  WHERE POS.BgBudgetID = @BgBudgetID AND POA.BgPositionsartCode IN (32021, 32022)
                    AND ( (POS.DatumVon IS NULL AND IsNull(POS.DatumBis, '19000101') < '19010101')
                       OR (IsNull(POS.DatumVon, @GetDate) > '19001231' AND IsNull(POS.DatumVon, @GetDate) <= @GetDate AND IsNull(POS.DatumBis, @GetDate) >= @GetDate) )
                  HAVING SUM(POS.BetragBudget) > SUM(POS.BetragFinanzplan))
               WHEN BPA.BgGruppeCode2 = 3202 THEN
                 (SELECT ', VVG aus SIL: ' + LTrim(STR(SUM(POS.BetragFinanzplan), 19, 2)) --BSS! Text
                  FROM dbo.vwBgPosition POS
                  INNER JOIN BgPositionsart POA ON POA.BgPositionsartID = POS.BgPositionsartID
                  WHERE POS.BgBudgetID = @BgBudgetID AND POA.BgPositionsartCode = 32022
                    AND ( (POS.DatumVon IS NULL AND IsNull(POS.DatumBis, '19000101') < '19010101')
                       OR (IsNull(POS.DatumVon, @GetDate) > '19001231' AND IsNull(POS.DatumVon, @GetDate) <= @GetDate AND IsNull(POS.DatumBis, @GetDate) >= @GetDate) )
                  HAVING SUM(POS.BetragFinanzplan) > $0.00)
               ELSE ''
             END +
             CASE
               WHEN BBG.BgBewilligungStatusCode = 5 THEN
-- BSS! im SQL-Server 2000 gab das Coalesce Probleme!
                 IsNull(', ' + (SELECT TOP 1 XLC.Text
                                FROM @WhPositionsart       PA2
                                  INNER JOIN dbo.vwBgPosition  BP2 ON BP2.BgPositionsartID = PA2.BgPositionsartID AND BP2.BgBudgetID = @BgBudgetID
                                  INNER JOIN dbo.XLOVCode      XLC WITH (READUNCOMMITTED) ON XLC.LOVName = 'BgBewilligungStatus' AND XLC.Code = BP2.BgBewilligungStatusCode
                                WHERE BP2.BgBewilligungStatusCode < 5
                                  AND PA2.BgKategorieCode = BPA.BgKategorieCode AND PA2.BgGruppeCode2 = BPA.BgGruppeCode2
                                ORDER BY XLC.SortKey), '') +
                 IsNull(', letzte Anpassung per: '
                             + (SELECT CONVERT(varchar, MAX(dbo.fnMAX(DatumVon, DatumBis)), 104)
                                FROM @WhPositionsart       BPA2
                                  INNER JOIN dbo.vwBgPosition  BBO2 ON BBO2.BgPositionsartID = BPA2.BgPositionsartID
                                WHERE BPA2.BgGruppeCode2 = BPA.BgGruppeCode2 AND BgBudgetID = @BgBudgetID), '')
               WHEN EXISTS (SELECT *
                            FROM @WhPositionsart       BPA2
                              INNER JOIN dbo.vwBgPosition  BBO2 ON BBO2.BgPositionsartID = BPA2.BgPositionsartID
                            WHERE BPA2.BgGruppeCode2 = BPA.BgGruppeCode2 AND BgBudgetID = @BgBudgetID
                              AND DatumVon > @GetDate)
                 THEN ', zukünftige Leistungen vorhanden'
               ELSE ''
             END
    FROM @WhPositionsart       BPA
      INNER JOIN dbo.BgBudget      BBG WITH (READUNCOMMITTED) ON BBG.BgBudgetID = @BgBudgetID
      INNER JOIN dbo.BgFinanzplan  BFP WITH (READUNCOMMITTED) ON BFP.BgFinanzplanID = BBG.BgFinanzplanID
      INNER JOIN dbo.XLOVCode      BGG WITH (READUNCOMMITTED) ON BGG.LOVName = 'BgGruppe' AND BGG.Code = BPA.BgGruppeCode2
																						  AND BGG.Value1 IS NOT NULL  -- es sollen nur die Einträge mit korrespondierender Maske (Value1 im LOV) angezeigt werden. ##HACK!
      LEFT  JOIN dbo.vwBgPosition  BPO ON BPO.BgPositionsartID = BPA.BgPositionsartID AND BPO.BgBudgetID = @BgBudgetID
                                      AND BPO.BgKategorieCode NOT IN (100, 101) -- falls diese Funktion nicht mit einem Masterbudget aufgerufen wird, können unerwünschte Zus.Leistungen & Einzelzahlungen auftreten
                                      AND ( (BPO.DatumVon IS NULL AND IsNull(BPO.DatumBis, '19000101') < '19010101')
                                         OR (IsNull(BPO.DatumVon, @GetDate) > '19001231' AND IsNull(BPO.DatumVon, @GetDate) <= @GetDate AND IsNull(BPO.DatumBis, @GetDate) >= @GetDate) )
    WHERE BPA.BgKategorieCode IN (1, 2) OR (BPA.BgKategorieCode = 4 AND BPO.BetragFinanzplan > 0)
    GROUP BY BBG.BgBewilligungStatusCode, BPA.BgKategorieCode, BFP.WhGrundbedarfTypCode, BPA.BgGruppeCode2, BGG.Text, BGG.SortKey

  --Kürzungen
  INSERT INTO @Budget (Style, Parent_ID, WhGrundbedarfTypCode, BgKategorieCode, BgGruppeCode,
                       Bezeichnung, Betrag, SortKey, Info)
    SELECT 
	  Style=10, Parent_ID=2, WhGrundbedarfTypCode=NULL, BgKategorieCode=4, BgGruppeCode=NULL,
      Bezeichnung= 'Kürzung: ' + SPZ.NameSpezkonto + ', ' + PRS.Vorname + ' ' + PRS.Name, IsNull(BPO.BetragFinanzplan, $0.00), 1000, Info = ', Kürzung'
     FROM  dbo.vwBgPosition  BPO 
	 INNER JOIN BgSpezkonto SPZ on SPZ.BgSpezkontoID = BPO.BgSpezkontoID
   INNER JOIN BaPerson PRS on BPO.BaPersonID = PRS.BaPersonID
	 WHERE BPO.BgBudgetID = @BgBudgetID 
	   AND BPO.BgPositionsartID IS NULL 
	   AND SPZ.BgSpezkontoTypCode = 4

  -- Kategorien
  INSERT INTO @Budget (Rec_ID, Style, BgKategorieCode, Bezeichnung, Total, SortKey)
    SELECT Code, 1, Code, UPPER(Text), (SELECT SUM(Betrag) FROM @Budget WHERE BgKategorieCode = Code), SortKey
    FROM dbo.XLOVCode WITH (READUNCOMMITTED) 
    WHERE LOVName = 'BgKategorie'
      AND EXISTS (SELECT 1 FROM @Budget WHERE BgKategorieCode = Code)
    ORDER BY SortKey

  -- Output
  INSERT INTO @OUTPUT (Rec_ID, Parent_ID, Style,
    BgKategorieCode, BgGruppeCode,
    Bezeichnung, Betrag, Total, Info)
  SELECT TMP.Rec_ID, TMP.Parent_ID, TMP.Style,
    TMP.BgKategorieCode, TMP.BgGruppeCode,
    Bezeichnung =    CASE WHEN @Indent = 0 THEN TMP.Bezeichnung --Bei Indent = 0 nicht einrücken
                       ELSE 
                         CASE TMP.Style
                           WHEN 1 THEN ''
                           WHEN 2 THEN '  '
                           ELSE        '    '
                         END + TMP.Bezeichnung
                       END,
    TMP.Betrag, TMP.Total,
    SubString(TMP.Info, 3, 8000)
  FROM @Budget                 TMP
    LEFT JOIN @Budget          SUB ON (SUB.Style IS NULL OR SUB.Style NOT IN (1, 2)) AND (SUB.PKey = TMP.PKey)
    LEFT JOIN @Budget          GRP ON GRP.Style = 2 AND (GRP.PKey = TMP.PKey OR GRP.Rec_ID = TMP.Parent_ID)
    LEFT JOIN @Budget          TIT ON TIT.Style = 1 AND (TIT.PKey = TMP.PKey OR TIT.Rec_ID = GRP.Parent_ID OR TIT.Rec_ID = TMP.Parent_ID)
  ORDER BY TIT.SortKey, TIT.PKey,
           GRP.SortKey, GRP.PKey,
           SUB.SortKey, SUB.PKey

  INSERT INTO @OUTPUT (Style, Bezeichnung) VALUES (1, '')

--- BE/Gemeinden (Wie in KiSS3)
  INSERT INTO @OUTPUT (Style, Bezeichnung) VALUES (1, 'Differenz')

  DECLARE @Betrag  money
  SELECT @Betrag = SUM(CASE BgKategorieCode
                         WHEN 1 THEN Betrag
                         WHEN 2 THEN 0 - Betrag
                         WHEN 4 THEN Betrag
                       END)
    FROM @OUTPUT

  INSERT INTO @OUTPUT (Style, Bezeichnung, Betrag)
    SELECT 2, CASE WHEN @Betrag < 0 THEN 'Fehlbetrag' ELSE 'Überschuss' END, ABS(@Betrag)

  RETURN
END
GO