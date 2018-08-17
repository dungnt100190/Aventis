SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnWhGetFinanzplanML
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/Sozialhilfe/fnWhGetFinanzplanML.sql $
  $Author: Tabegglen $
  $Modtime: 17.08.10 11:48 $
  $Revision: 3 $
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
  $Log: /KiSS4/Database/DBOs/Functions/Sozialhilfe/fnWhGetFinanzplanML.sql $
 * 
 * 3     17.08.10 11:50 Tabegglen
 * #3978 BgPositionsartNr muss BgPositionsartCode heissen, da es den
 * Charakter einer LOV hat.
 * 
 * 2     16.08.10 17:40 Tabegglen
 * #3978 Migration BgPositionsartID -> BgPositionsartID
 * 
 * 1     25.08.09 14:59 Nweber
 * #4932: Fehlende Funktionen
 * 
=================================================================================================*/
/*
  KiSS 4.0
  --------
  DB-Object: fnWhGetFinanzplanML
  Branch   : KiSS_PROD
  BuildNr  : 1
  Datum    : 15.07.2008 17:25
*/
-- =====================================================================================
-- Author:      RH (R. Hesterberg)
-- Create date: 04.01.2008
-- Description: fnWhGetBudget für Mehrsprachigkeit
-- =====================================================================================
-- History:
-- 04.01.2008 : RH : Neu 
-- =====================================================================================

CREATE FUNCTION dbo.fnWhGetFinanzplanML
(
  @BgBudgetID INT,
  @GetDate    datetime
)
RETURNS
  @OUTPUT TABLE (
    Rec_ID            INT,
    Parent_ID         INT,
    SortKey           INT IDENTITY(1, 1) PRIMARY KEY,
    Style             INT,
    BgKategorieCode   INT,
    BgGruppeCode      INT,
    Bezeichnung       varchar(500),
    Betrag            money,
    Total             money,
    Info              varchar(4000)
  )
