SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spWhSpezkonto_UpdateBudget;
GO
/*===============================================================================================
  $Revision: 7
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Positionen von Budgets die einen Spezialkonto verwenden aktualisieren
    @BgSpezkontoID:  ID des Spezialkonto
    @BgFinanzplanID: ID des Finanzplanes wenn nur einen Finanzplan angepasst werden muss
    @BgBudgetID:     ID des Budgets wenn nur einen Budget angepasst werden muss
  -
  RETURNS: -
  -
  TEST:    EXEC dbo.spWhSpezkonto_UpdateBudget 59695
           EXEC dbo.spWhSpezkonto_UpdateBudget 59695, 1, 2
           EXEC dbo.spWhSpezkonto_UpdateBudget 59695, 1
=================================================================================================*/
CREATE PROCEDURE dbo.spWhSpezkonto_UpdateBudget
(
  @BgSpezkontoID   INT,
  @BgFinanzplanID  INT = NULL,
  @BgBudgetID      INT = NULL
)
AS BEGIN
  SET NOCOUNT ON;

  DECLARE @BgBudget TABLE (
    BgFinanzplanID          INT NOT NULL,
    BgBudgetID              INT NOT NULL,
    MasterBudget            BIT NOT NULL,
    Jahr                    INT NULL,
    Monat                   INT NULL,
    BgBewilligungStatusCode INT NOT NULL,
    Spezkonto               BIT NOT NULL
  );
  
  IF @BgSpezkontoID IS NULL
  BEGIN
    RAISERROR('Parameter @BgSpezkontoID darf nicht NULL sein', 18, 1);
  END;

  DECLARE @FaLeistungID       INT,
          @BgKategorieCode    INT,
          @BgSpezkontoTypCode INT,
          @DatumVon           DATETIME,
          @DatumBis           DATETIME,
          @Inaktiv            BIT;

  -- Das Enddatum aktualisieren, damit keine Einträge wegen eines zu frühen DatumBis nicht erstellt werden
  UPDATE dbo.BgSpezkonto
  SET DatumBis = dbo.fnShGetSpezkontoEnddatum(BgSpezkontoID, DatumVon, StartSaldo, BetragProMonat, Inaktiv, KuerzungLaufzeitMonate)
  WHERE BgSpezkontoID = @BgSpezkontoID
    AND BgSpezkontoTypCode IN (3,4); -- Enddatum nur bei Abzahlung und Kürzung automatisch berechnen

  SELECT
    @FaLeistungID       = FaLeistungID,
    @BgKategorieCode    = CASE BgSpezkontoTypCode
                            WHEN 1 THEN 2  -- Ausgabekonto
                            WHEN 2 THEN 6  -- Vorabzugskonto
                            WHEN 3 THEN 3  -- Abzahlungskonto
                            WHEN 4 THEN 4  -- Kürzungen
                            ELSE NULL
                          END,
    @BgSpezkontoTypCode = BgSpezkontoTypCode,
    @DatumVon           = DatumVon,
    @DatumBis           = DatumBis,
    @Inaktiv            = Inaktiv
  FROM dbo.BgSpezkonto WITH (READUNCOMMITTED) 
  WHERE BgSpezkontoID = @BgSpezkontoID;

  -- Zu aktualisierende Master- / Monatsbudgets suchen
  INSERT INTO @BgBudget (BgFinanzplanID, BgBudgetID, MasterBudget, Jahr, Monat, BgBewilligungStatusCode, Spezkonto)
    SELECT SFP.BgFinanzplanID, BBG.BgBudgetID, BBG.MasterBudget, Jahr, Monat, BBG.BgBewilligungStatusCode, 0
    FROM dbo.BgFinanzplan     SFP WITH (READUNCOMMITTED) 
      INNER JOIN dbo.BgBudget BBG WITH (READUNCOMMITTED) ON BBG.BgFinanzplanID = SFP.BgFinanzplanID
    WHERE SFP.FaLeistungID = @FaLeistungID
      AND (BBG.BgBewilligungStatusCode < 5 OR (BBG.MasterBudget = 1 AND BBG.BgBewilligungStatusCode = 5));

  DELETE FROM @BgBudget WHERE BgFinanzplanID != @BgFinanzplanID;
  DELETE FROM @BgBudget WHERE BgBudgetID != @BgBudgetID;

  UPDATE TMP
    SET Spezkonto = 1
  FROM @BgBudget                 TMP
    INNER JOIN dbo.BgFinanzplan  SFP WITH (READUNCOMMITTED) ON SFP.BgFinanzplanID = TMP.BgFinanzplanID
    INNER JOIN dbo.BgBudget      BBG WITH (READUNCOMMITTED) ON BBG.BgBudgetID     = TMP.BgBudgetID
  WHERE ((BBG.MasterBudget = 1 AND ISNULL(SFP.DatumVon, SFP.GeplantVon) < ISNULL(@DatumBis, '20790606') AND COALESCE(SFP.DatumBis, SFP.GeplantBis, '20790606') > @DatumVon ) OR
         (BBG.MasterBudget = 0 AND dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 15) BETWEEN @DatumVon AND ISNULL(@DatumBis, '20790606') ))
        AND @Inaktiv = 0;

  -- Master- / Monatsbudget aktualisieren
  IF @BgKategorieCode = 2 -- Ausgabekonto
  BEGIN
    UPDATE BPO
      SET BgSpezkontoID = NULL
    FROM @BgBudget              BBG
      INNER JOIN dbo.BgPosition BPO ON BPO.BgBudgetID = BBG.BgBudgetID
    WHERE BPO.BgSpezkontoID = @BgSpezkontoID 
      AND BBG.Spezkonto = 0;

    RETURN;
  END;

  -- löschen
  DELETE BPO
  FROM @BgBudget          BBG
    INNER JOIN BgPosition BPO ON BPO.BgBudgetID = BBG.BgBudgetID
  WHERE BPO.BgSpezkontoID = @BgSpezkontoID 
    AND BBG.Spezkonto = 0
    AND BPO.BgKategorieCode IN (3, 4, 6);

  -- einfügen
  INSERT INTO BgPosition (BgBudgetID, BgKategorieCode, Betrag, BgSpezkontoID, Buchungstext, BaPersonID)
    SELECT BBG.BgBudgetID, 
           @BgKategorieCode, 
           Betrag = CASE SSK.BgSpezkontoTypCode 
                      WHEN 4 THEN dbo.fnShGetKuerzungBetrag(BBG.BgFinanzplanID, SSK.KuerzungAnteilGBL) 
                      ELSE SSK.BetragProMonat 
                    END,
           SSK.BgSpezkontoID, 
           SSK.NameSpezkonto, 
           SSK.BaPersonID
    FROM @BgBudget               BBG
      INNER JOIN dbo.BgSpezkonto SSK WITH (READUNCOMMITTED) ON SSK.BgSpezkontoID = @BgSpezkontoID
    WHERE BBG.Spezkonto = 1
      AND (MasterBudget = 0 OR @BgKategorieCode IN (6))
      AND NOT EXISTS (SELECT TOP 1 1 
                      FROM dbo.BgPosition WITH (READUNCOMMITTED)
                      WHERE BgBudgetID = BBG.BgBudgetID 
                        AND BgSpezkontoID = @BgSpezkontoID
                        AND BgKategorieCode = @BgKategorieCode);

  -- aktualisieren
  UPDATE BPO
    SET Betrag         = CASE 
                           WHEN BBG.MasterBudget = 1 AND BBG.BgBewilligungStatusCode <= 5  
                             THEN ISNULL(CASE SSK.BgSpezkontoTypCode 
                                           WHEN 4 THEN dbo.fnShGetKuerzungBetrag(BBG.BgFinanzplanID, SSK.KuerzungAnteilGBL) 
                                           ELSE SSK.BetragProMonat 
                                         END, Betrag) 
                           WHEN BBG.MasterBudget = 0 AND BBG.BgBewilligungStatusCode <= 5  AND SSK.BgSpezkontoTypCode = 4 
                             THEN CASE BPO.Betrag 
                                    WHEN 0 THEN 0 
                                    ELSE dbo.fnShGetKuerzungBetrag(BBG.BgFinanzplanID, SSK.KuerzungAnteilGBL) 
                                  END
                           ELSE Betrag
                         END,
        DatumVon       = CASE WHEN BBG.MasterBudget = 1 AND BBG.BgBewilligungStatusCode <= 5  THEN SSK.DatumVon ELSE NULL END,
        DatumBis       = CASE WHEN BBG.MasterBudget = 1 AND BBG.BgBewilligungStatusCode <= 5  THEN SSK.DatumBis ELSE NULL END,
        Buchungstext   = SSK.NameSpezkonto,
        BaPersonID     = SSK.BaPersonID,
        VerwPeriodeVon = CASE WHEN BBG.MasterBudget = 0 THEN dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1) END,
        VerwPeriodeBis = CASE WHEN BBG.MasterBudget = 0 THEN dbo.fnLastDayOf(dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1)) END
  FROM @BgBudget            BBG
    INNER JOIN BgPosition   BPO ON BPO.BgBudgetID = BBG.BgBudgetID
    INNER JOIN BgSpezkonto  SSK ON SSK.BgSpezkontoID = BPO.BgSpezkontoID
  WHERE BPO.BgKategorieCode IN (3, 4, 6)
    AND BPO.BgSpezkontoID = @BgSpezkontoID 
    AND BBG.Spezkonto = 1;

  -- Monatsbudget - Abzahlungskonto
  DECLARE cAbzahlungskonto CURSOR FAST_FORWARD FOR
    SELECT BgBudgetID
    FROM @BgBudget
    WHERE MasterBudget = 0 
      AND BgBewilligungStatusCode < 5;

  OPEN cAbzahlungskonto;
  WHILE (1 = 1)
  BEGIN
    FETCH NEXT FROM cAbzahlungskonto INTO @BgBudgetID;
    IF @@FETCH_STATUS != 0 BREAK;

    PRINT('EXECUTE spWhBudget_Abzahlungskonto '+ CONVERT(VARCHAR, @BgBudgetID));
    EXECUTE spWhBudget_Abzahlungskonto @BgBudgetID;
  END;
  CLOSE cAbzahlungskonto;
  DEALLOCATE cAbzahlungskonto;

  -- Das Enddatum auch aktualisieren, falls keine Monatsbudgets vorhanden sind.
  UPDATE BgSpezkonto
  SET DatumBis = dbo.fnShGetSpezkontoEnddatum(BgSpezkontoID, DatumVon, StartSaldo, BetragProMonat, Inaktiv, KuerzungLaufzeitMonate)
  WHERE BgSpezkontoID = @BgSpezkontoID
    AND BgSpezkontoTypCode IN (3,4); -- Enddatum nur bei Abzahlung und Kürzung automatisch berechnen

END;
GO