SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhBudget_Reset
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spWhBudget_Reset.sql $
  $Author: Ckaeser $
  $Modtime: 23.06.09 15:12 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/spWhBudget_Reset.sql $
 * 
 * 2     25.06.09 8:47 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/
/*
  KiSS 4.0
  --------
  DB-Object: spWhBudget_Reset
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:55
*/
CREATE PROCEDURE dbo.spWhBudget_Reset
 (@BgFinanzplanID   int,
  @BgBudgetID       int)
AS BEGIN
  IF EXISTS (SELECT * FROM BgBudget WHERE BgBudgetID = @BgBudgetID AND MasterBudget = 1 AND BgBewilligungStatusCode = 5) BEGIN  -- Masterbudget
    UPDATE BPO
      SET BgPositionID_CopyOf = MAS.BgPositionID_CopyOf
    FROM BgPosition          MAS
      INNER JOIN dbo.BgPosition  BPO ON BPO.BgPositionID_CopyOf = MAS.BgPositionID
    WHERE MAS.BgBudgetID = @BgBudgetID
      AND MAS.DatumVon = '19000102'

    DELETE BgPosition
    WHERE BgBudgetID = @BgBudgetID AND DatumVon = '19000102'

    UPDATE BgPosition
      SET DatumBis = NULL
    WHERE BgBudgetID = @BgBudgetID AND DatumBis = '19000101'

    -- Spzialkonto
    DECLARE @BgSpezkontoID  int

    DECLARE cShSpezkonto CURSOR FAST_FORWARD FOR
      SELECT BgSpezkontoID
      FROM BgFinanzplan         SFP
        INNER JOIN BgSpezkonto  SSK ON SSK.FaLeistungID = SFP.FaLeistungID
      WHERE SFP.BgFinanzplanID = @BgFinanzplanID

    OPEN cShSpezkonto
    WHILE 1 = 1 BEGIN
      FETCH NEXT FROM cShSpezkonto INTO @BgSpezkontoID
      IF @@FETCH_STATUS != 0 BREAK

      EXECUTE spWhSpezkonto_UpdateBudget @BgSpezkontoID, @BgFinanzplanID, @BgBudgetID
    END
    CLOSE cShSpezkonto
    DEALLOCATE cShSpezkonto
  END

  IF EXISTS (SELECT * FROM BgBudget WHERE BgBudgetID = @BgBudgetID AND MasterBudget = 0 AND BgBewilligungStatusCode < 5) BEGIN  -- Monatsbudget
    DECLARE @BgPosition TABLE (
      BgPositionID int PRIMARY KEY
    )

    INSERT INTO @BgPosition
      SELECT BgPositionID
      FROM BgPosition    BPO
      WHERE BPO.BgBudgetID = @BgBudgetID
        AND (BgPositionID_CopyOf IS NOT NULL OR BgKategorieCode IN (3, 6)) -- Vorabzug / Verrechnung

    DELETE APT
    FROM @BgPosition                       TMP
      INNER JOIN BgAuszahlungPerson        BAP ON BAP.BgPositionID = TMP.BgPositionID
      INNER JOIN BgAuszahlungPersonTermin  APT ON APT.BgAuszahlungPersonID = BAP.BgAuszahlungPersonID

    DELETE BAP
    FROM @BgPosition                       TMP
      INNER JOIN BgAuszahlungPerson        BAP ON BAP.BgPositionID = TMP.BgPositionID

    DELETE BPO
    FROM @BgPosition                       TMP
      INNER JOIN BgPosition                BPO ON BPO.BgPositionID = TMP.BgPositionID

    EXECUTE spWhBudget_Create @BgFinanzplanID, @BgBudgetID
  END
END
GO