AS
BEGIN

  -- Sprache des Klienten holen
  DECLARE @SprachCode INT
  SELECT @SprachCode = P.VerstaendigungSprachCode
  FROM BgBudget B
    LEFT OUTER JOIN BgFinanzplan FP ON FP.BgFinanzplanID = B.BgFinanzplanID
    LEFT OUTER JOIN FaLeistung LEI ON LEI.FaLeistungID = FP.FaLeistungID
    LEFT OUTER JOIN FaFall FAL ON FAL.FaFallID = LEI.FaFallID
    LEFT OUTER JOIN BaPerson P ON P.BaPersonID = FAL.BaPersonID
  WHERE B.BgBudgetID = @BgBudgetID
  IF @SprachCode IS NULL SET @SprachCode = 1

  -- ML-Text holen
  DECLARE @Text_VVGausGBL varchar(200)
  SELECT @Text_VVGausGBL = dbo.fnGetMLTextFromName('Report_Budget', 'VVGausGBL', @SprachCode)  -- "VVG aus GBL"
  DECLARE @Text_VVGgemEK varchar(200)
  SELECT @Text_VVGgemEK = dbo.fnGetMLTextFromName('Report_Budget', 'VVGgemEK', @SprachCode)  -- "VVG gemäss EK"
  DECLARE @Text_AndLeistg varchar(200)
  SELECT @Text_AndLeistg = dbo.fnGetMLTextFromName('Report_Budget', 'WeitereLeistungen', @SprachCode)  -- "weitere Leistungen vorhanden"
  DECLARE @Text_Differenz varchar(200)
  SELECT @Text_Differenz = dbo.fnGetMLTextFromName('Report_Budget', 'Differenz', @SprachCode)  -- "Differenz"
  DECLARE @Text_Fehlbetrag varchar(200)
  SELECT @Text_Fehlbetrag = dbo.fnGetMLTextFromName('Report_Budget', 'Fehlbetrag', @SprachCode)  -- "Fehlbetrag"
  DECLARE @Text_Ueberschuss varchar(200)
  SELECT @Text_Ueberschuss = dbo.fnGetMLTextFromName('Report_Budget', 'Ueberschuss', @SprachCode)  -- "Überschuss"


  DECLARE @Budget TABLE (
    PKey              INT IDENTITY(1, 1) PRIMARY KEY,
    Rec_ID            INT,
    Parent_ID         INT,
    SortKey           INT,
    Style             INT,
    BgKategorieCode   INT,
    BgGruppeCode      INT,
    Bezeichnung       varchar(500),
    Betrag            money,
    Total             money,
    Info              varchar(4000)
  )

  SELECT @GetDate = CASE
    WHEN BBG.MasterBudget = 1 THEN CONVERT(datetime,
      dbo.fnMIN(dbo.fnMAX(@GetDate, IsNull(BFP.DatumVon, BFP.GeplantVon)), IsNull(BFP.DatumBis, BFP.GeplantBis)))
    ELSE dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 15)
  END
  FROM BgBudget BBG
    LEFT JOIN BgFinanzplan  BFP ON BFP.BgFinanzplanID = BBG.BgFinanzplanID
  WHERE BBG.BgBudgetID = @BgBudgetID

  DECLARE @WhPositionsart TABLE (
    BgPositionsartID  INT PRIMARY KEY,
    BgKategorieCode   INT,
    BgGruppeCode      INT,
    BgGruppeCode2     INT
  )

  INSERT INTO @WhPositionsart
  SELECT BgPositionsartID, BgKategorieCode, BgGruppeCode,
    CASE WHEN BgGruppeCode BETWEEN 39000 AND 39999 THEN 39000 ELSE BgGruppeCode END
  FROM WhPositionsart
  WHERE BgKategorieCode IN (1, 2, 4)

  -- BgPositionen
  INSERT INTO @Budget (
    Style, Parent_ID, BgKategorieCode, BgGruppeCode,
    Bezeichnung, Betrag, SortKey, Info
  )
  SELECT 10, BPA.BgKategorieCode, BPA.BgKategorieCode, BPA.BgGruppeCode2,
    dbo.fnLOVMLText('BgGruppe', BPA.BgGruppeCode2, @SprachCode),
    IsNull(SUM(BPO.BetragFinanzplan), $0.00), BGG.SortKey,
    Info = CASE
      -- BgGruppeCode2 = 3201 : ???
      WHEN BPA.BgGruppeCode2 = 3201 THEN (
        SELECT ', ' + @Text_VVGausGBL + ': ' + LTrim(STR(SUM(POS.BetragFinanzplan) - SUM(POS.BetragBudget), 19, 2))
        FROM vwBgPosition POS
        INNER JOIN BgPositionsart POA ON POA.BgPositionsartID = POS.BgPositionsartID
        WHERE POS.BgBudgetID = @BgBudgetID AND POA.BgPositionsartCode IN (32021, 32022)
          AND ( (POS.DatumVon IS NULL AND IsNull(POS.DatumBis, '19000101') < '19010101')
             OR (IsNull(POS.DatumVon, @GetDate) > '19001231' AND IsNull(POS.DatumVon, @GetDate) <= @GetDate AND IsNull(POS.DatumBis, @GetDate) >= @GetDate) )
        HAVING SUM(POS.BetragBudget) > SUM(POS.BetragFinanzplan))
      -- BgGruppeCode2 = 3202 : ???
      WHEN BPA.BgGruppeCode2 = 3202 THEN (
        SELECT ', ' + @Text_VVGgemEK + ': ' + LTrim(STR(SUM(POS.BetragFinanzplan), 19, 2))
        FROM vwBgPosition POS
        INNER JOIN BgPositionsart POA ON POA.BgPositionsartID = POS.BgPositionsartID
        WHERE POS.BgBudgetID = @BgBudgetID AND POA.BgPositionsartCode = 32022
          AND ( (POS.DatumVon IS NULL AND IsNull(POS.DatumBis, '19000101') < '19010101')
             OR (IsNull(POS.DatumVon, @GetDate) > '19001231' AND IsNull(POS.DatumVon, @GetDate) <= @GetDate AND IsNull(POS.DatumBis, @GetDate) >= @GetDate) )
        HAVING SUM(POS.BetragFinanzplan) > $0.00)
      ELSE ''
    END + CASE
      WHEN BBG.BgBewilligungStatusCode = 5 THEN IsNull(', ' + (
        SELECT TOP 1
          Text = dbo.fnLOVMLText('BgBewilligungStatus', BP2.BgBewilligungStatusCode, @SprachCode)
        FROM @WhPositionsart PA2
        INNER JOIN vwBgPosition  BP2 ON BP2.BgPositionsartID = PA2.BgPositionsartID AND BP2.BgBudgetID = @BgBudgetID
        LEFT JOIN XLOVCode XLC ON XLC.LOVName = 'BgBewilligungStatus' AND XLC.Code = BP2.BgBewilligungStatusCode
        WHERE BP2.BgBewilligungStatusCode < 5
          AND PA2.BgKategorieCode = BPA.BgKategorieCode AND PA2.BgGruppeCode2 = BPA.BgGruppeCode2
        ORDER BY XLC.SortKey), '')
      ELSE ''
    END + CASE
      WHEN EXISTS (
        SELECT * FROM @WhPositionsart BPA2
        INNER JOIN vwBgPosition  BBO2 ON BBO2.BgPositionsartID = BPA2.BgPositionsartID
        WHERE BPA2.BgGruppeCode2 = BPA.BgGruppeCode2 AND BgBudgetID = @BgBudgetID AND DatumVon > @GetDate)
      THEN ', ' + @Text_AndLeistg   --'weitere Leistungen vorhanden'
      ELSE ''
    END
    FROM @WhPositionsart       BPA
      INNER JOIN BgBudget      BBG ON BBG.BgBudgetID = @BgBudgetID
      LEFT  JOIN XLOVCode      BGG ON BGG.LOVName = 'BgGruppe' AND BGG.Code = BPA.BgGruppeCode2
      LEFT  JOIN vwBgPosition  BPO ON BPO.BgPositionsartID = BPA.BgPositionsartID AND BPO.BgBudgetID = @BgBudgetID
                                  AND ( (BPO.DatumVon IS NULL AND IsNull(BPO.DatumBis, '19000101') < '19010101')
                                     OR (IsNull(BPO.DatumVon, @GetDate) > '19001231' AND IsNull(BPO.DatumVon, @GetDate) <= @GetDate AND IsNull(BPO.DatumBis, @GetDate) >= @GetDate) )
    WHERE BPA.BgKategorieCode IN (1, 2) OR (BPA.BgKategorieCode = 4 AND BPO.BetragFinanzplan > 0)
    GROUP BY
      BBG.BgBewilligungStatusCode, BPA.BgKategorieCode, BPA.BgGruppeCode2,
      dbo.fnLOVMLText('BgGruppe', BPA.BgGruppeCode2, @SprachCode),
      BGG.SortKey

  -- Kategorien
  INSERT INTO @Budget (Rec_ID, Style, BgKategorieCode, Bezeichnung, Total, SortKey)
    SELECT
      Code, 1, Code, -- UPPER(Text), 
      dbo.fnLOVMLText('BgKategorie', Code, @SprachCode),
      (SELECT SUM(Betrag) FROM @Budget WHERE BgKategorieCode = Code),
      SortKey
    FROM XLOVCode
    WHERE LOVName = 'BgKategorie'
      AND EXISTS (SELECT * FROM @Budget WHERE BgKategorieCode = Code)
    ORDER BY SortKey

  -- Output
  INSERT INTO @OUTPUT (Rec_ID, Parent_ID, Style,
    BgKategorieCode, BgGruppeCode,
    Bezeichnung, Betrag, Total, Info)
  SELECT TMP.Rec_ID, TMP.Parent_ID, TMP.Style,
    TMP.BgKategorieCode, TMP.BgGruppeCode,
    Bezeichnung = CASE TMP.Style WHEN 1 THEN '' WHEN 2 THEN '  ' ELSE '    ' END + TMP.Bezeichnung,
    TMP.Betrag, TMP.Total,
    SubString(TMP.Info, 3, 8000)
  FROM @Budget TMP
    LEFT JOIN @Budget SUB ON (SUB.Style IS NULL OR SUB.Style NOT IN (1, 2)) AND (SUB.PKey = TMP.PKey)
    LEFT JOIN @Budget GRP ON GRP.Style = 2 AND (GRP.PKey = TMP.PKey OR GRP.Rec_ID = TMP.Parent_ID)
    LEFT JOIN @Budget TIT ON TIT.Style = 1 AND (TIT.PKey = TMP.PKey OR TIT.Rec_ID = GRP.Parent_ID OR TIT.Rec_ID = TMP.Parent_ID)
