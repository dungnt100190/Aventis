SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spWhBudget_Abzahlungskonto;
GO
/*===============================================================================================
  $Revision: 9
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Positionen vom Budget die ein Abzahlungskonto verwenden aktualisieren
    @BgBudgetID: ID des Budgets zu anpassen
  -
  RETURNS: -
  -
  TEST:    EXEC dbo.spWhBudget_Abzahlungskonto 291379
=================================================================================================*/
CREATE PROCEDURE dbo.spWhBudget_Abzahlungskonto
(
  @BgBudgetID  INT
)
AS
BEGIN
  SET NOCOUNT ON;

  DECLARE @FaLeistungID   INT,
          @DatumBudget    DATETIME,
          @BgFinanzplanID INT;

  SELECT
    @FaLeistungID   = SFP.FaLeistungID,
    @DatumBudget    = dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1),
    @BgFinanzplanID = BBG.BgFinanzplanID
  FROM dbo.BgBudget              BBG WITH (READUNCOMMITTED) 
    INNER JOIN dbo.BgFinanzplan  SFP WITH (READUNCOMMITTED) ON SFP.BgFinanzplanID = BBG.BgFinanzplanID
  WHERE BBG.BgBudgetID = @BgBudgetID 
    AND BBG.MasterBudget = 0 
    AND BBG.BgBewilligungStatusCode < 5;

  IF @FaLeistungID IS NULL RETURN;

  UPDATE BgSpezkonto
  SET DatumBis = dbo.fnShGetSpezkontoEnddatum(BgSpezkontoID, DatumVon, StartSaldo, BetragProMonat, 0, KuerzungLaufzeitMonate)
  WHERE FaLeistungID = @FaLeistungID
    AND BgSpezkontoTypCode IN (3, 4)
    AND DatumVon <= @DatumBudget;

  -- Abzahlungskonto
  DECLARE @BgSpezkontoID          INT,
          @BetragProMonat         MONEY,
          @SpezKontoSaldo         MONEY,
          @BudgetBetrag           MONEY,
          @DatumVon               DATETIME,
          @DatumBis               DATETIME,
          @BgKategorieCode        INT,
          @KuerzungAnteilGBL      MONEY,
          @KuerzungLaufzeitMonate INT,
          @Inaktiv                BIT,
          @AnzahlBgPositionen     INT,
          @AbschlussgrundCode     INT;

  DECLARE cAbzahlungen CURSOR FAST_FORWARD FOR
    SELECT
      SSK.BgSpezkontoID,
      SSK.BetragProMonat,
      dbo.fnBgSpezkonto(SSK.BgSpezkontoID, 3, @BgBudgetID, DEFAULT),
      BPO.BetragRechnung,
      SSK.DatumVon,
      SSK.DatumBis,
      BgKategorieCode    = CASE SSK.BgSpezkontoTypCode
                             WHEN 3 THEN 3  -- Abzahlungskonto
                             WHEN 4 THEN 4  -- Kürzungen
                             ELSE NULL
                           END,
      SSK.KuerzungAnteilGBL,
      SSK.KuerzungLaufzeitMonate,
      SSK.Inaktiv,
      dbo.fnBgGetPositionenCount(SSK.BgSpezkontoID, @BgBudgetID),
      SSK.AbschlussgrundCode
    FROM dbo.BgSpezkonto          SSK WITH (READUNCOMMITTED) 
      LEFT JOIN dbo.vwBgPosition  BPO ON BPO.BgBudgetID = @BgBudgetID 
                                     AND BPO.BgKategorieCode = SSK.BgSpezkontoTypCode --Da 3->3 und 4->4
                                     AND BPO.BgSpezkontoID = SSK.BgSpezkontoID
    WHERE SSK.FaLeistungID = @FaLeistungID
      AND SSK.BgSpezkontoTypCode IN (3, 4)
      AND SSK.DatumVon <= @DatumBudget;

  OPEN cAbzahlungen;
  WHILE (1 = 1) 
  BEGIN
    FETCH NEXT FROM cAbzahlungen INTO @BgSpezkontoID, @BetragProMonat, @SpezKontoSaldo, @BudgetBetrag, @DatumVon, @DatumBis, @BgKategorieCode, @KuerzungAnteilGBL, @KuerzungLaufzeitMonate, @Inaktiv, @AnzahlBgPositionen, @AbschlussgrundCode;
    IF @@FETCH_STATUS < 0 BREAK;

    PRINT('@BgSpezkontoID = ' + CONVERT(VARCHAR, @BgSpezkontoID));
    
    IF (@Inaktiv = 0 
        AND @DatumBudget BETWEEN @DatumVon AND ISNULL(@DatumBis, @DatumBudget)) --Da EndDatum jetzt korrekt berechnet wird, können wir ausschliesslich aufs EndDatum gehen
    BEGIN
      DECLARE @Betrag  MONEY;
      IF (@BgKategorieCode = 3)
      BEGIN
        SET @Betrag = CONVERT(MONEY, dbo.fnMIN(@SpezKontoSaldo + ISNULL(@BudgetBetrag, $0.00), @BetragProMonat));
      END
      ELSE IF (@BgKategorieCode = 4)
      BEGIN
        SET @Betrag = dbo.fnShGetKuerzungBetrag(@BgFinanzplanID, @KuerzungAnteilGBL);
      END
      ELSE 
      BEGIN
        RAISERROR('Ungültiges Spezialkonto', 18, 1);
      END;
      
      IF (@AbschlussgrundCode IS NOT NULL)
      BEGIN
        -- abgeschlossen
        DELETE BPO
        FROM dbo.BgPosition           BPO
        WHERE BPO.BgBudgetID = @BgBudgetID 
          AND BPO.BgKategorieCode = @BgKategorieCode
          AND BPO.BgSpezkontoID = @BgSpezkontoID;
        PRINT('    Deleted BgPosition (ended) count: ' + CONVERT(VARCHAR, @@ROWCOUNT));
        
      END
      ELSE IF (@Betrag <= 0 AND NOT (@BgKategorieCode = 4 AND @BudgetBetrag = 0))
      BEGIN
        DELETE POS
        FROM dbo.BgPosition POS
        WHERE BgBudgetID = @BgBudgetID 
          AND BgKategorieCode = @BgKategorieCode 
          AND BgSpezkontoID = @BgSpezkontoID;
        PRINT('    Deleted BgPosition count: ' + CONVERT(VARCHAR, @@ROWCOUNT));
          
      END 
      ELSE IF (@BudgetBetrag IS NULL)
      BEGIN -- Noch keine Budgetposition vorhanden
        INSERT INTO BgPosition (BgBudgetID, BgKategorieCode, BgSpezkontoID, Betrag, Buchungstext, BaPersonID, VerwPeriodeVon, VerwPeriodeBis)
          SELECT @BgBudgetID, @BgKategorieCode, @BgSpezkontoID, @Betrag, SSK.NameSpezkonto, SSK.BaPersonID, @DatumBudget, dbo.fnLastDayOf(@DatumBudget)
          FROM BgSpezkonto   SSK
          WHERE SSK.BgSpezkontoID = @BgSpezkontoID;
        PRINT('    Inserted BgPosition count: ' + CONVERT(VARCHAR, @@ROWCOUNT));
      
      END 
      ELSE 
      BEGIN
        UPDATE BPO
          SET
            Reduktion    = CASE WHEN Reduktion <> $0.00 THEN @Betrag - Betrag + Reduktion ELSE Reduktion END, -- wenn der monatl. Abzahl-Betrag im SpezKonto angepasst wird, soll ein im Budget veränderter Betrag nicht ändern. Deshalb müssen wir die Reduktion entsprechend anpassen
            Betrag       = CASE WHEN SSK.BgSpezkontoTypCode = 4 AND Betrag = 0 THEN 0 ELSE @Betrag END,
            Buchungstext = SSK.NameSpezkonto,
            BaPersonID   = SSK.BaPersonID,
            VerwPeriodeVon = @DatumBudget,
            VerwPeriodeBis = dbo.fnLastDayOf(@DatumBudget)
        FROM dbo.BgPosition           BPO
          INNER JOIN dbo.BgSpezkonto  SSK ON SSK.BgSpezkontoID = BPO.BgSpezkontoID
        WHERE BPO.BgBudgetID = @BgBudgetID AND BPO.BgKategorieCode = @BgKategorieCode
          AND BPO.BgSpezkontoID = @BgSpezkontoID;
        PRINT('    Updated BgPosition count: ' + CONVERT(VARCHAR, @@ROWCOUNT));
      END;
      
    END -- end aktiv
    ELSE
    BEGIN
      -- inaktiv
      DELETE BPO
      FROM dbo.BgPosition           BPO
      WHERE BPO.BgBudgetID = @BgBudgetID 
        AND BPO.BgKategorieCode = @BgKategorieCode
        AND BPO.BgSpezkontoID = @BgSpezkontoID;
      PRINT('    Deleted BgPosition (inactive) count: ' + CONVERT(VARCHAR, @@ROWCOUNT));
    END;

    -- durch (in)aktivierte Verrechnungen kann das DatumBis des Spezialkonto geändert haben, berechnen wir es neu
    IF (@Betrag > 0)
    BEGIN
      UPDATE BgSpezkonto
      SET DatumBis = dbo.fnShGetSpezkontoEnddatum(BgSpezkontoID, DatumVon, StartSaldo, BetragProMonat, 0, KuerzungLaufzeitMonate)
      WHERE BgSpezkontoID = @BgSpezkontoID;
    END;
  END;

  CLOSE cAbzahlungen;
  DEALLOCATE cAbzahlungen;
END;
GO