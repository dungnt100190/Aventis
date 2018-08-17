CREATE FUNCTION [dbo].fnShGetFinanzplan
 (@BgBudgetID      int,
  @GetDate         datetime)
RETURNS
  @Finanzplan TABLE (
    BgPositionCode    int NOT NULL,
    Bezeichnung       varchar(500),
    BetragFinanzplan  money,
    ShPositionTypCode varchar(20),
    Info              varchar(1000)
  )
AS BEGIN
  DECLARE @ShFinanzPlanID    int,
          @ShGrundbedarfTyp  int

  SELECT @ShFinanzPlanID = ShFinanzPlanID FROM BgBudget WHERE BgBudgetID = @BgBudgetID
  IF @ShFinanzPlanID IS NULL RETURN

  SELECT @ShGrundbedarfTyp = ShPositionTypID
  FROM BgPosition        BPO
    INNER JOIN XLOVCode  XLC ON XLC.LOVName = 'ShGrundbedarfTyp' AND XLC.Code = BPO.ShPositionTypID
  WHERE BPO.BgBudgetID = @BgBudgetID

  DECLARE @BgPosition TABLE (
    Betrag            money,
    BgPositionCode    int,
    ShPositionTypID   int,
    BetragRechnung    money,
    BetragFinanzplan  money
  )

  INSERT INTO @BgPosition (Betrag, BgPositionCode, ShPositionTypID, BetragRechnung, BetragFinanzplan)
    SELECT BPO.BetragFinanzplan, BPO.BgPositionCode, BPO.ShPositionTypID, BPO.BetragRechnung, BPO.BetragFinanzplan
    FROM vwBgPosition BPO
    WHERE BPO.BgBudgetID = @BgBudgetID
      AND ( (BPO.GueltigVon IS NULL  AND BPO.ShPositionTypID NOT IN (20, 21) AND BPO.ShPositionTypID NOT BETWEEN 60 AND 99) OR
            ((BPO.ShPositionTypID IN (20, 21) OR BPO.ShPositionTypID BETWEEN 60 AND 99)
               AND @GetDate BETWEEN IsNull(BPO.GueltigVon, '19000101') AND IsNull(BPO.GueltigBis, @GetDate))
          )