-- TODO?  WHERE TMP.BgGruppeCode IS NULL OR TMP.BgGruppeCode NOT IN (3901, 3902)
  ORDER BY TIT.SortKey, TIT.PKey,
           GRP.SortKey, GRP.PKey,
           SUB.SortKey, SUB.PKey

  INSERT INTO @OUTPUT (Style, Bezeichnung) VALUES (1, '')
/*
ZH: 
  INSERT INTO @OUTPUT (Style, Bezeichnung) VALUES (1, 'Fehlbeträge')
  INSERT INTO @OUTPUT (Style, Bezeichnung, Betrag)
    SELECT 10, '   Fehlbetrag exkl. Zulagen',
      Betrag = (SELECT SUM(CASE
                             WHEN BgKategorieCode = 1 THEN -Betrag
                             WHEN BgKategorieCode = 2 THEN Betrag
                             WHEN BgKategorieCode = 4 THEN -Betrag
                             ELSE $0.00
                           END)
                FROM @Budget
                WHERE Style = 10 AND BgGruppeCode NOT BETWEEN 39000 AND 39999)
  INSERT INTO @OUTPUT (Style, Bezeichnung, Betrag)
    SELECT 1, ' Fehlbetrag inkl. Zulagen',
      Betrag = (SELECT SUM(CASE
                             WHEN BgKategorieCode = 1 THEN -Betrag
                             WHEN BgKategorieCode = 2 THEN Betrag
                             WHEN BgKategorieCode = 4 THEN -Betrag
                             ELSE $0.00
                           END)
                FROM @Budget
                WHERE Style = 10)
*/
--- BE/Gemeinden (Wie in KiSS3)
  INSERT INTO @OUTPUT (Style, Bezeichnung) VALUES (1, @Text_Differenz)

  DECLARE @Betrag  money
  SELECT @Betrag = SUM(CASE BgKategorieCode
                         WHEN 1 THEN Betrag
                         WHEN 2 THEN -Betrag
                         WHEN 4 THEN Betrag
                       END)
    FROM @OUTPUT

  INSERT INTO @OUTPUT (Style, Bezeichnung, Betrag)
    SELECT 2, CASE WHEN @Betrag < 0 THEN @Text_Fehlbetrag ELSE @Text_Ueberschuss END, ABS(@Betrag)

  RETURN
END
GO
