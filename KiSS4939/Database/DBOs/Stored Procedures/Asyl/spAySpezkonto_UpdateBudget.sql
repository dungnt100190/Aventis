SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spAySpezkonto_UpdateBudget
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spAySpezkonto_UpdateBudget.sql $
  $Author: Ckaeser $
  $Modtime: 23.06.09 15:32 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/spAySpezkonto_UpdateBudget.sql $
 * 
 * 2     25.06.09 11:40 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/

/*
  KiSS 4.0
  --------
  DB-Object: spAySpezkonto_UpdateBudget
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:54
*/
CREATE PROCEDURE dbo.spAySpezkonto_UpdateBudget
 (@BgSpezkontoID   int,
  @BgFinanzplanID  int = NULL,
  @BgBudgetID      int = NULL)
AS BEGIN
  DECLARE @BgBudget TABLE (
    BgFinanzplanID           int NOT NULL,
    BgBudgetID               int NOT NULL,
    MasterBudget             bit NOT NULL,
    Jahr                     int NULL,
    Monat                    int NULL,
    BgBewilligungStatusCode  int NOT NULL,
    Spezkonto                bit NOT NULL
  )

  DECLARE @FaLeistungID     int,
          @BgKategorieCode  int,
          @BetragProMonat   money,
          @DatumVon         datetime,
          @DatumBis         datetime

  SELECT
    @FaLeistungID    = FaLeistungID,
    @BgKategorieCode = CASE BgSpezkontoTypCode
                         WHEN 1 THEN 2  -- Ausgabekonto
                         WHEN 2 THEN 6  -- Vorabzugskonto
                         WHEN 3 THEN 3  -- Abzahlungskonto
                         ELSE NULL
                       END,
    @BetragProMonat  = BetragProMonat,
    @DatumVon        = DatumVon,
    @DatumBis        = DatumBis
  FROM dbo.BgSpezkonto WITH (READUNCOMMITTED) 
  WHERE BgSpezkontoID = @BgSpezkontoID

  -- Zu aktualisierende Master- / Monatsbudgets suchen
  INSERT INTO @BgBudget (BgFinanzplanID, BgBudgetID, MasterBudget, Jahr, Monat, BgBewilligungStatusCode, Spezkonto)
    SELECT SFP.BgFinanzplanID, BBG.BgBudgetID, BBG.MasterBudget, Jahr, Monat, BBG.BgBewilligungStatusCode, 0
    FROM dbo.BgFinanzplan        SFP WITH (READUNCOMMITTED) 
      INNER JOIN dbo.BgBudget    BBG WITH (READUNCOMMITTED) ON BBG.BgFinanzplanID = SFP.BgFinanzplanID
    WHERE SFP.FaLeistungID = @FaLeistungID
      AND (BBG.BgBewilligungStatusCode < 5 OR (BBG.MasterBudget = 1 AND BBG.BgBewilligungStatusCode = 5))

  DELETE FROM @BgBudget WHERE BgFinanzplanID != @BgFinanzplanID
  DELETE FROM @BgBudget WHERE BgBudgetID != @BgBudgetID

  UPDATE TMP
    SET Spezkonto = 1
  FROM @BgBudget             TMP
    INNER JOIN dbo.BgFinanzplan  SFP WITH (READUNCOMMITTED) ON SFP.BgFinanzplanID = TMP.BgFinanzplanID
    INNER JOIN dbo.BgBudget      BBG WITH (READUNCOMMITTED) ON BBG.BgBudgetID     = TMP.BgBudgetID
  WHERE ((BBG.MasterBudget = 1 AND IsNull(SFP.DatumVon, SFP.GeplantVon) < IsNull(@DatumBis, '20790606') AND COALESCE(SFP.DatumBis, SFP.GeplantBis, '20790606') > @DatumVon ) OR
         (BBG.MasterBudget = 0 AND dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 15) BETWEEN @DatumVon AND IsNull(@DatumBis, '20790606') ))

  -- Master- / Monatsbudget aktualisieren
  IF @BgKategorieCode = 2 BEGIN
    UPDATE BPO
      SET BgSpezkontoID = NULL
    FROM @BgBudget           BBG
      INNER JOIN dbo.BgPosition  BPO WITH (READUNCOMMITTED) ON BPO.BgBudgetID = BBG.BgBudgetID
    WHERE BPO.BgSpezkontoID = @BgSpezkontoID AND BBG.Spezkonto = 0

    RETURN
  END

  -- löschen
  DELETE BPO
  FROM @BgBudget           BBG
    INNER JOIN BgPosition  BPO ON BPO.BgBudgetID = BBG.BgBudgetID
  WHERE BPO.BgSpezkontoID = @BgSpezkontoID AND BBG.Spezkonto = 0
    AND BPO.BgKategorieCode IN (3, 6)

  -- einfügen
  INSERT INTO BgPosition (BgBudgetID, BgKategorieCode, Betrag, BgSpezkontoID)
    SELECT BBG.BgBudgetID, @BgKategorieCode, @BetragProMonat, @BgSpezkontoID
    FROM @BgBudget         BBG
    WHERE BBG.Spezkonto = 1
      AND (MasterBudget = 0 OR @BgKategorieCode = 6)
      AND NOT EXISTS (SELECT * FROM BgPosition
                      WHERE BgBudgetID = BBG.BgBudgetID AND BgSpezkontoID = @BgSpezkontoID
                        AND BgKategorieCode = @BgKategorieCode)

  -- aktualisieren
  UPDATE BPO
    SET Betrag      = CASE WHEN BBG.MasterBudget = 1 AND BBG.BgBewilligungStatusCode <= 5  THEN IsNull(@BetragProMonat, Betrag) ELSE Betrag END,
        DatumVon    = CASE WHEN BBG.MasterBudget = 1 AND BBG.BgBewilligungStatusCode <= 5  THEN @DatumVon ELSE NULL END,
        DatumBis    = CASE WHEN BBG.MasterBudget = 1 AND BBG.BgBewilligungStatusCode <= 5  THEN @DatumBis ELSE NULL END
  FROM @BgBudget           BBG
    INNER JOIN BgPosition  BPO ON BPO.BgBudgetID = BBG.BgBudgetID
  WHERE BPO.BgKategorieCode IN (3, 6)
    AND BPO.BgSpezkontoID = @BgSpezkontoID AND BBG.Spezkonto = 1

  -- Monatsbudget - Abzahlungskonto
  DECLARE cAbzahlungskonto CURSOR FAST_FORWARD FOR
    SELECT BgBudgetID
    FROM @BgBudget
    WHERE MasterBudget = 0 AND BgBewilligungStatusCode < 5
      AND @BgKategorieCode = 3

  OPEN cAbzahlungskonto
  WHILE 1 = 1 BEGIN
    FETCH NEXT FROM cAbzahlungskonto INTO @BgBudgetID
    IF @@FETCH_STATUS != 0 BREAK

    EXECUTE spAyBudget_Abzahlungskonto @BgBudgetID, @BgSpezkontoID
  END
  CLOSE cAbzahlungskonto
  DEALLOCATE cAbzahlungskonto
END
GO