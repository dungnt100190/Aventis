SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhBudget_Abzahlungskonto
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Stored Procedures/spWhBudget_Abzahlungskonto.sql $
  $Author: Mminder $
  $Modtime: 2.09.10 15:25 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Stored Procedures/spWhBudget_Abzahlungskonto.sql $
 * 
 * 7     24.09.10 17:35 Mminder
 * #???? Enddatumsberechnung Abzahlungskonto verbessert
 * 
 * 6     11.12.09 11:58 Lloreggia
 * Header aktualisiert
 * 
 * 5     10.08.09 10:06 Mminder
 * #5134: fnLastDateOf durch fnLastDayOf ersetzt
 * 
 * 4     6.08.09 16:25 Mminder
 * #5134: Automatisch eingefügte Verrechnungspositionen beinhalten nun
 * Buchungstext und Verwendungsperiode
 * 
 * 3     7.04.09 15:13 Mminder
 * #97: Update DatumBis des Verrechnungskonto wenn Verrechnungspositionen
 * geändert werden
 * 
 * 2     10.03.09 17:58 Rstahel
 * Abgleich der Stored Procedures aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE PROCEDURE [dbo].[spWhBudget_Abzahlungskonto]
(
  @BgBudgetID INT
)
AS BEGIN
  SET NOCOUNT ON;

  DECLARE @FaLeistungID INT,
          @DatumBudget  DATETIME;

  SELECT
    @FaLeistungID = SFP.FaLeistungID,
    @DatumBudget  = dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1)
  FROM dbo.BgBudget              BBG WITH (READUNCOMMITTED)
    INNER JOIN dbo.BgFinanzplan  SFP WITH (READUNCOMMITTED) ON SFP.BgFinanzplanID = BBG.BgFinanzplanID
  WHERE BBG.BgBudgetID = @BgBudgetID
    AND BBG.MasterBudget = 0
	AND BBG.BgBewilligungStatusCode < 5

  IF @FaLeistungID IS NULL RETURN

  UPDATE BgSpezkonto
  SET DatumBis = dbo.[fnWhBudget_GetSpezkontoEnddatum](BgSpezkontoID, DatumVon, StartSaldo, BetragProMonat, Inaktiv)
  WHERE FaLeistungID = @FaLeistungID
    AND BgSpezkontoTypCode = 3
    AND DatumVon <= @DatumBudget

  -- Abzahlungskonto
  DECLARE @BgSpezkontoID    INT,
          @BetragProMonat   MONEY,
          @SpezKontoSaldo   MONEY,
          @BudgetBetrag     MONEY,
          @Reduktion        MONEY,
          @DatumVon         DATETIME,
          @DatumBis         DATETIME,
          @Inaktiv          BIT,
          @StartSaldo       MONEY,
          @NameSpezkonto    VARCHAR(100)

  DECLARE cAbzahlungen CURSOR FAST_FORWARD FOR
    SELECT SSK.BgSpezkontoID, SSK.BetragProMonat,
           dbo.fnBgSpezkonto(SSK.BgSpezkontoID, 3, @BgBudgetID, NULL),
           BPO.BetragRechnung,
           ISNULL(BPO.Reduktion, $0.00),
           SSK.DatumVon,
           SSK.DatumBis,
           SSK.Inaktiv,
           SSK.StartSaldo,
           SSK.NameSpezkonto
    FROM dbo.BgSpezkonto          SSK WITH (READUNCOMMITTED)
      LEFT JOIN dbo.vwBgPosition  BPO ON BPO.BgBudgetID = @BgBudgetID
	                                 AND BPO.BgKategorieCode = 3
									 AND BPO.BgSpezkontoID = SSK.BgSpezkontoID
    WHERE SSK.FaLeistungID = @FaLeistungID
      AND SSK.BgSpezkontoTypCode = 3
      AND SSK.DatumVon <= @DatumBudget
      AND EXISTS (SELECT TOP 1 1    --Nur Verrechnungen auf aktiven Ausgabe-Positionsarten erstellen
                  FROM BgPositionsart
                  WHERE BgKostenartID = SSK.BgKostenartID
                  AND BgKategorieCode IN (2, 3))

  OPEN cAbzahlungen
  WHILE (1 = 1) BEGIN
    FETCH NEXT FROM cAbzahlungen INTO @BgSpezkontoID, @BetragProMonat, @SpezKontoSaldo, @BudgetBetrag, @Reduktion, @DatumVon, @DatumBis, @Inaktiv, @StartSaldo, @NameSpezkonto
    IF @@FETCH_STATUS < 0 BREAK

    IF @DatumBudget BETWEEN @DatumVon AND IsNull(@DatumBis, @DatumBudget) BEGIN
      DECLARE @Betrag MONEY;
      IF @Inaktiv = 1
        SET @Betrag = $0.00;
      ELSE BEGIN
        SET @Betrag = CONVERT(money, dbo.fnMIN(@SpezKontoSaldo + IsNull(@BudgetBetrag, $0.00), @BetragProMonat))

        -- eine manuell angepasste Buchung soll unverändert bleiben. wenn also der betrag ändert, muss die reduktion mitziehen
        IF @Reduktion <> $0.00 BEGIN
          SET @Reduktion = @Betrag - @BudgetBetrag -- entspricht @Betrag(neu) - Betrag(bisher) + Reduktion(bisher)
        END;

        IF @Betrag - @Reduktion < $0.00 BEGIN -- ...sonst könnte die Budgetposition negativ werden
          SET @Reduktion = @Betrag; 
        END ELSE IF @SpezKontoSaldo + @BudgetBetrag - @Betrag + @Reduktion < $0.00 BEGIN -- kann durch Löschen eines Budgets auftreten
          SET @Reduktion = @Betrag - @BudgetBetrag - @SpezKontoSaldo
        END;
      END;

      IF @Betrag < 0 OR @Betrag = 0 AND @Inaktiv <> 1
        DELETE FROM BgPosition WHERE BgBudgetID = @BgBudgetID AND BgKategorieCode = 3 AND BgSpezkontoID = @BgSpezkontoID

      ELSE IF @BudgetBetrag IS NULL
        INSERT INTO BgPosition (BgBudgetID, BgKategorieCode, BgSpezkontoID, Betrag, Buchungstext, BaPersonID, VerwPeriodeVon, VerwPeriodeBis)
          SELECT @BgBudgetID, 3, @BgSpezkontoID, @Betrag, SSK.NameSpezkonto, SSK.BaPersonID, @DatumBudget, dbo.fnLastDayOf(@DatumBudget)
          FROM BgSpezkonto   SSK
          WHERE SSK.BgSpezkontoID = @BgSpezkontoID;
      ELSE
        UPDATE BgPosition
        SET    Betrag         = @Betrag,
               Reduktion      = @Reduktion,
               Buchungstext   = SSK.NameSpezkonto,
               BaPersonID     = SSK.BaPersonID,
               VerwPeriodeVon = @DatumBudget,
               VerwPeriodeBis = dbo.fnLastDayOf(@DatumBudget)
        FROM dbo.BgPosition           BPO
          INNER JOIN dbo.BgSpezkonto  SSK ON SSK.BgSpezkontoID = BPO.BgSpezkontoID
        WHERE  BPO.BgBudgetID      = @BgBudgetID
		   AND BPO.BgKategorieCode = 3
		   AND SSK.BgSpezkontoID   = @BgSpezkontoID
    END ELSE BEGIN
        -- inaktiv
        DELETE FROM BgPosition WHERE BgBudgetID = @BgBudgetID AND BgKategorieCode = 3 AND BgSpezkontoID = @BgSpezkontoID
    END

    -- durch (in)aktivierte Verrechnungen kann das DatumBis des Spezialkonto geändert haben, berechnen wir es neu
    IF @BetragProMonat > 0 BEGIN
      UPDATE BgSpezkonto
      SET DatumBis = dbo.[fnWhBudget_GetSpezkontoEnddatum](@BgSpezkontoID, @DatumVon, @StartSaldo, @BetragProMonat, @Inaktiv)
      WHERE BgSpezkontoID = @BgSpezkontoID
    END
  END

  CLOSE cAbzahlungen
  DEALLOCATE cAbzahlungen
END


GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
