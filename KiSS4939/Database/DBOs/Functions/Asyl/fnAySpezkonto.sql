SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnAySpezkonto
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Functions/fnAySpezkonto.sql $
  $Author: Ckaeser $
  $Modtime: 24.06.09 9:50 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Functions/fnAySpezkonto.sql $
 * 
 * 2     24.06.09 16:16 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:06 Aklopfenstein
 * VSS First
=================================================================================================*/

/*
  KiSS 4.0
  --------
  DB-Object: fnAySpezkonto
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:53
*/
CREATE FUNCTION dbo.fnAySpezkonto
 (@BgSpezkontoID      int,
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

  DECLARE @FaLeistungID        int,
          @StartSaldo          money,
          @BgSpezkontoTypCode  int,
          @OhneEinzelzahlung   bit,
          @Gutschrift          money,
          @Belastung           money

  DECLARE @BgBudget TABLE (
    BgBudgetID   int NOT NULL,
    Verbucht     bit NOT NULL,
    Datum        datetime NOT NULL
  )

  SELECT
    @FaLeistungID         = SSK.FaLeistungID,
    @StartSaldo           = SSK.StartSaldo,
    @BgSpezkontoTypCode   = BgSpezkontoTypCode,
    @OhneEinzelzahlung    = SSK.OhneEinzelzahlung
  FROM dbo.BgSpezkonto  SSK WITH (READUNCOMMITTED) 
  WHERE SSK.BgSpezkontoID = @BgSpezkontoID

  -- Berücksichtigte Budget
  INSERT INTO @BgBudget (BgBudgetID, Verbucht, Datum)
    SELECT BgBudgetID, CASE BBG.BgBewilligungStatusCode WHEN 5 THEN 1 ELSE 0 END, dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1)
    FROM dbo.BgFinanzplan      SFP WITH (READUNCOMMITTED) 
      INNER JOIN dbo.BgBudget  BBG WITH (READUNCOMMITTED) ON BBG.BgFinanzplanID = SFP.BgFinanzplanID
    WHERE SFP.FaLeistungID = @FaLeistungID
      AND BBG.MasterBudget = 0

  UPDATE BBG
    SET Verbucht = 1
  FROM @BgBudget  BBG
  WHERE Verbucht = 0
    AND EXISTS (SELECT 1 FROM dbo.KbBuchung WITH (READUNCOMMITTED) 
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
         INNER JOIN dbo.vwBgPosition     BPO ON BPO.BgBudgetID = BBG.BgBudgetID
       WHERE BPO.BgSpezkontoID = SSK.BgSpezkontoID)
    , $0) + IsNull( -- ESIL an Abzahlungskonto
      (SELECT SUM(Betrag)
       FROM @BgBudget                BBG
         INNER JOIN dbo.ShEinzelzahlung  SEZ WITH (READUNCOMMITTED) ON SEZ.BgBudgetID = BBG.BgBudgetID
         INNER JOIN dbo.BgPositionsart    BPT WITH (READUNCOMMITTED) ON BPT.BgPositionsartID = SEZ.BgPositionsartID
       WHERE BgSpezkontoID = SSK.BgSpezkontoID AND BPT.BgKategorieCode = 100 AND ShStatusEinzelzahlungCode = 103)
    , $0),
    @Belastung  = IsNull(
      (SELECT SUM(Betrag)
       FROM @BgBudget                BBG
         INNER JOIN dbo.ShEinzelzahlung  SEZ WITH (READUNCOMMITTED) ON SEZ.BgBudgetID = BBG.BgBudgetID
         LEFT  JOIN dbo.BgPositionsart    BPT WITH (READUNCOMMITTED) ON BPT.BgPositionsartID = SEZ.BgPositionsartID
       WHERE BgSpezkontoID = SSK.BgSpezkontoID AND IsNull(BPT.BgKategorieCode, 2) = 2
         AND ShEinzelzahlungID != IsNull(@ShEinzelzahlungID, 0))
    , $0)
  FROM dbo.BgSpezkonto  SSK WITH (READUNCOMMITTED) 
  WHERE SSK.BgSpezkontoID = @BgSpezkontoID

  IF @ReturnTyp = 1
    RETURN @Gutschrift
  ELSE IF @ReturnTyp = 2
    RETURN @Belastung
  ELSE IF @ReturnTyp = 3 BEGIN
    IF @BgSpezkontoTypCode IN (1, 2)
      RETURN @StartSaldo + @Gutschrift - @Belastung
    ELSE IF @OhneEinzelzahlung = 1
      RETURN @StartSaldo + @Belastung - @Gutschrift
    ELSE
      RETURN @StartSaldo - @Gutschrift
  END ELSE IF @ReturnTyp = 4 BEGIN
    IF @BgSpezkontoTypCode IN (1, 2)
      RETURN @StartSaldo + @Gutschrift - @Belastung
    ELSE IF @OhneEinzelzahlung = 1
      RETURN $0.00
    ELSE
      RETURN @StartSaldo - @Belastung
  END

  RETURN $0.00
END
GO