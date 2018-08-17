SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBgSpezkonto;
GO
/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Funktion um die Gutschriften, Belastungen, Saldo oder Deckung eines Spezialkontos zurückzugeben.
    @BgSpezkontoID: ID des Spezialkontos
    @ReturnTyp:     1 Gutschriften
                    2 Belastungen
                    3 Saldo
                    4 Deckung
    @BgBudgetID:    ID des Budgets
    @BgPositionID:  ID der Position
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================*/
CREATE FUNCTION dbo.fnBgSpezkonto
(
  @BgSpezkontoID  INT,
  @ReturnTyp      INT = 3,
  @BgBudgetID     INT = NULL,
  @BgPositionID   INT = NULL
)
RETURNS MONEY
AS BEGIN

  DECLARE @FaLeistungID       INT,
          @StartSaldo         MONEY,
          @BgSpezkontoTypCode INT,
          @OhneEinzelzahlung  BIT,
          @Gutschrift         MONEY,
          @Belastung          MONEY;

  DECLARE @BgBudget TABLE (
    BgBudgetID INT NOT NULL,
    Verbucht   BIT NOT NULL,
    Datum      DATETIME NOT NULL
  );

  SELECT
    @FaLeistungID       = SSK.FaLeistungID,
    @StartSaldo         = SSK.StartSaldo,
    @BgSpezkontoTypCode = SSK.BgSpezkontoTypCode,
    @OhneEinzelzahlung  = SSK.OhneEinzelzahlung
  FROM dbo.BgSpezkonto SSK WITH (READUNCOMMITTED) 
  WHERE SSK.BgSpezkontoID = @BgSpezkontoID;

  -- Berücksichtigte Budget
  INSERT INTO @BgBudget (BgBudgetID, Verbucht, Datum)
    SELECT 
      BgBudgetID,
      CASE
        WHEN BBG.BgBewilligungStatusCode = 5 THEN 1
        WHEN EXISTS (SELECT TOP 1 1
                     FROM dbo.KbBuchung                   BUC WITH (READUNCOMMITTED) 
                       INNER JOIN dbo.KbBuchungKostenart  BUK WITH (READUNCOMMITTED) ON BUK.KbBuchungID  = BUC.KbBuchungID
                     WHERE BUC.BgBudgetID = BBG.BgBudgetID
                       AND BUC.KbBuchungTypCode IN (1, 2, 3, 4) /* Budget, Manuell, Automatisch, Ausgleich */                     
                       AND BUC.KbBuchungStatusCode NOT IN (1, 7, 8) -- vorbereitet, gesperrt, storniert
                    ) THEN 1
        ELSE 0
      END, 
      dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1)
    FROM dbo.BgFinanzplan      SFP WITH (READUNCOMMITTED) 
      INNER JOIN dbo.BgBudget  BBG WITH (READUNCOMMITTED) ON BBG.BgFinanzplanID = SFP.BgFinanzplanID
    WHERE SFP.FaLeistungID = @FaLeistungID
      AND BBG.MasterBudget = 0;

  IF @BgBudgetID IS NULL
  BEGIN
    DELETE FROM @BgBudget WHERE Verbucht = 0;
  END
  ELSE 
  BEGIN
    DELETE FROM @BgBudget
    WHERE Verbucht = 0 
      AND Datum < (SELECT MAX(Datum) FROM @BgBudget WHERE Verbucht = 1)
      AND (@ReturnTyp <> 4 OR BgBudgetID <> @BgBudgetID);

    DELETE FROM @BgBudget WHERE Datum > (SELECT Datum FROM @BgBudget WHERE BgBudgetID = @BgBudgetID);
  END;

  -- Berechnung
  SELECT
    @Gutschrift = ISNULL(
      (SELECT ISNULL(SUM(BPO.BetragRechnung), $0.00)
       FROM @BgBudget                 BBG
         INNER JOIN dbo.vwBgPosition  BPO WITH (READUNCOMMITTED) ON BPO.BgBudgetID = BBG.BgBudgetID
       WHERE BPO.BgSpezkontoID = SSK.BgSpezkontoID
         AND (BPO.BgKategorieCode IN (1, 2, 3, 6)  --Einnahmen, Ausgaben, Abzahlung, Vorabzug
               OR (BPO.BgKategorieCode = 100 AND BgBewilligungStatusCode = 5) -- Zusätzliche Leistung
             )
      ) + 
      (SELECT ISNULL(SUM(Betrag), $0.00)
       FROM dbo.BgSpezkontoAbschluss WITH (READUNCOMMITTED)
       WHERE BgSpezkontoID = SSK.BgSpezkontoID
       AND @BgBudgetID IS NULL)-- nur wenn @BgBudgetID NULL ist, soll Abschlussposition berücksichtigt werden
    , $0.00),
    @Belastung  = ISNULL(
      (SELECT SUM(BPO.Betrag)
       FROM @BgBudget                 BBG
         INNER JOIN dbo.BgPosition    BPO WITH (READUNCOMMITTED) ON BPO.BgBudgetID = BBG.BgBudgetID
       WHERE BPO.BgSpezkontoID = SSK.BgSpezkontoID AND BPO.BgKategorieCode = 101
         AND BPO.BgPositionID <> IsNull(@BgPositionID, 0))
    , $0.00)
  FROM dbo.BgSpezkonto  SSK WITH (READUNCOMMITTED) 
  WHERE SSK.BgSpezkontoID = @BgSpezkontoID;

  IF @ReturnTyp = 1
    RETURN @Gutschrift
  ELSE IF @ReturnTyp = 2
    RETURN @Belastung
  ELSE IF @ReturnTyp = 3 
  BEGIN
    IF @BgSpezkontoTypCode IN (1, 2)
      RETURN @StartSaldo + @Gutschrift - @Belastung
    ELSE IF @OhneEinzelzahlung = 1
      RETURN @StartSaldo + @Belastung - @Gutschrift
    ELSE
      RETURN @StartSaldo - @Gutschrift
  END 
  ELSE IF @ReturnTyp = 4 
  BEGIN
    IF @BgSpezkontoTypCode IN (1, 2)
      RETURN @StartSaldo + @Gutschrift - @Belastung
    ELSE IF @OhneEinzelzahlung = 1
      RETURN $0.00
    ELSE
      RETURN @StartSaldo - @Belastung
  END;

  RETURN $0.00;
END;
GO