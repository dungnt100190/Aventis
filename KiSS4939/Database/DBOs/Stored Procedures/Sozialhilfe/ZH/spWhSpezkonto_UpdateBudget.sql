SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhSpezkonto_UpdateBudget
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Stored Procedures/spWhSpezkonto_UpdateBudget.sql $
  $Author: Mminder $
  $Modtime: 2.09.10 15:02 $
  $Revision: 7 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Stored Procedures/spWhSpezkonto_UpdateBudget.sql $
 * 
 * 6     24.09.10 17:35 Mminder
 * #???? Enddatumsberechnung Abzahlungskonto verbessert
 * 
 * 5     11.12.09 12:51 Lloreggia
 * Header aktualisiert
 * 
 * 4     6.08.09 16:25 Mminder
 * #5134: Automatisch eingefügte Verrechnungspositionen beinhalten nun
 * Buchungstext und Verwendungsperiode
 * 
 * 3     29.06.09 14:37 Mmarghitola
 * Hinzufügen von fnIkKontoauszug
 * 
 * 2     10.03.09 17:59 Rstahel
 * Abgleich der Stored Procedures aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE PROCEDURE [dbo].[spWhSpezkonto_UpdateBudget]
(
  @BgSpezkontoID  INT,
  @BgFinanzplanID INT = NULL,
  @BgBudgetID     INT = NULL
)
AS BEGIN
  SET NOCOUNT ON;

  DECLARE @BgBudget TABLE (
    BgFinanzplanID           int      NOT NULL,
    BgBudgetID               int      NOT NULL,
    MasterBudget             bit      NOT NULL,
    BgBewilligungStatusCode  int      NOT NULL,
    Spezkonto                bit      NOT NULL,
    DatumBudget              datetime NOT NULL
  );

  IF @BgSpezkontoID IS NULL
  BEGIN
    RAISERROR('Parameter @BgSpezkontoID darf nicht NULL sein', 18, 1);
  END;


  DECLARE @FaLeistungID    INT,
          @BgKategorieCode INT,
          @BetragProMonat  MONEY,
          @DatumVon        DATETIME,
          @DatumBis        DATETIME,
          @Inaktiv         BIT,
		  @StartSaldo	   MONEY,
		  @NameSpezkonto   VARCHAR(100);

  -- Das Enddatum aktualisieren, damit keine Einträge wegen eines zu frühen DatumBis nicht erstellt werden
  UPDATE dbo.BgSpezkonto
  SET DatumBis = dbo.fnWhBudget_GetSpezkontoEnddatum(BgSpezkontoID, DatumVon, StartSaldo, BetragProMonat, Inaktiv)
  WHERE BgSpezkontoID = @BgSpezkontoID
    AND BgSpezkontoTypCode = 3; -- Enddatum nur bei Verrechnung automatisch berechnen

  SELECT
    @FaLeistungID = FaLeistungID,
    @BgKategorieCode = CASE BgSpezkontoTypCode
                        WHEN 1 THEN 2  -- Ausgabekonto
                        WHEN 2 THEN 6  -- Vorabzugskonto
                        WHEN 3 THEN 3  -- Abzahlungskonto
                        ELSE NULL
                      END,
    @BetragProMonat = BetragProMonat,
    @DatumVon       = DatumVon,
    @DatumBis       = DatumBis,
    @Inaktiv		= Inaktiv,
	@StartSaldo		= StartSaldo,
    @NameSpezkonto  = NameSpezkonto
  FROM dbo.BgSpezkonto WITH (READUNCOMMITTED)
  WHERE BgSpezkontoID = @BgSpezkontoID;

  -- Zu aktualisierende Master- / Monatsbudgets suchen
  INSERT INTO @BgBudget (BgFinanzplanID, BgBudgetID, MasterBudget, BgBewilligungStatusCode, Spezkonto, DatumBudget)
    SELECT SFP.BgFinanzplanID, BBG.BgBudgetID, BBG.MasterBudget, BBG.BgBewilligungStatusCode, 0, dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1)
    FROM dbo.BgFinanzplan        SFP WITH (READUNCOMMITTED)
      INNER JOIN dbo.BgBudget    BBG WITH (READUNCOMMITTED) ON BBG.BgFinanzplanID = SFP.BgFinanzplanID
    WHERE SFP.FaLeistungID = @FaLeistungID
      AND (BBG.BgBewilligungStatusCode < 5 OR (BBG.MasterBudget = 1 AND BBG.BgBewilligungStatusCode = 5));

  DELETE FROM @BgBudget WHERE BgFinanzplanID != @BgFinanzplanID;
  DELETE FROM @BgBudget WHERE BgBudgetID != @BgBudgetID;

  UPDATE TMP
    SET Spezkonto = 1
  FROM @BgBudget                TMP
    INNER JOIN dbo.BgFinanzplan SFP WITH (READUNCOMMITTED) ON SFP.BgFinanzplanID = TMP.BgFinanzplanID
    INNER JOIN dbo.BgBudget     BBG WITH (READUNCOMMITTED) ON BBG.BgBudgetID     = TMP.BgBudgetID
  WHERE ((BBG.MasterBudget = 1 AND BBG.BgBewilligungStatusCode <= 5 AND IsNull(SFP.DatumVon, SFP.GeplantVon) < IsNull(@DatumBis, '20790606') AND COALESCE(SFP.DatumBis, SFP.GeplantBis, '20790606') > @DatumVon ) OR
         (BBG.MasterBudget = 0 AND BBG.BgBewilligungStatusCode <  5 AND dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 15) BETWEEN @DatumVon AND IsNull(@DatumBis, '20790606') ));

  -- Master- / Monatsbudget aktualisieren
  IF @BgKategorieCode = 2
  BEGIN
    UPDATE BPO
      SET BgSpezkontoID = NULL
    FROM @BgBudget              BBG
      INNER JOIN dbo.BgPosition BPO WITH (READUNCOMMITTED) ON BPO.BgBudgetID = BBG.BgBudgetID
    WHERE BPO.BgSpezkontoID = @BgSpezkontoID
	  AND BBG.Spezkonto = 0;

    RETURN;
  END

  -- löschen
  DELETE BPO
  FROM @BgBudget              BBG
    INNER JOIN dbo.BgPosition BPO ON BPO.BgBudgetID = BBG.BgBudgetID
  WHERE BPO.BgSpezkontoID = @BgSpezkontoID
    AND BBG.Spezkonto = 0
	AND BPO.BgKategorieCode IN (3,4,6);

  -- einfügen
  INSERT INTO BgPosition (BgBudgetID, BgKategorieCode, Betrag, BgSpezkontoID, Buchungstext, BaPersonID, VerwPeriodeVon, VerwPeriodeBis)
    SELECT BBG.BgBudgetID,
	       @BgKategorieCode,
		   SSK.BetragProMonat,
		   SSK.BgSpezkontoID,
		   SSK.NameSpezkonto,
		   SSK.BaPersonID,
		   BBG.DatumBudget,
		   dbo.fnLastDayOf(BBG.DatumBudget)
    FROM @BgBudget               BBG
      INNER JOIN dbo.BgSpezkonto SSK WITH (READUNCOMMITTED) ON SSK.BgSpezkontoID = @BgSpezkontoID
    WHERE BBG.Spezkonto = 1
      AND (MasterBudget = 0 OR @BgKategorieCode = 6)
      AND EXISTS (SELECT TOP 1 1    --Nur Verrechnungen auf aktiven Ausgabe-Positionsarten weiterhin erstellen
                  FROM BgPositionsart
                  WHERE BgKostenartID = SSK.BgKostenartID
                  AND BgKategorieCode IN (2, 3))
      AND NOT EXISTS (SELECT TOP 1 1      
                      FROM dbo.BgPosition WITH (READUNCOMMITTED)
                      WHERE BgBudgetID      = BBG.BgBudgetID
                        AND BgSpezkontoID   = @BgSpezkontoID
                        AND BgKategorieCode = @BgKategorieCode)

  -- aktualisieren
  UPDATE BPO
    SET Betrag         = CASE
                           WHEN BBG.MasterBudget = 1 AND BBG.BgBewilligungStatusCode <= 5
                             THEN ISNULL(@BetragProMonat, Betrag)
                             ELSE Betrag
                           END,
        DatumVon       = CASE WHEN BBG.MasterBudget = 1 AND BBG.BgBewilligungStatusCode <= 5  THEN SSK.DatumVon ELSE NULL END,
        DatumBis       = CASE WHEN BBG.MasterBudget = 1 AND BBG.BgBewilligungStatusCode <= 5  THEN SSK.DatumBis ELSE NULL END,
        Buchungstext   = SSK.NameSpezkonto,
        BaPersonID     = SSK.BaPersonID,
        VerwPeriodeVon = CASE WHEN BBG.MasterBudget = 0 THEN BBG.DatumBudget END,
        VerwPeriodeBis = CASE WHEN BBG.MasterBudget = 0 THEN dbo.fnLastDayOf(BBG.DatumBudget) END
  FROM @BgBudget               BBG
    INNER JOIN dbo.BgPosition  BPO WITH (READUNCOMMITTED) ON BPO.BgBudgetID = BBG.BgBudgetID
    INNER JOIN dbo.BgSpezkonto SSK WITH (READUNCOMMITTED) ON SSK.BgSpezkontoID = BPO.BgSpezkontoID
  WHERE BPO.BgKategorieCode IN (3, 4, 6)
    AND BPO.BgSpezkontoID = @BgSpezkontoID
    AND BBG.Spezkonto = 1

  -- Monatsbudget - Abzahlungskonto
  DECLARE cAbzahlungskonto CURSOR FAST_FORWARD LOCAL FOR
    SELECT BgBudgetID
    FROM @BgBudget
    WHERE MasterBudget = 0
	  AND BgBewilligungStatusCode < 5
    ORDER BY DatumBudget

  OPEN cAbzahlungskonto
  WHILE 1 = 1 BEGIN
    FETCH NEXT FROM cAbzahlungskonto INTO @BgBudgetID
    IF @@FETCH_STATUS != 0 BREAK

    EXECUTE spWhBudget_Abzahlungskonto @BgBudgetID
  END
  CLOSE cAbzahlungskonto
  DEALLOCATE cAbzahlungskonto

  -- Das Enddatum auch aktualisieren, falls keine Monatsbudgets vorhanden sind.
  UPDATE dbo.BgSpezkonto
  SET DatumBis = dbo.fnWhBudget_GetSpezkontoEnddatum(BgSpezkontoID, DatumVon, StartSaldo, BetragProMonat, Inaktiv)
  WHERE BgSpezkontoID = @BgSpezkontoID
    AND BgSpezkontoTypCode = 3; -- Enddatum nur bei Verrechnung automatisch berechnen

END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
