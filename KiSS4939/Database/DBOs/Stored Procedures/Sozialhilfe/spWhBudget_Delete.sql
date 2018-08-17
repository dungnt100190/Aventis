SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhBudget_Delete
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spWhBudget_Delete.sql $
  $Author: Ckaeser $
  $Modtime: 23.06.09 15:13 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/spWhBudget_Delete.sql $
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
  DB-Object: spWhBudget_Delete
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:55
*/
CREATE PROCEDURE dbo.spWhBudget_Delete
 (@BgBudgetID   int)
AS BEGIN
  IF EXISTS (SELECT * FROM BgBudget WHERE BgBudgetID = @BgBudgetID AND MasterBudget = 1 AND BgBewilligungStatusCode >= 5) BEGIN
    RAISERROR('Das Masterbudget kann nicht gelöscht werden', 18, 1)
    RETURN -1
  END

  DECLARE @BudgetMonat  varchar(100)
  SELECT @BudgetMonat = dbo.fnXMonatJahr(dbo.fnDateSerial(Jahr, IsNull(Monat, 1), 1))
  FROM BgBudget WHERE BgBudgetID = @BgBudgetID

  IF EXISTS (SELECT * FROM BgBudget WHERE BgBudgetID = @BgBudgetID AND MasterBudget = 0 AND BgBewilligungStatusCode >= 5) BEGIN
    RAISERROR('Das Monatsbudget ''%s'' kann nicht gelöscht/zurückgesetzt werden, es ist zur Zahlung freigegeben', 18, 1, @BudgetMonat)
    RETURN -1
  END

  IF EXISTS (
    SELECT *
    FROM BgBudget                 BBG
      LEFT  JOIN KbBuchung        NET ON NET.BgBudgetID = BBG.BgBudgetID AND NET.KbBuchungStatusCode NOT IN (1, 2, 7)
-- BSS!      LEFT  JOIN KbBuchungBrutto  BRT ON BRT.BgBudgetID = BBG.BgBudgetID AND BRT.KbBuchungStatusCode NOT IN (1, 2, 7)
    WHERE BBG.BgBudgetID = @BgBudgetID
      AND (NET.BgBudgetID IS NOT NULL) --BSS! OR BRT.BgBudgetID IS NOT NULL)
  ) BEGIN
    RAISERROR('Das Monatsbudget ''%s'' kann nicht gelöscht/zurückgesetzt werden, es enthält verbuchte Belege', 18, 1, @BudgetMonat)
    RETURN -1
  END

  -- KbBuchung
  DELETE FROM KbBuchung        WHERE BgBudgetID = @BgBudgetID
  --BSS! DELETE FROM KbBuchungBrutto  WHERE BgBudgetID = @BgBudgetID

  -- BgPosition
  DELETE FROM BgPosition       WHERE BgBudgetID = @BgBudgetID
END
GO