SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnBgSpezkonto
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Functions/fnBgSpezkonto.sql $
  $Author: Mminder $
  $Modtime: 2.09.10 14:07 $
  $Revision: 8 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Functions/fnBgSpezkonto.sql $
 * 
 * 8     24.09.10 17:35 Mminder
 * #???? Enddatumsberechnung Abzahlungskonto verbessert
 * 
 * 7     11.12.09 10:22 Lloreggia
 * Header aktualisiert, ALTER -> CREATE
 * 
 * 6     27.08.09 16:07 Mmarghitola
 * #4863: Änderung aus #4863 wieder entfernen - Die Änderung kam nie auf
 * Produktion
 * 
 * 5     17.08.09 15:55 Mmarghitola
 * #4863, #5172: Korrekturen für Spezialfälle (GBL auf Ausgabekonto bei
 * roter Verrechnung, Sotrnierte Verrechnung).
 * 
 * 3     28.05.09 8:25 Mmarghitola
 * #4045: Gesperrte Positionen nicht im Saldo mitberechnen
 * 
 * 2     14.05.09 10:25 Mweber
 * 
 * 1     10.09.08 12:24 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION [dbo].[fnBgSpezkonto]
 (@BgSpezkontoID  int,
  @ReturnTyp      int = 3,
  @BgBudgetID     int = NULL,
  @BgPositionID   int = NULL)
 RETURNS money
AS BEGIN
 /* test
  * ReturnTyp:
  *  1 Gutschriften
  *  2 Belastungen
  *  3 Saldo  (für Ausgabekonto/Vorabzugkonto)
  *  4 Deckung (für Verrechnungskonto)
  */

  DECLARE @FaLeistungID        int,
          @StartSaldo          money,
          @BgSpezkontoTypCode  int,
          @OhneEinzelzahlung   bit,
          @Gutschrift          money,
          @Belastung           money

  DECLARE @BgBudget TABLE (
    BgBudgetID        int NOT NULL,
    Verbucht          bit NOT NULL,
    Datum             datetime NOT NULL,
    GBLPositionsArtID int
  )

  SELECT
    @FaLeistungID       = SSK.FaLeistungID,
    @StartSaldo         = SSK.StartSaldo,
    @BgSpezkontoTypCode = BgSpezkontoTypCode,
    @OhneEinzelzahlung  = SSK.OhneEinzelzahlung
  FROM dbo.BgSpezkonto  SSK WITH (READUNCOMMITTED)
  WHERE SSK.BgSpezkontoID = @BgSpezkontoID

  -- Berücksichtigte Budget
  INSERT INTO @BgBudget (BgBudgetID, Verbucht, Datum, GBLPositionsArtID)
    SELECT BgBudgetID,
      CASE
        WHEN BBG.BgBewilligungStatusCode = 5 THEN 1
        WHEN EXISTS (SELECT TOP 1 1
                     FROM dbo.KbBuchung                   BUC WITH (READUNCOMMITTED)
                       INNER JOIN dbo.KbBuchungKostenart  BUK WITH (READUNCOMMITTED) ON BUK.KbBuchungID  = BUC.KbBuchungID
                     WHERE BUC.BgBudgetID = BBG.BgBudgetID
                       AND BUC.KbBuchungTypCode IN (1, 2, 3, 4) /* Budget, Manuell, Automatisch, Ausgleich */
                       AND BUC.KbBuchungStatusCode NOT IN (1, 7, 8, 9) -- vorbereitet, gesperrt, storniert, Rückläufer
                    ) THEN 1
        ELSE 0
      END, dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1), SFP.WhGrundbedarfTypCode
    FROM dbo.BgFinanzplan      SFP WITH (READUNCOMMITTED)
      INNER JOIN dbo.BgBudget  BBG WITH (READUNCOMMITTED) ON BBG.BgFinanzplanID = SFP.BgFinanzplanID
    WHERE SFP.FaLeistungID = @FaLeistungID
      AND BBG.MasterBudget = 0

  IF @BgBudgetID IS NULL
    DELETE FROM @BgBudget WHERE Verbucht = 0
  ELSE BEGIN
    DELETE FROM @BgBudget
    WHERE Verbucht = 0 AND 
          Datum < (SELECT MAX(Datum) FROM @BgBudget WHERE Verbucht = 1) AND
          (@ReturnTyp <> 4 OR BgBudgetID <> @BgBudgetID) AND
          @BgSpezkontoTypCode <> 3 -- zumindest bei Verrechnungen dürfen Verrechnungs-Positionen in grauen Budgets zwischen grünen nicht ignoriert werden

    DELETE FROM @BgBudget
    WHERE Datum > (SELECT Datum FROM @BgBudget WHERE BgBudgetID = @BgBudgetID) AND
          (@BgSpezkontoTypCode <> 3 OR Verbucht = 0) -- bei abzahlungskonti die zukünftigen verbuchten auch berücksichtigen, sonst kann der saldo negativ werden
  END

-- Berechnung
  SELECT
    @Gutschrift = IsNull(
      (SELECT SUM(IsNull(BPO.BetragGBLAufAusgabekonto, BPO.BetragRechnung))
       FROM @BgBudget BBG
         INNER JOIN dbo.vwBgPosition BPO ON BPO.BgBudgetID = BBG.BgBudgetID
       WHERE BPO.BgSpezkontoID = SSK.BgSpezkontoID
         AND (BPO.BgKategorieCode IN (2, 3, 6) -- Ausgaben, Abzahlung, Vorabzug
               OR (BPO.BgKategorieCode = 100 AND BgBewilligungStatusCode = 5) -- Zusätzliche Leistung
             )
            AND BPO.BgBewilligungStatusCode <> 9 -- gesperrt
        AND NOT EXISTS (SELECT BUC.KbBuchungID
                      FROM dbo.KbBuchungKostenart KBA
                          INNER JOIN dbo.KbBuchung BUC ON BUC.KbBuchungID = KBA.KbBuchungID
                      WHERE KBA.BgPositionID = BPO.BgPositionID AND BUC.KbBuchungStatusCode IN (7, 8, 9)) -- gesperrt, storniert, Rückläufer
      )
    , $0.00),
    @Belastung = IsNull(
      (SELECT SUM(BPO.Betrag)
       FROM @BgBudget BBG
          INNER JOIN dbo.BgPosition BPO WITH (READUNCOMMITTED) ON BPO.BgBudgetID = BBG.BgBudgetID
       WHERE BPO.BgSpezkontoID = SSK.BgSpezkontoID AND BPO.BgKategorieCode = 101
          AND BPO.BgPositionID <> IsNull(@BgPositionID, 0)
          AND NOT EXISTS (SELECT BUC.KbBuchungID
                          FROM dbo.KbBuchungKostenart KBA
                            INNER JOIN dbo.KbBuchung BUC ON BUC.KbBuchungID = KBA.KbBuchungID
                          WHERE KBA.BgPositionID = BPO.BgPositionID AND BUC.KbBuchungStatusCode IN (7, 8, 9)) -- gesperrt, storniert, Rückläufer
      )
    , $0.00)
  FROM dbo.BgSpezkonto SSK WITH (READUNCOMMITTED)
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