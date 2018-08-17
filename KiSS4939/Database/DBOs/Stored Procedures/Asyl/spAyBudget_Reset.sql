SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spAyBudget_Reset
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spAyBudget_Reset.sql $
  $Author: Ckaeser $
  $Modtime: 23.06.09 15:34 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/spAyBudget_Reset.sql $
 * 
 * 2     25.06.09 11:42 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/
/*
  KiSS 4.0
  --------
  DB-Object: spAyBudget_Reset
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:53
*/
CREATE PROCEDURE dbo.spAyBudget_Reset
 (@BgFinanzplanID   int,
  @BgBudgetID       int)
AS BEGIN
  IF EXISTS (SELECT * FROM BgBudget WHERE BgBudgetID = @BgBudgetID AND MasterBudget = 1 AND BgBewilligungStatusCode = 5) BEGIN  -- Masterbudget
    UPDATE BPO
      SET BgPositionID_CopyOf = MAS.BgPositionID_CopyOf
    FROM BgPosition          MAS
      INNER JOIN BgPosition  BPO ON BPO.BgPositionID_CopyOf = MAS.BgPositionID
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

      EXECUTE spAySpezkonto_UpdateBudget @BgSpezkontoID, @BgFinanzplanID, @BgBudgetID
    END
    CLOSE cShSpezkonto
    DEALLOCATE cShSpezkonto
  END

  IF EXISTS (SELECT * FROM BgBudget WHERE BgBudgetID = @BgBudgetID AND MasterBudget = 0 AND BgBewilligungStatusCode < 5) BEGIN  -- Monatsbudget
    EXECUTE spAyBudget_Delete @BgBudgetID
    EXECUTE spAyBudget_Create @BgFinanzplanID, @BgBudgetID
  END
END
GO