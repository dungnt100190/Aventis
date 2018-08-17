/*
  KiSS 4.0
  --------
  DB-Object: fnShSpezkonto
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:56
*/
CREATE FUNCTION dbo.fnShSpezkonto
 (@ShSpezkontoID      int,
  @ReturnTyp          int = 3,
  @BgBudgetID         int = NULL,
  @ShEinzelzahlungID  int = NULL)
 RETURNS money
AS BEGIN
 /*
  * ReturnTyp:
  *  1 Gutschriften
  *  2 Belastungen
  *  3 Saldo
  *  4 Deckung
  */

  DECLARE @FaFallID            int,
          @StartSaldo          money,
          @ShSpezkontoTypCode  int,
          @OhneEinzelzahlung   bit,
          @Gutschrift          money,
          @Belastung           money

  DECLARE @BgBudget TABLE (
    BgBudgetID   int NOT NULL,
    Verbucht     bit NOT NULL,
    Datum        datetime NOT NULL
  )

  SELECT
    @FaFallID           = SSK.FaFallID,
    @StartSaldo         = SSK.StartSaldo,
    @ShSpezkontoTypCode = ShSpezkontoTypCode,
    @OhneEinzelzahlung  = SSK.OhneEinzelzahlung
  FROM ShSpezkonto  SSK
  WHERE SSK.ShSpezkontoID = @ShSpezkontoID

  -- Berücksichtigte Busdget
  INSERT INTO @BgBudget (BgBudgetID, Verbucht, Datum)
    SELECT BgBudgetID, CASE BBG.BgBudgetCode WHEN 12 THEN 1 ELSE 0 END, dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1)
    FROM ShFinanzPlan      SFP
      INNER JOIN BgBudget  BBG ON BBG.ShFinanzPlanID = SFP.ShFinanzPlanID
    WHERE SFP.FaFallID = @FaFallID
      AND BBG.BgBudgetCode BETWEEN 11 AND 19

  UPDATE BBG
    SET Verbucht = 1
  FROM @BgBudget  BBG
  WHERE Verbucht = 0
    AND EXISTS (SELECT * FROM FlBeleg
                WHERE IdSource = BBG.BgBudgetID AND FlTypSourceCode = 102
                AND FlBelegStatusCode NOT IN (105, 106) )

  IF @BgBudgetID IS NULL
    DELETE FROM @BgBudget WHERE Verbucht = 0
  ELSE
    DELETE FROM @BgBudget WHERE Datum > (SELECT Datum FROM @BgBudget WHERE BgBudgetID = @BgBudgetID)

  -- Berechnung
  SELECT
    @Gutschrift = IsNull(
      (SELECT SUM(BPO.BetragRechnung)
       FROM @BgBudget                BBG
         INNER JOIN vwBgPosition     BPO ON BPO.BgBudgetID = BBG.BgBudgetID
       WHERE BPO.ShSpezkontoID = SSK.ShSpezkontoID)
    , $0) + IsNull( -- ESIL an Abzahlungskonto
      (SELECT SUM(Betrag)
       FROM @BgBudget                BBG
         INNER JOIN ShEinzelzahlung  SEZ ON SEZ.BgBudgetID = BBG.BgBudgetID
         INNER JOIN ShPositionTyp    SPT ON SPT.ShPositionTypID = SEZ.ShPositionTypID
       WHERE ShSpezkontoID = SSK.ShSpezkontoID AND SPT.BgPositionCode = 100 AND ShStatusEinzelzahlungCode = 103)
    , $0),
    @Belastung  = IsNull(
      (SELECT SUM(Betrag)
       FROM @BgBudget                BBG
         INNER JOIN ShEinzelzahlung  SEZ ON SEZ.BgBudgetID = BBG.BgBudgetID
         LEFT  JOIN ShPositionTyp    SPT ON SPT.ShPositionTypID = SEZ.ShPositionTypID
       WHERE ShSpezkontoID = SSK.ShSpezkontoID AND IsNull(SPT.BgPositionCode, 2) = 2
         AND ShEinzelzahlungID != IsNull(@ShEinzelzahlungID, 0))
    , $0)
  FROM ShSpezkonto  SSK
  WHERE SSK.ShSpezkontoID = @ShSpezkontoID

  IF @ReturnTyp = 1
    RETURN @Gutschrift
  ELSE IF @ReturnTyp = 2
    RETURN @Belastung
  ELSE IF @ReturnTyp = 3 BEGIN
    IF @ShSpezkontoTypCode IN (1, 2)
      RETURN @StartSaldo + @Gutschrift - @Belastung
    ELSE IF @OhneEinzelzahlung = 1
      RETURN @StartSaldo + @Belastung - @Gutschrift
    ELSE
      RETURN @StartSaldo - @Gutschrift
  END ELSE IF @ReturnTyp = 4 BEGIN
    IF @ShSpezkontoTypCode IN (1, 2)
      RETURN @StartSaldo + @Gutschrift - @Belastung
    ELSE IF @OhneEinzelzahlung = 1
      RETURN $0.00
    ELSE
      RETURN @StartSaldo - @Belastung
  END

  RETURN $0.00
END
GO