-- SKOS 2005 Limite Zulagen
  IF @ShGrundbedarfTyp != 1 BEGIN
    DECLARE @RefDate datetime, @Limit money, @SumZulage money

    SELECT
      @RefDate = CASE WHEN BBG.BgBudgetCode BETWEEN 1 AND 9
                   THEN IsNull(SFP.DatumVon, SFP.GeplantVon)
                   ELSE dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1)
                 END
    FROM ShFinanzPlan      SFP
      INNER JOIN BgBudget  BBG ON BBG.ShFinanzPlanID = SFP.ShFinanzPlanID
    WHERE BBG.BgBudgetID = @BgBudgetID

    SELECT TOP 1 @Limit = CONVERT(money, CFG.ValueVar)
    FROM dbo.fnXConfigChild('System\Sozialhilfe\SKOS2005\Abzug_Limit\', @RefDate)  CFG
    WHERE CONVERT(int, CFG.Child) <= (SELECT UeGrundbedarf FROM dbo.fnShKennzahlen(@ShFinanzPlanID) KNZ)
    ORDER BY CFG.Child DESC

    SELECT @SumZulage = SUM(BPO.BetragFinanzplan)
    FROM @BgPosition  BPO
    WHERE BPO.BgPositionCode = 2 AND BPO.ShPositionTypID BETWEEN 39000 AND 39999

    IF @SumZulage > @Limit
      UPDATE @BgPosition
        SET BetragFinanzplan = BetragFinanzplan * @Limit / @SumZulage
      WHERE BgPositionCode = 2 AND ShPositionTypID BETWEEN 39000 AND 39999
  END

-- Einnahmen
  INSERT INTO @Finanzplan (BgPositionCode, Bezeichnung, BetragFinanzplan, ShPositionTypCode, Info)
    SELECT MIN(SPT.BgPositionCode), XPT.text, SUM(IsNull(BPO.BetragFinanzplan, 0.00)), CONVERT(varchar, SPT.ShPositionTypCode),
      'Betrag insgesammt: Fr. ' + LTrim(STR(NullIf(SUM(BPO.BetragRechnung), SUM(BPO.BetragFinanzplan)), 19, 2))
    FROM ShPositionTyp        SPT
      INNER JOIN XLOVCode     XPT ON XPT.LOVName = 'ShPositionTyp' AND XPT.Code = SPT.ShPositionTypCode
      LEFT  JOIN @BgPosition  BPO ON BPO.ShPositionTypID = SPT.ShPositionTypID
    WHERE SPT.BgPositionCode = 1
    GROUP BY SPT.ShPositionTypCode, XPT.text, XPT.SortKey
    ORDER BY XPT.SortKey

-- Ausgaben
  INSERT INTO @Finanzplan (BgPositionCode, Bezeichnung, BetragFinanzplan, ShPositionTypCode, Info)
    SELECT MIN(SPT.BgPositionCode),
           MAX(CASE
                 WHEN SPT.ShPositionTypID = 1 THEN 'Grundbedarf Lebensunterhalt'
                 WHEN SPT.ShPositionTypID = 2 THEN 'Zuschlag zum Grundbedarf I'
                 WHEN SPT.ShPositionTypID = 3 THEN 'Grundbedarf II'
                 WHEN SPT.ShPositionTypID = 4 THEN 'Grundbedarf II'

                 WHEN SPT.ShPositionTypID = 20 THEN XPT.text + '   Grundversicherung (KVG)'
                 WHEN SPT.ShPositionTypID = 21 THEN XPT.text + '   Zusatzversicherung (VVG)'

                 WHEN SPT.ShPositionTypID = 30 THEN SPT.Name
                 WHEN SPT.ShPositionTypID = 31 THEN SPT.Name

                 WHEN SPT.ShPositionTypID BETWEEN 39000 AND 39999 THEN 'Zulagen / EFB'

                 ELSE IsNull(SLT.NameInTreeview, XPT.text)
               END),
      SUM(IsNull(BPO.BetragFinanzplan, 0.00)),
      MIN(CASE
            WHEN SPT.ShPositionTypID BETWEEN 39000 AND 39999 THEN '9'
            WHEN SPT.ShPositionTypID   = 30                  THEN '1'
            WHEN SPT.ShPositionTypCode = 99                  THEN '\SIL' + CONVERT(varchar, SPT.ShSilTypID)
            ELSE CONVERT(varchar, SPT.ShPositionTypCode)
          END),
      'Betrag Rechnung: Fr. ' + LTrim(STR(NullIf(SUM(BPO.BetragRechnung), SUM(BPO.BetragFinanzplan)), 19, 2))
    FROM ShPositionTyp        SPT
      INNER JOIN XLOVCode     XPT ON XPT.LOVName = 'ShPositionTyp' AND XPT.Code = SPT.ShPositionTypCode
      LEFT  JOIN ShSilTyp     SLT ON SLT.ShSilTypID = SPT.ShSilTypID
      LEFT  JOIN @BgPosition  BPO ON BPO.ShPositionTypID = SPT.ShPositionTypID
    WHERE SPT.BgPositionCode = 2
      AND NOT (@ShGrundbedarfTyp != 1 AND SPT.ShPositionTypID IN (2, 3, 4)           )  -- SKOS
      AND NOT (@ShGrundbedarfTyp  = 1 AND SPT.ShPositionTypID BETWEEN 39000 AND 39999)  -- SKOS2005
      AND NOT (@ShGrundbedarfTyp  = 5 AND SPT.ShPositionTypID IN (31)                )  -- Alg. Erwerbsunkosten
    GROUP BY XPT.SortKey, SLT.SortKey,
      CASE SPT.ShPositionTypID
        WHEN 2 THEN 2
        WHEN 3 THEN 3
        WHEN 4 THEN 3

        WHEN 20 THEN 20
        WHEN 21 THEN 21

        WHEN 30 THEN 30
        WHEN 31 THEN 31

        ELSE 0
      END
    ORDER BY XPT.SortKey, SLT.SortKey

-- Kürzungen
  INSERT INTO @Finanzplan (BgPositionCode, Bezeichnung, BetragFinanzplan, ShPositionTypCode)
    SELECT MIN(SPT.BgPositionCode), MAX(XPT.text), SUM(IsNull(BPO.BetragFinanzplan, 0.00)),
      MIN(CASE
            WHEN SPT.ShPositionTypID BETWEEN 39000 AND 39999 THEN '9'
            ELSE CONVERT(varchar, SPT.ShPositionTypCode)
          END)
    FROM ShPositionTyp        SPT
      INNER JOIN XLOVCode     XPT ON XPT.LOVName = 'ShPositionTyp' AND XPT.Code = SPT.ShPositionTypCode
      LEFT  JOIN @BgPosition  BPO ON BPO.ShPositionTypID = SPT.ShPositionTypID
    WHERE SPT.BgPositionCode = 4
    GROUP BY XPT.SortKey
    ORDER BY XPT.SortKey

  RETURN
END

GO